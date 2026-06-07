using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Video;

public class ObjectDatabase : ScriptableObject
{
	[Serializable]
	public struct ReplacementKey
	{
		public string Key;

		public Mesh Mesh;

		public Mesh LOD1;

		public Mesh LOD2;
	}

	[Serializable]
	public struct ReplacementObject
	{
		public string Name;

		public List<ReplacementKey> Keys;

		public Material Material;

		public Texture2D AlbedoThumb;

		public Sprite Thumbnail;

		[NonSerialized]
		private Dictionary<string, ValueTuple<Mesh, Mesh, Mesh>> _map;

		public bool GetMesh(string key, [TupleElementNames(new string[] { "m", "m1", "m2" })] out ValueTuple<Mesh, Mesh, Mesh> meshes)
		{
			if (_map == null)
			{
				_map = Keys.ToDictionary((ReplacementKey x) => x.Key, [return: TupleElementNames(new string[] { "Mesh", "LOD1", "LOD2" })] (ReplacementKey x) => new ValueTuple<Mesh, Mesh, Mesh>(x.Mesh, x.LOD1, x.LOD2));
			}
			return _map.TryGetValue(key, out meshes);
		}
	}

	[Serializable]
	public struct ReplacementGroup
	{
		public string Name;

		public List<ReplacementObject> Replacements;

		[NonSerialized]
		private Dictionary<string, ReplacementObject> _map;

		public bool GetReplacement(string key, out ReplacementObject o)
		{
			if (_map == null)
			{
				_map = Replacements.ToDictionary((ReplacementObject x) => x.Name, (ReplacementObject x) => x);
			}
			return _map.TryGetValue(key, out o);
		}
	}

	[Serializable]
	public struct IconObject
	{
		public string Name;

		public Sprite Icon;

		public IconObject(string name, Sprite icon)
		{
			Name = name;
			Icon = icon;
		}
	}

	[Serializable]
	public struct FenceStyle
	{
		public string Name;

		public Mesh Pole;

		public Mesh Fence;

		public Material Mat;

		public Material FenceMat;

		public Texture Thumbnail;

		public Texture ThumbnailBump;

		public Texture ThumbnailExtra;

		public float Height;
	}

	[Serializable]
	public struct CursorSprite
	{
		public string Name;

		public Texture2D Cursor;

		public Vector2 HotStop;
	}

	[Serializable]
	public struct Language
	{
		public string Name;

		public Sprite Flag;
	}

	[Serializable]
	public struct AwardThumb
	{
		public Sprite[] Thumbs;
	}

	public Font DefaultFont;

	[SerializeField]
	private List<GameObject> Furniture;

	public List<GameObject> RoomSegments;

	public List<FenceStyle> FenceStyles;

	public StaticTree[] Trees;

	public WeatherPreset[] WeatherPresets;

	public EnvironmentPreset[] EnvironmentPresets;

	public HardwareDesign[] BuiltInHardwareDesigns;

	public Material CombineFurnitureMaterial;

	public Material AtlasFurnitureMaterial;

	public Material[] ModMats;

	public Material HardwareAtlasMaterial;

	public Material HardwareDesignMaterial;

	public Material GlassMaterial;

	public Sprite PlaceholderTrait;

	public Sprite[] AllTraits;

	public Sprite[] ReviewCompanies;

	public Sprite ActiveWindow;

	public Sprite InactiveWindow;

	public Texture2D DefaultUserImage;

	public Material UserImageMaterial;

	public CarScript[] CarPrefabs;

	public AwardThumb[] AwardThumbnails;

	public CursorSprite[] Cursors;

	public Sprite DefaultFlag;

	public Language[] Languages;

	public IconObject[] IconObjects;

	public List<RoomStyle> MainMenuRoomStyles = new List<RoomStyle>();

	public GUIColumn ColumnPrefab;

	public GUIColumn FilterColumnPrefab;

	public GUIColumn QueryColumnPrefab;

	public GameObject BodyShadow;

	public Material PanelBack;

	public List<ConferenceBooth.Booth> Booths = new List<ConferenceBooth.Booth>();

	public List<ReplacementGroup> ReplacementGroups = new List<ReplacementGroup>();

	[NonSerialized]
	public Dictionary<string, CursorSprite> CursorSprites = new Dictionary<string, CursorSprite>();

	[NonSerialized]
	private Dictionary<string, Sprite> _allIcons;

	[NonSerialized]
	private Dictionary<string, Sprite> _reviewCompanies;

	[NonSerialized]
	private Dictionary<string, GameObject> _furns;

	[NonSerialized]
	private Dictionary<string, Furniture> _furnCs;

