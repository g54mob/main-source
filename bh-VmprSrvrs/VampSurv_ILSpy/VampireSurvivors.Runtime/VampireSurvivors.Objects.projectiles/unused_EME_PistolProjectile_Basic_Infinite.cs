using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Projectiles;

public class unused_EME_PistolProjectile_Basic_Infinite : unused_EME_PistolProjectile_Basic
{
	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		GameObject gameObject = default(GameObject);
		EnemyController component = gameObject.GetComponent<EnemyController>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0 && (bool)_targetEnemyController)
		{
			bool flag;
			if ((object)_targetEnemyController != null)
			{
				object obj2 = (object)component - (object)_targetEnemyController;
				flag = obj2 == null;
			}
			else
			{
				flag = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
			}
			if (flag)
			{
				Despawn();
			}
		}
	}

	public unused_EME_PistolProjectile_Basic_Infinite()
	{
		base._useHoming = true;
		((Projectile)this)._002Ector();
	}
}
