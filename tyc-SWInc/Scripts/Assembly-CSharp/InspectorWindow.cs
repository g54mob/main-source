using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InspectorWindow : MonoBehaviour
{
	public static InspectorWindow Instance;

	public ObjectInspector Inspector;

	public ObjectInspector ObjectInspectorPrefab;

	public ImageInspector ImageInspectorPrefab;

	public RectTransform Content;

	public RectTransform Viewport;

	public InspectorItem InspectorPrefab;

	public InputField SearchField;

	public Toggle ControllerScene;

	public GUIWindow Window;

	public ScrollRect Scroll;

	public float ItemHeight = 24f;

	[NonSerialized]
	private InspectorItem _selected;

	[NonSerialized]
	public bool DirtyOrder;

	[NonSerialized]
	private bool _focusSelect;

	[NonSerialized]
	public Dictionary<GameObject, InspectorItem> AllItems = new Dictionary<GameObject, InspectorItem>();

	[NonSerialized]
	public List<InspectorItem> RootItems = new List<InspectorItem>();

	private void Awake()
	{
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	public void SetSelected(InspectorItem item)
	{
		if (_selected != null)
		{
			_selected.Highlight(false);
		}
		item.Highlight(true);
		_selected = item;
	}

	public void ToggleScene()
	{
		AllItems.Values.ForEachEnum(delegate(InspectorItem x)
		{
			UnityEngine.Object.Destroy(x.gameObject);
		});
		RootItems.Clear();
		AllItems.Clear();
	}

	private void Update()
	{
		GameObject[] rootGameObjects = (ControllerScene.isOn ? ModController.Instance.gameObject : base.gameObject).scene.GetRootGameObjects();
		for (int i = 0; i < rootGameObjects.Length; i++)
		{
			if (!AllItems.ContainsKey(rootGameObjects[i]) && rootGameObjects[i] != base.gameObject && rootGameObjects[i] != null)
			{
				CreateInspectorItem(null, rootGameObjects[i]);
			}
		}
		if (!DirtyOrder)
		{
			return;
		}
		int index = 0;
		RootItems.RemoveAll((InspectorItem x) => x.Root == null);
		foreach (InspectorItem item in RootItems.OrderBy((InspectorItem x) => x.Root.transform.GetSiblingIndex()))
		{
			OrderItem(item, ref index);
		}
		Content.sizeDelta = new Vector2(Content.sizeDelta.x, (float)index * ItemHeight);
		if (_focusSelect && _selected != null)
		{
			Scroll.normalizedPosition = new Vector2(0f, Mathf.Clamp01(1f - (0f - _selected.Self.anchoredPosition.y - Viewport.rect.height / 2f) / (Content.sizeDelta.y - Viewport.rect.height)));
		}
		DirtyOrder = false;
		_focusSelect = false;
	}

	public void OrderItem(InspectorItem item, ref int index)
	{
		if (item.gameObject.activeSelf)
		{
			item.Self.anchoredPosition = new Vector2(item.Self.anchoredPosition.x, (float)(-index) * ItemHeight);
			index++;
		}
		foreach (InspectorItem item2 in item.Children.OrderBy((InspectorItem x) => x.Root.transform.GetSiblingIndex()))
		{
			OrderItem(item2, ref index);
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public void OnSearchChange()
	{
		if (string.IsNullOrWhiteSpace(SearchField.text))
		{
			AllItems.Values.ForEachEnum(delegate(InspectorItem x)
			{
				x.gameObject.SetActive(true);
			});
			_focusSelect = true;
		}
		else
		{
			string q = SearchField.text.ToLower();
			AllItems.Values.ForEachEnum(delegate(InspectorItem x)
			{
				x.gameObject.SetActive(x.Label.text.ToLower().Contains(q));
			});
		}
		DirtyOrder = true;
	}

	public InspectorItem CreateInspectorItem(InspectorItem parent, GameObject root)
	{
		InspectorItem inspectorItem = UnityEngine.Object.Instantiate(InspectorPrefab);
		inspectorItem.transform.SetParent(Content, false);
		inspectorItem.Init(root, parent);
		if (parent == null)
		{
			RootItems.Add(inspectorItem);
		}
		AllItems[root] = inspectorItem;
		if (!string.IsNullOrWhiteSpace(SearchField.text))
		{
			inspectorItem.gameObject.SetActive(root.name.ToLower().Contains(SearchField.text.ToLower()));
		}
		DirtyOrder = true;
		return inspectorItem;
	}
}
