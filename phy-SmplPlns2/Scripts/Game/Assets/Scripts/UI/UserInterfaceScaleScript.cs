using Jundroo.Common.Platform;
using Jundroo.Common.Settings;
using Jundroo.Common.Settings.Events;
using Jundroo.Juicy.Widgets.Extra;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
	public class UserInterfaceScaleScript : MonoBehaviour
	{
		private Vector2i _resolution;

		private float _scale = 1f;

		private NumericSetting<float> _userInterfaceScaleSetting;

		public static RectOffset Margins { get; set; } = new RectOffset();

		public static float UserInterfaceScale { get; set; } = 1f;

		public float CanvasHeight { get; private set; }

		public float CanvasScaleFactor { get; private set; } = 1f;

		public float CanvasWidth { get; private set; }

		protected virtual void Awake()
		{
			_userInterfaceScaleSetting = Game.Instance.Settings.Gameplay.General.UserInterfaceScale;
			UpdateScale();
		}

		protected virtual void OnDestroy()
		{
		}

		protected virtual void OnEnable()
		{
			if (_scale != _userInterfaceScaleSetting.Value || Screen.width != _resolution.x || Screen.height != _resolution.y)
			{
				UpdateUserInterface();
			}
		}

		protected virtual void Update()
		{
			if (_scale != _userInterfaceScaleSetting.Value || Screen.width != _resolution.x || Screen.height != _resolution.y)
			{
				UpdateUserInterface();
			}
		}

		private void OnScreenMarginChanged(object sender, SettingChangedEventArgs<float> e)
		{
			UpdateUserInterface();
		}

		private float UpdateScale()
		{
			CanvasScaler component = GetComponent<CanvasScaler>();
			_scale = _userInterfaceScaleSetting.Value;
			UserInterfaceScale = _scale;
			_resolution.x = Screen.width;
			_resolution.y = Screen.height;
			float num = Mathf.Clamp(Screen.height, 720, 1080);
			if (Device.IsTablet)
			{
				num = 720f;
			}
			else if (Device.IsMobileBuild)
			{
				num = 640f;
			}
			CanvasScaleFactor = (float)Screen.height / num * _scale;
			CanvasHeight = (float)Screen.height / CanvasScaleFactor;
			CanvasWidth = (float)Screen.width / CanvasScaleFactor;
			component.scaleFactor = CanvasScaleFactor;
			return component.scaleFactor;
		}

		private void UpdateUserInterface()
		{
			float canvasScaleFactor = UpdateScale();
			ICanvasScaleChangeHandler[] componentsInChildren = GetComponentsInChildren<ICanvasScaleChangeHandler>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].OnCanvasScaleChanged(canvasScaleFactor);
			}
		}
	}
}
