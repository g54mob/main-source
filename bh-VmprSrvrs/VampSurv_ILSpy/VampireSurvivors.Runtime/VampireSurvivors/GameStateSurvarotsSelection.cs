using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors;

public class GameStateSurvarotsSelection : GameStateMachineState
{
	private sealed class _003CWaitDelay_003Ed__4(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public GameStateSurvarotsSelection _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			//IL_0478: Expected I4, but got O
			//IL_0091: Expected O, but got I
			//IL_00ec: Expected O, but got I
			//IL_00fc: Expected O, but got I
			//IL_01f2: Expected O, but got I4
			//IL_01f2: Expected O, but got I
			//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0200: Expected O, but got Unknown
			//IL_04cf: Expected O, but got I
			//IL_04cf: Expected O, but got I
			//IL_04df: Expected O, but got I
			//IL_0360: Expected O, but got I4
			//IL_0360: Expected O, but got I
			//IL_0369: Unknown result type (might be due to invalid IL or missing references)
			//IL_036e: Expected O, but got Unknown
			//IL_052f: Expected O, but got I
			//IL_052f: Expected O, but got I
			//IL_053f: Expected O, but got I
			//IL_03df: Expected O, but got I
			//IL_03ef: Expected O, but got I
			object obj = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (System.Object)+28]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (System.Object)+28]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rax_v6+70]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rax_v6+70]");
							((GameManager)0).PauseGame();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (System.Object)+28]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (System.Object)+28]");
							if ((nint)0 != 0)
							{
								Action<UISignals.CharacterCardSelectedSignal> action = null;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAC0C0");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v8+60]");
								if ((nint)0 != 0)
								{
									nint num = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rbx_v5 (Il2CppMethodInfo)+38]");
									if ((nint)0 == 0)
									{
									}
									object obj4 = null;
									if (obj4 != null)
									{
										Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.CharacterCardSelectedSignal>)obj4)._003CSubscribeId_003Eb__0;
										((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.CharacterCardSelectedSignal>)0)._003CSubscribeId_003Eb__0((object)1);
										object obj6 = default(object);
										object obj5 = obj6 + 32;
										Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v8+60]");
										nint num2 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rax_v17 (System.Object)+10]");
										Type signalType = default(Type);
										Action<object> callback = default(Action<object>);
										((SignalBus)num2).SubscribeInternal(signalType, (object)null, (object)0, callback);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (System.Object)+28]");
										object obj7 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (System.Object)+28]");
										if ((nint)0 != 0)
										{
											Action action3 = _003C_003E4__this.Skip;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rax_v24+60]");
											if ((nint)0 != 0)
											{
												nint num3 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rbx_v8 (Il2CppMethodInfo)+38]");
												if ((nint)0 == 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
												}
												nint num4 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rbx_v9 (Il2CppMethodInfo)+38]");
												if ((nint)0 == 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rbx_v9 (Il2CppMethodInfo)+38]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
													}
												}
												object obj8 = null;
												if (obj8 != null)
												{
													Action<object> action4 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.SurvarotsSkippedSignal>)obj8)._003CSubscribeId_003Eb__0;
													((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.SurvarotsSkippedSignal>)0)._003CSubscribeId_003Eb__0((object)1);
													object obj10 = default(object);
													object obj9 = obj10 + 32;
													Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rax_v24+60]");
													nint num5 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rax_v33 (System.Object)+10]");
													Type signalType2 = default(Type);
													((SignalBus)num5).SubscribeInternal(signalType2, (object)null, (object)0, callback);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (System.Object)+28]");
													object obj11 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (System.Object)+28]");
													if ((nint)0 != 0)
													{
														Action<GameplaySignals.ConnectionErrorSignal> action5 = null;
														((GameStateSurvarotsSelection)(object)action5).OnConnectionError((GameplaySignals.ConnectionErrorSignal)_003C_003E4__this);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rbx_v12+60]");
														if ((nint)0 != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rbx_v12+60]");
															((GameStateSurvarotsSelection)0).OnConnectionError((GameplaySignals.ConnectionErrorSignal)action5);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (System.Object)+28]");
															object obj12 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (System.Object)+28]");
															if ((nint)0 != 0)
															{
																Action action6 = _003C_003E4__this.Skip;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v43+60]");
																if ((nint)0 != 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8BB0");
																	return false;
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
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	public override void OnEnter()
	{
		_003CWaitDelay_003Ed__4 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	public override void OnExit()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		GameStateMachine gameStateMachine = _gameStateMachine;
		Action<UISignals.CharacterCardSelectedSignal> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAC0C0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		gameStateMachine.SignalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		GameStateMachine gameStateMachine2 = _gameStateMachine;
		Action token2 = Skip;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		gameStateMachine2.SignalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
		GameStateMachine gameStateMachine3 = _gameStateMachine;
		Action<GameplaySignals.ConnectionErrorSignal> action = null;
		((GameStateSurvarotsSelection)(object)action).OnConnectionError((GameplaySignals.ConnectionErrorSignal)this);
		((GameStateSurvarotsSelection)(object)gameStateMachine3.SignalBus).OnConnectionError((GameplaySignals.ConnectionErrorSignal)action);
		GameStateMachine gameStateMachine4 = _gameStateMachine;
		Action action2 = Skip;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8970");
		if (SoundManager._003CAllowUIFades_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
			BgmType bgmType = default(BgmType);
			SoundManager.FadeMusic(bgmType, 0.3f, 500f);
		}
		GameStateMachine gameStateMachine5 = _gameStateMachine;
		gameStateMachine5._003CGameplayManager_003Ek__BackingField.ResumeGame();
	}

	private void AddCharacterCard(UISignals.CharacterCardSelectedSignal sig)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A48BA]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		GameStateMachine gameStateMachine = _gameStateMachine;
		GameManager gameManager = gameStateMachine._003CGameplayManager_003Ek__BackingField;
		GameSessionData gameSessionData = gameManager._gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
		CharacterSkillCard_Base card = sig.Card;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v183 @ rax_v5 (VampireSurvivors.Objects.Characters.CharacterSkillCard_Base)+198] (should have been resolved before IL gen)");
		CharacterSkillCardsManager characterSkillCardsManager = activeCharacter.CharacterSkillCardsManager;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1A80");
		CharacterSkillCard_Base card2 = sig.Card;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v200 @ rax_v9 (VampireSurvivors.Objects.Characters.CharacterSkillCard_Base)+1A8] (should have been resolved before IL gen)");
		gameSessionData._activeCharacter.OnSkillCardAdded((CharacterSkillCard_Base)sig);
		parentStateMachine.FireEvent("RETURN_TO_GAME");
		GameEventMessage.SendEvent("RETURN_TO_GAME");
	}

	private void Skip()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A48BB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("RETURN_TO_GAME");
		GameEventMessage.SendEvent("RETURN_TO_GAME");
	}

	private IEnumerator WaitDelay()
	{
		_003CWaitDelay_003Ed__4 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void OnConnectionError(GameplaySignals.ConnectionErrorSignal signal)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A48BD]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("CONNECTION_ERROR");
		GameEventMessage.SendEvent("CONNECTION_ERROR");
	}

	public GameStateSurvarotsSelection()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
