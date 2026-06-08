using System;
using MessagePack;
using UnityEngine;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct SerializableQuaternion
	{
		[Key(0)]
		public float x;

		[Key(1)]
		public float y;

		[Key(2)]
		public float z;

		[Key(3)]
		public float w;

		[SerializationConstructor]
		public SerializableQuaternion(float X, float Y, float Z, float W)
		{
			x = X;
			y = Y;
			z = Z;
			w = W;
		}

		public SerializableQuaternion(Quaternion quaternion)
		{
			x = quaternion.x;
			y = quaternion.y;
			z = quaternion.z;
			w = quaternion.w;
		}

		public Quaternion ToQuaternion()
		{
			return new Quaternion(x, y, z, w);
		}
	}
}
