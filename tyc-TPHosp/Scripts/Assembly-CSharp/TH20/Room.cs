#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace TH20
{
	public class Room : Entity, ICursorSelectable, IStatusIconEmitter, IMultipleHighlight
	{
		private readonly Level _level;

		private FloorPlan _floorPlan;

		private RoomFloorPlanVisual _roomVisual;

		private readonly List<Job> _jobs;

		private readonly List<StaffRequired> _staffJobs;

		private readonly List<StaffRequired> _staffOptionalJobs;

		private bool _highPriorityJobs;

		private readonly List<Character> _using;

		private readonly List<Character> _queueing;

		private readonly List<Staff> _staff;

		private readonly List<Staff> _assignedStaff;

		private WeightedList<StaffPatientInteraction> _staffPatientInteractions;

		private bool _isOpen = true;

		private bool _isMissingRequiredItems;

		private bool _isOperational;

		private int _totalRevenue;

		private int _unitsProcessed;

		private string _userSpecifiedName;

		[DontSave]
		private Material _roomOpenLightMaterial;

		[DontSave]
		private Cubemap _roomOpenReflectionCubemap;

		[DontSave]
		private Material _roomClosedLightMaterial;

		[DontSave]
		private Cubemap _roomClosedReflectionCubemap;

		[DontSave]
		private Material _roomOperationalLightMaterial;

		[DontSave]
		private Cubemap _roomOperationalReflectionCubemap;

		private int _numBrokenItems;

		private int _numBurningItems;

		[DontSave]
		private QueuePath _queuePath;

		private float _diagnosisMultiplier = 1f;

		private float _treatmentModifier;

		private InWorldMenuObject _activeMenu;

		private readonly WhoCanUseRoom _whoCanUse;

		private static List<Staff> _remainingStaffRequiredCache = new List<Staff>(8);

		public RoomDefinition Definition => GetDefinition<RoomDefinition>();

		public FloorPlan FloorPlan => _floorPlan;

		public RoomFloorPlanVisual FloorPlanVisual => _roomVisual;

		public int QueueLength
		{
			get
			{
				int num = _queueing.Count;
				foreach (RoomItem queueItem in _floorPlan.QueueItems)
				{
					num += queueItem.QueueLength;
				}
				return num;
			}
		}

		public Vector3 Center => new Vector3(_floorPlan.Anchor.X + _floorPlan.Width() / 2, 0f, _floorPlan.Anchor.Y + _floorPlan.Height() / 2);

		private bool ShowDebugInfo { get; set; }

		public bool IsOpen => _isOpen;

		public List<Staff> StaffMembers => _staff;

		public List<Character> CharactersUsing => _using;

		public QueuePath QueuePath => _queuePath;

		public List<StaffRequired> StaffJobs => _staffJobs;

		public List<Character> Queue => _queueing;

		public Character CharacterEntering { get; set; }

		public float DiagnosisMultiplier
		{
			get
			{
				return _diagnosisMultiplier;
			}
			set
			{
				_diagnosisMultiplier = value;
			}
		}

		public float TreatmentModifier
		{
			get
			{
				return _treatmentModifier;
			}
			set
			{
				_treatmentModifier = value;
			}
		}

		public WhoCanUseRoom WhoCanUse => _whoCanUse;

		public List<Staff> AssignedStaff => _assignedStaff;

		public List<Staff> StaffWorkingInRoom
		{
			get
			{
				List<Staff> result = new List<Staff>();
				GetStaffWorkingInRoom(result);
				return result;
			}
		}

		public int TotalRevenue => _totalRevenue;

		public int UnitsProcessed => _unitsProcessed;

		public List<Job> Jobs => _jobs;

		public bool HighPriorityJobs => _highPriorityJobs;

		public string GetRoomName()
		{
			if (string.IsNullOrEmpty(_userSpecifiedName))
			{
				return Definition.GetLocalisedName();
			}
			return _userSpecifiedName;
		}

		public void SetUserSpecifiedName(string userSpecifiedName)
		{
			_userSpecifiedName = userSpecifiedName;
		}

		public string GetUserSpecifiedName()
		{
			return _userSpecifiedName;
		}

		public void GetStaffWorkingInRoom(List<Staff> result)
		{
			foreach (Staff item in _assignedStaff)
			{
				if (item.RoomUsing == this)
				{
					result.Add(item);
				}
			}
		}

		public Room(RoomDefinition definition, Level level)
			: base(definition, level)
		{
			_level = level;
			_using = new List<Character>();
			_staff = new List<Staff>();
			_assignedStaff = new List<Staff>();
			_queueing = new List<Character>();
			_queuePath = new QueuePath();
			_jobs = new List<Job>();
			_staffJobs = new List<StaffRequired>();
			_staffOptionalJobs = new List<StaffRequired>();
			_whoCanUse = new WhoCanUseRoom(definition.WhoCanUseRoom);
			RegisterEvents();
			InitializeComponents();
		}

		public Room(Level level, FloorPlan floorPlan, RoomFloorPlanVisual visual)
			: this(floorPlan.Definition, level)
		{
			Initialise(floorPlan, visual);
		}

		public void Initialise(FloorPlan floorPlan, RoomFloorPlanVisual visual)
		{
			Cleanup();
			_roomVisual = visual;
			_floorPlan = floorPlan;
			_floorPlan.OwningRoom = this;
			_queuePath.FloorPlan = _floorPlan;
			_level.QueuePathManager.Add(_queuePath);
			if (!floorPlan.Definition.IsHospitalOrBay && !floorPlan.Definition.IsHospitalUnbuilt)
			{
				_queuePath.CalculateQueue();
			}
			if (Definition._staffPatientInteractions != null)
			{
				_staffPatientInteractions = new WeightedList<StaffPatientInteraction>();
				StaffPatientInteraction[] staffPatientInteractions = Definition._staffPatientInteractions;
				foreach (StaffPatientInteraction staffPatientInteraction in staffPatientInteractions)
				{
					_staffPatientInteractions.Add(staffPatientInteraction, staffPatientInteraction.Weight);
				}
			}
			_staffJobs.Clear();
			_staffOptionalJobs.Clear();
			if (Definition._requiresStaff != null)
			{
				StaffRequired[] requiresStaff = Definition._requiresStaff;
				foreach (StaffRequired staffRequired in requiresStaff)
				{
					AddStaffJob(staffRequired);
				}
			}
			GetComponent<RoomExtraStaffJobsComponent>()?.AddOptionalJobsToRoom(this);
			_roomOpenLightMaterial = ((Definition._roomLightMaterial != null) ? new Material(Definition._roomLightMaterial) : null);
			_roomOpenReflectionCubemap = Definition._roomReflectionCubemap;
			_roomClosedLightMaterial = ((Definition._roomClosedLightMaterial != null) ? new Material(Definition._roomClosedLightMaterial) : null);
			_roomClosedReflectionCubemap = Definition._roomClosedReflectionCubemap;
			_roomOperationalLightMaterial = ((Definition._roomOperationalLightMaterial != null) ? new Material(Definition._roomOperationalLightMaterial) : null);
			_roomOperationalReflectionCubemap = Definition._roomOperationalReflectionCubemap;
		}

		public override void RestoreFromSave()
		{
			if (_floorPlan == null)
			{
				Logging.Error("Room restored with null _floorPlan; must have been broken before save");
				Level level = _level;
				level.PostConstruct = (System.Action)Delegate.Combine(level.PostConstruct, (System.Action)delegate
				{
					_level.WorldState.RemoveRoom(this, affectNavigation: false);
					Destroy();
				});
				return;
			}
			EntityComponent[] components = Definition.Components;
			for (int num = 0; num < components.Length; num++)
			{
				if (components[num] is RoomUseTypeComponent)
				{
					if (GetComponent<RoomUseTypeComponent>() == null)
					{
						AddComponent<RoomUseTypeComponent>();
					}
					break;
				}
			}
			_assignedStaff.RemoveDuplicates();
			_queuePath = new QueuePath
			{
				FloorPlan = _floorPlan
			};
			Level level2 = _level;
			level2.PostConstruct = (System.Action)Delegate.Combine(level2.PostConstruct, (System.Action)delegate
			{
				_queuePath.CalculateQueue();
			});
			_level.QueuePathManager.Add(_queuePath);
			_roomOpenLightMaterial = ((Definition._roomLightMaterial != null) ? new Material(Definition._roomLightMaterial) : null);
			_roomOpenReflectionCubemap = Definition._roomReflectionCubemap;
			_roomClosedLightMaterial = ((Definition._roomClosedLightMaterial != null) ? new Material(Definition._roomClosedLightMaterial) : null);
			_roomClosedReflectionCubemap = Definition._roomClosedReflectionCubemap;
			_roomOperationalLightMaterial = ((Definition._roomOperationalLightMaterial != null) ? new Material(Definition._roomOperationalLightMaterial) : null);
			_roomOperationalReflectionCubemap = Definition._roomOperationalReflectionCubemap;
			_floorPlan.RestoreFromSave();
			_roomVisual.RestoreFromSave(_level.WorldState, _level);
			RoomItemAlgorithms.RefreshInvalidItemBounds(_floorPlan);
			RegisterEvents();
			if (!Definition.IsHospitalOrBay && !Definition.IsHospitalUnbuilt && !_level.Metagame.HasUnlocked(Definition))
			{
				Logging.Warning(LogChannels.AI, "Room {0} is placed in the level but not unlocked, fixing!", this);
				_level.Metagame.UnlockItem(Definition, spendSilver: false, showMessage: false);
			}
			if (_numBurningItems != 0)
			{
				_numBurningItems = CalculateNumberOfBurningItems();
			}
			base.RestoreFromSave();
		}

		private void Cleanup()
		{
			if (_floorPlan != null)
			{
				_floorPlan.Destroy();
			}
			if (_roomVisual != null)
			{
				_roomVisual.Destroy();
			}
			if (_roomOpenLightMaterial != null)
			{
				UnityEngine.Object.Destroy(_roomOpenLightMaterial);
			}
			if (_roomClosedLightMaterial != null)
			{
				UnityEngine.Object.Destroy(_roomClosedLightMaterial);
			}
			if (_roomOperationalLightMaterial != null)
			{
				UnityEngine.Object.Destroy(_roomOperationalLightMaterial);
			}
			_roomOpenLightMaterial = null;
			_roomClosedLightMaterial = null;
			_roomOperationalLightMaterial = null;
		}

		public override void Destroy()
		{
			Cleanup();
			UnregisterEvents();
			_level.QueuePathManager.Remove(_queuePath);
			if (base.Level.StatusIconManager != null)
			{
				base.Level.StatusIconManager.DestroyStatusIcon(this);
			}
			base.Destroy();
		}

		private void RegisterEvents()
		{
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomItemOnFire = (Action<RoomItem, RoomItemFlammableComponent>)Delegate.Combine(buildEvents.OnRoomItemOnFire, new Action<RoomItem, RoomItemFlammableComponent>(OnRoomItemOnFire));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnRoomItemExtinguished = (Action<RoomItem>)Delegate.Combine(buildEvents2.OnRoomItemExtinguished, new Action<RoomItem>(OnRoomItemExtinguished));
			BuildEvents buildEvents3 = _level.BuildEvents;
			buildEvents3.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents3.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents4 = _level.BuildEvents;
			buildEvents4.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents4.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffPickup = (Action<Staff, JobApplicant>)Delegate.Combine(characterEvents.OnStaffPickup, new Action<Staff, JobApplicant>(OnStaffPickup));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnStaffDestroyed = (Action<Staff>)Delegate.Combine(characterEvents2.OnStaffDestroyed, new Action<Staff>(OnDestroyStaff));
			CharacterEvents characterEvents3 = _level.CharacterEvents;
			characterEvents3.OnPatientDestroyed = (Action<Patient>)Delegate.Combine(characterEvents3.OnPatientDestroyed, new Action<Patient>(OnDestroyCharacter));
		}

		private void UnregisterEvents()
		{
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomItemOnFire = (Action<RoomItem, RoomItemFlammableComponent>)Delegate.Remove(buildEvents.OnRoomItemOnFire, new Action<RoomItem, RoomItemFlammableComponent>(OnRoomItemOnFire));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnRoomItemExtinguished = (Action<RoomItem>)Delegate.Remove(buildEvents2.OnRoomItemExtinguished, new Action<RoomItem>(OnRoomItemExtinguished));
			BuildEvents buildEvents3 = _level.BuildEvents;
			buildEvents3.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents3.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents4 = _level.BuildEvents;
			buildEvents4.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents4.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffPickup = (Action<Staff, JobApplicant>)Delegate.Remove(characterEvents.OnStaffPickup, new Action<Staff, JobApplicant>(OnStaffPickup));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnStaffDestroyed = (Action<Staff>)Delegate.Remove(characterEvents2.OnStaffDestroyed, new Action<Staff>(OnDestroyStaff));
			CharacterEvents characterEvents3 = _level.CharacterEvents;
			characterEvents3.OnPatientDestroyed = (Action<Patient>)Delegate.Remove(characterEvents3.OnPatientDestroyed, new Action<Patient>(OnDestroyCharacter));
		}

		public override string ToString()
		{
			if (_roomVisual == null || !(_roomVisual.GameObject != null))
			{
				return "[DESTROYED]";
			}
			return _roomVisual.GameObject.name;
		}

		public RoomItem GetFirstItemOfType(RoomItemDefinition.Type type)
		{
			return _floorPlan.GetFirstItemOfType(type);
		}

		public RoomItem GetFirstItemOfType(RoomItemDefinition definition)
		{
			return _floorPlan.GetFirstItemOfType(definition);
		}

		public void RemainingStaffRequired(List<StaffRequired> remainingStaff)
		{
			remainingStaff.Clear();
			_remainingStaffRequiredCache.AddRange(_assignedStaff);
			foreach (StaffRequired staffJob in _staffJobs)
			{
				bool flag = false;
				foreach (Staff item in _remainingStaffRequiredCache)
				{
					if (item.CurrentMode == Staff.Mode.Work && item.CurrentJob != null && item.CurrentJob.IsInRoom(this) && staffJob.IsSuitable(item))
					{
						flag = true;
						_remainingStaffRequiredCache.Remove(item);
						break;
					}
				}
				if (!flag)
				{
					remainingStaff.Add(staffJob);
				}
			}
			_remainingStaffRequiredCache.Clear();
		}

		public int NumStaffWorkingInRoom(Staff exclude = null)
		{
			int num = 0;
			foreach (Staff item in _assignedStaff)
			{
				if (item != exclude && item.CurrentMode == Staff.Mode.Work && item.RoomUsing == this)
				{
					num++;
				}
			}
			return num;
		}

		public bool IsStaffed()
		{
			int num = NumStaffWorkingInRoom();
			if (num < _staffJobs.Count)
			{
				if (Definition.MinimumStaffCount != 0)
				{
					return num >= Definition.MinimumStaffCount;
				}
				return false;
			}
			return true;
		}

		public bool IsFullyStaffed(Staff exclude = null)
		{
			return NumStaffWorkingInRoom(exclude) >= _staffJobs.Count;
		}

		public bool RequiredStaffAssigned()
		{
			int count = _assignedStaff.Count;
			if (count < _staffJobs.Count)
			{
				if (Definition.MinimumStaffCount != 0)
				{
					return count >= Definition.MinimumStaffCount;
				}
				return false;
			}
			return true;
		}

		public int NumPeopleUsing()
		{
			return _using.Count + ((CharacterEntering != null) ? 1 : 0);
		}

		public int NumPeopleUsing<T>()
		{
			int num = 0;
			if (CharacterEntering is T)
			{
				num++;
			}
			foreach (Character item in _using)
			{
				if (item is T)
				{
					num++;
				}
			}
			return num;
		}

		public bool ArePatientsInRoom()
		{
			return NumPeopleUsing<Patient>() > 0;
		}

		public bool CanPatientBeAccepted(Patient patient)
		{
			if (Definition._type != RoomDefinition.Type.TimeTunnel)
			{
				return true;
			}
			RoomTimeTunnelComponent component = GetComponent<RoomTimeTunnelComponent>();
			AnachronisticTreatmentComponent component2 = patient.GetComponent<AnachronisticTreatmentComponent>();
			if (component2 != null && component != null && component.IsEraTypeValid(component2.EraType))
			{
				return true;
			}
			return false;
		}

		public bool AttemptRoomPreparation(Patient patient)
		{
			if (Definition._type != RoomDefinition.Type.TimeTunnel)
			{
				return true;
			}
			RoomTimeTunnelComponent component = GetComponent<RoomTimeTunnelComponent>();
			AnachronisticTreatmentComponent component2 = patient.GetComponent<AnachronisticTreatmentComponent>();
			if (component2 != null && component != null)
			{
				IllnessEraType eraType = component2.EraType;
				float num = _level.CharacterManager.GetAnachronisticManager().GetEraSwitchTime(eraType);
				foreach (Staff item in StaffWorkingInRoom)
				{
					num -= item.GetDurationReduction(this);
					if (component.SwitchEra(eraType, num))
					{
						return true;
					}
				}
			}
			return false;
		}

		public TaskStatus GetRoomPreparationStatus()
		{
			if (Definition._type != RoomDefinition.Type.TimeTunnel)
			{
				return TaskStatus.Inactive;
			}
			bool flag = false;
			RoomTimeTunnelComponent component = GetComponent<RoomTimeTunnelComponent>();
			if (component != null)
			{
				flag = component.IsSwitchingEra();
			}
			if (!flag)
			{
				return TaskStatus.Success;
			}
			return TaskStatus.Running;
		}

		private bool IsJanitorWorkingInRoom(Character character)
		{
			if (character is Staff staff && staff.Definition._type == StaffDefinition.Type.Janitor)
			{
				if (staff.CurrentJob != null)
				{
					return staff.CurrentJob.IsInRoom(this);
				}
				return false;
			}
			return false;
		}

		public bool IsAtMaxCapacity()
		{
			int num = 0;
			if (CharacterEntering != null && !IsJanitorWorkingInRoom(CharacterEntering))
			{
				num++;
			}
			foreach (Character item in _using)
			{
				if (!IsJanitorWorkingInRoom(item))
				{
					num++;
				}
			}
			return num >= _floorPlan.MaxCapacity;
		}

		public bool IsStaffMember(Staff staff)
		{
			return _staff.Contains(staff);
		}

		public bool CanAddStaff(Staff staff)
		{
			if (!_isOpen)
			{
				return false;
			}
			if (Definition.AlwaysAddStaff())
			{
				return true;
			}
			if (!CanWorkInRoom(staff))
			{
				return false;
			}
			if (!IsStaffMember(staff) && IsFullyStaffed(staff))
			{
				List<string> list = new List<string>();
				foreach (Staff item in _staff)
				{
					list.Add(item.ToString());
				}
				return false;
			}
			return true;
		}

		private bool CanWorkInRoom(Staff staff)
		{
			foreach (StaffRequired staffJob in _staffJobs)
			{
				if (staffJob.IsSuitable(staff))
				{
					return true;
				}
			}
			return false;
		}

		private bool StaffUseRoom(Staff staff)
		{
			if (CanAddStaff(staff))
			{
				_staff.AddUnique(staff);
				return true;
			}
			return false;
		}

		public void StaffLeaveRoom(Staff staff)
		{
			if (_staff.Remove(staff))
			{
				Job currentJob = staff.CurrentJob;
				if (currentJob != null && currentJob.IsInRoom(this))
				{
					currentJob.MakeAvailable();
				}
				if (!IsStaffed())
				{
					RoomUnstaffed();
				}
			}
		}

		private void OnStaffPickup(Staff staff, JobApplicant applicant)
		{
			if (staff.RoomUsing == this)
			{
				ExitRoom(staff);
			}
		}

		private void OnDestroyStaff(Staff staff)
		{
			if (staff.RoomUsing == this)
			{
				ExitRoom(staff);
			}
			_assignedStaff.Remove(staff);
			OnDestroyCharacter(staff);
		}

		private void OnDestroyCharacter(Character character)
		{
			if (_using.Contains(character))
			{
				ExitRoom(character);
			}
			if (_queueing.Contains(character))
			{
				RemoveFromQueue(character);
			}
			if (character == CharacterEntering)
			{
				CharacterEntering = null;
				character.CalledIntoRoom = false;
			}
		}

		private void RoomUnstaffed()
		{
			if (Definition.EvictUsersWhenUnstaffed())
			{
				if (CharacterEntering is Patient)
				{
					CharacterEntering.CalledIntoRoom = false;
					CharacterEntering.EvictedFromRoom(this);
					CharacterEntering = null;
				}
				for (int num = _using.Count - 1; num >= 0; num--)
				{
					if (num < _using.Count)
					{
						Character character = _using[num];
						if (character is Patient)
						{
							character.EvictedFromRoom(this);
						}
					}
				}
				for (int num2 = _staff.Count - 1; num2 >= 0; num2--)
				{
					if (num2 < _staff.Count)
					{
						Staff staff = _staff[num2];
						if (staff.CurrentMode != Staff.Mode.Break)
						{
							BehaviorManager.instance.RestartBehavior(staff.BehaviorTree);
						}
					}
				}
			}
			if (base.Level.StatusIconManager != null)
			{
				base.Level.StatusIconManager.ShowStatusIcon(this, StatusIcon.Type.StaffRequired);
			}
		}

		public void AddToQueue(Character character, int queueIndex = -1)
		{
			if (!_isOpen)
			{
				return;
			}
			bool num = _level.CharacterManager.GetAliensManager() != null;
			bool flag = character is Patient;
			bool flag2 = num && flag && _level.CharacterManager.GetAliensManager().Aliens.Contains(character as Patient);
			if ((character.QueuingAtRoom == null || character.QueuingAtRoom == this || !character.QueuingAtRoom.Definition._hasQueue) && (!flag2 || character.RoomCalledInto != this))
			{
				if (queueIndex != -1 && _queueing.Contains(character))
				{
					_queueing.Remove(character);
				}
				if (queueIndex != -1 && queueIndex < _queueing.Count)
				{
					_queueing.Insert(queueIndex, character);
				}
				else
				{
					_queueing.AddUnique(character);
				}
				character.QueuingAtRoom = this;
				base.Level.StatusIconManager.ShowStatusIcon(this, StatusIcon.Type.StaffRequired);
			}
			else if (character.QueuingAtRoom == null)
			{
				_ = character.RoomCalledInto;
			}
		}

		public void RemoveFromQueue(Character character)
		{
			if (character == CharacterEntering)
			{
				CharacterEntering.CalledIntoRoom = false;
				CharacterEntering = null;
			}
			if (_queueing.Remove(character))
			{
				if (character.QueuingAtRoom == this)
				{
					character.QueuingAtRoom = null;
				}
				character.GoingToRoomSetByPlayer = false;
			}
		}

		public void MoveCharacterToQueuePos(Character character, int reqdQueueIndex = 0)
		{
			if (reqdQueueIndex < 0 || reqdQueueIndex >= _queueing.Count || !_queueing.Contains(character))
			{
				return;
			}
			int num = PositionInQueue(character);
			if (reqdQueueIndex != num)
			{
				_queueing.Remove(character);
				if (reqdQueueIndex > num)
				{
					reqdQueueIndex--;
				}
				_queueing.Insert(reqdQueueIndex, character);
			}
		}

		public bool EnterRoom(Character character, ReasonUseRoom reason)
		{
			if (Definition.IsHospitalOrBay)
			{
				return true;
			}
			if (character == CharacterEntering)
			{
				CharacterEntering.CalledIntoRoom = false;
				CharacterEntering = null;
			}
			if (character.RoomUsing != this && FloorPlan.Door != null && FloorPlan.Door.Interactions.Count != 0)
			{
				character.Position = FloorPlan.Door.WorldPosition;
				character.RotationY = FloorPlan.Door.WorldRotation + 180f;
				character.NavPath.Warp(character.Position);
				character.ForceUpdateRoomUsing(this);
			}
			if (!_isOpen && reason != ReasonUseRoom.Maintenance && reason != ReasonUseRoom.Visit)
			{
				return false;
			}
			bool flag = reason == ReasonUseRoom.Work && character is Staff;
			if (flag && !StaffUseRoom((Staff)character))
			{
				return false;
			}
			RemoveFromQueue(character);
			_level.CharacterEvents.OnPlanToEnterRoom.InvokeSafe(character, this);
			if (!flag)
			{
				if ((reason != ReasonUseRoom.Diagnosis && reason != ReasonUseRoom.Treatment) || IsStaffed())
				{
					_using.AddUnique(character);
				}
				else
				{
					character.ReturnToRoomQueue();
				}
			}
			return true;
		}

		public void ExitRoom(Character character)
		{
			if (!Definition.IsHospitalOrBay)
			{
				if (character is Staff staff)
				{
					StaffLeaveRoom(staff);
				}
				_using.Remove(character);
				_level.CharacterEvents.OnPlanToExitRoom.InvokeSafe(character, this);
			}
		}

		public bool IsFrontOfQueue(Character character)
		{
			if (_queueing.IndexOf(character) == 0)
			{
				return true;
			}
			return false;
		}

		public int PositionInQueue(Character character)
		{
			return _queueing.IndexOf(character);
		}

		public int PositionToStandInQueue(Character character)
		{
			int num = 0;
			for (int i = 0; i < _queueing.Count; i++)
			{
				Character character2 = _queueing[i];
				if (character2 == character)
				{
					return num;
				}
				if (character2.StandInQueue)
				{
					num++;
				}
			}
			return -1;
		}

		public void DebugGUI()
		{
			if (!ShowDebugInfo || Definition.IsHospitalOrBay)
			{
				return;
			}
			GUIStyle gUIStyle = new GUIStyle(GUI.skin.box);
			Vector3 position = _floorPlan.WorldBounds.Center.ToWorldPosition() + Vector3.up * 2f;
			Vector3 vector = Camera.main.WorldToScreenPoint(position);
			string text = ToString();
			if (_staff.Count != 0)
			{
				text += "\nStaff:";
				foreach (Staff item in _staff)
				{
					text = text + "\n" + item;
				}
			}
			List<StaffRequired> list = new List<StaffRequired>();
			RemainingStaffRequired(list);
			if (list.Count != 0)
			{
				text += "\nStaff needed:";
				foreach (StaffRequired item2 in list)
				{
					text = text + "\n" + item2;
				}
			}
			text = text + "\nMax capacity: " + _floorPlan.MaxCapacity;
			if (_using.Count != 0)
			{
				foreach (Character item3 in _using)
				{
					text += $"\n{item3} is using room for {item3.ReasonUsingRoom}";
				}
			}
			if (CharacterEntering != null)
			{
				text += $"\nEntering: {CharacterEntering}";
			}
			if (_queueing.Count != 0)
			{
				text += "\n";
				foreach (Character item4 in _queueing)
				{
					text += $"\n{item4} is in queue";
				}
			}
			WhoCanUseRoom.GroupDefinition[] definition = _whoCanUse.Definition;
			if (definition != null)
			{
				string text2 = string.Empty;
				for (int i = 0; i < definition.Length; i++)
				{
					WhoCanUseRoom.GroupDefinition groupDefinition = definition[i];
					for (int j = 0; j < groupDefinition.Members.Length; j++)
					{
						WhoCanUseRoom.MemberType member = _whoCanUse.GetMember(i, j);
						if (_whoCanUse.IsMember(i, j))
						{
							text2 += " ";
							text2 += member;
						}
					}
				}
				text += $"\nWho can use:{text2}";
			}
			text += (IsFunctional() ? "\nFunctional" : "\nNot functional");
			text += $"\nBroken Items: {_numBrokenItems}   Burning Items: {_numBurningItems}   Missing RequiredItems: {_isMissingRequiredItems}";
			if (_staff.Count != 0 && _using.Count != 0)
			{
				Patient patient = _using.Find((Character character) => character is Patient) as Patient;
				Staff staff = GameAlgorithms.FindStaffLikelyToSeePatient(this);
				if (patient != null && staff != null)
				{
					if (patient.ReasonUsingRoom == ReasonUseRoom.Treatment)
					{
						TreatmentCalculationBreakdown treatmentCalculationBreakdown = GameAlgorithms.CalculateEstimatedTreatmentOutcome(patient, staff, this);
						text += "\n\n<b>Treatment Breakdown</b>";
						text += $"\nChance Of Success = {treatmentCalculationBreakdown.ChanceOfSuccess:0.00}%";
						text += $"\nDiagnosis Certainty = {treatmentCalculationBreakdown.DiagnosisCertainty:0.00}%";
						text += $"\nStaff Skill = {treatmentCalculationBreakdown.StaffSkill:0.00}%";
						text += $"\nRoom Modifiers = {treatmentCalculationBreakdown.RoomModifiers:0.00}%";
						text += $"\nMin Effectiveness = {treatmentCalculationBreakdown.MinTreatmentEffectiveness:0.00}%";
						text += $"\nMax Effectiveness = {treatmentCalculationBreakdown.MaxTreatmentEffectiveness:0.00}%";
					}
					else if (patient.ReasonUsingRoom == ReasonUseRoom.Diagnosis)
					{
						DiagnosisCalculationBreakdown diagnosisCertainty = GameAlgorithms.GetDiagnosisCertainty(patient, this, staff, _level.ResearchManager);
						text += "\n\n<b>Diagnosis Breakdown</b>";
						text += $"\nCertainty Increase = +{diagnosisCertainty.Certainty:0.00}%";
						text += $"\nBase Illness = +{diagnosisCertainty.Illness:0.00}%";
						text += $"\nStaff Skill Multiplier = {diagnosisCertainty.StaffMultiplier:0.00}";
						text += $"\nRoom Multiplier = {diagnosisCertainty.RoomMultiplier:0.00}";
						text += $"\nItems Multiplier = {diagnosisCertainty.ItemMultiplier:0.00}";
						text += $"\nRevist GP Multiplier = {diagnosisCertainty.RevistGP:0.00}";
						text += $"\nUpgrade Multiplier = {diagnosisCertainty.UpgradeMultiplier:0.00}";
					}
				}
			}
			Vector2 vector2 = gUIStyle.CalcSize(new GUIContent(text));
			GUI.Box(new Rect(vector.x - vector2.x / 2f, (float)Screen.height - vector.y - vector2.y, vector2.x, vector2.y), text, gUIStyle);
			_queuePath.DebugDraw();
			DebugDrawUtils.Bounds(FloorPlan.WorldBounds, Color.white);
		}

		public bool CanBeOpened()
		{
			bool result = true;
			if (!Definition.IsHospitalOrBay && !Definition.IsHospitalUnbuilt)
			{
				List<ChallengeElectricity> activeChallengesOfType = _level.ChallengeManager.GetActiveChallengesOfType<ChallengeElectricity>();
				if (activeChallengesOfType.Count > 0)
				{
					using List<ChallengeElectricity>.Enumerator enumerator = activeChallengesOfType.GetEnumerator();
					if (enumerator.MoveNext())
					{
						result = (enumerator.Current.HasSpareAllocation() ? true : false);
					}
				}
			}
			return result;
		}

		public void Open()
		{
			if (CanBeOpened())
			{
				_isOpen = true;
				base.Level.BuildEvents.OnRoomOpened.InvokeSafe(this);
			}
		}

		public void Close()
		{
			_isOpen = false;
			if (CharacterEntering != null)
			{
				CharacterEntering.CalledIntoRoom = false;
				CharacterEntering = null;
			}
			base.Level.BuildEvents.OnRoomClosed.InvokeSafe(this);
		}

		public bool IsSelectable()
		{
			if (IsInBoughtPlot())
			{
				return !Definition.IsHospitalOrBay;
			}
			return true;
		}

		public bool HasTooltip()
		{
			return true;
		}

		public bool CanHighlight()
		{
			return !Definition.IsHospitalUnbuilt;
		}

		public void ToggleDebugInfo()
		{
			ShowDebugInfo = !ShowDebugInfo;
		}

		public Renderer GetHighlightGameObject()
		{
			return null;
		}

		void IMultipleHighlight.GetMultipleHighlightGameObjects(List<Renderer> renderers)
		{
			_roomVisual.GetHightlightWallFloorRenderers(renderers);
			foreach (RoomItem item in _floorPlan.Items)
			{
				if (item.Definition.ItemSize == RoomItemDefinition.Size.Large || item.Definition.ItemType == RoomItemDefinition.Type.Window)
				{
					item.Visual.GetHighlightRenderers(renderers);
				}
			}
		}

		public Vector3 GetMenuAnchorPosition()
		{
			return _floorPlan.WorldBounds.Center.ToWorldPosition() + Vector3.up * 1.5f;
		}

		public Vector3 GetStatusIconPosition()
		{
			return _floorPlan.WorldBounds.Center.ToWorldPosition() + Vector3.up * 1.5f;
		}

		public bool IsStatusIconEmitterVisible()
		{
			if (FloorPlanVisual != null)
			{
				return FloorPlanVisual.IsVisible();
			}
			return false;
		}

		public GameObject GetCameraTrackObject()
		{
			if (FloorPlanVisual == null)
			{
				return null;
			}
			return FloorPlanVisual.GameObject;
		}

		public bool CanDragHoldSelect()
		{
			return false;
		}

		public void SetActiveMenu(InWorldMenuObject menu)
		{
			_activeMenu = menu;
		}

		public InWorldMenuObject GetActiveMenu()
		{
			return _activeMenu;
		}

		public void SetVisible(bool visible)
		{
			FloorPlanVisual.SetVisible(visible);
			base.Level.BuildEvents.OnRoomVisibilityChanged.InvokeSafe(this, visible);
		}

		public bool IsVisible()
		{
			return FloorPlanVisual.IsVisible();
		}

		public bool IsFunctional()
		{
			if (_numBrokenItems == 0 && _numBurningItems == 0)
			{
				return !_isMissingRequiredItems;
			}
			return false;
		}

		public bool HasValidRequiredItems()
		{
			return _floorPlan.HasValidRequiredItems;
		}

		public bool GetMissingRequiredItem(out IRoomItemDefinition missing)
		{
			List<RoomItem> items = _floorPlan.Items;
			RequiredItem[] requiredItemsNew = _floorPlan.Definition._requiredItemsNew;
			foreach (RequiredItem requiredItem in requiredItemsNew)
			{
				bool flag = false;
				foreach (RoomItem item in items)
				{
					if (requiredItem.Contains(item.Definition))
					{
						flag = true;
					}
				}
				if (!flag)
				{
					missing = requiredItem.Items[0].Instance;
					return true;
				}
			}
			missing = null;
			return false;
		}

		internal void OnItemBrokeDown(RoomItem roomItem)
		{
			if (Definition.RequiresWorkingItem(roomItem.Definition))
			{
				_numBrokenItems++;
			}
		}

		internal void OnItemRepaired(RoomItem roomItem)
		{
			if (_numBrokenItems > 0 && Definition.RequiresWorkingItem(roomItem.Definition))
			{
				_numBrokenItems--;
			}
		}

		public StaffPatientInteraction ChooseStaffPatientInteraction()
		{
			if (_staffPatientInteractions == null)
			{
				return null;
			}
			return _staffPatientInteractions.Choose(null, RandomUtils.GlobalRandomInstance);
		}

		private void AddStaffJob(StaffRequired staffRequired)
		{
			_staffJobs.Add(staffRequired);
		}

		public void AddOptionalStaffJob(StaffRequired staffRequired)
		{
			_staffJobs.Add(staffRequired);
			_staffOptionalJobs.Add(staffRequired);
		}

		public void RemoveOptionalStaffJob(StaffRequired staffRequired)
		{
			_staffJobs.Remove(staffRequired);
			_staffOptionalJobs.Remove(staffRequired);
		}

		public bool IsOptionalStaffRequired(StaffRequired staffRequired)
		{
			return _staffOptionalJobs.Contains(staffRequired);
		}

		public Job CreateJob(StaffRequired staffRequired)
		{
			RoomLogic component = GetComponent<RoomLogic>();
			if (component == null)
			{
				return new JobRoom(staffRequired, this);
			}
			return component.CreateJob(staffRequired);
		}

		public void ReloadRoomLights()
		{
			if (_roomOpenLightMaterial != null)
			{
				UnityEngine.Object.Destroy(_roomOpenLightMaterial);
			}
			if (_roomClosedLightMaterial != null)
			{
				UnityEngine.Object.Destroy(_roomClosedLightMaterial);
			}
			if (_roomOperationalLightMaterial != null)
			{
				UnityEngine.Object.Destroy(_roomOperationalLightMaterial);
			}
			_roomOpenLightMaterial = ((Definition._roomLightMaterial != null) ? new Material(Definition._roomLightMaterial) : null);
			_roomClosedLightMaterial = ((Definition._roomClosedLightMaterial != null) ? new Material(Definition._roomClosedLightMaterial) : null);
			_roomOperationalLightMaterial = ((Definition._roomOperationalLightMaterial != null) ? new Material(Definition._roomOperationalLightMaterial) : null);
		}

		public void SetRoomOperational(bool operational)
		{
			_isOperational = operational;
			base.Level.BuildEvents.OnRoomLightingChanged.InvokeSafe(this);
		}

		public Material GetRoomLightMaterial(Material defaultOpenMaterial, Material defaultClosedMaterial)
		{
			if (!_isOpen)
			{
				if (!(_roomClosedLightMaterial != null))
				{
					return defaultClosedMaterial;
				}
				return _roomClosedLightMaterial;
			}
			if (_isOperational)
			{
				if (!(_roomOperationalLightMaterial != null))
				{
					return defaultOpenMaterial;
				}
				return _roomOperationalLightMaterial;
			}
			if (!(_roomOpenLightMaterial != null))
			{
				return defaultOpenMaterial;
			}
			return _roomOpenLightMaterial;
		}

		public Cubemap GetRoomReflectionCubeMap(Cubemap defaultOpenCubemap, Cubemap defaultClosedCubemap)
		{
			if (!_isOpen)
			{
				if (!(_roomClosedReflectionCubemap != null))
				{
					return defaultClosedCubemap;
				}
				return _roomClosedReflectionCubemap;
			}
			if (_isOperational)
			{
				if (!(_roomOperationalReflectionCubemap != null))
				{
					return defaultOpenCubemap;
				}
				return _roomOperationalReflectionCubemap;
			}
			if (!(_roomOpenReflectionCubemap != null))
			{
				return defaultOpenCubemap;
			}
			return _roomOpenReflectionCubemap;
		}

		public void OnRevenueEarned(int amount)
		{
			_totalRevenue += amount;
		}

		public void OnUnitProcessed()
		{
			_unitsProcessed++;
		}

		private bool IsItemBurningInThisRoom(RoomItem roomItem)
		{
			if (roomItem.OwningRoom == this && roomItem.Definition.ItemType != RoomItemDefinition.Type.Special)
			{
				return roomItem.Definition.ItemType != RoomItemDefinition.Type.PlotObject;
			}
			return false;
		}

		private int CalculateNumberOfBurningItems()
		{
			int num = 0;
			foreach (RoomItem item in _floorPlan.Items)
			{
				if (IsItemBurningInThisRoom(item))
				{
					RoomItemFlammableComponent component = item.GetComponent<RoomItemFlammableComponent>();
					if (component != null && component.IsOnFire)
					{
						num++;
					}
				}
			}
			return num;
		}

		private void OnRoomItemOnFire(RoomItem roomItem, RoomItemFlammableComponent flammableComponent)
		{
			roomItem.EndAllInteractions(immediately: true);
			_numBurningItems = CalculateNumberOfBurningItems();
		}

		private void OnRoomItemExtinguished(RoomItem roomItem)
		{
			_numBurningItems = CalculateNumberOfBurningItems();
		}

		private void OnRoomItemAdded(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (roomItem.OwningRoom != this)
			{
				return;
			}
			if (((roomItem.MaintenanceLevel != null) ? roomItem.MaintenanceLevel.Value() : 0f) >= 100f && Definition.RequiresWorkingItem(roomItem.Definition))
			{
				_numBrokenItems++;
			}
			if (!_isMissingRequiredItems)
			{
				return;
			}
			List<RoomItem> items = _floorPlan.Items;
			RequiredItem[] requiredItems = _floorPlan.Definition.GetRequiredItems();
			foreach (RequiredItem requiredItem in requiredItems)
			{
				bool flag = false;
				foreach (RoomItem item in items)
				{
					if (requiredItem.Contains(item.Definition))
					{
						flag = true;
					}
				}
				if (!flag)
				{
					return;
				}
			}
			_isMissingRequiredItems = false;
		}

		private void OnRoomItemRemoved(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (roomItem.OwningRoom != this || roomItem.Definition.ItemType == RoomItemDefinition.Type.Door || roomItem.Definition.ItemType == RoomItemDefinition.Type.Window)
			{
				return;
			}
			if (Definition.IsRequiredItem(roomItem.Definition))
			{
				bool flag = false;
				List<RoomItem> items = _floorPlan.Items;
				RequiredItem[] requiredItems = _floorPlan.Definition.GetRequiredItems();
				foreach (RequiredItem requiredItem in requiredItems)
				{
					foreach (RoomItem item in items)
					{
						if (requiredItem.Contains(item.Definition))
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						break;
					}
				}
				if (!flag)
				{
					_isMissingRequiredItems = true;
					base.Level.BuildEvents.OnRoomMissingRequiredItem.InvokeSafe(this);
				}
			}
			if (((roomItem.MaintenanceLevel != null) ? roomItem.MaintenanceLevel.Value() : 0f) >= 100f && Definition.RequiresWorkingItem(roomItem.Definition))
			{
				_numBrokenItems--;
			}
		}

		public void ShowQueuePositions()
		{
			if (!Definition._hasQueue)
			{
				return;
			}
			foreach (Character item in Queue)
			{
				base.Level.StatusIconManager.ShowStatusIcon(item, StatusIcon.Type.QueuePosition);
			}
			if (CharacterEntering != null)
			{
				base.Level.StatusIconManager.ShowStatusIcon(CharacterEntering, StatusIcon.Type.QueuePosition);
			}
		}

		public void Debug_SetMissingRequiredItems(bool missing)
		{
			_isMissingRequiredItems = missing;
		}

		public bool CanLeaveWork(Staff staff)
		{
			if (staff.IsInteractingWithRoomDoor())
			{
				return false;
			}
			if (Definition.IsHospitalOrBay)
			{
				return true;
			}
			if (Definition._type == RoomDefinition.Type.Training || Definition._type == RoomDefinition.Type.Research || Definition._type == RoomDefinition.Type.Marketing)
			{
				return true;
			}
			if (NumPeopleUsing<Patient>() == 0)
			{
				return true;
			}
			if (NumStaffWorkingInRoom(staff) >= _staffJobs.Count - _staffOptionalJobs.Count)
			{
				return true;
			}
			return false;
		}

		public void AddJob(Job job)
		{
			_jobs.Add(job);
			if (_highPriorityJobs && !job.HighPriority)
			{
				job.BecomeHighPriority();
			}
		}

		public void RemoveJob(Job job)
		{
			_jobs.Remove(job);
		}

		public void SetHighPriorityJobs(bool highPriority)
		{
			_highPriorityJobs = highPriority;
			foreach (Job job in _jobs)
			{
				if (highPriority)
				{
					job.BecomeHighPriority();
				}
				else
				{
					job.BecomeNormalPriority();
				}
			}
			if (_highPriorityJobs && base.Level.StatusIconManager != null)
			{
				base.Level.StatusIconManager.ShowStatusIcon(this, StatusIcon.Type.StaffRequired);
			}
		}

		public int GetJobRoomIndex(JobRoom jobRoom)
		{
			int num = 0;
			foreach (Job job in _jobs)
			{
				if (job == jobRoom)
				{
					return num;
				}
				if (job is JobRoom)
				{
					num++;
				}
			}
			return -1;
		}

		public Character GetFrontOfQueue()
		{
			if (Queue.Count == 0)
			{
				return null;
			}
			Vector3 vector = RoomItemAlgorithms.CalculateDoorEnter(FloorPlan.Door);
			NavMesh navMesh = base.Level.WorldState.NavMesh;
			float maxRoomQueueDistance = GameAlgorithms.Config.MaxRoomQueueDistance;
			float num = MathUtils.Square(maxRoomQueueDistance);
			foreach (Character item in Queue)
			{
				if (vector.SquareDistance2D(item.Position) < num)
				{
					Vector3 start = ((item.Interaction != null) ? item.Interaction.WorldStartPosition : item.Position);
					if (navMesh.CanReach(start, vector) && navMesh.GetLastNavPathLength() < maxRoomQueueDistance)
					{
						return item;
					}
				}
			}
			Character result = null;
			float num2 = float.MaxValue;
			foreach (Character item2 in Queue)
			{
				Vector3 start2 = ((item2.Interaction != null) ? item2.Interaction.WorldStartPosition : item2.Position);
				if (navMesh.CanReach(start2, vector))
				{
					float lastNavPathLength = navMesh.GetLastNavPathLength();
					if (lastNavPathLength < num2)
					{
						result = item2;
						num2 = lastNavPathLength;
					}
				}
			}
			return result;
		}

		public bool IsCharacterInRoom(Character character)
		{
			if (!_using.Contains(character))
			{
				return _staff.Contains(character as Staff);
			}
			return true;
		}

		public bool IsInBoughtPlot()
		{
			if (FloorPlan != null)
			{
				return FloorPlan.HospitalMap.Plot.Bought;
			}
			return false;
		}

		public bool IsInEnergyGeneratingPlot()
		{
			if (FloorPlan != null)
			{
				return FloorPlan.HospitalMap.Plot.Definition.UseEnergyUI;
			}
			return false;
		}

		public bool IsItemBeingUpgraded(RoomItem item)
		{
			foreach (Job job in _jobs)
			{
				if (job is JobUpgrade jobUpgrade && jobUpgrade.GetStaff() != null && jobUpgrade.Item == item)
				{
					return true;
				}
			}
			return false;
		}

		public bool MachineUpgradeInProgress()
		{
			foreach (Job job in _jobs)
			{
				if (job is JobUpgrade jobUpgrade && jobUpgrade.GetStaff() != null)
				{
					return true;
				}
			}
			return false;
		}

		public bool IsItemBeingRepaired(RoomItem item)
		{
			foreach (Job job in _jobs)
			{
				if (job is JobMaintenance jobMaintenance && (jobMaintenance.Item.Definition.MaintenanceDescription == JobMaintenance.JobDescription.BrokenMachine || jobMaintenance.Item.Definition.MaintenanceDescription == JobMaintenance.JobDescription.Vehicular) && jobMaintenance.GetStaff() != null && jobMaintenance.Item == item)
				{
					return true;
				}
			}
			return false;
		}

		public bool MachineRepairInProgress()
		{
			foreach (Job job in _jobs)
			{
				if (job is JobMaintenance jobMaintenance && (jobMaintenance.Item.Definition.MaintenanceDescription == JobMaintenance.JobDescription.BrokenMachine || jobMaintenance.Item.Definition.MaintenanceDescription == JobMaintenance.JobDescription.Vehicular) && jobMaintenance.GetStaff() != null)
				{
					return true;
				}
			}
			return false;
		}

		public bool AllJobsAreOptional()
		{
			if (_staffJobs.Count != 0)
			{
				return _staffJobs.Count == _staffOptionalJobs.Count;
			}
			return true;
		}

		public override void VerifyAfterLoad()
		{
			if (!base.Level.WorldState.AllRooms.Contains(this))
			{
				Logging.Warning(LogChannels.Save, "Found invalid room, destroying");
				foreach (Character item in _using)
				{
					item.TeleportOutOfRoom(this);
				}
				base.Level.WorldState.RemoveRoom(this, affectNavigation: false);
				base.Level.BuildEvents.OnRoomDeleted.InvokeSafe(this);
				Destroy();
			}
			else if (Definition._hasQueue)
			{
				Character[] array = _queueing.ToArray();
				foreach (Character character in array)
				{
					Room queuingAtRoom = character.QueuingAtRoom;
					bool num = character.GoingToRoom == this;
					bool flag = queuingAtRoom != null && queuingAtRoom.Definition._hasQueue && character.GoingToRoom == queuingAtRoom;
					if (num || !flag)
					{
						if (character.QueuingAtRoom != this)
						{
							character.QueuingAtRoom = this;
							queuingAtRoom?._queueing.Remove(character);
							Logging.Warning(LogChannels.AI, "Queue: Fixed {0} in {1} was {2}", character, this, (queuingAtRoom != null) ? queuingAtRoom.ToString() : "NULL");
						}
					}
					else
					{
						_queueing.Remove(character);
						Logging.Warning(LogChannels.AI, "Queue: Removed {0} from {1} queue as they're going to {2}", character, this, queuingAtRoom);
					}
				}
				for (int j = 0; j < _queueing.Count; j++)
				{
					if (_queueing[j].RoomCalledInto == this)
					{
						Logging.Warning(LogChannels.AI, "Queue: Removed {0} from {1} queue as they've been called into the room", _queueing[j], this);
						RemoveFromQueue(_queueing[j]);
						j--;
					}
				}
			}
			else if (_queueing.Count != 0)
			{
				_queueing.Clear();
				Logging.Warning(LogChannels.AI, "{0} with no queue found with people in it, clearing", this);
			}
		}

		public bool CanBeUsedFor(RoomUseType useType)
		{
			RoomUseTypeComponent component = GetComponent<RoomUseTypeComponent>();
			if (component != null)
			{
				switch (useType)
				{
				case RoomUseType.Diagnosis:
					return component.Diagnosis;
				case RoomUseType.Treatment:
					return component.Treatment;
				}
			}
			return true;
		}

		public bool CanBeUsedFor(Character character)
		{
			if (!(character is Patient patient))
			{
				return true;
			}
			if (Definition._type != RoomDefinition.Type.TimeTunnel)
			{
				return true;
			}
			return GetComponent<RoomUseEraComponent>()?.CanBeUsedFor(patient) ?? true;
		}
	}
}
