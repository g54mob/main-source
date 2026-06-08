using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Examples.Data
{
	public class Cube : Shape
	{
		public Cube()
		{
			base.Points = CreateCube(7, 6, 4, 2.9f);
			Random.InitState(1);
			for (int i = 0; i < base.Points.Length; i++)
			{
				Vector3 vector = base.Points[i];
				vector.Set(vector.x + Random.value, vector.y + Random.value, vector.z + Random.value);
				base.Points[i] = vector;
			}
			base.CameraPoint = new Vector3(-15f, 10f, -20f);
			base.CameraRotation = Quaternion.Euler(30f, 45f, 0f);
		}

		public Vector3[] CreateCube(int nPointsWidth, int nPointsHeight, int nPointsDepth, float scale)
		{
			Vector3[] array = new Vector3[nPointsWidth * nPointsHeight * nPointsDepth];
			int num = 0;
			for (int i = 0; i < nPointsWidth; i++)
			{
				float x = ((float)i - (float)nPointsWidth * 0.5f) * scale;
				for (int j = 0; j < nPointsHeight; j++)
				{
					float y = ((float)j - (float)nPointsHeight * 0.5f) * scale;
					for (int k = 0; k < nPointsDepth; k++)
					{
						float z = ((float)k - (float)nPointsDepth * 0.5f) * scale;
						array[num] = new Vector3(x, y, z);
						num++;
					}
				}
			}
			return array;
		}
	}
}
