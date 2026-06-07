using System.Collections.Generic;
using UnityEngine;

public class FurnLODMeta : FurnModMeta
{
	[FurnModAttr("LOD0", FurnModAttr.VariableType.Mesh)]
	public Mesh LOD0;

	[FurnModAttr("LOD1", FurnModAttr.VariableType.Mesh)]
	public Mesh LOD1;

	[FurnModAttr("LOD2", FurnModAttr.VariableType.Mesh)]
	public Mesh LOD2;

	public override string MetaName
	{
		get
		{
			return "LOD";
		}
	}

	public FurnLODMeta(Component target)
		: base(target)
	{
	}

	public override void OnCreateNew()
	{
		LODFurn lODFurn = Target as LODFurn;
		lODFurn.Init();
		List<LODFurn> lODGroups = FurnitureModdingTool.Instance.ActiveObject.GetComponent<Furniture>().LODGroups;
		if (lODGroups != null)
		{
			lODGroups.Add(lODFurn);
		}
	}

	public override void OnDeactivate()
	{
		List<LODFurn> lODGroups = FurnitureModdingTool.Instance.ActiveObject.GetComponent<Furniture>().LODGroups;
		if (lODGroups != null)
		{
			lODGroups.Remove(Target as LODFurn);
		}
	}

	public override string GetMetaGroup()
	{
		return null;
	}
}
