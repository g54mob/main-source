using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CropInfoPanel : MonoBehaviour
{
	public static CropInfoPanel ins;

	public bool verticalVersion;

	[SerializeField]
	private TMP_Text infoHeader;

	[SerializeField]
	private TMP_Text infoText;

	[SerializeField]
	private TMP_Text descText;

	[SerializeField]
	private TMP_Text growDuration;

	[SerializeField]
	private TMP_Text wateringNeeds;

	[SerializeField]
	private TMP_Text biofuelYield;

	[SerializeField]
	private TMP_Text sparePartsYield;

	[SerializeField]
	private TMP_Text harvestTimes;

	[SerializeField]
	private Sprite tick;

	[SerializeField]
	private Sprite noTick;

	[Header("Unlock Requirements")]
	[SerializeField]
	private TMP_Text[] cropsHarvestedText;

	[SerializeField]
	private TMP_Text[] cropsHarvestedDenominator;

	[SerializeField]
	private Image[] cropsHarvestedImage;

	[SerializeField]
	private Slider[] cropsHarvestedProgressBar;

	[SerializeField]
	private Image[] requirementsMetTick;

	[SerializeField]
	private Image[] requirementsBackground;

	[Space]
	[SerializeField]
	private RectTransform rectTransform;

	[Header("GMO Chip")]
	[SerializeField]
	private GameObject chipObject;

	[SerializeField]
	private Image cropImage;

	[SerializeField]
	private Image chipImage;

	[SerializeField]
	private TMP_Text bonus1Text;

	[SerializeField]
	private TMP_Text bonus2Text;

	[SerializeField]
	private GameObject bonus2Obj;

	[SerializeField]
	private ShowBuffDebuff showBuffDebuff10;

	[SerializeField]
	private ShowBuffDebuff showBuffDebuff11;

	[SerializeField]
	private ShowBuffDebuff showBuffDebuff20;

	[SerializeField]
	private ShowBuffDebuff showBuffDebuff21;

	private float grow;

	private int water;

	private int harvest;

	private int biofuel;

	private int earn;

	[Space]
	[SerializeField]
	private ShowBuffDebuff buffDebuffDays;

	[SerializeField]
	private ShowBuffDebuff buffDebuffWater;

	[SerializeField]
	private ShowBuffDebuff buffDebuffHarvest;

	[SerializeField]
	private ShowBuffDebuff buffDebuffBiofuel;

	[SerializeField]
	private ShowBuffDebuff buffDebuffSpareParts;

	private bool addedGrowBonus;

	private bool addedBiofuelBonus;

	private bool addedEarnBonus;

	private bool addedHarvestBonus;

	private bool addedWaterBonus;

	private bool addedCostBonus;

	private void Start()
	{
		SetBlank();
		if (verticalVersion && SaveData.ins.verticalMode)
		{
			ins = this;
		}
		else if (!verticalVersion && !SaveData.ins.verticalMode)
		{
			ins = this;
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	public void SetInfo(CropSO cropSO)
	{
		infoText.text = LocalizationSystem.GetLocalizedValue(cropSO.cropName);
		if (cropSO.cropDescription != "")
		{
			descText.text = LocalizationSystem.GetLocalizedValue(cropSO.cropDescription);
		}
		else
		{
			descText.text = "";
		}
		ConsolidateForVerticalMode();
		HideAllBuffs();
		grow = cropSO.growingDays;
		water = cropSO.waterDemand;
		harvest = cropSO.harvestMultiplier;
		biofuel = cropSO.biofuelYield;
		earn = cropSO.earnings;
		ShowChip(cropSO);
		growDuration.text = "<sprite index=3>: " + TimeFormatter(grow * 60f);
		wateringNeeds.text = "<sprite index=5>: x" + water;
		harvestTimes.text = "<sprite index=2>: x" + harvest;
		biofuelYield.text = "<sprite index=1>: +" + biofuel;
		sparePartsYield.text = "<sprite index=15>: +" + earn;
		if (SaveData.ins.focusMode)
		{
			growDuration.text = "<sprite index=3>: " + TimeFormatter(grow * 60f * 2f);
		}
		base.gameObject.SetActive(value: true);
	}

	private void ShowChip(CropSO cropSO)
	{
		CropManager.GMO gMO = GameManager.ins.getGMO(cropSO);
		if (gMO.tier != CropManager.GmoTier.None)
		{
			cropImage.sprite = GameManager.ins.getCropSprite(cropSO.cropType);
			chipImage.sprite = GameManager.ins.getChipSprite(gMO.tier);
			ResetAddedBonusChecks();
			string bonus = GetBonus1(gMO);
			string bonus2 = GetBonus2(gMO);
			bonus1Text.text = bonus;
			bonus2Text.text = bonus2;
			if (gMO.tier == CropManager.GmoTier.Rare)
			{
				bonus2Obj.SetActive(value: false);
			}
			else
			{
				bonus2Obj.SetActive(value: true);
			}
			chipObject.SetActive(value: true);
			ResizeTextBoxes(isShowingChip: true);
		}
		else
		{
			chipObject.SetActive(value: false);
			ResizeTextBoxes(isShowingChip: false);
		}
	}

	private void ConsolidateForVerticalMode()
	{
		if (!SaveData.ins.verticalMode)
		{
			return;
		}
		descText.gameObject.SetActive(value: false);
		string text = infoText.text;
		if (descText.text != "")
		{
			if (LocalizationSystem.language == LocalizationSystem.Language.PTBR)
			{
				text = text + ": " + descText.text;
			}
			else
			{
				text = "<voffset=0.2em>" + text;
				text = text + "</voffset><br>" + descText.text;
			}
		}
		infoText.text = text;
	}

	private void ResizeTextBoxes(bool isShowingChip)
	{
		if (verticalVersion && SaveData.ins.verticalMode)
		{
			if (isShowingChip)
			{
				SetRight(infoText.rectTransform, 256f);
				SetRight(descText.rectTransform, 256f);
			}
			else
			{
				SetRight(infoText.rectTransform, 140f);
				SetRight(descText.rectTransform, 140f);
			}
		}
	}

	public void SetRight(RectTransform rt, float right)
	{
		rt.offsetMax = new Vector2(0f - right, rt.offsetMax.y);
	}

	private string TimeFormatter(float seconds)
	{
		int num = Mathf.FloorToInt(seconds / 60f);
		int num2 = Mathf.FloorToInt(seconds % 60f);
		return $"{num:0}m:{num2:00}s";
	}

	private string GMOTimeFormatter(float seconds)
	{
		string text = "+";
		if (seconds < 0f)
		{
			text = "-";
		}
		seconds = Mathf.Abs(seconds);
		float num = Mathf.Floor(seconds % 60f * 100f) / 100f;
		int num2 = (int)(seconds / 60f) % 60;
		return text + $"{num2:0}m:{num:00}s";
	}

	public void SetInfoToHidden()
	{
		infoText.text = "";
		HideAllBuffs();
		growDuration.text = "<sprite index=3>: ?m:??s";
		wateringNeeds.text = "<sprite index=5>: ??";
		harvestTimes.text = "<sprite index=2>: ??";
		biofuelYield.text = "<sprite index=1>: ??";
		sparePartsYield.text = "<sprite index=15>: ??";
		descText.text = "";
		base.gameObject.SetActive(value: true);
	}

	public void SetRequirement(int index, CropSO cropRequirement, int cropRequirementAmount, int totalCropsHarvested)
	{
		cropsHarvestedDenominator[index].gameObject.SetActive(value: true);
		cropsHarvestedImage[index].gameObject.SetActive(value: true);
		cropsHarvestedProgressBar[index].gameObject.SetActive(value: true);
		requirementsBackground[index].gameObject.SetActive(value: true);
		requirementsMetTick[index].gameObject.SetActive(value: true);
		cropsHarvestedDenominator[index].text = "<color=#181818>" + totalCropsHarvested + "</color>/" + cropRequirementAmount;
		cropsHarvestedImage[index].sprite = cropRequirement.cropSprite;
		cropsHarvestedProgressBar[index].maxValue = cropRequirementAmount;
		cropsHarvestedProgressBar[index].value = totalCropsHarvested;
		if (GameManager.ins.cropManager.cropUnlocked[cropRequirement.cropIndexInList])
		{
			cropsHarvestedImage[index].color = Color.white;
		}
		else
		{
			cropsHarvestedImage[index].color = GameManager.ins.lockedC;
		}
		if (totalCropsHarvested >= cropRequirementAmount)
		{
			requirementsMetTick[index].sprite = tick;
		}
		else
		{
			requirementsMetTick[index].sprite = noTick;
		}
	}

	public void HideRequirement(int index)
	{
		cropsHarvestedText[index].gameObject.SetActive(value: false);
		cropsHarvestedDenominator[index].gameObject.SetActive(value: false);
		cropsHarvestedImage[index].gameObject.SetActive(value: false);
		cropsHarvestedProgressBar[index].gameObject.SetActive(value: false);
		requirementsBackground[index].gameObject.SetActive(value: false);
		requirementsMetTick[index].gameObject.SetActive(value: false);
	}

	public void HideAllRequirements()
	{
		for (int i = 0; i < 4; i++)
		{
			HideRequirement(i);
		}
	}

	private void ResetAddedBonusChecks()
	{
		addedGrowBonus = false;
		addedBiofuelBonus = false;
		addedEarnBonus = false;
		addedHarvestBonus = false;
		addedWaterBonus = false;
		addedCostBonus = false;
	}

	private string GetBonus1(CropManager.GMO gmo)
	{
		string text = "+";
		showBuffDebuff10.Neutral();
		showBuffDebuff11.Neutral();
		if (gmo.grow != 0f)
		{
			grow += gmo.grow;
			addedGrowBonus = true;
			if (gmo.grow < 0f)
			{
				text = "";
			}
			if (gmo.grow < 0f)
			{
				buffDebuffDays.Buff();
				showBuffDebuff10.Buff();
				showBuffDebuff11.Buff();
			}
			else
			{
				buffDebuffDays.Debuff();
				showBuffDebuff10.Debuff();
				showBuffDebuff11.Debuff();
			}
			return GMOTimeFormatter(gmo.grow * 60f);
		}
		if (gmo.biofuel != 0)
		{
			biofuel += gmo.biofuel;
			addedBiofuelBonus = true;
			if (gmo.biofuel < 0)
			{
				text = "";
			}
			if (gmo.biofuel < 0)
			{
				buffDebuffBiofuel.Debuff();
				showBuffDebuff10.Debuff();
				showBuffDebuff11.Debuff();
			}
			else
			{
				buffDebuffBiofuel.Buff();
				showBuffDebuff10.Buff();
				showBuffDebuff11.Buff();
			}
			return "<sprite index=1>: " + text + gmo.biofuel;
		}
		if (gmo.earnings != 0)
		{
			earn += gmo.earnings;
			addedEarnBonus = true;
			if (gmo.earnings < 0)
			{
				text = "";
			}
			if (gmo.earnings < 0)
			{
				buffDebuffSpareParts.Debuff();
				showBuffDebuff10.Debuff();
				showBuffDebuff11.Debuff();
			}
			else
			{
				buffDebuffSpareParts.Buff();
				showBuffDebuff10.Buff();
				showBuffDebuff11.Buff();
			}
			return "<sprite index=15>: " + text + gmo.earnings;
		}
		if (gmo.harvest != 0)
		{
			harvest += gmo.harvest;
			addedHarvestBonus = true;
			if (gmo.harvest < 0)
			{
				text = "";
			}
			if (gmo.harvest < 0)
			{
				buffDebuffHarvest.Debuff();
				showBuffDebuff10.Debuff();
				showBuffDebuff11.Debuff();
			}
			else
			{
				buffDebuffHarvest.Buff();
				showBuffDebuff10.Buff();
				showBuffDebuff11.Buff();
			}
			return "<sprite index=2>: " + text + gmo.harvest;
		}
		if (gmo.water != 0)
		{
			water += gmo.water;
			addedWaterBonus = true;
			if (gmo.water < 0)
			{
				text = "";
			}
			if (gmo.water < 0)
			{
				buffDebuffWater.Buff();
				showBuffDebuff10.Buff();
				showBuffDebuff11.Buff();
			}
			else
			{
				buffDebuffWater.Debuff();
				showBuffDebuff10.Debuff();
				showBuffDebuff11.Debuff();
			}
			return "<sprite index=5>: " + text + gmo.water;
		}
		return "-";
	}

	private string GetBonus2(CropManager.GMO gmo)
	{
		string text = "+";
		showBuffDebuff20.Neutral();
		showBuffDebuff21.Neutral();
		if (gmo.water != 0 && !addedWaterBonus)
		{
			water += gmo.water;
			if (gmo.water < 0)
			{
				text = "";
			}
			if (gmo.water < 0)
			{
				buffDebuffWater.Buff();
				showBuffDebuff20.Buff();
				showBuffDebuff21.Buff();
			}
			else
			{
				buffDebuffWater.Debuff();
				showBuffDebuff20.Debuff();
				showBuffDebuff21.Debuff();
			}
			return "<sprite index=5>: " + text + gmo.water;
		}
		if (gmo.harvest != 0 && !addedHarvestBonus)
		{
			harvest += gmo.harvest;
			if (gmo.harvest < 0)
			{
				text = "";
			}
			if (gmo.harvest < 0)
			{
				buffDebuffHarvest.Debuff();
				showBuffDebuff20.Debuff();
				showBuffDebuff21.Debuff();
			}
			else
			{
				buffDebuffHarvest.Buff();
				showBuffDebuff20.Buff();
				showBuffDebuff21.Buff();
			}
			return "<sprite index=2>: " + text + gmo.harvest;
		}
		if (gmo.earnings != 0 && !addedEarnBonus)
		{
			earn += gmo.earnings;
			if (gmo.earnings < 0)
			{
				text = "";
			}
			if (gmo.earnings < 0)
			{
				buffDebuffSpareParts.Debuff();
				showBuffDebuff20.Debuff();
				showBuffDebuff21.Debuff();
			}
			else
			{
				buffDebuffSpareParts.Buff();
				showBuffDebuff20.Buff();
				showBuffDebuff21.Buff();
			}
			return "<sprite index=15>: " + text + gmo.earnings;
		}
		if (gmo.biofuel != 0 && !addedBiofuelBonus)
		{
			biofuel += gmo.biofuel;
			if (gmo.biofuel < 0)
			{
				text = "";
			}
			if (gmo.biofuel < 0)
			{
				buffDebuffBiofuel.Debuff();
				showBuffDebuff20.Debuff();
				showBuffDebuff21.Debuff();
			}
			else
			{
				buffDebuffBiofuel.Buff();
				showBuffDebuff20.Buff();
				showBuffDebuff21.Buff();
			}
			return "<sprite index=1>: " + text + gmo.biofuel;
		}
		if (gmo.grow != 0f && !addedGrowBonus)
		{
			grow += gmo.grow;
			if (gmo.grow < 0f)
			{
				text = "";
			}
			if (gmo.grow < 0f)
			{
				buffDebuffDays.Buff();
				showBuffDebuff20.Buff();
				showBuffDebuff21.Buff();
			}
			else
			{
				buffDebuffDays.Debuff();
				showBuffDebuff20.Debuff();
				showBuffDebuff21.Debuff();
			}
			return GMOTimeFormatter(gmo.grow * 60f);
		}
		return "-";
	}

	private void HideAllBuffs()
	{
		buffDebuffDays.Neutral();
		buffDebuffWater.Neutral();
		buffDebuffHarvest.Neutral();
		buffDebuffBiofuel.Neutral();
		buffDebuffSpareParts.Neutral();
	}

	public void SetBlank()
	{
		infoText.text = "";
		HideAllBuffs();
		growDuration.text = "";
		wateringNeeds.text = "";
		biofuelYield.text = "";
		sparePartsYield.text = "";
		base.gameObject.SetActive(value: false);
		HideAllRequirements();
		descText.text = "";
	}

	public void MoveToRightSide()
	{
		if (!SaveData.ins.verticalMode)
		{
			rectTransform.anchoredPosition = new Vector2(-112f, 0f);
		}
	}

	public void MoveToLeftSide()
	{
		if (!SaveData.ins.verticalMode)
		{
			rectTransform.anchoredPosition = new Vector2(-112f, 0f);
		}
	}
}
