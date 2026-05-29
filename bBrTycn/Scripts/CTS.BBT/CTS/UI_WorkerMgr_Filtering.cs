using System.Collections.Generic;
using CTS.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS
{
	[Constructor("Construct")]
	public class UI_WorkerMgr_Filtering : CTSBehaviour
	{
		[SerializeField]
		private UI_WorkerMgr_Layouter _layouter;

		[SerializeField]
		private UI_WorkerMgr_FilterToggle _togglePrefab;

		[SerializeField]
		private Transform _toggleContainer;

		[SerializeField]
		private List<VampirePowerData> _powers = new List<VampirePowerData>();

		private List<UI_WorkerMgr_FilterToggle> _toggles = new List<UI_WorkerMgr_FilterToggle>();

		[SerializeField]
		private ToggleGroup _toggleGroup;

		[SerializeField]
		private TMP_Text _textTitle;

		[SerializeField]
		private TMP_Text _textCount;

		private UI_WorkerMgr_FilterToggle _currentToggle;

		private void Construct()
		{
			foreach (VampirePowerData power in _powers)
			{
				UI_WorkerMgr_FilterToggle uI_WorkerMgr_FilterToggle = CTSFactory.Instantiate(_togglePrefab, _toggleContainer, instantiateInWorldSpace: false, false);
				uI_WorkerMgr_FilterToggle.Setup(this, power, _toggleGroup);
				uI_WorkerMgr_FilterToggle.gameObject.SetActive(value: true);
				_toggles.Add(uI_WorkerMgr_FilterToggle);
			}
			_currentToggle = _toggles[0];
		}

		private void Start()
		{
			RepaintCurrent();
			LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
			_layouter.WasRepaint += OnLayouterRepaint;
		}

		private void OnDestroy()
		{
			LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
			_layouter.WasRepaint -= OnLayouterRepaint;
		}

		private void OnLocaleChanged(Locale obj)
		{
			RepaintCurrent();
			foreach (UI_WorkerMgr_FilterToggle toggle in _toggles)
			{
				toggle.RepaintText();
			}
		}

		private void OnLayouterRepaint()
		{
			RepaintCurrent();
		}

		public void Filter(UI_WorkerMgr_FilterToggle filter)
		{
			_currentToggle = filter;
			RepaintCurrent();
			if (filter.Power == WorkerPowerFeature.e_PowerFeatures.None)
			{
				_layouter.DisableFiltering();
			}
			else
			{
				_layouter.Filter(filter.Filter);
			}
		}

		public void RepaintCurrent()
		{
			_textTitle.text = _currentToggle.PowerData.Name.GetLocalizedString();
			_textCount.text = _currentToggle.GetCount().ToString();
		}
	}
}
