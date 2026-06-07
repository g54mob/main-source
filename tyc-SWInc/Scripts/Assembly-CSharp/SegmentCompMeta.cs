using System;
using System.Collections.Generic;
using System.IO;
using Tyd;
using UnityEngine;

public class SegmentCompMeta : WallSnapCompMeta
{
	[FurnModAttr("name", FurnModAttr.VariableType.String, ReflectTarget = true, Desc = "This name will be used to uniquely identify your furniture, so you should try to make it as unique as possible")]
	public string Name;

	[FurnModAttr("LocalizedName", FurnModAttr.VariableType.String, ReflectTarget = true, Desc = "This is the name that will be used in the UI and which can be translated to other languages")]
	public string LocalizedName;

	[FurnModAttr("Type", FurnModAttr.VariableType.String, WriteDirectParent = "RoomSegment", FetchList = "GetAllTypes", Desc = "The category of this furniture")]
	public string Category;

	[FurnModAttr("ButtonDescription", FurnModAttr.VariableType.BigString, ReflectTarget = true)]
	public string Description;

	[FurnModAttr("Cost", FurnModAttr.VariableType.Float, WriteDirectParent = "RoomSegment")]
	public float Price;

	[FurnModAttr("IsIconic", FurnModAttr.VariableType.String, WriteDirectParent = "RoomSegment", IsArray = true, FetchList = "GetAllTypes", Desc = "Which categories to use furniture thumbnail for, if any")]
	public string[] UseThumbnail;

	public string Thumbnail;

	[FurnModHeader("Boundaries")]
	[FurnModAttr("Height1", FurnModAttr.VariableType.Float, WriteDirectParent = "RoomSegment", ReflectTarget = true, CallMethod = "SetStage", Desc = "This is the lowest point of your furniture, this should be -0.1 for carpets")]
	public float Bottom;

	[FurnModAttr("Height2", FurnModAttr.VariableType.Float, WriteDirectParent = "RoomSegment", ReflectTarget = true, CallMethod = "SetStage", Desc = "This is the highest point of your furniture, this should be -0.05 for carpets")]
	public float Top;

	[FurnModAttr(null, typeof(BoxCollider), CanDisableComp = false, Desc = "This box is used as a collider for mouse selection")]
	public FurnColliderMeta Collider;

	[FurnModHeader("In-game options")]
	[FurnModAttr("IsConnector", FurnModAttr.VariableType.Bool, WriteDirectParent = "RoomSegment", Desc = "Whether the employees can use this segment as a door and move through it")]
	public bool IsConnector;

	[FurnModAttr("Permeability", FurnModAttr.VariableType.Float, WriteDirectParent = "RoomSegment", Desc = "How much gas is let through, usually reserved for doors, from 0 to 1, where 1 = 100%")]
	public float Permeability;

	[FurnModAttr("IsPrivate", FurnModAttr.VariableType.Bool, WriteDirectParent = "RoomSegment", Desc = "Whether this segment maintains privacy of the room it is on, for toilets")]
	public bool IsPrivate;

	[FurnModAttr("LightAddition", FurnModAttr.VariableType.Float, WriteDirectParent = "RoomSegment", Desc = "How much light this segment lets in, from 0 to 1, where 1 = 100%")]
	public float Lighting;

	[FurnModAttr("NoiseFactor", FurnModAttr.VariableType.Float, WriteDirectParent = "RoomSegment", Desc = "How much noise this segment lets in, from 0 to 1, where 1 = 100%")]
	public float NoiseFactor;

	[FurnModAttr("HideWithWalls", FurnModAttr.VariableType.Bool, WriteDirectParent = "RoomSegment", Desc = "Whether this segment should be hidden when walls are down, mostly small windows")]
	public bool HideWithWalls;

	[FurnModAttr("Taggable", FurnModAttr.VariableType.Bool, WriteDirectParent = "RoomSegment", ReflectTarget = true, CallMethod = "UpdateTags", Desc = "Whether you can put a tag on this segment")]
	public bool Taggable;

	[FurnModAttr("TagParent", FurnModAttr.VariableType.ExternalComponent, WriteDirectParent = "RoomSegment", ReflectTarget = true, CallMethod = "UpdateTags", ComponentType = typeof(Transform), Dependency = "Taggable", Desc = "Which object the tag is relative to, normally a door hinge")]
	public GameObject TagParent;

