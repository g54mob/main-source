#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.Linq;
using BehaviorDesigner.Runtime;
using I2.Loc;
using TH20.BT_Types;
using UnityEngine;

namespace TH20
{
	public class Staff : Character
	{
		public enum Mode
		{
			Work = 0,
			Break = 1,
			Fired = 2,
			Training = 3,
			Trained = 4,
			Resigned = 5
		}

		private class TakeBreakModeChange : IModeChange
		{
			private readonly Staff _staff;

			private readonly bool _forceOnBreak;

			private readonly Mode _previousMode;

			public TakeBreakModeChange(Staff staff, bool forceOnBreak, Mode previousMode)
			{
				_staff = staff;
				_forceOnBreak = forceOnBreak;
				_previousMode = previousMode;
			}

			public bool Update()
			{
				if (_staff.Interaction != null && !_staff.Interaction.CanInterrupt())
				{
					if (_staff.Definition._type == StaffDefinition.Type.Janitor || _staff.Interaction.ParentRoomItem.Definition.ItemType != RoomItemDefinition.Type.Machine || _staff.RoomUsing == null || _staff.RoomUsing.ArePatientsInRoom())
					{
						return false;
					}
					Logging.Warning(LogChannels.AI, "{0} is interacting with a machine but there's no patients in the room, allowing on break", _staff);
					_staff.Interaction.ParentRoomItem.EndAllInteractions(immediately: true);
				}
				else if (_staff.CurrentJob != null && !_staff.CurrentJob.CanLeave())
				{
					return false;
				}
				if (!_forceOnBreak && !_staff.Level.WorkLifeBalanceManager.CanTakeBreak(_staff))
				{
					_staff.SetCurrentMode(_previousMode);
					_staff.Level.WorkLifeBalanceManager.RequestBreak(_staff);
				}
				else
				{
					_staff.SetCurrentMode(Mode.Break);
					_staff._timeBreakStarted = GameTime.time;
					_staff.Level.StatusIconManager.ShowStatusIcon(_staff, StatusIcon.Type.StaffEnergyLow);
					if (_staff.CurrentJob != null)
					{
						_staff.CurrentJob.Interrupt();
					}
					_staff.SetBehaviour(_staff.Definition._behaviourTakeBreak);
					if (_staff.RoomUsing != null && _staff.RoomUsing.Definition._type == RoomDefinition.Type.StaffRoom)
					{
						_staff.BehaviorTree.SetVariable("StaffRoom", new RoomRef(_staff.RoomUsing));
					}
					_staff.Level.CharacterEvents.OnStaffTakeBreak.InvokeSafe(_staff);
				}
				return true;
			}

			public int Priority()
			{
				return 0;
			}
		}

		private class TrainingModeChange : IModeChange
		{
			private readonly Room _room;

			private readonly Staff _staff;

			public TrainingModeChange(Staff staff, Room room)
			{
				_room = room;
				_staff = staff;
			}

			public bool Update()
			{
				if ((_staff.CurrentJob != null && !_staff.CurrentJob.CanLeave()) || (_staff.Interaction != null && !_staff.Interaction.CanInterrupt()))
				{
					return false;
				}
				if (_staff.CurrentJob != null)
				{
					_staff.CurrentJob.MakeAvailable();
				}
				if (_staff.RoomUsing != _room)
				{
					_staff.GotoRoom(_room, ReasonUseRoom.Work, setByPlayer: false);
				}
				else
				{
					_room.GetComponent<RoomLogicTrainingRoom>().StartTeacherBehaviour(_staff);
				}
				_staff.SetCurrentMode(Mode.Training);
				return true;
			}

			public int Priority()
			{
				return 1;
			}
		}

		private class TrainedModeChange : IModeChange
		{
			private readonly Room _room;

			private readonly Staff _staff;

			public TrainedModeChange(Staff staff, Room room)
			{
				_room = room;
				_staff = staff;
			}

			public bool Update()
			{
				if ((_staff.CurrentJob != null && !_staff.CurrentJob.CanLeave()) || (_staff.Interaction != null && !_staff.Interaction.CanInterrupt()))
				{
					return false;
				}
				if (_staff.CurrentJob != null)
				{
					_staff.CurrentJob.MakeAvailable();
				}
				_staff.SetCurrentMode(Mode.Trained);
				if (_staff.RoomUsing != _room)
				{
					_staff.GotoRoom(_room, ReasonUseRoom.Pleasure, setByPlayer: false);
				}
				return true;
			}

			public int Priority()
			{
				return 1;
			}
		}

		private class FiredModeChange : IModeChange
		{
			private readonly Staff _staff;

			public FiredModeChange(Staff staff)
			{
				_staff = staff;
			}

			public bool Update()
			{
				Room roomUsing = _staff.RoomUsing;
				if (roomUsing == null || _staff.CurrentMode == Mode.Break || roomUsing.CanLeaveWork(_staff))
				{
					Job currentJob = _staff.CurrentJob;
					if (currentJob != null && currentJob.GetStaff() == _staff)
					{
						currentJob.Interrupt();
						currentJob.MakeAvailable();
					}
					_staff.CurrentJob = null;
					_staff.SetCurrentMode(Mode.Fired);
					_staff.LeaveHospital(ReasonForLeavingHospital.Fired);
					return true;
				}
				return false;
			}

			public int Priority()
			{
				return 2;
			}
		}

		private class ResignedModeChange : IModeChange
		{
			private readonly Staff _staff;

			public ResignedModeChange(Staff staff)
			{
				_staff = staff;
			}

			public bool Update()
			{
				Room roomUsing = _staff.RoomUsing;
				if (roomUsing != null && !roomUsing.CanLeaveWork(_staff))
				{
					return false;
				}
				Job currentJob = _staff.CurrentJob;
				if (currentJob != null)
				{
					if (!currentJob.CanLeave())
					{
						return false;
					}
					currentJob.Interrupt();
					currentJob.MakeAvailable();
				}
				_staff.SetCurrentMode(Mode.Resigned);
				_staff.LeaveHospital(ReasonForLeavingHospital.Resigned);
				_staff.Level.StatusIconManager.ShowStatusIcon(_staff, StatusIcon.Type.StaffResigned);
				_staff.Level.Notifications.Send(new NotificationStaff(_staff.Definition.ResignationLetterMessage.Instance, null, _staff));
				List<string> topComplaints = _staff.GetComponent<StaffHappinessComponent>().GetTopComplaints(3, showHidden: false);
				string message = LocalisedString.Replace(ScriptLocalization.Advisor.Staff_Resigned_CS, new SubPair[2]
				{
					new SubPair("{[STAFF]}", GameStringUtils.StaffTitle(_staff)),
					new SubPair("{[COMPLAINTS]}", GameStringUtils.MakeStringFromList(topComplaints))
				});
				_staff.Level.Advisor.PushMessage(new AdvisorMessageDefinition
				{
					Message = message,
					Duration = 10f,
					CameraTrackObject = _staff.GetCameraTrackObject(),
					UserCanDismiss = true
				}, interrupt: true, Advisor.PriorityLevel.High);
				_staff.Level.CharacterEvents.OnStaffResigned.InvokeSafe(_staff);
				return true;
			}

