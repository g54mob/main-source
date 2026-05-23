using Presentation.Locators;
using Presentation.UI.Menus;
using Presentation.UI.Menus.FullscreenPage;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Await Open Full Screen Page", fileName = "AwaitOpenFullScreenPage", order = 11)]
	public class AwaitOpenFullScreenPageSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private UIMenuManagerLocator _uiMenuManagerLocator;

		[SerializeField]
		private UIMenuLocator _fullScreenPageUIMenuLocator;

		[SerializeField]
		private FullPagesEnum _openedPage;

		[SerializeField]
		private bool _shouldBeOpen;

		public override bool IsValid()
		{
			if (_shouldBeOpen == _uiMenuManagerLocator.UIMenuManager.IsCurrentlyShowing(_fullScreenPageUIMenuLocator.UIMenu))
			{
				return ((FullscreenPageUI)_fullScreenPageUIMenuLocator.UIMenu).CurrentPage == _openedPage;
			}
			return false;
		}

		public override void Reset()
		{
		}
	}
}
