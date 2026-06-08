using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UIUtils
{
	public static readonly int PANEL_SPAWN_LAYER = 3;

	private static Color SELECTED_COLOR = new Color32(173, 0, 207, byte.MaxValue);

	private static readonly TextInfo english = new CultureInfo("en-US").TextInfo;

	public static Canvas FindCanvasFromChild(Transform child)
	{
		Transform transform = child;
		while (transform.GetComponent<Canvas>() == null)
		{
			transform = transform.parent;
		}
		return transform.GetComponent<Canvas>();
	}

	public static Transform FindPanelTransformFromChild(Transform child)
	{
		Transform transform = child;
		while (transform.GetComponent<Panel>() == null)
		{
			transform = transform.parent;
		}
		return transform.transform;
	}

	public static void LogCollection<T>(string prefix, ICollection<T> collection)
	{
		Debug.Log(prefix + " " + string.Join(",", collection));
	}

	public static string ToTitleCase(string title)
	{
		return english.ToTitleCase(title);
	}

	public static bool IgnoreCaseEquals(string x, string y)
	{
		return x.Trim().Equals(y.Trim(), StringComparison.OrdinalIgnoreCase);
	}

	public static void SetPenultimateLayer(GameObject panel)
	{
		SetPenultimateLayer(panel.GetComponent<Transform>());
	}

	public static void SetPenultimateLayer(Transform panel)
	{
		SetLayer(panel, PANEL_SPAWN_LAYER);
	}

	public static void SetLayer(Transform panel, int layerLevel)
	{
		int siblingIndex = panel.parent.childCount - layerLevel;
		panel.SetSiblingIndex(siblingIndex);
	}

	public static char RemoveDiacritics(char character)
	{
		string text = (character.ToString() ?? "").Normalize(NormalizationForm.FormD);
		StringBuilder stringBuilder = new StringBuilder(text.Length);
		foreach (char c in text)
		{
			if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString().Normalize(NormalizationForm.FormC)[0];
	}

	public static GameObject LaunchTextPopup(GameObject popupPrefab, Canvas canvas, string toolbarText, string inputText)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(popupPrefab, canvas.transform.position, Quaternion.identity, canvas.transform);
		SetPenultimateLayer(gameObject);
		Transcript component = gameObject.GetComponent<Transcript>();
		component.SetTranscript(inputText);
		component.SetToolbarName(toolbarText);
		component.Resize();
		return gameObject;
	}

	public static float GetScreenFixedRatio()
	{
		return Mathf.Max(1920f / (float)Screen.width, 1080f / (float)Screen.height);
	}

	public static GameObject LaunchTextPopup(GameObject popupPrefab, Canvas canvas, string toolbarText, string inputText, NotificationHandler.Icon icon)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(popupPrefab, canvas.transform.position, Quaternion.identity, canvas.transform);
		SetPenultimateLayer(gameObject);
		Transcript component = gameObject.GetComponent<Transcript>();
		component.SetTranscript(inputText);
		component.SetToolbarName(toolbarText);
		component.SetIcon(icon);
		component.Resize();
		return gameObject;
	}

	public static void SetTextPopup(GameObject popup, string newText)
	{
		Transcript component = popup.GetComponent<Transcript>();
		component.SetTranscript(newText);
		component.Resize();
	}

	public static void SetTitlePopup(GameObject popup, string newTitle)
	{
		popup.GetComponent<Transcript>().SetToolbarName(newTitle);
	}

	public static void SetButtonColorSelected(Button button)
	{
		ColorBlock colors = button.colors;
		colors.normalColor = SELECTED_COLOR;
		colors.highlightedColor = SELECTED_COLOR;
		button.colors = colors;
	}

	public static void CloseAllPanels(Canvas canvas)
	{
		foreach (Transform item in canvas.transform)
		{
			Panel component = item.GetComponent<Panel>();
			if (component != null && item.gameObject.activeSelf)
			{
				component.ClosePanel();
			}
		}
	}

	public static float GetCurrentAnimationLength(Animator animator)
	{
		return animator.GetCurrentAnimatorStateInfo(0).length;
	}

	public static string GeneratePeriods(float currentTime, float interval)
	{
		currentTime = currentTime * 100f % interval;
		if (currentTime < interval / 3f)
		{
			return ".";
		}
		if (currentTime < interval * 2f / 3f)
		{
			return "..";
		}
		return "...";
	}
}
