using System;
using UnityEngine;

namespace Helpers.Attributes
{
	[AttributeUsage(AttributeTargets.Field)]
	public class VectorRangeAttribute : PropertyAttribute
	{
		public float MinX = float.MinValue;

		public float MaxX = float.MaxValue;

		public float MinY = float.MinValue;

		public float MaxY = float.MaxValue;

		public float MinZ = float.MinValue;

		public float MaxZ = float.MaxValue;
	}
}
