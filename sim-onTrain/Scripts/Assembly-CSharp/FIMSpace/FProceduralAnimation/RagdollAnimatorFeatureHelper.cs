using System;
using System.Collections.Generic;
using FIMSpace.FGenerating;
using UnityEngine;
using UnityEngine.Events;

namespace FIMSpace.FProceduralAnimation
{
	[Serializable]
	public class RagdollAnimatorFeatureHelper
	{
		[Tooltip("Displaying this name instead of feature class name in GUI + giving possibility to get feature from the ragdoll handler using this name.")]
		[HideInInspector]
		public string CustomName = "";

		[SerializeField]
		[HideInInspector]
		private bool enabled = true;

		[NonSerialized]
		private RagdollHandler handler;

		public RagdollAnimatorFeatureBase FeatureReference;

		[SerializeField]
		[HideInInspector]
		public List<string> customStringList;

		[SerializeField]
		[HideInInspector]
		public List<UnityEngine.Object> customObjectList;

		[SerializeField]
		[HideInInspector]
		public List<UnityEvent> customEventsList;

		[SerializeField]
		private List<FUniversalVariable> variables = new List<FUniversalVariable>();

		public bool Enabled
		{
			get
			{
				return enabled;
			}
			set
			{
				if (enabled != value)
				{
					enabled = value;
					if ((bool)RuntimeFeature)
					{
						RuntimeFeature.OnEnabledSwitch();
					}
				}
			}
		}

		public RagdollHandler ParentRagdollHandler => handler;

		[field: NonSerialized]
		public RagdollAnimatorFeatureBase RuntimeFeature { get; private set; }

		public RagdollAnimatorFeatureBase ActiveFeature => RuntimeFeature;

		internal void Init(RagdollHandler handler)
		{
			this.handler = handler;
			if (!(FeatureReference == null))
			{
				PreparePlaymodeModule(handler);
			}
		}

		public void PreparePlaymodeModule(RagdollHandler parent)
		{
			if (!(RuntimeFeature != null) && !(FeatureReference == null))
			{
				RuntimeFeature = UnityEngine.Object.Instantiate(FeatureReference);
				RuntimeFeature.Base_Init(parent, this);
			}
		}

		public void DisposeRagdollFeature()
		{
			if (RuntimeFeature != null)
			{
				RuntimeFeature.OnDestroyFeature();
				UnityEngine.Object.Destroy(RuntimeFeature);
			}
			RuntimeFeature = null;
		}

		public FUniversalVariable RequestVariable(string name, object defaultValue)
		{
			if (variables == null)
			{
				variables = new List<FUniversalVariable>();
			}
			int hashCode = name.GetHashCode();
			for (int i = 0; i < variables.Count; i++)
			{
				if (variables[i].GetNameHash == hashCode)
				{
					return variables[i];
				}
			}
			FUniversalVariable fUniversalVariable = new FUniversalVariable(name, defaultValue);
			variables.Add(fUniversalVariable);
			return fUniversalVariable;
		}

		public bool HasVariable(string name)
		{
			if (variables == null)
			{
				return false;
			}
			int hashCode = name.GetHashCode();
			for (int i = 0; i < variables.Count; i++)
			{
				if (variables[i].GetNameHash == hashCode)
				{
					return true;
				}
			}
			return false;
		}

		public void CopySettingsFrom(RagdollAnimatorFeatureHelper copyFrom)
		{
			if (copyFrom == null || copyFrom.FeatureReference == null)
			{
				return;
			}
			if (FeatureReference == null)
			{
				FeatureReference = copyFrom.FeatureReference;
			}
			if (FeatureReference.GetType() != copyFrom.FeatureReference.GetType())
			{
				return;
			}
			foreach (FUniversalVariable variable in copyFrom.variables)
			{
				RequestVariable(variable.VariableName, variable.GetValue());
			}
		}
	}
}
