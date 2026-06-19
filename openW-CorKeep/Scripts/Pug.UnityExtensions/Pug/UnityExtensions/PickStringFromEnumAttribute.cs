using System;
using UnityEngine;

namespace Pug.UnityExtensions
{
	[AttributeUsage(AttributeTargets.Field)]
	public class PickStringFromEnumAttribute : PropertyAttribute
	{
		public Type EnumType { get; }

		public PickStringFromEnumAttribute(Type enumType)
		{
			EnumType = enumType;
		}
	}
}
