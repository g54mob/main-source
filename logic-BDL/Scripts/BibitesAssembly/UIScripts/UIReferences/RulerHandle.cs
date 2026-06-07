using System;
using ManagementScripts;
using SettingScripts;
using UIScripts.InfoHandles;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIScripts.UIReferences
{
	public class RulerHandle : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
	{
		private RectTransform rt;

		[SerializeField]
		private FloatValueTextHandle value;

		private const float minWidth = 100f;

		private const float maxWidth = 200f;

		private const float switchFactor = 2f;

		private float targetSize;

		private float scale;

		private Camera cam;

		private Vector2 mouseOffset;

		private Vector2 defaultPos;

		private void Awake()
		{
			targetSize = 100f;
			scale = 100f;
			rt = GetComponent<RectTransform>();
			cam = Camera.main;
			CameraManager.onCameraSizeChange.AddListener(UpdateSize);
			UserSettings.ShowRuler.SubscribeTo<BoolUserSetting, bool>(HideShow);
			UserSettings.ScreenResolutionFactor.SubscribeTo<FloatUserSetting, float>(UpdateSizeOnUIScaleChange);
			HideShow(UserSettings.ShowRuler.val);
		}

		private void Start()
		{
			defaultPos = rt.anchoredPosition;
			UpdateSizeOnUIScaleChange();
		}

		public void HideShow(bool val)
		{
			base.gameObject.SetActive(val);
		}

		public void UpdateSizeOnUIScaleChange()
		{
			if (cam != null)
			{
				UpdateSize(cam.orthographicSize);
			}
		}

		public void UpdateSize(float camSize)
		{
			float val = UserSettings.ScreenResolutionFactor.val;
			float num = camSize / ((float)Screen.height / 2f / val);
			float num2 = targetSize / num;
			int num3 = (int)((double)targetSize / Math.Pow(10.0, (int)Math.Floor(Math.Log10(targetSize))));
			if (num2 > 200f)
			{
				if (num3 <= 1)
				{
					scale /= 10f;
				}
				targetSize -= scale;
			}
			else if (num2 < 100f)
			{
				targetSize += scale;
				if (num3 >= 9)
				{
					scale *= 10f;
				}
			}
			num2 = targetSize / num;
			rt.sizeDelta = new Vector2(num2, 5f);
			value.UpdateValue(targetSize);
		}

		private void OnDestroy()
		{
			UserSettings.ShowRuler.UnSubscribeTo<BoolUserSetting, bool>(HideShow);
			UserSettings.ScreenResolutionFactor.UnSubscribeTo<FloatUserSetting, float>(UpdateSizeOnUIScaleChange);
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			mouseOffset = (eventData.pressPosition - new Vector2(Screen.width, 0f)) / UserSettings.ScreenResolutionFactor.val - rt.anchoredPosition;
		}

		public void OnDrag(PointerEventData eventData)
		{
			rt.anchoredPosition = (eventData.position - new Vector2(Screen.width, 0f)) / UserSettings.ScreenResolutionFactor.val - mouseOffset;
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			rt.anchoredPosition = defaultPos;
		}
	}
}
