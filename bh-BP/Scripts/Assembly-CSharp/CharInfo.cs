using System;
using System.Collections.Generic;
using FMODUnity;
using I2.Loc;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "CharInfo", menuName = "Bouncer/CharInfo")]
public class CharInfo : SerializedScriptableObject
{
	public CharType Type;

	public bool IsInGame;

	public int MinVersion;

	public Sprite Icon;

	public Sprite[] MatchmadeIcons;

	public Sprite IconSmall;

	[NamedArray(typeof(PrincipleDir))]
	public CharBaseAnimSet[] BaseAnimsPrinciple;

	public List<CharProp> Props;

	public PlayerCharController PrefabChar;

	public PlayerCharController PrefabCharSecond;

	public string Name;

	[TextArea]
	public string FlavorDesc;

	[TextArea]
	public string GameplayDesc;

	[HideInInspector]
	public string Slug;

	public UpgradeInfo StarterUpgrade;

	public EventReference SFXOnShoot;

	[Header("UI")]
	public Vector2 WidgetOffset;

	public Vector2 WidgetOverlaySize;

	public Vector2 WidgetOverlayPos;

	public Vector2 WidgetXPSize;

	public Vector2 WidgetXPPos;

	public Sprite SprWidgetOverlay;

	[Header("Stats")]
	[NamedArray(typeof(StatType))]
	public int[] Stats;

	[NamedArray(typeof(StatType))]
	[HideInInspector]
	public float[] BattleStatWeights;

	public float BattleStatTotalWeight;

	public void GenerateSlug()
	{
	}

	public string GetNameSlug()
	{
		return null;
	}

	public string GetFlavorDescSlug()
	{
		return null;
	}

	public string GetGameplayDescSlug()
	{
		return null;
	}

	public void ExportLoc(LanguageSourceAsset loc)
	{
	}

	public AimMode GetAimMode()
	{
		return default(AimMode);
	}

	public MoveMode GetMoveMode()
	{
		return default(MoveMode);
	}

	public CharMetaInst GetInst()
	{
		return null;
	}

	public StatType PickLvlUpStat(System.Random rnd)
	{
		return default(StatType);
	}

	public Sprite GetIconSprite()
	{
		return null;
	}

	public bool HasStat(StatType st)
	{
		return false;
	}

	public bool HasProp(StatPropType pt)
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

	public bool HasProp(CharProp prop)
	{
		return false;
	}

	public Sprite GetIcon()
	{
		return null;
	}

	private bool CanCombinePropInternal(CharProp p1, CharProp p2)
	{
		return false;
	}

	private bool CanCombineProp(CharProp p1, CharProp p2)
	{
		return false;
	}

	private bool CanCombineCharsInternal(CharType c1, CharType c2)
	{
		return false;
	}

	private bool CanCombineChars(CharType c1, CharType c2)
	{
		return false;
	}

	public bool CanCombine(CharInfo inf)
	{
		return false;
	}

	public Sprite GetComboIcon(int idx)
	{
		return null;
	}

	public bool IncludeInGame()
	{
		return false;
	}
}
