using UnityEngine;

public class VoidweaverDevourAbility : SummonDevourAbility, IAbilityActivationProvider
{
	private readonly int RANGE = 55;

	public float devourArmor { get; set; }

	public override SuperAbilityActivationState ActivateAbility()
	{
		base.ActivateAbility();
		Voidweaver component = GetComponent<Voidweaver>();
		Hero hero = GameStates.Singleton.hero;
		hero.Armor = 0f;
		GameStates singleton = GameStates.Singleton;
		for (int num = singleton.level.Enemies.Count - 1; num >= 0; num--)
		{
			Enemy enemy = singleton.level.Enemies[num];
			if (enemy.Alive && enemy.PositionX < hero.PositionX + RANGE && EvaluateInstaKill(component, enemy))
			{
				AetherTalismanGoals.singleton.ReportEnemyKilledUnstable(devourArmor);
				hero.Armor += devourArmor;
				hero.LimitArmorToCeiling();
			}
		}
		return null;
	}

	public static bool EvaluateInstaKill(Voidweaver instigator, Character target)
	{
		if (!target.tags.Contains("boss") || (EventController.singleton.IsObjectiveActive("unmake_boss") && !target.id.Contains("dysangelos")))
		{
			SfxController.singleton.Play("insta_kill");
			EmitParticlesFromSprite(instigator.gameObject.GetComponent<AsciiParticleEmitter>(), target.MySprite);
			Damage damage = new Damage();
			damage.Owner = instigator;
			damage.tags.Add("Devour");
			damage.tags.Add("activated_ability");
			target.Die(Character.DeathReason.Unmake, damage);
			target.deathDurationTics = 0;
			AchievementController.singleton.ReportInstaKilledFoe(target);
			return true;
		}
		return false;
	}

	public static void EmitParticlesFromSprite(AsciiParticleEmitter emitter, AsciiSprite sprite)
	{
		if (!(emitter != null) || !(sprite != null))
		{
			return;
		}
		bool flag = false;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 99999;
		int num6 = -99999;
		int num7 = 99999;
		int num8 = -99999;
		AsciiData.Page currentPage = sprite.GetCurrentPage();
		if (currentPage != null)
		{
			flag = true;
			num3 = sprite.lastDrawX;
			num4 = sprite.lastDrawY;
			num = currentPage.width;
			num2 = currentPage.height;
			num5 = Mathf.Min(num5, num3);
			num6 = Mathf.Max(num6, num3 + num - 1);
			num7 = Mathf.Min(num7, num4);
			num8 = Mathf.Max(num8, num4 + num2 - 1);
		}
		if (sprite is MultilayerSprite)
		{
			MultilayerSprite multilayerSprite = (MultilayerSprite)sprite;
			for (int i = 0; i < multilayerSprite.additionalLayers.Count; i++)
			{
				AsciiSprite asciiSprite = multilayerSprite.additionalLayers[i];
				currentPage = asciiSprite.GetCurrentPage();
				if (currentPage != null)
				{
					flag = true;
					num3 = asciiSprite.lastDrawX;
					num4 = asciiSprite.lastDrawY;
					num = currentPage.width;
					num2 = currentPage.height;
					num5 = Mathf.Min(num5, num3);
					num6 = Mathf.Max(num6, num3 + num - 1);
					num7 = Mathf.Min(num7, num4);
					num8 = Mathf.Max(num8, num4 + num2 - 1);
				}
			}
		}
		if (!flag)
		{
			return;
		}
		num3 = num5;
		num4 = num7;
		num = num6 - num5 + 1;
		num2 = num8 - num7 + 1;
		float num9 = (float)num3 + (float)num / 2f;
		float num10 = (float)num4 + (float)num2 / 2f - 0.3f;
		float num11 = Mathf.Max(num, num2);
		float num12 = num11 / (float)num;
		float num13 = num11 / (float)num2;
		float num14 = num11 / 2f;
		for (int j = 0; j < num; j++)
		{
			for (int k = 0; k < num2; k++)
			{
				Vector3 pos = new Vector3(j + num5, k + num7);
				float num15 = (pos.x - num9) * num12;
				float num16 = (pos.y - num10) * num13;
				float num17 = Mathf.Sqrt(num15 * num15 + num16 * num16);
				if (!(num17 < num14 - 2f) && !(num17 > num14) && !(Random.Range(0f, 1f) > 0.65f))
				{
					emitter.MoveTo(pos);
					emitter.Emit();
				}
			}
		}
	}
}
