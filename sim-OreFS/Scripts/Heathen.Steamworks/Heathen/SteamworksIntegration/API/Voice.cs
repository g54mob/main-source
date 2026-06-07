using Steamworks;

namespace Heathen.SteamworksIntegration.API
{
	public static class Voice
	{
		public static class Client
		{
			public static uint OptimalSampleRate => SteamUser.GetVoiceOptimalSampleRate();

			public static EVoiceResult DecompressVoice(byte[] compressedData, byte[] resultBuffer, out uint resultsWrittenSize, uint desiredSampleRate)
			{
				return SteamUser.DecompressVoice(compressedData, (uint)compressedData.Length, resultBuffer, (uint)resultBuffer.Length, out resultsWrittenSize, desiredSampleRate);
			}

			public static EVoiceResult GetAvailableVoice(out uint pcbCompressed)
			{
				return SteamUser.GetAvailableVoice(out pcbCompressed);
			}

			public static EVoiceResult GetVoice(byte[] pDestBuffer, out uint nBytesWritten)
			{
				return SteamUser.GetVoice(bWantCompressed: true, pDestBuffer, (uint)pDestBuffer.Length, out nBytesWritten);
			}

			public static void StartRecording()
			{
				SteamUser.StartVoiceRecording();
			}

			public static void StopRecording()
			{
				SteamUser.StopVoiceRecording();
			}
		}
	}
}
