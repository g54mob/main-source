using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class CharBattleInst
{
	public static CharBattleInst I;

	public CharType Type;

	public List<CharType> CombinedTypes;

	public List<CharProp> Props;

	public bool[] _hasProp;

	public int[] LastSeenStats;

	public int[] Stats;

	public Sprite _comboIcon;

	private float _lastShootSFXTime;

	public CharBattleInst(CharType t)
	{
	}

	private void InitInternal(CharType t)
	{
	}

	public void AddCombo(CharType ct)
	{
	}

	public void SetCombo(CharType c1, CharType c2)
	{
	}

	private SpriteAnimClip CombineAnim(SpriteAnimClip c1, SpriteAnimClip c2, bool flipX = false)
	{
		return null;
	}

	public void AddStat(StatType st, int amt)
	{
	}

	public int GetNumRelatedProps(StatType t)
	{
		return 0;
	}

	public bool HasType(CharType t)
	{
		return false;
	}

	public bool HasProp(StatPropType prop)
	{
		return false;
	}

	public bool HasProp(CharProp prop)
	{
		return false;
	}

	public bool[] GetPropArray()
	{
		return null;
	}

	public AimMode GetAimMode()
	{
		return default(AimMode);
	}

	public MoveMode GetMoveMode()
	{
		return default(MoveMode);
	}

	public TimeMode GetTimeMode()
	{
		return default(TimeMode);
	}

	public bool RequiresReload()
	{
		return false;
	}

	public float GetGravityFactor()
	{
		return 0f;
	}

	public bool DoesBounceAddBonusDamage()
	{
		return false;
	}

	public bool DoesWallBounceAddBonusDamage()
	{
		return false;
	}

	public float GetBallDamageMult()
	{
		return 0f;
	}

	public float GetLaunchSpeedMult()
	{
		return 0f;
	}

	public float GetFireRateMult()
	{
		return 0f;
	}

	public float GetReloadTimeMult()
	{
		return 0f;
	}

	public float GetMoveSpeedMult()
	{
		return 0f;
	}

	public float GetAimScatter()
	{
		return 0f;
	}

	public float GetBounceScatter()
	{
		return 0f;
	}

	public CharInfo GetInfo()
	{
		return null;
	}

	public CharMetaInst GetMeta()
	{
		return null;
	}

	public CharInfo GetComboInfo(int idx)
	{
		return null;
	}

	public CharMetaInst GetComboMeta(int idx)
	{
		return null;
	}

	public void ApplyIcon(Image img)
	{
	}

	public PlayerCharController CreateCharController(Player p, int idx)
	{
		return null;
	}

	private void CheckCompletionAchInternal(CharType t)
	{
	}

	public void CheckCompletionAch()
	{
	}

	public void PlayShootSFX()
	{
	}

	public void PlayShootSFX(Vector2 aimDir)
	{
	}

	public bool AreStatsCheated()
	{
		return false;
	}

	public bool HasStat(StatType st)
	{
		return false;
	}

	public bool HasCustomAimCursor()
	{
		return false;
	}
}
