using UnityEngine;

namespace Simulator.GameWorld
{
	public class DoorLockable : Door, ILockable
	{
		[field: Header("ILockable")]
		[field: SerializeField]
		[field: ReadOnly(true, false)]
		public bool IsLocked { get; set; }

		protected override bool CanOpen(bool open)
		{
			if (!base.CanOpen(open))
			{
				return false;
			}
			if (IsLocked && open)
			{
				return false;
			}
			return true;
		}

		public bool CanLock()
		{
			return true;
		}

		public bool CanUnlock()
		{
			return true;
		}

		public void OnLock()
		{
		}

		public void OnUnlock()
		{
			TrySetOpen(open: true);
		}
	}
}
