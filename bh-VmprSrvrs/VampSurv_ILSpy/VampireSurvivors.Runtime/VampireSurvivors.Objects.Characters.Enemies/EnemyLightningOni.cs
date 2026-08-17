using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyLightningOni : EnemyController
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__8_2;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CPerformDeath_003Eb__8_2()
		{
			GameManager core = GM.Core;
			GameSessionData gameSessionData = core._gameSessionData;
			core.AddCharacterTypeToQueue(CharacterType.SCOREJ, gameSessionData._activeCharacter);
		}
	}

	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public bool PlayCoffinAnimation;

		public Action _003C_003E9__1;

		internal void _003CPerformDeath_003Eb__0()
		{
			ProCamera2DShake instance = ProCamera2DShake.Instance;
			instance.Shake("LightningOniShake");
			Action onComplete = _003C_003E9__1;
			if (_003C_003E9__1 == null)
			{
				onComplete = (_003C_003E9__1 = delegate
				{
					if (PlayCoffinAnimation)
					{
						Action onComplete2 = _003C_003Ec._003C_003E9__8_2;
						if (_003C_003Ec._003C_003E9__8_2 == null)
						{
							onComplete2 = (_003C_003Ec._003C_003E9__8_2 = delegate
							{
								GameManager core = GM.Core;
								GameSessionData gameSessionData = core._gameSessionData;
								core.AddCharacterTypeToQueue(CharacterType.SCOREJ, gameSessionData._activeCharacter);
							});
						}
						CharacterLoader.LoadCharacterAsync(CharacterType.SCOREJ, onComplete2);
					}
				});
			}
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.096f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}

		internal void _003CPerformDeath_003Eb__1()
		{
			if (!PlayCoffinAnimation)
			{
				return;
			}
			Action onComplete = _003C_003Ec._003C_003E9__8_2;
			if (_003C_003Ec._003C_003E9__8_2 == null)
			{
				onComplete = (_003C_003Ec._003C_003E9__8_2 = delegate
				{
					GameManager core = GM.Core;
					GameSessionData gameSessionData = core._gameSessionData;
					core.AddCharacterTypeToQueue(CharacterType.SCOREJ, gameSessionData._activeCharacter);
				});
			}
			CharacterLoader.LoadCharacterAsync(CharacterType.SCOREJ, onComplete);
		}
	}

	private int _activated;

	private bool _performingDeath;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		base.InitEnemy(enemyType, asRemote);
		EnemyData currentEnemyData = _currentEnemyData;
		_defaultSpeed = currentEnemyData._003Cspeed_003Ek__BackingField;
		base._003CIsCullable_003Ek__BackingField = false;
		base._003CIsTeleportOnCull_003Ek__BackingField = false;
		_activated = 0;
	}

	public override void Disappear()
	{
		base._003CIsCullable_003Ek__BackingField = true;
		base._003CIsTeleportOnCull_003Ek__BackingField = false;
	}

	protected override void OnUpdate()
	{
		//IL_002a: Invalid comparison between O and F4
		float num = (float)_activated * _defaultSpeed;
		base._003CSpeed_003Ek__BackingField = num;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref renderer.screenCenter) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)389.12f))
		{
			_activated = 1;
		}
		base.OnUpdate();
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		if (_activated > 0)
		{
			base.GetDamaged(value, showHitVfx, damageKb, damageType, hasKb);
		}
	}

	public void OnlineDie(long startingSimFrame)
	{
		Action onSyncedTimer = PerformDeath;
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	protected override void Die()
	{
		//IL_0080: Expected I8, but got O
		//IL_008f: Expected I8, but got O
		if (!_performingDeath)
		{
			_performingDeath = false;
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				PerformDeath();
			}
			else if (_coherenceSync.HasStateAuthority)
			{
				Action<long> action = null;
				((EnemyLightningOni)(object)action).OnlineDie((long)this);
				((EnemyLightningOni)(object)action).OnlineDie((long)this);
				OnlineStageManager onlineStageManager = default(OnlineStageManager);
				long startingOnlineClientFrame = onlineStageManager.GetStartingOnlineClientFrame();
				bool flag = _coherenceSync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
			}
		}
	}

	private void PerformDeath()
	{
		//IL_016e: Expected O, but got I4
		//IL_018a: Expected O, but got F4
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass8_0();
		base.Die();
		CS_0024_003C_003E8__locals6.PlayCoffinAnimation = false;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<CharacterType> list = config._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rcx_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				goto IL_0157;
			}
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		bool flag = core2._playerOptions.UnlockSecret(SecretType.HearTheThunder, config2);
		CS_0024_003C_003E8__locals6.PlayCoffinAnimation = true;
		goto IL_0157;
		IL_0157:
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		object obj2 = UnityEngine.Random.value;
		object obj3 = default(object);
		float detune = (float)obj3 * -600f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Crystal12, soundConfig, 0f, 10, time);
		Action onComplete = delegate
		{
			ProCamera2DShake instance = ProCamera2DShake.Instance;
			instance.Shake("LightningOniShake");
			Action onComplete2 = CS_0024_003C_003E8__locals6._003C_003E9__1;
			if (CS_0024_003C_003E8__locals6._003C_003E9__1 == null)
			{
				onComplete2 = (CS_0024_003C_003E8__locals6._003C_003E9__1 = delegate
				{
					if (CS_0024_003C_003E8__locals6.PlayCoffinAnimation)
					{
						Action onComplete3 = _003C_003Ec._003C_003E9__8_2;
						if (_003C_003Ec._003C_003E9__8_2 == null)
						{
							onComplete3 = (_003C_003Ec._003C_003E9__8_2 = delegate
							{
								GameManager core3 = GM.Core;
								GameSessionData gameSessionData = core3._gameSessionData;
								core3.AddCharacterTypeToQueue(CharacterType.SCOREJ, gameSessionData._activeCharacter);
							});
						}
						CharacterLoader.LoadCharacterAsync(CharacterType.SCOREJ, onComplete3);
					}
				});
			}
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.096f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		};
		GM.Core.FrameFreeze(onComplete);
	}
}
