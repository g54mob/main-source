using System.Collections.Generic;
using CTS.Core;
using CTS.Emotes;
using UnityEngine;

namespace CTS
{
	public class PathLockable : CTSBehaviour
	{
		[Inject(false)]
		private RoomObject _roomData;

		private EmoteBBT _errorEmote;

		private List<PathLocker> _lockers = new List<PathLocker>();

		public bool Locked { get; private set; }

		public void AddLocker(PathLocker locker)
		{
			if (!_lockers.Contains(locker))
			{
				_lockers.Add(locker);
				RecalculateLock();
			}
		}

		public void RemoveLocker(PathLocker locker)
		{
			if (_lockers.Contains(locker))
			{
				_lockers.Remove(locker);
				RecalculateLock();
			}
		}

		public void RecalculateLock()
		{
			if (_lockers.Count <= 0)
			{
				Unlock();
				return;
			}
			foreach (PathLocker locker in _lockers)
			{
				if (locker.IsPathable)
				{
					Unlock();
					return;
				}
			}
			Lock();
		}

		private void Lock()
		{
			if (Locked)
			{
				return;
			}
			Locked = true;
			if (_errorEmote == null)
			{
				_errorEmote = EmoteManager.Play<EmoteBBT>(base.transform, E_EmoteIcons.Ban).SetUseScaledTime(isScaled: false).SetStayDuration(-1f)
					.SetContentSize(20f);
				if ((bool)_roomData)
				{
					_errorEmote.SetRoomParent(_roomData);
				}
				if (TryGetComponent<Collider>(out var component))
				{
					_errorEmote.SetHeight(component, 0.5f);
				}
			}
		}

		private void Unlock()
		{
			if (Locked)
			{
				Locked = false;
				_errorEmote?.Kill();
				_errorEmote = null;
			}
		}
	}
}
