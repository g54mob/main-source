using System;
using System.Collections.Generic;
using PajamaLlama.Utilities;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Landmarks/ActionsBehaviour")]
public class ActionsBehaviour : LandmarkBehaviour, IPanelContext, IWorldMapMarkerTarget
{
	[Header("Actions")]
	[SerializeField]
	private LandmarkAction[] _actions;

	private LandmarkAction _markerAction;

	public List<LandmarkAction> Actions { get; private set; }

	public bool UseBoat
	{
		get
		{
			foreach (LandmarkAction action in Actions)
			{
				if (!action.UseBoat)
				{
					return false;
				}
			}
			return true;
		}
		set
		{
			foreach (LandmarkAction action in Actions)
			{
				action.UseBoat = value;
			}
		}
	}

	public int AssignmentLimitMinimum
	{
		get
		{
			int num = int.MaxValue;
			foreach (LandmarkAction action in Actions)
			{
				num = Mathf.Min(num, action.AssignmentLimitMinimum);
			}
			return num;
		}
	}

	public int AssignmentLimitMaximum
	{
		get
		{
			int num = 0;
			foreach (LandmarkAction action in Actions)
			{
				num = Mathf.Max(num, action.AssignmentLimitMaximum);
			}
			return num;
		}
	}

	public int AssignmentLimit
	{
		get
		{
			int num = 0;
			foreach (LandmarkAction action in Actions)
			{
				num = Mathf.Max(num, action.AssignmentLimit);
			}
			return num;
		}
	}

	public PanelID PanelID => PanelID.LandmarkPanel;

	Vector3 IWorldMapMarkerTarget.LocalPosition
	{
		get
		{
			if (!base.Landmark)
			{
				return Vector3.zero;
			}
			return base.Landmark.transform.position;
		}
	}

	Sprite IWorldMapMarkerTarget.Icon
	{
		get
		{
			if (!(_markerAction != null))
			{
				return null;
			}
			return _markerAction.Icon;
		}
	}

	public override void Initialize()
	{
		base.Initialize();
		Actions = new List<LandmarkAction>(_actions.Length);
		LandmarkAction[] actions = _actions;
		foreach (LandmarkAction landmarkAction in actions)
		{
			if (landmarkAction is LandmarkActionScout || landmarkAction is LandmarkActionRevealMap)
			{
				base.RequiresScouting = true;
			}
			LandmarkAction landmarkAction2 = UnityEngine.Object.Instantiate(landmarkAction);
			landmarkAction2.Initialize(this);
			Actions.Add(landmarkAction2);
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.PanelClosed, OnPanelClosed);
	}

	public override void Restore(LandmarkPersistentData landmarkPersistentData)
	{
		foreach (LandmarkAction action in Actions)
		{
			action.Restore(landmarkPersistentData);
		}
	}

	public override void SpawnLandmark(Vector3 position, Quaternion rotation, Transform parent = null)
	{
		base.SpawnLandmark(position, rotation, parent);
		foreach (LandmarkAction action in Actions)
		{
			action.OnLandmarkSpawned();
		}
	}

	public override void OnLandmarkSpawnedOrRestored()
	{
		foreach (LandmarkAction action in Actions)
		{
			action.UpdatedEvent?.AddListener(OnActionUpdated);
		}
	}

	public override void DestroyLandmark()
	{
		base.DestroyLandmark();
		foreach (LandmarkAction action in Actions)
		{
			action.UpdatedEvent?.RemoveListener(OnActionUpdated);
			action.Uninitialize();
		}
		GameEventDispatcher.RemoveListener(GameEventType.PanelClosed, OnPanelClosed);
	}

	protected override bool DispatchInteractableEvent()
	{
		if (!base.DispatchInteractableEvent())
		{
			return false;
		}
		foreach (LandmarkAction action in Actions)
		{
			GameEventDispatcher.Dispatch(action.InteractableEventType);
		}
		return true;
	}

	protected override void BeginInteraction()
	{
		throw new NotImplementedException();
	}

	public override void OnSelected(bool playSelectionSound)
	{
		foreach (LandmarkAction action in Actions)
		{
			action.OnLandmarkSelected();
		}
		FinalUpdate.RegisterEndOfFrameOneShot(TryOpenLandmarkPanel);
	}

	private void TryOpenLandmarkPanel()
	{
		if (GameManager.UIManager.IsPanelOpen(PanelID.DialoguePanel))
		{
			GameEventDispatcher.AddListener(GameEventType.PanelClosed, OnPanelClosed);
		}
		else
		{
			OnPanelClosed();
		}
	}

	private void OnPanelClosed(GameEvent gameEvent = null)
	{
		if (gameEvent == null || gameEvent is PanelEvent { ID: PanelID.DialoguePanel })
		{
			GameEventDispatcher.RemoveListener(GameEventType.PanelClosed, OnPanelClosed);
			GameManager.UIManager.DisplayPanel(this);
		}
	}

	public override void OnDeselected()
	{
		GameManager.UIManager.ClosePanel(PanelID);
		foreach (LandmarkAction action in Actions)
		{
			action.OnLandmarkDeselected();
		}
	}

	private void OnActionUpdated(ILandmarkAction action)
	{
		if (base.UpdatedEvent != null)
		{
			base.UpdatedEvent.Invoke(this, action);
		}
		UpdateMarkerAction();
	}

