using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomArt : MonoBehaviour
{
	public Sprite[] sprites;

	public Image[] images;

	public void Start()
	{
		List<Sprite> list = new List<Sprite>(sprites);
		for (int i = 0; i < list.Count; i++)
		{
			int num = Random.Range(i, list.Count);
			int index = i;
			List<Sprite> list2 = list;
			int index2 = num;
			Sprite sprite = list[num];
			Sprite sprite2 = list[i];
			Sprite sprite3 = (list[index] = sprite);
			sprite3 = (list2[index2] = sprite2);
		}
		for (int j = 0; j < images.Length; j++)
		{
			images[j].sprite = list[j];
		}
	}
}
