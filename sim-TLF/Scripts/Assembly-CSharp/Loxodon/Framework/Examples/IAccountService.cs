using System.Threading.Tasks;
using Loxodon.Framework.Messaging;

namespace Loxodon.Framework.Examples
{
	public interface IAccountService
	{
		IMessenger Messenger { get; }

		Task<Account> Register(Account account);

		Task<Account> Update(Account account);

		Task<Account> Login(string username, string password);

		Task<Account> GetAccount(string username);
	}
}
