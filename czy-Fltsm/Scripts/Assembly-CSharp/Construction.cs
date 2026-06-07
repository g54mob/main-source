using System;
using System.Collections.Generic;
using PajamaLlama.Debugs;
using PajamaLlama.Math;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Obstacle), typeof(Inventory))]
public class Construction : MonoBehaviour, IPersistentReference, IBuildableExtendable
{
	[Tooltip("Allow buildings to snap to the side.")]
	public bool AllowSideSnapping = true;

	public bool GenerateObstacleVertices = true;

	private static readonly HashSet<Construction> _cachedIgnoredConstructions = new HashSet<Construction>();

	private Obstacle _obstacle;

	private HierarchicalNodeMarker[] _hierarchicalNodeMarkers;

	public UnityEvent OnNeighbourChangeEvent = new UnityEvent();

	public static UnityEvent OnNeighboursChangedEvent = new UnityEvent();

	public List<Construction> NeighbourConstructions { get; private set; } = new List<Construction>();

	public bool Active { get; private set; }

	public int PersistentIndex { get; set; } = -1;

	public HierarchicalNodeMarker BuildPhaseTargetMarker { get; private set; }

	public static Construction Townheart { get; set; }

	public static Vector3 TownheartPosition
	{
		get
		{
			if ((bool)Townheart)
			{
				return Townheart.transform.position;
			}
			return Vector3.zero;
		}
	}

	public Target Target { get; private set; }

	public Buildable Buildable { get; private set; }

	private void Awake()
	{
		_obstacle = GetComponent<Obstacle>();
		_hierarchicalNodeMarkers = GetComponentsInChildren<HierarchicalNodeMarker>();
		Target = _obstacle;
	}

	private void Start()
	{
		if (LoadingScreen.IsLoading)
		{
			GameEventDispatcher.AddListener(GameEventType.LoadingCompleted, UpdateBuildPhaseTargetMarker);
		}
		else
		{
			UpdateBuildPhaseTargetMarker();
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		for (int i = 0; i < NeighbourConstructions.Count; i++)
		{
			if (NeighbourConstructions[i] == null)
			{
				Debugger.Log("neighbour is null.");
			}
			Gizmos.DrawLine(base.transform.position.Leveled() + new Vector3(0f, 10f, 0f), NeighbourConstructions[i].transform.position.Leveled() + new Vector3(0f, 10f, 0f));
		}
	}

	public void Initialize(Buildable buildable, bool restored = false)
	{
		Buildable = buildable;
		Target.SetConstruction(this);
		if (GenerateObstacleVertices)
		{
			_obstacle.Initialize(buildable.OutlineCorners, Buildable.Properties.PathfindingOutlines);
		}
		else
		{
			_obstacle.Initialize();
		}
		Target.PrimaryMarker.AddToConstructionGraph();
		GraphManager.RefreshNavigatorPaths();
		buildable.Community.AddConstruction(this);
	}

	public void Finish(bool restored = false)
	{
	}

	public void Remove()
	{
		Agent[] componentsInChildren = GetComponentsInChildren<Agent>();
		foreach (Agent agent in componentsInChildren)
		{
			DetachAgent(agent);
		}
		Target.PrimaryMarker.RemoveFromConstructionGraph();
		GraphManager.RefreshNavigatorPaths();
		Buildable.Community.RemoveConstruction(this);
		for (int j = 0; j < NeighbourConstructions.Count; j++)
		{
			NeighbourConstructions[j].RemoveNeighbour(this);
		}
		NeighbourConstructions.Clear();
	}

	private void DetachAgent(Agent agent)
	{
		if (agent.Boat == null)
		{
			Navigator navigator = agent.ReturnNavigator();
			Vector3 position = agent.transform.position;
			Construction construction = null;
			float num = float.MaxValue;
			foreach (Construction neighbourConstruction in NeighbourConstructions)
			{
				float num2 = neighbourConstruction.transform.position.DistanceToLeveledSquared(position);
				if (num2 < num)
				{
					construction = neighbourConstruction;
					num = num2;
				}
			}
			if (construction != null)
			{
				navigator.AttachToTarget(construction.Target);
				return;
			}
		}
		agent.transform.SetParent(GameManager.AgentManager.AgentParent);
		agent.ReturnNavigator().StopIdling();
		Vector3 position2 = base.transform.position;
		agent.ReturnNavigator(alwaysReturnDrifter: true).PlaceAt(position2, overrideCheck: true, placeOnObstacle: false);
		agent.TryGoToTown();
	}

	public bool AddNeighbourConstruction(Construction neighbour)
	{
		if (NeighbourConstructions.AddUnique(neighbour))
		{
			OnNeighbourChangeEvent.Invoke();
			OnNeighboursChangedEvent.Invoke();
			UpdateBuildPhaseTargetMarker();
			return true;
		}
		return false;
	}

	public bool RemoveNeighbour(Construction neighbour)
	{
		if (NeighbourConstructions.Remove(neighbour))
		{
			OnNeighbourChangeEvent.Invoke();
			OnNeighboursChangedEvent.Invoke();
			UpdateBuildPhaseTargetMarker();
			return true;
		}
		return false;
	}

	public void RemoveNeighbours()
	{
		if (NeighbourConstructions.Count != 0)
		{
			for (int num = NeighbourConstructions.Count - 1; num >= 0; num--)
			{
				RemoveNeighbour(NeighbourConstructions[num]);
			}
		}
	}

	private void UpdateBuildPhaseTargetMarker(GameEvent gameEvent = null)
	{
		if (LoadingScreen.IsLoading)
		{
			return;
		}
		GameEventDispatcher.RemoveListener(GameEventType.LoadingCompleted, UpdateBuildPhaseTargetMarker);
		Vector3 position = Target.PrimaryMarker.transform.position;
		float num = float.MaxValue;
		BuildPhaseTargetMarker = null;
		foreach (Construction neighbourConstruction in NeighbourConstructions)
		{
			if (neighbourConstruction.IsConnectedToTownheart() && neighbourConstruction.Buildable.TryReturnBuildableExtendable<Hookable>(out var buildableExtendable) && buildableExtendable.TryReturnClosestHierarchicalNodeMarker(out var closestMarker, Target.PrimaryMarker.transform.position))
			{
				float num2 = position.DistanceToLeveledSquared(closestMarker.transform.position);
				if (num2 < num)
				{
					BuildPhaseTargetMarker = closestMarker;
					num = num2;
				}
			}
		}
	}

	public bool CanStartBuilding()
	{
		if (!Buildable.Properties.NeedsTownConnection)
		{
			return true;
		}
		for (int i = 0; i < NeighbourConstructions.Count; i++)
		{
			if (NeighbourConstructions[i].Buildable.BuildPhase == BuildPhase.Finished)
			{
				return true;
			}
		}
		return false;
	}

	public ITarget ReturnGoToTownTarget(Agent agent)
	{
		if (_hierarchicalNodeMarkers == null || _hierarchicalNodeMarkers.Length == 0)
		{
			return Target;
		}
		Vector3 position = agent.transform.position;
		HierarchicalNodeMarker[] hierarchicalNodeMarkers = _hierarchicalNodeMarkers;
		foreach (HierarchicalNodeMarker hierarchicalNodeMarker in hierarchicalNodeMarkers)
		{
			if (hierarchicalNodeMarker.Children != null && hierarchicalNodeMarker.Children.Length != 0 && hierarchicalNodeMarker.Node != null)
			{
				return new PathfindingNodeTarget(hierarchicalNodeMarker.Node.ReturnClosestNode(position));
			}
		}
		return Target;
	}

	public bool IsConnectedToTownheart()
	{
		_cachedIgnoredConstructions.Clear();
		return IsConnectedToTownheartInternal();
	}

	public bool IsConnectedToTownheart(Construction ignoredConstruction)
	{
		_cachedIgnoredConstructions.Clear();
		_cachedIgnoredConstructions.Add(ignoredConstruction);
		return IsConnectedToTownheartInternal();
	}

	private bool IsConnectedToTownheartInternal()
	{
		if (this == Townheart)
		{
			return true;
		}
		_cachedIgnoredConstructions.Add(this);
		foreach (Construction neighbourConstruction in NeighbourConstructions)
		{
			if (!neighbourConstruction.IsBeingSalvaged() && !_cachedIgnoredConstructions.Contains(neighbourConstruction) && (neighbourConstruction == Townheart || neighbourConstruction.IsConnectedToTownheartInternal()))
			{
				return true;
			}
		}
		return false;
	}

	public float ReturnWeight()
	{
		return 0f;
	}

	public bool TryReturnBuildablePhaseTargetNode(out HierarchicalNode node)
	{
		if (Buildable.BuildPhase == BuildPhase.Finished || BuildPhaseTargetMarker == null)
		{
			node = null;
		}
		else
		{
			node = BuildPhaseTargetMarker.Node;
		}
		return node != null;
	}

	public void Activate()
	{
		Active = true;
	}

	public void Deactivate()
	{
		Active = false;
	}

	public void Shutdown()
	{
		Deactivate();
	}

	public void ShutdownImmediately()
	{
		throw new NotImplementedException();
	}

	public bool CanBeSalvaged()
	{
		return true;
	}

	public bool IsEnabled()
	{
		if (Active)
		{
			return Buildable.BuildPhase == BuildPhase.Finished;
		}
		return false;
	}

	public IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return new ConstructionPersistentData(this);
	}

