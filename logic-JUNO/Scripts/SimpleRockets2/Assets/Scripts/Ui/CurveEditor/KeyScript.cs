using Assets.Scripts.Flight.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.CurveEditor
{
	public class KeyScript : MonoBehaviour
	{
		private RectTransform _rectTransform;

		private CurveEditorScript _editor;

		private Image _image;

		private InputHandlerScript _inputHandler;

		[SerializeField]
		private Color _normalColour = Color.white;

		[SerializeField]
		private Color _selectedColour = Color.red;

		private bool _selected;

		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				_selected = value;
				_image.color = (value ? _selectedColour : _normalColour);
			}
		}

		public void UpdateFrom(Keyframe key, CurveEditorScript editor)
		{
			_editor = editor;
			if (_rectTransform == null)
			{
				_rectTransform = GetComponent<RectTransform>();
			}
			_rectTransform.anchoredPosition = editor.CurveToPixel(new Vector2(key.time, key.value));
			Selected = _selected;
		}

		private bool OnPointerClick(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left && !eventData.dragging)
			{
				_editor.KeyClicked(this);
				return true;
			}
			return false;
		}

		private bool OnDrag(PointerEventData eventData)
		{
			_rectTransform.position = eventData.position;
			_editor.KeyMoved(this, _rectTransform.localPosition);
			return true;
		}

		private void Awake()
		{
			_image = GetComponent<Image>();
			InputResponder inputResponder = new InputResponder("CurveKey");
			_inputHandler = base.gameObject.AddComponent<InputHandlerScript>();
			_inputHandler.AddInputResponder(inputResponder);
			inputResponder.OnDrag = OnDrag;
			inputResponder.OnPointerClick = OnPointerClick;
		}
	}
}
