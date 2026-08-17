using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_RulerSword_Weapon_Sprite : PhaserSprite
{
	private PhaserSprite _phaserSprite;

	public TP_RulerSword_Weapon Weapon;

	private Tween _scaleTween;

	private List<Projectile> bodies;

	public Vector2 offset_Idle;

	public Vector2 offset_Attack;

	private bool _isAttacking;

	public unsafe void Initialize(TP_RulerSword_Weapon _weapon, int hitBoxesAmount)
	{
		//IL_0215: Expected O, but got I4
		//IL_01a1: Expected O, but got I4
		//IL_047e: Expected O, but got Ref
		//IL_0294->IL01fe: Incompatible stack heights: 1 vs 0
		//IL_018c->IL041d: Incompatible stack heights: 10 vs 0
		//IL_0191->IL0191: Incompatible stack heights: 10 vs 0
		float2 float5 = default(float2);
		Vector3 value = default(Vector3);
		object obj = default(object);
		float2 value2 = default(float2);
		while (true)
		{
			PhaserSprite phaserSprite = setOrigin(0.5f, (float?)(object)1);
			PhaserSprite phaserSprite2 = setDepth(2);
			Weapon = _weapon;
			if (hitBoxesAmount > 0)
			{
				int num = 0;
				while (true)
				{
					TP_RulerSword_Weapon weapon = Weapon;
					Projectile projectile = ((Weapon)weapon)._projectilePool.SpawnAt(float5, Weapon, num);
					bool flag = ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)projectile).m_CachedPtr);
					Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					if (((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0)
					{
						break;
					}
					IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
					Transform parent = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
					transform.SetParent(parent, worldPositionStays: true);
					bool flag2 = ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr3 = Component.get_transform_Injected(((UnityEngine.Object)projectile).m_CachedPtr);
					Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
					bool flag3 = (object)transform2 == null;
					bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
					bool flag5 = ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr4 = Component.get_transform_Injected(((UnityEngine.Object)projectile).m_CachedPtr);
					Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr4);
					bool flag6 = (object)transform3 == null;
					bool flag7 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					Transform.get_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 _);
					float num2 = (float)num * 0.2f;
					float num3 = -0.2f - num2;
					float num4 = (float)obj + num3;
					bool flag8 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)(&value2));
					List<object> list = (List<object>)(object)bodies;
					bool flag9 = bodies == null;
					int version = list._version + 1;
					list._version = version;
					object[] items = list._items;
					bool flag10 = list._items == null;
					if (list._size >= items.Length)
					{
						((List<object>)(object)bodies).AddWithResize((object)projectile);
					}
					else
					{
						int size = list._size + 1;
						list._size = size;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					num++;
					bool flag11 = num < hitBoxesAmount;
					value2 = float5;
					if (flag11)
					{
						continue;
					}
					goto IL_0191;
				}
				goto IL_01fe;
			}
			goto IL_0191;
			IL_0191:
			PhaserSprite phaserSprite3 = setScale(0f, (float?)(object)0);
			if (_scaleTween != null)
			{
				TweenExtensions.Kill(_scaleTween);
			}
			if (((UnityEngine.Object)this).m_CachedPtr != (IntPtr)0)
			{
				break;
			}
			goto IL_01fe;
			IL_01fe:
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(this);
		}
		IntPtr gcHandlePtr5 = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
		Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr5);
		TweenerCore<Vector3, Vector3, VectorOptions> scaleTween = ShortcutExtensions.DOScale(target, (Vector3)(&value2), 0.2f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_scaleTween = scaleTween;
	}

	public void Disable()
	{
		//IL_000e: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		PhaserSprite phaserSprite = setVisible(visible: false);
		List<Projectile> list = bodies;
		object obj = 0;
		List<Projectile> list2 = bodies;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj < list._size)
			{
				if ((nint)obj2 >= list2._size)
				{
					break;
				}
				Projectile[] items = list2._items;
				Projectile projectile = items[obj2];
				BaseBody body = projectile.body;
				obj2++;
				body._enable = false;
				list2 = bodies;
				obj = obj2;
				list = bodies;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public unsafe void Enable()
	{
		//IL_0149: Expected O, but got I4
		//IL_017e: Expected O, but got Ref
		//IL_0052: Expected O, but got I4
		//IL_005b: Expected O, but got I4
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		PhaserSprite phaserSprite = setVisible(visible: true);
		PhaserSprite phaserSprite2 = setScale(0f, (float?)(object)0);
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		Transform target = base.transform;
		object obj = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> scaleTween = ShortcutExtensions.DOScale(target, (Vector3)(&obj), 0.5f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_scaleTween = scaleTween;
		List<Projectile> list = bodies;
		float? num = (float?)(object)0;
		float? num2 = (float?)(object)0;
		while (true)
		{
			if ((nint)num2 < list._size)
			{
				List<Projectile> list2 = bodies;
				if ((nint)num >= list2._size)
				{
					break;
				}
				Projectile[] items = list2._items;
				Projectile projectile = items[(object)num];
				BaseBody body = projectile.body;
				num = (float?)(object)((_003F?)num + 1);
				body._enable = true;
				list = bodies;
				num2 = num;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public unsafe void Attack()
	{
		//IL_0020: Expected O, but got I4
		//IL_0099: Expected O, but got Ref
		//IL_02c5: Expected O, but got Ref
		//IL_0224: Expected O, but got I
		if (_isAttacking)
		{
			return;
		}
		_isAttacking = true;
		PhaserSprite phaserSprite = setScale(1f, (float?)(object)0);
		Sequence sequence = DOTween.Sequence();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		sequence.stringId = "DefaultGameTweenId";
		Transform target = base.transform;
		object obj = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOLocalMove(target, (Vector3)(&obj), 0.1f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 3;
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)tweenerCore, ((Tween)sequence).duration);
		}
		Transform target2 = base.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target2, 2f, 0.1f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 2;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						object obj2 = num + 0;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 2;
					_ = 0;
				}
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore2, false))
		{
			Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)tweenerCore2, ((Tween)sequence).duration);
		}
		Sequence sequence4 = TweenSettingsExtensions.AppendInterval(sequence, 0.4f);
		Transform target3 = base.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOLocalMove(target3, (Vector3)(&obj), 0.4f);
		if (tweenerCore3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v22 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		TweenCallback onComplete;
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence4, (Tween)tweenerCore3, false))
		{
			Sequence sequence5 = Sequence.DoInsert(sequence4, (Tween)tweenerCore3, ((Tween)sequence4).duration);
			TweenCallback tweenCallback = delegate
			{
				_isAttacking = false;
			};
			onComplete = tweenCallback;
		}
		else
		{
			TweenCallback tweenCallback2 = delegate
			{
				_isAttacking = false;
			};
			bool flag = sequence4 == null;
			onComplete = tweenCallback2;
			if (flag)
			{
				return;
			}
		}
		if (((Tween)sequence4)._003Cactive_003Ek__BackingField)
		{
			sequence4.onComplete = onComplete;
		}
	}

	public TP_RulerSword_Weapon_Sprite()
	{
		List<Projectile> list = new List<Projectile>();
		bodies = list;
		((GameMonoBehaviour)this)._onResumeSent = true;
	}

	private void _003CAttack_003Eb__10_0()
	{
		_isAttacking = false;
	}
}
