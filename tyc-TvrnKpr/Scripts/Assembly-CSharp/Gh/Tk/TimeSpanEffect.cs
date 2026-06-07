using System.Collections.Generic;

namespace Gh.Tk
{
	public class TimeSpanEffect : GameEvent
	{
		public static class Effects
		{
			public const string MerchantSkip = "merchantSkip";

			public const string FireBrigadeDisabled = "fireBrigadeDisabled";

			public static string[] AllEffects;

			public static string[] GetAllEffects()
			{
				return null;
			}
		}

		public string Effect { get; private set; }

		public static IEnumerable<TimeSpanEffect> GetAllEffectsOfType(string effect)
		{
			return null;
		}

		protected TimeSpanEffect()
		{
		}

		public TimeSpanEffect(string effect, float startInDayF, float durationInDays)
		{
		}

		protected virtual void RegisterAlertBadge()
		{
		}

		protected virtual void UnregisterAlertBadge()
		{
		}

		public override void Trigger()
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
