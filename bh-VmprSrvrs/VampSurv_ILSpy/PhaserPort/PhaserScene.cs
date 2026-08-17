using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using PhaserPort;
using Unity.Mathematics;
using UnityEngine;

public class PhaserScene
{
	public class Renderer
	{
		public float width;

		public float height;

		public int pixelWidth;

		public int pixelHeight;

		public float screenWidth;

		public float screenHeight;

		public float screenWidthPixels;

		public float screenHeightPixels;

		public float sortPivotY;

		public float2 screenCenter;

		public float2 cameraVelocity;

		public ArcadeRect playArea;

		private float2 lastScreenCenter;

		private bool firstFrame = true;

		public void UpdateCameraVelocity()
		{
			//IL_0073: Expected O, but got F4
			//IL_0055: Expected O, but got I
			//IL_009c: Expected O, but got F4
			if (firstFrame)
			{
				firstFrame = false;
			}
			else
			{
				object obj = Time.deltaTime;
				object obj2 = default(object);
				if ((nint)obj2 > 0)
				{
					object obj3 = screenCenter - lastScreenCenter;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rcx_v5 (PhaserScene+Renderer)+38]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rcx_v5 (PhaserScene+Renderer)+58]");
					object obj4 = num - 0;
					object obj5 = Time.deltaTime;
					float2 float5 = obj3 / obj2;
					object obj6 = obj4 / obj2;
					cameraVelocity = float5;
				}
			}
			lastScreenCenter = screenCenter;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rcx_v5 (PhaserScene+Renderer)+38]");
			_ = 0;
		}

		public bool IsInPlayableScreenBounds(float2 point)
		{
			//IL_002b: Invalid comparison between O and F4
			//IL_006a: Invalid comparison between F4 and O
			//IL_00af: Invalid comparison between O and F4
			//IL_00f4: Invalid comparison between F4 and O
			float num = width * 0.5f;
			float num2 = (float)screenCenter - num;
			if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref point) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2))
			{
				float num3 = width * 0.5f;
				float num4 = num3 + (float)screenCenter;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) >= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref point))
				{
					float num5 = height * 0.5f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PhaserScene+Renderer)+38]");
					float num6 = 0f - num5;
					object obj = default(object);
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6))
					{
						float num7 = height * 0.5f;
						float num8 = num7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PhaserScene+Renderer)+38]");
						float num9 = num8 + 0f;
						bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num9) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
						return !flag;
					}
				}
			}
			return false;
		}
	}

	public class BoxedVector2(float x, float y)
	{
		public float x = x;

		public float y = y;
	}

	public class CameraSet
	{
		public PhaserCamera main;
	}

	public Factory add;

	public ArcadePhysics physics;

	public CameraSet cameras;

	private Renderer _renderer = new Renderer
	{
		firstFrame = true
	};

	public Renderer renderer => _renderer;

	public PhaserScene()
	{
		CameraSet cameraSet = new CameraSet();
		cameras = cameraSet;
		CameraSet cameraSet2 = cameras;
		Camera main = Camera.main;
		PhaserCamera component = main.GetComponent<PhaserCamera>();
		cameraSet2.main = component;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 207 Invalid \"Jump target not found in method: 0x18500DEF0\"");
		throw new NullReferenceException();
	}

	public void UpdateRendererCache()
	{
		//IL_0025: Expected F4, but got O
		//IL_00cd: Expected F4, but got O
		//IL_01d3: Expected O, but got F4
		//IL_02d1: Expected O, but got F4
		//IL_02da: Invalid comparison between F4 and I4
		//IL_0276: Expected O, but got I
		//IL_02fa: Expected O, but got F4
		//IL_0325: Expected O, but got F4
		float2 rendererSizeIgnoringBorders = RenderingHelper.GetRendererSizeIgnoringBorders();
		Renderer renderer = _renderer;
		renderer.screenWidth = (float)rendererSizeIgnoringBorders;
		float num = (float)rendererSizeIgnoringBorders * 100f;
		float num2 = default(float);
		renderer.screenHeight = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003890");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		float num3 = num2 * 100f;
		float screenWidthPixels = default(float);
		renderer.screenWidthPixels = screenWidthPixels;
		Renderer renderer2 = _renderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003890");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		float screenHeightPixels = default(float);
		renderer2.screenHeightPixels = screenHeightPixels;
		float2 rendererSize = RenderingHelper.GetRendererSize();
		Renderer renderer3 = _renderer;
		renderer3.width = (float)rendererSize;
		float num4 = (float)rendererSize * 100f;
		renderer3.height = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003890");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		float num5 = num2 * 100f;
		int pixelWidth = default(int);
		renderer3.pixelWidth = pixelWidth;
		Renderer renderer4 = _renderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003890");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		int pixelHeight = default(int);
		renderer4.pixelHeight = pixelHeight;
		float2 cameraCenter = RenderingHelper.GetCameraCenter();
		Renderer renderer5 = _renderer;
		float num6 = (float)cameraCenter * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003890");
		float num7 = num2 * 100f;
		float num8 = num6 / 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003890");
		float num9 = num7 / 100f;
		renderer5.screenCenter = (float2)num8;
		Renderer renderer6 = _renderer;
		float num10 = num2 * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003890");
		renderer6.sortPivotY = num10;
		Renderer renderer7 = _renderer;
		if (renderer7.firstFrame)
		{
			renderer7.firstFrame = false;
		}
		else
		{
			object obj = Time.deltaTime;
			if (num10 > 0f)
			{
				object obj2 = renderer7.screenCenter - renderer7.lastScreenCenter;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdi_v10 (PhaserScene+Renderer)+38]");
				nint num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdi_v10 (PhaserScene+Renderer)+58]");
				object obj3 = num11 - 0;
				object obj4 = Time.deltaTime;
				float num12 = (float)obj2 / num10;
				float num13 = (float)obj3 / num10;
				renderer7.cameraVelocity = (float2)num12;
			}
		}
		renderer7.lastScreenCenter = renderer7.screenCenter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdi_v10 (PhaserScene+Renderer)+38]");
		_ = 0;
		Renderer renderer8 = _renderer;
		ArcadeRect playArea = default(ArcadeRect);
		renderer8.playArea = playArea;
		Renderer renderer9 = _renderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rax_v22 (PhaserScene+Renderer)+50]");
		float num14 = 0f - 0.1f;
	}
}
