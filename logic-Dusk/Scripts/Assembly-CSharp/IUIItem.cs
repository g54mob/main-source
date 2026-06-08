using UnityEngine;

public interface IUIItem
{
	GameObject UnderlyingGameObject { get; }

	IInventoryItem ParentItem { get; set; }

	IInventoryItem InventoryItem { get; set; }

	bool IsHighlighted { get; }

	bool IsSelected { get; }

	bool IsActive { get; }

	IUIItem AffectedItem { get; set; }

	void ClearSelection();

	void ClearHighlight();

	void Select();

	void Highlight();

	void Dim();

	void UnDim();

	void SetInactive();

	void SetActive();
}
