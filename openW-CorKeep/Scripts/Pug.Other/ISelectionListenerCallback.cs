public interface ISelectionListenerCallback
{
	void OnSelected(string sourceTag = null);

	void OnDeselected(string sourceTag = null);
}
