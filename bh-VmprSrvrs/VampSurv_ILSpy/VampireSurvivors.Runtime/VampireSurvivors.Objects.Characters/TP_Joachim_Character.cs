using System;
using Coherence;
using Coherence.Toolkit;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters;

public class TP_Joachim_Character : TP_Character
{
	public override bool DrainWeaponsImmunity => true;

	protected override void OnStop()
	{
		if (_wiggleTween != null)
		{
			_wiggleTween.Pause();
		}
		base.angle = 0f;
	}

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		Action onComplete = delegate
		{
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				GM.Core.QueueEnterSkillSelection(this);
			}
			else if (GM.Core.IsStageHost)
			{
				CoherenceSync coherenceSync = _coherenceSync;
				Action method = EnterSkillSelection;
				bool flag = coherenceSync.commandsHandler.SendCommand(method, MessageTarget.All, ChannelID.Ordered);
			}
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public void EnterSkillSelection()
	{
		GM.Core.QueueEnterSkillSelection(this);
	}

	private void _003CAfterFullInitialization_003Eb__3_0()
	{
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			GM.Core.QueueEnterSkillSelection(this);
		}
		else if (GM.Core.IsStageHost)
		{
			CoherenceSync coherenceSync = _coherenceSync;
			Action method = EnterSkillSelection;
			bool flag = coherenceSync.commandsHandler.SendCommand(method, MessageTarget.All, ChannelID.Ordered);
		}
	}
}
