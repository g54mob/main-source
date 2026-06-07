using UnityEngine;

public class FurnSmokeMeta : FurnModMeta
{
	[FurnModHeader("Transform")]
	[FurnModAttr(null, FurnModAttr.VariableType.TransformParent)]
	public GameObject Parent;

	[FurnModAttr(null, FurnModAttr.VariableType.TransformPosition)]
	public Vector3 Position;

	public override string MetaName
	{
		get
		{
			return "Smoke point";
		}
	}

	public override void OnSelect()
	{
		FurnitureModdingTool.Instance.SmokeSystem.transform.SetParent(Target.transform, true);
		FurnitureModdingTool.Instance.SmokeSystem.transform.localPosition = Vector3.zero;
		FurnitureModdingTool.Instance.SmokeSystem.Play();
	}

	public override void OnDeselect()
	{
		FurnitureModdingTool.Instance.SmokeSystem.transform.SetParent(null, true);
		FurnitureModdingTool.Instance.SmokeSystem.transform.position = Vector3.zero;
		FurnitureModdingTool.Instance.SmokeSystem.Stop();
	}

	public FurnSmokeMeta(Component target)
		: base(target)
	{
	}

	public override string GetMetaGroup()
	{
		return null;
	}
}
