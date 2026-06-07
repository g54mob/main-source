using System;
using System.Collections.Generic;
using CTS.Core;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using XCharts.Runtime;

namespace CTS
{
	public class UI_Graph : MonoBehaviour
	{
		[SerializeField]
		private LineChart _lineChart;

		[SerializeField]
		private UI_GraphToggle _togglePrefab;

		[SerializeField]
		private Transform _toggleContainer;

		[SerializeField]
		private bool _showTotal = true;

		[SerializeField]
		private GraphDataline _totalLine;

		[SerializeField]
		private GraphDataline[] _dataLines;

		[SerializeField]
		private LocalizedString[] _mounths;

		[SerializeField]
		private int _intervalValue = 500;

		[SerializeField]
		private int _maxViewedValue = 20;

		private List<GraphPerMounthData> _dataPerMounth = new List<GraphPerMounthData>();

		private float[] _currentMounthDatas;

		private List<UI_GraphToggle> _toggles = new List<UI_GraphToggle>();

		public event Action OnGraphLoaded;

		public event Action OnGraphMounthPast;

		private void Awake()
		{
			_currentMounthDatas = new float[_dataLines.Length];
			CreateSeries();
			InitToggles();
			CalendarHandlers_NewMonth();
			CalendarHandlers.NewMonthAfterYearChanged += CalendarHandlers_NewMonth;
			LocalizationSettings.SelectedLocaleChanged += LocalizationSettings_SelectedLocaleChanged;
		}

		private void OnDestroy()
		{
			CalendarHandlers.NewMonthAfterYearChanged -= CalendarHandlers_NewMonth;
			LocalizationSettings.SelectedLocaleChanged -= LocalizationSettings_SelectedLocaleChanged;
			for (int i = 0; i < _toggles.Count; i++)
			{
				_toggles[i].Toggle.onValueChanged.RemoveListener(OnToggleChanged);
			}
		}

