using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Selection;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator
{
	public class FlipSkinX : MonoBehaviour
	{
		public void OnClick()
		{
			if (!ItemSelector.HasSelectedItems())
			{
				return;
			}
			foreach (DronePart selectedItem in ItemSelector.SelectedItems)
			{
				selectedItem.FlipSkinX();
			}
			BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.FlipSkinX);
		}
	}
}
