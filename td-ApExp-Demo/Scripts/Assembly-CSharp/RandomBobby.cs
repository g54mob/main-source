using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class RandomBobby : MonoBehaviour
{
	[SerializeField]
	private SerializedDictionary<Sprite, bool> bobbyVariants;

	[SerializeField]
	private SpriteRenderer bobbySr;

	private void OnEnable()
	{
		List<Sprite> list = new List<Sprite>();
		foreach (KeyValuePair<Sprite, bool> bobbyVariant in bobbyVariants)
		{
			if (bobbyVariant.Value)
			{
				list.Add(bobbyVariant.Key);
			}
		}
		bobbySr.sprite = list[Random.Range(0, list.Count)];
	}
}
