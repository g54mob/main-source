using System;
using UnityEngine;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
	public class TypeRegistryItemAttribute : Attribute
	{
		public string Name;

		public string CategoryPath;

		public SdfIconType Icon;

		public Color? LightIconColor;

		public Color? DarkIconColor;

		public int Priority;

		public TypeRegistryItemAttribute(string name = null, string categoryPath = null, SdfIconType icon = SdfIconType.None, float lightIconColorR = 0f, float lightIconColorG = 0f, float lightIconColorB = 0f, float lightIconColorA = 0f, float darkIconColorR = 0f, float darkIconColorG = 0f, float darkIconColorB = 0f, float darkIconColorA = 0f, int priority = 0)
		{
		}
	}
}
