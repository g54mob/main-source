using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengeHordeConfig : ChallengeConfig
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign, ImplicitUseTargetFlags.Members)]
		public struct Wave
		{
			public bool BossWave;

			public int NumPatients;

			public int SpawnDurationInDays;

			public int TargetCureRate;

			public float IncomeMultiplier;
		}

		[InspectorDivider]
		[InspectorMargin(8)]
		[InspectorHeader("Horde Config")]
		[SerializeField]
		private string WaveStartAudioEvent;

		[SerializeField]
		private string BossWaveStartAudioEvent;

		[SerializeField]
		private LocalisedString WaveStartAdvisorMessage;

		[SerializeField]
		private LocalisedString WaveFailedAdvisorMessage;

		[SerializeField]
		private Wave[] Waves;

		public int WaveCountdownInDays;

		public bool UseSeparateStartCountdown;

		[InspectorShowIf("UseSeparateStartCountdown")]
		public int FirstWaveCountdownInDays;

		public int CureStreak;

		[SerializeField]
		private string CureStreakAudioEvent;

		public float CureStreakMoneyMultiplier;

		public string ConstructionSequenceName = "Temple";

		public override Challenge CreateChallenge(Level level)
		{
			return new ChallengeHorde(this, level);
		}

		public Wave GetWave(int index)
		{
			return Waves[Mathf.Clamp(index, 0, Waves.Length - 1)];
		}

		public void StartWave(Level level, int waveIndex)
		{
			Wave wave = GetWave(waveIndex);
			if (wave.BossWave)
			{
				if (!BossWaveStartAudioEvent.IsNullOrEmpty())
				{
					AudioManager.Instance.Play(BossWaveStartAudioEvent);
				}
			}
			else if (!WaveStartAudioEvent.IsNullOrEmpty())
			{
				AudioManager.Instance.Play(WaveStartAudioEvent);
			}
			if (!WaveStartAdvisorMessage.IsNull())
			{
				string message = LocalisedString.Replace(WaveStartAdvisorMessage.Translation, new SubPair[2]
				{
					new SubPair("{[WAVE]}", (waveIndex + 1).ToString()),
					new SubPair("{[TARGET]}", StringUtils.FormatPercentageValue((float)wave.TargetCureRate / 100f))
				});
				level.Advisor.PushMessage(new AdvisorMessageDefinition
				{
					Message = message,
					Duration = 10f,
					UserCanDismiss = true
				}, interrupt: false, Advisor.PriorityLevel.Medium);
			}
		}

		public int EndWave(Level level, int waveIndex, int cured)
		{
			Wave wave = GetWave(waveIndex);
			float num = (float)cured / (float)wave.NumPatients;
			if (Mathf.Round(num * 100f) >= (float)wave.TargetCureRate)
			{
				return waveIndex + 1;
			}
			if (!WaveFailedAdvisorMessage.IsNull())
			{
				string message = LocalisedString.Replace(WaveFailedAdvisorMessage.Translation, new SubPair[4]
				{
					new SubPair("{[CURED]}", cured),
					new SubPair("{[PROCESSED]}", wave.NumPatients),
					new SubPair("{[CURERATE]}", StringUtils.FormatPercentageValue(num)),
					new SubPair("{[TARGET]}", StringUtils.FormatPercentageValue((float)wave.TargetCureRate / 100f))
				});
				level.Advisor.PushMessage(new AdvisorMessageDefinition
				{
					Message = message,
					Duration = 10f,
					UserCanDismiss = true
				}, interrupt: false, Advisor.PriorityLevel.Medium);
			}
			level.CharacterManager.ModifiySpawnedPatientCount(wave.NumPatients);
			return waveIndex;
		}

		private static float GetIncomeMultiplier(Wave wave)
		{
			if (!(wave.IncomeMultiplier > 0f))
			{
				return 1f;
			}
			return wave.IncomeMultiplier;
		}

		public void BeginStreak(Level level, int waveIndex)
		{
			Wave wave = GetWave(waveIndex);
			level.FinanceManager.IncomeMultiplier = CureStreakMoneyMultiplier * GetIncomeMultiplier(wave);
			if (!CureStreakAudioEvent.IsNullOrEmpty())
			{
				AudioManager.Instance.Play(CureStreakAudioEvent);
			}
			if (OnlineManager.IsInitialized() && level.UniqueID == "920")
			{
				PlatformStatsAndAchievements.TriggerAchievement(AchievementId.CuringSpree);
			}
		}

		public void EndStreak(Level level, int waveIndex)
		{
			level.FinanceManager.IncomeMultiplier = GetIncomeMultiplier(GetWave(waveIndex));
		}
	}
}
