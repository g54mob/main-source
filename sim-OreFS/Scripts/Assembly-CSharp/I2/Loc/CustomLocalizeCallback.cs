using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace I2.Loc
{
	[AddComponentMenu("I2/Localization/I2 Localize Callback")]
	public class CustomLocalizeCallback : MonoBehaviour
	{
		public UnityEvent _OnLocalize = new UnityEvent();

		[Header("UI Layout Refresh")]
		public bool isUIComponent;

		public void OnEnable()
		{
			LocalizationManager.OnLocalizeEvent -= OnLocalize;
			LocalizationManager.OnLocalizeEvent += OnLocalize;
		}

		public void OnDisable()
		{
			LocalizationManager.OnLocalizeEvent -= OnLocalize;
		}

		public void OnLocalize()
		{
			_OnLocalize.Invoke();
			if (isUIComponent)
			{
				RefreshAllUILayouts();
			}
		}

		private void RefreshAllUILayouts()
		{
			RectTransform[] componentsInChildren = GetComponentsInChildren<RectTransform>(includeInactive: true);
			if (componentsInChildren == null || componentsInChildren.Length == 0)
			{
				return;
			}
			RectTransform[] array = componentsInChildren;
			foreach (RectTransform rectTransform in array)
			{
				if (rectTransform != null && rectTransform.gameObject.activeInHierarchy)
				{
					LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
				}
			}
		}
	}
}
