using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhoneNumbersController : MonoBehaviour
{
	public RectTransform rect;

	public WindowContentController wcc;

	public bool isSetup;

	public bool isMini;

	public TextMeshProUGUI contentsText;

	public RectTransform entryParent;

	public TMP_InputField searchInputField;

	public List<PhoneNumberEntryController> spawnedEntries;

	public void Setup(WindowContentController newContentController)
	{
	}

	public void SetPageSize(Vector2 newSize)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	public void UpdateListDisplay()
	{
	}

	public void ClearSearchButton()
	{
	}
}
