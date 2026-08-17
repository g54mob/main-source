using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class RainbowCheckerboard : GameMonoBehaviour
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

	private float _angle;

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
		Renderer.set_sortingOrder_Injected(((UnityEngine.Object)blitRenderer).m_CachedPtr, -10000);
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
		object cachedTransform = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rbx_v2 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rbx_v2 (System.Object)+10]");
		Vector3 value = default(Vector3);
		Transform.set_position_Injected((IntPtr)0, ref value);
	}

	private unsafe void UpdateShader()
	{
		//IL_00e8: Expected O, but got Ref
		//IL_0161: Expected O, but got Ref
		//IL_00d0->IL0162: Incompatible stack heights: 1 vs 0
		//IL_0123->IL0162: Incompatible stack heights: 1 vs 0
		//IL_014f->IL0162: Incompatible stack heights: 1 vs 0
		int num = Shader.PropertyToID("_Alpha");
		if ((object)_shaderRTMaterial != null)
		{
			_shaderRTMaterial.SetFloatImpl(num, alpha);
			float num2 = (float)CameraExtensions.OrthographicBoundsIgnoringBorders(_mainCam).m_Extents * 2f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v14 (UnityEngine.Bounds)+10]");
			float num3 = 0f * 2f;
			if (num2 < num3)
			{
			}
			Transform transform = _blitRenderer.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			int nameID = Shader.PropertyToID("_TargetSize");
			int width = _renderTexture.width;
			int height = _renderTexture.height;
			if ((object)_shaderRTMaterial != null)
			{
				float num4 = default(float);
				_shaderRTMaterial.SetVector(nameID, (Vector4)(&num4));
				float angle = _angle + 0.25f;
				_angle = angle;
				if ((object)_blitRenderer != null)
				{
					Transform transform2 = _blitRenderer.transform;
					if ((object)transform2 != null)
					{
						transform2.localEulerAngles = (Vector3)(&value);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public RainbowCheckerboard()
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
