using System;
using UnityEngine;

namespace Shapes
{
	[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
	public sealed class ShapesColorFieldAttribute : PropertyAttribute
	{
		public readonly bool showAlpha = true;

		public ShapesColorFieldAttribute(bool showAlpha)
		{
			this.showAlpha = showAlpha;
		}
	}
}
