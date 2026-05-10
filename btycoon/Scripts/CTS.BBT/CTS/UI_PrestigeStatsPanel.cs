using System;
using System.Collections.Generic;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class UI_PrestigeStatsPanel : MonoSingleton<UI_PrestigeStatsPanel>
	{
		[SerializeField]
		private UI_StatsCounter _prefab;

		[SerializeField]
		private GameObject _spacingPrefab;

		[SerializeField]
		private Color _clearColor;

		[SerializeField]
		private Color _darkColor;

		[SerializeField]
		private Transform _container;

		[SerializeField]
		private StatsGroup[] _statGroups;

		private static List<PrestigeUIStatsSO> _statsSO = new List<PrestigeUIStatsSO>();

		[SerializeField]
		private SerializableDictionary<string, int> _testSave;

		protected override void SingletonAwake()
		{
			for (int i = 0; i < _statGroups.Length; i++)
			{
				for (int j = 0; j < _statGroups[i].Stats.Length; j++)
				{
					PrestigeUIStatsSO prestigeUIStatsSO = _statGroups[i].Stats[j];
					UnityEngine.Object.Instantiate(_prefab, _container).Init(prestigeUIStatsSO, (j % 2 == 0) ? _darkColor : _clearColor);
					if (!_statsSO.Contains(prestigeUIStatsSO))
					{
						_statsSO.Add(prestigeUIStatsSO);
					}
				}
				if (i < _statGroups.Length - 1)
				{
					UnityEngine.Object.Instantiate(_spacingPrefab, _container);
				}
			}
		}

		protected override void OnSingletonDestroy()
		{
			Clear();
		}

		private static void Clear()
		{
			foreach (PrestigeUIStatsSO item in _statsSO)
			{
				item.SetCurrentValue(0);
				item.SetLastMounthValues(Array.Empty<int>());
			}
		}

		public static StatsSaveStruct Save()
		{
			return StatsSaveStruct.CreateSaveStruct(_statsSO);
		}

		public static void Load(StatsSaveStruct save)
		{
			Clear();
			foreach (PrestigeUIStatsSO item in _statsSO)
			{
				if (save.SavedStats.ContainsKey(item.name))
				{
					item.SetCurrentValue(save.SavedStats[item.name]);
				}
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void TestLoad()
		{
			Load(StatsSaveStruct.CreateFromSerializedDictionary(_testSave));
		}

		[Button(null, EButtonEnableMode.Always)]
		private void TestSave()
		{
			_testSave = StatsSaveStruct.CreateFromSerializedDictionary(Save());
		}
	}
}
