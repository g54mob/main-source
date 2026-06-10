using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.Model.MapNew
{
	[Serializable]
	[FVSerializableKey("VoxelTypeDistribution", "")]
	public class VoxelTypeDistribution : NSEipix.Base.Model, IFVSerializable
	{
		[SerializeField]
		private string id = string.Empty;

		[SerializeField]
		private float percent;

		[SerializeField]
		private int minCount;

		[SerializeField]
		private int maxCount;

		[SerializeField]
		private List<string> storeInside;

		[SerializeField]
		private bool awayFromEdge;

		public float Percent => percent;

		public int MinCount => minCount;

		public int MaxCount => maxCount;

		public List<string> StoreInside => storeInside;

		public bool AwayFromEdge => awayFromEdge;

		public override string GetID()
		{
			return id;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("id", id);
			serializer.Write("percent", percent);
			serializer.Write("minCount", minCount);
			serializer.Write("maxCount", maxCount);
			serializer.Write("storeInside", storeInside);
			serializer.Write("awayFromEdge", awayFromEdge);
		}

		public VoxelTypeDistribution(FVDeserializer deserializer)
		{
			id = deserializer.ReadString("id");
			percent = deserializer.ReadFloat("percent");
			minCount = deserializer.ReadInt("minCount");
			maxCount = deserializer.ReadInt("maxCount");
			storeInside = deserializer.ReadStringList("storeInside");
			awayFromEdge = deserializer.ReadBool("awayFromEdge");
		}
	}
}
