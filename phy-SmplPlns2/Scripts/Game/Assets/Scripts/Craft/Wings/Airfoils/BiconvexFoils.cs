using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Wings.Physics;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Airfoils
{
	public static class BiconvexFoils
	{
		private class BiconvexAirfoil : StandardAirfoil
		{
			private float _offset;

			private float _radiusSq;

			public override bool LeadingColocated => true;

			public override bool LeadingSmooth => false;

			public override bool TrailingColocated => true;

			public override bool TrailingSmooth => false;

			public override float LeadingEdgeRadius => 0f;

			public BiconvexAirfoil(float height)
			{
				_offset = 0.5f * height + 1f / (height * 8f);
				_radiusSq = 0.25f + _offset * _offset;
			}

			public override bool Equals(object obj)
			{
				if (obj is BiconvexAirfoil biconvexAirfoil)
				{
					float radiusSq = _radiusSq;
					float offset = _offset;
					float radiusSq2 = biconvexAirfoil._radiusSq;
					float offset2 = biconvexAirfoil._offset;
					if (radiusSq == radiusSq2)
					{
						return offset == offset2;
					}
					return false;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return (_radiusSq, _offset).GetHashCode();
			}

			public override RuntimeAirfoil GetRuntimeAirfoil(List<IntPtr> mallocPtrs)
			{
				throw new NotImplementedException();
			}

			public override float2 SamplePoint(float x)
			{
				if (x == 0f || x == 1f)
				{
					return math.float2(0f, 0f);
				}
				x = math.clamp(x, 0f, 1f);
				x -= 0.5f;
				x *= x;
				x = math.sqrt(_radiusSq - x) - _offset;
				return math.float2(x, 0f - x);
			}

			public override float WarpDensity(float x)
			{
				return x;
			}
		}

		public static IAirfoil Parse(string str)
		{
			if (str.StartsWith("Biconvex "))
			{
				str = str.Substring(9, str.Length - 9);
				if (float.TryParse(str, out var result))
				{
					return new BiconvexAirfoil(result);
				}
			}
			return null;
		}
	}
}
