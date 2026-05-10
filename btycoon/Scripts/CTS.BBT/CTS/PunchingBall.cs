using System;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.BBT.Handlers.Transactions;
using CTS.Core;
using CTS.Emotes;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class PunchingBall : MachineBase, ITrapMachine, IInteractiveFurniture, IVisibleBBTObject, IBBTObject, IObject, IVisible
	{
		[SerializeField]
		[Space(10f)]
		[BoxGroup("Base Settings")]
		[Range(0f, 20f)]
		private int _partyPrice;

		[SerializeField]
		[BoxGroup("Base Settings")]
		[Range(0f, 1f)]
		private float _giveFunPercent;

		[SerializeField]
		[BoxGroup("Link Component")]
		public MachineScreenManager MachineScreenManager;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Animation Settings")]
		private Animator _animator;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		private AnimationClip _winHumanAnimationClip;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		private AnimationClip _looseHumanAnimationClip;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		private AnimationClip _closeTrapAnimationClip;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string IdleAnimatorTrigger = "Idle";

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string WinAnimatorTrigger = "Win";

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string LooseInAnimatorTrigger = "Loose";

		[SerializeField]
		[Space(10f)]
		[BoxGroup("GameObject Links")]
		private TrapSystem _trapSystem;

		private Sequence _processSequence;

		private bool _processCanceled;

		private EScreenIcon _tmpScreenIcon;

		private Vector3[] waypoints;

		private Vector3 _endPos;

		private Cell _selectedCell;

		public new static readonly Func<PunchingBall, bool> IsOn = (PunchingBall machine) => machine.MachinePowerState == EMachinePowerState.On;

		public static event Action<Agent> HumanCaptured;

		protected override void OnMachineSwitchPower(EMachinePowerState value)
		{
			base.OnMachineSwitchPower(value);
			_processCanceled = false;
			switch (value)
			{
			case EMachinePowerState.On:
				StartCoroutine(MachineScreenManager.SetScreen(EScreenColor.Blue, EScreenIcon.PowerIcon));
				break;
			case EMachinePowerState.Off:
				OnCanceled();
				StartCoroutine(MachineScreenManager.SetScreen(EScreenColor.Default, EScreenIcon.PowerIcon));
				break;
			}
		}

		protected override void OnCanceled()
		{
			_processCanceled = true;
			_animator.SetTrigger(IdleAnimatorTrigger);
			if ((bool)base.MachineSoundManager)
			{
				base.MachineSoundManager.StopAllSFXMachine();
			}
			if (_processSequence != null)
			{
				_processSequence.Kill();
				_processSequence = null;
				MachineBaseUseSequence.Kill();
				MachineBaseUseSequence = null;
			}
			if ((bool)base.User)
			{
				base.User.Selection.Selectable = true;
				base.User.Animator.SetIdleAndPlay(AgentAnim.Idle);
			}
			if ((bool)_selectedCell && _selectedCell.IsReserved)
			{
				_selectedCell.IsReserved = false;
			}
		}

		protected override void OnGameResume()
		{
			if ((bool)base.MachineSoundManager)
			{
				base.MachineSoundManager.StopAllSFXMachine();
			}
		}

		protected override void OnFurniturePickedUp()
		{
			base.OnFurniturePickedUp();
			if ((bool)_selectedCell && _selectedCell.IsReserved)
			{
				_selectedCell.IsReserved = false;
			}
		}

		protected override Sequence LoadIn()
		{
			Sequence result = DOTween.Sequence();
			_processCanceled = false;
			return result;
		}

		public override bool UsageCondition(Agent agent)
		{
			if (MachinePowerState == EMachinePowerState.Off)
			{
				return false;
			}
			if (!(agent is Customer))
			{
				return false;
			}
			return true;
		}

		protected override Sequence ProcessIn()
		{
			return DOTween.Sequence();
		}

		protected override Sequence Process()
		{
			_processSequence = DOTween.Sequence();
			_processSequence.AppendCallback(delegate
			{
				if (base.User is Customer customer)
				{
					customer.SpendMoney(_partyPrice);
					customer.Selection.Selectable = false;
				}
				MonoSingleton<TransactionsHandlers>.Instance.AddNewData(TransactionType.Income, _partyPrice, TransactionTag.HumanCustomer);
				EmoteManager.Play<EmoteBBT>(base.User.transform.position + Vector3.up * 1.7f, $"${_partyPrice}").SetRoom(base.User.RoomObject);
			});
			_selectedCell = _trapSystem.HumanCanBeCaptured(base.User);
			byte humanSexType = ((!base.User.HasDeepVoice) ? ((byte)1) : ((byte)0));
			if ((bool)_selectedCell)
			{
				_selectedCell.IsReserved = true;
				_processSequence.AppendCallback(delegate
				{
					if (!_processCanceled)
					{
						if ((bool)SFXMachineList)
						{
							base.MachineSoundManager.CallPlaySFXMachine((humanSexType == 0) ? SFXMachineList.SoundsList[0] : SFXMachineList.SoundsList[1]);
						}
						base.User.Animator.PlayPunctual(AgentAnim.PunchingBallFallBack);
						_animator.SetTrigger(LooseInAnimatorTrigger);
						base.User.Statistics.TryAddToStatisticUnitInterval(EAgentStatistics.Fun, _giveFunPercent);
					}
				});
				_processSequence.AppendInterval(_looseHumanAnimationClip.length - 0.65f);
				_processSequence.AppendCallback(delegate
				{
					if (!_processCanceled)
					{
						_trapSystem.OpenTrapSequence(humanSexType, bigtrap: true);
					}
				});
				_processSequence.AppendInterval(0.4f);
				_processSequence.AppendCallback(delegate
				{
					if (!_processCanceled)
					{
						_selectedCell.SetVictim(base.User);
						_endPos = base.User.transform.position - new Vector3(0f, 2.5f, 0f);
						base.User.transform.DOMove(_endPos, 0.25f).SetEase(Ease.InOutSine);
					}
				});
				_processSequence.AppendInterval(_closeTrapAnimationClip.length);
				_processSequence.AppendCallback(delegate
				{
					if (!_processCanceled)
					{
						_trapSystem.CloseTrapSequence();
						base.User.transform.rotation = _selectedCell.transform.rotation;
						base.User.RoomObject.CurrentRoom = _selectedCell.Furniture.RoomObject.CurrentRoom;
					}
				});
				_processSequence.Append(_selectedCell.DoOpenTrap());
				_processSequence.AppendCallback(delegate
				{
					base.User.transform.position = _selectedCell.transform.position;
					base.User.Animator.PlayPunctualInstantly(AgentAnim.CellHumanAppear);
					_endPos = new Vector3(base.User.transform.position.x, 0f, base.User.transform.position.z);
					base.User.transform.DOMove(_endPos, 0.25f).SetEase(Ease.InOutSine);
				});
				_processSequence.Append(_selectedCell.DoCloseTrap());
				_processSequence.AppendCallback(delegate
				{
					base.User.ContextualFSM.SetStateStuck();
					base.User.ActionPlayer.ForceStopAll();
					_selectedCell.IsReserved = false;
					PunchingBall.HumanCaptured?.Invoke(base.User);
					InvokeVictimCaptured(base.User);
				});
			}
			else
			{
				_processSequence.AppendCallback(delegate
				{
					if (!_processCanceled)
					{
						if ((bool)SFXMachineList)
						{
							base.MachineSoundManager.CallPlaySFXMachine((humanSexType == 0) ? SFXMachineList.SoundsList[2] : SFXMachineList.SoundsList[3]);
						}
						base.User.Animator.PlayPunctual(AgentAnim.PunchingBallWin);
						_animator.SetTrigger(WinAnimatorTrigger);
					}
				});
				_processSequence.AppendInterval(_winHumanAnimationClip.length - 0.65f);
				_processSequence.AppendCallback(delegate
				{
					if (!_processCanceled)
					{
						base.User.Statistics.TryAddToStatisticUnitInterval(EAgentStatistics.Fun, _giveFunPercent);
						base.User.Animator.PlayPunctual(AgentAnim.Machine04Win);
					}
				});
			}
			_processSequence.AppendInterval(1f);
			_animator.SetTrigger(IdleAnimatorTrigger);
			return _processSequence;
		}

		protected override Sequence ProcessOut()
		{
			Sequence sequence = DOTween.Sequence();
			sequence.AppendCallback(delegate
			{
				if (base.User is Customer customer)
				{
					customer.Selection.Selectable = true;
				}
			});
			return sequence;
		}

		protected override Sequence Unload()
		{
			return DOTween.Sequence();
		}

		protected override void OnVictimUnloaded()
		{
		}
	}
}
