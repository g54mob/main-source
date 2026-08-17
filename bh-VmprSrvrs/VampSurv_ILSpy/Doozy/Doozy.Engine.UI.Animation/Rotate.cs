using System;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;

namespace Doozy.Engine.UI.Animation;

[Serializable]
public class Rotate
{
	public AnimationType AnimationType;

	public bool Enabled;

	public Vector3 From;

	public Vector3 To;

	public Vector3 By;

	public bool UseCustomFromAndTo;

	public int Vibrato;

	public float Elasticity;

	public int NumberOfLoops;

	public LoopType LoopType;

	public RotateMode RotateMode;

	public EaseType EaseType;

	public Ease Ease;

	public AnimationCurve AnimationCurve;

	public float StartDelay;

	public float Duration;

	public float TotalDuration => Duration + StartDelay;

	public Rotate(AnimationType animationType)
	{
		//IL_007f: Expected I, but got O
		//IL_0044: Expected I, but got O
		//IL_00ba: Expected I, but got O
		//IL_0112: Expected I4, but got I8
		AnimationType = animationType;
		Enabled = false;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		From = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		nint num3 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v6 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num4 = 0;
		To = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v1 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		nint num5 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v9 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num6 = 0;
		By = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rcx_v6 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		UseCustomFromAndTo = false;
		Vibrato = 10;
		Elasticity = 1f;
		NumberOfLoops = -1;
		LoopType = LoopType.Yoyo;
		RotateMode = RotateMode.FastBeyond360;
		Ease = Ease.Linear;
		AnimationCurve animationCurve = new AnimationCurve();
		IntPtr ptr = AnimationCurve.Internal_Create((Keyframe[])null);
		animationCurve.m_Ptr = ptr;
		animationCurve.m_RequiresNativeCleanup = true;
		AnimationCurve = animationCurve;
		Duration = 1f;
		StartDelay = 0f;
	}

	public unsafe Rotate(AnimationType animationType, bool enabled, Vector3 from, Vector3 to, Vector3 by, bool useCustomFromAndTo, int vibrato, float elasticity, int numberOfLoops, LoopType loopType, RotateMode rotateMode, EaseType easeType, Ease ease, AnimationCurve animationCurve, float startDelay, float duration)
	{
		//IL_0085: Expected O, but got F4
		//IL_00b2: Expected O, but got F4
		//IL_00cb: Expected O, but got F4
		//IL_00f3: Expected I4, but got O
		//IL_00fd: Expected I4, but got F4
		//IL_0107: Expected I4, but got F4
		//IL_0125: Expected F4, but got I4
		this._002Ector(animationType);
		From = (Vector3)from.x;
		_ = from.z;
		AnimationType = animationType;
		Enabled = enabled;
		To = (Vector3)((Vector3*)numberOfLoops)->x;
		_ = ((Vector3*)numberOfLoops)->z;
		By = (Vector3)((Vector3*)(int)loopType)->x;
		_ = ((Vector3*)(int)loopType)->z;
		UseCustomFromAndTo = (byte)rotateMode != 0;
		Vibrato = (int)easeType;
		NumberOfLoops = (int)animationCurve;
		LoopType = (LoopType)startDelay;
		RotateMode = (RotateMode)duration;
		IntPtr intPtr = default(IntPtr);
		EaseType = (EaseType)(nint)intPtr;
		Ease ease2 = default(Ease);
		Ease = ease2;
		Elasticity = (float)ease;
		AnimationCurve animationCurve2 = default(AnimationCurve);
		Keyframe[] keys = animationCurve2.GetKeys();
		AnimationCurve = new AnimationCurve
		{
			m_Ptr = AnimationCurve.Internal_Create(keys),
			m_RequiresNativeCleanup = true
		};
		float startDelay2 = default(float);
		StartDelay = startDelay2;
		float duration2 = default(float);
		Duration = duration2;
	}

	public void Reset(AnimationType animationType)
	{
		//IL_007f: Expected I, but got O
		//IL_0044: Expected I, but got O
		//IL_00ba: Expected I, but got O
		//IL_0112: Expected I4, but got I8
		AnimationType = animationType;
		Enabled = false;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		From = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		nint num3 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v6 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num4 = 0;
		To = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v1 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		nint num5 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v9 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num6 = 0;
		By = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rcx_v6 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		UseCustomFromAndTo = false;
		Vibrato = 10;
		Elasticity = 1f;
		NumberOfLoops = -1;
		LoopType = LoopType.Yoyo;
		RotateMode = RotateMode.FastBeyond360;
		Ease = Ease.Linear;
		AnimationCurve animationCurve = new AnimationCurve();
		IntPtr ptr = AnimationCurve.Internal_Create((Keyframe[])null);
		animationCurve.m_Ptr = ptr;
		animationCurve.m_RequiresNativeCleanup = true;
		AnimationCurve = animationCurve;
		Duration = 1f;
		StartDelay = 0f;
	}

	public Rotate Copy()
	{
		Rotate rotate = new Rotate(AnimationType);
		if (rotate != null)
		{
			rotate.AnimationType = AnimationType;
			rotate.Enabled = Enabled;
			rotate.From = From;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.Animation.Rotate)+20]");
			_ = 0;
			rotate.To = To;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.Animation.Rotate)+2C]");
			_ = 0;
			rotate.By = By;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.Animation.Rotate)+38]");
			_ = 0;
			rotate.UseCustomFromAndTo = UseCustomFromAndTo;
			rotate.Vibrato = Vibrato;
			rotate.Elasticity = Elasticity;
			rotate.NumberOfLoops = NumberOfLoops;
			rotate.LoopType = LoopType;
			rotate.RotateMode = RotateMode;
			rotate.EaseType = EaseType;
			rotate.Ease = Ease;
			if (AnimationCurve != null)
			{
				Keyframe[] keys = AnimationCurve.GetKeys();
				AnimationCurve animationCurve = new AnimationCurve();
				IntPtr ptr = AnimationCurve.Internal_Create(keys);
				animationCurve.m_Ptr = ptr;
				animationCurve.m_RequiresNativeCleanup = true;
				rotate.AnimationCurve = animationCurve;
				rotate.StartDelay = StartDelay;
				rotate.Duration = Duration;
				return rotate;
			}
		}
		return (Rotate)(object)new NullReferenceException();
	}
}
