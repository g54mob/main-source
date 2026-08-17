using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

[Serializable]
public class CameraTarget
{
	public Transform TargetTransform;

	public float TargetInfluenceH = 1f;

	public float TargetInfluenceV = 1f;

	public Vector2 TargetOffset;

	private Vector3 _targetPosition;

	public float TargetInfluence
	{
		set
		{
			TargetInfluenceH = value;
			TargetInfluenceV = value;
		}
	}

	public unsafe Vector3 TargetPosition
	{
		get
		{
			//IL_0074: Expected F4, but got O
			//IL_006f: Expected native int or pointer, but got O
			//IL_0089: Expected F4, but got I
			//IL_0084: Expected native int or pointer, but got O
			//IL_010e: Expected F4, but got O
			//IL_0109: Expected native int or pointer, but got O
			//IL_011d: Expected native int or pointer, but got O
			Transform targetTransform = TargetTransform;
			Vector3 vector = default(Vector3);
			if ((object)TargetTransform != null && ((UnityEngine.Object)targetTransform).m_CachedPtr != (IntPtr)0)
			{
				object targetTransform2 = TargetTransform;
				bool flag = (object)TargetTransform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rdi_v3 (System.Object)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rdi_v3 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
				_targetPosition = ret;
				((Vector3*)(nint)vector)->x = (float)ret;
				_ = 0;
				((Vector3*)(nint)vector)->z = 0f;
				return vector;
			}
			((Vector3*)(nint)vector)->x = (float)_targetPosition;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.CameraTarget)+30]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
	}
}
