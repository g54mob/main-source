using System;
using System.Collections.Generic;
using UnityEngine.Networking;

namespace Cysharp.Threading.Tasks;

public class UnityWebRequestException : Exception
{
	private readonly UnityWebRequest _003CUnityWebRequest_003Ek__BackingField;

	private readonly UnityWebRequest.Result _003CResult_003Ek__BackingField;

	private readonly string _003CError_003Ek__BackingField;

	private readonly string _003CText_003Ek__BackingField;

	private readonly long _003CResponseCode_003Ek__BackingField;

	private readonly Dictionary<string, string> _003CResponseHeaders_003Ek__BackingField;

	private string msg;

	public UnityWebRequest UnityWebRequest => _003CUnityWebRequest_003Ek__BackingField;

	public UnityWebRequest.Result Result => _003CResult_003Ek__BackingField;

	public string Error => _003CError_003Ek__BackingField;

	public string Text => _003CText_003Ek__BackingField;

	public long ResponseCode => _003CResponseCode_003Ek__BackingField;

	public Dictionary<string, string> ResponseHeaders => _003CResponseHeaders_003Ek__BackingField;

	public override string Message
	{
		get
		{
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Expected O, but got Unknown
			//IL_0064: Expected O, but got I4
			//IL_009b: Expected I4, but got O
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Expected O, but got Unknown
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Expected O, but got Unknown
			if (msg == null)
			{
				string text = _003CText_003Ek__BackingField;
				string text2;
				if (_003CText_003Ek__BackingField != null)
				{
					object obj = _003CText_003Ek__BackingField + 20;
					object obj2 = 0;
					string result = default(string);
					while ((nint)obj2 < text._stringLength)
					{
						if ((nint)obj2 < text._stringLength)
						{
							if (char.IsWhiteSpace((char)(int)obj))
							{
								obj2++;
								obj += 2;
								continue;
							}
							goto IL_00d9;
						}
						System.ThrowHelper.ThrowIndexOutOfRangeException();
						return result;
					}
					text2 = _003CError_003Ek__BackingField;
				}
				else
				{
					text2 = _003CError_003Ek__BackingField;
				}
				msg = text2;
			}
			goto IL_012d;
			IL_012d:
			return msg;
			IL_00d9:
			string newLine = Environment.NewLine;
			string text3 = _003CError_003Ek__BackingField + newLine + _003CText_003Ek__BackingField;
			msg = text3;
			goto IL_012d;
		}
	}

	public UnityWebRequestException(UnityWebRequest unityWebRequest)
	{
		Init();
		_003CUnityWebRequest_003Ek__BackingField = unityWebRequest;
		bool flag = unityWebRequest.m_Ptr == (IntPtr)0;
		UnityWebRequest.Result result = UnityWebRequest.get_result_Injected(unityWebRequest.m_Ptr);
		_003CResult_003Ek__BackingField = result;
		string error = unityWebRequest.error;
		_003CError_003Ek__BackingField = error;
		bool flag2 = unityWebRequest.m_Ptr == (IntPtr)0;
		long num = UnityWebRequest.get_responseCode_Injected(unityWebRequest.m_Ptr);
		_003CResponseCode_003Ek__BackingField = num;
		UnityWebRequest unityWebRequest2 = _003CUnityWebRequest_003Ek__BackingField;
		if (unityWebRequest2.m_DownloadHandler != null)
		{
			DownloadHandler downloadHandler = unityWebRequest.m_DownloadHandler;
			if (unityWebRequest.m_DownloadHandler != null)
			{
				bool flag3 = (object)downloadHandler.GetType() != typeof(DownloadHandlerBuffer);
				DownloadHandler downloadHandler2 = null;
				if (!flag3)
				{
					downloadHandler2 = unityWebRequest.m_DownloadHandler;
				}
				if (downloadHandler2 != null)
				{
					string text = downloadHandler2.GetText();
					_003CText_003Ek__BackingField = text;
				}
			}
		}
		Dictionary<string, string> responseHeaders = unityWebRequest.GetResponseHeaders();
		_003CResponseHeaders_003Ek__BackingField = responseHeaders;
	}
}
