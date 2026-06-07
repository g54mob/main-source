using Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours
{
	public class WarpDriveAnchoringBehaviour : CoreBehaviour
	{
		public GameObject[] GameObjectsToActivate;

		public HealthPool[] HealthPoolsToDie;

		private bool _initialized;

		private bool _isContainerDestroyed;

		private bool _didThings;

		protected override void OnInit()
		{
			InteractiveWorldObject.OnNotify += ContainerNotification;
		}

		protected override void OnUpdate()
		{
			if (!RuntimeGlobals.IsGameLoading && !_initialized)
			{
				_initialized = true;
			}
			if (!_isContainerDestroyed || _didThings)
			{
				return;
			}
			GameObject[] gameObjectsToActivate = GameObjectsToActivate;
			foreach (GameObject obj in gameObjectsToActivate)
			{
				if ((object)obj != null)
				{
					obj.SetActive(true);
				}
			}
			HealthPool[] healthPoolsToDie = HealthPoolsToDie;
			foreach (HealthPool obj2 in healthPoolsToDie)
			{
				if ((object)obj2 != null)
				{
					obj2.Die();
				}
			}
			Debug.Log("WarpDrive Container destroyed! Self Destruction Sequence initiated!");
			_didThings = true;
		}

		public void ContainerNotification(NotificationData data)
		{
			if (data.Notification == ENotificationType.WarpDriveContainerDestroyed)
			{
				_isContainerDestroyed = true;
			}
		}

		protected override void OnRelease()
		{
			InteractiveWorldObject.OnNotify -= ContainerNotification;
		}
	}
}
