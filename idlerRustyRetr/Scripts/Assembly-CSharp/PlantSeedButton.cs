using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlantSeedButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public CropType cropType;

	private CropSO cropSO;

	public int seedAmount;

	public int cropAmount;

	public bool isUnlocked;

	public bool canUnlock;

	private bool isHoveringOver;

	[Header("References")]
	[SerializeField]
	private Image cropLogo;

	[SerializeField]
	private Image chipLogo;

	[SerializeField]
	private Image buttonBackground;

	[SerializeField]
	private Color canUnlockColor;

	[SerializeField]
	private TMP_Text seedAmountText;

	[SerializeField]
	private TMP_Text cropAmountText;

	[SerializeField]
	private TMP_Text costAmountText;

	[SerializeField]
	private AudioClip unlockSound;

	[Header("Overrides")]
	[SerializeField]
	private Image otherLogo;

	public Decoration bushDecoration;

	public void Initialize()
	{
		StorePrivateVariables();
		UpdateVisual();
		UpdateChipIcon();
	}

	private void StorePrivateVariables()
	{
		cropSO = GameManager.ins.getCropSO(cropType);
	}

	public CropSO getCropSO()
	{
		if ((bool)cropSO)
		{
			return cropSO;
		}
		return null;
	}

	private void UpdateVisual()
	{
		cropLogo.sprite = cropSO.cropSprite;
	}

	public void UpdateChipIcon()
	{
		CropManager.GmoTier tier = GameManager.ins.cropManager.cropGmoStats[cropSO.cropIndexInList].tier;
		if (tier != CropManager.GmoTier.None)
		{
			chipLogo.gameObject.SetActive(value: true);
			chipLogo.sprite = GameManager.ins.getChipMiniSprite(tier);
		}
		else
		{
			chipLogo.gameObject.SetActive(value: false);
		}
	}

	public void UpdateSeedAmountText()
	{
		seedAmountText.text = seedAmount.ToString();
	}

	public void UpdateCropAmountText()
	{
		cropAmountText.text = seedAmount.ToString();
	}

	public void AddCropHarvestedToTotalAmount()
	{
		GameManager.ins.cropManager.cropsHarvested[cropSO.cropIndexInList]++;
	}

	public void UpdateRequirementsStatus()
	{
		if (isHoveringOver)
		{
			SetRequirementsInInfoPanel();
		}
	}

	public void CalculateLockedState()
	{
		if (GameManager.ins.cropManager.cropUnlocked[cropSO.cropIndexInList])
		{
			isUnlocked = true;
			canUnlock = false;
			SetToUnlocked();
			Inventory.ins.CheckAllCropsUnlocked();
			Inventory.ins.CheckAllBerriesUnlocked();
			return;
		}
		isUnlocked = false;
		canUnlock = true;
		if (cropSO.requirement1 != null && cropSO.requirementAmount1 > GameManager.ins.cropManager.cropsHarvested[cropSO.requirement1.cropIndexInList])
		{
			canUnlock = false;
		}
		if (cropSO.requirement2 != null && cropSO.requirementAmount2 > GameManager.ins.cropManager.cropsHarvested[cropSO.requirement2.cropIndexInList])
		{
			canUnlock = false;
		}
		if (cropSO.requirement3 != null && cropSO.requirementAmount3 > GameManager.ins.cropManager.cropsHarvested[cropSO.requirement3.cropIndexInList])
		{
			canUnlock = false;
		}
		if (cropSO.requirement4 != null && cropSO.requirementAmount4 > GameManager.ins.cropManager.cropsHarvested[cropSO.requirement4.cropIndexInList])
		{
			canUnlock = false;
		}
		if (!canUnlock)
		{
			SetToLocked();
		}
		else
		{
			SetToCanUnlock();
		}
	}

	private void SetToLocked()
	{
		seedAmountText.text = "";
		cropLogo.color = GameManager.ins.lockedC;
		cropAmountText.text = "";
		costAmountText.text = "<sprite index=7>";
		buttonBackground.color = Color.white;
		if ((bool)otherLogo)
		{
			otherLogo.color = GameManager.ins.lockedC;
		}
	}

	private void SetToCanUnlock()
	{
		seedAmountText.text = "";
		cropLogo.color = GameManager.ins.lockedC;
		cropAmountText.text = "";
		costAmountText.text = "<sprite index=6>";
		buttonBackground.color = canUnlockColor;
		if ((bool)otherLogo)
		{
			otherLogo.color = GameManager.ins.lockedC;
		}
		Inventory.ins.CheckNewCropBerryIcon();
	}

	private void SetToUnlocked()
	{
		seedAmountText.text = seedAmount.ToString();
		cropLogo.color = Color.white;
		cropAmountText.text = cropAmount.ToString();
		costAmountText.text = "<sprite index=0>" + cropSO.cropCost;
		buttonBackground.color = Color.white;
		if ((bool)otherLogo)
		{
			otherLogo.color = Color.white;
		}
		if ((bool)bushDecoration)
		{
			costAmountText.text = "<sprite index=1>" + bushDecoration.biofuel + "<br><sprite index=0>" + bushDecoration.spareParts;
		}
	}

	public void SelectSeedToPlant_OLD()
	{
		if (seedAmount <= 0)
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			TooltipSystem.HideIcontip();
			return;
		}
		GameManager.ins.SetCurrentCropSelectedTo(cropType);
		GameManager.ins.state = GameManager.State.CanPlantSeed;
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
		TooltipSystem.ShowIcontip(cropSO.spriteList[0]);
	}

	public void SelectSeedToPlant()
	{
		if (canUnlock)
		{
			isUnlocked = true;
			canUnlock = false;
			GameManager.ins.SetCropUnlocked(cropType, state: true);
			CalculateLockedState();
			DisableNewCropBerryIcon();
			SoundManager.ins.PlaySound(unlockSound);
		}
		if (!isUnlocked)
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			TooltipSystem.HideIcontip();
		}
		else if (Inventory.ins.spareParts < cropSO.cropCost)
		{
			Inventory.ins.NotEnoughSpareparts();
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			TooltipSystem.HideIcontip();
		}
		else
		{
			GameManager.ins.SetCurrentCropSelectedTo(cropType);
			GameManager.ins.state = GameManager.State.CanPlantSeed;
			SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
			TooltipSystem.ShowIcontip(cropSO.spriteList[0]);
		}
	}

	public void SelectBushToPlant()
	{
		if ((bool)bushDecoration)
		{
			if (canUnlock)
			{
				isUnlocked = true;
				canUnlock = false;
				GameManager.ins.SetCropUnlocked(cropType, state: true);
				CalculateLockedState();
				DisableNewCropBerryIcon();
				SoundManager.ins.PlaySound(unlockSound);
			}
			if (!isUnlocked)
			{
				SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
				TooltipSystem.HideIcontip();
				return;
			}
			if (!DoesPlayerHaveResources(bushDecoration.spareParts, bushDecoration.biofuel))
			{
				SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
				TooltipSystem.HideIcontip();
				return;
			}
			GameManager.ins.decorSelected = bushDecoration;
			GameManager.ins.state = GameManager.State.CanDecorate;
			SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
			TooltipSystem.HideIcontip();
		}
	}

	private void DisableNewCropBerryIcon()
	{
		if ((bool)bushDecoration)
		{
			Inventory.ins.ShowNewBerryIcon(active: false);
		}
		else
		{
			Inventory.ins.ShowNewCropIcon(active: false);
		}
		Inventory.ins.CheckNewCropBerryIcon();
	}

	private bool DoesPlayerHaveResources(int sparePartsCost, int biofuelCost)
	{
		if (Inventory.ins.spareParts < sparePartsCost)
		{
			return false;
		}
		if (Inventory.ins.biofuel < biofuelCost)
		{
			return false;
		}
		return true;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		CropInfoPanel.ins.SetInfo(cropSO);
		SetRequirementsInInfoPanel();
		isHoveringOver = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		CropInfoPanel.ins.SetBlank();
		isHoveringOver = false;
	}

	private void SetRequirementsInInfoPanel()
	{
		if (isUnlocked)
		{
			CropInfoPanel.ins.HideAllRequirements();
			return;
		}
		CropInfoPanel.ins.SetInfoToHidden();
		if (cropSO.requirement1 != null)
		{
			CropInfoPanel.ins.SetRequirement(0, cropSO.requirement1, cropSO.requirementAmount1, GameManager.ins.cropManager.cropsHarvested[cropSO.requirement1.cropIndexInList]);
		}
		else
		{
			CropInfoPanel.ins.HideRequirement(0);
		}
		if (cropSO.requirement2 != null)
		{
			CropInfoPanel.ins.SetRequirement(1, cropSO.requirement2, cropSO.requirementAmount2, GameManager.ins.cropManager.cropsHarvested[cropSO.requirement2.cropIndexInList]);
		}
		else
		{
			CropInfoPanel.ins.HideRequirement(1);
		}
		if (cropSO.requirement3 != null)
		{
			CropInfoPanel.ins.SetRequirement(2, cropSO.requirement3, cropSO.requirementAmount3, GameManager.ins.cropManager.cropsHarvested[cropSO.requirement3.cropIndexInList]);
		}
		else
		{
			CropInfoPanel.ins.HideRequirement(2);
		}
		if (cropSO.requirement4 != null)
		{
			CropInfoPanel.ins.SetRequirement(3, cropSO.requirement4, cropSO.requirementAmount4, GameManager.ins.cropManager.cropsHarvested[cropSO.requirement4.cropIndexInList]);
		}
		else
		{
			CropInfoPanel.ins.HideRequirement(3);
		}
	}
}
