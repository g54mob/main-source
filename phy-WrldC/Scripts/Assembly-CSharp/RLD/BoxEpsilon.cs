using UnityEngine;

namespace RLD
{
	public struct BoxEpsilon
	{
		private Vector3 _sizeEps;

		public Vector3 SizeEps
		{
			get
			{
				return _sizeEps;
			}
			set
			{
				_sizeEps = value.Abs();
			}
		}

		public float WidthEps
		{
			get
			{
				return _sizeEps.x;
			}
			set
			{
				_sizeEps.x = Mathf.Abs(value);
			}
		}

		public float HeightEps
		{
			get
			{
				return _sizeEps.y;
			}
			set
			{
				_sizeEps.y = Mathf.Abs(value);
			}
		}

		public float DepthEps
		{
			get
			{
				return _sizeEps.z;
			}
			set
			{
				_sizeEps.z = Mathf.Abs(value);
			}
		}
	}
}
