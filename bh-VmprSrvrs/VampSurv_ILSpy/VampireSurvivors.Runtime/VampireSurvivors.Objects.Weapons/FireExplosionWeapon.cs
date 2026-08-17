using System;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Signals;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class FireExplosionWeapon : Weapon
{
	private bool _canExplode;

	private Tween _explodeTimer;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		_canExplode = true;
		_explosionType = WeaponType.FIREEXPLOSION;
		Action<GameplaySignals.CharacterLostShieldSignal> action = null;
		((FireExplosionWeapon)(object)action).ExplodeOnPlayerShield((GameplaySignals.CharacterLostShieldSignal)this);
		((FireExplosionWeapon)(object)_signalBus).ExplodeOnPlayerShield((GameplaySignals.CharacterLostShieldSignal)action);
		Action<GameplaySignals.CharacterReceivedDamageSignal> action2 = null;
		((FireExplosionWeapon)(object)action2).ExplodeOnPlayerDamage((GameplaySignals.CharacterReceivedDamageSignal)this);
		((FireExplosionWeapon)(object)_signalBus).ExplodeOnPlayerDamage((GameplaySignals.CharacterReceivedDamageSignal)action2);
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		//IL_020a: Expected I4, but got O
		if (second == null)
		{
			goto IL_01dc;
		}
		nint num = (nint)typeof(FireExplosionProjectile);
		nint num2 = (nint)second;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FireExplosionProjectile>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ r8_v4 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FireExplosionProjectile>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ r8_v4 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v26+FFFFFFF8+v51 @ rax_v5*8]");
			if (0 == (nint)typeof(FireExplosionProjectile))
			{
				obj3 = 1;
				goto IL_0227;
			}
		}
		obj3 = 0;
		goto IL_0227;
		IL_0266:
		return false;
		IL_01dc:
		return base.OnBulletOverlapsEnemy(context, second, first);
		IL_0227:
		bool flag = obj3 == null;
		ArcadeColliderType arcadeColliderType = null;
		if (!flag)
		{
			arcadeColliderType = second;
		}
		if (arcadeColliderType != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v8 (ArcadeColliderType)+138]");
			if ((nint)0 != 0)
			{
				if (first != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					GameObject gameObject = default(GameObject);
					if ((object)gameObject != null)
					{
						EnemyController component = gameObject.GetComponent<EnemyController>();
						if ((object)component != null)
						{
							if (component._003CIsDead_003Ek__BackingField)
							{
								goto IL_0266;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							GameObject gameObject2 = default(GameObject);
							if ((object)gameObject2 != null)
							{
								Projectile component2 = gameObject2.GetComponent<Projectile>();
								if ((object)component2 != null)
								{
									if (!component2.HasAlreadyHitObject(component))
									{
										base.DealDamageRetaliation(component);
									}
									goto IL_0266;
								}
							}
						}
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
		}
		goto IL_01dc;
	}

	public override void Cleanup()
	{
		if (_signalBus != null)
		{
			Action<GameplaySignals.CharacterLostShieldSignal> action = null;
			((FireExplosionWeapon)(object)action).ExplodeOnPlayerShield((GameplaySignals.CharacterLostShieldSignal)this);
			((FireExplosionWeapon)(object)_signalBus).ExplodeOnPlayerShield((GameplaySignals.CharacterLostShieldSignal)action);
		}
		if (_signalBus != null)
		{
			Action<GameplaySignals.CharacterReceivedDamageSignal> action2 = null;
			((FireExplosionWeapon)(object)action2).ExplodeOnPlayerDamage((GameplaySignals.CharacterReceivedDamageSignal)this);
			((FireExplosionWeapon)(object)_signalBus).ExplodeOnPlayerDamage((GameplaySignals.CharacterReceivedDamageSignal)action2);
		}
		base.Cleanup();
	}

	public void TriggerExplosion(Vector2 pos, int index)
	{
		Projectile projectile = base.FireOneProjectile(pos, index);
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	private void ExplodeOnPlayerDamage(GameplaySignals.CharacterReceivedDamageSignal signal)
	{
		//IL_00fa: Expected O, but got I4
		//IL_0114: Expected O, but got I4
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		bool flag = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
		bool flag2 = (object)signal == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				if ((object)signal != null)
				{
					object obj3 = (object)signal - (object)((Equipment)this)._003COwner_003Ek__BackingField;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [signal @ rdx (VampireSurvivors.Signals.GameplaySignals+CharacterReceivedDamageSignal)+10]");
				flag4 = (nint)0 == 0;
			}
			if (!flag4)
			{
				return;
			}
		}
		ExplodeOnPlayer();
	}

	private void ExplodeOnPlayerShield(GameplaySignals.CharacterLostShieldSignal signal)
	{
		//IL_0113: Expected O, but got I4
		//IL_012d: Expected O, but got I4
		VampireSurvivors.Objects.Characters.CharacterController character = signal.Character;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		bool flag = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
		bool flag2 = (object)signal.Character == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				if ((object)signal.Character != null)
				{
					object obj3 = (object)signal.Character - (object)((Equipment)this)._003COwner_003Ek__BackingField;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)character).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				return;
			}
		}
		ExplodeOnPlayer();
	}

	private void ExplodeOnPlayer()
	{
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				Vector2 position = default(Vector2);
				ExplodeAt(position, ignoreCooldown: false, retaliate: true);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void ExplodeAt(Vector2 position, bool ignoreCooldown = false, bool retaliate = false)
	{
		//IL_01f7: Expected I, but got O
		//IL_01ff: Expected I, but got O
		//IL_020f: Expected O, but got I
		//IL_0151: Expected O, but got I
		//IL_0236->IL0196: Incompatible stack heights: 1 vs 0
		//IL_0179->IL0196: Incompatible stack heights: 1 vs 0
		//IL_0188->IL0196: Incompatible stack heights: 1 vs 0
		if (!ignoreCooldown)
		{
			if (_canExplode == ignoreCooldown)
			{
				return;
			}
			Tween explodeTimer = _explodeTimer;
			_canExplode = ignoreCooldown;
			if (_explodeTimer != null && explodeTimer._003Cactive_003Ek__BackingField != ignoreCooldown)
			{
				DG.Tweening.TweenExtensions.Kill(_explodeTimer);
			}
			TweenCallback callback = delegate
			{
				_canExplode = true;
			};
			Tween gameId = DOVirtual.DelayedCall(0.5f, callback, ignoreTimeScale: false);
			Tween explodeTimer2 = VampireSurvivors.Tools.TweenExtensions.SetGameId(gameId);
			_explodeTimer = explodeTimer2;
		}
		Projectile projectile = base.FireOneProjectile(position, 0);
		if ((object)projectile == null || ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Transform transform = projectile.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		nint num = (nint)typeof(FireExplosionProjectile);
		nint num2 = (nint)projectile;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FireExplosionProjectile>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ r8_v4 (Il2CppClass<UnityEngine.Component>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FireExplosionProjectile>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ r8_v4 (Il2CppClass<UnityEngine.Component>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v569 @ rax_v24+FFFFFFF8+v555 @ rax_v22*8]");
			if (0 != (nint)typeof(FireExplosionProjectile))
			{
			}
		}
	}

	private void _003CExplodeAt_003Eb__10_0()
	{
		_canExplode = true;
	}
}
