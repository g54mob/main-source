using System.Collections.Generic;
using FMODUnity;
using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "HeroInfo", menuName = "Bouncer/HeroInfo")]
public class HeroInfo : UpgradeInfo
{
	public HeroType Type;

	public List<StatusEffectType> HitEffects;

	public List<BallAOEType> AOETypes;

	public List<BallSpecialType> Specials;

	public DamageType DmgType;

	[Header("Appearance")]
	public Color BallColor;

	public BallRotationType RotType;

	public float RotSpeed;

	public int IconPriority;

	[Header("VFX")]
	public BallVFXController VFX;

	public bool IsVFXBorrowed;

	public List<Color> VFXColorList;

	public ParticleSystem.MinMaxGradient[] DefaultParticleColor;

	public HDRColor[] DefaultTrailColor;

	public Dictionary<string, HDRColor>[] DefaultMatColors;

	public Dictionary<string, Texture2D>[] DefaultMatTextures;

	public Dictionary<string, Texture2D>[] DefaultTrailTextures;

	public Sprite[] MatTextureSprites;

	public List<Color> MatTextureColorList;

	[Header("SFX")]
	public EventReference[] SFXOnHit;

	public override void GenerateSlug()
	{
	}

	public override int GetIdx()
	{
		return 0;
	}

	public override HeroInfo ToHero()
	{
		return null;
	}

	public override void ApplyIcon(Image img)
	{
	}

	public Sprite GetIcon()
	{
		return null;
	}

	public Color GetIconColor()
	{
		return default(Color);
	}

	public Sprite GetComboIcon(HeroType comboType)
	{
		return null;
	}

	public Sprite GetComboIcon(HeroInfo comboInf)
	{
		return null;
	}

	public bool HasSynergy(HeroInfo other)
	{
		return false;
	}

	public override LevelType GetRequiredLevel()
	{
		return default(LevelType);
	}

	public override bool IncludeInGame()
	{
		return false;
	}

	public bool IsUnlocked()
	{
		return false;
	}

	public bool CanBeUsed()
	{
		return false;
	}

	public bool DoesSpawnBalls()
	{
		return false;
	}

	public bool DoesSpawnMosquitoes()
	{
		return false;
	}

	public bool ApplyComboDetails(HeroInfo comboInf, Localize loc, LocalizationParamsManager prams)
	{
		return false;
	}

	public bool HasAOE()
	{
		return false;
	}

	public Color GetVFXColorMapping(List<Color> vfxColorList, Color inColor)
	{
		return default(Color);
	}

	public Color GetVFXColorMapping(List<Color> vfxColorList, HDRColor inColor)
	{
		return default(Color);
	}

	public Color GetVFXColorMapping(HeroInfo inInf, Color inColor)
	{
		return default(Color);
	}

	public Color GetVFXColorMapping(HeroInfo inInf, HDRColor inColor)
	{
		return default(Color);
	}
}
