using System;
using System.Collections.Generic;
using UnityEngine;

namespace Simulator.GameWorld
{
	public abstract class Stand : MonoBehaviour, IActivable
	{
		[Header("Furniture")]
		[SerializeField]
		protected Furniture m_furniture;

		[SerializeField]
		protected int m_furnitureIndex;

		[Header("Users")]
		[SerializeField]
		protected List<NavigationPoint> m_places;

		[SerializeField]
		protected StandQueue m_queue;

		protected HashSet<IStandUser> m_registeredUsers = new HashSet<IStandUser>();

		protected List<IStandUser> m_usersAtStand = new List<IStandUser>();

		protected Dictionary<IStandUser, int> m_occupiedPlaces = new Dictionary<IStandUser, int>();

		public Furniture Furniture => m_furniture;

		public Vector2Int ID => new Vector2Int(m_furniture.GameID, m_furnitureIndex);

		public abstract EStandType Type { get; }

		public bool IsActive { get; private set; }

		public abstract int LocationCount { get; }

		public virtual int PlacesCount => m_places.Count;

		public virtual int OccupiedPlacesCount => m_occupiedPlaces.Count;

		public int FreePlacesCount => PlacesCount - OccupiedPlacesCount;

		public virtual int QueueSize => m_queue.Size;

		public event Action<bool> Activated;

		public virtual bool HasRelevantLocation()
		{
			for (int i = 0; i < LocationCount; i++)
			{
				if (IsLocationRelevant(i))
				{
					return true;
				}
			}
			return false;
		}

		public abstract bool IsLocationRelevant(int locationIndex);

		protected virtual void OnEnable()
		{
			m_furniture.Initialized += Init;
			m_furniture.Destroyed += OnDestroyed;
			SetActive(active: true);
			m_queue.Init(this);
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void Init()
		{
			m_furniture.Initialized -= Init;
			World.Shop.RegisterStand(this);
		}

		protected virtual void OnDestroyed()
		{
			m_furniture.Destroyed -= OnDestroyed;
			World.Shop.UnregisterStand(this);
		}

		public void SetActive(bool active)
		{
			if (IsActive != active)
			{
				IsActive = active;
				if (IsActive)
				{
					OnSetActive();
				}
				else
				{
					OnSetInactive();
				}
				this.Activated?.Invoke(IsActive);
			}
		}

		protected virtual void OnSetActive()
		{
		}

		protected virtual void OnSetInactive()
		{
		}

		public virtual bool CanAccess(IStandUser user)
		{
			if (!IsActive)
			{
				return false;
			}
			if (HasAvailablePlace())
			{
				return true;
			}
			return !m_queue.IsFull();
		}

		public virtual void Access(IStandUser user)
		{
			if (HasAvailablePlace())
			{
				GiveFirstAvailablePlace(user);
			}
			else
			{
				AddToQueue(user);
			}
		}

		protected void GiveFirstAvailablePlace(IStandUser user)
		{
			int firstAvailablePlace = GetFirstAvailablePlace();
			if (firstAvailablePlace >= 0)
			{
				GivePlace(firstAvailablePlace, user);
			}
			else
			{
				Debug.LogError("Try to GiveFirstAvailablePlace when none is free.");
			}
		}

		protected void GivePlace(int placeIndex, IStandUser user)
		{
			NavigationPoint destination = m_places[placeIndex];
			m_occupiedPlaces.Add(user, placeIndex);
			OnUserGetPlace(user, placeIndex);
			user.OnAccessStand(this, destination, placeIndex);
			RegisterUser(register: true, user);
		}

		protected void QuitPlace(IStandUser user)
		{
			RegisterUser(register: false, user);
			m_usersAtStand.Remove(user);
			m_occupiedPlaces.Remove(user, out var value);
			OnUserQuitPlace(user, value);
			if (IsActive && HasAvailablePlace() && PopFirstInLine(out var user2))
			{
				GivePlace(value, user2);
			}
		}

		protected void AskToQuitStand(IStandUser user, bool completed)
		{
			user.OnAskedToQuitStand(this, completed);
		}

		protected virtual void AddToQueue(IStandUser user)
		{
			m_queue.AddToQueue(user);
		}

		protected virtual void QuitQueue(IStandUser user)
		{
			RegisterUser(register: false, user);
			m_queue.QuitQueue(user);
		}

		protected virtual bool PopFirstInLine(out IStandUser user)
		{
			return m_queue.PopFirstInLine(out user);
		}

		public virtual bool IsUsed()
		{
			return m_occupiedPlaces.IsValid();
		}

		public IEnumerable<IStandUser> GetCurrentUsers()
		{
			if (!m_occupiedPlaces.IsValid())
			{
				yield break;
			}
			foreach (KeyValuePair<IStandUser, int> item in new Dictionary<IStandUser, int>(m_occupiedPlaces))
			{
				item.Deconstruct(out var key, out var _);
				yield return key;
			}
		}

		public IEnumerable<IStandUser> GetUsersInQueue()
		{
			return m_queue.GetUsersInQueue();
		}

		public NavigationPoint GetDestination(IStandUser user)
		{
			if (m_occupiedPlaces.TryGetValue(user, out var value))
			{
				return m_places[value];
			}
			return m_queue.GetDestination(user);
		}

		protected virtual bool HasAvailablePlace()
		{
			return PlacesCount > OccupiedPlacesCount;
		}

		protected List<int> GetAvailablePlaces()
		{
			List<int> list = new List<int>();
			for (int i = 0; i < PlacesCount; i++)
			{
				if (!m_occupiedPlaces.ContainsValue(i))
				{
					list.Add(i);
				}
			}
			return list;
		}

		protected int GetFirstAvailablePlace()
		{
			for (int i = 0; i < PlacesCount; i++)
			{
				if (!m_occupiedPlaces.ContainsValue(i))
				{
					return i;
				}
			}
			return -1;
		}

		private void RegisterUser(bool register, IStandUser user)
		{
			if (register)
			{
				if (m_registeredUsers.Add(user))
				{
					user.ArrivedAtStand += OnArrivedAtStand;
					user.QuittedStand += OnCompletedStand;
				}
			}
			else if (m_registeredUsers.Remove(user))
			{
				user.ArrivedAtStand -= OnArrivedAtStand;
				user.QuittedStand -= OnCompletedStand;
			}
		}

		public virtual void AccessViaSituation(IStandUser user, AIStandSituation situation)
		{
			if (situation.standID == ID)
			{
				if (situation.hasAccess)
				{
					m_occupiedPlaces.Add(user, situation.index);
					RegisterUser(register: true, user);
				}
				else
				{
					m_queue.AccessViaSituation(user, situation);
				}
			}
		}

		protected virtual void OnArrivedAtStand(IStandUser user)
		{
			if (!m_usersAtStand.Contains(user))
			{
				m_usersAtStand.Add(user);
			}
		}

		protected virtual void OnCompletedStand(IStandUser user, bool completed)
		{
			if (m_occupiedPlaces.ContainsKey(user))
			{
				QuitPlace(user);
			}
			else
			{
				QuitQueue(user);
			}
		}

		protected virtual void OnUserGetPlace(IStandUser user, int placeIndex)
		{
		}

		protected virtual void OnUserQuitPlace(IStandUser user, int placeIndex)
		{
		}
	}
}
