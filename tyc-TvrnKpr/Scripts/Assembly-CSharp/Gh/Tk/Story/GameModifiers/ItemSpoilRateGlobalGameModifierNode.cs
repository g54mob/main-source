using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.GameModifiers
{
	[InitializeOnGameStarted]
	public class ItemSpoilRateGlobalGameModifierNode : TemporaryGameModifierNode
	{
		[Range(-100f, 200f)]
		public int spoilRateAdjustmentPercentage;

		private static int? _spoilRateModifierPercentage;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void InvalidateSpoilRateModifier()
		{
		}

		public static int GetSpoilRateModifierPercentage()
		{
			return 0;
		}
	}
}
