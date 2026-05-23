using Muna.API;
using Muna.Beta.OpenAI;
using Muna.Beta.Services;
using Muna.Services;

namespace Muna.Beta
{
	public sealed class BetaClient
	{
		public readonly global::Muna.Beta.Services.PredictionService Predictions;

		public readonly OpenAIClient OpenAI;

		internal BetaClient(MunaClient client, PredictorService predictors, global::Muna.Services.PredictionService predictions)
		{
			Predictions = new global::Muna.Beta.Services.PredictionService(client);
			OpenAI = new OpenAIClient(predictors, predictions, Predictions.Remote);
		}
	}
}
