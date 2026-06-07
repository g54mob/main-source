using UnityEngine.Networking;

namespace Cysharp.Threading.Tasks.Internal
{
	internal static class UnityWebRequestResultExtensions
	{
		public static bool IsError(this UnityWebRequest unityWebRequest)
		{
			if (!unityWebRequest.isHttpError)
			{
				return unityWebRequest.isNetworkError;
			}
			return true;
		}
	}
}
