using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Animancer
{
	[AddComponentMenu("Animancer/Hybrid Animancer Component")]
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer/HybridAnimancerComponent")]
	public class HybridAnimancerComponent : NamedAnimancerComponent
	{
		[SerializeField]
		[Tooltip("The main Animator Controller that this object will play")]
		private ControllerTransition _Controller;

		public ref ControllerTransition Controller => ref _Controller;

		public AnimatorControllerPlayable ControllerPlayable => _Controller.State.Playable;

		public PlayableGraph playableGraph => base.Playable.Graph;

		public RuntimeAnimatorController runtimeAnimatorController
		{
			get
			{
				return Controller.Controller;
			}
			set
			{
				Controller.Controller = value;
			}
		}

		public float speed
		{
			get
			{
				return base.Animator.speed;
			}
			set
			{
				base.Animator.speed = value;
			}
		}

		public bool applyRootMotion
		{
			get
			{
				return base.Animator.applyRootMotion;
			}
			set
			{
				base.Animator.applyRootMotion = value;
			}
		}

		public Quaternion bodyRotation
		{
			get
			{
				return base.Animator.bodyRotation;
			}
			set
			{
				base.Animator.bodyRotation = value;
			}
		}

		public Vector3 bodyPosition
		{
			get
			{
				return base.Animator.bodyPosition;
			}
			set
			{
				base.Animator.bodyPosition = value;
			}
		}

		public float gravityWeight => base.Animator.gravityWeight;

		public bool hasRootMotion => base.Animator.hasRootMotion;

		public bool layersAffectMassCenter
		{
			get
			{
				return base.Animator.layersAffectMassCenter;
			}
			set
			{
				base.Animator.layersAffectMassCenter = value;
			}
		}

		public Vector3 pivotPosition => base.Animator.pivotPosition;

		public float pivotWeight => base.Animator.pivotWeight;

		public Quaternion rootRotation
		{
			get
			{
				return base.Animator.rootRotation;
			}
			set
			{
				base.Animator.rootRotation = value;
			}
		}

		public Vector3 rootPosition
		{
			get
			{
				return base.Animator.rootPosition;
			}
			set
			{
				base.Animator.rootPosition = value;
			}
		}

		public Vector3 angularVelocity => base.Animator.angularVelocity;

		public Vector3 velocity => base.Animator.velocity;

		public Quaternion deltaRotation => base.Animator.deltaRotation;

		public Vector3 deltaPosition => base.Animator.deltaPosition;

		public float feetPivotActive
		{
			get
			{
				return base.Animator.feetPivotActive;
			}
			set
			{
				base.Animator.feetPivotActive = value;
			}
		}

		public bool stabilizeFeet
		{
			get
			{
				return base.Animator.stabilizeFeet;
			}
			set
			{
				base.Animator.stabilizeFeet = value;
			}
		}

		public float rightFeetBottomHeight => base.Animator.rightFeetBottomHeight;

		public float leftFeetBottomHeight => base.Animator.leftFeetBottomHeight;

		public int parameterCount => ControllerPlayable.GetParameterCount();

		public AnimatorControllerParameter[] parameters => _Controller.State.parameters;

		public float humanScale => base.Animator.humanScale;

		public bool isHuman => base.Animator.isHuman;

		public int layerCount => ControllerPlayable.GetLayerCount();

		public Avatar avatar
		{
			get
			{
				return base.Animator.avatar;
			}
			set
			{
				base.Animator.avatar = value;
			}
		}

		public AnimatorCullingMode cullingMode
		{
			get
			{
				return base.Animator.cullingMode;
			}
			set
			{
				base.Animator.cullingMode = value;
			}
		}

		public bool fireEvents
		{
			get
			{
				return base.Animator.fireEvents;
			}
			set
			{
				base.Animator.fireEvents = value;
			}
		}

		public bool hasBoundPlayables => base.Animator.hasBoundPlayables;

		public bool hasTransformHierarchy => base.Animator.hasTransformHierarchy;

		public bool isInitialized => base.Animator.isInitialized;

		public bool isOptimizable => base.Animator.isOptimizable;

		public bool logWarnings
		{
			get
			{
				return base.Animator.logWarnings;
			}
			set
			{
				base.Animator.logWarnings = value;
			}
		}

		public AnimatorUpdateMode updateMode
		{
			get
			{
				return base.Animator.updateMode;
			}
			set
			{
				base.Animator.updateMode = value;
			}
		}

		public bool keepAnimatorStateOnDisable
		{
			get
			{
				return base.Animator.keepAnimatorStateOnDisable;
			}
			set
			{
				base.Animator.keepAnimatorStateOnDisable = value;
			}
		}

		public ControllerState PlayController()
		{
			if (!_Controller.IsValid())
			{
				return null;
			}
			Play(_Controller);
			return _Controller.State;
		}

		protected override void OnEnable()
		{
			if (TryGetAnimator())
			{
				PlayController();
				base.OnEnable();
			}
		}

		protected override void OnInitializePlayable()
		{
			base.OnInitializePlayable();
			base.Playable.KeepChildrenConnected = true;
		}

		public override void GatherAnimationClips(ICollection<AnimationClip> clips)
		{
			base.GatherAnimationClips(clips);
			clips.GatherFromSource(_Controller);
		}

		public void ApplyBuiltinRootMotion()
		{
			base.Animator.ApplyBuiltinRootMotion();
		}

		public void CrossFade(int stateNameHash, float fadeDuration = -1f, int layer = -1, float normalizedTime = float.NegativeInfinity)
		{
			fadeDuration = ControllerState.GetFadeDuration(fadeDuration);
			PlayController().Playable.CrossFade(stateNameHash, fadeDuration, layer, normalizedTime);
		}

		public AnimancerState CrossFade(string stateName, float fadeDuration = -1f, int layer = -1, float normalizedTime = float.NegativeInfinity)
		{
			fadeDuration = ControllerState.GetFadeDuration(fadeDuration);
			if (base.States.TryGet(base.name, out var state))
			{
				Play(state, fadeDuration);
				if (layer >= 0)
				{
					state.LayerIndex = layer;
				}
				if (normalizedTime != float.NegativeInfinity)
				{
					state.NormalizedTime = normalizedTime;
				}
				return state;
			}
			ControllerState controllerState = PlayController();
			controllerState.Playable.CrossFade(stateName, fadeDuration, layer, normalizedTime);
			return controllerState;
		}

		public void CrossFadeInFixedTime(int stateNameHash, float fadeDuration = -1f, int layer = -1, float fixedTime = 0f)
		{
			fadeDuration = ControllerState.GetFadeDuration(fadeDuration);
			PlayController().Playable.CrossFadeInFixedTime(stateNameHash, fadeDuration, layer, fixedTime);
		}

		public AnimancerState CrossFadeInFixedTime(string stateName, float fadeDuration = -1f, int layer = -1, float fixedTime = 0f)
		{
			fadeDuration = ControllerState.GetFadeDuration(fadeDuration);
			if (base.States.TryGet(base.name, out var state))
			{
				Play(state, fadeDuration);
				if (layer >= 0)
				{
					state.LayerIndex = layer;
				}
				state.Time = fixedTime;
				return state;
			}
			ControllerState controllerState = PlayController();
			controllerState.Playable.CrossFadeInFixedTime(stateName, fadeDuration, layer, fixedTime);
			return controllerState;
		}

		public void Play(int stateNameHash, int layer = -1, float normalizedTime = float.NegativeInfinity)
		{
			PlayController().Playable.Play(stateNameHash, layer, normalizedTime);
		}

		public AnimancerState Play(string stateName, int layer = -1, float normalizedTime = float.NegativeInfinity)
		{
			if (base.States.TryGet(base.name, out var state))
			{
				Play(state);
				if (layer >= 0)
				{
					state.LayerIndex = layer;
				}
				if (normalizedTime != float.NegativeInfinity)
				{
					state.NormalizedTime = normalizedTime;
				}
				return state;
			}
			ControllerState controllerState = PlayController();
			controllerState.Playable.Play(stateName, layer, normalizedTime);
			return controllerState;
		}

		public void PlayInFixedTime(int stateNameHash, int layer = -1, float fixedTime = 0f)
		{
			PlayController().Playable.PlayInFixedTime(stateNameHash, layer, fixedTime);
		}

		public AnimancerState PlayInFixedTime(string stateName, int layer = -1, float fixedTime = 0f)
		{
			if (base.States.TryGet(base.name, out var state))
			{
				Play(state);
				if (layer >= 0)
				{
					state.LayerIndex = layer;
				}
				state.Time = fixedTime;
				return state;
			}
			ControllerState controllerState = PlayController();
			controllerState.Playable.PlayInFixedTime(stateName, layer, fixedTime);
			return controllerState;
		}

		public bool GetBool(int id)
		{
			return ControllerPlayable.GetBool(id);
		}

		public bool GetBool(string name)
		{
			return ControllerPlayable.GetBool(name);
		}

		public void SetBool(int id, bool value)
		{
			ControllerPlayable.SetBool(id, value);
		}

		public void SetBool(string name, bool value)
		{
			ControllerPlayable.SetBool(name, value);
		}

		public float GetFloat(int id)
		{
			return ControllerPlayable.GetFloat(id);
		}

		public float GetFloat(string name)
		{
			return ControllerPlayable.GetFloat(name);
		}

		public void SetFloat(int id, float value)
		{
			ControllerPlayable.SetFloat(id, value);
		}

		public void SetFloat(string name, float value)
		{
			ControllerPlayable.SetFloat(name, value);
		}

		public float SetFloat(string name, float value, float dampTime, float deltaTime, float maxSpeed = float.PositiveInfinity)
		{
			return _Controller.State.SetFloat(name, value, dampTime, deltaTime, maxSpeed);
		}

		public float SetFloat(int id, float value, float dampTime, float deltaTime, float maxSpeed = float.PositiveInfinity)
		{
			return _Controller.State.SetFloat(base.name, value, dampTime, deltaTime, maxSpeed);
		}

		public int GetInteger(int id)
		{
			return ControllerPlayable.GetInteger(id);
		}

		public int GetInteger(string name)
		{
			return ControllerPlayable.GetInteger(name);
		}

		public void SetInteger(int id, int value)
		{
			ControllerPlayable.SetInteger(id, value);
		}

		public void SetInteger(string name, int value)
		{
			ControllerPlayable.SetInteger(name, value);
		}

		public void SetTrigger(int id)
		{
			ControllerPlayable.SetTrigger(id);
		}

		public void SetTrigger(string name)
		{
			ControllerPlayable.SetTrigger(name);
		}

		public void ResetTrigger(int id)
		{
			ControllerPlayable.ResetTrigger(id);
		}

		public void ResetTrigger(string name)
		{
			ControllerPlayable.ResetTrigger(name);
		}

		public bool IsParameterControlledByCurve(int id)
		{
			return ControllerPlayable.IsParameterControlledByCurve(id);
		}

		public bool IsParameterControlledByCurve(string name)
		{
			return ControllerPlayable.IsParameterControlledByCurve(name);
		}

		public AnimatorControllerParameter GetParameter(int index)
		{
			return ControllerPlayable.GetParameter(index);
		}

		public int GetParameterCount()
		{
			return ControllerPlayable.GetParameterCount();
		}

		public AnimatorClipInfo[] GetCurrentAnimatorClipInfo(int layerIndex = 0)
		{
			return ControllerPlayable.GetCurrentAnimatorClipInfo(layerIndex);
		}

		public void GetCurrentAnimatorClipInfo(int layerIndex, List<AnimatorClipInfo> clips)
		{
			ControllerPlayable.GetCurrentAnimatorClipInfo(layerIndex, clips);
		}

		public int GetCurrentAnimatorClipInfoCount(int layerIndex = 0)
		{
			return ControllerPlayable.GetCurrentAnimatorClipInfoCount(layerIndex);
		}

		public AnimatorClipInfo[] GetNextAnimatorClipInfo(int layerIndex = 0)
		{
			return ControllerPlayable.GetNextAnimatorClipInfo(layerIndex);
		}

		public void GetNextAnimatorClipInfo(int layerIndex, List<AnimatorClipInfo> clips)
		{
			ControllerPlayable.GetNextAnimatorClipInfo(layerIndex, clips);
		}

		public int GetNextAnimatorClipInfoCount(int layerIndex = 0)
		{
			return ControllerPlayable.GetNextAnimatorClipInfoCount(layerIndex);
		}

		public Transform GetBoneTransform(HumanBodyBones humanBoneId)
		{
			return base.Animator.GetBoneTransform(humanBoneId);
		}

		public void SetBoneLocalRotation(HumanBodyBones humanBoneId, Quaternion rotation)
		{
			base.Animator.SetBoneLocalRotation(humanBoneId, rotation);
		}

		public int GetLayerCount()
		{
			return ControllerPlayable.GetLayerCount();
		}

		public int GetLayerIndex(string layerName)
		{
			return ControllerPlayable.GetLayerIndex(layerName);
		}

		public string GetLayerName(int layerIndex)
		{
			return ControllerPlayable.GetLayerName(layerIndex);
		}

		public float GetLayerWeight(int layerIndex)
		{
			return ControllerPlayable.GetLayerWeight(layerIndex);
		}

		public void SetLayerWeight(int layerIndex, float weight)
		{
			ControllerPlayable.SetLayerWeight(layerIndex, weight);
		}

		public T GetBehaviour<T>() where T : StateMachineBehaviour
		{
			return base.Animator.GetBehaviour<T>();
		}

		public T[] GetBehaviours<T>() where T : StateMachineBehaviour
		{
			return base.Animator.GetBehaviours<T>();
		}

		public StateMachineBehaviour[] GetBehaviours(int fullPathHash, int layerIndex)
		{
			return base.Animator.GetBehaviours(fullPathHash, layerIndex);
		}

		public AnimatorStateInfo GetCurrentAnimatorStateInfo(int layerIndex = 0)
		{
			return ControllerPlayable.GetCurrentAnimatorStateInfo(layerIndex);
		}

		public AnimatorStateInfo GetNextAnimatorStateInfo(int layerIndex = 0)
		{
			return ControllerPlayable.GetNextAnimatorStateInfo(layerIndex);
		}

		public bool HasState(int layerIndex, int stateID)
		{
			return ControllerPlayable.HasState(layerIndex, stateID);
		}

		public bool IsInTransition(int layerIndex = 0)
		{
			return ControllerPlayable.IsInTransition(layerIndex);
		}

		public AnimatorTransitionInfo GetAnimatorTransitionInfo(int layerIndex = 0)
		{
			return ControllerPlayable.GetAnimatorTransitionInfo(layerIndex);
		}

		public void Rebind()
		{
			base.Animator.Rebind();
		}
	}
}
