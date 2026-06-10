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
	public class SelectionMiddleEnemyView : SelectionMiddleView
	{
		[SerializeField]
		private SoundButton humanoidIcon;

		[SerializeField]
		private HeraldrySymbolElement factionHeraldry;

		[SerializeField]
		private FillBarLayoutItemView hitpointsBar;

		[NonSerialized]
		private InfoPanelEnemyBody current;

		private int currentPanel;

		[NonSerialized]
		private HumanoidInstance humanoidInstance;

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
			humanoidInstance = null;
			current = null;
			base.OnDestroy();
		}

		public void InitializeBody(InfoPanelEnemyBody body)
		{
			base.CurrentBody = null;
			humanoidInstance = body.Humanoid;
			UpdateData(body);
			base.Tabs[1].gameObject.SetActive(value: false);
		}

		public void UpdateData(InfoPanelEnemyBody body)
		{
			CreateStats(body.Stats);
			CreateModifiers(body.Infos);
			SetIcon();
			UpdateLifeLogs(UiUtils.GetNPCName(humanoidInstance), humanoidInstance.LifeEventLogs);
			Refresh();
		}

		public void OnClickSelectTabClick(int index)
		{
			if (currentPanel == index)
			{
				ShowPanel(index);
			}
		}

		protected override void CreateStats(List<InfoPanelStat> infoStats)
		{
			InfoPanelStat infoPanelStat = infoStats.First();
			hitpointsBar.SetBasicData(base.Localize.GetText(infoPanelStat.Title, humanoidInstance.Info.BodyType), infoPanelStat.Title, string.Empty, string.Empty, StatUtils.GetTooltipLines(humanoidInstance.Stats.GetStat(infoPanelStat.StatType), humanoidInstance.Info.BodyType), infoPanelStat.Trend, new List<float>
			{
				0f,
				infoPanelStat.StatValues.Max,
				infoPanelStat.StatValues.Min
			}, null, null, invertArrows: false, string.Empty);
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
			humanoidIcon.image.sprite = humanoidInstance.GetSprite();
			humanoidIcon.onClick.AddListener(delegate
			{
				base.CameraFollowAction(humanoidInstance.GetAgentView<NPCView>().transform);
			});
		}
	}
}
