using System;
using System.Collections.Generic;
using NSMedieval.State.WorkerJobs;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class Worker : HumanoidBlueprint
	{
		[Serializable]
		public struct CombatModeSettings
		{
			[SerializeField]
			private UnitCombatModeType modeType;

			[SerializeField]
			private string effector;

			[SerializeField]
			private string combatAiAgent;

			public UnitCombatModeType ModeType => modeType;

			public string Effector => effector;

			public string CombatAiAgent => combatAiAgent;
		}

		[Serializable]
		public struct CombatHitXpStruct
		{
			[SerializeField]
			private float meleeHit;

			[SerializeField]
			private float meleeMis;

			[SerializeField]
			private float marksmanHit;

			[SerializeField]
			private float marksmanMiss;

			[SerializeField]
			private float animalHandlingHit;

			[SerializeField]
			private float animalHandlingMiss;

			public float MeleeHit => meleeHit;

			public float MeleeMis => meleeMis;

			public float MarksmanHit => marksmanHit;

			public float MarksmanMiss => marksmanMiss;

			public float AnimalHandlingHit => animalHandlingHit;

			public float AnimalHandlingMiss => animalHandlingMiss;
		}

		[SerializeField]
		private List<CombatModeSettings> combatModes = new List<CombatModeSettings>();

		[SerializeField]
		private float minSleepEffectorTime;

		[SerializeField]
		private CombatHitXpStruct combatHitXp;

		[SerializeField]
		private float idleWarningDelayTime;

		[SerializeField]
		private string afterCrazyEffector;

		[SerializeField]
		private float breakdownChance;

		[SerializeField]
		private float inspiredChance;

		public float IdleWarningDelayTime => idleWarningDelayTime;

		public string AfterCrazyEffector => afterCrazyEffector;

		public List<CombatModeSettings> CombatModes => combatModes;

		public float MinSleepEffectorTime => minSleepEffectorTime;

		public CombatHitXpStruct CombatHitXp => combatHitXp;

		public Vector3 SpawnPosition => new Vector3(56f, 18f, 76f);

		public float BreakdownChance => breakdownChance;

		public float InspiredChance => inspiredChance;
	}
}
