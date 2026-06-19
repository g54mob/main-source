using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class ObjectiveMenuItemBase : MonoBehaviour
	{
		[SerializeField]
		private Button _mainButton;

		[SerializeField]
		private TooltipSpawner _tooltipSpawner;

		[SerializeField]
		protected GameObject _completeEffectPrefab;

		[SerializeField]
		protected Transform _completeEffectParent;

		[SerializeField]
		protected float _completeEffectTime = 2f;

		[SerializeField]
		protected float _completeFadeOutRate = 4f;

		protected Level _level;

		protected Objective _objective;

		protected Coroutine _completeEffectCoroutine;

		public Objective Objective => _objective;

		public virtual void Initialise(Level level, Objective objective)
		{
			_level = level;
			_objective = objective;
			if (_mainButton != null)
			{
				_mainButton.onClick.AddListener(OnClicked);
			}
			if (_tooltipSpawner != null)
			{
				_tooltipSpawner.SetShouldShowFunc(_objective.ShouldShowTooltip);
				_tooltipSpawner.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = _objective.GetObjectiveMenuItemTooltip();
				});
			}
		}

		protected virtual void OnDisable()
		{
			if (_completeEffectCoroutine != null)
			{
				Object.Destroy(base.gameObject);
			}
		}

		public virtual void UpdateSubGoal(ObjectiveSubGoal objectiveSubGoal)
		{
		}

		public virtual void OnObjectiveStarted()
		{
		}

		public virtual void OnObjectiveRestarting()
		{
		}

		public virtual void OnObjectiveCompleted(Objective.CompletionType completionType)
		{
			if (!_objective.IsReplayable || completionType != Objective.CompletionType.Failed)
			{
				if (!base.gameObject.activeInHierarchy)
				{
					Object.Destroy(base.gameObject);
				}
				else
				{
					_completeEffectCoroutine = StartCoroutine(PlayCompleteEffect(completionType));
				}
			}
		}

		public virtual void OnObjectiveReadyForDestroy()
		{
		}

		public virtual LevelObjectiveSubGoal GetMostImportantUnfinishedSubGoal(int subGoalObjectiveDepth = 0)
		{
			return null;
		}

		public virtual RectTransform GetSubGoalTransform(ObjectiveSubGoal subGoal)
		{
			return null;
		}

		private IEnumerator PlayCompleteEffect(Objective.CompletionType completionType)
		{
			GameObject gameObject = ((completionType == Objective.CompletionType.Successful) ? _completeEffectPrefab : null);
			if (gameObject != null)
			{
				Object.Instantiate(gameObject, _completeEffectParent).transform.SetAsLastSibling();
				yield return new WaitForSecondsRealtime(_completeEffectTime);
			}
			CanvasGroup canvasGroup = base.gameObject.AddComponent<CanvasGroup>();
			canvasGroup.alpha = 1f;
			while (canvasGroup.alpha > 0f)
			{
				canvasGroup.alpha -= GameTime.unscaledDeltaTime * _completeFadeOutRate;
				base.transform.localScale = new Vector3(canvasGroup.alpha, canvasGroup.alpha, 1f);
				yield return null;
			}
			Object.Destroy(base.gameObject);
		}

		public virtual void OnObjectiveKickStateChanged()
		{
		}

		public virtual void OnClicked()
		{
			_objective.OnMouseSelect();
		}
	}
}
