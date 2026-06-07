using System;
using System.Collections.Generic;
using UnityEngine.Events;

public class DialogueContext
{
	public enum ActorType
	{
		None = 0,
		FirstMate = 1,
		SelectedDrifter = 2,
		BuildableDrifter = 3,
		LandmarkDrifter = 4,
		BoatCaptain = 5,
		Doctor = 6,
		Patient = 7,
		QuestGiver = 8,
		RadioMessageSender = 9
	}

	private readonly Dictionary<ActorType, AgentDescriptor> _actors = new Dictionary<ActorType, AgentDescriptor>();

	private Buildable _currentBuildableContext;

	public void Initialize()
	{
		OnFirstMateUpdated();
		GameEventDispatcher.AddListener(GameEventType.GameStart, OnFirstMateUpdated);
		GameEventDispatcher.AddListener(GameEventType.NewGamePanelClosed, OnFirstMateUpdated);
		GameEventDispatcher.AddListener(GameEventType.AgentAddedToPlayerCommunity, OnFirstMateUpdated);
		GameEventDispatcher.AddListener(GameEventType.AgentDeath, OnFirstMateUpdated);
		GameEventDispatcher.AddListener(GameEventType.AgentSelected, OnAgentSelected);
		GameEventDispatcher.AddListener(GameEventType.AgentDeselected, OnAgentDeselected);
		GameEventDispatcher.AddListener(GameEventType.BuildableSelected, OnBuildableSelected);
		GameEventDispatcher.AddListener(GameEventType.BuildableDeselected, OnBuildableDeselected);
		GameEventDispatcher.AddListener(GameEventType.LandmarkSelected, OnLandmarkSelected);
		GameEventDispatcher.AddListener(GameEventType.LandmarkDeselected, OnLandmarkDeselected);
		GameEventDispatcher.AddListener(GameEventType.QuestUpdated, OnQuestStarted);
		GameEventDispatcher.AddListener(GameEventType.QuestCompleted, OnQuestCompleted);
		GameEventDispatcher.AddListener(GameEventType.RadioMessageRead, OnRadioMessageRead);
	}

