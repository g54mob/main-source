using System;
using UnityEngine;

namespace Animancer
{
	[Serializable]
	public abstract class AnimancerTransition<TState> : ITransition<TState>, ITransition, IHasKey, IPolymorphic, ITransitionDetailed, ITransitionWithEvents, IHasEvents, ICopyable<AnimancerTransition<TState>> where TState : AnimancerState
	{
		[SerializeField]
		[Tooltip("The amount of time the transition will take, e.g:\n• 0s = Instant\n• 0.25s = quarter of a second (Default)\n• 0.25x = quarter of the animation length\n• x = Normalized, s = Seconds, f = Frame\n• Middle Click = reset to default value")]
		private float _FadeDuration = AnimancerPlayable.DefaultFadeDuration;

		[SerializeField]
		[Tooltip("Events which will be triggered as the animation plays")]
		private AnimancerEvent.Sequence.Serializable _Events;

		private TState _State;

		public float FadeDuration
		{
			get
			{
				return _FadeDuration;
			}
			set
			{
				if (value < 0f)
				{
					throw new ArgumentOutOfRangeException("value", "FadeDuration must not be negative");
				}
				_FadeDuration = value;
			}
		}

		public virtual bool IsLooping => false;

		public virtual float NormalizedStartTime
		{
			get
			{
				return float.NaN;
			}
			set
			{
			}
		}

		public virtual float Speed
		{
			get
			{
				return 1f;
			}
			set
			{
			}
		}

		public abstract float MaximumDuration { get; }

		public AnimancerEvent.Sequence Events
		{
			get
			{
				if (_Events == null)
				{
					_Events = new AnimancerEvent.Sequence.Serializable();
				}
				return _Events.Events;
			}
		}

		public ref AnimancerEvent.Sequence.Serializable SerializedEvents => ref _Events;

		public AnimancerState BaseState { get; private set; }

		public TState State
		{
			get
			{
				if (_State == null)
				{
					_State = (TState)BaseState;
				}
				return _State;
			}
			protected set
			{
				BaseState = (_State = value);
			}
		}

		public virtual bool IsValid => true;

		public virtual object Key => this;

		public virtual FadeMode FadeMode => FadeMode.FixedSpeed;

		public virtual UnityEngine.Object MainObject { get; }

		public virtual string Name
		{
			get
			{
				UnityEngine.Object mainObject = MainObject;
				if (!(mainObject != null))
				{
					return null;
				}
				return mainObject.name;
			}
		}

		public abstract TState CreateState();

		AnimancerState ITransition.CreateState()
		{
			return CreateState();
		}

		public virtual void Apply(AnimancerState state)
		{
			state.Events = _Events;
			BaseState = state;
			if (_State != state)
			{
				_State = null;
			}
		}

		public override string ToString()
		{
			string fullName = GetType().FullName;
			string name = Name;
			if (name != null)
			{
				return name + " (" + fullName + ")";
			}
			return fullName;
		}

		public virtual void CopyFrom(AnimancerTransition<TState> copyFrom)
		{
			if (copyFrom == null)
			{
				_FadeDuration = AnimancerPlayable.DefaultFadeDuration;
				_Events = null;
			}
			else
			{
				_FadeDuration = copyFrom._FadeDuration;
				_Events = copyFrom._Events.Clone();
			}
		}

		public static void ApplyDetails(AnimancerState state, float speed, float normalizedStartTime)
		{
			if (!float.IsNaN(speed))
			{
				state.Speed = speed;
			}
			if (!float.IsNaN(normalizedStartTime))
			{
				state.NormalizedTime = normalizedStartTime;
			}
			else if (state.Weight == 0f)
			{
				state.NormalizedTime = AnimancerEvent.Sequence.GetDefaultNormalizedStartTime(speed);
			}
		}
	}
}
