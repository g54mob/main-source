using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class LockWithFurnitureShop : CTSBehaviour
	{
		[SerializeField]
		private SoftReference<ILockable> _lockable;

		private LockToggle _lock = new LockToggle();

		protected override void OnAwake()
		{
			base.OnAwake();
			_lock.Add(_lockable.Value);
			FurnitureShop.FurnitureShopStatusChanged += OnFurnitureShopOpenChanged;
			OnFurnitureShopOpenChanged(FurnitureShop.IsOpen);
		}

		private void OnDestroy()
		{
			FurnitureShop.FurnitureShopStatusChanged -= OnFurnitureShopOpenChanged;
		}

		private void OnFurnitureShopOpenChanged(bool isOpen)
		{
			_lock.SetLock(isOpen);
		}
	}
}