			public int Priority()
			{
				return 3;
			}
		}

		private class GetTrainingLearningSpeedParam
		{
			public float Multiplier;
		}

		private class GetTrainingTeachingSpeedParam
		{
			public float Multiplier;
		}

		private const int ModePriorityBreak = 0;

		private const int ModePriorityTraining = 1;

		private const int ModePriorityTrained = 1;

		private const int ModePriorityFired = 2;

		private const int ModePriorityResigned = 3;

		private const int MinSalary = 0;

		private readonly List<QualificationSlot> _qualifications;

		private LookAtPOI _headLookAtPOI;

		private int _salary;

		private float _timeBreakStarted;

		private NotificationMessage _staffPromotionNotification;

		private NotificationMessage _staffTrainingRequiredNotification;

		private double _lastRankUpTime;

		private List<CharacterModifier> _jobBoostModifiers;

		private bool _femaleAssistantFixedUp;

		private bool _canRepairVehicles;

		private readonly GetTrainingLearningSpeedParam _getTrainingLearningSpeedParam = new GetTrainingLearningSpeedParam();

		private readonly GetTrainingTeachingSpeedParam _getTrainingTeachingSpeedParam = new GetTrainingTeachingSpeedParam();

		public new StaffDefinition Definition { get; private set; }

		public int Rank { get; private set; }

		public bool HasMaxXP
		{
			get
			{
				if (XP != null && RankDefinition != null)
				{
					return XP.Value() >= RankDefinition.MaximumXP;
				}
				return false;
			}
		}

		public bool IsReadyForPromotion { get; private set; }

		public bool IsSatisfiedWithSalary
		{
			get
			{
				switch (GameAlgorithms.CalculatePaySatisfactionLevel(GetDesiredSalaryDifference()))
				{
				case StaffDefinition.Satisfaction.VeryUnhappy:
				case StaffDefinition.Satisfaction.Unhappy:
					return false;
				case StaffDefinition.Satisfaction.Satisfied:
				case StaffDefinition.Satisfaction.Happy:
				case StaffDefinition.Satisfaction.VeryHappy:
					return true;
				default:
					return false;
				}
			}
		}

		public StaffRank RankDefinition
		{
			get
			{
				if (Definition == null || Rank < 0 || Rank >= Definition._rank.Length)
				{
					return null;
				}
				return Definition._rank[Rank];
			}
		}

		public int MaxQualifications => Rank + 1;

		public int NumFreeQualificationSlots => MaxQualifications - _qualifications.Count;

		public bool IsFullyTrained
		{
			get
			{
				foreach (QualificationSlot qualification in _qualifications)
				{
					if (!qualification.IsComplete())
					{
						return false;
					}
				}
				return !HasFreeTrainingSlots;
			}
		}

		public bool HasFreeTrainingSlots => NumFreeQualificationSlots != 0;

		public List<QualificationSlot> Qualifications => _qualifications;

		protected QualificationDefinition TeachingQualification { get; set; }

		private QualificationDefinition LearningQualification { get; set; }

		public AttributeFloat XP { get; private set; }

		public AttributeFloat Energy { get; private set; }

		public Mode CurrentMode { get; private set; }

		public Job CurrentJob { get; set; }

		public StaffRecord StaffRecord { get; private set; }

		public string NameWithTitle
		{
			get
			{
				string titleTermStr = string.Empty;
				switch (Definition._type)
				{
				case StaffDefinition.Type.Doctor:
					titleTermStr = ((base.Gender == Sex.Female) ? "Staff/Title_Doctor_F_CS" : "Staff/Title_Doctor_M_CS");
					break;
				case StaffDefinition.Type.Nurse:
					titleTermStr = ((base.Gender == Sex.Female) ? "Staff/Title_Nurse_F_CS" : "Staff/Title_Nurse_M_CS");
					break;
				}
				return base.CharacterName.GetCharacterName(base.PostFixName, titleTermStr);
			}
		}

		public List<JobDescription> JobExclusions { get; private set; }

		public float SalaryPremiumMultiplier { get; private set; }

		public LocalisedString GuiltTripFlavourText { get; private set; }

		public List<CharacterModifier> JobBoostModifiers => _jobBoostModifiers;

		public bool CanRepairVehicles => _canRepairVehicles;

		public void OnNewHireStaffPickup()
		{
			_attributes.Enabled = false;
		}

		public void OnNewHireStaffHired()
		{
			_attributes.Enabled = true;
		}

		public Staff(JobApplicant applicant, Level level, VisualManager visualManager, int id, Vector3 position, bool navDisabled)
			: base(applicant.Definition, level, visualManager, applicant.Sex, applicant.Name, id, position, navDisabled)
		{
			Definition = applicant.Definition;
			SetBehaviour(Definition._behaviourIdle);
			SetCurrentMode(Mode.Work);
			_qualifications = new List<QualificationSlot>(applicant.Qualifications);
			if (base.ModifiersComponent != null)
			{
				foreach (QualificationSlot qualification in _qualifications)
				{
					base.ModifiersComponent.AddModifiers(qualification.Definition.Modifiers);
				}
			}
			SetCanRepairVehicles();
			base.Traits = applicant.Traits;
			GuiltTripFlavourText = applicant.GuiltTripFlavourText;
			SetRank(applicant.Rank);
			XP.SetValue(applicant.Experience, callCallbacks: false);
			SalaryPremiumMultiplier = ((RankDefinition != null) ? RankDefinition.SalaryPremiumMultiplier : 1f);
			_salary = Mathf.Max(_salary, GetDesiredSalary());
			base.Visual.SetModularAssets(applicant.CharModuleAssets, applicant.SkinMaterial, applicant.EyeMaterial, applicant.HairMeshMaterialBindings);
			Energy = _attributes.GetAttribute(CharacterAttributes.Type.Energy);
			if (Energy != null)
			{
				Energy.LessThan(GameAlgorithms.Config.StaffEnergyLow, TakeBreak, checkCallback: true);
			}
			if (base.Happiness != null)
			{
				base.Happiness.SetValue(applicant.Happiness, callCallbacks: false);
			}
			_headLookAtPOI = new LookAtPOI(GetOrAddComponent<CharacterLookAtPOISourceComponent>(), 6f, 1f);
			level.CharacterLookAtManager.AddGlobalPOI(_headLookAtPOI);
			StaffRecord = new StaffRecord(this);
			JobExclusions = new List<JobDescription>();
			InitializeComponents();
			_lastRankUpTime = _totalTimeInHospital;
			Notifications notifications = base.Level.Notifications;
			notifications.OnNotificationRemoved = (Action<NotificationMessage>)Delegate.Combine(notifications.OnNotificationRemoved, new Action<NotificationMessage>(OnNotificationRemoved));
		}

