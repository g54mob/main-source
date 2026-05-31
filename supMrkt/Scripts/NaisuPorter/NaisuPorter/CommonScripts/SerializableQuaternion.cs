using System;
using UnityEngine;

namespace NaisuPorter.CommonScripts
{
	[Serializable]
	public class SerializableQuaternion
	{
		public float x;

		public float y;

		public float z;

		public float w;

		public SerializableQuaternion(Quaternion initialValue)
		{
		}

		public static implicit operator SerializableQuaternion(Quaternion rot)
		{
			return null;
		}

		public static implicit operator Quaternion(SerializableQuaternion sRot)
		{
			return default(Quaternion);
		}
	}
}
