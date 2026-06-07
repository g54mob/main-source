using UnityEngine;

namespace RLD
{
	public struct PyramidEpsilon
	{
		private float _ptContainEps;

		public float PtContainEps
		{
			get
			{
				return _ptContainEps;
			}
			set
			{
				_ptContainEps = Mathf.Abs(value);
			}
		}
	}
}