		protected void SetCurrentMode(Mode mode)
		{
			CurrentMode = mode;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (Rank >= 5)
			{
				Logging.Warning(LogChannels.AI, "Resetting Rank on restore from save, as it is out of range. Rank: {0}, staff: {1}", Rank, this);
				SetRank(4);
			}
			if (XP != null && RankDefinition != null)
			{
				XP.Equals(RankDefinition.MaximumXP, XPMaxReached, checkCallback: false);
			}
			if (Energy != null)
			{
				Energy.LessThan(GameAlgorithms.Config.StaffEnergyLow, TakeBreak, checkCallback: false);
			}
			Notifications notifications = base.Level.Notifications;
			notifications.OnNotificationRemoved = (Action<NotificationMessage>)Delegate.Combine(notifications.OnNotificationRemoved, new Action<NotificationMessage>(OnNotificationRemoved));
			_headLookAtPOI.RestoreFromSave(base.Level.EntityManager);
			StaffPickedUpState component = GetComponent<StaffPickedUpState>();
			if (component != null)
			{
				Level level = base.Level;
				level.PostConstruct = (Action)Delegate.Combine(level.PostConstruct, new Action(component.AbortPickup));
			}
			Level level2 = base.Level;
			level2.PostConstruct = (Action)Delegate.Combine(level2.PostConstruct, new Action(CheckForStuckAmbulanceStaff));
			DLCItemDefinition dLCItemDefinition = base.Visual.CustomisationOption?.DlcPackRequired?.Instance;
			if (dLCItemDefinition != null && (!DLCUtils.IsDLCOwned(dLCItemDefinition) || !DLCUtils.IsDLCInstalled(dLCItemDefinition)))
			{
				base.Visual.SetCustomisationOption(base.Level.CharacterManager.GetDefaultSaffCustomisationOption(Definition._type), this);
			}
		}

		private void CheckForStuckAmbulanceStaff()
		{
			bool flag = Math.Abs(base.Position.y - CharacterManager.AmbulancePatientSpawnLocation.y) < 0.01f;
			bool flag2 = GetComponent<DisableSelectionComponent>() != null && GetComponent<DisableHighlightComponent>() != null;
			JobAmbulance jobAmbulance = CurrentJob as JobAmbulance;
			bool flag3 = jobAmbulance != null;
			if (jobAmbulance != null)
			{
				foreach (JobAmbulance currentlyUnassignedJob in jobAmbulance.Ambulance.CurrentlyUnassignedJobs)
				{
					if (flag && currentlyUnassignedJob.IsAssigned(this))
					{
						Reset(includeJob: true);
					}
				}
			}
			if (flag && !flag3)
			{
				Reset(includeJob: false);
			}
			if (!flag && flag2)
			{
				Reset(includeJob: false);
				jobAmbulance?.StartJob(this);
			}
			if (flag3 && jobAmbulance.Ambulance.CurrentState == Ambulance.State.Idle)
			{
				Reset(includeJob: true);
			}
			void Reset(bool includeJob)
			{
				RemoveComponents<DisableSelectionComponent>();
				RemoveComponents<DisableHighlightComponent>();
				RemoveComponents<DisableStatusIconComponent>();
				base.Visual.SetRendererActive(active: true);
				base.Position = Vector3.zero;
				if (includeJob)
				{
					(CurrentJob as JobAmbulance).JobDone(this, success: true);
					base.Level.StaffWorkScheduler.RemoveJob(CurrentJob as JobAmbulance, complete: true);
					SetBehaviour(Definition._behaviourIdle);
					EnableBehaviour(enabled: true);
				}
				base.NavPath.PutBackInNavWorld();
			}
		}

		public void SetRank(int rank)
		{
			if (rank < 0 || rank >= 5)
			{
				Logging.Warning(LogChannels.AI, "Trying to set invalid rank {0} on {1}", rank, this);
			}
			else
			{
				Rank = rank;
				InitialiseXP();
				IsReadyForPromotion = false;
				base.NavPath.SetMaxSpeed(GetMaxMovementSpeed());
			}
		}

		private void InitialiseXP()
		{
			if (XP != null)
			{
				_attributes.Remove(CharacterAttributes.Type.XP);
			}
			XP = new AttributeFloat(0f, 0f, (RankDefinition != null) ? RankDefinition.MaximumXP : 0f);
			XP.Equals((RankDefinition != null) ? RankDefinition.MaximumXP : 0f, XPMaxReached, checkCallback: true);
			_attributes.Add(CharacterAttributes.Type.XP, XP);
		}

		protected override void SetBehaviourVariables(CharacterBehaviorTree behaviorTree)
		{
			base.SetBehaviourVariables(behaviorTree);
			behaviorTree.SetVariable("Staff", new StaffRef(this));
		}

