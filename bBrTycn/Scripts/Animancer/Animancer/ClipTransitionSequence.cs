using System;
using System.Collections.Generic;
using UnityEngine;

namespace Animancer
{
	[Serializable]
	public class ClipTransitionSequence : ClipTransition, ISerializationCallbackReceiver, ICopyable<ClipTransitionSequence>
	{
		[SerializeField]
		[Tooltip("The other transitions to play in order after the first one.")]
		private ClipTransition[] _Others = Array.Empty<ClipTransition>();

		private Action _OnEnd;

		public ref ClipTransition[] Others => ref _Others;

		public ClipTransition LastTransition
		{
			get
			{
				if (_Others.Length == 0)
				{
					return this;
				}
				return _Others[_Others.Length - 1];
			}
		}

		public override bool IsValid
		{
			get
			{
				if (!base.IsValid)
				{
					return false;
				}
				for (int i = 0; i < _Others.Length; i++)
				{
					if (!_Others[i].IsValid)
					{
						return false;
					}
				}
				return true;
			}
		}

		public override bool IsLooping
		{
			get
			{
				if (_Others.Length == 0)
				{
					return base.IsLooping;
				}
				return LastTransition.IsLooping;
			}
		}

		public override float Length
		{
			get
			{
				float num = base.Length;
				for (int i = 0; i < _Others.Length; i++)
				{
					num += _Others[i].Length;
				}
				return num;
			}
		}

		public override float MaximumDuration
		{
			get
			{
				float num = base.MaximumDuration;
				for (int i = 0; i < _Others.Length; i++)
				{
					num += _Others[i].MaximumDuration;
				}
				return num;
			}
		}

		public override float AverageAngularSpeed
		{
			get
			{
				float averageAngularSpeed = base.AverageAngularSpeed;
				if (_Others.Length == 0)
				{
					return averageAngularSpeed;
				}
				float num = base.MaximumDuration;
				averageAngularSpeed *= num;
				for (int i = 0; i < _Others.Length; i++)
				{
					ClipTransition obj = _Others[i];
					float averageAngularSpeed2 = obj.AverageAngularSpeed;
					float maximumDuration = obj.MaximumDuration;
					averageAngularSpeed += averageAngularSpeed2 * maximumDuration;
					num += maximumDuration;
				}
				return averageAngularSpeed / num;
			}
		}

		public override Vector3 AverageVelocity
		{
			get
			{
				Vector3 averageVelocity = base.AverageVelocity;
				if (_Others.Length == 0)
				{
					return averageVelocity;
				}
				float num = base.MaximumDuration;
				averageVelocity *= num;
				for (int i = 0; i < _Others.Length; i++)
				{
					ClipTransition obj = _Others[i];
					Vector3 averageVelocity2 = obj.AverageVelocity;
					float maximumDuration = obj.MaximumDuration;
					averageVelocity += averageVelocity2 * maximumDuration;
					num += maximumDuration;
				}
				return averageVelocity / num;
			}
		}

		public AnimancerEvent EndEvent
		{
			get
			{
				return LastTransition.Events.EndEvent;
			}
			set
			{
				LastTransition.Events.EndEvent = value;
			}
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			if (_Others.Length <= 1)
			{
				return;
			}
			ClipTransition clipTransition = _Others[0];
			for (int i = 1; i < _Others.Length; i++)
			{
				ClipTransition next = _Others[i];
				clipTransition.Events.OnEnd = delegate
				{
					AnimancerEvent.CurrentState.Layer.Play(next);
				};
				clipTransition = next;
			}
		}

		public override void Apply(AnimancerState state)
		{
			if (_Others.Length != 0)
			{
				if (_OnEnd == null)
				{
					_OnEnd = delegate
					{
						AnimancerEvent.CurrentState.Layer.Play(_Others[0]);
					};
				}
				Action onEnd = base.Events.OnEnd;
				if (onEnd != _OnEnd)
				{
					base.Events.OnEnd = _OnEnd;
					onEnd = (Action)Delegate.Remove(onEnd, _OnEnd);
					_Others[_Others.Length - 1].Events.OnEnd = onEnd;
				}
			}
			base.Apply(state);
		}

		public override void GatherAnimationClips(ICollection<AnimationClip> clips)
		{
			base.GatherAnimationClips(clips);
			for (int i = 0; i < _Others.Length; i++)
			{
				_Others[i].GatherAnimationClips(clips);
			}
		}

		public virtual void CopyFrom(ClipTransitionSequence copyFrom)
		{
			CopyFrom((ClipTransition)copyFrom);
			if (copyFrom == null)
			{
				_Others = Array.Empty<ClipTransition>();
			}
			else
			{
				AnimancerUtilities.CopyExactArray(copyFrom._Others, ref _Others);
			}
		}

		public void AddEvent(float time, bool normalized, Action callback)
		{
			if (normalized)
			{
				time *= Length;
			}
			if (TryAddEvent(this, base.Length, ref time, callback))
			{
				return;
			}
			for (int i = 0; i < _Others.Length - 1; i++)
			{
				ClipTransition obj = _Others[i];
				if (TryAddEvent(obj, obj.Length, ref time, callback))
				{
					return;
				}
			}
			AddEvent(LastTransition, time, callback);
		}

		private static bool TryAddEvent(ClipTransition transition, float length, ref float time, Action callback)
		{
			if (time > length)
			{
				time -= length;
				return false;
			}
			AddEvent(transition, time, callback);
			return true;
		}

		private static void AddEvent(ClipTransition transition, float time, Action callback)
		{
			float num = transition.NormalizedStartTime;
			if (float.IsNaN(num))
			{
				num = AnimancerEvent.Sequence.GetDefaultNormalizedStartTime(num);
			}
			time /= transition.Clip.length * (1f - num);
			time += num;
			transition.Events.Add(time, callback);
		}
	}
}
