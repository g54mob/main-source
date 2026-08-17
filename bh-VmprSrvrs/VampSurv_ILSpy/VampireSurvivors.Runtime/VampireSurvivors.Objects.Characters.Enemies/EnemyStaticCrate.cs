using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyStaticCrate : EnemyStatic
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action<Pickup> _003C_003E9__3_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CDie_003Eb__3_0(Pickup c)
		{
			if ((object)c != null && ((UnityEngine.Object)c).m_CachedPtr != (IntPtr)0)
			{
				c.Time = 1f;
				c.GoToPlayer = true;
			}
		}
	}

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		base.InitEnemy(enemyType, asRemote);
		base.SetFlipX(flip: false);
		((EnemyController)this)._003CIsCullable_003Ek__BackingField = true;
	}

	protected override void OnUpdate()
	{
		if (!((EnemyController)this)._003CIsDead_003Ek__BackingField)
		{
			UpdateDepth();
			if (!((EnemyController)this)._003CIsTimeStopped_003Ek__BackingField)
			{
				ProcessWiggle();
			}
		}
		object cachedTransform = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rbx_v2 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rbx_v2 (System.Object)+10]");
		Quaternion value = default(Quaternion);
		Transform.set_localRotation_Injected((IntPtr)0, ref value);
	}

	protected override void ProcessWiggle()
	{
	}

	protected override void Die()
	{
		//IL_007a->IL0098: Incompatible stack heights: 1 vs 0
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
			Action<Pickup> callback = _003C_003Ec._003C_003E9__3_0;
			if (_003C_003Ec._003C_003E9__3_0 == null)
			{
				callback = (_003C_003Ec._003C_003E9__3_0 = delegate(Pickup c)
				{
					if ((object)c != null && ((UnityEngine.Object)c).m_CachedPtr != (IntPtr)0)
					{
						c.Time = 1f;
						c.GoToPlayer = true;
					}
				});
			}
			if ((object)_gameManager != null)
			{
				Vector2 pos = default(Vector2);
				_gameManager.MakeCoin(pos, 0f, callback);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public EnemyStaticCrate()
	{
		//IL_001b: Expected I4, but got I8
		base._prevDepth = -1;
		((EnemyController)this)._002Ector();
	}
}
