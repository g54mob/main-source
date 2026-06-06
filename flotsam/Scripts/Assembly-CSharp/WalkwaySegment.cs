using System;
using System.Collections.Generic;
using PajamaLlama.Debugs;
using PajamaLlama.Math;
using UnityEngine;

public class WalkwaySegment : SceneBehaviour, IBuildableExtendable, IPersistentReference
{
	[Header("Properties")]
	public int Length;

	public int Width = 1;

	public Construction Construction;

	public float HierarchicalMarkerSpread = 1.5f;

	public Transform OutlineParent;

	public Obstacle Obstacle;

	[SerializeField]
	private BoxCollider _collider;

	private float _scaledLength;

	private Hookable _startHookable;

	private Hookable _endHookable;

	private WalkwayScalable[] _scalables;

	private Transform _startTransform;

	private Transform _endTransform;

	private bool _canBeSalvaged;

	public Buildable Buildable { get; private set; }

	public bool Active { get; private set; }

	public int PersistentIndex { get; set; } = -1;

	public Vector3 StartPosition { get; private set; }

	public Vector3 EndPosition { get; private set; }

	public HierarchicalNodeMarker[] _futureHierarchicalNodeMarkers { get; private set; }

	public void InitializeSegment(Vector3 startLocation, Vector3 endLocation, Hookable startHookable, Hookable endHookable, float scaledLength)
	{
		InstantiateHooks(startLocation, endLocation, startHookable, endHookable, scaledLength);
		startHookable.Buildable.OnBuildableUpgradedEvent.AddListener(OnNeighbourConstructionUpgrade);
		Buildable.OnBuildableUpgradedEvent.AddListener(OnNeighbourConstructionUpgrade);
		endHookable.Buildable.OnBuildableUpgradedEvent.AddListener(OnNeighbourConstructionUpgrade);
		if (Construction != null && Obstacle != null)
		{
			InstantiateFutureHierarchicalMarkers(_scaledLength);
		}
	}

	private void InstantiateHooks(Vector3 startLocation, Vector3 endLocation, Hookable startHookable, Hookable endHookable, float scaledLength)
	{
		StartPosition = startLocation;
		EndPosition = endLocation;
		GameObject gameObject = new GameObject("LineStart");
		GameObject gameObject2 = new GameObject("LineEnd");
		gameObject.transform.position = startLocation;
		gameObject2.transform.position = endLocation;
		gameObject.transform.SetParent(startHookable.Buildable.BuoyantTransform, worldPositionStays: true);
		gameObject.transform.localPosition = gameObject.transform.localPosition.SetY(startHookable.HookHeightOffset);
		gameObject2.transform.SetParent(endHookable.Buildable.BuoyantTransform, worldPositionStays: true);
		gameObject2.transform.localPosition = gameObject2.transform.localPosition.SetY(endHookable.HookHeightOffset);
		_startTransform = gameObject.transform;
		_endTransform = gameObject2.transform;
		_scaledLength = scaledLength;
		_collider.size = FlotsamGame.SetZ(_collider.size, scaledLength);
		_startHookable = startHookable;
		_endHookable = endHookable;
	}

	public void SetStartHookable(Hookable hookable, Vector3 segmentStartPositionAdjustment = default(Vector3))
	{
		if (_startHookable != null)
		{
			_startHookable.Buildable.OnBuildableUpgradedEvent.RemoveListener(OnNeighbourConstructionUpgrade);
		}
		_startHookable = hookable;
		_startHookable.Buildable.OnBuildableUpgradedEvent.AddListener(OnNeighbourConstructionUpgrade);
		_startTransform.position += segmentStartPositionAdjustment;
		_startTransform.SetParent(hookable.Buildable.BuoyantTransform, worldPositionStays: true);
		_startTransform.localPosition = _startTransform.localPosition.SetY(hookable.HookHeightOffset);
	}

	public void SetEndHookable(Hookable hookable, Vector3 segmentEndPositionAdjustment = default(Vector3))
	{
		if (_endHookable != null)
		{
			_endHookable.Buildable.OnBuildableUpgradedEvent.RemoveListener(OnNeighbourConstructionUpgrade);
		}
		_endHookable = hookable;
		_endHookable.Buildable.OnBuildableUpgradedEvent.AddListener(OnNeighbourConstructionUpgrade);
		_endTransform.position += segmentEndPositionAdjustment;
		_endTransform.SetParent(hookable.Buildable.BuoyantTransform, worldPositionStays: true);
		_endTransform.localPosition = _endTransform.localPosition.SetY(hookable.HookHeightOffset);
	}

