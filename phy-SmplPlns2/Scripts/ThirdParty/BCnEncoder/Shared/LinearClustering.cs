using System;
using System.Collections.Generic;

namespace BCnEncoder.Shared
{
	internal static class LinearClustering
	{
		private struct LabXy
		{
			public float l;

			public float a;

			public float b;

			public float x;

			public float y;

			public static LabXy operator +(LabXy left, LabXy right)
			{
				return new LabXy
				{
					l = left.l + right.l,
					a = left.a + right.a,
					b = left.b + right.b,
					x = left.x + right.x,
					y = left.y + right.y
				};
			}

			public static LabXy operator /(LabXy left, int right)
			{
				return new LabXy
				{
					l = left.l / (float)right,
					a = left.a / (float)right,
					b = left.b / (float)right,
					x = left.x / (float)right,
					y = left.y / (float)right
				};
			}
		}

		private struct ClusterCenter
		{
			public float l;

			public float a;

			public float b;

			public float x;

			public float y;

			public int count;

			public ClusterCenter(LabXy labxy)
			{
				l = labxy.l;
				a = labxy.a;
				b = labxy.b;
				x = labxy.x;
				y = labxy.y;
				count = 0;
			}

			public readonly float Distance(LabXy other, float m, float s)
			{
				float num = MathF.Sqrt(MathF.Pow(l - other.l, 2f) + MathF.Pow(a - other.a, 2f) + MathF.Pow(b - other.b, 2f));
				float num2 = MathF.Sqrt(MathF.Pow(x - other.x, 2f) + MathF.Pow(y - other.y, 2f));
				return num + m / s * num2;
			}

			public readonly float Distance(ClusterCenter other, float m, float s)
			{
				float num = MathF.Sqrt((l - other.l) * (l - other.l) + (a - other.a) * (a - other.a) + (b - other.b) * (b - other.b));
				float num2 = MathF.Sqrt((x - other.x) * (x - other.x) + (y - other.y) * (y - other.y));
				return num + m / s * num2;
			}

			public static ClusterCenter operator +(ClusterCenter left, LabXy right)
			{
				return new ClusterCenter
				{
					l = left.l + right.l,
					a = left.a + right.a,
					b = left.b + right.b,
					x = left.x + right.x,
					y = left.y + right.y,
					count = left.count + 1
				};
			}

			public static ClusterCenter operator /(ClusterCenter left, int right)
			{
				return new ClusterCenter
				{
					l = left.l / (float)right,
					a = left.a / (float)right,
					b = left.b / (float)right,
					x = left.x / (float)right,
					y = left.y / (float)right,
					count = left.count
				};
			}
		}

		public static int[] ClusterPixels(ReadOnlySpan<ColorRgba32> pixels, int width, int height, int clusters, float m = 10f, int maxIterations = 10, bool enforceConnectivity = true)
		{
			ColorRgbFloat[] array = new ColorRgbFloat[pixels.Length];
			for (int i = 0; i < pixels.Length; i++)
			{
				array[i] = pixels[i].ToRgbFloat();
			}
			return ClusterPixels(array, width, height, clusters, m, maxIterations, enforceConnectivity);
		}

		public static int[] ClusterPixels(ReadOnlySpan<ColorRgbFloat> pixels, int width, int height, int clusters, float m = 10f, int maxIterations = 10, bool enforceConnectivity = true)
		{
			if (clusters < 2)
			{
				throw new ArgumentException("Number of clusters should be more than 1");
			}
			float num = MathF.Sqrt((float)pixels.Length / (float)clusters);
			int[] array = new int[pixels.Length];
			LabXy[] array2 = ConvertToLabXy(pixels, width, height);
			Span<ClusterCenter> clusterCenters = InitialClusterCenters(width, height, clusters, num, array2);
			Span<ClusterCenter> span = new ClusterCenter[clusters];
			float num2 = 999f;
			int num3 = 0;
			while (num2 > 0.1f && (maxIterations <= 0 || num3 < maxIterations))
			{
				num3++;
				clusterCenters.CopyTo(span);
				Array.Fill(array, -1);
				for (int i = 0; i < clusters; i++)
				{
					int num4 = Math.Max(0, (int)(clusterCenters[i].x - num));
					int num5 = Math.Min(width, (int)(clusterCenters[i].x + num));
					int num6 = Math.Max(0, (int)(clusterCenters[i].y - num));
					int num7 = Math.Min(height, (int)(clusterCenters[i].y + num));
					for (int j = num4; j < num5; j++)
					{
						for (int k = num6; k < num7; k++)
						{
							int num8 = j + k * width;
							if (array[num8] == -1)
							{
								array[num8] = i;
								continue;
							}
							float num9 = clusterCenters[array[num8]].Distance(array2[num8], m, num);
							if (clusterCenters[i].Distance(array2[num8], m, num) < num9)
							{
								array[num8] = i;
							}
						}
					}
				}
				num2 = RecalculateCenters(clusters, m, array2, array, span, num, ref clusterCenters);
			}
			if (enforceConnectivity)
			{
				array = EnforceConnectivity(array, width, height, clusters);
			}
			return array;
		}

