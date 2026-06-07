using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LightTower
{
	public class EnemyController : Controller, ISavable
	{
		[Serializable]
		private class FEnemyAIData : ISavable
		{
			public EnemyAICondition[] conditions;

			public int abilityIndex;

			public int maxActivations;

			[Savable("currentActivations", true, false)]
			private int currentActivations;

			public int CurrentActivations
			{
				get
				{
					return currentActivations;
				}
				set
				{
					currentActivations = value;
				}
			}

			public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
			{
			}

			public void OnPreLoad()
			{
			}

			public void OnSave()
			{
			}
		}

		private const float MOVEMENT_TICK = 0.02f;

		private const float TRY_USE_ABILITY_TIME = 1f;

		[SerializeField]
		[Savable("globalCooldown", true, false)]
		private float globalCooldown;

		[SerializeField]
		[Savable("AIData", true, false)]
		private FEnemyAIData[] AIData;

		private Enemy enemy;

		private EnemyMovement enemyMovement;

		private AbilityManager abilityManager;

		[Savable("startTime", true, false)]
		private float startTime;

		[Savable("lastAbilityTime", true, false)]
		private float lastAbilityTime;

		[Savable("hasBeenVisible", true, false)]
		private bool hasBeenVisible;

		private Coroutine movementCoroutine;

		private Coroutine useAbilityCoroutine;

		public EnemyMovement EnemyMovement => enemyMovement;

		public float StartTime => startTime;

		private void OnEnable()
		{
			startTime = (float)LTFunctionLibrary.GetTimeManager().GetTimeSeconds();
		}

		public override void Possess(Character newCharacter)
		{
			base.Possess(newCharacter);
			enemyMovement = newCharacter.GetComponent<EnemyMovement>();
			abilityManager = newCharacter.GetComponent<AbilityManager>();
			enemy = newCharacter as Enemy;
			enemy.onEnableChanged += onEnemyEnabledChanged;
			this.StartCoroutineCheckingVar(MovementCoroutine(), ref movementCoroutine);
			if ((bool)abilityManager)
			{
				this.StartCoroutineCheckingVar(UseAbilityCoroutine(), ref useAbilityCoroutine);
			}
		}

		private IEnumerator MovementCoroutine()
		{
			yield return null;
			float counter = 0f;
			while (true)
			{
				counter += Time.deltaTime;
				if (counter > 0.02f)
				{
					EnemyMovement.Move(Vector3.zero, counter);
					counter = 0f;
				}
				yield return null;
			}
		}

		private IEnumerator UseAbilityCoroutine()
		{
			WaitForSeconds abilityWFS = new WaitForSeconds(1f);
			while (true)
			{
				if (enemy.IsEnabled)
				{
					if (!hasBeenVisible)
					{
						hasBeenVisible = LTFunctionLibrary.GetFogOfWarController().IsPositionVisible(base.ControlledCharacter.transform.position);
					}
					else
					{
						DoAI();
					}
				}
				yield return abilityWFS;
			}
		}

		protected virtual void DoAI()
		{
			if (LTFunctionLibrary.GetTimeManager().GetTimeSeconds() - (double)lastAbilityTime < (double)globalCooldown)
			{
				return;
			}
			for (int i = 0; i < AIData.Length; i++)
			{
				if ((abilityManager.GetAbility(AIData[i].abilityIndex + 1) as ActiveAbility).IsInCooldown())
				{
					continue;
				}
				bool flag = true;
				for (int j = 0; j < AIData[i].conditions.Length; j++)
				{
					if ((AIData[i].maxActivations != 0 && AIData[i].CurrentActivations >= AIData[i].maxActivations) || !AIData[i].conditions[j].CheckCondition(this))
					{
						flag = false;
						break;
					}
				}
				if (flag && abilityManager.UseAbility(AIData[i].abilityIndex + 1, default(FActiveAbilityInputData)))
				{
					lastAbilityTime = (float)LTFunctionLibrary.GetTimeManager().GetTimeSeconds();
					AIData[i].CurrentActivations++;
				}
			}
		}

		private void onEnemyEnabledChanged(bool enabled)
		{
			if (enabled)
			{
				this.StartCoroutineCheckingVar(MovementCoroutine(), ref movementCoroutine, stopCoroutineIfRunning: true);
			}
		}
	}
}
