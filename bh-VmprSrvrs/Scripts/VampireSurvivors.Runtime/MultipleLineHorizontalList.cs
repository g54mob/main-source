using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(VerticalLayoutGroup))]
public class MultipleLineHorizontalList : MonoBehaviour
{
	[SerializeField]
	private float _LineHeight;

	[SerializeField]
	private float _MaxWidth;

	[SerializeField]
	private float _PortraitMaxWidth;

	private List<GameObject> _lines;

	private RectTransform _activeLine;

	private List<GameObject> _spawned;

	private void Start()
	{
	}

	public void AddNewItem(RectTransform t)
	{
	}

	public void Clear()
	{
	}

	public void CreateNewLine()
	{
	}

	public void SetMaxWidth(float w)
	{
	}
}
