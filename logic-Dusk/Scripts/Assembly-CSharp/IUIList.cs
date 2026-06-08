using UnityEngine;

public interface IUIList
{
	GameObject UnderlyingGameObject { get; }

	int ItemCount { get; }

	int CurrentPageIndex { get; }

	int CurrentHighlightedIndex { get; }

	void Refresh();

	void GotFocus();

	void LoseFocus();

	bool MoveDown();

	bool MoveUp();

	bool MoveToBottom();

	bool MoveToTop();

	void MoveToTopOrSelected();

	bool DeleteHighlightedItem();

	void DeleteAllItems();

	bool RemoveBackendSelectedItem();

	void AddBackendItem(IUIItem item);

	IUIItem SelectHighlightedItem();

	IUIItem GetHighlightedItem();

	IUIItem GetSelectedItem();
}
