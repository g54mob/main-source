using System;
using UnityEngine;

namespace NaisuPorter.CommonScripts
{
	[Serializable]
	public class SerializableVector3
	{
		public float x;

		public float y;

		public float z;

		public SerializableVector3(Vector3 initialValue)
		{
		}

		public SerializableVector3(float xValue, float yValue, float zValue)
		{
		}

		public static implicit operator SerializableVector3(Vector3 vector)
		{
			return null;
		}

		public static implicit operator Vector3(SerializableVector3 sVector)
		{
			return default(Vector3);
		}
	}
}
