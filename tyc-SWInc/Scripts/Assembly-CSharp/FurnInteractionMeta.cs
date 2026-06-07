using System.Collections.Generic;
using System.Linq;
using Tyd;
using UnityEngine;

public class FurnInteractionMeta : FurnModMeta
{
	[FurnModAttr("name", FurnModAttr.VariableType.String, ReflectTarget = true)]
	public string Name;

	[FurnModAttr("Action", FurnModAttr.VariableType.Enum, ReflectTarget = true)]
	public InteractionPoint.ActionType Action;

	[FurnModAttr("MinimumNeeded", FurnModAttr.VariableType.Integer, Desc = "The least amount of points of this type that need to be reachable before the player is warned")]
	public int MinimumNeeded;

	[FurnModAttr("NeedsReachCheck", FurnModAttr.VariableType.Bool, Desc = "Whether the player should be warned at all, if the interaction point is unreachable")]
	public bool NeedsReachCheck;

	[FurnModAttr("MainAction", FurnModAttr.VariableType.Bool, Desc = "Whether the feet graphic should appear dark or not, to tell the player whether it's important")]
	public bool MainAction;

	[FurnModAttr("ShowOnBuild", FurnModAttr.VariableType.Bool, Desc = "Whether the feet graphic should appear at all")]
	public bool ShowOnBuild;

	[FurnModAttr("Outside", FurnModAttr.VariableType.Bool, Hidden = true)]
	public bool Outside;

	[FurnModAttr("AlwaysValid", FurnModAttr.VariableType.Bool, Hidden = true)]
	public bool AlwaysValid;

	[FurnModAttr(null, FurnModAttr.VariableType.ExternalMeta, IsList = true, CallMethod = "ReflectBlock", Desc = "Stops this point from being used if any of the listed points are in use, but not vice versa")]
	public List<FurnInteractionMeta> BlockedBy;

	[FurnModAttr("TurnTo", FurnModAttr.VariableType.Bool, Desc = "Whether employee should turn to face this interaction point before interacting, usually not required for ceiling mounted furniture that is interacted with from below")]
	public bool TurnTo;

	[FurnModAttr("Range", FurnModAttr.VariableType.Float, Desc = "Set to value above 0 to define a range within which the point can be interacted with, even if blocked")]
	public float Range = -1f;

	[FurnModAttr("Animation", FurnModAttr.VariableType.Enum, ReflectTarget = true, Desc = "The actual animation used depends a lot on the AI code, so the animation set here may not ever be used by the game", CallMethod = "UpdateAnimation")]
	public Actor.AnimationStates Animation;

	[FurnModAttr("subAnimation", FurnModAttr.VariableType.Integer, ReflectTarget = true, Desc = "Only used for whether repair hammer animation hits low, mid or high", CallMethod = "UpdateAnimation")]
	public int SubAnimation;

	[FurnModAttr(null, FurnModAttr.VariableType.Integer, Desc = "Put interaction points in the same group if you want them not to be used at the same time. -1 for no group")]
	public int Group = -1;

