using System.Collections.Generic;
using I2.Loc;
using Pug.UnityExtensions;
using UnityEngine;

public class SoulsUIElement : UIelement
{
	public SpriteRenderer icon;

	public LocalizedString soulTitle;

	public LocalizedString soulDesc;

	private const string clickToActivateTerm = "clickToActivate";

	private const string clickToDeactivateTerm = "clickToDeactivate";

	public SoulID soulID;

	private const string conditionsPrefix = "Conditions/";

	private bool hasCollectedSoul => Manager.saves.HasCollectedSoul(soulID);

	private bool soulIsEnabled => Manager.saves.SoulPowerIsEnabled(soulID);

	protected override void LateUpdate()
	{
		icon.gameObject.SetActive(hasCollectedSoul);
		icon.SetAlpha(soulIsEnabled ? 1f : 0.3f);
		base.LateUpdate();
	}

	public override TextAndFormatFields GetHoverTitle()
	{
		if (soulID == SoulID.None)
		{
			return null;
		}
		return new TextAndFormatFields
		{
			text = soulTitle.mTerm
		};
	}

	public override List<TextAndFormatFields> GetHoverDescription()
	{
		if (soulID == SoulID.None)
		{
			return null;
		}
		if (hasCollectedSoul)
		{
			return new List<TextAndFormatFields>
			{
				new TextAndFormatFields
				{
					text = soulDesc.mTerm
				},
				GetInstructionText(soulIsEnabled)
			};
		}
		return null;
	}

	private TextAndFormatFields GetInstructionText(bool soulEnabled)
	{
		string[] formatFields = null;
		return new TextAndFormatFields
		{
			text = (soulEnabled ? "clickToDeactivate" : "clickToActivate"),
			formatFields = formatFields
		};
	}

	public override List<TextAndFormatFields> GetHoverStats(bool previewReinforced)
	{
		if (soulID == SoulID.None)
		{
			return null;
		}
		List<TextAndFormatFields> list = new List<TextAndFormatFields>();
		if (hasCollectedSoul)
		{
			ConditionData soulConditionData = SoulsExtensions.GetSoulConditionData(soulID);
			int additionalSoulConditionData = GetAdditionalSoulConditionData(soulID);
			ConditionInfo conditionInfo = Manager.ui.conditionsIconsTable.GetConditionInfo(soulConditionData.conditionID);
			ConditionID conditionId = soulConditionData.conditionID;
			if (conditionInfo.useSameDescAsId != ConditionID.None)
			{
				conditionId = conditionInfo.useSameDescAsId;
			}
			string conditionValueString = ConditionUI.GetConditionValueString(conditionId, soulConditionData.value + additionalSoulConditionData, showPlusSign: true);
			list.Add(new TextAndFormatFields
			{
				text = "Conditions/" + conditionId,
				formatFields = new string[1] { conditionValueString },
				color = (soulIsEnabled ? Color.yellow : (Color.yellow * 0.5f))
			});
		}
		return list;
	}

	public static int GetAdditionalSoulConditionData(SoulID soulID)
	{
		PlayerController player = Manager.main.player;
		if (player != null)
		{
			switch (soulID)
			{
			case SoulID.SoulOfAzeos:
				return EntityUtility.GetConditionEffectValue(ConditionEffect.AdditionalChanceOnCritToSpawnThunderBeam, player.entity, player.world);
			case SoulID.SoulOfOmoroth:
				return EntityUtility.GetConditionEffectValue(ConditionEffect.AdditionalChanceOnRangeHitToSpawnOctopusBossProjectile, player.entity, player.world);
			case SoulID.SoulOfScarab:
				return EntityUtility.GetConditionEffectValue(ConditionEffect.AdditionalChanceOnHitToSpawnScarabBossProjectile, player.entity, player.world);
			}
		}
		return 0;
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		if (hasCollectedSoul)
		{
			if (Manager.saves.SoulPowerIsEnabled(soulID))
			{
				Manager.saves.DisableSoulPower(soulID);
			}
			else
			{
				Manager.saves.EnableSoulPower(soulID);
			}
		}
		base.OnLeftClicked(mod1, mod2);
	}

	public override HoverWindowAlignment GetHoverWindowAlignment()
	{
		if (!hasCollectedSoul)
		{
			return HoverWindowAlignment.BOTTOM_RIGHT_OF_CURSOR;
		}
		return base.GetHoverWindowAlignment();
	}
}
