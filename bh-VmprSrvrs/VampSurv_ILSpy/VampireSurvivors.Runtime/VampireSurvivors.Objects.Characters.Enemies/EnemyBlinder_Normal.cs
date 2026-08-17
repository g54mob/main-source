using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyBlinder_Normal : EnemyController
{
	private bool _done;

	private float _sineF = 1f;

	private Tween _onEnterTween;

	private Sequence _onSineTween;

	private GameObject _spritte;

	private SpriteRenderer _ringSprite;

	private Action _003COnDefeat_003Ek__BackingField;

	public Action OnDefeat
	{
		get
		{
			return _003COnDefeat_003Ek__BackingField;
		}
		set
		{
			_003COnDefeat_003Ek__BackingField = value;
		}
	}

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_06c4: Expected O, but got Ref
		//IL_04b5: Expected I4, but got I8
		//IL_065a->IL05b3: Incompatible stack heights: 1 vs 0
		//IL_01ec->IL05b3: Incompatible stack heights: 1 vs 0
		//IL_06f8->IL05b3: Incompatible stack heights: 1 vs 0
		base.InitEnemy(enemyType, asRemote);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(_EnemyRenderer, 13421823u);
		SpriteRenderer ringSprite = _ringSprite;
		if ((object)_ringSprite != null && ((UnityEngine.Object)ringSprite).m_CachedPtr != (IntPtr)0)
		{
			goto IL_0116;
		}
		object cachedTransform = _cachedTransform;
		Vector3 ret = default(Vector3);
		if ((object)_cachedTransform != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rbx_v20 (System.Object)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rbx_v20 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out ret);
				GameObject gameObject = base.gameObject;
				Vector2 pos = default(Vector2);
				SpriteRenderer component = RenderingExtensions.AddSprite(gameObject, pos, "vfx", "sPFX_ring_64");
				SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(component, 0f);
				Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
				if ((object)spriteRenderer2 != null)
				{
					((Renderer)spriteRenderer2).SetMaterial(material);
					_ringSprite = spriteRenderer2;
					goto IL_0116;
				}
			}
			else
			{
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_cachedTransform);
			}
		}
		goto IL_05b3;
		IL_0116:
		Transform cachedTransform2 = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
		Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref ret);
		Vector3 vector = default(Vector3);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, (Vector3)(&vector), 0.3f);
		TweenCallback tweenCallback = delegate
		{
			Transform cachedTransform3 = _cachedTransform;
			bool flag2 = ((UnityEngine.Object)cachedTransform3).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform3).m_CachedPtr, ref value);
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v950 @ rax_v32 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (tweenerCore != null)
		{
			_onEnterTween = tweenerCore;
			EnemyData currentEnemyData = _currentEnemyData;
			if (_currentEnemyData != null)
			{
				_defaultSpeed = currentEnemyData._003Cspeed_003Ek__BackingField;
				SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(_EnemyRenderer, 0.8f);
				_sineF = 1f;
				base._003CIsCullable_003Ek__BackingField = false;
				base._003CIsTeleportOnCull_003Ek__BackingField = true;
				if (_onSineTween != null)
				{
					TweenExtensions.Restart(_onSineTween);
					return;
				}
				Sequence onSineTween = DOTween.Sequence();
				_onSineTween = onSineTween;
				DOGetter<float> getter = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
				DOSetter<float> dOSetter = null;
				((EnemyBlinder_Normal)(object)dOSetter)._003CInitEnemy_003Eb__10_2(0.8f);
				TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter, dOSetter, 0.1f, 2f);
				if (tweenerCore2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1407 @ rax_v51 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 4;
						_ = 0;
					}
				}
				if (TweenSettingsExtensions.ValidateAddToSequence(_onSineTween, (Tween)tweenerCore2, false))
				{
					Sequence sequence = Sequence.DoInsert(_onSineTween, (Tween)tweenerCore2, 0f);
				}
				TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleSprite.DOFade(_EnemyRenderer, 0.6f, 2f);
				if (tweenerCore3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1501 @ rax_v55 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 4;
						_ = 0;
					}
				}
				if (TweenSettingsExtensions.ValidateAddToSequence(_onSineTween, (Tween)tweenerCore3, false))
				{
					Sequence sequence2 = Sequence.DoInsert(_onSineTween, (Tween)tweenerCore3, 0f);
				}
				Sequence onSineTween2 = _onSineTween;
				if (_onSineTween != null && ((Tween)onSineTween2)._003Cactive_003Ek__BackingField && !((Tween)onSineTween2).creationLocked)
				{
					((Tween)onSineTween2).loops = -1;
					((Tween)onSineTween2).loopType = LoopType.Yoyo;
					if (((ABSSequentiable)onSineTween2).tweenType == TweenType.Tweener)
					{
						((Tween)onSineTween2).fullDuration = 1f / 0f;
					}
				}
				Sequence onSineTween3 = _onSineTween;
				if (_onSineTween != null && ((Tween)onSineTween3)._003Cactive_003Ek__BackingField && !((Tween)onSineTween3).creationLocked)
				{
					((Tween)onSineTween3).autoKill = false;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if (_onSineTween != null)
				{
					return;
				}
			}
		}
		goto IL_05b3;
		IL_05b3:
		throw new NullReferenceException();
	}

	public override void Disappear()
	{
		if (_onSineTween != null)
		{
			Sequence sequence = TweenExtensions.Pause(_onSineTween);
		}
		_sineF = -2f;
		base._003CIsCullable_003Ek__BackingField = true;
		base._003CIsTeleportOnCull_003Ek__BackingField = false;
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float val = default(float);
		((EnemyBlinder_Normal)(object)dOSetter)._003CDisappear_003Eb__11_1(val);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, -10f, 2f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
	}

	public override void Despawn()
	{
		base.Despawn();
		GameObject spritte = _spritte;
		if ((object)_spritte != null && ((UnityEngine.Object)spritte).m_CachedPtr != (IntPtr)0)
		{
			_spritte.SetActive(value: false);
		}
	}

	protected override void OnUpdate()
	{
		//IL_0106: Expected O, but got I4
		//IL_0237: Expected O, but got I4
		float num = _sineF * _defaultSpeed;
		base._003CSpeed_003Ek__BackingField = num;
		base.OnUpdate();
		if (_done)
		{
			return;
		}
		PlayerOptionsData config = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		PlayerOptionsData config2 = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
		object obj2 = default(object);
		if (obj2 == null)
		{
			return;
		}
		GameObject spritte = _spritte;
		if ((object)_spritte == null || ((UnityEngine.Object)spritte).m_CachedPtr == (IntPtr)0)
		{
			SpawnSpritte();
		}
		_spritte.SetActive(value: true);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.PAN, soundConfig, 20000f, 1, time);
		if (GM.Core.CheckValidToastieInputs())
		{
			_done = true;
			PlayerOptionsData config3 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
			object obj3 = default(object);
			if (obj3 == null)
			{
				_playerOptions.UnlockCharacter(CharacterType.PANINI);
				_playerOptions.RevealCharacter(CharacterType.PANINI);
				_playerOptions.BuyCharacter(CharacterType.PANINI);
				_playerOptions.Save();
				PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
				SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
				soundConfig2.Volume = (float?)(object)1;
				soundConfig2.Delay = -1000f;
				soundConfig2.Rate = 0.5f;
				PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.ThingFound, soundConfig2, 0f, 10, time);
			}
		}
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		object obj = default(object);
		if ((nint)obj != 24)
		{
			object obj2 = obj - 25;
			if ((nint)obj2 <= 49)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"bt r9,rax\"");
				if ((nint)obj2 < 49)
				{
					goto IL_0113;
				}
			}
			if ((nint)obj != 1612 && (nint)obj != 92)
			{
				float num = default(float);
				if ((nint)obj == 76)
				{
					num *= 10f;
				}
				else if (obj == null)
				{
					num *= 0.1f;
				}
				base.GetDamaged(num, showHitVfx, damageKb, damageType, hasKb);
				return;
			}
		}
		goto IL_0113;
		IL_0113:
		Die();
	}

	private unsafe void SpawnSpritte()
	{
		//IL_0051: Expected O, but got I4
		//IL_006d: Expected O, but got I4
		//IL_0095: Expected O, but got Ref
		PhaserScene s_scene = ArcadePhysics.s_scene;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.sprite(s_scene.add, pos, "enemies2023", "uExdash_01");
		PhaserSprite phaserSprite2 = phaserSprite.setOrigin(0.5f, (float?)(object)0);
		PhaserSprite phaserSprite3 = phaserSprite2.setScale(4f, (float?)(object)0);
		Transform transform = phaserSprite3.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		PhaserSprite phaserSprite4 = RenderingExtensions.SetScrollFactor(phaserSprite3, 0f);
		PhaserSprite phaserSprite5 = phaserSprite4.setDepth(3300);
		PhaserSprite phaserSprite6 = phaserSprite5.setAlpha(0.8f);
		GameObject gameObject = phaserSprite6.gameObject;
		((UnityEngine.Object)gameObject).SetName("spritte");
		GameObject spritte = phaserSprite6.gameObject;
		_spritte = spritte;
		_spritte.SetActive(value: false);
	}

	protected unsafe override void Die()
	{
		//IL_0242: Expected O, but got I4
		//IL_0272: Expected O, but got Ref
		//IL_011c: Expected O, but got I4
		//IL_012b: Expected O, but got I4
		//IL_02bb: Expected O, but got I4
		//IL_00d6: Expected O, but got I
		base.Die();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Deathscream, soundConfig, 150f, 2, time);
		Transform target = _ringSprite.transform;
		Vector3 vector = Vector3.oneVector;
		object obj = default(object);
		float num = (float)obj * 16f;
		Vector3 vector2 = default(Vector3);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, (Vector3)(&vector2), 0.3f);
		nint num3;
		object obj2;
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						vector = (Vector3)(num2 + 0);
					}
					TweenCallback tweenCallback = delegate
					{
						_ringSprite.enabled = false;
					};
					tweenCallback2 = tweenCallback;
					num3 = 0;
					obj2 = 0;
					goto IL_0141;
				}
			}
		}
		TweenCallback tweenCallback3 = delegate
		{
			_ringSprite.enabled = false;
		};
		bool flag = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		num3 = 0;
		obj2 = 0;
		nint num4 = 0;
		object obj3 = 0;
		Vector3 vector3 = vector;
		if (!flag)
		{
			goto IL_0141;
		}
		goto IL_01a0;
		IL_0141:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		bool flag2 = (nint)0 == 0;
		num4 = num3;
		obj3 = obj2;
		vector3 = vector;
		if (!flag2)
		{
			num4 = num3;
			obj3 = obj2;
			vector3 = vector;
		}
		goto IL_01a0;
		IL_01a0:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Action action = _003COnDefeat_003Ek__BackingField;
		if (_003COnDefeat_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v498.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		_003COnDefeat_003Ek__BackingField = null;
	}

	private void _003CInitEnemy_003Eb__10_0()
	{
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
	}

	private float _003CInitEnemy_003Eb__10_1()
	{
		return _sineF;
	}

	private void _003CInitEnemy_003Eb__10_2(float val)
	{
		_sineF = val;
	}

	private float _003CDisappear_003Eb__11_0()
	{
		return _sineF;
	}

	private void _003CDisappear_003Eb__11_1(float val)
	{
		_sineF = val;
	}

	private void _003CDie_003Eb__16_0()
	{
		_ringSprite.enabled = false;
	}
}
