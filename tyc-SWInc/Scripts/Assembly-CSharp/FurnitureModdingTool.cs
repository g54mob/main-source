using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using DevConsole;
using Steamworks;
using Tyd;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FurnitureModdingTool : MonoBehaviour
{
	public static FurnitureModdingTool Instance;

	public ThumbCam CamTool;

	public GameObject ActiveObject;

	public GameObject MainPanel;

	public GameObject LaunchPanelObj;

	public GameObject AtlasLabel;

	public GameObject AddFurnButton;

	public GameObject BoundsPanel;

	public GameObject ButtonPanel;

	public GameObject EditPanel;

	public GameObject ButtonPrefab;

	public SimpleDrop DropPrefab;

	public WallSnap ActivePrefab;

	public GameObject SnapOnTemp;

	public Image Thumb;

	public Material OutlineMat;

	public Slider LODSlider;

	public Slider AtlasSlider;

	public Toggle LODToggle;

	public Toggle SnapFurnToggle;

	public Text LODLabel;

	public Text InspectorHeader;

	public RectTransform ComponentPanel;

	public RectTransform ObjectPanel;

	public RectTransform LaunchPanel;

	public Text CompLabelPrefab;

	public FurnitureBoundDrawer BoundaryDrawer;

	public BoundaryPointEditor BoundaryEditor;

	public Slider SliderInputPrefab;

	public InputField CompInputPrefab;

	public GameObject ThreeInputPrefab;

	public GameObject ToggleButtonPrefab;

	public GameObject ArrayPanelPrefab;

	public GameObject CompInputSugPrefab;

	public GameObject FStylePrefab;

	public Toggle ToggleInputPrefab;

	public GUICombobox ComboPrefab;

	public Button ObjectButtonPrefab;

	public List<FurnModMeta> CurrentMeta = new List<FurnModMeta>();

	public FurnModMeta ActiveMeta;

	public TransformGizmo CurrentGizmo;

	public Mesh Circle;

	public Mesh Arrow;

	public Mesh ScaleArrow;

	public Material GizmoMat;

	public Camera MainCam;

	public Toggle MoveToggle;

	public Toggle RotateToggle;

	public Toggle ScaleToggle;

	public Toggle GlobalToggle;

	public Toggle PivotToggle;

	[NonSerialized]
	public FurnitureMod ActiveMod;

	[NonSerialized]
	public Dictionary<FurnModMeta, GameObject> MetaButtons = new Dictionary<FurnModMeta, GameObject>();

	[NonSerialized]
	public Dictionary<string, SimpleDrop> MetaDrops = new Dictionary<string, SimpleDrop>();

	private Dictionary<FieldInfo, GameObject> _inspectorElements = new Dictionary<FieldInfo, GameObject>();

	private Dictionary<FieldInfo, SimpleDrop> _inspectorHeaders = new Dictionary<FieldInfo, SimpleDrop>();

	public ActorPortrait DummyActor;

	public Animator DummyAnimator;

	public List<Material> Materials = new List<Material>();

	public List<Mesh> Meshes = new List<Mesh>();

	public List<Texture2D> Textures = new List<Texture2D>();

	public Dictionary<WallSnap, GameObject> Buttons = new Dictionary<WallSnap, GameObject>();

	public bool InterDeleted;

	public bool SnapDeleted;

	public bool IsNew;

	public ParticleSystem SmokeSystem;

	public Transform IssuePanel;

	public GameObject IssuePrefab;

	public GameObject IssueMainPanel;

	public Material TileMat;

	public List<MeshFilter> _tempCutouts = new List<MeshFilter>();

	public DoorScript ActiveHinge;

	public Transform[] DoorTags;

	public List<GameObject> ValidForFurniture;

	public List<GameObject> ValidForSegment;

	public static List<Type> ValidGenericTypes = new List<Type>
	{
		typeof(TrashCan),
		typeof(FurnLoadScript),
		typeof(Server),
		typeof(ProductPrinter),
		typeof(Conveyor),
		typeof(Battery),
		typeof(WindTurbine),
		typeof(UserImageFrame)
	};

	private static List<ValueTuple<string, FurnModAttr.ItemType, Action<FurnitureModdingTool>>> _newObjectList = new List<ValueTuple<string, FurnModAttr.ItemType, Action<FurnitureModdingTool>>>
	{
		new ValueTuple<string, FurnModAttr.ItemType, Action<FurnitureModdingTool>>("Mesh", FurnModAttr.ItemType.Everything, delegate(FurnitureModdingTool x)
		{
			WindowManager.Instance.MultiWindow.Show("Mesh", x.Meshes.Select((Mesh z) => z.name), delegate(int z)
			{
				Mesh mesh = x.Meshes[z];
				FurnModMeta meta;
				MeshFilter meshFilter = x.AddNewMeta<MeshFilter>(Path.GetFileNameWithoutExtension(mesh.name), typeof(FurnMeshMeta), out meta);
				FurnMeshMeta obj = (FurnMeshMeta)meta;
				Mesh mesh2 = (meshFilter.sharedMesh = mesh);
				obj.Mesh = mesh2;
				GameObject gameObject = meshFilter.gameObject;
				gameObject.tag = "Highlight";
				FurnCompMeta furnCompMeta = x.CurrentMeta.FirstOrDefaultOf<FurnCompMeta>();
				if (furnCompMeta != null && furnCompMeta.IsLamp)
				{
					gameObject.layer = 13;
				}
				MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
				Material material = (meshRenderer.sharedMaterial = ObjectDatabase.Instance.CombineFurnitureMaterial);
				obj.Material = material;
				WallSnap component = x.ActiveObject.GetComponent<WallSnap>();
				component.Colorable.Add(meshRenderer);
				component.UpdateMaterials();
				x.SetInspector(x.ActiveMeta);
			}, false);
		}),
		new ValueTuple<string, FurnModAttr.ItemType, Action<FurnitureModdingTool>>("Light", FurnModAttr.ItemType.Furniture, delegate(FurnitureModdingTool x)
		{
			FurnModMeta meta;
			x.AddNewMeta<Light>("Light", typeof(FurnLightMeta), out meta).shadows = LightShadows.Hard;
		}),
		new ValueTuple<string, FurnModAttr.ItemType, Action<FurnitureModdingTool>>("Interaction point", FurnModAttr.ItemType.Furniture, delegate(FurnitureModdingTool x)
		{
			FurnModMeta meta;
			x.AddNewMeta<InteractionPoint>("InteractionPoint", typeof(FurnInteractionMeta), out meta);
		}),
		new ValueTuple<string, FurnModAttr.ItemType, Action<FurnitureModdingTool>>("Snap point", FurnModAttr.ItemType.Furniture, delegate(FurnitureModdingTool x)
		{
			FurnModMeta meta;
			x.AddNewMeta<SnapPoint>("SnapPoint", typeof(FurnSnapMeta), out meta);
		}),
		new ValueTuple<string, FurnModAttr.ItemType, Action<FurnitureModdingTool>>("Hinge", FurnModAttr.ItemType.RoomSegment, delegate(FurnitureModdingTool x)
		{
			FurnModMeta meta;
			x.AddNewMeta<DoorScript>("Hinge", typeof(FurnDoorScriptMeta), out meta);
		}),
		new ValueTuple<string, FurnModAttr.ItemType, Action<FurnitureModdingTool>>("Empty Transform", FurnModAttr.ItemType.Everything, delegate(FurnitureModdingTool x)
		{
			FurnModMeta meta;
			x.AddNewMeta<Transform>("Transform", typeof(FurnTransformMeta), out meta, false);
		})
	};

	private static HashSet<Type> _validRangeTypes = new HashSet<Type>
	{
		typeof(Furniture),
		typeof(Upgradable)
	};

	private static Dictionary<string, int> TydNodeOrder = new Dictionary<string, int>
	{
		{ "Transforms", 0 },
		{ "Models", 1 },
		{ "InteractionPoints", 2 },
		{ "SnapPoints", 3 },
		{
			"Furniture",
			int.MaxValue
		},
		{
			"RoomSegment",
			int.MaxValue
		}
	};

	public void ToggleBoundaries(bool on)
	{
		BoundaryDrawer.Boundaries = on;
	}

	public void UpdateTags()
	{
		DoorTags.ForEachEnum(delegate(Transform x)
		{
			x.gameObject.SetActive(false);
			x.SetParent(null);
		});
		RoomSegment component;
		if (ActiveObject != null && ActiveObject.transform.TryGetComponent<RoomSegment>(out component) && component.Taggable && component.TagParent != null)
		{
			DoorTags.ForEachEnum(delegate(Transform x)
			{
				x.gameObject.SetActive(true);
			});
			for (int num = 0; num < DoorTags.Length; num++)
			{
				component.SetTagPosition(DoorTags[num], (num != 0) ? 1 : (-1));
			}
		}
	}

	public void AtlasChange()
	{
		if (ActiveObject != null)
		{
			WallSnap component = ActiveObject.GetComponent<WallSnap>();
			if (component.AtlasObject != null)
			{
				int atlasIndex = Mathf.RoundToInt(AtlasSlider.value);
				component.AtlasIndex = atlasIndex;
			}
		}
	}

	public void StartBoundsEdit(bool nav)
	{
		BoundaryEditor.Init(ActiveObject.GetComponent<Furniture>(), nav);
	}

	public void MoveRotUpdate()
	{
		if (CurrentGizmo != null)
		{
			if (MoveToggle.isOn)
			{
				CurrentGizmo.CurrentAction = TransformGizmo.Action.Move;
			}
			else if (RotateToggle.isOn)
			{
				CurrentGizmo.CurrentAction = TransformGizmo.Action.Rotate;
			}
			else if (ScaleToggle.isOn)
			{
				CurrentGizmo.CurrentAction = TransformGizmo.Action.Scale;
			}
			CurrentGizmo.Global = GlobalToggle.isOn;
			CurrentGizmo.Pivot = PivotToggle.isOn;
		}
	}

	public string FindUniqueName(string baseName)
	{
		HashSet<string> hashSet = (from x in ActiveObject.GetComponentsInChildren<Transform>(true)
			select x.name).ToHashSet();
		int num = 1;
		string text = baseName;
		while (hashSet.Contains(text))
		{
			text = baseName + num;
			num++;
		}
		return text;
	}

	public void RefreshLightColor()
	{
		Furniture component = ActiveObject.GetComponent<Furniture>();
		if (!(component != null))
		{
			return;
		}
		Color color = (component.LightPrimary ? component.ColorPrimary : component.ColorTertiary);
		foreach (FurnLightMeta item in CurrentMeta.OfType<FurnLightMeta>())
		{
			if (item.Colorable)
			{
				((Light)item.Target).color = color;
			}
		}
	}

	public void DisableCutouts()
	{
		_tempCutouts.ForEach(delegate(MeshFilter x)
		{
			x.gameObject.SetActive(false);
		});
	}

	public void RefreshCutouts()
	{
		RoomSegment component;
		if (ActiveObject.transform.TryGetComponent<RoomSegment>(out component))
		{
			int num = 0;
			for (int i = 0; i < component.InsideWallMeshes.Length; i++)
			{
				MeshFilter cutout = GetCutout(num);
				cutout.sharedMesh = component.InsideWallMeshes[i].sharedMesh;
				cutout.transform.position = component.InsideWallMeshes[i].transform.position + new Vector3(0f, 0f, Room.WallOffset / 2f);
				cutout.transform.rotation = component.InsideWallMeshes[i].transform.rotation;
				num++;
				MeshFilter cutout2 = GetCutout(num);
				cutout2.sharedMesh = component.InsideWallMeshes[i].sharedMesh;
				cutout2.transform.position = component.InsideWallMeshes[i].transform.position + new Vector3(0f, 0f, (0f - Room.WallOffset) / 2f);
				cutout2.transform.rotation = component.InsideWallMeshes[i].transform.rotation;
				cutout2.transform.localScale = new Vector3(1f, 1f, -1f);
				num++;
			}
			for (int j = num; j < _tempCutouts.Count; j++)
			{
				_tempCutouts[j].gameObject.SetActive(false);
			}
		}
		else
		{
			DisableCutouts();
		}
		SetStage();
	}

	private MeshFilter GetCutout(int i)
	{
		MeshFilter meshFilter;
		if (i < _tempCutouts.Count)
		{
			meshFilter = _tempCutouts[i];
			meshFilter.gameObject.SetActive(true);
		}
		else
		{
			GameObject obj = new GameObject("Cutout");
			meshFilter = obj.AddComponent<MeshFilter>();
			obj.AddComponent<MeshRenderer>().sharedMaterial = CamTool.SideWall1.GetComponent<Renderer>().sharedMaterial;
			_tempCutouts.Add(meshFilter);
		}
		return meshFilter;
	}

	public T AddNewMeta<T>(string name, Type metaType, out FurnModMeta meta, bool add = true) where T : Component
	{
		GameObject gameObject = new GameObject(FindUniqueName(name));
		gameObject.transform.SetParent(ActiveObject.transform, true);
		gameObject.transform.localPosition = Vector3.zero;
		T val = (add ? ((T)gameObject.AddComponent(typeof(T))) : gameObject.GetComponent<T>());
		meta = (FurnModMeta)metaType.GetConstructor(new Type[1] { typeof(Component) }).Invoke(new object[1] { val });
		meta.OnCreateNew();
		meta.Changed = true;
		CurrentMeta.Add(meta);
		AddMeta(meta);
		SetInspector(meta);
		return val;
	}

	public void AddObject()
	{
		FurnModAttr.ItemType type = GetItemType();
		List<ValueTuple<string, FurnModAttr.ItemType, Action<FurnitureModdingTool>>> valids = _newObjectList.Where((ValueTuple<string, FurnModAttr.ItemType, Action<FurnitureModdingTool>> x) => (x.Item2 & type) > FurnModAttr.ItemType.None).ToList();
		WindowManager.Instance.MultiWindow.Show("Object", valids.Select((ValueTuple<string, FurnModAttr.ItemType, Action<FurnitureModdingTool>> x) => x.Item1), delegate(int x)
		{
			valids[x].Item3(this);
		}, false);
	}

	public void OnSnapFurnToggle()
	{
		SnapOnTemp.SetActive(SnapFurnToggle.isOn);
	}

	public void InitMeta(WallSnap item)
	{
		HashSet<Transform> hashSet = new HashSet<Transform>();
		if (ActiveMeta != null)
		{
			ActiveMeta.OnDeselect();
			ActiveMeta = null;
		}
		int childCount = ObjectPanel.childCount;
		for (int i = 0; i < childCount; i++)
		{
			UnityEngine.Object.Destroy(ObjectPanel.GetChild(i).gameObject);
		}
		MetaButtons.Clear();
		MetaDrops.Clear();
		CurrentMeta.Clear();
		hashSet.Add(item.transform);
		WallSnapCompMeta wallSnapCompMeta = null;
		Furniture furn;
		RoomSegment roomSegment;
		if ((object)(furn = item as Furniture) != null)
		{
			Upgradable component = furn.GetComponent<Upgradable>();
			if (component != null && component.SmokePosition != null)
			{
				hashSet.Add(component.SmokePosition);
			}
			FurnCompMeta furnCompMeta = new FurnCompMeta(furn);
			Server component2 = furn.GetComponent<Server>();
			if (component2 != null)
			{
				furnCompMeta.ServerPower = component2.Power;
			}
			furnCompMeta.Thumbnail = ((furn.Thumbnail != null) ? furn.Thumbnail.name : null);
			wallSnapCompMeta = furnCompMeta;
			CurrentMeta.Add(furnCompMeta);
			AddMeta(furnCompMeta);
			MeshFilter[] componentsInChildren = item.GetComponentsInChildren<MeshFilter>(true);
			foreach (MeshFilter meshFilter in componentsInChildren)
			{
				FurnMeshMeta furnMeshMeta = new FurnMeshMeta(meshFilter);
				CurrentMeta.Add(furnMeshMeta);
				hashSet.Add(meshFilter.transform);
				AddMeta(furnMeshMeta);
			}
			Light[] componentsInChildren2 = furn.GetComponentsInChildren<Light>(true);
			foreach (Light light in componentsInChildren2)
			{
				FurnLightMeta furnLightMeta = new FurnLightMeta(light);
				PipLight component3 = light.GetComponent<PipLight>();
				furnLightMeta.Colorable = component3 != null && furn.ColorableLights != null && furn.ColorableLights.Contains(component3);
				CurrentMeta.Add(furnLightMeta);
				AddMeta(furnLightMeta);
				hashSet.Add(light.transform);
			}
			List<List<InteractionPoint>> list = MakeGroups(furn.InteractionPoints, (InteractionPoint x) => x.Child);
			List<ValueTuple<InteractionPoint, FurnInteractionMeta>> ip = new List<ValueTuple<InteractionPoint, FurnInteractionMeta>>();
			for (int num = 0; num < list.Count; num++)
			{
				List<InteractionPoint> list2 = list[num];
				for (int num2 = 0; num2 < list2.Count; num2++)
				{
					InteractionPoint interactionPoint = list2[num2];
					FurnInteractionMeta furnInteractionMeta = new FurnInteractionMeta(interactionPoint);
					ip.Add(new ValueTuple<InteractionPoint, FurnInteractionMeta>(interactionPoint, furnInteractionMeta));
					hashSet.Add(interactionPoint.transform);
					CurrentMeta.Add(furnInteractionMeta);
					AddMeta(furnInteractionMeta);
					if (list2.Count > 1)
					{
						furnInteractionMeta.Group = num + 1;
					}
				}
			}
			for (int num3 = 0; num3 < ip.Count; num3++)
			{
				ValueTuple<InteractionPoint, FurnInteractionMeta> valueTuple = ip[num3];
				valueTuple.Item2.BlockedBy = valueTuple.Item1.BlockedBy.SelectInPlaceList((InteractionPoint x) => ip[furn.InteractionPoints.FindIndex(x)].Item2);
			}
			Dictionary<SnapPoint, FurnSnapMeta> dictionary = new Dictionary<SnapPoint, FurnSnapMeta>();
			SnapPoint[] snapPoints = furn.SnapPoints;
			foreach (SnapPoint snapPoint in snapPoints)
			{
				hashSet.Add(snapPoint.transform);
				FurnSnapMeta furnSnapMeta = new FurnSnapMeta(snapPoint);
				CurrentMeta.Add(furnSnapMeta);
				AddMeta(furnSnapMeta);
				dictionary[snapPoint] = furnSnapMeta;
			}
			foreach (KeyValuePair<SnapPoint, FurnSnapMeta> item4 in dictionary)
			{
				item4.Key.Awake();
				foreach (SnapPoint link in item4.Key.Links)
				{
					FurnSnapMeta item2 = dictionary[link];
					item4.Value.Links.Add(item2);
				}
				if (item4.Key.Blocking != null)
				{
					snapPoints = item4.Key.Blocking;
					foreach (SnapPoint key in snapPoints)
					{
						FurnSnapMeta item3 = dictionary[key];
						item4.Value.Blocking.Add(item3);
					}
				}
			}
			if (furn.ColorableLights != null)
			{
				furn.ColorableLights.Clear();
			}
		}
		else if ((object)(roomSegment = item as RoomSegment) != null)
		{
			SegmentCompMeta segmentCompMeta = new SegmentCompMeta(roomSegment);
			segmentCompMeta.Thumbnail = ((roomSegment.Thumbnail != null) ? roomSegment.Thumbnail.name : null);
			CurrentMeta.Add(segmentCompMeta);
			AddMeta(segmentCompMeta);
			wallSnapCompMeta = segmentCompMeta;
			MeshFilter[] componentsInChildren = item.GetComponentsInChildren<MeshFilter>(true);
			foreach (MeshFilter meshFilter2 in componentsInChildren)
			{
				if (roomSegment.WallMask != meshFilter2.gameObject && !roomSegment.InsideWallMeshes.Contains(meshFilter2))
				{
					FurnMeshMeta furnMeshMeta2 = new FurnMeshMeta(meshFilter2);
					CurrentMeta.Add(furnMeshMeta2);
					AddMeta(furnMeshMeta2);
				}
				hashSet.Add(meshFilter2.transform);
			}
			segmentCompMeta.WallMeshes.AddRange(roomSegment.InsideWallMeshes.Select((MeshFilter x) => x.sharedMesh));
			DoorScript[] hinges = roomSegment.Hinges;
			foreach (DoorScript doorScript in hinges)
			{
				FurnDoorScriptMeta furnDoorScriptMeta = new FurnDoorScriptMeta(doorScript);
				CurrentMeta.Add(furnDoorScriptMeta);
				AddMeta(furnDoorScriptMeta);
				hashSet.Add(doorScript.transform);
			}
		}
		if (wallSnapCompMeta != null && item.AtlasObject != null)
		{
			FurnMeshMeta furnMeshMeta3 = CurrentMeta.OfType<FurnMeshMeta>().FirstOrDefault((FurnMeshMeta x) => x.Target.gameObject == item.AtlasObject.gameObject);
			if (furnMeshMeta3 != null)
			{
				wallSnapCompMeta.AtlasObject = furnMeshMeta3;
			}
		}
		Transform[] componentsInChildren3 = item.GetComponentsInChildren<Transform>(true);
		foreach (Transform transform in componentsInChildren3)
		{
			if (!hashSet.Contains(transform))
			{
				FurnTransformMeta furnTransformMeta = new FurnTransformMeta(transform);
				CurrentMeta.Add(furnTransformMeta);
				AddMeta(furnTransformMeta);
			}
		}
		foreach (Type validGenericType in ValidGenericTypes)
		{
			Component component4 = item.GetComponent(validGenericType);
			if (component4 != null)
			{
				FurnGenericMeta furnGenericMeta = new FurnGenericMeta(component4);
				CurrentMeta.Add(furnGenericMeta);
				AddMeta(furnGenericMeta);
			}
		}
		ActiveMeta = null;
		SetInspector(wallSnapCompMeta);
	}

	private List<List<T>> MakeGroups<T>(IList<T> input, Func<T, T> next)
	{
		HashSet<T> grouped = new HashSet<T>();
		List<List<T>> list = new List<List<T>>();
		foreach (T item in input)
		{
			List<T> list2 = InitGroup(item, grouped, next);
			if (list2 != null)
			{
				list.Add(list2);
			}
		}
		return list;
	}

	private List<T> InitGroup<T>(T item, HashSet<T> grouped, Func<T, T> next)
	{
		List<T> list = null;
		while (item != null && grouped.Add(item))
		{
			if (list == null)
			{
				list = new List<T>();
			}
			list.Add(item);
			item = next(item);
		}
		return list;
	}

	public void UpdateMetaDrops()
	{
		Dictionary<string, List<GameObject>> dictionary = new Dictionary<string, List<GameObject>>();
		foreach (FurnModMeta currentMetum in CurrentMeta)
		{
			string metaGroup = currentMetum.GetMetaGroup();
			if (metaGroup != null)
			{
				dictionary.Append(metaGroup, MetaButtons[currentMetum]);
			}
		}
		foreach (KeyValuePair<string, SimpleDrop> item in MetaDrops.ToList())
		{
			List<GameObject> value;
			if (dictionary.TryGetValue(item.Key, out value))
			{
				item.Value.Items.Clear();
				item.Value.Items.AddRange(value);
				item.Value.Label.text = item.Key + " (" + value.Count + ")";
			}
			else
			{
				UnityEngine.Object.Destroy(item.Value.gameObject);
				MetaDrops.Remove(item.Key);
			}
		}
	}

	private void GetMetaDrop(FurnModMeta meta, Button b)
	{
		string metaGroup = meta.GetMetaGroup();
		if (metaGroup != null)
		{
			SimpleDrop value;
			if (!MetaDrops.TryGetValue(metaGroup, out value))
			{
				value = UnityEngine.Object.Instantiate(DropPrefab);
				value.transform.SetParent(ObjectPanel, false);
				MetaDrops[metaGroup] = value;
			}
			value.Items.Add(b.gameObject);
			value.Label.text = metaGroup + " (" + value.Items.Count + ")";
			b.transform.SetSiblingIndex(value.transform.GetSiblingIndex() + value.Items.Count);
			b.gameObject.SetActive(value.Dropped);
		}
		else if (MetaDrops.Count > 0)
		{
			b.transform.SetSiblingIndex(MetaDrops.Values.Min((SimpleDrop x) => x.transform.GetSiblingIndex()));
		}
	}

	private string GetLabel(FurnModMeta meta)
	{
		return meta.Target.name + ((meta.GetMetaGroup() == null) ? ("(" + meta.MetaName + ")") : "");
	}

	private void AddMeta(FurnModMeta meta)
	{
		Button button = UnityEngine.Object.Instantiate(ObjectButtonPrefab);
		button.GetComponentInChildren<Text>().text = GetLabel(meta);
		button.onClick.AddListener(delegate
		{
			SetInspector(meta);
		});
		button.transform.SetParent(ObjectPanel, false);
		MetaButtons[meta] = button.gameObject;
		GetMetaDrop(meta, button);
	}

	public void RefreshTransform()
	{
		foreach (KeyValuePair<FieldInfo, GameObject> inspectorElement in _inspectorElements)
		{
			switch (ActiveMeta.Meta[inspectorElement.Key].Type)
			{
			case FurnModAttr.VariableType.TransformPosition:
			{
				InputField[] componentsInChildren3 = inspectorElement.Value.GetComponentsInChildren<InputField>();
				Vector3 localPosition = ActiveMeta.Target.transform.localPosition;
				componentsInChildren3[0].text = localPosition.x.ToString("N");
				componentsInChildren3[1].text = localPosition.y.ToString("N");
				componentsInChildren3[2].text = localPosition.z.ToString("N");
				SetMetaValue(ActiveMeta, inspectorElement.Key, ActiveMeta.Meta[inspectorElement.Key], localPosition, -1);
				break;
			}
			case FurnModAttr.VariableType.TransformRotation:
			{
				InputField[] componentsInChildren2 = inspectorElement.Value.GetComponentsInChildren<InputField>();
				Vector3 eulerAngles = ActiveMeta.Target.transform.localRotation.eulerAngles;
				componentsInChildren2[0].text = eulerAngles.x.ToString("N");
				componentsInChildren2[1].text = eulerAngles.y.ToString("N");
				componentsInChildren2[2].text = eulerAngles.z.ToString("N");
				SetMetaValue(ActiveMeta, inspectorElement.Key, ActiveMeta.Meta[inspectorElement.Key], eulerAngles, -1);
				break;
			}
			case FurnModAttr.VariableType.TransformScale:
			{
				InputField[] componentsInChildren = inspectorElement.Value.GetComponentsInChildren<InputField>();
				Vector3 localScale = ActiveMeta.Target.transform.localScale;
				componentsInChildren[0].text = localScale.x.ToString("N");
				componentsInChildren[1].text = localScale.y.ToString("N");
				componentsInChildren[2].text = localScale.z.ToString("N");
				SetMetaValue(ActiveMeta, inspectorElement.Key, ActiveMeta.Meta[inspectorElement.Key], localScale, -1);
				break;
			}
			}
		}
	}

	public string SplitByCap(string input)
	{
		StringBuilder stringBuilder = new StringBuilder(input.Length);
		for (int i = 0; i < input.Length; i++)
		{
			if (i > 0 && char.IsUpper(input[i]) && !char.IsUpper(input[i - 1]))
			{
				stringBuilder.Append(' ');
			}
			else if (i > 0 && char.IsDigit(input[i]) && !char.IsDigit(input[i - 1]))
			{
				stringBuilder.Append(' ');
			}
			stringBuilder.Append(input[i]);
		}
		return stringBuilder.ToString();
	}

	private void UpdateActiveElements()
	{
		if (ActiveMeta == null)
		{
			return;
		}
		foreach (KeyValuePair<FieldInfo, FurnModAttr> metum in ActiveMeta.Meta)
		{
			SimpleDrop value;
			if (metum.Value.Dependency == null || (_inspectorHeaders.TryGetValue(metum.Key, out value) && value != null && (!value.gameObject.activeSelf || !value.Dropped)))
			{
				continue;
			}
			bool active = IsValid(metum.Value);
			GameObject orDefault = _inspectorElements.GetOrDefault(metum.Key);
			if (orDefault != null)
			{
				orDefault.SetActive(active);
				orDefault.transform.parent.GetChild(orDefault.transform.GetSiblingIndex() - 1).gameObject.SetActive(active);
				if (metum.Value.IsArray || metum.Value.IsList)
				{
					orDefault.transform.parent.GetChild(orDefault.transform.GetSiblingIndex() + 1).gameObject.SetActive(active);
				}
			}
		}
	}

	private bool IsValid(FurnModAttr atr)
	{
		KeyValuePair<FieldInfo, FurnModAttr> keyValuePair = ActiveMeta.Meta.First((KeyValuePair<FieldInfo, FurnModAttr> x) => x.Key.Name.Equals(atr.Dependency));
		object value = keyValuePair.Key.GetValue(ActiveMeta);
		bool flag = ((atr.DependencyValue != null) ? (atr.ReverseDependency ^ atr.DependencyValue.Equals(value)) : ((!(value is bool)) ? (value != null) : ((bool)value)));
		if (flag && keyValuePair.Value.Dependency != null)
		{
			return IsValid(keyValuePair.Value);
		}
		return flag;
	}

	private void SetHeader(SimpleDrop header, Component o)
	{
		if (header != null)
		{
			header.Items.Add(o.gameObject);
			o.gameObject.SetActive(false);
		}
	}

	private void SetHeader(SimpleDrop header, GameObject o)
	{
		if (header != null)
		{
			header.Items.Add(o);
			o.SetActive(false);
		}
	}

	public void SetInspector(FurnModMeta modMeta)
	{
		FurnModAttr.ItemType itemType = GetItemType();
		if (ActiveMeta != null)
		{
			Renderer component = ActiveMeta.Target.GetComponent<Renderer>();
			if (component != null)
			{
				component.sharedMaterials = component.sharedMaterials.Take(Mathf.Max(1, component.sharedMaterials.Length - 1)).ToArray();
			}
			ActiveMeta.OnDeselect();
		}
		ActiveMeta = modMeta;
		_inspectorElements.Clear();
		_inspectorHeaders.Clear();
		int childCount = ComponentPanel.childCount;
		for (int i = 1; i < childCount; i++)
		{
			UnityEngine.Object.Destroy(ComponentPanel.GetChild(i).gameObject);
		}
		if (modMeta == null)
		{
			InspectorHeader.text = "";
			return;
		}
		ActiveMeta.OnSelect();
		Renderer component2 = ActiveMeta.Target.GetComponent<Renderer>();
		if (component2 != null)
		{
			component2.sharedMaterials = component2.sharedMaterials.Concate(OutlineMat).ToArray();
		}
		InspectorHeader.text = modMeta.Target.name + " (" + modMeta.MetaName + ")";
		if (CurrentGizmo != null)
		{
			UnityEngine.Object.Destroy(CurrentGizmo);
		}
		if (modMeta.UseGizmo())
		{
			CurrentGizmo = modMeta.Target.gameObject.AddComponent<TransformGizmo>();
			CurrentGizmo.Circle = Circle;
			CurrentGizmo.Arrow = Arrow;
			CurrentGizmo.ScaleArrow = ScaleArrow;
			CurrentGizmo.Mat = GizmoMat;
			CurrentGizmo.Scale = 0.5f;
			CurrentGizmo.Cam = MainCam;
			CurrentGizmo.OnFinishChange = RefreshTransform;
			MoveRotUpdate();
		}
		MethodInfo[] methods = modMeta.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public);
		foreach (MethodInfo action in methods)
		{
			FurnModAction customAttribute = action.GetCustomAttribute<FurnModAction>();
			if (customAttribute != null && (customAttribute.ValidFor & itemType) > FurnModAttr.ItemType.None)
			{
				Button button = UnityEngine.Object.Instantiate(ObjectButtonPrefab);
				button.GetComponentInChildren<Text>().text = SplitByCap(action.Name);
				button.onClick.AddListener(delegate
				{
					action.Invoke(modMeta, null);
				});
				button.name = "-FAction";
				button.transform.SetParent(ComponentPanel, false);
				if (!string.IsNullOrEmpty(customAttribute.Tip))
				{
					GUIToolTipper component3 = button.GetComponent<GUIToolTipper>();
					component3.Localize = false;
					component3.TooltipDescription = customAttribute.Tip;
				}
			}
		}
		SimpleDrop simpleDrop = null;
		foreach (KeyValuePair<FieldInfo, FurnModAttr> meta in modMeta.Meta)
		{
			if (meta.Value.Hidden || (meta.Value.ValidFor & itemType) == 0)
			{
				continue;
			}
			FurnModHeader customAttribute2 = meta.Key.GetCustomAttribute<FurnModHeader>();
			if (customAttribute2 != null)
			{
				simpleDrop = UnityEngine.Object.Instantiate(DropPrefab);
				simpleDrop.name = "-FHeader";
				simpleDrop.Label.text = customAttribute2.Header;
				simpleDrop.Label.fontStyle = FontStyle.Bold;
				simpleDrop.Label.alignment = TextAnchor.MiddleRight;
				simpleDrop.transform.SetParent(ComponentPanel, false);
				simpleDrop.OnChanged = UpdateActiveElements;
				simpleDrop.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.8f);
			}
			if (!meta.Value.IsArray && !meta.Value.IsList)
			{
				Text text = UnityEngine.Object.Instantiate(CompLabelPrefab);
				text.text = SplitByCap(meta.Key.Name);
				text.rectTransform.SetParent(ComponentPanel, false);
				SetHeader(simpleDrop, text.gameObject);
				if (meta.Value.Desc != null)
				{
					GUIToolTipper gUIToolTipper = text.gameObject.AddComponent<GUIToolTipper>();
					gUIToolTipper.TooltipDescription = meta.Value.Desc;
					gUIToolTipper.Localize = false;
				}
			}
			if (meta.Value.IsArray || meta.Value.IsList)
			{
				object obj = ((modMeta is FurnGenericMeta) ? ((object)modMeta.Target) : ((object)modMeta));
				IList list = meta.Key.GetValue(obj) as IList;
				Transform arrayPanel = UnityEngine.Object.Instantiate(ArrayPanelPrefab).transform;
				if (list != null)
				{
					for (int num = 0; num < list.Count; num++)
					{
						CreateMetaElement(modMeta, meta.Key, meta.Value, arrayPanel, null, num);
						Button b = UnityEngine.Object.Instantiate(ObjectButtonPrefab);
						b.GetComponentInChildren<Text>().text = "X";
						b.transform.SetParent(arrayPanel, false);
						b.onClick.AddListener(delegate
						{
							RemoveArrayElement(modMeta, meta.Key, meta.Value, b.transform);
						});
					}
				}
				Button button2 = UnityEngine.Object.Instantiate(ObjectButtonPrefab);
				button2.name = "-FAddButton";
				button2.GetComponentInChildren<Text>().text = "Add element";
				button2.onClick.AddListener(delegate
				{
					int idx = AddElementToArray(modMeta, meta.Key, meta.Value);
					CreateMetaElement(modMeta, meta.Key, meta.Value, arrayPanel, null, idx);
					Button b2 = UnityEngine.Object.Instantiate(ObjectButtonPrefab);
					b2.GetComponentInChildren<Text>().text = "X";
					b2.transform.SetParent(arrayPanel, false);
					b2.onClick.AddListener(delegate
					{
						RemoveArrayElement(modMeta, meta.Key, meta.Value, b2.transform);
					});
				});
				SimpleDrop simpleDrop2 = UnityEngine.Object.Instantiate(DropPrefab);
				simpleDrop2.name = "-FHeader";
				simpleDrop2.Label.text = SplitByCap(meta.Key.Name);
				if (meta.Value.Desc != null)
				{
					GUIToolTipper gUIToolTipper2 = simpleDrop2.gameObject.AddComponent<GUIToolTipper>();
					gUIToolTipper2.TooltipDescription = meta.Value.Desc;
					gUIToolTipper2.Localize = false;
				}
				simpleDrop2.transform.SetParent(ComponentPanel, false);
				arrayPanel.SetParent(ComponentPanel, false);
				arrayPanel.gameObject.SetActive(false);
				button2.transform.SetParent(ComponentPanel, false);
				button2.gameObject.SetActive(false);
				SetHeader(simpleDrop, simpleDrop2);
				SetHeader(simpleDrop, arrayPanel);
				SetHeader(simpleDrop, button2);
				simpleDrop2.Items.Add(arrayPanel.gameObject);
				simpleDrop2.Items.Add(button2.gameObject);
				_inspectorElements[meta.Key] = arrayPanel.gameObject;
				if (simpleDrop != null)
				{
					_inspectorHeaders[meta.Key] = simpleDrop;
				}
			}
			else
			{
				CreateMetaElement(modMeta, meta.Key, meta.Value, ComponentPanel, simpleDrop);
			}
		}
		UpdateActiveElements();
	}

	private int AddElementToArray(FurnModMeta modMeta, FieldInfo field, FurnModAttr atr)
	{
		int result = 0;
		object obj = ((modMeta is FurnGenericMeta) ? ((object)modMeta.Target) : ((object)modMeta));
		if (atr.IsArray)
		{
			Array array = field.GetValue(obj) as Array;
			Array array2;
			if (array == null)
			{
				array2 = Array.CreateInstance(field.FieldType.GetElementType(), 1);
				result = 0;
			}
			else
			{
				array2 = Array.CreateInstance(field.FieldType.GetElementType(), array.Length + 1);
				for (int i = 0; i < array.Length; i++)
				{
					array2.SetValue(array.GetValue(i), i);
				}
				result = array.Length;
			}
			field.SetValue(obj, array2);
			if (atr.ReflectTarget)
			{
				Type type = modMeta.Target.GetType();
				FieldInfo field2 = type.GetField(atr.VarName);
				if (field2 != null)
				{
					field2.SetValue(modMeta.Target, array2.Clone());
				}
				else
				{
					PropertyInfo property = type.GetProperty(atr.VarName);
					if (property != null)
					{
						property.SetValue(modMeta.Target, array2.Clone());
					}
				}
			}
		}
		else if (atr.IsList)
		{
			IList list = field.GetValue(obj) as IList;
			if (list == null)
			{
				list = field.FieldType.GetConstructor(null).Invoke(null) as IList;
				field.SetValue(obj, list);
			}
			object value = field.FieldType.GenericTypeArguments[0].GetDefault(atr.CanInstantiate);
			result = list.Count;
			list.Add(value);
			if (atr.ReflectTarget)
			{
				Type type2 = modMeta.Target.GetType();
				FieldInfo field3 = type2.GetField(atr.VarName);
				if (field3 != null)
				{
					list = field3.GetValue(modMeta.Target) as IList;
					if (list == null)
					{
						list = field3.FieldType.GetConstructor(null).Invoke(null) as IList;
						field3.SetValue(modMeta, list);
					}
					list.Add(value);
				}
				else
				{
					PropertyInfo property2 = type2.GetProperty(atr.VarName);
					if (property2 != null)
					{
						list = property2.GetValue(modMeta.Target) as IList;
						if (list == null)
						{
							list = property2.PropertyType.GetConstructor(null).Invoke(null) as IList;
							property2.SetValue(modMeta, list);
						}
						list.Add(value);
					}
				}
			}
		}
		if (atr.CallMethod != null)
		{
			modMeta.GetType().GetMethod(atr.CallMethod, BindingFlags.Instance | BindingFlags.Public).Invoke(modMeta, null);
		}
		return result;
	}

	private void RemoveArrayElement(FurnModMeta modMeta, FieldInfo field, FurnModAttr atr, Transform button)
	{
		int siblingIndex = button.GetSiblingIndex();
		int num = (siblingIndex - 1) / 2;
		UnityEngine.Object.Destroy(button.parent.GetChild(siblingIndex - 1).gameObject);
		UnityEngine.Object.Destroy(button.gameObject);
		object obj = ((modMeta is FurnGenericMeta) ? ((object)modMeta.Target) : ((object)modMeta));
		if (atr.IsArray)
		{
			Array array = field.GetValue(obj) as Array;
			Array array2 = Array.CreateInstance(field.FieldType.GetElementType(), array.Length - 1);
			int num2 = 0;
			for (int i = 0; i < array.Length; i++)
			{
				if (i != num)
				{
					array2.SetValue(array.GetValue(i), num2);
					num2++;
				}
			}
			field.SetValue(obj, array2);
			if (atr.ReflectTarget)
			{
				Type type = modMeta.Target.GetType();
				FieldInfo field2 = type.GetField(atr.VarName);
				if (field2 != null)
				{
					field2.SetValue(modMeta.Target, array2.Clone());
				}
				else
				{
					PropertyInfo property = type.GetProperty(atr.VarName);
					if (property != null)
					{
						property.SetValue(modMeta.Target, array2.Clone());
					}
				}
			}
		}
		else if (atr.IsList)
		{
			(field.GetValue(obj) as IList).RemoveAt(num);
			if (atr.ReflectTarget)
			{
				Type type2 = modMeta.Target.GetType();
				FieldInfo field3 = type2.GetField(atr.VarName);
				if (field3 != null)
				{
					(field3.GetValue(modMeta.Target) as IList).RemoveAt(num);
				}
				else
				{
					PropertyInfo property2 = type2.GetProperty(atr.VarName);
					if (property2 != null)
					{
						(property2.GetValue(modMeta.Target) as IList).RemoveAt(num);
					}
				}
			}
		}
		if (atr.CallMethod != null)
		{
			modMeta.GetType().GetMethod(atr.CallMethod, BindingFlags.Instance | BindingFlags.Public).Invoke(modMeta, null);
		}
		modMeta.Changed = true;
	}

	private int GetIndex(Transform t)
	{
		return t.GetSiblingIndex() / 2;
	}

	private object GetFieldValue(FurnModMeta modMeta, FieldInfo field, FurnModAttr atr, int idx)
	{
		object obj = ((modMeta is FurnGenericMeta) ? ((object)modMeta.Target) : ((object)modMeta));
		if (atr.IsArray || atr.IsList)
		{
			IList obj2 = field.GetValue(obj) as IList;
			if (obj2 == null)
			{
				return null;
			}
			return obj2[idx];
		}
		return field.GetValue(obj);
	}

	private static float[] FindRanges(FurnModAttr atr, Type compType, string type, bool furn)
	{
		float[] array = new float[4]
		{
			float.MaxValue,
			float.MinValue,
			float.MaxValue,
			float.MinValue
		};
		FieldInfo field = compType.GetField(atr.VarName);
		PropertyInfo propertyInfo = null;
		if (field == null)
		{
			propertyInfo = compType.GetProperty(atr.VarName);
		}
		if (field != null || propertyInfo != null)
		{
			float[] array2 = new float[1];
			IEnumerable<WallSnap> source;
			if (!furn)
			{
				IEnumerable<WallSnap> enumerable = ObjectDatabase.Instance.RoomSegments.Select((GameObject x) => x.GetComponent<RoomSegment>());
				source = enumerable;
			}
			else
			{
				IEnumerable<WallSnap> enumerable = from x in ObjectDatabase.Instance.GetAllFurniture()
					select x.GetComponent<Furniture>();
				source = enumerable;
			}
			foreach (WallSnap item in source.Where((WallSnap x) => x.FileName == null))
			{
				Component component = item.GetComponent(compType);
				if (!(component != null))
				{
					continue;
				}
				float[] array3;
				if (field != null)
				{
					if (field.FieldType.IsArray)
					{
						array3 = (float[])field.GetValue(component);
					}
					else
					{
						array2[0] = (float)field.GetValue(component);
						array3 = array2;
					}
				}
				else if (propertyInfo.PropertyType.IsArray)
				{
					array3 = (float[])propertyInfo.GetValue(component);
				}
				else
				{
					array2[0] = (float)propertyInfo.GetValue(component);
					array3 = array2;
				}
				foreach (float num2 in array3)
				{
					if (array[0] == float.MaxValue)
					{
						array[0] = (array[1] = num2);
					}
					if (num2 > array[1])
					{
						array[1] = num2;
					}
					else if (num2 < array[0])
					{
						array[0] = num2;
					}
					if (item.Type.Equals(type))
					{
						if (array[2] == float.MaxValue)
						{
							array[2] = (array[3] = num2);
						}
						if (num2 > array[3])
						{
							array[3] = num2;
						}
						else if (num2 < array[2])
						{
							array[2] = num2;
						}
					}
				}
			}
		}
		return array;
	}

	public string GetTypeName()
	{
		if (!(ActivePrefab is Furniture))
		{
			return "RoomSegment";
		}
		return "Furniture";
	}

	public FurnModAttr.ItemType GetItemType()
	{
		if (!(ActivePrefab is Furniture))
		{
			return FurnModAttr.ItemType.RoomSegment;
		}
		return FurnModAttr.ItemType.Furniture;
	}

	private void CreateMetaElement(FurnModMeta modMeta, FieldInfo field, FurnModAttr atr, Transform parent, SimpleDrop header, int idx = -1)
	{
		if (header != null)
		{
			_inspectorHeaders[field] = header;
		}
		switch (atr.Type)
		{
		case FurnModAttr.VariableType.String:
		{
			GameObject output;
			InputField input19;
			if (atr.FetchList != null)
			{
				output = UnityEngine.Object.Instantiate(CompInputSugPrefab);
				input19 = output.GetComponentInChildren<InputField>();
				output.GetComponentInChildren<Button>().onClick.AddListener(delegate
				{
					Type type = modMeta.GetType();
					List<string> el = ((IEnumerable<string>)type.GetMethod(atr.FetchList).Invoke(modMeta, null)).Distinct().ToList();
					WindowManager.Instance.MultiWindow.Show("Value", el, delegate(int x)
					{
						input19.text = el[x];
						input19.onEndEdit.Invoke(el[x]);
					}, false);
				});
			}
			else
			{
				input19 = UnityEngine.Object.Instantiate(CompInputPrefab);
				output = input19.gameObject;
			}
			input19.text = (GetFieldValue(modMeta, field, atr, idx) ?? "").ToString();
			input19.onEndEdit.AddListener(delegate
			{
				SetMetaValue(modMeta, field, atr, input19.text, GetIndex(output.transform));
				if ("name".Equals(atr.VarName))
				{
					MetaButtons[modMeta].GetComponentInChildren<Text>().text = GetLabel(modMeta);
				}
			});
			output.transform.SetParent(parent, false);
			SetHeader(header, output);
			if (!atr.IsArray && !atr.IsList)
			{
				_inspectorElements[field] = output;
			}
			break;
		}
		case FurnModAttr.VariableType.Combo:
		{
			GUICombobox combo = UnityEngine.Object.Instantiate(ComboPrefab);
			List<string[]> list = ((string[][])modMeta.GetType().GetMethod(atr.FetchList).Invoke(modMeta, null)).Distinct().ToList();
			combo.UpdateContent(list[0], list[1]);
			combo.SelectedItem = GetFieldValue(modMeta, field, atr, idx);
			combo.OnSelectedChanged.AddListener(delegate
			{
				SetMetaValue(modMeta, field, atr, combo.SelectedItemString, GetIndex(combo.transform));
			});
			combo.transform.SetParent(parent, false);
			SetHeader(header, combo);
			if (!atr.IsArray && !atr.IsList)
			{
				_inspectorElements[field] = combo.gameObject;
			}
			break;
		}
		case FurnModAttr.VariableType.BigString:
		{
			InputField input12 = UnityEngine.Object.Instantiate(CompInputPrefab);
			input12.lineType = InputField.LineType.MultiLineNewline;
			input12.text = (GetFieldValue(modMeta, field, atr, idx) ?? "").ToString();
			input12.gameObject.AddComponent<LayoutElement>().minHeight = 128f;
			input12.onEndEdit.AddListener(delegate
			{
				SetMetaValue(modMeta, field, atr, input12.text, GetIndex(input12.gameObject.transform));
			});
			input12.transform.SetParent(parent, false);
			SetHeader(header, input12);
			if (!atr.IsArray && !atr.IsList)
			{
				_inspectorElements[field] = input12.gameObject;
			}
			break;
		}
		case FurnModAttr.VariableType.PercentSlider:
		{
			Slider input13 = UnityEngine.Object.Instantiate(SliderInputPrefab);
			Text label3 = input13.GetComponentInChildren<Text>();
			input13.maxValue = atr.UpperBound;
			input13.minValue = atr.LowerBound;
			input13.value = (float)GetFieldValue(modMeta, field, atr, idx);
			label3.text = input13.value.ToPercent(false);
			input13.onValueChanged.AddListener(delegate
			{
				float num6 = Mathf.Round(input13.value * 100f) / 100f;
				SetMetaValue(modMeta, field, atr, num6, GetIndex(input13.transform));
				label3.text = num6.ToPercent(false);
			});
			input13.transform.SetParent(parent, false);
			SetHeader(header, input13);
			if (!atr.IsArray && !atr.IsList)
			{
				_inspectorElements[field] = input13.gameObject;
			}
			break;
		}
		case FurnModAttr.VariableType.Integer:
		{
			InputField input18 = UnityEngine.Object.Instantiate(CompInputPrefab);
			input18.contentType = InputField.ContentType.IntegerNumber;
			input18.text = ((int)GetFieldValue(modMeta, field, atr, idx)).ToString();
			input18.onEndEdit.AddListener(delegate
			{
				int index = GetIndex(input18.transform);
				SetMetaValue(modMeta, field, atr, input18.text.ConvertToIntDef((int)GetFieldValue(modMeta, field, atr, index)), index);
				input18.text = ((int)GetFieldValue(modMeta, field, atr, index)).ToString();
			});
			input18.transform.SetParent(parent, false);
			SetHeader(header, input18);
			if (!atr.IsArray && !atr.IsList)
			{
				_inspectorElements[field] = input18.gameObject;
			}
			break;
		}
		case FurnModAttr.VariableType.Float:
		{
			GameObject gameObject2;
			InputField input5;
			if (atr.VarName != null && _validRangeTypes.Contains(modMeta.Target.GetType()))
			{
				gameObject2 = UnityEngine.Object.Instantiate(CompInputSugPrefab);
				input5 = gameObject2.GetComponentInChildren<InputField>();
				gameObject2.GetComponentInChildren<Button>().onClick.AddListener(delegate
				{
					float[] array = FindRanges(atr, modMeta.Target.GetType(), ActivePrefab.Type, ActivePrefab is Furniture);
					if (array[0] != float.MaxValue)
					{
						WindowManager.Instance.ShowMessageBox(string.Format("Range of {0} in vanilla furniture:\n{1} - {2}\nRange for {3} {4}:\n{5} - {6}", field.Name, array[0], array[1], ActivePrefab.Type, GetTypeName(), array[2], array[3]), true, DialogWindow.DialogType.Information);
					}
				});
			}
			else
			{
				input5 = UnityEngine.Object.Instantiate(CompInputPrefab);
				gameObject2 = input5.gameObject;
			}
			input5.contentType = InputField.ContentType.DecimalNumber;
			input5.text = ((float)GetFieldValue(modMeta, field, atr, idx)).ToString("N");
			input5.onEndEdit.AddListener(delegate
			{
				int index = GetIndex(input5.transform);
				SetMetaValue(modMeta, field, atr, input5.text.ConvertToFloatDef((float)GetFieldValue(modMeta, field, atr, index)), index);
				input5.text = ((float)GetFieldValue(modMeta, field, atr, index)).ToString("N");
			});
			gameObject2.transform.SetParent(parent, false);
			SetHeader(header, gameObject2);
			if (!atr.IsArray && !atr.IsList)
			{
				_inspectorElements[field] = gameObject2;
			}
			break;
		}
		case FurnModAttr.VariableType.TransformPosition:
		{
			GameObject prefab2 = UnityEngine.Object.Instantiate(ThreeInputPrefab);
			InputField[] input8 = prefab2.GetComponentsInChildren<InputField>();
			Vector3 pos = modMeta.Target.transform.localPosition;
			input8[0].text = pos.x.ToString("N");
			input8[1].text = pos.y.ToString("N");
			input8[2].text = pos.z.ToString("N");
			for (int num2 = 0; num2 < input8.Length; num2++)
			{
				input8[num2].onEndEdit.AddListener(delegate
				{
					Vector3 localPosition = modMeta.Target.transform.localPosition;
					modMeta.Target.transform.localPosition = new Vector3(input8[0].text.ConvertToFloatDef(localPosition.x), input8[1].text.ConvertToFloatDef(localPosition.y), input8[2].text.ConvertToFloatDef(localPosition.z));
					Vector3 localPosition2 = modMeta.Target.transform.localPosition;
					SetMetaValue(modMeta, field, atr, pos, GetIndex(prefab2.transform));
					input8[0].text = localPosition2.x.ToString("N");
					input8[1].text = localPosition2.y.ToString("N");
					input8[2].text = localPosition2.z.ToString("N");
				});
			}
			prefab2.transform.SetParent(parent, false);
			SetHeader(header, prefab2);
			if (!atr.IsArray && !atr.IsList)
			{
				_inspectorElements[field] = prefab2;
			}
			break;
		}
		case FurnModAttr.VariableType.TransformRotation:
		{
			GameObject prefab = UnityEngine.Object.Instantiate(ThreeInputPrefab);
			InputField[] input = prefab.GetComponentsInChildren<InputField>();
			Vector3 eulerAngles = modMeta.Target.transform.localRotation.eulerAngles;
			input[0].text = eulerAngles.x.ToString("N");
			input[1].text = eulerAngles.y.ToString("N");
			input[2].text = eulerAngles.z.ToString("N");
			for (int num = 0; num < input.Length; num++)
			{
				input[num].onEndEdit.AddListener(delegate
				{
					Vector3 eulerAngles2 = modMeta.Target.transform.localRotation.eulerAngles;
					modMeta.Target.transform.localRotation = Quaternion.Euler(input[0].text.ConvertToFloatDef(eulerAngles2.x), input[1].text.ConvertToFloatDef(eulerAngles2.y), input[2].text.ConvertToFloatDef(eulerAngles2.z));
					Vector3 eulerAngles3 = modMeta.Target.transform.localRotation.eulerAngles;
					SetMetaValue(modMeta, field, atr, eulerAngles3, GetIndex(prefab.transform));
					input[0].text = eulerAngles3.x.ToString("N");
					input[1].text = eulerAngles3.y.ToString("N");
					input[2].text = eulerAngles3.z.ToString("N");
				});
			}
			prefab.transform.SetParent(parent, false);
			SetHeader(header, prefab);
			if (!atr.IsArray && !atr.IsList)
			{
				_inspectorElements[field] = prefab;
			}
			break;
		}
		case FurnModAttr.VariableType.TransformScale:
		{
			GameObject prefab4 = UnityEngine.Object.Instantiate(ThreeInputPrefab);
			InputField[] input14 = prefab4.GetComponentsInChildren<InputField>();
			Vector3 localScale = modMeta.Target.transform.localScale;
			input14[0].text = localScale.x.ToString("N");
			input14[1].text = localScale.y.ToString("N");
			input14[2].text = localScale.z.ToString("N");
			for (int num4 = 0; num4 < input14.Length; num4++)
			{
				input14[num4].onEndEdit.AddListener(delegate
				{
					Vector3 localScale2 = modMeta.Target.transform.localScale;
					modMeta.Target.transform.localScale = new Vector3(Mathf.Max(0.001f, input14[0].text.ConvertToFloatDef(localScale2.x)), Mathf.Max(0.001f, input14[1].text.ConvertToFloatDef(localScale2.y)), Mathf.Max(0.001f, input14[2].text.ConvertToFloatDef(localScale2.z)));
					Vector3 localScale3 = modMeta.Target.transform.localScale;
					SetMetaValue(modMeta, field, atr, localScale3, GetIndex(prefab4.transform));
					input14[0].text = localScale3.x.ToString("N");
					input14[1].text = localScale3.y.ToString("N");
					input14[2].text = localScale3.z.ToString("N");
				});
			}
			prefab4.transform.SetParent(parent, false);
			SetHeader(header, prefab4);
			if (!atr.IsArray && !atr.IsList)
			{
				_inspectorElements[field] = prefab4;
			}
			break;
		}
		case FurnModAttr.VariableType.Color:
		{
			Button input4 = UnityEngine.Object.Instantiate(ObjectButtonPrefab);
			input4.GetComponentInChildren<Text>().text = "Set";
			Image img = input4.GetComponent<Image>();
			img.color = (Color)GetFieldValue(modMeta, field, atr, idx);
			input4.onClick.AddListener(delegate
			{
				WindowManager.SpawnColorDialog(delegate(Color x)
				{
					SetMetaValue(modMeta, field, atr, x, GetIndex(input4.transform));
					img.color = x;
				}, (Color)GetFieldValue(modMeta, field, atr, idx), null, null, false);
			});
			input4.transform.SetParent(parent, false);
			SetHeader(header, input4);
			if (!atr.IsArray && !atr.IsList)
			{
				_inspectorElements[field] = input4.gameObject;
			}
			break;
		}
		case FurnModAttr.VariableType.Bool:
		{
			Toggle input16 = UnityEngine.Object.Instantiate(ToggleInputPrefab);
			input16.isOn = (bool)GetFieldValue(modMeta, field, atr, idx);
			input16.onValueChanged.AddListener(delegate(bool x)
			{
				SetMetaValue(modMeta, field, atr, x, GetIndex(input16.transform));
			});
			input16.transform.SetParent(parent, false);
			SetHeader(header, input16);
			if (!atr.IsArray && !atr.IsList)
			{
				_inspectorElements[field] = input16.gameObject;
			}
			break;
		}
		case FurnModAttr.VariableType.TransformParent:
		{
			Button input11 = UnityEngine.Object.Instantiate(ObjectButtonPrefab);
			Text label2 = input11.GetComponentInChildren<Text>();
			label2.text = modMeta.Target.transform.parent.name;
			input11.onClick.AddListener(delegate
			{
				Transform[] valids = (from x in CurrentMeta.Select((FurnModMeta x) => x.Target.transform).Distinct()
					where x.transform != modMeta.Target.transform
					select x).ToArray();
				WindowManager.Instance.MultiWindow.Show("Parent", valids.Select((Transform x) => x.name), delegate(int x)
				{
					SetMetaValue(modMeta, field, atr, valids[x].gameObject, GetIndex(input11.transform));
					modMeta.Target.transform.SetParent(valids[x], true);
					label2.text = valids[x].name;
				}, false);
			});
			input11.transform.SetParent(parent, false);
			SetHeader(header, input11);
			if (!atr.IsArray && !atr.IsList)
			{
				_inspectorElements[field] = input11.gameObject;
			}
			break;
		}
		case FurnModAttr.VariableType.SubComponent:
		{
			Button button3;
			GameObject input7;
			if (!atr.CanDisableComp)
			{
				button3 = UnityEngine.Object.Instantiate(ObjectButtonPrefab);
				input7 = button3.gameObject;
			}
			else
			{
				input7 = UnityEngine.Object.Instantiate(ToggleButtonPrefab);
				Toggle componentInChildren2 = input7.GetComponentInChildren<Toggle>();
				button3 = input7.GetComponentInChildren<Button>();
				componentInChildren2.isOn = GetFieldValue(modMeta, field, atr, idx) != null;
				componentInChildren2.onValueChanged.AddListener(delegate(bool x)
				{
					if (x)
					{
						FurnModMeta furnModMeta2 = FurnModMeta.CreateMeta(modMeta.Target.gameObject.AddComponent(atr.ComponentType), field.FieldType);
						SetMetaValue(modMeta, field, atr, furnModMeta2, GetIndex(input7.transform));
						furnModMeta2.OnCreateNew();
						furnModMeta2.Changed = true;
					}
					else
					{
						FurnModMeta furnModMeta3 = GetFieldValue(modMeta, field, atr, idx) as FurnModMeta;
						if (furnModMeta3 != null)
						{
							furnModMeta3.OnDeactivate();
							UnityEngine.Object.Destroy(furnModMeta3.Target);
							SetMetaValue(modMeta, field, atr, null, GetIndex(input7.transform));
						}
					}
				});
			}
			button3.GetComponentInChildren<Text>().text = "Open";
			button3.onClick.AddListener(delegate
			{
				FurnModMeta furnModMeta2 = GetFieldValue(modMeta, field, atr, idx) as FurnModMeta;
				if (furnModMeta2 != null)
				{
					SetInspector(furnModMeta2);
				}
			});
			input7.transform.SetParent(parent, false);
			SetHeader(header, input7);
			if (!atr.IsArray && !atr.IsList)
			{
				_inspectorElements[field] = input7;
			}
			break;
		}
		case FurnModAttr.VariableType.ExternalComponent:
		{
			bool isGO = FurnModMeta.IsGameObjectField(field.FieldType);
			if (modMeta is FurnGenericMeta || isGO)
			{
				Button button = UnityEngine.Object.Instantiate(ObjectButtonPrefab);
				UnityEngine.Object obj = GetFieldValue(modMeta, field, atr, idx) as UnityEngine.Object;
				Text label = button.GetComponentInChildren<Text>();
				label.text = ((obj == null) ? "[NULL]" : obj.name);
				button.onClick.AddListener(delegate
				{
					Component[] os = ActiveObject.GetComponentsInChildren(atr.ComponentType, true);
					if (os.Length != 0)
					{
						WindowManager.Instance.MultiWindow.Show("Object", os.Select((Component x) => x.name), delegate(int num6)
						{
							if (num6 == -1)
							{
								label.text = "[NULL]";
								SetMetaValue(modMeta, field, atr, null, GetIndex(button.transform));
							}
							else
							{
								Component component2 = os[num6];
								label.text = component2.name;
								SetMetaValue(modMeta, field, atr, isGO ? ((UnityEngine.Object)component2.gameObject) : ((UnityEngine.Object)component2), GetIndex(button.transform));
							}
						}, true);
					}
				});
				button.transform.SetParent(parent, false);
				SetHeader(header, button);
				if (!atr.IsArray && !atr.IsList)
				{
					_inspectorElements[field] = button.gameObject;
				}
				break;
			}
			Button button2;
			GameObject input6;
			if (!atr.CanDisableComp)
			{
				button2 = UnityEngine.Object.Instantiate(ObjectButtonPrefab);
				input6 = button2.gameObject;
			}
			else
			{
				input6 = UnityEngine.Object.Instantiate(ToggleButtonPrefab);
				Toggle componentInChildren = input6.GetComponentInChildren<Toggle>();
				button2 = input6.GetComponentInChildren<Button>();
				componentInChildren.isOn = GetFieldValue(modMeta, field, atr, idx) != null;
				componentInChildren.onValueChanged.AddListener(delegate(bool x)
				{
					if (x)
					{
						GameObject gameObject3 = new GameObject(field.Name);
						gameObject3.transform.SetParent(ActiveObject.transform, true);
						gameObject3.transform.localPosition = Vector3.zero;
						FurnModMeta furnModMeta2 = FurnModMeta.CreateMeta(gameObject3.GetComponent(atr.ComponentType) ?? gameObject3.AddComponent(atr.ComponentType), field.FieldType);
						SetMetaValue(modMeta, field, atr, furnModMeta2, GetIndex(input6.transform));
						furnModMeta2.OnCreateNew();
						furnModMeta2.Changed = true;
					}
					else
					{
						FurnModMeta furnModMeta3 = GetFieldValue(modMeta, field, atr, idx) as FurnModMeta;
						if (furnModMeta3 != null)
						{
							furnModMeta3.OnDeactivate();
							UnityEngine.Object.Destroy(furnModMeta3.Target.gameObject);
							SetMetaValue(modMeta, field, atr, null, GetIndex(input6.transform));
						}
					}
				});
			}
			button2.GetComponentInChildren<Text>().text = "Open";
			button2.onClick.AddListener(delegate
			{
				FurnModMeta furnModMeta2 = GetFieldValue(modMeta, field, atr, idx) as FurnModMeta;
				if (furnModMeta2 != null)
				{
					SetInspector(furnModMeta2);
				}
			});
			input6.transform.SetParent(parent, false);
			SetHeader(header, input6);
			if (!atr.IsArray && !atr.IsList)
			{
				_inspectorElements[field] = input6;
			}
			break;
		}
		case FurnModAttr.VariableType.ExternalMeta:
		{
			Button input17 = UnityEngine.Object.Instantiate(ObjectButtonPrefab);
			Text label4 = input17.GetComponentInChildren<Text>();
			FurnModMeta furnModMeta = (FurnModMeta)GetFieldValue(modMeta, field, atr, idx);
			label4.text = ((furnModMeta == null) ? "[NULL]" : furnModMeta.Target.name);
			input17.onClick.AddListener(delegate
			{
				Type t = field.FieldType;
				if (atr.IsArray)
				{
					t = t.GetElementType();
				}
				else if (atr.IsList)
				{
					t = t.GetGenericArguments()[0];
				}
				FurnModMeta[] valids = CurrentMeta.Where((FurnModMeta x) => x.GetType() == t && x != modMeta).ToArray();
				if (valids.Length != 0)
				{
					WindowManager.Instance.MultiWindow.Show("Value", valids.Select((FurnModMeta x) => x.Target.name), delegate(int x)
					{
						SetMetaValue(modMeta, field, atr, valids[x], GetIndex(input17.transform));
						label4.text = valids[x].Target.name;
					}, false);
				}
			});
			input17.transform.SetParent(parent, false);
			SetHeader(header, input17);
			if (!atr.IsArray && !atr.IsList)
			{
				_inspectorElements[field] = input17.gameObject;
			}
			break;
		}
		case FurnModAttr.VariableType.Mesh:
		{
			Button input9 = UnityEngine.Object.Instantiate(ObjectButtonPrefab);
			Mesh mesh = GetFieldValue(modMeta, field, atr, idx) as Mesh;
			input9.GetComponentInChildren<Text>().text = ((mesh != null) ? mesh.name : "None");
			input9.onClick.AddListener(delegate
			{
				WindowManager.Instance.MultiWindow.Show("Mesh", Meshes.Select((Mesh x) => x.name), delegate(int x)
				{
					Mesh mesh2 = Meshes[x];
					input9.GetComponentInChildren<Text>().text = mesh2.name;
					if (atr.VarName == null)
					{
						modMeta.Target.gameObject.GetComponent<MeshFilter>().sharedMesh = mesh2;
					}
					SetMetaValue(modMeta, field, atr, mesh2, GetIndex(input9.transform), true);
				}, false);
			});
			input9.transform.SetParent(parent, false);
			SetHeader(header, input9);
			if (!atr.IsArray && !atr.IsList)
			{
				_inspectorElements[field] = input9.gameObject;
			}
			break;
		}
		case FurnModAttr.VariableType.Material:
		{
			Button input3 = UnityEngine.Object.Instantiate(ObjectButtonPrefab);
			Material material = GetFieldValue(modMeta, field, atr, idx) as Material;
			input3.GetComponentInChildren<Text>().text = ((material != null) ? material.name : "None");
			input3.onClick.AddListener(delegate
			{
				WindowManager.Instance.MultiWindow.Show("Material", Materials.Select((Material x) => x.name), delegate(int x)
				{
					Material material2 = Materials[x];
					input3.GetComponentInChildren<Text>().text = material2.name;
					SetMetaValue(modMeta, field, atr, material2, GetIndex(input3.transform), true);
					if (atr.VarName == null)
					{
						modMeta.Target.gameObject.GetComponent<Renderer>().sharedMaterial = material2;
					}
				}, false);
			});
			input3.transform.SetParent(parent, false);
			SetHeader(header, input3);
			if (!atr.IsArray && !atr.IsList)
			{
				_inspectorElements[field] = input3.gameObject;
			}
			break;
		}
		case FurnModAttr.VariableType.Enum:
		{
			Button input2 = UnityEngine.Object.Instantiate(ObjectButtonPrefab);
			input2.GetComponentInChildren<Text>().text = GetFieldValue(modMeta, field, atr, idx).ToString();
			input2.onClick.AddListener(delegate
			{
				object[] values = Enum.GetValues(field.FieldType).Cast<object>().ToArray();
				WindowManager.Instance.MultiWindow.Show("Value", values.Select((object x) => x.ToString()), delegate(int x)
				{
					object obj2 = values[x];
					input2.GetComponentInChildren<Text>().text = obj2.ToString();
					SetMetaValue(modMeta, field, atr, obj2, GetIndex(input2.transform));
				}, false);
			});
			input2.transform.SetParent(parent, false);
			SetHeader(header, input2);
			if (!atr.IsArray && !atr.IsList)
			{
				_inspectorElements[field] = input2.gameObject;
			}
			break;
		}
		case FurnModAttr.VariableType.Vector2:
		{
			GameObject prefab5 = UnityEngine.Object.Instantiate(ThreeInputPrefab);
			InputField[] input15 = prefab5.GetComponentsInChildren<InputField>();
			Vector2 vector2 = (Vector2)GetFieldValue(modMeta, field, atr, idx);
			input15[0].text = vector2.x.ToString("N");
			input15[1].text = vector2.y.ToString("N");
			input15[0].GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1f);
			RectTransform component = input15[1].GetComponent<RectTransform>();
			component.anchorMin = new Vector2(0.5f, 0f);
			component.anchorMax = new Vector2(1f, 1f);
			UnityEngine.Object.Destroy(input15[2].gameObject);
			for (int num5 = 0; num5 < input15.Length - 1; num5++)
			{
				input15[num5].onEndEdit.AddListener(delegate
				{
					int index = GetIndex(prefab5.transform);
					Vector2 vector3 = (Vector2)GetFieldValue(modMeta, field, atr, index);
					vector3 = new Vector2(input15[0].text.ConvertToFloatDef(vector3.x), input15[1].text.ConvertToFloatDef(vector3.y));
					SetMetaValue(modMeta, field, atr, vector3, index);
					input15[0].text = vector3.x.ToString("N");
					input15[1].text = vector3.y.ToString("N");
				});
			}
			prefab5.transform.SetParent(parent, false);
			SetHeader(header, prefab5);
			if (!atr.IsArray && !atr.IsList)
			{
				_inspectorElements[field] = prefab5;
			}
			break;
		}
		case FurnModAttr.VariableType.Vector3:
		{
			GameObject prefab3 = UnityEngine.Object.Instantiate(ThreeInputPrefab);
			InputField[] input10 = prefab3.GetComponentsInChildren<InputField>();
			Vector3 vector = (Vector3)GetFieldValue(modMeta, field, atr, idx);
			input10[0].text = vector.x.ToString("N");
			input10[1].text = vector.y.ToString("N");
			input10[2].text = vector.z.ToString("N");
			for (int num3 = 0; num3 < input10.Length; num3++)
			{
				input10[num3].onEndEdit.AddListener(delegate
				{
					int index = GetIndex(prefab3.transform);
					Vector3 vector3 = (Vector3)GetFieldValue(modMeta, field, atr, index);
					vector3 = new Vector3(input10[0].text.ConvertToFloatDef(vector3.x), input10[1].text.ConvertToFloatDef(vector3.y), input10[2].text.ConvertToFloatDef(vector3.z));
					SetMetaValue(modMeta, field, atr, vector3, index);
					input10[0].text = vector3.x.ToString("N");
					input10[1].text = vector3.y.ToString("N");
					input10[2].text = vector3.z.ToString("N");
				});
			}
			prefab3.transform.SetParent(parent, false);
			SetHeader(header, prefab3);
			if (!atr.IsArray && !atr.IsList)
			{
				_inspectorElements[field] = prefab3;
			}
			break;
		}
		case FurnModAttr.VariableType.FurnitureStyle:
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(FStylePrefab);
			Button[] componentsInChildren = gameObject.GetComponentsInChildren<Button>();
			Image[] images = gameObject.GetComponentsInChildren<Image>();
			FurnitureStyle style = (FurnitureStyle)GetFieldValue(modMeta, field, atr, idx);
			images[0].color = (style.Color1 ?? SVector3.Zero).ToColor().Alpha(1f);
			images[1].color = (style.Color2 ?? SVector3.Zero).ToColor().Alpha(1f);
			images[2].color = (style.Color3 ?? SVector3.Zero).ToColor().Alpha(1f);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				int i2 = i;
				componentsInChildren[i].onClick.AddListener(delegate
				{
					SetFurnColor(0, style[0] ?? SVector3.Zero);
					SetFurnColor(1, style[1] ?? SVector3.Zero);
					SetFurnColor(2, style[2] ?? SVector3.Zero);
					WindowManager.SpawnColorDialog(delegate(Color c)
					{
						style[i2] = c;
						images[i2].color = c;
						SetFurnColor(i2, c);
					}, style[i2] ?? SVector3.Zero, null, ResetFurnColor);
				});
			}
			gameObject.transform.SetParent(parent, false);
			SetHeader(header, gameObject);
			if (!atr.IsArray && !atr.IsList)
			{
				_inspectorElements[field] = gameObject;
			}
			break;
		}
		}
	}

	private void ResetFurnColor()
	{
		Furniture component = ActiveObject.GetComponent<Furniture>();
		FurnCompMeta furnCompMeta = CurrentMeta.FirstOrDefaultOf<FurnCompMeta>();
		component.ColorPrimary = furnCompMeta.PrimaryColor;
		component.ColorSecondary = furnCompMeta.SecondaryColor;
		component.ColorTertiary = furnCompMeta.TertiaryColor;
		RefreshLightColor();
	}

	private void SetFurnColor(int i, Color c)
	{
		Furniture component = ActiveObject.GetComponent<Furniture>();
		switch (i)
		{
		case 0:
			component.ColorPrimary = c;
			break;
		case 1:
			component.ColorSecondary = c;
			break;
		case 2:
			component.ColorTertiary = c;
			break;
		}
		RefreshLightColor();
	}

	private void SetMetaValue(FurnModMeta modMeta, FieldInfo field, FurnModAttr at, object value, int arrIdx, bool forceReflect = false)
	{
		object obj = ((modMeta is FurnGenericMeta) ? ((object)modMeta.Target) : ((object)modMeta));
		if (at.IsArray || at.IsList)
		{
			(field.GetValue(obj) as IList)[arrIdx] = value;
		}
		else
		{
			field.SetValue(obj, value);
		}
		modMeta.Changed = true;
		if (at.ReflectProp != null)
		{
			if (at.IsArray || at.IsList)
			{
				(modMeta.Target.GetType().GetProperty(at.ReflectProp).GetValue(modMeta.Target) as IList)[arrIdx] = value;
			}
			else
			{
				modMeta.Target.GetType().GetProperty(at.ReflectProp).SetValue(modMeta.Target, value);
			}
		}
		else if ((forceReflect || at.ReflectTarget) && at.VarName != null)
		{
			modMeta.SetTargetField(field, at, arrIdx);
		}
		if (at.CallMethod != null)
		{
			modMeta.GetType().GetMethod(at.CallMethod, BindingFlags.Instance | BindingFlags.Public).Invoke(modMeta, null);
		}
		UpdateActiveElements();
	}

	private void Awake()
	{
		Instance = this;
	}

	public void GenerateBoundary()
	{
		if (!(ActiveObject != null) || !(ActivePrefab is Furniture))
		{
			return;
		}
		Furniture furn = ActiveObject.GetComponent<Furniture>();
		furn.MeshBoundary = null;
		bool used;
		Vector2[] bounds = FurnitureLoader.GenerateBounds(furn, false, out used);
		if (!used)
		{
			WindowManager.Instance.ShowMessageBox("Build and nav boundaries are not recommended for this furniture.\nDo you want to generate them anyway?", true, DialogWindow.DialogType.Question, delegate
			{
				bounds = FurnitureLoader.GenerateBounds(furn, true, out used);
				FinishBoundGeneration(furn, bounds);
			}, null, delegate
			{
				FinishBoundGeneration(furn, bounds);
			});
		}
		else
		{
			FinishBoundGeneration(furn, bounds);
		}
	}

	private void FinishBoundGeneration(Furniture furn, Vector2[] bounds)
	{
		FurnCompMeta furnCompMeta = CurrentMeta.OfType<FurnCompMeta>().First();
		furnCompMeta.Bottom = furn.Height1;
		furnCompMeta.Top = furn.Height2;
		furnCompMeta.XGridOffset = furn.OnXEdge;
		furnCompMeta.YGridOffset = furn.OnYEdge;
		furnCompMeta.YOffset = furn.YOffset;
		furnCompMeta.WallWidth = furn.WallWidth;
		furnCompMeta.Collider.InitFields();
		if (!furnCompMeta.WallFurniture && furn.BuildBoundary != null && furn.BuildBoundary.Length != 0)
		{
			if (bounds == null || bounds.Length < 3)
			{
				bounds = furn.CalculateBoundary().ToArray();
			}
			furn.MeshBoundary = bounds;
		}
		if (furnCompMeta == ActiveMeta || furnCompMeta.Collider == ActiveMeta)
		{
			SetInspector(ActiveMeta);
		}
		SetStage();
	}

	public Vector3[] GetMinMax(GameObject obj)
	{
		Vector3 vector = Vector3.one * 500f;
		Vector3 vector2 = Vector3.one * -500f;
		MeshFilter[] componentsInChildren = obj.GetComponentsInChildren<MeshFilter>();
		foreach (MeshFilter meshFilter in componentsInChildren)
		{
			Renderer component = meshFilter.GetComponent<Renderer>();
			if (component == null || !component.enabled)
			{
				continue;
			}
			MeshFilter meshFilter2 = meshFilter;
			if (meshFilter.sharedMesh != null)
			{
				for (int j = 0; j < meshFilter.sharedMesh.vertices.Length; j++)
				{
					Vector3 v = meshFilter2.transform.localToWorldMatrix.MultiplyPoint(meshFilter.sharedMesh.vertices[j]);
					vector = Utilities.MinVector(vector, v);
					vector2 = Utilities.MaxVector(vector2, v);
				}
			}
		}
		return new Vector3[2] { vector, vector2 };
	}

	private static int CompareNode(TydNode a, TydNode b)
	{
		TydString obj = a as TydString;
		TydString tydString = b as TydString;
		if (obj != null)
		{
			if (tydString != null)
			{
				return 0;
			}
			return -1;
		}
		if (tydString != null)
		{
			return 1;
		}
		return TydNodeOrder.GetOrDefault(a.Name, 2147483646).CompareTo(TydNodeOrder.GetOrDefault(b.Name, 2147483646));
	}

	public void CreateFurniture()
	{
		List<Furniture> mods = (from x in ObjectDatabase.Instance.GetAllFurniture()
			select x.GetComponent<Furniture>() into x
			where x.AllowForMods && x.Queryable()
			select x).ToList();
		if (mods.Count <= 0)
		{
			return;
		}
		WindowManager.Instance.MultiWindow.Show("Base", mods.Select((Furniture x) => x.name), delegate(int baseF)
		{
			WindowManager.SpawnInputDialog("Name", "Name", "Enter name here", delegate(string name)
			{
				Furniture furniture = UnityEngine.Object.Instantiate(mods[baseF]);
				furniture.isTemporary = true;
				FurnitureLoader.StripFurnitureGameObject(furniture.gameObject, true);
				furniture.Thumbnail = null;
				furniture.name = name;
				furniture.LocalizedName = name;
				furniture.FileName = Path.Combine(ActiveMod.Root, name + ".tyd");
				furniture.BaseObject = mods[baseF];
				furniture.gameObject.SetActive(false);
				StartCoroutine(SelectItem(furniture));
				IsNew = true;
			});
		}, false);
	}

	public void CreateSegment()
	{
		List<RoomSegment> mods = (from x in ObjectDatabase.Instance.RoomSegments
			select x.GetComponent<RoomSegment>() into x
			where x.AllowForMods && !x.OnlyInEditor
			select x).ToList();
		if (mods.Count <= 0)
		{
			return;
		}
		WindowManager.Instance.MultiWindow.Show("Base", mods.Select((RoomSegment x) => x.name), delegate(int baseF)
		{
			WindowManager.SpawnInputDialog("Name", "Name", "Enter name here", delegate(string name)
			{
				RoomSegment roomSegment = UnityEngine.Object.Instantiate(mods[baseF]);
				roomSegment.IsTemporary = true;
				FurnitureLoader.StripSegmentGameObject(roomSegment.gameObject);
				roomSegment.Thumbnail = null;
				roomSegment.name = name;
				roomSegment.LocalizedName = name;
				roomSegment.FileName = Path.Combine(ActiveMod.Root, name + ".tyd");
				roomSegment.BaseObject = mods[baseF];
				roomSegment.gameObject.SetActive(false);
				StartCoroutine(SelectItem(roomSegment));
				IsNew = true;
			});
		}, false);
	}

	public void SaveToPrefab()
	{
		if (!(ActiveObject != null) || ActiveMod == null)
		{
			return;
		}
		if (ActivePrefab.Thumbnail == null)
		{
			WindowManager.Instance.ShowMessageBox("Please create a thumbnail before saving", true, DialogWindow.DialogType.Error);
			return;
		}
		bool flag = ActivePrefab is Furniture;
		string fileName = ActivePrefab.FileName;
		TydTable tydTable = (File.Exists(fileName) ? (TydFromText.ParseOne(File.ReadAllText(fileName)) as TydTable) : null);
		if (tydTable == null)
		{
			tydTable = new TydTable(GetTypeName());
		}
		if (tydTable != null)
		{
			TydList obj = tydTable.FindNode("Models") as TydList;
			if (obj != null)
			{
				obj.Nodes.Clear();
			}
			tydTable.RemoveNode("Furniture/ColorableLights");
			tydTable.RemoveNode("LampScript");
			tydTable.Nodes.RemoveAll((TydNode x) =>
			{
				TydTable tydTable2;
				return (tydTable2 = x as TydTable) != null && "DoorScript".Equals(tydTable2.Name);
			});
			tydTable.RemoveNode("AutoBounds");
			tydTable.RemoveNode("Transforms");
			if (ActivePrefab.BaseObject != null)
			{
				tydTable.SetNode("Base", ActivePrefab.BaseObject.name, true);
			}
			else
			{
				tydTable.RemoveNode("Base");
			}
			tydTable.Nodes.RemoveAll((TydNode x) =>
			{
				TydTable tydTable2;
				return (tydTable2 = x as TydTable) != null && "Light".Equals(tydTable2.Name);
			});
			tydTable.Nodes.RemoveAll((TydNode x) => x.Name.Equals("LODFurn"));
			tydTable.RemoveNode("Furniture/LODGroups");
			bool flag2 = tydTable.RemoveNode("InteractionPoints") || InterDeleted || CurrentMeta.OfType<FurnInteractionMeta>().Any((FurnInteractionMeta x) => x.Changed);
			if (flag2 && flag)
			{
				tydTable.AddChild(new TydList("InteractionPoints"));
			}
			bool flag3 = tydTable.RemoveNode("SnapPoints") || SnapDeleted || CurrentMeta.OfType<FurnSnapMeta>().Any((FurnSnapMeta x) => x.Changed);
			if (flag3 && flag)
			{
				tydTable.AddChild(new TydList("SnapPoints"));
				int num = 0;
				foreach (FurnSnapMeta item in CurrentMeta.OfType<FurnSnapMeta>())
				{
					item.ID = num;
					num++;
				}
			}
			for (int num2 = 0; num2 < CurrentMeta.Count; num2++)
			{
				FurnModMeta furnModMeta = CurrentMeta[num2];
				if ((flag2 || !(furnModMeta is FurnInteractionMeta)) && (flag3 || !(furnModMeta is FurnSnapMeta)))
				{
					furnModMeta.WriteToTyD(tydTable);
				}
			}
			tydTable.Nodes.Sort(CompareNode);
			File.WriteAllText(fileName, TydToText.Write(tydTable, true));
			WindowManager.Instance.ShowMessageBox("File saved succcessfully!", true, DialogWindow.DialogType.Information);
			if (IsNew)
			{
				IsNew = false;
				CreateButton(ActivePrefab);
			}
		}
		FurnitureMaterialEditor.SaveMaterials(Materials, ActiveMod);
		WallSnap component = ActiveObject.GetComponent<WallSnap>();
		ActivePrefab.LocalizedName = component.LocalizedName;
		ActivePrefab.ButtonDescription = component.ButtonDescription;
		ActivePrefab.PrimaryColorName = component.PrimaryColorName;
		ActivePrefab.SecondaryColorName = component.SecondaryColorName;
		ActivePrefab.TertiaryColorName = component.TertiaryColorName;
		ActiveMod.GenerateLocalization();
	}

	private void Update()
	{
		if (LODToggle.isOn && ActiveObject != null)
		{
			Furniture component = ActiveObject.GetComponent<Furniture>();
			if (component != null && component.LODGroups != null)
			{
				float sqrMagnitude = (component.transform.position - CamTool.MainCamTransform.position).sqrMagnitude;
				int num = 0;
				if (sqrMagnitude > 1600f)
				{
					num = 2;
				}
				else if (sqrMagnitude > 625f)
				{
					num = 1;
				}
				for (int i = 0; i < component.LODGroups.Count; i++)
				{
					component.LODGroups[i].SetLOD(num);
				}
				LODLabel.text = "LOD" + num;
			}
		}
		if (ActiveHinge != null)
		{
			float state = (Time.realtimeSinceStartup / 2f * ActiveHinge.Speed).PingPong() * 2f - 1f;
			ActiveHinge.SetState(state);
		}
	}

	public void SetLOD()
	{
		if (!(ActiveObject != null))
		{
			return;
		}
		Furniture component = ActiveObject.GetComponent<Furniture>();
		int num = Mathf.RoundToInt(LODSlider.value);
		if (component != null && component.LODGroups != null)
		{
			for (int i = 0; i < component.LODGroups.Count; i++)
			{
				component.LODGroups[i].SetLOD(num);
			}
			LODLabel.text = "LOD" + num;
		}
	}

	private IEnumerator SelectItem(WallSnap item)
	{
		Furniture localItem;
		if ((object)(localItem = item as Furniture) != null)
		{
			return SelectFurniture(localItem);
		}
		RoomSegment localItem2;
		if ((object)(localItem2 = item as RoomSegment) != null)
		{
			return SelectSegment(localItem2);
		}
		return null;
	}

	private IEnumerator SelectFurniture(Furniture localItem)
	{
		ValidForFurniture.ForEach(delegate(GameObject x)
		{
			x.gameObject.SetActive(true);
		});
		ValidForSegment.ForEach(delegate(GameObject x)
		{
			x.gameObject.SetActive(false);
		});
		EditPanel.SetActive(true);
		DummyActor.transform.SetParent(null, true);
		DummyActor.gameObject.SetActive(false);
		CleanUp();
		IsNew = false;
		InterDeleted = false;
		SnapDeleted = false;
		ActivePrefab = localItem;
		GameObject gameObject = UnityEngine.Object.Instantiate(localItem.gameObject);
		PipLight[] componentsInChildren = gameObject.GetComponentsInChildren<PipLight>(true);
		foreach (PipLight pipLight in componentsInChildren)
		{
			pipLight.enabled = false;
			Light light = pipLight.gameObject.AddComponent<Light>();
			light.shadows = LightShadows.Hard;
			light.color = pipLight.color;
			light.range = pipLight.range;
			light.intensity = pipLight.intensity;
		}
		Furniture component = gameObject.GetComponent<Furniture>();
		gameObject.name = gameObject.name.Replace("(Clone)", "").Trim();
		ActiveObject = gameObject;
		if (component.AtlasObject != null)
		{
			AtlasSlider.gameObject.SetActive(true);
			AtlasLabel.SetActive(true);
			AtlasSlider.value = 0f;
			AtlasChange();
			AtlasSlider.maxValue = component.AtlasCount - 1;
		}
		else
		{
			AtlasSlider.gameObject.SetActive(false);
			AtlasLabel.SetActive(false);
		}
		InitMeta(component);
		component.isTemporary = true;
		component.gameObject.SetActive(true);
		Thumb.sprite = localItem.Thumbnail;
		SetLOD();
		SetStage();
		RefreshCutouts();
		yield return new WaitForEndOfFrame();
		RefreshLightColor();
	}

	private void CleanUp()
	{
		if (!(ActiveObject != null))
		{
			return;
		}
		GameObject activeObject = ActiveObject;
		ActiveObject = null;
		UpdateTags();
		ActiveObject = activeObject;
		if (!IsNew && ActiveMod != null && ActivePrefab != null)
		{
			GameObject obj = Buttons[ActivePrefab];
			int siblingIndex = obj.transform.GetSiblingIndex();
			UnityEngine.Object.Destroy(obj.gameObject);
			string fileName = ActivePrefab.FileName;
			Furniture furniture;
			if ((object)(furniture = ActivePrefab as Furniture) != null)
			{
				furniture.isTemporary = true;
				ObjectDatabase.Instance.RemoveFurniture(ActivePrefab.gameObject);
				ActiveMod.Furniture.Remove(ActivePrefab.gameObject);
			}
			else if (ActivePrefab is RoomSegment)
			{
				ObjectDatabase.Instance.RemoveSegment(ActivePrefab.gameObject);
				ActiveMod.RoomSegments.Remove(ActivePrefab.gameObject);
			}
			UnityEngine.Object.Destroy(ActivePrefab.gameObject);
			WallSnap wallSnap = FurnitureLoader.ReloadSingleFurniture(ActiveMod, fileName);
			if (wallSnap != null)
			{
				CreateButton(wallSnap).transform.SetSiblingIndex(siblingIndex);
			}
		}
		UnityEngine.Object.Destroy(ActiveObject);
	}

	private IEnumerator SelectSegment(RoomSegment localItem)
	{
		ValidForFurniture.ForEach(delegate(GameObject x)
		{
			x.gameObject.SetActive(false);
		});
		ValidForSegment.ForEach(delegate(GameObject x)
		{
			x.gameObject.SetActive(true);
		});
		EditPanel.SetActive(true);
		DummyActor.transform.SetParent(null, true);
		DummyActor.gameObject.SetActive(false);
		CleanUp();
		IsNew = false;
		InterDeleted = false;
		SnapDeleted = false;
		ActivePrefab = localItem;
		GameObject gameObject = UnityEngine.Object.Instantiate(localItem.gameObject);
		RoomSegment component = gameObject.GetComponent<RoomSegment>();
		gameObject.name = gameObject.name.Replace("(Clone)", "").Trim();
		ActiveObject = gameObject;
		if (component.AtlasObject != null)
		{
			AtlasSlider.gameObject.SetActive(true);
			AtlasLabel.SetActive(true);
			AtlasSlider.value = 0f;
			AtlasChange();
			AtlasSlider.maxValue = component.AtlasCount - 1;
		}
		else
		{
			AtlasSlider.gameObject.SetActive(false);
			AtlasLabel.SetActive(false);
		}
		InitMeta(component);
		component.IsTemporary = true;
		component.gameObject.SetActive(true);
		Thumb.sprite = localItem.Thumbnail;
		SetLOD();
		SetStage();
		RefreshCutouts();
		UpdateTags();
		yield return new WaitForEndOfFrame();
	}

	public void SetStage()
	{
		if (ActivePrefab is Furniture)
		{
			Furniture furn = ActiveObject.GetComponent<Furniture>();
			if (SnapOnTemp != null)
			{
				UnityEngine.Object.Destroy(SnapOnTemp);
			}
			CamTool.WallCube.SetActive(furn.WallFurn);
			CamTool.SideWall1.SetActive(false);
			CamTool.SideWall2.SetActive(false);
			CamTool.UpperWall.SetActive(false);
			if (furn.WallFurn)
			{
				CamTool.GroundPlane.transform.position = new Vector3(0f, 0f, -0.1f);
			}
			else
			{
				CamTool.GroundPlane.transform.position = new Vector3(furn.OnXEdge ? 0f : 0.5f, 0f, furn.OnYEdge ? 0f : 0.5f);
			}
			SnapFurnToggle.gameObject.SetActive(false);
			if (furn.IsSnapping && furn.SnapsTo.Length != 0)
			{
				Furniture furniture = (from x in ObjectDatabase.Instance.GetAllFurniture()
					select x.GetComponent<Furniture>()).FirstOrDefault((Furniture x) => x.SnapPoints.Any((SnapPoint y) => y.Name.Equals(furn.SnapsTo[0])));
				if (furniture != null)
				{
					SnapFurnToggle.gameObject.SetActive(true);
					Furniture furniture2 = UnityEngine.Object.Instantiate(furniture);
					furniture2.isTemporary = true;
					furniture2.gameObject.gameObject.SetActive(SnapFurnToggle.isOn);
					SnapOnTemp = furniture2.gameObject;
					SnapPoint snapPoint = furniture2.SnapPoints.First((SnapPoint x) => x.Name.Equals(furn.SnapsTo[0]));
					Vector3 position = snapPoint.transform.position;
					furn.transform.position = new Vector3(0f, position.y, 0f);
					Quaternion quaternion = Quaternion.Inverse(snapPoint.transform.rotation);
					furniture2.transform.position = quaternion * new Vector3(0f - position.x, 0f, 0f - position.z);
					furniture2.transform.rotation = quaternion;
				}
			}
			else if (furn.WallFurn && furn.CustomHeight)
			{
				furn.transform.position = new Vector3(0f, furn.WallHeight, 0f);
			}
			else
			{
				furn.transform.position = Vector3.zero;
			}
		}
		else if (ActivePrefab is RoomSegment)
		{
			RoomSegment component = ActiveObject.GetComponent<RoomSegment>();
			CamTool.WallCube.SetActive(false);
			CamTool.SideWall1.SetActive(true);
			CamTool.SideWall2.SetActive(true);
			CamTool.UpperWall.SetActive(true);
			CamTool.UpperWall.transform.localScale = new Vector3(component.WallWidth, 0.2f, 1f);
			CamTool.SideWall1.transform.position = new Vector3(component.WallWidth / 2f + 0.5f, 1f, 0f);
			CamTool.SideWall2.transform.position = new Vector3((0f - component.WallWidth) / 2f - 0.5f, 1f, 0f);
			CamTool.GroundPlane.transform.position = new Vector3(component.WallWidth / 2f, 0f, 0f);
		}
		FixPivot();
	}

	public void FixPivot()
	{
		Vector3[] minMax = GetMinMax(ActiveObject);
		CamTool.PivotTransform.transform.position = (minMax[0] + minMax[1]) * 0.5f;
		if (CurrentGizmo != null)
		{
			CurrentGizmo.InitOffsets();
		}
	}

	private Button CreateButton(WallSnap item)
	{
		WallSnap localItem = item;
		GameObject gameObject = UnityEngine.Object.Instantiate(ButtonPrefab);
		gameObject.GetComponentInChildren<Text>().text = item.name;
		gameObject.GetComponentsInChildren<Image>()[1].sprite = item.Thumbnail;
		Furniture furniture;
		gameObject.GetComponentsInChildren<Image>()[2].enabled = (object)(furniture = item as Furniture) != null && !furniture.IsSnapping && !furniture.WallFurn && (furniture.BuildBoundary == null || furniture.BuildBoundary.Length == 0 || (!furniture.InFloor && furniture.Height2 >= 0f && furniture.Height1 < 1f && (furniture.NavBoundary == null || furniture.NavBoundary.Length == 0)));
		Button component = gameObject.GetComponent<Button>();
		component.onClick.AddListener(delegate
		{
			if (ActivePrefab != item)
			{
				if (ActiveObject != null && ActiveMod != null)
				{
					WindowManager.Instance.ShowMessageBox("Are you sure you want change object?\nAny unsaved changes will be discarded", true, DialogWindow.DialogType.Question, delegate
					{
						StartCoroutine(SelectItem(localItem));
					});
				}
				else
				{
					StartCoroutine(SelectItem(localItem));
				}
			}
		});
		gameObject.transform.SetParent(ButtonPanel.transform);
		Buttons[item] = gameObject;
		return component;
	}

	public Mesh LoadMesh(string filePath, string relativeFile, bool showError)
	{
		Mesh mesh = null;
		try
		{
			List<Mesh> list = ObjImporter.ImportMeshes(File.ReadAllText(filePath));
			if (list.Count == 1)
			{
				mesh = list[0];
			}
			else if (list.Count > 1)
			{
				mesh = new Mesh();
				mesh.CombineMeshes(list.SelectInPlace((Mesh x) => new CombineInstance
				{
					mesh = x,
					subMeshIndex = 0,
					transform = Matrix4x4.identity
				}));
				list.ForEach(delegate(Mesh x)
				{
					UnityEngine.Object.Destroy(x);
				});
			}
			else if (showError)
			{
				WindowManager.Instance.ShowMessageBox("No mesh data to load", true, DialogWindow.DialogType.Error);
			}
		}
		catch (Exception ex)
		{
			if (showError)
			{
				WindowManager.Instance.ShowMessageBox("Failed loading mesh:\n" + ex.ToString(), true, DialogWindow.DialogType.Error);
			}
		}
		if (mesh != null)
		{
			mesh.name = relativeFile;
			Meshes.Add(mesh);
			FurnitureMod activeMod = ActiveMod;
			if (activeMod != null)
			{
				activeMod.Meshes.Add(mesh);
			}
		}
		return mesh;
	}

	public static string ReplaceRoot(string root, string file)
	{
		string fullPath = Path.GetFullPath(file);
		return fullPath.Substring(root.Length, fullPath.Length - root.Length).Replace('\\', '/').TrimStart('/');
	}

	public static string NormalizePath(string path)
	{
		return path.ToUpper().Replace('\\', '/').TrimEnd('/');
	}

	private void CheckIconics()
	{
		List<WallSnap> fs = (from x in ObjectDatabase.Instance.GetAllFurniture()
			select x.GetComponent<WallSnap>() into x
			where string.IsNullOrEmpty(x.FileName)
			select x).ToList();
		WallSnap[] fs2 = ActiveMod.Furniture.SelectInPlace((GameObject x) => x.GetComponent<WallSnap>());
		HashSet<string> hashSet = new HashSet<string>();
		HashSet<string> hashSet2 = new HashSet<string>();
		AddCats(hashSet, fs2);
		AddIconics(hashSet2, fs);
		AddIconics(hashSet2, fs2);
		foreach (string item in hashSet)
		{
			if (!hashSet2.Contains(item))
			{
				AddIssue("You should assign a furniture's IsIconic to the following new category: '" + item + "', to get a thumbnail in the build menu");
			}
		}
		fs = (from x in ObjectDatabase.Instance.RoomSegments
			select x.GetComponent<WallSnap>() into x
			where string.IsNullOrEmpty(x.FileName)
			select x).ToList();
		fs2 = ActiveMod.RoomSegments.SelectInPlace((GameObject x) => x.GetComponent<WallSnap>());
		hashSet.Clear();
		hashSet2.Clear();
		AddCats(hashSet, fs2);
		AddIconics(hashSet2, fs);
		AddIconics(hashSet2, fs2);
		foreach (string item2 in hashSet)
		{
			if (!hashSet2.Contains(item2))
			{
				AddIssue("You should assign a segment's IsIconic to the following new category: '" + item2 + "', to get a thumbnail in the build menu");
			}
		}
	}

	private void AddIconics(HashSet<string> ic, IList<WallSnap> fs)
	{
		for (int i = 0; i < fs.Count; i++)
		{
			WallSnap wallSnap = fs[i];
			if (wallSnap.IsIconic != null)
			{
				ic.AddRange(wallSnap.IsIconic.Where((string x) => !string.IsNullOrWhiteSpace(x)));
			}
		}
	}

	private void AddCats(HashSet<string> cats, IList<WallSnap> fs)
	{
		for (int i = 0; i < fs.Count; i++)
		{
			WallSnap wallSnap = fs[i];
			Furniture furniture;
			RoomSegment roomSegment;
			if ((object)(furniture = wallSnap as Furniture) != null)
			{
				if (furniture.Category != null)
				{
					if (furniture.Category.Length != 0 && "Construction".Equals(furniture.Category[0]))
					{
						cats.Add(furniture.Type);
					}
					else
					{
						cats.AddRange(furniture.Category.Where((string x) => !string.IsNullOrWhiteSpace(x)));
					}
				}
				if (!string.IsNullOrWhiteSpace(furniture.FunctionCategory))
				{
					cats.Add(furniture.FunctionCategory);
				}
			}
			else if ((object)(roomSegment = wallSnap as RoomSegment) != null && !string.IsNullOrWhiteSpace(roomSegment.Type))
			{
				cats.Add(roomSegment.Type);
			}
		}
	}

	private void AddIssue(string issue)
	{
		GameObject e = UnityEngine.Object.Instantiate(IssuePrefab);
		e.GetComponentInChildren<Text>().text = issue;
		e.GetComponentInChildren<Button>().onClick.AddListener(delegate
		{
			UnityEngine.Object.Destroy(e.gameObject);
			if (IssuePanel.transform.childCount <= 2)
			{
				IssueMainPanel.SetActive(false);
			}
		});
		e.transform.SetParent(IssuePanel, false);
	}

	private void Initialize(IEnumerable<Furniture> furns, IEnumerable<RoomSegment> segments, FurnitureMod mod)
	{
		ActiveMod = mod;
		Materials.Clear();
		Materials.Add(ObjectDatabase.Instance.CombineFurnitureMaterial);
		Material[] modMats = ObjectDatabase.Instance.ModMats;
		foreach (Material item in modMats)
		{
			Materials.Add(item);
		}
		Meshes.Clear();
		AddFurnButton.SetActive(mod != null);
		if (mod != null)
		{
			if (mod.Issues != null && mod.Issues.Count > 0)
			{
				for (int j = 0; j < mod.Issues.Count; j++)
				{
					AddIssue(mod.Issues[j]);
				}
			}
			else
			{
				IssueMainPanel.SetActive(false);
			}
			CheckIconics();
			Meshes.AddRange(mod.Meshes);
			string[] source = Meshes.SelectInPlace((Mesh x) => NormalizePath(Path.Combine(mod.Root, x.name)));
			string[] files = Directory.GetFiles(mod.Root, "*.obj", SearchOption.AllDirectories);
			foreach (string text in files)
			{
				string text2 = NormalizePath(text);
				if (source.None(text2.Equals))
				{
					LoadMesh(text, ReplaceRoot(mod.Root, text), false);
				}
			}
			HashSet<Texture2D> thumbs = mod.Furniture.Select((GameObject x) => x.GetComponent<Furniture>().Thumbnail.texture).ToHashSet();
			Textures.AddRange(mod.Textures.Where((Texture2D x) => !thumbs.Contains(x)));
			source = Textures.Select((Texture2D x) => NormalizePath(x.name)).Concat(thumbs.Select((Texture2D x) => NormalizePath(x.name))).ToArray();
			files = Directory.GetFiles(mod.Root, "*.png", SearchOption.AllDirectories);
			foreach (string text3 in files)
			{
				string upper = NormalizePath(text3);
				if (source.None((string x) => upper.EndsWith(x)))
				{
					Texture2D texture2D = new Texture2D(4, 4);
					texture2D.LoadImage(File.ReadAllBytes(text3));
					texture2D.name = ReplaceRoot(mod.Root, text3);
					Textures.Add(texture2D);
				}
			}
			Materials.AddRange(mod.Materials);
		}
		foreach (Furniture furn in furns)
		{
			if (ActiveMod != null && (furn.FileName == null || !furn.FileName.ToLower().EndsWith("tyd")))
			{
				return;
			}
			CreateButton(furn);
		}
		if (segments == null)
		{
			return;
		}
		foreach (RoomSegment segment in segments)
		{
			if (ActiveMod != null && (segment.FileName == null || !segment.FileName.ToLower().EndsWith("tyd")))
			{
				break;
			}
			CreateButton(segment);
		}
	}

	public void Exit()
	{
		WindowManager.Instance.ShowMessageBox("Are you sure you want to exit?\nAny unsaved changes will be discarded", true, DialogWindow.DialogType.Question, delegate
		{
			if (ActiveMod != null)
			{
				foreach (Mesh mesh in Meshes)
				{
					if (!ActiveMod.Meshes.Contains(mesh))
					{
						UnityEngine.Object.Destroy(mesh);
					}
				}
				foreach (Texture2D texture in Textures)
				{
					if (!ActiveMod.Textures.Contains(texture))
					{
						UnityEngine.Object.Destroy(texture);
					}
				}
				foreach (Material material in Materials)
				{
					if (!ActiveMod.Materials.Contains(material) && material != ObjectDatabase.Instance.CombineFurnitureMaterial && !ObjectDatabase.Instance.ModMats.Contains(material))
					{
						UnityEngine.Object.Destroy(material);
					}
				}
				FurnitureLoader.ReLoadFurniture(ActiveMod);
			}
			FrameTransition.StartTransition(true);
			ErrorLogging.FirstOfScene = true;
			ErrorLogging.SceneChanging = true;
			DevConsole.Console.SaveConsole();
			SceneManager.LoadScene("MainMenu");
		});
	}

	private void Start()
	{
		TileMat.SetMatrix("_TextureRotation", Matrix4x4.TRS(Vector3.zero, Quaternion.LookRotation(Vector3.forward), Vector3.one * 250f));
		Shader.SetGlobalFloat("_SupportHeightCutoff", 1000f);
		ActorGenerator.Instance.ApplySavedStyle(ActorGenerator.Instance.GenerateStyle(UnityEngine.Random.value > 0.5f, "Default", 20f), DummyActor);
		DummyActor.gameObject.SetActive(false);
		MainPanel.SetActive(false);
		EditPanel.SetActive(false);
		LaunchPanelObj.gameObject.SetActive(true);
		bool flag = false;
		foreach (FurnitureMod mod in FurnitureLoader.LoadedFurniture)
		{
			if (!mod.CanUpload || (!mod.Furniture.Any((GameObject x) => x.GetComponent<Furniture>().FileName.ToLower().EndsWith("tyd")) && !mod.RoomSegments.Any((GameObject x) => x.GetComponent<RoomSegment>().FileName.ToLower().EndsWith("tyd"))))
			{
				continue;
			}
			Button button = UnityEngine.Object.Instantiate(ObjectButtonPrefab);
			button.GetComponentInChildren<Text>().text = mod.ItemTitle;
			button.onClick.AddListener(delegate
			{
				Initialize(mod.Furniture.Select((GameObject x) => x.GetComponent<Furniture>()), mod.RoomSegments.Select((GameObject x) => x.GetComponent<RoomSegment>()), mod);
				MainPanel.SetActive(true);
				LaunchPanelObj.gameObject.SetActive(false);
			});
			button.transform.SetParent(LaunchPanel, false);
			flag = true;
		}
		string path = Path.Combine(Utilities.GetRoot(), "Furniture");
		if (Directory.Exists(path))
		{
			string[] directories = Directory.GetDirectories(path);
			foreach (string dir in directories)
			{
				if (Directory.GetFiles(dir, "*.tyd").Length == 0 && Directory.GetFiles(dir, "*.xml").Length == 0)
				{
					Button button2 = UnityEngine.Object.Instantiate(ObjectButtonPrefab);
					button2.GetComponentInChildren<Text>().text = Path.GetFileName(dir).BlueHighlight().FontBold();
					button2.onClick.AddListener(delegate
					{
						Initialize(Array.Empty<Furniture>(), Array.Empty<RoomSegment>(), new FurnitureMod(dir));
						MainPanel.SetActive(true);
						LaunchPanelObj.gameObject.SetActive(false);
					});
					button2.transform.SetParent(LaunchPanel, false);
					flag = true;
				}
			}
		}
		if (flag)
		{
			return;
		}
		Button button3 = UnityEngine.Object.Instantiate(ObjectButtonPrefab);
		button3.GetComponentInChildren<Text>().text = "NoModsToEdit".Loc();
		string url = "https://swinc.net/wiki/index.php/Furniture_Modding";
		button3.onClick.AddListener(delegate
		{
			if (SteamManager.Initialized && SteamUtils.IsOverlayEnabled())
			{
				SteamFriends.ActivateGameOverlayToWebPage(url);
			}
			else
			{
				Application.OpenURL(url);
			}
		});
		button3.transform.SetParent(LaunchPanel, false);
		button3.GetComponent<RectTransform>().sizeDelta = new Vector2(0f, 64f);
		GUIToolTipper component = button3.GetComponent<GUIToolTipper>();
		component.Localize = false;
		component.TooltipDescription = url;
	}
}
