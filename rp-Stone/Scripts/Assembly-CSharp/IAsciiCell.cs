using UnityEngine;

public interface IAsciiCell
{
	void SetValue(int asciiValue);

	void SetValue(int asciiValue, Color foreground);

	void SetValue(int asciiValue, Color foreground, Color background);

	int GetValue();

	Color GetForeground();

	Color GetBackground();

	void SetBackground(Color background);

	void SetForeground(Color foreround);

	void SetGridPosition(int x, int y);

	void SetInteractionLayer(ICellInteractable interactableObject, int priority = 0);

	ICellInteractable GetInteractionLayer();

	int GetInteractionPriority();

	void ClearInteractionLayer();

	void SetUnicodeValue(char value);

	char GetUnicodeValue();

	void Push();
}
