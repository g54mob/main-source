using System;
using System.Collections.Generic;
using UnityEngine;

namespace Jundroo.Common.Math
{
	public class OrientedBoundingBox
	{
		public Vector3 Center { get; private set; }

		public Vector3 Extents { get; private set; }

		public Quaternion Rotation { get; private set; }

		public Vector3 Size => 2f * Extents;

		public OrientedBoundingBox(Vector3 center, Vector3 extents, Quaternion rotation)
		{
			Center = center;
			Extents = extents;
			Rotation = rotation;
		}

		public static OrientedBoundingBox CalculateOBB(IEnumerable<MeshRenderer> renderers, float scale = 1f)
		{
			if (renderers == null)
			{
				throw new ArgumentNullException("renderers");
			}
			List<Vector3> list = new List<Vector3>();
			bool flag = false;
			foreach (MeshRenderer renderer in renderers)
			{
				if (renderer == null || !renderer.TryGetComponent<MeshFilter>(out var component))
				{
					continue;
				}
				Mesh mesh = component.sharedMesh;
				if (mesh == null)
				{
					mesh = component.mesh;
				}
				if (!(mesh == null) && mesh.vertexCount != 0)
				{
					flag = true;
					Vector3[] vertices = mesh.vertices;
					for (int i = 0; i < vertices.Length; i++)
					{
						list.Add(renderer.transform.TransformPoint(vertices[i]));
					}
				}
			}
			if (!flag)
			{
				throw new InvalidOperationException("No valid renderers with meshes were found.");
			}
			if (list.Count == 0)
			{
				throw new InvalidOperationException("No vertices were found in the provided renderers.");
			}
			Vector3 zero = Vector3.zero;
			foreach (Vector3 item in list)
			{
				zero += item;
			}
			zero /= (float)list.Count;
			Matrix4x4 zero2 = Matrix4x4.zero;
			foreach (Vector3 item2 in list)
			{
				Vector3 vector = item2 - zero;
				zero2.m00 += vector.x * vector.x;
				zero2.m01 += vector.x * vector.y;
				zero2.m02 += vector.x * vector.z;
				zero2.m10 += vector.y * vector.x;
				zero2.m11 += vector.y * vector.y;
				zero2.m12 += vector.y * vector.z;
				zero2.m20 += vector.z * vector.x;
				zero2.m21 += vector.z * vector.y;
				zero2.m22 += vector.z * vector.z;
			}
			Vector3[] array = ComputePrincipalAxes(zero2);
			array[1] = Vector3.up;
			array[0] = new Vector3(array[0].x, 0f, array[0].z).normalized;
			array[2] = new Vector3(array[2].x, 0f, array[2].z).normalized;
			array[2] = Vector3.Cross(array[0], array[1]).normalized;
			Matrix4x4 matrix4x = default(Matrix4x4);
			matrix4x.SetColumn(0, array[0]);
			matrix4x.SetColumn(1, array[1]);
			matrix4x.SetColumn(2, array[2]);
			matrix4x.SetColumn(3, new Vector4(0f, 0f, 0f, 1f));
			Vector3[] array2 = new Vector3[list.Count];
			for (int j = 0; j < list.Count; j++)
			{
				array2[j] = matrix4x.inverse.MultiplyPoint3x4(list[j]);
			}
			Vector3 vector2 = array2[0];
			Vector3 vector3 = array2[0];
			Vector3[] array3 = array2;
			foreach (Vector3 rhs in array3)
			{
				vector2 = Vector3.Min(vector2, rhs);
				vector3 = Vector3.Max(vector3, rhs);
			}
			Vector3 extents = (vector3 - vector2) * 0.5f;
			Vector3 center = matrix4x.MultiplyPoint3x4((vector2 + vector3) * 0.5f);
			extents *= scale;
			return new OrientedBoundingBox(rotation: Quaternion.LookRotation(array[2], array[1]), center: center, extents: extents);
		}

		public void Draw()
		{
			Gizmos.color = Color.green;
			Gizmos.matrix = Matrix4x4.TRS(Center, Rotation, Vector3.one);
			Gizmos.DrawWireCube(Vector3.zero, Extents * 2f);
		}

		public Vector3[] GetBottomVertices()
		{
			return GetVertices(top: false);
		}

		public Vector3[] GetTopVertices()
		{
			return GetVertices(top: true);
		}

		private static Vector3[] ComputePrincipalAxes(Matrix4x4 covariance)
		{
			float[,] matrix = new float[3, 3]
			{
				{ covariance.m00, covariance.m01, covariance.m02 },
				{ covariance.m10, covariance.m11, covariance.m12 },
				{ covariance.m20, covariance.m21, covariance.m22 }
			};
			float[] eigenvalues = new float[3];
			float[,] array = new float[3, 3];
			Jacobi(matrix, eigenvalues, array);
			SortEigenvaluesAndVectors(eigenvalues, array);
			Vector3[] array2 = new Vector3[3];
			for (int i = 0; i < 3; i++)
			{
				array2[i] = new Vector3(array[0, i], array[1, i], array[2, i]);
				array2[i].Normalize();
			}
			return array2;
		}

