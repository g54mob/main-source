using System;
using Unity.Profiling;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
	public static float MinigameDelta;

	public static float SimulationDelta;

	public static float MenuDelta;

	public static float FlashAnimationValue;

	private static float FlashAnimationProgress;

	public static bool IsProcessingSimulation;

	private static float TAU = MathF.PI * 2f;

	public static float ProgressToNextFixedUpdate;

	public static float SimulationTimeElapsedSinceLastTick;

	public static int debugSpeedMod;

	public static float timeSinceAutosave;

	public static float autosaveIntervalSeconds;

	public static bool isMenuPaused;

	public static bool IsFastForwarding;

	public static int bonusTicksToApply;

	public static int bonusTicksRemaining;

	public static int bonusTicksPerFrameMax;

	public static float overrideSimulationDelta;

	private static float lastFixedUpdateTimestamp;

	private static float lastFlexUpdateTimestamp;

	public const float baselineSimulationDelta = 0.2f;

	public static int totalOfflineSeconds;

	public static int totalEarnedSeconds;

	private static readonly ProfilerMarker ProfileStartSim = new ProfilerMarker(ProfilerCategory.Scripts, "Simulation");

	private static float statsCalcCountdown;

	private static float achievementCalcCountdown;

	private static float displayStatCountdown;

	private static int _timeMode;

	private static int numFastForwards;

	public static int targetSpeedMultiplier;

	private static TimeManager _instance;

	public static float timestampForLastFullSimulation;

	public const bool useRepeatSteps = true;

	public static float repeatSimulationsToRun;

	public static bool isTestingRepeatCapacity;

	private static float accumulatedSimulationTime;

	private const float maxDeltaForSimulation = 0.016f;

	private bool isDisplayStatDataStale;

	public static int timeMode
	{
		get
		{
			return _timeMode;
		}
		set
		{
			if (_timeMode != value)
			{
				accumulatedSimulationTime = 0f;
			}
			_timeMode = value;
			if (_timeMode <= 0)
			{
				numFastForwards = 0;
				targetSpeedMultiplier = 1;
			}
		}
	}

	private bool isGamePaused => timeMode == -1;

	private static GameManager gm => GameManager.Instance;

	private void Awake()
	{
		_instance = this;
	}

	private void Update()
	{
		MenuDelta = Time.deltaTime;
		MinigameDelta = Time.deltaTime * (float)debugSpeedMod;
		if (isMenuPaused)
		{
			MinigameDelta = 0f;
		}
		float num = 1f;
		FlashAnimationProgress = (FlashAnimationProgress + MenuDelta * num) % 1f;
		FlashAnimationValue = Mathf.Sin(FlashAnimationProgress * TAU) * 0.5f + 0.5f;
		if (!isGamePaused && !isMenuPaused && gm.gameState == GameState.InGame)
		{
			float num2 = Time.deltaTime * (float)targetSpeedMultiplier;
			if (timeMode > 0)
			{
				float num3 = GameUtility.AsTruncatedFloat(gm.timeTokenState.currentCount * 60.0);
				if (num2 > num3)
				{
					num2 = num3;
				}
			}
			SimulationTimeElapsedSinceLastTick += num2;
			float num4 = 0.2f / (float)targetSpeedMultiplier;
			if (num4 > 0f)
			{
				ProgressToNextFixedUpdate = Mathf.Clamp01(SimulationTimeElapsedSinceLastTick / num4);
			}
			accumulatedSimulationTime += num2;
			int num5 = 0;
			float num6 = Time.realtimeSinceStartup + 0.016f;
			while (accumulatedSimulationTime >= 0.2f)
			{
				float realtimeSinceStartup = Time.realtimeSinceStartup;
				FixedUpdateSimulation();
				num5++;
				float realtimeSinceStartup2 = Time.realtimeSinceStartup;
				float num7 = realtimeSinceStartup2 - realtimeSinceStartup;
				if (realtimeSinceStartup2 + num7 > num6)
				{
					break;
				}
			}
		}
		achievementCalcCountdown -= MenuDelta;
		if (achievementCalcCountdown <= 0f)
		{
			GameManager.IsQuestAndAchievementProcessFrame = true;
			achievementCalcCountdown += 1f;
		}
		lastFlexUpdateTimestamp = Time.realtimeSinceStartup;
		if (gm != null && gm.gameState == GameState.InGame)
		{
			statsCalcCountdown -= MenuDelta;
			if (statsCalcCountdown <= 0f)
			{
				statsCalcCountdown = 0.2f;
				gm.IncrementAllStats();
			}
			if (autosaveIntervalSeconds > 0f)
			{
				timeSinceAutosave += MenuDelta;
				if (timeSinceAutosave > autosaveIntervalSeconds)
				{
					gm.queueAutoSave = true;
				}
			}
			gm.CheckTimedAchievements();
			gm.UpdateDynamicData();
			if (timeMode != 0 && !GameManager.Instance.isExtraActive)
			{
				gm.EarnTimeTokenSeconds(Time.deltaTime);
			}
			displayStatCountdown -= MenuDelta;
			if (displayStatCountdown <= 0f && isDisplayStatDataStale)
			{
				GameManager.Instance.CalcDisplayStats();
				MenuManager.Instance.FlagAllSimulationDataStale();
				displayStatCountdown = 0.098f;
				if (timeMode >= 1)
				{
					displayStatCountdown = 0.05f;
				}
				isDisplayStatDataStale = false;
			}
		}
		MenuManager.Instance.UpdateVisiblePanels();
		if (gm.queueAutoSave)
		{
			gm.AutoSave();
		}
	}

	public static void FastForward(int seconds)
	{
		IsFastForwarding = true;
		float num = 4f;
		int num2 = Mathf.RoundToInt((float)seconds / num);
		MinigameDelta = num;
		overrideSimulationDelta = 0.2f;
		if (seconds > 2000)
		{
			int num3 = seconds - 2000;
			overrideSimulationDelta += (float)num3 / 5000f;
			if (overrideSimulationDelta > 2f)
			{
				overrideSimulationDelta = 2f;
			}
		}
		bonusTicksToApply = (bonusTicksRemaining = Mathf.RoundToInt((float)seconds / overrideSimulationDelta));
		bonusTicksPerFrameMax = bonusTicksToApply / 100;
		if (bonusTicksPerFrameMax < 50)
		{
			bonusTicksPerFrameMax = 50;
		}
		else if (bonusTicksPerFrameMax > 100)
		{
			bonusTicksPerFrameMax = 100;
		}
	}

	public static void ChangeDebugSpeed(int diff)
	{
		debugSpeedMod += diff;
		debugSpeedMod = Mathf.Clamp(debugSpeedMod, 0, 100);
		MenuManager.Instance.ShowMessage("Changed speed to " + debugSpeedMod);
	}

	public static void TriggerSimulation()
	{
		accumulatedSimulationTime = 0.2f;
		_instance.FixedUpdateSimulation();
	}

	private void FixedUpdateSimulation()
	{
		lastFixedUpdateTimestamp = Time.realtimeSinceStartup;
		SimulationTimeElapsedSinceLastTick = 0f;
		ProgressToNextFixedUpdate = 0f;
		SimulationDelta = 0.2f;
		IsProcessingSimulation = true;
		gm.UpdateSimulation();
		timestampForLastFullSimulation = Time.realtimeSinceStartup;
		float num = accumulatedSimulationTime - 0.2f;
		if (MenuDelta * (float)targetSpeedMultiplier + num > 0.2f)
		{
			repeatSimulationsToRun = num / 0.2f;
			gm.RepeatSimulation();
		}
		else
		{
			repeatSimulationsToRun = 0f;
		}
		gm.PostProcessSimulation();
		gm.PerformSimulationSummary();
		float num2 = repeatSimulationsToRun + 1f;
		if (timeMode > 0)
		{
			float num3 = 0.2f * num2;
			GameManager.Instance.SpendTimeTokens(num3);
		}
		accumulatedSimulationTime -= num2 * 0.2f;
		IsProcessingSimulation = false;
		GameManager.IsQuestAndAchievementProcessFrame = false;
		isDisplayStatDataStale = true;
		if (gm.timeTokenState.currentCount <= 0.0 && timeMode > 0)
		{
			timeMode = 0;
			ShowNoTokensMessage();
		}
	}

	public static void ShowNoTurboModeMessage()
	{
		if (LocalizationManager.IsEnglish())
		{
			MenuManager.Instance.ShowMessage("Turbo mode not available when Extra Active modifier is applied.");
		}
		else
		{
			MenuManager.Instance.ShowMessage(TextDisplay.FormattedKeyValue("GameModifier", TextDisplay.LabelForGameModifier(GameModifier.ExtraActive)));
		}
	}

	public static void ShowTimeModeMessage()
	{
		if (GameManager.GameState == GameState.InGame)
		{
			MenuManager.Instance.ShowMessage(TextDisplay.LabelForTimeMode(_timeMode, 1f));
		}
	}

	public static void ShowNoTokensMessage()
	{
		if (LocalizationManager.IsEnglish())
		{
			MenuManager.Instance.ShowMessage("No more Time Tokens left, Turbo Mode is not available. Reverting to normal speed.");
		}
		else
		{
			MenuManager.Instance.ShowMessage(string.Format(TextDisplay.LocalizedKeyValueFormat(), TextDisplay.LabelForItem(ItemType.TimeToken), TextDisplay.LocalizedNumber(0)));
		}
	}

	public static int TargetSpeedForFastForwards(int num, int mode)
	{
		if (num <= 0)
		{
			return 1;
		}
		if (mode == 1)
		{
			return num switch
			{
				1 => 2, 
				2 => 5, 
				3 => 10, 
				4 => 20, 
				5 => 50, 
				6 => 100, 
				7 => 200, 
				8 => 250, 
				9 => 500, 
				10 => 750, 
				11 => 1000, 
				12 => 2000, 
				_ => 2000, 
			};
		}
		return num switch
		{
			1 => 100, 
			2 => 200, 
			3 => 500, 
			4 => 1000, 
			5 => 2000, 
			6 => 2500, 
			7 => 5000, 
			8 => 10000, 
			9 => 20000, 
			10 => 50000, 
			_ => 50000, 
		};
	}

	public static bool TrySpeedUp(int mode)
	{
		if (GameManager.Instance.timeTokenState.currentCount > 0.0)
		{
			if (mode == timeMode)
			{
				numFastForwards++;
			}
			else
			{
				numFastForwards = 1;
			}
			targetSpeedMultiplier = TargetSpeedForFastForwards(numFastForwards, mode);
			timeMode = mode;
			return true;
		}
		return false;
	}
}
