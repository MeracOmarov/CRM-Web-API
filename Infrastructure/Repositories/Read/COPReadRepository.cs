﻿using Abstraction.Abstractions.Read;
using AutoMapper;
using Buisness.DTOs.Query;
using Domen.Models.QueryModel;
using Infrastructure.DataContexts.QueryDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.QueryRepositories
{
    public class COPReadRepository : ICOPReadRepository
    {
        private readonly CompanyReadDbContext _companyDbContextread;
        private readonly IMapper _mapper;

        public COPReadRepository(CompanyReadDbContext DbContext, IMapper mapper)
        {
            _companyDbContextread = DbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<COPReadDTO>> GetCOPsAsync(Guid CustomerPIN,
                                                                CancellationToken cancellationToken)
        {
            List<COPReadModel> cops = await _companyDbContextread.ClientOrderProducts
                .Where(x => x.CustomerPIN == CustomerPIN)
                .ToListAsync();

            List<COPReadDTO> responses = new();

            COPReadDTO response;

            int CountOfEltities = cops.Count;

            for (int i = 0; i < CountOfEltities; i++)
            {
                response = _mapper.Map<COPReadDTO>(cops[i]);

                responses.Add(response);
            }

            return responses;
        }

        public async Task<COPReadDTO> GetCOPAsync(Guid OrderCode, CancellationToken cancellationToken)
        {
            //Validation
            CheckGuid(OrderCode);

            //Entity from database 
            COPReadModel? customerOrderProductFromdb = await _companyDbContextread.ClientOrderProducts
                .SingleOrDefaultAsync(x => x.OrderCode == OrderCode);

            if (customerOrderProductFromdb == null)
                throw new Exception("CustomerOrderProduct Error: The CustomerOrderProduct dose not exist");

            // Mapping Entity to DTO
            var response = _mapper.Map<COPReadDTO>(customerOrderProductFromdb);

            return response;
        }

        private void CheckGuid(Guid guid)
        {
            if(guid==null)
                throw new Exception("Validation Error: The order_Code field can not be null");

            if (!(guid.GetType() == typeof(Guid)))
                throw new Exception("Validation Error: The order_Code field must be guid");
        }
    }
}