	[FurnModAttr("TagPosition", FurnModAttr.VariableType.Vector2, WriteDirectParent = "RoomSegment", ReflectTarget = true, CallMethod = "UpdateTags", Dependency = "Taggable", Desc = "The tag offset on the object, e.g. XZ plane")]
	public Vector2 TagPosition;

	[FurnModAttr("TagOffset", FurnModAttr.VariableType.Float, WriteDirectParent = "RoomSegment", ReflectTarget = true, CallMethod = "UpdateTags", Dependency = "Taggable", Desc = "How far the tag should be offset depth-wise to not clip with meshes")]
	public float TagOffset;

	[FurnModAttr("TagRot", FurnModAttr.VariableType.Float, WriteDirectParent = "RoomSegment", ReflectTarget = true, CallMethod = "UpdateTags", Dependency = "Taggable", Desc = "How muhc the tag should be rotated")]
	public float TagRot;

	[FurnModHeader("Build options")]
	[FurnModAttr("CustomizationRotation", FurnModAttr.VariableType.Float, WriteDirectParent = "RoomSegment", Desc = "Rotation offset of furniture preview in style panel")]
	public float CustomizationRotation;

	[FurnModAttr("WallMeshes", FurnModAttr.VariableType.Mesh, IsList = true, CallMethod = "RefreshCutout", MetaLocal = true)]
	public List<Mesh> WallMeshes = new List<Mesh>();

	[FurnModAttr("Directional", FurnModAttr.VariableType.Bool, WriteDirectParent = "RoomSegment", Desc = "Whether the direction of the segment is important, e.g. asymmetrical")]
	public bool Directional;

	[FurnModAttr("DynamicWidth", FurnModAttr.VariableType.Bool, WriteDirectParent = "RoomSegment", Desc = "Whether this segment is stretchable")]
	public bool DynamicWidth;

	[FurnModAttr("MaxDynamicWidth", FurnModAttr.VariableType.Float, WriteDirectParent = "RoomSegment", Dependency = "DynamicWidth", Desc = "HOw long this segment can be stretched (Doorways should not go above 3 due to how pathfinding works)")]
	public float MaxDynamicWidth;

	[FurnModAttr("ScalableObjects", FurnModAttr.VariableType.ExternalComponent, IsList = true, WriteDirectParent = "RoomSegment", Dependency = "DynamicWidth", ComponentType = typeof(Transform), Desc = "Objects that will be scaled if segment is dynamic width")]
	public List<GameObject> ScalableObjects;

	[FurnModAttr("ScalableObjectsEdgeToEdge", FurnModAttr.VariableType.ExternalComponent, IsList = true, WriteDirectParent = "RoomSegment", Dependency = "DynamicWidth", ComponentType = typeof(Transform), Desc = "Objects that will be scaled if segment is dynamic width, up to edge if merging with neighbors")]
	public List<GameObject> ScalableObjectsEdgeToEdge;

	[FurnModAttr("MovableObjects", FurnModAttr.VariableType.ExternalComponent, IsList = true, WriteDirectParent = "RoomSegment", Dependency = "DynamicWidth", ComponentType = typeof(Transform), Desc = "Objects that will be moved if segment is dynamic width")]
	public List<GameObject> MovableObjects;

	[FurnModAttr("MergeNeighbors", FurnModAttr.VariableType.Bool, WriteDirectParent = "RoomSegment", Dependency = "DynamicWidth", Desc = "Whether this segment will merge across room corners, like the large window")]
	public bool MergeNeighbors;

	[FurnModHeader("Wall options")]
	[FurnModAttr("WallWidth", FurnModAttr.VariableType.Float, WriteDirectParent = "RoomSegment", ReflectTarget = true, CallMethod = "SetStage", Desc = "How wide the furniture is on a wall")]
	public float WallWidth;

	[FurnModAttr("GridSizeOverride", FurnModAttr.VariableType.Float, WriteDirectParent = "RoomSegment", Desc = "Whether to override the grid size when placing, e.g. 2 for half size grid")]
	public float GridSizeOverride;

	[FurnModAttr("ReverseWallSide", FurnModAttr.VariableType.Bool, WriteDirectParent = "RoomSegment", Desc = "Whether this furniture sits on the exterior of the wall it's placed on, like the company sign")]
	public bool ReverseWallSide;

