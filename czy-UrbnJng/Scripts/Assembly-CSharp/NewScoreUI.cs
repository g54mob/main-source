using System;
using System.Collections;
using DG.Tweening;
using Infrastructure.Services;
using Infrastructure.Services.CoinService;
using Infrastructure.Services.PersistentProgress;
using NewGameplayScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewScoreUI : MonoBehaviour, ISavedProgressReader
{
	[SerializeField]
	private TextMeshProUGUI scoreText;

	[SerializeField]
	private TextMeshProUGUI maxScoreText;

	[SerializeField]
	private Image progressPermanentImage;

	[SerializeField]
	private Image progressTemporaryAdd;

	[SerializeField]
	private Image progressTemporarySubtract;

	[SerializeField]
	private Transform scaleTransform;

	[SerializeField]
	private ParticleSystem particlesTemplate;

	[SerializeField]
	private GameObject coinInfo;

	private int currentScore;

	private int maxScore;

	private int previousMaxScore;

	private int levelScore;

	private int newScore;

	public int countFPS = 30;

	public float duration = 1f;

	private float frameRate;

	private bool TurnOnTemporaryProgress;

	private bool IsTutorialScoreToReach;

	public Action<bool> OnMaxScoreReached;

	private Sequence triggerAnimation;

	private bool canCount;

	private bool isParticlesSpawned;

	private bool isParticlesOnTarget;

	private bool isParticlesOnPlants;

	private IEnumerator coroutineCounting;

	private IEnumerator coroutineProgressBar;

	private IEnumerator coroutineText;

	public static NewScoreUI Instance { get; private set; }

	public event EventHandler OnLevelScoreReached;

	public event EventHandler OnTutorialScoreReached;

	private void Awake()
	{
		Instance = this;
		previousMaxScore = 0;
		frameRate = duration * (float)countFPS;
	}

	private void Start()
	{
		ParticlesManagerUI.Instance.OnParticlesSpawnAtTarget += ParticlesManager_OnParticlesSpawnAtTarget;
		ParticlesManagerUI.Instance.OnParticleHitTarget += ParticlesManager_OnParticleHitTarget;
		TotalScoreCalculator.Instance.OnTotalScoreChanged += TotalScoreCalculator_OnTotalScoreChanged;
		MovementSystem.Instance.OnStartMovingItem += MovementSystem_OnStartMovingItem;
		levelScore = CollectionManager.Instance.GetScoreMax();
	}

	private void OnDestroy()
	{
		ParticlesManagerUI.Instance.OnParticlesSpawnAtTarget -= ParticlesManager_OnParticlesSpawnAtTarget;
		ParticlesManagerUI.Instance.OnParticleHitTarget -= ParticlesManager_OnParticleHitTarget;
		TotalScoreCalculator.Instance.OnTotalScoreChanged -= TotalScoreCalculator_OnTotalScoreChanged;
		MovementSystem.Instance.OnStartMovingItem -= MovementSystem_OnStartMovingItem;
	}

	private void Update()
	{
		if (TurnOnTemporaryProgress)
		{
			TotalScoreCalculator.Instance.CalculateTotalScore();
			(bool, Plant) movingPlant = MovementSystem.Instance.GetMovingPlant();
			int num = 0;
			if (movingPlant.Item1)
			{
				num = movingPlant.Item2.GetScore();
			}
			UpdateTemporaryProgressBar(TotalScoreCalculator.Instance.GetTotalScore() + num);
		}
	}

	private void MovementSystem_OnStartMovingItem(object sender, EventArgs e)
	{
		if (coroutineCounting != null)
		{
			StopCurrentCoroutines();
		}
	}

	private void TotalScoreCalculator_OnTotalScoreChanged(object sender, EventArgs e)
	{
		newScore = TotalScoreCalculator.Instance.GetTotalScore();
		if (newScore >= maxScore)
		{
			OnMaxScoreReached?.Invoke(coinInfo.activeInHierarchy);
			if (newScore < levelScore || maxScore == levelScore)
			{
				if (maxScore >= levelScore)
				{
					coinInfo.SetActive(value: false);
				}
				AllServices.Container.Single<ICoinService>().AddCoin(1);
			}
		}
		coroutineCounting = StartCounting(currentScore >= newScore);
		StartCoroutine(coroutineCounting);
	}

	private void ParticlesManager_OnParticlesSpawnAtTarget(object sender, EventArgs e)
	{
		TriggerScore();
	}

	private void ParticlesManager_OnParticleHitTarget(object sender, EventArgs e)
	{
		TriggerScore();
		UnityEngine.Object.Instantiate(particlesTemplate, particlesTemplate.transform.parent).Play();
	}

	private void StopCurrentCoroutines()
	{
		if (coroutineCounting != null)
		{
			StopCoroutine(coroutineCounting);
		}
		if (coroutineProgressBar != null)
		{
			StopCoroutine(coroutineProgressBar);
		}
		if (coroutineText != null)
		{
			StopCoroutine(coroutineText);
		}
		currentScore = newScore;
		if (currentScore >= maxScore)
		{
			previousMaxScore = maxScore;
			maxScore = ProgressManager.Instance.GetNextScoreToUnlock();
		}
		if (maxScore - previousMaxScore != 0)
		{
			UpdateProgressBar(newScore - previousMaxScore, maxScore - previousMaxScore);
		}
		UpdateScore(newScore);
		UpdateMaxScore(maxScore);
	}

	private IEnumerator StartCounting(bool isDecreased)
	{
		if (!isDecreased)
		{
			yield return new WaitForSeconds(0.75f);
		}
		while (newScore >= maxScore)
		{
			coroutineProgressBar = CountProgressBar(maxScore);
			coroutineText = CountText(maxScore);
			StartCoroutine(coroutineProgressBar);
			yield return StartCoroutine(coroutineText);
			previousMaxScore = maxScore;
			maxScore = ProgressManager.Instance.GetNextScoreToUnlock();
			UpdateScore(currentScore);
			this.OnTutorialScoreReached?.Invoke(this, EventArgs.Empty);
			if (IsTutorialScoreToReach)
			{
				IsTutorialScoreToReach = false;
			}
			if (currentScore >= levelScore)
			{
				coinInfo.SetActive(value: false);
				this.OnLevelScoreReached?.Invoke(this, EventArgs.Empty);
			}
		}
		coroutineProgressBar = CountProgressBar(newScore);
		coroutineText = CountText(newScore);
		StartCoroutine(coroutineProgressBar);
		yield return StartCoroutine(coroutineText);
		canCount = false;
		isParticlesSpawned = false;
	}

	private void UpdateProgressBar(float fillAmount, float fillAmountMax)
	{
		if (fillAmount >= fillAmountMax && maxScore < levelScore)
		{
			fillAmount = 0f;
		}
		if (fillAmountMax != 0f)
		{
			progressPermanentImage.fillAmount = fillAmount / fillAmountMax;
		}
		else
		{
			progressPermanentImage.fillAmount = 0f;
		}
	}

	private void UpdateTemporaryProgressBar(float fillAmount)
	{
		float num = 0f;
		float num2 = 0f;
		if (maxScore - previousMaxScore != 0)
		{
			num = (fillAmount - (float)previousMaxScore) / (float)(maxScore - previousMaxScore);
			num2 = (float)(currentScore - previousMaxScore) / (float)(maxScore - previousMaxScore);
		}
		progressTemporaryAdd.fillAmount = num;
		progressTemporarySubtract.fillAmount = num2;
		progressPermanentImage.fillAmount = ((fillAmount < (float)currentScore) ? num : num2);
	}

	private void UpdateScore(int score)
	{
		scoreText.text = score.ToString();
		maxScoreText.text = "/" + maxScore;
	}

	public void UpdateMaxScore(int newMaxScore)
	{
		maxScore = newMaxScore;
		maxScoreText.text = "/" + maxScore;
	}

	private IEnumerator CountProgressBar(int newScore)
	{
		WaitForSeconds Wait = new WaitForSeconds(1f / (float)countFPS);
		int maxValue = maxScore - previousMaxScore;
		int currentValue = currentScore - previousMaxScore;
		int newValue = newScore - previousMaxScore;
		int scoreDelta = newScore - currentScore;
		int stepAmount = ((scoreDelta < 0) ? Mathf.FloorToInt((float)scoreDelta / frameRate) : Mathf.CeilToInt((float)scoreDelta / frameRate));
		while (currentValue != newValue)
		{
			if (scoreDelta > 0 && currentValue >= maxValue)
			{
				currentValue = 0;
				newValue -= maxValue;
				maxValue = ProgressManager.Instance.GetNextScoreToUnlock() - previousMaxScore;
			}
			currentValue += stepAmount;
			if (Mathf.Sign(scoreDelta) * (float)(newValue - currentValue) <= 0f)
			{
				currentValue = newValue;
			}
			UpdateProgressBar(currentValue, maxValue);
			yield return Wait;
		}
	}

	private IEnumerator CountText(int newScore)
	{
		WaitForSeconds Wait = new WaitForSeconds(1f / (float)countFPS);
		int scoreDelta = newScore - currentScore;
		int stepAmount = ((scoreDelta < 0) ? Mathf.FloorToInt((float)scoreDelta / frameRate) : Mathf.CeilToInt((float)scoreDelta / frameRate));
		while (currentScore != newScore)
		{
			currentScore += stepAmount;
			if (Mathf.Sign(scoreDelta) * (float)(newScore - currentScore) <= 0f)
			{
				currentScore = newScore;
			}
			UpdateScore(currentScore);
			yield return Wait;
		}
	}

	public void StartPlantMoving()
	{
		isParticlesOnTarget = false;
		isParticlesOnPlants = false;
		progressTemporaryAdd.gameObject.SetActive(value: true);
		progressTemporarySubtract.gameObject.SetActive(value: true);
		TurnOnTemporaryProgress = true;
	}

	public void StopPlantMoving()
	{
		progressTemporaryAdd.gameObject.SetActive(value: false);
		progressTemporarySubtract.gameObject.SetActive(value: false);
		TurnOnTemporaryProgress = false;
	}

	public void StartTutorial()
	{
		IsTutorialScoreToReach = true;
	}

	public void Show()
	{
		base.gameObject.SetActive(value: true);
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	public int GetCurrentScore()
	{
		return currentScore;
	}

	public int GetCurrentMaxScore()
	{
		return maxScore;
	}

	public void TriggerScore()
	{
		SoundManager.Instance.OnRecievePoints();
		triggerAnimation.Kill();
		triggerAnimation = DOTween.Sequence();
		triggerAnimation.Append(scaleTransform.DOScale(0.9f, 0.05f).SetEase(Ease.InOutSine)).Append(scaleTransform.DOScale(1.1f, 0.1f).SetEase(Ease.InOutSine)).Append(scaleTransform.DOScale(1f, 0.1f).SetEase(Ease.InOutSine))
			.Play();
	}

	public void LoadProgress(PlayerProgress progress)
	{
		if (!progress.CreativeMode)
		{
			currentScore = progress.Score;
			UpdateScore(currentScore);
			UpdateProgressBar(currentScore, maxScore);
			if (currentScore >= levelScore)
			{
				this.OnLevelScoreReached?.Invoke(this, EventArgs.Empty);
			}
			if (currentScore >= levelScore)
			{
				coinInfo.SetActive(value: false);
			}
		}
	}
}
