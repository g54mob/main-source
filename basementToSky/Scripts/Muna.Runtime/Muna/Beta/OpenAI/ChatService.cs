using Muna.Beta.Services;
using Muna.Services;

namespace Muna.Beta.OpenAI
{
	public sealed class ChatService
	{
		public readonly ChatCompletionService Completions;

		internal ChatService(PredictorService predictors, global::Muna.Services.PredictionService predictions, RemotePredictionService remotePredictions)
		{
			Completions = new ChatCompletionService(predictors, predictions, remotePredictions);
		}
	}
}
