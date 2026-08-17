using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class JubileeWeapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public JubileeWeapon _003C_003E4__this;

		public int repeatCount;

		public SfxType sfx;

		internal void _003CFire_003Eb__0()
		{
			//IL_00c8: Expected O, but got I4
			int num = repeatCount + 1;
			repeatCount = num;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float detune = (float)repeatCount * 200f;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(sfx, soundConfig, 50f, 5, time);
			JubileeWeapon jubileeWeapon = _003C_003E4__this;
			Timer soundTimer = jubileeWeapon._soundTimer;
			if (soundTimer._repeat == 0)
			{
				JubileeWeapon jubileeWeapon2 = _003C_003E4__this;
				jubileeWeapon2._canPlaySounds = true;
			}
		}
	}

	private List<ParticleSystem> _fwEmitters;

	private GravityWell _well;

	private List<SpriteRenderer> _rays;

	private List<MultiTargetTween> _raysTween;

	private int _raysLevel;

	private Timer _soundTimer;

	private SfxType[] _soundArray;

	private bool _makeRaysOnUpdate;

	private bool _canPlaySounds;

	private int _soundIndex;

	private ParticleEmitterManager _particles;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		_makeRaysOnUpdate = false;
		_soundIndex = 0;
		_explosionType = WeaponType.JUBILEE_RAYS;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 14 Invalid \"Jump target not found in method: 0x1875257C0\"");
	}

	private unsafe void MakeFireworks()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Expected O, but got I
		//IL_00e7: Expected O, but got I8
		//IL_011a: Expected O, but got I4
		//IL_019b: Expected O, but got I
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_02b0: Expected O, but got I4
		//IL_02d7: Expected O, but got I4
		//IL_02fe: Expected O, but got I4
		//IL_04fd: Expected O, but got I
		//IL_06d2: Expected O, but got I
		//IL_0704: Expected O, but got I
		//IL_0582: Expected O, but got I
		//IL_0596: Expected O, but got I4
		//IL_0749: Expected O, but got I
		//IL_0336: Expected O, but got I
		//IL_0357: Expected O, but got I
		//IL_037d: Expected O, but got Ref
		//IL_0471: Expected O, but got I4
		//IL_0631: Expected O, but got I
		//IL_0652: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager particles;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C0]");
			particles = (ParticleEmitterManager)0;
		}
		else
		{
			particles = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_particles = particles;
		List<ParticleSystem> fwEmitters = _fwEmitters;
		int version = fwEmitters._version + 1;
		fwEmitters._version = version;
		fwEmitters._size = 0;
		bool flag = fwEmitters._size <= 0;
		object obj3 = 6603577472L;
		if (!flag)
		{
			Array.Clear(fwEmitters._items, 0, fwEmitters._size);
			obj3 = 0;
		}
		string[] array = new string[5];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int num = 0;
		bool flag2;
		do
		{
			List<object> fwEmitters2 = (List<object>)(object)_fwEmitters;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			list._002Ector();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r14d\"");
			object obj4 = (nint)0 >> 1;
			object obj5 = obj4 >> 31;
			object obj6 = obj4 + obj5;
			object obj7 = obj6 * 4;
			object obj8 = obj6 + obj7;
			object obj9 = num - obj8;
			int version2 = list._version + 1;
			list._version = version2;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)array[obj9]);
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(1500f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			_ = 3;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 1135869952;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
			particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
			_ = 0;
			_ = 3;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 1135869952;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
			_ = 0;
			particleSystemConfig._angleSteps = 16;
			_ = 3;
			_ = 0;
			_ = 50f;
			_ = 100f;
			_ = 0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-30]");
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-10]");
			_ = 0;
			_ = 0;
			_ = 64;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C0]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			obj = 3;
			_ = 0;
			_ = 1f;
			_ = 0;
			_ = 1f;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+18]");
			_ = 0;
			_ = 0;
			_ = 1115684864;
			_ = 1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C0]");
			particleSystemConfig._frequency = (float?)(object)0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C0]");
			particleSystemConfig._blendMode = (BlendMode?)(object)0;
			particleSystemConfig._on = false;
			string text = System.Number.FormatInt32(num, (ReadOnlySpan<char>)(&minMaxCurve), null);
			string psName = "fwEmitter" + text;
			ParticleSystem item = _particles.CreateEmitter(particleSystemConfig, null, psName);
			int version3 = fwEmitters2._version + 1;
			fwEmitters2._version = version3;
			object[] items2 = fwEmitters2._items;
			if (fwEmitters2._size >= items2.Length)
			{
				fwEmitters2.AddWithResize((object)item);
			}
			else
			{
				int size2 = fwEmitters2._size + 1;
				fwEmitters2._size = size2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			num++;
			flag2 = num < 5;
			minMaxCurve = (ParticleSystem.MinMaxCurve)0;
		}
		while (flag2);
		GravityWellConfig gravityWellConfig = new GravityWellConfig();
		gravityWellConfig._usePauseSystem = true;
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C0]");
		gravityWellConfig._x = (float?)(object)0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C0]");
		gravityWellConfig._y = (float?)(object)0;
		gravityWellConfig.preCacheParticles = true;
		gravityWellConfig._power = 0.5f;
		gravityWellConfig._epsilon = 25f;
		gravityWellConfig._gravity = 100f;
		GravityWell well = _particles.CreateGravityWell(gravityWellConfig, null, "Well");
		_well = well;
	}

	private unsafe void MakeRays()
	{
		//IL_01c6: Expected O, but got I4
		//IL_14ad: Expected O, but got I
		//IL_0229: Expected O, but got I
		//IL_1245: Unknown result type (might be due to invalid IL or missing references)
		//IL_124a: Expected O, but got Unknown
		//IL_02ae: Expected O, but got I4
		//IL_1504: Expected O, but got I
		//IL_0308: Expected O, but got I
		//IL_129a: Unknown result type (might be due to invalid IL or missing references)
		//IL_129f: Expected O, but got Unknown
		//IL_038c: Expected O, but got I4
		//IL_155b: Expected O, but got I
		//IL_03e6: Expected O, but got I
		//IL_12ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f4: Expected O, but got Unknown
		//IL_0403: Expected F4, but got I4
		//IL_040c: Expected F4, but got I4
		//IL_1462: Unknown result type (might be due to invalid IL or missing references)
		//IL_1467: Expected O, but got Unknown
		//IL_0584: Expected O, but got Ref
		//IL_06b4: Expected O, but got I
		//IL_0759: Expected I, but got O
		//IL_07ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b3: Expected O, but got Unknown
		//IL_07cd: Expected O, but got I4
		//IL_1431: Expected O, but got I4
		//IL_144d: Expected O, but got I4
		//IL_08ae: Expected O, but got I4
		//IL_08ce: Expected I4, but got I8
		//IL_0995: Expected I, but got O
		//IL_09fa: Expected O, but got I4
		//IL_0a1a: Expected I4, but got I8
		//IL_0a99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a9e: Expected O, but got Unknown
		//IL_0aa7: Invalid comparison between F4 and I4
		//IL_0436->IL11e5: Incompatible stack heights: 1 vs 0
		//IL_0454->IL11e5: Incompatible stack heights: 1 vs 0
		//IL_1336->IL11e5: Incompatible stack heights: 1 vs 0
		//IL_047b->IL11e5: Incompatible stack heights: 1 vs 0
		//IL_04c0->IL11e5: Incompatible stack heights: 1 vs 0
		//IL_04ea->IL11e5: Incompatible stack heights: 1 vs 0
		//IL_0548->IL11e5: Incompatible stack heights: 2 vs 0
		//IL_0572->IL11e5: Incompatible stack heights: 2 vs 0
		//IL_059d->IL11e5: Incompatible stack heights: 2 vs 0
		//IL_13a7->IL11e5: Incompatible stack heights: 2 vs 0
		//IL_05d1->IL11e5: Incompatible stack heights: 2 vs 0
		//IL_0628->IL11e5: Incompatible stack heights: 2 vs 0
		//IL_0677->IL11e5: Incompatible stack heights: 2 vs 0
		//IL_0725->IL11e5: Incompatible stack heights: 2 vs 0
		//IL_1401->IL11e5: Incompatible stack heights: 3 vs 0
		//IL_141e->IL11e5: Incompatible stack heights: 3 vs 0
		//IL_077c->IL077c: Incompatible stack heights: 4 vs 3
		//IL_081e->IL11e5: Incompatible stack heights: 3 vs 0
		//IL_0867->IL11e5: Incompatible stack heights: 3 vs 0
		//IL_088e->IL11e5: Incompatible stack heights: 3 vs 0
		//IL_0915->IL11e5: Incompatible stack heights: 3 vs 0
		//IL_096b->IL11e5: Incompatible stack heights: 3 vs 0
		//IL_09da->IL11e5: Incompatible stack heights: 3 vs 0
		//IL_09b8->IL09b8: Incompatible stack heights: 4 vs 3
		//IL_0a61->IL11e5: Incompatible stack heights: 3 vs 0
		//IL_0ace->IL1452: Incompatible stack heights: 3 vs 0
		//IL_0b02->IL11e5: Incompatible stack heights: 3 vs 0
		//IL_0b52->IL11e5: Incompatible stack heights: 4 vs 0
		//IL_0b9c->IL11e5: Incompatible stack heights: 4 vs 0
		//IL_0bec->IL11e5: Incompatible stack heights: 5 vs 0
		//IL_0c31->IL11e5: Incompatible stack heights: 5 vs 0
		//IL_0c81->IL11e5: Incompatible stack heights: 6 vs 0
		//IL_0cc6->IL11e5: Incompatible stack heights: 6 vs 0
		//IL_0d16->IL11e5: Incompatible stack heights: 7 vs 0
		//IL_0d5b->IL11e5: Incompatible stack heights: 7 vs 0
		//IL_0dab->IL11e5: Incompatible stack heights: 8 vs 0
		//IL_0df0->IL11e5: Incompatible stack heights: 8 vs 0
		//IL_0e40->IL11e5: Incompatible stack heights: 9 vs 0
		//IL_0e85->IL11e5: Incompatible stack heights: 9 vs 0
		//IL_0ed5->IL11e5: Incompatible stack heights: 10 vs 0
		//IL_0f1a->IL11e5: Incompatible stack heights: 10 vs 0
		//IL_0f6a->IL11e5: Incompatible stack heights: 11 vs 0
		//IL_0faf->IL11e5: Incompatible stack heights: 11 vs 0
		//IL_0fff->IL11e5: Incompatible stack heights: 12 vs 0
		//IL_1044->IL11e5: Incompatible stack heights: 12 vs 0
		//IL_1094->IL11e5: Incompatible stack heights: 13 vs 0
		//IL_10d9->IL11e5: Incompatible stack heights: 13 vs 0
		//IL_1129->IL11e5: Incompatible stack heights: 14 vs 0
		//IL_116e->IL11e5: Incompatible stack heights: 14 vs 0
		//IL_11be->IL11e5: Incompatible stack heights: 15 vs 0
		//IL_11e4->IL11e4: Incompatible stack heights: 15 vs 0
		List<SpriteRenderer> rays = _rays;
		if (_rays != null)
		{
			if (rays._size > 0)
			{
				return;
			}
			int version = rays._version + 1;
			rays._version = version;
			rays._size = 0;
			if (rays._size > 0)
			{
				Array.Clear(rays._items, 0, rays._size);
			}
			List<MultiTargetTween> raysTween = _raysTween;
			if (_raysTween != null)
			{
				int version2 = raysTween._version + 1;
				raysTween._version = version2;
				raysTween._size = 0;
				if (raysTween._size > 0)
				{
					Array.Clear(raysTween._items, 0, raysTween._size);
				}
				List<float> list = new List<float>();
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						PhaserScene.Renderer renderer = s_scene._renderer;
						if (s_scene._renderer != null)
						{
							float num = renderer.width / 7f;
							bool flag = list == null;
							GameObject gameObject = (GameObject)1;
							if (!flag)
							{
								Vector2 vector = default(Vector2);
								string spriteName = default(string);
								Vector2 vector2 = default(Vector2);
								object obj8 = default(object);
								object obj11 = default(object);
								while (true)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1378 @ rax_v28 (System.Collections.Generic.List`1<System.Single>)+1C]");
									_ = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1378 @ rax_v28 (System.Collections.Generic.List`1<System.Single>)+10]");
									object obj = 0;
									float item = (float)gameObject * num;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1378 @ rax_v28 (System.Collections.Generic.List`1<System.Single>)+10]");
									if ((nint)0 == 0)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1378 @ rax_v28 (System.Collections.Generic.List`1<System.Single>)+18]");
									nint num2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rdx_v22+18]");
									if (num2 >= 0)
									{
										list.AddWithResize(item);
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1378 @ rax_v28 (System.Collections.Generic.List`1<System.Single>)+18]");
										object obj2 = (nint)0 + (nint)1;
									}
									gameObject = (GameObject)(gameObject + 1);
									if ((nint)gameObject <= 5)
									{
										continue;
									}
									if ((object)GM.Core == null)
									{
										break;
									}
									PhaserScene s_scene2 = ArcadePhysics.s_scene;
									if (ArcadePhysics.s_scene == null)
									{
										break;
									}
									PhaserScene.Renderer renderer2 = s_scene2._renderer;
									if (s_scene2._renderer == null)
									{
										break;
									}
									float num3 = renderer2.width / 5f;
									GameObject gameObject2 = (GameObject)1;
									while (true)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1378 @ rax_v28 (System.Collections.Generic.List`1<System.Single>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1378 @ rax_v28 (System.Collections.Generic.List`1<System.Single>)+10]");
										object obj3 = 0;
										float item2 = (float)gameObject2 * num3;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1378 @ rax_v28 (System.Collections.Generic.List`1<System.Single>)+10]");
										if ((nint)0 == 0)
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1378 @ rax_v28 (System.Collections.Generic.List`1<System.Single>)+18]");
										nint num4 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rdx_v24+18]");
										if (num4 >= 0)
										{
											list.AddWithResize(item2);
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1378 @ rax_v28 (System.Collections.Generic.List`1<System.Single>)+18]");
											object obj4 = (nint)0 + (nint)1;
										}
										gameObject2 = (GameObject)(gameObject2 + 1);
										if ((nint)gameObject2 <= 3)
										{
											continue;
										}
										if ((object)GM.Core == null)
										{
											break;
										}
										PhaserScene s_scene3 = ArcadePhysics.s_scene;
										if (ArcadePhysics.s_scene == null)
										{
											break;
										}
										PhaserScene.Renderer renderer3 = s_scene3._renderer;
										if (s_scene3._renderer == null)
										{
											break;
										}
										float num5 = renderer3.width * 0.25f;
										GameObject gameObject3 = (GameObject)1;
										while (true)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1378 @ rax_v28 (System.Collections.Generic.List`1<System.Single>)+1C]");
											_ = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1378 @ rax_v28 (System.Collections.Generic.List`1<System.Single>)+10]");
											object obj5 = 0;
											float item3 = (float)gameObject3 * num5;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1378 @ rax_v28 (System.Collections.Generic.List`1<System.Single>)+10]");
											if ((nint)0 == 0)
											{
												break;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1378 @ rax_v28 (System.Collections.Generic.List`1<System.Single>)+18]");
											nint num6 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rdx_v26+18]");
											if (num6 >= 0)
											{
												list.AddWithResize(item3);
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1378 @ rax_v28 (System.Collections.Generic.List`1<System.Single>)+18]");
												object obj6 = (nint)0 + (nint)1;
											}
											gameObject3 = (GameObject)(gameObject3 + 1);
											if ((nint)gameObject3 <= 4)
											{
												continue;
											}
											float num7 = 500f;
											float num8 = 3000f;
											SpriteRenderer spriteRenderer = null;
											while (true)
											{
												SpriteRenderer spriteRenderer2 = spriteRenderer;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1378 @ rax_v28 (System.Collections.Generic.List`1<System.Single>)+18]");
												object obj7 = spriteRenderer2 % 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1378 @ rax_v28 (System.Collections.Generic.List`1<System.Single>)+18]");
												bool flag2 = (nint)obj7 >= 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1378 @ rax_v28 (System.Collections.Generic.List`1<System.Single>)+10]");
												if ((nint)0 == 0 || (object)GM.Core == null)
												{
													break;
												}
												PhaserScene s_scene4 = ArcadePhysics.s_scene;
												if (ArcadePhysics.s_scene == null || s_scene4._renderer == null)
												{
													break;
												}
												GameObject gameObject4 = base.gameObject;
												SpriteRenderer spriteRenderer3 = RenderingExtensions.AddSprite(gameObject4, vector, vector, "vfx", spriteName);
												if ((object)spriteRenderer3 == null)
												{
													break;
												}
												Transform transform = spriteRenderer3.transform;
												if ((object)transform == null)
												{
													break;
												}
												bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
												Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
												Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
												((Renderer)spriteRenderer3).SetMaterial(material);
												SpriteRenderer spriteRenderer4 = RenderingExtensions.SetScale(spriteRenderer3, 0f);
												if ((object)spriteRenderer4 == null)
												{
													break;
												}
												Transform transform2 = spriteRenderer4.transform;
												if ((object)transform2 == null)
												{
													break;
												}
												transform2.localEulerAngles = (Vector3)(&vector2);
												if ((object)GM.Core == null)
												{
													break;
												}
												PhaserScene s_scene5 = ArcadePhysics.s_scene;
												if (ArcadePhysics.s_scene == null)
												{
													break;
												}
												PhaserScene.Renderer renderer4 = s_scene5._renderer;
												if (s_scene5._renderer == null)
												{
													break;
												}
												spriteRenderer4.sortingOrder = renderer4.pixelHeight;
												SpriteRenderer spriteRenderer5 = RenderingExtensions.SetScrollFactor(spriteRenderer4, 0f);
												List<object> rays2 = (List<object>)(object)_rays;
												if (_rays == null)
												{
													break;
												}
												int version3 = rays2._version + 1;
												rays2._version = version3;
												object[] items = rays2._items;
												if (rays2._items == null)
												{
													break;
												}
												if (rays2._size >= items.Length)
												{
													((List<object>)(object)_rays).AddWithResize((object)spriteRenderer5);
													SpriteRenderer spriteRenderer6 = (SpriteRenderer)0;
												}
												else
												{
													int size = rays2._size + 1;
													rays2._size = size;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													SpriteRenderer spriteRenderer6 = spriteRenderer5;
												}
												TweenConfig tweenConfig = new TweenConfig();
												object[] array = new Transform[1];
												if ((object)spriteRenderer5 == null)
												{
													break;
												}
												bool flag4 = ((UnityEngine.Object)spriteRenderer5).m_CachedPtr == (IntPtr)0;
												IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)spriteRenderer5).m_CachedPtr);
												Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
												if (array == null)
												{
													break;
												}
												if ((object)transform3 != null)
												{
													nint num9 = (nint)array;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
													bool flag5 = obj8 == null;
												}
												array[0] = transform3;
												if (tweenConfig == null)
												{
													break;
												}
												tweenConfig.targets = array;
												object obj9 = spriteRenderer & 1;
												bool flag6 = obj9 == null;
												object obj10 = !flag6;
												if (obj10 == null)
												{
													float num10 = 2.5f;
												}
												else
												{
													float num10 = -2.5f;
												}
												tweenConfig.scaleX = (float?)(object)1;
												tweenConfig.duration = 500f;
												tweenConfig.scaleY = (float?)(object)1;
												MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
												if (_raysTween == null)
												{
													break;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
												TweenConfig tweenConfig2 = new TweenConfig();
												object[] array2 = new SpriteRenderer[1];
												if (array2 == null)
												{
													break;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												if (tweenConfig2 == null)
												{
													break;
												}
												tweenConfig2.targets = array2;
												tweenConfig2.alpha = (float?)(object)1;
												tweenConfig2.yoyo = true;
												tweenConfig2.repeat = -1;
												tweenConfig2.ease = Ease.InOutSine;
												tweenConfig2.duration = num7;
												MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
												if (_raysTween == null)
												{
													break;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
												TweenConfig tweenConfig3 = new TweenConfig();
												object[] array3 = new Transform[1];
												Transform transform4 = spriteRenderer5.transform;
												if (array3 == null)
												{
													break;
												}
												if ((object)transform4 != null)
												{
													nint num11 = (nint)array3;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
													bool flag7 = obj11 == null;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												if (tweenConfig3 == null)
												{
													break;
												}
												tweenConfig3.targets = array3;
												tweenConfig3.angle = (float?)(object)1;
												tweenConfig3.yoyo = true;
												tweenConfig3.repeat = -1;
												tweenConfig3.ease = Ease.InOutSine;
												tweenConfig3.duration = num8;
												MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
												if (_raysTween == null)
												{
													break;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
												float num12 = num7 + 75f;
												float num13 = num8 + 150f;
												spriteRenderer = (SpriteRenderer)(spriteRenderer + 1);
												bool flag8 = num12 < 1400f;
												vector2 = vector;
												num7 = num12;
												num8 = num13;
												if (!flag8)
												{
													Extensions.Shuffle((IList<object>)_rays);
													List<SpriteRenderer> rays3 = _rays;
													if (_rays == null)
													{
														break;
													}
													bool flag9 = rays3._size <= 0;
													SpriteRenderer[] items2 = rays3._items;
													if (rays3._items == null)
													{
														break;
													}
													SpriteRenderer spriteRenderer7 = RenderingExtensions.SetTint(items2[0], 16711680u);
													List<SpriteRenderer> rays4 = _rays;
													if (_rays == null)
													{
														break;
													}
													bool flag10 = rays4._size <= 1;
													SpriteRenderer[] items3 = rays4._items;
													if (rays4._items == null)
													{
														break;
													}
													SpriteRenderer spriteRenderer8 = RenderingExtensions.SetTint(items3[1], 65280u);
													List<SpriteRenderer> rays5 = _rays;
													if (_rays == null)
													{
														break;
													}
													bool flag11 = rays5._size <= 2;
													SpriteRenderer[] items4 = rays5._items;
													if (rays5._items == null)
													{
														break;
													}
													SpriteRenderer spriteRenderer9 = RenderingExtensions.SetTint(items4[2], 255u);
													List<SpriteRenderer> rays6 = _rays;
													if (_rays == null)
													{
														break;
													}
													bool flag12 = rays6._size <= 3;
													SpriteRenderer[] items5 = rays6._items;
													if (rays6._items == null)
													{
														break;
													}
													SpriteRenderer spriteRenderer10 = RenderingExtensions.SetTint(items5[3], 16776960u);
													List<SpriteRenderer> rays7 = _rays;
													if (_rays == null)
													{
														break;
													}
													bool flag13 = rays7._size <= 4;
													SpriteRenderer[] items6 = rays7._items;
													if (rays7._items == null)
													{
														break;
													}
													SpriteRenderer spriteRenderer11 = RenderingExtensions.SetTint(items6[4], 16711935u);
													List<SpriteRenderer> rays8 = _rays;
													if (_rays == null)
													{
														break;
													}
													bool flag14 = rays8._size <= 5;
													SpriteRenderer[] items7 = rays8._items;
													if (rays8._items == null)
													{
														break;
													}
													SpriteRenderer spriteRenderer12 = RenderingExtensions.SetTint(items7[5], 65535u);
													List<SpriteRenderer> rays9 = _rays;
													if (_rays == null)
													{
														break;
													}
													bool flag15 = rays9._size <= 6;
													SpriteRenderer[] items8 = rays9._items;
													if (rays9._items == null)
													{
														break;
													}
													SpriteRenderer spriteRenderer13 = RenderingExtensions.SetTint(items8[6], 16711680u);
													List<SpriteRenderer> rays10 = _rays;
													if (_rays == null)
													{
														break;
													}
													bool flag16 = rays10._size <= 7;
													SpriteRenderer[] items9 = rays10._items;
													if (rays10._items == null)
													{
														break;
													}
													SpriteRenderer spriteRenderer14 = RenderingExtensions.SetTint(items9[7], 65280u);
													List<SpriteRenderer> rays11 = _rays;
													if (_rays == null)
													{
														break;
													}
													bool flag17 = rays11._size <= 8;
													SpriteRenderer[] items10 = rays11._items;
													if (rays11._items == null)
													{
														break;
													}
													SpriteRenderer spriteRenderer15 = RenderingExtensions.SetTint(items10[8], 255u);
													List<SpriteRenderer> rays12 = _rays;
													if (_rays == null)
													{
														break;
													}
													bool flag18 = rays12._size <= 9;
													SpriteRenderer[] items11 = rays12._items;
													if (rays12._items == null)
													{
														break;
													}
													SpriteRenderer spriteRenderer16 = RenderingExtensions.SetTint(items11[9], 16776960u);
													List<SpriteRenderer> rays13 = _rays;
													if (_rays == null)
													{
														break;
													}
													bool flag19 = rays13._size <= 10;
													SpriteRenderer[] items12 = rays13._items;
													if (rays13._items == null)
													{
														break;
													}
													SpriteRenderer spriteRenderer17 = RenderingExtensions.SetTint(items12[10], 16711935u);
													List<SpriteRenderer> rays14 = _rays;
													if (_rays == null)
													{
														break;
													}
													bool flag20 = rays14._size <= 11;
													SpriteRenderer[] items13 = rays14._items;
													if (rays14._items == null)
													{
														break;
													}
													SpriteRenderer spriteRenderer18 = RenderingExtensions.SetTint(items13[11], 65535u);
													return;
												}
											}
											break;
										}
										break;
									}
									break;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public ParticleSystem GetFwEmitters(int index)
	{
		List<ParticleSystem> fwEmitters = _fwEmitters;
		int num = index % fwEmitters._size;
		if (num < fwEmitters._size)
		{
			ParticleSystem[] items = fwEmitters._items;
			return items[num];
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		ParticleSystem result = default(ParticleSystem);
		return result;
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_034e: Expected O, but got F4
		//IL_0067: Expected O, but got I4
		//IL_0084: Expected O, but got I4
		//IL_00a1: Expected O, but got I4
		//IL_00d6: Invalid comparison between F4 and I4
		//IL_016e: Expected I4, but got I8
		//IL_01f9: Expected O, but got I4
		//IL_025c: Invalid comparison between I4 and F4
		//IL_019e: Expected O, but got I4
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected O, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected I4, but got Unknown
		//IL_02ff: Expected I4, but got F4
		_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass15_0();
		CS_0024_003C_003E8__locals10._003C_003E4__this = this;
		base.Fire(skipTriggers);
		bool flag = default(bool);
		if (((Equipment)this)._003CLevel_003Ek__BackingField >= _raysLevel)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Projectile projectile = base.SpawnExplosionAt((float2)flag, 0, 1, 0f);
			Projectile projectile2 = base.SpawnExplosionAt((float2)flag, 1, 1, 0f);
			Projectile projectile3 = base.SpawnExplosionAt((float2)flag, 2, 1, 0f);
		}
		object obj = UnityEngine.Random.value;
		WeaponData currentWeaponData = _currentWeaponData;
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
		float num2 = (float)(flag ? 1 : 0) * currentWeaponData._003Cchance_003Ek__BackingField;
		if (num2 > (float)(flag ? 1 : 0))
		{
			GameManager core = GM.Core;
			core._stage.DebugSpawnDestructibles();
		}
		if (!_canPlaySounds)
		{
			return;
		}
		_canPlaySounds = false;
		CS_0024_003C_003E8__locals10.repeatCount = 0;
		SfxType[] soundArray = _soundArray;
		int num3 = (int)(_soundIndex & 0x80000003L);
		if ((nint)_soundArray < 0)
		{
			object obj2 = num3 - 1;
			object obj3 = obj2 | -4;
			num3 = obj3 + 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rcx_v15 (VampireSurvivors.Data.SfxType[])+20+v489 @ rax_v24 (System.Int32)*4]");
		CS_0024_003C_003E8__locals10.sfx = SfxType.None;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)CS_0024_003C_003E8__locals10.repeatCount * 200f;
		soundConfig.Detune = detune;
		float num4 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound((SfxType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref soundArray[num3]), soundConfig, 50f, 5, num4);
		float num5 = base.PAmount();
		if (!(0f > 1f))
		{
			_canPlaySounds = true;
		}
		else
		{
			WeaponData currentWeaponData2 = _currentWeaponData;
			Action onComplete = delegate
			{
				//IL_00c8: Expected O, but got I4
				int repeatCount = CS_0024_003C_003E8__locals10.repeatCount + 1;
				CS_0024_003C_003E8__locals10.repeatCount = repeatCount;
				SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
				soundConfig2.Rate = 1f;
				soundConfig2.Volume = (float?)(object)1;
				float detune2 = (float)CS_0024_003C_003E8__locals10.repeatCount * 200f;
				soundConfig2.Detune = detune2;
				float time = default(float);
				PlaySoundResult playSoundResult2 = SoundManager.PlaySound(CS_0024_003C_003E8__locals10.sfx, soundConfig2, 50f, 5, time);
				JubileeWeapon jubileeWeapon = CS_0024_003C_003E8__locals10._003C_003E4__this;
				Timer soundTimer2 = jubileeWeapon._soundTimer;
				if (soundTimer2._repeat == 0)
				{
					JubileeWeapon jubileeWeapon2 = CS_0024_003C_003E8__locals10._003C_003E4__this;
					jubileeWeapon2._canPlaySounds = true;
				}
			};
			float num6 = base.PAmount();
			float duration = currentWeaponData2._003CrepeatInterval_003Ek__BackingField * 0.001f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer soundTimer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)(int)num4 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_soundTimer = soundTimer;
		}
		int soundIndex = _soundIndex + 1;
		_soundIndex = soundIndex;
	}

	protected override void OnUpdate()
	{
		if ((object)_well != null)
		{
			Transform transform = _well.transform;
			Transform cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
				bool flag2 = (object)transform == null;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				if (_makeRaysOnUpdate)
				{
					_makeRaysOnUpdate = false;
					MakeRays();
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override bool LevelUp()
	{
		bool result = LevelUp(skipFire: false);
		if (((Equipment)this)._003CLevel_003Ek__BackingField >= _raysLevel)
		{
			_makeRaysOnUpdate = true;
		}
		return result;
	}

	protected override bool OnSecondaryBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		//IL_0142: Expected O, but got I
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		//IL_01de: Expected I, but got O
		//IL_01e6: Expected I, but got O
		//IL_01f6: Expected O, but got I
		//IL_0232: Expected O, but got I
		//IL_026f: Expected O, but got I
		//IL_02b3: Expected O, but got I4
		//IL_02a5: Expected O, but got I4
		//IL_03ce: Expected I, but got O
		nint num = (nint)typeof(EnemyController);
		nint num2 = (nint)first;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v4 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v4 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rax_v37+FFFFFFF8+v61 @ rax_v8*8]");
			if (0 == (nint)typeof(EnemyController))
			{
				obj3 = 1;
				goto IL_0333;
			}
		}
		obj3 = 0;
		goto IL_0333;
		IL_0333:
		bool flag = obj3 == null;
		ArcadeColliderType arcadeColliderType = null;
		if (!flag)
		{
			arcadeColliderType = first;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdi_v5 (ArcadeColliderType)+260]");
		if ((nint)0 == 0)
		{
			List<float> critChancesArray = _critChancesArray;
			int critIndex = _critIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
			int num4 = (int)((nint)critIndex % (nint)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)num4 < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v8 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj4 = 0;
				int critIndex2 = _critIndex + 1;
				_critIndex = critIndex2;
				float num5 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
				WeaponData currentWeaponData = _currentWeaponData;
				object obj6 = default(object);
				object obj5 = obj6 * currentWeaponData._003CcritChance_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rcx_v9+20+v94 @ rdx_v7 (System.Int32)*4]");
				float num6;
				if ((nint)obj5 <= 0)
				{
					num6 = 1f;
				}
				else
				{
					float num7 = currentWeaponData._003CcritMul_003Ek__BackingField * ArcanaManager.CritMul;
					num6 = num7 * (float)obj6;
				}
				nint num8 = (nint)typeof(Projectile);
				nint num9 = (nint)second;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ r8_v6 (Il2CppClass<ArcadeColliderType>)+130]");
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				if (num10 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ r8_v6 (Il2CppClass<ArcadeColliderType>)+C8]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v20+FFFFFFF8+v103 @ rax_v19*8]");
					if (0 == (nint)typeof(Projectile))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v20+FFFFFFF8+v508 @ rcx_v13*8]");
						object obj10 = ((0 != (nint)typeof(Projectile)) ? ((object)0) : ((object)1));
						bool flag2 = obj10 == null;
						ArcadeColliderType arcadeColliderType2 = null;
						if (!flag2)
						{
							arcadeColliderType2 = second;
						}
						if (!((Projectile)arcadeColliderType2).HasAlreadyHitObject((IDamageable)arcadeColliderType))
						{
							float num11 = base.SecondaryPPower();
							WeaponData currentWeaponData2 = _currentWeaponData;
							float num12 = (float)obj6 * num6;
							if (_currentWeaponData != null)
							{
								HitVfxType hitVfxType = currentWeaponData2._003ChitVFX_003Ek__BackingField;
							}
							else
							{
								HitVfxType hitVfxType = HitVfxType.Default;
							}
							float knockback = base.Knockback;
							nint num13 = (nint)arcadeColliderType;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v370 @ rdx_v15 (Il2CppClass<ArcadeColliderType>)+3E8] (should have been resolved before IL gen)");
							float num14 = num12 + base._003CStatsInflictedDamage_003Ek__BackingField;
							base._003CStatsInflictedDamage_003Ek__BackingField = num14;
						}
						goto IL_0355;
					}
				}
				throw new NullReferenceException();
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			bool result = default(bool);
			return result;
		}
		goto IL_0355;
		IL_0355:
		return false;
	}

	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
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
	}

	public JubileeWeapon()
	{
		List<ParticleSystem> fwEmitters = new List<ParticleSystem>();
		_fwEmitters = fwEmitters;
		_rays = new List<SpriteRenderer>();
		_raysTween = new List<MultiTargetTween>();
		_raysLevel = 9;
		_soundArray = new SfxType[4]
		{
			SfxType.STEP1,
			SfxType.STEP2,
			SfxType.STEP3,
			SfxType.STEP4
		};
		_canPlaySounds = true;
		base._002Ector();
	}
}
