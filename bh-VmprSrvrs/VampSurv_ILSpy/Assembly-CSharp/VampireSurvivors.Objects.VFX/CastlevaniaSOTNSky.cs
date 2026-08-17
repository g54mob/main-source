using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Signals;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.Objects.VFX;

public class CastlevaniaSOTNSky : GameMonoBehaviour
{
	private static readonly int MainTexMultiply;

	private bool IsWithinPlatformingArea;

	private Vector2 BottomLeftPlatformingArea;

	private Vector2 TopRightPlatformingArea;

	private float PlatformingSkyboxHeight;

	private float PlatformingGizmoWidth;

	private float PlatformingGizmoHeight;

	private float BlitRendererPlatformScale;

	private RenderTexture RenderTexture;

	private MeshRenderer BlitRenderer;

	private Camera _cam;

	private MeshRenderer FloorRenderer;

	private ParticleSystem CloudFX;

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
		//IL_0147: Expected I4, but got O
		//IL_019f: Expected I4, but got O
		//IL_01e8: Expected I, but got O
		//IL_053d: Expected I4, but got I8
		//IL_03d2: Expected O, but got I4
		//IL_03d2: Expected O, but got I
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e0: Expected O, but got Unknown
		//IL_0581: Expected O, but got I
		//IL_010f->IL03fe: Incompatible stack heights: 1 vs 0
		//IL_04fd->IL03fe: Incompatible stack heights: 2 vs 0
		//IL_0171->IL03fe: Incompatible stack heights: 2 vs 0
		//IL_01c8->IL03fe: Incompatible stack heights: 2 vs 0
		//IL_0202->IL03fe: Incompatible stack heights: 2 vs 0
		//IL_0557->IL03fe: Incompatible stack heights: 3 vs 0
		//IL_0273->IL03fe: Incompatible stack heights: 3 vs 0
		//IL_02b7->IL03fe: Incompatible stack heights: 3 vs 0
		//IL_02f6->IL03fe: Incompatible stack heights: 3 vs 0
		//IL_0335->IL03fe: Incompatible stack heights: 3 vs 0
		//IL_0394->IL03fe: Incompatible stack heights: 3 vs 0
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
				float num = (float)obj * 1000f;
				float num2 = (float)Vector3.downVector * 1000f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v649 @ rax_v30 (UnityEngine.Transform)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v649 @ rax_v30 (UnityEngine.Transform)+10]");
				Vector3 value = default(Vector3);
				Transform.set_position_Injected((IntPtr)0, ref value);
				Transform blitRendererCachedTransform = BlitRenderer.transform;
				BlitRendererCachedTransform = blitRendererCachedTransform;
				int2 renderTextureSize = CameraExtensions.GetRenderTextureSize(MainCam);
				Action<GameplaySignals.SetBackgroundVisible> renderTexture = (Action<GameplaySignals.SetBackgroundVisible>)(object)RenderTexture;
				if ((object)RenderTexture != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rsi_v10 (System.Action`1<VampireSurvivors.Signals.GameplaySignals+SetBackgroundVisible>)+10]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rsi_v10 (System.Action`1<VampireSurvivors.Signals.GameplaySignals+SetBackgroundVisible>)+10]");
					RenderTexture.Release_Injected((IntPtr)0);
					if ((object)RenderTexture != null)
					{
						object obj2 = (object)renderTextureSize >> 31;
						object obj3 = (object)renderTextureSize - obj2;
						int width = obj3 >> 1;
						RenderTexture.width = width;
						if ((object)RenderTexture != null)
						{
							object obj5 = default(object);
							object obj4 = obj5 >> 31;
							object obj6 = obj5 - obj4;
							int height = obj6 >> 1;
							RenderTexture.height = height;
							if ((object)_cam != null)
							{
								_cam.targetTexture = RenderTexture;
								nint num3 = (nint)BlitRenderer;
								if ((object)BlitRenderer != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rbx_v14 (Il2CppMethodInfo)+10]");
									bool flag3 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rbx_v14 (Il2CppMethodInfo)+10]");
									Renderer.set_sortingOrder_Injected((IntPtr)0, -9000);
									if ((object)FloorRenderer != null)
									{
										Material material = ((Renderer)FloorRenderer).GetMaterial();
										FloorMaterial = material;
										UpdateShader(isInPlatformingArea: false);
										_initialised = true;
										Action<GameplaySignals.SetBackgroundVisible> action = null;
										((CastlevaniaSOTNSky)(object)action).SetBackgroundVisible((GameplaySignals.SetBackgroundVisible)this);
										if (_signalBus != null)
										{
											((CastlevaniaSOTNSky)(object)_signalBus).SetBackgroundVisible((GameplaySignals.SetBackgroundVisible)action);
											Action action2 = OnGameQuit;
											if (_signalBus != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004010");
												Action action3 = OnGameQuit;
												if (_signalBus != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004190");
													Action action4 = DisableBackground;
													if (_signalBus != null)
													{
														nint num4 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rbx_v19 (Il2CppMethodInfo)+38]");
														if ((nint)0 == 0)
														{
														}
														object obj7 = null;
														if (obj7 != null)
														{
															Action<object> action5 = ((SignalBus._003C_003Ec__DisplayClass35_0<GameplaySignals.DisableThosePeopleBackground>)obj7)._003CSubscribeId_003Eb__0;
															((SignalBus._003C_003Ec__DisplayClass35_0<GameplaySignals.DisableThosePeopleBackground>)0)._003CSubscribeId_003Eb__0((object)1);
															object obj9 = default(object);
															object obj8 = obj9 + 32;
															Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
															SignalBus signalBus = _signalBus;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rax_v77 (System.Object)+10]");
															Type signalType = default(Type);
															Action<object> callback = default(Action<object>);
															signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
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
				}
			}
		}
		throw new NullReferenceException();
	}

	private void OnGameQuit()
	{
		Camera cam = _cam;
		_initialised = false;
		bool flag = ((UnityEngine.Object)cam).m_CachedPtr == (IntPtr)0;
		Camera.set_targetTexture_Injected(((UnityEngine.Object)cam).m_CachedPtr, (IntPtr)0);
		_cam.enabled = false;
	}

	private void SetBackgroundVisible(GameplaySignals.SetBackgroundVisible signal)
	{
		//IL_000a: Expected I4, but got O
		_shouldBeVisible = (byte)(int)signal != 0;
	}

	private void DisableBackground()
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	protected override void OnUpdate()
	{
	}

	protected unsafe void LateUpdate()
	{
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected F8, but got Unknown
		//IL_0126: Expected O, but got I
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected F8, but got Unknown
		//IL_016d: Expected F8, but got I
		//IL_016d: Expected F8, but got O
		//IL_01a3: Expected F4, but got I4
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_0208: Invalid comparison between F4 and O
		//IL_0237: Invalid comparison between F4 and I4
		//IL_02b9: Invalid comparison between I4 and F4
		//IL_03f0->IL032c: Incompatible stack heights: 1 vs 0
		//IL_047e->IL032c: Incompatible stack heights: 3 vs 0
		//IL_049b->IL032c: Incompatible stack heights: 3 vs 0
		//IL_050e->IL032c: Incompatible stack heights: 3 vs 0
		//IL_0299->IL032c: Incompatible stack heights: 3 vs 0
		//IL_0318->IL032c: Incompatible stack heights: 3 vs 0
		//IL_02ea->IL032c: Incompatible stack heights: 3 vs 0
		Camera main = Camera.main;
		bool flag3;
		if ((object)main != null)
		{
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector2 ret;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
				Vector2 vector = ret;
				Vector2 bottomLeftPlatformingArea = BottomLeftPlatformingArea;
				if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) >= System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref bottomLeftPlatformingArea))
				{
					Vector2 topRightPlatformingArea = TopRightPlatformingArea;
					if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref topRightPlatformingArea) >= System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref ret))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.VFX.CastlevaniaSOTNSky)+30]");
						Vector2 vector2 = default(Vector2);
						if ((nint)vector2 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.VFX.CastlevaniaSOTNSky)+38]");
							bool flag2 = 0 < (nint)vector2;
							flag3 = !flag2;
							goto IL_03a9;
						}
					}
				}
				flag3 = false;
				goto IL_03a9;
			}
		}
		goto IL_032c;
		IL_032c:
		throw new NullReferenceException();
		IL_03a9:
		IsWithinPlatformingArea = flag3;
		if (flag3)
		{
		}
		object blitRendererCachedTransform = BlitRendererCachedTransform;
		if ((object)BlitRendererCachedTransform != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbp_v8 (System.Object)+10]");
			bool flag4 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbp_v8 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out Vector3 _);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbp_v8 (System.Object)+10]");
			bool flag5 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbp_v8 (System.Object)+10]");
			Vector3 value = default(Vector3);
			Transform.set_position_Injected((IntPtr)0, ref value);
			if (_initialised)
			{
				UpdateShader(IsWithinPlatformingArea);
			}
			object obj = TopRightPlatformingArea - BottomLeftPlatformingArea;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			double num = obj & 0;
			PlatformingGizmoWidth = (float)num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.VFX.CastlevaniaSOTNSky)+38]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.VFX.CastlevaniaSOTNSky)+30]");
			object obj2 = num2 - 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			double num3 = obj2 & 0;
			PlatformingGizmoHeight = (float)num3;
			Vector2 bottomLeftPlatformingArea2 = BottomLeftPlatformingArea;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.VFX.CastlevaniaSOTNSky)+30]");
			Color colour = default(Color);
			VSDebug.DrawDebugRect((double)bottomLeftPlatformingArea2, 0.0, num, num3, colour);
			float num4 = ((!_shouldBeVisible) ? 0f : 1f);
			if ((object)BlitRenderer != null)
			{
				Material material = ((Renderer)BlitRenderer).GetMaterial();
				if ((object)material != null)
				{
					float floatImpl = material.GetFloatImpl(MainTexMultiply);
					float deltaTime = PauseSystem.DeltaTime;
					float num5 = num4 - floatImpl;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					object obj3 = num5 & 0;
					float num9;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)deltaTime) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
					{
						float num6 = num4 - floatImpl;
						bool flag6 = !(num6 < 0f);
						float num7 = 1f;
						if (!flag6)
						{
							num7 = -1f;
						}
						float num8 = num7 * deltaTime;
						num9 = num8 + floatImpl;
					}
					else
					{
						num9 = num4;
					}
					if ((object)BlitRenderer != null)
					{
						Material material2 = ((Renderer)BlitRenderer).GetMaterial();
						if ((object)material2 != null)
						{
							material2.SetFloatImpl(MainTexMultiply, num9);
							bool flag7;
							if (0f < num9)
							{
								if ((object)BlitRenderer == null)
								{
									goto IL_032c;
								}
								flag7 = true;
							}
							else
							{
								if ((object)BlitRenderer == null)
								{
									goto IL_032c;
								}
								flag7 = false;
							}
							BlitRenderer.enabled = flag7;
							return;
						}
					}
				}
			}
		}
		goto IL_032c;
	}

	private void UpdateShader(bool isInPlatformingArea)
	{
		//IL_00ac: Expected F4, but got I4
		//IL_00b5: Expected O, but got I4
		//IL_0086: Expected O, but got I4
		Material floorMaterial;
		int num;
		float value;
		object obj;
		if (!PauseSystem._paused)
		{
			GameManager core = GM.Core;
			PlayerOptions playerOptions = core._playerOptions;
			PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
			if (!mainGameConfig._003CDisableMovingBackground_003Ek__BackingField)
			{
				floorMaterial = FloorMaterial;
				num = Shader.PropertyToID("_SpeedMultiply");
				value = 1f;
				obj = 0;
				goto IL_00ba;
			}
		}
		floorMaterial = FloorMaterial;
		num = Shader.PropertyToID("_SpeedMultiply");
		value = 0f;
		obj = 1;
		goto IL_00ba;
		IL_00ba:
		floorMaterial.SetFloatImpl(num, value);
		if (obj == null)
		{
			if (CloudFX.isPaused)
			{
				CloudFX.Play(withChildren: true);
			}
		}
		else
		{
			CloudFX.Pause();
		}
		int2 renderTextureSize = CameraExtensions.GetRenderTextureSize(MainCam);
		object obj2 = (object)renderTextureSize >> 32;
		float num2 = (float)renderTextureSize / 100f;
		float num3 = (float)obj2 / 100f;
		float num4 = num2 / num3;
		if (!(1.7777778f > num4))
		{
			if (num4 > 1.7777778f)
			{
				num4 = num2 / 1.7777778f;
			}
		}
		else
		{
			num4 = num3 * 1.7777778f;
		}
		Transform transform = default(Transform);
		if (!isInPlatformingArea)
		{
			transform = BlitRenderer.transform;
		}
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
	}

	protected override void OnDestroy()
	{
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		if (_signalBus == null)
		{
			goto IL_0125;
		}
		Action<GameplaySignals.SetBackgroundVisible> action = null;
		((CastlevaniaSOTNSky)(object)action).SetBackgroundVisible((GameplaySignals.SetBackgroundVisible)this);
		((CastlevaniaSOTNSky)(object)_signalBus).SetBackgroundVisible((GameplaySignals.SetBackgroundVisible)action);
		Action action2 = OnGameQuit;
		if (_signalBus != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800043D0");
			Action action3 = OnGameQuit;
			if (_signalBus != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004490");
				Action token = DisableBackground;
				if (_signalBus != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
					object obj2 = default(object);
					object obj = obj2 + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					Type signalType = default(Type);
					bool throwIfMissing = default(bool);
					_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
					goto IL_0125;
				}
			}
		}
		goto IL_01ee;
		IL_0125:
		Material floorMaterial = FloorMaterial;
		if ((object)FloorMaterial != null && ((UnityEngine.Object)floorMaterial).m_CachedPtr != (IntPtr)0)
		{
			int num = Shader.PropertyToID("_SpeedMultiply");
			if ((object)FloorMaterial == null)
			{
				goto IL_01ee;
			}
			FloorMaterial.SetFloatImpl(num, 1f);
		}
		SignalBus cam = (SignalBus)(object)_cam;
		_initialised = false;
		if ((object)_cam != null)
		{
			bool flag = cam._subscriptionPool == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 387 ConditionalJump @-1, v378 @ ZF_v15 (System.Boolean) --- -1 Nop");
			/*Error: End of method reached without returning.*/;
		}
		goto IL_01ee;
		IL_01ee:
		throw new NullReferenceException();
	}

	public CastlevaniaSOTNSky()
	{
		//IL_0036: Expected I, but got O
		PlatformingSkyboxHeight = 20f;
		BlitRendererPlatformScale = 1.5f;
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	static CastlevaniaSOTNSky()
	{
		int mainTexMultiply = Shader.PropertyToID("_MainTexMultiply");
		MainTexMultiply = mainTexMultiply;
	}
}
