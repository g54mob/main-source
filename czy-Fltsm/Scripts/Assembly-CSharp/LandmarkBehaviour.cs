using System.Collections;
using I2.Loc;
using PajamaLlama.Flotsam.Landmarks;
using PajamaLlama.Flotsam.World;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public abstract class LandmarkBehaviour : PersistentProperties, ILandmarkBehaviourProvider, ITooltipProvider
{
	public class Event : UnityEvent<LandmarkBehaviour, object>
	{
	}

	private const float CLEARANCE_BUFFER = 10f;

	[Header("Landmark")]
	[SerializeField]
	[FormerlySerializedAs("Name")]
	private LocalizedString _name = "";

	public LocalizedString Description = "";

	[SerializeField]
	private Landmark _landmarkPrefab;

	[SerializeField]
	private LandmarkFeature _primaryLandmarkFeature;

	[SerializeField]
	internal Sprite _uiIcon;

	public float MapAvoidanceRadius = 75f;

	[Header("Audio")]
	public AudioClipProperties landmarkMusic;

	[Header("Misc")]
	public WorldMapLandmark MapPrefab;

	[Header("Scouting")]
	public WorldMapScoutingId ScoutingId;

	[FormerlySerializedAs("BearingIcon")]
	[SerializeField]
	private Sprite _bearingIcon;

	[Header("Pollution")]
	[SerializeField]
	[Min(0f)]
	private float _pollutionPerDay;

	protected SelectionLink _selectionLink;

	private Vector3 _spawnPosition;

	private bool _isScouted;

	public override Types Type => Types.LandmarkBehaviour;

	public string Name => _name;

	public LandmarkBehaviour Prefab { get; private set; }

	public Landmark Landmark { get; private set; }

	public bool RequiresScouting { get; protected set; }

	public bool IsScouted
	{
		get
		{
			if (RequiresScouting)
			{
				return _isScouted;
			}
			return true;
		}
	}

	public bool IsInteracting { get; private set; }

	public bool IsPanelOpen { get; set; }

	public static bool IsCameraLocked { get; set; }

	public Agent Actor { get; private set; }

	public Event UpdatedEvent { get; private set; }

	public LandmarkFeature PrimaryLandmarkFeature => _primaryLandmarkFeature;

	public float Radius => _landmarkPrefab.ScoutRadius;

	public GameObject LandmarkPrefabGameObject => _landmarkPrefab.gameObject;

	public string EditorName => base.name;

	public Sprite EditorIcon => null;

	public float PollutionPerDay => _pollutionPerDay;

	private void Awake()
	{
		_isScouted = false;
	}

	public virtual void Initialize()
	{
		if (UpdatedEvent == null)
		{
			UpdatedEvent = new Event();
		}
		else
		{
			UpdatedEvent.RemoveAllListeners();
		}
	}

	public virtual void Restore(LandmarkPersistentData persistentData)
	{
	}

	protected Landmark InstantiateLandmark(Vector3 position, Quaternion rotation, Transform parent = null)
	{
		Landmark = Object.Instantiate(_landmarkPrefab, position, rotation, parent);
		Landmark.Initialize(this);
		if (Landmark.IsInteractable)
		{
			_selectionLink = Landmark.GetComponentInChildren<SelectionLink>(includeInactive: true);
			_selectionLink.SetObjectToSelect(Landmark.gameObject, ObjectType.Landmark);
			_selectionLink.SetOnCursorStayListener(OnUnderCursor);
			_selectionLink.SetOnShowTooltipListener(OnShowTooltip);
			_selectionLink.SetOnSelectedListener(OnSelected);
			_selectionLink.SetOnDeselectedListener(OnDeselected);
		}
		IsInteracting = false;
		IsPanelOpen = false;
		IsCameraLocked = false;
		return Landmark;
	}

	public virtual void OnLandmarkSpawnedOrRestored()
	{
	}

	public virtual void DestroyLandmark()
	{
		Selector.Deselect(_selectionLink);
		if (Landmark == null)
		{
			return;
		}
		LandmarkMooringPoint[] mooringPoints = Landmark.MooringPoints;
		foreach (LandmarkMooringPoint landmarkMooringPoint in mooringPoints)
		{
			if ((bool)landmarkMooringPoint.MooredBoat)
			{
				Debug.LogErrorFormat("'{0}' is moored at a Landmark '{1}' that is being destroyed. This is a whale of a bug!", landmarkMooringPoint.MooredBoat.Buildable.Name, Name);
				landmarkMooringPoint.MooredBoat.ResetToTown();
			}
		}
		LandmarkNotificationEvent.Remove(this);
		Object.Destroy(Landmark.gameObject);
	}

	private void OnDestroy()
	{
		if (UpdatedEvent != null)
		{
			UpdatedEvent.RemoveAllListeners();
		}
	}

	public bool Validate()
	{
		if ((bool)_landmarkPrefab)
		{
			return true;
		}
		Debug.LogErrorFormat("Landmark Prefab for LandmarkBehaviour '{0}' is null!", base.name);
		return false;
	}

	public virtual void SpawnLandmark(Vector3 position, Quaternion rotation, Transform parent = null)
	{
		InstantiateLandmark(position, rotation, parent);
		Landmark.InitializeInteractables();
		if (0f < _pollutionPerDay)
		{
			Landmark.gameObject.AddComponent<LandmarkPollution>();
		}
		DispatchInteractableEvent();
	}

	public Landmark RestoreLandmark(LandmarkPersistentData persistentData, Vector3 position, Quaternion rotation, Transform parent = null)
	{
		InstantiateLandmark(position, rotation, parent);
		if (persistentData.Interactables != null)
		{
			ILandmarkInteractablePersistentData[] interactables = persistentData.Interactables;
			for (int i = 0; i < interactables.Length; i++)
			{
				interactables[i].Restore(Landmark);
			}
		}
		else
		{
			Landmark.InitializeRescueables();
		}
		if (persistentData.Behaviour != null)
		{
			persistentData.Behaviour.Restore(this as ActionsBehaviour);
		}
		return Landmark;
	}

	public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
	{
		if (!(Landmark == null))
		{
			Landmark.transform.position = position + Landmark.PositionOffset;
			Landmark.transform.rotation = rotation;
			DispatchInteractableEvent();
		}
	}

	protected virtual bool DispatchInteractableEvent()
	{
		if ((bool)Landmark && WorldManager.IsInInteractionRadius(Landmark.transform.position))
		{
			GameEventDispatcher.Dispatch(GameEventType.LandmarkInteractable);
			return true;
		}
		return false;
	}

	public bool Interact(Agent agent)
	{
		if (!IsPanelOpen && IsInteracting && Actor != null)
		{
			BeginInteraction();
			IsPanelOpen = true;
			return false;
		}
		if (IsInteracting)
		{
			return false;
		}
		IsInteracting = true;
		Actor = agent;
		Landmark.StartCoroutine(InteractCoroutine(agent));
		return true;
	}

	private IEnumerator InteractCoroutine(Agent agent)
	{
		while (Selector.Selection != agent.SelectionLink && Selector.Selection != _selectionLink)
		{
			yield return null;
		}
		BeginInteraction();
	}

	protected abstract void BeginInteraction();

	public virtual void EndInteraction()
	{
		Actor = null;
		IsInteracting = false;
	}

	public void SetScouted()
	{
		_isScouted = true;
		UpdatedEvent.Invoke(this, this);
	}

	public void CountItems(InventoryAuditor auditor)
	{
		CountItems(auditor, _landmarkPrefab);
	}

	public abstract void CountItems(InventoryAuditor auditor, Landmark landmark);

	public int ReturnMooringPointCount()
	{
		if ((bool)Landmark)
		{
			return Landmark.MooringPoints.Length;
		}
		Debug.LogError("This line should never be reached...");
		return _landmarkPrefab.GetComponentsInChildren<LandmarkMooringPoint>(includeInactive: true).Length;
	}

	public LandmarkMooringPoint ReturnMooringPoint()
	{
		return _landmarkPrefab.GetComponentInChildren<LandmarkMooringPoint>(includeInactive: true);
	}

	public LandmarkBehaviour ReturnInstance()
	{
		LandmarkBehaviour landmarkBehaviour = Object.Instantiate(this);
		landmarkBehaviour.Prefab = this;
		return landmarkBehaviour;
	}

	public bool ReturnMatchesScoutingFilter(WorldMapScoutingId filter)
	{
		if (ScoutingId == WorldMapScoutingId.None)
		{
			return false;
		}
		if (filter == WorldMapScoutingId.None)
		{
			return true;
		}
		return (ScoutingId & filter) == ScoutingId;
	}

	public virtual bool ReturnIsActive()
	{
		return false;
	}

	public virtual float ReturnProgress()
	{
		return 0f;
	}

	public virtual bool ReturnIsCompleted()
	{
		return false;
	}

	public virtual bool ReturnIsInteractable()
	{
		return false;
	}

	public float ReturnClearanceRadius()
	{
		return _landmarkPrefab.ReturnClearanceRadius() + 10f;
	}

	public Polygon ReturnLandmarkPrefabPolygon()
	{
		LandmarkBase componentInChildren = _landmarkPrefab.GetComponentInChildren<LandmarkBase>();
		if ((bool)componentInChildren)
		{
			return componentInChildren.Polygon;
		}
		Obstacle componentInChildren2 = _landmarkPrefab.GetComponentInChildren<Obstacle>();
		if ((bool)componentInChildren2)
		{
			return componentInChildren2.Polygon;
		}
		return null;
	}

	public virtual Sprite ReturnBearingIcon()
	{
		return _bearingIcon;
	}

	public bool IsInSwimmingRadius()
	{
		if ((bool)Landmark)
		{
			return Landmark.IsInSwimmingRadius();
		}
		return false;
	}

	public bool IsInBoatRadius()
	{
		if ((bool)Landmark)
		{
			return Landmark.IsInBoatRadius();
		}
		return false;
	}

	public bool IsReachableByBoat()
	{
		if (Community.PlayerCommunity.ReturnHasBoatWithAssignmentType(AssignmentType.LandmarkInteraction))
		{
			return IsInBoatRadius();
		}
		return false;
	}

	public virtual void OnUnderCursor()
	{
		if ((bool)Landmark && Landmark.IsInteractable)
		{
			CursorManager.SetCursorState(CursorState.Select);
		}
	}

	public virtual void OnShowTooltip()
	{
		if ((bool)Landmark && Landmark.IsInteractable)
		{
			TooltipPanel.ShowTooltip(this);
		}
	}

	public virtual void OnSelected(bool playSelectionSound)
	{
		if (IsInteracting && Actor != null)
		{
			Interact(Actor);
		}
	}

	public virtual void OnDeselected()
	{
	}

	public bool IsSelected()
	{
		if (Selector.SelectedType == ObjectType.Landmark)
		{
			return Selector.Selection.ObjectToSelect == _selectionLink.ObjectToSelect;
		}
		return false;
	}

	public LandmarkBehaviour ReturnLandmarkBehaviour(WorldRegionType region)
	{
		return this;
	}

	public MooringPointBase[] ReturnMooringPoints()
	{
		return LandmarkPrefabGameObject.GetComponentsInChildren<MooringPointBase>();
	}

	public virtual bool ReturnHasLandmarkActionReference<T>() where T : LandmarkAction
	{
		return false;
	}

	public bool ReturnIsLandmarkBehaviour(LandmarkBehaviour behaviour)
	{
		if (behaviour != null)
		{
			return behaviour.LandmarkPrefabGameObject == LandmarkPrefabGameObject;
		}
		return false;
	}

	public string GetTooltip(TooltipBuilder tooltipBuilder)
	{
		return Name;
	}

	public abstract bool RequiresPersistence();
}
