using System;
using System.Collections.Generic;
using Coherence.Toolkit;
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
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyTricksterNormal : EnemyController
{
	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public List<EnemyController> enemies;

		internal void _003CSummonGems_003Eb__0()
		{
			//IL_0013: Expected O, but got I4
			List<EnemyController>.Enumerator enumerator = default(List<EnemyController>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
			}
		}
	}

	private bool _hasLostTreasure;

	private bool _done;

	private float _sineF;

	private Timer _gemSummonTimer;

	private Tween _onEnterTween;

	private Tween _onSineTween;

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
		//IL_05f6: Expected I, but got O
		//IL_0633: Expected O, but got Ref
		//IL_055d: Expected O, but got F4
		//IL_0576: Expected O, but got I4
		//IL_054f->IL04a8: Incompatible stack heights: 1 vs 0
		//IL_023d->IL04a8: Incompatible stack heights: 1 vs 0
		//IL_05e3->IL04a8: Incompatible stack heights: 1 vs 0
		bool asRemote2 = default(bool);
		base.InitEnemy(enemyType, asRemote2);
		SpriteRenderer ringSprite = _ringSprite;
		if ((object)_ringSprite != null && ((UnityEngine.Object)ringSprite).m_CachedPtr != (IntPtr)0)
		{
			goto IL_00f1;
		}
		object cachedTransform = _cachedTransform;
		Vector3 ret = default(Vector3);
		if ((object)_cachedTransform != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rbx_v18 (System.Object)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rbx_v18 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out ret);
				GameObject gameObject = base.gameObject;
				Vector2 pos = default(Vector2);
				SpriteRenderer component = RenderingExtensions.AddSprite(gameObject, pos, "vfx", "sPFX_ring_64");
				SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(component, 0f);
				Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
				if ((object)spriteRenderer != null)
				{
					((Renderer)spriteRenderer).SetMaterial(material);
					_ringSprite = spriteRenderer;
					goto IL_00f1;
				}
			}
			else
			{
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_cachedTransform);
			}
		}
		goto IL_04a8;
		IL_00f1:
		Transform cachedTransform2 = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
		Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref ret);
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1032 @ rax_v32 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1033 @ rcx_v26 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float val = 0f * _scaleMul;
		Vector3 vector = default(Vector3);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, (Vector3)(&vector), 0.3f);
		TweenCallback tweenCallback = delegate
		{
			Transform cachedTransform3 = _cachedTransform;
			bool flag3 = ((UnityEngine.Object)cachedTransform3).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform3).m_CachedPtr, ref value);
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1053 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
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
			object obj = UnityEngine.Random.value;
			bool flag2 = default(bool);
			SummonGems((float?)(object)1, 48, 0.8f, flag2);
			if (_gemSummonTimer != null)
			{
				_gemSummonTimer.Cancel();
			}
			Action onComplete = delegate
			{
				//IL_0036: Expected O, but got F4
				//IL_004f: Expected O, but got I4
				if (!base._003CIsDead_003Ek__BackingField)
				{
					object obj2 = UnityEngine.Random.value;
					bool useStatic = default(bool);
					SummonGems((float?)(object)1, 48, 0.8f, useStatic);
				}
			};
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer gemSummonTimer = Timers.Register(30.000002f, onComplete, null, isLooped: true, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_gemSummonTimer = gemSummonTimer;
			EnemyData currentEnemyData = _currentEnemyData;
			if (_currentEnemyData != null)
			{
				_defaultSpeed = currentEnemyData._003Cspeed_003Ek__BackingField;
				_sineF = 1f;
				base._003CIsCullable_003Ek__BackingField = false;
				base._003CIsTeleportOnCull_003Ek__BackingField = true;
				_hasLostTreasure = false;
				if (_onSineTween != null)
				{
					DG.Tweening.TweenExtensions.Restart(_onSineTween);
					return;
				}
				DOGetter<float> getter = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
				DOSetter<float> dOSetter = null;
				((EnemyTricksterNormal)(object)dOSetter)._003CInitEnemy_003Eb__12_3(val);
				TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter, dOSetter, 0.1f, 2f);
				if (tweenerCore2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1580 @ rax_v58 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 4;
						_ = 0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1580 @ rax_v58 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1580 @ rax_v58 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
						if ((nint)0 == 0)
						{
							_ = 4294967295L;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1580 @ rax_v58 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
							if ((nint)0 == 0)
							{
								_ = 2139095040;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1580 @ rax_v58 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1580 @ rax_v58 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
							if ((nint)0 == 0)
							{
								_ = 0;
							}
						}
					}
				}
				_onSineTween = tweenerCore2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
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
		goto IL_04a8;
		IL_04a8:
		throw new NullReferenceException();
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

	public override void Disappear()
	{
		if (_onSineTween != null)
		{
			Tween tween = DG.Tweening.TweenExtensions.Pause(_onSineTween);
		}
		_sineF = -2f;
		base._003CIsCullable_003Ek__BackingField = true;
		base._003CIsTeleportOnCull_003Ek__BackingField = false;
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float val = default(float);
		((EnemyTricksterNormal)(object)dOSetter)._003CDisappear_003Eb__14_1(val);
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

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		if (_hasLostTreasure)
		{
			return;
		}
		object obj2 = default(object);
		object obj = obj2 - 24;
		if ((nint)obj > 2 && (nint)obj2 != 1612 && (nint)obj2 != 73 && (nint)obj2 != 74)
		{
			float num = default(float);
			if ((nint)obj2 == 76)
			{
				num *= 10f;
			}
			base.GetDamaged(num, showHitVfx, damageKb, damageType, hasKb);
		}
		else
		{
			Die();
			_hasLostTreasure = true;
		}
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

	private unsafe void SummonGems(float? duration, int moreX, float moreZ, bool useStatic)
	{
		//IL_00db: Expected O, but got I4
		//IL_0683: Expected O, but got F4
		//IL_008d: Expected O, but got I
		//IL_021a: Expected O, but got I4
		//IL_03fe: Expected I, but got O
		//IL_0414: Expected O, but got I
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0422: Expected O, but got Unknown
		//IL_0498: Expected I, but got O
		//IL_061e: Expected O, but got I4
		//IL_0645: Expected I, but got I8
		//IL_0474: Expected I, but got I8
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Expected I4, but got Unknown
		//IL_057f: Expected O, but got I4
		//IL_058d: Expected I, but got O
		//IL_02b2: Expected O, but got I4
		//IL_02c0: Expected I, but got O
		//IL_0313: Expected I, but got O
		//IL_0610->IL049e: Incompatible stack heights: 1 vs 0
		//IL_067a->IL049d: Incompatible stack heights: 2 vs 0
		//IL_024c->IL049e: Incompatible stack heights: 1 vs 0
		//IL_02f3->IL049e: Incompatible stack heights: 1 vs 0
		//IL_0330->IL049e: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass19_0 obj = new _003C_003Ec__DisplayClass19_0();
		CoherenceSync coherenceSync = _coherenceSync;
		float num;
		float? num2;
		bool canPause;
		bool flag6 = default(bool);
		if ((object)_coherenceSync != null)
		{
			NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
			if (coherenceSync._003CEntityState_003Ek__BackingField != null)
			{
				ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
				if (networkEntityState._003CAuthorityType_003Ek__BackingField == null)
				{
					goto IL_049e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v74 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				bool flag;
				if ((nint)0 == 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v74 (Coherence.Toolkit.ObservableAuthorityType)+10]");
					flag = false;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v74 (Coherence.Toolkit.ObservableAuthorityType)+10]");
					object obj2 = -3;
					bool flag2 = obj2 == null;
					flag = flag2;
				}
				if (!flag)
				{
					return;
				}
			}
			if ((object)duration == null)
			{
				num = 60000f;
				num2 = (float?)(object)1;
			}
			else
			{
				float num3 = default(float);
				num = num3;
				num2 = duration;
			}
			object obj3 = UnityEngine.Random.value;
			object obj4 = default(object);
			float num4 = (float)obj4 * ((float)Math.PI * 2f);
			List<EnemyController> enemies = new List<EnemyController>();
			if (obj != null)
			{
				obj.enemies = enemies;
				GameSessionData gameSessionData = _gameSessionData;
				if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
				{
					Transform transform = gameSessionData._activeCharacter.transform;
					if ((object)transform != null)
					{
						bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						Camera main = Camera.main;
						Bounds bounds = CameraExtensions.OrthographicBounds(main);
						int num5 = default(int);
						bool flag4 = num5 <= 0;
						canPause = false;
						if (flag4)
						{
							goto IL_0397;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ rax_v33 (UnityEngine.Bounds)+10]");
						float num6 = 0f * 2f;
						float num7 = (float)num5 * 0.5f;
						float num8 = num6 * moreZ;
						float num9 = (float)Math.PI / num7;
						bool flag5 = false;
						Vector2 vector = (Vector2)0;
						Camera camera = main;
						object obj5 = default(object);
						nint num10 = (nint)(&obj5);
						object obj6 = default(object);
						object obj7 = default(object);
						Vector2 vector2 = default(Vector2);
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
							GameManager gameManager = _gameManager;
							float num11 = num4 + num9;
							float num12 = num4 * 0.8f;
							float num13 = num12 * num8;
							float num14 = (float)obj6 - num13;
							if ((object)_gameManager == null || (object)gameManager._stage == null)
							{
								break;
							}
							EnemyType enemyType = (EnemyType)(obj7 + 233);
							GameObject gameObject = gameManager._stage.SpawnEnemy(enemyType, vector2, asRemote: false, flag6);
							bool flag7 = (object)gameObject == null;
							camera = (Camera)enemyType;
							num10 = (nint)typeof(UnityEngine.Object);
							if (!flag7)
							{
								bool flag8 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								camera = (Camera)enemyType;
								num10 = (nint)typeof(UnityEngine.Object);
								if (!flag8)
								{
									EnemyController component = gameObject.GetComponent<EnemyController>();
									if ((object)component == null)
									{
										break;
									}
									component._003CIsCullable_003Ek__BackingField = false;
									num10 = (nint)obj.enemies;
									if (obj.enemies == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FE520");
									camera = (Camera)(object)component;
								}
							}
							flag5 = (byte)((flag5 ? 1u : 0u) + 1u) != 0;
							bool flag9 = (flag5 ? 1 : 0) < num5;
							canPause = false;
							flag6 = flag6;
							num4 = num11;
							vector = vector2;
							if (flag9)
							{
								continue;
							}
							goto IL_0397;
						}
					}
				}
			}
		}
		goto IL_049e;
		IL_0615:
		object obj8 = 24;
		float duration2 = num * 0.001f;
		Action action;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration2, action, null, isLooped: false, flag6, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause);
		return;
		IL_0397:
		bool flag10 = (object)num2 == null;
		action = null;
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v566 @ r10_v2 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass19_0._003CSummonGems_003Eb__0);
		((Delegate)action).m_target = obj;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v566 @ r10_v2 (Il2CppMethodInfo)+4C]");
		object obj9 = (nint)0 >> 4;
		object obj10 = obj9 & 1;
		nint num16;
		if (obj10 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v566 @ r10_v2 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num16 = unchecked((nint)6447293664L);
				goto IL_0615;
			}
		}
		num16 = ((Delegate)action).method_ptr;
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		goto IL_0615;
		IL_049e:
		throw new NullReferenceException();
	}

	private void _003CInitEnemy_003Eb__12_0()
	{
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
	}

	private void _003CInitEnemy_003Eb__12_1()
	{
		//IL_0036: Expected O, but got F4
		//IL_004f: Expected O, but got I4
		if (!base._003CIsDead_003Ek__BackingField)
		{
			object obj = UnityEngine.Random.value;
			bool useStatic = default(bool);
			SummonGems((float?)(object)1, 48, 0.8f, useStatic);
		}
	}

	private float _003CInitEnemy_003Eb__12_2()
	{
		return _sineF;
	}

	private void _003CInitEnemy_003Eb__12_3(float val)
	{
		_sineF = val;
	}

	private float _003CDisappear_003Eb__14_0()
	{
		return _sineF;
	}

	private void _003CDisappear_003Eb__14_1(float val)
	{
		_sineF = val;
	}

	private void _003CDie_003Eb__18_0()
	{
		_ringSprite.enabled = false;
	}
}
