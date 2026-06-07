using Sirenix.OdinInspector;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts
{
	public class DeselectUpgradeSlot : SerializedMonoBehaviour
	{
		public void OnClick()
		{
			WeaponUpgradeSlot.SelectedSlot = null;
		}
	}
}
