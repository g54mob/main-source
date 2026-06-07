using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Tyd;
using UnityEngine;

public class HardwareDesign : ScriptableObject
{
	public enum AttachmentType
	{
		Vertex = 0,
		Triangle = 1
	}

	[Serializable]
	public class MorphInfo
	{
		public string Label;

		public float MinValue;

		public float Chance = 1f;

		public int GroupID = -1;

		public int VertexIndex;

		public bool DoubleMorph;

		public bool UseCustomHandle;

		public bool Gauss;

		public float Mean = 0.5f;

		public float Deviation = 0.2f;

		public float HandleMagnitude = 1f;

		public Vector3 CustomHandle;

		public Vector3 CustomHandleDir;

		public MorphInfo()
		{
		}

		public MorphInfo(TydTable node)
		{
			Label = node.GetChildValue("Label");
			MinValue = node.GetChildValue("MinValue", false, 0f);
			Chance = node.GetChildValue("Chance", false, 1f);
			GroupID = node.GetChildValue("GroupID", false, -1);
			VertexIndex = node.GetChildValue("VertexIndex", false, 0);
			DoubleMorph = node.GetChildValue("DoubleMorph", false, false);
			UseCustomHandle = node.GetChildValue("UseCustomHandle", false, false);
			Gauss = node.GetChildValue("Gauss", false, false);
			Mean = node.GetChildValue("Mean", false, 0.5f);
			Deviation = node.GetChildValue("Deviation", false, 0.2f);
			HandleMagnitude = node.GetChildValue("HandleMagnitude", false, 1f);
			CustomHandle = LoadVector(node.GetChild<TydList>("CustomHandle"), Vector3.zero);
			CustomHandleDir = LoadVector(node.GetChild<TydList>("CustomHandleDir"), Vector3.forward);
		}

		public TydTable Export()
		{
			TydTable tydTable = new TydTable(null);
			tydTable.AddChild(new TydString("Label", Label));
			tydTable.AddChild(new TydString("VertexIndex", VertexIndex.ToString()));
			if (MinValue > 0f)
			{
				tydTable.AddChild(new TydString("MinValue", MinValue.ToString()));
			}
			if (Chance < 1f)
			{
				tydTable.AddChild(new TydString("Chance", Chance.ToString()));
			}
			if (GroupID >= 0)
			{
				tydTable.AddChild(new TydString("GroupID", GroupID.ToString()));
			}
			if (DoubleMorph)
			{
				tydTable.AddChild(new TydString("DoubleMorph", DoubleMorph.ToString()));
			}
			if (UseCustomHandle)
			{
				tydTable.AddChild(new TydString("UseCustomHandle", UseCustomHandle.ToString()));
				tydTable.AddChild(ExportVector3("CustomHandle", CustomHandle));
				tydTable.AddChild(ExportVector3("CustomHandleDir", CustomHandleDir));
			}
			if (Gauss)
			{
				tydTable.AddChild(new TydString("Gauss", Gauss.ToString()));
				tydTable.AddChild(new TydString("Mean", Mean.ToString()));
				tydTable.AddChild(new TydString("Deviation", Deviation.ToString()));
			}
			if (HandleMagnitude != 1f)
			{
				tydTable.AddChild(new TydString("HandleMagnitude", HandleMagnitude.ToString()));
			}
			return tydTable;
		}

		public MorphInfo(string label)
		{
			Label = label;
		}

		public override string ToString()
		{
			return Label;
		}
	}

	[Serializable]
	public class MeshObject
	{
		public string ID;

		public string Name;

		public Mesh Mesh;

		[NonSerialized]
		public string MeshFile;

		public int AtlasCount = 1;

		public int Max = -1;

		public float AtlasX;

		public float AtlasY;

		public MorphInfo[] MorphTargets;

		public int GroupID = -1;

		public Vector2 AtlasOffset
		{
			get
			{
				return new Vector2(AtlasX, AtlasY);
			}
		}

		public void Reload(string path)
		{
			UnityEngine.Object.Destroy(Mesh);
			Mesh = LoadMesh(Path.Combine(path, MeshFile));
		}

		private static Mesh LoadMesh(string file)
		{
			if (file.ToLower().EndsWith(".gltf"))
			{
				return SimpleGLTF.Parse(File.ReadAllText(file), Path.GetFileName(file));
			}
			if (file.ToLower().EndsWith(".glb"))
			{
				return SimpleGLTF.Parse(File.ReadAllBytes(file), Path.GetFileName(file));
			}
			List<Mesh> list = ObjImporter.ImportMeshes(Utilities.ReadOnlyReadAllText(file));
			if (list.Count > 1)
			{
				foreach (Mesh item in list)
				{
					UnityEngine.Object.Destroy(item);
				}
				throw new Exception("Mesh file can only contain one mesh!");
			}
			return list[0];
		}

