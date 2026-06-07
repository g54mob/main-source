using System;
using UnityEngine;

namespace Jundroo.ModTools.Attributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class HideInspectorLabelAttribute : PropertyAttribute
	{
	}
}
