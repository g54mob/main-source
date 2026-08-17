using System;
using Cpp2ILInjected;
using UnityEngine;

public class ViewportCrop : MonoBehaviour
{
	private Vector2 ScreenRes;

	private Vector2 _referenceResolution;

	private float _currentAspectRatio;

	private float _referenceAspectRatio;

	private float _percentageX;

	private float _percentageY;

	private Camera _camera;

	private float xSize;

	private float ySize;

	private float xOffset;

	private float yOffset;

	private void Awake()
	{
		Camera component = GetComponent<Camera>();
		_camera = component;
	}

	private unsafe void Update()
	{
		//IL_0026: Expected F4, but got O
		//IL_014e: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		Color backgroundColor = default(Color);
		object obj = default(object);
		GL.GLClear_Injected(true, true, ref backgroundColor, (float)obj);
		Camera camera = (Camera)Screen.width;
		object obj2 = Screen.height;
		Camera camera2 = _camera;
		ScreenRes = (Vector2)camera;
		float num = (float)_referenceResolution;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ViewportCrop)+2C]");
		float num2 = num / 0f;
		float num3 = (float)camera / (float)obj2;
		_referenceAspectRatio = num2;
		_currentAspectRatio = num3;
		float num4 = num2 / num3;
		float num5 = num3 / num2;
		xSize = num4;
		float num6 = 1f - num4;
		ySize = num5;
		float num7 = 1f - num5;
		float num8 = num6 * 0.5f;
		float num9 = num7 * 0.5f;
		xOffset = num8;
		yOffset = num9;
		bool flag = ((UnityEngine.Object)camera2).m_CachedPtr == (IntPtr)0;
		float value = default(float);
		Camera.set_rect_Injected(((UnityEngine.Object)camera2).m_CachedPtr, ref *(Rect*)(&value));
	}

	public ViewportCrop()
	{
		//IL_000b: Expected O, but got I4
		//IL_0026: Expected I, but got O
		_referenceResolution = (Vector2)1156579328;
		_ = 1150681088;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
