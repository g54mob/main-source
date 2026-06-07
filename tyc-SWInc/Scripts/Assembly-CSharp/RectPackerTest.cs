using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RectPackerTest : MonoBehaviour
{
	public int Rects;

	public int[] sizes;

	public float delay = 0.5f;

	public RectTransform RectPrefab;

	public RectTransform SelfRect;

	private List<GameObject> _spaces = new List<GameObject>();

	private void Start()
	{
		RectPacker<int[]> rectPacker = new RectPacker<int[]>((int[] x) => new Vector2(x[0], x[1]), 2);
		for (int num = 0; num < Rects; num++)
		{
			int random = sizes.GetRandom();
			int[] item = new int[2] { random, random };
			rectPacker.AddItem(item);
		}
		StartCoroutine(rectPacker.Pack(RunUpdate, delay));
	}

	private void RunUpdate(Rect r, Vector2 fs, List<Rect> subSpaces)
	{
		SelfRect.sizeDelta = fs;
		MakeRect(r, Utilities.HSVToRGB(Random.Range(0, 360), 1f, 1f).ToVector4(1f));
		foreach (GameObject space in _spaces)
		{
			Object.Destroy(space);
		}
		_spaces.Clear();
		foreach (Rect subSpace in subSpaces)
		{
			GameObject gameObject = MakeRect(subSpace, new Color(1f, 1f, 1f, 0.5f));
			gameObject.transform.SetSiblingIndex(0);
			_spaces.Add(gameObject);
		}
	}

	private GameObject MakeRect(Rect r, Color c)
	{
		RectTransform rectTransform = Object.Instantiate(RectPrefab);
		rectTransform.gameObject.SetActive(true);
		rectTransform.GetComponent<Image>().color = c;
		rectTransform.SetParent(SelfRect, false);
		rectTransform.anchoredPosition = new Vector2(r.position.x, 0f - r.position.y);
		rectTransform.sizeDelta = r.size;
		return rectTransform.gameObject;
	}
}
