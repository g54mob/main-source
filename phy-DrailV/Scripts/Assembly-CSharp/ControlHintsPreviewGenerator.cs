using System;
using DV.Game.Tutorial;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlHintsPreviewGenerator : MonoBehaviour
{
	private void Start()
	{
		for (int num = base.transform.childCount - 1; num >= 0; num--)
		{
			UnityEngine.Object.DestroyImmediate(base.transform.GetChild(num).gameObject);
		}
		Vector2 sizeDelta = new Vector2(100f, 4f);
		GameObject gameObject = new GameObject("Background");
		gameObject.transform.SetParent(base.transform);
		gameObject.transform.localPosition = new Vector3(0f, 0f, 0.01f);
		gameObject.transform.localRotation = Quaternion.identity;
		gameObject.transform.localScale = Vector3.one;
		Image image = gameObject.AddComponent<Image>();
		image.sprite = null;
		image.color = new Color(0.2f, 0.2f, 0.2f, 1f);
		RectTransform obj = gameObject.transform as RectTransform;
		obj.anchorMin = Vector2.zero;
		obj.anchorMax = Vector2.one;
		obj.sizeDelta = Vector2.zero;
		HorizontalLayoutGroup horizontalLayoutGroup = gameObject.AddComponent<HorizontalLayoutGroup>();
		horizontalLayoutGroup.childAlignment = TextAnchor.UpperCenter;
		horizontalLayoutGroup.childControlHeight = true;
		horizontalLayoutGroup.childForceExpandWidth = false;
		Vector3 localPosition = new Vector2(0f, 0f);
		GameObject gameObject2 = new GameObject("Container");
		gameObject2.transform.SetParent(gameObject.transform);
		gameObject2.transform.localPosition = localPosition;
		gameObject2.transform.localRotation = Quaternion.identity;
		gameObject2.transform.localScale = Vector3.one;
		GameObject gameObject3 = new GameObject("Title");
		gameObject3.transform.SetParent(gameObject2.transform);
		gameObject3.transform.localPosition = new Vector3(0f, localPosition.y, localPosition.z);
		gameObject3.transform.localRotation = Quaternion.identity;
		gameObject3.transform.localScale = Vector3.one;
		TextMeshProUGUI textMeshProUGUI = gameObject3.AddComponent<TextMeshProUGUI>();
		textMeshProUGUI.text = (VRManager.IsVREnabled() ? "Control hints [VR]" : "Control hints [Non-VR]");
		textMeshProUGUI.alignment = TextAlignmentOptions.Center;
		textMeshProUGUI.color = Color.yellow;
		textMeshProUGUI.fontStyle = FontStyles.Bold;
		textMeshProUGUI.fontSize = 4f;
		textMeshProUGUI.enableAutoSizing = true;
		textMeshProUGUI.fontSizeMin = 0.1f;
		textMeshProUGUI.fontSizeMax = 4f;
		RectTransform rectTransform = gameObject3.GetComponent<RectTransform>();
		if (rectTransform == null)
		{
			rectTransform = gameObject3.AddComponent<RectTransform>();
		}
		rectTransform.pivot = new Vector2(0.5f, 1f);
		rectTransform.anchorMin = new Vector2(0.5f, 1f);
		rectTransform.anchorMax = new Vector2(0.5f, 1f);
		rectTransform.sizeDelta = sizeDelta;
		localPosition.y -= sizeDelta.y + 2f;
		ControlHint[] obj2 = (ControlHint[])Enum.GetValues(typeof(ControlHint));
		localPosition.x += sizeDelta.x * 0.5f;
		localPosition.y = sizeDelta.y * -1.75f;
		ControlHint[] array = obj2;
		for (int i = 0; i < array.Length; i++)
		{
			ControlHint controlHint = array[i];
			if (controlHint != ControlHint.None)
			{
				gameObject2.AddComponent<LayoutElement>();
				RectTransform rectTransform2 = gameObject2.GetComponent<RectTransform>();
				if (rectTransform2 == null)
				{
					rectTransform2 = gameObject2.AddComponent<RectTransform>();
				}
				rectTransform2.pivot = new Vector2(0f, 1f);
				rectTransform2.anchorMin = new Vector2(0.5f, 1f);
				rectTransform2.anchorMax = new Vector2(0.5f, 1f);
				rectTransform2.sizeDelta = new Vector2(sizeDelta.x + 10f, 0f);
				GameObject gameObject4 = new GameObject(controlHint.ToString());
				gameObject4.transform.SetParent(gameObject2.transform);
				gameObject4.transform.localPosition = new Vector3(0f, localPosition.y, localPosition.z);
				gameObject4.transform.localRotation = Quaternion.identity;
				gameObject4.transform.localScale = Vector3.one;
				TextMeshProUGUI textMeshProUGUI2 = gameObject4.AddComponent<TextMeshProUGUI>();
				textMeshProUGUI2.text = controlHint.GetAttribute().GetMessage();
				textMeshProUGUI2.alignment = TextAlignmentOptions.Center;
				textMeshProUGUI2.color = Color.white;
				textMeshProUGUI2.fontStyle = FontStyles.Normal;
				textMeshProUGUI2.fontSize = 3.5f;
				textMeshProUGUI2.enableAutoSizing = true;
				textMeshProUGUI2.fontSizeMin = 0.1f;
				textMeshProUGUI2.fontSizeMax = 2f;
				rectTransform2 = gameObject4.GetComponent<RectTransform>();
				if (rectTransform2 == null)
				{
					rectTransform2 = gameObject4.AddComponent<RectTransform>();
				}
				rectTransform2.pivot = new Vector2(0.5f, 1f);
				rectTransform2.anchorMin = new Vector2(0.5f, 1f);
				rectTransform2.anchorMax = new Vector2(0.5f, 1f);
				rectTransform2.sizeDelta = sizeDelta;
				localPosition.y -= sizeDelta.y + 1f;
			}
		}
	}
}
