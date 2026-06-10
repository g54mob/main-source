using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	public class StatEffector : NSEipix.Base.Model, ISerializationCallbackReceiver
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private EffectDetailsHolder[] effects;

		[SerializeField]
		private float duration;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private int maxStack;

		[SerializeField]
		private float stackMultiplier = 1f;

		[SerializeField]
		private string category;

		[SerializeField]
		private bool isInstant;

		[SerializeField]
		private float triggerFailChance;

		[SerializeField]
		private EffectorUiGroup uiGroup;

		[SerializeField]
		private string bubbleIcon;

		[SerializeField]
		private bool dontSave;

		[SerializeField]
		private bool isDisabled;

		[NonSerialized]
		private List<EffectorBase> instances = new List<EffectorBase>();

		public LocKeys[] LocKeys => locKeys;

		public bool IsDisabled => isDisabled;

		public bool DontSave => dontSave;

		public float Duration
		{
			get
			{
				return duration;
			}
			protected set
			{
				duration = value;
			}
		}

		public int MaxStack => maxStack;

		public float StackMultiplier => stackMultiplier;

		public string Category => category;

		public bool IsInstant => isInstant;

		public EffectDetailsHolder[] Effects => effects;

		public string BubbleIcon => bubbleIcon;

		internal List<EffectorBase> Instances => instances;

		public EffectorUiGroup UIGroup => uiGroup;

		public float TriggerFailChance => triggerFailChance;

		public bool IsReligious
		{
			get
			{
				EffectDetailsHolder[] array = effects;
				foreach (EffectDetailsHolder effectDetailsHolder in array)
				{
					if (effectDetailsHolder.Type == EffectorType.StatModifyCurrent && effectDetailsHolder.Parameters.Any((KeyValuePair<string, string> kvp) => kvp.Key == "stat" && (kvp.Value == 14.ToString() || kvp.Value == StatType.ReligiousAlignment.ToString())))
					{
						return true;
					}
				}
				return false;
			}
		}

		public static List<StatEffector> GetEffectorsObjectsList(string[] names)
		{
			List<StatEffector> list = new List<StatEffector>();
			foreach (string text in names)
			{
				StatEffector byID = Repository<EffectorRepository, StatEffector>.Instance.GetByID(text);
				if (!(byID == null))
				{
					list.Add(byID);
				}
			}
			return list;
		}

		public override string GetID()
		{
			return id;
		}

		public virtual void OnAfterDeserialize()
		{
			GenerateEffectInstances();
		}

		public void OnBeforeSerialize()
		{
		}

		protected virtual void GenerateEffectInstances()
		{
			if (effects == null)
			{
				return;
			}
			instances = new List<EffectorBase>();
			for (int i = 0; i < effects.Length; i++)
			{
				if (!EffectorsMap.Constuctors.ContainsKey(effects[i].Type))
				{
					Log.Warning("Effect " + effects[i].Type.ToString() + " has no implementation!", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Model\\StatEffector.cs");
					continue;
				}
				EffectorBase effectorBase = (EffectorBase)(EffectorsMap.Constuctors[effects[i].Type]?.Invoke(new object[1] { this }));
				effectorBase.InitParameters(effects[i].Parameters);
				instances.Add(effectorBase);
			}
		}
	}
}
