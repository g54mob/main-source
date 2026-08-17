using System;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyShard : EnemyController
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__3_3;

		public static Action _003C_003E9__3_2;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CDie_003Eb__3_3()
		{
			GameManager core = GM.Core;
			GameSessionData gameSessionData = core._gameSessionData;
			core.AddCharacterTypeToQueue(CharacterType.AVATAR, gameSessionData._activeCharacter);
		}

		internal void _003CDie_003Eb__3_2()
		{
			GameManager core = GM.Core;
			core._WhiteHandManager.SummonWhiteHand();
		}
	}

	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public bool playCoffinAnim;

		public EnemyShard _003C_003E4__this;

		internal void _003CDie_003Eb__0()
		{
			ProCamera2DShake instance = ProCamera2DShake.Instance;
			Action b = delegate
			{
				// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
				ProCamera2DShake instance3 = ProCamera2DShake.Instance;
				Action value = _003CDie_003Eg__OnShakeCompleted_007C1;
				Delegate obj4 = Delegate.Remove(instance3.OnShakeCompleted, value);
				if ((object)obj4 == null)
				{
					instance3.OnShakeCompleted = (Action)obj4;
				}
				else
				{
					bool flag3 = (object)obj4.GetType() != typeof(Action);
					Delegate obj5 = null;
					if (!flag3)
					{
						obj5 = obj4;
					}
					if ((object)obj5 == null)
					{
						throw new InvalidCastException();
					}
					instance3.OnShakeCompleted = (Action)obj5;
					bool flag4 = (object)obj4.GetType() != typeof(Action);
					Delegate obj6 = null;
					if (!flag4)
					{
						obj6 = obj4;
					}
					if ((object)obj6 == null)
					{
						throw new InvalidCastException();
					}
				}
				if (playCoffinAnim)
				{
					Action onComplete2 = _003C_003Ec._003C_003E9__3_3;
					if (_003C_003Ec._003C_003E9__3_3 == null)
					{
						onComplete2 = (_003C_003Ec._003C_003E9__3_3 = delegate
						{
							GameManager core2 = GM.Core;
							GameSessionData gameSessionData = core2._gameSessionData;
							core2.AddCharacterTypeToQueue(CharacterType.AVATAR, gameSessionData._activeCharacter);
						});
					}
					CharacterLoader.LoadCharacterAsync(CharacterType.AVATAR, onComplete2);
				}
			};
			Delegate obj = Delegate.Combine(instance.OnShakeCompleted, b);
			if ((object)obj == null)
			{
				instance.OnShakeCompleted = null;
			}
			else
			{
				bool flag = (object)obj.GetType() != typeof(Action);
				Delegate obj2 = null;
				if (!flag)
				{
					obj2 = obj;
				}
				if ((object)obj2 == null)
				{
					throw new InvalidCastException();
				}
				instance.OnShakeCompleted = (Action)obj2;
				bool flag2 = (object)obj.GetType() != typeof(Action);
				Delegate obj3 = null;
				if (!flag2)
				{
					obj3 = obj;
				}
				if ((object)obj3 == null)
				{
					throw new InvalidCastException();
				}
			}
			ProCamera2DShake instance2 = ProCamera2DShake.Instance;
			instance2.Shake("MaskBreakingShake");
			Action onComplete = _003C_003Ec._003C_003E9__3_2;
			if (_003C_003Ec._003C_003E9__3_2 == null)
			{
				onComplete = (_003C_003Ec._003C_003E9__3_2 = delegate
				{
					GameManager core2 = GM.Core;
					core2._WhiteHandManager.SummonWhiteHand();
				});
			}
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			GameManager core = GM.Core;
			core._003CCanPause_003Ek__BackingField = false;
			GM.Core.SetPlayersInvulForMillisecondsAndRestoreTints(30000f);
			List<EquipmentInfo> list = GM.Core.RemoveAllEquipmentFromPlayers(addToRemovedList: true);
			((EnemyController)_003C_003E4__this).Die();
		}

		internal void _003CDie_003Eg__OnShakeCompleted_007C1()
		{
			// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
			ProCamera2DShake instance = ProCamera2DShake.Instance;
			Action value = _003CDie_003Eg__OnShakeCompleted_007C1;
			Delegate obj = Delegate.Remove(instance.OnShakeCompleted, value);
			if ((object)obj == null)
			{
				instance.OnShakeCompleted = (Action)obj;
			}
			else
			{
				bool flag = (object)obj.GetType() != typeof(Action);
				Delegate obj2 = null;
				if (!flag)
				{
					obj2 = obj;
				}
				if ((object)obj2 == null)
				{
					throw new InvalidCastException();
				}
				instance.OnShakeCompleted = (Action)obj2;
				bool flag2 = (object)obj.GetType() != typeof(Action);
				Delegate obj3 = null;
				if (!flag2)
				{
					obj3 = obj;
				}
				if ((object)obj3 == null)
				{
					throw new InvalidCastException();
				}
			}
			if (!playCoffinAnim)
			{
				return;
			}
			Action onComplete = _003C_003Ec._003C_003E9__3_3;
			if (_003C_003Ec._003C_003E9__3_3 == null)
			{
				onComplete = (_003C_003Ec._003C_003E9__3_3 = delegate
				{
					GameManager core = GM.Core;
					GameSessionData gameSessionData = core._gameSessionData;
					core.AddCharacterTypeToQueue(CharacterType.AVATAR, gameSessionData._activeCharacter);
				});
			}
			CharacterLoader.LoadCharacterAsync(CharacterType.AVATAR, onComplete);
		}
	}

	private MultiTargetTween _onEnterTween;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_010d: Expected O, but got I4
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		base.InitEnemy(enemyType, asRemote);
		base._003CIsCullable_003Ek__BackingField = false;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		if (_onEnterTween != null)
		{
			_onEnterTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 500f;
		tweenConfig.scale = (float?)(object)1;
		MultiTargetTween onEnterTween = Tweens.Add(tweenConfig);
		_onEnterTween = onEnterTween;
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		base.GetDamaged(value, showHitVfx, damageKb, damageType, hasKb);
	}

	protected override void Die()
	{
		//IL_0167: Expected O, but got I4
		//IL_0183: Expected O, but got F4
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals6._003C_003E4__this = this;
		if (base._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		CS_0024_003C_003E8__locals6.playCoffinAnim = false;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
		object obj = default(object);
		if (obj == null)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config2 = core2._playerOptions.Config;
			bool flag = core2._playerOptions.UnlockSecret(SecretType.MaFaiPianooo, config2);
			CS_0024_003C_003E8__locals6.playCoffinAnim = true;
		}
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
			Action b = delegate
			{
				// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
				ProCamera2DShake instance3 = ProCamera2DShake.Instance;
				Action value = CS_0024_003C_003E8__locals6._003CDie_003Eg__OnShakeCompleted_007C1;
				Delegate obj7 = Delegate.Remove(instance3.OnShakeCompleted, value);
				if ((object)obj7 == null)
				{
					instance3.OnShakeCompleted = (Action)obj7;
				}
				else
				{
					bool flag4 = (object)obj7.GetType() != typeof(Action);
					Delegate obj8 = null;
					if (!flag4)
					{
						obj8 = obj7;
					}
					if ((object)obj8 == null)
					{
						throw new InvalidCastException();
					}
					instance3.OnShakeCompleted = (Action)obj8;
					bool flag5 = (object)obj7.GetType() != typeof(Action);
					Delegate obj9 = null;
					if (!flag5)
					{
						obj9 = obj7;
					}
					if ((object)obj9 == null)
					{
						throw new InvalidCastException();
					}
				}
				if (CS_0024_003C_003E8__locals6.playCoffinAnim)
				{
					Action onComplete3 = _003C_003Ec._003C_003E9__3_3;
					if (_003C_003Ec._003C_003E9__3_3 == null)
					{
						onComplete3 = (_003C_003Ec._003C_003E9__3_3 = delegate
						{
							GameManager core4 = GM.Core;
							GameSessionData gameSessionData = core4._gameSessionData;
							core4.AddCharacterTypeToQueue(CharacterType.AVATAR, gameSessionData._activeCharacter);
						});
					}
					CharacterLoader.LoadCharacterAsync(CharacterType.AVATAR, onComplete3);
				}
			};
			Delegate obj4 = Delegate.Combine(instance.OnShakeCompleted, b);
			if ((object)obj4 == null)
			{
				instance.OnShakeCompleted = null;
			}
			else
			{
				bool flag2 = (object)obj4.GetType() != typeof(Action);
				Delegate obj5 = null;
				if (!flag2)
				{
					obj5 = obj4;
				}
				if ((object)obj5 == null)
				{
					throw new InvalidCastException();
				}
				instance.OnShakeCompleted = (Action)obj5;
				bool flag3 = (object)obj4.GetType() != typeof(Action);
				Delegate obj6 = null;
				if (!flag3)
				{
					obj6 = obj4;
				}
				if ((object)obj6 == null)
				{
					throw new InvalidCastException();
				}
			}
			ProCamera2DShake instance2 = ProCamera2DShake.Instance;
			instance2.Shake("MaskBreakingShake");
			Action onComplete2 = _003C_003Ec._003C_003E9__3_2;
			if (_003C_003Ec._003C_003E9__3_2 == null)
			{
				onComplete2 = (_003C_003Ec._003C_003E9__3_2 = delegate
				{
					GameManager core4 = GM.Core;
					core4._WhiteHandManager.SummonWhiteHand();
				});
			}
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.5f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			GameManager core3 = GM.Core;
			core3._003CCanPause_003Ek__BackingField = false;
			GM.Core.SetPlayersInvulForMillisecondsAndRestoreTints(30000f);
			List<EquipmentInfo> list = GM.Core.RemoveAllEquipmentFromPlayers(addToRemovedList: true);
			((EnemyController)CS_0024_003C_003E8__locals6._003C_003E4__this).Die();
		};
		GM.Core.FrameFreeze(onComplete);
	}

	private void BlockInput()
	{
		GameManager core = GM.Core;
		core._003CCanPause_003Ek__BackingField = false;
		GM.Core.SetPlayersInvulForMillisecondsAndRestoreTints(30000f);
		List<EquipmentInfo> list = GM.Core.RemoveAllEquipmentFromPlayers(addToRemovedList: true);
	}

	private void _003C_003En__0()
	{
		base.Die();
	}
}
