using Pug.UnityExtensions;
using Rewired;
using UnityEngine;

public class ControlMapper_CalibrationPreview : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private Transform _rawAxisValueIndicator;

	[SerializeField]
	private Transform _calibratedValueIndicator;

	[SerializeField]
	private SpriteRenderer _deadZoneIndicator;

	[SerializeField]
	private Transform _zeroIndicator;

	[SerializeField]
	private PugText _rangeMinimumLabel;

	[SerializeField]
	private PugText _rangeZeroLabel;

	[SerializeField]
	private PugText _rangeMaximumLabel;

	[SerializeField]
	private SpriteRenderer _previewBackground;

	[Header("Display configuration")]
	[SerializeField]
	private float _previewAreaWidth = 10f;

	[SerializeField]
	private bool _showCalibratedValueIndicator = true;

	[SerializeField]
	private bool _showRawValueIndicator = true;

	[SerializeField]
	private bool _showDeadZone = true;

	[SerializeField]
	private bool _showZero = true;

	[SerializeField]
	private bool _showRangeLabels = true;

	private Joystick _activeJoystick;

	private int _axisIndex;

	private void Awake()
	{
		_previewBackground.size = new Vector2(_previewAreaWidth, _previewBackground.size.y);
		_rawAxisValueIndicator.gameObject.SetActive(_showRawValueIndicator);
		_calibratedValueIndicator.gameObject.SetActive(_showCalibratedValueIndicator);
		_deadZoneIndicator.GetComponentInChildren<SpriteRenderer>().enabled = _showDeadZone;
		_zeroIndicator.GetComponentInChildren<SpriteRenderer>().enabled = _showZero;
		_rangeMinimumLabel.gameObject.SetActive(_showRangeLabels);
		_rangeZeroLabel.gameObject.SetActive(_showRangeLabels);
		_rangeMaximumLabel.gameObject.SetActive(_showRangeLabels);
		_rangeMinimumLabel.transform.SetLocalPositionX(_previewAreaWidth * -0.5f);
		_rangeMaximumLabel.transform.SetLocalPositionX(_previewAreaWidth * 0.5f);
	}

	private void Update()
	{
		if (_activeJoystick != null)
		{
			UpdateIndicatorPosition(_rawAxisValueIndicator, _activeJoystick.GetAxisRaw(_axisIndex));
			UpdateIndicatorPosition(_calibratedValueIndicator, _activeJoystick.GetAxis(_axisIndex));
		}
	}

	public void Setup(Joystick activeJoystick, int axisIndex)
	{
		_activeJoystick = activeJoystick;
		_axisIndex = axisIndex;
	}

	public void UpdatePreview(AxisCalibrationData axisCalibrationData)
	{
		float zero = axisCalibrationData.zero;
		UpdateIndicatorPosition(_zeroIndicator, zero);
		Vector2 size = _deadZoneIndicator.size;
		_deadZoneIndicator.size = new Vector2(axisCalibrationData.deadZone * _previewAreaWidth, size.y);
	}

	private void UpdateIndicatorPosition(Transform indicator, float position)
	{
		position *= _previewAreaWidth / 2f;
		Vector3 localPosition = indicator.localPosition;
		localPosition = new Vector3(position, localPosition.y, localPosition.z);
		indicator.localPosition = localPosition;
	}
}
