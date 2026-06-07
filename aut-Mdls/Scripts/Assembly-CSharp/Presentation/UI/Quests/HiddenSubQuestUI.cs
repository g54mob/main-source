using Data.Quests;

namespace Presentation.UI.Quests
{
	public class HiddenSubQuestUI : SubQuestUI
	{
		protected override void Awake()
		{
		}

		public override void Show(SubQuestSO subQuest)
		{
			_subQuest = subQuest;
		}

		public override void MarkAsStarted()
		{
		}

		public override void ShowAsCompleted()
		{
		}

		protected override void SetProgress(float current, float target = 1f)
		{
		}
	}
}
