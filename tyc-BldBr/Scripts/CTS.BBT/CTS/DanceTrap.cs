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
	public class DanceTrap : MachineBase, ITrapMachine, IInteractiveFurniture, IVisibleBBTObject, IBBTObject, IObject, IVisible
	{
		[SerializeField]
		[Space(10f)]
		[BoxGroup("Base Settings")]
		[Range(1f, 5f)]
		private int _cycleMinimalCount;

		[SerializeField]
		[BoxGroup("Base Settings")]
		[Range(0f, 20f)]
		private int _partyPrice;

		[SerializeField]
		[BoxGroup("Base Settings")]
		[Range(0f, 1f)]
		private float _giveFunPercent;

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
		private AnimationClip _openTrapAnimationClip;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		private AnimationClip _closeTrapAnimationClip;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		private AnimationClip _danceTrapAnimationClip;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string TurnOnScreenAnimatorTrigger = "TurnOn";

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string TurnOffScreenAnimatorTrigger = "TurnOff";

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string IdleScreenAnimatorTrigger = "Idle";

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string PlayingScreenAnimatorTrigger = "Playing";

		[SerializeField]
		[Space(10f)]
		[BoxGroup("GameObject Links")]
		private TrapSystem _trapSystem;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private GameObject _screen;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private GameObject _screenBackground;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private GameObject _screenInsertCoins;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private GameObject _screenarrowTop;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private GameObject _screenarrowRight;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private GameObject _screenarrowLeft;

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
				_animator.SetTrigger(TurnOnScreenAnimatorTrigger);
				break;
			case EMachinePowerState.Off:
				OnCanceled();
				_animator.SetTrigger(TurnOffScreenAnimatorTrigger);
				break;
			}
		}

		protected override void OnCanceled()
		{
			_processCanceled = true;
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
				DisableAllArrows();
				if (MachinePowerState != EMachinePowerState.Off)
				{
					_animator.SetTrigger(IdleScreenAnimatorTrigger);
				}
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
				if ((bool)SFXMachineList)
				{
					base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[0]);
				}
			});
			_selectedCell = _trapSystem.HumanCanBeCaptured(base.User);
			byte humanSexType = ((!base.User.HasDeepVoice) ? ((byte)1) : ((byte)0));
			_processSequence.AppendInterval(0.5f);
			_processSequence.AppendCallback(delegate
			{
				_animator.SetTrigger(PlayingScreenAnimatorTrigger);
			});
			_processSequence.AppendInterval(0.5f);
			Sequence sequence = DOTween.Sequence();
			int _cycleCount = 0;
			sequence.SetLoops(_cycleMinimalCount);
			sequence.AppendCallback(delegate
			{
				if (!_processCanceled)
				{
					base.User.Animator.PlayPunctual(AgentAnim.DanceTrapDance);
					_cycleCount++;
				}
			});
			sequence.AppendCallback(delegate
			{
				if (!_processCanceled)
				{
					_screenarrowLeft.SetActive(value: true);
				}
			});
			sequence.AppendInterval(0.8f);
			sequence.AppendCallback(delegate
			{
				if (!_processCanceled)
				{
					_screenarrowLeft.SetActive(value: false);
				}
			});
			sequence.AppendInterval(0.2f);
			sequence.AppendCallback(delegate
			{
				if (!_processCanceled)
				{
					if (_cycleCount == _cycleMinimalCount && (bool)_selectedCell)
					{
						_screenarrowTop.SetActive(value: true);
					}
					else
					{
						_screenarrowRight.SetActive(value: true);
					}
				}
			});
			if (_cycleCount != _cycleMinimalCount)
			{
				sequence.AppendInterval(0.8f);
				sequence.AppendCallback(delegate
				{
					if (!_processCanceled)
					{
						if (_cycleCount == _cycleMinimalCount && (bool)_selectedCell)
						{
							_screenarrowTop.SetActive(value: false);
						}
						else
						{
							_screenarrowRight.SetActive(value: false);
						}
					}
				});
				sequence.AppendInterval(0.2f);
			}
			else
			{
				sequence.AppendCallback(delegate
				{
					if (!_processCanceled)
					{
						if (_cycleCount == _cycleMinimalCount && (bool)_selectedCell)
						{
							_screenarrowTop.SetActive(value: false);
						}
						else
						{
							_screenarrowRight.SetActive(value: false);
						}
					}
				});
			}
			_processSequence.Append(sequence);
			_processSequence.AppendCallback(delegate
			{
				if (!_processCanceled)
				{
					DisableAllArrows();
					base.User.Statistics.TryAddToStatisticUnitInterval(EAgentStatistics.Fun, _giveFunPercent);
				}
			});
			if ((bool)_selectedCell)
			{
				_selectedCell.IsReserved = true;
				_processSequence.AppendCallback(delegate
				{
					if (!_processCanceled)
					{
						if ((bool)SFXMachineList)
						{
							base.MachineSoundManager.StopAllSFXMachine();
							base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[3]);
						}
						_trapSystem.OpenTrapSequence(humanSexType, bigtrap: true);
						base.User.Animator.PlayPunctual(AgentAnim.DanceTrapFall);
						_animator.SetTrigger(IdleScreenAnimatorTrigger);
					}
				});
				_processSequence.AppendInterval(_looseHumanAnimationClip.length);
				_processSequence.AppendCallback(delegate
				{
					if (!_processCanceled)
					{
						_selectedCell.SetVictim(base.User);
						_endPos = base.User.transform.position - new Vector3(0f, 2.5f, 0f);
						base.User.transform.DOMove(_endPos, 0.25f).SetEase(Ease.InOutSine);
					}
				});
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
					DanceTrap.HumanCaptured?.Invoke(base.User);
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
							base.MachineSoundManager.CallPlaySFXMachine((humanSexType == 0) ? SFXMachineList.SoundsList[1] : SFXMachineList.SoundsList[2]);
						}
					}
				});
				_processSequence.AppendInterval(_winHumanAnimationClip.length);
				_processSequence.AppendCallback(delegate
				{
					_animator.SetTrigger(IdleScreenAnimatorTrigger);
				});
			}
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

		private void DisableAllArrows()
		{
			_screenarrowLeft.SetActive(value: false);
			_screenarrowTop.SetActive(value: false);
			_screenarrowRight.SetActive(value: false);
		}
	}
}
