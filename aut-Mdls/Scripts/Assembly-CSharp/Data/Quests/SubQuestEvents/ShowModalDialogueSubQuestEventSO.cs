using Events.UI.Overlays;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using UnityEngine;
using Utils.Enums;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Show ModalDialogue", fileName = "ShowModalDialogue", order = 3)]
	public class ShowModalDialogueSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private ShowModalDialogEvent _showModalDialogEvent;

		[SerializeField]
		private Sizes _modalDialogueSize = Sizes.M;

		[SerializeField]
		private string _titleKey = "ModalOnboarding1.Title";

		[SerializeField]
		private string _textKey = "ModalOnboarding1.Text";

		[SerializeField]
		private string _extraTextKey = "";

		[SerializeField]
		private bool _allowPageSkip;

		[Space]
		[SerializeField]
		private Sprite _sprite1;

		[Space]
		[SerializeField]
		private string _videoName;

		public override void Execute()
		{
			_showModalDialogEvent.Fire(new UIModaldialogData(new ModalDialogDto(new ModalDialogContent(_titleKey, _textKey, _videoName, _sprite1, _extraTextKey), _modalDialogueSize, null, showCancelButton: false, null, _allowPageSkip)));
		}
	}
}
