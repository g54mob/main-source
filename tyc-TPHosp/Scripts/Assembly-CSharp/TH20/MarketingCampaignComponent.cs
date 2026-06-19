using System;
using System.Linq;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class MarketingCampaignComponent : EntityComponent
	{
		private int _durationInMonths;

		private int _timeRemainingInDays;

		private RoomItem _roomItem;

		private MarketingCampaignDefinition _activeCampaign;

		public Action OnTimeRemainingChanged;

		public MarketingCampaignDefinition ActiveCampaign => _activeCampaign;

		public int DurationInDays => (int)((float)_durationInMonths * 30.42f);

		public int DurationInMonths => _durationInMonths;

		public int TimeRemainingInMonths => (int)((float)_timeRemainingInDays / 30.42f);

		public int TimeRemainingInDays => _timeRemainingInDays;

		public int Cost => _activeCampaign.LaunchCost + _durationInMonths * _activeCampaign.MonthlySpend;

		public RoomItem Item => _roomItem;

		protected override Type ValidEntityType()
		{
			return typeof(RoomItem);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_roomItem = GetOwner<RoomItem>();
			TimelineManager timelineManager = base.Level.TimelineManager;
			timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Combine(timelineManager.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			SetTableItemsVisible(show: false);
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			TimelineManager timelineManager = base.Level.TimelineManager;
			timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Combine(timelineManager.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			if (_activeCampaign != null)
			{
				Level level = base.Level;
				level.PostConstruct = (Action)Delegate.Combine(level.PostConstruct, (Action)delegate
				{
					base.Level.StatusIconManager.ShowStatusIcon(_roomItem, StatusIcon.Type.MarketingCampaign);
				});
			}
		}

		public override void Destroy()
		{
			TimelineManager timelineManager = base.Level.TimelineManager;
			timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Remove(timelineManager.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			EndCampaign(cancelled: true);
			base.Destroy();
		}

		private void OnTimelineUpdated(int day, int month, int year)
		{
			if (_activeCampaign != null && _roomItem.OwningRoom != null && _roomItem.OwningRoom.StaffWorkingInRoom.Count != 0)
			{
				_timeRemainingInDays--;
				if (_timeRemainingInDays == 0)
				{
					EndCampaign(cancelled: false);
				}
				else
				{
					OnTimeRemainingChanged.InvokeSafe();
				}
				if (day == 0)
				{
					base.Level.MarketingManager.OnCampaignUpdated.InvokeSafe(this);
				}
			}
		}

		public void StartCampaign(MarketingCampaignDefinition campaign, int duration)
		{
			ResumeCampaign(campaign, duration, (int)((float)duration * 30.42f));
			base.Level.MarketingManager.OnCampaignStarted.InvokeSafe(this);
		}

		public void ResumeCampaign(MarketingCampaignDefinition campaign, int duration, int timeRemaining)
		{
			SetCampaign(campaign, duration, timeRemaining);
		}

		private void SetCampaign(MarketingCampaignDefinition campaign, int duration, int timeRemaining)
		{
			_durationInMonths = duration;
			_timeRemainingInDays = timeRemaining;
			_activeCampaign = campaign;
			_roomItem.OwningRoom.SetRoomOperational(operational: true);
			SetTableItemsVisible(show: true);
			base.Level.StatusIconManager.ShowStatusIcon(_roomItem, StatusIcon.Type.MarketingCampaign);
		}

		public void EndCampaign(bool cancelled)
		{
			if (_activeCampaign != null)
			{
				if (_roomItem.OwningRoom != null)
				{
					_roomItem.OwningRoom.SetRoomOperational(operational: false);
				}
				base.Level.MarketingManager.OnCampaignEnded.InvokeSafe(this, cancelled);
				if (!cancelled)
				{
					base.Level.ObjectiveEvents.OnGameEvent.InvokeSafe(ObjectiveGameEvent.ResearchProjectCompleted);
				}
				SetTableItemsVisible(show: false);
				_activeCampaign = null;
			}
		}

		public float TotalStaffMarketingSkill()
		{
			return _roomItem.OwningRoom.StaffWorkingInRoom.Sum((Staff staff) => staff.GetMarketingSkill(_roomItem.OwningRoom));
		}

		public float CalculateJobPoolMultiplier()
		{
			if (!(ActiveCampaign is RecruitmentMarketingCampaignDefinition recruitmentMarketingCampaignDefinition))
			{
				return 0f;
			}
			return recruitmentMarketingCampaignDefinition.StaffPoolTimeMultiplier * TotalStaffMarketingSkill();
		}

		public float CalculateIllnessMultiplier(IllnessDefinition illness)
		{
			if (ActiveCampaign is IllnessMarketingCampaignDefinition illnessMarketingCampaignDefinition && illnessMarketingCampaignDefinition.IsValid(illness))
			{
				return illnessMarketingCampaignDefinition.IllnessWeightMultiplier * TotalStaffMarketingSkill();
			}
			return 0f;
		}

		private void SetTableItemsVisible(bool show)
		{
			if (_roomItem.Visual != null && _roomItem.Visual.GameObject != null)
			{
				RoomItemMarketingTableComponent component = _roomItem.Visual.GameObject.GetComponent<RoomItemMarketingTableComponent>();
				if (component != null)
				{
					component.EnableItems(show);
				}
			}
		}
	}
}
