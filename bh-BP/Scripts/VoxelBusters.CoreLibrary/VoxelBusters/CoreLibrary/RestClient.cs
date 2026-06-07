using System;
using UnityEngine.Networking;

namespace VoxelBusters.CoreLibrary
{
	internal class RestClient
	{
		[ClearOnReload]
		private static RestClient s_sharedInstance;

		public static RestClient SharedInstance => null;

		public static string EscapeUrl(string url)
		{
			return null;
		}

		public void StartWebRequest<TResult>(UnityWebRequest request, Action<TResult> onSuccess, Action<string> onError)
		{
		}

		public byte[] ConvertObjectToBytes<TData>(TData data)
		{
			return null;
		}
	}
}
