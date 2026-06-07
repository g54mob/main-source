using System.Runtime.CompilerServices;
using FishNet.Connection;

namespace Assets.Scripts.Multiplayer.Extensions
{
	public static class NetworkConnectionExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static NetworkPlayerScript GetPlayer(this NetworkConnection connection)
		{
			return connection.CustomData as NetworkPlayerScript;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string GetPlayerName(this NetworkConnection connection)
		{
			return (connection.CustomData as NetworkPlayerScript)?.Name ?? string.Empty;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string GetPlayerNameAndId(this NetworkConnection connection)
		{
			return $"{(connection.CustomData as NetworkPlayerScript)?.Name ?? string.Empty} ({connection.ClientId})";
		}
	}
}
