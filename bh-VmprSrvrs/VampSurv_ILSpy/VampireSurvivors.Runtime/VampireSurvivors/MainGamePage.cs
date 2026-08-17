using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Cpp2ILInjected;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.UI.Twitch;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using VampireSurvivors.Tools;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors;

public class MainGamePage : BaseUIPage
{
	private sealed class _003C_003Ec__DisplayClass48_0
	{
		public Action onCompleteCallback;

		internal void _003CPerformSceneTransition_003Eb__0()
		{
			Action action = onCompleteCallback;
			if (onCompleteCallback != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003CWaitForConfig_003Ed__43(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public MainGamePage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_0089: Expected I4, but got I8
			//IL_025f: Expected I4, but got O
			//IL_0214: Unknown result type (might be due to invalid IL or missing references)
			//IL_0219: Expected O, but got Unknown
			MainGamePage mainGamePage = _003C_003E4__this;
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
				if ((object)_003C_003E4__this != null && mainGamePage._playerOptions != null)
				{
					PlayerOptionsData config = mainGamePage._playerOptions.Config;
					if (config != null && (object)mainGamePage._XPBar != null)
					{
						bool active = !config._003ChideXPBar_003Ek__BackingField;
						mainGamePage._XPBar.SetActive(active);
						if ((object)mainGamePage._FastForwardButton != null)
						{
							GameObject gameObject = mainGamePage._FastForwardButton.gameObject;
							if (mainGamePage._playerOptions != null)
							{
								PlayerOptionsData config2 = mainGamePage._playerOptions.Config;
								if (config2 != null)
								{
									List<ItemType> list = config2._003CCollectedItems_003Ek__BackingField;
									if (config2._003CCollectedItems_003Ek__BackingField != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
										bool active2;
										if ((nint)0 == 0)
										{
											active2 = false;
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
											object obj2 = default(object);
											object obj = obj2 - -1;
											bool flag = obj == null;
											active2 = !flag;
										}
										if ((object)gameObject != null)
										{
											gameObject.SetActive(active2);
											return false;
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

	private Image _ExperienceProgress;

	private TextMeshProUGUI _EnemiesText;

	private Image _KillsIcon;

	private TextMeshProUGUI _CoinsText;

	private TextMeshProUGUI _TimeText;

	private TextMeshProUGUI _LevelText;

	private GoldFeverUIManager _GoldFever;

	private GameObject _CheatsPanel;

	private GameObject _OnlineCheatsPanel;

	private GameObject _XPBar;

	private RectTransform _EquipmentPanelContainer;

	private GameObject _PlayerEquipmentPanelPrefab;

	private Button _PauseButton;

	private Button _FastForwardButton;

	private TwitchStageEventsPanel _TwitchStageEventsPanel;

	private GameObject _SceneTransitionFader;

	private GlimmerTechniqueCarousel _GlimmerTechniqueCarousel;

	private GameObject _SpectateModeContainer;

	private Image _SpectateModeIcon;

	private TextMeshProUGUI _SpectateModePlayerName;

	private TextMeshProUGUI _SpectateModeSwitchPlayerText;

	private SignalBus _signalBus;

	private GameSessionData _session;

	private readonly LocalizedString _levelString = "lang/ingame_level";

	private PlayerOptions _playerOptions;

	private StringBuilder _timeFormatStringBuilder;

	private Dictionary<VampireSurvivors.Objects.Characters.CharacterController, GameObject> _uiPanels = new Dictionary<VampireSurvivors.Objects.Characters.CharacterController, GameObject>();

	public TextMeshProUGUI SurvivedSecondsText => _TimeText;

	public Image KillsIcon => _KillsIcon;

	public TextMeshProUGUI KillsText => _EnemiesText;

	public GoldFeverUIManager GoldFever => _GoldFever;

	public TwitchStageEventsPanel TwitchStageEventsPanel => _TwitchStageEventsPanel;

	protected override bool IsOnlineUi => false;

	private void Construct(SignalBus signalBus, GameSessionData session, PlayerOptions playerOptions)
	{
		//IL_001c: Expected O, but got I4
		//IL_0025: Expected O, but got I4
		//IL_0057: Expected O, but got I4
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected O, but got Unknown
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected O, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Expected O, but got Unknown
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected O, but got Unknown
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Expected O, but got Unknown
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected O, but got Unknown
		_signalBus = signalBus;
		_session = session;
		_playerOptions = playerOptions;
		TextMeshProUGUI[] array = UnityEngine.Object.FindObjectsOfType<TextMeshProUGUI>();
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < array.Length)
		{
			TextMeshProUGUI textMeshProUGUI = array[obj2];
			object obj3 = (int)((TMP_Text)textMeshProUGUI).m_VerticalAlignment | (int)((TMP_Text)textMeshProUGUI).m_HorizontalAlignment;
			if ((nint)obj3 > 2052)
			{
				object obj4 = obj3 - 4097;
				bool flag = (nint)obj3 == 4097;
				if (!flag)
				{
					object obj5 = obj4 - 1;
					if (!flag)
					{
						object obj6 = obj5 - 1;
						if (!flag)
						{
							if ((nint)obj6 == 1)
							{
								goto IL_02a3;
							}
							object obj7 = obj3 - 8193;
							bool flag2 = (nint)obj3 == 8193;
							if (flag2)
							{
								goto IL_02cc;
							}
							object obj8 = obj7 - 1;
							if (!flag2)
							{
								object obj9 = obj8 - 1;
								if (!flag2 && (nint)obj9 == 1)
								{
									goto IL_02a3;
								}
							}
						}
					}
					goto IL_0177;
				}
			}
			else
			{
				object obj10 = obj3 - 513;
				bool flag3 = (nint)obj3 == 513;
				if (!flag3)
				{
					object obj11 = obj10 - 1;
					if (!flag3)
					{
						object obj12 = obj11 - 1;
						if (!flag3)
						{
							if ((nint)obj12 == 1)
							{
								goto IL_02a3;
							}
							object obj13 = obj3 - 2049;
							bool flag4 = (nint)obj3 == 2049;
							if (flag4)
							{
								goto IL_02cc;
							}
							object obj14 = obj13 - 1;
							if (!flag4)
							{
								object obj15 = obj14 - 1;
								if (!flag4 && (nint)obj15 == 1)
								{
									goto IL_02a3;
								}
							}
						}
					}
					goto IL_0177;
				}
			}
			goto IL_02cc;
			IL_02a3:
			textMeshProUGUI.alignment = TextAlignmentOptions.MidlineRight;
			obj2++;
			obj = obj2;
			continue;
			IL_0177:
			textMeshProUGUI.alignment = TextAlignmentOptions.Midline;
			obj2++;
			obj = obj2;
			continue;
			IL_02cc:
			textMeshProUGUI.alignment = TextAlignmentOptions.MidlineLeft;
			obj2++;
			obj = obj2;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.m_MaxCapacity = 2147483647;
		char[] chunkChars = new char[10];
		stringBuilder.m_ChunkChars = chunkChars;
		_timeFormatStringBuilder = stringBuilder;
		_TimeText.text = "00:00";
		TextMeshProUGUI timeText = _TimeText;
		if (((TMP_Text)timeText).m_fontStyle != FontStyles.Bold)
		{
			((TMP_Text)timeText).m_fontStyle = FontStyles.Bold;
			((TMP_Text)timeText).m_havePropertiesChanged = true;
			timeText.SetVerticesDirty();
			timeText.SetLayoutDirty();
		}
		GameObject sceneTransitionFader = _SceneTransitionFader;
		if ((object)_SceneTransitionFader != null && ((UnityEngine.Object)sceneTransitionFader).m_CachedPtr != (IntPtr)0)
		{
			_SceneTransitionFader.SetActive(value: false);
		}
		_CheatsPanel.SetActive(value: false);
		_OnlineCheatsPanel.SetActive(value: false);
	}

	private void Start()
	{
		InitializeEquipment();
	}

	private void OnEnable()
	{
		//IL_009d: Expected O, but got I4
		//IL_009d: Expected O, but got I
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_0bf8: Expected O, but got I
		//IL_0229: Expected O, but got I4
		//IL_0229: Expected O, but got I
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected O, but got Unknown
		//IL_0c33: Expected O, but got I
		//IL_0367: Expected O, but got I
		//IL_038b: Expected O, but got I
		//IL_0543: Expected O, but got I4
		//IL_0543: Expected O, but got I
		//IL_054c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0551: Expected O, but got Unknown
		//IL_0c6e: Expected O, but got I
		//IL_0690: Expected O, but got I4
		//IL_0690: Expected O, but got I
		//IL_0699: Unknown result type (might be due to invalid IL or missing references)
		//IL_069e: Expected O, but got Unknown
		//IL_0ca7: Expected O, but got I
		//IL_07dd: Expected O, but got I4
		//IL_07dd: Expected O, but got I
		//IL_07e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07eb: Expected O, but got Unknown
		//IL_0ce0: Expected O, but got I
		//IL_092a: Expected O, but got I4
		//IL_092a: Expected O, but got I
		//IL_0933: Unknown result type (might be due to invalid IL or missing references)
		//IL_0938: Expected O, but got Unknown
		//IL_0d1b: Expected O, but got I
		Action<GameplaySignals.CharacterXpChangedSignal> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AACC00");
		if (_signalBus != null)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rbx_v4 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
			}
			object obj = null;
			if (obj != null)
			{
				Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.CharacterXpChangedSignal>)obj)._003CSubscribeId_003Eb__0;
				((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.CharacterXpChangedSignal>)0)._003CSubscribeId_003Eb__0((object)1);
				object obj3 = default(object);
				object obj2 = obj3 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				SignalBus signalBus = _signalBus;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rax_v14 (System.Object)+10]");
				Type signalType = default(Type);
				Action<object> callback = default(Action<object>);
				signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
				Action action3 = LevelUp;
				if (_signalBus != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA93F0");
					Action action4 = LevelUp;
					if (_signalBus != null)
					{
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v887 @ rbx_v8 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
						}
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rbx_v9 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rbx_v9 (Il2CppMethodInfo)+38]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
							}
						}
						object obj4 = null;
						if (obj4 != null)
						{
							Action<object> action5 = ((SignalBus._003C_003Ec__DisplayClass35_0<GameplaySignals.LevelUpWithoutScreenSignal>)obj4)._003CSubscribeId_003Eb__0;
							((SignalBus._003C_003Ec__DisplayClass35_0<GameplaySignals.LevelUpWithoutScreenSignal>)0)._003CSubscribeId_003Eb__0((object)1);
							object obj6 = default(object);
							object obj5 = obj6 + 32;
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
							SignalBus signalBus2 = _signalBus;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rax_v32 (System.Object)+10]");
							Type signalType2 = default(Type);
							signalBus2.SubscribeInternal(signalType2, (object)null, (object)0, callback);
							Action action6 = ActivateGoldFever;
							if (_signalBus != null)
							{
								nint num4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1111 @ rbx_v12 (Il2CppMethodInfo)+38]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
								}
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rbx_v13 (Il2CppMethodInfo)+38]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rbx_v13 (Il2CppMethodInfo)+38]");
									if ((nint)0 == 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
									}
								}
								object obj7 = null;
								if (obj7 != null)
								{
									Action<object> action7 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.GoldFeverStartedSignal>)obj7)._003CSubscribeId_003Eb__0;
									Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
									SignalBus signalBus3 = _signalBus;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rax_v47 (System.Object)+10]");
									signalBus3.SubscribeInternal(typeFromHandle, (object)null, (object)0, callback);
									Action action8 = DeactivateGoldFever;
									if (_signalBus != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96D40");
										Action action9 = LevelUp;
										if (_signalBus != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AACCE0");
											Action<UISignals.ToggleXPBarSignal> action10 = null;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AACE60");
											if (_signalBus != null)
											{
												nint num6 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rbx_v18 (Il2CppMethodInfo)+38]");
												if ((nint)0 == 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
												}
												nint num7 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rbx_v19 (Il2CppMethodInfo)+38]");
												if ((nint)0 == 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rbx_v19 (Il2CppMethodInfo)+38]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
													}
												}
												object obj8 = null;
												if (obj8 != null)
												{
													Action<object> action11 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ToggleXPBarSignal>)obj8)._003CSubscribeId_003Eb__0;
													((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ToggleXPBarSignal>)0)._003CSubscribeId_003Eb__0((object)1);
													object obj10 = default(object);
													object obj9 = obj10 + 32;
													Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
													SignalBus signalBus4 = _signalBus;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rax_v68 (System.Object)+10]");
													Type signalType3 = default(Type);
													signalBus4.SubscribeInternal(signalType3, (object)null, (object)0, callback);
													Action<UISignals.ToggleWeaponSlotsSignal> action12 = null;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AACF40");
													if (_signalBus != null)
													{
														nint num8 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1435 @ rbx_v22 (Il2CppMethodInfo)+38]");
														if ((nint)0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
														}
														nint num9 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rbx_v23 (Il2CppMethodInfo)+38]");
														if ((nint)0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rbx_v23 (Il2CppMethodInfo)+38]");
															if ((nint)0 == 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
															}
														}
														object obj11 = null;
														if (obj11 != null)
														{
															Action<object> action13 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ToggleWeaponSlotsSignal>)obj11)._003CSubscribeId_003Eb__0;
															((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ToggleWeaponSlotsSignal>)0)._003CSubscribeId_003Eb__0((object)1);
															object obj13 = default(object);
															object obj12 = obj13 + 32;
															Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
															SignalBus signalBus5 = _signalBus;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v83 (System.Object)+10]");
															Type signalType4 = default(Type);
															signalBus5.SubscribeInternal(signalType4, (object)null, (object)0, callback);
															Action<UISignals.FireNewGlimmerTechnique> action14 = null;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD020");
															if (_signalBus != null)
															{
																nint num10 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1644 @ rbx_v26 (Il2CppMethodInfo)+38]");
																if ((nint)0 == 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
																}
																nint num11 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rbx_v27 (Il2CppMethodInfo)+38]");
																if ((nint)0 == 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rbx_v27 (Il2CppMethodInfo)+38]");
																	if ((nint)0 == 0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
																	}
																}
																object obj14 = null;
																if (obj14 != null)
																{
																	Action<object> action15 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.FireNewGlimmerTechnique>)obj14)._003CSubscribeId_003Eb__0;
																	((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.FireNewGlimmerTechnique>)0)._003CSubscribeId_003Eb__0((object)1);
																	object obj16 = default(object);
																	object obj15 = obj16 + 32;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
																	SignalBus signalBus6 = _signalBus;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v98 (System.Object)+10]");
																	Type signalType5 = default(Type);
																	signalBus6.SubscribeInternal(signalType5, (object)null, (object)0, callback);
																	Action action16 = ChangeSpectateTargetUi;
																	if (_signalBus != null)
																	{
																		nint num12 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1855 @ rbx_v30 (Il2CppMethodInfo)+38]");
																		if ((nint)0 == 0)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
																		}
																		nint num13 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rbx_v31 (Il2CppMethodInfo)+38]");
																		if ((nint)0 == 0)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rbx_v31 (Il2CppMethodInfo)+38]");
																			if ((nint)0 == 0)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
																			}
																		}
																		object obj17 = null;
																		if (obj17 != null)
																		{
																			Action<object> action17 = ((SignalBus._003C_003Ec__DisplayClass35_0<GameplaySignals.ChangeSpectateSignal>)obj17)._003CSubscribeId_003Eb__0;
																			((SignalBus._003C_003Ec__DisplayClass35_0<GameplaySignals.ChangeSpectateSignal>)0)._003CSubscribeId_003Eb__0((object)1);
																			object obj19 = default(object);
																			object obj18 = obj19 + 32;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
																			SignalBus signalBus7 = _signalBus;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v113 (System.Object)+10]");
																			Type signalType6 = default(Type);
																			signalBus7.SubscribeInternal(signalType6, (object)null, (object)0, callback);
																			PlayerOptions playerOptions = _playerOptions;
																			PlayerOptions.OnValueChanged b = UpdateCoins;
																			if (_playerOptions != null)
																			{
																				Delegate obj20 = playerOptions.RunGoldUpdated;
																				while (true)
																				{
																					Delegate obj21 = Delegate.Combine(obj20, b);
																					bool flag = (object)obj21 == null;
																					Delegate obj22 = null;
																					if (!flag)
																					{
																						bool flag2 = (object)obj21.GetType() != typeof(PlayerOptions.OnValueChanged);
																						obj22 = null;
																						if (!flag2)
																						{
																							obj22 = obj21;
																						}
																						if ((object)obj22 == null)
																						{
																							break;
																						}
																					}
																					bool flag3 = (object)obj20 == playerOptions.RunGoldUpdated;
																					Delegate obj23;
																					if ((object)obj20 == playerOptions.RunGoldUpdated)
																					{
																						playerOptions.RunGoldUpdated = (PlayerOptions.OnValueChanged)obj22;
																						obj23 = obj20;
																					}
																					else
																					{
																						obj23 = playerOptions.RunGoldUpdated;
																					}
																					Delegate obj24 = obj20;
																					if (!flag3)
																					{
																						obj24 = obj23;
																					}
																					bool flag4 = (object)obj24 != obj20;
																					obj20 = obj24;
																					if (flag4)
																					{
																						continue;
																					}
																					goto IL_0a4d;
																				}
																				goto IL_0e31;
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
						}
					}
				}
			}
		}
		goto IL_0b96;
		IL_0a4d:
		LocalizedString localizedString = default(LocalizedString);
		string text = localizedString.ToString();
		GameSessionData session = _session;
		string newValue;
		if (_session != null)
		{
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter = session._activeCharacter;
			if ((object)session._activeCharacter != null && ((UnityEngine.Object)activeCharacter).m_CachedPtr != (IntPtr)0)
			{
				GameSessionData session2 = _session;
				if (_session != null && (object)session2._activeCharacter != null)
				{
					int num14 = default(int);
					string text2 = num14.ToString();
					if (text != null)
					{
						newValue = text2;
						goto IL_0dda;
					}
				}
			}
			else if (text != null)
			{
				newValue = "1";
				goto IL_0dda;
			}
		}
		goto IL_0b96;
		IL_0e31:
		throw new InvalidCastException();
		IL_0b96:
		NullReferenceException ex = new NullReferenceException();
		goto IL_0e31;
		IL_0dda:
		string text3 = text.Replace("%0", newValue);
		if ((object)_LevelText != null)
		{
			_LevelText.text = text3;
			_003CWaitForConfig_003Ed__43 obj25 = null;
			obj25._003C_003E1__state = 0;
			obj25._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj25);
			return;
		}
		goto IL_0b96;
	}

	private IEnumerator WaitForConfig()
	{
		_003CWaitForConfig_003Ed__43 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void OnDisable()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Expected O, but got Unknown
		//IL_040c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Expected O, but got Unknown
		//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ea: Expected O, but got Unknown
		//IL_05be: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c3: Expected O, but got Unknown
		//IL_0697: Unknown result type (might be due to invalid IL or missing references)
		//IL_069c: Expected O, but got Unknown
		//IL_0991: Unknown result type (might be due to invalid IL or missing references)
		//IL_0996: Expected O, but got Unknown
		Action<GameplaySignals.CharacterXpChangedSignal> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AACC00");
		if (_signalBus != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool throwIfMissing = default(bool);
			_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
			Action action = LevelUp;
			if (_signalBus != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAACB0");
				Action token2 = LevelUp;
				if (_signalBus != null)
				{
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v532 @ rbx_v8 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
					}
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ rbx_v9 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
					object obj4 = default(object);
					object obj3 = obj4 + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					Type signalType2 = default(Type);
					_signalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
					Action token3 = LevelUp;
					if (_signalBus != null)
					{
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v652 @ rbx_v12 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
						}
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v669 @ rbx_v13 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
						object obj6 = default(object);
						object obj5 = obj6 + 32;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
						Type signalType3 = default(Type);
						_signalBus.UnsubscribeInternal(signalType3, (object)null, (object)token3, throwIfMissing);
						Action token4 = ActivateGoldFever;
						if (_signalBus != null)
						{
							nint num5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rbx_v16 (Il2CppMethodInfo)+38]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
							}
							nint num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v767 @ rbx_v17 (Il2CppMethodInfo)+38]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
							object obj8 = default(object);
							object obj7 = obj8 + 32;
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
							Type signalType4 = default(Type);
							_signalBus.UnsubscribeInternal(signalType4, (object)null, (object)token4, throwIfMissing);
							Action action2 = DeactivateGoldFever;
							if (_signalBus != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97040");
								Action<UISignals.ToggleXPBarSignal> token5 = null;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AACE60");
								if (_signalBus != null)
								{
									nint num7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v854 @ rbx_v21 (Il2CppMethodInfo)+38]");
									if ((nint)0 == 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
									}
									nint num8 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v871 @ rbx_v22 (Il2CppMethodInfo)+38]");
									if ((nint)0 == 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
									object obj10 = default(object);
									object obj9 = obj10 + 32;
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
									Type signalType5 = default(Type);
									_signalBus.UnsubscribeInternal(signalType5, (object)null, (object)token5, throwIfMissing);
									Action<UISignals.ToggleWeaponSlotsSignal> token6 = null;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AACF40");
									if (_signalBus != null)
									{
										nint num9 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v950 @ rbx_v25 (Il2CppMethodInfo)+38]");
										if ((nint)0 == 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
										}
										nint num10 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v967 @ rbx_v26 (Il2CppMethodInfo)+38]");
										if ((nint)0 == 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
										object obj12 = default(object);
										object obj11 = obj12 + 32;
										Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
										Type signalType6 = default(Type);
										_signalBus.UnsubscribeInternal(signalType6, (object)null, (object)token6, throwIfMissing);
										Action<UISignals.FireNewGlimmerTechnique> token7 = null;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD020");
										if (_signalBus != null)
										{
											nint num11 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1046 @ rbx_v29 (Il2CppMethodInfo)+38]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
											}
											nint num12 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1063 @ rbx_v30 (Il2CppMethodInfo)+38]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
											object obj14 = default(object);
											object obj13 = obj14 + 32;
											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
											Type signalType7 = default(Type);
											_signalBus.UnsubscribeInternal(signalType7, (object)null, (object)token7, throwIfMissing);
											Action token8 = ChangeSpectateTargetUi;
											if (_signalBus != null)
											{
												nint num13 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1144 @ rbx_v33 (Il2CppMethodInfo)+38]");
												if ((nint)0 == 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
												}
												nint num14 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1161 @ rbx_v34 (Il2CppMethodInfo)+38]");
												if ((nint)0 == 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
												object obj16 = default(object);
												object obj15 = obj16 + 32;
												Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
												Type signalType8 = default(Type);
												_signalBus.UnsubscribeInternal(signalType8, (object)null, (object)token8, throwIfMissing);
												PlayerOptions playerOptions = _playerOptions;
												PlayerOptions.OnValueChanged value = UpdateCoins;
												if (_playerOptions != null)
												{
													Delegate obj17 = playerOptions.RunGoldUpdated;
													object obj18 = _playerOptions + 16;
													while (true)
													{
														Delegate obj19 = Delegate.Remove(obj17, value);
														bool flag = (object)obj19 == null;
														Delegate obj20 = null;
														if (!flag)
														{
															bool flag2 = (object)obj19.GetType() != typeof(PlayerOptions.OnValueChanged);
															obj20 = null;
															if (!flag2)
															{
																obj20 = obj19;
															}
															if ((object)obj20 == null)
															{
																break;
															}
														}
														bool flag3 = obj17 == obj18;
														Delegate obj21;
														if (obj17 == obj18)
														{
															obj18 = obj20;
															obj21 = obj17;
														}
														else
														{
															obj21 = (Delegate)obj18;
														}
														Delegate obj22 = obj17;
														if (!flag3)
														{
															obj22 = obj21;
														}
														bool flag4 = (object)obj22 != obj17;
														obj17 = obj22;
														if (!flag4)
														{
															return;
														}
													}
													goto IL_0a01;
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
		goto IL_0a01;
		IL_0a01:
		throw new InvalidCastException();
	}

	public bool ArePanelsInitialized()
	{
		//IL_009c: Expected I4, but got O
		//IL_001c: Expected O, but got I4
		Dictionary<VampireSurvivors.Objects.Characters.CharacterController, GameObject> uiPanels = _uiPanels;
		if (_uiPanels != null)
		{
			object obj = uiPanels._count - uiPanels._freeCount;
			object obj2 = obj ^ obj;
			object obj3 = obj & obj2;
			bool flag = (nint)obj3 < 0;
			bool flag2 = (nint)obj < 0;
			bool flag3 = obj == null;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			return flag5 & flag4;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void ReinitializeEquipment()
	{
		//IL_0163: Expected O, but got I4
		//IL_00ad: Expected O, but got I
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		Dictionary<VampireSurvivors.Objects.Characters.CharacterController, GameObject> uiPanels = _uiPanels;
		if (uiPanels._count == uiPanels._freeCount)
		{
			return;
		}
		Dictionary<VampireSurvivors.Objects.Characters.CharacterController, GameObject>.ValueCollection values = uiPanels.Values;
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		UnityEngine.Object obj9 = default(UnityEngine.Object);
		while (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ stack_-28_v10+2C]");
			if (obj2 == null)
			{
				object obj3 = obj4;
				bool flag;
				do
				{
					object obj5 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ stack_-28_v10+20]");
					if ((nint)obj5 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ stack_-28_v10+18]");
						object obj6 = 0;
						obj4 = obj3 + 1;
						object obj7 = obj3 * 2;
						object obj8 = obj3 + obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rdx_v16+20+v595 @ r8_v13*8]");
						flag = (nint)0 < (nint)0;
						obj3 = obj4;
						continue;
					}
					_uiPanels.Clear();
					GameEquipmentPanel._panels.Clear();
					InitializeEquipment();
					return;
				}
				while (flag);
				UnityEngine.Object.Destroy(obj9, 0f);
				continue;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			object obj10 = 0;
			break;
		}
		throw new NullReferenceException();
	}

	public unsafe void UpdateKills()
	{
		//IL_0039: Expected O, but got Ref
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		object obj = default(object);
		string text = System.Number.FormatInt32(config._003CRunEnemies_003Ek__BackingField, (ReadOnlySpan<char>)(&obj), null);
		_EnemiesText.text = text;
	}

	public void PerformSceneTransition(Action onCompleteCallback, float durationMillis = 3000f)
	{
		_003C_003Ec__DisplayClass48_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass48_0();
		CS_0024_003C_003E8__locals5.onCompleteCallback = onCompleteCallback;
		Debug.Log("<color=green>Starting Scene Transition To Holy Forbidden</color>");
		GameObject sceneTransitionFader = _SceneTransitionFader;
		if ((object)_SceneTransitionFader != null && ((UnityEngine.Object)sceneTransitionFader).m_CachedPtr != (IntPtr)0)
		{
			_SceneTransitionFader.SetActive(value: true);
			Action onComplete = delegate
			{
				Action onCompleteCallback3 = CS_0024_003C_003E8__locals5.onCompleteCallback;
				if (CS_0024_003C_003E8__locals5.onCompleteCallback != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			Timer timer = TimerHelper.RegisterMillisUI(durationMillis, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		}
		else
		{
			Action onCompleteCallback2 = CS_0024_003C_003E8__locals5.onCompleteCallback;
			if (CS_0024_003C_003E8__locals5.onCompleteCallback != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v343.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	public void ForceEquipmentLayoutRebuild()
	{
		RectTransform equipmentPanelContainer = _EquipmentPanelContainer;
		if ((object)_EquipmentPanelContainer != null && ((UnityEngine.Object)equipmentPanelContainer).m_CachedPtr != (IntPtr)0)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(_EquipmentPanelContainer);
			Canvas.ForceUpdateCanvases();
		}
	}

	protected override void OnShowStart(GameObject g)
	{
		base.OnShowStart(g);
		ForceEquipmentLayoutRebuild();
	}

	private void UpdateExperienceProgress(GameplaySignals.CharacterXpChangedSignal sig)
	{
		object obj = default(object);
		float fillAmount = (float)sig / (float)obj;
		_ExperienceProgress.fillAmount = fillAmount;
	}

	public unsafe void LevelUp()
	{
		//IL_0072: Expected O, but got Ref
		_ExperienceProgress.fillAmount = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A497A]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		LocalizedString localizedString = default(LocalizedString);
		string text = localizedString.ToString();
		GameSessionData session = _session;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = session._activeCharacter;
		string newValue = System.Number.FormatInt32(activeCharacter._level, (ReadOnlySpan<char>)(&localizedString), null);
		string text2 = text.Replace("%0", newValue);
		_LevelText.text = text2;
	}

	private void ToggleXPBar(UISignals.ToggleXPBarSignal sig)
	{
		bool active = (object)sig == null;
		_XPBar.SetActive(active);
	}

	private void ToggleWeaponSlots(UISignals.ToggleWeaponSlotsSignal sig)
	{
		GameObject gameObject = _EquipmentPanelContainer.gameObject;
		bool active = (object)sig == null;
		gameObject.SetActive(active);
	}

	private void FireNewGlimmerTechnique(UISignals.FireNewGlimmerTechnique sig)
	{
		_GlimmerTechniqueCarousel.SpawnGlimmerTechnique((string)sig);
	}

	private unsafe void AssignLevel()
	{
		//IL_0062: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A497A]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		LocalizedString localizedString = default(LocalizedString);
		string text = localizedString.ToString();
		GameSessionData session = _session;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = session._activeCharacter;
		string newValue = System.Number.FormatInt32(activeCharacter._level, (ReadOnlySpan<char>)(&localizedString), null);
		string text2 = text.Replace("%0", newValue);
		_LevelText.text = text2;
	}

	protected unsafe override void Update()
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_011f: Expected O, but got Ref
		//IL_017c: Expected O, but got Ref
		base.Update();
		GameObject gameObject = _FastForwardButton.gameObject;
		PlayerOptionsData config = _playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		bool active;
		if ((nint)0 == 0)
		{
			active = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			object obj = obj2 - -1;
			bool flag = obj == null;
			active = !flag;
		}
		gameObject.SetActive(active);
		GameManager core = GM.Core;
		_timeFormatStringBuilder.Length = 0;
		float num = core._003CSurvivedSeconds_003Ek__BackingField / 60f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		System.ParamsArray paramsArray2 = default(System.ParamsArray);
		StringBuilder stringBuilder = _timeFormatStringBuilder.AppendFormatHelper((IFormatProvider)null, "{0:00}", (System.ParamsArray)(&paramsArray2));
		StringBuilder stringBuilder2 = _timeFormatStringBuilder.Append(":");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg2 = default(object);
		paramsArray = new System.ParamsArray(arg2);
		StringBuilder stringBuilder3 = _timeFormatStringBuilder.AppendFormatHelper((IFormatProvider)null, "{0:00}", (System.ParamsArray)(&paramsArray2));
		string text = _timeFormatStringBuilder.ToString();
		_TimeText.text = text;
		CanvasGroup canvasGroup = View.CanvasGroup;
		GameManager core2 = GM.Core;
		bool interactable = !core2._isPaused;
		canvasGroup.interactable = interactable;
		GameManager core3 = GM.Core;
		bool flag2 = !core3._isPaused;
		_PauseButton.enabled = flag2;
		CheckSpectateMode();
	}

	private unsafe void ChangeSpectateTargetUi()
	{
		//IL_016f: Expected O, but got I
		//IL_0194: Expected O, but got I
		//IL_0211: Expected O, but got Ref
		//IL_01b5: Expected I4, but got O
		//IL_01da: Expected O, but got Ref
		//IL_01ff: Expected O, but got I4
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Expected O, but got Unknown
		GameManager core = GM.Core;
		GameManager core2 = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
		int num = core2._003CFreeRoamCameraTargetWhenDead_003Ek__BackingField;
		if (core2._003CFreeRoamCameraTargetWhenDead_003Ek__BackingField < mainCharacters._size)
		{
			VampireSurvivors.Objects.Characters.CharacterController[] items = mainCharacters._items;
			VampireSurvivors.Objects.Characters.CharacterController characterController = items[num];
			PlayerInfo playerInfoForCharacter = OnlineStageManager._instance.GetPlayerInfoForCharacter(items[num]);
			TextMeshProUGUI spectateModePlayerName;
			System.ParamsArray paramsArray = default(System.ParamsArray);
			if ((object)playerInfoForCharacter != null && ((UnityEngine.Object)playerInfoForCharacter).m_CachedPtr != (IntPtr)0)
			{
				_SpectateModePlayerName.text = playerInfoForCharacter._003CUserName_003Ek__BackingField;
				spectateModePlayerName = _SpectateModePlayerName;
			}
			else
			{
				GameManager core3 = GM.Core;
				Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = core3._dataManager.GetConvertedCharacterData();
				object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterController._characterType);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rax_v37 (System.Object)+18]");
				if ((nint)0 <= (nint)0)
				{
					goto IL_02f2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rax_v37 (System.Object)+10]");
				object obj2 = 0;
				TextMeshProUGUI spectateModePlayerName2 = _SpectateModePlayerName;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v38+20]");
				string fullNameUntranslated = ((CharacterData)0).GetFullNameUntranslated();
				spectateModePlayerName2.text = fullNameUntranslated;
				object obj3 = default(object);
				object arg = (CharacterType)obj3;
				paramsArray = new System.ParamsArray(arg);
				object obj4 = default(object);
				string message = string.FormatHelper((IFormatProvider)null, "Couldn't get playerInfo for player using character {0}, maybe they disconnected?", (System.ParamsArray)(&obj4));
				Debug.LogWarning(message);
				spectateModePlayerName = _SpectateModePlayerName;
				paramsArray = (System.ParamsArray)0;
			}
			Color coopColour = items[num].GetCoopColour();
			spectateModePlayerName.color = (Color)(&paramsArray);
			TextMeshProUGUI spectateModePlayerName3 = _SpectateModePlayerName;
			if (((TMP_Text)spectateModePlayerName3).m_HorizontalAlignment != HorizontalAlignmentOptions.Left || ((TMP_Text)spectateModePlayerName3).m_VerticalAlignment != VerticalAlignmentOptions.Geometry)
			{
				((TMP_Text)spectateModePlayerName3).m_HorizontalAlignment = HorizontalAlignmentOptions.Left;
				((TMP_Text)spectateModePlayerName3).m_VerticalAlignment = VerticalAlignmentOptions.Geometry;
				((TMP_Text)spectateModePlayerName3).m_havePropertiesChanged = true;
				spectateModePlayerName3.SetVerticesDirty();
			}
			CharacterData currentSkinData = characterController._currentSkinData;
			Sprite sprite = SpriteManager.GetSprite(currentSkinData._003CspriteName_003Ek__BackingField, currentSkinData._003CtextureName_003Ek__BackingField);
			_SpectateModeIcon.sprite = sprite;
			object obj5 = _SpectateModeIcon + 244;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A77350");
			object obj6 = default(object);
			if (obj6 != null)
			{
				_SpectateModeIcon.SetVerticesDirty();
			}
			return;
		}
		goto IL_02f2;
		IL_02f2:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	private void CheckSpectateMode()
	{
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config._003CSelectedOnlineFreeRoam_003Ek__BackingField)
			{
				GameManager core2 = GM.Core;
				List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core2._mainCharacters;
				if (mainCharacters._size <= 0)
				{
					goto IL_0265;
				}
				VampireSurvivors.Objects.Characters.CharacterController[] items = mainCharacters._items;
				VampireSurvivors.Objects.Characters.CharacterController characterController = items[0];
				if (characterController._multiplayerRevivalUI.IsVisible() && !IsSpectateModeActive())
				{
					_SpectateModeContainer.SetActive(value: true);
					bool applyParameters = default(bool);
					GameObject localParametersRoot = default(GameObject);
					string overrideLanguage = default(string);
					bool allowLocalizedParameters = default(bool);
					string translation = LocalizationManager.GetTranslation("onlineLang/DeathCameraSwitch", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
					_SpectateModeSwitchPlayerText.text = translation;
					GameManager core3 = GM.Core;
					core3._003CFreeRoamCameraTargetWhenDead_003Ek__BackingField = 0;
					ChangeSpectateTargetUi();
					return;
				}
			}
		}
		GameManager core4 = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters2 = core4._mainCharacters;
		if (mainCharacters2._size > 0)
		{
			VampireSurvivors.Objects.Characters.CharacterController[] items2 = mainCharacters2._items;
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = items2[0];
			if (!characterController2._multiplayerRevivalUI.IsVisible() && IsSpectateModeActive())
			{
				_SpectateModeContainer.SetActive(value: false);
			}
			return;
		}
		goto IL_0265;
		IL_0265:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private bool IsSpectateModeActive()
	{
		GameObject spectateModeContainer = _SpectateModeContainer;
		bool flag = ((UnityEngine.Object)spectateModeContainer).m_CachedPtr == (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 43 ConditionalJump @-1, v51 @ ZF_v5 (System.Boolean) --- -1 Nop");
		/*Error: End of method reached without returning.*/;
	}

	private void UpdateCoins()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A497E]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PlayerOptionsData config = _playerOptions.Config;
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		string text = System.Number.FormatSingle(config._003CRunCoins_003Ek__BackingField, "F0", currentInfo);
		_CoinsText.text = text;
	}

	private void ActivateGoldFever()
	{
		GoldFeverUIManager goldFever = _GoldFever;
		_GoldFever.IntroTween();
		goldFever._isActive = true;
		goldFever._003CIsGoldFeverShowing_003Ek__BackingField = true;
	}

	private void DeactivateGoldFever()
	{
		GoldFeverUIManager goldFever = _GoldFever;
		Debug.Log("HIDING GOLD FEVER");
		if (goldFever._isActive)
		{
			goldFever.ExitTween();
			goldFever._isActive = false;
		}
	}

	private unsafe void InitializeEquipment()
	{
		//IL_0018: Expected O, but got Ref
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		ForceEquipmentLayoutRebuild();
	}
}
