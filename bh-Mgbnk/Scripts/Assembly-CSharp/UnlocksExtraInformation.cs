using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class UnlocksExtraInformation : MonoBehaviour
{
	public TextMeshProUGUI t_title;

	public TextMeshProUGUI t_info;

	public TextMeshProUGUI t_infoNumbers;

	public LocalizedString titleStringWeapons;

	public LocalizedString titleStringCharacters;

	private PlayerInventory dummyInventory;

	public void TrySetInfo(UnlockableBase unlockable)
	{
	}

	public void SetInfoWeapon(WeaponData weaponData)
	{
	}

	public void SetCharacterInformation(CharacterData characterData)
	{
	}

	private void OnDestroy()
	{
	}
}
