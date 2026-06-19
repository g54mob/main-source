using Aggro.Core;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class UICamera : EntityBehaviourBase
{
	private UniversalAdditionalCameraData _cameraData;

	private static readonly int FXAA_SETTING_ID = AggroSettings.IdToHash("video-fxaa");

	private uint settingVersion;

	protected override void OnEntityCreated()
	{
		_cameraData = GetComponent<Camera>().GetUniversalAdditionalCameraData();
	}

	protected override void OnUpdatePresentation()
	{
		ToggleSetting setting = AggroSettings.GetSetting<ToggleSetting>(FXAA_SETTING_ID);
		if (settingVersion != setting.saveVersion)
		{
			settingVersion = setting.saveVersion;
			if (AggroSettings.GetSetting<ToggleSetting>(FXAA_SETTING_ID).value)
			{
				_cameraData.antialiasing = AntialiasingMode.FastApproximateAntialiasing;
			}
			else
			{
				_cameraData.antialiasing = AntialiasingMode.None;
			}
		}
	}
}
