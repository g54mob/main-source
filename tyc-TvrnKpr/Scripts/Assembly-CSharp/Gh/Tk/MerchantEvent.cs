namespace Gh.Tk
{
	public class MerchantEvent : GameEvent
	{
		public string MerchantTemplateId;

		public bool AutoRepeat { get; set; }

		public int SpawnFrequencyOverride { get; set; }

		public override bool ShowOnTimeline => false;

		public MerchantEvent()
		{
		}

		public MerchantEvent(string merchantTemplateId, float spawnFrequencyOverride = -1f, bool autoRepeat = true)
		{
		}

		private bool WillVisitAtDayF(float dayFToVisit)
		{
			return false;
		}

		private bool ShouldMerchantSpawn()
		{
			return false;
		}

		public override void Trigger()
		{
		}

		public static Merchant SpawnMerchant(string templateId)
		{
			return null;
		}
	}
}
