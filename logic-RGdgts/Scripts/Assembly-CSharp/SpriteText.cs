using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;

[ExecuteInEditMode]
public class SpriteText : MonoBehaviour
{
	public enum HorizontalAlignment
	{
		Left = 0,
		Center = 1,
		Right = 2
	}

	public LocalizedString localizedString;

	private string text;

	public SpriteFont spriteFont;

	public HorizontalAlignment horizontalAlignment;

	public bool updateCollider;

	[SortingLayer]
	public int sortingLayer;

	public int sortingOrder;

	public SpriteMaskInteraction maskInteraction;

	private SpriteRenderer spriteRenderer;

	private BoxCollider2D textCollider;

	private Sprite sprite;

	private Texture2D texture;

	private static Material blitMaterial;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
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
