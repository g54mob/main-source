using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class GottaSphereFast : GameMonoBehaviour
{
	public float alpha;

	private bool _initialised;

	private Transform _cachedTransform;

	private Camera _mainCam;

	private Material _shaderRTMaterial;

	private Mesh _quadMesh;

	private RenderTexture _renderTexture;

	private MeshRenderer _shaderMesh;

	private MeshRenderer _blitRenderer;

	private float _scrollX;

	private float _scrollY;

	private void Start()
	{
		Initialise();
	}

	private unsafe void Initialise()
	{
		//IL_0097: Expected O, but got Ref
		//IL_016b: Expected I4, but got I8
		Transform mainCam = (Transform)(object)_mainCam;
		if ((object)_mainCam == null || ((UnityEngine.Object)mainCam).m_CachedPtr == (IntPtr)0)
		{
			Camera main = Camera.main;
			_mainCam = main;
		}
		Transform cachedTransform = base.transform;
		_cachedTransform = cachedTransform;
		Material material = ((Renderer)_shaderMesh).GetMaterial();
		_shaderRTMaterial = material;
		Vector3 value = default(Vector3);
		_shaderRTMaterial.color = (Color)(&value);
		Transform transform = _blitRenderer.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		Transform blitRenderer = (Transform)(object)_blitRenderer;
		bool flag2 = ((UnityEngine.Object)blitRenderer).m_CachedPtr == (IntPtr)0;
		Renderer.set_sortingOrder_Injected(((UnityEngine.Object)blitRenderer).m_CachedPtr, -9000);
		UpdateShader();
		_initialised = true;
	}

	protected override void OnUpdate()
	{
		if (_initialised)
		{
			UpdateShader();
		}
	}

	protected void LateUpdate()
	{
		//IL_00c4->IL0069: Incompatible stack heights: 1 vs 0
		Camera main = Camera.main;
		if ((object)main != null)
		{
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				object cachedTransform = _cachedTransform;
				if ((object)_cachedTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ rsi_v8 (System.Object)+10]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ rsi_v8 (System.Object)+10]");
					Transform.get_position_Injected((IntPtr)0, out Vector3 _);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ rsi_v8 (System.Object)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ rsi_v8 (System.Object)+10]");
					Transform.set_position_Injected((IntPtr)0, ref ret);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void UpdateShader()
	{
		//IL_00ea: Expected F4, but got I
		//IL_0225: Expected O, but got Ref
		int num = Shader.PropertyToID("_Alpha");
		_shaderRTMaterial.SetFloatImpl(num, alpha);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873833E1h\"");
		if ((object)renderer.cameraVelocity == null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v60 (PhaserScene+Renderer)+40]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873833E1h\"");
			if (flag)
			{
				goto IL_01f0;
			}
		}
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer3 = s_scene3._renderer;
		PhaserScene s_scene4 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer4 = s_scene4._renderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rax_v43 (PhaserScene+Renderer)+40]");
		float num2 = 0f;
		int num3 = Shader.PropertyToID("_ScrollX");
		_shaderRTMaterial.SetFloatImpl(num3, _scrollX);
		int num4 = Shader.PropertyToID("_ScrollY");
		_shaderRTMaterial.SetFloatImpl(num4, _scrollY);
		GameManager core = GM.Core;
		Stage stage = core._stage;
		TilingTileset tilingTileset = stage._tilingTileset;
		if (tilingTileset._inverted)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config = core2._playerOptions.Config;
			if (config._003CVisuallyInvertStages_003Ek__BackingField)
			{
				num2 *= -1f;
			}
		}
		float scrollX = (float)renderer3.cameraVelocity + _scrollX;
		float scrollY = _scrollY - num2;
		_scrollX = scrollX;
		_scrollY = scrollY;
		goto IL_01f0;
		IL_01f0:
		int2 renderTextureSize = CameraExtensions.GetRenderTextureSize(_mainCam);
		int nameID = Shader.PropertyToID("_TargetSize");
		object obj = default(object);
		_shaderRTMaterial.SetVector(nameID, (Vector4)(&obj));
		Transform transform = _blitRenderer.transform;
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	public GottaSphereFast()
	{
		//IL_002b: Expected I, but got O
		alpha = 1f;
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
