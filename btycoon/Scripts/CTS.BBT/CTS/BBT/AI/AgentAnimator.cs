using System.Collections;
using System.Collections.Generic;
using Animancer;
using CTS.Core;
using CTS.Utilities;
using UnityEngine;

namespace CTS.BBT.AI
{
	public class AgentAnimator : CTSBehaviour
	{
		[Inject(false)]
		private Agent _agentRef;

		[Inject(false)]
		private AnimancerComponent _animatorComponent;

		[SerializeField]
		private float _walkSpeedMultiplier = 5f;

		[SerializeField]
		private AnimationStateCollection _baseAnimations;

		[SerializeField]
		private SerializableDictionary<string, AnimationOverride> _overrides;

		[SerializeField]
		private bool _debug;

		private List<AnimationOverride> _activeOverrides = new List<AnimationOverride>();

		public bool _locked;

		private float _currentSpeed;

		private AnimKey _currentIdleKey;

		private ITransition _currentIdle;

		private ITransition _currentTransition;

		private AnimancerLayer _fullBodyLayer;

		private AnimancerLayer _upperBodyLayer;

		private Dictionary<int, HashSet<LinearMixerState>> _mixers = new Dictionary<int, HashSet<LinearMixerState>>();

		private static readonly int ASpeed = Animator.StringToHash("Speed");

		private static readonly Resource<AvatarMask> upperBodyMask = new Resource<AvatarMask>("Animation/AvatarMasks/UpperBody");

		private bool _paused;

		[field: Inject(false)]
		public AgentAnimEvents Events { get; }

		public AnimKey CurrentIdle => _currentIdleKey;

		public float Speed
		{
			get
			{
				return _animatorComponent.Playable.Speed;
			}
			set
			{
				_animatorComponent.Playable.Speed = value;
			}
		}

		public void Lock()
		{
			_locked = true;
		}

		public void Unlock()
		{
			_locked = false;
		}

		protected override void OnAwake()
		{
			base.OnAwake();
			_fullBodyLayer = _animatorComponent.Layers[0];
			_upperBodyLayer = _animatorComponent.Layers[1];
			_upperBodyLayer.SetMask(upperBodyMask);
			CreateMixersForCollection(_baseAnimations);
			if (_baseAnimations.TryGet(AgentAnim.Idle, out var transition))
			{
				_currentIdle = transition.GetTransition();
				_currentIdleKey = AgentAnim.Idle;
			}
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			ReturnToIdle();
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			foreach (var (overrideKey, _) in _overrides)
			{
				DisableOverride(overrideKey);
			}
		}

		private void Update()
		{
			UpdateSpeed();
		}

		public void SetUpdateMode(AnimatorUpdateMode mode)
		{
			_animatorComponent.UpdateMode = mode;
		}

		private void UpdateSpeed()
		{
			float magnitude = _agentRef.Movement.Velocity.magnitude;
			_currentSpeed = Mathf.Lerp(_currentSpeed, magnitude, Time.deltaTime * _walkSpeedMultiplier);
			if (!_mixers.ContainsKey(ASpeed))
			{
				return;
			}
			foreach (LinearMixerState item in _mixers[ASpeed])
			{
				item.Parameter = _currentSpeed;
			}
		}

		private bool TryGetOverride(string overrideKey, out AnimationOverride collection)
		{
			if (_overrides.TryGetValue(overrideKey, out collection))
			{
				return true;
			}
			return false;
		}

		public void EnableOverride(string overrideKey)
		{
			if (TryGetOverride(overrideKey, out var collection) && !_activeOverrides.Contains(collection))
			{
				int i;
				for (i = 0; i < _activeOverrides.Count && collection.Priority <= _activeOverrides[i].Priority; i++)
				{
				}
				_activeOverrides.Insert(i, collection);
				CreateMixersForCollection(collection.AnimationCollection);
				SetIdle(_currentIdleKey);
			}
		}

		public void DisableOverride(string overrideKey)
		{
			if (TryGetOverride(overrideKey, out var collection) && _activeOverrides.Contains(collection))
			{
				_activeOverrides.Remove(collection);
				SetIdle(_currentIdleKey);
			}
		}

		private void CreateMixersForCollection(AnimationStateCollection collection)
		{
			Animator.StringToHash("Speed");
			foreach (CTSLinearMixerTransition mixer in collection.GetMixers())
			{
				LinearMixerState item = (LinearMixerState)_animatorComponent.States.GetOrCreate(mixer);
				_mixers.TryAdd(mixer.ParameterKey, new HashSet<LinearMixerState>());
				if (!_mixers[mixer.ParameterKey].Contains(item))
				{
					_mixers[mixer.ParameterKey].Add(item);
				}
			}
		}

		public void ChangeIdle(AnimKey animation)
		{
			_ = _currentIdle;
			_currentIdle = GetTransition(animation).GetTransition();
			_currentIdleKey = animation;
		}

		public void SetIdle(AnimKey animation)
		{
			ITransition currentIdle = _currentIdle;
			_currentIdle = GetTransition(animation).GetTransition();
			_currentIdleKey = animation;
			if (_currentTransition == null)
			{
				Play(_currentIdle, 0);
			}
			else if (_currentTransition == currentIdle)
			{
				Play(_currentIdle, 0, _currentTransition.FadeDuration);
			}
		}

