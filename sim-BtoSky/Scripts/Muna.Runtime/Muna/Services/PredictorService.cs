using System.Threading.Tasks;
using Muna.API;

namespace Muna.Services
{
	public sealed class PredictorService
	{
		private readonly MunaClient client;

		public async Task<Predictor?> Retrieve(string tag)
		{
			try
			{
				return await client.Request<Predictor>("GET", "/predictors/" + tag);
			}
			catch (MunaAPIException ex)
			{
				if (ex.status == 404)
				{
					return null;
				}
				throw;
			}
		}

		internal PredictorService(MunaClient client)
		{
			this.client = client;
		}
	}
}
