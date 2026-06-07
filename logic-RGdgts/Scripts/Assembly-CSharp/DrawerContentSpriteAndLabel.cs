using System;
using UnityEngine;
using UnityEngine.Localization.Tables;

public class DrawerContentSpriteAndLabel : DrawerContent
{
	private struct Content
	{
		public string text;

		public (TableReference, TableEntryReference)? localizedText;
	}

	public SpriteRenderer spriteRenderer;

	public TextLabel textLabel;

	public Interactable interactable;

	private Vector2 size;

	private Vector2 pivot;

	private Content content;

	private bool contentPending;

	public override void Init(float position, int sortingLayerID, int sortingOrder, DraggablePanel.Direction direction)
	{
	}

	public override float GetSize(DraggablePanel.Direction direction)
	{
		return 0f;
	}

	public override float GetMin(DraggablePanel.Direction direction)
	{
		return 0f;
	}

	public override float GetMax(DraggablePanel.Direction direction)
	{
		return 0f;
	}

	public void SetText(string text)
	{
	}

	public void SetLocalizedText(TableReference tableRef, TableEntryReference entryRef)
	{
	}

	private void OnEnable()
	{
	}

	public void SetOnInteraction(Action onInteraction)
	{
	}
}