	public override void CountItems(InventoryAuditor auditor, Landmark landmark)
	{
		LandmarkAction[] actions = _actions;
		for (int i = 0; i < actions.Length; i++)
		{
			actions[i].CountItems(auditor, landmark);
		}
	}

	public void SetAssignmentLimit(int limit)
	{
		foreach (LandmarkAction action in Actions)
		{
			action.SetAssignmentLimit(limit);
		}
	}

	public void Activate()
	{
		foreach (LandmarkAction action in Actions)
		{
			action.Activate();
		}
	}

	public void Deactivate()
	{
		foreach (LandmarkAction action in Actions)
		{
			action.Deactivate();
		}
	}

	public bool TrySetActionActive(GameEventType actionToActivate, bool active)
	{
		foreach (LandmarkAction action in Actions)
		{
			if (action.InteractableEventType == actionToActivate)
			{
				if (active)
				{
					action.Activate();
				}
				else
				{
					action.Deactivate();
				}
				return true;
			}
		}
		return false;
	}

	private void UpdateMarkerAction()
	{
		_markerAction = null;
		foreach (LandmarkAction action in Actions)
		{
			if (action.State == ILandmarkActionStates.Active && (_markerAction == null || _markerAction.MarkerPriority < action.MarkerPriority))
			{
				_markerAction = action;
			}
		}
		if (_markerAction == null)
		{
			WorldMapManager.DestroyMarker(this);
		}
		else
		{
			WorldMapManager.InstantiateMarker(this);
		}
	}

	public override bool ReturnIsInteractable()
	{
		if (Actions.IsNullOrEmpty())
		{
			return false;
		}
		foreach (LandmarkAction action in Actions)
		{
			if (!action.ReturnIsInteractable())
			{
				return false;
			}
		}
		return true;
	}

	public bool ReturnHasInactiveActions()
	{
		if (Actions == null)
		{
			return true;
		}
		foreach (LandmarkAction action in Actions)
		{
			if (action.State == ILandmarkActionStates.Inactive)
			{
				return true;
			}
		}
		return false;
	}

	public override bool ReturnIsActive()
	{
		if (Actions == null)
		{
			return false;
		}
		foreach (LandmarkAction action in Actions)
		{
			if (action.State != ILandmarkActionStates.Active)
			{
				return false;
			}
		}
		return true;
	}

	public override bool ReturnIsCompleted()
	{
		if (Actions.IsNullOrEmpty())
		{
			return false;
		}
		foreach (LandmarkAction action in Actions)
		{
			if (!action.IsCompleted)
			{
				return false;
			}
		}
		return true;
	}

	public override float ReturnProgress()
	{
		if (Actions == null)
		{
			return 0f;
		}
		float num = 1f / (float)Actions.Count;
		float num2 = 0f;
		foreach (LandmarkAction action in Actions)
		{
			num2 += num * ((ILandmarkAction)action).ReturnProgress();
		}
		return num2;
	}

	public bool ReturnHasAction<T>() where T : LandmarkAction
	{
		if (Actions == null)
		{
			return false;
		}
		foreach (LandmarkAction action in Actions)
		{
			if (!action.IsCompleted && action is T)
			{
				return true;
			}
		}
		return false;
	}

	public bool TryReturnAction<T>(out T action, bool includeCompleted = false) where T : LandmarkAction
	{
		if (TryReturnAction(out var action2, typeof(T), includeCompleted))
		{
			action = action2 as T;
			return true;
		}
		action = null;
		return false;
	}

	public bool TryReturnAction(out LandmarkAction action, Type actionType, bool includeCompleted = false)
	{
		action = null;
		if (Actions == null)
		{
			return false;
		}
		foreach (LandmarkAction action2 in Actions)
		{
			if (action2.GetType() == actionType && (includeCompleted || !action2.IsCompleted))
			{
				action = action2;
				return true;
			}
		}
		return false;
	}

	public override Sprite ReturnBearingIcon()
	{
		foreach (LandmarkAction action in Actions)
		{
			Sprite sprite = action.ReturnBearingIcon();
			if (sprite != null)
			{
				return sprite;
			}
		}
		return base.ReturnBearingIcon();
	}

	public bool ReturnHasLandmarkAction(LandmarkAction action)
	{
		LandmarkAction action2;
		return TryReturnAction(out action2, action.GetType());
	}

	public bool ReturnHasLandmarkAction(GameEventType actionType)
	{
		if (Actions == null)
		{
			return false;
		}
		foreach (LandmarkAction action in Actions)
		{
			if (action.InteractableEventType == actionType && !action.IsCompleted)
			{
				return true;
			}
		}
		return false;
	}

	public override bool ReturnHasLandmarkActionReference<T>()
	{
		LandmarkAction[] actions = _actions;
		for (int i = 0; i < actions.Length; i++)
		{
			if (actions[i] is T)
			{
				return true;
			}
		}
		return false;
	}

	public override bool RequiresPersistence()
	{
		if ((bool)base.Landmark)
		{
			return true;
		}
		foreach (LandmarkAction action in Actions)
		{
			if (action.RequiresPersistence)
			{
				return true;
			}
		}
		return false;
	}
}
