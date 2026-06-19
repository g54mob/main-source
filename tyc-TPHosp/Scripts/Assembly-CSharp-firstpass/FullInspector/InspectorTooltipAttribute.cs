using System;
using System.Reflection;
using FullSerializer.Internal;

namespace FullInspector
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class InspectorTooltipAttribute : Attribute
	{
		public string Tooltip;

		public InspectorTooltipAttribute(string tooltip)
		{
			Tooltip = tooltip ?? "";
		}

		public static string GetTooltip(MemberInfo memberInfo)
		{
			InspectorTooltipAttribute attribute = fsPortableReflection.GetAttribute<InspectorTooltipAttribute>(memberInfo);
			if (attribute == null)
			{
				return "";
			}
			return attribute.Tooltip;
		}
	}
}
