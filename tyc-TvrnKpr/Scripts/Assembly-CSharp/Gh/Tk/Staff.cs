using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace Gh.Tk
{
	public class Staff : Actor
	{
		public static EventHandler<EventArgs> AllStaffChanged;

		private static HashSet<Staff> AllStaff;

		public static IEnumerable<Staff> HiredStaff;

		public static IEnumerable<Staff> ActiveStaff;

		public static IEnumerable<Staff> PotentialStaff;

		[PersistenceOptIn]
		private float _hiredTimestamp;

		private static readonly float[] _startingEnergy;

		[PersistenceObjectReference]
		[PersistenceOptIn]
		[PersistenceAllowBrokenReferenceOnLoad]
		public List<Room> ExcludedRooms;

		[Header("Particle Effects")]
		public GameObject SkillSuccessParticleEffect;

		public GameObject SkillFailParticleEffect;

		protected GameObject _hat;

		[PersistenceOptIn]
		private float _minutesLate;

		[PersistenceOptIn]
		private readonly List<Tuple<float, bool>> _workTimestampsOfLast24Hours;

		public float WorkHoursLastDay;

		public static float HoursToFullyRest;

		[PersistenceOptIn]
		private string _currentlyWorkingAsRole;

		[PersistenceOptIn]
		private string[] _currentRoles;

		private static List<SlotOption> _scheduleSlots;

		private ScheduleTimeSlot[] _defaultSchedule;

		public const string SKILL_SUFFIX = "Skill";

		[PersistenceOptIn]
		public string[] BiosKeys;

		[PersistenceOptIn]
		public bool UseDirectBiosKeysTranslations;

		[PersistenceOptIn]
		public Dictionary<string, List<string>> BiosTextsPerLanguage;

		[PersistenceOptIn]
		public string SourceStoryNodeId;

		[PersistenceOptIn]
		public string SourceConfigId;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private float _lastCashBonusTimestamp;

		private int _scheduledWorkHours;

		protected override int DefaultComponentCollectionSize => 0;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool IsHired { get; private set; }

		public int Tier => 0;

		public new StaffData Data
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool CanBeFired => false;

		[PersistenceOptIn]
		public bool IsWorking { get; private set; }

		public string CurrentlyWorkingAsRole
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string[] CurrentRoles
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[PersistenceOptIn]
		public bool WakeUp { get; set; }

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public Bed PreferredBed { get; set; }

		public static event EventHandler HiredStaffChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<EventArgs<Staff>> ExcludedRoomsChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler ModelChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler IsWorkingStatusChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<EventArgs<string>> CurrentlyWorkingAsRoleChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler IsStaffOffWorkAndNotWorkingChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static void ClearStaffList()
		{
		}

		public void HireAndActivate(bool withHiringAnimation = true, bool suppressTavernLog = false)
		{
		}

		public string[] GetDesiredRoles()
		{
			return null;
		}

		public void AddToExcludedRooms(Room room)
		{
		}

		public void RemoveFromExcludedRooms(Room room)
		{
		}

		private static void RaiseExcludedRoomsChanged(Staff staff)
		{
		}

		public void RemoveDeadRoomsFromExcludedRooms()
		{
		}

		internal bool IsIdle()
		{
			return false;
		}

		public new void Fire(bool staffQuitVoluntarily = false)
		{
		}

		public void StaffQuits()
		{
		}

		public override void Init()
		{
		}

		public override void OnEnable()
		{
		}

		public override void OnDisable()
		{
		}

		private void OnCurrentSelectableChanged(object sender, EventArgs e)
		{
		}

		public string GetCurrentRole()
		{
			return null;
		}

		public override void InvalidateActorModel()
		{
		}

		public void InvalidateCharacterTexture()
		{
		}

		public override void PostBuiltInit()
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}

		public override void Awake()
		{
		}

		private void OnMouseModeChanged(object sender, EventArgs e)
		{
		}

		private void CurrentJobsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
		}

		public override void Start()
		{
		}

		private void OnBedDestroyed(object sender, EventArgs<Bed> e)
		{
		}

		private void OnResearchChanged(object sender, EventArgs e)
		{
		}

		public int GetSalary()
		{
			return 0;
		}

		public override void OnDestroy()
		{
		}

		private bool IsScheduledOffWork(float addMinutes)
		{
			return false;
		}

		public bool IsOffWork(float addMinutes = 0f)
		{
			return false;
		}

		public bool IsShiftStartingWithin(float minutes)
		{
			return false;
		}

		protected override void UpdateInternal()
		{
		}

		private void UpdateIsWorking()
		{
		}

		private void CheckSleepNeed()
		{
		}

		public bool CanSleepInBed(Bed bed, out string reasonKey)
		{
			reasonKey = null;
			return false;
		}

		public void GoToSleep(GameObjectX target = null)
		{
		}

		public void CancelSleep()
		{
		}

		internal bool CanAssignStaffJob()
		{
			return false;
		}

		private Job FetchNextOwnedJobFromGlobalList()
		{
			return null;
		}

		private float GetHoursNeededToRest()
		{
			return 0f;
		}

		public bool NeedsToRestUntilWorkStarts()
		{
			return false;
		}

		protected override Job GetNextJob()
		{
			return null;
		}

		public bool CanHandleJob(Job job, bool ignoreOffWork = false, bool allowOffRoleJobs = false)
		{
			return false;
		}

		public bool CanHandleJob(Job job, out string declineReason, bool ignoreOffWork = false, bool allowOffRoleJobs = false)
		{
			declineReason = null;
			return false;
		}

		private bool CanHandleJobInternal(Job job, out string declineReason, bool ignoreOffWork, bool includeReasonDetail, bool allowOffRoleJobs = false)
		{
			declineReason = null;
			return false;
		}

		public bool IsAllowedInRoom(Room room)
		{
			return false;
		}

		public bool CanReplaceCurrentJob(Job job)
		{
			return false;
		}

		public float GetJobRating(Job job)
		{
			return 0f;
		}

		public bool IsStaffOffWorkAndNotWorking()
		{
			return false;
		}

		public bool IsAtWork()
		{
			return false;
		}

		public bool AreCurrentRolesEqualToAny(params string[] roles)
		{
			return false;
		}

		private void EnsureUniformTrait()
		{
		}

		public override void EditSchedule()
		{
		}

		public override List<SlotOption> GetAvailableScheduleItems()
		{
			return null;
		}

		public override ScheduleTimeSlot[] GetDefaultSchedule()
		{
			return null;
		}

		public ActorSkill GetSkill(string role)
		{
			return null;
		}

		public float GetSkillValue(string role)
		{
			return 0f;
		}

		public bool IsCatharsisActive()
		{
			return false;
		}

		public bool CanPlayerControlStaff(out string reasonKey)
		{
			reasonKey = null;
			return false;
		}

		public (int, bool) GetCashBonusInfo(StringBuilder details = null)
		{
			return default((int, bool));
		}

		public void GiveCashBonus()
		{
		}

		public void GiveChaosHappinessBoost()
		{
		}

		public void GiveChaosHappinessPenalty()
		{
		}

		public void LogWeaponCraftedForGameStats(Weapon targetWeapon)
		{
		}

		public void AdjustWage(int change)
		{
		}

		protected override void ChangeModel(string model)
		{
		}

		protected override void OnScheduleChanged()
		{
		}

		public int GetScheduledHoursForWork()
		{
			return 0;
		}

		protected override bool ShouldShowNameTag()
		{
			return false;
		}

		public override void MarkToDestroy()
		{
		}
	}
}
