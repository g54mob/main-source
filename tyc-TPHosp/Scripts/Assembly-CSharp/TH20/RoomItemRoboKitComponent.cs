#define LOG_LEVEL_VERBOSE
using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly]
	public class RoomItemRoboKitComponent : EntityTickComponent
	{
		[UsedImplicitly]
		private class LevelLimit
		{
			public int Count = 1;

			public SharedInstance<RoboJanitorDefinition> Definition;
		}

		[SerializeField]
		private bool _editingScenario;

		[SerializeField]
		private LevelLimit[] _levelLimits;

		[SerializeField]
		private SharedInstance<RoboJanitorDefinition>[] _janitorDefinitions;

		[SerializeField]
		private SharedInstance<RoboJanitorDefinition> _janitorToSpawn;

		private RoboJanitorDefinition _selectedJanitor;

		public SharedInstance<RoboJanitorDefinition>[] JanitorDefinitions => _janitorDefinitions;

		protected override Type ValidEntityType()
		{
			return typeof(RoomItem);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			if (_janitorToSpawn.IsNull())
			{
				SetComponentTickEnabled(enabled: false);
			}
			else
			{
				SetComponentTickEnabled(enabled: true);
			}
		}

		public void SelectJanitor(RoboJanitorDefinition definition)
		{
			_selectedJanitor = definition;
			SetComponentTickEnabled(enabled: true);
			Logging.Info(LogChannels.Debug, _selectedJanitor.Name.GetCharacterName() ?? "");
		}

		public override void Tick()
		{
			base.Tick();
			if (_janitorToSpawn.IsNull())
			{
				if (_selectedJanitor != null)
				{
					SpawnJanitor();
				}
			}
			else if (!_editingScenario)
			{
				RoomItem owner = GetOwner<RoomItem>();
				if (owner.FloorPlan != null && owner.FloorPlan.Items.Contains(owner))
				{
					_selectedJanitor = _janitorToSpawn.Instance;
					SpawnJanitor();
				}
			}
		}

		private void SpawnJanitor()
		{
			RoomItem owner = GetOwner<RoomItem>();
			Level level = owner.Level;
			Vector3 worldPosition = owner.WorldPosition;
			JobApplicant applicant = new JobApplicant(_selectedJanitor);
			Staff staff = level.CharacterManager.SpawnStaff(applicant, worldPosition, navDisabled: false);
			bool flag = _janitorToSpawn.NotNull();
			staff.JobExclusions.AddRange(_selectedJanitor.JobExclusions);
			if (flag)
			{
				staff.GetComponent<RoboJanitorComponent>().SpawnedInLevel = true;
			}
			level.CharacterEvents.OnStaffHired.InvokeSafe(staff, applicant, (!flag) ? _selectedJanitor.UpfrontCost : 0);
			level.BuildEvents.OnRoomItemDestroy.InvokeSafe(owner);
		}

		public bool SpawnAllowed(RoboJanitorDefinition definition)
		{
			if (!LimitReached(definition))
			{
				return CanAfford(definition);
			}
			return false;
		}

		public bool CanAfford(RoboJanitorDefinition definition)
		{
			bool result = false;
			Entity owner = GetOwner();
			if (owner != null)
			{
				result = owner.Level.FinanceManager.CanAfford(definition.UpfrontCost);
			}
			return result;
		}

		public bool LimitReached(RoboJanitorDefinition definition)
		{
			if (_levelLimits == null)
			{
				return false;
			}
			LevelLimit[] levelLimits = _levelLimits;
			foreach (LevelLimit levelLimit in levelLimits)
			{
				RoboJanitorDefinition instance = levelLimit.Definition.Instance;
				if (instance == definition && RoboJanitorComponent.NumSpawned(instance) >= levelLimit.Count)
				{
					return true;
				}
			}
			return false;
		}
	}
}
