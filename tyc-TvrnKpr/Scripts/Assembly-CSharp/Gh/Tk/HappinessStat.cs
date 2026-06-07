using Gh.Tk.Story.Conversations;
using UnityEngine;

namespace Gh.Tk
{
	public class HappinessStat : StaffStat
	{
		[PersistenceOptIn]
		[PersistenceObjectReference]
		private EnergyStat _energy;

		private HappinessBehaviour _behaviour;

		private GameObject _statusIcon;

		private StaffStatusMeter _statusIconScript;

		private EmotionalState _angryEmotionalState;

		private EmotionalState _happyEmotionalState;

		protected HappinessStat()
		{
		}

		public HappinessStat(Staff owner)
		{
		}

		public override void Init()
		{
		}

		public override void Update()
		{
		}

		private void UpdateValues()
		{
		}

		public override int GetDisplayChevrons(float? changePerSecond = null)
		{
			return 0;
		}

		private void UpdateMeterInfo()
		{
		}

		private void SetSpeedModifier(float modifier, string displayReasonKey = null)
		{
		}

		private void SetSkillModifier(int points, string displayReasonKey = null, string keyOverride = null)
		{
		}
	}
}
