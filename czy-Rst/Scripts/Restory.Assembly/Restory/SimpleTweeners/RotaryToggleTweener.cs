using DG.Tweening;
using UnityEngine;

namespace Restory.SimpleTweeners
{
	public class RotaryToggleTweener : ToggleTweenerBase
	{
		[SerializeField]
		private Vector3 eulerAngleRotationOffset = Vector3.zero;

		private Vector3 finalEulerRotation;

		private Vector3 cachedLocalEulerAngles = Vector3.zero;

		private bool isOn;

		public override float Progress { get; set; }

		public override bool IsOn => isOn;

		protected override void CacheInitialState()
		{
			cachedLocalEulerAngles = base.transform.localEulerAngles;
			finalEulerRotation = cachedLocalEulerAngles + eulerAngleRotationOffset;
			PlayImmediately();
		}

		public override void Play()
		{
			if (isOn)
			{
				TurnOff();
			}
			else
			{
				TurnOn();
			}
		}

		public override void PlayImmediately()
		{
			Vector3 euler = (isOn ? finalEulerRotation : (-finalEulerRotation));
			base.transform.localRotation = Quaternion.Euler(euler);
		}

		public override void RevertState()
		{
		}

		public override void TurnOn()
		{
			if (!isOn)
			{
				isOn = true;
				Sequence sequence = InitSequence();
				sequence.Append(base.transform.DOLocalRotate(finalEulerRotation, duration).SetEase(ease));
				sequence.Play();
			}
		}

		public override void TurnOff()
		{
			if (isOn)
			{
				isOn = false;
				Sequence sequence = InitSequence();
				sequence.Append(base.transform.DOLocalRotate(-finalEulerRotation, duration).SetEase(ease));
				sequence.Play();
			}
		}
	}
}
