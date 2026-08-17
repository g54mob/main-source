using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Items;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyBlinder : EnemyController
{
	private bool _hasLostTreasure;

	private bool _done;

	private float _sineF = 1f;

	private Sequence _onSineTween;

	private GameObject _spritte;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_02d4: Expected I4, but got I8
		base.InitEnemy(enemyType, asRemote);
		EnemyData currentEnemyData = _currentEnemyData;
		_defaultSpeed = currentEnemyData._003Cspeed_003Ek__BackingField;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_EnemyRenderer, 0.8f);
		bool flag = _onSineTween == null;
		_sineF = 1f;
		base._003CIsCullable_003Ek__BackingField = false;
		base._003CIsTeleportOnCull_003Ek__BackingField = true;
		_hasLostTreasure = false;
		if (!flag)
		{
			TweenExtensions.Restart(_onSineTween);
			return;
		}
		Sequence onSineTween = DOTween.Sequence();
		_onSineTween = onSineTween;
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((EnemyBlinder)(object)dOSetter)._003CInitEnemy_003Eb__5_1(0.8f);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 0.1f, 2f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 4;
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(_onSineTween, (Tween)tweenerCore, false))
		{
			Sequence sequence = Sequence.DoInsert(_onSineTween, (Tween)tweenerCore, 0f);
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(_EnemyRenderer, 0.6f, 2f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 4;
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(_onSineTween, (Tween)tweenerCore2, false))
		{
			Sequence sequence2 = Sequence.DoInsert(_onSineTween, (Tween)tweenerCore2, 0f);
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
		Sequence onSineTween4 = _onSineTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		onSineTween4.stringId = "DefaultGameTweenId";
	}

	public void MulSpeed(float factor)
	{
		EnemyData currentEnemyData = _currentEnemyData;
		float defaultSpeed = factor * currentEnemyData._003Cspeed_003Ek__BackingField;
		_defaultSpeed = defaultSpeed;
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
		float x = default(float);
		((EnemyBlinder)(object)dOSetter)._003CDisappear_003Eb__7_1(x);
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
		//IL_0128: Expected O, but got I4
		//IL_0259: Expected O, but got I4
		float num = _sineF * _defaultSpeed;
		base._003CSpeed_003Ek__BackingField = num;
		base.OnUpdate();
		if (!_hasLostTreasure || _done)
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
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0440->IL0440: Incompatible stack heights: 1 vs 0
		//IL_0251->IL0422: Incompatible stack heights: 0 vs 1
		WeaponType damageType2 = default(WeaponType);
		bool hasKb2 = default(bool);
		bool isRemote;
		Treasure treasure2;
		Vector2 pos;
		Vector2 vector2 = default(Vector2);
		GameManager core2;
		if (!_hasLostTreasure)
		{
			object obj = default(object);
			if ((nint)obj != 24)
			{
				object obj2 = obj - 25;
				if ((nint)obj2 <= 49)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"bt rdx,rax\"");
					if ((nint)obj2 < 49)
					{
						goto IL_0251;
					}
				}
				if ((nint)obj == 1612 || (nint)obj == 92 || (nint)obj == 134)
				{
					goto IL_0251;
				}
				if ((nint)obj != 35)
				{
					base.GetDamaged(value, showHitVfx, damageKb, damageType2, hasKb2);
					return;
				}
				Disappear();
				_hasLostTreasure = true;
				Treasure treasure = new Treasure();
				List<float> list = new List<float>();
				list.Add(3f);
				list.Add(10f);
				list.Add(100f);
				treasure.chances = list;
				List<PrizeType?> list2 = new List<PrizeType?>();
				((List<float>)(object)list2).Add(100f);
				((List<float>)(object)list2).Add(100f);
				((List<float>)(object)list2).Add(100f);
				((List<float>)(object)list2).Add(100f);
				((List<float>)(object)list2).Add(100f);
				treasure.prizeTypes = list2;
				GameManager core = GM.Core;
				int num = core._stage.SetTreasureLevelFromChance(treasure);
				Vector3 vector = _cachedTransform.position;
				isRemote = false;
				treasure2 = treasure;
				pos = vector2;
				core2 = GM.Core;
				goto IL_0422;
			}
			Disappear();
			return;
		}
		base.GetDamaged(value, showHitVfx, damageKb, damageType2, hasKb2);
		return;
		IL_0422:
		TreasureChest treasureChest = core2.MakeTreasure(pos, treasure2, isRemote);
		return;
		IL_0251:
		Disappear();
		_hasLostTreasure = true;
		Treasure treasure3 = new Treasure();
		List<float> list3 = new List<float>();
		list3.Add(6f);
		list3.Add(66f);
		list3.Add(100f);
		treasure3.chances = list3;
		List<PrizeType?> list4 = new List<PrizeType?>();
		((List<float>)(object)list4).Add(100f);
		((List<float>)(object)list4).Add(100f);
		((List<float>)(object)list4).Add(100f);
		((List<float>)(object)list4).Add(100f);
		((List<float>)(object)list4).Add(100f);
		treasure3.prizeTypes = list4;
		GameManager core3 = GM.Core;
		int num2 = core3._stage.SetTreasureLevelFromChance(treasure3);
		object cachedTransform = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rbx_v6 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rbx_v6 (System.Object)+10]");
		Transform.get_position_Injected((IntPtr)0, out Vector3 _);
		isRemote = false;
		treasure2 = treasure3;
		pos = vector2;
		core2 = GM.Core;
		goto IL_0422;
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

	private float _003CInitEnemy_003Eb__5_0()
	{
		return _sineF;
	}

	private void _003CInitEnemy_003Eb__5_1(float val)
	{
		_sineF = val;
	}

	private float _003CDisappear_003Eb__7_0()
	{
		return _sineF;
	}

	private void _003CDisappear_003Eb__7_1(float x)
	{
		_sineF = x;
	}
}
