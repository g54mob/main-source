using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class FABRIKChain
	{
		public bmg ik;

		[Range(0f, 1f)]
		public float pull;

		[Range(0f, 1f)]
		public float pin;

		public int[] children;

		public bool jzd(ref string a)
		{
			return false;
		}

		public void jze()
		{
		}

		public void jzf(FABRIKChain[] a)
		{
		}

		public void jzg(Vector3 a, FABRIKChain[] b)
		{
		}

		private Vector3 jzh(FABRIKChain[] a)
		{
			return default(Vector3);
		}
	}
}
