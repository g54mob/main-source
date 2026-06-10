using System;
using System.Collections.Generic;
using NSEipix.View.UI;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using NSMedieval.View.Animals;
using UnityEngine;

namespace NSMedieval.UI
{
	public class SelectionMiddleAnimalView : SelectionMiddleView
	{
		[SerializeField]
		private SoundButton icon;

		[SerializeField]
		private FillBarLayoutItemView hitpointsBar;

		private readonly List<FillBarLayoutItemView> textStats = new List<FillBarLayoutItemView>();

		[NonSerialized]
		private AnimalInstance animal;

		[NonSerialized]
		private InfoPanelAnimalBody current;

		private int currentPanel;

		public void InitializeBody(InfoPanelAnimalBody body)
		{
			base.CurrentBody = null;
			animal = body.Animal;
			UpdateData(body);
			base.Tabs[1].gameObject.SetActive(value: false);
		}

		public void UpdateData(InfoPanelAnimalBody body)
		{
			CreateStats(body.Stats);
			CreateModifiers(body.Infos);
			SetIcon();
			UpdateLifeLogs(AnimalUtils.GetAnimalName(animal), animal.LifeEventLogs);
			Refresh();
		}

		public void OnClickSelectTabClick(int index)
		{
			if (currentPanel == index)
			{
				ShowPanel(index);
			}
		}

		public override void Hide()
		{
			if (icon != null)
			{
				icon.onClick?.RemoveAllListeners();
			}
			base.Hide();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			animal = null;
		}

		protected override void CreateStats(List<InfoPanelStat> infoStats)
		{
			for (int i = 0; i < infoStats.Count; i++)
			{
				if (i == 0)
				{
					hitpointsBar.SetBasicData(base.Localize.GetText(infoStats[i].Title, animal.Gender), infoStats[i].Title, string.Empty, string.Empty, StatUtils.GetTooltipLines(animal.Stats.GetStat(infoStats[i].StatType), animal.Gender), infoStats[i].Trend, new List<float>
					{
						0f,
						infoStats[i].StatValues.Max,
						infoStats[i].StatValues.Min
					}, null, null, invertArrows: false, string.Empty);
				}
				else
				{
					string text = base.Localize.GetText(infoStats[i].Title, animal.Gender);
					string threshold = StatUtils.GetThreshold(animal.Stats.GetStat(infoStats[i].StatType), animal.Gender);
					GetTextStat(i - 1).SetDataText(text ?? "", 0);
					GetTextStat(i - 1).SetDataText(threshold ?? "", 1);
					GetTextStat(i - 1).SetSliderTooltip(StatUtils.GetTooltipLines(animal.Stats.GetStat(infoStats[i].StatType), animal.Gender));
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

		private void ShowPanel(int index)
		{
			currentPanel = index;
		}

		private void SetIcon()
		{
			if (animal == null || animal.HasDisposed || animal.HasDied)
			{
				return;
			}
			icon.image.sprite = AssetUtils.GetSprite(AnimalUtils.GetIconPath(animal.Blueprint));
			Transform followTransform = animal.GetAgentView<AnimalView>()?.transform;
			if (!(followTransform == null))
			{
				icon.AddCleanListener(delegate
				{
					base.CameraFollowAction(followTransform);
				});
			}
		}
	}
}
