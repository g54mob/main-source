using Events.UI.Overlays;
using Presentation.Locators;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Show EndDemo ModalDialogue", fileName = "ShowEndDemoModalDialogueSubQuestEventSO", order = 3)]
	public class ShowEndDemoModalDialogueSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private ShowModalDialogEvent _showModalDialogEvent;

		[SerializeField]
		private UIEndDemoModalLocator _locator;

		public override void Execute()
		{
			_showModalDialogEvent.Fire(new UIEmptyModalDialogData(_locator.Value));
		}
	}
}
