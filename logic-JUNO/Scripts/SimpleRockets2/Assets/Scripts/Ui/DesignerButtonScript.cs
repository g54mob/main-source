using Assets.Scripts.Design;
using ModApi.Ui;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.Ui
{
	public class DesignerButtonScript : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		private DesignerUiScript _designerUi;

		[SerializeField]
		private Image _icon;

		private bool _selected;

		[SerializeField]
		private GameObject _selectedOverlay;

		public IFlyout Flyout { get; set; }

		public Sprite IconSprite
		{
			get
			{
				return _icon.sprite;
			}
			private set
			{
				_icon.sprite = value;
				_icon.SetNativeSize();
			}
		}

		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				if (_selected != value)
				{
					_selected = value;
				}
				UpdateLayout();
			}
		}

		public bool Visible
		{
			get
			{
				return base.gameObject.activeSelf;
			}
			set
			{
				if (Visible != value)
				{
					base.gameObject.SetActive(value);
				}
			}
		}

		public void AddClickListener(UnityAction call)
		{
			GetComponent<Button>().onClick.AddListener(call);
		}

		public void Initialize(Sprite iconSprite, IFlyout flyout, DesignerUiScript designerUi)
		{
			IconSprite = iconSprite;
			Flyout = flyout;
			_designerUi = designerUi;
			AddClickListener(delegate
			{
				_designerUi.ToggleFlyout(Flyout);
			});
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		protected virtual void Start()
		{
			UpdateLayout();
		}

		protected virtual void Update()
		{
			Selected = Flyout != null && Flyout.IsOpen;
		}

		private void UpdateLayout()
		{
			ColorBlock colors = GetComponent<Button>().colors;
			if (Selected)
			{
				colors.normalColor = Color.white;
				colors.highlightedColor = Color.white;
				colors.pressedColor = Color.white;
			}
			else
			{
				colors.normalColor = new Color(1f, 1f, 1f, 0f);
				colors.highlightedColor = new Color(1f, 1f, 1f, 0.25f);
				colors.pressedColor = new Color(1f, 1f, 1f, 0.75f);
			}
			GetComponent<Button>().colors = colors;
			if (_selectedOverlay != null)
			{
				_selectedOverlay.SetActive(Selected);
			}
		}
	}
}
