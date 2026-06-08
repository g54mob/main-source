using UnityEngine;

public class SummonDevourAbility : MonoBehaviour
{
	public string abilityId;

	public AsciiSprite abilityIcon;

	public ItemData.Element runeConsumed;

	public int cooldown = 60;

	private AbilityClock clock;

	public int runeCostX;

	public int runeCostY;

	public string GetId()
	{
		return abilityId;
	}

	public bool IsAvailable()
	{
		return true;
	}

	public AsciiSprite GetIcon()
	{
		return abilityIcon;
	}

	public bool IsEnabled()
	{
		return Inventory.Singleton.HasRunestoneMaterial(runeConsumed);
	}

	public bool IsWaiting()
	{
		return clock.GetPercent() >= 1f;
	}

	public float GetCooldownRemaining()
	{
		return 1f - clock.GetPercent();
	}

	public virtual SuperAbilityActivationState ActivateAbility()
	{
		clock.duration = ComputeCooldown();
		clock.Play();
		Inventory.Singleton.RemoveRunestoneMaterial(runeConsumed);
		Summon component = GetComponent<Summon>();
		if (component != null && component.owner != null)
		{
			FloatingText floatingText = component.owner.ShowFloatingText("-" + ItemData.CharForElement(runeConsumed));
			if (floatingText != null)
			{
				floatingText.velocity *= 0.7f;
				floatingText.targetDistance += 1f;
				floatingText.maxTravelTime += 2.5f;
				floatingText.fadeOutDuration += 1f;
			}
		}
		OfflineFarmController.singleton.ReportRuneDevoured(runeConsumed, 1);
		return null;
	}

	protected virtual int ComputeCooldown()
	{
		return cooldown;
	}

	private void PostIconDraw(AsciiSprite iconSprite, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetX += (iconSprite.flipX ? (-iconSprite.pivotX) : iconSprite.pivotX);
		offsetY += (iconSprite.flipY ? (-iconSprite.pivotY) : iconSprite.pivotY);
		offsetX += runeCostX;
		offsetY += runeCostY;
		if (IsEnabled())
		{
			r.SetCell(offsetX, offsetY, SpecialSymbols.Map('-'), ColorConstants.grey);
			r.SetCell(offsetX + 1, offsetY, SpecialSymbols.Map('1'), ColorConstants.grey);
			r.SetCell(offsetX + 2, offsetY, SpecialSymbols.Map(ItemData.CharForElement(runeConsumed)), ColorConstants.grey);
		}
		else if (Mathf.Repeat(Time.realtimeSinceStartup, 2f) < 1f)
		{
			r.SetCell(offsetX + 1, offsetY, SpecialSymbols.Map('↓'), ColorConstants.grey);
			r.SetCell(offsetX + 2, offsetY, SpecialSymbols.Map(ItemData.CharForElement(runeConsumed)), ColorConstants.grey);
		}
		else
		{
			r.SetCell(offsetX + 2, offsetY, SpecialSymbols.Map('x'), ColorConstants.grey);
		}
	}

	protected virtual void Awake()
	{
		clock = AbilityClock.GetClockForAbility(abilityId);
		abilityIcon.OnDraw += PostIconDraw;
	}
}
