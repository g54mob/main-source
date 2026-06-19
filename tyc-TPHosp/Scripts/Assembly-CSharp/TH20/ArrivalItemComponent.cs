using System.Collections.Generic;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ArrivalItemComponent : ArrivalBaseComponent
	{
		[SerializeField]
		private SharedInstance_TH20TH20_ArrivalMethodDefinition _arrivalMethod;

		private static readonly List<KeyValuePair<int, ArrivalMethodDefinition>> _free = new List<KeyValuePair<int, ArrivalMethodDefinition>>();

		private static readonly List<ArrivalItemComponent> _spawnPoints = new List<ArrivalItemComponent>();

		public static bool ValidArrivalComponent(int index)
		{
			return index < _spawnPoints.Count;
		}

		public static ArrivalBaseComponent GetArrivalComponent(int index)
		{
			return _spawnPoints[index];
		}

		private void Awake()
		{
			_spawnPoints.Add(this);
			_free.Add(new KeyValuePair<int, ArrivalMethodDefinition>(_spawnPoints.Count - 1, _arrivalMethod.Instance));
		}

		private void OnDestroy()
		{
			_free.RemoveAt(_spawnPoints.IndexOf(this));
			_spawnPoints.Remove(this);
		}

		public static bool IsAvailable()
		{
			return _spawnPoints.Count != 0;
		}

		public static bool IsSpawnPointFree(ArrivalMethodItemDefinition method)
		{
			foreach (KeyValuePair<int, ArrivalMethodDefinition> item in _free)
			{
				if (item.Value == method)
				{
					return true;
				}
			}
			return false;
		}

		public static int Reserve(ArrivalMethodItemDefinition method)
		{
			for (int i = 0; i < _free.Count; i++)
			{
				KeyValuePair<int, ArrivalMethodDefinition> keyValuePair = _free[i];
				if (keyValuePair.Value == method)
				{
					_free.RemoveAt(i);
					return keyValuePair.Key;
				}
			}
			return -1;
		}

		public static void Free(int index, ArrivalMethodItemDefinition method)
		{
			_free.Add(new KeyValuePair<int, ArrivalMethodDefinition>(index, method));
		}

		public static void RestoreFromSave(int index)
		{
			_free.RemoveAt(index);
		}

		public static int TotalSpawnPoints()
		{
			return _spawnPoints.Count;
		}

		public static int TotalFreeSpawnPoints()
		{
			return _free.Count;
		}
	}
}
