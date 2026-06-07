using UnityEngine;

namespace RLD
{
	public struct PrismEpsilon
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
