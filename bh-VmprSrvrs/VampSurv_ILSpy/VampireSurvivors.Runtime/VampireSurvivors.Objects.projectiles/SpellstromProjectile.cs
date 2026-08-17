using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class SpellstromProjectile : Projectile
{
	private Timer _hitBoxTimer;

	private Timer _expireTimer;

	public Transform _toFollow;

	private bool _alreadyRecycled;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("blur128", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		ArcadeSprite arcadeSprite2 = setTint(0u);
		ArcadeSprite arcadeSprite3 = setAlpha(0.65f);
		_isCullable = false;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_002f: Expected O, but got I4
		//IL_0053: Expected O, but got I4
		//IL_0053: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		if (!_alreadyRecycled)
		{
			ArcadeSprite arcadeSprite = setVisible(visible: true);
			_alreadyRecycled = true;
			ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
			BaseBody baseBody = body.setCircle(64f, (float?)(object)1, (float?)(object)1);
			_targetTransform = null;
			if (_hitBoxTimer != null)
			{
				_hitBoxTimer.Cancel();
			}
			float hitBoxDelay = weapon.HitBoxDelay;
			Action onComplete = delegate
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			};
			float duration = hitBoxDelay * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer hitBoxTimer = Timers.Register(duration, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_hitBoxTimer = hitBoxTimer;
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			int num = ~renderer.pixelHeight;
			ArcadeSprite arcadeSprite3 = setDepth(num);
		}
	}

	public void SetObjectToFollow(Transform toFollow)
	{
		_toFollow = toFollow;
	}

	public override void InternalUpdate()
	{
		//IL_00c8->IL0082: Incompatible stack heights: 1 vs 0
		Transform toFollow = _toFollow;
		if ((object)_toFollow != null && ((UnityEngine.Object)toFollow).m_CachedPtr != (IntPtr)0)
		{
			object toFollow2 = _toFollow;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rbx_v4 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rbx_v4 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out Vector3 _);
			float2 float5 = default(float2);
			base.position = float5;
		}
	}

	public override void Despawn()
	{
		base.Despawn();
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if (_hitBoxTimer != null)
		{
			_hitBoxTimer.Cancel();
		}
	}

	private void _003CInitProjectile_003Eb__5_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
