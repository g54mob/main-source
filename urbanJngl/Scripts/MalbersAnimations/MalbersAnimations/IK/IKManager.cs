using System.Collections;
using System.Collections.Generic;
using MalbersAnimations.Utilities;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[DisallowMultipleComponent]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/secondary-components/ik/ikmanager")]
	[AddComponentMenu("Malbers/IK/IK Manager")]
	public class IKManager : MonoBehaviour, IIKSource
	{
		[RequiredField]
		public Animator animator;

		[Range(0f, 1f)]
		[Tooltip("Global weight for the All IK Profiles")]
		public float Weight = 1f;

		public List<IKSet> sets = new List<IKSet>();

		private HashSet<int> animatorHashParams;

		[HideInInspector]
		[SerializeField]
		private int EditorTabs;

		[HideInInspector]
		[SerializeField]
		internal int SelectedSet;

		private bool animatePhysics;

		public Transform Owner => base.transform;

		private void Awake()
		{
			animator = ((animator == null) ? GetComponent<Animator>() : animator);
			animatorHashParams = new HashSet<int>();
			AnimatorControllerParameter[] parameters = animator.parameters;
			foreach (AnimatorControllerParameter animatorControllerParameter in parameters)
			{
				if (animatorControllerParameter.type == AnimatorControllerParameterType.Float)
				{
					animatorHashParams.Add(animatorControllerParameter.nameHash);
				}
			}
			foreach (IKSet set in sets)
			{
				set.Initialize(animator, animatorHashParams);
				set.Owner = this;
			}
		}

		private void OnEnable()
		{
			animatePhysics = animator.updateMode == AnimatorUpdateMode.AnimatePhysics;
			if (animatePhysics)
			{
				StartCoroutine(SolveFixedUpdateIK());
			}
			foreach (IKSet set in sets)
			{
				set.OnEnable(animator, animatorHashParams);
			}
		}

		private void OnDisable()
		{
			foreach (IKSet set in sets)
			{
				set.OnDisable(animator, animatorHashParams);
			}
		}

		private IEnumerator SolveFixedUpdateIK()
		{
			WaitForFixedUpdate wait = new WaitForFixedUpdate();
			while (true)
			{
				yield return wait;
				foreach (IKSet set in sets)
				{
					if (animatePhysics)
					{
						set.CacheValues(animator);
						set.LateUpdate(animator, Weight, Time.fixedDeltaTime);
					}
				}
			}
		}

		private void LateUpdate()
		{
			foreach (IKSet set in sets)
			{
				if (!animatePhysics)
				{
					set.CacheValues(animator);
					set.LateUpdate(animator, Weight, Time.deltaTime);
				}
			}
		}

		private void OnAnimatorIK()
		{
			foreach (IKSet set in sets)
			{
				set.OnAnimatorIK(animator, Weight, (animator.updateMode == AnimatorUpdateMode.Normal) ? Time.deltaTime : Time.fixedDeltaTime);
			}
		}

		public void Set_Enable(string set, bool value)
		{
			if (base.enabled)
			{
				FindSet(set)?.Enable(value);
			}
		}

		public void Set_Enable(string set)
		{
			Set_Enable(set, value: true);
		}

		public void Set_Disable(string set)
		{
			Set_Enable(set, value: false);
		}

		public void Set_Weight_1(string set)
		{
			Set_Enable(set, value: false);
		}

		public void Set_Weight_0(string set)
		{
			Set_Enable(set, value: false);
		}

		public void Set_Weight(string set, bool value)
		{
			FindSet(set)?.SetWeight(value);
		}

		public void Target_Set(string set, Transform newTarget, int index)
		{
			FindSet(set)?.SetTarget(newTarget, index);
		}

		public virtual IKSet FindSet(string set)
		{
			return sets.Find((IKSet x) => x.name == set);
		}

		public void Target_Clear(string set, int index)
		{
			FindSet(set)?.ClearTarget(index);
		}

		public void Target_Clear(string set)
		{
			FindSet(set)?.ClearAllTargets();
		}

		public void Target_Set(string set, Transform[] targets)
		{
			FindSet(set)?.SetTargets(targets);
		}

		public void Processor_SetEnable(string set, string processor, bool value)
		{
			FindSet(set)?.Processor_SetEnable(processor, value);
		}

		private void Reset()
		{
			animator = this.FindComponent<Animator>();
		}

		private void OnValidate()
		{
			foreach (IKSet set in sets)
			{
				if (set.aimer == null)
				{
					set.aimer = this.FindComponent<Aim>();
				}
			}
		}

		private void OnDrawGizmosSelected()
		{
			if (!base.enabled || sets == null || sets.Count <= 0 || !(animator != null))
			{
				return;
			}
			for (int i = 0; i < sets.Count; i++)
			{
				IKSet iKSet = sets[i];
				if (!iKSet.active)
				{
					continue;
				}
				if (iKSet.weightProcessors != null)
				{
					foreach (WeightProcessor weightProcessor in iKSet.weightProcessors)
					{
						weightProcessor?.OnDrawGizmos(iKSet, animator);
					}
				}
				if (iKSet == null || SelectedSet != i || !iKSet.active || iKSet.Processors == null)
				{
					continue;
				}
				for (int j = 0; j < iKSet.Processors.Count; j++)
				{
					IKProcessor iKProcessor = iKSet.Processors[j];
					if (iKProcessor != null && iKProcessor.Active && iKSet.SelectedIKProcessor == j)
					{
						iKProcessor.OnDrawGizmos(iKSet, animator, Weight);
					}
				}
			}
		}
	}
}
