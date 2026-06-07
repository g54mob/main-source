using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class Shop : WorldManager
	{
		private List<EPaymentMethod> m_availablePaymentMethods = new List<EPaymentMethod>
		{
			EPaymentMethod.CASH,
			EPaymentMethod.CARD
		};

		private string m_name;

		private Queue<int> m_clientQueue = new Queue<int>();

		private HashSet<AIClientBehaviour> m_clientsInside = new HashSet<AIClientBehaviour>();

		private readonly Dictionary<Vector2Int, Stand> m_stands = new Dictionary<Vector2Int, Stand>();

		private readonly Dictionary<EStandType, List<Stand>> m_standsByType = new Dictionary<EStandType, List<Stand>>();

		public bool HasOpen { get; private set; }

		public bool Open { get; private set; }

		public string ShopName
		{
			get
			{
				return m_name;
			}
			set
			{
				m_name = value;
				Shop.NameChanged?.Invoke();
			}
		}

		public int MaxClientsInside { get; protected set; }

		public int ClientCount => m_clientsInside.Count;

		public bool HasClientInQueue => m_clientQueue.Count > 0;

		public HashSet<AIClientBehaviour> ClientsInside => m_clientsInside;

		public static event Action NameChanged;

		public static event Action<int> ClientVisited;

		public static event Action GotEmpty;

		protected override void OnEnable()
		{
			base.OnEnable();
			ShopExtensionSystem.ShopExtensionBought += OnShopExtension;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			ShopExtensionSystem.ShopExtensionBought -= OnShopExtension;
		}

		protected override void OnWorldEvent(EWorldEvent worldEvent)
		{
			base.OnWorldEvent(worldEvent);
			switch (worldEvent)
			{
			case EWorldEvent.LOADING_PHASE1:
				LoadPhase1();
				break;
			case EWorldEvent.SAVE:
				Save();
				break;
			}
		}

		protected override void OnGameEvent(EGameEvent gameEvent)
		{
			base.OnGameEvent(gameEvent);
			switch (gameEvent)
			{
			case EGameEvent.DAY_START:
				Open = false;
				HasOpen = false;
				break;
			case EGameEvent.OPEN_SHOP:
				Open = true;
				HasOpen = true;
				CheckClientQueue();
				break;
			case EGameEvent.CLOSE_SHOP:
				Open = false;
				break;
			}
		}

		public bool IsPaymentMethodAvailable(EPaymentMethod method)
		{
			return m_availablePaymentMethods.Contains(method);
		}

		private void LoadPhase1()
		{
			m_name = SaveManager.CurrentSave.shop.shopName;
			foreach (int item in SaveManager.CurrentSave.shop.shopClientQueue)
			{
				m_clientQueue.Enqueue(item);
			}
			foreach (BoxSaveState simpleBox in SaveManager.CurrentSave.shop.simpleBoxes)
			{
				BaseBox.LoadBoxFromSave(simpleBox);
			}
			foreach (StackableBoxSaveState stackableBox in SaveManager.CurrentSave.shop.stackableBoxes)
			{
				BaseBox.LoadBoxFromSave(stackableBox);
			}
		}

		private void Save()
		{
			SaveManager.CurrentSave.shop.shopName = ShopName;
			SaveManager.CurrentSave.shop.shopOpen = Open;
			if (m_clientQueue.Count > 0)
			{
				SaveManager.CurrentSave.shop.shopClientQueue = m_clientQueue.ToList();
			}
			SaveManager.CurrentSave.shop.SaveBoxes();
			SaveManager.CurrentSave.shop.shopOpenThisDay = HasOpen;
		}

		public virtual bool CanAcceptNewClient(ClientCharacter clientCharacter)
		{
			if (m_clientsInside.IsValid())
			{
				foreach (AIClientBehaviour item in m_clientsInside)
				{
					if (item.Character.ModelIndex == clientCharacter.ModelIndex)
					{
						return false;
					}
				}
			}
			return true;
		}

		public bool ContainsSameModel(ClientCharacter clientCharacter)
		{
			if (m_clientsInside.IsValid())
			{
				foreach (AIClientBehaviour item in m_clientsInside)
				{
					if (item.Character.ModelIndex == clientCharacter.ModelIndex)
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool HasSpaceForNewClient()
		{
			if (!Open)
			{
				return false;
			}
			return ClientCount < MaxClientsInside;
		}

		public void ClientEnter(AIClientBehaviour behaviour)
		{
			m_clientsInside.Add(behaviour);
		}

		public void ClientExit(AIClientBehaviour behaviour, int satisfaction)
		{
			if (m_clientsInside.Remove(behaviour))
			{
				Shop.ClientVisited?.Invoke(satisfaction);
			}
			CheckClientQueue();
			if (ClientCount == 0)
			{
				Shop.GotEmpty?.Invoke();
			}
		}

		public void AddClientToQueue(AIClientBehaviour client)
		{
			m_clientQueue.Enqueue(client.GameID);
		}

		private void CheckClientQueue()
		{
			if (!TimeController.IsDay)
			{
				while (HasClientInQueue)
				{
					AIClientBehaviour clientByID = World.ClientManager.GetClientByID(m_clientQueue.Dequeue());
					if (clientByID != null && clientByID.ClientState == EClientState.WAITING_TO_ACCESS_SHOP)
					{
						clientByID.GoAutoDestroy();
					}
				}
				return;
			}
			List<int> list = new List<int>();
			foreach (AIClientBehaviour item in m_clientsInside)
			{
				list.Add(item.Character.ModelIndex);
			}
			while (HasClientInQueue && HasSpaceForNewClient())
			{
				AIClientBehaviour clientByID = World.ClientManager.GetClientByID(m_clientQueue.Dequeue());
				if (clientByID != null && clientByID.ClientState == EClientState.WAITING_TO_ACCESS_SHOP && !list.Contains(clientByID.Character.ModelIndex))
				{
					clientByID.EnterShop();
					list.Add(clientByID.Character.ModelIndex);
				}
			}
		}

		public void RegisterStand(Stand stand)
		{
			m_stands[stand.ID] = stand;
			if (m_standsByType.TryGetValue(stand.Type, out var value))
			{
				value.Add(stand);
				return;
			}
			value = new List<Stand> { stand };
			m_standsByType[stand.Type] = value;
		}

		public void UnregisterStand(Stand stand)
		{
			m_stands.Remove(stand.ID);
			if (m_standsByType.TryGetValue(stand.Type, out var value))
			{
				value.Remove(stand);
			}
		}

		public bool TryGetStandByID(Vector2Int id, out Stand stand)
		{
			return m_stands.TryGetValue(id, out stand);
		}

		public bool HasStandOfType(EStandType type)
		{
			if (m_standsByType.TryGetValue(type, out var value))
			{
				return value.IsValid();
			}
			return false;
		}

		public IEnumerable<Stand> GetAllStandsOfType(EStandType type)
		{
			if (!m_standsByType.TryGetValue(type, out var value))
			{
				yield break;
			}
			foreach (Stand item in value)
			{
				if (item != null)
				{
					yield return item;
				}
			}
		}

		public bool TryGetBestStandOfType(EStandType type, out Stand stand)
		{
			if (m_standsByType.TryGetValue(type, out var value))
			{
				Stand stand2 = null;
				int num = int.MaxValue;
				foreach (Stand item in value)
				{
					if (item.FreePlacesCount > 0)
					{
						stand = item;
						return true;
					}
					if (item.QueueSize < num)
					{
						stand2 = item;
						num = item.QueueSize;
					}
				}
				stand = stand2;
				return stand != null;
			}
			stand = null;
			return false;
		}

		public IEnumerable<Stand> GetAllClientStands()
		{
			if (m_standsByType.TryGetValue(EStandType.SHELF, out var value))
			{
				foreach (Stand item in value)
				{
					yield return item;
				}
			}
			if (!m_standsByType.TryGetValue(EStandType.STALL, out var value2))
			{
				yield break;
			}
			foreach (Stand item2 in value2)
			{
				yield return item2;
			}
		}

		public bool TryGetValidClientStandUnvisited(IStandUser user, List<Vector2Int> visitedStands, out Stand nextStand)
		{
			Dictionary<int, List<Stand>> dictionary = new Dictionary<int, List<Stand>>();
			List<Stand> list = new List<Stand>();
			if (m_standsByType.TryGetValue(EStandType.SHELF, out var value))
			{
				list.AddRange(value);
			}
			if (m_standsByType.TryGetValue(EStandType.STALL, out var value2))
			{
				list.AddRange(value2);
			}
			foreach (Stand item in list)
			{
				if (!item.IsActive || !item.CanAccess(user))
				{
					continue;
				}
				for (int i = 0; i < item.LocationCount; i++)
				{
					if (item.IsLocationRelevant(i) && !visitedStands.Contains(new Vector2Int(item.ID.x, item.ID.y)))
					{
						int key = ((item.FreePlacesCount > 0) ? (-1) : item.QueueSize);
						if (dictionary.TryGetValue(key, out var value3))
						{
							value3.Add(item);
							continue;
						}
						dictionary.Add(key, new List<Stand> { item });
					}
				}
			}
			if (dictionary.Count > 0)
			{
				for (int j = -1; j < 5; j++)
				{
					if (dictionary.TryGetValue(j, out var value4))
					{
						nextStand = value4.GetRandom();
						return true;
					}
				}
			}
			nextStand = null;
			return false;
		}

		public bool TryGetAnyClientStand(out Stand stand)
		{
			List<Stand> list = new List<Stand>();
			if (m_standsByType.TryGetValue(EStandType.SHELF, out var value))
			{
				list.AddRange(value);
			}
			if (m_standsByType.TryGetValue(EStandType.STALL, out var value2))
			{
				list.AddRange(value2);
			}
			list = list.Where((Stand s) => s.IsActive).ToList();
			if (list.IsValid())
			{
				stand = list.GetRandom();
				return stand != null;
			}
			stand = null;
			return false;
		}

		public int GetValidClientStandCount()
		{
			int num = 0;
			foreach (Stand allClientStand in GetAllClientStands())
			{
				if (allClientStand.HasRelevantLocation())
				{
					num++;
				}
			}
			return num;
		}

		public Stand GetCheckoutStand()
		{
			if (m_standsByType.TryGetValue(EStandType.CHECKOUT, out var value) && value.IsValid())
			{
				return value[0];
			}
			return null;
		}

		protected virtual void OnShopExtension(int level)
		{
			MaxClientsInside = ShopSettings.MaxClientsInside + level * ShopSettings.ClientBonusByExtension;
		}
	}
}
