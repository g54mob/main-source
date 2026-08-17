using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.MapGeneration.ProceduralTiles;

public class LinearHeightBias : IHeightBiasStrategy
{
	public float CalculateBias(int x, int y, int size, float outerBiasStrength, float strictness)
	{
		//IL_0045: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm6,eax\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm2,edx\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm8,eax\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,r8d\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180418EF0");
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v5 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180418EF0");
		object obj2 = default(object);
		object obj = obj2 / obj2;
		float num3 = 1f - (float)obj;
		object obj3 = default(object);
		return num3 * (float)obj3;
	}
}
