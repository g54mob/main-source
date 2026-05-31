using System;
using UnityEngine;

namespace Rewired.Utils.Attributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class FieldRangeAttribute : PropertyAttribute
	{
		private float szzYczHVflIMSoYoACGLLLvUeeyc;

		private float bcEyOviHCPyMHpPIrFcpJQpoqzK;

		private int hivNUEHDzrDRmulUQfqgDCJhGuEe;

		private int aFlBbQefhNnypacWAODVNpSPBwN;

		public float minFloat => szzYczHVflIMSoYoACGLLLvUeeyc;

		public float maxFloat => bcEyOviHCPyMHpPIrFcpJQpoqzK;

		public int minInt => hivNUEHDzrDRmulUQfqgDCJhGuEe;

		public int maxInt => aFlBbQefhNnypacWAODVNpSPBwN;

		public FieldRangeAttribute(float min, float max)
		{
			szzYczHVflIMSoYoACGLLLvUeeyc = min;
			bcEyOviHCPyMHpPIrFcpJQpoqzK = max;
			hivNUEHDzrDRmulUQfqgDCJhGuEe = (int)min;
			aFlBbQefhNnypacWAODVNpSPBwN = (int)max;
		}

		public FieldRangeAttribute(int min, int max)
		{
			hivNUEHDzrDRmulUQfqgDCJhGuEe = min;
			aFlBbQefhNnypacWAODVNpSPBwN = max;
			szzYczHVflIMSoYoACGLLLvUeeyc = min;
			bcEyOviHCPyMHpPIrFcpJQpoqzK = max;
		}
	}
}
