using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengeWaveObjectivesHordeConfig : ChallengeConfig
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign, ImplicitUseTargetFlags.Members)]
		public struct PatientIllnessesRequiredItem
		{
			public int NumPatients;

			public SharedInstance<IllnessDefinition> Illness;
		}

		[UsedImplicitly(ImplicitUseKindFlags.Assign, ImplicitUseTargetFlags.Members)]
		public struct Wave
		{
			public bool BossWave;

			public int NumPatients;

			public int SpawnDurationInDays;

			public float IncomeMultiplier;

			public SharedInstance<ObjectiveDefinition> ObjectiveDefn;

			public PatientIllnessesRequiredItem[] PatientIllnesses;
		}

		[InspectorDivider]
		[InspectorMargin(8)]
		[InspectorHeader("Wave Objectives Horde Config")]
		[SerializeField]
		private string WaveStartAudioEvent;

		[SerializeField]
		private string BossWaveStartAudioEvent;

		[SerializeField]
		private LocalisedString WaveStartAdvisorMessage;

		[SerializeField]
		private LocalisedString WaveFailedAdvisorMessage;

		[UsedImplicitly]
		public string UniqueObjectivesBaseName;

		public int WaveCountdownInDays;

		[SerializeField]
		private Wave[] Waves;

		public string ConstructionSequenceName = "Temple";

		public override Challenge CreateChallenge(Level level)
		{
			return new ChallengeWaveObjectivesHorde(this, level);
		}

		public Wave GetWave(int waveIndex)
		{
			return Waves[Mathf.Clamp(waveIndex, 0, Waves.Length - 1)];
		}

		private static float GetIncomeMultiplier(Wave wave)
		{
			if (!(wave.IncomeMultiplier > 0f))
			{
				return 1f;
			}
			return wave.IncomeMultiplier;
		}

		public void StartWave(Level level, int waveNum, int waveIndex)
		{
			Wave wave = GetWave(waveIndex);
			StartWaveProcessObjective(level, wave, waveNum, waveIndex);
			StartWaveProcessAudio(level, wave, waveNum);
			StartWaveProcessAdvisor(level, wave, waveNum);
			level.FinanceManager.IncomeMultiplier = GetIncomeMultiplier(wave);
		}

		public void EndWave(Level level, ref int waveNum, ref int waveIndex)
		{
			Wave wave = GetWave(waveIndex);
			bool success = false;
			if (level.LevelScriptManager.HasObjectiveExpired(GetUniqueObjectiveName(waveNum), out success))
			{
				waveNum++;
				waveIndex = waveNum;
				if (waveNum >= Waves.Length)
				{
					waveIndex = Random.Range(0, Waves.Length);
				}
			}
			else
			{
				EndWaveFailedProcessAdvisor(level, wave, waveNum);
				level.CharacterManager.ModifiySpawnedPatientCount(wave.NumPatients);
			}
			string uniqueObjectiveName = GetUniqueObjectiveName(waveNum);
			Objective activeObjectiveByUniqueReference = level.LevelScriptManager.GetActiveObjectiveByUniqueReference(uniqueObjectiveName);
			level.LevelScriptManager.DestroyLevelObjective((LevelObjective)activeObjectiveByUniqueReference, bRemoveFromExpiredObjectivesList: true);
		}

		public string GetUniqueObjectiveName(int waveNum)
		{
			return $"{UniqueObjectivesBaseName}{waveNum}";
		}

		private void StartWaveProcessObjective(Level level, Wave wave, int waveNum, int waveIndex)
		{
			bool success = false;
			string uniqueObjectiveName = GetUniqueObjectiveName(waveNum);
			if (level.LevelScriptManager.HasObjectiveExpired(uniqueObjectiveName, out success))
			{
				return;
			}
			Objective activeObjectiveByUniqueReference = level.LevelScriptManager.GetActiveObjectiveByUniqueReference(uniqueObjectiveName);
			if (activeObjectiveByUniqueReference != null)
			{
				level.LevelScriptManager.DestroyLevelObjective((LevelObjective)activeObjectiveByUniqueReference, bRemoveFromExpiredObjectivesList: true);
			}
			level.LevelScriptManager.CreateObjective(uniqueObjectiveName, wave.ObjectiveDefn.Instance, isVisible: false, isDiscovered: true, isReplayable: true, startImmediately: true);
			activeObjectiveByUniqueReference = level.LevelScriptManager.GetActiveObjectiveByUniqueReference(uniqueObjectiveName);
			if (activeObjectiveByUniqueReference == null)
			{
				return;
			}
			foreach (ObjectiveSubGoal subGoal in activeObjectiveByUniqueReference.SubGoals)
			{
				if (subGoal.Definition != null)
				{
					subGoal.Definition.OnceCompleteStayComplete = true;
				}
			}
		}

		private void StartWaveProcessAudio(Level level, Wave wave, int waveNum)
		{
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
		}

		private void StartWaveProcessAdvisor(Level level, Wave wave, int waveNum)
		{
			if (!WaveStartAdvisorMessage.IsNull())
			{
				string message = LocalisedString.Replace(WaveStartAdvisorMessage.Translation, new SubPair[1]
				{
					new SubPair("{[WAVE]}", (waveNum + 1).ToString())
				});
				level.Advisor.PushMessage(new AdvisorMessageDefinition
				{
					Message = message,
					Duration = 10f,
					UserCanDismiss = true
				}, interrupt: false, Advisor.PriorityLevel.Medium);
			}
		}

		private void EndWaveFailedProcessAdvisor(Level level, Wave wave, int waveNum)
		{
			if (!WaveFailedAdvisorMessage.IsNull())
			{
				string message = LocalisedString.Replace(WaveFailedAdvisorMessage.Translation, new SubPair[1]
				{
					new SubPair("{[PROCESSED]}", wave.NumPatients)
				});
				level.Advisor.PushMessage(new AdvisorMessageDefinition
				{
					Message = message,
					Duration = 10f,
					UserCanDismiss = true
				}, interrupt: false, Advisor.PriorityLevel.Medium);
			}
		}
	}
}