	private void LateUpdate()
	{
		if (_scaledLength < 1f)
		{
			Buildable.Remove();
			return;
		}
		Buildable.BuoyantTransform.position = Vector3.Lerp(_startTransform.position, _endTransform.position, 0.5f);
		Buildable.BuoyantTransform.rotation = FlotsamGame.PointsToRotation(_startTransform.position, _endTransform.position, level: false);
	}

	public void Initialize(Buildable buildable, bool restored = false)
	{
		Buildable = buildable;
		buildable.Community.AddWalkwaySegment(this);
		buildable.SetStatus(GameSettings.Instance.BuildableSettings.StatusBuildingProperties);
		_scalables = GetComponentsInChildren<WalkwayScalable>(includeInactive: true);
	}

	public void Finish(bool restored = false)
	{
		if (_startHookable != null)
		{
			_startHookable.Buildable.CancelDeconstruction();
		}
		if (_endHookable != null)
		{
			_endHookable.Buildable.CancelDeconstruction();
		}
		Buildable.SetStatus(GameSettings.Instance.BuildableSettings.StatusIdleProperties);
		if (!restored && Construction != null && Obstacle != null)
		{
			AddHierarchicalMarkersToConstructionGraph();
		}
	}

	public void Remove()
	{
		Buildable.Community.RemoveWalkwaySegment(this);
		RemoveListeners();
	}

	private void OnDestroy()
	{
		RemoveListeners();
	}

	private void OnDrawGizmos()
	{
		Debug.DrawLine(StartPosition.SetY(0f), EndPosition.SetY(0f));
	}

	private void RemoveListeners()
	{
		if (_startHookable == null)
		{
			Debugger.Warning("Start Hookable missing for walkway segment.", this);
		}
		else if (_endHookable == null)
		{
			Debugger.Warning("End Hookable missing for walkway segment.", this);
		}
	}

	public void UpdateScale()
	{
		Buildable.Boundary.SetSize(Buildable.Properties.Width, _scaledLength / 2f);
		WalkwayScalable.SetZScale(_scalables, _scaledLength / (float)Length);
	}

	public void ManuallySetBuildable()
	{
		if (Buildable == null)
		{
			Buildable = GetComponent<Buildable>();
		}
	}

	public bool IsMarkerInRange(Vector3 position, float range)
	{
		HierarchicalNodeMarker[] futureHierarchicalNodeMarkers = _futureHierarchicalNodeMarkers;
		foreach (HierarchicalNodeMarker hierarchicalNodeMarker in futureHierarchicalNodeMarkers)
		{
			if (hierarchicalNodeMarker.IsInRange(position, Mathf.Min(hierarchicalNodeMarker.Range, range)))
			{
				return true;
			}
		}
		return false;
	}

	private void OnNeighbourConstructionUpgrade(Buildable buildable, Buildable instantiatedBuildable)
	{
		if (_startHookable.Buildable == buildable)
		{
			_startHookable.Buildable.OnBuildableUpgradedEvent.RemoveListener(OnNeighbourConstructionUpgrade);
			if (instantiatedBuildable.TryReturnBuildableExtendable<Hookable>(out var buildableExtendable))
			{
				InstantiateHooks(StartPosition, EndPosition, buildableExtendable, _endHookable, _scaledLength);
			}
			_startHookable.Buildable.OnBuildableUpgradedEvent.AddListener(OnNeighbourConstructionUpgrade);
		}
		if (_endHookable.Buildable == buildable)
		{
			_endHookable.Buildable.OnBuildableUpgradedEvent.RemoveListener(OnNeighbourConstructionUpgrade);
			if (instantiatedBuildable.TryReturnBuildableExtendable<Hookable>(out var buildableExtendable2))
			{
				InstantiateHooks(StartPosition, EndPosition, _startHookable, buildableExtendable2, _scaledLength);
			}
			_endHookable.Buildable.OnBuildableUpgradedEvent.AddListener(OnNeighbourConstructionUpgrade);
		}
		if (Buildable == buildable)
		{
			_startHookable.Buildable.OnBuildableUpgradedEvent.RemoveListener(OnNeighbourConstructionUpgrade);
			Buildable.OnBuildableUpgradedEvent.RemoveListener(OnNeighbourConstructionUpgrade);
			_endHookable.Buildable.OnBuildableUpgradedEvent.RemoveListener(OnNeighbourConstructionUpgrade);
			if (instantiatedBuildable.TryReturnBuildableExtendable<WalkwaySegment>(out var buildableExtendable3))
			{
				buildableExtendable3.InitializeSegment(StartPosition, EndPosition, _startHookable, _endHookable, _scaledLength);
				buildableExtendable3.AddHierarchicalMarkersToConstructionGraph();
			}
		}
	}

