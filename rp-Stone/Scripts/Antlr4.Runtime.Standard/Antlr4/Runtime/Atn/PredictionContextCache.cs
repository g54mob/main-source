using System.Collections.Generic;
using Antlr4.Runtime.Sharpen;

namespace Antlr4.Runtime.Atn
{
	public class PredictionContextCache
	{
		protected readonly Dictionary<PredictionContext, PredictionContext> cache = new Dictionary<PredictionContext, PredictionContext>();

		public int Count => cache.Count;

		public PredictionContext Add(PredictionContext ctx)
		{
			if (ctx == PredictionContext.EMPTY)
			{
				return PredictionContext.EMPTY;
			}
			PredictionContext predictionContext = cache.Get(ctx);
			if (predictionContext != null)
			{
				return predictionContext;
			}
			cache.Put(ctx, ctx);
			return ctx;
		}

		public PredictionContext Get(PredictionContext ctx)
		{
			return cache.Get(ctx);
		}
	}
}
