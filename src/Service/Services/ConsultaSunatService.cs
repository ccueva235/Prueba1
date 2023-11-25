using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ConsultaSunatService: IConsultaSunatService
    {
        private readonly IConsultaSunatRepository consultaSunatRepository;

        public ConsultaSunatService(IConsultaSunatRepository consultaSunatRepository)
        {
            this.consultaSunatRepository = consultaSunatRepository;
        }
        public async Task<ConsultaSunat> BuscarDNI(string DNI)
        {
            return await consultaSunatRepository.BuscarDNI(DNI);
        }
        
        
    }
}
