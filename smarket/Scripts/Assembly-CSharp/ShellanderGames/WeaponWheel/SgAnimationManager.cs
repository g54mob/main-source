using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShellanderGames.WeaponWheel
{
	public class SgAnimationManager
	{
		private enum SgTaskType
		{
			alpha = 0,
			color = 1,
			scale = 2
		}

		private struct SgTaskKey
		{
			public readonly SgTaskType type;

			public readonly MonoBehaviour owner;

			public SgTaskKey(MonoBehaviour owner, SgTaskType type)
			{
				this.type = default(SgTaskType);
				this.owner = null;
			}
		}

		private struct SgTaskData
		{
			public readonly Action doneCallback;

			public readonly MonoBehaviour owner;

			public readonly float duration;

			public readonly float timeStarted;

			public readonly SgTaskKey key;

			public SgTaskData(MonoBehaviour owner, float duration, Action doneCallback, SgTaskType type, float timeStarted)
			{
				this.doneCallback = null;
				this.owner = null;
				this.duration = 0f;
				this.timeStarted = 0f;
				key = default(SgTaskKey);
			}

			public void Done()
			{
			}
		}

		private interface SgAnimationTaskI
		{
			SgTaskData GetTaskData();

			void Update(float timeElapsed);

			void Done();
		}

		private struct SgAlphaTask : SgAnimationTaskI
		{
			public readonly SgTaskData taskData;

			public readonly CanvasGroup canvasGroup;

			public readonly float startAlpha;

			public readonly float targetAlpha;

			public SgTaskData GetTaskData()
			{
				return default(SgTaskData);
			}

			public SgAlphaTask(MonoBehaviour owner, CanvasGroup canvasGroup, float targetAlpha, float duration, Action doneCallback, float timeStarted)
			{
				taskData = default(SgTaskData);
				this.canvasGroup = null;
				startAlpha = 0f;
				this.targetAlpha = 0f;
			}

			public void Update(float timeElapsed)
			{
			}

			public void Done()
			{
			}
		}

		private struct SgColorTask : SgAnimationTaskI
		{
			public readonly SgTaskData taskData;

			public readonly Graphic uiGraphic;

			public readonly Color startColor;

			public readonly Color targetColor;

			public SgTaskData GetTaskData()
			{
				return default(SgTaskData);
			}

			public SgColorTask(Graphic uiGraphic, Color targetColor, float duration, Action doneCallback, float timeStarted)
			{
				taskData = default(SgTaskData);
				this.uiGraphic = null;
				startColor = default(Color);
				this.targetColor = default(Color);
			}

			public void Update(float timeElapsed)
			{
			}

			public void Done()
			{
			}
		}

		private struct SgScaleTask : SgAnimationTaskI
		{
			public readonly SgTaskData taskData;

			public readonly Vector2 startScale;

			public readonly Vector2 targetScale;

			public SgTaskData GetTaskData()
			{
				return default(SgTaskData);
			}

			public SgScaleTask(MonoBehaviour target, Vector2 targetScale, float duration, Action doneCallback, float timeStarted)
			{
				taskData = default(SgTaskData);
				startScale = default(Vector2);
				this.targetScale = default(Vector2);
			}

			public void Update(float timeElapsed)
			{
			}

			public void Done()
			{
			}
		}

		private struct SgSizeTask : SgAnimationTaskI
		{
			public readonly SgTaskData taskData;

			public readonly RectTransform targetTransform;

			public readonly Vector2 startSize;

			public readonly Vector2 targetSize;

			public SgTaskData GetTaskData()
			{
				return default(SgTaskData);
			}

			public SgSizeTask(MonoBehaviour target, RectTransform targetTransform, Vector2 defaultSize, Vector2 targetScale, float duration, Action doneCallback, float timeStarted)
			{
				taskData = default(SgTaskData);
				this.targetTransform = null;
				startSize = default(Vector2);
				targetSize = default(Vector2);
			}

			public void Update(float timeElapsed)
			{
			}

			public void Done()
			{
			}
		}

		private readonly List<SgAnimationTaskI> m_ScheduledTasks;

		private readonly List<SgTaskKey> m_CleanupKeys;

		private readonly Dictionary<SgTaskKey, SgAnimationTaskI> m_CurrentTasks;

		private float m_CurrentTime;

		public void UpdateLoop(float time)
		{
		}

		public void AnimateAlpha(MonoBehaviour owner, CanvasGroup canvasGroup, float targetAlpha, float duration, Action doneCallback)
		{
		}

		public void AnimateColor(Graphic uiGraphic, Color targetColor, float duration, Action doneCallback)
		{
		}

		public void AnimateScale(MonoBehaviour target, Vector2 targetScale, float duration, Action doneCallback)
		{
		}

		public void AnimateSize(MonoBehaviour target, RectTransform targetTransform, Vector2 defaultSize, Vector2 targetScale, float duration, Action doneCallback)
		{
		}

		private void TaskStart(SgAnimationTaskI task)
		{
		}
	}
}
