using Presentation.Locators;
using Presentation.UI.Menus;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Check Menu Open", fileName = "CheckMenuOpen", order = 11)]
	public class CheckMenuOpenSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private UIMenuManagerLocator _uiMenuManagerLocator;

		[SerializeField]
		private UIMenuLocator _uiMenuLocator;

		[SerializeField]
		private bool _shouldBeOpen = true;

		public override bool IsValid()
		{
			return _shouldBeOpen == _uiMenuManagerLocator.UIMenuManager.IsCurrentlyShowing(_uiMenuLocator.UIMenu);
		}

		public override void Reset()
		{
		}
	}
}
