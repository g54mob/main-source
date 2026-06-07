using System;
using CTS.BBT.AI;
using CTS.Core;
using CTS.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_WorkerMgr_FilterToggle : CTSBehaviour
	{
		[SerializeField]
		private TMP_Text _countText;

		[SerializeField]
		private TMP_Text _nameText;

		[InjectScope(EGetScope.Children)]
		[SerializeField]
		[Inject(false)]
		private CTSToggle _toggle;

		private UI_WorkerMgr_Filtering _filtering;

		public VampirePowerData PowerData { get; private set; }

		public Func<Worker, bool> Filter { get; private set; }

		public WorkerPowerFeature.e_PowerFeatures Power => PowerData?.Power ?? WorkerPowerFeature.e_PowerFeatures.None;

		public void Setup(UI_WorkerMgr_Filtering filtering, VampirePowerData powerData, ToggleGroup toggleGroup)
		{
			_filtering = filtering;
			PowerData = powerData;
			GetComponentInChildren<CTSToggle>(includeInactive: true).group = toggleGroup;
			Filter = (Worker worker) => worker.PowerFeatures.HavePower(powerData.Power);
		}

		protected override void OnAwake()
		{
			base.OnAwake();
			_toggle.ToggledOn.AddListener(OnToggledOn);
		}

		private void Start()
		{
			RepaintCount();
			RepaintText();
		}

		private void OnDestroy()
		{
			_toggle.ToggledOn.RemoveListener(OnToggledOn);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			RepaintCount();
		}

		private void OnToggledOn()
		{
			_filtering.Filter(this);
		}

		public void RepaintCount()
		{
			_countText.text = GetCount().ToString();
		}

		public void RepaintText()
		{
			_nameText.text = PowerData.Name.GetLocalizedString();
		}

		public int GetCount()
		{
			if (PowerData.Power == WorkerPowerFeature.e_PowerFeatures.None)
			{
				return WorkerList.Count;
			}
			int num = 0;
			foreach (Worker item in WorkerList.All)
			{
				if (item.PowerFeatures.HavePower(PowerData.Power))
				{
					num++;
				}
			}
			return num;
		}
	}
}
