using Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events;
using Assets.Nimbatus.Scripts.Characters.Behaviours.Corp;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours
{
	public class ShieldBehaviour : CoreBehaviour
	{
		public CorpShield Shield;

		public SpriteRenderer ShieldStatus;

		public GameObject ActiveIndicator;

		public string ShieldActiveLoop;

		public string ShieldDisableSound;

		private bool _initialized;

		internal bool IsActive;

		private int _initEnergyCount;

		internal int CurrentEnergy;

		private AudioObject _activeLoop;

		protected override void OnInit()
		{
			InteractiveWorldObject.OnNotify += EnergyNotification;
			Shield.Init();
			IsActive = true;
			ActiveIndicator.SetActive(false);
			_activeLoop = AudioController.Play(ShieldActiveLoop, OwnWorldObject.transform);
		}

		protected override void OnUpdate()
		{
			if (!RuntimeGlobals.IsGameLoading && !_initialized && CurrentEnergy >= 1)
			{
				_initialized = true;
				_initEnergyCount = CurrentEnergy;
				Shield.EngageShield();
				IsActive = true;
				ActiveIndicator.SetActive(true);
			}
			if (IsActive)
			{
				ShieldStatus.material.SetFloat("_Fuel", (float)CurrentEnergy / (float)_initEnergyCount);
				if (_initialized && CurrentEnergy == 0)
				{
					Shield.DisengageShield();
					IsActive = false;
					ActiveIndicator.SetActive(false);
					_activeLoop.Stop(0.1f);
					AudioController.Play(ShieldDisableSound, OwnWorldObject.transform);
				}
			}
		}

		public void EnergyNotification(NotificationData data)
		{
			if (data.Notification == ENotificationType.EnergySourceActivated)
			{
				CurrentEnergy++;
			}
			else if (data.Notification == ENotificationType.EnergySourceDestroyed)
			{
				CurrentEnergy--;
			}
		}

		protected override void OnRelease()
		{
			InteractiveWorldObject.OnNotify -= EnergyNotification;
		}
	}
}
