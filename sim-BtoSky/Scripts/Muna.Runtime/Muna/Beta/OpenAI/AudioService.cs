using Muna.Beta.Services;
using Muna.Services;

namespace Muna.Beta.OpenAI
{
	public sealed class AudioService
	{
		public readonly SpeechService Speech;

		public readonly TranscriptionService Transcriptions;

		internal AudioService(PredictorService predictors, global::Muna.Services.PredictionService predictions, RemotePredictionService remotePredictions)
		{
			Speech = new SpeechService(predictors, predictions, remotePredictions);
			Transcriptions = new TranscriptionService(predictors, predictions, remotePredictions);
		}
	}
}
