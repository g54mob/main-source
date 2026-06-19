using System;
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using TH20.EventStaffHired;
using UnityEngine;

namespace TH20
{
	public class WorkLifeBalanceManager : MustCallDestroy, Interface, IGameEventCallback
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public StaffCategory[] StaffCategories;

			public SharedInstance<ObjectiveDefinition> ResignationObjective;
		}

		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class StaffCategory
		{
			public StaffDefinition.Type StaffType;

			public int StaffRank = -1;

			public float InitialSliderValue = 0.5f;

			public float MinPercent = 10f;

			public float MaxPercent = 90f;
		}

		public class BalanceData
		{
			public StaffCategory Category;

			public float Value = 1f;

			public List<Staff> Staff = new List<Staff>();

			public List<Staff> StaffOnBreak = new List<Staff>();

			public List<Staff> StaffRequestBreak = new List<Staff>();

			public int NumAllowedBreak()
			{
				int count = Staff.Count;
				float num = Mathf.Lerp(Category.MinPercent, Category.MaxPercent, Value) / 100f;
				return Mathf.CeilToInt((float)count * num);
			}

			public bool AllowBreak()
			{
				int count = StaffOnBreak.Count;
				int num = NumAllowedBreak();
				return count < num;
			}

			public bool SendLowestEnergyStaffMemberOnBreak()
			{
				if (StaffRequestBreak.Count != 0 && AllowBreak())
				{
					StaffRequestBreak.Sort((Staff staff2, Staff staff3) => staff2.Energy.Value().CompareTo(staff3.Energy.Value()));
					Staff staff = StaffRequestBreak[0];
					staff.TakeBreak();
					StaffRequestBreak.Remove(staff);
					return true;
				}
				return false;
			}
		}

		private readonly Level _level;

		private readonly Config _config;

		private readonly List<BalanceData> _balanceData;

		private float _lastResignationTime;

		private readonly List<Staff> _staffThreatingToLeave;

		[DontSave]
		private GUIStyle _debugGUIStyle;

		public int StaffThreatingToLeave => _staffThreatingToLeave.Count;

		public WorkLifeBalanceManager(Config config, Level level)
		{
			_config = config;
			_level = level;
			_balanceData = new List<BalanceData>();
			_staffThreatingToLeave = new List<Staff>();
			StaffCategory[] staffCategories = config.StaffCategories;
			foreach (StaffCategory staffCategory in staffCategories)
			{
				_balanceData.Add(new BalanceData
				{
					Category = staffCategory,
					Value = staffCategory.InitialSliderValue
				});
			}
			level.PostConstruct = (System.Action)Delegate.Combine(level.PostConstruct, (System.Action)delegate
			{
				BindEvents();
				_level.CharacterEvents.OnStaffHired.Add(this);
				_lastResignationTime = 0f - GameAlgorithms.Config.StaffResignationFrequencyInSeconds;
			});
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			BindEvents();
		}

		private void BindEvents()
		{
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffTakeBreak = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffTakeBreak, new Action<Staff>(OnStaffTakeBreak));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnStaffAssignedJob = (Action<Room, Staff, Job, bool>)Delegate.Combine(characterEvents2.OnStaffAssignedJob, new Action<Room, Staff, Job, bool>(OnStaffAssignedJob));
			CharacterEvents characterEvents3 = _level.CharacterEvents;
			characterEvents3.OnCharacterDestroyed = (Action<Character>)Delegate.Combine(characterEvents3.OnCharacterDestroyed, new Action<Character>(OnRemoveCharacter));
			CharacterEvents characterEvents4 = _level.CharacterEvents;
			characterEvents4.OnStaffResigned = (Action<Staff>)Delegate.Combine(characterEvents4.OnStaffResigned, new Action<Staff>(OnRemoveCharacter));
			CharacterEvents characterEvents5 = _level.CharacterEvents;
			characterEvents5.OnStaffFired = (Action<Staff>)Delegate.Combine(characterEvents5.OnStaffFired, new Action<Staff>(OnRemoveCharacter));
			CharacterEvents characterEvents6 = _level.CharacterEvents;
			characterEvents6.OnStaffThreatenToLeave = (Action<Staff>)Delegate.Combine(characterEvents6.OnStaffThreatenToLeave, new Action<Staff>(OnStaffThreatenToLeave));
			CharacterEvents characterEvents7 = _level.CharacterEvents;
			characterEvents7.OnStaffStopThreateningToLeave = (Action<Staff>)Delegate.Combine(characterEvents7.OnStaffStopThreateningToLeave, new Action<Staff>(OnStaffStopThreateningToLeave));
		}

		public override void Destroy()
		{
			_level.CharacterEvents.OnStaffHired.Remove(this);
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffTakeBreak = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffTakeBreak, new Action<Staff>(OnStaffTakeBreak));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnStaffAssignedJob = (Action<Room, Staff, Job, bool>)Delegate.Remove(characterEvents2.OnStaffAssignedJob, new Action<Room, Staff, Job, bool>(OnStaffAssignedJob));
			CharacterEvents characterEvents3 = _level.CharacterEvents;
			characterEvents3.OnCharacterDestroyed = (Action<Character>)Delegate.Remove(characterEvents3.OnCharacterDestroyed, new Action<Character>(OnRemoveCharacter));
			CharacterEvents characterEvents4 = _level.CharacterEvents;
			characterEvents4.OnStaffResigned = (Action<Staff>)Delegate.Remove(characterEvents4.OnStaffResigned, new Action<Staff>(OnRemoveCharacter));
			CharacterEvents characterEvents5 = _level.CharacterEvents;
			characterEvents5.OnStaffFired = (Action<Staff>)Delegate.Remove(characterEvents5.OnStaffFired, new Action<Staff>(OnRemoveCharacter));
			CharacterEvents characterEvents6 = _level.CharacterEvents;
			characterEvents6.OnStaffThreatenToLeave = (Action<Staff>)Delegate.Remove(characterEvents6.OnStaffThreatenToLeave, new Action<Staff>(OnStaffThreatenToLeave));
			CharacterEvents characterEvents7 = _level.CharacterEvents;
			characterEvents7.OnStaffStopThreateningToLeave = (Action<Staff>)Delegate.Remove(characterEvents7.OnStaffStopThreateningToLeave, new Action<Staff>(OnStaffStopThreateningToLeave));
			base.Destroy();
		}

		public void Update()
		{
			List<Staff> list = new List<Staff>();
			foreach (BalanceData balanceDatum in _balanceData)
			{
				foreach (Staff item in balanceDatum.StaffOnBreak)
				{
					if (item.IsFitForWork())
					{
						list.Add(item);
					}
				}
			}
			foreach (Staff item2 in list)
			{
				OnStaffEndBreak(item2);
			}
			UpdateResignations();
		}

		private void UpdateResignations()
		{
			if (GameTime.time - _lastResignationTime > GameAlgorithms.Config.StaffResignationFrequencyInSeconds && _staffThreatingToLeave.Count != 0)
			{
				_staffThreatingToLeave.Sort((Staff staff2, Staff staff3) => (staff2.Happiness != null) ? staff2.Happiness.Value().CompareTo((staff3.Happiness != null) ? staff3.Happiness.Value() : 0f) : 0);
				Staff staff = _staffThreatingToLeave[0];
				_lastResignationTime = GameTime.time;
				_staffThreatingToLeave.Remove(staff);
				staff.AddComponent<StaffThreatingToLeaveComponent>().Setup(_config.ResignationObjective.Instance);
			}
		}

		public void OnStaffHiredEvent(Staff staff, JobApplicant applicant, int fee)
		{
			GetBalanceData(staff)?.Staff.Add(staff);
		}

		private void OnRemoveCharacter(Character character)
		{
			if (character is Staff staff)
			{
				BalanceData balanceData = GetBalanceData(staff);
				if (balanceData != null)
				{
					balanceData.Staff.Remove(staff);
					balanceData.StaffOnBreak.Remove(staff);
					balanceData.StaffRequestBreak.Remove(staff);
				}
				OnStaffStopThreateningToLeave(staff);
			}
		}

		private void OnStaffTakeBreak(Staff staff)
		{
			BalanceData balanceData = GetBalanceData(staff);
			if (balanceData != null)
			{
				balanceData.StaffOnBreak.Add(staff);
				balanceData.StaffRequestBreak.Remove(staff);
			}
		}

		private void OnStaffEndBreak(Staff staff)
		{
			BalanceData balanceData = GetBalanceData(staff);
			if (balanceData != null)
			{
				balanceData.StaffOnBreak.Remove(staff);
				balanceData.SendLowestEnergyStaffMemberOnBreak();
			}
		}

		private void OnStaffAssignedJob(Room room, Staff staff, Job job, bool WasOnBreak)
		{
			OnStaffEndBreak(staff);
		}

		private void OnStaffThreatenToLeave(Staff staff)
		{
			if (staff.GetComponent<StaffThreatingToLeaveComponent>() == null)
			{
				_staffThreatingToLeave.AddUnique(staff);
			}
		}

		private void OnStaffStopThreateningToLeave(Staff staff)
		{
			_staffThreatingToLeave.Remove(staff);
		}

		private BalanceData GetBalanceData(Staff staff)
		{
			return GetBalanceData(staff.Definition._type, staff.Rank);
		}

		public BalanceData GetBalanceData(StaffDefinition.Type type, int rank)
		{
			foreach (BalanceData balanceDatum in _balanceData)
			{
				if (balanceDatum.Category.StaffType == type && (balanceDatum.Category.StaffRank == -1 || balanceDatum.Category.StaffRank == rank))
				{
					return balanceDatum;
				}
			}
			return null;
		}

		public float GetWorkLifeBalance(StaffDefinition.Type staffType, int rank)
		{
			return GetBalanceData(staffType, rank)?.Value ?? 0f;
		}

		public float GetBreakDuration(StaffDefinition.Type staffType, int rank)
		{
			float workLifeBalance = GetWorkLifeBalance(staffType, rank);
			return Mathf.Lerp(GameAlgorithms.Config.StaffBreakDurationMin, GameAlgorithms.Config.StaffBreakDurationMax, workLifeBalance);
		}

		public void SetWorkLifeBalance(StaffDefinition.Type staffType, int rank, float value)
		{
			BalanceData balanceData = GetBalanceData(staffType, rank);
			if (balanceData != null)
			{
				balanceData.Value = value;
				while (balanceData.SendLowestEnergyStaffMemberOnBreak())
				{
				}
			}
		}

		public bool CanTakeBreak(Staff staff)
		{
			return GetBalanceData(staff)?.AllowBreak() ?? true;
		}

		public void RequestBreak(Staff staff)
		{
			GetBalanceData(staff)?.StaffRequestBreak.AddUnique(staff);
		}

		private void CacheGUIStyle()
		{
			if (_debugGUIStyle == null)
			{
				_debugGUIStyle = new GUIStyle(GUI.skin.box)
				{
					alignment = TextAnchor.UpperLeft,
					font = Font.CreateDynamicFontFromOSFont("Courier New", 12),
					fontStyle = FontStyle.Bold
				};
			}
		}

		public void DebugGUI()
		{
			if (!DebugVars.ShowWorkLifeBalance.Value)
			{
				return;
			}
			CacheGUIStyle();
			string text = "Work Life Balance";
			foreach (BalanceData balanceDatum in _balanceData)
			{
				StaffCategory category = balanceDatum.Category;
				text += $"\n{category.StaffType,11} ({category.StaffRank,3}) ({balanceDatum.Value,3}): {balanceDatum.Staff.Count,3} total. {balanceDatum.StaffOnBreak.Count,3} on break. {balanceDatum.NumAllowedBreak(),3} allowed.";
			}
			Vector2 vector = _debugGUIStyle.CalcSize(new GUIContent(text));
			GUI.Box(new Rect(0f, 0f, vector.x, vector.y), text, _debugGUIStyle);
		}
	}
}
