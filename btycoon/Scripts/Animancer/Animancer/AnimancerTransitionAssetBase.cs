using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Animancer
{
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer/AnimancerTransitionAssetBase")]
	public abstract class AnimancerTransitionAssetBase : ScriptableObject, ITransition, IHasKey, IPolymorphic, IWrapper, IAnimationClipSource
	{
		[Serializable]
		public class UnShared : UnShared<AnimancerTransitionAssetBase>
		{
		}

		[Serializable]
		public class UnShared<TAsset> : ITransition, IHasKey, IPolymorphic, ITransitionWithEvents, IHasEvents, IWrapper where TAsset : AnimancerTransitionAssetBase
		{
			[SerializeField]
			private TAsset _Asset;

			private AnimancerState _BaseState;

			private AnimancerEvent.Sequence _Events;

			public TAsset Asset
			{
				get
				{
					return _Asset;
				}
				set
				{
					_Asset = value;
					BaseState = null;
					ClearCachedEvents();
				}
			}

			object IWrapper.WrappedObject => _Asset;

			public ITransition BaseTransition => _Asset.GetTransition();

			public virtual bool IsValid => _Asset.IsValid();

			public bool HasAsset => _Asset != null;

			public AnimancerState BaseState
			{
				get
				{
					return _BaseState;
				}
				protected set
				{
					_BaseState = value;
					OnSetBaseState();
				}
			}

			public virtual AnimancerEvent.Sequence Events
			{
				get
				{
					if (_Events == null)
					{
						_Events = new AnimancerEvent.Sequence(SerializedEvents.GetEventsOptional());
					}
					return _Events;
				}
			}

			public virtual ref AnimancerEvent.Sequence.Serializable SerializedEvents => ref ((ITransitionWithEvents)_Asset.GetTransition()).SerializedEvents;

			public virtual object Key => _Asset.Key;

			public virtual float FadeDuration => _Asset.FadeDuration;

			public virtual FadeMode FadeMode => _Asset.FadeMode;

			[Conditional("UNITY_ASSERTIONS")]
			private void AssertAsset()
			{
				if (_Asset == null)
				{
					UnityEngine.Debug.LogError(GetType().Name + ".Asset is not assigned. HasAsset can be used to check without triggering this error.");
				}
			}

			protected virtual void OnSetBaseState()
			{
			}

			public void ClearCachedEvents()
			{
				_Events = null;
			}

			public virtual void Apply(AnimancerState state)
			{
				BaseState = state;
				_Asset.Apply(state);
				if (_Events == null)
				{
					_Events = SerializedEvents.GetEventsOptional();
					if (_Events == null)
					{
						return;
					}
					_Events = new AnimancerEvent.Sequence(_Events);
				}
				state.Events = _Events;
			}

			AnimancerState ITransition.CreateState()
			{
				return BaseState = _Asset.CreateState();
			}
		}

		[Serializable]
		public class UnShared<TAsset, TTransition, TState> : UnShared<TAsset>, ITransition<TState>, ITransition, IHasKey, IPolymorphic where TAsset : AnimancerTransitionAsset<TTransition> where TTransition : ITransition<TState>, IHasEvents where TState : AnimancerState
		{
			private TState _State;

			public TTransition Transition
			{
				get
				{
					return base.Asset.Transition;
				}
				set
				{
					base.Asset.Transition = value;
				}
			}

			public TState State
			{
				get
				{
					if (_State == null)
					{
						_State = (TState)base.BaseState;
					}
					return _State;
				}
				protected set
				{
					base.BaseState = (_State = value);
				}
			}

			public override ref AnimancerEvent.Sequence.Serializable SerializedEvents => ref base.Asset.Transition.SerializedEvents;

			protected override void OnSetBaseState()
			{
				base.OnSetBaseState();
				if (_State != base.BaseState)
				{
					_State = null;
				}
			}

			public virtual TState CreateState()
			{
				return State = (TState)base.Asset.CreateState();
			}
		}

		object IWrapper.WrappedObject => GetTransition();

		public virtual bool IsValid => GetTransition().IsValid();

		public virtual float FadeDuration => GetTransition().FadeDuration;

		public virtual object Key => GetTransition().Key;

		public virtual FadeMode FadeMode => GetTransition().FadeMode;

		public abstract ITransition GetTransition();

		public virtual AnimancerState CreateState()
		{
			return GetTransition().CreateState();
		}

		public virtual void Apply(AnimancerState state)
		{
			GetTransition().Apply(state);
		}

		public virtual void GetAnimationClips(List<AnimationClip> clips)
		{
			clips.GatherFromSource(GetTransition());
		}
	}
}
