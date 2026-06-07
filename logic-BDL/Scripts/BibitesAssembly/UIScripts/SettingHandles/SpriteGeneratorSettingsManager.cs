using System.Collections.Generic;
using SettingScripts;
using UnityEngine;

namespace UIScripts.SettingHandles
{
	public class SpriteGeneratorSettingsManager : MonoBehaviour
	{
		public GameObject settingsHolder;

		private readonly SettingsGroupHandle parameters = new SettingsGroupHandle
		{
			GroupTitle = "Image Parameters",
			Settings = new List<ISettingHandle>
			{
				new IntSettingSlider(SpriteGeneratorSettings.ImageRatio),
				new FloatSettingSlider(SpriteGeneratorSettings.inflateRatio)
			}
		};

		private readonly SettingsGroupHandle visualGenes = new SettingsGroupHandle
		{
			GroupTitle = "Genes",
			Settings = new List<ISettingHandle>
			{
				new ChoiceSettingDropdown<ChoiceUserSetting<UserSettings.ProceduralSizeChoice>, UserSettings.ProceduralSizeChoice>(UserSettings.ProceduralSize),
				new FloatSettingSlider(BibiteEditorSettings.colorR),
				new FloatSettingSlider(BibiteEditorSettings.colorG),
				new FloatSettingSlider(BibiteEditorSettings.colorB),
				new FloatSettingSlider(BibiteEditorSettings.eyeOffset),
				new FloatSettingSlider(BibiteEditorSettings.diet),
				new FloatSettingSlider(BibiteEditorSettings.sizeRatio),
				new FloatSettingSlider(BibiteEditorSettings.speedRatio),
				new FloatSettingSlider(BibiteEditorSettings.viewAngle),
				new FloatSettingSlider(BibiteEditorSettings.viewRadius),
				new FloatSettingSlider(BibiteEditorSettings.jawWAG),
				new FloatSettingSlider(BibiteEditorSettings.armorWAG),
				new FloatSettingSlider(BibiteEditorSettings.wombWAG),
				new FloatSettingSlider(BibiteEditorSettings.stomachWAG),
				new FloatSettingSlider(BibiteEditorSettings.moveWAG),
				new FloatSettingSlider(BibiteEditorSettings.throatWAG),
				new FloatSettingSlider(BibiteEditorSettings.fatWAG)
			}
		};

		private void Awake()
		{
			parameters.AssignHolder(settingsHolder);
			visualGenes.AssignHolder(settingsHolder);
		}

		public void StartLoadingSettingsHandles()
		{
			parameters.CreateUIElements();
			visualGenes.CreateUIElements();
		}

		public void UpdateControls()
		{
			parameters.UpdateUIElement();
			visualGenes.UpdateUIElement();
		}

		public void ResetValues()
		{
			parameters.ResetValue();
			visualGenes.ResetValue();
			UpdateControls();
		}

		public void RandomizeVisibleGenes()
		{
			parameters.Settings.ForEach(delegate(ISettingHandle _s)
			{
				if (_s is FloatSettingSlider floatSettingSlider)
				{
					floatSettingSlider.SetValue(Random.Range(floatSettingSlider.setting.minValue, floatSettingSlider.setting.maxValue), revertable: false);
				}
			});
			visualGenes.Settings.ForEach(delegate(ISettingHandle _s)
			{
				if (_s is FloatSettingSlider floatSettingSlider)
				{
					floatSettingSlider.SetValue(Random.Range(floatSettingSlider.setting.minValue, floatSettingSlider.setting.maxValue), revertable: false);
				}
			});
		}
	}
}
