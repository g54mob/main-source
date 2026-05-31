using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChipButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public enum Stat
	{
		None = 0,
		Grow = 1,
		Water = 2,
		Biofuel = 3,
		Harvest = 4,
		Earnings = 5
	}

	public bool hidden;

	[SerializeField]
	private Image cropImage;

	[SerializeField]
	private Image chipImage;

	[SerializeField]
	private GameObject chipShine;

	private Sprite cropSprite;

	[SerializeField]
	private GameObject cropNameObject;

	[SerializeField]
	private TMP_Text nameText;

	[SerializeField]
	private TMP_Text costText;

	[SerializeField]
	private GameObject bonus1;

	[SerializeField]
	private GameObject bonus2;

	[SerializeField]
	private TMP_Text bonusText1;

	[SerializeField]
	private TMP_Text bonusText2;

	[SerializeField]
	private TooltipTrigger tooltipTrigger1;

	[SerializeField]
	private TooltipTrigger tooltipTrigger2;

	private string growTooltip = "_GMO_GROW_TIME";

	private string waterTooltip = "_GMO_WATER_NEEDS";

	private string harvestTooltip = "_GMO_REGROW_CYCLE";

	private string biofuelTooltip = "_GMO_BIOFUEL";

	private string earningsTooltip = "_GMO_EARNINGS";

	[SerializeField]
	private ShowBuffDebuff showBuffDebuff10;

	[SerializeField]
	private ShowBuffDebuff showBuffDebuff11;

	[SerializeField]
	private ShowBuffDebuff showBuffDebuff20;

	[SerializeField]
	private ShowBuffDebuff showBuffDebuff21;

	[SerializeField]
	private Transform areYouSurePos;

	[Header("Lock buttons")]
	[SerializeField]
	private Image lockButtonImage;

	[SerializeField]
	private Sprite lockedSprite;

	[SerializeField]
	private Sprite unlockedSprite;

	public bool locked;

	[Header("GMO")]
	public CropSO currentCrop;

	public CropManager.GMO currentGMOstats;

	public int currentGMOprice;

	public Stat currentGMOstat1;

	public Stat currentGMOstat2;

	private float growMultiplierMax = -0.2f;

	private float growMultiplierMin = -0.05f;

	private float waterMultiplierMax = -0.3f;

	private float waterMultiplierMin = -0.1f;

	private float biofuelMultiplierMax = 0.25f;

	private float biofuelMultiplierMin = 0.1f;

	private float harvestMultiplierMax = 0.25f;

	private float harvestMultiplierMin = 0.1f;

	private float earningsMultiplierMax = 0.75f;

	private float earningsMultiplierMin = 0.1f;

	private float commonMultiplier = 1f;

	private float rareMultiplier = 1.25f;

	private float legendaryMultiplier = 1.5f;

	private float uberMultiplier = 1.75f;

	public void CreateRandomGMOfor(CropSO cropSO)
	{
		currentCrop = cropSO;
		currentGMOstats = default(CropManager.GMO);
		float value = Random.value;
		if (value < 0.4f)
		{
			CreateCommonGMO(currentCrop);
		}
		else if (value < 0.79f)
		{
			CreateRareGMO(currentCrop);
		}
		else if (value < 0.99f)
		{
			CreateLegendaryGMO(currentCrop);
		}
		else
		{
			CreateUberGMO(currentCrop);
		}
	}

	private void CreateCommonGMO(CropSO cropSO)
	{
		currentGMOstats.tier = CropManager.GmoTier.Common;
		PickRandomStat(Stat.None, out currentGMOstat1);
		PickRandomStat(Stat.Biofuel, currentGMOstat1, out currentGMOstat2);
		RandomizeStat(cropSO, currentGMOstat1, buff: true);
		RandomizeStat(cropSO, currentGMOstat2, buff: false);
		SetChipInfo(cropSO, currentGMOstat1, currentGMOstat2);
	}

	private void CreateRareGMO(CropSO cropSO)
	{
		currentGMOstats.tier = CropManager.GmoTier.Rare;
		PickRandomStat(Stat.None, out currentGMOstat1);
		currentGMOstat2 = Stat.None;
		RandomizeStat(cropSO, currentGMOstat1, buff: true);
		SetChipInfo(cropSO, currentGMOstat1, currentGMOstat2);
	}

	private void CreateLegendaryGMO(CropSO cropSO)
	{
		currentGMOstats.tier = CropManager.GmoTier.Legendary;
		PickRandomStat(Stat.None, out currentGMOstat1);
		PickRandomStat(currentGMOstat1, out currentGMOstat2);
		RandomizeStat(cropSO, currentGMOstat1, buff: true);
		RandomizeStat(cropSO, currentGMOstat2, buff: true);
		SetChipInfo(cropSO, currentGMOstat1, currentGMOstat2);
	}

	private void CreateUberGMO(CropSO cropSO)
	{
		currentGMOstats.tier = CropManager.GmoTier.Uber;
		PickRandomStat(Stat.Harvest, Stat.None, out currentGMOstat1);
		PickRandomStat(Stat.Harvest, currentGMOstat1, out currentGMOstat2);
		MaximizeStat(cropSO, currentGMOstat1);
		MaximizeStat(cropSO, currentGMOstat2);
		SetChipInfo(cropSO, currentGMOstat1, currentGMOstat2);
	}

	private void PickRandomStat(Stat excludingStat, out Stat resultStat)
	{
		List<Stat> list = new List<Stat>
		{
			Stat.Grow,
			Stat.Water,
			Stat.Biofuel,
			Stat.Harvest,
			Stat.Earnings
		};
		list.Remove(excludingStat);
		resultStat = list[Random.Range(0, list.Count)];
	}

	private void PickRandomStat(Stat excludingStat1, Stat excludingStat2, out Stat resultStat)
	{
		List<Stat> list = new List<Stat>
		{
			Stat.Grow,
			Stat.Water,
			Stat.Biofuel,
			Stat.Harvest,
			Stat.Earnings
		};
		list.Remove(excludingStat1);
		list.Remove(excludingStat2);
		resultStat = list[Random.Range(0, list.Count)];
	}

	private void RandomizeStat(CropSO cropSO, Stat stat, bool buff)
	{
		float num = 1f;
		if (!buff)
		{
			num = -0.5f;
		}
		float num2 = 1f;
		switch (stat)
		{
		case Stat.Grow:
			num2 = Random.Range(growMultiplierMax, growMultiplierMin);
			currentGMOstats.grow = cropSO.growingDays * (num * num2);
			if (buff)
			{
				if (currentGMOstats.grow > -0.167f)
				{
					currentGMOstats.grow = -0.167f;
				}
			}
			else if (!buff && currentGMOstats.grow < 0.167f)
			{
				currentGMOstats.grow = 0.167f;
			}
			break;
		case Stat.Water:
			num2 = Random.Range(waterMultiplierMax, waterMultiplierMin);
			currentGMOstats.water = Mathf.FloorToInt((float)cropSO.waterDemand * (num * num2));
			if (buff)
			{
				if (currentGMOstats.water > -1)
				{
					currentGMOstats.water = -1;
				}
			}
			else if (!buff && currentGMOstats.water < 1)
			{
				currentGMOstats.water = 1;
			}
			break;
		case Stat.Biofuel:
			num2 = Random.Range(biofuelMultiplierMax, biofuelMultiplierMin);
			currentGMOstats.biofuel = Mathf.FloorToInt((float)cropSO.biofuelYield * (num * num2));
			if (buff)
			{
				if (currentGMOstats.biofuel < 1)
				{
					currentGMOstats.biofuel = 1;
				}
			}
			else if (!buff && currentGMOstats.biofuel > -1)
			{
				currentGMOstats.biofuel = -1;
			}
			break;
		case Stat.Harvest:
			num2 = Random.Range(harvestMultiplierMax, harvestMultiplierMin);
			currentGMOstats.harvest = Mathf.FloorToInt((float)cropSO.harvestMultiplier * (num * num2));
			if (buff)
			{
				if (currentGMOstats.harvest < 1)
				{
					currentGMOstats.harvest = 1;
				}
			}
			else if (!buff && currentGMOstats.harvest > -1)
			{
				currentGMOstats.harvest = -1;
			}
			break;
		case Stat.Earnings:
			num2 = Random.Range(earningsMultiplierMax, earningsMultiplierMin);
			currentGMOstats.earnings = Mathf.FloorToInt((float)cropSO.earnings * (num * num2));
			if (buff)
			{
				if (currentGMOstats.earnings < 1)
				{
					currentGMOstats.earnings = 1;
				}
			}
			else if (!buff && currentGMOstats.earnings > -1)
			{
				currentGMOstats.earnings = -1;
			}
			break;
		}
	}

	private void MaximizeStat(CropSO cropSO, Stat stat)
	{
		float num = 1f;
		switch (stat)
		{
		case Stat.Grow:
			currentGMOstats.grow = cropSO.growingDays * (num * growMultiplierMax);
			break;
		case Stat.Water:
			currentGMOstats.water = Mathf.FloorToInt((float)cropSO.waterDemand * (num * waterMultiplierMax));
			break;
		case Stat.Biofuel:
			currentGMOstats.biofuel = Mathf.CeilToInt((float)cropSO.biofuelYield * (num * biofuelMultiplierMax));
			break;
		case Stat.Harvest:
			currentGMOstats.harvest = Mathf.CeilToInt((float)cropSO.harvestMultiplier * (num * harvestMultiplierMax));
			break;
		case Stat.Earnings:
			currentGMOstats.earnings = Mathf.CeilToInt((float)cropSO.earnings * (num * earningsMultiplierMax));
			break;
		}
	}

	public void SetChipInfo()
	{
		SetChipInfo(currentCrop, currentGMOstat1, currentGMOstat2);
	}

	private void SetChipInfo(CropSO cropSO, Stat stat1, Stat stat2)
	{
		cropSprite = cropSO.cropSprite;
		cropImage.sprite = cropSprite;
		UpdateChipImage();
		nameText.text = LocalizationSystem.GetLocalizedValue(cropSO.cropName);
		SetGMOprice(cropSO);
		UpdateStatText(bonus1, bonusText1, stat1);
		UpdateStatText(bonus2, bonusText2, stat2);
		SetTooltip(stat1, tooltipTrigger1);
		SetTooltip(stat2, tooltipTrigger2);
		CheckLockedSprite();
		SetBuffDebuff(currentGMOstats.tier);
	}

	private void SetTooltip(Stat stat, TooltipTrigger tooltip)
	{
		if (stat == Stat.Grow)
		{
			tooltip.tip = growTooltip;
		}
		if (stat == Stat.Water)
		{
			tooltip.tip = waterTooltip;
		}
		if (stat == Stat.Biofuel)
		{
			tooltip.tip = biofuelTooltip;
		}
		if (stat == Stat.Harvest)
		{
			tooltip.tip = harvestTooltip;
		}
		if (stat == Stat.Earnings)
		{
			tooltip.tip = earningsTooltip;
		}
	}

	private void SetGMOprice(CropSO cropSO)
	{
		int num = Inventory.ins.getCropIndexInCropInventoryPanel(cropSO.cropType);
		if (cropSO.cropType == CropType.GreenChiliPepper)
		{
			num = 44;
		}
		if (num == -1)
		{
			costText.text = "<sprite index=0>???";
			return;
		}
		int num2 = 0;
		float p = 0f;
		if (currentGMOstats.tier == CropManager.GmoTier.Common)
		{
			num2 = 50;
			p = 2.2f;
		}
		if (currentGMOstats.tier == CropManager.GmoTier.Rare)
		{
			num2 = 65;
			p = 2.3f;
		}
		if (currentGMOstats.tier == CropManager.GmoTier.Legendary)
		{
			num2 = 80;
			p = 2.4f;
		}
		if (currentGMOstats.tier == CropManager.GmoTier.Uber)
		{
			num2 = 100;
			p = 2.5f;
		}
		int num3 = Mathf.CeilToInt((float)num2 + Mathf.Pow((float)num + 2f, p));
		if (num3 > 200)
		{
			num3 = Mathf.FloorToInt(num3 / 10) * 10;
		}
		if (num3 > 2000)
		{
			num3 = Mathf.FloorToInt(num3 / 100) * 100;
		}
		currentGMOprice = num3;
		costText.text = "<sprite index=0>" + currentGMOprice;
	}

	private void SetBuffDebuff(ShowBuffDebuff showBuffDebuff, bool buff, bool debuff)
	{
		if (buff)
		{
			showBuffDebuff.Buff();
			showBuffDebuff.Buff();
		}
		else if (debuff)
		{
			showBuffDebuff.Debuff();
			showBuffDebuff.Debuff();
		}
		else
		{
			showBuffDebuff.Neutral();
			showBuffDebuff.Neutral();
		}
	}

	private void SetBuffDebuff(CropManager.GmoTier tier)
	{
		if (tier == CropManager.GmoTier.Legendary || tier == CropManager.GmoTier.Uber)
		{
			showBuffDebuff10.Buff();
			showBuffDebuff11.Buff();
			showBuffDebuff20.Buff();
			showBuffDebuff21.Buff();
		}
		if (tier == CropManager.GmoTier.Rare)
		{
			showBuffDebuff10.Buff();
			showBuffDebuff11.Buff();
			showBuffDebuff20.Neutral();
			showBuffDebuff21.Neutral();
		}
		if (tier == CropManager.GmoTier.Common)
		{
			showBuffDebuff10.Buff();
			showBuffDebuff11.Buff();
			showBuffDebuff20.Debuff();
			showBuffDebuff21.Debuff();
		}
		if (tier == CropManager.GmoTier.Uber)
		{
			chipShine.SetActive(value: true);
		}
		else
		{
			chipShine.SetActive(value: false);
		}
	}

	private void UpdateChipImage()
	{
		chipImage.sprite = GameManager.ins.getChipSprite(currentGMOstats.tier);
	}

	private void UpdateStatText(GameObject statObj, TMP_Text textField, Stat statN)
	{
		string text = "+";
		statObj.SetActive(value: true);
		if (statN == Stat.None)
		{
			statObj.SetActive(value: false);
		}
		if (statN == Stat.Grow)
		{
			textField.text = TimeFormatter(currentGMOstats.grow * 60f);
		}
		if (statN == Stat.Water)
		{
			if (currentGMOstats.water < 0)
			{
				text = "";
			}
			textField.text = "<sprite index=5>: " + text + currentGMOstats.water;
		}
		if (statN == Stat.Biofuel)
		{
			if (currentGMOstats.biofuel < 0)
			{
				text = "";
			}
			textField.text = "<sprite index=1>: " + text + currentGMOstats.biofuel;
		}
		if (statN == Stat.Earnings)
		{
			if (currentGMOstats.earnings < 0)
			{
				text = "";
			}
			textField.text = "<sprite index=15>: " + text + currentGMOstats.earnings;
		}
		if (statN == Stat.Harvest)
		{
			if (currentGMOstats.harvest < 0)
			{
				text = "";
			}
			textField.text = "<sprite index=2>: " + text + currentGMOstats.harvest;
		}
	}

	public void SelectGMO()
	{
		if (!hidden && currentGMOstats.tier != CropManager.GmoTier.None)
		{
			if (Inventory.ins.spareParts < currentGMOprice)
			{
				Inventory.ins.NotEnoughSpareparts();
				SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			}
			else
			{
				AreYouSure.ins.SpawnOn(this, areYouSurePos);
				SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
			}
		}
	}

	public void PurchaseChip()
	{
		if (Inventory.ins.spareParts < currentGMOprice)
		{
			Inventory.ins.NotEnoughSpareparts();
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			return;
		}
		Inventory.ins.AddSpareParts(-currentGMOprice);
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
		for (int i = 0; i < GameManager.ins.cropManager.cropCatalog.Length; i++)
		{
			if (GameManager.ins.cropManager.cropCatalog[i].cropType == currentCrop.cropType)
			{
				GameManager.ins.cropManager.SetGMOStatTo(i, currentGMOstats);
				break;
			}
		}
		Inventory.ins.UpdateCropChipIcons();
		AddHarvestBoostImmediately();
		HideSelectedChip();
		TooltipSystem.Hide();
		CropInfoPanel.ins.SetBlank();
		AchievementManager.ins.BuyGMO(currentGMOstats.tier);
		AchievementManager.ins.CheckGMOsOnCrops();
		locked = false;
		CheckLockedSprite();
	}

	private void AddHarvestBoostImmediately()
	{
		if (currentGMOstats.harvest == 0)
		{
			return;
		}
		for (int i = 0; i < GameManager.ins.cropSlots.Count; i++)
		{
			if (GameManager.ins.cropSlots[i].cropType == currentCrop.cropType)
			{
				GameManager.ins.cropSlots[i].AddHarvestMultiplier(currentGMOstats.harvest);
			}
		}
	}

	private void HideSelectedChip()
	{
		hidden = true;
		base.transform.DOScaleY(0f, 0.25f).SetEase(Ease.InBack).OnComplete(CheckSoldChips);
		HideLockedButton();
	}

	private void CheckSoldChips()
	{
		GameManager.ins.reaperShopPanel.CheckIfAllChipsHaveBeenPurchased();
	}

	private void ResetSelectedChip()
	{
		hidden = false;
		currentCrop = null;
		currentGMOstats = default(CropManager.GMO);
		currentGMOprice = 0;
		HideLockedButton();
	}

	public void Reroll()
	{
		if (!locked)
		{
			ResetSelectedChip();
		}
	}

	private string TimeFormatter(float seconds)
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

	public void LockGMO()
	{
		locked = !locked;
		CheckLockedSprite();
	}

	private void CheckLockedSprite()
	{
		if (locked)
		{
			lockButtonImage.sprite = lockedSprite;
		}
		else
		{
			lockButtonImage.sprite = unlockedSprite;
		}
	}

	private void HideLockedButton()
	{
		if (hidden)
		{
			lockButtonImage.gameObject.SetActive(value: false);
		}
		else
		{
			lockButtonImage.gameObject.SetActive(value: true);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		cropNameObject.SetActive(value: true);
		if ((bool)currentCrop)
		{
			CropInfoPanel.ins.SetInfo(currentCrop);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		cropNameObject.SetActive(value: false);
		CropInfoPanel.ins.SetBlank();
	}
}
