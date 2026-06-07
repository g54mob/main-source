using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class WallSnap : Selectable
{
	public string Type = "";

	[FormerlySerializedAs("LocName")]
	public string LocalizedName = "";

	[FormerlySerializedAs("Desc")]
	[TextArea(3, 10)]
	public string ButtonDescription;

	public string[] IsIconic;

	public float LightAddition;

	public float WallWidth;

	public float YOffset;

	public float Permeability;

	public bool ReverseWallSide;

	public bool IsPrivate;

	public bool CustomHeight;

	public bool OnlyInEditor;

	public bool AllowForMods;

	public Sprite Thumbnail;

	[HideInInspector]
	public WallSnap BaseObject;

	[NonSerialized]
	public string FileName;

	public float[] ValidHeights = new float[0];

	public float WallHeight;

	public float GridSizeOverride = -1f;

	[NonSerialized]
	protected bool _beingStylized;

	[NonSerialized]
	public Dictionary<WallEdge, float> WallPosition = new Dictionary<WallEdge, float>();

	public WallEdge FirstEdge;

	public WallEdge SecondEdge;

	public MeshFilter[] InsideWallMeshes = new MeshFilter[0];

	[NonSerialized]
	public bool IsReversed;

	private static WallEdge[] _edgeChangeCache = new WallEdge[2];

	[NonSerialized]
	public bool DeserializeClone;

	private uint TempSnapRoom;

	private bool TempSnapReversed;

	[Header("Style")]
	[SerializeField]
	public string _defaultColorGroup;

	public string PrimaryColorName = "Primary";

	public string SecondaryColorName = "Secondary";

	public string TertiaryColorName = "Tertiary";

	public bool ColorPrimaryEnabled;

	public bool ColorSecondaryEnabled;

	public bool ColorTertiaryEnabled;

	public bool ForceColorPrimary;

	public bool ForceColorSecondary;

	public bool ForceColorTertiary;

	[NonSerialized]
	public bool TurnOffSecondaryColor;

	[NonSerialized]
	public bool TurnOffTertiaryColor;

	private Color _colorPrimary;

	private Color _colorSecondary;

	private Color _colorTertiary;

	[NonSerialized]
	public bool DisableInitColor;

	public Color ColorPrimaryDefault;

	public Color ColorSecondaryDefault;

	public Color ColorTertiaryDefault;

	public List<FurnitureStyle> AltStyles = new List<FurnitureStyle>();

	public List<Renderer> Colorable;

	public List<PipLight> ColorableLights;

	public ReplacementMesh[] ReplacementMeshes;

	public string[] ReplacementGroups;

	public string[] Replacements;

	public bool LightPrimary = true;

	protected MaterialPropertyBlock _matBlock;

	public MeshRenderer AtlasObject;

	public Vector2 AtlasDimensions;

	public int AtlasCount;

	public int AtlasSkip = 1;

	public int AtlasOff;

	public bool AtlasColorable;

	[NonSerialized]
	private int _atlasIndex = -1;

	public float CustomizationRotation;

	public string DefaultColorGroup
	{
		get
		{
			if (!string.IsNullOrEmpty(_defaultColorGroup))
			{
				return _defaultColorGroup;
			}
			return base.name;
		}
	}

	public bool ColorEditEnabled
	{
		get
		{
			if (!ColorPrimaryEnabled && !ColorSecondaryEnabled)
			{
				return ColorTertiaryEnabled;
			}
			return true;
		}
	}

	public Color ActualColorPrimary
	{
		get
		{
			if (!ColorPrimaryEnabled)
			{
				return ColorPrimaryDefault;
			}
			return _colorPrimary;
		}
	}

	public Color ActualColorSecondary
	{
		get
		{
			if (!ColorSecondaryEnabled)
			{
				return ColorSecondaryDefault;
			}
			return _colorSecondary;
		}
	}

	public Color ActualColorTertiary
	{
		get
		{
			if (!ColorTertiaryEnabled)
			{
				return ColorTertiaryDefault;
			}
			return _colorTertiary;
		}
	}

	public Color ColorPrimary
	{
		get
		{
			return _colorPrimary;
		}
		set
		{
			if (!ColorPrimaryEnabled)
			{
				_colorPrimary = value;
				return;
			}
			_colorPrimary = value;
			if (LightPrimary && ColorableLights != null)
			{
				ColorableLights.ForEach(delegate(PipLight x)
				{
					x.color = _colorPrimary;
				});
			}
			UpdateMaterials();
		}
	}

	public Color ColorSecondary
	{
		get
		{
			if (!TurnOffSecondaryColor)
			{
				return _colorSecondary;
			}
			return Color.black;
		}
		set
		{
			if (!ColorSecondaryEnabled)
			{
				_colorSecondary = value;
				return;
			}
			_colorSecondary = value;
			UpdateMaterials();
		}
	}

	public Color ColorTertiary
	{
		get
		{
			if (!TurnOffTertiaryColor)
			{
				return _colorTertiary;
			}
			return Color.black;
		}
		set
		{
			if (!ColorTertiaryEnabled)
			{
				_colorTertiary = value;
				return;
			}
			_colorTertiary = value;
			if (!LightPrimary)
			{
				ColorableLights.ForEach(delegate(PipLight x)
				{
					x.color = _colorTertiary;
				});
			}
			UpdateMaterials();
		}
	}

	public int AtlasIndex
	{
		get
		{
			return _atlasIndex;
		}
		set
		{
			if (_atlasIndex == value)
			{
				return;
			}
			_atlasIndex = value;
			if (AtlasObject != null)
			{
				float x = (float)_atlasIndex % AtlasDimensions.x / AtlasDimensions.x;
				float y = Mathf.Floor((float)_atlasIndex / AtlasDimensions.x) / AtlasDimensions.y;
				MaterialPropertyBlock materialPropertyBlock;
				if (AtlasColorable)
				{
					InitializeMatBlock();
					materialPropertyBlock = _matBlock;
				}
				else
				{
					materialPropertyBlock = new MaterialPropertyBlock();
				}
				materialPropertyBlock.SetVector("_Offset", new Vector4(x, y, 1f / AtlasDimensions.x, 1f / AtlasDimensions.y));
				AtlasObject.SetPropertyBlock(materialPropertyBlock);
			}
		}
	}

	public void Stylize(bool st)
	{
		if (st ^ _beingStylized)
		{
			_beingStylized = st;
			Furniture furniture;
			if ((object)(furniture = this as Furniture) != null)
			{
				furniture.RefreshEdgeDetection();
			}
		}
	}

	private void InitChangeCache()
	{
		for (int i = 0; i < 2; i++)
		{
			_edgeChangeCache[i] = null;
		}
		int num = 0;
		foreach (KeyValuePair<WallEdge, float> item in WallPosition)
		{
			_edgeChangeCache[num] = item.Key;
			num++;
			if (num >= 2)
			{
				break;
			}
		}
	}

	public virtual bool IsMerge(WallEdge e)
	{
		return false;
	}

	public virtual Room GetParentRoom(bool first)
	{
		return null;
	}

	public void Init(WallEdge edge1, WallEdge edge2, float pos, bool clone = false)
	{
		base.name = base.name.Replace("(Clone)", "");
		InitChangeCache();
		ClearConnections();
		FirstEdge = edge1;
		SecondEdge = edge2;
		Vector2 vector = edge2.Pos - edge1.Pos;
		float magnitude = vector.magnitude;
		WallPosition[edge1] = pos * magnitude;
		WallPosition[edge2] = (1f - pos) * magnitude;
		edge1.AddSegment(edge2, this);
		edge2.AddSegment(edge1, this);
		Vector2 vector2 = edge1.Pos + vector * pos;
		float y = base.transform.position.y;
		base.transform.SetPositionAndRotation(new Vector3(vector2.x, y, vector2.y), IsReversed ? Quaternion.LookRotation(new Vector3(vector.y, 0f, 0f - vector.x)) : Quaternion.LookRotation(new Vector3(0f - vector.y, 0f, vector.x)));
		if (CustomHeight)
		{
			WallHeight = y - (float)(Mathf.FloorToInt(y / 2f) * 2);
		}
		DirtyRoom(edge1.GetRoom(edge2));
		DirtyRoom(edge2.GetRoom(edge1));
		EdgeChanged(_edgeChangeCache, clone);
		Initialized();
	}

	public virtual void Initialized()
	{
	}

	public MeshFilter[] GetWallMeshes(bool inside, WallEdge edge)
	{
		return InsideWallMeshes;
	}

	public virtual bool PunchHole()
	{
		return true;
	}

	public virtual bool TowardsOutside()
	{
		return false;
	}

	private void DirtyRoom(Room r)
	{
		if (r != null)
		{
			r.DirtyOuterMesh = true;
			r.DirtyInnerMesh = true;
		}
	}

	public virtual bool EdgeChanged(WallEdge[] previous, bool clone)
	{
		return true;
	}

	public bool EdgeChanged(bool clone)
	{
		InitChangeCache();
		return EdgeChanged(_edgeChangeCache, clone);
	}

	public virtual bool ValidSnap(bool clone, HashSet<Room> destroy = null, bool keep = false)
	{
		return true;
	}

	private bool TrySnap(Room room, bool reversed, Vector2 pos, Vector2? forward)
	{
		bool result = false;
		for (int i = 0; i < room.Edges.Count; i++)
		{
			WallEdge wallEdge = room.Edges[i];
			WallEdge wallEdge2 = room.Edges[(i + 1) % room.Edges.Count];
			Vector2 res;
			if (Utilities.ProjectToLine(pos, wallEdge.Pos, wallEdge2.Pos, out res) && (res - pos).magnitude < 0.1f)
			{
				if (reversed)
				{
					WallEdge wallEdge3 = wallEdge;
					wallEdge = wallEdge2;
					wallEdge2 = wallEdge3;
				}
				Vector2 vector = Vector2.zero;
				if (forward.HasValue)
				{
					vector = (wallEdge.Pos - wallEdge2.Pos).normalized.Turn90();
				}
				if (!forward.HasValue || vector.Approximate(forward.Value, 0.001f) || (-vector).Approximate(forward.Value, 0.001f))
				{
					base.transform.position = new Vector3(0f, (float)(room.Floor * 2) + (CustomHeight ? WallHeight : 0f), 0f);
					Init(wallEdge, wallEdge2, (pos - wallEdge.Pos).magnitude / (wallEdge.Pos - wallEdge2.Pos).magnitude, DeserializeClone);
					DeserializeClone = false;
					result = true;
					break;
				}
			}
		}
		return result;
	}

	protected bool DeserializeSnap(WriteDictionary dictionary, Vector2? helpPos = null)
	{
		IsReversed = dictionary.Get("IsReversed", false);
		if (dictionary.Contains("WallSnapRoom"))
		{
			bool flag = dictionary.Get("Reversed", false);
			WallHeight = dictionary.Get("WallHeight", WallHeight);
			if (dictionary.Contains("WallSnapForcePos"))
			{
				uint roomID = (uint)dictionary["WallSnapRoom"];
				Vector2 vector = dictionary.Get("WallSnapForcePos", new SVector3(0f, 0f, 0f)).ToVector2();
				Room room = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.DID == roomID);
				Vector2? forward = null;
				SVector3 val;
				if (dictionary.TryGet<SVector3>("Rot", out val))
				{
					Vector2 vector2 = (val.ToQuaternion() * Vector3.forward).FlattenVector3();
					forward = vector2;
					vector2 *= 0.25f;
					int val2;
					if (room == null && dictionary.TryGet<int>("Floor", out val2))
					{
						room = GameSettings.Instance.sRoomManager.GetRoomFromPoint(val2, vector + vector2);
						Furniture furniture;
						if (room != null && room.Outside && (object)(furniture = this as Furniture) != null && furniture.ValidOutside)
						{
							IsReversed = true;
							flag = true;
							room = GameSettings.Instance.sRoomManager.GetRoomFromPoint(val2, vector - vector2);
						}
					}
				}
				if (!(room != null) || room.Edges == null)
				{
					DestroyGO();
					return false;
				}
				if (!TrySnap(room, flag, vector, forward) && room.IsUpperAtriumNotBalcony)
				{
					for (int num = 0; num < room.AtriumChildren.Count && !TrySnap(room.AtriumChildren[num], flag, vector, forward); num++)
					{
					}
				}
			}
			else
			{
				uint roomID2 = (uint)dictionary["WallSnapRoom"];
				int num2 = (int)dictionary["WallSnapIndex"];
				float pos = (float)dictionary["WallSnapPos"];
				Room room2 = GetDeserializedObject(roomID2) as Room;
				if (room2 == null && roomID2 != 0)
				{
					room2 = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.DID == roomID2);
				}
				if (room2 == null)
				{
					DestroyGO();
					return false;
				}
				if (num2 < 0 || num2 > room2.Edges.Count - 1)
				{
					if (helpPos.HasValue)
					{
						for (int num3 = 0; num3 < room2.Edges.Count; num3++)
						{
							WallEdge wallEdge = room2.Edges[num3];
							WallEdge wallEdge2 = room2.Edges[(num3 + 1) % room2.Edges.Count];
							Vector2 res;
							if (Utilities.ProjectToLine(helpPos.Value, wallEdge.Pos, wallEdge2.Pos, out res) && (res - helpPos.Value).sqrMagnitude < 0.0001f)
							{
								num2 = num3;
								pos = (wallEdge.Pos - helpPos.Value).magnitude;
								break;
							}
						}
					}
					if (num2 < 0 || num2 > room2.Edges.Count - 1)
					{
						DestroyGO();
						return false;
					}
				}
				WallEdge e1 = room2.Edges[num2];
				WallEdge wallEdge3 = e1.Links[room2];
				base.transform.position = new Vector3(0f, (float)(room2.Floor * 2) + (CustomHeight ? WallHeight : 0f), 0f);
				float num4 = pos / (e1.Pos - wallEdge3.Pos).magnitude;
				if (flag)
				{
					WallEdge wallEdge4 = e1;
					e1 = wallEdge3;
					wallEdge3 = wallEdge4;
					num4 = 1f - num4;
				}
				HashSet<WallSnap> value;
				if (e1.Children.TryGetValue(wallEdge3, out value) && value.FirstOrDefault((WallSnap x) => x.name.Equals(base.name) && x.FirstEdge == e1 && x.WallPosition[e1] == pos && x.WallHeight == WallHeight) != null)
				{
					DestroyGO();
					return false;
				}
				Init(e1, wallEdge3, num4, DeserializeClone);
				DeserializeClone = false;
			}
			return true;
		}
		Furniture furniture2 = this as Furniture;
		if (furniture2 != null)
		{
			Room room3 = furniture2.Parent ?? (GetDeserializedObject(dictionary.Get("Parent", 0u)) as Room);
			if (room3 != null)
			{
				List<WallEdge> edges = room3.Edges;
				Vector2 vector3 = furniture2.OriginalPosition.FlattenVector3();
				for (int num5 = 0; num5 < edges.Count; num5++)
				{
					WallEdge wallEdge5 = edges[num5];
					WallEdge wallEdge6 = edges[(num5 + 1) % edges.Count];
					Vector2 res2;
					if (Utilities.ProjectToLine(vector3, wallEdge5.Pos, wallEdge6.Pos, out res2) && (res2 - vector3).magnitude < 0.01f)
					{
						Init(wallEdge5, wallEdge6, (res2 - wallEdge5.Pos).magnitude / (wallEdge6.Pos - wallEdge5.Pos).magnitude, DeserializeClone);
						Debug.Log("WallFurn wasn't saved properly, but managed to fix: " + base.name, this);
						return true;
					}
				}
			}
		}
		DestroyGO();
		return false;
	}

	public void TryPlace(IList<WallEdge> edges)
	{
		bool flag = false;
		if (edges != null)
		{
			Vector2 vector = base.transform.position.FlattenVector3();
			Vector2 p = vector + base.transform.forward.FlattenVector3();
			for (int i = 0; i < edges.Count; i++)
			{
				WallEdge wallEdge = edges[i];
				foreach (WallEdge value in wallEdge.Links.Values)
				{
					Vector2 res;
					if (Utilities.ProjectToLine(vector, wallEdge.Pos, value.Pos, out res) && (res - vector).sqrMagnitude < 0.0001f)
					{
						WallEdge wallEdge2 = value;
						if (Utilities.IsLeft(wallEdge.Pos, value.Pos, p) < 0)
						{
							WallEdge wallEdge3 = wallEdge2;
							WallEdge wallEdge4 = wallEdge;
							wallEdge = wallEdge3;
							wallEdge2 = wallEdge4;
						}
						float pos = (vector - wallEdge.Pos).magnitude / (wallEdge2.Pos - wallEdge.Pos).magnitude;
						flag = true;
						Init(wallEdge, wallEdge2, pos);
						break;
					}
				}
			}
		}
		if (!flag)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public void PrepareTempSerialization()
	{
		if (WallPosition.Count <= 0)
		{
			return;
		}
		TempSnapReversed = false;
		WallEdge firstEdge = FirstEdge;
		WallEdge e2 = SecondEdge;
		IRoom key = firstEdge.Links.FirstOrDefault((KeyValuePair<IRoom, WallEdge> x) => x.Value == e2).Key;
		if (key == null)
		{
			WallEdge wallEdge = e2;
			e2 = firstEdge;
			firstEdge = wallEdge;
			key = firstEdge.Links.FirstOrDefault((KeyValuePair<IRoom, WallEdge> x) => x.Value == e2).Key;
			TempSnapReversed = true;
		}
		if (key == null)
		{
			Debug.LogException(new Exception("Failed saving a wall snapping object: " + base.name + " due to linking error"), this);
		}
		else
		{
			TempSnapRoom = key.GetUniqueID();
		}
	}

	protected void SerializeReplacement(WriteDictionary dictionary)
	{
		if (ReplacementGroups != null && ReplacementGroups.Length != 0)
		{
			dictionary["Replacements"] = Replacements;
		}
	}

	protected void DeserializeReplacement(WriteDictionary dictionary)
	{
		string[] array = dictionary.Get<string[]>("Replacements", null);
		if (array != null)
		{
			for (int i = 0; i < array.Length && i < 2; i++)
			{
				SetReplacement(i, array[i]);
			}
		}
	}

	protected void SerializeSnap(WriteDictionary dictionary)
	{
		dictionary["IsReversed"] = IsReversed;
		if (CustomHeight)
		{
			dictionary["WallHeight"] = WallHeight;
		}
		if (TempSnapRoom != 0)
		{
			dictionary["WallSnapRoom"] = TempSnapRoom;
			dictionary["WallSnapForcePos"] = (SVector3)base.transform.position.FlattenVector3();
			dictionary["Reversed"] = TempSnapReversed;
			TempSnapRoom = 0u;
		}
		else
		{
			if (WallPosition.Count <= 0)
			{
				return;
			}
			WallEdge wallEdge = FirstEdge;
			WallEdge secondEdge = SecondEdge;
			Room room = wallEdge.GetRoom(secondEdge);
			bool flag = false;
			if (room == null)
			{
				WallEdge wallEdge2 = secondEdge;
				secondEdge = wallEdge;
				wallEdge = wallEdge2;
				room = wallEdge.GetRoom(secondEdge);
				flag = true;
			}
			if (room == null)
			{
				Debug.LogException(new Exception("Failed saving a wall snapping object: " + base.name + " due to linking error"), this);
				DestroyGO();
				return;
			}
			int num = room.Edges.IndexOf(wallEdge);
			if (num == -1)
			{
				Debug.LogException(new Exception("Failed saving a wall snapping object: " + base.name + " due to linking error"), this);
				DestroyGO();
				return;
			}
			dictionary["WallSnapRoom"] = room.DID;
			dictionary["WallSnapIndex"] = num;
			dictionary["WallSnapPos"] = WallPosition[wallEdge];
			dictionary["Reversed"] = flag;
		}
	}

	public bool GetAgainstExterior()
	{
		if (SecondEdge == null)
		{
			return false;
		}
		if (!FirstEdge.IsAgainstOutdoors(SecondEdge) && SecondEdge.Links.ContainsValue(FirstEdge))
		{
			return !FirstEdge.Links.ContainsValue(SecondEdge);
		}
		return true;
	}

	public IRoom GetPrimarySaveRoom()
	{
		IRoom iRoom = FirstEdge.GetIRoom(SecondEdge);
		if (iRoom != null && iRoom.Outdoors)
		{
			IRoom iRoom2 = SecondEdge.GetIRoom(FirstEdge);
			if (iRoom2 == null || iRoom2.Outdoors)
			{
				return iRoom;
			}
			return iRoom2;
		}
		return iRoom;
	}

	public Room GetPrimaryRoom()
	{
		WallEdge firstEdge = FirstEdge;
		if (firstEdge == null)
		{
			return null;
		}
		return firstEdge.GetRoom(SecondEdge);
	}

	public Room GetSecondaryRoom()
	{
		return SecondEdge.GetRoom(FirstEdge);
	}

	protected void ClearConnections()
	{
		foreach (KeyValuePair<WallEdge, float> item in WallPosition)
		{
			foreach (KeyValuePair<WallEdge, HashSet<WallSnap>> child in item.Key.Children)
			{
				child.Value.Remove(this);
			}
		}
		WallPosition.Clear();
	}

	public override int GetFloor()
	{
		if (FirstEdge == null)
		{
			return 0;
		}
		return FirstEdge.Floor;
	}

	public override Vector2 GetFlatPos()
	{
		return base.transform.position.FlattenVector3();
	}

	public float GetValidHeight(int up)
	{
		if (up <= 0)
		{
			if (ValidHeights == null || ValidHeights.Length == 0)
			{
				return 0f;
			}
			return ValidHeights[ValidHeights.Length - 1];
		}
		if (ValidHeights == null || ValidHeights.Length == 0)
		{
			return 2f;
		}
		return ValidHeights[0];
	}

	public virtual bool IsOnSide(WallEdge w)
	{
		return true;
	}

	public virtual void ToggleDoors(bool open, bool keepOpen, bool force = false)
	{
	}

	public void TurnOffColor(bool off2, bool off3)
	{
		if (TurnOffSecondaryColor != off2 || TurnOffTertiaryColor != off3)
		{
			TurnOffSecondaryColor = off2;
			TurnOffTertiaryColor = off3;
			UpdateMaterials();
		}
	}

	public void InitColors()
	{
		_colorPrimary = ColorPrimaryDefault;
		_colorSecondary = ColorSecondaryDefault;
		_colorTertiary = ColorTertiaryDefault;
	}

	public void UpdateMaterials()
	{
		if (Colorable.Count > 0)
		{
			InitializeMatBlock();
			_matBlock.SetColor("_Color1", ColorPrimary);
			_matBlock.SetColor("_Color2", ColorSecondary);
			_matBlock.SetColor("_Color3", ColorTertiary);
			for (int i = 0; i < Colorable.Count; i++)
			{
				Colorable[i].SetPropertyBlock(_matBlock);
			}
		}
		for (int j = 0; j < ColorableLights.Count; j++)
		{
			ColorableLights[j].color = (LightPrimary ? ColorPrimary : ColorTertiary);
		}
	}

	public MaterialPropertyBlock GetBlock()
	{
		InitializeMatBlock();
		return _matBlock;
	}

	protected virtual void InitializeMatBlock()
	{
		if (_matBlock == null)
		{
			_matBlock = new MaterialPropertyBlock();
		}
	}

	public virtual bool IsActuallyPlayerControlled()
	{
		return true;
	}

	public virtual bool IsCustomizable()
	{
		if (AtlasObject != null)
		{
			return true;
		}
		if (Colorable.Count > 0 || ColorableLights.Count > 0)
		{
			return ColorEditEnabled;
		}
		return false;
	}

	private int GetRandomAtlas(ref int last)
	{
		int num = AtlasCount / AtlasSkip;
		return (last = (last + UnityEngine.Random.Range(1, num)) % num) * AtlasSkip + AtlasOff;
	}

	public void InitAtlas()
	{
		int atlasIndex = _atlasIndex;
		_atlasIndex = -1;
		if (!GameSettings.Instance.IsReferenceNull() && IsCustomizable() && MaterialPreviewer.Instance.gameObject.activeSelf && MaterialPreviewer.Instance.CurrentPrefab != null && MaterialPreviewer.Instance.CurrentPrefab.name.Equals(base.name))
		{
			IStyle activeStyle = MaterialPreviewer.Instance.GetActiveStyle();
			activeStyle.Apply(this, null);
			if (AtlasObject != null)
			{
				FurnitureStyle furnitureStyle;
				atlasIndex = (((furnitureStyle = activeStyle as FurnitureStyle) != null && furnitureStyle.AtlasIndex >= 0) ? furnitureStyle.AtlasIndex : ((!MaterialPreviewer.Instance.RandomizeStyle.gameObject.activeSelf || !MaterialPreviewer.Instance.RandomizeStyle.isOn) ? MaterialPreviewer.Instance.GetActiveAtlas() : GetRandomAtlas(ref MaterialPreviewer.Instance.LastRandom)));
			}
		}
		AtlasIndex = atlasIndex;
	}

	public void ApplyMaterialPickerStyle()
	{
		if (IsCustomizable() && MaterialPreviewer.Instance.gameObject.activeSelf && MaterialPreviewer.Instance.CurrentPrefab != null && MaterialPreviewer.Instance.CurrentPrefab.name.Equals(base.name.Replace("(Clone)", "")))
		{
			IStyle activeStyle = MaterialPreviewer.Instance.GetActiveStyle();
			activeStyle.Apply(this, null);
			if (AtlasObject != null)
			{
				FurnitureStyle furnitureStyle;
				if ((furnitureStyle = activeStyle as FurnitureStyle) != null && furnitureStyle.AtlasIndex >= 0)
				{
					AtlasIndex = furnitureStyle.AtlasIndex;
				}
				else if (MaterialPreviewer.Instance.RandomizeStyle.gameObject.activeSelf && MaterialPreviewer.Instance.RandomizeStyle.isOn)
				{
					AtlasIndex = GetRandomAtlas(ref MaterialPreviewer.Instance.LastRandom);
				}
				else
				{
					AtlasIndex = MaterialPreviewer.Instance.GetActiveAtlas();
				}
			}
		}
		if (Colorable.Count > 0)
		{
			UpdateMaterials();
		}
	}

	public virtual string GetLocalizationName()
	{
		return base.name;
	}

	public virtual string GetActualString()
	{
		return Localization.GetFurniture(GetLocalizationName(), base.name, null)[0];
	}

	public override IStyle GetStyle()
	{
		return new FurnitureStyle(this, false);
	}

	public string GetReplacement(int index)
	{
		UserImageFrame component;
		if (index == 1 && this.TryGetComponent<UserImageFrame>(out component))
		{
			return component.ImageName;
		}
		HardwareDesignFurn component2;
		if (this.TryGetComponent<HardwareDesignFurn>(out component2))
		{
			return ((index == 0) ? component2.ProductID : component2.AddonID).ToString();
		}
		if (Replacements != null && index < Replacements.Length)
		{
			return Replacements[index];
		}
		return null;
	}

	public void SetReplacement(string group, string key)
	{
		int num = ReplacementGroups.FindIndex(group);
		if (num != -1)
		{
			SetReplacement(num, key);
		}
	}

	public void SetReplacement(int idx, string key)
	{
		ObjectDatabase.ReplacementGroup group;
		ObjectDatabase.ReplacementObject o;
		if (ReplacementGroups == null || idx >= ReplacementGroups.Length || string.IsNullOrEmpty(key) || !ObjectDatabase.Instance.GetReplacementGroup(ReplacementGroups[idx], out group) || !group.GetReplacement(key, out o))
		{
			return;
		}
		Replacements[idx] = key;
		for (int i = 0; i < ReplacementMeshes.Length; i++)
		{
			ReplacementMesh replacementMesh = ReplacementMeshes[i];
			ValueTuple<Mesh, Mesh, Mesh> meshes;
			if (o.GetMesh(replacementMesh.ReplacementName, out meshes))
			{
				replacementMesh.MF.sharedMesh = meshes.Item1;
				if (replacementMesh.HasLOD)
				{
					replacementMesh.LOD.LOD0 = meshes.Item1;
					replacementMesh.LOD.LOD1 = meshes.Item2;
					replacementMesh.LOD.LOD2 = meshes.Item3;
					replacementMesh.LOD.Mat0 = (replacementMesh.LOD.Mat1 = (replacementMesh.LOD.Mat2 = o.Material));
				}
				else
				{
					replacementMesh.MF.sharedMesh = meshes.Item1;
				}
				if (ReplacementMeshes[i].ReplaceMaterial)
				{
					replacementMesh.MR.sharedMaterial = o.Material;
				}
			}
		}
	}

	public override void ApplyNetworkStyle(string material, string material2, Color c, Color c2, Color c3, Color c4, int atlasIndex)
	{
		if (ColorPrimaryEnabled)
		{
			ColorPrimary = c;
		}
		if (ColorSecondaryEnabled)
		{
			ColorSecondary = c2;
		}
		if (ColorTertiaryEnabled)
		{
			ColorTertiary = c3;
		}
		AtlasIndex = atlasIndex;
	}

	public void RemoveFromWallEdges()
	{
		if (FirstEdge != null && SecondEdge != null)
		{
			HashSet<WallSnap> value;
			if (FirstEdge.Children.TryGetValue(SecondEdge, out value))
			{
				value.Remove(this);
			}
			HashSet<WallSnap> value2;
			if (SecondEdge.Children.TryGetValue(FirstEdge, out value2))
			{
				value2.Remove(this);
			}
		}
	}
}
