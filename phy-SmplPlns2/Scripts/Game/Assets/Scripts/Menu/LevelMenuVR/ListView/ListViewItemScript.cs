using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Menu.LevelMenuVR.ListView
{
	public class ListViewItemScript : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
	{
		[SerializeField]
		private Image _checkmark;

		[SerializeField]
		private Image _highlight;

		[SerializeField]
		private Color _hoverColor;

		private bool _hovered;

		private Color _invisible = new Color(0f, 0f, 0f, 0f);

		[SerializeField]
		private Image _lock;

		private bool _selected;

		[SerializeField]
		private Color _selectedColor;

		[SerializeField]
		private TextMeshProUGUI _text;

		[SerializeField]
		private Image _thumbnail;

		private TweenerCore<Color, Color, ColorOptions> _tween;

		public Color Color { get; private set; }

		public ListViewScript ListView { get; private set; }

		public bool LockVisible
		{
			get
			{
				return _lock.gameObject.activeSelf;
			}
			set
			{
				_lock.gameObject.SetActive(value);
			}
		}

		public ItemModel Model { get; private set; }

		public string Name
		{
			get
			{
				return _text.text;
			}
			private set
			{
				_text.text = value;
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
				_selected = value;
				UpdateHighlight();
			}
		}

		private bool Hovered
		{
			get
			{
				return _hovered;
			}
			set
			{
				_hovered = value;
				UpdateHighlight();
			}
		}

		public void Initialize(ItemModel model, ListViewScript listView)
		{
			Model = model;
			Name = model.Name;
			UpdateCheckmarkStyle();
			ListView = listView;
			if (model.Sprite != null)
			{
				_thumbnail.sprite = model.Sprite;
			}
			LockVisible = Model.IsLocked;
			UpdateTextColor();
			if (LockVisible)
			{
				_thumbnail.color = new Color(0.5f, 0.5f, 0.5f, 1f);
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			ListView.OnItemClicked(this);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			Hovered = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			Hovered = false;
		}

		public void UpdateCheckmarkStyle()
		{
			ItemModel.CheckmarkStyleTypes checkmarkStyleTypes = Model.CheckmarkStyle();
			_checkmark.gameObject.SetActive(checkmarkStyleTypes != ItemModel.CheckmarkStyleTypes.Invisible);
			Color color = Color.white;
			switch (checkmarkStyleTypes)
			{
			case ItemModel.CheckmarkStyleTypes.Invisible:
				color = Color.white;
				break;
			case ItemModel.CheckmarkStyleTypes.Success:
				color = new Color32(0, 168, 15, byte.MaxValue);
				break;
			case ItemModel.CheckmarkStyleTypes.Error:
				color = new Color32(byte.MaxValue, 52, 47, byte.MaxValue);
				break;
			}
			_checkmark.color = color;
		}

		protected virtual void OnDestroy()
		{
			_tween?.Kill();
		}

		private void UpdateHighlight()
		{
			_tween?.Kill();
			UpdateTextColor();
			Color invisible = _invisible;
			_tween = DOTween.To(endValue: _selected ? _selectedColor : ((!_hovered) ? _invisible : _hoverColor), getter: () => _highlight.color, setter: delegate(Color x)
			{
				_highlight.color = x;
			}, duration: 0.25f).SetUpdate(isIndependentUpdate: true);
		}

		private void UpdateTextColor()
		{
			if (Selected)
			{
				_text.color = Color.white;
			}
			else
			{
				_text.color = (LockVisible ? new Color(0.5f, 0.5f, 0.5f, 1f) : Color.white);
			}
		}
	}
}
