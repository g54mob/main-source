using System;
using System.Collections.Generic;
using UnityEngine;

public class RenderTargetPool
{
	public class Temp : IDisposable
	{
		public RenderTexture rt;

		public bool inUse;

		public Temp(RenderTexture rt_)
		{
			rt = rt_;
			inUse = true;
		}

		public void Dispose()
		{
			Release();
		}

		public void Release()
		{
			inUse = false;
		}

		public static implicit operator RenderTexture(Temp temp)
		{
			return temp.rt;
		}
	}

	private static List<Temp> pool = new List<Temp>();

	public static void Flush()
	{
		List<Temp> list = new List<Temp>();
		foreach (Temp item in pool)
		{
			if (!item.inUse)
			{
				list.Add(item);
			}
		}
		Debug.LogFormat("Flushing {0} temp renderTargets", list.Count);
		foreach (Temp item2 in list)
		{
			UnityEngine.Object.Destroy(item2.rt);
			item2.rt = null;
			pool.Remove(item2);
		}
		list.Clear();
	}

	public static Temp CreateTemp(double scale = 1.0, bool wantDepth = false)
	{
		return CreateTemp((int)(scale * (double)Resolution.bufferW), (int)(scale * (double)Resolution.bufferH), RenderTextureFormat.ARGB32, FilterMode.Point, wantDepth);
	}

	public static Temp CreateTemp(RenderTexture template, double scale = 1.0, bool wantDepth = false)
	{
		Temp temp = Alloc((int)(scale * (double)template.width), (int)(scale * (double)template.height), wantDepth, template.format);
		temp.rt.filterMode = template.filterMode;
		return temp;
	}

	public static Temp CreateTemp(int width, int height, RenderTextureFormat format, FilterMode filterMode, bool wantDepth = false)
	{
		Temp temp = Alloc(width, height, wantDepth, format);
		temp.rt.filterMode = filterMode;
		return temp;
	}

	private static Temp Alloc(int width, int height, bool wantDepth, RenderTextureFormat format)
	{
		int num = (wantDepth ? 24 : 0);
		foreach (Temp item in pool)
		{
			if (!item.inUse && item.rt.width == width && item.rt.height == height && item.rt.format == format && item.rt.depth == num)
			{
				item.inUse = true;
				return item;
			}
		}
		RenderTexture renderTexture = new RenderTexture(width, height, num, format, RenderTextureReadWrite.Linear);
		Debug.LogFormat("Allocating new RenderTarget.Temp (#{0} {1}x{2} {3} {4})", pool.Count, renderTexture.width, renderTexture.height, renderTexture.format, renderTexture.depth);
		Temp temp = new Temp(renderTexture);
		pool.Add(temp);
		return temp;
	}
}
