using System.Collections.Generic;
using UnityEngine;

public class ReplacementColorDataBlock : SkinBaseDataBlock
{
	public List<Color> colors = new List<Color>();

	public Texture2D targetTexture;

	public DataBlockRef<SourceColorDataBlock> sourceColors;
}
