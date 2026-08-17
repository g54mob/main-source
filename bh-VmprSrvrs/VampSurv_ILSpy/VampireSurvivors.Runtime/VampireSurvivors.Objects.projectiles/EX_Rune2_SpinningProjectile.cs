using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EX_Rune2_SpinningProjectile : Projectile
{
	private Timer _hitBoxTimer;

	private Timer _expireTimer;

	public Transform _toFollow;

	private bool _alreadyRecycled;

	private List<PhaserSprite> magicCircles;

	private float _angle1;

	private float _angle2;

	private float _angle3;

	protected override void Awake()
	{
		//IL_0072: Expected O, but got I4
		//IL_008a: Expected I4, but got I8
		//IL_00a2: Expected O, but got I4
		//IL_00c4: Expected O, but got I4
		//IL_0120: Expected I4, but got I8
		//IL_014e: Expected O, but got I4
		//IL_021e: Expected O, but got I
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Expected O, but got Unknown
		//IL_02f0->IL0346: Incompatible stack heights: 2 vs 0
		//IL_0340->IL03c5: Incompatible stack heights: 2 vs 0
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("blur128", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		ArcadeSprite arcadeSprite2 = setTint(16777215u);
		ArcadeSprite arcadeSprite3 = setAlpha(0.15f);
		ArcadeSprite arcadeSprite4 = setVisible(visible: true);
		ArcadeSprite arcadeSprite5 = setScale(0.5f, (float?)(object)0);
		ArcadeSprite arcadeSprite6 = setDepth(-1996);
		_isCullable = false;
		float? num = (float?)(object)0;
		while (true)
		{
			GameObject gameObject = base.gameObject;
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, (Vector2)0, "vfx", "MagicCircleRed");
			if ((object)phaserSprite == null)
			{
				break;
			}
			PhaserSprite phaserSprite2 = phaserSprite.setBlendMode(BlendMode.Add);
			PhaserSprite phaserSprite3 = phaserSprite.setAlpha(0.35f);
			PhaserSprite phaserSprite4 = phaserSprite.setDepth(-1995);
			PhaserSprite phaserSprite5 = phaserSprite.setVisible(visible: true);
			PhaserSprite phaserSprite6 = phaserSprite.setScale(0.75f, (float?)(object)0);
			PhaserSprite phaserSprite7 = phaserSprite.setTintFill(isEnabled: true, 16777215u);
			List<object> list = (List<object>)(object)magicCircles;
			if (magicCircles == null)
			{
				break;
			}
			int version = list._version + 1;
			list._version = version;
			object[] items = list._items;
			if (list._items == null)
			{
				break;
			}
			if (list._size >= items.Length)
			{
				((List<object>)(object)magicCircles).AddWithResize((object)phaserSprite);
				PhaserSprite phaserSprite8 = (PhaserSprite)0;
			}
			else
			{
				int num2 = list._size + 1;
				list._size = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				PhaserSprite phaserSprite8 = phaserSprite;
			}
			CheckRenderer();
			string spriteRenderer = (string)(object)((ArcadeSprite)this)._spriteRenderer;
			if ((object)((ArcadeSprite)this)._spriteRenderer == null)
			{
				break;
			}
			bool flag = spriteRenderer._stringLength == 0;
			IEnumerable<object> materialArray_Injected = Renderer.GetMaterialArray_Injected((IntPtr)spriteRenderer._stringLength);
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rsi_v8 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			bool flag2 = materialArray_Injected == null;
			List<object> materials = new List<object>(materialArray_Injected);
			if ((object)phaserSprite._spriteRenderer == null)
			{
				break;
			}
			phaserSprite._spriteRenderer.SetMaterials((List<Material>)(object)materials);
			((UnityEngine.Object)phaserSprite).SetName("MagicCircleRed White");
			num = (float?)(object)((_003F?)num + 1);
			if ((nint)num < 3)
			{
				continue;
			}
			return;
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_003f: Expected O, but got I4
		//IL_003f: Expected O, but got I4
		//IL_0053: Expected O, but got I4
		//IL_0119: Expected I4, but got I8
		base.InitProjectile(pool, weapon, index);
		if (!_alreadyRecycled)
		{
			ArcadeSprite arcadeSprite = setVisible(visible: true);
			_alreadyRecycled = true;
			BaseBody baseBody = body.setCircle(64f, (float?)(object)1, (float?)(object)1);
			ArcadeSprite arcadeSprite2 = setScale(0.5f, (float?)(object)0);
			_targetTransform = null;
			if (_hitBoxTimer != null)
			{
				_hitBoxTimer.Cancel();
			}
			float hitBoxDelay = weapon.HitBoxDelay;
			Action onComplete = delegate
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			};
			float duration = hitBoxDelay * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer hitBoxTimer = Timers.Register(duration, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_hitBoxTimer = hitBoxTimer;
			ArcadeSprite arcadeSprite3 = setDepth(-1996);
		}
	}

	public void SetObjectToFollow(Transform toFollow)
	{
		_toFollow = toFollow;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_0352: Expected O, but got Ref
		//IL_0438: Unknown result type (might be due to invalid IL or missing references)
		//IL_043d: Expected O, but got Unknown
		//IL_0450: Unknown result type (might be due to invalid IL or missing references)
		//IL_0455: Expected O, but got Unknown
		//IL_02da: Expected O, but got Ref
		//IL_0262: Expected O, but got Ref
		//IL_019a->IL0390: Incompatible stack heights: 1 vs 0
		//IL_0419->IL0069: Incompatible stack heights: 1 vs 0
		//IL_0309->IL0390: Incompatible stack heights: 1 vs 0
		//IL_033d->IL0390: Incompatible stack heights: 1 vs 0
		//IL_0291->IL0390: Incompatible stack heights: 1 vs 0
		//IL_02c5->IL0390: Incompatible stack heights: 1 vs 0
		//IL_046f->IL0390: Incompatible stack heights: 1 vs 0
		//IL_0219->IL0390: Incompatible stack heights: 1 vs 0
		//IL_024d->IL0390: Incompatible stack heights: 1 vs 0
		//IL_0490->IL0495: Incompatible stack heights: 1 vs 0
		//IL_0495->IL038f: Incompatible stack heights: 1 vs 0
		ArcadeSprite arcadeSprite = setAlpha(0.8f);
		Transform toFollow = _toFollow;
		float2 ret;
		float2 float5 = default(float2);
		if ((object)_toFollow != null && ((UnityEngine.Object)toFollow).m_CachedPtr != (IntPtr)0)
		{
			Transform toFollow2 = _toFollow;
			if ((object)_toFollow == null)
			{
				goto IL_0390;
			}
			bool flag = ((UnityEngine.Object)toFollow2).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)toFollow2).m_CachedPtr, out *(Vector3*)(&ret));
			base.position = float5;
		}
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		List<PhaserSprite> list = magicCircles;
		float num2 = num * 2.1618f;
		float num3 = num * 1.6181f;
		float angle = num2 + _angle2;
		float angle2 = num + _angle1;
		float angle3 = num3 + _angle3;
		_angle2 = angle;
		_angle1 = angle2;
		_angle3 = angle3;
		if (magicCircles != null)
		{
			if (list._size <= 0)
			{
				return;
			}
			Transform transform = null;
			Transform transform2 = null;
			while (true)
			{
				List<PhaserSprite> list2 = magicCircles;
				if (magicCircles == null)
				{
					break;
				}
				bool flag2 = (nint)transform2 >= list2._size;
				PhaserSprite[] items = list2._items;
				if (list2._items == null)
				{
					break;
				}
				bool flag3 = (object)transform == null;
				if (flag3)
				{
					goto IL_02e8;
				}
				object obj = transform - 1;
				Transform transform3;
				Vector3 axis;
				float num4;
				if (!flag3)
				{
					if ((nint)obj != 1)
					{
						goto IL_02e8;
					}
					if ((object)items[(object)transform2] == null)
					{
						break;
					}
					transform3 = items[(object)transform2].transform;
					if ((object)transform3 == null)
					{
						break;
					}
					ret = float5;
					axis = (Vector3)(&ret);
					num4 = 2.4f;
				}
				else
				{
					if ((object)items[(object)transform2] == null)
					{
						break;
					}
					transform3 = items[(object)transform2].transform;
					if ((object)transform3 == null)
					{
						break;
					}
					float2 float6 = float5;
					axis = (Vector3)(&float6);
					num4 = 2.2f;
				}
				goto IL_0419;
				IL_0419:
				transform3.Rotate(axis, num4, Space.Self);
				Transform transform4 = (Transform)(transform + 1);
				List<PhaserSprite> list3 = magicCircles;
				transform2 = (Transform)(transform2 + 1);
				if (magicCircles == null)
				{
					break;
				}
				bool flag4 = (nint)transform4 > 2;
				transform = null;
				if (!flag4)
				{
					transform = transform4;
				}
				if ((nint)transform2 >= list3._size)
				{
					return;
				}
				continue;
				IL_02e8:
				if ((object)items[(object)transform2] == null)
				{
					break;
				}
				transform3 = items[(object)transform2].transform;
				if ((object)transform3 == null)
				{
					break;
				}
				float2 float7 = float5;
				axis = (Vector3)(&float7);
				num4 = 2f;
				goto IL_0419;
			}
		}
		goto IL_0390;
		IL_0390:
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		base.Despawn();
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if (_hitBoxTimer != null)
		{
			_hitBoxTimer.Cancel();
		}
	}

	public EX_Rune2_SpinningProjectile()
	{
		List<PhaserSprite> list = new List<PhaserSprite>();
		magicCircles = list;
		base._002Ector();
	}

	private void _003CInitProjectile_003Eb__9_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
