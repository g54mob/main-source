using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Events;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Diamond3_Projectile : Projectile
{
	private TrailRenderer _Trail;

	private Timer _expireTimer;

	private float _saveVelX;

	private float _saveVelY;

	private readonly List<int> _targetAngles;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("Diamond2", "items");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT = Bounce;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6950");
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0086: Expected O, but got I4
		//IL_0086: Expected O, but got I4
		//IL_03f5: Expected O, but got I4
		//IL_0271: Expected F4, but got I4
		//IL_030d->IL0276: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		if (base.body != null)
		{
			BaseBody baseBody = base.body.setCircle(8f, (float?)(object)0, (float?)(object)0);
			_speed = 1.1f;
			Transform targetTransform = base.AimForRandomEnemy();
			_targetTransform = targetTransform;
			SetScaleToArea();
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 1f);
			setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
			if ((object)weapon != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null && base.body != null)
				{
					Body body = base.body.setBoundsRectangle(characterController._worldBoxCollider);
					BaseBody baseBody2 = base.body;
					if (base.body != null)
					{
						baseBody2._onWorldBounds = true;
						if (_expireTimer != null)
						{
							_expireTimer.Cancel();
						}
						if ((object)_weapon != null)
						{
							float num = _weapon.PDuration();
							Action onComplete = FadeOutAndDispose;
							object obj = default(object);
							float duration = (float)obj * 0.001f;
							bool flag = default(bool);
							MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
							int repeat = default(int);
							TimerType type = default(TimerType);
							Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
							_expireTimer = expireTimer;
							SetupTrails();
							Weapon targetTransform2 = (Weapon)(object)_targetTransform;
							if ((object)_targetTransform != null)
							{
								bool flag2 = ((UnityEngine.Object)targetTransform2).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)targetTransform2).m_CachedPtr, out Vector3 ret);
								Weapon cachedTransform = (Weapon)(object)_cachedTransform;
								if ((object)_cachedTransform != null)
								{
									bool flag3 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret2);
									object obj2 = ret - ret2;
									object obj4 = default(object);
									object obj5 = default(object);
									object obj3 = obj4 - obj5;
									Weapon cachedTransform2 = (Weapon)(object)_cachedTransform;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
									Quaternion.Internal_FromEulerRad_Injected(ref ret, out Quaternion _);
									bool flag4 = (object)_cachedTransform == null;
									bool flag5 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
									Transform.set_rotation_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref *(Quaternion*)(&ret2));
									SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
									{
										Rate = 1f,
										Volume = (float?)(object)1
									};
									float detune = (float)_indexInWeapon * -100f;
									soundConfig.Detune = detune;
									PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.MagicMissile, soundConfig, 200f, 10, flag ? 1 : 0);
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

	public override void SetTarget(Transform target)
	{
		//IL_0022: Expected I, but got O
		//IL_002a: Expected I, but got O
		//IL_003a: Expected O, but got I
		//IL_00ba: Expected O, but got I4
		//IL_0076: Expected O, but got I
		//IL_00ac: Expected O, but got I4
		//IL_01ae: Expected F4, but got O
		_targetTransform = target;
		Weapon weapon = _weapon;
		nint num = (nint)typeof(TP_Diamond3_Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Diamond3_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Diamond3_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v42+FFFFFFF8+v113 @ rax_v15*8]");
			if (0 == (nint)typeof(TP_Diamond3_Weapon))
			{
				obj3 = 1;
				goto IL_0148;
			}
		}
		obj3 = 0;
		goto IL_0148;
		IL_0148:
		bool flag = obj3 == null;
		Weapon weapon2 = null;
		if (!flag)
		{
			weapon2 = weapon;
		}
		float num4 = _indexInWeapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rax_v18 (VampireSurvivors.Objects.Weapons.Weapon)+158]");
		float rotation = num4 * 0f;
		float projectileSpeed = base.ProjectileSpeed;
		float speed = default(float);
		Vector2 vector = SetVelocityFromRotation(rotation, speed);
		BaseBody baseBody = body;
		Transform transform = base.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		Vector3 axis = default(Vector3);
		Quaternion.AngleAxis_Injected((float)this, ref axis, out Quaternion _);
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	public override void InternalUpdate()
	{
		//IL_003c: Expected O, but got I4
		//IL_0098: Expected F4, but got O
		//IL_00e6: Expected F4, but got I
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		int num = renderer.pixelHeight >> 31;
		object obj = renderer.pixelHeight - num;
		object obj2 = obj >> 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int sortingOrder = default(int);
		_renderer.sortingOrder = sortingOrder;
		_Trail.sortingOrder = sortingOrder;
		BaseBody baseBody = body;
		float saveVelX = (float)baseBody._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001872EEAC5h\"");
		if ((object)baseBody._velocity == null)
		{
			saveVelX = _saveVelX;
		}
		_saveVelX = saveVelX;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v15 (BaseBody)+74]");
		float saveVelY = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001872EEAE6h\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v15 (BaseBody)+74]");
		if ((nint)0 == 0)
		{
			saveVelY = _saveVelY;
		}
		_saveVelY = saveVelY;
	}

	private void Bounce(Body b, bool up, bool down, bool left, bool right)
	{
		if (b == body)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	private void SetupTrails()
	{
		//IL_0389->IL0305: Incompatible stack heights: 1 vs 0
		//IL_03d8->IL0305: Incompatible stack heights: 1 vs 0
		//IL_020a->IL0305: Incompatible stack heights: 3 vs 0
		//IL_02dc->IL0305: Incompatible stack heights: 7 vs 0
		float saturationMax = default(float);
		float valueMin = default(float);
		float valueMax = default(float);
		float alphaMin = default(float);
		Color color = UnityEngine.Random.ColorHSV(0f, 1f, 0.35f, saturationMax, valueMin, valueMax, alphaMin, 0.35f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		if ((object)_weapon != null)
		{
			float num = _weapon.PArea();
			if ((object)_Trail != null)
			{
				_Trail.time = 1f;
				float num2 = 0.8f * 0.015f;
				if ((object)_Trail != null)
				{
					_Trail.endWidth = num2;
					_Trail.startWidth = num2;
					Sprite sprite = default(Sprite);
					RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_Trail, sprite, true);
					if ((object)_Trail != null)
					{
						Material material = ((Renderer)_Trail).GetMaterial();
						RenderingExtensions.SetAlpha(material, 1f);
						Sprite trail = (Sprite)(object)_Trail;
						if ((object)_Trail != null)
						{
							bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
							TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
							if ((object)_Trail != null)
							{
								_Trail.emitting = true;
								Gradient gradient = new Gradient();
								IntPtr ptr = Gradient.Init();
								gradient.m_Ptr = ptr;
								gradient.m_RequiresNativeCleanup = true;
								GradientColorKey[] array = new GradientColorKey[2];
								if (array != null)
								{
									bool flag2 = array.Length <= 0;
									_ = color.r;
									_ = 0;
									bool flag3 = array.Length <= 1;
									_ = color.r;
									_ = 1f;
									GradientAlphaKey[] array2 = new GradientAlphaKey[4];
									if (array2 != null)
									{
										bool flag4 = array2.Length <= 0;
										_ = 1061997773;
										bool flag5 = array2.Length <= 1;
										_ = 1061997773;
										_ = 1056964608;
										bool flag6 = array2.Length <= 2;
										_ = 1056964608;
										_ = 1056964608;
										bool flag7 = array2.Length <= 3;
										_ = 1036831949;
										_ = 1065353216;
										gradient.SetKeys(array, array2);
										if ((object)_Trail != null)
										{
											_Trail.colorGradient = gradient;
											TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_Trail);
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
		throw new NullReferenceException();
	}

	private void FadeOutAndDispose()
	{
		//IL_0148: Expected I, but got O
		Material material = ((Renderer)_Trail).GetMaterial();
		TweenerCore<Color, Color, ColorOptions> tweenerCore = ShortcutExtensions.DOFade(material, 0f, 0.1f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(_renderer, 0f, 0.1f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Diamond3_Projectile>)+370]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Weapon weapon = _weapon;
		if (weapon._explodeOnExpire)
		{
			float2 pos = base.position;
			Projectile projectile = weapon.SpawnExplosionAt(pos, 0, 1, 0f);
		}
	}

	public override void Despawn()
	{
		TrailRenderer trail = _Trail;
		bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
		TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
		_Trail.emitting = false;
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T14_JEWELS))
		{
			bool flag = TryFreeze(other);
		}
	}

	public TP_Diamond3_Projectile()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0445: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_046d: Expected O, but got I
		//IL_015a: Expected O, but got I
		//IL_013f: Expected I4, but got I8
		//IL_0495: Expected O, but got I
		//IL_01c8: Expected O, but got I
		//IL_04bd: Expected O, but got I
		//IL_0236: Expected O, but got I
		//IL_021b: Expected I4, but got I8
		//IL_04e5: Expected O, but got I
		//IL_02a4: Expected O, but got I
		//IL_050d: Expected O, but got I
		//IL_0312: Expected O, but got I
		//IL_02f7: Expected I4, but got I8
		//IL_0535: Expected O, but got I
		//IL_0380: Expected O, but got I
		//IL_055d: Expected O, but got I
		//IL_03ee: Expected O, but got I
		//IL_03d3: Expected I4, but got I8
		List<int> list = new List<int>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(10);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 10;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(-10);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 4294967286L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(20);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 20;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			list.AddWithResize(-20);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 4294967276L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			list.AddWithResize(30);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 30;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v16+18]");
		if (num7 >= 0)
		{
			list.AddWithResize(-30);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 4294967266L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdx_v18+18]");
		if (num8 >= 0)
		{
			list.AddWithResize(40);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 40;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v20+18]");
		if (num9 >= 0)
		{
			list.AddWithResize(-40);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 4294967256L;
		}
		_targetAngles = list;
		base._002Ector();
	}
}
