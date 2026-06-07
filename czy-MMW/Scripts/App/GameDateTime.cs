using System;

public static class GameDateTime
{
	public static IGameDateTime Backend { get; set; } = new ActualDateTime();

	public static DateTime LocalNow => Backend.LocalNow;

	public static DateTime UtcNow => Backend.UtcNow;

	public static DateTime LocalToday => Backend.LocalToday;

	public static DateTime UtcToday => Backend.UtcToday;
}
