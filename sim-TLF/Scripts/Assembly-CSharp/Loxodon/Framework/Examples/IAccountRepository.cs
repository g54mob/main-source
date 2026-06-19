using System.Threading.Tasks;

namespace Loxodon.Framework.Examples
{
	public interface IAccountRepository
	{
		Task<Account> Get(string username);

		Task<Account> Save(Account account);

		Task<Account> Update(Account account);

		Task<bool> Delete(string username);
	}
}
