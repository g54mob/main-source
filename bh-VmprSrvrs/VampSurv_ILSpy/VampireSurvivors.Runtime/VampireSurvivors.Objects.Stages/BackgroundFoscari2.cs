using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.Speedup;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Props;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundFoscari2 : BackgroundManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<VampireSurvivors.Objects.Characters.CharacterController> _003C_003E9__39_0;

		public static Action _003C_003E9__39_1;

		public static TweenCallback _003C_003E9__39_2;

		public static Func<SuperObject, bool> _003C_003E9__44_0;

		public static Func<SuperObject, bool> _003C_003E9__47_0;

		public static Func<SuperObject, bool> _003C_003E9__48_0;

		public static Func<SuperObject, bool> _003C_003E9__49_0;

		public static Func<SuperObject, bool> _003C_003E9__50_0;

		public static Func<SuperObject, bool> _003C_003E9__55_0;

		public static Action _003C_003E9__68_3;

		public static Predicate<VampireSurvivors.Objects.Characters.CharacterController> _003C_003E9__71_1;

		public static Predicate<VampireSurvivors.Objects.Characters.CharacterController> _003C_003E9__73_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003COnUpdate_003Eb__39_0(VampireSurvivors.Objects.Characters.CharacterController x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._characterType - 75;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal void _003COnUpdate_003Eb__39_1()
		{
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			config._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_Luminaire;
			GameManager core2 = GM.Core;
			PlayerOptionsData config2 = core2._playerOptions.Config;
			config2._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
			GM.Core.SetupMusicBanger();
		}

		internal void _003COnUpdate_003Eb__39_2()
		{
			GameManager core = GM.Core;
			MainGamePage mainGamePage = core._003CMainUI_003Ek__BackingField;
			if ((object)core._003CMainUI_003Ek__BackingField != null && ((UnityEngine.Object)mainGamePage).m_CachedPtr != (IntPtr)0)
			{
				GameManager core2 = GM.Core;
				MainGamePage mainGamePage2 = core2._003CMainUI_003Ek__BackingField;
				mainGamePage2._TimeText.enabled = false;
			}
		}

		internal unsafe bool _003CMakePizza_003Eb__44_0(SuperObject o)
		{
			//IL_0144: Expected I4, but got O
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected Ref, but got Unknown
			//IL_00fd: Expected I8, but got I4
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3D59]");
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

		internal unsafe bool _003CCreateSeal2_003Eb__47_0(SuperObject o)
		{
			//IL_0144: Expected I4, but got O
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected Ref, but got Unknown
			//IL_00fd: Expected I8, but got I4
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3D5A]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((object)o != null)
			{
				string tiledName = o.m_TiledName;
				if (o.m_TiledName != null)
				{
					object obj = "FS_SEAL2";
					if ((object)o.m_TiledName != "FS_SEAL2")
					{
						if ("FS_SEAL2" != null)
						{
							int stringLength = tiledName._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
							if ((nint)stringLength == 0)
							{
								ref byte second = ref *(byte*)("FS_SEAL2" + 20);
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

		internal unsafe bool _003CCreateSeal3_003Eb__48_0(SuperObject o)
		{
			//IL_0144: Expected I4, but got O
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected Ref, but got Unknown
			//IL_00fd: Expected I8, but got I4
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3D5B]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((object)o != null)
			{
				string tiledName = o.m_TiledName;
				if (o.m_TiledName != null)
				{
					object obj = "FS_SEAL3";
					if ((object)o.m_TiledName != "FS_SEAL3")
					{
						if ("FS_SEAL3" != null)
						{
							int stringLength = tiledName._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
							if ((nint)stringLength == 0)
							{
								ref byte second = ref *(byte*)("FS_SEAL3" + 20);
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

		internal unsafe bool _003CCreateBadge_003Eb__49_0(SuperObject o)
		{
			//IL_0144: Expected I4, but got O
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected Ref, but got Unknown
			//IL_00fd: Expected I8, but got I4
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3D5C]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((object)o != null)
			{
				string tiledName = o.m_TiledName;
				if (o.m_TiledName != null)
				{
					object obj = "FS_SEAL2";
					if ((object)o.m_TiledName != "FS_SEAL2")
					{
						if ("FS_SEAL2" != null)
						{
							int stringLength = tiledName._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
							if ((nint)stringLength == 0)
							{
								ref byte second = ref *(byte*)("FS_SEAL2" + 20);
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

		internal unsafe bool _003CCreateShadowServant_003Eb__50_0(SuperObject o)
		{
			//IL_0144: Expected I4, but got O
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected Ref, but got Unknown
			//IL_00fd: Expected I8, but got I4
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3D5D]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((object)o != null)
			{
				string tiledName = o.m_TiledName;
				if (o.m_TiledName != null)
				{
					object obj = "FS_SEAL3";
					if ((object)o.m_TiledName != "FS_SEAL3")
					{
						if ("FS_SEAL3" != null)
						{
							int stringLength = tiledName._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
							if ((nint)stringLength == 0)
							{
								ref byte second = ref *(byte*)("FS_SEAL3" + 20);
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

		internal unsafe bool _003CSpawnJeneviv_003Eb__55_0(SuperObject o)
		{
			//IL_0144: Expected I4, but got O
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected Ref, but got Unknown
			//IL_00fd: Expected I8, but got I4
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3D5E]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((object)o != null)
			{
				string tiledName = o.m_TiledName;
				if (o.m_TiledName != null)
				{
					object obj = "FS_JENEVIV";
					if ((object)o.m_TiledName != "FS_JENEVIV")
					{
						if ("FS_JENEVIV" != null)
						{
							int stringLength = tiledName._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
							if ((nint)stringLength == 0)
							{
								ref byte second = ref *(byte*)("FS_JENEVIV" + 20);
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

		internal void _003CFreeJeneviv_003Eb__68_3()
		{
		}

		internal bool _003CStartSpawningPrismaticMissile_003Eb__71_1(VampireSurvivors.Objects.Characters.CharacterController x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._characterType - 75;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003COnWorldEater_003Eb__73_0(VampireSurvivors.Objects.Characters.CharacterController x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._characterType - 75;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass52_0
	{
		public BackgroundFoscari2 _003C_003E4__this;

		public float tweenXDirection;

		public TweenCallback _003C_003E9__1;

		internal void _003COnSeal2DestructionComplete_003Eb__0()
		{
			//IL_006b: Expected I, but got O
			//IL_00f0: Expected O, but got I4
			//IL_00fe: Expected O, but got I4
			_003C_003E4__this.OpenBounds();
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			BackgroundFoscari2 backgroundFoscari = _003C_003E4__this;
			if ((object)backgroundFoscari._sBlackWall != null)
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
			BackgroundFoscari2 backgroundFoscari2 = _003C_003E4__this;
			float2 position = backgroundFoscari2._sBlackWall.position;
			tweenConfig.duration = 5000f;
			tweenConfig.x = (float?)(object)1;
			tweenConfig.alpha = (float?)(object)1;
			TweenCallback onComplete = _003C_003E9__1;
			if (_003C_003E9__1 == null)
			{
				onComplete = (_003C_003E9__1 = delegate
				{
					BackgroundFoscari2 backgroundFoscari3 = _003C_003E4__this;
					PhaserSprite phaserSprite = backgroundFoscari3._sBlackWall.setVisible(visible: false);
				});
			}
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		}

		internal void _003COnSeal2DestructionComplete_003Eb__1()
		{
			BackgroundFoscari2 backgroundFoscari = _003C_003E4__this;
			PhaserSprite phaserSprite = backgroundFoscari._sBlackWall.setVisible(visible: false);
		}
	}

	private sealed class _003C_003Ec__DisplayClass70_0
	{
		public PhaserSprite s;

		internal void _003CDevourEggs_003Eb__0()
		{
			s.destroy();
		}
	}

	private sealed class _003C_003Ec__DisplayClass73_0
	{
		public WeaponData specialWeaponData;

		internal bool _003COnWorldEater_003Eb__2(Weapon weapon)
		{
			//IL_0061: Expected I4, but got O
			WeaponData weaponData = specialWeaponData;
			if (specialWeaponData != null && (object)weapon != null && weaponData._003CevolvesFrom_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
				bool result = default(bool);
				return result;
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

	private bool _isSealed = true;

	private bool _isPathBlocked;

	private float _waterOffset;

	private EnemyJeneviv _jeneviv;

	private PhaserSprite _sBlackWall;

	private ParticleEmitterManager _shadowParticlesManager;

	private ParticleSystem _shadowEmitter;

	private PropFoscariSeal2 _seal;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _glitchEmitter;

	private ParticleSystem _glitchEmitter2;

	private PropFoscariSeal3 _sealBlue;

	private bool _checkForLuminaire;

	private Timer _luminairePathEvent;

	private static List<WeaponType> s_foscariEventWeapons;

	public static bool s_hasFallenFromFoscari1;

	private float Delay01_Wave = 7000f;

	private float Delay02_Wave = 13500f;

	private float Delay03_Wave = 20500f;

	private float Delay04_Wave = 25000f;

	private float Delay05_Break = 30000f;

	private float Delay06_Move = 33500f;

	private float Delay07_Color = 37000f;

	private float Delay08_Charge = 47000f;

	private float Delay09_WorldEater = 50000f;

	private float Delay10_Start = 65000f;

	private float Delay11_Light = 70000f;

	private List<Weapon> _playerWeapons;

	public static List<WeaponType> FoscariEventWeapons
	{
		get
		{
			return s_foscariEventWeapons;
		}
		set
		{
			s_foscariEventWeapons = value;
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		Action<Destructible> value = OnRemoteDestructibleSpawned;
		Delegate obj = Delegate.Remove(DestructibleInstantiator.OnRemoteDestructibleSpawned, value);
		if ((object)obj == null)
		{
			DestructibleInstantiator.OnRemoteDestructibleSpawned = (Action<Destructible>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Action<Destructible> action = default(Action<Destructible>);
			if (action == null)
			{
				throw new InvalidCastException();
			}
			DestructibleInstantiator.OnRemoteDestructibleSpawned = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				throw new InvalidCastException();
			}
		}
		Action<EnemyController> value2 = OnRemoteEnemySpawned;
		Delegate obj3 = Delegate.Remove(EnemyInstantiator.OnRemoteEnemySpawned, value2);
		if ((object)obj3 == null)
		{
			EnemyInstantiator.OnRemoteEnemySpawned = (Action<EnemyController>)obj3;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		Action<EnemyController> action2 = default(Action<EnemyController>);
		if (action2 != null)
		{
			EnemyInstantiator.OnRemoteEnemySpawned = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 != null)
			{
				return;
			}
			throw new InvalidCastException();
		}
		throw new InvalidCastException();
	}

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
		//IL_0eb7: Expected O, but got I
		//IL_042d: Expected O, but got Ref
		//IL_0447: Expected native int or pointer, but got O
		//IL_0ef1: Expected O, but got I
		//IL_047f: Expected O, but got Ref
		//IL_0499: Expected native int or pointer, but got O
		//IL_0f2b: Expected O, but got I
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
		//IL_0f78: Expected O, but got I4
		//IL_0758: Expected O, but got Ref
		//IL_0772: Expected native int or pointer, but got O
		//IL_0f95: Expected O, but got I4
		//IL_07a4: Expected O, but got Ref
		//IL_07be: Expected native int or pointer, but got O
		//IL_0fcf: Expected O, but got I
		//IL_0838: Expected O, but got I
		//IL_0a3b: Expected O, but got I
		//IL_0bcd: Expected O, but got Ref
		//IL_0be7: Expected native int or pointer, but got O
		//IL_0c06: Expected O, but got I
		//IL_0c22: Expected F4, but got I4
		//IL_1043: Expected F4, but got I4
		//IL_1093: Expected O, but got Ref
		//IL_109f: Expected native int or pointer, but got O
		//IL_10df: Expected O, but got I
		//IL_0c42: Expected F4, but got I8
		//IL_0c67: Expected O, but got Ref
		//IL_0c8e: Expected O, but got I
		//IL_0ca8: Expected native int or pointer, but got O
		//IL_0c54: Expected F4, but got I8
		//IL_0cda: Expected O, but got I4
		//IL_0d02: Expected O, but got Ref
		//IL_0d1c: Expected native int or pointer, but got O
		//IL_1064: Expected O, but got I4
		//IL_0d4c: Expected O, but got I
		//IL_0d9c: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		_canPizza = true;
		_beats = 0f;
		_checkForLuminaire = false;
		_isSealed = true;
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

	public unsafe override void Create()
	{
		//IL_0621: Expected I4, but got O
		//IL_0659: Expected O, but got I4
		//IL_074b: Expected O, but got I4
		//IL_0767: Expected O, but got I4
		//IL_08d7: Expected O, but got I4
		//IL_08c0: Expected O, but got I4
		//IL_0a55: Expected O, but got I4
		//IL_0e24: Expected O, but got I4
		//IL_0e60: Expected O, but got I4
		//IL_0ae3: Expected O, but got I
		//IL_10b0: Expected I, but got O
		//IL_10c6: Expected O, but got I
		//IL_10cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d4: Expected O, but got Unknown
		//IL_114a: Expected I, but got O
		//IL_1384: Expected O, but got I4
		//IL_139b: Expected I, but got I8
		//IL_13c9: Expected O, but got I4
		//IL_1174: Expected O, but got I4
		//IL_1126: Expected I, but got I8
		//IL_0eea: Expected I, but got O
		//IL_0f4e: Expected O, but got I4
		//IL_0d56: Expected I4, but got O
		//IL_0d77: Expected I4, but got O
		//IL_0d9d: Expected I4, but got O
		//IL_0d9d: Expected F4, but got I4
		//IL_0daf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db4: Expected O, but got Unknown
		//IL_0c87: Expected O, but got I
		//IL_0cd6: Expected O, but got I
		//IL_0ce2: Expected I4, but got O
		base.Create();
		if (!GM.Core.IsStageHost)
		{
			Action<Destructible> b = OnRemoteDestructibleSpawned;
			Delegate obj = Delegate.Combine(DestructibleInstantiator.OnRemoteDestructibleSpawned, b);
			if ((object)obj == null)
			{
				DestructibleInstantiator.OnRemoteDestructibleSpawned = null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				Action<Destructible> action = default(Action<Destructible>);
				if (action == null)
				{
					throw new InvalidCastException();
				}
				DestructibleInstantiator.OnRemoteDestructibleSpawned = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					throw new InvalidCastException();
				}
			}
			Action<EnemyController> b2 = OnRemoteEnemySpawned;
			Delegate obj3 = Delegate.Combine(EnemyInstantiator.OnRemoteEnemySpawned, b2);
			if ((object)obj3 == null)
			{
				EnemyInstantiator.OnRemoteEnemySpawned = null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				Action<EnemyController> action2 = default(Action<EnemyController>);
				if (action2 == null)
				{
					throw new InvalidCastException();
				}
				EnemyInstantiator.OnRemoteEnemySpawned = action2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					throw new InvalidCastException();
				}
			}
		}
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<AchievementType> list = config._003CAchievements_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ rcx_v24 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj5 = default(object);
			if ((nint)obj5 != -1)
			{
				_isPathBlocked = false;
			}
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		List<AchievementType> list2 = config2._003CAchievements_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v28 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj6 = default(object);
			if ((nint)obj6 != -1)
			{
				_isSealed = false;
				if (GM.Core.HasCharacterInPlay(CharacterType.ELEANOR))
				{
					_isSealed = true;
				}
			}
		}
		GameManager core3 = GM.Core;
		PlayerOptionsData config3 = core3._playerOptions.Config;
		_saveBGM = config3._003CSelectedBGM_003Ek__BackingField;
		GameManager core4 = GM.Core;
		PlayerOptionsData config4 = core4._playerOptions.Config;
		_saveBGMMod = config4._003CSelectedBGMMod_003Ek__BackingField;
		GameManager core5 = GM.Core;
		PlayerOptionsData config5 = core5._playerOptions.Config;
		GameManager core6 = default(GameManager);
		if (!config5._003CSelectedInverse_003Ek__BackingField)
		{
			core6 = GM.Core;
		}
		PlayerOptionsData config6 = core6._playerOptions.Config;
		float waterOffset;
		if (config6._003CSelectedInverse_003Ek__BackingField)
		{
			GameManager core7 = GM.Core;
			PlayerOptionsData config7 = core7._playerOptions.Config;
			if (config7._003CVisuallyInvertStages_003Ek__BackingField)
			{
				waterOffset = 0.05f;
				goto IL_120a;
			}
		}
		waterOffset = -0.05f;
		goto IL_120a;
		IL_137b:
		object obj7 = 24;
		Action action3;
		((Delegate)action3).extra_arg = unchecked((nint)6447293568L);
		EnemyJeneviv jeneviv;
		Delegate obj8 = Delegate.Combine(jeneviv._003COnActivated_003Ek__BackingField, action3);
		bool flag = (object)obj8 == null;
		float? num = (float?)(object)0;
		if (!flag)
		{
			bool flag2 = (object)obj8.GetType() != typeof(Action);
			num = (float?)(object)0;
			if (!flag2)
			{
				num = (float?)obj8;
			}
			if ((object)num == null)
			{
				throw new InvalidCastException();
			}
		}
		jeneviv._003COnActivated_003Ek__BackingField = (Action)num;
		return;
		IL_12fb:
		s_hasFallenFromFoscari1 = false;
		goto IL_09ef;
		IL_09ef:
		List<WeaponType> list3 = s_foscariEventWeapons;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rax_v120 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		Vector2 pos = default(Vector2);
		bool flag3;
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		int num6 = default(int);
		PhaserScene.Renderer renderer;
		if ((nint)0 > (nint)0)
		{
			List<EquipmentInfo> list4 = GM.Core.RemoveAllEquipmentFromPlayers();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186F77230");
			float? num2 = (float?)(object)0;
			TweenConfig tweenConfig;
			object[] array;
			object obj11 = default(object);
			while (true)
			{
				List<WeaponType> list5 = s_foscariEventWeapons;
				float? num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rdx_v75 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				if ((nint)num3 < 0)
				{
					List<WeaponType> list6 = s_foscariEventWeapons;
					float? num4 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ rax_v213 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					if ((nint)num4 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ rax_v213 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v505 @ rcx_v179+20+v299 @ rdi_v19 (System.Nullable`1<System.Single>)*4]");
						System.Int32Enum weaponType = (System.Int32Enum)0;
						GameManager core8 = GM.Core;
						Dictionary<WeaponType, List<WeaponData>> convertedWeapons = core8._dataManager.GetConvertedWeapons();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v505 @ rcx_v179+20+v299 @ rdi_v19 (System.Nullable`1<System.Single>)*4]");
						int num5 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).FindEntry((System.Int32Enum)0);
						if (num5 >= 0)
						{
							GameManager core9 = GM.Core;
							Dictionary<WeaponType, List<WeaponData>> convertedWeapons2 = core9._dataManager.GetConvertedWeapons();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v505 @ rcx_v179+20+v299 @ rdi_v19 (System.Nullable`1<System.Single>)*4]");
							object obj10 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons2).get_Item((System.Int32Enum)0);
							if (obj10 != null)
							{
								List<WeaponData> list7 = ((Dictionary<WeaponType, List<WeaponData>>)obj10).get_Item(WeaponType.VOID);
								if (list7 != null)
								{
									List<WeaponData> list8 = ((Dictionary<WeaponType, List<WeaponData>>)obj10).get_Item(WeaponType.VOID);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rax_v232 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+60]");
									if ((nint)0 != 0)
									{
										List<WeaponData> list9 = ((Dictionary<WeaponType, List<WeaponData>>)obj10).get_Item(WeaponType.VOID);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ rax_v233 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+68]");
										if ((nint)0 != 0)
										{
											List<WeaponData> list10 = ((Dictionary<WeaponType, List<WeaponData>>)obj10).get_Item(WeaponType.VOID);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ rax_v234 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+68]");
											List<WeaponData> list11 = ((Dictionary<WeaponType, List<WeaponData>>)0).get_Item(WeaponType.VOID);
											if (list11 != null)
											{
												List<WeaponData> list12 = ((Dictionary<WeaponType, List<WeaponData>>)obj10).get_Item(WeaponType.VOID);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v430 @ rax_v236 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+68]");
												List<WeaponData> list13 = ((Dictionary<WeaponType, List<WeaponData>>)0).get_Item(WeaponType.VOID);
												weaponType = (System.Int32Enum)list13;
											}
										}
									}
								}
							}
						}
						GameManager core10 = GM.Core;
						GameSessionData gameSessionData = core10._gameSessionData;
						float2 position = gameSessionData._activeCharacter.position;
						GameManager core11 = GM.Core;
						GameSessionData gameSessionData2 = core11._gameSessionData;
						float2 position2 = gameSessionData2._activeCharacter.position;
						List<WeaponData> list14 = ((Dictionary<WeaponType, List<WeaponData>>)(object)gameSessionData2._activeCharacter).get_Item((WeaponType)typeof(GM));
						List<WeaponData> list15 = ((Dictionary<WeaponType, List<WeaponData>>)(object)gameSessionData2._activeCharacter).get_Item((WeaponType)typeof(GM));
						Pickup pickup = core10.MakeStagePickup(pos, ItemType.WEAPON, (WeaponType)weaponType, flag3 ? 1 : 0, (ItemType)monoBehaviour, (byte)num6 != 0);
						num2 = (float?)(object)((_003F?)num2 + 1);
						flag3 = flag3;
						continue;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				}
				else
				{
					List<WeaponType> list16 = new List<WeaponType>();
					list16._002Ector();
					PhaserWorld instance = PhaserWorld.Instance;
					PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "vfx", "blackDot");
					PhaserSprite component = phaserSprite.setOrigin(0f, (float?)(object)0);
					PhaserSprite phaserSprite2 = RenderingExtensions.SetScrollFactor(component, 0f);
					PhaserSprite phaserSprite3 = phaserSprite2.setScale(renderer.width, (float?)(object)1);
					PhaserSprite phaserSprite4 = phaserSprite3.setAlpha(1f);
					PhaserSprite sFader = phaserSprite4.setDepth(10000);
					_sFader = sFader;
					tweenConfig = new TweenConfig();
					array = new object[1];
					if ((object)_sFader == null)
					{
						break;
					}
					nint num7 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					if (obj11 != null)
					{
						break;
					}
				}
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 1000f;
			tweenConfig.alpha = (float?)(object)1;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		}
		if (!_isPathBlocked)
		{
			PhaserSprite phaserSprite5 = _sBlackWall.setVisible(visible: false);
			CreateBadge();
		}
		else
		{
			CreateSeal2();
		}
		GameManager core12 = GM.Core;
		CharacterLoader.LoadCharacterTexture("character_luminaire", CharacterType.LUMINAIRE, core12._dataManager);
		if (!_isSealed)
		{
			CreateShadowServant();
			MakePizza();
			SpawnJeneviv();
			EnemyJeneviv jeneviv2 = _jeneviv;
			if ((object)_jeneviv == null || ((UnityEngine.Object)jeneviv2).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			jeneviv = _jeneviv;
			action3 = null;
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2322 @ r10_v3 (Il2CppMethodInfo)+8]");
			((Delegate)action3).method_ptr = (IntPtr)0;
			((Delegate)action3).method = (nint)__ldftn(BackgroundFoscari2.OnJenevivActivation);
			((Delegate)action3).m_target = this;
			((Delegate)action3).method_code = (IntPtr)action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2322 @ r10_v3 (Il2CppMethodInfo)+4C]");
			object obj12 = (nint)0 >> 4;
			object obj13 = obj12 & 1;
			nint num9;
			if (obj13 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2322 @ r10_v3 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num9 = unchecked((nint)6447293664L);
					goto IL_137b;
				}
			}
			num9 = ((Delegate)action3).method_ptr;
			((Delegate)action3).method_code = (IntPtr)((Delegate)action3).m_target;
			goto IL_137b;
		}
		ForceSpoopyMusic();
		CreateSeal3();
		SpawnJeneviv();
		SealJeneviv();
		return;
		IL_120a:
		_waterOffset = waterOffset;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene._renderer;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer3 = s_scene2._renderer;
				float y = renderer3.height * 0.5f;
				float x = renderer2.width * 0.5f;
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
					PhaserScene.Renderer renderer4 = s_scene3._renderer;
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene4 = ArcadePhysics.s_scene;
						PhaserScene.Renderer renderer5 = s_scene4._renderer;
						tileSpriteBuilder._tileHeight = renderer5.height;
						tileSpriteBuilder._tileWidth = renderer4.width;
						tileSpriteBuilder._name = "Water";
						TileSprite water = tileSpriteBuilder.Build();
						_water = water;
						TileSprite tileSprite = RenderingExtensions.SetScrollFactor(_water, 0f);
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene5 = ArcadePhysics.s_scene;
							PhaserScene.Renderer renderer6 = s_scene5._renderer;
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene6 = ArcadePhysics.s_scene;
								renderer = s_scene6._renderer;
								PhaserWorld instance2 = PhaserWorld.Instance;
								flag3 = (byte)(int)text != 0;
								PhaserSprite phaserSprite6 = instance2.AddPhaserSprite(pos, "vfx", "stageShadows");
								PhaserSprite component2 = phaserSprite6.setOrigin(0f, (float?)(object)0);
								PhaserSprite component3 = RenderingExtensions.SetScrollFactor(component2, 0f);
								float xScale = renderer.width / 1.5999999f;
								PhaserSprite phaserSprite7 = RenderingExtensions.SetScale(component3, xScale, renderer6.height);
								PhaserSprite phaserSprite8 = phaserSprite7.setAlpha(1f);
								PhaserSprite phaserSprite9 = phaserSprite8.setDepth(10000);
								GameObject gameObject = phaserSprite9.gameObject;
								((UnityEngine.Object)gameObject).SetName("stageShadows");
								_sDarkness = phaserSprite9;
								PhaserWorld instance3 = PhaserWorld.Instance;
								PhaserSprite phaserSprite10 = instance3.AddPhaserSprite(pos, "vfx", "trueBlack");
								PhaserSprite phaserSprite11 = phaserSprite10.setOrigin(0f, (float?)(object)0);
								PhaserSprite phaserSprite12 = phaserSprite11.setScale(5120f, (float?)(object)1);
								PhaserSprite phaserSprite13 = phaserSprite12.setAlpha(1f);
								PhaserSprite phaserSprite14 = phaserSprite13.setDepth(10000);
								GameObject gameObject2 = phaserSprite14.gameObject;
								((UnityEngine.Object)gameObject2).SetName("blackWall");
								_sBlackWall = phaserSprite14;
								Action onComplete = onBeat;
								if (beatTimer != null)
								{
									beatTimer.Cancel();
								}
								TimerType type = default(TimerType);
								Timer timer = Timers.Register(0.411f, onComplete, null, isLooped: true, flag3, monoBehaviour, num6, type, isOnlineTimer: true, canPause: false);
								beatTimer = timer;
								GameManager core13 = GM.Core;
								Stage stage = core13._stage;
								StageModifiers stageModifiers = stage._003CStageMods_003Ek__BackingField;
								float? num11;
								if ((object)stageModifiers._003CEnemySpeed_003Ek__BackingField != null)
								{
									object obj14 = default(object);
									float num10 = (float)obj14 + 1f;
									num11 = (float?)(object)1;
								}
								else
								{
									float num10 = 0.411f;
									num11 = (float?)(object)0;
								}
								stageModifiers._003CEnemySpeed_003Ek__BackingField = num11;
								GameManager core14 = GM.Core;
								core14._stage.CalculateEnemySpeed();
								if (s_hasFallenFromFoscari1)
								{
									GameManager core15 = GM.Core;
									PlayerOptionsData config8 = core15._playerOptions.Config;
									int num12 = config8._003CRunDestroyedProps_003Ek__BackingField.FindEntry(PropType.FOSCARI_SEAL_1);
									if (num12 >= 0)
									{
										GameManager core16 = GM.Core;
										PlayerOptionsData config9 = core16._playerOptions.Config;
										int num13 = config9._003CRunDestroyedProps_003Ek__BackingField.get_Item(PropType.FOSCARI_SEAL_1);
										if (num13 > 0)
										{
											goto IL_12fb;
										}
									}
									GameManager core17 = GM.Core;
									core17._playerOptions.IncreaseDestroyedPropCount(PropType.FOSCARI_SEAL_1);
									goto IL_12fb;
								}
								goto IL_09ef;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void OnRemoteEnemySpawned(EnemyController enemy)
	{
		//IL_0038: Expected I, but got O
		//IL_0040: Expected I, but got O
		//IL_0050: Expected O, but got I
		//IL_008c: Expected O, but got I
		//IL_00d1: Expected I, but got O
		//IL_00d9: Expected I, but got O
		//IL_00e9: Expected O, but got I
		//IL_0125: Expected O, but got I
		if ((object)enemy != null)
		{
			if (enemy._enemyType != EnemyType.FS_BOSS_JENEVIV)
			{
				return;
			}
			nint num = (nint)typeof(EnemyJeneviv);
			nint num2 = (nint)enemy;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyJeneviv>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyJeneviv>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v12+FFFFFFF8+v97 @ rax_v11*8]");
				if (0 == (nint)typeof(EnemyJeneviv))
				{
					_jeneviv = (EnemyJeneviv)enemy;
					nint num4 = (nint)typeof(EnemyJeneviv);
					nint num5 = (nint)enemy;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyJeneviv>)+130]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyJeneviv>)+130]");
					if (num6 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+C8]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rax_v14+FFFFFFF8+v285 @ rax_v13*8]");
						if (0 == (nint)typeof(EnemyJeneviv))
						{
							if (!_isSealed)
							{
								EnemyJeneviv jeneviv = _jeneviv;
								if ((object)_jeneviv != null)
								{
									Action b = OnJenevivActivation;
									Delegate obj5 = Delegate.Combine(jeneviv._003COnActivated_003Ek__BackingField, b);
									bool flag = (object)obj5 == null;
									Delegate obj6 = null;
									if (!flag)
									{
										bool flag2 = (object)obj5.GetType() != typeof(Action);
										obj6 = null;
										if (!flag2)
										{
											obj6 = obj5;
										}
										if ((object)obj6 == null)
										{
											goto IL_02a4;
										}
									}
									_jeneviv.OnActivated = (Action)obj6;
									return;
								}
								goto IL_0248;
							}
							SealJeneviv();
							return;
						}
					}
					throw new InvalidCastException();
				}
			}
			throw new InvalidCastException();
		}
		goto IL_0248;
		IL_02a4:
		throw new InvalidCastException();
		IL_0248:
		NullReferenceException ex = new NullReferenceException();
		goto IL_02a4;
	}

	private void OnRemoteDestructibleSpawned(Destructible destructible)
	{
		//IL_0038: Expected I, but got O
		//IL_0040: Expected I, but got O
		//IL_0050: Expected O, but got I
		//IL_01bd: Expected I, but got O
		//IL_01c5: Expected I, but got O
		//IL_01d5: Expected O, but got I
		//IL_008c: Expected O, but got I
		//IL_0211: Expected O, but got I
		//IL_00d1: Expected I, but got O
		//IL_00d9: Expected I, but got O
		//IL_00e9: Expected O, but got I
		//IL_0256: Expected I, but got O
		//IL_025e: Expected I, but got O
		//IL_026e: Expected O, but got I
		//IL_0125: Expected O, but got I
		//IL_02aa: Expected O, but got I
		if (destructible._destructibleType == PropType.FOSCARI_SEAL_2)
		{
			nint num = (nint)typeof(PropFoscariSeal2);
			nint num2 = (nint)destructible;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal2>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal2>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rax_v29+FFFFFFF8+v126 @ rax_v28*8]");
				if (0 == (nint)typeof(PropFoscariSeal2))
				{
					_seal = (PropFoscariSeal2)destructible;
					nint num4 = (nint)typeof(PropFoscariSeal2);
					nint num5 = (nint)destructible;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal2>)+130]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ r8_v16 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+130]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal2>)+130]");
					if (num6 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ r8_v16 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+C8]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rax_v31+FFFFFFF8+v275 @ rax_v30*8]");
						if (0 == (nint)typeof(PropFoscariSeal2))
						{
							PropFoscariSeal2 seal = _seal;
							Action action = OnSeal2DestructionComplete;
							seal._003CDestroyedCallback_003Ek__BackingField = action;
							return;
						}
					}
					throw new InvalidCastException();
				}
			}
			throw new InvalidCastException();
		}
		if (destructible._destructibleType != PropType.FOSCARI_SEAL_3)
		{
			return;
		}
		nint num7 = (nint)typeof(PropFoscariSeal3);
		nint num8 = (nint)destructible;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal3>)+130]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+130]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal3>)+130]");
		if (num9 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+C8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rax_v14+FFFFFFF8+v208 @ rax_v13*8]");
			if (0 == (nint)typeof(PropFoscariSeal3))
			{
				_sealBlue = (PropFoscariSeal3)destructible;
				nint num10 = (nint)typeof(PropFoscariSeal3);
				nint num11 = (nint)destructible;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v377 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal3>)+130]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v376 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+130]");
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v377 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal3>)+130]");
				if (num12 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v376 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+C8]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rax_v16+FFFFFFF8+v379 @ rax_v15*8]");
					if (0 == (nint)typeof(PropFoscariSeal3))
					{
						Action destroyedCallback = FreeJeneviv;
						_sealBlue.DestroyedCallback = destroyedCallback;
						return;
					}
				}
				throw new InvalidCastException();
			}
		}
		throw new InvalidCastException();
	}

	public override void OnInitCompleted()
	{
		//IL_0148: Expected O, but got I4
		//IL_017b: Expected O, but got I4
		//IL_0184: Expected O, but got I4
		//IL_01f8: Expected O, but got I4
		//IL_00c1: Expected O, but got I4
		if (!_isPathBlocked)
		{
			OpenBounds();
		}
		else
		{
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			float num;
			if (config._003CSelectedInverse_003Ek__BackingField)
			{
				GameManager core2 = GM.Core;
				PlayerOptionsData config2 = core2._playerOptions.Config;
				if (config2._003CVisuallyInvertStages_003Ek__BackingField)
				{
					GameManager core3 = GM.Core;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
					core3._003CHardBounds_003Ek__BackingField = (Rect?)(object)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A125B0]");
					_ = 0;
					_sBlackWall.X = 51.199997f;
					object obj = 0;
					num = 51.199997f;
					goto IL_00fe;
				}
			}
			float yMax = default(float);
			bool skipInverseCalculation = default(bool);
			GM.Core.SetHardBoundsMinMax(5120f, 256f, 9984f, yMax, skipInverseCalculation);
			num = 5120f;
		}
		goto IL_00fe;
		IL_00fe:
		GameManager core4 = GM.Core;
		PlayerOptionsData config3 = core4._playerOptions.Config;
		List<ItemType> list = config3._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		bool flag = (nint)0 == 0;
		object obj2 = 0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj3 = default(object);
			bool flag2 = (nint)obj3 != -1;
			object obj = 0;
			obj2 = 22;
			if (flag2)
			{
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
		BgmType bgmType = default(BgmType);
		SoundManager.StopMusic(bgmType);
	}

	public void OnJenevivActivation()
	{
		SpeedupManager instance = SpeedupManager.Instance;
		instance.SetSpeedupBlocked(isBlocked: true);
		StopBeat();
		ResumeEnemiesMovement();
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
		//IL_0a7f: Expected I, but got O
		//IL_0abb: Expected I, but got O
		//IL_0090: Expected F4, but got O
		//IL_00b1: Expected I, but got O
		//IL_00d6: Expected F4, but got O
		//IL_00ee: Expected I, but got O
		//IL_0b08: Expected I, but got O
		//IL_01ce: Expected I, but got O
		//IL_01fc: Expected I, but got O
		//IL_02a8: Expected I, but got O
		//IL_0361: Expected I, but got O
		//IL_0ba5: Expected I, but got O
		//IL_0c0e: Expected I, but got O
		//IL_02f0: Expected I, but got O
		//IL_0c3f: Expected I, but got O
		//IL_032f: Expected I4, but got I8
		//IL_0439: Expected I, but got O
		//IL_04b7: Expected I, but got O
		//IL_04a4: Expected I, but got O
		//IL_0504: Expected O, but got I
		//IL_05c6: Expected I, but got O
		//IL_0621: Expected I, but got O
		//IL_0d2a: Expected I, but got O
		//IL_0d5b: Expected I, but got O
		//IL_0de0: Expected I, but got O
		//IL_07fd: Expected O, but got I4
		//IL_083f: Expected I, but got O
		//IL_089b: Expected O, but got I4
		//IL_089b: Expected I4, but got O
		//IL_090f: Expected I, but got O
		//IL_0994: Expected O, but got I4
		//IL_09b0: Expected O, but got I4
		//IL_09be: Expected O, but got I4
		base.OnUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = num * _waterOffset;
		float num3 = num2 * 0.01f;
		float tilingOffset = _tilingOffset - num3;
		_tilingOffset = tilingOffset;
		TileSprite water = _water;
		nint num4 = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num5 = 0;
		Vector2 pos = default(Vector2);
		if ((object)GM.Core != null)
		{
			nint num6 = (nint)typeof(ArcadePhysics);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v707 @ rax_v12 (Il2CppClass<ArcadePhysics>)+B8]");
			nint num7 = 0;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			bool flag = ArcadePhysics.s_scene == null;
			num5 = num7;
			if (!flag)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				bool flag2 = s_scene._renderer == null;
				num5 = num7;
				if (!flag2)
				{
					bool flag3 = (object)_water == null;
					num5 = num7;
					if (!flag3)
					{
						water._xScrollOffset = (float)renderer.screenCenter;
						bool flag4 = (object)water._spriteScroller == null;
						num5 = (nint)water._spriteScroller;
						if (!flag4)
						{
							water._spriteScroller.SetScrollOffsetX((float)renderer.screenCenter);
							TileSprite water2 = _water;
							nint num8 = (nint)typeof(GM);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v671 @ rax_v16 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
							nint num9 = 0;
							bool flag5 = (object)GM.Core == null;
							num5 = num9;
							if (!flag5)
							{
								nint num10 = (nint)typeof(ArcadePhysics);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v908 @ rax_v18 (Il2CppClass<ArcadePhysics>)+B8]");
								nint num11 = 0;
								PhaserScene s_scene2 = ArcadePhysics.s_scene;
								bool flag6 = ArcadePhysics.s_scene == null;
								num5 = num11;
								if (!flag6)
								{
									PhaserScene.Renderer renderer2 = s_scene2._renderer;
									bool flag7 = s_scene2._renderer == null;
									num5 = num11;
									if (!flag7)
									{
										bool flag8 = (object)_water == null;
										num5 = num11;
										if (!flag8)
										{
											float num12 = _tilingOffset;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v672 @ rax_v20 (PhaserScene+Renderer)+38]");
											float scrollOffsetY = (water2._yScrollOffset = num12 + 0f);
											bool flag9 = (object)water2._spriteScroller == null;
											num5 = (nint)water2._spriteScroller;
											if (!flag9)
											{
												water2._spriteScroller.SetScrollOffsetY(scrollOffsetY);
												nint num13 = (nint)typeof(GM);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ rax_v22 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
												nint num14 = 0;
												GameManager core = GM.Core;
												bool flag10 = (object)GM.Core == null;
												num5 = num14;
												if (!flag10)
												{
													bool flag11 = core._characters == null;
													num5 = num14;
													if (!flag11)
													{
														List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
														while (enumerator.MoveNext())
														{
															if (_canPizza)
															{
																CheckPizzas(null);
															}
														}
														if (!_isPathBlocked)
														{
															goto IL_0334;
														}
														nint num15 = (nint)typeof(GM);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v674 @ rax_v181 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
														nint num16 = 0;
														bool flag12 = (object)GM.Core == null;
														num5 = num16;
														if (!flag12)
														{
															nint num17 = (nint)typeof(ArcadePhysics);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1195 @ rax_v183 (Il2CppClass<ArcadePhysics>)+B8]");
															nint num18 = 0;
															PhaserScene s_scene3 = ArcadePhysics.s_scene;
															bool flag13 = ArcadePhysics.s_scene == null;
															num5 = num18;
															if (!flag13)
															{
																num5 = (nint)s_scene3._renderer;
																if (s_scene3._renderer != null)
																{
																	RenderingExtensions.EmitParticleAt(_shadowEmitter, pos, -1);
																	goto IL_0334;
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
		}
		goto IL_0a00;
		IL_0a00:
		throw new NullReferenceException();
		IL_0334:
		if (!_checkForLuminaire)
		{
			return;
		}
		nint num19 = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1124 @ rax_v31 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num20 = 0;
		GameManager core2 = GM.Core;
		bool flag14 = (object)GM.Core == null;
		num5 = num20;
		if (!flag14)
		{
			Predicate<VampireSurvivors.Objects.Characters.CharacterController> match = _003C_003Ec._003C_003E9__39_0;
			bool flag15 = _003C_003Ec._003C_003E9__39_0 != null;
			num5 = (nint)typeof(_003C_003Ec);
			if (!flag15)
			{
				Predicate<VampireSurvivors.Objects.Characters.CharacterController> predicate = delegate(VampireSurvivors.Objects.Characters.CharacterController x)
				{
					//IL_0052: Expected I4, but got O
					//IL_0030: Expected O, but got I4
					if ((object)x == null)
					{
						NullReferenceException ex2 = new NullReferenceException();
						return (byte)(int)ex2 != 0;
					}
					object obj2 = x._characterType - 75;
					return obj2 == null;
				};
				nint num21 = (nint)typeof(_003C_003Ec);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1278 @ rax_v173 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundFoscari2+<>c>)+B8]");
				nint num22 = 0;
				_003C_003Ec._003C_003E9__39_0 = predicate;
				match = predicate;
				num5 = num22;
			}
			if (core2._characters != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = core2._characters.Find(match);
				if ((object)characterController == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				bool flag16 = (object)characterController._weaponsManager == null;
				num5 = (nint)characterController._weaponsManager;
				if (!flag16)
				{
					Equipment equipmentByType = characterController._weaponsManager.GetEquipmentByType(WeaponType.PRISMATICMISS2);
					bool flag18;
					if ((object)equipmentByType != null)
					{
						bool flag17 = ((UnityEngine.Object)equipmentByType).m_CachedPtr == (IntPtr)0;
						flag18 = !flag17;
						num5 = (nint)typeof(UnityEngine.Object);
					}
					else
					{
						num5 = (nint)typeof(UnityEngine.Object);
						flag18 = false;
					}
					if (!flag18)
					{
						return;
					}
					object jeneviv = _jeneviv;
					if ((object)_jeneviv != null)
					{
						_ = 0;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ r15_v7 (System.Object)+290]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ r15_v7 (System.Object)+290]");
							((Timer)0).Cancel();
						}
						Action onComplete = delegate
						{
							float hp = ((EnemyController)_jeneviv)._hp - _jeneviv._shieldDamage;
							_jeneviv._hasShield = false;
							((EnemyController)_jeneviv)._hp = hp;
						};
						bool flag19 = default(bool);
						MonoBehaviour monoBehaviour = default(MonoBehaviour);
						int num23 = default(int);
						TimerType timerType = default(TimerType);
						Timer timer = Timers.Register(45.000004f, onComplete, null, isLooped: false, flag19, monoBehaviour, num23, timerType, isOnlineTimer: false, canPause: false);
						if (_luminairePathEvent != null)
						{
							_luminairePathEvent.Cancel();
						}
						_checkForLuminaire = false;
						SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, 0f, 500f);
						nint num24 = (nint)typeof(GM);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1669 @ rax_v60 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
						nint num25 = 0;
						GameManager core3 = GM.Core;
						bool flag20 = (object)GM.Core == null;
						num5 = num25;
						if (!flag20)
						{
							core3._003CCanInterrupt_003Ek__BackingField = false;
							nint num26 = (nint)typeof(GM);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1670 @ rax_v62 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
							nint num27 = 0;
							GameManager core4 = GM.Core;
							bool flag21 = (object)GM.Core == null;
							num5 = num27;
							if (!flag21)
							{
								core4._003CCanPause_003Ek__BackingField = false;
								Action onComplete2 = _003C_003Ec._003C_003E9__39_1;
								bool flag22 = _003C_003Ec._003C_003E9__39_1 != null;
								num5 = (nint)typeof(_003C_003Ec);
								if (!flag22)
								{
									Action action = delegate
									{
										GameManager core6 = GM.Core;
										PlayerOptionsData config = core6._playerOptions.Config;
										config._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_Luminaire;
										GameManager core7 = GM.Core;
										PlayerOptionsData config2 = core7._playerOptions.Config;
										config2._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
										GM.Core.SetupMusicBanger();
									};
									nint num28 = (nint)typeof(_003C_003Ec);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1756 @ rax_v136 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundFoscari2+<>c>)+B8]");
									nint num29 = 0;
									_003C_003Ec._003C_003E9__39_1 = action;
									onComplete2 = action;
									num5 = num29;
								}
								Timer timer2 = Timers.Register(1f, onComplete2, null, isLooped: false, flag19, monoBehaviour, num23, timerType, isOnlineTimer: false, canPause: false);
								if ((object)GM.Core != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AD90]");
									num5 = 0;
									PhaserScene s_scene4 = ArcadePhysics.s_scene;
									if (ArcadePhysics.s_scene != null && s_scene4._renderer != null && (object)GM.Core != null)
									{
										PhaserScene s_scene5 = ArcadePhysics.s_scene;
										if (ArcadePhysics.s_scene != null && s_scene5._renderer != null && (object)GM.Core != null)
										{
											num5 = (nint)ArcadePhysics.s_scene;
											if (ArcadePhysics.s_scene != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rcx_v55 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+28]");
												if ((nint)0 != 0)
												{
													GameObject gameObject = base.gameObject;
													PhaserSprite component = RenderingExtensions.AddPhaserSprite(gameObject, pos, "character_luminaire", "Luminaire_i01");
													PhaserSprite phaserSprite = RenderingExtensions.SetScrollFactor(component, 0f);
													if ((object)phaserSprite != null)
													{
														PhaserSprite phaserSprite2 = phaserSprite.setScale(2f, (float?)(object)0);
														List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Luminaire_i0", 1, 5, "character_luminaire", flag19 ? 1 : 0);
														bool flag23 = (object)phaserSprite2 == null;
														num5 = unchecked((nint)"Luminaire_i0");
														if (!flag23 && (object)phaserSprite2._spriteAnimation != null)
														{
															phaserSprite2._spriteAnimation.AddAnimation("walk", animationFrames, 8, flag19, (byte)(int)monoBehaviour != 0, (Action)num23, (byte)timerType != 0);
															if ((object)phaserSprite2._spriteAnimation != null)
															{
																phaserSprite2._spriteAnimation.SetAnimation("walk");
																TweenConfig tweenConfig = new TweenConfig();
																object[] array = new object[1];
																bool flag24 = array == null;
																num5 = (nint)typeof(object[]);
																if (!flag24)
																{
																	GameManager core5 = GM.Core;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																	object obj = default(object);
																	if (obj == null)
																	{
																		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
																		throw ex;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																	if (tweenConfig != null)
																	{
																		tweenConfig.targets = array;
																		tweenConfig.scale = (float?)(object)1;
																		tweenConfig.ease = Ease.InOutSine;
																		tweenConfig.localX = (float?)(object)1;
																		tweenConfig.localY = (float?)(object)1;
																		tweenConfig.duration = 1500f;
																		TweenCallback onComplete3 = _003C_003Ec._003C_003E9__39_2;
																		if (_003C_003Ec._003C_003E9__39_2 == null)
																		{
																			onComplete3 = (_003C_003Ec._003C_003E9__39_2 = delegate
																			{
																				GameManager core6 = GM.Core;
																				MainGamePage mainGamePage = core6._003CMainUI_003Ek__BackingField;
																				if ((object)core6._003CMainUI_003Ek__BackingField != null && ((UnityEngine.Object)mainGamePage).m_CachedPtr != (IntPtr)0)
																				{
																					GameManager core7 = GM.Core;
																					MainGamePage mainGamePage2 = core7._003CMainUI_003Ek__BackingField;
																					mainGamePage2._TimeText.enabled = false;
																				}
																			});
																		}
																		tweenConfig.onComplete = onComplete3;
																		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
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
				}
			}
		}
		goto IL_0a00;
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
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000186F6806Fh\"");
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
												Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__44_0;
												if (_003C_003Ec._003C_003E9__44_0 == null)
												{
													predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__44_0 = delegate(SuperObject o)
													{
														//IL_0144: Expected I4, but got O
														//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
														//IL_00e6: Expected Ref, but got Unknown
														//IL_00fd: Expected I8, but got I4
														//IL_010b: Unknown result type (might be due to invalid IL or missing references)
														//IL_0110: Expected Ref, but got Unknown
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3D59]");
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
		if (_canPizza && _pizzaA != null)
		{
			float2 position = character.position;
			float2 position2 = character.position;
			Vector2 point = default(Vector2);
			if (_pizzaA.Contains(point))
			{
				_canPizza = false;
				StopBeat();
				ResumeEnemiesMovement();
				AnimPizza();
			}
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

	public unsafe void CreateSeal2()
	{
		//IL_01aa: Expected I, but got O
		//IL_01b8: Expected I, but got O
		//IL_01c8: Expected O, but got I
		//IL_0248: Expected O, but got I4
		//IL_0204: Expected O, but got I
		//IL_023a: Expected O, but got I4
		//IL_0401->IL02da: Incompatible stack heights: 1 vs 0
		//IL_043b->IL037f: Incompatible stack heights: 2 vs 0
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				TilingTileset tilingTileset = stage._tilingTileset;
				if ((object)stage._tilingTileset != null)
				{
					Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__47_0;
					if (_003C_003Ec._003C_003E9__47_0 == null)
					{
						predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__47_0 = delegate(SuperObject o)
						{
							//IL_0144: Expected I4, but got O
							//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
							//IL_00e6: Expected Ref, but got Unknown
							//IL_00fd: Expected I8, but got I4
							//IL_010b: Unknown result type (might be due to invalid IL or missing references)
							//IL_0110: Expected Ref, but got Unknown
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3D5A]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if ((object)o != null)
							{
								string tiledName = o.m_TiledName;
								if (o.m_TiledName != null)
								{
									object obj5 = "FS_SEAL2";
									if ((object)o.m_TiledName != "FS_SEAL2")
									{
										if ("FS_SEAL2" != null)
										{
											int stringLength = tiledName._stringLength;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
											if ((nint)stringLength == 0)
											{
												ref byte second = ref *(byte*)("FS_SEAL2" + 20);
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
					object obj = Enumerable.FirstOrDefault(tilingTileset.SavedScripts, predicate);
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ rax_v20 (System.Object)+10]");
						if ((nint)0 != 0)
						{
							Transform transform = ((Component)obj).transform;
							if ((object)transform != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v59 (UnityEngine.Transform)+10]");
								bool flag = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v59 (UnityEngine.Transform)+10]");
								Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
								Transform transform2 = ((Component)obj).transform;
								if ((object)transform2 != null)
								{
									bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
									goto IL_037f;
								}
							}
							goto IL_02da;
						}
					}
					goto IL_037f;
				}
			}
		}
		goto IL_02da;
		IL_02da:
		throw new NullReferenceException();
		IL_037f:
		GameManager core2 = GM.Core;
		Destructible destructible;
		Destructible seal;
		object obj4;
		if ((object)GM.Core != null)
		{
			Stage stage2 = core2._stage;
			if ((object)core2._stage != null && (object)stage2._tilingTileset != null)
			{
				Vector2 defaultMapPosition = stage2._tilingTileset.DefaultMapPosition;
				Vector2 pos = default(Vector2);
				destructible = core2._stage.MakeDestructible(PropType.FOSCARI_SEAL_2, pos);
				bool flag3 = (object)destructible == null;
				seal = destructible;
				if (flag3)
				{
					goto IL_043b;
				}
				nint num = (nint)destructible;
				nint num2 = (nint)typeof(PropFoscariSeal2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v818 @ rdx_v24 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal2>)+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v818 @ rdx_v24 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal2>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v887 @ rax_v57+FFFFFFF8+v819 @ rax_v52*8]");
					if (0 == (nint)typeof(PropFoscariSeal2))
					{
						obj4 = 1;
						goto IL_044a;
					}
				}
				obj4 = 0;
				goto IL_044a;
			}
		}
		goto IL_02da;
		IL_043b:
		_seal = (PropFoscariSeal2)seal;
		PropFoscariSeal2 seal2 = _seal;
		if ((object)_seal != null && ((UnityEngine.Object)seal2).m_CachedPtr != (IntPtr)0)
		{
			Action action = OnSeal2DestructionComplete;
			if ((object)_seal != null)
			{
				return;
			}
			goto IL_02da;
		}
		return;
		IL_044a:
		bool flag4 = obj4 == null;
		seal = null;
		if (!flag4)
		{
			seal = destructible;
		}
		goto IL_043b;
	}

	public unsafe void CreateSeal3()
	{
		//IL_01aa: Expected I, but got O
		//IL_01b8: Expected I, but got O
		//IL_01c8: Expected O, but got I
		//IL_0248: Expected O, but got I4
		//IL_0204: Expected O, but got I
		//IL_023a: Expected O, but got I4
		//IL_0401->IL02da: Incompatible stack heights: 1 vs 0
		//IL_043b->IL037f: Incompatible stack heights: 2 vs 0
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				TilingTileset tilingTileset = stage._tilingTileset;
				if ((object)stage._tilingTileset != null)
				{
					Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__48_0;
					if (_003C_003Ec._003C_003E9__48_0 == null)
					{
						predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__48_0 = delegate(SuperObject o)
						{
							//IL_0144: Expected I4, but got O
							//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
							//IL_00e6: Expected Ref, but got Unknown
							//IL_00fd: Expected I8, but got I4
							//IL_010b: Unknown result type (might be due to invalid IL or missing references)
							//IL_0110: Expected Ref, but got Unknown
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3D5B]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if ((object)o != null)
							{
								string tiledName = o.m_TiledName;
								if (o.m_TiledName != null)
								{
									object obj5 = "FS_SEAL3";
									if ((object)o.m_TiledName != "FS_SEAL3")
									{
										if ("FS_SEAL3" != null)
										{
											int stringLength = tiledName._stringLength;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
											if ((nint)stringLength == 0)
											{
												ref byte second = ref *(byte*)("FS_SEAL3" + 20);
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
					object obj = Enumerable.FirstOrDefault(tilingTileset.SavedScripts, predicate);
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ rax_v20 (System.Object)+10]");
						if ((nint)0 != 0)
						{
							Transform transform = ((Component)obj).transform;
							if ((object)transform != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v59 (UnityEngine.Transform)+10]");
								bool flag = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v59 (UnityEngine.Transform)+10]");
								Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
								Transform transform2 = ((Component)obj).transform;
								if ((object)transform2 != null)
								{
									bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
									goto IL_037f;
								}
							}
							goto IL_02da;
						}
					}
					goto IL_037f;
				}
			}
		}
		goto IL_02da;
		IL_02da:
		throw new NullReferenceException();
		IL_037f:
		GameManager core2 = GM.Core;
		Destructible destructible;
		Destructible sealBlue;
		object obj4;
		if ((object)GM.Core != null)
		{
			Stage stage2 = core2._stage;
			if ((object)core2._stage != null && (object)stage2._tilingTileset != null)
			{
				Vector2 defaultMapPosition = stage2._tilingTileset.DefaultMapPosition;
				Vector2 pos = default(Vector2);
				destructible = core2._stage.MakeDestructible(PropType.FOSCARI_SEAL_3, pos);
				bool flag3 = (object)destructible == null;
				sealBlue = destructible;
				if (flag3)
				{
					goto IL_043b;
				}
				nint num = (nint)destructible;
				nint num2 = (nint)typeof(PropFoscariSeal3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v818 @ rdx_v24 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal3>)+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v818 @ rdx_v24 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal3>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v887 @ rax_v57+FFFFFFF8+v819 @ rax_v52*8]");
					if (0 == (nint)typeof(PropFoscariSeal3))
					{
						obj4 = 1;
						goto IL_044a;
					}
				}
				obj4 = 0;
				goto IL_044a;
			}
		}
		goto IL_02da;
		IL_043b:
		_sealBlue = (PropFoscariSeal3)sealBlue;
		PropFoscariSeal3 sealBlue2 = _sealBlue;
		if ((object)_sealBlue != null && ((UnityEngine.Object)sealBlue2).m_CachedPtr != (IntPtr)0)
		{
			Action action = FreeJeneviv;
			if ((object)_sealBlue != null)
			{
				return;
			}
			goto IL_02da;
		}
		return;
		IL_044a:
		bool flag4 = obj4 == null;
		sealBlue = null;
		if (!flag4)
		{
			sealBlue = destructible;
		}
		goto IL_043b;
	}

	public unsafe void CreateBadge()
	{
		//IL_02b2->IL018b: Incompatible stack heights: 1 vs 0
		//IL_02ec->IL0230: Incompatible stack heights: 2 vs 0
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				TilingTileset tilingTileset = stage._tilingTileset;
				if ((object)stage._tilingTileset != null)
				{
					Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__49_0;
					if (_003C_003Ec._003C_003E9__49_0 == null)
					{
						predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__49_0 = delegate(SuperObject o)
						{
							//IL_0144: Expected I4, but got O
							//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
							//IL_00e6: Expected Ref, but got Unknown
							//IL_00fd: Expected I8, but got I4
							//IL_010b: Unknown result type (might be due to invalid IL or missing references)
							//IL_0110: Expected Ref, but got Unknown
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3D5C]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if ((object)o != null)
							{
								string tiledName = o.m_TiledName;
								if (o.m_TiledName != null)
								{
									object obj2 = "FS_SEAL2";
									if ((object)o.m_TiledName != "FS_SEAL2")
									{
										if ("FS_SEAL2" != null)
										{
											int stringLength = tiledName._stringLength;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
											if ((nint)stringLength == 0)
											{
												ref byte second = ref *(byte*)("FS_SEAL2" + 20);
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
					object obj = Enumerable.FirstOrDefault(tilingTileset.SavedScripts, predicate);
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rax_v20 (System.Object)+10]");
						if ((nint)0 != 0)
						{
							Transform transform = ((Component)obj).transform;
							if ((object)transform != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v32 (UnityEngine.Transform)+10]");
								bool flag = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v32 (UnityEngine.Transform)+10]");
								Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
								Transform transform2 = ((Component)obj).transform;
								if ((object)transform2 != null)
								{
									bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
									goto IL_0230;
								}
							}
							goto IL_018b;
						}
					}
					goto IL_0230;
				}
			}
		}
		goto IL_018b;
		IL_0230:
		GameManager core2 = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage2 = core2._stage;
			if ((object)core2._stage != null && (object)stage2._tilingTileset != null)
			{
				Vector2 defaultMapPosition = stage2._tilingTileset.DefaultMapPosition;
				Vector2 pos = default(Vector2);
				float value = default(float);
				ItemType relicType = default(ItemType);
				bool validatePickups = default(bool);
				Pickup pickup = GM.Core.MakeStagePickup(pos, ItemType.WEAPON, WeaponType.ACADEMYBADGE, value, relicType, validatePickups);
				return;
			}
		}
		goto IL_018b;
		IL_018b:
		throw new NullReferenceException();
	}

	private unsafe void CreateShadowServant()
	{
		//IL_02b2->IL018b: Incompatible stack heights: 1 vs 0
		//IL_02ec->IL0230: Incompatible stack heights: 2 vs 0
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				TilingTileset tilingTileset = stage._tilingTileset;
				if ((object)stage._tilingTileset != null)
				{
					Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__50_0;
					if (_003C_003Ec._003C_003E9__50_0 == null)
					{
						predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__50_0 = delegate(SuperObject o)
						{
							//IL_0144: Expected I4, but got O
							//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
							//IL_00e6: Expected Ref, but got Unknown
							//IL_00fd: Expected I8, but got I4
							//IL_010b: Unknown result type (might be due to invalid IL or missing references)
							//IL_0110: Expected Ref, but got Unknown
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3D5D]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if ((object)o != null)
							{
								string tiledName = o.m_TiledName;
								if (o.m_TiledName != null)
								{
									object obj2 = "FS_SEAL3";
									if ((object)o.m_TiledName != "FS_SEAL3")
									{
										if ("FS_SEAL3" != null)
										{
											int stringLength = tiledName._stringLength;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
											if ((nint)stringLength == 0)
											{
												ref byte second = ref *(byte*)("FS_SEAL3" + 20);
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
					object obj = Enumerable.FirstOrDefault(tilingTileset.SavedScripts, predicate);
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rax_v20 (System.Object)+10]");
						if ((nint)0 != 0)
						{
							Transform transform = ((Component)obj).transform;
							if ((object)transform != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v32 (UnityEngine.Transform)+10]");
								bool flag = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v32 (UnityEngine.Transform)+10]");
								Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
								Transform transform2 = ((Component)obj).transform;
								if ((object)transform2 != null)
								{
									bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
									goto IL_0230;
								}
							}
							goto IL_018b;
						}
					}
					goto IL_0230;
				}
			}
		}
		goto IL_018b;
		IL_0230:
		GameManager core2 = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage2 = core2._stage;
			if ((object)core2._stage != null && (object)stage2._tilingTileset != null)
			{
				Vector2 defaultMapPosition = stage2._tilingTileset.DefaultMapPosition;
				Vector2 pos = default(Vector2);
				float value = default(float);
				ItemType relicType = default(ItemType);
				bool validatePickups = default(bool);
				Pickup pickup = GM.Core.MakeStagePickup(pos, ItemType.WEAPON, WeaponType.SHADOWSERVANT, value, relicType, validatePickups);
				return;
			}
		}
		goto IL_018b;
		IL_018b:
		throw new NullReferenceException();
	}

	private void CreateWeapons()
	{
		//IL_0076: Expected I, but got O
		//IL_007e: Expected I, but got O
		//IL_008e: Expected O, but got I
		//IL_010e: Expected O, but got I4
		//IL_00ca: Expected O, but got I
		//IL_0100: Expected O, but got I4
		//IL_015f: Expected I, but got O
		//IL_0167: Expected I, but got O
		//IL_0177: Expected O, but got I
		//IL_01f7: Expected O, but got I4
		//IL_01b3: Expected O, but got I
		//IL_01e9: Expected O, but got I4
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		Vector2 pos = default(Vector2);
		float value = default(float);
		ItemType relicType = default(ItemType);
		bool validatePickups = default(bool);
		Pickup pickup = GM.Core.MakeStagePickup(pos, ItemType.WEAPON, WeaponType.WHIP, value, relicType, validatePickups);
		nint num = (nint)typeof(PickupWeapon);
		nint num2 = (nint)pickup;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rcx_v22+FFFFFFF8+v472 @ rcx_v12*8]");
			if (0 == (nint)typeof(PickupWeapon))
			{
				obj3 = 1;
				goto IL_020e;
			}
		}
		obj3 = 0;
		goto IL_020e;
		IL_022b:
		object obj4 = default(object);
		bool flag = obj4 == null;
		Pickup pickup2 = null;
		if (!flag)
		{
			/*Error: End of method reached without returning.*/;
		}
		_ = 0;
		_ = 1;
		return;
		IL_020e:
		bool flag2 = obj3 == null;
		Pickup pickup3 = null;
		if (flag2)
		{
			_ = 0;
			_ = 1;
			Pickup pickup4 = GM.Core.MakeStagePickup(pos, ItemType.WEAPON, WeaponType.MAGIC_MISSILE, value, relicType, validatePickups);
			nint num4 = (nint)typeof(PickupWeapon);
			nint num5 = (nint)pickup4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
			if (num6 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ rcx_v19+FFFFFFF8+v540 @ rcx_v16*8]");
				if (0 == (nint)typeof(PickupWeapon))
				{
					obj4 = 1;
					goto IL_022b;
				}
			}
			obj4 = 0;
		}
		goto IL_022b;
	}

	public void OnSeal2DestructionComplete()
	{
		//IL_00f6: Expected I, but got O
		//IL_0169: Expected O, but got I4
		_003C_003Ec__DisplayClass52_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass52_0();
		CS_0024_003C_003E8__locals9._003C_003E4__this = this;
		ForceSpoopyMusic();
		_isPathBlocked = false;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		float tweenXDirection;
		if (config._003CSelectedInverse_003Ek__BackingField)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config2 = core2._playerOptions.Config;
			if (config2._003CVisuallyInvertStages_003Ek__BackingField)
			{
				tweenXDirection = 1f;
				goto IL_01b5;
			}
		}
		tweenXDirection = -1f;
		goto IL_01b5;
		IL_01b5:
		CS_0024_003C_003E8__locals9.tweenXDirection = tweenXDirection;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_sBlackWall != null)
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
		float2 position = _sBlackWall.position;
		tweenConfig.duration = 5000f;
		tweenConfig.x = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			//IL_006b: Expected I, but got O
			//IL_00f0: Expected O, but got I4
			//IL_00fe: Expected O, but got I4
			CS_0024_003C_003E8__locals9._003C_003E4__this.OpenBounds();
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			BackgroundFoscari2 backgroundFoscari = CS_0024_003C_003E8__locals9._003C_003E4__this;
			if ((object)backgroundFoscari._sBlackWall != null)
			{
				nint num2 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			BackgroundFoscari2 backgroundFoscari2 = CS_0024_003C_003E8__locals9._003C_003E4__this;
			float2 position2 = backgroundFoscari2._sBlackWall.position;
			tweenConfig2.duration = 5000f;
			tweenConfig2.x = (float?)(object)1;
			tweenConfig2.alpha = (float?)(object)1;
			TweenCallback onComplete2 = CS_0024_003C_003E8__locals9._003C_003E9__1;
			if (CS_0024_003C_003E8__locals9._003C_003E9__1 == null)
			{
				onComplete2 = (CS_0024_003C_003E8__locals9._003C_003E9__1 = delegate
				{
					BackgroundFoscari2 backgroundFoscari3 = CS_0024_003C_003E8__locals9._003C_003E4__this;
					PhaserSprite phaserSprite = backgroundFoscari3._sBlackWall.setVisible(visible: false);
				});
			}
			tweenConfig2.onComplete = onComplete2;
			MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	public void SetBoundsBeforeSeal2()
	{
		//IL_00f1: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CSelectedInverse_003Ek__BackingField)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config2 = core2._playerOptions.Config;
			if (config2._003CVisuallyInvertStages_003Ek__BackingField)
			{
				GameManager core3 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
				core3._003CHardBounds_003Ek__BackingField = (Rect?)(object)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A125B0]");
				_ = 0;
				_sBlackWall.X = 51.199997f;
				return;
			}
		}
		float yMax = default(float);
		bool skipInverseCalculation = default(bool);
		GM.Core.SetHardBoundsMinMax(5120f, 256f, 9984f, yMax, skipInverseCalculation);
	}

	public void OpenBounds()
	{
		float yMax = default(float);
		bool skipInverseCalculation = default(bool);
		GM.Core.SetHardBoundsMinMax(256f, 256f, 9984f, yMax, skipInverseCalculation);
	}

	private unsafe void SpawnJeneviv()
	{
		//IL_015f: Expected O, but got I
		//IL_02a9->IL0182: Incompatible stack heights: 1 vs 0
		//IL_02e3->IL0227: Incompatible stack heights: 2 vs 0
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				TilingTileset tilingTileset = stage._tilingTileset;
				if ((object)stage._tilingTileset != null)
				{
					Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__55_0;
					if (_003C_003Ec._003C_003E9__55_0 == null)
					{
						predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__55_0 = delegate(SuperObject o)
						{
							//IL_0144: Expected I4, but got O
							//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
							//IL_00e6: Expected Ref, but got Unknown
							//IL_00fd: Expected I8, but got I4
							//IL_010b: Unknown result type (might be due to invalid IL or missing references)
							//IL_0110: Expected Ref, but got Unknown
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3D5E]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if ((object)o != null)
							{
								string tiledName = o.m_TiledName;
								if (o.m_TiledName != null)
								{
									object obj2 = "FS_JENEVIV";
									if ((object)o.m_TiledName != "FS_JENEVIV")
									{
										if ("FS_JENEVIV" != null)
										{
											int stringLength = tiledName._stringLength;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
											if ((nint)stringLength == 0)
											{
												ref byte second = ref *(byte*)("FS_JENEVIV" + 20);
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
					object obj = Enumerable.FirstOrDefault(tilingTileset.SavedScripts, predicate);
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rax_v20 (System.Object)+10]");
						if ((nint)0 != 0)
						{
							Transform transform = ((Component)obj).transform;
							if ((object)transform != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rax_v36 (UnityEngine.Transform)+10]");
								bool flag = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rax_v36 (UnityEngine.Transform)+10]");
								Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
								Transform transform2 = ((Component)obj).transform;
								if ((object)transform2 != null)
								{
									bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
									goto IL_0227;
								}
							}
							goto IL_0182;
						}
					}
					goto IL_0227;
				}
			}
		}
		goto IL_0182;
		IL_0227:
		GameManager core2 = GM.Core;
		if ((object)GM.Core != null)
		{
			object stage2 = core2._stage;
			if ((object)core2._stage != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rbx_v8 (System.Object)+208]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rbx_v8 (System.Object)+208]");
					Vector2 defaultMapPosition = ((TilingTileset)0).DefaultMapPosition;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
					EnemyJeneviv jeneviv = default(EnemyJeneviv);
					_jeneviv = jeneviv;
					return;
				}
			}
		}
		goto IL_0182;
		IL_0182:
		throw new NullReferenceException();
	}

	private void SealJeneviv()
	{
		EnemyJeneviv jeneviv = _jeneviv;
		if ((object)_jeneviv != null && ((UnityEngine.Object)jeneviv).m_CachedPtr != (IntPtr)0)
		{
			_jeneviv.SealInStone();
		}
	}

	public void FreeJeneviv()
	{
		//IL_01fa: Expected I4, but got F4
		//IL_0253: Expected I4, but got F4
		//IL_02b1: Expected I4, but got F4
		//IL_02fe: Expected I4, but got F4
		//IL_0357: Expected I4, but got F4
		//IL_03b5: Expected I4, but got F4
		//IL_040e: Expected I4, but got F4
		//IL_046c: Expected I4, but got F4
		//IL_04c5: Expected I4, but got F4
		//IL_0523: Expected I4, but got F4
		//IL_057c: Expected I4, but got F4
		StopBeat();
		ResumeEnemiesMovement();
		ProCamera2D instance = ProCamera2D.Instance;
		instance.RemoveAllCameraTargets(0.5f);
		ProCamera2D instance2 = ProCamera2D.Instance;
		Transform targetTransform = _jeneviv.transform;
		float num = default(float);
		Vector2 vector = default(Vector2);
		Com.LuisPedroFonseca.ProCamera2D.CameraTarget cameraTarget = instance2.AddCameraTarget(targetTransform, 1f, 1f, num, vector);
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rcx_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				goto IL_00f3;
			}
		}
		SoundManager.StopMusic(BgmType.BGM_Foscari2);
		goto IL_00f3;
		IL_00f3:
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		config2._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_Genevieve;
		GameManager core3 = GM.Core;
		PlayerOptionsData config3 = core3._playerOptions.Config;
		config3._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
		GM.Core.SetupMusicBanger();
		GameManager core4 = GM.Core;
		core4._003CCanInterrupt_003Ek__BackingField = false;
		GameManager core5 = GM.Core;
		core5._003CCanPause_003Ek__BackingField = false;
		Action onComplete = delegate
		{
			DevourEggs();
			SummonSnakes();
		};
		float duration = Delay01_Wave * 0.001f;
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete2 = delegate
		{
			SummonSnakes();
		};
		float duration2 = Delay02_Wave * 0.001f;
		Timer timer2 = Timers.Register(duration2, onComplete2, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete3 = delegate
		{
			SummonSnakes();
		};
		float duration3 = Delay03_Wave * 0.001f;
		Timer timer3 = Timers.Register(duration3, onComplete3, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete4 = _003C_003Ec._003C_003E9__68_3;
		if (_003C_003Ec._003C_003E9__68_3 == null)
		{
			onComplete4 = (_003C_003Ec._003C_003E9__68_3 = delegate
			{
			});
		}
		float duration4 = Delay04_Wave * 0.001f;
		Timer timer4 = Timers.Register(duration4, onComplete4, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete5 = delegate
		{
			//IL_00a4: Expected O, but got I4
			EnemyJeneviv jeneviv = _jeneviv;
			float2 position = _jeneviv.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			PhaserSprite phaserSprite = jeneviv._breakFreeSprite.setVisible(visible: true);
			PhaserSprite breakFreeSprite = jeneviv._breakFreeSprite;
			breakFreeSprite._spriteAnimation.SetAnimation("BreakAnim");
			GameManager core6 = GM.Core;
			GameSessionData gameSessionData = core6._gameSessionData;
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
			object obj2 = activeCharacter._level * 300;
			((EnemyController)jeneviv)._hp = (((EnemyController)jeneviv)._maxHp = (float)obj2 + 1000f);
		};
		float duration5 = Delay05_Break * 0.001f;
		Timer timer5 = Timers.Register(duration5, onComplete5, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete6 = delegate
		{
			EnemyJeneviv jeneviv = _jeneviv;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6283]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			float2 position = _jeneviv.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			PhaserSprite phaserSprite = jeneviv._breakFreeSprite.setVisible(visible: true);
			PhaserSprite breakFreeSprite = jeneviv._breakFreeSprite;
			breakFreeSprite._spriteAnimation.SetAnimation("BreakAnim");
			float num2 = ((EnemyController)jeneviv)._defaultSpeed * 0.1f;
			((EnemyController)jeneviv)._003CIsTeleportOnCull_003Ek__BackingField = true;
			jeneviv._painInTheAss = true;
			((EnemyController)jeneviv)._003CSpeed_003Ek__BackingField = num2;
			((EnemyController)jeneviv)._SpriteAnimation.SetAnimation("NoColor");
		};
		float duration6 = Delay06_Move * 0.001f;
		Timer timer6 = Timers.Register(duration6, onComplete6, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete7 = delegate
		{
			EnemyJeneviv jeneviv = _jeneviv;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6284]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			float2 position = _jeneviv.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			PhaserSprite phaserSprite = jeneviv._breakFreeSprite.setVisible(visible: true);
			PhaserSprite breakFreeSprite = jeneviv._breakFreeSprite;
			breakFreeSprite._spriteAnimation.SetAnimation("BreakAnim");
			((EnemyController)jeneviv)._SpriteAnimation.SetAnimation("NoEle");
			((EnemyController)jeneviv)._003CSpeed_003Ek__BackingField = ((EnemyController)jeneviv)._defaultSpeed;
		};
		float duration7 = Delay07_Color * 0.001f;
		Timer timer7 = Timers.Register(duration7, onComplete7, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete8 = delegate
		{
			_jeneviv.ChargeWorldEater();
		};
		float duration8 = Delay08_Charge * 0.001f;
		Timer timer8 = Timers.Register(duration8, onComplete8, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete9 = delegate
		{
			_jeneviv.CastWorldEater();
			OnWorldEater();
		};
		float duration9 = Delay09_WorldEater * 0.001f;
		Timer timer9 = Timers.Register(duration9, onComplete9, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete10 = delegate
		{
			_jeneviv.StartVerySmartAI();
		};
		float duration10 = Delay10_Start * 0.001f;
		Timer timer10 = Timers.Register(duration10, onComplete10, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete11 = delegate
		{
			GameManager core6 = GM.Core;
			core6._003CCanInterrupt_003Ek__BackingField = true;
			GameManager core7 = GM.Core;
			core7._003CCanPause_003Ek__BackingField = true;
			if (_luminairePathEvent != null)
			{
				_luminairePathEvent.Cancel();
			}
			Action onComplete12 = delegate
			{
				//IL_04ee: Expected I, but got O
				//IL_04fc: Expected I, but got O
				//IL_050c: Expected O, but got I
				//IL_058c: Expected O, but got I4
				//IL_0548: Expected O, but got I
				//IL_05f6: Expected F4, but got O
				//IL_057e: Expected O, but got I4
				//IL_039e: Expected F4, but got O
				GameManager core8 = GM.Core;
				Predicate<VampireSurvivors.Objects.Characters.CharacterController> match = _003C_003Ec._003C_003E9__71_1;
				if (_003C_003Ec._003C_003E9__71_1 == null)
				{
					match = (_003C_003Ec._003C_003E9__71_1 = delegate(VampireSurvivors.Objects.Characters.CharacterController x)
					{
						//IL_0052: Expected I4, but got O
						//IL_0030: Expected O, but got I4
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						object obj7 = x._characterType - 75;
						return obj7 == null;
					});
				}
				VampireSurvivors.Objects.Characters.CharacterController characterController = core8._characters.Find(match);
				if ((object)characterController == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				Equipment equipmentByType = characterController._weaponsManager.GetEquipmentByType(WeaponType.PRISMATICMISS);
				bool flag = (object)equipmentByType == null;
				int num2 = 0;
				if (!flag)
				{
					bool flag2 = ((UnityEngine.Object)equipmentByType).m_CachedPtr == (IntPtr)0;
					num2 = 0;
					if (!flag2)
					{
						num2 = equipmentByType._003CLevel_003Ek__BackingField;
					}
				}
				Vector2 pos = default(Vector2);
				GameManager core11;
				float y2;
				object obj2 = default(object);
				float2 float5;
				WeaponType weaponType;
				if ((object)equipmentByType != null && ((UnityEngine.Object)equipmentByType).m_CachedPtr != (IntPtr)0 && num2 >= 8)
				{
					Equipment equipmentByType2 = characterController._accessoriesManager.GetEquipmentByType(WeaponType.GROWTH);
					bool flag3 = equipmentByType2;
					bool flag4 = !flag3;
					int num3 = 0;
					if (!flag4)
					{
						num3 = equipmentByType2._003CLevel_003Ek__BackingField;
					}
					if ((bool)equipmentByType2 && num3 >= 5)
					{
						List<float> list2 = new List<float>();
						list2.Add(0.1f);
						list2.Add(5f);
						list2.Add(100f);
						List<PrizeType?> list3 = new List<PrizeType?>();
						((List<float>)(object)list3).Add(100f);
						((List<float>)(object)list3).Add(100f);
						((List<float>)(object)list3).Add(100f);
						((List<float>)(object)list3).Add(100f);
						((List<float>)(object)list3).Add(100f);
						Treasure treasure = new Treasure();
						treasure._003Clevel_003Ek__BackingField = 1;
						treasure.chances = list2;
						treasure.prizeTypes = list3;
						List<WeaponType> fixedPrizes = new List<WeaponType>();
						treasure.fixedPrizes = fixedPrizes;
						treasure._003ChasArcana_003Ek__BackingField = false;
						GameManager core9 = GM.Core;
						int num4 = core9._stage.SetTreasureLevelFromChance(treasure);
						float2 position = characterController.position;
						float2 position2 = characterController.position;
						PhaserScene phaserScene = GM.Core.scene;
						PhaserScene.Renderer renderer = phaserScene._renderer;
						float num5 = renderer.height * 0.25f;
						float y = 6f - num5;
						TreasureChest treasureChest = GM.Core.MakeTreasure(pos, treasure);
						GameManager core10 = GM.Core;
						core10._gizmoManager.ShowHighlightAt((float)position, y);
						_checkForLuminaire = true;
						return;
					}
					float2 position3 = characterController.position;
					float2 position4 = characterController.position;
					if ((object)GM.Core == null)
					{
						goto IL_0610;
					}
					PhaserScene s_scene = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer2 = s_scene._renderer;
					float num6 = renderer2.height * 0.25f;
					core11 = GM.Core;
					y2 = (float)obj2 - num6;
					float5 = position3;
					weaponType = WeaponType.GROWTH;
				}
				else
				{
					float2 position5 = characterController.position;
					float2 position6 = characterController.position;
					if ((object)GM.Core == null)
					{
						goto IL_0610;
					}
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer3 = s_scene2._renderer;
					float num7 = renderer3.height * 0.25f;
					core11 = GM.Core;
					y2 = (float)obj2 - num7;
					float5 = position5;
					weaponType = WeaponType.PRISMATICMISS;
				}
				float value = default(float);
				ItemType relicType = default(ItemType);
				bool validatePickups = default(bool);
				Pickup pickup = core11.MakeStagePickup(pos, ItemType.WEAPON, weaponType, value, relicType, validatePickups);
				bool flag5 = (object)pickup == null;
				UnityEngine.Object obj3 = null;
				ItemType itemType = ItemType.WEAPON;
				if (flag5)
				{
					goto IL_05a6;
				}
				nint num8 = (nint)pickup;
				nint num9 = (nint)typeof(PickupWeapon);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1236 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1235 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1236 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
				object obj6;
				if (num10 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1235 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1313 @ rax_v40+FFFFFFF8+v1237 @ rax_v36*8]");
					if (0 == (nint)typeof(PickupWeapon))
					{
						obj6 = 1;
						goto IL_0766;
					}
				}
				obj6 = 0;
				goto IL_0766;
				IL_05a6:
				if ((bool)obj3)
				{
					_ = 0;
					GameManager core12 = GM.Core;
					core12._gizmoManager.ShowHighlightAt((float)float5, y2);
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BC71C0");
				}
				return;
				IL_0610:
				throw new NullReferenceException();
				IL_0766:
				bool flag6 = obj6 == null;
				obj3 = null;
				itemType = (ItemType)num8;
				if (!flag6)
				{
					obj3 = pickup;
					itemType = (ItemType)num8;
				}
				goto IL_05a6;
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat2 = default(int);
			TimerType type2 = default(TimerType);
			Timer luminairePathEvent = Timers.Register(10f, onComplete12, null, isLooped: true, useRealTime, autoDestroyOwner, repeat2, type2, isOnlineTimer: false, canPause: false);
			_luminairePathEvent = luminairePathEvent;
		};
		float duration11 = Delay11_Light * 0.001f;
		Timer timer11 = Timers.Register(duration11, onComplete11, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private unsafe void SummonSnakes()
	{
		//IL_0029: Expected O, but got Ref
		//IL_005b: Expected O, but got Ref
		//IL_00d1: Expected O, but got Ref
		//IL_0103: Expected O, but got Ref
		GameManager core = GM.Core;
		Stage stage = core._stage;
		VampireSurvivors.Data.Stage.Event obj = new VampireSurvivors.Data.Stage.Event();
		IntPtr intPtr = default(IntPtr);
		string text = ((Enum)(&intPtr)).ToString();
		obj._003CeventType_003Ek__BackingField = text;
		obj._003CmoreX_003Ek__BackingField = 50;
		string text2 = ((Enum)(&intPtr)).ToString();
		obj._003CmoreY_003Ek__BackingField = text2;
		obj._003CmoreZ_003Ek__BackingField = 1.4f;
		bool flag = stage._stageEventManager.TriggerEvent(obj);
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		VampireSurvivors.Data.Stage.Event obj2 = new VampireSurvivors.Data.Stage.Event();
		IntPtr intPtr2 = default(IntPtr);
		string text3 = ((Enum)(&intPtr2)).ToString();
		obj2._003CeventType_003Ek__BackingField = text3;
		obj2._003CmoreX_003Ek__BackingField = 50;
		string text4 = ((Enum)(&intPtr2)).ToString();
		obj2._003CmoreY_003Ek__BackingField = text4;
		obj2._003CmoreZ_003Ek__BackingField = 1.5f;
		bool flag2 = stage2._stageEventManager.TriggerEvent(obj2);
		_jeneviv.ScreenShake();
	}

	public unsafe void DevourEggs()
	{
		//IL_0067: Invalid comparison between F4 and I4
		//IL_0087: Invalid comparison between F4 and I4
		//IL_00a7: Expected F4, but got I4
		//IL_00b0: Expected F4, but got I4
		//IL_0485: Invalid comparison between F4 and I4
		//IL_0345: Expected O, but got F4
		//IL_0372: Expected O, but got F4
		//IL_0386: Expected O, but got F4
		//IL_0394: Expected O, but got I4
		//IL_026f: Expected O, but got I4
		//IL_03c9: Expected O, but got F4
		//IL_03f7: Expected O, but got I4
		//IL_04a5: Expected O, but got F4
		//IL_0409: Expected I, but got O
		//IL_041f: Expected O, but got I
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_042d: Expected O, but got Unknown
		//IL_02c0: Expected I, but got O
		//IL_0453: Expected O, but got I4
		//IL_046a: Expected I, but got I8
		//IL_02a9: Expected I, but got I8
		//IL_01df->IL01df: Incompatible stack heights: 1 vs 0
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CSelectedGoldenEggs_003Ek__BackingField)
		{
			return;
		}
		GameManager core2 = GM.Core;
		float num = core2._eggManager.RemoveBonuses();
		if (!(num > 0f) || !(num > 0f))
		{
			return;
		}
		float num2 = 0f;
		float num3 = 0f;
		Vector2 pos = default(Vector2);
		while (true)
		{
			if (!(num2 < 2000f))
			{
				return;
			}
			_003C_003Ec__DisplayClass70_0 obj = new _003C_003Ec__DisplayClass70_0();
			PhaserWorld instance = PhaserWorld.Instance;
			if ((object)GM.Core == null)
			{
				break;
			}
			object obj2 = UnityEngine.Random.value;
			if ((object)GM.Core == null)
			{
				break;
			}
			object obj3 = UnityEngine.Random.value;
			PhaserSprite component = instance.AddPhaserSprite(pos, "items", "goldenegg");
			PhaserSprite phaserSprite = RenderingExtensions.SetScrollFactor(component, 0f);
			PhaserSprite s = phaserSprite.setDepth(9000);
			obj.s = s;
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)obj.s != null)
			{
				PhaserSprite phaserSprite2 = RenderingExtensions.SetScrollFactor(obj.s, 0f);
				bool flag = (object)phaserSprite2 == null;
			}
			array[0] = obj.s;
			tweenConfig.targets = array;
			if ((object)GM.Core == null)
			{
				break;
			}
			object obj4 = UnityEngine.Random.value;
			tweenConfig.x = (float?)(object)1;
			if ((object)GM.Core == null)
			{
				break;
			}
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			float num4 = renderer.height + 0.32f;
			tweenConfig.y = (float?)(object)1;
			object obj5 = UnityEngine.Random.value;
			float num5 = num4 * 180f;
			float num6 = num5 + 180f;
			tweenConfig.angle = (float?)(object)1;
			object obj6 = UnityEngine.Random.value;
			float num7 = num6 * 300f;
			tweenConfig.ease = Ease.InCirc;
			float duration = num7 + 300f;
			tweenConfig.duration = duration;
			tweenConfig.delay = num2;
			TweenCallback tweenCallback = null;
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ r10_v11 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass70_0._003CDevourEggs_003Eb__0);
			((Delegate)tweenCallback).m_target = obj;
			((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ r10_v11 (Il2CppMethodInfo)+4C]");
			object obj7 = (nint)0 >> 4;
			object obj8 = obj7 & 1;
			nint num9;
			if (obj8 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ r10_v11 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num9 = unchecked((nint)6447293664L);
					goto IL_044a;
				}
			}
			((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
			num9 = ((Delegate)tweenCallback).method_ptr;
			goto IL_044a;
			IL_044a:
			object obj9 = 24;
			((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
			tweenConfig.onComplete = tweenCallback;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			num3++;
			num2 += 10f;
			if (!(num > num3))
			{
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void StartSpawningPrismaticMissile()
	{
		if (_luminairePathEvent != null)
		{
			_luminairePathEvent.Cancel();
		}
		Action onComplete = delegate
		{
			//IL_04ee: Expected I, but got O
			//IL_04fc: Expected I, but got O
			//IL_050c: Expected O, but got I
			//IL_058c: Expected O, but got I4
			//IL_0548: Expected O, but got I
			//IL_05f6: Expected F4, but got O
			//IL_057e: Expected O, but got I4
			//IL_039e: Expected F4, but got O
			GameManager core = GM.Core;
			Predicate<VampireSurvivors.Objects.Characters.CharacterController> match = _003C_003Ec._003C_003E9__71_1;
			if (_003C_003Ec._003C_003E9__71_1 == null)
			{
				match = (_003C_003Ec._003C_003E9__71_1 = delegate(VampireSurvivors.Objects.Characters.CharacterController x)
				{
					//IL_0052: Expected I4, but got O
					//IL_0030: Expected O, but got I4
					if ((object)x == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					object obj6 = x._characterType - 75;
					return obj6 == null;
				});
			}
			VampireSurvivors.Objects.Characters.CharacterController characterController = core._characters.Find(match);
			if ((object)characterController == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			Equipment equipmentByType = characterController._weaponsManager.GetEquipmentByType(WeaponType.PRISMATICMISS);
			bool flag = (object)equipmentByType == null;
			int num = 0;
			if (!flag)
			{
				bool flag2 = ((UnityEngine.Object)equipmentByType).m_CachedPtr == (IntPtr)0;
				num = 0;
				if (!flag2)
				{
					num = equipmentByType._003CLevel_003Ek__BackingField;
				}
			}
			Vector2 pos = default(Vector2);
			GameManager core4;
			float y2;
			object obj = default(object);
			float2 float5;
			WeaponType weaponType;
			if ((object)equipmentByType != null && ((UnityEngine.Object)equipmentByType).m_CachedPtr != (IntPtr)0 && num >= 8)
			{
				Equipment equipmentByType2 = characterController._accessoriesManager.GetEquipmentByType(WeaponType.GROWTH);
				bool flag3 = equipmentByType2;
				bool flag4 = !flag3;
				int num2 = 0;
				if (!flag4)
				{
					num2 = equipmentByType2._003CLevel_003Ek__BackingField;
				}
				if ((bool)equipmentByType2 && num2 >= 5)
				{
					List<float> list = new List<float>();
					list.Add(0.1f);
					list.Add(5f);
					list.Add(100f);
					List<PrizeType?> list2 = new List<PrizeType?>();
					((List<float>)(object)list2).Add(100f);
					((List<float>)(object)list2).Add(100f);
					((List<float>)(object)list2).Add(100f);
					((List<float>)(object)list2).Add(100f);
					((List<float>)(object)list2).Add(100f);
					Treasure treasure = new Treasure();
					treasure._003Clevel_003Ek__BackingField = 1;
					treasure.chances = list;
					treasure.prizeTypes = list2;
					List<WeaponType> fixedPrizes = new List<WeaponType>();
					treasure.fixedPrizes = fixedPrizes;
					treasure._003ChasArcana_003Ek__BackingField = false;
					GameManager core2 = GM.Core;
					int num3 = core2._stage.SetTreasureLevelFromChance(treasure);
					float2 position = characterController.position;
					float2 position2 = characterController.position;
					PhaserScene phaserScene = GM.Core.scene;
					PhaserScene.Renderer renderer = phaserScene._renderer;
					float num4 = renderer.height * 0.25f;
					float y = 6f - num4;
					TreasureChest treasureChest = GM.Core.MakeTreasure(pos, treasure);
					GameManager core3 = GM.Core;
					core3._gizmoManager.ShowHighlightAt((float)position, y);
					_checkForLuminaire = true;
					return;
				}
				float2 position3 = characterController.position;
				float2 position4 = characterController.position;
				if ((object)GM.Core == null)
				{
					goto IL_0610;
				}
				PhaserScene s_scene = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer2 = s_scene._renderer;
				float num5 = renderer2.height * 0.25f;
				core4 = GM.Core;
				y2 = (float)obj - num5;
				float5 = position3;
				weaponType = WeaponType.GROWTH;
			}
			else
			{
				float2 position5 = characterController.position;
				float2 position6 = characterController.position;
				if ((object)GM.Core == null)
				{
					goto IL_0610;
				}
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer3 = s_scene2._renderer;
				float num6 = renderer3.height * 0.25f;
				core4 = GM.Core;
				y2 = (float)obj - num6;
				float5 = position5;
				weaponType = WeaponType.PRISMATICMISS;
			}
			float value = default(float);
			ItemType relicType = default(ItemType);
			bool validatePickups = default(bool);
			Pickup pickup = core4.MakeStagePickup(pos, ItemType.WEAPON, weaponType, value, relicType, validatePickups);
			bool flag5 = (object)pickup == null;
			UnityEngine.Object obj2 = null;
			ItemType itemType = ItemType.WEAPON;
			if (flag5)
			{
				goto IL_05a6;
			}
			nint num7 = (nint)pickup;
			nint num8 = (nint)typeof(PickupWeapon);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1236 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1235 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1236 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
			object obj5;
			if (num9 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1235 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1313 @ rax_v40+FFFFFFF8+v1237 @ rax_v36*8]");
				if (0 == (nint)typeof(PickupWeapon))
				{
					obj5 = 1;
					goto IL_0766;
				}
			}
			obj5 = 0;
			goto IL_0766;
			IL_05a6:
			if ((bool)obj2)
			{
				_ = 0;
				GameManager core5 = GM.Core;
				core5._gizmoManager.ShowHighlightAt((float)float5, y2);
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BC71C0");
			}
			return;
			IL_0610:
			throw new NullReferenceException();
			IL_0766:
			bool flag6 = obj5 == null;
			obj2 = null;
			itemType = (ItemType)num7;
			if (!flag6)
			{
				obj2 = pickup;
				itemType = (ItemType)num7;
			}
			goto IL_05a6;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer luminairePathEvent = Timers.Register(10f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_luminairePathEvent = luminairePathEvent;
	}

	private void OnWorldEater()
	{
		//IL_00a7: Expected I, but got O
		//IL_015c: Expected I, but got O
		GameManager core = GM.Core;
		int playerCount = core._multiplayer.GetPlayerCount();
		if (playerCount <= 1 && !core._multiplayer.IsOnlineMultiplayer)
		{
			GameManager core2 = GM.Core;
			GameSessionData gameSessionData = core2._gameSessionData;
			List<Weapon> playerWeapons = core2.RemoveAllWeaponsFromPlayer(gameSessionData._activeCharacter);
			_playerWeapons = playerWeapons;
			nint num = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BBF0");
			LinkedList<WeaponType> linkedList = default(LinkedList<WeaponType>);
			linkedList.Clear();
		}
		else
		{
			GameManager core3 = GM.Core;
			Predicate<VampireSurvivors.Objects.Characters.CharacterController> match = _003C_003Ec._003C_003E9__73_0;
			if (_003C_003Ec._003C_003E9__73_0 == null)
			{
				match = (_003C_003Ec._003C_003E9__73_0 = delegate(VampireSurvivors.Objects.Characters.CharacterController x)
				{
					//IL_0052: Expected I4, but got O
					//IL_0030: Expected O, but got I4
					if ((object)x == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					object obj = x._characterType - 75;
					return obj == null;
				});
			}
			VampireSurvivors.Objects.Characters.CharacterController characterController = core3._characters.Find(match);
			if ((object)characterController != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
			{
				List<Weapon> playerWeapons2 = GM.Core.RemoveAllWeaponsFromPlayer(characterController);
				_playerWeapons = playerWeapons2;
				nint num2 = (nint)typeof(GM);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BBF0");
				Func<WeaponType, bool> condition = delegate(WeaponType specialWeapon)
				{
					//IL_006a: Expected O, but got I
					//IL_0084: Expected O, but got I
					_003C_003Ec__DisplayClass73_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass73_0();
					GameManager core4 = GM.Core;
					Dictionary<WeaponType, List<WeaponData>> convertedWeapons = core4._dataManager.GetConvertedWeapons();
					object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)specialWeapon);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v10 (System.Object)+18]");
					if ((nint)0 > (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v10 (System.Object)+10]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rax_v11+20]");
						CS_0024_003C_003E8__locals5.specialWeaponData = (WeaponData)0;
						if (CS_0024_003C_003E8__locals5.specialWeaponData != null)
						{
							WeaponData specialWeaponData = CS_0024_003C_003E8__locals5.specialWeaponData;
							if (specialWeaponData._003CevolvesFrom_003Ek__BackingField != null)
							{
								Predicate<Weapon> match2 = delegate(Weapon weapon2)
								{
									//IL_0061: Expected I4, but got O
									WeaponData specialWeaponData2 = CS_0024_003C_003E8__locals5.specialWeaponData;
									if (CS_0024_003C_003E8__locals5.specialWeaponData == null || (object)weapon2 == null || specialWeaponData2._003CevolvesFrom_003Ek__BackingField == null)
									{
										NullReferenceException ex = new NullReferenceException();
										return (byte)(int)ex != 0;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
									bool result2 = default(bool);
									return result2;
								};
								Weapon weapon = _playerWeapons.Find(match2);
								if ((object)weapon != null)
								{
									bool flag = ((UnityEngine.Object)weapon).m_CachedPtr == (IntPtr)0;
									return !flag;
								}
							}
						}
						return false;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					bool result = default(bool);
					return result;
				};
				ICollection<System.Int32Enum> collection = default(ICollection<System.Int32Enum>);
				Extensions.RemoveWhere(collection, (Func<System.Int32Enum, bool>)(object)condition);
			}
		}
		CreateWeapons();
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

	public BackgroundFoscari2()
	{
		List<Weapon> playerWeapons = new List<Weapon>();
		_playerWeapons = playerWeapons;
		base._002Ector();
	}

	static BackgroundFoscari2()
	{
		List<WeaponType> list = new List<WeaponType>();
		s_foscariEventWeapons = list;
		s_hasFallenFromFoscari1 = false;
	}

	private void _003CAnimPizza_003Eb__46_0()
	{
		_pizzaAsprite.destroy();
	}

	private void _003CFreeJeneviv_003Eb__68_0()
	{
		DevourEggs();
		SummonSnakes();
	}

	private void _003CFreeJeneviv_003Eb__68_1()
	{
		SummonSnakes();
	}

	private void _003CFreeJeneviv_003Eb__68_2()
	{
		SummonSnakes();
	}

	private void _003CFreeJeneviv_003Eb__68_4()
	{
		//IL_00a4: Expected O, but got I4
		EnemyJeneviv jeneviv = _jeneviv;
		float2 position = _jeneviv.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		PhaserSprite phaserSprite = jeneviv._breakFreeSprite.setVisible(visible: true);
		PhaserSprite breakFreeSprite = jeneviv._breakFreeSprite;
		breakFreeSprite._spriteAnimation.SetAnimation("BreakAnim");
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
		object obj = activeCharacter._level * 300;
		((EnemyController)jeneviv)._hp = (((EnemyController)jeneviv)._maxHp = (float)obj + 1000f);
	}

	private void _003CFreeJeneviv_003Eb__68_5()
	{
		EnemyJeneviv jeneviv = _jeneviv;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6283]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		float2 position = _jeneviv.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		PhaserSprite phaserSprite = jeneviv._breakFreeSprite.setVisible(visible: true);
		PhaserSprite breakFreeSprite = jeneviv._breakFreeSprite;
		breakFreeSprite._spriteAnimation.SetAnimation("BreakAnim");
		float num = ((EnemyController)jeneviv)._defaultSpeed * 0.1f;
		((EnemyController)jeneviv)._003CIsTeleportOnCull_003Ek__BackingField = true;
		jeneviv._painInTheAss = true;
		((EnemyController)jeneviv)._003CSpeed_003Ek__BackingField = num;
		((EnemyController)jeneviv)._SpriteAnimation.SetAnimation("NoColor");
	}

	private void _003CFreeJeneviv_003Eb__68_6()
	{
		EnemyJeneviv jeneviv = _jeneviv;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6284]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		float2 position = _jeneviv.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		PhaserSprite phaserSprite = jeneviv._breakFreeSprite.setVisible(visible: true);
		PhaserSprite breakFreeSprite = jeneviv._breakFreeSprite;
		breakFreeSprite._spriteAnimation.SetAnimation("BreakAnim");
		((EnemyController)jeneviv)._SpriteAnimation.SetAnimation("NoEle");
		((EnemyController)jeneviv)._003CSpeed_003Ek__BackingField = ((EnemyController)jeneviv)._defaultSpeed;
	}

	private void _003CFreeJeneviv_003Eb__68_7()
	{
		_jeneviv.ChargeWorldEater();
	}

	private void _003CFreeJeneviv_003Eb__68_8()
	{
		_jeneviv.CastWorldEater();
		OnWorldEater();
	}

	private void _003CFreeJeneviv_003Eb__68_9()
	{
		_jeneviv.StartVerySmartAI();
	}

	private void _003CFreeJeneviv_003Eb__68_10()
	{
		GameManager core = GM.Core;
		core._003CCanInterrupt_003Ek__BackingField = true;
		GameManager core2 = GM.Core;
		core2._003CCanPause_003Ek__BackingField = true;
		if (_luminairePathEvent != null)
		{
			_luminairePathEvent.Cancel();
		}
		Action onComplete = delegate
		{
			//IL_04ee: Expected I, but got O
			//IL_04fc: Expected I, but got O
			//IL_050c: Expected O, but got I
			//IL_058c: Expected O, but got I4
			//IL_0548: Expected O, but got I
			//IL_05f6: Expected F4, but got O
			//IL_057e: Expected O, but got I4
			//IL_039e: Expected F4, but got O
			GameManager core3 = GM.Core;
			Predicate<VampireSurvivors.Objects.Characters.CharacterController> match = _003C_003Ec._003C_003E9__71_1;
			if (_003C_003Ec._003C_003E9__71_1 == null)
			{
				match = (_003C_003Ec._003C_003E9__71_1 = delegate(VampireSurvivors.Objects.Characters.CharacterController x)
				{
					//IL_0052: Expected I4, but got O
					//IL_0030: Expected O, but got I4
					if ((object)x == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					object obj6 = x._characterType - 75;
					return obj6 == null;
				});
			}
			VampireSurvivors.Objects.Characters.CharacterController characterController = core3._characters.Find(match);
			if ((object)characterController == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			Equipment equipmentByType = characterController._weaponsManager.GetEquipmentByType(WeaponType.PRISMATICMISS);
			bool flag = (object)equipmentByType == null;
			int num = 0;
			if (!flag)
			{
				bool flag2 = ((UnityEngine.Object)equipmentByType).m_CachedPtr == (IntPtr)0;
				num = 0;
				if (!flag2)
				{
					num = equipmentByType._003CLevel_003Ek__BackingField;
				}
			}
			Vector2 pos = default(Vector2);
			GameManager core6;
			float y2;
			object obj = default(object);
			float2 float5;
			WeaponType weaponType;
			if ((object)equipmentByType != null && ((UnityEngine.Object)equipmentByType).m_CachedPtr != (IntPtr)0 && num >= 8)
			{
				Equipment equipmentByType2 = characterController._accessoriesManager.GetEquipmentByType(WeaponType.GROWTH);
				bool flag3 = equipmentByType2;
				bool flag4 = !flag3;
				int num2 = 0;
				if (!flag4)
				{
					num2 = equipmentByType2._003CLevel_003Ek__BackingField;
				}
				if ((bool)equipmentByType2 && num2 >= 5)
				{
					List<float> list = new List<float>();
					list.Add(0.1f);
					list.Add(5f);
					list.Add(100f);
					List<PrizeType?> list2 = new List<PrizeType?>();
					((List<float>)(object)list2).Add(100f);
					((List<float>)(object)list2).Add(100f);
					((List<float>)(object)list2).Add(100f);
					((List<float>)(object)list2).Add(100f);
					((List<float>)(object)list2).Add(100f);
					Treasure treasure = new Treasure();
					treasure._003Clevel_003Ek__BackingField = 1;
					treasure.chances = list;
					treasure.prizeTypes = list2;
					List<WeaponType> fixedPrizes = new List<WeaponType>();
					treasure.fixedPrizes = fixedPrizes;
					treasure._003ChasArcana_003Ek__BackingField = false;
					GameManager core4 = GM.Core;
					int num3 = core4._stage.SetTreasureLevelFromChance(treasure);
					float2 position = characterController.position;
					float2 position2 = characterController.position;
					PhaserScene phaserScene = GM.Core.scene;
					PhaserScene.Renderer renderer = phaserScene._renderer;
					float num4 = renderer.height * 0.25f;
					float y = 6f - num4;
					TreasureChest treasureChest = GM.Core.MakeTreasure(pos, treasure);
					GameManager core5 = GM.Core;
					core5._gizmoManager.ShowHighlightAt((float)position, y);
					_checkForLuminaire = true;
					return;
				}
				float2 position3 = characterController.position;
				float2 position4 = characterController.position;
				if ((object)GM.Core == null)
				{
					goto IL_0610;
				}
				PhaserScene s_scene = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer2 = s_scene._renderer;
				float num5 = renderer2.height * 0.25f;
				core6 = GM.Core;
				y2 = (float)obj - num5;
				float5 = position3;
				weaponType = WeaponType.GROWTH;
			}
			else
			{
				float2 position5 = characterController.position;
				float2 position6 = characterController.position;
				if ((object)GM.Core == null)
				{
					goto IL_0610;
				}
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer3 = s_scene2._renderer;
				float num6 = renderer3.height * 0.25f;
				core6 = GM.Core;
				y2 = (float)obj - num6;
				float5 = position5;
				weaponType = WeaponType.PRISMATICMISS;
			}
			float value = default(float);
			ItemType relicType = default(ItemType);
			bool validatePickups = default(bool);
			Pickup pickup = core6.MakeStagePickup(pos, ItemType.WEAPON, weaponType, value, relicType, validatePickups);
			bool flag5 = (object)pickup == null;
			UnityEngine.Object obj2 = null;
			ItemType itemType = ItemType.WEAPON;
			if (flag5)
			{
				goto IL_05a6;
			}
			nint num7 = (nint)pickup;
			nint num8 = (nint)typeof(PickupWeapon);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1236 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1235 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1236 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
			object obj5;
			if (num9 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1235 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1313 @ rax_v40+FFFFFFF8+v1237 @ rax_v36*8]");
				if (0 == (nint)typeof(PickupWeapon))
				{
					obj5 = 1;
					goto IL_0766;
				}
			}
			obj5 = 0;
			goto IL_0766;
			IL_05a6:
			if ((bool)obj2)
			{
				_ = 0;
				GameManager core7 = GM.Core;
				core7._gizmoManager.ShowHighlightAt((float)float5, y2);
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BC71C0");
			}
			return;
			IL_0610:
			throw new NullReferenceException();
			IL_0766:
			bool flag6 = obj5 == null;
			obj2 = null;
			itemType = (ItemType)num7;
			if (!flag6)
			{
				obj2 = pickup;
				itemType = (ItemType)num7;
			}
			goto IL_05a6;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer luminairePathEvent = Timers.Register(10f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_luminairePathEvent = luminairePathEvent;
	}

	private void _003CStartSpawningPrismaticMissile_003Eb__71_0()
	{
		//IL_04ee: Expected I, but got O
		//IL_04fc: Expected I, but got O
		//IL_050c: Expected O, but got I
		//IL_058c: Expected O, but got I4
		//IL_0548: Expected O, but got I
		//IL_05f6: Expected F4, but got O
		//IL_057e: Expected O, but got I4
		//IL_039e: Expected F4, but got O
		GameManager core = GM.Core;
		Predicate<VampireSurvivors.Objects.Characters.CharacterController> match = _003C_003Ec._003C_003E9__71_1;
		if (_003C_003Ec._003C_003E9__71_1 == null)
		{
			match = (_003C_003Ec._003C_003E9__71_1 = delegate(VampireSurvivors.Objects.Characters.CharacterController x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj6 = x._characterType - 75;
				return obj6 == null;
			});
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = core._characters.Find(match);
		if ((object)characterController == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Equipment equipmentByType = characterController._weaponsManager.GetEquipmentByType(WeaponType.PRISMATICMISS);
		bool flag = (object)equipmentByType == null;
		int num = 0;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)equipmentByType).m_CachedPtr == (IntPtr)0;
			num = 0;
			if (!flag2)
			{
				num = equipmentByType._003CLevel_003Ek__BackingField;
			}
		}
		Vector2 pos = default(Vector2);
		GameManager core4;
		float y2;
		object obj = default(object);
		float2 float5;
		WeaponType weaponType;
		if ((object)equipmentByType != null && ((UnityEngine.Object)equipmentByType).m_CachedPtr != (IntPtr)0 && num >= 8)
		{
			Equipment equipmentByType2 = characterController._accessoriesManager.GetEquipmentByType(WeaponType.GROWTH);
			bool flag3 = equipmentByType2;
			bool flag4 = !flag3;
			int num2 = 0;
			if (!flag4)
			{
				num2 = equipmentByType2._003CLevel_003Ek__BackingField;
			}
			if ((bool)equipmentByType2 && num2 >= 5)
			{
				List<float> list = new List<float>();
				list.Add(0.1f);
				list.Add(5f);
				list.Add(100f);
				List<PrizeType?> list2 = new List<PrizeType?>();
				((List<float>)(object)list2).Add(100f);
				((List<float>)(object)list2).Add(100f);
				((List<float>)(object)list2).Add(100f);
				((List<float>)(object)list2).Add(100f);
				((List<float>)(object)list2).Add(100f);
				Treasure treasure = new Treasure();
				treasure._003Clevel_003Ek__BackingField = 1;
				treasure.chances = list;
				treasure.prizeTypes = list2;
				List<WeaponType> fixedPrizes = new List<WeaponType>();
				treasure.fixedPrizes = fixedPrizes;
				treasure._003ChasArcana_003Ek__BackingField = false;
				GameManager core2 = GM.Core;
				int num3 = core2._stage.SetTreasureLevelFromChance(treasure);
				float2 position = characterController.position;
				float2 position2 = characterController.position;
				PhaserScene phaserScene = GM.Core.scene;
				PhaserScene.Renderer renderer = phaserScene._renderer;
				float num4 = renderer.height * 0.25f;
				float y = 6f - num4;
				TreasureChest treasureChest = GM.Core.MakeTreasure(pos, treasure);
				GameManager core3 = GM.Core;
				core3._gizmoManager.ShowHighlightAt((float)position, y);
				_checkForLuminaire = true;
				return;
			}
			float2 position3 = characterController.position;
			float2 position4 = characterController.position;
			if ((object)GM.Core == null)
			{
				goto IL_0610;
			}
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene._renderer;
			float num5 = renderer2.height * 0.25f;
			core4 = GM.Core;
			y2 = (float)obj - num5;
			float5 = position3;
			weaponType = WeaponType.GROWTH;
		}
		else
		{
			float2 position5 = characterController.position;
			float2 position6 = characterController.position;
			if ((object)GM.Core == null)
			{
				goto IL_0610;
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer3 = s_scene2._renderer;
			float num6 = renderer3.height * 0.25f;
			core4 = GM.Core;
			y2 = (float)obj - num6;
			float5 = position5;
			weaponType = WeaponType.PRISMATICMISS;
		}
		float value = default(float);
		ItemType relicType = default(ItemType);
		bool validatePickups = default(bool);
		Pickup pickup = core4.MakeStagePickup(pos, ItemType.WEAPON, weaponType, value, relicType, validatePickups);
		bool flag5 = (object)pickup == null;
		UnityEngine.Object obj2 = null;
		ItemType itemType = ItemType.WEAPON;
		nint num7;
		object obj5;
		if (!flag5)
		{
			num7 = (nint)pickup;
			nint num8 = (nint)typeof(PickupWeapon);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1236 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1235 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1236 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
			if (num9 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1235 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1313 @ rax_v40+FFFFFFF8+v1237 @ rax_v36*8]");
				if (0 == (nint)typeof(PickupWeapon))
				{
					obj5 = 1;
					goto IL_0766;
				}
			}
			obj5 = 0;
			goto IL_0766;
		}
		goto IL_05a6;
		IL_05a6:
		if ((bool)obj2)
		{
			_ = 0;
			GameManager core5 = GM.Core;
			core5._gizmoManager.ShowHighlightAt((float)float5, y2);
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BC71C0");
		}
		return;
		IL_0610:
		throw new NullReferenceException();
		IL_0766:
		bool flag6 = obj5 == null;
		obj2 = null;
		itemType = (ItemType)num7;
		if (!flag6)
		{
			obj2 = pickup;
			itemType = (ItemType)num7;
		}
		goto IL_05a6;
	}

	private bool _003COnWorldEater_003Eb__73_1(WeaponType specialWeapon)
	{
		//IL_006a: Expected O, but got I
		//IL_0084: Expected O, but got I
		_003C_003Ec__DisplayClass73_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass73_0();
		GameManager core = GM.Core;
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = core._dataManager.GetConvertedWeapons();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)specialWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v10 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v10 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rax_v11+20]");
			CS_0024_003C_003E8__locals5.specialWeaponData = (WeaponData)0;
			if (CS_0024_003C_003E8__locals5.specialWeaponData != null)
			{
				WeaponData specialWeaponData = CS_0024_003C_003E8__locals5.specialWeaponData;
				if (specialWeaponData._003CevolvesFrom_003Ek__BackingField != null)
				{
					Predicate<Weapon> match = delegate(Weapon weapon2)
					{
						//IL_0061: Expected I4, but got O
						WeaponData specialWeaponData2 = CS_0024_003C_003E8__locals5.specialWeaponData;
						if (CS_0024_003C_003E8__locals5.specialWeaponData == null || (object)weapon2 == null || specialWeaponData2._003CevolvesFrom_003Ek__BackingField == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
						bool result2 = default(bool);
						return result2;
					};
					Weapon weapon = _playerWeapons.Find(match);
					if ((object)weapon != null)
					{
						bool flag = ((UnityEngine.Object)weapon).m_CachedPtr == (IntPtr)0;
						return !flag;
					}
				}
			}
			return false;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		bool result = default(bool);
		return result;
	}
}
