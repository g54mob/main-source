using TMPro;
using UnityEngine;

public class ResolveOptionsController : MonoBehaviour
{
	[Header("Components")]
	public RectTransform rect;

	public RectTransform pageRect;

	public WindowContentController wcc;

	public TextMeshProUGUI titleText;

	public ButtonController submitButton;

	public ButtonController openJobPostButton;

	public void Setup(WindowContentController newContentController)
	{
	}

	private void OnEnable()
	{
	}

	public void HelpButton()
	{
	}

	public void OpenJobPostButton()
	{
	}

	public void SubmitCaseButton()
	{
	}

	public void CloseCaseButton()
	{
	}

	public void SetPageSize(Vector2 newSize)
	{
	}
}
