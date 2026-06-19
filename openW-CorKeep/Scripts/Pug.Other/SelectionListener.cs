using UnityEngine;

public class SelectionListener : MonoBehaviour
{
	public void OnSelected(string sourceTag = null)
	{
		Component[] components = GetComponents<Component>();
		for (int i = 0; i < components.Length; i++)
		{
			if (components[i] is ISelectionListenerCallback selectionListenerCallback)
			{
				selectionListenerCallback.OnSelected(sourceTag);
			}
		}
	}

	public void OnDeselected(string sourceTag = null)
	{
		Component[] components = GetComponents<Component>();
		for (int i = 0; i < components.Length; i++)
		{
			if (components[i] is ISelectionListenerCallback selectionListenerCallback)
			{
				selectionListenerCallback.OnDeselected(sourceTag);
			}
		}
	}
}
