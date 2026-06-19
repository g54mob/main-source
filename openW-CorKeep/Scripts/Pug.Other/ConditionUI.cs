using System;
using System.Collections.Generic;
using System.Globalization;
using I2.Loc;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine;

public class ConditionUI : UIelement
{
	public enum DurationFormat
	{
		SEC = 0,
		MIN = 1,
		MIN_AND_SEC = 2
	}

	public SpriteRenderer icon;

	public Sprite positiveBackground;

	public Sprite negativeBackground;

	public SpriteRenderer background;

	public SpriteRenderer fader;

	public PugText stacksText;

	public PugText stacksTextShadow;

	private ConditionsContainerUI conditionsContainerUI;

	private Condition activeCondition;

	private static readonly int _MaskRect = Shader.PropertyToID("_MaskRect");

	private float currentMaskScale;

	private const string durationSec = "durationSec";

	private const string durationMin = "durationMin";

	private const string durationMinSec = "durationMinSec";

	private const string conditionsPrefix = "Conditions/";

	private const string oneTimeEffect = "oneTimeEffect";

	private const string buffsOwnerTerm = "buffsOwner";

	public void Awake()
	{
		currentMaskScale = -1f;
	}

	public void Init(ConditionsContainerUI conditionsContainerUI)
	{
		this.conditionsContainerUI = conditionsContainerUI;
	}

	public void UpdateCondition(Condition condition, NetworkTick currentTick, float tickFraction, uint tickRate)
	{
		if (activeCondition.conditionData.conditionID != condition.conditionData.conditionID)
		{
			ConditionInfo conditionInfo = Manager.ui.conditionsIconsTable.GetConditionInfo(condition.conditionData.conditionID);
			icon.sprite = conditionInfo.icon;
			background.sprite = (conditionInfo.isNegative ? negativeBackground : positiveBackground);
		}
		float num = NetworkTimeUtilities.TimeToFutureTickInSeconds(currentTick, tickFraction, condition.removeTick, tickRate);
		float num2 = 1f;
		if (condition.conditionData.duration > 0f && !float.IsPositiveInfinity(condition.conditionData.duration))
		{
			num2 = num / condition.conditionData.duration;
		}
		if (math.abs(currentMaskScale - num2) > 0.0625f)
		{
			currentMaskScale = num2;
			Vector4 maskRect = GetMaskRect(fader.bounds);
			maskRect.y += maskRect.w * num2;
			maskRect.w *= 1f - num2;
			fader.material.SetVector(_MaskRect, new Vector4(maskRect.x, maskRect.y, 1f / maskRect.z, 1f / maskRect.w));
		}
		if (activeCondition.conditionData.conditionID != condition.conditionData.conditionID || activeCondition.conditionData.value != condition.conditionData.value)
		{
			int stacks = ConditionExtensions.GetStacks(condition.conditionData.conditionID, condition.conditionData.value);
			if (stacks > 0)
			{
				string text = stacks.ToString();
				stacksText.gameObject.SetActive(value: true);
				stacksTextShadow.gameObject.SetActive(value: true);
				stacksText.DisableAutoInactivationOnStart();
				stacksTextShadow.DisableAutoInactivationOnStart();
				if (stacksText.GetText() != text)
				{
					stacksText.Render(text);
					stacksTextShadow.Render(text);
				}
			}
			else
			{
				stacksText.gameObject.SetActive(value: false);
				stacksTextShadow.gameObject.SetActive(value: false);
			}
		}
		activeCondition = condition;
	}

	private Vector4 GetMaskRect(Bounds bounds)
	{
		Vector3 min = bounds.min;
		Vector3 max = bounds.max;
		return new Vector4(min.x, min.y, max.x - min.x, max.y - min.y);
	}

	public override void OnDeselected(bool playEffect = true)
	{
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
	}

	public override void OnRightClicked(bool mod1, bool mod2)
	{
	}

	public override void OnSelected()
	{
	}

