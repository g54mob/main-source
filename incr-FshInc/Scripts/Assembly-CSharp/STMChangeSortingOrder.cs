using UnityEngine;

public class STMChangeSortingOrder : MonoBehaviour
{
	public int sortingOrder;

	public string sortingLayer = "Default";

	private void OnEnable()
	{
		Refresh();
	}

	private void OnValidate()
	{
		Refresh();
	}

	public void Refresh()
	{
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			component.sortingOrder = sortingOrder;
			component.sortingLayerName = sortingLayer;
		}
	}
}
