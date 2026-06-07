using Tyd;
using UnityEngine;

public class FurnLightMeta : FurnModMeta
{
	[FurnModAttr("color", FurnModAttr.VariableType.Color, ReflectProp = "color")]
	public Color Color;

	[FurnModAttr("range", FurnModAttr.VariableType.Float, ReflectTarget = true)]
	public float Range;

	[FurnModAttr("intensity", FurnModAttr.VariableType.Float, ReflectTarget = true)]
	public float Intensity;

	[FurnModAttr(null, FurnModAttr.VariableType.Bool, Desc = "Whether player can change light color. See Furniture.LightPrimary for which color controls it")]
	public bool Colorable;

	[FurnModAttr(null, FurnModAttr.VariableType.TransformParent)]
	public GameObject Parent;

	[FurnModAttr(null, FurnModAttr.VariableType.TransformPosition)]
	public Vector3 Position;

	[FurnModAttr(null, FurnModAttr.VariableType.TransformRotation)]
	public Vector3 Rotation;

	public override string MetaName
	{
		get
		{
			return "Light";
		}
	}

	public FurnLightMeta(Component target)
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

	public override void WriteToTyD(TydTable root)
	{
		WriteTransform(root, Target.name, Target.transform, Parent);
		TydTable tydTable = new TydTable("Light", new TydString("TransformParent", Target.name), new TydString("range", Range.ToString()), new TydString("intensity", Intensity.ToString()));
		if (!Colorable)
		{
			tydTable.Nodes.Add(new TydString("color", ColorUtility.ToHtmlStringRGB(Color)));
		}
		root.AddChild(tydTable);
		if (Colorable)
		{
			(root.FindNode("Furniture/ColorableLights", true, false) as TydList).AddChild(new TydString(null, Target.name));
		}
	}

	public override string GetMetaGroup()
	{
		return "Lights";
	}
}
