using System;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.UnityConsent;

public class AnalyticsManager : MonoBehaviour
{
	private enum BuildableAction
	{
		Built = 0,
		Salvaged = 1,
		Researched = 2
	}

	private enum AgentType
	{
		Drifter = 0,
		Bird = 1
	}

	private class DayMarkedEvent : Unity.Services.Analytics.Event
	{
		public DayMarkedEvent(string eventName)
			: base(eventName)
		{
			Initialize();
		}

		public void Initialize()
		{
			SetParameter("day", GameManager.TimeManager.Days.Count);
		}
	}

	private class SessionEvent : Unity.Services.Analytics.Event
	{
		public SessionEvent()
			: base("SessionInfo")
		{
			GameVersion version = GameManager.Settings.Version;
			SetParameter("majorVersion", version.Major);
			SetParameter("minorVersion", version.Minor);
			SetParameter("patchVersion", version.Patch);
			SetParameter("additionalVersionModifiers", version.AdditionalModifiers);
			SetParameter("saveVersion", version.Save);
			SetParameter("tileProperties", (WorldManager.TileProperties != null) ? WorldManager.TileProperties.name : "Unknown");
		}
	}

	private class PerformanceEvent : Unity.Services.Analytics.Event
	{
		public PerformanceEvent()
			: base("Performance")
		{
		}

		public void SetFPS(float fps)
		{
			SetParameter("fps", fps);
		}
	}

	private class BuildableActionEvent : DayMarkedEvent
	{
		public BuildableActionEvent()
			: base("BuildableAction")
		{
		}

		public void Initialize(string buildableName, BuildableAction action)
		{
			Initialize();
			SetParameter("buildableName", buildableName);
			SetParameter("buildableAction", action.ToString());
		}
	}

	private class MarkerPlacementEvent : DayMarkedEvent
	{
		public MarkerPlacementEvent()
			: base("MarkerPlacement")
		{
		}

		public void Initialize(string resourceName)
		{
			Initialize();
			SetParameter("resourceName", resourceName);
		}
	}

	private class AgentRescuedEvent : DayMarkedEvent
	{
		public AgentRescuedEvent()
			: base("AgentRescued")
		{
		}

		public void Initialize(AgentType agentType)
		{
			Initialize();
			SetParameter("agentType", agentType.ToString());
		}
	}

	private class AgentDiedEvent : DayMarkedEvent
	{
		public AgentDiedEvent()
			: base("AgentDied")
		{
		}
	}

	private class DrifterleveledEvent : DayMarkedEvent
	{
		public DrifterleveledEvent()
			: base("DrifterLeveled")
		{
		}

		public void Initialize(int drifterLevel)
		{
			Initialize();
			SetParameter("level", drifterLevel);
		}
	}

	private bool _initialized;

	private bool _readyToSendEvents;

	private float _averageFPS;

	private int _performanceFrameQuantity;

	private float _currentPooledAnalyticsTime;

	private float _pooledAnalyticsMaximumTime;

	private readonly PerformanceEvent _performanceEvent = new PerformanceEvent();

	private readonly Queue<Unity.Services.Analytics.Event> _queuedEvents = new Queue<Unity.Services.Analytics.Event>();

	private readonly Dictionary<Type, Queue<Unity.Services.Analytics.Event>> _eventsPools = new Dictionary<Type, Queue<Unity.Services.Analytics.Event>>();

	public void Initialize()
	{
		GameEventDispatcher.AddListener(GameEventType.GameStart, SendSessionEvent);
		GameEventDispatcher.AddListener(GameEventType.BuildableBuilt, TrackBuildableBuilt);
		GameEventDispatcher.AddListener(GameEventType.BuildableSalvaged, TrackBuildableSalvage);
		GameEventDispatcher.AddListener(GameEventType.ResearchFinished, TrackBuildableResearched);
		GameEventDispatcher.AddListener(GameEventType.MarkerPlaced, TrackMarkerPlaced);
		GameEventDispatcher.AddListener(GameEventType.AgentRescue, TrackDrifterRescued);
		GameEventDispatcher.AddListener(GameEventType.BirdRescue, TrackBirdRescued);
		GameEventDispatcher.AddListener(GameEventType.AgentDeath, TrackDrifterDied);
		GameEventDispatcher.AddListener(GameEventType.AgentLevelGained, TrackDrifterLeveled);
		if (!_initialized)
		{
			_pooledAnalyticsMaximumTime = GameManager.Settings.DataSettings.PooledAnalyticsCallIntervalTime;
			_initialized = true;
		}
	}

