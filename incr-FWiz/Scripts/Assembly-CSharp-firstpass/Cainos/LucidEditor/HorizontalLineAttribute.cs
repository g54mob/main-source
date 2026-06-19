using System;
using UnityEngine;

namespace Cainos.LucidEditor
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field, AllowMultiple = true)]
	public class HorizontalLineAttribute : Attribute
	{
		public readonly InspectorColor color;

		public readonly bool useCustomColor;

		public readonly Color customColor;

		public HorizontalLineAttribute()
		{
		}

		public HorizontalLineAttribute(InspectorColor color)
		{
		}

		public HorizontalLineAttribute(float r, float g, float b)
		{
		}

		public HorizontalLineAttribute(float r, float g, float b, float a)
		{
		}
	}
}
