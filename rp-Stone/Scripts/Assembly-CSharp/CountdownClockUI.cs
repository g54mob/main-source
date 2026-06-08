using System;
using UnityEngine;

public class CountdownClockUI : AsciiObject
{
	public AsciiSprite clockSprite;

	public AsciiString timeRemainingLabel;

	public bool morePrecision;

	public int timeRunOutMinutes = 1440;

	public Color timeRunOutLabelColor = ColorConstants.midRed;

	public Color timeRunOutSpriteTint = ColorConstants.red;

	private Color defaultColor;

	private DateTime expirationTime;

	private int elapsedTics;

	private long _lastSecondsRemaining = -1L;

	private bool isTimeRunningOut;

	public bool hasExpired { get; private set; }

	public void Setup(DateTime expirationTime)
	{
		this.expirationTime = expirationTime;
		elapsedTics = 0;
		_lastSecondsRemaining = -1L;
		UpdateContent();
	}

	private void UpdateContent()
	{
		long secondsRemaining = GetSecondsRemaining();
		if (_lastSecondsRemaining != secondsRemaining)
		{
			_lastSecondsRemaining = secondsRemaining;
			isTimeRunningOut = secondsRemaining < timeRunOutMinutes * 60;
			if (isTimeRunningOut)
			{
				timeRemainingLabel.color = timeRunOutLabelColor;
			}
			else
			{
				timeRemainingLabel.color = defaultColor;
			}
			if (secondsRemaining <= 0)
			{
				timeRemainingLabel.SetValue(Utils.FormatTimeCasual(0L));
				hasExpired = true;
			}
			else
			{
				timeRemainingLabel.SetValue(Utils.FormatTimeCasual(secondsRemaining, morePrecision));
				hasExpired = false;
			}
		}
	}

	private long GetSecondsRemaining()
	{
		return (long)(expirationTime - DateTime.Now).TotalSeconds;
	}

	public override void UpdateTic()
	{
		if (++elapsedTics == 15)
		{
			elapsedTics = 0;
			UpdateContent();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetX += PositionX;
		offsetY += PositionY;
		if (clockSprite != null)
		{
			if (isTimeRunningOut)
			{
				clockSprite.Draw(r, offsetX, offsetY, 1f, timeRunOutSpriteTint);
			}
			else
			{
				clockSprite.Draw(r, offsetX, offsetY);
			}
		}
		timeRemainingLabel.Draw(r, offsetX, offsetY);
	}

	private void Awake()
	{
		defaultColor = timeRemainingLabel.color;
	}
}
