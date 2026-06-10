using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultsController : MonoBehaviour
{
	[Header("Components")]
	public RectTransform rect;

	public RectTransform pageRect;

	public WindowContentController wcc;

	public TextMeshProUGUI titleText;

	public TextMeshProUGUI descriptionText;

	public TextMeshProUGUI successText;

	public GameObject inputFieldPrefab;

	public ButtonController closeCaseButton;

	public LayoutGroup layout;

	public ProgressBarController questionsBar;

	public ProgressBarController victimsBar;

	public Image rankImage;

	public TextMeshProUGUI rankText;

	[Header("State")]
	public bool isSetup;

	public List<InputFieldController> spawnedInputFields;

	private static ResultsController _instance;

	public static ResultsController Instance => null;

	public void Setup(WindowContentController newContentController)
	{
	}

	public void UpdateResolveFields()
	{
	}

	public void SetPageSize(Vector2 newSize)
	{
	}

	public void CloseCaseButton()
	{
	}
}
