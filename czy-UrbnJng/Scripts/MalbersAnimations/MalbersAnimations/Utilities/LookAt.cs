using System;
using System.Collections;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[DefaultExecutionOrder(500)]
	[AddComponentMenu("Malbers/Utilities/Aiming/Look At")]
	public class LookAt : MonoBehaviour, IAnimatorListener, ILookAtActivation
	{
		[Serializable]
		public class BoneRotation
		{
			[RequiredField]
			public Transform bone;

			public Vector3 offset = new Vector3(0f, -90f, -90f);

			[Range(0f, 1f)]
			public float weight = 1f;

			internal Quaternion defaultRotation;

			[Tooltip("Is not a bone driven by the Animator")]
			public bool external;
		}

		private const float CloseToZero = 0.005f;

		public BoolReference active = new BoolReference(value: true);

		[Tooltip("Enable this if your Animator uses Animate physics loop")]
		public bool AnimatePhysics = true;

		private IGravity a_UpVector;

		[Tooltip("Reference for the Aim Component")]
		[RequiredField]
		public Aim aimer;

		[Tooltip("Limits the Look At from the Min to Max Value")]
		public RangedFloat LookAtLimit = new RangedFloat(90f, 120f);

		[Tooltip("Track an animator Paramter to multiply its value to the weight of the Look At")]
		public StringReference TrackParameter = new StringReference("LookAt");

		private int TrackParameterHash;

		[Tooltip("Smoothness between Enabled and Disable")]
		public FloatReference Lerp = new FloatReference(5f);

		[Tooltip("Use the LookAt only when there's a Force Target on the Aim... use this when the Animal is AI Controlled")]
		[SerializeField]
		private BoolReference onlyTargets = new BoolReference(value: false);

		[Space]
		public BoneRotation[] Bones;

		public BoolEvent OnLookAtActive = new BoolEvent();

		public bool debug = true;

		[Hide("debug")]
		public float GizmoRadius = 1f;

		private Transform EndBone;

		private bool isAiming;

		public float LookAtWeight { get; private set; }

		public float Angle { get; private set; }

		public bool HasTarget { get; set; }

		public Vector3 UpVector
		{
			get
			{
				if (a_UpVector == null)
				{
					return Vector3.up;
				}
				return a_UpVector.UpVector;
			}
		}

		public Vector3 AimDirection => aimer.AimDirection;

		public bool IsAiming
		{
			get
			{
				bool flag = Active && CameraAndTarget && ActiveByAnimation;
				if (flag != isAiming)
				{
					isAiming = flag;
					OnLookAtActive.Invoke(isAiming);
				}
				return isAiming;
			}
		}

		public bool Active
		{
			get
			{
				return active;
			}
			set
			{
				active.Value = value;
			}
		}

		public Animator Anim { get; set; }

		public bool ActiveByAnimation { get; set; }

		private bool CameraAndTarget { get; set; }

		public bool OnlyTargets
		{
			get
			{
				return onlyTargets.Value;
			}
			set
			{
				onlyTargets.Value = value;
			}
		}

		public int EnablePriority { get; private set; }

		public int DisablePriority { get; private set; }

		Transform IAnimatorListener.transform => base.transform;

		private void Awake()
		{
			a_UpVector = base.gameObject.FindInterface<IGravity>();
			if (aimer == null)
			{
				aimer = base.gameObject.FindComponent<Aim>();
			}
			Anim = base.gameObject.FindComponent<Animator>();
			if (Anim != null && MTools.FindAnimatorParameter(Anim, AnimatorControllerParameterType.Float, TrackParameter.Value))
			{
				TrackParameterHash = Animator.StringToHash(TrackParameter.Value);
			}
			aimer.IgnoreTransform = base.transform;
			ActiveByAnimation = true;
			EnablePriority = 1;
			BoneRotation[] bones = Bones;
			for (int i = 0; i < bones.Length; i++)
			{
				if (bones[i].bone == null)
				{
					Debug.LogError("LookAt in [" + base.name + "] has missing/empty bones. Please fill the reference. Disabling [LookAt]", this);
					base.enabled = false;
					break;
				}
			}
		}

		private void OnEnable()
		{
			if (Bones != null && Bones.Length != 0)
			{
				EndBone = Bones[^1].bone;
			}
			if (aimer.AimOrigin == null || aimer.AimOrigin == EndBone)
			{
				aimer.AimOrigin = Bones[0].bone.parent;
			}
			for (int i = 0; i < Bones.Length; i++)
			{
				Bones[i].defaultRotation = Bones[i].bone.localRotation;
			}
			if (AnimatePhysics)
			{
				StartCoroutine(SolveLookAt());
			}
		}

		private void OnDisable()
		{
			StopAllCoroutines();
		}

		private IEnumerator SolveLookAt()
		{
			WaitForFixedUpdate fixedUp = new WaitForFixedUpdate();
			while (true)
			{
				yield return fixedUp;
				DoLateUpdateLookAt(Time.fixedDeltaTime);
			}
		}

		private void ResetBoneLocalRot()
		{
			for (int i = 0; i < Bones.Length; i++)
			{
				Bones[i].bone.localRotation = Bones[i].defaultRotation;
			}
		}

		private void LateUpdate()
		{
			if (!AnimatePhysics)
			{
				DoLateUpdateLookAt(Time.deltaTime);
			}
		}

		private void DoLateUpdateLookAt(float time)
		{
			if (!aimer.UseCamera && aimer.AimTarget == null)
			{
				CameraAndTarget = false;
			}
			else if (OnlyTargets)
			{
				CameraAndTarget = aimer.AimTarget != null;
			}
			else
			{
				CameraAndTarget = aimer.MainCamera != null || !aimer.UseCamera;
			}
			Angle = Vector3.Angle(base.transform.forward, AimDirection);
			LookAtWeight = Mathf.Lerp(LookAtWeight, IsAiming ? 1 : 0, time * (float)Lerp);
			if (LookAtLimit.maxValue != 0f && LookAtLimit.minValue != 0f)
			{
				LookAtWeight = Mathf.Min(LookAtWeight, Angle.CalculateRangeWeight(LookAtLimit.minValue, LookAtLimit.maxValue));
			}
			if (TrackParameterHash != 0)
			{
				float num = Anim.GetFloat(TrackParameterHash);
				LookAtWeight *= num;
			}
			if (LookAtWeight != 0f)
			{
				LookAtBoneSet_AnimatePhysics2();
				if (LookAtWeight <= 0.005f)
				{
					LookAtWeight = 0f;
				}
			}
		}

		private void LookAtBoneSet_AnimatePhysics2()
		{
			if (AimDirection == Vector3.zero)
			{
				return;
			}
			for (int i = 0; i < Bones.Length; i++)
			{
				BoneRotation boneRotation = Bones[i];
				if ((bool)boneRotation.bone && LookAtWeight != 0f)
				{
					float t = Mathf.SmoothStep(0f, 1f, LookAtWeight);
					Quaternion b = Quaternion.LookRotation(AimDirection, base.transform.up) * Quaternion.Euler(boneRotation.offset);
					if (boneRotation.external)
					{
						boneRotation.bone.localRotation = Quaternion.Lerp(boneRotation.defaultRotation, b, t);
					}
					else
					{
						boneRotation.bone.rotation = Quaternion.Lerp(boneRotation.bone.rotation, b, t);
					}
				}
			}
		}

		public void EnableLookAt(int layer)
		{
			EnableByPriority(layer + 1);
		}

		public void DisableLookAt(int layer)
		{
			DisableByPriority(layer + 1);
		}

		public virtual void SetTargetOnly(bool val)
		{
			OnlyTargets = val;
		}

		public virtual void EnableByPriority(int priority)
		{
			if (priority >= DisablePriority)
			{
				EnablePriority = priority;
				if (DisablePriority == EnablePriority)
				{
					DisablePriority = 0;
				}
			}
			ActiveByAnimation = EnablePriority > DisablePriority;
		}

		public virtual void ResetByPriority(int priority)
		{
			if (EnablePriority == priority)
			{
				EnablePriority = 0;
			}
			if (DisablePriority == priority)
			{
				DisablePriority = 0;
			}
			ActiveByAnimation = EnablePriority > DisablePriority;
		}

		public virtual void DisableByPriority(int priority)
		{
			if (priority >= EnablePriority)
			{
				DisablePriority = priority;
				if (DisablePriority == EnablePriority)
				{
					EnablePriority = 0;
				}
			}
			ActiveByAnimation = EnablePriority > DisablePriority;
		}

		public virtual bool OnAnimatorBehaviourMessage(string message, object value)
		{
			return this.InvokeWithParams(message, value);
		}

		private void OnValidate()
		{
			if (Bones != null && Bones.Length != 0)
			{
				EndBone = Bones[^1].bone;
			}
		}

		private void Reset()
		{
			aimer = base.gameObject.FindInterface<Aim>();
			if (aimer == null)
			{
				aimer = base.gameObject.AddComponent<Aim>();
			}
		}
	}
}
