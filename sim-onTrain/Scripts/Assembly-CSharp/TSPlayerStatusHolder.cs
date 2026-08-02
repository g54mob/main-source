using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using HQFPSTemplate;
using HQFPSTemplate.Equipment;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TSPlayerStatusHolder : MonoBehaviour
{
	public PlayerStatusPanel playerStatusPanel;

	public PowerUpPanel powerUpPanel;

	public Volume postProcessVolume;

	private TSPlayerController player;

	[Header("Chromatic Aberration Settings")]
	[Tooltip("Artık kullanılmıyor - Efekt sadece yemek veya su 0 olduğunda aktif olur")]
	[HideInInspector]
	public float chromaticThreshold;

	[Tooltip("Sabit base chromatic aberration değeri")]
	[Range(0f, 1f)]
	public float chromaticBaseIntensity = 0.7f;

	[Tooltip("İlk açılış süresi (0'dan base değere)")]
	public float chromaticFadeInDuration = 1f;

	[Tooltip("Damage flash'ı arasındaki süre (saniye)")]
	public float chromaticFlashInterval = 3f;

	[Tooltip("Flash'ın maksimum yoğunluğu")]
	[Range(0f, 1f)]
	public float chromaticFlashIntensity = 1f;

	[Tooltip("Flash'ın çıkış süresi (saniye)")]
	public float chromaticFlashRiseTime = 0.1f;

	[Tooltip("Flash'ın inme süresi (saniye)")]
	public float chromaticFlashFallTime = 0.3f;

	[Tooltip("Chromatic aberration kapanma hızı")]
	public float chromaticFadeOutSpeed = 0.5f;

	[Tooltip("Zayıflık durumunda hareket hızı çarpanı (0.7 = %30 azalma)")]
	[Range(0.1f, 1f)]
	public float weaknessSpeedMultiplier = 0.7f;

	private ChromaticAberration chromaticAberration;

	private Coroutine chromaticFlashCoroutine;

	private Coroutine chromaticFadeOutCoroutine;

	private Coroutine chromaticFadeInCoroutine;

	private bool isChromaticActive;

	[Header("Water System")]
	[Tooltip("Su sistemini aktif eder/devre dışı bırakır")]
	public bool useWater = true;

	[Header("Hunger/Thirst Damage")]
	public float foodHealthDamagePerSecond;

	public float waterHealthDamagePerSecond;

	public float foodDecraseRatioPerSecond = 1f;

	public float waterDecraseRatioPerSecond = 0.25f;

	[Header("Health Regeneration")]
	[Tooltip("Yemek bu yüzdenin üzerindeyse can yenilenir")]
	public float foodThresholdForHealthRegen = 20f;

	[Tooltip("Saniyede ne kadar can yenilenir")]
	public float healthRegenRatePerSecond = 0.2f;

	[Tooltip("HealthRegen powerup aktifken saniyede yenilenecek can miktarı (override)")]
	public float healthRegenBoostAmount = 1f;

	[Tooltip("DefenseBoost powerup aktifken hasar bölme çarpanı (4 = hasar 4'e bölünür)")]
	public float defenseBoostAmount = 4f;

	public bool healthRegenBoostActive;

	public float defenseBoostMultiplier = 1f;

	public float playerHpFuel = 100f;

	public float playerFoodFuel = 100f;

	public float playerWaterFuel = 100f;

	[Header("DEBUG - HQFPS Health System")]
	public float hqfpsHealth = 100f;

	[HideInInspector]
	public bool isResettingHQFPSHealth;

	[HideInInspector]
	public bool ignoreFallDamage;

	public float eatingTime = 3f;

	public float drinkingTime = 2f;

	public float syringeTime = 2f;

	public AudioSource audioSource;

	public AudioClip eatingSound;

	public AudioClip drinkingSound;

	public AudioClip eatPowerUpSound;

	public AudioClip drinkPowerUpSound;

	public AudioClip bandagingSound;

	[Header("Damage Sounds")]
	public List<AudioClip> damageSounds;

	[Header("Warning Sounds")]
	public AudioClip lowHungerSound;

	public AudioClip lowThirstSound;

	public float warningSoundInterval = 10f;

	private float lastWarningSoundTime = -999f;

	private bool lastWasFoodSound;

	public GameObject foodParticle;

	public GameObject drinkParticle;

	public bool isEating;

	public bool isDrinking;

	public bool isUsingSyringe;

	public bool isBandaging;

	public bool isUsingConsumablePowerUp;

	public bool isCPR;

	public float currentEatingTime;

	public float currentDrinkingTime;

	public float currentSyringeTime;

	public float currentBandagingTime;

	public float currentConsumablePowerUpTime;

	public float consumablePowerUpUseTime = 1f;

	private AudioClip currentConsumableClip;

	private PlayerInventory playerInventory;

	private EastUpPlayerItemManager itemManager;

	private PlayerMovement playerMovement;

	private PlayerVitals playerVitals;

	private HQFPSTemplate.Player hqfpsPlayerCached;

	[Header("Damage Effect Settings")]
	[Tooltip("Damage efekti gösterilecek can azalma yüzdesi (%15 = her %15 can azaldığında)")]
	[Range(5f, 30f)]
	public float damageEffectHealthInterval = 15f;

	private float lastDamageEffectHealthThreshold = 100f;

	[Header("Camera Shake Settings (Zombie Damage)")]
	[Tooltip("Zombie hasarında kamera shake şiddeti")]
	[Range(0.1f, 2f)]
	public float cameraShakeIntensity = 0.5f;

	[Tooltip("Kamera shake süresi")]
	[Range(0.1f, 1f)]
	public float cameraShakeDuration = 0.3f;

	[Tooltip("Kamera shake titreşim sayısı")]
	[Range(5f, 50f)]
	public int cameraShakeVibrato = 20;

	[Tooltip("Kamera shake rastgelelik (0 = düzgün, 90 = kaotik)")]
	[Range(0f, 90f)]
	public float cameraShakeRandomness = 45f;

	private CameraPhysicsHandler cameraPhysicsHandler;

	private List<TimedPowerUpData> activePowerUps = new List<TimedPowerUpData>();

	private void Start()
	{
		this.player = GetComponent<TSPlayerController>();
		if (!(this.player != null) || this.player.isLocalPlayer)
		{
			playerStatusPanel = Object.FindObjectOfType<PlayerStatusPanel>();
			playerInventory = GetComponent<PlayerInventory>();
			itemManager = GetComponent<EastUpPlayerItemManager>();
			postProcessVolume = Object.FindObjectOfType<Volume>();
			playerMovement = GetComponent<PlayerMovement>();
			playerVitals = GetComponent<PlayerVitals>();
			powerUpPanel = Object.FindObjectOfType<PowerUpPanel>();
			if (postProcessVolume != null && postProcessVolume.profile.TryGet<ChromaticAberration>(out chromaticAberration))
			{
				chromaticAberration.active = true;
				chromaticAberration.intensity.value = 0f;
			}
			if (this.player != null && this.player.worldCamera != null)
			{
				cameraPhysicsHandler = this.player.worldCamera.GetComponent<CameraPhysicsHandler>();
			}
			hqfpsPlayerCached = GetComponent<HQFPSTemplate.Player>();
			HQFPSTemplate.Player player = hqfpsPlayerCached;
			if (player != null)
			{
				player.ChangeHealth.AddListener(OnHQFPSHealthChanged);
				isResettingHQFPSHealth = true;
				player.Health.Set(100f);
				isResettingHQFPSHealth = false;
			}
		}
	}

	private void Update()
	{
		if (player == null || !player.isLocalPlayer)
		{
			return;
		}
		HQFPSTemplate.Player component = GetComponent<HQFPSTemplate.Player>();
		if (component != null)
		{
			hqfpsHealth = component.Health.Get();
		}
		if (player != null && player.isDeath)
		{
			if (isChromaticActive && chromaticAberration != null)
			{
				isChromaticActive = false;
				if (chromaticFlashCoroutine != null)
				{
					StopCoroutine(chromaticFlashCoroutine);
					chromaticFlashCoroutine = null;
				}
				if (chromaticFadeInCoroutine != null)
				{
					StopCoroutine(chromaticFadeInCoroutine);
					chromaticFadeInCoroutine = null;
				}
				chromaticAberration.intensity.value = 0f;
			}
			UpdateUI();
			return;
		}
		if (TrainGameManager.Instance != null && TrainGameManager.Instance.currentGameMode == GameMode.Creative)
		{
			playerHpFuel = 100f;
			playerFoodFuel = 100f;
			playerWaterFuel = 100f;
		}
		else
		{
			if (playerFoodFuel > 0f)
			{
				playerFoodFuel -= foodDecraseRatioPerSecond * Time.deltaTime;
			}
			else if (playerFoodFuel < 0f)
			{
				playerFoodFuel = 0f;
			}
			if (useWater)
			{
				if (playerWaterFuel > 0f)
				{
					playerWaterFuel -= waterDecraseRatioPerSecond * Time.deltaTime;
				}
				else if (playerWaterFuel < 0f)
				{
					playerWaterFuel = 0f;
				}
			}
			if (playerFoodFuel <= 0f && foodHealthDamagePerSecond > 0f)
			{
				GetDamage(foodHealthDamagePerSecond * Time.deltaTime, isZombieHit: false);
			}
			if (useWater && playerWaterFuel <= 0f && waterHealthDamagePerSecond > 0f)
			{
				GetDamage(waterHealthDamagePerSecond * Time.deltaTime, isZombieHit: false);
			}
			if (playerHpFuel < 100f && playerFoodFuel > foodThresholdForHealthRegen)
			{
				float num = (healthRegenBoostActive ? healthRegenBoostAmount : healthRegenRatePerSecond);
				playerHpFuel += num * Time.deltaTime;
				if (playerHpFuel > 100f)
				{
					playerHpFuel = 100f;
				}
			}
		}
		HandleEating();
		if (useWater)
		{
			HandleDrinking();
		}
		HandleUsingSyringe();
		HandleBandaging();
		HandleConsumablePowerUp();
		HandleParticles();
		HandleChromaticAberration();
		UpdatePowerUps();
		UpdateUI();
	}

	private void HandleParticles()
	{
		if (isEating && !foodParticle.activeSelf)
		{
			foodParticle.SetActive(value: true);
		}
		else if (!isEating && foodParticle.activeSelf)
		{
			foodParticle.SetActive(value: false);
		}
		if (useWater)
		{
			if (isDrinking && !drinkParticle.activeSelf)
			{
				drinkParticle.SetActive(value: true);
			}
			else if (!isDrinking && drinkParticle.activeSelf)
			{
				drinkParticle.SetActive(value: false);
			}
		}
		else if (drinkParticle.activeSelf)
		{
			drinkParticle.SetActive(value: false);
		}
	}

	private void HandleEating()
	{
		if (isEating)
		{
			currentEatingTime += Time.deltaTime;
			if (currentEatingTime >= eatingTime)
			{
				CompleteEating();
			}
		}
	}

	private void HandleDrinking()
	{
		if (isDrinking)
		{
			currentDrinkingTime += Time.deltaTime;
			if (currentDrinkingTime >= drinkingTime)
			{
				CompleteDrinking();
			}
		}
	}

	private void HandleUsingSyringe()
	{
		if (isUsingSyringe)
		{
			currentSyringeTime += Time.deltaTime;
			if (currentSyringeTime >= syringeTime)
			{
				CompleteUsingSyringe();
			}
		}
	}

	private void HandleBandaging()
	{
		if (!isBandaging)
		{
			return;
		}
		if (hqfpsPlayerCached != null && hqfpsPlayerCached.Run.Active)
		{
			StopBandaging();
			return;
		}
		currentBandagingTime += Time.deltaTime;
		if (currentBandagingTime >= 1f)
		{
			CompleteBandaging();
		}
	}

	public void StartBandaging()
	{
		if (isEating || isDrinking || isBandaging)
		{
			Debug.Log($"[Bandage] BLOCKED - isEating:{isEating} isDrinking:{isDrinking} isBandaging:{isBandaging}");
			return;
		}
		if (hqfpsPlayerCached != null && hqfpsPlayerCached.Run.Active)
		{
			Debug.Log("[Bandage] BLOCKED - Player is running");
			return;
		}
		CollectableItemData selectedSlotItemData = itemManager.GetSelectedSlotItemData();
		if (selectedSlotItemData == null || selectedSlotItemData.itemType != ItemType.Bandage)
		{
			Debug.Log("[Bandage] BLOCKED - selectedItem:" + ((selectedSlotItemData != null) ? selectedSlotItemData.itemName : "NULL") + " type:" + ((selectedSlotItemData != null) ? selectedSlotItemData.itemType.ToString() : "N/A"));
			return;
		}
		if (playerHpFuel >= 100f)
		{
			Debug.Log($"[Bandage] BLOCKED - HP is full ({playerHpFuel})");
			return;
		}
		Debug.Log($"[Bandage] STARTED - HP:{playerHpFuel}");
		isBandaging = true;
		currentBandagingTime = 0f;
		if (audioSource != null && bandagingSound != null)
		{
			audioSource.clip = bandagingSound;
			audioSource.loop = false;
			audioSource.Play();
		}
	}

	public void StopBandaging()
	{
		isBandaging = false;
		currentBandagingTime = 0f;
		if (audioSource != null && audioSource.isPlaying && audioSource.clip == bandagingSound)
		{
			audioSource.Stop();
		}
	}

	private void CompleteBandaging()
	{
		CollectableItemData selectedSlotItemData = itemManager.GetSelectedSlotItemData();
		if (selectedSlotItemData != null && selectedSlotItemData.itemType == ItemType.Bandage)
		{
			ApplyHealthChange(selectedSlotItemData.IncreaseHealthPerUse);
			playerInventory.AddItemInventory(selectedSlotItemData, -1);
		}
		isBandaging = false;
		currentBandagingTime = 0f;
		itemManager.StartBandageCooldown();
		if (audioSource != null && audioSource.isPlaying && audioSource.clip == bandagingSound)
		{
			audioSource.Stop();
		}
		CollectableItemData selectedSlotItemData2 = itemManager.GetSelectedSlotItemData();
		if (selectedSlotItemData2 == null || selectedSlotItemData2.itemType != ItemType.Bandage)
		{
			itemManager.DeactivateCurrentUnarmedItem();
		}
		itemManager.UpdateConsumableInteraction();
	}

	public void StartEating()
	{
		if (isEating || isDrinking)
		{
			return;
		}
		CollectableItemData selectedSlotItemData = itemManager.GetSelectedSlotItemData();
		if (selectedSlotItemData == null || selectedSlotItemData.itemType != ItemType.Food)
		{
			return;
		}
		if (selectedSlotItemData.hasDurability)
		{
			InventorySlot lastSelectedSlot = itemManager.lastSelectedSlot;
			if (lastSelectedSlot?.InventoryItem == null || lastSelectedSlot.InventoryItem.GetCurrentDurability() < selectedSlotItemData.durabilityDecreasePerUse)
			{
				return;
			}
		}
		isEating = true;
		currentEatingTime = 0f;
		itemManager.PlayUseAnimation();
		if (audioSource != null && eatingSound != null)
		{
			audioSource.clip = eatingSound;
			currentConsumableClip = eatingSound;
			audioSource.loop = false;
			audioSource.Play();
		}
	}

	public void StartDrinking()
	{
		if (!useWater || isEating || isDrinking)
		{
			return;
		}
		CollectableItemData selectedSlotItemData = itemManager.GetSelectedSlotItemData();
		if (selectedSlotItemData == null || selectedSlotItemData.itemType != ItemType.Drink)
		{
			return;
		}
		if (selectedSlotItemData.hasDurability)
		{
			InventorySlot lastSelectedSlot = itemManager.lastSelectedSlot;
			if (lastSelectedSlot?.InventoryItem == null || lastSelectedSlot.InventoryItem.GetCurrentDurability() <= 0f)
			{
				return;
			}
		}
		isDrinking = true;
		currentDrinkingTime = 0f;
		itemManager.PlayUseAnimation();
		if (audioSource != null && drinkingSound != null)
		{
			audioSource.clip = drinkingSound;
			currentConsumableClip = drinkingSound;
			audioSource.loop = false;
			audioSource.Play();
		}
	}

	public void StopEating()
	{
		isEating = false;
		currentEatingTime = 0f;
		itemManager.StopUseAnimation();
		if (audioSource != null && audioSource.isPlaying && audioSource.clip == currentConsumableClip)
		{
			audioSource.Stop();
		}
		currentConsumableClip = null;
	}

	public void StopDrinking()
	{
		isDrinking = false;
		currentDrinkingTime = 0f;
		itemManager.StopUseAnimation();
		if (audioSource != null && audioSource.isPlaying && audioSource.clip == currentConsumableClip)
		{
			audioSource.Stop();
		}
		currentConsumableClip = null;
	}

	public void StartPouring()
	{
		if (!useWater || isEating || isDrinking)
		{
			return;
		}
		CollectableItemData selectedSlotItemData = itemManager.GetSelectedSlotItemData();
		if (selectedSlotItemData == null || selectedSlotItemData.itemType != ItemType.Drink)
		{
			return;
		}
		InventorySlot lastSelectedSlot = itemManager.lastSelectedSlot;
		if (selectedSlotItemData.hasDurability && (lastSelectedSlot?.InventoryItem == null || lastSelectedSlot.InventoryItem.GetCurrentDurability() <= 0f))
		{
			return;
		}
		if (selectedSlotItemData.hasDurability)
		{
			if (lastSelectedSlot?.InventoryItem != null)
			{
				float currentDurability = lastSelectedSlot.InventoryItem.GetCurrentDurability();
				if (Singleton<ItemManager>.Instance.ConsumeWaterFromBottle(lastSelectedSlot.InventoryItem, currentDurability) <= 0f)
				{
					return;
				}
			}
		}
		else
		{
			playerInventory.AddItemInventory(selectedSlotItemData, -1);
		}
		itemManager.StartPouringCooldown();
		CollectableItemData selectedSlotItemData2 = itemManager.GetSelectedSlotItemData();
		if (selectedSlotItemData2 == null || (selectedSlotItemData2.itemType != ItemType.Drink && selectedSlotItemData2.itemType != ItemType.Food))
		{
			itemManager.DeactivateCurrentUnarmedItem();
		}
		else if (selectedSlotItemData2 != selectedSlotItemData)
		{
			itemManager.ActivateUnarmedItem(selectedSlotItemData2);
		}
		itemManager.UpdateConsumableInteraction();
	}

	public void StartUsingSyringe()
	{
		if (!isEating && !isDrinking && !isUsingSyringe)
		{
			CollectableItemData selectedSlotItemData = itemManager.GetSelectedSlotItemData();
			if (!(selectedSlotItemData == null) && selectedSlotItemData.itemType == ItemType.Syringe)
			{
				isUsingSyringe = true;
				currentSyringeTime = 0f;
				StartSyringeAnimation();
			}
		}
	}

	private void StartSyringeAnimation()
	{
		EquipmentInventoryAdder component = GetComponent<EquipmentInventoryAdder>();
		if (component != null && component.equipmentHandler != null)
		{
			HealingItem healingItem = component.equipmentHandler.EquipmentItem as HealingItem;
			if (healingItem != null)
			{
				Debug.Log("Starting syringe animation.");
				healingItem.StartSyringeAnimation();
			}
		}
	}

	public void StopUsingSyringe()
	{
		if (currentSyringeTime < syringeTime)
		{
			Debug.Log("Syringe kullanımı iptal edildi.");
			CancelSyringeAnimation();
		}
		isUsingSyringe = false;
		currentSyringeTime = 0f;
	}

	private void CancelSyringeAnimation()
	{
		Debug.Log("Cancelling syringe animation - Unequipping to unarmed.");
		if (itemManager != null && itemManager.fpsInventory != null)
		{
			CollectableItemData selectedSlotItemData = itemManager.GetSelectedSlotItemData();
			itemManager.fpsInventory.TryUnequipItem();
			if (selectedSlotItemData != null)
			{
				itemManager.fpsInventory.TryEquipItem(selectedSlotItemData);
			}
		}
	}

	private void CompleteEating()
	{
		CollectableItemData selectedSlotItemData = itemManager.GetSelectedSlotItemData();
		if (selectedSlotItemData != null && selectedSlotItemData.itemType == ItemType.Food)
		{
			if (selectedSlotItemData.hasDurability)
			{
				InventorySlot lastSelectedSlot = itemManager.lastSelectedSlot;
				if (lastSelectedSlot?.InventoryItem != null)
				{
					float currentDurability = lastSelectedSlot.InventoryItem.GetCurrentDurability();
					float durabilityDecreasePerUse = selectedSlotItemData.durabilityDecreasePerUse;
					if (currentDurability >= durabilityDecreasePerUse)
					{
						lastSelectedSlot.InventoryItem.DecreaseDurability(durabilityDecreasePerUse);
						Eat(selectedSlotItemData.IncreaseHungerPerUse);
						DrinkWater(selectedSlotItemData.IncreaseWaterPerUse);
						ApplyHealthChange(selectedSlotItemData.IncreaseHealthPerUse);
					}
				}
			}
			else
			{
				playerInventory.AddItemInventory(selectedSlotItemData, -1);
				Eat(selectedSlotItemData.IncreaseHungerPerUse);
				DrinkWater(selectedSlotItemData.IncreaseWaterPerUse);
				ApplyHealthChange(selectedSlotItemData.IncreaseHealthPerUse);
			}
		}
		isEating = false;
		currentEatingTime = 0f;
		itemManager.StopUseAnimation();
		itemManager.StartEatingCooldown();
		if (audioSource != null && audioSource.isPlaying && audioSource.clip == currentConsumableClip)
		{
			audioSource.Stop();
		}
		currentConsumableClip = null;
		CollectableItemData selectedSlotItemData2 = itemManager.GetSelectedSlotItemData();
		if (selectedSlotItemData2 == null || (selectedSlotItemData2.itemType != ItemType.Food && selectedSlotItemData2.itemType != ItemType.Drink && selectedSlotItemData2.itemType != ItemType.EatPowerUp && selectedSlotItemData2.itemType != ItemType.DrinkPowerUp))
		{
			itemManager.DeactivateCurrentUnarmedItem();
			itemManager.UpdateConsumableInteraction();
			return;
		}
		if (selectedSlotItemData2 != selectedSlotItemData)
		{
			itemManager.ActivateUnarmedItem(selectedSlotItemData2);
		}
		itemManager.UpdateConsumableInteraction();
	}

	private void CompleteDrinking()
	{
		CollectableItemData selectedSlotItemData = itemManager.GetSelectedSlotItemData();
		if (selectedSlotItemData != null && selectedSlotItemData.itemType == ItemType.Drink)
		{
			InventorySlot lastSelectedSlot = itemManager.lastSelectedSlot;
			if (selectedSlotItemData.hasDurability)
			{
				if (lastSelectedSlot?.InventoryItem != null)
				{
					float currentDurability = lastSelectedSlot.InventoryItem.GetCurrentDurability();
					float durabilityDecreasePerUse = selectedSlotItemData.durabilityDecreasePerUse;
					float amount = ((currentDurability < 35f) ? currentDurability : durabilityDecreasePerUse);
					float num = Singleton<ItemManager>.Instance.ConsumeWaterFromBottle(lastSelectedSlot.InventoryItem, amount) / durabilityDecreasePerUse;
					DrinkWater(selectedSlotItemData.IncreaseWaterPerUse * num);
					Eat(selectedSlotItemData.IncreaseHungerPerUse * num);
					ApplyHealthChange(selectedSlotItemData.IncreaseHealthPerUse * num);
				}
			}
			else
			{
				playerInventory.AddItemInventory(selectedSlotItemData, -1);
				DrinkWater(selectedSlotItemData.IncreaseWaterPerUse);
				Eat(selectedSlotItemData.IncreaseHungerPerUse);
				ApplyHealthChange(selectedSlotItemData.IncreaseHealthPerUse);
			}
		}
		isDrinking = false;
		currentDrinkingTime = 0f;
		itemManager.StopUseAnimation();
		itemManager.StartDrinkingCooldown();
		if (audioSource != null && audioSource.isPlaying && audioSource.clip == currentConsumableClip)
		{
			audioSource.Stop();
		}
		currentConsumableClip = null;
		CollectableItemData selectedSlotItemData2 = itemManager.GetSelectedSlotItemData();
		if (selectedSlotItemData2 == null || (selectedSlotItemData2.itemType != ItemType.Drink && selectedSlotItemData2.itemType != ItemType.Food && selectedSlotItemData2.itemType != ItemType.EatPowerUp && selectedSlotItemData2.itemType != ItemType.DrinkPowerUp))
		{
			itemManager.DeactivateCurrentUnarmedItem();
			itemManager.UpdateConsumableInteraction();
			return;
		}
		if (selectedSlotItemData2 != selectedSlotItemData)
		{
			itemManager.ActivateUnarmedItem(selectedSlotItemData2);
		}
		itemManager.UpdateConsumableInteraction();
	}

	private void OnHQFPSHealthChanged(DamageInfo dmgInfo)
	{
		if (isResettingHQFPSHealth || ignoreFallDamage || !(dmgInfo.Delta < 0f))
		{
			return;
		}
		float num = Mathf.Abs(dmgInfo.Delta) / defenseBoostMultiplier;
		playerHpFuel -= num;
		HQFPSTemplate.Player component = GetComponent<HQFPSTemplate.Player>();
		if (component != null)
		{
			isResettingHQFPSHealth = true;
			component.Health.Set(100f);
			isResettingHQFPSHealth = false;
		}
		if (playerHpFuel <= lastDamageEffectHealthThreshold - damageEffectHealthInterval)
		{
			if (playerStatusPanel != null)
			{
				playerStatusPanel.ShowDamageEffect();
			}
			PlayRandomDamageSound();
			lastDamageEffectHealthThreshold = Mathf.Floor(playerHpFuel / damageEffectHealthInterval) * damageEffectHealthInterval;
		}
		if (playerHpFuel <= 0f && !player.isDeath)
		{
			ClearAllPowerUps();
			player.ToFaint();
			lastDamageEffectHealthThreshold = 100f;
		}
	}

	public void GetDamage(float damage, bool isZombieHit)
	{
		float num = damage / defenseBoostMultiplier;
		playerHpFuel -= num;
		if (isZombieHit)
		{
			if (playerStatusPanel != null)
			{
				playerStatusPanel.ShowDamageEffect();
			}
			PlayRandomDamageSound();
			TriggerDamageCameraShake();
			lastDamageEffectHealthThreshold = Mathf.Floor(playerHpFuel / damageEffectHealthInterval) * damageEffectHealthInterval;
		}
		else if (playerHpFuel <= lastDamageEffectHealthThreshold - damageEffectHealthInterval)
		{
			if (playerStatusPanel != null)
			{
				playerStatusPanel.ShowDamageEffect();
			}
			PlayRandomDamageSound();
			lastDamageEffectHealthThreshold = Mathf.Floor(playerHpFuel / damageEffectHealthInterval) * damageEffectHealthInterval;
		}
		if (playerHpFuel <= 0f && !player.isDeath)
		{
			ClearAllPowerUps();
			player.ToFaint();
			lastDamageEffectHealthThreshold = 100f;
		}
	}

	public void Eat(float eatAmount)
	{
		playerFoodFuel += eatAmount;
		if (playerFoodFuel > 100f)
		{
			playerFoodFuel = 100f;
		}
	}

	public void UpdateUI()
	{
		bool flag = player != null && player.isDeath;
		playerStatusPanel.UpdateUI(playerHpFuel, playerFoodFuel, playerWaterFuel, flag);
		if (!flag)
		{
			CheckAndPlayWarningSounds(playerFoodFuel, playerWaterFuel);
		}
	}

	public void DrinkWater(float waterAmount)
	{
		playerWaterFuel += waterAmount;
		if (playerWaterFuel > 100f)
		{
			playerWaterFuel = 100f;
		}
	}

	public void ApplyHealthChange(float healthAmount)
	{
		if (healthAmount > 0f)
		{
			playerHpFuel += healthAmount;
			if (playerHpFuel > 100f)
			{
				playerHpFuel = 100f;
			}
		}
		else if (healthAmount < 0f)
		{
			float num = Mathf.Abs(healthAmount) / defenseBoostMultiplier;
			playerHpFuel -= num;
			if (playerStatusPanel != null)
			{
				playerStatusPanel.ShowDamageEffect();
			}
			if (playerHpFuel <= 0f && !player.isDeath)
			{
				ClearAllPowerUps();
				player.ToFaint();
				lastDamageEffectHealthThreshold = 100f;
			}
		}
	}

	private void HandleChromaticAberration()
	{
		if (chromaticAberration == null)
		{
			return;
		}
		bool flag = playerFoodFuel <= 0f || (useWater && playerWaterFuel <= 0f);
		if (playerMovement != null)
		{
			playerMovement.isWeakenedByHunger = flag;
			playerMovement.weaknessSpeedMultiplier = weaknessSpeedMultiplier;
			if (flag && player != null)
			{
				HQFPSTemplate.Player component = player.GetComponent<HQFPSTemplate.Player>();
				if (component != null && component.Run.Active)
				{
					component.Run.ForceStop();
				}
			}
		}
		if (flag && !isChromaticActive)
		{
			isChromaticActive = true;
			chromaticAberration.active = true;
			chromaticAberration.intensity.value = 0f;
			if (chromaticFadeOutCoroutine != null)
			{
				StopCoroutine(chromaticFadeOutCoroutine);
				chromaticFadeOutCoroutine = null;
			}
			if (chromaticFadeInCoroutine == null)
			{
				chromaticFadeInCoroutine = StartCoroutine(ChromaticFadeIn());
			}
		}
		else if (!flag && isChromaticActive)
		{
			isChromaticActive = false;
			if (chromaticFlashCoroutine != null)
			{
				StopCoroutine(chromaticFlashCoroutine);
				chromaticFlashCoroutine = null;
			}
			if (chromaticFadeOutCoroutine == null)
			{
				chromaticFadeOutCoroutine = StartCoroutine(ChromaticFadeOut());
			}
		}
	}

	private void CompleteUsingSyringe()
	{
		CollectableItemData selectedSlotItemData = itemManager.GetSelectedSlotItemData();
		if (selectedSlotItemData != null && selectedSlotItemData.itemType == ItemType.Syringe)
		{
			HandlePowerUps(selectedSlotItemData);
			if (!selectedSlotItemData.hasDurability)
			{
				playerInventory.AddItemInventory(selectedSlotItemData, -1);
			}
		}
		isUsingSyringe = false;
		currentSyringeTime = 0f;
		itemManager.StartSyringeCooldown();
	}

	private void HandleConsumablePowerUp()
	{
		if (isUsingConsumablePowerUp)
		{
			currentConsumablePowerUpTime += Time.deltaTime;
			if (currentConsumablePowerUpTime >= consumablePowerUpUseTime)
			{
				CompleteConsumablePowerUp();
			}
		}
	}

	public void StartConsumablePowerUp()
	{
		if (isEating || isDrinking || isUsingSyringe || isBandaging || isUsingConsumablePowerUp)
		{
			Debug.Log($"[ConsumablePowerUp] START BLOCKED - isEating:{isEating} isDrinking:{isDrinking} isSyringe:{isUsingSyringe} isBandaging:{isBandaging} isUsing:{isUsingConsumablePowerUp}");
			return;
		}
		CollectableItemData selectedSlotItemData = itemManager.GetSelectedSlotItemData();
		if (selectedSlotItemData == null || (selectedSlotItemData.itemType != ItemType.EatPowerUp && selectedSlotItemData.itemType != ItemType.DrinkPowerUp))
		{
			Debug.Log("[ConsumablePowerUp] START BLOCKED - item:" + ((selectedSlotItemData != null) ? selectedSlotItemData.itemName : "NULL") + " type:" + ((selectedSlotItemData != null) ? selectedSlotItemData.itemType.ToString() : "N/A"));
			return;
		}
		Debug.Log($"[ConsumablePowerUp] STARTED - {selectedSlotItemData.itemName} ({selectedSlotItemData.itemType})");
		isUsingConsumablePowerUp = true;
		currentConsumablePowerUpTime = 0f;
		AudioClip audioClip = ((selectedSlotItemData.itemType == ItemType.EatPowerUp) ? eatPowerUpSound : drinkPowerUpSound);
		if (audioSource != null && audioClip != null)
		{
			audioSource.clip = audioClip;
			currentConsumableClip = audioClip;
			audioSource.loop = false;
			audioSource.Play();
		}
	}

	public void StopConsumablePowerUp()
	{
		isUsingConsumablePowerUp = false;
		currentConsumablePowerUpTime = 0f;
		if (audioSource != null && audioSource.isPlaying && audioSource.clip == currentConsumableClip)
		{
			audioSource.Stop();
		}
		currentConsumableClip = null;
	}

	private void CompleteConsumablePowerUp()
	{
		CollectableItemData selectedSlotItemData = itemManager.GetSelectedSlotItemData();
		if (selectedSlotItemData != null && (selectedSlotItemData.itemType == ItemType.EatPowerUp || selectedSlotItemData.itemType == ItemType.DrinkPowerUp))
		{
			playerInventory.AddItemInventory(selectedSlotItemData, -1);
			Eat(selectedSlotItemData.IncreaseHungerPerUse);
			DrinkWater(selectedSlotItemData.IncreaseWaterPerUse);
			ApplyHealthChange(selectedSlotItemData.IncreaseHealthPerUse);
			if (selectedSlotItemData.powerUpType != PlayerPowerUpType.None)
			{
				HandlePowerUps(selectedSlotItemData);
			}
		}
		isUsingConsumablePowerUp = false;
		currentConsumablePowerUpTime = 0f;
		itemManager.StartConsumablePowerUpCooldown();
		if (audioSource != null && audioSource.isPlaying && audioSource.clip == currentConsumableClip)
		{
			audioSource.Stop();
		}
		currentConsumableClip = null;
		CollectableItemData selectedSlotItemData2 = itemManager.GetSelectedSlotItemData();
		if (selectedSlotItemData2 == null || (selectedSlotItemData2.itemType != ItemType.Food && selectedSlotItemData2.itemType != ItemType.Drink && selectedSlotItemData2.itemType != ItemType.EatPowerUp && selectedSlotItemData2.itemType != ItemType.DrinkPowerUp))
		{
			itemManager.DeactivateCurrentUnarmedItem();
		}
		else if (selectedSlotItemData2 != selectedSlotItemData)
		{
			itemManager.ActivateUnarmedItem(selectedSlotItemData2);
		}
		itemManager.UpdateConsumableInteraction();
	}

	public void HandlePowerUps(CollectableItemData data)
	{
		if (!data.isInstantUse && powerUpPanel != null)
		{
			powerUpPanel.ActivatePowerUp(data);
		}
		switch (data.powerUpType)
		{
		case PlayerPowerUpType.UnlimitedSprintBoost:
			ActivateTimedPowerUp(data.powerUpType, data.powerUpDuration);
			break;
		case PlayerPowerUpType.DamageBoost:
			ActivateTimedPowerUp(data.powerUpType, data.powerUpDuration);
			break;
		case PlayerPowerUpType.DefenseBoost:
			ActivateTimedPowerUp(data.powerUpType, data.powerUpDuration);
			break;
		case PlayerPowerUpType.HealthRegen:
			ActivateTimedPowerUp(data.powerUpType, data.powerUpDuration);
			break;
		case PlayerPowerUpType.FullHpRestore:
			StartCoroutine(RestoreHealthFast());
			break;
		case PlayerPowerUpType.FullFoodAndWaterRestore:
			StartCoroutine(RestoreFoodAndWaterFast());
			break;
		case PlayerPowerUpType.FullStatusRestore:
			StartCoroutine(RestoreAllStatsFast());
			break;
		}
	}

	private void UpdatePowerUps()
	{
		for (int num = activePowerUps.Count - 1; num >= 0; num--)
		{
			TimedPowerUpData timedPowerUpData = activePowerUps[num];
			timedPowerUpData.remainingDuration -= Time.deltaTime;
			if (timedPowerUpData.remainingDuration <= 0f)
			{
				activePowerUps.RemoveAt(num);
			}
		}
		UpdatePowerUpMultipliers();
	}

	private void UpdatePowerUpMultipliers()
	{
		healthRegenBoostActive = false;
		defenseBoostMultiplier = 1f;
		foreach (TimedPowerUpData activePowerUp in activePowerUps)
		{
			switch (activePowerUp.powerUpType)
			{
			case PlayerPowerUpType.HealthRegen:
				healthRegenBoostActive = true;
				break;
			case PlayerPowerUpType.DefenseBoost:
				defenseBoostMultiplier = defenseBoostAmount;
				break;
			}
		}
	}

	public bool HasActivePowerUp(PlayerPowerUpType powerUpType)
	{
		return activePowerUps.Exists((TimedPowerUpData p) => p.powerUpType == powerUpType);
	}

	public void ClearAllPowerUps()
	{
		activePowerUps.Clear();
		healthRegenBoostActive = false;
		defenseBoostMultiplier = 1f;
		if (powerUpPanel != null)
		{
			powerUpPanel.DeactivateAllPowerUps();
		}
	}

	private void ActivateTimedPowerUp(PlayerPowerUpType powerUpType, float duration)
	{
		TimedPowerUpData timedPowerUpData = activePowerUps.Find((TimedPowerUpData p) => p.powerUpType == powerUpType);
		if (timedPowerUpData != null)
		{
			timedPowerUpData.remainingDuration = duration;
			return;
		}
		TimedPowerUpData item = new TimedPowerUpData
		{
			powerUpType = powerUpType,
			remainingDuration = duration
		};
		activePowerUps.Add(item);
	}

	private IEnumerator RestoreHealthFast()
	{
		float startHealth = playerHpFuel;
		float elapsed = 0f;
		float duration = 1f;
		while (elapsed < duration)
		{
			elapsed += Time.deltaTime;
			playerHpFuel = Mathf.Lerp(startHealth, 100f, elapsed / duration);
			yield return null;
		}
		playerHpFuel = 100f;
	}

	private IEnumerator RestoreFoodAndWaterFast()
	{
		float startFood = playerFoodFuel;
		float startWater = playerWaterFuel;
		float elapsed = 0f;
		float duration = 1f;
		while (elapsed < duration)
		{
			elapsed += Time.deltaTime;
			float t = elapsed / duration;
			playerFoodFuel = Mathf.Lerp(startFood, 100f, t);
			playerWaterFuel = Mathf.Lerp(startWater, 100f, t);
			yield return null;
		}
		playerFoodFuel = 100f;
		playerWaterFuel = 100f;
	}

	private IEnumerator RestoreAllStatsFast()
	{
		float startHealth = playerHpFuel;
		float startFood = playerFoodFuel;
		float startWater = playerWaterFuel;
		float elapsed = 0f;
		float duration = 1f;
		while (elapsed < duration)
		{
			elapsed += Time.deltaTime;
			float t = elapsed / duration;
			playerHpFuel = Mathf.Lerp(startHealth, 100f, t);
			playerFoodFuel = Mathf.Lerp(startFood, 100f, t);
			playerWaterFuel = Mathf.Lerp(startWater, 100f, t);
			yield return null;
		}
		playerHpFuel = 100f;
		playerFoodFuel = 100f;
		playerWaterFuel = 100f;
	}

	private IEnumerator ChromaticFadeIn()
	{
		float elapsed = 0f;
		while (elapsed < chromaticFadeInDuration)
		{
			elapsed += Time.deltaTime;
			float t = elapsed / chromaticFadeInDuration;
			chromaticAberration.intensity.value = Mathf.Lerp(0f, chromaticBaseIntensity, t);
			yield return null;
		}
		chromaticAberration.intensity.value = chromaticBaseIntensity;
		chromaticFadeInCoroutine = null;
		if (chromaticFlashCoroutine == null)
		{
			chromaticFlashCoroutine = StartCoroutine(ChromaticFlashLoop());
		}
	}

	private IEnumerator ChromaticFlashLoop()
	{
		while (true)
		{
			yield return new WaitForSeconds(chromaticFlashInterval);
			float elapsed = 0f;
			while (elapsed < chromaticFlashRiseTime)
			{
				elapsed += Time.deltaTime;
				float t = elapsed / chromaticFlashRiseTime;
				chromaticAberration.intensity.value = Mathf.Lerp(chromaticBaseIntensity, chromaticFlashIntensity, t);
				yield return null;
			}
			elapsed = 0f;
			while (elapsed < chromaticFlashFallTime)
			{
				elapsed += Time.deltaTime;
				float t2 = elapsed / chromaticFlashFallTime;
				chromaticAberration.intensity.value = Mathf.Lerp(chromaticFlashIntensity, chromaticBaseIntensity, t2);
				yield return null;
			}
			chromaticAberration.intensity.value = chromaticBaseIntensity;
		}
	}

	private IEnumerator ChromaticFadeOut()
	{
		float currentValue = chromaticAberration.intensity.value;
		while (currentValue > 0.01f)
		{
			currentValue = Mathf.Lerp(currentValue, 0f, chromaticFadeOutSpeed * Time.deltaTime);
			chromaticAberration.intensity.value = currentValue;
			yield return null;
		}
		chromaticAberration.intensity.value = 0f;
		chromaticFadeOutCoroutine = null;
	}

	public void PlayRandomDamageSound()
	{
		if (!(audioSource == null) && damageSounds != null && damageSounds.Count != 0)
		{
			AudioClip clip = damageSounds[Random.Range(0, damageSounds.Count)];
			audioSource.PlayOneShot(clip);
		}
	}

	public void CheckAndPlayWarningSounds(float foodStatus, float waterStatus)
	{
		if (Time.time - lastWarningSoundTime < warningSoundInterval)
		{
			return;
		}
		bool flag = foodStatus <= playerStatusPanel.foodWarningThreshold;
		bool flag2 = waterStatus <= playerStatusPanel.waterWarningThreshold;
		if (flag && flag2)
		{
			if (lastWasFoodSound)
			{
				PlayWarningSound(lowThirstSound);
				lastWasFoodSound = false;
			}
			else
			{
				PlayWarningSound(lowHungerSound);
				lastWasFoodSound = true;
			}
			lastWarningSoundTime = Time.time;
		}
		else if (flag)
		{
			PlayWarningSound(lowHungerSound);
			lastWarningSoundTime = Time.time;
			lastWasFoodSound = true;
		}
		else if (flag2)
		{
			PlayWarningSound(lowThirstSound);
			lastWarningSoundTime = Time.time;
			lastWasFoodSound = false;
		}
	}

	private void PlayWarningSound(AudioClip clip)
	{
		if (audioSource != null && clip != null)
		{
			audioSource.PlayOneShot(clip);
		}
	}

	public void TriggerLootCameraShake()
	{
		if (!(player == null) && !(player.worldCamera == null))
		{
			Transform parent = player.worldCamera.transform.parent;
			if (parent == null)
			{
				parent = player.worldCamera.transform;
			}
			float num = cameraShakeIntensity * 0.5f;
			parent.DOShakeRotation(cameraShakeDuration * 0.5f, new Vector3(num, num, num), cameraShakeVibrato).SetRelative();
		}
	}

	public void TriggerDamageCameraShake()
	{
		if (player == null || player.worldCamera == null)
		{
			Debug.LogWarning("[CameraShake] Cannot shake - player or worldCamera is NULL!");
			return;
		}
		Transform parent = player.worldCamera.transform.parent;
		if (parent == null)
		{
			parent = player.worldCamera.transform;
		}
		Debug.Log($"[CameraShake] Shaking: {parent.name}, intensity: {cameraShakeIntensity}, duration: {cameraShakeDuration}");
		parent.DOKill();
		parent.DOShakeRotation(cameraShakeDuration, new Vector3(cameraShakeIntensity * 2f, cameraShakeIntensity * 1.5f, cameraShakeIntensity * 1f), cameraShakeVibrato, cameraShakeRandomness).SetRelative();
		if (cameraPhysicsHandler != null && cameraPhysicsHandler.enabled)
		{
			Vector3 rotationForce = new Vector3(Random.Range(-1f, 1f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f)) * cameraShakeIntensity * 15f;
			cameraPhysicsHandler.AddRotationForce(rotationForce);
		}
	}
}
