using UnityEngine;

public static class SpriteTempEffectID
{
	public enum ID
	{
		ExploDiscID = 0,
		Splash = 1,
		Flash = 2,
		Footstep = 3,
		FootstepSlime = 4,
		FootstepAcid = 5,
		FootstepPoison = 6,
		FootstepIce = 7,
		WaterSplash = 8,
		WaterSplashYellow = 9,
		WaterSplashMold = 10,
		WaterSplashLava = 11,
		WaterRipple = 12,
		AcidImpact = 13,
		AcidSplat = 14,
		AcidSplat2 = 15,
		BloodImpact = 16,
		BloodSplat = 17,
		SmallBloodSplat = 18,
		SmallSlimeSplat = 19,
		SmallLarvaSplat = 20,
		BlueSplat = 21,
		BlueSplat2 = 22,
		BlueImpact = 23,
		MoldSplat2 = 24,
		HitEffect = 25,
		PoisonSplat = 26,
		SnowSplat = 27,
		FootstepBlueSplat = 28,
		WaterRippleLava = 29,
		WaterRippleWhite = 30,
		WaterRippleYellow = 31
	}

	public static readonly int ExploDisc = Animator.StringToHash("ExploDisc");

	public static readonly int Splash = Animator.StringToHash("Splash");

	public static readonly int Flash = Animator.StringToHash("Flash");

	public static readonly int Footstep = Animator.StringToHash("Footstep");

	public static readonly int FootstepSlime = Animator.StringToHash("FootstepSlime");

	public static readonly int FootstepAcid = Animator.StringToHash("FootstepAcid");

	public static readonly int FootstepPoison = Animator.StringToHash("FootstepPoison");

	public static readonly int BigSplash = Animator.StringToHash("BigSplash");

	public static readonly int WaterSplash = Animator.StringToHash("WaterSplash");

	public static readonly int WaterSplashYellow = Animator.StringToHash("WaterSplashYellow");

	public static readonly int WaterSplashMold = Animator.StringToHash("WaterSplashMold");

	public static readonly int WaterSplashLava = Animator.StringToHash("WaterSplashLava");

	public static readonly int WaterRipple = Animator.StringToHash("WaterRipple");

	public static readonly int AcidImpact = Animator.StringToHash("AcidImpact");

	public static readonly int AcidSplat = Animator.StringToHash("AcidSplat");

	public static readonly int AcidSplat2 = Animator.StringToHash("AcidSplat2");

	public static readonly int BloodImpact = Animator.StringToHash("BloodImpact");

	public static readonly int BloodSplat = Animator.StringToHash("BloodSplat");

	public static readonly int SmallBloodSplat = Animator.StringToHash("SmallBloodSplat");

	public static readonly int SmallSlimeSplat = Animator.StringToHash("SmallSlimeSplat");

	public static readonly int SmallLarvaSplat = Animator.StringToHash("SmallLarvaSplat");

	public static readonly int BlueSplat = Animator.StringToHash("BlueSplat");

	public static readonly int BlueSplat2 = Animator.StringToHash("BlueSplat2");

	public static readonly int BlueImpact = Animator.StringToHash("BlueImpact");

	public static readonly int MoldSplat2 = Animator.StringToHash("MoldSplat2");

	public static readonly int HitEffect = Animator.StringToHash("HitEffect");

	public static readonly int PoisonSplat = Animator.StringToHash("PoisonSplat");

	public static readonly int SnowSplat = Animator.StringToHash("SnowSplat");

	public static readonly int FootstepBlueSplat = Animator.StringToHash("FootstepBlueSplat");

	public static readonly int WaterRippleLava = Animator.StringToHash("WaterRippleLava");

	public static readonly int WaterRippleWhite = Animator.StringToHash("WaterRippleWhite");

	public static readonly int WaterRippleYellow = Animator.StringToHash("WaterRippleYellow");

	public static readonly int FootstepOilSplat = Animator.StringToHash("FootstepOil");

	public static int GetHash(ID id)
	{
		return id switch
		{
			ID.ExploDiscID => ExploDisc, 
			ID.Splash => Splash, 
			ID.Flash => Flash, 
			ID.Footstep => Footstep, 
			ID.FootstepSlime => FootstepSlime, 
			ID.FootstepAcid => FootstepAcid, 
			ID.FootstepPoison => FootstepPoison, 
			ID.WaterSplash => WaterSplash, 
			ID.WaterSplashYellow => WaterSplashYellow, 
			ID.WaterSplashMold => WaterSplashMold, 
			ID.WaterSplashLava => WaterSplashLava, 
			ID.WaterRipple => WaterRipple, 
			ID.AcidImpact => AcidImpact, 
			ID.AcidSplat => AcidSplat, 
			ID.AcidSplat2 => AcidSplat2, 
			ID.BloodImpact => BloodImpact, 
			ID.BloodSplat => BloodSplat, 
			ID.SmallBloodSplat => SmallBloodSplat, 
			ID.SmallSlimeSplat => SmallSlimeSplat, 
			ID.SmallLarvaSplat => SmallLarvaSplat, 
			ID.BlueSplat => BlueSplat, 
			ID.BlueSplat2 => BlueSplat2, 
			ID.BlueImpact => BlueImpact, 
			ID.MoldSplat2 => MoldSplat2, 
			ID.HitEffect => HitEffect, 
			ID.PoisonSplat => PoisonSplat, 
			ID.SnowSplat => SnowSplat, 
			ID.FootstepBlueSplat => FootstepBlueSplat, 
			ID.WaterRippleLava => WaterRippleLava, 
			ID.WaterRippleWhite => WaterRippleWhite, 
			ID.WaterRippleYellow => WaterRippleYellow, 
			_ => -1, 
		};
	}

	public static void Init()
	{
	}
}
