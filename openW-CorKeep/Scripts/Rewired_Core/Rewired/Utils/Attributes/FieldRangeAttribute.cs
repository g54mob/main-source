using System;
using UnityEngine;

namespace Rewired.Utils.Attributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class FieldRangeAttribute : PropertyAttribute
	{
		private float VkmPTxxkeozLAPLVYyODetfniLcT;

		private float CdNPltIiGWSwhkPSzGgAJLxPjGdv;

		private int pFOfrmSFPWIXfeSDpuvRnoQpGkzn;

		private int PkBsvLkVPlhJhNaHYIJjhMdGYzNTA;

		public float minFloat => VkmPTxxkeozLAPLVYyODetfniLcT;

		public float maxFloat => CdNPltIiGWSwhkPSzGgAJLxPjGdv;

		public int minInt => pFOfrmSFPWIXfeSDpuvRnoQpGkzn;

		public int maxInt => PkBsvLkVPlhJhNaHYIJjhMdGYzNTA;

		public FieldRangeAttribute(float P_0, float P_1)
		{
			VkmPTxxkeozLAPLVYyODetfniLcT = P_0;
			CdNPltIiGWSwhkPSzGgAJLxPjGdv = P_1;
			pFOfrmSFPWIXfeSDpuvRnoQpGkzn = (int)P_0;
			PkBsvLkVPlhJhNaHYIJjhMdGYzNTA = (int)P_1;
		}

		public FieldRangeAttribute(int P_0, int P_1)
		{
			pFOfrmSFPWIXfeSDpuvRnoQpGkzn = P_0;
			PkBsvLkVPlhJhNaHYIJjhMdGYzNTA = P_1;
			VkmPTxxkeozLAPLVYyODetfniLcT = P_0;
			CdNPltIiGWSwhkPSzGgAJLxPjGdv = P_1;
		}
	}
}
