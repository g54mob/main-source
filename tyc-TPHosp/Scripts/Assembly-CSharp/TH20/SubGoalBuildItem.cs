using System;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalBuildItem : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionBuildItem _definition;

		private int _numBuilt;

		public SubGoalBuildItem(Objective owner, SubGoalDefinitionBuildItem definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionBuildItem;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionBuildItem)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				BuildEvents buildEvents = Level.BuildEvents;
				buildEvents.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnItemBuilt));
				BuildEvents buildEvents2 = Level.BuildEvents;
				buildEvents2.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents2.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnItemRemoved));
				BuildEvents buildEvents3 = Level.BuildEvents;
				buildEvents3.OnHospitalPlotBought = (Action<HospitalPlot>)Delegate.Combine(buildEvents3.OnHospitalPlotBought, new Action<HospitalPlot>(OnHospitalPlotBought));
			}
		}

		protected override void OnStart()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnItemBuilt));
			BuildEvents buildEvents2 = Level.BuildEvents;
			buildEvents2.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents2.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnItemRemoved));
			BuildEvents buildEvents3 = Level.BuildEvents;
			buildEvents3.OnHospitalPlotBought = (Action<HospitalPlot>)Delegate.Combine(buildEvents3.OnHospitalPlotBought, new Action<HospitalPlot>(OnHospitalPlotBought));
			if (_definition.IncludeExisting)
			{
				if (_definition.ItemList == null || _definition.ItemList.Count == 0)
				{
					_numBuilt = Level.WorldState.GetRoomItemsOfType(_definition.Item.Instance).Count;
				}
				else
				{
					int num = 0;
					foreach (SharedInstance<RoomItemDefinition> item in _definition.ItemList)
					{
						num += Level.WorldState.GetRoomItemsOfType(item.Instance).Count;
					}
					_numBuilt = num;
				}
			}
			base.OnStart();
		}

		protected override void OnEnd()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnItemBuilt));
			BuildEvents buildEvents2 = Level.BuildEvents;
			buildEvents2.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents2.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnItemRemoved));
			BuildEvents buildEvents3 = Level.BuildEvents;
			buildEvents3.OnHospitalPlotBought = (Action<HospitalPlot>)Delegate.Remove(buildEvents3.OnHospitalPlotBought, new Action<HospitalPlot>(OnHospitalPlotBought));
			base.OnEnd();
		}

		private void OnItemRemoved(RoomItem item, FloorPlan floorPlan)
		{
			if ((_definition.Item != null && item.Definition == _definition.Item.Instance) || ItemExistsInList(item.Definition))
			{
				_numBuilt--;
				UpdateProgress();
			}
		}

		private void OnItemBuilt(RoomItem item, FloorPlan floorPlan)
		{
			if ((_definition.Item != null && item.Definition == _definition.Item.Instance) || ItemExistsInList(item.Definition))
			{
				_numBuilt++;
				UpdateProgress();
			}
		}

		private void OnHospitalPlotBought(HospitalPlot plot)
		{
			foreach (HospitalPlotItem item in plot.Definition.GetItems(HospitalPlotLayer.Built))
			{
				RoomItemDefinition instance = item.Definition.Instance;
				if ((_definition.Item != null && instance == _definition.Item.Instance) || ItemExistsInList(instance))
				{
					_numBuilt++;
				}
			}
			UpdateProgress();
		}

		private bool ItemExistsInList(IRoomItemDefinition itemDefinition)
		{
			if (_definition.ItemList != null)
			{
				foreach (SharedInstance<RoomItemDefinition> item in _definition.ItemList)
				{
					if (itemDefinition == item.Instance)
					{
						return true;
					}
				}
			}
			return false;
		}

		protected override bool HasCompleted()
		{
			return _numBuilt >= _definition.ItemCount;
		}

		public override float PercentComplete()
		{
			return (float)_numBuilt / (float)_definition.ItemCount;
		}

		public override int Score()
		{
			return _numBuilt;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_numBuilt} / {_definition.ItemCount}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
