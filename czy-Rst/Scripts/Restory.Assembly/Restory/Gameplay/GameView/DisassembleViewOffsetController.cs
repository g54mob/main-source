using DG.Tweening;
using Restory.Gameplay.Elements;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.GameView
{
	public class DisassembleViewOffsetController : MonoBehaviour
	{
		[SerializeField]
		private Transform disassembleViewPoint;

		[SerializeField]
		private Vector3 tiltOffset;

		[SerializeField]
		[Range(0f, 2f)]
		private float transitionDuration = 0.4f;

		[SerializeField]
		private Ease transitionEase = Ease.InOutSine;

		private DragElementRegistrator dragElementRegistrator;

		private TweenSequencesService tweenSequences;

		private bool isSubscribed;

		private bool hasOffset;

		private Sequence transitionSequence;

		[Inject]
		private void Construct(DragElementRegistrator dragElementRegistrator, TweenSequencesService tweenSequences)
		{
			this.dragElementRegistrator = dragElementRegistrator;
			this.tweenSequences = tweenSequences;
			Subscribe();
		}

		private void OnEnable()
		{
			if (dragElementRegistrator != null)
			{
				Subscribe();
			}
		}

		private void OnDisable()
		{
			if (dragElementRegistrator != null)
			{
				Unsubscribe();
			}
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
				transitionSequence = null;
			}
		}

		private void Subscribe()
		{
			if (!isSubscribed)
			{
				isSubscribed = true;
				dragElementRegistrator.OnBrokenElementStartDrag += ResolveBrokenElementStartDrag;
				dragElementRegistrator.OnElementStopDrag += ResolveElementStopDrag;
			}
		}

		private void Unsubscribe()
		{
			if (isSubscribed)
			{
				isSubscribed = false;
				dragElementRegistrator.OnBrokenElementStartDrag -= ResolveBrokenElementStartDrag;
				dragElementRegistrator.OnElementStopDrag -= ResolveElementStopDrag;
			}
		}

		private void ResolveBrokenElementStartDrag()
		{
			ApplyTiltOffset();
		}

		private void ResolveElementStopDrag()
		{
			if (hasOffset)
			{
				ResetOffset();
			}
		}

		private void ApplyTiltOffset()
		{
			hasOffset = true;
			TransferViewPoint(tiltOffset);
		}

		private void ResetOffset()
		{
			hasOffset = false;
			TransferViewPoint(Vector3.zero);
		}

		private void TransferViewPoint(Vector3 targetOffset)
		{
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
			}
			transitionSequence = tweenSequences.Create();
			transitionSequence.Append(disassembleViewPoint.DOLocalMove(targetOffset, transitionDuration).SetEase(transitionEase));
		}
	}
}
