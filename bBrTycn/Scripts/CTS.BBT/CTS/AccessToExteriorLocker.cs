using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class AccessToExteriorLocker : CTSBehaviour
	{
		[Inject(false)]
		private ILockable _selectable;

		[SerializeField]
		private bool _alsoLockWhenEmpty = true;

		private bool _accessible;

		private LockToggle _lock;

		protected override void OnAwake()
		{
			base.OnAwake();
			_lock = new LockToggle();
			_lock.Add(_selectable);
			BuildingRoomsContainerManager.OnAccessToExteriorChanged += OnAccessChanged;
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_accessible = !IsAccessValid(MonoSingleton<BuildingRoomsContainerManager>.Instance.AllRoomHaveExteriorAccess);
			OnAccessChanged(!_accessible);
		}

		private void OnDestroy()
		{
			BuildingRoomsContainerManager.OnAccessToExteriorChanged -= OnAccessChanged;
		}

		private void OnAccessChanged(EAccess accessible)
		{
			bool accessible2 = IsAccessValid(accessible);
			OnAccessChanged(accessible2);
		}

		private bool IsAccessValid(EAccess access)
		{
			if (access == EAccess.Inaccessible || access == EAccess.WrongAccess)
			{
				return false;
			}
			if (_alsoLockWhenEmpty && access == EAccess.Empty)
			{
				return false;
			}
			return true;
		}

		private void OnAccessChanged(bool accessible)
		{
			if (accessible != _accessible)
			{
				_accessible = accessible;
				_lock.SetLock(!_accessible);
			}
		}
	}
}
