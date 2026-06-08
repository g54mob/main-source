using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Examples.Data
{
	public class Random2D : Shape
	{
		public Random2D()
		{
			base.Points = CreateRandomPoints2D(100, 12f, 12f);
			base.CameraPoint = new Vector3(0f, 0f, -12f);
			base.CameraRotation = new Quaternion(0f, 0f, 0f, 1f);
		}

		public Vector3[] CreateRandomPoints2D(int nPoints, float rangeWidth, float rangeHeight)
		{
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
