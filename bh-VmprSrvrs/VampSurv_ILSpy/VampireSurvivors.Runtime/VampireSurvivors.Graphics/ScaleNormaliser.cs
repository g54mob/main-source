using System;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Graphics;

public class ScaleNormaliser : GameMonoBehaviour
{
	private void LateUpdate()
	{
		Transform transform = base.transform;
		Vector3 ret;
		if ((object)transform != null)
		{
			Transform parent = transform.parent;
			if ((object)parent != null)
			{
				bool flag = ((UnityEngine.Object)parent).m_CachedPtr == (IntPtr)0;
				Transform.get_lossyScale_Injected(((UnityEngine.Object)parent).m_CachedPtr, out ret);
				bool flag2 = (object)ret == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001874BBD20h\"");
				if (flag2)
				{
					object obj = default(object);
					bool flag3 = obj == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001874BBD38h\"");
					if (!flag3)
					{
						goto IL_00c3;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001874BBD4Fh\"");
				goto IL_00c3;
			}
		}
		throw new NullReferenceException();
		IL_00c3:
		Transform transform2 = base.transform;
		bool flag4 = (object)transform2 == null;
		bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref ret);
	}

	public ScaleNormaliser()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
