#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.IO;
using I2.Loc;
using TH20.BT_Types;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	public class StaffWorkScheduler : MustCallDestroy
	{
		private readonly List<Job> _jobs;

		private readonly List<Staff> _staff;

		private List<Staff> _priorityStaff;

		private readonly BuildEvents _buildEvents;

		private readonly CharacterEvents _characterEvents;

		private Staff _heldStaff;

		private Job _heldStaffJob;

		private string _heldStaffDropResult;

		private readonly Dictionary<Job, WaitForJobCompleteTask> _waitForJobCompleteTasks;

		private readonly List<Job> _jobsToRemoveCache = new List<Job>(64);

		private const int MaxToProcess = 4;

		private Dictionary<Staff, float> _timeProcessed = new Dictionary<Staff, float>();

		[DontSave]
		private GUIStyle _debugGUIStyle;

		public List<Job> AllJobs => _jobs;

		public StaffWorkScheduler(BuildEvents buildEvents, CharacterEvents characterEvents)
		{
			_jobs = new List<Job>();
			_staff = new List<Staff>();
			_priorityStaff = new List<Staff>();
			_waitForJobCompleteTasks = new Dictionary<Job, WaitForJobCompleteTask>();
			_buildEvents = buildEvents;
			_characterEvents = characterEvents;
			RegisterEvents();
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			RegisterEvents();
			if (_priorityStaff == null)
			{
				_priorityStaff = new List<Staff>();
			}
			foreach (Job job in _jobs)
			{
				job.RestoreFromSave();
			}
			Staff[] array = _staff.ToArray();
			foreach (Staff staff in array)
			{
				if (staff.IsOrphaned())
				{
					OnStaffDestroyed(staff);
				}
			}
			_timeProcessed = new Dictionary<Staff, float>();
			foreach (Staff item in _staff)
			{
				_timeProcessed.Add(item, GameTime.time);
			}
		}

		private void RegisterEvents()
		{
			CharacterEvents characterEvents = _characterEvents;
			characterEvents.OnStaffSpawned = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffSpawned, new Action<Staff>(OnStaffSpawned));
			CharacterEvents characterEvents2 = _characterEvents;
			characterEvents2.OnStaffDestroyed = (Action<Staff>)Delegate.Combine(characterEvents2.OnStaffDestroyed, new Action<Staff>(OnStaffDestroyed));
			CharacterEvents characterEvents3 = _characterEvents;
			characterEvents3.OnStaffPickup = (Action<Staff, JobApplicant>)Delegate.Combine(characterEvents3.OnStaffPickup, new Action<Staff, JobApplicant>(OnStaffPickup));
			CharacterEvents characterEvents4 = _characterEvents;
			characterEvents4.OnStaffDrop = (Action<Staff, Room, bool>)Delegate.Combine(characterEvents4.OnStaffDrop, new Action<Staff, Room, bool>(OnStaffDrop));
			CharacterEvents characterEvents5 = _characterEvents;
			characterEvents5.OnStaffTakeBreak = (Action<Staff>)Delegate.Combine(characterEvents5.OnStaffTakeBreak, new Action<Staff>(OnStaffTakeBreak));
			CharacterEvents characterEvents6 = _characterEvents;
			characterEvents6.OnStaffFired = (Action<Staff>)Delegate.Combine(characterEvents6.OnStaffFired, new Action<Staff>(OnStaffFired));
			CharacterEvents characterEvents7 = _characterEvents;
			characterEvents7.OnGhostSpawned = (Action<Character>)Delegate.Combine(characterEvents7.OnGhostSpawned, new Action<Character>(OnGhostSpawned));
			CharacterEvents characterEvents8 = _characterEvents;
			characterEvents8.OnGhostDestroyed = (Action<Character>)Delegate.Combine(characterEvents8.OnGhostDestroyed, new Action<Character>(OnGhostDestroyed));
			CharacterEvents characterEvents9 = _characterEvents;
			characterEvents9.OnGhostCaptured = (Action<Character, Staff>)Delegate.Combine(characterEvents9.OnGhostCaptured, new Action<Character, Staff>(OnGhostCaptured));
			BuildEvents buildEvents = _buildEvents;
			buildEvents.OnEnterEditFloorPlanState = (Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Combine(buildEvents.OnEnterEditFloorPlanState, new Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterEditFloorPlanState));
			BuildEvents buildEvents2 = _buildEvents;
			buildEvents2.OnRoomOpened = (Action<Room>)Delegate.Combine(buildEvents2.OnRoomOpened, new Action<Room>(AddRoomJobs));
			BuildEvents buildEvents3 = _buildEvents;
			buildEvents3.OnRoomClosed = (Action<Room>)Delegate.Combine(buildEvents3.OnRoomClosed, new Action<Room>(RemoveClosedRoomJobs));
			BuildEvents buildEvents4 = _buildEvents;
			buildEvents4.OnRoomDeleted = (Action<Room>)Delegate.Combine(buildEvents4.OnRoomDeleted, new Action<Room>(RemoveRoomJobs));
			BuildEvents buildEvents5 = _buildEvents;
			buildEvents5.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents5.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents6 = _buildEvents;
			buildEvents6.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents6.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			BuildEvents buildEvents7 = _buildEvents;
			buildEvents7.OnRoomItemDestroyed = (Action<RoomItem>)Delegate.Combine(buildEvents7.OnRoomItemDestroyed, new Action<RoomItem>(OnRoomItemDestroyed));
			BuildEvents buildEvents8 = _buildEvents;
			buildEvents8.OnRoomItemMaintenanceRequired = (Action<RoomItem>)Delegate.Combine(buildEvents8.OnRoomItemMaintenanceRequired, new Action<RoomItem>(CreateMaintenanceJob));
			BuildEvents buildEvents9 = _buildEvents;
			buildEvents9.OnRoomItemMaintenanceComplete = (Action<RoomItem, Staff, JobMaintenance>)Delegate.Combine(buildEvents9.OnRoomItemMaintenanceComplete, new Action<RoomItem, Staff, JobMaintenance>(RemoveMaintenanceJob));
			BuildEvents buildEvents10 = _buildEvents;
			buildEvents10.OnRoomItemMaintenanceComplete = (Action<RoomItem, Staff, JobMaintenance>)Delegate.Combine(buildEvents10.OnRoomItemMaintenanceComplete, new Action<RoomItem, Staff, JobMaintenance>(AddPriorityStaff));
			BuildEvents buildEvents11 = _buildEvents;
			buildEvents11.OnRoomItemRequestRepair = (Action<RoomItem>)Delegate.Combine(buildEvents11.OnRoomItemRequestRepair, new Action<RoomItem>(OnRoomItemRequestRepair));
			BuildEvents buildEvents12 = _buildEvents;
			buildEvents12.OnRoomItemCancelRepair = (Action<RoomItem>)Delegate.Combine(buildEvents12.OnRoomItemCancelRepair, new Action<RoomItem>(OnRoomItemCancelRepair));
			BuildEvents buildEvents13 = _buildEvents;
			buildEvents13.OnRoomItemRequestUpgrade = (Action<RoomItem>)Delegate.Combine(buildEvents13.OnRoomItemRequestUpgrade, new Action<RoomItem>(CreateUpgradeJob));
			BuildEvents buildEvents14 = _buildEvents;
			buildEvents14.OnRoomItemCancelUpgrade = (Action<RoomItem>)Delegate.Combine(buildEvents14.OnRoomItemCancelUpgrade, new Action<RoomItem>(CancelUpgradeJob));
			BuildEvents buildEvents15 = _buildEvents;
			buildEvents15.OnRoomItemUpgradeComplete = (Action<RoomItem, Staff>)Delegate.Combine(buildEvents15.OnRoomItemUpgradeComplete, new Action<RoomItem, Staff>(RemoveUpgradeJob));
			BuildEvents buildEvents16 = _buildEvents;
			buildEvents16.OnRoomItemOnFire = (Action<RoomItem, RoomItemFlammableComponent>)Delegate.Combine(buildEvents16.OnRoomItemOnFire, new Action<RoomItem, RoomItemFlammableComponent>(CreateFireJob));
			BuildEvents buildEvents17 = _buildEvents;
			buildEvents17.OnRoomItemExtinguished = (Action<RoomItem>)Delegate.Combine(buildEvents17.OnRoomItemExtinguished, new Action<RoomItem>(RemoveFireJob));
			ConsoleCommandsDatabase.RegisterCommand("DumpStaffWorkScehdule", "Dumps out a log of all jobs in the work scheduler", "DumpStaffWorkScehdule", Debug_DumpStaffWorkScehdule);
		}

		public override void Destroy()
		{
			CharacterEvents characterEvents = _characterEvents;
			characterEvents.OnStaffSpawned = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffSpawned, new Action<Staff>(OnStaffSpawned));
			CharacterEvents characterEvents2 = _characterEvents;
			characterEvents2.OnStaffDestroyed = (Action<Staff>)Delegate.Remove(characterEvents2.OnStaffDestroyed, new Action<Staff>(OnStaffDestroyed));
			CharacterEvents characterEvents3 = _characterEvents;
			characterEvents3.OnStaffPickup = (Action<Staff, JobApplicant>)Delegate.Remove(characterEvents3.OnStaffPickup, new Action<Staff, JobApplicant>(OnStaffPickup));
			CharacterEvents characterEvents4 = _characterEvents;
			characterEvents4.OnStaffDrop = (Action<Staff, Room, bool>)Delegate.Remove(characterEvents4.OnStaffDrop, new Action<Staff, Room, bool>(OnStaffDrop));
			CharacterEvents characterEvents5 = _characterEvents;
			characterEvents5.OnStaffTakeBreak = (Action<Staff>)Delegate.Remove(characterEvents5.OnStaffTakeBreak, new Action<Staff>(OnStaffTakeBreak));
			CharacterEvents characterEvents6 = _characterEvents;
			characterEvents6.OnStaffFired = (Action<Staff>)Delegate.Remove(characterEvents6.OnStaffFired, new Action<Staff>(OnStaffFired));
			CharacterEvents characterEvents7 = _characterEvents;
			characterEvents7.OnGhostSpawned = (Action<Character>)Delegate.Remove(characterEvents7.OnGhostSpawned, new Action<Character>(OnGhostSpawned));
			CharacterEvents characterEvents8 = _characterEvents;
			characterEvents8.OnGhostDestroyed = (Action<Character>)Delegate.Remove(characterEvents8.OnGhostDestroyed, new Action<Character>(OnGhostDestroyed));
			CharacterEvents characterEvents9 = _characterEvents;
			characterEvents9.OnGhostCaptured = (Action<Character, Staff>)Delegate.Remove(characterEvents9.OnGhostCaptured, new Action<Character, Staff>(OnGhostCaptured));
			BuildEvents buildEvents = _buildEvents;
			buildEvents.OnEnterEditFloorPlanState = (Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Remove(buildEvents.OnEnterEditFloorPlanState, new Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterEditFloorPlanState));
			BuildEvents buildEvents2 = _buildEvents;
			buildEvents2.OnRoomOpened = (Action<Room>)Delegate.Remove(buildEvents2.OnRoomOpened, new Action<Room>(AddRoomJobs));
			BuildEvents buildEvents3 = _buildEvents;
			buildEvents3.OnRoomClosed = (Action<Room>)Delegate.Remove(buildEvents3.OnRoomClosed, new Action<Room>(RemoveClosedRoomJobs));
			BuildEvents buildEvents4 = _buildEvents;
			buildEvents4.OnRoomDeleted = (Action<Room>)Delegate.Remove(buildEvents4.OnRoomDeleted, new Action<Room>(RemoveRoomJobs));
			BuildEvents buildEvents5 = _buildEvents;
			buildEvents5.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents5.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents6 = _buildEvents;
			buildEvents6.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents6.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			BuildEvents buildEvents7 = _buildEvents;
			buildEvents7.OnRoomItemDestroyed = (Action<RoomItem>)Delegate.Remove(buildEvents7.OnRoomItemDestroyed, new Action<RoomItem>(OnRoomItemDestroyed));
			BuildEvents buildEvents8 = _buildEvents;
			buildEvents8.OnRoomItemMaintenanceRequired = (Action<RoomItem>)Delegate.Remove(buildEvents8.OnRoomItemMaintenanceRequired, new Action<RoomItem>(CreateMaintenanceJob));
			BuildEvents buildEvents9 = _buildEvents;
			buildEvents9.OnRoomItemMaintenanceComplete = (Action<RoomItem, Staff, JobMaintenance>)Delegate.Remove(buildEvents9.OnRoomItemMaintenanceComplete, new Action<RoomItem, Staff, JobMaintenance>(RemoveMaintenanceJob));
			BuildEvents buildEvents10 = _buildEvents;
			buildEvents10.OnRoomItemMaintenanceComplete = (Action<RoomItem, Staff, JobMaintenance>)Delegate.Remove(buildEvents10.OnRoomItemMaintenanceComplete, new Action<RoomItem, Staff, JobMaintenance>(AddPriorityStaff));
			BuildEvents buildEvents11 = _buildEvents;
			buildEvents11.OnRoomItemRequestRepair = (Action<RoomItem>)Delegate.Remove(buildEvents11.OnRoomItemRequestRepair, new Action<RoomItem>(OnRoomItemRequestRepair));
			BuildEvents buildEvents12 = _buildEvents;
			buildEvents12.OnRoomItemCancelRepair = (Action<RoomItem>)Delegate.Remove(buildEvents12.OnRoomItemCancelRepair, new Action<RoomItem>(OnRoomItemCancelRepair));
			BuildEvents buildEvents13 = _buildEvents;
			buildEvents13.OnRoomItemRequestUpgrade = (Action<RoomItem>)Delegate.Remove(buildEvents13.OnRoomItemRequestUpgrade, new Action<RoomItem>(CreateUpgradeJob));
			BuildEvents buildEvents14 = _buildEvents;
			buildEvents14.OnRoomItemCancelUpgrade = (Action<RoomItem>)Delegate.Remove(buildEvents14.OnRoomItemCancelUpgrade, new Action<RoomItem>(CancelUpgradeJob));
			BuildEvents buildEvents15 = _buildEvents;
			buildEvents15.OnRoomItemUpgradeComplete = (Action<RoomItem, Staff>)Delegate.Remove(buildEvents15.OnRoomItemUpgradeComplete, new Action<RoomItem, Staff>(RemoveUpgradeJob));
			BuildEvents buildEvents16 = _buildEvents;
			buildEvents16.OnRoomItemOnFire = (Action<RoomItem, RoomItemFlammableComponent>)Delegate.Remove(buildEvents16.OnRoomItemOnFire, new Action<RoomItem, RoomItemFlammableComponent>(CreateFireJob));
			BuildEvents buildEvents17 = _buildEvents;
			buildEvents17.OnRoomItemExtinguished = (Action<RoomItem>)Delegate.Remove(buildEvents17.OnRoomItemExtinguished, new Action<RoomItem>(RemoveFireJob));
			ConsoleCommandsDatabase.UnRegisterCommand("DumpStaffWorkScehdule");
			base.Destroy();
		}

		private void OnEnterEditFloorPlanState(Room roomBeingEdited, BlueprintFloorPlan floorPlan, BlueprintFloorPlanVisual floorPlanVisual)
		{
			RemoveRoomJobs(roomBeingEdited);
			foreach (RoomItem item in roomBeingEdited.FloorPlan.Items)
			{
				RemoveRoomItemJobs(item, complete: false);
			}
		}

		private void OnRoomItemAdded(RoomItem item, FloorPlan floorPlan)
		{
			if (item.OwningRoom != null)
			{
				if (item.OwningRoom.IsOpen)
				{
					AddRoomItemJobs(item);
				}
				else
				{
					AddUpgradeJob(item);
				}
			}
		}

		private void OnRoomItemRemoved(RoomItem item, FloorPlan floorPlan)
		{
			RemoveRoomItemJobs(item, complete: false);
		}

		private void OnRoomItemDestroyed(RoomItem item)
		{
			RemoveRoomItemJobs(item, complete: false);
		}

		public void Update()
		{
			_jobsToRemoveCache.Clear();
			foreach (KeyValuePair<Job, WaitForJobCompleteTask> waitForJobCompleteTask in _waitForJobCompleteTasks)
			{
				Job key = waitForJobCompleteTask.Key;
				WaitForJobCompleteTask value = waitForJobCompleteTask.Value;
				if (value.Staff != _heldStaff && value.Update())
				{
					_jobsToRemoveCache.Add(key);
				}
			}
			foreach (Job item in _jobsToRemoveCache)
			{
				_waitForJobCompleteTasks.Remove(item);
			}
			_jobsToRemoveCache.Clear();
			try
			{
				_staff.Sort((Staff staff, Staff staff1) => staff1.Energy.Value().CompareTo(staff.Energy.Value()));
			}
			catch
			{
			}
			foreach (Staff item2 in _priorityStaff)
			{
				ProcessStaffMember(item2, GameTime.deltaTime);
			}
			_priorityStaff.Clear();
			int num = 0;
			float time = GameTime.time;
			float num2 = (float)_staff.Count * 1f / 15f;
			foreach (Staff item3 in _staff)
			{
				float num3 = _timeProcessed[item3];
				if (num3 + num2 < time)
				{
					float deltaTime = time - num3;
					ProcessStaffMember(item3, deltaTime);
					_timeProcessed[item3] = time;
					num++;
					if (num == 4)
					{
						break;
					}
				}
			}
		}

		private void ProcessStaffMember(Staff staff, float deltaTime)
		{
			if (staff != _heldStaff && staff.IsFitForWork() && !WaitingForJobComplete(staff) && !staff.IsRequestingABreak())
			{
				Job job = staff.CurrentJob;
				if (job != null && job.CanLeave() && !job.IsSuitable(staff, checkExclusion: true, out var _))
				{
					job.MakeAvailable();
					job = null;
					staff.Idle();
				}
				if ((job == null || job.CanLeaveIgnoringDroppedCheck()) && !staff.IsInteractingWithRoomDoor())
				{
					float finalScore;
					Job job2 = FindBestJobForStaff(staff, out finalScore);
					if (job2 != null)
					{
						if (job == null)
						{
							if (!job2.StartJob(staff))
							{
								RemoveInvalidJob(job2);
							}
						}
						else if (job.GetJobScore(staff) < finalScore)
						{
							job.Interrupt();
							job.MakeAvailable();
							job.RemoveStaffFromRoom(staff);
							staff.Idle();
							if (!job2.StartJob(staff))
							{
								RemoveInvalidJob(job2);
							}
						}
					}
				}
			}
			if (!staff.Level.HospitalPolicy.StaffLeaveRooms || staff.CurrentJob == null)
			{
				return;
			}
			if (staff.IsIdleInWorkRoom())
			{
				staff.CurrentJob.IdleTime += deltaTime;
				if (staff.CurrentJob.IdleTime >= GameAlgorithms.Config.MaxTimeStaffIdleOnJob && staff.Interaction == null)
				{
					staff.Idle();
				}
			}
			else
			{
				staff.CurrentJob.IdleTime = 0f;
			}
		}

		private bool WaitingForJobComplete(Staff staff)
		{
			foreach (WaitForJobCompleteTask value in _waitForJobCompleteTasks.Values)
			{
				if (value.Staff == staff)
				{
					return true;
				}
			}
			return false;
		}

		private Job FindBestJobForStaff(Staff staff, out float finalScore, Room room = null)
		{
			Job result = null;
			float num = float.NegativeInfinity;
			Vector3 position = staff.Position;
			foreach (Job job in _jobs)
			{
				bool num2 = room != null || job.Available();
				bool flag = room == null || job.IsInRoom(room);
				bool flag2 = room == null || job.IsWithinDropRadius(position);
				if (num2 && job.IsSuitable(staff, checkExclusion: true, out var _) && job.IsReadyForWork() && flag && flag2)
				{
					float jobScore = job.GetJobScore(staff);
					if (jobScore > 0f && jobScore > num)
					{
						result = job;
						num = jobScore;
					}
				}
			}
			finalScore = num;
			return result;
		}

		private Job FindBestJobForStaffBasedOnDistance(Staff staff, Room room)
		{
			Job result = null;
			float num = float.MinValue;
			Vector3 position = staff.Position;
			foreach (Job job in _jobs)
			{
				bool num2 = room != null || job.Available();
				bool flag = room == null || job.IsInRoom(room);
				bool flag2 = room == null || job.IsWithinDropRadius(position);
				if (num2 && flag && flag2 && job.IsSuitable(staff, checkExclusion: true, out var _))
				{
					float num3 = GameAlgorithms.GetJobScoreDistanceMultiplier(staff, job.GetWorldPosition());
					if (job.GetStaff() == null)
					{
						num3 *= 2f;
					}
					if (num3 > num)
					{
						result = job;
						num = num3;
					}
				}
			}
			return result;
		}

		public void AddJob(Job job)
		{
			if (_jobs.AddUnique(job))
			{
				job.OnAddedToScheduler();
			}
		}

		public void RemoveJob(Job job, bool complete)
		{
			Staff staff = job.GetStaff();
			if (staff != null)
			{
				job.MakeAvailable();
				if (!complete)
				{
					staff.Idle();
				}
			}
			if (job == _heldStaffJob)
			{
				_heldStaffJob = null;
			}
			if (_jobs.Remove(job))
			{
				job.OnRemovedFromScheduler();
				if (_waitForJobCompleteTasks.ContainsKey(job))
				{
					_waitForJobCompleteTasks.Remove(job);
				}
			}
		}

		private void AddRoomJobs(Room room)
		{
			foreach (StaffRequired staffJob in room.StaffJobs)
			{
				if (!room.IsOptionalStaffRequired(staffJob))
				{
					AddJob(room.CreateJob(staffJob));
				}
			}
			foreach (RoomItem item in room.FloorPlan.Items)
			{
				AddRoomItemJobs(item);
			}
			RoomExtraStaffJobsComponent component = room.GetComponent<RoomExtraStaffJobsComponent>();
			if (component == null)
			{
				return;
			}
			foreach (Job job in component.Jobs)
			{
				AddJob(job);
			}
		}

		private void RemoveRoomJobs(Room room)
		{
			for (int num = room.Jobs.Count - 1; num >= 0; num--)
			{
				RemoveJob(room.Jobs[num], complete: false);
			}
		}

		private void RemoveClosedRoomJobs(Room room)
		{
			for (int num = room.Jobs.Count - 1; num >= 0; num--)
			{
				if (room.Jobs[num].RemoveOnRoomClosed())
				{
					RemoveJob(room.Jobs[num], complete: false);
				}
			}
		}

		private void AddRoomItemJobs(RoomItem item)
		{
			if (!(item.FloorPlan is BlueprintFloorPlan))
			{
				AddRoomJob(item);
				AddServiceJob(item);
				AddUpgradeJob(item);
				AddMaintenanceJob(item);
				AddFireJob(item);
			}
		}

		private void RemoveRoomItemJobs(RoomItem item, bool complete)
		{
			if (!(item.FloorPlan is BlueprintFloorPlan))
			{
				RemoveRoomJob(item, complete);
				RemoveServiceJob(item, complete);
				RemoveUpgradeJobInternal(item, complete);
				RemoveMaintenanceJobInternal(item, complete);
				RemoveFireJobInternal(item, complete);
			}
		}

		private void AddRoomJob(RoomItem item)
		{
			if (item.FloorPlan is BlueprintFloorPlan)
			{
				return;
			}
			item.IterateModifiers(delegate(RoomModifierRequiredStaff modifier)
			{
				RoomJobComponent orAddComponent = item.GetOrAddComponent<RoomJobComponent>();
				if (orAddComponent.Job == null)
				{
					Job job = item.OwningRoom.CreateJob(modifier.StaffRequired);
					orAddComponent.Job = job;
				}
				AddJob(orAddComponent.Job);
			});
		}

		private void RemoveRoomJob(RoomItem item, bool complete)
		{
			if (!(item.FloorPlan is BlueprintFloorPlan))
			{
				RoomJobComponent component = item.GetComponent<RoomJobComponent>();
				if (component != null && component.Job != null)
				{
					RemoveJob(component.Job, complete);
					component.Job = null;
				}
			}
		}

		private void AddServiceJob(RoomItem item)
		{
			if (item.FloorPlan is BlueprintFloorPlan)
			{
				return;
			}
			RoomItemJobComponent component = item.GetComponent<RoomItemJobComponent>();
			if (component != null)
			{
				if (component.Job == null)
				{
					component.Job = new JobService(item, component);
				}
				AddJob(component.Job);
			}
		}

		private void RemoveServiceJob(RoomItem item, bool complete)
		{
			if (!(item.FloorPlan is BlueprintFloorPlan))
			{
				RoomItemJobComponent component = item.GetComponent<RoomItemJobComponent>();
				if (component != null && component.Job != null)
				{
					RemoveJob(component.Job, complete);
				}
			}
		}

		private void RemoveInvalidJob(Job job)
		{
			RemoveJob(job, complete: false);
			Logging.Error(LogChannels.StaffWork, "Removed invalid job {0}", job.DebugDescription());
		}

		private void OnStaffSpawned(Staff staff)
		{
			_staff.Add(staff);
			_timeProcessed.Add(staff, GameTime.time);
		}

		private void OnStaffDestroyed(Staff staff)
		{
			staff.CurrentJob?.MakeAvailable();
			if (staff == _heldStaff)
			{
				_heldStaff = null;
				_heldStaffJob = null;
				_heldStaffDropResult = null;
			}
			_staff.Remove(staff);
			_timeProcessed.Remove(staff);
			RemoveStaffFromWaitForJobList(staff);
		}

		private void OnStaffPickup(Staff staff, JobApplicant applicant)
		{
			_heldStaff = staff;
			if (_heldStaff.CurrentJob != null)
			{
				_heldStaff.CurrentJob.Interrupt();
			}
		}

		private void OnStaffTakeBreak(Staff staff)
		{
			staff.CurrentJob?.MakeAvailable();
			RemoveStaffFromWaitForJobList(staff);
		}

		private void OnStaffFired(Staff staff)
		{
			RemoveStaffFromWaitForJobList(staff);
		}

		private void OnGhostSpawned(Character ghost)
		{
			GhostComponent component = ghost.GetComponent<GhostComponent>();
			if (component != null && component.Job == null && !component.Invulnerable)
			{
				JobGhost job = new JobGhost(ghost);
				AddJob(job);
				component.Job = job;
			}
		}

		private void OnGhostDestroyed(Character ghost)
		{
			GhostComponent component = ghost.GetComponent<GhostComponent>();
			if (component.Job is JobGhost { IsEctoVatAssigned: false } jobGhost)
			{
				RemoveJob(jobGhost, complete: true);
				component.Job = null;
			}
		}

		private void OnGhostCaptured(Character character, Staff staff)
		{
			OnGhostDestroyed(character);
		}

		private Job FindJobByRoom(Room room, Staff staff)
		{
			List<Job> list = new List<Job>();
			Vector3 position = staff.Position;
			foreach (Job job in room.Jobs)
			{
				if (job.IsSuitable(staff, checkExclusion: false, out var _) && job.IsWithinDropRadius(position))
				{
					list.Add(job);
				}
			}
			if (list.Count == 0)
			{
				return null;
			}
			list.Sort((Job job, Job job1) => (!job.Available() || job1.Available()) ? 1 : (-1));
			if (list[0].Available())
			{
				return list[0];
			}
			list.Sort((Job job, Job job1) => job.GetStaff().Energy.Value().CompareTo(job1.GetStaff().Energy.Value()));
			return list[0];
		}

		private void OnStaffDrop(Staff staff, Room room, bool jobSearch)
		{
			staff.CurrentJob?.MakeAvailable();
			RemoveStaffFromWaitForJobList(staff);
			Job job = _heldStaffJob;
			string heldStaffDropResult = _heldStaffDropResult;
			_heldStaff = null;
			_heldStaffJob = null;
			_heldStaffDropResult = null;
			if (room == null)
			{
				return;
			}
			Job currentJob = staff.CurrentJob;
			if (room.IsOpen && room.Definition._staffBreakRoom && room.WhoCanUse.IsMember(staff))
			{
				currentJob?.MakeAvailable();
				room.EnterRoom(staff, ReasonUseRoom.Visit);
				staff.ForceOnBreak();
			}
			else if (staff.CurrentMode == Staff.Mode.Break || staff.IsFitForWork())
			{
				if (currentJob != null)
				{
					if (currentJob.StartFromStaffDrop(staff))
					{
						currentJob.AssignStaff(staff, room);
					}
					else
					{
						RemoveInvalidJob(currentJob);
					}
					return;
				}
				if (job == null && jobSearch)
				{
					job = FindBestJobForStaff(staff, out var _, room);
					if (job == null)
					{
						job = FindJobByRoom(room, staff);
					}
				}
				if (job != null)
				{
					Staff staff2 = job.GetStaff();
					if (staff2 != null)
					{
						if (!job.CanLeave())
						{
							WaitForJobToComplete(staff, job, room);
							return;
						}
						room.StaffLeaveRoom(staff2);
						staff2.Idle();
					}
					if (job.StartFromStaffDrop(staff))
					{
						job.AssignStaff(staff, room);
						return;
					}
					Logging.Warning(LogChannels.StaffWork, "Failed to start job {0} in {1} for {2}", job.DebugDescription(), room, staff);
				}
				if (staff.CurrentMode == Staff.Mode.Break)
				{
					staff.ForceOnBreak();
				}
				else if (staff.ShouldIdleWhenDroppedInRoom(room))
				{
					staff.Idle();
				}
				if (heldStaffDropResult != null)
				{
					staff.Level.InWorldMessages.ShowMessage(heldStaffDropResult, staff.Position, 3f, InWorldMessages.MessageType.Info);
				}
			}
			else if (staff.ShouldIdleWhenDroppedInRoom(room))
			{
				staff.Idle();
			}
		}

		private void RemoveStaffFromWaitForJobList(Staff staff)
		{
			foreach (WaitForJobCompleteTask value in _waitForJobCompleteTasks.Values)
			{
				if (value.Staff == staff)
				{
					_waitForJobCompleteTasks.Remove(value.Job);
					break;
				}
			}
		}

		public string GetStaffDropResult(Staff staff, Room room, out ICursorSelectable highlightObject)
		{
			_heldStaffDropResult = GetStaffDropResultInner(staff, room, out highlightObject, out _heldStaffJob);
			return _heldStaffDropResult;
		}

		private string GetStaffDropResultInner(Staff staff, Room room, out ICursorSelectable highlightObject, out Job job)
		{
			highlightObject = null;
			job = null;
			if (room == null || !RoomAlgorithms.CanReachAnyDoor(staff.Position, room.FloorPlan, staff.Level))
			{
				return ScriptLocalization.Staff.DropResult_InvalidNav_CS;
			}
			if (room.Definition.IsHospitalOrBay && staff.Definition._type != StaffDefinition.Type.Janitor && staff.Definition._type != StaffDefinition.Type.Assistant && !room.Definition.IsAmbulanceBayOnly)
			{
				return null;
			}
			if (room.IsOpen && room.Definition._staffBreakRoom && room.WhoCanUse.IsMember(staff))
			{
				highlightObject = room;
				return ScriptLocalization.Staff.DropResult_TakeBreak_CS;
			}
			if (staff.Definition._type != StaffDefinition.Type.Janitor && !room.HasValidRequiredItems())
			{
				highlightObject = room;
				return ScriptLocalization.Menu.BuildRoom_FixInvalidItems_CS;
			}
			job = FindBestJobForStaffBasedOnDistance(staff, room);
			RoomLogic component = room.GetComponent<RoomLogic>();
			if (component != null)
			{
				string staffDropResult = component.GetStaffDropResult(staff);
				if (staffDropResult != null)
				{
					highlightObject = room;
					return staffDropResult;
				}
			}
			if (job != null)
			{
				string text = job.Description(staff.Gender);
				Staff staff2 = job.GetStaff();
				if (staff2 != null && staff2 != staff)
				{
					return (job.CanLeave() ? ScriptLocalization.Staff.DropResult_ReplaceStaff_CS : ScriptLocalization.Staff.DropResult_ReplaceStaffWait_CS).Replace("{[JOB]}", text).Replace("{[STAFF]}", staff2.Name);
				}
				highlightObject = job.Highlight();
				return text;
			}
			bool flag = true;
			bool flag2 = true;
			bool flag3 = false;
			QualificationDefinition qualificationDefinition = null;
			bool num = staff.Definition._type == StaffDefinition.Type.Janitor && room.Definition.IsHospitalOrBay;
			bool flag4 = staff.Definition._type == StaffDefinition.Type.Assistant && room.Definition.IsHospitalOrBay;
			if (!num && !flag4)
			{
				foreach (Job job2 in room.Jobs)
				{
					flag3 = true;
					if (job2.StaffType() == staff.Definition._type || job2.AltStaffType() == staff.Definition._type)
					{
						QualificationDefinition qualificationDefinition2 = job2.RequiredQualification();
						if (qualificationDefinition2 != null && !staff.HasCompletedQualification(qualificationDefinition2))
						{
							flag = false;
							qualificationDefinition = qualificationDefinition2;
						}
						flag2 = false;
					}
				}
				if (flag3)
				{
					if (flag2)
					{
						return ((staff.Definition._type == StaffDefinition.Type.Janitor) ? ScriptLocalization.Staff.DropResult_InvalidRoomJanitor_CS : ScriptLocalization.Staff.DropResult_InvalidRoom_CS).Replace("{[STAFF]}", GameStringUtils.GetStaffTypeTextLoc(staff.Definition._type)).Replace("{[ROOM]}", room.Definition.GetLocalisedName());
					}
					if (!flag)
					{
						return ScriptLocalization.Staff.DropResult_RequiresQualification_CS.Replace("{[QUALIFICATION]}", qualificationDefinition.NameLocalised.Translation).Replace("{[ROOM]}", room.Definition.GetLocalisedName());
					}
				}
			}
			return null;
		}

		private void WaitForJobToComplete(Staff staff, Job job, Room room)
		{
			if (!_waitForJobCompleteTasks.ContainsKey(job))
			{
				WaitForJobCompleteTask value = new WaitForJobCompleteTask(staff, job, room);
				_waitForJobCompleteTasks.Add(job, value);
			}
			else
			{
				WaitForJobCompleteTask value = _waitForJobCompleteTasks[job];
				value.ReplaceStaff(staff);
			}
			staff.SetBehaviour(staff.Definition._behaviourWaitForJob);
			staff.BehaviorTree.SetVariable("Room", new RoomRef(room));
		}

		public void DebugGUI()
		{
			if (!DebugVars.ShowWorkSchedule.Value)
			{
				return;
			}
			int num = 0;
			string empty = string.Empty;
			if (_debugGUIStyle == null)
			{
				_debugGUIStyle = new GUIStyle(GUI.skin.box)
				{
					alignment = TextAnchor.UpperRight,
					font = Font.CreateDynamicFontFromOSFont("Consolas", 12),
					fontStyle = FontStyle.Bold
				};
			}
			empty += "Work Schedule\n";
			foreach (Job job in _jobs)
			{
				Staff staff = job.GetStaff();
				string arg = ((staff != null) ? $"<color=white>{staff}</color> {job.DebugDescription()}" : $"<color=silver>Nobody</color> {job.DebugDescription()}");
				empty += $"\n{arg,64} {(int)job.GetJobScore(staff),8}";
				num++;
				if (num == 32)
				{
					break;
				}
			}
			Vector2 vector = _debugGUIStyle.CalcSize(new GUIContent(empty));
			GUI.Box(new Rect((float)Screen.width - vector.x, 0f, vector.x, vector.y), empty, _debugGUIStyle);
		}

		private ConsoleCommandResult Debug_DumpStaffWorkScehdule(string[] args)
		{
			string text = string.Empty;
			foreach (Job job in _jobs)
			{
				Staff staff = job.GetStaff();
				string arg = ((staff != null) ? $"{staff},{job.DebugDescription()}" : $"Nobody,{job.DebugDescription()}");
				text += $"{arg},{(int)job.GetJobScore(staff)}\n";
			}
			Logging.Info(LogChannels.StaffWork, text);
			try
			{
				File.WriteAllText(Path.Combine(Directories.GameOutputDirectory, "StaffWorkSchedule.csv"), text);
			}
			catch (Exception ex)
			{
				return ConsoleCommandResult.Failed(ex.ToString());
			}
			return ConsoleCommandResult.Succeeded();
		}

		private void CreateUpgradeJob(RoomItem roomItem)
		{
			RoomItemUpgradeComponent orAddComponent = roomItem.GetOrAddComponent<RoomItemUpgradeComponent>();
			if (orAddComponent.Job == null)
			{
				orAddComponent.Job = new JobUpgrade(roomItem);
				AddJob(orAddComponent.Job);
			}
		}

		private void AddUpgradeJob(RoomItem roomItem)
		{
			RoomItemUpgradeComponent component = roomItem.GetComponent<RoomItemUpgradeComponent>();
			if (component != null && component.Job != null)
			{
				AddJob(component.Job);
			}
		}

		private void RemoveUpgradeJob(RoomItem item, Staff staff)
		{
			RemoveUpgradeJobInternal(item, complete: true);
		}

		private void CancelUpgradeJob(RoomItem item)
		{
			RemoveUpgradeJobInternal(item, complete: false);
			item.RemoveComponents<RoomItemUpgradeComponent>();
		}

		private void RemoveUpgradeJobInternal(RoomItem item, bool complete)
		{
			RoomItemUpgradeComponent component = item.GetComponent<RoomItemUpgradeComponent>();
			if (component != null && component.Job != null)
			{
				RemoveJob(component.Job, complete);
				if (complete)
				{
					component.Job = null;
				}
			}
		}

		private void CreateMaintenanceJob(RoomItem roomItem)
		{
			if (!(roomItem.FloorPlan is BlueprintFloorPlan))
			{
				RoomItemMaintenanceComponent orAddComponent = roomItem.GetOrAddComponent<RoomItemMaintenanceComponent>();
				if (orAddComponent.Job == null && !roomItem.Definition.IgnoredByJanitors)
				{
					orAddComponent.Job = new JobMaintenance(roomItem);
					AddJob(orAddComponent.Job);
				}
			}
		}

		private void AddMaintenanceJob(RoomItem roomItem)
		{
			if (!(roomItem.FloorPlan is BlueprintFloorPlan))
			{
				RoomItemMaintenanceComponent component = roomItem.GetComponent<RoomItemMaintenanceComponent>();
				if (component != null && component.Job != null && !roomItem.Definition.IgnoredByJanitors)
				{
					AddJob(component.Job);
				}
			}
		}

		private void RemoveMaintenanceJob(RoomItem item, Staff staff, JobMaintenance job)
		{
			if (item.IsRepaired())
			{
				RemoveMaintenanceJobInternal(item, complete: true);
				item.RemoveComponents<RoomItemMaintenanceComponent>();
			}
		}

		private void RemoveMaintenanceJobInternal(RoomItem item, bool complete)
		{
			if (item.FloorPlan is BlueprintFloorPlan)
			{
				return;
			}
			RoomItemMaintenanceComponent component = item.GetComponent<RoomItemMaintenanceComponent>();
			if (component == null || component.Job == null)
			{
				return;
			}
			JobMaintenance.JobDescription maintenanceDescription = item.Definition.MaintenanceDescription;
			if (maintenanceDescription == JobMaintenance.JobDescription.Litter || maintenanceDescription == JobMaintenance.JobDescription.MedicalWaste)
			{
				Staff staff = component.Job.GetStaff();
				if (staff != null && staff.Interaction != null && staff.Interaction.ParentRoomItem == item)
				{
					complete = true;
				}
			}
			RemoveJob(component.Job, complete);
			if (complete)
			{
				component.Job = null;
			}
		}

		private void OnRoomItemRequestRepair(RoomItem item)
		{
			CreateMaintenanceJob(item);
			item.GetComponent<RoomItemMaintenanceComponent>().Job.BecomeHighPriority();
		}

		private void OnRoomItemCancelRepair(RoomItem item)
		{
			RoomItemMaintenanceComponent component = item.GetComponent<RoomItemMaintenanceComponent>();
			if (component != null && component.Job != null)
			{
				component.Job.BecomeNormalPriority();
			}
		}

		private void CreateFireJob(RoomItem roomItem, RoomItemFlammableComponent flammableComponent)
		{
			if (flammableComponent == null || flammableComponent.Job != null)
			{
				return;
			}
			JobFire job = (JobFire)(flammableComponent.Job = new JobFire(roomItem));
			AddJob(job);
			foreach (Staff item in _staff)
			{
				if (item.RoomUsing == roomItem.OwningRoom)
				{
					_priorityStaff.AddUnique(item);
				}
			}
		}

		private void AddFireJob(RoomItem roomItem)
		{
			RoomItemFlammableComponent component = roomItem.GetComponent<RoomItemFlammableComponent>();
			if (component != null && component.Job != null)
			{
				AddJob(component.Job);
			}
		}

		private void RemoveFireJob(RoomItem roomItem)
		{
			RemoveFireJobInternal(roomItem, complete: true);
		}

		private void RemoveFireJobInternal(RoomItem roomItem, bool complete)
		{
			RoomItemFlammableComponent component = roomItem.GetComponent<RoomItemFlammableComponent>();
			if (component != null && component.Job != null)
			{
				RemoveJob(component.Job, complete);
				if (complete)
				{
					component.Job = null;
				}
			}
		}

		public Staff FindStaffAssignedToJob(RoomItem roomItem)
		{
			foreach (Staff item in _staff)
			{
				if (item.CurrentJob != null)
				{
					if (item.CurrentJob is JobMaintenance jobMaintenance && jobMaintenance.Item == roomItem)
					{
						return item;
					}
					if (item.CurrentJob is JobUpgrade jobUpgrade && jobUpgrade.Item == roomItem)
					{
						return item;
					}
				}
			}
			return null;
		}

		public void GatherJobsOfType<T>(ref List<T> jobList) where T : Job
		{
			foreach (Job job in _jobs)
			{
				if (job is T item)
				{
					jobList.Add(item);
				}
			}
		}

		public void GatherJobRoomsInRoom(ref List<Job> jobList, Room room)
		{
			foreach (Job job in room.Jobs)
			{
				if (job is JobRoom || job is JobService)
				{
					jobList.Add(job);
				}
			}
		}

		private void AddPriorityStaff(RoomItem roomItem, Staff staff, JobMaintenance job)
		{
			_priorityStaff.AddUnique(staff);
		}

		private T FindJobInRoomForStaff<T>(Room room, Staff staff) where T : Job
		{
			foreach (Job job in room.Jobs)
			{
				if (job is T result && job.IsSuitable(staff, checkExclusion: false, out var _))
				{
					return result;
				}
			}
			return null;
		}

		public void StartRoomItemJobForStaff<TJob>(Staff staff, RoomItem roomItem) where TJob : Job
		{
			Job job = roomItem.GetComponent<RoomItemJobComponent>()?.Job;
			if (!(job is TJob) || !job.IsSuitable(staff, checkExclusion: false, out var _))
			{
				job = FindJobInRoomForStaff<TJob>(roomItem.OwningRoom, staff);
			}
			if (job != null && !job.StartJob(staff))
			{
				RemoveInvalidJob(job);
			}
		}
	}
}
