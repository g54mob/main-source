using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TutorialEvent_HighlightInvalidTileSlots : TutorialEvent
{
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public InvalidTileSlotPreview invalidTileSlotPreview;

		internal void _003CFinish_003Eb__0()
		{
			Object.Destroy(invalidTileSlotPreview.gameObject);
		}
	}

	[SerializeField]
	private TileSlotPreviewer tileSlotPreviewer;

	[SerializeField]
	private TileStack tileStack;

	[SerializeField]
	private InvalidTileSlotPreview invalidTileSlotPreviewPrefab;

	[SerializeField]
	private bool disableOnFinish = true;

	private bool _003CActive_003Ek__BackingField;

	private bool initialScaleAnimationShown;

	private List<InvalidTileSlotPreview> visibleInvalidPreviews = new List<InvalidTileSlotPreview>();

	public bool Active
	{
		get
		{
			return _003CActive_003Ek__BackingField;
		}
		private set
		{
			_003CActive_003Ek__BackingField = value;
		}
	}

	public override void Begin()
	{
		if (!tileStack)
		{
			tileStack = Object.FindObjectOfType<TileStack>(includeInactive: true);
		}
		UpdatePreview();
		tileStack.OnAdvanced += UpdatePreview;
		Active = true;
	}

	private void UpdatePreview()
	{
		foreach (InvalidTileSlotPreview visibleInvalidPreview in visibleInvalidPreviews)
		{
			Object.Destroy(visibleInvalidPreview.gameObject);
		}
		visibleInvalidPreviews = new List<InvalidTileSlotPreview>();
		foreach (TileSlot invalidTileSlot in tileSlotPreviewer.InvalidTileSlots)
		{
			CreateInvalidPreview(invalidTileSlot);
		}
		if (initialScaleAnimationShown)
		{
			return;
		}
		foreach (InvalidTileSlotPreview visibleInvalidPreview2 in visibleInvalidPreviews)
		{
			TweenSettingsExtensions.From(ShortcutExtensions.DOScale(visibleInvalidPreview2.transform, 1f, 0.3f), 0f);
		}
		initialScaleAnimationShown = true;
	}

	private void CreateInvalidPreview(TileSlot invalidTileSlot)
	{
		InvalidTileSlotPreview item = Object.Instantiate(invalidTileSlotPreviewPrefab, invalidTileSlot.transform.position, Quaternion.identity, tileSlotPreviewer.transform);
		visibleInvalidPreviews.Add(item);
	}

	public override void Finish()
	{
		if (!disableOnFinish)
		{
			return;
		}
		tileStack.OnAdvanced -= UpdatePreview;
		using (List<InvalidTileSlotPreview>.Enumerator enumerator = visibleInvalidPreviews.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass13_0();
				CS_0024_003C_003E8__locals3.invalidTileSlotPreview = enumerator.Current;
				TweenSettingsExtensions.OnComplete(ShortcutExtensions.DOScale(CS_0024_003C_003E8__locals3.invalidTileSlotPreview.transform, 0f, 0.5f), delegate
				{
					Object.Destroy(CS_0024_003C_003E8__locals3.invalidTileSlotPreview.gameObject);
				});
			}
		}
		visibleInvalidPreviews = new List<InvalidTileSlotPreview>();
		Active = false;
	}

	public override void Skip()
	{
		Begin();
		Finish();
	}
}
