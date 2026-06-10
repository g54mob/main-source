using System;
using NSEipix.Base;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class BuildingEventProp : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private string eventPropsPrefabId;

		[SerializeField]
		private TransformSettings[] storagePositions;

		public string EventPropsPrefabId => eventPropsPrefabId;

		public TransformSettings[] StoragePositions => storagePositions;

		public override string GetID()
		{
			return id;
		}
	}
}
