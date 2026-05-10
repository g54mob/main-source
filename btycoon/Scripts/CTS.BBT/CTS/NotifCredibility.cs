using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class NotifCredibility : CTSBehaviour
	{
		[SerializeField]
		private NotificationData _notificationData;

		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private Notifications _notificationManager;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			BodyDisposalCredibility.AnyCredibilityChanged += OnCredibilityChanged;
			Agent.AgentDespawned += OnAgentDespawned;
			Agent.Died += OnAgentDied;
			Furniture.FurniturePlaced += OnFurniturePlaced;
			Furniture.FurnitureSold += OnFurnitureSold;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			BodyDisposalCredibility.AnyCredibilityChanged -= OnCredibilityChanged;
			Agent.AgentDespawned -= OnAgentDespawned;
			Agent.Died -= OnAgentDied;
			Furniture.FurniturePlaced -= OnFurniturePlaced;
			Furniture.FurnitureSold -= OnFurnitureSold;
		}

		public void Recalculate()
		{
			int num = 0;
			foreach (IBodyDisposalMachine item in CTSSingleton<BarFurnitures>.Instance.Enumerate<IBodyDisposalMachine>())
			{
				num = Mathf.Max(num, item.MachineCredibility.Credibility);
			}
			if (IsAnyDeadBodyOverCredibility(num))
			{
				if (!_notificationManager.HasNotification(_notificationData))
				{
					_notificationManager.ShowNotification(_notificationData);
				}
			}
			else
			{
				_notificationManager.RemoveAll(_notificationData);
			}
		}

		private void OnFurnitureSold(Furniture furniture)
		{
			FurnitureInteractor interactor = furniture.Interactor;
			if (interactor is IBodyDisposalMachine || interactor is StationMorgue)
			{
				Recalculate();
			}
		}

		private void OnFurniturePlaced(Furniture furniture)
		{
			if (_notificationManager.HasNotification(_notificationData))
			{
				FurnitureInteractor interactor = furniture.Interactor;
				if (interactor is IBodyDisposalMachine || interactor is StationMorgue)
				{
					Recalculate();
				}
			}
		}

		private void OnAgentDied(Agent obj)
		{
			Recalculate();
		}

		private void OnCredibilityChanged()
		{
			Recalculate();
		}

		private void OnAgentDespawned(Agent agent)
		{
			if (_notificationManager.HasNotification(_notificationData))
			{
				Recalculate();
			}
		}

		private bool IsAnyDeadBodyOverCredibility(int credibility)
		{
			foreach (BodyBag item in StaticObjectSet<BodyBag>.List)
			{
				if (item.BodyData.Credibility > credibility)
				{
					return true;
				}
			}
			foreach (Customer humans in CustomerManager.HumansList)
			{
				if (humans.IsDead && humans.Credibility > credibility)
				{
					return true;
				}
			}
			foreach (StationMorgue item2 in CTSSingleton<BarFurnitures>.Instance.Enumerate<StationMorgue>())
			{
				foreach (DeadBodyData deadBody in item2.DeadBodies)
				{
					if (deadBody.Credibility > credibility)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