		private static T1[] CalcDelta<T1, T2>(List<T2> l, T2[] i, T1[] o, Func<T2, T2, T1> sub)
		{
			int num = Mathf.Min(l.Count, i.Length);
			for (int j = 0; j < num; j++)
			{
				o[j] = sub(l[j], i[j]);
			}
			return o;
		}

		public MeshObject(TydTable node, string path, out bool needsMorphs)
		{
			needsMorphs = false;
			ID = node.GetChildValue("ID");
			Name = node.GetChildValue("Name");
			MeshFile = node.GetChildValue("Mesh");
			Mesh = LoadMesh(Path.Combine(path, MeshFile));
			TydList child = node.GetChild<TydList>("MorphTargets");
			if (child != null)
			{
				MorphTargets = (from x in child.Nodes.OfType<TydTable>()
					select new MorphInfo(x)).ToArray();
			}
			else
			{
				MorphTargets = new MorphInfo[Mesh.blendShapeCount];
				for (int num = 0; num < Mesh.blendShapeCount; num++)
				{
					needsMorphs = true;
					MorphTargets[num] = new MorphInfo(Mesh.GetBlendShapeName(num));
				}
			}
			AtlasCount = node.GetChildValue("AtlasCount", false, 1);
			Max = node.GetChildValue("Max", false, -1);
			GroupID = node.GetChildValue("GroupID", false, -1);
			AtlasX = node.GetChildValue("AtlasX", false, 0f);
			AtlasY = node.GetChildValue("AtlasY", false, 0f);
		}

		public MeshObject(string file, string path)
		{
			Name = (ID = Path.GetFileNameWithoutExtension(file));
			MeshFile = file;
			Mesh = LoadMesh(Path.Combine(path, MeshFile));
			MorphTargets = new MorphInfo[Mesh.blendShapeCount];
			for (int i = 0; i < Mesh.blendShapeCount; i++)
			{
				MorphTargets[i] = new MorphInfo(Mesh.GetBlendShapeName(i));
			}
		}

		public TydTable Export()
		{
			TydTable tydTable = new TydTable(null);
			tydTable.AddChild(new TydString("ID", ID));
			tydTable.AddChild(new TydString("Name", Name));
			tydTable.AddChild(new TydString("Mesh", MeshFile));
			if (MorphTargets.Length != 0)
			{
				TydNode[] children = MorphTargets.SelectInPlace((MorphInfo x) => x.Export());
				tydTable.AddChild(new TydList("MorphTargets", children));
			}
			if (AtlasCount != 1)
			{
				tydTable.AddChild(new TydString("AtlasCount", AtlasCount.ToString()));
				tydTable.AddChild(new TydString("AtlasX", AtlasX.ToString()));
				tydTable.AddChild(new TydString("AtlasY", AtlasY.ToString()));
			}
			if (Max >= 0)
			{
				tydTable.AddChild(new TydString("Max", Max.ToString()));
			}
			if (GroupID >= 0)
			{
				tydTable.AddChild(new TydString("GroupID", GroupID.ToString()));
			}
			return tydTable;
		}

		public MeshObject()
		{
		}

		public int GetActualMorphIndex(int idx)
		{
			int num = 0;
			for (int i = 0; i < idx; i++)
			{
				num = ((!MorphTargets[i].DoubleMorph) ? (num + 1) : (num + 2));
			}
			return num;
		}

		public override string ToString()
		{
			return Name;
		}
	}

	[Serializable]
	public class Attachment
	{
		public string Object;

		public Vector3 Offset;

		public Vector3 Rotation;

		public bool FlipX;

		public bool FlipY;

		public bool FlipZ;

		public bool Roll = true;

		public bool UseForGeneration = true;

		public int GroupID = -1;

		public Attachment()
		{
		}

		public Attachment(string obj)
		{
			Object = obj;
		}

		public Attachment(TydTable t)
		{
			Object = t.GetChildValue("Object");
			Offset = LoadVector(t.GetChild<TydList>("Offset"), Vector3.zero);
			Rotation = LoadVector(t.GetChild<TydList>("Rotation"), Vector3.zero);
			TydList child = t.GetChild<TydList>("Flip");
			if (child != null)
			{
				FlipX = child.GetChildValue<bool>(0);
				FlipY = child.GetChildValue<bool>(1);
				FlipZ = child.GetChildValue<bool>(2);
			}
			Roll = t.GetChildValue("Roll", false, false);
			UseForGeneration = t.GetChildValue("UseForGeneration", false, true);
			GroupID = t.GetChildValue("GroupID", false, -1);
		}

