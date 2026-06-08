using Jobberwocky.GeometryAlgorithms.Source.Core;
using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Source.Parameters
{
	public class Triangulation3DParameters : Parameters
	{
		private Vector3[] _003CPoints_003Ek__BackingField;

		private bool _003CBoundaryOnly_003Ek__BackingField;

		private Side _003CSide_003Ek__BackingField;

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

		public bool BoundaryOnly
		{
			get
			{
				return _003CBoundaryOnly_003Ek__BackingField;
			}
			set
			{
				_003CBoundaryOnly_003Ek__BackingField = value;
			}
		}

		public Side Side
		{
			get
			{
				return _003CSide_003Ek__BackingField;
			}
			set
			{
				_003CSide_003Ek__BackingField = value;
			}
		}

		public Triangulation3DParameters()
		{
			BoundaryOnly = false;
			Side = Side.Front;
		}
	}
}
