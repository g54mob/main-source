using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Objects.Props;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundFoscari2_Plain : BackgroundManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<SuperObject, bool> _003C_003E9__29_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal unsafe bool _003CMakePizza_003Eb__29_0(SuperObject o)
		{
			//IL_0144: Expected I4, but got O
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected Ref, but got Unknown
			//IL_00fd: Expected I8, but got I4
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3D6E]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((object)o != null)
			{
				string tiledName = o.m_TiledName;
				if (o.m_TiledName != null)
				{
					object obj = "FS_PIZZA";
					if ((object)o.m_TiledName != "FS_PIZZA")
					{
						if ("FS_PIZZA" != null)
						{
							int stringLength = tiledName._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
							if ((nint)stringLength == 0)
							{
								ref byte second = ref *(byte*)("FS_PIZZA" + 20);
								ulong length = (ulong)(tiledName._stringLength + tiledName._stringLength);
								return System.SpanHelpers.SequenceEqual(ref *(byte*)(o.m_TiledName + 20), ref second, length);
							}
						}
						return false;
					}
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private TileSprite _water;

	private float _beats;

	private float _tilingOffset;

	private PhaserSprite _sDarkness;

	private PhaserSprite _sFader;

	private PhaserSprite _pizzaAsprite;

	private Circle _pizzaA;

	private bool _canPizza = true;

	private BgmType _saveBGM;

	private BgmModType _saveBGMMod;

	private Timer beatTimer;

	private float _waterOffset;

	private EnemyJeneviv _jeneviv;

	private ParticleEmitterManager _shadowParticlesManager;

	private ParticleSystem _shadowEmitter;

	private PropFoscariSeal2 _seal;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _glitchEmitter;

	private ParticleSystem _glitchEmitter2;

	public unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00ef: Expected O, but got F4
		//IL_01d9: Expected O, but got I
		//IL_02e7: Expected O, but got I4
		//IL_030e: Expected O, but got I4
		//IL_0327: Expected O, but got Ref
		//IL_0341: Expected native int or pointer, but got O
		//IL_035b: Expected O, but got I
		//IL_0394: Expected O, but got I
		//IL_03d7: Expected O, but got Ref
		//IL_03fa: Expected F4, but got I4
		//IL_03f5: Expected native int or pointer, but got O
		//IL_0ea1: Expected O, but got I
		//IL_042d: Expected O, but got Ref
		//IL_0447: Expected native int or pointer, but got O
		//IL_0edb: Expected O, but got I
		//IL_047f: Expected O, but got Ref
		//IL_0499: Expected native int or pointer, but got O
		//IL_0f15: Expected O, but got I
		//IL_0513: Expected O, but got I
		//IL_0632: Expected O, but got I4
		//IL_0659: Expected O, but got I4
		//IL_0672: Expected O, but got Ref
		//IL_068c: Expected native int or pointer, but got O
		//IL_06a6: Expected O, but got I
		//IL_06df: Expected O, but got I
		//IL_0722: Expected O, but got Ref
		//IL_0745: Expected F4, but got I4
		//IL_0740: Expected native int or pointer, but got O
		//IL_0f62: Expected O, but got I4
		//IL_0758: Expected O, but got Ref
		//IL_0772: Expected native int or pointer, but got O
		//IL_0f7f: Expected O, but got I4
		//IL_07a4: Expected O, but got Ref
		//IL_07be: Expected native int or pointer, but got O
		//IL_0fb9: Expected O, but got I
		//IL_0838: Expected O, but got I
		//IL_0a3b: Expected O, but got I
		//IL_0bcd: Expected O, but got Ref
		//IL_0be7: Expected native int or pointer, but got O
		//IL_0c06: Expected O, but got I
		//IL_0c22: Expected F4, but got I4
		//IL_102d: Expected F4, but got I4
		//IL_107d: Expected O, but got Ref
		//IL_1089: Expected native int or pointer, but got O
		//IL_10c9: Expected O, but got I
		//IL_0c42: Expected F4, but got I8
		//IL_0c67: Expected O, but got Ref
		//IL_0c8e: Expected O, but got I
		//IL_0ca8: Expected native int or pointer, but got O
		//IL_0c54: Expected F4, but got I8
		//IL_0cda: Expected O, but got I4
		//IL_0d02: Expected O, but got Ref
		//IL_0d1c: Expected native int or pointer, but got O
		//IL_104e: Expected O, but got I4
		//IL_0d4c: Expected O, but got I
		//IL_0d9c: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		_canPizza = true;
		_beats = 0f;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			Rectangle rectangle = new Rectangle();
			rectangle._width = renderer.width;
			rectangle._x = -0.64f;
			rectangle._y = 0f;
			rectangle._height = 0.64f;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer2 = s_scene2._renderer;
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene3 = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer3 = s_scene3._renderer;
					Rectangle rectangle2 = new Rectangle();
					object obj3 = renderer2.height ^ -0f;
					float y = (float)obj3 + 0.64f;
					rectangle2._width = renderer3.width;
					rectangle2._x = -0.64f;
					rectangle2._height = 0.64f;
					rectangle2._y = y;
					GameObject gameObject = base.gameObject;
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v879 @ rbx_v5 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
					}
					_ = 0;
					ParticleEmitterManager particlesManager;
					if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 432))))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
						particlesManager = (ParticleEmitterManager)0;
					}
					else
					{
						particlesManager = gameObject.AddComponent<ParticleEmitterManager>();
					}
					_particlesManager = particlesManager;
					ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
					List<string> list = new List<string>();
					int version = list._version + 1;
					list._version = version;
					string[] items = list._items;
					if (list._size >= items.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"trueBlack");
					}
					else
					{
						int size = list._size + 1;
						list._size = size;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					particleSystemConfig._frame = list;
					ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
					particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
					_ = 0;
					minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
					particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
					_ = 0;
					ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(100f, 150f));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
					particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
					_ = 0;
					_ = 0;
					_ = 100;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
					particleSystemConfig._quantity = (int?)(object)0;
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene4 = ArcadePhysics.s_scene;
						PhaserScene.Renderer renderer4 = s_scene4._renderer;
						ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, renderer4.pixelWidth));
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E0]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+F0]");
						_ = 0;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
						particleSystemConfig._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+68]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 1f));
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
						_ = 0;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
						particleSystemConfig._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+80]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+90]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.25f, 1f));
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+120]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+130]");
						_ = 0;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+98]");
						particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+A8]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B8]");
						_ = 0;
						EmitZone emitZone = new EmitZone();
						emitZone._type = EmitZoneType.Random;
						emitZone._source = rectangle;
						particleSystemConfig._emitZone = emitZone;
						_ = 0;
						_ = 1120403456;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
						particleSystemConfig._frequency = (float?)(object)0;
						particleSystemConfig._on = true;
						ParticleSystem glitchEmitter = _particlesManager.CreateEmitter(particleSystemConfig);
						_glitchEmitter = glitchEmitter;
						ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
						List<string> list2 = new List<string>();
						int version2 = list2._version + 1;
						list2._version = version2;
						string[] items2 = list2._items;
						if (list2._size >= items2.Length)
						{
							((List<object>)(object)list2).AddWithResize((object)"trueBlack");
						}
						else
						{
							int size2 = list2._size + 1;
							list2._size = size2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						particleSystemConfig2._frame = list2;
						minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
						particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
						_ = 0;
						minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
						particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(100f, 150f));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-38]");
						particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-28]");
						_ = 0;
						_ = 0;
						_ = 100;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
						particleSystemConfig2._quantity = (int?)(object)0;
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene5 = ArcadePhysics.s_scene;
							PhaserScene.Renderer renderer5 = s_scene5._renderer;
							ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(1f, renderer5.pixelWidth));
							particleSystemConfig2._scaleX = (ParticleSystem.MinMaxCurve?)(object)1;
							ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(1f, 1f));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
							_ = 0;
							particleSystemConfig2._scaleY = (ParticleSystem.MinMaxCurve?)(object)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(0.25f, 1f));
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
							particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
							_ = 0;
							EmitZone emitZone2 = new EmitZone();
							emitZone2._type = EmitZoneType.Random;
							emitZone2._source = rectangle2;
							particleSystemConfig2._emitZone = emitZone2;
							_ = 0;
							_ = 1120403456;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
							particleSystemConfig2._frequency = (float?)(object)0;
							particleSystemConfig2._on = true;
							ParticleSystem glitchEmitter2 = _particlesManager.CreateEmitter(particleSystemConfig2);
							_glitchEmitter2 = glitchEmitter2;
							ParticleSystem particleSystem = RenderingExtensions.SetScrollFactor(_glitchEmitter, 0f);
							ParticleSystem particleSystem2 = RenderingExtensions.SetScrollFactor(_glitchEmitter2, 0f);
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene6 = ArcadePhysics.s_scene;
								PhaserScene.Renderer renderer6 = s_scene6._renderer;
								if ((object)GM.Core != null)
								{
									PhaserScene s_scene7 = ArcadePhysics.s_scene;
									PhaserScene.Renderer renderer7 = s_scene7._renderer;
									Line line = null;
									float y2 = renderer6.height + renderer6.height;
									float y3 = renderer7.height ^ -0f;
									line._y2 = y3;
									line._x1 = 0f;
									line._y1 = y2;
									line._x2 = 0f;
									GameManager core = GM.Core;
									PlayerOptionsData config = core._playerOptions.Config;
									GameObject gameObject2 = base.gameObject;
									nint num2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v800 @ rbx_v9 (Il2CppMethodInfo)+38]");
									if ((nint)0 == 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
									}
									_ = 0;
									ParticleEmitterManager shadowParticlesManager;
									if (gameObject2.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 432))))
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
										shadowParticlesManager = (ParticleEmitterManager)0;
									}
									else
									{
										shadowParticlesManager = gameObject2.AddComponent<ParticleEmitterManager>();
									}
									_shadowParticlesManager = shadowParticlesManager;
									ParticleSystemConfig particleSystemConfig3 = new ParticleSystemConfig("vfx");
									List<string> list3 = new List<string>();
									int version3 = list3._version + 1;
									list3._version = version3;
									string[] items3 = list3._items;
									if (list3._size >= items3.Length)
									{
										((List<object>)(object)list3).AddWithResize((object)"Smoke1");
									}
									else
									{
										int size3 = list3._size + 1;
										list3._size = size3;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									}
									int version4 = list3._version + 1;
									list3._version = version4;
									string[] items4 = list3._items;
									if (list3._size >= items4.Length)
									{
										((List<object>)(object)list3).AddWithResize((object)"Smoke2");
									}
									else
									{
										int size4 = list3._size + 1;
										list3._size = size4;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									}
									particleSystemConfig3._frame = list3;
									ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(100f, 150f));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
									particleSystemConfig3._lifespan = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
									_ = 0;
									_ = 0;
									float max = 150f;
									if (!config._003CSelectedInverse_003Ek__BackingField)
									{
										max = 4.294967E+09f;
									}
									_ = 0;
									float min = 100f;
									if (!config._003CSelectedInverse_003Ek__BackingField)
									{
										min = 4.2949673E+09f;
									}
									ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(min, max));
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
									particleSystemConfig3._speed = (ParticleSystem.MinMaxCurve?)(object)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve12 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
									_ = 0;
									_ = 100;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
									particleSystemConfig3._quantity = (int?)(object)0;
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve12, new ParticleSystem.MinMaxCurve(1f, 2f));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
									_ = 0;
									particleSystemConfig3._scale = (ParticleSystem.MinMaxCurve?)(object)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve13 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve13, new ParticleSystem.MinMaxCurve(1f, 0f));
									particleSystemConfig3._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
									particleSystemConfig3._tint = (uint?)(object)0;
									EmitZone emitZone3 = new EmitZone();
									emitZone3._type = EmitZoneType.Random;
									emitZone3._source = line;
									particleSystemConfig3._emitZone = emitZone3;
									_ = 0;
									_ = 1120403456;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
									particleSystemConfig3._frequency = (float?)(object)0;
									particleSystemConfig3._on = false;
									ParticleSystem shadowEmitter = _shadowParticlesManager.CreateEmitter(particleSystemConfig3);
									_shadowEmitter = shadowEmitter;
									ParticleEmitterManager particleEmitterManager = _particlesManager.SetDepth(10000);
									ParticleEmitterManager particleEmitterManager2 = _shadowParticlesManager.SetDepth(10000);
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Create()
	{
		//IL_037b: Expected O, but got I4
		//IL_049f: Expected I4, but got O
		//IL_0501: Expected O, but got I4
		//IL_0518: Expected O, but got I4
		base.Create();
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		_saveBGM = config._003CSelectedBGM_003Ek__BackingField;
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		_saveBGMMod = config2._003CSelectedBGMMod_003Ek__BackingField;
		GameManager core3 = GM.Core;
		PlayerOptionsData config3 = core3._playerOptions.Config;
		GameManager core4 = default(GameManager);
		if (!config3._003CSelectedInverse_003Ek__BackingField)
		{
			core4 = GM.Core;
		}
		PlayerOptionsData config4 = core4._playerOptions.Config;
		float waterOffset;
		if (config4._003CSelectedInverse_003Ek__BackingField)
		{
			GameManager core5 = GM.Core;
			PlayerOptionsData config5 = core5._playerOptions.Config;
			if (config5._003CVisuallyInvertStages_003Ek__BackingField)
			{
				waterOffset = 0.05f;
				goto IL_0555;
			}
		}
		waterOffset = -0.05f;
		goto IL_0555;
		IL_0555:
		_waterOffset = waterOffset;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float y = renderer2.height * 0.5f;
		float x = renderer.width * 0.5f;
		GameObject go = base.gameObject;
		string text = default(string);
		TileSpriteBuilder tileSpriteBuilder = RenderingExtensions.AddTileSprite(go, x, y, "background_Foscari", text);
		tileSpriteBuilder._depth = -32768f;
		tileSpriteBuilder._depthMul = 1f;
		Transform parent = base.transform;
		tileSpriteBuilder._parent = parent;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer3 = s_scene3._renderer;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene4 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer4 = s_scene4._renderer;
				tileSpriteBuilder._tileHeight = renderer4.height;
				tileSpriteBuilder._tileWidth = renderer3.width;
				tileSpriteBuilder._name = "Water";
				TileSprite water = tileSpriteBuilder.Build();
				_water = water;
				TileSprite tileSprite = RenderingExtensions.SetScrollFactor(_water, 0f);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene5 = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer5 = s_scene5._renderer;
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene6 = ArcadePhysics.s_scene;
						PhaserScene.Renderer renderer6 = s_scene6._renderer;
						PhaserWorld instance = PhaserWorld.Instance;
						Vector2 pos = default(Vector2);
						PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "vfx", "stageShadows");
						PhaserSprite component = phaserSprite.setOrigin(0f, (float?)(object)0);
						PhaserSprite component2 = RenderingExtensions.SetScrollFactor(component, 0f);
						float xScale = renderer6.width / 1.5999999f;
						PhaserSprite phaserSprite2 = RenderingExtensions.SetScale(component2, xScale, renderer5.height);
						PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(1f);
						PhaserSprite phaserSprite4 = phaserSprite3.setDepth(10000);
						GameObject gameObject = phaserSprite4.gameObject;
						((UnityEngine.Object)gameObject).SetName("stageShadows");
						_sDarkness = phaserSprite4;
						Action onComplete = onBeat;
						if (beatTimer != null)
						{
							beatTimer.Cancel();
						}
						MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
						int repeat = default(int);
						TimerType type = default(TimerType);
						Timer timer = Timers.Register(0.411f, onComplete, null, isLooped: true, (byte)(int)text != 0, autoDestroyOwner, repeat, type, isOnlineTimer: true, canPause: false);
						beatTimer = timer;
						GameManager core6 = GM.Core;
						Stage stage = core6._stage;
						StageModifiers stageModifiers = stage._003CStageMods_003Ek__BackingField;
						bool flag = (object)stageModifiers._003CEnemySpeed_003Ek__BackingField == null;
						float? num = (float?)(object)0;
						if (!flag)
						{
							num = (float?)(object)1;
						}
						stageModifiers._003CEnemySpeed_003Ek__BackingField = num;
						GameManager core7 = GM.Core;
						core7._stage.CalculateEnemySpeed();
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void OnInitCompleted()
	{
		//IL_0041: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		bool flag = (nint)0 == 0;
		object obj = 0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			bool flag2 = (nint)obj2 != -1;
			obj = 22;
			if (flag2)
			{
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
		BgmType bgmType = default(BgmType);
		SoundManager.StopMusic(bgmType);
	}

	public override void CheckMinute(int minute)
	{
		//IL_0086: Expected O, but got I4
		//IL_00c7: Expected O, but got I4
		//IL_0111: Expected O, but got I4
		//IL_015b: Expected O, but got I4
		switch (minute)
		{
		case 26:
			_glitchEmitter.Stop();
			_glitchEmitter2.Stop();
			break;
		case 25:
		{
			RenderingExtensions.Start(_glitchEmitter);
			RenderingExtensions.Start(_glitchEmitter2);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 0.5f;
			soundConfig.Volume = (float?)(object)1;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.WorldEater, soundConfig, 0f, 10, time);
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Volume = (float?)(object)1;
			soundConfig2.Rate = 0.25f;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.WorldEater, soundConfig2, 0f, 10, time);
			SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
			soundConfig3.Volume = (float?)(object)1;
			soundConfig3.Rate = 0.5f;
			PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.Haha, soundConfig3, 0f, 10, time);
			SoundManager.SoundConfig soundConfig4 = new SoundManager.SoundConfig();
			soundConfig4.Volume = (float?)(object)1;
			soundConfig4.Rate = 0.25f;
			PlaySoundResult playSoundResult4 = SoundManager.PlaySound(SfxType.Haha, soundConfig4, 0f, 10, time);
			break;
		}
		}
	}

	public override void Cleanup()
	{
		//IL_0031: Expected O, but got I4
		base._003CIsBackgroundActive_003Ek__BackingField = false;
		if (beatTimer != null)
		{
			beatTimer.Cancel();
		}
		GameManager core = GM.Core;
		core._003CHardBounds_003Ek__BackingField = (Rect?)(object)0;
		_ = 0;
		GameManager core2 = GM.Core;
		PlayerOptionsData config = core2._playerOptions.Config;
		config._003CSelectedBGM_003Ek__BackingField = _saveBGM;
		GameManager core3 = GM.Core;
		PlayerOptionsData config2 = core3._playerOptions.Config;
		config2._003CSelectedBGMMod_003Ek__BackingField = _saveBGMMod;
		GameManager core4 = GM.Core;
		PlayerOptionsData config3 = core4._playerOptions.Config;
		List<ItemType> list = config3._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v18 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				return;
			}
		}
		SoundManager.StopMusic(BgmType.BGM_Foscari2);
	}

	protected override void OnUpdate()
	{
		//IL_002e: Expected F4, but got O
		//IL_004a: Expected F4, but got O
		base.OnUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = num * _waterOffset;
		float num3 = num2 * 0.01f;
		float tilingOffset = _tilingOffset - num3;
		_tilingOffset = tilingOffset;
		TileSprite water = _water;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		water._xScrollOffset = (float)renderer.screenCenter;
		water._spriteScroller.SetScrollOffsetX((float)renderer.screenCenter);
		TileSprite water2 = _water;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float num4 = _tilingOffset;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v15 (PhaserScene+Renderer)+38]");
		float scrollOffsetY = (water2._yScrollOffset = num4 + 0f);
		water2._spriteScroller.SetScrollOffsetY(scrollOffsetY);
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		while (enumerator.MoveNext())
		{
			if (_canPizza)
			{
				CheckPizzas(null);
			}
		}
	}

	public void StopBeat()
	{
		//IL_0080: Expected O, but got I4
		//IL_0072: Expected O, but got I4
		if (beatTimer != null)
		{
			beatTimer.Cancel();
		}
		GameManager core = GM.Core;
		Stage stage = core._stage;
		StageModifiers stageModifiers = stage._003CStageMods_003Ek__BackingField;
		float? num = (float?)(((object)stageModifiers._003CEnemySpeed_003Ek__BackingField == null) ? ((object)0) : ((object)1));
		stageModifiers._003CEnemySpeed_003Ek__BackingField = num;
		GameManager core2 = GM.Core;
		core2._stage.CalculateEnemySpeed();
	}

	public void ForceSpoopyMusic()
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		config._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_Foscari2;
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		config2._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
		GM.Core.SetupMusicBanger();
	}

	public void onBeat()
	{
		//IL_0160: Invalid comparison between F4 and I4
		float beats = _beats + 1f;
		_beats = beats;
		float num = _beats + 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000186F7203Fh\"");
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		if (num != 0f)
		{
			ResumeEnemiesMovement();
		}
		else if (enumerator.MoveNext())
		{
			Component component = null;
			throw new NullReferenceException();
		}
	}

	public void ResumeEnemiesMovement()
	{
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		if (enumerator.MoveNext())
		{
			Component component = null;
			throw new NullReferenceException();
		}
	}

	public unsafe void MakePizza()
	{
		//IL_0387: Expected F4, but got O
		//IL_04fe->IL03a8: Incompatible stack heights: 1 vs 0
		//IL_0548->IL0473: Incompatible stack heights: 2 vs 0
		int depth;
		float y;
		float2 float5;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					depth = -renderer.pixelHeight;
					GameManager core = GM.Core;
					if ((object)GM.Core != null)
					{
						GameSessionData gameSessionData = core._gameSessionData;
						if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
						{
							float2 position = gameSessionData._activeCharacter.position;
							GameManager core2 = GM.Core;
							if ((object)GM.Core != null)
							{
								GameSessionData gameSessionData2 = core2._gameSessionData;
								if (core2._gameSessionData != null && (object)gameSessionData2._activeCharacter != null)
								{
									float2 position2 = gameSessionData2._activeCharacter.position;
									object obj = default(object);
									y = (float)obj + 2f;
									GameManager core3 = GM.Core;
									if ((object)GM.Core != null)
									{
										Stage stage = core3._stage;
										if ((object)core3._stage != null)
										{
											TilingTileset tilingTileset = stage._tilingTileset;
											if ((object)stage._tilingTileset != null)
											{
												Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__29_0;
												if (_003C_003Ec._003C_003E9__29_0 == null)
												{
													predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__29_0 = delegate(SuperObject o)
													{
														//IL_0144: Expected I4, but got O
														//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
														//IL_00e6: Expected Ref, but got Unknown
														//IL_00fd: Expected I8, but got I4
														//IL_010b: Unknown result type (might be due to invalid IL or missing references)
														//IL_0110: Expected Ref, but got Unknown
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3D6E]");
														if ((nint)0 == 0)
														{
															_ = 1;
														}
														if ((object)o != null)
														{
															string tiledName = o.m_TiledName;
															if (o.m_TiledName != null)
															{
																object obj3 = "FS_PIZZA";
																if ((object)o.m_TiledName != "FS_PIZZA")
																{
																	if ("FS_PIZZA" != null)
																	{
																		int stringLength = tiledName._stringLength;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
																		if ((nint)stringLength == 0)
																		{
																			ref byte second = ref *(byte*)("FS_PIZZA" + 20);
																			ulong length = (ulong)(tiledName._stringLength + tiledName._stringLength);
																			return System.SpanHelpers.SequenceEqual(ref *(byte*)(o.m_TiledName + 20), ref second, length);
																		}
																	}
																	return false;
																}
																return true;
															}
														}
														NullReferenceException ex = new NullReferenceException();
														return (byte)(int)ex != 0;
													});
												}
												object obj2 = Enumerable.FirstOrDefault(tilingTileset.SavedScripts, predicate);
												bool flag = obj2 == null;
												float5 = position;
												if (!flag)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v32 (System.Object)+10]");
													bool flag2 = (nint)0 == 0;
													float5 = position;
													if (!flag2)
													{
														Transform transform = ((Component)obj2).transform;
														if ((object)transform != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v54 (UnityEngine.Transform)+10]");
															bool flag3 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v54 (UnityEngine.Transform)+10]");
															float2 ret;
															Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
															Transform transform2 = ((Component)obj2).transform;
															if ((object)transform2 != null)
															{
																bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
																Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)(&ret));
																float num = default(float);
																y = num;
																float5 = ret;
																goto IL_0473;
															}
														}
														goto IL_03a8;
													}
												}
												goto IL_0473;
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
		goto IL_03a8;
		IL_03a8:
		throw new NullReferenceException();
		IL_0473:
		PhaserWorld instance = PhaserWorld.Instance;
		GameManager core4 = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage2 = core4._stage;
			if ((object)core4._stage != null && (object)stage2._tilingTileset != null)
			{
				Vector2 defaultMapPosition = stage2._tilingTileset.DefaultMapPosition;
				if ((object)instance != null)
				{
					Vector2 pos = default(Vector2);
					PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "items", "PizzaTime");
					if ((object)phaserSprite != null)
					{
						PhaserSprite pizzaAsprite = phaserSprite.setDepth(depth);
						_pizzaAsprite = pizzaAsprite;
						Circle circle = (_pizzaA = new Circle());
						circle._x = (float)float5;
						circle._y = y;
						circle._radius = 0.16f;
						return;
					}
				}
			}
		}
		goto IL_03a8;
	}

	public void CheckPizzas(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_0114: Expected O, but got I4
		//IL_0106: Expected O, but got I4
		if (!_canPizza || _pizzaA == null)
		{
			return;
		}
		float2 position = character.position;
		float2 position2 = character.position;
		Vector2 point = default(Vector2);
		if (_pizzaA.Contains(point))
		{
			_canPizza = false;
			if (beatTimer != null)
			{
				beatTimer.Cancel();
			}
			GameManager core = GM.Core;
			Stage stage = core._stage;
			StageModifiers stageModifiers = stage._003CStageMods_003Ek__BackingField;
			float? num = (float?)(((object)stageModifiers._003CEnemySpeed_003Ek__BackingField == null) ? ((object)0) : ((object)1));
			stageModifiers._003CEnemySpeed_003Ek__BackingField = num;
			GameManager core2 = GM.Core;
			core2._stage.CalculateEnemySpeed();
			ResumeEnemiesMovement();
			AnimPizza();
		}
	}

	public void AnimPizza()
	{
		//IL_0175: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_00dd: Expected O, but got I4
		//IL_0115: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Bumper, soundConfig, 100f, 4, time);
		PhaserSprite phaserSprite = _pizzaAsprite.setAlpha(0.65f);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_pizzaAsprite != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.ease = Ease.InOutBounce;
		tweenConfig.yoyo = false;
		tweenConfig.duration = 1000f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			_pizzaAsprite.destroy();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private void GimmeAbeat(float interval, Action callback)
	{
		if (beatTimer != null)
		{
			beatTimer.Cancel();
		}
		float duration = interval * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, callback, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: true, canPause: false);
		beatTimer = timer;
	}

	private void ClearBeat()
	{
		if (beatTimer != null)
		{
			beatTimer.Cancel();
		}
	}

	private void _003CAnimPizza_003Eb__31_0()
	{
		_pizzaAsprite.destroy();
	}
}
