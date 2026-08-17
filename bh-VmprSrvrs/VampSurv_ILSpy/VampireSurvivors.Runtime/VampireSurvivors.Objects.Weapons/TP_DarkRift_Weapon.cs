using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_DarkRift_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public TP_DarkRift_Weapon _003C_003E4__this;

		public float x;

		public float incrementUnit;

		public float y;
	}

	private sealed class _003C_003Ec__DisplayClass3_1
	{
		public int index1;

		public _003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals1;

		internal void _003CFire_003Eb__0()
		{
			_003C_003Ec__DisplayClass3_0 obj = CS_0024_003C_003E8__locals1;
			TP_DarkRift_Weapon tP_DarkRift_Weapon = obj._003C_003E4__this;
			Vector2 pos = default(Vector2);
			Projectile projectile = obj._003C_003E4__this.FireOneProjectile(pos, index1, tP_DarkRift_Weapon._targetTransform);
		}
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.1f;
		base._003CTotalTime_003Ek__BackingField = num2;
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = base.PInterval();
		float num2 = deltaTime * 1000f;
		if (!((base._003CTotalTime_003Ek__BackingField = num2 + base._003CTotalTime_003Ek__BackingField) < deltaTime))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			base.Fire();
		}
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		_003C_003Ec__DisplayClass3_0 obj = new _003C_003Ec__DisplayClass3_0();
		obj._003C_003E4__this = this;
		float num = base.PAmount();
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		object obj2 = default(object);
		float num2 = (float)obj2 + 1f;
		float incrementUnit = renderer.width / num2;
		obj.incrementUnit = incrementUnit;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float num3 = renderer2.width * 0.5f;
		float x = (float)position - num3;
		obj.x = x;
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float y = default(float);
		obj.y = y;
		if ((nint)obj2 > 0)
		{
			bool flag = false;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			do
			{
				WeaponData currentWeaponData = _currentWeaponData;
				object obj3 = flag * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
				if ((nint)obj3 <= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				}
				else
				{
					_003C_003Ec__DisplayClass3_1 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass3_1();
					CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1 = obj;
					CS_0024_003C_003E8__locals4.index1 = (flag ? 1 : 0);
					WeaponData currentWeaponData2 = _currentWeaponData;
					Action onComplete = delegate
					{
						_003C_003Ec__DisplayClass3_0 obj4 = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1;
						TP_DarkRift_Weapon tP_DarkRift_Weapon = obj4._003C_003E4__this;
						Vector2 pos = default(Vector2);
						Projectile projectile = obj4._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals4.index1, tP_DarkRift_Weapon._targetTransform);
					};
					float num4 = (float)(flag ? 1 : 0) * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
					float duration = num4 * 0.001f;
					Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_lastShotTimer = lastShotTimer;
				}
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			}
			while ((nint)obj2 > (flag ? 1 : 0));
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}
}
