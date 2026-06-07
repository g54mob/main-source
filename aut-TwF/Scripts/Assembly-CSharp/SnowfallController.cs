using System;
using System.Linq;
using UnityEngine;

public class SnowfallController : MonoBehaviour
{
	[Serializable]
	public class FSnowfallLevelInfo
	{
		public int level;

		public GameplayEffectData[] GEToApply;
	}

	[SerializeField]
	private int startSnowfallIntensity;

	[SerializeField]
	private int snowfallIntensityPerDay = 1;

	[SerializeField]
	private FSnowfallLevelInfo[] snowafallLevels;

	[SerializeField]
	private GameObject snowfallVFXPrefab;

	private SnowfallVFX snowfallVFX;

	private FSnowfallLevelInfo currentSnowfallLevelInfo;

	private int activeBeacons;

	private int snowfallIntensity;

	private ParticleSystem snowfallParticles;

	public int CurrentSnowfallLevel
	{
		get
		{
			if (CurrentSnowfallLevelInfo == null)
			{
				return 0;
			}
			return CurrentSnowfallLevelInfo.level;
		}
	}

	public int ActiveBeacons
	{
		get
		{
			return activeBeacons;
		}
		set
		{
			activeBeacons = value;
			UpdateSnowfallLevel(snowfallIntensity - activeBeacons);
			this.onActiveBeaconsChanged?.Invoke(activeBeacons);
		}
	}

	public int SnowfallIntensity
	{
		get
		{
			return snowfallIntensity;
		}
		set
		{
			snowfallIntensity = value;
			UpdateSnowfallLevel(snowfallIntensity - activeBeacons);
			this.onSnowfallIntensityChanged?.Invoke(snowfallIntensity);
		}
	}

	public FSnowfallLevelInfo CurrentSnowfallLevelInfo
	{
		get
		{
			return currentSnowfallLevelInfo;
		}
		private set
		{
			FSnowfallLevelInfo fSnowfallLevelInfo = currentSnowfallLevelInfo;
			currentSnowfallLevelInfo = value;
			if (currentSnowfallLevelInfo?.level != fSnowfallLevelInfo?.level)
			{
				ApplySnowfallLevelInfo(currentSnowfallLevelInfo, fSnowfallLevelInfo);
			}
		}
	}

	public FSnowfallLevelInfo[] SnowafallLevels => snowafallLevels;

	public event Action<int> onSnowfallLevelChanged;

	public event Action<int> onSnowfallIntensityChanged;

	public event Action<int> onActiveBeaconsChanged;

	private void Awake()
	{
		Array.Sort(SnowafallLevels, (FSnowfallLevelInfo x, FSnowfallLevelInfo y) => x.level.CompareTo(y.level));
	}

	private void Start()
	{
		if ((bool)LTFunctionLibrary.GetLTGameManager().PlayerCharacter)
		{
			OnPlayerCharacterSpawned(null, null, null, null);
		}
		else
		{
			LTFunctionLibrary.GetLTGameManager().onSpawnPlayer += OnPlayerCharacterSpawned;
		}
	}

	private void UpdateSnowfallLevel(int totalLevel)
	{
		_ = CurrentSnowfallLevelInfo;
		if (SnowafallLevels != null && SnowafallLevels.Length != 0)
		{
			if (totalLevel <= SnowafallLevels[0].level)
			{
				CurrentSnowfallLevelInfo = SnowafallLevels[0];
			}
			else if (totalLevel >= SnowafallLevels[^1].level)
			{
				CurrentSnowfallLevelInfo = SnowafallLevels[^1];
			}
			else
			{
				CurrentSnowfallLevelInfo = SnowafallLevels.First((FSnowfallLevelInfo x) => x.level == totalLevel);
			}
		}
		this.onSnowfallLevelChanged?.Invoke(CurrentSnowfallLevel);
	}

	private void ApplySnowfallLevelInfo(FSnowfallLevelInfo snowfallLevelInfo, FSnowfallLevelInfo oldSnowLevelInfo)
	{
		if (snowfallLevelInfo == null)
		{
			return;
		}
		GameplayEffectsComponent component = LTFunctionLibrary.GetLTGameManager().PlayerCharacter.GetComponent<GameplayEffectsComponent>();
		if (oldSnowLevelInfo != null)
		{
			GameplayEffectData[] gEToApply = oldSnowLevelInfo.GEToApply;
			foreach (GameplayEffectData effectData in gEToApply)
			{
				component.RemoveEffect(effectData);
			}
		}
		if (snowfallLevelInfo != null)
		{
			GameplayEffectData[] gEToApply = snowfallLevelInfo.GEToApply;
			foreach (GameplayEffectData effectData2 in gEToApply)
			{
				component.ApplyEffect(effectData2);
			}
		}
	}

	private void OnPlayerCharacterSpawned(Character playerCharacter, PlayerController playerController, Character oldPlayerCharacter, PlayerController oldPlayerController)
	{
		snowfallVFX = UnityEngine.Object.Instantiate(snowfallVFXPrefab, base.transform.position, Quaternion.identity, base.transform).GetComponent<SnowfallVFX>();
		snowfallVFX.Init(this);
		UpdateSnowfallLevel(snowfallIntensity - activeBeacons);
		CyclesManager cyclesManager = LTFunctionLibrary.GetCyclesManager();
		cyclesManager.onCycleChanged = (Action<int, ECycleMode>)Delegate.Combine(cyclesManager.onCycleChanged, new Action<int, ECycleMode>(OnCycleChanged));
		OnCycleChanged(cyclesManager.CurrentCycle, cyclesManager.CurrentCycleMode);
	}

	private void OnCycleChanged(int cycle, ECycleMode mode)
	{
		SnowfallIntensity = startSnowfallIntensity + cycle * snowfallIntensityPerDay;
	}
}