	[FurnModAttr("OnlyInterior", FurnModAttr.VariableType.Bool, WriteDirectParent = "RoomSegment", Desc = "Whether segment has to be placed on a wall that faces another room")]
	public bool OnlyInterior;

	[FurnModAttr("InsideSegment", FurnModAttr.VariableType.Bool, WriteDirectParent = "RoomSegment", Desc = "Otherwise only on fences")]
	public bool OnlyOnWalls;

	[FurnModHeader("Colors")]
	[FurnModAttr("ColorPrimaryEnabled", FurnModAttr.VariableType.Bool, WriteDirectParent = "RoomSegment", ReflectTarget = true)]
	public bool Primary;

	[FurnModAttr("ColorPrimaryDefault", FurnModAttr.VariableType.Color, WriteDirectParent = "RoomSegment", ReflectProp = "ColorPrimary", Dependency = "Primary")]
	public Color PrimaryColor;

	[FurnModAttr("PrimaryColorName", FurnModAttr.VariableType.String, WriteDirectParent = "RoomSegment", Dependency = "Primary", ReflectTarget = true)]
	public string PrimaryColorName;

	[FurnModAttr("ColorSecondaryEnabled", FurnModAttr.VariableType.Bool, WriteDirectParent = "RoomSegment", ReflectTarget = true)]
	public bool Secondary;

	[FurnModAttr("ColorSecondaryDefault", FurnModAttr.VariableType.Color, WriteDirectParent = "RoomSegment", ReflectProp = "ColorSecondary", Dependency = "Secondary")]
	public Color SecondaryColor;

	[FurnModAttr("SecondaryColorName", FurnModAttr.VariableType.String, WriteDirectParent = "RoomSegment", Dependency = "Secondary", ReflectTarget = true)]
	public string SecondaryColorName;

	[FurnModAttr("ForceColorSecondary", FurnModAttr.VariableType.Bool, WriteDirectParent = "RoomSegment", ReflectTarget = true, Desc = "Whether furniture should be forced to use default secondary color")]
	public bool ForceColorSecondary;

	[FurnModAttr("ColorTertiaryEnabled", FurnModAttr.VariableType.Bool, WriteDirectParent = "RoomSegment", ReflectTarget = true)]
	public bool Tertiary;

	[FurnModAttr("ColorTertiaryDefault", FurnModAttr.VariableType.Color, WriteDirectParent = "RoomSegment", ReflectProp = "ColorTertiary", Dependency = "Tertiary")]
	public Color TertiaryColor;

	[FurnModAttr("TertiaryColorName", FurnModAttr.VariableType.String, WriteDirectParent = "RoomSegment", Dependency = "Tertiary", ReflectTarget = true)]
	public string TertiaryColorName;

	[FurnModAttr("ForceColorTertiary", FurnModAttr.VariableType.Bool, WriteDirectParent = "RoomSegment", ReflectTarget = true, Desc = "Whether furniture should be forced to use default tertiary color")]
	public bool ForceColorTertiary;

	[FurnModAttr("AltStyles", FurnModAttr.VariableType.FurnitureStyle, CanInstantiate = true, IsList = true, Desc = "Default alternative furniture colors")]
	public List<FurnitureStyle> AltStyles;

	[FurnModAttr("_defaultColorGroup", FurnModAttr.VariableType.String, WriteDirectParent = "RoomSegment", FetchList = "GetAllColorGroups", Desc = "Name of group that furniture is compatible with for color mapping, like normal and round tables. Leave completely blank for none.")]
	public string ColorGroup;

	[FurnModHeader("Replacement options")]
	[FurnModAttr("ReplacementGroups", FurnModAttr.VariableType.String, WriteDirectParent = "RoomSegment", IsArray = true, FetchList = "GetAllReplacementGroups", Desc = "Which replacement groups to use for this furniture as defined in replacements.tyd")]
	public string[] ReplacementGroups;

	[FurnModAttr("Replacements", FurnModAttr.VariableType.String, WriteDirectParent = "RoomSegment", IsArray = true, FetchList = "GetAllReplacementKeys", Desc = "Which replacement to use by default for this furniture in the same order as replacement groups")]
	public string[] DefaultReplacements;

	public override string MetaName
	{
		get
		{
			return "Segment";
		}
	}

	public SegmentCompMeta(Component target)
		: base(target)
	{
	}

	public void SetStage()
	{
		FurnitureModdingTool.Instance.SetStage();
	}

	public override void OnActivate()
	{
	}

