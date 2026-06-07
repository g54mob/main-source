using UnityEngine;

namespace RLD
{
	public struct CylinderEpsilon
	{
		private float _hrzEps;

		private float _vertEps;

		public float RadiusEps
		{
			get
			{
				return _hrzEps;
			}
			set
			{
				_hrzEps = Mathf.Abs(value);
			}
		}

		public float VertEps
		{
			get
			{
				return _vertEps;
			}
			set
			{
				_vertEps = Mathf.Abs(value);
			}
		}
	}
}
