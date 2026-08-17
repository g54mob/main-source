using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.MapGeneration.ProceduralTiles;

public class GaussianHeightBias : IHeightBiasStrategy
{
	public float CalculateBias(int x, int y, int size, float outerBiasStrength, float strictness)
	{
		//IL_0059: Expected I, but got O
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm6,eax\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm2,edx\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm7,eax\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,r8d\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180418EF0");
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v5 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180418EF0");
		object obj2 = default(object);
		object obj = obj2 / obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
		object obj3 = obj ^ 0;
		object obj5 = default(object);
		object obj4 = obj3 * obj5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803009B0");
		object obj6 = default(object);
		return (float)obj4 * (float)obj6;
	}
}
