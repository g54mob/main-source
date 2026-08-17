using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using UnityEngine;

public class PhaserCamera : MonoBehaviour
{
	public PhaserScene.BoxedVector2 followOffset;

	private ProCamera2D _camera2D;

	private void Awake()
	{
		ProCamera2D component = GetComponent<ProCamera2D>();
		_camera2D = component;
	}

	public void setFollowOffset(float x, float y)
	{
		PhaserScene.BoxedVector2 boxedVector = followOffset;
		boxedVector.x = x;
		boxedVector.y = y;
	}

	private void LateUpdate()
	{
		PhaserScene.BoxedVector2 boxedVector = followOffset;
		ProCamera2D camera2D = _camera2D;
		float offsetX = boxedVector.x * 0.01f;
		camera2D.OffsetX = offsetX;
		float offsetY = boxedVector.y * 0.01f;
		camera2D.OffsetY = offsetY;
	}

	public PhaserCamera()
	{
		//IL_003c: Expected I, but got O
		(followOffset = null).x = 0f;
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rcx_v6 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
