using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Source.Parameters
{
	public class Hull3DParameters : Parameters
	{
		private Vector3[] _003CPoints_003Ek__BackingField;

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
	}
}