		public TydTable Export()
		{
			TydTable tydTable = new TydTable(null);
			tydTable.AddChild(new TydString("Object", Object));
			tydTable.AddChild(ExportVector3("Offset", Offset));
			tydTable.AddChild(ExportVector3("Rotation", Rotation));
			tydTable.AddChild(new TydString("Roll", Roll.ToString()));
			if (FlipX || FlipY || FlipZ)
			{
				tydTable.AddChild(new TydList("Flip", FlipX.ToString(), FlipY.ToString(), FlipZ.ToString()));
			}
			if (!UseForGeneration)
			{
				tydTable.AddChild(new TydString("UseForGeneration", UseForGeneration.ToString()));
			}
			if (GroupID >= 0)
			{
				tydTable.AddChild(new TydString("GroupID", GroupID.ToString()));
			}
			return tydTable;
		}

		public override string ToString()
		{
			return Object;
		}
	}

	[Serializable]
	public class AttachmentPoint
	{
		public string Name = "Point";

		public int Index;

		public bool CanBeEmpty;

		public bool CanRemove;

		public AttachmentType Type = AttachmentType.Triangle;

		public List<Attachment> Attachments = new List<Attachment>();

		public int GroupID = -1;

		public bool ControlOnlyEmpty;

		public Vector3 AreaOffset;

		public AttachmentPoint()
		{
		}

		public AttachmentPoint(int index, AttachmentType type)
		{
			Index = index;
			Type = type;
		}

		public AttachmentPoint(TydTable t)
		{
			Name = t.GetChildValue("Name");
			Index = t.GetChildValue("Index", true, 0);
			CanBeEmpty = t.GetChildValue("CanBeEmpty", false, false);
			CanRemove = t.GetChildValue("CanRemove", false, false);
			Type = t.GetChildValue("Type", false, AttachmentType.Triangle);
			Attachments = (from x in t.GetChild<TydList>("Attachments").Nodes.OfType<TydTable>()
				select new Attachment(x)).ToList();
			GroupID = t.GetChildValue("GroupID", false, -1);
			ControlOnlyEmpty = t.GetChildValue("ControlOnlyEmpty", false, false);
			AreaOffset = LoadVector(t.GetChild<TydList>("AreaOffset"), Vector3.zero);
		}

		public TydTable Export()
		{
			TydTable tydTable = new TydTable(null);
			tydTable.AddChild(new TydString("Name", Name));
			tydTable.AddChild(new TydString("Index", Index.ToString()));
			tydTable.AddChild(new TydString("Type", Type.ToString()));
			if (CanBeEmpty)
			{
				tydTable.AddChild(new TydString("CanBeEmpty", CanBeEmpty.ToString()));
			}
			if (CanRemove)
			{
				tydTable.AddChild(new TydString("CanRemove", CanRemove.ToString()));
			}
			if (ControlOnlyEmpty)
			{
				tydTable.AddChild(new TydString("ControlOnlyEmpty", ControlOnlyEmpty.ToString()));
			}
			if (AreaOffset != Vector3.zero)
			{
				tydTable.AddChild(ExportVector3("AreaOffset", AreaOffset));
			}
			if (GroupID >= 0)
			{
				tydTable.AddChild(new TydString("GroupID", GroupID.ToString()));
			}
			TydNode[] children = Attachments.SelectInPlace((Attachment x) => x.Export());
			tydTable.AddChild(new TydList("Attachments", children));
			return tydTable;
		}

		public override string ToString()
		{
			return Name;
		}
	}

	[Serializable]
	public class ColorSet
	{
		public List<Color> Primaries = new List<Color>();

		public List<Color> Secondaries = new List<Color>();

		public List<Color> Tertieries = new List<Color>();

		public ColorSet()
		{
		}

		public ColorSet(List<Color> p, List<Color> s, List<Color> t)
		{
			Primaries = p;
			Secondaries = s;
			Tertieries = t;
		}
	}

	public string ID;

	public string Name;

	public bool BuiltIn;

	public MeshObject[] Objects;

	public List<AttachmentPoint> Attachments;

	public string BaseMesh;

	[NonSerialized]
	public string BaseTexFile;

	[NonSerialized]
	public string NormalTexFile;

	[NonSerialized]
	public string ExtraTexFile;

	[NonSerialized]
	public string FileLocation;

	public Material Mat;

	public bool ColorPrimary;

	public bool ColorSecondary;

	public bool ColorTertiary;

	public List<ColorSet> ColorSets = new List<ColorSet>();

	public Vector3 ThumbnailOffset;

	public float ZoomOffset;

	public float RotOffset;

	public float RotOffsetX;

	public float WorldScale = 0.2f;

	[NonSerialized]
	public ModPackage Parent;

	[NonSerialized]
	private Dictionary<string, MeshObject> _objects;

