using System;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class InsatiableProjectile : Projectile
{
	private Timer _expireTimer;

	private float _radius;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0055: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_02f2->IL0268: Incompatible stack heights: 1 vs 0
		//IL_0208->IL0268: Incompatible stack heights: 1 vs 0
		//IL_022a->IL0268: Incompatible stack heights: 1 vs 0
		//IL_0259->IL0268: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		if ((object)weapon != null)
		{
			float num = weapon.PArea();
			float num2 = default(float);
			_radius = num2;
			if (body != null)
			{
				BaseBody baseBody = body.setCircle(num2, (float?)(object)1, (float?)(object)1);
				ArcadeSprite arcadeSprite = setVisible(visible: false);
				if (_expireTimer != null)
				{
					_expireTimer.Cancel();
				}
				if ((object)_weapon != null)
				{
					float num3 = _weapon.PInterval();
					Action onComplete = delegate
					{
						if (_expireTimer != null)
						{
							_expireTimer.Cancel();
						}
						base.Despawn();
					};
					float duration = num2 * 0.001f;
					bool useRealTime = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_expireTimer = expireTimer;
					Weapon weapon2 = _weapon;
					if ((object)_weapon != null)
					{
						VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null && (object)characterController._magnet != null)
						{
							Transform transform = characterController._magnet.transform;
							if ((object)transform != null)
							{
								bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
								Weapon weapon3 = _weapon;
								if ((object)_weapon != null)
								{
									VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
									if ((object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null && (object)characterController2._magnet != null)
									{
										Transform transform2 = characterController2._magnet.transform;
										if ((object)transform2 != null)
										{
											bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
											Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
											float2 float5 = default(float2);
											base.position = float5;
											return;
										}
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

	protected override void OnUpdate()
	{
		//IL_0198->IL013d: Incompatible stack heights: 1 vs 0
		//IL_00dd->IL013d: Incompatible stack heights: 1 vs 0
		//IL_00ff->IL013d: Incompatible stack heights: 1 vs 0
		//IL_012e->IL013d: Incompatible stack heights: 1 vs 0
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null && (object)characterController._magnet != null)
			{
				Transform transform = characterController._magnet.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					Weapon weapon2 = _weapon;
					if ((object)_weapon != null)
					{
						VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null && (object)characterController2._magnet != null)
						{
							Transform transform2 = characterController2._magnet.transform;
							if ((object)transform2 != null)
							{
								bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
								float2 float5 = default(float2);
								base.position = float5;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void _003CInitProjectile_003Eb__3_0()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		base.Despawn();
	}
}
