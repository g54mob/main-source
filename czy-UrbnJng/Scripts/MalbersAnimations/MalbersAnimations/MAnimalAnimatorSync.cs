using System;
using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations
{
	[RequireComponent(typeof(Animator))]
	[AddComponentMenu("Malbers/Utilities/Animator/Animator Sync")]
	public class MAnimalAnimatorSync : MonoBehaviour
	{
		[RequiredField]
		[Tooltip("Master Animator Reference to get the parameters values")]
		public Animator MasterAnimator;

		[SerializeField]
		[Tooltip("Slave Animator to receive the parameters values")]
		private Animator SlaveAnimator;

		[Tooltip("Which Layer Index will be used to sync to the Slave Animator")]
		public int Layer;

		[Tooltip("When the Animator is playing a blendtree or a loopable animation. it will check if both Animator times are in sync. If not it will force a synchronization")]
		public bool Resynchronize = true;

		[Hide("Resynchronize")]
		[Tooltip("Threshold to check if the slave animator is unsync")]
		public float Threshold = 0.1f;

		[Hide("Resynchronize")]
		[Tooltip("Which State will be synced again")]
		public List<int> StateCheck = new List<int>();

		[Space]
		[Tooltip("Enables the Offset position and rotation from the Master Animator")]
		public bool useTransformOffset;

		[Tooltip("Offset the position relative to the Master Animator.\nRIGHT CLICK to Calculate the current offest")]
		[ContextMenuItem("Calculate Current Position Offset", "CalculateCurrentOffset")]
		[Hide("useTransformOffset")]
		public Vector3 PosOffset;

		[Tooltip("Offset the rotation relative to the Master Animator.")]
		[Hide("useTransformOffset")]
		public Vector3 RotOffset;

		private IMAnimator listenTo;

		private IAnimatorStateCycle StateCycle;

		private List<int> animatorParams;

		private const float crossFade = 0.2f;

		private void Awake()
		{
			animatorParams = new List<int>();
			if (MasterAnimator != null)
			{
				listenTo = MasterAnimator.GetComponent<IMAnimator>();
				StateCycle = MasterAnimator.GetComponent<IAnimatorStateCycle>();
			}
			SlaveAnimator = GetComponent<Animator>();
			AnimatorControllerParameter[] parameters = SlaveAnimator.parameters;
			foreach (AnimatorControllerParameter animatorControllerParameter in parameters)
			{
				animatorParams.Add(animatorControllerParameter.nameHash);
			}
		}

		private void OnEnable()
		{
			IMAnimator iMAnimator = listenTo;
			iMAnimator.SetBoolParameter = (Action<int, bool>)Delegate.Combine(iMAnimator.SetBoolParameter, new Action<int, bool>(SetAnimParameter));
			IMAnimator iMAnimator2 = listenTo;
			iMAnimator2.SetIntParameter = (Action<int, int>)Delegate.Combine(iMAnimator2.SetIntParameter, new Action<int, int>(SetAnimParameter));
			IMAnimator iMAnimator3 = listenTo;
			iMAnimator3.SetFloatParameter = (Action<int, float>)Delegate.Combine(iMAnimator3.SetFloatParameter, new Action<int, float>(SetAnimParameter));
			IMAnimator iMAnimator4 = listenTo;
			iMAnimator4.SetTriggerParameter = (Action<int>)Delegate.Combine(iMAnimator4.SetTriggerParameter, new Action<int>(SetAnimParameter));
			if (Resynchronize)
			{
				IAnimatorStateCycle stateCycle = StateCycle;
				stateCycle.StateCycle = (Action<int>)Delegate.Combine(stateCycle.StateCycle, new Action<int>(SyncStateCycle));
			}
		}

		private void OnDisable()
		{
			IMAnimator iMAnimator = listenTo;
			iMAnimator.SetBoolParameter = (Action<int, bool>)Delegate.Remove(iMAnimator.SetBoolParameter, new Action<int, bool>(SetAnimParameter));
			IMAnimator iMAnimator2 = listenTo;
			iMAnimator2.SetIntParameter = (Action<int, int>)Delegate.Remove(iMAnimator2.SetIntParameter, new Action<int, int>(SetAnimParameter));
			IMAnimator iMAnimator3 = listenTo;
			iMAnimator3.SetFloatParameter = (Action<int, float>)Delegate.Remove(iMAnimator3.SetFloatParameter, new Action<int, float>(SetAnimParameter));
			if (Resynchronize)
			{
				IAnimatorStateCycle stateCycle = StateCycle;
				stateCycle.StateCycle = (Action<int>)Delegate.Remove(stateCycle.StateCycle, new Action<int>(SyncStateCycle));
			}
		}

		private void Update()
		{
			if (useTransformOffset)
			{
				base.transform.position = MasterAnimator.transform.position + PosOffset;
				base.transform.rotation = MasterAnimator.transform.rotation * Quaternion.Euler(RotOffset);
			}
		}

		private void SyncStateCycle(int currentState)
		{
			if (!MasterAnimator.IsInTransition(0) && !SlaveAnimator.IsInTransition(Layer) && HasStateCheck(currentState))
			{
				AnimatorStateInfo currentAnimatorStateInfo = MasterAnimator.GetCurrentAnimatorStateInfo(0);
				AnimatorStateInfo currentAnimatorStateInfo2 = SlaveAnimator.GetCurrentAnimatorStateInfo(Layer);
				float normalizedTime = currentAnimatorStateInfo.normalizedTime;
				float normalizedTime2 = currentAnimatorStateInfo2.normalizedTime;
				if (Mathf.Abs(normalizedTime - normalizedTime2) >= Threshold)
				{
					SlaveAnimator.CrossFade(currentAnimatorStateInfo2.fullPathHash, 0.2f, Layer, normalizedTime);
				}
			}
		}

		public bool HasStateCheck(int check)
		{
			if (StateCheck.Count == 0)
			{
				return false;
			}
			foreach (int item in StateCheck)
			{
				if (item == check)
				{
					return true;
				}
			}
			return false;
		}

		public void SetAnimParameter(int hash, int value)
		{
			if (animatorParams.Contains(hash))
			{
				SlaveAnimator.SetInteger(hash, value);
			}
		}

		public void SetAnimParameter(int hash, float value)
		{
			if (animatorParams.Contains(hash))
			{
				SlaveAnimator.SetFloat(hash, value);
			}
		}

		public void SetAnimParameter(int hash)
		{
			if (animatorParams.Contains(hash))
			{
				SlaveAnimator.SetTrigger(hash);
			}
		}

		public void SetAnimParameter(int hash, bool value)
		{
			if (animatorParams.Contains(hash))
			{
				SlaveAnimator.SetBool(hash, value);
			}
		}

		private void OnValidate()
		{
			if (SlaveAnimator == null)
			{
				SlaveAnimator = GetComponent<Animator>();
			}
		}

		[ContextMenu("Calculate Current Position Offset")]
		private void CalculateCurrentOffset()
		{
			PosOffset = MasterAnimator.transform.InverseTransformPoint(base.transform.position);
		}
	}
}
