using System;
using System.Linq;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomLogicMarketing : RoomLogic
	{
		private class SavedData
		{
			public MarketingCampaignDefinition Campaign;

			public int Duration;

			public int TimeRemaining;
		}

		private SavedData _savedData;

		private MarketingCampaignComponent _campaignComponent;

		public MarketingCampaignComponent CampaignComponent => _campaignComponent;

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			RegisterEvents();
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			RegisterEvents();
		}

		public override void Destroy()
		{
			UnregisterEvents();
			base.Destroy();
		}

		private void RegisterEvents()
		{
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomOpened = (Action<Room>)Delegate.Combine(buildEvents.OnRoomOpened, new Action<Room>(OnRoomOpened));
			BuildEvents buildEvents2 = base.Level.BuildEvents;
			buildEvents2.OnRoomClosed = (Action<Room>)Delegate.Combine(buildEvents2.OnRoomClosed, new Action<Room>(OnRoomClosed));
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnStaffDrop = (Action<Staff, Room, bool>)Delegate.Combine(characterEvents.OnStaffDrop, new Action<Staff, Room, bool>(OnStaffDrop));
			MarketingManager marketingManager = base.Level.MarketingManager;
			marketingManager.OnCampaignStarted = (Action<MarketingCampaignComponent>)Delegate.Combine(marketingManager.OnCampaignStarted, new Action<MarketingCampaignComponent>(OnCampaignStarted));
			MarketingManager marketingManager2 = base.Level.MarketingManager;
			marketingManager2.OnCampaignEnded = (Action<MarketingCampaignComponent, bool>)Delegate.Combine(marketingManager2.OnCampaignEnded, new Action<MarketingCampaignComponent, bool>(OnCampaignEnded));
		}

		private void UnregisterEvents()
		{
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomOpened = (Action<Room>)Delegate.Remove(buildEvents.OnRoomOpened, new Action<Room>(OnRoomOpened));
			BuildEvents buildEvents2 = base.Level.BuildEvents;
			buildEvents2.OnRoomClosed = (Action<Room>)Delegate.Remove(buildEvents2.OnRoomClosed, new Action<Room>(OnRoomClosed));
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnStaffDrop = (Action<Staff, Room, bool>)Delegate.Remove(characterEvents.OnStaffDrop, new Action<Staff, Room, bool>(OnStaffDrop));
			MarketingManager marketingManager = base.Level.MarketingManager;
			marketingManager.OnCampaignStarted = (Action<MarketingCampaignComponent>)Delegate.Remove(marketingManager.OnCampaignStarted, new Action<MarketingCampaignComponent>(OnCampaignStarted));
			MarketingManager marketingManager2 = base.Level.MarketingManager;
			marketingManager2.OnCampaignEnded = (Action<MarketingCampaignComponent, bool>)Delegate.Remove(marketingManager2.OnCampaignEnded, new Action<MarketingCampaignComponent, bool>(OnCampaignEnded));
		}

		public override Job CreateJob(StaffRequired staffRequired)
		{
			return new JobMarketing(staffRequired, _room);
		}

		private void OnRoomOpened(Room room)
		{
			if (_room == room && _savedData != null)
			{
				_campaignComponent = FindMarketingTable();
				if (_campaignComponent != null)
				{
					_campaignComponent.ResumeCampaign(_savedData.Campaign, _savedData.Duration, _savedData.TimeRemaining);
				}
				_savedData = null;
			}
		}

		private void OnRoomClosed(Room room)
		{
			if (_room == room && _savedData == null && _campaignComponent != null && _campaignComponent.ActiveCampaign != null)
			{
				_savedData = new SavedData
				{
					Campaign = _campaignComponent.ActiveCampaign,
					Duration = _campaignComponent.DurationInMonths,
					TimeRemaining = _campaignComponent.TimeRemainingInDays
				};
			}
		}

		private MarketingCampaignComponent FindMarketingTable()
		{
			foreach (RoomItem item in _room.FloorPlan.Items)
			{
				MarketingCampaignComponent component = item.GetComponent<MarketingCampaignComponent>();
				if (component != null)
				{
					return component;
				}
			}
			return null;
		}

		private void OnStaffDrop(Staff staff, Room room, bool jobSearch)
		{
			if (_room == room && room.IsOpen && _room.CanAddStaff(staff) && _room.EnterRoom(staff, ReasonUseRoom.Work) && !IsProjectAssigned())
			{
				MarketingCampaignComponent marketingCampaignComponent = FindMarketingTable();
				if (marketingCampaignComponent != null && marketingCampaignComponent.ActiveCampaign == null)
				{
					base.Level.HUD.CreateMenu<MarketingCampaignMenu>().Setup(marketingCampaignComponent, base.Level);
				}
			}
		}

		public override string GetStaffDropResult(Staff staff)
		{
			if (_room.IsOpen && !IsProjectAssigned() && _room.CanAddStaff(staff))
			{
				return ScriptLocalization.Staff.DropResult_StartMarketingProject_CS;
			}
			return null;
		}

		public override bool IsProjectAssigned()
		{
			return _campaignComponent != null;
		}

		public override void Tick()
		{
			if (_campaignComponent != null)
			{
				float num = _room.StaffWorkingInRoom.Sum((Staff staff) => staff.GetMarketingSkill(_room));
				_campaignComponent.ActiveCampaign.Apply(num * Time.deltaTime, base.Level.MarketingManager);
			}
		}

		private void OnCampaignStarted(MarketingCampaignComponent component)
		{
			if (component.GetOwner<RoomItem>().OwningRoom == _room)
			{
				_campaignComponent = component;
			}
		}

		private void OnCampaignEnded(MarketingCampaignComponent component, bool cancelled)
		{
			if (component == _campaignComponent)
			{
				_campaignComponent = null;
			}
		}
	}
}
