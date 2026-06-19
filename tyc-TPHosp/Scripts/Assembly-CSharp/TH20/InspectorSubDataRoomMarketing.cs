using I2.Loc;

namespace TH20
{
	public class InspectorSubDataRoomMarketing : InspectorSubDataRoom
	{
		private MarketingCampaignComponent _campaignComponent;

		public InspectorSubDataRoomMarketing(Room room)
			: base(room)
		{
			RoomAlgorithms.IterateRoomItemsWithComponent(_room, delegate(MarketingCampaignComponent component)
			{
				_campaignComponent = component;
			});
		}

		public override string GetText()
		{
			if (_campaignComponent == null)
			{
				return string.Empty;
			}
			if (_campaignComponent.ActiveCampaign != null)
			{
				return ScriptLocalization.Inspector_Room_Marketing.CancelCampaign_CS;
			}
			return ScriptLocalization.Inspector_Room_Marketing.Marketing_CS;
		}

		public override string GetTooltip()
		{
			if (_campaignComponent == null)
			{
				return string.Empty;
			}
			if (_campaignComponent.ActiveCampaign != null)
			{
				return ScriptLocalization.Inspector_Room_Marketing.CancelCampaign_CS;
			}
			return ScriptLocalization.Inspector_Room_Marketing.StartCampaign_CS;
		}

		public override bool OnButtonPressed()
		{
			if (_campaignComponent == null)
			{
				return false;
			}
			if (_campaignComponent.ActiveCampaign != null)
			{
				_campaignComponent.EndCampaign(cancelled: true);
				return false;
			}
			base.Level.HospitalHUDManager.TryOpenMenu(delegate
			{
				base.Level.HUD.CreateMenu<MarketingCampaignMenu>().Setup(_campaignComponent, base.Level);
			});
			return true;
		}

		public override bool ShouldShowButton()
		{
			if (_campaignComponent != null)
			{
				return _room.HasValidRequiredItems();
			}
			return false;
		}
	}
}
