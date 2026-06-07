using System.Collections.Generic;
using UnityEngine;

public class LayoutHelper<T> where T : Component
{
	private Transform root;

	private GameObject element;

	private List<T> _elements;

	public T[] elements => null;

	public int Count => 0;

	public LayoutHelper(Transform root)
	{
	}

	public void Clear()
	{
	}

	public T GetElement(int index)
	{
		return null;
	}

	public void RemoveElement(int index, bool destroy = true)
	{
	}

	public void AddElement(T element)
	{
	}

	public T InstantiateElement(string name = null, params LayoutHelperProperty[] elements)
	{
		return null;
	}

	public T InstantiateCustomElement(string element, string name = null, params LayoutHelperProperty[] properties)
	{
		return null;
	}

	public T InstantiateCustomElement(GameObject _element, string name = null, params LayoutHelperProperty[] properties)
	{
		return null;
	}

	public void SetupElement(int index, params LayoutHelperProperty[] properties)
	{
	}

	public void SetupElement(T instantiatedElement, params LayoutHelperProperty[] properties)
	{
	}
}
