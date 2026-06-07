using System;
using Assets.Scripts.Flight.Combat.Events;
using Assets.Scripts.Flight.Combat.Teams.Events;
using Jundroo.Common.Pool;
using UnityEngine;

namespace Assets.Scripts.Flight.Combat
{
	public abstract class Target : ITarget
	{
		private ushort _teamId;

		public Vector3 AngularVelocity => Vector3.zero;

		public abstract bool IsDead { get; }

		public float MaxVisibleRange { get; set; }

		public string Name { get; set; }

		public FlightScenePlayer Player { get; protected set; }

		public abstract Vector3 Position { get; }

		public virtual bool SupportsOcclusion => true;

		public abstract TargetType TargetType { get; }

		public ushort TeamId
		{
			get
			{
				return _teamId;
			}
			set
			{
				if (_teamId != value)
				{
					ushort teamId = _teamId;
					_teamId = value;
					this.TeamChanged?.Invoke(this, new TeamChangedEventArgs(teamId, value));
				}
			}
		}

		public abstract Vector3 Velocity { get; }

		public bool Visible { get; set; } = true;

		public event EventHandler<TargetLockEventArgs> Locked;

		public event EventHandler<TeamChangedEventArgs> TeamChanged;

		public event Action<Target> Unloaded;

		public Target(ushort teamId)
		{
			_teamId = teamId;
			MaxVisibleRange = 0f;
		}

		public virtual void Alert(bool locked, ITargetLockSource source, TrackedTarget trackedTarget)
		{
			using PooledObject<TargetLockEventArgs> pooledObject = TargetLockEventArgs.GetFromPool(trackedTarget, locked, source);
			this.Locked?.Invoke(this, pooledObject.Value);
		}

		public virtual float GetBreakLockProbability(SignatureType signatureType)
		{
			return 0f;
		}

		public virtual float GetEvadeLockProbability(SignatureType signatureType)
		{
			return 0f;
		}

		public virtual float GetSignature(SignatureType signatureType)
		{
			return 0f;
		}

		public virtual void OnRegistered()
		{
		}

		public virtual void OnUnregistered()
		{
		}

		protected void RaiseUnloadedEvent()
		{
			this.Unloaded?.Invoke(this);
		}
	}
}
