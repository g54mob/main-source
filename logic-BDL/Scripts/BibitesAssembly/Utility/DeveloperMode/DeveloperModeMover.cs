using SettingScripts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Utility.DeveloperMode
{
	public class DeveloperModeMover : DeveloperModeElement, IDragHandler, IEventSystemHandler
	{
		private RectTransform moverRT;

		private Vector2 initialPos;

		protected override void InitElement()
		{
			elementOffset = elementRT.rect.size * new Vector2(-0.5f, 0.5f);
		}

		public override void SetTarget(RectTransform target)
		{
			base.SetTarget(target);
			initialPos = targetRT.anchoredPosition;
		}

		public override void OnDeveloperModeChange(bool devMode)
		{
			base.OnDeveloperModeChange(devMode);
			if (!devMode)
			{
				targetRT.anchoredPosition = initialPos;
			}
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (developerMode && Input.GetKey(KeyCode.LeftControl))
			{
				Vector2 anchoredPosition = (eventData.position - targetRT.anchorMin * new Vector2(Screen.width, Screen.height) + elementOffset) / UserSettings.ScreenResolutionFactor.val;
				targetRT.anchoredPosition = anchoredPosition;
			}
		}
	}
}
