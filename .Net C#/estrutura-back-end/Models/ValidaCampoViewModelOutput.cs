using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estrutura_back_end.Models
{
    public class ValidaCampoViewModelOutput
    {
        public IEnumerable<string> Erros { get; private set; }
        public  ValidaCampoViewModelOutput(IEnumerable<string> err)
    }
}