		private static float RecalculateCenters(int clusters, float m, LabXy[] labXys, int[] clusterIndices, Span<ClusterCenter> previousCenters, float s, ref Span<ClusterCenter> clusterCenters)
		{
			clusterCenters.Clear();
			for (int i = 0; i < labXys.Length; i++)
			{
				int num = clusterIndices[i];
				if (num == -1)
				{
					int num2 = 0;
					float num3 = previousCenters[0].Distance(labXys[i], m, s);
					for (int j = 1; j < clusters; j++)
					{
						float num4 = previousCenters[j].Distance(labXys[i], m, s);
						if (num4 < num3)
						{
							num3 = num4;
							num2 = j;
						}
					}
					clusterCenters[num2] += labXys[i];
					clusterIndices[i] = num2;
				}
				else
				{
					clusterCenters[num] += labXys[i];
				}
			}
			float num5 = 0f;
			for (int k = 0; k < clusters; k++)
			{
				if (clusterCenters[k].count > 0)
				{
					clusterCenters[k] /= clusterCenters[k].count;
					num5 += clusterCenters[k].Distance(previousCenters[k], m, s);
				}
			}
			return num5 / (float)clusters;
		}

		private static ClusterCenter[] InitialClusterCenters(int width, int height, int clusters, float s, LabXy[] labXys)
		{
			ClusterCenter[] array = new ClusterCenter[clusters];
			switch (clusters)
			{
			case 2:
			{
				int num5 = (int)MathF.Floor((float)width * 0.333f);
				int num6 = (int)MathF.Floor((float)height * 0.333f);
				int num7 = (int)MathF.Floor((float)width * 0.666f);
				int num8 = (int)MathF.Floor((float)height * 0.666f);
				int num9 = num5 + num6 * width;
				array[0] = new ClusterCenter(labXys[num9]);
				int num10 = num7 + num8 * width;
				array[1] = new ClusterCenter(labXys[num10]);
				break;
			}
			case 3:
			{
				int num11 = (int)MathF.Floor((float)width * 0.333f);
				int num12 = (int)MathF.Floor((float)height * 0.333f);
				int num13 = num11 + num12 * width;
				array[0] = new ClusterCenter(labXys[num13]);
				int num14 = (int)MathF.Floor((float)width * 0.666f);
				int num15 = (int)MathF.Floor((float)height * 0.333f);
				int num16 = num14 + num15 * width;
				array[1] = new ClusterCenter(labXys[num16]);
				int num17 = (int)MathF.Floor((float)width * 0.5f);
				int num18 = (int)MathF.Floor((float)height * 0.666f);
				int num19 = num17 + num18 * width;
				array[2] = new ClusterCenter(labXys[num19]);
				break;
			}
			default:
			{
				int num = 0;
				for (float num2 = s / 2f; num2 < (float)width; num2 += s)
				{
					for (float num3 = s / 2f; num3 < (float)height; num3 += s)
					{
						if (num >= array.Length)
						{
							break;
						}
						int num4 = (int)num2 + (int)num3 * width;
						array[num] = new ClusterCenter(labXys[num4]);
						num++;
					}
				}
				break;
			}
			}
			return array;
		}

		private static LabXy[] ConvertToLabXy(ReadOnlySpan<ColorRgba32> pixels, int width, int height)
		{
			LabXy[] array = new LabXy[pixels.Length];
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					int num = i + j * width;
					ColorLab colorLab = new ColorLab(pixels[num]);
					array[num] = new LabXy
					{
						l = colorLab.l,
						a = colorLab.a,
						b = colorLab.b,
						x = i,
						y = j
					};
				}
			}
			return array;
		}

		private static LabXy[] ConvertToLabXy(ReadOnlySpan<ColorRgbFloat> pixels, int width, int height)
		{
			LabXy[] array = new LabXy[pixels.Length];
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					int num = i + j * width;
					ColorLab colorLab = new ColorLab(pixels[num]);
					array[num] = new LabXy
					{
						l = colorLab.l,
						a = colorLab.a,
						b = colorLab.b,
						x = i,
						y = j
					};
				}
			}
			return array;
		}

		private static int[] EnforceConnectivity(int[] oldLabels, int width, int height, int clusters)
		{
			ReadOnlySpan<int> readOnlySpan = new int[4] { -1, 0, 1, 0 };
			ReadOnlySpan<int> readOnlySpan2 = new int[4] { 0, -1, 0, 1 };
			int num = width * height / clusters;
			List<int> list = new List<int>(num);
			List<int> list2 = new List<int>(num);
			int num2 = 0;
			int[] array = new int[oldLabels.Length];
			bool[] array2 = new bool[clusters];
			Array.Fill(array, -1);
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					int num3 = j + i * width;
					if (array[num3] >= 0)
					{
						continue;
					}
					int num4 = (array[num3] = oldLabels[num3]);
					list.Add(j);
					list2.Add(i);
					for (int k = 0; k < readOnlySpan.Length; k++)
					{
						int num5 = j + readOnlySpan[k];
						int num6 = i + readOnlySpan2[k];
						int num7 = num5 + num6 * width;
						if (num5 < width && num5 >= 0 && num6 < height && num6 >= 0 && array[num7] >= 0)
						{
							num2 = array[num7];
							break;
						}
					}
					for (int l = 0; l < list.Count; l++)
					{
						for (int m = 0; m < readOnlySpan.Length; m++)
						{
							int num8 = list[l] + readOnlySpan[m];
							int num9 = list2[l] + readOnlySpan2[m];
							int num10 = num8 + num9 * width;
							if (num8 < width && num8 >= 0 && num9 < height && num9 >= 0 && array[num10] == -1 && num4 == oldLabels[num10])
							{
								list.Add(num8);
								list2.Add(num9);
								array[num10] = num4;
							}
						}
					}
					if (list.Count < num / 4 || array2[num4])
					{
						for (int n = 0; n < list.Count; n++)
						{
							array[list2[n] * width + list[n]] = num2;
						}
					}
					else
					{
						array2[num4] = true;
					}
					list.Clear();
					list2.Clear();
				}
			}
			return array;
		}
	}
}
