using System;

namespace Battlehub.SplineEditor
{
	[Serializable]
	public struct Twist
	{
		public static readonly Twist Null;

		public float Data;

		public float T1;

		public float T2;

		public Twist(float data, float t1, float t2)
		{
			Data = data;
			T1 = t1;
			T2 = t2;
		}
	}
}
