using Tyd;
using UnityEngine;

public class FurnUpgMeta : FurnModMeta
{
	[FurnModAttr("TimeToAtrophy", FurnModAttr.VariableType.Float, Desc = "How many months until furniture breaks")]
	public float AtrophyTime;

	[FurnModAttr("CanBreak", FurnModAttr.VariableType.Bool, Desc = "Whether furniture will actually stop working at 0%")]
	public bool CanBreak;

	[FurnModAttr("AffectedByTemp", FurnModAttr.VariableType.Bool, Desc = "Whether furniture degrades faster when hot, e.g. electronics")]
	public bool AffectedByTemperature;

	[FurnModAttr("AffectedByAirQuality", FurnModAttr.VariableType.Bool, Desc = "Whether furniture degrades faster when the air is bad quality / dusty, e.g. electronics")]
	public bool AffectedByAirQuality;

	[FurnModAttr("DegradeAlways", FurnModAttr.VariableType.Bool, Desc = "Whether furniture is degrading whether being used or not")]
	public bool DegradeAlways;

	[FurnModAttr("FireStarter", FurnModAttr.VariableType.PercentSlider, UpperBound = 0.5f, Desc = "How high the chances are of furniture starting fire when it breaks")]
	public float FireChance;

	[FurnModAttr("SmokePosition", FurnModAttr.VariableType.ExternalComponent, ComponentType = typeof(Transform))]
	public FurnSmokeMeta SmokePosition;

	public override string MetaName
	{
		get
		{
			return "Upgradable";
		}
	}

	public FurnUpgMeta(Component target)
		: base(target)
	{
	}

	public override void OnCreateNew()
	{
		Transform transform = new GameObject("SmokePosition").transform;
		transform.SetParent(FurnitureModdingTool.Instance.ActiveObject.transform);
		transform.localPosition = Vector3.zero;
		SmokePosition = new FurnSmokeMeta(transform);
	}

	public override void OnDeactivate()
	{
		Object.Destroy(SmokePosition.Target.gameObject);
	}

	public override bool UseGizmo()
	{
		return false;
	}

	public override void WriteToTyD(TydTable root)
	{
		if (SmokePosition != null)
		{
			WriteTransform(root, "SmokePosition", SmokePosition.Target.transform, SmokePosition.Parent);
		}
		else
		{
			WriteTransform(root, "SmokePosition");
		}
		WallSnap baseObject = FurnitureModdingTool.Instance.ActivePrefab.BaseObject;
		Upgradable target = ((baseObject == null) ? null : baseObject.GetComponent<Upgradable>());
		TydTable tydTable;
		if ((tydTable = root.FindNode("Upgradable", true) as TydTable) != null)
		{
			SetIfChanged("AtrophyTime", target, tydTable, AtrophyTime.ToString());
			SetIfChanged("CanBreak", target, tydTable, CanBreak.ToString());
			SetIfChanged("DegradeAlways", target, tydTable, DegradeAlways.ToString());
			SetIfChanged("AffectedByTemperature", target, tydTable, AffectedByTemperature.ToString());
			SetIfChanged("FireChance", target, tydTable, FireChance.ToString());
			tydTable.SetNode("SmokePosition", "SmokePosition", true);
			tydTable.RemoveNode("TheScreen");
			tydTable.RemoveNode("OnMat");
			tydTable.RemoveNode("OffMat");
			tydTable.RemoveNode("ChangeColorOffSecondary");
			tydTable.RemoveNode("ChangeColorOffTertiary");
			tydTable.RemoveNode("DisableObjs");
		}
	}

	public override string GetMetaGroup()
	{
		return null;
	}
}
