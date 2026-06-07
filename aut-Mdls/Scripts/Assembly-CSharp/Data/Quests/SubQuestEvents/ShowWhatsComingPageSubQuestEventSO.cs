using Data.FeatureFlags.Validators;
using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Show WhatsComing Page", fileName = "ShowWhatsComingPage", order = 10)]
	public class ShowWhatsComingPageSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private FeatureFlagValidator _demoFeaturesValidator;

		[SerializeField]
		private ShowUIMenuEvent _showUIMenuEvent;

		[SerializeField]
		private UIMenuLocator _whatsComingMenuLocator;

		public override void Execute()
		{
			_showUIMenuEvent.Fire(new WhatsComingUIMenuData(_whatsComingMenuLocator.UIMenu, proceedToExit: false));
		}
	}
}
