using PajamaLlama.Math;
using UnityEngine;

public class CircadianRotation : SceneBehaviour
{
	[Tooltip("A normalized offset to account for a game day not starting at midnight.")]
	[SerializeField]
	private float _timeOffset = 0.1f;

	[Header("Rotation")]
	[SerializeField]
	private AnimationCurve _xAngleRotation;

	[SerializeField]
	private AnimationCurve _yAngleRotation;

	[SerializeField]
	private AnimationCurve _zAngleRotation;

	[Header("Elevation")]
	[SerializeField]
	private bool _elevated;

	[SerializeField]
	[ConditionalHide("_elevated")]
	private float _lowestElevation = -10f;

	[SerializeField]
	[ConditionalHide("_elevated")]
	private float _highestElevation = 30f;

	[SerializeField]
	[ConditionalHide("_elevated")]
	private AnimationCurve _elevationCurve;

	private float _progress;

	private float _xAngle;

	private float _yAngle;

	private float _zAngle;

	private Vector3 _rotation = Vector3.zero;

	private float _elevation;

	private void Update()
	{
		if (!(GameManager.TimeManager == null) && GameManager.TimeManager.Initialized)
		{
			_progress = GameManager.TimeManager.CurrentDay.NormalizedDayProgress + _timeOffset;
			_xAngle = _xAngleRotation.Evaluate(GameManager.TimeManager.CurrentDay.NormalizedDayProgress);
			_yAngle = _yAngleRotation.Evaluate(GameManager.TimeManager.CurrentDay.NormalizedDayProgress);
			_zAngle = _zAngleRotation.Evaluate(GameManager.TimeManager.CurrentDay.NormalizedDayProgress);
			_rotation = new Vector3(_xAngle, _yAngle, _zAngle);
			base.transform.rotation = Quaternion.Euler(_rotation);
			if (_elevated)
			{
				_elevation = Mathf.Lerp(_lowestElevation, _highestElevation, _elevationCurve.Evaluate(_progress));
				base.transform.localPosition = base.transform.localPosition.SetY(_elevation);
			}
		}
	}
}
