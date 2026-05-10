using System;
using UnityEngine;

namespace NaisuPorter.CommonScripts
{
	[Serializable]
	public class SerializableVector2
	{
		public float x;

		public float y;

		public SerializableVector2(Vector2 initialValue)
		{
		}

		public SerializableVector2(float xValue, float yValue)
		{
		}

		public static implicit operator SerializableVector2(Vector2 vector)
		{
			return null;
		}

		public static implicit operator Vector2(SerializableVector2 sVector)
		{
			return default(Vector2);
		}
	}
}
