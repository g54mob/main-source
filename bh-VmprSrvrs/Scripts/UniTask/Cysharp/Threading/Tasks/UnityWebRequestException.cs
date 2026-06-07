using System;
using System.Collections.Generic;
using UnityEngine.Networking;

namespace Cysharp.Threading.Tasks
{
	public class UnityWebRequestException : Exception
	{
		private string msg;

		public UnityWebRequest UnityWebRequest { get; }

		public UnityWebRequest.Result Result { get; }

		public string Error { get; }

		public string Text { get; }

		public long ResponseCode { get; }

		public Dictionary<string, string> ResponseHeaders { get; }

		public override string Message => null;

		public UnityWebRequestException(UnityWebRequest unityWebRequest)
		{
		}
	}
}
