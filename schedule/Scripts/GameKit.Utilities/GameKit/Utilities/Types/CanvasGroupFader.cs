using GameKit.Dependencies.Inspectors;
using UnityEngine;

namespace GameKit.Utilities.Types
{
	public class CanvasGroupFader : MonoBehaviour
	{
		public enum FadeGoalType
		{
			Unset = 0,
			Hidden = 1,
			Visible = 2
		}

		[Group("Components", false)]
		[SerializeField]
		[Tooltip("CanvasGroup to fade in and out.")]
		protected CanvasGroup CanvasGroup;

		[Group("Effects", false)]
		[SerializeField]
		[Tooltip("True to update the CanvasGroup blocking settings when showing and hiding.")]
		protected bool UpdateCanvasBlocking;

		[Group("Effects", false)]
		[SerializeField]
		protected float FadeInDuration;

		[Group("Effects", false)]
		[SerializeField]
		protected float FadeOutDuration;

		private bool _completedOnce;

		public FadeGoalType FadeGoal { get; private set; }

		public bool IsHiding => false;

		public bool IsVisible => false;

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void Update()
		{
		}

		public virtual void ShowImmediately()
		{
		}

		public virtual void HideImmediately()
		{
		}

		public virtual void Show()
		{
		}

		protected virtual void OnShow()
		{
		}

		public virtual void Hide()
		{
		}

		protected virtual void OnHide()
		{
		}

		private void SetFadeGoal(bool fadeIn)
		{
		}

		private void Fade()
		{
		}

		protected virtual void CompleteFade(bool fadingIn)
		{
		}

		protected virtual void SetCanvasGroupBlockingType(CanvasGroupBlockingType blockingType)
		{
		}
	}
}
