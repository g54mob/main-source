using UnityEngine;

namespace RLD
{
	public struct TorusEpsilon
	{
		private float _tubeRadiusEps;

		private float _cylHrzRadius;

		private float _cylVertRadius;

		public float TubeRadiusEps
		{
			get
			{
				return _tubeRadiusEps;
			}
			set
			{
				_tubeRadiusEps = Mathf.Abs(value);
			}
		}

		public float CylHrzRadius
		{
			get
			{
				return _cylHrzRadius;
			}
			set
			{
				_cylHrzRadius = Mathf.Abs(value);
			}
		}

		public float CylVertRadius
		{
			get
			{
				return _cylVertRadius;
			}
			set
			{
				_cylVertRadius = Mathf.Abs(value);
			}
		}
	}
}
