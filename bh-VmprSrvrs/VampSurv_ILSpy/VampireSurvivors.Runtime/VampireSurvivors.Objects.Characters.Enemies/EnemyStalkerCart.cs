using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Items;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyStalkerCart : EnemyController
{
	protected float2 _CartOffset;

	private bool _hasLostTreasure;

	private bool _done;

	private float _sineF;

	private Sequence _onSineTween;

	private GameObject _spritte;

	private PhaserSprite _frontSprite;

	private PhaserSprite _backSprite;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0082: Expected O, but got I4
		//IL_00dd: Expected O, but got I4
		//IL_0371: Expected I4, but got I8
		base.InitEnemy(enemyType, asRemote);
		EnemyData currentEnemyData = _currentEnemyData;
		PhaserSprite frontSprite = _frontSprite;
		_defaultSpeed = currentEnemyData._003Cspeed_003Ek__BackingField;
		string text;
		if ((object)_frontSprite != null)
		{
			bool flag = ((UnityEngine.Object)frontSprite).m_CachedPtr != (IntPtr)0;
			text = null;
			if (flag)
			{
				goto IL_0125;
			}
		}
		PhaserWorld instance = PhaserWorld.Instance;
		PhaserSprite frontSprite2 = instance.AddPhaserSprite((Vector2)0, "enemies2023", "CarloCartFront");
		_frontSprite = frontSprite2;
		GameObject gameObject = _frontSprite.gameObject;
		((UnityEngine.Object)gameObject).SetName("_frontCartSprite");
		PhaserWorld instance2 = PhaserWorld.Instance;
		PhaserSprite backSprite = instance2.AddPhaserSprite((Vector2)0, "enemies2023", "CarloCartBack");
		_backSprite = backSprite;
		GameObject gameObject2 = _backSprite.gameObject;
		((UnityEngine.Object)gameObject2).SetName("_backCartSprite");
		text = "CarloCartBack";
		goto IL_0125;
		IL_0125:
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(_EnemyRenderer, 13421823u);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_EnemyRenderer, 0.8f);
		_sineF = 1f;
		base._003CIsCullable_003Ek__BackingField = false;
		base._003CIsTeleportOnCull_003Ek__BackingField = true;
		_hasLostTreasure = false;
		PhaserSprite phaserSprite = _frontSprite.setVisible(visible: true);
		PhaserSprite phaserSprite2 = _backSprite.setVisible(visible: true);
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
		((EnemyStalkerCart)(object)dOSetter)._003CInitEnemy_003Eb__8_1(0.8f);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 0.1f, 2f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v762 @ rax_v24 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
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
		((EnemyStalkerCart)(object)dOSetter)._003CDisappear_003Eb__10_1(x);
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
		PhaserSprite frontSprite = _frontSprite;
		if ((object)_frontSprite != null && ((UnityEngine.Object)frontSprite).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite = _frontSprite.setVisible(visible: false);
		}
		PhaserSprite backSprite = _backSprite;
		if ((object)_backSprite != null && ((UnityEngine.Object)backSprite).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite2 = _backSprite.setVisible(visible: false);
		}
	}

	protected override void OnUpdate()
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_01f6: Expected O, but got I4
		//IL_0327: Expected O, but got I4
		float num = _sineF * _defaultSpeed;
		base._003CSpeed_003Ek__BackingField = num;
		base.OnUpdate();
		float2 float5 = base.position;
		float2 float6 = default(float2);
		PhaserSprite phaserSprite = _frontSprite.setPosition(float6);
		int num2 = base.depth;
		int num3 = num2 + 1;
		PhaserSprite phaserSprite2 = _frontSprite.setDepth(num3);
		float2 float7 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyStalkerCart)+274]");
		object obj2 = default(object);
		object obj = obj2 + 0;
		PhaserSprite phaserSprite3 = _backSprite.setPosition(float6);
		int num4 = base.depth;
		int num5 = num4 - 1;
		PhaserSprite phaserSprite4 = _backSprite.setDepth(num5);
		if (!_hasLostTreasure || _done)
		{
			return;
		}
		PlayerOptionsData config = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
		object obj3 = default(object);
		if (obj3 != null)
		{
			return;
		}
		PlayerOptionsData config2 = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
		object obj4 = default(object);
		if (obj4 == null)
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
			object obj5 = default(object);
			if (obj5 == null)
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
		//IL_0401->IL0401: Incompatible stack heights: 1 vs 0
		//IL_0235->IL03e3: Incompatible stack heights: 0 vs 1
		if (_hasLostTreasure)
		{
			return;
		}
		object obj = default(object);
		bool isRemote;
		Treasure treasure2;
		Vector2 pos;
		Vector2 vector2 = default(Vector2);
		GameManager core2;
		if ((nint)obj != 24)
		{
			object obj2 = obj - 25;
			if ((nint)obj2 <= 49)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"bt rdx,rax\"");
				if ((nint)obj2 < 49)
				{
					goto IL_0235;
				}
			}
			if ((nint)obj == 1612 || (nint)obj == 92)
			{
				goto IL_0235;
			}
			if ((nint)obj == 35 || (nint)obj == 208)
			{
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
				goto IL_03e3;
			}
			return;
		}
		Disappear();
		return;
		IL_0235:
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ rbx_v7 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ rbx_v7 (System.Object)+10]");
		Transform.get_position_Injected((IntPtr)0, out Vector3 _);
		isRemote = false;
		treasure2 = treasure3;
		pos = vector2;
		core2 = GM.Core;
		goto IL_03e3;
		IL_03e3:
		TreasureChest treasureChest = core2.MakeTreasure(pos, treasure2, isRemote);
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

	public EnemyStalkerCart()
	{
		//IL_0017: Expected O, but got I4
		_CartOffset = (float2)0;
		_ = 1034147594;
		_sineF = 1f;
		base._002Ector();
	}

	private float _003CInitEnemy_003Eb__8_0()
	{
		return _sineF;
	}

	private void _003CInitEnemy_003Eb__8_1(float val)
	{
		_sineF = val;
	}

	private float _003CDisappear_003Eb__10_0()
	{
		return _sineF;
	}

	private void _003CDisappear_003Eb__10_1(float x)
	{
		_sineF = x;
	}
}
