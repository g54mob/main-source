using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectorItem : MonoBehaviour
{
	public Text Label;

	[NonSerialized]
	public GameObject Root;

	[NonSerialized]
	public InspectorItem Parent;

	public RectTransform ExpandIcon;

	public RectTransform Self;

	public Image Back;

	public GameObject Expander;

	public Color SelectColor;

	public float ExpandRot;

	public float CollapseRot;

	public float LevelPadding = 24f;

	[NonSerialized]
	public List<InspectorItem> Children = new List<InspectorItem>();

	[NonSerialized]
	public bool Expanded;

	[NonSerialized]
	public int Level;

	[NonSerialized]
	private int _lastSiblingIndex;

	public void Highlight(bool sel)
	{
		Back.color = (sel ? SelectColor : Color.white);
	}

	public void Init(GameObject o, InspectorItem parent)
	{
		Root = o;
		Label.text = o.name;
		Level = ((!(parent == null)) ? (parent.Level + 1) : 0);
		Self.anchoredPosition = new Vector2((float)Level * LevelPadding, Self.anchoredPosition.y);
		Parent = parent;
	}

	public void Expand()
	{
		Expanded = !Expanded;
		ExpandIcon.rotation = Quaternion.Euler(0f, 0f, Expanded ? ExpandRot : CollapseRot);
		if (Expanded)
		{
			Transform transform = Root.transform;
			for (int i = 0; i < transform.childCount; i++)
			{
				Children.Add(InspectorWindow.Instance.CreateInspectorItem(this, transform.GetChild(i).gameObject));
			}
			return;
		}
		for (int j = 0; j < Children.Count; j++)
		{
			Children[j].DestroyMe();
		}
		Children.Clear();
		InspectorWindow.Instance.DirtyOrder = true;
	}

	public void DestroyMe()
	{
		if (this != null)
		{
			for (int i = 0; i < Children.Count; i++)
			{
				Children[i].DestroyMe();
			}
			Children.Clear();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public void Inspect()
	{
		InspectorWindow.Instance.Inspector.Show(Root, null);
		InspectorWindow.Instance.SetSelected(this);
	}

	public void UpdateIndex()
	{
		if (Parent != null)
		{
			_lastSiblingIndex = Root.transform.GetSiblingIndex();
			if (Level == 0)
			{
				InspectorWindow.Instance.RootItems.Remove(this);
			}
			Level = Parent.Level + 1;
		}
		else
		{
			_lastSiblingIndex = -Root.transform.GetSiblingIndex();
			if (Level != 0)
			{
				InspectorWindow.Instance.RootItems.Add(this);
			}
		}
		Self.anchoredPosition = new Vector2((float)Level * LevelPadding, Self.anchoredPosition.y);
		InspectorWindow.Instance.DirtyOrder = true;
	}

	public InspectorItem GetLastChild()
	{
		if (Children.Count != 0)
		{
			return Children.MaxInstance((InspectorItem x) => x.transform.GetSiblingIndex()).GetLastChild();
		}
		return this;
	}

	private void OnDestroy()
	{
		if (InspectorWindow.Instance != null)
		{
			InspectorWindow.Instance.AllItems.Remove(Root);
			InspectorWindow.Instance.RootItems.Remove(this);
		}
	}

	private void Update()
	{
		if (Root == null)
		{
			DestroyMe();
			return;
		}
		Expander.SetActive(Root.transform.childCount > 0);
		if (Parent == null)
		{
			if (Root.transform.parent != null)
			{
				InspectorItem orNull = InspectorWindow.Instance.AllItems.GetOrNull(Root.transform.parent.gameObject);
				if (orNull == null || !orNull.Expanded)
				{
					DestroyMe();
					return;
				}
				Parent = orNull;
				UpdateIndex();
			}
		}
		else if (Root.transform.parent == null)
		{
			Parent.Children.Remove(this);
			Parent = null;
			UpdateIndex();
		}
		else if (Root.transform.parent.gameObject != Parent.Root)
		{
			Parent.Children.Remove(this);
			InspectorItem orNull2 = InspectorWindow.Instance.AllItems.GetOrNull(Root.transform.parent.gameObject);
			if (orNull2 == null || !orNull2.Expanded)
			{
				DestroyMe();
				return;
			}
			Parent = orNull2;
			UpdateIndex();
		}
		int num = _lastSiblingIndex;
		if (Parent == null)
		{
			num = -num;
		}
		if (num != Root.transform.GetSiblingIndex())
		{
			UpdateIndex();
		}
		Label.color = (Root.activeSelf ? new Color32(50, 50, 50, byte.MaxValue) : new Color32(100, 0, 0, byte.MaxValue));
		if (!Label.text.Equals(Root.name))
		{
			Label.text = Root.name;
		}
	}
}
