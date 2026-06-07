using UnityEngine;

public struct ProductionGraphLineMetadata
{
	public int ResourceId;

	public ProductionGraphLineType Type;

	public string Name;

	public Color Color;

	public Sprite Icon;

	public ProductionGraphLineMetadata(int resourceId, ProductionGraphLineType type, string name, Color color, Sprite icon)
	{
		ResourceId = resourceId;
		Type = type;
		Name = name;
		Color = color;
		Icon = icon;
	}
}
