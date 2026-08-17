using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Sirenix.Utilities;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using VampireSurvivors.Graphics;

namespace VampireSurvivors;

public class SpriteAnimationController : GameMonoBehaviour
{
	private static readonly HashSet<BaseSpriteAnimation> Animations;

	private static readonly HashSet<BaseSpriteAnimation> PendingAdd;

	private static readonly HashSet<BaseSpriteAnimation> PendingRemove;

	private static ProfilerMarker update;

	private static bool iterating;

	protected unsafe override void OnUpdate()
	{
		//IL_01ed: Expected I, but got O
		//IL_00bf->IL01f2: Incompatible stack heights: 2 vs 1
		//IL_0167->IL0237: Incompatible stack heights: 3 vs 2
		//IL_00fd->IL01f2: Incompatible stack heights: 2 vs 1
		//IL_0144->IL01f2: Incompatible stack heights: 3 vs 1
		//IL_018a->IL027c: Incompatible stack heights: 4 vs 3
		if ((object)update != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)update);
		}
		iterating = true;
		bool flag = Animations == null;
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		while (enumerator.MoveNext())
		{
			MissingMethodException ex = null;
			float deltaTime = PauseSystem.DeltaTime;
			if (((Exception)ex)._remoteStackIndex != 0 || ((Exception)ex)._stackTrace == null)
			{
				continue;
			}
			((FrameAnimationData)((Exception)ex)._stackTrace).AddTime(deltaTime);
			FrameAnimationData stackTrace = (FrameAnimationData)((Exception)ex)._stackTrace;
			bool flag2 = ((Exception)ex)._stackTrace == null;
			if (stackTrace._frameChanged)
			{
				Sprite frame = ((FrameAnimationData)((Exception)ex)._stackTrace).GetFrame();
				string source = ((Exception)null).Source;
				if (((Exception)ex)._remoteStackTraceString != null)
				{
					string remoteStackTraceString = ((Exception)ex)._remoteStackTraceString;
					bool flag3 = (object)frame == null;
					string text = ((UnityEngine.Object)frame).GetName();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v333 @ rbx_v14 (System.String)+18] (should have been resolved before IL gen)");
				}
			}
		}
		iterating = false;
		bool flag4 = PendingAdd == null;
		while (enumerator.MoveNext())
		{
			bool flag5 = Animations == null;
			bool flag6 = ((HashSet<object>)(object)Animations).AddIfNotPresent((object)null);
		}
		bool flag7 = PendingRemove == null;
		while (enumerator.MoveNext())
		{
			bool flag8 = Animations == null;
			bool flag9 = ((HashSet<object>)(object)Animations).Remove((object)null);
		}
		bool flag10 = PendingAdd == null;
		bool flag11 = ((HashSet<BaseSpriteAnimation>.Enumerator*)PendingAdd)->MoveNext();
		bool flag12 = PendingRemove == null;
		bool flag13 = ((HashSet<BaseSpriteAnimation>.Enumerator*)PendingRemove)->MoveNext();
		ProfilerMarker profilerMarker = default(ProfilerMarker);
		((ProfilerMarker.AutoScope*)(&profilerMarker))->Dispose();
	}

	public static void Add(BaseSpriteAnimation baseSpriteAnimation)
	{
		if (!iterating)
		{
			bool flag = ((HashSet<object>)(object)Animations).AddIfNotPresent((object)baseSpriteAnimation);
			return;
		}
		bool flag2 = ((HashSet<object>)(object)PendingAdd).AddIfNotPresent((object)baseSpriteAnimation);
		bool flag3 = ((HashSet<object>)(object)PendingRemove).Remove((object)baseSpriteAnimation);
	}

	public static void Remove(BaseSpriteAnimation baseSpriteAnimation)
	{
		if (!iterating)
		{
			bool flag = ((HashSet<object>)(object)Animations).Remove((object)baseSpriteAnimation);
			return;
		}
		bool flag2 = ((HashSet<object>)(object)PendingAdd).Remove((object)baseSpriteAnimation);
		bool flag3 = ((HashSet<object>)(object)PendingRemove).AddIfNotPresent((object)baseSpriteAnimation);
	}

	public SpriteAnimationController()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	static SpriteAnimationController()
	{
		//IL_002d: Expected I4, but got I8
		//IL_00ce: Expected I4, but got I8
		//IL_0161: Expected I4, but got I8
		//IL_01b5: Expected O, but got I
		EqualityComparer<object> comparer = (EqualityComparer<object>)(object)ReferenceEqualityComparer<BaseSpriteAnimation>.Default;
		HashSet<BaseSpriteAnimation> hashSet = null;
		if (ReferenceEqualityComparer<BaseSpriteAnimation>.Default == null)
		{
			EqualityComparer<object> equalityComparer = EqualityComparer<object>.Default;
			comparer = equalityComparer;
		}
		hashSet._comparer = comparer;
		hashSet._freeList = -1;
		hashSet._count = 0;
		hashSet._version = 0;
		int num = hashSet.Initialize(1024);
		Animations = hashSet;
		EqualityComparer<object> comparer2 = (EqualityComparer<object>)(object)ReferenceEqualityComparer<BaseSpriteAnimation>.Default;
		HashSet<BaseSpriteAnimation> hashSet2 = null;
		if (ReferenceEqualityComparer<BaseSpriteAnimation>.Default == null)
		{
			EqualityComparer<object> equalityComparer2 = EqualityComparer<object>.Default;
			comparer2 = equalityComparer2;
		}
		hashSet2._comparer = comparer2;
		hashSet2._count = 0;
		hashSet2._freeList = -1;
		hashSet2._version = 0;
		int num2 = hashSet2.Initialize(64);
		PendingAdd = hashSet2;
		EqualityComparer<object> comparer3 = (EqualityComparer<object>)(object)ReferenceEqualityComparer<BaseSpriteAnimation>.Default;
		HashSet<BaseSpriteAnimation> hashSet3 = null;
		if (ReferenceEqualityComparer<BaseSpriteAnimation>.Default == null)
		{
			EqualityComparer<object> equalityComparer3 = EqualityComparer<object>.Default;
			comparer3 = equalityComparer3;
		}
		hashSet3._comparer = comparer3;
		hashSet3._count = 0;
		hashSet3._freeList = -1;
		hashSet3._version = 0;
		int num3 = hashSet3.Initialize(64);
		PendingRemove = hashSet3;
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("SpriteAnimationController.Update", 1, MarkerFlags.Default, 0);
		update = (ProfilerMarker)(nint)intPtr;
		iterating = false;
	}
}
