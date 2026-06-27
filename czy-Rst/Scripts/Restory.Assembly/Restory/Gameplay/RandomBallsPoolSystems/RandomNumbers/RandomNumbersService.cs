using System;
using System.Collections.Generic;
using System.Text;
using Mandragora.Utils;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;

namespace Restory.Gameplay.RandomBallsPoolSystems.RandomNumbers
{
	public sealed class RandomNumbersService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool isDebugModeOn;

		private readonly List<int> availableNumbers = new List<int>();

		public int GetRandomNumber()
		{
			if (availableNumbers.Count == 0)
			{
				RefillNumbersCollection();
			}
			int index = UnityEngine.Random.Range(0, availableNumbers.Count);
			int num = availableNumbers[index];
			availableNumbers.RemoveAt(index);
			if (isDebugModeOn)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine($"Number {num} taken out.");
				stringBuilder.AppendLine($"Remaining numbers ({availableNumbers.Count} total):");
				foreach (int availableNumber in availableNumbers)
				{
					stringBuilder.AppendLine(availableNumber.ToString());
				}
				Debug.Log(stringBuilder.ToString());
			}
			return num;
		}

		public bool TryGetRandomNumberInRange(int minNumberInclusive, int maxNumberExclusive, out int result)
		{
			if (minNumberInclusive >= maxNumberExclusive)
			{
				result = minNumberInclusive;
				if (isDebugModeOn)
				{
					Debug.Log("Unable to get random number in range - range is invalid");
				}
				return false;
			}
			int num = maxNumberExclusive - 1;
			int randomNumber = GetRandomNumber();
			float f = Mathf.Lerp(minNumberInclusive, num, (float)randomNumber * 0.01f);
			result = Mathf.RoundToInt(f);
			if (isDebugModeOn)
			{
				Debug.Log($"Generated number in range is {result}");
			}
			return true;
		}

		public bool TryGetRandomNumberInRange(float minNumberInclusive, float maxNumberInclusive, out float result)
		{
			if (minNumberInclusive > maxNumberInclusive)
			{
				result = minNumberInclusive;
				if (isDebugModeOn)
				{
					Debug.Log("Unable to get random number in range - range is invalid");
				}
				return false;
			}
			int randomNumber = GetRandomNumber();
			result = Mathf.Lerp(minNumberInclusive, maxNumberInclusive, (float)randomNumber * 0.01f);
			if (isDebugModeOn)
			{
				Debug.Log($"Generated number in range is {result}");
			}
			return true;
		}

		public bool TryToFallWithinPercentProbability(int percentProbability)
		{
			if (percentProbability < 100)
			{
				if (percentProbability > 0)
				{
					return percentProbability > GetRandomNumber();
				}
				return false;
			}
			return true;
		}

		public bool TryToFallWithinRatioProbability(float percentProbability)
		{
			if (!(percentProbability >= 1f))
			{
				if (percentProbability > 0f)
				{
					return percentProbability * 100f < (float)GetRandomNumber();
				}
				return false;
			}
			return true;
		}

		private void Debug_RemoveNumbersCount(int numbersCountToRemove)
		{
			if (!isDebugModeOn)
			{
				return;
			}
			if (numbersCountToRemove > availableNumbers.Count)
			{
				Debug.Log("Not enough numbers left!");
				return;
			}
			for (int i = 0; i < numbersCountToRemove; i++)
			{
				int index = UnityEngine.Random.Range(0, availableNumbers.Count);
				availableNumbers.RemoveAt(index);
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine($"Removed {numbersCountToRemove} numbers from the pool.");
			stringBuilder.AppendLine($"Remaining numbers ({availableNumbers.Count} total):");
			foreach (int availableNumber in availableNumbers)
			{
				stringBuilder.AppendLine(availableNumber.ToString());
			}
			Debug.Log(stringBuilder.ToString());
		}

		private void RefillNumbersCollection()
		{
			availableNumbers.Clear();
			for (int i = 0; i < 101; i++)
			{
				availableNumbers.Add(i);
			}
			if (isDebugModeOn)
			{
				Debug.Log("Numbers list refilled.");
			}
		}

		public object CaptureState()
		{
			try
			{
				return new RandomNumbersServiceSaveData
				{
					AvailableNumbers = availableNumbers.ToArray()
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
				RandomNumbersServiceSaveData randomNumbersServiceSaveData = DataMigrationWizard.Migrate<RandomNumbersServiceSaveData>(state, base.gameObject);
				availableNumbers.Clear();
				availableNumbers.AddRange(randomNumbersServiceSaveData.AvailableNumbers);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
