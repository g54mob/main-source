using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace tripolygon.UModeler
{
	[CreateAssetMenu(fileName = "UModelerHST", menuName = "UModeler/Hotspot Texture", order = 500)]
	public class HotspotLayout : ScriptableObject
	{
		private struct TransHotspotData
		{
			public Vector2 a;

			public Vector2 b;

			public Vector2 c;

			public Line2D abLine;

			public Line2D acLine;

			public void PreProcess(Vector2[] triangle)
			{
				if (triangle.Length == 3)
				{
					a = triangle[0];
					b = triangle[1];
					c = triangle[2];
					abLine = new Line2D(b, a);
					acLine = new Line2D(c, a);
				}
			}

			public Vector2 GetUV(Vector2 pos)
			{
				Vector2 vector = pos - b;
				Vector2 vector2 = pos - c;
				HitResult hitResult = acLine.RayHit(b, vector.normalized);
				HitResult hitResult2 = abLine.RayHit(c, vector2.normalized);
				return new Vector2(1f - vector.magnitude / (hitResult.pos - b).magnitude, 1f - vector2.magnitude / (hitResult2.pos - c).magnitude);
			}

			public Vector2 GetPos(Vector2 uv)
			{
				return Vector2.zero + a * (1f - uv.x - uv.y) + b * uv.x + c * uv.y;
			}
		}

		[SerializeField]
		public Texture2D texture;

		[SerializeField]
		public List<Hotspot> hotspotList = new List<Hotspot>();

		[SerializeField]
		public int selectedHotspotIndex;

		private Vector2[] TransHotspot(Vector2[] normalUVs, int[] outlineIndices, Vector2[] outlineHotspotUVs)
		{
			Vector2[] array = new Vector2[normalUVs.Length];
			TransHotspotData[] array2 = new TransHotspotData[(outlineIndices.Length == 3) ? 1 : 2];
			TransHotspotData[] array3 = new TransHotspotData[(outlineIndices.Length == 3) ? 1 : 2];
			if (outlineIndices.Length == 3)
			{
				array2[0].PreProcess(new Vector2[3]
				{
					normalUVs[outlineIndices[0]],
					normalUVs[outlineIndices[1]],
					normalUVs[outlineIndices[2]]
				});
				array3[0].PreProcess(new Vector2[3]
				{
					outlineHotspotUVs[0],
					outlineHotspotUVs[1],
					outlineHotspotUVs[2]
				});
			}
			else
			{
				array2[0].PreProcess(new Vector2[3]
				{
					normalUVs[outlineIndices[0]],
					normalUVs[outlineIndices[1]],
					normalUVs[outlineIndices[2]]
				});
				array3[0].PreProcess(new Vector2[3]
				{
					outlineHotspotUVs[0],
					outlineHotspotUVs[1],
					outlineHotspotUVs[2]
				});
				array2[1].PreProcess(new Vector2[3]
				{
					normalUVs[outlineIndices[0]],
					normalUVs[outlineIndices[1]],
					normalUVs[outlineIndices[3]]
				});
				array3[1].PreProcess(new Vector2[3]
				{
					outlineHotspotUVs[0],
					outlineHotspotUVs[1],
					outlineHotspotUVs[3]
				});
			}
			for (int i = 0; i < normalUVs.Length; i++)
			{
				int num = Array.IndexOf(outlineIndices, i);
				if (num != -1)
				{
					array[i] = outlineHotspotUVs[num];
					continue;
				}
				Vector2 vector = Vector2.zero;
				for (int j = 0; j < array2.Length; j++)
				{
					Vector2 uV = array2[j].GetUV(normalUVs[i]);
					if (0f <= uV.x + uV.y && uV.x + uV.y <= 1f)
					{
						vector = array3[j].GetPos(uV);
						break;
					}
				}
				array[i] = vector;
			}
			return array;
		}

		public Vector2[] GetHotspotUVs(Vector2[] normalUVs, PlaneEx plane, int[] outlineIndices, int padding, float scale, float priority)
		{
			if (outlineIndices.Length < 3 || hotspotList.Count == 0)
			{
				return null;
			}
			float num = 1f - priority;
			Vector2 padding2 = default(Vector2);
			if (texture != null)
			{
				padding2.x = (float)padding / (float)texture.width;
				padding2.y = (float)padding / (float)texture.height;
			}
			else
			{
				padding2.x = (float)padding / 1024f;
				padding2.y = (float)padding / 1024f;
			}
			if (outlineIndices.Length == 3)
			{
				float[] array = new float[outlineIndices.Length];
				float[] array2 = new float[outlineIndices.Length];
				int num2 = outlineIndices.Length - 1;
				for (int i = 0; i < outlineIndices.Length; i++)
				{
					int num3 = (i + 1) % outlineIndices.Length;
					array[i] = Vector2.Angle(normalUVs[outlineIndices[num2]] - normalUVs[outlineIndices[i]], normalUVs[outlineIndices[num3]] - normalUVs[outlineIndices[i]]);
					array2[i] = Vector2.Distance(normalUVs[outlineIndices[num3]], normalUVs[outlineIndices[i]]);
					num2 = i;
				}
				float gab = float.MaxValue;
				Dictionary<Hotspot, float> dictionary = new Dictionary<Hotspot, float>();
				foreach (Hotspot hotspot2 in hotspotList)
				{
					if (hotspot2.uvs.Count != 3)
					{
						continue;
					}
					Hotspot hotspot = hotspot2.Clone();
					hotspot.SetPadding(padding2);
					for (int j = 0; j < 2; j++)
					{
						for (int k = 0; k < 3; k++)
						{
							float num4 = 0f;
							float[] angles = hotspot.GetAngles();
							float[] lengths = hotspot.GetLengths();
							for (int l = 0; l < 3; l++)
							{
								num4 += Mathf.Abs(angles[l] - array[l]) * priority;
								num4 += Mathf.Abs(array2[l] - lengths[l]) * num;
							}
							num4 = Mathf.Round(num4);
							dictionary.Add(hotspot.Clone(), num4);
							if (num4 < gab)
							{
								gab = num4;
							}
							hotspot.Rotation();
						}
						hotspot.Reverse();
					}
				}
				if (dictionary != null && dictionary.Count > 0)
				{
					gab *= 1.1f;
					List<Hotspot> list = (from a in dictionary
						where a.Value <= gab
						select a.Key).ToList();
					if (normalUVs.Length == 3)
					{
						return list[UnityEngine.Random.Range(0, list.Count - 1)].uvs.ToArray();
					}
					return TransHotspot(normalUVs, outlineIndices, list[UnityEngine.Random.Range(0, list.Count - 1)].uvs.ToArray());
				}
			}
			if (outlineIndices.Length == 4)
			{
				AABB aABB = new AABB();
				aABB.Reset();
				for (int num5 = 0; num5 < outlineIndices.Length; num5++)
				{
					aABB.Add(normalUVs[num5]);
				}
				float width = aABB.max.x - aABB.min.x;
				float height = aABB.max.y - aABB.min.y;
				Hotspot hotspotRect = GetHotspotRect(width, height, padding2, scale, plane.up);
				if (hotspotRect != null)
				{
					if (normalUVs.Length == 4)
					{
						Vector2[] array3 = new Vector2[normalUVs.Length];
						int[] array4 = new int[normalUVs.Length];
						Vector3 center = aABB.GetCenter();
						for (int num6 = 0; num6 < outlineIndices.Length; num6++)
						{
							bool flag = center.x > normalUVs[outlineIndices[num6]].x;
							bool flag2 = center.y < normalUVs[outlineIndices[num6]].y;
							if (!flag && !flag2)
							{
								array4[num6] = 0;
								continue;
							}
							if (!flag && flag2)
							{
								array4[num6] = 1;
								continue;
							}
							if (flag && flag2)
							{
								array4[num6] = 2;
								continue;
							}
							if (flag && !flag2)
							{
								array4[num6] = 3;
								continue;
							}
							array4 = outlineIndices;
							break;
						}
						for (int num7 = 0; num7 < array3.Length; num7++)
						{
							array3[num7] = hotspotRect.uvs[array4[num7]];
						}
						return array3;
					}
					return TransHotspot(normalUVs, outlineIndices, hotspotRect.uvs.ToArray());
				}
			}
			AABB aABB2 = new AABB();
			aABB2.Reset();
			for (int num8 = 0; num8 < outlineIndices.Length; num8++)
			{
				aABB2.Add(normalUVs[outlineIndices[num8]]);
			}
			float num9 = aABB2.max.x - aABB2.min.x;
			float num10 = aABB2.max.y - aABB2.min.y;
			Hotspot hotspotRect2 = GetHotspotRect(num9, num10, padding2, scale, plane.up);
			if (hotspotRect2 != null)
			{
				Vector2 vector = aABB2.min;
				Vector2 vector2 = hotspotRect2.uvs[0];
				Vector2 vector3 = hotspotRect2.uvs[3] - hotspotRect2.uvs[0];
				Vector2 vector4 = hotspotRect2.uvs[1] - hotspotRect2.uvs[0];
				Vector2[] array5 = new Vector2[normalUVs.Length];
				for (int num11 = 0; num11 < array5.Length; num11++)
				{
					array5[num11] = vector2 + (1f - (normalUVs[num11].x - vector.x) / num9) * vector3 + (normalUVs[num11].y - vector.y) / num10 * vector4;
				}
				return array5;
			}
			return null;
		}

		public Vector2[] GetSelectedHotspotUnwrap(Vector2[] normalUVs, PlaneEx plane, int[] outlineIndices, int padding, float scaleWeight, float priority)
		{
			if (outlineIndices.Length < 3 || hotspotList.Count == 0 || hotspotList.Count <= selectedHotspotIndex || selectedHotspotIndex < 0)
			{
				return null;
			}
			Hotspot hotspot = hotspotList[selectedHotspotIndex];
			float num = 1f - priority;
			if (hotspot == null)
			{
				return null;
			}
			Vector2 padding2 = default(Vector2);
			if (texture != null)
			{
				padding2.x = (float)padding / (float)texture.width;
				padding2.y = (float)padding / (float)texture.height;
			}
			else
			{
				padding2.x = (float)padding / 1024f;
				padding2.y = (float)padding / 1024f;
			}
			if (outlineIndices.Length == 3 && hotspot.uvs.Count == 3)
			{
				float[] array = new float[outlineIndices.Length];
				float[] array2 = new float[outlineIndices.Length];
				int num2 = outlineIndices.Length - 1;
				for (int i = 0; i < outlineIndices.Length; i++)
				{
					int num3 = (i + 1) % outlineIndices.Length;
					array[i] = Vector2.Angle(normalUVs[outlineIndices[num2]] - normalUVs[outlineIndices[i]], normalUVs[outlineIndices[num3]] - normalUVs[outlineIndices[i]]);
					array2[i] = Vector2.Distance(normalUVs[outlineIndices[num3]], normalUVs[outlineIndices[i]]);
					num2 = i;
				}
				float gab = float.MaxValue;
				Dictionary<Hotspot, float> dictionary = new Dictionary<Hotspot, float>();
				Hotspot hotspot2 = hotspot.Clone();
				hotspot2.SetPadding(padding2);
				for (int j = 0; j < 2; j++)
				{
					for (int k = 0; k < 3; k++)
					{
						float num4 = 0f;
						float[] angles = hotspot2.GetAngles();
						float[] lengths = hotspot2.GetLengths();
						for (int l = 0; l < 3; l++)
						{
							num4 += Mathf.Abs(angles[l] - array[l]) * priority;
							num4 += Mathf.Abs(array2[l] - lengths[l] * scaleWeight) * num;
						}
						num4 = Mathf.Round(num4);
						dictionary.Add(hotspot2.Clone(), num4);
						if (num4 < gab)
						{
							gab = num4;
						}
						hotspot2.Rotation();
					}
					hotspot2.Reverse();
				}
				if (dictionary != null && dictionary.Count > 0)
				{
					List<Hotspot> list = (from a in dictionary
						where a.Value <= gab
						select a.Key).ToList();
					if (normalUVs.Length == 3)
					{
						return list[UnityEngine.Random.Range(0, list.Count - 1)].uvs.ToArray();
					}
					return TransHotspot(normalUVs, outlineIndices, list[UnityEngine.Random.Range(0, list.Count - 1)].uvs.ToArray());
				}
			}
			if (outlineIndices.Length == 4)
			{
				AABB aABB = new AABB();
				aABB.Reset();
				for (int num5 = 0; num5 < outlineIndices.Length; num5++)
				{
					aABB.Add(normalUVs[num5]);
				}
				float width = aABB.max.x - aABB.min.x;
				float height = aABB.max.y - aABB.min.y;
				Hotspot hotspotRect = GetHotspotRect(width, height, padding2, scaleWeight, plane.up, hotspot);
				if (hotspotRect != null)
				{
					if (normalUVs.Length == 4)
					{
						Vector2[] array3 = new Vector2[normalUVs.Length];
						int[] array4 = new int[normalUVs.Length];
						Vector3 center = aABB.GetCenter();
						for (int num6 = 0; num6 < outlineIndices.Length; num6++)
						{
							bool flag = center.x > normalUVs[outlineIndices[num6]].x;
							bool flag2 = center.y < normalUVs[outlineIndices[num6]].y;
							if (!flag && !flag2)
							{
								array4[num6] = 0;
								continue;
							}
							if (!flag && flag2)
							{
								array4[num6] = 1;
								continue;
							}
							if (flag && flag2)
							{
								array4[num6] = 2;
								continue;
							}
							if (flag && !flag2)
							{
								array4[num6] = 3;
								continue;
							}
							array4 = outlineIndices;
							break;
						}
						for (int num7 = 0; num7 < array3.Length; num7++)
						{
							array3[num7] = hotspotRect.uvs[array4[num7]];
						}
						return array3;
					}
					return TransHotspot(normalUVs, outlineIndices, hotspotRect.uvs.ToArray());
				}
			}
			AABB aABB2 = new AABB();
			aABB2.Reset();
			for (int num8 = 0; num8 < outlineIndices.Length; num8++)
			{
				aABB2.Add(normalUVs[outlineIndices[num8]]);
			}
			float num9 = aABB2.max.x - aABB2.min.x;
			float num10 = aABB2.max.y - aABB2.min.y;
			if (GetHotspotRect(num9, num10, padding2, scaleWeight, plane.up, hotspot) != null)
			{
				Vector2 vector = aABB2.min;
				Vector2 vector2 = hotspot.uvs[0];
				Vector2 vector3 = hotspot.uvs[3] - hotspot.uvs[0];
				Vector2 vector4 = hotspot.uvs[1] - hotspot.uvs[0];
				Vector2[] array5 = new Vector2[normalUVs.Length];
				for (int num11 = 0; num11 < array5.Length; num11++)
				{
					array5[num11] = vector2 + (1f - (normalUVs[num11].x - vector.x) / num9) * vector3 + (normalUVs[num11].y - vector.y) / num10 * vector4;
				}
				return array5;
			}
			return null;
		}

		private Hotspot GetHotspotRect(float width, float height, Vector2 padding, float scale, Vector3 up, Hotspot selectedHotspot = null)
		{
			List<Hotspot> list = new List<Hotspot>();
			float num = width / height;
			float num2 = float.MaxValue;
			float num3 = float.MaxValue;
			foreach (Hotspot hotspot3 in hotspotList)
			{
				if (hotspot3.uvs.Count != 4 || (selectedHotspot != null && selectedHotspot != hotspot3))
				{
					continue;
				}
				Hotspot hotspot = hotspot3.Clone();
				hotspot.Sort();
				hotspot.SetPadding(padding);
				bool flag = Mathf.Abs(up.x) < up.y && Mathf.Abs(up.z) < up.y && up.y > 0.1f;
				if (Mathf.Abs(up.x) < up.y && Mathf.Abs(up.z) < up.y && up.y < -0.1f)
				{
					Debug.LogError("Downs");
				}
				for (int i = 0; i < 4; i++)
				{
					float[] lengths = hotspot.GetLengths();
					float num4 = lengths[1] / lengths[0];
					float num5 = lengths[0] * scale;
					bool flag2 = true;
					if (hotspot.IsYLock)
					{
						flag2 = false;
						if (hotspot.yUpLock && flag)
						{
							flag2 = true;
						}
					}
					if (Mathf.Abs(1f - num4 / num) < Mathf.Abs(1f - num2 / num) && flag2)
					{
						list.Clear();
						list.Add(hotspot.Clone());
						num2 = num4;
						num3 = num5;
					}
					else if (num2 == num4 && flag2)
					{
						if (Mathf.Abs(width - num5) < Mathf.Abs(width - num3))
						{
							list.Clear();
							list.Add(hotspot.Clone());
							num3 = num5;
						}
						else if (num3 == num5)
						{
							list.Add(hotspot.Clone());
						}
					}
					hotspot.Rotation();
				}
			}
			if (list.Count > 0)
			{
				Hotspot hotspot2 = list[UnityEngine.Random.Range(0, list.Count)];
				if (UnityEngine.Random.Range(0, 2) == 0)
				{
					hotspot2.Reverse();
				}
				return hotspot2;
			}
			return null;
		}

		public bool InvalidHotspotList()
		{
			return hotspotList.Count <= 0;
		}

		public bool InvalidSelectedIndex()
		{
			if (selectedHotspotIndex >= 0)
			{
				return hotspotList.Count <= selectedHotspotIndex;
			}
			return true;
		}
	}
}
