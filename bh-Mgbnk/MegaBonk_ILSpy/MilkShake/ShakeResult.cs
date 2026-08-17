using Cpp2ILInjected;
using UnityEngine;

namespace MilkShake;

public struct ShakeResult
{
	public Vector3 PositionShake;

	public Vector3 RotationShake;

	public unsafe static ShakeResult operator +(ShakeResult a, ShakeResult b)
	{
		//IL_0034: Expected O, but got I
		//IL_003c: Expected native int or pointer, but got O
		//IL_005e: Expected O, but got I
		//IL_0085: Expected O, but got I
		//IL_008d: Expected native int or pointer, but got O
		Vector3 positionShake = a.PositionShake + b.PositionShake;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [a @ rdx (MilkShake.ShakeResult)+4]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [b @ r8 (MilkShake.ShakeResult)+4]");
		object obj = num + 0;
		ShakeResult shakeResult = default(ShakeResult);
		((ShakeResult*)(nint)shakeResult)->PositionShake = positionShake;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [a @ rdx (MilkShake.ShakeResult)+8]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [b @ r8 (MilkShake.ShakeResult)+8]");
		object obj2 = num2 + 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [a @ rdx (MilkShake.ShakeResult)+14]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [b @ r8 (MilkShake.ShakeResult)+14]");
		object obj3 = num3 + 0;
		Vector3 rotationShake = default(Vector3);
		((ShakeResult*)(nint)shakeResult)->RotationShake = rotationShake;
		return shakeResult;
	}
}
