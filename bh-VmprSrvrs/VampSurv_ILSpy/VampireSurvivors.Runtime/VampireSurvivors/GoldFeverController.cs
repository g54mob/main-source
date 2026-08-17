using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors;

public class GoldFeverController : GameTickable, IInitializable, IDisposable
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action<Pickup> _003C_003E9__27_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003COnEnemyDeath_003Eb__27_0(Pickup pickup)
		{
			if ((object)pickup != null && ((UnityEngine.Object)pickup).m_CachedPtr != (IntPtr)0)
			{
				pickup.Time = 1f;
				pickup.GoToPlayer = true;
				pickup._003CFeverMS_003Ek__BackingField = 10f;
			}
		}
	}

	private SignalBus _signalBus;

	private PlayerOptions _playerOptions;

	private GameManager _gameManager;

	private DataManager _dataManager;

	private GameSessionData _session;

	private ArcanaManager _arcanas;

	private bool _isActive;

	private float _totalTime;

	private float _durationInMS;

	private float _durationCap = 10f;

	private float _defaultCap = 10f;

	private float _totalDuration;

	private List<float> _randoms;

	private int _randomIndex;

	private float _total;

	private float _redu;

	private bool _isFake;

	public void Initialize()
	{
		//IL_0085: Expected O, but got I4
		//IL_0085: Expected O, but got I
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_01e2: Expected O, but got I
		//IL_0110: Expected O, but got I
		//IL_0120: Expected O, but got I
		//IL_0189: Expected O, but got I
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Expected O, but got Unknown
		Action<UISignals.GoldFeverStartedSignal> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96C60");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.GoldFeverStartedSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.GoldFeverStartedSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v14 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		Action action3 = EndGoldFever;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96D40");
		Action<GameplaySignals.EnemyKilledImmediateSignal> action4 = null;
		((GoldFeverController)(object)action4).OnEnemyDeath((GameplaySignals.EnemyKilledImmediateSignal)this);
		((GoldFeverController)(object)_signalBus).OnEnemyDeath((GameplaySignals.EnemyKilledImmediateSignal)action4);
		Type type = null;
		do
		{
			List<float> randoms = _randoms;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v24 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v24 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v24 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj5 = 0;
			float item = (float)type / 1000f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v24 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ r8_v10+18]");
			if (num2 >= 0)
			{
				randoms.AddWithResize(item);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v24 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj6 = (nint)0 + (nint)1;
			}
			type = (Type)(type + 1);
		}
		while ((nint)type < 1000);
		Extensions.Shuffle(_randoms);
	}

	public void Dispose()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Action<UISignals.GoldFeverStartedSignal> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96C60");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		Action action = EndGoldFever;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97040");
		Action<GameplaySignals.EnemyKilledImmediateSignal> action2 = null;
		((GoldFeverController)(object)action2).OnEnemyDeath((GameplaySignals.EnemyKilledImmediateSignal)this);
		((GoldFeverController)(object)_signalBus).OnEnemyDeath((GameplaySignals.EnemyKilledImmediateSignal)action2);
	}

	protected override void OnTick()
	{
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		if (!_isActive)
		{
			return;
		}
		float deltaTime = PauseSystem.DeltaTime;
		float totalDuration = deltaTime + _totalDuration;
		_totalDuration = totalDuration;
		GameManager core = GM.Core;
		float num = ((!core._003CIsTimeStopped_003Ek__BackingField) ? 1f : 0.5f);
		float deltaTime2 = PauseSystem.DeltaTime;
		float num2 = deltaTime2 * _redu;
		float num3 = num2 * num;
		if (!((_totalTime = num3 + _totalTime) < _durationInMS))
		{
			_totalTime = 0f;
			_isActive = false;
			PlayerOptionsData config = _playerOptions.Config;
			PlayerOptionsData config2 = _playerOptions.Config;
			if (_totalDuration > config._003CLongestFever_003Ek__BackingField)
			{
				PlayerOptionsData config3 = _playerOptions.Config;
				config3._003CLongestFever_003Ek__BackingField = _totalDuration;
			}
			if (_total > config2._003CHighestFever_003Ek__BackingField)
			{
				PlayerOptionsData config4 = _playerOptions.Config;
				config4._003CHighestFever_003Ek__BackingField = _total;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		}
	}

	public bool IsFake()
	{
		return _isFake;
	}

	public float GetScaleFactor()
	{
		//IL_008a: Expected O, but got I4
		//IL_007c: Expected O, but got I8
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003E40");
		object obj = default(object);
		if (_total < 2.1474836E+09f)
		{
			if (-2.1474836E+09f < _total)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				float num = -2.1474836E+09f;
			}
			else
			{
				float num = -2.1474836E+09f;
				obj = 2147483648L;
			}
		}
		else
		{
			obj = 2147483647;
		}
		float num2 = (float)obj / 10000f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
		float num3 = num2 * 0.15f;
		return num3 + 1f;
	}

	public float GetProgress()
	{
		return _totalTime / _durationInMS;
	}

	public float GetDuration()
	{
		return _totalDuration;
	}

	public int GetTotalCoins()
	{
		//IL_0067: Expected I4, but got I8
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003E40");
		if (_total < 2.1474836E+09f)
		{
			if (-2.1474836E+09f < _total)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				int result = default(int);
				return result;
			}
			return -2147483648;
		}
		return 2147483647;
	}

	public void OnCoinPickup(Pickup c)
	{
		//IL_030e: Invalid comparison between I4 and F4
		//IL_00d1: Expected O, but got I4
		//IL_00a8: Expected O, but got I4
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_02c3: Expected O, but got I4
		//IL_02b5: Expected O, but got I8
		if (!_isActive)
		{
			ArcanaManager arcanas = _arcanas;
			if (!arcanas._003CCoinFever_003Ek__BackingField)
			{
				return;
			}
			if (c._003CPickupType_003Ek__BackingField != ItemType.COINBAG1)
			{
				if (c._003CPickupType_003Ek__BackingField != ItemType.COINBAGMAX && c._003CPickupType_003Ek__BackingField != ItemType.STATIC_GOLDPILE)
				{
					return;
				}
				object obj = 1092616192;
			}
			else
			{
				_durationInMS = 0f;
				object obj = 1084227584;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A971C0");
			return;
		}
		GameSessionData session = _session;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = session._activeCharacter;
		float num = c._003CFeverMS_003Ek__BackingField / 1000f;
		float num2 = num * activeCharacter._gFeverMul;
		if ((_durationInMS = num2 + _durationInMS) > _durationCap)
		{
			_durationInMS = _durationCap;
		}
		if (0f > (_totalTime -= num2))
		{
			_totalTime = 0f;
		}
		GameSessionData session2 = _session;
		float num3 = c._003CValue_003Ek__BackingField * GameManager.GoldMultiplier;
		float num4 = session2._activeCharacter.PGreed();
		float num5 = 0f * num3;
		float total = num5 + _total;
		_total = total;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		float total2 = _total;
		if (!(_total > 20000f))
		{
			if (total2 > 10000f)
			{
				_redu = 1.1f;
			}
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003E40");
		object obj4 = default(object);
		if (_total < 2.1474836E+09f)
		{
			if (-2.1474836E+09f < _total)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				total2 = -2.1474836E+09f;
			}
			else
			{
				total2 = -2.1474836E+09f;
				obj4 = 2147483648L;
			}
		}
		else
		{
			obj4 = 2147483647;
		}
		float num6 = (float)obj4 / 10000f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
		float num7 = num6 * 0.15f;
		float redu = num7 + 1f;
		_redu = redu;
	}

	private void CheckResults()
	{
		PlayerOptionsData config = _playerOptions.Config;
		PlayerOptionsData config2 = _playerOptions.Config;
		if (_totalDuration > config._003CLongestFever_003Ek__BackingField)
		{
			PlayerOptionsData config3 = _playerOptions.Config;
			config3._003CLongestFever_003Ek__BackingField = _totalDuration;
		}
		if (_total > config2._003CHighestFever_003Ek__BackingField)
		{
			PlayerOptionsData config4 = _playerOptions.Config;
			config4._003CHighestFever_003Ek__BackingField = _total;
		}
	}

	private void OnEnemyDeath(GameplaySignals.EnemyKilledImmediateSignal sig)
	{
		//IL_0054: Expected O, but got I
		//IL_00b1: Invalid comparison between F4 and I
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_0410: Expected I, but got O
		//IL_042c: Expected O, but got I
		//IL_043c: Expected O, but got I
		//IL_01c4: Expected F4, but got I
		//IL_0074->IL02ce: Incompatible stack heights: 1 vs 0
		//IL_00d6->IL0406: Incompatible stack heights: 1 vs 0
		//IL_00f3->IL02ce: Incompatible stack heights: 1 vs 0
		//IL_011d->IL02ce: Incompatible stack heights: 1 vs 0
		//IL_038d->IL02ce: Incompatible stack heights: 2 vs 0
		//IL_045c->IL02ce: Incompatible stack heights: 2 vs 0
		//IL_01e8->IL02ce: Incompatible stack heights: 2 vs 0
		//IL_0401->IL02ce: Incompatible stack heights: 2 vs 0
		//IL_0226->IL02ce: Incompatible stack heights: 2 vs 0
		//IL_0257->IL02ce: Incompatible stack heights: 2 vs 0
		//IL_0283->IL02ce: Incompatible stack heights: 2 vs 0
		//IL_02ce->IL0406: Incompatible stack heights: 2 vs 0
		if (!_isActive)
		{
			return;
		}
		List<float> randoms = _randoms;
		int randomIndex = _randomIndex + 1;
		_randomIndex = randomIndex;
		if (_randoms != null)
		{
			int randomIndex2 = _randomIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ r8_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			int num = (int)((nint)randomIndex2 % (nint)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ r8_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			bool flag = (nint)num >= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ r8_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ r8_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ r8_v8+18]");
				if ((nint)num >= (nint)0)
				{
					throw new IndexOutOfRangeException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ r8_v8+20+v290 @ rdx_v10 (System.Int32)*4]");
				if (0.75f < 0f)
				{
					return;
				}
				if ((object)sig != null)
				{
					Transform transform = ((Component)sig).transform;
					if ((object)transform != null)
					{
						bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						if (_signalBus != null)
						{
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
							object obj3 = default(object);
							object obj2 = obj3 + 32;
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
							IntPtr intPtr = default(IntPtr);
							num2 = intPtr;
							object obj4 = default(object);
							object signal = (IntPtr)obj4;
							bool requireDeclaration = default(bool);
							_signalBus.InternalFire((Type)num2, signal, (object)null, requireDeclaration);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [sig @ rdx (VampireSurvivors.Signals.GameplaySignals+EnemyKilledImmediateSignal)+B0]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [sig @ rdx (VampireSurvivors.Signals.GameplaySignals+EnemyKilledImmediateSignal)+B0]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018696E2C7h\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rax_v34+128]");
								float num3;
								if ((nint)0 == 0)
								{
									num3 = 1f;
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rax_v34+128]");
									num3 = 0f;
								}
								float num4 = num3 * 0.5f;
								Action<Pickup> callback = _003C_003Ec._003C_003E9__27_0;
								if (_003C_003Ec._003C_003E9__27_0 == null)
								{
									callback = (_003C_003Ec._003C_003E9__27_0 = delegate(Pickup pickup)
									{
										if ((object)pickup != null && ((UnityEngine.Object)pickup).m_CachedPtr != (IntPtr)0)
										{
											pickup.Time = 1f;
											pickup.GoToPlayer = true;
											pickup._003CFeverMS_003Ek__BackingField = 10f;
										}
									});
								}
								if ((object)_gameManager != null)
								{
									Vector2 pos = default(Vector2);
									_gameManager.MakeCoin(pos, num4, callback);
									GameSessionData session = _session;
									if (_session != null && (object)session._activeCharacter != null)
									{
										float num5 = session._activeCharacter.PGreed();
										if (_playerOptions != null)
										{
											PlayerOptionsData config = _playerOptions.Config;
											if (config != null)
											{
												float num6 = GameManager.GoldMultiplier * num4;
												float num7 = num6 * 0f;
												float num8 = num7 + config._003CRunFever_003Ek__BackingField;
												config._003CRunFever_003Ek__BackingField = num8;
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
		throw new NullReferenceException();
	}

	private unsafe float GetHighestFeverBonus()
	{
		//IL_0305: Expected I, but got O
		//IL_01b2: Expected I, but got O
		//IL_0084: Expected I, but got O
		//IL_0229: Expected F4, but got I4
		//IL_0236: Expected F4, but got O
		//IL_0107: Expected I, but got O
		//IL_0244: Expected O, but got I4
		//IL_0139: Expected O, but got I
		//IL_0181: Expected F4, but got I4
		//IL_019f: Expected F4, but got I
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		GameManager core = GM.Core;
		float num5;
		if ((object)GM.Core != null && core._multiplayer != null)
		{
			int playerCount = core._multiplayer.GetPlayerCount();
			if (playerCount <= 1 && !core._multiplayer.IsOnlineMultiplayer)
			{
				nint num3 = (nint)typeof(GM);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rax_v27 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
				nint num4 = 0;
				GameManager core2 = GM.Core;
				bool flag = (object)GM.Core == null;
				num2 = num4;
				if (!flag)
				{
					GameSessionData gameSessionData = core2._gameSessionData;
					bool flag2 = core2._gameSessionData == null;
					num2 = num4;
					if (!flag2)
					{
						num2 = (nint)gameSessionData._activeCharacter;
						if ((object)gameSessionData._activeCharacter != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rcx_v4 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+218]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rcx_v4 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+218]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v30+C4]");
								bool flag3 = (nint)0 <= (nint)0;
								num5 = 0f;
								if (!flag3)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v30+C4]");
									num5 = 0f;
								}
								goto IL_033c;
							}
						}
					}
				}
			}
			else
			{
				nint num6 = (nint)typeof(GM);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v13 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
				nint num7 = 0;
				GameManager core3 = GM.Core;
				bool flag4 = (object)GM.Core == null;
				num2 = num7;
				if (!flag4)
				{
					bool flag5 = core3._mainCharacters == null;
					num2 = num7;
					if (!flag5)
					{
						num5 = 0f;
						float num8 = (float)core3._mainCharacters;
						List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
						if (enumerator.MoveNext())
						{
							object obj2 = 0;
							num2 = (nint)(&enumerator);
							throw new NullReferenceException();
						}
						goto IL_033c;
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_033c:
		return num5 + 1f;
	}

	private void StartGoldFever(UISignals.GoldFeverStartedSignal sig)
	{
		//IL_0275: Invalid comparison between I4 and F4
		//IL_00f2: Expected O, but got I4
		//IL_014f: Expected O, but got I4
		//IL_01a7: Expected O, but got I4
		GameSessionData session = _session;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = session._activeCharacter;
		float highestFeverBonus = GetHighestFeverBonus();
		float num = activeCharacter._gFeverMul * _defaultCap;
		bool isFake = default(bool);
		_isFake = isFake;
		float num2 = (_durationCap = highestFeverBonus * num);
		if (!_isActive)
		{
			float highestFeverBonus2 = GetHighestFeverBonus();
			float durationInMS = highestFeverBonus2 * (float)sig;
			_totalTime = 0f;
			_isActive = true;
			_total = 0f;
			_durationInMS = durationInMS;
			_redu = 1f;
			_totalDuration = 0f;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			soundConfig.Detune = -100f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Ringing, soundConfig, 150f, 3, time);
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Volume = (float?)(object)1;
			soundConfig2.Rate = 1f;
			soundConfig2.Detune = -200f;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Ringing, soundConfig2, 150f, 3, time);
			SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
			soundConfig3.Volume = (float?)(object)1;
			soundConfig3.Rate = 1f;
			soundConfig3.Detune = -300f;
			PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.Ringing, soundConfig3, 150f, 3, time);
		}
		else
		{
			if ((_durationInMS = (float)sig + _durationInMS) > num2)
			{
				_durationInMS = num2;
			}
			if (0f > (_totalTime -= (float)sig))
			{
				_totalTime = 0f;
			}
		}
	}

	private void EndGoldFever()
	{
		_isActive = false;
	}

	private float GetRandom()
	{
		//IL_0053: Expected O, but got I
		//IL_0065: Expected F4, but got I
		List<float> randoms = _randoms;
		int randomIndex = _randomIndex + 1;
		_randomIndex = randomIndex;
		int randomIndex2 = _randomIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+18]");
		int num = (int)((nint)randomIndex2 % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)num < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v7+20+v50 @ rdx_v5 (System.Int32)*4]");
			return 0f;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		float result = default(float);
		return result;
	}

	public GoldFeverController()
	{
		List<float> randoms = new List<float>();
		_randoms = randoms;
	}
}
