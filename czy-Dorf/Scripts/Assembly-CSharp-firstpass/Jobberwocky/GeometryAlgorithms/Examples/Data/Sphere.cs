using System;
using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Examples.Data
{
	public class Sphere : Shape
	{
		public Sphere()
		{
			base.Points = CreateSphere(10f, 16, 16);
			base.CameraPoint = new Vector3(-12f, 11f, -16f);
			base.CameraRotation = Quaternion.Euler(30f, 45f, 0f);
		}

		private Vector3[] CreateSphere(float r, int lats, int longs)
		{
			Vector3[] array = new Vector3[(lats + 1) * (longs + 1) * 2];
			int num = 0;
			for (int i = 0; i <= lats; i++)
			{
				float f = (float)Math.PI * (-0.5f + (float)(i - 1) / (float)lats);
				float z = Mathf.Sin(f);
				float num2 = Mathf.Cos(f);
				float f2 = (float)Math.PI * (-0.5f + (float)(i / lats));
				float z2 = Mathf.Sin(f2);
				float num3 = Mathf.Cos(f2);
				for (int j = 0; j <= longs; j++)
				{
					float f3 = (float)Math.PI * 2f * (float)(j - 1) / (float)longs;
					float num4 = Mathf.Cos(f3);
					float num5 = Mathf.Sin(f3);
					array[num] = new Vector3(num4 * num2, num5 * num2, z) * r;
					num++;
					array[num] = new Vector3(num4 * num3, num5 * num3, z2) * r;
					num++;
				}
			}
			return array;
		}
	}
}
