using System;
using System.Collections.Generic;
using PajamaLlama.Flotsam.Landmarks;
using PajamaLlama.Math;
using Unity.AI.Navigation;
using UnityEngine;

[RequireComponent(typeof(PhysicsController), typeof(Obstacle), typeof(NavMeshSurface))]
public class Landmark : MonoBehaviour, IPersistentReference
{
	[Header("Landmark")]
	[Tooltip("The physics properties of the landmark gameObject.")]
	[SerializeField]
	private PhysicsProperties _physicsProperties;

	[Tooltip("The target we use if we create a new project based on this landmark.")]
	[SerializeField]
	protected Target _projectTarget;

	[Tooltip("When focusing on the landmark, through the notification, this will decide how zoomed in/out we are. The larger the zoom the more zoomed out.")]
	[SerializeField]
	private float _cameraZoomLevel;

	[SerializeField]
	private float _scoutRadius;

	[SerializeField]
	private Sprite _notificationIcon;

	[SerializeField]
	private LandmarkActionSalvageableUnlockable[] _unlockables;

	[Header("Selection")]
	[Tooltip("Reference to the circle displayed when the landmark is selected.")]
	[SerializeField]
	private LandmarkSelectionCircle _selectionCircle;

	[Tooltip("Radius of the selection circle.")]
	[SerializeField]
	private float _circleRadius;

	[Header("Resource Override")]
	[SerializeField]
	private CountedItemProperty[] _itemOverrides;

	[Header("Debug")]
	[Tooltip("Turn this on if we want to start the interaction when we click on it and we want to skip the swimming of a drifter.")]
	[SerializeField]
	private bool _debug;

	private LandmarkBehaviour _behaviour;

	private PhysicsController _physicsController;

	protected Agent _investigator;

	private List<PathfindingNodeTarget> _scoutTargets;

	private Vector3 _positionOffset;

	public int PersistentIndex { get; set; } = -1;

	public LandmarkBehaviour Behaviour => _behaviour;

	public Obstacle Obstacle { get; private set; }

	public Target ProjectTarget => _projectTarget;

	public bool BeingInteractedWith => _behaviour.IsInteracting;

	public float CameraZoomLevel => _cameraZoomLevel;

	public float ScoutRadius => _scoutRadius;

	public Sprite NotificationIcon => _notificationIcon;

	public LandmarkActionSalvageableUnlockable[] Unlockables => _unlockables;

	public LandmarkMooringPoint[] MooringPoints { get; private set; }

	public bool IsInteractable => MooringPoints.Length != 0;

	public Vector3 PositionOffset { get; private set; }

	public virtual void Initialize(LandmarkBehaviour behaviour)
	{
		_behaviour = behaviour;
		_physicsController = GetComponent<PhysicsController>();
		_physicsController.Initialize(_physicsProperties);
		Obstacle = GetComponent<Obstacle>();
		Obstacle.Initialize();
		Buildable.BlockingPolygons.Add(Obstacle.Polygon);
		MooringPoints = GetComponentsInChildren<LandmarkMooringPoint>();
		Target target = Obstacle.ReturnTarget() as Target;
		if (target != null && target.PrimaryMarker != null)
		{
			target.PrimaryMarker.AddToConstructionGraph();
		}
		SelectionLink componentInChildren = GetComponentInChildren<SelectionLink>(includeInactive: true);
		componentInChildren.SetOnSelectedListener(OnSelected);
		componentInChildren.SetOnDeselectedListener(OnDeselected);
		_selectionCircle = GetComponentInChildren<LandmarkSelectionCircle>();
		_selectionCircle.Initialize(_circleRadius, _selectionCircle.transform.position, Color.white);
		HideSelectionCircle();
		if (_debug)
		{
			componentInChildren.SetOnSelectedListener(DebugInteract);
		}
		ApplyOverrides();
		if (!IsInteractable)
		{
			LandmarkBase componentInChildren2 = GetComponentInChildren<LandmarkBase>();
			if (!(componentInChildren2 == null))
			{
				PositionOffset = new Vector3(0f, componentInChildren2.InactiveYOffsetRange.Minimum, 0f);
			}
		}
	}

	public void InitializeInteractables()
	{
		LandmarkInteractable[] componentsInChildren = GetComponentsInChildren<LandmarkInteractable>();
		foreach (LandmarkInteractable landmarkInteractable in componentsInChildren)
		{
			if (landmarkInteractable.Validate())
			{
				landmarkInteractable.Initialize(_behaviour);
			}
			else if (Application.isEditor)
			{
				Debug.LogException(new Exception($"Invalid interactable of type '{landmarkInteractable.GetType()}' found in landmark '{base.name}'"));
			}
		}
	}

	public void InitializeRescueables()
	{
		LandmarkRescueable[] componentsInChildren = GetComponentsInChildren<LandmarkRescueable>();
		foreach (LandmarkRescueable landmarkRescueable in componentsInChildren)
		{
			if (landmarkRescueable.Validate())
			{
				landmarkRescueable.Initialize(_behaviour);
			}
			else if (Application.isEditor)
			{
				Debug.LogException(new Exception("Invalid rescueable found in landmark '" + base.name + "'"));
			}
		}
	}

