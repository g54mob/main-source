using System;
using System.Collections.Generic;
using Cpp2ILInjected;

public class PhaserGameObjectComparer : IEqualityComparer<PhaserGameObject>
{
	public static PhaserGameObjectComparer Default;

	public bool Equals(PhaserGameObject x, PhaserGameObject y)
	{
		object obj = (object)x - (object)y;
		return obj == null;
	}

	public int GetHashCode(PhaserGameObject obj)
	{
		//IL_005d: Expected I4, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_0045: Expected O, but got I
		if ((object)obj != null)
		{
			nint num = (nint)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rdx_v1 (Il2CppClass<PhaserGameObject>)+158]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rdx_v1 (Il2CppClass<PhaserGameObject>)+160]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v14 @ rax_v2 (should have been resolved before IL gen)");
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	static PhaserGameObjectComparer()
	{
		PhaserGameObjectComparer phaserGameObjectComparer = new PhaserGameObjectComparer();
		Default = phaserGameObjectComparer;
	}
}
