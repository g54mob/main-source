using UnityEngine;

namespace MeshXtensions
{
	public class CrossSection
	{
		public Vector2[] points;

		public int atIndex;

		public CrossSection()
		{
		}

		public CrossSection(Vector2[] _points, int _atIndex)
		{
			points = _points;
			atIndex = _atIndex;
		}
	}
}
