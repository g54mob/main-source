using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.Progress;

[Serializable]
public abstract class ProgressTarget : MonoBehaviour
{
	public virtual void OnEnable()
	{
	}

	public virtual void OnDisable()
	{
	}

	public virtual void UpdateTarget(Progressor progressor)
	{
	}

	protected ProgressTarget()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
