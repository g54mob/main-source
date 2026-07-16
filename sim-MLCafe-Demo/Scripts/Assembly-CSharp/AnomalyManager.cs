using System.Collections.Generic;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{
	public AnomalyEffect activeEffect;

	private bool anomaliesActivated;

	private bool positiveAnomalies;

	private bool negativeAnomalies;

	private bool isAnomalyActive;

	private int daysGone;

	private int anomalyDuration = 1;

	private AnomalyEffectLibrary library = new AnomalyEffectLibrary();

	private AnomalyProperties anomalyProperties = new AnomalyProperties();

	private static AnomalyManager instance;

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
		WorldTime.instance.OnBeginDay.AddListener(delegate
		{
			daysGone++;
		});
	}

	public static AnomalyProperties GetAnomalyProperties()
	{
		return instance.anomalyProperties;
	}

	public static AnomalyEffect GetActiveEffect()
	{
		return instance.activeEffect;
	}

	public static bool IsAnomalyActive()
	{
		return instance.isAnomalyActive;
	}

	public static int DaysSinceActivation()
	{
		return instance.daysGone;
	}

	public static int GetAnomalyDuration()
	{
		return instance.anomalyDuration;
	}

	private void Start()
	{
		anomaliesActivated = GameModeManager.GetGameModeValue<bool>("gm_anomaly_enabled");
		if (anomaliesActivated)
		{
			InitAnomalies();
		}
	}

	private void InitAnomalies()
	{
		library = new AnomalyEffectLibrary();
		positiveAnomalies = GameModeManager.GetGameModeValue<bool>("gm_anomaly_posiive_enabled");
		negativeAnomalies = GameModeManager.GetGameModeValue<bool>("gm_anomaly_negative_enabled");
		anomalyDuration = GameModeManager.GetGameModeValue<int>("gm_anomaly_duration");
	}

	public static bool TriggerNewAnomalyEvent()
	{
		int num = Random.Range(0, 100);
		int gameModeValue = GameModeManager.GetGameModeValue<int>("gm_anomaly_effect_chance");
		return num < gameModeValue;
	}

	[ContextMenu("RollEffect")]
	public static void RollEffect()
	{
		if (instance.positiveAnomalies)
		{
			_ = 100 / GameModeManager.GetGameModeValue<int>("gm_anomaly_positive_chance");
		}
		if (instance.negativeAnomalies)
		{
			_ = 100 / GameModeManager.GetGameModeValue<int>("gm_anomaly_negative_chance");
		}
		List<AnomalyEffect> list = new List<AnomalyEffect>();
		if (instance.positiveAnomalies)
		{
			AnomalyEffect[] positiveEffects = instance.library.GetPositiveEffects();
			foreach (AnomalyEffect item in positiveEffects)
			{
				list.Add(item);
			}
		}
		if (instance.negativeAnomalies)
		{
			AnomalyEffect[] positiveEffects = instance.library.GetNegativeEffects();
			foreach (AnomalyEffect item2 in positiveEffects)
			{
				list.Add(item2);
			}
		}
		if (list.Count == 0)
		{
			Debug.LogError("NO ANOMALY EFFECTS ADDED!");
			return;
		}
		int num = Random.Range(0, list.Count);
		if (num >= list.Count)
		{
			num--;
		}
		if (num < 0)
		{
			num = 0;
		}
		AnomalyEffect anomalyEffect = list[num];
		Debug.Log("Anomaly Roll: effect-> " + anomalyEffect.effectType.ToString() + " | number-> " + anomalyEffect.index);
		instance.ApplyAnomalyEffect(anomalyEffect);
	}

	private void ApplyAnomalyEffect(AnomalyEffect anomalyEffect)
	{
		activeEffect = anomalyEffect;
		activeEffect.isActive = true;
		activeEffect.OnEffectEvent()();
		isAnomalyActive = true;
	}

	public static void EndAnomalyEffect()
	{
		instance.daysGone = 0;
		instance.isAnomalyActive = false;
		SoundManager.PlaySoundOnce("darkroom_anomaly_vanish");
	}
}
