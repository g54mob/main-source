using TMPro;
using UnityEngine;

public class MultitoolConsoleLine : MonoBehaviour
{
	public TextMeshProUGUI textRenderer;

	public TextMeshProUGUI backgroundRenderer;

	private RectTransform rectTransform;

	private Color[] _foregroundColors;

	private Color[] _backgroundColors;

	private static Color defaultColor;

	public Color[] foregroundColors
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Color[] backgroundColors
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public string text
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public void Init()
	{
	}

	private void InitColors()
	{
	}

	private void Refresh()
	{
	}

	private void RefreshHeight()
	{
	}

	private void OnRefreshForegroundTMPRo(TMP_TextInfo info)
	{
	}

	private void OnRefreshBackgroundTMPRo(TMP_TextInfo info)
	{
	}
}
