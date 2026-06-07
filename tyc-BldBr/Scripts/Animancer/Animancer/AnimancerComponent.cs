using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace Animancer
{
	[AddComponentMenu("Animancer/Animancer Component")]
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer/AnimancerComponent")]
	[DefaultExecutionOrder(-5000)]
	public class AnimancerComponent : MonoBehaviour, IAnimancerComponent, IEnumerator, IAnimationClipSource, IAnimationClipCollection
	{
		public enum DisableAction
		{
			Stop = 0,
			Pause = 1,
			Continue = 2,
			Reset = 3,
			Destroy = 4
		}

		public const int DefaultExecutionOrder = -5000;

		[SerializeField]
		[Tooltip("The Animator component which this script controls")]
		private Animator _Animator;

		private AnimancerPlayable _Playable;

		[SerializeField]
		[Tooltip("Determines what happens when this component is disabled or its GameObject becomes inactive (i.e. in OnDisable):\n• Stop all animations\n• Pause all animations\n• Continue playing\n• Reset to the original values\n• Destroy all layers and states")]
		private DisableAction _ActionOnDisable;

		public Animator Animator
		{
			get
			{
				return _Animator;
			}
			set
			{
				_Animator = value;
				if (IsPlayableInitialized)
				{
					_Playable.DestroyOutput();
					_Playable.CreateOutput(value, this);
				}
			}
		}

		public AnimancerPlayable Playable
		{
			get
			{
				InitializePlayable();
				return _Playable;
			}
		}

		public bool IsPlayableInitialized
		{
			get
			{
				if (_Playable != null)
				{
					return _Playable.IsValid;
				}
				return false;
			}
		}

		public AnimancerPlayable.StateDictionary States => Playable.States;

		public AnimancerPlayable.LayerList Layers => Playable.Layers;

		public ref DisableAction ActionOnDisable => ref _ActionOnDisable;

		bool IAnimancerComponent.ResetOnDisable => _ActionOnDisable == DisableAction.Reset;

		public AnimatorUpdateMode UpdateMode
		{
			get
			{
				return _Animator.updateMode;
			}
			set
			{
				_Animator.updateMode = value;
				if (IsPlayableInitialized)
				{
					_Playable.UpdateMode = ((value != AnimatorUpdateMode.UnscaledTime) ? DirectorUpdateMode.GameTime : DirectorUpdateMode.UnscaledGameTime);
				}
			}
		}

		object IEnumerator.Current => null;

		bool IAnimancerComponent.enabled => base.enabled;

		GameObject IAnimancerComponent.gameObject => base.gameObject;

		public static implicit operator AnimancerPlayable(AnimancerComponent animancer)
		{
			return animancer.Playable;
		}

		public static implicit operator AnimancerLayer(AnimancerComponent animancer)
		{
			return animancer.Playable.Layers[0];
		}

		protected virtual void OnEnable()
		{
			if (IsPlayableInitialized)
			{
				_Playable.UnpauseGraph();
			}
		}

		protected virtual void OnDisable()
		{
			if (IsPlayableInitialized)
			{
				switch (_ActionOnDisable)
				{
				case DisableAction.Stop:
					Stop();
					_Playable.PauseGraph();
					break;
				case DisableAction.Pause:
					_Playable.PauseGraph();
					break;
				case DisableAction.Reset:
					Stop();
					_Animator.Rebind();
					_Playable.PauseGraph();
					break;
				case DisableAction.Destroy:
					_Playable.DestroyGraph();
					_Playable = null;
					break;
				default:
					throw new ArgumentOutOfRangeException("ActionOnDisable");
				case DisableAction.Continue:
					break;
				}
			}
		}

		public void InitializePlayable()
		{
			if (!IsPlayableInitialized)
			{
				TryGetAnimator();
				_Playable = AnimancerPlayable.Create();
				_Playable.CreateOutput(_Animator, this);
				OnInitializePlayable();
			}
		}

		public void InitializePlayable(AnimancerPlayable playable)
		{
			if (IsPlayableInitialized)
			{
				throw new InvalidOperationException("The AnimancerPlayable is already initialized. Either call this method before anything else uses it or call animancerComponent.Playable.DestroyGraph before re-initializing it.");
			}
			TryGetAnimator();
			_Playable = playable;
			_Playable.CreateOutput(_Animator, this);
			OnInitializePlayable();
		}

		protected virtual void OnInitializePlayable()
		{
		}

		public bool TryGetAnimator()
		{
			if (!(_Animator != null))
			{
				return TryGetComponent<Animator>(out _Animator);
			}
			return true;
		}

		protected virtual void OnDestroy()
		{
			if (IsPlayableInitialized)
			{
				_Playable.DestroyGraph();
				_Playable = null;
			}
		}

		public virtual object GetKey(AnimationClip clip)
		{
			return clip;
		}

		public AnimancerState Play(AnimationClip clip)
		{
			return Playable.Play(States.GetOrCreate(clip));
		}

		public AnimancerState Play(AnimancerState state)
		{
			return Playable.Play(state);
		}

		public AnimancerState Play(AnimationClip clip, float fadeDuration, FadeMode mode = FadeMode.FixedSpeed)
		{
			return Playable.Play(States.GetOrCreate(clip), fadeDuration, mode);
		}

		public AnimancerState Play(AnimancerState state, float fadeDuration, FadeMode mode = FadeMode.FixedSpeed)
		{
			return Playable.Play(state, fadeDuration, mode);
		}

		public AnimancerState Play(ITransition transition)
		{
			return Playable.Play(transition);
		}

		public AnimancerState Play(ITransition transition, float fadeDuration, FadeMode mode = FadeMode.FixedSpeed)
		{
			return Playable.Play(transition, fadeDuration, mode);
		}

		public AnimancerState TryPlay(object key)
		{
			return Playable.TryPlay(key);
		}

		public AnimancerState TryPlay(object key, float fadeDuration, FadeMode mode = FadeMode.FixedSpeed)
		{
			return Playable.TryPlay(key, fadeDuration, mode);
		}

		public AnimancerState Stop(AnimationClip clip)
		{
			return Stop(GetKey(clip));
		}

		public AnimancerState Stop(IHasKey hasKey)
		{
			return _Playable?.Stop(hasKey);
		}

		public AnimancerState Stop(object key)
		{
			return _Playable?.Stop(key);
		}

		public void Stop()
		{
			if (IsPlayableInitialized)
			{
				_Playable.Stop();
			}
		}

		public bool IsPlaying(AnimationClip clip)
		{
			return IsPlaying(GetKey(clip));
		}

		public bool IsPlaying(IHasKey hasKey)
		{
			if (IsPlayableInitialized)
			{
				return _Playable.IsPlaying(hasKey);
			}
			return false;
		}

		public bool IsPlaying(object key)
		{
			if (IsPlayableInitialized)
			{
				return _Playable.IsPlaying(key);
			}
			return false;
		}

		public bool IsPlaying()
		{
			if (IsPlayableInitialized)
			{
				return _Playable.IsPlaying();
			}
			return false;
		}

		public bool IsPlayingClip(AnimationClip clip)
		{
			if (IsPlayableInitialized)
			{
				return _Playable.IsPlayingClip(clip);
			}
			return false;
		}

		public void Evaluate()
		{
			Playable.Evaluate();
		}

		public void Evaluate(float deltaTime)
		{
			Playable.Evaluate(deltaTime);
		}

		bool IEnumerator.MoveNext()
		{
			if (!IsPlayableInitialized)
			{
				return false;
			}
			return ((IEnumerator)_Playable).MoveNext();
		}

		void IEnumerator.Reset()
		{
		}

		public void GetAnimationClips(List<AnimationClip> clips)
		{
			HashSet<AnimationClip> hashSet = ObjectPool.AcquireSet<AnimationClip>();
			hashSet.UnionWith(clips);
			GatherAnimationClips(hashSet);
			clips.Clear();
			clips.AddRange(hashSet);
			ObjectPool.Release(hashSet);
		}

		public virtual void GatherAnimationClips(ICollection<AnimationClip> clips)
		{
			if (IsPlayableInitialized)
			{
				_Playable.GatherAnimationClips(clips);
			}
		}
	}
}
