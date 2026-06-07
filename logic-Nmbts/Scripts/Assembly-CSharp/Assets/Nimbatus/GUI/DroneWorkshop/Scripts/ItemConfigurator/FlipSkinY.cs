using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Selection;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator
{
	public class FlipSkinY : MonoBehaviour
	{
		public void OnClick()
		{
			if (!ItemSelector.HasSelectedItems())
			{
				return;
			}
			foreach (DronePart selectedItem in ItemSelector.SelectedItems)
			{
				selectedItem.FlipSkinY();
			}
			BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.FlipSkinY);
		}
	}
}
