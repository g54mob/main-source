using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyAGaea : EnemyController
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__14_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003COnDefeat_003Eb__14_0()
		{
			GM.Core.SetupMusicBanger();
		}
	}

	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public EnemyAGaea _003C_003E4__this;

		public float shieldDelay;

		public Action _003C_003E9__3;

		public Action _003C_003E9__2;

		internal void _003CStartInvulTimer_003Eb__0()
		{
			EnemyAGaea enemyAGaea = _003C_003E4__this;
			enemyAGaea._savedBGM = SoundManager._003CCurrentBgm_003Ek__BackingField;
			EnemyAGaea enemyAGaea2 = _003C_003E4__this;
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			enemyAGaea2._savedBGMmod = config._003CSelectedBGMMod_003Ek__BackingField;
		}

		internal unsafe void _003CStartInvulTimer_003Eb__1()
		{
			//IL_0018: Expected O, but got I4
			//IL_023a: Invalid comparison between F4 and I4
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Expected O, but got Unknown
			//IL_025e: Expected I, but got O
			//IL_0274: Expected O, but got I
			//IL_027d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0282: Expected O, but got Unknown
			//IL_01c4: Expected I, but got O
			//IL_02a8: Expected O, but got I4
			//IL_02bf: Expected I, but got I8
			//IL_01a0: Expected I, but got I8
			EnemyAGaea enemyAGaea = _003C_003E4__this;
			object obj = 200;
			bool flag = false;
			bool flag2 = false;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			while (true)
			{
				float num = enemyAGaea._bonusTimes - 1f;
				if (!(num > (float)(flag2 ? 1 : 0)))
				{
					break;
				}
				Action onComplete = _003C_003E9__3;
				if (_003C_003E9__3 == null)
				{
					onComplete = (_003C_003E9__3 = delegate
					{
						_003C_003E4__this.GetEnemyToken();
					});
				}
				float duration = (float)obj * 0.001f;
				Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				enemyAGaea = _003C_003E4__this;
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
				obj += 200;
				flag2 = flag;
			}
			Action onComplete2 = _003C_003E9__2;
			if (_003C_003E9__2 != null)
			{
				goto IL_01c9;
			}
			Action action = null;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ r10_v2 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass11_0._003CStartInvulTimer_003Eb__2);
			((Delegate)action).m_target = this;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ r10_v2 (Il2CppMethodInfo)+4C]");
			object obj2 = (nint)0 >> 4;
			object obj3 = obj2 & 1;
			nint num3;
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ r10_v2 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num3 = unchecked((nint)6447293664L);
					goto IL_029f;
				}
			}
			num3 = ((Delegate)action).method_ptr;
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			goto IL_029f;
			IL_01c9:
			float num4 = shieldDelay + 2000f;
			float duration2 = num4 * 0.001f;
			Timer timer2 = Timers.Register(duration2, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			return;
			IL_029f:
			object obj4 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			_003C_003E9__2 = action;
			onComplete2 = action;
			goto IL_01c9;
		}

		internal void _003CStartInvulTimer_003Eb__3()
		{
			_003C_003E4__this.GetEnemyToken();
		}

		internal void _003CStartInvulTimer_003Eb__2()
		{
			//IL_0037: Expected O, but got I
			//IL_0091: Expected O, but got I
			//IL_0076: Expected O, but got I4
			//IL_01c5: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_00e0: Expected O, but got I4
			GameManager core = GM.Core;
			List<EnemyType?> list = new List<EnemyType?>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rdx_v4+18]");
			if (num >= 0)
			{
				list.AddWithResize((EnemyType?)(object)1);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
				object obj2 = (nint)0 + (nint)1;
				_ = 1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rdx_v6+18]");
			if (num2 >= 0)
			{
				list.AddWithResize((EnemyType?)(object)1);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
				object obj4 = (nint)0 + (nint)1;
				_ = 1;
			}
			List<EnemyType?> bosses = new List<EnemyType?>();
			core._stage.UpdateEnemyPools(list, bosses);
			GameManager core2 = GM.Core;
			Stage stage = core2._stage;
			StageData stageData = stage._stageData;
			stageData._003Cminimum_003Ek__BackingField = 150;
			_003C_003E4__this.StartSummons();
			EnemyAGaea enemyAGaea = _003C_003E4__this;
			enemyAGaea._isInvul = false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public PhaserSprite img2;

		public PhaserSprite img;

		public EnemyAGaea _003C_003E4__this;

		internal void _003CGetEnemyToken_003Eb__0()
		{
			//IL_00d7->IL0086: Incompatible stack heights: 1 vs 0
			PhaserSprite phaserSprite = img;
			if ((object)img != null)
			{
				PhaserSprite spriteRenderer = (PhaserSprite)(object)phaserSprite._spriteRenderer;
				if ((object)phaserSprite._spriteRenderer != null)
				{
					bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
					SpriteRenderer.get_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, out Color _);
					if ((object)img2 != null)
					{
						object obj = default(object);
						float alpha = 1f - (float)obj;
						PhaserSprite phaserSprite2 = img2.setAlpha(alpha);
						return;
					}
				}
			}
			throw new NullReferenceException();
		}

		internal void _003CGetEnemyToken_003Eb__1()
		{
			_003C_003E4__this.FakeRecover();
			img.destroy();
			img2.destroy();
		}
	}

	private float _bonusTimes;

	private bool _isInvul;

	private float _recoveredTimes;

	private bool _hasBeenDefeated;

	private BgmType _savedBGM;

	private BgmModType _savedBGMmod;

	private PhaserSprite _ringSprite;

	private Timer _summonEvent;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		base.InitEnemy(enemyType, asRemote);
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<AchievementType> list = config._003CAchievements_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
		bool hasBeenDefeated;
		if ((nint)0 == 0)
		{
			hasBeenDefeated = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			object obj = obj2 - -1;
			bool flag = obj == null;
			hasBeenDefeated = !flag;
		}
		_hasBeenDefeated = hasBeenDefeated;
	}

	protected override void OnRecycleEnemy()
	{
		//IL_0093: Expected O, but got I4
		base.OnRecycleEnemy();
		CalculateBonus();
		StartInvulTimer();
		PhaserSprite ringSprite = _ringSprite;
		if ((object)_ringSprite == null || ((UnityEngine.Object)ringSprite).m_CachedPtr == (IntPtr)0)
		{
			PhaserWorld instance = PhaserWorld.Instance;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "vfx", "sPFX_ring_64");
			PhaserSprite phaserSprite2 = phaserSprite.setScale(0f, (float?)(object)0);
			PhaserSprite ringSprite2 = phaserSprite2.setBlendMode(BlendMode.Add);
			_ringSprite = ringSprite2;
		}
	}

	public void CalculateBonus()
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		float num = (float)config._003CRunEnemies_003Ek__BackingField / 1000f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E0DC");
		bool flag = !(1f < num);
		float num2 = 1f;
		if (!flag)
		{
			num2 = num;
		}
		_bonusTimes = num2;
		float num3 = num2 * 1000f;
		float maxHp = num3 + _maxHp;
		_maxHp = maxHp;
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		if (config2._003CSelectedGoldenEggs_003Ek__BackingField)
		{
			GameManager core3 = GM.Core;
			PlayerOptionsData config3 = core3._playerOptions.Config;
			GameManager core4 = GM.Core;
			PlayerOptionsData config4 = core4._playerOptions.Config;
			int num4 = ((Dictionary<System.Int32Enum, object>)(object)config3._003CCharacterEggInfo_003Ek__BackingField).FindEntry((System.Int32Enum)config4._selectedChar);
			if (num4 >= 0)
			{
				GameManager core5 = GM.Core;
				PlayerOptionsData config5 = core5._playerOptions.Config;
				object obj = ((Dictionary<System.Int32Enum, object>)(object)config3._003CCharacterEggInfo_003Ek__BackingField).get_Item((System.Int32Enum)config5._selectedChar);
				int num5 = ((Dictionary<string, float>)obj).FindEntry("power");
				if (num5 >= 0)
				{
					EnemyData currentEnemyData = _currentEnemyData;
					float num6 = ((Dictionary<object, float>)obj).get_Item((object)"power");
					float num7 = num6 + currentEnemyData._003Cpower_003Ek__BackingField;
					currentEnemyData._003Cpower_003Ek__BackingField = num7;
				}
				int num8 = ((Dictionary<string, float>)obj).FindEntry("maxHp");
				if (num8 >= 0)
				{
					float num9 = ((Dictionary<object, float>)obj).get_Item((object)"maxHp");
					float maxHp2 = num9 + _maxHp;
					_maxHp = maxHp2;
				}
			}
		}
		_hp = _maxHp;
	}

	public unsafe void StartInvulTimer()
	{
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals15 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals15._003C_003E4__this = this;
		if (_isInvul)
		{
			return;
		}
		float num = _bonusTimes * 200f;
		bool flag = num > 10000f;
		float shieldDelay = 10000f;
		if (!flag)
		{
			shieldDelay = num;
		}
		CS_0024_003C_003E8__locals15.shieldDelay = shieldDelay;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (!_hasBeenDefeated)
		{
			Action onComplete = delegate
			{
				EnemyAGaea enemyAGaea = CS_0024_003C_003E8__locals15._003C_003E4__this;
				enemyAGaea._savedBGM = SoundManager._003CCurrentBgm_003Ek__BackingField;
				EnemyAGaea enemyAGaea2 = CS_0024_003C_003E8__locals15._003C_003E4__this;
				GameManager core = GM.Core;
				PlayerOptionsData config = core._playerOptions.Config;
				enemyAGaea2._savedBGMmod = config._003CSelectedBGMMod_003Ek__BackingField;
			};
			Timer timer = Timers.Register(2.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
		Action onComplete2 = delegate
		{
			//IL_0018: Expected O, but got I4
			//IL_023a: Invalid comparison between F4 and I4
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Expected O, but got Unknown
			//IL_025e: Expected I, but got O
			//IL_0274: Expected O, but got I
			//IL_027d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0282: Expected O, but got Unknown
			//IL_01c4: Expected I, but got O
			//IL_02a8: Expected O, but got I4
			//IL_02bf: Expected I, but got I8
			//IL_01a0: Expected I, but got I8
			EnemyAGaea enemyAGaea = CS_0024_003C_003E8__locals15._003C_003E4__this;
			object obj = 200;
			bool flag2 = false;
			bool flag3 = false;
			bool useRealTime2 = default(bool);
			MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
			int repeat2 = default(int);
			TimerType type2 = default(TimerType);
			while (true)
			{
				float num2 = enemyAGaea._bonusTimes - 1f;
				if (!(num2 > (float)(flag3 ? 1 : 0)))
				{
					break;
				}
				Action onComplete3 = CS_0024_003C_003E8__locals15._003C_003E9__3;
				if (CS_0024_003C_003E8__locals15._003C_003E9__3 == null)
				{
					onComplete3 = (CS_0024_003C_003E8__locals15._003C_003E9__3 = delegate
					{
						CS_0024_003C_003E8__locals15._003C_003E4__this.GetEnemyToken();
					});
				}
				float duration = (float)obj * 0.001f;
				Timer timer3 = Timers.Register(duration, onComplete3, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
				enemyAGaea = CS_0024_003C_003E8__locals15._003C_003E4__this;
				flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
				obj += 200;
				flag3 = flag2;
			}
			Action onComplete4 = CS_0024_003C_003E8__locals15._003C_003E9__2;
			if (CS_0024_003C_003E8__locals15._003C_003E9__2 != null)
			{
				goto IL_01c9;
			}
			Action action = null;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ r10_v2 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass11_0._003CStartInvulTimer_003Eb__2);
			((Delegate)action).m_target = CS_0024_003C_003E8__locals15;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ r10_v2 (Il2CppMethodInfo)+4C]");
			object obj2 = (nint)0 >> 4;
			object obj3 = obj2 & 1;
			nint num4;
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ r10_v2 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num4 = unchecked((nint)6447293664L);
					goto IL_029f;
				}
			}
			num4 = ((Delegate)action).method_ptr;
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			goto IL_029f;
			IL_01c9:
			float num5 = CS_0024_003C_003E8__locals15.shieldDelay + 2000f;
			float duration2 = num5 * 0.001f;
			Timer timer4 = Timers.Register(duration2, onComplete4, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
			return;
			IL_029f:
			object obj4 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			CS_0024_003C_003E8__locals15._003C_003E9__2 = action;
			onComplete4 = action;
			goto IL_01c9;
		};
		Timer timer2 = Timers.Register(8f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_isInvul = true;
	}

	public void RemoveInvul()
	{
		_isInvul = false;
	}

	public unsafe void StartSummons()
	{
		//IL_0030: Expected I, but got O
		//IL_0046: Expected O, but got I
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_00bd: Expected I, but got O
		//IL_0123: Expected O, but got I4
		//IL_013a: Expected I, but got I8
		//IL_00a6: Expected I, but got I8
		if (_summonEvent != null)
		{
			_summonEvent.Cancel();
		}
		bool flag = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			Action action = null;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r10_v2 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(EnemyAGaea._003CStartSummons_003Eb__13_0);
			((Delegate)action).m_target = this;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r10_v2 (Il2CppMethodInfo)+4C]");
			object obj = (nint)0 >> 4;
			object obj2 = obj & 1;
			nint num2;
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r10_v2 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num2 = unchecked((nint)6447293664L);
					goto IL_011a;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num2 = ((Delegate)action).method_ptr;
			goto IL_011a;
			IL_011a:
			object obj3 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float duration = (float)(flag ? 1 : 0) * 0.001f;
			Timer summonEvent = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_summonEvent = summonEvent;
			flag = (byte)((flag ? 1u : 0u) + 5000u) != 0;
		}
		while ((flag ? 1 : 0) < 500000);
	}

	public void OnDefeat()
	{
		Action onComplete = _003C_003Ec._003C_003E9__14_0;
		if (_003C_003Ec._003C_003E9__14_0 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__14_0 = delegate
			{
				GM.Core.SetupMusicBanger();
			});
		}
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public unsafe void GetEnemyToken()
	{
		//IL_04e6: Expected O, but got Ref
		//IL_0149: Expected O, but got I4
		//IL_0229: Expected I, but got O
		//IL_0293: Expected O, but got I4
		//IL_02a1: Expected O, but got I4
		//IL_02c7: Expected O, but got I4
		//IL_02f4: Expected O, but got I4
		//IL_039a: Expected I, but got O
		//IL_0404: Expected O, but got I4
		//IL_042a: Expected O, but got I4
		//IL_0447: Expected O, but got I4
		//IL_0511->IL0480: Incompatible stack heights: 1 vs 0
		//IL_0102->IL0480: Incompatible stack heights: 1 vs 0
		//IL_0131->IL0480: Incompatible stack heights: 1 vs 0
		//IL_0538->IL0480: Incompatible stack heights: 1 vs 0
		//IL_019c->IL0480: Incompatible stack heights: 1 vs 0
		//IL_01fa->IL0480: Incompatible stack heights: 1 vs 0
		//IL_026e->IL0480: Incompatible stack heights: 1 vs 0
		//IL_024c->IL024c: Incompatible stack heights: 2 vs 1
		//IL_036b->IL0480: Incompatible stack heights: 1 vs 0
		//IL_03df->IL0480: Incompatible stack heights: 1 vs 0
		//IL_03bd->IL03bd: Incompatible stack heights: 2 vs 1
		_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass15_0();
		if (CS_0024_003C_003E8__locals13 != null)
		{
			CS_0024_003C_003E8__locals13._003C_003E4__this = this;
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				MainGamePage mainGamePage = core._003CMainUI_003Ek__BackingField;
				if ((object)core._003CMainUI_003Ek__BackingField != null && (object)mainGamePage._KillsIcon != null)
				{
					Transform transform = mainGamePage._KillsIcon.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						object obj = default(object);
						Vector3 vector = UICamera.UIToGame((Vector3)(&obj));
						PhaserScene s_scene = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null)
						{
							Vector2 pos = default(Vector2);
							PhaserSprite phaserSprite = RenderingExtensions.sprite(s_scene.add, pos, "items", "SkullToken");
							if ((object)phaserSprite != null)
							{
								PhaserSprite phaserSprite2 = phaserSprite.setAlpha(1f);
								if ((object)phaserSprite2 != null)
								{
									PhaserSprite img = phaserSprite2.setScale(2f, (float?)(object)0);
									CS_0024_003C_003E8__locals13.img = img;
									PhaserScene s_scene2 = ArcadePhysics.s_scene;
									if (ArcadePhysics.s_scene != null)
									{
										PhaserSprite phaserSprite3 = RenderingExtensions.sprite(s_scene2.add, pos, "items", "HeartMini");
										if ((object)phaserSprite3 != null)
										{
											PhaserSprite img2 = phaserSprite3.setAlpha(0f);
											CS_0024_003C_003E8__locals13.img2 = img2;
											TweenConfig tweenConfig = new TweenConfig();
											object[] array = new object[1];
											if (array != null)
											{
												if ((object)CS_0024_003C_003E8__locals13.img != null)
												{
													nint num = (nint)array;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
													object obj2 = default(object);
													bool flag2 = obj2 == null;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												if (tweenConfig != null)
												{
													tweenConfig.targets = array;
													tweenConfig.scale = (float?)(object)1;
													tweenConfig.alpha = (float?)(object)1;
													tweenConfig.duration = 500f;
													float2 float5 = base.position;
													tweenConfig.x = (float?)(object)1;
													float2 float6 = base.position;
													object obj3 = default(object);
													float num2 = (float)obj3 + 0.24f;
													tweenConfig.y = (float?)(object)1;
													TweenCallback onUpdate = delegate
													{
														//IL_00d7->IL0086: Incompatible stack heights: 1 vs 0
														PhaserSprite img3 = CS_0024_003C_003E8__locals13.img;
														if ((object)CS_0024_003C_003E8__locals13.img != null)
														{
															PhaserSprite spriteRenderer = (PhaserSprite)(object)img3._spriteRenderer;
															if ((object)img3._spriteRenderer != null)
															{
																bool flag4 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
																SpriteRenderer.get_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, out Color _);
																if ((object)CS_0024_003C_003E8__locals13.img2 != null)
																{
																	object obj5 = default(object);
																	float alpha = 1f - (float)obj5;
																	PhaserSprite phaserSprite4 = CS_0024_003C_003E8__locals13.img2.setAlpha(alpha);
																	return;
																}
															}
														}
														throw new NullReferenceException();
													};
													tweenConfig.onUpdate = onUpdate;
													MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
													TweenConfig tweenConfig2 = new TweenConfig();
													object[] array2 = new object[1];
													if (array2 != null)
													{
														if ((object)CS_0024_003C_003E8__locals13.img2 != null)
														{
															nint num3 = (nint)array2;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															object obj4 = default(object);
															bool flag3 = obj4 == null;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														if (tweenConfig2 != null)
														{
															tweenConfig2.targets = array2;
															tweenConfig2.scale = (float?)(object)1;
															tweenConfig2.duration = 500f;
															float2 float7 = base.position;
															tweenConfig2.x = (float?)(object)1;
															float2 float8 = base.position;
															tweenConfig2.y = (float?)(object)1;
															TweenCallback onComplete = delegate
															{
																CS_0024_003C_003E8__locals13._003C_003E4__this.FakeRecover();
																CS_0024_003C_003E8__locals13.img.destroy();
																CS_0024_003C_003E8__locals13.img2.destroy();
															};
															tweenConfig2.onComplete = onComplete;
															MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
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
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void FakeRecover()
	{
		//IL_015d: Expected O, but got I4
		//IL_00ef: Expected I4, but got F4
		//IL_0133: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 0.65f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Roast, soundConfig, 500f, 1, num);
		float recoveredTimes = _recoveredTimes + 1f;
		_recoveredTimes = recoveredTimes;
		ArcadeSprite arcadeSprite = setTintFill(isEnabled: true, 65280u);
		float2 float5 = base.position;
		Vector2 pos = default(Vector2);
		GM.Core.ShowDamageAt(pos, -1000f);
		if (_blinkTimeout != null)
		{
			_blinkTimeout.Cancel();
		}
		Action onComplete = delegate
		{
			ArcadeSprite arcadeSprite3 = setTintFill(isEnabled: false, 16777215u);
		};
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer blinkTimeout = Timers.Register(0.120000005f, onComplete, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_blinkTimeout = blinkTimeout;
		float num2 = _recoveredTimes / 100f;
		float xScale = num2 + 1f;
		ArcadeSprite arcadeSprite2 = setScale(xScale, (float?)(object)0);
	}

	public override void Despawn()
	{
		Action onComplete = _003C_003Ec._003C_003E9__14_0;
		if (_003C_003Ec._003C_003E9__14_0 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__14_0 = delegate
			{
				GM.Core.SetupMusicBanger();
			});
		}
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		base.Despawn();
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		if (!_isInvul)
		{
			base.GetDamaged(value, showHitVfx, damageKb, damageType, hasKb);
		}
	}

	protected unsafe override void OnUpdate()
	{
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
		//IL_0173: Expected O, but got F4
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Expected O, but got Unknown
		//IL_0232->IL0188: Incompatible stack heights: 1 vs 0
		//IL_02af->IL010c: Incompatible stack heights: 2 vs 0
		if (base._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		PhaserScene s_scene = ArcadePhysics.s_scene;
		if (ArcadePhysics.s_scene != null)
		{
			PhaserScene.Renderer renderer = s_scene._renderer;
			if (s_scene._renderer != null)
			{
				ArcadeSprite arcadeSprite = setDepth(renderer.height);
				if (!base._fixedDirection)
				{
					goto IL_00c9;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001876D8DEDh\"");
				if ((object)_currentDirection == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001876D8DEDh\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyAGaea)+1E4]");
					if ((nint)0 == 0)
					{
						goto IL_00c9;
					}
				}
				goto IL_010c;
			}
		}
		goto IL_0188;
		IL_010c:
		float num2;
		if (_receivingDamage)
		{
			float num = base._003CKnockBack_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj = num ^ 0;
			num2 = (float)obj * _damageKb;
		}
		else
		{
			num2 = 1f;
		}
		bool flag = (nint)_currentDirection < 0;
		bool flag2 = (object)_currentDirection == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool flag5 = flag4 & flag3;
		ArcadeSprite arcadeSprite2 = setFlipX(flag5);
		float num3 = GameManager.EnemySpeed * base._003CSpeed_003Ek__BackingField;
		float num4 = num3 / 100f;
		float num5 = num4 * num2;
		float num6 = num5 * base._003CSlow_003Ek__BackingField;
		float num7 = (float)_currentDirection * num6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyAGaea)+1E4]");
		float num8 = 0f * num6;
		BaseBody baseBody = body;
		if (body != null)
		{
			baseBody._velocity = (float2)num7;
			base.angle = 0f;
			return;
		}
		goto IL_0188;
		IL_0188:
		throw new NullReferenceException();
		IL_00c9:
		RetargetIfNecessary();
		object targetTransform = base._targetTransform;
		if ((object)base._targetTransform != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rdi_v9 (System.Object)+10]");
			bool flag6 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rdi_v9 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
			object cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rdi_v10 (System.Object)+10]");
				bool flag7 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rdi_v10 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 ret2);
				Vector2 currentDirection = ret - ret2;
				object obj3 = default(object);
				object obj4 = default(object);
				object obj2 = obj3 - obj4;
				Vector2 vector = (Vector2)(this + 480);
				_currentDirection = currentDirection;
				((Vector2*)vector)->Normalize();
				goto IL_010c;
			}
		}
		goto IL_0188;
	}

	protected override void Die()
	{
		//IL_0160: Expected O, but got I4
		//IL_006e: Expected I, but got O
		//IL_00d2: Expected O, but got I4
		base.Die();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Deathscream, soundConfig, 150f, 2, time);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_ringSprite != null)
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
		tweenConfig.duration = 300f;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			float2 float5 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			PhaserSprite phaserSprite = _ringSprite.setVisible(visible: false);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private void _003CStartSummons_003Eb__13_0()
	{
		if (!base._003CIsDead_003Ek__BackingField)
		{
			GameManager core = GM.Core;
			float2 float5 = base.position;
			Vector2 spawnPos = default(Vector2);
			bool forceSpawn = default(bool);
			GameObject gameObject = core._stage.SpawnEnemy(EnemyType.FS_GGHOST, spawnPos, asRemote: false, forceSpawn);
			GameManager core2 = GM.Core;
			float2 float6 = base.position;
			GameObject gameObject2 = core2._stage.SpawnEnemy(EnemyType.FS_GGHOST, spawnPos, asRemote: false, forceSpawn);
			GameManager core3 = GM.Core;
			float2 float7 = base.position;
			GameObject gameObject3 = core3._stage.SpawnEnemy(EnemyType.FS_GGHOST, spawnPos, asRemote: false, forceSpawn);
			GameManager core4 = GM.Core;
			float2 float8 = base.position;
			GameObject gameObject4 = core4._stage.SpawnEnemy(EnemyType.FS_GGGHOST, spawnPos, asRemote: false, forceSpawn);
			GameManager core5 = GM.Core;
			float2 float9 = base.position;
			GameObject gameObject5 = core5._stage.SpawnEnemy(EnemyType.FS_GGGHOST, spawnPos, asRemote: false, forceSpawn);
			GameManager core6 = GM.Core;
			float2 float10 = base.position;
			GameObject gameObject6 = core6._stage.SpawnEnemy(EnemyType.FS_GGGHOST, spawnPos, asRemote: false, forceSpawn);
		}
		else if (_summonEvent != null)
		{
			_summonEvent.Cancel();
		}
	}

	private void _003CFakeRecover_003Eb__16_0()
	{
		ArcadeSprite arcadeSprite = setTintFill(isEnabled: false, 16777215u);
	}

	private void _003CDie_003Eb__20_0()
	{
		float2 float5 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
	}

	private void _003CDie_003Eb__20_1()
	{
		PhaserSprite phaserSprite = _ringSprite.setVisible(visible: false);
	}
}
