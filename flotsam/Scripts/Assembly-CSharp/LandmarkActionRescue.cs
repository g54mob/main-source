using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Landmarks/Actions/Rescue")]
public class LandmarkActionRescue : LandmarkAction
{
	public class Rescueable : ILandmarkActionToggleable, IToggleable, IDialogueInteractable
	{
		private LandmarkAction _action;

		private LandmarkRescueable _rescueable;

		private bool _rescueOnDialogueEnd;

		private bool _hasStartedDialogue;

		public string Label
		{
			get
			{
				if (!(Actor != null))
				{
					return "NULL";
				}
				return Actor.Name;
			}
		}

		public bool IsInteractable => _action.ReturnIsInteractable();

		public bool IsCompleted
		{
			get
			{
				if (!(_rescueable == null))
				{
					return _rescueable.IsRescued;
				}
				return true;
			}
		}

		public bool IsToggled { get; private set; }

		public ActorDescriptor Descriptor { get; private set; }

		public ActorBehaviour Actor { get; private set; }

		public Agent Agent { get; private set; }

		public DialogueTreeProperties DialogueProperties { get; private set; }

		public bool Unlocked { get; set; }

		public Rescueable(LandmarkAction action, LandmarkRescueable rescueable, bool unlocked = false)
		{
			_action = action;
			_rescueable = rescueable;
			Unlocked = !TryReturnRequiredItemAndCost(out var _, out var _) || unlocked;
			if ((bool)_rescueable)
			{
				Descriptor = _rescueable.Descriptor;
				Actor = _rescueable.Actor;
				Agent = _rescueable.Agent;
				if ((bool)Descriptor.ActorProfile)
				{
					DialogueProperties = Descriptor.ActorProfile.DialogueProperties;
				}
				if ((bool)_rescueable.Unlockable)
				{
					_rescueable.Unlockable.Initialize(this);
				}
			}
		}

		public IEnumerator Unlock()
		{
			Unlocked = true;
			if ((bool)_rescueable && (bool)_rescueable.Unlockable)
			{
				yield return _rescueable.Unlockable.Unlock();
			}
		}

		public void Toggle()
		{
			IsToggled = !IsToggled;
			_action.UpdateState();
		}

		public void SetActive(bool active)
		{
			IsToggled = active;
			_action.UpdateState();
		}

		public void SeekAttention()
		{
			if ((bool)_rescueable && (bool)_rescueable.Agent && (bool)_rescueable.Agent.Descriptor.VoicePack)
			{
				AudioManager.Play(_rescueable.Agent.Descriptor.VoicePack.AttentionSounds, _rescueable.Agent.transform);
			}
		}

		public bool IsSeekingAttention()
		{
			if ((bool)_rescueable)
			{
				return _rescueable.Actor.Community != Community.PlayerCommunity;
			}
			return false;
		}

		public bool IsAgent(Agent agent)
		{
			if ((bool)_rescueable)
			{
				return _rescueable.Actor == agent;
			}
			return false;
		}

		public bool TriggerDialogue()
		{
			if (!_hasStartedDialogue && IsInteractable && !IsCompleted && !IsToggled && (bool)Agent && TryGetEntryPoint(out var _))
			{
				DialogueGameEvent.DispatchDialogueStartRequest(this);
				_hasStartedDialogue = true;
				if (_rescueable.Agent != null)
				{
					_rescueable.Agent.UpdateActivity(Activity.Landmark_Speaking);
				}
				return true;
			}
			return false;
		}

