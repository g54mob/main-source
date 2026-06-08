using System;
using UnityEngine;

public class OuroborosWeapon : Weapon
{
	private float healingPeriod = MathF.PI * 2f;

	private float elapsedTime;

	private int _lastLevel = -1;

	public static Data.Quest questToReplay { get; set; }

	public static bool hasBeenTapped { get; set; }

	public static bool healingBlocked { get; set; }

	public static OuroborosWeapon singleton { get; set; }

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (healingBlocked)
		{
			return;
		}
		elapsedTime += 0.03333333f;
		if (elapsedTime >= healingPeriod)
		{
			elapsedTime -= healingPeriod;
			Hero hero = GameStates.Singleton.hero;
			if (hero.Hitpoints < hero.MaxHitpoints)
			{
				Damage damage = new Damage();
				damage.type = Damage.Type.Melee;
				damage.amount = 1;
				damage.Owner = hero;
				hero.ApplyHeal(damage);
				AchievementController.singleton.ReportOuroborosHealed();
			}
		}
	}

	public static bool IsEnabled()
	{
		return Inventory.Singleton.HasItemById("ouroboros_stone");
	}

	public static string Serialize()
	{
		SlimJson.BeginSerialization();
		SlimJson.AddProperty("hasBeenTapped", hasBeenTapped);
		return SlimJson.EndSerialization();
	}

	public static void Parse(string sjson)
	{
		questToReplay = null;
		if (!Inventory.Singleton.HasItemById("ouroboros_stone"))
		{
			singleton = null;
		}
		if (sjson != null)
		{
			hasBeenTapped = SlimJson.ParseBool(sjson, "hasBeenTapped");
		}
		else
		{
			ClearProgress();
		}
	}

	public static void ClearProgress()
	{
		questToReplay = null;
		hasBeenTapped = false;
		singleton = null;
	}

	private void HandleDrawingIdle(AsciiSprite s, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		UpdateEquippedColor();
	}

	private void UpdateEquippedColor()
	{
		if (_lastLevel != level)
		{
			_lastLevel = level;
			Color colorForLevel = UpgradeRelicScreen.GetColorForLevel(level);
			idleSprite.colorOverride = colorForLevel;
			castSprite.colorOverride = colorForLevel;
			perfSprite.colorOverride = colorForLevel;
			leftHandIdleSprite.colorOverride = colorForLevel;
			leftHandCastSprite.colorOverride = colorForLevel;
			leftHandPerfSprite.colorOverride = colorForLevel;
			leftHandPickingUpSprite.colorOverride = colorForLevel;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		singleton = this;
		idleSprite.OnDraw += HandleDrawingIdle;
		leftHandIdleSprite.OnDraw += HandleDrawingIdle;
	}

	protected override void OnDestroy()
	{
		idleSprite.OnDraw -= HandleDrawingIdle;
		leftHandIdleSprite.OnDraw -= HandleDrawingIdle;
		if (singleton == this)
		{
			singleton = null;
		}
		base.OnDestroy();
	}
}