	[NonSerialized]
	private Dictionary<string, RoomSegment> _segments;

	[NonSerialized]
	private Dictionary<string, ReplacementGroup> _replacements;

	[NonSerialized]
	public Dictionary<string, ReplacementGroup> ModdedReplacements = new Dictionary<string, ReplacementGroup>();

	[NonSerialized]
	public Dictionary<string, Sprite> Flags;

	public List<Material> FurnMatTypes;

	[NonSerialized]
	public Dictionary<string, Material> FurnitureMaterialTypes = new Dictionary<string, Material>();

	public Sprite[] UIBorderSprites;

	[NonSerialized]
	private HashSet<Sprite> _borderSpites;

	[NonSerialized]
	public Dictionary<string, Texture2D> TutorialPicDic;

	[NonSerialized]
	public Dictionary<string, VideoClip> TutorialVidDic;

	[NonSerialized]
	public Dictionary<string, HardwareDesign> HardwareDesigns;

	[NonSerialized]
	private Dictionary<Employee.Trait, Sprite> _traitSprites;

	[NonSerialized]
	private Dictionary<string, HashSet<string>> _furnitureReplacables = new Dictionary<string, HashSet<string>>();

	[NonSerialized]
	private bool _furnitureReplacableDirty = true;

	private static string _lastCursor;

	public int DirtAtlasSize;

	public Vector2Int[] DirtTypes;

	public int[] DirtSubmesh;

	public float[] DirtScale;

	private static bool _bound;

	private static ObjectDatabase _instance;

	public Texture2D[] DefaultManufacuringSprites;

	private List<ValueTuple<int, float>> _serverPriceCache = new List<ValueTuple<int, float>>();

	public static ObjectDatabase Instance
	{
		get
		{
			if (!_bound)
			{
				_instance = UnityEngine.Object.Instantiate(Resources.Load<ObjectDatabase>("ObjectDatabaseInstance"));
				_bound = true;
			}
			return _instance;
		}
	}

	public float GetDirtScale(int idx)
	{
		idx = Mathf.Clamp(idx, 0, DirtScale.Length - 1);
		return DirtScale[idx];
	}

	public HashSet<string> GetReplacables(string furniture)
	{
		if (_furnitureReplacableDirty)
		{
			UpdateFurnitureReplacables();
			_furnitureReplacableDirty = false;
		}
		return _furnitureReplacables.GetOrNull(furniture);
	}

	public bool CurrentlyValidFurnitureReplacement(string r)
	{
		Furniture furnitureComponent = GetFurnitureComponent(r);
		if (furnitureComponent != null && furnitureComponent.IsUnlocked() && furnitureComponent.IsPurchasable())
		{
			return furnitureComponent.Queryable();
		}
		return false;
	}

	private void UpdateFurnitureReplacables()
	{
		_furnitureReplacables.Clear();
		IEnumerable<IGrouping<string, Furniture>> enumerable = from x in GetAllFurnitureComponents()
			where !string.IsNullOrWhiteSpace(x.UpgradeTo)
			group x by x.UpgradeTo;
		List<Furniture> list = new List<Furniture>();
		foreach (IGrouping<string, Furniture> item in enumerable)
		{
			list.Clear();
			list.AddRange(item);
			for (int num = 0; num < list.Count; num++)
			{
				Furniture furniture = list[num];
				if (!furniture.BlueprintReplaceable || furniture.IsConstructionFurniture())
				{
					continue;
				}
				for (int num2 = num + 1; num2 < list.Count; num2++)
				{
					Furniture furniture2 = list[num2];
					if (furniture2.BlueprintReplaceable && !furniture2.IsConstructionFurniture())
					{
						if (CanReplaceDirectly(furniture, furniture2))
						{
							_furnitureReplacables.Append(furniture.name, furniture2.name);
						}
						if (CanReplaceDirectly(furniture2, furniture))
						{
							_furnitureReplacables.Append(furniture2.name, furniture.name);
						}
					}
				}
			}
		}
	}

	public Furniture GetOptimalReplacement(Furniture furn)
	{
		if (furn.BlueprintUpgradeFrom)
		{
			HashSet<string> replacables = GetReplacables(furn.name);
			if (replacables != null)
			{
				int num = -1;
				Furniture result = null;
				{
					foreach (string item in replacables)
					{
						Furniture furnitureComponent = GetFurnitureComponent(item);
						if (furnitureComponent != null && furnitureComponent != furn && furnitureComponent.BlueprintUpgradeTo && furnitureComponent.UnlockYear > num && furnitureComponent.IsUnlocked() && furnitureComponent.IsPurchasable() && furnitureComponent.Queryable())
						{
							num = furnitureComponent.UnlockYear;
							result = furnitureComponent;
						}
					}
					return result;
				}
			}
		}
		return null;
	}

