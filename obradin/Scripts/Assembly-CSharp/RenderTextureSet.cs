using System.Collections.Generic;
using UnityEngine;

public class RenderTextureSet
{
	public struct UsedInMaterial
	{
		public Material material;

		public string textureName;
	}

	public class Spec
	{
		public float scale = 1f;

		public FilterMode filterMode;

		public List<UsedInMaterial> usedInMaterials = new List<UsedInMaterial>();

		public int width
		{
			get
			{
				return Mathf.CeilToInt(scale * (float)Resolution.bufferW);
			}
		}

		public int height
		{
			get
			{
				return Mathf.CeilToInt(scale * (float)Resolution.bufferH);
			}
		}

		public Spec SetScale(float scale_)
		{
			scale = scale_;
			return this;
		}

		public Spec SetFilterMode(FilterMode filterMode_)
		{
			filterMode = filterMode_;
			return this;
		}

		public Spec SetInMaterial(Material material, string textureName)
		{
			usedInMaterials.Add(new UsedInMaterial
			{
				material = material,
				textureName = textureName
			});
			return this;
		}
	}

	private class Entry
	{
		public string name;

		public Spec spec;

		public RenderTexture renderTexture;

		public CameraClearFlags clearFlags;

		public bool needsRealloc
		{
			get
			{
				return renderTexture == null || spec.width != renderTexture.width || spec.height != renderTexture.height;
			}
		}

		public Entry(string name_, Spec spec_)
		{
			name = name_;
			spec = spec_;
			if (spec == null)
			{
				spec = new Spec();
			}
			Alloc();
		}

		public void Alloc()
		{
			if (renderTexture != null)
			{
				Free();
			}
			int depth = 24;
			renderTexture = new RenderTexture(spec.width, spec.height, depth, RenderTextureFormat.ARGB32);
			renderTexture.filterMode = spec.filterMode;
			renderTexture.Create();
			foreach (UsedInMaterial usedInMaterial in spec.usedInMaterials)
			{
				if (usedInMaterial.material != null)
				{
					usedInMaterial.material.SetTexture(usedInMaterial.textureName, renderTexture);
				}
			}
		}

		public void Free()
		{
			Util.DestroyRenderTexture(renderTexture);
			renderTexture = null;
			foreach (UsedInMaterial usedInMaterial in spec.usedInMaterials)
			{
				if (usedInMaterial.material != null)
				{
					usedInMaterial.material.SetTexture(usedInMaterial.textureName, null);
				}
			}
		}

		public void Realloc()
		{
			Alloc();
		}
	}

	private Dictionary<string, Entry> entries = new Dictionary<string, Entry>();

	public RenderTextureSet()
	{
		Enable();
	}

	public RenderTexture Add(string name, Spec spec = null)
	{
		if (entries.ContainsKey(name))
		{
			return entries[name].renderTexture;
		}
		Entry entry = new Entry(name, spec);
		entries.Add(name, entry);
		return entry.renderTexture;
	}

	public RenderTexture Get(string name)
	{
		Entry entry = entries[name];
		if (entry.needsRealloc)
		{
			entry.Realloc();
		}
		return entry.renderTexture;
	}

	public bool Has(string name)
	{
		return entries.ContainsKey(name);
	}

	public CameraClearFlags GetClearFlags(string name)
	{
		return entries[name].clearFlags;
	}

	public void SetClearFlags(string name, CameraClearFlags clearFlags)
	{
		entries[name].clearFlags = clearFlags;
	}

	public void Enable()
	{
		foreach (KeyValuePair<string, Entry> entry in entries)
		{
			entry.Value.Alloc();
		}
	}

	public void Disable()
	{
		foreach (KeyValuePair<string, Entry> entry in entries)
		{
			entry.Value.Free();
		}
	}

	public void Realloc()
	{
		foreach (KeyValuePair<string, Entry> entry in entries)
		{
			entry.Value.Alloc();
		}
	}

	private void OnResolutionBufferSizeChanged()
	{
		Realloc();
	}
}
