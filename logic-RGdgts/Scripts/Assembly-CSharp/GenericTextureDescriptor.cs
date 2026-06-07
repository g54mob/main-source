using System.Collections.Generic;
using UnityEngine;

public abstract class GenericTextureDescriptor
{
	public TextureChannel channel;

	public Vector2Int cellSize;

	public string path { get; private set; }

	public bool isLoaded { get; private set; }

	public abstract ICollection<TextureDescriptorCell> cells { get; }

	public GenericTextureDescriptor(TextAsset textAsset)
	{
	}

	public GenericTextureDescriptor(string path)
	{
	}

	private void LoadData(string data)
	{
	}

	protected abstract void ParseCell(string value);
}
