using UnityEngine;

public class BasePotionActivationState : SuperAbilityActivationState
{
	public class PotionState : State
	{
		public static readonly State BottleRising = new State("BottleRising");

		public static readonly State BottleMorphing = new State("BottleRising");
	}

	public static readonly string EMPTY_BOTTLE = " Cannot activate empty bottle. ";

	public AsciiAnimation bottleMorphAnm;

	public bool dimBottleColorMorph = true;

	private AsciiSprite potionIcon;

	private float offsetY;

	public override bool CanActivate()
	{
		if (Potion.GetItem().type == Potion.Type.Empty)
		{
			base.errorMessage = Te.xt(EMPTY_BOTTLE);
			return false;
		}
		return true;
	}

	public override void Activate()
	{
		base.Activate();
		Potion item = Potion.GetItem();
		potionIcon = IconLoader.Singleton.GetSharedIcon(item.iconPath);
		AchievementController.singleton.ReportPotionUsed(item);
		item.type = Potion.Type.Empty;
		offsetY = 0f;
		SetState(PotionState.BottleRising);
	}

	protected override void SetState(State newState)
	{
		if (newState != PotionState.BottleRising && newState == PotionState.BottleMorphing && bottleMorphAnm != null)
		{
			bottleMorphAnm.Sprite.Load();
			bottleMorphAnm.Play();
		}
		base.SetState(newState);
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.currentState == PotionState.BottleRising && stateElapsedTics == 10)
		{
			SetState(PotionState.BottleMorphing);
		}
		else if (base.currentState == PotionState.BottleMorphing && stateElapsedTics == 450)
		{
			SetState(State.Done);
		}
	}

	public override void Draw(AsciiRenderProcedural r)
	{
		base.Draw(r);
		Hero hero = GameStates.Singleton.hero;
		int lastDrawX = hero.lastDrawX;
		int lastDrawY = hero.lastDrawY;
		if (base.currentState == PotionState.BottleRising)
		{
			potionIcon.Draw(r, lastDrawX + 1, lastDrawY - 3 - Mathf.RoundToInt(offsetY));
		}
		else if (base.currentState == PotionState.BottleMorphing && bottleMorphAnm != null)
		{
			if (dimBottleColorMorph)
			{
				float t = (float)(stateElapsedTics - 6) / 7f;
				Color overrideForeground = Color.Lerp(ColorConstants.white, ColorConstants.grey, t);
				bottleMorphAnm.Sprite.Draw(r, lastDrawX, lastDrawY, overrideForeground);
			}
			else
			{
				bottleMorphAnm.Sprite.Draw(r, lastDrawX, lastDrawY);
			}
		}
	}

	protected virtual void Update()
	{
		offsetY = Mathf.Lerp(offsetY, 4f, Time.deltaTime * 10f);
	}

	protected DebuffStatMod AddBuff(DebuffStatMod buffPrefab)
	{
		DebuffStatMod debuffStatMod = Object.Instantiate(buffPrefab);
		if (debuffStatMod != null)
		{
			Hero hero = GameStates.Singleton.hero;
			debuffStatMod.sourceItem = Potion.GetItem();
			debuffStatMod.character = hero;
			debuffStatMod.statData = debuffStatMod.replacementStat;
			debuffStatMod.Init();
			hero.AddStatModifier(debuffStatMod);
		}
		else
		{
			Utils.LogError("Could not instantiate buff " + buffPrefab?.ToString() + " for super ability " + this);
		}
		return debuffStatMod;
	}
}
