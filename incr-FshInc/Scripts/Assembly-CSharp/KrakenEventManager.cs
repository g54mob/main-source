using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class KrakenEventManager : MonoBehaviour
{
	[Header("Zone Identity")]
	[Tooltip("Drag in the 'Ocean Trench' ZoneData ScriptableObject.")]
	public ZoneData zoneData;

	[Header("Anomaly Meter UI")]
	[Tooltip("Root GameObject of the entire meter UI. Will be hidden after the event fires.")]
	public GameObject meterRoot;

	[Tooltip("The 4 Image segments of the meter, in order (left to right / 0→3).")]
	public Image[] meterSegments = new Image[4];

	[Tooltip("Color of a filled segment.")]
	public Color segmentFilledColor = new Color(1f, 0.55f, 0f, 1f);

	[Tooltip("Color of an empty segment.")]
	public Color segmentEmptyColor = new Color(0.2f, 0.2f, 0.2f, 0.7f);

	[Header("Cutscene Wiring")]
	[Tooltip("Dialogue that plays BEFORE the Kraken timeline (first time only).")]
	public DialogueSequenceSO preDialogue;

	[Tooltip("The Kraken reveal / boss Timeline asset.")]
	public PlayableAsset krakenTimeline;

	[Tooltip("Dialogue that plays AFTER the Kraken timeline (first time only).")]
	public DialogueSequenceSO postDialogue;

	[Header("Kraken Summon FX")]
	[Tooltip("The water Tilemap whose tint color will lerp when the Kraken is summoned.")]
	public Tilemap waterTilemap;

	[Tooltip("Sound ID registered in SoundManager for the Kraken scream.")]
	[SerializeField]
	private string krakenScreamSoundID = "KrakenScream";

	[Tooltip("Duration of the heavy screen shake when the Kraken is summoned.")]
	[SerializeField]
	private float krakenShakeDuration = 1.2f;

	[Tooltip("Strength of the screen shake when the Kraken is summoned.")]
	[SerializeField]
	private float krakenShakeStrength = 0.6f;

	[Tooltip("How long the water color lerp takes (seconds).")]
	[SerializeField]
	private float waterColorLerpDuration = 2f;

	[Header("Meter Slide-In Animation")]
	[Tooltip("How far right (pixels) the meter starts from before sliding in.")]
	[SerializeField]
	private float meterSlideInOffset = 1400f;

	[Tooltip("How long the slide-in takes in seconds.")]
	[SerializeField]
	private float meterSlideInDuration = 0.7f;

	[Tooltip("Delay before the slide-in starts.")]
	[SerializeField]
	private float meterSlideInDelay = 0.3f;

	[Header("Settings")]
	[Tooltip("How many Legendary fish must be caught to fill the meter.")]
	public int legendariesRequired = 4;

	private static readonly Color WaterColorNormal = new Color(31f / 85f, 1f, 82f / 85f);

	private static readonly Color WaterColorKraken = new Color(0.3019608f, 0.5568628f, 0.7647059f);

	private const string SequenceSeenKey = "KrakenSequenceSeen";

	private const string CaughtKey = "KrakenCaught";

	private int _legendaryCount;

	private bool _krakenCaught;

	private bool _sequenceSeen;

	private bool _waitingForBossCast;

	private Vector2 _meterOriginalPos;

	public static KrakenEventManager Instance { get; private set; }

	public bool IsBossSequenceActive { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private void Start()
	{
		_krakenCaught = PlayerPrefs.GetInt("KrakenCaught", 0) == 1;
		_sequenceSeen = PlayerPrefs.GetInt("KrakenSequenceSeen", 0) == 1;
		AnomalyMeterUI instance = AnomalyMeterUI.Instance;
		if (instance != null)
		{
			meterRoot = instance.gameObject;
			meterSegments = instance.segments;
		}
		if (_krakenCaught)
		{
			if (meterRoot != null)
			{
				meterRoot.SetActive(value: false);
			}
			Debug.Log("[KrakenEventManager] Kraken already caught – meter hidden permanently.");
			return;
		}
		_legendaryCount = 0;
		if (meterRoot != null)
		{
			meterRoot.SetActive(value: true);
			CanvasGroup component = meterRoot.GetComponent<CanvasGroup>();
			if (component != null)
			{
				component.alpha = 1f;
			}
			RectTransform component2 = meterRoot.GetComponent<RectTransform>();
			if (component2 != null)
			{
				_meterOriginalPos = component2.anchoredPosition;
				component2.anchoredPosition = new Vector2(_meterOriginalPos.x + meterSlideInOffset, _meterOriginalPos.y);
				if (CutsceneManager.Instance != null && CutsceneManager.Instance.IsCutsceneActive)
				{
					CutsceneManager.OnCutsceneEnd += SlideInMeter;
				}
				else
				{
					component2.DOAnchorPosX(_meterOriginalPos.x, meterSlideInDuration).SetDelay(meterSlideInDelay).SetEase(Ease.OutBack);
				}
			}
		}
		RefreshMeterUI(animate: false);
		FishLogManager.OnFishLoggedWithData += OnFishLogged;
		Debug.Log($"[KrakenEventManager] Ready – meter reset to 0. SequenceSeen={_sequenceSeen}");
	}

	private void SlideInMeter()
	{
		CutsceneManager.OnCutsceneEnd -= SlideInMeter;
		if (!(meterRoot == null) && meterRoot.activeSelf)
		{
			RectTransform component = meterRoot.GetComponent<RectTransform>();
			if (component != null)
			{
				component.DOAnchorPosX(_meterOriginalPos.x, meterSlideInDuration).SetEase(Ease.OutBack);
			}
		}
	}

	private void OnDestroy()
	{
		FishLogManager.OnFishLoggedWithData -= OnFishLogged;
		CutsceneManager.OnCutsceneEnd -= SlideInMeter;
		if (Instance == this)
		{
			Instance = null;
		}
	}

	private void Update()
	{
		if (!_waitingForBossCast || IsBossSequenceActive || !(FishingManager.Instance != null) || !FishingManager.Instance.IsCasting)
		{
			return;
		}
		_waitingForBossCast = false;
		Bobber currentBobber = FishingManager.Instance.currentBobber;
		if (!(currentBobber != null))
		{
			return;
		}
		currentBobber.onFishBite.RemoveAllListeners();
		currentBobber.onFishBite.AddListener(delegate
		{
			FishingManager.Instance.currentState = FishingManager.FishingState.BiteIndicator;
			KrakenBossFight component = GetComponent<KrakenBossFight>();
			if (component != null)
			{
				StartCoroutine(component.StartBossFight());
			}
			else
			{
				Debug.LogWarning("[KrakenEventManager] No KrakenBossFight component found — skipping reel-in.");
			}
		});
	}

	private void OnFishLogged(CaughtFish fish)
	{
		if (GameManager.Instance == null || GameManager.Instance.currentZone != zoneData || _krakenCaught || IsBossSequenceActive || fish.rarityData == null || fish.rarityData.rarity != FishRarity.Legendary)
		{
			return;
		}
		int num = 1;
		if (fish.isTripleCatch)
		{
			num = 3;
		}
		else if (fish.isDoubleCatch)
		{
			num = 2;
		}
		_legendaryCount += num;
		_legendaryCount = Mathf.Clamp(_legendaryCount, 0, legendariesRequired);
		Debug.Log($"[KrakenEventManager] Legendary caught! +{num} segment(s). Count: {_legendaryCount}/{legendariesRequired}");
		RefreshMeterUI(animate: true);
		if (_legendaryCount >= legendariesRequired)
		{
			Debug.Log("[KrakenEventManager] \ud83d\udea8 Meter FULL! Playing fill animation then triggering cinematic.");
			if (PlayerManager.Instance != null && PlayerManager.Instance.currentEnergy <= 0)
			{
				PlayerManager.Instance.currentEnergy = 1;
				PlayerManager.Instance.UpdateUI();
			}
			StartCoroutine(AnimateMeterFullThenTrigger());
		}
	}

	private IEnumerator AnimateMeterFullThenTrigger()
	{
		IsBossSequenceActive = true;
		RectTransform meterRect = ((meterRoot != null) ? meterRoot.GetComponent<RectTransform>() : null);
		if (meterSegments != null)
		{
			Image[] array = meterSegments;
			foreach (Image image in array)
			{
				if (image != null)
				{
					image.transform.DOPunchScale(Vector3.one * 0.35f, 0.4f, 8, 0.5f);
				}
			}
		}
		yield return new WaitForSeconds(0.25f);
		if (meterRect != null)
		{
			meterRect.DOShakeAnchorPos(0.55f, new Vector2(18f, 8f), 14, 60f);
		}
		yield return new WaitForSeconds(0.65f);
		if (meterRect != null)
		{
			meterRect.DOAnchorPosX(_meterOriginalPos.x + 1400f, 0.5f).SetEase(Ease.InBack);
			yield return new WaitForSeconds(0.55f);
		}
		if (meterRoot != null)
		{
			meterRoot.SetActive(value: false);
		}
		StartCoroutine(TriggerKrakenEventSequence());
	}

	private IEnumerator TriggerKrakenEventSequence()
	{
		IsBossSequenceActive = true;
		Debug.Log("[KrakenEventManager] ▶ Triggering Kraken event sequence!");
		if (FishCaughtAlert.Instance != null)
		{
			FishCaughtAlert.Instance.ForceHide();
		}
		SoundManager.PlaySound(krakenScreamSoundID);
		if (CameraController.Instance != null && CameraController.Instance.cam != null)
		{
			CameraController.Instance.cam.transform.DOShakePosition(krakenShakeDuration, krakenShakeStrength, 12).SetId("CameraShake");
		}
		if (waterTilemap != null)
		{
			waterTilemap.color = WaterColorNormal;
			DOTween.To(() => waterTilemap.color, delegate(Color x)
			{
				waterTilemap.color = x;
			}, WaterColorKraken, waterColorLerpDuration).SetEase(Ease.InOutSine);
		}
		yield return new WaitForSeconds(0.5f);
		if (!_sequenceSeen)
		{
			if (preDialogue != null && DialogueManager.Instance != null)
			{
				yield return StartCoroutine(PlayDialogueAndWait(preDialogue));
			}
			if (krakenTimeline != null && CutsceneManager.Instance != null)
			{
				CutsceneEntry cutsceneEntry = new CutsceneEntry
				{
					timelineAsset = krakenTimeline,
					preDialogue = null,
					postDialogue = null,
					playOnce = false,
					skippable = true,
					blockFishing = true,
					showCinematicBars = true,
					hideUI = true
				};
				CutsceneManager.Instance.PlayCutscene(cutsceneEntry);
				yield return new WaitUntil(() => !CutsceneManager.Instance.IsCutsceneActive);
			}
			if (postDialogue != null && DialogueManager.Instance != null)
			{
				yield return StartCoroutine(PlayDialogueAndWait(postDialogue));
			}
			_sequenceSeen = true;
			PlayerPrefs.SetInt("KrakenSequenceSeen", 1);
			PlayerPrefs.Save();
		}
		else if (krakenTimeline != null && CutsceneManager.Instance != null)
		{
			CutsceneEntry cutsceneEntry2 = new CutsceneEntry
			{
				timelineAsset = krakenTimeline,
				preDialogue = null,
				postDialogue = null,
				playOnce = false,
				skippable = true,
				blockFishing = true,
				showCinematicBars = true,
				hideUI = true
			};
			CutsceneManager.Instance.PlayCutscene(cutsceneEntry2);
			yield return new WaitUntil(() => !CutsceneManager.Instance.IsCutsceneActive);
		}
		_waitingForBossCast = true;
		IsBossSequenceActive = false;
		HideMeterForSession();
		FishLogManager.OnFishLoggedWithData -= OnFishLogged;
		Debug.Log("[KrakenEventManager] ✅ Sequence complete – waiting for player cast.");
	}

	public void MarkKrakenCaught()
	{
		_krakenCaught = true;
		_waitingForBossCast = false;
		PlayerPrefs.SetInt("KrakenCaught", 1);
		PlayerPrefs.Save();
		Debug.Log("[KrakenEventManager] ✅ Kraken caught – meter permanently disabled.");
	}

	public void ResetReadyForKraken()
	{
		_waitingForBossCast = false;
	}

	private void RefreshMeterUI(bool animate)
	{
		if (meterSegments == null)
		{
			return;
		}
		AnomalyMeterUI instance = AnomalyMeterUI.Instance;
		int num = meterSegments.Length;
		for (int i = 0; i < num; i++)
		{
			if (meterSegments[i] == null)
			{
				continue;
			}
			bool flag = i < _legendaryCount;
			if (instance != null)
			{
				if (flag && animate)
				{
					instance.AnimateFill(i, num);
				}
				else if (flag)
				{
					instance.SetFilled(i, num);
				}
				else
				{
					instance.SetEmpty(i, segmentEmptyColor);
				}
			}
			else
			{
				meterSegments[i].color = (flag ? segmentFilledColor : segmentEmptyColor);
			}
		}
	}

	private void HideMeterForSession()
	{
		if (!(meterRoot == null) && meterRoot.activeSelf)
		{
			CanvasGroup canvasGroup = meterRoot.GetComponent<CanvasGroup>();
			if (canvasGroup == null)
			{
				canvasGroup = meterRoot.AddComponent<CanvasGroup>();
			}
			canvasGroup.DOFade(0f, 0.6f).OnComplete(delegate
			{
				meterRoot.SetActive(value: false);
			});
		}
	}

	private IEnumerator PlayDialogueAndWait(DialogueSequenceSO sequence)
	{
		bool done = false;
		DialogueManager.OnDialogueEnd += OnEnd;
		DialogueManager.Instance.ShowDialogue(sequence);
		yield return new WaitUntil(() => done);
		DialogueManager.OnDialogueEnd -= OnEnd;
		void OnEnd()
		{
			done = true;
		}
	}

	[ContextMenu("DEBUG: Reset Kraken Event (Full)")]
	public void Debug_ResetKrakenEvent()
	{
		PlayerPrefs.DeleteKey("KrakenSequenceSeen");
		PlayerPrefs.DeleteKey("KrakenCaught");
		PlayerPrefs.Save();
		_krakenCaught = false;
		_sequenceSeen = false;
		_legendaryCount = 0;
		if (meterRoot != null)
		{
			meterRoot.SetActive(value: true);
			CanvasGroup component = meterRoot.GetComponent<CanvasGroup>();
			if (component != null)
			{
				component.alpha = 1f;
			}
		}
		FishLogManager.OnFishLoggedWithData -= OnFishLogged;
		FishLogManager.OnFishLoggedWithData += OnFishLogged;
		RefreshMeterUI(animate: false);
		Debug.Log("[KrakenEventManager] DEBUG: Full reset (count=0, sequenceSeen=false, caught=false).");
	}

	[ContextMenu("DEBUG: Mark Sequence Seen (simulate repeat visit)")]
	public void Debug_MarkSequenceSeen()
	{
		_sequenceSeen = true;
		PlayerPrefs.SetInt("KrakenSequenceSeen", 1);
		PlayerPrefs.Save();
		Debug.Log("[KrakenEventManager] DEBUG: SequenceSeen=true – next trigger will be cutscene-only.");
	}

	[ContextMenu("DEBUG: Simulate Legendary Catch")]
	public void Debug_SimulateLegendaryCatch()
	{
		if (_krakenCaught || IsBossSequenceActive)
		{
			return;
		}
		_legendaryCount++;
		_legendaryCount = Mathf.Clamp(_legendaryCount, 0, legendariesRequired);
		if (FishCaughtAlert.Instance != null && GameManager.Instance != null && GameManager.Instance.currentZone != null && GameManager.Instance.currentZone.possibleCatches != null && GameManager.Instance.currentZone.possibleCatches.Count > 0)
		{
			Fish fishSpecies = GameManager.Instance.currentZone.possibleCatches[0].fishSpecies;
			RarityData rarityData = fishSpecies.GetRarityData(FishRarity.Legendary) ?? fishSpecies.GetRarityData(FishRarity.Common);
			if (rarityData != null)
			{
				FishCaughtAlert.TriggerAlert(new CaughtFish(fishSpecies, rarityData), 1, 0f, 100, isFinalCatch: false);
			}
		}
		Debug.Log($"[KrakenEventManager] DEBUG Simulate: count now {_legendaryCount}/{legendariesRequired}");
		RefreshMeterUI(animate: true);
		if (_legendaryCount >= legendariesRequired)
		{
			Debug.Log("[KrakenEventManager] \ud83d\udea8 Meter FULL! (Simulated) Playing fill animation then triggering cinematic.");
			StartCoroutine(AnimateMeterFullThenTrigger());
		}
	}
}
