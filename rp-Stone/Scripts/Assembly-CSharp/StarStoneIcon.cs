using UnityEngine;

[RequireComponent(typeof(AsciiSprite))]
public class StarStoneIcon : LevelColoredSoulStoneIcon
{
	protected override int GetItemLevel()
	{
		return StarStoneWeapon.singleton.level;
	}
}
