using System.Threading.Tasks;

namespace Helpers.Initializaton
{
	public interface IInitAsync
	{
		Task InitializeAsync();
	}
	public interface IInitAsync<T>
	{
		Task InitializeAsync(T arg);
	}
}
