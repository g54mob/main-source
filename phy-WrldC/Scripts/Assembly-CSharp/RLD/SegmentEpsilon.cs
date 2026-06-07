using UnityEngine;

namespace RLD
{
	public struct SegmentEpsilon
	{
		private float _raycastEps;

		private float _ptOnSegmentEps;

		public float RaycastEps
		{
			get
			{
				return _raycastEps;
			}
			set
			{
				_raycastEps = Mathf.Abs(value);
			}
		}

		public float PtOnSegmentEps
		{
			get
			{
				return _ptOnSegmentEps;
			}
			set
			{
				_ptOnSegmentEps = Mathf.Abs(value);
			}
		}
	}
}
