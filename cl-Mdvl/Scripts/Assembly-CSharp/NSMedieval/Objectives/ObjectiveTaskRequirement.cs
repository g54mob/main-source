using System;
using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval.Objectives
{
	[Serializable]
	public class ObjectiveTaskRequirement
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private string type;

		[SerializeField]
		private int[] plantLifePhases;

		[SerializeField]
		private string modelId;

		[SerializeField]
		private int minCount;

		[SerializeField]
		private int minLevel;

		[SerializeField]
		private string roomType;

		[SerializeField]
		private bool includeCountInText;

		[NonSerialized]
		private bool typeCacheInit;

		[NonSerialized]
		private ObjectiveTaskRequirementType typeCache;

		[NonSerialized]
		private bool plantLifePhasesCacheInit;

		[NonSerialized]
		private HashSet<int> plantLifePhasesCache;

		public string Id => id;

		public ObjectiveTaskRequirementType Type
		{
			get
			{
				if (!typeCacheInit)
				{
					typeCache = Enum.Parse<ObjectiveTaskRequirementType>(type);
					typeCacheInit = true;
				}
				return typeCache;
			}
		}

		public string ModelId => modelId;

		public int MinCount => minCount;

		public int MinLevel => minLevel;

		public string RoomType => roomType;

		public bool IncludeCountInText => includeCountInText;

		public HashSet<int> PlantLifePhases
		{
			get
			{
				if (!plantLifePhasesCacheInit)
				{
					plantLifePhasesCache = new HashSet<int>(plantLifePhases);
					plantLifePhasesCacheInit = true;
				}
				return plantLifePhasesCache;
			}
		}

		public override string ToString()
		{
			return id;
		}
	}
}
