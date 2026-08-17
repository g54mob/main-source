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
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FourSeasonsProjectile : Projectile
{
	private FourSeasonsWeapon _trueWeapon;

	private Timer _expireTimer;

	private ParticleEmitterManager _particles;

	private ParticleSystem _fwEmitter;

	private SpriteRenderer _ringRenderer;

	private SpriteRenderer _rainbowRenderer;

	private SpriteRenderer _raysRenderer;

	private MultiTargetTween _tween5;

	private MultiTargetTween _tween3;

	private MultiTargetTween _tween4;

	private MultiTargetTween _tween2;

	private MultiTargetTween _tween1;

	private int _season;

	private List<ParticleEmitterManager> _seasonParticles;

	private List<ParticleSystem> _seasonEmitters;

	private List<GravityWell> _seasonWells;

	private PhaserSprite _kanji;

	private List<Sprite> _kanjiFrames;

	private bool _initalized;

	public uint[] getEmitCustomTint(int season)
	{
		//IL_0013: Expected O, but got I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		bool flag = season == 0;
		uint[] array;
		RuntimeFieldHandle fldHandle;
		if (!flag)
		{
			object obj = season - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 != 1)
					{
						return null;
					}
					array = new uint[4];
					fldHandle = (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					array = new uint[4];
					fldHandle = (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/;
				}
			}
			else
			{
				array = new uint[4];
				fldHandle = (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/;
			}
		}
		else
		{
			array = new uint[4];
			fldHandle = (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/;
		}
		RuntimeHelpers.InitializeArray(array, fldHandle);
		return array;
	}

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("blurBlack2", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		Sprite sprite2 = SpriteManager.GetSprite("sPFX_ring_64", "vfx");
		_ringRenderer.sprite = sprite2;
		Sprite sprite3 = SpriteManager.GetSprite("s_pfx_rainbow_64", "vfx");
		_ringRenderer.sprite = sprite3;
		Sprite sprite4 = SpriteManager.GetSprite("fuzzA", "vfx");
		_ringRenderer.sprite = sprite4;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_02f5: Expected I, but got O
		//IL_02fd: Expected I, but got O
		//IL_030d: Expected O, but got I
		//IL_038d: Expected O, but got I4
		//IL_0349: Expected O, but got I
		//IL_037f: Expected O, but got I4
		//IL_04b3: Expected O, but got I4
		//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Expected I4, but got Unknown
		base.InitProjectile(pool, weapon, index);
		if (_kanjiFrames != null)
		{
			List<Sprite> kanjiFrames = _kanjiFrames;
			if (kanjiFrames._size != 0)
			{
				goto IL_02c5;
			}
		}
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"k_spring");
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
			((List<object>)(object)list).AddWithResize((object)"k_summer");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"k_autumn");
		}
		else
		{
			int num3 = list._size + 1;
			list._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"k_winter");
		}
		else
		{
			int num4 = list._size + 1;
			list._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(list, "vfx");
		_kanjiFrames = animationFrames;
		goto IL_02c5;
		IL_051b:
		object obj;
		bool flag = obj == null;
		Weapon trueWeapon = null;
		if (!flag)
		{
			trueWeapon = weapon;
		}
		goto IL_050c;
		IL_050c:
		_trueWeapon = (FourSeasonsWeapon)trueWeapon;
		_ringRenderer.enabled = false;
		Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
		((Renderer)_ringRenderer).SetMaterial(material);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_ringRenderer, 0.65f);
		_rainbowRenderer.enabled = false;
		Material material2 = MaterialManager.GetMaterial(MaterialType.Vfx);
		((Renderer)_rainbowRenderer).SetMaterial(material2);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_rainbowRenderer, 0.65f);
		_raysRenderer.enabled = false;
		Material material3 = MaterialManager.GetMaterial(MaterialType.Vfx);
		((Renderer)_raysRenderer).SetMaterial(material3);
		SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(_raysRenderer, 0.65f);
		Initialize();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ebp\"");
		object obj2 = 0 * 2;
		int num5 = index - obj2;
		RenderingExtensions.SetFrame(_fwEmitter, num5);
		OnRecycle();
		return;
		IL_02c5:
		bool flag2 = (object)weapon == null;
		trueWeapon = null;
		if (flag2)
		{
			goto IL_050c;
		}
		nint num6 = (nint)typeof(FourSeasonsWeapon);
		nint num7 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Weapons.FourSeasonsWeapon>)+130]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Weapons.FourSeasonsWeapon>)+130]");
		if (num8 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v49+FFFFFFF8+v164 @ rax_v45*8]");
			if (0 == (nint)typeof(FourSeasonsWeapon))
			{
				obj = 1;
				goto IL_051b;
			}
		}
		obj = 0;
		goto IL_051b;
	}

	private unsafe void Initialize()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected F4, but got Unknown
		//IL_1a34: Expected O, but got I4
		//IL_13a5: Expected O, but got I4
		//IL_13cc: Expected O, but got I4
		//IL_13f3: Expected O, but got I4
		//IL_1407: Expected O, but got Ref
		//IL_1421: Expected native int or pointer, but got O
		//IL_1440: Expected O, but got I
		//IL_145b: Expected O, but got Ref
		//IL_1475: Expected native int or pointer, but got O
		//IL_149a: Expected O, but got I4
		//IL_14d5: Expected O, but got Ref
		//IL_14ef: Expected native int or pointer, but got O
		//IL_1509: Expected O, but got I
		//IL_1529: Expected O, but got Ref
		//IL_1551: Expected native int or pointer, but got O
		//IL_1596: Expected O, but got I
		//IL_15be: Expected O, but got Ref
		//IL_15e5: Expected O, but got I
		//IL_15ff: Expected native int or pointer, but got O
		//IL_1644: Expected O, but got I
		//IL_1662: Expected O, but got I
		//IL_16a1: Expected O, but got I
		//IL_16c2: Expected O, but got I
		//IL_1a66: Expected O, but got I
		//IL_1a87: Expected O, but got I
		//IL_1bad: Expected O, but got I
		//IL_1bf6: Expected O, but got I
		//IL_1763->IL1b86: Incompatible stack heights: 1 vs 0
		//IL_1844->IL1b87: Incompatible stack heights: 7 vs 6
		//IL_18a2->IL1bd0: Incompatible stack heights: 9 vs 8
		//IL_19dd->IL1744: Incompatible stack heights: 12 vs 1
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (_initalized)
		{
			return;
		}
		_initalized = true;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.sprite(s_scene.add, pos, "vfx", "k_spring");
		PhaserSprite kanji = phaserSprite.setVisible(visible: false);
		_kanji = kanji;
		GameObject gameObject = base.gameObject;
		ParticleEmitterManager particles = gameObject.AddComponent<ParticleEmitterManager>();
		_particles = particles;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene2._renderer;
		float height = renderer.height;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float num = height ^ 0;
		_particles.SetDepthMultiplied(num);
		int[] array = new int[10] { 0, 1, 2, 3, 0, 1, 3, 0, 1, 3 };
		object obj3 = UnityEngine.Random.RandomRangeInt(0, array.Length);
		_season = array[obj3];
		List<ParticleEmitterManager> seasonParticles = _seasonParticles;
		int version = seasonParticles._version + 1;
		seasonParticles._version = version;
		seasonParticles._size = 0;
		if (seasonParticles._size > 0)
		{
			Array.Clear(seasonParticles._items, 0, seasonParticles._size);
		}
		List<GravityWell> seasonWells = _seasonWells;
		int version2 = seasonWells._version + 1;
		seasonWells._version = version2;
		seasonWells._size = 0;
		if (seasonWells._size > 0)
		{
			Array.Clear(seasonWells._items, 0, seasonWells._size);
		}
		List<ParticleSystem> seasonEmitters = _seasonEmitters;
		int version3 = seasonEmitters._version + 1;
		seasonEmitters._version = version3;
		seasonEmitters._size = 0;
		if (seasonEmitters._size > 0)
		{
			Array.Clear(seasonEmitters._items, 0, seasonEmitters._size);
		}
		List<string> list = new List<string>();
		int version4 = list._version + 1;
		list._version = version4;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"flo_01");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list._version + 1;
		list._version = version5;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"flo_02");
		}
		else
		{
			int num3 = list._size + 1;
			list._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version6 = list._version + 1;
		list._version = version6;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"flo_03");
		}
		else
		{
			int num4 = list._size + 1;
			list._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version7 = list._version + 1;
		list._version = version7;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"flo_04");
		}
		else
		{
			int num5 = list._size + 1;
			list._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version8 = list._version + 1;
		list._version = version8;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"flo_05");
		}
		else
		{
			int num6 = list._size + 1;
			list._size = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version9 = list._version + 1;
		list._version = version9;
		string[] items6 = list._items;
		if (list._size >= items6.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"flo_06");
		}
		else
		{
			int num7 = list._size + 1;
			list._size = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version10 = list._version + 1;
		list._version = version10;
		string[] items7 = list._items;
		if (list._size >= items7.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"flo_07");
		}
		else
		{
			int num8 = list._size + 1;
			list._size = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version11 = list._version + 1;
		list._version = version11;
		string[] items8 = list._items;
		if (list._size >= items8.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"flo_08");
		}
		else
		{
			int num9 = list._size + 1;
			list._size = num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version12 = list._version + 1;
		list._version = version12;
		string[] items9 = list._items;
		if (list._size >= items9.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"flo_09");
		}
		else
		{
			int num10 = list._size + 1;
			list._size = num10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version13 = list._version + 1;
		list._version = version13;
		string[] items10 = list._items;
		if (list._size >= items10.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"flo_10");
		}
		else
		{
			int num11 = list._size + 1;
			list._size = num11;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		MakeEmitter_Frames(list, 0);
		List<string> list2 = new List<string>();
		int version14 = list2._version + 1;
		list2._version = version14;
		string[] items11 = list2._items;
		if (list2._size >= items11.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"leaf0000");
		}
		else
		{
			int num12 = list2._size + 1;
			list2._size = num12;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version15 = list2._version + 1;
		list2._version = version15;
		string[] items12 = list2._items;
		if (list2._size >= items12.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"leaf0001");
		}
		else
		{
			int num13 = list2._size + 1;
			list2._size = num13;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version16 = list2._version + 1;
		list2._version = version16;
		string[] items13 = list2._items;
		if (list2._size >= items13.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"leaf0002");
		}
		else
		{
			int num14 = list2._size + 1;
			list2._size = num14;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version17 = list2._version + 1;
		list2._version = version17;
		string[] items14 = list2._items;
		if (list2._size >= items14.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"leaf0003");
		}
		else
		{
			int num15 = list2._size + 1;
			list2._size = num15;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version18 = list2._version + 1;
		list2._version = version18;
		string[] items15 = list2._items;
		if (list2._size >= items15.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"leaf0004");
		}
		else
		{
			int num16 = list2._size + 1;
			list2._size = num16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version19 = list2._version + 1;
		list2._version = version19;
		string[] items16 = list2._items;
		if (list2._size >= items16.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"leaf0005");
		}
		else
		{
			int num17 = list2._size + 1;
			list2._size = num17;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version20 = list2._version + 1;
		list2._version = version20;
		string[] items17 = list2._items;
		if (list2._size >= items17.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"leaf0006");
		}
		else
		{
			int num18 = list2._size + 1;
			list2._size = num18;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version21 = list2._version + 1;
		list2._version = version21;
		string[] items18 = list2._items;
		if (list2._size >= items18.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"leaf0007");
		}
		else
		{
			int num19 = list2._size + 1;
			list2._size = num19;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version22 = list2._version + 1;
		list2._version = version22;
		string[] items19 = list2._items;
		if (list2._size >= items19.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"leaf0008");
		}
		else
		{
			int num20 = list2._size + 1;
			list2._size = num20;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version23 = list2._version + 1;
		list2._version = version23;
		string[] items20 = list2._items;
		if (list2._size >= items20.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"leaf0009");
		}
		else
		{
			int num21 = list2._size + 1;
			list2._size = num21;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version24 = list2._version + 1;
		list2._version = version24;
		string[] items21 = list2._items;
		if (list2._size >= items21.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"leaf0010");
		}
		else
		{
			int num22 = list2._size + 1;
			list2._size = num22;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version25 = list2._version + 1;
		list2._version = version25;
		string[] items22 = list2._items;
		if (list2._size >= items22.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"leaf0011");
		}
		else
		{
			int num23 = list2._size + 1;
			list2._size = num23;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version26 = list2._version + 1;
		list2._version = version26;
		string[] items23 = list2._items;
		if (list2._size >= items23.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"leaf0012");
		}
		else
		{
			int num24 = list2._size + 1;
			list2._size = num24;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version27 = list2._version + 1;
		list2._version = version27;
		string[] items24 = list2._items;
		if (list2._size >= items24.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"leaf0013");
		}
		else
		{
			int num25 = list2._size + 1;
			list2._size = num25;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version28 = list2._version + 1;
		list2._version = version28;
		string[] items25 = list2._items;
		if (list2._size >= items25.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"leaf0014");
		}
		else
		{
			int num26 = list2._size + 1;
			list2._size = num26;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version29 = list2._version + 1;
		list2._version = version29;
		string[] items26 = list2._items;
		if (list2._size >= items26.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"leaf0015");
		}
		else
		{
			int num27 = list2._size + 1;
			list2._size = num27;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2.Add("leaf0016");
		list2.Add("leaf0017");
		list2.Add("leaf0018");
		list2.Add("leaf0019");
		MakeEmitter_Frames(list2, 1);
		MakeEmitter_Frames(list2, 2);
		List<string> list3 = new List<string>();
		list3.Add("snowb0000");
		list3.Add("snowb0001");
		list3.Add("snowb0002");
		list3.Add("snowb0003");
		list3.Add("snowb0004");
		list3.Add("snowb0005");
		list3.Add("snowb0006");
		MakeEmitter_Frames(list3, 3);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list4 = new List<string>();
		list4.Add("_blur");
		list4.Add("_blur2");
		list4.Add("_blur3");
		particleSystemConfig._frame = list4;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(800f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 1f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+18]");
		_ = 0;
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
		_ = 0;
		particleSystemConfig._alphaEase = Easing.OutExpo;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+28]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+38]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
		particleSystemConfig._angleSteps = 8;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(50f, 100f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-48]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
		_ = 0;
		_ = 16;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(2f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+78]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-20]");
		float2 float5 = (float2)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-20]");
		_ = 0;
		_ = 0;
		_ = 1098907648;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
		particleSystemConfig._frequency = (float?)(object)0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		particleSystemConfig._fps = 0;
		particleSystemConfig._on = false;
		ParticleSystem fwEmitter = _particles.CreateEmitter(particleSystemConfig);
		_fwEmitter = fwEmitter;
		List<ParticleEmitterManager> seasonParticles2 = _seasonParticles;
		bool flag = _seasonParticles == null;
		int num28 = 0;
		string text = null;
		float2 float6 = default(float2);
		for (int num29 = 0; num29 < seasonParticles2._size; num29 = num28)
		{
			List<ParticleEmitterManager> seasonParticles3 = _seasonParticles;
			bool flag2 = _seasonParticles == null;
			bool flag3 = num28 >= seasonParticles3._size;
			ParticleEmitterManager[] items27 = seasonParticles3._items;
			bool flag4 = seasonParticles3._items == null;
			GravityWellConfig gravityWellConfig = new GravityWellConfig();
			_ = 0;
			_ = 0;
			_ = 1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
			gravityWellConfig._x = (float?)(object)0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
			gravityWellConfig._y = (float?)(object)0;
			gravityWellConfig._epsilon = 100f;
			gravityWellConfig._gravity = 50f;
			gravityWellConfig._usePauseSystem = true;
			gravityWellConfig.preCacheParticles = true;
			Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
			bool flag5 = (object)cachedTrans == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1417 @ rax_v136 (UnityEngine.Transform)+10]");
			bool flag6 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1417 @ rax_v136 (UnityEngine.Transform)+10]");
			float2 ret;
			Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
			if (body != null)
			{
				BaseBody baseBody = body;
				ArcadeTransform arcadeTransform = baseBody._transform;
				bool flag7 = baseBody._transform == null;
				arcadeTransform.position = ret;
				float5 = float6;
			}
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
			gravityWellConfig._x = (float?)(object)0;
			Transform cachedTrans2 = ((ArcadeSprite)this).CachedTrans;
			bool flag8 = (object)cachedTrans2 == null;
			bool flag9 = ((UnityEngine.Object)cachedTrans2).m_CachedPtr == (IntPtr)0;
			float2 ret2;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans2).m_CachedPtr, out *(Vector3*)(&ret2));
			if (body != null)
			{
				BaseBody baseBody2 = body;
				ArcadeTransform arcadeTransform2 = baseBody2._transform;
				bool flag10 = baseBody2._transform == null;
				arcadeTransform2.position = ret2;
				float5 = ret2;
			}
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
			gravityWellConfig._y = (float?)(object)0;
			gravityWellConfig._power = 1f;
			gravityWellConfig._epsilon = 20f;
			gravityWellConfig._gravity = 200f;
			bool flag11 = (object)items27[num28] == null;
			GravityWell item = items27[num28].CreateGravityWell(gravityWellConfig);
			List<object> seasonWells2 = (List<object>)(object)_seasonWells;
			bool flag12 = _seasonWells == null;
			int version30 = seasonWells2._version + 1;
			seasonWells2._version = version30;
			text = (string)(object)seasonWells2._items;
			bool flag13 = seasonWells2._items == null;
			int num30 = seasonWells2._size;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ r9_v52 (System.String)+18]");
			if ((nint)num30 >= (nint)0)
			{
				((List<object>)(object)_seasonWells).AddWithResize((object)item);
			}
			else
			{
				int num31 = seasonWells2._size + 1;
				seasonWells2._size = num31;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			seasonParticles2 = _seasonParticles;
			num28++;
			bool flag14 = _seasonParticles == null;
		}
	}

	private unsafe void MakeEmitter_Frames(List<string> frames, int season)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected F4, but got Unknown
		//IL_00a4: Expected O, but got I4
		//IL_00cb: Expected O, but got I4
		//IL_0100: Expected O, but got I4
		//IL_0119: Expected O, but got Ref
		//IL_0133: Expected native int or pointer, but got O
		//IL_014d: Expected O, but got I
		//IL_016d: Expected O, but got Ref
		//IL_017c: Expected O, but got I4
		//IL_018a: Expected native int or pointer, but got O
		//IL_044f: Expected O, but got I4
		//IL_01a2: Expected O, but got Ref
		//IL_01ca: Expected native int or pointer, but got O
		//IL_01e4: Expected O, but got I
		//IL_0204: Expected O, but got Ref
		//IL_022c: Expected native int or pointer, but got O
		//IL_0479: Expected O, but got I
		//IL_0264: Expected O, but got Ref
		//IL_0272: Expected O, but got I4
		//IL_028c: Expected native int or pointer, but got O
		//IL_02d1: Expected O, but got I
		//IL_02fe: Expected O, but got I4
		//IL_0311: Expected O, but got I4
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		ParticleEmitterManager particleEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float height = renderer.height;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float num = height ^ 0;
		particleEmitterManager.SetDepthMultiplied(num);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		particleSystemConfig._frame = frames;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		particleSystemConfig._fps = 30;
		minMaxCurve = new ParticleSystem.MinMaxCurve(1200f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 48));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 720f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-30]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-20]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
		_ = 0;
		obj = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 1f));
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
		particleSystemConfig._alphaEase = Easing.OutExpo;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+10]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+20]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
		particleSystemConfig._angleSteps = 31;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(50f, 100f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+40]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-80]");
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
		particleSystemConfig._quantity = (int?)(object)1;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(2f, 0.1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+60]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-58]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
		_ = 0;
		particleSystemConfig._frequency = (float?)(object)1;
		bool flag = season == 0;
		Array tintRandom;
		uint[] array;
		RuntimeFieldHandle fldHandle;
		if (!flag)
		{
			object obj3 = season - 1;
			if (!flag)
			{
				object obj4 = obj3 - 1;
				if (!flag)
				{
					if ((nint)obj4 != 1)
					{
						tintRandom = null;
						goto IL_03d2;
					}
					array = new uint[4];
					fldHandle = (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					array = new uint[4];
					fldHandle = (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/;
				}
			}
			else
			{
				array = new uint[4];
				fldHandle = (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/;
			}
		}
		else
		{
			array = new uint[4];
			fldHandle = (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/;
		}
		RuntimeHelpers.InitializeArray(array, fldHandle);
		tintRandom = array;
		goto IL_03d2;
		IL_03d2:
		particleSystemConfig._tintRandom = (uint[])tintRandom;
		particleSystemConfig._on = false;
		ParticleSystem particleSystem = particleEmitterManager.CreateEmitter(particleSystemConfig);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD230");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96880");
	}

	private void OnRecycle()
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0064: Expected I4, but got I8
		//IL_0092: Expected O, but got I4
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected I4, but got Unknown
		//IL_016d: Expected I, but got O
		//IL_01e1: Expected O, but got I4
		BaseBody baseBody = body.setCircle(16f, (float?)(object)0, (float?)(object)0);
		BaseBody baseBody2 = body;
		baseBody2._enable = true;
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		int num = (int)(_indexInWeapon & 0x80000003L);
		if ((nint)baseBody2 < 0)
		{
			object obj = num - 1;
			object obj2 = obj | -4;
			num = obj2 + 1;
		}
		List<Sprite> kanjiFrames = _kanjiFrames;
		_season = num;
		if (num < kanjiFrames._size)
		{
			Sprite[] items = kanjiFrames._items;
			PhaserSprite phaserSprite = _kanji.setFrame(items[num]);
			List<ParticleSystem> seasonEmitters = _seasonEmitters;
			int season = _season;
			if (_season < seasonEmitters._size)
			{
				ParticleSystem[] items2 = seasonEmitters._items;
				FourSeasonsWeapon trueWeapon = _trueWeapon;
				nint num2 = (nint)trueWeapon;
				float num3 = trueWeapon.PArea();
				object obj3 = default(object);
				float num4 = (float)obj3 * 16f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
				int quantity = default(int);
				RenderingExtensions.SetQuantity(items2[season], quantity);
				ArcadeSprite arcadeSprite2 = setAlpha(1f);
				float num5 = _weapon.PArea();
				ArcadeSprite arcadeSprite3 = setScale(num4, (float?)(object)0);
				float num6 = _weapon.PArea();
				float num7 = _weapon.PArea();
				float num8 = num4 * 100f;
				float min = num4 * 50f;
				RenderingExtensions.SetSpeed(_fwEmitter, min, num8);
				List<ParticleSystem> seasonEmitters2 = _seasonEmitters;
				int season2 = _season;
				if (_season < seasonEmitters2._size)
				{
					ParticleSystem[] items3 = seasonEmitters2._items;
					float num9 = _weapon.PArea();
					float num10 = _weapon.PArea();
					float num11 = num8 * 10f;
					float min2 = num8 * 5f;
					RenderingExtensions.SetSpeed(items3[season2], min2, num11);
					float num12 = _weapon.PArea();
					float num13 = num11 * 16f;
					bool flag = 32f > num13;
					float radius = 32f;
					if (!flag)
					{
						radius = num13;
					}
					Circle circle = new Circle();
					circle._radius = radius;
					circle._x = 0f;
					List<ParticleSystem> seasonEmitters3 = _seasonEmitters;
					int season3 = _season;
					if (_season < seasonEmitters3._size)
					{
						ParticleSystem[] items4 = seasonEmitters3._items;
						EmitZone emitZone = new EmitZone();
						emitZone._type = EmitZoneType.Random;
						emitZone._source = circle;
						RenderingExtensions.SetEmitZone(items4[season3], emitZone);
						_isCullable = false;
						if (_expireTimer != null)
						{
							_expireTimer.Cancel();
						}
						Action onComplete = delegate
						{
							if (_expireTimer != null)
							{
								_expireTimer.Cancel();
							}
							Despawn();
						};
						bool useRealTime = default(bool);
						MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
						int repeat = default(int);
						TimerType type = default(TimerType);
						Timer expireTimer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_expireTimer = expireTimer;
						Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 627 Invalid \"Jump target not found in method: 0x18728D270\"");
						throw new NullReferenceException();
					}
				}
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private unsafe void TryDetonate()
	{
		//IL_006b: Expected I4, but got I8
		//IL_07dd: Expected O, but got I4
		//IL_00ac: Expected O, but got I4
		//IL_01d2: Expected I4, but got I8
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_069b: Expected I, but got O
		//IL_06ff: Expected O, but got I4
		//IL_0273: Expected I, but got O
		//IL_02d7: Expected O, but got I4
		//IL_03d2: Expected I, but got O
		//IL_0428: Expected O, but got I4
		//IL_0444: Expected O, but got I4
		//IL_053f: Expected I, but got O
		//IL_05a3: Expected O, but got I4
		List<ParticleSystem> seasonEmitters = _seasonEmitters;
		int season = _season;
		float durationMillis;
		SfxType sfxType;
		if (_season < seasonEmitters._size)
		{
			ParticleSystem[] items = seasonEmitters._items;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			RenderingExtensions.EmitParticleAt(items[season], pos, -1);
			bool flag = _season == 0;
			durationMillis = 500f;
			sfxType = SfxType.Seasons2;
			if (!flag)
			{
				object obj = _season - 1;
				if (flag)
				{
					sfxType = SfxType.Seasons3;
					goto IL_07e2;
				}
				object obj2 = obj - 1;
				if (!flag)
				{
					object obj3 = obj2 - 1;
					if (!flag)
					{
						bool flag2 = (nint)obj3 != 1;
						durationMillis = 500f;
						sfxType = SfxType.Seasons2;
						if (!flag2)
						{
							sfxType = SfxType.Seasons6;
							goto IL_07e2;
						}
					}
					else
					{
						durationMillis = 500f;
						sfxType = SfxType.Seasons5;
					}
				}
				else
				{
					durationMillis = 500f;
					sfxType = SfxType.Seasons4;
				}
			}
			goto IL_07b8;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_07e2:
		durationMillis = 6000f;
		goto IL_07b8;
		IL_07b8:
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(sfxType, soundConfig, durationMillis, 1, time);
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		bool flag3 = !config._003CFlashingVFXEnabled_003Ek__BackingField;
		int num = -1;
		int num2 = 1;
		if (!flag3)
		{
			if (_tween1 != null)
			{
				_tween1.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			Transform transform = _ringRenderer.transform;
			if ((object)transform != null)
			{
				nint num3 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.scale = (float?)(object)1;
			TweenCallback onStart = delegate
			{
				_ringRenderer.enabled = true;
				SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_ringRenderer, 0f);
			};
			tweenConfig.onStart = onStart;
			TweenCallback onComplete = delegate
			{
				_ringRenderer.enabled = false;
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween tween = Tweens.Add(tweenConfig);
			_tween1 = tween;
			if (_tween2 != null)
			{
				_tween2.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			Transform transform2 = _rainbowRenderer.transform;
			if ((object)transform2 != null)
			{
				nint num4 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj5 = default(object);
				if (obj5 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.scale = (float?)(object)1;
			tweenConfig2.duration = 250f;
			tweenConfig2.angle = (float?)(object)1;
			TweenCallback onStart2 = delegate
			{
				//IL_004f: Expected O, but got Ref
				_rainbowRenderer.enabled = true;
				SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_rainbowRenderer, 0f);
				Transform transform4 = _rainbowRenderer.transform;
				object obj8 = default(object);
				transform4.localEulerAngles = (Vector3)(&obj8);
			};
			tweenConfig2.onStart = onStart2;
			TweenCallback onComplete2 = delegate
			{
				_rainbowRenderer.enabled = false;
			};
			tweenConfig2.onComplete = onComplete2;
			MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
			_tween2 = tween2;
			if (_tween3 != null)
			{
				_tween3.Kill();
			}
			TweenConfig tweenConfig3 = new TweenConfig();
			object[] array3 = new object[1];
			Transform transform3 = _raysRenderer.transform;
			if ((object)transform3 != null)
			{
				nint num5 = (nint)array3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj6 = default(object);
				if (obj6 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig3.targets = array3;
			tweenConfig3.duration = 60f;
			tweenConfig3.scale = (float?)(object)1;
			TweenCallback onStart3 = delegate
			{
				//IL_004f: Expected O, but got Ref
				_raysRenderer.enabled = true;
				SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_raysRenderer, 0f);
				Transform transform4 = _raysRenderer.transform;
				object obj8 = default(object);
				transform4.localEulerAngles = (Vector3)(&obj8);
			};
			tweenConfig3.onStart = onStart3;
			TweenCallback onComplete3 = delegate
			{
				_raysRenderer.enabled = false;
			};
			tweenConfig3.onComplete = onComplete3;
			num = 0;
			MultiTargetTween tween3 = Tweens.Add(tweenConfig3);
			_tween3 = tween3;
			num2 = 0;
		}
		if (_tween4 != null)
		{
			_tween4.Kill();
		}
		TweenConfig tweenConfig4 = new TweenConfig();
		object[] array4 = new object[1];
		if ((object)_kanji != null)
		{
			nint num6 = (nint)array4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj7 = default(object);
			if (obj7 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig4.targets = array4;
		tweenConfig4.duration = 200f;
		tweenConfig4.scale = (float?)(object)1;
		TweenCallback onStart4 = delegate
		{
			//IL_002e: Expected O, but got I4
			PhaserSprite phaserSprite = _kanji.setVisible(visible: true);
			PhaserSprite phaserSprite2 = _kanji.setScale(0f, (float?)(object)0);
			PhaserSprite phaserSprite3 = _kanji.setAlpha(1f);
			PhaserSprite phaserSprite4 = _kanji.setTint(16777215u);
		};
		tweenConfig4.onStart = onStart4;
		TweenCallback onComplete4 = delegate
		{
			//IL_005e: Expected I, but got O
			//IL_00c2: Expected O, but got I4
			//IL_00d0: Expected O, but got I4
			//IL_00de: Expected O, but got I4
			if (_tween5 != null)
			{
				_tween5.Kill();
			}
			TweenConfig tweenConfig5 = new TweenConfig();
			object[] array5 = new object[1];
			if ((object)_kanji != null)
			{
				nint num7 = (nint)array5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj8 = default(object);
				if (obj8 == null)
				{
					ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
					throw ex5;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig5.targets = array5;
			tweenConfig5.duration = 200f;
			tweenConfig5.scale = (float?)(object)1;
			tweenConfig5.alpha = (float?)(object)1;
			tweenConfig5.tint = (uint?)(object)1;
			MultiTargetTween tween5 = Tweens.Add(tweenConfig5);
			_tween5 = tween5;
		};
		tweenConfig4.onComplete = onComplete4;
		TweenCallback onUpdate = delegate
		{
			float2 float6 = base.position;
			PhaserSprite phaserSprite = _kanji.setPosition(float6);
		};
		tweenConfig4.onUpdate = onUpdate;
		MultiTargetTween tween4 = Tweens.Add(tweenConfig4);
		_tween4 = tween4;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_0114: Expected O, but got I4
		//IL_011e: Expected O, but got I4
		//IL_01f5: Expected O, but got I
		//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Expected O, but got Unknown
		//IL_019f->IL0248: Incompatible stack heights: 1 vs 0
		//IL_01d6->IL0248: Incompatible stack heights: 1 vs 0
		//IL_0306->IL0248: Incompatible stack heights: 2 vs 0
		//IL_0215->IL0248: Incompatible stack heights: 2 vs 0
		//IL_0366->IL0248: Incompatible stack heights: 3 vs 0
		//IL_0416->IL0248: Incompatible stack heights: 6 vs 0
		//IL_0247->IL041b: Incompatible stack heights: 6 vs 0
		BaseBody baseBody = body;
		if (body != null)
		{
			if (!baseBody._enable)
			{
				return;
			}
			FourSeasonsWeapon trueWeapon = _trueWeapon;
			if ((object)_trueWeapon != null && trueWeapon._positions != null)
			{
				float2 float5 = default(float2);
				base.position = float5;
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					PhaserScene.Renderer renderer = s_scene._renderer;
					if (s_scene._renderer != null)
					{
						float height = renderer.height;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
						object obj = height ^ 0;
						float num = (float)obj * 100f;
						ArcadeSprite arcadeSprite = setDepth(num);
						List<GravityWell> seasonWells = _seasonWells;
						bool flag = _seasonWells == null;
						object obj2 = 0;
						object obj3 = 0;
						if (!flag)
						{
							float2 value = default(float2);
							while (true)
							{
								if ((nint)obj3 < seasonWells._size)
								{
									List<GravityWell> seasonWells2 = _seasonWells;
									if (_seasonWells == null)
									{
										break;
									}
									bool flag2 = (nint)obj2 >= seasonWells2._size;
									GravityWell[] items = seasonWells2._items;
									if (seasonWells2._items == null)
									{
										break;
									}
									object obj4 = items[obj2];
									if ((object)items[obj2] == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rbx_v16 (System.Object)+10]");
									bool flag3 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rbx_v16 (System.Object)+10]");
									IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
									Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
									object weapon = _weapon;
									if ((object)_weapon == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rbx_v17 (System.Object)+58]");
									object obj5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rbx_v17 (System.Object)+58]");
									if ((nint)0 == 0)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rbx_v18 (System.Object)+10]");
									bool flag4 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rbx_v18 (System.Object)+10]");
									IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
									Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
									if ((object)transform2 == null)
									{
										break;
									}
									bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
									float2 ret;
									Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)(&ret));
									bool flag6 = (object)transform == null;
									bool flag7 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
									seasonWells = _seasonWells;
									obj2++;
									if (_seasonWells == null)
									{
										break;
									}
									obj3 = obj2;
									continue;
								}
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		BaseBody baseBody = body;
		if (baseBody._enable)
		{
			baseBody._enable = false;
			Action onComplete = delegate
			{
				_isCullable = true;
				base.Despawn();
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}

	public FourSeasonsProjectile()
	{
		List<ParticleEmitterManager> seasonParticles = new List<ParticleEmitterManager>();
		_seasonParticles = seasonParticles;
		_seasonEmitters = new List<ParticleSystem>();
		_seasonWells = new List<GravityWell>();
		base._002Ector();
	}

	private void _003COnRecycle_003Eb__24_0()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		Despawn();
	}

	private void _003CTryDetonate_003Eb__25_0()
	{
		_ringRenderer.enabled = true;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_ringRenderer, 0f);
	}

	private void _003CTryDetonate_003Eb__25_1()
	{
		_ringRenderer.enabled = false;
	}

	private unsafe void _003CTryDetonate_003Eb__25_2()
	{
		//IL_004f: Expected O, but got Ref
		_rainbowRenderer.enabled = true;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_rainbowRenderer, 0f);
		Transform transform = _rainbowRenderer.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
	}

	private void _003CTryDetonate_003Eb__25_3()
	{
		_rainbowRenderer.enabled = false;
	}

	private unsafe void _003CTryDetonate_003Eb__25_4()
	{
		//IL_004f: Expected O, but got Ref
		_raysRenderer.enabled = true;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_raysRenderer, 0f);
		Transform transform = _raysRenderer.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
	}

	private void _003CTryDetonate_003Eb__25_5()
	{
		_raysRenderer.enabled = false;
	}

	private void _003CTryDetonate_003Eb__25_6()
	{
		//IL_002e: Expected O, but got I4
		PhaserSprite phaserSprite = _kanji.setVisible(visible: true);
		PhaserSprite phaserSprite2 = _kanji.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite3 = _kanji.setAlpha(1f);
		PhaserSprite phaserSprite4 = _kanji.setTint(16777215u);
	}

	private void _003CTryDetonate_003Eb__25_7()
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		//IL_00d0: Expected O, but got I4
		//IL_00de: Expected O, but got I4
		if (_tween5 != null)
		{
			_tween5.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_kanji != null)
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
		tweenConfig.duration = 200f;
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.alpha = (float?)(object)1;
		tweenConfig.tint = (uint?)(object)1;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween5 = tween;
	}

	private void _003CTryDetonate_003Eb__25_8()
	{
		float2 float5 = base.position;
		PhaserSprite phaserSprite = _kanji.setPosition(float5);
	}

	private void _003CDespawn_003Eb__27_0()
	{
		_isCullable = true;
		base.Despawn();
	}
}
