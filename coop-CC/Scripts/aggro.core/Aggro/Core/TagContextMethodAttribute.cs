using System;
using UnityEngine;

namespace Aggro.Core
{
	[AttributeUsage(AttributeTargets.Field)]
	public class TagContextMethodAttribute : PropertyAttribute
	{
		public readonly string methodName;

		public TagContextMethodAttribute(string methodName)
		{
			this.methodName = methodName;
		}
	}
}
