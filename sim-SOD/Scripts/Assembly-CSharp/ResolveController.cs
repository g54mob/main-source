using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResolveController : MonoBehaviour
{
	[Header("Components")]
	public RectTransform rect;

	public RectTransform pageRect;

	public WindowContentController wcc;

	public TextMeshProUGUI titleText;

	public TextMeshProUGUI descriptionText;

	public GameObject inputFieldPrefab;

	public TextMeshProUGUI invalidText;

	public RectTransform lineBreak1;

	public ButtonController submitButton;

	public ButtonController changeLeadButton;

	public ButtonController closeCaseButton;

	public RectTransform lineBreak2;

	public LayoutGroup layout;

	[Header("State")]
	public bool isSetup;

	public bool isValid;

	public List<InputFieldController> spawnedInputFields;

	private static ResolveController _instance;

	public static ResolveController Instance => null;

	public void Setup(WindowContentController newContentController)
	{
	}

	public void UpdateResolveFields()
	{
	}

	public void ValidationUpdate()
	{
	}

	public void SetPageSize(Vector2 newSize)
	{
	}

	private void OnDestroy()
	{
	}

	public void SubmitButton()
	{
	}

	public void ChangeLeadButton()
	{
	}

	public void CloseCaseButton()
	{
	}

	public void CancelCloseCase()
	{
	}

	public void ConfirmCloseCurrentCase()
	{
	}
}
