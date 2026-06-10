using System;
using UnityEngine;

namespace Rewired.Utils.Attributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class FieldRangeAttribute : PropertyAttribute
	{
		private float agLBLIOGOdtBJPtYwJxGdtUFdLt;

		private float lbkflOzOtZlPSIHwJiBgzdIvZYB;

		private int lXVTelMjGtCSxiPcwbBfNaksSTRJ;

		private int gYZYIrlWAJCpwVTamccWdnfKHyUC;

		public float minFloat => 0f;

		public float maxFloat => 0f;

		public int minInt => 0;

		public int maxInt => 0;

		public FieldRangeAttribute(float min, float max)
		{
		}

		public FieldRangeAttribute(int min, int max)
		{
		}
	}
}
