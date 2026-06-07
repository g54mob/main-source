using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ContextMenu : MonoBehaviour
{
	[Serializable]
	public class Item
	{
		public bool isDivider;

		public UnityEvent itemEvent;

		public string functionName;

		public KeyCode[] shortCuts;

		public Sprite image;
	}

	[Header("Context Items")]
	public Item[] items;

	[Header("Populate")]
	public GameObject template;

	public GameObject dividerTemplate;

	public Transform parent;

	[Header("Display")]
	public Canvas canvas;

	private Selectable selectable;

	private void Awake()
	{
	}

	public void Display(Selectable s)
	{
	}

	public void Hide()
	{
	}
}
