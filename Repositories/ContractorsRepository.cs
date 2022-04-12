using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Contracted.Models;


namespace Contracted.Repositories
{
    public class ContractorsRepository
    {
        private readonly IDbConnection _db;

        public ContractorsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Contractor> GetAll()
        {
            string sql = @"
            SELECT
            c.*,
            a.*
            FROM contractors c
            JOIN accounts a WHERE a.id = c.creatorId;
            ";
            return _db.Query<Contractor, Account, Contractor>(sql, (contractor, account) =>
            {
                contractor.Creator = account;
                return contractor;
            }).ToList();
        }

        internal Contractor GetById(int id)
        {
            string sql = @"
            SELECT 
            c.*,
            a.* 
            FROM contractors c
            JOIN accounts a ON c.creatorId = a.id
            WHERE c.id = @id;
            ";
            return _db.Query<Contractor, Account, Contractor>(sql, (contractor, account) =>
            {
                contractor.Creator = account;
                return contractor;
            }, new { id }).FirstOrDefault();
        }

        internal Contractor Create(Contractor contractorData)
        {
            string sql = @"
            INSERT INTO contractors
            (name, creatorId)
            VALUES
            (@Name, @CreatorId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, contractorData);
            contractorData.Id = id;
            return contractorData;
        }

        internal string Remove(int id)
        {
            string sql = @"
            DELETE FROM contractors WHERE id = @id LIMIT 1;
            ";
            int rowsAffected = _db.Execute(sql, new { id });
            if (rowsAffected > 0)
            {
                return "deleted";
            }
            throw new Exception("could not delete");
        }

        internal void Update(Contractor original)
        {
            string sql = @"
            UPDATE
                contractors
            SET
                name = @Name
            WHERE
                id = @Id;";
            _db.Execute(sql, original);
        }
    }
}