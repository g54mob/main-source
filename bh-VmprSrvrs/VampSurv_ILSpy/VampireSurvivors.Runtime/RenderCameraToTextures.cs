using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Cpp2ILInjected;
using UnityEngine;

public class RenderCameraToTextures : MonoBehaviour
{
	private sealed class _003CCaptureFrames_003Ed__10(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public RenderCameraToTextures _003C_003E4__this;

		private int _003Cwidth_003E5__2;

		private int _003Cheight_003E5__3;

		private RenderTexture _003Crt_003E5__4;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0153: Expected I4, but got I8
			//IL_0099: Expected O, but got Ref
			//IL_01dd: Expected O, but got I4
			//IL_01fd: Expected O, but got Ref
			//IL_0261: Expected O, but got Ref
			//IL_05c2: Expected I, but got O
			//IL_032f: Expected O, but got Ref
			//IL_0438->IL0505: Incompatible stack heights: 1 vs 0
			RenderCameraToTextures renderCameraToTextures = _003C_003E4__this;
			System.ParamsArray paramsArray2 = default(System.ParamsArray);
			RenderTextureFormat renderTextureFormat = default(RenderTextureFormat);
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
					int num = default(int);
					_003Cwidth_003E5__2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
					int num2 = default(int);
					_003Cheight_003E5__3 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg = default(object);
					object arg2 = default(object);
					System.ParamsArray paramsArray = new System.ParamsArray(arg, arg2);
					string message = string.FormatHelper((IFormatProvider)null, "Starting capture at resolution: {0}x{1}", (System.ParamsArray)(&paramsArray2));
					Debug.Log(message);
					RenderTexture renderTexture = new RenderTexture(_003Cwidth_003E5__2, _003Cheight_003E5__3, 0, renderTextureFormat);
					_003Crt_003E5__4 = renderTexture;
					if ((object)renderCameraToTextures.captureCamera != null)
					{
						renderCameraToTextures.captureCamera.targetTexture = _003Crt_003E5__4;
						goto IL_04e3;
					}
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_0505;
				}
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null && (object)renderCameraToTextures.captureCamera != null)
				{
					renderCameraToTextures.captureCamera.Render();
					RenderTexture.SetActive(_003Crt_003E5__4);
					bool linear = default(bool);
					IntPtr nativeTex = default(IntPtr);
					bool createUninitialized = default(bool);
					Texture2D texture2D = new Texture2D(_003Cwidth_003E5__2, _003Cheight_003E5__3, TextureFormat.RGBA32, (int)renderTextureFormat, linear, nativeTex, createUninitialized, (MipmapLimitDescriptor)1);
					if ((object)texture2D != null)
					{
						_003CCaptureFrames_003Ed__10 obj = default(_003CCaptureFrames_003Ed__10);
						texture2D.ReadPixels((Rect)(&obj), 0, 0);
						if ((object)texture2D != null)
						{
							texture2D.Apply(updateMipmaps: true, makeNoLongerReadable: false);
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
							object arg3 = default(object);
							System.ParamsArray paramsArray = new System.ParamsArray(renderCameraToTextures.baseFileName, arg3);
							string path = string.FormatHelper((IFormatProvider)null, "{0}_{1:D04}.png", (System.ParamsArray)(&paramsArray2));
							string text = Path.Combine(renderCameraToTextures.outputFolder, path);
							Texture2D tex = default(Texture2D);
							byte[] array = ImageConversion.EncodeToPNG(tex);
							if (text != null)
							{
								if (text._stringLength != 0)
								{
									if (array != null)
									{
										File.InternalWriteAllBytes(text, array);
										Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
										object arg4 = default(object);
										paramsArray2 = new System.ParamsArray(arg4, text);
										System.ParamsArray paramsArray3 = default(System.ParamsArray);
										string message2 = string.FormatHelper((IFormatProvider)null, "Saved frame {0} to {1}", (System.ParamsArray)(&paramsArray3));
										Debug.Log(message2);
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186951B60");
										_003CCaptureFrames_003Ed__10 obj2 = null;
										int currentFrame = renderCameraToTextures.currentFrame + 1;
										renderCameraToTextures.currentFrame = currentFrame;
										obj2 = null;
										goto IL_04e3;
									}
									ArgumentNullException ex = new ArgumentNullException("bytes");
									ex._002Ector("bytes");
									throw ex;
								}
								ArgumentException ex2 = new ArgumentException("Empty path name is not legal.", "path");
								throw ex2;
							}
							ArgumentNullException ex3 = new ArgumentNullException("path", "Path cannot be null.");
							throw ex3;
						}
					}
				}
			}
			goto IL_0438;
			IL_0438:
			throw new NullReferenceException();
			IL_0505:
			return false;
			IL_04e3:
			if (renderCameraToTextures.capturing && renderCameraToTextures.currentFrame < renderCameraToTextures.frameCount)
			{
				WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
				_003C_003E2__current = waitForEndOfFrame;
				_003C_003E1__state = 1;
				return true;
			}
			ArgumentNullException captureCamera = (ArgumentNullException)(object)renderCameraToTextures.captureCamera;
			if ((object)renderCameraToTextures.captureCamera == null)
			{
				goto IL_0438;
			}
			bool flag = ((Exception)captureCamera)._className == null;
			Camera.set_targetTexture_Injected((IntPtr)((Exception)captureCamera)._className, (IntPtr)0);
			RenderTexture.SetActive_Injected((IntPtr)0);
			UnityEngine.Object.Destroy(_003Crt_003E5__4, 0f);
			Debug.Log("Frame capture complete.");
			renderCameraToTextures.capturing = false;
			goto IL_0505;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	public Camera captureCamera;

	public int frameCount;

	public string outputFolder;

	public string baseFileName;

	private int currentFrame;

	private bool capturing;

	private Vector2 ScreenRes;

	private void Start()
	{
		Camera camera = captureCamera;
		if ((object)captureCamera == null || ((UnityEngine.Object)camera).m_CachedPtr == (IntPtr)0)
		{
			Camera main = Camera.main;
			captureCamera = main;
		}
		ValidateAndCreateOutputFolder();
	}

	private static Vector2 GetMainGameViewSize()
	{
		//IL_0099: Expected I, but got O
		//IL_00fa: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7D50");
		object obj = default(object);
		if (obj != null)
		{
			if ("GetSizeOfMainGameView" == null)
			{
				ArgumentNullException ex = new ArgumentNullException("name");
				ex._002Ector("name");
				throw ex;
			}
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v145 @ rcx_v14+788] (should have been resolved before IL gen)");
			object obj3 = default(object);
			if (obj3 != null)
			{
				object obj4 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v193 @ rcx_v17+338] (should have been resolved before IL gen)");
				nint num = (nint)typeof(Vector2);
				object obj5 = default(object);
				if (obj5 != null)
				{
					object obj6 = obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rdx_v9+40]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ r8_v8 (Il2CppClass<UnityEngine.Vector2>)+40]");
					if (num2 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v16+10]");
						return (Vector2)0;
					}
					goto IL_013e;
				}
			}
		}
		NullReferenceException ex2 = new NullReferenceException();
		goto IL_013e;
		IL_013e:
		throw new InvalidCastException();
	}

	public void StartCapture()
	{
		//IL_0084: Expected I, but got O
		//IL_00d2: Expected O, but got I
		if (!capturing)
		{
			capturing = true;
			currentFrame = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7D50");
			if ("GetSizeOfMainGameView" == null)
			{
				ArgumentNullException ex = new ArgumentNullException("name");
				ex._002Ector("name");
				throw ex;
			}
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v269 @ rcx_v15+788] (should have been resolved before IL gen)");
			object obj4 = default(object);
			object obj3 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v291 @ rcx_v18+338] (should have been resolved before IL gen)");
			nint num = (nint)typeof(Vector2);
			object obj6 = default(object);
			object obj5 = obj6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rdx_v8+40]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ r8_v7 (Il2CppClass<UnityEngine.Vector2>)+40]");
			if (num2 != 0)
			{
				throw new InvalidCastException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v18+10]");
			ScreenRes = (Vector2)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v18+14]");
			_ = 0;
			_003CCaptureFrames_003Ed__10 obj7 = null;
			obj7._003C_003E1__state = 0;
			obj7._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj7);
		}
		else
		{
			Debug.LogWarning("Capture is already in progress.");
		}
	}

	private IEnumerator CaptureFrames()
	{
		_003CCaptureFrames_003Ed__10 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public void ValidateAndCreateOutputFolder()
	{
		string text = outputFolder;
		if (outputFolder == null || text._stringLength <= 0)
		{
			Debug.LogWarning("Output folder path is empty. Using default 'CapturedFrames' folder.");
			string dataPath = Application.dataPath;
			string text2 = Path.Combine(dataPath, "CapturedFrames");
			outputFolder = text2;
		}
		if (!Directory.Exists(outputFolder))
		{
			DirectoryInfo directoryInfo = Directory.CreateDirectory(outputFolder);
			string message = "Created directory: " + outputFolder;
			Debug.Log(message);
		}
	}

	public void OpenOutputFolderInExplorer()
	{
		if (!Directory.Exists(outputFolder))
		{
			string message = "Directory does not exist: " + outputFolder;
			Debug.LogWarning(message);
			return;
		}
		ProcessStartInfo processStartInfo = new ProcessStartInfo();
		processStartInfo.useShellExecute = true;
		processStartInfo.fileName = outputFolder;
		Process process = Process.Start(processStartInfo);
	}

	public RenderCameraToTextures()
	{
		//IL_0063: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F1CE]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		frameCount = 10;
		outputFolder = "CapturedFrames";
		baseFileName = "Frame";
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rcx_v6 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
