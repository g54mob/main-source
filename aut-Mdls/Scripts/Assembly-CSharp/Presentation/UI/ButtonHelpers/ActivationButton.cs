using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Presentation.UI.ButtonHelpers
{
	public abstract class ActivationButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private int _ID;

		[SerializeField]
		private Button _button;

		private bool _active;

		private bool _hover;

		public Action<int> OnClick = delegate
		{
		};

		public Button Button => _button;

		public int ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}

		public bool ActiveState
		{
			get
			{
				return _active;
			}
			set
			{
				_active = value;
				SetActive(_active);
			}
		}

		protected bool HoverState
		{
			get
			{
				return _hover;
			}
			set
			{
				_hover = value;
				SetHover(_hover);
			}
		}

		protected virtual void Awake()
		{
			_button.onClick.AddListener(OnButtonClick);
		}

		protected virtual void OnDestroy()
		{
			_button.onClick.RemoveListener(OnButtonClick);
			ActiveState = false;
			HoverState = false;
		}

		protected abstract void SetActive(bool active);

		protected abstract void SetHover(bool hover);

		private void OnDisable()
		{
			ActiveState = false;
			HoverState = false;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			HoverState = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			HoverState = false;
		}

		protected virtual void OnButtonClick()
		{
			ActiveState = true;
			OnClick(_ID);
		}
	}
}
