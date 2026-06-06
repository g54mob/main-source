using System;
using I2.Loc;
using PajamaLlama.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class LandmarkAction : ScriptableObject, ILandmarkAction
{
	[Tooltip("Title for the action panel.")]
	[SerializeField]
	[FormerlySerializedAs("Title")]
	private LocalizedString _title;

	[Tooltip("Interaction text to display on button.")]
	[SerializeField]
	[FormerlySerializedAs("ActivateText")]
	private LocalizedString _activateText;

	public Sprite Icon;

	public int MarkerPriority;

	public bool RequiresRowBoat;

	public bool RequiresScouting;

	public NotificationProperties CompletedNotification;

	[Header("Projects")]
	public ProjectProperties SwimmingProjectProperties;

	public ProjectProperties BoatingProjectProperties;

	public RangedInt AssignmentLimitRange = new RangedInt(1, 1);

	[NonSerialized]
	protected LandmarkBehaviour _landmarkBehaviour;

	[NonSerialized]
	private bool _enabled;

	[NonSerialized]
	private bool _wasCompleted;

	[NonSerialized]
	private bool _useBoat;

	public ILandmarkActionStates State { get; private set; }

	public Project Project { get; private set; }

	public bool UseBoat
	{
		get
		{
			return _useBoat;
		}
		set
		{
			if (_useBoat != value)
			{
				_useBoat = value;
				SetAssignmentLimit(Mathf.Clamp(AssignmentLimit, AssignmentLimitMinimum, AssignmentLimitMaximum));
				if (State == ILandmarkActionStates.Active)
				{
					Deactivate();
					Activate();
				}
			}
		}
	}

	public int MooringPointCount => _landmarkBehaviour.ReturnMooringPointCount();

	public virtual int AssignmentLimitMinimum => AssignmentLimitRange.Minimum;

	public virtual int AssignmentLimitMaximum
	{
		get
		{
			if (!UseBoat)
			{
				return AssignmentLimitRange.Maximum;
			}
			return MooringPointCount;
		}
	}

	public int AssignmentLimit { get; private set; }

	public bool HasProject => Project != null;

	public bool IsCompleted => State == ILandmarkActionStates.Completed;

	public bool WasCompleted
	{
		get
		{
			if (State == ILandmarkActionStates.Completed && !_wasCompleted)
			{
				_wasCompleted = true;
				return true;
			}
			return false;
		}
	}

	public ILandmarkActionEvent UpdatedEvent { get; private set; }

	public LocalizedString Title => _title;

	public LocalizedString ActivateText => _activateText;

	public abstract GameEventType InteractableEventType { get; }

	public virtual bool RequiresPersistence => false;

	public virtual void Initialize(LandmarkBehaviour landmarkBehaviour)
	{
		_landmarkBehaviour = landmarkBehaviour;
		_enabled = true;
		_wasCompleted = false;
	}

	public virtual void Restore(LandmarkPersistentData landmarkPersistentData)
	{
	}

	public virtual void OnLandmarkSpawned(LandmarkActionPersistentData persistentData = null)
	{
		if (State == ILandmarkActionStates.Hidden)
		{
			if (RequiresScouting)
			{
				_landmarkBehaviour.UpdatedEvent.AddListener(OnLandmarkBehaviourUpdate);
			}
			else
			{
				State = ILandmarkActionStates.Inactive;
			}
		}
		if (UpdatedEvent == null)
		{
			UpdatedEvent = new ILandmarkActionEvent();
		}
	}

	public virtual void OnLandmarkSelected()
	{
	}

	public virtual void OnLandmarkDeselected()
	{
	}

	public virtual void Uninitialize()
	{
		if (!(_landmarkBehaviour == null) && _landmarkBehaviour.UpdatedEvent != null)
		{
			_landmarkBehaviour.UpdatedEvent.RemoveListener(OnLandmarkBehaviourUpdate);
		}
	}

	private void OnDisable()
	{
		_enabled = false;
		if (UpdatedEvent != null)
		{
			UpdatedEvent.RemoveAllListeners();
		}
	}

	public virtual void UpdateState()
	{
	}

	public void Activate()
	{
		if (!_enabled)
		{
			throw new NotSupportedException("LandmarkAction '" + base.name + "' was activated before it was instantiated. This is not supported!");
		}
		if (State != ILandmarkActionStates.Inactive)
		{
			return;
		}
		if (Project == null)
		{
			Project project = ReturnProject();
			if (project != null && Community.PlayerCommunity.QueueProject(project))
			{
				Project = project;
				Project.FinishedEvent.AddListener(OnProjectFinished);
				SetState(ILandmarkActionStates.Active);
			}
		}
		else if (Community.PlayerCommunity.QueueProject(Project))
		{
			Project.FinishedEvent.AddListener(OnProjectFinished);
			SetState(ILandmarkActionStates.Active);
		}
	}

	public void Deactivate()
	{
		if (State == ILandmarkActionStates.Active)
		{
			if (Project != null)
			{
				Project.FinishedEvent.RemoveListener(OnProjectFinished);
				Project.Stop(ProjectFlags.Cancelled);
				Project = null;
			}
			SetState(ILandmarkActionStates.Inactive);
		}
	}

	public void SetAssignmentLimit(int limit)
	{
		AssignmentLimit = Mathf.Clamp(limit, AssignmentLimitMinimum, AssignmentLimitMaximum);
		if (Project != null)
		{
			Project.AssignmentLimit = limit;
		}
	}

	protected void SetState(ILandmarkActionStates state, bool dispatchEvent = true)
	{
		if (state == State)
		{
			return;
		}
		ILandmarkActionStates state2 = State;
		State = state;
		if (!dispatchEvent)
		{
			return;
		}
		if (UpdatedEvent != null)
		{
			UpdatedEvent.Invoke(this);
		}
		switch (state)
		{
		case ILandmarkActionStates.Active:
			OnActivated();
			LandmarkNotificationEvent.Working(_landmarkBehaviour, this);
			break;
		case ILandmarkActionStates.Inactive:
			OnDeactivated();
			if (state2 == ILandmarkActionStates.Hidden)
			{
				LandmarkNotificationEvent.Update(_landmarkBehaviour, this);
			}
			else
			{
				LandmarkNotificationEvent.Idle(_landmarkBehaviour, this);
			}
			break;
		case ILandmarkActionStates.Completed:
			OnCompleted();
			LandmarkNotificationEvent.Completed(_landmarkBehaviour, this);
			break;
		}
	}

	private void OnLandmarkBehaviourUpdate(LandmarkBehaviour landmarkBehaviour, object trigger)
	{
		if (State == ILandmarkActionStates.Hidden)
		{
			if (!landmarkBehaviour.IsScouted)
			{
				return;
			}
			SetState(ILandmarkActionStates.Inactive);
		}
		landmarkBehaviour.UpdatedEvent.RemoveListener(OnLandmarkBehaviourUpdate);
	}

	protected virtual void OnProjectFinished(Project project, bool success)
	{
		if (Project != null)
		{
			Project.FinishedEvent.RemoveListener(OnProjectFinished);
			Project = null;
		}
		if (success)
		{
			SetState(ILandmarkActionStates.Completed);
		}
		else
		{
			SetState(ILandmarkActionStates.Inactive);
		}
	}

	protected virtual void OnActivated()
	{
	}

	protected virtual void OnDeactivated()
	{
	}

	protected virtual void OnCompleted()
	{
	}

	public virtual void CountItems(InventoryAuditor auditor, Landmark landmark)
	{
	}

	public virtual Project ReturnProject()
	{
		return new Project(UseBoat ? BoatingProjectProperties : SwimmingProjectProperties, _landmarkBehaviour.Landmark.gameObject);
	}

	public virtual bool ReturnIsInteractable()
	{
		if ((State == ILandmarkActionStates.Active || State == ILandmarkActionStates.Inactive) && (bool)_landmarkBehaviour)
		{
			if (!_landmarkBehaviour.IsReachableByBoat())
			{
				return _landmarkBehaviour.IsInSwimmingRadius();
			}
			return true;
		}
		return false;
	}

	public virtual bool TryReturnInteractableTooltip(out LocalizedString tooltip)
	{
		tooltip = default(LocalizedString);
		return false;
	}

	public abstract void InitializeUI(LandmarkPanel landmarkPanel);

	public virtual Sprite ReturnBearingIcon()
	{
		return null;
	}

	public virtual float ReturnProgress()
	{
		return IsCompleted ? 1 : 0;
	}

	public virtual LandmarkActionPersistentData ReturnLandmarkActionPersistentData()
	{
		return new LandmarkActionPersistentData(this);
	}

	public virtual void Restore(LandmarkActionPersistentData data, LandmarkBehaviour landmarkBehaviour)
	{
		State = data.State;
		_useBoat = data.UseBoat;
		Initialize(landmarkBehaviour);
		OnLandmarkSpawned(data);
	}

	public virtual void RestoreReferences(LandmarkActionPersistentData data)
	{
		if (State == ILandmarkActionStates.Active && data.Project == null)
		{
			TryToFixMissingProjectReference(data);
		}
		if (data.Project.TryReturn(out var instance))
		{
			Project = instance;
			Project.FinishedEvent.AddListener(OnProjectFinished);
		}
	}

	private void TryToFixMissingProjectReference(LandmarkActionPersistentData data)
	{
		string projectTargetName = _landmarkBehaviour.name;
		data.Project = Community.PlayerCommunity.Projects.Find((Project project) => project.Target != null && project.Target.name == projectTargetName);
		if (data.Project == null)
		{
			Debug.LogError($"The current save has an active landmark action ({data.Id} action with target {projectTargetName}) but no project associated with it. Deactivating the action.");
			State = ILandmarkActionStates.Inactive;
		}
	}
}
