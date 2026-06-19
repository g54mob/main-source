namespace Loxodon.Framework.Examples
{
	public class AccountEventArgs
	{
		public AccountEventType Type { get; private set; }

		public Account Account { get; private set; }

		public AccountEventArgs(AccountEventType type, Account account)
		{
			Type = type;
			Account = account;
		}
	}
}
