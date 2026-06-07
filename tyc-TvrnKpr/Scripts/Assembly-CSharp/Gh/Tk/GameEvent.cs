using LitJson;

namespace Gh.Tk
{
	public abstract class GameEvent : IPersistable, ILateRestoreState
	{
		private Rng _rng;

		private bool _showOnTimeline;

		[JsonIgnore]
		private TooltipData _gameEventTooltip;

		[JsonIgnore]
		private TooltipData _nestedTooltipForSummary;

		[JsonIgnore]
		private TooltipData _nestedDurationTooltip;

		[JsonIgnore]
		private TooltipData _alertBadgeTooltip;

		private string _routeStopA;

		private string _routeStopB;

		private bool _isDragonRoute;

		[JsonIgnore]
		private Route _route;

		[JsonIgnore]
		private RouteMarker _routeMarker;

		public int Id { get; protected set; }

		public int Seed { get; protected set; }

		[JsonIgnore]
		protected IRng EventRng => null;

		public bool HasTriggered { get; set; }

		public float TimeCreated { get; set; }

		public float StartsAt { get; set; }

		public float EndsAt { get; set; }

		[JsonIgnore]
		public bool ShowTimeRange => false;

		[JsonIgnore]
		public bool IsIndefinite => false;

		[JsonIgnore]
		public bool IsActive => false;

		public virtual bool ShowOnTimeline
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool RequiresTimeClarity { get; set; }

		[JsonIgnore]
		public bool IsKnownToPlayer => false;

		public virtual string TimelineTitleKey { get; set; }

		public string TimelineTooltipTextBlockKey { get; set; }

		public string TimelineIcon { get; set; }

		[JsonIgnore]
		public bool IsDestroyed { get; private set; }

		public GameEvent()
		{
		}

		public GameEvent(float dueInSeconds)
		{
		}

		public abstract void Trigger();

		public void SetDueInDaysF(float days)
		{
		}

		protected void SetEndsInDaysF(float days)
		{
		}

		public float GetDueInDaysF()
		{
			return 0f;
		}

		public float GetEndsInDaysF()
		{
			return 0f;
		}

		public float GetDurationInDaysF()
		{
			return 0f;
		}

		public float GetTriggerDayF()
		{
			return 0f;
		}

		public float GetPercentageProgressTillTrigger()
		{
			return 0f;
		}

		public string GetEventSummaryForUI()
		{
			return null;
		}

		protected virtual void OnDestroy()
		{
		}

		public virtual void OnUpdate()
		{
		}

		public void Destroy()
		{
		}

		public virtual void LateRestoreState(IDataStore data)
		{
		}

		protected virtual string GetHeaderWithLinkedTextblockKey()
		{
			return null;
		}

		protected string GetHeaderWithLinkedTextblockKey(string headerKey, string contentKey)
		{
			return null;
		}

		public TooltipData GetTooltip()
		{
			return null;
		}

		public TooltipData GetTooltip(bool withNestedHeaderInfo)
		{
			return null;
		}

		public TooltipData GetAlertBadgeTooltip()
		{
			return null;
		}

		private bool IsRouteSet()
		{
			return false;
		}

		private Route GetRoute()
		{
			return null;
		}

		public void ApplyRoute(Route route)
		{
		}

		public void UpdateRouteMarker()
		{
		}
	}
}
