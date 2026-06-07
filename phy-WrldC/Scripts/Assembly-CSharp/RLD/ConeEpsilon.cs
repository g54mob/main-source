using UnityEngine;

namespace RLD
{
	public struct ConeEpsilon
	{
		private float _hrzEps;

		private float _vertEps;

		public float HrzEps
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
