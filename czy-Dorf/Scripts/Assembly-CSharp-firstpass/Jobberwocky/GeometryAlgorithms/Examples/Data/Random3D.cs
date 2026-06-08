using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Examples.Data
{
	public class Random3D : Shape
	{
		public Random3D()
		{
			base.Points = CreateRandomPoints3D(100, 10f, 5f, 8f);
			base.CameraPoint = new Vector3(-4.5f, 2f, -10f);
			base.CameraRotation = Quaternion.Euler(15f, 30f, 0f);
		}

		public Vector3[] CreateRandomPoints3D(int nPoints, float rangeWidth, float rangeHeight, float rangeDepth)
		{
			Random.InitState(11);
			Vector3[] array = new Vector3[nPoints];
			for (int i = 0; i < nPoints; i++)
			{
				float x = Random.Range(rangeWidth * -0.5f, rangeWidth * 0.5f);
				float y = Random.Range(rangeHeight * -0.5f, rangeHeight * 0.5f);
				float z = Random.Range(rangeDepth * -0.5f, rangeDepth * 0.5f);
				array[i] = new Vector3(x, y, z);
			}
			return array;
		}
	}
}
