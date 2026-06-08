using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
	public class Flag
	{
		public static readonly uint PAUSE = 1u;

		public static readonly uint PLAYER = 2u;

		public static readonly uint FOE = 4u;

		public static readonly uint ABILITIES = 8u;

		public static readonly uint RESOURCES = 16u;

		public static readonly uint BANNER = 32u;

		public static readonly uint UTIL_BELT = 64u;
	}

	private readonly bool ABBREVIATE_DEBUFFS = true;

	public static uint enabledFlags = 65535u;

	private float showEnemyNameDuration = 1.5f;

	private float enemyShownElapsedTime;

	private AsciiString heroHitpoints = new AsciiString();

	private AsciiString enemyHitpoints = new AsciiString();

	private AsciiString heroArmor = new AsciiString();

	private AsciiString enemyArmor = new AsciiString();

	private List<List<StatModifier>> heroDebuffs;

	private string currentEnemyName;

	private int hitPointsBlinking;

	private int armorBlinking;

	private AsciiString workString = new AsciiString();

	private int lastHeroHitpoints;

	private int lastHeroMaxHitpoints;

	private float lastHeroArmor;

	private float lastEnemyArmor;

	public Enemy currentEnemy { get; set; }

	public static void EnableAll()
	{
		enabledFlags = 65535u;
	}

	public static void DisableAll()
	{
		enabledFlags = 0u;
	}

	public static bool IsEnabled(uint flag)
	{
		return (enabledFlags & flag) != 0;
	}

	public static void Enable(uint flag)
	{
		enabledFlags |= flag;
	}

	public static void Disable(uint flag)
	{
		enabledFlags &= ~flag;
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (!IsEnabled(Flag.PLAYER + Flag.FOE))
		{
			return;
		}
		GameStates singleton = GameStates.Singleton;
		Data.Quest questData = singleton.level.QuestData;
		if ((questData.safe && currentEnemy == null) || questData.hideHUD || singleton.CurrentState == GameStates.State.PlayChoiceDialog)
		{
			return;
		}
		for (int i = 0; i < r.width; i++)
		{
			r.SetCell(i, r.height - 1, 32);
		}
		offsetY += r.height - 1;
		int num = 0;
		if (IsEnabled(Flag.PLAYER))
		{
			heroHitpoints.Draw(r, num, offsetY);
			num += heroHitpoints.Length;
			if (heroArmor.Length > 0)
			{
				if (armorBlinking <= 0 || armorBlinking-- % 6 < 3)
				{
					heroArmor.Draw(r, num, offsetY);
				}
				num += heroArmor.Length;
			}
			else
			{
				armorBlinking = 0;
			}
			num++;
			if (heroDebuffs != null)
			{
				DrawDebuffs(r, num, offsetY, drawDirection: true, heroDebuffs);
			}
		}
		if (IsEnabled(Flag.FOE))
		{
			num = r.width - 1;
			enemyHitpoints.Draw(r, num, offsetY);
			num -= enemyHitpoints.Length;
			if (enemyArmor.Length > 0)
			{
				enemyArmor.Draw(r, num, offsetY);
				num -= enemyArmor.Length;
			}
			num--;
			if (currentEnemy != null && currentEnemy.statModController != null && currentEnemy.statModController.debuffs.Count > 0)
			{
				List<List<StatModifier>> debuffs = currentEnemy.statModController.debuffs;
				DrawDebuffs(r, num, offsetY, drawDirection: false, debuffs);
			}
		}
	}

	private void DrawDebuffs(AsciiRenderProcedural r, int x, int y, bool drawDirection, List<List<StatModifier>> debuffs)
	{
		for (int i = 0; i < debuffs.Count; i++)
		{
			List<StatModifier> list = debuffs[i];
			if (ABBREVIATE_DEBUFFS && list.Count > 2)
			{
				StatModifier statModifier = list[0];
				string text = list.Count.ToString();
				Color color = ColorConstants.red;
				if (statModifier.customSymbolColor != Color.clear)
				{
					color = statModifier.customSymbolColor;
				}
				else if (statModifier.isPositiveBuff)
				{
					color = ColorConstants.blue;
				}
				float num = statModifier.GetPercentComplete();
				for (int num2 = list.Count - 1; num2 >= 0; num2--)
				{
					StatModifier statModifier2 = list[num2];
					float percentComplete = statModifier2.GetPercentComplete();
					if (percentComplete > num)
					{
						num = percentComplete;
						statModifier = statModifier2;
					}
				}
				num = Mathf.Lerp(0f, 0.88f, num);
				Color foreground = Color.Lerp(color, ColorConstants.black, num);
				workString.color = color;
				workString.SetValue(text);
				char c = ((statModifier.customHudSymbol.Length <= 0) ? ItemData.CharForElement(statModifier.element) : statModifier.customHudSymbol[0]);
				if (drawDirection)
				{
					workString.Draw(r, x, y);
					x += text.Length;
					r.SetCell(x, y, SpecialSymbols.Map(c), foreground);
					x++;
				}
				else
				{
					r.SetCell(x, y, SpecialSymbols.Map(c), foreground);
					x -= text.Length;
					workString.Draw(r, x, y);
					x--;
				}
				continue;
			}
			for (int num3 = list.Count - 1; num3 >= 0; num3--)
			{
				StatModifier statModifier3 = list[num3];
				char c2 = ((statModifier3.customHudSymbol.Length <= 0) ? ItemData.CharForElement(statModifier3.element) : statModifier3.customHudSymbol[0]);
				Color a = ColorConstants.red;
				if (statModifier3.customSymbolColor != Color.clear)
				{
					a = statModifier3.customSymbolColor;
				}
				else if (statModifier3.isPositiveBuff)
				{
					a = ColorConstants.blue;
				}
				float percentComplete2 = statModifier3.GetPercentComplete();
				percentComplete2 = Mathf.Lerp(0f, 0.88f, percentComplete2);
				a = Color.Lerp(a, ColorConstants.black, percentComplete2);
				r.SetCell(x, y, SpecialSymbols.Map(c2), a);
				x = ((!drawDirection) ? (x - 1) : (x + 1));
			}
		}
	}

	private void Update()
	{
		Hero hero = GameStates.Singleton.hero;
		if (lastHeroHitpoints != hero.Hitpoints || lastHeroMaxHitpoints != hero.MaxHitpoints || hitPointsBlinking > 0)
		{
			lastHeroHitpoints = hero.Hitpoints;
			lastHeroMaxHitpoints = hero.MaxHitpoints;
			string text = hero.Hitpoints.ToString();
			if (hitPointsBlinking > 0 && hitPointsBlinking-- % 6 >= 3)
			{
				int length = text.Length;
				text = "";
				while (length-- > 0)
				{
					text += " ";
				}
			}
			string value = $" \\O/ {text}/{hero.MaxHitpoints}";
			heroHitpoints.SetValue(value);
		}
		float num = ComputeArmorDisplayValue(hero.Armor);
		if (lastHeroArmor != num)
		{
			lastHeroArmor = num;
			heroArmor.color = ColorConstants.lightGrey;
			if (num <= 0f)
			{
				heroArmor.Clear();
			}
			else
			{
				heroArmor.SetValue("[" + $"{num:F1}" + "]");
			}
		}
		if (hero.statModController != null)
		{
			heroDebuffs = hero.statModController.debuffs;
		}
		else
		{
			heroDebuffs = null;
		}
		if (!(enemyShownElapsedTime > 0f))
		{
			return;
		}
		if (GameStates.Singleton.CurrentState < GameStates.State.Playing)
		{
			enemyShownElapsedTime = 0f;
			enemyHitpoints.Clear();
			enemyArmor.Clear();
			currentEnemy = null;
			currentEnemyName = null;
		}
		else
		{
			if (GameStates.Singleton.CurrentState != GameStates.State.Playing && GameStates.Singleton.CurrentState != GameStates.State.PlayPaused)
			{
				return;
			}
			if (currentEnemy == null || !currentEnemy.Alive || currentEnemy.PositionX < GameStates.Singleton.hero.PositionX)
			{
				enemyShownElapsedTime -= Utils.deltaTime;
			}
			if (enemyShownElapsedTime <= 0f)
			{
				enemyHitpoints.Clear();
				enemyArmor.Clear();
				currentEnemy = null;
				currentEnemyName = null;
			}
			UpdateEnemyHitpoints();
			if (!(currentEnemy != null))
			{
				return;
			}
			num = ComputeArmorDisplayValue(currentEnemy.Armor);
			if (lastEnemyArmor != num)
			{
				lastEnemyArmor = num;
				enemyArmor.color = ColorConstants.lightGrey;
				enemyArmor.alignment = AsciiString.Alignment.Right;
				if (num <= 0f)
				{
					enemyArmor.Clear();
				}
				else
				{
					enemyArmor.SetValue("[" + $"{num:F1}" + "]");
				}
			}
		}
	}

	private float ComputeArmorDisplayValue(float armorValue)
	{
		if (armorValue > 0f)
		{
			return Mathf.Ceil(armorValue * 10f) / 10f;
		}
		return 0f;
	}

	private void HandleOnCharacterDied(Character character, Character.DeathReason reason, Damage damage)
	{
		if (character == currentEnemy)
		{
			UpdateEnemyHitpoints();
			currentEnemy = null;
			currentEnemyName = null;
			enemyArmor.Clear();
		}
	}

	private void HandleOnCharacterGoingToTakeDamage(Character character, Damage dmg)
	{
	}

	private void HandleOnCharacterTookDamage(Character character, Damage dmg)
	{
		if (character == GameStates.Singleton.hero)
		{
			if (character.Armor > 0f && dmg.armorLost > 0f && armorBlinking <= 6)
			{
				armorBlinking += 12;
			}
			if (dmg.amount > Mathf.CeilToInt(character.Armor) && hitPointsBlinking <= 6)
			{
				hitPointsBlinking += 12;
			}
		}
		CommonHandleEnemy(character as Enemy);
	}

	private void HandleEnemyEngaged(Enemy enemy)
	{
		if (currentEnemy == null)
		{
			CommonHandleEnemy(enemy);
		}
	}

	private void CommonHandleEnemy(Enemy enemy)
	{
		if (enemy != null && enemy.showInHud)
		{
			currentEnemy = enemy;
			currentEnemyName = Te.xt(enemy.displayName);
			enemyShownElapsedTime = showEnemyNameDuration;
			ApplySeasonalNames();
			UpdateEnemyHitpoints();
		}
	}

	public void UpdateEnemyHitpoints()
	{
		if (currentEnemy != null)
		{
			string value = $"{currentEnemy.Hitpoints}/{currentEnemy.MaxHitpoints} {currentEnemyName} ";
			enemyHitpoints.SetValue(value);
		}
	}

	private void ApplySeasonalNames()
	{
		if (currentEnemyName.StartsWith("Pallas") && EventController.singleton.IsEventActiveAndStarted("halloween"))
		{
			currentEnemyName = "Pallas, Prepped to Party";
		}
		if (currentEnemyName.StartsWith("Nagaraja") && EventController.singleton.IsEventActiveAndStarted("nagaraja_2x"))
		{
			currentEnemyName = "Nagaraja, Dragonborne";
		}
	}

	private void Start()
	{
		enemyHitpoints.alignment = AsciiString.Alignment.Right;
		Character.OnCharacterDied += HandleOnCharacterDied;
		Character.OnCharacterTookDamage += HandleOnCharacterTookDamage;
		Character.OnCharacterGoingToTakeDamage += HandleOnCharacterGoingToTakeDamage;
		Enemy.OnEnemyEngaged += HandleEnemyEngaged;
	}

	private void OnDestroy()
	{
		Character.OnCharacterDied -= HandleOnCharacterDied;
		Character.OnCharacterTookDamage -= HandleOnCharacterTookDamage;
		Character.OnCharacterGoingToTakeDamage -= HandleOnCharacterGoingToTakeDamage;
		Enemy.OnEnemyEngaged -= HandleEnemyEngaged;
	}
}
