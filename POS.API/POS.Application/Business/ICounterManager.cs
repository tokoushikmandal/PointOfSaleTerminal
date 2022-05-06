
namespace POS.Application.Business
{
    public interface ICounterManager
    {
        double ProcessAndCalculateTotal(string codes);
        bool Validate(string codes);
    }
}