	[FurnModHeader("Transform")]
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
			return "Interaction point";
		}
	}

	public void ReflectBlock()
	{
		InteractionPoint ip;
		if ((object)(ip = Target as InteractionPoint) != null)
		{
			List<FurnInteractionMeta> metas = FurnitureModdingTool.Instance.CurrentMeta.OfType<FurnInteractionMeta>().ToList();
			ip.BlockedBy = (from x in BlockedBy
				where x != null
				select ip.Parent.InteractionPoints[metas.IndexOf(x)]).ToList();
		}
	}

	[FurnModAction]
	public void Delete()
	{
		FurnitureModdingTool.Instance.CurrentMeta.Remove(this);
		FurnitureModdingTool.Instance.SetInspector(null);
		FurnitureModdingTool.Instance.InterDeleted = true;
		for (int num = Target.transform.childCount - 1; num >= 0; num--)
		{
			Target.transform.GetChild(num).SetParent(FurnitureModdingTool.Instance.ActiveObject.transform, true);
		}
		Utilities.RemoveElement(ref FurnitureModdingTool.Instance.ActiveObject.GetComponent<Furniture>().InteractionPoints, Target as InteractionPoint);
		Object.Destroy(FurnitureModdingTool.Instance.MetaButtons[this]);
		FurnitureModdingTool.Instance.MetaButtons.Remove(this);
		FurnitureModdingTool.Instance.UpdateMetaDrops();
		Object.Destroy(Target.gameObject);
	}

	public FurnInteractionMeta(Component target)
		: base(target)
	{
	}

	public void UpdateAnimation()
	{
		InteractionPoint interactionPoint = Target as InteractionPoint;
		FurnitureModdingTool.Instance.DummyAnimator.SetActorAnim(interactionPoint.Animation, interactionPoint.subAnimation);
	}

	public override void OnSelect()
	{
		FurnitureModdingTool.Instance.BoundaryDrawer.Interaction = true;
		FurnitureModdingTool.Instance.DummyActor.gameObject.SetActive(true);
		FurnitureModdingTool.Instance.DummyActor.transform.SetParent(Target.transform, true);
		FurnitureModdingTool.Instance.DummyActor.transform.localPosition = Vector3.zero;
		FurnitureModdingTool.Instance.DummyActor.transform.position = FurnitureModdingTool.Instance.DummyActor.transform.position.ReplaceY(0f);
		FurnitureModdingTool.Instance.DummyActor.transform.localRotation = Quaternion.identity;
		InteractionPoint interactionPoint = Target as InteractionPoint;
		FurnitureModdingTool.Instance.DummyAnimator.SetActorAnim(interactionPoint.Animation, interactionPoint.subAnimation);
	}

	public override void OnDeselect()
	{
		FurnitureModdingTool.Instance.BoundaryDrawer.Interaction = false;
		FurnitureModdingTool.Instance.DummyActor.gameObject.SetActive(false);
		FurnitureModdingTool.Instance.DummyActor.transform.SetParent(null, true);
	}

	public override void WriteToTyD(TydTable root)
	{
		TydTable tydTable = (root.FindNode("InteractionPoints", true, false) as TydList).AddChild(new TydTable(null, new TydString("ComponentName", Name), new TydString("Name", Action.ToString()), Target.transform.localPosition.ToTyd("Position"), Target.transform.localRotation.eulerAngles.ToTyd("Rotation"), new TydString("Animation", Animation.ToString())));
		if (Parent != null && Parent.GetComponent<Furniture>() == null)
		{
			tydTable.AddChild(new TydString("TransformParent", Parent.name));
		}
		SaveIfChanged(tydTable, "SubAnimation", SubAnimation, 0);
		SaveIfChanged(tydTable, "MinimumNeeded", MinimumNeeded, 1);
		SaveIfChanged(tydTable, "NeedsReachCheck", NeedsReachCheck, true);
		SaveIfChanged(tydTable, "MainAction", MainAction, true);
		SaveIfChanged(tydTable, "ShowOnBuild", ShowOnBuild, true);
		SaveIfChanged(tydTable, "Outside", Outside, false);
		SaveIfChanged(tydTable, "AlwaysValid", AlwaysValid, false);
		SaveIfChanged(tydTable, "Group", Group, -1);
		if (BlockedBy.Count > 0)
		{
			List<FurnInteractionMeta> metas = FurnitureModdingTool.Instance.CurrentMeta.OfType<FurnInteractionMeta>().ToList();
			tydTable.AddChild(new TydList("BlockedBy", BlockedBy.SelectInPlace((FurnInteractionMeta x) => metas.FindIndex(x).ToString())));
		}
	}

	public override string GetMetaGroup()
	{
		return "Interaction points";
	}
}
