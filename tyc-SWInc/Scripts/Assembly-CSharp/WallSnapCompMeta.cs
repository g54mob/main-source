using UnityEngine;

public abstract class WallSnapCompMeta : FurnModMeta
{
	[FurnModHeader("Atlas options")]
	[FurnModAttr(null, FurnModAttr.VariableType.ExternalMeta, CallMethod = "RefreshAtlas")]
	public FurnMeshMeta AtlasObject;

	[FurnModAttr("AtlasDimensions", FurnModAttr.VariableType.Vector2, WriteDirectParent = "Furniture", ReflectTarget = true, CallMethod = "RefreshAtlas")]
	public Vector2 AtlasDimensions;

	[FurnModAttr("AtlasCount", FurnModAttr.VariableType.Integer, WriteDirectParent = "Furniture", ReflectTarget = true, CallMethod = "RefreshAtlas", Desc = "How many atlas tiles to use from texture")]
	public int AtlasCount;

	[FurnModAttr("AtlasSkip", FurnModAttr.VariableType.Integer, WriteDirectParent = "Furniture", ReflectTarget = true, CallMethod = "RefreshAtlas", Desc = "How many atlas tiles to skip ahead each jump, 1 if none")]
	public int AtlasSkip;

	[FurnModAttr("AtlasOff", FurnModAttr.VariableType.Integer, WriteDirectParent = "Furniture", ReflectTarget = true, CallMethod = "RefreshAtlas", Desc = "How many initial atlas tiles to skip")]
	public int AtlasOff;

	[FurnModAttr("AtlasColorable", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", ReflectTarget = true, CallMethod = "RefreshAtlas", Desc = "Whether atlas material is RGB mapped")]
	public bool AtlasColorable;

	public WallSnapCompMeta(Component target)
		: base(target)
	{
	}
}
