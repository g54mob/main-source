using System.IO;
using UnityEngine.Networking;

namespace NSEipix.FileReader
{
	public class AndroidFileReader : DefaultFileReader
	{
		public override string ReadFromStreamingAssets(string fileName)
		{
			using UnityWebRequest unityWebRequest = new UnityWebRequest(Path.Combine(GetStreamingAssetsPath(), fileName));
			UnityWebRequestAsyncOperation unityWebRequestAsyncOperation = unityWebRequest.SendWebRequest();
			while (!unityWebRequestAsyncOperation.isDone)
			{
			}
			return string.IsNullOrEmpty(unityWebRequest.error) ? unityWebRequest.downloadHandler.text : string.Empty;
		}
	}
}
