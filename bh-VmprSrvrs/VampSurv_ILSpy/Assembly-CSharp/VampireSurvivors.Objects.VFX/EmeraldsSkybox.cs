using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Framework;
using VampireSurvivors.Signals;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.Objects.VFX;

public class EmeraldsSkybox : GameMonoBehaviour
{
	private RenderTexture RenderTexture;

	private MeshRenderer BlitRenderer;

	private Camera _cam;

	private List<Material> CloudMaterials;

	private ParticleSystem FloatingDoorsFX;

	private bool _initialised;

	private Transform BlitRendererCachedTransform;

	private Material FloorMaterial;

	private Camera MainCam;

	private bool _shouldBeVisible;

	private SignalBus _signalBus;

	private void Start()
	{
		Initialise();
	}

	private void Construct(SignalBus signalBus)
	{
		_signalBus = signalBus;
	}

	private void Initialise()
	{
		//IL_012d: Expected I4, but got O
		//IL_03af: Expected I4, but got I8
		//IL_03af: Expected I, but got O
		//IL_010f->IL0276: Incompatible stack heights: 1 vs 0
		//IL_0375->IL0276: Incompatible stack heights: 2 vs 0
		//IL_0147->IL0276: Incompatible stack heights: 2 vs 0
		//IL_0175->IL0276: Incompatible stack heights: 2 vs 0
		//IL_01af->IL0276: Incompatible stack heights: 2 vs 0
		//IL_01d8->IL0276: Incompatible stack heights: 3 vs 0
		//IL_021c->IL0276: Incompatible stack heights: 3 vs 0
		//IL_025b->IL0276: Incompatible stack heights: 3 vs 0
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			GameObject gameObject = base.gameObject;
			if (core._diContainer != null)
			{
				core._diContainer.InjectGameObject(gameObject);
				Camera mainCam = MainCam;
				if ((object)MainCam == null || ((UnityEngine.Object)mainCam).m_CachedPtr == (IntPtr)0)
				{
					Camera main = Camera.main;
					MainCam = main;
				}
				Transform transform = base.transform;
				object obj = default(object);
				float num = (float)obj * -2000f;
				float num2 = (float)Vector3.forwardVector * -2000f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v582 @ rax_v30 (UnityEngine.Transform)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v582 @ rax_v30 (UnityEngine.Transform)+10]");
				Vector3 value = default(Vector3);
				Transform.set_position_Injected((IntPtr)0, ref value);
				Transform blitRendererCachedTransform = BlitRenderer.transform;
				BlitRendererCachedTransform = blitRendererCachedTransform;
				int2 renderTextureSize = CameraExtensions.GetRenderTextureSize(MainCam);
				Action<GameplaySignals.SetBackgroundVisible> renderTexture = (Action<GameplaySignals.SetBackgroundVisible>)(object)RenderTexture;
				if ((object)RenderTexture != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rsi_v10 (System.Action`1<VampireSurvivors.Signals.GameplaySignals+SetBackgroundVisible>)+10]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rsi_v10 (System.Action`1<VampireSurvivors.Signals.GameplaySignals+SetBackgroundVisible>)+10]");
					RenderTexture.Release_Injected((IntPtr)0);
					if ((object)RenderTexture != null)
					{
						RenderTexture.width = (int)renderTextureSize;
						if ((object)RenderTexture != null)
						{
							int height = default(int);
							RenderTexture.height = height;
							if ((object)_cam != null)
							{
								_cam.targetTexture = RenderTexture;
								DiContainer blitRenderer = (DiContainer)(object)BlitRenderer;
								if ((object)BlitRenderer != null)
								{
									bool flag3 = blitRenderer._decorators == null;
									Renderer.set_sortingOrder_Injected((IntPtr)blitRenderer._decorators, -9000);
									_initialised = true;
									UpdateShader();
									Action<GameplaySignals.SetBackgroundVisible> action = null;
									((EmeraldsSkybox)(object)action).SetBackgroundVisible((GameplaySignals.SetBackgroundVisible)this);
									if (_signalBus != null)
									{
										((EmeraldsSkybox)(object)_signalBus).SetBackgroundVisible((GameplaySignals.SetBackgroundVisible)action);
										Action action2 = OnGameQuit;
										if (_signalBus != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004010");
											Action action3 = OnGameQuit;
											if (_signalBus != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004190");
												_shouldBeVisible = true;
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
		}
		throw new NullReferenceException();
	}

	private unsafe void OnGameQuit()
	{
		//IL_0115: Expected O, but got Ref
		//IL_0184->IL008b: Incompatible stack heights: 1 vs 0
		_initialised = false;
		if (CloudMaterials != null)
		{
			List<Material>.Enumerator enumerator = default(List<Material>.Enumerator);
			while (enumerator.MoveNext())
			{
				Material material = null;
			}
			object cam = _cam;
			bool flag = (object)_cam == null;
			EmeraldsSkybox emeraldsSkybox = (EmeraldsSkybox)(&enumerator);
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rbx_v7 (System.Object)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rbx_v7 (System.Object)+10]");
				Camera.set_targetTexture_Injected((IntPtr)0, (IntPtr)0);
				object cam2 = _cam;
				if ((object)_cam != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbx_v8 (System.Object)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbx_v8 (System.Object)+10]");
					Behaviour.set_enabled_Injected((IntPtr)0, false);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void SetBackgroundVisible(GameplaySignals.SetBackgroundVisible signal)
	{
		//IL_000a: Expected I4, but got O
		_shouldBeVisible = (byte)(int)signal != 0;
	}

	protected override void OnUpdate()
	{
	}

	protected void LateUpdate()
	{
		Camera main = Camera.main;
		if ((object)main != null)
		{
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				object blitRendererCachedTransform = BlitRendererCachedTransform;
				bool flag2 = (object)BlitRendererCachedTransform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rdi_v7 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rdi_v7 (System.Object)+10]");
				Vector3 value = default(Vector3);
				Transform.set_position_Injected((IntPtr)0, ref value);
				if (_initialised)
				{
					UpdateShader();
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void UpdateShader()
	{
		//IL_04ed: Expected I, but got O
		//IL_00f9: Expected O, but got I4
		//IL_0029: Expected I, but got O
		//IL_009c: Expected I, but got O
		//IL_03ca: Expected O, but got I4
		//IL_01d5->IL02ef: Incompatible stack heights: 1 vs 0
		nint num = (nint)typeof(PauseSystem);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (Il2CppClass<PauseSystem>)+B8]");
		nint num2 = 0;
		if (PauseSystem._paused)
		{
			goto IL_00f0;
		}
		nint num3 = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v90 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num4 = 0;
		GameManager core = GM.Core;
		Transform transform;
		if ((object)GM.Core != null)
		{
			PlayerOptions playerOptions = core._playerOptions;
			if (core._playerOptions != null)
			{
				num2 = (nint)playerOptions._mainGameConfig;
				if (playerOptions._mainGameConfig != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rcx_v72 (Il2CppStaticFields<PauseSystem>)+283]");
					if ((nint)0 != 0)
					{
						goto IL_00f0;
					}
					transform = null;
					goto IL_0300;
				}
			}
		}
		goto IL_02ef;
		IL_00f0:
		transform = (Transform)1;
		goto IL_0300;
		IL_0225:
		int2 renderTextureSize = CameraExtensions.GetRenderTextureSize(MainCam);
		object obj = (object)renderTextureSize >> 32;
		float num5 = (float)renderTextureSize / 100f;
		float num6 = (float)obj / 100f;
		float num7 = num5 / num6;
		if (!(1.7777778f > num7))
		{
			if (num7 > 1.7777778f)
			{
				num7 = num5 / 1.7777778f;
			}
		}
		else
		{
			num7 = num6 * 1.7777778f;
		}
		object blitRenderer = BlitRenderer;
		bool flag = (object)BlitRenderer == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v842 @ rbx_v13 (System.Object)+10]");
		bool flag2 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v842 @ rbx_v13 (System.Object)+10]");
		IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
		Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
		bool flag3 = (object)transform2 == null;
		bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
		return;
		IL_0300:
		if (CloudMaterials != null)
		{
			List<Material>.Enumerator enumerator = default(List<Material>.Enumerator);
			while (enumerator.MoveNext())
			{
				Material material = null;
			}
			object floatingDoorsFX = FloatingDoorsFX;
			bool num8;
			if ((object)transform == null)
			{
				bool flag5 = (object)FloatingDoorsFX == null;
				num4 = (nint)(&enumerator);
				if (!flag5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rbx_v11 (System.Object)+10]");
					bool flag6 = (nint)0 == 0;
					num8 = flag6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rbx_v11 (System.Object)+10]");
					object obj2 = ParticleSystem.get_isPaused_Injected((IntPtr)0);
					if (obj2 != null)
					{
						if ((object)FloatingDoorsFX == null)
						{
							goto IL_02ef;
						}
						FloatingDoorsFX.Play(withChildren: true);
					}
					goto IL_0225;
				}
			}
			else
			{
				bool flag7 = (object)FloatingDoorsFX == null;
				num4 = (nint)(&enumerator);
				if (!flag7)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rbx_v11 (System.Object)+10]");
					bool flag8 = (nint)0 == 0;
					num8 = flag8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rbx_v11 (System.Object)+10]");
					ParticleSystem.Pause_Injected((IntPtr)0, true);
					goto IL_0225;
				}
			}
		}
		goto IL_02ef;
		IL_02ef:
		throw new NullReferenceException();
	}

	protected override void OnDestroy()
	{
		Action<GameplaySignals.SetBackgroundVisible> action = null;
		((EmeraldsSkybox)(object)action).SetBackgroundVisible((GameplaySignals.SetBackgroundVisible)this);
		((EmeraldsSkybox)(object)_signalBus).SetBackgroundVisible((GameplaySignals.SetBackgroundVisible)action);
		Action action2 = OnGameQuit;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800043D0");
		Action action3 = OnGameQuit;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004490");
		Camera cam = _cam;
		_initialised = false;
		if ((object)_cam != null && ((UnityEngine.Object)cam).m_CachedPtr != (IntPtr)0)
		{
			_cam.targetTexture = null;
		}
	}

	public EmeraldsSkybox()
	{
		List<Material> cloudMaterials = new List<Material>();
		CloudMaterials = cloudMaterials;
		base._onResumeSent = true;
	}
}