	public override List<TextAndFormatFields> GetHoverStats(bool previewReinforced)
	{
		List<TextAndFormatFields> list = new List<TextAndFormatFields>();
		if (activeCondition.conditionData.conditionID != ConditionID.None)
		{
			list.Add(GetConditionTextAndFormatFields(default(ContainedObjectsBuffer), activeCondition.conditionData, previewReinforced: false, isReinforced: false, previewUpgraded: false));
		}
		return list;
	}

	public override HoverWindowAlignment GetHoverWindowAlignment()
	{
		return HoverWindowAlignment.BOTTOM_RIGHT_OF_CURSOR;
	}

	public static DurationFormat GetDurationStrings(float duration, out string sec, out string min, bool showDecimal = false)
	{
		min = "";
		sec = "";
		string text = (showDecimal ? "F1" : "F0");
		if (duration == 0f)
		{
			return DurationFormat.SEC;
		}
		if (duration >= 60f && duration % 60f == 0f)
		{
			min = (duration / 60f).ToString(text, CultureInfo.InvariantCulture);
			return DurationFormat.MIN;
		}
		if (duration >= 60f)
		{
			min = math.floor(duration / 60f).ToString(text, CultureInfo.InvariantCulture);
			sec = (duration % 60f).ToString(text);
			return DurationFormat.MIN_AND_SEC;
		}
		sec = duration.ToString(text, CultureInfo.InvariantCulture);
		return DurationFormat.SEC;
	}

