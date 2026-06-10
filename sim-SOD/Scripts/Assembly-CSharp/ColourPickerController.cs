using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ColourPickerController : MonoBehaviour
{
	public delegate void NewColour(Color newColour);

	[Header("Components")]
	public RectTransform rect;

	public WindowContentController wcc;

	public RectTransform entryParent;

	public RectTransform spawnParent;

	public GameObject swatchPrefab;

	[Header("State")]
	public bool isSetup;

	public Color selectedColor;

	public List<SwatchController> spawnedEntries;

	public event NewColour OnNewColour
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void Setup(WindowContentController newContentController)
	{
	}

	public void SetPageSize(Vector2 newSize)
	{
	}

	public void UpdateListDisplay()
	{
	}

	public void OnPickNewColour(SwatchController swatch)
	{
	}
}
