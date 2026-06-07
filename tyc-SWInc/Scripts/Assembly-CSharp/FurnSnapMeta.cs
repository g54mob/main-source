using System.Collections.Generic;
using System.Linq;
using Tyd;
using UnityEngine;

public class FurnSnapMeta : FurnModMeta
{
	[FurnModAttr("name", FurnModAttr.VariableType.String, ReflectTarget = true)]
	public string Name;

	[FurnModAttr("Name", FurnModAttr.VariableType.String, ReflectTarget = true, FetchList = "GetAllSnaps")]
	public string SnapName;

	[FurnModAttr("CheckValid", FurnModAttr.VariableType.Bool, Desc = "Whether we need to check for collisions at this snap point. In some cases (like for PCs) this won't be needed for snapping furniture and it improves performance a lot")]
	public bool CheckValid;

	[FurnModAttr(null, FurnModAttr.VariableType.ExternalMeta, IsList = true, CallMethod = "FixLinks", Desc = "Used to link chairs and computers together. In most cases AtTable's should have an OnTable linked.")]
	public List<FurnSnapMeta> Links = new List<FurnSnapMeta>();

	[FurnModAttr(null, FurnModAttr.VariableType.ExternalMeta, IsList = true, Desc = "All snap points in this list will block this snap point if in use")]
	public List<FurnSnapMeta> Blocking = new List<FurnSnapMeta>();

	[FurnModAttr("UseForOrientation", FurnModAttr.VariableType.Bool, Desc = "Whether furniture that is snapped to linked snap points should try to face this snap point by default")]
	public bool UseForOrientation;

	[FurnModAttr(null, FurnModAttr.VariableType.Integer, Desc = "Put snap points in the same group if you want them not to be used at the same time. -1 for no group")]
	public int Group = -1;

	[FurnModHeader("Transform")]
	[FurnModAttr(null, FurnModAttr.VariableType.TransformParent)]
	public GameObject Parent;

	[FurnModAttr(null, FurnModAttr.VariableType.TransformPosition)]
	public Vector3 Position;

	[FurnModAttr(null, FurnModAttr.VariableType.TransformRotation)]
	public Vector3 Rotation;

	public int ID;

	private GameObject _test;

	public override string MetaName
	{
		get
		{
			return "Snap point";
		}
	}

	[FurnModAction]
	public void TestSnap()
	{
		List<Furniture> snaps = new List<Furniture>();
		foreach (GameObject item in ObjectDatabase.Instance.GetAllFurniture())
		{
			Furniture component = item.GetComponent<Furniture>();
			if (component.IsSnapping && component.SnapsTo.Contains(SnapName))
			{
				snaps.Add(component);
			}
		}
		if (snaps.Count <= 0)
		{
			return;
		}
		WindowManager.Instance.MultiWindow.Show("Snap", snaps.Select((Furniture x) => x.name), delegate(int x)
		{
			if (_test != null)
			{
				Object.Destroy(_test);
			}
			Furniture furniture = Object.Instantiate(snaps[x]);
			furniture.isTemporary = true;
			furniture.transform.SetParent(Target.transform, true);
			furniture.transform.localPosition = Vector3.zero;
			furniture.transform.localRotation = Quaternion.identity;
			furniture.gameObject.SetActive(true);
			_test = furniture.gameObject;
		}, false);
	}

	[FurnModAction(Tip = "Adding a surface makes it possible to place some objects anywhere on the surface of this snap point, but make sure no surfaces overlap")]
	public void EditSurface()
	{
		FurnitureModdingTool instance = FurnitureModdingTool.Instance;
		instance.BoundaryEditor.Init(instance.ActiveObject.GetComponent<Furniture>(), this);
		instance.BoundsPanel.SetActive(true);
		instance.MainPanel.SetActive(false);
		FurnitureModdingTool.Instance.BoundaryDrawer.SnapPoint = null;
	}

	[FurnModAction(Tip = "Adding a surface makes it possible to place some objects anywhere on the surface of this snap point, but make sure no surfaces overlap")]
	public void GenerateSurface()
	{
		SnapPoint s = (SnapPoint)Target;
		s.Surface = (from x in FurnitureModdingTool.Instance.ActiveObject.GetComponent<Furniture>().CalculateBoundary()
			select s.transform.worldToLocalMatrix.MultiplyPoint(x.ToVector3(0f)).FlattenVector3()).ToArray();
	}

