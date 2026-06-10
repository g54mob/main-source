using System;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.Structs
{
	[Serializable]
	[FVSerializableKey("CameraData", "")]
	public class CameraData : IFVSerializable
	{
		[SerializeField]
		private Vector3 position;

		[SerializeField]
		private float height;

		[SerializeField]
		private float rotation;

		[SerializeField]
		private float tilt;

		public Vector3 Position => position;

		public float Height => height;

		public float Rotation => rotation;

		public float Tilt => tilt;

		public CameraData(Vector3 position, float height, float rotation, float tilt)
		{
			this.position = position;
			this.height = height;
			this.rotation = rotation;
			this.tilt = tilt;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("position", position);
			serializer.Write("height", height);
			serializer.Write("rotation", rotation);
			serializer.Write("tilt", tilt);
		}

		public CameraData(FVDeserializer deserializer)
		{
			position = deserializer.ReadVector3("position");
			height = deserializer.ReadFloat("height");
			rotation = deserializer.ReadFloat("rotation");
			tilt = deserializer.ReadFloat("tilt");
		}
	}
}
