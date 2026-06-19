using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TH20.UI
{
	[AddComponentMenu("UI/Column Sort Button", 102)]
	public class ColumnSortButton : Selectable, IPointerDownHandler, IEventSystemHandler
	{
		public enum SortMode
		{
			None = 0,
			Ascending = 1,
			Descending = 2
		}

		[SerializeField]
		private Table _table;

		[SerializeField]
		private SortMode _sortMode;

		[SerializeField]
		private Color _sortButtonActiveTint = Color.white;

		[SerializeField]
		private Color _sortButtonDisabledTint = new Color(1f, 1f, 1f, 0.5f);

		[SerializeField]
		private Graphic _ascendingGraphic;

		[SerializeField]
		private Graphic _descendingGraphic;

		[SerializeField]
		private float _fadeDuration = 0.1f;

		public Action<SortMode> OnChangeSortMode;

		public SortMode CurrentSortMode
		{
			get
			{
				return _sortMode;
			}
			set
			{
				_sortMode = value;
				RefreshGraphics();
				if (_table != null)
				{
					_table.NotifySortModeChange(this);
				}
				if (OnChangeSortMode != null)
				{
					OnChangeSortMode(_sortMode);
				}
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			RefreshGraphics();
		}

		public void SetSortModeWithoutNotifyingTable(SortMode sortMode)
		{
			_sortMode = sortMode;
			RefreshGraphics();
			if (OnChangeSortMode != null)
			{
				OnChangeSortMode(_sortMode);
			}
		}

		public new void OnPointerDown(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				Press();
			}
		}

		private void RefreshGraphics()
		{
			if (_ascendingGraphic != null)
			{
				if (_sortMode == SortMode.Ascending)
				{
					_ascendingGraphic.CrossFadeColor(_sortButtonActiveTint, _fadeDuration, ignoreTimeScale: true, useAlpha: true, useRGB: true);
				}
				else
				{
					_ascendingGraphic.CrossFadeColor(_sortButtonDisabledTint, _fadeDuration, ignoreTimeScale: true, useAlpha: true, useRGB: true);
				}
			}
			if (_descendingGraphic != null)
			{
				if (_sortMode == SortMode.Descending)
				{
					_descendingGraphic.CrossFadeColor(_sortButtonActiveTint, _fadeDuration, ignoreTimeScale: true, useAlpha: true, useRGB: true);
				}
				else
				{
					_descendingGraphic.CrossFadeColor(_sortButtonDisabledTint, _fadeDuration, ignoreTimeScale: true, useAlpha: true, useRGB: true);
				}
			}
		}

		private void Press()
		{
			if (IsActive() && IsInteractable())
			{
				_sortMode = (SortMode)((int)(_sortMode + 1) % 3);
				RefreshGraphics();
				if (_table != null)
				{
					_table.NotifySortModeChange(this);
				}
				if (OnChangeSortMode != null)
				{
					OnChangeSortMode(_sortMode);
				}
			}
		}

		public virtual void OnSubmit(BaseEventData eventData)
		{
			Press();
			if (IsActive() && IsInteractable())
			{
				DoStateTransition(SelectionState.Pressed, instant: false);
			}
		}
	}
}
