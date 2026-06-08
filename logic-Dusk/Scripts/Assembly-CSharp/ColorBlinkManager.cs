using UnityEngine;

public class ColorBlinkManager
{
	public delegate void BlinkDoneDelegate();

	public delegate void BlinkDoneWithSenderDelegate(object sender);

	private AutoFadeColorManager _fadeColorDown = new AutoFadeColorManager();

	private AutoFadeColorManager _fadeColorUp = new AutoFadeColorManager();

	private Color _startColor = Color.black;

	private Color _endColor = Color.black;

	private float _cycleTime;

	private int _totalCycles;

	private int _cyclesSoFar;

	private bool _endNextUpdate;

	private bool _isActive;

	private bool smooth = true;

	private float timerDiscrete;

	private Color currentDiscreteColor = Color.white;

	private bool discreteColorIsOn;

	public bool IsActive
	{
		get
		{
			return _isActive;
		}
	}

	public object tag { get; set; }

	public Color startColor
	{
		get
		{
			return _startColor;
		}
		set
		{
			_startColor = value;
		}
	}

	public Color endColor
	{
		get
		{
			return _endColor;
		}
		set
		{
			_endColor = value;
		}
	}

	public event BlinkDoneDelegate OnBlinkDone;

	public event BlinkDoneWithSenderDelegate OnBlinkDoneWithSender;

	public void Start(Color startColor, Color endColor, float cycleTime)
	{
		Start(startColor, endColor, cycleTime, true);
	}

	public void Start(Color startColor, Color endColor, float cycleTime, int numberOfCycles)
	{
		Start(startColor, endColor, cycleTime);
		_totalCycles = numberOfCycles;
	}

	public void Start(Color startColor, Color endColor, float cycleTime, bool smooth)
	{
		Start(startColor, endColor, cycleTime, 0, smooth);
	}

	public void Start(Color startColor, Color endColor, float cycleTime, int numberOfCycles, bool smooth)
	{
		_totalCycles = numberOfCycles;
		_fadeColorDown.Cancel();
		_fadeColorUp.Cancel();
		_startColor = startColor;
		_endColor = endColor;
		_cycleTime = cycleTime;
		if (smooth)
		{
			_fadeColorDown.OnFadeDone -= OnDoneFadingDown;
			_fadeColorDown.OnFadeDone += OnDoneFadingDown;
			_fadeColorUp.OnFadeDone -= OnDoneFadingUp;
			_fadeColorUp.OnFadeDone += OnDoneFadingUp;
			_fadeColorUp.Cancel();
			_fadeColorDown.StartFade(startColor, endColor, cycleTime / 2f);
		}
		else
		{
			timerDiscrete = cycleTime;
			currentDiscreteColor = _startColor;
		}
		this.smooth = smooth;
		_cyclesSoFar = 0;
		_endNextUpdate = false;
		_isActive = true;
	}

	public void Stop()
	{
		_isActive = false;
		_fadeColorDown.Cancel();
		_fadeColorUp.Cancel();
		if (this.OnBlinkDone != null)
		{
			this.OnBlinkDone();
		}
		if (this.OnBlinkDoneWithSender != null)
		{
			this.OnBlinkDoneWithSender(this);
		}
	}

	public Color Update(float timeElapsed)
	{
		Color color = Color.white;
		Update(timeElapsed, out color);
		return color;
	}

	public bool Update(float timeElapsed, out Color color)
	{
		color = Color.white;
		if (!_isActive)
		{
			color = _endColor;
		}
		if (_endNextUpdate)
		{
			Stop();
			color = _startColor;
		}
		if (smooth)
		{
			if (_fadeColorDown.FadeIsInProgress)
			{
				color = _fadeColorDown.Update(timeElapsed);
			}
			else if (_fadeColorUp.FadeIsInProgress)
			{
				color = _fadeColorUp.Update(timeElapsed);
			}
			return false;
		}
		timerDiscrete -= Time.deltaTime;
		if (timerDiscrete <= 0f)
		{
			timerDiscrete = _cycleTime;
			if (_totalCycles > 0 && ++_cyclesSoFar >= _totalCycles)
			{
				_endNextUpdate = true;
			}
			discreteColorIsOn = !discreteColorIsOn;
			if (discreteColorIsOn)
			{
				currentDiscreteColor = _endColor;
			}
			else
			{
				currentDiscreteColor = _startColor;
			}
		}
		color = currentDiscreteColor;
		return discreteColorIsOn;
	}

	private void OnDoneFadingDown()
	{
		if (_isActive)
		{
			_fadeColorUp.StartFade(_endColor, _startColor, _cycleTime);
		}
	}

	private void OnDoneFadingUp()
	{
		if (_totalCycles > 0 && ++_cyclesSoFar >= _totalCycles)
		{
			_endNextUpdate = true;
		}
		if (_isActive)
		{
			_fadeColorDown.StartFade(_startColor, _endColor, _cycleTime);
		}
	}
}