		public override void DebugGUI()
		{
			base.DebugGUI();
			if (!base.ShowDebugInfo)
			{
				return;
			}
			GUIStyle gUIStyle = new GUIStyle(GUI.skin.box)
			{
				richText = true
			};
			Vector3 position = base.Position + Vector3.up * 2f;
			Vector3 vector = Camera.main.WorldToScreenPoint(position);
			string empty = string.Empty;
			empty = empty + "Name: " + base.Name;
			empty = empty + "\nRank: " + Rank;
			empty = empty + "  Salary: " + GetSalary() + " (" + GetDesiredSalary() + ")";
			empty = empty + "\nMode: " + CurrentMode.ToString() + "   State: " + GetState();
			empty = empty + "  Job: " + ((CurrentJob != null) ? CurrentJob.DescriptionDoing(base.Gender) : "None");
			empty = empty + "\nGoing to: " + base.GoingToRoom;
			empty = empty + "\nUsing: " + base.RoomUsing;
			empty = empty + "\nTemperature: " + base.TemperatureValue;
			empty = empty + "  Attractiveness: " + base.AttractivenessValue;
			empty = empty + "\n" + _attributes;
			StaffHappinessComponent component = GetComponent<StaffHappinessComponent>();
			if (component != null)
			{
				empty = empty + "\n\n" + component.GetAsDebugString();
			}
			if (base.ModifiersComponent != null)
			{
				empty += base.ModifiersComponent.DebuggerDisplay();
			}
			empty = empty + "\n" + ((base.BehaviorTree != null) ? base.BehaviorTree.ToString() : "No behaviour!");
			if (base.Animator != null)
			{
				AnimatorClipInfo[] currentAnimatorClipInfo = base.Animator.GetCurrentAnimatorClipInfo(0);
				foreach (AnimatorClipInfo animatorClipInfo in currentAnimatorClipInfo)
				{
					empty += $"\nAnimation Clip: {animatorClipInfo.clip.name}";
				}
			}
			Vector2 vector2 = gUIStyle.CalcSize(new GUIContent(empty));
			GUI.Box(new Rect(vector.x - vector2.x / 2f, (float)Screen.height - vector.y - vector2.y, vector2.x, vector2.y), empty, gUIStyle);
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			UpdateEnergy(deltaTime);
			CacheJobBoostModifiers();
			LeaveIfRequired();
		}

		private void CacheJobBoostModifiers()
		{
			if (JobBoostModifiers == null)
			{
				_jobBoostModifiers = new List<CharacterModifier>();
			}
			_jobBoostModifiers.Clear();
			if (base.ModifiersComponent == null)
			{
				return;
			}
			foreach (CharacterModifier modifier in base.ModifiersComponent.Modifiers)
			{
				if (modifier is QualificationJobRoomScoreBoost || modifier is QualificationJobMaintenanceScoreBoost)
				{
					_jobBoostModifiers.Add(modifier);
				}
			}
		}

		private void UpdateEnergy(float deltaTime)
		{
			if (Energy != null)
			{
				Room roomUsing = base.RoomUsing;
				if (roomUsing != null)
				{
					float staffEnergyModifier = roomUsing.Definition.GetStaffEnergyModifier(this, roomUsing);
					Energy.Modify(staffEnergyModifier * deltaTime, GetAttributeMultiplier(CharacterAttributes.Type.Energy));
				}
			}
		}

		private void LeaveIfRequired()
		{
			if ((CurrentMode == Mode.Fired || CurrentMode == Mode.Resigned) && base.CurrentBehaviour == Definition._behaviourIdle)
			{
				SetBehaviour(Definition._behaviourLeaveHospital);
			}
		}

		public override void Idle()
		{
			if (HasBeenFired() || HasResigned())
			{
				return;
			}
			base.Idle();
			Job currentJob = CurrentJob;
			if (currentJob != null)
			{
				currentJob.Interrupt();
				currentJob.MakeAvailable();
				if (base.Interaction != null)
				{
					base.Interaction.EndInteraction(this);
				}
			}
			if (base.Level.StatusIconManager != null)
			{
				base.Level.StatusIconManager.DestroyStatusIcon(this);
			}
			bool num = CurrentMode == Mode.Break;
			SetCurrentMode(Mode.Work);
			if (Energy != null && Energy.Value() < GameAlgorithms.Config.StaffEnergyLow)
			{
				TakeBreak();
			}
			if (num)
			{
				base.Level.CharacterEvents.OnStaffIdle.InvokeSafe(this);
			}
		}

		public void StartWork(Job job)
		{
			CurrentJob = job;
			if (CurrentMode == Mode.Break)
			{
				base.Level.StatusIconManager.DestroyStatusIcon(this);
			}
			SetCurrentMode(Mode.Work);
		}

		public override bool ShouldBehaviourAllowExitingOfRoom(Room roomExiting)
		{
			bool result = true;
			if (IsModeChangeActive<TakeBreakModeChange>() && base.RoomUsing != null && base.RoomUsing.Definition._type == RoomDefinition.Type.StaffRoom && !(CurrentJob is JobFire))
			{
				result = false;
			}
			return result;
		}

		public void TakeBreak()
		{
			TakeBreak(forceOnBreak: false);
		}

		public void ForceOnBreak()
		{
			if (CurrentMode == Mode.Break && BehaviorTreeEnabled)
			{
				BehaviorManager.instance.RestartBehavior(base.BehaviorTree);
			}
			else
			{
				TakeBreak(forceOnBreak: true);
			}
		}

		private void TakeBreak(bool forceOnBreak)
		{
			if (CurrentMode == Mode.Work)
			{
				ChangeMode(new TakeBreakModeChange(this, forceOnBreak, CurrentMode));
			}
		}

		public bool IsRequestingABreak()
		{
			return IsModeChangeActive<TakeBreakModeChange>();
		}

		public bool IsFitForWork()
		{
			if (IsThinkingAboutTraining() || IsthinkingAboutBeingTrained())
			{
				return false;
			}
			if (GetComponent<TeleportCharacterComponent>() != null)
			{
				return false;
			}
			if (GetComponent<StaffFailedToStartJobComponent>() != null)
			{
				return false;
			}
			bool flag = CurrentMode == Mode.Break && BreakTimeOver();
			if (base.SatisfyingNeed && flag && (base.Interaction == null || base.Interaction.IsInQueue(this)))
			{
				return true;
			}
			if (!base.Interruptable || base.SatisfyingNeed)
			{
				return false;
			}
			if (CurrentMode == Mode.Work)
			{
				return true;
			}
			if (flag)
			{
				return true;
			}
			return false;
		}

		private float GetBreakLength()
		{
			return base.Level.WorkLifeBalanceManager.GetBreakDuration(Definition._type, Rank);
		}

		private bool BreakTimeOver()
		{
			return GameTime.time - _timeBreakStarted > GetBreakLength();
		}

		private float TimeRemainingOnBreak()
		{
			if (CurrentMode != Mode.Break)
			{
				return 0f;
			}
			float num = GetBreakLength() - (GameTime.time - _timeBreakStarted);
			if (!(num < 0f))
			{
				return num;
			}
			return 0f;
		}

		public virtual bool StartTraining(QualificationDefinition qualification, Room room)
		{
			if (CurrentMode != Mode.Training && ChangeMode(new TrainingModeChange(this, room)) && TeachingQualification != qualification)
			{
				TeachingQualification = qualification;
				return true;
			}
			return false;
		}

