using System.Collections.Generic;

namespace Gh.Tk
{
	public class AtmosphereSatisfactionStat : SatisfactionStatBase
	{
		private static Dictionary<string, List<AreaEffectRatingsProfile>> _defaultConfig;

		private WetTrait _wetTrait;

		private DecorSatisfactionStat _decorStat;

		private static readonly Dictionary<string, string> DisplayCategoryKeyCache;

		protected AtmosphereSatisfactionStat()
		{
		}

		public AtmosphereSatisfactionStat(Patron owner)
		{
		}

		public static AreaEffectRatingsProfile GetDefaultProfile(string type, int tier = 1)
		{
			return null;
		}

		private (float, string) RateAtmosphere(string type, float value)
		{
			return default((float, string));
		}

		public override void Update()
		{
		}

		private bool ShouldTrack(string category)
		{
			return false;
		}

		private bool ShouldTrackNoise()
		{
			return false;
		}

		private string GetDisplayCategoryKey(string effect)
		{
			return null;
		}
	}
}
