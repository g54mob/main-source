using System;
using Restory.SimpleTweeners;
using UnityEngine;

namespace Restory.Gameplay.Equipment.Ultrasonic
{
	public class SonicBathToggleButton : MonoBehaviour
	{
		[SerializeField]
		private ClickableTrigger buttonTrigger;

		[SerializeField]
		private ToggleTweenerBase buttonTweener;

		[SerializeField]
		private GameObject buttonLamp;

		public bool IsOn => buttonTweener.IsOn;

		public event Action OnButtonClick;

		private void OnEnable()
		{
			buttonTrigger.OnClick += ResolveButtonPush;
			buttonTweener.TweenEvents.OnComplete.AddListener(ResolveButtonClick);
		}

		private void OnDisable()
		{
			buttonTrigger.OnClick -= ResolveButtonPush;
			buttonTweener.TweenEvents.OnComplete.RemoveListener(ResolveButtonClick);
		}

		public void TurnOn()
		{
			buttonTweener.TurnOn();
		}

		public void TurnOff()
		{
			buttonTweener.TurnOff();
		}

		private void ResolveButtonPush()
		{
			buttonTweener.Play();
		}

		private void ResolveButtonClick()
		{
			buttonLamp.SetActive(IsOn);
			this.OnButtonClick?.Invoke();
		}
	}
}
