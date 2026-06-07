using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class AnimationController
	{
		private struct AnimatorCache
		{
			public readonly Animator Animator;

			public readonly AnimationEventObserver EventObserver;

			private readonly int _animControllerNameHash;

			private static readonly Dictionary<int, AnimatorControllerParameter[]> ParameterCache;

			private static readonly Dictionary<int, Dictionary<AnimatorControllerParameterType, Dictionary<int, bool>>> HasParameterCache;

			public IEnumerable<AnimatorControllerParameter> Parameters => null;

			public AnimatorCache(Animator animator, AnimationEventObserver observer)
			{
				Animator = null;
				EventObserver = null;
				_animControllerNameHash = 0;
			}

			public bool HasParameter(AnimatorControllerParameterType type, string name)
			{
				return false;
			}
		}

		private readonly List<Tuple<Animator, AnimatorCache>> _animatorsAndCache;

		private GameObjectX _gox;

		public string AnimationLayerSuffix;

		public string Race;

		private static string _replaceAccessPointForTarget;

		private IEnumerable<AnimatorCache> GetAnimatorCaches(string controllerTransformName = null)
		{
			return null;
		}

		public void RefreshAnimatorList(GameObjectX gox)
		{
		}

		private void SwitchLayer(Animator animator, string layer, string usedByRace)
		{
		}

		private static void EnableLayer(Animator animator, int index)
		{
		}

		private IEnumerable<Tuple<Animator, AnimatorCache>> GetAnimatorsAndCache(string controllerTransformName = null)
		{
			return null;
		}

		public void SwitchLayer(string layer, GameObjectX interactionObject = null, string usedByRace = null, string controllerTransformName = null)
		{
		}

		public int GetLayerIndex(string layer)
		{
			return 0;
		}

		private IEnumerable<AnimationEventObserver> GetEventObservers()
		{
			return null;
		}

		public void AttachAnimEventListener(EventHandler<AnimationEventArgs> eventHandler)
		{
		}

		public void RemoveAnimEventListener(EventHandler<AnimationEventArgs> eventHandler)
		{
		}

		public void AttachSetBoolOnTargetListener(EventHandler<AnimationEventArgs> eventHandler)
		{
		}

		public void RemoveSetBoolOnTargetListener(EventHandler<AnimationEventArgs> eventHandler)
		{
		}

		public void AttachSetBoolOnItemsListener(EventHandler<AnimationEventArgs> eventHandler)
		{
		}

		public void RemoveSetBoolOnItemsListener(EventHandler<AnimationEventArgs> eventHandler)
		{
		}

		public void AttachSetBoolOnSpawnedItemsListener(EventHandler<AnimationEventArgs> eventHandler)
		{
		}

		public void RemoveSetBoolOnAttachedListener(EventHandler<AnimationEventArgs> eventHandler)
		{
		}

		public void AttachSpawnItemListener(EventHandler<SpawnItemEventArgs> eventHandler)
		{
		}

		public void RemoveSpawnItemListener(EventHandler<SpawnItemEventArgs> eventHandler)
		{
		}

		public void AttachSpawnConvItemListener(EventHandler<SpawnConvItemEventArgs> eventHandler)
		{
		}

		public void RemoveSpawnConvItemListener(EventHandler<SpawnConvItemEventArgs> eventHandler)
		{
		}

		public void AttachParticleEventListener(EventHandler eventHandler)
		{
		}

		public void RemoveParticleEventListener(EventHandler eventHandler)
		{
		}

		public virtual void SetBool(string animation, bool value, GameObjectX interactionObject = null, string usedByRace = null, string controllerTransformName = null)
		{
		}

		public virtual bool GetBool(string animation)
		{
			return false;
		}

		public virtual void SetTrigger(string trigger, string controllerTransformName = null)
		{
		}

		public void SetSpeedFactor(float speedFactor)
		{
		}

		public void SetMovementSpeed(float moveSpeed)
		{
		}

		public void SetRotationSpeed(float speed)
		{
		}

		public void SetFloatValue(string paramName, float value)
		{
		}

		public void SetIntValue(string paramName, int value)
		{
		}

		public void SetIdleSubState(float idleSubState)
		{
		}

		public void SetSubIdleStateTransition(float transitionValue)
		{
		}

		public bool IsAnimating(int layer)
		{
			return false;
		}

		public bool IsInState(string state)
		{
			return false;
		}

		public void CrossFadeInFixedTime(string stateNameHash, float transitionDuration)
		{
		}

		public IEnumerable<AnimatorControllerParameter> GetAnimationParameters()
		{
			return null;
		}

		public void FireAnimEvent(string name)
		{
		}

		public void TryReset()
		{
		}

		public void ForceUpdate()
		{
		}

		public void EnsureUpdateMode(AnimatorUpdateMode mode)
		{
		}
	}
}
