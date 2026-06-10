using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class GlobalVariableManager : MonoSingleton<GlobalVariableManager>
	{
		public bool ZoneGridVisible { get; private set; }

		public bool ResourceIndicatorsVisible { get; private set; }

		public void ZoneGridToggle()
		{
			ZoneGridVisible = !ZoneGridVisible;
			Shader.SetGlobalFloat("_showZoneColors", BoolValue(ZoneGridVisible));
			GlobalSaveController.CurrentVillageData.ZoneGridVisible = ZoneGridVisible;
		}

		public void ForceShowZoneGrid()
		{
			ZoneGridVisible = true;
			Shader.SetGlobalFloat("_showZoneColors", BoolValue(ZoneGridVisible));
			GlobalSaveController.CurrentVillageData.ZoneGridVisible = ZoneGridVisible;
		}

		public void DismissModifyZoneButton(bool value)
		{
			ZoneGridVisible = value;
			Shader.SetGlobalFloat("_showZoneColors", BoolValue(ZoneGridVisible));
			GlobalSaveController.CurrentVillageData.ZoneGridVisible = ZoneGridVisible;
		}

		public void ResourceIndicatorsToggle()
		{
			ResourceIndicatorsVisible = !ResourceIndicatorsVisible;
			Shader.SetGlobalFloat("ItemIndicatorOpacity", BoolValue(ResourceIndicatorsVisible));
			GlobalSaveController.CurrentVillageData.ResourceIndicatorsVisible = ResourceIndicatorsVisible;
		}

		private float BoolValue(bool isOn)
		{
			return isOn ? 1 : 0;
		}

		private void Start()
		{
			ZoneGridVisible = GlobalSaveController.CurrentVillageData.ZoneGridVisible;
			Shader.SetGlobalFloat("_showZoneColors", BoolValue(ZoneGridVisible));
			ResourceIndicatorsVisible = GlobalSaveController.CurrentVillageData.ResourceIndicatorsVisible;
			Shader.SetGlobalFloat("ItemIndicatorOpacity", BoolValue(ResourceIndicatorsVisible));
		}
	}
}
