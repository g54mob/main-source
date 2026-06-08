using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dorfromantik.UI
{
	public class UiScalingManager : ScriptableObject
	{
		private sealed class _003C_003Ec__DisplayClass36_0
		{
			public float uiScalingFloat;

			internal bool _003CGetScalingLevel_003Eb__0(KeyValuePair<UiScalingLevelId, float> x)
			{
				return x.Value == uiScalingFloat;
			}
		}

		private sealed class _003C_003Ec__DisplayClass37_0
		{
			public UiScalingLevelId uiScalingLevelId;

			internal bool _003CSetUiScalingLevel_003Eb__0(UiScalingLevelData x)
			{
				return x.levelId == uiScalingLevelId;
			}
		}

		[SerializeField]
		private float defaultQuestBubbleScale = 0.2f;

		[SerializeField]
		private AnimationCurve questBubbleScaleByUiLevel;

		[SerializeField]
		private bool scaleQuestBubblesWithZoom;

		[SerializeField]
		private AnimationCurve questBubbleScaleByZoomDistance;

		[SerializeField]
		private bool scaleQuestBubblesByScreenPos;

		[SerializeField]
		private AnimationCurve questBubbleScaleByScreenCenterDistance;

		private float _003CCurrentQuestBubbleScale_003Ek__BackingField;

		[SerializeField]
		private AnimationCurve offscreenQuestByUiLevel;

		[SerializeField]
		private QuestManager questManager;

		[SerializeField]
		private SettingsRouter settingsRouter;

		[SerializeField]
		private List<UiScalingLevelData> uiScalingLevels;

		[SerializeField]
		private SessionQuestScreen rewardScreenPrefab;

		[SerializeField]
		private UiScalingLevelId currentUiScalingLevelId;

		[FormerlySerializedAs("currentUiScalingData")]
		[SerializeField]
		private UiScalingLevelData currentUiScaling;

		[SerializeField]
		private float currentZoomDistance;

		private readonly Dictionary<UiScalingLevelId, float> uiScaleByScalingLevel = new Dictionary<UiScalingLevelId, float>
		{
			{
				UiScalingLevelId.Default,
				1f
			},
			{
				UiScalingLevelId.Large,
				1.5f
			}
		};

		public float DefaultQuestBubbleScale => defaultQuestBubbleScale;

		public float CurrentQuestBubbleScale
		{
			get
			{
				return _003CCurrentQuestBubbleScale_003Ek__BackingField;
			}
			private set
			{
				_003CCurrentQuestBubbleScale_003Ek__BackingField = value;
			}
		}

		public float CurrentOffscreenQuestMarkerScale => offscreenQuestByUiLevel.Evaluate(uiScaleByScalingLevel[currentUiScalingLevelId]);

		private float BiggestUiScaleLevel => uiScaleByScalingLevel[UiScalingLevelId.Large];

		private float SmallestUiScaleLevel => uiScaleByScalingLevel[UiScalingLevelId.Default];

		public UiScalingLevelData CurrentUiScalingLevel => currentUiScaling;

		public event Action<UiScalingLevelData> OnUiScalingLevelChanged;

		public void Initialize()
		{
		}

		public void OnZoomCamera(float zoomDistance)
		{
			currentZoomDistance = zoomDistance;
			if (scaleQuestBubblesWithZoom)
			{
				UpdateQuestUiScale();
			}
		}

		public void OnMoveCamera()
		{
			if (scaleQuestBubblesByScreenPos && settingsRouter.ScaleQuestsByScreenPos)
			{
				UpdateQuestUiScale();
			}
		}

		private void UpdateQuestUiScale()
		{
			CurrentQuestBubbleScale = defaultQuestBubbleScale * uiScaleByScalingLevel[currentUiScalingLevelId];
			if (scaleQuestBubblesWithZoom)
			{
				CurrentQuestBubbleScale *= questBubbleScaleByZoomDistance.Evaluate(currentZoomDistance);
			}
			foreach (QuestWatcher allQuestWatcher in questManager.AllQuestWatchers)
			{
				float num = 1f;
				if (scaleQuestBubblesByScreenPos && settingsRouter.ScaleQuestsByScreenPos)
				{
					float time = Vector2.Distance(Camera.main.WorldToViewportPoint(allQuestWatcher.QuestLabel.transform.position), new Vector2(0.5f, 0.5f)) * 2f;
					num = questBubbleScaleByScreenCenterDistance.Evaluate(time);
				}
				allQuestWatcher.ChangeQuestBubbleScale(CurrentQuestBubbleScale * num);
			}
		}

		public UiScalingLevelId GetScalingLevel(float uiScalingFloat)
		{
			_003C_003Ec__DisplayClass36_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass36_0();
			CS_0024_003C_003E8__locals5.uiScalingFloat = uiScalingFloat;
			if (CS_0024_003C_003E8__locals5.uiScalingFloat < SmallestUiScaleLevel || CS_0024_003C_003E8__locals5.uiScalingFloat > BiggestUiScaleLevel)
			{
				Debug.LogError($"The passed UI Scaling Value ({CS_0024_003C_003E8__locals5.uiScalingFloat}) is not available!", this);
			}
			return Enumerable.FirstOrDefault(uiScaleByScalingLevel, (KeyValuePair<UiScalingLevelId, float> x) => x.Value == CS_0024_003C_003E8__locals5.uiScalingFloat).Key;
		}

		public void SetUiScalingLevel(UiScalingLevelId uiScalingLevelId)
		{
			_003C_003Ec__DisplayClass37_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass37_0();
			CS_0024_003C_003E8__locals3.uiScalingLevelId = uiScalingLevelId;
			currentUiScaling = Enumerable.FirstOrDefault(uiScalingLevels, (UiScalingLevelData x) => x.levelId == CS_0024_003C_003E8__locals3.uiScalingLevelId);
			if ((bool)currentUiScaling)
			{
				rewardScreenPrefab.SetGridSize(currentUiScaling.challengeCardSize);
				if ((bool)Singleton<MainMenuUi>.Instance)
				{
					Singleton<MainMenuUi>.Instance.challengeScreen.SetGridSize(currentUiScaling.challengeCardSize);
				}
			}
			currentUiScalingLevelId = CS_0024_003C_003E8__locals3.uiScalingLevelId;
			this.OnUiScalingLevelChanged?.Invoke(currentUiScaling);
		}

		public void DBG_UpdateUiScalingLevel(UiScalingLevelId uiScalingLevelId)
		{
			SetUiScalingLevel(uiScalingLevelId);
		}

		private void GetBiggestUiScaleLevel()
		{
			Enumerable.ToList(uiScaleByScalingLevel.Values).Sort();
		}

		private void GetSmallestUiScaleLevel()
		{
			Enumerable.ToList(uiScaleByScalingLevel.Values).Sort();
		}
	}
}
