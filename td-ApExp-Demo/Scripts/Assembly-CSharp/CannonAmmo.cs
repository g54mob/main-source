using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CannonAmmo : MonoBehaviour
{
	public static CannonAmmo Instance;

	[SerializeField]
	private ModuleCannon cannon;

	[Header("Elements")]
	[SerializeField]
	private float panelExcessHeight;

	[SerializeField]
	private VerticalLayoutGroup bulletsVlg;

	[SerializeField]
	private RectTransform panelRt;

	[SerializeField]
	private RectTransform bulletsRt;

	[SerializeField]
	private RectTransform openingRect;

	[SerializeField]
	private GameObject[] bulletGos;

	[SerializeField]
	private Animator bulletAnim;

	[SerializeField]
	private RectTransform bulletCoverLeft;

	[SerializeField]
	private RectTransform bulletCoverRight;

	[SerializeField]
	private Image reloadLamp;

	[SerializeField]
	private Sprite reloadInProgressSprite;

	[SerializeField]
	private Sprite reloadCompleteSprite;

	[SerializeField]
	private Sprite reloadLampOffSprite;

	[SerializeField]
	private Sprite reloadLampNoAmmoSprite;

	[SerializeField]
	public SlidingUIElement leftCover;

	[SerializeField]
	public SlidingUIElement rightCover;

	[Header("Parameters")]
	[SerializeField]
	private float reloadBlinkingSpeed;

	[SerializeField]
	private float reloadCompleteLampDuration;

	private float max;

	private Coroutine _lampBlinkCoroutine;

	private Coroutine _lampCompleteCoroutine;

	private float lastMissing;

	private bool _bulletLoading;

	private float _bulletTimeShorten = 0.05f;

	private int _bulletShiftTweenId = -1;

	private int _oldMax;

	private float reloadTimePerBullet => cannon.cannon.AdjustedReloadTimePerBullet;

	public static event Action OnReloadReady;

	public static event Action OnReloadComplete;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		GameManager.Instance.JourneyStarted += HandleJourneyStarted;
		GameManager.Instance.JourneyContinued += HandleJourneyContinued;
		LevelManager.Instance.DestinationReached += delegate
		{
			UpdateToMax();
		};
		ModuleCannon moduleByType = Train.Instance.GetModuleByType<ModuleCannon>();
		if (moduleByType == null)
		{
			Debug.Log("CannonAmmo: No ModuleCannon found in the train.");
			return;
		}
		UpgradeManager.Instance.OnAddModule += SubscribeToCannonEvents;
		SubscribeToCannonEvents(moduleByType);
		leftCover.OnSlideInFinished += ReloadReady;
		rightCover.OnSlideInFinished += ReloadReady;
		leftCover.OnSlideOutFinished += ReloadComplete;
		rightCover.OnSlideOutFinished += ReloadComplete;
	}

	private void SubscribeToCannonEvents(Module module)
	{
		if (module is ModuleCannon moduleCannon)
		{
			if (cannon != null)
			{
				cannon.cannon.AmmoChangedTo -= UpdateCurrent;
				cannon.cannon.Upgraded -= Upgraded;
				cannon.cannon.ReloadStart -= HandleCannonReloadStart;
				cannon.cannon.ReloadUpdate -= HandleCannonReloadUpdate;
				cannon.cannon.ReloadComplete -= HandleReloadComplete;
				cannon.cannon.ReloadStoped -= HandleReloadStoped;
				cannon.cannon.ReloadFailed -= HandleReloadFailed;
				cannon.cannon.MagazineFull -= HandleMagazineFull;
				cannon = null;
			}
			cannon = moduleCannon;
			cannon.cannon.AmmoChangedTo += UpdateCurrent;
			cannon.cannon.Upgraded += Upgraded;
			cannon.cannon.ReloadStart += HandleCannonReloadStart;
			cannon.cannon.ReloadUpdate += HandleCannonReloadUpdate;
			cannon.cannon.ReloadComplete += HandleReloadComplete;
			cannon.cannon.ReloadStoped += HandleReloadStoped;
			cannon.cannon.ReloadFailed += HandleReloadFailed;
			cannon.cannon.MagazineFull += HandleMagazineFull;
		}
	}

	private void HandleReloadFailed()
	{
		if (cannon.cannon.CanShoot)
		{
			StartCoroutine(SingleRedLightBlink());
		}
		else
		{
			reloadLamp.sprite = reloadLampNoAmmoSprite;
		}
		IEnumerator SingleRedLightBlink()
		{
			Sprite oldSprite = reloadLamp.sprite;
			reloadLamp.sprite = reloadLampNoAmmoSprite;
			yield return new WaitForSeconds(reloadBlinkingSpeed);
			reloadLamp.sprite = oldSprite;
		}
	}

	private void OnDestroy()
	{
		cannon.cannon.AmmoChangedTo -= UpdateCurrent;
		cannon.cannon.Upgraded -= Upgraded;
		cannon.cannon.ReloadUpdate -= HandleCannonReloadUpdate;
		cannon.cannon.ReloadStart -= HandleCannonReloadStart;
		cannon.cannon.MagazineFull -= HandleMagazineFull;
		cannon.cannon.ReloadComplete -= HandleReloadComplete;
		cannon.cannon.ReloadStoped -= HandleReloadStoped;
		cannon.cannon.AmmoChangedTo -= UpdateCurrent;
		cannon.cannon.Upgraded -= Upgraded;
		cannon.cannon.ReloadUpdate -= HandleCannonReloadUpdate;
	}

	public void Scramble()
	{
		float to = UnityEngine.Random.Range(0f, max) * (2f + bulletsVlg.spacing) + ((max > 20f) ? 1.5f : 0f);
		switch (UnityEngine.Random.Range(0, 3))
		{
		case 0:
			TurnOnNoAmmoLight();
			break;
		case 1:
			BlinkReloadLamp();
			break;
		case 2:
			TurnOnReloadCompleteLight();
			break;
		}
		_ = LeanTween.value(bulletsRt.anchoredPosition.y, to, reloadTimePerBullet - _bulletTimeShorten).setOnUpdate(delegate(float y)
		{
			bulletsRt.anchoredPosition = new Vector2(0f, (float)Math.Round((decimal)y, 1));
		}).id;
	}

	public void Unscramble()
	{
		if (max - lastMissing > 0f)
		{
			TurnOnReloadCompleteLight();
		}
		_bulletLoading = false;
		if (_bulletShiftTweenId >= 0)
		{
			LeanTween.cancel(_bulletShiftTweenId);
		}
		UpdateCurrent(max - lastMissing);
	}

	private void HandleJourneyStarted()
	{
		_bulletLoading = false;
		Upgraded();
	}

	private void HandleJourneyContinued()
	{
		_bulletLoading = false;
		Upgraded();
	}

	private void HandleCannonReloadUpdate(float reloadTimeNorm)
	{
		int num = Mathf.FloorToInt(max * (1f - reloadTimeNorm));
		UpdateCurrent(num);
	}

	public void TurnOnNoAmmoLight()
	{
		reloadLamp.sprite = reloadLampNoAmmoSprite;
	}

	private void HandleCannonReloadStart()
	{
		CloseMagazineCover();
	}

	private void CloseMagazineCover()
	{
		if (_lampCompleteCoroutine != null)
		{
			StopCoroutine(_lampCompleteCoroutine);
		}
		_lampBlinkCoroutine = StartCoroutine(BlinkReloadLamp());
		leftCover.SlideIn();
		rightCover.SlideIn();
	}

	private void HandleMagazineFull()
	{
		OpenMagazineCover();
	}

	private void OpenMagazineCover()
	{
		if (_lampBlinkCoroutine != null)
		{
			StopCoroutine(_lampBlinkCoroutine);
		}
		leftCover.SlideOut();
		rightCover.SlideOut();
	}

	private void HandleReloadComplete(float amount)
	{
		if (amount < cannon.GetUpgradedStatValueByStatType(StatTypes.consumption))
		{
			TurnOnNoAmmoLight();
		}
		else
		{
			TurnOnReloadCompleteLight();
		}
		_bulletLoading = false;
		UpdateCurrent(amount);
	}

	private void HandleReloadStoped()
	{
		TurnOnReloadCompleteLight();
		OpenMagazineCover();
	}

	private void TurnOnReloadCompleteLight()
	{
		reloadLamp.sprite = reloadCompleteSprite;
	}

	private IEnumerator BlinkReloadLamp()
	{
		while (true)
		{
			reloadLamp.sprite = reloadInProgressSprite;
			yield return new WaitForSeconds(reloadBlinkingSpeed);
			reloadLamp.sprite = reloadLampOffSprite;
			yield return new WaitForSeconds(reloadBlinkingSpeed);
		}
	}

	private void UpdateCurrent(float current)
	{
		if (_bulletLoading)
		{
			return;
		}
		_bulletLoading = true;
		float num = max - current;
		if (num > lastMissing)
		{
			bulletAnim.Play("Fire", 0, 0f);
		}
		lastMissing = num;
		if (!HUD.Instance.IsScrambled)
		{
			float to = num * (2f + bulletsVlg.spacing) + ((max > 20f) ? 1.5f : 0f);
			if (current == 0f && !cannon.cannon.CanShoot)
			{
				TurnOnNoAmmoLight();
			}
			_bulletShiftTweenId = LeanTween.value(bulletsRt.anchoredPosition.y, to, reloadTimePerBullet - _bulletTimeShorten).setOnUpdate(delegate(float y)
			{
				bulletsRt.anchoredPosition = new Vector2(0f, (float)Math.Round((decimal)y, 1));
			}).setOnComplete((Action)delegate
			{
				_bulletLoading = false;
			})
				.id;
			if (num == 0f)
			{
				_bulletLoading = false;
			}
		}
	}

	public void UpdateToMax(float duration = 0f)
	{
		_bulletLoading = true;
		if (duration == 0f)
		{
			bulletsRt.anchoredPosition = Vector2.zero;
		}
		else
		{
			_ = LeanTween.value(bulletsRt.anchoredPosition.y, 0f, duration).setOnUpdate(delegate(float y)
			{
				bulletsRt.anchoredPosition = new Vector2(0f, y);
			}).setOnComplete((Action)delegate
			{
				_bulletLoading = false;
			})
				.id;
		}
		_bulletLoading = false;
	}

	private void Upgraded()
	{
		max = (int)cannon.GetUpgradedStatValueByStatType(StatTypes.capacity);
		bulletAnim.SetFloat("FireMult", 1f / reloadTimePerBullet);
		ClearAndSpawnBulletGos(max);
		float size = (2f + bulletsVlg.spacing) * max + panelExcessHeight;
		panelRt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
	}

	private void ClearAndSpawnBulletGos(float max)
	{
		for (int i = 0; i < bulletGos.Length; i++)
		{
			if ((float)i >= max)
			{
				bulletGos[i].SetActive(value: false);
			}
			else
			{
				bulletGos[i].SetActive(value: true);
			}
		}
	}

	private void ReloadReady()
	{
		CannonAmmo.OnReloadReady?.Invoke();
	}

	private void ReloadComplete()
	{
		CannonAmmo.OnReloadComplete?.Invoke();
	}
}
