using System;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Repository;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class AnimalProduction : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private bool autoSpawn;

		[SerializeField]
		private string harvestAnimationId;

		[SerializeField]
		private float productionDuration;

		[SerializeField]
		private float harvestDuration;

		[SerializeField]
		private string productId;

		[SerializeField]
		private int amountToSpawn;

		[SerializeField]
		private int harvestXp;

		[SerializeField]
		private LocKeys[] locKeys;

		private Resource resource;

		public bool AutoSpawn => autoSpawn;

		public string HarvestAnimationId => harvestAnimationId;

		public float ProductionDuration => productionDuration;

		public float HarvestDuration => harvestDuration;

		public string ProductId => productId;

		public int AmountToSpawn => amountToSpawn;

		public int HarvestXp => harvestXp;

		public Resource Resource
		{
			get
			{
				if (resource == null)
				{
					resource = Repository<ResourceRepository, Resource>.Instance.GetByID(productId);
				}
				return resource;
			}
		}

		public LocKeys[] LocKeys => locKeys;

		public override string GetID()
		{
			return id;
		}
	}
}