	public void RefreshAtlas()
	{
		Furniture component = FurnitureModdingTool.Instance.ActiveObject.GetComponent<Furniture>();
		FurnMeshMeta atlasObject = AtlasObject;
		object atlasObject2;
		if (atlasObject == null)
		{
			atlasObject2 = null;
		}
		else
		{
			Component target = atlasObject.Target;
			atlasObject2 = (((object)target != null) ? target.GetComponent<MeshRenderer>() : null);
		}
		component.AtlasObject = (MeshRenderer)atlasObject2;
		component.AtlasIndex = 0;
	}

	public void RefreshCutout()
	{
		if (WallMeshes.Count > 0)
		{
			RoomSegment roomSegment = (RoomSegment)Target;
			for (int i = 0; i < roomSegment.InsideWallMeshes.Length; i++)
			{
				UnityEngine.Object.Destroy(roomSegment.InsideWallMeshes[i].gameObject);
			}
			List<MeshFilter> list = new List<MeshFilter>();
			for (int j = 0; j < WallMeshes.Count; j++)
			{
				GameObject gameObject = new GameObject(WallMeshes[j].name);
				MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
				meshFilter.sharedMesh = WallMeshes[j];
				gameObject.transform.SetParent(roomSegment.transform);
				list.Add(meshFilter);
			}
			roomSegment.InsideWallMeshes = list.ToArray();
			FurnitureModdingTool.Instance.RefreshCutouts();
		}
	}

	[FurnModAction]
	public void CutOutOfWall()
	{
		WallMeshes.Clear();
		RoomSegment roomSegment = (RoomSegment)Target;
		SegmentCompMeta segmentCompMetum = (SegmentCompMeta)FurnitureModdingTool.Instance.ActiveMeta;
		string text = null;
		HashSet<MeshFilter> hashSet = roomSegment.GetComponentsInChildren<MeshFilter>().ToHashSet();
		if (roomSegment.WallMask != null)
		{
			hashSet.Remove(roomSegment.WallMask.GetComponent<MeshFilter>());
		}
		if (roomSegment.InsideWallMeshes != null && roomSegment.InsideWallMeshes.Length != 0)
		{
			for (int i = 0; i < roomSegment.InsideWallMeshes.Length; i++)
			{
				if (i == 0)
				{
					text = roomSegment.InsideWallMeshes[0].sharedMesh.name;
				}
				MeshFilter meshFilter = roomSegment.InsideWallMeshes[i];
				hashSet.Remove(meshFilter);
				FurnitureModdingTool.Instance.ActiveMod.Meshes.Remove(meshFilter.sharedMesh);
				FurnitureModdingTool.Instance.Meshes.Remove(meshFilter.sharedMesh);
				UnityEngine.Object.Destroy(meshFilter.sharedMesh);
				UnityEngine.Object.Destroy(meshFilter.gameObject);
			}
		}
		else
		{
			text = roomSegment.name + "_cutout.obj";
		}
		List<Vector2[]> list = new List<Vector2[]>();
		foreach (MeshFilter m in hashSet)
		{
			int[] triangles = m.sharedMesh.triangles;
			List<Vector2> list2 = Utilities.ComputeOuterShell(m.sharedMesh.vertices.SelectInPlace((Vector3 x) => m.transform.localToWorldMatrix.MultiplyPoint(x).ToVector2()), triangles);
			if (list2 != null && list2.Count > 2)
			{
				list.Add(list2.ToArray());
			}
		}
		if (list.Count > 0)
		{
			Mesh mesh = new Mesh();
			float num = roomSegment.WallWidth / 2f;
			KeyValuePair<Vector2[], int[]> keyValuePair = Utilities.SubtractAndTriangulate(new Vector2[4]
			{
				new Vector2(0f - num, 0f),
				new Vector2(num, 0f),
				new Vector2(num, 2f),
				new Vector2(0f - num, 2f)
			}, list, 0, false);
			mesh.vertices = keyValuePair.Key.SelectInPlace((Vector2 x) => new Vector3(x.x, x.y, 0f));
			mesh.triangles = keyValuePair.Value;
			mesh.normals = Utilities.RepeatValue(Vector3.forward, mesh.vertexCount);
			mesh.RecalculateTangents();
			mesh.name = text;
			WallMeshes.Clear();
			WallMeshes.Add(mesh);
			ObjExporterScript.Start();
			string contents = ObjExporterScript.MeshToString(mesh, null, Matrix4x4.identity, Quaternion.identity);
			ObjExporterScript.End();
			File.WriteAllText(Path.Combine(FurnitureModdingTool.Instance.ActiveMod.Root, text), contents);
			FurnitureModdingTool.Instance.ActiveMod.Meshes.Add(mesh);
			FurnitureModdingTool.Instance.Meshes.Add(mesh);
			GameObject gameObject = new GameObject("WallMesh");
			MeshFilter meshFilter2 = gameObject.AddComponent<MeshFilter>();
			meshFilter2.sharedMesh = mesh;
			meshFilter2.name = text;
			gameObject.transform.SetParent(roomSegment.transform);
			roomSegment.InsideWallMeshes = new MeshFilter[1] { meshFilter2 };
		}
		else
		{
			roomSegment.InsideWallMeshes = Array.Empty<MeshFilter>();
		}
		FurnitureModdingTool.Instance.RefreshCutouts();
		FurnitureModdingTool.Instance.SetInspector(FurnitureModdingTool.Instance.ActiveMeta);
	}

