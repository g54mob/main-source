using System;
using System.Linq;
using DV.UIFramework;
using UnityEngine;

namespace DV.Localization.Debug
{
	public class PopupDebug : MonoBehaviour
	{
		[Serializable]
		public class PopupType
		{
			[Serializable]
			public class PopupDebugElement
			{
				public string nameDontUpdateThisValue;

				public PopupLocalizationKeys localizationKeys;

				public string[] localizationParams;
			}

			public Popup prefab;

			public PopupDebugElement[] elements;
		}

		public int verticalCount = 3;

		public float verticalOffset = 1f;

		public float horizontalOffset = 3f;

		public float scale = 0.0023f;

		public PopupType[] popupTypes;

		private void Start()
		{
			int num = 0;
			Canvas componentInChildren = GetComponentInChildren<Canvas>();
			PopupType[] array = popupTypes;
			foreach (PopupType popupType in array)
			{
				PopupType.PopupDebugElement[] elements = popupType.elements;
				foreach (PopupType.PopupDebugElement popupDebugElement in elements)
				{
					int num2 = num / verticalCount;
					int num3 = num % verticalCount;
					Vector3 position = base.transform.position - base.transform.right * num2 * horizontalOffset + base.transform.up * num3 * verticalOffset;
					Popup popup = UnityEngine.Object.Instantiate(popupType.prefab, componentInChildren.transform);
					popup.transform.position = position;
					popup.transform.forward = base.transform.forward;
					popup.transform.localScale = Vector3.one * scale;
					Popup component = popup.GetComponent<Popup>();
					if (component.TryGetComponent<PopupTextInputFieldController>(out var component2))
					{
						component2.focusOnStart = false;
					}
					component.SetLocalizationData(parameters: popupDebugElement.localizationParams.Select((string param) => param.Split('|')).ToDictionary((string[] split) => split[0], (string[] split) => split[1]), keys: popupDebugElement.localizationKeys);
					num++;
				}
			}
		}

		private void OnValidate()
		{
			PopupType[] array = popupTypes;
			for (int i = 0; i < array.Length; i++)
			{
				PopupType.PopupDebugElement[] elements = array[i].elements;
				foreach (PopupType.PopupDebugElement popupDebugElement in elements)
				{
					if (!popupDebugElement.nameDontUpdateThisValue.Equals(popupDebugElement.localizationKeys.labelKey))
					{
						popupDebugElement.nameDontUpdateThisValue = popupDebugElement.localizationKeys.labelKey;
					}
				}
			}
		}
	}
}
