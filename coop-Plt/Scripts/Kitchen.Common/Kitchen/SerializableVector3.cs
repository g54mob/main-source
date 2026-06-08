using System;
using MessagePack;
using UnityEngine;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct SerializableVector3
	{
		[Key(0)]
		public float x;

		[Key(1)]
		public float y;

		[Key(2)]
		public float z;

		[SerializationConstructor]
		public SerializableVector3(float X, float Y, float Z)
		{
			x = X;
			y = Y;
			z = Z;
		}

		public SerializableVector3(Vector3 vector)
		{
			x = vector.x;
			y = vector.y;
			z = vector.z;
		}

		public Vector3 ToVector3()
		{
			return new Vector3(x, y, z);
		}
	}
}