	public void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.GameStart, OnFirstMateUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.NewGamePanelClosed, OnFirstMateUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.AgentAddedToPlayerCommunity, OnFirstMateUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.AgentDeath, OnFirstMateUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.AgentSelected, OnAgentSelected);
		GameEventDispatcher.RemoveListener(GameEventType.AgentDeselected, OnAgentDeselected);
		GameEventDispatcher.RemoveListener(GameEventType.BuildableSelected, OnBuildableSelected);
		GameEventDispatcher.RemoveListener(GameEventType.BuildableDeselected, OnBuildableDeselected);
		GameEventDispatcher.RemoveListener(GameEventType.LandmarkSelected, OnLandmarkSelected);
		GameEventDispatcher.RemoveListener(GameEventType.LandmarkDeselected, OnLandmarkDeselected);
		GameEventDispatcher.RemoveListener(GameEventType.QuestUpdated, OnQuestStarted);
		GameEventDispatcher.RemoveListener(GameEventType.QuestCompleted, OnQuestCompleted);
		GameEventDispatcher.RemoveListener(GameEventType.RadioMessageRead, OnRadioMessageRead);
	}

	public void Clear()
	{
		_actors.Clear();
	}

	public bool TryGetActor(ActorType actorType, out AgentDescriptor actor)
	{
		return _actors.TryGetValue(actorType, out actor);
	}

	public AgentDescriptor GetActor(ActorType actorType)
	{
		if (!_actors.TryGetValue(actorType, out var value))
		{
			SetActor(actorType, null);
		}
		return value;
	}

	public void SetActor(ActorType actorType, AgentDescriptor agent)
	{
		_actors[actorType] = agent;
	}

	private void OnFirstMateUpdated(GameEvent gameEvent = null)
	{
		if (!Community.PlayerCommunity.Agents.IsNullOrEmpty())
		{
			SetActor(ActorType.FirstMate, (Community.PlayerCommunity != null) ? Community.PlayerCommunity.Agents[0].Descriptor : null);
			GameEventDispatcher.RemoveListener(GameEventType.AgentAddedToPlayerCommunity, OnFirstMateUpdated);
		}
	}

	private void OnAgentSelected(GameEvent gameEvent)
	{
		SetActor(ActorType.SelectedDrifter, (gameEvent is AgentEvent agentEvent) ? agentEvent.AgentDescriptor : null);
	}

	private void OnAgentDeselected(GameEvent gameEvent)
	{
		SetActor(ActorType.SelectedDrifter, null);
	}

	private void OnBuildableSelected(GameEvent gameEvent)
	{
		if (gameEvent is BuildableEvent buildableEvent)
		{
			_currentBuildableContext = buildableEvent.Buildable;
			if (_currentBuildableContext.TryReturnBuildableExtendable<Boat>(out var buildableExtendable))
			{
				UpdateBoatCaptain(buildableExtendable);
				Boat boat = buildableExtendable;
				boat.BoatUpdatedEvent = (UnityAction<Boat>)Delegate.Remove(boat.BoatUpdatedEvent, new UnityAction<Boat>(UpdateBoatCaptain));
				Boat boat2 = buildableExtendable;
				boat2.BoatUpdatedEvent = (UnityAction<Boat>)Delegate.Combine(boat2.BoatUpdatedEvent, new UnityAction<Boat>(UpdateBoatCaptain));
				return;
			}
			if (_currentBuildableContext.TryReturnBuildableExtendable<Clinic>(out var buildableExtendable2))
			{
				UpdateClinicActors(buildableExtendable2);
				buildableExtendable2.OnUpdated -= UpdateClinicActors;
				buildableExtendable2.OnUpdated += UpdateClinicActors;
				return;
			}
			if (_currentBuildableContext.TryReturnBuildableExtendable<MedPod>(out var buildableExtendable3))
			{
				UpdateMedPodActors(buildableExtendable3);
				buildableExtendable3.OnUpdated -= UpdateMedPodActors;
				buildableExtendable3.OnUpdated += UpdateMedPodActors;
				return;
			}
			if (_currentBuildableContext.TryReturnBuildableExtendable<Producer>(out var buildableExtendable4))
			{
				buildableExtendable4.OnStartProducing.AddListener(UpdateBuildableActor);
				buildableExtendable4.OnStopProducing.AddListener(UpdateBuildableActor);
			}
			UpdateBuildableActor(_currentBuildableContext);
			_currentBuildableContext.OnAssignedProjectUpdatedEvent.AddListener(UpdateBuildableActor);
		}
		else
		{
			SetActor(ActorType.BuildableDrifter, null);
		}
	}

	private void UpdateBuildableActor(Buildable buildable)
	{
		using ListPool<Agent>.List list = ListPool<Agent>.Get(8);
		if (buildable.AssignedProject != null)
		{
			buildable.AssignedProject.ReturnAssignedAgents(list);
		}
		else
		{
			buildable.ReturnAgentsOnBuildable(list);
		}
		SetActor(ActorType.BuildableDrifter, (list.Count > 0) ? list[0].Descriptor : null);
	}

	private void UpdateBoatCaptain(Boat boat)
	{
		SetActor(ActorType.BoatCaptain, (boat.Captain != null) ? boat.Captain.Descriptor : null);
	}

	private void UpdateClinicActors(Clinic clinic)
	{
		SetActor(ActorType.Doctor, (clinic.Doctor != null) ? clinic.Doctor.Descriptor : null);
		SetActor(ActorType.Patient, (clinic.Patient != null) ? clinic.Patient.Descriptor : null);
	}

	private void UpdateMedPodActors(MedPod medPod)
	{
		SetActor(ActorType.Doctor, medPod.GetDoctorDescriptor());
		SetActor(ActorType.Patient, medPod.GetPatientDescriptor());
	}

	private void OnBuildableDeselected(GameEvent gameEvent)
	{
		if (gameEvent is BuildableEvent buildableEvent && buildableEvent.Buildable != null)
		{
			UnregisterFromBuildableEvents(buildableEvent.Buildable);
		}
		else
		{
			UnregisterFromBuildableEvents(_currentBuildableContext);
		}
		_currentBuildableContext = null;
		SetActor(ActorType.BuildableDrifter, null);
		SetActor(ActorType.BoatCaptain, null);
		SetActor(ActorType.Doctor, null);
		SetActor(ActorType.Patient, null);
	}

	private void UnregisterFromBuildableEvents(Buildable buildable)
	{
		Clinic buildableExtendable2;
		MedPod buildableExtendable3;
		Producer buildableExtendable4;
		if (buildable.TryReturnBuildableExtendable<Boat>(out var buildableExtendable))
		{
			Boat boat = buildableExtendable;
			boat.BoatUpdatedEvent = (UnityAction<Boat>)Delegate.Remove(boat.BoatUpdatedEvent, new UnityAction<Boat>(UpdateBoatCaptain));
		}
		else if (buildable.TryReturnBuildableExtendable<Clinic>(out buildableExtendable2))
		{
			buildableExtendable2.OnUpdated -= UpdateClinicActors;
		}
		else if (buildable.TryReturnBuildableExtendable<MedPod>(out buildableExtendable3))
		{
			buildableExtendable3.OnUpdated -= UpdateMedPodActors;
		}
		else if (buildable.TryReturnBuildableExtendable<Producer>(out buildableExtendable4))
		{
			buildableExtendable4.OnStartProducing.RemoveListener(UpdateBuildableActor);
			buildableExtendable4.OnStopProducing.RemoveListener(UpdateBuildableActor);
		}
		buildable.OnAssignedProjectUpdatedEvent.RemoveListener(UpdateBuildableActor);
	}

	private void OnLandmarkSelected(GameEvent gameEvent)
	{
		Agent agent = null;
		if (gameEvent is LandmarkNotificationEvent { LandmarkBehaviour: ActionsBehaviour landmarkBehaviour } && landmarkBehaviour.TryReturnAction<LandmarkActionRescue>(out var action, false))
		{
			action.TryGetFirstRescuableAgent(out agent);
		}
		SetActor(ActorType.LandmarkDrifter, (agent != null) ? agent.Descriptor : null);
	}

	private void OnLandmarkDeselected(GameEvent gameEvent)
	{
		SetActor(ActorType.LandmarkDrifter, null);
	}

	private void OnQuestStarted(GameEvent gameEvent)
	{
		if (gameEvent is QuestEvent questEvent)
		{
			SetActor(ActorType.QuestGiver, questEvent.Quest.QuestGiver);
		}
	}

	private void OnQuestCompleted(GameEvent gameEvent)
	{
		if (gameEvent is QuestEvent questEvent && questEvent.Quest.QuestGiver == GetActor(ActorType.QuestGiver))
		{
			SetActor(ActorType.QuestGiver, null);
		}
	}

	private void OnRadioMessageRead(GameEvent gameEvent)
	{
		if (gameEvent is RadioMessageEvent { Message: not null } radioMessageEvent)
		{
			SetActor(ActorType.RadioMessageSender, radioMessageEvent.Message.Sender);
		}
	}
}