	public static TextAndFormatFields GetConditionTextAndFormatFields(ContainedObjectsBuffer containedObject, ConditionData conditionData, bool previewReinforced, bool isReinforced, bool previewUpgraded, bool buffsOwner = false)
	{
		TextAndFormatFields textAndFormatFields = new TextAndFormatFields();
		ConditionInfo conditionInfo = Manager.ui.conditionsIconsTable.GetConditionInfo(conditionData.conditionID);
		ConditionID conditionID = ((conditionInfo.useSameDescAsId != ConditionID.None) ? conditionInfo.useSameDescAsId : conditionInfo.Id);
		int num = 0;
		int num2 = 0;
		if (isReinforced || previewReinforced)
		{
			num2 = ConditionExtensions.GetReinforcedBonusValue(conditionData.value, conditionInfo);
		}
		if (isReinforced)
		{
			conditionData.value += num2;
		}
		else if (previewReinforced)
		{
			num = num2;
		}
		if (previewUpgraded && PugDatabase.HasComponent<LevelCD>(containedObject.objectData))
		{
			int num3 = ((containedObject.variation > 0) ? containedObject.variation : PugDatabase.GetComponent<LevelCD>(containedObject.objectData).level);
			List<ConditionData> conditionsOnEquip = ConditionUIExtensions.GetConditionsOnEquip(new ObjectDataCD
			{
				objectID = containedObject.objectID,
				variation = num3 + 1
			});
			for (int i = 0; i < conditionsOnEquip.Count; i++)
			{
				if (conditionsOnEquip[i].conditionID == conditionData.conditionID)
				{
					int value = conditionsOnEquip[i].value;
					int num4 = 0;
					if (isReinforced)
					{
						num4 = ConditionExtensions.GetReinforcedBonusValue(value, conditionInfo);
					}
					value += num4;
					num = value - conditionData.value;
					break;
				}
			}
		}
		bool num5 = conditionData.duration > 0f && !float.IsInfinity(conditionData.duration);
		string text = GetConditionValueString(value: conditionData.value + num, conditionId: conditionData.conditionID, showPlusSign: true);
		if (num5)
		{
			text = PugText.ProcessText("Conditions/" + conditionID, new string[1] { text }, shouldLocalize: true, shouldLocalizeFormatFields: false);
			if (buffsOwner)
			{
				text = PugText.ProcessText("buffsOwner", new string[1] { text }, shouldLocalize: true, shouldLocalizeFormatFields: false);
			}
			string sec;
			string min;
			switch (GetDurationStrings((int)conditionData.duration, out sec, out min))
			{
			case DurationFormat.MIN_AND_SEC:
				textAndFormatFields.text = "durationMinSec";
				textAndFormatFields.formatFields = new string[3] { text, min, sec };
				break;
			case DurationFormat.MIN:
				textAndFormatFields.text = "durationMin";
				textAndFormatFields.formatFields = new string[2] { text, min };
				break;
			default:
				textAndFormatFields.text = "durationSec";
				textAndFormatFields.formatFields = new string[2] { text, sec };
				break;
			}
		}
		else if (buffsOwner)
		{
			text = PugText.ProcessText("Conditions/" + conditionID, new string[1] { text }, shouldLocalize: true, shouldLocalizeFormatFields: false);
			textAndFormatFields.text = "buffsOwner";
			textAndFormatFields.formatFields = new string[1] { text };
		}
		else
		{
			textAndFormatFields.text = "Conditions/" + conditionID;
			textAndFormatFields.formatFields = new string[1] { text };
		}
		if (isReinforced && !conditionInfo.isUnique)
		{
			textAndFormatFields.color = Manager.ui.reinforcedColor;
		}
		if (((previewReinforced && !isReinforced) || previewUpgraded) && !conditionInfo.isUnique)
		{
			bool flag = false;
			string translation = LocalizationManager.GetTranslation(textAndFormatFields.text);
			if (!string.IsNullOrEmpty(translation))
			{
				int num6 = translation.IndexOf("{0}", StringComparison.Ordinal);
				if (num6 >= 0)
				{
					flag = num6 + 3 < translation.Length && translation[num6 + 3] == '%';
				}
			}
			string conditionValueString = GetConditionValueString(conditionData.conditionID, num, showPlusSign: true);
			if (flag)
			{
				textAndFormatFields.additionalText = "(" + conditionValueString + "%)";
			}
			else
			{
				textAndFormatFields.additionalText = "(" + conditionValueString + ")";
			}
			textAndFormatFields.additionalTextColor = Manager.ui.previewReinforcedColor;
		}
		if (conditionInfo.isUnique || conditionInfo.isPermanent)
		{
			if (conditionInfo.isPermanent && !conditionInfo.isAdditiveWithSelf && EntityUtility.GetConditionValue(conditionInfo.Id, Manager.main.player.entity, Manager.main.player.world) != 0)
			{
				textAndFormatFields.color = Color.gray;
				textAndFormatFields.color.a = 0.2f;
			}
			else
			{
				textAndFormatFields.color = Color.green;
			}
		}
		if (conditionInfo.isUnique && conditionInfo.isPermanent && !conditionInfo.isAdditiveWithSelf)
		{
			textAndFormatFields.additionalText = LocalizationManager.GetTranslation("oneTimeEffect");
			textAndFormatFields.additionalTextColor = textAndFormatFields.color;
		}
		textAndFormatFields.isPermanent = conditionInfo.isPermanent;
		return textAndFormatFields;
	}

	public static string GetConditionValueString(ConditionID conditionId, int value, bool showPlusSign)
	{
		ConditionInfo conditionInfo = Manager.ui.conditionsIconsTable.GetConditionInfo(conditionId);
		if (showPlusSign && conditionInfo.skipShowingSignInfrontOfValue)
		{
			showPlusSign = false;
		}
		if (conditionInfo.skipShowingSignInfrontOfValue)
		{
			value = math.abs(value);
		}
		if (conditionInfo.showDecimal)
		{
			float num = (float)value / 10f;
			if (!(value >= 0 && showPlusSign))
			{
				return num.ToString("F1", CultureInfo.InvariantCulture);
			}
			return "+" + num.ToString("F1", CultureInfo.InvariantCulture);
		}
		if (!(value >= 0 && showPlusSign))
		{
			return value.ToString();
		}
		return "+" + value;
	}
}
