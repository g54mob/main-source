using UnityEngine.EventSystems;

namespace Assets.Scripts.UI.CurveEditor
{
	public class InputResponder : IInputResponder
	{
		private static InputResponderDelegates.IsRespondingDelegate _defaultIsResponding = () => true;

		private static InputResponderDelegates.InputPinchResponderDelegate _defaultPinchResponder = (PinchEventData x) => false;

		private static InputResponderDelegates.InputResponderDelegate _defaultPointerResponder = (PointerEventData x) => false;

		private static InputResponderDelegates.InputSelectionResponderDelegate _defaultSelectionResponder = (BaseEventData x) => false;

		private InputResponderDelegates.IsRespondingDelegate _isRespondingToInputs = _defaultIsResponding;

		private InputResponderDelegates.InputResponderDelegate _onBeginDrag = _defaultPointerResponder;

		private InputResponderDelegates.InputPinchResponderDelegate _onBeginPinch = _defaultPinchResponder;

		private InputResponderDelegates.InputSelectionResponderDelegate _onDeselect = _defaultSelectionResponder;

		private InputResponderDelegates.InputResponderDelegate _onDrag = _defaultPointerResponder;

		private InputResponderDelegates.InputResponderDelegate _onDrop = _defaultPointerResponder;

		private InputResponderDelegates.InputResponderDelegate _onEndDrag = _defaultPointerResponder;

		private InputResponderDelegates.InputPinchResponderDelegate _onEndPinch = _defaultPinchResponder;

		private InputResponderDelegates.InputResponderDelegate _onInitializePotentialDrag = _defaultPointerResponder;

		private InputResponderDelegates.InputPinchResponderDelegate _onPinch = _defaultPinchResponder;

		private InputResponderDelegates.InputResponderDelegate _onPointerClick = _defaultPointerResponder;

		private InputResponderDelegates.InputResponderDelegate _onPointerDown = _defaultPointerResponder;

		private InputResponderDelegates.InputResponderDelegate _onPointerUp = _defaultPointerResponder;

		private InputResponderDelegates.InputResponderDelegate _onScroll = _defaultPointerResponder;

		private InputResponderDelegates.InputSelectionResponderDelegate _onSelect = _defaultSelectionResponder;

		public InputResponderDelegates.IsRespondingDelegate IsResponding
		{
			get
			{
				return _isRespondingToInputs;
			}
			set
			{
				_isRespondingToInputs = value ?? _defaultIsResponding;
			}
		}

		public string Name { get; }

		public InputResponderDelegates.InputResponderDelegate OnBeginDrag
		{
			get
			{
				return _onBeginDrag;
			}
			set
			{
				_onBeginDrag = value ?? _defaultPointerResponder;
			}
		}

		public InputResponderDelegates.InputPinchResponderDelegate OnBeginPinch
		{
			get
			{
				return _onBeginPinch;
			}
			set
			{
				_onBeginPinch = value ?? _defaultPinchResponder;
			}
		}

		public InputResponderDelegates.InputSelectionResponderDelegate OnDeselect
		{
			get
			{
				return _onDeselect;
			}
			set
			{
				_onDeselect = value ?? _defaultSelectionResponder;
			}
		}

		public InputResponderDelegates.InputResponderDelegate OnDrag
		{
			get
			{
				return _onDrag;
			}
			set
			{
				_onDrag = value ?? _defaultPointerResponder;
			}
		}

		public InputResponderDelegates.InputResponderDelegate OnDrop
		{
			get
			{
				return _onDrop;
			}
			set
			{
				_onDrop = value ?? _defaultPointerResponder;
			}
		}

		public InputResponderDelegates.InputResponderDelegate OnEndDrag
		{
			get
			{
				return _onEndDrag;
			}
			set
			{
				_onEndDrag = value ?? _defaultPointerResponder;
			}
		}

		public InputResponderDelegates.InputPinchResponderDelegate OnEndPinch
		{
			get
			{
				return _onEndPinch;
			}
			set
			{
				_onEndPinch = value ?? _defaultPinchResponder;
			}
		}

		public InputResponderDelegates.InputResponderDelegate OnInitializePotentialDrag
		{
			get
			{
				return _onInitializePotentialDrag;
			}
			set
			{
				_onInitializePotentialDrag = value ?? _defaultPointerResponder;
			}
		}

		public InputResponderDelegates.InputPinchResponderDelegate OnPinch
		{
			get
			{
				return _onPinch;
			}
			set
			{
				_onPinch = value ?? _defaultPinchResponder;
			}
		}

		public InputResponderDelegates.InputResponderDelegate OnPointerClick
		{
			get
			{
				return _onPointerClick;
			}
			set
			{
				_onPointerClick = value ?? _defaultPointerResponder;
			}
		}

		public InputResponderDelegates.InputResponderDelegate OnPointerDown
		{
			get
			{
				return _onPointerDown;
			}
			set
			{
				_onPointerDown = value ?? _defaultPointerResponder;
			}
		}

		public InputResponderDelegates.InputResponderDelegate OnPointerUp
		{
			get
			{
				return _onPointerUp;
			}
			set
			{
				_onPointerUp = value ?? _defaultPointerResponder;
			}
		}

		public InputResponderDelegates.InputResponderDelegate OnScroll
		{
			get
			{
				return _onScroll;
			}
			set
			{
				_onScroll = value ?? _defaultPointerResponder;
			}
		}

		public InputResponderDelegates.InputSelectionResponderDelegate OnSelect
		{
			get
			{
				return _onSelect;
			}
			set
			{
				_onSelect = value ?? _defaultSelectionResponder;
			}
		}

		public int Priority { get; set; }

		public InputResponder(string name)
		{
			Name = name;
		}
	}
}
