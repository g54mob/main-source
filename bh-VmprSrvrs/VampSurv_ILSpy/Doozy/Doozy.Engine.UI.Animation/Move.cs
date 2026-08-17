using System;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;

namespace Doozy.Engine.UI.Animation;

[Serializable]
public class Move
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

	public Direction Direction;

	public Vector3 CustomPosition;

	public EaseType EaseType;

	public Ease Ease;

	public AnimationCurve AnimationCurve;

	public float StartDelay;

	public float Duration;

	public float TotalDuration => Duration + StartDelay;

	public Move(AnimationType animationType)
	{
		//IL_0108: Expected I, but got O
		//IL_0044: Expected I, but got O
		//IL_0143: Expected I, but got O
		//IL_019b: Expected I4, but got I8
		//IL_007f: Expected I, but got O
		AnimationType = animationType;
		Enabled = false;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		From = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		nint num3 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v6 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num4 = 0;
		To = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v5 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		nint num5 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v9 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num6 = 0;
		By = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		UseCustomFromAndTo = false;
		Vibrato = 10;
		Elasticity = 1f;
		NumberOfLoops = -1;
		LoopType = LoopType.Yoyo;
		nint num7 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v12 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num8 = 0;
		CustomPosition = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v9 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		EaseType = EaseType.Ease;
		Ease = Ease.Linear;
		AnimationCurve animationCurve = new AnimationCurve();
		IntPtr ptr = AnimationCurve.Internal_Create((Keyframe[])null);
		animationCurve.m_Ptr = ptr;
		animationCurve.m_RequiresNativeCleanup = true;
		AnimationCurve = animationCurve;
		StartDelay = 0f;
		Duration = 1f;
	}

	public unsafe Move(AnimationType animationType, bool enabled, Vector3 from, Vector3 to, Vector3 by, bool useCustomFromAndTo, int vibrato, float elasticity, int numberOfLoops, LoopType loopType, Direction direction, Vector3 customPosition, EaseType easeType, Ease ease, AnimationCurve animationCurve, float startDelay, float duration)
	{
		//IL_0085: Expected O, but got F4
		//IL_00b2: Expected O, but got F4
		//IL_00cb: Expected O, but got F4
		//IL_00e9: Expected I4, but got O
		//IL_00fd: Expected I4, but got O
		//IL_0107: Expected I4, but got F4
		//IL_0111: Expected F4, but got I4
		//IL_0116: Expected native int or pointer, but got F4
		//IL_0120: Expected O, but got F4
		//IL_0124: Expected native int or pointer, but got F4
		this._002Ector(animationType);
		From = (Vector3)from.x;
		_ = from.z;
		AnimationType = animationType;
		Enabled = enabled;
		To = (Vector3)((Vector3*)numberOfLoops)->x;
		_ = ((Vector3*)numberOfLoops)->z;
		By = (Vector3)((Vector3*)(int)loopType)->x;
		_ = ((Vector3*)(int)loopType)->z;
		UseCustomFromAndTo = (byte)direction != 0;
		Vibrato = (int)customPosition;
		NumberOfLoops = (int)ease;
		LoopType = (LoopType)animationCurve;
		Direction = (Direction)startDelay;
		Elasticity = (float)easeType;
		CustomPosition = (Vector3)((Vector3*)(nint)duration)->x;
		_ = ((Vector3*)(nint)duration)->z;
		IntPtr intPtr = default(IntPtr);
		EaseType = (EaseType)(nint)intPtr;
		Ease ease2 = default(Ease);
		Ease = ease2;
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
		//IL_0108: Expected I, but got O
		//IL_0044: Expected I, but got O
		//IL_0143: Expected I, but got O
		//IL_019b: Expected I4, but got I8
		//IL_007f: Expected I, but got O
		AnimationType = animationType;
		Enabled = false;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		From = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		nint num3 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v6 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num4 = 0;
		To = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v5 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		nint num5 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v9 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num6 = 0;
		By = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		UseCustomFromAndTo = false;
		Vibrato = 10;
		Elasticity = 1f;
		NumberOfLoops = -1;
		LoopType = LoopType.Yoyo;
		nint num7 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v12 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num8 = 0;
		CustomPosition = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v9 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		EaseType = EaseType.Ease;
		Ease = Ease.Linear;
		AnimationCurve animationCurve = new AnimationCurve();
		IntPtr ptr = AnimationCurve.Internal_Create((Keyframe[])null);
		animationCurve.m_Ptr = ptr;
		animationCurve.m_RequiresNativeCleanup = true;
		AnimationCurve = animationCurve;
		StartDelay = 0f;
		Duration = 1f;
	}

	public Move Copy()
	{
		Move move = new Move(AnimationType);
		if (move != null)
		{
			move.AnimationType = AnimationType;
			move.Enabled = Enabled;
			move.From = From;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.Animation.Move)+20]");
			_ = 0;
			move.To = To;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.Animation.Move)+2C]");
			_ = 0;
			move.By = By;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.Animation.Move)+38]");
			_ = 0;
			move.UseCustomFromAndTo = UseCustomFromAndTo;
			move.Vibrato = Vibrato;
			move.Elasticity = Elasticity;
			move.NumberOfLoops = NumberOfLoops;
			move.LoopType = LoopType;
			move.Direction = Direction;
			move.CustomPosition = CustomPosition;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.Animation.Move)+5C]");
			_ = 0;
			move.EaseType = EaseType;
			move.Ease = Ease;
			if (AnimationCurve != null)
			{
				Keyframe[] keys = AnimationCurve.GetKeys();
				AnimationCurve animationCurve = new AnimationCurve();
				IntPtr ptr = AnimationCurve.Internal_Create(keys);
				animationCurve.m_Ptr = ptr;
				animationCurve.m_RequiresNativeCleanup = true;
				move.AnimationCurve = animationCurve;
				move.StartDelay = StartDelay;
				move.Duration = Duration;
				return move;
			}
		}
		return (Move)(object)new NullReferenceException();
	}
}
