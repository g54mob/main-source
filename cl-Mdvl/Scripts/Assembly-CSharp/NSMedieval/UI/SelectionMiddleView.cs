using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.StatsSystem;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class SelectionMiddleView : UIView
	{
		[SerializeField]
		private RectTransform contentParent;

		[SerializeField]
		private CustomGrouppedToggle[] tabs;

		[SerializeField]
		private LayoutGroupView[] panels;

		[SerializeField]
		private LayoutGroupView statsGroup;

		[SerializeField]
		private LayoutGroupView modifiersGroup;

		[SerializeField]
		private LayoutGroupView decayModifiersGroup;

		[SerializeField]
		private SoundButton fullLogButton;

		[SerializeField]
		private FillBarLayoutItemView[] logLines;

		[SerializeField]
		protected LayoutGroupView infosGroup;

		[NonSerialized]
		private readonly List<FillBarLayoutItemView> descriptions = new List<FillBarLayoutItemView>();

		[NonSerialized]
		private readonly List<FillBarLayoutItemView> modifiers = new List<FillBarLayoutItemView>();

		[NonSerialized]
		private readonly List<LayoutDecayModifierItemView> decayModifiers = new List<LayoutDecayModifierItemView>();

		[NonSerialized]
		protected readonly List<FillBarLayoutItemView> infos = new List<FillBarLayoutItemView>();

		[NonSerialized]
		private readonly List<FillBarLayoutItemView> stats = new List<FillBarLayoutItemView>();

		public LayoutGroupView[] Panels => panels;

		protected CustomGrouppedToggle[] Tabs => tabs;

		protected LayoutGroupView StatsGroup => statsGroup;

		[field: NonSerialized]
		protected InfoPanelBody CurrentBody { get; set; }

		protected int CurrentIndex { get; private set; }

		public event Action<int, bool> TabSelectedAction;

		public virtual void Start()
		{
			SetupPanels();
		}

		public void ResetTabIndex()
		{
			CurrentIndex = 0;
			for (int i = 0; i < panels.Length; i++)
			{
				panels[i].gameObject.SetActive(value: false);
				tabs[i].isOn = false;
			}
			if (panels.Length != 0 && tabs.Length != 0)
			{
				panels[0].gameObject.SetActive(value: true);
				tabs[0].isOn = true;
			}
		}

		protected void Refresh()
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(contentParent);
		}

		protected void UpdateLifeLogs()
		{
			UpdateLifeLogs(CurrentBody.ObjectName, CurrentBody.LifeEventLogs);
		}

		protected void UpdateLifeLogs(string logTitle, LinkedList<LifeEventLogStruct> lifeEventLogs)
		{
			if (lifeEventLogs == null)
			{
				fullLogButton.interactable = false;
				FillLogList(null);
				return;
			}
			fullLogButton.interactable = lifeEventLogs.Count > 0;
			fullLogButton.AddCleanListener(delegate
			{
				MonoSingleton<UIController>.Instance.LogPanelView.SetDataAndShow(logTitle, lifeEventLogs);
			});
			List<string> lifEventsList = lifeEventLogs.Select((LifeEventLogStruct workerLifeEvent) => workerLifeEvent.LocalizedLog).ToList();
			FillLogList(lifEventsList);
		}

		private void FillLogList(List<string> lifEventsList)
		{
			for (int i = 0; i < logLines.Length; i++)
			{
				string text = string.Empty;
				if (lifEventsList != null && i < lifEventsList.Count)
				{
					text = lifEventsList[i];
				}
				logLines[i].SetDataText(text);
				logLines[i].SetTooltipLine(text);
			}
		}

		protected void UpdateCommonStats()
		{
			if (CurrentBody != null)
			{
				CreateStats(CurrentBody.Stats);
				CreateModifiers(CurrentBody.Modifiers, CurrentBody.ModifierTooltips, CurrentBody.DecayModifiers);
			}
			Refresh();
		}

		protected void CreateModifiers(List<string> modifiers, List<string> modifierTooltips = null, List<DecayModifierData> decayModifiers = null)
		{
			int num = 0;
			if (decayModifiers != null)
			{
				foreach (DecayModifierData decayModifier in decayModifiers)
				{
					LayoutDecayModifierItemView at = this.decayModifiers.GetAt(decayModifiersGroup, num);
					at.SetText(decayModifier.Label);
					at.SetIcons(decayModifier);
					num++;
				}
			}
			this.decayModifiers.SetActiveFromIndex(num, active: false);
			num = 0;
			foreach (string modifier in modifiers)
			{
				FillBarLayoutItemView at2 = this.modifiers.GetAt(modifiersGroup, num);
				string id = ((modifierTooltips != null && num < modifierTooltips.Count) ? modifierTooltips[num] : string.Empty);
				at2.SetDataText(modifier, id);
				num++;
			}
			this.modifiers.SetActiveFromIndex(num, active: false);
		}

		protected virtual void CreateStats(List<InfoPanelStat> infoStats)
		{
			int num = 0;
			foreach (InfoPanelStat infoStat in infoStats)
			{
				int num2 = 0;
				int max = infoStat.StatValues.Max;
				int num3 = infoStat.StatValues.Min;
				if (infoStat.StatType.Equals(StatType.Fermentation))
				{
					num3 = 100 - num3;
				}
				string barLabelText = $"{infoStat.StatValues.Min}/{infoStat.StatValues.Max}";
				if (infoStat.StatFormat.Equals("%"))
				{
					barLabelText = $"{num3}%";
				}
				stats.GetAt(statsGroup, num).SetBasicData(MonoSingleton<LocalizationController>.Instance.GetText(infoStat.Title), infoStat.TooltipKey, string.Empty, string.Empty, GetStatTooltipLines(infoStat), infoStat.Trend, new List<float> { num2, max, num3 }, null, null, invertArrows: false, barLabelText);
				num++;
			}
			stats.SetActiveFromIndex(num, active: false);
		}

		private List<KeyValuePair<string, string>> GetStatTooltipLines(InfoPanelStat infoPanelStat)
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (!string.IsNullOrEmpty(infoPanelStat.TooltipKey))
			{
				list.Add(new KeyValuePair<string, string>(MonoSingleton<LocalizationController>.Instance.GetText(infoPanelStat.TooltipKey), string.Empty));
			}
			return list;
		}

		private void SetupPanels()
		{
			int num = 0;
			CustomGrouppedToggle[] array = tabs;
			foreach (CustomGrouppedToggle obj in array)
			{
				int i2 = num;
				obj.onValueChanged.AddListener(delegate(bool call)
				{
					if (MonoSingleton<UIController>.Instance.IsSelectionPanelVisible)
					{
						panels[i2].gameObject.SetActive(call);
						this.TabSelectedAction?.Invoke(i2, call);
						CurrentIndex = (call ? i2 : CurrentIndex);
					}
				});
				num++;
			}
		}

		protected void UpdateInfos()
		{
			infos.SetAllActive(active: false);
			if (CurrentBody == null)
			{
				return;
			}
			foreach (string description in CurrentBody.Descriptions)
			{
				infos.GetNext(infosGroup).SetText("<style=\"Desc\">" + description + "</style>");
			}
			infos.GetNext(infosGroup).SetText(string.Empty);
			foreach (string info in CurrentBody.Infos)
			{
				infos.GetNext(infosGroup).SetText(info);
			}
		}
	}
}
