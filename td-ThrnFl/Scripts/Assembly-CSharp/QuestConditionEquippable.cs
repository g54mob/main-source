using MPUIKIT;
using UnityEngine;
using UnityEngine.UI;

public class QuestConditionEquippable : MonoBehaviour
{
	public Color weaponBgColor;

	public Color perkBgColor;

	public Color mutatorBgColor;

	public MPImageBasic background;

	public Image icon;

	public void SetData(Equippable data)
	{
		icon.sprite = data.icon;
		if (data is EquippableWeapon)
		{
			background.color = weaponBgColor;
		}
		if (data is EquippablePerk)
		{
			background.color = perkBgColor;
		}
		if (data is EquippableMutation)
		{
			background.color = mutatorBgColor;
		}
	}
}
