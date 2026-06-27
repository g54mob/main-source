using System;
using DG.Tweening;
using Restory.Data.GameView;
using Restory.Gameplay.Equipment;
using Restory.Utils;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.GameView
{
	public class GameViewController : MonoBehaviour, IDisposable
	{
		[Header("Game View Settings")]
		[SerializeField]
		private GameViewPreset defaultViewPreset;

		[SerializeField]
		private GameViewPreset defaultDisassembleViewPreset;

		[SerializeField]
		private float transitionDuration = 1f;

		[SerializeField]
		private Ease transitionEase = Ease.InQuad;

		[Space]
		[Header("Equipment")]
		[SerializeField]
		private Transform noteTransform;

		[SerializeField]
		private Transform tabletTransform;

		[SerializeField]
		private Transform inventoryTransform;

		[SerializeField]
		private Transform trashCanTransform;

		[SerializeField]
		private Transform trashCanModelTransform;

		[Space]
		[Header("Camera Settings")]
		[SerializeField]
		private CinemachineCamera virtualCamera;

		private TweenSequencesService tweenSequences;

		private CameraDirectionSwitcher cameraDirectionSwitcher;

		private Transform cameraTransform;

		private Transform spotLightTransform;

		private Transform binTransform;

		private Transform cleanerTransform;

		private GameViewPreset currentViewPreset;

		private Sequence transitionSequence;

		public bool IsCurrentViewPresetDisassemblePreset => currentViewPreset != defaultViewPreset;

		public Vector3 CameraTargetPosition => currentViewPreset.cameraPosition;

		public event Action OnViewPresetSwitchingProcessStarted;

		public event Action OnViewPresetSwitchingProcessComplete;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences, CameraDirectionSwitcher cameraDirectionSwitcher, DeviceSpotLight deviceSpotLight, SmallElementBin smallElementBin, ElementCleaner elementCleaner)
		{
			this.tweenSequences = tweenSequences;
			this.cameraDirectionSwitcher = cameraDirectionSwitcher;
			cameraTransform = virtualCamera.transform;
			spotLightTransform = deviceSpotLight.transform;
			binTransform = smallElementBin.transform;
			cleanerTransform = elementCleaner.transform;
			currentViewPreset = defaultViewPreset;
		}

		public void Dispose()
		{
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
				transitionSequence = null;
			}
		}

		public void ApplyDefaultViewPreset()
		{
			ApplyViewPreset(defaultViewPreset);
		}

		public void ApplyDisassembleViewPreset(GameViewPreset viewPreset = null)
		{
			if (viewPreset == null)
			{
				viewPreset = defaultDisassembleViewPreset;
			}
			ApplyViewPreset(viewPreset);
		}

		private void ApplyViewPreset(GameViewPreset viewPreset)
		{
			if (!(currentViewPreset == viewPreset))
			{
				currentViewPreset = viewPreset;
				cameraDirectionSwitcher.ApplyCameraDirection(viewPreset.cameraDirection, transitionEase, transitionDuration);
				if (transitionSequence != null)
				{
					tweenSequences.Kill(transitionSequence);
				}
				transitionSequence = tweenSequences.Create();
				transitionSequence.Append(cameraTransform.DOMove(viewPreset.cameraPosition, transitionDuration)).Join(DOTween.To(() => virtualCamera.Lens.FieldOfView, delegate(float x)
				{
					virtualCamera.Lens.FieldOfView = x;
				}, viewPreset.cameraFieldOfView, transitionDuration)).Join(spotLightTransform.DOMove(viewPreset.lightPosition, transitionDuration))
					.Join(spotLightTransform.DORotateQuaternion(viewPreset.lightRotation, transitionDuration))
					.Join(binTransform.DOMove(viewPreset.binPosition, transitionDuration))
					.Join(binTransform.DORotateQuaternion(viewPreset.binRotation, transitionDuration))
					.Join(cleanerTransform.DOMove(viewPreset.cleanerPosition, transitionDuration))
					.Join(cleanerTransform.DORotateQuaternion(viewPreset.cleanerRotation, transitionDuration))
					.Join(noteTransform.DOMove(viewPreset.notePosition, transitionDuration))
					.Join(noteTransform.DORotateQuaternion(viewPreset.noteRotation, transitionDuration))
					.Join(tabletTransform.DOMove(viewPreset.tabletPosition, transitionDuration))
					.Join(tabletTransform.DORotateQuaternion(viewPreset.tabletRotation, transitionDuration))
					.Join(inventoryTransform.DOMove(viewPreset.inventoryPosition, transitionDuration))
					.Join(inventoryTransform.DORotateQuaternion(viewPreset.inventoryRotation, transitionDuration))
					.Join(trashCanTransform.DOMove(viewPreset.trashCanPosition, transitionDuration))
					.Join(trashCanModelTransform.DORotateQuaternion(viewPreset.trashCanRotation, transitionDuration))
					.SetEase(transitionEase)
					.OnComplete(OnTransferComplete);
				this.OnViewPresetSwitchingProcessStarted?.Invoke();
			}
		}

		private void OnTransferComplete()
		{
			this.OnViewPresetSwitchingProcessComplete?.Invoke();
		}
	}
}
