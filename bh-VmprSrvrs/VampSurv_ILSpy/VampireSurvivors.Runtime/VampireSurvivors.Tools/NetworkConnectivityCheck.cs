using System;
using System.Globalization;
using System.Net;
using Cpp2ILInjected;

namespace VampireSurvivors.Tools;

public static class NetworkConnectivityCheck
{
	public static bool IsConnected(int timeoutMs = 10000, string url = null)
	{
		//IL_02c5: Expected I, but got O
		//IL_0111: Expected I, but got O
		//IL_0303: Expected I4, but got O
		//IL_0136: Expected I, but got O
		//IL_0146: Expected O, but got I
		//IL_0182: Expected O, but got I
		//IL_01cf: Expected I, but got O
		//IL_01dd: Expected I, but got O
		//IL_0202: Expected O, but got I
		//IL_0212: Expected O, but got I
		//IL_024e: Expected O, but got I
		bool flag = url != null;
		string text = url;
		if (!flag)
		{
			CultureInfo cultureInfo = CultureInfo.ConstructCurrentCulture();
			if (cultureInfo == null)
			{
				goto IL_00c6;
			}
			string name = cultureInfo.Name;
			if (name == null)
			{
				throw new NullReferenceException();
			}
			if (!name.StartsWith("fa"))
			{
				if (!name.StartsWith("zh"))
				{
					goto IL_00c6;
				}
				text = "http://www.baidu.com";
			}
			else
			{
				text = "http://www.aparat.com";
			}
		}
		goto IL_0335;
		IL_027b:
		nint num;
		if (num != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
		}
		return true;
		IL_0335:
		if (text != null)
		{
			Uri requestUri = new Uri(text);
			WebRequest webRequest = WebRequest.Create(requestUri, false);
			nint num2 = (nint)typeof(HttpWebRequest);
			if (webRequest != null)
			{
				nint num3 = (nint)webRequest;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rdx_v6 (Il2CppClass<System.Net.HttpWebRequest>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v376 @ r8_v5 (Il2CppClass<System.Net.WebRequest>)+130]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rdx_v6 (Il2CppClass<System.Net.HttpWebRequest>)+130]");
				if (num4 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v376 @ r8_v5 (Il2CppClass<System.Net.WebRequest>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v430 @ rax_v16+FFFFFFF8+v377 @ rax_v15*8]");
					if (0 == (nint)typeof(HttpWebRequest))
					{
						_ = 0;
						webRequest.Timeout = timeoutMs;
						num = (nint)webRequest.GetResponse();
						nint num5 = (nint)typeof(HttpWebResponse);
						if (num != 0)
						{
							object obj3 = num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ rdx_v10 (Il2CppClass<System.Net.HttpWebResponse>)+130]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ r9_v1+130]");
							nint num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ rdx_v10 (Il2CppClass<System.Net.HttpWebResponse>)+130]");
							if (num6 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ r9_v1+C8]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rax_v26+FFFFFFF8+v319 @ rax_v25*8]");
								if (0 == (nint)typeof(HttpWebResponse))
								{
									goto IL_027b;
								}
							}
							throw new InvalidCastException();
						}
						goto IL_027b;
					}
				}
				throw new InvalidCastException();
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		ArgumentNullException ex2 = new ArgumentNullException("requestUriString");
		nint num7 = unchecked((nint)null);
		throw ex2;
		IL_00c6:
		text = "https://www.google.com";
		goto IL_0335;
	}
}
