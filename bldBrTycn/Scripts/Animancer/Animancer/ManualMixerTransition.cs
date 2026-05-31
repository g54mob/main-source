using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Animancer
{
	[Serializable]
	public class ManualMixerTransition : ManualMixerTransition<ManualMixerState>, ManualMixerState.ITransition, ITransition<ManualMixerState>, ITransition, IHasKey, IPolymorphic, ICopyable<ManualMixerTransition>
	{
		public override ManualMixerState CreateState()
		{
			base.State = new ManualMixerState();
			InitializeState();
			return base.State;
		}

		public virtual void CopyFrom(ManualMixerTransition copyFrom)
		{
			CopyFrom((ManualMixerTransition<ManualMixerState>)copyFrom);
		}
	}
	[Serializable]
	public abstract class ManualMixerTransition<TMixer> : AnimancerTransition<TMixer>, IMotion, IAnimationClipCollection, ICopyable<ManualMixerTransition<TMixer>> where TMixer : ManualMixerState
	{
		[SerializeField]
		[Tooltip("How fast the animation will play, e.g:\n• 0x = paused\n• 1x = normal speed\n• -2x = double speed backwards\n• Disabled = keep previous speed\n• Middle Click = reset to default value")]
		private float _Speed = 1f;

		[SerializeField]
		[FormerlySerializedAs("_Clips")]
		[FormerlySerializedAs("_States")]
		private UnityEngine.Object[] _Animations;

		public const string AnimationsField = "_Animations";

		[SerializeField]
		private float[] _Speeds;

		public const string SpeedsField = "_Speeds";

		[SerializeField]
		private bool[] _SynchronizeChildren;

		public const string SynchronizeChildrenField = "_SynchronizeChildren";

		public override float Speed
		{
			get
			{
				return _Speed;
			}
			set
			{
				_Speed = value;
			}
		}

		public ref UnityEngine.Object[] Animations => ref _Animations;

		public ref float[] Speeds => ref _Speeds;

		public bool HasSpeeds
		{
			get
			{
				if (_Speeds != null)
				{
					return _Speeds.Length >= _Animations.Length;
				}
				return false;
			}
		}

		public ref bool[] SynchronizeChildren => ref _SynchronizeChildren;

		public override bool IsLooping
		{
			get
			{
				for (int num = _Animations.Length - 1; num >= 0; num--)
				{
					if (AnimancerUtilities.TryGetIsLooping(_Animations[num], out var isLooping) && isLooping)
					{
						return true;
					}
				}
				return false;
			}
		}

		public override float MaximumDuration
		{
			get
			{
				if (_Animations == null)
				{
					return 0f;
				}
				float num = 0f;
				bool hasSpeeds = HasSpeeds;
				for (int num2 = _Animations.Length - 1; num2 >= 0; num2--)
				{
					if (AnimancerUtilities.TryGetLength(_Animations[num2], out var length))
					{
						if (hasSpeeds)
						{
							length *= _Speeds[num2];
						}
						if (num < length)
						{
							num = length;
						}
					}
				}
				return num;
			}
		}

		public virtual float AverageAngularSpeed
		{
			get
			{
				if (_Animations == null)
				{
					return 0f;
				}
				float num = 0f;
				bool hasSpeeds = HasSpeeds;
				int num2 = 0;
				for (int num3 = _Animations.Length - 1; num3 >= 0; num3--)
				{
					if (AnimancerUtilities.TryGetAverageAngularSpeed(_Animations[num3], out var averageAngularSpeed))
					{
						if (hasSpeeds)
						{
							averageAngularSpeed *= _Speeds[num3];
						}
						num += averageAngularSpeed;
						num2++;
					}
				}
				return num / (float)num2;
			}
		}

		public virtual Vector3 AverageVelocity
		{
			get
			{
				if (_Animations == null)
				{
					return default(Vector3);
				}
				Vector3 vector = default(Vector3);
				bool hasSpeeds = HasSpeeds;
				int num = 0;
				for (int num2 = _Animations.Length - 1; num2 >= 0; num2--)
				{
					if (AnimancerUtilities.TryGetAverageVelocity(_Animations[num2], out var averageVelocity))
					{
						if (hasSpeeds)
						{
							averageVelocity *= _Speeds[num2];
						}
						vector += averageVelocity;
						num++;
					}
				}
				return vector / num;
			}
		}

		public override bool IsValid
		{
			get
			{
				if (_Animations == null || _Animations.Length == 0)
				{
					return false;
				}
				for (int num = _Animations.Length - 1; num >= 0; num--)
				{
					if (_Animations[num] == null)
					{
						return false;
					}
				}
				return true;
			}
		}

		public virtual void InitializeState()
		{
			TMixer state = base.State;
			int childCount = state.ChildCount;
			bool synchronizeNewChildren = ManualMixerState.SynchronizeNewChildren;
			try
			{
				ManualMixerState.SynchronizeNewChildren = false;
				object[] animations = _Animations;
				state.AddRange(animations);
			}
			finally
			{
				ManualMixerState.SynchronizeNewChildren = synchronizeNewChildren;
			}
			state.InitializeSynchronizedChildren(_SynchronizeChildren);
			if (_Speeds != null)
			{
				for (int num = Math.Min(_Animations.Length, _Speeds.Length) - 1; num >= 0; num--)
				{
					state.GetChild(childCount + num).Speed = _Speeds[num];
				}
			}
		}

		public override void Apply(AnimancerState state)
		{
			base.Apply(state);
			if (!float.IsNaN(_Speed))
			{
				state.Speed = _Speed;
			}
			for (int i = 0; i < _Animations.Length; i++)
			{
				if (_Animations[i] is ITransition transition)
				{
					transition.Apply(state.GetChild(i));
				}
			}
		}

		void IAnimationClipCollection.GatherAnimationClips(ICollection<AnimationClip> clips)
		{
			clips.GatherFromSource(_Animations);
		}

		public virtual void CopyFrom(ManualMixerTransition<TMixer> copyFrom)
		{
			CopyFrom((AnimancerTransition<TMixer>)copyFrom);
			if (copyFrom == null)
			{
				_Speed = 1f;
				_Animations = null;
				_Speeds = null;
				_SynchronizeChildren = null;
			}
			else
			{
				_Speed = copyFrom._Speed;
				AnimancerUtilities.CopyExactArray(copyFrom._Animations, ref _Animations);
				AnimancerUtilities.CopyExactArray(copyFrom._Speeds, ref _Speeds);
				AnimancerUtilities.CopyExactArray(copyFrom._SynchronizeChildren, ref _SynchronizeChildren);
			}
		}
	}
}
