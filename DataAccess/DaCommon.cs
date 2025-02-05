using MasterClass;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DataAccess
{
    public class DaCommon
    {
        #region GLobal
        private readonly string _connectionString;
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;
        private SqlDataAdapter _sqlDataAdapter;
        private SqlDataReader _sqlDataReader;
        #endregion

        #region Constructor
        public DaCommon(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DatabaseConStr");
            _sqlConnection = new SqlConnection(_connectionString);
        }
        #endregion

        #region Sql Connection States
        public void OpenConnection()
        {
            try
            {
                if(_sqlConnection.State == ConnectionState.Closed)
                {
                    _sqlConnection.Open();
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error opening database connection", ex);
            }
        }

        public void CloseConnection()
        {
            if(_sqlConnection.State == ConnectionState.Open)
            {
                _sqlConnection.Close();
            }
        }
        #endregion

        #region Dynamic Parameter Method
        public SqlParameter CreateParameter(string name, object value, SqlDbType type, ParameterDirection direction = ParameterDirection.Input) =>
            new SqlParameter
            {
                ParameterName = name,
                Value = value ?? DBNull.Value,
                SqlDbType = type,
                Direction = direction
            };
        #endregion

        #region Get All Records
        public DataTable GetAllRecords(string storedProcedure, List<SqlParameter>? parameters = null)
        {
            DataTable dataTable = new DataTable();
            try
            {
                OpenConnection();
                _sqlCommand = new SqlCommand(storedProcedure, _sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if(parameters != null)
                {
                    _sqlCommand.Parameters.AddRange(parameters.ToArray());
                }

                _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                _sqlDataAdapter.Fill(dataTable);
            }
            catch(Exception ex)
            {
                throw new Exception("Error fetching records", ex);
            }
            finally
            {
                CloseConnection();
            }
            return dataTable;
        }
        #endregion

        #region Get Records By Id
        public DataRow GetRecordById(string storedProcedure, List<SqlParameter> parameters)
        {
            try
            {
                DataTable dataTable = GetAllRecords(storedProcedure, parameters);
                return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Execute Non Query and Get All Records of Table as DataTable
        public int ExecuteNonQuery(string storedProcedure, List<SqlParameter> parameters)
        {
            int result = 0;
            try
            {
                OpenConnection();
                _sqlCommand = new SqlCommand(storedProcedure, _sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                if(parameters != null)
                {
                    _sqlCommand.Parameters.AddRange(parameters.ToArray());
                }
                result = _sqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new Exception("Error executing command", ex);
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }
        #endregion

        #region Execute Scalar and Get Single Record
        public object ExecuteScalar(string storedProcedure, List<SqlParameter> parameters)
        {
            object result;
            try
            {
                OpenConnection();
                _sqlCommand = new SqlCommand(storedProcedure, _sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                if(parameters != null)
                {
                    _sqlCommand.Parameters.AddRange(parameters.ToArray());
                }
                result = _sqlCommand.ExecuteScalar();
            }
            catch(Exception ex)
            {
                throw new Exception("Error executing scalar command", ex);
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }
        #endregion

        #region Object Destructor
        public void Dispose()
        {
            if(_sqlConnection != null)
            {
                _sqlConnection.Dispose();
            }
            if(_sqlCommand != null)
            {
                _sqlCommand.Dispose();
            }
            if(_sqlDataAdapter != null)
            {
                _sqlDataAdapter.Dispose();
            }
        }
        #endregion
    }
}
