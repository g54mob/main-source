using UnityEngine;

namespace RLD
{
	public class ColorTransition
	{
		public enum State
		{
			CompleteFadeIn = 0,
			CompleteFadeOut = 1,
			FadingIn = 2,
			FadingOut = 3,
			Ready = 4
		}

		public delegate void ColorTransitionBeginHandler(ColorTransition colorTransition);

		public delegate void ColorTransitionEndHandler(ColorTransition colorTransition);

		private ColorRef _colorRef;

		private Color _fadeInColor;

		private Color _fadeOutColor;

		private State _state = State.Ready;

		private float _durationInSeconds;

		private float _elapsedTimeInSeconds;

		private bool _isActive;

		public State TransitionState => _state;

		public Color FadeInColor
		{
			get
			{
				return _fadeInColor;
			}
			set
			{
				_fadeInColor = value;
			}
		}

		public Color FadeOutColor
		{
			get
			{
				return _fadeOutColor;
			}
			set
			{
				_fadeOutColor = value;
			}
		}

		public float DurationInSeconds
		{
			get
			{
				return _durationInSeconds;
			}
			set
			{
				_durationInSeconds = Mathf.Max(value, 0f);
			}
		}

		public bool IsActive => _isActive;

		public event ColorTransitionBeginHandler TransitionBegin;

		public event ColorTransitionEndHandler TransitionEnd;

		public ColorTransition(ColorRef colorRef)
		{
			_colorRef = colorRef;
			_fadeInColor = colorRef.Value;
			_fadeOutColor = colorRef.Value;
		}

		public void BeginFadeIn(bool startFromCurrentColor)
		{
			if (startFromCurrentColor)
			{
				FadeOutColor = _colorRef.Value;
			}
			_state = State.FadingIn;
			_isActive = true;
			_elapsedTimeInSeconds = 0f;
			if (this.TransitionBegin != null)
			{
				this.TransitionBegin(this);
			}
		}

		public void BeginFadeOut(bool startFromCurrentColor)
		{
			if (startFromCurrentColor)
			{
				FadeInColor = _colorRef.Value;
			}
			_state = State.FadingOut;
			_isActive = true;
			_elapsedTimeInSeconds = 0f;
			if (this.TransitionBegin != null)
			{
				this.TransitionBegin(this);
			}
		}

		public void Update(float elapsedTime)
		{
			if (_isActive)
			{
				Color a = _fadeOutColor;
				Color color = _fadeInColor;
				if (_state == State.FadingOut)
				{
					a = _fadeInColor;
					color = _fadeOutColor;
				}
				_elapsedTimeInSeconds += elapsedTime;
				_elapsedTimeInSeconds = Mathf.Clamp(_elapsedTimeInSeconds, 0f, _durationInSeconds);
				float num = _elapsedTimeInSeconds / _durationInSeconds;
				if (MathEx.AlmostEqual(num, 1f, 0.0001f))
				{
					_colorRef.Value = color;
					End();
				}
				else
				{
					_colorRef.Value = Color.Lerp(a, color, num);
				}
			}
		}

		private void End()
		{
			if (_isActive)
			{
				_isActive = false;
				if (_state == State.FadingOut)
				{
					_state = State.CompleteFadeOut;
				}
				else if (_state == State.FadingIn)
				{
					_state = State.CompleteFadeIn;
				}
				if (this.TransitionEnd != null)
				{
					this.TransitionEnd(this);
				}
			}
		}
	}
}
