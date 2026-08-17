using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class BubbleWeapon : Weapon
{
	protected override void OnStart()
	{
		base.OnStart();
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.collider(_projectilePool, _projectilePool, null, processCallback, callbackContext);
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_00b9: Expected I, but got O
		//IL_00c7: Expected I, but got O
		//IL_00d7: Expected O, but got I
		//IL_0157: Expected O, but got I4
		//IL_0113: Expected O, but got I
		//IL_0149: Expected O, but got I4
		GameManager core = GM.Core;
		Projectile projectile;
		Projectile projectile2;
		object obj3;
		if ((object)GM.Core != null && (object)core._stage != null)
		{
			if (!core._stage.IsCharacterNearYourPlayer(((Equipment)this)._003COwner_003Ek__BackingField))
			{
				return null;
			}
			if (_projectilePool != null)
			{
				float2 pos2 = default(float2);
				projectile = _projectilePool.SpawnAt(pos2, this, index);
				bool flag = (object)projectile == null;
				projectile2 = null;
				if (!flag)
				{
					nint num = (nint)projectile;
					nint num2 = (nint)typeof(BubbleProjectile);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BubbleProjectile>)+130]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BubbleProjectile>)+130]");
					if (num3 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rax_v42+FFFFFFF8+v200 @ rax_v38*8]");
						if (0 == (nint)typeof(BubbleProjectile))
						{
							obj3 = 1;
							goto IL_024e;
						}
					}
					obj3 = 0;
					goto IL_024e;
				}
				goto IL_0275;
			}
		}
		return (Projectile)(object)new NullReferenceException();
		IL_02b4:
		((BubbleProjectile)projectile2).SetColor(16777215u);
		goto IL_020d;
		IL_024e:
		bool flag2 = obj3 == null;
		projectile2 = null;
		if (!flag2)
		{
			projectile2 = projectile;
		}
		goto IL_0275;
		IL_020d:
		return projectile2;
		IL_0275:
		if ((object)target != null && ((UnityEngine.Object)target).m_CachedPtr != (IntPtr)0)
		{
			if ((object)projectile2 == null)
			{
				goto IL_020d;
			}
			if (((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
			{
				projectile2.SetTarget(target);
				goto IL_02b4;
			}
		}
		if ((object)projectile2 == null)
		{
			goto IL_020d;
		}
		projectile2.SetNullTarget();
		goto IL_02b4;
	}

	protected override void OnUpdate()
	{
		//IL_005a: Expected O, but got I
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_0175: Expected F4, but got O
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		ArcadeSprite magnet = characterController._magnet;
		float2 position = characterController._magnet.position;
		float2 position2 = characterController._magnet.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ rbx_v3 (ArcadeSprite)+70]");
		object obj = 0;
		float eggValue = default(float);
		float value = default(float);
		EggFloat eggFloat = new EggFloat(value, eggValue);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v4+14]");
		eggValue = 0f * 0.01f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v4+10]");
		value = 0f * 0.01f;
		float num = eggFloat._eggVal + eggFloat._val;
		object obj2 = num & -2147483649L;
		if ((nint)obj2 != 2139095040)
		{
			object obj3 = num & -2147483649L;
			if ((nint)obj3 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018739BAFAh\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				goto IL_0163;
			}
		}
		num = 3.4028235E+38f;
		goto IL_0163;
		IL_0163:
		float y = default(float);
		OverlapCirc((float)position, y, num);
	}

	private void OverlapCirc(float x, float y, float radius)
	{
		//IL_00e0: Invalid comparison between I4 and F4
		//IL_0107: Expected F4, but got I4
		Circle circle = new Circle();
		circle._x = x;
		circle._y = y;
		circle._radius = radius;
		Dictionary<int, GameObject>.Enumerator enumerator = default(Dictionary<int, GameObject>.Enumerator);
		GameObject gameObject = default(GameObject);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if ((object)gameObject == null)
				{
					break;
				}
				BubbleProjectile component = gameObject.GetComponent<BubbleProjectile>();
				BaseBody body = component.body;
				float num = circle._y;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rsi_v6 (BaseBody)+54]");
				float num2 = num - 0f;
				float num3 = circle._x - (float)body._position;
				float num4 = num2 * num2;
				float num5 = num3 * num3;
				float num6 = num5 + num4;
				float num7;
				if (!(0f > num6))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm1\"");
					num7 = 0f;
				}
				else
				{
					BubbleProjectile component2 = gameObject.GetComponent<BubbleProjectile>();
					num7 = num6;
				}
				float num8 = body._radius + circle._radius;
				if (num8 < num7)
				{
					component._saveVelX = 0f;
				}
				continue;
			}
			return;
		}
		throw new NullReferenceException();
	}

	private bool CircleToCircle(Circle circleA, BaseBody circleB)
	{
		//IL_012d: Expected I4, but got O
		//IL_00a5: Invalid comparison between I4 and F4
		//IL_00cc: Expected F4, but got I4
		if (circleA != null && circleB != null)
		{
			float num = circleA._y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [circleB @ r8 (BaseBody)+54]");
			float num2 = num - 0f;
			float num3 = circleA._x - (float)circleB._position;
			float num4 = num2 * num2;
			float num5 = num3 * num3;
			float num6 = num5 + num4;
			float num7;
			if (!(0f > num6))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm1\"");
				num7 = 0f;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
				num7 = num6;
			}
			float num8 = circleB._radius + circleA._radius;
			bool flag = num8 < num7;
			return !flag;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private float DistanceBetween(float x1, float y1, float x2, float y2)
	{
		//IL_0054: Invalid comparison between I4 and F4
		//IL_0078: Expected F4, but got I4
		object obj = default(object);
		float num = y1 - (float)obj;
		float num2 = x1 - x2;
		float num3 = num * num;
		float num4 = num2 * num2;
		float num5 = num4 + num3;
		if (!(0f > num5))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm1\"");
			return 0f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
		return num5;
	}

	public override void ParadoxFire()
	{
		base.Fire(skipTriggers: true);
		Action onComplete = delegate
		{
			base.Fire(skipTriggers: true);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.05f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete2 = delegate
		{
			base.Fire(skipTriggers: true);
		};
		Timer timer2 = Timers.Register(0.1f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void _003CParadoxFire_003Eb__6_0()
	{
		base.Fire(skipTriggers: true);
	}

	private void _003CParadoxFire_003Eb__6_1()
	{
		base.Fire(skipTriggers: true);
	}
}
