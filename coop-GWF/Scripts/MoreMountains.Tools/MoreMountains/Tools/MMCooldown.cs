using System;
using UnityEngine;

namespace MoreMountains.Tools
{
	[Serializable]
	public class MMCooldown
	{
		public enum CooldownStates
		{
			Idle = 0,
			Consuming = 1,
			Stopped = 2,
			Refilling = 3
		}

		public delegate void OnStateChangeDelegate(CooldownStates newState);

		public bool Unlimited;

		public float ConsumptionDuration = 2f;

		public float PauseOnEmptyDuration = 1f;

		public float RefillDuration = 1f;

		public bool CanInterruptRefill = true;

		[MMReadOnly]
		public CooldownStates CooldownState;

		[MMReadOnly]
		public float CurrentDurationLeft;

		public OnStateChangeDelegate OnStateChange;

		protected float _emptyReachedTimestamp;

		public float Progress
		{
			get
			{
				if (Unlimited)
				{
					return 1f;
				}
				if (CooldownState == CooldownStates.Consuming || CooldownState == CooldownStates.Stopped)
				{
					return 0f;
				}
				if (CooldownState == CooldownStates.Refilling)
				{
					return CurrentDurationLeft / RefillDuration;
				}
				return 1f;
			}
		}

		public virtual void Initialization()
		{
			CurrentDurationLeft = ConsumptionDuration;
			ChangeState(CooldownStates.Idle);
			_emptyReachedTimestamp = 0f;
		}

		public virtual void Start()
		{
			if (Ready())
			{
				ChangeState(CooldownStates.Consuming);
			}
		}

		public virtual bool Ready()
		{
			if (Unlimited)
			{
				return true;
			}
			if (CooldownState == CooldownStates.Idle)
			{
				return true;
			}
			if (CooldownState == CooldownStates.Refilling && CanInterruptRefill)
			{
				return true;
			}
			return false;
		}

		public virtual void Stop()
		{
			if (CooldownState == CooldownStates.Consuming)
			{
				ChangeState(CooldownStates.Stopped);
			}
		}

		public virtual void Update()
		{
			if (Unlimited)
			{
				return;
			}
			switch (CooldownState)
			{
			case CooldownStates.Consuming:
				CurrentDurationLeft -= Time.deltaTime;
				if (CurrentDurationLeft <= 0f)
				{
					CurrentDurationLeft = 0f;
					_emptyReachedTimestamp = Time.time;
					ChangeState(CooldownStates.Stopped);
				}
				break;
			case CooldownStates.Stopped:
				if (Time.time - _emptyReachedTimestamp >= PauseOnEmptyDuration)
				{
					ChangeState(CooldownStates.Refilling);
				}
				break;
			case CooldownStates.Refilling:
				CurrentDurationLeft += RefillDuration * Time.deltaTime / RefillDuration;
				if (CurrentDurationLeft >= RefillDuration)
				{
					CurrentDurationLeft = ConsumptionDuration;
					ChangeState(CooldownStates.Idle);
				}
				break;
			case CooldownStates.Idle:
				break;
			}
		}

		protected virtual void ChangeState(CooldownStates newState)
		{
			CooldownState = newState;
			OnStateChange?.Invoke(newState);
		}
	}
}
