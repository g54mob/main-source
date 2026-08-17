using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Objects.Stages;

public class MazerellaTorinoSecretPositions : MonoBehaviour
{
	private float _colossusOutsideMapYThreshold;

	private Bounds _unlockTorinoPlayerBounds;

	public unsafe Bounds UnlockTorinoPlayerBounds
	{
		get
		{
			//IL_000a: Expected native int or pointer, but got O
			Bounds bounds = default(Bounds);
			((Bounds*)(nint)bounds)->m_Center = (Vector3)_unlockTorinoPlayerBounds;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (VampireSurvivors.Objects.Stages.MazerellaTorinoSecretPositions)+34]");
			_ = 0;
			return bounds;
		}
	}

	public float ColossusOutsideMapYThreshold()
	{
		return _colossusOutsideMapYThreshold;
	}

	public MazerellaTorinoSecretPositions()
	{
		//IL_0020: Expected I, but got O
		_colossusOutsideMapYThreshold = -76.48f;
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
