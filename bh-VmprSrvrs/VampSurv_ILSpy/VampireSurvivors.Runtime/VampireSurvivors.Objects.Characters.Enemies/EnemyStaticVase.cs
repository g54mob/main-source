using System;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyStaticVase : EnemyStatic
{
	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		base.InitEnemy(enemyType, asRemote);
		base.SetFlipX(flip: false);
	}

	protected override void Die()
	{
		//IL_0124->IL0074: Incompatible stack heights: 1 vs 0
		((EnemyController)this).Die();
		if (base._onEnterTween != null)
		{
			base._onEnterTween.Pause();
		}
		if (body != null)
		{
			BaseBody baseBody = body;
			baseBody._enable = false;
		}
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			Action<Pickup> callback = delegate(Pickup c)
			{
				if ((object)c != null && ((UnityEngine.Object)c).m_CachedPtr != (IntPtr)0)
				{
					float2 float5 = base.position;
					bool includeFollowers = default(bool);
					CharacterController closestPlayer = _gameManager.GetClosestPlayer(float5, PlayerInclusionMode.AlivePreferred, 3.4028235E+38f, includeFollowers);
					bool flag2 = c.Vacuum(closestPlayer);
				}
			};
			if ((object)_gameManager != null)
			{
				Vector2 pos = default(Vector2);
				_gameManager.MakeCoin(pos, 0f, callback);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public EnemyStaticVase()
	{
		//IL_001b: Expected I4, but got I8
		base._prevDepth = -1;
		((EnemyController)this)._002Ector();
	}

	private void _003CDie_003Eb__1_0(Pickup c)
	{
		if ((object)c != null && ((UnityEngine.Object)c).m_CachedPtr != (IntPtr)0)
		{
			float2 float5 = base.position;
			bool includeFollowers = default(bool);
			CharacterController closestPlayer = _gameManager.GetClosestPlayer(float5, PlayerInclusionMode.AlivePreferred, 3.4028235E+38f, includeFollowers);
			bool flag = c.Vacuum(closestPlayer);
		}
	}
}
