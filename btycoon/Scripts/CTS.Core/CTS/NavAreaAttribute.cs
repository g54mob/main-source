using System;
using UnityEngine;

namespace CTS
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class NavAreaAttribute : PropertyAttribute
	{
		public bool IsFlag { get; }

		public NavAreaAttribute(bool isFlag = true)
		{
			IsFlag = isFlag;
		}
	}
}
