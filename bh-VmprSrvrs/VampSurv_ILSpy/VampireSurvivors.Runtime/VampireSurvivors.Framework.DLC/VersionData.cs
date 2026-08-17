using System;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Framework.DLC;

[Serializable]
public class VersionData : ScriptableObject
{
	public string _BuildId;

	public string _BuildTime;

	private static VersionData _instance;

	public static VersionData Instance => _instance;

	private void OnEnable()
	{
		_instance = this;
	}

	private void OnDisable()
	{
		//IL_00e7: Expected O, but got I4
		//IL_0101: Expected O, but got I4
		VersionData instance = _instance;
		bool flag = (object)_instance == null;
		bool flag2 = (object)this == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)this != null)
			{
				if ((object)_instance != null)
				{
					object obj3 = (object)_instance - (object)this;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)instance).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				return;
			}
		}
		_instance = null;
	}

	public unsafe string GetFormattedBuildId()
	{
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected Ref, but got Unknown
		//IL_00c2: Expected I8, but got I4
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected Ref, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2BE8]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string buildId = _BuildId;
		object obj = "";
		if ((object)_BuildId != "")
		{
			if (_BuildId != null && "" != null)
			{
				int stringLength = buildId._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdx_v1+10]");
				if ((nint)stringLength == 0)
				{
					ref byte second = ref *(byte*)("" + 20);
					ulong length = (ulong)(buildId._stringLength + buildId._stringLength);
					if (System.SpanHelpers.SequenceEqual(ref *(byte*)(_BuildId + 20), ref second, length))
					{
						goto IL_010e;
					}
				}
			}
			return _BuildId + "R";
		}
		goto IL_010e;
		IL_010e:
		return "LOCAL";
	}
}
