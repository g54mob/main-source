using DG.Tweening;
using Restory.Data.Equipment;
using Restory.Gameplay.InteractiveObjects;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.GameView
{
	public class WorkViewOffsetController : MonoBehaviour
	{
		[SerializeField]
		private ToolsCategory shredderToolsCategory;

		[SerializeField]
		private Transform workViewPointsHolder;

		[SerializeField]
		private Vector3 tiltOffset;

		[SerializeField]
		[Range(0f, 2f)]
		private float transitionDuration = 0.4f;

		[SerializeField]
		private Ease transitionEase = Ease.InOutSine;

		private DragObjectRegistrator dragObjectRegistrator;

		private TweenSequencesService tweenSequences;

		private bool isSubscribed;

		private bool hasOffset;

		private Sequence transitionSequence;

		[Inject]
		private void Construct(DragObjectRegistrator dragObjectRegistrator, TweenSequencesService tweenSequences)
		{
			this.dragObjectRegistrator = dragObjectRegistrator;
			this.tweenSequences = tweenSequences;
			Subscribe();
		}

		private void OnEnable()
		{
			if (dragObjectRegistrator != null)
			{
				Subscribe();
			}
		}

		private void OnDisable()
		{
			if (dragObjectRegistrator != null)
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
				dragObjectRegistrator.OnTrashObjectStartDrag += ResolveTrashObjectStartDrag;
				dragObjectRegistrator.OnInteractiveObjectStopDrag += ResolveInteractiveObjectStopDrag;
				dragObjectRegistrator.OnPersonalObjectStartDrag += ResolvePersonalObjectStartDrag;
			}
		}

		private void Unsubscribe()
		{
			if (isSubscribed)
			{
				isSubscribed = false;
				dragObjectRegistrator.OnTrashObjectStartDrag -= ResolveTrashObjectStartDrag;
				dragObjectRegistrator.OnInteractiveObjectStopDrag -= ResolveInteractiveObjectStopDrag;
				dragObjectRegistrator.OnPersonalObjectStartDrag -= ResolvePersonalObjectStartDrag;
			}
		}

		private void ResolveTrashObjectStartDrag()
		{
			ApplyTiltOffset();
		}

		private void ResolveInteractiveObjectStopDrag()
		{
			if (hasOffset)
			{
				ResetOffset();
			}
		}

		private void ResolvePersonalObjectStartDrag(PersonalObjectBase personalObject)
		{
			if (personalObject is PersonalTool personalTool && personalTool.ToolInfo != null && personalTool.ToolInfo.ToolsCategory == shredderToolsCategory)
			{
				ApplyTiltOffset();
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
			transitionSequence.Append(workViewPointsHolder.DOLocalMove(targetOffset, transitionDuration).SetEase(transitionEase));
		}
	}
}
