using System;

public class ActualDateTime : IGameDateTime
{
	public DateTime LocalNow => DateTime.Now;

	public DateTime LocalToday => DateTime.Today;

	public DateTime UtcNow => DateTime.UtcNow;

	public DateTime UtcToday => DateTime.UtcNow.Date;
}
