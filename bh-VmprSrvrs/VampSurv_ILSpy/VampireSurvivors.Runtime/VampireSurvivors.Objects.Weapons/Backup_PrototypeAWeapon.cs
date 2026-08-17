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

public class Backup_PrototypeAWeapon : FB_QuantisedAngleWeapon
{
	private SpriteRenderer _muzzleFlash;

	private bool _muzzleFlashLastRotated;

	private int _frameCount;

	private float _sinPhase;

	private List<PhaserSprite> _planeSprites;

	private List<float2> _planeVectors;

	private Timer _planeTimer;

	private bool _planeFiring;

	private int _planeCounter;

	private Timer _planeFiringTimer;

	private MultiTargetTween _moveTween;

	private BulletPool _planeBulletPool;

	private float2 _playerPos;

	public float planesOffsetX;

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_017a: Expected O, but got Ref
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected O, but got Unknown
		//IL_0379: Expected O, but got F4
		//IL_0407: Expected O, but got I
		//IL_047f: Expected O, but got I
		//IL_0793: Expected I, but got O
		//IL_07a9: Expected O, but got I
		//IL_07b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b7: Expected O, but got Unknown
		//IL_082d: Expected I, but got O
		//IL_09f3: Expected O, but got I4
		//IL_0a0a: Expected I, but got I8
		//IL_0809: Expected I, but got I8
		//IL_05ce: Expected I, but got O
		//IL_061f: Expected O, but got I4
		//IL_06e6: Expected I, but got O
		//IL_0737: Expected O, but got I4
		//IL_08b9->IL0833: Incompatible stack heights: 1 vs 0
		//IL_0067->IL0833: Incompatible stack heights: 1 vs 0
		//IL_0a64->IL0833: Incompatible stack heights: 1 vs 0
		//IL_08e0->IL0833: Incompatible stack heights: 1 vs 0
		//IL_00b7->IL0833: Incompatible stack heights: 1 vs 0
		//IL_00d5->IL0833: Incompatible stack heights: 1 vs 0
		//IL_0907->IL0833: Incompatible stack heights: 1 vs 0
		//IL_00fc->IL0833: Incompatible stack heights: 1 vs 0
		//IL_013e->IL0833: Incompatible stack heights: 1 vs 0
		//IL_0168->IL0833: Incompatible stack heights: 1 vs 0
		//IL_01aa->IL0833: Incompatible stack heights: 1 vs 0
		//IL_093d->IL0833: Incompatible stack heights: 1 vs 0
		//IL_01de->IL0833: Incompatible stack heights: 1 vs 0
		//IL_022b->IL0833: Incompatible stack heights: 1 vs 0
		//IL_027a->IL0833: Incompatible stack heights: 1 vs 0
		//IL_032d->IL0833: Incompatible stack heights: 1 vs 0
		//IL_0964->IL0833: Incompatible stack heights: 1 vs 0
		//IL_0361->IL0833: Incompatible stack heights: 1 vs 0
		//IL_03d2->IL0833: Incompatible stack heights: 1 vs 0
		//IL_0424->IL0833: Incompatible stack heights: 1 vs 0
		//IL_0469->IL0969: Incompatible stack heights: 1 vs 2
		//IL_0997->IL0a4b: Incompatible stack heights: 2 vs 1
		//IL_04fa->IL0833: Incompatible stack heights: 2 vs 0
		//IL_0553->IL0833: Incompatible stack heights: 2 vs 0
		//IL_09be->IL0833: Incompatible stack heights: 2 vs 0
		//IL_0587->IL0833: Incompatible stack heights: 2 vs 0
		//IL_05ae->IL0833: Incompatible stack heights: 2 vs 0
		//IL_05f1->IL0833: Incompatible stack heights: 2 vs 0
		//IL_063c->IL0833: Incompatible stack heights: 2 vs 0
		//IL_09e5->IL0833: Incompatible stack heights: 2 vs 0
		//IL_0670->IL0833: Incompatible stack heights: 2 vs 0
		//IL_0697->IL0833: Incompatible stack heights: 2 vs 0
		//IL_06c6->IL0833: Incompatible stack heights: 2 vs 0
		//IL_0709->IL0833: Incompatible stack heights: 2 vs 0
		base.InitWeapon(characterController, weaponType);
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector2 ret;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
			if ((object)this != null)
			{
				GameObject gameObject = base.gameObject;
				Vector2 vector = default(Vector2);
				SpriteRenderer muzzleFlash = RenderingExtensions.AddSprite(gameObject, vector, "vfx", "2Spell4Orange");
				_muzzleFlash = muzzleFlash;
				if ((object)_muzzleFlash != null)
				{
					_muzzleFlash.enabled = false;
					_frameCount = 5;
					bool flag2 = false;
					bool flag5 = default(bool);
					MonoBehaviour monoBehaviour = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					while ((object)GM.Core != null)
					{
						PhaserScene s_scene = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene == null || s_scene._renderer == null || (object)GM.Core == null)
						{
							break;
						}
						PhaserScene s_scene2 = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene == null || s_scene2._renderer == null)
						{
							break;
						}
						GameObject gameObject2 = base.gameObject;
						PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject2, vector, "vfx", "flame000");
						if ((object)phaserSprite == null)
						{
							break;
						}
						Transform transform2 = phaserSprite.transform;
						if ((object)transform2 == null)
						{
							break;
						}
						transform2.localEulerAngles = (Vector3)(&ret);
						PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: false);
						if ((object)GM.Core == null)
						{
							break;
						}
						PhaserScene s_scene3 = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene == null)
						{
							break;
						}
						PhaserScene.Renderer renderer = s_scene3._renderer;
						if (s_scene3._renderer == null)
						{
							break;
						}
						int depth = renderer.pixelHeight - 1;
						PhaserSprite phaserSprite3 = phaserSprite.setDepth(depth);
						List<object> planeSprites = (List<object>)(object)_planeSprites;
						if (_planeSprites == null)
						{
							break;
						}
						int version = planeSprites._version + 1;
						planeSprites._version = version;
						object[] items = planeSprites._items;
						if (planeSprites._items == null)
						{
							break;
						}
						if (planeSprites._size >= items.Length)
						{
							((List<object>)(object)_planeSprites).AddWithResize((object)phaserSprite);
						}
						else
						{
							int size = planeSprites._size + 1;
							planeSprites._size = size;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						Transform planeVectors = (Transform)(object)_planeVectors;
						float num = (float)(flag2 ? 1 : 0) - 3f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
						object obj = num & 0;
						if ((object)GM.Core == null)
						{
							break;
						}
						PhaserScene s_scene4 = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene == null)
						{
							break;
						}
						PhaserScene.Renderer renderer2 = s_scene4._renderer;
						if (s_scene4._renderer == null)
						{
							break;
						}
						object obj2 = renderer2.width ^ -0f;
						float num2 = (float)obj * 0.19999999f;
						float num3 = (float)obj2 - num2;
						float num4 = (float)(flag2 ? 1 : 0) * 0.29999998f;
						float num5 = num4 - 0.9f;
						if (_planeVectors == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rbx_v11 (UnityEngine.Transform)+1C]");
						_ = (nint)0 + (nint)1;
						IntPtr cachedPtr = ((UnityEngine.Object)planeVectors).m_CachedPtr;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rbx_v11 (UnityEngine.Transform)+18]");
						object obj3 = 0;
						if (((UnityEngine.Object)planeVectors).m_CachedPtr == (IntPtr)0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rbx_v11 (UnityEngine.Transform)+18]");
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ r8_v18 (System.IntPtr)+18]");
						if (num6 >= 0)
						{
							_planeVectors.AddWithResize((float2)vector);
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rbx_v11 (UnityEngine.Transform)+18]");
							object obj4 = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rbx_v11 (UnityEngine.Transform)+18]");
							nint num7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ r8_v18 (System.IntPtr)+18]");
							bool flag3 = num7 >= 0;
						}
						flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
						bool flag4 = (flag2 ? 1 : 0) < 7;
						ret = vector;
						if (flag4)
						{
							continue;
						}
						if (_planeBulletPool == null)
						{
							if ((object)_projectileFactory == null)
							{
								break;
							}
							Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.FB_FULLAUTO);
							BulletPool planeBulletPool = new BulletPool(projectilePrefab);
							_planeBulletPool = planeBulletPool;
							if ((object)GM.Core == null)
							{
								break;
							}
							PhaserScene s_scene5 = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene == null)
							{
								break;
							}
							ArcadePhysics physics = s_scene5.physics;
							if ((object)s_scene5.physics == null)
							{
								break;
							}
							GameManager core = GM.Core;
							if ((object)GM.Core == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1646 @ r8_v34 (Il2CppClass<VampireSurvivors.Objects.Weapons.Backup_PrototypeAWeapon>)+370]");
							ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
							nint num8 = (nint)this;
							if (physics.add == null)
							{
								break;
							}
							Collider collider = physics.add.overlap(_planeBulletPool, core.Enemies, collideCallback, (ArcadePhysicsCallback)flag5, (CallbackContext)(object)monoBehaviour);
							if ((object)GM.Core == null)
							{
								break;
							}
							PhaserScene s_scene6 = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene == null)
							{
								break;
							}
							ArcadePhysics physics2 = s_scene6.physics;
							if ((object)s_scene6.physics == null)
							{
								break;
							}
							GameManager core2 = GM.Core;
							if ((object)GM.Core == null)
							{
								break;
							}
							PhysicsManager physicsManager = core2._physicsManager;
							if (core2._physicsManager == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1668 @ r8_v37 (Il2CppClass<VampireSurvivors.Objects.Weapons.Backup_PrototypeAWeapon>)+3A0]");
							ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
							nint num9 = (nint)this;
							if (physics2.add == null)
							{
								break;
							}
							Collider collider2 = physics2.add.overlap(_planeBulletPool, physicsManager._destructiblesGroup, collideCallback2, (ArcadePhysicsCallback)flag5, (CallbackContext)(object)monoBehaviour);
							flag5 = flag5;
						}
						Action action = null;
						nint num10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v921 @ r10_v1 (Il2CppMethodInfo)+8]");
						((Delegate)action).method_ptr = (IntPtr)0;
						((Delegate)action).method = (nint)__ldftn(Backup_PrototypeAWeapon._003CInitWeapon_003Eb__14_0);
						((Delegate)action).m_target = this;
						((Delegate)action).method_code = (IntPtr)action;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v921 @ r10_v1 (Il2CppMethodInfo)+4C]");
						object obj5 = (nint)0 >> 4;
						object obj6 = obj5 & 1;
						nint num11;
						if (obj6 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v921 @ r10_v1 (Il2CppMethodInfo)+52]");
							if ((nint)0 == 0)
							{
								num11 = unchecked((nint)6447293664L);
								goto IL_09ea;
							}
						}
						num11 = ((Delegate)action).method_ptr;
						((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
						goto IL_09ea;
						IL_09ea:
						object obj7 = 24;
						((Delegate)action).extra_arg = unchecked((nint)6447293568L);
						Timer planeTimer = Timers.Register(10f, action, null, isLooped: true, flag5, monoBehaviour, repeat, type, isOnlineTimer: false, canPause: false);
						_planeTimer = planeTimer;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void startPlanes()
	{
		//IL_0058: Expected I, but got O
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		_playerPos = position;
		planesOffsetX = 0f;
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
			if ((object)GM.Core != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object value = default(object);
				bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"planesOffsetX", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				tweenConfig.custom = dictionary;
				tweenConfig.duration = 7000f;
				MultiTargetTween moveTween = Tweens.Add(tweenConfig);
				_moveTween = moveTween;
				Action onComplete = delegate
				{
					_planeFiring = true;
					Action onComplete2 = delegate
					{
						_planeFiring = false;
					};
					bool useRealTime2 = default(bool);
					MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
					int repeat2 = default(int);
					TimerType type2 = default(TimerType);
					Timer planeFiringTimer2 = Timers.Register(2.5f, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
					_planeFiringTimer = planeFiringTimer2;
				};
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer planeFiringTimer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_planeFiringTimer = planeFiringTimer;
				List<float2> planeVectors = _planeVectors;
				bool flag2 = false;
				bool flag3 = false;
				while (true)
				{
					bool num2 = flag3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v33 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
					if ((nint)(num2 ? 1 : 0) < (nint)0)
					{
						List<PhaserSprite> planeSprites = _planeSprites;
						if ((flag2 ? 1 : 0) >= planeSprites._size)
						{
							break;
						}
						PhaserSprite[] items = planeSprites._items;
						PhaserSprite phaserSprite = items[flag2 ? 1u : 0u].setVisible(visible: true);
						planeVectors = _planeVectors;
						flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
						flag3 = flag2;
						continue;
					}
					return;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			throw new NullReferenceException();
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public override void InternalUpdate()
	{
		//IL_008a: Expected O, but got I4
		//IL_0093: Expected O, but got I4
		//IL_013a: Expected O, but got I
		//IL_0159: Expected O, but got I
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		base.InternalUpdate();
		if (++_frameCount < 2)
		{
			int depth = ((Equipment)this)._003COwner_003Ek__BackingField.depth;
			int sortingOrder = depth + 1;
			_muzzleFlash.sortingOrder = sortingOrder;
		}
		if (_frameCount == 2)
		{
			_muzzleFlash.enabled = false;
		}
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
				PhaserScene s_scene = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer = s_scene._renderer;
				List<float2> planeVectors = _planeVectors;
				object obj3 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v21 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				if ((nint)obj3 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v21 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
				object obj4 = 0;
				List<float2> planeVectors2 = _planeVectors;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rcx_v15 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
				object obj5 = 0;
				float num = planesOffsetX + (float)renderer.screenCenter;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ r8_v7+24+v147 @ rbx_v7*8]");
				float num2 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.Backup_PrototypeAWeapon)+1B4]");
				float y = num2 + 0f;
				float num3 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ r9_v5+20+v147 @ rbx_v7*8]");
				float x = num3 + 0f;
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

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_045a: Expected I, but got O
		//IL_0155: Expected O, but got Ref
		//IL_0425: Unknown result type (might be due to invalid IL or missing references)
		//IL_042a: Expected O, but got Unknown
		//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Expected Ref, but got Unknown
		//IL_0408: Expected F4, but got O
		//IL_0408: Expected O, but got I
		//IL_0567->IL0454: Incompatible stack heights: 6 vs 5
		//IL_0454->IL0548: Incompatible stack heights: 14 vs 6
		//IL_0412->IL0412: Incompatible stack heights: 16 vs 13
		nint num = (nint)this;
		float2 firingVector = GetFiringVector();
		object obj = default(object);
		float num2 = (float)obj * 0.01f;
		bool flag = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num3 = num2 * 12f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		bool flag2 = (object)_muzzleFlash == null;
		Transform transform = _muzzleFlash.transform;
		bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector2 ret = default(Vector2);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&ret));
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_muzzleFlash, 2f);
		_muzzleFlash.enabled = true;
		int depth = ((Equipment)this)._003COwner_003Ek__BackingField.depth;
		int sortingOrder = depth + 1;
		_muzzleFlash.sortingOrder = sortingOrder;
		if (_muzzleFlashLastRotated)
		{
		}
		bool flag4 = (object)_muzzleFlash == null;
		Transform transform2 = _muzzleFlash.transform;
		bool flag5 = (object)transform2 == null;
		transform2.localEulerAngles = (Vector3)(&ret);
		bool muzzleFlashLastRotated = !_muzzleFlashLastRotated;
		_muzzleFlashLastRotated = muzzleFlashLastRotated;
		Vector2 vector = default(Vector2);
		Projectile projectile = base.FireOneProjectile(vector, 0, _targetTransform);
		Projectile projectile2 = base.FireOneProjectile(vector, 1, _targetTransform);
		int num4 = ++_planeCounter;
		if (!_planeFiring || num4 <= 1)
		{
			return;
		}
		List<PhaserSprite> planeSprites = _planeSprites;
		_planeCounter = 0;
		bool flag6 = _planeSprites == null;
		ref float2 reference = ref *(float2*)_targetTransform;
		Transform transform3 = null;
		Transform transform4 = null;
		BulletPool pool = default(BulletPool);
		object obj2 = default(object);
		while ((nint)transform4 < planeSprites._size)
		{
			List<PhaserSprite> planeSprites2 = _planeSprites;
			bool flag7 = _planeSprites == null;
			bool flag8 = (nint)transform3 >= planeSprites2._size;
			PhaserSprite[] items = planeSprites2._items;
			bool flag9 = planeSprites2._items == null;
			bool flag10 = (nint)transform3 >= items.Length;
			bool flag11 = (object)items[(object)transform3] == null;
			Transform transform5 = items[(object)transform3].transform;
			bool flag12 = (object)transform5 == null;
			bool flag13 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out *(Vector3*)(&ret));
			Projectile projectile3 = base.FireOneProjectile(vector, 0, _targetTransform, pool);
			bool flag14 = (object)projectile3 == null;
			reference = ref *(float2*)_targetTransform;
			if (!flag14)
			{
				bool flag15 = ((UnityEngine.Object)projectile3).m_CachedPtr == (IntPtr)0;
				reference = ref *(float2*)_targetTransform;
				if (!flag15)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
					bool flag16 = obj2 == null;
					float projectileSpeed = projectile3.ProjectileSpeed;
					bool flag17 = projectile3.body == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rax_v62+18]");
					bool flag18 = (nint)0 == 0;
					reference = ref *(float2*)(projectile3.body + 112);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rax_v62+18]");
					float2 float5 = ((ArcadePhysics)0).velocityFromRotation(0f, (float)vector, ref reference);
				}
			}
			planeSprites = _planeSprites;
			transform3 = (Transform)(transform3 + 1);
			bool flag19 = _planeSprites == null;
			transform4 = transform3;
		}
	}

	public override void Cleanup()
	{
		base.Cleanup();
		if (_planeTimer != null)
		{
			_planeTimer.Cancel();
		}
		if (_planeFiringTimer != null)
		{
			_planeFiringTimer.Cancel();
		}
		if (_moveTween != null)
		{
			_moveTween.Kill();
		}
		_planeBulletPool.Cleanup();
		List<PhaserSprite>.Enumerator enumerator = default(List<PhaserSprite>.Enumerator);
		if (!enumerator.MoveNext())
		{
			return;
		}
		throw new NullReferenceException();
	}

	public Backup_PrototypeAWeapon()
	{
		//IL_002e: Expected O, but got I4
		List<PhaserSprite> planeSprites = new List<PhaserSprite>();
		_planeSprites = planeSprites;
		_planeVectors = new List<float2>();
		_playerPos = (float2)0;
		((Weapon)this)._002Ector();
	}

	private void _003CInitWeapon_003Eb__14_0()
	{
		startPlanes();
	}

	private void _003CstartPlanes_003Eb__15_0()
	{
		_planeFiring = true;
		Action onComplete = delegate
		{
			_planeFiring = false;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer planeFiringTimer = Timers.Register(2.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_planeFiringTimer = planeFiringTimer;
	}

	private void _003CstartPlanes_003Eb__15_1()
	{
		_planeFiring = false;
	}
}
