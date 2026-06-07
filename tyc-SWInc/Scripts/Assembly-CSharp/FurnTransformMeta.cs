using Tyd;
using UnityEngine;

public class FurnTransformMeta : FurnModMeta
{
	[FurnModAttr("name", FurnModAttr.VariableType.String, ReflectTarget = true)]
	public string Name;

	[FurnModHeader("Transform")]
	[FurnModAttr(null, FurnModAttr.VariableType.TransformParent)]
	public GameObject Parent;

	[FurnModAttr(null, FurnModAttr.VariableType.TransformPosition, CallMethod = "FixPivot")]
	public Vector3 Position;

	[FurnModAttr(null, FurnModAttr.VariableType.TransformRotation, CallMethod = "FixPivot")]
	public Vector3 Rotation;

	[FurnModAttr(null, FurnModAttr.VariableType.TransformScale, CallMethod = "FixPivot")]
	public Vector3 Scale;

	public override string MetaName
	{
		get
		{
			return "Transform";
		}
	}

	public FurnTransformMeta(Component target)
		: base(target)
	{
	}

	[FurnModAction]
	public void Delete()
	{
		FurnitureModdingTool.Instance.CurrentMeta.Remove(this);
		FurnitureModdingTool.Instance.SetInspector(null);
		for (int num = Target.transform.childCount - 1; num >= 0; num--)
		{
			Target.transform.GetChild(num).SetParent(FurnitureModdingTool.Instance.ActiveObject.transform, true);
		}
		Object.Destroy(FurnitureModdingTool.Instance.MetaButtons[this]);
		FurnitureModdingTool.Instance.MetaButtons.Remove(this);
		FurnitureModdingTool.Instance.UpdateMetaDrops();
		Object.Destroy(Target.gameObject);
	}

	public void FixPivot()
	{
		FurnitureModdingTool.Instance.FixPivot();
	}

	public override void WriteToTyD(TydTable root)
	{
		WriteTransform(root, Target.name, Target.transform, Parent);
	}

	public override string GetMetaGroup()
	{
		return "Transforms";
	}
}
