using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using UnityEngine;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts
{
	public class DeleteSelectedWeapon : MonoBehaviour
	{
		public WeaponPresetList List;

		public void Start()
		{
			if (RuntimeGlobals.GameModeSettings.HasPartUnlocking)
			{
				base.gameObject.SetActive(false);
			}
		}

		public void OnClick()
		{
			if (List.SelectedItem != null)
			{
				SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.RemovePreset(List.SelectedItem);
				List.FillUp();
				List.SelectedItem = null;
			}
		}
	}
}
