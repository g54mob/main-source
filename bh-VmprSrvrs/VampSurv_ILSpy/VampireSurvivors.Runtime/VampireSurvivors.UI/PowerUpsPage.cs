using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using I2.Loc;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI;

public class PowerUpsPage : BaseUIPage
{
	private sealed class _003CWaitAndGenerateNavigation_003Ed__31(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public PowerUpsPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0554: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_0528: Expected I4, but got I8
			//IL_0055: Expected I4, but got I8
			//IL_05a8: Expected I4, but got O
			//IL_0084: Expected O, but got I
			//IL_00e1: Expected O, but got I
			//IL_013c: Expected O, but got I
			//IL_016f: Expected O, but got I4
			//IL_0178: Expected O, but got I4
			//IL_0657: Expected O, but got I
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b2: Expected O, but got Unknown
			//IL_01e9: Expected O, but got I
			//IL_0244: Expected O, but got I
			//IL_0272: Expected O, but got Ref
			//IL_027b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0280: Expected O, but got Unknown
			//IL_0298: Unknown result type (might be due to invalid IL or missing references)
			//IL_029d: Expected O, but got Unknown
			//IL_02ad: Expected O, but got I
			//IL_02b6: Expected O, but got I4
			//IL_030b: Expected O, but got I
			//IL_038c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0391: Expected O, but got Unknown
			//IL_042a: Expected O, but got I
			//IL_0622: Expected O, but got I
			//IL_0438: Unknown result type (might be due to invalid IL or missing references)
			//IL_043d: Expected O, but got Unknown
			//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e1: Expected O, but got Unknown
			//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f7: Expected O, but got Unknown
			//IL_0500: Unknown result type (might be due to invalid IL or missing references)
			//IL_0505: Expected O, but got Unknown
			//IL_050e: Expected O, but got I4
			//IL_046d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0472: Expected O, but got Unknown
			BaseUIPage baseUIPage = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj != 1)
					{
						return false;
					}
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+170]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+170]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rax_v20+18]");
							if ((nint)0 <= (nint)0)
							{
								goto IL_05a8;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rax_v20+10]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rax_v20+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rcx_v17+20]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rcx_v17+20]");
									Selectable component = ((Component)0).GetComponent<Selectable>();
									if ((object)component != null)
									{
										component.Select();
										object obj4 = 1;
										object obj5 = 0;
										object obj10 = default(object);
										Component component3 = default(Component);
										Component component5 = default(Component);
										Component component7 = default(Component);
										Component component8 = default(Component);
										while (true)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+170]");
											object obj6 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+170]");
											if ((nint)0 == 0)
											{
												break;
											}
											object obj7 = obj5;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rax_v28+18]");
											if ((nint)obj7 < 0)
											{
												object obj8 = obj4 - 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rax_v28+18]");
												if ((nint)obj8 < 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rax_v28+10]");
													object obj9 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rax_v28+10]");
													if ((nint)0 == 0)
													{
														break;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ rcx_v24+18+v343 @ rdi_v7*8]");
													if ((nint)0 == 0)
													{
														break;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ rcx_v24+18+v343 @ rdi_v7*8]");
													Button component2 = ((Component)0).GetComponent<Button>();
													if ((object)component2 == null)
													{
														break;
													}
													component2.navigation = (Navigation)(&obj10);
													object obj11 = obj4 - 2;
													bool flag2 = (nint)obj11 < 0;
													object obj12 = obj4 - 2;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+170]");
													object obj13 = 0;
													object obj14 = 0;
													if (!flag2)
													{
														obj14 = obj12;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+170]");
													if ((nint)0 == 0)
													{
														break;
													}
													object obj15 = obj4;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v36+18]");
													if ((nint)obj15 >= 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v36+18]");
														object obj16 = -1;
													}
													else
													{
														object obj16 = obj4;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
													if ((object)component3 == null)
													{
														break;
													}
													Selectable component4 = component3.GetComponent<Selectable>();
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+170]");
													if ((nint)0 == 0)
													{
														break;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
													if ((object)component5 == null)
													{
														break;
													}
													Selectable component6 = component5.GetComponent<Selectable>();
													object obj17 = obj4 - 5;
													Selectable target;
													if ((nint)obj17 >= 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+170]");
														if ((nint)0 == 0)
														{
															break;
														}
														object obj18 = obj4 - 5;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
														if ((object)component7 == null)
														{
															break;
														}
														target = component7.GetComponent<Selectable>();
													}
													else
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+138]");
														target = (Selectable)0;
													}
													_003C_003E4__this.SetNavigationUp(component2, target);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+170]");
													object obj19 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+170]");
													if ((nint)0 == 0)
													{
														break;
													}
													object obj20 = obj4 + 3;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rcx_v35+18]");
													if ((nint)obj20 < 0)
													{
														object obj21 = obj4 + 3;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
														if ((object)component8 == null)
														{
															break;
														}
														Selectable component9 = component8.GetComponent<Selectable>();
														_003C_003E4__this.SetNavigationDown(component2, component9);
													}
													_003C_003E4__this.SetNavigationLeft(component2, component4);
													_003C_003E4__this.SetNavigationRight(component2, component6);
													obj4++;
													obj5 = obj4 - 1;
													obj10 = 4;
													continue;
												}
												goto IL_05a8;
											}
											return false;
										}
									}
								}
							}
						}
					}
					goto IL_059a;
				}
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			}
			_003C_003E1__state = -1;
			_003C_003E2__current = null;
			_003C_003E1__state = 1;
			return true;
			IL_05a8:
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			goto IL_059a;
			IL_059a:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
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

	private Localize Name;

	private Localize Description;

	private Image Icon;

	private PriceUI Price;

	private GameObject PowerUpPrefab;

	private GameObject BuyButton;

	private GameObject CompleteText;

	private Image Background;

	private Color MaxColor;

	private Image _Frame;

	private Button _RefundButton;

	private TickBoxUI _ActiveTickBox;

	private PlayerOptions _playerOptions;

	private DataManager _dataManager;

	private PlayerStats _playerStats;

	private SignalBus _signalBus;

	private PowerUpItemUI _selected;

	private List<PowerUpItemUI> _spawned;

	private Dictionary<PowerUpType, List<PowerUpData>> rawPowerUpData;

	private List<PowerUpType> _shownPowerUps;

	private void Construct(PlayerOptions playerOptions, DataManager dataManager, PlayerStats playerStats, SignalBus signal)
	{
		_playerOptions = playerOptions;
		_dataManager = dataManager;
		_playerStats = playerStats;
		SignalBus signalBus = default(SignalBus);
		_signalBus = signalBus;
	}

	protected override void OnShowStart(GameObject g)
	{
		base.OnShowStart(g);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 11 Invalid \"Jump target not found in method: 0x186D5FB40\"");
	}

	private unsafe void Populate()
	{
		//IL_0068: Expected O, but got Ref
		Reset();
		Dictionary<PowerUpType, PlayerStat> ownedPowerUps = _playerStats.GetOwnedPowerUps();
		Dictionary<PowerUpType, List<PowerUpData>> convertedPowerUpData = _dataManager.GetConvertedPowerUpData();
		rawPowerUpData = convertedPowerUpData;
		Dictionary<PowerUpType, List<PowerUpData>>.Enumerator enumerator = default(Dictionary<PowerUpType, List<PowerUpData>>.Enumerator);
		if (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			PowerUpType powerUpType = PowerUpType.POWER;
			Dictionary<PowerUpType, List<PowerUpData>>.Enumerator enumerator2 = (Dictionary<PowerUpType, List<PowerUpData>>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		RectTransform component = GetComponent<RectTransform>();
		LayoutRebuilder.ForceRebuildLayoutImmediate(component);
		Canvas.ForceUpdateCanvases();
		_003CWaitAndGenerateNavigation_003Ed__31 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private void CreatePowerUp(PowerUpData dat, PowerUpType type, int level, int maxRank)
	{
		//IL_0122: Expected O, but got I
		//IL_017c: Expected O, but got I
		GameObject gameObject = UnityEngine.Object.Instantiate(PowerUpPrefab, _content);
		PowerUpItemUI component = gameObject.GetComponent<PowerUpItemUI>();
		int currentLevel = default(int);
		int maxRank2 = default(int);
		component.SetData(dat, type, this, currentLevel, maxRank2);
		List<object> spawned = (List<object>)(object)_spawned;
		int version = spawned._version + 1;
		spawned._version = version;
		object[] items = spawned._items;
		if (spawned._size >= items.Length)
		{
			spawned.AddWithResize((object)component);
		}
		else
		{
			int size = spawned._size + 1;
			spawned._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		List<System.Int32Enum> shownPowerUps = (List<System.Int32Enum>)(object)_shownPowerUps;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rcx_v11 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rcx_v11 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rcx_v11 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r8_v7+18]");
		if (num >= 0)
		{
			shownPowerUps.AddWithResize((System.Int32Enum)type);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rcx_v11 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj2 = (nint)0 + (nint)1;
	}

	public bool CheckIfDisabled(PowerUpType type)
	{
		//IL_0070: Expected I4, but got O
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null && config._003CDisabledPowerups_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A980C0");
				bool result = default(bool);
				return result;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void Purchase(PowerUpData data, PowerUpType type, PowerUpItemUI item)
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_0205: Expected O, but got I
		//IL_0122: Expected F4, but got I4
		float price = _playerStats.GetPrice(type);
		PlayerOptionsData config = _playerOptions.Config;
		if (!(price > config._003CCoins_003Ek__BackingField))
		{
			if (item.UpdateAfterPurchase())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
				object obj2 = default(object);
				object obj = obj2 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				IntPtr intPtr = default(IntPtr);
				num = intPtr;
				PowerUpType powerUpType = default(PowerUpType);
				object signal = (nint)powerUpType;
				bool flag = default(bool);
				_signalBus.InternalFire((Type)num, signal, (object)null, flag);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm6\"");
				_playerOptions.RemoveCoins((int)num);
				SetInfo(data, type, item);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, flag ? 1 : 0);
				return;
			}
		}
		else if (item._currentLevel < item._maxRank)
		{
			return;
		}
		if (type <= PowerUpType.SEAL3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"bt eax,esi\"");
			if (type < PowerUpType.SEAL3)
			{
				return;
			}
		}
		if (type != PowerUpType.SEAL4)
		{
			ToggleActive();
			SetInfo(data, type, item);
		}
	}

	private bool IsTogglablePowerup(PowerUpType type)
	{
		//IL_005b: Expected O, but got I4
		if (type <= PowerUpType.SEAL3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"bt eax,edx\"");
			if (type < PowerUpType.SEAL3)
			{
				return false;
			}
		}
		object obj = type - 29;
		bool flag = obj == null;
		return !flag;
	}

	public void ToggleActive()
	{
		TickBoxUI activeTickBox = _ActiveTickBox;
		bool isOn = !activeTickBox.isOn;
		activeTickBox.isOn = isOn;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A2F7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string text = "False";
		if (!activeTickBox.isOn)
		{
			text = "True";
		}
		string message = "Is On : " + text;
		Debug.Log(message);
		if (!activeTickBox.isOn)
		{
			activeTickBox.SetOff();
		}
		else
		{
			activeTickBox.SetOn();
		}
	}

	public unsafe void OnActiveToggled(bool b)
	{
		//IL_0066: Expected O, but got Ref
		//IL_002f: Expected O, but got Ref
		//IL_003f: Expected O, but got I
		//IL_004f: Expected O, but got I
		//IL_008a: Expected I, but got O
		//IL_0097: Expected O, but got Ref
		//IL_019a: Expected O, but got Ref
		//IL_011e: Expected O, but got Ref
		PowerUpItemUI selected = _selected;
		Color color = default(Color);
		if (!b)
		{
			selected.Background.color = (Color)(&color);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12250]");
			Color color2 = (Color)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12250]");
			color = (Color)0;
		}
		else
		{
			selected.Background.color = (Color)(&color);
			Color color2 = MaxColor;
			color = selected.MaxColor;
		}
		Image background = Background;
		nint num = (nint)background;
		background.color = (Color)(&color);
		PowerUpItemUI selected2 = _selected;
		string text;
		string text2;
		if (!b)
		{
			PlayerOptionsData config = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A980C0");
			object obj = default(object);
			if (obj != null)
			{
				return;
			}
			PlayerOptionsData config2 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A98130");
			text = ((Enum)(&color)).ToString();
			text2 = "Disabling ";
		}
		else
		{
			PlayerOptionsData config3 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A980C0");
			object obj2 = default(object);
			if (obj2 == null)
			{
				return;
			}
			PlayerOptionsData config4 = _playerOptions.Config;
			bool flag = ((List<System.Int32Enum>)(object)config4._003CDisabledPowerups_003Ek__BackingField).Remove((System.Int32Enum)selected2._type);
			text = ((Enum)(&color)).ToString();
			text2 = "Enabling ";
		}
		string message = text2 + text;
		Debug.Log(message);
	}

	public void PurchaseSelected()
	{
		PowerUpItemUI selected = _selected;
		if ((object)_selected != null && ((UnityEngine.Object)selected).m_CachedPtr != (IntPtr)0)
		{
			PowerUpItemUI selected2 = _selected;
			Purchase(selected2._data, selected2._type, _selected);
			EventSystem current = EventSystem.current;
			GameObject selectedGameObject = _selected.gameObject;
			current.SetSelectedGameObject(selectedGameObject);
		}
	}

	public PowerUpItemUI GetCurrentSelected()
	{
		return _selected;
	}

	private IEnumerator WaitAndGenerateNavigation()
	{
		_003CWaitAndGenerateNavigation_003Ed__31 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public void ResetAll()
	{
		List<PowerUpItemUI>.Enumerator enumerator = default(List<PowerUpItemUI>.Enumerator);
		if (enumerator.MoveNext())
		{
			throw new NullReferenceException();
		}
		PlayerOptions playerOptions = _playerOptions;
		PlayerOptionsData playerOptionsData;
		if (playerOptions._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions._hostGameConfig == null)
			{
				if (playerOptions._currentAdventureSaveData != null)
				{
					playerOptionsData = playerOptions._currentAdventureSaveData;
					if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_0165;
					}
				}
				playerOptionsData = playerOptions._mainGameConfig;
			}
			else
			{
				playerOptionsData = playerOptions._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
		}
		goto IL_0165;
		IL_0165:
		List<PowerUpType> list = playerOptionsData._003CDisabledPowerups_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
	}

	public unsafe void SetInfo(PowerUpData data, PowerUpType type, PowerUpItemUI itemUI)
	{
		//IL_01de: Expected O, but got I
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Expected O, but got Unknown
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Expected I4, but got Unknown
		//IL_03f1: Expected O, but got Ref
		//IL_043b: Expected O, but got I
		//IL_0528: Unknown result type (might be due to invalid IL or missing references)
		//IL_052d: Expected I4, but got Unknown
		//IL_047a: Expected O, but got Ref
		//IL_09c3: Expected O, but got Ref
		//IL_04e6: Expected O, but got I
		//IL_06ec: Expected I4, but got O
		//IL_064b: Expected I4, but got O
		//IL_0a83: Expected I4, but got O
		//IL_07ce: Expected I4, but got O
		//IL_0b36: Expected I4, but got O
		//IL_0a9d->IL08cb: Incompatible stack heights: 1 vs 0
		//IL_077a->IL08cb: Incompatible stack heights: 1 vs 0
		//IL_0af1->IL08cb: Incompatible stack heights: 2 vs 0
		//IL_07b0->IL08cb: Incompatible stack heights: 2 vs 0
		//IL_07e8->IL08cb: Incompatible stack heights: 2 vs 0
		//IL_081d->IL08cb: Incompatible stack heights: 2 vs 0
		//IL_0b50->IL08cb: Incompatible stack heights: 3 vs 0
		//IL_085c->IL08cb: Incompatible stack heights: 3 vs 0
		//IL_0ba3->IL08cb: Incompatible stack heights: 4 vs 0
		//IL_08a1->IL08cb: Incompatible stack heights: 4 vs 0
		bool flag3;
		PlayerStat playerStat;
		Color ret = default(Color);
		if (data != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C7B]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			string prefix = data.GetPrefix(type);
			string term = prefix + "name";
			if ((object)Name != null)
			{
				Name.Term = term;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C7C]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				string prefix2 = data.GetPrefix(type);
				string term2 = prefix2 + "description";
				if ((object)Description != null)
				{
					Description.Term = term2;
					Sprite sprite = SpriteManager.GetSprite(data._003CframeName_003Ek__BackingField, data._003Ctexture_003Ek__BackingField);
					if ((object)Icon != null)
					{
						Icon.sprite = sprite;
						if (_playerStats != null)
						{
							float price = _playerStats.GetPrice(type);
							if ((object)Price != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
								float price2 = default(float);
								Price.SetPrice(price2);
								PlayerStats playerStats = _playerStats;
								if (_playerStats != null && playerStats._stats != null)
								{
									object obj = ((Dictionary<System.Int32Enum, object>)(object)playerStats._stats).get_Item((System.Int32Enum)type);
									if (obj != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rax_v37 (System.Object)+14]");
										object obj2 = -data._003CunlockedRank_003Ek__BackingField;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rax_v37 (System.Object)+14]");
										int num = (int)((nint)0 ^ (nint)data._003CunlockedRank_003Ek__BackingField);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rax_v37 (System.Object)+14]");
										object obj3 = 0 ^ obj2;
										int num2 = num & obj3;
										bool flag = num2 < 0;
										bool flag2 = (nint)obj2 < 0;
										flag3 = flag2 == flag;
										if (_playerOptions != null)
										{
											PlayerOptionsData config = _playerOptions.Config;
											if (config != null && config._003CDisabledPowerups_003Ek__BackingField != null)
											{
												playerStat = ((Dictionary<PowerUpType, PlayerStat>)(object)config._003CDisabledPowerups_003Ek__BackingField).get_Item(type);
												if ((object)Price != null)
												{
													GameObject gameObject = Price.gameObject;
													if ((object)gameObject != null)
													{
														bool active = (byte)((flag3 ? 1u : 0u) ^ 1u) != 0;
														gameObject.SetActive(active);
														if ((object)BuyButton != null)
														{
															bool active2 = (byte)((flag3 ? 1u : 0u) ^ 1u) != 0;
															BuyButton.SetActive(active2);
															if ((object)_ActiveTickBox != null)
															{
																GameObject gameObject2 = _ActiveTickBox.gameObject;
																if ((object)gameObject2 != null)
																{
																	gameObject2.SetActive(flag3);
																	if ((object)Background != null)
																	{
																		Background.color = (Color)(&ret);
																		if ((object)CompleteText != null)
																		{
																			CompleteText.SetActive(value: false);
																			bool flag4 = !flag3;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
																			ret = (Color)0;
																			if (flag4)
																			{
																				goto IL_0973;
																			}
																			if (playerStat != null)
																			{
																			}
																			if ((object)Background != null)
																			{
																				Background.color = (Color)(&ret);
																				if ((object)itemUI != null)
																				{
																					if (playerStat != null)
																					{
																						if ((object)itemUI.Background == null)
																						{
																							goto IL_08cb;
																						}
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12250]");
																						ret = (Color)0;
																					}
																					else
																					{
																						if ((object)itemUI.Background == null)
																						{
																							goto IL_08cb;
																						}
																						ret = itemUI.MaxColor;
																					}
																					itemUI.Background.color = (Color)(&ret);
																					goto IL_0973;
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
		}
		goto IL_08cb;
		IL_0973:
		if ((object)_ActiveTickBox == null)
		{
			goto IL_08cb;
		}
		bool b = (byte)(playerStat ^ 1) != 0;
		_ActiveTickBox.InitialSet(b);
		if (type <= PowerUpType.SEAL3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"bt eax,edi\"");
			if (type < PowerUpType.SEAL3)
			{
				goto IL_05a0;
			}
		}
		if (type == PowerUpType.SEAL4)
		{
			goto IL_05a0;
		}
		goto IL_09c8;
		IL_09c8:
		string spriteName = (data._003CisSpecial_003Ek__BackingField ? "FrameE" : "FrameD");
		Sprite sprite2 = SpriteManager.GetSprite(spriteName, "UI");
		if ((object)_Frame != null)
		{
			_Frame.sprite = sprite2;
			if ((object)_Frame != null)
			{
				RectTransform rectTransform = _Frame.rectTransform;
				PowerUpType powerUpType = (PowerUpType)_Frame;
				if ((object)_Frame != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rdi_v13 (VampireSurvivors.Data.PowerUpType)+E0]");
					PowerUpType powerUpType2 = PowerUpType.POWER;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rdi_v13 (VampireSurvivors.Data.PowerUpType)+E0]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rdi_v14 (VampireSurvivors.Data.PowerUpType)+10]");
						bool flag5 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rdi_v14 (VampireSurvivors.Data.PowerUpType)+10]");
						Sprite.get_rect_Injected((IntPtr)0, out Rect ret2);
						PowerUpType powerUpType3 = (PowerUpType)_Frame;
						if ((object)_Frame != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rdi_v15 (VampireSurvivors.Data.PowerUpType)+E0]");
							PowerUpType powerUpType4 = PowerUpType.POWER;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rdi_v15 (VampireSurvivors.Data.PowerUpType)+E0]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rdi_v16 (VampireSurvivors.Data.PowerUpType)+10]");
								bool flag6 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rdi_v16 (VampireSurvivors.Data.PowerUpType)+10]");
								Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)(&ret));
								if ((object)rectTransform != null)
								{
									Vector2 sizeDelta = default(Vector2);
									rectTransform.sizeDelta = sizeDelta;
									if ((object)Icon != null)
									{
										RectTransform rectTransform2 = Icon.rectTransform;
										PowerUpType powerUpType5 = (PowerUpType)Icon;
										if ((object)Icon != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rdi_v17 (VampireSurvivors.Data.PowerUpType)+E0]");
											PowerUpType powerUpType6 = PowerUpType.POWER;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rdi_v17 (VampireSurvivors.Data.PowerUpType)+E0]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rdi_v18 (VampireSurvivors.Data.PowerUpType)+10]");
												bool flag7 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rdi_v18 (VampireSurvivors.Data.PowerUpType)+10]");
												Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)(&ret));
												PowerUpType powerUpType7 = (PowerUpType)Icon;
												if ((object)Icon != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rdi_v19 (VampireSurvivors.Data.PowerUpType)+E0]");
													PowerUpType powerUpType8 = PowerUpType.POWER;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rdi_v19 (VampireSurvivors.Data.PowerUpType)+E0]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rdi_v20 (VampireSurvivors.Data.PowerUpType)+10]");
														bool flag8 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rdi_v20 (VampireSurvivors.Data.PowerUpType)+10]");
														Sprite.get_rect_Injected((IntPtr)0, out ret2);
														if ((object)rectTransform2 != null)
														{
															rectTransform2.sizeDelta = sizeDelta;
															_selected = itemUI;
															if ((object)_selected != null)
															{
																SetNavigationDown(target: _selected.GetComponent<Button>(), origin: _RefundButton);
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
		}
		goto IL_08cb;
		IL_08cb:
		throw new NullReferenceException();
		IL_05a0:
		if (flag3)
		{
			if ((object)_ActiveTickBox != null)
			{
				GameObject gameObject3 = _ActiveTickBox.gameObject;
				if ((object)gameObject3 != null)
				{
					gameObject3.SetActive(value: false);
					if ((object)CompleteText != null)
					{
						CompleteText.SetActive(value: true);
						PowerUpType powerUpType9 = (PowerUpType)Background;
						Color color = ColourHelper.HexToColor("FFF47C");
						if ((object)Background != null)
						{
							int value__ = ((PowerUpType*)(int)powerUpType9)->value__;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1344 @ r9_v16 (System.Int32)+2A8] (should have been resolved before IL gen)");
							goto IL_09c8;
						}
					}
				}
			}
			goto IL_08cb;
		}
		goto IL_09c8;
	}

	public void RefundPowerUps()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0940");
		ResetAll();
		_playerStats.Reset();
		PowerUpItemUI selected = _selected;
		SetInfo(selected._data, selected._type, _selected);
	}

	public void Reset()
	{
		//IL_0039->IL0125: Incompatible stack heights: 1 vs 0
		if (_spawned != null)
		{
			List<PowerUpItemUI>.Enumerator enumerator = default(List<PowerUpItemUI>.Enumerator);
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
			List<PowerUpItemUI> spawned = _spawned;
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

	protected override void OnEnterPressed()
	{
		PowerUpItemUI selected = _selected;
		if ((object)_selected == null || ((UnityEngine.Object)selected).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		EventSystem current = EventSystem.current;
		if ((object)current == null || ((UnityEngine.Object)current).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		EventSystem current2 = EventSystem.current;
		GameObject currentSelected = current2.m_CurrentSelected;
		if ((object)current2.m_CurrentSelected != null && ((UnityEngine.Object)currentSelected).m_CachedPtr != (IntPtr)0)
		{
			EventSystem current3 = EventSystem.current;
			PowerUpItemUI component = current3.m_CurrentSelected.GetComponent<PowerUpItemUI>();
			if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
			{
				PowerUpItemUI selected2 = _selected;
				Purchase(selected2._data, selected2._type, _selected);
			}
		}
	}

	public PowerUpsPage()
	{
		List<PowerUpItemUI> spawned = new List<PowerUpItemUI>();
		_spawned = spawned;
		rawPowerUpData = new Dictionary<PowerUpType, List<PowerUpData>>();
		_shownPowerUps = new List<PowerUpType>();
		base._002Ector();
	}
}
