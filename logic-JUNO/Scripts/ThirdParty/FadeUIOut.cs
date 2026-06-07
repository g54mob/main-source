using UnityEngine;

public class FadeUIOut : MonoBehaviour
{
	public AnimationCurve _amcFadeOutCurve;

	public float _fFadeOutTime;

	public float _fTimeOfLastMouseOver;

	public float _fBaseAlpha;

	public float _fFadeOutAlpha;

	public CanvasGroup _canTargetUI;

	public bool _bMouseOver;

	private void Start()
	{
		_fTimeOfLastMouseOver = 0f;
	}

	public void MouseEnter()
	{
		_bMouseOver = true;
	}

	public void MouseExit()
	{
		_bMouseOver = false;
	}

	public void Update()
	{
		if (_bMouseOver)
		{
			_fTimeOfLastMouseOver = Time.timeSinceLevelLoad;
		}
		float time = Mathf.Clamp01((Time.timeSinceLevelLoad - _fTimeOfLastMouseOver) / _fFadeOutTime);
		float t = _amcFadeOutCurve.Evaluate(time);
		float alpha = Mathf.Lerp(_fFadeOutAlpha, _fBaseAlpha, t);
		_canTargetUI.alpha = alpha;
	}
}
