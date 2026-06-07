using System;
using Doozy.Engine.Nody.Attributes;
using Doozy.Engine.Nody.Models;
using Doozy.Engine.SceneManagement;
using UnityEngine.SceneManagement;

namespace Doozy.Engine.UI.Nodes
{
	[NodeMenu("System/Wait", 50, false, false)]
	public class WaitNode : Node
	{
		public enum WaitType
		{
			Time = 0,
			GameEvent = 1,
			SceneLoad = 2,
			SceneUnload = 3,
			ActiveSceneChange = 4,
			UIView = 5,
			UIButton = 6,
			UIDrawer = 7
		}

		private const WaitType DEFAULT_WAIT_TYPE = WaitType.Time;

		private const bool DEFAULT_ANY_VALUE = false;

		private const bool DEFAULT_IGNORE_UNITY_TIMESCALE = true;

		private const bool DEFAULT_RANDOM_DURATION = false;

		private const float DEFAULT_DURATION = 1f;

		private const float DEFAULT_DURATION_MAX = 1f;

		private const float DEFAULT_DURATION_MIN = 0f;

		private const string DEFAULT_GAME_EVENT = "";

		public GetSceneBy GetSceneBy;

		public WaitType WaitFor;

		public bool AnyValue;

		public bool IgnoreUnityTimescale;

		public bool RandomDuration;

		public float Duration;

		public float DurationMax;

		public float DurationMin;

		public int SceneBuildIndex;

		public string GameEvent;

		public string SceneName;

		public UIViewBehaviorType UIViewTriggerAction;

		public string ViewCategory;

		public string ViewName;

		public UIButtonBehaviorType UIButtonTriggerAction;

		public string ButtonCategory;

		public string ButtonName;

		public UIDrawerBehaviorType UIDrawerTriggerAction;

		public string DrawerName;

		public bool CustomDrawerName;

		[NonSerialized]
		public float CurrentDuration;

		[NonSerialized]
		private bool m_timerIsActive;

		[NonSerialized]
		private double m_timerStart;

		[NonSerialized]
		private float m_timeDelay;

		public float TimerProgress => 0f;

		public string WaitForInfoTitle => null;

		public string WaitForInfoDescription => null;

		public override void OnCreate()
		{
		}

		public override void AddDefaultSockets()
		{
		}

		public override void CopyNode(Node original)
		{
		}

		protected override void OnEnable()
		{
		}

		public override void OnEnter(Node previousActiveNode, Connection connection)
		{
		}

		public override void OnUpdate()
		{
		}

		public override void OnExit(Node nextActiveNode, Connection connection)
		{
		}

		private void UpdateCurrentDuration()
		{
		}

		private void StartWait()
		{
		}

		private void EndWait()
		{
		}

		private void ActivateTimer()
		{
		}

		private void StopTimer()
		{
		}

		private void OnGameEventMessage(GameEventMessage message)
		{
		}

		private void SceneLoaded(Scene scene, LoadSceneMode mode)
		{
		}

		private void SceneUnloaded(Scene unloadedScene)
		{
		}

		private void ActiveSceneChanged(Scene current, Scene next)
		{
		}

		private bool IsTargetScene(Scene scene)
		{
			return false;
		}

		private void OnUIViewMessage(UIViewMessage message)
		{
		}

		private void OnUIButtonMessage(UIButtonMessage message)
		{
		}

		private void OnUIDrawerMessage(UIDrawerMessage message)
		{
		}

		private void ContinueToNextNode()
		{
		}

		public override void CheckForErrors()
		{
		}
	}
}
