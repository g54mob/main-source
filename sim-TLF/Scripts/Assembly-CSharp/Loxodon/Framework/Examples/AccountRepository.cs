using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loxodon.Framework.Examples
{
	public class AccountRepository : IAccountRepository
	{
		private Dictionary<string, Account> cache = new Dictionary<string, Account>();

		public AccountRepository()
		{
			Account account = new Account
			{
				Username = "test",
				Password = "test",
				Created = DateTime.Now
			};
			cache.Add(account.Username, account);
		}

		public virtual Task<Account> Get(string username)
		{
			Account value = null;
			cache.TryGetValue(username, out value);
			return Task.FromResult(value);
		}

		public virtual async Task<Account> Save(Account account)
		{
			if (cache.ContainsKey(account.Username))
			{
				throw new Exception("The account already exists.");
			}
			cache.Add(account.Username, account);
			return account;
		}

		public virtual Task<Account> Update(Account account)
		{
			throw new NotImplementedException();
		}

		public virtual Task<bool> Delete(string username)
		{
			throw new NotImplementedException();
		}
	}
}