		public void AddDataToGraph(GraphPerMounthData data)
		{
			try
			{
				if (_dataPerMounth == null || _dataPerMounth.Count == 0)
				{
					Debug.LogError("_dataPerMounth = " + ((_dataPerMounth == null) ? "null" : "0"));
					return;
				}
				_dataPerMounth[_dataPerMounth.Count - 1] = data;
				_currentMounthDatas = data.datas;
				for (int i = 0; i < _lineChart.series.Count - 1; i++)
				{
					_lineChart.UpdateData(i, _dataPerMounth.Count - 1, _dataPerMounth[_dataPerMounth.Count - 1].datas[i]);
				}
				_lineChart.UpdateData(_lineChart.series.Count - 1, _dataPerMounth.Count - 1, _dataPerMounth[_dataPerMounth.Count - 1].Total);
				RecalculInterval();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private void CreateSeries()
		{
			for (int num = _dataLines.Length - 1; num >= 0; num--)
			{
				CreateSerie(_dataLines[num], show: true);
			}
			CreateSerie(_totalLine, _showTotal);
		}

		private void CreateSerie(GraphDataline line, bool show)
		{
			Line line2 = _lineChart.AddSerie<Line>();
			line2.itemStyle.color = line.colorActive;
			line2.itemStyle.backgroundColor = line.colorInactive;
			line2.symbol.size = 12f;
			line2.lineStyle.width = 4f;
			line2.animation.unscaledTime = true;
			line2.show = show;
		}

		private void InitToggles()
		{
			CreateToogle(_totalLine, _showTotal);
			for (int i = 0; i < _dataLines.Length; i++)
			{
				CreateToogle(_dataLines[i], show: true);
			}
		}

		private void CreateToogle(GraphDataline line, bool show)
		{
			UI_GraphToggle uI_GraphToggle = UnityEngine.Object.Instantiate(_togglePrefab, _toggleContainer);
			uI_GraphToggle.Toggle.onValueChanged.AddListener(OnToggleChanged);
			uI_GraphToggle.Init(line);
			_toggles.Add(uI_GraphToggle);
			uI_GraphToggle.gameObject.SetActive(show);
		}

		private void LocalizationSettings_SelectedLocaleChanged(Locale obj)
		{
			UpdateMounthLabels(MonoSingleton<CalendarHandlers>.Instance.CurrentMonth - 1);
		}

		public void Clear()
		{
			_lineChart.ClearSerieData();
		}

		private float[] CopyCurrentMounthDatas()
		{
			float[] array = new float[_currentMounthDatas.Length];
			for (int i = 0; i < _currentMounthDatas.Length; i++)
			{
				array[i] = _currentMounthDatas[i];
			}
			return array;
		}

		private void CalendarHandlers_NewMonth()
		{
			float[] datas = CopyCurrentMounthDatas();
			_dataPerMounth.Add(new GraphPerMounthData
			{
				datas = datas
			});
			if (MonoSingleton<CalendarHandlers>.Instance.CurrentYear == 0)
			{
				for (int i = 0; i < _lineChart.series.Count - 1; i++)
				{
					_lineChart.AddData(i, _dataPerMounth[_dataPerMounth.Count - 1].datas[i]);
				}
				if (_showTotal)
				{
					_lineChart.AddData(_lineChart.series.Count - 1, _dataPerMounth[_dataPerMounth.Count - 1].Total);
				}
			}
			else
			{
				_dataPerMounth.RemoveAt(0);
				SetMounth(MonoSingleton<CalendarHandlers>.Instance.CurrentMonth);
			}
			RecalculInterval();
			this.OnGraphMounthPast?.Invoke();
		}

		private void SetMounth(int currentMounth)
		{
			UpdateMounthLabels(currentMounth);
			for (int i = 0; i < _mounths.Length && i < _dataPerMounth.Count; i++)
			{
				for (int j = 0; j < _lineChart.series.Count - 1; j++)
				{
					_lineChart.UpdateData(j, i, _dataPerMounth[i].datas[j]);
				}
				if (_showTotal)
				{
					_lineChart.UpdateData(_lineChart.series.Count - 1, i, _dataPerMounth[i].Total);
				}
			}
		}

		private void UpdateMounthLabels(int currentMounth)
		{
			for (int i = 0; i < _mounths.Length; i++)
			{
				_lineChart.UpdateXAxisData(i, _mounths[(currentMounth + i) % _mounths.Length].GetLocalizedString().ToUpper());
			}
		}

		private void OnToggleChanged(bool value)
		{
			for (int i = 0; i < _lineChart.series.Count; i++)
			{
				_lineChart.series[i].show = _toggles[_lineChart.series.Count - 1 - i].Toggle.isOn;
			}
			_lineChart.series[_lineChart.series.Count - 1].show = _showTotal && _toggles[0].Toggle.isOn;
			RecalculInterval();
		}

		private void RecalculInterval()
		{
			try
			{
				int num = (int)GetGreatestValue();
				YAxis chartComponent = _lineChart.GetChartComponent<YAxis>();
				if (chartComponent != null)
				{
					int num2 = (num / _intervalValue + 1) * _intervalValue / _maxViewedValue;
					chartComponent.interval = num2;
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private float GetGreatestValue()
		{
			float num = 0f;
			if (_lineChart.series[_lineChart.series.Count - 1].show)
			{
				for (int i = 0; i < _dataPerMounth.Count; i++)
				{
					if (Mathf.Abs(_dataPerMounth[i].Total) > num)
					{
						num = Mathf.Abs(_dataPerMounth[i].Total);
					}
				}
			}
			for (int j = 0; j < _lineChart.series.Count - 1; j++)
			{
				if (!_lineChart.series[j].show)
				{
					continue;
				}
				for (int k = 0; k < _dataPerMounth.Count; k++)
				{
					if (Mathf.Abs(_dataPerMounth[k].datas[j]) > num)
					{
						num = Mathf.Abs(_dataPerMounth[k].datas[j]);
					}
				}
			}
			return num;
		}

		public GraphSaveStruct SaveData()
		{
			if (_dataPerMounth.Count == 0)
			{
				Debug.LogError("Fail to save prestige graph!");
				return default(GraphSaveStruct);
			}
			GraphPerMounthData[] array = new GraphPerMounthData[_dataPerMounth.Count];
			for (int i = 0; i < _dataPerMounth.Count; i++)
			{
				array[i] = _dataPerMounth[i].Copy();
			}
			return new GraphSaveStruct
			{
				hasPastOneYear = (MonoSingleton<CalendarHandlers>.Instance.CurrentYear > 0),
				currentMounth = MonoSingleton<CalendarHandlers>.Instance.CurrentMonth,
				dataPerMounth = array
			};
		}

		public void LoadData(GraphSaveStruct data, float[] current)
		{
			if (data.dataPerMounth == null)
			{
				Debug.LogError("Fail to load graph save!");
				return;
			}
			_currentMounthDatas = current;
			_dataPerMounth.Clear();
			_dataPerMounth.AddRange(data.dataPerMounth);
			_lineChart.ClearSerieData();
			if (data.hasPastOneYear)
			{
				UpdateMounthLabels(data.currentMounth);
				for (int i = 0; i < _dataPerMounth.Count; i++)
				{
					for (int j = 0; j < _lineChart.series.Count - 1; j++)
					{
						_lineChart.AddData(j, _dataPerMounth[i].datas[j]);
					}
					_lineChart.AddData(_lineChart.series.Count - 1, _dataPerMounth[i].Total);
				}
			}
			else
			{
				for (int k = 0; k < _dataPerMounth.Count; k++)
				{
					for (int l = 0; l < _lineChart.series.Count - 1; l++)
					{
						_lineChart.AddData(l, _dataPerMounth[k].datas[l]);
					}
					_lineChart.AddData(_lineChart.series.Count - 1, _dataPerMounth[k].Total);
				}
			}
			RecalculInterval();
			this.OnGraphMounthPast?.Invoke();
			this.OnGraphLoaded?.Invoke();
		}
	}
}
