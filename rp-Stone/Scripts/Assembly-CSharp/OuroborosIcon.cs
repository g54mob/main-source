using UnityEngine;

[RequireComponent(typeof(AsciiSprite))]
public class OuroborosIcon : LevelColoredSoulStoneIcon
{
	protected override int GetItemLevel()
	{
		return OuroborosWeapon.singleton.level;
	}
}
