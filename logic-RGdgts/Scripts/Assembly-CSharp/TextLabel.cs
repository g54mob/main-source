using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;

[ExecuteInEditMode]
public class TextLabel : MonoBehaviour
{
	public TextMeshPro textRenderer;

	public SpriteRenderer sprite;

	public float textYoffset;

	public float leftBorder;

	public float rightBorder;

	[SortingLayer]
	public int sortingLayer;

	public int sortingOrder;

	public SpriteMaskInteraction maskInteraction;

	private string text;

	public LocalizedString localizedString;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private float SnapPixelFloor(float value)
	{
		return 0f;
	}

	private float SnapPixelCeil(float value)
	{
		return 0f;
	}

	private void Start()
	{
	}

	public Vector2 GetSize()
	{
		return default(Vector2);
	}

	public void RefreshRenderSettings()
	{
	}

	public void Refresh()
	{
	}

	public void SetText(string text)
	{
	}

	public void SetLocalizedText(TableReference tableRef, TableEntryReference entryRef)
	{
	}
}
