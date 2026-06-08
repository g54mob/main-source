using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Examples.Data
{
	public class CircleWithHole : Circle
	{
		public CircleWithHole()
		{
			base.Holes = new Vector3[1][];
			base.Holes[0] = CreateCircle(0.5f, 72);
		}
	}
}
