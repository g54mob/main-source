using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Cursor Properties/Single Construction")]
public class SingleConstructionCursorProperties : ConstructionCursorProperties
{
	[NonSerialized]
	private ConstructionPreview _constructionPreview;

	public override void Activate()
	{
		base.Activate();
		_constructionPreview = CreateConstructionVisual(_buildable, _visualIndex, isHooked: false, createMarkerProxy: true);
	}

	public override void UpdateCursor(CursorManager cursorManager)
	{
		base.UpdateCursor(cursorManager);
		UpdatePreviewPlacingConstruction(_constructionPreview, out var _, out var canBePlaced);
		if (canBePlaced)
		{
			TryPlacingConstruction(cursorManager, _constructionPreview);
		}
	}

	public override void DeactivateImmediately()
	{
		base.DeactivateImmediately();
		RemoveConstructionPreview(ref _constructionPreview);
	}
}