		public bool StartBeingTrained(QualificationDefinition qualification, Room room)
		{
			if (CurrentMode != Mode.Trained && ChangeMode(new TrainedModeChange(this, room)) && LearningQualification != qualification)
			{
				LearningQualification = qualification;
				if (_qualifications.All((QualificationSlot slot) => slot.Definition != qualification))
				{
					QualificationSlot qualificationSlot = ((_qualifications.Count == 0) ? null : _qualifications[_qualifications.Count - 1]);
					if (qualificationSlot != null && !qualificationSlot.IsComplete())
					{
						_qualifications[_qualifications.Count - 1] = new QualificationSlot(qualification, complete: false);
					}
					else
					{
						_qualifications.Add(new QualificationSlot(qualification, complete: false));
					}
					SetCanRepairVehicles();
				}
				return true;
			}
			return false;
		}

		public void Debug_AssignQualification(QualificationDefinition qualification)
		{
			if (_qualifications.All((QualificationSlot slot) => slot.Definition != qualification))
			{
				_qualifications.Add(new QualificationSlot(qualification, complete: true));
				if (base.ModifiersComponent != null)
				{
					base.ModifiersComponent.AddModifiers(qualification.Modifiers);
				}
			}
		}

		public void Debug_RemoveQualifications()
		{
			if (base.ModifiersComponent != null)
			{
				foreach (QualificationSlot qualification in _qualifications)
				{
					base.ModifiersComponent.RemoveModifiers(qualification.Definition.Modifiers);
				}
			}
			_qualifications.Clear();
		}

		public void Debug_ForceRequiresTraining()
		{
			Debug_RemoveQualifications();
			InitialiseXP();
			if (RankDefinition != null)
			{
				XP.SetValue(RankDefinition.MaximumXP, callCallbacks: false);
				XP.Equals(RankDefinition.MaximumXP, XPMaxReached, checkCallback: true);
			}
		}

		public void Debug_MarkForPromotion()
		{
			ReadyForPromotion();
		}

		public void Debug_SetGuiltTrip(LocalisedString newGuiltTrip)
		{
			GuiltTripFlavourText = newGuiltTrip;
		}

		public override bool IsSelectable()
		{
			if (HasBeenFired() || HasResigned())
			{
				return false;
			}
			return base.IsSelectable();
		}

		public override bool CanDragHoldSelect()
		{
			if (IsSelectable())
			{
				return CanPickup();
			}
			return false;
		}

		protected override void OnRoomBecameInvalid(Room room)
		{
			if (base.QueuingAtRoom == room)
			{
				LeaveQueue();
			}
			if (base.RoomUsing == room || (CurrentJob != null && CurrentJob.IsInRoom(room)) || base.GoingToRoom == room)
			{
				room.RemoveFromQueue(this);
				Idle();
			}
		}

		public void Fire()
		{
			if (CurrentMode != Mode.Fired && ChangeMode(new FiredModeChange(this)))
			{
				_attributes.Enabled = false;
			}
		}

		public void Resign()
		{
			if (CurrentMode != Mode.Resigned && ChangeMode(new ResignedModeChange(this)))
			{
				_attributes.Enabled = false;
			}
		}

		public RuntimeAnimatorController GetPickedUpAnimGraph()
		{
			if (!IsMale())
			{
				return Definition._pickedUpAnimGraph[1];
			}
			return Definition._pickedUpAnimGraph[0];
		}

		public override WalkAnimation GetWalkAnim()
		{
			if (base.ModifiersComponent != null && base.ModifiersComponent.HasModifierOfType<CharacterModifierMovementSpeed>())
			{
				return WalkAnimation.Normal;
			}
			if (CurrentMode == Mode.Fired || CurrentMode == Mode.Resigned)
			{
				return WalkAnimation.Angry;
			}
			if (CurrentMode == Mode.Work && CurrentJob != null && CurrentJob.IsInRoom(base.RoomUsing))
			{
				return WalkAnimation.Normal;
			}
			return base.GetWalkAnim();
		}

		public int GetSalary()
		{
			return Mathf.Max(0, _salary);
		}

		public void SetSalary(int salary, bool silent)
		{
			_salary = Mathf.Max(0, salary);
			if (!silent)
			{
				base.Level.CharacterEvents.OnStaffSalaryChanged.InvokeSafe(this, _salary);
			}
		}

		public int GetDesiredSalary()
		{
			return Mathf.Max(0, GameAlgorithms.CalculateDesiredSalary(Definition, Rank, XP.Value(), Qualifications, base.Traits, SalaryPremiumMultiplier));
		}

		public float GetDesiredSalaryDifference(int salary)
		{
			int desiredSalary = GetDesiredSalary();
			return (float)(salary - desiredSalary) / (float)desiredSalary;
		}

		public float GetDesiredSalaryDifference()
		{
			int salary = GetSalary();
			int desiredSalary = GetDesiredSalary();
			return (float)(salary - desiredSalary) / (float)desiredSalary;
		}

		private void OnNotificationRemoved(NotificationMessage notificationMessage)
		{
			if (notificationMessage == _staffTrainingRequiredNotification)
			{
				_staffTrainingRequiredNotification = null;
			}
			if (notificationMessage == _staffPromotionNotification)
			{
				_staffPromotionNotification = null;
			}
		}

		private void XPMaxReached()
		{
			if (Rank < 4)
			{
				double param = _totalTimeInHospital - _lastRankUpTime;
				base.Level.CharacterEvents.OnStaffReachedMaxXP.InvokeSafe(this, param);
				_lastRankUpTime = _totalTimeInHospital;
				if (IsFullyTrained)
				{
					ReadyForPromotion();
				}
				else if (base.Level.Metagame.HasUnlockedRoomOfType(RoomDefinition.Type.Training) && _staffTrainingRequiredNotification == null && CurrentMode != Mode.Trained && base.Level.HospitalPolicy.StaffTrainingRequests)
				{
					_staffTrainingRequiredNotification = new NotificationStaffTrainingRequired(base.Level.Notifications.MessageDefinitions._staffTrainingRequiredMessage, this);
					base.Level.Notifications.Send(_staffTrainingRequiredNotification);
				}
			}
		}

