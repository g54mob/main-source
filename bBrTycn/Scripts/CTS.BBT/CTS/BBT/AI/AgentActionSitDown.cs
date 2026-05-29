using System;
using System.Collections;
using CTS.AI;
using CTS.Core;
using DG.Tweening;
using UnityEngine;

namespace CTS.BBT.AI
{
	public sealed class AgentActionSitDown : AgentAction<Agent>
	{
		private SoftReference<Seat> _seat;

		private ESitType _sitType;

		private MoveTarget _seatTarget;

		public Seat Seat
		{
			get
			{
				return _seat.Get();
			}
			set
			{
				_seat = SoftReference.Create(value);
			}
		}

		public static event Action<Agent> SittingDown;

		public AgentActionSitDown(SoftReference<Seat> seat)
		{
			_seat = seat;
			base.Name = "Sit Down";
		}

		public AgentActionSitDown(Seat seat)
			: this(SoftReference.Create(seat))
		{
		}

		public override bool CanBePerformed(Agent p_agentRef)
		{
			Seat seat = Seat;
			if (!seat)
			{
				return false;
			}
			if (!seat.CanBeUsed(p_agentRef))
			{
				return false;
			}
			if (p_agentRef.FurnitureAssignment.CurrentSeat == seat)
			{
				return false;
			}
			return p_agentRef.ContextualFSM.CurrentStateEquals<ContextualStateNormal>();
		}

		public override void OnStart()
		{
			SyncWithFurniture((Seat)_seat);
		}

		public override IEnumerator WaitForRoutine()
		{
			if (Seat.ContextActorData.TryGetAvailableInteractionTarget(EInteractionKey.RegularUsage, base.ActionAgent.transform.position, out _seatTarget))
			{
				Vector3 vector = Seat.transform.position - _seatTarget.Position;
				if (Vector3.SignedAngle(Seat.transform.forward, vector.normalized, Vector3.up) < 0f)
				{
					_sitType = ESitType.Right;
				}
				else
				{
					_sitType = ESitType.Left;
				}
			}
			if (_seatTarget == null)
			{
				if (base.ActionAgent is Customer customer)
				{
					customer.ReleaseSeat();
				}
				CancelAction("Couldn't find a seat target", playBlockedAction: true);
			}
			else
			{
				yield return MoveToTarget(_seatTarget);
			}
		}

		public override IEnumerator ActionRoutine()
		{
			Seat seat = Seat;
			base.ActionAgent.transform.DORotateQuaternion(_seatTarget.Rotation, 0.1f);
			yield return base.ActionAgent.transform.DOMove(_seatTarget.Position, 0.1f).WaitForCompletion();
			AgentActionSitDown.SittingDown?.Invoke(base.ActionAgent);
			if (seat.IsLow)
			{
				base.ActionAgent.Animator.SetIdle(AgentAnim.SitLowIdle);
				yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.SitLowDown);
			}
			else
			{
				base.ActionAgent.Animator.SetIdle(AgentAnim.SitHighIdle);
				switch (_sitType)
				{
				case ESitType.Right:
					yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.SitHighRDown);
					break;
				case ESitType.Left:
					yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.SitHighLDown);
					break;
				case ESitType.Back:
					yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.SitHighBDown);
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
			base.ActionAgent.FurnitureAssignment.AssignSeat(seat);
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
			base.ActionAgent.transform.DOKill();
		}
	}
}
