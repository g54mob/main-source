using System;
using UnityEngine;

namespace Gh.Tk
{
	public class Maintainable : AttachedBehaviour
	{
		[PersistenceOptIn]
		public MaintenanceType type;

		[PersistenceOptIn]
		public MaintenanceUpkeep upkeep;

		[PersistenceOptIn]
		public int usesSinceLastMaintenance;

		[PersistenceOptIn]
		public float nextMaintenanceTime;

		[PersistenceOptIn]
		public int usesUntilMaintenance;

		[PersistenceOptIn]
		public bool maintenanceNecessary;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool maintainImmediately;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool SuppressMaintenanceNeed;

		public bool StartsMaintained;

		public string fireSoundEvent;

		private GametimeTimer _maintenanceRequiredTimer;

		private GametimeTimer _turnLightOffTimer;

		private ParticleSystem[] _particleSystems;

		private flickeringLight[] _lights;

		public GameObject[] fireStateOnElements;

		public static EventHandler<EventArgs<Prop>> MaintenanceNecessaryChanged;

		[PersistenceOptIn]
		private bool _isLightOn;

		public bool IsLightOn => false;

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		private void OnIsBrokenChanged(object sender, EventArgs<bool> e)
		{
		}

		public void SetMaintenanceRequired(bool required)
		{
		}

		private float GetTimeUntilMaintenanceRequired()
		{
			return 0f;
		}

		private float HandleFireTraits(float realDelta)
		{
			return 0f;
		}

		private int GetUsesUntilMaintenanceRequired()
		{
			return 0;
		}

		protected virtual void OnMaintenanceNecessaryChanged()
		{
		}

		private void OnPropUsed(object sender, EventArgs e)
		{
		}

		private bool CheckNeedsMaintenance()
		{
			return false;
		}

		public void NotifyMaintenanceCompleted()
		{
		}

		public override void SaveState(IDataStore data)
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}

		private void CreateMaintenanceRequiredTimer()
		{
		}

		private void InstantiateMaitenanceRequiredTimer(float deltaTime)
		{
		}

		private void CreateFireOffTimer()
		{
		}

		protected void SetFireState(bool active)
		{
		}

		private void PlayParticleSystems()
		{
		}

		private void StopParticleSystems()
		{
		}

		private void PlayFireSFX()
		{
		}

		private void StopFireSFX()
		{
		}

		public void ExhaustObject()
		{
		}

		public override void OnDestroy()
		{
		}

		internal void PostBuiltInit()
		{
		}
	}
}
