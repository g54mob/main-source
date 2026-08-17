using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors;

public class PauseTimeHelper : GameMonoBehaviour
{
	public Renderer _renderer;

	private float _timer;

	private int _shaderParam;

	private void Awake()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3616]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		int shaderParam = Shader.PropertyToID("_PauseTime");
		_shaderParam = shaderParam;
	}

	protected override void OnUpdate()
	{
		float deltaTime = PauseSystem.DeltaTime;
		float timer = deltaTime + _timer;
		_timer = timer;
		Material material = _renderer.GetMaterial();
		material.SetFloatImpl(_shaderParam, _timer);
	}

	public PauseTimeHelper()
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
