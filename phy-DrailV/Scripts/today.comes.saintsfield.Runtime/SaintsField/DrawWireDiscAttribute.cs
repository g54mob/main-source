using System;
using System.Diagnostics;
using SaintsField.Interfaces;
using SaintsField.Utils;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
	public class DrawWireDiscAttribute : PropertyAttribute, ISaintsAttribute
	{
		public readonly float Radius;

		public readonly string RadiusCallback;

		public readonly string Space;

		public readonly Vector3 Normal;

		public readonly string NormalCallback;

		public readonly Vector3 PosOffset;

		public readonly string PosOffsetCallback;

		public readonly Quaternion Rot;

		public readonly string RotCallback;

		public readonly Color Color;

		public readonly string ColorCallback;

		public SaintsAttributeType AttributeType => SaintsAttributeType.Other;

		public string GroupBy => "";

		public DrawWireDiscAttribute(float radius = 1f, string radisCallback = null, string space = "this", float norX = 0f, float norY = 0f, float norZ = 1f, string norCallback = null, float posXOffset = 0f, float posYOffset = 0f, float posZOffset = 0f, string posOffsetCallback = null, float rotX = 0f, float rotY = 0f, float rotZ = 0f, string rotCallback = null, EColor eColor = EColor.White, string color = null)
		{
			Radius = radius;
			RadiusCallback = radisCallback;
			Space = space;
			Normal = new Vector3(norX, norY, norZ);
			NormalCallback = norCallback;
			PosOffset = new Vector3(posXOffset, posYOffset, posZOffset);
			PosOffsetCallback = posOffsetCallback;
			Rot = Quaternion.Euler(rotX, rotY, rotZ);
			RotCallback = rotCallback;
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
