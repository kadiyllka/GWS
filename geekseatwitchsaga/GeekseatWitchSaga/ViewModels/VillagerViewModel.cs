using GeekseatWitchSaga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekseatWitchSaga.Models
{
    public class VillagerViewModel
    {
        public List<Villager> Villagers { get; set; }
        public int NumberOfPeopleKilledA { get; set; }
        public int NumberOfPeopleKilledB { get; set; }
        public decimal Average { get; set; }
    }
}
