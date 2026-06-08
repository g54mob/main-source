using System;
using MessagePack;
using UnityEngine;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct SerializableColor
	{
		[Key(0)]
		public float r;

		[Key(1)]
		public float g;

		[Key(2)]
		public float b;

		[Key(3)]
		public float a;

		[SerializationConstructor]
		public SerializableColor(float R, float G, float B, float A)
		{
			r = R;
			g = G;
			b = B;
			a = A;
		}

		public SerializableColor(Color color)
		{
			r = color.r;
			g = color.g;
			b = color.b;
			a = color.a;
		}

		public Color ToColor()
		{
			return new Color(r, g, b, a);
		}
	}
}