		public void OnDialogueResponse(DialogueResponseType response, Dialogue dialogue)
		{
			switch (response)
			{
			case DialogueResponseType.Yes:
				_rescueOnDialogueEnd = true;
				if ((bool)_rescueable.Agent)
				{
					_rescueable.Agent.UpdateActivity(Activity.Landmark_RescueAccepted);
				}
				break;
			case DialogueResponseType.No:
				if ((bool)_rescueable.Agent)
				{
					_rescueable.Agent.UpdateActivity(Activity.Landmark_RescueRefused);
				}
				break;
			case DialogueResponseType.EndOfDialogue:
				if (_rescueOnDialogueEnd)
				{
					_rescueable.Rescue();
					_action.UpdateState();
				}
				else if ((bool)_rescueable.Agent)
				{
					_rescueable.Agent.UpdateActivity(Activity.Idling);
				}
				break;
			}
			if (response != DialogueResponseType.None)
			{
				_hasStartedDialogue = false;
			}
		}

		public bool TryGetEntryPoint(out DialogueNodeProperties entryPoint)
		{
			entryPoint = null;
			if ((bool)DialogueProperties)
			{
				entryPoint = DialogueProperties.ReturnBranchEntryNode(DialogueBranchType.Rescue);
			}
			return entryPoint != null;
		}

		public bool TryGetMainSpeaker(out AgentDescriptor mainSpeaker)
		{
			if ((bool)Agent)
			{
				mainSpeaker = Agent.Descriptor;
				return true;
			}
			mainSpeaker = null;
			return false;
		}

		public bool TryReturnRequiredItemAndCost(out ItemProperties itemProperties, out int cost)
		{
			itemProperties = _rescueable.RequiredItem;
			cost = _rescueable.RequiredItemCost;
			if ((bool)itemProperties)
			{
				return 0 < cost;
			}
			return false;
		}
	}

	[Serializable]
	public class PersistentData : LandmarkActionPersistentData
	{
		[OptionalField(VersionAdded = 3)]
		private readonly ActorType _actorType;

		[OptionalField(VersionAdded = 4)]
		private readonly ushort[] _rescuableDescriptors;

		[OptionalField(VersionAdded = 4)]
		private readonly ushort[] _unlockedRescuables;

		[OptionalField(VersionAdded = 2)]
		private readonly int _associatedQuestIndex = -1;

		private readonly int _forcedBackgroundIndex = -1;

		[OptionalField(VersionAdded = 2)]
		private readonly ushort _forcedDescriptorID;

		public ushort[] UnlockedRescuables => _unlockedRescuables;

		public PersistentData(LandmarkActionRescue instance)
			: base(instance)
		{
			_actorType = instance.ActorType;
			if (instance._rescuableDescriptors != null)
			{
				_rescuableDescriptors = new ushort[instance._rescuableDescriptors.Count];
				for (int i = 0; i < instance._rescuableDescriptors.Count; i++)
				{
					_rescuableDescriptors[i] = instance._rescuableDescriptors[i].UniqueID;
				}
			}
			if (instance.Rescueables != null)
			{
				using ListPool<ushort>.List list = ListPool<ushort>.Get();
				foreach (Rescueable rescueable in instance.Rescueables)
				{
					if (rescueable.Unlocked)
					{
						list.Add(rescueable.Descriptor.UniqueID);
					}
				}
				if (0 < list.Count)
				{
					_unlockedRescuables = list.ToArray();
				}
			}
			_associatedQuestIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(instance._associatedQuest);
		}

		public ActorType ReturnActorType()
		{
			return _actorType;
		}

		public List<ActorDescriptor> ReturnRescuableDescriptors()
		{
			if (_rescuableDescriptors.IsNullOrEmpty())
			{
				return null;
			}
			List<ActorDescriptor> list = new List<ActorDescriptor>(_rescuableDescriptors.Length);
			ushort[] rescuableDescriptors = _rescuableDescriptors;
			foreach (ushort id in rescuableDescriptors)
			{
				if (ActorDescriptor.TryGet<ActorDescriptor>(out var actorDescriptor, id))
				{
					list.Add(actorDescriptor);
				}
			}
			return list;
		}

