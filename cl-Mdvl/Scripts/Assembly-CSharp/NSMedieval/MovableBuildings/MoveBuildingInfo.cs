using System;
using NSMedieval.BuildingComponents;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.MovableBuildings
{
	[Serializable]
	[FVSerializableKey("MoveBuildingInfo", "")]
	public class MoveBuildingInfo : IFVSerializable
	{
		[SerializeField]
		private BaseBuildingInstance newBuilding;

		[SerializeField]
		private BaseBuildingInstance oldBuilding;

		public BaseBuildingInstance NewBuilding => newBuilding;

		public BaseBuildingInstance OldBuilding => oldBuilding;

		public MoveBuildingInfo(BaseBuildingInstance newBuilding, BaseBuildingInstance oldBuilding)
		{
			this.newBuilding = newBuilding;
			this.oldBuilding = oldBuilding;
		}

		public MoveBuildingInfo()
		{
		}

		public void EraseOldBuilding()
		{
			oldBuilding = null;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("newBuilding", newBuilding);
			serializer.Write("oldBuilding", oldBuilding);
		}

		public MoveBuildingInfo(FVDeserializer deserializer)
		{
			newBuilding = deserializer.ReadObject<BaseBuildingInstance>("newBuilding");
			oldBuilding = deserializer.ReadObject<BaseBuildingInstance>("oldBuilding");
		}
	}
}
