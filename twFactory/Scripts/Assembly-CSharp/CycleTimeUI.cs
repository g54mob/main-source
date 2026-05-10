using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class CycleTimeUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI cycleText;

	[SerializeField]
	private CycleTimeUI_floatingBubble enemiesFloatingBubble;

	[Header("Crystals")]
	[SerializeField]
	private int totalCrystals = 10;

	[SerializeField]
	private CycleTimeUI_crystal smallCrystalPrefab;

	[SerializeField]
	private CycleTimeUI_crystal bigCrystalPrefab;

	[SerializeField]
	private RectTransform crystalsContainer;

	private CycleTimeUI_crystal[] crystals;

	private int nextCrystalIdx;

	private CycleTimeUI_centerController centerController;

	private CycleTimeUI_ticksCircle ticksCircle;

	private TooltipComponent_text timeTooltip;

	private TimeSpan timeSpan;

	private Coroutine updateTimeCoroutine;

	private void Awake()
	{
		centerController = GetComponent<CycleTimeUI_centerController>();
		ticksCircle = GetComponent<CycleTimeUI_ticksCircle>();
		timeTooltip = GetComponent<TooltipComponent_text>();
		SetupCrystals();
	}

	private void OnEnable()
	{
		CyclesManager cyclesManager = LTFunctionLibrary.GetCyclesManager();
		cyclesManager.onCycleChanged = (Action<int, ECycleMode>)Delegate.Combine(cyclesManager.onCycleChanged, new Action<int, ECycleMode>(OnCycleChanged));
		SyncAll();
	}

	private void OnDisable()
	{
		CyclesManager cyclesManager = LTFunctionLibrary.GetCyclesManager();
		cyclesManager.onCycleChanged = (Action<int, ECycleMode>)Delegate.Remove(cyclesManager.onCycleChanged, new Action<int, ECycleMode>(OnCycleChanged));
	}

	private void SetupCrystals()
	{
		crystals = new CycleTimeUI_crystal[totalCrystals];
		for (int i = 0; i < totalCrystals; i++)
		{
			CycleTimeUI_crystal cycleTimeUI_crystal = UnityEngine.Object.Instantiate((i % 2 == 0) ? smallCrystalPrefab : bigCrystalPrefab, crystalsContainer);
			cycleTimeUI_crystal.transform.rotation = Quaternion.Euler(0f, 0f, -360f / (float)totalCrystals * (float)(i + 1));
			crystals[i] = cycleTimeUI_crystal;
		}
	}

	private void SyncAll()
	{
		UpdateCycleText(LTFunctionLibrary.GetCyclesManager().CurrentCycle);
		UpdateCenter(LTFunctionLibrary.GetCyclesManager().CurrentCycleMode, doTransition: false);
		UpdateAllCrystals(LTFunctionLibrary.GetCyclesManager().CurrentCycleMode);
		UpdateTicksCircle(LTFunctionLibrary.GetCyclesManager().CurrentCycleMode);
		UpdateFloatingBubbles();
		if (LTFunctionLibrary.GetCyclesManager().CurrentCycleMode == ECycleMode.Neutral)
		{
			this.StartCoroutineCheckingVar(UpdateTimeCoroutine(), ref updateTimeCoroutine, stopCoroutineIfRunning: true);
			return;
		}
		this.StopCoroutineCheckingVar(ref updateTimeCoroutine);
		timeTooltip.TooltipText = LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_timeUI_tooltip_nightTime", null, FallbackBehavior.UseProjectSettings);
		ticksCircle.SetTicksCircleTime(1f);
	}

	private IEnumerator UpdateTimeCoroutine()
	{
		WaitForFixedUpdate wffu = new WaitForFixedUpdate();
		while (true)
		{
			UpdateTime(LTFunctionLibrary.GetDayPercentTime());
			timeSpan = TimeSpan.FromMilliseconds(LTFunctionLibrary.GetDayRemainingMilliseconds() + 1000);
			timeTooltip.TooltipText = LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_timeUI_tooltip_dayTime", null, FallbackBehavior.UseProjectSettings) + ": " + $"{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
			yield return wffu;
		}
	}

	private void UpdateTime(float dayPercentTime)
	{
		ticksCircle.SetTicksCircleTime(dayPercentTime);
		if (dayPercentTime > (float)(nextCrystalIdx + 1) / (float)totalCrystals)
		{
			crystals[nextCrystalIdx].SetCrystalState(CycleTimeUI_crystal.ECrystalState.Day, 1f, doGlow: true);
			nextCrystalIdx++;
		}
	}

	private void UpdateCycleText(int cycle)
	{
		cycleText.text = (cycle + 1).ToString() ?? "";
	}

	private void UpdateCenter(ECycleMode mode, bool doTransition)
	{
		if (mode == ECycleMode.Neutral)
		{
			centerController.SetCenterState(CycleTimeUI_centerController.ECenterState.Sun, doTransition);
		}
		else
		{
			centerController.SetCenterState(CycleTimeUI_centerController.ECenterState.Moon, doTransition);
		}
	}

	private void UpdateAllCrystals(ECycleMode mode)
	{
		if (mode == ECycleMode.Neutral)
		{
			int num = (nextCrystalIdx = (int)(LTFunctionLibrary.GetDayPercentTime() * (float)crystals.Length));
			for (int i = 0; i < crystals.Length; i++)
			{
				if (i < num)
				{
					crystals[i].SetCrystalState(CycleTimeUI_crystal.ECrystalState.Day, 0f, doGlow: false);
				}
				else
				{
					crystals[i].SetCrystalState(CycleTimeUI_crystal.ECrystalState.None, 0f, doGlow: false);
				}
			}
		}
		else
		{
			CycleTimeUI_crystal[] array = crystals;
			for (int j = 0; j < array.Length; j++)
			{
				array[j].SetCrystalState(CycleTimeUI_crystal.ECrystalState.Night, 0f, doGlow: false);
			}
		}
	}

	private void UpdateTicksCircle(ECycleMode mode)
	{
		if (mode == ECycleMode.Neutral)
		{
			ticksCircle.SetCircleState(CycleTimeUI_ticksCircle.ECircleState.Day, 0f);
		}
		else
		{
			ticksCircle.SetCircleState(CycleTimeUI_ticksCircle.ECircleState.Night, 0f);
		}
	}

	private void UpdateFloatingBubbles()
	{
		float percentage = LTFunctionLibrary.GetSpawnersManager().GetEnemyStartSpawnTime() / (float)LTFunctionLibrary.GetCyclesManager().RoundTime;
		enemiesFloatingBubble.SetBubbleRotation(percentage, 0f);
	}

	private void OnCycleChanged(int cycle, ECycleMode mode)
	{
		UpdateCycleText(cycle);
		UpdateCenter(mode, doTransition: true);
		if (mode == ECycleMode.Neutral)
		{
			ticksCircle.ResetTicksCircle(1.5f);
			this.StartCoroutineCheckingVar(UpdateTimeCoroutine(), ref updateTimeCoroutine, stopCoroutineIfRunning: true);
			CycleTimeUI_crystal[] array = crystals;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetCrystalState(CycleTimeUI_crystal.ECrystalState.None, 1.5f, doGlow: false);
			}
			nextCrystalIdx = 0;
			float percentage = LTFunctionLibrary.GetSpawnersManager().GetEnemyStartSpawnTime() / (float)LTFunctionLibrary.GetCyclesManager().RoundTime;
			enemiesFloatingBubble.SetBubbleRotation(percentage, 2f);
		}
		else
		{
			this.StopCoroutineCheckingVar(ref updateTimeCoroutine);
			ticksCircle.SetCircleState(CycleTimeUI_ticksCircle.ECircleState.Night, 1.5f);
			CycleTimeUI_crystal[] array = crystals;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetCrystalState(CycleTimeUI_crystal.ECrystalState.Night, 1.5f, doGlow: true);
			}
			timeTooltip.TooltipText = LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_timeUI_tooltip_nightTime", null, FallbackBehavior.UseProjectSettings);
		}
	}
}
