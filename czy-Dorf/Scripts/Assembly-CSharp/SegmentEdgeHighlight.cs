using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class SegmentEdgeHighlight : MonoBehaviour, IRecyclable
{
	private sealed class _003C_003Ec__DisplayClass27_0
	{
		public int lineRendererIndex;

		public SegmentEdgeHighlight _003C_003E4__this;

		internal Color _003CHighlight_003Eb__0()
		{
			return _003C_003E4__this.lineRenderers[lineRendererIndex].startColor;
		}

		internal void _003CHighlight_003Eb__1(Color x)
		{
			_003C_003E4__this.lineRenderers[lineRendererIndex].startColor = x;
		}

		internal Color _003CHighlight_003Eb__2()
		{
			return _003C_003E4__this.lineRenderers[lineRendererIndex].endColor;
		}

		internal void _003CHighlight_003Eb__3(Color x)
		{
			_003C_003E4__this.lineRenderers[lineRendererIndex].endColor = x;
		}
	}

	private sealed class _003C_003Ec__DisplayClass28_0
	{
		public SegmentEdgeHighlight _003C_003E4__this;

		public Action onCompletedCallback;

		public TweenCallback _003C_003E9__4;

		internal void _003CShow_003Eb__4()
		{
			onCompletedCallback();
		}
	}

	private sealed class _003C_003Ec__DisplayClass28_1
	{
		public int lineRendererIndex;

		public _003C_003Ec__DisplayClass28_0 CS_0024_003C_003E8__locals1;

		internal Color _003CShow_003Eb__0()
		{
			return CS_0024_003C_003E8__locals1._003C_003E4__this.lineRenderers[lineRendererIndex].startColor;
		}

		internal void _003CShow_003Eb__1(Color x)
		{
			CS_0024_003C_003E8__locals1._003C_003E4__this.lineRenderers[lineRendererIndex].startColor = x;
		}

		internal Color _003CShow_003Eb__2()
		{
			return CS_0024_003C_003E8__locals1._003C_003E4__this.lineRenderers[lineRendererIndex].endColor;
		}

		internal void _003CShow_003Eb__3(Color x)
		{
			CS_0024_003C_003E8__locals1._003C_003E4__this.lineRenderers[lineRendererIndex].endColor = x;
		}
	}

	[SerializeField]
	private RecyclableType recyclableType = RecyclableType.SegmentEdgeHighlight;

	[SerializeField]
	private float fadeDuration = 0.5f;

	[SerializeField]
	private float highlightDuration = 0.1f;

	[SerializeField]
	private LineRenderer[] lineRenderers;

	[SerializeField]
	private QuestUiComponentLibrary questIconLibrary;

	private bool _003CShown_003Ek__BackingField;

	private bool _003CHighlighted_003Ek__BackingField;

	private TextMeshPro groupTypeLabel;

	private SpriteRenderer arrowSprite;

	private Tile tile;

	private int localEdgeIndex;

	private GroupType groupType;

	private QuestElementIcon elementIcon;

	private List<Color> startColors;

	private List<Color> endColors;

	private Sequence fadeSequence;

	public bool Shown
	{
		get
		{
			return _003CShown_003Ek__BackingField;
		}
		private set
		{
			_003CShown_003Ek__BackingField = value;
		}
	}

	public bool Highlighted
	{
		get
		{
			return _003CHighlighted_003Ek__BackingField;
		}
		private set
		{
			_003CHighlighted_003Ek__BackingField = value;
		}
	}

	public RecyclableType RecyclableId
	{
		get
		{
			return recyclableType;
		}
		set
		{
			recyclableType = value;
		}
	}

	public GameObject GameObject => base.gameObject;

	public void Setup(Tile tile, int localTileEdgeIndex, GroupType groupType, bool startHighlighted = true)
	{
		this.tile = tile;
		localEdgeIndex = localTileEdgeIndex;
		this.groupType = groupType;
		if (startHighlighted)
		{
			tile.OnNeighborTileAdded += HighlightFromNeighborAdded;
			tile.OnNeighborTilePlaced += UpdateLineVisibilityFromNeighborPlaced;
			tile.OnPlaced += UpdateLineVisibilityForPlacedTile;
		}
		base.transform.parent = tile.TileVisual.transform;
		base.transform.localPosition = Vector3.zero;
		base.transform.localRotation = Quaternion.AngleAxis(60 * localTileEdgeIndex, Vector3.up);
		int layer = tile.gameObject.layer;
		base.gameObject.layer = layer;
		startColors = new List<Color>();
		endColors = new List<Color>();
		LineRenderer[] array = lineRenderers;
		foreach (LineRenderer obj in array)
		{
			startColors.Add(new Color(groupType.color.r, groupType.color.g, groupType.color.b, 1f));
			endColors.Add(new Color(groupType.color.r, groupType.color.g, groupType.color.b, 0f));
			obj.startColor = Enumerable.Last(startColors);
			obj.endColor = Enumerable.Last(endColors);
			obj.gameObject.layer = layer;
		}
		Show(newShow: false, animate: false);
		if (startHighlighted)
		{
			Show(newShow: true);
			int num = GridCalculator.RotatedDirection(localEdgeIndex, tile.RotationIndex);
			Tile neighbor = tile.GetNeighbor(num, Space.World);
			HighlightFromNeighborAdded(num, neighbor);
		}
	}

	private void HighlightFromNeighborAdded(int worldNeighborEdge, Tile newNeighborTile)
	{
		if (GridCalculator.RotatedDirection(localEdgeIndex, tile.RotationIndex) == worldNeighborEdge)
		{
			if (newNeighborTile == null)
			{
				Highlight(newHighlight: false);
				return;
			}
			ElementGroup elementGroup = newNeighborTile.GetElementGroup((worldNeighborEdge + 3) % 6, Space.World);
			Highlight(elementGroup != null && elementGroup.GroupType == groupType);
		}
	}

	private void UpdateLineVisibilityFromNeighborPlaced(int worldNeighborEdge, Tile newNeighborTile)
	{
		if (GridCalculator.RotatedDirection(localEdgeIndex, tile.RotationIndex) == worldNeighborEdge)
		{
			Show(newNeighborTile == null);
		}
	}

	private void UpdateLineVisibilityForPlacedTile(Tile placedTile)
	{
		int directionIndex = GridCalculator.RotatedDirection(localEdgeIndex, tile.RotationIndex);
		Tile neighbor = placedTile.GetNeighbor(directionIndex, Space.World);
		Show(neighbor == null);
	}

	private void Highlight(bool newHighlight)
	{
		Sequence sequence = fadeSequence;
		if (sequence != null)
		{
			TweenExtensions.Kill(sequence);
		}
		fadeSequence = DOTween.Sequence();
		for (int i = 0; i < lineRenderers.Length; i++)
		{
			_003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass27_0();
			CS_0024_003C_003E8__locals10._003C_003E4__this = this;
			Color endValue = (newHighlight ? Color.Lerp(startColors[i], Color.white, 0.5f) : startColors[i]);
			endValue.a = startColors[i].a;
			Color endValue2 = (newHighlight ? Color.Lerp(startColors[i], Color.white, 0.5f) : endColors[i]);
			endValue2.a = endColors[i].a;
			CS_0024_003C_003E8__locals10.lineRendererIndex = i;
			TweenSettingsExtensions.Insert(fadeSequence, 0f, DOTween.To(() => CS_0024_003C_003E8__locals10._003C_003E4__this.lineRenderers[CS_0024_003C_003E8__locals10.lineRendererIndex].startColor, delegate(Color x)
			{
				CS_0024_003C_003E8__locals10._003C_003E4__this.lineRenderers[CS_0024_003C_003E8__locals10.lineRendererIndex].startColor = x;
			}, endValue, highlightDuration));
			TweenSettingsExtensions.Insert(fadeSequence, 0f, DOTween.To(() => CS_0024_003C_003E8__locals10._003C_003E4__this.lineRenderers[CS_0024_003C_003E8__locals10.lineRendererIndex].endColor, delegate(Color x)
			{
				CS_0024_003C_003E8__locals10._003C_003E4__this.lineRenderers[CS_0024_003C_003E8__locals10.lineRendererIndex].endColor = x;
			}, endValue2, highlightDuration));
		}
		Highlighted = newHighlight;
	}

	public void Show(bool newShow, bool animate = true, Action onCompletedCallback = null)
	{
		_003C_003Ec__DisplayClass28_0 _003C_003Ec__DisplayClass28_2 = new _003C_003Ec__DisplayClass28_0();
		_003C_003Ec__DisplayClass28_2._003C_003E4__this = this;
		_003C_003Ec__DisplayClass28_2.onCompletedCallback = onCompletedCallback;
		Sequence sequence = fadeSequence;
		if (sequence != null)
		{
			TweenExtensions.Kill(sequence);
		}
		fadeSequence = DOTween.Sequence();
		for (int i = 0; i < lineRenderers.Length; i++)
		{
			_003C_003Ec__DisplayClass28_1 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass28_1();
			CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass28_2;
			Color color = new Color(startColors[i].r, startColors[i].g, startColors[i].b, newShow ? startColors[i].a : 0f);
			Color color2 = new Color(endColors[i].r, endColors[i].g, endColors[i].b, newShow ? endColors[i].a : 0f);
			CS_0024_003C_003E8__locals13.lineRendererIndex = i;
			if (animate)
			{
				TweenSettingsExtensions.Insert(fadeSequence, 0f, DOTween.To(() => CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1._003C_003E4__this.lineRenderers[CS_0024_003C_003E8__locals13.lineRendererIndex].startColor, delegate(Color x)
				{
					CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1._003C_003E4__this.lineRenderers[CS_0024_003C_003E8__locals13.lineRendererIndex].startColor = x;
				}, color, fadeDuration));
				TweenSettingsExtensions.Insert(fadeSequence, 0f, DOTween.To(() => CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1._003C_003E4__this.lineRenderers[CS_0024_003C_003E8__locals13.lineRendererIndex].endColor, delegate(Color x)
				{
					CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1._003C_003E4__this.lineRenderers[CS_0024_003C_003E8__locals13.lineRendererIndex].endColor = x;
				}, color2, fadeDuration));
				if (CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1.onCompletedCallback != null)
				{
					Sequence sequence2 = fadeSequence;
					sequence2.onComplete = (TweenCallback)Delegate.Combine(sequence2.onComplete, (TweenCallback)delegate
					{
						CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1.onCompletedCallback();
					});
				}
			}
			else
			{
				lineRenderers[i].startColor = color;
				lineRenderers[i].endColor = color2;
				CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1.onCompletedCallback?.Invoke();
			}
		}
		Shown = newShow;
	}

	public void Disappear()
	{
		Show(newShow: false, animate: true, delegate
		{
			MasterObjectPool.Instance.StoreObject(this);
		});
		tile.OnNeighborTilePlaced -= UpdateLineVisibilityFromNeighborPlaced;
		tile.OnPlaced -= UpdateLineVisibilityForPlacedTile;
	}

	private void _003CDisappear_003Eb__29_0()
	{
		MasterObjectPool.Instance.StoreObject(this);
	}
}