	[FurnModAction]
	public void ReloadCutoutMesh()
	{
		RoomSegment roomSegment = (RoomSegment)Target;
		if (roomSegment.InsideWallMeshes == null || roomSegment.InsideWallMeshes.Length == 0)
		{
			return;
		}
		MeshFilter meshFilter = null;
		for (int i = 0; i < roomSegment.InsideWallMeshes.Length; i++)
		{
			MeshFilter meshFilter2 = roomSegment.InsideWallMeshes[i];
			FurnitureModdingTool.Instance.ActiveMod.Meshes.Remove(meshFilter2.sharedMesh);
			FurnitureModdingTool.Instance.Meshes.Remove(meshFilter2.sharedMesh);
			string name = meshFilter2.sharedMesh.name;
			UnityEngine.Object.Destroy(meshFilter2.sharedMesh);
			string text = Path.Combine(FurnitureModdingTool.Instance.ActiveMod.Root, name);
			if (i == 0 && File.Exists(text))
			{
				Mesh mesh;
				try
				{
					mesh = FurnitureModdingTool.Instance.LoadMesh(text, name, false);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					UnityEngine.Object.Destroy(meshFilter2.gameObject);
					continue;
				}
				if (mesh != null)
				{
					meshFilter = meshFilter2;
					mesh.name = name;
					meshFilter2.sharedMesh = mesh;
				}
				else
				{
					UnityEngine.Object.Destroy(meshFilter2.gameObject);
				}
			}
			else
			{
				UnityEngine.Object.Destroy(meshFilter2.gameObject);
			}
		}
		roomSegment.InsideWallMeshes = ((!(meshFilter != null)) ? null : new MeshFilter[1] { meshFilter });
		FurnitureModdingTool.Instance.RefreshCutouts();
	}

	[FurnModAction]
	public void TestAtlas()
	{
		Furniture f = FurnitureModdingTool.Instance.ActiveObject.GetComponent<Furniture>();
		if (f.AtlasCount > 0)
		{
			f.AtlasIndex = (f.AtlasIndex + 1) % f.AtlasCount;
		}
		else
		{
			if (f.ReplacementGroups == null || f.ReplacementGroups.Length == 0)
			{
				return;
			}
			List<ValueTuple<string, int, string>> options = new List<ValueTuple<string, int, string>>();
			for (int i = 0; i < f.ReplacementGroups.Length; i++)
			{
				ObjectDatabase.ReplacementGroup group;
				if (!ObjectDatabase.Instance.GetReplacementGroup(f.ReplacementGroups[i], out group))
				{
					continue;
				}
				foreach (ObjectDatabase.ReplacementObject replacement in group.Replacements)
				{
					options.Add(new ValueTuple<string, int, string>(group.Name + " -> " + replacement.Name, i, replacement.Name));
				}
			}
			if (options.Count > 0)
			{
				WindowManager.Instance.MultiWindow.Show("Replacements", options.Select((ValueTuple<string, int, string> x) => x.Item1), delegate(int x)
				{
					f.SetReplacement(options[x].Item2, options[x].Item3);
				}, false);
			}
		}
	}

