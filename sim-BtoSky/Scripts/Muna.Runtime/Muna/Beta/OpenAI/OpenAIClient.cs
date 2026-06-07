using Muna.Beta.Services;
using Muna.Services;

namespace Muna.Beta.OpenAI
{
	public sealed class OpenAIClient
	{
		public readonly ChatService Chat;

		public readonly EmbeddingService Embeddings;

		public readonly AudioService Audio;

		internal OpenAIClient(PredictorService predictors, global::Muna.Services.PredictionService predictions, RemotePredictionService remotePredictions)
		{
			Chat = new ChatService(predictors, predictions, remotePredictions);
			Embeddings = new EmbeddingService(predictors, predictions, remotePredictions);
			Audio = new AudioService(predictors, predictions, remotePredictions);
		}
	}
}
