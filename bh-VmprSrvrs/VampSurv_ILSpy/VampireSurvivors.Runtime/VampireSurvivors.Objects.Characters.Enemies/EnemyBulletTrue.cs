using System;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyBulletTrue : EnemyController
{
	private float _lifetime = 1f;

	private float _myAngle;

	private bool _isDespawning;

	private Tween _onEnterTween;

	private Tween _scaleTween;

	private Tween _onLifetimeTween;

	private const float DurationMillis = 5500f;

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0285: Expected O, but got I4
		//IL_02cc: Expected O, but got I4
		//IL_003a: Expected I4, but got O
		//IL_0303: Expected O, but got Ref
		//IL_0074: Expected O, but got I4
		//IL_0370: Expected O, but got I4
		//IL_017f: Expected I, but got O
		base.InitEnemy(enemyType, asRemote);
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		EnemyData currentEnemyData = _currentEnemyData;
		_isDespawning = false;
		_lifetime = 1f;
		uint tint = (((object)currentEnemyData._003Ctint_003Ek__BackingField == null) ? 16777215u : ((uint)((object?)currentEnemyData._003Ctint_003Ek__BackingField >> 32)));
		ArcadeSprite arcadeSprite2 = setTint(tint);
		ArcadeSprite arcadeSprite3 = setOrigin(0.5f, (float?)(object)0);
		if (_onEnterTween != null)
		{
			TweenExtensions.Restart(_onEnterTween);
			float num = -1f;
			object obj = 0;
		}
		else
		{
			object obj2 = default(object);
			TweenerCore<Vector3, Vector3, VectorOptions> onEnterTween = ShortcutExtensions.DOScale(_cachedTransform, (Vector3)(&obj2), 0.1f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rax_v42 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rax_v42 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 0;
				}
			}
			_onEnterTween = onEnterTween;
			float num = 0.1f;
			object obj = 0;
		}
		if (_onLifetimeTween != null)
		{
			TweenExtensions.Restart(_onLifetimeTween);
			return;
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((EnemyBulletTrue)(object)dOSetter)._003CInitEnemy_003Eb__7_1(0.5f);
		TweenerCore<float, float, FloatOptions> t = DOTween.To(getter, dOSetter, 0f, 0.1f);
		TweenerCore<float, float, FloatOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, 5.5000005f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyBulletTrue>)+390]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v553 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v553 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v553 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
			if ((nint)0 == 0)
			{
				_ = 0;
			}
		}
		_onLifetimeTween = tweenerCore;
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
			_deathStyle = EnemyDeathStyle.Disappear;
			DeathTween();
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
			base.Despawn();
		}
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
	}

	public override void OnPlayerOverlap(CharacterController player)
	{
		base.OnPlayerOverlap(player);
		Die();
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		ArcadeSprite arcadeSprite = setFlipX(flipX: false);
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		object cachedTransform = _cachedTransform;
		float myAngle = num + _myAngle;
		_myAngle = myAngle;
		Vector3 axis = default(Vector3);
		Quaternion.AngleAxis_Injected(0f, ref axis, out Quaternion _);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rdi_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rdi_v1 (System.Object)+10]");
		Quaternion value = default(Quaternion);
		Transform.set_localRotation_Injected((IntPtr)0, ref value);
	}

	protected override void ProcessWiggle()
	{
	}

	private unsafe void DeathTween()
	{
		//IL_0169: Expected O, but got Ref
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
		TweenCallback tweenCallback = delegate
		{
			CoherenceSync coherenceSync = _coherenceSync;
			if ((object)_coherenceSync == null || ((UnityEngine.Object)coherenceSync).m_CachedPtr == (IntPtr)0 || _coherenceSync.HasStateAuthority)
			{
				Despawn();
			}
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
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
			_deathStyle = EnemyDeathStyle.Die;
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

	private void _003CDeathTween_003Eb__14_0()
	{
		CoherenceSync coherenceSync = _coherenceSync;
		if ((object)_coherenceSync == null || ((UnityEngine.Object)coherenceSync).m_CachedPtr == (IntPtr)0 || _coherenceSync.HasStateAuthority)
		{
			Despawn();
		}
	}
}
