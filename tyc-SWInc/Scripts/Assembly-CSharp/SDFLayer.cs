using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SDFLayer : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public RawImage Icon;

	public Image Back;

	public Text Label;

	public Toggle Show;

	[NonSerialized]
	public SDFSimpleEditor.SDFSuperNode Node;

	[NonSerialized]
	public SDFSimpleEditor Parent;

	public Color ActiveColor;

	public Color NotActiveColor;

	public Color EffectColor;

	public Color GraphicColor;

	public Color MaskColor;

	public Outline OuterEdge;

	public RectTransform CollapseImage;

	public bool Collapsed;

	public void Init(SDFSimpleEditor parent, SDFSimpleEditor.SDFSuperNode node)
	{
		Parent = parent;
		Node = node;
		Refresh();
	}

	public void Collapse()
	{
		Collapsed = !Collapsed;
		CollapseImage.rotation = Quaternion.Euler(0f, 0f, Collapsed ? 180 : 90);
		Parent.UpdateActivation();
	}

	public void UpdateActivation(bool activated)
	{
		base.gameObject.SetActive(activated);
		foreach (SDFSimpleEditor.SDFSuperNode child in Node.Children)
		{
			child.UILayer.UpdateActivation(activated && !Collapsed);
		}
	}

	public void UpdateCollapse()
	{
		CollapseImage.gameObject.SetActive(Node.Children.Count > 0);
	}

	public int GetDepth()
	{
		int num = 0;
		for (SDFSimpleEditor.SDFSuperNode parent = Node.Parent; parent != null; parent = parent.Parent)
		{
			num++;
		}
		return num;
	}

	public void UpdateHidden()
	{
		Parent.Dirty = 1;
	}

	public void RefreshDepth()
	{
		Back.rectTransform.offsetMin = new Vector2(GetDepth() * 24, 0f);
	}

	public Texture GetIcon()
	{
		switch (Node.SDFType)
		{
		case SDFSimpleEditor.SDFSuperNode.Type.Shape:
			return Parent.GetSDFIcon(Node.Function);
		case SDFSimpleEditor.SDFSuperNode.Type.Texture:
			return Parent.GetSDFIcon(Node.SDFResource);
		case SDFSimpleEditor.SDFSuperNode.Type.Mirror:
			return Parent.MirrorIcon;
		case SDFSimpleEditor.SDFSuperNode.Type.Array:
			return Parent.ArrayIcon;
		case SDFSimpleEditor.SDFSuperNode.Type.Reflect:
			return Parent.ReflectIcon;
		default:
			return null;
		}
	}

	public void Refresh()
	{
		RefreshDepth();
		UpdateCollapse();
		Icon.texture = GetIcon();
		if (Node.Parent != null && (Node.SDFType == SDFSimpleEditor.SDFSuperNode.Type.Shape || Node.SDFType == SDFSimpleEditor.SDFSuperNode.Type.Texture))
		{
			Icon.color = MaskColor;
			OuterEdge.effectColor = Color.black;
			Label.text = SDFCreator.GetCombineLoc(Node.CombineType).Loc();
			switch (Node.SDFType)
			{
			case SDFSimpleEditor.SDFSuperNode.Type.Shape:
			{
				Text label2 = Label;
				label2.text = label2.text + ": " + Node.Function;
				break;
			}
			case SDFSimpleEditor.SDFSuperNode.Type.Texture:
			{
				Text label = Label;
				label.text = label.text + ": " + Node.SDFResource;
				break;
			}
			}
			return;
		}
		switch (Node.SDFType)
		{
		case SDFSimpleEditor.SDFSuperNode.Type.Shape:
			Icon.color = Color.Lerp(Node.MainColor, Node.GradientColor, 0.5f);
			OuterEdge.effectColor = ((Node.Outline > 0f) ? Node.OutlineColor : Icon.color.Invert());
			Label.text = Node.Function.ToString();
			break;
		case SDFSimpleEditor.SDFSuperNode.Type.Texture:
			Icon.color = Color.Lerp(Node.MainColor, Node.GradientColor, 0.5f);
			OuterEdge.effectColor = ((Node.Outline > 0f) ? Node.OutlineColor : Icon.color.Invert());
			Label.text = Node.SDFResource;
			break;
		case SDFSimpleEditor.SDFSuperNode.Type.Mirror:
			Icon.color = EffectColor;
			Label.text = "SDFMirror".Loc();
			break;
		case SDFSimpleEditor.SDFSuperNode.Type.Array:
			Icon.color = EffectColor;
			Label.text = "SDFArray".Loc();
			break;
		case SDFSimpleEditor.SDFSuperNode.Type.Reflect:
			Icon.color = EffectColor;
			Label.text = "SDFReflect".Loc();
			break;
		}
	}

	public void DestroyMe()
	{
		DeepDestroy(this, Parent);
		Parent.Dirty = 1;
		Parent.ArrangeLayers();
	}

	private static void DeepDestroy(SDFLayer layer, SDFSimpleEditor editor)
	{
		List<SDFSimpleEditor.SDFSuperNode> list = layer.Node.Children.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			DeepDestroy(list[i].UILayer, editor);
		}
		if (editor.IsActiveLayer(layer))
		{
			editor.RemoveActiveLayer(layer);
		}
		if (layer.Node.Parent != null)
		{
			layer.Node.Parent.Children.Remove(layer.Node);
			layer.Node.SetParent(null);
		}
		else
		{
			editor.Layers.Remove(layer.Node);
		}
		UnityEngine.Object.Destroy(layer.gameObject);
	}

	public void Activate()
	{
		Parent.SetActiveLayer(this);
	}

	public void SetActive(bool active)
	{
		if (active)
		{
			UISoundFX.PlaySFX("HighlightTick");
		}
		Back.color = (active ? ActiveColor : NotActiveColor);
	}

	public void StartDrag()
	{
		Parent.StartDragging(this);
	}

	public void Duplicate()
	{
		if (!Parent.CanCreate())
		{
			return;
		}
		SDFSimpleEditor.SDFSuperNode sDFSuperNode = Node.Clone();
		if (Node.Parent != null)
		{
			sDFSuperNode.SetParent(Node.Parent, Node.Parent.Children.IndexOf(Node));
		}
		else
		{
			Parent.Layers.Insert(Parent.Layers.IndexOf(Node) + 1, sDFSuperNode);
		}
		Parent.CreateSDFLayerDirect(sDFSuperNode);
		foreach (SDFSimpleEditor.SDFSuperNode child in Node.Children)
		{
			DeepDuplicate(child, sDFSuperNode, Parent);
		}
		Parent.ArrangeLayers();
		Parent.Dirty = 1;
	}

	public static void DeepDuplicate(SDFSimpleEditor.SDFSuperNode copy, SDFSimpleEditor.SDFSuperNode parent, SDFSimpleEditor editor)
	{
		if (!editor.CanCreate())
		{
			return;
		}
		SDFSimpleEditor.SDFSuperNode sDFSuperNode = copy.Clone();
		sDFSuperNode.SetParent(parent);
		editor.CreateSDFLayerDirect(sDFSuperNode);
		foreach (SDFSimpleEditor.SDFSuperNode child in copy.Children)
		{
			DeepDuplicate(child, sDFSuperNode, editor);
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (Input.GetKey(KeyCode.LeftShift))
		{
			if (Parent.IsActiveLayer(this))
			{
				Parent.RemoveActiveLayer(this);
			}
			else
			{
				Parent.AddActiveLayer(this);
			}
		}
		else
		{
			Parent.SetActiveLayer(this);
		}
	}
}
