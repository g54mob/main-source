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

public class TP_SacredBeast1_Turtle_Projectile : Projectile
{
	private TrailRenderer _Trail;

	private Timer _expireTimer;

	private float _saveVelX;

	private float _saveVelY;

	private readonly List<int> _targetAngles;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("Turtle", "ThosePeople");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT = Bounce;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6950");
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0086: Expected O, but got I4
		//IL_0086: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		//IL_01e6: Expected F4, but got I4
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		BaseBody baseBody = base.body.setCircle(8f, (float?)(object)0, (float?)(object)0);
		_speed = 1.1f;
		Transform targetTransform = base.AimForRandomEnemy(rotate: false);
		_targetTransform = targetTransform;
		SetScaleToArea(0.8f);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 1f);
		setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		Body body = base.body.setBoundsRectangle(characterController._worldBoxCollider);
		BaseBody baseBody2 = base.body;
		baseBody2._onWorldBounds = true;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
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
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Detune = detune;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.MagicMissile, soundConfig, 200f, 10, flag ? 1 : 0);
	}

	public override void SetTarget(Transform target)
	{
		//IL_009c: Expected O, but got I
		_targetTransform = target;
		Weapon weapon = _weapon;
		Transform playerTransform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
		float num = AngleFromTargetRadians(_targetTransform, playerTransform);
		List<int> targetAngles = _targetAngles;
		int indexInWeapon = _indexInWeapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v9 (System.Collections.Generic.List`1<System.Int32>)+18]");
		int num2 = (int)((nint)indexInWeapon % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v9 (System.Collections.Generic.List`1<System.Int32>)+18]");
		if ((nint)num2 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v9 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj = 0;
			float projectileSpeed = base.ProjectileSpeed;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v6+20+v138 @ rdx_v8 (System.Int32)*4]");
			float num3 = 0f * ((float)Math.PI / 180f);
			float rotation = num3 + num;
			Vector2 vector = SetVelocityFromRotation(rotation, num);
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
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
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187155AC5h\"");
		if ((object)baseBody._velocity == null)
		{
			saveVelX = _saveVelX;
		}
		_saveVelX = saveVelX;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v15 (BaseBody)+74]");
		float saveVelY = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187155AE6h\"");
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SacredBeast1_Turtle_Projectile>)+370]");
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

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		//IL_0050: Expected O, but got I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_00e7: Expected O, but got I8
		//IL_0209: Expected O, but got I4
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_00b6: Expected O, but got I4
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00cc: Expected O, but got I4
		//IL_0168: Expected O, but got I8
		//IL_0137: Expected O, but got I4
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_014d: Expected O, but got I4
		//IL_018e: Expected O, but got F4
		int num = tile._data & 8;
		bool flag = num == 0;
		bool flag2 = num < 0;
		bool flag3 = !flag2;
		object obj = !flag;
		object obj2 = flag3 & obj;
		object obj5;
		if (obj2 == null)
		{
			int num2 = tile._data & 4;
			bool flag4 = num2 == 0;
			bool flag5 = num2 < 0;
			bool flag6 = !flag5;
			object obj3 = !flag6;
			object obj4 = obj3 | flag4;
			obj5 = 1;
			if (obj4 != null)
			{
				goto IL_01a3;
			}
		}
		obj5 = 4294967295L;
		goto IL_01a3;
		IL_0224:
		object obj6;
		float saveVelY = (float)obj6 * _saveVelY;
		_saveVelY = saveVelY;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)_saveVelX;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		return;
		IL_01a3:
		float saveVelX = (float)obj5 * _saveVelX;
		_saveVelX = saveVelX;
		int num3 = tile._data & 1;
		bool flag7 = num3 == 0;
		bool flag8 = num3 < 0;
		bool flag9 = !flag8;
		object obj7 = !flag7;
		object obj8 = flag9 & obj7;
		if (obj8 == null)
		{
			int num4 = tile._data & 2;
			bool flag10 = num4 == 0;
			bool flag11 = num4 < 0;
			bool flag12 = !flag11;
			object obj9 = !flag12;
			object obj10 = obj9 | flag10;
			obj6 = 1;
			if (obj10 != null)
			{
				goto IL_0224;
			}
		}
		obj6 = 4294967295L;
		goto IL_0224;
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

	public TP_SacredBeast1_Turtle_Projectile()
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
