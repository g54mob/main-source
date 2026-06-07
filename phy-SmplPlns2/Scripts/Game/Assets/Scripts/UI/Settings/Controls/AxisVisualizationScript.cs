using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.UI.Settings.Controls
{
	public class AxisVisualizationScript : WidgetScript
	{
		private TextWidget _axisNameText;

		private Widget _calibratedZero;

		private Widget _deadZone;

		private Widget _gameInputArrow;

		private Widget _inputArrowsParent;

		private Widget _rawInputArrow;

		public string AxisName
		{
			get
			{
				return _axisNameText.Text;
			}
			set
			{
				_axisNameText.Text = value;
			}
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_axisNameText = widget.FindWidget<TextWidget>("axis-name");
			_deadZone = widget.FindWidget("dead-zone");
			_gameInputArrow = widget.FindWidget("input-game");
			_rawInputArrow = widget.FindWidget("input-raw");
			_calibratedZero = widget.FindWidget("calibrated-zero");
			_inputArrowsParent = _gameInputArrow.Parent;
		}

		public void SetCalibratedZero(float calibratedZero, float value)
		{
			Vector3 localPosition = _calibratedZero.Rect.localPosition;
			localPosition.x = calibratedZero * _inputArrowsParent.Rect.rect.width * 0.5f;
			_calibratedZero.Rect.localPosition = localPosition;
			Vector3 localPosition2 = _deadZone.Rect.localPosition;
			localPosition2.x = localPosition.x;
			_deadZone.Rect.localPosition = localPosition2;
		}

		public void SetDeadZone(float value)
		{
			_deadZone.Width = _deadZone.Parent.Rect.rect.width * value;
		}

		public void SetInputValues(float value, float rawValue)
		{
			Vector3 localPosition = _gameInputArrow.Rect.localPosition;
			localPosition.x = value * _inputArrowsParent.Rect.rect.width * 0.5f;
			_gameInputArrow.Rect.localPosition = localPosition;
			Vector3 localPosition2 = _rawInputArrow.Rect.localPosition;
			localPosition2.x = rawValue * _inputArrowsParent.Rect.rect.width * 0.5f;
			_rawInputArrow.Rect.localPosition = localPosition2;
		}
	}
}
