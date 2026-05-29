using CTS.BBT;
using CTS.Core;
using PixelCrushers.DialogueSystem;

namespace CTS
{
	public class DaysWithoutRoomTypeSecondaryQuest : BaseRoomTypeSecondaryQuest<DaysWithoutRoomTypeGoal>
	{
		public override void OfferQuest()
		{
			int num = MonoSingleton<TimeController>.Instance.DaysMinutesConvertion(5f);
			TargetValue.x = num;
			TargetValue.y = num;
			base.OfferQuest();
		}

		protected override void StopObservingObjectives()
		{
			base.StopObservingObjectives();
			SecondaryQuestsManager.FailCountdownUpdated -= OnFailCountdownUpdated;
		}

		protected override void StartObservingObjectives()
		{
			base.StartObservingObjectives();
			SecondaryQuestsManager.FailCountdownUpdated += OnFailCountdownUpdated;
		}

		private void OnFailCountdownUpdated(Quest quest, float current, float total)
		{
			if (current < MonoSingleton<TimeController>.Instance._dayDurationInSeconds * (float)DialogueLua.GetVariable(Target).asInt)
			{
				FailQuest();
			}
		}
	}
}
