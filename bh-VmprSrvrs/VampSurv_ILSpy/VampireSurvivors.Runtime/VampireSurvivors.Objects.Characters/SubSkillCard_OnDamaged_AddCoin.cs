using System;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_OnDamaged_AddCoin(ArcanaType type) : CharacterSkillCard_Base(type)
{
	private bool _canRetaliate = true;

	private float retaliationDelay = 50f;

	public override void OnOwnerGetDamaged(float damageAmount)
	{
		if (_canRetaliate)
		{
			float2 position = LinkedCharacter.position;
			Vector2 pos = default(Vector2);
			GM.Core.MakeCoin(pos);
			_canRetaliate = false;
			Action onComplete = delegate
			{
				_canRetaliate = true;
			};
			float duration = retaliationDelay * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}

	private void _003COnOwnerGetDamaged_003Eb__3_0()
	{
		_canRetaliate = true;
	}
}
