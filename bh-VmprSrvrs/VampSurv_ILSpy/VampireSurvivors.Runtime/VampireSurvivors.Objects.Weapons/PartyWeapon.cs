using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class PartyWeapon : Weapon
{
	private ParticleEmitterManager _pfxEmitter;

	private ParticleSystem _emitter1;

	private GravityWell _well1;

	protected uint[] CircleColors = new uint[8] { 12255232u, 12263970u, 13369344u, 11141120u, 12255232u, 12255232u, 12255232u, 12255232u };

	protected uint[] StarColors = new uint[8] { 12303104u, 12303138u, 13421568u, 11184640u, 12303104u, 12303104u, 12303104u, 12303104u };

	protected uint[] TriangleColors = new uint[8] { 12281344u, 12281378u, 13395456u, 11167232u, 12281344u, 12281344u, 12281344u, 12281344u };

	protected uint[] HeartColors = new uint[8] { 12255334u, 12264038u, 13369446u, 11141222u, 12255334u, 12255334u, 12255334u, 12255334u };

	private int _colorIndex;

	private readonly int _maxColors = 8;

	private PartyCounterWeapon _counterWeapon;

	private WeaponType _counterWeaponType = WeaponType.PARTY_COUNTER;

	[NonSerialized]
	public int FireType;

	[NonSerialized]
	public bool FrontFiring = true;

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Expected O, but got I
		//IL_0210: Expected O, but got I
		//IL_022c: Expected O, but got I4
		//IL_0245: Expected O, but got Ref
		//IL_0254: Expected O, but got I4
		//IL_0262: Expected native int or pointer, but got O
		//IL_0480: Expected O, but got I4
		//IL_027a: Expected O, but got Ref
		//IL_0294: Expected native int or pointer, but got O
		//IL_049d: Expected O, but got I4
		//IL_02c6: Expected O, but got Ref
		//IL_02fb: Expected O, but got I
		//IL_0315: Expected native int or pointer, but got O
		//IL_04d7: Expected O, but got I
		//IL_034d: Expected O, but got Ref
		//IL_0367: Expected native int or pointer, but got O
		//IL_0511: Expected O, but got I
		//IL_039f: Expected O, but got Ref
		//IL_03b9: Expected native int or pointer, but got O
		//IL_03d3: Expected O, but got I
		//IL_0401: Expected O, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitWeapon(characterController, weaponType);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager pfxEmitter;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 200))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C8]");
			pfxEmitter = (ParticleEmitterManager)0;
		}
		else
		{
			pfxEmitter = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_pfxEmitter = pfxEmitter;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"2Spell1");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"WhiteDot");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C8]");
		particleSystemConfig._quantity = (int?)(object)0;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(2000f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
		_ = 0;
		obj = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1f, 0f));
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(2f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+10]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+20]");
		_ = 0;
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
		_ = 0;
		particleSystemConfig._on = true;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C8]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 200f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+40]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
		particleSystemConfig._speedX = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(-100f, -200f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-38]");
		particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(225f, 315f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+80]");
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(300f);
		particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem emitter = _pfxEmitter.CreateEmitter(particleSystemConfig, null, "ParticleEmitter");
		_emitter1 = emitter;
		RenderingExtensions.Start(_emitter1);
		RenderingExtensions.StopEmitting(_emitter1);
	}

	private void PickType()
	{
		int[] array = new int[5] { 0, 1, 2, 3, 4 };
		int seed = default(int);
		System.Random random = new System.Random(seed);
		seed = System.Random.GenerateSeed();
		random._002Ector(seed);
		int num = random.Next(0, array.Length);
		FireType = array[num];
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_00b0: Expected O, but got I4
		//IL_0138: Expected O, but got I4
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected O, but got Unknown
		//IL_0199: Expected O, but got Ref
		int[] array = new int[5] { 0, 1, 2, 3, 4 };
		int seed = default(int);
		System.Random random = new System.Random(seed);
		seed = System.Random.GenerateSeed();
		random._002Ector(seed);
		int num = random.Next(0, array.Length);
		FireType = array[num];
		base.Fire(skipTriggers);
		float chanceFromArray = base.GetChanceFromArray();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		object obj = default(object);
		float detune = (float)obj * -600f;
		soundConfig.Rate = 1f;
		soundConfig.Detune = detune;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Party, soundConfig, 200f, 10, time);
		bool flag;
		if (FrontFiring)
		{
			bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
			flag = (byte)((flipX ? 1u : 0u) ^ 1u) != 0;
		}
		else
		{
			flag = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
		}
		object obj2 = (flag ? 1 : 0) ^ 1;
		object obj3 = obj2 * 2;
		object obj4 = obj3 - 1;
		float max = (float)obj4 * 200f;
		float min = (float)obj4 * 100f;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(min, max);
		object obj5 = default(object);
		RenderingExtensions.SetSpeedX(_emitter1, (ParticleSystem.MinMaxCurve)(&obj5));
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 pos = default(Vector2);
		RenderingExtensions.EmitParticleAt(_emitter1, pos, 64);
		PartyCounterWeapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			_counterWeapon.Fire();
		}
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_0079: Expected I, but got O
		//IL_0087: Expected I, but got O
		//IL_0097: Expected O, but got I
		//IL_0117: Expected O, but got I4
		//IL_00d3: Expected O, but got I
		//IL_0109: Expected O, but got I4
		GameManager core = GM.Core;
		Projectile projectile;
		Projectile projectile2;
		object obj3;
		if (core._stage.IsCharacterNearYourPlayer(((Equipment)this)._003COwner_003Ek__BackingField))
		{
			float2 pos2 = default(float2);
			projectile = _projectilePool.SpawnAt(pos2, this, index);
			bool flag = (object)projectile == null;
			projectile2 = null;
			if (!flag)
			{
				nint num = (nint)projectile;
				nint num2 = (nint)typeof(PartyProjectile);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.PartyProjectile>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.PartyProjectile>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rax_v49+FFFFFFF8+v335 @ rax_v45*8]");
					if (0 == (nint)typeof(PartyProjectile))
					{
						obj3 = 1;
						goto IL_023b;
					}
				}
				obj3 = 0;
				goto IL_023b;
			}
			goto IL_0263;
		}
		return null;
		IL_023b:
		bool flag2 = obj3 == null;
		projectile2 = null;
		if (!flag2)
		{
			projectile2 = projectile;
		}
		goto IL_0263;
		IL_0263:
		if ((object)projectile2 != null && ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
		{
			int type;
			if (FireType != 4)
			{
				type = FireType;
			}
			else
			{
				int[] array = new int[4] { 0, 1, 2, 3 };
				int seed = default(int);
				System.Random random = new System.Random(seed);
				seed = System.Random.GenerateSeed();
				random._002Ector(seed);
				int num4 = random.Next(0, array.Length);
				if (num4 >= array.Length)
				{
					return (Projectile)(object)new IndexOutOfRangeException();
				}
				type = array[num4];
			}
			((PartyProjectile)projectile2).SetType(type);
			Transform target2 = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			projectile2.SetTarget(target2);
		}
		return projectile2;
	}

	public uint GetRandomCircleColor()
	{
		//IL_00a0: Expected I4, but got O
		if (++_colorIndex >= _maxColors)
		{
			_colorIndex = 0;
		}
		uint[] circleColors = CircleColors;
		int colorIndex = _colorIndex;
		if (_colorIndex < circleColors.Length)
		{
			return circleColors[colorIndex];
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (uint)(int)ex;
	}

	public uint GetRandomStarColor()
	{
		//IL_00a0: Expected I4, but got O
		if (++_colorIndex >= _maxColors)
		{
			_colorIndex = 0;
		}
		uint[] starColors = StarColors;
		int colorIndex = _colorIndex;
		if (_colorIndex < starColors.Length)
		{
			return starColors[colorIndex];
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (uint)(int)ex;
	}

	public uint GetRandomTriangleColor()
	{
		//IL_00a0: Expected I4, but got O
		if (++_colorIndex >= _maxColors)
		{
			_colorIndex = 0;
		}
		uint[] triangleColors = TriangleColors;
		int colorIndex = _colorIndex;
		if (_colorIndex < triangleColors.Length)
		{
			return triangleColors[colorIndex];
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (uint)(int)ex;
	}

	public uint GetRandomHeartColor()
	{
		//IL_00a0: Expected I4, but got O
		if (++_colorIndex >= _maxColors)
		{
			_colorIndex = 0;
		}
		uint[] heartColors = HeartColors;
		int colorIndex = _colorIndex;
		if (_colorIndex < heartColors.Length)
		{
			return heartColors[colorIndex];
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (uint)(int)ex;
	}

	public unsafe override void CheckArcanas()
	{
		//IL_011a: Expected O, but got Ref
		//IL_01ac: Expected I, but got O
		//IL_01ba: Expected I, but got O
		//IL_01ca: Expected O, but got I
		//IL_024a: Expected O, but got I4
		//IL_0206: Expected O, but got I
		//IL_023c: Expected O, but got I4
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager2 = core._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj2 = default(object);
		if ((nint)obj2 <= -1)
		{
			goto IL_0348;
		}
		GameSessionData gameSessionData = _gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
		CharacterData currentCharacterData = activeCharacter._currentCharacterData;
		object obj3 = default(object);
		string text = ((Enum)(&obj3)).ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B2E0");
		object obj4 = default(object);
		if (obj4 != null)
		{
			return;
		}
		GameManager core2 = GM.Core;
		bool allowDuplicates = default(bool);
		Weapon weapon = core2._weaponsFacade.AddHiddenWeapon(_counterWeaponType, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates);
		bool flag = (object)weapon == null;
		Weapon weapon2 = null;
		object obj7;
		if (!flag)
		{
			nint num = (nint)weapon;
			nint num2 = (nint)typeof(PartyCounterWeapon);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v482 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.PartyCounterWeapon>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v482 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.PartyCounterWeapon>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ rax_v48+FFFFFFF8+v483 @ rax_v44*8]");
				if (0 == (nint)typeof(PartyCounterWeapon))
				{
					obj7 = 1;
					goto IL_036c;
				}
			}
			obj7 = 0;
			goto IL_036c;
		}
		goto IL_0393;
		IL_036c:
		bool flag2 = obj7 == null;
		weapon2 = null;
		if (!flag2)
		{
			weapon2 = weapon;
		}
		goto IL_0393;
		IL_0393:
		if ((object)weapon2 != null && ((UnityEngine.Object)weapon2).m_CachedPtr != (IntPtr)0)
		{
			_counterWeapon = (PartyCounterWeapon)weapon2;
			PartyCounterWeapon counterWeapon = _counterWeapon;
			if (counterWeapon._firingTimer != null)
			{
				counterWeapon._firingTimer.Cancel();
			}
			if (((Weapon)counterWeapon)._firingAnimEvent != null)
			{
				((Weapon)counterWeapon)._firingAnimEvent.Cancel();
			}
			while (((Equipment)weapon2)._003CLevel_003Ek__BackingField < ((Equipment)this)._003CLevel_003Ek__BackingField)
			{
				bool flag3 = weapon2.LevelUp();
			}
		}
		goto IL_0348;
		IL_0348:
		CheckBeginningArcana();
	}

	public override bool LevelUp()
	{
		//IL_0077: Expected I4, but got O
		bool result = LevelUp(skipFire: false);
		PartyCounterWeapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			bool flag = _counterWeapon.LevelUp();
		}
		return result;
	}

	public override void ParadoxFire()
	{
		Fire(skipTriggers: true);
		Action onComplete = delegate
		{
			Fire(skipTriggers: true);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete2 = delegate
		{
			Fire(skipTriggers: true);
		};
		Timer timer2 = Timers.Register(0.2f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void _003CParadoxFire_003Eb__23_0()
	{
		Fire(skipTriggers: true);
	}

	private void _003CParadoxFire_003Eb__23_1()
	{
		Fire(skipTriggers: true);
	}
}
