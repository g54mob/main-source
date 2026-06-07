using System.Collections.Generic;
using SettingScripts;
using UIScripts.InfoHandles;
using UIScripts.SettingHandles;
using UnityEngine;

namespace UIScripts.UIReferences.LineagePanel
{
	public class LineagePanelSettingsManager : UIPanel
	{
		public GameObject SettingsHolder;

		public static BoolUserSetting hideExtinctLineages = new BoolUserSetting
		{
			Name = "Hide Extinct Lineages",
			key = "HideExtinctLineages",
			HelperText = "If enabled, the species of extinct lineages (with no alive descendants) won't be displayed.",
			DefaultValue = true
		};

		public static BoolUserSetting showLineagesOfFavorite = new BoolUserSetting
		{
			Name = "Show Favorited Lineages",
			key = "ShowLineagesOfFavorited",
			HelperText = "If enabled, the lineage of favorited species will always be displayed, no matter the other settings",
			DefaultValue = false
		};

		public static BoolUserSetting scaleImportantSpecies = new BoolUserSetting
		{
			Name = "Scale Important Species",
			key = "ScaleImportantSpecies",
			HelperText = "If enabled, the tree will emphasize (make bigger) species considered important (around for longer, more children, etc.) and scale down others",
			DefaultValue = true
		};

		public FloatValueTextHandle spanHandle;

		private readonly SettingsGroupHandle speciesOptions = new SettingsGroupHandle
		{
			GroupTitle = "Species Options",
			Settings = new List<ISettingHandle>
			{
				new FloatSettingSlider(ScenarioIndependentSettings.Instance.speciesGeneticSpan),
				new FloatSettingSlider(ScenarioIndependentSettings.Instance.speciesSpanScalingFactor),
				new IntSettingSlider(ScenarioIndependentSettings.Instance.speciesPrunePointLimit)
			}
		};

		private SettingsGroupHandle lineageOptions = new SettingsGroupHandle
		{
			GroupTitle = "Lineage Options",
			Settings = new List<ISettingHandle>
			{
				new SettingToggle(hideExtinctLineages),
				new SettingToggle(showLineagesOfFavorite)
			}
		};

		private SettingsGroupHandle treeOptions = new SettingsGroupHandle
		{
			GroupTitle = "Lineage Tree",
			Settings = new List<ISettingHandle>
			{
				new SettingToggle(scaleImportantSpecies)
			}
		};

		public void LoadUISettingsHandles()
		{
			base.gameObject.SetActive(value: true);
			lineageOptions.Settings.Add(treeOptions);
			lineageOptions.AssignHolder(SettingsHolder);
			lineageOptions.CreateUIElements();
			speciesOptions.AssignHolder(SettingsHolder);
			speciesOptions.CreateUIElements();
			base.gameObject.SetActive(value: false);
		}

		public void ShowSettingsOfType(bool treeOrMesh)
		{
			if (treeOrMesh)
			{
				treeOptions.ShowUIElement();
			}
			else
			{
				treeOptions.HideUIElement();
			}
		}
	}
}
