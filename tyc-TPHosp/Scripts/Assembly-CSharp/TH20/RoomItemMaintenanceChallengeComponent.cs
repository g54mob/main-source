using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class RoomItemMaintenanceChallengeComponent : EntityTickComponent
	{
		[SerializeField]
		public string ChallengeScheduleName;

		[SerializeField]
		public float MaintenanceThreshold;

		private ChallengeSchedule _schedule;

		private RoomItem _roomItem;

		[DontSave]
		private ParticleEffectControlComponent _smokeParticleEffectComponent;

		private float _previousMaintenanceLevel;

		public ChallengeSchedule Schedule => _schedule;

		protected override Type ValidEntityType()
		{
			return typeof(RoomItem);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_schedule = base.Level.ChallengeManager.FindChallengeSchedule(ChallengeScheduleName);
			_roomItem = GetOwner<RoomItem>();
			if (_roomItem.Visual == null)
			{
				_roomItem.OnVisualSet += OnVisualRestored;
			}
			else
			{
				OnVisualRestored();
			}
		}

		private void OnVisualRestored()
		{
			_roomItem.OnVisualSet -= OnVisualRestored;
			_smokeParticleEffectComponent = _roomItem?.Visual?.GameObject?.GetComponent<ParticleEffectControlComponent>();
		}

		public override void Tick()
		{
			base.Tick();
			if (_schedule == null || _roomItem == null || _roomItem.MaintenanceLevel == null)
			{
				return;
			}
			float previousMaintenanceLevel = _roomItem.MaintenanceLevel.Value();
			if (_roomItem.MaintenanceLevel.Value() > MaintenanceThreshold)
			{
				if (_previousMaintenanceLevel <= MaintenanceThreshold)
				{
					base.Level.BuildEvents.OnRoomItemMaintenanceChallengeThresholdEntered.InvokeSafe(this);
					if (_smokeParticleEffectComponent != null)
					{
						_smokeParticleEffectComponent.EnableEffect("smoke", enable: true);
					}
				}
			}
			else if (_previousMaintenanceLevel > MaintenanceThreshold)
			{
				base.Level.BuildEvents.OnRoomItemMaintenanceChallengeThresholdExited.InvokeSafe(this);
				if (_smokeParticleEffectComponent != null)
				{
					_smokeParticleEffectComponent.EnableEffect("smoke", enable: false);
				}
			}
			_previousMaintenanceLevel = previousMaintenanceLevel;
		}
	}
}
