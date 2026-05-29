using System.Collections.Generic;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

public class WallSelectionManager : MonoSingleton<WallSelectionManager>
{
	[SerializeField]
	private Material _selectionMaterial;

	[SerializeField]
	[Layer]
	private int _selectionLayer;

	private List<SelectableWall> _currentSelectables = new List<SelectableWall>();

	protected override void SingletonAwake()
	{
	}

	protected override void OnSingletonDestroy()
	{
	}

	public void AddSelectable(SelectableWall[] selectables)
	{
		for (int i = 0; i < selectables.Length; i++)
		{
			selectables[i].SetToSelectionLayer(_selectionLayer);
		}
		_currentSelectables.AddRange(selectables);
	}

	public void RemoveSelectable(SelectableWall[] selectables)
	{
		for (int i = 0; i < selectables.Length; i++)
		{
			if (_currentSelectables.Contains(selectables[i]))
			{
				selectables[i].ResetToDefaultLayer();
				_currentSelectables.Remove(selectables[i]);
			}
		}
	}

	public SelectableWall GetFirstSelectable()
	{
		return _currentSelectables[0];
	}

	public int GetSelectableCount()
	{
		return _currentSelectables.Count;
	}

	public bool ContaintSelectable(SelectableWall selectable)
	{
		return _currentSelectables.Contains(selectable);
	}

	public void RemoveSelectable(SelectableWall selectable)
	{
		if (_currentSelectables.Contains(selectable))
		{
			selectable.ResetToDefaultLayer();
			_currentSelectables.Remove(selectable);
		}
	}

	public void ClearSelectables()
	{
		if (_currentSelectables.Count != 0)
		{
			for (int i = 0; i < _currentSelectables.Count; i++)
			{
				_currentSelectables[i]?.ResetToDefaultLayer();
			}
			_currentSelectables.Clear();
		}
	}

	public List<SelectableWall> GetChildSelectables(GameObject go)
	{
		List<SelectableWall> list = new List<SelectableWall>();
		for (int i = 0; i < go.transform.childCount; i++)
		{
			if (go.transform.GetChild(i).TryGetComponent<SelectableWall>(out var component))
			{
				list.Add(component);
			}
		}
		return list;
	}
}
