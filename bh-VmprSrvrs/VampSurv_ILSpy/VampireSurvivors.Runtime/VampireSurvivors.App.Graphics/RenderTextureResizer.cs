using System;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Tools;

namespace VampireSurvivors.App.Graphics;

public class RenderTextureResizer : MonoBehaviour
{
	private AspectRatioFitter _AspectRatioFitter;

	private ProCamera2DPixelPerfect _ppCam;

	private int _prevScreenHeight;

	private int _prevScreenWidth;

	private Camera _mainCam;

	private RawImage _rawImage;

	private RenderTexture _currentRT;

	private ProCamera2DPixelPerfect _proCamera2DPixelPerfect;

	private void Awake()
	{
		Camera main = Camera.main;
		_mainCam = main;
		RawImage component = GetComponent<RawImage>();
		_rawImage = component;
		ProCamera2DPixelPerfect component2 = _mainCam.GetComponent<ProCamera2DPixelPerfect>();
		_proCamera2DPixelPerfect = component2;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 188 Invalid \"Jump target not found in method: 0x186C1CFD0\"");
		throw new NullReferenceException();
	}

	private void Update()
	{
		UpdateRT();
	}

	public void UpdateRT(bool force = false)
	{
		//IL_0019: Expected O, but got I4
		//IL_0243: Expected O, but got I4
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected O, but got Unknown
		//IL_00c1: Expected O, but got I4
		//IL_0139: Expected I4, but got O
		//IL_00f5: Expected O, but got I4
		int width = Screen.width;
		int height = Screen.height;
		bool flag = width == _prevScreenWidth;
		if (flag)
		{
			object obj = height - _prevScreenHeight;
			flag = obj == null;
		}
		if (flag)
		{
			return;
		}
		_prevScreenWidth = width;
		Camera mainCam = _mainCam;
		_prevScreenHeight = height;
		if ((object)_mainCam == null || ((UnityEngine.Object)mainCam).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		RenderTexture targetTexture = _mainCam.targetTexture;
		bool flag2 = (object)targetTexture == null;
		object obj2 = 0;
		if (!flag2)
		{
			bool flag3 = ((UnityEngine.Object)targetTexture).m_CachedPtr == (IntPtr)0;
			obj2 = 0;
			if (!flag3)
			{
				RenderTexture targetTexture2 = _mainCam.targetTexture;
				targetTexture2.Release();
				obj2 = 0;
			}
		}
		object obj3 = _AspectRatioFitter + 36;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A773E0");
		object obj4 = default(object);
		if (obj4 != null)
		{
			_AspectRatioFitter.UpdateRect();
		}
		int2 renderTextureSize = CameraExtensions.GetRenderTextureSize(_mainCam);
		int height2 = default(int);
		RenderTextureFormat format = default(RenderTextureFormat);
		RenderTexture currentRT = new RenderTexture((int)renderTextureSize, height2, 0, format);
		_currentRT = currentRT;
		bool flag4 = _currentRT.Create();
		_currentRT.filterMode = FilterMode.Point;
		RenderingExtensions.ClearRenderTexture(_currentRT);
		_rawImage.texture = _currentRT;
		_mainCam.targetTexture = _currentRT;
		_proCamera2DPixelPerfect.ResizeCameraToPixelPerfect();
	}

	public RenderTextureResizer()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
