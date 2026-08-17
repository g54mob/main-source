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
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_PowerOfLire_Projectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public PhaserSprite sprite;

		public TP_PowerOfLire_Projectile _003C_003E4__this;

		internal void _003CFireSpark_003Eb__0()
		{
			//IL_0085: Expected O, but got I4
			TP_PowerOfLire_Projectile tP_PowerOfLire_Projectile = _003C_003E4__this;
			float2 position = tP_PowerOfLire_Projectile._animatedSprite.position;
			PhaserSprite phaserSprite = sprite.setPosition(position);
			PhaserSprite phaserSprite2 = sprite.setVisible(visible: true);
			PhaserSprite phaserSprite3 = sprite.setAlpha(3f);
			PhaserSprite phaserSprite4 = sprite.setScale(2f, (float?)(object)0);
		}

		internal void _003CFireSpark_003Eb__1()
		{
			PhaserSprite phaserSprite = sprite.setVisible(visible: false);
		}
	}

	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public TP_PowerOfLire_Projectile _003C_003E4__this;

		public float value;

		internal void _003CMakeCoin_003Eb__0(Pickup pickup)
		{
			//IL_0044: Expected I, but got O
			//IL_004c: Expected I, but got O
			//IL_005c: Expected O, but got I
			//IL_00dc: Expected O, but got I4
			//IL_0098: Expected O, but got I
			//IL_00ce: Expected O, but got I4
			//IL_027c: Expected O, but got F4
			//IL_01d3: Expected F4, but got I4
			if ((object)pickup == null || ((UnityEngine.Object)pickup).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			nint num = (nint)typeof(Coin);
			nint num2 = (nint)pickup;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.Coin>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.Coin>)+130]");
			object obj3;
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ rax_v43+FFFFFFF8+v302 @ rax_v8*8]");
				if (0 == (nint)typeof(Coin))
				{
					obj3 = 1;
					goto IL_0204;
				}
			}
			obj3 = 0;
			goto IL_0204;
			IL_0204:
			bool flag = obj3 == null;
			Pickup pickup2 = null;
			if (!flag)
			{
				pickup2 = pickup;
			}
			if ((object)pickup2 != null && ((UnityEngine.Object)pickup2).m_CachedPtr != (IntPtr)0)
			{
				TP_PowerOfLire_Projectile tP_PowerOfLire_Projectile = _003C_003E4__this;
				string spriteName = Extensions.PickRnd(tP_PowerOfLire_Projectile.coinBagFrames);
				_ = 1;
				Sprite sprite = SpriteManager.GetSprite(spriteName, "TP_items");
				ArcadeSprite arcadeSprite = pickup2.setFrame(sprite);
				if (value > 1000f)
				{
					value = 1000f;
				}
				pickup2._003CValue_003Ek__BackingField = value;
			}
			object obj4 = UnityEngine.Random.value;
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_PickupGold, 100f, 1, 0f, volume, rate, detune, loop, 1f);
		}
	}

	private MultiTargetTween _tween1;

	private PhaserSprite _animatedSprite;

	private List<PhaserSprite> _sparkSprites;

	private int sparkCounter;

	private int frameIndex;

	private float frameTime;

	private bool _isActivated;

	private MultiTargetTween _tween2;

	private bool _canUpdate;

	private List<string> coinBagFrames;

	private List<int> _tints;

	private int tintCounter;

	private bool isFiring;

	protected override void Awake()
	{
		//IL_00ee: Expected O, but got I4
		//IL_00ee: Expected I4, but got O
		//IL_0156: Expected O, but got I4
		//IL_0156: Expected I4, but got O
		base.Awake();
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		GameObject gameObject = base.gameObject;
		Vector2 vector = default(Vector2);
		PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_PowerOf01");
		_animatedSprite = animatedSprite;
		PhaserSprite phaserSprite = _animatedSprite.setDepth(2000);
		PhaserSprite phaserSprite2 = _animatedSprite.setVisible(visible: false);
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_PowerOf", 1, 12, vector, text, num, flag);
		PhaserSprite animatedSprite2 = _animatedSprite;
		Action action = FirePowerOfLire;
		bool autoSetAnimation = default(bool);
		animatedSprite2._spriteAnimation.AddAnimation("appear", animationFrames, 32, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("PowerOfLire", 1, 12, vector, text, num, flag);
		PhaserSprite animatedSprite3 = _animatedSprite;
		animatedSprite3._spriteAnimation.AddAnimation("loop", animationFrames2, 24, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		List<PhaserSprite> sparkSprites = new List<PhaserSprite>();
		_sparkSprites = sparkSprites;
		int num2 = 0;
		do
		{
			GameObject gameObject2 = base.gameObject;
			PhaserSprite phaserSprite3 = RenderingExtensions.AddPhaserSprite(gameObject2, vector, "ThosePeople", "TP_VFX_PowerOf00");
			PhaserSprite phaserSprite4 = phaserSprite3.setBlendMode(BlendMode.Add);
			PhaserSprite phaserSprite5 = phaserSprite3.setAlpha(0.65f);
			PhaserSprite phaserSprite6 = phaserSprite3.setVisible(visible: false);
			List<object> sparkSprites2 = (List<object>)(object)_sparkSprites;
			int version = sparkSprites2._version + 1;
			sparkSprites2._version = version;
			object[] items = sparkSprites2._items;
			if (sparkSprites2._size >= items.Length)
			{
				sparkSprites2.AddWithResize((object)phaserSprite3);
			}
			else
			{
				int num3 = sparkSprites2._size + 1;
				sparkSprites2._size = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			num2++;
		}
		while (num2 < 8);
		sparkCounter = 0;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0149: Expected O, but got I4
		//IL_0080: Expected O, but got I4
		//IL_00e1: Expected I4, but got I8
		//IL_0165: Expected O, but got F4
		//IL_0183: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body;
		baseBody._enable = false;
		_isCullable = false;
		isFiring = false;
		tintCounter = 0;
		PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: true);
		PhaserSprite phaserSprite2 = _animatedSprite.setAlpha(1f);
		PhaserSprite phaserSprite3 = _animatedSprite.setScale(1f, (float?)(object)0);
		PhaserSprite animatedSprite = _animatedSprite;
		animatedSprite._spriteAnimation.SetAnimation("appear");
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float6 = default(float2);
		base.position = float6;
		PhaserSprite phaserSprite4 = _animatedSprite.setDepth(-1);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		float num = (float)float6 - 0.5f;
		soundConfig.Volume = (float?)(object)1;
		float detune = num * 200f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_PowerOfSire, soundConfig, 200f, 3, time);
	}

	public unsafe void FirePowerOfLire()
	{
		//IL_00c1: Expected O, but got I4
		//IL_0137: Invalid comparison between F4 and I4
		//IL_0157: Expected O, but got I4
		//IL_0384: Expected I, but got O
		//IL_039a: Expected O, but got I
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Expected O, but got Unknown
		//IL_041e: Expected I, but got O
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected O, but got Unknown
		//IL_04ca: Expected O, but got I4
		//IL_0505: Expected I, but got I8
		//IL_03fa: Expected I, but got I8
		//IL_0491: Unknown result type (might be due to invalid IL or missing references)
		//IL_0496: Expected O, but got Unknown
		//IL_049e: Invalid comparison between F4 and O
		isFiring = true;
		PhaserSprite phaserSprite = _animatedSprite.setTint(16777215u);
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		PhaserSprite animatedSprite = _animatedSprite;
		bool visible;
		if (!config._003CFlashingVFXEnabled_003Ek__BackingField)
		{
			visible = false;
		}
		else
		{
			animatedSprite._spriteAnimation.SetAnimation("loop");
			PhaserSprite phaserSprite2 = _animatedSprite.setAlpha(0.65f);
			PhaserSprite phaserSprite3 = _animatedSprite.setScale(1f, (float?)(object)0);
			animatedSprite = _animatedSprite;
			visible = true;
		}
		PhaserSprite phaserSprite4 = animatedSprite.setVisible(visible);
		float num = _weapon.PAmount();
		float num2 = default(float);
		bool flag = 1f > num2;
		float num3 = 1f;
		if (!flag)
		{
			num3 = num2;
		}
		GameManager core2 = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A971C0");
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (num3 > 0f)
		{
			float? num4 = (float?)(object)0;
			do
			{
				Weapon weapon = _weapon;
				WeaponData currentWeaponData = weapon._currentWeaponData;
				object obj = (_003F?)num4 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
				Action onComplete4;
				float duration;
				if ((nint)obj <= 0)
				{
					TransformItems();
					TransformEnemies();
					GM.Core.TurnOnVacuumForGold();
					FireSpark();
					Action onComplete = FireSpark;
					Timer timer = Timers.Register(0.2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					Action onComplete2 = FireSpark;
					Timer timer2 = Timers.Register(0.4f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					Action onComplete3 = FireSpark;
					Timer timer3 = Timers.Register(0.6f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					Action action = FireSpark;
					onComplete4 = action;
					duration = 0.8f;
				}
				else
				{
					Action action2 = delegate
					{
						//IL_01a4: Expected O, but got I4
						GameObject gameObject = base.gameObject;
						bool flag2 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
						object obj5 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
						if (obj5 != null)
						{
							TransformItems();
							TransformEnemies();
							GM.Core.TurnOnVacuumForGold();
							FireSpark();
							Action onComplete5 = FireSpark;
							bool useRealTime2 = default(bool);
							MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
							int repeat2 = default(int);
							TimerType type2 = default(TimerType);
							Timer timer6 = Timers.Register(0.2f, onComplete5, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
							Action onComplete6 = FireSpark;
							Timer timer7 = Timers.Register(0.4f, onComplete6, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
							Action onComplete7 = FireSpark;
							Timer timer8 = Timers.Register(0.6f, onComplete7, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
							Action onComplete8 = FireSpark;
							Timer timer9 = Timers.Register(0.8f, onComplete8, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
						}
					};
					float num5 = (float)num4 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
					duration = num5 * 0.001f;
					onComplete4 = action2;
				}
				Timer timer4 = Timers.Register(duration, onComplete4, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				num4 = (float?)(object)((_003F?)num4 + 1);
			}
			while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) > System.Runtime.CompilerServices.Unsafe.As<float?, UIntPtr>(ref num4));
		}
		Weapon weapon2 = _weapon;
		WeaponData currentWeaponData2 = weapon2._currentWeaponData;
		Action action3 = null;
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ r10_v1 (Il2CppMethodInfo)+8]");
		((Delegate)action3).method_ptr = (IntPtr)0;
		((Delegate)action3).method = (nint)__ldftn(TP_PowerOfLire_Projectile.Finish);
		((Delegate)action3).m_target = this;
		((Delegate)action3).method_code = (IntPtr)action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ r10_v1 (Il2CppMethodInfo)+4C]");
		object obj2 = (nint)0 >> 4;
		object obj3 = obj2 & 1;
		nint num7;
		if (obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ r10_v1 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num7 = unchecked((nint)6447293664L);
				goto IL_04c1;
			}
		}
		num7 = ((Delegate)action3).method_ptr;
		((Delegate)action3).method_code = (IntPtr)((Delegate)action3).m_target;
		goto IL_04c1;
		IL_04c1:
		object obj4 = 24;
		float num8 = num3 * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
		float duration2 = num8 * 0.001f;
		((Delegate)action3).extra_arg = unchecked((nint)6447293568L);
		Timer timer5 = Timers.Register(duration2, action3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void FireSpark()
	{
		//IL_01aa: Expected O, but got F4
		//IL_00d5: Expected I, but got O
		//IL_0127: Expected O, but got I4
		//IL_01dc: Expected O, but got F4
		//IL_01f8: Expected O, but got I4
		//IL_0206: Expected O, but got I4
		//IL_0214: Expected O, but got I4
		//IL_00f8->IL00f8: Incompatible stack heights: 2 vs 1
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals9._003C_003E4__this = this;
		List<PhaserSprite> sparkSprites = _sparkSprites;
		int num = sparkCounter + 1;
		sparkCounter = num;
		int num2 = sparkCounter % sparkSprites._size;
		bool flag = num2 >= sparkSprites._size;
		PhaserSprite[] items = sparkSprites._items;
		CS_0024_003C_003E8__locals9.sprite = items[num2];
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num3 = (float)obj2 * ((float)Math.PI * 2f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float2 float5 = _animatedSprite.position;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)CS_0024_003C_003E8__locals9.sprite != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			bool flag2 = obj3 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.alpha = (float?)(object)1;
		object obj4 = UnityEngine.Random.value;
		tweenConfig.duration = 300f;
		tweenConfig.angle = (float?)(object)1;
		tweenConfig.x = (float?)(object)1;
		tweenConfig.y = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			//IL_0085: Expected O, but got I4
			TP_PowerOfLire_Projectile tP_PowerOfLire_Projectile = CS_0024_003C_003E8__locals9._003C_003E4__this;
			float2 float6 = tP_PowerOfLire_Projectile._animatedSprite.position;
			PhaserSprite phaserSprite = CS_0024_003C_003E8__locals9.sprite.setPosition(float6);
			PhaserSprite phaserSprite2 = CS_0024_003C_003E8__locals9.sprite.setVisible(visible: true);
			PhaserSprite phaserSprite3 = CS_0024_003C_003E8__locals9.sprite.setAlpha(3f);
			PhaserSprite phaserSprite4 = CS_0024_003C_003E8__locals9.sprite.setScale(2f, (float?)(object)0);
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			PhaserSprite phaserSprite = CS_0024_003C_003E8__locals9.sprite.setVisible(visible: false);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private void Finish()
	{
		PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
		GM.Core.TurnOnVacuumForGold();
		Despawn();
	}

	public override void InternalUpdate()
	{
		//IL_007c: Expected O, but got I
		if (!isFiring)
		{
			List<int> tints = _tints;
			int num = tintCounter + 1;
			tintCounter = num;
			int num2 = tintCounter;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
			int num3 = (int)((nint)num2 % (nint)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
			if ((nint)num3 >= (nint)0)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v5 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj = 0;
			PhaserSprite animatedSprite = _animatedSprite;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v14+20+v108 @ rdx_v7 (System.Int32)*4]");
			PhaserSprite phaserSprite = animatedSprite.setTint(0u);
		}
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float6 = default(float2);
		base.position = float6;
	}

	public override void Despawn()
	{
		base.Despawn();
	}

	public void MakeCoin(Vector2 pos, float value)
	{
		_003C_003Ec__DisplayClass20_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass20_0();
		CS_0024_003C_003E8__locals6._003C_003E4__this = this;
		CS_0024_003C_003E8__locals6.value = value;
		Action<Pickup> callback = delegate(Pickup pickup)
		{
			//IL_0044: Expected I, but got O
			//IL_004c: Expected I, but got O
			//IL_005c: Expected O, but got I
			//IL_00dc: Expected O, but got I4
			//IL_0098: Expected O, but got I
			//IL_00ce: Expected O, but got I4
			//IL_027c: Expected O, but got F4
			//IL_01d3: Expected F4, but got I4
			if ((object)pickup == null || ((UnityEngine.Object)pickup).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			nint num = (nint)typeof(Coin);
			nint num2 = (nint)pickup;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.Coin>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.Coin>)+130]");
			object obj3;
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ rax_v43+FFFFFFF8+v302 @ rax_v8*8]");
				if (0 == (nint)typeof(Coin))
				{
					obj3 = 1;
					goto IL_0204;
				}
			}
			obj3 = 0;
			goto IL_0204;
			IL_0204:
			bool flag = obj3 == null;
			Pickup pickup2 = null;
			if (!flag)
			{
				pickup2 = pickup;
			}
			if ((object)pickup2 != null && ((UnityEngine.Object)pickup2).m_CachedPtr != (IntPtr)0)
			{
				TP_PowerOfLire_Projectile tP_PowerOfLire_Projectile = CS_0024_003C_003E8__locals6._003C_003E4__this;
				string spriteName = Extensions.PickRnd(tP_PowerOfLire_Projectile.coinBagFrames);
				_ = 1;
				Sprite sprite = SpriteManager.GetSprite(spriteName, "TP_items");
				ArcadeSprite arcadeSprite = pickup2.setFrame(sprite);
				if (CS_0024_003C_003E8__locals6.value > 1000f)
				{
					CS_0024_003C_003E8__locals6.value = 1000f;
				}
				pickup2._003CValue_003Ek__BackingField = CS_0024_003C_003E8__locals6.value;
			}
			object obj4 = UnityEngine.Random.value;
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_PickupGold, 100f, 1, 0f, volume, rate, detune, loop, 1f);
		};
		GM.Core.MakeCoin(pos, 1f, callback);
	}

	protected unsafe void TransformEnemies(bool erase = false)
	{
		//IL_003c: Expected O, but got I4
		//IL_0068: Expected O, but got Ref
		Weapon weapon = _weapon;
		GameManager gameMan = weapon._gameMan;
		List<EnemyController> allEnemiesInScreenBounds = gameMan._stage.GetAllEnemiesInScreenBounds(0f);
		object obj = 0;
		List<EnemyController> list = allEnemiesInScreenBounds;
		List<EnemyController> list2 = allEnemiesInScreenBounds;
		List<EnemyController> list3 = null;
		List<EnemyController>.Enumerator enumerator = default(List<EnemyController>.Enumerator);
		if (enumerator.MoveNext())
		{
			ArcadeSprite arcadeSprite = null;
			List<EnemyController>.Enumerator enumerator2 = (List<EnemyController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	protected unsafe void TransformItems()
	{
		//IL_0051: Expected O, but got Ref
		//IL_0332: Expected O, but got Ref
		//IL_03ea: Expected O, but got Ref
		//IL_05a3: Expected O, but got Ref
		Weapon weapon = _weapon;
		GameManager gameMan = weapon._gameMan;
		List<Pickup> allPickupsInScreenBounds = gameMan._stage.GetAllPickupsInScreenBounds();
		List<Pickup>.Enumerator enumerator = default(List<Pickup>.Enumerator);
		if (enumerator.MoveNext())
		{
			ArcadeSprite arcadeSprite = null;
			List<Pickup>.Enumerator enumerator2 = (List<Pickup>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		Weapon weapon2 = _weapon;
		GameManager gameMan2 = weapon2._gameMan;
		List<Pickup> allGemsInScreenBounds = gameMan2._stage.GetAllGemsInScreenBounds();
		List<Pickup>.Enumerator enumerator3 = default(List<Pickup>.Enumerator);
		if (enumerator3.MoveNext())
		{
			ArcadeSprite arcadeSprite2 = null;
			ArcadeSprite arcadeSprite3 = (ArcadeSprite)(&enumerator3);
			throw new NullReferenceException();
		}
		Weapon weapon3 = _weapon;
		GameManager gameMan3 = weapon3._gameMan;
		List<Pickup> allFrozenSoulsInScreenBounds = gameMan3._stage.GetAllFrozenSoulsInScreenBounds();
		List<Pickup>.Enumerator enumerator4 = default(List<Pickup>.Enumerator);
		if (enumerator4.MoveNext())
		{
			ArcadeSprite arcadeSprite4 = null;
			TP_PowerOfLire_Projectile tP_PowerOfLire_Projectile = (TP_PowerOfLire_Projectile)(&enumerator4);
			throw new NullReferenceException();
		}
		Weapon weapon4 = _weapon;
		GameManager gameMan4 = weapon4._gameMan;
		List<Destructible> allDestructiblesInScreenBounds = gameMan4._stage.GetAllDestructiblesInScreenBounds();
		List<Destructible>.Enumerator enumerator5 = default(List<Destructible>.Enumerator);
		if (enumerator5.MoveNext())
		{
			ArcadeSprite arcadeSprite5 = null;
			TP_PowerOfLire_Projectile tP_PowerOfLire_Projectile = (TP_PowerOfLire_Projectile)(&enumerator5);
			throw new NullReferenceException();
		}
	}

	public TP_PowerOfLire_Projectile()
	{
		//IL_0ca9: Expected O, but got I
		//IL_0d03: Expected O, but got I
		//IL_0fd2: Expected O, but got I
		//IL_0d6d: Expected O, but got I
		//IL_0ffa: Expected O, but got I
		//IL_0dd7: Expected O, but got I
		//IL_1022: Expected O, but got I
		//IL_0e41: Expected O, but got I
		//IL_104a: Expected O, but got I
		//IL_0eab: Expected O, but got I
		//IL_1072: Expected O, but got I
		//IL_0f15: Expected O, but got I
		//IL_109a: Expected O, but got I
		//IL_0f7f: Expected O, but got I
		List<string> list = new List<string>();
		list._version++;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Moneybag01");
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
			((List<object>)(object)list).AddWithResize((object)"TP_Moneybag02");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Moneybag03");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Moneybag04");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Moneybag05");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items6 = list._items;
		if (list._size >= items6.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Moneybag06");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items7 = list._items;
		if (list._size >= items7.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Moneybag07");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items8 = list._items;
		if (list._size >= items8.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Moneybag08");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items9 = list._items;
		if (list._size >= items9.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Moneybag09");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items10 = list._items;
		if (list._size >= items10.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Moneybag10");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items11 = list._items;
		if (list._size >= items11.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Moneybag11");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items12 = list._items;
		if (list._size >= items12.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Moneybag12");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items13 = list._items;
		if (list._size >= items13.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Moneybag13");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items14 = list._items;
		if (list._size >= items14.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Moneybag14");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items15 = list._items;
		if (list._size >= items15.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Moneybag15");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items16 = list._items;
		if (list._size >= items16.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Moneybag16");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items17 = list._items;
		if (list._size >= items17.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Moneybag17");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items18 = list._items;
		if (list._size >= items18.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Moneybag18");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items19 = list._items;
		if (list._size >= items19.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Moneybag19");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items20 = list._items;
		if (list._size >= items20.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Moneybag20");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items21 = list._items;
		if (list._size >= items21.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Moneybag21");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		coinBagFrames = list;
		List<int> list2 = new List<int>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v48+18]");
		if (num >= 0)
		{
			list2.AddWithResize(8421624);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 8421624;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rdx_v50+18]");
		if (num2 >= 0)
		{
			list2.AddWithResize(8452344);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 8452344;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rdx_v52+18]");
		if (num3 >= 0)
		{
			list2.AddWithResize(8452224);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 8452224;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdx_v54+18]");
		if (num4 >= 0)
		{
			list2.AddWithResize(16316544);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 16316544;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdx_v56+18]");
		if (num5 >= 0)
		{
			list2.AddWithResize(16302208);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 16302208;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rdx_v58+18]");
		if (num6 >= 0)
		{
			list2.AddWithResize(16285824);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 16285824;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rdx_v60+18]");
		if (num7 >= 0)
		{
			list2.AddWithResize(5533070);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 5533070;
		}
		_tints = list2;
		base._002Ector();
	}

	private void _003CFirePowerOfLire_003Eb__15_0()
	{
		//IL_01a4: Expected O, but got I4
		GameObject gameObject = base.gameObject;
		bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
		object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
		if (obj != null)
		{
			TransformItems();
			TransformEnemies();
			GM.Core.TurnOnVacuumForGold();
			FireSpark();
			Action onComplete = FireSpark;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			Action onComplete2 = FireSpark;
			Timer timer2 = Timers.Register(0.4f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			Action onComplete3 = FireSpark;
			Timer timer3 = Timers.Register(0.6f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			Action onComplete4 = FireSpark;
			Timer timer4 = Timers.Register(0.8f, onComplete4, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}
}
