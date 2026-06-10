using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;

namespace Cysharp.Threading.Tasks
{
	public class UnityWebRequestException : Exception
	{
		[CompilerGenerated]
		private readonly UnityWebRequest.Result _003CResult_003Ek__BackingField;

		[CompilerGenerated]
		private readonly long _003CResponseCode_003Ek__BackingField;

		[CompilerGenerated]
		private readonly Dictionary<string, string> _003CResponseHeaders_003Ek__BackingField;

		private string msg;

		public UnityWebRequest UnityWebRequest { get; }

		public string Error { get; }

		public string Text { get; }

		public override string Message => null;

		public UnityWebRequestException(UnityWebRequest unityWebRequest)
		{
		}
	}
}
