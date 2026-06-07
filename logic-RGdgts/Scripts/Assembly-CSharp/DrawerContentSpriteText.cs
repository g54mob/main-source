using UnityEngine;
using UnityEngine.Localization.Tables;

public class DrawerContentSpriteText : DrawerContent, ITextContent
{
	public SpriteText spriteText;

	private Vector2 size;

	private Vector2 pivot;

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
}
