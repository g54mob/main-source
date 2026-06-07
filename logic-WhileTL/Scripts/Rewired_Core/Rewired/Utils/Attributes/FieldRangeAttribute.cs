using System;
using UnityEngine;

namespace Rewired.Utils.Attributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class FieldRangeAttribute : PropertyAttribute
	{
		private float eLHMDVUQXJXfiDcrBXJPvfUHkuxA;

		private float zLcqXVvvftPebIMQIntUnrDibCzB;

		private int tJTqxiGeAPqERRRYjknyuJPfEqUu;

		private int akNNPcnLQzgjYIRWxoIFshMFBHTAb;

		public float minFloat => eLHMDVUQXJXfiDcrBXJPvfUHkuxA;

		public float maxFloat => zLcqXVvvftPebIMQIntUnrDibCzB;

		public int minInt => tJTqxiGeAPqERRRYjknyuJPfEqUu;

		public int maxInt => akNNPcnLQzgjYIRWxoIFshMFBHTAb;

		public FieldRangeAttribute(float P_0, float P_1)
		{
			eLHMDVUQXJXfiDcrBXJPvfUHkuxA = P_0;
			zLcqXVvvftPebIMQIntUnrDibCzB = P_1;
			tJTqxiGeAPqERRRYjknyuJPfEqUu = (int)P_0;
			akNNPcnLQzgjYIRWxoIFshMFBHTAb = (int)P_1;
		}

		public FieldRangeAttribute(int P_0, int P_1)
		{
			tJTqxiGeAPqERRRYjknyuJPfEqUu = P_0;
			akNNPcnLQzgjYIRWxoIFshMFBHTAb = P_1;
			eLHMDVUQXJXfiDcrBXJPvfUHkuxA = P_0;
			zLcqXVvvftPebIMQIntUnrDibCzB = P_1;
		}
	}
}
