using Data.Variables;
using Events.UI.Overlays;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using UnityEngine;
using Utils.Enums;

namespace Data.TechTree.Behaviours
{
	[CreateAssetMenu(menuName = "Tech Tree/Behaviors/Show Modal", fileName = "ShowModal")]
	public class ShowModalTechTreeNodeBehaviour : AbstractTechTreeNodeBehaviour
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

		[Space]
		[SerializeField]
		private Sprite _sprite1;

		[Space]
		[SerializeField]
		private string _videoName;

		public override void Unlock()
		{
			_showModalDialogEvent.Fire(new UIModaldialogData(new ModalDialogDto(new ModalDialogContent(_titleKey, _textKey, _videoName, _sprite1, _extraTextKey), _modalDialogueSize)));
		}

		public override void RefunableReUnlock()
		{
		}

		public override bool TryGetRefunableVariable(out VariableSO variable)
		{
			variable = null;
			return false;
		}
	}
}
