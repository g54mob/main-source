using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Tools;
using NSMedieval.Utils.Pool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class InfoCursor : MonoBehaviour
	{
		private List<TextMeshProUGUI> elements = new List<TextMeshProUGUI>();

		private int elementsToShowCount;

		private float baseFontSize;

		[SerializeField]
		private GameObject cursorLinePrefab;

		[SerializeField]
		private GameObject infoCursorChild;

		[SerializeField]
		private Image backgroundImage;

		[SerializeField]
		private Vector3 offset;

		[SerializeField]
		private int maxCharacters = 240;

		private readonly Dictionary<string, List<string>> content = new Dictionary<string, List<string>>();

		private readonly HashSet<string> isShowingContentByTag = new HashSet<string>();

		private readonly Dictionary<string, float> fontSizeByTag = new Dictionary<string, float>();

		private readonly Dictionary<string, int> sortValueByTag = new Dictionary<string, int>();

		private void UpdateElementsList(int elementsCount)
		{
			if (elements.Count < elementsCount)
			{
				int num = elementsCount - elements.Count;
				for (int i = 0; i < num; i++)
				{
					elements.Add(UnityEngine.Object.Instantiate(cursorLinePrefab, infoCursorChild.transform).GetComponent<TextMeshProUGUI>());
				}
			}
		}

		private IEnumerator Show(bool background)
		{
			for (int i = 0; i < elementsToShowCount; i++)
			{
				if (!elements[i].gameObject.activeSelf)
				{
					elements[i].gameObject.SetActive(value: true);
				}
			}
			yield return null;
			if (elementsToShowCount > 0)
			{
				backgroundImage.gameObject.SetActive(value: true);
			}
			background &= elementsToShowCount != 0;
			if (backgroundImage.enabled != background)
			{
				backgroundImage.enabled = background;
			}
		}

		private void OnInfoCursorToggle(bool active, string tag)
		{
			if (!active)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(19, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\InfoCursor.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("(");
					messageBuilder.AppendFormatted(isShowingContentByTag.Count);
					messageBuilder.AppendLiteral(") Contais tag: ");
					messageBuilder.AppendFormatted(tag);
					messageBuilder.AppendLiteral(": ");
					messageBuilder.AppendFormatted(isShowingContentByTag.Contains(tag));
					messageBuilder.AppendLiteral(" ");
				}
				Log.Trace(messageBuilder);
				if (isShowingContentByTag.Contains(tag))
				{
					isShowingContentByTag.Remove(tag);
				}
			}
			else if (!isShowingContentByTag.Contains(tag))
			{
				isShowingContentByTag.Add(tag);
			}
			UpdateInfoCursorContent(backgroundImage.enabled);
		}

		private void SetTagContent(string tag, List<string> content, float fontSize, int sortValue)
		{
			if (!this.content.ContainsKey(tag))
			{
				this.content.Add(tag, new List<string>());
			}
			else if (this.content[tag] == null)
			{
				this.content[tag] = new List<string>(content);
			}
			if (!fontSizeByTag.ContainsKey(tag))
			{
				fontSizeByTag.Add(tag, fontSize);
			}
			else
			{
				fontSizeByTag[tag] = fontSize;
			}
			if (!sortValueByTag.ContainsKey(tag))
			{
				sortValueByTag.Add(tag, sortValue);
			}
			else
			{
				sortValueByTag[tag] = sortValue;
			}
			this.content[tag].Clear();
			this.content[tag].AddRange(content);
			isShowingContentByTag.Add(tag);
		}

		private void OnUpdateInfoCursorContent(List<string> textLines, string tag, int sortValue, bool background, float fontSizeScaler)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(33, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\InfoCursor.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Update Content tag: ");
				messageBuilder.AppendFormatted(tag);
				messageBuilder.AppendLiteral(" background: ");
				messageBuilder.AppendFormatted(background);
			}
			Log.Trace(messageBuilder);
			backgroundImage.enabled = background;
			SetTagContent(tag, textLines, fontSizeScaler, sortValue);
			UpdateInfoCursorContent(background);
		}

		private void OnUpdateInfoCursorBackground(bool isActive)
		{
			backgroundImage.enabled = isActive;
		}

		private void UpdateInfoCursorContent(bool showBackground)
		{
			int num = 0;
			foreach (KeyValuePair<string, List<string>> item in content)
			{
				if (isShowingContentByTag.Contains(item.Key))
				{
					num += item.Value.Count;
				}
			}
			UpdateElementsList(num);
			int num2 = 0;
			List<string> list = content.Keys.Where((string tag) => isShowingContentByTag.Contains(tag)).ToPooledList();
			list.Sort((string a, string b) => sortValueByTag[a] - sortValueByTag[b]);
			foreach (string item2 in list)
			{
				float num3 = fontSizeByTag[item2];
				foreach (string item3 in content[item2])
				{
					if (!elements[num2].gameObject.activeInHierarchy)
					{
						elements[num2].gameObject.SetActive(value: true);
					}
					elements[num2].SetText(TextFormatting.FormatNewLines(item3, maxCharacters));
					elements[num2].fontSize = baseFontSize * num3;
					num2++;
				}
			}
			ListPool<string>.Return(list);
			elements.SetActiveFromIndex(num2, active: false);
			elementsToShowCount = num;
			if (base.isActiveAndEnabled)
			{
				StartCoroutine(Show(showBackground));
			}
		}

		private void Start()
		{
			baseFontSize = cursorLinePrefab.GetComponent<TextMeshProUGUI>().fontSize;
			MonoSingleton<UIController>.Instance.InfoCursorToggleEvent += OnInfoCursorToggle;
			MonoSingleton<UIController>.Instance.UpdateInfoCursorContentEvent += OnUpdateInfoCursorContent;
			MonoSingleton<UIController>.Instance.UpdateInfoCursorBackground += OnUpdateInfoCursorBackground;
			UpdateElementsList(1);
			infoCursorChild.SetActive(value: false);
		}

		private void OnDestroy()
		{
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.InfoCursorToggleEvent -= OnInfoCursorToggle;
				MonoSingleton<UIController>.Instance.UpdateInfoCursorContentEvent -= OnUpdateInfoCursorContent;
				MonoSingleton<UIController>.Instance.UpdateInfoCursorBackground -= OnUpdateInfoCursorBackground;
			}
		}

		private void LateUpdate()
		{
			if (MonoSingleton<InputManager>.Instance.InputEnabled)
			{
				Vector3 vector = offset;
				if (MonoSingleton<TooltipController>.Instance.IsShowing())
				{
					float num = (float)Math.Round(1f / MonoSingleton<UIScaleController>.Instance.GetUIScale(MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.CurrentUISize) * 100f) / 100f;
					vector = new Vector3(offset.x, infoCursorChild.GetComponent<RectTransform>().sizeDelta.y * num, 0f);
				}
				base.transform.position = Input.mousePosition + vector;
			}
		}
	}
}
