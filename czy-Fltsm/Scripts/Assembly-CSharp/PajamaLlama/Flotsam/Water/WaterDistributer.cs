using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Water
{
	public class WaterDistributer : BuildableExtendableBase
	{
		[Serializable]
		public class PersistentData : IBuildableExtendablePersistentData
		{
			private float _available;

			private float _refillThreshold;

			private float _refillAmount;

			private PersistentReference<Project>.Reference _importProject;

			[NonSerialized]
			private WaterDistributer _instance;

			[NonSerialized]
			private ItemDistributer _itemDistributer;

			public float Available => _available;

			public float RefillThreshold => _refillThreshold;

			public float RefillAmount => _refillAmount;

			public PersistentReference<Project>.Reference ImportProject => _importProject;

			public void PopulateReferences()
			{
				throw new NotSupportedException();
			}

			public void Restore()
			{
			}

			public void RestoreData(Buildable buildable)
			{
				if (!buildable.TryReturnBuildableExtendable<WaterDistributer>(out _instance) || !buildable.TryReturnBuildableExtendable<ItemDistributer>(out _itemDistributer))
				{
					Debug.LogError("Unable to restore WaterDistributer");
				}
			}

			public void RestoreReferences()
			{
				if (!(_instance == null) && !(_itemDistributer == null))
				{
					_itemDistributer.RestoreWaterDistributer(_instance, this);
				}
			}
		}

		[SerializeField]
		private ItemProperties _water;

		public ItemProperties Water => _water;

		public override IBuildableExtendablePersistentData ReturnPersistentData()
		{
			return null;
		}
	}
}
