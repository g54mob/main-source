using UnityEngine;

[CreateAssetMenu(menuName = "Game Settings/Setting Item/Reset", fileName = "ResetSetting")]
public class ResetSettingItem : SettingItemBase
{
	public override SettingKind Kind => SettingKind.Reset;
}
