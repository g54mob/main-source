using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using Zenject;

namespace VampireSurvivors;

public class FireworksUIManager : MonoBehaviour
{
	private ParticleEmitterManager _Fireworks;

	private RectTransform _ScreenRect;

	private RectTransform _Target;

	private SignalBus _signalBus;

	private static FireworksUIManager Instance;

	private List<ParticleSystem> _particles;

	private GravityWell _well;

	private void Construct(SignalBus signalBus)
	{
		_signalBus = signalBus;
	}

	private void Awake()
	{
		Instance = this;
	}

	private unsafe void Test()
	{
		//IL_004b: Expected O, but got Ref
		//IL_005b: Expected O, but got I
		//IL_0285: Expected O, but got I
		//IL_00c4: Expected O, but got I8
		//IL_0102: Expected O, but got I8
		GravityWellConfig gravityWellConfig = new GravityWellConfig();
		gravityWellConfig._power = 1f;
		gravityWellConfig._epsilon = 25f;
		gravityWellConfig._gravity = 150f;
		gravityWellConfig.requiresLateUpdate = true;
		object obj = default(object);
		AddGravityWell(gravityWellConfig, (Vector3)(&obj), null);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		GravityWellConfig gravityWellConfig2 = gravityWellConfig;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj2 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			gravityWellConfig2 = (GravityWellConfig)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v184 @ rax_v14 (should have been resolved before IL gen)");
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
			gravityWellConfig2 = (GravityWellConfig)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v253 @ rax_v17 (should have been resolved before IL gen)");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxBlue.png");
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
			((List<object>)(object)list).AddWithResize((object)"PfxPink.png");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		Transform transform = base.transform;
		Vector2 screenPos = default(Vector2);
		Transform parent = default(Transform);
		PlayFirework(screenPos, list, 1, parent);
	}

	private unsafe void PlayFirework(Vector2 screenPos, List<string> frames, int i, Transform parent)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_008c: Expected native int or pointer, but got O
		//IL_00a6: Expected O, but got I
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_00e0: Expected native int or pointer, but got O
		//IL_00fa: Expected O, but got I
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_0134: Expected native int or pointer, but got O
		//IL_014e: Expected O, but got I
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Expected O, but got Unknown
		//IL_01d5: Expected native int or pointer, but got O
		//IL_0460: Expected O, but got I4
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected O, but got Unknown
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Expected O, but got Unknown
		//IL_028c: Expected O, but got I
		//IL_02a5: Expected native int or pointer, but got O
		//IL_049a: Expected O, but got I
		//IL_02fc: Expected O, but got I
		//IL_031d: Expected O, but got I
		//IL_04c9: Expected O, but got I
		//IL_05d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dc: Expected O, but got Unknown
		//IL_0544: Expected O, but got I4
		//IL_054c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0551: Expected O, but got Unknown
		//IL_0583: Unknown result type (might be due to invalid IL or missing references)
		//IL_0588: Expected O, but got Unknown
		//IL_05ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b1: Expected I4, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 200;
		float num = (float)i / 5f;
		float num2 = num + num;
		float num3 = num2 + 2f;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		if (frames != null)
		{
			List<object> frame = new List<object>(frames);
			particleSystemConfig._frame = (List<string>)(object)frame;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)(obj - 56);
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(3000f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-38]");
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-28]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)(obj - 24);
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-18]");
			particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-8]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)(obj + 8);
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1+8]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1+18]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)(obj + 40);
			particleSystemConfig._angleSteps = 16;
			_ = 0;
			float num4 = (float)i / 5f;
			_ = 0;
			float num5 = num4 * 300f;
			float num6 = num5 * 0.5f;
			float max = num6 + 150f;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, max));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1+38]");
			_ = 0;
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-68]");
			_ = 0;
			float min = num3 * 0.5f;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r12d\"");
			_ = 1;
			object obj3 = (object)frames >> 1;
			object obj4 = obj3 + 1;
			object obj5 = obj3 >> 31;
			object obj6 = obj5 + obj4;
			object obj7 = obj6 << 5;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)(obj + 72);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1+E0]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(min, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1+48]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1+58]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-60]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-40]");
			_ = 0;
			_ = 0;
			_ = 1115684864;
			_ = 1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1+E0]");
			particleSystemConfig._frequency = (float?)(object)0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1+E0]");
			particleSystemConfig._blendMode = (BlendMode?)(object)0;
			particleSystemConfig._on = true;
			Transform parent2 = default(Transform);
			string psName = default(string);
			bool isAdditive = default(bool);
			bool requiresMasking = default(bool);
			ParticleSystem particleSystem = _Fireworks.CreateUIEmitter(particleSystemConfig, "UI", 1000, parent2, psName, isAdditive, requiresMasking);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96880");
			ParticleSystemRenderer component = particleSystem.GetComponent<ParticleSystemRenderer>();
			component.enabled = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA58]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA58]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj8 == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1262 @ rax_v54 (should have been resolved before IL gen)");
			object obj9 = obj + 224;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183A1CC80");
			string text = default(string);
			string message = "Screenpos :" + text;
			Debug.Log(message);
			Transform transform = particleSystem.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v903 @ rax_v60 (UnityEngine.Transform)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v903 @ rax_v60 (UnityEngine.Transform)+10]");
			Vector3 value = default(Vector3);
			Transform.set_position_Injected((IntPtr)0, ref value);
			object obj10 = i * 2;
			object obj11 = i + obj10;
			object obj12 = obj11 >> 31;
			object obj13 = obj11 - obj12;
			object obj14 = obj13 >> 1;
			object obj15 = obj14 * 4;
			object obj16 = obj14 + obj15;
			object obj17 = obj16 << 5;
			int count = obj17 + 32;
			particleSystem.Emit(count);
			return;
		}
		Exception ex2 = System.Linq.Error.ArgumentNull("source");
		throw ex2;
	}

	public unsafe static void AddGravityWell(GravityWellConfig conf, Vector3 pos, Transform parent)
	{
		//IL_02c6: Expected O, but got F4
		//IL_0098: Expected O, but got I
		//IL_018d: Expected O, but got I
		//IL_033d: Expected I, but got O
		//IL_0390: Expected I, but got O
		//IL_03a9: Expected I, but got O
		//IL_02de->IL0269: Incompatible stack heights: 1 vs 0
		//IL_0083->IL0269: Incompatible stack heights: 1 vs 0
		//IL_00f0->IL0269: Incompatible stack heights: 1 vs 0
		//IL_0112->IL0269: Incompatible stack heights: 1 vs 0
		//IL_03ae->IL012e: Incompatible stack heights: 12 vs 1
		Camera main = Camera.main;
		if ((object)main != null)
		{
			bool flag = ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0;
			object obj = Camera.get_orthographicSize_Injected(((UnityEngine.Object)main).m_CachedPtr);
			if (conf != null)
			{
				conf._usePauseSystem = false;
				float epsilon = conf._epsilon * 1.6f;
				conf._epsilon = epsilon;
				float gravity = conf._gravity * 1.6f;
				conf._gravity = gravity;
				Camera instance = (Camera)(object)Instance;
				if ((object)Instance != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdi_v12 (UnityEngine.Camera)+48]");
					Camera camera = (Camera)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdi_v12 (UnityEngine.Camera)+48]");
					if ((nint)0 == 0 || ((UnityEngine.Object)camera).m_CachedPtr == (IntPtr)0)
					{
						Camera instance2 = (Camera)(object)Instance;
						bool flag2 = (object)Instance == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v589 @ rdi_v14 (UnityEngine.Camera)+20]");
						bool flag3 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v589 @ rdi_v14 (UnityEngine.Camera)+20]");
						Transform parent2 = default(Transform);
						GravityWell gravityWell = ((ParticleEmitterManager)0).CreateGravityWell(conf, parent2);
						FireworksUIManager instance3 = Instance;
						bool flag4 = (object)Instance == null;
						bool flag5 = (object)instance3._well == null;
						Transform transform = instance3._well.transform;
						bool flag6 = (object)transform == null;
						bool flag7 = (object)((GravityWellConfig)(object)transform)._x == null;
						float value = default(float);
						Transform.set_position_Injected((IntPtr)((GravityWellConfig)(object)transform)._x, ref *(Vector3*)(&value));
						FireworksUIManager instance4 = Instance;
						bool flag8 = (object)Instance == null;
						bool flag9 = (object)instance4._well == null;
						Transform transform2 = instance4._well.transform;
						bool flag10 = (object)transform2 == null;
						bool flag11 = (object)((GravityWellConfig)(object)transform2)._x == null;
						Transform.get_localScale_Injected((IntPtr)((GravityWellConfig)(object)transform2)._x, out Vector3 _);
						bool flag12 = (object)((GravityWellConfig)(object)transform2)._x == null;
						Vector3 value2 = default(Vector3);
						Transform.set_localScale_Injected((IntPtr)((GravityWellConfig)(object)transform2)._x, ref value2);
						return;
					}
					FireworksUIManager instance5 = Instance;
					if ((object)Instance != null && (object)instance5._Fireworks != null)
					{
						instance5._Fireworks.UpdateGravityWellConfig(conf);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public static Vector2 GetPositionFromCanvas(Vector3 position)
	{
		Vector2 result = default(Vector2);
		return result;
	}

	public FireworksUIManager()
	{
		List<ParticleSystem> particles = new List<ParticleSystem>();
		_particles = particles;
	}
}
