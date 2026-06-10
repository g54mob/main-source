using System;
using NSEipix.Base;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class ShelfTransformSettings : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private TransformSettings[] transformSettingsArray;

		[SerializeField]
		private string[] forcedItemsPrefabIds;

		public TransformSettings[] TransformSettingsArray => transformSettingsArray;

		public string[] ForcedItemsPrefabIds => forcedItemsPrefabIds;

		public override string GetID()
		{
			return id;
		}
	}
}
