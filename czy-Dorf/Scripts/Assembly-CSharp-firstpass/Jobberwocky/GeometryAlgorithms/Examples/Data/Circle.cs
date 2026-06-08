using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Examples.Data
{
	public class Circle : Shape
	{
		public Circle()
		{
			base.Boundary = CreateCircle(1f, 72);
			base.Points = new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			};
			base.CameraPoint = new Vector3(0f, 0f, -10f);
			base.CameraRotation = new Quaternion(0f, 0f, 0f, 1f);
		}

		protected Vector3[] CreateCircle(float scale, int nPoints)
		{
			Vector3[] array = new Vector3[nPoints];
			float z = 360f / (float)nPoints;
			Quaternion quaternion = Quaternion.Euler(0f, 0f, z);
			array[0] = scale * new Vector3(0f, 0.5f, 0f);
			array[1] = quaternion * array[0];
			quaternion.eulerAngles *= 2f;
			for (int i = 1; i < nPoints - 1; i++)
			{
				array[i + 1] = quaternion * array[i - 1];
			}
			return array;
		}
	}
}
