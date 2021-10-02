using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekseatWitchSaga.Helpers
{
    public class NumberOfPeopleKilled
    {
        public static int CalculateNumberOfPeopleKilled(int yearOfDeath, int ageOfDeath)
        {
            int yearOfBirth = yearOfDeath - ageOfDeath;
            if (yearOfBirth <= 0) {
                return yearOfBirth;
                }
            List<int> sequnce = new List<int>() { 1 };

            int firstItem = 0;
            int secondItem = 1;
            int next = 0;

            for (int i = 2; i <= yearOfBirth; i++)
            {

                next = firstItem + secondItem;
                firstItem = secondItem;
                secondItem = next;
                sequnce.Add(next);
            }

            int numberOfPeopleKilled = 0;
            foreach (int item in sequnce)
            {
                numberOfPeopleKilled += item;
            }


            return numberOfPeopleKilled;

        }
    }   
}
