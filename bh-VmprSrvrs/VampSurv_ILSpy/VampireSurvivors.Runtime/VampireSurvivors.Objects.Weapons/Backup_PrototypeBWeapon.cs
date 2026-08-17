using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class Backup_PrototypeBWeapon : FB_QuantisedAngleWeapon
{
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public int index;

		public Backup_PrototypeBWeapon _003C_003E4__this;

		internal void _003CstartPlanes_003Eb__0()
		{
			_003C_003E4__this.dropexplosion(index);
		}
	}

	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public int index;

		public Backup_PrototypeBWeapon _003C_003E4__this;

		internal void _003Cdropexplosion_003Eb__0()
		{
			//IL_009e: Expected O, but got I
			Backup_PrototypeBWeapon backup_PrototypeBWeapon = _003C_003E4__this;
			List<PhaserSprite> planeSprites = backup_PrototypeBWeapon._planeSprites;
			int num = index;
			if (index < planeSprites._size)
			{
				PhaserSprite[] items = planeSprites._items;
				float2 position = items[num].position;
				Weapon weapon = _003C_003E4__this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v10 (VampireSurvivors.Objects.Weapons.Weapon)+190]");
				float2 pos = default(float2);
				Projectile projectile = ((BulletPool)0).SpawnAt(pos, _003C_003E4__this);
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
	}

	private List<PhaserSprite> _planeSprites;

	private List<float2> _planeVectors;

	private Timer _planeTimer;

	private MultiTargetTween _moveTween;

	private Timer[] _explosionTimers;

	private Timer[] _explosionDelays;

	private BulletPool _explosionPool;

	private float2 _playerPos;

	public float planesOffsetY;

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_0206: Expected O, but got F4
		//IL_02cc: Expected O, but got I
		//IL_0508: Expected I, but got O
		//IL_051e: Expected O, but got I
		//IL_0527: Unknown result type (might be due to invalid IL or missing references)
		//IL_052c: Expected O, but got Unknown
		//IL_05a2: Expected I, but got O
		//IL_0643: Expected O, but got I4
		//IL_065a: Expected I, but got I8
		//IL_057e: Expected I, but got I8
		//IL_03da: Expected I, but got O
		//IL_0409: Expected O, but got I4
		//IL_047d: Expected I, but got O
		//IL_04ac: Expected O, but got I4
		base.InitWeapon(characterController, weaponType);
		bool flag = false;
		Vector2 vector = default(Vector2);
		bool flag2 = default(bool);
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		Action action;
		while (true)
		{
			if ((object)GM.Core != null && (object)GM.Core != null)
			{
				GameObject gameObject = base.gameObject;
				PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "vfx", "flame000");
				PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: false);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer = s_scene._renderer;
					int depth = renderer.pixelHeight - 1;
					PhaserSprite phaserSprite3 = phaserSprite.setDepth(depth);
					List<object> planeSprites = (List<object>)(object)_planeSprites;
					int version = planeSprites._version + 1;
					planeSprites._version = version;
					object[] items = planeSprites._items;
					if (planeSprites._size >= items.Length)
					{
						planeSprites.AddWithResize((object)phaserSprite);
					}
					else
					{
						int size = planeSprites._size + 1;
						planeSprites._size = size;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					List<float2> planeVectors = _planeVectors;
					float num = (float)(flag ? 1 : 0) - 3f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					object obj = num & 0;
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene2 = ArcadePhysics.s_scene;
						PhaserScene.Renderer renderer2 = s_scene2._renderer;
						object obj2 = renderer2.height ^ -0f;
						float num2 = (float)obj * 0.19999999f;
						float num3 = (float)obj2 - num2;
						float num4 = (float)(flag ? 1 : 0) * 0.29999998f;
						float num5 = num4 - 0.9f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rbx_v7 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rbx_v7 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rbx_v7 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
						nint num7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v978 @ r8_v14 (Il2CppMethodInfo)+18]");
						if (num7 >= 0)
						{
							planeVectors.AddWithResize((float2)vector);
							num6 = 0;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rbx_v7 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
							object obj3 = (nint)0 + (nint)1;
						}
						flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
						if ((flag ? 1 : 0) < 7)
						{
							continue;
						}
						Timer[] explosionTimers = new Timer[10];
						_explosionTimers = explosionTimers;
						Timer[] explosionDelays = new Timer[70];
						_explosionDelays = explosionDelays;
						if (_explosionPool != null)
						{
							goto IL_04bd;
						}
						Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.FB_PROTOTYPE_B_EXPLOSION);
						BulletPool explosionPool = new BulletPool(projectilePrefab);
						_explosionPool = explosionPool;
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene3 = ArcadePhysics.s_scene;
							ArcadePhysics physics = s_scene3.physics;
							GameManager core = GM.Core;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1394 @ r8_v30 (Il2CppClass<VampireSurvivors.Objects.Weapons.Backup_PrototypeBWeapon>)+370]");
							ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
							nint num8 = (nint)this;
							Collider collider = physics.add.overlap(_explosionPool, core.Enemies, collideCallback, (ArcadePhysicsCallback)flag2, (CallbackContext)(object)monoBehaviour);
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene4 = ArcadePhysics.s_scene;
								ArcadePhysics physics2 = s_scene4.physics;
								GameManager core2 = GM.Core;
								PhysicsManager physicsManager = core2._physicsManager;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1416 @ r8_v33 (Il2CppClass<VampireSurvivors.Objects.Weapons.Backup_PrototypeBWeapon>)+3A0]");
								ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
								nint num9 = (nint)this;
								Collider collider2 = physics2.add.overlap(_explosionPool, physicsManager._destructiblesGroup, collideCallback2, (ArcadePhysicsCallback)flag2, (CallbackContext)(object)monoBehaviour);
								flag2 = flag2;
								goto IL_04bd;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
			IL_04bd:
			action = null;
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v708 @ r10_v1 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(Backup_PrototypeBWeapon._003CInitWeapon_003Eb__9_0);
			((Delegate)action).m_target = this;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v708 @ r10_v1 (Il2CppMethodInfo)+4C]");
			object obj4 = (nint)0 >> 4;
			object obj5 = obj4 & 1;
			nint num11;
			if (obj5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v708 @ r10_v1 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num11 = unchecked((nint)6447293664L);
					break;
				}
			}
			num11 = ((Delegate)action).method_ptr;
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			break;
		}
		object obj6 = 24;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer planeTimer = Timers.Register(10f, action, null, isLooped: true, flag2, monoBehaviour, repeat, type, isOnlineTimer: false, canPause: false);
		_planeTimer = planeTimer;
	}

	private unsafe void startPlanes()
	{
		//IL_006d: Expected I, but got O
		//IL_00d2: Expected I, but got O
		//IL_025a: Expected O, but got I4
		//IL_02f3: Expected I, but got O
		//IL_0309: Expected O, but got I
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Expected O, but got Unknown
		//IL_0380: Expected I, but got O
		//IL_0498: Expected O, but got I4
		//IL_04af: Expected I, but got I8
		//IL_0369: Expected I, but got I8
		//IL_0415: Unknown result type (might be due to invalid IL or missing references)
		//IL_041a: Expected O, but got Unknown
		//IL_03b7: Expected I, but got O
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		_playerPos = renderer.screenCenter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rcx_v11 (PhaserScene+Renderer)+38]");
		_ = 0;
		planesOffsetY = 0f;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			nint num2 = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdx_v13 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
			nint num3 = 0;
			if ((object)GM.Core != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object value = default(object);
				bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"planesOffsetY", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				tweenConfig.custom = dictionary;
				tweenConfig.duration = 7000f;
				MultiTargetTween moveTween = Tweens.Add(tweenConfig);
				_moveTween = moveTween;
				List<float2> planeVectors = _planeVectors;
				bool flag2 = false;
				bool flag3 = false;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				object obj7 = default(object);
				while (true)
				{
					bool num4 = flag3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v35 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
					if ((nint)(num4 ? 1 : 0) < (nint)0)
					{
						List<PhaserSprite> planeSprites = _planeSprites;
						if ((flag2 ? 1 : 0) < planeSprites._size)
						{
							PhaserSprite[] items = planeSprites._items;
							PhaserSprite phaserSprite = items[flag2 ? 1u : 0u].setVisible(visible: true);
							planeVectors = _planeVectors;
							flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
							flag3 = flag2;
							continue;
						}
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					}
					else
					{
						Timer[] explosionTimers = _explosionTimers;
						object obj2 = 650;
						bool flag4 = false;
						bool flag5 = false;
						while (true)
						{
							if ((flag5 ? 1 : 0) >= explosionTimers.Length)
							{
								return;
							}
							_003C_003Ec__DisplayClass10_0 obj3 = new _003C_003Ec__DisplayClass10_0();
							obj3._003C_003E4__this = this;
							obj3.index = (flag4 ? 1 : 0);
							Timer[] explosionTimers2 = _explosionTimers;
							Action action = null;
							nint num5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ r10_v6 (Il2CppMethodInfo)+8]");
							((Delegate)action).method_ptr = (IntPtr)0;
							((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass10_0._003CstartPlanes_003Eb__0);
							((Delegate)action).m_target = obj3;
							((Delegate)action).method_code = (IntPtr)action;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ r10_v6 (Il2CppMethodInfo)+4C]");
							object obj4 = (nint)0 >> 4;
							object obj5 = obj4 & 1;
							nint num6;
							if (obj5 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ r10_v6 (Il2CppMethodInfo)+52]");
								if ((nint)0 == 0)
								{
									num6 = unchecked((nint)6447293664L);
									goto IL_048f;
								}
							}
							((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
							num6 = ((Delegate)action).method_ptr;
							goto IL_048f;
							IL_048f:
							object obj6 = 24;
							((Delegate)action).extra_arg = unchecked((nint)6447293568L);
							float duration = (float)obj2 * 0.001f;
							Timer timer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
							if (timer != null)
							{
								nint num7 = (nint)explosionTimers2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								if (obj7 == null)
								{
									break;
								}
							}
							explosionTimers2[flag4 ? 1u : 0u] = timer;
							explosionTimers = _explosionTimers;
							flag4 = (byte)((flag4 ? 1u : 0u) + 1u) != 0;
							obj2 += 550;
							bool flag6 = _explosionTimers != null;
							flag5 = flag4;
							if (!flag6)
							{
								goto end_IL_0191;
							}
						}
					}
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
					continue;
					end_IL_0191:
					break;
				}
			}
			throw new NullReferenceException();
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	public override void InternalUpdate()
	{
		//IL_01a2: Expected O, but got I4
		//IL_01ab: Expected O, but got I4
		//IL_0090: Expected O, but got I
		//IL_00f2: Expected O, but got I
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected O, but got Unknown
		base.InternalUpdate();
		List<PhaserSprite> planeSprites = _planeSprites;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < planeSprites._size)
			{
				List<PhaserSprite> planeSprites2 = _planeSprites;
				if ((nint)obj >= planeSprites2._size)
				{
					break;
				}
				PhaserSprite[] items = planeSprites2._items;
				List<float2> planeVectors = _planeVectors;
				object obj3 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rax_v7 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				if ((nint)obj3 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rax_v7 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
				object obj4 = 0;
				PhaserScene s_scene = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer = s_scene._renderer;
				List<float2> planeVectors2 = _planeVectors;
				object obj5 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v13 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				if ((nint)obj5 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v13 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rcx_v6+20+v87 @ rbx_v2*8]");
				float x = 0f + (float)_playerPos;
				float num = planesOffsetY;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r8_v2 (PhaserScene+Renderer)+38]");
				float num2 = num + 0f;
				float num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v3+24+v87 @ rbx_v2*8]");
				float y = num3 + 0f;
				PhaserSprite phaserSprite = items[obj].setPosition(x, y);
				planeSprites = _planeSprites;
				obj++;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private unsafe void dropexplosion(int explosionIndex)
	{
		//IL_0297: Expected O, but got I4
		//IL_02bd: Expected O, but got F4
		//IL_00ca: Expected I, but got O
		//IL_00e0: Expected O, but got I
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_0157: Expected I, but got O
		//IL_0307: Expected O, but got I4
		//IL_033e: Expected I, but got I8
		//IL_01c3: Expected O, but got I4
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		//IL_0140: Expected I, but got I8
		//IL_018e: Expected I, but got O
		//IL_03a9->IL0243: Incompatible stack heights: 3 vs 2
		//IL_01b1->IL01b1: Incompatible stack heights: 7 vs 6
		//IL_0243->IL038a: Incompatible stack heights: 8 vs 3
		GameObject gameObject = base.gameObject;
		bool flag = (object)gameObject == null;
		bool flag2 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
		object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
		if (obj == null)
		{
			return;
		}
		List<PhaserSprite> planeSprites = _planeSprites;
		bool flag3 = _planeSprites == null;
		bool flag4 = false;
		bool flag5 = false;
		float num4 = default(float);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		object obj7 = default(object);
		while ((flag5 ? 1 : 0) < planeSprites._size)
		{
			_003C_003Ec__DisplayClass12_0 obj2 = new _003C_003Ec__DisplayClass12_0();
			bool flag6 = obj2 == null;
			obj2._003C_003E4__this = this;
			((UnityEngine.Object)(object)obj2).m_CachedPtr = (IntPtr)(flag4 ? 1 : 0);
			List<PhaserSprite> planeSprites2 = _planeSprites;
			Timer[] explosionDelays = _explosionDelays;
			bool flag7 = _planeSprites == null;
			object obj3 = UnityEngine.Random.value;
			Action action = null;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ r10_v8 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass12_0._003Cdropexplosion_003Eb__0);
			((Delegate)action).m_target = obj2;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ r10_v8 (Il2CppMethodInfo)+4C]");
			object obj4 = (nint)0 >> 4;
			object obj5 = obj4 & 1;
			nint num2;
			if (obj5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ r10_v8 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num2 = unchecked((nint)6447293664L);
					goto IL_02fe;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num2 = ((Delegate)action).method_ptr;
			goto IL_02fe;
			IL_02fe:
			object obj6 = 24;
			float num3 = num4 * 500f;
			num4 = num3 * 0.001f;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			Timer timer = Timers.Register(num4, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			bool flag8 = _explosionDelays == null;
			if (timer != null)
			{
				nint num5 = (nint)explosionDelays;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				bool flag9 = obj7 == null;
			}
			object obj8 = planeSprites2._size * explosionIndex;
			object obj9 = obj8 + flag4;
			bool flag10 = (nint)obj9 >= explosionDelays.Length;
			explosionDelays[obj9] = timer;
			planeSprites = _planeSprites;
			flag4 = (byte)((flag4 ? 1u : 0u) + 1u) != 0;
			bool flag11 = _planeSprites == null;
			flag5 = flag4;
		}
	}

	public override void Cleanup()
	{
		//IL_006c: Expected O, but got I4
		//IL_0075: Expected O, but got I4
		//IL_015e: Expected O, but got I4
		//IL_0167: Expected O, but got I4
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Expected O, but got Unknown
		//IL_0125: Expected O, but got I4
		//IL_0133: Expected O, but got I4
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Expected O, but got Unknown
		//IL_0217: Expected O, but got I4
		//IL_0225: Expected O, but got I4
		base.Cleanup();
		if (_planeTimer != null)
		{
			_planeTimer.Cancel();
		}
		if (_moveTween != null)
		{
			_moveTween.Kill();
		}
		Timer[] explosionTimers = _explosionTimers;
		bool flag = _explosionTimers == null;
		object obj = 0;
		object obj2 = 0;
		if (!flag)
		{
			List<PhaserSprite>.Enumerator enumerator = default(List<PhaserSprite>.Enumerator);
			while (true)
			{
				if ((nint)obj2 < explosionTimers.Length)
				{
					if ((nint)obj < explosionTimers.Length)
					{
						Timer timer = explosionTimers[obj];
						if (explosionTimers[obj] == null)
						{
							break;
						}
						if (!explosionTimers[obj].IsDone)
						{
							float timeElapsed = explosionTimers[obj].GetTimeElapsed();
							timer._timeElapsedBeforeCancel = (float?)(object)1;
							timer._timeElapsedBeforePause = (float?)(object)0;
						}
						obj++;
						obj2 = obj;
						continue;
					}
					goto IL_02b1;
				}
				Timer[] explosionDelays = _explosionDelays;
				bool flag2 = _explosionDelays == null;
				object obj3 = 0;
				object obj4 = 0;
				if (flag2)
				{
					break;
				}
				while ((nint)obj4 < explosionDelays.Length)
				{
					if ((nint)obj3 < explosionDelays.Length)
					{
						Timer timer2 = explosionDelays[obj3];
						if (explosionDelays[obj3] == null)
						{
							goto end_IL_0083;
						}
						if (!explosionDelays[obj3].IsDone)
						{
							float timeElapsed = explosionDelays[obj3].GetTimeElapsed();
							timer2._timeElapsedBeforeCancel = (float?)(object)1;
							timer2._timeElapsedBeforePause = (float?)(object)0;
						}
						obj3++;
						obj4 = obj3;
						continue;
					}
					goto IL_02b1;
				}
				if (_planeSprites == null)
				{
					break;
				}
				if (enumerator.MoveNext())
				{
					PhaserSprite phaserSprite = null;
					throw new NullReferenceException();
				}
				if (_explosionPool == null)
				{
					break;
				}
				_explosionPool.Cleanup();
				return;
				IL_02b1:
				throw new IndexOutOfRangeException();
				continue;
				end_IL_0083:
				break;
			}
		}
		throw new NullReferenceException();
	}

	public Backup_PrototypeBWeapon()
	{
		//IL_002e: Expected O, but got I4
		List<PhaserSprite> planeSprites = new List<PhaserSprite>();
		_planeSprites = planeSprites;
		_planeVectors = new List<float2>();
		_playerPos = (float2)0;
		((Weapon)this)._002Ector();
	}

	private void _003CInitWeapon_003Eb__9_0()
	{
		startPlanes();
	}
}
