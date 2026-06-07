using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.UI
{
	public class MapButtonLockedCard : MapButtonCard
	{
		[SerializeField]
		private LocalizedTextUI header;

		[SerializeField]
		private LocalizedTextUI descriptionHeader;

		[SerializeField]
		private LocalizedTextUI description;

		[SerializeField]
		private TouchButton touchButton;

		[SerializeField]
		private Animator _animator;

		private static readonly int AnimationTriggerUnlockMap = Animator.StringToHash("Unlock");

		public LocalizedTextUI Header => header;

		public LocalizedTextUI DescriptionHeader => descriptionHeader;

		public LocalizedTextUI Description => description;

		public TouchButton TouchButton => touchButton;

		public event Action OnNavButtonClicked;

		private event Action _onUnlockAnimationComplete;

		public void NavButtonClicked()
		{
			this.OnNavButtonClicked?.Invoke();
		}

		public void PlayUnlockAnimation(Action onComplete)
		{
			_onUnlockAnimationComplete += onComplete;
			_animator.SetTrigger(AnimationTriggerUnlockMap);
		}

		[UsedImplicitly]
		public void UnlockAnimationComplete()
		{
			this._onUnlockAnimationComplete?.Invoke();
		}
	}
}
