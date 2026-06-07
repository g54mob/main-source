using System;
using DV.UI.Inventory;
using DV.Utils;

namespace DV.InventorySystem
{
	public class InventoryViewBase : SingletonBehaviour<InventoryViewBase>
	{
		public AInventoryUIController inventoryUI;

		protected InventorySounds inventorySounds;

		public virtual bool IsVR { get; }

		public virtual bool BigInventoryOpen { get; }

		public event Action BigInventoryOpenChanged;

		public new static string AllowAutoCreate()
		{
			return null;
		}

		protected override void Awake()
		{
			base.Awake();
			inventorySounds = SingletonBehaviour<Inventory>.Instance.GetComponent<InventorySounds>();
		}

		protected virtual void OnBigInventoryOpenChanged_Fire()
		{
			this.BigInventoryOpenChanged?.Invoke();
		}

		public void RequestAddSound()
		{
			inventorySounds.RequestAddSound();
		}
	}
}
