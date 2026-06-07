using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dreamteck.Splines
{
	[Serializable]
	public class SplineSampleModifier
	{
		[Serializable]
		public class Key
		{
			[SerializeField]
			private double _featherStart;

			[SerializeField]
			private double _featherEnd;

			[SerializeField]
			private double _centerStart;

			[SerializeField]
			private double _centerEnd;

			[SerializeField]
			internal SplineSampleModifier modifier;

			public AnimationCurve interpolation;

			public float blend;

			public double start
			{
				get
				{
					return 0.0;
				}
				set
				{
				}
			}

			public double end
			{
				get
				{
					return 0.0;
				}
				set
				{
				}
			}

			public double centerStart
			{
				get
				{
					return 0.0;
				}
				set
				{
				}
			}

			public double centerEnd
			{
				get
				{
					return 0.0;
				}
				set
				{
				}
			}

			public double globalCenterStart
			{
				get
				{
					return 0.0;
				}
				set
				{
				}
			}

			public double globalCenterEnd
			{
				get
				{
					return 0.0;
				}
				set
				{
				}
			}

			public double position
			{
				get
				{
					return 0.0;
				}
				set
				{
				}
			}

			internal Key(double f, double t, SplineSampleModifier modifier)
			{
			}

			private double GlobalToLocalPercent(double t)
			{
				return 0.0;
			}

			private double LocalToGlobalPercent(double t)
			{
				return 0.0;
			}

			public float Evaluate(double t)
			{
				return 0f;
			}

			public virtual Key Duplicate()
			{
				return null;
			}
		}

		public float blend;

		public virtual List<Key> GetKeys()
		{
			return null;
		}

		public virtual void SetKeys(List<Key> input)
		{
		}

		public virtual void Apply(SplineSample result)
		{
		}

		public virtual void Apply(SplineSample source, SplineSample destination)
		{
		}
	}
}
