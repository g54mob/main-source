using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(Inventory))]
	public class ItemStoreModelChanger : AttachedBehaviour
	{
		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool IsReserved { get; set; }

		public override void Start()
		{
		}

		public override void OnDestroy()
		{
		}

		private void Inventory_ItemRemoved(object sender, GameItemEventArgs e)
		{
		}

		private void Inventory_ItemAdded(object sender, GameItemEventArgs e)
		{
		}

		private void ChangeVisualForStorage(GameItem item, bool toStore)
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}
	}
}
