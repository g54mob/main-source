#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TH20
{
	public class PlayerAmbulance : Ambulance, IAnimationEndEvent
	{
		private List<AmbulanceStaffAssignment> _requiredStaffAssignments;

		private List<Patient> _patientsCollected;

		[DontSave]
		private Transform _ambulanceRig;

		[DontSave]
		private Animator _animator;

		private Vector3 _embarkStart;

		[DontSave]
		private Transform _disembarkStart;

		[DontSave]
		private RoomItem _ambulanceItem;

		private readonly int _ambulanceItemID;

		private readonly PlayerAmbulanceDepartment _myOwner;

		[DontSave]
		private RoomItemAmbulanceComponent _roomItemAmbulanceComponent;

		[DontSave]
		private ParticleEffectControlComponent _particleEffectControlComponent;

		private Staff _currentlyBoardingStaff;

		private List<JobAmbulance> _currentlyUnassignedJobs;

		private Character _currentlyDisembarkingCharacter;

		private Character debug_currentlyDisembarkingCharacter;

		private float debug_disembarkTimer;

		private float debug_disembarkTimerMaxSeconds = 30f;

		private bool _readyToDisembark = true;

		private int _requiredStaffCount;

		private float _timeSpentWaitingForOptionals;

		private bool _allRequiredStaffAssignedAndAboard;

		private bool _unassignOnReturn;

		private ChallengeAmbulanceEmergency _queuedEmergency;

		private bool _hasBeenSold;

		private bool _removingStaffAndJobs;

		[DontSave]
		private AmbulanceStatus _statusIcon;

		private Vector3 _currentPosition = Vector3.zero;

		private float _endPullingOutAnimY;

		private Vector3 _pullOutPosition;

		private Quaternion _pullOutRotation;

		private Vector3 _reversingInPosition;

		private Quaternion _reversingInRotation;

		private float _curveProgress;

		private float _currentSpeed;

		private bool _isDrivingIn;

		private bool _isPullingOut;

		private bool _isReversingIn;

		private bool _isBrokenDown;

		private int _upgradeLevel;

		private float _maxAdditionalSpeed;

		private int _journeyID;

		[DontSave]
		private AnimationEventListener _animEvent;

		private readonly Vector3 _reverseOffset = new Vector3(8.33f, 0f, 16.1f);

		private Vector3 _driveInLocation;

		private Vector3 _driveOutDirection;

		private Vector3 _sittingPosition;

		private Quaternion _originalRotation;

		private const float DistanceOffScreen = 170f;

		private const float AirAmbulanceCurveShrinker = 1.2f;

		private float _localSpeed = 0.8f;

		private bool _tripAborted;

		private float _returnVisualDistance;

		private static readonly int TriggerPullOut = Animator.StringToHash("PullOut");

		private static readonly int TriggerMorePatients = Animator.StringToHash("MorePatients");

		private static readonly int TriggerStartReversing = Animator.StringToHash("StartReversing");

		private static readonly int TriggerBreakdown = Animator.StringToHash("BreakDown");

		private static readonly int TriggerRepaired = Animator.StringToHash("Repaired");

		private static readonly int StaffEnterStateName = Animator.StringToHash("Base Layer.GetIn");

		private static readonly int ExitStateName = Animator.StringToHash("Get_Out");

		private static readonly string PullingOutState = "PullOut";

		private static readonly string DrivingOutState = "DrivingOutLoop";

		private static readonly string DrivingInState = "DrivingInLoop";

		private static readonly string ReverseInState = "ReverseIn";

		private static readonly string IdleState = "Idle";

		private static readonly string GetInState = "GetIn";

		private static readonly string SirenPFX = "Siren";

		private static int CurrentID = 0;

		private static readonly string SocketEmbarkStart = "EMBARK_START";

		private static readonly string SocketDisembarkStart = "DISEMBARK_START";

		public int AmbulanceItemID => _ambulanceItemID;

		public List<Patient> PatientsCollected => _patientsCollected;

		public Transform AmbulanceRig => _ambulanceRig;

		public RoomItem AmbulanceItem => _ambulanceItem;

		public bool IsDrivingIn => _isDrivingIn;

		public bool IsPullingOut => _isPullingOut;

		public bool IsReversingIn => _isReversingIn;

		public bool IsBrokenDown => _isBrokenDown;

		public float MaintenanceLevel => _ambulanceItem.MaintenanceLevel.Value();

		public int ID => _journeyID;

		public bool UnassignOnReturn => _unassignOnReturn;

		public ChallengeAmbulanceEmergency QueuedEmergency => _queuedEmergency;

		public bool HasBeenSold => _hasBeenSold;

		public bool StaffOnBoarding => _currentlyBoardingStaff != null;

		public List<AmbulanceStaffAssignment> RequiredStaffAssignments => _requiredStaffAssignments;

		public List<JobAmbulance> CurrentlyUnassignedJobs => _currentlyUnassignedJobs;

		public PlayerAmbulance(AmbulanceConfig config, PlayerAmbulanceDepartment owner, RoomItem ambulanceItem)
			: base(config, owner)
		{
			_localSpeed = config.InGameSpeed;
			_requiredStaffAssignments = new List<AmbulanceStaffAssignment>();
			_ambulanceItem = ambulanceItem;
			_ambulanceItemID = _ambulanceItem.ID;
			_ambulanceRig = _ambulanceItem.Visual.GameObject.transform.GetChild(0);
			_embarkStart = _ambulanceItem.Visual.GameObject.transform.FindChildRecursively(SocketEmbarkStart).position;
			_disembarkStart = _ambulanceItem.Visual.GameObject.transform.FindChildRecursively(SocketDisembarkStart);
			_animator = _ambulanceItem.Visual.Animator;
			_animEvent = ambulanceItem.Visual.GameObject.GetComponentInChildren<AnimationEventListener>();
			ToggleAnimEvents(active: true);
			_myOwner = owner;
			_upgradeLevel = _ambulanceItem.UpgradeLevel;
			_config = _ambulanceItem.Definition.GetAmbulanceConfig(_upgradeLevel).Instance;
			_maxAdditionalSpeed = _config.MaxInGameSpeed;
			_roomItemAmbulanceComponent = _ambulanceItem.GetComponent<RoomItemAmbulanceComponent>();
			_particleEffectControlComponent = _ambulanceItem?.Visual?.GameObject.GetComponent<ParticleEffectControlComponent>();
			BuildEvents buildEvents = owner.Level.BuildEvents;
			buildEvents.OnRoomItemSold = (Action<RoomItem>)Delegate.Combine(buildEvents.OnRoomItemSold, new Action<RoomItem>(OnRoomItemSold));
			BuildEvents buildEvents2 = owner.Level.BuildEvents;
			buildEvents2.OnRoomItemVisualDestroyed = (Action<RoomItemVisual>)Delegate.Combine(buildEvents2.OnRoomItemVisualDestroyed, new Action<RoomItemVisual>(OnRoomItemVisualDestroyed));
			ambulanceItem.OnInteractionStarted = (Action<Character>)Delegate.Combine(ambulanceItem.OnInteractionStarted, new Action<Character>(OnRepairStarted));
			_patientsCollected = new List<Patient>();
			_currentlyUnassignedJobs = new List<JobAmbulance>();
			_driveInLocation = config.DriveInLocation;
			_driveOutDirection = config.DriveOutDirection;
			_originalRotation = AmbulanceRig.localRotation;
			_sittingPosition = _ambulanceRig.localPosition;
			GameObject gameObject = UnityEngine.Object.Instantiate(owner.AmbulanceStatusUIPrefab);
			_statusIcon = gameObject.GetComponent<AmbulanceStatus>();
			_statusIcon.Initialise(this, owner.Level);
			_returnVisualDistance = 170f - _driveInLocation.y;
		}

		public void RestoreFromSave(RoomItem roomItem)
		{
			_ambulanceItem = roomItem;
			_ambulanceRig = _ambulanceItem.Visual.GameObject.transform.GetChild(0);
			_embarkStart = _ambulanceItem.Visual.GameObject.transform.FindChildRecursively(SocketEmbarkStart).position;
			_disembarkStart = _ambulanceItem.Visual.GameObject.transform.FindChildRecursively(SocketDisembarkStart);
			_animator = _ambulanceItem.Visual.Animator;
			ResetAnimTriggers();
			_roomItemAmbulanceComponent = _ambulanceItem.GetComponent<RoomItemAmbulanceComponent>();
			_ambulanceRig.gameObject.SetActive(!base.IsAwayFromLevel);
			_particleEffectControlComponent = _ambulanceItem?.Visual?.GameObject.GetComponent<ParticleEffectControlComponent>();
			GameObject gameObject = UnityEngine.Object.Instantiate(_myOwner.AmbulanceStatusUIPrefab);
			_statusIcon = gameObject.GetComponent<AmbulanceStatus>();
			_statusIcon.Initialise(this, _myOwner.Level);
			_maxAdditionalSpeed = _config.MaxInGameSpeed;
			_animEvent = _ambulanceItem.Visual.GameObject.GetComponentInChildren<AnimationEventListener>(includeInactive: true);
			ToggleAnimEvents(active: true);
			BuildEvents buildEvents = _myOwner.Level.BuildEvents;
			buildEvents.OnRoomItemSold = (Action<RoomItem>)Delegate.Combine(buildEvents.OnRoomItemSold, new Action<RoomItem>(OnRoomItemSold));
			BuildEvents buildEvents2 = _myOwner.Level.BuildEvents;
			buildEvents2.OnRoomItemVisualDestroyed = (Action<RoomItemVisual>)Delegate.Combine(buildEvents2.OnRoomItemVisualDestroyed, new Action<RoomItemVisual>(OnRoomItemVisualDestroyed));
			RoomItem ambulanceItem = _ambulanceItem;
			ambulanceItem.OnInteractionStarted = (Action<Character>)Delegate.Combine(ambulanceItem.OnInteractionStarted, new Action<Character>(OnRepairStarted));
			_driveInLocation = _config.DriveInLocation;
			_returnVisualDistance = 170f - _driveInLocation.y;
			ActivateExhaustAndSirenFX(_currentState != State.Idle);
			switch (_currentState)
			{
			case State.Idle:
				ResetAnimTriggers();
				KickOutAllStaff();
				break;
			case State.GettingReady:
				if (StaffOnBoarding)
				{
					Staff currentlyBoardingStaff = _currentlyBoardingStaff;
					currentlyBoardingStaff.PostRestoreFromSaveCallback = (Action)Delegate.Combine(currentlyBoardingStaff.PostRestoreFromSaveCallback, (Action)delegate
					{
						RuntimeAnimatorController animGraph = _currentlyBoardingStaff.FindAnimationGraph(ref _config.BoardAnimGraph);
						_currentlyBoardingStaff.FixupAnimationEndEvent(this, animGraph);
					});
				}
				{
					foreach (AmbulanceStaffAssignment requiredStaffAssignment in _requiredStaffAssignments)
					{
						if (!requiredStaffAssignment.IsAboard && requiredStaffAssignment.StaffAssigned != _currentlyBoardingStaff)
						{
							Staff staffAssigned = requiredStaffAssignment.StaffAssigned;
							staffAssigned.PostRestoreFromSaveCallback = (Action)Delegate.Combine(staffAssigned.PostRestoreFromSaveCallback, (Action)delegate
							{
								requiredStaffAssignment.JobAssignment.PostLoadFixUpEvent(requiredStaffAssignment.StaffAssigned);
							});
						}
					}
					break;
				}
			case State.VisuallyLeavingBase:
				if (_isPullingOut)
				{
					_animator.enabled = false;
					_animator.SetTrigger(TriggerPullOut);
					_ambulanceRig.localPosition = _pullOutPosition;
					_ambulanceRig.localRotation = _pullOutRotation;
					_animator.enabled = true;
				}
				else
				{
					_animator.enabled = false;
					_ambulanceRig.localRotation = _pullOutRotation;
					Vector3 localPosition = _ambulanceRig.localPosition;
					localPosition.z = _reverseOffset.z;
					_ambulanceRig.localPosition = localPosition;
					_animator.enabled = true;
				}
				break;
			case State.VisuallyReturning:
				_animator.enabled = false;
				_ambulanceRig.localRotation = ((base.AmbulanceType == AmbulanceConfig.Type.Road) ? _pullOutRotation : _originalRotation);
				_animator.enabled = true;
				break;
			case State.Parking:
				_animator.enabled = false;
				_ambulanceRig.localPosition = _reverseOffset;
				_ambulanceRig.localRotation = _originalRotation;
				_animator.enabled = true;
				_animator.Play(ReverseInState, 0, 0f);
				break;
			case State.UnloadingStaff:
			{
				_readyToDisembark = true;
				Character currentlyDisembarkingCharacter = _currentlyDisembarkingCharacter;
				Staff staff = currentlyDisembarkingCharacter as Staff;
				if (staff != null)
				{
					RuntimeAnimatorController staffAnimgraph = staff.FindAnimationGraph(ref _config.DisembarkAnimGraph);
					Staff staff2 = staff;
					staff2.PostRestoreFromSaveCallback = (Action)Delegate.Combine(staff2.PostRestoreFromSaveCallback, (Action)delegate
					{
						staff.FixupAnimationEndEvent(this, staffAnimgraph);
					});
				}
				break;
			}
			case State.UnloadingPatients:
			{
				_readyToDisembark = true;
				Character currentlyDisembarkingCharacter = _currentlyDisembarkingCharacter;
				Patient patient = currentlyDisembarkingCharacter as Patient;
				if (patient != null)
				{
					RuntimeAnimatorController patientAnimgraph = patient.FindAnimationGraph(ref _config.DisembarkAnimGraph);
					Patient patient2 = patient;
					patient2.PostRestoreFromSaveCallback = (Action)Delegate.Combine(patient2.PostRestoreFromSaveCallback, (Action)delegate
					{
						patient.FixupAnimationEndEvent(this, patientAnimgraph);
					});
				}
				break;
			}
			case State.Maintenance:
				if (_isBrokenDown)
				{
					ActivateAnimationPFX(enable: true, 0);
				}
				break;
			case State.ReturnOrIdleDecision:
				ResetAnimTriggers();
				break;
			default:
				throw new ArgumentOutOfRangeException();
			case State.ReadyToLeave:
			case State.WaitingForClearExitRoute:
			case State.MovingToEmergency:
			case State.AtEmergency:
			case State.RescuePatients:
			case State.ReturningToBase:
			case State.WaitingForClearParkingRoute:
			case State.AtHospital:
			case State.ApplyWearAndTear:
				break;
			}
		}

		public void OnboardPatients(List<Patient> patients)
		{
			_patientsCollected = patients;
			float num = 1f;
			foreach (AmbulanceStaffAssignment requiredStaffAssignment in _requiredStaffAssignments)
			{
				num += requiredStaffAssignment.StaffAssigned.GetDiagnosisMultiplier(_ambulanceItem.OwningRoom);
			}
			foreach (Patient item in _patientsCollected)
			{
				float num2 = ((float)_config.DiagnosisBonus + item.Illness._diagnosisCertaintyDefaultIncrease) * num;
				item.ForceUpdateRoomUsing(AmbulanceItem.OwningRoom);
				item.ModifyDiagnosisCertainty(num2);
				_myOwner.Level.CharacterEvents.OnPatientReceivedDiagnosis.InvokeSafe(item, _requiredStaffAssignments[0].StaffAssigned, AmbulanceItem.OwningRoom, num2);
			}
		}

		public void ResetStaffLists()
		{
			_requiredStaffAssignments.Clear();
			_allRequiredStaffAssignedAndAboard = false;
			_requiredStaffCount = 0;
			_currentlyUnassignedJobs.Clear();
		}

		public override void Update(float timeDelta)
		{
			base.Update(timeDelta);
			if (_myOwner.DebugAmbulanceDisembark)
			{
				DebugAmbulanceDisembark();
			}
			switch (_currentState)
			{
			case State.Idle:
				if (_myOwner.DebugAutoAssignAmbulances)
				{
					_myOwner.Debug_AssignAmbulance(this);
				}
				break;
			case State.GettingReady:
				LeaveWhenReady();
				break;
			case State.WaitingForClearExitRoute:
				if (!_myOwner.IsAnyAmbulanceManeuvering(this, entering: false))
				{
					_roomItemAmbulanceComponent.IsOutOfParkingSpace = true;
					_animator.SetTrigger(TriggerPullOut);
					_isPullingOut = true;
					_tripAborted = false;
					_ambulanceEmergency.OnAmbulanceDepartHospital.InvokeSafe(this);
					_currentState = State.VisuallyLeavingBase;
				}
				break;
			case State.VisuallyLeavingBase:
				if (DriveAmbulanceOffScreen())
				{
					_currentState = State.MovingToEmergency;
				}
				break;
			case State.AtEmergency:
			{
				int num = _ambulanceEmergency.PlayerAmbulanceArrivesAtEmergency(this);
				_currentState = ((num > 0 && _ambulanceEmergency.IsRescue) ? State.RescuePatients : State.ReturningToBase);
				break;
			}
			case State.WaitingForClearParkingRoute:
				if (!_myOwner.IsAnyAmbulanceManeuvering(this, entering: true))
				{
					SpawnAmbulanceBack();
					_currentState = State.VisuallyReturning;
				}
				break;
			case State.VisuallyReturning:
				if (DriveAmbulanceOnScreen())
				{
					_currentState = State.Parking;
				}
				break;
			case State.Parking:
				if (AmbulanceHasParked())
				{
					_currentState = State.AtHospital;
				}
				break;
			case State.AtHospital:
				_ambulanceEmergency.PlayerAmbulanceArrivesAtHospital(this);
				_readyToDisembark = true;
				_currentState = State.UnloadingStaff;
				break;
			case State.UnloadingStaff:
				ProcessUnloadingStaff();
				break;
			case State.UnloadingPatients:
				ProcessUnloadingPatients();
				break;
			case State.ApplyWearAndTear:
				ApplyWearAndTear();
				_roomItemAmbulanceComponent.IsOutOfParkingSpace = false;
				_ambulanceItem.OverrideDefinitionIsSelectable(newSelectableState: true);
				_ambulanceItem.OverrideDefinitionIgnoredByJanitors(newIgnoreState: false);
				_currentState = ((_isBrokenDown || IsUndergoingUpgrade()) ? State.Maintenance : State.ReturnOrIdleDecision);
				break;
			case State.Maintenance:
				if (!_isBrokenDown && !IsUndergoingMaintenance() && !IsUndergoingUpgrade())
				{
					_currentState = State.ReturnOrIdleDecision;
				}
				else
				{
					CheckRepairStatus();
				}
				break;
			case State.ReturnOrIdleDecision:
				ResetAnimTriggers();
				DecideOnNextMove();
				break;
			case State.ReadyToLeave:
			case State.MovingToEmergency:
			case State.RescuePatients:
			case State.ReturningToBase:
				break;
			}
		}

		private void CheckRepairStatus()
		{
			RoomItemMaintenanceComponent component = _ambulanceItem.GetComponent<RoomItemMaintenanceComponent>();
			if (component?.Job != null && _ambulanceItem.GetComponent<RoomItemMaintenanceComponent>().Job.MaintenanceValue == 0f)
			{
				_myOwner.Level.StaffWorkScheduler.RemoveJob(_ambulanceItem.GetComponent<RoomItemMaintenanceComponent>().Job, complete: false);
				component.Job = null;
				component.Destroy();
			}
		}

		private void DebugAmbulanceDisembark()
		{
			if (_currentlyDisembarkingCharacter == null)
			{
				return;
			}
			if (debug_currentlyDisembarkingCharacter == _currentlyDisembarkingCharacter)
			{
				debug_disembarkTimer += Time.deltaTime;
				if (debug_disembarkTimer > debug_disembarkTimerMaxSeconds)
				{
					Logging.Warning($"{_currentlyDisembarkingCharacter} is disembarking, but is stuck!");
				}
			}
			else
			{
				debug_currentlyDisembarkingCharacter = _currentlyDisembarkingCharacter;
				debug_disembarkTimer = 0f;
			}
		}

		public override void SetEmergency(ChallengeAmbulanceEmergency emergency, float distance)
		{
			_unassignOnReturn = false;
			_queuedEmergency = null;
			_myOwner.RespondingToEmergency(emergency);
			base.SetEmergency(emergency, distance);
		}

		private void DecideOnNextMove()
		{
			if (_unassignOnReturn)
			{
				ResetAmbulanceToDefaults();
				return;
			}
			if (_queuedEmergency != null)
			{
				_ambulanceEmergency?.UnAssignAmbulance(this);
				if (!_queuedEmergency.IsJourneyFutile(this))
				{
					_ambulanceEmergency = _queuedEmergency;
					_ambulanceEmergency.AssignAmbulance(this);
					BeginGettingReady();
					return;
				}
			}
			else if (_ambulanceEmergency != null && !_ambulanceEmergency.IsJourneyFutile(this))
			{
				BeginGettingReady();
				return;
			}
			ResetAmbulanceToDefaults();
		}

		private void ResetAnimTriggers()
		{
			AnimatorControllerParameter[] parameters = _animator.parameters;
			foreach (AnimatorControllerParameter animatorControllerParameter in parameters)
			{
				if (animatorControllerParameter.type == AnimatorControllerParameterType.Trigger)
				{
					_animator.ResetTrigger(animatorControllerParameter.name);
				}
			}
		}

		private void ResetAmbulanceToDefaults()
		{
			ActivateExhaustAndSirenFX(enable: false);
			_unassignOnReturn = false;
			_queuedEmergency = null;
			_ambulanceEmergency?.UnAssignAmbulance(this);
			_ambulanceItem.OverrideDefinitionIsSelectable(newSelectableState: true);
			_ambulanceItem.OverrideDefinitionIgnoredByJanitors(newIgnoreState: false);
			_currentState = State.Idle;
		}

		public override void LeaveWhenReady()
		{
			if (_ambulanceEmergency == null)
			{
				return;
			}
			if (IsUndergoingUpgrade() && !StaffOnBoarding)
			{
				Logging.Info(LogChannels.AmbulanceEmergency, "While getting ready your " + _config.AmbulanceName.Translation + " ambulance was set to upgrade");
				AbortTrip();
				return;
			}
			if (_ambulanceEmergency.IsJourneyFutile(this) && !StaffOnBoarding)
			{
				Logging.Info(LogChannels.AmbulanceEmergency, "While getting ready your " + _config.AmbulanceName.Translation + " ambulance decided the journey was futile due to ETA vs Death-Clock");
				AbortTrip();
				return;
			}
			if (!_allRequiredStaffAssignedAndAboard)
			{
				_allRequiredStaffAssignedAndAboard = CheckStaffRequirements();
			}
			if (!_animator.IsInTransition(0) && _animator.IsInState(GetInState) && _allRequiredStaffAssignedAndAboard)
			{
				Logging.Info(LogChannels.AmbulanceEmergency, $"Your {base.Config.AmbulanceName} Ambulance is loaded up and ready to go!");
				_currentState = State.WaitingForClearExitRoute;
				_speedBoost = GetHighestSpeedFromStaff();
				CurrentID++;
				_journeyID = CurrentID;
			}
		}

		private void AbortTrip()
		{
			_removingStaffAndJobs = true;
			foreach (AmbulanceStaffAssignment requiredStaffAssignment in _requiredStaffAssignments)
			{
				_ambulanceEmergency.Level.StaffWorkScheduler.RemoveJob(requiredStaffAssignment.JobAssignment, complete: false);
			}
			foreach (JobAmbulance currentlyUnassignedJob in _currentlyUnassignedJobs)
			{
				currentlyUnassignedJob.SetInvalid();
				_ambulanceEmergency.Level.StaffWorkScheduler.RemoveJob(currentlyUnassignedJob, complete: false);
			}
			_requiredStaffAssignments.Clear();
			_currentlyUnassignedJobs.Clear();
			_removingStaffAndJobs = false;
			_tripAborted = true;
			_currentState = State.UnloadingStaff;
		}

		public override float GetHighestSpeedFromStaff()
		{
			float num = 1f;
			foreach (AmbulanceStaffAssignment requiredStaffAssignment in _requiredStaffAssignments)
			{
				float num2 = 1f;
				foreach (QualificationSlot qualification in requiredStaffAssignment.StaffAssigned.Qualifications)
				{
					CharacterModifier[] modifiers = qualification.Definition.Modifiers;
					for (int i = 0; i < modifiers.Length; i++)
					{
						if (modifiers[i] is QualificationAmbulanceSpeedBoost qualificationAmbulanceSpeedBoost && (qualificationAmbulanceSpeedBoost.Type == _config.AmbulanceType || qualificationAmbulanceSpeedBoost.Type == AmbulanceConfig.Type.All))
						{
							num2 += qualificationAmbulanceSpeedBoost.ScoreBoost;
						}
					}
				}
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}

		private bool AmbulanceHasParked()
		{
			if (_animator.IsInState(IdleState))
			{
				_currentPosition = _sittingPosition;
				_ambulanceRig.localPosition = _currentPosition;
				_isReversingIn = false;
				return true;
			}
			_reversingInPosition = _ambulanceRig.localPosition;
			_reversingInRotation = _ambulanceRig.localRotation;
			return false;
		}

		private bool CheckStaffRequirements()
		{
			AmbulanceConfig.StaffRequirement[] staffRequirements = _config.StaffRequirements;
			List<AmbulanceStaffAssignment> requiredStaffAssignments = _requiredStaffAssignments;
			AmbulanceConfig.StaffRequirement[] array = staffRequirements;
			for (int i = 0; i < array.Length; i++)
			{
				AmbulanceConfig.StaffRequirement staffRequirement = array[i];
				StaffRequired staffType = staffRequirement.StaffType;
				int countRequired = staffRequirement.CountRequired;
				int num = 0;
				for (int j = 0; j < requiredStaffAssignments.Count; j++)
				{
					if (staffType.IsSuitable(requiredStaffAssignments[j].StaffAssigned) && requiredStaffAssignments[j].IsAboard)
					{
						num++;
					}
				}
				if (num < countRequired)
				{
					return false;
				}
			}
			return true;
		}

		private bool DriveAmbulanceOffScreen()
		{
			if (_isPullingOut)
			{
				bool num = _animator.IsInTransition(0);
				bool flag = _animator.IsInState(DrivingOutState);
				if (!(num || flag))
				{
					_pullOutPosition = _ambulanceRig.localPosition;
					_pullOutRotation = _ambulanceRig.localRotation;
					return false;
				}
				_isPullingOut = false;
				_curveProgress = 0f;
				_currentSpeed = _localSpeed;
				_currentPosition = _ambulanceRig.localPosition;
				_endPullingOutAnimY = _currentPosition.y;
			}
			MakeProgress(Time.deltaTime, toEmergency: true, blockCompletion: true);
			Vector3 localPosition = _ambulanceRig.localPosition;
			if (_config.AmbulanceType == AmbulanceConfig.Type.Air)
			{
				if (!(_ambulanceRig.localPosition.y < 170f))
				{
					_currentPosition = _sittingPosition;
					_ambulanceRig.gameObject.SetActive(value: false);
					return true;
				}
				_currentPosition.y += _driveOutDirection.y * _currentSpeed * GameTime.deltaTime;
				localPosition.y = _currentPosition.y;
				_currentPosition.x += _driveOutDirection.x * _currentSpeed * GameTime.deltaTime;
				localPosition.x = _currentPosition.x;
				_currentPosition.z += _driveOutDirection.z * _currentSpeed * GameTime.deltaTime;
				localPosition.z = _currentPosition.z;
				_ambulanceRig.localPosition = localPosition;
				CalculateSpeed(localPosition, leavingMap: true);
			}
			if (_config.AmbulanceType == AmbulanceConfig.Type.Road)
			{
				if (!(_ambulanceRig.localPosition.x > -170f))
				{
					_originalRotation = AmbulanceRig.localRotation;
					ActivateExhaustAndSirenFX(enable: false);
					_currentPosition = _sittingPosition;
					_ambulanceRig.gameObject.SetActive(value: false);
					return true;
				}
				_currentPosition.x += _driveOutDirection.x * _currentSpeed * GameTime.deltaTime;
				localPosition.x = _currentPosition.x;
				_ambulanceRig.localPosition = localPosition;
				CalculateSpeed(localPosition, leavingMap: true);
			}
			return false;
		}

		private void SpawnAmbulanceBack()
		{
			_isDrivingIn = true;
			_ambulanceRig.gameObject.SetActive(value: true);
			_ambulanceRig.localRotation = ((base.AmbulanceType == AmbulanceConfig.Type.Road) ? _pullOutRotation : _originalRotation);
			if (_config.AmbulanceType == AmbulanceConfig.Type.Air)
			{
				_currentPosition = new Vector3(_driveInLocation.x, 170f, _driveInLocation.z);
			}
			else
			{
				_currentPosition = new Vector3(_reverseOffset.x + 170f, 0f, _reverseOffset.z);
			}
			_ambulanceRig.localPosition = _currentPosition;
			ActivateExhaustAndSirenFX(enable: true);
			_animator.Play(DrivingInState, -1, 0f);
		}

		private bool DriveAmbulanceOnScreen()
		{
			if (_config.AmbulanceType == AmbulanceConfig.Type.Air)
			{
				if (_ambulanceRig.localPosition.y >= _driveInLocation.y)
				{
					_currentPosition.y += -1f * _currentSpeed * GameTime.deltaTime;
					Vector3 localPosition = _ambulanceRig.localPosition;
					localPosition.y = _currentPosition.y;
					_ambulanceRig.localPosition = localPosition;
					CalculateSpeed(localPosition);
					return false;
				}
				_isDrivingIn = false;
				_isReversingIn = true;
				_ambulanceRig.localPosition = _driveInLocation;
				_animator.SetTrigger(TriggerStartReversing);
				return true;
			}
			if (_ambulanceRig.localPosition.x >= _reverseOffset.x)
			{
				_currentPosition.x += _driveOutDirection.x * _currentSpeed * GameTime.deltaTime;
				Vector3 localPosition2 = _ambulanceRig.localPosition;
				localPosition2.x = _currentPosition.x;
				_ambulanceRig.localPosition = localPosition2;
				CalculateSpeed(localPosition2);
				return false;
			}
			_isDrivingIn = false;
			_isReversingIn = true;
			_ambulanceRig.localPosition = _reverseOffset;
			_animator.SetTrigger(TriggerStartReversing);
			return true;
		}

		private void CalculateSpeed(Vector3 position, bool leavingMap = false)
		{
			if (leavingMap)
			{
				if (_config.AmbulanceType == AmbulanceConfig.Type.Air)
				{
					float f = position.y - _endPullingOutAnimY;
					_curveProgress = Mathf.Abs(f) / Mathf.Abs(-141.66666f);
				}
				else
				{
					_curveProgress = Mathf.Abs(position.x) / Mathf.Abs(170f);
				}
			}
			else if (_config.AmbulanceType == AmbulanceConfig.Type.Air)
			{
				float num = 170f - position.y;
				float f2 = _returnVisualDistance - num;
				_curveProgress = Mathf.Abs(f2) / Mathf.Abs(_returnVisualDistance);
			}
			else
			{
				_curveProgress = Mathf.Abs(position.x) / Mathf.Abs(170f);
			}
			float num2 = _config.OutroAcceleration.Evaluate(_curveProgress);
			_currentSpeed = (_localSpeed + num2 * _maxAdditionalSpeed) * GetHighestSpeedFromStaff();
		}

		public override bool BeginGettingReady()
		{
			AmbulanceConfig.StaffRequirement[] staffRequirements = base.Config.StaffRequirements;
			for (int i = 0; i < staffRequirements.Length; i++)
			{
				AmbulanceConfig.StaffRequirement staffRequirement = staffRequirements[i];
				for (int j = 0; j < staffRequirement.CountRequired; j++)
				{
					JobAmbulance jobAmbulance = new JobAmbulance(staffRequirement.StaffType, _ambulanceItem, this);
					_ambulanceEmergency.Level.StaffWorkScheduler.AddJob(jobAmbulance);
					_currentlyUnassignedJobs.Add(jobAmbulance);
					_requiredStaffCount++;
				}
			}
			ActivateExhaustAndSirenFX(enable: true);
			return base.BeginGettingReady();
		}

		public void RemoveStaff(Staff staff)
		{
			if (_requiredStaffAssignments.FirstOrDefault((AmbulanceStaffAssignment x) => x.StaffAssigned == staff) != null)
			{
				_requiredStaffAssignments.Remove(_requiredStaffAssignments.FirstOrDefault((AmbulanceStaffAssignment x) => x.StaffAssigned == staff));
			}
			else
			{
				_requiredStaffAssignments.Remove(_requiredStaffAssignments.FirstOrDefault((AmbulanceStaffAssignment x) => x.StaffAssigned == staff));
			}
		}

		public void StaffAssignedAmbulance(Staff staff, JobAmbulance job)
		{
			if (_requiredStaffAssignments.Count < _requiredStaffCount)
			{
				_requiredStaffAssignments.Add(new AmbulanceStaffAssignment(staff, isAboard: false, job));
				if (_currentlyUnassignedJobs.Contains(job))
				{
					_currentlyUnassignedJobs.Remove(job);
				}
			}
		}

		public void JobReset(JobAmbulance job)
		{
			if (_removingStaffAndJobs)
			{
				return;
			}
			AmbulanceStaffAssignment ambulanceStaffAssignment = null;
			foreach (AmbulanceStaffAssignment requiredStaffAssignment in _requiredStaffAssignments)
			{
				if (requiredStaffAssignment.JobAssignment == job)
				{
					ambulanceStaffAssignment = requiredStaffAssignment;
				}
			}
			if (ambulanceStaffAssignment != null)
			{
				_requiredStaffAssignments.Remove(ambulanceStaffAssignment);
				_currentlyUnassignedJobs.Add(job);
			}
		}

		public void StaffArrivedAmbulance(Staff staff)
		{
			if (_currentlyBoardingStaff != null || (RequiredStaffAssignments.Count > 0 && RequiredStaffAssignments[0].StaffAssigned != staff))
			{
				staff.Idle();
				return;
			}
			_currentlyBoardingStaff = staff;
			RuntimeAnimatorController animationGraph = staff.FindAnimationGraph(ref _config.BoardAnimGraph);
			staff.PushAnimationGraph(animationGraph, 0f, this);
			staff.SetBehaviour(_currentlyBoardingStaff.Definition._behaviourWaitForJob);
			staff.AddComponent<DisableSelectionComponent>().InitializeComponent();
			staff.AddComponent<DisableHighlightComponent>().InitializeComponent();
			staff.NavPath.RemoveFromNavWorld();
			_animator.Play(StaffEnterStateName, -1, 0f);
			staff.Animator.Play(StaffEnterStateName, -1, 0f);
			_ambulanceItem.OverrideDefinitionIsSelectable(newSelectableState: false);
			_ambulanceItem.OverrideDefinitionIgnoredByJanitors(newIgnoreState: true);
			Job job = null;
			foreach (Job job2 in _ambulanceItem.OwningRoom.Jobs)
			{
				if (job2 is JobMaintenance jobMaintenance && jobMaintenance.Item == _ambulanceItem)
				{
					job = jobMaintenance;
				}
			}
			if (job != null)
			{
				_myOwner.Level.StaffWorkScheduler.RemoveJob(job, complete: false);
				RoomItemMaintenanceComponent component = _ambulanceItem.GetComponent<RoomItemMaintenanceComponent>();
				if (component != null)
				{
					component.Job = null;
					component.Destroy();
				}
			}
		}

		private void ProcessUnloadingPatients()
		{
			if (!_readyToDisembark)
			{
				return;
			}
			if (PatientsCollected == null || PatientsCollected.Count == 0)
			{
				_currentState = State.ApplyWearAndTear;
				return;
			}
			if (_currentlyDisembarkingCharacter != null && _currentlyDisembarkingCharacter != _patientsCollected[0])
			{
				RuntimeAnimatorController animationGraph = _currentlyDisembarkingCharacter.FindAnimationGraph(ref _config.DisembarkAnimGraph);
				_currentlyDisembarkingCharacter.PopAnimationGraph(animationGraph, 0f, isolate: true);
				_currentlyDisembarkingCharacter.EnableBehaviour(enabled: true);
				_currentlyDisembarkingCharacter.NavPath.PutBackInNavWorld();
			}
			_currentlyDisembarkingCharacter = PatientsCollected[0];
			if (!(_currentlyDisembarkingCharacter is Patient patient))
			{
				return;
			}
			if (patient.GameObject == null)
			{
				Logging.Error("Patient disembarking does not exist.");
				if (patient.CurrentMode == Patient.Mode.Dead)
				{
					Logging.Error("Patient died in transit.");
				}
				return;
			}
			patient.CreateVisuals();
			patient.Position = _disembarkStart.position;
			patient.Rotation = _disembarkStart.rotation;
			patient.RemoveComponents<CharacterCheckInComponent>();
			RuntimeAnimatorController animationGraph2 = patient.FindAnimationGraph(ref _config.DisembarkAnimGraph);
			patient.PushAnimationGraph(animationGraph2, 0f, this);
			_readyToDisembark = false;
			PatientsCollected.RemoveAt(0);
			_animator.Play(ExitStateName, -1, 0f);
			patient.Animator.Play(ExitStateName, -1, 0f);
		}

		private void ProcessUnloadingStaff()
		{
			if (!_readyToDisembark)
			{
				return;
			}
			if (_currentlyDisembarkingCharacter == null || !(_currentlyDisembarkingCharacter is Staff))
			{
				if (_requiredStaffAssignments.Count == 0)
				{
					_currentState = State.UnloadingPatients;
					ResetStaffLists();
					return;
				}
				AmbulanceStaffAssignment ambulanceStaffAssignment = _requiredStaffAssignments[0];
				if (!ambulanceStaffAssignment.IsAboard)
				{
					_requiredStaffAssignments.RemoveAt(0);
					_myOwner.Level.StaffWorkScheduler.RemoveJob(ambulanceStaffAssignment.JobAssignment, complete: false);
					return;
				}
				_currentlyDisembarkingCharacter = ambulanceStaffAssignment.StaffAssigned;
				if (_currentlyDisembarkingCharacter == null)
				{
					return;
				}
			}
			_currentlyDisembarkingCharacter.Position = _disembarkStart.position;
			_currentlyDisembarkingCharacter.Rotation = _disembarkStart.rotation;
			_currentlyDisembarkingCharacter.Visual.SetRendererActive(active: true);
			RuntimeAnimatorController animationGraph = _currentlyDisembarkingCharacter.FindAnimationGraph(ref _config.DisembarkAnimGraph);
			_currentlyDisembarkingCharacter.PushAnimationGraph(animationGraph, 0f, this);
			_animator.SetTrigger(TriggerMorePatients);
			_readyToDisembark = false;
			if (_requiredStaffAssignments.Count > 0)
			{
				_requiredStaffAssignments.RemoveAt(0);
			}
		}

		private void PlayParticleEffects(AnimationEvent animationEvent)
		{
			ActivateAnimationPFX(enable: true, animationEvent.intParameter);
		}

		private void StopParticleEffects(AnimationEvent animationEvent)
		{
			ActivateAnimationPFX(enable: false, animationEvent.intParameter);
		}

		private void ActivateAnimationPFX(bool enable, int effectIndex)
		{
			_particleEffectControlComponent.EnableEffect(effectIndex, enable);
		}

		private void ActivateExhaustAndSirenFX(bool enable)
		{
			_particleEffectControlComponent.EnableEffect(SirenPFX, enable);
		}

		private void TurnCharacterInvisible(AnimationEvent animationEvent)
		{
			_currentlyBoardingStaff.Visual.SetRendererActive(active: false);
		}

		public void OnAnimationEndEvent()
		{
			if (_currentlyBoardingStaff != null)
			{
				_currentlyBoardingStaff.EnableBehaviour(enabled: false);
				_currentlyBoardingStaff.AddComponent<DisableStatusIconComponent>();
				_currentlyBoardingStaff.Position = new Vector3(_ambulanceItem.WorldPosition.x, CharacterManager.AmbulancePatientSpawnLocation.y, _ambulanceItem.WorldPosition.z);
				AmbulanceStaffAssignment ambulanceStaffAssignment = _requiredStaffAssignments.FirstOrDefault((AmbulanceStaffAssignment x) => x.StaffAssigned == _currentlyBoardingStaff);
				if (ambulanceStaffAssignment != null)
				{
					ambulanceStaffAssignment.IsAboard = true;
				}
				RuntimeAnimatorController animationGraph = _currentlyBoardingStaff.FindAnimationGraph(ref _config.BoardAnimGraph);
				_currentlyBoardingStaff.PopAnimationGraph(animationGraph, 0f, isolate: true);
				_currentlyBoardingStaff = null;
			}
			if (_currentlyDisembarkingCharacter == null)
			{
				return;
			}
			_currentlyDisembarkingCharacter.RemoveComponents<DisableSelectionComponent>();
			_currentlyDisembarkingCharacter.RemoveComponents<DisableHighlightComponent>();
			_currentlyDisembarkingCharacter.RemoveComponents<DisableStatusIconComponent>();
			if (_currentlyDisembarkingCharacter is Patient patient)
			{
				patient.SetArrivedAndDisembarked();
				patient.ExcludeDiagnosisRoom(RoomDefinition.Type.GPOffice);
				if (patient.FullyDiagnosed())
				{
					patient.SendToTreatmentRoom(patient.Illness.GetTreatmentRoom(patient, _myOwner.Level.ResearchManager), immediately: true);
				}
				else
				{
					patient.SendToNextDiagnosisRoom(_config.FurtherDiagnosisChoiceCount);
				}
			}
			else if (_currentlyDisembarkingCharacter is Staff { CurrentJob: JobAmbulance currentJob } staff)
			{
				if (_ambulanceEmergency == null)
				{
					Logging.Info(LogChannels.AmbulanceEmergency, "Emergency is null on animation end. Why is this?");
				}
				else
				{
					currentJob.JobDone(staff, success: true);
					_myOwner.Level.StaffWorkScheduler.RemoveJob(currentJob, complete: true);
				}
				staff.SetBehaviour(staff.Definition._behaviourIdle);
			}
			RuntimeAnimatorController animationGraph2 = _currentlyDisembarkingCharacter.FindAnimationGraph(ref _config.DisembarkAnimGraph);
			_currentlyDisembarkingCharacter.PopAnimationGraph(animationGraph2, 0.25f, isolate: true);
			_currentlyDisembarkingCharacter.EnableBehaviour(enabled: true);
			_currentlyDisembarkingCharacter.NavPath.PutBackInNavWorld();
			_currentlyDisembarkingCharacter = null;
			_readyToDisembark = true;
		}

		private void ApplyWearAndTear()
		{
			if (!_tripAborted)
			{
				_animator.ResetTrigger(TriggerRepaired);
				_ambulanceItem.MaintenanceLevel.ResetCallbackStatus();
				AttributeFloat attribute = _ambulanceItem.GetAttributes().GetAttribute(0);
				float modifyValue = base.CurrentEmergencyDistance * 2f / _config.MilesPerBreakdown * 100f;
				attribute.Modify(modifyValue, 1f);
				if (MaintenanceLevel >= _ambulanceItem.Definition.MaintenanceFunctionalLevel)
				{
					_animator.SetTrigger(TriggerBreakdown);
					_isBrokenDown = true;
				}
			}
		}

		public void OnRepairStarted(Character character)
		{
			if (_isBrokenDown && character is Staff staff && staff.Definition._type == StaffDefinition.Type.Janitor)
			{
				_animator.SetTrigger(TriggerRepaired);
				_isBrokenDown = false;
			}
		}

		public void OnUpgradeComplete()
		{
			_upgradeLevel = _ambulanceItem.UpgradeLevel;
			_config = _ambulanceItem.Definition.GetAmbulanceConfig(_upgradeLevel).Instance;
			_ambulanceRig = _ambulanceItem.Visual.GameObject.transform.GetChild(0);
			_embarkStart = _ambulanceItem.Visual.GameObject.transform.FindChildRecursively(SocketEmbarkStart).position;
			_disembarkStart = _ambulanceItem.Visual.GameObject.transform.FindChildRecursively(SocketDisembarkStart);
			_animator = _ambulanceItem.Visual.Animator;
			_particleEffectControlComponent = _ambulanceItem?.Visual?.GameObject.GetComponent<ParticleEffectControlComponent>();
			_animEvent = _ambulanceItem.Visual.GameObject.GetComponentInChildren<AnimationEventListener>(includeInactive: true);
			ToggleAnimEvents(active: true);
			BuildEvents buildEvents = _myOwner.Level.BuildEvents;
			buildEvents.OnRoomItemSold = (Action<RoomItem>)Delegate.Combine(buildEvents.OnRoomItemSold, new Action<RoomItem>(OnRoomItemSold));
			RoomItem ambulanceItem = _ambulanceItem;
			ambulanceItem.OnInteractionStarted = (Action<Character>)Delegate.Combine(ambulanceItem.OnInteractionStarted, new Action<Character>(OnRepairStarted));
		}

		private void OnRoomItemSold(RoomItem roomItem)
		{
			if (roomItem == _ambulanceItem)
			{
				_hasBeenSold = true;
				_myOwner.AmbulanceWasSold(this);
				BuildEvents buildEvents = _myOwner.Level.BuildEvents;
				buildEvents.OnRoomItemSold = (Action<RoomItem>)Delegate.Remove(buildEvents.OnRoomItemSold, new Action<RoomItem>(OnRoomItemSold));
				BuildEvents buildEvents2 = _myOwner.Level.BuildEvents;
				buildEvents2.OnRoomItemVisualDestroyed = (Action<RoomItemVisual>)Delegate.Remove(buildEvents2.OnRoomItemVisualDestroyed, new Action<RoomItemVisual>(OnRoomItemVisualDestroyed));
				ToggleAnimEvents(active: false);
				if (_currentState == State.GettingReady)
				{
					KickOutAllStaff();
				}
				_ambulanceEmergency?.UnAssignAmbulance(this);
			}
		}

		public void UnregisterEvents()
		{
			BuildEvents buildEvents = _myOwner.Level.BuildEvents;
			buildEvents.OnRoomItemSold = (Action<RoomItem>)Delegate.Remove(buildEvents.OnRoomItemSold, new Action<RoomItem>(OnRoomItemSold));
			BuildEvents buildEvents2 = _myOwner.Level.BuildEvents;
			buildEvents2.OnRoomItemVisualDestroyed = (Action<RoomItemVisual>)Delegate.Remove(buildEvents2.OnRoomItemVisualDestroyed, new Action<RoomItemVisual>(OnRoomItemVisualDestroyed));
			RoomItem ambulanceItem = _ambulanceItem;
			ambulanceItem.OnInteractionStarted = (Action<Character>)Delegate.Combine(ambulanceItem.OnInteractionStarted, new Action<Character>(OnRepairStarted));
			ToggleAnimEvents(active: false);
			_statusIcon.Destroy();
		}

		private void OnRoomItemVisualDestroyed(RoomItemVisual obj)
		{
			if (obj == _ambulanceItem.Visual)
			{
				BuildEvents buildEvents = _myOwner.Level.BuildEvents;
				buildEvents.OnRoomItemSold = (Action<RoomItem>)Delegate.Remove(buildEvents.OnRoomItemSold, new Action<RoomItem>(OnRoomItemSold));
				RoomItem ambulanceItem = _ambulanceItem;
				ambulanceItem.OnInteractionStarted = (Action<Character>)Delegate.Remove(ambulanceItem.OnInteractionStarted, new Action<Character>(OnRepairStarted));
				ToggleAnimEvents(active: false);
			}
		}

		public void ToggleAnimEvents(bool active)
		{
			if (active)
			{
				_animEvent.RegisterEvent("PlayParticleEffects", PlayParticleEffects);
				_animEvent.RegisterEvent("StopParticleEffects", StopParticleEffects);
				_animEvent.RegisterEvent("TurnCharacterInvisible", TurnCharacterInvisible);
			}
			else
			{
				_animEvent.UnregisterEvent("PlayParticleEffects", PlayParticleEffects);
				_animEvent.UnregisterEvent("StopParticleEffects", StopParticleEffects);
				_animEvent.UnregisterEvent("TurnCharacterInvisible", TurnCharacterInvisible);
			}
		}

		private void KickOutAllStaff()
		{
			_removingStaffAndJobs = true;
			foreach (AmbulanceStaffAssignment requiredStaffAssignment in _requiredStaffAssignments)
			{
				KickOutStaff(requiredStaffAssignment);
			}
			foreach (JobAmbulance currentlyUnassignedJob in _currentlyUnassignedJobs)
			{
				currentlyUnassignedJob.SetInvalid();
				_ambulanceEmergency.Level.StaffWorkScheduler.RemoveJob(currentlyUnassignedJob, complete: true);
			}
			ResetStaffLists();
			_removingStaffAndJobs = false;
			void KickOutStaff(AmbulanceStaffAssignment assignment)
			{
				_ambulanceEmergency?.Level.StaffWorkScheduler.RemoveJob(assignment.JobAssignment, complete: false);
				if (assignment.IsAboard)
				{
					assignment.StaffAssigned.Position = _ambulanceItem.WorldPosition;
					assignment.StaffAssigned.NavPath.PutBackInNavWorld();
					assignment.StaffAssigned.RemoveComponents<DisableSelectionComponent>();
					assignment.StaffAssigned.RemoveComponents<DisableHighlightComponent>();
					assignment.StaffAssigned.RemoveComponents<DisableStatusIconComponent>();
					assignment.StaffAssigned.EnableBehaviour(enabled: true);
					assignment.StaffAssigned.TeleportOutOfRoom(_ambulanceItem.OwningRoom);
				}
			}
		}

		public bool IsStaffAboard(Staff staff)
		{
			foreach (AmbulanceStaffAssignment requiredStaffAssignment in _requiredStaffAssignments)
			{
				if (requiredStaffAssignment.StaffAssigned == staff)
				{
					return requiredStaffAssignment.IsAboard;
				}
			}
			return false;
		}

		public bool IsUndergoingMaintenance()
		{
			return _ambulanceItem.GetComponent<RoomItemMaintenanceComponent>() != null;
		}

		public bool IsUndergoingUpgrade()
		{
			return _ambulanceItem.GetComponent<RoomItemUpgradeComponent>() != null;
		}

		public override bool CanBeAssignedTo(ChallengeAmbulanceEmergency emergency, bool includeReassign)
		{
			bool flag = includeReassign && emergency == _queuedEmergency;
			if (!IsBrokenDown && !flag)
			{
				return base.CanBeAssignedTo(emergency, includeReassign);
			}
			return false;
		}

		public void QueueNewEmergency(ChallengeAmbulanceEmergency ambulanceEmergency)
		{
			if (_currentState == State.GettingReady && !StaffOnBoarding)
			{
				AbortTrip();
			}
			_queuedEmergency = ambulanceEmergency;
			_unassignOnReturn = false;
		}

		public void UnassignNowOrOnReturn(ChallengeAmbulanceEmergency ambulanceEmergency)
		{
			if (_currentState == State.GettingReady && !StaffOnBoarding)
			{
				AbortTrip();
			}
			_queuedEmergency = null;
			_unassignOnReturn = true;
		}

		public void OnPickup()
		{
			KickOutAllStaff();
			ResetAmbulanceToDefaults();
		}
	}
}
