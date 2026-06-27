using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Mandragora.Utils;
using Restory.Data.Base;
using Restory.Data.RandomBallsPoolSystems;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;

namespace Restory.Gameplay.RandomBallsPoolSystems
{
	public abstract class RandomBallsPoolSystemBase<TBallSourceObject> : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		[SerializeField]
		private RandomBallsPoolSystemSettingsBase generalSettings;

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool isDebugModeOn;

		private readonly List<RandomBallsPoolBall<TBallSourceObject>> ballsPool = new List<RandomBallsPoolBall<TBallSourceObject>>();

		public TBallSourceObject GetObjectFromRandomBall()
		{
			return GetRandomBall().TargetObject;
		}

		public RandomBallsPoolBall<TBallSourceObject> GetRandomBall()
		{
			if (ballsPool.Count <= generalSettings.RemainingBallsCountToRefillPool)
			{
				RefillPool();
			}
			int index = UnityEngine.Random.Range(0, ballsPool.Count);
			RandomBallsPoolBall<TBallSourceObject> randomBallsPoolBall = ballsPool[index];
			ballsPool.RemoveAt(index);
			if (isDebugModeOn)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("Ball [" + GetBallData(randomBallsPoolBall) + "] taken out.");
				stringBuilder.AppendLine($"Remaining balls ({ballsPool.Count} total):");
				foreach (RandomBallsPoolBall<TBallSourceObject> item in ballsPool)
				{
					stringBuilder.AppendLine(GetBallData(item));
				}
				Debug.Log(stringBuilder.ToString());
			}
			return randomBallsPoolBall;
		}

		public bool TryGetObjectByBallSourceID(int id, out TBallSourceObject ballSourceObject)
		{
			if (!(generalSettings is RandomBallsPoolSystemSettings<TBallSourceObject> randomBallsPoolSystemSettings))
			{
				Debug.LogError("[RandomBallsPoolSystemBase] tried to find BallSource by its ID, but its general settings asset has an incorrect type! Aborting.");
				ballSourceObject = default(TBallSourceObject);
				return false;
			}
			return randomBallsPoolSystemSettings.TryGetObjectByBallSourceID(id, out ballSourceObject);
		}

		private void RefillPool()
		{
			if (!(generalSettings is RandomBallsPoolSystemSettings<TBallSourceObject> randomBallsPoolSystemSettings))
			{
				Debug.LogError("[RandomBallsPoolSystemBase] tried to refill balls pool, but its general settings asset has an incorrect type! Aborting.");
				return;
			}
			randomBallsPoolSystemSettings.RefillBallsPool(ballsPool);
			if (!isDebugModeOn)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Balls pool refilled.");
			stringBuilder.AppendLine($"Balls ({ballsPool.Count} total):");
			foreach (RandomBallsPoolBall<TBallSourceObject> item in ballsPool)
			{
				stringBuilder.AppendLine(GetBallData(item));
			}
			Debug.Log(stringBuilder.ToString());
		}

		private string GetBallData(RandomBallsPoolBall<TBallSourceObject> ball)
		{
			TBallSourceObject targetObject = ball.TargetObject;
			string text = ((targetObject is RestoryEntityInfoBase restoryEntityInfoBase) ? restoryEntityInfoBase.ID : ((!(targetObject is UnityEngine.Object obj)) ? ball.TargetObject.ToString() : obj.name));
			string arg = text;
			return $"BallSourceID - {ball.BallSourceID}; Name - '{arg}'";
		}

		[UsedImplicitly]
		private bool CheckSettingsType()
		{
			return generalSettings is RandomBallsPoolSystemSettings<TBallSourceObject>;
		}

		public object CaptureState()
		{
			try
			{
				if (!(generalSettings is RandomBallsPoolSystemSettings<TBallSourceObject> randomBallsPoolSystemSettings))
				{
					Debug.LogError("[RandomBallsPoolSystemBase] tried to refill balls pool, but its general settings asset has an incorrect type! Aborting.");
					return null;
				}
				return new RandomBallsPoolSystemBaseSaveData
				{
					InitialBalls = randomBallsPoolSystemSettings.GetInitialBallsIdsList().ToArray(),
					RemainingBalls = randomBallsPoolSystemSettings.GetRemainingBallsIdsDictionary(ballsPool)
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				RandomBallsPoolSystemBaseSaveData randomBallsPoolSystemBaseSaveData = DataMigrationWizard.Migrate<RandomBallsPoolSystemBaseSaveData>(state, base.gameObject);
				if (!(generalSettings is RandomBallsPoolSystemSettings<TBallSourceObject> randomBallsPoolSystemSettings))
				{
					Debug.LogError("[RandomBallsPoolSystemBase] tried to refill balls pool, but its general settings asset has an incorrect type! Aborting.");
				}
				else
				{
					randomBallsPoolSystemSettings.RestoreBallsPool(ballsPool, randomBallsPoolSystemBaseSaveData.RemainingBalls, randomBallsPoolSystemBaseSaveData.InitialBalls);
				}
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
