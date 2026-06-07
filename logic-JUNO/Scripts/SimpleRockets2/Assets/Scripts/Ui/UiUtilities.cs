using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Assets.Packages.SocialPlatforms;
using DG.Tweening;
using ModApi.Input;
using TMPro;
using UI.Tables;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui
{
	public static class UiUtilities
	{
		public enum ExpandType
		{
			Vertical = 0,
			Horizontal = 1,
			HorizontalAndVertical = 2
		}

		public struct TableInfo
		{
			public XmlElement RowTemplate { get; private set; }

			public TableLayout Table { get; private set; }

			public Dictionary<TMP_Text, Func<string>> TextElements { get; private set; }

			public TableInfo(TableLayout table, XmlElement rowTemplate)
			{
				Table = table;
				RowTemplate = rowTemplate;
				TextElements = new Dictionary<TMP_Text, Func<string>>();
			}

			public void UpdateRows()
			{
				foreach (KeyValuePair<TMP_Text, Func<string>> textElement in TextElements)
				{
					textElement.Key.text = textElement.Value();
				}
			}
		}

		public static void AddTableRow(TableInfo tableInfo, string label, Func<string> updater)
		{
			XmlElement rowTemplate = tableInfo.RowTemplate;
			XmlElement xmlElement = UnityEngine.Object.Instantiate(rowTemplate);
			xmlElement.Initialise(xmlElement.xmlLayoutInstance, (RectTransform)rowTemplate.gameObject.transform, rowTemplate.tagHandler);
			TMP_Text[] componentsInChildren = xmlElement.GetComponentsInChildren<TMP_Text>();
			componentsInChildren[0].text = label;
			TableRow component = xmlElement.GetComponent<TableRow>();
			component.gameObject.SetActive(value: true);
			tableInfo.Table.AddRow(component);
			RegisterDynamicRow(tableInfo.TextElements, componentsInChildren[1], updater);
		}

		public static XmlElement CloneTemplate(XmlElement template, XmlElement parent, bool applyAttributes = true)
		{
			XmlElement component = UnityEngine.Object.Instantiate(template.gameObject).GetComponent<XmlElement>();
			parent.AddChildElement(component);
			component.SetAttribute("id", null);
			if (applyAttributes)
			{
				component.ApplyAttributesRecursive();
			}
			component.Show();
			return component;
		}

		public static void CollapseElement(XmlElement element, float animTime, ExpandType expandType, Action<float> onUpdate, Action onComplete)
		{
			string attribute = element.GetAttribute("preferredHeight");
			float num = (string.IsNullOrEmpty(attribute) ? GetPreferredHeightAllChildren(element.rectTransform) : float.Parse(attribute));
			Func<float, Vector3> scaler = GetScalerFunc(expandType);
			float val = 1f;
			element.SetAttribute("preferredHeightBackup", num.ToString());
			element.ApplyAttributes();
			DOTween.To(() => val, delegate(float x)
			{
				val = x;
				element.transform.localScale = scaler(x);
				onUpdate?.Invoke(x);
				element.ApplyAttributes();
			}, 0f, animTime).OnComplete(delegate
			{
				element.Hide();
				onComplete?.Invoke();
			});
		}

		public static GameObject CreateUiGameObject(string name, Transform parent)
		{
			GameObject gameObject = new GameObject(name, typeof(RectTransform));
			gameObject.transform.SetParent(parent, worldPositionStays: false);
			RectTransform component = gameObject.GetComponent<RectTransform>();
			component.anchorMin = Vector2.zero;
			component.anchorMax = Vector2.one;
			component.sizeDelta = Vector2.zero;
			return gameObject;
		}

		public static void ExpandElement(XmlElement element, float animTime, ExpandType expandType, Action<float> onUpdate, Action onComplete)
		{
			Func<float, Vector3> scaler = GetScalerFunc(expandType);
			float val = 0f;
			element.Show();
			DOTween.To(() => val, delegate(float x)
			{
				val = x;
				element.transform.localScale = scaler(x);
				onUpdate?.Invoke(x);
				element.ApplyAttributes();
			}, 1f, animTime).OnComplete(delegate
			{
				onComplete?.Invoke();
			});
			element.RemoveAttribute("preferredHeightBackup");
			element.ApplyAttributes();
		}

		public static float GetPreferredHeightAllChildren(RectTransform rectTransform)
		{
			float num = 0f;
			RectTransform[] componentsInChildren = rectTransform.GetComponentsInChildren<RectTransform>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				float preferredHeight = LayoutUtility.GetPreferredHeight(componentsInChildren[i]);
				num = ((preferredHeight > num) ? preferredHeight : num);
			}
			return num;
		}

		public static void GetRectCornersInLocalSpace(RectTransform rect, RectTransform canvas, Vector2[] points, Camera camera)
		{
			Vector3[] array = new Vector3[4];
			rect.GetWorldCorners(array);
			for (int i = 0; i < 4; i++)
			{
				array[i] = RectTransformUtility.WorldToScreenPoint(camera, array[i]);
				RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, array[i], null, out var localPoint);
				points[i] = localPoint;
			}
		}

		public static Transform GetRootCanvasTransform()
		{
			Canvas canvas = null;
			int num = int.MinValue;
			Canvas[] array = UnityEngine.Object.FindObjectsOfType<Canvas>();
			foreach (Canvas canvas2 in array)
			{
				if (canvas2.sortingOrder > num && canvas2.isActiveAndEnabled && canvas2.GetComponent<GraphicRaycaster>() != null && (canvas2.transform.parent == null || canvas2.transform.parent.GetComponentInParent<Canvas>() == null))
				{
					canvas = canvas2;
					num = canvas2.sortingOrder;
				}
			}
			if (canvas == null)
			{
				Debug.LogError("Unable to find root canvas");
			}
			return canvas?.transform;
		}

		public static string ProcessStringWithInputs(string s)
		{
			return new Regex("\\|[^|]+\\|").Replace(s, delegate(Match match)
			{
				string[] array = match.Value.Trim('|').Split(';');
				string text = array[0];
				string text2 = ((array.Length == 2) ? array[1] : string.Empty);
				IGameInput gameInput = Game.Instance.Inputs.FindById(text);
				if (gameInput != null)
				{
					bool isSteamDeckOrBigPicture = SocialExt.IsSteamDeckOrBigPicture;
					switch (text2)
					{
					case "+":
						if (!isSteamDeckOrBigPicture)
						{
							return gameInput.GetKeyboardPrimaryPositiveBindingText();
						}
						return gameInput.GetControllerPositiveBindingText() ?? gameInput.GetKeyboardPrimaryPositiveBindingText();
					case "-":
						if (!isSteamDeckOrBigPicture)
						{
							return gameInput.GetKeyboardPrimaryNegativeBindingText();
						}
						return gameInput.GetControllerNegativeBindingText() ?? gameInput.GetKeyboardPrimaryNegativeBindingText();
					case "name":
						return gameInput.DescriptiveName;
					default:
						return gameInput.GetFirstBindingText();
					}
				}
				Debug.LogError("Cannot find input with the ID " + text);
				return (string)null;
			});
		}

		public static void ScrollToTarget(RectTransform target, ScrollRect scrollRect, float offset)
		{
			if (scrollRect.GetComponent<RectTransform>().pivot.y != 1f)
			{
				Debug.LogWarning("ScrollToItem: Scroll Rect must have pivot.y set to 1");
			}
			if (!scrollRect.vertical || scrollRect.horizontal)
			{
				Debug.LogWarning("ScrollToItem: Only vertical scroll rects are supported.");
			}
			Vector2 anchoredPosition = scrollRect.content.anchoredPosition;
			RectTransform component = scrollRect.GetComponent<RectTransform>();
			float y = component.InverseTransformPoint(target.position).y;
			float y2 = component.InverseTransformPoint(scrollRect.content.position).y;
			if (y > 0f)
			{
				anchoredPosition.y = y2 - y + offset;
			}
			else if (y < 0f - component.rect.height)
			{
				anchoredPosition.y = y2 - (y + component.rect.height) - offset;
			}
			scrollRect.content.anchoredPosition = anchoredPosition;
		}

		private static Func<float, Vector3> GetScalerFunc(ExpandType expandType)
		{
			Func<float, Vector3> result = null;
			switch (expandType)
			{
			case ExpandType.Vertical:
				result = (float x) => new Vector3(1f, x, 1f);
				break;
			case ExpandType.Horizontal:
				result = (float x) => new Vector3(x, 1f, 1f);
				break;
			case ExpandType.HorizontalAndVertical:
				result = (float x) => new Vector3(x, x, 1f);
				break;
			}
			return result;
		}

		private static void RegisterDynamicRow(Dictionary<TMP_Text, Func<string>> textElements, TMP_Text text, Func<string> updater)
		{
			textElements.Add(text, updater);
		}
	}
}
