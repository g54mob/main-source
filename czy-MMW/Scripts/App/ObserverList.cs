using System.Collections.Generic;

public class ObserverList<T>
{
	public struct Enumerator
	{
		private readonly ObserverList<T> _list;

		private int _index;

		private bool _hasLock;

		public T Current => _list._observers[_index];

		public Enumerator(ObserverList<T> list)
		{
			_list = list;
			_index = -1;
			list.Lock();
			_hasLock = true;
		}

		public bool MoveNext()
		{
			if (_index + 1 < _list._observers.Count)
			{
				_index++;
				return true;
			}
			if (_hasLock)
			{
				_list.Unlock();
				_hasLock = false;
			}
			return false;
		}
	}

	private readonly List<T> _observers;

	private List<T> _lockedSubscriptions;

	private List<T> _lockedUnsubscriptions;

	private int _lockCount;

	public ObserverList(int capacity = 1)
	{
		_observers = new List<T>(capacity);
	}

	public void Subscribe(T observer)
	{
		if (_lockCount == 0)
		{
			if (!_observers.Contains(observer))
			{
				_observers.Add(observer);
			}
		}
		else if ((_lockedSubscriptions == null || !_lockedSubscriptions.Contains(observer)) && (_lockedUnsubscriptions == null || !_lockedUnsubscriptions.Remove(observer)))
		{
			if (_lockedSubscriptions == null)
			{
				_lockedSubscriptions = new List<T>();
			}
			_lockedSubscriptions.Add(observer);
		}
	}

	public bool Unsubscribe(T observer)
	{
		if (_lockCount == 0)
		{
			return _observers.Remove(observer);
		}
		if (_lockedUnsubscriptions != null && _lockedUnsubscriptions.Contains(observer))
		{
			return false;
		}
		if (_lockedSubscriptions != null && _lockedSubscriptions.Remove(observer))
		{
			return true;
		}
		if (_lockedUnsubscriptions == null)
		{
			_lockedUnsubscriptions = new List<T>();
		}
		_lockedUnsubscriptions.Add(observer);
		return true;
	}

	public void UnsubscribeAll()
	{
		if (_lockCount == 0)
		{
			_observers.Clear();
			return;
		}
		if (_lockedUnsubscriptions == null)
		{
			_lockedUnsubscriptions = new List<T>();
		}
		_lockedUnsubscriptions.AddRange(_observers);
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(this);
	}

	private void Lock()
	{
		_lockCount++;
	}

	private void Unlock()
	{
		_lockCount--;
		if (_lockCount > 0)
		{
			return;
		}
		if (_lockedUnsubscriptions != null)
		{
			foreach (T lockedUnsubscription in _lockedUnsubscriptions)
			{
				Unsubscribe(lockedUnsubscription);
			}
			_lockedUnsubscriptions.Clear();
		}
		if (_lockedSubscriptions == null)
		{
			return;
		}
		foreach (T lockedSubscription in _lockedSubscriptions)
		{
			Subscribe(lockedSubscription);
		}
		_lockedSubscriptions.Clear();
	}
}
