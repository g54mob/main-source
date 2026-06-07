using System.Collections.Generic;
using I2.Loc;
using UnityEngine;
using UnityEngine.Events;

public class T_Tool : MonoBehaviour
{
	[Header("Info")]
	public string itemName;

	public ItemType itemType;

	[Header("Config")]
	[Min(0.01f)]
	public float speed = 1f;

	public float damage = 1f;

	[Header("Detector Config")]
	[Tooltip("Detector için tarama mesafesi (sadece ItemType.Detector için)")]
	public float scanDistance = 5f;

	[Tooltip("Detector için tarama yarıçapı (sadece ItemType.Detector için)")]
	public float scanRadius = 1f;

	[Header("Audio")]
	[Range(0f, 1f)]
	public float drawVolume = 0.5f;

	public AudioClip drawClip;

	[Range(0f, 1f)]
	public float swingVolume = 0.5f;

	public List<AudioClip> swingClips;

	private AudioSource equipmentSource;

	[Header("Loop Use Sound")]
	public bool useLoopSound;

	public AudioSource useAudioSource;

	[Range(0f, 1f)]
	public float idleVolume = 0.15f;

	public float idlePitch = 1f;

	[Range(0f, 1f)]
	public float useVolume = 0.35f;

	public float usePitch = 1.15f;

	[Min(0.01f)]
	public float volumeLerpSpeed = 2.5f;

	[Min(0.01f)]
	public float pitchLerpSpeed = 2.5f;

	private float _targetLoopVolume;

	private float _targetLoopPitch;

	[Header("Local References")]
	public GameObject viewmodelObject;

	public Animator viewmodelAnimator;

	[Header("Default")]
	public UseAction defaultUseAction;

	public UseAction defaultSecondUseAction = UseAction.onSecondUse;

	[Header("Equip Events")]
	public UnityEvent onEquip;

	[Header("Use Events")]
	public UnityEvent onUse;

	public UnityEvent onSecondUse;

	public UnityEvent onPlace;

	public UnityEvent onThrow;

	[Header("Animation Keys")]
	public string useAnimationKey = "Use";

	public string secondUseAnimationKey = "SecondUse";

	public string mineAnimationKey = "Mine";

	public string drawAnimationKey = "Draw";

	[Header("Animations")]
	public AnimationClip useAnimation;

	public AnimationClip mineAnimation;

	public AnimationClip secondUseAnimation;

	[Header("Cross Action Delay")]
	[Tooltip("OnUse ve OnSecondUse arasındaki minimum bekleme süresi")]
	[Min(0f)]
	public float crossActionDelay = 0.15f;

	[Header("Mine Grace Period")]
	[Tooltip("Madenden çıktıktan sonra hâlâ mine animasyonu oynatılacak süre")]
	[Min(0f)]
	public float mineGracePeriod = 0.3f;

	private float _nextUseReadyTime;

	private float _nextSecondUseReadyTime;

	private float _lastMineTime = float.NegativeInfinity;

	public float TimeUntilNextUse()
	{
		return Mathf.Max(0f, _nextUseReadyTime - Time.time);
	}

	public float TimeUntilNextSecondUse()
	{
		return Mathf.Max(0f, _nextSecondUseReadyTime - Time.time);
	}

	private void Update()
	{
		if (useLoopSound && !(useAudioSource == null))
		{
			bool flag = Time.time < _nextUseReadyTime;
			_targetLoopVolume = (flag ? useVolume : idleVolume);
			_targetLoopPitch = (flag ? usePitch : idlePitch);
			useAudioSource.volume = Mathf.MoveTowards(useAudioSource.volume, _targetLoopVolume, volumeLerpSpeed * Time.deltaTime);
			useAudioSource.pitch = Mathf.MoveTowards(useAudioSource.pitch, _targetLoopPitch, pitchLerpSpeed * Time.deltaTime);
			if (!useAudioSource.isPlaying)
			{
				useAudioSource.Play();
			}
		}
	}

	public void StopUseLoopSound()
	{
		if (useLoopSound && !(useAudioSource == null))
		{
			_nextUseReadyTime = 0f;
			_targetLoopVolume = idleVolume;
			_targetLoopPitch = idlePitch;
		}
	}

	public void OnLocalEnable()
	{
		if (!viewmodelObject)
		{
			return;
		}
		viewmodelObject.SetActive(value: true);
		if (GameManager.Instance != null)
		{
			equipmentSource = GameManager.Instance.localEquipments.toolAudioSource;
		}
		RefreshStatsFromCurrentLevel();
		if (useLoopSound && useAudioSource != null)
		{
			_targetLoopVolume = idleVolume;
			_targetLoopPitch = idlePitch;
			useAudioSource.volume = idleVolume;
			useAudioSource.pitch = idlePitch;
			if (!useAudioSource.isPlaying)
			{
				useAudioSource.Play();
			}
		}
	}

