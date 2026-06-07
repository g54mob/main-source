using UnityEngine;

namespace RLD
{
	public struct PolygonEpsilon
	{
		private float _areaEps;

		private float _extrudeEps;

		private float _wireEps;

		private float _thickWireEps;

		public float AreaEps
		{
			get
			{
				return _areaEps;
			}
			set
			{
				_areaEps = Mathf.Abs(value);
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

		public float ThickWireEps
		{
			get
			{
				return _thickWireEps;
			}
			set
			{
				_thickWireEps = Mathf.Abs(value);
			}
		}
	}
}
