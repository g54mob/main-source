using System;
using System.Diagnostics;
using SaintsField.Interfaces;
using SaintsField.Utils;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
	public class SphereHandleCapAttribute : PropertyAttribute, ISaintsAttribute
	{
		public readonly float Radius;

		public readonly string RadiusCallback;

		public readonly string Space;

		public readonly Vector3 PosOffset;

		public readonly string PosOffsetCallback;

		public readonly Color Color;

		public readonly string ColorCallback;

		public SaintsAttributeType AttributeType => SaintsAttributeType.Other;

		public string GroupBy => "";

		public SphereHandleCapAttribute(float radius = 1f, string radiusCallback = null, string space = "this", float posXOffset = 0f, float posYOffset = 0f, float posZOffset = 0f, string posOffsetCallback = null, EColor eColor = EColor.White, string color = null)
		{
			Radius = radius;
			RadiusCallback = radiusCallback;
			Space = space;
			PosOffset = new Vector3(posXOffset, posYOffset, posZOffset);
			PosOffsetCallback = posOffsetCallback;
			Color = eColor.GetColor();
			bool flag = !string.IsNullOrEmpty(color);
			ColorCallback = null;
			if (flag && color.StartsWith("#"))
			{
				if (!ColorUtility.TryParseHtmlString(color, out var color2))
				{
					throw new Exception("Color " + color + " is not a valid color");
				}
				Color = color2;
			}
			else if (flag)
			{
				string item = RuntimeUtil.ParseCallback(color).content;
				ColorCallback = item;
			}
		}
	}
}
