using System;
using System.Text;

namespace Muna.C
{
	public sealed class Prediction : IDisposable
	{
		private readonly IntPtr prediction;

		public string id
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder(64);
				prediction.GetPredictionID(stringBuilder, stringBuilder.Capacity).Throw();
				return stringBuilder.ToString();
			}
		}

		public double latency
		{
			get
			{
				prediction.GetPredictionLatency(out var result).Throw();
				return result;
			}
		}

		public ValueMap? results
		{
			get
			{
				IntPtr map;
				ValueMap valueMap = ((prediction.GetPredictionResults(out map).Throw() == Function.Status.Ok) ? new ValueMap(map) : null);
				if (valueMap == null || valueMap.size <= 0)
				{
					return null;
				}
				return valueMap;
			}
		}

		public string? error
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder(2048);
				if (prediction.GetPredictionError(stringBuilder, stringBuilder.Capacity) != Function.Status.Ok)
				{
					return null;
				}
				return stringBuilder.ToString();
			}
		}

		public string logs
		{
			get
			{
				prediction.GetPredictionLogLength(out var size).Throw();
				StringBuilder stringBuilder = new StringBuilder(size + 1);
				prediction.GetPredictionLogs(stringBuilder, stringBuilder.Capacity);
				return stringBuilder.ToString();
			}
		}

		public void Dispose()
		{
			prediction.ReleasePrediction();
		}

		internal Prediction(IntPtr prediction)
		{
			this.prediction = prediction;
		}

		public static implicit operator IntPtr(Prediction prediction)
		{
			return prediction.prediction;
		}
	}
}
