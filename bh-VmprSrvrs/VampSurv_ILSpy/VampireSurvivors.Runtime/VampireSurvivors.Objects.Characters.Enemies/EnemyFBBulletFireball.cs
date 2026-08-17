using System;
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
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyFBBulletFireball : EnemyController
{
	private float _lifetime = 1f;

	private const float DurationMillis = 5500f;

	private bool _isDespawning;

	private Tween _onEnterTween;

	private Tween _scaleTween;

	private Tween _onLifetimeTween;

	private float2 _fixedVelocity;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0045: Expected O, but got I4
		//IL_005e: Expected O, but got I4
		//IL_0082: Expected O, but got I4
		//IL_0082: Expected O, but got I4
		//IL_00e0: Expected I4, but got O
		//IL_01bd: Expected I, but got O
		base.InitEnemy(enemyType, asRemote);
		GameManager core = GM.Core;
		core.Enemies.remove(this);
		GameManager core2 = GM.Core;
		Group obj = core2.EnemiesThatIgnoreProjectiles.add(this);
		ArcadeSprite arcadeSprite = setScale(2f, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setOrigin(0f, (float?)(object)1);
		BaseBody baseBody = body.setCircle(8f, (float?)(object)1, (float?)(object)1);
		EnemyData currentEnemyData = _currentEnemyData;
		_isDespawning = false;
		_lifetime = 1f;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(tint: ((object)currentEnemyData._003Ctint_003Ek__BackingField == null) ? 16777215u : ((uint)((object?)currentEnemyData._003Ctint_003Ek__BackingField >> 32)), spriteRenderer: _EnemyRenderer);
		if (_onLifetimeTween != null)
		{
			DG.Tweening.TweenExtensions.Restart(_onLifetimeTween);
		}
		else
		{
			DOGetter<float> getter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter = null;
			((EnemyFBBulletFireball)(object)dOSetter)._003CInitEnemy_003Eb__7_1(8f);
			TweenerCore<float, float, FloatOptions> t = DOTween.To(getter, dOSetter, 0f, 0.1f);
			TweenerCore<float, float, FloatOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, 5.5000005f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyFBBulletFireball>)+390]");
			TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
			nint num = (nint)this;
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ rax_v24 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ rax_v24 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ rax_v24 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 0;
				}
			}
			_onLifetimeTween = tweenerCore;
		}
		ArcadeSprite arcadeSprite3 = setDepth(1500);
	}

	public void SetFixedVelocity(float2 velocity)
	{
		_fixedVelocity = velocity;
	}

	public override void Disappear()
	{
		if (!base._003CIsDead_003Ek__BackingField)
		{
			if (_onLifetimeTween != null)
			{
				Tween tween = DG.Tweening.TweenExtensions.Pause(_onLifetimeTween);
			}
			if (_onEnterTween != null)
			{
				Tween tween2 = DG.Tweening.TweenExtensions.Pause(_onEnterTween);
			}
			base._003CIsDead_003Ek__BackingField = true;
			DeathTween();
		}
	}

	protected override void OnUpdate()
	{
		BaseBody baseBody = body;
		baseBody._velocity = _fixedVelocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyFBBulletFireball)+294]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num = default(int);
		ArcadeSprite arcadeSprite = setDepth(num);
	}

	public override void Despawn()
	{
		if (!_isDespawning)
		{
			_isDespawning = true;
			if (_scaleTween != null)
			{
				Tween tween = DG.Tweening.TweenExtensions.Pause(_scaleTween);
			}
			if (_onEnterTween != null)
			{
				Tween tween2 = DG.Tweening.TweenExtensions.Pause(_onEnterTween);
			}
			if (_onLifetimeTween != null)
			{
				Tween tween3 = DG.Tweening.TweenExtensions.Pause(_onLifetimeTween);
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
		if (_onLifetimeTween != null)
		{
			Tween tween = DG.Tweening.TweenExtensions.Pause(_onLifetimeTween);
		}
		base._003CIsDead_003Ek__BackingField = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 47 Invalid \"Jump target not found in method: 0x18768FE70\"");
	}

	private unsafe void DeathTween()
	{
		//IL_01b9: Expected O, but got Ref
		//IL_01d8: Expected I, but got O
		if (_onLifetimeTween != null)
		{
			Tween tween = DG.Tweening.TweenExtensions.Pause(_onLifetimeTween);
		}
		Transform transform = base.transform;
		if ((object)transform == null || ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if (_scaleTween != null)
		{
			DG.Tweening.TweenExtensions.Restart(_scaleTween);
			return;
		}
		object obj = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, (Vector3)(&obj), 0.1f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyFBBulletFireball>)+3A0]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Tween tween2 = VampireSurvivors.Tools.TweenExtensions.SetGameId(tweenerCore);
		if (tween2 != null && tween2._003Cactive_003Ek__BackingField && !tween2.creationLocked)
		{
			tween2.autoKill = false;
		}
		_scaleTween = tween2;
	}

	protected override void Die()
	{
		if (!base._003CIsDead_003Ek__BackingField)
		{
			if (_onLifetimeTween != null)
			{
				Tween tween = DG.Tweening.TweenExtensions.Pause(_onLifetimeTween);
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
