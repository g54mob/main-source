using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Particles;

namespace VampireSurvivors.UI;

public class FireworksManager : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public ParticleSystem ps;

		internal void _003CMakeFireworkAtPosition_003Eb__0()
		{
			ps.Stop();
		}
	}

	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public ParticleSystem ps;

		internal void _003CMakeRandomFirework_003Eb__0()
		{
			ps.Stop();
		}
	}

	private Camera _RenderCam;

	private RawImage _RenderImage;

	private RectTransform _CanvasRect;

	private ParticleEmitterManager _particles;

	private List<ParticleSystem> _fwEmitters;

	private GravityWell _well;

	private float _viewportMin;

	private float _viewPortMax;

	private float _viewportScale;

	private int index;

	private static FireworksManager Instance;

	private List<GravityWell> _wells;

	private List<ParticleSystem> _particleSpawned;

	private RenderTexture _currentRT;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		//IL_01da: Expected O, but got I4
		//IL_0203: Expected I4, but got O
		//IL_02a8: Expected O, but got I4
		//IL_02d1: Expected I4, but got O
		//IL_010f: Expected I, but got O
		//IL_029a: Expected O, but got I4
		float num = 1f / _viewportScale;
		float viewportMin = num * 0.5f;
		_viewportMin = viewportMin;
		float viewPortMax = _viewportScale * 0.5f;
		_viewPortMax = viewPortMax;
		GameObject gameObject = base.gameObject;
		ParticleEmitterManager particles = ((!gameObject.TryGetComponent<ParticleEmitterManager>(out var component)) ? gameObject.AddComponent<ParticleEmitterManager>() : component);
		_particles = particles;
		ParticleEmitterManager particles2 = _particles;
		particles2._GlobalClockKey = "Root";
		object obj = Screen.width;
		object obj2 = obj >> 31;
		object obj3 = obj - obj2;
		int num2 = obj3 >> 1;
		object obj4 = Screen.height;
		object obj5 = obj4 >> 31;
		object obj6 = obj4 - obj5;
		int num3 = obj6 >> 1;
		Camera main = Camera.main;
		bool flag = (object)main == null;
		int height = num3;
		int width = num2;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0;
			height = num3;
			width = num2;
			if (!flag2)
			{
				Camera main2 = Camera.main;
				RenderTexture targetTexture = main2.targetTexture;
				int width2 = targetTexture.width;
				int height2 = targetTexture.height;
				height = height2;
				width = width2;
			}
		}
		RenderTextureFormat format = default(RenderTextureFormat);
		RenderTexture currentRT = new RenderTexture(width, height, 0, format);
		_currentRT = currentRT;
		nint num4 = (nint)_currentRT;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rbx_v8 (Il2CppMethodInfo)+10]");
		bool flag3 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rbx_v8 (Il2CppMethodInfo)+10]");
		object obj7 = RenderTexture.Create_Injected((IntPtr)0);
		_currentRT.filterMode = FilterMode.Point;
		RenderingExtensions.ClearRenderTexture(_currentRT);
		_RenderCam.targetTexture = _currentRT;
		_RenderImage.texture = _currentRT;
	}

	public static ParticleSystem CreateRandomFirework(int _index, List<string> frames, RectTransform _origin, float scale = 1f)
	{
		float scale2 = default(float);
		if ((object)Instance != null)
		{
			return Instance.MakeRandomFirework(_index, frames, _origin, scale2);
		}
		return (ParticleSystem)(object)new NullReferenceException();
	}

	public static ParticleSystem CreateFireworkAtPosition(int _index, List<string> frames, Vector2 viewportPos, float scale = 1f)
	{
		float scale2 = default(float);
		if ((object)Instance != null)
		{
			return Instance.MakeFireworkAtPosition(_index, frames, viewportPos, scale2);
		}
		return (ParticleSystem)(object)new NullReferenceException();
	}

	private void SpawnFirework()
	{
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxYellow");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxPink");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxRed");
		}
		else
		{
			int size3 = list._size + 1;
			list._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxGreen");
		}
		else
		{
			int size4 = list._size + 1;
			list._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list._version + 1;
		list._version = version5;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxBlue");
		}
		else
		{
			int size5 = list._size + 1;
			list._size = size5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		RectTransform component = GetComponent<RectTransform>();
		float scale = default(float);
		ParticleSystem particleSystem = MakeRandomFirework(index, list, component, scale);
		int num = index + 1;
		index = num;
	}

	private float GetRTScale()
	{
		Camera renderCam = _RenderCam;
		if ((object)_RenderCam != null && ((UnityEngine.Object)renderCam).m_CachedPtr != (IntPtr)0)
		{
			return 0.666875f;
		}
		return 1f;
	}

	private unsafe ParticleSystem MakeFireworkAtPosition(int _index, List<string> frames, Vector2 viewportPos, float scale = 1f)
	{
		//IL_0008: Expected O, but got Ref
		//IL_012b: Expected O, but got I4
		//IL_07ab: Expected I, but got O
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected I4, but got Unknown
		//IL_0337: Expected O, but got I4
		//IL_035d: Expected O, but got I4
		//IL_0384: Expected O, but got I4
		//IL_039d: Expected O, but got Ref
		//IL_03b7: Expected native int or pointer, but got O
		//IL_03d1: Expected O, but got I
		//IL_03f1: Expected O, but got Ref
		//IL_040b: Expected native int or pointer, but got O
		//IL_0425: Expected O, but got I
		//IL_0445: Expected O, but got Ref
		//IL_04ca: Expected native int or pointer, but got O
		//IL_07d6: Expected O, but got I4
		//IL_04fc: Expected O, but got Ref
		//IL_051a: Expected O, but got I4
		//IL_0562: Expected native int or pointer, but got O
		//IL_0810: Expected O, but got I
		//IL_05a8: Expected O, but got I4
		//IL_05b6: Expected O, but got I4
		//IL_0191->IL073b: Incompatible stack heights: 1 vs 0
		//IL_01f2->IL073b: Incompatible stack heights: 2 vs 0
		//IL_022c->IL073b: Incompatible stack heights: 3 vs 0
		//IL_027b->IL073b: Incompatible stack heights: 3 vs 0
		//IL_0305->IL073b: Incompatible stack heights: 3 vs 0
		//IL_0602->IL073b: Incompatible stack heights: 3 vs 0
		//IL_0637->IL073b: Incompatible stack heights: 3 vs 0
		//IL_066b->IL073b: Incompatible stack heights: 3 vs 0
		//IL_06ad->IL073b: Incompatible stack heights: 3 vs 0
		//IL_06ec->IL073b: Incompatible stack heights: 3 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_003C_003Ec__DisplayClass20_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass20_0();
		FireworksManager instance = Instance;
		if ((object)Instance != null && (object)instance._RenderCam != null)
		{
			GameObject gameObject = instance._RenderCam.gameObject;
			if ((object)gameObject != null)
			{
				gameObject.SetActive(value: true);
				List<ParticleSystem> fwEmitters = _fwEmitters;
				if (_fwEmitters != null)
				{
					int version = fwEmitters._version + 1;
					fwEmitters._version = version;
					fwEmitters._size = 0;
					if (fwEmitters._size > 0)
					{
						Array.Clear(fwEmitters._items, 0, fwEmitters._size);
					}
					float rTScale = GetRTScale();
					ParticleSystemConfig renderCam = (ParticleSystemConfig)(object)_RenderCam;
					object obj3 = _index + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D0]");
					float num = 0f * rTScale;
					if ((object)_RenderCam != null)
					{
						bool flag = (object)renderCam._x == null;
						Vector3 position = default(Vector3);
						float ret;
						Camera.ViewportToWorldPoint_Injected((IntPtr)renderCam._x, ref position, Camera.MonoOrStereoscopicEye.Mono, out *(Vector3*)(&ret));
						ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
						List<string> list = new List<string>();
						list._002Ector();
						if (frames != null)
						{
							int num2 = obj3 % frames._size;
							bool flag2 = num2 >= frames._size;
							string[] items = frames._items;
							if (frames._items != null)
							{
								bool flag3 = num2 >= items.Length;
								if (list != null)
								{
									int version2 = list._version + 1;
									list._version = version2;
									string[] items2 = list._items;
									if (list._items != null)
									{
										if (list._size >= items2.Length)
										{
											((List<object>)(object)list).AddWithResize((object)items[num2]);
										}
										else
										{
											int size = list._size + 1;
											list._size = size;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										if (particleSystemConfig != null)
										{
											particleSystemConfig._frame = list;
											ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(ret);
											particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
											_ = 0;
											float constant = default(float);
											minMaxCurve = new ParticleSystem.MinMaxCurve(constant);
											particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
											_ = 0;
											minMaxCurve = new ParticleSystem.MinMaxCurve(3000f);
											particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
											_ = 0;
											ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
											_ = 0;
											_ = 0;
											System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-38]");
											particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-28]");
											_ = 0;
											ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
											_ = 0;
											_ = 0;
											System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
											particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
											_ = 0;
											ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
											particleSystemConfig._angleSteps = 16;
											float num3 = (float)obj3 / 5f;
											float min = num * 100f;
											float num4 = num3 * 300f;
											_ = 0;
											float num5 = num4 * 0.5f;
											_ = 0;
											float num6 = num5 + 150f;
											float max = num6 * num;
											System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(min, max));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+18]");
											_ = 0;
											particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
											_ = 0;
											ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
											float num7 = (float)obj3 / 5f;
											particleSystemConfig._quantity = (int?)(object)1;
											float num8 = num7 + 2f;
											_ = 0;
											_ = 0;
											float num9 = num8 * 0.625f;
											float min2 = num9 * num;
											System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(min2, 0f));
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+28]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+38]");
											_ = 0;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
											particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
											_ = 0;
											int num10 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 184));
											particleSystemConfig._frequency = (float?)(object)1;
											particleSystemConfig._blendMode = (BlendMode?)(object)1;
											particleSystemConfig._on = true;
											string text = ((int*)num10)->ToString();
											string psName = "fwEmitter" + text;
											if ((object)_particles != null)
											{
												ParticleSystem ps = _particles.CreateEmitter(particleSystemConfig, null, psName);
												if (CS_0024_003C_003E8__locals7 != null)
												{
													CS_0024_003C_003E8__locals7.ps = ps;
													if ((object)CS_0024_003C_003E8__locals7.ps != null)
													{
														GameObject gameObject2 = CS_0024_003C_003E8__locals7.ps.gameObject;
														int layer = LayerMask.NameToLayer("UIParticles");
														if ((object)gameObject2 != null)
														{
															gameObject2.layer = layer;
															RenderingExtensions.Start(CS_0024_003C_003E8__locals7.ps);
															if (_particleSpawned != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96880");
																TweenCallback onComplete = delegate
																{
																	CS_0024_003C_003E8__locals7.ps.Stop();
																};
																Tween tween = UITimerHelper.RegisterMillis(40f, onComplete);
																return CS_0024_003C_003E8__locals7.ps;
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
		}
		throw new NullReferenceException();
	}

	private unsafe ParticleSystem MakeRandomFirework(int _index, List<string> frames, RectTransform _origin, float scale = 1f)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0153: Expected O, but got I4
		//IL_018e: Expected O, but got I
		//IL_0803: Expected O, but got I
		//IL_01f7: Expected O, but got I8
		//IL_0235: Expected O, but got I8
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Expected I4, but got Unknown
		//IL_0459: Expected O, but got Ref
		//IL_0473: Expected native int or pointer, but got O
		//IL_04a5: Expected O, but got Ref
		//IL_04bf: Expected native int or pointer, but got O
		//IL_0512: Expected native int or pointer, but got O
		//IL_052c: Expected native int or pointer, but got O
		//IL_058e: Expected O, but got Ref
		//IL_05ec: Expected native int or pointer, but got O
		//IL_0265->IL07ad: Incompatible stack heights: 1 vs 0
		//IL_02c6->IL07ad: Incompatible stack heights: 2 vs 0
		//IL_0300->IL07ad: Incompatible stack heights: 3 vs 0
		//IL_034f->IL07ad: Incompatible stack heights: 3 vs 0
		//IL_03d9->IL07ad: Incompatible stack heights: 3 vs 0
		//IL_0674->IL07ad: Incompatible stack heights: 3 vs 0
		//IL_06a9->IL07ad: Incompatible stack heights: 3 vs 0
		//IL_06dd->IL07ad: Incompatible stack heights: 3 vs 0
		//IL_071f->IL07ad: Incompatible stack heights: 3 vs 0
		//IL_075e->IL07ad: Incompatible stack heights: 3 vs 0
		ParticleSystem.MinMaxCurve minMaxCurve2 = default(ParticleSystem.MinMaxCurve);
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)(&minMaxCurve2);
		_003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass21_0();
		FireworksManager instance = Instance;
		if ((object)Instance != null && (object)instance._RenderCam != null)
		{
			GameObject gameObject = instance._RenderCam.gameObject;
			if ((object)gameObject != null)
			{
				gameObject.SetActive(value: true);
				List<ParticleSystem> fwEmitters = _fwEmitters;
				if (_fwEmitters != null)
				{
					int version = fwEmitters._version + 1;
					fwEmitters._version = version;
					fwEmitters._size = 0;
					bool flag = fwEmitters._size <= 0;
					RectTransform rectTransform = _origin;
					if (!flag)
					{
						Array.Clear(fwEmitters._items, 0, fwEmitters._size);
						rectTransform = null;
					}
					float rTScale = GetRTScale();
					float num = rTScale;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)+C0]");
					float num2 = num * 0f;
					float particleScaleFactor = UICamera.ParticleScaleFactor;
					object obj = _index + 1;
					float num3 = particleScaleFactor * num2;
					Vector2 viewportPosition = GetViewportPosition(_origin);
					RectTransform renderCam = (RectTransform)(object)_RenderCam;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
					bool flag2 = (nint)0 != 0;
					RectTransform rectTransform2 = _origin;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						if (obj2 == null)
						{
							MissingMethodException ex = new MissingMethodException();
							throw ex;
						}
						rectTransform2 = (RectTransform)6573110936L;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v636 @ rax_v25 (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						if (obj3 == null)
						{
							MissingMethodException ex2 = new MissingMethodException();
							throw ex2;
						}
						rectTransform2 = (RectTransform)6573110936L;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v663 @ rax_v28 (should have been resolved before IL gen)");
					object obj4 = default(object);
					float num4 = 0.1f + (float)obj4;
					if ((object)_RenderCam != null)
					{
						bool flag3 = ((UnityEngine.Object)renderCam).m_CachedPtr == (IntPtr)0;
						Vector3 position = default(Vector3);
						float ret;
						Camera.ViewportToWorldPoint_Injected(((UnityEngine.Object)renderCam).m_CachedPtr, ref position, Camera.MonoOrStereoscopicEye.Mono, out *(Vector3*)(&ret));
						ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
						List<string> list = new List<string>();
						list._002Ector();
						if (frames != null)
						{
							int num5 = obj % frames._size;
							bool flag4 = num5 >= frames._size;
							string[] items = frames._items;
							if (frames._items != null)
							{
								bool flag5 = num5 >= items.Length;
								if (list != null)
								{
									int version2 = list._version + 1;
									list._version = version2;
									string[] items2 = list._items;
									if (list._items != null)
									{
										if (list._size >= items2.Length)
										{
											((List<object>)(object)list).AddWithResize((object)items[num5]);
										}
										else
										{
											int size = list._size + 1;
											list._size = size;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										if (particleSystemConfig != null)
										{
											ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(ret);
											((UnityEngine.Object)(object)particleSystemConfig).m_CachedPtr = (IntPtr)0;
											_ = 0;
											float constant = default(float);
											minMaxCurve3 = new ParticleSystem.MinMaxCurve(constant);
											_ = 0;
											_ = 0;
											minMaxCurve3 = new ParticleSystem.MinMaxCurve(3000f);
											_ = 0;
											_ = 0;
											ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref minMaxCurve2, 64));
											_ = 0;
											_ = 0;
											System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0f, 360f));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-40]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-30]");
											_ = 0;
											ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref minMaxCurve2, 32));
											_ = 0;
											_ = 0;
											System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0f, 360f));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-20]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-10]");
											_ = 0;
											_ = 16;
											float min = num3 * 100f;
											float num6 = (float)obj / 5f;
											((ParticleSystem.MinMaxCurve*)(nint)minMaxCurve)->m_Mode = ParticleSystemCurveMode.Constant;
											float num7 = num6 * 300f;
											System.Runtime.CompilerServices.Unsafe.Write(&((ParticleSystem.MinMaxCurve*)(nint)minMaxCurve)->m_CurveMax, null);
											float num8 = num7 * 0.5f;
											float num9 = num8 + 150f;
											float max = num9 * num3;
											minMaxCurve2 = new ParticleSystem.MinMaxCurve(min, max);
											_ = minMaxCurve.m_CurveMax;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-80]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-70]");
											_ = 0;
											ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref minMaxCurve2, 32));
											float num10 = (float)obj / 5f;
											_ = 1;
											float num11 = num10 * 0.625f;
											_ = 0;
											float num12 = num11 + 2f;
											_ = 0;
											float min2 = num12 * num3;
											System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(min2, 0f));
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)+20]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)+30]");
											_ = 0;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-68]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-58]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-48]");
											_ = 0;
											int num13 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref minMaxCurve2, 168));
											_ = 1;
											_ = 1;
											_ = 1;
											string text = ((int*)num13)->ToString();
											string psName = "fwEmitter" + text;
											if ((object)_particles != null)
											{
												ParticleSystem ps = _particles.CreateEmitter(particleSystemConfig, null, psName);
												if (CS_0024_003C_003E8__locals7 != null)
												{
													CS_0024_003C_003E8__locals7.ps = ps;
													if ((object)CS_0024_003C_003E8__locals7.ps != null)
													{
														GameObject gameObject2 = CS_0024_003C_003E8__locals7.ps.gameObject;
														int layer = LayerMask.NameToLayer("UIParticles");
														if ((object)gameObject2 != null)
														{
															gameObject2.layer = layer;
															RenderingExtensions.Start(CS_0024_003C_003E8__locals7.ps);
															if (_particleSpawned != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96880");
																TweenCallback onComplete = delegate
																{
																	CS_0024_003C_003E8__locals7.ps.Stop();
																};
																Tween tween = UITimerHelper.RegisterMillis(40f, onComplete);
																return CS_0024_003C_003E8__locals7.ps;
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
		}
		throw new NullReferenceException();
	}

	public static GravityWell CreateGravityWell(Vector2 viewportPosition, GravityWellConfig conf = null)
	{
		if ((object)Instance != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 43 Invalid \"Jump target not found in method: 0x186CC6210\"");
		}
		return (GravityWell)(object)new NullReferenceException();
	}

	private GravityWell SpawnGravityWell(Vector2 viewportPosition, GravityWellConfig conf = null)
	{
		//IL_0205: Expected O, but got I4
		//IL_0213: Expected O, but got I4
		//IL_023b->IL015e: Incompatible stack heights: 1 vs 0
		//IL_014a->IL015e: Incompatible stack heights: 1 vs 0
		//IL_00be->IL015e: Incompatible stack heights: 1 vs 0
		FireworksManager instance = Instance;
		if ((object)Instance != null && (object)instance._RenderCam != null)
		{
			GameObject gameObject = instance._RenderCam.gameObject;
			if ((object)gameObject != null)
			{
				gameObject.SetActive(value: true);
				Camera renderCam = _RenderCam;
				if ((object)_RenderCam != null)
				{
					bool flag = ((UnityEngine.Object)renderCam).m_CachedPtr == (IntPtr)0;
					Vector3 position = default(Vector3);
					Camera.ViewportToWorldPoint_Injected(((UnityEngine.Object)renderCam).m_CachedPtr, ref position, Camera.MonoOrStereoscopicEye.Mono, out Vector3 _);
					float rTScale = GetRTScale();
					bool flag2 = conf != null;
					GravityWellConfig gravityWellConfig = conf;
					if (!flag2)
					{
						GravityWellConfig gravityWellConfig2 = new GravityWellConfig();
						if (gravityWellConfig2 == null)
						{
							goto IL_015e;
						}
						gravityWellConfig2._power = rTScale;
						float epsilon = rTScale * 25f;
						float gravity = rTScale * 150f;
						gravityWellConfig2._epsilon = epsilon;
						gravityWellConfig2._gravity = gravity;
						gravityWellConfig = gravityWellConfig2;
					}
					gravityWellConfig._x = (float?)(object)1;
					gravityWellConfig._y = (float?)(object)1;
					gravityWellConfig._usePauseSystem = false;
					if ((object)_particles != null)
					{
						GravityWell result = _particles.CreateGravityWell(gravityWellConfig, null, "Well");
						if (_wells != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99550");
							return result;
						}
					}
				}
			}
		}
		goto IL_015e;
		IL_015e:
		throw new NullReferenceException();
	}

	public static void Clear()
	{
		//IL_03c7: Expected O, but got I
		//IL_0213: Expected O, but got I
		//IL_0524: Expected O, but got I
		//IL_0284: Expected O, but got I
		//IL_02da: Expected O, but got I
		//IL_00bf->IL047a: Incompatible stack heights: 3 vs 0
		//IL_025b->IL0545: Incompatible stack heights: 4 vs 0
		//IL_05ed->IL0400: Incompatible stack heights: 1 vs 0
		//IL_02a2->IL0545: Incompatible stack heights: 4 vs 0
		//IL_02e5->IL0545: Incompatible stack heights: 5 vs 0
		FireworksManager instance = Instance;
		if ((object)Instance != null && instance._particleSpawned != null)
		{
			List<ParticleSystem>.Enumerator enumerator = default(List<ParticleSystem>.Enumerator);
			while (enumerator.MoveNext())
			{
				object obj = null;
				FireworksManager instance2 = Instance;
				bool flag = (object)Instance == null;
				bool flag2 = (object)instance2._particles == null;
				instance2._particles.RemoveEmitter(null);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rdi_v24 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rdi_v24 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
				GameObject obj2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				UnityEngine.Object.Destroy(obj2, 0f);
			}
			FireworksManager instance3 = Instance;
			if ((object)Instance != null)
			{
				List<ParticleSystem> particleSpawned = instance3._particleSpawned;
				if (instance3._particleSpawned != null)
				{
					int version = particleSpawned._version + 1;
					particleSpawned._version = version;
					particleSpawned._size = 0;
					if (particleSpawned._size > 0)
					{
						Array.Clear(particleSpawned._items, 0, particleSpawned._size);
					}
					FireworksManager instance4 = Instance;
					if ((object)Instance != null && instance4._wells != null)
					{
						List<GravityWell>.Enumerator enumerator2 = default(List<GravityWell>.Enumerator);
						while (enumerator2.MoveNext())
						{
							object obj3 = null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v657 @ rdi_v23 (System.Object)+10]");
							bool flag4 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v657 @ rdi_v23 (System.Object)+10]");
							IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
							GameObject obj4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
							UnityEngine.Object.Destroy(obj4, 0f);
							object instance5 = Instance;
							bool flag5 = (object)Instance == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1009 @ rbx_v26 (System.Object)+38]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1009 @ rbx_v26 (System.Object)+38]");
							bool flag6 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v766 @ rbx_v27 (System.Object)+38]");
							object obj6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v766 @ rbx_v27 (System.Object)+38]");
							bool flag7 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ r10_v19+18]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ r10_v19+10]");
								nint num = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ r10_v19+18]");
								int num2 = Array.IndexOf((object[])num, null, 0, 0);
								if (num2 != -1)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v766 @ rbx_v27 (System.Object)+38]");
									bool flag8 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v766 @ rbx_v27 (System.Object)+38]");
									bool flag9 = ((List<object>)0).Remove(null);
								}
							}
						}
						FireworksManager instance6 = Instance;
						if ((object)Instance != null)
						{
							List<GravityWell> wells = instance6._wells;
							if (instance6._wells != null)
							{
								int version2 = wells._version + 1;
								wells._version = version2;
								wells._size = 0;
								if (wells._size > 0)
								{
									Array.Clear(wells._items, 0, wells._size);
								}
								object instance7 = Instance;
								if ((object)Instance != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rbx_v20 (System.Object)+20]");
									object obj7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rbx_v20 (System.Object)+20]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rbx_v21 (System.Object)+10]");
										bool flag10 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rbx_v21 (System.Object)+10]");
										IntPtr gcHandlePtr3 = Component.get_gameObject_Injected((IntPtr)0);
										GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr3);
										if ((object)gameObject != null)
										{
											bool flag11 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
											GameObject.SetActive_Injected(((UnityEngine.Object)gameObject).m_CachedPtr, false);
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

	public static Vector2 GetViewportPosition(RectTransform rTrans)
	{
		//IL_00be->IL0043: Incompatible stack heights: 1 vs 0
		FireworksManager instance = Instance;
		if ((object)Instance != null)
		{
			FireworksManager renderCam = (FireworksManager)(object)instance._RenderCam;
			if ((object)rTrans != null)
			{
				bool flag = ((UnityEngine.Object)rTrans).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)rTrans).m_CachedPtr, out Vector3 _);
				if ((object)instance._RenderCam != null)
				{
					bool flag2 = ((UnityEngine.Object)renderCam).m_CachedPtr == (IntPtr)0;
					Vector3 position = default(Vector3);
					Camera.WorldToViewportPoint_Injected(((UnityEngine.Object)renderCam).m_CachedPtr, ref position, Camera.MonoOrStereoscopicEye.Mono, out Vector3 _);
					Vector2 result = default(Vector2);
					return result;
				}
			}
		}
		throw new NullReferenceException();
	}

	public FireworksManager()
	{
		List<ParticleSystem> fwEmitters = new List<ParticleSystem>();
		_fwEmitters = fwEmitters;
		_viewportScale = 1.6f;
		List<GravityWell> wells = new List<GravityWell>();
		_wells = wells;
		List<ParticleSystem> particleSpawned = new List<ParticleSystem>();
		_particleSpawned = particleSpawned;
	}
}
