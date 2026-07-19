using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentIconToggle : MonoBehaviour
{
	public List<string> items = new List<string>();

	public RawImage rawImage;

	private List<Texture> textures = new List<Texture>();

	private int index;

	private void Prepare()
	{
		foreach (string item2 in items)
		{
			Texture item = Resources.Load<Texture>("Interface/Icons Next/" + item2);
			textures.Add(item);
		}
		SetValue(0);
	}

	public void Toggle()
	{
		if (index < items.Count - 1)
		{
			index++;
		}
		else
		{
			index = 0;
		}
		SetValue(index);
		GetComponent<ComponentBase>().Callback(base.name + "Toggle", index, base.transform);
	}

	public void SetValue(int _index)
	{
		rawImage.texture = textures[_index];
		index = _index;
	}

	public void SetList(List<string> list)
	{
		items = list;
	}
}