	private void InstantiateFutureHierarchicalMarkers(float scaledLength)
	{
		if ((bool)Buildable.SpawnedVisual && (bool)Buildable.SpawnedVisual.HierarhicalNodeParent)
		{
			_futureHierarchicalNodeMarkers = Buildable.SpawnedVisual.HierarhicalNodeParent.GetComponentsInChildren<HierarchicalNodeMarker>(includeInactive: true);
			return;
		}
		int num = Mathf.CeilToInt(scaledLength / HierarchicalMarkerSpread);
		float num2 = scaledLength / (float)num;
		Vector3 zero = Vector3.zero;
		zero.z = 0f - scaledLength * 0.5f + num2 * 0.5f;
		_futureHierarchicalNodeMarkers = new HierarchicalNodeMarker[num * 2];
		for (int i = 0; i < num; i++)
		{
			Vector3 localPosition = new Vector3(zero.x - 0.5f, zero.y, zero.z + (float)i * num2);
			Vector3 localPosition2 = new Vector3(zero.x + 0.5f, zero.y, zero.z + (float)i * num2);
			_futureHierarchicalNodeMarkers[2 * i] = HierarchicalNodeMarker.Instantiate(localPosition, Obstacle.PrimaryMarker.transform, $"HierarchicalMarker{2 * i:D2}");
			_futureHierarchicalNodeMarkers[2 * i + 1] = HierarchicalNodeMarker.Instantiate(localPosition2, Obstacle.PrimaryMarker.transform, $"HierarchicalMarker{2 * i + 1:D2}");
		}
	}

	public void AddHierarchicalMarkersToConstructionGraph()
	{
		if ((bool)Buildable.SpawnedVisual && (bool)Buildable.SpawnedVisual.HierarhicalNodeParent)
		{
			Buildable.SpawnedVisual.HierarhicalNodeParent.SetActive(value: true);
		}
		if (_futureHierarchicalNodeMarkers == null)
		{
			InstantiateFutureHierarchicalMarkers(_scaledLength);
		}
		HierarchicalNodeMarker[] futureHierarchicalNodeMarkers = _futureHierarchicalNodeMarkers;
		for (int i = 0; i < futureHierarchicalNodeMarkers.Length; i++)
		{
			futureHierarchicalNodeMarkers[i].AddToConstructionGraph();
		}
		GraphManager.RefreshNavigatorPaths();
	}

	private bool TrySpawnPonton(out Hookable hookable, Vector3 hookPosition)
	{
		if (Buildable.Properties is WalkwaySegmentProperties walkwaySegmentProperties)
		{
			Buildable prefab = walkwaySegmentProperties.walkwayPontonProperties.Prefab;
			Buildable buildable = Buildable.Place(prefab, hookPosition, base.transform.rotation, prefab.VisualIndex, instantPlacement: true);
			if (buildable.TryReturnBuildableExtendable<Hookable>(out hookable))
			{
				if (Construction != null && buildable.TryReturnBuildableExtendable<Construction>(out var buildableExtendable))
				{
					Construction.AddNeighbourConstruction(buildableExtendable);
					buildableExtendable.AddNeighbourConstruction(Construction);
				}
				return true;
			}
		}
		hookable = null;
		return false;
	}

	public bool IsEnabled()
	{
		return true;
	}

	public bool CanBeSalvaged()
	{
		return ReturnCanSalvage();
	}

	public bool CanBeUpgraded()
	{
		return true;
	}