		public bool TryReturnFirstRescuableDescriptor(out ActorDescriptor rescuableDescriptor)
		{
			rescuableDescriptor = null;
			if (_rescuableDescriptors.IsNullOrEmpty())
			{
				return false;
			}
			ushort[] rescuableDescriptors = _rescuableDescriptors;
			foreach (ushort id in rescuableDescriptors)
			{
				if (ActorDescriptor.TryGet<ActorDescriptor>(out rescuableDescriptor, id))
				{
					break;
				}
			}
			return rescuableDescriptor != null;
		}

		public QuestProperties ReturnAssociatedQuest()
		{
			if (_associatedQuestIndex == -1 || !GameManager.PersistenceManager.TryReturnPropertiesReference<QuestProperties>(_associatedQuestIndex, out var reference))
			{
				return null;
			}
			return reference;
		}

		public ActorDescriptor ReturnForcedDescriptor()
		{
			if (ActorDescriptor.TryGet<ActorDescriptor>(out var actorDescriptor, _forcedDescriptorID))
			{
				return actorDescriptor;
			}
			if (0 <= _forcedBackgroundIndex && GameManager.PersistenceManager.TryReturnPropertiesReference<DrifterAttributesEffect>(_forcedBackgroundIndex, out var reference))
			{
				return AgentDescriptor.CreateInstance(reference);
			}
			return null;
		}
	}

	private List<ActorDescriptor> _rescuableDescriptors;

	private QuestProperties _associatedQuest;

	private ushort[] _unlockedRescuables;

	public override GameEventType InteractableEventType => GameEventType.LandmarkActionRescueInteractable;

	public ActorType ActorType { get; private set; }

	public List<Rescueable> Rescueables { get; private set; }

	public override bool RequiresPersistence => !_rescuableDescriptors.IsNullOrEmpty();

	public override void OnLandmarkSpawned(LandmarkActionPersistentData persistentData = null)
	{
		base.OnLandmarkSpawned(persistentData);
		PopulateRescuables();
		if (base.State != ILandmarkActionStates.Completed)
		{
			_landmarkBehaviour.Landmark.StartCoroutine(PlayAttentionSoundCoroutine());
		}
	}

	public override void OnLandmarkSelected()
	{
		if (Rescueables.IsNullOrEmpty())
		{
			return;
		}
		foreach (Rescueable rescueable in Rescueables)
		{
			if (rescueable.TriggerDialogue() || CameraDevTools.DebugCinematicLock)
			{
				CameraController.Instance.CinematicLock(rescueable.Agent.transform, 0f, CameraController.TargetFocusOrientationType.FaceTarget);
				GameEventDispatcher.AddListener(GameEventType.DialogueEnded, OnDialogueEnded);
				break;
			}
		}
	}

	public override void Uninitialize()
	{
		base.Uninitialize();
		UnregisterQuestEvents();
	}

