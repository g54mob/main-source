using System;
using System.Runtime.CompilerServices;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.App.Graphics;

public class PixelPerfectProCameraController : MonoBehaviour
{
	private const float DEFAULT_SCALE = 0.5f;

	private const float DEFAULT_WIDTH = 1920f;

	private const float DEFAULT_HEIGHT = 1200f;

	private const float PHASER_DEFAULT_WIDTH = 1366f;

	private const float PHASER_DEFAULT_HEIGHT = 1024f;

	private ProCamera2DPixelPerfect _ppCam;

	private int _prevScreenHeight;

	private int _prevScreenWidth;

	private float _widthToHeightRatio;

	private float _heightToWidthRatio;

	private void Awake()
	{
		//IL_0081: Expected O, but got I4
		Camera main = Camera.main;
		if ((object)main != null && ((UnityEngine.Object)main).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = main.gameObject;
			ProCamera2DPixelPerfect component = gameObject.GetComponent<ProCamera2DPixelPerfect>();
			_ppCam = component;
			ProCamera2DPixelPerfect ppCam = _ppCam;
			ppCam.TargetViewportSizeInPixels = (Vector2)1156579328;
			_ = 1150681088;
			ProCamera2DPixelPerfect ppCam2 = _ppCam;
			ppCam2._zoom = 1;
			ppCam2.ResizeCameraToPixelPerfect();
			ProCamera2DPixelPerfect ppCam3 = _ppCam;
			ppCam3.SnapCameraToGrid = true;
			ProCamera2DPixelPerfect ppCam4 = _ppCam;
			ppCam4.SnapMovementToGrid = true;
			ProCamera2DPixelPerfect ppCam5 = _ppCam;
			ppCam5.ViewportAutoScale = AutoScaleMode.Round;
			UpdateCamera();
		}
	}

	private void FixedUpdate()
	{
		UpdateCamera();
	}

	private void UpdateCamera()
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_011f: Expected O, but got I4
		int width = Screen.width;
		int height = Screen.height;
		if (width != _prevScreenWidth || height != _prevScreenHeight)
		{
			_prevScreenWidth = width;
			_prevScreenHeight = height;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm2,eax\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,eax\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,edi\"");
			object obj = 0 * _widthToHeightRatio;
			object obj2 = 0 * _heightToWidthRatio;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm3,edi\"");
			object obj3 = 0 / obj2;
			object obj4 = 0 / obj;
			float num;
			int num2;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
			{
				num = 1920f;
				num2 = width;
			}
			else
			{
				num = 1200f;
				num2 = height;
			}
			float num3 = num / (float)num2;
			float num4 = 1f / num3;
			ProCamera2DPixelPerfect ppCam = _ppCam;
			float pixelsPerUnit = num4 * 266.79688f;
			ppCam.PixelsPerUnit = pixelsPerUnit;
			ProCamera2DPixelPerfect ppCam2 = _ppCam;
			ppCam2.TargetViewportSizeInPixels = (Vector2)width;
			_ppCam.ResizeCameraToPixelPerfect();
		}
	}

	public PixelPerfectProCameraController()
	{
		//IL_002b: Expected I, but got O
		_widthToHeightRatio = 1.6f;
		_heightToWidthRatio = 0.625f;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
