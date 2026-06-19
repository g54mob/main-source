using System.Collections.Generic;
using I2.Loc;
using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

public class PetTalentUIElement : UIelement
{
	public SpriteRenderer icon;

	public PugText pointsText;

	public List<PugText> shadowPointsTexts;

	private int _talentIndex;

	private ConditionInfo _conditionInfo;

	private PetInfosTable.PetTalentInfo _petTalentInfo;

	private PetCD _petCD;

	private int _talentPoints;

	public SpriteRenderer hoverSR;

	public LocalizedString nextTalentPointTerm;

	public SpriteRenderer completedBorder;

	private const int MAX_TALENT_POINTS = 1;

	private const string talentPrefix = "PetTalents/";

	private ContainedObjectsBuffer GetPetContainedObject()
	{
		PlayerController player = Manager.main.player;
		if (player != null)
		{
			return player.equipmentHandler.petInventoryHandler.GetContainedObjectData(0);
		}
		return default(ContainedObjectsBuffer);
	}

	public void UpdateTalent(int index, PetInfosTable.PetTalentInfo petTalentInfo, PetCD petCD)
	{
		_petTalentInfo = petTalentInfo;
		_conditionInfo = Manager.ui.conditionsIconsTable.GetConditionInfo(petTalentInfo.conditionID);
		_petCD = petCD;
		_talentIndex = index;
		bool flag = RowIsUnlocked();
		icon.sprite = petTalentInfo.GetIcon(_petCD.petType);
		_talentPoints = GetCurrentPoints();
		bool flag2 = CanPlacePoints() || _talentPoints > 0;
		icon.color = (flag ? Color.white : Color.black);
		icon.SetAlpha(flag2 ? 1f : 0.25f);
		if (_talentPoints >= 1)
		{
			completedBorder.enabled = true;
		}
		else
		{
			completedBorder.enabled = false;
		}
		pointsText.gameObject.SetActive(value: false);
		foreach (PugText shadowPointsText in shadowPointsTexts)
		{
			shadowPointsText.gameObject.SetActive(value: false);
		}
	}

	private bool CanPlacePoints()
	{
		ContainedObjectsBuffer petContainedObject = GetPetContainedObject();
		int currentPoints = GetCurrentPoints();
		int totalTalentPoints = PetExtensions.GetTotalTalentPoints(petContainedObject.amount);
		int spentTalentPoints = PetExtensions.GetSpentTalentPoints(petContainedObject);
		int num = totalTalentPoints - spentTalentPoints;
		int num2 = UnlockedLevel();
		if (num > 0 && currentPoints == 0)
		{
			return spentTalentPoints >= num2;
		}
		return false;
	}

	private bool RowIsUnlocked()
	{
		return true;
	}

	private int UnlockedLevel()
	{
		return _talentIndex / 3;
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		PlayerController player = Manager.main.player;
		if (CanPlacePoints() && !(player == null))
		{
			if (GetCurrentPoints() < 1)
			{
				ContainedObjectsBuffer petContainedObject = GetPetContainedObject();
				player.equipmentHandler.petInventoryHandler.SetPetTalentPoints(player, petContainedObject.objectID, _talentIndex, 1);
				AudioManager.SfxUI(SfxID.FIXME_menu_select, 1f, reuse: true, 1f, 0.15f, playOnGamepad: true);
			}
			base.OnLeftClicked(mod1, mod2);
		}
	}

	public int GetCurrentPoints()
	{
		if (!PetExtensions.HasTalent(_talentIndex, GetPetContainedObject()))
		{
			return 0;
		}
		return 1;
	}

	public override TextAndFormatFields GetHoverTitle()
	{
		return new TextAndFormatFields
		{
			text = "PetTalents/" + _petTalentInfo.petTalentID.ToString() + _petCD.petType
		};
	}

	public override List<TextAndFormatFields> GetHoverStats(bool previewReinforced)
	{
		if (!RowIsUnlocked())
		{
			return null;
		}
		List<TextAndFormatFields> list = new List<TextAndFormatFields>();
		ObjectID objectID = GetPetContainedObject().objectID;
		float num = 1f;
		foreach (PetInfosTable.PetTalentMultiplierOverride multiplierOverride in _petTalentInfo.multiplierOverrides)
		{
			if (multiplierOverride.petId == objectID)
			{
				num = multiplierOverride.multiplier;
				break;
			}
		}
		float num2 = 1f;
		if (Manager.main.player.activePet != null)
		{
			num2 += (float)EntityUtility.GetConditionEffectValue(ConditionEffect.BuffsIncrease, Manager.main.player.activePet.entity, base.world) / 100f;
		}
		int num3 = (_petCD.buffsOwner ? _petTalentInfo.buffValue : _petTalentInfo.value);
		ConditionData conditionData = new ConditionData
		{
			conditionID = _petTalentInfo.conditionID,
			value = (int)math.round((float)num3 * num * num2)
		};
		TextAndFormatFields conditionTextAndFormatFields = ConditionUI.GetConditionTextAndFormatFields(default(ContainedObjectsBuffer), conditionData, previewReinforced: false, isReinforced: false, previewUpgraded: false, _petCD.buffsOwner);
		conditionTextAndFormatFields.color = ((_talentPoints > 0) ? Color.yellow : Color.gray);
		list.Add(conditionTextAndFormatFields);
		return list;
	}

	public override void OnSelected()
	{
		hoverSR.gameObject.SetActive(value: true);
		base.OnSelected();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		hoverSR.gameObject.SetActive(value: false);
		base.OnDeselected(playEffect);
	}
}