		public void SetIdleAndPlay(AnimKey animation, bool crossFade = true)
		{
			_ = _currentIdle;
			_currentIdle = GetTransition(animation).GetTransition();
			_currentIdleKey = animation;
			_agentRef.ProceduralAnimator.WeightMultiplier = 1f;
			if (_currentTransition == null)
			{
				Play(_currentIdle, 0, crossFade ? _currentIdle.FadeDuration : 0f);
			}
			else
			{
				Play(_currentIdle, 0, crossFade ? _currentTransition.FadeDuration : 0f);
			}
		}

		public void StartLoop(AnimKey p_animation)
		{
			ICTSTransition transition = GetTransition(p_animation);
			_agentRef.ProceduralAnimator.WeightMultiplier = 0f;
			Play(transition.GetTransition(), (int)transition.Layer);
		}

		public IEnumerator PlayTimedLoop(AnimKey p_animation, float p_duration)
		{
			StartLoop(p_animation);
			yield return Coroutines.WaitForSeconds(p_duration);
			ReturnToIdle();
		}

		private void UnPause()
		{
			if (_paused)
			{
				_paused = false;
				_animatorComponent.Playable.Speed = 1f;
			}
		}

		private void Pause()
		{
			if (!_paused)
			{
				_paused = true;
				_upperBodyLayer.StartFade(0f, 0.2f);
				_animatorComponent.Playable.Speed = 0f;
			}
		}

		public void ReturnToIdle()
		{
			UnPause();
			if (_currentTransition == null)
			{
				Play(_currentIdle, 0);
			}
			else
			{
				Play(_currentIdle, 0, _currentTransition.FadeDuration);
			}
			FadeOutUpperLayer();
			_agentRef.ProceduralAnimator.WeightMultiplier = 1f;
		}

		private void EndEvent(ICTSTransition p_transition)
		{
			switch (p_transition.EndEvent)
			{
			case EEndEvent.Idle:
				ReturnToIdle();
				break;
			case EEndEvent.PauseGraph:
				_agentRef.ProceduralAnimator.WeightMultiplier = 1f;
				Pause();
				break;
			case EEndEvent.ClearObject:
				_agentRef.ClearObject();
				break;
			}
		}

		public AnimationTracker PlayPunctual(AnimKey animation, float proceduralMultiplier = 1f)
		{
			if (_locked)
			{
				return null;
			}
			ICTSTransition iCTSTransition = PunctualStart(animation, proceduralMultiplier);
			AnimancerState state = Play(iCTSTransition.GetTransition(), (int)iCTSTransition.Layer);
			return AnimationTracker.Start(this, PunctualRoutine(state, iCTSTransition), state);
		}

		public AnimationTracker PlayPunctual(AnimKey animation, FadeMode fadeMode, float proceduralMultiplier = 1f)
		{
			if (_locked)
			{
				return null;
			}
			ICTSTransition iCTSTransition = PunctualStart(animation, proceduralMultiplier);
			AnimancerState state = Play(iCTSTransition.GetTransition(), (int)iCTSTransition.Layer, fadeMode);
			return AnimationTracker.Start(this, PunctualRoutine(state, iCTSTransition), state);
		}

		public Coroutine PlayPunctualInstantly(AnimKey animation, float proceduralMultiplier = 1f)
		{
			return StartCoroutine(PunctualRoutine(animation, proceduralMultiplier));
		}

		private IEnumerator PunctualRoutine(AnimKey animation, float proceduralMultiplier)
		{
			if (!_locked)
			{
				ICTSTransition iCTSTransition = PunctualStart(animation, proceduralMultiplier);
				AnimancerState state = Play(iCTSTransition.GetTransition(), (int)iCTSTransition.Layer, 0f);
				yield return PunctualRoutine(state, iCTSTransition);
			}
		}

		private ICTSTransition PunctualStart(AnimKey animation, float proceduralMultiplier)
		{
			UnPause();
			_agentRef.ProceduralAnimator.WeightMultiplier = proceduralMultiplier;
			return GetTransition(animation);
		}

		private IEnumerator PunctualRoutine(AnimancerState state, ICTSTransition transition)
		{
			while (state.IsPlayingAndNotEnding())
			{
				yield return null;
			}
			if (_currentTransition == transition)
			{
				EndEvent(transition);
			}
		}

		private ICTSTransition GetTransition(AnimKey p_key)
		{
			ICTSTransition transition;
			foreach (AnimationOverride activeOverride in _activeOverrides)
			{
				if (activeOverride.AnimationCollection.TryGet(p_key, out transition))
				{
					return transition;
				}
			}
			if (_baseAnimations.TryGet(p_key, out transition))
			{
				return transition;
			}
			return null;
		}

		private AnimancerState Play(ITransition p_transition, int layer)
		{
			_currentTransition = p_transition;
			if (layer == 0)
			{
				FadeOutUpperLayer();
			}
			return _animatorComponent.Layers[layer].Play(p_transition);
		}

		private AnimancerState Play(ITransition p_transition, int layer, float p_fadeDuration)
		{
			_currentTransition = p_transition;
			if (layer == 0)
			{
				FadeOutUpperLayer();
			}
			return _animatorComponent.Layers[layer].Play(p_transition, p_fadeDuration, p_transition.FadeMode);
		}

		private AnimancerState Play(ITransition p_transition, int layer, FadeMode p_fadeMode)
		{
			_currentTransition = p_transition;
			if (layer == 0)
			{
				FadeOutUpperLayer();
			}
			return _animatorComponent.Layers[layer].Play(p_transition, p_transition.FadeDuration, p_fadeMode);
		}

		private void FadeOutUpperLayer()
		{
			_upperBodyLayer.StartFade(0f, 0.2f);
		}
	}
}
