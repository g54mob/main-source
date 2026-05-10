using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Animancer
{
	public class ControllerState : AnimancerState, ICopyable<ControllerState>
	{
		public interface ITransition : ITransition<ControllerState>, Animancer.ITransition, IHasKey, IPolymorphic
		{
		}

		public enum ActionOnStop
		{
			DefaultState = 0,
			RewindTime = 1,
			Continue = 2
		}

		public class DampedFloatParameter
		{
			public ParameterID parameter;

			public float smoothTime;

			public float currentValue;

			public float targetValue;

			public float maxSpeed;

			public float velocity;

			public DampedFloatParameter(ParameterID parameter, float smoothTime, float defaultValue = 0f, float maxSpeed = float.PositiveInfinity)
			{
				this.parameter = parameter;
				this.smoothTime = smoothTime;
				currentValue = (targetValue = defaultValue);
				this.maxSpeed = maxSpeed;
			}

			public void Apply(ControllerState controller)
			{
				Apply(controller, UnityEngine.Time.deltaTime);
			}

			public void Apply(ControllerState controller, float deltaTime)
			{
				currentValue = Mathf.SmoothDamp(currentValue, targetValue, ref velocity, smoothTime, maxSpeed, deltaTime);
				controller.SetFloat(parameter, currentValue);
			}
		}

		public readonly struct ParameterID
		{
			public readonly string Name;

			public readonly int Hash;

			public ParameterID(string name)
			{
				Name = name;
				Hash = Animator.StringToHash(name);
			}

			public ParameterID(int hash)
			{
				Name = null;
				Hash = hash;
			}

			public ParameterID(string name, int hash)
			{
				Name = name;
				Hash = hash;
			}

			public static implicit operator ParameterID(string name)
			{
				return new ParameterID(name);
			}

			public static implicit operator ParameterID(int hash)
			{
				return new ParameterID(hash);
			}

			public static implicit operator int(ParameterID parameter)
			{
				return parameter.Hash;
			}

			[Conditional("UNITY_EDITOR")]
			public void ValidateHasParameter(RuntimeAnimatorController controller, AnimatorControllerParameterType type)
			{
			}

			public override string ToString()
			{
				return "ControllerState.ParameterID(Name: '" + Name + "'" + string.Format(", {0}: {1})", "Hash", Hash);
			}
		}

		private RuntimeAnimatorController _Controller;

		private new AnimatorControllerPlayable _Playable;

		private ActionOnStop[] _ActionsOnStop;

		public const float DefaultFadeDuration = -1f;

		private AnimatorControllerParameter[] _Parameters;

		private Dictionary<int, float> _SmoothingVelocities;

		public RuntimeAnimatorController Controller
		{
			get
			{
				return _Controller;
			}
			set
			{
				ChangeMainObject(ref _Controller, value);
			}
		}

		public override UnityEngine.Object MainObject
		{
			get
			{
				return Controller;
			}
			set
			{
				Controller = (RuntimeAnimatorController)value;
			}
		}

		public new AnimatorControllerPlayable Playable => _Playable;

		public ActionOnStop[] ActionsOnStop
		{
			get
			{
				return _ActionsOnStop;
			}
			set
			{
				_ActionsOnStop = value;
				if (_Playable.IsValid())
				{
					GatherDefaultStates();
				}
			}
		}

		public int[] DefaultStateHashes { get; set; }

		public override bool ApplyAnimatorIK
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public override bool ApplyFootIK
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual int ParameterCount => 0;

		public override double RawTime
		{
			get
			{
				AnimatorStateInfo stateInfo = GetStateInfo(0);
				return stateInfo.normalizedTime * stateInfo.length;
			}
			set
			{
				_Playable.PlayInFixedTime(0, 0, (float)value);
				if (!base.IsPlaying)
				{
					_Playable.Play();
					DelayedPause.Register(this);
				}
			}
		}

		public override float Length => GetStateInfo(0).length;

		public override bool IsLooping => GetStateInfo(0).loop;

		public int parameterCount => Playable.GetParameterCount();

		public AnimatorControllerParameter[] parameters
		{
			get
			{
				if (_Parameters == null)
				{
					int num = GetParameterCount();
					_Parameters = new AnimatorControllerParameter[num];
					for (int i = 0; i < num; i++)
					{
						_Parameters[i] = GetParameter(i);
					}
				}
				return _Parameters;
			}
		}

		public int layerCount => Playable.GetLayerCount();

		[Conditional("UNITY_ASSERTIONS")]
		public void AssertParameterValue(float value, [CallerMemberName] string parameterName = null)
		{
			if (!value.IsFinite())
			{
				throw new ArgumentOutOfRangeException(parameterName, "must not be NaN or Infinity");
			}
		}

		public override void CopyIKFlags(AnimancerNode copyFrom)
		{
		}

		public virtual int GetParameterHash(int index)
		{
			throw new NotSupportedException();
		}

		public ControllerState(RuntimeAnimatorController controller)
		{
			if (controller == null)
			{
				throw new ArgumentNullException("controller");
			}
			_Controller = controller;
		}

		public ControllerState(RuntimeAnimatorController controller, params ActionOnStop[] actionsOnStop)
			: this(controller)
		{
			_ActionsOnStop = actionsOnStop;
		}

		protected override void CreatePlayable(out Playable playable)
		{
			playable = (_Playable = AnimatorControllerPlayable.Create(base.Root._Graph, _Controller));
			GatherDefaultStates();
		}

		public override void RecreatePlayable()
		{
			if (!_Playable.IsValid())
			{
				CreatePlayable();
				return;
			}
			int num = _Playable.GetParameterCount();
			object[] array = new object[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = AnimancerUtilities.GetParameterValue(_Playable, _Playable.GetParameter(i));
			}
			base.RecreatePlayable();
			for (int j = 0; j < num; j++)
			{
				AnimancerUtilities.SetParameterValue(_Playable, _Playable.GetParameter(j), array[j]);
			}
		}

		public AnimatorStateInfo GetStateInfo(int layerIndex)
		{
			if (!_Playable.IsInTransition(layerIndex))
			{
				return _Playable.GetCurrentAnimatorStateInfo(layerIndex);
			}
			return _Playable.GetNextAnimatorStateInfo(layerIndex);
		}

		public void GatherDefaultStates()
		{
			int num = _Playable.GetLayerCount();
			if (DefaultStateHashes == null || DefaultStateHashes.Length != num)
			{
				DefaultStateHashes = new int[num];
			}
			while (--num >= 0)
			{
				DefaultStateHashes[num] = _Playable.GetCurrentAnimatorStateInfo(num).shortNameHash;
			}
		}

		public override void Stop()
		{
			base.Weight = 0f;
			base.IsPlaying = false;
			if (AnimancerState.AutomaticallyClearEvents)
			{
				base.Events = null;
			}
			ApplyActionsOnStop();
			if (_SmoothingVelocities != null)
			{
				_SmoothingVelocities.Clear();
			}
		}

		public void ApplyActionsOnStop()
		{
			int num = Math.Min(DefaultStateHashes.Length, _Playable.GetLayerCount());
			if (_ActionsOnStop == null || _ActionsOnStop.Length == 0)
			{
				for (int num2 = num - 1; num2 >= 0; num2--)
				{
					_Playable.Play(DefaultStateHashes[num2], num2, 0f);
				}
			}
			else
			{
				for (int num3 = num - 1; num3 >= 0; num3--)
				{
					int num4 = ((num3 < _ActionsOnStop.Length) ? num3 : (_ActionsOnStop.Length - 1));
					switch (_ActionsOnStop[num4])
					{
					case ActionOnStop.DefaultState:
						_Playable.Play(DefaultStateHashes[num3], num3, 0f);
						break;
					case ActionOnStop.RewindTime:
						_Playable.Play(0, num3, 0f);
						break;
					}
				}
			}
			CancelSetTime();
		}

		public override void GatherAnimationClips(ICollection<AnimationClip> clips)
		{
			if (_Controller != null)
			{
				clips.Gather(_Controller.animationClips);
			}
		}

		public override void Destroy()
		{
			_Controller = null;
			base.Destroy();
		}

		public override AnimancerState Clone(AnimancerPlayable root)
		{
			ControllerState controllerState = new ControllerState(_Controller);
			controllerState.SetNewCloneRoot(root);
			((ICopyable<ControllerState>)controllerState).CopyFrom(this);
			return controllerState;
		}

		void ICopyable<ControllerState>.CopyFrom(ControllerState copyFrom)
		{
			_ActionsOnStop = copyFrom._ActionsOnStop;
			if (copyFrom.Root != null && base.Root != null)
			{
				int num = copyFrom._Playable.GetLayerCount();
				for (int i = 0; i < num; i++)
				{
					AnimatorStateInfo currentAnimatorStateInfo = copyFrom._Playable.GetCurrentAnimatorStateInfo(i);
					_Playable.Play(currentAnimatorStateInfo.shortNameHash, i, currentAnimatorStateInfo.normalizedTime);
				}
				int num2 = copyFrom._Playable.GetParameterCount();
				for (int j = 0; j < num2; j++)
				{
					AnimancerUtilities.CopyParameterValue(copyFrom._Playable, _Playable, copyFrom._Playable.GetParameter(j));
				}
			}
			((ICopyable<AnimancerState>)this).CopyFrom((AnimancerState)copyFrom);
		}

		public static float GetFadeDuration(float fadeDuration)
		{
			if (!(fadeDuration >= 0f))
			{
				return AnimancerPlayable.DefaultFadeDuration;
			}
			return fadeDuration;
		}

		public void CrossFade(int stateNameHash, float fadeDuration = -1f, int layer = -1, float normalizedTime = float.NegativeInfinity)
		{
			Playable.CrossFade(stateNameHash, GetFadeDuration(fadeDuration), layer, normalizedTime);
		}

		public void CrossFade(string stateName, float fadeDuration = -1f, int layer = -1, float normalizedTime = float.NegativeInfinity)
		{
			Playable.CrossFade(stateName, GetFadeDuration(fadeDuration), layer, normalizedTime);
		}

		public void CrossFadeInFixedTime(int stateNameHash, float fadeDuration = -1f, int layer = -1, float fixedTime = 0f)
		{
			Playable.CrossFadeInFixedTime(stateNameHash, GetFadeDuration(fadeDuration), layer, fixedTime);
		}

		public void CrossFadeInFixedTime(string stateName, float fadeDuration = -1f, int layer = -1, float fixedTime = 0f)
		{
			Playable.CrossFadeInFixedTime(stateName, GetFadeDuration(fadeDuration), layer, fixedTime);
		}

		public void Play(int stateNameHash, int layer = -1, float normalizedTime = float.NegativeInfinity)
		{
			Playable.Play(stateNameHash, layer, normalizedTime);
		}

		public void Play(string stateName, int layer = -1, float normalizedTime = float.NegativeInfinity)
		{
			Playable.Play(stateName, layer, normalizedTime);
		}

		public void PlayInFixedTime(int stateNameHash, int layer = -1, float fixedTime = 0f)
		{
			Playable.PlayInFixedTime(stateNameHash, layer, fixedTime);
		}

		public void PlayInFixedTime(string stateName, int layer = -1, float fixedTime = 0f)
		{
			Playable.PlayInFixedTime(stateName, layer, fixedTime);
		}

		public bool GetBool(int id)
		{
			return Playable.GetBool(id);
		}

		public bool GetBool(string name)
		{
			return Playable.GetBool(name);
		}

		public void SetBool(int id, bool value)
		{
			Playable.SetBool(id, value);
		}

		public void SetBool(string name, bool value)
		{
			Playable.SetBool(name, value);
		}

		public float GetFloat(int id)
		{
			return Playable.GetFloat(id);
		}

		public float GetFloat(string name)
		{
			return Playable.GetFloat(name);
		}

		public void SetFloat(int id, float value)
		{
			Playable.SetFloat(id, value);
		}

		public void SetFloat(string name, float value)
		{
			Playable.SetFloat(name, value);
		}

		public int GetInteger(int id)
		{
			return Playable.GetInteger(id);
		}

		public int GetInteger(string name)
		{
			return Playable.GetInteger(name);
		}

		public void SetInteger(int id, int value)
		{
			Playable.SetInteger(id, value);
		}

		public void SetInteger(string name, int value)
		{
			Playable.SetInteger(name, value);
		}

		public void SetTrigger(int id)
		{
			Playable.SetTrigger(id);
		}

		public void SetTrigger(string name)
		{
			Playable.SetTrigger(name);
		}

		public void ResetTrigger(int id)
		{
			Playable.ResetTrigger(id);
		}

		public void ResetTrigger(string name)
		{
			Playable.ResetTrigger(name);
		}

		public bool IsParameterControlledByCurve(int id)
		{
			return Playable.IsParameterControlledByCurve(id);
		}

		public bool IsParameterControlledByCurve(string name)
		{
			return Playable.IsParameterControlledByCurve(name);
		}

		public AnimatorControllerParameter GetParameter(int index)
		{
			return Playable.GetParameter(index);
		}

		public int GetParameterCount()
		{
			return Playable.GetParameterCount();
		}

		public float SetFloat(string name, float value, float dampTime, float deltaTime, float maxSpeed = float.PositiveInfinity)
		{
			return SetFloat(Animator.StringToHash(name), value, dampTime, deltaTime, maxSpeed);
		}

		public float SetFloat(int id, float value, float dampTime, float deltaTime, float maxSpeed = float.PositiveInfinity)
		{
			if (_SmoothingVelocities == null)
			{
				_SmoothingVelocities = new Dictionary<int, float>();
			}
			_SmoothingVelocities.TryGetValue(id, out var value2);
			value = Mathf.SmoothDamp(GetFloat(id), value, ref value2, dampTime, maxSpeed, deltaTime);
			SetFloat(id, value);
			_SmoothingVelocities[id] = value2;
			return value;
		}

		public float GetLayerWeight(int layerIndex)
		{
			return Playable.GetLayerWeight(layerIndex);
		}

		public void SetLayerWeight(int layerIndex, float weight)
		{
			Playable.SetLayerWeight(layerIndex, weight);
		}

		public int GetLayerCount()
		{
			return Playable.GetLayerCount();
		}

		public int GetLayerIndex(string layerName)
		{
			return Playable.GetLayerIndex(layerName);
		}

		public string GetLayerName(int layerIndex)
		{
			return Playable.GetLayerName(layerIndex);
		}

		public AnimatorStateInfo GetCurrentAnimatorStateInfo(int layerIndex = 0)
		{
			return Playable.GetCurrentAnimatorStateInfo(layerIndex);
		}

		public AnimatorStateInfo GetNextAnimatorStateInfo(int layerIndex = 0)
		{
			return Playable.GetNextAnimatorStateInfo(layerIndex);
		}

		public bool HasState(int layerIndex, int stateID)
		{
			return Playable.HasState(layerIndex, stateID);
		}

		public bool IsInTransition(int layerIndex = 0)
		{
			return Playable.IsInTransition(layerIndex);
		}

		public AnimatorTransitionInfo GetAnimatorTransitionInfo(int layerIndex = 0)
		{
			return Playable.GetAnimatorTransitionInfo(layerIndex);
		}

		public AnimatorClipInfo[] GetCurrentAnimatorClipInfo(int layerIndex = 0)
		{
			return Playable.GetCurrentAnimatorClipInfo(layerIndex);
		}

		public void GetCurrentAnimatorClipInfo(int layerIndex, List<AnimatorClipInfo> clips)
		{
			Playable.GetCurrentAnimatorClipInfo(layerIndex, clips);
		}

		public int GetCurrentAnimatorClipInfoCount(int layerIndex = 0)
		{
			return Playable.GetCurrentAnimatorClipInfoCount(layerIndex);
		}

		public AnimatorClipInfo[] GetNextAnimatorClipInfo(int layerIndex = 0)
		{
			return Playable.GetNextAnimatorClipInfo(layerIndex);
		}

		public void GetNextAnimatorClipInfo(int layerIndex, List<AnimatorClipInfo> clips)
		{
			Playable.GetNextAnimatorClipInfo(layerIndex, clips);
		}

		public int GetNextAnimatorClipInfoCount(int layerIndex = 0)
		{
			return Playable.GetNextAnimatorClipInfoCount(layerIndex);
		}
	}
}
