using Pug.Sprite;

public class SeasonalMerchant : CraftingBuilding
{
	private readonly int m_EmoteSoundEvent = SpriteAsset.StringToHash("emoteSound");

	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimMovementSpeed => true;

	protected override void Awake()
	{
		base.Awake();
		spriteObjects[0].onAnimationEvent += HandleAnimationEvent;
	}

	protected override float GetAnimSpeed()
	{
		return 0.8f;
	}

	public override void Use()
	{
		PlayerController player = Manager.main.player;
		if (player != null && EntityUtility.GetComponentData<MerchantCD>(base.entity, base.world).hasNewItems)
		{
			player.playerCommandSystem.ResetMerchantHasNewItems(base.entity);
		}
		base.Use();
		interactSFX();
	}

	private void interactSFX()
	{
		switch (Manager.prefs.season)
		{
		case Season.Christmas:
			AudioManager.Sfx(SfxTableID.santaHohoho, base.transform.position);
			break;
		case Season.Valentine:
			AudioManager.Sfx(SfxTableID.valentineMerchant, base.transform.position);
			break;
		case Season.Anniversary:
			AudioManager.Sfx(SfxTableID.anniversaryMerchant, base.transform.position);
			Manager.effects.PlayPuff(PuffID.Confetti, base.transform.position, 5);
			Manager.effects.PlayPuff(PuffID.Confetti2, base.transform.position, 5);
			break;
		case Season.Halloween:
			AudioManager.Sfx(SfxTableID.halloweenMerchant, base.transform.position);
			break;
		case Season.LunarNewYear:
			AudioManager.Sfx(SfxTableID.lunarMerchant, base.transform.position);
			break;
		default:
			AudioManager.Sfx(SfxTableID.seasonalMerchantLaugh, base.transform.position);
			break;
		}
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -689712656)
		{
			Season season = Manager.prefs.season;
			if ((uint)(season - 2) <= 3u || season != Season.LunarNewYear)
			{
				spriteObjects[0].PlayAnimation(-689712656, m_spriteObjectOrientationHash);
			}
			else
			{
				spriteObjects[0].PlayAnimation(1340768330, m_spriteObjectOrientationHash);
			}
		}
	}

	private void HandleAnimationEvent(int hash)
	{
		if (hash == m_EmoteSoundEvent)
		{
			interactSFX();
		}
	}
}