	[FurnModAction]
	public void Delete()
	{
		FurnitureModdingTool.Instance.CurrentMeta.Remove(this);
		FurnitureModdingTool.Instance.SetInspector(null);
		FurnitureModdingTool.Instance.SnapDeleted = true;
		int childCount = Target.transform.childCount;
		if (_test != null)
		{
			Object.Destroy(_test);
		}
		for (int num = childCount - 1; num >= 0; num--)
		{
			Target.transform.GetChild(num).SetParent(FurnitureModdingTool.Instance.ActiveObject.transform, true);
		}
		Utilities.RemoveElement(ref FurnitureModdingTool.Instance.ActiveObject.GetComponent<Furniture>().SnapPoints, Target as SnapPoint);
		GameObject obj = FurnitureModdingTool.Instance.MetaButtons[this];
		foreach (FurnSnapMeta item in FurnitureModdingTool.Instance.CurrentMeta.OfType<FurnSnapMeta>())
		{
			if (item != this)
			{
				if (item.Links.Contains(this))
				{
					item.Links.Remove(this);
				}
				if (item.Blocking.Contains(this))
				{
					item.Blocking.Remove(this);
				}
			}
		}
		Object.Destroy(obj);
		FurnitureModdingTool.Instance.MetaButtons.Remove(this);
		FurnitureModdingTool.Instance.UpdateMetaDrops();
		Object.Destroy(Target.gameObject);
	}

	public override void OnSelect()
	{
		FurnitureModdingTool.Instance.BoundaryDrawer.SnapPoint = Target as SnapPoint;
	}

	public override void OnDeselect()
	{
		FurnitureModdingTool.Instance.BoundaryDrawer.SnapPoint = null;
		if (_test != null)
		{
			Object.Destroy(_test);
		}
	}

	public void FixLinks()
	{
		foreach (FurnSnapMeta item in FurnitureModdingTool.Instance.CurrentMeta.OfType<FurnSnapMeta>())
		{
			if (item != this)
			{
				bool flag = item.Links.Contains(this);
				bool flag2 = Links.Contains(item);
				if (flag && !flag2)
				{
					item.Links.Remove(this);
				}
				else if (!flag && flag2)
				{
					item.Links.Add(this);
				}
			}
		}
	}

	public FurnSnapMeta(Component target)
		: base(target)
	{
	}

	public IEnumerable<string> GetAllSnaps()
	{
		foreach (GameObject item in ObjectDatabase.Instance.GetAllFurniture())
		{
			Furniture component = item.GetComponent<Furniture>();
			if (component.IsSnapping)
			{
				string[] snapsTo = component.SnapsTo;
				for (int i = 0; i < snapsTo.Length; i++)
				{
					yield return snapsTo[i];
				}
			}
		}
	}

	public override void WriteToTyD(TydTable root)
	{
		TydTable tydTable = (root.FindNode("SnapPoints", true, false) as TydList).AddChild(new TydTable(null, new TydString("ComponentName", Name), new TydString("Name", SnapName), Target.transform.localPosition.ToTyd("Position"), Target.transform.localRotation.eulerAngles.ToTyd("Rotation")));
		if (Parent != null && Parent.GetComponent<Furniture>() == null)
		{
			tydTable.AddChild(new TydString("TransformParent", Parent.name));
		}
		if (Links.Count > 0)
		{
			tydTable.AddChild(new TydList("Links", Links.SelectInPlace((FurnSnapMeta x) => x.ID.ToString())));
		}
		if (Blocking.Count > 0)
		{
			tydTable.AddChild(new TydList("Blocking", Blocking.SelectInPlace((FurnSnapMeta x) => x.ID.ToString())));
		}
		SnapPoint snapPoint;
		if ((object)(snapPoint = Target as SnapPoint) != null && snapPoint.Surface.Length > 2)
		{
			TydNode[] children = snapPoint.Surface.SelectInPlace((Vector2 x) => new TydList(null, x.x.ToString(), x.y.ToString()));
			tydTable.AddChild(new TydList("Surface", children));
		}
		SaveIfChanged(tydTable, "CheckValid", CheckValid, true);
		SaveIfChanged(tydTable, "UseForOrientation", UseForOrientation, true);
		SaveIfChanged(tydTable, "Group", Group, -1);
	}

	public override string GetMetaGroup()
	{
		return "Snap points";
	}
}
