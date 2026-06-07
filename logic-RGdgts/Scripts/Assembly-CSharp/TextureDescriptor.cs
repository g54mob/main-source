using System.Collections.Generic;
using UnityEngine;

public class TextureDescriptor<T> : GenericTextureDescriptor where T : TextureDescriptorCell, new()
{
	public List<T> _cells;

	public override ICollection<TextureDescriptorCell> cells => null;

	public TextureDescriptor(TextAsset textAsset)
		: base((TextAsset)null)
	{
	}

	public TextureDescriptor(string path)
		: base((TextAsset)null)
	{
	}

	protected override void ParseCell(string value)
	{
	}
}
