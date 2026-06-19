using System;
using UnityEngine;

namespace Rewired.Utils.Attributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class FieldRangeAttribute : PropertyAttribute
	{
		private float OtFKVTwbAcWfMdbQZlSWLYUeiqY;

		private float PVyghHHGnKzfNeNoejwqVSQCvju;

		private int XbVcZwqClmkiwlerFkvzAsfLyEc;

		private int YONKywRIYKNcfvqnZDuIVnlfHpn;

		public float minFloat => OtFKVTwbAcWfMdbQZlSWLYUeiqY;

		public float maxFloat => PVyghHHGnKzfNeNoejwqVSQCvju;

		public int minInt => XbVcZwqClmkiwlerFkvzAsfLyEc;

		public int maxInt => YONKywRIYKNcfvqnZDuIVnlfHpn;

		public FieldRangeAttribute(float min, float max)
		{
			OtFKVTwbAcWfMdbQZlSWLYUeiqY = min;
			PVyghHHGnKzfNeNoejwqVSQCvju = max;
			XbVcZwqClmkiwlerFkvzAsfLyEc = (int)min;
			YONKywRIYKNcfvqnZDuIVnlfHpn = (int)max;
		}

		public FieldRangeAttribute(int min, int max)
		{
			XbVcZwqClmkiwlerFkvzAsfLyEc = min;
			YONKywRIYKNcfvqnZDuIVnlfHpn = max;
			OtFKVTwbAcWfMdbQZlSWLYUeiqY = min;
			PVyghHHGnKzfNeNoejwqVSQCvju = max;
		}
	}
}
