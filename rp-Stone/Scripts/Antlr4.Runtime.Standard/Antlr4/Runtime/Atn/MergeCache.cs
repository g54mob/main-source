using System.Collections.Generic;

namespace Antlr4.Runtime.Atn
{
	public class MergeCache
	{
		private Dictionary<PredictionContext, Dictionary<PredictionContext, PredictionContext>> data = new Dictionary<PredictionContext, Dictionary<PredictionContext, PredictionContext>>();

		public PredictionContext Get(PredictionContext a, PredictionContext b)
		{
			if (!data.TryGetValue(a, out var value))
			{
				return null;
			}
			if (value.TryGetValue(b, out var value2))
			{
				return value2;
			}
			return null;
		}

		public void Put(PredictionContext a, PredictionContext b, PredictionContext value)
		{
			if (!data.TryGetValue(a, out var value2))
			{
				value2 = new Dictionary<PredictionContext, PredictionContext>();
				data[a] = value2;
			}
			value2[b] = value;
		}
	}
}
