using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DG.Tweening;
using Dorfromantik;
using UnityEngine;

public class Tile : MonoBehaviour, IOutlineable, ISelectable
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<Tile, bool> _003C_003E9__22_0;

		public static Func<Tile, bool> _003C_003E9__154_0;

		public static Func<Tile, bool> _003C_003E9__154_1;

		public static Func<DecorationElement, bool> _003C_003E9__159_0;

		internal bool _003Cget_NeighborCount_003Eb__22_0(Tile x)
		{
			return x;
		}

		internal bool _003CDestroyTile_003Eb__154_0(Tile x)
		{
			return x != null;
		}

		internal bool _003CDestroyTile_003Eb__154_1(Tile x)
		{
			return x != null;
		}

		internal bool _003CReadDecorationData_003Eb__159_0(DecorationElement x)
		{
			if (x.ElementType != null)
			{
				return x.ElementType.instancingInfo != null;
			}
			return false;
		}
	}

	private sealed class _003CWobble_003Ed__152 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float startDelay;

		public Tile _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CWobble_003Ed__152(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			Tile CS_0024_003C_003E8__locals19 = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = new WaitForSeconds(startDelay);
				_003C_003E1__state = 1;
				return true;
			case 1:
			{
				_003C_003E1__state = -1;
				Sequence wobbleTween = CS_0024_003C_003E8__locals19.wobbleTween;
				if (wobbleTween != null)
				{
					TweenExtensions.Kill(wobbleTween, complete: true);
				}
				CS_0024_003C_003E8__locals19.wobbleTween = DOTween.Sequence();
				CS_0024_003C_003E8__locals19.AddRunningAnimation(CS_0024_003C_003E8__locals19.wobbleTween);
				AudioManager.Instance.PlaySoundAtPosition(CS_0024_003C_003E8__locals19.wobbleSound, CS_0024_003C_003E8__locals19.transform.position);
				startDelay = 0.2f * _003CWobble_003Eg__Jitter_007C152_0();
				float num2 = 0.1f * _003CWobble_003Eg__Jitter_007C152_0();
				float num3 = 0.2f * _003CWobble_003Eg__Jitter_007C152_0();
				float duration = 0.5f * _003CWobble_003Eg__Jitter_007C152_0();
				float num4 = 0.05f * _003CWobble_003Eg__Jitter_007C152_0();
				Vector3 onUnitSphere = UnityEngine.Random.onUnitSphere;
				TweenSettingsExtensions.Insert(CS_0024_003C_003E8__locals19.wobbleTween, 0f, ShortcutExtensions.DOBlendableMoveBy(CS_0024_003C_003E8__locals19.transform, Vector3.up * num4, num2));
				TweenSettingsExtensions.Insert(CS_0024_003C_003E8__locals19.wobbleTween, num2, TweenSettingsExtensions.SetEase(ShortcutExtensions.DOBlendableMoveBy(CS_0024_003C_003E8__locals19.transform, Vector3.up * (0f - num4), num3), Ease.OutBounce));
				TweenSettingsExtensions.Insert(CS_0024_003C_003E8__locals19.wobbleTween, num2 + num3 / 2f, ShortcutExtensions.DOPunchRotation(CS_0024_003C_003E8__locals19.transform, onUnitSphere * 3f, duration, 8));
				TweenSettingsExtensions.OnComplete(CS_0024_003C_003E8__locals19.wobbleTween, delegate
				{
					ShortcutExtensions.DOMoveY(CS_0024_003C_003E8__locals19.transform, 0f, 0f);
				});
				TweenSettingsExtensions.OnComplete(CS_0024_003C_003E8__locals19.wobbleTween, delegate
				{
					ShortcutExtensions.DORotate(CS_0024_003C_003E8__locals19.transform, Vector3.zero, 0f);
				});
				TweenSettingsExtensions.OnComplete(CS_0024_003C_003E8__locals19.wobbleTween, delegate
				{
					CS_0024_003C_003E8__locals19.RemoveRunningAnimation(CS_0024_003C_003E8__locals19.wobbleTween);
				});
				return false;
			}
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class _003CBroadcastAnimationStopAtEndOfFrame_003Ed__157 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tile _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CBroadcastAnimationStopAtEndOfFrame_003Ed__157(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			Tile tile = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = new WaitForEndOfFrame();
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if (tile.runningAnimations.Count == 0 && !tile.destroyed)
				{
					foreach (ITileStateReceiver tileStateReceiver in tile.tileStateReceivers)
					{
						tileStateReceiver.SetAnimationsRunning(animationsRunning: false);
					}
					foreach (InstanceableVisual item in tile.InstanceableDecoration)
					{
						item.SetAnimationsRunning(animationsRunning: false);
					}
				}
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[SerializeField]
	private bool isInitialTile;

	private Vector2Int _003CGridPos_003Ek__BackingField;

	[SerializeField]
	private int rotationIndex;

	private TileState _003CState_003Ek__BackingField;

	private Tile[] _003CNeighborTiles_003Ek__BackingField;

	private TileVisual tileVisual;

	private Dictionary<Biome, float> _003CCurrentBiomeInfluence_003Ek__BackingField;

	[SerializeField]
	private bool animateTilePlacement = true;

	[SerializeField]
	private AudioClipOptions wobbleSound;

	[SerializeField]
	private LoadingProgressRouter loadingProgressRouter;

	[SerializeField]
	private float destroyAnimationDuration = 0.3f;

	[SerializeField]
	private Ease destroyAnimationEasing = Ease.InCubic;

	private List<ElementGroupSegment> _003CAllElementGroupSegments_003Ek__BackingField;

	private List<ElementGroup> _003CAllElementGroups_003Ek__BackingField = new List<ElementGroup>();

	private bool _003CTileFitCanChangeOnRotate_003Ek__BackingField;

	private Dictionary<GroupType, int> _003CAdaptiveEdges_003Ek__BackingField;

	private List<Element> _003CDecoration_003Ek__BackingField;

	public List<InstanceableVisual> InstanceableDecoration = new List<InstanceableVisual>();

	private int _003CClosedEdgeCount_003Ek__BackingField;

	private List<Tile> _003CFittingPlacedNeighbors_003Ek__BackingField = new List<Tile>();

	private List<Tile> _003CHybridPlacedNeighbors_003Ek__BackingField = new List<Tile>();

	public List<Debug_BiomeInfluence> debug_biomeInfluence;

	[SerializeField]
	private int seed;

	private bool _003CGenerated_003Ek__BackingField;

	private bool destroyed;

	private bool _003CIsCurrentTile_003Ek__BackingField;

	private List<ITileStateReceiver> tileStateReceivers = new List<ITileStateReceiver>();

	private Sequence wobbleTween;

	private TileEdgeInfo[] tileEdges = new TileEdgeInfo[6];

	private List<Tween> runningAnimations = new List<Tween>();

	public bool IsInitialTile => isInitialTile;

	public Vector2Int GridPos
	{
		get
		{
			return _003CGridPos_003Ek__BackingField;
		}
		private set
		{
			_003CGridPos_003Ek__BackingField = value;
		}
	}

	public int RotationIndex
	{
		get
		{
			return rotationIndex;
		}
		private set
		{
			rotationIndex = value;
		}
	}

	public TileState State
	{
		get
		{
			return _003CState_003Ek__BackingField;
		}
		private set
		{
			_003CState_003Ek__BackingField = value;
		}
	}

	public Transform VisualContainer => tileVisual.transform;

	public Tile[] NeighborTiles
	{
		get
		{
			return _003CNeighborTiles_003Ek__BackingField;
		}
		private set
		{
			_003CNeighborTiles_003Ek__BackingField = value;
		}
	}

	public int NeighborCount => Enumerable.Count(NeighborTiles, (Tile x) => x);

	public Dictionary<Biome, float> CurrentBiomeInfluence
	{
		get
		{
			return _003CCurrentBiomeInfluence_003Ek__BackingField;
		}
		private set
		{
			_003CCurrentBiomeInfluence_003Ek__BackingField = value;
		}
	}

	public List<ElementGroupSegment> AllElementGroupSegments
	{
		get
		{
			return _003CAllElementGroupSegments_003Ek__BackingField;
		}
		private set
		{
			_003CAllElementGroupSegments_003Ek__BackingField = value;
		}
	}

	public List<ElementGroup> AllElementGroups
	{
		get
		{
			return _003CAllElementGroups_003Ek__BackingField;
		}
		private set
		{
			_003CAllElementGroups_003Ek__BackingField = value;
		}
	}

	public bool TileFitCanChangeOnRotate
	{
		get
		{
			return _003CTileFitCanChangeOnRotate_003Ek__BackingField;
		}
		private set
		{
			_003CTileFitCanChangeOnRotate_003Ek__BackingField = value;
		}
	}

	public Dictionary<GroupType, int> AdaptiveEdges
	{
		get
		{
			return _003CAdaptiveEdges_003Ek__BackingField;
		}
		private set
		{
			_003CAdaptiveEdges_003Ek__BackingField = value;
		}
	}

	public List<Element> Decoration
	{
		get
		{
			return _003CDecoration_003Ek__BackingField;
		}
		private set
		{
			_003CDecoration_003Ek__BackingField = value;
		}
	}

	public int ClosedEdgeCount
	{
		get
		{
			return _003CClosedEdgeCount_003Ek__BackingField;
		}
		private set
		{
			_003CClosedEdgeCount_003Ek__BackingField = value;
		}
	}

	public List<Tile> FittingPlacedNeighbors
	{
		get
		{
			return _003CFittingPlacedNeighbors_003Ek__BackingField;
		}
		private set
		{
			_003CFittingPlacedNeighbors_003Ek__BackingField = value;
		}
	}

	public List<Tile> HybridPlacedNeighbors
	{
		get
		{
			return _003CHybridPlacedNeighbors_003Ek__BackingField;
		}
		private set
		{
			_003CHybridPlacedNeighbors_003Ek__BackingField = value;
		}
	}

	public int Seed => seed;

	public TileVisual TileVisual => tileVisual;

	public bool Generated
	{
		get
		{
			return _003CGenerated_003Ek__BackingField;
		}
		set
		{
			_003CGenerated_003Ek__BackingField = value;
		}
	}

	public bool IsCurrentTile
	{
		get
		{
			return _003CIsCurrentTile_003Ek__BackingField;
		}
		private set
		{
			_003CIsCurrentTile_003Ek__BackingField = value;
		}
	}

	public IOutlineable[] Neighbors => NeighborTiles;

	public int Layer => 10;

	public Transform Transform => base.transform;

	public Vector3 WorldPosition => base.transform.position;

	public event Action<int> OnRendererLayerChanged;

	public event Action<ElementGroup, ElementGroup> OnGroupChanged;

	public event Action<int, Tile> OnNeighborTileAdded;

	public event Action<int, Tile> OnNeighborTilePlaced;

	public event Action<Tile> OnPlaced;

	public event Action OnDestroyed;

	public event Action OnSeedChanged;

	private void DebugTileStateReceiver()
	{
		foreach (ITileStateReceiver tileStateReceiver in tileStateReceivers)
		{
			Debug.Log($"<color=magenta>{tileStateReceiver}</color>");
		}
	}

	private void DebugTileEdgeInfo()
	{
		for (int i = 0; i < 6; i++)
		{
			if (tileEdges[i] == null)
			{
				Debug.Log($"Tile Edge {i}: empty");
				continue;
			}
			Debug.Log($"Tile Edge {i}: {tileEdges[i].segmentEdges.Count} types");
			foreach (SegmentEdgeInfo segmentEdge in tileEdges[i].segmentEdges)
			{
				Debug.Log($"segment edge: {segmentEdge.groupType}, hybrid: {segmentEdge.hybridSegment}");
			}
		}
	}

	protected virtual void Awake()
	{
		NeighborTiles = new Tile[6];
		tileVisual = GetComponentInChildren<TileVisual>();
		AllElementGroupSegments = new List<ElementGroupSegment>(GetComponentsInChildren<ElementGroupSegment>());
		Decoration = new List<Element>(GetComponentsInChildren<DecorationElement>(includeInactive: true));
		tileStateReceivers = new List<ITileStateReceiver>(GetComponentsInChildren<ITileStateReceiver>(includeInactive: true));
	}

	public virtual void ChangeTileState(TileState targetState)
	{
		if (loadingProgressRouter == null)
		{
			Debug.LogError(base.name + " has no loadingProgressRouter", this);
		}
		tileVisual.ChangeTileState(targetState, !IsInitialTile && (!loadingProgressRouter.IsLoading || !loadingProgressRouter.FastLoadingEnabled) && animateTilePlacement);
		State = targetState;
		int num = ((targetState == TileState.stacked || targetState == TileState.stackPreview || targetState == TileState.topStackPreview) ? 9 : 10);
		base.gameObject.layer = num;
		tileVisual.ShowReplacedGround(targetState != TileState.stacked);
		foreach (ITileStateReceiver tileStateReceiver in tileStateReceivers)
		{
			tileStateReceiver.ChangeTileState(targetState);
			tileStateReceiver.SetRendererLayer(num);
		}
		foreach (InstanceableVisual item in InstanceableDecoration)
		{
			item.ChangeTileState(targetState);
			item.SetLayer(num);
		}
	}

	public void SetLayer(int targetLayer)
	{
		foreach (ITileStateReceiver tileStateReceiver in tileStateReceivers)
		{
			tileStateReceiver.SetRendererLayer(targetLayer);
		}
	}

	IOutlineable IOutlineable.GetNeighbor(int edgeIndex, Space space)
	{
		return GetNeighbor(edgeIndex, space);
	}

	public Tile GetNeighbor(int directionIndex, Space space)
	{
		if (space == Space.Self)
		{
			return NeighborTiles[(directionIndex - RotationIndex + 6) % 6];
		}
		return NeighborTiles[directionIndex];
	}

	public List<GroupType> GetEdgeTypes(int directionIndex, Space space, TileEdgeType edgeType = TileEdgeType.Any)
	{
		int num = ((space == Space.World) ? ((directionIndex - RotationIndex + 6) % 6) : directionIndex);
		return tileEdges[num].GetEdgeTypes(edgeType);
	}

	public List<HybridSegment> GetHybridEdges(int directionIndex, Space space)
	{
		int num = ((space == Space.World) ? ((directionIndex - RotationIndex + 6) % 6) : directionIndex);
		return tileEdges[num].GetHybridSegments();
	}

	public ElementGroupSegment GetElementGroupSegment(int directionIndex, Space space, GroupType groupType = null)
	{
		int num = ((space == Space.World) ? ((directionIndex - RotationIndex + 6) % 6) : directionIndex);
		return tileEdges[num].GetElementGroupSegment(groupType);
	}

	public ElementGroup GetElementGroup(int directionIndex, Space space, GroupType groupType = null)
	{
		int num = ((space == Space.World) ? ((directionIndex - RotationIndex + 6) % 6) : directionIndex);
		return tileEdges[num].GetElementGroup(groupType);
	}

	public void Rotate(int amount, bool animate = true)
	{
		RotationIndex = (RotationIndex + amount + 6) % 6;
		tileVisual.Rotate(RotationIndex, animate);
	}

	public void Initialize(TileState state)
	{
		switch (state)
		{
		}
	}

	public void Initialize()
	{
		AllElementGroupSegments = new List<ElementGroupSegment>(GetComponentsInChildren<ElementGroupSegment>());
		SetupEdges();
		InitializeVisual();
		List<Element> decoration = (Decoration = new List<Element>(GetComponentsInChildren<DecorationElement>(includeInactive: true)));
		Decoration = decoration;
		for (int i = 0; i < Decoration.Count; i++)
		{
			Decoration[i].Randomize(seed + i);
		}
		tileStateReceivers = new List<ITileStateReceiver>(GetComponentsInChildren<ITileStateReceiver>(includeInactive: true));
		foreach (ITileStateReceiver tileStateReceiver in tileStateReceivers)
		{
			tileStateReceiver.SetTileReference(this);
		}
	}

	public void InitializeSeed(int overwriteSeed = -1)
	{
		seed = ((overwriteSeed == -1) ? (GetHashCode() + (int)DateTime.Now.Ticks) : overwriteSeed);
		this.OnSeedChanged?.Invoke();
	}

	public virtual void BoardInitialization()
	{
		base.gameObject.SetActive(value: false);
		ChangeTileState(TileState.placementPreview);
	}

	public void PlacementInitialization(Vector2Int gridPos)
	{
		base.gameObject.SetActive(value: true);
		GridPos = gridPos;
		base.name = $"Tile ({GridPos.x}|{GridPos.y})";
		foreach (ElementGroupSegment allElementGroupSegment in AllElementGroupSegments)
		{
			allElementGroupSegment.PlacementInitialization();
		}
		HighlightAdjacentGroups(newHighlight: false);
	}

	private void PlaceNeighbor(int worldEdge, Tile placedNeighbor)
	{
		ClosedEdgeCount++;
		ElementGroup elementGroup = GetElementGroup(worldEdge, Space.World);
		ElementGroup elementGroup2 = placedNeighbor.GetElementGroup((worldEdge + 3) % 6, Space.World);
		if (OverwritingSingleton<IngameUi>.Instance.settingsRouter.AllTilesCountAsPerfect || GetElementGroup(worldEdge, Space.World) == placedNeighbor.GetElementGroup((worldEdge + 3) % 6, Space.World))
		{
			FittingPlacedNeighbors.Add(placedNeighbor);
		}
		else if (elementGroup != null && elementGroup2 != null && (elementGroup == placedNeighbor.GetElementGroup((worldEdge + 3) % 6, Space.World, elementGroup.GroupType) || elementGroup2 == GetElementGroup(worldEdge, Space.World, elementGroup2.GroupType)))
		{
			FittingPlacedNeighbors.Add(placedNeighbor);
		}
		else if ((GetHybridEdges(worldEdge, Space.World).Count > 0 && elementGroup2 == null) || (placedNeighbor.GetHybridEdges((worldEdge + 3) % 6, Space.World).Count > 0 && elementGroup == null))
		{
			FittingPlacedNeighbors.Add(placedNeighbor);
		}
		else if (GetHybridEdges(worldEdge, Space.World).Count > 0 || placedNeighbor.GetHybridEdges((worldEdge + 3) % 6, Space.World).Count > 0)
		{
			HybridPlacedNeighbors.Add(placedNeighbor);
		}
		this.OnNeighborTilePlaced?.Invoke(worldEdge, placedNeighbor);
	}

	public void HighlightAdjacentGroups(bool newHighlight)
	{
		foreach (ElementGroup allElementGroup in AllElementGroups)
		{
			if (!(allElementGroup == null))
			{
				allElementGroup.HighlightElements(newHighlight && allElementGroup.Segments.Count > 1);
			}
		}
	}

	private void SetupEdges()
	{
		tileEdges = new TileEdgeInfo[6];
		for (int i = 0; i < 6; i++)
		{
			tileEdges[i] = new TileEdgeInfo();
		}
		foreach (ElementGroupSegment allElementGroupSegment in AllElementGroupSegments)
		{
			allElementGroupSegment.UpdateTileReference(this);
			GroupType groupType = allElementGroupSegment.GroupType;
			if (groupType == null)
			{
				Debug.LogError($"{this}, segment {allElementGroupSegment} has no segmentType");
			}
			foreach (int edge in allElementGroupSegment.Edges)
			{
				tileEdges[edge].AddElementGroupSegment(allElementGroupSegment);
				if (groupType.constraining && (!allElementGroupSegment.HybridSegment || allElementGroupSegment.SegmentType.edges.Count < 6))
				{
					TileFitCanChangeOnRotate = true;
				}
			}
			allElementGroupSegment.UpdateName();
		}
	}

	public void RemoveFromNeighborsNeighbors()
	{
		for (int i = 0; i < 6; i++)
		{
			if (NeighborTiles[i] != null)
			{
				if (State == TileState.placed)
				{
					NeighborTiles[i].RemovePlacedNeighbor(this);
				}
				NeighborTiles[i].SetNeighbor((i + 3) % 6, null);
			}
		}
	}

	private void RemovePlacedNeighbor(Tile tile)
	{
		HybridPlacedNeighbors.Remove(tile);
		FittingPlacedNeighbors.Remove(tile);
		ClosedEdgeCount--;
	}

	public void SetNeighbors(Tile[] neighbors)
	{
		for (int i = 0; i < 6; i++)
		{
			SetNeighbor(i, neighbors[i]);
			if ((bool)neighbors[i])
			{
				NeighborTiles[i].SetNeighbor((i + 3) % 6, this);
			}
		}
		UpdateNeighborVisual();
		for (int j = 0; j < 6; j++)
		{
			if ((bool)NeighborTiles[j])
			{
				NeighborTiles[j].UpdateNeighborVisual();
			}
		}
	}

	private void UpdateNeighborVisual()
	{
		foreach (ElementGroupSegment allElementGroupSegment in AllElementGroupSegments)
		{
			allElementGroupSegment.UpdateSegmentNeighborVisual();
		}
	}

	public void SetNeighbor(int worldDirectionIndex, Tile newNeighbor)
	{
		NeighborTiles[worldDirectionIndex] = newNeighbor;
		UpdateSegmentNeighbor(worldDirectionIndex, newNeighbor);
		UpdateNeighborVisual();
		this.OnNeighborTileAdded?.Invoke(worldDirectionIndex, newNeighbor);
	}

	private void UpdateSegmentNeighbor(int worldDirectionIndex, Tile newNeighbor)
	{
		int localEdgeIndex = GridCalculator.RotatedDirection(worldDirectionIndex, -RotationIndex);
		foreach (ElementGroupSegment allElementGroupSegment in AllElementGroupSegments)
		{
			allElementGroupSegment.UpdateNeighborSegment(worldDirectionIndex, localEdgeIndex, newNeighbor);
		}
	}

	public ElementGroup UpdateGroup(int edgeIndex, ElementGroup newGroup, bool invokeGroupChangedEvent = true)
	{
		ElementGroup elementGroup = tileEdges[edgeIndex].GetElementGroup(newGroup ? newGroup.GroupType : null);
		if ((bool)elementGroup)
		{
			AllElementGroups.Remove(elementGroup);
		}
		if (invokeGroupChangedEvent)
		{
			this.OnGroupChanged?.Invoke(elementGroup, newGroup);
		}
		tileEdges[edgeIndex].UpdateElementGroup(newGroup);
		if ((bool)newGroup)
		{
			AllElementGroups.Add(newGroup);
		}
		return elementGroup;
	}

	public void InvokeGroupChangedEvent(ElementGroup previousGroup, ElementGroup newGroup)
	{
		this.OnGroupChanged?.Invoke(previousGroup, newGroup);
	}

	public void ClearSegments()
	{
		if (AllElementGroupSegments == null)
		{
			return;
		}
		foreach (ElementGroupSegment allElementGroupSegment in AllElementGroupSegments)
		{
			allElementGroupSegment.gameObject.SetActive(value: false);
			UnityEngine.Object.Destroy(allElementGroupSegment.gameObject);
		}
		AllElementGroupSegments = new List<ElementGroupSegment>();
	}

	public void RotateTo(int targetRotation, bool animate = true)
	{
		RotationIndex = targetRotation;
		tileVisual.Rotate(RotationIndex, animate);
	}

	public void InitializeVisual()
	{
		foreach (ElementGroupSegment allElementGroupSegment in AllElementGroupSegments)
		{
			allElementGroupSegment.Randomize(seed);
		}
		for (int i = 0; i < InstanceableDecoration.Count; i++)
		{
			InstanceableDecoration[i].Randomize(seed + i);
		}
		tileVisual.Initialize();
	}

	public void PlacementCompleted()
	{
		ChangeTileState(TileState.placed);
		for (int i = 0; i < 6; i++)
		{
			if (Neighbors[i] != null)
			{
				PlaceNeighbor(i, NeighborTiles[i]);
				NeighborTiles[i].PlaceNeighbor((i + 3) % 6, this);
			}
		}
		this.OnPlaced?.Invoke(this);
	}

	public void SetGridPos(Vector2Int targetGridPos)
	{
		GridPos = targetGridPos;
		base.name = $"PreviewTile ({GridPos.x}|{GridPos.y})";
		foreach (ElementGroupSegment allElementGroupSegment in AllElementGroupSegments)
		{
			allElementGroupSegment.UpdateName();
		}
	}

	public void SetBiomeInfluence(Dictionary<Biome, float> biomeInfluenceDictionary)
	{
		CurrentBiomeInfluence = biomeInfluenceDictionary;
		debug_biomeInfluence.Clear();
		foreach (KeyValuePair<Biome, float> item in biomeInfluenceDictionary)
		{
			debug_biomeInfluence.Add(new Debug_BiomeInfluence(item.Key, item.Value));
		}
	}

	public void Animate(bool newAnimate)
	{
		if ((bool)GetComponentInChildren<Animator>())
		{
			GetComponentInChildren<Animator>().speed = (newAnimate ? 1 : 0);
		}
	}

	public void SetGroundReplacement(MeshRenderer overwriteGround)
	{
		if (tileVisual == null)
		{
			Debug.LogError($"{this} has no tileVisual");
		}
		else
		{
			tileVisual.SetGroundReplacement(overwriteGround);
		}
	}

	public void SetIsCurrentTile(bool newIsCurrentTile)
	{
		IsCurrentTile = newIsCurrentTile;
	}

	public void StartWobble(float startDelay)
	{
		StartCoroutine(Wobble(startDelay));
	}

	private IEnumerator Wobble(float startDelay)
	{
		return new _003CWobble_003Ed__152(0)
		{
			_003C_003E4__this = this,
			startDelay = startDelay
		};
	}

	public void SetMaterials(Material newMaterial)
	{
		Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>(includeInactive: true);
		foreach (Renderer renderer in componentsInChildren)
		{
			Material[] array = new Material[renderer.materials.Length];
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = newMaterial;
			}
			renderer.sharedMaterials = array;
		}
	}

	public virtual void DestroyTile(bool animate = false)
	{
		foreach (ElementGroup allElementGroup in AllElementGroups)
		{
			UnityEngine.Object.Destroy(allElementGroup.gameObject);
		}
		if (Enumerable.Count(NeighborTiles, (Tile x) => x != null) > 0)
		{
			Debug.LogError($"{base.name} is destroyed but has {Enumerable.Count(NeighborTiles, (Tile x) => x != null)} neighbors");
		}
		foreach (ElementGroupSegment allElementGroupSegment in AllElementGroupSegments)
		{
			foreach (Element allElement in allElementGroupSegment.AllElements)
			{
				allElement.ChangeTileState(TileState.placementPreview);
			}
			allElementGroupSegment.ChangeTileState(TileState.placementPreview);
		}
		foreach (Element item in Decoration)
		{
			item.ChangeTileState(TileState.placementPreview);
		}
		foreach (InstanceableVisual item2 in InstanceableDecoration)
		{
			item2.ChangeTileState(TileState.placementPreview);
		}
		tileVisual.ChangeTileState(TileState.placementPreview);
		destroyed = true;
		this.OnDestroyed?.Invoke();
		if (animate)
		{
			Sequence sequence = DOTween.Sequence();
			TweenSettingsExtensions.Insert(sequence, 0f, TweenSettingsExtensions.SetEase(ShortcutExtensions.DOScaleX(base.transform, 0f, destroyAnimationDuration), destroyAnimationEasing));
			TweenSettingsExtensions.Insert(sequence, 0f, TweenSettingsExtensions.SetEase(ShortcutExtensions.DOScaleZ(base.transform, 0f, destroyAnimationDuration), destroyAnimationEasing));
			TweenSettingsExtensions.OnComplete(sequence, delegate
			{
				UnityEngine.Object.Destroy(base.gameObject);
			});
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public void AddRunningAnimation(Tween tween)
	{
		runningAnimations.Add(tween);
		if (runningAnimations.Count < 1)
		{
			return;
		}
		foreach (ITileStateReceiver tileStateReceiver in tileStateReceivers)
		{
			tileStateReceiver.SetAnimationsRunning(animationsRunning: true);
		}
		foreach (InstanceableVisual item in InstanceableDecoration)
		{
			item.SetAnimationsRunning(animationsRunning: true);
		}
	}

	public void RemoveRunningAnimation(Tween tween)
	{
		runningAnimations.Remove(tween);
		if (runningAnimations.Count == 0)
		{
			StartCoroutine(BroadcastAnimationStopAtEndOfFrame());
		}
	}

	private IEnumerator BroadcastAnimationStopAtEndOfFrame()
	{
		return new _003CBroadcastAnimationStopAtEndOfFrame_003Ed__157(0)
		{
			_003C_003E4__this = this
		};
	}

	public void AddDecorationData(DecorationElement[] decorationElements)
	{
		foreach (DecorationElement decorationElement in decorationElements)
		{
			if (decorationElement.ElementType == null || decorationElement.ElementType.instancingInfo == null)
			{
				Debug.Log($"Skipping {decorationElement} because it has no elementType or {decorationElement.ElementType} has no instancing info");
				continue;
			}
			InstanceableVisual instanceableVisual = new InstanceableVisual();
			instanceableVisual.SetElementType(decorationElement.ElementType);
			instanceableVisual.Initialize(tileVisual.transform, decorationElement.transform.localPosition);
			instanceableVisual.Randomize(Seed + InstanceableDecoration.Count);
			InstanceableDecoration.Add(instanceableVisual);
		}
	}

	private void ReadDecorationData(bool destroyElements = true)
	{
		tileVisual = GetComponentInChildren<TileVisual>();
		DecorationElement[] array = Enumerable.ToArray(Enumerable.Where(GetComponentsInChildren<DecorationElement>(), (DecorationElement x) => x.ElementType != null && x.ElementType.instancingInfo != null));
		AddDecorationData(array);
		if (destroyElements)
		{
			for (int num = array.Length - 1; num >= 0; num--)
			{
			}
		}
	}

	internal static float _003CWobble_003Eg__Jitter_007C152_0()
	{
		return UnityEngine.Random.Range(0.7f, 1.3f);
	}

	private void _003CWobble_003Eb__152_1()
	{
		ShortcutExtensions.DOMoveY(base.transform, 0f, 0f);
	}

	private void _003CWobble_003Eb__152_2()
	{
		ShortcutExtensions.DORotate(base.transform, Vector3.zero, 0f);
	}

	private void _003CWobble_003Eb__152_3()
	{
		RemoveRunningAnimation(wobbleTween);
	}

	private void _003CDestroyTile_003Eb__154_2()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
