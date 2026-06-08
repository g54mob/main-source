using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Examples.Data
{
	public class SquareWithHole : Square
	{
		public SquareWithHole()
		{
			base.Holes = new Vector3[1][];
			base.Holes[0] = CreateSquare(0.5f);
		}
	}
}
