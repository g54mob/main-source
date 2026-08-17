using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class TP_AxeArmor_Character : TP_Character
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__6_0;

		public static Predicate<Equipment> _003C_003E9__6_1;

		public static Predicate<Equipment> _003C_003E9__7_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CLevelUp_003Eb__6_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 5;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CLevelUp_003Eb__6_1(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 5;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003COnGetDamaged_003Eb__7_1(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 5;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public SpriteRenderer spr;

		public int index;

		public TweenCallback _003C_003E9__2;

		internal void _003CShowRings_003Eb__0()
		{
			spr.enabled = true;
		}

		internal void _003CShowRings_003Eb__1()
		{
			//IL_002c: Expected I, but got O
			//IL_0096: Expected I, but got O
			//IL_00fa: Expected O, but got I4
			//IL_0108: Expected O, but got I4
			//IL_0116: Expected O, but got I4
			//IL_0124: Expected O, but got I4
			//IL_0140: Expected O, but got I4
			//IL_0150: Expected O, but got I4
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[2];
			if ((object)spr != null)
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
			Transform transform = spr.transform;
			if ((object)transform != null)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 500f;
			tweenConfig.scaleX = (float?)(object)1;
			tweenConfig.scaleY = (float?)(object)1;
			tweenConfig.localX = (float?)(object)1;
			tweenConfig.localY = (float?)(object)1;
			tweenConfig.ease = Ease.InOutSine;
			tweenConfig.alpha = (float?)(object)1;
			object obj3 = index + 10;
			float delay = (float)obj3 * 100f;
			tweenConfig.delay = delay;
			TweenCallback onComplete = _003C_003E9__2;
			if (_003C_003E9__2 == null)
			{
				onComplete = (_003C_003E9__2 = delegate
				{
					SpriteRenderer spriteRenderer = spr;
					if ((object)spr != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
					{
						spr.enabled = false;
						UnityEngine.Object.Destroy(spr, 0f);
					}
				});
			}
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		}

		internal void _003CShowRings_003Eb__2()
		{
			SpriteRenderer spriteRenderer = spr;
			if ((object)spr != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
			{
				spr.enabled = false;
				UnityEngine.Object.Destroy(spr, 0f);
			}
		}
	}

	private bool _canRetaliate = true;

	private float _retaliationDelay = 1000f;

	private Timer _retaliationTimeout;

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
	}

	public override void OnAttackAnim(Weapon.FiringAnimation firingAnimation)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5CD7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (firingAnimation == Weapon.FiringAnimation.Axe)
		{
			((CharacterController)this)._isAnimForced = true;
			_currentAnimation = CharAnimationType.ranged;
			_spriteAnimation.SetAnimation("rangedA");
		}
	}

	public override void ClearFromSpecialAnims()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5CD8]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		((CharacterController)this)._isAnimForced = false;
		if (!_hasIdleAnimation)
		{
			_spriteAnimation.SetAnimation("walk");
			_currentAnimation = CharAnimationType.walk;
		}
		else
		{
			_spriteAnimation.SetAnimation("idle");
			_currentAnimation = CharAnimationType.idle;
		}
	}

	public override void LevelUp()
	{
		//IL_002f: Expected O, but got I4
		//IL_0062: Expected I4, but got O
		//IL_0070: Expected O, but got I4
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_012a: Invalid comparison between F4 and I4
		//IL_0440: Expected O, but got I4
		//IL_044a: Expected O, but got I4
		//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e6: Expected O, but got Unknown
		//IL_021d: Expected I, but got O
		//IL_0225: Expected I, but got O
		//IL_0235: Expected O, but got I
		//IL_0271: Expected O, but got I
		//IL_02ae: Expected O, but got I
		//IL_02f2: Expected O, but got I4
		//IL_02e4: Expected O, but got I4
		//IL_04bd: Invalid comparison between F4 and I
		//IL_0495: Unknown result type (might be due to invalid IL or missing references)
		//IL_049a: Expected O, but got Unknown
		//IL_0327: Expected I, but got O
		base.LevelUp();
		CharacterWeaponsManager weaponsManager = ((CharacterController)this)._weaponsManager;
		Predicate<object> predicate = (Predicate<object>)_003C_003Ec._003C_003E9__6_0;
		if (_003C_003Ec._003C_003E9__6_0 == null)
		{
			predicate = (Predicate<object>)(_003C_003Ec._003C_003E9__6_0 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj14 = x._equipmentType - 5;
				return obj14 == null;
			});
			bool flag = false;
		}
		List<object> list = ((List<object>)(object)((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField).FindAll(predicate);
		CharacterController characterController = (CharacterController)((CharacterController)this)._level;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
		object obj = (object)predicate >> 2;
		WeaponsFacade weaponsFacade = (WeaponsFacade)(obj >> 31);
		WeaponType weaponType = (WeaponType)(obj + (object)weaponsFacade);
		object obj2 = (int)weaponType * 4;
		object obj3 = weaponType + obj2;
		object obj4 = obj3 + obj3;
		bool flag2 = ((CharacterController)this)._level == (nint)obj4;
		if (flag2)
		{
			float num = (float)((CharacterController)this)._level / 10f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
			float num2 = num + 1f;
			if (num2 > (float)list._size && list._size < 6)
			{
				GameManager core = GM.Core;
				weaponsFacade = core._weaponsFacade;
				bool allowDuplicates = default(bool);
				Weapon weapon = core._weaponsFacade.AddHiddenWeapon(WeaponType.AXE, this, removeFromStore: true, allowDuplicates);
				weaponType = WeaponType.AXE;
				bool flag = true;
				characterController = this;
			}
			float num3 = (float)((CharacterController)this)._level / 10f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
			float num4 = num3 + 1f;
			object obj5 = 0;
			object obj6 = 0;
			while (true)
			{
				object obj7 = obj6 - list._size;
				flag2 = obj7 == null;
				if ((nint)obj6 >= list._size)
				{
					break;
				}
				if ((nint)obj5 < list._size)
				{
					object[] items = list._items;
					object obj8 = items[obj5];
					nint num5 = (nint)typeof(Weapon);
					nint num6 = (nint)obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r8_v17 (Il2CppClass<System.Object>)+130]");
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
					if (num7 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r8_v17 (Il2CppClass<System.Object>)+C8]");
						object obj10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v44+FFFFFFF8+v145 @ rax_v43*8]");
						if (0 == (nint)typeof(Weapon))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
							object obj11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v44+FFFFFFF8+v801 @ rcx_v32*8]");
							object obj12 = ((0 != (nint)typeof(Weapon)) ? ((object)0) : ((object)1));
							bool flag3 = obj12 == null;
							object obj13 = null;
							if (flag3)
							{
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ r9_v17 (System.Object)+4C]");
								if (num4 > 0f)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ r9_v17 (System.Object)+4C]");
									if ((nint)0 < (nint)8)
									{
										nint num8 = (nint)obj8;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v860 @ rax_v49 (Il2CppClass<System.Object>)+208] (should have been resolved before IL gen)");
									}
								}
							}
							obj5++;
							obj6 = obj5;
							continue;
						}
					}
					throw new NullReferenceException();
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
		}
		if (flag2)
		{
			return;
		}
		CharacterWeaponsManager weaponsManager2 = ((CharacterController)this)._weaponsManager;
		Predicate<object> match = (Predicate<object>)_003C_003Ec._003C_003E9__6_1;
		if (_003C_003Ec._003C_003E9__6_1 == null)
		{
			match = (Predicate<object>)(_003C_003Ec._003C_003E9__6_1 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj14 = x._equipmentType - 5;
				return obj14 == null;
			});
		}
		List<object> list2 = ((List<object>)(object)((EquipmentManager)weaponsManager2)._003CHiddenEquipment_003Ek__BackingField).FindAll(match);
		ShowRings(list2._size);
	}

	public unsafe override void OnGetDamaged(string hexColor = "#ff0000", float vulnerabilityDelay = 120f, bool playDamageFx = true, bool playWeaponDamageFx = false)
	{
		//IL_0074: Expected O, but got I4
		//IL_017a: Expected I, but got O
		//IL_0182: Expected I, but got O
		//IL_0192: Expected O, but got I
		//IL_01ce: Expected O, but got I
		//IL_020b: Expected O, but got I
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Expected O, but got Unknown
		//IL_025f: Expected I4, but got O
		if (_receivingDamage)
		{
			return;
		}
		bool flag = default(bool);
		bool flag2 = default(bool);
		OnGetDamaged(hexColor, vulnerabilityDelay, playDamageFx, flag, flag2);
		Action onComplete = delegate
		{
			_canRetaliate = true;
		};
		float duration = _retaliationDelay * 0.001f;
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer retaliationTimeout = Timers.Register(duration, onComplete, null, isLooped: false, flag, (MonoBehaviour)flag2, repeat, type, isOnlineTimer: false, canPause: false);
		_retaliationTimeout = retaliationTimeout;
		if (!_canRetaliate)
		{
			return;
		}
		CharacterWeaponsManager weaponsManager = ((CharacterController)this)._weaponsManager;
		_canRetaliate = false;
		Predicate<object> match = (Predicate<object>)_003C_003Ec._003C_003E9__7_1;
		if (_003C_003Ec._003C_003E9__7_1 == null)
		{
			match = (Predicate<object>)(_003C_003Ec._003C_003E9__7_1 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj6 = x._equipmentType - 5;
				return obj6 == null;
			});
		}
		List<object> list = ((List<object>)(object)((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField).FindAll(match);
		bool flag3 = false;
		bool flag4 = false;
		while ((flag3 ? 1 : 0) < list._size)
		{
			if ((flag4 ? 1 : 0) < list._size)
			{
				object[] items = list._items;
				object obj = items[flag4 ? 1u : 0u];
				nint num = (nint)typeof(Weapon);
				nint num2 = (nint)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ r9_v10 (Il2CppClass<System.Object>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ r9_v10 (Il2CppClass<System.Object>)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ rax_v23+FFFFFFF8+v358 @ rax_v22*8]");
					if (0 == (nint)typeof(Weapon))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ rax_v23+FFFFFFF8+v551 @ rcx_v18*8]");
						object obj5 = 0 - typeof(Weapon);
						bool flag5 = obj5 == null;
						bool flag6 = !flag5;
						bool flag7 = false;
						if (!flag6)
						{
							flag7 = (byte)(int)obj != 0;
						}
						bool value = ((bool*)(flag7 ? 1 : 0))->m_value;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v565 @ rax_v25 (System.Boolean)+4B8] (should have been resolved before IL gen)");
						flag4 = (byte)((flag4 ? 1u : 0u) + 1u) != 0;
						flag3 = flag4;
						continue;
					}
				}
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
			throw new NullReferenceException();
		}
	}

	public unsafe void ShowRings(int frames)
	{
		//IL_019f: Expected O, but got I
		//IL_01b8: Expected I, but got O
		//IL_0230: Expected I, but got O
		//IL_0242: Expected O, but got I4
		//IL_024d: Expected I, but got O
		//IL_0282: Expected O, but got I4
		//IL_064d: Expected I, but got O
		//IL_0663: Expected O, but got I
		//IL_066c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0671: Expected O, but got Unknown
		//IL_030f: Expected I, but got O
		//IL_0697: Expected O, but got I4
		//IL_06ae: Expected I, but got I8
		//IL_06cd: Expected I, but got O
		//IL_06e3: Expected O, but got I
		//IL_06ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f1: Expected O, but got Unknown
		//IL_02f8: Expected I, but got I8
		//IL_03ae: Expected I, but got O
		//IL_072e: Expected I, but got I8
		//IL_0397: Expected I, but got I8
		//IL_0473->IL03fd: Incompatible stack heights: 1 vs 0
		//IL_007a->IL03fd: Incompatible stack heights: 2 vs 0
		//IL_053b->IL03fd: Incompatible stack heights: 4 vs 0
		//IL_0595->IL03fd: Incompatible stack heights: 5 vs 0
		//IL_010d->IL03fd: Incompatible stack heights: 5 vs 0
		//IL_0178->IL03fd: Incompatible stack heights: 5 vs 0
		//IL_061e->IL03fd: Incompatible stack heights: 6 vs 0
		//IL_01dd->IL01dd: Incompatible stack heights: 7 vs 6
		//IL_063b->IL03fd: Incompatible stack heights: 7 vs 0
		//IL_03f8->IL0740: Incompatible stack heights: 7 vs 0
		//IL_03fd->IL074e: Incompatible stack heights: 7 vs 0
		if (frames <= 0)
		{
			return;
		}
		int num = 0;
		Vector2 vector = default(Vector2);
		string spriteName = default(string);
		while (true)
		{
			_003C_003Ec__DisplayClass8_0 obj = new _003C_003Ec__DisplayClass8_0();
			if ((object)this == null)
			{
				break;
			}
			bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			if ((object)transform == null)
			{
				break;
			}
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			GameObject gameObject = base.gameObject;
			SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, vector, vector, "items", spriteName);
			if ((object)spriteRenderer == null)
			{
				break;
			}
			spriteRenderer.enabled = false;
			bool flag3 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
			Renderer.set_sortingOrder_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, 2000);
			bool flag4 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr);
			Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
			CheckRenderer();
			string spriteRenderer2 = (string)(object)((ArcadeSprite)this)._spriteRenderer;
			if ((object)((ArcadeSprite)this)._spriteRenderer == null)
			{
				break;
			}
			bool flag5 = spriteRenderer2._stringLength == 0;
			IntPtr gcHandlePtr3 = Component.get_transform_Injected((IntPtr)spriteRenderer2._stringLength);
			Transform parent = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
			if ((object)transform2 == null)
			{
				break;
			}
			bool flag6 = (object)transform2.GetType() != typeof(RectTransform);
			Transform transform3 = null;
			if (!flag6)
			{
				transform3 = transform2;
			}
			if ((object)transform3 != null)
			{
				Debug.LogWarning("Parent of RectTransform is being set with parent property. Consider using the SetParent method instead, with the worldPositionStays argument set to false. This will retain local orientation and scale rather than world orientation and scale, which can prevent common UI scaling issues.", transform2);
			}
			transform2.SetParent(parent, worldPositionStays: true);
			((UnityEngine.Object)spriteRenderer).SetName("RING");
			if (obj == null)
			{
				break;
			}
			obj.index = num;
			obj.spr = spriteRenderer;
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			Transform spr = (Transform)(object)obj.spr;
			if ((object)obj.spr == null)
			{
				break;
			}
			bool flag7 = ((UnityEngine.Object)spr).m_CachedPtr == (IntPtr)0;
			IntPtr intPtr = Component.get_transform_Injected(((UnityEngine.Object)spr).m_CachedPtr);
			Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(intPtr);
			if (array == null)
			{
				break;
			}
			bool flag8 = (object)transform4 == null;
			Transform transform5 = (Transform)(nint)intPtr;
			if (!flag8)
			{
				Transform transform6 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((IntPtr)transform4);
				bool flag9 = (object)transform6 == null;
				transform5 = transform4;
			}
			bool flag10 = (nint)((SpriteRenderer)(object)array).m_SpriteChangeEvent <= 0;
			array[0] = transform4;
			if (tweenConfig == null)
			{
				break;
			}
			tweenConfig.targets = array;
			Transform transform7 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((IntPtr)transform5);
			tweenConfig.localX = (float?)(object)1;
			Transform transform8 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((IntPtr)transform5);
			tweenConfig.duration = 500f;
			tweenConfig.ease = Ease.InOutSine;
			tweenConfig.localY = (float?)(object)1;
			TweenCallback tweenCallback = null;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1807 @ r10_v3 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass8_0._003CShowRings_003Eb__0);
			((Delegate)tweenCallback).m_target = obj;
			((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1807 @ r10_v3 (Il2CppMethodInfo)+4C]");
			object obj2 = (nint)0 >> 4;
			object obj3 = obj2 & 1;
			nint num3;
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1807 @ r10_v3 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num3 = unchecked((nint)6447293664L);
					goto IL_068e;
				}
			}
			((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
			num3 = ((Delegate)tweenCallback).method_ptr;
			goto IL_068e;
			IL_068e:
			object obj4 = 24;
			((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
			tweenConfig.onStart = tweenCallback;
			TweenCallback tweenCallback2 = null;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r10_v4 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback2).method = (nint)__ldftn(_003C_003Ec__DisplayClass8_0._003CShowRings_003Eb__1);
			((Delegate)tweenCallback2).m_target = obj;
			((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r10_v4 (Il2CppMethodInfo)+4C]");
			object obj5 = (nint)0 >> 4;
			object obj6 = obj5 & 1;
			nint num5;
			if (obj6 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r10_v4 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num5 = unchecked((nint)6447293664L);
					goto IL_070e;
				}
			}
			((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
			num5 = ((Delegate)tweenCallback2).method_ptr;
			goto IL_070e;
			IL_070e:
			nint num6 = 24;
			((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
			tweenConfig.onComplete = tweenCallback2;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			num++;
			if (num >= frames)
			{
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void _003COnGetDamaged_003Eb__7_0()
	{
		_canRetaliate = true;
	}
}
