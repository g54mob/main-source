using System;
using CTS.BBT;
using CTS.BBT.AI;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class Hypnotic : MachineBase, ITrapMachine, IInteractiveFurniture, IVisibleBBTObject, IBBTObject, IObject, IVisible
	{
		[SerializeField]
		[Space(10f)]
		[BoxGroup("Base Settings")]
		[Range(0f, 1f)]
		private float _giveFunPercent;

		[SerializeField]
		[BoxGroup("Base Settings")]
		private Texture[] _pictures;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Animation Settings")]
		private AnimationClip _processAnimationClip;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		private AnimationClip _processEndAnimationClip;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		private AnimationClip _closeTrapAnimationClip;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Link Component")]
		private Animation _animation;

		[SerializeField]
		[BoxGroup("Link Component")]
		private Renderer _pictureRenderer;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("GameObject Links")]
		private TrapSystem _trapSystem;

		private Sequence _processSequence;

		private WorkerChore _currentChore;

		private bool _processCanceled;

		private Vector3 _endPos;

		private Cell _selectedCell;

		public new static readonly Func<Hypnotic, bool> IsOn = (Hypnotic machine) => machine.MachinePowerState == EMachinePowerState.On;

		public int PictureIndex { get; set; }

		public static event Action<Agent> HumanCaptured;

		protected override void OnMachineSwitchPower(EMachinePowerState value)
		{
			base.OnMachineSwitchPower(value);
			_processCanceled = false;
			if (value != EMachinePowerState.Off)
			{
				_ = 2;
			}
			else
			{
				OnCanceled();
			}
		}

		protected override void OnCanceled()
		{
			_processCanceled = true;
			_animation.Play(_processEndAnimationClip.name);
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
			if (PictureIndex < 0)
			{
				ChangePicture();
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
					customer.Selection.Selectable = false;
				}
			});
			_selectedCell = _trapSystem.HumanCanBeCaptured(base.User);
			if ((bool)_selectedCell)
			{
				_selectedCell.IsReserved = true;
				byte humanSexType = ((!base.User.HasDeepVoice) ? ((byte)1) : ((byte)0));
				_processSequence.AppendInterval(1f);
				_processSequence.AppendCallback(delegate
				{
					if (!_processCanceled)
					{
						if ((bool)SFXMachineList)
						{
							base.MachineSoundManager.StopAllSFXMachine();
							base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[4]);
						}
						base.User.Animator.PlayPunctualInstantly(AgentAnim.HypnoticHumanHypnotized);
						_animation.Play(_processAnimationClip.name);
						base.User.Statistics.TryAddToStatisticUnitInterval(EAgentStatistics.Fun, _giveFunPercent);
					}
				});
				_processSequence.AppendInterval(1f);
				_processSequence.AppendCallback(delegate
				{
					if (!_processCanceled)
					{
						_trapSystem.OpenTrapSequence(humanSexType);
						base.User.Animator.PlayPunctual(AgentAnim.TrapFall02);
						if ((bool)SFXMachineList)
						{
							base.MachineSoundManager.CallPlaySFXMachine((humanSexType == 0) ? SFXMachineList.SoundsList[2] : SFXMachineList.SoundsList[3]);
							base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[0]);
						}
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
						base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[1]);
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
					_animation.Play(_processEndAnimationClip.name);
					base.User.ContextualFSM.SetStateStuck();
					base.User.ActionPlayer.ForceStopAll();
					_selectedCell.IsReserved = false;
					Hypnotic.HumanCaptured?.Invoke(base.User);
					InvokeVictimCaptured(base.User);
				});
			}
			else
			{
				_processSequence.AppendInterval(2f);
				_processSequence.AppendCallback(delegate
				{
					if (!_processCanceled)
					{
						base.User.Statistics.TryAddToStatisticUnitInterval(EAgentStatistics.Fun, _giveFunPercent);
					}
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

		public void ResetSave()
		{
			ChangePicture(PictureIndex);
		}

		public void ChangePicture(int index = -1)
		{
			PictureIndex = ((index != -1) ? index : UnityEngine.Random.Range(0, _pictures.Length));
			_pictureRenderer.material.SetTexture("_Picture", _pictures[PictureIndex]);
		}
	}
}
