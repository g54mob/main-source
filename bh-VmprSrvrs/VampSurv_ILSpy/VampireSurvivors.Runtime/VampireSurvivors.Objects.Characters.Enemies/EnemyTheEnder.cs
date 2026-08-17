using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.VFX;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyTheEnder : EnemyController
{
	private SpriteRenderer _ringSprite;

	private float _totalTime;

	private float _scytheTime;

	private float _shieldDamage;

	private int _deathScreamTimerLoopCount;

	private bool _hasShield;

	private bool _hasRunDeathLogic;

	private Timer _shieldTimer;

	private Timer _aiTimer;

	private Timer _deathScreamTimer;

	private ObjectPool _explosionPool;

	private DiContainer _diContainer;

	protected float _attacksDurationMultiplier = 1f;

	private readonly List<string> _defaultBag1;

	private readonly List<string> _defaultBag2;

	private readonly List<string> _defaultBag3;

	private readonly List<string> _defaultBag4;

	private readonly List<string> _defaultBag5;

	private readonly List<string> _defaultBag6;

	private readonly List<string> _defaultBag7;

	private readonly List<string> _defaultBag8;

	private Action _003COnDefeat_003Ek__BackingField;

	private bool _003CDropGospel_003Ek__BackingField;

	private float _003CShieldTime_003Ek__BackingField;

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

	public virtual bool DropGospel
	{
		get
		{
			return _003CDropGospel_003Ek__BackingField;
		}
		set
		{
			_003CDropGospel_003Ek__BackingField = value;
		}
	}

	public virtual float ShieldTime
	{
		get
		{
			return _003CShieldTime_003Ek__BackingField;
		}
		set
		{
			_003CShieldTime_003Ek__BackingField = value;
		}
	}

	protected override void FakeConstruct()
	{
		base.FakeConstruct();
		GameManager core = GM.Core;
		_diContainer = core._diContainer;
	}

	protected override void Awake()
	{
		base.Awake();
	}

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_00a5: Expected I4, but got O
		//IL_00b0: Expected I4, but got O
		//IL_011b: Expected I4, but got O
		//IL_0124->IL0268: Incompatible stack heights: 1 vs 0
		//IL_0145->IL0145: Incompatible stack heights: 1 vs 0
		_isImmuneToModification = true;
		base.InitEnemy(enemyType, asRemote);
		_003COnDefeat_003Ek__BackingField = null;
		_hasRunDeathLogic = false;
		if ((object)HeroVfxManager._factory != null)
		{
			ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.DamagingZones);
			_explosionPool = pool;
			SpriteRenderer ringSprite = _ringSprite;
			base._003CIsTeleportOnCull_003Ek__BackingField = true;
			_totalTime = 0f;
			_scytheTime = 5000f;
			if ((object)_ringSprite != null && ((UnityEngine.Object)ringSprite).m_CachedPtr != (IntPtr)0)
			{
				goto IL_0325;
			}
			bool flag = (byte)(int)_cachedTransform != 0;
			if ((int)(~_cachedTransform) == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rbx_v10 (System.Boolean)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rbx_v10 (System.Boolean)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 _);
				GameObject gameObject = base.gameObject;
				Vector2 pos = default(Vector2);
				SpriteRenderer component = RenderingExtensions.AddSprite(gameObject, pos, "vfx", "sPFX_ring_64");
				SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(component, 0f);
				Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
				if ((int)(~spriteRenderer) == 0)
				{
					((Renderer)spriteRenderer).SetMaterial(material);
					_ringSprite = spriteRenderer;
					goto IL_0325;
				}
			}
		}
		throw new NullReferenceException();
		IL_0325:
		if (_aiTimer != null)
		{
			_aiTimer.Cancel();
		}
		Action onComplete = TriggerExplosion;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer aiTimer = Timers.Register(5f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_aiTimer = aiTimer;
		_shieldDamage = 0f;
		_hasShield = true;
		if (_shieldTimer != null)
		{
			_shieldTimer.Cancel();
		}
		float shieldTime = ShieldTime;
		Action onComplete2 = delegate
		{
			float hp = _hp - _shieldDamage;
			_hasShield = false;
			_hp = hp;
		};
		float duration = 5f * 0.001f;
		Timer shieldTimer = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_shieldTimer = shieldTimer;
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_01e9: Invalid comparison between F4 and I4
		//IL_0261: Invalid comparison between I4 and F4
		//IL_028f: Expected O, but got I4
		//IL_02ab: Expected O, but got F4
		//IL_00c2: Expected F4, but got O
		//IL_0251->IL01d9: Incompatible stack heights: 1 vs 0
		//IL_0325->IL01d9: Incompatible stack heights: 1 vs 0
		//IL_00c7->IL00c7: Incompatible stack heights: 1 vs 0
		//IL_01ca->IL01ca: Incompatible stack heights: 1 vs 0
		if (!(value > 0f))
		{
			goto IL_00c7;
		}
		Vector3 ret;
		Vector2 vector = default(Vector2);
		float num = default(float);
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				if (!config._003CDamageNumbersEnabled_003Ek__BackingField)
				{
					goto IL_00c7;
				}
				object cachedTransform = _cachedTransform;
				if ((object)_cachedTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rdi_v12 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rdi_v12 (System.Object)+10]");
					Transform.get_position_Injected((IntPtr)0, out ret);
					if ((object)_gameManager != null)
					{
						_gameManager.ShowDamageAt(vector, value);
						num = (float)vector;
						goto IL_00c7;
					}
				}
			}
		}
		goto IL_01d9;
		IL_00c7:
		if (!_hasShield)
		{
			num = (_hp -= value);
		}
		else
		{
			float shieldDamage = value + _shieldDamage;
			_shieldDamage = shieldDamage;
		}
		if (0f < _hp)
		{
			_damageKb = damageKb;
		}
		else
		{
			Die();
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		float num2 = num - 0.5f;
		float num3 = num2 * 500f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Hit, soundConfig, 150f, 3, time);
		if (showHitVfx == HitVfxType.None)
		{
			goto IL_01ca;
		}
		object cachedTransform2 = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rdi_v11 (System.Object)+10]");
			bool flag2 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rdi_v11 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out ret);
			if ((object)_gameManager != null)
			{
				VFXManager.SpawnImpactVFX(showHitVfx, vector);
				goto IL_01ca;
			}
		}
		goto IL_01d9;
		IL_01d9:
		throw new NullReferenceException();
		IL_01ca:
		bool hasKb2 = default(bool);
		base.OnGetDamaged(showHitVfx, hasKb2);
	}

	protected override void OnUpdate()
	{
		//IL_00ca: Invalid comparison between I4 and F4
		//IL_00dc: Expected F4, but got I4
		//IL_0134->IL009f: Incompatible stack heights: 1 vs 0
		base.OnUpdate();
		if (!base._003CIsDead_003Ek__BackingField)
		{
			float num = ((!_hasShield) ? _hp : (_maxHp - _shieldDamage));
			float num2 = num / _maxHp;
			float num3 = num2 * 4000f;
			bool flag = !(0f < num3);
			float num4 = 0f;
			if (!flag)
			{
				num4 = num3;
			}
			float scytheTime = num4 + 500f;
			_scytheTime = scytheTime;
			float deltaTime = PauseSystem.DeltaTime;
			float num5 = deltaTime + _totalTime;
			float num6 = _scytheTime * 0.001f;
			_totalTime = num5;
			if (num5 > num6)
			{
				object cachedTransform = _cachedTransform;
				_totalTime = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rdi_v2 (System.Object)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rdi_v2 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 _);
				Vector2 spawnPos = default(Vector2);
				base.FireEnemyAsBullet(spawnPos, EnemyType.BULLET_SCYTHE);
			}
		}
	}

	private void StartVerySmartAI()
	{
		if (_aiTimer != null)
		{
			_aiTimer.Cancel();
		}
		Action onComplete = TriggerExplosion;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer aiTimer = Timers.Register(5f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_aiTimer = aiTimer;
	}

	private void ThrowScythe()
	{
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
		Vector2 spawnPos = default(Vector2);
		base.FireEnemyAsBullet(spawnPos, EnemyType.BULLET_SCYTHE);
	}

	private void TriggerExplosion()
	{
		//IL_01fa: Invalid comparison between F4 and I4
		bool flag = base._003CIsDead_003Ek__BackingField;
		EnemyTheEnder enemyTheEnder = this;
		IList<string> list;
		if (!flag)
		{
			bool hasStateAuthority = _coherenceSync.HasStateAuthority;
			bool flag2 = !hasStateAuthority;
			enemyTheEnder = this;
			if (!flag2)
			{
				bool flag3 = !_hasShield;
				float num = _maxHp / 9f;
				float num2 = (flag3 ? _hp : (_maxHp - _shieldDamage));
				float num3 = num2 / num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
				float num4 = 9f - num3;
				if (3f < num4)
				{
					if (5f < num4)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018777A1D4h\"");
						if (num4 != 6f)
						{
							goto IL_0259;
						}
						list = _defaultBag7;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018777A170h\"");
						if (num4 == 4f)
						{
							list = _defaultBag5;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018777A1D4h\"");
							if (num4 != 5f)
							{
								goto IL_0259;
							}
							list = _defaultBag6;
						}
					}
				}
				else if (1f < num4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018777A1A1h\"");
					if (num4 == 2f)
					{
						list = _defaultBag3;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018777A1D4h\"");
						if (num4 != 3f)
						{
							goto IL_0259;
						}
						list = _defaultBag4;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018777A1C4h\"");
					if (num4 == 0f)
					{
						list = _defaultBag1;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018777A1D4h\"");
						if (num4 != 1f)
						{
							goto IL_0259;
						}
						list = _defaultBag2;
					}
				}
				goto IL_0350;
			}
		}
		goto IL_02e5;
		IL_02e5:
		if (enemyTheEnder._aiTimer != null)
		{
			enemyTheEnder._aiTimer.Cancel();
		}
		return;
		IL_0259:
		list = _defaultBag8;
		goto IL_0350;
		IL_0350:
		string skinType = Extensions.PickRnd(list);
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			SpawnDamagingZonesLocally(skinType);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 289 Invalid \"Jump target not found in method: 0x18777A270\"");
		EnemyTheEnder enemyTheEnder2 = default(EnemyTheEnder);
		enemyTheEnder = enemyTheEnder2;
		goto IL_02e5;
	}

	private unsafe void SpawnDamagingZonesOnline(string skinType)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_001c: Expected O, but got I4
		//IL_0029: Expected O, but got I8
		//IL_0b04: Expected F4, but got I4
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_087e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0883: Expected Ref, but got Unknown
		//IL_089a: Expected I8, but got I4
		//IL_08a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a9: Expected Ref, but got Unknown
		//IL_08d2: Expected O, but got I4
		//IL_08db: Expected O, but got I4
		//IL_09b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ba: Expected Ref, but got Unknown
		//IL_09d1: Expected I8, but got I4
		//IL_09db: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e0: Expected Ref, but got Unknown
		//IL_0a09: Expected O, but got I4
		//IL_0a12: Expected O, but got I4
		//IL_05ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cf: Expected Ref, but got Unknown
		//IL_05e6: Expected I8, but got I4
		//IL_05f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f5: Expected Ref, but got Unknown
		//IL_061e: Expected O, but got I4
		//IL_0627: Expected O, but got I4
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0431: Expected Ref, but got Unknown
		//IL_0448: Expected I8, but got I4
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		//IL_0457: Expected Ref, but got Unknown
		//IL_0480: Expected O, but got I4
		//IL_0489: Expected O, but got I4
		//IL_0700: Unknown result type (might be due to invalid IL or missing references)
		//IL_0705: Expected Ref, but got Unknown
		//IL_071c: Expected I8, but got I4
		//IL_0726: Unknown result type (might be due to invalid IL or missing references)
		//IL_072b: Expected Ref, but got Unknown
		//IL_0754: Expected O, but got I4
		//IL_075d: Expected O, but got I4
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected Ref, but got Unknown
		//IL_018f: Expected I8, but got I4
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected Ref, but got Unknown
		//IL_01c7: Expected O, but got I4
		//IL_01d0: Expected O, but got I4
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Expected Ref, but got Unknown
		//IL_02ca: Expected I8, but got I4
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Expected Ref, but got Unknown
		//IL_0302: Expected O, but got I4
		//IL_030b: Expected O, but got I4
		object obj12;
		object obj;
		if (skinType != null)
		{
			obj = skinType + 20;
			object obj2 = 0;
			object obj3 = 2166136261L;
			while ((nint)obj2 < skinType._stringLength)
			{
				if ((nint)obj2 < skinType._stringLength)
				{
					obj2++;
					object obj4 = obj ^ obj3;
					obj3 = obj4 * 16777619;
					obj += 2;
					continue;
				}
				System.ThrowHelper.ThrowIndexOutOfRangeException();
				return;
			}
			if ((nint)obj3 > 961393281)
			{
				if ((nint)obj3 > 1932111646)
				{
					if ((long)obj3 == 2678344512L)
					{
						object obj5 = "Trainees";
						bool flag = (object)skinType == "Trainees";
						object obj6 = obj;
						if (flag)
						{
							goto IL_01de;
						}
						if ("Trainees" != null)
						{
							int stringLength = skinType._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v52+10]");
							if ((nint)stringLength == 0)
							{
								ref byte first = ref *(byte*)(skinType + 20);
								ulong length = (ulong)(skinType._stringLength + skinType._stringLength);
								bool flag2 = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("Trainees" + 20), length);
								bool flag3 = !flag2;
								obj6 = 0;
								obj = 0;
								if (!flag3)
								{
									goto IL_01de;
								}
							}
						}
					}
					else if ((long)obj3 == 4025533012L)
					{
						object obj7 = "DoubleExplosions";
						bool flag4 = (object)skinType == "DoubleExplosions";
						object obj8 = obj;
						if (flag4)
						{
							goto IL_0319;
						}
						if ("DoubleExplosions" != null)
						{
							int stringLength2 = skinType._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v44+10]");
							if ((nint)stringLength2 == 0)
							{
								ref byte first2 = ref *(byte*)(skinType + 20);
								ulong length2 = (ulong)(skinType._stringLength + skinType._stringLength);
								bool flag5 = System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("DoubleExplosions" + 20), length2);
								bool flag6 = !flag5;
								obj8 = 0;
								obj = 0;
								if (!flag6)
								{
									goto IL_0319;
								}
							}
						}
					}
				}
				else if ((nint)obj3 == 1932111646)
				{
					object obj9 = "DoubleCoffins";
					bool flag7 = (object)skinType == "DoubleCoffins";
					object obj10 = obj;
					if (flag7)
					{
						goto IL_0497;
					}
					if ("DoubleCoffins" != null)
					{
						int stringLength3 = skinType._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v36+10]");
						if ((nint)stringLength3 == 0)
						{
							ref byte first3 = ref *(byte*)(skinType + 20);
							ulong length3 = (ulong)(skinType._stringLength + skinType._stringLength);
							bool flag8 = System.SpanHelpers.SequenceEqual(ref first3, ref *(byte*)("DoubleCoffins" + 20), length3);
							bool flag9 = !flag8;
							obj10 = 0;
							obj = 0;
							if (!flag9)
							{
								goto IL_0497;
							}
						}
					}
				}
			}
			else if ((nint)obj3 > 493987261)
			{
				if ((nint)obj3 == 636945445)
				{
					object obj11 = "Coffins";
					bool flag10 = (object)skinType == "Coffins";
					obj12 = obj;
					if (flag10)
					{
						goto IL_0635;
					}
					if ("Coffins" != null)
					{
						int stringLength4 = skinType._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v33+10]");
						if ((nint)stringLength4 == 0)
						{
							ref byte first4 = ref *(byte*)(skinType + 20);
							ulong length4 = (ulong)(skinType._stringLength + skinType._stringLength);
							bool flag11 = System.SpanHelpers.SequenceEqual(ref first4, ref *(byte*)("Coffins" + 20), length4);
							bool flag12 = !flag11;
							obj12 = 0;
							obj = 0;
							if (!flag12)
							{
								goto IL_0635;
							}
						}
					}
				}
				else if ((nint)obj3 == 961393281)
				{
					object obj13 = "DoubleTrainees";
					bool flag13 = (object)skinType == "DoubleTrainees";
					object obj14 = obj;
					if (flag13)
					{
						goto IL_076b;
					}
					if ("DoubleTrainees" != null)
					{
						int stringLength5 = skinType._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v25+10]");
						if ((nint)stringLength5 == 0)
						{
							ref byte first5 = ref *(byte*)(skinType + 20);
							ulong length5 = (ulong)(skinType._stringLength + skinType._stringLength);
							bool flag14 = System.SpanHelpers.SequenceEqual(ref first5, ref *(byte*)("DoubleTrainees" + 20), length5);
							bool flag15 = !flag14;
							obj14 = 0;
							obj = 0;
							if (!flag15)
							{
								goto IL_076b;
							}
						}
					}
				}
			}
			else if ((nint)obj3 == 315793545)
			{
				object obj15 = "Explosions";
				bool flag16 = (object)skinType == "Explosions";
				object obj16 = obj;
				if (flag16)
				{
					goto IL_08e9;
				}
				if ("Explosions" != null)
				{
					int stringLength6 = skinType._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v21+10]");
					if ((nint)stringLength6 == 0)
					{
						ref byte first6 = ref *(byte*)(skinType + 20);
						ulong length6 = (ulong)(skinType._stringLength + skinType._stringLength);
						bool flag17 = System.SpanHelpers.SequenceEqual(ref first6, ref *(byte*)("Explosions" + 20), length6);
						bool flag18 = !flag17;
						obj16 = 0;
						obj = 0;
						if (!flag18)
						{
							goto IL_08e9;
						}
					}
				}
			}
			else if ((nint)obj3 == 493987261)
			{
				object obj17 = "DoubleWeapons";
				bool flag19 = (object)skinType == "DoubleWeapons";
				object obj18 = obj;
				if (flag19)
				{
					goto IL_0a20;
				}
				if ("DoubleWeapons" != null)
				{
					int stringLength7 = skinType._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rdx_v13+10]");
					if ((nint)stringLength7 == 0)
					{
						ref byte first7 = ref *(byte*)(skinType + 20);
						ulong length7 = (ulong)(skinType._stringLength + skinType._stringLength);
						bool flag20 = System.SpanHelpers.SequenceEqual(ref first7, ref *(byte*)("DoubleWeapons" + 20), length7);
						bool flag21 = !flag20;
						obj18 = 0;
						obj = 0;
						if (!flag21)
						{
							goto IL_0a20;
						}
					}
				}
			}
		}
		CoherenceSync coherenceSync = _coherenceSync;
		Action<float, bool, float> action = null;
		Action<float, bool, float> action2 = action;
		nint num = 0;
		goto IL_0b2c;
		IL_0a20:
		Action<float, bool, float> action3 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB34D0");
		bool param = default(bool);
		float param2 = default(float);
		bool flag22 = _coherenceSync.SendCommand(action3, MessageTarget.All, -150f, param, param2);
		coherenceSync = _coherenceSync;
		Action<float, bool, float> action4 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB34D0");
		float param3 = 150f;
		action2 = action4;
		goto IL_0b09;
		IL_0319:
		Action<float, bool, float> action5 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB34D0");
		bool flag23 = _coherenceSync.SendCommand(action5, MessageTarget.All, -100f, param, param2);
		coherenceSync = _coherenceSync;
		Action<float, bool, float> action6 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB34D0");
		param3 = 100f;
		action2 = action6;
		goto IL_0b09;
		IL_076b:
		Action<float, bool, float> action7 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB34D0");
		bool flag24 = _coherenceSync.SendCommand(action7, MessageTarget.All, -100f, param, param2);
		coherenceSync = _coherenceSync;
		Action<float, bool, float> action8 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB34D0");
		param3 = 100f;
		action2 = action8;
		goto IL_0b09;
		IL_08e9:
		coherenceSync = _coherenceSync;
		Action<float, bool, float> action9 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB34D0");
		action2 = action9;
		goto IL_0afb;
		IL_0497:
		Action<float, bool, float> action10 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB34D0");
		bool flag25 = _coherenceSync.SendCommand(action10, MessageTarget.All, -350f, param, param2);
		coherenceSync = _coherenceSync;
		Action<float, bool, float> action11 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB34D0");
		param3 = 350f;
		action2 = action11;
		goto IL_0b09;
		IL_0635:
		coherenceSync = _coherenceSync;
		action = null;
		action2 = action;
		num = 0;
		obj = obj12;
		goto IL_0b2c;
		IL_0b2c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB34D0");
		goto IL_0afb;
		IL_01de:
		coherenceSync = _coherenceSync;
		Action<float, bool, float> action12 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB34D0");
		action2 = action12;
		goto IL_0afb;
		IL_0afb:
		param3 = 0f;
		goto IL_0b09;
		IL_0b09:
		bool flag26 = coherenceSync.SendCommand(action2, MessageTarget.All, param3, param, param2);
	}

	private unsafe void SpawnDamagingZonesLocally(string skinType)
	{
		//IL_08fb: Expected F4, but got I4
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004a: Expected O, but got I4
		//IL_0057: Expected O, but got I8
		//IL_0060: Expected O, but got I4
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0758: Unknown result type (might be due to invalid IL or missing references)
		//IL_075d: Expected Ref, but got Unknown
		//IL_0774: Expected I8, but got I4
		//IL_077e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0783: Expected Ref, but got Unknown
		//IL_0864: Unknown result type (might be due to invalid IL or missing references)
		//IL_0869: Expected Ref, but got Unknown
		//IL_0880: Expected I8, but got I4
		//IL_088a: Unknown result type (might be due to invalid IL or missing references)
		//IL_088f: Expected Ref, but got Unknown
		//IL_0526: Unknown result type (might be due to invalid IL or missing references)
		//IL_052b: Expected Ref, but got Unknown
		//IL_0542: Expected I8, but got I4
		//IL_054c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0551: Expected Ref, but got Unknown
		//IL_03e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e5: Expected Ref, but got Unknown
		//IL_03fc: Expected I8, but got I4
		//IL_0406: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Expected Ref, but got Unknown
		//IL_0632: Unknown result type (might be due to invalid IL or missing references)
		//IL_0637: Expected Ref, but got Unknown
		//IL_064e: Expected I8, but got I4
		//IL_0658: Unknown result type (might be due to invalid IL or missing references)
		//IL_065d: Expected Ref, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected Ref, but got Unknown
		//IL_01c6: Expected I8, but got I4
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Expected Ref, but got Unknown
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Expected Ref, but got Unknown
		//IL_02d6: Expected I8, but got I4
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Expected Ref, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A643B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (skinType != null)
		{
			object obj = skinType + 20;
			object obj2 = 0;
			object obj3 = 2166136261L;
			object obj4 = 0;
			while ((nint)obj4 < skinType._stringLength)
			{
				if ((nint)obj2 < skinType._stringLength)
				{
					obj2++;
					object obj5 = obj ^ obj3;
					obj3 = obj5 * 16777619;
					obj += 2;
					obj4 = obj2;
					continue;
				}
				System.ThrowHelper.ThrowIndexOutOfRangeException();
				return;
			}
			if ((nint)obj3 > 961393281)
			{
				if ((nint)obj3 > 1932111646)
				{
					if ((long)obj3 == 2678344512L)
					{
						object obj6 = "Trainees";
						if ((object)skinType == "Trainees")
						{
							goto IL_0203;
						}
						if ("Trainees" != null)
						{
							int stringLength = skinType._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v24+10]");
							if ((nint)stringLength == 0)
							{
								ref byte first = ref *(byte*)(skinType + 20);
								ulong length = (ulong)(skinType._stringLength + skinType._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("Trainees" + 20), length))
								{
									goto IL_0203;
								}
							}
						}
					}
					else if ((long)obj3 == 4025533012L)
					{
						object obj7 = "DoubleExplosions";
						if ((object)skinType == "DoubleExplosions")
						{
							goto IL_0313;
						}
						if ("DoubleExplosions" != null)
						{
							int stringLength2 = skinType._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v21+10]");
							if ((nint)stringLength2 == 0)
							{
								ref byte first2 = ref *(byte*)(skinType + 20);
								ulong length2 = (ulong)(skinType._stringLength + skinType._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("DoubleExplosions" + 20), length2))
								{
									goto IL_0313;
								}
							}
						}
					}
				}
				else if ((nint)obj3 == 1932111646)
				{
					object obj8 = "DoubleCoffins";
					if ((object)skinType == "DoubleCoffins")
					{
						goto IL_0439;
					}
					if ("DoubleCoffins" != null)
					{
						int stringLength3 = skinType._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v18+10]");
						if ((nint)stringLength3 == 0)
						{
							ref byte first3 = ref *(byte*)(skinType + 20);
							ulong length3 = (ulong)(skinType._stringLength + skinType._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first3, ref *(byte*)("DoubleCoffins" + 20), length3))
							{
								goto IL_0439;
							}
						}
					}
				}
			}
			else if ((nint)obj3 > 493987261)
			{
				if ((nint)obj3 == 636945445)
				{
					object obj9 = "Coffins";
					if ((object)skinType == "Coffins")
					{
						goto IL_057f;
					}
					if ("Coffins" != null)
					{
						int stringLength4 = skinType._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v15+10]");
						if ((nint)stringLength4 == 0)
						{
							ref byte first4 = ref *(byte*)(skinType + 20);
							ulong length4 = (ulong)(skinType._stringLength + skinType._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first4, ref *(byte*)("Coffins" + 20), length4))
							{
								goto IL_057f;
							}
						}
					}
				}
				else if ((nint)obj3 == 961393281)
				{
					object obj10 = "DoubleTrainees";
					if ((object)skinType == "DoubleTrainees")
					{
						goto IL_068b;
					}
					if ("DoubleTrainees" != null)
					{
						int stringLength5 = skinType._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v12+10]");
						if ((nint)stringLength5 == 0)
						{
							ref byte first5 = ref *(byte*)(skinType + 20);
							ulong length5 = (ulong)(skinType._stringLength + skinType._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first5, ref *(byte*)("DoubleTrainees" + 20), length5))
							{
								goto IL_068b;
							}
						}
					}
				}
			}
			else if ((nint)obj3 == 315793545)
			{
				object obj11 = "Explosions";
				if ((object)skinType == "Explosions")
				{
					goto IL_07b1;
				}
				if ("Explosions" != null)
				{
					int stringLength6 = skinType._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rdx_v9+10]");
					if ((nint)stringLength6 == 0)
					{
						ref byte first6 = ref *(byte*)(skinType + 20);
						ulong length6 = (ulong)(skinType._stringLength + skinType._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref first6, ref *(byte*)("Explosions" + 20), length6))
						{
							goto IL_07b1;
						}
					}
				}
			}
			else if ((nint)obj3 == 493987261)
			{
				object obj12 = "DoubleWeapons";
				if ((object)skinType == "DoubleWeapons")
				{
					goto IL_08bd;
				}
				if ("DoubleWeapons" != null)
				{
					int stringLength7 = skinType._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v6+10]");
					if ((nint)stringLength7 == 0)
					{
						ref byte first7 = ref *(byte*)(skinType + 20);
						ulong length7 = (ulong)(skinType._stringLength + skinType._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref first7, ref *(byte*)("DoubleWeapons" + 20), length7))
						{
							goto IL_08bd;
						}
					}
				}
			}
		}
		float xOffset = 0f;
		float duration = 10000f;
		bool follow = true;
		goto IL_095a;
		IL_095a:
		DamagingZone_Weapons(xOffset, follow, duration);
		return;
		IL_068b:
		DamagingZone_Trainees(-100f, follow: false, 9000f);
		DamagingZone_Trainees(100f, follow: false, 9000f);
		return;
		IL_0203:
		DamagingZone_Trainees(0f, follow: true);
		return;
		IL_08bd:
		DamagingZone_Weapons(-150f);
		xOffset = 150f;
		duration = 10000f;
		follow = false;
		goto IL_095a;
		IL_07b1:
		DamagingZone_Explosions(0f, follow: true, 9000f);
		return;
		IL_057f:
		DamagingZone_Coffins(0f, follow: true);
		return;
		IL_0439:
		DamagingZone_Coffins(-350f, follow: true, 4000f);
		DamagingZone_Coffins(350f, follow: true, 4000f);
		return;
		IL_0313:
		DamagingZone_Explosions(-100f);
		DamagingZone_Explosions(100f);
	}

	public override void Disappear()
	{
		if (!_hasRunDeathLogic && _coherenceSync.HasStateAuthority)
		{
			_hasRunDeathLogic = true;
			FireCustomDeathLogic();
		}
	}

	protected override void Die()
	{
		if (!_hasRunDeathLogic && _coherenceSync.HasStateAuthority)
		{
			_hasRunDeathLogic = true;
			FireCustomDeathLogic();
		}
	}

	private bool CanRunDeathLogic()
	{
		//IL_008e: Expected I4, but got O
		if (!_hasRunDeathLogic)
		{
			if ((object)_coherenceSync == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			if (_coherenceSync.HasStateAuthority)
			{
				_hasRunDeathLogic = true;
				return true;
			}
		}
		return false;
	}

	public void OnlineDeath(long startingSimFrame)
	{
		Action onSyncedTimer = CustomDeathLogic;
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	private void FireCustomDeathLogic()
	{
		//IL_0094: Expected I8, but got O
		GameManager core = GM.Core;
		bool isOnlineMultiplayer = core._multiplayer.IsOnlineMultiplayer;
		EnemyTheEnder enemyTheEnder = this;
		if (!isOnlineMultiplayer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 78 Invalid \"Jump target not found in method: 0x18777B180\"");
			EnemyTheEnder enemyTheEnder2 = default(EnemyTheEnder);
			enemyTheEnder = enemyTheEnder2;
		}
		Action<long> action = null;
		((EnemyTheEnder)(object)action).OnlineDeath((long)enemyTheEnder);
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		bool flag = enemyTheEnder._coherenceSync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	private unsafe void CustomDeathLogic()
	{
		//IL_0052: Expected O, but got Ref
		//IL_09e6: Expected I, but got O
		//IL_09fc: Expected O, but got I
		//IL_0114: Expected I, but got O
		//IL_024b: Expected O, but got I
		//IL_0133: Expected I, but got O
		//IL_02a8: Expected O, but got I
		//IL_02dd: Expected O, but got I
		//IL_035d: Invalid comparison between F4 and I
		//IL_0404: Expected O, but got I
		//IL_0456: Expected O, but got I
		//IL_0541: Expected O, but got I
		//IL_056e: Expected I, but got O
		//IL_0581: Unknown result type (might be due to invalid IL or missing references)
		//IL_0586: Expected O, but got Unknown
		//IL_075d: Expected I, but got O
		//IL_0773: Expected O, but got I
		//IL_077c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0781: Expected O, but got Unknown
		//IL_07ea: Expected I, but got O
		//IL_0b02: Expected O, but got I4
		//IL_0b19: Expected I, but got I8
		//IL_0b47: Expected I4, but got F4
		//IL_0847: Expected I, but got O
		//IL_085d: Expected O, but got I
		//IL_0866: Unknown result type (might be due to invalid IL or missing references)
		//IL_086b: Expected O, but got Unknown
		//IL_07d3: Expected I, but got I8
		//IL_08d9: Expected I, but got O
		//IL_0b71: Expected I, but got I8
		//IL_0b9f: Expected I4, but got F4
		//IL_08ac: Expected I, but got I8
		//IL_050c->IL08de: Incompatible stack heights: 1 vs 0
		//IL_0561->IL08de: Incompatible stack heights: 2 vs 0
		//IL_0af4->IL08de: Incompatible stack heights: 1 vs 0
		//IL_05a9->IL0a76: Incompatible stack heights: 2 vs 0
		//IL_05ae->IL05ae: Incompatible stack heights: 2 vs 0
		//IL_069a->IL08de: Incompatible stack heights: 1 vs 0
		//IL_06e8->IL08de: Incompatible stack heights: 1 vs 0
		base.Die();
		Action action = _003COnDefeat_003Ek__BackingField;
		if (_003COnDefeat_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v52.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		ObjectPool explosionPool = _explosionPool;
		if ((object)_explosionPool != null)
		{
			IEnumerable<GameObject> allActiveObjects = _explosionPool.GetAllActiveObjects();
			if (allActiveObjects != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj = default(object);
				Dictionary<StageType, List<StageData>> dictionary = (Dictionary<StageType, List<StageData>>)(&obj);
				explosionPool = null;
				object obj2 = default(object);
				GameObject gameObject = default(GameObject);
				while (true)
				{
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						if (obj2 == null)
						{
							break;
						}
						bool flag = obj == null;
						explosionPool = null;
						if (!flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							bool flag2 = (object)gameObject == null;
							explosionPool = null;
							if (!flag2)
							{
								DamagingZone component = gameObject.GetComponent<DamagingZone>();
								bool flag3 = (object)component == null;
								nint num = (nint)typeof(UnityEngine.Object);
								if (!flag3)
								{
									bool flag4 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
									num = (nint)typeof(UnityEngine.Object);
									if (!flag4)
									{
										component.TriggerDespawnDelayed();
										num = (nint)component;
									}
								}
								explosionPool = (ObjectPool)num;
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				if (dictionary != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				if (_dataManager != null)
				{
					Dictionary<StageType, List<StageData>> convertedStages = _dataManager.GetConvertedStages();
					if (_playerOptions != null)
					{
						PlayerOptionsData config = _playerOptions.Config;
						if (config != null)
						{
							if (convertedStages != null)
							{
								object obj3 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item((System.Int32Enum)config._003CSelectedStage_003Ek__BackingField);
								if (obj3 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v874 @ rax_v49 (System.Object)+18]");
									if ((nint)0 > (nint)0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v874 @ rax_v49 (System.Object)+10]");
										object obj4 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v874 @ rax_v49 (System.Object)+10]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rax_v50+18]");
											if ((nint)0 > (nint)0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rax_v50+20]");
												object obj5 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rax_v50+20]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v691 @ rcx_v36+98]");
													object obj6 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v691 @ rcx_v36+98]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rax_v51+10]");
														bool flag5 = (nint)0 == 0;
														float num2 = 1800f;
														if (!flag5)
														{
															float num3 = default(float);
															num2 = num3;
														}
														explosionPool = (ObjectPool)(object)GM.Core;
														if ((object)GM.Core != null)
														{
															float num4 = num2 + 60f;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rcx_v39 (QFSW.MOP2.ObjectPool)+3E0]");
															if (num4 > 0f)
															{
																float num5 = num2 + 60f;
															}
															GameManager gameManager = _gameManager;
															if ((object)_gameManager != null)
															{
																gameManager._canRunTickerTimer = false;
																GameManager gameManager2 = _gameManager;
																if ((object)_gameManager != null)
																{
																	explosionPool = (ObjectPool)(object)gameManager2._stage;
																	if ((object)gameManager2._stage != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rcx_v39 (QFSW.MOP2.ObjectPool)+190]");
																		Dictionary<StageType, List<StageData>> dictionary2 = (Dictionary<StageType, List<StageData>>)0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rcx_v39 (QFSW.MOP2.ObjectPool)+190]");
																		bool flag6 = (nint)0 < (nint)0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rcx_v39 (QFSW.MOP2.ObjectPool)+190]");
																		if ((nint)0 != 0)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rbx_v21 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.StageType, System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>>)+18]");
																			Dictionary<StageType, List<StageData>> dictionary3 = (Dictionary<StageType, List<StageData>>)(-1);
																			if (flag6)
																			{
																				goto IL_05ae;
																			}
																			while (true)
																			{
																				GameManager gameManager3 = _gameManager;
																				if ((object)_gameManager == null)
																				{
																					break;
																				}
																				Stage stage = gameManager3._stage;
																				if ((object)gameManager3._stage == null)
																				{
																					break;
																				}
																				List<EnemyController> spawnedEnemies = stage._spawnedEnemies;
																				if (stage._spawnedEnemies == null)
																				{
																					break;
																				}
																				bool flag7 = (nint)dictionary3 >= spawnedEnemies._size;
																				explosionPool = (ObjectPool)(object)spawnedEnemies._items;
																				if (spawnedEnemies._items == null)
																				{
																					break;
																				}
																				Dictionary<StageType, List<StageData>> dictionary4 = dictionary3;
																				string text = explosionPool._name;
																				bool flag8 = System.Runtime.CompilerServices.Unsafe.As<Dictionary<StageType, List<StageData>>, UIntPtr>(ref dictionary4) >= System.Runtime.CompilerServices.Unsafe.As<string, UIntPtr>(ref text);
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rcx_v39 (QFSW.MOP2.ObjectPool)+20+v148 @ rbx_v24 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.StageType, System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>>)*8]");
																				explosionPool = (ObjectPool)0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rcx_v39 (QFSW.MOP2.ObjectPool)+20+v148 @ rbx_v24 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.StageType, System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>>)*8]");
																				if ((nint)0 == 0)
																				{
																					break;
																				}
																				nint num6 = (nint)explosionPool;
																				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1644 @ rax_v61 (Il2CppClass<QFSW.MOP2.ObjectPool>)+388] (should have been resolved before IL gen)");
																				dictionary3 = (Dictionary<StageType, List<StageData>>)(dictionary3 - 1);
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rcx_v39 (QFSW.MOP2.ObjectPool)+20+v148 @ rbx_v24 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.StageType, System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>>)*8]");
																				if ((nint)0 >= (nint)0)
																				{
																					continue;
																				}
																				goto IL_05ae;
																			}
																		}
																	}
																}
															}
														}
														goto IL_08de;
													}
													throw new NullReferenceException();
												}
												throw new NullReferenceException();
											}
											throw new IndexOutOfRangeException();
										}
										throw new NullReferenceException();
									}
									System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
		}
		goto IL_08de;
		IL_05ae:
		float num7 = default(float);
		Vector2 vector = default(Vector2);
		Action action2;
		if ((object)_gameManager != null)
		{
			_gameManager.TogglePlayerHealthBar(visible: false);
			SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, 0f, 500f);
			if ((object)GM.Core != null)
			{
				GM.Core.SetPlayersInvulForMillisecondsAndRestoreTints(30000f);
				Dictionary<StageType, List<StageData>> cachedTransform = (Dictionary<StageType, List<StageData>>)(object)_cachedTransform;
				if ((object)_cachedTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rbx_v27 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.StageType, System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>>)+10]");
					bool flag9 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rbx_v27 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.StageType, System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>>)+10]");
					Transform.get_position_Injected((IntPtr)0, out Vector3 _);
					if ((object)_gameManager != null)
					{
						Vector2 center = default(Vector2);
						_gameManager.StopCamera(center);
						ProCamera2D instance = ProCamera2D.Instance;
						bool flag10 = (object)instance == null;
						explosionPool = null;
						if (!flag10)
						{
							Com.LuisPedroFonseca.ProCamera2D.CameraTarget cameraTarget = instance.AddCameraTarget(_cachedTransform, 1f, 1f, num7, vector);
							SpriteAnimation spriteAnimation = _SpriteAnimation;
							if ((object)_SpriteAnimation != null)
							{
								((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
								DeathScream();
								_deathScreamTimerLoopCount = 0;
								action2 = null;
								nint num8 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1776 @ r10_v1 (Il2CppMethodInfo)+8]");
								((Delegate)action2).method_ptr = (IntPtr)0;
								((Delegate)action2).method = (nint)__ldftn(EnemyTheEnder._003CCustomDeathLogic_003Eb__48_0);
								((Delegate)action2).m_target = this;
								((Delegate)action2).method_code = (IntPtr)action2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1776 @ r10_v1 (Il2CppMethodInfo)+4C]");
								object obj7 = (nint)0 >> 4;
								object obj8 = obj7 & 1;
								nint num9;
								if (obj8 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1776 @ r10_v1 (Il2CppMethodInfo)+52]");
									if ((nint)0 == 0)
									{
										num9 = unchecked((nint)6447293664L);
										goto IL_0af9;
									}
								}
								((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
								num9 = ((Delegate)action2).method_ptr;
								goto IL_0af9;
							}
						}
					}
				}
			}
		}
		goto IL_08de;
		IL_0b5a:
		Action action3;
		((Delegate)action3).extra_arg = unchecked((nint)6447293568L);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(5f, action3, null, isLooped: false, (byte)(int)num7 != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
		return;
		IL_08de:
		throw new NullReferenceException();
		IL_0af9:
		object obj9 = 24;
		((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
		Timer deathScreamTimer = Timers.Register(1f, action2, null, isLooped: true, (byte)(int)num7 != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
		_deathScreamTimer = deathScreamTimer;
		action3 = null;
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1474 @ r10_v2 (Il2CppMethodInfo)+8]");
		((Delegate)action3).method_ptr = (IntPtr)0;
		((Delegate)action3).method = (nint)__ldftn(EnemyTheEnder._003CCustomDeathLogic_003Eb__48_1);
		((Delegate)action3).m_target = this;
		((Delegate)action3).method_code = (IntPtr)action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1474 @ r10_v2 (Il2CppMethodInfo)+4C]");
		object obj10 = (nint)0 >> 4;
		object obj11 = obj10 & 1;
		nint num11;
		if (obj11 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1474 @ r10_v2 (Il2CppMethodInfo)+52]");
			bool flag11 = (nint)0 == 0;
			num11 = unchecked((nint)6447293664L);
			if (flag11)
			{
				goto IL_0b5a;
			}
		}
		num11 = ((Delegate)action3).method_ptr;
		((Delegate)action3).method_code = (IntPtr)((Delegate)action3).m_target;
		goto IL_0b5a;
	}

	protected void DeathScream()
	{
		//IL_0193: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Deathscream, soundConfig, 150f, 2, time);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_ringSprite, 0f);
		TweenConfig tweenConfig = new TweenConfig();
		object[] targets = new object[1];
		Transform transform = _ringSprite.transform;
		if ((object)transform != null)
		{
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale((SpriteRenderer)(object)transform, 0f);
			if ((object)spriteRenderer2 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = targets;
		tweenConfig.duration = 300f;
		tweenConfig.repeat = 1;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			if ((object)_ringSprite != null)
			{
				Transform transform2 = _ringSprite.transform;
				Transform cachedTransform = _cachedTransform;
				if ((object)_cachedTransform != null)
				{
					bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
					bool flag2 = (object)transform2 == null;
					bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
					bool flag4 = (object)_ringSprite == null;
					_ringSprite.enabled = true;
					return;
				}
			}
			throw new NullReferenceException();
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			_ringSprite.enabled = false;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	protected virtual void SpecialDeathAnimation()
	{
		//IL_002c: Expected I, but got O
		//IL_0090: Expected O, but got I4
		//IL_00ac: Expected O, but got I4
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 5000f;
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.ease = Ease.InOutBounce;
		tweenConfig.scaleY = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	public void OnlineDamagingZone_Weapons(float xOffset, bool follow, float duration)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1 Invalid \"Jump target not found in method: 0x18777C180\"");
	}

	private unsafe void DamagingZone_Weapons(float xOffset = 0f, bool follow = false, float duration = 10000f)
	{
		//IL_0065: Expected O, but got Ref
		//IL_0065: Expected O, but got Ref
		//IL_0195: Expected O, but got F4
		//IL_0225->IL01a9: Incompatible stack heights: 1 vs 0
		//IL_0099->IL01a9: Incompatible stack heights: 1 vs 0
		//IL_00c5->IL01a9: Incompatible stack heights: 1 vs 0
		//IL_0137->IL01a9: Incompatible stack heights: 1 vs 0
		Camera main = Camera.main;
		if ((object)main != null)
		{
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				if ((object)_explosionPool != null)
				{
					object obj2 = default(object);
					object obj3 = default(object);
					GameObject obj = _explosionPool.GetObject((Vector3)(&obj2), (Quaternion)(&obj3));
					Component objectComponent = _explosionPool.GetObjectComponent<DamagingZone>(obj);
					if ((object)objectComponent != null)
					{
						GameObject gameObject = objectComponent.gameObject;
						if (_diContainer != null)
						{
							_diContainer.InjectGameObject(gameObject);
							Camera main2 = Camera.main;
							Bounds bounds = CameraExtensions.OrthographicBounds(main2);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ rax_v29 (UnityEngine.Bounds)+10]");
							float num = 0f * 2f;
							Camera main3 = Camera.main;
							if ((object)main3 != null)
							{
								Transform transform2 = main3.transform;
								float h = num * 100f;
								float num2 = _attacksDurationMultiplier * duration;
								float durationMillis = default(float);
								float hitBoxDelayMillis = default(float);
								string skinType = default(string);
								bool follow2 = default(bool);
								((DamagingZone)objectComponent).Init(100f, h, 12f, durationMillis, hitBoxDelayMillis, skinType, follow2, (Transform)num2);
								((DamagingZone)objectComponent)._003CLockY_003Ek__BackingField = true;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void OnlineDamagingZone_Coffins(float xOffset, bool follow, float duration)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1 Invalid \"Jump target not found in method: 0x18777C4D0\"");
	}

	private unsafe void DamagingZone_Coffins(float xOffset = 0f, bool follow = false, float duration = 10000f)
	{
		//IL_0065: Expected O, but got Ref
		//IL_0065: Expected O, but got Ref
		//IL_0195: Expected O, but got F4
		//IL_0225->IL01a9: Incompatible stack heights: 1 vs 0
		//IL_0099->IL01a9: Incompatible stack heights: 1 vs 0
		//IL_00c5->IL01a9: Incompatible stack heights: 1 vs 0
		//IL_0137->IL01a9: Incompatible stack heights: 1 vs 0
		Camera main = Camera.main;
		if ((object)main != null)
		{
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				if ((object)_explosionPool != null)
				{
					object obj2 = default(object);
					object obj3 = default(object);
					GameObject obj = _explosionPool.GetObject((Vector3)(&obj2), (Quaternion)(&obj3));
					Component objectComponent = _explosionPool.GetObjectComponent<DamagingZone>(obj);
					if ((object)objectComponent != null)
					{
						GameObject gameObject = objectComponent.gameObject;
						if (_diContainer != null)
						{
							_diContainer.InjectGameObject(gameObject);
							Camera main2 = Camera.main;
							Bounds bounds = CameraExtensions.OrthographicBounds(main2);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ rax_v29 (UnityEngine.Bounds)+10]");
							float num = 0f * 2f;
							Camera main3 = Camera.main;
							if ((object)main3 != null)
							{
								Transform transform2 = main3.transform;
								float h = num * 100f;
								float num2 = _attacksDurationMultiplier * duration;
								float durationMillis = default(float);
								float hitBoxDelayMillis = default(float);
								string skinType = default(string);
								bool follow2 = default(bool);
								((DamagingZone)objectComponent).Init(100f, h, 12f, durationMillis, hitBoxDelayMillis, skinType, follow2, (Transform)num2);
								((DamagingZone)objectComponent)._003CLockY_003Ek__BackingField = true;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void OnlineDamagingZone_Trainees(float yOffset, bool follow, float duration)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1 Invalid \"Jump target not found in method: 0x18777C820\"");
	}

	private unsafe void DamagingZone_Trainees(float yOffset = 0f, bool follow = false, float duration = 5000f)
	{
		//IL_0065: Expected O, but got Ref
		//IL_0065: Expected O, but got Ref
		//IL_018d: Expected O, but got F4
		//IL_0215->IL0199: Incompatible stack heights: 1 vs 0
		//IL_0099->IL0199: Incompatible stack heights: 1 vs 0
		//IL_00c5->IL0199: Incompatible stack heights: 1 vs 0
		//IL_012f->IL0199: Incompatible stack heights: 1 vs 0
		Camera main = Camera.main;
		if ((object)main != null)
		{
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				if ((object)_explosionPool != null)
				{
					object obj2 = default(object);
					GameObject obj = _explosionPool.GetObject((Vector3)(&ret), (Quaternion)(&obj2));
					Transform objectComponent = (Transform)(object)_explosionPool.GetObjectComponent<DamagingZone>(obj);
					if ((object)objectComponent != null)
					{
						GameObject gameObject = objectComponent.gameObject;
						if (_diContainer != null)
						{
							_diContainer.InjectGameObject(gameObject);
							Camera main2 = Camera.main;
							Bounds bounds = CameraExtensions.OrthographicBounds(main2);
							object obj3 = default(object);
							float num = (float)obj3 * 2f;
							Camera main3 = Camera.main;
							if ((object)main3 != null)
							{
								Transform transform2 = main3.transform;
								float w = num * 100f;
								float num2 = _attacksDurationMultiplier * duration;
								float durationMillis = default(float);
								float hitBoxDelayMillis = default(float);
								string skinType = default(string);
								bool follow2 = default(bool);
								((DamagingZone)(object)objectComponent).Init(w, 100f, 12f, durationMillis, hitBoxDelayMillis, skinType, follow2, (Transform)num2);
								_ = 1;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void OnlineDamagingZone_Explosions(float yOffset, bool follow, float duration)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1 Invalid \"Jump target not found in method: 0x18777CB80\"");
	}

	private unsafe void DamagingZone_Explosions(float yOffset = 0f, bool follow = false, float duration = 5000f)
	{
		//IL_0065: Expected O, but got Ref
		//IL_0065: Expected O, but got Ref
		//IL_018d: Expected O, but got F4
		//IL_0215->IL0199: Incompatible stack heights: 1 vs 0
		//IL_0099->IL0199: Incompatible stack heights: 1 vs 0
		//IL_00c5->IL0199: Incompatible stack heights: 1 vs 0
		//IL_012f->IL0199: Incompatible stack heights: 1 vs 0
		Camera main = Camera.main;
		if ((object)main != null)
		{
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				if ((object)_explosionPool != null)
				{
					object obj2 = default(object);
					GameObject obj = _explosionPool.GetObject((Vector3)(&ret), (Quaternion)(&obj2));
					Transform objectComponent = (Transform)(object)_explosionPool.GetObjectComponent<DamagingZone>(obj);
					if ((object)objectComponent != null)
					{
						GameObject gameObject = objectComponent.gameObject;
						if (_diContainer != null)
						{
							_diContainer.InjectGameObject(gameObject);
							Camera main2 = Camera.main;
							Bounds bounds = CameraExtensions.OrthographicBounds(main2);
							object obj3 = default(object);
							float num = (float)obj3 * 2f;
							Camera main3 = Camera.main;
							if ((object)main3 != null)
							{
								Transform transform2 = main3.transform;
								float w = num * 100f;
								float num2 = _attacksDurationMultiplier * duration;
								float durationMillis = default(float);
								float hitBoxDelayMillis = default(float);
								string skinType = default(string);
								bool follow2 = default(bool);
								((DamagingZone)(object)objectComponent).Init(w, 100f, 12f, durationMillis, hitBoxDelayMillis, skinType, follow2, (Transform)num2);
								_ = 1;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public EnemyTheEnder()
	{
		List<string> list = new List<string>();
		list._version++;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Trainees");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_defaultBag1 = list;
		List<string> list2 = new List<string>();
		list2._version++;
		string[] items2 = list2._items;
		if (list2._size >= items2.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"Coffins");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_defaultBag2 = list2;
		List<string> list3 = new List<string>();
		list3._version++;
		string[] items3 = list3._items;
		if (list3._size >= items3.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"DoubleTrainees");
		}
		else
		{
			list3._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list3._version++;
		string[] items4 = list3._items;
		if (list3._size >= items4.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"DoubleCoffins");
		}
		else
		{
			list3._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_defaultBag3 = list3;
		List<string> list4 = new List<string>();
		list4._version++;
		string[] items5 = list4._items;
		if (list4._size >= items5.Length)
		{
			((List<object>)(object)list4).AddWithResize((object)"Explosions");
		}
		else
		{
			list4._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_defaultBag4 = list4;
		List<string> list5 = new List<string>();
		list5._version++;
		string[] items6 = list5._items;
		if (list5._size >= items6.Length)
		{
			((List<object>)(object)list5).AddWithResize((object)"DoubleExplosions");
		}
		else
		{
			list5._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_defaultBag5 = list5;
		List<string> list6 = new List<string>();
		list6._version++;
		string[] items7 = list6._items;
		if (list6._size >= items7.Length)
		{
			((List<object>)(object)list6).AddWithResize((object)"Weapons");
		}
		else
		{
			list6._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_defaultBag6 = list6;
		List<string> list7 = new List<string>();
		list7._version++;
		string[] items8 = list7._items;
		if (list7._size >= items8.Length)
		{
			((List<object>)(object)list7).AddWithResize((object)"DoubleWeapons");
		}
		else
		{
			list7._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_defaultBag7 = list7;
		List<string> list8 = new List<string>();
		list8._version++;
		string[] items9 = list8._items;
		if (list8._size >= items9.Length)
		{
			((List<object>)(object)list8).AddWithResize((object)"Trainees");
		}
		else
		{
			list8._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list8._version++;
		string[] items10 = list8._items;
		if (list8._size >= items10.Length)
		{
			((List<object>)(object)list8).AddWithResize((object)"Coffins");
		}
		else
		{
			list8._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list8._version++;
		string[] items11 = list8._items;
		if (list8._size >= items11.Length)
		{
			((List<object>)(object)list8).AddWithResize((object)"Weapons");
		}
		else
		{
			list8._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list8._version++;
		string[] items12 = list8._items;
		if (list8._size >= items12.Length)
		{
			((List<object>)(object)list8).AddWithResize((object)"Explosions");
		}
		else
		{
			list8._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_defaultBag8 = list8;
		_003CDropGospel_003Ek__BackingField = true;
		_003CShieldTime_003Ek__BackingField = 90000f;
		base._002Ector();
	}

	private void _003CInitEnemy_003Eb__35_0()
	{
		float hp = _hp - _shieldDamage;
		_hasShield = false;
		_hp = hp;
	}

	private void _003CCustomDeathLogic_003Eb__48_0()
	{
		DeathScream();
		if (++_deathScreamTimerLoopCount >= 4 && _deathScreamTimer != null)
		{
			_deathScreamTimer.Cancel();
		}
	}

	private void _003CCustomDeathLogic_003Eb__48_1()
	{
		//IL_0292: Expected I, but got O
		//IL_02ac->IL01fd: Incompatible stack heights: 1 vs 0
		//IL_015f->IL015f: Incompatible stack heights: 1 vs 0
		SpecialDeathAnimation();
		GameManager gameManager = _gameManager;
		if ((object)_gameManager != null && (object)gameManager._WhiteHandManager != null)
		{
			gameManager._WhiteHandManager.SummonWhiteHand();
			if (!DropGospel)
			{
				goto IL_0164;
			}
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
					if (config._003CCollectedItems_003Ek__BackingField != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v19 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
							object obj = default(object);
							if ((nint)obj != -1)
							{
								goto IL_0164;
							}
						}
						PlayerOptionsData cachedTransform = (PlayerOptionsData)(object)_cachedTransform;
						if ((object)_cachedTransform != null)
						{
							bool flag = cachedTransform._003CsaveDate_003Ek__BackingField == null;
							Transform.get_position_Injected((IntPtr)cachedTransform._003CsaveDate_003Ek__BackingField, out Vector3 _);
							if ((object)_gameManager != null)
							{
								Vector2 pos = default(Vector2);
								float value = default(float);
								ItemType relicType = default(ItemType);
								bool validatePickups = default(bool);
								Pickup pickup = _gameManager.MakeStagePickup(pos, ItemType.RELIC, WeaponType.VOID, value, relicType, validatePickups);
								goto IL_0164;
							}
						}
					}
				}
			}
		}
		goto IL_01fd;
		IL_01fd:
		throw new NullReferenceException();
		IL_0164:
		ProCamera2D instance = ProCamera2D.Instance;
		if ((object)instance != null)
		{
			instance.RemoveCameraTarget(_cachedTransform, 0.2f);
			if ((object)_gameManager != null)
			{
				_gameManager.AddAllPlayersAsCameraTargets(0.2f);
				if ((object)_gameManager != null)
				{
					_gameManager.SetPlayerWorldBoundCollision(on: false);
					return;
				}
			}
		}
		goto IL_01fd;
	}

	private void _003CDeathScream_003Eb__49_0()
	{
		if ((object)_ringSprite != null)
		{
			Transform transform = _ringSprite.transform;
			Transform cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
				bool flag2 = (object)transform == null;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				bool flag4 = (object)_ringSprite == null;
				_ringSprite.enabled = true;
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void _003CDeathScream_003Eb__49_1()
	{
		_ringSprite.enabled = false;
	}
}
