using Events;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Hide Narration Dialogue", fileName = "HideNarrationDialogue", order = 4)]
	public class HideNarrationDialogSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private BaseEvent _hideNarrationDialogEvent;

		public override void Execute()
		{
			_hideNarrationDialogEvent.Fire();
		}
	}
}
