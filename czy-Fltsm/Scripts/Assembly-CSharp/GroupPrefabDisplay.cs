using System.Collections.Generic;
using UnityEngine;

public class GroupPrefabDisplay : MonoBehaviour
{
	[SerializeField]
	private GameObject _prefab;

	private List<GameObject> _displays;

	public void Display(int amount)
	{
		if (_displays == null)
		{
			_displays = new List<GameObject>(amount);
		}
		foreach (GameObject display in _displays)
		{
			display.SetActive(value: false);
		}
		for (int i = 0; i < amount; i++)
		{
			if (i >= _displays.Count)
			{
				GameObject item = Object.Instantiate(_prefab, base.transform);
				_displays.Add(item);
			}
			else
			{
				_displays[i].gameObject.SetActive(value: true);
			}
		}
	}
}
