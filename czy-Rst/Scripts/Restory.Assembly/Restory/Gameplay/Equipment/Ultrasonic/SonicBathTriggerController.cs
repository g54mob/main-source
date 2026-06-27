using System;
using System.Collections;
using UnityEngine;

namespace Restory.Gameplay.Equipment.Ultrasonic
{
	public class SonicBathTriggerController : MonoBehaviour
	{
		[SerializeField]
		private ClickableTrigger bodyTrigger;

		[SerializeField]
		private ClickableTrigger buttonTrigger;

		[SerializeField]
		private SonicBathElementFitter elementFitter;

		[SerializeField]
		[Range(0f, 0.8f)]
		private float detectionCooldown = 0.5f;

		private Coroutine detectionCooldownCoroutine;

		private bool canBeDetected = true;

		public bool CanBeDetected
		{
			set
			{
				if (canBeDetected == value)
				{
					return;
				}
				canBeDetected = value;
				if (!canBeDetected || detectionCooldownCoroutine == null)
				{
					bodyTrigger.Toggle(value);
					buttonTrigger.Toggle(value);
					if (!canBeDetected)
					{
						StartDetectionCooldownCoroutine();
					}
				}
			}
		}

		public event Action OnBodyClick;

		private void OnEnable()
		{
			bodyTrigger.OnClick += ResolveBodyClick;
			elementFitter.OnTargetChanged += ResolveElementFitterTargetChanged;
		}

		private void OnDisable()
		{
			bodyTrigger.OnClick -= ResolveBodyClick;
			elementFitter.OnTargetChanged -= ResolveElementFitterTargetChanged;
		}

		private void ResolveBodyClick()
		{
			this.OnBodyClick?.Invoke();
		}

		private void ResolveElementFitterTargetChanged()
		{
			if (elementFitter.HasTarget)
			{
				buttonTrigger.Toggle(enabled: false);
			}
			else
			{
				buttonTrigger.Toggle(canBeDetected);
			}
		}

		private void StartDetectionCooldownCoroutine()
		{
			if (detectionCooldownCoroutine != null)
			{
				StopCoroutine(detectionCooldownCoroutine);
			}
			detectionCooldownCoroutine = StartCoroutine(DetectionCooldownCoroutine());
		}

		private IEnumerator DetectionCooldownCoroutine()
		{
			yield return new WaitForSeconds(detectionCooldown);
			if (canBeDetected)
			{
				bodyTrigger.Toggle(enabled: true);
				buttonTrigger.Toggle(enabled: true);
			}
			detectionCooldownCoroutine = null;
		}
	}
}
