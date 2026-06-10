using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using NSMedieval.View;
using UnityEngine;

namespace NSMedieval.UI
{
	public class SelectionMiddleCharacterView : SelectionMiddleView
	{
		[SerializeField]
		private SoundButton workerIcon;

		[SerializeField]
		private FillBarLayoutItemView hitpointsBar;

		[NonSerialized]
		private readonly List<FillBarLayoutItemView> textStats = new List<FillBarLayoutItemView>();

		[NonSerialized]
		private InfoPanelWorkerBody current;

		private int currentPanel;

		[NonSerialized]
		private HumanoidInstance humanoid;

		public override void Start()
		{
			OnDevToolsActive(active: false);
			MonoSingleton<UIController>.Instance.DevToolsActive += OnDevToolsActive;
			base.Start();
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.DevToolsActive -= OnDevToolsActive;
			}
			base.OnDestroy();
		}

		public void InitializeBody(InfoPanelWorkerBody body)
		{
			base.CurrentBody = null;
			humanoid = body.Humanoid;
			UpdateData(body);
		}

		public void UpdateData(InfoPanelWorkerBody body)
		{
			CreateStats(body.Stats);
			CreateModifiers(body.Infos);
			SetIcon();
			UpdateLifeLogs(humanoid.Info.GetFullName(), humanoid.LifeEventLogs);
			Refresh();
		}

		public void OnTabClick(int index)
		{
			if (currentPanel == index)
			{
				ShowPanel(index);
			}
		}

		public override void Hide()
		{
			if (workerIcon != null)
			{
				workerIcon.onClick?.RemoveAllListeners();
			}
			base.Hide();
		}

		protected override void CreateStats(List<InfoPanelStat> infoStats)
		{
			for (int i = 0; i < infoStats.Count; i++)
			{
				if (i == 0)
				{
					hitpointsBar.SetBasicData(base.Localize.GetText(infoStats[i].Title, humanoid), infoStats[i].Title, string.Empty, string.Empty, StatUtils.GetTooltipLines(humanoid.Stats.GetStat(infoStats[i].StatType), humanoid.Info.BodyType), infoStats[i].Trend, new List<float>
					{
						0f,
						infoStats[i].StatValues.Max,
						infoStats[i].StatValues.Min
					}, null, null, invertArrows: false, string.Empty);
				}
				else
				{
					string text = base.Localize.GetText(infoStats[i].Title, humanoid);
					string threshold = StatUtils.GetThreshold(humanoid.Stats.GetStat(infoStats[i].StatType), humanoid.Info.BodyType);
					GetTextStat(i - 1).SetDataText(text ?? "", 0);
					GetTextStat(i - 1).SetDataText(threshold ?? "", 1);
					GetTextStat(i - 1).SetSliderTooltip(StatUtils.GetTooltipLines(humanoid.Stats.GetStat(infoStats[i].StatType), humanoid.Info.BodyType));
				}
			}
		}

		private FillBarLayoutItemView GetTextStat(int index)
		{
			if (index < textStats.Count)
			{
				return textStats[index];
			}
			FillBarLayoutItemView fillBarLayoutItemView = UnityEngine.Object.Instantiate(base.StatsGroup.Prefab, base.StatsGroup.transform) as FillBarLayoutItemView;
			textStats.Add(fillBarLayoutItemView);
			return fillBarLayoutItemView;
		}

		private void OnDevToolsActive(bool active)
		{
			base.Tabs.Last().gameObject.SetActive(active);
		}

		private void ShowPanel(int index)
		{
			currentPanel = index;
		}

		private void SetIcon()
		{
			workerIcon.image.sprite = humanoid.GetSprite();
			workerIcon.onClick.RemoveAllListeners();
			workerIcon.onClick.AddListener(delegate
			{
				base.CameraFollowAction(humanoid.GetAgentView<WorkerView>().transform);
			});
		}
	}
}