		public void AutoPromote()
		{
			if (HasMaxXP && IsFullyTrained && Rank < 4)
			{
				LocalisedString titleLocalised = RankDefinition.GetTitleLocalised(base.Gender);
				int a = GameAlgorithms.CalculateDesiredSalary(Definition, Rank + 1, 0f, Qualifications, base.Traits, SalaryPremiumMultiplier);
				IsReadyForPromotion = true;
				Promote(Mathf.Max(a, GetSalary()));
				LocalisedString titleLocalised2 = RankDefinition.GetTitleLocalised(base.Gender);
				string message = LocalisedString.Replace(ScriptLocalization.Advisor.Staff_Promoted_CS, new SubPair[3]
				{
					new SubPair("{[NAME]}", base.Name),
					new SubPair("{[OLDTITLE]}", titleLocalised.Translation),
					new SubPair("{[NEWTITLE]}", titleLocalised2.Translation)
				});
				base.Level.Advisor.PushMessage(new AdvisorMessageDefinition
				{
					Message = message,
					Duration = 10f,
					UserCanDismiss = true
				}, interrupt: false, Advisor.PriorityLevel.Medium);
			}
		}

		public void ReadyForPromotion()
		{
			if (Rank < 4 && !IsReadyForPromotion)
			{
				_staffTrainingRequiredNotification = null;
				if (base.Level.HospitalPolicy.StaffPromotion)
				{
					AutoPromote();
					return;
				}
				ShowReadyForPromotionMessage(immediately: false);
				IsReadyForPromotion = true;
				base.Level.CharacterEvents.OnStaffReadyForPromotion.InvokeSafe(this);
			}
		}

		public void ShowReadyForPromotionMessage(bool immediately)
		{
			if (Rank < 4)
			{
				if (_staffPromotionNotification == null)
				{
					_staffPromotionNotification = new NotificationStaffPromotion(base.Level.Notifications.MessageDefinitions._staffPromotionMessage, this);
					base.Level.Notifications.Send(_staffPromotionNotification);
				}
				if (immediately)
				{
					base.Level.Notifications.Open(_staffPromotionNotification);
				}
			}
		}

		public void Promote(int newSalary)
		{
			if (IsReadyForPromotion)
			{
				_staffPromotionNotification = null;
				_staffTrainingRequiredNotification = null;
				if (Definition.PromotedStatusEffect != null && base.ModifiersComponent != null)
				{
					base.ModifiersComponent.AddStatusEffect(Definition.PromotedStatusEffect.Instance);
				}
				if (base.Happiness != null)
				{
					base.Happiness.Modify(Definition.HappinessPromotion, 1f);
				}
				SetRank(Rank + 1);
				SetSalary(newSalary, silent: false);
				base.Level.CharacterEvents.OnStaffPromoted.InvokeSafe(this);
				if (Rank >= 4 && GetComponent<RoderickCushionCharacterComponent>() != null)
				{
					PlatformStatsAndAchievements.TriggerAchievement(AchievementId.TrainRoderick);
				}
			}
			else
			{
				Logging.Error(LogChannels.AI, "{0} isn't ready for a promotion!", this);
			}
		}

		public virtual string GetStatusText()
		{
			string text = "";
			if (HasBeenFired())
			{
				text = ((base.Gender == Sex.Male) ? ScriptLocalization.Staff.Status_Fired_CS_M : ScriptLocalization.Staff.Status_Fired_CS_F);
			}
			else if (HasResigned())
			{
				text = ((base.Gender == Sex.Male) ? ScriptLocalization.Staff.Status_Resigned_CS_M : ScriptLocalization.Staff.Status_Resigned_CS_F);
			}
			else
			{
				if (CurrentMode == Mode.Break || IsRequestingABreak())
				{
					text = ((base.Gender == Sex.Male) ? ScriptLocalization.Staff.Status_OnBreakOnCall_CS_M : ScriptLocalization.Staff.Status_OnBreakOnCall_CS_F);
					if (!IsFitForWork())
					{
						int numberOfDays = (int)(TimeRemainingOnBreak() / GameAlgorithms.Config.SecondsPerDay) + 1;
						text = $"{((base.Gender == Sex.Male) ? ScriptLocalization.Staff.Status_OnBreak_CS_M : ScriptLocalization.Staff.Status_OnBreak_CS_F)} ({GameStringUtils.GetDaysString(numberOfDays)})";
					}
				}
				else
				{
					switch (CurrentMode)
					{
					case Mode.Work:
						text = ((base.Gender == Sex.Male) ? ScriptLocalization.Staff.Status_LookingForWork_CS_M : ScriptLocalization.Staff.Status_LookingForWork_CS_F);
						if (CurrentJob != null)
						{
							text = CurrentJob.DescriptionDoing(base.Gender);
						}
						break;
					case Mode.Training:
						if (TeachingQualification == null)
						{
							text = ((base.Gender == Sex.Male) ? ScriptLocalization.Staff.Status_TrainingNoCourse_CS_M : ScriptLocalization.Staff.Status_TrainingNoCourse_CS_F);
							break;
						}
						text = ((base.Gender == Sex.Male) ? ScriptLocalization.Staff.Status_Training_CS_M : ScriptLocalization.Staff.Status_Training_CS_F);
						text = text.Replace("{[QUALIFICATION]}", TeachingQualification.NameLocalised.Translation);
						break;
					case Mode.Trained:
					{
						QualificationSlot qualificationSlot = GetQualificationSlot(LearningQualification);
						text = ((base.Gender == Sex.Male) ? ScriptLocalization.Staff.Status_Trained_CS_M : ScriptLocalization.Staff.Status_Trained_CS_F);
						text = text.Replace("{[QUALIFICATION]}", LearningQualification.NameLocalised.Translation);
						text = text.Replace("{[PERCENT]}", StringUtils.FormatPercentageValue(qualificationSlot?.FractionComplete ?? 0f));
						break;
					}
					}
				}
				if (text.IsNullOrEmpty() && base.GoingToRoom != null)
				{
					text = ((base.Gender == Sex.Male) ? ScriptLocalization.Staff.Status_GoingToRoom_CS_M : ScriptLocalization.Staff.Status_GoingToRoom_CS_F);
					text = text.Replace("{[ROOM]}", base.GoingToRoom.GetRoomName());
				}
			}
			return text;
		}

