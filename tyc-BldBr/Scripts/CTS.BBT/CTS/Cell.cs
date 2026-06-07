using System;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class Cell : MachineBase, ICustomerCell, IMachine, IManageableFurniture, IInteractiveFurniture, IVisibleBBTObject, IBBTObject, IObject, IVisible, IDestructibleFurniture
	{
		[SerializeField]
		[Space(10f)]
		[BoxGroup("Base Settings")]
		private Transform _door;

		[SerializeField]
		[BoxGroup("Base Settings")]
		private float _openDuration;

		[SerializeField]
		[BoxGroup("Base Settings")]
		private Vector3 _openPosition;

		[SerializeField]
		[BoxGroup("Base Settings")]
		private AnimationCurve _openEasing = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[SerializeField]
		[BoxGroup("Base Settings")]
		private float _closedDuration;

		[SerializeField]
		[BoxGroup("Base Settings")]
		private Vector3 _closedPosition;

		[SerializeField]
		[BoxGroup("Base Settings")]
		private AnimationCurve _closedEasing = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Animation Settings")]
		private Animator _animator;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		private AnimationClip _openTrapAnimatorTriggerClip;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		private AnimationClip _closeTrapInAnimatorTriggerClip;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string OpenTrapAnimatorTrigger = "OpenDoor";

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string CloseTrapAnimatorTrigger = "CloseDoor";

		[SerializeField]
		[Space(10f)]
		[BoxGroup("GameObject Links")]
		private GameObject _navMeshObstacleDoor;

		private WorkerChore _loadChore;

		public EDoorStatus doorStatus;

		public static readonly Func<MachineBase, Customer, bool> IsBloodCompatible = (MachineBase machine, Customer customer) => !machine.HasAVictim && customer.BloodQuality >= machine.MachineBloodQuality.CurrentBloodQuality;

		public static readonly Func<Cell, Customer, bool> IsAvailableForTrap = (Cell cell, Customer customer) => IsBloodCompatible(cell, customer) && !cell.IsReserved;

		public bool IsReserved { get; set; }

		public static event Action<Cell, Agent> AgentCaptured;

		public static event Action<Cell, Agent> AgentReleased;

		public event Action<Agent> PrisonerEntered;

		public event Action<Agent> PrisonerLeaving;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			CreateLoadChore();
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			if (_loadChore != null)
			{
				_loadChore.OnActionComplete -= OnCaptureComplete;
				_loadChore.DestroyChore();
			}
		}

		protected override void OnFurniturePickedUp()
		{
			base.OnFurniturePickedUp();
			doorStatus = EDoorStatus.Closed;
		}

		public void CreateLoadChore()
		{
			_loadChore?.DestroyChore();
			_loadChore = new WorkerChoreHub(ChoreCategory.Capture, new ActionHubCaptureHuman(this)
			{
				UseAssignation = true
			}, base.Furniture.RoomObject);
			_loadChore.AssignationBypassPowers = true;
			_loadChore.AddContext(this);
			_loadChore.OnActionComplete += OnCaptureComplete;
			_loadChore.VisibleInContextualMenu = false;
			MonoSingleton<ChoreList>.Instance.AddToList(_loadChore);
		}

		public override void SetVictim(Agent victim)
		{
			base.SetVictim(victim);
			if (!(victim == null))
			{
				Cell.AgentCaptured?.Invoke(this, base.Victim);
				this.PrisonerEntered?.Invoke(_victim);
			}
		}

		private void OnCaptureComplete(AgentAction action)
		{
			action.OnActionComplete -= OnCaptureComplete;
			Cell.AgentCaptured?.Invoke(this, base.Victim);
			this.PrisonerEntered?.Invoke(base.Victim);
			CreateLoadChore();
		}

		public override Tween LoadPreparation()
		{
			return DoOpenDoor();
		}

		protected override Sequence LoadIn()
		{
			Sequence sequence = DOTween.Sequence();
			sequence.Append(DoCloseDoor(EClosingDoorType.Load));
			return sequence;
		}

		protected override Sequence ProcessIn()
		{
			throw new NotImplementedException("Cell shouldn't be used");
		}

		protected override Sequence Process()
		{
			throw new NotImplementedException("Cell shouldn't be used");
		}

		protected override Sequence ProcessOut()
		{
			throw new NotImplementedException("Cell shouldn't be used");
		}

		protected override Sequence Unload()
		{
			Sequence sequence = DOTween.Sequence();
			sequence.SetAutoKill(autoKillOnCompletion: false);
			sequence.AppendCallback(delegate
			{
				this.PrisonerLeaving?.Invoke(base.Victim);
				Cell.AgentReleased?.Invoke(this, base.Victim);
				_victim.Animator.ReturnToIdle();
			});
			sequence.Append(DoOpenDoor());
			return sequence;
		}

		protected override void OnVictimUnloaded()
		{
		}

		protected override void OnVictimFullyUnloaded()
		{
			base.OnVictimFullyUnloaded();
			if (!machineWillBeDestroyed)
			{
				DoCloseDoor(EClosingDoorType.Unload);
			}
		}

		public override void OnFurnitureUsageEndUnload()
		{
			if (doorStatus == EDoorStatus.Opened)
			{
				if ((bool)_victim)
				{
					SetVictim(null);
				}
				DoCloseDoor(EClosingDoorType.Unload);
			}
		}

		public override void UnloadPreparation()
		{
			this.PrisonerLeaving?.Invoke(base.Victim);
			Cell.AgentReleased?.Invoke(this, base.Victim);
		}

		public Tween DoOpenTrap()
		{
			Sequence sequence = DOTween.Sequence();
			sequence.AppendCallback(delegate
			{
				_animator.SetTrigger(OpenTrapAnimatorTrigger);
			});
			sequence.AppendInterval(_openTrapAnimatorTriggerClip.length);
			return sequence;
		}

		public Tween DoCloseTrap()
		{
			Sequence sequence = DOTween.Sequence();
			sequence.AppendCallback(delegate
			{
				_animator.SetTrigger(CloseTrapAnimatorTrigger);
			});
			sequence.AppendInterval(_closeTrapInAnimatorTriggerClip.length);
			return sequence;
		}

		private Tween DoOpenDoor()
		{
			if (machineWillBeDestroyed || doorStatus == EDoorStatus.Opened)
			{
				return null;
			}
			if ((bool)SFXMachineList)
			{
				base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[0]);
			}
			_navMeshObstacleDoor.SetActive(value: true);
			doorStatus = EDoorStatus.Opened;
			return _door.DOLocalMove(_openPosition, _openDuration).SetEase(_openEasing);
		}

		private Tween DoCloseDoor(EClosingDoorType value)
		{
			if (machineWillBeDestroyed || doorStatus == EDoorStatus.Closed)
			{
				return null;
			}
			Sequence sequence = DOTween.Sequence();
			if (value == EClosingDoorType.Unload)
			{
				sequence.AppendInterval(_closedDuration);
			}
			sequence.AppendCallback(delegate
			{
				if ((bool)SFXMachineList)
				{
					base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[1]);
				}
				doorStatus = EDoorStatus.Closed;
				_door.DOLocalMove(_closedPosition, _closedDuration).SetEase(_closedEasing);
			});
			sequence.AppendCallback(delegate
			{
				_navMeshObstacleDoor.SetActive(value: false);
			});
			return sequence;
		}
	}
}
