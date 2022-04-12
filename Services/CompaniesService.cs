using System;
using System.Collections.Generic;
using Contracted.Models;
using Contracted.Repositories;

namespace Contracted.Services
{
    public class CompaniesService
    {
        private readonly CompaniesRepository _compRepo;

        public CompaniesService(CompaniesRepository compRepo)
        {
            _compRepo = compRepo;
        }

        internal List<Company> GetAll()
        {
            return _compRepo.GetAll();
        }

        internal Company GetById(int id)
        {
            Company found = _compRepo.GetById(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        internal Company Create(Company companyData)
        {
            return _compRepo.Create(companyData);
        }

        internal string Remove(int id, Account user)
        {
            Company company = _compRepo.GetById(id);
            if (company.creatorId != user.Id)
            {
                throw new Exception("you can't do that, nice try.");
            }
            return _compRepo.Remove(id);
        }

        internal Company Update(Company companyData)
        {
            Company original = GetById(companyData.Id);
            original.Name = companyData.Name ?? original.Name;
            _compRepo.Update(original);
            return original;
        }
    }
}