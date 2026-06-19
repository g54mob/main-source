using System.Runtime.CompilerServices;
using Unity.NetCode;

public static class NetworkTickExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsSameOrNewerThan(this NetworkTick ourTick, NetworkTick otherTick)
	{
		return !otherTick.IsNewerThan(ourTick);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsOlderThan(this NetworkTick ourTick, NetworkTick otherTick)
	{
		return otherTick.IsNewerThan(ourTick);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsSameOrOlderThan(this NetworkTick ourTick, NetworkTick otherTick)
	{
		return !ourTick.IsNewerThan(otherTick);
	}
}
