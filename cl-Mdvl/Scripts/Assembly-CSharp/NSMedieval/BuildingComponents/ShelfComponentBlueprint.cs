using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Enums;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class ShelfComponentBlueprint : NSEipix.Base.Model
	{
		private readonly BuildingType componentType = BuildingType.Decoration;

		[SerializeField]
		private string id;

		[SerializeField]
		private List<string> storageIDs = new List<string>();

		[SerializeField]
		private bool hideBeautyContent;

		[SerializeField]
		private bool animalFeeder;

		[SerializeField]
		private bool prisonFeeder;

		[SerializeField]
		private bool barrel;

		[SerializeField]
		private List<LockStateData> lockStates;

		[SerializeField]
		private ShelfSize shelfSize;

		[SerializeField]
		private ShelfTransformSettings[] multipleTransformSettingsArray;

		[SerializeField]
		private bool rainproof;

		public BuildingType ComponentType => componentType;

		public List<string> StorageIDs => storageIDs;

		public bool AnimalFeeder => animalFeeder;

		public bool PrisonFeeder => prisonFeeder;

		public bool Barrel => barrel;

		public List<LockStateData> LockStates => lockStates;

		public bool HideBeautyContent => hideBeautyContent;

		public LockState DefaultLockState => LockState.Locked;

		public ShelfSize ShelfSize => shelfSize;

		public bool Rainproof => rainproof;

		public bool HasShelfTransformSettings(int index, out ShelfTransformSettings settings)
		{
			settings = null;
			if (multipleTransformSettingsArray == null || multipleTransformSettingsArray.Length <= index)
			{
				return false;
			}
			settings = multipleTransformSettingsArray[index];
			return true;
		}

		public override string GetID()
		{
			return id;
		}
	}
}