	public void Restore(IBuildableExtendablePersistentData persistentData)
	{
	}

	public void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
		ConstructionPersistentData constructionPersistentData = persistentData as ConstructionPersistentData;
		for (int i = 0; i < constructionPersistentData.Neighbours.Length; i++)
		{
			if (constructionPersistentData.Neighbours[i].TryReturn(out var instance))
			{
				AddNeighbourConstruction(instance);
			}
		}
	}

	public void PopulateReferences(IBuildableExtendablePersistentData persistentData)
	{
		ConstructionPersistentData constructionPersistentData = persistentData as ConstructionPersistentData;
		constructionPersistentData.Neighbours = new PersistentReference<Construction>.Reference[NeighbourConstructions.Count];
		for (int i = 0; i < NeighbourConstructions.Count; i++)
		{
			constructionPersistentData.Neighbours[i] = NeighbourConstructions[i];
		}
	}

	public void OnDeconstruct()
	{
	}

	public bool CanBeDeconstructed()
	{
		return true;
	}

	public void Upgrade(Buildable upgradedBuildable)
	{
		Construction component = upgradedBuildable.GetComponent<Construction>();
		foreach (Construction neighbourConstruction in NeighbourConstructions)
		{
			if (neighbourConstruction.AddNeighbourConstruction(component))
			{
				component.AddNeighbourConstruction(neighbourConstruction);
			}
		}
	}

	public void ShowResearchInfo(RectTransform parent)
	{
	}

	public string ReturnDescription(string text)
	{
		return text;
	}

	private bool IsBeingSalvaged()
	{
		BuildPhase buildPhase = Buildable.BuildPhase;
		if ((uint)(buildPhase - 2) <= 1u || buildPhase == BuildPhase.HaulFrom)
		{
			return true;
		}
		return false;
	}
}
