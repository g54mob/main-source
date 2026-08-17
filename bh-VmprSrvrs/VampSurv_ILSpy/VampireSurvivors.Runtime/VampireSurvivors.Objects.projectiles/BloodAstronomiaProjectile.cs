using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class BloodAstronomiaProjectile : Projectile
{
	private Timer _expireTimer;

	private EggFloat _radius;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected O, but got Unknown
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Expected O, but got Unknown
		//IL_026c: Expected O, but got I4
		//IL_026c: Expected O, but got I4
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Expected O, but got Unknown
		base.InitProjectile(pool, weapon, index);
		MatchMagnetPosition();
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		MagnetZone magnet = characterController._magnet;
		_radius = magnet.Radius;
		EggFloat radius = _radius;
		float num = radius._eggVal + radius._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186FF0A9Eh\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				goto IL_0341;
			}
		}
		num = 3.4028235E+38f;
		goto IL_0341;
		IL_0341:
		EggFloat radius2 = _radius;
		float num2 = radius2._eggVal + radius2._val;
		object obj3 = num2 & -2147483649L;
		if ((nint)obj3 != 2139095040)
		{
			object obj4 = num2 & -2147483649L;
			if ((nint)obj4 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186FF0AE5h\"");
				if (num2 != -1f / 0f)
				{
				}
			}
		}
		EggFloat radius3 = _radius;
		float num3 = radius3._eggVal + radius3._val;
		object obj5 = num3 & -2147483649L;
		if ((nint)obj5 != 2139095040)
		{
			object obj6 = num3 & -2147483649L;
			if ((nint)obj6 <= 2139095040)
			{
				bool flag = num3 == -1f / 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186FF0B48h\"");
				if (flag)
				{
				}
			}
		}
		BaseBody baseBody = body.setCircle(num, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float num4 = _weapon.PInterval();
		Action onComplete = delegate
		{
			if (_expireTimer != null)
			{
				_expireTimer.Cancel();
			}
			base.Despawn();
		};
		float duration = num3 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	public override void InternalUpdate()
	{
		MatchMagnetPosition();
	}

	private void MatchMagnetPosition()
	{
		Weapon weapon = _weapon;
		Transform cachedTransform = _cachedTransform;
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
					bool flag2 = (object)_cachedTransform == null;
					bool flag3 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public BloodAstronomiaProjectile()
	{
		EggFloat radius = new EggFloat(1f);
		_radius = radius;
		base._002Ector();
	}

	private void _003CInitProjectile_003Eb__2_0()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		base.Despawn();
	}
}
