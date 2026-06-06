using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionCellsPanel : MonoBehaviour
{
	[SerializeField]
	private List<CollectionCell> _cells;

	[SerializeField]
	private ScrollRect _scrollRect;

	public event Action<CollectionCell> OnSelectCollectionCell;

	public void Show()
	{
		List<Animal> list = new List<Animal>();
		list = AnimalManager.Instance.GetAnimalList();
		for (int i = 0; i < _cells.Count; i++)
		{
			if (i < list.Count)
			{
				_cells[i].OnSelectCollectionCell += SelectCell;
				_cells[i].Show(list[i]);
			}
			else
			{
				_cells[i].OnSelectCollectionCell -= SelectCell;
				_cells[i].Hide();
			}
		}
		SelectCell(_cells[0]);
		_scrollRect.verticalNormalizedPosition = 1f;
	}

	public void Hide()
	{
		for (int i = 0; i < _cells.Count; i++)
		{
			_cells[i].OnSelectCollectionCell -= SelectCell;
			_cells[i].Hide();
		}
	}

	private void SelectCell(CollectionCell collectionCell)
	{
		foreach (CollectionCell cell in _cells)
		{
			cell.SetUnselect();
		}
		collectionCell.SetSelect();
		this.OnSelectCollectionCell?.Invoke(collectionCell);
	}

	public void UpdateCellByCollectAnimal(Animal collectAnimal)
	{
		foreach (CollectionCell cell in _cells)
		{
			if (cell.Animal != null && cell.Animal.AnimalData.ID == collectAnimal.AnimalData.ID)
			{
				cell.UpdateCellState();
			}
		}
	}
}
