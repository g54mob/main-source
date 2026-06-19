using System;
using UnityEngine;

namespace Battlehub.SplineEditor
{
	[Serializable]
	public struct Thickness
	{
		public static readonly Thickness Null;

		public Vector3Serialziable Data;

		public float T1;

		public float T2;

		public Thickness(Vector3 data, float t1, float t2)
		{
			Data = data;
			T1 = t1;
			T2 = t2;
		}
	}
}
