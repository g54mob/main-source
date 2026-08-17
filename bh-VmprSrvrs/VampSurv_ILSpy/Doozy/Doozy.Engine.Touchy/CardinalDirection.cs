using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.Touchy;

public static class CardinalDirection
{
	public static readonly Vector2 None;

	public static readonly Vector2 Up;

	public static readonly Vector2 Down;

	public static readonly Vector2 Right;

	public static readonly Vector2 Left;

	public static readonly Vector2 UpRight;

	public static readonly Vector2 UpLeft;

	public static readonly Vector2 DownRight;

	public static readonly Vector2 DownLeft;

	public static Vector2 Get(Swipe swipe)
	{
		//IL_0012: Expected O, but got I8
		//IL_002c: Expected O, but got I8
		if (swipe <= Swipe.DownRight)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v1+2BFAF44+swipe @ rcx (Doozy.Engine.Touchy.Swipe)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v45 @ rcx_v5 (should have been resolved before IL gen)");
		}
		Vector2 result = default(Vector2);
		return result;
	}

	static CardinalDirection()
	{
		//IL_000f: Expected O, but got I4
		//IL_001d: Expected I, but got O
		//IL_0037: Expected O, but got I4
		//IL_004b: Expected I, but got O
		//IL_0065: Expected O, but got I4
		//IL_0079: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_00a5: Expected O, but got I8
		//IL_00b9: Expected I, but got O
		//IL_00d3: Expected O, but got I4
		//IL_00e7: Expected I, but got O
		//IL_0105: Expected O, but got I8
		//IL_0119: Expected I, but got O
		//IL_0133: Expected O, but got I4
		//IL_014b: Expected I, but got O
		//IL_0169: Expected O, but got I8
		None = (Vector2)0;
		nint num = (nint)typeof(CardinalDirection);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v3 (Il2CppClass<Doozy.Engine.Touchy.CardinalDirection>)+B8]");
		nint num2 = 0;
		Up = (Vector2)0;
		_ = 1065353216;
		nint num3 = (nint)typeof(CardinalDirection);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v4 (Il2CppClass<Doozy.Engine.Touchy.CardinalDirection>)+B8]");
		nint num4 = 0;
		Down = (Vector2)0;
		_ = 3212836864L;
		Right = (Vector2)1065353216;
		nint num5 = (nint)typeof(CardinalDirection);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v6 (Il2CppClass<Doozy.Engine.Touchy.CardinalDirection>)+B8]");
		nint num6 = 0;
		Left = (Vector2)3212836864L;
		_ = 0;
		nint num7 = (nint)typeof(CardinalDirection);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v7 (Il2CppClass<Doozy.Engine.Touchy.CardinalDirection>)+B8]");
		nint num8 = 0;
		UpRight = (Vector2)1065353216;
		_ = 1065353216;
		nint num9 = (nint)typeof(CardinalDirection);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v8 (Il2CppClass<Doozy.Engine.Touchy.CardinalDirection>)+B8]");
		nint num10 = 0;
		UpLeft = (Vector2)3212836864L;
		_ = 1065353216;
		nint num11 = (nint)typeof(CardinalDirection);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v9 (Il2CppClass<Doozy.Engine.Touchy.CardinalDirection>)+B8]");
		nint num12 = 0;
		DownRight = (Vector2)1065353216;
		_ = 3212836864L;
		nint num13 = (nint)typeof(CardinalDirection);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v10 (Il2CppClass<Doozy.Engine.Touchy.CardinalDirection>)+B8]");
		nint num14 = 0;
		DownLeft = (Vector2)3212836864L;
		_ = 3212836864L;
	}
}
