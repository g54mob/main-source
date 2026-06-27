using System;
using Restory.Utils.UserInterfaceUtils.TweenSequencesUtils;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_AnimatedButtonView : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		[SerializeField]
		private TweenSequenceConstructor clickSequence;

		[SerializeField]
		private bool shouldDisabledOnComplete;

		[SerializeField]
		private bool nonRestartable;

		public bool IsActive => clickSequence.IsSequenceActive;

		public event Action OnAnimationStart;

		public event Action OnAnimationComplete;

		private void OnEnable()
		{
			clickSequence.OnSequenceStarted.AddListener(OnSequenceStart);
			clickSequence.OnSequenceKilled.AddListener(OnSequenceComplete);
		}

		private void OnDisable()
		{
			clickSequence.OnSequenceStarted.RemoveListener(OnSequenceStart);
			clickSequence.OnSequenceKilled.RemoveListener(OnSequenceComplete);
		}

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				StartSequence();
			}
		}

		private void StartSequence()
		{
			if (clickSequence.IsSequenceActive)
			{
				if (!shouldDisabledOnComplete && !nonRestartable)
				{
					clickSequence.RestartActiveSequence();
				}
			}
			else
			{
				clickSequence.StartSequence();
			}
		}

		private void OnSequenceStart()
		{
			this.OnAnimationStart?.Invoke();
		}

		private void OnSequenceComplete()
		{
			this.OnAnimationComplete?.Invoke();
			if (shouldDisabledOnComplete)
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}
}
