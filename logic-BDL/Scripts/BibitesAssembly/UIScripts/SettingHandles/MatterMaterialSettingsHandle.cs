using System.Collections.Generic;
using SettingScripts;
using SimulationScripts;
using UIScripts.UIReferences;
using UnityEngine;

namespace UIScripts.SettingHandles
{
	public class MatterMaterialSettingsHandle : SettingsListHandle
	{
		private MaterialParametersReference groupRef;

		private MatterMaterialSettings MaterialSettings;

		public MatterMaterialSettingsHandle(MatterMaterialSettings mat)
		{
			MaterialSettings = mat;
		}

		public override void CreateUIElement(GameObject parent)
		{
			GroupTitle = MaterialSettings.mat.Name + " Material Parameters";
			Settings = new List<ISettingHandle>
			{
				new LogFloatSettingSlider(MaterialSettings.energyDensity, 10f),
				new LogFloatSettingSlider(MaterialSettings.massDensity, 10f),
				new LogFloatSettingSlider(MaterialSettings.cohesiveness, 10f, wholeNumbers: false, simple: false, 4f),
				new LogFloatSettingSlider(MaterialSettings.reactivity, 10f, wholeNumbers: false, simple: false, 4f),
				new FloatSettingSlider(MaterialSettings.maxEfficiency),
				new FloatSettingSlider(MaterialSettings.minEfficiency),
				new SubSettingsGroupHandle
				{
					GroupTitle = "Decay Parameters",
					MasterToggle = new SubSettingsToggleMaster(MaterialSettings.decay),
					Settings = new List<ISettingHandle>
					{
						new LogFloatSettingSlider(MaterialSettings.freshTime, 6f, wholeNumbers: false, simple: false, 5f),
						new LogFloatSettingSlider(MaterialSettings.decayRate, 10f)
					}
				}
			};
			groupRef = Object.Instantiate(UIPrefabsHolder.Instance.MaterialParametersPrefab, parent.transform).GetComponent<MaterialParametersReference>();
			groupRef.titleText.text = GroupTitle;
			groupRef.resetButton.onClick.AddListener(ResetMaterialProperties);
			Settings?.ForEach(delegate(ISettingHandle _r)
			{
				_r.CreateUIElement(groupRef.settingsHolder);
			});
			groupRef.subSettingsPanel.SetActive(value: false);
			groupRef.pelletImage.sprite = MaterialSettings.defaultSprite;
		}

		public void ResetMaterialProperties()
		{
			MatterMaterialManager.ResetMaterialParameters(MaterialSettings.mat);
			Settings.ForEach(delegate(ISettingHandle s)
			{
				s.ResetValue();
			});
		}

		public override void HideUIElement()
		{
		}

		public override void ShowUIElement()
		{
		}

		public override int GetSettingsCount()
		{
			return 6;
		}
	}
}