	private void UnregisterQuestEvents()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentRescue, OnRescueableRescued);
		GameEventDispatcher.RemoveListener(GameEventType.DialogueEnded, OnDialogueEnded);
		GameEventDispatcher.RemoveListener(GameEventType.QuestAbandoned, OnQuestFailed);
		GameEventDispatcher.RemoveListener(GameEventType.QuestFailed, OnQuestFailed);
	}

	protected override void OnActivated()
	{
		if (Rescueables.IsNullOrEmpty())
		{
			return;
		}
		foreach (Rescueable rescueable in Rescueables)
		{
			rescueable.SetActive(active: true);
		}
		GameEventDispatcher.AddListener(GameEventType.AgentRescue, OnRescueableRescued);
	}

	protected override void OnDeactivated()
	{
		if (Rescueables.IsNullOrEmpty())
		{
			return;
		}
		foreach (Rescueable rescueable in Rescueables)
		{
			rescueable.SetActive(active: false);
		}
		GameEventDispatcher.RemoveListener(GameEventType.AgentRescue, OnRescueableRescued);
	}

	private void OnRescueableRescued(GameEvent gameEvent)
	{
		AgentEvent agentEvent = gameEvent as AgentEvent;
		if (agentEvent != null && Rescueables.Find((Rescueable rescueable) => rescueable.Agent == agentEvent.Agent) != null)
		{
			UnregisterQuestEvents();
		}
	}

	private void OnDialogueEnded(GameEvent gameEvent)
	{
		if (gameEvent is DialogueGameEvent { IsToBeContinued: false })
		{
			GameEventDispatcher.RemoveListener(GameEventType.DialogueEnded, OnDialogueEnded);
			if (_landmarkBehaviour.IsSelected() && _landmarkBehaviour is ActionsBehaviour context)
			{
				GameManager.UIManager.DisplayPanel(context);
			}
		}
	}

	private void PopulateRescuables()
	{
		using ListPool<LandmarkRescueable>.List list = ListPool<LandmarkRescueable>.Get();
		if (_rescuableDescriptors == null)
		{
			_rescuableDescriptors = new List<ActorDescriptor>();
		}
		_landmarkBehaviour.Landmark.GetComponentsInChildren(list);
		if (Rescueables == null)
		{
			Rescueables = new List<Rescueable>();
		}
		else
		{
			Rescueables.Clear();
		}
		foreach (ActorDescriptor rescuableDescriptor in _rescuableDescriptors)
		{
			for (int i = 0; i < list.Count; i++)
			{
				LandmarkRescueable landmarkRescueable = list[i];
				if (landmarkRescueable.Spawn(rescuableDescriptor))
				{
					Rescueables.Add(new Rescueable(this, landmarkRescueable, _unlockedRescuables.Contains(rescuableDescriptor.UniqueID)));
					list.RemoveAt(i);
					break;
				}
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			LandmarkRescueable landmarkRescueable = list[j];
			_rescuableDescriptors.Add(landmarkRescueable.Spawn());
			Rescueables.Add(new Rescueable(this, landmarkRescueable));
		}
		if (base.State != ILandmarkActionStates.Completed)
		{
			return;
		}
		foreach (Rescueable rescueable in Rescueables)
		{
			if (!rescueable.IsCompleted)
			{
				SetState(ILandmarkActionStates.Inactive, dispatchEvent: false);
				break;
			}
		}
	}

	public override void UpdateState()
	{
		if (base.State == ILandmarkActionStates.Hidden || base.State == ILandmarkActionStates.Completed)
		{
			return;
		}
		bool flag = true;
		foreach (Rescueable rescueable in Rescueables)
		{
			if (!rescueable.IsCompleted)
			{
				flag = false;
				if (rescueable.IsInteractable && rescueable.IsToggled)
				{
					Activate();
					return;
				}
			}
		}
		if (flag)
		{
			SetState(ILandmarkActionStates.Completed);
		}
		else
		{
			Deactivate();
		}
	}

	protected override void OnProjectFinished(Project project, bool success)
	{
		success = true;
		foreach (Rescueable rescueable in Rescueables)
		{
			if (!rescueable.IsCompleted)
			{
				success = false;
				break;
			}
		}
		base.OnProjectFinished(project, success);
	}

	private IEnumerator PlayAttentionSoundCoroutine()
	{
		while (base.State != ILandmarkActionStates.Completed)
		{
			float seconds = UnityEngine.Random.Range(GameManager.Settings.AudioSettings.AttentionVoiceInterval.Minimum, GameManager.Settings.AudioSettings.AttentionVoiceInterval.Maximum);
			yield return new WaitForSeconds(seconds);
			using ListPool<Rescueable>.List list = ListPool<Rescueable>.Get();
			foreach (Rescueable rescueable in Rescueables)
			{
				if (rescueable.IsSeekingAttention())
				{
					list.Add(rescueable);
				}
			}
			if (list.Count == 0)
			{
				break;
			}
			list.GetRandom().SeekAttention();
		}
	}

	public void SetLandmarkRescueableActorType(ActorType rescueableActorType)
	{
		ActorType = rescueableActorType;
	}

	public void AddDescriptor(ActorDescriptor descriptor)
	{
		if (descriptor != null)
		{
			ActorType = descriptor.ActorType;
			if (_rescuableDescriptors == null)
			{
				_rescuableDescriptors = new List<ActorDescriptor>();
			}
			_rescuableDescriptors.Add(descriptor);
			_landmarkBehaviour.ScoutingId |= descriptor.ScoutingId;
		}
	}

	public void AssignDrifterQuest(QuestProperties quest)
	{
		if (_associatedQuest == null)
		{
			GameEventDispatcher.AddListener(GameEventType.QuestAbandoned, OnQuestFailed);
			GameEventDispatcher.AddListener(GameEventType.QuestFailed, OnQuestFailed);
		}
		_associatedQuest = quest;
	}

	private void OnQuestFailed(GameEvent gameEvent)
	{
		if (!(gameEvent is QuestEvent questEvent) || questEvent.Quest.Properties != _associatedQuest)
		{
			return;
		}
		GameEventDispatcher.RemoveListener(GameEventType.QuestAbandoned, OnQuestFailed);
		GameEventDispatcher.RemoveListener(GameEventType.QuestFailed, OnQuestFailed);
		_associatedQuest = null;
		if (!Rescueables.IsNullOrEmpty())
		{
			foreach (Rescueable rescueable in Rescueables)
			{
				rescueable.Agent.KillAgent();
				UnityEngine.Object.Destroy(rescueable.Agent.gameObject);
			}
			Rescueables.Clear();
		}
		if (_landmarkBehaviour is ActionsBehaviour actionsBehaviour)
		{
			actionsBehaviour.Actions.Remove(this);
		}
	}

	public override Project ReturnProject()
	{
		return new Project(base.UseBoat ? GameManager.Settings.ProjectSettings.RescueLandmark : GameManager.Settings.ProjectSettings.RescueLandmarkSwiming, _landmarkBehaviour.Landmark.ProjectTarget.gameObject);
	}

	public override void InitializeUI(LandmarkPanel landmarkPanel)
	{
		landmarkPanel.ReturnLandmarkActionUI<LandmarkActionRescueUI>().Initialize(this);
	}

	public override Sprite ReturnBearingIcon()
	{
		if ((bool)_associatedQuest)
		{
			return GameSettings.Instance.LandmarkSettings.DistressSignalBearingIcon;
		}
		if (_rescuableDescriptors.IsNullOrEmpty())
		{
			return null;
		}
		return _rescuableDescriptors[0].GetBearingIcon();
	}

	public override void Restore(LandmarkPersistentData landmarkPersistentData)
	{
		base.Restore(landmarkPersistentData);
		if (landmarkPersistentData.Behaviour.TryGetActionPersistentData<PersistentData>(out var data))
		{
			ActorType = data.ReturnActorType();
			_rescuableDescriptors = data.ReturnRescuableDescriptors();
			_associatedQuest = data.ReturnAssociatedQuest();
			_unlockedRescuables = data.UnlockedRescuables;
			AddDescriptor(data.ReturnForcedDescriptor());
		}
	}

	public override void RestoreReferences(LandmarkActionPersistentData data)
	{
		base.RestoreReferences(data);
		if (base.State != ILandmarkActionStates.Active)
		{
			return;
		}
		foreach (Rescueable rescueable in Rescueables)
		{
			if (!rescueable.IsToggled)
			{
				rescueable.Toggle();
			}
		}
	}

	public override LandmarkActionPersistentData ReturnLandmarkActionPersistentData()
	{
		return new PersistentData(this);
	}

	public bool TryGetFirstRescuableAgent(out Agent agent)
	{
		if (Rescueables != null)
		{
			foreach (Rescueable rescueable in Rescueables)
			{
				if (!rescueable.IsCompleted && rescueable.Agent != null)
				{
					agent = rescueable.Agent;
					return true;
				}
			}
		}
		agent = null;
		return false;
	}
}
