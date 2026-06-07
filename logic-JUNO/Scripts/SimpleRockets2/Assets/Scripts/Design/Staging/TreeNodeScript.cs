using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Ui;
using DG.Tweening;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Design.Staging
{
	public class TreeNodeScript : MonoBehaviour, IDraggableItem
	{
		private Image _arrow;

		private float _arrowRotation = -90f;

		private Button _button;

		private List<TreeNodeScript> _children = new List<TreeNodeScript>();

		private GameObject _dragElement;

		private DragHandlerScript _dragHandler;

		private bool _expanded;

		private Vector3 _grabDelta;

		private bool _showReadyForDragIndication;

		private TextMeshProUGUI _text;

		private bool _visible = true;

		public Button Button => _button;

		public bool CanDrag => true;

		public GameObject DragElement => _dragElement;

		public Transform DragParent => StagingEditor.DragParent;

		public virtual bool Empty => false;

		public bool Expanded
		{
			get
			{
				return _expanded;
			}
			set
			{
				if (_expanded != value)
				{
					_expanded = value;
					UpdateContent();
					AnimateArrow();
				}
			}
		}

		public bool IsDragging => _dragHandler.IsDragging;

		public int Order { get; set; }

		public TreeNodeScript Parent { get; set; }

		public bool ShowReadyForDragIndication
		{
			get
			{
				return _showReadyForDragIndication;
			}
			set
			{
				if (_showReadyForDragIndication == value)
				{
					return;
				}
				_showReadyForDragIndication = value;
				XmlElement nodeButton = GetNodeButton();
				if (nodeButton != null)
				{
					if (value)
					{
						nodeButton.AddClass("ready-for-drag");
					}
					else
					{
						nodeButton.RemoveClass("ready-for-drag");
					}
				}
			}
		}

		public StageNodeScript StageNode
		{
			get
			{
				if (Parent != null)
				{
					return Parent.StageNode;
				}
				return this as StageNodeScript;
			}
		}

		public StagingEditorScript StagingEditor { get; protected set; }

		public string Text
		{
			get
			{
				return _text.text;
			}
			set
			{
				_text.text = value;
			}
		}

		public bool Visible
		{
			get
			{
				return _visible;
			}
			set
			{
				if (_visible != value)
				{
					_visible = value;
					base.gameObject.SetActive(_visible);
				}
			}
		}

		public XmlElement XmlElement { get; private set; }

		protected IReadOnlyList<TreeNodeScript> Children => _children;

		public virtual void AddChild(TreeNodeScript child)
		{
			if (child.Parent != null)
			{
				child.Parent.RemoveChild(child);
			}
			child.Parent = this;
			TreeNodeScript treeNodeScript = null;
			for (int i = 0; i < _children.Count; i++)
			{
				if (child.Order < _children[i].Order)
				{
					_children.Insert(i, child);
					treeNodeScript = _children[i];
					break;
				}
			}
			child.transform.SetParent(base.transform);
			if (treeNodeScript == null)
			{
				_children.Add(child);
				return;
			}
			int num = treeNodeScript.transform.GetSiblingIndex() - 1;
			if (num < 0)
			{
				num = 0;
			}
			child.transform.SetSiblingIndex(num);
		}

		public List<PartNodeScript> GetPartNodes()
		{
			List<PartNodeScript> list = new List<PartNodeScript>();
			GetPartNodesRecursive(list);
			return list;
		}

		public virtual void HighlightParts(bool highlight)
		{
			foreach (TreeNodeScript child in Children)
			{
				child.HighlightParts(highlight);
			}
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			StagingEditor.StartDrag(this);
		}

		public void OnDrag(PointerEventData eventData)
		{
			StagingEditor.Dragging(eventData);
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			StagingEditor.EndDrag(this);
		}

		public void RemoveChild(TreeNodeScript child)
		{
			_children.Remove(child);
			child.Parent = null;
		}

		public virtual void UpdateContent()
		{
			foreach (TreeNodeScript child in Children)
			{
				child.UpdateContent();
			}
		}

		protected virtual void GetPartNodesRecursive(List<PartNodeScript> nodes)
		{
			foreach (TreeNodeScript child in Children)
			{
				child.GetPartNodesRecursive(nodes);
			}
		}

		protected void InitializeNode(StagingEditorScript stagingEditor, XmlElement element)
		{
			StagingEditor = stagingEditor;
			XmlElement = element;
			_text = element.GetElementByInternalId<TextMeshProUGUI>("name");
			_button = element.GetComponentInChildren<Button>();
			_button.onClick.AddListener(OnClicked);
			_dragHandler = _button.gameObject.AddComponent<DragHandlerScript>();
			_dragHandler.Item = this;
			_dragElement = _button.gameObject;
			_arrow = element.GetElementByInternalId<Image>("arrow");
		}

		private void AnimateArrow()
		{
			if (_arrow != null)
			{
				float endValue = 0f;
				if (_expanded)
				{
					endValue = -90f;
				}
				DOTween.To(() => _arrowRotation, delegate(float z)
				{
					_arrow.rectTransform.localRotation = Quaternion.Euler(0f, 0f, z);
					_arrowRotation = z;
				}, endValue, 0.25f);
			}
		}

		private XmlElement GetNodeButton()
		{
			XmlElement xmlElement = XmlElement.GetChildElementsWithClass("node-button").FirstOrDefault();
			if (xmlElement == null && XmlElement.HasClass("node-button"))
			{
				xmlElement = XmlElement;
			}
			return xmlElement;
		}

		private void OnClicked()
		{
			Expanded = !Expanded;
		}
	}
}
