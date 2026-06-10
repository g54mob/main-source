using UnityEngine.Networking;

namespace ModIO
{
	internal class ModIoWebRequest : IModIoWebRequest
	{
		public UnityWebRequest unityWebRequest;

		public bool isDone => false;

		public ulong downloadedBytes => 0uL;

		public float downloadProgress => 0f;

		public float uploadProgress => 0f;

		public ulong uploadedBytes => 0uL;

		public ModIoWebRequest(UnityWebRequest unityWebRequest)
		{
		}

		public string GetResponseHeader(string name)
		{
			return null;
		}
	}
}
