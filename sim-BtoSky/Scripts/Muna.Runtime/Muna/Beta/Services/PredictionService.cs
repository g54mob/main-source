using Muna.API;

namespace Muna.Beta.Services
{
	public sealed class PredictionService
	{
		public readonly RemotePredictionService Remote;

		internal PredictionService(MunaClient client)
		{
			Remote = new RemotePredictionService(client);
		}
	}
}
