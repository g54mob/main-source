using System;
using UnityEngine;

namespace MalbersAnimations
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
	public sealed class SubclassSelectorAttribute : PropertyAttribute
	{
	}
}
