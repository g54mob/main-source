using System;
using System.Reflection;
using FullSerializer.Internal;

namespace FullInspector
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class InspectorOrderAttribute : Attribute
	{
		public double Order;

		public InspectorOrderAttribute(double order)
		{
			Order = order;
		}

		public static double GetInspectorOrder(MemberInfo memberInfo)
		{
			return fsPortableReflection.GetAttribute<InspectorOrderAttribute>(memberInfo)?.Order ?? double.MaxValue;
		}
	}
}
