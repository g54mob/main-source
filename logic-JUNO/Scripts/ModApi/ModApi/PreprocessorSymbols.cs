using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ModApi
{
	public static class PreprocessorSymbols
	{
		public enum PreprocessorSymbolBuildBehaviorType
		{
			Default = 0,
			WarningIfDefined = 1,
			ErrorIfDefined = 2
		}

		public static class PERFORMANCE_METRICS_QUAD_GENERATION
		{
			public const PreprocessorSymbolBuildBehaviorType BuildBehavior = PreprocessorSymbolBuildBehaviorType.ErrorIfDefined;

			public const string Id = "PERFORMANCE_METRICS_QUAD_GENERATION";

			public const bool IsDefined = false;
		}

		public class PreprocessorSymbol
		{
			public PreprocessorSymbolBuildBehaviorType BuildBehavior { get; private set; }

			public string Id { get; private set; }

			public bool IsDefined { get; private set; }

			public PreprocessorSymbol(string id, bool isDefined, PreprocessorSymbolBuildBehaviorType buildBehavior)
			{
				Id = id;
				IsDefined = isDefined;
				BuildBehavior = buildBehavior;
			}
		}

		public static readonly ReadOnlyCollection<PreprocessorSymbol> AllSymbols = new ReadOnlyCollection<PreprocessorSymbol>(new List<PreprocessorSymbol>
		{
			new PreprocessorSymbol("PERFORMANCE_METRICS_QUAD_GENERATION", isDefined: false, PreprocessorSymbolBuildBehaviorType.ErrorIfDefined)
		});
	}
}
