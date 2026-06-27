using DG.Tweening;
using Restory.Gameplay.GameView;
using Restory.Gameplay.InteractiveObjects;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment
{
	public class TrashCanPositionSwitcher : MonoBehaviour
	{
		[SerializeField]
		private Transform trashCan;

		[SerializeField]
		private Vector3 defaultPosition;

		[SerializeField]
		private Vector3 leftPosition;

		[SerializeField]
		private Vector3 rightPosition;

		[SerializeField]
		private Ease ease = Ease.OutQuad;

		[SerializeField]
		private float duration = 1f;

		private DragObjectRegistrator dragObjectRegistrator;

		private CameraDirectionSwitcher cameraDirectionSwitcher;

		private TweenSequencesService tweenSequencesService;

		private bool isSubscribed;

		private InteractiveObject trackedTrashObject;

		private Sequence moveSequence;

		[Inject]
		private void Construct(DragObjectRegistrator dragObjectRegistrator, CameraDirectionSwitcher cameraDirectionSwitcher, TweenSequencesService tweenSequencesService)
		{
			this.dragObjectRegistrator = dragObjectRegistrator;
			this.cameraDirectionSwitcher = cameraDirectionSwitcher;
			this.tweenSequencesService = tweenSequencesService;
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
			trackedTrashObject = null;
		}

		private void Subscribe()
		{
			if (!isSubscribed)
			{
				isSubscribed = true;
				dragObjectRegistrator.OnTrashObjectStartDrag += ResolveTrashObjectStartDrag;
				dragObjectRegistrator.OnInteractiveObjectStopDrag += ResolveInteractiveObjectStopDrag;
				cameraDirectionSwitcher.OnCameraDirectionChanged += ResolveCameraDirectionChanged;
			}
		}

		private void Unsubscribe()
		{
			if (isSubscribed)
			{
				isSubscribed = false;
				dragObjectRegistrator.OnTrashObjectStartDrag -= ResolveTrashObjectStartDrag;
				dragObjectRegistrator.OnInteractiveObjectStopDrag -= ResolveInteractiveObjectStopDrag;
				cameraDirectionSwitcher.OnCameraDirectionChanged -= ResolveCameraDirectionChanged;
			}
		}

		private void ResolveTrashObjectStartDrag()
		{
			trackedTrashObject = dragObjectRegistrator.DraggingObject;
			if ((bool)trackedTrashObject)
			{
				MoveTrash();
			}
		}

		private void ResolveInteractiveObjectStopDrag()
		{
			if ((bool)trackedTrashObject)
			{
				trackedTrashObject = null;
			}
		}

		private void ResolveCameraDirectionChanged()
		{
			if ((bool)trackedTrashObject)
			{
				MoveTrash();
			}
		}

		private void MoveTrash()
		{
			MoveTrash(cameraDirectionSwitcher.CurrentDirection switch
			{
				CameraDirection.Left => leftPosition, 
				CameraDirection.Right => rightPosition, 
				_ => defaultPosition, 
			});
		}

		private void MoveTrash(Vector3 targetPosition)
		{
			if (moveSequence != null)
			{
				tweenSequencesService.Kill(moveSequence);
			}
			moveSequence = tweenSequencesService.Create();
			moveSequence.Append(trashCan.DOMove(targetPosition, duration).SetEase(ease));
		}
	}
}
