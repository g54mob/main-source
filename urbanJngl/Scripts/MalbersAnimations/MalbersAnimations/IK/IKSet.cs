using System;
using System.Collections;
using System.Collections.Generic;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using MalbersAnimations.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations.IK
{
	[Serializable]
	public class IKSet
	{
		public struct IKVars
		{
			public Transform RootBone;

			public Transform Bone;

			public Dictionary<int, Quaternion> rotations;

			public IKVars(string _)
			{
				rotations = new Dictionary<int, Quaternion>();
				RootBone = (Bone = null);
			}
		}

		public string name;

		public bool active = true;

		[Tooltip("Smoothly Enable the IK Set Weight")]
		[Min(0f)]
		public float EnableTime;

		[Tooltip("Smoothly Disable the IK Set Weight")]
		[Min(0f)]
		public float DisableTime = 0.25f;

		[Range(0f, 1f)]
		[Tooltip("Weight of the IK Set")]
		[SerializeField]
		private float weight = 1f;

		[Tooltip("Use this Targets array to assign IK goals, Targets or Transform References to the IK Processors")]
		public TransformReference[] Targets;

		[Tooltip("Clears all Targets on the Set if the Set gets disabled")]
		public bool ClearTargetsOnDisable;

		[Tooltip("Reference for the Aimer Component to get Directions")]
		public Aim aimer;

		[SerializeReference]
		public List<IKProcessor> IKProcesors;

		[SerializeReference]
		[SubclassSelector]
		public List<WeightProcessor> weightProcessors;

		[HideInInspector]
		public int SelectedIKProcessor;

		public IKVars[] Var;

		[Tooltip("Lerp the Weight of the IK Set. Set the value to zero to ignore lerping")]
		[Min(0f)]
		public float LerpWeight = 5f;

		public FloatEvent OnWeightChanged = new FloatEvent();

		public UnityEvent OnSetEnable = new UnityEvent();

		public UnityEvent OnSetDisable = new UnityEvent();

		public AnimationCurve EnterLerp = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		public AnimationCurve ExitLerp = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		public Dictionary<string, object> sharedVars = new Dictionary<string, object>();

		private IEnumerator C_EnableSmooth;

		public TransformValues[] CacheTargets { get; set; }

		public float FinalWeight { get; private set; }

		public int CurrentState { get; private set; }

		public int CurrentStance { get; private set; }

		public Animator Animator { get; set; }

		public MonoBehaviour Owner { get; set; }

		public List<IKProcessor> Processors => IKProcesors;

		public float Weight
		{
			get
			{
				return weight;
			}
			set
			{
				weight = value;
			}
		}

		public virtual void OnEnable(Animator anim, HashSet<int> animParams)
		{
			for (int i = 0; i < weightProcessors.Count; i++)
			{
				weightProcessors[i].OnEnable(this, anim);
			}
			for (int j = 0; j < Processors.Count; j++)
			{
				Processors[j].OnEnable(this, anim, j);
			}
		}

		public virtual void OnDisable(Animator anim, HashSet<int> animParams)
		{
			for (int i = 0; i < weightProcessors.Count; i++)
			{
				weightProcessors[i].OnDisable(this, anim);
			}
			for (int j = 0; j < Processors.Count; j++)
			{
				Processors[j].OnDisable(this, anim, j);
			}
		}

		public virtual void Initialize(Animator anim, HashSet<int> animParams)
		{
			if (Targets == null)
			{
				Targets = new TransformReference[0];
			}
			CacheTargets = new TransformValues[Targets.Length];
			Animator = anim;
			Var = new IKVars[Processors.Count];
			FinalWeight = 0f;
			for (int i = 0; i < Processors.Count; i++)
			{
				IKProcessor iKProcessor = Processors[i];
				Var[i] = new IKVars(iKProcessor.name);
				if (iKProcessor != null)
				{
					iKProcessor.AnimParameterHash = TryAnimParameter(iKProcessor.AnimParameter, animParams);
					iKProcessor.Start(this, anim, i);
				}
			}
		}

		public int TryAnimParameter(string param, HashSet<int> animParams)
		{
			int num = Animator.StringToHash(param);
			if (!animParams.Contains(num))
			{
				return 0;
			}
			return num;
		}

		public void CacheValues(Animator anim)
		{
			if (!active)
			{
				return;
			}
			for (int i = 0; i < Targets.Length; i++)
			{
				if (Targets[i] != null && Targets[i].Value != null)
				{
					CacheTargets[i] = new TransformValues(Targets[i].Value);
				}
			}
		}

		public void OnAnimatorIK(Animator anim, float GlobalWeight, float deltaTime)
		{
			DoProcessor(anim, GlobalWeight, deltaTime, OnAnimatorIK: true);
		}

		public void LateUpdate(Animator anim, float GlobalWeight, float deltaTime)
		{
			DoProcessor(anim, GlobalWeight, deltaTime, OnAnimatorIK: false);
		}

		protected virtual void DoProcessor(Animator anim, float GlobalWeight, float deltaTime, bool OnAnimatorIK)
		{
			float weightProcessor = GetWeightProcessor(GlobalWeight);
			if (!active)
			{
				return;
			}
			for (int i = 0; i < Processors.Count; i++)
			{
				IKProcessor iKProcessor = Processors[i];
				if (!iKProcessor.Active)
				{
					continue;
				}
				float num = FinalWeight * iKProcessor.Weight;
				num *= iKProcessor.GetProcessorAnimWeight(anim);
				if (num > 0f)
				{
					if (FinalWeight > 0.999f)
					{
						FinalWeight = 1f;
					}
					else if (FinalWeight < 0.001f)
					{
						FinalWeight = 0f;
					}
					if (OnAnimatorIK)
					{
						iKProcessor.OnAnimatorIK(this, anim, i, num);
					}
					else
					{
						iKProcessor.LateUpdate(this, anim, i, num);
					}
				}
				GetFinalWeight(weightProcessor, deltaTime);
			}
		}

		protected virtual float GetWeightProcessor(float GlobalWeight)
		{
			float result = Weight * GlobalWeight;
			if (weightProcessors != null)
			{
				for (int i = 0; i < weightProcessors.Count; i++)
				{
					if (weightProcessors[i].Active)
					{
						result = weightProcessors[i].Process(this, result);
					}
				}
			}
			return result;
		}

		private void GetFinalWeight(float finalWeight, float deltaTime)
		{
			if (FinalWeight != finalWeight)
			{
				FinalWeight = ((LerpWeight > 0f) ? Mathf.Lerp(FinalWeight, finalWeight, deltaTime * LerpWeight) : finalWeight);
				OnWeightChanged.Invoke(FinalWeight);
			}
		}

		public virtual void Enable(bool value)
		{
			if (C_EnableSmooth != null)
			{
				Owner.StopCoroutine(C_EnableSmooth);
			}
			C_EnableSmooth = (value ? EnableSmooth() : DisableSmooth());
			Owner.StartCoroutine(C_EnableSmooth);
		}

		public virtual void SetWeight(bool value)
		{
			if (active)
			{
				Weight = (value ? 1 : 0);
			}
		}

		private IEnumerator EnableSmooth()
		{
			float elapsedTime = 0f;
			float startWeight = Weight;
			active = true;
			OnSetEnable.Invoke();
			while (Weight != 1f && elapsedTime <= EnableTime)
			{
				Weight = Mathf.Lerp(startWeight, 1f, EnterLerp.Evaluate(elapsedTime / EnableTime));
				elapsedTime += Time.deltaTime;
				yield return null;
			}
			Weight = 1f;
			yield return null;
		}

		private IEnumerator DisableSmooth()
		{
			float elapsedTime = 0f;
			float startWeight = Weight;
			while (Weight != 0f && DisableTime > 0f && elapsedTime <= DisableTime)
			{
				Weight = Mathf.Lerp(startWeight, 0f, ExitLerp.Evaluate(elapsedTime / DisableTime));
				elapsedTime += Time.deltaTime;
				yield return null;
			}
			Weight = 0f;
			yield return null;
			if (ClearTargetsOnDisable)
			{
				int num = Targets.Length;
				Targets = new TransformReference[num];
			}
			OnSetDisable.Invoke();
			active = false;
		}

		public virtual void SetTarget(Transform target, int index)
		{
			Targets[index] = target;
		}

		public virtual void ClearTarget(int index)
		{
			Targets[index].Value = null;
		}

		public virtual void ClearAllTargets()
		{
			for (int i = 0; i < Targets.Length; i++)
			{
				Targets[i] = null;
			}
		}

		public virtual void SetTargets(Transform[] newTargets)
		{
			Targets = new TransformReference[newTargets.Length];
			for (int i = 0; i < Targets.Length; i++)
			{
				if (newTargets[i] != null)
				{
					Targets[i] = new TransformReference(newTargets[i]);
				}
			}
		}

		internal void Processor_SetEnable(string processor, bool value)
		{
			for (int i = 0; i < Processors.Count; i++)
			{
				if (Processors[i].name.Contains(processor))
				{
					Processors[i].Active = value;
					break;
				}
			}
		}

		internal void Verify(Animator animator)
		{
			for (int i = 0; i < Processors.Count; i++)
			{
				Processors[i].Validate(this, animator, i);
			}
		}
	}
}
