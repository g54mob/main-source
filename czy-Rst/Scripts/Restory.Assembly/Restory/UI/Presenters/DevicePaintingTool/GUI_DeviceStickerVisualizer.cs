using System;
using DG.Tweening;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.DevicePaintingTool
{
	public class GUI_DeviceStickerVisualizer : MonoBehaviour
	{
		[Serializable]
		private class StickerMovement
		{
			public Vector3 targetPosition;

			public Vector3 targetRotation;

			public Ease Ease = Ease.OutQuad;

			[Range(100f, 1000f)]
			public float Speed = 400f;
		}

		[SerializeField]
		private Transform stickerPivot;

		[Space]
		[Header("Scale Animation Settings")]
		[SerializeField]
		private Vector3 peakScale = new Vector3(1.2f, 1.2f, 1.2f);

		[SerializeField]
		[Min(0f)]
		private float scaleUpDuration = 0.15f;

		[SerializeField]
		[Min(0f)]
		private float scaleHoldDuration = 0.1f;

		[SerializeField]
		[Min(0f)]
		private float scaleDownDuration = 0.15f;

		[SerializeField]
		private Ease scaleUpEase = Ease.OutQuad;

		[SerializeField]
		private Ease scaleDownEase = Ease.InQuad;

		[Space]
		[Header("Movement Animation Settings")]
		[SerializeField]
		private StickerMovement forwardMovement;

		[SerializeField]
		private StickerMovement centerMovement;

		[SerializeField]
		private StickerMovement backwardMovement;

		[SerializeField]
		private StickerMovement bottomMovement;

		private TweenSequencesService tweenSequences;

		private Sequence scaleSequence;

		private Sequence movementSequence;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences)
		{
			this.tweenSequences = tweenSequences;
		}

		private void OnDisable()
		{
			Clear();
			stickerPivot.localScale = Vector3.one;
		}

		public void PlayForwardMovementAnimation()
		{
			PlayMovementAnimation(forwardMovement);
		}

		public void PlayCenterMovementAnimation()
		{
			PlayMovementAnimation(centerMovement);
		}

		public void PlayBackwardMovementAnimation()
		{
			PlayMovementAnimation(backwardMovement);
		}

		public void SetCentralPosition()
		{
			SetTargetPosition(centerMovement);
		}

		public void SetBottomPosition()
		{
			SetTargetPosition(bottomMovement);
		}

		public void PlayScaleAnimation()
		{
			ClearScaleSequence();
			scaleSequence = tweenSequences.Create();
			scaleSequence.Append(stickerPivot.DOScale(peakScale, scaleUpDuration).SetEase(scaleUpEase)).AppendInterval(scaleHoldDuration).Append(stickerPivot.DOScale(Vector3.one, scaleDownDuration).SetEase(scaleDownEase))
				.OnComplete(delegate
				{
					stickerPivot.localScale = Vector3.one;
				});
		}

		private void PlayMovementAnimation(StickerMovement movement)
		{
			ClearMovementSequence();
			float duration = Vector3.Distance(stickerPivot.localPosition, movement.targetPosition) / movement.Speed;
			movementSequence = tweenSequences.Create();
			movementSequence.Append(stickerPivot.DOLocalMove(movement.targetPosition, duration).SetEase(movement.Ease)).Join(stickerPivot.DOLocalRotate(movement.targetRotation, duration).SetEase(movement.Ease));
		}

		private void SetTargetPosition(StickerMovement movement)
		{
			stickerPivot.SetLocalPositionAndRotation(movement.targetPosition, Quaternion.Euler(movement.targetRotation));
		}

		private void Clear()
		{
			ClearScaleSequence();
			ClearMovementSequence();
		}

		private void ClearScaleSequence()
		{
			if (scaleSequence != null)
			{
				tweenSequences.Kill(scaleSequence);
				scaleSequence = null;
			}
		}

		private void ClearMovementSequence()
		{
			if (movementSequence != null)
			{
				tweenSequences.Kill(movementSequence);
				movementSequence = null;
			}
		}
	}
}
