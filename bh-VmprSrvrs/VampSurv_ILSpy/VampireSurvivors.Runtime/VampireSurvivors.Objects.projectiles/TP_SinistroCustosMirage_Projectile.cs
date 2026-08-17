using System;
using System.Threading;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using Zenject;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_SinistroCustosMirage_Projectile : Projectile
{
	private MultiTargetTween _alphaTween;

	private SpriteAnimation _anim;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("Dextro_Custos_1", "ThosePeople");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0031: Expected O, but got I4
		//IL_00eb: Expected O, but got I4
		//IL_0102: Expected O, but got I4
		//IL_0161: Expected O, but got I4
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected O, but got Unknown
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Expected O, but got Unknown
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		//IL_01c7: Expected O, but got I
		//IL_02c4: Expected O, but got I
		//IL_033e: Expected I, but got O
		//IL_0351: Expected O, but got I4
		//IL_04a6: Expected O, but got I4
		//IL_04bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c2: Expected O, but got Unknown
		//IL_04ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cf: Expected I4, but got Unknown
		//IL_02ed->IL0585: Incompatible stack heights: 1 vs 2
		//IL_0594->IL0594: Incompatible stack heights: 2 vs 0
		//IL_024d->IL030a: Incompatible stack heights: 1 vs 0
		//IL_030a->IL030a: Incompatible stack heights: 2 vs 0
		base.InitProjectile(pool, weapon, index);
		if ((object)weapon != null)
		{
			float num = weapon.PArea();
			object obj = default(object);
			float xScale = (float)obj * 0.5f;
			ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
			Weapon weapon2 = _weapon;
			if ((object)_weapon != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
				{
					bool flag = !characterController._isFlipped;
					ArcadeSprite arcadeSprite2 = setFlipX(flag);
					ArcadeSprite arcadeSprite3 = setTint(4379893u);
					ArcadeSprite arcadeSprite4 = setAlpha(0f);
					bool flag2 = base.flipX;
					object obj2 = 35;
					if (!flag2)
					{
						obj2 = 55;
					}
					if (body != null)
					{
						((Weapon)(object)body).CheckArcanas();
						BaseBody baseBody = body;
						if (body != null)
						{
							baseBody._enable = true;
							bool flag3 = base.flipX;
							object obj3 = (flag3 ? 1 : 0) ^ 1;
							Vector3 euler = default(Vector3);
							Quaternion ret;
							if (index == 1)
							{
								Transform transform = base.transform;
								object obj4 = obj3 * 70;
								object obj5 = obj4 - 35;
								float num2 = (float)obj5 * ((float)Math.PI / 180f);
								Quaternion.Internal_FromEulerRad_Injected(ref euler, out ret);
								bool flag4 = (object)transform == null;
								IntPtr cachedPtr = ((UnityEngine.Object)transform).m_CachedPtr;
								bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								object obj6 = 0;
								object obj7 = ret;
								object obj8 = ret;
							}
							else
							{
								bool flag6 = index != 2;
								float num2 = 45f;
								object obj8 = obj2;
								if (flag6)
								{
									goto IL_0594;
								}
								Transform transform2 = base.transform;
								object obj9 = obj3 * 70;
								object obj10 = 35 - obj9;
								num2 = (float)obj10 * ((float)Math.PI / 180f);
								Quaternion.Internal_FromEulerRad_Injected(ref euler, out ret);
								IntPtr cachedPtr = ((UnityEngine.Object)transform2).m_CachedPtr;
								bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								object obj6 = 0;
								bool flag8 = (nint)0 != 0;
								object obj7 = ret;
								obj8 = ret;
								if (!flag8)
								{
									bool flag9 = (nint)0 == 0;
									goto IL_030a;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1060 @ rax_v82 (should have been resolved before IL gen)");
							goto IL_0594;
						}
					}
				}
			}
		}
		goto IL_04df;
		IL_0594:
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if (array != null)
		{
			if ((object)_renderer != null)
			{
				void* value = ((IntPtr*)(&array))->m_value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj11 = default(object);
				bool flag10 = obj11 == null;
			}
			goto IL_030a;
		}
		goto IL_04df;
		IL_04df:
		throw new NullReferenceException();
		IL_030a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if (tweenConfig != null)
		{
			((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
			((MonoBehaviour)(object)tweenConfig).m_CancellationTokenSource = (CancellationTokenSource)1120403456;
			((GameMonoBehaviour)(object)tweenConfig)._onPauseSent = true;
			_ = 1;
			TweenCallback signalBus = delegate
			{
				//IL_002c: Expected I, but got O
				//IL_00ac: Expected O, but got I4
				//IL_00c7: Expected I, but got O
				TweenConfig tweenConfig2 = new TweenConfig();
				object[] array2 = new object[1];
				if ((object)_renderer != null)
				{
					nint num5 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj15 = default(object);
					if (obj15 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array2;
				tweenConfig2.duration = 500f;
				tweenConfig2.ease = Ease.Linear;
				tweenConfig2.delay = 250f;
				tweenConfig2.alpha = (float?)(object)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SinistroCustosMirage_Projectile>)+370]");
				TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
				nint num6 = (nint)this;
				tweenConfig2.onComplete = onComplete;
				MultiTargetTween alphaTween2 = Tweens.Add(tweenConfig2);
				_alphaTween = alphaTween2;
			};
			((Equipment)(object)tweenConfig)._signalBus = (SignalBus)(object)signalBus;
			MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
			_alphaTween = alphaTween;
			Weapon weapon3 = _weapon;
			if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
			{
				int num3 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.Depth;
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						PhaserScene.Renderer renderer = s_scene._renderer;
						if (s_scene._renderer != null && (object)_renderer != null)
						{
							int num4 = renderer.pixelHeight >> 31;
							object obj12 = renderer.pixelHeight - num4;
							object obj13 = obj12 >> 1;
							object obj14 = obj13 - 1;
							int sortingOrder = obj14 + num3;
							_renderer.sortingOrder = sortingOrder;
							return;
						}
					}
				}
			}
		}
		goto IL_04df;
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			bool flag = TryFreeze(other);
		}
	}

	public override void Despawn()
	{
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__3_0()
	{
		//IL_002c: Expected I, but got O
		//IL_00ac: Expected O, but got I4
		//IL_00c7: Expected I, but got O
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_renderer != null)
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
		tweenConfig.duration = 500f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.delay = 250f;
		tweenConfig.alpha = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SinistroCustosMirage_Projectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
	}
}
