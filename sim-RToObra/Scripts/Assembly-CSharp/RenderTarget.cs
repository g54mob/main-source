using System;
using UnityEngine;

public class RenderTarget : IDisposable
{
	public class Spec
	{
		public int width;

		public int height;

		public bool wantDepth;

		public FilterMode filterMode;

		public int depthBits
		{
			get
			{
				return wantDepth ? 24 : 0;
			}
		}

		public RenderTextureFormat format
		{
			get
			{
				return RenderTextureFormat.ARGB32;
			}
		}

		public Spec(int width_, int height_)
		{
			width = width_;
			height = height_;
		}

		public Spec InitFilterModeBilinear()
		{
			filterMode = FilterMode.Bilinear;
			return this;
		}

		public Spec InitWantDepth()
		{
			wantDepth = true;
			return this;
		}
	}

	private readonly Spec spec;

	private RenderTexture rt_;

	private bool needsRealloc
	{
		get
		{
			return rt_ == null || spec.width != rt_.width || spec.height != rt_.height;
		}
	}

	public RenderTexture rt
	{
		get
		{
			if (needsRealloc)
			{
				Alloc();
			}
			return rt_;
		}
	}

	public RenderTarget(Spec spec_)
	{
		spec = spec_;
		Alloc();
	}

	public static implicit operator RenderTexture(RenderTarget helper)
	{
		return helper.rt;
	}

	public void Alloc()
	{
		if (rt_ != null)
		{
			Free();
		}
		rt_ = new RenderTexture(spec.width, spec.height, spec.depthBits, spec.format);
		rt_.filterMode = spec.filterMode;
		rt_.autoGenerateMips = false;
		rt_.Create();
	}

	public void Free()
	{
		if (!(rt_ == null))
		{
			Util.DestroyRenderTexture(rt_);
			rt_ = null;
		}
	}

	public void Dispose()
	{
		Free();
	}

	public void SetSize(int width, int height)
	{
		spec.width = width;
		spec.height = height;
		if (needsRealloc)
		{
			Alloc();
		}
	}

	public static void BlitBilinear(RenderTexture src, RenderTexture dst, Material material = null, int pass = -1)
	{
		FilterMode filterMode = src.filterMode;
		src.filterMode = FilterMode.Bilinear;
		if (material != null)
		{
			Blit(src, dst, material, pass);
		}
		else
		{
			Blit(src, dst);
		}
		src.filterMode = filterMode;
	}

	public static void Blit(Texture src, RenderTexture dst)
	{
		Blit(src, dst, null, -1);
	}

	public static void Blit(Texture src, RenderTexture dst, Material material)
	{
		Blit(src, dst, material, -1);
	}

	public static void Blit(Texture src, RenderTexture dst, Material material, int pass)
	{
		SetShaderTargetSize(dst);
		if (material != null)
		{
			if (pass < 0)
			{
				Graphics.Blit(src, dst, material);
			}
			else
			{
				Graphics.Blit(src, dst, material, pass);
			}
		}
		else
		{
			Graphics.Blit(src, dst);
		}
	}

	public static void SetShaderTargetSize(RenderTexture dst)
	{
		if (dst != null)
		{
			Shader.SetGlobalVector("_TargetSize", new Vector2(dst.width, dst.height));
		}
	}
}