	public void RefreshStatsFromCurrentLevel()
	{
		if (itemType != ItemType.None && itemType != ItemType.Pickup && itemType != ItemType.Building && itemType != ItemType.Hammer && !(PlayerProgressManager.Instance == null))
		{
			int num = PlayerProgressManager.Instance.GetLevel(itemType);
			if (num <= 0)
			{
				num = 1;
			}
			UpdateStatsFromLevel(num);
		}
	}

	public void OnLocalDisable()
	{
		if ((bool)viewmodelObject)
		{
			viewmodelObject.SetActive(value: false);
			if (useLoopSound && useAudioSource != null)
			{
				_targetLoopVolume = idleVolume;
				_targetLoopPitch = idlePitch;
				useAudioSource.volume = idleVolume;
				useAudioSource.pitch = idlePitch;
			}
		}
	}

	public void OnEquip()
	{
		onEquip?.Invoke();
	}

	public void OnUse()
	{
		if (Time.time < _nextUseReadyTime)
		{
			return;
		}
		onUse.Invoke();
		bool flag = itemType == ItemType.Pickaxe || itemType == ItemType.Shovel || itemType == ItemType.Jackhammer;
		bool num = GameManager.Instance.localEquipments.interactionManager.GetCurrentNodeItem() != null;
		bool flag2 = num && flag;
		if (!flag2 && flag && Time.time - _lastMineTime <= mineGracePeriod)
		{
			flag2 = true;
		}
		if (num && flag)
		{
			_lastMineTime = Time.time;
		}
		if (flag2)
		{
			SetLocalAnimation(mineAnimationKey);
		}
		else if (defaultUseAction != UseAction.None)
		{
			SetLocalAnimation(useAnimationKey);
		}
		_nextUseReadyTime = Time.time + ComputeDelay(isSecond: false, flag2);
		float num2 = Time.time + crossActionDelay;
		if (num2 > _nextSecondUseReadyTime)
		{
			_nextSecondUseReadyTime = num2;
		}
		if (useLoopSound && useAudioSource != null)
		{
			_targetLoopVolume = useVolume;
			_targetLoopPitch = usePitch;
			if (!useAudioSource.isPlaying)
			{
				useAudioSource.Play();
			}
		}
		if (itemType == ItemType.Hammer)
		{
			if (!(GameManager.Instance != null) || !(GameManager.Instance.localEquipments != null) || !(GameManager.Instance.localEquipments.buildingInteractionManager != null) || !GameManager.Instance.localEquipments.buildingInteractionManager.InputActive)
			{
				Debug.Log("[T_Tool] Hammer SOL TIK - ExecuteUseLogic çağrılıyor");
				ExecuteUseLogic();
			}
			else
			{
				Debug.Log("[T_Tool] Hammer SOL TIK - Building mode aktif, Hammer işlevi devre dışı");
			}
		}
	}

	public void OnSecondUse()
	{
		if (Time.time < _nextSecondUseReadyTime || itemType == ItemType.Pickaxe || itemType == ItemType.Jackhammer || (itemType == ItemType.Dynamite && !CanDynamiteUse()))
		{
			return;
		}
		onSecondUse.Invoke();
		if (defaultSecondUseAction != UseAction.None)
		{
			SetLocalAnimation(secondUseAnimationKey);
		}
		_nextSecondUseReadyTime = Time.time + ComputeDelay(isSecond: true);
		float num = Time.time + crossActionDelay;
		if (num > _nextUseReadyTime)
		{
			_nextUseReadyTime = num;
		}
		if (itemType == ItemType.Hammer)
		{
			if (!(GameManager.Instance != null) || !(GameManager.Instance.localEquipments != null) || !(GameManager.Instance.localEquipments.buildingInteractionManager != null) || !GameManager.Instance.localEquipments.buildingInteractionManager.InputActive)
			{
				Debug.Log("[T_Tool] Hammer SAĞ TIK - ExecuteSecondUseLogic çağrılıyor");
				ExecuteSecondUseLogic();
			}
			else
			{
				Debug.Log("[T_Tool] Hammer SAĞ TIK - Building mode aktif, iptal için T_Equipments kullanılıyor");
			}
		}
	}

	public void SetLocalAnimation(string animationKey)
	{
		if ((bool)viewmodelAnimator)
		{
			viewmodelAnimator.SetTrigger(animationKey);
			if (swingClips.Count > 0 && equipmentSource != null)
			{
				int index = Random.Range(0, swingClips.Count);
				AudioClip clip = swingClips[index];
				equipmentSource.clip = clip;
				equipmentSource.volume = swingVolume;
				equipmentSource.Play();
			}
		}
	}

	public void RunAnimationOnEquip()
	{
		SetLocalAnimation(drawAnimationKey);
		if (drawClip != null && equipmentSource != null)
		{
			equipmentSource.clip = drawClip;
			equipmentSource.volume = drawVolume;
			equipmentSource.Play();
		}
	}

