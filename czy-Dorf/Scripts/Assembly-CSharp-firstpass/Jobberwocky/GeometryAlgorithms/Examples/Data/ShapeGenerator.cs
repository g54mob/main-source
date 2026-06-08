using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Examples.Data
{
	public class ShapeGenerator
	{
		public Vector3[] CreateRandomPoints2D(int nPoints, float rangeWidth, float rangeHeight)
		{
			Random.InitState(1);
			Vector3[] array = new Vector3[nPoints];
			for (int i = 0; i < nPoints; i++)
			{
				float x = Random.Range(rangeWidth * -0.5f, rangeWidth * 0.5f);
				float y = Random.Range(rangeHeight * -0.5f, rangeHeight * 0.5f);
				array[i] = new Vector3(x, y, 0f);
			}
			return array;
		}
	}
}
