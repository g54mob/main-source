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
	public class BloodyArcade : MachineBase, ITrapMachine, IInteractiveFurniture, IVisibleBBTObject, IBBTObject, IObject, IVisible
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
		[BoxGroup("Waypoints Settings")]
		[MinMaxSlider(0f, 20f)]
		private Vector2 ProcessDuration;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Animation Settings")]
		private Animator _animator;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		private AnimationClip _machine04Loose;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		private AnimationClip _humanFall02;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string ProcessInAnimatorTrigger = "ProcessIn";

		[SerializeField]
		[Space(10f)]
		[BoxGroup("GameObject Links")]
		private TrapSystem _trapSystem;

		private Sequence _processSequence;

		private byte _humanWillBeCaptured;

		private bool _processCanceled;

		private EScreenIcon _tmpScreenIcon;

		private Vector3[] waypoints;

		private Vector3 _endPos;

		private Cell _selectedCell;

		public new static readonly Func<BloodyArcade, bool> IsOn = (BloodyArcade machine) => machine.MachinePowerState == EMachinePowerState.On;

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
			base.MachineSoundManager.StopAllSFXMachine();
			if (_processSequence != null)
			{
				_processSequence.Kill();
				MachineBaseUseSequence.Kill();
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
				if ((bool)SFXMachineList)
				{
					base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[0]);
				}
			});
			_processSequence.AppendInterval(UnityEngine.Random.Range(ProcessDuration.x, ProcessDuration.y) * base.WorkerIntelligenceEffect);
			_processSequence.AppendCallback(delegate
			{
				if (!_processCanceled)
				{
					base.User.Statistics.TryAddToStatisticUnitInterval(EAgentStatistics.Fun, _giveFunPercent);
				}
			});
			_selectedCell = _trapSystem.HumanCanBeCaptured(base.User);
			if ((bool)_selectedCell)
			{
				_selectedCell.IsReserved = true;
				byte humanSexType = ((!base.User.HasDeepVoice) ? ((byte)1) : ((byte)0));
				_processSequence.AppendCallback(delegate
				{
					if (!_processCanceled)
					{
						if ((bool)SFXMachineList)
						{
							base.MachineSoundManager.StopAllSFXMachine();
							base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[2]);
						}
						StartCoroutine((!_processCanceled) ? MachineScreenManager.SetScreen(EScreenColor.Red, EScreenIcon.DeadIcon) : MachineScreenManager.SetScreen(EScreenColor.Default, EScreenIcon.PowerIcon));
						base.User.Animator.PlayPunctual(AgentAnim.Machine04Loose);
					}
				});
				_processSequence.AppendInterval(_machine04Loose.length - 0.8f);
				_processSequence.AppendCallback(delegate
				{
					if (!_processCanceled)
					{
						_trapSystem.OpenTrapSequence(humanSexType);
						base.User.Animator.PlayPunctual(AgentAnim.TrapFall02);
					}
				});
				_processSequence.AppendInterval(2f);
				_processSequence.AppendCallback(delegate
				{
					if (!_processCanceled)
					{
						_selectedCell.SetVictim(base.User);
						_endPos = base.User.transform.position - new Vector3(0f, 2.5f, 0f);
						base.User.transform.DOMove(_endPos, 0.25f).SetEase(Ease.InOutSine);
					}
				});
				_processSequence.AppendInterval(0.8f);
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
					BloodyArcade.HumanCaptured?.Invoke(base.User);
					InvokeVictimCaptured(base.User);
				});
			}
			else
			{
				_processSequence.AppendCallback(delegate
				{
					if (!_processCanceled)
					{
						base.User.Animator.PlayPunctual(AgentAnim.Machine04Win);
						if ((bool)SFXMachineList)
						{
							base.MachineSoundManager.StopAllSFXMachine();
							base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[1]);
						}
					}
				});
			}
			_processSequence.AppendInterval(1f);
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
