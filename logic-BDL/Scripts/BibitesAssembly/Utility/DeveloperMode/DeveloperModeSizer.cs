using SettingScripts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Utility.DeveloperMode
{
	public class DeveloperModeSizer : DeveloperModeElement, IDragHandler, IEventSystemHandler
	{
		protected override void InitElement()
		{
			elementOffset = elementRT.rect.size * new Vector2(0.5f, -0.5f);
		}

		public override void OnDeveloperModeChange(bool devMode)
		{
			developerMode = devMode;
			if (!devMode)
			{
				targetRT.localScale = Vector3.one;
			}
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (developerMode && Input.GetKey(KeyCode.LeftControl))
			{
				Vector2 sizeDelta = targetRT.sizeDelta;
				Vector2 anchoredPosition = targetRT.anchoredPosition;
				Vector2 vector = (eventData.position - targetRT.anchorMin * new Vector2(Screen.width, Screen.height) + elementOffset) / UserSettings.ScreenResolutionFactor.val;
				float num = Mathf.Max((vector.x - anchoredPosition.x) / sizeDelta.x, (vector.y - anchoredPosition.y) / sizeDelta.y);
				targetRT.localScale = Vector3.one * num;
			}
		}
	}
}
