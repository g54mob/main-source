using System;
using NSEipix.Base;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.EnvironmentEffects;
using NSMedieval.Scripts.Pooler;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	[RequireComponent(typeof(DoorComponent))]
	public class DoorViewComponent : ComponentBaseView
	{
		[SerializeField]
		private DoorOpenAnim doorOpenAnim;

		[NonSerialized]
		private DoorComponent doorComponent;

		[SerializeField]
		private GameObject door;

		[SerializeField]
		private GameObject doorBroken;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			doorComponent = GetComponent<DoorComponent>();
		}

		protected override void OnComponentEnterFinishedState(bool afterLoading = false)
		{
			base.OnComponentEnterFinishedState(afterLoading);
			doorComponent.DoorLockStatusChangedEvent += OnLockStatusChanged;
			doorComponent.ComponentInstance.AbortPortcullisOpeningEvent += OnAbortPortcullisOpening;
			doorComponent.ComponentInstance.AbortDrawbridgeClosingEvent += OnAbortDrawbridgeClosing;
			doorComponent.ComponentInstance.AbortGateOpeningEvent += OnAbortGateOpening;
			doorComponent.ComponentInstance.AbortGateClosingEvent += OnAbortGateClosing;
			doorComponent.ComponentInstance.StartOpeningAnimationEvent += OnStartOpeningAnimation;
			doorComponent.ComponentInstance.StartClosingAnimationEvent += OnStartClosingAnimation;
			doorComponent.ComponentInstance.ChangeGateDirectionEvent += OnChangeGateDirection;
			if (doorOpenAnim != null)
			{
				doorOpenAnim.SetDoorComponentInstance(doorComponent.ComponentInstance);
			}
		}

		protected override void OnBuildingDisposed(IDisposable disposable)
		{
			base.OnBuildingDisposed(disposable);
			if (disposable is DoorComponentInstance doorComponentInstance && doorComponentInstance.Blueprint.DoorType == DoorType.Regular && doorOpenAnim != null)
			{
				doorOpenAnim.OnBuildingDisposed();
			}
		}

		private void OnLockStatusChanged()
		{
			if (!(doorOpenAnim == null))
			{
				if (doorComponent.ComponentInstance.LockState == LockState.ForcedOpen)
				{
					MonoSingleton<ParticleSystemPool>.Instance.PlayParticles("destroy_building", base.transform);
					MonoSingleton<CameraManager>.Instance.OnCameraShakeEvent(base.transform.position, CameraShakeStrength.Mild);
					door.SetActive(value: false);
					doorBroken.SetActive(value: true);
				}
				else
				{
					door.SetActive(value: true);
					doorBroken.SetActive(value: false);
				}
				switch (doorComponent.ComponentInstance.Blueprint.DoorType)
				{
				case DoorType.Portcullis:
					doorOpenAnim.UpdatePortcullisState();
					break;
				case DoorType.Drawbridge:
					doorOpenAnim.UpdateDrawbridgeState();
					break;
				default:
					doorOpenAnim.UpdateDoorAnim(null);
					break;
				}
			}
		}

		private void OnAbortPortcullisOpening()
		{
			doorOpenAnim.AbortPortcullisOpening();
		}

		private void OnAbortDrawbridgeClosing()
		{
			doorOpenAnim.AbortDrawbridgeClosing();
		}

		private void OnAbortGateOpening()
		{
			doorOpenAnim.AbortGateOpening();
		}

		private void OnAbortGateClosing()
		{
			doorOpenAnim.AbortGateClosing();
		}

		private void OnStartOpeningAnimation(float animationSpeedMultiplier)
		{
			doorOpenAnim.StartOpeningAnimation(animationSpeedMultiplier);
		}

		private void OnStartClosingAnimation(float animationSpeedMultiplier)
		{
			doorOpenAnim.StartClosingAnimation(animationSpeedMultiplier);
		}

		public void UpdateDoorAnim()
		{
			if (doorOpenAnim != null)
			{
				doorOpenAnim.UpdateDoorAnim(null);
			}
		}

		private void OnChangeGateDirection()
		{
			if (doorOpenAnim != null)
			{
				doorOpenAnim.InvertOpenedGate();
			}
		}
	}
}
