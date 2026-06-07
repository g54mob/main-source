using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Animations
{
	public class PartModifierGenericAnimationScript : MonoBehaviour, IPartModifierAnimationScript
	{
		public enum AnimationStepType
		{
			Translation = 0,
			Rotation = 1,
			Scale = 2
		}

		[Serializable]
		public class AnimationStep
		{
			public float EndTime;

			public Vector3 EndValue;

			public float StartTime;

			public Vector3 StartValue;

			public Transform Transform;

			public AnimationStepType Type;
		}

		[SerializeField]
		private float _animationSpeed = 1f;

		[SerializeField]
		private List<AnimationStep> _animationSteps = new List<AnimationStep>(1);

		private bool _isActive;

		private bool _isValid;

		[Range(0f, 1f)]
		[SerializeField]
		private float _stateCurrent;

		private float _stateGainPerSecond;

		private float _stateTarget;

		private float _totalTime;

		public float AnimationSpeed
		{
			get
			{
				return _animationSpeed;
			}
			set
			{
				SetAnimationSpeed(value);
			}
		}

		public float AnimationState
		{
			get
			{
				return _stateCurrent;
			}
			set
			{
				SetAnimationState(value, cancelCurrentAnimation: true);
			}
		}

		public float AnimationStateTarget
		{
			get
			{
				return _stateTarget;
			}
			set
			{
				Animate(value, _animationSpeed);
			}
		}

		public List<AnimationStep> AnimationSteps => _animationSteps;

		public AudioSource Audio { get; set; }

		public bool IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				if (value)
				{
					Animate(_stateTarget, _animationSpeed);
				}
				else
				{
					Stop();
				}
			}
		}

		public float TotalTime => _totalTime;

		public void Animate(float targetState, float animationSpeed = 1f)
		{
			if (_isValid)
			{
				SetAnimationSpeed(animationSpeed);
				_stateTarget = targetState;
				_isActive = true;
			}
		}

		public void Initialize()
		{
			_isValid = false;
			int num = AnimationSteps?.Count ?? 0;
			if (num != 0)
			{
				float num2 = 0f;
				for (int i = 0; i < num; i++)
				{
					num2 = Mathf.Max(num2, AnimationSteps[i].EndTime);
				}
				if (!(num2 <= 0f) && !float.IsNaN(num2) && !float.IsInfinity(num2))
				{
					_totalTime = num2;
					_stateGainPerSecond = 1f / num2 * _animationSpeed;
					_isValid = true;
				}
			}
		}

		public void Stop()
		{
			_isActive = false;
		}

		protected virtual void OnValidate()
		{
			Initialize();
			SetAnimationState(_stateCurrent, cancelCurrentAnimation: false);
		}

		protected virtual void Update()
		{
			if (!_isActive)
			{
				if (Audio != null && Audio.isPlaying)
				{
					Audio.Stop();
				}
				return;
			}
			float deltaTime = Time.deltaTime;
			if (deltaTime == 0f)
			{
				return;
			}
			if (Audio != null && !Audio.isPlaying)
			{
				Audio.Play();
				Audio.timeSamples = (int)(UnityEngine.Random.value * (float)Audio.clip.samples);
			}
			if (_stateCurrent < _stateTarget)
			{
				if (Audio != null)
				{
					Audio.volume = Mathf.Clamp01(3f * (_stateTarget - _stateCurrent) / _stateGainPerSecond);
					Audio.pitch = Audio.volume;
				}
				_stateCurrent += _stateGainPerSecond * deltaTime;
				if (_stateCurrent > _stateTarget)
				{
					_stateCurrent = _stateTarget;
					_isActive = false;
				}
			}
			else
			{
				if (Audio != null)
				{
					Audio.volume = Mathf.Clamp01(3f * (_stateCurrent - _stateTarget) / _stateGainPerSecond);
					Audio.pitch = Audio.volume;
				}
				_stateCurrent -= _stateGainPerSecond * deltaTime;
				if (_stateCurrent < _stateTarget)
				{
					_stateCurrent = _stateTarget;
					_isActive = false;
				}
			}
			SetAnimationState(_stateCurrent, cancelCurrentAnimation: false);
		}

		private void SetAnimationSpeed(float value)
		{
			_animationSpeed = value;
			if (_isValid)
			{
				_stateGainPerSecond = 1f / _totalTime * _animationSpeed;
			}
		}

		private void SetAnimationState(float targetState, bool cancelCurrentAnimation)
		{
			if (!_isValid)
			{
				return;
			}
			if (cancelCurrentAnimation)
			{
				Stop();
			}
			_stateCurrent = targetState;
			int num = AnimationSteps?.Count ?? 0;
			float value = _totalTime * targetState;
			for (int i = 0; i < num; i++)
			{
				AnimationStep animationStep = AnimationSteps[i];
				float t = Mathf.InverseLerp(animationStep.StartTime, animationStep.EndTime, value);
				Vector3 vector = Vector3.Lerp(animationStep.StartValue, animationStep.EndValue, t);
				switch (animationStep.Type)
				{
				case AnimationStepType.Translation:
					animationStep.Transform.localPosition = vector;
					break;
				case AnimationStepType.Rotation:
					animationStep.Transform.localEulerAngles = vector;
					break;
				case AnimationStepType.Scale:
					animationStep.Transform.localScale = vector;
					break;
				}
			}
		}
	}
}
