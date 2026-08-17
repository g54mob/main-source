using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Lapiste2_Projectile : Projectile
{
	private Transform _BodyTarget;

	private TP_Lapiste2_Weapon _trueWeapon;

	private TP_Lapiste2_InvisibleProjectile _invisibleProjectile;

	private float _initialRotation;

	private PhaserSprite _fistSprite;

	private ParticleEmitterManager _pfxEmitter;

	private ParticleSystem _projEmitter;

	private MultiTargetTween _scaleTween;

	private Timer _launchTimer;

	private unsafe SpriteTextureData FistSprite1
	{
		get
		{
			//IL_0063: Expected native int or pointer, but got O
			SpriteTextures.SpriteTexturesThosepeople thosepeople = SpriteTextures.Thosepeople;
			if (SpriteTextures.Thosepeople != null && thosepeople.Thosepeople != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A1659]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				SpriteTextureData spriteTextureData = default(SpriteTextureData);
				System.Runtime.CompilerServices.Unsafe.Write(&((SpriteTextureData*)(nint)spriteTextureData)->Sprite, "TP_VFX_Lapiste01");
				return spriteTextureData;
			}
			return (SpriteTextureData)new NullReferenceException();
		}
	}

	private unsafe SpriteTextureData FistSprite2
	{
		get
		{
			//IL_0063: Expected native int or pointer, but got O
			SpriteTextures.SpriteTexturesThosepeople thosepeople = SpriteTextures.Thosepeople;
			if (SpriteTextures.Thosepeople != null && thosepeople.Thosepeople != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A165A]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				SpriteTextureData spriteTextureData = default(SpriteTextureData);
				System.Runtime.CompilerServices.Unsafe.Write(&((SpriteTextureData*)(nint)spriteTextureData)->Sprite, "TP_VFX_Lapiste02");
				return spriteTextureData;
			}
			return (SpriteTextureData)new NullReferenceException();
		}
	}

	private float[] FireAngles => new float[13]
	{
		0f, -15f, 15f, -30f, 30f, -5f, 5f, -20f, 20f, -10f,
		10f, -25f, 25f
	};

	protected override void Awake()
	{
		//IL_0115: Expected O, but got I4
		//IL_0131: Expected O, but got I4
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		SpriteTextures.SpriteTexturesThosepeople thosepeople = SpriteTextures.Thosepeople;
		if (thosepeople.Thosepeople != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A1659]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Lapiste01");
			PhaserSprite phaserSprite2 = phaserSprite.setOrigin(0f, (float?)(object)1);
			PhaserSprite phaserSprite3 = phaserSprite2.setScale(0.7f, (float?)(object)0);
			GameObject gameObject2 = phaserSprite3.gameObject;
			((UnityEngine.Object)gameObject2).SetName("FistSprite");
			_fistSprite = phaserSprite3;
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 612 Invalid \"Jump target not found in method: 0x18712DB70\"");
		}
		throw new NullReferenceException();
	}

	private unsafe void GeneratePfx()
	{
		//IL_0008: Expected O, but got Ref
		//IL_019a: Expected O, but got Ref
		//IL_01b4: Expected native int or pointer, but got O
		//IL_0720: Expected O, but got I4
		//IL_01e5: Expected O, but got I
		//IL_0201: Expected O, but got I4
		//IL_021a: Expected O, but got Ref
		//IL_0234: Expected native int or pointer, but got O
		//IL_073d: Expected O, but got I4
		//IL_0266: Expected O, but got Ref
		//IL_0280: Expected native int or pointer, but got O
		//IL_0777: Expected O, but got I
		//IL_04df: Expected O, but got Ref
		//IL_04f9: Expected native int or pointer, but got O
		//IL_07b1: Expected O, but got I
		//IL_0531: Expected O, but got Ref
		//IL_054b: Expected native int or pointer, but got O
		//IL_0565: Expected O, but got I
		//IL_0585: Expected O, but got Ref
		//IL_059f: Expected native int or pointer, but got O
		//IL_05b9: Expected O, but got I
		//IL_05f2: Expected O, but got I
		//IL_061c: Expected O, but got I4
		//IL_0635: Expected O, but got Ref
		//IL_064f: Expected native int or pointer, but got O
		//IL_07eb: Expected O, but got I
		//IL_0687: Expected O, but got Ref
		//IL_06a1: Expected native int or pointer, but got O
		//IL_081d: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		ParticleEmitterManager pfxEmitter = gameObject.AddComponent<ParticleEmitterManager>();
		_pfxEmitter = pfxEmitter;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxGreen");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxYellow");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(15.000001f, 30.000002f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+180]");
		particleSystemConfig._quantity = (int?)(object)0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(100f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+70]");
		_ = 0;
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+90]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
		_ = 0;
		particleSystemConfig._on = false;
		ParticleSystem particleSystem = _pfxEmitter.CreateEmitter(particleSystemConfig);
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
		int version3 = list2._version + 1;
		list2._version = version3;
		string[] items3 = list2._items;
		if (list2._size >= items3.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"ProjectileBlue1");
		}
		else
		{
			int num3 = list2._size + 1;
			list2._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list2._version + 1;
		list2._version = version4;
		string[] items4 = list2._items;
		if (list2._size >= items4.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"ProjectileBlue2");
		}
		else
		{
			int num4 = list2._size + 1;
			list2._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list2._version + 1;
		list2._version = version5;
		string[] items5 = list2._items;
		if (list2._size >= items5.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"PfxLightGreen");
		}
		else
		{
			int num5 = list2._size + 1;
			list2._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(15.000001f, 30.000002f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-38]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C0]");
		particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+D0]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 180f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
		particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F0]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+180]");
		particleSystemConfig2._quantity = (int?)(object)0;
		particleSystemConfig2._angleSteps = 16;
		minMaxCurve2 = new ParticleSystem.MinMaxCurve(100f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+100]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+110]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-10]");
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+10]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(0f, 2f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+120]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+130]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+18]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+38]");
		_ = 0;
		particleSystemConfig2._on = false;
		ParticleSystem projEmitter = _pfxEmitter.CreateEmitter(particleSystemConfig2);
		_projEmitter = projEmitter;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I4, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		//IL_00f1: Expected O, but got I4
		//IL_014d: Expected O, but got Ref
		//IL_0404: Expected O, but got F4
		//IL_040e: Invalid comparison between F4 and I4
		//IL_026b: Invalid comparison between F4 and O
		//IL_0294: Invalid comparison between O and F4
		//IL_0487: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		TP_Lapiste2_Weapon trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = null;
			goto IL_03b3;
		}
		nint num = (nint)typeof(TP_Lapiste2_Weapon);
		int num2 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v34 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Lapiste2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r9_v12 (System.Int32)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v34 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Lapiste2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r9_v12 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v103+FFFFFFF8+v69 @ rax_v98*8]");
			if (0 == (nint)typeof(TP_Lapiste2_Weapon))
			{
				obj3 = 1;
				goto IL_03c2;
			}
		}
		obj3 = 0;
		goto IL_03c2;
		IL_03c2:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = (TP_Lapiste2_Weapon)_weapon;
		}
		goto IL_03b3;
		IL_03b3:
		_trueWeapon = trueWeapon;
		BaseBody baseBody = body;
		_speed = 0.1f;
		baseBody._checkCollision = (ArcadeBodyCollision)0;
		CreateInvisibleBody();
		float num4 = _weapon.PArea();
		float num5 = default(float);
		bool flag2 = 2f > num5;
		float max = 2f;
		if (!flag2)
		{
			max = num5;
		}
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f, max);
		object obj4 = default(object);
		RenderingExtensions.SetScale(_projEmitter, (ParticleSystem.MinMaxCurve)(&obj4));
		object obj5 = UnityEngine.Random.value;
		bool num6;
		string text;
		if (0.5f > 0f)
		{
			SpriteTextures.SpriteTexturesThosepeople thosepeople = SpriteTextures.Thosepeople;
			bool flag3 = thosepeople.Thosepeople == null;
			num6 = flag3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A165A]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			text = "TP_VFX_Lapiste02";
		}
		else
		{
			SpriteTextures.SpriteTexturesThosepeople thosepeople2 = SpriteTextures.Thosepeople;
			bool flag4 = thosepeople2.Thosepeople == null;
			num6 = flag4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A1659]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			text = "TP_VFX_Lapiste01";
		}
		PhaserSprite fistSprite = _fistSprite;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
		Sprite sprite = SpriteManager.GetSprite(text, text);
		fistSprite._spriteRenderer.sprite = sprite;
		float num7 = _weapon.PArea();
		bool flag5 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) >= System.Runtime.CompilerServices.Unsafe.As<string, UIntPtr>(ref text);
		float alpha = 1f;
		if (!flag5)
		{
			if (System.Runtime.CompilerServices.Unsafe.As<string, UIntPtr>(ref text) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)5f))
			{
				float num8 = (float)text - 1f;
				float num9 = num8 * 0.5f;
				float num10 = num9 * 0.25f;
				alpha = 1f - num10;
			}
			else
			{
				alpha = 0.5f;
			}
		}
		PhaserSprite phaserSprite = _fistSprite.setAlpha(alpha);
		PhaserSprite phaserSprite2 = _fistSprite.setDepth(_indexInWeapon);
		float2 float5 = base.position;
		float2 float6 = default(float2);
		base.position = float6;
		ScaleIn();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
		{
			Rate = 1f
		};
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Lapiste, soundConfig, 200f, 5, time);
	}

	private void CreateInvisibleBody()
	{
		//IL_0057: Expected I, but got O
		//IL_0065: Expected I, but got O
		//IL_0075: Expected O, but got I
		//IL_00f5: Expected O, but got I4
		//IL_00b1: Expected O, but got I
		//IL_00e7: Expected O, but got I4
		//IL_024a->IL0214: Incompatible stack heights: 1 vs 0
		TP_Lapiste2_Weapon trueWeapon = _trueWeapon;
		float2 pos = default(float2);
		Projectile projectile = trueWeapon._invisibleProjectilePool.SpawnAt(pos, _weapon);
		bool flag = (object)projectile == null;
		Projectile invisibleProjectile = null;
		if (flag)
		{
			goto IL_01bf;
		}
		nint num = (nint)projectile;
		nint num2 = (nint)typeof(TP_Lapiste2_InvisibleProjectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Lapiste2_InvisibleProjectile>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Lapiste2_InvisibleProjectile>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rax_v50+FFFFFFF8+v216 @ rax_v46*8]");
			if (0 == (nint)typeof(TP_Lapiste2_InvisibleProjectile))
			{
				obj3 = 1;
				goto IL_01ce;
			}
		}
		obj3 = 0;
		goto IL_01ce;
		IL_01bf:
		_invisibleProjectile = (TP_Lapiste2_InvisibleProjectile)invisibleProjectile;
		TP_Lapiste2_InvisibleProjectile invisibleProjectile2 = _invisibleProjectile;
		if ((object)_invisibleProjectile != null && ((UnityEngine.Object)invisibleProjectile2).m_CachedPtr != (IntPtr)0)
		{
			TP_Lapiste2_InvisibleProjectile invisibleProjectile3 = _invisibleProjectile;
			BaseBody baseBody = invisibleProjectile3.body;
			baseBody._enable = true;
			((Projectile)invisibleProjectile3)._cachedTransform.SetParent(_BodyTarget, worldPositionStays: true);
			TP_Lapiste2_Projectile cachedTransform = (TP_Lapiste2_Projectile)(object)((Projectile)invisibleProjectile3)._cachedTransform;
			bool flag2 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
		}
		return;
		IL_01ce:
		bool flag3 = obj3 == null;
		invisibleProjectile = null;
		if (!flag3)
		{
			invisibleProjectile = projectile;
		}
		goto IL_01bf;
	}

	private void ScaleIn()
	{
		//IL_0139: Expected O, but got I4
		//IL_005e: Expected I, but got O
		//IL_00df: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
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
		float num2 = _weapon.PArea();
		tweenConfig.duration = 100f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onComplete = LaunchProjectile;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
	}

	private void PlaySfx()
	{
		//IL_005d: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Lapiste, soundConfig, 200f, 5, time);
	}

	public override void InternalUpdate()
	{
		UpdatePfx();
	}

	private void UpdatePfx()
	{
		//IL_0126: Expected I4, but got I8
		//IL_006f: Expected I4, but got I8
		//IL_00ec->IL0074: Incompatible stack heights: 1 vs 0
		//IL_004c->IL0074: Incompatible stack heights: 1 vs 0
		//IL_0140->IL0074: Incompatible stack heights: 2 vs 0
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			if ((object)_pfxEmitter != null)
			{
				Vector2 pos = default(Vector2);
				_pfxEmitter.EmitParticleAt(pos);
				Transform renderer = (Transform)(object)_renderer;
				if ((object)_renderer != null)
				{
					bool flag2 = ((UnityEngine.Object)renderer).m_CachedPtr == (IntPtr)0;
					Renderer.set_sortingOrder_Injected(((UnityEngine.Object)renderer).m_CachedPtr, -2);
					if ((object)_pfxEmitter != null)
					{
						ParticleEmitterManager particleEmitterManager = _pfxEmitter.SetDepth(-1);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		TP_Lapiste2_InvisibleProjectile invisibleProjectile = _invisibleProjectile;
		if ((object)_invisibleProjectile != null && ((UnityEngine.Object)invisibleProjectile).m_CachedPtr != (IntPtr)0)
		{
			TP_Lapiste2_InvisibleProjectile invisibleProjectile2 = _invisibleProjectile;
			invisibleProjectile2.Despawn();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_launchTimer != null)
		{
			_launchTimer.Cancel();
		}
		Weapon weapon = _weapon;
		if (weapon._explodeOnExpire)
		{
			float2 pos = base.position;
			Projectile projectile = weapon.SpawnExplosionAt(pos, 0, 1, 0f);
		}
		base.Despawn();
	}

	public unsafe override void SetTarget(Transform target)
	{
		//IL_00b4: Expected I, but got O
		//IL_0104: Expected O, but got F4
		//IL_012e: Expected O, but got Ref
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		_targetTransform = target;
		Weapon weapon = _weapon;
		Transform playerTransform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
		float num = AngleFromTargetRadians(_targetTransform, playerTransform);
		float[] fireAngles = FireAngles;
		float[] fireAngles2 = FireAngles;
		int num2 = _indexInWeapon % fireAngles2.Length;
		float num3 = fireAngles[num2] * ((float)Math.PI / 180f);
		float num4 = (_initialRotation = num3 + num);
		nint num5 = (nint)this;
		float projectileSpeed = base.ProjectileSpeed;
		BaseBody baseBody = body;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
		float num6 = _initialRotation * num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
		baseBody._velocity = (float2)num6;
		float num7 = _initialRotation * num4;
		object obj = default(object);
		_cachedTransform.localEulerAngles = (Vector3)(&obj);
		BaseBody baseBody2 = body;
		bool flag = 0 < (nint)baseBody2._velocity;
		object obj2 = 0 - baseBody2._velocity;
		bool flag2 = obj2 == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool flag5 = flag4 & flag3;
		PhaserSprite phaserSprite = _fistSprite.setFlipY(flag5);
	}

	private void LaunchProjectile()
	{
		if (_launchTimer != null)
		{
			_launchTimer.Cancel();
		}
		Action onComplete = delegate
		{
			//IL_0015: Expected I, but got O
			//IL_0076: Expected O, but got F4
			_speed = 3f;
			nint num = (nint)this;
			float projectileSpeed = base.ProjectileSpeed;
			BaseBody baseBody = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
			object obj = default(object);
			float num2 = _initialRotation * (float)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
			float num3 = _initialRotation * (float)obj;
			baseBody._velocity = (float2)num2;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer launchTimer = Timers.Register(0.25f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_launchTimer = launchTimer;
	}

	private void _003CLaunchProjectile_003Eb__25_0()
	{
		//IL_0015: Expected I, but got O
		//IL_0076: Expected O, but got F4
		_speed = 3f;
		nint num = (nint)this;
		float projectileSpeed = base.ProjectileSpeed;
		BaseBody baseBody = body;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
		object obj = default(object);
		float num2 = _initialRotation * (float)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
		float num3 = _initialRotation * (float)obj;
		baseBody._velocity = (float2)num2;
	}
}
