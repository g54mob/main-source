using System.Collections.Generic;
using Events.UI.Overlays;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Show Multi-Page ModalDialogue", fileName = "ShowMultiPageModalDialogue", order = 3)]
	public class ShowMultiPageModalDialogueSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private ShowModalDialogEvent _showModalDialogEvent;

		[SerializeField]
		private List<ModelDialogPageContent> _pages = new List<ModelDialogPageContent>();

		public override void Execute()
		{
			ModalDialogContent[] array = new ModalDialogContent[_pages.Count];
			for (int i = 0; i < _pages.Count; i++)
			{
				array[i] = new ModalDialogContent(_pages[i].TitleKey, _pages[i].TextKey, _pages[i].VideoName, _pages[i].Sprite, _pages[i].ExtraTextKey);
			}
			_showModalDialogEvent.Fire(new UIModaldialogData(new ModalDialogDto(array)));
		}
	}
}
