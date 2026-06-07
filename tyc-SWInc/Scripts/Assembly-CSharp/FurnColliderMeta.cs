using UnityEngine;

public class FurnColliderMeta : FurnModMeta
{
	[FurnModAttr("center", FurnModAttr.VariableType.Vector3, ReflectTarget = true)]
	public Vector3 Center;

	[FurnModAttr("size", FurnModAttr.VariableType.Vector3, ReflectTarget = true)]
	public Vector3 Size;

	public override string MetaName
	{
		get
		{
			return "Box collider";
		}
	}

	public FurnColliderMeta(Component target)
		: base(target)
	{
	}

	public override void OnSelect()
	{
		FurnitureModdingTool.Instance.BoundaryDrawer.Collider = Target as BoxCollider;
	}

	public override void OnDeselect()
	{
		FurnitureModdingTool.Instance.BoundaryDrawer.Collider = null;
	}

	public override bool UseGizmo()
	{
		return false;
	}

	public override string GetMetaGroup()
	{
		return null;
	}
}