	public void ExecuteUseLogic()
	{
		if (defaultUseAction != UseAction.onUse)
		{
			return;
		}
		switch (itemType)
		{
		case ItemType.Shovel:
			if (DiggerController.Instance != null)
			{
				DiggerController.Instance.DigAtRayOnce(isDig: true);
			}
			GameManager.Instance.localEquipments.DigableAreaCheck();
			break;
		case ItemType.Pickaxe:
			if (DiggerController.Instance != null)
			{
				DiggerController.Instance.DigAtRayOnce(isDig: true);
			}
			GameManager.Instance.localEquipments.DigableAreaCheck();
			break;
		case ItemType.Jackhammer:
			if (DiggerController.Instance != null)
			{
				DiggerController.Instance.DigAtRayOnce(isDig: true);
			}
			GameManager.Instance.localEquipments.DigableAreaCheck();
			break;
		}
	}

	public void ExecuteSecondUseLogic()
	{
		switch (defaultSecondUseAction)
		{
		case UseAction.onSecondUse:
			onSecondUse.Invoke();
			switch (itemType)
			{
			default:
				_ = 8;
				break;
			case ItemType.Shovel:
				if (DiggerController.Instance != null)
				{
					DiggerController.Instance.DigAtRayOnce(isDig: false);
				}
				GameManager.Instance.localEquipments.DigableAreaCheck();
				break;
			case ItemType.None:
			case ItemType.Pickaxe:
				break;
			}
			break;
		case UseAction.onPlace:
			onPlace.Invoke();
			break;
		case UseAction.onThrow:
			onThrow.Invoke();
			break;
		}
	}

	private float ComputeDelay(bool isSecond, bool isMine = false)
	{
		AnimationClip animationClip = (isSecond ? secondUseAnimation : ((!isMine) ? useAnimation : mineAnimation));
		float num = ((animationClip != null) ? animationClip.length : 0f);
		float num2 = ((viewmodelAnimator != null) ? viewmodelAnimator.speed : 1f);
		float num3 = Mathf.Max(0.01f, num2 * Mathf.Max(0.01f, speed + 0.45f));
		return Mathf.Max(0f, num / num3);
	}

	public void UpdateStatsFromLevel(int level)
	{
		if (UpgradeManager.Instance == null)
		{
			Debug.LogWarning("[T_Tool] UpgradeManager bulunamadı! Tool: " + itemName);
			return;
		}
		if (itemType == ItemType.Detector)
		{
			DetectorLevelEntry detectorStats = UpgradeManager.Instance.GetDetectorStats(level);
			scanDistance = detectorStats.scanDistance;
			scanRadius = detectorStats.scanRadius;
			Debug.Log($"[T_Tool] '{itemName}' detector stats güncellendi => Level: {level}, ScanDistance: {scanDistance}, ScanRadius: {scanRadius}");
			return;
		}
		ToolLevelEntry toolStats = UpgradeManager.Instance.GetToolStats(itemType, level);
		speed = toolStats.speed;
		damage = toolStats.damage;
		if (viewmodelAnimator != null)
		{
			viewmodelAnimator.SetFloat("Speed", toolStats.speed);
		}
		Debug.Log($"[T_Tool] '{itemName}' stats güncellendi => Level: {level}, Speed: {speed}, Damage: {damage}");
	}

	public bool CanDynamiteUse()
	{
		if (ComputerPropertyManager.Instance == null || ComputerPropertyManager.Instance.GetActivePropertyItems() == null || ComputerPropertyManager.Instance.GetActivePropertyItems().Count == 0)
		{
			GameManager.Instance.notificationManager.ShowNotification(LocalizationManager.GetTranslation("Notification_NoDigsiteAvailable"));
			return false;
		}
		if (GetComponent<T_DynamiteManager>().localDynamiteRefs.Count >= GetComponent<T_DynamiteManager>().maxDynamites)
		{
			GameManager.Instance.notificationManager.ShowNotification(LocalizationManager.GetTranslation("Notitication_CantThrowDynamite"));
			return false;
		}
		if (!GameManager.Instance.factoryManager.TryPurchase(GetComponent<T_DynamiteManager>().dynamiteCost, EconomyType.EconomyType_Dynamite))
		{
			if (GameManager.Instance.notificationManager != null)
			{
				GameManager.Instance.notificationManager.ShowNotification(LocalizationManager.GetTranslation("Notification_InsufficientBalance"));
			}
			return false;
		}
		return true;
	}

	[ContextMenu("Set Level 1")]
	public void TestLevel1()
	{
		UpdateStatsFromLevel(1);
	}

	[ContextMenu("Set Level 2")]
	public void TestLevel2()
	{
		UpdateStatsFromLevel(2);
	}

	[ContextMenu("Set Level 3")]
	public void TestLevel3()
	{
		UpdateStatsFromLevel(3);
	}

	[ContextMenu("Set Level 4")]
	public void TestLevel4()
	{
		UpdateStatsFromLevel(4);
	}
}
