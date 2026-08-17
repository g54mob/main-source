using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class LancetProjectile : Projectile
{
	private Timer _expireTimer;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body.setCircle(16f, (float?)(object)0, (float?)(object)0);
		ArcadeSprite arcadeSprite = setScale(2f, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
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
		Timer expireTimer = Timers.Register(0.020000001f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	public void SetTargetPosition(Vector2 targetPos)
	{
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
		LancetProjectile cachedTransform2 = (LancetProjectile)(object)_cachedTransform;
		bool flag2 = (object)_cachedTransform == null;
		bool flag3 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref value);
	}

	public override void Despawn()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_0269->IL01d0: Incompatible stack heights: 1 vs 0
		//IL_01cf->IL01cf: Incompatible stack heights: 1 vs 0
		if (other != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj = default(object);
			if (obj != null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component == null)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rax_v12 (VampireSurvivors.Objects.Characters.EnemyController)+10]");
				if ((nint)0 == 0)
				{
					return;
				}
				if ((object)_weapon != null)
				{
					float num = _weapon.PDuration();
					float duration = default(float);
					bool flag = component.Freeze(duration);
					if ((object)_weapon != null)
					{
						if (!_weapon.HasActiveArcanaOfType(ArcanaType.T12_OUT_OF_TIME))
						{
							return;
						}
						Weapon weapon = _weapon;
						if ((object)_weapon != null)
						{
							GameManager gameMan = weapon._gameMan;
							if ((object)weapon._gameMan != null)
							{
								Transform transform = component.transform;
								if ((object)transform != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v23 (UnityEngine.Transform)+10]");
									bool flag2 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v23 (UnityEngine.Transform)+10]");
									Transform.get_position_Injected((IntPtr)0, out Vector3 _);
									if (gameMan._arcanaManager != null)
									{
										Vector2 pos = default(Vector2);
										gameMan._arcanaManager.TriggerColdExplosion(pos);
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void _003CInitProjectile_003Eb__1_0()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		Despawn();
	}
}