	public IEnumerable<string> GetAllColorGroups()
	{
		foreach (GameObject roomSegment in ObjectDatabase.Instance.RoomSegments)
		{
			RoomSegment component = roomSegment.GetComponent<RoomSegment>();
			if (!string.IsNullOrEmpty(component._defaultColorGroup))
			{
				yield return component._defaultColorGroup;
			}
		}
	}

	public IEnumerable<string> GetAllReplacementGroups()
	{
		foreach (string replacementGroup in ObjectDatabase.Instance.GetReplacementGroups())
		{
			yield return replacementGroup;
		}
	}

	public IEnumerable<string> GetAllReplacementKeys()
	{
		string[] replacementGroups = ReplacementGroups;
		foreach (string text in replacementGroups)
		{
			ObjectDatabase.ReplacementGroup group;
			if (text == null || !ObjectDatabase.Instance.GetReplacementGroup(text, out group))
			{
				continue;
			}
			foreach (ObjectDatabase.ReplacementObject replacement in group.Replacements)
			{
				yield return replacement.Name;
			}
		}
	}

	public IEnumerable<string> GetAllTypes()
	{
		foreach (GameObject roomSegment in ObjectDatabase.Instance.RoomSegments)
		{
			RoomSegment component = roomSegment.GetComponent<RoomSegment>();
			if (component.Type != null)
			{
				yield return component.Type;
			}
		}
	}

	public void UpdateTags()
	{
		FurnitureModdingTool.Instance.UpdateTags();
	}

	public override void WriteToTyD(TydTable root)
	{
		root.SetNode("Name", Name, true);
		root.SetNode("Thumbnail", Thumbnail, true);
		TydTable tydTable = root.FindNode("RoomSegment", true) as TydTable;
		RoomSegment roomSegment = FurnitureModdingTool.Instance.ActivePrefab.BaseObject as RoomSegment;
		GameObject gameObject = null;
		if (roomSegment == null)
		{
			gameObject = new GameObject("Temp");
			roomSegment = gameObject.AddComponent<RoomSegment>();
			roomSegment.enabled = false;
		}
		if (tydTable == null)
		{
			return;
		}
		if (!string.IsNullOrWhiteSpace(LocalizedName))
		{
			tydTable.SetNode("LocalizedName", LocalizedName, true);
		}
		else
		{
			tydTable.RemoveNode("LocalizedName");
		}
		if (!string.IsNullOrWhiteSpace(Description))
		{
			tydTable.SetNode("ButtonDescription", Description, true);
		}
		else
		{
			tydTable.RemoveNode("ButtonDescription");
		}
		if (AtlasObject != null || (((object)roomSegment != null) ? roomSegment.AtlasObject : null) != null)
		{
			tydTable.SetNode("AtlasObject", (AtlasObject != null) ? AtlasObject.Target.name : null, true);
		}
		WriteDirects("RoomSegment", tydTable, roomSegment);
		tydTable.SetNode("Taggable", Taggable.ToString(), true);
		TydNode root2 = root.FindNode("BoxCollider", true);
		BoxCollider boxCollider = (BoxCollider)Collider.Target;
		root2.SetNode("center", boxCollider.center.ToTyd("center"));
		root2.SetNode("size", boxCollider.size.ToTyd("size"));
		if (AltStyles != null && AltStyles.Count > 0)
		{
			TydNode[] children = AltStyles.SelectInPlace((FurnitureStyle x) => new TydList(null, ColorUtility.ToHtmlStringRGB(x.Color1 ?? SVector3.Zero), ColorUtility.ToHtmlStringRGB(x.Color2 ?? SVector3.Zero), ColorUtility.ToHtmlStringRGB(x.Color3 ?? SVector3.Zero)));
			tydTable.SetNode("AltStyles", new TydList("AltStyles", children));
		}
		else
		{
			tydTable.RemoveNode("AltStyles");
		}
		if (gameObject != null)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
		if (WallMeshes.Count > 0)
		{
			tydTable.SetNode("WallMeshes", new TydList("WallMeshes", WallMeshes.SelectInPlace((Mesh x) => x.name)), 0);
		}
		else
		{
			tydTable.RemoveNode("WallMeshes");
		}
	}

	private bool CheckArrayValue<T>(T[] ar, T value, int index, T defValue)
	{
		if ((ar != null || value.Equals(defValue)) && (ar == null || index >= ar.Length || ar[index].Equals(value)))
		{
			if (ar != null && index >= ar.Length)
			{
				return !value.Equals(defValue);
			}
			return false;
		}
		return true;
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
