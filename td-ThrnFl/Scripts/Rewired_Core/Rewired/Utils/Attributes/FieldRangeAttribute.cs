using System;
using UnityEngine;

namespace Rewired.Utils.Attributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class FieldRangeAttribute : PropertyAttribute
	{
		private float kNKSmEJFPyvKfFrupbzTnnEsYtfl;

		private float lqlSSYmnnKdrAqdpYeZUcEEMtZeY;

		private int UyNUZFycUYYGeDkGVAZecdksjoT;

		private int iOrXMeGQkfnEQVbeftanZbCPhaMFA;

		public float minFloat => kNKSmEJFPyvKfFrupbzTnnEsYtfl;

		public float maxFloat => lqlSSYmnnKdrAqdpYeZUcEEMtZeY;

		public int minInt => UyNUZFycUYYGeDkGVAZecdksjoT;

		public int maxInt => iOrXMeGQkfnEQVbeftanZbCPhaMFA;

		public FieldRangeAttribute(float P_0, float P_1)
		{
			kNKSmEJFPyvKfFrupbzTnnEsYtfl = P_0;
			lqlSSYmnnKdrAqdpYeZUcEEMtZeY = P_1;
			UyNUZFycUYYGeDkGVAZecdksjoT = (int)P_0;
			iOrXMeGQkfnEQVbeftanZbCPhaMFA = (int)P_1;
		}

		public FieldRangeAttribute(int P_0, int P_1)
		{
			UyNUZFycUYYGeDkGVAZecdksjoT = P_0;
			iOrXMeGQkfnEQVbeftanZbCPhaMFA = P_1;
			kNKSmEJFPyvKfFrupbzTnnEsYtfl = P_0;
			lqlSSYmnnKdrAqdpYeZUcEEMtZeY = P_1;
		}
	}
}
