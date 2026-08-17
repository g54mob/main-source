using System;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerGenevieve : CharacterController
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__4_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CLevelUp_003Eb__4_0()
		{
			//IL_004d: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Vacuum, soundConfig, 1000f, 1, time);
			GM.Core.TurnOnVacuum();
		}
	}

	public WorldEaterVFX _wolrdEater;

	public override bool NeedsCart => false;

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		WorldEaterVFX wolrdEater = new WorldEaterVFX(this);
		_wolrdEater = wolrdEater;
		base._isLastBreathEnabled = true;
		Action onLastBreath = LastBreath;
		base._onLastBreath = onLastBreath;
	}

	public override void LevelUp()
	{
		//IL_0153: Expected O, but got I4
		//IL_016d: Expected O, but got I4
		base.LevelUp();
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		CharacterController activeCharacter = gameSessionData._activeCharacter;
		bool flag = (object)gameSessionData._activeCharacter == null;
		bool flag2 = (object)this == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)this != null)
			{
				if ((object)gameSessionData._activeCharacter != null)
				{
					object obj3 = (object)gameSessionData._activeCharacter - (object)this;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)activeCharacter).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				return;
			}
		}
		Action onComplete = _003C_003Ec._003C_003E9__4_0;
		if (_003C_003Ec._003C_003E9__4_0 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__4_0 = delegate
			{
				//IL_004d: Expected O, but got I4
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Rate = 1f;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Vacuum, soundConfig, 1000f, 1, time);
				GM.Core.TurnOnVacuum();
			});
		}
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	protected override void OnStop()
	{
		if (_wiggleTween != null)
		{
			_wiggleTween.Pause();
		}
		base.angle = 0f;
	}

	public void LastBreath()
	{
		base.IsInvul = true;
		if (3.0000002f > base._invincibilityTimer)
		{
			base._invincibilityTimer = 3.0000002f;
		}
		_wolrdEater.CastSoulSteal();
	}

	public override bool DoesWantPickup(Pickup pickup)
	{
		//IL_0066: Expected I4, but got O
		if ((object)pickup != null)
		{
			if (pickup._003CPickupType_003Ek__BackingField != ItemType.LITTLEHEART)
			{
				return base.DoesWantPickup(pickup);
			}
			return true;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
