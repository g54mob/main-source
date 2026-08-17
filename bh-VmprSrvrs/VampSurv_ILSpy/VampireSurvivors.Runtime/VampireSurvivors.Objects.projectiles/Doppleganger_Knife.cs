using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Projectiles;

public class Doppleganger_Knife : EnemyProjectile
{
	private Timer _despawnTimer;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("ProjectileKnife3", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public override void InitProjectile(int index, float2 direction, EnemyBulletPool pool)
	{
		//IL_002a: Expected O, but got I4
		//IL_002a: Expected O, but got I4
		//IL_018c: Expected O, but got F4
		//IL_0205: Expected O, but got F4
		//IL_0061: Expected O, but got F4
		//IL_00c6: Expected O, but got I4
		//IL_0118: Expected I, but got O
		//IL_0147: Expected I4, but got F4
		base.InitProjectile(index, direction, pool);
		base._003CDamage_003Ek__BackingField = 18f;
		BaseBody baseBody = body.setCircle(8f, (float?)(object)0, (float?)(object)0);
		_speed = 2f;
		float2 float5 = base.position;
		object obj = UnityEngine.Random.value;
		if (_indexInWeapon == 0)
		{
		}
		object obj2 = UnityEngine.Random.value;
		if (_indexInWeapon == 0)
		{
			/*Error: End of method reached without returning.*/;
		}
		float2 float6 = default(float2);
		base.position = float6;
		float num = _speed * 1.6500001f;
		BaseBody baseBody2 = body;
		float num2 = (float)direction * num;
		object obj3 = default(object);
		float num3 = (float)obj3 * num;
		baseBody2._velocity = (float2)num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		float num4 = (float)obj3 * 57.29578f;
		base.angle = num4;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float num5 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Shot, soundConfig, 200f, 10, num5);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v463 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Doppleganger_Knife>)+280]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num6 = (nint)this;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer despawnTimer = Timers.Register(5f, onComplete, null, isLooped: false, (byte)(int)num5 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_despawnTimer = despawnTimer;
	}

	public override void Despawn()
	{
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		_despawnTimer = null;
		base.Despawn();
	}

	public Doppleganger_Knife()
	{
		//IL_002b: Expected I, but got O
		_speed = 1f;
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
