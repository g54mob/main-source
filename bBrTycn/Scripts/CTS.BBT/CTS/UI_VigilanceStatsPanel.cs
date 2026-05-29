using System.Collections.Generic;
using System.Linq;
using CTS.Core;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class UI_VigilanceStatsPanel : MonoSingleton<UI_VigilanceStatsPanel>
	{
		[SerializeField]
		private UI_VigilanceStatsCounter _prefab;

		[SerializeField]
		private Color _clearColor;

		[SerializeField]
		private Color _darkColor;

		[SerializeField]
		private Transform _currentContainer;

		[SerializeField]
		private Transform _lastContainer;

		[SerializeField]
		private TMP_Text _currentMounthTotalText;

		[SerializeField]
		private TMP_Text _lastMounthTotalText;

		[SerializeField]
		private UI_Graph _graph;

		private static List<PrestigeUIStatsSO> _pr_statsSO;

		[field: SerializeField]
		public PrestigeUIStatsSO[] Stats { get; private set; }

		private static List<PrestigeUIStatsSO> StatsSO
		{
			get
			{
				if (_pr_statsSO == null)
				{
					_pr_statsSO = Resources.LoadAll<PrestigeUIStatsSO>("Scriptables/Vigilance/Stats").ToList();
				}
				return _pr_statsSO;
			}
			set
			{
				_pr_statsSO = value;
			}
		}

		protected override void SingletonAwake()
		{
			for (int i = 0; i < Stats.Length; i++)
			{
				Object.Instantiate(_prefab, _currentContainer).Init(Stats[i], (i % 2 == 0) ? _darkColor : _clearColor, isCurrentMounth: true);
				if (_lastContainer != null)
				{
					Object.Instantiate(_prefab, _lastContainer).Init(Stats[i], (i % 2 == 0) ? _darkColor : _clearColor, isCurrentMounth: false);
				}
			}
		}

		private void Start()
		{
			UI_VigilanceStatsCounter.OnCurrentValueChanged += UI_VigilanceStatsCounter_OnCurrentValueChanged;
			_graph.OnGraphMounthPast += CalendarHandlers_NewMonthAfterYearChanged;
			UI_VigilanceStatsCounter_OnCurrentValueChanged();
		}

		protected override void OnSingletonDestroy()
		{
			UI_VigilanceStatsCounter.OnCurrentValueChanged -= UI_VigilanceStatsCounter_OnCurrentValueChanged;
			_graph.OnGraphMounthPast -= CalendarHandlers_NewMonthAfterYearChanged;
			Clear();
		}

		private static void Clear()
		{
			for (int i = 0; i < StatsSO.Count; i++)
			{
				StatsSO[i].SetCurrentValue(0);
				StatsSO[i].SetLastMounthValues(new int[0]);
			}
			StatsSO = null;
		}

		private void CalendarHandlers_NewMonthAfterYearChanged()
		{
			int num = 0;
			for (int i = 0; i < StatsSO.Count; i++)
			{
				StatsSO[i].SendCurrentValueToLastMounth();
				num += StatsSO[i].PreviousMounthValue;
			}
			_lastMounthTotalText.text = ((num > 0) ? "+" : "") + num;
		}

		private void UI_VigilanceStatsCounter_OnCurrentValueChanged()
		{
			int num = 0;
			for (int i = 0; i < StatsSO.Count; i++)
			{
				num += StatsSO[i].CurrentValue;
			}
			_currentMounthTotalText.text = ((num > 0) ? "+" : "") + num;
			_graph.AddDataToGraph(new GraphPerMounthData
			{
				datas = ValuesToDataGraph()
			});
		}

		private float[] ValuesToDataGraph()
		{
			float[] array = new float[Stats.Length];
			for (int i = 0; i < Stats.Length; i++)
			{
				array[i] = Stats[Stats.Length - 1 - i].CurrentValue;
			}
			return array;
		}

		public static VigilanceStatsSaveStruct Save()
		{
			return VigilanceStatsSaveStruct.CreateSaveStruct(StatsSO);
		}

		public static void Load(VigilanceStatsSaveStruct save)
		{
			Clear();
			for (int i = 0; i < StatsSO.Count; i++)
			{
				if (save.SavedStats.ContainsKey(StatsSO[i].name))
				{
					StatsSO[i].SetCurrentValue(save.SavedStats[StatsSO[i].name].Current);
					StatsSO[i].SetLastMounthValues(save.SavedStats[StatsSO[i].name].Last);
				}
			}
		}
	}
}
