using System;

public class AdjustableGameDateTime : IGameDateTime
{
	private DateTime? _frozenUtcNow;

	private TimeZoneInfo _localTimeZoneInfo = TimeZoneInfo.Local;

	public TimeSpan UtcOffset { get; set; }

	public DateTime LocalNow => TimeZoneInfo.ConvertTimeFromUtc(UtcNow, _localTimeZoneInfo);

	public DateTime LocalToday => LocalNow.Date;

	public DateTime UtcNow => _frozenUtcNow ?? (DateTime.UtcNow + UtcOffset);

	public DateTime UtcToday => UtcNow.Date;

	public void SetUtcNow(DateTime newUtcNow)
	{
		if (_frozenUtcNow.HasValue)
		{
			_frozenUtcNow = newUtcNow;
		}
		else
		{
			UtcOffset += newUtcNow - UtcNow;
		}
	}

	public void UseActualUtcNow()
	{
		UtcOffset = TimeSpan.Zero;
	}

	public void SetLocalTimeZoneInfo(TimeZoneInfo timeZoneInfo)
	{
		_localTimeZoneInfo = timeZoneInfo;
	}

	public void Freeze()
	{
		_frozenUtcNow = UtcNow;
	}

	public void Unfreeze()
	{
		_frozenUtcNow = null;
	}
}
