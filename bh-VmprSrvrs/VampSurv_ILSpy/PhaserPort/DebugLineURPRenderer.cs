using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Rendering;

public class DebugLineURPRenderer : MonoBehaviour
{
	private void OnEnable()
	{
		Action<ScriptableRenderContext, Camera> value = RenderPipelineManager_endCameraRendering;
		RenderPipelineManager.endCameraRendering += value;
	}

	private void OnDisable()
	{
		Action<ScriptableRenderContext, Camera> value = RenderPipelineManager_endCameraRendering;
		RenderPipelineManager.endCameraRendering -= value;
	}

	private void Update()
	{
		if (VSDebug.s_drawDebug)
		{
			List<Vector3> debugLineVerts = VSDebug._debugLineVerts;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rcx_v8 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			List<Color> debugLineColours = VSDebug._debugLineColours;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rdx_v3 (System.Collections.Generic.List`1<UnityEngine.Color>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			List<int> debugLineIndices = VSDebug._debugLineIndices;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v4 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
		}
	}

	private unsafe void RenderPipelineManager_endCameraRendering(ScriptableRenderContext context, Camera camera)
	{
		//IL_00c5: Expected O, but got Ref
		//IL_0145->IL00ca: Incompatible stack heights: 1 vs 0
		//IL_00ad->IL00ca: Incompatible stack heights: 1 vs 0
		//IL_00ca->IL00d6: Incompatible stack heights: 2 vs 0
		if (!VSDebug.s_drawDebug)
		{
			return;
		}
		if ((object)camera != null)
		{
			GameObject gameObject = camera.gameObject;
			if ((object)gameObject != null)
			{
				if (gameObject.CompareTag_Internal("MainCamera"))
				{
					return;
				}
				Transform transform = camera.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					Camera main = Camera.main;
					if ((object)main != null)
					{
						Transform transform2 = main.transform;
						if ((object)transform2 != null)
						{
							bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret2);
							VSDebug.FlushDebugLines((Vector3)(&ret2));
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public DebugLineURPRenderer()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
