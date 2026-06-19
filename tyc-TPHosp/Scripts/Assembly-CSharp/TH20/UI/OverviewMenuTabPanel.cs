using System;
using FullInspector;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace TH20.UI
{
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class OverviewMenuTabPanel : MonoBehaviour
	{
		[Serializable]
		public class OverviewMenuTabPanelSettings
		{
			[InspectorMargin(8)]
			[InspectorHeader("Localisation")]
			public LocalisedString TitleString;
		}

		[SerializeField]
		private OverviewMenuTabPanelSettings _overviewMenuTabPanelSettings;

		private TMP_Text _titleText;

		protected Level _level;

		protected LevelStatsDatabase _levelStatsDatabase;

		protected PanelItemProgressBar[] _progressBars;

		protected PanelItemValueViewer[] _valueViewers;

		protected PanelItemInfoMessage[] _infoMessages;

		protected virtual void Update()
		{
		}

		public Level GetLevel()
		{
			return _level;
		}

		public virtual void Setup(OverviewMenuTab theTabRoot)
		{
			_level = theTabRoot.TheOverviewMenu.TheLevel;
			_levelStatsDatabase = theTabRoot.TheOverviewMenu.TheLevel.LevelStatsDatabase;
			TMP_Text[] componentsInChildren = GetComponentsInChildren<TMP_Text>(includeInactive: true);
			foreach (TMP_Text tMP_Text in componentsInChildren)
			{
				if (tMP_Text.name == "Title")
				{
					_titleText = tMP_Text;
					_titleText.text = _overviewMenuTabPanelSettings.TitleString.Translation;
					break;
				}
			}
			PanelItem[] componentsInChildren2 = GetComponentsInChildren<PanelItem>(includeInactive: true);
			foreach (PanelItem panelItem in componentsInChildren2)
			{
				if (!panelItem.HasBeenSetup)
				{
					panelItem.Setup();
				}
			}
			_progressBars = GetComponentsInChildren<PanelItemProgressBar>(includeInactive: true);
			_valueViewers = GetComponentsInChildren<PanelItemValueViewer>(includeInactive: true);
			_infoMessages = GetComponentsInChildren<PanelItemInfoMessage>(includeInactive: true);
			if (theTabRoot.TheOverviewMenu._generalTooltipPrefab != null)
			{
				PanelItemProgressBar[] progressBars = _progressBars;
				for (int i = 0; i < progressBars.Length; i++)
				{
					progressBars[i].SetupTooltip(theTabRoot.TheOverviewMenu._generalTooltipPrefab);
				}
			}
			Refresh();
		}

		public virtual void UpdateProgressBars()
		{
		}

		protected virtual void Refresh()
		{
			PanelItemProgressBar[] progressBars = _progressBars;
			for (int i = 0; i < progressBars.Length; i++)
			{
				progressBars[i].UpdateStat(_levelStatsDatabase);
			}
			PanelItemValueViewer[] valueViewers = _valueViewers;
			for (int i = 0; i < valueViewers.Length; i++)
			{
				valueViewers[i].UpdateStat(_levelStatsDatabase);
			}
			PanelItemInfoMessage[] infoMessages = _infoMessages;
			for (int i = 0; i < infoMessages.Length; i++)
			{
				infoMessages[i].UpdateMessage(_level);
			}
		}
	}
}
