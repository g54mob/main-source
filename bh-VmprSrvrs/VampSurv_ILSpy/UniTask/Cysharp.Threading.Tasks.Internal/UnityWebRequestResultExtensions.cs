using System;
using UnityEngine.Networking;

namespace Cysharp.Threading.Tasks.Internal;

internal static class UnityWebRequestResultExtensions
{
	public static bool IsError(UnityWebRequest unityWebRequest)
	{
		//IL_005d: Expected O, but got I4
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_0097: Expected O, but got I4
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		bool flag = unityWebRequest.m_Ptr == (IntPtr)0;
		object obj = UnityWebRequest.get_result_Injected(unityWebRequest.m_Ptr);
		object obj2 = obj - 2;
		object obj3 = obj2 & 0xFFFFFFFDL;
		bool flag2 = obj3 == null;
		object obj4 = !flag2;
		if (obj4 == null)
		{
			return true;
		}
		object obj5 = obj - 3;
		return obj5 == null;
	}
}