		private static void Jacobi(float[,] matrix, float[] eigenvalues, float[,] eigenvectors)
		{
			int num = 3;
			for (int i = 0; i < num; i++)
			{
				eigenvectors[i, i] = 1f;
				for (int j = 0; j < num; j++)
				{
					if (i != j)
					{
						eigenvectors[i, j] = 0f;
					}
				}
			}
			float[] array = new float[num];
			float[] array2 = new float[num];
			for (int k = 0; k < num; k++)
			{
				array[k] = (eigenvalues[k] = matrix[k, k]);
				array2[k] = 0f;
			}
			for (int l = 0; l < 50; l++)
			{
				float num2 = 0f;
				for (int m = 0; m < num - 1; m++)
				{
					for (int n = m + 1; n < num; n++)
					{
						num2 += Mathf.Abs(matrix[m, n]);
					}
				}
				if (num2 == 0f)
				{
					break;
				}
				for (int num3 = 0; num3 < num - 1; num3++)
				{
					for (int num4 = num3 + 1; num4 < num; num4++)
					{
						float num5 = 100f * Mathf.Abs(matrix[num3, num4]);
						if (l > 4 && Mathf.Abs(eigenvalues[num3]) + num5 == Mathf.Abs(eigenvalues[num3]) && Mathf.Abs(eigenvalues[num4]) + num5 == Mathf.Abs(eigenvalues[num4]))
						{
							matrix[num3, num4] = 0f;
						}
						else
						{
							if (!(Mathf.Abs(matrix[num3, num4]) > 0.0001f))
							{
								continue;
							}
							float num6 = eigenvalues[num4] - eigenvalues[num3];
							float num7;
							if (Mathf.Abs(num6) + num5 == Mathf.Abs(num6))
							{
								num7 = matrix[num3, num4] / num6;
							}
							else
							{
								float num8 = 0.5f * num6 / matrix[num3, num4];
								num7 = 1f / (Mathf.Abs(num8) + Mathf.Sqrt(1f + num8 * num8));
								if (num8 < 0f)
								{
									num7 = 0f - num7;
								}
							}
							float num9 = 1f / Mathf.Sqrt(1f + num7 * num7);
							float num10 = num7 * num9;
							float tau = num10 / (1f + num9);
							num6 = num7 * matrix[num3, num4];
							array2[num3] -= num6;
							array2[num4] += num6;
							eigenvalues[num3] -= num6;
							eigenvalues[num4] += num6;
							matrix[num3, num4] = 0f;
							for (int num11 = 0; num11 < num3; num11++)
							{
								Rotate(matrix, num11, num3, num11, num4, num10, tau);
							}
							for (int num12 = num3 + 1; num12 < num4; num12++)
							{
								Rotate(matrix, num3, num12, num12, num4, num10, tau);
							}
							for (int num13 = num4 + 1; num13 < num; num13++)
							{
								Rotate(matrix, num3, num13, num4, num13, num10, tau);
							}
							for (int num14 = 0; num14 < num; num14++)
							{
								Rotate(eigenvectors, num14, num3, num14, num4, num10, tau);
							}
						}
					}
				}
				for (int num15 = 0; num15 < num; num15++)
				{
					array[num15] += array2[num15];
					eigenvalues[num15] = array[num15];
					array2[num15] = 0f;
				}
			}
		}

		private static void Rotate(float[,] matrix, int i, int j, int k, int l, float s, float tau)
		{
			float num = matrix[i, j];
			float num2 = matrix[k, l];
			matrix[i, j] = num - s * (num2 + num * tau);
			matrix[k, l] = num2 + s * (num - num2 * tau);
		}

		private static void SortEigenvaluesAndVectors(float[] eigenvalues, float[,] eigenvectors)
		{
			for (int i = 0; i < 2; i++)
			{
				for (int j = i + 1; j < 3; j++)
				{
					if (eigenvalues[i] < eigenvalues[j])
					{
						float num = eigenvalues[i];
						eigenvalues[i] = eigenvalues[j];
						eigenvalues[j] = num;
						for (int k = 0; k < 3; k++)
						{
							float num2 = eigenvectors[k, i];
							eigenvectors[k, i] = eigenvectors[k, j];
							eigenvectors[k, j] = num2;
						}
					}
				}
			}
		}

		private Vector3[] GetVertices(bool top)
		{
			Vector3[] array = new Vector3[4];
			Vector3 vector = (top ? Vector3.up : Vector3.down);
			for (int i = 0; i < 4; i++)
			{
				Vector3 vector2 = new Vector3(((i & 1) == 0) ? (0f - Extents.x) : Extents.x, vector.y * Extents.y, ((i & 2) == 0) ? (0f - Extents.z) : Extents.z);
				array[i] = Center + Rotation * vector2;
			}
			return array;
		}
	}
}
