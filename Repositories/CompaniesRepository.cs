using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Contracted.Models;


namespace Contracted.Repositories
{
    public class CompaniesRepository
    {
        private readonly IDbConnection _db;

        public CompaniesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Company> GetAll()
        {
            string sql = @"
            SELECT
            c.*,
            a.*
            FROM companies c
            JOIN accounts a WHERE a.id = c.creatorId;
            ";
            return _db.Query<Company, Account, Company>(sql, (company, account) =>
            {
                company.Creator = account;
                return company;
            }).ToList();
        }

        internal Company GetById(int id)
        {
            string sql = @"
            SELECT 
            c.*,
            a.* 
            FROM companies c
            JOIN accounts a ON c.creatorId = a.id
            WHERE c.id = @id;
            ";
            return _db.Query<Company, Account, Company>(sql, (company, account) =>
            {
                company.Creator = account;
                return company;
            }, new { id }).FirstOrDefault();
        }

        internal Company Create(Company companyData)
        {
            string sql = @"
            INSERT INTO companies
            (name, creatorId)
            VALUES
            (@Name, @CreatorId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, companyData);
            companyData.Id = id;
            return companyData;
        }

        internal string Remove(int id)
        {
            string sql = @"
            DELETE FROM companies WHERE id = @id LIMIT 1;
            ";
            int rowsAffected = _db.Execute(sql, new { id });
            if (rowsAffected > 0)
            {
                return "deleted";
            }
            throw new Exception("could not delete");
        }

        internal void Update(Company original)
        {
            string sql = @"
            UPDATE
                companies
            SET
                name = @Name
            WHERE
                id = @Id;";
            _db.Execute(sql, original);
        }
    }
}