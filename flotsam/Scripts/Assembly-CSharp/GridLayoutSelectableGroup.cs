using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class GridLayoutSelectableGroup : SelectableGroup
{
	private GridLayoutGroup _grid;

	private List<Selectable> _activeSelectables = new List<Selectable>();

	private RectTransform _rectTransform;

	private EventTrigger _selectedEventTrigger;

	private Rect _navigationRect;

	protected override void OnEnable()
	{
		UpdateActiveSelectables();
		base.OnEnable();
		GameEventDispatcher.AddListener(GameEventType.BuildableBuilt, UpdateActiveSelectables);
	}

	private void Update()
	{
		if ((bool)_selectedEventTrigger && FlotsamInputManager.GetUISubmit())
		{
			_selectedEventTrigger.OnSubmit(null);
		}
		if (IsInInputModuleNavigationMode() && (_navigationRect.width != _rectTransform.rect.width || _navigationRect.height != _rectTransform.rect.height))
		{
			UpdateNavigation();
		}
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		GameEventDispatcher.RemoveListener(GameEventType.BuildableBuilt, UpdateActiveSelectables);
	}

	public override void Initialize(bool clearSelected = false)
	{
		base.Initialize(clearSelected);
		if (_grid == null)
		{
			_grid = GetComponent<GridLayoutGroup>();
		}
		UpdateActiveSelectables();
		_rectTransform = base.transform as RectTransform;
	}

	protected override void UpdateNavigation()
	{
		if (IsInInputModuleNavigationMode())
		{
			_navigationRect = _rectTransform.rect;
			{
				foreach (Selectable activeSelectable in _activeSelectables)
				{
					if (ReturnSelectedIndex(activeSelectable, out var column, out var row))
					{
						Navigation navigation = activeSelectable.navigation;
						navigation.mode = Navigation.Mode.Explicit;
						navigation.selectOnUp = ReturnSelectable(column, row - 1);
						navigation.selectOnRight = ReturnSelectable(column + 1, row);
						navigation.selectOnDown = ReturnSelectable(column, row + 1);
						navigation.selectOnLeft = ReturnSelectable(column - 1, row);
						activeSelectable.navigation = navigation;
					}
				}
				return;
			}
		}
		base.UpdateNavigation();
	}

	protected override Selectable FindSelectableOnUp()
	{
		if (ReturnSelectedIndex(_selected, out var column, out var row))
		{
			return ReturnSelectable(column, row - 1);
		}
		return null;
	}

	protected override Selectable FindSelectableOnRight()
	{
		if (ReturnSelectedIndex(_selected, out var column, out var row))
		{
			return ReturnSelectable(column + 1, row);
		}
		return null;
	}

	protected override Selectable FindSelectableOnDown()
	{
		if (ReturnSelectedIndex(_selected, out var column, out var row))
		{
			return ReturnSelectable(column, row + 1);
		}
		return null;
	}

	protected override Selectable FindSelectableOnLeft()
	{
		if (ReturnSelectedIndex(_selected, out var column, out var row))
		{
			return ReturnSelectable(column - 1, row);
		}
		return null;
	}

	private void UpdateActiveSelectables(GameEvent gameEvent = null)
	{
		_activeSelectables.Clear();
		if (_selectables.IsNullOrEmpty())
		{
			return;
		}
		foreach (Selectable selectable in _selectables)
		{
			if (selectable.gameObject.activeInHierarchy)
			{
				_activeSelectables.Add(selectable);
			}
		}
	}

	private void ReturnColumnAndRowCount(out int columnCount, out int rowCount)
	{
		int count = _activeSelectables.Count;
		if (count == 0)
		{
			columnCount = (rowCount = 0);
			return;
		}
		switch (_grid.constraint)
		{
		case GridLayoutGroup.Constraint.FixedColumnCount:
			rowCount = count / _grid.constraintCount;
			if (0 < count % _grid.constraintCount)
			{
				rowCount++;
			}
			if (_grid.startAxis == GridLayoutGroup.Axis.Horizontal)
			{
				columnCount = Mathf.Min(count, _grid.constraintCount);
				break;
			}
			columnCount = count / rowCount;
			if (0 < count % rowCount)
			{
				columnCount++;
			}
			break;
		case GridLayoutGroup.Constraint.FixedRowCount:
			columnCount = count / _grid.constraintCount;
			if (0 < count % _grid.constraintCount)
			{
				columnCount++;
			}
			if (_grid.startAxis == GridLayoutGroup.Axis.Vertical)
			{
				rowCount = Mathf.Min(count, _grid.constraintCount);
				break;
			}
			rowCount = count / columnCount;
			if (0 < count % columnCount)
			{
				rowCount++;
			}
			break;
		case GridLayoutGroup.Constraint.Flexible:
			if (_grid.startAxis == GridLayoutGroup.Axis.Horizontal)
			{
				int b = Mathf.FloorToInt((_rectTransform.rect.width + _grid.spacing.x) / (_grid.cellSize.x + _grid.spacing.x));
				columnCount = Mathf.Min(count, b);
				rowCount = count / columnCount;
				if (0 < count % columnCount)
				{
					rowCount++;
				}
			}
			else
			{
				int b = Mathf.FloorToInt((_rectTransform.rect.height + _grid.spacing.y) / (_grid.cellSize.y + _grid.spacing.y));
				rowCount = Mathf.Min(count, b);
				columnCount = count / rowCount;
				if (0 < count % rowCount)
				{
					columnCount++;
				}
			}
			break;
		default:
			throw new NotImplementedException();
		}
	}

	private bool ReturnSelectedIndex(Selectable selectable, out int column, out int row)
	{
		if (selectable == null)
		{
			column = (row = -1);
			return false;
		}
		int num = _activeSelectables.IndexOf(selectable);
		ReturnColumnAndRowCount(out var columnCount, out var rowCount);
		if (_grid.startAxis == GridLayoutGroup.Axis.Horizontal)
		{
			row = num / columnCount;
			column = num % columnCount;
		}
		else
		{
			row = num % rowCount;
			column = num / rowCount;
		}
		return true;
	}

	public Selectable ReturnSelectable(int column, int row)
	{
		ReturnColumnAndRowCount(out var columnCount, out var rowCount);
		if (column < 0 || columnCount <= column || row < 0 || rowCount <= row)
		{
			return null;
		}
		int num = ((_grid.startAxis != GridLayoutGroup.Axis.Horizontal) ? (row + column * rowCount) : (row * columnCount + column));
		if (-1 < num && num < _activeSelectables.Count)
		{
			return _activeSelectables[num];
		}
		return null;
	}

	protected override void Select(Selectable selectable)
	{
		base.Select(selectable);
		if ((bool)_selected && _selected.TryGetComponent<EventTrigger>(out _selectedEventTrigger))
		{
			_selectedEventTrigger.OnSelect(null);
		}
	}

	protected override void Deselect()
	{
		if ((bool)_selectedEventTrigger)
		{
			_selectedEventTrigger.OnDeselect(null);
			_selectedEventTrigger = null;
		}
		base.Deselect();
	}
}
