using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tyd;
using UnityEngine;
using UnityEngine.Rendering;
using UnityMeshSimplifier;

public class FurnMeshMeta : FurnModMeta
{
	[FurnModAttr("name", FurnModAttr.VariableType.String, ReflectTarget = true)]
	public string Name;

	[FurnModAttr("tag", FurnModAttr.VariableType.Combo, ReflectTarget = true, FetchList = "GetTags")]
	public string Tag;

	[FurnModAttr(null, FurnModAttr.VariableType.String, ReflectTarget = false, FetchList = "GetAllReplacementKeys", Desc = "Adds ability to replace this mesh with another mesh in-game. Key needs to be defined in replacements.tyd")]
	public string Replacement;

	[FurnModAttr(null, FurnModAttr.VariableType.Material)]
	public Material Material;

	[FurnModAttr(null, FurnModAttr.VariableType.Mesh, CallMethod = "FixPivot")]
	public Mesh Mesh;

	[FurnModAttr(null, typeof(LODFurn), ValidFor = FurnModAttr.ItemType.Furniture, Desc = "Allows you to change the mesh to a simpler version when zoomed out, which improves performance")]
	public FurnLODMeta LOD;

	[FurnModAttr(null, FurnModAttr.VariableType.Bool, Desc = "Whether to cast shadows. Not recommended for lamps.", CallMethod = "ChangeShadows", ValidFor = FurnModAttr.ItemType.Furniture)]
	public bool Shadows;

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
			return "Mesh";
		}
	}

	public FurnMeshMeta(Component target)
		: base(target)
	{
		ReplacementMesh component = target.GetComponent<ReplacementMesh>();
		if (component != null)
		{
			Replacement = component.ReplacementName;
		}
	}

	public void ChangeShadows()
	{
		Renderer component = Target.GetComponent<Renderer>();
		if (component != null)
		{
			component.shadowCastingMode = (Shadows ? ShadowCastingMode.On : ShadowCastingMode.Off);
		}
	}

	public override void OnActivate()
	{
		Shadows = Target.gameObject.layer != 13;
		ChangeShadows();
	}

	public void FixPivot()
	{
		FurnitureModdingTool.Instance.FixPivot();
	}

	public IEnumerable<string> GetAllReplacementKeys()
	{
		HashSet<string> hashSet = new HashSet<string>();
		string[] replacementGroups = FurnitureModdingTool.Instance.CurrentMeta.FirstOrDefaultOf<FurnCompMeta>().ReplacementGroups;
		foreach (string text in replacementGroups)
		{
			ObjectDatabase.ReplacementGroup group;
			if (text == null || !ObjectDatabase.Instance.GetReplacementGroup(text, out group))
			{
				continue;
			}
			foreach (ObjectDatabase.ReplacementObject replacement in group.Replacements)
			{
				hashSet.AddRange(replacement.Keys.Select((ObjectDatabase.ReplacementKey x) => x.Key));
			}
		}
		foreach (string item in hashSet)
		{
			yield return item;
		}
	}

	public string[][] GetTags()
	{
		return new string[2][]
		{
			new string[6] { "Untagged", "Highlight", "HighlightAlpha", "HidePlacement", "IgnoreMesh", "HideUnaffected" },
			new string[6] { "Does nothing", "Renders outline when selected by player", "Renders outline when selected by player and will use alpha channel of material for preview when placing", "Hides this mesh when placing", "Hides this mesh when placing, disables shadows and won't be used for calculating boundaries or material previews in build mode", "Hides this mesh when placing, isn't part of visibility calculation and won't be used for calculating boundaries or material previews in build mode" }
		};
	}

	public void ReplaceMesh(Mesh old, Mesh m)
	{
		if ((bool)(Mesh = old))
		{
			Mesh = m;
		}
		if (LOD != null)
		{
			if (LOD.LOD0 == old)
			{
				LOD.LOD0 = m;
			}
			if (LOD.LOD1 == old)
			{
				LOD.LOD1 = m;
			}
			if (LOD.LOD2 == old)
			{
				LOD.LOD2 = m;
			}
		}
		MeshFilter meshFilter = Target as MeshFilter;
		if (meshFilter != null && meshFilter.sharedMesh == old)
		{
			meshFilter.sharedMesh = m;
		}
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
		FurnitureModdingTool.Instance.ActiveObject.GetComponent<Furniture>().Colorable.Remove(Target.GetComponent<MeshRenderer>());
		FurnLODMeta lOD = LOD;
		if (lOD != null)
		{
			lOD.OnDeactivate();
		}
		UnityEngine.Object.Destroy(FurnitureModdingTool.Instance.MetaButtons[this]);
		FurnitureModdingTool.Instance.MetaButtons.Remove(this);
		FurnitureModdingTool.Instance.UpdateMetaDrops();
		UnityEngine.Object.Destroy(Target.gameObject);
	}

	[FurnModAction]
	public void ReloadMesh()
	{
		if (LOD != null)
		{
			HashSet<Mesh> hashSet = new HashSet<Mesh>();
			if (LOD.LOD0 != null)
			{
				hashSet.Add(LOD.LOD0);
			}
			if (LOD.LOD1 != null)
			{
				hashSet.Add(LOD.LOD1);
			}
			if (LOD.LOD2 != null)
			{
				hashSet.Add(LOD.LOD2);
			}
			if (hashSet.Count > 0)
			{
				foreach (Mesh item in hashSet)
				{
					ReloadMeshFile(item);
				}
				FixPivot();
				return;
			}
		}
		if (Mesh != null)
		{
			ReloadMeshFile(Mesh);
		}
		FixPivot();
	}

	[FurnModAction(ValidFor = FurnModAttr.ItemType.RoomSegment)]
	public void Hinge()
	{
		if (Mesh == null)
		{
			WindowManager.Instance.ShowMessageBox("Pick a mesh file first", true, DialogWindow.DialogType.Error);
			return;
		}
		if (CheckHinged(Target.transform))
		{
			WindowManager.Instance.ShowMessageBox("This mesh is already hinged", true, DialogWindow.DialogType.Error);
			return;
		}
		WindowManager.Instance.ShowMessageBox("Where would like to hinge this object?", true, DialogWindow.DialogType.Question, new KeyValuePair<string, Action>("Left", delegate
		{
			MakeHinged(false);
		}), new KeyValuePair<string, Action>("Right (Default)", delegate
		{
			MakeHinged(true);
		}));
	}

	private void MakeHinged(bool left)
	{
		MeshFilter meshFilter;
		if ((object)(meshFilter = Target as MeshFilter) != null)
		{
			Bounds bounds = meshFilter.sharedMesh.bounds;
			Vector3 point = (left ? new Vector3(bounds.min.x, bounds.min.y, bounds.center.z) : new Vector3(bounds.max.x, bounds.min.y, bounds.center.z));
			point = Target.transform.localToWorldMatrix.MultiplyPoint(point);
			FurnModMeta meta;
			DoorScript doorScript = FurnitureModdingTool.Instance.AddNewMeta<DoorScript>("Hinge", typeof(FurnDoorScriptMeta), out meta);
			doorScript.transform.position = point;
			doorScript.transform.rotation = (left ? Quaternion.Euler(0f, 90f, 0f) : Quaternion.Euler(0f, 270f, 0f));
			doorScript.Init();
			Parent = doorScript.gameObject;
			Target.transform.SetParent(doorScript.transform, true);
			FurnitureModdingTool.Instance.SetInspector(meta);
		}
	}

	private bool CheckHinged(Transform t)
	{
		if (t == null)
		{
			return false;
		}
		if (t.GetComponent<DoorScript>() != null)
		{
			return true;
		}
		return CheckHinged(t.parent);
	}

	[FurnModAction(ValidFor = FurnModAttr.ItemType.Furniture)]
	public void GenerateLODs()
	{
		LODFurn lODFurn;
		if (LOD == null)
		{
			lODFurn = Target.gameObject.AddComponent<LODFurn>();
			LOD = new FurnLODMeta(lODFurn);
			LOD.OnCreateNew();
			LOD.LOD0 = lODFurn.LOD0;
			LOD.LOD1 = lODFurn.LOD1;
			LOD.LOD2 = lODFurn.LOD2;
		}
		else
		{
			lODFurn = LOD.Target as LODFurn;
		}
		Mesh lOD = lODFurn.LOD0;
		if (lOD != null)
		{
			FurnitureMod activeMod = FurnitureModdingTool.Instance.ActiveMod;
			MeshSimplifier meshSimplifier = new MeshSimplifier();
			meshSimplifier.Initialize(lOD);
			meshSimplifier.SimplifyMeshLossless();
			Mesh mesh = lOD;
			if (meshSimplifier.Vertices.Length < lOD.vertexCount)
			{
				mesh = meshSimplifier.ToMesh();
				mesh.name = Path.Combine(Path.GetDirectoryName(lOD.name), Path.GetFileNameWithoutExtension(lOD.name) + "_LOD1.obj");
				ObjExporterScript.Start();
				string contents = ObjExporterScript.MeshToString(mesh, null, Matrix4x4.identity, Quaternion.identity);
				ObjExporterScript.End();
				File.WriteAllText(Path.Combine(activeMod.Root, mesh.name), contents);
				lODFurn.LOD1 = (LOD.LOD1 = mesh);
			}
			meshSimplifier.Initialize(mesh);
			meshSimplifier.SimplifyMesh(0.25f);
			if (meshSimplifier.Vertices.Length < mesh.vertexCount)
			{
				Mesh mesh2 = meshSimplifier.ToMesh();
				mesh2.name = Path.Combine(Path.GetDirectoryName(lOD.name), Path.GetFileNameWithoutExtension(lOD.name) + "_LOD2.obj");
				ObjExporterScript.Start();
				string contents2 = ObjExporterScript.MeshToString(mesh2, null, Matrix4x4.identity, Quaternion.identity);
				ObjExporterScript.End();
				File.WriteAllText(Path.Combine(activeMod.Root, mesh2.name), contents2);
				lODFurn.LOD2 = (LOD.LOD2 = mesh2);
			}
			if (lODFurn.LOD0 == lODFurn.LOD1 && lODFurn.LOD1 == lODFurn.LOD2)
			{
				LOD.OnDeactivate();
				UnityEngine.Object.Destroy(lODFurn);
				LOD = null;
				WindowManager.Instance.ShowMessageBox("Could not produce any LODs, mesh too simple", true, DialogWindow.DialogType.Information);
			}
		}
	}

	private void ReloadMeshFile(Mesh me)
	{
		string name = me.name;
		FurnitureMod activeMod = FurnitureModdingTool.Instance.ActiveMod;
		string text = Path.Combine(activeMod.Root, name);
		if (!File.Exists(text))
		{
			return;
		}
		Mesh mesh;
		try
		{
			mesh = FurnitureModdingTool.Instance.LoadMesh(text, name, true);
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
			return;
		}
		if (!(mesh != null))
		{
			return;
		}
		mesh.name = name;
		foreach (FurnMeshMeta item in FurnitureModdingTool.Instance.CurrentMeta.OfType<FurnMeshMeta>())
		{
			item.ReplaceMesh(me, mesh);
		}
		activeMod.Meshes.Add(mesh);
		activeMod.Meshes.Remove(me);
		FurnitureModdingTool.Instance.Meshes.Remove(me);
		UnityEngine.Object.Destroy(me);
	}

	public override void WriteToTyD(TydTable root)
	{
		TydTable tydTable = (root.FindNode("Models", true, false) as TydList).AddChild(new TydTable(null));
		tydTable.AddChild(new TydString("ComponentName", Name));
		tydTable.AddChild(new TydString("File", Mesh.name));
		tydTable.AddChild(new TydString("Tag", Tag));
		if (LOD != null)
		{
			if (LOD.LOD1 != null)
			{
				tydTable.AddChild(new TydString("LOD1", LOD.LOD1.name));
			}
			if (LOD.LOD2 != null && LOD.LOD2 != Mesh)
			{
				tydTable.AddChild(new TydString("LOD2", LOD.LOD2.name));
			}
		}
		tydTable.AddChild(Target.transform.localPosition.ToTyd("Position"));
		tydTable.AddChild(Target.transform.localRotation.eulerAngles.ToTyd("Rotation"));
		tydTable.AddChild(Target.transform.localScale.ToTyd("Scale"));
		if (Material != null && Material != ObjectDatabase.Instance.CombineFurnitureMaterial)
		{
			tydTable.AddChild(new TydString("Material", Material.name));
		}
		if (Parent != null && Parent != FurnitureModdingTool.Instance.ActiveObject)
		{
			tydTable.AddChild(new TydString("TransformParent", Parent.name));
		}
		tydTable.AddChild(new TydString("Shadows", Shadows.ToString()));
		if (!string.IsNullOrWhiteSpace(Replacement))
		{
			tydTable.AddChild(new TydString("Replacement", Replacement));
		}
	}

	public override string GetMetaGroup()
	{
		return "Meshes";
	}
}
