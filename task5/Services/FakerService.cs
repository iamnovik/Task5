using System.Globalization;
using Bogus;
using task5.Models;

namespace task5.Services;

public class FakerService : IFakerService
{
    
    
    
    public List<UserData> GenerateFakeData(string region, int seed, int page, double errorCount)
        {
            var culture = GetCultureCode(region);
            var faker = new Faker(culture);
            faker.Random = new Randomizer(seed);
            var pageNumber = (page - 1 ) * 20;
            var fakeDataList = new List<UserData>();

            for (int i = pageNumber; i < pageNumber + 20; i++) // Генерируем 20 записей
            {
                var userData = new UserData();

                // Генерация случайных данных
                userData.Number = i + 1;
                userData.Id = faker.Random.AlphaNumeric(8);
                userData.FullName = faker.Name.FullName();
                userData.Address = faker.Address.StreetAddress();
                userData.PhoneNumber = faker.Phone.PhoneNumber();

                fakeDataList.Add(userData);
            }
            AddErrorsToUserDataList(fakeDataList, errorCount, faker);
            return fakeDataList;
        }

        // Метод для получения кода культуры на основе региона
        public string GetCultureCode(string region)
        {
            switch (region)
            {
                case "USA":
                    return "en_US";
                case "Poland":
                    return "pl";
                case "Russia":
                    return "ru";
                default:
                    return "en_US";
            }
        }
        

        // Метод для добавления ошибок к данным пользователя
        public void AddErrorsToUserDataList(List<UserData> userDataList, double errorCount, Faker faker)
        {
            foreach (var userData in userDataList)
            {
                double fractionalPart = errorCount - Math.Floor(errorCount);
                double randomDouble = faker.Random.Double();
                if (randomDouble <= fractionalPart)
                {
                var propertyIndex = faker.Random.Int(2, 4);

                // Генерация случайного вида ошибки
                var errorType = faker.Random.Int(0, 2);

                // Ошибка в номере
                if (errorType == 0)
                {
                    // Удаление одного символа в случайной позиции
                    if (userData[propertyIndex].Length > 0)
                    {
                        var indexToRemove = faker.Random.Int(0, userData[propertyIndex].Length - 1);
                        userData[propertyIndex] = userData[propertyIndex].Remove(indexToRemove, 1);
                    }
                }
                else if (errorType == 1)
                {
                    // Добавление одного случайного символа в случайной позиции
                    var indexToAdd = faker.Random.Int(0, userData[propertyIndex].Length - 1);
                    var randomChar = Convert.ToChar(faker.Random.Int(0,26) + 65); 
                    userData[propertyIndex] = userData[propertyIndex].Insert(indexToAdd, randomChar.ToString());
                }
                else if (errorType == 2)
                {
                    // Перестановка двух соседних символов местами
                    if (userData[propertyIndex].Length > 1)
                    {
                        var indexToSwap = faker.Random.Int(0, userData[propertyIndex].Length - 2);
                        var tempChar = userData[propertyIndex][indexToSwap];
                        userData[propertyIndex] = userData[propertyIndex].Remove(indexToSwap, 1).Insert(indexToSwap + 1, tempChar.ToString());
                    }
                }
            }
            
            
            for (int i = 0; i < errorCount; i++)
            {
                // Генерация случайного индекса свойства
                var propertyIndex = faker.Random.Int(2, 4);

                // Генерация случайного вида ошибки
                var errorType = faker.Random.Int(0, 2);

                // Ошибка в номере
                if (errorType == 0)
                {
                    // Удаление одного символа в случайной позиции
                    if (userData[propertyIndex].Length > 0)
                    {
                        var indexToRemove = faker.Random.Int(0, userData[propertyIndex].Length - 1);
                        userData[propertyIndex] = userData[propertyIndex].Remove(indexToRemove, 1);
                    }
                }
                else if (errorType == 1)
                {
                    // Добавление одного случайного символа в случайной позиции
                    var indexToAdd = faker.Random.Int(0, userData[propertyIndex].Length - 1);
                    var randomChar = Convert.ToChar(faker.Random.Int(0,26) + 65); 
                    userData[propertyIndex] = userData[propertyIndex].Insert(indexToAdd, randomChar.ToString());
                }
                else if (errorType == 2)
                {
                    // Перестановка двух соседних символов местами
                    if (userData[propertyIndex].Length > 1)
                    {
                        var indexToSwap = faker.Random.Int(0, userData[propertyIndex].Length - 2);
                        var tempChar = userData[propertyIndex][indexToSwap];
                        userData[propertyIndex] = userData[propertyIndex].Remove(indexToSwap, 1).Insert(indexToSwap + 1, tempChar.ToString());
                    }
                }
                       
            }
            }
            
        }
}