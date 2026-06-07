using System;
using System.Collections.Generic;
using UnityEngine;

public static class CircleCoverage
{
	private static float AngleDelta(float a, float b)
	{
		float result = b - a;
		if (a > b)
		{
			result = b + (float)Math.PI * 2f - a;
		}
		return result;
	}

	public static float PointToAngle(Vector2 center, Vector2 pos)
	{
		return (float)Math.PI + Mathf.Atan2(pos.y - center.y, pos.x - center.x);
	}

	private static bool Overlap(float x, float a, float b)
	{
		if (a > b)
		{
			if (!(x >= a))
			{
				return x <= b;
			}
			return true;
		}
		if (x >= a)
		{
			return x <= b;
		}
		return false;
	}

	public static void CorrectDirection(float[] segment)
	{
		if (AngleDelta(segment[0], segment[1]) > (float)Math.PI)
		{
			float num = segment[0];
			segment[0] = segment[1];
			segment[1] = num;
		}
	}

	public static float GetCoverage(List<float[]> segs)
	{
		float num = 0f;
		for (int i = 0; i < segs.Count; i++)
		{
			num += AngleDelta(segs[i][0], segs[i][1]);
		}
		return num / ((float)Math.PI * 2f);
	}

	public static void MergeSegments(List<float[]> segs)
	{
		bool flag = false;
		bool flag2 = true;
		while (flag2 && !flag)
		{
			flag2 = false;
			for (int i = 0; i < segs.Count; i++)
			{
				for (int j = 0; j < segs.Count; j++)
				{
					if (i >= segs.Count)
					{
						break;
					}
					if (j == i)
					{
						continue;
					}
					if (Overlap(segs[i][0], segs[j][0], segs[j][1]))
					{
						if (Overlap(segs[i][1], segs[j][0], segs[j][1]))
						{
							if (AngleDelta(segs[j][0], segs[i][0]) > AngleDelta(segs[j][0], segs[i][1]))
							{
								flag = true;
								break;
							}
							flag2 = true;
							segs.RemoveAt(i);
							i--;
							break;
						}
						flag2 = true;
						segs[i][0] = segs[j][0];
						segs.RemoveAt(j);
						j--;
					}
					else if (Overlap(segs[i][1], segs[j][0], segs[j][1]))
					{
						flag2 = true;
						segs[i][1] = segs[j][1];
						segs.RemoveAt(j);
						j--;
					}
				}
				if (flag)
				{
					break;
				}
			}
		}
		if (flag)
		{
			segs.Clear();
			segs.Add(new float[2]
			{
				0f,
				(float)Math.PI * 2f
			});
		}
	}

	public static void SubtractSegments(List<float[]> segs, List<float[]> neg)
	{
		if (neg.Count == 1 && AngleDelta(neg[0][0], neg[0][1]) >= (float)Math.PI * 2f)
		{
			segs.Clear();
			return;
		}
		for (int i = 0; i < neg.Count; i++)
		{
			for (int j = 0; j < segs.Count; j++)
			{
				if (AngleDelta(segs[j][0], segs[j][1]) >= (float)Math.PI * 2f)
				{
					segs[j][0] = neg[i][1];
					segs[j][1] = neg[i][0];
					break;
				}
				if (Overlap(neg[i][0], segs[j][0], segs[j][1]))
				{
					if (Overlap(neg[i][1], segs[j][0], segs[j][1]))
					{
						if (AngleDelta(segs[j][0], neg[i][0]) > AngleDelta(segs[j][0], neg[i][1]))
						{
							segs[j][0] = neg[i][1];
							segs[j][1] = neg[i][0];
							break;
						}
						float num = segs[j][0];
						float num2 = neg[i][0];
						float num3 = neg[i][1];
						float num4 = segs[j][1];
						segs[j][0] = num;
						segs[j][1] = num2;
						segs.Add(new float[2] { num3, num4 });
						break;
					}
					segs[j][1] = neg[i][0];
				}
				else if (Overlap(neg[i][1], segs[j][0], segs[j][1]))
				{
					segs[j][0] = neg[i][1];
				}
				else if (Overlap(segs[j][0], neg[i][0], neg[i][1]) && Overlap(segs[j][1], neg[i][0], neg[i][1]))
				{
					segs.RemoveAt(j);
					j--;
				}
			}
		}
	}

	public static int FindLineCircleIntersections(Vector2 center, float radius, Vector2 point1, Vector2 point2, out Vector2 intersection1, out Vector2 intersection2, bool segments)
	{
		float num = point2.x - point1.x;
		float num2 = point2.y - point1.y;
		float num3 = num * num + num2 * num2;
		float num4 = 2f * (num * (point1.x - center.x) + num2 * (point1.y - center.y));
		float num5 = (point1.x - center.x) * (point1.x - center.x) + (point1.y - center.y) * (point1.y - center.y) - radius * radius;
		float num6 = num4 * num4 - 4f * num3 * num5;
		if ((double)num3 <= 1E-07 || num6 < 0f)
		{
			intersection1 = new Vector2(float.NaN, float.NaN);
			intersection2 = new Vector2(float.NaN, float.NaN);
			return 0;
		}
		float num7;
		if (num6 == 0f)
		{
			num7 = (0f - num4) / (2f * num3);
			intersection1 = new Vector2(float.NaN, float.NaN);
			intersection2 = new Vector2(float.NaN, float.NaN);
			if (segments)
			{
				return 0;
			}
			intersection1 = new Vector2(point1.x + num7 * num, point1.y + num7 * num2);
			return 1;
		}
		num7 = (0f - num4 + Mathf.Sqrt(num6)) / (2f * num3);
		intersection1 = new Vector2(point1.x + num7 * num, point1.y + num7 * num2);
		int num8 = 0 | ((!segments || (num7 >= 0f && num7 <= 1f)) ? 1 : 0);
		num7 = (0f - num4 - Mathf.Sqrt(num6)) / (2f * num3);
		intersection2 = new Vector2(point1.x + num7 * num, point1.y + num7 * num2);
		if (((uint)num8 | ((!segments || (num7 >= 0f && num7 <= 1f)) ? 1u : 0u)) == 0)
		{
			return 0;
		}
		return 2;
	}
}
