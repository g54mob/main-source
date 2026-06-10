using System;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Scripts.Pooler;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	[RequireComponent(typeof(DoorComponent), typeof(GateAnimationComponent))]
	public class GateViewComponent : ComponentBaseView
	{
		[SerializeField]
		private GateAnimationComponent gateAnimationComponent;

		[NonSerialized]
		private DoorComponent doorComponent;

		[SerializeField]
		private GameObject defaultGate;

		[SerializeField]
		private GameObject defaultGateBroken;

		[SerializeField]
		private GameObject invertedGate;

		[SerializeField]
		private GameObject invertedGateBroken;

		[SerializeField]
		private Transform useTransform;

		public Transform UseTransform => useTransform;

		private DoorComponentInstance DoorComponentInstance => doorComponent.ComponentInstance;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			doorComponent = GetComponent<DoorComponent>();
		}

		protected override void OnComponentEnterFinishedState(bool afterLoading = false)
		{
			base.OnComponentEnterFinishedState(afterLoading);
			doorComponent.DoorLockStatusChangedEvent += OnLockStatusChanged;
			doorComponent.ComponentInstance.AbortGateOpeningEvent += OnAbortGateOpening;
			doorComponent.ComponentInstance.AbortGateClosingEvent += OnAbortGateClosing;
			doorComponent.ComponentInstance.StartOpeningAnimationEvent += OnStartOpeningAnimation;
			doorComponent.ComponentInstance.StartClosingAnimationEvent += OnStartClosingAnimation;
			doorComponent.ComponentInstance.ChangeGateDirectionEvent += OnChangeGateDirection;
			if (useTransform != null)
			{
				doorComponent.ComponentInstance.SetUsePosition(useTransform.position.ToGridVec3Int());
			}
			RefreshGateVisuals();
		}

		private void OnLockStatusChanged()
		{
			if (!(gateAnimationComponent == null))
			{
				RefreshGateVisuals();
				LockState lockState = doorComponent.ComponentInstance.LockState;
				bool openCloseAnim = lockState == LockState.AlwaysOpen || lockState == LockState.ForcedOpen;
				gateAnimationComponent.SetOpenCloseAnim(openCloseAnim);
			}
		}

		private void OnAbortGateOpening()
		{
			gateAnimationComponent.AbortGateOpening();
		}

		private void OnAbortGateClosing()
		{
			gateAnimationComponent.AbortGateClosing();
		}

		private void OnStartOpeningAnimation(float animationSpeedMultiplier)
		{
			gateAnimationComponent.StartOpeningAnimation(animationSpeedMultiplier);
		}

		private void OnStartClosingAnimation(float animationSpeedMultiplier)
		{
			gateAnimationComponent.StartClosingAnimation(animationSpeedMultiplier);
		}

		private void OnChangeGateDirection()
		{
			RefreshGateVisuals();
		}

		private void RefreshGateVisuals()
		{
			if (DoorComponentInstance == null || DoorComponentInstance.HasDisposed)
			{
				return;
			}
			if (DoorComponentInstance.LockState == LockState.ForcedOpen)
			{
				MonoSingleton<ParticleSystemPool>.Instance.PlayParticles("destroy_building", base.transform);
				if (DoorComponentInstance.GateDirection == GateDirection.Default)
				{
					defaultGate.SetActive(value: false);
					defaultGateBroken.SetActive(value: true);
					invertedGate.SetActive(value: false);
					invertedGateBroken.SetActive(value: false);
				}
				else
				{
					invertedGate.SetActive(value: false);
					invertedGateBroken.SetActive(value: true);
					defaultGate.SetActive(value: false);
					defaultGateBroken.SetActive(value: false);
				}
			}
			else if (DoorComponentInstance.GateDirection == GateDirection.Default)
			{
				defaultGate.SetActive(value: true);
				defaultGateBroken.SetActive(value: false);
				invertedGate.SetActive(value: false);
				invertedGateBroken.SetActive(value: false);
			}
			else
			{
				invertedGate.SetActive(value: true);
				invertedGateBroken.SetActive(value: false);
				defaultGate.SetActive(value: false);
				defaultGateBroken.SetActive(value: false);
			}
		}
	}
}
