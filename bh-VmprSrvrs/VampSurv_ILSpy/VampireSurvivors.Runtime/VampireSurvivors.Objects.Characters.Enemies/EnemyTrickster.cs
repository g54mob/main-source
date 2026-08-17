using System;
using System.Collections.Generic;
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

public class EnemyTrickster : EnemyController
{
	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public List<EnemyController> enemies;

		internal void _003CSummonAll_003Eb__0()
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
		//IL_0618: Expected I, but got O
		//IL_0655: Expected O, but got Ref
		//IL_0598: Expected O, but got I4
		//IL_0572->IL04cb: Incompatible stack heights: 1 vs 0
		//IL_0260->IL04cb: Incompatible stack heights: 1 vs 0
		//IL_0605->IL04cb: Incompatible stack heights: 1 vs 0
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rbx_v17 (System.Object)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rbx_v17 (System.Object)+10]");
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
		goto IL_04cb;
		IL_00f1:
		Transform cachedTransform2 = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
		Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref ret);
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v985 @ rax_v29 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rcx_v23 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float val = 0f * _scaleMul;
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1006 @ rax_v30 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
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
			if (6660f > _maxHp)
			{
				_maxHp = 6660f;
			}
			_hp = _maxHp;
			SummonAll((float?)(object)1, 48, 0.8f);
			if (_gemSummonTimer != null)
			{
				_gemSummonTimer.Cancel();
			}
			Action onComplete = delegate
			{
				//IL_001a: Expected O, but got I4
				if (!base._003CIsDead_003Ek__BackingField)
				{
					SummonAll((float?)(object)1, 48, 0.8f);
				}
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer gemSummonTimer = Timers.Register(30.000002f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
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
				((EnemyTrickster)(object)dOSetter)._003CInitEnemy_003Eb__12_3(val);
				TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter, dOSetter, 0.1f, 2f);
				if (tweenerCore2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1494 @ rax_v52 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 4;
						_ = 0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1494 @ rax_v52 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1494 @ rax_v52 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
						if ((nint)0 == 0)
						{
							_ = 4294967295L;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1494 @ rax_v52 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
							if ((nint)0 == 0)
							{
								_ = 2139095040;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1494 @ rax_v52 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1494 @ rax_v52 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
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
		goto IL_04cb;
		IL_04cb:
		throw new NullReferenceException();
	}

	protected override void OnUpdate()
	{
		//IL_00af: Expected O, but got I4
		//IL_01e0: Expected O, but got I4
		float num = _sineF * _defaultSpeed;
		base._003CSpeed_003Ek__BackingField = num;
		base.OnUpdate();
		if (!_hasLostTreasure || _done)
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
			PlayerOptionsData config = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
			object obj = default(object);
			if (obj == null)
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
		((EnemyTrickster)(object)dOSetter)._003CDisappear_003Eb__14_1(val);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, -10f, 2f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Action action = _003COnDefeat_003Ek__BackingField;
		if (_003COnDefeat_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v173.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		_003COnDefeat_003Ek__BackingField = null;
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
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		object obj2 = default(object);
		if (!_hasLostTreasure)
		{
			object obj = obj2 - 25;
			if ((nint)obj <= 49)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"bt r9,rax\"");
				if ((nint)obj < 49)
				{
					goto IL_00de;
				}
			}
			if ((nint)obj2 == 1612 || (nint)obj2 == 92)
			{
				goto IL_00de;
			}
			if ((nint)obj2 == 35)
			{
				_hasLostTreasure = true;
			}
			goto IL_010b;
		}
		goto IL_0127;
		IL_010b:
		base.GetDamaged(value, showHitVfx, damageKb, damageType, hasKb);
		return;
		IL_0127:
		object obj3 = obj2 - 25;
		if ((nint)obj3 > 1 && (nint)obj2 != 1612)
		{
			goto IL_010b;
		}
		return;
		IL_00de:
		_hasLostTreasure = true;
		goto IL_0127;
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

	private unsafe void SummonAll(float? duration, int moreX, float moreZ)
	{
		//IL_005e: Expected O, but got I4
		//IL_0844: Expected O, but got F4
		//IL_016a: Expected O, but got I
		//IL_01e4: Expected O, but got I
		//IL_06f4: Expected O, but got I
		//IL_0274: Expected O, but got I
		//IL_074c: Expected O, but got I
		//IL_0316: Expected O, but got I
		//IL_035d: Expected O, but got I4
		//IL_05c0: Expected I, but got O
		//IL_05d6: Expected O, but got I
		//IL_05df: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e4: Expected O, but got Unknown
		//IL_065a: Expected I, but got O
		//IL_07de: Expected O, but got I4
		//IL_0805: Expected I, but got I8
		//IL_0636: Expected I, but got I8
		//IL_0538: Unknown result type (might be due to invalid IL or missing references)
		//IL_053d: Expected O, but got Unknown
		//IL_04d3: Expected I4, but got O
		//IL_0142->IL0660: Incompatible stack heights: 1 vs 0
		//IL_018a->IL0660: Incompatible stack heights: 1 vs 0
		//IL_01ce->IL06d1: Incompatible stack heights: 1 vs 2
		//IL_0714->IL0660: Incompatible stack heights: 2 vs 0
		//IL_025e->IL0719: Incompatible stack heights: 2 vs 3
		//IL_076c->IL0660: Incompatible stack heights: 3 vs 0
		//IL_0300->IL0771: Incompatible stack heights: 3 vs 4
		//IL_07d0->IL0660: Incompatible stack heights: 4 vs 0
		//IL_083b->IL065f: Incompatible stack heights: 5 vs 0
		//IL_038c->IL0660: Incompatible stack heights: 4 vs 0
		//IL_03cc->IL0660: Incompatible stack heights: 4 vs 0
		//IL_03f6->IL0660: Incompatible stack heights: 4 vs 0
		//IL_0441->IL0660: Incompatible stack heights: 4 vs 0
		//IL_0490->IL0660: Incompatible stack heights: 4 vs 0
		_003C_003Ec__DisplayClass19_0 obj = new _003C_003Ec__DisplayClass19_0();
		float num;
		float? num2;
		bool flag5 = default(bool);
		if ((object)GM.Core != null)
		{
			if (!GM.Core.IsStageHost)
			{
				return;
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
			object obj2 = UnityEngine.Random.value;
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
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						Camera main = Camera.main;
						Bounds bounds = CameraExtensions.OrthographicBounds(main);
						List<EnemyType> list = new List<EnemyType>();
						if (list != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1082 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1082 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1082 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1082 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
								nint num4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rdx_v19+18]");
								if (num4 >= 0)
								{
									((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)233);
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1082 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
									object obj4 = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1082 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
									nint num5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rdx_v19+18]");
									bool flag2 = num5 >= 0;
									_ = 233;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1082 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+1C]");
								_ = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1082 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1082 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1082 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
									nint num6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rdx_v21+18]");
									if (num6 >= 0)
									{
										((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)86);
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1082 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
										object obj6 = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1082 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
										nint num7 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rdx_v21+18]");
										bool flag3 = num7 >= 0;
										_ = 86;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1082 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+1C]");
									_ = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1082 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
									System.Int32Enum item = (System.Int32Enum)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1082 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
									List<System.Int32Enum> list2 = (List<System.Int32Enum>)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1082 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1082 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
										nint num8 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rdx_v27 (System.Int32Enum)+18]");
										if (num8 >= 0)
										{
											((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)39);
											item = (System.Int32Enum)39;
											list2 = (List<System.Int32Enum>)(object)list;
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1082 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
											object obj7 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1082 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
											nint num9 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rdx_v27 (System.Int32Enum)+18]");
											bool flag4 = num9 >= 0;
											_ = 39;
										}
										int num10 = default(int);
										if (num10 <= 0)
										{
											goto IL_0559;
										}
										object obj8 = 0;
										Vector2 spawnPos = default(Vector2);
										while (true)
										{
											((List<EnemyType>)(object)list2).Add((EnemyType)item);
											((List<EnemyType>)(object)list2).Add((EnemyType)item);
											GameManager gameManager = _gameManager;
											if ((object)_gameManager == null)
											{
												break;
											}
											EnemyType enemyType = VampireSurvivors.App.Tools.Extensions.PickRnd(list);
											if ((object)gameManager._stage == null)
											{
												break;
											}
											GameObject gameObject = gameManager._stage.SpawnEnemy(enemyType, spawnPos, asRemote: false, flag5);
											if ((object)gameObject == null)
											{
												break;
											}
											EnemyController component = gameObject.GetComponent<EnemyController>();
											if ((object)component == null)
											{
												break;
											}
											component._003CIsCullable_003Ek__BackingField = false;
											component._003CSpeed_003Ek__BackingField = 250f;
											List<object> enemies2 = (List<object>)(object)obj.enemies;
											if (obj.enemies == null)
											{
												break;
											}
											int version = enemies2._version + 1;
											enemies2._version = version;
											object[] items = enemies2._items;
											if (enemies2._items == null)
											{
												break;
											}
											if (enemies2._size >= items.Length)
											{
												((List<object>)(object)obj.enemies).AddWithResize((object)component);
												item = (System.Int32Enum)component;
												list2 = (List<System.Int32Enum>)(object)obj.enemies;
											}
											else
											{
												int num11 = enemies2._size + 1;
												enemies2._size = num11;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												item = (System.Int32Enum)enemies2._size;
												list2 = (List<System.Int32Enum>)(object)enemies2._items;
											}
											obj8++;
											if ((nint)obj8 < num10)
											{
												continue;
											}
											goto IL_0559;
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
		IL_0559:
		bool flag6 = (object)num2 == null;
		Action action = null;
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ r10_v9 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass19_0._003CSummonAll_003Eb__0);
		((Delegate)action).m_target = obj;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ r10_v9 (Il2CppMethodInfo)+4C]");
		object obj9 = (nint)0 >> 4;
		object obj10 = obj9 & 1;
		nint num13;
		if (obj10 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ r10_v9 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num13 = unchecked((nint)6447293664L);
				goto IL_07d5;
			}
		}
		num13 = ((Delegate)action).method_ptr;
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		goto IL_07d5;
		IL_07d5:
		object obj11 = 24;
		float duration2 = num * 0.001f;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration2, action, null, isLooped: false, flag5, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
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
		//IL_001a: Expected O, but got I4
		if (!base._003CIsDead_003Ek__BackingField)
		{
			SummonAll((float?)(object)1, 48, 0.8f);
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
