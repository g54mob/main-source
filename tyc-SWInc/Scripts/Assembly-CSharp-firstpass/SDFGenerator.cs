using System;
using System.Collections;
using System.Linq;
using System.Threading;
using UnityEngine;

public static class SDFGenerator
{
	public static IEnumerator ApplySDF(this RenderTexture rt, int size, bool immediateDestroy = false, bool insideOnly = false, int threads = 4, bool signed = false, Texture2D signedOutput = null)
	{
		Texture2D tex = new Texture2D(rt.width, rt.height, TextureFormat.ARGB32, false);
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = rt;
		tex.ReadPixels(new Rect(0f, 0f, rt.width, rt.height), 0, 0, false);
		RenderTexture.active = active;
		tex.Apply();
		Color32[] p = tex.GetPixels32();
		int w = tex.width;
		int h = tex.height;
		Thread[] ts = new Thread[threads];
		float[] res = new float[p.Length];
		int part = p.Length / threads;
		for (int i = 0; i < threads; i++)
		{
			int s = i * part;
			ts[i] = new Thread((ThreadStart)delegate
			{
				CalculateSDF(p, res, w, h, size, s, s + part, insideOnly);
			});
			ts[i].Start();
		}
		for (int i2 = 0; i2 < threads; i2++)
		{
			while (ts[i2].IsAlive)
			{
				yield return null;
			}
		}
		int globalD = rt.width;
		Thread endT = new Thread((ThreadStart)delegate
		{
			FinishSDF(p, res, insideOnly, signed, globalD);
		});
		endT.Start();
		while (endT.IsAlive)
		{
			yield return null;
		}
		if (signed)
		{
			signedOutput.SetPixels(res.Select((float x) => new Color(x, x, x, 1f)).ToArray());
			signedOutput.Apply(false);
		}
		else
		{
			tex.SetPixels32(p);
			tex.Apply(true);
			Graphics.Blit(tex, rt);
		}
		if (immediateDestroy)
		{
			UnityEngine.Object.DestroyImmediate(tex);
		}
		else
		{
			UnityEngine.Object.Destroy(tex);
		}
	}

	private static void FinishSDF(Color32[] p, float[] res, bool insideOnly, bool signed, float globalD)
	{
		float num = 0f;
		float b = 0f;
		if (!signed)
		{
			for (int i = 0; i < res.Length; i++)
			{
				if (!float.IsInfinity(res[i]))
				{
					b = Mathf.Max(res[i], b);
					num = Mathf.Min(res[i], num);
				}
			}
		}
		for (int j = 0; j < res.Length; j++)
		{
			if (signed)
			{
				if (float.IsPositiveInfinity(res[j]))
				{
					res[j] = -1f;
				}
				else if (float.IsNegativeInfinity(res[j]))
				{
					res[j] = 1f;
				}
				else
				{
					res[j] = (0f - res[j]) / globalD;
				}
			}
			else if (float.IsPositiveInfinity(res[j]))
			{
				res[j] = 1f;
			}
			else if (float.IsNegativeInfinity(res[j]))
			{
				res[j] = 0f;
			}
			else if (res[j] < 0f)
			{
				res[j] = MapRange(res[j], num, 0f, 0f, 0.5f, true);
			}
			else if (res[j] > 0f)
			{
				res[j] = MapRange(res[j], 0f, b, insideOnly ? 0f : 0.5f, 1f, true);
			}
			else
			{
				res[j] = (insideOnly ? 0f : 0.5f);
			}
		}
		if (!signed)
		{
			for (int k = 0; k < res.Length; k++)
			{
				byte b2 = (byte)Mathf.RoundToInt(res[k] * 255f);
				p[k] = new Color32(b2, b2, b2, (byte)Mathf.RoundToInt(MapRange(res[k], 0.45f, 0.5f, 0f, 255f, true)));
			}
		}
	}

