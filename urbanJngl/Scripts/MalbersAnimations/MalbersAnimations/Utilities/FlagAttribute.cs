using System;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
	public class FlagAttribute : PropertyAttribute
	{
		public string enumName;

		public FlagAttribute()
		{
		}

		public FlagAttribute(string name)
		{
			enumName = name;
		}
	}
}
