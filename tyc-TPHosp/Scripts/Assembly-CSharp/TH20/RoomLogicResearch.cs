using System;
using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class RoomLogicResearch : RoomLogic
	{
		[DontSave]
		private List<RoomModifierResearchRate> _researchRateModifiersCached;

		[DontSave]
		private List<Staff> _staffWorkingInRoomCached;

		private static float _itemMultiplier = 1f;

		private static List<ResearchProjectComponent> _componentsCache = new List<ResearchProjectComponent>();

		internal override void InitializeComponent()
		{
			_researchRateModifiersCached = new List<RoomModifierResearchRate>(64);
			_staffWorkingInRoomCached = new List<Staff>(8);
			base.InitializeComponent();
			RegisterEvents();
		}

		public override void Destroy()
		{
			UnregisterEvents();
			base.Destroy();
		}

		internal override void RestoreComponentFromSave()
		{
			_researchRateModifiersCached = new List<RoomModifierResearchRate>(64);
			_staffWorkingInRoomCached = new List<Staff>(8);
			base.RestoreComponentFromSave();
			RegisterEvents();
		}

		private void RegisterEvents()
		{
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnStaffDrop = (Action<Staff, Room, bool>)Delegate.Combine(characterEvents.OnStaffDrop, new Action<Staff, Room, bool>(OnStaffDrop));
		}

		private void UnregisterEvents()
		{
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnStaffDrop = (Action<Staff, Room, bool>)Delegate.Remove(characterEvents.OnStaffDrop, new Action<Staff, Room, bool>(OnStaffDrop));
		}

		public override Job CreateJob(StaffRequired staffRequired)
		{
			return new JobResearch(staffRequired, _room);
		}

		private void OnStaffDrop(Staff staff, Room room, bool jobSearch)
		{
			if (_room != room || !room.IsOpen || !_room.CanAddStaff(staff))
			{
				return;
			}
			RoomItem roomItem = null;
			foreach (RoomItem item in room.FloorPlan.Items)
			{
				ResearchProjectComponent component = item.GetComponent<ResearchProjectComponent>();
				if (component != null && component.Project == null)
				{
					roomItem = item;
					break;
				}
			}
			if (roomItem != null && _room.EnterRoom(staff, ReasonUseRoom.Work))
			{
				base.Level.HUD.CreateMenu<ResearchProjectMenu>().Setup(base.Level, roomItem);
			}
		}

		public override string GetStaffDropResult(Staff staff)
		{
			if (!IsProjectAssigned() && _room.CanAddStaff(staff))
			{
				return ScriptLocalization.Staff.DropResult_StartResearchProject_CS;
			}
			return null;
		}

		public override bool IsProjectAssigned()
		{
			RoomAlgorithms.IterateRoomItemsWithComponent(_room, delegate(ResearchProjectComponent component)
			{
				if (component.Project != null)
				{
					_componentsCache.Add(component);
				}
			});
			bool result = _componentsCache.Count != 0;
			_componentsCache.Clear();
			return result;
		}

		public override void Tick()
		{
			foreach (RoomItem item in _room.FloorPlan.Items)
			{
				ResearchProjectComponent component = item.GetComponent<ResearchProjectComponent>();
				if (component != null && component.Project != null && !component.Project.IsComplete())
				{
					_componentsCache.Add(component);
				}
			}
			if (_componentsCache.Count != 0)
			{
				_staffWorkingInRoomCached.Clear();
				_room.GetStaffWorkingInRoom(_staffWorkingInRoomCached);
				float num = 0f;
				int count = _componentsCache.Count;
				foreach (Staff item2 in _staffWorkingInRoomCached)
				{
					float researchRate = item2.GetResearchRate(_room);
					num += researchRate;
					item2.StaffRecord.RecordResearchContribution(researchRate * (float)count);
				}
				_staffWorkingInRoomCached.Clear();
				_itemMultiplier = 1f;
				foreach (RoomItem item3 in _room.FloorPlan.Items)
				{
					item3.GetRoomModifiersOfType(_researchRateModifiersCached);
					foreach (RoomModifierResearchRate item4 in _researchRateModifiersCached)
					{
						_itemMultiplier += item4.Percentage / 100f;
					}
					_researchRateModifiersCached.Clear();
				}
				num *= _itemMultiplier;
				float points = num / (float)count * Time.deltaTime;
				foreach (ResearchProjectComponent item5 in _componentsCache)
				{
					ResearchProject project = item5.Project;
					if (project != null && project.AddPoints(points))
					{
						string text = ScriptLocalization.Research.ProjectComplete_CS.Replace("{[PROJECT]}", project.Definition.NameLocalised.Translation);
						base.Level.InWorldMessages.ShowMessage(text, item5.GetOwner<RoomItem>().WorldPosition, 3f, InWorldMessages.MessageType.Info);
					}
				}
			}
			_componentsCache.Clear();
		}
	}
}
