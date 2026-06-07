using System;

namespace Muna.C
{
	public sealed class Predictor : IDisposable
	{
		private readonly IntPtr predictor;

		public Predictor(Configuration configuration)
		{
			Function.CreatePredictor(configuration, out var intPtr).Throw();
			predictor = intPtr;
		}

		public Prediction CreatePrediction(ValueMap inputs)
		{
			predictor.CreatePrediction(inputs, out var prediction).Throw();
			return new Prediction(prediction);
		}

		public PredictionStream StreamPrediction(ValueMap inputs)
		{
			predictor.StreamPrediction(inputs, out var stream).Throw();
			return new PredictionStream(stream);
		}

		public void Dispose()
		{
			predictor.ReleasePredictor();
		}

		public static implicit operator IntPtr(Predictor predictor)
		{
			return predictor.predictor;
		}
	}
}
