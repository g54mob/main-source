using UnityEngine;
using UnityEngine.Networking;

namespace AeLa.EasyFeedback.Web
{
	internal readonly struct AsyncWebRequestData
	{
		public UnityWebRequest Request { get; }

		public AsyncOperation Operation { get; }

		public bool OperationIsDone => false;

		public bool RequestIsError => false;

		public string ErrorText => null;

		public AsyncWebRequestData(UnityWebRequest request, AsyncOperation operation)
		{
			Request = null;
			Operation = null;
		}
	}
}