	private bool CanReplaceDirectly(Furniture a, Furniture b)
	{
		if ((a.ValidOutdoors && !b.ValidOutdoors) || (a.ValidIndoors && !b.ValidIndoors) || (a.ValidOutside && !b.ValidOutside))
		{
			return false;
		}
		if (!a.Type.Equals(b.Type))
		{
			return false;
		}
		if (a.SnapsTo != null && a.SnapsTo.Length != 0)
		{
			if (b.SnapsTo == null || a.SnapsTo.Any((string x) => !b.SnapsTo.Contains(x)))
			{
				return false;
			}
		}
		else if (b.SnapsTo != null && b.SnapsTo.Length != 0)
		{
			return false;
		}
		bool flag = false;
		if (a.WallFurn)
		{
			if (!b.WallFurn)
			{
				return false;
			}
			if (b.WallWidth > a.WallWidth)
			{
				return false;
			}
			flag = true;
		}
		if (b.BuildBoundary != null && b.BuildBoundary.Length != 0)
		{
			if (a.BuildBoundary == null || a.BuildBoundary.Length == 0)
			{
				return false;
			}
			flag = true;
			if (!FitsInside(a, b))
			{
				return false;
			}
		}
		if (flag && (b.Height1 < a.Height1 || b.Height2 > a.Height2))
		{
			return false;
		}
		if (a.SnapsTo != null && a.SnapPoints.Length != 0)
		{
			if (b.SnapsTo == null || b.SnapPoints.Length < a.SnapPoints.Length)
			{
				return false;
			}
			for (int num = 0; num < a.SnapPoints.Length; num++)
			{
				SnapPoint snapPoint = a.SnapPoints[num];
				SnapPoint snapPoint2 = b.SnapPoints[num];
				if (!snapPoint2.Name.Equals(snapPoint.Name) || (snapPoint2.CheckValid && ((double)(snapPoint2.transform.position - snapPoint.transform.position).sqrMagnitude > 0.001 || Mathf.Abs(Quaternion.Angle(snapPoint.transform.rotation, snapPoint2.transform.rotation)) > 1f)))
				{
					return false;
				}
			}
		}
		return true;
	}

	private bool FitsInside(Furniture a, Furniture b)
	{
		for (int i = 0; i < b.BuildBoundary.Length; i++)
		{
			if (!Utilities.IsInside(b.BuildBoundary[i], a.BuildBoundary, -0.01f))
			{
				return false;
			}
		}
		return true;
	}

	[ContextMenu("Save room styles")]
	public void SaveStyles()
	{
		MainMenuRoomStyles.AddRange(GameSettings.Instance.RoomStyles);
	}

	public GUIColumn GetColumnPrefab(GUIListView.FilterType filter)
	{
		switch (filter)
		{
		case GUIListView.FilterType.Query:
			return QueryColumnPrefab;
		case GUIListView.FilterType.None:
			return ColumnPrefab;
		default:
			return FilterColumnPrefab;
		}
	}

	public Sprite TryGetFlag(string input, string forcedValue = null)
	{
		Sprite value;
		if (forcedValue != null && Flags.TryGetValue(forcedValue.ToLower(), out value))
		{
			return value;
		}
		input = input.ToLower();
		if (Flags.TryGetValue(input, out value))
		{
			return value;
		}
		int num = input.IndexOf(' ');
		if (num > 0 && Flags.TryGetValue(input.Substring(0, num), out value))
		{
			return value;
		}
		return DefaultFlag;
	}

	public Sprite GetAwardSprite(AwardTrophy.AwardData a)
	{
		return GetAwardSprite(a.Type, a.Tier);
	}

	public Sprite GetAwardSprite(AwardTrophy.AwardType type, AwardTrophy.AwardTier tier)
	{
		return AwardThumbnails[(int)type].Thumbs[(int)tier];
	}

	public bool GetReplacementGroup(string key, out ReplacementGroup group)
	{
		if (!_replacements.TryGetValue(key, out group))
		{
			return ModdedReplacements.TryGetValue(key, out group);
		}
		return true;
	}

	public HashSet<string> GetReplacementGroups()
	{
		HashSet<string> hashSet = _replacements.Keys.ToHashSet();
		hashSet.AddRange(ModdedReplacements.Keys);
		return hashSet;
	}

	public Sprite GetReviewCompany(string thumb)
	{
		return _reviewCompanies.GetOrDefault(thumb, ReviewCompanies[0]);
	}

