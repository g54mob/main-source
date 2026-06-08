using System;
using System.Collections.Generic;
using System.Linq;
using Dorfromantik;
using UnityEngine;
using UnityEngine.Serialization;

public class ElementGroupSegment : MonoBehaviour, ITileStateReceiver
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Predicate<Element> _003C_003E9__76_0;

		public static Predicate<ElementGroupSegment> _003C_003E9__82_0;

		public static Func<CustomInstanceInt, bool> _003C_003E9__101_0;

		public static Func<CustomInstanceInt, bool> _003C_003E9__101_1;

		internal bool _003CSetupElements_003Eb__76_0(Element x)
		{
			return x is DecorationElement;
		}

		internal bool _003CGetNeighborSegments_003Eb__82_0(ElementGroupSegment x)
		{
			return x == null;
		}

		internal bool _003CInitializeInstancedGroupShape_003Eb__101_0(CustomInstanceInt x)
		{
			return x.propertyName == Constants.MaterialParameters.GroupType;
		}

		internal bool _003CInitializeInstancedGroupShape_003Eb__101_1(CustomInstanceInt x)
		{
			return x.propertyName == Constants.MaterialParameters.GroupType;
		}
	}

	private Dictionary<ElementType, int> _003CElements_003Ek__BackingField;

	[SerializeField]
	private List<int> edges;

	[SerializeField]
	private Tile tile;

	[SerializeField]
	private int rotationIndex = -1;

	[SerializeField]
	private int segmentIndex;

	[SerializeField]
	private GroupType groupType;

	[SerializeField]
	private SegmentType segmentType;

	[SerializeField]
	private List<int> openLocalEdges;

	private List<Element> _003CAllElements_003Ek__BackingField = new List<Element>();

	[FormerlySerializedAs("tileEdgeDescriptionPrefab")]
	[SerializeField]
	private SegmentEdgeHighlight segmentEdgeHighlightPrefab;

	private List<SegmentEdgeHighlight> highlightedEdges = new List<SegmentEdgeHighlight>();

	public MeshRenderer groundTileReplacement;

	[SerializeField]
	private GameObject adaptiveObjectContainer;

	[SerializeField]
	[FormerlySerializedAs("groundShapeElementType")]
	private ElementType segmentGroundElementType;

	[SerializeField]
	private List<InstanceableVisual> allInstanceableElements = new List<InstanceableVisual>();

	[SerializeField]
	private Element elementPrefab;

	[SerializeField]
	[FormerlySerializedAs("instancedGroupShape")]
	private InstanceableVisual instanceableSegmentGround;

	private SegmentGround _003CSegmentFloor_003Ek__BackingField;

	private bool _003CHighlightingEdges_003Ek__BackingField;

	private ElementGroupSegment[] neighborSegments;

	private VehicleSegment vehicleSegment;

	private HybridSegment _003CHybridSegment_003Ek__BackingField;

	private ElementGroup _003CElementGroup_003Ek__BackingField;

	public Dictionary<ElementType, int> Elements
	{
		get
		{
			return _003CElements_003Ek__BackingField;
		}
		private set
		{
			_003CElements_003Ek__BackingField = value;
		}
	}

	public List<Element> AllElements
	{
		get
		{
			return _003CAllElements_003Ek__BackingField;
		}
		private set
		{
			_003CAllElements_003Ek__BackingField = value;
		}
	}

	public Tile Tile => tile;

	public List<int> Edges => edges;

	public int RotationIndex => rotationIndex;

	public int PrimaryVariant => SegmentType.primaryVariant;

	public int SubVariant => SegmentType.SubVariant;

	public int SegmentIndex => segmentIndex;

	public GroupType GroupType => groupType;

	public SegmentType SegmentType => segmentType;

	public SegmentGround SegmentFloor
	{
		get
		{
			return _003CSegmentFloor_003Ek__BackingField;
		}
		private set
		{
			_003CSegmentFloor_003Ek__BackingField = value;
		}
	}

	public List<InstanceableVisual> AllElementData => allInstanceableElements;

	public InstanceableVisual InstanceableSegmentGround => instanceableSegmentGround;

	public int OpenEdgeCount => openLocalEdges.Count;

	public Vector3 WorldCenterPos => base.transform.position + Quaternion.AngleAxis(60 * (RotationIndex + tile.RotationIndex), Vector3.up) * SegmentType.centerPos;

	public bool HighlightingEdges
	{
		get
		{
			return _003CHighlightingEdges_003Ek__BackingField;
		}
		private set
		{
			_003CHighlightingEdges_003Ek__BackingField = value;
		}
	}

	public HybridSegment HybridSegment
	{
		get
		{
			return _003CHybridSegment_003Ek__BackingField;
		}
		private set
		{
			_003CHybridSegment_003Ek__BackingField = value;
		}
	}

	public ElementGroup ElementGroup
	{
		get
		{
			return _003CElementGroup_003Ek__BackingField;
		}
		private set
		{
			_003CElementGroup_003Ek__BackingField = value;
		}
	}

	public event Action<int, int, Tile, ElementGroupSegment> OnSegmentNeighborChanged;

	public event Action OnSegmentNeighborVisualChanged;

	public event Action<ElementGroupSegment> OnDestroyed;

	public List<int> GetEdges(Space space)
	{
		if (space == Space.Self)
		{
			return segmentType.edges;
		}
		List<int> list = new List<int>();
		foreach (int edge in Edges)
		{
			list.Add((edge + Tile.RotationIndex + 12) % 6);
		}
		return list;
	}

	private void Awake()
	{
		SegmentFloor = GetComponentInChildren<SegmentGround>();
		vehicleSegment = GetComponent<VehicleSegment>();
		HybridSegment = GetComponent<HybridSegment>();
		neighborSegments = new ElementGroupSegment[6];
		AllElements = new List<Element>();
		SetupElements();
	}

	private void SetupElements()
	{
		Elements = new Dictionary<ElementType, int>();
		AllElements = new List<Element>(GetComponentsInChildren<Element>(includeInactive: true));
		AllElements.RemoveAll((Element x) => x is DecorationElement);
		foreach (Element allElement in AllElements)
		{
			if (!Elements.ContainsKey(allElement.ElementType))
			{
				Elements.Add(allElement.ElementType, 0);
			}
			Elements[allElement.ElementType]++;
		}
		foreach (InstanceableVisual allElementDatum in AllElementData)
		{
			if (!Elements.ContainsKey(allElementDatum.ElementType))
			{
				Elements.Add(allElementDatum.ElementType, 0);
			}
			Elements[allElementDatum.ElementType]++;
		}
	}

	public void Initialize(Tile tile, int segmentIndex, int rotationIndex = -1)
	{
		this.tile = tile;
		this.segmentIndex = segmentIndex;
		if (rotationIndex == -1)
		{
			this.rotationIndex = Mathf.RoundToInt((base.transform.localRotation.eulerAngles.y + 360f) % 360f / 60f);
		}
		else
		{
			this.rotationIndex = rotationIndex;
		}
		edges = GridCalculator.RotateDirections(SegmentType.edges, RotationIndex);
		openLocalEdges = new List<int>(edges);
	}

	public void PlacementInitialization()
	{
		UpdateName();
		if ((bool)vehicleSegment)
		{
			vehicleSegment.PlacementInitialization();
		}
	}

	public void UpdateName()
	{
		base.name = $"{Tile.name} Segment {SegmentIndex} | {GroupType.name} | " + "edges " + ListHelper.ListDebugString(GetEdges(Space.World));
	}

	public void UpdateNeighborSegment(int worldEdgeIndex, int localEdgeIndex, Tile newNeighbor)
	{
		neighborSegments[worldEdgeIndex] = null;
		ElementGroupSegment elementGroupSegment = null;
		if (!edges.Contains(localEdgeIndex))
		{
			return;
		}
		if (newNeighbor != null)
		{
			elementGroupSegment = newNeighbor.GetElementGroupSegment((worldEdgeIndex + 3) % 6, Space.World, groupType);
			if ((bool)elementGroupSegment && elementGroupSegment.GroupType == GroupType)
			{
				neighborSegments[worldEdgeIndex] = elementGroupSegment;
			}
		}
		if (openLocalEdges.Contains(localEdgeIndex) && (bool)newNeighbor)
		{
			openLocalEdges.Remove(localEdgeIndex);
			this.OnSegmentNeighborChanged?.Invoke(localEdgeIndex, worldEdgeIndex, newNeighbor, elementGroupSegment);
			if (HighlightingEdges)
			{
				HighlightOpenEdges(newHighlight: true);
			}
		}
		else if (Edges.Contains(localEdgeIndex) && !openLocalEdges.Contains(localEdgeIndex) && !newNeighbor)
		{
			openLocalEdges.Add(localEdgeIndex);
			this.OnSegmentNeighborChanged?.Invoke(localEdgeIndex, worldEdgeIndex, newNeighbor, elementGroupSegment);
			if (HighlightingEdges)
			{
				HighlightOpenEdges(newHighlight: true);
			}
		}
	}

	public void Randomize(int seed)
	{
		int num = 0;
		foreach (Element allElement in AllElements)
		{
			allElement.Randomize(seed + num);
			num++;
		}
		foreach (InstanceableVisual allElementDatum in AllElementData)
		{
			allElementDatum.Randomize(seed + num);
			num++;
		}
		if (instanceableSegmentGround.isInitialized)
		{
			instanceableSegmentGround.Randomize(seed);
		}
	}

	public List<ElementGroupSegment> GetNeighborSegments()
	{
		List<ElementGroupSegment> list = new List<ElementGroupSegment>(neighborSegments);
		list.RemoveAll((ElementGroupSegment x) => x == null);
		return list;
	}

	private void ShowElements(bool show)
	{
		if ((bool)SegmentFloor)
		{
			SegmentFloor.gameObject.SetActive(show);
		}
		if ((bool)adaptiveObjectContainer)
		{
			adaptiveObjectContainer.SetActive(show);
		}
		foreach (Element allElement in AllElements)
		{
			allElement.Show(show);
		}
	}

	public void HighlightElements(bool newHighlight)
	{
		foreach (Element allElement in AllElements)
		{
			allElement.Highlight(newHighlight);
		}
		foreach (InstanceableVisual allElementDatum in AllElementData)
		{
			allElementDatum.Highlight(newHighlight);
		}
	}

	public ElementGroupSegment GetNeighborSegment(int worldEdge)
	{
		return neighborSegments[worldEdge];
	}

	public void UpdateSegmentNeighborVisual()
	{
		this.OnSegmentNeighborVisualChanged?.Invoke();
	}

	public void UpdateTileReference(Tile tile)
	{
		this.tile = tile;
	}

	public void ChangeTileState(TileState targetState)
	{
		ShowElements(targetState != TileState.stacked);
		foreach (InstanceableVisual allElementDatum in AllElementData)
		{
			allElementDatum.ChangeTileState(targetState);
		}
		if (instanceableSegmentGround.isInitialized)
		{
			instanceableSegmentGround.ChangeTileState(targetState);
		}
	}

	public void SetRendererLayer(int targetLayer)
	{
		if ((bool)SegmentFloor)
		{
			SegmentFloor.SetLayer(targetLayer);
		}
		foreach (InstanceableVisual allElementDatum in AllElementData)
		{
			allElementDatum.SetLayer(targetLayer);
		}
		if (instanceableSegmentGround.isInitialized)
		{
			instanceableSegmentGround.SetLayer(targetLayer);
		}
	}

	public void SetAnimationsRunning(bool animationsRunning)
	{
		foreach (InstanceableVisual allElementDatum in AllElementData)
		{
			allElementDatum.SetAnimationsRunning(animationsRunning);
		}
		if (instanceableSegmentGround.isInitialized)
		{
			instanceableSegmentGround.SetAnimationsRunning(animationsRunning);
		}
	}

	public void SetTileReference(Tile tile)
	{
	}

	private void OnDestroy()
	{
		this.OnDestroyed?.Invoke(this);
	}

	public void HighlightOpenEdges(bool newHighlight)
	{
		HighlightingEdges = newHighlight;
		foreach (SegmentEdgeHighlight highlightedEdge in highlightedEdges)
		{
			highlightedEdge.Disappear();
		}
		highlightedEdges.Clear();
		if (!newHighlight)
		{
			return;
		}
		for (int i = 0; i < 6; i++)
		{
			if (openLocalEdges.Contains(i))
			{
				SegmentEdgeHighlight segmentEdgeHighlight = MasterObjectPool.Instance.GetObject<SegmentEdgeHighlight>(RecyclableType.SegmentEdgeHighlight);
				segmentEdgeHighlight.Setup(tile, i, groupType, startHighlighted: false);
				segmentEdgeHighlight.Show(newShow: true);
				highlightedEdges.Add(segmentEdgeHighlight);
			}
		}
	}

	public void RemoveGroup(ElementGroup elementGroup)
	{
		if (ElementGroup == elementGroup)
		{
			ElementGroup = null;
		}
	}

	public void SetGroup(ElementGroup newElementGroup)
	{
		ElementGroup = newElementGroup;
	}

	public void DestroyAllElements()
	{
		foreach (Element allElement in AllElements)
		{
			allElement.Destroy();
		}
		foreach (InstanceableVisual allElementDatum in AllElementData)
		{
			allElementDatum.ChangeDisplayState(InstancingDisplayState.Hidden);
		}
	}

	public void InitializeDataFromReferencePrefab(ElementGroupSegment referencePrefab)
	{
		allInstanceableElements.Clear();
		Elements.Clear();
		Element[] componentsInChildren = referencePrefab.GetComponentsInChildren<Element>(includeInactive: true);
		foreach (Element element in componentsInChildren)
		{
			InstanceableVisual instanceableVisual = new InstanceableVisual();
			instanceableVisual.SetElementType(element.ElementType);
			instanceableVisual.Initialize(base.transform, element.transform.localPosition);
			allInstanceableElements.Add(instanceableVisual);
			if (!Elements.ContainsKey(element.ElementType))
			{
				Elements.Add(element.ElementType, 0);
			}
			Elements[element.ElementType]++;
		}
		VehicleSegment component = referencePrefab.GetComponent<VehicleSegment>();
		vehicleSegment = GetComponent<VehicleSegment>();
		if ((bool)vehicleSegment && (bool)component)
		{
			vehicleSegment.SetupFromReference(component);
		}
	}

	public void UpdateElementGroup(ElementGroup elementGroup)
	{
		foreach (InstanceableVisual allInstanceableElement in allInstanceableElements)
		{
			allInstanceableElement.UpdateElementGroup(elementGroup);
		}
	}

	private void ReadElementData(bool destroyElements = true)
	{
		Element[] componentsInChildren = GetComponentsInChildren<Element>();
		if (componentsInChildren.Length == 0)
		{
			Debug.LogError(base.name + " has no child Elements!");
			return;
		}
		allInstanceableElements.Clear();
		Element[] componentsInChildren2 = GetComponentsInChildren<Element>();
		foreach (Element element in componentsInChildren2)
		{
			if (element.ElementType != elementPrefab.ElementType)
			{
				Debug.Log($"found element {element} with type different from {elementPrefab} - skipped as ElementData!");
				continue;
			}
			InstanceableVisual instanceableVisual = new InstanceableVisual();
			instanceableVisual.SetElementType(element.ElementType);
			instanceableVisual.Initialize(base.transform, element.transform.localPosition);
			allInstanceableElements.Add(instanceableVisual);
			Element[] componentsInChildren3 = element.GetComponentsInChildren<Element>(includeInactive: true);
			foreach (Element element2 in componentsInChildren3)
			{
				if (!(element2 == element))
				{
					instanceableVisual.AddSubElement(element2);
				}
			}
		}
		if (destroyElements)
		{
			for (int num = componentsInChildren.Length - 1; num >= 0; num--)
			{
			}
		}
	}

	private void CreateElementsBasedOnData(bool ignoreExistingChildElements = false)
	{
		if (AllElementData.Count == 0)
		{
			Debug.LogError(base.name + " has no ElementData!");
			return;
		}
		if (!ignoreExistingChildElements && GetComponentsInChildren<Element>().Length != 0)
		{
			Debug.LogError(base.name + " already has Elements!");
			return;
		}
		for (int i = 0; i < AllElementData.Count; i++)
		{
		}
	}

	private void InitializeInstancedGroupShape()
	{
		instanceableSegmentGround.SetElementType(segmentGroundElementType, groupType.SegmentGroundSubType);
		if ((bool)segmentType)
		{
			instanceableSegmentGround.SetInstanceable(segmentType.segmentGroundInstanceable);
		}
		instanceableSegmentGround.Initialize(base.transform, Vector3.zero);
		if (Enumerable.Count(instanceableSegmentGround.CustomInts, (CustomInstanceInt x) => x.propertyName == Constants.MaterialParameters.GroupType) > 0)
		{
			Enumerable.First(instanceableSegmentGround.CustomInts, (CustomInstanceInt x) => x.propertyName == Constants.MaterialParameters.GroupType).value = (int)groupType.id;
		}
		else
		{
			instanceableSegmentGround.CustomInts.Add(new CustomInstanceInt(Constants.MaterialParameters.GroupType, (int)groupType.id));
		}
	}
}
