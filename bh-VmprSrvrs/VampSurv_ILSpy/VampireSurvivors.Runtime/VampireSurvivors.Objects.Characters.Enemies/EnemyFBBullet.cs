using System;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyFBBullet : EnemyController
{
	private float _originalScale;

	private float _lifetime = 1f;

	private const float DurationMillis = 5500f;

	private bool _isDespawning;

	private Tween _onEnterTween;

	private Tween _scaleTween;

	private Tween _onLifetimeTween;

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_036d: Expected O, but got I4
		//IL_003a: Expected I4, but got O
		//IL_007f: Invalid comparison between F4 and I4
		//IL_012c: Expected O, but got Ref
		//IL_0109: Expected F4, but got I4
		//IL_0257: Expected I, but got O
		base.InitEnemy(enemyType, asRemote);
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		EnemyData currentEnemyData = _currentEnemyData;
		_isDespawning = false;
		_lifetime = 1f;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(tint: ((object)currentEnemyData._003Ctint_003Ek__BackingField == null) ? 16777215u : ((uint)((object?)currentEnemyData._003Ctint_003Ek__BackingField >> 32)), spriteRenderer: _EnemyRenderer);
		float originalScale = _originalScale;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018768DBA7h\"");
		if (_originalScale == 0f)
		{
			EnemyData currentEnemyData2 = _currentEnemyData;
			float num = default(float);
			originalScale = (((object)currentEnemyData2._003Cscale_003Ek__BackingField == null) ? 1f : num);
			_originalScale = originalScale;
		}
		float val;
		if (_onEnterTween != null)
		{
			TweenExtensions.Restart(_onEnterTween);
			float num2 = -1f;
			val = 0f;
		}
		else
		{
			val = _originalScale;
			object obj = default(object);
			TweenerCore<Vector3, Vector3, VectorOptions> onEnterTween = ShortcutExtensions.DOScale(_cachedTransform, (Vector3)(&obj), 0.1f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 0;
				}
			}
			_onEnterTween = onEnterTween;
			float num2 = 0.1f;
			float num3 = default(float);
			originalScale = num3;
		}
		if (_onLifetimeTween != null)
		{
			TweenExtensions.Restart(_onLifetimeTween);
		}
		else
		{
			DOGetter<float> getter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter = null;
			((EnemyFBBullet)(object)dOSetter)._003CInitEnemy_003Eb__7_1(val);
			TweenerCore<float, float, FloatOptions> t = DOTween.To(getter, dOSetter, 0f, 0.1f);
			TweenerCore<float, float, FloatOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, 5.5000005f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyFBBullet>)+390]");
			TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
			nint num4 = (nint)this;
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 0;
				}
			}
			_onLifetimeTween = tweenerCore;
		}
		ArcadeSprite arcadeSprite2 = setDepth(1000);
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

	protected override void UpdateDepth()
	{
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
		//IL_0024: Invalid comparison between I4 and F4
		if (0f < (_hp -= value))
		{
			_damageKb = damageKb;
		}
		else
		{
			Die();
		}
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
			//IL_0079: Expected O, but got I
			CoherenceSync coherenceSync = _coherenceSync;
			NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
			if (coherenceSync._003CEntityState_003Ek__BackingField != null)
			{
				ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v6 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				bool flag = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v6 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				if ((nint)0 != 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v6 (Coherence.Toolkit.ObservableAuthorityType)+10]");
					object obj2 = -3;
					bool flag2 = obj2 == null;
					flag = flag2;
				}
				if (!flag)
				{
					return;
				}
			}
			Despawn();
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

	private void _003CDeathTween_003Eb__13_0()
	{
		//IL_0079: Expected O, but got I
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v6 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v6 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v6 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		Despawn();
	}
}
