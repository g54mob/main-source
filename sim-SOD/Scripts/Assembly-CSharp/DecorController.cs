using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DecorController : PageBasedContent
{
	[Header("Components")]
	public RectTransform rect;

	public WindowContentController wcc;

	public RectTransform entryParent;

	public ButtonController wallsButton;

	public ButtonController ceilingButton;

	public ButtonController floorButton;

	public GameObject decorElementPrefab;

	[Header("State")]
	public MaterialGroupPreset.MaterialType decorType;

	public bool isSetup;

	public NewRoom room;

	public MaterialKeyController keyController;

	public TMP_InputField searchInputField;

	private List<MaterialGroupPreset> allRequired;

	public List<DecorElementController> spawnedEntries;

	public void Setup(WindowContentController newContentController)
	{
	}

	public void SetDecorType(int newType)
	{
	}

	public void SetPageSize(Vector2 newSize)
	{
	}

	public override void UpdateListDisplay()
	{
	}

	public void ClearSearchButton()
	{
	}

	public void SetSelected(MaterialGroupPreset newSelection)
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

	public override int GetMaxPages()
	{
		return 0;
	}
}
