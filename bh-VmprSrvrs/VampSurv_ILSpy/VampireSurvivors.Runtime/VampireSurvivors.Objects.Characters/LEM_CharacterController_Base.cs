using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters;

public class LEM_CharacterController_Base : CharacterController
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__2_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CAfterFullInitialization_003Eb__2_0()
		{
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			config._003CForcedSurvarots_003Ek__BackingField = true;
		}
	}

	public virtual bool StartWithSurvarotDraft => true;

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		if (!StartWithSurvarotDraft)
		{
			return;
		}
		Action onComplete = _003C_003Ec._003C_003E9__2_0;
		if (_003C_003Ec._003C_003E9__2_0 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__2_0 = delegate
			{
				GameManager core = GM.Core;
				PlayerOptionsData config = core._playerOptions.Config;
				config._003CForcedSurvarots_003Ek__BackingField = true;
			});
		}
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public void GiveSurvarocchi()
	{
		//IL_0093: Expected O, but got I4
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			GM.Core.QueueOpenSurvarots(4, this);
			return;
		}
		List<CharacterController> playerCharacters = OnlineStageManager._instance.GetPlayerCharacters();
		int num = Array.IndexOf((object[])playerCharacters._items, (object)this, 0, playerCharacters._size);
		Action onComplete = delegate
		{
			GM.Core.QueueOpenSurvarots(4, this);
		};
		object obj = num * 100;
		float duration = (float)obj * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void _003CGiveSurvarocchi_003Eb__3_0()
	{
		GM.Core.QueueOpenSurvarots(4, this);
	}
}
