using System;
using System.Collections.Generic;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Components.Base;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class AnimalLifePhase
	{
		[SerializeField]
		private string phaseName;

		[SerializeField]
		private string nameTextKey;

		[SerializeField]
		private FloatRange durationDays;

		[SerializeField]
		private float scaleStart;

		[SerializeField]
		private float scaleEnd;

		[SerializeField]
		private string carcassResourceId;

		[SerializeField]
		private int caravanStorageCapacity;

		[SerializeField]
		private StorageBase storageBase;

		[SerializeField]
		private string attributesList;

		[SerializeField]
		private List<string> productionsMale;

		[SerializeField]
		private List<string> productionsFemale;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private bool canBreed;

		private AttributesList attributesListCache;

		public string PhaseName => phaseName;

		public FloatRange DurationDays => durationDays;

		public float ScaleStart => scaleStart;

		public float ScaleEnd => scaleEnd;

		public string NameTextKey => nameTextKey;

		public string CarcassResourceId => carcassResourceId;

		public int CaravanStorageCapacity => caravanStorageCapacity;

		public StorageBase StorageBase => storageBase;

		public bool CanBreed => canBreed;

		public AttributesList AttributesList
		{
			get
			{
				if (attributesListCache == null)
				{
					attributesListCache = Repository<AttributesListRepository, AttributesList>.Instance.GetByID(attributesList);
					foreach (NSMedieval.StatsSystem.Attribute attribute in attributesListCache.Attributes)
					{
						NSMedieval.StatsSystem.Attribute byID = Repository<AttributeRepository, NSMedieval.StatsSystem.Attribute>.Instance.GetByID(attribute.GetID());
						attribute.CopyPropertiesFrom(byID);
					}
				}
				return attributesListCache;
			}
		}

		public LocKeys[] LocKeys => locKeys;

		public List<string> GetProductions(BodyType bodyType)
		{
			if (bodyType != BodyType.Female)
			{
				return productionsMale;
			}
			return productionsFemale;
		}
	}
}