	private async void InitializeDataCollection()
	{
		_readyToSendEvents = false;
		await UnityServices.InitializeAsync();
		ConsentState consentState = new ConsentState();
		consentState.AnalyticsIntent = ConsentStatus.Granted;
		EndUserConsent.SetConsentState(consentState);
		_readyToSendEvents = true;
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.GameStart, SendSessionEvent);
		GameEventDispatcher.RemoveListener(GameEventType.BuildableBuilt, TrackBuildableBuilt);
		GameEventDispatcher.RemoveListener(GameEventType.BuildableSalvaged, TrackBuildableSalvage);
		GameEventDispatcher.RemoveListener(GameEventType.ResearchFinished, TrackBuildableResearched);
		GameEventDispatcher.RemoveListener(GameEventType.MarkerPlaced, TrackMarkerPlaced);
		GameEventDispatcher.RemoveListener(GameEventType.AgentRescue, TrackDrifterRescued);
		GameEventDispatcher.RemoveListener(GameEventType.BirdRescue, TrackBirdRescued);
		GameEventDispatcher.RemoveListener(GameEventType.AgentDeath, TrackDrifterDied);
		GameEventDispatcher.RemoveListener(GameEventType.AgentAttributeLeveled, TrackDrifterLeveled);
		if (_readyToSendEvents)
		{
			SendEvents();
		}
		_initialized = false;
		_readyToSendEvents = false;
	}

	private void Update()
	{
		if (_readyToSendEvents)
		{
			_currentPooledAnalyticsTime += Time.unscaledDeltaTime;
			_performanceFrameQuantity++;
			float num = 1f / Time.unscaledDeltaTime;
			_averageFPS += (num - _averageFPS) / (float)_performanceFrameQuantity;
			if (_currentPooledAnalyticsTime > _pooledAnalyticsMaximumTime)
			{
				SendEvents();
				_currentPooledAnalyticsTime = 0f;
				_averageFPS = 0f;
				_performanceFrameQuantity = 0;
			}
		}
	}

	private EventType GetEvent<EventType>() where EventType : Unity.Services.Analytics.Event, new()
	{
		if (!_eventsPools.TryGetValue(typeof(EventType), out var value) || value.Count <= 0)
		{
			return new EventType();
		}
		return value.Dequeue() as EventType;
	}

	private void SendEvents()
	{
		if (UnityServices.State == ServicesInitializationState.Initialized)
		{
			SendPerformanceEvents();
			while (_queuedEvents.Count > 0)
			{
				Unity.Services.Analytics.Event obj = _queuedEvents.Dequeue();
				AnalyticsService.Instance.RecordEvent(obj);
				_eventsPools.GetOrCreate(obj.GetType()).Enqueue(obj);
			}
		}
	}

	public void SendSessionEvent(GameEvent gameEvent)
	{
		if (!GameManager.Instance.IntroScene)
		{
			_queuedEvents.Enqueue(new SessionEvent());
		}
	}

	private void SendPerformanceEvents()
	{
		_performanceEvent.SetFPS(_averageFPS);
		_queuedEvents.Enqueue(_performanceEvent);
	}

	private void TrackBuildableBuilt(GameEvent gameEvent)
	{
		if (gameEvent is BuildableEvent buildableEvent)
		{
			BuildableActionEvent buildableActionEvent = GetEvent<BuildableActionEvent>();
			buildableActionEvent.Initialize(buildableEvent.BuildableProperties.name, BuildableAction.Built);
			_queuedEvents.Enqueue(buildableActionEvent);
		}
	}

	private void TrackBuildableSalvage(GameEvent gameEvent)
	{
		if (gameEvent is BuildableEvent buildableEvent)
		{
			BuildableActionEvent buildableActionEvent = GetEvent<BuildableActionEvent>();
			buildableActionEvent.Initialize(buildableEvent.BuildableProperties.name, BuildableAction.Salvaged);
			_queuedEvents.Enqueue(buildableActionEvent);
		}
	}

	private void TrackBuildableResearched(GameEvent gameEvent)
	{
		if (!(gameEvent is ResearchEvent { EventType: GameEventType.ResearchFinished } researchEvent))
		{
			return;
		}
		foreach (ResearchUnlockable unlockable in researchEvent.Research.TechTreeNode.Unlockables)
		{
			if (unlockable is BuildableProperties buildableProperties)
			{
				BuildableActionEvent buildableActionEvent = GetEvent<BuildableActionEvent>();
				buildableActionEvent.Initialize(buildableProperties.name, BuildableAction.Researched);
				_queuedEvents.Enqueue(buildableActionEvent);
			}
		}
	}

	private void TrackMarkerPlaced(GameEvent gameEvent)
	{
		if (gameEvent is MarkerEvent markerEvent)
		{
			MarkerPlacementEvent markerPlacementEvent = GetEvent<MarkerPlacementEvent>();
			markerPlacementEvent.Initialize(markerEvent.Marker.MarkerCursorProperties.name);
			_queuedEvents.Enqueue(markerPlacementEvent);
		}
	}

	private void TrackDrifterRescued(GameEvent gameEvent)
	{
		AgentRescuedEvent agentRescuedEvent = GetEvent<AgentRescuedEvent>();
		agentRescuedEvent.Initialize(AgentType.Drifter);
		_queuedEvents.Enqueue(agentRescuedEvent);
	}

	private void TrackBirdRescued(GameEvent gameEvent)
	{
		AgentRescuedEvent agentRescuedEvent = GetEvent<AgentRescuedEvent>();
		agentRescuedEvent.Initialize(AgentType.Bird);
		_queuedEvents.Enqueue(agentRescuedEvent);
	}

	private void TrackDrifterDied(GameEvent gameEvent)
	{
		AgentDiedEvent agentDiedEvent = GetEvent<AgentDiedEvent>();
		agentDiedEvent.Initialize();
		_queuedEvents.Enqueue(agentDiedEvent);
	}

	private void TrackDrifterLeveled(GameEvent gameEvent)
	{
		DrifterleveledEvent drifterleveledEvent = GetEvent<DrifterleveledEvent>();
		drifterleveledEvent.Initialize(0);
		_queuedEvents.Enqueue(drifterleveledEvent);
	}
}
