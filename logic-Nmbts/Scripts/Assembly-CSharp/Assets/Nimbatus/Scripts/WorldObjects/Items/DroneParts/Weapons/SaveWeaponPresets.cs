using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons
{
	public class SaveWeaponPresets : MonoBehaviour
	{
		public void OnClick()
		{
			SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.UpdateWeaponPresets();
		}
	}
}
