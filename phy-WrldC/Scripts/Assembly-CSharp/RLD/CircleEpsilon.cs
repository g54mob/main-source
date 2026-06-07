using UnityEngine;

namespace RLD
{
	public struct CircleEpsilon
	{
		private float _radiusEps;

		private float _extrudeEps;

		private float _wireEps;

		public float RadiusEps
		{
			get
			{
				return _radiusEps;
			}
			set
			{
				_radiusEps = Mathf.Abs(value);
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
