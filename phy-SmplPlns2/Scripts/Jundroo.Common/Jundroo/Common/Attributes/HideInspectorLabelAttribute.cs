using System;
using UnityEngine;

namespace Jundroo.Common.Attributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class HideInspectorLabelAttribute : PropertyAttribute
	{
	}
}