	private static void CalculateSDF(Color32[] p, float[] res, int w, int h, int size, int a, int b, bool insideOnly)
	{
		for (int i = a; i < b; i++)
		{
			int num = i % w;
			int num2 = i / w;
			if (num == 0 || num == w - 1 || num2 == 0 || num2 == h - 1)
			{
				res[i] = float.NegativeInfinity;
			}
			else
			{
				res[i] = FindClosest(num, num2, p, w, h, size, 128, insideOnly);
			}
		}
	}

	private static float Distance(Vector2 a)
	{
		return a.magnitude;
	}

	public static float FindClosest(int x, int y, Color32[] tex, int w, int h, int max, byte thresh, bool insideOnly)
	{
		if (insideOnly)
		{
			thresh = 1;
		}
		bool flag = !insideOnly && Sample(tex, x, y, w).r < thresh;
		for (int i = 1; i < max; i++)
		{
			ValueTuple<int, int>? valueTuple = CheckCircle(x, y, i, w, h, tex, flag, thresh);
			if (valueTuple.HasValue)
			{
				if (!flag && Mathf.Max(Mathf.Abs(valueTuple.Value.Item1 - x), Mathf.Abs(valueTuple.Value.Item2 - y)) == 1)
				{
					return 0f;
				}
				return Distance(new Vector2(x, y) - new Vector2(valueTuple.Value.Item1, valueTuple.Value.Item2)) * (float)((!flag) ? 1 : (-1));
			}
		}
		if (!flag)
		{
			return float.PositiveInfinity;
		}
		return float.NegativeInfinity;
	}

	public static ValueTuple<int, int>? CheckCircle(int centerX, int centerY, int radius, int w, int h, Color32[] tex, bool outside, byte thresh)
	{
		int num = (5 - radius * 4) / 4;
		int num2 = 0;
		int num3 = radius;
		do
		{
			if (centerX + num2 >= 0 && centerX + num2 <= w - 1 && centerY + num3 >= 0 && centerY + num3 <= h - 1 && ((Sample(tex, centerX + num2, centerY + num3, w).r < thresh) ^ outside))
			{
				return new ValueTuple<int, int>(centerX + num2, centerY + num3);
			}
			if (centerX + num2 >= 0 && centerX + num2 <= w - 1 && centerY - num3 >= 0 && centerY - num3 <= h - 1 && ((Sample(tex, centerX + num2, centerY - num3, w).r < thresh) ^ outside))
			{
				return new ValueTuple<int, int>(centerX + num2, centerY - num3);
			}
			if (centerX - num2 >= 0 && centerX - num2 <= w - 1 && centerY + num3 >= 0 && centerY + num3 <= h - 1 && ((Sample(tex, centerX - num2, centerY + num3, w).r < thresh) ^ outside))
			{
				return new ValueTuple<int, int>(centerX - num2, centerY + num3);
			}
			if (centerX - num2 >= 0 && centerX - num2 <= w - 1 && centerY - num3 >= 0 && centerY - num3 <= h - 1 && ((Sample(tex, centerX - num2, centerY - num3, w).r < thresh) ^ outside))
			{
				return new ValueTuple<int, int>(centerX - num2, centerY - num3);
			}
			if (centerX + num3 >= 0 && centerX + num3 <= w - 1 && centerY + num2 >= 0 && centerY + num2 <= h - 1 && ((Sample(tex, centerX + num3, centerY + num2, w).r < thresh) ^ outside))
			{
				return new ValueTuple<int, int>(centerX + num3, centerY + num2);
			}
			if (centerX + num3 >= 0 && centerX + num3 <= w - 1 && centerY - num2 >= 0 && centerY - num2 <= h - 1 && ((Sample(tex, centerX + num3, centerY - num2, w).r < thresh) ^ outside))
			{
				return new ValueTuple<int, int>(centerX + num3, centerY - num2);
			}
			if (centerX - num3 >= 0 && centerX - num3 <= w - 1 && centerY + num2 >= 0 && centerY + num2 <= h - 1 && ((Sample(tex, centerX - num3, centerY + num2, w).r < thresh) ^ outside))
			{
				return new ValueTuple<int, int>(centerX - num3, centerY + num2);
			}
			if (centerX - num3 >= 0 && centerX - num3 <= w - 1 && centerY - num2 >= 0 && centerY - num2 <= h - 1 && ((Sample(tex, centerX - num3, centerY - num2, w).r < thresh) ^ outside))
			{
				return new ValueTuple<int, int>(centerX - num3, centerY - num2);
			}
			if (num < 0)
			{
				num += 2 * num2 + 1;
			}
			else
			{
				num += 2 * (num2 - num3) + 1;
				num3--;
			}
			num2++;
		}
		while (num2 <= num3);
		return null;
	}