	public bool CanBeSalvaged(ref List<Buildable> walkwayPontons)
	{
		if (!_startHookable.Construction.IsConnectedToTownheart(Construction))
		{
			walkwayPontons.Add(_startHookable.Buildable);
		}
		if (!_endHookable.Construction.IsConnectedToTownheart(Construction))
		{
			walkwayPontons.Add(_endHookable.Buildable);
		}
		return ReturnCanSalvage();
	}

	public void OnHaulFromBuildable()
	{
		if (_startHookable != null && !_startHookable.Construction.IsConnectedToTownheart(Construction))
		{
			_startHookable.Remove();
		}
		if (_endHookable != null && !_endHookable.Construction.IsConnectedToTownheart(Construction))
		{
			_endHookable.Remove();
		}
	}

	private bool ConstructionBlocksSalvaging(Construction construction)
	{
		if (!IsStartOrEndHookable(construction.Buildable) && (!construction.IsConnectedToTownheart(Construction) || !construction.Buildable.TryReturnBuildableExtendable<WalkwaySegment>(out var buildableExtendable) || !buildableExtendable.IsStartOrEndHookable(Buildable)))
		{
			return !(construction == Construction.Townheart);
		}
		return false;
	}

	private bool IsStartOrEndHookable(Buildable buildable)
	{
		if (!_startHookable || !(_startHookable.Buildable == buildable))
		{
			if ((bool)_endHookable)
			{
				return _endHookable.Buildable == buildable;
			}
			return false;
		}
		return true;
	}

	public void Shutdown()
	{
		Deactivate();
	}

	public void Activate()
	{
		Active = true;
	}

	public void Deactivate()
	{
		Active = false;
	}

	public void ShutdownImmediately()
	{
		throw new NotImplementedException();
	}

