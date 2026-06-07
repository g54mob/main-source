using System.Threading.Tasks;
using Muna.API;

namespace Muna.Services
{
	public sealed class UserService
	{
		private readonly MunaClient client;

		public async Task<User?> Retrieve()
		{
			try
			{
				return await client.Request<User>("GET", "/users");
			}
			catch (MunaAPIException ex)
			{
				if (ex.status == 401)
				{
					return null;
				}
				throw;
			}
		}

		internal UserService(MunaClient client)
		{
			this.client = client;
		}
	}
}
