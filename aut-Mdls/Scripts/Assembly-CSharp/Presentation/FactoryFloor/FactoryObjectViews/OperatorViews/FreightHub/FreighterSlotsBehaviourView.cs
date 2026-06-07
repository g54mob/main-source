using DG.Tweening;
using Data.FactoryFloor;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Freighter;
using Data.FactoryFloor.Freighter.Actions;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews.OperatorViews.FreightHub
{
	public class FreighterSlotsBehaviourView : FreighterBehaviourView<FreighterSlotsBehaviour>
	{
		private FactoryObject _freightHubFactoryObject;

		private FactoryObjectView _freightHubView;

		public static readonly int[] DropCrateAnimatorTriggers = new int[4]
		{
			Animator.StringToHash("DropCrate4"),
			Animator.StringToHash("DropCrate3"),
			Animator.StringToHash("DropCrate2"),
			Animator.StringToHash("DropCrate1")
		};

		public static readonly int[] RetrieveCrateAnimatorTriggers = new int[4]
		{
			Animator.StringToHash("RetrieveCrate4"),
			Animator.StringToHash("RetrieveCrate3"),
			Animator.StringToHash("RetrieveCrate2"),
			Animator.StringToHash("RetrieveCrate1")
		};

		public static readonly int[] DropAndRetrieveCrateAnimatorTriggers = new int[4]
		{
			Animator.StringToHash("DropAndRetrieveCrate4"),
			Animator.StringToHash("DropAndRetrieveCrate3"),
			Animator.StringToHash("DropAndRetrieveCrate2"),
			Animator.StringToHash("DropAndRetrieveCrate1")
		};

		public static readonly int[] DropAndRetrieveCrateLongAnimatorTriggers = new int[4]
		{
			Animator.StringToHash("DropAndRetrieveCrateLong4"),
			Animator.StringToHash("DropAndRetrieveCrateLong3"),
			Animator.StringToHash("DropAndRetrieveCrateLong2"),
			Animator.StringToHash("DropAndRetrieveCrateLong1")
		};

		private const float ROTATION_DURATION = 0.5f;

		public override void Enter(IFreighterObjectStateBehaviour freighterObjectStateBehaviour, FreighterObject freighterObject, FreighterView freighterView)
		{
			base.Enter(freighterObjectStateBehaviour, freighterObject, freighterView);
			_freightHubFactoryObject = _freighter.Path.GetCurrentFactoryObject();
			_view.transform.DOKill();
			_view.RotationPivot.DOKill();
			int num = _freightHubFactoryObject.Rotation - 90 + (_freightHubFactoryObject.Mirrored ? 180 : 0);
			_view.transform.DORotateQuaternion(Quaternion.Euler(0f, num, 0f), 0.5f).SetEase(Ease.OutCubic);
			_view.RotationPivot.DOLocalRotateQuaternion(Quaternion.identity, 0.5f).SetEase(Ease.OutCubic);
			_behaviour.OnFreighterSlotAnimation.RegisterMainThread(OnFreighterSlotAnimation);
		}

		public override void Exit()
		{
			_behaviour.OnFreighterSlotAnimation.UnRegisterMainThread(OnFreighterSlotAnimation);
		}

		public override void Update()
		{
		}

		public void SetInitialState(FreighterObject freighter, FreighterView freighterView)
		{
			for (int i = 0; i < 4; i++)
			{
				FreightHubBehaviour.FreightHubSlot freightHubSlot = freighter.Slots.StorageSlots[i];
				if (!freightHubSlot.HasResource)
				{
					freighterView.SetCrateActive(i, active: false);
					continue;
				}
				freighterView.SetCrateResource(i, freightHubSlot.Resource);
				freighterView.Animator.SetTrigger(RetrieveCrateAnimatorTriggers[i]);
			}
		}

		private void OnFreighterSlotAnimation(int slotIndex, FreighterSlotAction action, FreightHubBehaviour.FreightHubSlot slotBeforeAction, FreightHubBehaviour.FreightHubSlot slotAfterAction)
		{
			if (slotBeforeAction.Resource == slotAfterAction.Resource && slotBeforeAction.Amount == slotAfterAction.Amount)
			{
				return;
			}
			if (!slotBeforeAction.HasResource && slotAfterAction.HasResource)
			{
				_view.SetCrateResource(slotIndex, _behaviour.StorageSlots[slotIndex].Resource);
				_view.Animator.SetTrigger(RetrieveCrateAnimatorTriggers[slotIndex]);
			}
			else if (slotBeforeAction.HasResource && !slotAfterAction.HasResource)
			{
				_view.Animator.SetTrigger(DropCrateAnimatorTriggers[slotIndex]);
			}
			else if (slotBeforeAction.HasResource && slotAfterAction.HasResource)
			{
				if (action is FreighterSlotActionUnloadAndLoad)
				{
					_view.Animator.SetTrigger(DropAndRetrieveCrateAnimatorTriggers[slotIndex]);
				}
				else
				{
					_view.Animator.SetTrigger(DropAndRetrieveCrateLongAnimatorTriggers[slotIndex]);
				}
			}
		}
	}
}
