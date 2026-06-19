using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class CharacterStatsWindow : UIelement, IScrollable
{
	private const string totalItemLevel = "TotalItemLevel";

	private const string healthTitle = "Stats/Health";

	private const string manaTitle = "Stats/Mana";

	private const string defenseTitle = "Stats/Defense";

	private const string offenseTitle = "Stats/Offense";

	private const string minionsTitle = "Stats/Minions";

	private const string adventureTitle = "Stats/Adventure";

	private const string weaponMeleeDamageString = "meleeWeapon";

	private const string weaponRangeDamageString = "rangeWeapon";

	private const string explosiveDamageString = "explosiveDamage";

	private const string magicWeaponDamage = "magicWeaponDamage";

	private const string physicalWeaponDamage = "physicalWeaponDamage";

	public Color titleDarkColor;

	public Color titleBrightColor;

	public int textOrderInlayer;

	public GameObject linePrefab;

	public List<GameObject> lines;

	public List<StatTextUIElement> statsTexts;

	public StatTextUIElement statTextPrefab;

	public GameObject statsTextsContainer;

	public SpriteRenderer backgroundSR;

	public BoxCollider backgroundCollider;

	public UIScrollWindow uIScrollWindow;

	private int tmpIndex;

	private int tmpLineIndex;

	private Vector3 previousTextBottom = Vector3.zero;

	private readonly string conditionText = "ConditionEffect/";

	public void UpdateContainingElements(float scroll)
	{
		if (!(Manager.main.player == null))
		{
			for (int i = 0; i < statsTexts.Count; i++)
			{
				statsTexts[i].gameObject.SetActive(value: false);
			}
			for (int j = 0; j < lines.Count; j++)
			{
				lines[j].SetActive(value: false);
			}
			DynamicBuffer<SummarizedConditionEffectsBuffer> conditionEffectValues = EntityUtility.GetConditionEffectValues(Manager.main.player.entity, base.world);
			DynamicBuffer<SummarizedConditionsBuffer> conditionValues = EntityUtility.GetConditionValues(Manager.main.player.entity, base.world);
			tmpIndex = 0;
			tmpLineIndex = 0;
			previousTextBottom = Vector3.zero;
			ShowTotalItemLevel();
			ShowTitle("Stats/Health");
			AddLine();
			ShowCondition(ConditionID.IncreasedMaxHealth, showValueWhenZero: true, conditionEffectValues, conditionValues);
			ShowCondition(ConditionID.HealOverTime, showValueWhenZero: false, conditionEffectValues, conditionValues);
			ShowCondition(ConditionID.LifeOnHit, showValueWhenZero: false, conditionEffectValues, conditionValues);
			ShowCondition(ConditionID.LifeOnPetHit, showValueWhenZero: false, conditionEffectValues, conditionValues);
			ShowCondition(ConditionID.LifeOnMinionHit, showValueWhenZero: false, conditionEffectValues, conditionValues);
			if (conditionEffectValues[100].value != 0 || conditionEffectValues[111].value != 0)
			{
				ShowTitle("Stats/Mana");
				AddLine();
				ShowCondition(ConditionID.IncreasedMaxMana, showValueWhenZero: true, conditionEffectValues, conditionValues);
				ShowCondition(ConditionID.IncreasedManaRegen, showValueWhenZero: true, conditionEffectValues, conditionValues);
				ShowCondition(ConditionID.ManaOnHit, showValueWhenZero: false, conditionEffectValues, conditionValues);
			}
			ShowTitle("Stats/Defense");
			AddLine();
			ShowCondition(ConditionID.ArmorIncrease, showValueWhenZero: true, conditionEffectValues, conditionValues);
			ShowCondition(ConditionID.MagicBarrier, showValueWhenZero: false, conditionEffectValues, conditionValues);
			ShowCondition(ConditionID.DodgeChance, showValueWhenZero: false, conditionEffectValues, conditionValues);
			ShowCondition(ConditionID.ReducedDamageFromBosses, showValueWhenZero: false, conditionEffectValues, conditionValues);
			ShowTitle("Stats/Offense");
			AddLine();
			ShowCondition(ConditionID.MeleeDamageIncrease, showValueWhenZero: true, conditionEffectValues, conditionValues);
			ShowCondition(ConditionID.MeleeAttackSpeedIncrease, showValueWhenZero: false, conditionEffectValues, conditionValues);
			ShowCondition(ConditionID.RangeDamageIncrease, showValueWhenZero: false, conditionEffectValues, conditionValues);
			ShowCondition(ConditionID.RangeAttackSpeedIncrease, showValueWhenZero: false, conditionEffectValues, conditionValues);
			ShowCondition(ConditionID.CritChance, showValueWhenZero: false, conditionEffectValues, conditionValues);
			ShowCondition(ConditionID.CriticalDamagePercentageIncrease, showValueWhenZero: false, conditionEffectValues, conditionValues);
			ShowCondition(ConditionID.IncreasedExplosivesDamage, showValueWhenZero: false, conditionEffectValues, conditionValues);
			ShowCondition(ConditionID.ChanceOnHitToKnockback, showValueWhenZero: false, conditionEffectValues, conditionValues);
			ShowCondition(ConditionID.ApplyBurning, showValueWhenZero: false, conditionEffectValues, conditionValues);
			ShowCondition(ConditionID.ThornsDamage, showValueWhenZero: false, conditionEffectValues, conditionValues);
			ShowCondition(ConditionID.IncreasedDamageAgainstBosses, showValueWhenZero: false, conditionEffectValues, conditionValues);
			ShowCondition(ConditionID.AmassThenReciprocateDamage, showValueWhenZero: false, conditionEffectValues, conditionValues);
			if (conditionEffectValues[113].value != 0 || conditionEffectValues[105].value != 0 || conditionEffectValues[103].value != 0)
			{
				ShowTitle("Stats/Minions");
				AddLine();
				ShowCondition(ConditionID.IncreasedMaxMinions, showValueWhenZero: true, conditionEffectValues, conditionValues);
				ShowCondition(ConditionID.IncreasedMinionDamagePercentage, showValueWhenZero: false, conditionEffectValues, conditionValues);
				ShowCondition(ConditionID.IncreasedMinionLifespanPercentage, showValueWhenZero: false, conditionEffectValues, conditionValues);
				ShowCondition(ConditionID.IncreasedMinionAttackSpeed, showValueWhenZero: false, conditionEffectValues, conditionValues);
				ShowCondition(ConditionID.IncreasedMinionCritChance, showValueWhenZero: false, conditionEffectValues, conditionValues);
			}
			ShowTitle("Stats/Adventure");
			AddLine();
			ShowCondition(ConditionID.MiningIncrease, showValueWhenZero: true, conditionEffectValues, conditionValues);
			ShowCondition(ConditionID.MiningSpeedIncrease, showValueWhenZero: false, conditionEffectValues, conditionValues);
			ShowCondition(ConditionID.MovementSpeedIncrease, showValueWhenZero: true, conditionEffectValues, conditionValues);
			ShowCondition(ConditionID.IncreasedFishing, showValueWhenZero: false, conditionEffectValues, conditionValues);
			ShowCondition(ConditionID.OrangeGlow, showValueWhenZero: false, conditionEffectValues, conditionValues);
			ShowCondition(ConditionID.ExtraHarvestChance, showValueWhenZero: false, conditionEffectValues, conditionValues);
			ShowCondition(ConditionID.ChanceToGainExtraCookedFood, showValueWhenZero: false, conditionEffectValues, conditionValues);
			UpdateNavigation();
		}
	}

	private void ShowTotalItemLevel()
	{
		TextAndFormatFields textAndFormatFields = new TextAndFormatFields();
		textAndFormatFields.text = "TotalItemLevel";
		textAndFormatFields.formatFields = new string[1] { GetTotalItemLevel().ToString() };
		TextAndFormatFields textAndFields = textAndFormatFields;
		ShowText(textAndFields, isTitle: false, Manager.ui.itemLevelColor);
	}

	private int GetTotalItemLevel()
	{
		return (from handler in Manager.main.player.equipmentHandler.getAllItemInventoryHandlers()
			where handler.GetContainedObjectData(0).amount > 0
			select handler.GetObjectData(0)).Sum((ObjectDataCD objectData) => (objectData.variation <= 0) ? PugDatabase.GetComponent<LevelCD>(objectData).level : objectData.variation);
	}

	public bool IsBottomElementSelected()
	{
		UIelement uIelement = null;
		foreach (UIelement childElement in childElements)
		{
			if (childElement.gameObject.activeInHierarchy)
			{
				uIelement = childElement;
			}
		}
		if (uIelement != null)
		{
			return uIelement == Manager.ui.currentSelectedUIElement;
		}
		return false;
	}

	public bool IsTopElementSelected()
	{
		foreach (UIelement childElement in childElements)
		{
			if (childElement.gameObject.activeInHierarchy)
			{
				return childElement == Manager.ui.currentSelectedUIElement;
			}
		}
		return false;
	}

	public float GetCurrentWindowHeight()
	{
		return math.abs(previousTextBottom.y);
	}

	public UIScrollWindow GetScrollWindow()
	{
		return uIScrollWindow;
	}

	private void UpdateNavigation()
	{
		childElements.Clear();
		UIelement uIelement = null;
		for (int i = 0; i < statsTexts.Count; i++)
		{
			if (statsTexts[i].conditionEffect != ConditionEffect.None)
			{
				childElements.Add(statsTexts[i]);
				statsTexts[i].topUIElements.Clear();
				statsTexts[i].bottomUIElements.Clear();
				if (uIelement != null)
				{
					statsTexts[i].topUIElements.Add(uIelement);
					uIelement.bottomUIElements.Add(statsTexts[i]);
				}
				uIelement = statsTexts[i];
			}
		}
	}

	private void ShowCondition(ConditionID conditionId, bool showValueWhenZero, DynamicBuffer<SummarizedConditionEffectsBuffer> conditionEffects, DynamicBuffer<SummarizedConditionsBuffer> conditions)
	{
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			return;
		}
		ConditionEffect effect = Manager.ui.conditionsIconsTable.GetConditionInfo(conditionId).effect;
		int num = conditionEffects[(int)effect].value;
		switch (effect)
		{
		case ConditionEffect.MovementSpeed:
			num += 1000;
			break;
		case ConditionEffect.HealOverTime:
		{
			if (Manager.main.player != null)
			{
				num += (int)math.round((float)Manager.main.player.GetMaxHealth() * ((float)conditions[211].value / 100f));
			}
			float num5 = 1f + (float)conditions[105].value / 100f;
			num = (int)math.round((float)num * num5);
			break;
		}
		case ConditionEffect.CriticalDamagePercentage:
			if (num == 0)
			{
				return;
			}
			num += 50;
			break;
		case ConditionEffect.MeleeAttackSpeed:
		case ConditionEffect.RangeAttackSpeed:
		{
			ObjectDataCD objectData = Manager.main.player.GetEquippedSlot().objectData;
			if (PugDatabase.HasComponent<HasWeaponDamageCD>(objectData) && !PugDatabase.HasComponent<ControlledByOtherEntityCD>(objectData))
			{
				HasWeaponDamageCD component = PugDatabase.GetComponent<HasWeaponDamageCD>(objectData);
				if ((effect == ConditionEffect.MeleeAttackSpeed && component.isRange) || (effect == ConditionEffect.RangeAttackSpeed && !component.isRange))
				{
					return;
				}
			}
			else if (effect == ConditionEffect.RangeAttackSpeed)
			{
				return;
			}
			num += conditionEffects[65].value;
			break;
		}
		case ConditionEffect.MaxHealth:
		{
			num += 100;
			num += conditionEffects[68].value;
			float num4 = math.max(1f + (float)conditionEffects[34].value / 100f, 0f);
			num = (int)math.round(math.max(1f, num4 * (float)num));
			break;
		}
		case ConditionEffect.Mining:
			num = (int)math.round((1f + (float)conditionEffects[38].value / 100f) * (float)(20 + num));
			break;
		case ConditionEffect.Armor:
		{
			float num3 = 1f + (float)conditionEffects[37].value / 1000f;
			int value = conditionEffects[52].value;
			num += (int)math.round((float)num * ((float)value / 1000f * math.max(0f, (float)conditionEffects[2].value / 1000f)));
			num = (int)math.round(num3 * (float)num);
			break;
		}
		case ConditionEffect.MaxMana:
			num += 100;
			break;
		case ConditionEffect.ManaRegen:
		{
			float num2 = (float)num + 100f;
			MagicBarrierCD componentData = EntityUtility.GetComponentData<MagicBarrierCD>(player.entity, player.world);
			num = (int)math.round((num2 + (float)conditions[272].value / 10f * (float)componentData.barrierHealth) * (1f + (float)conditions[255].value / 100f));
			break;
		}
		case ConditionEffect.MaxMinions:
			num++;
			break;
		}
		bool flag = effect == ConditionEffect.MeleeDamage;
		bool flag2 = effect == ConditionEffect.RangeDamage;
		int num6 = 10;
		float num7 = 1f + (float)num / 1000f;
		if (flag || flag2)
		{
			ObjectDataCD objectData2 = Manager.main.player.GetEquippedSlot().objectData;
			bool flag3 = false;
			if (PugDatabase.HasComponent<HasWeaponDamageCD>(objectData2) && !PugDatabase.HasComponent<ControlledByOtherEntityCD>(objectData2) && PugDatabase.HasComponent<LevelCD>(objectData2))
			{
				WeaponDamageCD componentData2 = EntityUtility.GetComponentData<WeaponDamageCD>(EntityUtility.GetLevelEntity(objectData2), base.world);
				HasWeaponDamageCD component2 = PugDatabase.GetComponent<HasWeaponDamageCD>(objectData2);
				RangeWeaponCD component3;
				bool flag4 = PugDatabase.TryGetComponent<RangeWeaponCD>(objectData2, out component3);
				bool flag5 = PugDatabase.HasComponent<IsExplosiveCD>(objectData2) || (flag4 && PugDatabase.HasComponent<IsExplosiveCD>(component3.projectileID));
				flag3 = component2.isMagic;
				if ((flag && (component2.isRange || flag5)) || (flag2 && !component2.isRange))
				{
					return;
				}
				bool isReinforced = PugDatabase.HasComponent<DurabilityCD>(objectData2) && PugDatabase.GetComponent<DurabilityCD>(objectData2).IsReinforced(objectData2.amount);
				num6 = componentData2.GetDamage(isReinforced);
			}
			else if (!flag)
			{
				return;
			}
			if (flag)
			{
				float num8 = 1f + (float)conditionEffects[38].value / 100f;
				float num9 = (float)(conditionEffects[7].value + 20) * num8;
				num6 += (int)math.round((float)conditionEffects[43].value / 100f * num9);
			}
			else if (flag2)
			{
				num6 += (int)math.round((float)conditionEffects[44].value / 100f * (float)conditionEffects[36].value);
			}
			if (flag3)
			{
				num7 += (float)conditionEffects[102].value / 1000f;
				if (conditionEffects[110].value != 0)
				{
					float normalized = EntityUtility.GetComponentData<ManaCD>(player.entity, player.world).Normalized;
					num7 += (float)conditionEffects[110].value * normalized / 100f;
				}
				if (conditionEffects[109].value != 0)
				{
					MagicBarrierCD componentData3 = EntityUtility.GetComponentData<MagicBarrierCD>(player.entity, player.world);
					int num10 = (int)math.round((float)conditionEffects[109].value / 100f * (float)componentData3.barrierHealth);
					num6 += num10;
				}
			}
			else if (flag2)
			{
				num7 += (float)conditionEffects[22].value / 1000f;
			}
			else if (flag)
			{
				num7 += (float)conditionEffects[8].value / 1000f;
			}
			if (conditionEffects[74].value > 0)
			{
				num6 += conditionEffects[21].value;
			}
			num7 += (float)conditionEffects[33].value / 1000f;
			num = (int)math.round((float)num6 * num7);
			int num11 = (int)((float)num * 0.1f);
			string str = (flag3 ? "magicWeaponDamage" : "physicalWeaponDamage");
			string text = (flag ? "meleeWeapon" : "rangeWeapon");
			TextAndFormatFields textAndFormatFields = new TextAndFormatFields();
			textAndFormatFields.text = text;
			textAndFormatFields.formatFields = new string[1] { PugText.ProcessText(str, new string[2]
			{
				(num - num11).ToString(),
				(num + num11).ToString()
			}, shouldLocalize: true, shouldLocalizeFormatFields: false) };
			TextAndFormatFields textAndFields = textAndFormatFields;
			if (showValueWhenZero || num != 0)
			{
				ShowText(textAndFields, isTitle: false, Color.white, hasOutline: false, effect);
			}
			return;
		}
		switch (effect)
		{
		case ConditionEffect.ExplosivesDamage:
		{
			ObjectDataCD objectData3 = Manager.main.player.GetEquippedSlot().objectData;
			if (StatsUIUtility.HasExplosiveWeapon(objectData3, out var isExplosiveCD, base.world))
			{
				num6 = isExplosiveCD.damage;
				float num12 = 1f + (float)conditionEffects[46].value / 100f;
				if (PugDatabase.TryGetComponent<DurabilityCD>(objectData3, out var component4) && component4.IsReinforced(objectData3.amount))
				{
					num12 *= 1.15f;
				}
				num = (int)math.round(num12 * (float)num6);
				int num13 = (int)((float)num * 0.1f);
				TextAndFormatFields textAndFormatFields = new TextAndFormatFields();
				textAndFormatFields.text = "nonLocalizedPlaceholder";
				textAndFormatFields.formatFields = new string[1] { PugText.ProcessText("explosiveDamage", new string[2]
				{
					(num - num13).ToString(),
					(num + num13).ToString()
				}, shouldLocalize: true, shouldLocalizeFormatFields: false) };
				TextAndFormatFields textAndFields2 = textAndFormatFields;
				if (showValueWhenZero || num != 0)
				{
					ShowText(textAndFields2, isTitle: false, Color.white, hasOutline: false, effect);
				}
			}
			break;
		}
		case ConditionEffect.ApplyBurning:
		{
			int num14 = (int)math.round((float)(num * conditions[314].value) / 100f);
			num += num14;
			if (showValueWhenZero || num != 0)
			{
				ShowText(GetConditionTextAndFormat(conditionId, effect, num), isTitle: false, Color.white, hasOutline: false, effect);
			}
			break;
		}
		default:
			if (showValueWhenZero || num != 0)
			{
				ShowText(GetConditionTextAndFormat(conditionId, effect, num), isTitle: false, Color.white, hasOutline: false, effect);
			}
			break;
		}
	}

	private void ShowTitle(string text)
	{
		ShowText(new TextAndFormatFields
		{
			text = text
		}, isTitle: true, titleDarkColor, hasOutline: true);
	}

	private void ShowText(TextAndFormatFields textAndFields, bool isTitle, Color color, bool hasOutline = false, ConditionEffect conditionEffect = ConditionEffect.None)
	{
		StatTextUIElement statText = GetStatText(tmpIndex, conditionEffect);
		statText.gameObject.SetActive(value: true);
		tmpIndex++;
		if (statText.text.formatFields == null)
		{
			statText.text.formatFields = new string[0];
		}
		StatTextUIElement statTextUIElement = null;
		if (hasOutline)
		{
			statTextUIElement = GetStatText(tmpIndex);
			statTextUIElement.conditionEffect = conditionEffect;
			tmpIndex++;
			statTextUIElement.gameObject.SetActive(value: true);
		}
		statText.text.SetOrderInLayer(textOrderInlayer);
		statText.text.SetFont(isTitle ? TextManager.FontFace.boldSmall : TextManager.FontFace.thinSmall);
		statText.text.formatFields = textAndFields.formatFields;
		statText.text.Render(textAndFields.text);
		statText.text.SetTempColor(color);
		statText.UpdateStatTextUIElement(conditionEffect, textAndFields);
		if (hasOutline)
		{
			statTextUIElement.text.SetOrderInLayer(textOrderInlayer - 1);
			statTextUIElement.text.SetFont(isTitle ? TextManager.FontFace.boldSmall : TextManager.FontFace.thinSmall);
			statTextUIElement.text.formatFields = textAndFields.formatFields;
			statTextUIElement.text.Render(textAndFields.text);
			statTextUIElement.text.SetTempColor(titleBrightColor);
			statTextUIElement.UpdateStatTextUIElement(conditionEffect, textAndFields);
		}
		float num = Math.Max(1f, 2f * (float)statText.text.displayedTextStringLinesAmount);
		float num2 = statText.text.dimensions.height / num;
		float num3 = (isTitle ? 0.0625f : (-0.0625f));
		Vector3 vector = new Vector3(0f, num2 - num2 % 0.0625f + num3, 0f);
		vector += new Vector3(0f, 0.0625f, 0f);
		statText.transform.localPosition = previousTextBottom - vector;
		previousTextBottom -= new Vector3(0f, statText.text.dimensions.height + num3, 0f);
		if (statTextUIElement != null)
		{
			Vector3 vector2 = new Vector3(0f, 0.0625f, 0f);
			statTextUIElement.transform.localPosition = statText.transform.localPosition - vector2;
			previousTextBottom -= vector2;
		}
	}

	private StatTextUIElement GetStatText(int index, ConditionEffect conditionEffect = ConditionEffect.None)
	{
		while (index >= statsTexts.Count)
		{
			StatTextUIElement statTextUIElement = UnityEngine.Object.Instantiate(statTextPrefab, statsTextsContainer.transform);
			statTextUIElement.statsWindow = this;
			statTextUIElement.gameObject.SetActive(value: false);
			statsTexts.Add(statTextUIElement);
		}
		return statsTexts[index];
	}

	private TextAndFormatFields GetConditionTextAndFormat(ConditionID conditionId, ConditionEffect conditionEffect, int conditionValue)
	{
		string conditionValueString = ConditionUI.GetConditionValueString(conditionId, conditionValue, showPlusSign: false);
		TextAndFormatFields textAndFormatFields = new TextAndFormatFields();
		textAndFormatFields.text = conditionText + conditionEffect;
		textAndFormatFields.formatFields = new string[1] { conditionValueString };
		return textAndFormatFields;
	}

	private void AddLine()
	{
		GameObject line = GetLine(tmpLineIndex);
		line.SetActive(value: true);
		line.transform.localPosition = previousTextBottom;
		previousTextBottom -= new Vector3(0f, 0.125f, 0f);
		tmpLineIndex++;
	}

	private GameObject GetLine(int index)
	{
		while (index >= lines.Count)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(linePrefab, statsTextsContainer.transform);
			gameObject.gameObject.SetActive(value: false);
			lines.Add(gameObject);
		}
		return lines[index];
	}
}