	private static float GetVectorAt(TydList node, int idx, float dValue)
	{
		if (idx >= 0 && idx < node.Count)
		{
			TydString tydString = node[idx] as TydString;
			if (tydString != null)
			{
				return tydString.Value.ConvertToFloatDef(dValue);
			}
		}
		return dValue;
	}

	public static Vector3 LoadVector(TydList node, Vector3 dValue)
	{
		if (node == null)
		{
			return dValue;
		}
		return new Vector3(GetVectorAt(node, 0, dValue.x), GetVectorAt(node, 1, dValue.y), GetVectorAt(node, 2, dValue.z));
	}

	public static TydList ExportVector3(string name, Vector3 v)
	{
		return new TydList(name, v.x.ToString(), v.y.ToString(), v.z.ToString());
	}

	public string CheckForErrors()
	{
		MeshObject meshObject = GetObject(BaseMesh);
		if (meshObject == null)
		{
			return "Base: " + BaseMesh + " is missing";
		}
		MeshObject[] objects = Objects;
		foreach (MeshObject meshObject2 in objects)
		{
			MorphInfo[] morphTargets = meshObject2.MorphTargets;
			foreach (MorphInfo morphInfo in morphTargets)
			{
				if (!morphInfo.UseCustomHandle && morphInfo.VertexIndex >= meshObject2.Mesh.vertexCount)
				{
					return "Morph target: " + morphInfo.Label + " of " + meshObject2.ID + "'s handle is attached to vertex " + morphInfo.VertexIndex + " but mesh only has " + meshObject2.Mesh.vertexCount;
				}
			}
		}
		foreach (AttachmentPoint attachment in Attachments)
		{
			switch (attachment.Type)
			{
			case AttachmentType.Vertex:
				if (attachment.Index >= meshObject.Mesh.vertexCount)
				{
					return "Attachment: " + attachment.Name + " is attached to vertex " + attachment.Index + " but mesh only has " + meshObject.Mesh.vertexCount;
				}
				break;
			case AttachmentType.Triangle:
			{
				int num = meshObject.Mesh.triangles.Length;
				if (attachment.Index >= num - 2)
				{
					return "Attachment: " + attachment.Name + " is attached to triangle " + Mathf.CeilToInt((float)attachment.Index / 3f) + " but mesh only has " + num / 3;
				}
				break;
			}
			}
			foreach (Attachment attachment2 in attachment.Attachments)
			{
				if (GetObject(attachment2.Object) == null)
				{
					return "Attachment: " + attachment.Name + " is using non-existent mesh " + attachment2.Object;
				}
			}
		}
		return null;
	}

