using System.Collections.Generic;

public static class DisabledInteractions
{
	public enum InteractionType
	{
		FloorPickup = 0,
		FloorDrop = 1,
		Build = 2
	}

	private static Dictionary<string, int> _disabledKeys;

	public static bool IsDisabled(InteractionType key)
	{
		return false;
	}

	public static void IncrementDisableRequest(InteractionType key)
	{
	}

	public static void DecrementDisableRequest(InteractionType key)
	{
	}

	public static bool IsDisabled(string key)
	{
		return false;
	}

	public static void IncrementDisableRequest(string key)
	{
	}

	public static void DecrementDisableRequest(string key)
	{
	}
}
