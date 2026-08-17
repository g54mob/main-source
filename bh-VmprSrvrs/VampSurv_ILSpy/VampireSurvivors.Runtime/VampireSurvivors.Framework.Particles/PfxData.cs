using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Framework.Particles;

public class PfxData : GameMonoBehaviour
{
	private ParticleSystemConfig _003CCurrentConfig_003Ek__BackingField;

	public ParticleSystemConfig CurrentConfig
	{
		get
		{
			return _003CCurrentConfig_003Ek__BackingField;
		}
		set
		{
			_003CCurrentConfig_003Ek__BackingField = value;
		}
	}

	public PfxData()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
