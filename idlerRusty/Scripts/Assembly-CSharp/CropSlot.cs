using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CropSlot : MonoBehaviour, ICropSlot, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler, IDragHandler
{
	public enum State
	{
		Empty = 0,
		NeedWater = 1,
		IsGrowing = 2,
		NeedHarvest = 3,
		MarkedForWatering = 4,
		MarkedForHarvest = 5,
		GiantCrop = 6,
		MarkedForSeeding = 7,
		Fossil = 8
	}

	public State state;

	[SerializeField]
	private float progressRemaining;

	public List<float> waterAtProgressMark;

	private float totalGrowthTimer;

	private float growthTimer;

	private Sprite[] sprites;

	private BoxCollider2D coll;

	[Header("Crop")]
	private CropSO cropSO;

	private int harvestMultiplier;

	public CropType cropType;

	public SpriteRenderer cropVisual;

	[SerializeField]
	private GameObject highlight;

	public CropPatch cropPatchParent;

	[SerializeField]
	private bool randomizeStartPos = true;

	private bool canDie;

	private float killTimer;

	private float killTime = 120f;

	[Header("Giant crop")]
	[SerializeField]
	private bool chanceToSpawnGiant3x3;

	[SerializeField]
	private CropSlot[] surroundingSlots3x3;

	[SerializeField]
	private bool chanceToSpawnGiant2x2;

	[SerializeField]
	private CropSlot[] surroundingSlots2x2;

	[Header("Dirt")]
	[SerializeField]
	private SpriteRenderer dirtSprite;

	private Sprite notWateredSprite;

	[SerializeField]
	private Sprite wateredSprite;

	[SerializeField]
	private SpriteRenderer fertilizedSprite;

	public float fertilizedTimer;

	public bool markedForFertilizing;

	[Header("Chicken")]
	public bool improvedRegrowthCycle;

	public bool markedForImprovement;

	[Header("Sounds")]
	[SerializeField]
	private AudioClip plantSeedAudio;

	private float deltaTime;

	public CropType _CropType
	{
		get
		{
			return cropType;
		}
		set
		{
			cropType = value;
		}
	}

	public int _CropState
	{
		get
		{
			return (int)state;
		}
		set
		{
			state = (State)value;
		}
	}

	public float _CropProgress
	{
		get
		{
			return progressRemaining;
		}
		set
		{
			progressRemaining = value;
		}
	}

	public int _CropMultiplier
	{
		get
		{
			return harvestMultiplier;
		}
		set
		{
			harvestMultiplier = value;
		}
	}

	public float _CropFertilizer
	{
		get
		{
			return fertilizedTimer;
		}
		set
		{
			fertilizedTimer = value;
		}
	}

	public bool _CropImproved
	{
		get
		{
			return improvedRegrowthCycle;
		}
		set
		{
			improvedRegrowthCycle = value;
		}
	}

	public void ForceUpdateCropSlot()
	{
		if (state == State.MarkedForSeeding)
		{
			state = State.Empty;
		}
		if (state == State.Fossil)
		{
			state = State.Empty;
		}
		if (fertilizedTimer > 0f)
		{
			ShowFertilizedSprite(active: true);
		}
		if (cropType == CropType.GoldenGiantPumpkin)
		{
			StartCoroutine(SpawnGiantCropInNextFrame3x3(CropType.GoldenGiantPumpkin, GameManager.ins.goldenGiantPumpkin));
		}
		else
		{
			if (cropType == CropType.None)
			{
				return;
			}
			cropSO = GameManager.ins.getCropSO(cropType);
			GetSprites(GameManager.ins.getCropSprites(cropType));
			SetWateringNeeds(GameManager.ins.getCropWaterDemand(cropType));
			StartCoroutine(CheckWaterProgressMarks());
			SetGrowthTimerBasedOnProgress();
			cropVisual.sprite = sprites[0];
			cropVisual.sortingOrder = -1;
			if (progressRemaining <= 0.8f)
			{
				cropVisual.sprite = sprites[1];
			}
			if (progressRemaining <= 0.6f)
			{
				cropVisual.sprite = sprites[2];
			}
			if (progressRemaining <= 0.4f)
			{
				cropVisual.sprite = sprites[3];
			}
			if (progressRemaining <= 0.2f)
			{
				cropVisual.sprite = sprites[4];
			}
			if (progressRemaining <= 0f)
			{
				cropVisual.sprite = sprites[5];
			}
			if (progressRemaining <= 0.8f)
			{
				cropVisual.sortingOrder = 0;
			}
			for (int i = 0; i < waterAtProgressMark.Count; i++)
			{
				if (waterAtProgressMark[i] > progressRemaining)
				{
					waterAtProgressMark.Remove(waterAtProgressMark[i]);
				}
			}
			if (state == State.MarkedForWatering)
			{
				state = State.NeedWater;
			}
			if (state == State.MarkedForHarvest)
			{
				state = State.NeedHarvest;
			}
			if (state == State.IsGrowing)
			{
				dirtSprite.sprite = wateredSprite;
			}
			if (state == State.NeedHarvest)
			{
				dirtSprite.sprite = wateredSprite;
			}
			if (state == State.GiantCrop && cropType == CropType.Pumpkin)
			{
				StartCoroutine(SpawnGiantCropInNextFrame3x3(CropType.Pumpkin, GameManager.ins.giantPumpkin));
			}
			if (state == State.GiantCrop && cropType == CropType.WhitePumpkin)
			{
				StartCoroutine(SpawnGiantCropInNextFrame3x3(CropType.WhitePumpkin, GameManager.ins.giantWhitePumpkin));
			}
			if (state == State.GiantCrop && cropType == CropType.Tomato)
			{
				StartCoroutine(SpawnGiantCropInNextFrame2x3(CropType.Tomato, GameManager.ins.giantTomato));
			}
			if (state == State.GiantCrop && cropType == CropType.Cucumber)
			{
				StartCoroutine(SpawnGiantCropInNextFrame2x3(CropType.Cucumber, GameManager.ins.giantCucumber));
			}
			if (state == State.GiantCrop && cropType == CropType.Zucchini)
			{
				StartCoroutine(SpawnGiantCropInNextFrame2x3(CropType.Zucchini, GameManager.ins.giantZucchini));
			}
			if (state == State.GiantCrop && cropType == CropType.RedCabbage)
			{
				StartCoroutine(SpawnGiantCropInNextFrame2x3(CropType.RedCabbage, GameManager.ins.giantRedCabbage));
			}
			AddGarlicCircle(cropType);
		}
	}

	private IEnumerator SpawnGiantCropInNextFrame3x3(CropType type, GiantCrop obj)
	{
		yield return null;
		SpawnGiantCrop3x3(type, obj);
	}

	private IEnumerator SpawnGiantCropInNextFrame2x3(CropType type, GiantCrop obj)
	{
		yield return null;
		SpawnGiantCrop2x3(type, obj);
	}

	private IEnumerator CheckWaterProgressMarks()
	{
		yield return null;
		List<float> list = new List<float>();
		for (int i = 0; i < waterAtProgressMark.Count; i++)
		{
			if (!(waterAtProgressMark[i] > progressRemaining))
			{
				list.Add(waterAtProgressMark[i]);
			}
		}
		waterAtProgressMark.Clear();
		for (int j = 0; j < list.Count; j++)
		{
			waterAtProgressMark.Add(list[j]);
		}
	}

	private void Awake()
	{
		RandomizeStartPos();
		notWateredSprite = null;
		highlight.SetActive(value: false);
		waterAtProgressMark = new List<float>();
		coll = GetComponent<BoxCollider2D>();
		ShowFertilizedSprite(active: false);
	}

	private void Start()
	{
		if (SaveData.ins.farmType == SaveData.FarmType.Desert)
		{
			canDie = true;
		}
	}

	private void RandomizeStartPos()
	{
		if (!randomizeStartPos)
		{
			return;
		}
		float num = 0.0625f;
		if (!(Random.value < 0.2f))
		{
			num = ((!(Random.value < 0.5f)) ? (num * -1f) : (num * 1f));
			if (Random.value < 0.5f)
			{
				cropVisual.transform.position += new Vector3(num, 0f);
			}
			else
			{
				cropVisual.transform.position += new Vector3(0f, num);
			}
			if (Random.value < 0.5f)
			{
				cropVisual.flipX = true;
			}
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (GameManager.ins.state == GameManager.State.CanPlantSeed && state == State.Empty)
		{
			PlantSeed(GameManager.ins.cropSelected, playSound: true);
		}
		if (GameManager.ins.state == GameManager.State.CanRemoveCrop && state != State.Empty)
		{
			RemoveCrop();
		}
		if (GameManager.ins.state == GameManager.State.CanFertilize && fertilizedTimer <= 0f)
		{
			ClickToFertilizeSoil();
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (GameManager.ins.state == GameManager.State.CanPlantSeed && state == State.Empty && Input.GetMouseButton(0))
		{
			PlantSeed(GameManager.ins.cropSelected, playSound: true);
		}
		if (GameManager.ins.state == GameManager.State.CanRemoveCrop && state != State.Empty && Input.GetMouseButton(0))
		{
			RemoveCrop();
		}
		if (GameManager.ins.state == GameManager.State.CanFertilize && fertilizedTimer <= 0f && Input.GetMouseButton(0))
		{
			ClickToFertilizeSoil();
		}
		if (cropType != CropType.None && GameManager.ins.state == GameManager.State.CanInspectCrops)
		{
			if ((bool)cropSO && !GameManager.ins.qualityUpdate)
			{
				TooltipSystem.Show(LocalizationSystem.GetLocalizedValue(cropSO.cropName));
			}
			if ((bool)cropSO && GameManager.ins.qualityUpdate)
			{
				TooltipSystem.ShowCrop(LocalizationSystem.GetLocalizedValue(cropSO.cropName), waterAtProgressMark.Count + 1, harvestMultiplier, improvedRegrowthCycle);
			}
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		TooltipSystem.Hide();
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (GameManager.ins.state == GameManager.State.CanPlantSeed && state == State.Empty)
		{
			PlantSeed(GameManager.ins.cropSelected, playSound: true);
		}
		if (GameManager.ins.state == GameManager.State.CanRemoveCrop && state != State.Empty)
		{
			RemoveCrop();
		}
		if (GameManager.ins.state == GameManager.State.CanFertilize && fertilizedTimer <= 0f)
		{
			ClickToFertilizeSoil();
		}
	}

	public void ClickToFertilizeSoil()
	{
		if (!(fertilizedTimer > 0f))
		{
			if (Inventory.ins.fertilizer <= 0)
			{
				GameManager.ins.SetStateToIdle();
				return;
			}
			SoundManager.ins.PlaySound(plantSeedAudio);
			Fertilized();
		}
	}

	public void FertilizeSoil()
	{
		if (!(fertilizedTimer > 0f))
		{
			markedForFertilizing = false;
			Fertilized();
		}
	}

	private void Fertilized()
	{
		fertilizedTimer = 3600f;
		ShowFertilizedSprite(active: true);
	}

	private void ShowFertilizedSprite(bool active)
	{
		fertilizedSprite.gameObject.SetActive(active);
		if (SaveData.ins.farmType == SaveData.FarmType.WinterSnow)
		{
			fertilizedSprite.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
		}
	}

	public void ImproveCrop()
	{
		markedForImprovement = false;
		if (state != State.Empty && state != State.GiantCrop && state != State.Fossil && !improvedRegrowthCycle)
		{
			improvedRegrowthCycle = true;
			harvestMultiplier++;
		}
	}

	public void PlantSeed(CropType type, bool playSound)
	{
		Plant(type, playSound, chargeMoney: true);
	}

	public void PlantSeedForFree(CropType type)
	{
		Plant(type, playSound: false, chargeMoney: false);
	}

	private void Plant(CropType type, bool playSound, bool chargeMoney)
	{
		cropType = type;
		cropSO = GameManager.ins.getCropSO(type);
		int cropCost = cropSO.cropCost;
		if (Inventory.ins.spareParts < cropCost)
		{
			GameManager.ins.SetStateToIdle();
			return;
		}
		if (chargeMoney)
		{
			Inventory.ins.AddSpareParts(-cropCost);
		}
		if (chargeMoney)
		{
			GameManager.ins.SpawnSparePartsPopUp(base.transform.position, -cropCost);
		}
		if (playSound)
		{
			SoundManager.ins.PlaySound(plantSeedAudio);
		}
		SetWateringNeeds(GameManager.ins.getCropWaterDemand(cropType));
		SetGrowthTimer(GameManager.ins.getCropDaysToGrow(cropType));
		harvestMultiplier = cropSO.harvestMultiplier + GameManager.ins.GetCropGMO(cropSO).harvest;
		GetSprites(GameManager.ins.getCropSprites(cropType));
		cropVisual.sprite = sprites[0];
		cropVisual.sortingOrder = -1;
		state = State.NeedWater;
		killTimer = 0f;
		AddGarlicCircle(type);
	}

	private void ReplantCurrentSeed()
	{
		SetWateringNeeds(GameManager.ins.getCropWaterDemand(cropType));
		SetGrowthTimer(GameManager.ins.getCropDaysToGrow(cropType));
		GetSprites(GameManager.ins.getCropSprites(cropType));
		state = State.NeedWater;
		killTimer = 0f;
	}

	private void SetGrowthTimerBasedOnProgress()
	{
		float num = GameManager.ins.getCropDaysToGrow(cropType);
		if ((bool)cropSO)
		{
			num += GameManager.ins.GetCropGMO(cropSO).grow;
		}
		totalGrowthTimer = num * 60f;
		growthTimer = totalGrowthTimer * progressRemaining;
	}

	private void SetGrowthTimer(float durationInMinutes)
	{
		if ((bool)cropSO)
		{
			durationInMinutes += GameManager.ins.GetCropGMO(cropSO).grow;
		}
		totalGrowthTimer = durationInMinutes * 60f;
		growthTimer = totalGrowthTimer;
		progressRemaining = growthTimer / totalGrowthTimer;
	}

	private void SetWateringNeeds(int timesNeedsWater)
	{
		if (waterAtProgressMark.Count > 0)
		{
			waterAtProgressMark.Clear();
		}
		if ((bool)cropSO)
		{
			timesNeedsWater += GameManager.ins.GetCropGMO(cropSO).water;
		}
		for (int i = 0; i < timesNeedsWater - 1; i++)
		{
			waterAtProgressMark.Add(1f - ((float)i + 1f) / (float)timesNeedsWater);
		}
	}

	public void GetSprites(Sprite[] spr)
	{
		sprites = new Sprite[spr.Length];
		for (int i = 0; i < spr.Length; i++)
		{
			sprites[i] = spr[i];
		}
	}

	private void RemoveSprite()
	{
		cropVisual.sprite = null;
		dirtSprite.sprite = notWateredSprite;
	}

	private void Update()
	{
		if (fertilizedTimer > 0f)
		{
			fertilizedTimer -= Time.deltaTime;
		}
		else
		{
			fertilizedTimer = 0f;
			ShowFertilizedSprite(active: false);
		}
		if (state == State.IsGrowing)
		{
			deltaTime = Time.deltaTime;
			if (fertilizedTimer > 0f)
			{
				deltaTime *= 1.25f;
			}
			if (SaveData.ins.focusMode)
			{
				deltaTime *= 0.5f;
			}
			if (SaveData.ins.farmType == SaveData.FarmType.WinterSnow)
			{
				deltaTime *= 0.97f;
			}
			growthTimer -= deltaTime;
			progressRemaining = growthTimer / totalGrowthTimer;
			CheckSpriteVisualAt(0.8f, 1);
			CheckSpriteVisualAt(0.6f, 2);
			CheckSpriteVisualAt(0.4f, 3);
			CheckSpriteVisualAt(0.2f, 4);
			CheckSpriteVisualAt(0f, 5);
			if (progressRemaining < 0f)
			{
				ReadyForHarvest();
				progressRemaining = 0f;
				return;
			}
			if (waterAtProgressMark.Count > 0 && progressRemaining < waterAtProgressMark[0])
			{
				NeedsWatering();
				waterAtProgressMark.RemoveAt(0);
				return;
			}
		}
		if (state == State.Empty && GameManager.ins.state == GameManager.State.CanPlantSeed)
		{
			highlight.SetActive(value: true);
			if (!coll.enabled)
			{
				coll.enabled = true;
			}
			return;
		}
		if (state != State.Empty && GameManager.ins.state == GameManager.State.CanRemoveCrop)
		{
			highlight.SetActive(value: true);
			if (!coll.enabled)
			{
				coll.enabled = true;
			}
			return;
		}
		if (fertilizedTimer <= 0f && GameManager.ins.state == GameManager.State.CanFertilize)
		{
			highlight.SetActive(value: true);
			if (!coll.enabled)
			{
				coll.enabled = true;
			}
			return;
		}
		if (GameManager.ins.state == GameManager.State.CanInspectCrops)
		{
			highlight.SetActive(value: false);
			if (!coll.enabled)
			{
				coll.enabled = true;
			}
			return;
		}
		highlight.SetActive(value: false);
		if (coll.enabled)
		{
			coll.enabled = false;
		}
		if (!canDie)
		{
			return;
		}
		if (state == State.NeedWater || state == State.MarkedForWatering)
		{
			if (killTimer < killTime)
			{
				killTimer += Time.deltaTime;
			}
			else
			{
				RemoveCropNoSound();
				cropVisual.sprite = cropSO.deadSprite;
				killTimer = 0f;
			}
		}
		if (state == State.NeedHarvest || state == State.MarkedForHarvest)
		{
			if (killTimer < killTime + killTime)
			{
				killTimer += Time.deltaTime;
				return;
			}
			RemoveCropNoSound();
			cropVisual.sprite = cropSO.deadSprite;
			killTimer = 0f;
		}
	}

	private void CheckSpriteVisualAt(float progress, int spriteIndex)
	{
		if (progressRemaining <= progress && cropVisual.sprite != sprites[spriteIndex])
		{
			cropVisual.sprite = sprites[spriteIndex];
			cropVisual.sortingOrder = 0;
		}
	}

	private void NeedsWatering()
	{
		dirtSprite.sprite = notWateredSprite;
		state = State.NeedWater;
	}

	public void WaterCropSlot()
	{
		dirtSprite.sprite = wateredSprite;
		state = State.IsGrowing;
		killTimer = 0f;
		SaveData.ins.AddTotalCropsWatered(1);
	}

	private void ReadyForHarvest()
	{
		state = State.NeedHarvest;
		killTimer = 0f;
		CheckChanceToSpawnGoldenCrop3x3(CropType.Pumpkin, GameManager.ins.goldenGiantPumpkin);
		CheckChanceToSpawnGiantCrop3x3(CropType.Pumpkin, GameManager.ins.giantPumpkin);
		CheckChanceToSpawnGiantCrop3x3(CropType.WhitePumpkin, GameManager.ins.giantWhitePumpkin);
		CheckChanceToSpawnGiantCrop2x3(CropType.Tomato, GameManager.ins.giantTomato);
		CheckChanceToSpawnGiantCrop2x3(CropType.Cucumber, GameManager.ins.giantCucumber);
		CheckChanceToSpawnGiantCrop2x3(CropType.Zucchini, GameManager.ins.giantZucchini);
		CheckChanceToSpawnGiantCrop2x3(CropType.RedCabbage, GameManager.ins.giantRedCabbage);
	}

	private void CheckChanceToSpawnGoldenCrop3x3(CropType type, GiantCrop obj)
	{
		int maxExclusive = 4096;
		if (chanceToSpawnGiant3x3 && cropType == type && GameManager.ins.spawnGoldenPumpkin)
		{
			maxExclusive = 1;
			GameManager.ins.spawnGoldenPumpkin = false;
		}
		if (!chanceToSpawnGiant3x3 || cropType != type || Random.Range(0, maxExclusive) != 0 || state == State.GiantCrop)
		{
			return;
		}
		for (int i = 0; i < surroundingSlots3x3.Length; i++)
		{
			if (surroundingSlots3x3[i].state == State.GiantCrop)
			{
				return;
			}
		}
		cropType = obj.newCropType;
		SpawnGiantCrop3x3(type, obj);
		AchievementManager.ins.AddGiantCropStat(cropType, 1);
	}

	private void CheckChanceToSpawnGiantCrop3x3(CropType type, GiantCrop obj)
	{
		int num = Random.Range(0, 150);
		if (!chanceToSpawnGiant3x3 || cropType != type || num != 0 || state == State.GiantCrop)
		{
			return;
		}
		for (int i = 0; i < surroundingSlots3x3.Length; i++)
		{
			if (surroundingSlots3x3[i].state == State.GiantCrop)
			{
				return;
			}
		}
		SpawnGiantCrop3x3(type, obj);
		AchievementManager.ins.AddGiantCropStat(type, 1);
	}

	private void SpawnGiantCrop3x3(CropType type, GiantCrop obj)
	{
		GiantCrop giantCrop = Object.Instantiate(obj, base.transform);
		giantCrop.affectedCropSlots[0] = this;
		RemoveSprite();
		state = State.GiantCrop;
		harvestMultiplier = 0;
		improvedRegrowthCycle = false;
		for (int i = 0; i < surroundingSlots3x3.Length; i++)
		{
			giantCrop.affectedCropSlots[i + 1] = surroundingSlots3x3[i];
			surroundingSlots3x3[i].RemoveCropForGiantCrop();
		}
		AchievementManager.ins.GrowGiantCrop(type);
	}

	private void CheckChanceToSpawnGiantCrop2x3(CropType type, GiantCrop obj)
	{
		int num = Random.Range(0, 250);
		if (cropType == CropType.Cabbage)
		{
			num = Random.Range(0, 409);
		}
		if (!chanceToSpawnGiant2x2 || cropType != type || num != 0)
		{
			return;
		}
		for (int i = 0; i < surroundingSlots2x2.Length; i++)
		{
			if (surroundingSlots2x2[i].state == State.GiantCrop)
			{
				return;
			}
		}
		SpawnGiantCrop2x3(type, obj);
		AchievementManager.ins.AddGiantCropStat(type, 1);
	}

	private void SpawnGiantCrop2x3(CropType type, GiantCrop obj)
	{
		GiantCrop giantCrop = Object.Instantiate(obj, base.transform);
		giantCrop.affectedCropSlots[0] = this;
		RemoveSprite();
		state = State.GiantCrop;
		harvestMultiplier = 0;
		improvedRegrowthCycle = false;
		for (int i = 0; i < surroundingSlots2x2.Length; i++)
		{
			giantCrop.affectedCropSlots[i + 1] = surroundingSlots2x2[i];
			surroundingSlots2x2[i].RemoveCropForGiantCrop();
		}
		AchievementManager.ins.GrowGiantCrop(type);
	}

	public void HarvestCropSlot()
	{
		HarvestCropSlot(addToInventory: true);
	}

	public void HarvestCropSlot(bool addToInventory)
	{
		if (addToInventory)
		{
			Inventory.ins.AddToCropInventory(cropType, 1);
			SaveData.ins.AddTotalCropsHarvested(1);
			GiveEarnings();
		}
		harvestMultiplier--;
		if (harvestMultiplier > 0)
		{
			ReplantCurrentSeed();
			cropVisual.sprite = sprites[1];
			dirtSprite.sprite = notWateredSprite;
		}
		else
		{
			RemoveCropNoSound();
		}
	}

	private void GiveEarnings()
	{
		int num = cropSO.earnings + GameManager.ins.GetCropGMO(cropSO).earnings;
		if (num > 0)
		{
			if (SaveData.ins.checkIfCrossover(out var crossover) && crossover == CrossoverFarmType.Balatro)
			{
				Object.Instantiate(GameManager.ins.balatroCard, base.transform.position + Vector3.up, Quaternion.identity).transform.GetChild(0).GetComponent<BalatroCropCard>().SetPokerCardInfo(cropSO, num);
				return;
			}
			GameManager.ins.SpawnSparePartsPopUp((Vector2)base.transform.position + Vector2.up, num);
			Inventory.ins.AddSpareParts(num);
		}
	}

	public void AddHarvestMultiplier(int amount)
	{
		harvestMultiplier += amount;
	}

	public void RemoveCrop()
	{
		if (state != State.GiantCrop && state != State.Fossil)
		{
			RemoveCropNoSound();
			SoundManager.ins.PlaySound(plantSeedAudio);
		}
	}

	public void RemoveCropNoSound()
	{
		RemoveSprite();
		cropType = CropType.None;
		state = State.Empty;
		harvestMultiplier = 0;
		improvedRegrowthCycle = false;
		SaveData.ins.statsPanel.UpdateCropStats();
		RemoveGarlicCircle();
	}

	public void RemoveCropForGiantCrop()
	{
		RemoveSprite();
		cropType = CropType.None;
		state = State.GiantCrop;
		harvestMultiplier = 0;
		improvedRegrowthCycle = false;
	}

	private void AddGarlicCircle(CropType crop)
	{
		if (crop == CropType.Garlic && SaveData.ins.checkIfCrossover(out var crossover) && crossover == CrossoverFarmType.VampireSurvivors)
		{
			GarlicCircle garlicCircle = Object.Instantiate(GameManager.ins.garlicCircle, base.transform);
			garlicCircle.transform.position = base.transform.position;
			garlicCircle.gameObject.name = "GarlicCircle";
		}
	}

	private void RemoveGarlicCircle()
	{
		if (!SaveData.ins.checkIfCrossover(out var crossover) || crossover != CrossoverFarmType.VampireSurvivors)
		{
			return;
		}
		for (int i = 0; i < base.transform.childCount; i++)
		{
			if (base.transform.GetChild(i).gameObject.name == "GarlicCircle")
			{
				Object.Destroy(base.transform.GetChild(i).gameObject);
			}
		}
	}
}
