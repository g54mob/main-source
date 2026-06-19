using UnityEngine.Networking;

namespace ModIO
{
	internal class ModIoWebRequest : IModIoWebRequest
	{
		public UnityWebRequest unityWebRequest;

		public bool isDone => unityWebRequest.isDone;

		public ulong downloadedBytes => unityWebRequest.downloadedBytes;

		public float downloadProgress => unityWebRequest.downloadProgress;

		public float uploadProgress => unityWebRequest.uploadProgress;

		public ulong uploadedBytes => unityWebRequest.uploadedBytes;

		public ModIoWebRequest(UnityWebRequest unityWebRequest)
		{
			this.unityWebRequest = unityWebRequest;
		}

		public string GetResponseHeader(string name)
		{
			return unityWebRequest.GetResponseHeader(name);
		}
	}
}