		public virtual Sprite GetStatusSprite()
		{
			Sprite result = null;
			if (HasBeenFired())
			{
				result = Definition.FiredIcon;
			}
			else if (HasResigned())
			{
				result = Definition.ResignedIcon;
			}
			else
			{
				switch (CurrentMode)
				{
				case Mode.Break:
					result = (IsFitForWork() ? Definition.OnBreakOnCallIcon : Definition.OnBreakIcon);
					break;
				case Mode.Work:
					result = ((CurrentJob == null) ? Definition.LookingForWorkIcon : CurrentJob.Icon());
					break;
				case Mode.Training:
					if (TeachingQualification != null)
					{
						result = Definition.TrainingRoomIcon;
					}
					break;
				case Mode.Trained:
					if (LearningQualification != null)
					{
						result = Definition.TrainingRoomIcon;
					}
					break;
				}
			}
			return result;
		}

		private float SumModifierMultiplier<T>(Room room, float baseMultiplier) where T : QualificationBaseModifier
		{
			float num = baseMultiplier;
			if (base.ModifiersComponent != null)
			{
				foreach (CharacterModifier modifier in base.ModifiersComponent.Modifiers)
				{
					if (modifier is T val)
					{
						num += val.Calculate(room);
					}
				}
			}
			return num;
		}

		public float GetDiagnosisMultiplier(Room room)
		{
			return SumModifierMultiplier<QualificationDiagnosisModifier>(room, RankDefinition.DiagnosisCertaintyMultiplier);
		}

		public float GetTreatmentSkillRating(Room room)
		{
			return SumModifierMultiplier<QualificationTreatmentModifier>(room, RankDefinition.TreatmentSkillRating);
		}

		public float GetResearchRate(Room room)
		{
			return SumModifierMultiplier<QualificationResearchModifier>(room, RankDefinition.ResearchRate);
		}

		public float GetMarketingSkill(Room room)
		{
			return SumModifierMultiplier<QualificationMarketModifier>(room, RankDefinition.MarketingSkill);
		}

		public float GetUpgradeItemMultiplier(Room room)
		{
			return SumModifierMultiplier<QualificationUpgradeItemModifier>(room, RankDefinition.UpgradeItemSkill);
		}

		public float GetMaintenanceMultiplier(Room room)
		{
			return SumModifierMultiplier<QualificationMaintenanceModifier>(room, RankDefinition.MaintenanceSkill);
		}

		public float GetServiceMultiplier(Room room)
		{
			return SumModifierMultiplier<QualificationServiceModifier>(room, RankDefinition.ServiceSkill);
		}

		public float GetDurationReduction(Room room)
		{
			return SumModifierMultiplier<QualificationDurationModifier>(room, 0f);
		}

		public bool IncreaseLearning(QualificationDefinition definition, float points)
		{
			foreach (QualificationSlot qualification in _qualifications)
			{
				if (qualification.Definition == definition && qualification.AddPoints(points))
				{
					if (base.Happiness != null)
					{
						base.Happiness.Modify(Definition.HappinessQualification, 1f);
					}
					if (base.ModifiersComponent != null)
					{
						base.ModifiersComponent.AddModifiers(qualification.Definition.Modifiers);
					}
					string text = ScriptLocalization.Notification.QualificationLearned_CS.Replace("{[QUALIFICATION]}", qualification.Definition.NameLocalised.Translation);
					base.Level.InWorldMessages.ShowMessage(text, base.Position, 3f, InWorldMessages.MessageType.Info);
					return true;
				}
			}
			return false;
		}

		public bool HasCompletedQualification(QualificationDefinition definition)
		{
			return definition.HasCompletedQualification(_qualifications);
		}

		public bool HasQualifications()
		{
			foreach (QualificationSlot qualification in _qualifications)
			{
				if (qualification.IsComplete())
				{
					return true;
				}
			}
			return false;
		}

		public void IterateCompleteQualifications(Action<QualificationSlot> callback)
		{
			foreach (QualificationSlot qualification in _qualifications)
			{
				if (qualification.IsComplete())
				{
					callback(qualification);
				}
			}
		}

		public QualificationSlot GetQualificationSlot(QualificationDefinition qualification)
		{
			foreach (QualificationSlot qualification2 in _qualifications)
			{
				if (qualification2.Definition == qualification)
				{
					return qualification2;
				}
			}
			return null;
		}

		public override bool CanSatisfyNeeds()
		{
			if (base.CanSatisfyNeeds())
			{
				if (CurrentMode == Mode.Break)
				{
					return true;
				}
				if (IsIdleInWorkRoom())
				{
					return true;
				}
			}
			return false;
		}

		public bool IsIdleInWorkRoom()
		{
			if (CurrentMode == Mode.Work && CurrentJob != null && CurrentJob is JobRoom && CurrentJob.IsInRoom(base.RoomUsing) && !base.RoomUsing.Definition._disallowStaffNeeds && !CurrentJob.IsReadyForWork())
			{
				return true;
			}
			return false;
		}

		protected override string GetInteractionPostfix()
		{
			string text = string.Empty;
			if (Definition != null && !string.IsNullOrEmpty(Definition._animGraphPostfixOverride))
			{
				text += Definition._animGraphPostfixOverride;
			}
			return text + base.GetInteractionPostfix();
		}

		public override StatusIcon.Type GetStatusIcon()
		{
			if (Energy != null && Energy.Value() < GameAlgorithms.Config.StaffEnergyLow)
			{
				return StatusIcon.Type.StaffEnergyLow;
			}
			return base.GetStatusIcon();
		}

		public override void Destroy()
		{
			base.Destroy();
			base.Level.CharacterLookAtManager.RemoveGlobalPOI(_headLookAtPOI);
			StaffRecord.Destroy();
			Notifications notifications = base.Level.Notifications;
			notifications.OnNotificationRemoved = (Action<NotificationMessage>)Delegate.Remove(notifications.OnNotificationRemoved, new Action<NotificationMessage>(OnNotificationRemoved));
		}

		public override float GetMaxMovementSpeed()
		{
			float num = base.GetMaxMovementSpeed();
			if (RankDefinition != null)
			{
				num *= RankDefinition.WalkSpeedMultiplier;
			}
			return num;
		}

		public float GetTrainingLearningSpeed()
		{
			_getTrainingLearningSpeedParam.Multiplier = 1f;
			if (base.ModifiersComponent != null)
			{
				base.ModifiersComponent.IterateModifiersOfType(_getTrainingLearningSpeedParam, delegate(GetTrainingLearningSpeedParam param, CharacterModifierTrainingLearningMultiplier modifier)
				{
					param.Multiplier += modifier.Modifier;
				});
			}
			if (RankDefinition != null)
			{
				return RankDefinition.TraineeLearningSpeed * Mathf.Max(_getTrainingLearningSpeedParam.Multiplier, 0f);
			}
			return 0f;
		}

