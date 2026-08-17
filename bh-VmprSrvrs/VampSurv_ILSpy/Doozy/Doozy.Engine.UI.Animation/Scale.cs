using System;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;

namespace Doozy.Engine.UI.Animation;

[Serializable]
public class Scale
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

	public EaseType EaseType;

	public Ease Ease;

	public AnimationCurve AnimationCurve;

	public float StartDelay;

	public float Duration;

	public float TotalDuration => Duration + StartDelay;

	public Scale(AnimationType animationType)
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
		Ease = Ease.Linear;
		AnimationCurve animationCurve = new AnimationCurve();
		IntPtr ptr = AnimationCurve.Internal_Create((Keyframe[])null);
		animationCurve.m_Ptr = ptr;
		animationCurve.m_RequiresNativeCleanup = true;
		AnimationCurve = animationCurve;
		Duration = 1f;
		StartDelay = 0f;
	}

	public unsafe Scale(AnimationType animationType, bool enabled, Vector3 from, Vector3 to, Vector3 by, bool useCustomFromAndTo, int vibrato, float elasticity, int numberOfLoops, LoopType loopType, EaseType easeType, Ease ease, AnimationCurve animationCurve, float startDelay, float duration)
	{
		//IL_0085: Expected O, but got F4
		//IL_00b2: Expected O, but got F4
		//IL_00cb: Expected O, but got F4
		//IL_00f3: Expected I4, but got F4
		//IL_00fd: Expected I4, but got F4
		//IL_011b: Expected F4, but got O
		this._002Ector(animationType);
		From = (Vector3)from.x;
		_ = from.z;
		AnimationType = animationType;
		Enabled = enabled;
		To = (Vector3)((Vector3*)numberOfLoops)->x;
		_ = ((Vector3*)numberOfLoops)->z;
		By = (Vector3)((Vector3*)(int)loopType)->x;
		_ = ((Vector3*)(int)loopType)->z;
		UseCustomFromAndTo = (byte)easeType != 0;
		Vibrato = (int)ease;
		NumberOfLoops = (int)startDelay;
		LoopType = (LoopType)duration;
		IntPtr intPtr = default(IntPtr);
		EaseType = (EaseType)(nint)intPtr;
		Ease ease2 = default(Ease);
		Ease = ease2;
		Elasticity = (float)animationCurve;
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
		Ease = Ease.Linear;
		AnimationCurve animationCurve = new AnimationCurve();
		IntPtr ptr = AnimationCurve.Internal_Create((Keyframe[])null);
		animationCurve.m_Ptr = ptr;
		animationCurve.m_RequiresNativeCleanup = true;
		AnimationCurve = animationCurve;
		Duration = 1f;
		StartDelay = 0f;
	}

	public Scale Copy()
	{
		Scale scale = new Scale(AnimationType);
		if (scale != null)
		{
			scale.AnimationType = AnimationType;
			scale.Enabled = Enabled;
			scale.From = From;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.Animation.Scale)+20]");
			_ = 0;
			scale.To = To;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.Animation.Scale)+2C]");
			_ = 0;
			scale.By = By;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.Animation.Scale)+38]");
			_ = 0;
			scale.UseCustomFromAndTo = UseCustomFromAndTo;
			scale.Vibrato = Vibrato;
			scale.Elasticity = Elasticity;
			scale.NumberOfLoops = NumberOfLoops;
			scale.LoopType = LoopType;
			scale.EaseType = EaseType;
			scale.Ease = Ease;
			if (AnimationCurve != null)
			{
				Keyframe[] keys = AnimationCurve.GetKeys();
				AnimationCurve animationCurve = new AnimationCurve();
				IntPtr ptr = AnimationCurve.Internal_Create(keys);
				animationCurve.m_Ptr = ptr;
				animationCurve.m_RequiresNativeCleanup = true;
				scale.AnimationCurve = animationCurve;
				scale.StartDelay = StartDelay;
				scale.Duration = Duration;
				return scale;
			}
		}
		return (Scale)(object)new NullReferenceException();
	}
}
