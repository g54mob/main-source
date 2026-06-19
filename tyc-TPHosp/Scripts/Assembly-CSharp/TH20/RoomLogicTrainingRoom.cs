#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using I2.Loc;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomLogicTrainingRoom : RoomLogic
	{
		private class TrainingSessionData
		{
			public Staff Teacher;

			public List<Staff> Pupils;

			public QualificationDefinition Qualification;
		}

		[SerializeField]
		private ExternalBehavior _trainerBehaviour;

		[SerializeField]
		private ExternalBehavior _traineeBehaviour;

		[SerializeField]
		private ExternalBehavior _trainerEndBehaviour;

		private Staff _teacher;

		private Staff _droppedTeacherPending;

		private List<Staff> _pupils;

		private QualificationDefinition _qualification;

		private TrainingSessionData _savedSession;

		private float _sessionStartTime;

		private Staff _teacherFinishing;

		private int _trainerFinishedBehaviourID;

		public bool IsAvailable
		{
			get
			{
				if (_teacher != null)
				{
					return false;
				}
				if (_savedSession != null && _savedSession.Teacher != null)
				{
					return false;
				}
				return true;
			}
		}

		public QualificationDefinition Qualification
		{
			get
			{
				if (_savedSession == null)
				{
					return _qualification;
				}
				return _savedSession.Qualification;
			}
		}

		public List<Staff> Pupils
		{
			get
			{
				if (_savedSession == null)
				{
					return _pupils;
				}
				return _savedSession.Pupils;
			}
		}

		public Staff Teacher
		{
			get
			{
				if (_savedSession == null)
				{
					return _teacher;
				}
				return _savedSession.Teacher;
			}
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_pupils = new List<Staff>();
			RegisterEvents();
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			RegisterEvents();
			if (_trainerFinishedBehaviourID != 0 && _teacherFinishing != null)
			{
				Staff teacherFinishing = _teacherFinishing;
				teacherFinishing.PostRestoreFromSaveCallback = (Action)Delegate.Combine(teacherFinishing.PostRestoreFromSaveCallback, (Action)delegate
				{
					BindTrainerEndEvent(_teacherFinishing, _trainerFinishedBehaviourID);
				});
			}
		}

		public override void Destroy()
		{
			CancelSavedSession();
			UnregisterEvents();
			base.Destroy();
		}

		private void RegisterEvents()
		{
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomOpened = (Action<Room>)Delegate.Combine(buildEvents.OnRoomOpened, new Action<Room>(OnRoomOpened));
			BuildEvents buildEvents2 = base.Level.BuildEvents;
			buildEvents2.OnRoomClosed = (Action<Room>)Delegate.Combine(buildEvents2.OnRoomClosed, new Action<Room>(OnRoomClosed));
			BuildEvents buildEvents3 = base.Level.BuildEvents;
			buildEvents3.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents3.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnStaffDrop = (Action<Staff, Room, bool>)Delegate.Combine(characterEvents.OnStaffDrop, new Action<Staff, Room, bool>(OnStaffDrop));
			CharacterEvents characterEvents2 = base.Level.CharacterEvents;
			characterEvents2.OnPlanToEnterRoom = (Action<Character, Room>)Delegate.Combine(characterEvents2.OnPlanToEnterRoom, new Action<Character, Room>(OnEnterRoom));
			CharacterEvents characterEvents3 = base.Level.CharacterEvents;
			characterEvents3.OnPlanToExitRoom = (Action<Character, Room>)Delegate.Combine(characterEvents3.OnPlanToExitRoom, new Action<Character, Room>(OnExitRoom));
			CharacterEvents characterEvents4 = base.Level.CharacterEvents;
			characterEvents4.OnStaffFired = (Action<Staff>)Delegate.Combine(characterEvents4.OnStaffFired, new Action<Staff>(OnStaffBecameInvalid));
			CharacterEvents characterEvents5 = base.Level.CharacterEvents;
			characterEvents5.OnStaffResigned = (Action<Staff>)Delegate.Combine(characterEvents5.OnStaffResigned, new Action<Staff>(OnStaffBecameInvalid));
			CharacterEvents characterEvents6 = base.Level.CharacterEvents;
			characterEvents6.OnStaffDestroyed = (Action<Staff>)Delegate.Combine(characterEvents6.OnStaffDestroyed, new Action<Staff>(OnStaffBecameInvalid));
			CharacterEvents characterEvents7 = base.Level.CharacterEvents;
			characterEvents7.OnStaffReadyToStartTraining = (Action<Staff, Room>)Delegate.Combine(characterEvents7.OnStaffReadyToStartTraining, new Action<Staff, Room>(OnStaffReadyToStartTraining));
		}

		private void UnregisterEvents()
		{
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomOpened = (Action<Room>)Delegate.Remove(buildEvents.OnRoomOpened, new Action<Room>(OnRoomOpened));
			BuildEvents buildEvents2 = base.Level.BuildEvents;
			buildEvents2.OnRoomClosed = (Action<Room>)Delegate.Remove(buildEvents2.OnRoomClosed, new Action<Room>(OnRoomClosed));
			BuildEvents buildEvents3 = base.Level.BuildEvents;
			buildEvents3.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents3.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnStaffDrop = (Action<Staff, Room, bool>)Delegate.Remove(characterEvents.OnStaffDrop, new Action<Staff, Room, bool>(OnStaffDrop));
			CharacterEvents characterEvents2 = base.Level.CharacterEvents;
			characterEvents2.OnPlanToEnterRoom = (Action<Character, Room>)Delegate.Remove(characterEvents2.OnPlanToEnterRoom, new Action<Character, Room>(OnEnterRoom));
			CharacterEvents characterEvents3 = base.Level.CharacterEvents;
			characterEvents3.OnPlanToExitRoom = (Action<Character, Room>)Delegate.Remove(characterEvents3.OnPlanToExitRoom, new Action<Character, Room>(OnExitRoom));
			CharacterEvents characterEvents4 = base.Level.CharacterEvents;
			characterEvents4.OnStaffFired = (Action<Staff>)Delegate.Remove(characterEvents4.OnStaffFired, new Action<Staff>(OnStaffBecameInvalid));
			CharacterEvents characterEvents5 = base.Level.CharacterEvents;
			characterEvents5.OnStaffResigned = (Action<Staff>)Delegate.Remove(characterEvents5.OnStaffResigned, new Action<Staff>(OnStaffBecameInvalid));
			CharacterEvents characterEvents6 = base.Level.CharacterEvents;
			characterEvents6.OnStaffDestroyed = (Action<Staff>)Delegate.Remove(characterEvents6.OnStaffDestroyed, new Action<Staff>(OnStaffBecameInvalid));
			CharacterEvents characterEvents7 = base.Level.CharacterEvents;
			characterEvents7.OnStaffReadyToStartTraining = (Action<Staff, Room>)Delegate.Remove(characterEvents7.OnStaffReadyToStartTraining, new Action<Staff, Room>(OnStaffReadyToStartTraining));
		}

		public override void Tick()
		{
			if (_teacher != null && _qualification != null && ValidateTeacher())
			{
				if (_pupils.Count == 0)
				{
					if (GameTime.time > _sessionStartTime + GameAlgorithms.Config.TrainingSessionWaitTime)
					{
						base.Level.CharacterEvents.OnTrainingCourseFinished.InvokeSafe(_qualification);
						CancelTraining(success: true);
					}
				}
				else if (_teacher.RoomUsing == _room)
				{
					Staff[] array = _pupils.ToArray();
					foreach (Staff pupil in array)
					{
						UpdateLearning(pupil, Time.deltaTime);
					}
				}
			}
			ShowLecternStatusIcon(_qualification != null);
		}

		private bool ValidateTeacher()
		{
			if (_teacher is GuestTrainer guestTrainer && guestTrainer.Enabled && guestTrainer.IsOrphaned())
			{
				Logging.Error(LogChannels.Training, "Found zombie guest trainer {0} cancelling course", guestTrainer);
				_teacher = null;
				CancelTraining(success: false);
				return false;
			}
			return true;
		}

		private void UpdateLearning(Staff pupil, float deltaTime)
		{
			if (pupil.RoomUsing == _room)
			{
				float num = GameAlgorithms.CalculateTrainingPointLearnRate(_teacher, pupil, _pupils.Count, _room);
				if (pupil.IncreaseLearning(_qualification, num * deltaTime))
				{
					RemovePupil(pupil);
					base.Level.CharacterEvents.OnStaffQualificationComplete.InvokeSafe(pupil, _qualification, _teacher);
					_room.OnUnitProcessed();
				}
			}
		}

		private void OnRoomOpened(Room room)
		{
			if (room != _room || _savedSession == null)
			{
				return;
			}
			if (_savedSession.Teacher != null && _savedSession.Pupils.Count != 0)
			{
				while (_savedSession.Pupils.Count > _room.FloorPlan.MaxCapacity)
				{
					Staff staff = _savedSession.Pupils.RandomItem();
					RemovePupil(staff);
					_savedSession.Pupils.Remove(staff);
				}
				StartTraining(_savedSession.Qualification, _savedSession.Teacher, _savedSession.Pupils);
			}
			else
			{
				CancelSavedSession();
			}
			_savedSession = null;
		}

		private void CancelSavedSession()
		{
			if (_savedSession == null)
			{
				return;
			}
			GuestTrainer guestTrainer = _savedSession.Teacher as GuestTrainer;
			if (guestTrainer != null)
			{
				if (guestTrainer.IsOrphaned())
				{
					Level level = base.Level;
					level.PostConstruct = (Action)Delegate.Combine(level.PostConstruct, (Action)delegate
					{
						guestTrainer.Level.CharacterManager.DestroyOrphan(guestTrainer);
					});
				}
				else if (TeacherHasArrived())
				{
					guestTrainer.Idle();
				}
			}
			_savedSession = null;
		}

		private void OnRoomClosed(Room room)
		{
			if (_room == room && _savedSession == null)
			{
				_savedSession = new TrainingSessionData
				{
					Teacher = _teacher,
					Pupils = new List<Staff>(_pupils),
					Qualification = _qualification
				};
				CancelTraining(success: false);
				if (_savedSession.Teacher is GuestTrainer guestTrainer)
				{
					guestTrainer.WaitForTrainingRoom(room);
				}
			}
		}

		private void OnRoomItemRemoved(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (_room == floorPlan.OwningRoom)
			{
				if (!_room.HasValidRequiredItems())
				{
					CancelTraining(success: false);
				}
				else if (roomItem.HasInterationWithName("Trainee"))
				{
					RemoveExtraPupils(roomItem);
				}
			}
		}

		private void RemoveExtraPupils(RoomItem desk)
		{
			while (_pupils.Count > _room.FloorPlan.MaxCapacity)
			{
				List<Staff> list = new List<Staff>();
				foreach (Staff pupil in _pupils)
				{
					if (pupil.RoomUsing != _room)
					{
						list.Add(pupil);
					}
					else if (pupil.Interaction == null || (pupil.Interaction != null && pupil.Interaction.ParentRoomItem == desk))
					{
						list.Add(pupil);
					}
				}
				Staff staff = null;
				if (list.Count != 0)
				{
					staff = list.RandomItem();
				}
				else if (_pupils.Count != 0)
				{
					staff = _pupils.RandomItem();
				}
				if (staff != null)
				{
					RemovePupil(staff);
					continue;
				}
				break;
			}
		}

		public override bool ShouldIdleWhenDroppedInRoom(Staff staff)
		{
			if (staff != _teacher && staff != _droppedTeacherPending)
			{
				return !_pupils.Contains(staff);
			}
			return false;
		}

		private void OnStaffDrop(Staff staff, Room room, bool jobSearch)
		{
			_droppedTeacherPending = null;
			if (_room != room)
			{
				if (staff == _teacher)
				{
					CancelTraining(success: false);
				}
				else if (_pupils.Contains(staff))
				{
					RemovePupil(staff);
				}
			}
			else
			{
				if (_room != room || !room.IsOpen || !room.HasValidRequiredItems())
				{
					return;
				}
				if (staff == _teacher)
				{
					StartTeacherBehaviour(staff);
				}
				else if (_pupils.Contains(staff))
				{
					StartPupilBehaviour(staff);
				}
				else
				{
					if (staff.IsRoboJanitor())
					{
						return;
					}
					if (_teacher != null)
					{
						if (!staff.IsFullyTrained && (_qualification == null || _qualification.ValidForExcludeIncomplete(staff)) && CanAddPupils() && CanAfford() && _room.EnterRoom(staff, ReasonUseRoom.Visit))
						{
							AddPupil(staff);
						}
					}
					else if (IsNearLectern(staff))
					{
						if (staff.HasQualifications())
						{
							_droppedTeacherPending = staff;
							if (_room.EnterRoom(staff, ReasonUseRoom.Work))
							{
								base.Level.HUD.CreateMenu<TrainingMenu>().Setup(base.Level, staff, null, _room);
							}
						}
					}
					else if (!staff.IsFullyTrained && CanAddPupils() && _room.EnterRoom(staff, ReasonUseRoom.Visit))
					{
						base.Level.HUD.CreateMenu<TrainingMenu>().Setup(base.Level, null, staff, _room);
					}
				}
			}
		}

		public override string GetStaffDropResult(Staff staff)
		{
			if (!_room.HasValidRequiredItems())
			{
				return null;
			}
			if (staff.IsRoboJanitor())
			{
				return null;
			}
			if (staff == _teacher)
			{
				return ScriptLocalization.Staff.DropResult_Training_TeachQualification_CS.Replace("{[QUALIFICATION]}", _qualification.NameLocalised.Translation);
			}
			if (_pupils.Contains(staff))
			{
				return ScriptLocalization.Staff.DropResult_Training_LearnQualification_CS.Replace("{[QUALIFICATION]}", _qualification.NameLocalised.Translation);
			}
			if (_teacher != null)
			{
				if (staff.IsFullyTrained)
				{
					return ScriptLocalization.Staff.DropResult_Training_NoSlots_CS;
				}
				if (!CanAddPupils())
				{
					return ScriptLocalization.Staff.DropResult_Training_MaxCapacity_CS;
				}
				if (_qualification != null && !_qualification.ValidForExcludeIncomplete(staff))
				{
					return ScriptLocalization.Staff.DropResult_Training_InvalidCourse_CS.Replace("{[QUALIFICATION]}", _qualification.NameLocalised.Translation);
				}
				if (_qualification != null && CanAfford())
				{
					return ScriptLocalization.Staff.DropResult_Training_LearnQualification_CS.Replace("{[QUALIFICATION]}", _qualification.NameLocalised.Translation);
				}
			}
			if (_teacher == null)
			{
				if (IsNearLectern(staff))
				{
					if (staff.HasQualifications())
					{
						return ScriptLocalization.Staff.DropResult_Training_Teach_CS;
					}
					return ScriptLocalization.Staff.DropResult_Training_NoQualificationsToTeach_CS;
				}
				if (staff.IsFullyTrained)
				{
					return ScriptLocalization.Staff.DropResult_Training_NoSlots_CS;
				}
				if (!CanAddPupils())
				{
					return ScriptLocalization.Staff.DropResult_Training_MaxCapacity_CS;
				}
				return ScriptLocalization.Staff.DropResult_Training_Learn_CS;
			}
			return null;
		}

		private bool CanAfford()
		{
			bool result = true;
			if (_teacher is GuestTrainer guestTrainer)
			{
				GuestTrainerDefinition.Skill skill = guestTrainer.Definition.GetSkill(_qualification);
				result = base.Level.FinanceManager.CanAfford(skill.GetCostPerTrainee(base.Level));
			}
			return result;
		}

		public override bool IsProjectAssigned()
		{
			return _qualification != null;
		}

		private void OnEnterRoom(Character character, Room room)
		{
			if (room == _room && character is Staff staff)
			{
				if (staff == _teacher)
				{
					StartTeacherBehaviour(staff);
				}
				else if (_pupils.Contains(staff))
				{
					StartPupilBehaviour(staff);
				}
			}
		}

		private void OnExitRoom(Character character, Room room)
		{
			if (room == _room && character is Staff staff)
			{
				if (_teacher == staff && _teacher.CurrentMode == Staff.Mode.Training)
				{
					CancelTraining(success: false);
				}
				else if (_pupils.Contains(staff) && staff.CurrentMode == Staff.Mode.Trained)
				{
					RemovePupil(staff);
				}
			}
		}

		private void OnStaffBecameInvalid(Staff staff)
		{
			if (_teacher == staff)
			{
				CancelTraining(success: false);
			}
			else if (_pupils.Contains(staff))
			{
				RemovePupil(staff);
			}
			else if (_savedSession != null)
			{
				if (_savedSession.Teacher == staff)
				{
					_savedSession.Teacher = null;
				}
				else if (_savedSession.Pupils.Contains(staff))
				{
					_savedSession.Pupils.Remove(staff);
				}
			}
		}

		private void OnStaffReadyToStartTraining(Staff staff, Room room)
		{
			if (room != _room)
			{
				OnStaffBecameInvalid(staff);
			}
		}

		private void SetTeacher(Staff teacher)
		{
			if (teacher.StartTraining(_qualification, _room))
			{
				base.Level.CharacterEvents.OnStaffStartTeaching.InvokeSafe(teacher, this);
			}
			_teacher = teacher;
			_droppedTeacherPending = null;
		}

		private void AddPupil(Staff pupil)
		{
			if (!_pupils.Contains(pupil))
			{
				if (pupil.RoomUsing == _room)
				{
					StartPupilBehaviour(pupil);
				}
				_pupils.Add(pupil);
				if (pupil.StartBeingTrained(_qualification, _room))
				{
					base.Level.CharacterEvents.OnStaffStartLearning.InvokeSafe(pupil, this);
				}
			}
		}

		private void RemovePupil(Staff pupil)
		{
			if (pupil != null)
			{
				if (pupil.GoingToRoom == _room || pupil.RoomUsing == _room)
				{
					pupil.Idle();
				}
				pupil.StopThinkingAboutTraining();
				_pupils.Remove(pupil);
			}
			else
			{
				_pupils.RemoveAll((Staff x) => x == null);
			}
			_sessionStartTime = GameTime.time;
		}

		public void StartTeacherBehaviour(Staff teacher)
		{
			teacher.SetBehaviour(_trainerBehaviour);
			teacher.BehaviorTree.SetVariable("Room", new RoomRef(_room));
		}

		private void StartPupilBehaviour(Staff pupil)
		{
			pupil.SetBehaviour(_traineeBehaviour);
			pupil.BehaviorTree.SetVariable("Room", new RoomRef(_room));
		}

		private bool IsNearLectern(Staff staff)
		{
			RoomItem roomItem = null;
			float num = float.MaxValue;
			foreach (RoomItem item in _room.FloorPlan.Items)
			{
				float num2 = staff.Position.SquareDistance2D(item.WorldPosition);
				if (num2 < num)
				{
					roomItem = item;
					num = num2;
				}
			}
			if (roomItem != null)
			{
				return roomItem.GetComponent<RoomItemTrainingLecternComponent>() != null;
			}
			return false;
		}

		public RoomItemTrainingLecternComponent GetLecternComponent()
		{
			foreach (RoomItem item in _room.FloorPlan.Items)
			{
				RoomItemTrainingLecternComponent component = item.GetComponent<RoomItemTrainingLecternComponent>();
				if (component != null)
				{
					return component;
				}
			}
			return null;
		}

		private bool CanAddPupils()
		{
			return _pupils.Count < _room.FloorPlan.MaxCapacity;
		}

		public void StartTraining(QualificationDefinition course, Staff teacher, List<Staff> pupils)
		{
			if (!_room.IsOpen)
			{
				_room.Open();
			}
			_qualification = course;
			_sessionStartTime = GameTime.time;
			SetTeacher(teacher);
			foreach (Staff pupil in pupils)
			{
				AddPupil(pupil);
			}
			base.Level.CharacterEvents.OnStaffReadyToStartTraining.InvokeSafe(_teacher, _room);
		}

		private bool TeacherHasArrived()
		{
			if (_teacher is GuestTrainer guestTrainer)
			{
				return guestTrainer.Enabled;
			}
			return true;
		}

		public void CancelTraining()
		{
			CancelSavedSession();
			CancelTraining(success: true);
		}

		private void CancelTraining(bool success)
		{
			if (_teacher != null && !_teacher.HasBeenDestroyed())
			{
				_teacher.Idle();
				_teacher.StopThinkingAboutTraining();
				base.Level.CharacterEvents.OnStaffEndedTraining.InvokeSafe(_teacher);
				if (TeacherHasArrived() && success)
				{
					_teacherFinishing = _teacher;
					_trainerFinishedBehaviourID = _teacher.PushBehaviourTree(_trainerEndBehaviour, pauseWhenPushed: true, restartWhenPopped: false, restartMainBehaviour: true, delegate(CharacterBehaviorTree bt)
					{
						bt.SetVariable("Staff", new CharacterRef(_teacher));
						bt.SetVariable("Room", new RoomRef(_room));
					});
					BindTrainerEndEvent(_teacher, _trainerFinishedBehaviourID);
				}
			}
			while (_pupils.Count != 0)
			{
				RemovePupil(_pupils[0]);
			}
			_teacher = null;
			_qualification = null;
			_droppedTeacherPending = null;
		}

		private void BindTrainerEndEvent(Character character, int behaviourTreeID)
		{
			CharacterBehaviorTree behaviourTree = character.GetBehaviourTreeFromStack(behaviourTreeID);
			CharacterBehaviorTree.FinishedEvent finishedEvent = null;
			finishedEvent = delegate
			{
				CharacterBehaviorTree characterBehaviorTree2 = behaviourTree;
				characterBehaviorTree2.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Remove(characterBehaviorTree2.OnFinishedEvent, finishedEvent);
				character.PopBehaviourTree(behaviourTreeID);
				_teacherFinishing = null;
				_trainerFinishedBehaviourID = 0;
			};
			CharacterBehaviorTree characterBehaviorTree = behaviourTree;
			characterBehaviorTree.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Combine(characterBehaviorTree.OnFinishedEvent, finishedEvent);
		}

		private void ShowLecternStatusIcon(bool show)
		{
			RoomItemTrainingLecternComponent lecternComponent = GetLecternComponent();
			if (lecternComponent == null)
			{
				return;
			}
			RoomItem item = lecternComponent.GetOwner<RoomItem>();
			if (base.Level.StatusIconManager != null)
			{
				if (show)
				{
					base.Level.StatusIconManager.ShowStatusIcon(item, StatusIcon.Type.TrainingLecternQualification);
				}
				else
				{
					base.Level.StatusIconManager.HideStatusIcon(item, StatusIcon.Type.TrainingLecternQualification);
				}
				return;
			}
			Level level = base.Level;
			level.PostConstruct = (Action)Delegate.Combine(level.PostConstruct, (Action)delegate
			{
				if (show)
				{
					base.Level.StatusIconManager.ShowStatusIcon(item, StatusIcon.Type.TrainingLecternQualification);
				}
				else
				{
					base.Level.StatusIconManager.HideStatusIcon(item, StatusIcon.Type.TrainingLecternQualification);
				}
			});
		}

		public bool IsTrainerAssigned(Staff staff)
		{
			if (_teacher == staff)
			{
				return true;
			}
			if (_savedSession != null && _savedSession.Teacher == staff)
			{
				return true;
			}
			return false;
		}
	}
}
