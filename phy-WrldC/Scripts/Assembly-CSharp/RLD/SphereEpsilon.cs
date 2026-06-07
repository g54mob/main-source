using UnityEngine;

namespace RLD
{
	public struct SphereEpsilon
	{
		private float _radiusEps;

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
	}
}
