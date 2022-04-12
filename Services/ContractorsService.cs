using System;
using System.Collections.Generic;
using Contracted.Models;
using Contracted.Repositories;

namespace Contracted.Services
{
    public class ContractorsService
    {
        private readonly ContractorsRepository _contRepo;

        public ContractorsService(ContractorsRepository contRepo)
        {
            _contRepo = contRepo;
        }

        internal List<Contractor> GetAll()
        {
            return _contRepo.GetAll();
        }

        internal Contractor GetById(int id)
        {
            Contractor found = _contRepo.GetById(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        internal Contractor Create(Contractor contractorData)
        {
            return _contRepo.Create(contractorData);
        }

        internal string Remove(int id, Account user)
        {
            Contractor contractor = _contRepo.GetById(id);
            if (contractor.creatorId != user.Id)
            {
                throw new Exception("you can't do that, nice try.");
            }
            return _contRepo.Remove(id);
        }

        internal Contractor Update(Contractor contractorData)
        {
            Contractor original = GetById(contractorData.Id);
            original.Name = contractorData.Name ?? original.Name;
            _contRepo.Update(original);
            return original;
        }
    }
}