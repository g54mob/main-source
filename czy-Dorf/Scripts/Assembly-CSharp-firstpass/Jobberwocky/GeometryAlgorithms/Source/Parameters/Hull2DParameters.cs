using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Source.Parameters
{
	public class Hull2DParameters : Parameters
	{
		private Vector3[] _003CPoints_003Ek__BackingField;

		private double _003CConcavity_003Ek__BackingField;

		public Vector3[] Points
		{
			get
			{
				return _003CPoints_003Ek__BackingField;
			}
			set
			{
				_003CPoints_003Ek__BackingField = value;
			}
		}

		public double Concavity
		{
			get
			{
				return _003CConcavity_003Ek__BackingField;
			}
			set
			{
				_003CConcavity_003Ek__BackingField = value;
			}
		}

		public Hull2DParameters()
		{
			Concavity = double.MaxValue;
		}
	}
}
