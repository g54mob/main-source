using System.Collections;
using System.Collections.Generic;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Drones;
using FMODUnity;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class SupplyTankView : FactoryResourceHolderView<SupplyTankBehaviour>
	{
		[SerializeField]
		private SupplyTankDroneView _droneViewPrefab;

		[SerializeField]
		private List<Transform> _blockedViews;

		[SerializeField]
		private Animator _supplyTankAnimator;

		[SerializeField]
		private List<SupplyTankCapsuleView> _capsuleViews;

		[SerializeField]
		private SupplyTankCapsuleView _storageCapsule;

		[Header("Audio")]
		[SerializeField]
		private EventReference _capsuleTakenSFX;

		[SerializeField]
		private EventReference _capsuleFilledSFX;

		private readonly List<SupplyTankDroneView> _drones = new List<SupplyTankDroneView>();

		private static readonly int[] AnimatorRefillHashes = new int[4]
		{
			Animator.StringToHash("SectionOne_Refill"),
			Animator.StringToHash("SectionTwo_Refill"),
			Animator.StringToHash("SectionThree_Refill"),
			Animator.StringToHash("SectionFour_Refill")
		};

		private static readonly int[] AnimatorDeliverHashes = new int[4]
		{
			Animator.StringToHash("SectionOne_Deliver"),
			Animator.StringToHash("SectionTwo_Deliver"),
			Animator.StringToHash("SectionThree_Deliver"),
			Animator.StringToHash("SectionFour_Deliver")
		};

		private static readonly int[] AnimatorHasDroneHashes = new int[4]
		{
			Animator.StringToHash("SectionOne_HasDrone"),
			Animator.StringToHash("SectionTwo_HasDrone"),
			Animator.StringToHash("SectionThree_HasDrone"),
			Animator.StringToHash("SectionFour_HasDrone")
		};

		protected override void Init()
		{
			base.Init();
			UpdateBlockedViews();
			_behaviour.OnCreatedDrone.RegisterMainThread(CreateDroneView);
			_behaviour.OnCapsuleFilled.RegisterMainThread(CapsuleFilled);
			_behaviour.OnCapsuleTaken.RegisterMainThread(CapsuleTaken);
			_behaviour.OnResourceCountChanged.RegisterMainThread(ResourceCountChanged);
			_behaviour.OnResourceAdded.RegisterMainThread(ResourceAdded);
			foreach (KeyValuePair<SupplyTankRecipientBehaviour, SupplyTankDroneBehaviour> linkedRecipient in _behaviour.LinkedRecipients)
			{
				CreateDroneView(linkedRecipient.Value);
			}
			for (int i = 0; i < _capsuleViews.Count; i++)
			{
				CapsuleTaken(i);
				if (_behaviour.HasFilledCapsule(i))
				{
					StartCoroutine(SetCapsuleFilled(i, _behaviour.GetCapsuleResourceID(i)));
				}
			}
			ResourceCountChanged();
		}

		private IEnumerator SetCapsuleFilled(int index, int resourceID)
		{
			yield return new WaitForSeconds(1f);
			CapsuleFilled(index, resourceID);
		}

		protected override void ResetFactoryObject()
		{
			if ((bool)_behaviour)
			{
				_behaviour.OnCreatedDrone.UnRegisterMainThread(CreateDroneView);
				_behaviour.OnCapsuleFilled.UnRegisterMainThread(CapsuleFilled);
				_behaviour.OnCapsuleTaken.UnRegisterMainThread(CapsuleTaken);
				_behaviour.OnResourceCountChanged.UnRegisterMainThread(ResourceCountChanged);
				_behaviour.OnResourceAdded.UnRegisterMainThread(ResourceAdded);
			}
			base.ResetFactoryObject();
		}

		private void UpdateBlockedViews()
		{
			for (int i = 0; i < _blockedViews.Count; i++)
			{
				_blockedViews[i].gameObject.SetActive(i >= _behaviour.MaxLinkedRecipients);
			}
		}

		private void CreateDroneView(SupplyTankDroneBehaviour droneBehaviour)
		{
			SupplyTankDroneView supplyTankDroneView = Object.Instantiate(_droneViewPrefab, base.transform);
			supplyTankDroneView.Init(droneBehaviour, this, droneBehaviour.StartPos, droneBehaviour.EndPos);
			_drones.Add(supplyTankDroneView);
			SetAnimatorHasDrone(droneBehaviour.DroneID, hasDrone: true);
		}

		public void DestroyDroneView(SupplyTankDroneView supplyTankDroneView, SupplyTankDroneBehaviour droneBehaviour)
		{
			_drones.Remove(supplyTankDroneView);
			SetAnimatorHasDrone(droneBehaviour.DroneID, hasDrone: false);
		}

		private void ResourceCountChanged()
		{
			_storageCapsule.SetLiquidToResource(_behaviour.CurrentResourceData);
			_storageCapsule.SetLiquidFillPercentage((float)_behaviour.CurrentResourceAmount / (float)_behaviour.MaxStorage);
		}

		private void ResourceAdded()
		{
			_audioManagerLocator.AudioManager.PlayFactoryBehaviourViewOneShot(_capsuleFilledSFX, _objectView.transform.position, _objectView.FactoryObject.FactoryObjectData.ObjectSize);
		}

		private void CapsuleFilled(int capsuleID, int resourceID)
		{
			_supplyTankAnimator.SetTrigger(AnimatorDeliverHashes[capsuleID]);
			_capsuleViews[capsuleID].SetLiquidToResource(resourceID);
			_capsuleViews[capsuleID].AnimateLiquidFillPercentage(1f);
		}

		private void CapsuleTaken(int capsuleID)
		{
			_supplyTankAnimator.ResetTrigger(AnimatorDeliverHashes[capsuleID]);
			_supplyTankAnimator.SetTrigger(AnimatorRefillHashes[capsuleID]);
			_capsuleViews[capsuleID].SetLiquidFillPercentage(0f);
		}

		private void SetAnimatorHasDrone(int capsuleID, bool hasDrone)
		{
			_supplyTankAnimator.SetBool(AnimatorHasDroneHashes[capsuleID], hasDrone);
		}
	}
}
