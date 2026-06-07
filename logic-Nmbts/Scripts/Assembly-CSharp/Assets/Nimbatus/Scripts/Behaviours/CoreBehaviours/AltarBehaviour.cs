using Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events;
using Assets.Nimbatus.Scripts.Characters.Behaviours.Corp;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours
{
	public class AltarBehaviour : CoreBehaviour
	{
		public CorpShield Shield;

		public InteractiveWorldObject Relic;

		public GameObject DummyRelic;

		public float EjectForce = 1f;

		public string EjectSound;

		private bool _initialized;

		private bool _shieldActive;

		private int _initTorchCount;

		private int _torchCount;

		protected override void OnInit()
		{
			InteractiveWorldObject.OnNotify += TorchNotification;
			Shield.Init();
		}

		protected override void OnUpdate()
		{
			if (!RuntimeGlobals.IsGameLoading && !_initialized && _initTorchCount >= 1)
			{
				_initialized = true;
				Shield.EngageShield();
				_shieldActive = true;
			}
			if (_shieldActive && _torchCount == _initTorchCount)
			{
				Shield.DisengageShield();
				Shield.GetComponent<Collider>().enabled = false;
				_shieldActive = false;
				SpawnRelic();
			}
		}

		private void SpawnRelic()
		{
			DummyRelic.gameObject.SetActive(false);
			InteractiveWorldObject interactiveWorldObject = Object.Instantiate(Relic, DummyRelic.transform.position, OwnWorldObject.transform.rotation);
			interactiveWorldObject.Rigidbody.AddForce(interactiveWorldObject.transform.up * EjectForce, ForceMode.Impulse);
			AudioController.Play(EjectSound, interactiveWorldObject.transform.position);
		}

		public void TorchNotification(NotificationData data)
		{
			if (data.Notification == ENotificationType.TorchActivated)
			{
				_initTorchCount++;
			}
			else if (data.Notification == ENotificationType.TorchLit)
			{
				_torchCount++;
			}
			else if (data.Notification == ENotificationType.TorchUnlit)
			{
				_torchCount--;
			}
		}

		protected override void OnRelease()
		{
			InteractiveWorldObject.OnNotify -= TorchNotification;
		}
	}
}