	public Sprite GetTrait(Employee.Trait t)
	{
		return _traitSprites.GetOrDefault(t, PlaceholderTrait);
	}

	public bool IsValidBorderSprite(Sprite spr)
	{
		if (_borderSpites == null)
		{
			_borderSpites = UIBorderSprites.Where((Sprite x) => x != null).ToHashSet();
		}
		if (!(spr == null))
		{
			return _borderSpites.Contains(spr);
		}
		return true;
	}

	public Sprite GetSprite(bool topRight, bool bottomRight, bool bottomLeft, bool topLeft)
	{
		int num = 0;
		if (topRight)
		{
			num |= 1;
		}
		if (bottomRight)
		{
			num |= 2;
		}
		if (bottomLeft)
		{
			num |= 4;
		}
		if (topLeft)
		{
			num |= 8;
		}
		if (num == 0)
		{
			return null;
		}
		return UIBorderSprites[num - 1];
	}

	public GameObject GetFurniture(string name)
	{
		if (name != null)
		{
			return _furns.GetOrNull(name);
		}
		return null;
	}

	public GameObject GetFurnitureNoCase(string name)
	{
		return _furns.FirstOrDefaultOf((KeyValuePair<string, GameObject> x) => x.Key.ToLower().Equals(name), (KeyValuePair<string, GameObject> x) => x.Value);
	}

	public List<Furniture> GetUpgrades(string group)
	{
		return _furnCs.Values.Where((Furniture x) => x.UpgradeCompatible(group)).ToList();
	}

	public List<Furniture> GetUpgrades(string group, IList<Furniture> fs)
	{
		return _furnCs.Values.Where((Furniture x) => x.UpgradeCompatible(group, fs)).ToList();
	}

	public Furniture GetFurnitureComponent(string name)
	{
		if (name != null)
		{
			return _furnCs.GetOrNull(name);
		}
		return null;
	}

	public RoomSegment GetSegmentComponent(string name)
	{
		if (name != null)
		{
			return _segments.GetOrNull(name);
		}
		return null;
	}

	public List<GameObject> GetAllFurniture()
	{
		return Furniture;
	}

	public IEnumerable<Furniture> GetAllFurnitureComponents()
	{
		return _furnCs.Values;
	}

	public void AddFurniture(GameObject obj)
	{
		Furniture.Add(obj);
		_furns.Add(obj.name, obj);
		Furniture component = obj.GetComponent<Furniture>();
		_furnCs.Add(obj.name, component);
		if (component.Type.Equals("Server"))
		{
			CacheServerPrices();
		}
		_furnitureReplacableDirty = true;
	}

	public void AddFencestyle(FenceStyle style)
	{
		FenceStyles.Add(style);
	}

	public void AddSegment(GameObject obj)
	{
		RoomSegments.Add(obj);
		_segments.Add(obj.name, obj.GetComponent<RoomSegment>());
	}

	public void RemoveSegment(GameObject obj)
	{
		RoomSegments.Remove(obj);
		_segments.Remove(obj.name);
	}

	public void RemoveFurniture(GameObject furn)
	{
		Furniture.Remove(furn);
		Furniture value;
		if (_furnCs.TryGetValue(furn.name, out value))
		{
			_furnCs.Remove(furn.name);
			if (value.Type.Equals("Server"))
			{
				CacheServerPrices();
			}
		}
		_furns.Remove(furn.name);
		_furnitureReplacableDirty = true;
	}

	private void OnEnable()
	{
		Shader.SetGlobalFloat("_SupportHeightCutoff", 1000f);
		_furns = Furniture.ToDictionary((GameObject x) => x.name, (GameObject x) => x);
		_furnCs = Furniture.ToDictionary((GameObject x) => x.name, (GameObject x) => x.GetComponent<Furniture>());
		_segments = RoomSegments.ToDictionary((GameObject x) => x.name, (GameObject x) => x.GetComponent<RoomSegment>());
		FurnitureMaterialTypes = FurnMatTypes.ToDictionary((Material x) => x.name, (Material x) => x);
		TutorialPicDic = Resources.LoadAll<Texture2D>("Tutorial Assets/").ToDictionary((Texture2D x) => x.name, (Texture2D x) => x);
		TutorialVidDic = Resources.LoadAll<VideoClip>("Tutorial Assets/").ToDictionary((VideoClip x) => x.name, (VideoClip x) => x);
		HardwareDesigns = BuiltInHardwareDesigns.ToDictionary((HardwareDesign x) => x.ID, (HardwareDesign x) => x);
		Flags = Languages.ToDictionary((Language x) => x.Name.ToLower(), (Language x) => x.Flag);
		_allIcons = new Dictionary<string, Sprite>();
		for (int num = 0; num < IconObjects.Length; num++)
		{
			_allIcons.Add(IconObjects[num].Name, IconObjects[num].Icon);
		}
		_traitSprites = new Dictionary<Employee.Trait, Sprite>();
		for (int num2 = 0; num2 < AllTraits.Length; num2++)
		{
			if (AllTraits[num2] != null)
			{
				Employee.Trait key = (Employee.Trait)(1L << num2);
				_traitSprites[key] = AllTraits[num2];
			}
		}
		_reviewCompanies = ReviewCompanies.ToDictionary((Sprite x) => x.name, (Sprite x) => x);
		CursorSprites = Cursors.ToDictionary((CursorSprite x) => x.Name, (CursorSprite x) => x);
		_replacements = ReplacementGroups.ToDictionary((ReplacementGroup x) => x.Name, (ReplacementGroup x) => x);
		CacheServerPrices();
	}