	[ContextMenu("Check morph")]
	public void CheckMorph()
	{
		MeshObject[] objects = Objects;
		foreach (MeshObject meshObject in objects)
		{
			if (meshObject.MorphTargets == null || meshObject.MorphTargets.Length == 0)
			{
				continue;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Morphs for " + meshObject.Name + ":");
			int num = 0;
			for (int j = 0; j < meshObject.MorphTargets.Length; j++)
			{
				MorphInfo morphInfo = meshObject.MorphTargets[j];
				if (num >= meshObject.Mesh.blendShapeCount)
				{
					stringBuilder.AppendLine("Too few blendshapes compared to morphs defined!");
					break;
				}
				if (morphInfo.DoubleMorph)
				{
					stringBuilder.AppendLine(morphInfo.Label + ": " + meshObject.Mesh.GetBlendShapeName(num) + ", " + meshObject.Mesh.GetBlendShapeName(num + 1));
					num += 2;
				}
				else
				{
					stringBuilder.AppendLine(morphInfo.Label + ": " + meshObject.Mesh.GetBlendShapeName(num));
					num++;
				}
			}
			Debug.Log(stringBuilder.ToString());
		}
	}

	public void CalculateMorphHandles(MeshObject mO)
	{
		if (mO.MorphTargets == null || mO.MorphTargets.Length == 0)
		{
			return;
		}
		Vector3[] array = new Vector3[mO.Mesh.vertexCount];
		Vector3[] array2 = new Vector3[array.Length];
		int num = 0;
		for (int i = 0; i < mO.MorphTargets.Length; i++)
		{
			MorphInfo morphInfo = mO.MorphTargets[i];
			if (morphInfo.DoubleMorph)
			{
				mO.Mesh.GetBlendVertices(num, array);
				mO.Mesh.GetBlendVertices(num + 1, array2);
				morphInfo.VertexIndex = GetLargestChange(array, array2);
				num += 2;
			}
			else
			{
				mO.Mesh.GetBlendVertices(num, array);
				morphInfo.VertexIndex = GetLargestChange(array);
				num++;
			}
			morphInfo.UseCustomHandle = false;
			morphInfo.HandleMagnitude = 1f;
		}
	}

	public void CalculateMorphHandle(MeshObject mO, int i)
	{
		Vector3[] array = new Vector3[mO.Mesh.vertexCount];
		Vector3[] array2 = new Vector3[array.Length];
		MorphInfo morphInfo = mO.MorphTargets[i];
		int actualMorphIndex = mO.GetActualMorphIndex(i);
		if (morphInfo.DoubleMorph)
		{
			mO.Mesh.GetBlendVertices(actualMorphIndex, array);
			mO.Mesh.GetBlendVertices(actualMorphIndex + 1, array2);
			morphInfo.VertexIndex = GetLargestChange(array, array2);
		}
		else
		{
			mO.Mesh.GetBlendVertices(actualMorphIndex, array);
			morphInfo.VertexIndex = GetLargestChange(array);
		}
		morphInfo.UseCustomHandle = false;
		morphInfo.HandleMagnitude = 1f;
	}

	private int GetLargestChange(Vector3[] v)
	{
		int result = 0;
		float num = float.MinValue;
		for (int i = 0; i < v.Length; i++)
		{
			float sqrMagnitude = v[i].sqrMagnitude;
			if (sqrMagnitude > num)
			{
				num = sqrMagnitude;
				result = i;
			}
		}
		return result;
	}

	private int GetLargestChange(Vector3[] v1, Vector3[] v2)
	{
		int result = 0;
		float num = float.MinValue;
		for (int i = 0; i < v1.Length; i++)
		{
			float sqrMagnitude = (v1[i] - v2[i]).sqrMagnitude;
			if (sqrMagnitude > num)
			{
				num = sqrMagnitude;
				result = i;
			}
		}
		return result;
	}

	public MeshObject GetObject(string ID)
	{
		if (_objects == null)
		{
			_objects = Objects.ToDictionary((MeshObject x) => x.ID, (MeshObject x) => x);
		}
		return _objects.GetOrNull(ID);
	}

	public List<Color> GetDefaults(int i)
	{
		if (i < 0 || i > 2)
		{
			throw new Exception("Hardware design only has 3 colors");
		}
		if (ColorSets.Count == 0)
		{
			return new List<Color>();
		}
		if (ColorSets.Count == 1)
		{
			switch (i)
			{
			case 0:
				return ColorSets[0].Primaries;
			case 1:
				return ColorSets[0].Secondaries;
			case 2:
				return ColorSets[0].Tertieries;
			default:
				return null;
			}
		}
		List<Color> list = new List<Color>();
		switch (i)
		{
		case 0:
			list.AddRange(ColorSets.SelectMany((ColorSet x) => x.Primaries));
			break;
		case 1:
			list.AddRange(ColorSets.SelectMany((ColorSet x) => x.Secondaries));
			break;
		case 2:
			list.AddRange(ColorSets.SelectMany((ColorSet x) => x.Tertieries));
			break;
		}
		return list;
	}

	public bool ColorActive(int i)
	{
		switch (i)
		{
		case 0:
			return ColorPrimary;
		case 1:
			return ColorSecondary;
		case 2:
			return ColorTertiary;
		default:
			throw new Exception("Hardware design only has 3 colors");
		}
	}

	public GameObject SpawnObject(MeshObject obj, out bool skinned)
	{
		skinned = false;
		GameObject gameObject = new GameObject(obj.ID);
		if (obj.Mesh.blendShapeCount > 0)
		{
			gameObject.AddComponent<SkinnedMeshRenderer>().sharedMesh = obj.Mesh;
			skinned = true;
		}
		else
		{
			gameObject.AddComponent<MeshFilter>().sharedMesh = obj.Mesh;
			gameObject.AddComponent<MeshRenderer>();
		}
		return gameObject;
	}

	public HardwareDesignInstance CreateRandomInstance(int layer, HashSet<string> disallowed)
	{
		HardwareDesignInstance hardwareDesignInstance = new GameObject(Name).AddComponent<HardwareDesignInstance>();
		hardwareDesignInstance.Design = this;
		hardwareDesignInstance.Layer = layer;
		hardwareDesignInstance.CreateRandom(disallowed);
		return hardwareDesignInstance;
	}

	private static void LoadColors(TydList t, List<Color> colors)
	{
		if (t == null)
		{
			return;
		}
		foreach (TydString item in t.Nodes.OfType<TydString>())
		{
			Color color;
			if (ColorUtility.TryParseHtmlString("#" + item.Value.Replace("#", ""), out color))
			{
				colors.Add(color);
			}
		}
	}

	public TydDocument SaveDesign()
	{
		TydDocument tydDocument = new TydDocument();
		TydTable tydTable = tydDocument.AddChild(new TydTable("Design"));
		tydTable.AddChild(new TydString("ID", ID));
		tydTable.AddChild(new TydString("Name", Name));
		tydTable.AddChild(new TydString("BaseMesh", BaseMesh));
		TydNode[] children = Objects.SelectInPlace((MeshObject x) => x.Export());
		tydTable.AddChild(new TydList("Objects", children));
		children = Attachments.SelectInPlace((AttachmentPoint x) => x.Export());
		tydTable.AddChild(new TydList("Attachments", children));
		tydTable.AddChild(new TydString("BaseTexture", BaseTexFile));
		if (NormalTexFile != null)
		{
			tydTable.AddChild(new TydString("NormalTexture", NormalTexFile));
		}
		if (ExtraTexFile != null)
		{
			tydTable.AddChild(new TydString("ExtraTexture", ExtraTexFile));
		}
		if (!ColorPrimary)
		{
			tydTable.AddChild(new TydString("PrimaryColorEnabled", ColorPrimary.ToString()));
		}
		if (ColorSecondary)
		{
			tydTable.AddChild(new TydString("SecondaryColorEnabled", ColorSecondary.ToString()));
		}
		if (ColorTertiary)
		{
			tydTable.AddChild(new TydString("TertiaryColorEnabled", ColorTertiary.ToString()));
		}
		if (ColorPrimary || ColorSecondary || ColorTertiary)
		{
			TydList tydList = tydTable.AddChild(new TydList("ColorSets"));
			foreach (ColorSet colorSet in ColorSets)
			{
				TydTable tydTable2 = tydList.AddChild(new TydTable(""));
				if (ColorPrimary)
				{
					tydTable2.AddChild(new TydList("PrimaryColors", colorSet.Primaries.SelectInPlace(ColorUtility.ToHtmlStringRGB)));
				}
				if (ColorSecondary)
				{
					tydTable2.AddChild(new TydList("SecondaryColors", colorSet.Secondaries.SelectInPlace(ColorUtility.ToHtmlStringRGB)));
				}
				if (ColorTertiary)
				{
					tydTable2.AddChild(new TydList("TertiaryColors", colorSet.Tertieries.SelectInPlace(ColorUtility.ToHtmlStringRGB)));
				}
			}
		}
		if (ThumbnailOffset != Vector3.zero)
		{
			tydTable.AddChild(ExportVector3("ThumbnailOffset", ThumbnailOffset));
		}
		if (ZoomOffset != 0f)
		{
			tydTable.AddChild(new TydString("ZoomOffset", ZoomOffset.ToString()));
		}
		if (RotOffset != 0f)
		{
			tydTable.AddChild(new TydString("RotYOffset", RotOffset.ToString()));
		}
		if (RotOffsetX != 0f)
		{
			tydTable.AddChild(new TydString("RotXOffset", RotOffsetX.ToString()));
		}
		tydTable.AddChild(new TydString("WorldScale", WorldScale.ToString()));
		return tydDocument;
	}

	public static HardwareDesign CreateDesign(string id, string pathToFile, string baseMesh, string[] meshes, string mainTex, string extraTex, string normalTex, out string error)
	{
		HardwareDesign hardwareDesign = ScriptableObject.CreateInstance<HardwareDesign>();
		bool mat = false;
		bool albTex = false;
		bool normTex = false;
		bool exTex = false;
		try
		{
			error = null;
			string path = Path.GetDirectoryName(pathToFile);
			hardwareDesign.FileLocation = pathToFile;
			hardwareDesign.Mat = new Material(ObjectDatabase.Instance.HardwareDesignMaterial);
			mat = true;
			hardwareDesign.ID = (hardwareDesign.Name = id);
			hardwareDesign.BaseMesh = Path.GetFileNameWithoutExtension(baseMesh);
			hardwareDesign.Objects = meshes.SelectInPlace((string x) => new MeshObject(x, path));
			MeshObject[] objects = hardwareDesign.Objects;
			foreach (MeshObject mO in objects)
			{
				hardwareDesign.CalculateMorphHandles(mO);
			}
			hardwareDesign.Attachments = new List<AttachmentPoint>();
			hardwareDesign.BaseTexFile = mainTex;
			Texture2D texture2D = new Texture2D(4, 4);
			texture2D.LoadImage(File.ReadAllBytes(Path.Combine(path, hardwareDesign.BaseTexFile)));
			hardwareDesign.Mat.SetTexture("_MainTex", texture2D);
			albTex = true;
			hardwareDesign.NormalTexFile = normalTex;
			if (hardwareDesign.NormalTexFile != null)
			{
				texture2D = new Texture2D(4, 4);
				texture2D.LoadImage(File.ReadAllBytes(Path.Combine(path, hardwareDesign.NormalTexFile)));
				hardwareDesign.Mat.SetTexture("_LumpMap", texture2D);
				hardwareDesign.Mat.EnableKeyword("_BUMPMAP");
				normTex = true;
			}
			hardwareDesign.ExtraTexFile = extraTex;
			if (hardwareDesign.ExtraTexFile != null)
			{
				texture2D = new Texture2D(4, 4);
				texture2D.LoadImage(File.ReadAllBytes(Path.Combine(path, hardwareDesign.ExtraTexFile)));
				hardwareDesign.Mat.SetTexture("_ExtraTex", texture2D);
				hardwareDesign.Mat.EnableKeyword("_EXTRAMAP");
				exTex = true;
			}
			hardwareDesign.ColorSets.Add(new ColorSet(new List<Color> { Color.red }, new List<Color> { Color.green }, new List<Color> { Color.blue }));
			return hardwareDesign;
		}
		catch (Exception ex)
		{
			error = ex.Message;
			hardwareDesign.CleanUp(mat, albTex, normTex, exTex);
			UnityEngine.Object.Destroy(hardwareDesign);
		}
		return null;
	}

	public static HardwareDesign LoadDesign(TydTable t, string pathToFile)
	{
		string path = Path.GetDirectoryName(pathToFile);
		HardwareDesign hardwareDesign = ScriptableObject.CreateInstance<HardwareDesign>();
		bool mat = false;
		bool albTex = false;
		bool normTex = false;
		bool exTex = false;
		try
		{
			hardwareDesign.FileLocation = pathToFile;
			hardwareDesign.Mat = new Material(ObjectDatabase.Instance.HardwareDesignMaterial);
			mat = true;
			hardwareDesign.ID = t.GetChildValue("ID");
			hardwareDesign.Name = t.GetChildValue("Name");
			hardwareDesign.BaseMesh = t.GetChildValue("BaseMesh");
			List<MeshObject> refMorph = new List<MeshObject>();
			hardwareDesign.Objects = t.GetChild<TydList>("Objects", true).Nodes.OfType<TydTable>().Select(delegate(TydTable x)
			{
				bool needsMorphs = false;
				MeshObject meshObject = new MeshObject(x, path, out needsMorphs);
				if (needsMorphs)
				{
					refMorph.Add(meshObject);
				}
				return meshObject;
			}).ToArray();
			if (hardwareDesign.GetObject(hardwareDesign.BaseMesh) == null)
			{
				throw new Exception("Base mesh for " + hardwareDesign.ID + " does not exist: " + hardwareDesign.BaseMesh);
			}
			foreach (MeshObject item in refMorph)
			{
				hardwareDesign.CalculateMorphHandles(item);
			}
			hardwareDesign.Attachments = new List<AttachmentPoint>();
			TydList child = t.GetChild<TydList>("Attachments");
			if (child != null)
			{
				hardwareDesign.Attachments.AddRange(from x in child.Nodes.OfType<TydTable>()
					select new AttachmentPoint(x));
			}
			hardwareDesign.BaseTexFile = t.GetChildValue("BaseTexture");
			Texture2D texture2D = new Texture2D(4, 4);
			texture2D.LoadImage(File.ReadAllBytes(Path.Combine(path, hardwareDesign.BaseTexFile)));
			hardwareDesign.Mat.SetTexture("_MainTex", texture2D);
			albTex = true;
			hardwareDesign.NormalTexFile = t.GetChildValue("NormalTexture", false);
			if (hardwareDesign.NormalTexFile != null)
			{
				texture2D = new Texture2D(4, 4);
				texture2D.LoadImage(File.ReadAllBytes(Path.Combine(path, hardwareDesign.NormalTexFile)));
				hardwareDesign.Mat.SetTexture("_LumpMap", texture2D);
				hardwareDesign.Mat.EnableKeyword("_BUMPMAP");
				normTex = true;
			}
			hardwareDesign.ExtraTexFile = t.GetChildValue("ExtraTexture", false);
			if (hardwareDesign.ExtraTexFile != null)
			{
				texture2D = new Texture2D(4, 4);
				texture2D.LoadImage(File.ReadAllBytes(Path.Combine(path, hardwareDesign.ExtraTexFile)));
				hardwareDesign.Mat.SetTexture("_ExtraTex", texture2D);
				hardwareDesign.Mat.EnableKeyword("_EXTRAMAP");
				exTex = true;
			}
			hardwareDesign.ColorPrimary = t.GetChildValue("PrimaryColorEnabled", false, true);
			hardwareDesign.ColorSecondary = t.GetChildValue("SecondaryColorEnabled", false, false);
			hardwareDesign.ColorTertiary = t.GetChildValue("TertiaryColorEnabled", false, false);
			TydList child2 = t.GetChild<TydList>("ColorSets");
			if (child2 != null)
			{
				foreach (TydTable item2 in child2.Nodes.OfType<TydTable>())
				{
					ColorSet colorSet = new ColorSet();
					hardwareDesign.ColorSets.Add(colorSet);
					LoadColors(item2.GetChild<TydList>("PrimaryColors"), colorSet.Primaries);
					LoadColors(item2.GetChild<TydList>("SecondaryColors"), colorSet.Secondaries);
					LoadColors(item2.GetChild<TydList>("TertiaryColors"), colorSet.Tertieries);
				}
			}
			else if (hardwareDesign.ColorPrimary)
			{
				hardwareDesign.ColorSets.Add(new ColorSet());
				hardwareDesign.ColorSets[0].Primaries.Add(new Color(1f, 0f, 0f));
			}
			hardwareDesign.ThumbnailOffset = LoadVector(t.GetChild<TydList>("ThumbnailOffset"), Vector3.zero);
			hardwareDesign.ZoomOffset = t.GetChildValue("ZoomOffset", false, 0f);
			hardwareDesign.WorldScale = Mathf.Clamp(t.GetChildValue("WorldScale", false, 0.2f), 0.2f, 1f);
			hardwareDesign.RotOffset = t.GetChildValue("RotYOffset", false, 0f);
			hardwareDesign.RotOffsetX = t.GetChildValue("RotXOffset", false, 0f);
			return hardwareDesign;
		}
		catch (Exception ex)
		{
			hardwareDesign.CleanUp(mat, albTex, normTex, exTex);
			UnityEngine.Object.Destroy(hardwareDesign);
			throw ex;
		}
	}

	public void CleanUp(bool mat, bool albTex, bool normTex, bool exTex)
	{
		if (BuiltIn)
		{
			return;
		}
		if (Objects != null)
		{
			for (int i = 0; i < Objects.Length; i++)
			{
				if (Objects[i].Mesh != null)
				{
					UnityEngine.Object.Destroy(Objects[i].Mesh);
				}
			}
		}
		if (!mat || !(Mat != null))
		{
			return;
		}
		if (albTex)
		{
			Texture texture = Mat.GetTexture("_MainTex");
			if (texture != null)
			{
				UnityEngine.Object.Destroy(texture);
			}
		}
		if (exTex)
		{
			Texture texture = Mat.GetTexture("_ExtraTex");
			if (texture != null)
			{
				UnityEngine.Object.Destroy(texture);
			}
		}
		if (normTex)
		{
			Texture texture = Mat.GetTexture("_LumpMap");
			if (texture != null)
			{
				UnityEngine.Object.Destroy(texture);
			}
		}
		UnityEngine.Object.Destroy(Mat);
	}

	public static void GetPoint(int tr, AttachmentType type, Vector3[] vertices, Vector3[] normals, int[] tris, Matrix4x4 transform, bool roll, out Vector3 p, out Vector3 n, out Vector3 u)
	{
		if (type == AttachmentType.Vertex)
		{
			if (tr >= vertices.Length)
			{
				p = Vector3.zero;
				n = Vector3.right;
				u = Vector3.up;
				return;
			}
			p = transform.MultiplyPoint(vertices[tr]);
			n = Vector3.zero;
			u = (roll ? Vector3.zero : Vector3.right);
			int num = 0;
			for (int i = 0; i < tris.Length; i += 3)
			{
				if (tris[i] == tr || tris[i + 1] == tr || tris[i + 2] == tr)
				{
					Vector3 vector = transform.MultiplyPoint(vertices[tris[i]]);
					Vector3 vector2 = transform.MultiplyPoint(vertices[tris[i + 1]]);
					Vector3 vector3 = transform.MultiplyPoint(vertices[tris[i + 2]]);
					n += Vector3.Cross(vector2 - vector, vector3 - vector).normalized;
					if (roll)
					{
						u += (vector2 - vector).normalized;
					}
					num++;
				}
			}
			n = (n * (1f / (float)num)).normalized;
			if (roll)
			{
				u = (u * (1f / (float)num)).normalized;
			}
		}
		else if (tr + 2 >= tris.Length)
		{
			p = Vector3.zero;
			n = Vector3.right;
			u = Vector3.up;
		}
		else
		{
			Vector3 vector4 = transform.MultiplyPoint(vertices[tris[tr]]);
			Vector3 vector5 = transform.MultiplyPoint(vertices[tris[tr + 1]]);
			Vector3 vector6 = transform.MultiplyPoint(vertices[tris[tr + 2]]);
			p = (vector4 + vector5 + vector6) * (1f / 3f);
			n = Vector3.Cross(vector5 - vector4, vector6 - vector4).normalized;
			u = (roll ? (vector5 - vector4).normalized : Vector3.right);
		}
	}
}
