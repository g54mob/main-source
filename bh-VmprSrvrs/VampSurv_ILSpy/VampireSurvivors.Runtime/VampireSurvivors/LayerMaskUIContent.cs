using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors;

public class LayerMaskUIContent : MonoBehaviour
{
	private RenderTexture _renderTex;

	private Camera _camera;

	private RawImage _image;

	private void OnEnable()
	{
		//IL_0624: Expected O, but got I4
		//IL_0427: Expected O, but got I4
		//IL_046a: Expected I4, but got O
		//IL_0493: Expected I4, but got O
		//IL_04d3: Expected O, but got I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_00a0: Expected I, but got O
		//IL_05b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bc: Expected O, but got Unknown
		//IL_0503->IL0412: Incompatible stack heights: 1 vs 0
		//IL_00fd->IL0412: Incompatible stack heights: 1 vs 0
		//IL_00c3->IL00c3: Incompatible stack heights: 2 vs 1
		//IL_0138->IL0412: Incompatible stack heights: 1 vs 0
		//IL_0173->IL0412: Incompatible stack heights: 1 vs 0
		//IL_019f->IL0412: Incompatible stack heights: 1 vs 0
		//IL_01cb->IL0412: Incompatible stack heights: 1 vs 0
		//IL_0558->IL0412: Incompatible stack heights: 2 vs 0
		//IL_0211->IL0412: Incompatible stack heights: 2 vs 0
		//IL_05c9->IL0629: Incompatible stack heights: 6 vs 5
		object obj = Screen.width;
		object obj2 = Screen.height;
		RenderTextureFormat format = default(RenderTextureFormat);
		int height = default(int);
		int width = default(int);
		RenderTexture renderTex = new RenderTexture(width, height, 32, format);
		object obj3 = obj2 >> 31;
		object obj4 = obj2 - obj3;
		height = obj4 >> 1;
		object obj5 = obj >> 31;
		object obj6 = obj - obj5;
		width = obj6 >> 1;
		_renderTex = renderTex;
		RenderTexture renderTex2 = _renderTex;
		if ((object)_renderTex != null)
		{
			bool flag = ((UnityEngine.Object)renderTex2).m_CachedPtr == (IntPtr)0;
			object obj7 = RenderTexture.Create_Injected(((UnityEngine.Object)renderTex2).m_CachedPtr);
			Type[] array = new Type[1];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj9 = default(object);
			object obj8 = obj9 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			RenderTexture renderTexture2 = default(RenderTexture);
			RenderTexture renderTexture = renderTexture2;
			if (array != null)
			{
				if ((object)renderTexture != null)
				{
					nint num = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj10 = default(object);
					bool flag2 = obj10 == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				GameObject gameObject = new GameObject("Window Camera", array);
				if ((object)gameObject != null)
				{
					Camera component = gameObject.GetComponent<Camera>();
					_camera = component;
					if ((object)_camera != null)
					{
						Transform transform = _camera.transform;
						Transform parent = base.transform;
						if ((object)transform != null)
						{
							transform.parent = parent;
							if ((object)_camera != null)
							{
								Transform transform2 = _camera.transform;
								if ((object)transform2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ rax_v43 (UnityEngine.Transform)+10]");
									bool flag3 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ rax_v43 (UnityEngine.Transform)+10]");
									Vector3 value = default(Vector3);
									Transform.set_localPosition_Injected((IntPtr)0, ref value);
									if ((object)_camera != null)
									{
										_camera.orthographic = true;
										Transform transform3 = base.transform;
										if ((object)transform3 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v49 (UnityEngine.Transform)+10]");
											bool flag4 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v49 (UnityEngine.Transform)+10]");
											Transform.get_localScale_Injected((IntPtr)0, out Vector3 ret);
											bool flag5 = (object)_camera == null;
											float orthographicSize = (float)ret * 0.5f;
											_camera.orthographicSize = orthographicSize;
											string[] array2 = new string[1];
											bool flag6 = array2 == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											object obj11 = null;
											int num2 = 0;
											object obj12 = null;
											while ((nint)obj12 < array2.Length)
											{
												bool flag7 = (nint)obj11 >= array2.Length;
												int num3 = LayerMask.NameToLayer(array2[obj11]);
												if (num3 != -1)
												{
													int num4 = num3 & 0x1F;
													int num5 = 1 << num4;
													num2 |= num5;
												}
												obj11++;
												obj12 = obj11;
											}
											bool flag8 = (object)_camera == null;
											_camera.cullingMask = num2;
											object camera = _camera;
											bool flag9 = (object)_camera == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1106 @ rbx_v16 (System.Object)+10]");
											bool flag10 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1106 @ rbx_v16 (System.Object)+10]");
											Camera.set_forceIntoRenderTexture_Injected((IntPtr)0, true);
											bool flag11 = (object)_camera == null;
											_camera.targetTexture = _renderTex;
											RawImage componentInChildren = GetComponentInChildren<RawImage>();
											_image = componentInChildren;
											bool flag12 = (object)_image == null;
											_image.texture = _renderTex;
											bool flag13 = (object)_image == null;
											Canvas canvas = _image.canvas;
											bool flag14 = (object)canvas == null;
											canvas.worldCamera = _camera;
											return;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void OnDisable()
	{
		GameObject obj = _camera.gameObject;
		UnityEngine.Object.Destroy(obj, 0f);
	}

	public LayerMaskUIContent()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