	public static void DrawCircle(int centerX, int centerY, int radius, int w, int h, Color32[] tex)
	{
		int num = (5 - radius * 4) / 4;
		int num2 = 0;
		int num3 = radius;
		do
		{
			if (centerX + num2 >= 0 && centerX + num2 <= w - 1 && centerY + num3 >= 0 && centerY + num3 <= h - 1)
			{
				SetSample(tex, centerX + num2, centerY + num3, w, new Color32(0, 0, 0, byte.MaxValue));
			}
			if (centerX + num2 >= 0 && centerX + num2 <= w - 1 && centerY - num3 >= 0 && centerY - num3 <= h - 1)
			{
				SetSample(tex, centerX + num2, centerY - num3, w, new Color32(0, 0, 0, byte.MaxValue));
			}
			if (centerX - num2 >= 0 && centerX - num2 <= w - 1 && centerY + num3 >= 0 && centerY + num3 <= h - 1)
			{
				SetSample(tex, centerX - num2, centerY + num3, w, new Color32(0, 0, 0, byte.MaxValue));
			}
			if (centerX - num2 >= 0 && centerX - num2 <= w - 1 && centerY - num3 >= 0 && centerY - num3 <= h - 1)
			{
				SetSample(tex, centerX - num2, centerY - num3, w, new Color32(0, 0, 0, byte.MaxValue));
			}
			if (centerX + num3 >= 0 && centerX + num3 <= w - 1 && centerY + num2 >= 0 && centerY + num2 <= h - 1)
			{
				SetSample(tex, centerX + num3, centerY + num2, w, new Color32(0, 0, 0, byte.MaxValue));
			}
			if (centerX + num3 >= 0 && centerX + num3 <= w - 1 && centerY - num2 >= 0 && centerY - num2 <= h - 1)
			{
				SetSample(tex, centerX + num3, centerY - num2, w, new Color32(0, 0, 0, byte.MaxValue));
			}
			if (centerX - num3 >= 0 && centerX - num3 <= w - 1 && centerY + num2 >= 0 && centerY + num2 <= h - 1)
			{
				SetSample(tex, centerX - num3, centerY + num2, w, new Color32(0, 0, 0, byte.MaxValue));
			}
			if (centerX - num3 >= 0 && centerX - num3 <= w - 1 && centerY - num2 >= 0 && centerY - num2 <= h - 1)
			{
				SetSample(tex, centerX - num3, centerY - num2, w, new Color32(0, 0, 0, byte.MaxValue));
			}
			if (num < 0)
			{
				num += 2 * num2 + 1;
			}
			else
			{
				num += 2 * (num2 - num3) + 1;
				num3--;
			}
			num2++;
		}
		while (num2 <= num3);
	}

	public static void SetSample(Color32[] tex, int x, int y, int w, Color32 v)
	{
		tex[y * w + x] = v;
	}

	public static Color32 Sample(Color32[] tex, int x, int y, int w)
	{
		return tex[y * w + x];
	}

	public static float MapRange(float x, float a, float b, float c, float d, bool clamp = false)
	{
		if (clamp)
		{
			if (a > b)
			{
				if (x >= a)
				{
					return c;
				}
				if (x <= b)
				{
					return d;
				}
			}
			else
			{
				if (x >= b)
				{
					return d;
				}
				if (x <= a)
				{
					return c;
				}
			}
		}
		float num = b - a;
		float num2 = ((num == 0f) ? (x - a) : ((x - a) / num));
		float num3 = d - c;
		return num2 * num3 + c;
	}
}
