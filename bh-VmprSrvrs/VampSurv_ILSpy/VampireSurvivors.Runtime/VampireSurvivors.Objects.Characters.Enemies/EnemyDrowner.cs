using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyDrowner : EnemyController
{
	private Stage _stage;

	private bool _hasLostTreasure;

	private bool _dismissed;

	private bool _invul;

	private bool _isFresh = true;

	private bool _done;

	private EnemyBulletW _bullet;

	private GameObject _spritte;

	private ParticleSystem _pfxEmitter;

	public bool _FromTrisection;

	public bool Dismissed
	{
		get
		{
			return _dismissed;
		}
		set
		{
			_dismissed = value;
		}
	}

	protected override void FakeConstruct()
	{
		base.FakeConstruct();
		GameManager core = GM.Core;
		_stage = core._stage;
	}

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0095->IL0095: Incompatible stack heights: 1 vs 0
		base.InitEnemy(enemyType, asRemote);
		EnemyBulletW bullet = _bullet;
		_isFresh = true;
		_hasLostTreasure = false;
		base._003CIsCullable_003Ek__BackingField = false;
		if ((object)_bullet == null || ((UnityEngine.Object)bullet).m_CachedPtr == (IntPtr)0)
		{
			object cachedTransform = _cachedTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rdi_v6 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rdi_v6 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out Vector3 _);
			Vector2 spawnPos = default(Vector2);
			bool forceSpawn = default(bool);
			GameObject gameObject = _stage.SpawnEnemy(EnemyType.BULLET_W, spawnPos, asRemote: false, forceSpawn);
			EnemyBulletW component = gameObject.GetComponent<EnemyBulletW>();
			_bullet = component;
			GenerateParticleSystems();
		}
		GameObject spritte = _spritte;
		if ((object)_spritte == null || ((UnityEngine.Object)spritte).m_CachedPtr == (IntPtr)0)
		{
			SpawnSpritte();
		}
	}

	public void Dismiss()
	{
		//IL_002c: Expected I, but got O
		_dismissed = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDrowner>)+390]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
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
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_030e->IL029b: Incompatible stack heights: 1 vs 0
		//IL_029b->IL02c4: Incompatible stack heights: 1 vs 0
		if (_invul || _hasLostTreasure)
		{
			return;
		}
		object obj2 = default(object);
		object obj = obj2 - 25;
		if ((nint)obj <= 49)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"bt rdx,rax\"");
			if ((nint)obj < 49)
			{
				goto IL_00b6;
			}
		}
		if ((nint)obj2 == 1612 || (nint)obj2 == 92)
		{
			goto IL_00b6;
		}
		return;
		IL_00b6:
		Dismiss();
		_hasLostTreasure = true;
		Treasure treasure = new Treasure();
		List<float> list = new List<float>();
		if (list != null)
		{
			list.Add(6f);
			list.Add(66f);
			list.Add(100f);
			if (treasure != null)
			{
				treasure.chances = list;
				List<PrizeType?> list2 = new List<PrizeType?>();
				if (list2 != null)
				{
					((List<float>)(object)list2).Add(100f);
					((List<float>)(object)list2).Add(100f);
					((List<float>)(object)list2).Add(100f);
					((List<float>)(object)list2).Add(100f);
					((List<float>)(object)list2).Add(100f);
					treasure.prizeTypes = list2;
					GameManager core = GM.Core;
					if ((object)GM.Core != null && (object)core._stage != null)
					{
						int num = core._stage.SetTreasureLevelFromChance(treasure);
						EnemyDrowner cachedTransform = (EnemyDrowner)(object)_cachedTransform;
						if ((object)_cachedTransform != null)
						{
							bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
							if ((object)GM.Core != null)
							{
								Vector2 pos = default(Vector2);
								TreasureChest treasureChest = GM.Core.MakeTreasure(pos, treasure);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
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

	private unsafe void HandleDrownerUpdate()
	{
		//IL_0230: Invalid comparison between F4 and O
		//IL_017b: Invalid comparison between F4 and O
		//IL_0d3c: Expected O, but got F4
		//IL_0cb6: Expected O, but got I4
		//IL_0534: Expected O, but got I4
		//IL_0ce1: Expected O, but got I4
		//IL_05a1: Expected O, but got I4
		//IL_0601: Expected O, but got I4
		//IL_080e: Expected O, but got I4
		//IL_0a27: Expected O, but got I4
		//IL_0b30->IL0ab5: Incompatible stack heights: 2 vs 0
		//IL_0c97->IL0c26: Incompatible stack heights: 1 vs 0
		PhaserScene.Renderer renderer;
		float value = default(float);
		float2 float5;
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
						object cachedTransform = _cachedTransform;
						bool flag = (object)_cachedTransform == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ rdi_v20 (System.Object)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ rdi_v20 (System.Object)+10]");
						Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value));
						_isFresh = false;
					}
					float5 = base.position;
					base._003CIsTeleportOnCull_003Ek__BackingField = false;
					base._003CSpeed_003Ek__BackingField = 0f;
					base.OnUpdate();
					float deltaTime = PauseSystem.DeltaTime;
					float num = deltaTime * 1000f;
					float num2 = num * 100f;
					num3 = num2 * 0.01f;
					if (!_dismissed)
					{
						goto IL_01e4;
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
								if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5) > System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5))
								{
									float num6 = (float)float5 + num3;
									if (!(num6 > num5))
									{
										goto IL_0d13;
									}
								}
								float num7 = (float)float5 - num3;
								if (num7 < num5)
								{
									goto IL_01e4;
								}
								goto IL_0d13;
							}
						}
					}
				}
			}
		}
		goto IL_0a69;
		IL_0d13:
		if (_playerOptions != null)
		{
			goto IL_0299;
		}
		goto IL_0a69;
		IL_01e4:
		float num9 = default(float);
		float num8 = num9 * 2f;
		float num10 = num8 * 0.5f;
		float num11 = (float)renderer.screenCenter - num10;
		float num12 = num11 + 0.96f;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num12) > System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5))
		{
			float num13 = (float)float5 + num3;
			if (!(num13 > num12))
			{
				goto IL_0d13;
			}
		}
		float num14 = (float)float5 - num3;
		if (num14 < num12)
		{
			goto IL_0299;
		}
		goto IL_0d13;
		IL_07c3:
		if ((object)_spritte != null)
		{
			_spritte.SetActive(value: true);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.PAN, soundConfig, 20000f, 1, time);
			if ((object)GM.Core != null)
			{
				if (!GM.Core.CheckValidToastieInputs())
				{
					return;
				}
				_done = true;
				if (_playerOptions != null)
				{
					PlayerOptionsData config = _playerOptions.Config;
					if (config != null && config._003CUnlockedCharacters_003Ek__BackingField != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
						object obj = default(object);
						if (obj != null)
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
										SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
										soundConfig2.Volume = (float?)(object)1;
										soundConfig2.Delay = -1000f;
										soundConfig2.Rate = 0.5f;
										PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.ThingFound, soundConfig2, 0f, 10, time);
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0a69;
		IL_0299:
		PlayerOptionsData config2 = _playerOptions.Config;
		if (config2 != null)
		{
			bool flag3 = config2._003CSelectedReapers_003Ek__BackingField;
			bool flag4 = true;
			if (!flag3)
			{
				flag4 = _FromTrisection;
			}
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				bool invul;
				if (!(core._003CSurvivedSeconds_003Ek__BackingField > 1800f))
				{
					invul = false;
				}
				else
				{
					bool flag5 = !flag4;
					invul = flag5;
				}
				_invul = invul;
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null)
				{
					float num15 = ((!(core2._003CSurvivedSeconds_003Ek__BackingField > 1800f) || flag4) ? 0.1f : 1.5f);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rax_v22 (PhaserScene+Renderer)+38]");
					float num16 = 0f + 0.12f;
					float num17 = default(float);
					bool flag6 = !(num16 > num17);
					float num18 = num17;
					if (!flag6)
					{
						num15 *= 0.01f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rax_v22 (PhaserScene+Renderer)+38]");
						num16 = 0f + 0.12f;
						if (num16 > num17)
						{
							num18 = num17 + num15;
							if (num18 > num16)
							{
								num18 = num16;
							}
						}
						else
						{
							num18 = num17 - num15;
							if (num18 < num16)
							{
								num18 = num16;
							}
						}
					}
					base.position = (float2)num9;
					object bullet = _bullet;
					if ((object)_bullet != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rdi_v10 (System.Object)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v665 @ rax_v25 (UnityEngine.Bounds)+10]");
							float num19 = 0f * 2f;
							float num20 = num19 * 0.5f;
							float num21 = num18;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rax_v22 (PhaserScene+Renderer)+38]");
							float num22 = num21 - 0f;
							if (!(num22 > num20) && (object)_bullet == null)
							{
								goto IL_0a69;
							}
							Transform transform = _bullet.transform;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1129 @ rax_v103 (UnityEngine.Transform)+10]");
							bool flag7 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1129 @ rax_v103 (UnityEngine.Transform)+10]");
							Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value));
							num16 = num9;
						}
					}
					object pfxEmitter = _pfxEmitter;
					bool flag8 = (object)_pfxEmitter == null;
					object obj2 = 0;
					if (!flag8)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rdi_v12 (System.Object)+10]");
						bool flag9 = (nint)0 == 0;
						obj2 = 0;
						if (!flag9)
						{
							if ((object)_pfxEmitter == null)
							{
								goto IL_0a69;
							}
							ParticleSystemRenderer component = _pfxEmitter.GetComponent<ParticleSystemRenderer>();
							bool flag10 = (object)component == null;
							obj2 = 0;
							if (!flag10)
							{
								bool flag11 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
								obj2 = 0;
								if (!flag11)
								{
									if ((object)_EnemyRenderer == null)
									{
										goto IL_0a69;
									}
									int sortingOrder = _EnemyRenderer.sortingOrder;
									int sortingOrder2 = sortingOrder - 1;
									component.sortingOrder = sortingOrder2;
									obj2 = 0;
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
						PlayerOptionsData config3 = _playerOptions.Config;
						if (config3 != null && config3._003CUnlockedCharacters_003Ek__BackingField != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
							object obj3 = default(object);
							if (obj3 != null)
							{
								return;
							}
							if (_playerOptions != null)
							{
								PlayerOptionsData config4 = _playerOptions.Config;
								if (config4 != null && config4._003CUnlockedCharacters_003Ek__BackingField != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
									object obj4 = default(object);
									if (obj4 == null)
									{
										return;
									}
									object spritte = _spritte;
									if ((object)_spritte != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rdi_v16 (System.Object)+10]");
										if ((nint)0 != 0)
										{
											goto IL_07c3;
										}
									}
									SpawnSpritte();
									goto IL_07c3;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0a69;
		IL_0a69:
		throw new NullReferenceException();
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
}
