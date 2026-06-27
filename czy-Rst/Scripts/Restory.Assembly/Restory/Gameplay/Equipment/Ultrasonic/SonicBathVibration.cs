using DG.Tweening;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.Ultrasonic
{
	public class SonicBathVibration : MonoBehaviour
	{
		[SerializeField]
		private Vector3 vibrationScale = new Vector3(0.996f, 1.008f, 0.996f);

		[SerializeField]
		[Min(0.01f)]
		private float halfCycleDuration = 0.1f;

		[SerializeField]
		private Ease vibrationEase = Ease.InOutSine;

		private TweenSequencesService tweenSequences;

		private Sequence vibrationSequence;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences)
		{
			this.tweenSequences = tweenSequences;
		}

		private void OnDisable()
		{
			StopVibration();
		}

		public void StartVibration()
		{
			StopVibration();
			vibrationSequence = tweenSequences.Create();
			vibrationSequence.Append(base.transform.DOScale(vibrationScale, halfCycleDuration).SetEase(vibrationEase)).SetLoops(-1, LoopType.Yoyo);
		}

		public void StopVibration()
		{
			if (vibrationSequence != null)
			{
				tweenSequences.Kill(vibrationSequence);
				vibrationSequence = null;
				base.transform.localScale = Vector3.one;
			}
		}
	}
}
