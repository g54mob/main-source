using System;

namespace Muna.C
{
	public sealed class PredictionStream : IDisposable
	{
		private readonly IntPtr stream;

		public Prediction? ReadNext()
		{
			if (stream.ReadNextPrediction(out var prediction) == Function.Status.Ok)
			{
				return new Prediction(prediction);
			}
			return null;
		}

		public void Dispose()
		{
			stream.ReleasePredictionStream();
		}

		internal PredictionStream(IntPtr stream)
		{
			this.stream = stream;
		}

		public static implicit operator IntPtr(PredictionStream stream)
		{
			return stream.stream;
		}
	}
}
