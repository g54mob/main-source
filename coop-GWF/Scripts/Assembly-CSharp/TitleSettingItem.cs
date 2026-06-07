using UnityEngine;

[CreateAssetMenu(menuName = "Game Settings/Setting Item/Title", fileName = "TitleSetting")]
public class TitleSettingItem : SettingItemBase
{
	public override SettingKind Kind => SettingKind.Title;
}
