using System;
using System.Collections.Generic;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using TH20.EventAwardRemixBadge;
using TH20.EventAwardStar;
using TH20.EventUnlockItem;

namespace TH20
{
	public class ResearchManager : MustCallDestroy, IGameEventsBase, TH20.EventUnlockItem.Interface, IGameEventCallback, TH20.EventAwardStar.Interface, TH20.EventAwardRemixBadge.Interface
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public SharedInstance<ResearchProjectDefinition>[] Projects;
		}

		public Action<ResearchProject, RoomItem> OnResearchProjectAssigned;

		public Action<ResearchProject, RoomItem> OnResearchProjectRemoved;

		public Action<ResearchProject> OnResearchProjectComplete;

		public Action<float, ResearchProject> OnResearchPointsAdded;

		private readonly Level _level;

		private readonly BuildEvents _buildEvents;

		private readonly CharacterEvents _characterEvents;

		private readonly Dictionary<ResearchProjectDefinition, ResearchProject> _projects;

		private Config _config;

		public ResearchManager(Config config, Level level, BuildEvents buildEvents, CharacterEvents characterEvents)
		{
			GameEventsRegistry.RegisterLevelEvent(this);
			_level = level;
			_config = config;
			_buildEvents = buildEvents;
			_characterEvents = characterEvents;
			_projects = new Dictionary<ResearchProjectDefinition, ResearchProject>();
			AddAllProjects();
			RegisterEvents();
		}

		private void AddAllProjects()
		{
			Metagame metagame = _level.Metagame;
			SharedInstance<ResearchProjectDefinition>[] projects = _config.Projects;
			for (int i = 0; i < projects.Length; i++)
			{
				ResearchProjectDefinition instance = projects[i].Instance;
				float researchProjectPoints = metagame.GetResearchProjectPoints(instance);
				if (_projects.ContainsKey(instance))
				{
					_projects[instance].ResearchedPoints = _level.Metagame.GetResearchProjectPoints(instance);
					continue;
				}
				ResearchProject researchProject = new ResearchProject(instance, this, researchProjectPoints);
				if (!instance.Repeatable && metagame.HasCompletedResearchProject(instance))
				{
					researchProject.SetComplete();
				}
				_projects.Add(instance, researchProject);
			}
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			CheckProjectPrerequisites();
			AddAllProjects();
			RegisterEvents();
			foreach (ResearchProject value in _projects.Values)
			{
				RoomItem[] array = value.Assigned.ToArray();
				foreach (RoomItem roomItem in array)
				{
					if (roomItem.FloorPlan is BlueprintFloorPlan blueprintFloorPlan)
					{
						value.Assigned.Remove(roomItem);
						if (!blueprintFloorPlan.HasBeenDestroyed())
						{
							blueprintFloorPlan.Destroy();
						}
						if (!roomItem.HasBeenDestroyed())
						{
							roomItem.Destroy();
						}
					}
				}
			}
		}

		public override void Destroy()
		{
			UnregisterEvents();
			base.Destroy();
		}

		private void RegisterEvents()
		{
			foreach (KeyValuePair<ResearchProjectDefinition, ResearchProject> project in _projects)
			{
				ResearchProject value = project.Value;
				value.OnPointsAdded = (Action<float, ResearchProject>)Delegate.Combine(value.OnPointsAdded, new Action<float, ResearchProject>(PointsAddedToProjectListener));
			}
			BuildEvents buildEvents = _buildEvents;
			buildEvents.OnRoomItemDestroyed = (Action<RoomItem>)Delegate.Combine(buildEvents.OnRoomItemDestroyed, new Action<RoomItem>(OnRoomItemDestroyed));
			CharacterEvents characterEvents = _characterEvents;
			characterEvents.OnGhostCaptured = (Action<Character, Staff>)Delegate.Combine(characterEvents.OnGhostCaptured, new Action<Character, Staff>(OnGhostCaptured));
			CharacterEvents characterEvents2 = _characterEvents;
			characterEvents2.OnPatientReceivedDiagnosis = (Action<Patient, Staff, Room, float>)Delegate.Combine(characterEvents2.OnPatientReceivedDiagnosis, new Action<Patient, Staff, Room, float>(OnPatientReceivedDiagnosis));
			CharacterEvents characterEvents3 = _characterEvents;
			characterEvents3.OnPatientReceivedTreatment = (Action<Patient, Staff, Room>)Delegate.Combine(characterEvents3.OnPatientReceivedTreatment, new Action<Patient, Staff, Room>(OnPatientReceivedTreatment));
			CharacterEvents characterEvents4 = _characterEvents;
			characterEvents4.OnAddQualification = (Action<QualificationDefinition, int>)Delegate.Combine(characterEvents4.OnAddQualification, new Action<QualificationDefinition, int>(OnAddQualification));
			CharacterEvents characterEvents5 = _characterEvents;
			characterEvents5.OnAddIllness = (Action<IllnessDefinition>)Delegate.Combine(characterEvents5.OnAddIllness, new Action<IllnessDefinition>(OnAddIllness));
			CharacterEvents characterEvents6 = _characterEvents;
			characterEvents6.OnIllnessDiagnosed = (Action<Patient, IllnessDefinition>)Delegate.Combine(characterEvents6.OnIllnessDiagnosed, new Action<Patient, IllnessDefinition>(OnIllnessDiagnosed));
			_level.Metagame.OnItemUnlocked.Add(this);
			_level.Metagame.OnStarAwarded.Add(this);
			_level.Metagame.OnRemixBadgeAwarded.Add(this);
		}

		private void UnregisterEvents()
		{
			foreach (ResearchProject value in _projects.Values)
			{
				value.OnPointsAdded = (Action<float, ResearchProject>)Delegate.Remove(value.OnPointsAdded, new Action<float, ResearchProject>(PointsAddedToProjectListener));
			}
			BuildEvents buildEvents = _buildEvents;
			buildEvents.OnRoomItemDestroyed = (Action<RoomItem>)Delegate.Remove(buildEvents.OnRoomItemDestroyed, new Action<RoomItem>(OnRoomItemDestroyed));
			CharacterEvents characterEvents = _characterEvents;
			characterEvents.OnGhostCaptured = (Action<Character, Staff>)Delegate.Remove(characterEvents.OnGhostCaptured, new Action<Character, Staff>(OnGhostCaptured));
			CharacterEvents characterEvents2 = _characterEvents;
			characterEvents2.OnPatientReceivedDiagnosis = (Action<Patient, Staff, Room, float>)Delegate.Remove(characterEvents2.OnPatientReceivedDiagnosis, new Action<Patient, Staff, Room, float>(OnPatientReceivedDiagnosis));
			CharacterEvents characterEvents3 = _characterEvents;
			characterEvents3.OnPatientReceivedTreatment = (Action<Patient, Staff, Room>)Delegate.Remove(characterEvents3.OnPatientReceivedTreatment, new Action<Patient, Staff, Room>(OnPatientReceivedTreatment));
			CharacterEvents characterEvents4 = _characterEvents;
			characterEvents4.OnAddQualification = (Action<QualificationDefinition, int>)Delegate.Remove(characterEvents4.OnAddQualification, new Action<QualificationDefinition, int>(OnAddQualification));
			CharacterEvents characterEvents5 = _characterEvents;
			characterEvents5.OnAddIllness = (Action<IllnessDefinition>)Delegate.Remove(characterEvents5.OnAddIllness, new Action<IllnessDefinition>(OnAddIllness));
			CharacterEvents characterEvents6 = _characterEvents;
			characterEvents6.OnIllnessDiagnosed = (Action<Patient, IllnessDefinition>)Delegate.Remove(characterEvents6.OnIllnessDiagnosed, new Action<Patient, IllnessDefinition>(OnIllnessDiagnosed));
			_level.Metagame.OnItemUnlocked.Remove(this);
			_level.Metagame.OnStarAwarded.Remove(this);
			_level.Metagame.OnRemixBadgeAwarded.Remove(this);
		}

		public void VerifyEvents()
		{
			OnResearchProjectAssigned.VerifyIsNull();
			OnResearchProjectRemoved.VerifyIsNull();
			OnResearchProjectComplete.VerifyIsNull();
			OnResearchPointsAdded.VerifyIsNull();
		}

		public void AssignProject(ResearchProject project, RoomItem roomItem)
		{
			roomItem.GetComponent<ResearchProjectComponent>().AssignProject(project);
			project.Assigned.Add(roomItem);
			OnResearchProjectAssigned.InvokeSafe(project, roomItem);
		}

		public void AssignProjectSilent(ResearchProject project, RoomItem roomItem)
		{
			roomItem.GetComponent<ResearchProjectComponent>().AssignProject(project);
			project.Assigned.Add(roomItem);
		}

		public void RemoveResearchProject(ResearchProject project, RoomItem roomItem)
		{
			roomItem.GetComponent<ResearchProjectComponent>()?.ClearProject();
			project.Assigned.Remove(roomItem);
			OnResearchProjectRemoved.InvokeSafe(project, roomItem);
		}

		public void CompleteResearchProject(ResearchProject project)
		{
			RewardUtils.GiveAllRewards(null, project.Definition.Rewards, _level.Metagame);
			while (project.Assigned.Count != 0)
			{
				RemoveResearchProject(project, project.Assigned[0]);
			}
			_level.Notifications.Send(new NotificationResearchComplete(_level.Notifications.MessageDefinitions._researchCompleteMessage, project.Definition, _level));
			if (_level.App.GameMode is GameModeSandbox)
			{
				if (_level.Metagame != null)
				{
					_level.Metagame.OnResearchProjectComplete(project);
				}
			}
			else
			{
				OnResearchProjectComplete.InvokeSafe(project);
			}
			_level.ObjectiveEvents.OnGameEvent.InvokeSafe(ObjectiveGameEvent.ResearchProjectCompleted);
			TryRadioLineInjection(project.Definition);
			CheckProjectPrerequisites();
		}

		private void OnRoomItemDestroyed(RoomItem roomItem)
		{
			ResearchProjectComponent component = roomItem.GetComponent<ResearchProjectComponent>();
			if (component != null && component.Project != null)
			{
				RemoveResearchProject(component.Project, roomItem);
			}
		}

		private void PointsAddedToProjectListener(float points, ResearchProject project)
		{
			_level.Metagame.UpdateResearchProjectPoints(project.Definition, project.ResearchedPoints);
			OnResearchPointsAdded.InvokeSafe(points, project);
		}

		public ResearchProject GetProject(ResearchProjectDefinition definition)
		{
			if (_projects.ContainsKey(definition))
			{
				return _projects[definition];
			}
			return null;
		}

		public List<ResearchProject> GetAllProjectsForLevel(Level level)
		{
			List<ResearchProject> list = new List<ResearchProject>();
			foreach (ResearchProject value in _projects.Values)
			{
				if (value.IsValid(level))
				{
					list.Add(value);
				}
			}
			return list;
		}

		private void OnGhostCaptured(Character ghost, Staff staff)
		{
			float num = 0f;
			IllnessDefinition illness = ghost.GetComponent<DeathRecordComponent>().Illness;
			if (illness != null)
			{
				foreach (ResearchProject value in _projects.Values)
				{
					if (value.IsValid(_level) && value.Definition.CanAddPoints(illness, null))
					{
						num += illness.ResearchPointsGhostCapture;
						value.AddPoints(illness.ResearchPointsGhostCapture);
					}
				}
			}
			string text = ScriptLocalization.Research.CapturedGhost_CS.Replace("{[NAME]}", ghost.Name);
			if (num > 0f)
			{
				text += "\n";
				text += ScriptLocalization.Research.CapturedGhost_ResearchPoints_CS.Replace("{[POINTS]}", ((int)num).ToString());
			}
			_level.InWorldMessages.ShowMessage(text, staff.Position, 3f, InWorldMessages.MessageType.Info);
		}

		private void OnPatientReceivedDiagnosis(Patient patient, Staff staff, Room room, float increment)
		{
			IllnessDefinition illness = patient.Illness;
			RoomDefinition definition = room.Definition;
			foreach (ResearchProject value in _projects.Values)
			{
				if (value.IsValid(_level) && value.Definition.CanAddPoints(illness, definition))
				{
					value.AddPoints(illness.ResearchPointsDiagnosis);
				}
			}
		}

		private void OnPatientReceivedTreatment(Patient patient, Staff staff, Room room)
		{
			IllnessDefinition illness = patient.Illness;
			RoomDefinition definition = room.Definition;
			float treatmentResearchPoints = illness.GetTreatmentResearchPoints(patient.TreatmentOutcome);
			foreach (ResearchProject value in _projects.Values)
			{
				if (value.IsValid(_level) && value.Definition.CanAddPoints(illness, definition))
				{
					value.AddPoints(treatmentResearchPoints);
				}
			}
		}

		public void AwardResearchPoints(float points, ResearchProjectDefinition definition)
		{
			ResearchProject researchProject = null;
			if (definition != null)
			{
				researchProject = GetProject(definition);
			}
			else
			{
				List<ResearchProject> allProjectsForLevel = GetAllProjectsForLevel(_level);
				if (allProjectsForLevel.Count != 0)
				{
					researchProject = allProjectsForLevel.RandomItem();
				}
			}
			if (researchProject != null && researchProject.IsValid(_level))
			{
				researchProject.AddPoints(points);
			}
		}

		public void OnItemUnlockedEvent(ISilverUnlockable item)
		{
			CheckProjectPrerequisites();
		}

		private void OnAddQualification(QualificationDefinition definition, int weight)
		{
			CheckProjectPrerequisites();
		}

		private void OnAddIllness(IllnessDefinition illness)
		{
			CheckProjectPrerequisites();
		}

		private void OnIllnessDiagnosed(Patient patient, IllnessDefinition illness)
		{
			CheckProjectPrerequisites();
		}

		public void OnStarAwardedEvent(MetagameHospitalRecord.StarIndex starIndex, LevelConfig levelConfig, bool debug)
		{
			CheckProjectPrerequisites();
		}

		public void OnRemixBadgeAwardedEvent(LevelConfig levelConfig, bool debug)
		{
			CheckProjectPrerequisites();
		}

		private void CheckProjectPrerequisites()
		{
			SharedInstance<ResearchProjectDefinition>[] projects = _config.Projects;
			for (int i = 0; i < projects.Length; i++)
			{
				ResearchProjectDefinition instance = projects[i].Instance;
				if (instance.PrerequisitesMet(_level))
				{
					_level.Metagame.UnlockResearchProject(instance);
				}
			}
		}

		private void TryRadioLineInjection(ResearchProjectDefinition definition)
		{
			if (definition.LineInjectionsOnCompletion == null || definition.ChanceOfLineInjection < RandomUtils.GlobalRandomInstance.NextFloat(0f, 1f))
			{
				return;
			}
			Dictionary<RadioDJDefinition, RadioDJQuote> dictionary = new Dictionary<RadioDJDefinition, RadioDJQuote>();
			foreach (KeyValuePair<SharedInstance<RadioDJDefinition>, RadioDJQuote> item in definition.LineInjectionsOnCompletion)
			{
				dictionary[item.Key.Instance] = item.Value;
			}
			_level.Radio.SuggestLineInjection(dictionary);
		}
	}
}
