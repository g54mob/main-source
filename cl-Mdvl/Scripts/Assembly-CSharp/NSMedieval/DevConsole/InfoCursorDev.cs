using System.Collections;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.DevConsole
{
	public class InfoCursorDev : MonoBehaviour
	{
		private List<TextMeshProUGUI> elements = new List<TextMeshProUGUI>();

		private int elementsToShowCount;

		private float baseFontSize;

		[SerializeField]
		private GameObject cursorLinePrefab;

		[SerializeField]
		private Image backgroundImage;

		[SerializeField]
		private GameObject infoCursorChild;

		[SerializeField]
		private Vector3 offset;

		private void Hide()
		{
			infoCursorChild.SetActive(value: false);
		}

		private void UpdateElementsList(int elementsCount)
		{
			if (elements.Count < elementsCount)
			{
				int num = elementsCount - elements.Count;
				for (int i = 0; i < num; i++)
				{
					elements.Add(Object.Instantiate(cursorLinePrefab, infoCursorChild.transform).GetComponent<TextMeshProUGUI>());
				}
			}
		}

		private void ShowInNextFrame(bool background)
		{
			backgroundImage.enabled = false;
			foreach (TextMeshProUGUI element in elements)
			{
				element.gameObject.SetActive(value: false);
			}
			infoCursorChild.SetActive(value: true);
			StartCoroutine(Show(background));
		}

		private IEnumerator Show(bool background)
		{
			for (int i = 0; i < elementsToShowCount; i++)
			{
				elements[i].gameObject.SetActive(value: true);
			}
			yield return null;
			backgroundImage.enabled = background;
		}

		private void OnInfoCursorToggle(bool active)
		{
			if (active)
			{
				ShowInNextFrame(background: true);
			}
			else
			{
				Hide();
			}
		}

		private void OnUpdateInfoCursorContent(List<string> textLines, string tag, int tagSortValue, bool background, float fontSizeScaler)
		{
			backgroundImage.enabled = background;
			UpdateElementsList(textLines.Count);
			for (int i = 0; i < textLines.Count; i++)
			{
				elements[i].SetText(textLines[i]);
				elements[i].fontSize = baseFontSize * fontSizeScaler;
			}
			elementsToShowCount = textLines.Count;
			ShowInNextFrame(background);
		}

		private void Start()
		{
			baseFontSize = cursorLinePrefab.GetComponent<TextMeshProUGUI>().fontSize;
			MonoSingleton<DeveloperConsoleController>.Instance.InfoCursorDevToggleEvent += OnInfoCursorToggle;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContentDevEvent += OnUpdateInfoCursorContent;
			infoCursorChild.SetActive(value: false);
		}

		private void OnDestroy()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.InfoCursorDevToggleEvent -= OnInfoCursorToggle;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContentDevEvent -= OnUpdateInfoCursorContent;
		}

		private void LateUpdate()
		{
			if (MonoSingleton<InputManager>.Instance.InputEnabled)
			{
				base.transform.position = Input.mousePosition + offset;
			}
		}
	}
}
