using System.Collections.Generic;
using UnityEngine;

public class WrappingHorizontalLayoutGroup : MonoBehaviour
{
	public float cellHeight;

	public Vector2 padding;

	private HashSet<GameObject> elements;

	private List<List<GameObject>> rows;

	private float MaxWidth => 0f;

	private float CurrentRowHeight => 0f;

	public void AddGameObjectToLayout(GameObject gameObject)
	{
	}

	public void EmptyLayoutGroup()
	{
	}

	private List<GameObject> AddRow()
	{
		return null;
	}

	private List<GameObject> CurrentRow()
	{
		return null;
	}

	private float RowWidth(List<GameObject> row)
	{
		return 0f;
	}
}
