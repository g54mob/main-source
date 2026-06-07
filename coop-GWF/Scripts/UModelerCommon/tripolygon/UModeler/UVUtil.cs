using UnityEngine;

namespace tripolygon.UModeler
{
	public class UVUtil
	{
		private static Vector3[] elemental_axes_ = new Vector3[18]
		{
			new Vector3(0f, 1f, 0f),
			new Vector3(1f, 0f, 0f),
			new Vector3(0f, 0f, -1f),
			new Vector3(0f, -1f, 0f),
			new Vector3(-1f, 0f, 0f),
			new Vector3(0f, 0f, 1f),
			new Vector3(1f, 0f, 0f),
			new Vector3(0f, 0f, 1f),
			new Vector3(0f, -1f, 0f),
			new Vector3(-1f, 0f, 0f),
			new Vector3(0f, 0f, -1f),
			new Vector3(0f, -1f, 0f),
			new Vector3(0f, 0f, 1f),
			new Vector3(-1f, 0f, 0f),
			new Vector3(0f, -1f, 0f),
			new Vector3(0f, 0f, -1f),
			new Vector3(1f, 0f, 0f),
			new Vector3(0f, -1f, 0f)
		};

		public static Vector2 TransformUV(Vector2 uv, UVParameter texture_param, Vector2 uv_center)
		{
			float num = ((Mathf.Abs(texture_param.scale.x) < 0.0001f) ? 0.0001f : texture_param.scale.x);
			float num2 = ((Mathf.Abs(texture_param.scale.y) < 0.0001f) ? 0.0001f : texture_param.scale.y);
			Vector3 vector = Matrix4x4.TRS(Vector3.zero, Quaternion.AngleAxis(texture_param.rotation, Vector3.forward), new Vector3(1f / num, 1f / num2, 1f)).MultiplyVector(new Vector3(uv.x - uv_center.x, uv.y - uv_center.y, 1f));
			return new Vector3(vector.x + texture_param.shift.x + uv_center.x, vector.y + texture_param.shift.y + uv_center.y);
		}

		public static Vector2 CalcTexCoords(Vector3 pos, Vector3 normal)
		{
			CalcTextureBasis(normal, out var basis_u, out var basis_v);
			return new Vector2(Vector3.Dot(pos, basis_u), 0f - Vector3.Dot(pos, basis_v));
		}

		private static void CalcTextureBasis(Vector3 normal, out Vector3 basis_u, out Vector3 basis_v)
		{
			Vector3[] array = new Vector3[2];
			CalcTextureAxis(normal, out array[0], out array[1]);
			basis_u = array[0];
			basis_v = array[1];
			int index = ((array[0].x == 0f) ? ((array[0].y != 0f) ? 1 : 2) : 0);
			int index2 = ((array[1].x == 0f) ? ((array[1].y != 0f) ? 1 : 2) : 0);
			for (int i = 0; i < 2; i++)
			{
				float value = array[i][index];
				float value2 = array[i][index2];
				if (i == 0)
				{
					basis_u[index] = value;
					basis_u[index2] = value2;
				}
				else
				{
					basis_v[index] = value;
					basis_v[index2] = value2;
				}
			}
		}

		private static void CalcTextureAxis(Vector3 normal, out Vector3 xv, out Vector3 yv)
		{
			float num = -1f;
			int num2 = 0;
			for (int i = 0; i < 6; i++)
			{
				float num3 = Vector3.Dot(normal, elemental_axes_[i * 3]);
				if (num3 > num)
				{
					num = num3;
					num2 = i;
				}
			}
			xv = elemental_axes_[num2 * 3 + 1];
			yv = elemental_axes_[num2 * 3 + 2];
		}

		public static UVParameter TileUVs(PlaneEx plane, AABB aabb, float tile_u, float tile_v)
		{
			UVParameter uVParameter = new UVParameter();
			Vector3[] array = new Vector3[2];
			Vector3[] array2 = new Vector3[4];
			float num = Mathf.Sin(0f);
			float num2 = Mathf.Cos(0f);
			CalcTextureAxis(plane.normal, out array[0], out array[1]);
			float value = Vector3.Dot(aabb.min, array[0]);
			float value2 = Vector3.Dot(aabb.min, array[1]);
			float value3 = Vector3.Dot(aabb.max, array[0]);
			float value4 = Vector3.Dot(aabb.max, array[1]);
			array2[0][0] = value;
			array2[0][1] = value2;
			array2[1][0] = value3;
			array2[1][1] = value2;
			array2[2][0] = value;
			array2[2][1] = value4;
			array2[3][0] = value3;
			array2[3][1] = value4;
			value = (value2 = 99999f);
			value3 = (value4 = -99999f);
			for (int i = 0; i < 4; i++)
			{
				float num3 = num2 * array2[i][0] - num * array2[i][1];
				float num4 = num * array2[i][0] + num2 * array2[i][1];
				if (i % 2 == 1)
				{
					if (num3 > value3)
					{
						value3 = num3;
					}
					continue;
				}
				if (num3 < value)
				{
					value = num3;
				}
				if (i < 2)
				{
					if (num4 < value2)
					{
						value2 = num4;
					}
				}
				else if (num4 > value4)
				{
					value4 = num4;
				}
			}
			float num5 = value3 - value;
			float num6 = value4 - value2;
			float num7 = ((Mathf.Abs(tile_u) < 0.0001f) ? (0.0001f * Mathf.Sign(tile_u)) : tile_u);
			float num8 = ((Mathf.Abs(tile_v) < 0.0001f) ? (0.0001f * Mathf.Sign(tile_v)) : tile_v);
			uVParameter.scale[0] = (0f - num5) / num7;
			uVParameter.scale[1] = (0f - num6) / num8;
			float num9 = ((Mathf.Abs(uVParameter.scale[0]) < 0.0001f) ? (0.0001f * Mathf.Sign(uVParameter.scale[0])) : uVParameter.scale[0]);
			float num10 = ((Mathf.Abs(uVParameter.scale[1]) < 0.0001f) ? (0.0001f * Mathf.Sign(uVParameter.scale[1])) : uVParameter.scale[1]);
			uVParameter.shift[0] = value / num9;
			uVParameter.shift[1] = value2 / num10;
			return uVParameter;
		}
	}
}
