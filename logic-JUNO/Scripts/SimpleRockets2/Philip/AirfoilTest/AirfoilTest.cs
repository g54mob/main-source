using System;
using UnityEngine;

namespace Philip.AirfoilTest
{
	public class AirfoilTest : MonoBehaviour
	{
		public bool ClosedTrailingEdge = true;

		public int NACA = 2415;

		private const int GridPoints = 100;

		private void GraphAirfoil(float M, float P, float T, bool closeTrailingEdge)
		{
			M /= 100f;
			P /= 10f;
			T /= 100f;
			float[] array = new float[100];
			float[] array2 = new float[100];
			float[] array3 = new float[100];
			float[] array4 = new float[100];
			float[] array5 = new float[100];
			float[] array6 = new float[100];
			float[] array7 = new float[100];
			float[] array8 = new float[100];
			float[] array9 = new float[100];
			float num = (closeTrailingEdge ? (-0.1036f) : (-0.1015f));
			float num2 = 0.01f;
			for (int i = 0; i < 100; i++)
			{
				array4[i] = num2 * (float)i;
				float num3 = Mathf.Pow(P, 2f);
				if (array4[i] >= 0f && array4[i] < P)
				{
					array[i] = M / num3 * (2f * P * array4[i] - Mathf.Pow(array4[i], 2f));
					array2[i] = 2f * M / num3 * (P - array4[i]);
				}
				else if (array4[i] >= P && array4[i] <= 1f)
				{
					array[i] = M / Mathf.Pow(1f - P, 2f) * (1f - 2f * P + 2f * P * array4[i] - Mathf.Pow(array4[i], 2f));
					array2[i] = 2f * M / Mathf.Pow(1f - P, 2f) * (P - array4[i]);
				}
				array3[i] = Mathf.Atan(array2[i]);
				array5[i] = 5f * T * (0.2969f * Mathf.Sqrt(array4[i]) + -0.126f * array4[i] + -0.3516f * Mathf.Pow(array4[i], 2f) + 0.2843f * Mathf.Pow(array4[i], 3f) + num * Mathf.Pow(array4[i], 4f));
				array6[i] = array4[i] - array5[i] * Mathf.Sin(array3[i]);
				array7[i] = array[i] + array5[i] * Mathf.Cos(array3[i]);
				array8[i] = array4[i] + array5[i] * Mathf.Sin(array3[i]);
				array9[i] = array[i] - array5[i] * Mathf.Cos(array3[i]);
			}
			for (int j = 0; j < 100; j++)
			{
				DebugGraph.MultiDraw("airfoil", Color.gray, new Vector2(array4[j], array[j]));
			}
			for (int k = 0; k < 100; k++)
			{
				DebugGraph.MultiDraw("airfoil", Color.red, new Vector2(array6[k], array7[k]));
			}
			for (int l = 0; l < 100; l++)
			{
				DebugGraph.MultiDraw("airfoil", Color.blue, new Vector2(array8[l], array9[l]));
			}
			GraphCircle();
		}

		private void GraphCircle()
		{
			for (float num = 0f; num < MathF.PI * 2f; num += MathF.PI / 50f)
			{
				DebugGraph.MultiDraw("airfoil", Color.black, new Vector2(Mathf.Cos(num), Mathf.Sin(num)) * 0.1f);
			}
		}

		private void OnValidate()
		{
			string text = NACA.ToString();
			float m = float.Parse(text.Substring(0, 1));
			float p = float.Parse(text.Substring(1, 1));
			float t = float.Parse(text.Substring(2, 2));
			GraphAirfoil(m, p, t, ClosedTrailingEdge);
		}

		private void Start()
		{
			float m = 9f;
			float p = 5f;
			float t = 5f;
			GraphAirfoil(m, p, t, closeTrailingEdge: true);
		}
	}
}
