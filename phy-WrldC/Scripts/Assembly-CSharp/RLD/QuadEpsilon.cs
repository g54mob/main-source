using UnityEngine;

namespace RLD
{
	public struct QuadEpsilon
	{
		private Vector2 _sizeEps;

		private float _extrudeEps;

		private float _wireEps;

		public Vector2 SizeEps
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

		public float ExtrudeEps
		{
			get
			{
				return _extrudeEps;
			}
			set
			{
				_extrudeEps = Mathf.Abs(value);
			}
		}

		public float WireEps
		{
			get
			{
				return _wireEps;
			}
			set
			{
				_wireEps = Mathf.Abs(value);
			}
		}
	}
}
