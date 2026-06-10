using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
	[Header("Core Stats")]
	public int currentEnergy;

	[Header("Manager References")]
	public Inventory inventory;

	public FishingManager fishingManager;

	public GameGrid gameGrid;

	[Header("UI References")]
	public TMP_Text energyText;

	public TMP_Text moneyText;

	public TMP_Text moneyTextShadow;

	public EndOfDayPanel endOfDayPanel;

	public static bool IsDemoFinished;

	public static PlayerManager Instance;

	public Action onDayEnd;

	public bool dayEnded;

	public event Action<int, int> OnCastsChanged;

	private void Awake()
	{
		if (GameManager.Instance == null)
		{
			Debug.LogWarning("GameManager not found! Redirecting to MenuScene...");
			SceneManager.LoadScene("MenuScene");
		}
		else if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void Start()
	{
		if (!(GameManager.Instance == null) && !(PlayerStats.Instance == null))
		{
			currentEnergy = GetChosenMaxEnergy();
			this.OnCastsChanged?.Invoke(currentEnergy, PlayerStats.Instance.MaxEnergy);
			GameManager.Instance.IncrementDayAndSave();
			if (CutsceneManager.Instance != null)
			{
				CutsceneManager.Instance.TryPlayCutsceneForDay(GameManager.Instance.CurrentDay);
			}
			GameManager instance = GameManager.Instance;
			instance.OnMoneyChanged = (Action<double>)Delegate.Combine(instance.OnMoneyChanged, new Action<double>(UpdateMoneyUI));
			IsDemoFinished = false;
			UpdateUI();
			UpdateMoneyUI(GameManager.Instance.totalMoney);
		}
	}

	public static int GetChosenMaxEnergy()
	{
		int num = PlayerPrefs.GetInt("ChosenMaxEnergy", -1);
		if (num <= 0)
		{
			return 4;
		}
		if (PlayerStats.Instance != null)
		{
			return Mathf.Clamp(num, 1, PlayerStats.Instance.absoluteMaxDailyCasts);
		}
		return num;
	}

	public static void SetChosenMaxEnergy(int amount)
	{
		int num = ((PlayerStats.Instance != null) ? PlayerStats.Instance.absoluteMaxDailyCasts : 100);
		int num2 = Mathf.Clamp(amount, 1, num);
		PlayerPrefs.SetInt("ChosenMaxEnergy", num2);
		PlayerPrefs.Save();
		if (Instance != null && Instance.currentEnergy > num2)
		{
			Instance.currentEnergy = num2;
			Instance.OnCastsChanged?.Invoke(Instance.currentEnergy, num);
			Instance.UpdateUI();
		}
	}

	private void OnDestroy()
	{
		if (GameManager.Instance != null)
		{
			GameManager instance = GameManager.Instance;
			instance.OnMoneyChanged = (Action<double>)Delegate.Remove(instance.OnMoneyChanged, new Action<double>(UpdateMoneyUI));
		}
	}

	private void UpdateMoneyUI(double newTotalMoney)
	{
		LocalizedString localizedString = new LocalizedString("Skills", "#ui.unit.gold");
		moneyText.text = CurrencyFormatter.FormatMoneyPrecise(newTotalMoney) + " " + localizedString.GetLocalizedString();
		if (moneyTextShadow != null)
		{
			moneyTextShadow.text = moneyText.text;
		}
	}

	public void UseEnergy()
	{
		currentEnergy -= PlayerStats.Instance.EnergyCostPerCast;
		this.OnCastsChanged?.Invoke(currentEnergy, PlayerStats.Instance.MaxEnergy);
		AchievementManager.Instance?.NotifyEnergyExpended(PlayerStats.Instance.EnergyCostPerCast);
		UpdateUI();
	}

	public void EndDay()
	{
		if (dayEnded)
		{
			return;
		}
		dayEnded = true;
		fishingManager.enabled = false;
		if (SteamAchievementManager.Instance != null)
		{
			SteamAchievementManager.Instance.NotifyTripEnded(inventory.caughtFish.Count);
		}
		AchievementManager.Instance?.NotifyDayCompleted();
		endOfDayPanel.ShowPanel(this, inventory);
		try
		{
			onDayEnd?.Invoke();
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
	}

	public static void SetDemoFinished(bool finished)
	{
		IsDemoFinished = finished;
	}

	public void UpdateUI()
	{
		energyText.text = $"Energy: {currentEnergy} / {PlayerStats.Instance.MaxEnergy}";
	}

	public void StartNewDay()
	{
		dayEnded = false;
		currentEnergy = GetChosenMaxEnergy();
		inventory.ClearInventory();
		fishingManager.enabled = true;
		endOfDayPanel.gameObject.SetActive(value: false);
		if (CutsceneManager.Instance != null)
		{
			CutsceneManager.Instance.TryPlayCutsceneForDay(GameManager.Instance.CurrentDay);
		}
		if (gameGrid != null)
		{
			gameGrid.CreateBubbleSpots(3);
		}
		UpdateUI();
	}

	public void ReturnToMenu()
	{
		GameManager.Instance.SaveGameData();
		SoundManager.Instance.StopAmbiance();
		SceneTransitionManager.Instance.TransitionToScene("MenuScene");
	}

	public void ReplayDay()
	{
		dayEnded = false;
		SceneTransitionManager.Instance.TransitionToScene(SceneManager.GetActiveScene().name);
	}
}
