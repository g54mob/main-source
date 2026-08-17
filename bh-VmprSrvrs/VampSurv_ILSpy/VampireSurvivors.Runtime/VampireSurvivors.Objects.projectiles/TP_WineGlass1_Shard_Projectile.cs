using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_WineGlass1_Shard_Projectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public float __duration;

		public TP_WineGlass1_Shard_Projectile _003C_003E4__this;

		internal void _003CInitProjectile_003Eb__0()
		{
			Action onComplete = _003C_003E4__this.StartDespawn;
			float duration = __duration * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}

	private PhaserSprite _shardSprite;

	private MultiTargetTween _scaleTween;

	private List<string> _shardSprites;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		string spriteName = Extensions.PickRnd(_shardSprites);
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite shardSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", spriteName);
		_shardSprite = shardSprite;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_004a: Expected O, but got I4
		//IL_007b: Expected O, but got I4
		//IL_007b: Expected O, but got I4
		//IL_037b: Expected O, but got F4
		//IL_00ce: Invalid comparison between O and F4
		//IL_00ed: Invalid comparison between F4 and I4
		//IL_0389: Expected O, but got F4
		//IL_0137: Invalid comparison between O and F4
		//IL_0156: Invalid comparison between F4 and I4
		//IL_0397: Expected O, but got F4
		//IL_03bc: Expected O, but got F4
		//IL_041b: Expected O, but got F4
		//IL_0463: Expected O, but got I
		//IL_01f6: Expected I, but got O
		//IL_020d: Invalid comparison between I4 and F4
		//IL_01e9: Expected O, but got I8
		//IL_03ea: Expected O, but got I
		//IL_0274: Expected O, but got I8
		//IL_02b3: Expected I, but got O
		//IL_0305: Expected O, but got I4
		//IL_01ee->IL03c1: Incompatible stack heights: 1 vs 0
		//IL_0279->IL0490: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals5._003C_003E4__this = this;
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setVisible(visible: true);
		ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body.setCircle(6f, (float?)(object)0, (float?)(object)0);
		_renderer.enabled = false;
		string spriteName = Extensions.PickRnd(_shardSprites);
		PhaserSprite phaserSprite = _shardSprite.setFrame(spriteName, "ThosePeople");
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f);
		float num = (float)obj2 - 0.5f;
		bool flag2 = num == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool flag5 = flag4 & flag3;
		PhaserSprite phaserSprite2 = _shardSprite.setFlipX(flag5);
		object obj3 = UnityEngine.Random.value;
		bool flag6 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f);
		float num2 = (float)obj2 - 0.5f;
		bool flag7 = num2 == 0f;
		bool flag8 = !flag6;
		bool flag9 = !flag7;
		bool flag10 = flag9 & flag8;
		PhaserSprite phaserSprite3 = _shardSprite.setFlipY(flag10);
		Weapon weapon2 = _weapon;
		float num3 = weapon2.PSpeed();
		object obj4 = UnityEngine.Random.value;
		object obj5 = obj2 + obj2;
		float2 float5 = base.position;
		object obj6 = UnityEngine.Random.value;
		object obj7 = UnityEngine.Random.value;
		float num4 = (float)obj2 - 0.5f;
		float num5 = num4 * (float)obj5;
		object obj8 = default(object);
		float num6 = (float)obj8 + num5;
		float2 float6 = default(float2);
		base.position = float6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag11 = (nint)0 != 0;
		ArcadeSprite arcadeSprite3 = this;
		if (!flag11)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag12 = obj9 == null;
			arcadeSprite3 = (ArcadeSprite)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v974 @ rax_v61 (should have been resolved before IL gen)");
		Weapon weapon3 = _weapon;
		nint num7 = (nint)weapon3;
		float num8 = weapon3.PArea();
		if (!(0f > 1f))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm6,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag13 = obj10 == null;
			weapon3 = (Weapon)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1089 @ rax_v67 (should have been resolved before IL gen)");
		CS_0024_003C_003E8__locals5.__duration = 200f;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num9 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj11 = default(object);
		bool flag14 = obj11 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.duration = CS_0024_003C_003E8__locals5.__duration;
		TweenCallback onComplete = delegate
		{
			Action onComplete2 = CS_0024_003C_003E8__locals5._003C_003E4__this.StartDespawn;
			float duration = CS_0024_003C_003E8__locals5.__duration * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
	}

	private void StartDespawn()
	{
		//IL_003f: Expected I, but got O
		//IL_00a3: Expected O, but got I4
		//IL_00be: Expected I, but got O
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 250f;
			tweenConfig.scale = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_WineGlass1_Shard_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		base.Despawn();
	}

	public TP_WineGlass1_Shard_Projectile()
	{
		List<string> list = new List<string>();
		list._version++;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Wineglass03");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Wineglass04");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_shardSprites = list;
		base._002Ector();
	}
}
