using System;
using NSEipix.Repository;
using NSMedieval.Repository;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class WalkableModelProvider
	{
		[SerializeField]
		private string walkableModelBlueprintId;

		[NonSerialized]
		private WalkableModel walkableModelCache;

		[NonSerialized]
		private bool walkableModelOInitialized;

		public WalkableModel WalkableModel
		{
			get
			{
				if (!walkableModelOInitialized)
				{
					walkableModelOInitialized = true;
					walkableModelCache = Repository<WalkableModelRepository, WalkableModel>.Instance.GetByID(walkableModelBlueprintId);
				}
				return walkableModelCache;
			}
		}
	}
}
