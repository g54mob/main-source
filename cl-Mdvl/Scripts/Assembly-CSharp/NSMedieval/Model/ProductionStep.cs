using System;
using System.Collections.Generic;
using Models.Production;
using NSEipix;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class ProductionStep : ISerializationCallbackReceiver
	{
		[SerializeField]
		private string type;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private float productionTime;

		[SerializeField]
		private bool interruptible;

		[SerializeField]
		private AttributeType modifyingAttribute;

		[SerializeField]
		private List<SkillValuePair> experienceReward;

		private ProductionStepType typeParsed;

		public ProductionStepType Type => typeParsed;

		public LocKeys[] LocKeys => locKeys;

		public float ProductionTime => productionTime;

		public bool Interruptible => interruptible;

		public AttributeType ModifyingAttribute => modifyingAttribute;

		public List<SkillValuePair> ExperienceReward => experienceReward;

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
			if (!string.IsNullOrEmpty(type))
			{
				string value = type.CapitalizeFirst();
				typeParsed = (ProductionStepType)Enum.Parse(typeof(ProductionStepType), value);
			}
		}
	}
}
