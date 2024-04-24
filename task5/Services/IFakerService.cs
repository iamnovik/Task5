using Bogus;
using task5.Models;

namespace task5.Services;

public interface IFakerService
{
    List<UserData> GenerateFakeData(string region, int seed, int page, double errorCount);

    string GetCultureCode(string region);

    void AddErrorsToUserDataList(List<UserData> userDataList, double errorCount, Faker faker);

}