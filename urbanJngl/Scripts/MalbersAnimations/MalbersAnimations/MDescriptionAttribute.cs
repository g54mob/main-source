using System;
using UnityEngine;

namespace MalbersAnimations
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
	public sealed class MDescriptionAttribute : PropertyAttribute
	{
		public string Description { get; }

		public MDescriptionAttribute(string menuName)
		{
			Description = menuName;
		}
	}
}
