using Rewired.UI;
using UnityEngine;

namespace PajamaLlama
{
	public class MouseButton
	{
		public const float CLICK_INTERVAL = 0.15f;

		public const float DOUBLE_CLICK_INTERVAL = 0.3f;

		private float _now;

		private float _buttonDownTimestamp;

		private float _buttonUpTimestamp;

		private float _buttonClickTimestamp;

		private IMouseInputSource _inputSource;

		public int Index { get; private set; }

		public string Name { get; private set; }

		public bool Down { get; private set; }

		public bool Hold { get; private set; }

		public bool Up { get; private set; }

		public bool Click { get; private set; }

		public bool DoubleClick { get; private set; }

		public float HoldTime
		{
			get
			{
				if (!Hold)
				{
					return 0f;
				}
				return _now - _buttonDownTimestamp;
			}
		}

		public float HeldTime
		{
			get
			{
				if (!Up)
				{
					return 0f;
				}
				return _buttonUpTimestamp - _buttonDownTimestamp;
			}
		}

		public MouseButton(int index, string name)
		{
			Index = index;
			Name = name;
		}

		public void LateUpdate()
		{
			_now = Time.realtimeSinceStartup;
			Down = ((_inputSource == null) ? Input.GetMouseButtonDown(Index) : _inputSource.GetButtonDown(Index));
			Hold = ((_inputSource == null) ? Input.GetMouseButton(Index) : _inputSource.GetButton(Index));
			Up = ((_inputSource == null) ? Input.GetMouseButtonUp(Index) : _inputSource.GetButtonUp(Index));
			Click = false;
			DoubleClick = false;
			if (Down)
			{
				_buttonDownTimestamp = _now;
			}
			else if (Up)
			{
				OnMouseButtonUp();
			}
		}

		public void SetInputSource(IMouseInputSource inputSource)
		{
			_inputSource = inputSource;
		}

		public void ClearInputSource()
		{
			_inputSource = null;
		}

		private void OnMouseButtonUp()
		{
			if (_now - _buttonDownTimestamp <= 0.15f)
			{
				if (_now - _buttonClickTimestamp <= 0.3f)
				{
					DoubleClick = true;
				}
				else
				{
					Click = true;
					_buttonClickTimestamp = _now;
				}
			}
			_buttonUpTimestamp = _now;
		}
	}
}
