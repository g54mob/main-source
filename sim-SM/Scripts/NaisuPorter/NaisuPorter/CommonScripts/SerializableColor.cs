using System;
using UnityEngine;

namespace NaisuPorter.CommonScripts
{
	[Serializable]
	public class SerializableColor
	{
		public float r;

		public float g;

		public float b;

		public float a;

		public SerializableColor(Color initialValue)
		{
		}

		public SerializableColor(float r, float g, float b, float a)
		{
		}

		public static implicit operator SerializableColor(Color color)
		{
			return null;
		}

		public static implicit operator Color(SerializableColor sColor)
		{
			return default(Color);
		}
	}
}
