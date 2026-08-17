using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyFBBulletEyeLaser : EnemyController
{
	private float _lifetime = 1f;

	private const float DurationMillis = 5500f;

	private bool _isDespawning;

	private Tween _onEnterTween;

	private Tween _scaleTween;

	private Tween _onLifetimeTween;

	private float _directionTimer;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0045: Expected O, but got I4
		//IL_005e: Expected O, but got I4
		//IL_0082: Expected O, but got I4
		//IL_0082: Expected O, but got I4
		//IL_0113: Expected I4, but got O
		//IL_01f0: Expected I, but got O
		base.InitEnemy(enemyType, asRemote);
		GameManager core = GM.Core;
		core.Enemies.remove(this);
		GameManager core2 = GM.Core;
		Group obj = core2.EnemiesThatIgnoreProjectiles.add(this);
		ArcadeSprite arcadeSprite = setScale(2f, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setOrigin(0.5f, (float?)(object)1);
		BaseBody baseBody = body.setCircle(8f, (float?)(object)1, (float?)(object)1);
		_isDespawning = false;
		_lifetime = 1f;
		CheckRenderer();
		SpriteTrail component = ((ArcadeSprite)this)._spriteRenderer.GetComponent<SpriteTrail>();
		component.Reset();
		EnemyData currentEnemyData = _currentEnemyData;
		_directionTimer = -0.001f;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(tint: ((object)currentEnemyData._003Ctint_003Ek__BackingField == null) ? 16777215u : ((uint)((object?)currentEnemyData._003Ctint_003Ek__BackingField >> 32)), spriteRenderer: _EnemyRenderer);
		if (_onLifetimeTween != null)
		{
			TweenExtensions.Restart(_onLifetimeTween);
		}
		else
		{
			DOGetter<float> getter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter = null;
			((EnemyFBBulletEyeLaser)(object)dOSetter)._003CInitEnemy_003Eb__7_1(8f);
			TweenerCore<float, float, FloatOptions> t = DOTween.To(getter, dOSetter, 0f, 0.1f);
			TweenerCore<float, float, FloatOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, 5.5000005f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyFBBulletEyeLaser>)+390]");
			TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
			nint num = (nint)this;
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v449 @ rax_v27 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v449 @ rax_v27 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v449 @ rax_v27 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 0;
				}
			}
			_onLifetimeTween = tweenerCore;
		}
		ArcadeSprite arcadeSprite3 = setDepth(1000);
	}

	public override void Disappear()
	{
		if (!base._003CIsDead_003Ek__BackingField)
		{
			if (_onLifetimeTween != null)
			{
				Tween tween = TweenExtensions.Pause(_onLifetimeTween);
			}
			if (_onEnterTween != null)
			{
				Tween tween2 = TweenExtensions.Pause(_onEnterTween);
			}
			base._003CIsDead_003Ek__BackingField = true;
			DeathTween();
		}
	}

	protected unsafe override void OnUpdate()
	{
		//IL_0413: Invalid comparison between I4 and F4
		//IL_0049: Invalid comparison between F4 and I4
		//IL_0072: Expected O, but got I4
		//IL_0480: Invalid comparison between F4 and I4
		//IL_04a9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_027f: Expected O, but got I4
		//IL_0288: Expected O, but got I4
		//IL_028d: Expected I, but got O
		//IL_053a: Invalid comparison between F4 and I4
		//IL_0563: Expected O, but got I4
		//IL_02b6: Expected O, but got I4
		//IL_02b6: Expected O, but got I4
		//IL_02f8: Expected I, but got O
		//IL_00c6: Expected O, but got I4
		//IL_00c6: Expected O, but got I4
		//IL_033b: Expected O, but got I4
		//IL_034c: Expected O, but got I4
		//IL_03d0: Expected O, but got Ref
		//IL_011c: Expected I, but got O
		//IL_04e5: Expected O, but got I4
		//IL_04f6: Expected O, but got I4
		//IL_0143: Expected O, but got I4
		//IL_0154: Expected O, but got I4
		//IL_0162: Expected I, but got O
		//IL_05e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ea: Expected O, but got Unknown
		//IL_01fb: Expected O, but got F4
		//IL_0232: Expected O, but got I4
		//IL_023a: Expected O, but got Ref
		//IL_0243: Expected O, but got I4
		//IL_0248: Expected I, but got O
		//IL_024d->IL0504: Incompatible stack heights: 2 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num = default(int);
		ArcadeSprite arcadeSprite = setDepth(num);
		object obj;
		if (0f > _directionTimer)
		{
			obj = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
			bool flag = 0.8f < _directionTimer;
			float num2 = 0.8f - _directionTimer;
			bool flag2 = num2 == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			obj = flag4 & flag3;
		}
		float deltaTime = PauseSystem.DeltaTime;
		float num3 = (_directionTimer = deltaTime + _directionTimer);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		bool flag5 = 0.8f < num3;
		float num4 = 0.8f - num3;
		bool flag6 = num4 == 0f;
		bool flag7 = !flag5;
		bool flag8 = !flag6;
		object obj2 = flag8 & flag7;
		float ret2 = default(float);
		if (obj2 != null && obj == null)
		{
			ArcadeSprite arcadeSprite2 = setTint(16777215u);
			BaseBody baseBody = body.setCircle(4f, (float?)(object)1, (float?)(object)1);
			Sprite sprite = SpriteManager.GetSprite("PrismC", "vfx");
			ArcadeSprite arcadeSprite3 = setFrame(sprite);
			Transform targetTransform = base._targetTransform;
			nint num5 = (nint)typeof(UnityEngine.Object);
			bool flag9 = (object)base._targetTransform == null;
			object obj3 = 0;
			Sprite sprite2 = sprite;
			object obj4 = 0;
			if (!flag9)
			{
				bool flag10 = ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0;
				obj3 = 0;
				sprite2 = sprite;
				obj4 = 0;
				num5 = (nint)typeof(UnityEngine.Object);
				if (!flag10)
				{
					Transform targetTransform2 = base._targetTransform;
					bool flag11 = ((UnityEngine.Object)targetTransform2).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)targetTransform2).m_CachedPtr, out Vector3 ret);
					Transform transform = base.transform;
					bool flag12 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret2));
					object obj5 = ret - ret2;
					object obj7 = default(object);
					object obj8 = default(object);
					object obj6 = obj7 - obj8;
					float num6 = UnityEngine.Random.Range(-0.5f, 0.5f);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
					float num7 = num6 + (float)obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					BaseBody baseBody2 = body;
					float num8 = num7 * base._003CSpeed_003Ek__BackingField;
					float num9 = num7 * base._003CSpeed_003Ek__BackingField;
					float num10 = num8 * 0.01f;
					float num11 = num9 * 0.01f;
					baseBody2._velocity = (float2)num10;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
					float num12 = num11 * 57.29578f;
					base.angle = num12;
					obj3 = 0;
					sprite2 = (Sprite)(&ret2);
					obj4 = 0;
					num5 = (nint)this;
				}
			}
		}
		else
		{
			object obj9 = obj2 ^ 1;
			object obj10 = obj & obj9;
			bool flag13 = obj10 == null;
			Sprite sprite2 = (Sprite)num;
			object obj4 = 0;
			nint num5 = unchecked((nint)null);
			if (!flag13)
			{
				BaseBody baseBody3 = body.setCircle(6f, (float?)(object)1, (float?)(object)1);
				Sprite sprite3 = SpriteManager.GetSprite("_phaser", "vfx");
				ArcadeSprite arcadeSprite4 = setFrame(sprite3);
				nint num13 = (nint)typeof(float2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ rax_v32 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
				num5 = 0;
				BaseBody baseBody4 = body;
				baseBody4._velocity = float2.zero;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rcx_v5 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
				_ = 0;
				object obj3 = 0;
				sprite2 = sprite3;
				obj4 = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		bool flag14 = _directionTimer < 0.05f;
		float num14 = _directionTimer - 0.05f;
		bool flag15 = num14 == 0f;
		bool flag16 = !flag14;
		bool flag17 = !flag15;
		object obj11 = flag17 & flag16;
		CheckRenderer();
		SpriteTrail component = ((ArcadeSprite)this)._spriteRenderer.GetComponent<SpriteTrail>();
		if (obj11 != null)
		{
			if (obj11 == null)
			{
				goto IL_064d;
			}
			if (obj11 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 323 ConditionalJump @-1, v791 @ ZF_v34 (System.Boolean) --- -1 Nop");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 399 ConditionalJump @-1, v885 @ ZF_v42 (System.Boolean) --- -1 Nop");
				/*Error: End of method reached without returning.*/;
			}
		}
		int num15 = 0;
		int num16 = 0;
		goto IL_064d;
		IL_064d:
		while (true)
		{
			int num17;
			if (component._ghosts == null)
			{
				num17 = 0;
			}
			else
			{
				List<SpriteRenderer> ghosts = component._ghosts;
				num17 = ghosts._size;
			}
			if (num15 < num17)
			{
				SpriteTrail spriteTrail = component.SetTint(num16, (Color)(&ret2));
				num16++;
				num15 = num16;
				continue;
			}
			break;
		}
	}

	public override void Despawn()
	{
		if (!_isDespawning)
		{
			_isDespawning = true;
			if (_scaleTween != null)
			{
				Tween tween = TweenExtensions.Pause(_scaleTween);
			}
			if (_onEnterTween != null)
			{
				Tween tween2 = TweenExtensions.Pause(_onEnterTween);
			}
			if (_onLifetimeTween != null)
			{
				Tween tween3 = TweenExtensions.Pause(_onLifetimeTween);
			}
			GameManager core = GM.Core;
			core.EnemiesThatIgnoreProjectiles.remove(this);
			base.Despawn();
		}
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
	}

	public override void OnPlayerOverlap(CharacterController player)
	{
		base.OnPlayerOverlap(player);
		if (!base._003CIsDead_003Ek__BackingField)
		{
			if (_onLifetimeTween != null)
			{
				Tween tween = TweenExtensions.Pause(_onLifetimeTween);
			}
			base._003CIsDead_003Ek__BackingField = true;
			DeathTween();
		}
	}

	private unsafe void DeathTween()
	{
		//IL_0169: Expected O, but got Ref
		//IL_0188: Expected I, but got O
		if (_onLifetimeTween != null)
		{
			Tween tween = TweenExtensions.Pause(_onLifetimeTween);
		}
		if (_scaleTween != null)
		{
			TweenExtensions.Restart(_scaleTween);
			return;
		}
		object obj = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, (Vector3)(&obj), 0.1f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyFBBulletEyeLaser>)+3A0]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
			if ((nint)0 == 0)
			{
				_ = 0;
			}
		}
		_scaleTween = tweenerCore;
	}

	protected override void Die()
	{
		if (!base._003CIsDead_003Ek__BackingField)
		{
			if (_onLifetimeTween != null)
			{
				Tween tween = TweenExtensions.Pause(_onLifetimeTween);
			}
			base._003CIsDead_003Ek__BackingField = true;
			DeathTween();
		}
	}

	private float _003CInitEnemy_003Eb__7_0()
	{
		return _lifetime;
	}

	private void _003CInitEnemy_003Eb__7_1(float val)
	{
		_lifetime = val;
	}
}
