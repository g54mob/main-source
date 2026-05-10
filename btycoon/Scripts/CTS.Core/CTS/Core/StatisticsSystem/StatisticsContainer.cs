using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.Core.StatisticsSystem
{
	public abstract class StatisticsContainer<T> : MonoBehaviour where T : Enum
	{
		[SerializeField]
		[Header("Initialization")]
		private SerializableDictionary<T, NumericStatistic> _statisticsToInitialize = new SerializableDictionary<T, NumericStatistic>();

		[SerializeField]
		public SerializableDictionary<T, StatisticBehaviourFactory<T>> _behavioursToInitialize = new SerializableDictionary<T, StatisticBehaviourFactory<T>>();

		[SerializeField]
		[Header("Debug")]
		[ReadOnly]
		protected SerializableDictionary<T, NumericStatistic> _statistics = new SerializableDictionary<T, NumericStatistic>();

		protected Dictionary<T, StatisticBehaviour<T>> _behaviours = new Dictionary<T, StatisticBehaviour<T>>();

		public Dictionary<T, NumericStatistic> GetAllStatistics => _statistics.Dict;

		public static event Action<T, float> StatisticChanged;

		public void Clear()
		{
			_behaviours.Clear();
			_statistics.Clear();
		}

		public bool HasStatistic(T statToCheck)
		{
			return _statistics.ContainsKey(statToCheck);
		}

		public void AddNumericStatistic(T statEnum, NumericStatistic numericStatisticToAdd)
		{
			if (HasStatistic(statEnum))
			{
				throw new Exception("The key already exists in the statistics collection.");
			}
			_statistics.Add(statEnum, numericStatisticToAdd);
		}

		public NumericStatistic GetNumericStatistic(T statToGet)
		{
			if (!HasStatistic(statToGet))
			{
				throw new Exception("Tried to get a non existent statistic.");
			}
			return _statistics[statToGet];
		}

		public bool TryGetNumericStatistic(T statToGet, out NumericStatistic numericStatistic)
		{
			numericStatistic = null;
			if (!HasStatistic(statToGet))
			{
				return false;
			}
			numericStatistic = GetNumericStatistic(statToGet);
			return true;
		}

		public float GetStatisticValue(T statToGet)
		{
			if (!HasStatistic(statToGet))
			{
				throw new Exception("Tried to get the value of a non existent statistic.");
			}
			return _statistics[statToGet].Value;
		}

		public bool TryGetStatisticValue(T statToGet, out float statisticValue)
		{
			statisticValue = 0f;
			if (!HasStatistic(statToGet))
			{
				return false;
			}
			statisticValue = GetStatisticValue(statToGet);
			return true;
		}

		public int GetStatisticIntValue(T statToGet)
		{
			if (!HasStatistic(statToGet))
			{
				throw new Exception("Tried to get the value of a non existent statistic.");
			}
			return _statistics[statToGet].IntValue;
		}

		public bool TryGetStatisticIntValue(T statToGet, out int statisticValue)
		{
			statisticValue = 0;
			if (!HasStatistic(statToGet))
			{
				return false;
			}
			statisticValue = GetStatisticIntValue(statToGet);
			return true;
		}

		public float GetStatisticUnitInterval(T statToGet)
		{
			if (!HasStatistic(statToGet))
			{
				throw new Exception("Tried to get the unit interval of a non existent statistic.");
			}
			return _statistics[statToGet].UnitInterval;
		}

		public bool TryGetStatisticUnitInterval(T statToGet, out float statisticValue)
		{
			statisticValue = 0f;
			if (!HasStatistic(statToGet))
			{
				return false;
			}
			statisticValue = GetStatisticUnitInterval(statToGet);
			return true;
		}

		public float GetStatisticPercentage(T statToGet)
		{
			if (!HasStatistic(statToGet))
			{
				throw new Exception("Tried to get the percentage of a non existent statistic.");
			}
			return _statistics[statToGet].PercentageValue;
		}

		public bool TryGetStatisticPercentage(T statToGet, out float statisticValue)
		{
			statisticValue = 0f;
			if (!HasStatistic(statToGet))
			{
				return false;
			}
			statisticValue = GetStatisticPercentage(statToGet);
			return true;
		}

		public void SetStatisticValue(T statToChange, float newValue)
		{
			if (!HasStatistic(statToChange))
			{
				throw new Exception("Tried to set the value of a non existent statistic.");
			}
			ChangeStatisticValue(statToChange, delegate
			{
				_statistics[statToChange].Value = newValue;
			});
		}

		public void SetStatisticFromUnitInterval(T statToChange, float unitInterval)
		{
			if (!HasStatistic(statToChange))
			{
				throw new Exception("Tried to set the value from an unit interval of a non existent statistic.");
			}
			ChangeStatisticValue(statToChange, delegate
			{
				_statistics[statToChange].SetValueFromUnitInterval(unitInterval);
			});
		}

		public void SetStatisticFromPercentage(T statToChange, float percentage)
		{
			if (!HasStatistic(statToChange))
			{
				throw new Exception("Tried to set the value from a percentage of a non existent statistic.");
			}
			ChangeStatisticValue(statToChange, delegate
			{
				_statistics[statToChange].SetValueFromPercentage(percentage);
			});
		}

		public void AddToStatistic(T statToChange, float toAdd, bool allowBehaviour = true)
		{
			if (!HasStatistic(statToChange))
			{
				throw new Exception("Tried to add to the value of a non existent statistic.");
			}
			if (allowBehaviour && _behaviours.ContainsKey(statToChange))
			{
				ChangeStatisticValue(statToChange, delegate
				{
					_behaviours[statToChange].AddToStatistic(toAdd);
				});
			}
			else
			{
				ChangeStatisticValue(statToChange, delegate
				{
					_statistics[statToChange].AddToValue(toAdd);
				});
			}
		}

		public bool TryAddToStatistic(T statToChange, float toAdd, bool allowBehaviour = true)
		{
			if (!HasStatistic(statToChange))
			{
				return false;
			}
			AddToStatistic(statToChange, toAdd, allowBehaviour);
			return true;
		}

		public void AddToStatisticUnitInterval(T statToChange, float unitInterval, bool allowBehaviour = true)
		{
			if (!HasStatistic(statToChange))
			{
				throw new Exception("Tried to add to the value of a non existent statistic.");
			}
			AddToStatistic(statToChange, unitInterval * GetNumericStatistic(statToChange).Max, allowBehaviour);
		}

		public bool TryAddToStatisticUnitInterval(T statToChange, float toAdd, bool allowBehaviour = true)
		{
			if (!HasStatistic(statToChange))
			{
				return false;
			}
			AddToStatisticUnitInterval(statToChange, toAdd, allowBehaviour);
			return true;
		}

		public void AddBehaviourToStatistic(T stat, StatisticBehaviourFactory<T> behaviourToAdd)
		{
			if (_statistics.ContainsKey(stat))
			{
				_behaviours.Add(stat, behaviourToAdd.GetNewBehaviour(_statistics[stat], this));
			}
		}

		public void SetBehaviourActive(T stat, bool active)
		{
			if (_behaviours.ContainsKey(stat))
			{
				_behaviours[stat].IsActive = active;
			}
		}

		private void ChangeStatisticValue(T statToChange, Action change)
		{
			float value = _statistics[statToChange].Value;
			change();
			if (value != _statistics[statToChange].Value)
			{
				StatisticsContainer<T>.StatisticChanged?.Invoke(statToChange, _statistics[statToChange].Value);
			}
		}

		private void Awake()
		{
			InitializeBaseSetup();
		}

		protected void InitializeBaseSetup()
		{
			InitializeValues();
			InitializeBehaviours();
		}

		private void InitializeValues()
		{
			foreach (KeyValuePair<T, NumericStatistic> item in _statisticsToInitialize)
			{
				_statistics.Add(item.Key, new NumericStatistic(item.Value));
			}
		}

		private void InitializeBehaviours()
		{
			foreach (KeyValuePair<T, StatisticBehaviourFactory<T>> item in _behavioursToInitialize)
			{
				if (_statistics.ContainsKey(item.Key))
				{
					_behaviours.Add(item.Key, item.Value.GetNewBehaviour(_statistics[item.Key], this));
				}
			}
		}
	}
}
