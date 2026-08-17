using System;
using Cpp2ILInjected;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Jobs;

namespace Plugins.PhaserPort.physics.arcade.jobs;

public struct PostSpriteOffsetUpdateJob : IJobParallelForTransform
{
	public NativeArray<bool> _enabledArray;

	public NativeArray<bool> _movesArray;

	public NativeArray<bool> _validArray;

	public NativeArray<SpriteOffsetData> _spriteOffsetDataArray;

	public unsafe void Execute(int index, TransformAccess transform)
	{
		if (transform.hierarchy == (IntPtr)0)
		{
			return;
		}
		NativeArray<bool> enabledArray = _enabledArray;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [index @ rdx (System.Int32)+v16 @ rax_v2 (Unity.Collections.NativeArray`1<System.Boolean>)]");
		if ((nint)0 == 0)
		{
			return;
		}
		NativeArray<bool> movesArray = _movesArray;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [index @ rdx (System.Int32)+v85 @ rax_v3 (Unity.Collections.NativeArray`1<System.Boolean>)]");
		if ((nint)0 != 0)
		{
			NativeArray<bool> validArray = _validArray;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [index @ rdx (System.Int32)+v86 @ rax_v4 (Unity.Collections.NativeArray`1<System.Boolean>)]");
			if ((nint)0 != 0)
			{
				Vector3 p = default(Vector3);
				TransformAccess.SetLocalPosition(ref *(TransformAccess*)transform, ref p);
			}
		}
	}
}
