using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Source.Parameters
{
	public class Voronoi2DParameters : Parameters
	{
		private Vector3[] _003CPoints_003Ek__BackingField;

		private bool _003CBounded_003Ek__BackingField;

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

		public bool Bounded
		{
			get
			{
				return _003CBounded_003Ek__BackingField;
			}
			set
			{
				_003CBounded_003Ek__BackingField = value;
			}
		}

		public Voronoi2DParameters()
		{
			Bounded = false;
		}
	}
}
