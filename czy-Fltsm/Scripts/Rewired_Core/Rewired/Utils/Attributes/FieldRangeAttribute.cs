using System;
using UnityEngine;

namespace Rewired.Utils.Attributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class FieldRangeAttribute : PropertyAttribute
	{
		private float LpoyLeBoOqnVisLzTnJkvmtORMcs;

		private float YbNArijmeAPiDcDoirptCwrsyFfu;

		private int zZMnexkpbGXzLDdSgehmuKBWzZfE;

		private int NoZtpEYHldVXTwYhDWKOTNvfbcXIA;

		public float minFloat => LpoyLeBoOqnVisLzTnJkvmtORMcs;

		public float maxFloat => YbNArijmeAPiDcDoirptCwrsyFfu;

		public int minInt => zZMnexkpbGXzLDdSgehmuKBWzZfE;

		public int maxInt => NoZtpEYHldVXTwYhDWKOTNvfbcXIA;

		public FieldRangeAttribute(float P_0, float P_1)
		{
			LpoyLeBoOqnVisLzTnJkvmtORMcs = P_0;
			YbNArijmeAPiDcDoirptCwrsyFfu = P_1;
			zZMnexkpbGXzLDdSgehmuKBWzZfE = (int)P_0;
			NoZtpEYHldVXTwYhDWKOTNvfbcXIA = (int)P_1;
		}

		public FieldRangeAttribute(int P_0, int P_1)
		{
			zZMnexkpbGXzLDdSgehmuKBWzZfE = P_0;
			NoZtpEYHldVXTwYhDWKOTNvfbcXIA = P_1;
			LpoyLeBoOqnVisLzTnJkvmtORMcs = P_0;
			YbNArijmeAPiDcDoirptCwrsyFfu = P_1;
		}
	}
}
