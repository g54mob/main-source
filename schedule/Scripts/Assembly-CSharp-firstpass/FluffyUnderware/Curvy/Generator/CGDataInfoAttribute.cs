using System;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator
{
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class CGDataInfoAttribute : Attribute
	{
		public readonly Color Color;

		public CGDataInfoAttribute(Color color)
		{
		}

		public CGDataInfoAttribute(float r, float g, float b, float a = 1f)
		{
		}

		public CGDataInfoAttribute(string htmlColor)
		{
		}
	}
}
