using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HelpController : MonoBehaviour
{
	public RectTransform rect;

	public WindowContentController wcc;

	public bool isSetup;

	[Header("Contents")]
	public RectTransform helpContents;

	public TMP_InputField searchInputField;

	public RectTransform helpContentButtonParent;

	public TextMeshProUGUI contentsText;

	public List<InterfaceVideoController> videos;

	[Header("Page")]
	public GameObject page;

	public TextMeshProUGUI helpTitle;

	public TextMeshProUGUI helpContent;

	public ButtonController backButtonTop;

	public ButtonController backButtonBottom;

	public VerticalLayoutGroup layoutGroup;

	[Header("Content")]
	public List<ButtonController> helpContentButtons;

	public GameObject helpContentButtonPrefab;

	private static HelpController _instance;

	public static HelpController Instance => null;

	public void Setup(WindowContentController newContentController)
	{
	}

	public void SetPageSize(Vector2 newSize)
	{
	}

	public void DisplayHelpContents()
	{
	}

	public void UpdateHelpButtonList()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnDisable()
	{
	}

	private void OnEnable()
	{
	}

	public void ClearSearchButton()
	{
	}

	public void DisplayHelpPage(ButtonController button)
	{
	}

	public void DisplayHelpPage(string pageName)
	{
	}

	public void LoadHelpPage(string h)
	{
	}
}
