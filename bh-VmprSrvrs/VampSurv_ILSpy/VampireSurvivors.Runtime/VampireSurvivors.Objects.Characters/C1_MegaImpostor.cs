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
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class C1_MegaImpostor : CharacterController
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__2_0;

		public static Predicate<Equipment> _003C_003E9__2_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CLevelUp_003Eb__2_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 176;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CLevelUp_003Eb__2_1(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 176;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass3_0
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

	private float getNewHiddenWeaponEveryLevel = 6f;

	private float improveHiddenWeaponEveryLevel = 11f;

	public override void LevelUp()
	{
		//IL_0233: Expected O, but got I4
		//IL_020f: Expected O, but got I4
		//IL_00cf: Expected O, but got I4
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected I4, but got Unknown
		//IL_0118: Invalid comparison between F4 and I4
		//IL_00c1: Expected O, but got I4
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Expected I4, but got Unknown
		//IL_0289: Expected O, but got I4
		//IL_0293: Expected O, but got I4
		//IL_05ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b1: Expected O, but got Unknown
		//IL_018c: Expected O, but got I4
		//IL_02f2: Expected I, but got O
		//IL_02fa: Expected I, but got O
		//IL_030a: Expected O, but got I
		//IL_0346: Expected O, but got I
		//IL_0383: Expected O, but got I
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_039e: Expected O, but got Unknown
		//IL_0518: Invalid comparison between F4 and I
		//IL_0538: Unknown result type (might be due to invalid IL or missing references)
		//IL_053d: Expected O, but got Unknown
		//IL_03f6: Expected I, but got O
		base.LevelUp();
		CharacterWeaponsManager weaponsManager = base._weaponsManager;
		Predicate<object> predicate = (Predicate<object>)_003C_003Ec._003C_003E9__2_0;
		if (_003C_003Ec._003C_003E9__2_0 == null)
		{
			predicate = (Predicate<object>)(_003C_003Ec._003C_003E9__2_0 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj11 = x._equipmentType - 176;
				return obj11 == null;
			});
		}
		List<object> list = ((List<object>)(object)((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField).FindAll(predicate);
		List<Equipment> list2 = ((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField.FindAll(predicate);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001875D9E00h\"");
		object obj;
		Predicate<object> match;
		List<object> list5;
		if (base._level == 0)
		{
			float num = improveHiddenWeaponEveryLevel;
			List<Equipment> list3 = ((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField.FindAll(predicate);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875D9D72h\"");
			obj = ((base._level != 0) ? ((object)0) : ((object)1));
			int num2 = (int)(base._level / getNewHiddenWeaponEveryLevel);
			List<Equipment> list4 = ((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField.FindAll(predicate);
			float num3 = (float)num2 + 1f;
			if (num3 > (float)list._size && list._size < 6)
			{
				GameManager core = GM.Core;
				bool allowDuplicates = default(bool);
				Weapon weapon = core._weaponsFacade.AddHiddenWeapon(WeaponType.C1_TONGUE1, this, removeFromStore: true, allowDuplicates);
				match = (Predicate<object>)176;
				list5 = (List<object>)(object)core._weaponsFacade;
			}
			else
			{
				match = predicate;
				list5 = (List<object>)(object)((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField;
			}
		}
		else
		{
			float num = improveHiddenWeaponEveryLevel;
			List<Equipment> list6 = ((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField.FindAll(predicate);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875D9E22h\"");
			if (base._level == 0)
			{
				obj = 1;
				match = predicate;
				list5 = (List<object>)(object)((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField;
			}
			else
			{
				obj = 0;
				match = predicate;
				list5 = (List<object>)(object)((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField;
			}
		}
		bool flag = obj == null;
		if (!flag)
		{
			int num4 = (int)(base._level / improveHiddenWeaponEveryLevel);
			List<Equipment> list7 = ((List<Equipment>)(object)list5).FindAll((Predicate<Equipment>)match);
			float num5 = (float)num4 + 1f;
			object obj2 = 0;
			object obj3 = 0;
			while (true)
			{
				object obj4 = obj3 - list._size;
				flag = obj4 == null;
				if ((nint)obj3 >= list._size)
				{
					break;
				}
				if ((nint)obj2 < list._size)
				{
					object[] items = list._items;
					object obj5 = items[obj2];
					nint num6 = (nint)typeof(Weapon);
					nint num7 = (nint)obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ r8_v16 (Il2CppClass<System.Object>)+130]");
					nint num8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
					if (num8 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ r8_v16 (Il2CppClass<System.Object>)+C8]");
						object obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v41+FFFFFFF8+v155 @ rax_v40*8]");
						if (0 == (nint)typeof(Weapon))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
							object obj8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v41+FFFFFFF8+v845 @ rcx_v30*8]");
							object obj9 = 0 - typeof(Weapon);
							bool flag2 = obj9 == null;
							bool flag3 = !flag2;
							object obj10 = null;
							if (flag3)
							{
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ r9_v17 (System.Object)+4C]");
								if (!(num5 > 0f))
								{
									goto IL_052f;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ r9_v17 (System.Object)+4C]");
							if ((nint)0 < (nint)8)
							{
								nint num9 = (nint)obj5;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v921 @ rax_v45 (Il2CppClass<System.Object>)+208] (should have been resolved before IL gen)");
							}
							goto IL_052f;
						}
					}
					throw new NullReferenceException();
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
				IL_052f:
				obj2++;
				obj3 = obj2;
			}
		}
		if (flag)
		{
			return;
		}
		CharacterWeaponsManager weaponsManager2 = base._weaponsManager;
		Predicate<object> match2 = (Predicate<object>)_003C_003Ec._003C_003E9__2_1;
		if (_003C_003Ec._003C_003E9__2_1 == null)
		{
			match2 = (Predicate<object>)(_003C_003Ec._003C_003E9__2_1 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj11 = x._equipmentType - 176;
				return obj11 == null;
			});
		}
		List<object> list8 = ((List<object>)(object)((EquipmentManager)weaponsManager2)._003CHiddenEquipment_003Ek__BackingField).FindAll(match2);
		ShowRings(list8._size);
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
			_003C_003Ec__DisplayClass3_0 obj = new _003C_003Ec__DisplayClass3_0();
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
			((UnityEngine.Object)spriteRenderer).SetName("TONGUE");
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
			((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass3_0._003CShowRings_003Eb__0);
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
			((Delegate)tweenCallback2).method = (nint)__ldftn(_003C_003Ec__DisplayClass3_0._003CShowRings_003Eb__1);
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
}
