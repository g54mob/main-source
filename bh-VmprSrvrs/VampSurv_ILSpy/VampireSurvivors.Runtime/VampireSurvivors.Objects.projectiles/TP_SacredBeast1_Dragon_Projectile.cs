using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_SacredBeast1_Dragon_Projectile : Projectile
{
	private Timer _expireTimer;

	private float _offset;

	private Vector2 _direction;

	private float2 _centralPos;

	private float _offsetDist;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("p_mws00_p006", "ThosePeople");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_002b: Expected O, but got I4
		//IL_004f: Expected O, but got I4
		//IL_004f: Expected O, but got I4
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_00f3: Expected O, but got I8
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		ArcadeSprite arcadeSprite = setVisible(visible: true);
		float num = weapon.PArea();
		float xScale = default(float);
		ArcadeSprite arcadeSprite2 = setScale(xScale, (float?)(object)0);
		BaseBody baseBody = body.setCircle(8f, (float?)(object)1, (float?)(object)1);
		float2 float5 = PickPosition();
		base.position = float5;
		float2 centralPos = base.position;
		_centralPos = centralPos;
		_ = 3229614080L;
		float2 float6 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float7 = base.position;
		Vector2 direction = float6 - float7;
		_direction = direction;
		float2 float8 = base.position;
		Vector2 vector = (Vector2)(this + 220);
		object obj = 3229614080L - 3229614080L;
		((Vector2*)vector)->Normalize();
		float2 float9 = base.position;
		float2 float10 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		bool flag = (byte)(float9 < float10) != 0;
		object obj2 = float9 - float10;
		bool flag2 = obj2 == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool flag5 = flag4 & flag3;
		ArcadeSprite arcadeSprite3 = setFlipX(flag5);
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float num2 = weapon.PDuration();
		Action onComplete = delegate
		{
			_isCullable = true;
		};
		float duration = (float)float9 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	public override void InternalUpdate()
	{
		//IL_00b5: Expected O, but got F4
		//IL_00da: Expected I, but got O
		float deltaTime = PauseSystem.DeltaTime;
		float num = (float)_direction * deltaTime;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_SacredBeast1_Dragon_Projectile)+E0]");
		float num2 = 0f * deltaTime;
		float num3 = _weapon.PSpeed();
		float num4 = num * deltaTime;
		float num5 = num2 * deltaTime;
		float num6 = num4 * 1.25f;
		float num7 = num5 * 1.25f;
		float num8 = num6 + (float)_centralPos;
		float num9 = num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_SacredBeast1_Dragon_Projectile)+E8]");
		float num10 = num9 + 0f;
		_centralPos = (float2)num8;
		float deltaTime2 = PauseSystem.DeltaTime;
		Weapon weapon = _weapon;
		nint num11 = (nint)weapon;
		float num12 = weapon.PSpeed();
		float num13 = deltaTime2 * deltaTime2;
		float num14 = num13 + num13;
		float offset = num14 + _offset;
		_offset = offset;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float2 float5 = default(float2);
		base.position = float5;
	}

	public float2 PickPosition()
	{
		//IL_0097: Expected O, but got F4
		//IL_0080: Expected O, but got F4
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 * ((float)Math.PI * 2f);
		object obj3 = UnityEngine.Random.value;
		Camera main = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		Weapon weapon2 = _weapon;
		float2 float6 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float2 result = default(float2);
		return result;
	}

	public override void Despawn()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		base.Despawn();
	}

	public TP_SacredBeast1_Dragon_Projectile()
	{
		//IL_0065: Expected I, but got O
		//IL_001f: Expected I, but got O
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v3 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		_direction = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rdx_v1 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		nint num3 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rax_v5 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num4 = 0;
		_centralPos = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rcx_v5 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		_offsetDist = 0.19999999f;
		base._002Ector();
	}

	private void _003CInitProjectile_003Eb__6_0()
	{
		_isCullable = true;
	}
}