	public void SetCursor(string c)
	{
		c = (Options.CustomCursor ? c : null);
		bool flag = Input.GetMouseButton(0) || Input.GetMouseButton(1);
		if ("Finger".Equals(c) && flag)
		{
			c = "FingerDown";
		}
		if ("Default".Equals(c) && flag)
		{
			c = "DefaultDown";
		}
		if ("Grab".Equals(c) && flag)
		{
			c = "GrabClosed";
		}
		if (c == null)
		{
			if (_lastCursor == null)
			{
				return;
			}
		}
		else if (c.Equals(_lastCursor))
		{
			return;
		}
		CursorSprite value;
		if (c == null)
		{
			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		}
		else if (CursorSprites.TryGetValue(c, out value))
		{
			_lastCursor = c;
			Cursor.SetCursor(value.Cursor, value.HotStop, CursorMode.Auto);
		}
	}

	public static IEnumerable<Sprite> GetAllIcons()
	{
		return Instance._allIcons.Values;
	}

	public static Sprite GetIcon(string name, bool allowEmpty = false)
	{
		if (allowEmpty)
		{
			return Instance._allIcons.GetOrDefault(name);
		}
		Sprite value;
		if (Instance._allIcons.TryGetValue(name, out value))
		{
			return value;
		}
		throw new Exception("Trying to get non-existent icon: " + name);
	}

	private void CacheServerPrices()
	{
		Dictionary<int, float> dictionary = null;
		foreach (Furniture value2 in _furnCs.Values)
		{
			if (!"Server".Equals(value2.Type))
			{
				continue;
			}
			float num = value2.Wattage / value2.GetComponent<Server>().Power;
			if (!(num < 4f))
			{
				continue;
			}
			if (dictionary == null)
			{
				dictionary = new Dictionary<int, float>();
			}
			float value;
			if (dictionary.TryGetValue(value2.UnlockYear, out value))
			{
				if (num < value)
				{
					dictionary[value2.UnlockYear] = num;
				}
			}
			else
			{
				dictionary[value2.UnlockYear] = num;
			}
		}
		_serverPriceCache.Clear();
		_serverPriceCache.Add(new ValueTuple<int, float>(0, 4f));
		float num2 = 4f;
		if (dictionary == null)
		{
			return;
		}
		foreach (KeyValuePair<int, float> item in dictionary.OrderBy((KeyValuePair<int, float> x) => x.Key))
		{
			if (item.Value < num2)
			{
				_serverPriceCache.Add(new ValueTuple<int, float>(item.Key, item.Value));
				num2 = item.Value;
			}
		}
	}

	public float CheapestServer()
	{
		int num = TimeOfDay.Instance.Year + 1900;
		float num2 = 4f;
		for (int i = 0; i < _serverPriceCache.Count; i++)
		{
			ValueTuple<int, float> valueTuple = _serverPriceCache[i];
			if (valueTuple.Item1 > num)
			{
				break;
			}
			num2 = valueTuple.Item2;
		}
		return num2 * 0.03f * global::Furniture.GetElectricityPrice();
	}

	private void OnDestroy()
	{
		_bound = false;
	}

	public static bool SetWallCullingDistance(Furniture f)
	{
		float num = 0f;
		if (f.MeshBoundary != null)
		{
			Rect bounds = ((IList<Vector2>)f.MeshBoundary).GetBounds();
			num = Mathf.Max(0f, Mathf.Max(bounds.width, bounds.height) / 2f - 0.5f);
			if (num < 0.01f)
			{
				num = 0f;
			}
		}
		if (num != f.WallCullingDistance)
		{
			f.WallCullingDistance = num;
			return true;
		}
		return false;
	}
}
