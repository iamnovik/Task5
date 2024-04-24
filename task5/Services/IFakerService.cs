using Bogus;
using task5.Models;

namespace task5.Services;

public interface IFakerService
{
    List<UserData> GenerateFakeData(string region, int seed, int page);

    string GetCultureCode(string region);

    void AddErrorsToUserDataList(List<UserData> userDataList, double errorCount);

}