using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Combat.Targets
{
	public class ExclusiveLock
	{
		private GameObject _owner;

		public bool AcquireOrMaintain(GameObject obj)
		{
			if (_owner == null)
			{
				_owner = obj;
			}
			return _owner == obj;
		}

		public bool Release(GameObject obj)
		{
			if (_owner == obj)
			{
				_owner = null;
				return true;
			}
			return false;
		}
	}
}
