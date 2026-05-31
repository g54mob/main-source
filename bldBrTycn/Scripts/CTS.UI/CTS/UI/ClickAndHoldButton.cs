using System;
using System.Collections;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CTS.UI
{
	public class ClickAndHoldButton : CTSButton
	{
		[SerializeField]
		private float _holdBuffer = 0.5f;

		[SerializeField]
		private float _holdTickDuration = 0.2f;

		[SerializeField]
		private bool _accelerate;

		[SerializeField]
		[Label("Multiplier")]
		private float _accelerationMultiplier = 1f;

		[SerializeField]
		[Label("Is Exponential")]
		private bool _accelerationExponential;

		public event Action HeldTick;

		public override void OnPointerClick(PointerEventData eventData)
		{
		}

		public override void OnSubmit(BaseEventData eventData)
		{
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			if (base.currentSelectionState == SelectionState.Pressed)
			{
				StartCoroutine(HoldRoutine());
			}
		}

		public override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerUp(eventData);
			if (base.currentSelectionState != SelectionState.Pressed)
			{
				StopAllCoroutines();
			}
		}

		private IEnumerator HoldRoutine()
		{
			this.HeldTick?.Invoke();
			yield return Coroutines.WaitForSecondsRealtime(_holdBuffer);
			double startTime = Time.realtimeSinceStartupAsDouble;
			float duration = _holdTickDuration;
			while (base.currentSelectionState == SelectionState.Pressed)
			{
				this.HeldTick?.Invoke();
				if (_accelerate)
				{
					if (_accelerationExponential)
					{
						duration *= _accelerationMultiplier;
					}
					else
					{
						double num = Time.realtimeSinceStartupAsDouble - startTime + 1.0;
						duration = _holdTickDuration / ((float)num * _accelerationMultiplier);
					}
				}
				yield return Coroutines.WaitForSecondsRealtime(duration);
			}
		}
	}
}
