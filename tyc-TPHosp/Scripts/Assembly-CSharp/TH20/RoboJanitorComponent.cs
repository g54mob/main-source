#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly]
	public class RoboJanitorComponent : EntityTickComponent
	{
		public bool SpawnedInLevel;

		private bool _hibernate;

		private Vector3 _spawnPosition;

		private static Dictionary<RoboJanitorDefinition, List<RoboJanitorComponent>> _spawnedJanitors = new Dictionary<RoboJanitorDefinition, List<RoboJanitorComponent>>();

		protected override Type ValidEntityType()
		{
			return typeof(Staff);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			if (!IsInBoughtPlot())
			{
				SetHibernation(hibernate: true);
			}
			AddSpawnedJanitor();
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			if (_hibernate)
			{
				GetOwner<Staff>().Animator.speed = 0.001f;
			}
			AddSpawnedJanitor();
		}

		private void AddSpawnedJanitor()
		{
			RoboJanitorDefinition definition = GetOwner<Staff>().GetDefinition<RoboJanitorDefinition>();
			if (_spawnedJanitors.TryGetValue(definition, out var value))
			{
				value.Add(this);
				return;
			}
			_spawnedJanitors.Add(definition, new List<RoboJanitorComponent> { this });
		}

		public override void Destroy()
		{
			RoboJanitorDefinition definition = GetOwner<Staff>().GetDefinition<RoboJanitorDefinition>();
			if (_spawnedJanitors.TryGetValue(definition, out var value))
			{
				value.Remove(this);
			}
			else
			{
				Logging.Error(LogChannels.Debug, "Trying to remove RoboJanitorComponent that doesn't exist");
			}
			base.Destroy();
		}

		private void SetHibernation(bool hibernate)
		{
			Staff owner = GetOwner<Staff>();
			_hibernate = hibernate;
			if (hibernate)
			{
				owner.Animator.speed = 0.001f;
				owner.EnableBehaviour(enabled: false);
				owner.NavPath.RemoveFromNavWorld();
				_spawnPosition = owner.Position;
			}
			else
			{
				owner.Animator.speed = 1f;
				owner.EnableBehaviour(enabled: true);
				owner.NavPath.PutBackInNavWorld();
			}
		}

		private bool IsInBoughtPlot()
		{
			Staff owner = GetOwner<Staff>();
			HospitalMap hospitalMapAtWorldPosition = owner.Level.WorldState.GetHospitalMapAtWorldPosition(owner.Position);
			if (hospitalMapAtWorldPosition != null && hospitalMapAtWorldPosition.Plot.Bought)
			{
				return true;
			}
			return false;
		}

		public override void Tick()
		{
			base.Tick();
			Staff owner = GetOwner<Staff>();
			if (_hibernate)
			{
				owner.Position = _spawnPosition;
				if (IsInBoughtPlot())
				{
					SetHibernation(hibernate: false);
				}
			}
			else if (owner.CurrentMode == Staff.Mode.Break && owner.Energy.Value() >= 100f)
			{
				owner.Idle();
			}
		}

		public static int NumSpawned(RoboJanitorDefinition definition)
		{
			if (!_spawnedJanitors.TryGetValue(definition, out var value))
			{
				return 0;
			}
			return value.Count;
		}
	}
}
