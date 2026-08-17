using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyDrownerNormal : EnemyController
{
	private Stage _stage;

	private bool _hasLostTreasure;

	private bool _dismissed;

	private bool _isFresh = true;

	private bool _done;

	private Tween _onEnterTween;

	private Tween _onFireTimer;

	private EnemyBulletW _bullet;

	private GameObject _spritte;

	private ParticleSystem _pfxEmitter;

	private SpriteRenderer _ringSprite;

	protected float _goNutsMinute = 10f;

	protected float _distanceMultiplier = 0.45f;

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

	protected override void FakeConstruct()
	{
		base.FakeConstruct();
		GameManager core = GM.Core;
		_stage = core._stage;
	}

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_04a8: Expected O, but got Ref
		//IL_00cf->IL02ac: Incompatible stack heights: 1 vs 0
		//IL_03cc->IL02ac: Incompatible stack heights: 2 vs 0
		//IL_00f1->IL00f1: Incompatible stack heights: 1 vs 0
		//IL_0419->IL02ac: Incompatible stack heights: 2 vs 0
		//IL_0468->IL02ac: Incompatible stack heights: 3 vs 0
		//IL_0231->IL02ac: Incompatible stack heights: 3 vs 0
		//IL_025d->IL025d: Incompatible stack heights: 3 vs 2
		bool asRemote2 = default(bool);
		base.InitEnemy(enemyType, asRemote2);
		SpriteRenderer ringSprite = _ringSprite;
		_dismissed = false;
		base._003CIsCullable_003Ek__BackingField = false;
		_hasLostTreasure = false;
		if ((object)_ringSprite != null && ((UnityEngine.Object)ringSprite).m_CachedPtr != (IntPtr)0)
		{
			goto IL_00f1;
		}
		Transform cachedTransform = _cachedTransform;
		Vector3 ret = default(Vector3);
		Vector2 vector = default(Vector2);
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out ret);
			GameObject gameObject = base.gameObject;
			SpriteRenderer component = RenderingExtensions.AddSprite(gameObject, vector, "vfx", "sPFX_ring_64");
			SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(component, 0f);
			Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
			if ((object)spriteRenderer != null)
			{
				((Renderer)spriteRenderer).SetMaterial(material);
				_ringSprite = spriteRenderer;
				goto IL_00f1;
			}
		}
		goto IL_02ac;
		IL_00f1:
		object cachedTransform2 = _cachedTransform;
		bool flag2 = (object)_cachedTransform == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v449 @ rdi_v12 (System.Object)+10]");
		bool flag3 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v449 @ rdi_v12 (System.Object)+10]");
		Transform.set_localScale_Injected((IntPtr)0, ref ret);
		Vector3 vector2 = default(Vector3);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, (Vector3)(&vector2), 0.3f);
		TweenCallback tweenCallback = delegate
		{
			Transform cachedTransform4 = _cachedTransform;
			bool flag5 = ((UnityEngine.Object)cachedTransform4).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform4).m_CachedPtr, ref value);
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1009 @ rax_v37 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
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
			EnemyBulletW bullet = _bullet;
			if ((object)_bullet != null && ((UnityEngine.Object)bullet).m_CachedPtr != (IntPtr)0)
			{
				goto IL_025d;
			}
			Transform cachedTransform3 = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag4 = ((UnityEngine.Object)cachedTransform3).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform3).m_CachedPtr, out ret);
				if ((object)_stage != null)
				{
					bool forceSpawn = default(bool);
					GameObject gameObject2 = _stage.SpawnEnemy(EnemyType.BULLET_W, vector, asRemote: false, forceSpawn);
					if ((object)gameObject2 != null)
					{
						EnemyBulletW component2 = gameObject2.GetComponent<EnemyBulletW>();
						_bullet = component2;
						GenerateParticleSystems();
						goto IL_025d;
					}
				}
			}
		}
		goto IL_02ac;
		IL_025d:
		GameObject spritte = _spritte;
		if ((object)_spritte == null || ((UnityEngine.Object)spritte).m_CachedPtr == (IntPtr)0)
		{
			SpawnSpritte();
		}
		return;
		IL_02ac:
		throw new NullReferenceException();
	}

	public override void Disappear()
	{
		EnemyBulletW bullet = _bullet;
		_dismissed = true;
		base._003CIsCullable_003Ek__BackingField = true;
		base._003CIsTeleportOnCull_003Ek__BackingField = false;
		if ((object)_bullet != null && ((UnityEngine.Object)bullet).m_CachedPtr != (IntPtr)0)
		{
			_bullet.Dismiss();
		}
		_bullet = null;
		ParticleSystem pfxEmitter = _pfxEmitter;
		if ((object)_pfxEmitter != null && ((UnityEngine.Object)pfxEmitter).m_CachedPtr != (IntPtr)0)
		{
			_pfxEmitter.Stop();
		}
	}

	protected override void OnUpdate()
	{
		HandleDrownerUpdate();
	}

	public override void Despawn()
	{
		base.Despawn();
		GameObject spritte = _spritte;
		if ((object)_spritte != null && ((UnityEngine.Object)spritte).m_CachedPtr != (IntPtr)0)
		{
			_spritte.SetActive(value: false);
		}
		ParticleSystem pfxEmitter = _pfxEmitter;
		if ((object)_pfxEmitter != null && ((UnityEngine.Object)pfxEmitter).m_CachedPtr != (IntPtr)0)
		{
			_pfxEmitter.Stop();
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
		if ((nint)obj <= 50)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"bt rcx,rax\"");
			if ((nint)obj < 50)
			{
				goto IL_00e3;
			}
		}
		if ((nint)obj2 != 1612 && (nint)obj2 != 92)
		{
			float num = default(float);
			if ((nint)obj2 == 76)
			{
				num *= 10f;
			}
			base.GetDamaged(num, showHitVfx, damageKb, damageType, hasKb);
			return;
		}
		goto IL_00e3;
		IL_00e3:
		Die();
		_hasLostTreasure = true;
	}

	protected unsafe override void Die()
	{
		//IL_0247: Expected O, but got I4
		//IL_0277: Expected O, but got Ref
		//IL_011c: Expected O, but got I4
		//IL_012b: Expected O, but got I4
		//IL_02c0: Expected O, but got I4
		//IL_02f7: Expected I, but got O
		//IL_0326: Expected I4, but got F4
		//IL_00d6: Expected O, but got I
		base.Die();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Deathscream, soundConfig, 150f, 2, num);
		Transform target = _ringSprite.transform;
		Vector3 vector = Vector3.oneVector;
		object obj = default(object);
		float num2 = (float)obj * 16f;
		Vector3 vector2 = default(Vector3);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, (Vector3)(&vector2), 0.3f);
		nint num4;
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
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						vector = (Vector3)(num3 + 0);
					}
					TweenCallback tweenCallback = delegate
					{
						_ringSprite.enabled = false;
					};
					tweenCallback2 = tweenCallback;
					num4 = 0;
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
		num4 = 0;
		obj2 = 0;
		nint num5 = 0;
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
		num5 = num4;
		obj3 = obj2;
		vector3 = vector;
		if (!flag2)
		{
			num5 = num4;
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
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v520.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		_003COnDefeat_003Ek__BackingField = null;
		_dismissed = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDrownerNormal>)+390]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num6 = (nint)this;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void SpawnBullet()
	{
		object cachedTransform = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rdi_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rdi_v1 (System.Object)+10]");
		Transform.get_position_Injected((IntPtr)0, out Vector3 _);
		Vector2 spawnPos = default(Vector2);
		bool forceSpawn = default(bool);
		GameObject gameObject = _stage.SpawnEnemy(EnemyType.BULLET_W, spawnPos, asRemote: false, forceSpawn);
		EnemyBulletW component = gameObject.GetComponent<EnemyBulletW>();
		_bullet = component;
		GenerateParticleSystems();
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

	protected virtual float GetSpawnY()
	{
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		Camera main = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v10 (UnityEngine.Bounds)+10]");
		float num = 0f * 2f;
		float num2 = num * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rcx_v6 (PhaserScene+Renderer)+38]");
		return 0f - num2;
	}

	private unsafe void HandleDrownerUpdate()
	{
		//IL_01f3: Invalid comparison between F4 and O
		//IL_013d: Invalid comparison between F4 and O
		//IL_0d0e: Expected O, but got I4
		//IL_04df: Expected O, but got I4
		//IL_0d39: Expected O, but got I4
		//IL_054c: Expected O, but got I4
		//IL_05ac: Expected O, but got I4
		//IL_07b6: Expected O, but got I4
		//IL_09cf: Expected O, but got I4
		//IL_0acc->IL0a5d: Incompatible stack heights: 2 vs 0
		//IL_00cf->IL0a11: Incompatible stack heights: 1 vs 0
		//IL_0d8d->IL0a11: Incompatible stack heights: 1 vs 0
		//IL_0bc3->IL0a11: Incompatible stack heights: 1 vs 0
		//IL_0b92->IL0a11: Incompatible stack heights: 1 vs 0
		//IL_02d8->IL0a11: Incompatible stack heights: 1 vs 0
		//IL_0103->IL0a11: Incompatible stack heights: 1 vs 0
		//IL_0ca7->IL0a11: Incompatible stack heights: 3 vs 0
		//IL_060c->IL0a11: Incompatible stack heights: 3 vs 0
		//IL_0507->IL0a11: Incompatible stack heights: 3 vs 0
		//IL_0cef->IL0c7e: Incompatible stack heights: 5 vs 3
		//IL_0638->IL0a11: Incompatible stack heights: 3 vs 0
		//IL_065a->IL0a11: Incompatible stack heights: 3 vs 0
		//IL_06a3->IL0a11: Incompatible stack heights: 3 vs 0
		//IL_06cf->IL0a11: Incompatible stack heights: 3 vs 0
		//IL_0574->IL0a11: Incompatible stack heights: 3 vs 0
		//IL_06f1->IL0a11: Incompatible stack heights: 3 vs 0
		//IL_0785->IL0a11: Incompatible stack heights: 3 vs 0
		//IL_0802->IL0a11: Incompatible stack heights: 3 vs 0
		//IL_0853->IL0a11: Incompatible stack heights: 3 vs 0
		//IL_087f->IL0a11: Incompatible stack heights: 3 vs 0
		//IL_08a1->IL0a11: Incompatible stack heights: 3 vs 0
		//IL_08ea->IL0a11: Incompatible stack heights: 3 vs 0
		//IL_0919->IL0a11: Incompatible stack heights: 3 vs 0
		//IL_0948->IL0a11: Incompatible stack heights: 3 vs 0
		//IL_0977->IL0a11: Incompatible stack heights: 3 vs 0
		PhaserScene.Renderer renderer;
		float value = default(float);
		Vector3 ret;
		float num3;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					Camera main = Camera.main;
					Bounds bounds = CameraExtensions.OrthographicBounds(main);
					if (_isFresh)
					{
						float spawnY = GetSpawnY();
						object cachedTransform = _cachedTransform;
						bool flag = (object)_cachedTransform == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rdi_v27 (System.Object)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rdi_v27 (System.Object)+10]");
						Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value));
						_isFresh = false;
					}
					ParticleSystemRenderer cachedTransform2 = (ParticleSystemRenderer)(object)_cachedTransform;
					if ((object)_cachedTransform != null)
					{
						bool flag3 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out ret);
						base._003CIsTeleportOnCull_003Ek__BackingField = false;
						base._003CSpeed_003Ek__BackingField = 0f;
						base.OnUpdate();
						float deltaTime = PauseSystem.DeltaTime;
						float num = deltaTime * 100f;
						float num2 = num * 1000f;
						num3 = num2 * 0.01f;
						if (!_dismissed)
						{
							goto IL_01a6;
						}
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene2 = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null)
							{
								PhaserScene.Renderer renderer2 = s_scene2._renderer;
								if (s_scene2._renderer != null)
								{
									float num4 = renderer2.width + renderer2.width;
									float num5 = (float)renderer.screenCenter - num4;
									if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5) > System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret))
									{
										float num6 = (float)ret + num3;
										if (!(num6 > num5))
										{
											goto IL_0d6b;
										}
									}
									float num7 = (float)ret - num3;
									if (num7 < num5)
									{
										goto IL_01a6;
									}
									goto IL_0d6b;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0a11;
		IL_025c:
		float num8 = _goNutsMinute * 60f;
		GameManager core = default(GameManager);
		float num9 = ((!(core._003CSurvivedSeconds_003Ek__BackingField > num8)) ? 0.1f : 1.3f);
		float num20 = default(float);
		if (core._playerOptions != null)
		{
			PlayerOptionsData config = core._playerOptions.Config;
			if (config != null)
			{
				bool flag4 = config._003CSelectedHyper_003Ek__BackingField;
				float num10 = num9;
				if (!flag4)
				{
					num10 = num9 * 0.5f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rax_v34 (PhaserScene+Renderer)+38]");
				float num11 = 0f + 0.12f;
				float num12 = default(float);
				bool flag5 = !(num11 > num12);
				float num13 = num12;
				if (!flag5)
				{
					float num14 = num10 * 0.01f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rax_v34 (PhaserScene+Renderer)+38]");
					num11 = 0f + 0.12f;
					if (num11 > num12)
					{
						float num15 = num14 + num12;
						bool flag6 = !(num15 > num11);
						num13 = num15;
						if (!flag6)
						{
							num13 = num11;
						}
					}
					else
					{
						num13 = num12 - num14;
						if (num13 < num11)
						{
							num13 = num11;
						}
					}
				}
				object cachedTransform3 = _cachedTransform;
				bool flag7 = (object)_cachedTransform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v972 @ rdi_v16 (System.Object)+10]");
				bool flag8 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v972 @ rdi_v16 (System.Object)+10]");
				Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value));
				ParticleSystemRenderer bullet = (ParticleSystemRenderer)(object)_bullet;
				bool flag9 = (object)_bullet == null;
				float num16 = 0.12f;
				if (!flag9)
				{
					bool flag10 = ((UnityEngine.Object)bullet).m_CachedPtr == (IntPtr)0;
					num16 = 0.12f;
					if (!flag10)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v674 @ rax_v37 (UnityEngine.Bounds)+10]");
						float num17 = 0f * 2f;
						num16 = num17 * 0.5f;
						float num18 = num13;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rax_v34 (PhaserScene+Renderer)+38]");
						float num19 = num18 - 0f;
						if (!(num19 > num16) && (object)_bullet == null)
						{
							goto IL_0a11;
						}
						Transform transform = _bullet.transform;
						bool flag11 = (object)transform == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1496 @ rax_v118 (UnityEngine.Transform)+10]");
						bool flag12 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1496 @ rax_v118 (UnityEngine.Transform)+10]");
						Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value));
						num11 = num20;
					}
				}
				ParticleSystemRenderer pfxEmitter = (ParticleSystemRenderer)(object)_pfxEmitter;
				bool flag13 = (object)_pfxEmitter == null;
				object obj = 0;
				if (!flag13)
				{
					bool flag14 = ((UnityEngine.Object)pfxEmitter).m_CachedPtr == (IntPtr)0;
					obj = 0;
					if (!flag14)
					{
						if ((object)_pfxEmitter == null)
						{
							goto IL_0a11;
						}
						ParticleSystemRenderer component = _pfxEmitter.GetComponent<ParticleSystemRenderer>();
						bool flag15 = (object)component == null;
						obj = 0;
						if (!flag15)
						{
							bool flag16 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
							obj = 0;
							if (!flag16)
							{
								if ((object)_EnemyRenderer == null)
								{
									goto IL_0a11;
								}
								int sortingOrder = _EnemyRenderer.sortingOrder;
								int sortingOrder2 = sortingOrder - 1;
								component.sortingOrder = sortingOrder2;
								obj = 0;
							}
						}
					}
				}
				if (!_hasLostTreasure || _done)
				{
					return;
				}
				if (_playerOptions != null)
				{
					PlayerOptionsData config2 = _playerOptions.Config;
					if (config2 != null && config2._003CUnlockedCharacters_003Ek__BackingField != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
						object obj2 = default(object);
						if (obj2 != null)
						{
							return;
						}
						if (_playerOptions != null)
						{
							PlayerOptionsData config3 = _playerOptions.Config;
							if (config3 != null && config3._003CUnlockedCharacters_003Ek__BackingField != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
								object obj3 = default(object);
								if (obj3 == null)
								{
									return;
								}
								ParticleSystemRenderer spritte = (ParticleSystemRenderer)(object)_spritte;
								if ((object)_spritte == null || ((UnityEngine.Object)spritte).m_CachedPtr == (IntPtr)0)
								{
									SpawnSpritte();
								}
								if ((object)_spritte != null)
								{
									_spritte.SetActive(value: true);
									float time = default(float);
									PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.PAN, new SoundManager.SoundConfig
									{
										Volume = (float?)(object)1,
										Rate = 1f
									}, 20000f, 1, time);
									if ((object)GM.Core != null)
									{
										if (!GM.Core.CheckValidToastieInputs())
										{
											return;
										}
										_done = true;
										if (_playerOptions != null)
										{
											PlayerOptionsData config4 = _playerOptions.Config;
											if (config4 != null && config4._003CUnlockedCharacters_003Ek__BackingField != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
												object obj4 = default(object);
												if (obj4 != null)
												{
													return;
												}
												if (_playerOptions != null)
												{
													_playerOptions.UnlockCharacter(CharacterType.PANINI);
													if (_playerOptions != null)
													{
														_playerOptions.RevealCharacter(CharacterType.PANINI);
														if (_playerOptions != null)
														{
															_playerOptions.BuyCharacter(CharacterType.PANINI);
															if (_playerOptions != null)
															{
																_playerOptions.Save();
																PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
																PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.ThingFound, new SoundManager.SoundConfig
																{
																	Volume = (float?)(object)1,
																	Delay = -1000f,
																	Rate = 0.5f
																}, 0f, 10, time);
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
						}
					}
				}
			}
		}
		goto IL_0a11;
		IL_0a11:
		throw new NullReferenceException();
		IL_0d6b:
		core = GM.Core;
		if ((object)GM.Core != null)
		{
			goto IL_025c;
		}
		goto IL_0a11;
		IL_01a6:
		float num21 = num20 * 2f;
		float num22 = num21 * _distanceMultiplier;
		float num23 = (float)renderer.screenCenter - num22;
		float num24 = num23 + 0.96f;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num24) > System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret))
		{
			float num25 = (float)ret + num3;
			if (!(num25 > num24))
			{
				goto IL_0d6b;
			}
		}
		float num26 = (float)ret - num3;
		if (num26 < num24)
		{
			goto IL_025c;
		}
		goto IL_0d6b;
	}

	private float Approach(float start, float end, float shift)
	{
		if (end > start)
		{
			float num = start + shift;
			if (num > end)
			{
				num = end;
			}
			return num;
		}
		float num2 = start - shift;
		if (num2 < end)
		{
			num2 = end;
		}
		return num2;
	}

	private void Dismiss()
	{
		//IL_002c: Expected I, but got O
		_dismissed = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDrownerNormal>)+390]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_01a4: Expected O, but got I
		//IL_01c0: Expected O, but got I4
		//IL_01d4: Expected native int or pointer, but got O
		//IL_01de: Expected native int or pointer, but got O
		//IL_052e: Expected O, but got I4
		//IL_0209: Expected O, but got Ref
		//IL_0223: Expected native int or pointer, but got O
		//IL_023d: Expected O, but got I
		//IL_025d: Expected O, but got Ref
		//IL_0277: Expected native int or pointer, but got O
		//IL_0560: Expected O, but got I
		//IL_02af: Expected O, but got Ref
		//IL_02c9: Expected native int or pointer, but got O
		//IL_059a: Expected O, but got I
		//IL_030f: Expected O, but got I4
		//IL_0328: Expected O, but got Ref
		//IL_034f: Expected O, but got I
		//IL_0369: Expected native int or pointer, but got O
		//IL_05d4: Expected O, but got I
		//IL_03af: Expected O, but got I
		//IL_03ca: Expected O, but got I
		//IL_03e5: Expected O, but got I
		//IL_0413: Expected O, but got I
		//IL_0095->IL0498: Incompatible stack heights: 1 vs 0
		//IL_00e4->IL0498: Incompatible stack heights: 1 vs 0
		//IL_0166->IL0498: Incompatible stack heights: 1 vs 0
		//IL_060d->IL0498: Incompatible stack heights: 1 vs 0
		//IL_0498->IL04d2: Incompatible stack heights: 3 vs 0
		ParticleSystem.MinMaxCurve minMaxCurve2 = default(ParticleSystem.MinMaxCurve);
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)(&minMaxCurve2);
		ParticleSystem pfxEmitter = _pfxEmitter;
		if ((object)_pfxEmitter != null && ((UnityEngine.Object)pfxEmitter).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Rect? ret;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)(&ret));
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			list._002Ector();
			if (list != null)
			{
				int version = list._version + 1;
				list._version = version;
				string[] items = list._items;
				if (list._items != null)
				{
					if (list._size >= items.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"WhiteDot");
					}
					else
					{
						int num = list._size + 1;
						list._size = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					if (particleSystemConfig != null)
					{
						particleSystemConfig._frame = list;
						_ = 0;
						_ = 10;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)+E0]");
						particleSystemConfig._quantity = (int?)(object)0;
						ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(2000f);
						particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
						_ = 0;
						((ParticleSystem.MinMaxCurve*)(nint)minMaxCurve)->m_Mode = ParticleSystemCurveMode.Constant;
						System.Runtime.CompilerServices.Unsafe.Write(&((ParticleSystem.MinMaxCurve*)(nint)minMaxCurve)->m_CurveMax, null);
						minMaxCurve2 = new ParticleSystem.MinMaxCurve(0.7f, 0f);
						particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-80]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref minMaxCurve2, 32));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(225f, 315f));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)+20]");
						particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)+30]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref minMaxCurve2, 64));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(75f, 125f));
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)+40]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)+50]");
						_ = 0;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-78]");
						particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-68]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-58]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref minMaxCurve2, 96));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(2f, 0f));
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)+60]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)+70]");
						_ = 0;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-50]");
						particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-40]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-30]");
						_ = 0;
						minMaxCurve3 = new ParticleSystem.MinMaxCurve(300f);
						particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref minMaxCurve2, 128));
						_ = 0;
						_ = 12303359;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)+E0]");
						particleSystemConfig._tint = (uint?)(object)0;
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0.2f, 0.5f));
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)+80]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)+90]");
						_ = 0;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-28]");
						particleSystemConfig._bounce = (ParticleSystem.MinMaxCurve?)(object)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-18]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-8]");
						_ = 0;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)+E0]");
						particleSystemConfig._collideTop = (bool?)(object)0;
						_ = 257;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)+E0]");
						particleSystemConfig._collideBottom = (bool?)(object)0;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)+E0]");
						particleSystemConfig._collideLeft = (bool?)(object)0;
						Rect? bounds = default(Rect?);
						particleSystemConfig._bounds = bounds;
						_ = 1;
						_ = 1f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)+E0]");
						particleSystemConfig._collideRight = (bool?)(object)0;
						particleSystemConfig._on = false;
						Transform parent = base.transform;
						ParticleSystem pfxEmitter2 = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent);
						_pfxEmitter = pfxEmitter2;
						if ((object)_pfxEmitter != null)
						{
							Transform transform = _pfxEmitter.transform;
							bool flag2 = (object)transform == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v65 (UnityEngine.Transform)+10]");
							bool flag3 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v65 (UnityEngine.Transform)+10]");
							Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&ret));
							RenderingExtensions.Start(_pfxEmitter);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void _003CInitEnemy_003Eb__18_0()
	{
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
	}

	private void _003CDie_003Eb__23_0()
	{
		_ringSprite.enabled = false;
	}
}
