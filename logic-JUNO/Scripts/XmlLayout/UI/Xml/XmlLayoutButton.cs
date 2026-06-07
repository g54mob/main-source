using UI.Tables;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Xml
{
	[ExecuteInEditMode]
	public class XmlLayoutButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[Header("Icon Colors")]
		public Color IconColor;

		public Color IconHoverColor;

		public Color IconDisabledColor;

		[Header("Text Colors")]
		public ColorBlock TextColors = new ColorBlock
		{
			normalColor = Color.black,
			highlightedColor = Color.black,
			disabledColor = Color.black,
			pressedColor = Color.black,
			colorMultiplier = 1f
		};

		[Header("References")]
		public Image IconComponent;

		public TableLayout ButtonTableLayout;

		public TableCell IconCell;

		public TableCell TextCell;

		public TextComponentWrapper TextComponent;

		public Selectable PrimaryComponent;

		private XmlElement m_xmlElement;

		private XmlElement.SelectionState selectionState;

		private XmlElement xmlElement
		{
			get
			{
				if (m_xmlElement == null)
				{
					m_xmlElement = GetComponent<XmlElement>();
				}
				return m_xmlElement;
			}
		}

		public bool mouseIsOver { get; protected set; }

		private void Start()
		{
			if (IconColor == default(Color))
			{
				IconColor = Color.white;
			}
			if (IconHoverColor == default(Color))
			{
				IconHoverColor = IconColor;
			}
			if (IconComponent != null)
			{
				IconComponent.color = IconColor;
			}
			NotifyButtonStateChanged(XmlElement.SelectionState.Normal);
		}

		public virtual void OnPointerEnter(PointerEventData eventData)
		{
			mouseIsOver = true;
			if (PrimaryComponent.interactable && IconComponent != null)
			{
				IconComponent.color = IconHoverColor;
			}
		}

		public virtual void OnPointerExit(PointerEventData eventData)
		{
			mouseIsOver = false;
			if (PrimaryComponent.interactable && IconComponent != null)
			{
				IconComponent.color = IconColor;
			}
		}

		public void NotifyButtonStateChanged(XmlElement.SelectionState newSelectionState)
		{
			if (Application.isPlaying && newSelectionState == selectionState)
			{
				return;
			}
			selectionState = newSelectionState;
			if (xmlElement != null)
			{
				xmlElement.NotifySelectionStateChanged(newSelectionState);
			}
			if (IconComponent != null)
			{
				if (PrimaryComponent.interactable)
				{
					IconComponent.color = IconColor;
				}
				else
				{
					IconComponent.color = IconDisabledColor;
				}
			}
			if (TextComponent != null)
			{
				_ = PrimaryComponent.interactable;
			}
		}
	}
}
