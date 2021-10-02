using GeekseatWitchSaga.Helpers;
using GeekseatWitchSaga.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GeekseatWitchSaga.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View(new VillagerViewModel());
        }
        [HttpPost]
        public IActionResult Index([FromForm] VillagerViewModel villager)
        {
            if (!ModelState.IsValid)
                return View((new VillagerViewModel() { Average = -1 }));

            foreach (var item in villager.Villagers)
            {
                if (item.AgeOfDeath < 0 || item.YearOfDeath < 0)
                {
                    return View(new VillagerViewModel() { Average = -1 });
                }
                else
                {
                    item.YearOfBirth = item.YearOfDeath - item.AgeOfDeath;
                }

            }

            var numberOfPeopleKilledA = NumberOfPeopleKilled.CalculateNumberOfPeopleKilled(villager.Villagers[0].YearOfDeath, villager.Villagers[0].AgeOfDeath);
            var numberOfPeopleKilledB = NumberOfPeopleKilled.CalculateNumberOfPeopleKilled(villager.Villagers[1].YearOfDeath, villager.Villagers[1].AgeOfDeath);
            decimal averageNumber;
            if (numberOfPeopleKilledA <= 0 || numberOfPeopleKilledB <= 0)
            {
                averageNumber = -1;
            }
            else
            {
                averageNumber = (decimal)(numberOfPeopleKilledA + numberOfPeopleKilledB) / 2;
            }


            VillagerViewModel _villager = new VillagerViewModel
            {
                Villagers = villager.Villagers,
                Average = averageNumber,
                NumberOfPeopleKilledA = numberOfPeopleKilledA,
                NumberOfPeopleKilledB = numberOfPeopleKilledB
            };
            return View(_villager);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
