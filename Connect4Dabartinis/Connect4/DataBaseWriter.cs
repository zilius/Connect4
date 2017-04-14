using Connect4.Models;
using System.Collections.Generic;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace Connect4
{
    public class DataBaseWriter
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Žygimantas\Desktop\Paskaitos\Connect4Git\Connect4\Connect4Dabartinis\Connect4\Database1.mdf;Integrated Security=True";

        private int _gameId;

        private List<Ejimai> _ejimaiIsDb;

        public DataBaseWriter()
        {
            _ejimaiIsDb = GetEjimai();
        }

        public void WriteData(List<Ejimai> data)
        {
            foreach (var ejimas in data)
            {
                string query =
                $@"INSERT INTO Ejimai 
                                ( 
                                GameId,
                                EjimoNr,
                                EjimasX
                                )                                   
                            VALUES 
                                (
                                @GameId,
                                @EjimoNr,
                                @EjimasX
                                 )
                            ";

                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    db.Execute(query, ejimas);
                }
            }
        }
        public int WriteGameAndGetId(Game game)
        {
            string query =
                $@"INSERT INTO Game 
                                ( 
                                Won
                                )                                   
                            VALUES 
                                (
                                @Won 
                                 )
                            SELECT SCOPE_IDENTITY()";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<int>(query, game).SingleOrDefault();
            }
        }

        public List<Ejimai> GetBestMove(int ejimas)
        {
            try
            {

                if (_ejimaiIsDb[ejimas] == null)
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }

            return _ejimaiIsDb.FindAll(e => e.EjimoNr == ejimas);
                   
        }

        private List<Ejimai> GetEjimai()
        {

            string query =
                $@"SELECT 
                        *
                   FROM
                        Ejimai
                         ";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Ejimai>
                    (query).ToList();
            }

        }


        

       
    }
}
