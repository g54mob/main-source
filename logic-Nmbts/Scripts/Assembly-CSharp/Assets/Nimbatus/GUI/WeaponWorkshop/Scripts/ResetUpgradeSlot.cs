using UnityEngine;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts
{
	public class ResetUpgradeSlot : MonoBehaviour
	{
		private WeaponUpgradeSlot _slot;

		public void Init(WeaponUpgradeSlot slot)
		{
			_slot = slot;
		}

		public void OnClick()
		{
			_slot.SetUpgrade(null);
		}
	}
}
