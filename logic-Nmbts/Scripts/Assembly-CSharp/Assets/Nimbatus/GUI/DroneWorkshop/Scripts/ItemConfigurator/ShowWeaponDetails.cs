using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Selection;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator
{
	public class ShowWeaponDetails : MonoBehaviour
	{
		public TweenPosition WeaponDetailsTween;

		public EnumChooser RotationTypeChooser;

		public WeaponDetails WeaponDetails;

		private Weapon _selectedItem;

		public void Update()
		{
			DronePart onlySelection = ItemSelector.GetOnlySelection();
			if (!(onlySelection is Weapon))
			{
				WeaponDetailsTween.Play(false);
				{
					foreach (Transform item in base.transform)
					{
						item.gameObject.SetActive(false);
					}
					return;
				}
			}
			WeaponDetailsTween.Play(true);
			foreach (Transform item2 in base.transform)
			{
				item2.gameObject.SetActive(true);
			}
			if (_selectedItem == onlySelection && _selectedItem != null)
			{
				EWeaponRotation eWeaponRotation = (EWeaponRotation)(object)RotationTypeChooser.SelectedOption;
				if (_selectedItem.Emitter.RotationMode != eWeaponRotation)
				{
					_selectedItem.Rotation = eWeaponRotation;
					BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.WeaponRotation);
				}
			}
			if (!(onlySelection == _selectedItem))
			{
				_selectedItem = (Weapon)onlySelection;
				WeaponDetails.ShowWeapon(_selectedItem);
				RotationTypeChooser.Init<EWeaponRotation>(_selectedItem.Rotation);
			}
		}
	}
}
