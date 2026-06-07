using System;
using UnityEngine;

namespace Rewired.Utils.Attributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class FieldRangeAttribute : PropertyAttribute
	{
		private float XrgDdSVbGNKxAYVtSZOJaemZJazU;

		private float KDFrOAuGynzIbrKcrlhYRBqflxqh;

		private int xlCFtTDepfiUpbhhcfcNXrPTRTiJb;

		private int TDNzdkOafGKqpMSvSQqfCCakQtEh;

		public float minFloat => XrgDdSVbGNKxAYVtSZOJaemZJazU;

		public float maxFloat => KDFrOAuGynzIbrKcrlhYRBqflxqh;

		public int minInt => xlCFtTDepfiUpbhhcfcNXrPTRTiJb;

		public int maxInt => TDNzdkOafGKqpMSvSQqfCCakQtEh;

		public FieldRangeAttribute(float P_0, float P_1)
		{
			XrgDdSVbGNKxAYVtSZOJaemZJazU = P_0;
			KDFrOAuGynzIbrKcrlhYRBqflxqh = P_1;
			xlCFtTDepfiUpbhhcfcNXrPTRTiJb = (int)P_0;
			TDNzdkOafGKqpMSvSQqfCCakQtEh = (int)P_1;
		}

		public FieldRangeAttribute(int P_0, int P_1)
		{
			xlCFtTDepfiUpbhhcfcNXrPTRTiJb = P_0;
			TDNzdkOafGKqpMSvSQqfCCakQtEh = P_1;
			XrgDdSVbGNKxAYVtSZOJaemZJazU = P_0;
			KDFrOAuGynzIbrKcrlhYRBqflxqh = P_1;
		}
	}
}
