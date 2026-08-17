using System;
using System.Collections;
using System.Collections.Generic;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI;

public class LevelBonusSelectionPage : BaseUIPage
{
	private sealed class _003CShowRoutine_003Ed__25(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public LevelBonusSelectionPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_048f: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_03e0: Expected I4, but got I8
			//IL_005d: Expected I4, but got I8
			//IL_0435: Expected O, but got I
			//IL_008c: Expected O, but got I
			//IL_00e5: Expected O, but got I
			//IL_0140: Expected O, but got I
			//IL_017e: Expected O, but got I
			//IL_01d7: Expected O, but got I
			//IL_0232: Expected O, but got I
			//IL_0269: Expected O, but got I4
			//IL_0272: Expected O, but got I4
			//IL_0614: Expected O, but got I
			//IL_02d1: Expected O, but got I
			//IL_032c: Expected O, but got I
			//IL_05c5: Expected F4, but got I
			//IL_05e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e6: Expected O, but got Unknown
			//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c4: Expected O, but got Unknown
			//IL_03a1: Expected F4, but got O
			//IL_0105->IL04f1: Incompatible stack heights: 1 vs 0
			//IL_012a->IL04f1: Incompatible stack heights: 1 vs 0
			//IL_015c->IL04f1: Incompatible stack heights: 1 vs 0
			//IL_019e->IL04f1: Incompatible stack heights: 1 vs 0
			//IL_01f7->IL04f1: Incompatible stack heights: 2 vs 0
			//IL_021c->IL04f1: Incompatible stack heights: 2 vs 0
			//IL_024e->IL04f1: Incompatible stack heights: 2 vs 0
			//IL_0634->IL04f1: Incompatible stack heights: 2 vs 0
			//IL_0299->IL0040: Incompatible stack heights: 2 vs 0
			//IL_02f1->IL04f1: Incompatible stack heights: 3 vs 0
			//IL_0316->IL04f1: Incompatible stack heights: 3 vs 0
			//IL_0348->IL04f1: Incompatible stack heights: 3 vs 0
			//IL_0592->IL04f1: Incompatible stack heights: 5 vs 0
			//IL_03d1->IL0604: Incompatible stack heights: 7 vs 2
			Component component = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj != 1)
					{
						goto IL_0040;
					}
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ r14_v1 (UnityEngine.Component)+138]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ r14_v1 (UnityEngine.Component)+138]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v46+18]");
							bool flag2 = (nint)0 <= (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v46+10]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v46+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v42+20]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v42+20]");
									RectTransform component2 = ((Component)0).GetComponent<RectTransform>();
									if ((object)component2 != null)
									{
										Vector2 anchoredPosition = component2.anchoredPosition;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ r14_v1 (UnityEngine.Component)+138]");
										object obj4 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ r14_v1 (UnityEngine.Component)+138]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v49+18]");
											bool flag3 = (nint)0 <= (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v49+10]");
											object obj5 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v49+10]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v50+28]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v50+28]");
													RectTransform component3 = ((Component)0).GetComponent<RectTransform>();
													if ((object)component3 != null)
													{
														Vector2 anchoredPosition2 = component3.anchoredPosition;
														object obj6 = 0;
														object obj7 = 0;
														Vector2 value = default(Vector2);
														while (true)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ r14_v1 (UnityEngine.Component)+138]");
															object obj8 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ r14_v1 (UnityEngine.Component)+138]");
															if ((nint)0 == 0)
															{
																break;
															}
															object obj9 = obj7;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v54+18]");
															if ((nint)obj9 < 0)
															{
																object obj10 = obj6;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v54+18]");
																bool flag4 = (nint)obj10 >= 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v54+10]");
																object obj11 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v54+10]");
																if ((nint)0 == 0)
																{
																	break;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rcx_v49+20+v150 @ rbp_v15*8]");
																if ((nint)0 == 0)
																{
																	break;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rcx_v49+20+v150 @ rbp_v15*8]");
																RectTransform component4 = ((Component)0).GetComponent<RectTransform>();
																if ((object)component4 == null)
																{
																	break;
																}
																bool flag5 = ((_003CShowRoutine_003Ed__25)(object)component4)._003C_003E1__state == 0;
																RectTransform.get_anchoredPosition_Injected((IntPtr)((_003CShowRoutine_003Ed__25)(object)component4)._003C_003E1__state, out Vector2 _);
																bool flag6 = ((_003CShowRoutine_003Ed__25)(object)component4)._003C_003E1__state == 0;
																RectTransform.set_anchoredPosition_Injected((IntPtr)((_003CShowRoutine_003Ed__25)(object)component4)._003C_003E1__state, ref value);
																CanvasGroup component5 = component4.GetComponent<CanvasGroup>();
																if ((object)component5 == null)
																{
																	break;
																}
																bool flag7 = ((UnityEngine.Object)component5).m_CachedPtr == (IntPtr)0;
																CanvasGroup.set_alpha_Injected(((UnityEngine.Object)component5).m_CachedPtr, 0f);
																bool flag8 = ((_003CShowRoutine_003Ed__25)(object)component4)._003C_003E1__state == 0;
																Transform.SetAsLastSibling_Injected((IntPtr)((_003CShowRoutine_003Ed__25)(object)component4)._003C_003E1__state);
																object obj12 = obj6 & 1;
																if (obj12 != null)
																{
																	float num = (float)obj6 * 0.008f;
																	float duration = num + 0.15f;
																	TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOAnchorPosX(component4, (float)anchoredPosition2, duration);
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
																}
																obj6++;
																obj7 = obj6;
																continue;
															}
															goto IL_0040;
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
				else
				{
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ r14_v1 (UnityEngine.Component)+E0]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ r14_v1 (UnityEngine.Component)+E0]");
							LayoutGroup component6 = ((Component)0).GetComponent<LayoutGroup>();
							if ((object)component6 != null)
							{
								component6.enabled = false;
								_003C_003E2__current = null;
								_003C_003E1__state = 2;
								goto IL_0639;
							}
						}
					}
				}
			}
			else
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					RectTransform component7 = _003C_003E4__this.GetComponent<RectTransform>();
					LayoutRebuilder.ForceRebuildLayoutImmediate(component7);
					Canvas.ForceUpdateCanvases();
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					goto IL_0639;
				}
			}
			throw new NullReferenceException();
			IL_0639:
			return true;
			IL_0040:
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

	private sealed class _003CWaitAndSelect_003Ed__27(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public LevelBonusSelectionPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			LevelBonusSelectionPage levelBonusSelectionPage = _003C_003E4__this;
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
				List<LevelBonusSelectionItem> spawned = levelBonusSelectionPage._spawned;
				if (spawned._size <= 0)
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					bool result = default(bool);
					return result;
				}
				LevelBonusSelectionItem[] items = spawned._items;
				Selectable component = items[0].GetComponent<Selectable>();
				component.Select();
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

	private RectTransform _Container;

	private GameObject _WeaponPrefab;

	private RectTransform _Panel;

	private RectTransform _SkipButton;

	private SpriteReel _LeftBanner;

	private SpriteReel _RightBanner;

	private UISpriteAnimation _VFX;

	private DataManager _dataManager;

	private Dictionary<WeaponType, List<WeaponData>> _weapons;

	private LevelBonusSelectionItem _currentSelected;

	private PowerUpType _currentType;

	private List<LevelBonusSelectionItem> _spawned;

	private VampireSurvivors.Objects.Characters.CharacterController _targetCharacter;

	private void Construct(DataManager data)
	{
		//IL_0099: Expected O, but got I4
		//IL_0099: Expected O, but got I
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_01a5: Expected O, but got I
		//IL_0145: Expected O, but got I4
		//IL_0145: Expected O, but got I
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_01e0: Expected O, but got I
		_dataManager = data;
		Action<OnlineSignals.SelectLevelUpBonus> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9EE90");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.SelectLevelUpBonus>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.SelectLevelUpBonus>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v13 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		Action action3 = OnLevelBonusSkippedRemotely;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rbx_v8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj4 = null;
		Action<object> action4 = ((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.SkipLevelBonus>)obj4)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.SkipLevelBonus>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus2 = SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v28 (System.Object)+10]");
		Type signalType2 = default(Type);
		signalBus2.SubscribeInternal(signalType2, (object)null, (object)0, callback);
	}

	private void OnLevelBonusSkippedRemotely()
	{
		ExecuteSkip();
	}

	private void OnLevelUpBonusRemotely(OnlineSignals.SelectLevelUpBonus bonus)
	{
		//IL_000a: Expected I4, but got O
		ExecuteLevelUpBonus((PowerUpType)bonus);
	}

	protected void OnDestroy()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		Action<OnlineSignals.SelectLevelUpBonus> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9EE90");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		SignalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		Action token2 = OnLevelBonusSkippedRemotely;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		SignalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
	}

	public void SetSelected(LevelBonusSelectionItem item)
	{
		_currentSelected = item;
		LevelBonusSelectionItem currentSelected = _currentSelected;
		_currentType = currentSelected._type;
	}

	public void Skip()
	{
		//IL_0070: Expected I8, but got O
		//IL_0088: Expected I8, but got O
		//IL_0054: Expected O, but got I
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			ExecuteSkip();
			return;
		}
		long num = (long)OnlineStageManager._instance;
		Action<long> action = null;
		((OnlineStageManager)(object)action).LevelBonusSelectionSkip((long)OnlineStageManager._instance);
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rbx_v3 (System.Int64)+78]");
		bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public unsafe void ConfirmBonus(LevelBonusSelectionItem item)
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string message = "CONFIRMING : " + text;
		Debug.Log(message);
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			ExecuteLevelUpBonus(item._type);
			return;
		}
		OnlineStageManager instance = OnlineStageManager._instance;
		Action<long, int> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5A20");
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		int param = default(int);
		bool flag = instance._sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame, param);
	}

	private void ExecuteLevelUpBonus(PowerUpType item)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0071: Expected I, but got O
		//IL_008d: Expected O, but got I
		ApplyChosenBonus(item);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		SignalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		ExitMultiplayerControl();
	}

	private void ExecuteSkip()
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		Debug.Log("SKIPPING");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		SignalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		ExitMultiplayerControl();
	}

	private void ApplyChosenBonus(PowerUpType powerUpType)
	{
		//IL_002a: Expected O, but got I8
		//IL_0044: Expected O, but got I8
		if (powerUpType <= PowerUpType.CURSE)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ r8_v1+6CF1168+powerUpType @ rdx (VampireSurvivors.Data.PowerUpType)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ rdx_v2 (should have been resolved before IL gen)");
		}
	}

	protected unsafe override void OnShowStart(GameObject g)
	{
		//IL_0285: Expected O, but got Ref
		//IL_05d7: Expected O, but got Ref
		//IL_0421: Expected O, but got I4
		//IL_047e: Expected O, but got I4
		//IL_03ae->IL04ce: Incompatible stack heights: 8 vs 0
		//IL_0646->IL04ce: Incompatible stack heights: 9 vs 0
		//IL_03f3->IL04ce: Incompatible stack heights: 9 vs 0
		base.OnShowStart(g);
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			_targetCharacter = core._003CEnterBonusSelectionPlayer_003Ek__BackingField;
			GameObject targetCharacter = (GameObject)(object)_targetCharacter;
			if ((object)_targetCharacter != null && ((UnityEngine.Object)targetCharacter).m_CachedPtr != (IntPtr)0)
			{
				goto IL_00c6;
			}
			GameManager core2 = GM.Core;
			if ((object)GM.Core != null)
			{
				GameSessionData gameSessionData = core2._gameSessionData;
				if (core2._gameSessionData != null)
				{
					_targetCharacter = gameSessionData._activeCharacter;
					goto IL_00c6;
				}
			}
		}
		goto IL_04ce;
		IL_00c6:
		if ((object)_Container != null)
		{
			LayoutGroup component = _Container.GetComponent<LayoutGroup>();
			if ((object)component != null)
			{
				component.enabled = true;
				GameManager core3 = GM.Core;
				if ((object)GM.Core != null)
				{
					CoopConfig coopConfig = core3.CoopConfig;
					if ((object)core3.CoopConfig != null)
					{
						EnterMultiplayerControl(_targetCharacter, coopConfig._levelupVibrationMilliseconds);
						Clear();
						if ((object)_VFX != null)
						{
							_VFX.Play();
							if ((object)_Panel != null)
							{
								Transform transform = _Panel.transform;
								if ((object)transform != null)
								{
									bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
									bool flag2 = (object)_Panel == null;
									Transform transform2 = _Panel.transform;
									bool flag3 = (object)transform2 == null;
									bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
									Vector3 value = default(Vector3);
									Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
									bool flag5 = (object)_Panel == null;
									Transform transform3 = _Panel.transform;
									bool flag6 = (object)transform3 == null;
									transform3.localEulerAngles = (Vector3)(&ret);
									bool flag7 = (object)_Panel == null;
									Transform target = _Panel.transform;
									TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 1f, 0.15f);
									if (tweenerCore != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1142 @ rax_v53 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
										if ((nint)0 != 0)
										{
											_ = 1;
											_ = 0;
										}
									}
									bool flag8 = (object)_Panel == null;
									Transform target2 = _Panel.transform;
									TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(target2, (Vector3)(&ret), 0.15f);
									if (tweenerCore2 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1246 @ rax_v59 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
										if ((nint)0 != 0)
										{
											_ = 1;
											_ = 0;
										}
									}
									GameObject skipButton = (GameObject)(object)_SkipButton;
									if ((object)_SkipButton != null)
									{
										bool flag9 = ((UnityEngine.Object)skipButton).m_CachedPtr == (IntPtr)0;
										Transform.SetAsLastSibling_Injected(((UnityEngine.Object)skipButton).m_CachedPtr);
										Populate();
										if ((object)_SkipButton != null)
										{
											GameObject gameObject = _SkipButton.gameObject;
											bool active = IsLocalPlayerControllingUi();
											if ((object)gameObject != null)
											{
												gameObject.SetActive(active);
												float time = default(float);
												PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LevelUp, new SoundManager.SoundConfig
												{
													Volume = (float?)(object)1,
													Rate = 1f,
													Detune = -200f
												}, 0f, 10, time);
												PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.LevelUp, new SoundManager.SoundConfig
												{
													Volume = (float?)(object)1,
													Rate = 1f,
													Detune = -1500f
												}, 0f, 10, time);
												_003CShowRoutine_003Ed__25 obj = null;
												obj._003C_003E1__state = 0;
												obj._003C_003E4__this = this;
												Coroutine coroutine = StartCoroutine(obj);
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
		goto IL_04ce;
		IL_04ce:
		throw new NullReferenceException();
	}

	protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
	{
		return _targetCharacter;
	}

	private IEnumerator ShowRoutine()
	{
		_003CShowRoutine_003Ed__25 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void Populate()
	{
		SpawnItem(PowerUpType.POWER);
		SpawnItem(PowerUpType.GROWTH);
		SpawnItem(PowerUpType.AREA);
		SpawnItem(PowerUpType.LUCK);
		SpawnItem(PowerUpType.SPEED);
		SpawnItem(PowerUpType.GREED);
		SpawnItem(PowerUpType.DURATION);
		SpawnItem(PowerUpType.CURSE);
		SpawnItem(PowerUpType.REGEN);
		SpawnItem(PowerUpType.MOVESPEED);
		object skipButton = _SkipButton;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rsi_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rsi_v1 (System.Object)+10]");
		Transform.SetAsLastSibling_Injected((IntPtr)0);
		_003CWaitAndSelect_003Ed__27 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator WaitAndSelect()
	{
		_003CWaitAndSelect_003Ed__27 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void SpawnItem(PowerUpType p)
	{
		//IL_0093: Expected O, but got I
		//IL_00b2: Expected O, but got I
		GameObject gameObject = UnityEngine.Object.Instantiate(_WeaponPrefab, _Container);
		LevelBonusSelectionItem component = gameObject.GetComponent<LevelBonusSelectionItem>();
		Dictionary<PowerUpType, List<PowerUpData>> convertedPowerUpData = _dataManager.GetConvertedPowerUpData();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedPowerUpData).get_Item((System.Int32Enum)p);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v12 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v12 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ r9_v4+20]");
			component.SetData(this, p, (PowerUpData)0);
			GameObject gameObject2 = component.gameObject;
			CanvasGroup canvasGroup = gameObject2.AddComponent<CanvasGroup>();
			canvasGroup.alpha = 0f;
			if (!IsLocalPlayerControllingUi())
			{
				component._button.interactable = false;
			}
			List<object> spawned = (List<object>)(object)_spawned;
			int version = spawned._version + 1;
			spawned._version = version;
			object[] items = spawned._items;
			if (spawned._size >= items.Length)
			{
				spawned.AddWithResize((object)component);
				return;
			}
			int size = spawned._size + 1;
			spawned._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private void Clear()
	{
		//IL_0039->IL0125: Incompatible stack heights: 1 vs 0
		if (_spawned != null)
		{
			List<LevelBonusSelectionItem>.Enumerator enumerator = default(List<LevelBonusSelectionItem>.Enumerator);
			while (enumerator.MoveNext())
			{
				object obj = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rbx_v7 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rbx_v7 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
				GameObject obj2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				UnityEngine.Object.Destroy(obj2, 0f);
			}
			List<LevelBonusSelectionItem> spawned = _spawned;
			if (_spawned != null)
			{
				int version = spawned._version + 1;
				spawned._version = version;
				spawned._size = 0;
				if (spawned._size > 0)
				{
					Array.Clear(spawned._items, 0, spawned._size);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public LevelBonusSelectionPage()
	{
		List<LevelBonusSelectionItem> spawned = new List<LevelBonusSelectionItem>();
		_spawned = spawned;
		base._002Ector();
	}
}
