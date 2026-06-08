using Jobberwocky.GeometryAlgorithms.Source.Core;
using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Source.Parameters
{
	public class Triangulation2DParameters : Parameters
	{
		private Vector3[] _003CPoints_003Ek__BackingField;

		private Vector3[] _003CBoundary_003Ek__BackingField;

		private Vector3[][] _003CHoles_003Ek__BackingField;

		private bool _003CDelaunay_003Ek__BackingField;

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

		public Vector3[] Boundary
		{
			get
			{
				return _003CBoundary_003Ek__BackingField;
			}
			set
			{
				_003CBoundary_003Ek__BackingField = value;
			}
		}

		public Vector3[][] Holes
		{
			get
			{
				return _003CHoles_003Ek__BackingField;
			}
			set
			{
				_003CHoles_003Ek__BackingField = value;
			}
		}

		public bool Delaunay
		{
			get
			{
				return _003CDelaunay_003Ek__BackingField;
			}
			set
			{
				_003CDelaunay_003Ek__BackingField = value;
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

		public Triangulation2DParameters()
		{
			Delaunay = false;
			Side = Side.Front;
		}
	}
}