	public IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return new SegmentPersistentData(this, _scaledLength);
	}

	public void Restore(IBuildableExtendablePersistentData persistentData)
	{
		if (Buildable.BuildPhase == BuildPhase.Build || Buildable.BuildPhase == BuildPhase.HaulTo)
		{
			Buildable.SpawnedVisual.SetProgress(0f);
		}
	}

	public void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
		SegmentPersistentData segmentPersistentData = persistentData as SegmentPersistentData;
		Hookable instance = null;
		Hookable instance2 = null;
		if (segmentPersistentData.StartConstruction != null && segmentPersistentData.StartConstruction.TryReturn(out var instance3))
		{
			instance = instance3.GetComponent<Hookable>();
		}
		if (segmentPersistentData.EndConstruction != null && segmentPersistentData.EndConstruction.TryReturn(out instance3))
		{
			instance2 = instance3.GetComponent<Hookable>();
		}
		if (segmentPersistentData.StartHookable != null)
		{
			segmentPersistentData.StartHookable.TryReturn(out instance);
		}
		if (segmentPersistentData.EndHookable != null)
		{
			segmentPersistentData.EndHookable.TryReturn(out instance2);
		}
		if (instance == null)
		{
			if (!TrySpawnPonton(out instance, segmentPersistentData.StartPosition))
			{
				Debug.LogException(new Exception("Unable to spawn replacement for missing start hookable referene"));
			}
			else
			{
				Debug.LogError("Spawned start hookable", instance);
			}
		}
		if (instance2 == null)
		{
			if (!TrySpawnPonton(out instance2, segmentPersistentData.EndPosition))
			{
				Debug.LogException(new Exception("Unable to spawn replacement for missing end hookable referene"));
			}
			else
			{
				Debug.LogError("Spawned end hookable", instance2);
			}
		}
		InitializeSegment(segmentPersistentData.StartPosition, segmentPersistentData.EndPosition, instance, instance2, segmentPersistentData.ScaledLength);
		Finish(Buildable.BuildPhase != BuildPhase.Finished);
		UpdateScale();
		if (Buildable.BuildPhase == BuildPhase.HaulFrom)
		{
			OnHaulFromBuildable();
		}
		if (Buildable.BuildPhase == BuildPhase.Build)
		{
			Buildable.StartBuilding();
		}
	}

	public void PopulateReferences(IBuildableExtendablePersistentData persistentData)
	{
		SegmentPersistentData obj = persistentData as SegmentPersistentData;
		obj.StartHookable = _startHookable;
		obj.EndHookable = _endHookable;
	}

	public void OnDeconstruct()
	{
	}

	public bool CanBeDeconstructed()
	{
		return CanBeSalvaged();
	}

	public void Upgrade(Buildable buildable)
	{
	}

	public void ShowResearchInfo(RectTransform parent)
	{
	}

	public string ReturnDescription(string text)
	{
		return text;
	}

	public float ReturnWeight()
	{
		return 0f;
	}

	private bool ReturnCanSalvage()
	{
		if (_startHookable == null || _endHookable == null)
		{
			return false;
		}
		if (CanRemoveHookable(_startHookable) && CanRemoveHookable(_endHookable))
		{
			return !ReturnNeighboursBlockSalvaging();
		}
		return false;
	}

	private bool CanRemoveHookable(Hookable hookable)
	{
		if ((bool)hookable)
		{
			if (hookable.Construction.IsConnectedToTownheart(Construction))
			{
				return true;
			}
			if (hookable.Buildable.TryReturnBuildableExtendable<WalkwayPonton>(out var buildableExtendable))
			{
				buildableExtendable.UpdateCanSalvage();
				return buildableExtendable.CanBeDeconstructed();
			}
		}
		return false;
	}

	public bool ReturnNeighboursBlockSalvaging()
	{
		if (Construction == null)
		{
			return true;
		}
		foreach (Construction neighbourConstruction in Construction.NeighbourConstructions)
		{
			if (ConstructionBlocksSalvaging(neighbourConstruction))
			{
				return true;
			}
		}
		return false;
	}

	public void ReturnBlockingNeighbours(ref ListPool<VisualPrefab>.List blockingConstructions)
	{
		if (Construction == null)
		{
			return;
		}
		foreach (Construction neighbourConstruction in Construction.NeighbourConstructions)
		{
			VisualPrefab energyPole;
			if (ConstructionBlocksSalvaging(neighbourConstruction))
			{
				blockingConstructions.Add(neighbourConstruction.Buildable.SpawnedVisual);
			}
			else if (TryGetOwningPontonEnergyPole(neighbourConstruction, out energyPole))
			{
				blockingConstructions.Add(energyPole);
			}
		}
		PopulateBlockingNeighbours(_startHookable, ref blockingConstructions);
		PopulateBlockingNeighbours(_endHookable, ref blockingConstructions);
	}

	public bool IsHookedTo(Hookable hookable, out bool isHookedToEnd)
	{
		if (_endHookable == hookable)
		{
			isHookedToEnd = true;
			return true;
		}
		if (_startHookable == hookable)
		{
			isHookedToEnd = false;
			return true;
		}
		isHookedToEnd = false;
		return false;
	}

	private bool TryGetOwningPontonEnergyPole(Construction construction, out VisualPrefab energyPole)
	{
		if (construction.Buildable.TryReturnBuildableExtendable<WalkwayPonton>(out var buildableExtendable) && buildableExtendable.NeighbouringWalkwaySegments.Contains(this) && buildableExtendable.EnergyPole != null && buildableExtendable.EnergyPole.Decoration != null)
		{
			energyPole = buildableExtendable.EnergyPole.Decoration.SpawnedVisual;
			return true;
		}
		energyPole = null;
		return false;
	}

	private void PopulateBlockingNeighbours(Hookable hookable, ref ListPool<VisualPrefab>.List blockingConstructions)
	{
		if (hookable.Construction.IsConnectedToTownheart(Construction))
		{
			return;
		}
		foreach (Construction neighbourConstruction in hookable.Construction.NeighbourConstructions)
		{
			if (neighbourConstruction != Construction)
			{
				blockingConstructions.Add(neighbourConstruction.Buildable.SpawnedVisual);
			}
		}
	}

	public HierarchicalNodeMarker ReturnClosestHierarchicalNodeMarker(Vector3 position)
	{
		if (_futureHierarchicalNodeMarkers.IsNullOrEmpty())
		{
			return null;
		}
		HierarchicalNodeMarker result = null;
		float num = float.MaxValue;
		HierarchicalNodeMarker[] futureHierarchicalNodeMarkers = _futureHierarchicalNodeMarkers;
		foreach (HierarchicalNodeMarker hierarchicalNodeMarker in futureHierarchicalNodeMarkers)
		{
			float num2 = position.DistanceToLeveledSquared(hierarchicalNodeMarker.transform.position);
			if (num2 < num)
			{
				num = num2;
				result = hierarchicalNodeMarker;
			}
		}
		return result;
	}
}
