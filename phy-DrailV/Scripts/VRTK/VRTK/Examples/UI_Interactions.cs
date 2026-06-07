using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VRTK.Examples
{
	public class UI_Interactions : MonoBehaviour
	{
		private const int EXISTING_CANVAS_COUNT = 4;

		public void Button_Red()
		{
			VRTK_Logger.Info("Red Button Clicked");
		}

		public void Button_Pink()
		{
			VRTK_Logger.Info("Pink Button Clicked");
		}

		public void Toggle(bool state)
		{
			VRTK_Logger.Info("The toggle state is " + (state ? "on" : "off"));
		}

		public void Dropdown(int value)
		{
			VRTK_Logger.Info("Dropdown option selected was ID " + value);
		}

		public void SetDropText(BaseEventData data)
		{
			PointerEventData pointerEventData = data as PointerEventData;
			GameObject gameObject = GameObject.Find("ActionText");
			if ((bool)gameObject)
			{
				gameObject.GetComponent<Text>().text = pointerEventData.pointerDrag.name + " Dropped On " + pointerEventData.pointerEnter.name;
			}
		}

		public void CreateCanvas()
		{
			StartCoroutine(CreateCanvasOnNextFrame());
		}

		private IEnumerator CreateCanvasOnNextFrame()
		{
			yield return null;
			int num = Object.FindObjectsOfType<Canvas>().Length - 4;
			GameObject gameObject = new GameObject("TempCanvas");
			gameObject.layer = 5;
			RectTransform component = gameObject.AddComponent<Canvas>().GetComponent<RectTransform>();
			component.position = new Vector3(-4f, 2f, 3f + (float)num);
			component.sizeDelta = new Vector2(300f, 400f);
			component.localScale = new Vector3(0.005f, 0.005f, 0.005f);
			component.eulerAngles = new Vector3(0f, 270f, 0f);
			GameObject gameObject2 = new GameObject("TempButton", typeof(RectTransform));
			gameObject2.transform.SetParent(gameObject.transform);
			gameObject2.layer = 5;
			RectTransform component2 = gameObject2.GetComponent<RectTransform>();
			component2.position = new Vector3(0f, 0f, 0f);
			component2.anchoredPosition = new Vector3(0f, 0f, 0f);
			component2.localPosition = new Vector3(0f, 0f, 0f);
			component2.sizeDelta = new Vector2(180f, 60f);
			component2.localScale = new Vector3(1f, 1f, 1f);
			component2.localEulerAngles = new Vector3(0f, 0f, 0f);
			gameObject2.AddComponent<Image>();
			Button button = gameObject2.AddComponent<Button>();
			ColorBlock colors = button.colors;
			colors.highlightedColor = Color.red;
			button.colors = colors;
			GameObject obj = new GameObject("BtnText", typeof(RectTransform));
			obj.transform.SetParent(gameObject2.transform);
			obj.layer = 5;
			RectTransform component3 = obj.GetComponent<RectTransform>();
			component3.position = new Vector3(0f, 0f, 0f);
			component3.anchoredPosition = new Vector3(0f, 0f, 0f);
			component3.localPosition = new Vector3(0f, 0f, 0f);
			component3.sizeDelta = new Vector2(180f, 60f);
			component3.localScale = new Vector3(1f, 1f, 1f);
			component3.localEulerAngles = new Vector3(0f, 0f, 0f);
			Text text = obj.AddComponent<Text>();
			text.text = "New Button";
			text.color = Color.black;
			text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
			gameObject.AddComponent<VRTK_UICanvas>();
		}
	}
}
