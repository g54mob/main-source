using UnityEngine;

public class AutoFadeColorManager
{
	public delegate void FadeDoneDelegate();

	private float _totalPreFadeTime;

	private float _currentPreFadeTime;

	private float _totalFadeTime;

	private float _currentFadeProgress;

	private Color _startColor;

	private Color _endColor = Color.black;

	private bool _fadeIsInProgress;

	public bool FadeIsInProgress
	{
		get
		{
			return _fadeIsInProgress;
		}
	}

	public event FadeDoneDelegate OnFadeDone;

	public void StartFade(Color startColor, Color endColor, float fadeTime)
	{
		StartFade(startColor, endColor, 0f, fadeTime);
	}

	public void StartFade(Color startColor, Color endColor, float preFadeTime, float fadeTime)
	{
		_startColor = startColor;
		_endColor = endColor;
		_totalPreFadeTime = preFadeTime;
		_totalFadeTime = fadeTime;
		_currentPreFadeTime = 0f;
		_currentFadeProgress = 0f;
		_fadeIsInProgress = true;
	}

	public void Cancel()
	{
		_fadeIsInProgress = false;
	}

	public Color Update(float timeElapsed)
	{
		Color black = Color.black;
		if (!_fadeIsInProgress)
		{
			return _endColor;
		}
		if (_currentPreFadeTime < _totalPreFadeTime)
		{
			black = _startColor;
			_currentPreFadeTime += timeElapsed;
		}
		else if (_currentFadeProgress < 1f)
		{
			_currentFadeProgress += timeElapsed / _totalFadeTime;
			black = Color.Lerp(_startColor, _endColor, _currentFadeProgress);
		}
		else
		{
			_fadeIsInProgress = false;
			black = _endColor;
			if (this.OnFadeDone != null)
			{
				this.OnFadeDone();
			}
		}
		return black;
	}
}
