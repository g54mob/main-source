using System;
using UnityEngine;

namespace Cainos.LucidEditor
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field, AllowMultiple = true)]
	public class GUIColorAttribute : Attribute
	{
		public readonly InspectorColor color;

		public readonly bool useCustomColor;

		public readonly Color customColor;

		public GUIColorAttribute()
		{
		}

		public GUIColorAttribute(InspectorColor color)
		{
		}

		public GUIColorAttribute(float r, float g, float b)
		{
		}

		public GUIColorAttribute(float r, float g, float b, float a)
		{
		}
	}
}
