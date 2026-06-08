using System;
using System.Collections.Generic;
using System.Linq;
using Dorfromantik;
using UnityEngine;
using UnityEngine.Serialization;

public class ElementGroup : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<ElementGroupSegment, bool> _003C_003E9__15_0;

		internal bool _003Cget_Placed_003Eb__15_0(ElementGroupSegment x)
		{
			return x.Tile.State == TileState.placed;
		}
	}

	[SerializeField]
	[FormerlySerializedAs("tileEdgeDescriptionPrefab")]
	private SegmentEdgeHighlight segmentEdgeHighlightPrefab;

	[SerializeField]
	private SettingsRouter settingsRouter;

	private GroupType _003CGroupType_003Ek__BackingField;

	private List<ElementGroupSegment> _003CSegments_003Ek__BackingField;

	private Dictionary<ElementType, int> _003CElements_003Ek__BackingField;

	private bool _003CValid_003Ek__BackingField = true;

	internal bool highlighted;

	private List<ElementGroupSegment> highlightedSegments = new List<ElementGroupSegment>();

	private Tile highlightSource;

	public Dictionary<RecyclableType, Dictionary<Biome, GPUInstanceData>> instanceCollections = new Dictionary<RecyclableType, Dictionary<Biome, GPUInstanceData>>();

	private int totalOpenEdges;

	private bool checkingOpenEdgeCount;

	private List<VehiclePath> vehiclePaths;

	private bool placed;

	private bool _003CPreviewClosed_003Ek__BackingField;

	private bool _003CClosed_003Ek__BackingField;

	private bool _003CIsAboutToBeRemoved_003Ek__BackingField;

	private int _003CId_003Ek__BackingField;

	public GroupType GroupType
	{
		get
		{
			return _003CGroupType_003Ek__BackingField;
		}
		private set
		{
			_003CGroupType_003Ek__BackingField = value;
		}
	}

	public List<ElementGroupSegment> Segments
	{
		get
		{
			return _003CSegments_003Ek__BackingField;
		}
		private set
		{
			_003CSegments_003Ek__BackingField = value;
		}
	}

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

	public bool Placed => Enumerable.Any(Segments, (ElementGroupSegment x) => x.Tile.State == TileState.placed);

	public bool Valid
	{
		get
		{
			return _003CValid_003Ek__BackingField;
		}
		private set
		{
			_003CValid_003Ek__BackingField = value;
		}
	}

	public Vector3 MedianPosition
	{
		get
		{
			Vector3 worldCenterPos = Segments[0].WorldCenterPos;
			for (int i = 1; i < Segments.Count; i++)
			{
				worldCenterPos += Segments[i].WorldCenterPos;
			}
			return worldCenterPos / Segments.Count;
		}
	}

	public bool PreviewClosed
	{
		get
		{
			return _003CPreviewClosed_003Ek__BackingField;
		}
		private set
		{
			_003CPreviewClosed_003Ek__BackingField = value;
		}
	}

	public bool Closed
	{
		get
		{
			return _003CClosed_003Ek__BackingField;
		}
		private set
		{
			_003CClosed_003Ek__BackingField = value;
		}
	}

	public int OpenEdges => totalOpenEdges;

	public bool IsAboutToBeRemoved
	{
		get
		{
			return _003CIsAboutToBeRemoved_003Ek__BackingField;
		}
		set
		{
			_003CIsAboutToBeRemoved_003Ek__BackingField = value;
		}
	}

	public int Id
	{
		get
		{
			return _003CId_003Ek__BackingField;
		}
		set
		{
			_003CId_003Ek__BackingField = value;
		}
	}

	public event Action<ElementGroup, List<ElementGroup>> OnGroupSplit;

	public event Action<ElementGroup, ElementGroup> OnGroupsMerged;

	public event Action<ElementGroup> OnSegmentAdded;

	public event Action<ElementGroup> OnSegmentRemoved;

	public event Action<ElementGroup, bool> OnGroupClosed;

	public event Action<bool> OnHighlight;

	public event Action<ElementGroup> OnAllSegmentsRemoved;

	private void Awake()
	{
		Elements = new Dictionary<ElementType, int>();
		Segments = new List<ElementGroupSegment>();
	}

	public void SetType(GroupType originGroupType)
	{
		GroupType = originGroupType;
	}

	public void AddSegment(ElementGroupSegment newSegment, bool updateOpenEdgeCount = true)
	{
		foreach (KeyValuePair<ElementType, int> element in newSegment.Elements)
		{
			if (!Elements.ContainsKey(element.Key))
			{
				Elements.Add(element.Key, 0);
			}
			Elements[element.Key] += element.Value;
		}
		Segments.Add(newSegment);
		newSegment.OnSegmentNeighborChanged += UpdateOpenEdgeCount;
		newSegment.SetGroup(this);
		if (updateOpenEdgeCount)
		{
			UpdateOpenEdgeCount();
		}
		this.OnSegmentAdded?.Invoke(this);
	}

	public void UpdateOpenEdgeCount(int localSegmentEdge = -1, int worldSegmentEdge = -1, Tile newNeighborTile = null, ElementGroupSegment newNeighborSegment = null)
	{
		totalOpenEdges = 0;
		foreach (ElementGroupSegment segment in Segments)
		{
			totalOpenEdges += segment.OpenEdgeCount;
		}
		if (PreviewClosed != (totalOpenEdges == 0))
		{
			PreviewClosed = totalOpenEdges == 0;
			this.OnGroupClosed?.Invoke(this, PreviewClosed);
		}
	}

	public void AddGroup(ElementGroup neighborGroup)
	{
		foreach (ElementGroupSegment segment in neighborGroup.Segments)
		{
			AddSegment(segment);
			foreach (int edge in segment.Edges)
			{
				segment.Tile.UpdateGroup(edge, this);
			}
		}
		if (highlighted)
		{
			HighlightOpenEdges(newHighlight: false, highlightSource);
			HighlightOpenEdges(newHighlight: true, highlightSource);
		}
		neighborGroup.MergeInto(this);
	}

	private void MergeInto(ElementGroup newGroup)
	{
		for (int num = Segments.Count - 1; num >= 0; num--)
		{
			RemoveSegment(Segments[num]);
		}
		Segments.Clear();
		if (highlighted)
		{
			HighlightOpenEdges(newHighlight: false, highlightSource);
			newGroup.HighlightOpenEdges(newHighlight: true, highlightSource);
		}
		this.OnGroupsMerged?.Invoke(this, newGroup);
	}

	public void PlacementInitialization()
	{
		if (!placed)
		{
			placed = true;
			UpdateOpenEdgeCount();
		}
	}

	public void OnDestroy()
	{
		foreach (ElementGroupSegment segment in Segments)
		{
			segment.OnSegmentNeighborChanged -= UpdateOpenEdgeCount;
		}
	}

	public void RemoveSegment(ElementGroupSegment segmentToRemove, bool invokeEvent = true)
	{
		foreach (KeyValuePair<ElementType, int> element in segmentToRemove.Elements)
		{
			Elements[element.Key] -= element.Value;
		}
		segmentToRemove.RemoveGroup(this);
		if (invokeEvent)
		{
			Segments.Remove(segmentToRemove);
			segmentToRemove.OnSegmentNeighborChanged -= UpdateOpenEdgeCount;
			UpdateOpenEdgeCount();
			this.OnSegmentRemoved?.Invoke(this);
		}
	}

	public void Split(List<ElementGroup> splitGroups, Dictionary<ElementGroupSegment, ElementGroup> splitGroupBySegment)
	{
		if (highlighted)
		{
			foreach (ElementGroup splitGroup in splitGroups)
			{
				splitGroup.HighlightOpenEdges(newHighlight: false);
			}
		}
		for (int num = Segments.Count - 1; num >= 0; num--)
		{
			ElementGroup previousGroup = null;
			foreach (int edge in Segments[num].Edges)
			{
				previousGroup = Segments[num].Tile.UpdateGroup(edge, splitGroupBySegment[Segments[num]], invokeGroupChangedEvent: false);
				if (highlighted && Segments[num].Tile == highlightSource)
				{
					splitGroupBySegment[Segments[num]].HighlightOpenEdges(newHighlight: true, highlightSource);
				}
			}
			Segments[num].Tile.InvokeGroupChangedEvent(previousGroup, splitGroupBySegment[Segments[num]]);
			RemoveSegment(Segments[num], invokeEvent: false);
		}
		this.OnGroupSplit?.Invoke(this, splitGroups);
	}

	public void HighlightElements(bool newHighlight)
	{
		foreach (ElementGroupSegment segment in Segments)
		{
			segment.HighlightElements(newHighlight);
		}
		this.OnHighlight?.Invoke(newHighlight);
	}

	public int ConditionCount(CountTarget countTarget, ElementType elementType)
	{
		switch (countTarget)
		{
		case CountTarget.Elements:
			return Elements[elementType];
		case CountTarget.Segments:
			return Segments.Count;
		default:
			Debug.LogError($"no condition count for type {countTarget}");
			return 0;
		}
	}

	public void HighlightOpenEdges(bool newHighlight, Tile highlightingSource = null)
	{
		if (highlighted == newHighlight)
		{
			return;
		}
		highlighted = newHighlight;
		highlightSource = highlightingSource;
		if (!newHighlight)
		{
			foreach (ElementGroupSegment segment in Segments)
			{
				if (segment.HighlightingEdges)
				{
					segment.HighlightOpenEdges(newHighlight: false);
				}
			}
			return;
		}
		foreach (ElementGroupSegment segment2 in Segments)
		{
			if (segment2.OpenEdgeCount > 0)
			{
				segment2.HighlightOpenEdges(newHighlight: true);
			}
		}
	}

	public int ElementCount(ElementType elementType)
	{
		if (Elements.ContainsKey(elementType))
		{
			return Elements[elementType];
		}
		return 0;
	}

	public void SetValid(bool valid)
	{
		Valid = valid;
	}
}