	public void ApplyOverrides()
	{
		LandmarkSalvageable[] componentsInChildren = GetComponentsInChildren<LandmarkSalvageable>();
		CountedItemProperty[] itemOverrides = _itemOverrides;
		foreach (CountedItemProperty countedItemProperty in itemOverrides)
		{
			ApplyOverride(componentsInChildren, countedItemProperty.ItemProperties, countedItemProperty.Amount);
		}
	}

	private void ApplyOverride(LandmarkSalvageable[] salvageables, ItemProperties itemProperties, int overrideAmount)
	{
		if (salvageables.IsNullOrEmpty())
		{
			return;
		}
		using ListPool<LandmarkSalvageable>.List list = ListPool<LandmarkSalvageable>.Get();
		int num = 0;
		foreach (LandmarkSalvageable landmarkSalvageable in salvageables)
		{
			if (landmarkSalvageable.TryReturnItemCount(itemProperties, out var itemCount))
			{
				num += itemCount;
				list.Add(landmarkSalvageable);
			}
		}
		if (list.Count == 0)
		{
			list.AddRange(salvageables);
		}
		int num2 = overrideAmount - num;
		int num3 = 0;
		int change;
		if (0 < num2)
		{
			change = 1;
		}
		else
		{
			change = -1;
			num2 *= -1;
		}
		for (int j = 0; j < num2; j++)
		{
			list[num3++].UpdateComposition(itemProperties, change);
			if (num3 == list.Count)
			{
				num3 = 0;
			}
		}
	}

	public void OnDrawGizmos()
	{
		if (_scoutTargets == null)
		{
			return;
		}
		Gizmos.color = Color.red;
		foreach (PathfindingNodeTarget scoutTarget in _scoutTargets)
		{
			Gizmos.DrawWireCube(scoutTarget.Position, Vector3.one);
		}
	}

	public bool Interact(Agent agent)
	{
		agent.UpdateActivity(Activity.Idling);
		return _behaviour.Interact(agent);
	}

	public void EndInteraction()
	{
		_behaviour.EndInteraction();
	}

	public void ShowSelectionCircle()
	{
		_selectionCircle.gameObject.SetActive(value: true);
	}

	public void HideSelectionCircle()
	{
		_selectionCircle.gameObject.SetActive(value: false);
	}

	public void DebugInteract(bool value)
	{
		_behaviour.Interact(Community.PlayerCommunity.Agents[0]);
	}

	protected virtual void OnDestroy()
	{
		_behaviour.DestroyLandmark();
		Buildable.BlockingPolygons.Remove(Obstacle.Polygon);
	}

	public void OnSelected(bool playSelectionSound)
	{
		ShowSelectionCircle();
		LandmarkNotificationEvent.Selected(this);
	}

	public void OnDeselected()
	{
		HideSelectionCircle();
		LandmarkNotificationEvent.Deselected(this);
	}

	public bool IsInSwimmingRadius(bool useWorldMapPosition = false)
	{
		return IsInRadius(useWorldMapPosition ? new WorldManager.IsInRadius(GameManager.WorldManager.IsInSwimmingRadiusOnWorldMap) : new WorldManager.IsInRadius(GameManager.WorldManager.IsInSwimmingRadius));
	}

	public bool IsInBoatRadius()
	{
		return IsInRadius(GameManager.WorldManager.IsInBoatRadius);
	}

	public bool IsInRadius(WorldManager.IsInRadius isInRadiusCallback)
	{
		if (MooringPoints.IsNullOrEmpty())
		{
			return false;
		}
		LandmarkMooringPoint[] mooringPoints = MooringPoints;
		foreach (LandmarkMooringPoint landmarkMooringPoint in mooringPoints)
		{
			if (isInRadiusCallback(landmarkMooringPoint.EntranceTransform.position))
			{
				return true;
			}
		}
		foreach (Transform item in Obstacle.Polygon.ReturnVertices())
		{
			if (isInRadiusCallback(item.position))
			{
				return true;
			}
		}
		return false;
	}

	public MooringPointBase ReturnMooringPoint(bool empty)
	{
		if (MooringPoints == null || MooringPoints.Length == 0)
		{
			return null;
		}
		LandmarkMooringPoint[] mooringPoints = MooringPoints;
		foreach (LandmarkMooringPoint landmarkMooringPoint in mooringPoints)
		{
			if (landmarkMooringPoint.IsEmpty == empty)
			{
				return landmarkMooringPoint;
			}
		}
		return null;
	}

	public List<PathfindingNodeTarget> ReturnScoutTargets(Vector3 agentPosition)
	{
		if (_scoutTargets == null)
		{
			_scoutTargets = new List<PathfindingNodeTarget>(3);
		}
		else
		{
			_scoutTargets.Clear();
		}
		Quaternion quaternion = Quaternion.AngleAxis((UnityEngine.Random.Range(0, 100) < 50) ? 90 : (-90), Vector3.forward);
		Vector2 vector = base.transform.position.Vector2TopDown();
		Vector2 vector2 = (agentPosition.Vector2TopDown() - vector).normalized * _scoutRadius;
		for (int i = 0; i < 3; i++)
		{
			vector2 = quaternion * vector2;
			_scoutTargets.Add(new PathfindingNodeTarget(GameManager.GraphManager.WaterSurfaceGraph.ReturnNode(vector + vector2)));
		}
		return _scoutTargets;
	}

	public float ReturnClearanceRadius()
	{
		if (Obstacle == null)
		{
			Obstacle = GetComponent<Obstacle>();
		}
		return Obstacle.Polygon.ReturnBoundingRadius();
	}
}