		public float GetTrainingTeachingSpeed()
		{
			_getTrainingTeachingSpeedParam.Multiplier = 1f;
			if (base.ModifiersComponent != null)
			{
				base.ModifiersComponent.IterateModifiersOfType(_getTrainingTeachingSpeedParam, delegate(GetTrainingTeachingSpeedParam param, CharacterModifierTrainingTeachingMultiplier modifier)
				{
					param.Multiplier += modifier.Modifier;
				});
			}
			if (RankDefinition != null)
			{
				return RankDefinition.TrainingMultiplier * Mathf.Max(_getTrainingTeachingSpeedParam.Multiplier, 0f);
			}
			return 0f;
		}

		public bool IsJobExcluded(Job job)
		{
			if (GetComponent<StaffPickedUpState>() == null)
			{
				foreach (JobDescription jobExclusion in JobExclusions)
				{
					if (jobExclusion.MatchesJob(job))
					{
						return true;
					}
				}
			}
			if (Definition.IsUniqueVehicularMechanic && !job.IsVehicular())
			{
				return true;
			}
			return false;
		}

		public bool CanPickup()
		{
			if (!HasBeenFired() && !HasResigned() && !HasEmbarkedAmbulance() && base.InteractionInterruptable)
			{
				return GetComponent<TeleportCharacterComponent>() == null;
			}
			return false;
		}

		public bool HasBeenFired()
		{
			if (CurrentMode != Mode.Fired)
			{
				return IsModeChangeActive<FiredModeChange>();
			}
			return true;
		}

		public bool HasResigned()
		{
			if (CurrentMode != Mode.Resigned)
			{
				return IsModeChangeActive<ResignedModeChange>();
			}
			return true;
		}

		public bool HasEmbarkedAmbulance()
		{
			if (CurrentJob is JobAmbulance jobAmbulance)
			{
				return jobAmbulance.Ambulance.IsActive;
			}
			return false;
		}

		public bool CanCallPeopleIntoRoom()
		{
			if (GetActiveModeChange() != null)
			{
				return false;
			}
			if (CurrentJob != null && !CurrentJob.IsSuitable(this, checkExclusion: true, out var _))
			{
				return false;
			}
			if (!HasResigned() && !IsRequestingABreak() && !HasBeenFired())
			{
				return !base.SatisfyingNeed;
			}
			return false;
		}

		public bool ShouldIdleWhenDroppedInRoom(Room room)
		{
			RoomLogic component = room.GetComponent<RoomLogic>();
			if (component != null && !component.ShouldIdleWhenDroppedInRoom(this))
			{
				return false;
			}
			if ((CurrentMode == Mode.Trained || CurrentMode == Mode.Training) && room.Definition.IsHospitalOrBay)
			{
				return false;
			}
			return true;
		}

		public float GetMovementSpeedPercentage()
		{
			return 1f + (base.GetMaxMovementSpeed() - Definition._maxSpeed) / Definition._maxSpeed;
		}

		public bool IsThinkingAboutTraining()
		{
			if (CurrentMode != Mode.Training)
			{
				return IsModeChangeActive<TrainingModeChange>();
			}
			return true;
		}

		public bool IsthinkingAboutBeingTrained()
		{
			if (CurrentMode != Mode.Trained)
			{
				return IsModeChangeActive<TrainedModeChange>();
			}
			return true;
		}

		public void StopThinkingAboutTraining()
		{
			if (IsModeChangeActive<TrainedModeChange>() || IsModeChangeActive<TrainingModeChange>())
			{
				CancelModeChange();
			}
		}

		public override void FixupMissingBehaviour()
		{
			base.FixupMissingBehaviour();
			switch (CurrentMode)
			{
			case Mode.Work:
			{
				if (CurrentJob == null)
				{
					Idle();
					break;
				}
				Job currentJob = CurrentJob;
				currentJob.MakeAvailable();
				currentJob.StartJob(this);
				break;
			}
			case Mode.Break:
				CurrentMode = Mode.Work;
				TakeBreak(forceOnBreak: true);
				break;
			case Mode.Fired:
				CurrentMode = Mode.Work;
				Fire();
				break;
			case Mode.Training:
				CurrentMode = Mode.Work;
				StartTraining(LearningQualification, (base.GoingToRoom != null) ? base.GoingToRoom : base.RoomUsing);
				break;
			case Mode.Trained:
				CurrentMode = Mode.Work;
				StartBeingTrained(LearningQualification, (base.GoingToRoom != null) ? base.GoingToRoom : base.RoomUsing);
				break;
			case Mode.Resigned:
				CurrentMode = Mode.Work;
				Resign();
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		public bool IsRoboJanitor()
		{
			return GetComponent<RoboJanitorComponent>() != null;
		}

		public bool IsReadyForTraining()
		{
			if (!IsThinkingAboutTraining() && !IsthinkingAboutBeingTrained())
			{
				return !IsRoboJanitor();
			}
			return false;
		}

		public override void OnCharacterAttributeModified(CharacterAttributes.Type modifierType)
		{
			base.Level.CharacterEvents.OnStaffAttributeModified.InvokeSafe(this, modifierType);
		}

		public override void OnCharacterUsedItem(RoomItem item)
		{
			base.Level.CharacterEvents.OnStaffUsedItem.InvokeSafe(this, item);
		}

		public override void RegenerateVisualIfNeeded()
		{
			if (base.Gender == Sex.Female && Definition._type == StaffDefinition.Type.Assistant && !_femaleAssistantFixedUp)
			{
				List<CharModule.CharModuleAssets> list = new List<CharModule.CharModuleAssets>(CharModule.CharModuleAssets.InitListCapicity);
				Definition.RootModule.GetRandomCharacterData(Definition.GetModularCategory(base.Gender), base.Visual.EyeMaterial, base.Visual.SkinToneMaterial, base.Visual.HairMeshMaterialBindings, list);
				base.Visual.SetModularAssets(list, base.Visual.SkinToneMaterial, base.Visual.EyeMaterial, base.Visual.HairMeshMaterialBindings);
				_femaleAssistantFixedUp = true;
			}
		}

		public void SetCanRepairVehicles()
		{
			foreach (QualificationSlot qualification in _qualifications)
			{
				CharacterModifier[] modifiers = qualification.Definition.Modifiers;
				for (int i = 0; i < modifiers.Length; i++)
				{
					if (modifiers[i] is QualificationVehicleMaintenanceOnly)
					{
						_canRepairVehicles = true;
						return;
					}
				}
			}
		}
	}
}
