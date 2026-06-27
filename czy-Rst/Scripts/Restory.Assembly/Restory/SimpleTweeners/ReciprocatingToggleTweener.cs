using DG.Tweening;
using UnityEngine;

namespace Restory.SimpleTweeners
{
	public class ReciprocatingToggleTweener : ToggleTweenerBase
	{
		[SerializeField]
		private Vector3 localPositionOffset = Vector3.zero;

		private Vector3 pushedLocalPosition;

		private Vector3 cachedLocalPosition = Vector3.zero;

		private bool isOn;

		public override float Progress { get; set; }

		public override bool IsOn => isOn;

		protected override void CacheInitialState()
		{
			cachedLocalPosition = base.transform.localPosition;
			pushedLocalPosition = cachedLocalPosition + localPositionOffset;
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
			base.transform.localPosition = (isOn ? pushedLocalPosition : cachedLocalPosition);
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
				sequence.Append(base.transform.DOLocalMove(pushedLocalPosition, duration).SetEase(ease));
				sequence.Play();
			}
		}

		public override void TurnOff()
		{
			if (isOn)
			{
				isOn = false;
				Sequence sequence = InitSequence();
				sequence.Append(base.transform.DOLocalMove(cachedLocalPosition, duration).SetEase(ease));
				sequence.Play();
			}
		}
	}
}
