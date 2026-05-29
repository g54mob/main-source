using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace XCharts.Runtime
{
	public static class ChartHelper
	{
		private static StringBuilder s_Builder = new StringBuilder();

		private static Vector3 s_DefaultIngoreDataVector3 = Vector3.zero;

		public static StringBuilder sb => s_Builder;

		public static Vector3 ignoreVector3 => s_DefaultIngoreDataVector3;

		public static bool IsIngore(Vector3 pos)
		{
			return pos == s_DefaultIngoreDataVector3;
		}

		public static string Cancat(string str1, string str2)
		{
			s_Builder.Length = 0;
			s_Builder.Append(str1).Append(str2);
			return s_Builder.ToString();
		}

		public static string Cancat(string str1, int i)
		{
			s_Builder.Length = 0;
			s_Builder.Append(str1).Append(ChartCached.IntToStr(i));
			return s_Builder.ToString();
		}

		public static void SetActive(GameObject gameObject, bool active)
		{
			if (!(gameObject == null))
			{
				SetActive(gameObject.transform, active);
			}
		}

		public static void SetActive(Image image, bool active)
		{
			if (!(image == null))
			{
				SetActive(image.gameObject, active);
			}
		}

		public static void SetActive(Text text, bool active)
		{
			if (!(text == null))
			{
				SetActive(text.gameObject, active);
			}
		}

		public static void SetActive(Transform transform, bool active)
		{
			if (!(transform == null))
			{
				if (active)
				{
					transform.localScale = Vector3.one;
				}
				else
				{
					transform.localScale = Vector3.zero;
				}
			}
		}

		public static void HideAllObject(GameObject obj, string match = null)
		{
			if (!(obj == null))
			{
				HideAllObject(obj.transform, match);
			}
		}

		public static void HideAllObject(Transform parent, string match = null)
		{
			if (!(parent == null))
			{
				ActiveAllObject(parent, active: false, match);
			}
		}

		public static void ActiveAllObject(Transform parent, bool active, string match = null)
		{
			if (parent == null)
			{
				return;
			}
			for (int i = 0; i < parent.childCount; i++)
			{
				if (match == null)
				{
					SetActive(parent.GetChild(i), active);
					continue;
				}
				Transform child = parent.GetChild(i);
				if (child.name.StartsWith(match))
				{
					SetActive(child, active);
				}
			}
		}

		public static void DestroyAllChildren(Transform parent)
		{
			if (parent == null)
			{
				return;
			}
			for (int num = parent.childCount - 1; num >= 0; num--)
			{
				Transform child = parent.GetChild(num);
				if (child != null)
				{
					UnityEngine.Object.DestroyImmediate(child.gameObject, allowDestroyingAssets: true);
				}
			}
		}

		public static void DestoryGameObject(Transform parent, string childName)
		{
			if (!(parent == null))
			{
				Transform transform = parent.Find(childName);
				if (transform != null)
				{
					UnityEngine.Object.DestroyImmediate(transform.gameObject, allowDestroyingAssets: true);
				}
			}
		}

		public static void DestoryGameObjectByMatch(Transform parent, string containString)
		{
			if (parent == null)
			{
				return;
			}
			for (int num = parent.childCount - 1; num >= 0; num--)
			{
				Transform child = parent.GetChild(num);
				if (child != null && child.name.Contains(containString))
				{
					UnityEngine.Object.DestroyImmediate(child.gameObject, allowDestroyingAssets: true);
				}
			}
		}

		public static void DestoryGameObject(GameObject go)
		{
			if (go != null)
			{
				UnityEngine.Object.DestroyImmediate(go, allowDestroyingAssets: true);
			}
		}

		public static string GetFullName(Transform transform)
		{
			string text = transform.name;
			Transform transform2 = transform;
			while ((bool)transform2.transform.parent)
			{
				text = transform2.transform.parent.name + "/" + text;
				transform2 = transform2.transform.parent;
			}
			return text;
		}

		public static void RemoveComponent<T>(GameObject gameObject)
		{
			T component = gameObject.GetComponent<T>();
			if (component != null)
			{
				UnityEngine.Object.Destroy(component as UnityEngine.Object);
			}
		}

		[Obsolete("Use EnsureComponent instead")]
		public static T GetOrAddComponent<T>(Transform transform) where T : Component
		{
			return EnsureComponent<T>(transform.gameObject);
		}

		[Obsolete("Use EnsureComponent instead")]
		public static T GetOrAddComponent<T>(GameObject gameObject) where T : Component
		{
			return EnsureComponent<T>(gameObject);
		}

		public static T EnsureComponent<T>(Transform transform) where T : Component
		{
			return EnsureComponent<T>(transform.gameObject);
		}

		public static T EnsureComponent<T>(GameObject gameObject) where T : Component
		{
			if (gameObject.GetComponent<T>() == null)
			{
				return gameObject.AddComponent<T>();
			}
			return gameObject.GetComponent<T>();
		}

		public static GameObject AddObject(string name, Transform parent, Vector2 anchorMin, Vector2 anchorMax, Vector2 pivot, Vector2 sizeDelta, int replaceIndex = -1)
		{
			GameObject gameObject;
			if ((bool)parent.Find(name))
			{
				gameObject = parent.Find(name).gameObject;
				SetActive(gameObject, active: true);
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
			}
			else if (replaceIndex >= 0 && replaceIndex < parent.childCount)
			{
				gameObject = parent.GetChild(replaceIndex).gameObject;
				if (!gameObject.name.Equals(name))
				{
					gameObject.name = name;
				}
				SetActive(gameObject, active: true);
			}
			else
			{
				gameObject = new GameObject();
				gameObject.name = name;
				gameObject.transform.SetParent(parent);
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
				gameObject.layer = parent.gameObject.layer;
			}
			RectTransform rectTransform = EnsureComponent<RectTransform>(gameObject);
			rectTransform.localPosition = Vector3.zero;
			rectTransform.sizeDelta = sizeDelta;
			rectTransform.anchorMin = anchorMin;
			rectTransform.anchorMax = anchorMax;
			rectTransform.pivot = pivot;
			rectTransform.anchoredPosition3D = Vector3.zero;
			return gameObject;
		}

		public static void UpdateRectTransform(GameObject obj, Vector2 anchorMin, Vector2 anchorMax, Vector2 pivot, Vector2 sizeDelta)
		{
			if (!(obj == null))
			{
				RectTransform rectTransform = EnsureComponent<RectTransform>(obj);
				rectTransform.sizeDelta = sizeDelta;
				rectTransform.anchorMin = anchorMin;
				rectTransform.anchorMax = anchorMax;
				rectTransform.pivot = pivot;
			}
		}

		public static ChartText AddTextObject(string objectName, Transform parent, Vector2 anchorMin, Vector2 anchorMax, Vector2 pivot, Vector2 sizeDelta, TextStyle textStyle, ComponentTheme theme, Color autoColor, TextAnchor autoAlignment, ChartText chartText = null)
		{
			GameObject gameObject = AddObject(objectName, parent, anchorMin, anchorMax, pivot, sizeDelta);
			gameObject.transform.localEulerAngles = new Vector3(0f, 0f, textStyle.rotate);
			gameObject.layer = parent.gameObject.layer;
			if (chartText == null)
			{
				chartText = new ChartText();
			}
			chartText.text = EnsureComponent<Text>(gameObject);
			chartText.text.font = ((textStyle.font == null) ? theme.font : textStyle.font);
			chartText.text.fontStyle = textStyle.fontStyle;
			chartText.text.horizontalOverflow = ((!textStyle.autoWrap) ? HorizontalWrapMode.Overflow : HorizontalWrapMode.Wrap);
			chartText.text.verticalOverflow = VerticalWrapMode.Overflow;
			chartText.text.supportRichText = true;
			chartText.text.raycastTarget = false;
			if (textStyle.autoColor && autoColor != Color.clear)
			{
				chartText.SetColor(autoColor);
			}
			else
			{
				chartText.SetColor(textStyle.GetColor(theme.textColor));
			}
			chartText.SetAlignment(textStyle.autoAlign ? autoAlignment : textStyle.alignment);
			chartText.SetFontSize(textStyle.GetFontSize(theme));
			chartText.SetText("Text");
			chartText.SetLineSpacing(textStyle.lineSpacing);
			chartText.SetActive(textStyle.show);
			RectTransform rectTransform = EnsureComponent<RectTransform>(gameObject);
			rectTransform.localPosition = Vector3.zero;
			rectTransform.sizeDelta = sizeDelta;
			rectTransform.anchorMin = anchorMin;
			rectTransform.anchorMax = anchorMax;
			rectTransform.pivot = pivot;
			return chartText;
		}

		public static Painter AddPainterObject(string name, Transform parent, Vector2 anchorMin, Vector2 anchorMax, Vector2 pivot, Vector2 sizeDelta, HideFlags hideFlags, int siblingIndex)
		{
			GameObject gameObject = AddObject(name, parent, anchorMin, anchorMax, pivot, sizeDelta);
			gameObject.hideFlags = hideFlags;
			gameObject.transform.SetSiblingIndex(siblingIndex);
			return EnsureComponent<Painter>(gameObject);
		}

		public static Image AddIcon(string name, Transform parent, IconStyle iconStyle)
		{
			return AddIcon(name, parent, iconStyle.width, iconStyle.height, iconStyle.sprite, iconStyle.type);
		}

		public static Image AddIcon(string name, Transform parent, float width, float height, Sprite sprite = null, Image.Type type = Image.Type.Simple)
		{
			Vector2 anchorMax = new Vector2(0.5f, 0.5f);
			Vector2 anchorMin = new Vector2(0.5f, 0.5f);
			Vector2 pivot = new Vector2(0.5f, 0.5f);
			Vector2 sizeDelta = new Vector2(width, height);
			Image image = EnsureComponent<Image>(AddObject(name, parent, anchorMin, anchorMax, pivot, sizeDelta));
			if (image.raycastTarget)
			{
				image.raycastTarget = false;
			}
			if (image.type != type)
			{
				image.type = type;
			}
			if (sprite != null && image.sprite != sprite)
			{
				image.sprite = sprite;
				if (width == 0f || height == 0f)
				{
					image.SetNativeSize();
				}
			}
			return image;
		}

		public static void SetBackground(Image background, ImageStyle imageStyle)
		{
			if (background == null)
			{
				return;
			}
			if (imageStyle.show)
			{
				background.gameObject.SetActive(value: true);
				background.sprite = imageStyle.sprite;
				background.color = imageStyle.color;
				background.type = imageStyle.type;
				if (imageStyle.width > 0f && imageStyle.height > 0f)
				{
					background.rectTransform.sizeDelta = new Vector2(imageStyle.width, imageStyle.height);
				}
			}
			else
			{
				background.sprite = null;
				background.color = Color.clear;
				background.gameObject.SetActive(value: false);
			}
		}

		public static ChartLabel AddAxisLabelObject(int total, int index, string name, Transform parent, Vector2 sizeDelta, Axis axis, ComponentTheme theme, string content, Color autoColor, TextAnchor autoAlignment = TextAnchor.MiddleCenter, Color32 iconDefaultColor = default(Color32))
		{
			_ = axis.axisLabel.textStyle;
			ChartLabel chartLabel = AddChartLabel(name, parent, axis.axisLabel, theme, content, autoColor, autoAlignment);
			bool active = axis.IsNeedShowLabel(index, total);
			chartLabel.UpdateIcon(axis.axisLabel.icon, axis.GetIcon(index), iconDefaultColor);
			chartLabel.text.SetActive(active);
			return chartLabel;
		}

		public static ChartLabel AddChartLabel(string name, Transform parent, LabelStyle labelStyle, ComponentTheme theme, string content, Color autoColor, TextAnchor autoAlignment = TextAnchor.MiddleCenter)
		{
			Vector2 sizeDelta = new Vector2(labelStyle.width, labelStyle.height);
			TextStyle textStyle = labelStyle.textStyle;
			UpdateAnchorAndPivotByTextAlignment(textStyle.GetAlignment(autoAlignment), out var anchorMin, out var anchorMax, out var pivot);
			ChartLabel chartLabel = EnsureComponent<ChartLabel>(AddObject(name, parent, anchorMin, anchorMax, pivot, sizeDelta));
			chartLabel.text = AddTextObject("Text", chartLabel.gameObject.transform, anchorMin, anchorMax, pivot, sizeDelta, textStyle, theme, autoColor, autoAlignment, chartLabel.text);
			chartLabel.icon = AddIcon("Icon", chartLabel.gameObject.transform, labelStyle.icon);
			chartLabel.SetSize(labelStyle.width, labelStyle.height);
			chartLabel.SetTextPadding(labelStyle.textPadding);
			chartLabel.SetText(content);
			chartLabel.UpdateIcon(labelStyle.icon);
			if (labelStyle.background.show)
			{
				chartLabel.color = ((!labelStyle.background.autoColor || autoColor == Color.clear) ? labelStyle.background.color : autoColor);
				chartLabel.sprite = labelStyle.background.sprite;
				chartLabel.type = labelStyle.background.type;
			}
			else
			{
				chartLabel.color = Color.clear;
				chartLabel.sprite = null;
			}
			chartLabel.transform.localEulerAngles = new Vector3(0f, 0f, labelStyle.rotate);
			chartLabel.transform.localPosition = labelStyle.offset;
			return chartLabel;
		}

		public static ChartLabel AddChartLabel2(string name, Transform parent, LabelStyle labelStyle, ComponentTheme theme, string content, Color autoColor, TextAnchor autoAlignment = TextAnchor.MiddleCenter)
		{
			Vector2 sizeDelta = new Vector2(labelStyle.width, labelStyle.height);
			TextStyle textStyle = labelStyle.textStyle;
			UpdateAnchorAndPivotByTextAlignment(textStyle.GetAlignment(autoAlignment), out var anchorMin, out var anchorMax, out var pivot);
			Vector2 vector = new Vector2(0.5f, 0.5f);
			ChartLabel chartLabel = EnsureComponent<ChartLabel>(AddObject(name, parent, vector, vector, vector, sizeDelta));
			chartLabel.text = AddTextObject("Text", chartLabel.gameObject.transform, anchorMin, anchorMax, pivot, sizeDelta, textStyle, theme, autoColor, autoAlignment, chartLabel.text);
			chartLabel.icon = AddIcon("Icon", chartLabel.gameObject.transform, labelStyle.icon);
			chartLabel.SetSize(labelStyle.width, labelStyle.height);
			chartLabel.SetTextPadding(labelStyle.textPadding);
			chartLabel.SetText(content);
			chartLabel.UpdateIcon(labelStyle.icon);
			if (labelStyle.background.show)
			{
				chartLabel.color = ((!labelStyle.background.autoColor || autoColor == Color.clear) ? labelStyle.background.color : autoColor);
				chartLabel.sprite = labelStyle.background.sprite;
				chartLabel.type = labelStyle.background.type;
			}
			else
			{
				chartLabel.color = Color.clear;
				chartLabel.sprite = null;
			}
			chartLabel.transform.localEulerAngles = new Vector3(0f, 0f, labelStyle.rotate);
			chartLabel.transform.localPosition = labelStyle.offset;
			return chartLabel;
		}

		private static void UpdateAnchorAndPivotByTextAlignment(TextAnchor alignment, out Vector2 anchorMin, out Vector2 anchorMax, out Vector2 pivot)
		{
			switch (alignment)
			{
			case TextAnchor.LowerLeft:
				anchorMin = new Vector2(0f, 0f);
				anchorMax = new Vector2(0f, 0f);
				pivot = new Vector2(0f, 0f);
				break;
			case TextAnchor.UpperLeft:
				anchorMin = new Vector2(0f, 1f);
				anchorMax = new Vector2(0f, 1f);
				pivot = new Vector2(0f, 1f);
				break;
			case TextAnchor.MiddleLeft:
				anchorMin = new Vector2(0f, 0.5f);
				anchorMax = new Vector2(0f, 0.5f);
				pivot = new Vector2(0f, 0.5f);
				break;
			case TextAnchor.LowerRight:
				anchorMin = new Vector2(1f, 0f);
				anchorMax = new Vector2(1f, 0f);
				pivot = new Vector2(1f, 0f);
				break;
			case TextAnchor.UpperRight:
				anchorMin = new Vector2(1f, 1f);
				anchorMax = new Vector2(1f, 1f);
				pivot = new Vector2(1f, 1f);
				break;
			case TextAnchor.MiddleRight:
				anchorMin = new Vector2(1f, 0.5f);
				anchorMax = new Vector2(1f, 0.5f);
				pivot = new Vector2(1f, 0.5f);
				break;
			case TextAnchor.LowerCenter:
				anchorMin = new Vector2(0.5f, 0f);
				anchorMax = new Vector2(0.5f, 0f);
				pivot = new Vector2(0.5f, 0f);
				break;
			case TextAnchor.UpperCenter:
				anchorMin = new Vector2(0.5f, 1f);
				anchorMax = new Vector2(0.5f, 1f);
				pivot = new Vector2(0.5f, 1f);
				break;
			case TextAnchor.MiddleCenter:
				anchorMin = new Vector2(0.5f, 0.5f);
				anchorMax = new Vector2(0.5f, 0.5f);
				pivot = new Vector2(0.5f, 0.5f);
				break;
			default:
				anchorMin = new Vector2(0.5f, 0.5f);
				anchorMax = new Vector2(0.5f, 0.5f);
				pivot = new Vector2(0.5f, 0.5f);
				break;
			}
		}

		internal static ChartLabel AddTooltipIndicatorLabel(Tooltip tooltip, string name, Transform parent, ThemeStyle theme, TextAnchor alignment, LabelStyle labelStyle)
		{
			ChartLabel chartLabel = AddChartLabel(name, parent, labelStyle, theme.tooltip, "", Color.clear, alignment);
			chartLabel.SetActive(tooltip.show && labelStyle.show);
			return chartLabel;
		}

		public static void GetPointList(ref List<Vector3> posList, Vector3 sp, Vector3 ep, float k = 30f)
		{
			Vector3 normalized = (ep - sp).normalized;
			float num = Vector3.Distance(sp, ep);
			int num2 = (int)(num / k);
			posList.Clear();
			posList.Add(sp);
			for (int i = 1; i < num2; i++)
			{
				posList.Add(sp + normalized * num * i / num2);
			}
			posList.Add(ep);
		}

		public static bool IsValueEqualsColor(Color32 color1, Color32 color2)
		{
			if (color1.a == color2.a && color1.b == color2.b && color1.g == color2.g)
			{
				return color1.r == color2.r;
			}
			return false;
		}

		public static bool IsValueEqualsColor(Color color1, Color color2)
		{
			if (color1.a == color2.a && color1.b == color2.b && color1.g == color2.g)
			{
				return color1.r == color2.r;
			}
			return false;
		}

		public static bool IsValueEqualsString(string str1, string str2)
		{
			if (str1 == null && str2 == null)
			{
				return true;
			}
			if (str1 != null && str2 != null)
			{
				return str1.Equals(str2);
			}
			return false;
		}

		public static bool IsValueEqualsVector2(Vector2 v1, Vector2 v2)
		{
			if (v1.x == v2.x)
			{
				return v1.y == v2.y;
			}
			return false;
		}

		public static bool IsValueEqualsVector3(Vector3 v1, Vector3 v2)
		{
			if (v1.x == v2.x && v1.y == v2.y)
			{
				return v1.z == v2.z;
			}
			return false;
		}

		public static bool IsValueEqualsList<T>(List<T> list1, List<T> list2)
		{
			if (list1 == null || list2 == null)
			{
				return false;
			}
			if (list1.Count != list2.Count)
			{
				return false;
			}
			for (int i = 0; i < list1.Count; i++)
			{
				if (list1[i] == null && list2[i] == null)
				{
					continue;
				}
				if (list1[i] != null)
				{
					if (!list1[i].Equals(list2[i]))
					{
						return false;
					}
				}
				else if (!list2[i].Equals(list1[i]))
				{
					return false;
				}
			}
			return true;
		}

		public static bool IsEquals(double d1, double d2)
		{
			return Math.Abs(d1 - d2) < 1E-06;
		}

		public static bool IsEquals(float d1, float d2)
		{
			return Math.Abs(d1 - d2) < 1E-06f;
		}

		public static bool IsClearColor(Color32 color)
		{
			if (color.a == 0 && color.b == 0 && color.g == 0)
			{
				return color.r == 0;
			}
			return false;
		}

		public static bool IsClearColor(Color color)
		{
			if (color.a == 0f && color.b == 0f && color.g == 0f)
			{
				return color.r == 0f;
			}
			return false;
		}

		public static bool IsZeroVector(Vector3 pos)
		{
			if (pos.x == 0f && pos.y == 0f)
			{
				return pos.z == 0f;
			}
			return false;
		}

		public static bool CopyList<T>(List<T> toList, List<T> fromList)
		{
			if (toList == null || fromList == null)
			{
				return false;
			}
			toList.Clear();
			foreach (T from in fromList)
			{
				toList.Add(from);
			}
			return true;
		}

		public static bool CopyArray<T>(T[] toList, T[] fromList)
		{
			if (toList == null || fromList == null)
			{
				return false;
			}
			if (toList.Length != fromList.Length)
			{
				toList = new T[fromList.Length];
			}
			for (int i = 0; i < fromList.Length; i++)
			{
				toList[i] = fromList[i];
			}
			return true;
		}

		public static List<float> ParseFloatFromString(string jsonData)
		{
			List<float> list = new List<float>();
			if (string.IsNullOrEmpty(jsonData))
			{
				return list;
			}
			int num = jsonData.IndexOf("[");
			int num2 = jsonData.IndexOf("]");
			string text = jsonData.Substring(num + 1, num2 - num - 1);
			if (text.IndexOf("],") > -1 || text.IndexOf("] ,") > -1)
			{
				string[] array = text.Split(new string[2] { "],", "] ," }, StringSplitOptions.RemoveEmptyEntries);
				for (int i = 0; i < array.Length; i++)
				{
					text = array[i];
				}
				return list;
			}
			string[] array2 = text.Split(',');
			for (int j = 0; j < array2.Length; j++)
			{
				list.Add(float.Parse(array2[j].Trim()));
			}
			return list;
		}

		public static List<string> ParseStringFromString(string jsonData)
		{
			List<string> list = new List<string>();
			if (string.IsNullOrEmpty(jsonData))
			{
				return list;
			}
			string pattern = "[\"'](.*?)[\"']";
			if (Regex.IsMatch(jsonData, pattern))
			{
				foreach (Match item in Regex.Matches(jsonData, pattern))
				{
					list.Add(item.Groups[1].Value);
				}
			}
			return list;
		}

		public static Color32 GetColor(string hexColorStr)
		{
			ColorUtility.TryParseHtmlString(hexColorStr, out var color);
			return color;
		}

		public static double GetMaxDivisibleValue(double max, double ceilRate)
		{
			if (max == 0.0)
			{
				return 0.0;
			}
			double num = 1.0;
			if (max > -1.0 && max < 1.0)
			{
				num = Mathf.Pow(10f, MathUtil.GetPrecision(max));
				max *= num;
			}
			if (ceilRate == 0.0)
			{
				double num2 = Math.Ceiling(Math.Abs(max));
				int i;
				for (i = 1; num2 / (double)Mathf.Pow(10f, i) > 10.0; i++)
				{
				}
				double num3 = num2;
				float num4 = Mathf.Pow(10f, i);
				float num5 = Mathf.Pow(10f, i + 1);
				bool flag = num3 % (double)num4 == 0.0;
				if (num3 > 10.0 && i < 38)
				{
					num3 = num2 - num2 % (double)num4;
					if (!flag)
					{
						num3 += (double)((max > 0.0) ? num4 : (0f - num4));
					}
				}
				double num6 = num3;
				if (max > 100.0 && !flag && max / num3 < 0.800000011920929)
				{
					num6 -= (double)(Mathf.Pow(10f, i) / 2f);
				}
				if (num6 >= (double)(num5 - num4) && num6 < (double)num5)
				{
					num6 = num5;
				}
				if (max < 0.0)
				{
					return 0.0 - Math.Ceiling((num6 > 0.0 - max) ? num6 : num3);
				}
				return Math.Ceiling((num6 > max) ? num6 : num3) / num;
			}
			return GetMaxCeilRate(max, ceilRate) / num;
		}

		public static double GetMaxCeilRate(double value, double ceilRate)
		{
			if (ceilRate == 0.0)
			{
				return value;
			}
			double num = value % ceilRate;
			int num2 = (int)(value / ceilRate);
			if (num != 0.0)
			{
				return (double)((value < 0.0) ? num2 : (num2 + 1)) * ceilRate;
			}
			return value;
		}

		public static double GetMinCeilRate(double value, double ceilRate)
		{
			if (ceilRate == 0.0)
			{
				return value;
			}
			double num = value % ceilRate;
			int num2 = (int)(value / ceilRate);
			if (num != 0.0)
			{
				return (double)((value < 0.0) ? (num2 - 1) : num2) * ceilRate;
			}
			return value;
		}

		public static double GetMinDivisibleValue(double min, double ceilRate)
		{
			if (min == 0.0)
			{
				return 0.0;
			}
			double num = 1.0;
			if (min > -1.0 && min < 1.0)
			{
				num = Mathf.Pow(10f, MathUtil.GetPrecision(min));
				min *= num;
			}
			if (ceilRate == 0.0)
			{
				double num2 = ((min < 0.0) ? Math.Ceiling(Math.Abs(min)) : Math.Floor(Math.Abs(min)));
				int i;
				for (i = 1; num2 / (double)Mathf.Pow(10f, i) > 10.0; i++)
				{
				}
				double num3 = num2;
				if (num3 > 10.0 && i < 38)
				{
					num3 = num2 - num2 % (double)Mathf.Pow(10f, i);
					num3 += (double)((min < 0.0) ? Mathf.Pow(10f, i) : (0f - Mathf.Pow(10f, i)));
				}
				if (min < 0.0)
				{
					return (0.0 - Math.Floor(num3)) / num;
				}
				return Math.Floor(num3) / num;
			}
			return GetMinCeilRate(min, ceilRate) / num;
		}

		public static double GetMaxLogValue(double value, float logBase, bool isLogBaseE, out int splitNumber)
		{
			splitNumber = 0;
			if (value <= 0.0)
			{
				return 0.0;
			}
			double num = 0.0;
			while (num < value)
			{
				num = ((!isLogBaseE) ? Math.Pow(logBase, splitNumber) : Math.Exp(splitNumber));
				splitNumber++;
			}
			return num;
		}

		public static double GetMinLogValue(double value, float logBase, bool isLogBaseE, out int splitNumber)
		{
			splitNumber = 0;
			if (value > 1.0)
			{
				return 1.0;
			}
			double num = 1.0;
			while (num > value)
			{
				num = ((!isLogBaseE) ? Math.Pow(logBase, -splitNumber) : Math.Exp(-splitNumber));
				splitNumber++;
			}
			return num;
		}

		public static void AddEventListener(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> call)
		{
			EventTrigger eventTrigger = EnsureComponent<EventTrigger>(obj.gameObject);
			EventTrigger.Entry entry = new EventTrigger.Entry();
			entry.eventID = type;
			entry.callback = new EventTrigger.TriggerEvent();
			entry.callback.AddListener(call);
			eventTrigger.triggers.Add(entry);
		}

		public static void ClearEventListener(GameObject obj)
		{
			EventTrigger component = obj.GetComponent<EventTrigger>();
			if (component != null)
			{
				component.triggers.Clear();
			}
		}

		public static Vector3 RotateRound(Vector3 position, Vector3 center, Vector3 axis, float angle)
		{
			Vector3 vector = Quaternion.AngleAxis(angle, axis) * (position - center);
			return center + vector;
		}

		public static Vector3 GetPosition(Vector3 center, float angle, float radius)
		{
			float f = angle * (MathF.PI / 180f);
			float x = Mathf.Sin(f) * radius;
			float y = Mathf.Cos(f) * radius;
			return center + new Vector3(x, y);
		}

		public static float GetAngle360(Vector2 from, Vector2 to)
		{
			Vector3 vector = Vector3.Cross(from, to);
			float num = Vector2.Angle(from, to);
			num = ((vector.z > 0f) ? (0f - num) : num);
			return (num + 360f) % 360f;
		}

		public static Vector3 GetPos(Vector3 center, float radius, float angle, bool isDegree = false)
		{
			angle = (isDegree ? (angle * (MathF.PI / 180f)) : angle);
			return new Vector3(center.x + radius * Mathf.Sin(angle), center.y + radius * Mathf.Cos(angle));
		}

		public static Vector3 GetDire(float angle, bool isDegree = false)
		{
			angle = (isDegree ? (angle * (MathF.PI / 180f)) : angle);
			return new Vector3(Mathf.Sin(angle), Mathf.Cos(angle));
		}

		public static Vector3 GetVertialDire(Vector3 dire)
		{
			if (dire.x == 0f)
			{
				return new Vector3(-1f, 0f, 0f);
			}
			if (dire.y == 0f)
			{
				return new Vector3(0f, -1f, 0f);
			}
			return new Vector3((0f - dire.y) / dire.x, 1f, 0f).normalized;
		}

		public static Vector3 GetLastValue(List<Vector3> list)
		{
			if (list.Count <= 0)
			{
				return Vector3.zero;
			}
			return list[list.Count - 1];
		}

		public static void SetColorOpacity(ref Color32 color, float opacity)
		{
			if (color.a != 0 && opacity != 1f)
			{
				color.a = (byte)((float)(int)color.a * opacity);
			}
		}

		public static Color32 GetHighlightColor(Color32 color, float rate = 0.8f)
		{
			Color32 result = color;
			result.r = (byte)((float)(int)color.r * rate);
			result.g = (byte)((float)(int)color.g * rate);
			result.b = (byte)((float)(int)color.b * rate);
			return result;
		}

		public static Color32 GetBlurColor(Color32 color, float a = 0.3f)
		{
			Color32 result = color;
			result.a = (byte)(a * 255f);
			return result;
		}

		public static Color32 GetSelectColor(Color32 color, float rate = 0.8f)
		{
			Color32 result = color;
			result.r = (byte)((float)(int)color.r * rate);
			result.g = (byte)((float)(int)color.g * rate);
			result.b = (byte)((float)(int)color.b * rate);
			return result;
		}

		public static bool IsPointInQuadrilateral(Vector3 P, Vector3 A, Vector3 B, Vector3 C, Vector3 D)
		{
			Vector3 lhs = Vector3.Cross(A - D, P - D);
			Vector3 rhs = Vector3.Cross(B - A, P - A);
			Vector3 rhs2 = Vector3.Cross(C - B, P - B);
			Vector3 rhs3 = Vector3.Cross(D - C, P - C);
			if (Vector3.Dot(lhs, rhs) < 0f || Vector3.Dot(lhs, rhs2) < 0f || Vector3.Dot(lhs, rhs3) < 0f)
			{
				return false;
			}
			return true;
		}

		public static bool IsInRect(Vector3 pos, float xMin, float xMax, float yMin, float yMax)
		{
			if (pos.x >= xMin && pos.x <= xMax && pos.y <= yMax)
			{
				return pos.y >= yMin;
			}
			return false;
		}

		public static bool IsColorAlphaZero(Color color)
		{
			if (!IsClearColor(color))
			{
				return color.a == 0f;
			}
			return false;
		}

		public static float GetActualValue(float valueOrRate, float total, float maxRate = 1.5f)
		{
			if (valueOrRate >= 0f - maxRate && valueOrRate <= maxRate)
			{
				return valueOrRate * total;
			}
			return valueOrRate;
		}

		public static Texture2D SaveAsImage(RectTransform rectTransform, Canvas canvas, string imageType = "png", string path = "")
		{
			Vector2 vector = RectTransformUtility.WorldToScreenPoint((canvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : canvas.worldCamera, rectTransform.position);
			float num = rectTransform.rect.width * canvas.scaleFactor;
			float num2 = rectTransform.rect.height * canvas.scaleFactor;
			float x = vector.x + rectTransform.rect.xMin * canvas.scaleFactor;
			float y = vector.y + rectTransform.rect.yMin * canvas.scaleFactor;
			Rect source = new Rect(x, y, num, num2);
			Texture2D texture2D = new Texture2D((int)num, (int)num2, TextureFormat.RGBA32, mipChain: false);
			texture2D.ReadPixels(source, 0, 0);
			texture2D.Apply();
			byte[] bytes;
			switch (imageType)
			{
			case "png":
				bytes = texture2D.EncodeToPNG();
				break;
			case "jpg":
				bytes = texture2D.EncodeToJPG();
				break;
			case "exr":
				bytes = texture2D.EncodeToEXR();
				break;
			default:
				Debug.LogError("SaveAsImage ERROR: not support image type:" + imageType);
				return null;
			}
			string text = rectTransform.name + "." + imageType;
			if (string.IsNullOrEmpty(path))
			{
				string text2 = Application.persistentDataPath + "/SavedImage";
				text2 = Application.persistentDataPath + "/SavedImage";
				if (!Directory.Exists(text2))
				{
					Directory.CreateDirectory(text2);
				}
				path = text2 + "/" + text;
			}
			File.WriteAllBytes(path, bytes);
			Debug.Log("SaveAsImage:" + path);
			return texture2D;
		}
	}
}
