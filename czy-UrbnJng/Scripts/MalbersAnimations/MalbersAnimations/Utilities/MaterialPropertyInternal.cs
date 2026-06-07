using System;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[Serializable]
	public class MaterialPropertyInternal
	{
		public string propertyName;

		public MaterialPropertyType propertyType;

		public float FloatValue = 1f;

		public Color ColorValue = Color.white;

		[ColorUsage(true, true)]
		public Color ColorHDRValue = Color.white;

		[HideInInspector]
		public bool isFloat;

		[HideInInspector]
		public bool isColor;

		[HideInInspector]
		public bool isColorHDR;
	}
}
