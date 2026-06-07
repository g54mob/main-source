using Data.Variables;
using NaughtyAttributes;
using Presentation.Locators;
using Presentation.UI.Menus;
using Presentation.UI.Menus.FullscreenPage;
using Presentation.UI.Menus.MenuEvents;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Reveal Tech Tree Area", fileName = "RevealTechTreeArea", order = 23)]
	public class RevealTechTreeAreaSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private ShowUIMenuEvent _showUIMenuEvent;

		[SerializeField]
		private UIMenuLocator _fullscreenPageMenuLocator;

		[SerializeField]
		private FullPagesEnum _pageToOpen;

		[SerializeField]
		private TechTreeManagerLocator _techTreeManagerLocator;

		[SerializeField]
		private Vector2 _techTreePanPosition;

		[SerializeField]
		private Vector2 _techTreePanStartPosition;

		[SerializeField]
		private float _panningTime;

		[SerializeField]
		private BoolVariableSO _techTreeShowBool;

		[SerializeField]
		private UIMenuManagerLocator _uiMenuManagerLocator;

		[SerializeField]
		private UIMenuLocator _fullScreenPageUIMenuLocator;

		[Button("Execute", EButtonEnableMode.Always)]
		public override void Execute()
		{
			if (!_techTreeShowBool.Value)
			{
				if (!_uiMenuManagerLocator.UIMenuManager.IsCurrentlyShowing(_fullScreenPageUIMenuLocator.UIMenu) || ((FullscreenPageUI)_fullScreenPageUIMenuLocator.UIMenu).CurrentPage != FullPagesEnum.TechTree)
				{
					_showUIMenuEvent.Fire(new FullscreenPageUIMenuData(_fullscreenPageMenuLocator.UIMenu, _pageToOpen));
				}
				_techTreeManagerLocator.TechTreeManager.TechTreeView.Reveal(_techTreePanStartPosition, _techTreePanPosition, _panningTime, _techTreeShowBool);
			}
		}

		[Button("Debug Force Execute", EButtonEnableMode.Always)]
		private void ForceExecute()
		{
			if (!_uiMenuManagerLocator.UIMenuManager.IsCurrentlyShowing(_fullScreenPageUIMenuLocator.UIMenu) || ((FullscreenPageUI)_fullScreenPageUIMenuLocator.UIMenu).CurrentPage != FullPagesEnum.TechTree)
			{
				_showUIMenuEvent.Fire(new FullscreenPageUIMenuData(_fullscreenPageMenuLocator.UIMenu, _pageToOpen));
			}
			_techTreeManagerLocator.TechTreeManager.TechTreeView.Reveal(_techTreePanStartPosition, _techTreePanPosition, _panningTime, _techTreeShowBool);
		}
	}
}
