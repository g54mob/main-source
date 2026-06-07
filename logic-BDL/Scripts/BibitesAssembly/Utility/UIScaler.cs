using SettingScripts;
using UnityEngine;
using UnityEngine.UI;

namespace Utility
{
	public class UIScaler : MonoBehaviour
	{
		[SerializeField]
		private CanvasScaler scaler;

		private static Canvas canvas;

		private static RectTransform rt;

		public static float canvasScale => rt.localScale.x;

		public static float totalScale => UserSettings.ScreenResolutionFactor.val * UserSettings.UIScale.val;

		public static float UIScale => UserSettings.UIScale.val;

		private void Start()
		{
			UserSettings.ScreenResolutionFactor.SubscribeTo<FloatUserSetting, float>(UpdateUIScale);
			UserSettings.UIScale.SubscribeTo<FloatUserSetting, float>(UpdateUIScale);
			UserSettings.AutomaticallyDetectScreenResolution.SubscribeTo<BoolUserSetting, bool>(UpdateUIScaleFactor);
			canvas = GetComponent<Canvas>();
			rt = GetComponent<RectTransform>();
			ScreenChangeDetector.onScreenDimensionChange.AddListener(UpdateUIScaleFactor);
			UpdateUIScaleFactor();
			UpdateUIScale();
		}

		private void UpdateUIScaleFactor()
		{
			if (UserSettings.AutomaticallyDetectScreenResolution.val)
			{
				float value = Mathf.Min((float)Screen.height / 1080f, (float)Screen.width / 1920f);
				UserSettings.ScreenResolutionFactor.SetValue(value);
			}
			else
			{
				UserSettings.ScreenResolutionFactor.SetClosestLandmark(UserSettings.ScreenResolutionFactor.val);
			}
			UpdateUIScale();
		}

		private void UpdateUIScale()
		{
			scaler.scaleFactor = totalScale;
		}

		private void OnDestroy()
		{
			UserSettings.ScreenResolutionFactor.UnSubscribeTo<FloatUserSetting, float>(UpdateUIScale);
			UserSettings.UIScale.UnSubscribeTo<FloatUserSetting, float>(UpdateUIScale);
			UserSettings.AutomaticallyDetectScreenResolution.UnSubscribeTo<BoolUserSetting, bool>(UpdateUIScaleFactor);
			ScreenChangeDetector.onScreenDimensionChange.RemoveListener(UpdateUIScaleFactor);
		}
	}
}
