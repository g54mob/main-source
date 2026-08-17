using System;
using System.Collections.Generic;
using System.Linq;
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
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors;

public class WeaponSelectionPage : BaseWeaponSelectionPage
{
	private sealed class _003C_003Ec__DisplayClass27_0
	{
		public WeaponType v;

		internal bool _003CGetEvolvedWeapons_003Eb__0(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - v;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CGetEvolvedWeapons_003Eb__1(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - v;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private RectTransform _Container;

	private GameObject _WeaponPrefab;

	private RectTransform _Panel;

	private RectTransform _SkipButton;

	private SpriteReel _LeftBanner;

	private SpriteReel _RightBanner;

	private PlayerOptions _playerOptions;

	private DataManager _dataManager;

	private SignalBus _signalBus;

	private Dictionary<WeaponType, List<WeaponData>> _weapons;

	private WeaponType _currentType;

	private List<WeaponSelectionItemUI> _spawned;

	private bool _hasSelected;

	private VampireSurvivors.Objects.Characters.CharacterController _targetCharacter;

	private void Construct(PlayerOptions player, DataManager data, SignalBus signalBus)
	{
		//IL_0099: Expected O, but got I4
		//IL_0099: Expected O, but got I
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_01b4: Expected O, but got I
		//IL_0145: Expected O, but got I4
		//IL_0145: Expected O, but got I
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_01ef: Expected O, but got I
		_playerOptions = player;
		DataManager dataManager = default(DataManager);
		_dataManager = dataManager;
		_signalBus = signalBus;
		Action<OnlineSignals.SelectCandyBoxWeapon> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE8E0");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.SelectCandyBoxWeapon>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.SelectCandyBoxWeapon>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus2 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rax_v16 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus2.SubscribeInternal(signalType, (object)null, (object)0, callback);
		Action action3 = OnWeaponSkippedRemotely;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rbx_v8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj4 = null;
		Action<object> action4 = ((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.SkipCandyBox>)obj4)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.SkipCandyBox>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus3 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rax_v31 (System.Object)+10]");
		Type signalType2 = default(Type);
		signalBus3.SubscribeInternal(signalType2, (object)null, (object)0, callback);
	}

	private void OnWeaponSkippedRemotely()
	{
		RemoveCandyBox();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1D00");
		ExitMultiplayerControl();
	}

	private unsafe void OnWeaponSelectedRemotely(OnlineSignals.SelectCandyBoxWeapon weapon)
	{
		//IL_002c: Expected I4, but got O
		//IL_004c: Expected O, but got Ref
		//IL_001d: Expected I4, but got O
		object obj = default(object);
		object arg = (WeaponType)obj;
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj2 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "CandyBox Weapon Was Selected Remotely {0}", (System.ParamsArray)(&obj2));
		Debug.Log(message);
		ExecuteWeaponSelection((WeaponType)weapon);
	}

	public override void SetSelected(WeaponSelectionItemUI item)
	{
		_currentType = item._type;
	}

	public override void SelectWeapon(WeaponSelectionItemUI item)
	{
		if (!_hasSelected)
		{
			_hasSelected = true;
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				ExecuteWeaponSelection(item._type);
				return;
			}
			OnlineStageManager instance = OnlineStageManager._instance;
			Action<long, int> action = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5A20");
			long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
			int param = default(int);
			bool flag = instance._sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame, param);
		}
	}

	public void Skip()
	{
		//IL_008f: Expected I8, but got O
		//IL_00a7: Expected I8, but got O
		//IL_0068: Expected O, but got I
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			RemoveCandyBox();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1D00");
			ExitMultiplayerControl();
			return;
		}
		long num = (long)OnlineStageManager._instance;
		Action<long> action = null;
		((OnlineStageManager)(object)action).CandyBoxSkip((long)OnlineStageManager._instance);
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rbx_v3 (System.Int64)+78]");
		bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	protected unsafe override void OnShowStart(GameObject g)
	{
		//IL_001d: Expected I8, but got I4
		//IL_00cf: Expected O, but got I
		//IL_0429: Expected I8, but got I4
		//IL_019d: Expected I8, but got I
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected Ref, but got Unknown
		//IL_02b6: Expected I8, but got I
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Expected Ref, but got Unknown
		//IL_03bc: Expected I8, but got I
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Expected Ref, but got Unknown
		//IL_0595: Expected O, but got I4
		//IL_059d: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a2: Expected O, but got Unknown
		//IL_06ec: Expected O, but got I4
		//IL_072d: Expected O, but got I4
		//IL_060c->IL089a: Incompatible stack heights: 11 vs 8
		base.OnShowStart(g);
		GameManager core = GM.Core;
		ulong num2;
		ulong num;
		if ((object)GM.Core != null)
		{
			_targetCharacter = core._003CEnterWeaponSelectionPlayer_003Ek__BackingField;
			num = 0uL;
			GameManager core2 = GM.Core;
			if ((object)GM.Core != null)
			{
				CoopConfig coopConfig = core2.CoopConfig;
				if ((object)core2.CoopConfig != null)
				{
					EnterMultiplayerControl(_targetCharacter, coopConfig._levelupVibrationMilliseconds);
					Clear();
					GameObject core3 = (GameObject)(object)GM.Core;
					if ((object)GM.Core != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdi_v13 (UnityEngine.GameObject)+360]");
						GameObject gameObject = (GameObject)0;
						object obj = "normal";
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdi_v13 (UnityEngine.GameObject)+360]");
						if (0 != unchecked((nint)"normal"))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdi_v13 (UnityEngine.GameObject)+360]");
							if ((nint)0 != 0 && "normal" != null)
							{
								IntPtr cachedPtr = ((UnityEngine.Object)gameObject).m_CachedPtr;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rdx_v24+10]");
								if (cachedPtr == (IntPtr)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdi_v13 (UnityEngine.GameObject)+360]");
									ref byte first = ref *(byte*)((nint)0 + (nint)20);
									num = (ulong)((nint)((UnityEngine.Object)gameObject).m_CachedPtr + (nint)((UnityEngine.Object)gameObject).m_CachedPtr);
									if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("normal" + 20), num))
									{
										goto IL_0419;
									}
								}
							}
							object obj2 = "passive";
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdi_v13 (UnityEngine.GameObject)+360]");
							if (0 != unchecked((nint)"passive"))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdi_v13 (UnityEngine.GameObject)+360]");
								bool flag = (nint)0 == 0;
								num2 = num;
								if (!flag)
								{
									bool flag2 = "passive" == null;
									num2 = num;
									if (!flag2)
									{
										IntPtr cachedPtr2 = ((UnityEngine.Object)gameObject).m_CachedPtr;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rdx_v42+10]");
										bool flag3 = cachedPtr2 != (IntPtr)0;
										num2 = num;
										if (!flag3)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdi_v13 (UnityEngine.GameObject)+360]");
											ref byte first2 = ref *(byte*)((nint)0 + (nint)20);
											num2 = (ulong)((nint)((UnityEngine.Object)gameObject).m_CachedPtr + (nint)((UnityEngine.Object)gameObject).m_CachedPtr);
											bool flag4 = System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("passive" + 20), num2);
											num = num2;
											if (flag4)
											{
												goto IL_040d;
											}
										}
									}
								}
								object obj3 = "evo";
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdi_v13 (UnityEngine.GameObject)+360]");
								if (0 != unchecked((nint)"evo"))
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdi_v13 (UnityEngine.GameObject)+360]");
									if ((nint)0 != 0 && "evo" != null)
									{
										IntPtr cachedPtr3 = ((UnityEngine.Object)gameObject).m_CachedPtr;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rdx_v46+10]");
										if (cachedPtr3 == (IntPtr)0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdi_v13 (UnityEngine.GameObject)+360]");
											ref byte first3 = ref *(byte*)((nint)0 + (nint)20);
											num2 = (ulong)((nint)((UnityEngine.Object)gameObject).m_CachedPtr + (nint)((UnityEngine.Object)gameObject).m_CachedPtr);
											if (System.SpanHelpers.SequenceEqual(ref first3, ref *(byte*)("evo" + 20), num2))
											{
												goto IL_03fa;
											}
										}
									}
									Exception ex = new Exception("WeaponSelectionPage.cs - missing valid weapon selection type");
									ex._002Ector("WeaponSelectionPage.cs - missing valid weapon selection type");
									throw ex;
								}
								goto IL_03fa;
							}
							goto IL_040d;
						}
						goto IL_0419;
					}
				}
			}
		}
		goto IL_076a;
		IL_076a:
		throw new NullReferenceException();
		IL_03fa:
		GetEvolvedWeapons();
		num = num2;
		goto IL_042e;
		IL_042e:
		if ((object)_Panel != null)
		{
			Transform transform = _Panel.transform;
			if ((object)transform != null)
			{
				bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				float ret;
				Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
				bool flag6 = (object)_Panel == null;
				Transform transform2 = _Panel.transform;
				bool flag7 = (object)transform2 == null;
				bool flag8 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
				bool flag9 = (object)_Panel == null;
				Transform target = _Panel.transform;
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScaleX(target, ret, 0.15f);
				GameObject skipButton = (GameObject)(object)_SkipButton;
				bool flag10 = (object)_SkipButton == null;
				bool flag11 = ((UnityEngine.Object)skipButton).m_CachedPtr == (IntPtr)0;
				Transform.SetAsLastSibling_Injected(((UnityEngine.Object)skipButton).m_CachedPtr);
				List<WeaponSelectionItemUI> spawned = _spawned;
				bool flag12 = _spawned == null;
				int num3 = spawned._size ^ spawned._size;
				int num4 = spawned._size & num3;
				bool flag13 = num4 < 0;
				bool flag14 = spawned._size < 0;
				bool flag15 = spawned._size == 0;
				Component component;
				if (!flag15)
				{
					bool flag16 = flag14 == flag13;
					object obj4 = !flag16;
					object obj5 = obj4 | flag15;
					WeaponSelectionItemUI[] items = spawned._items;
					bool flag17 = spawned._items == null;
					bool flag18 = items.Length <= 0;
					component = items[0];
				}
				else
				{
					component = _SkipButton;
				}
				bool flag19 = (object)component == null;
				Selectable component2 = component.GetComponent<Selectable>();
				bool flag20 = (object)component2 == null;
				component2.Select();
				bool flag21 = (object)_SkipButton == null;
				GameObject gameObject2 = _SkipButton.gameObject;
				bool active = IsLocalPlayerControllingUi();
				bool flag22 = (object)gameObject2 == null;
				gameObject2.SetActive(active);
				_hasSelected = false;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LevelUp, new SoundManager.SoundConfig
				{
					Rate = 1f,
					Detune = -200f,
					Volume = (float?)(object)1
				}, 0f, 10, time);
				PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.LevelUp, new SoundManager.SoundConfig
				{
					Volume = (float?)(object)1,
					Rate = 1f,
					Detune = -1500f
				}, 0f, 10, time);
				return;
			}
		}
		goto IL_076a;
		IL_0419:
		GetBaseWeapons();
		num = 0uL;
		goto IL_042e;
		IL_040d:
		GetPassiveWeapons();
		goto IL_042e;
	}

	protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
	{
		return _targetCharacter;
	}

	private void ExecuteSkip()
	{
		RemoveCandyBox();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1D00");
		ExitMultiplayerControl();
	}

	private unsafe void ExecuteWeaponSelection(WeaponType weapon)
	{
		//IL_00a1: Expected O, but got I
		//IL_010e: Expected O, but got I
		_currentType = weapon;
		RemoveCandyBox();
		DataManager dataManager = _dataManager;
		if (_dataManager != null)
		{
			Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
			if (convertedWeapons != null)
			{
				object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)_currentType);
				bool flag = obj == null;
				dataManager = (DataManager)(object)convertedWeapons;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rax_v15 (System.Object)+18]");
					if ((nint)0 <= (nint)0)
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rax_v15 (System.Object)+10]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rax_v15 (System.Object)+10]");
					bool flag2 = (nint)0 == 0;
					dataManager = (DataManager)(object)convertedWeapons;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v16+18]");
						bool flag3 = (nint)0 <= (nint)0;
						dataManager = (DataManager)(object)convertedWeapons;
						if (flag3)
						{
							throw new IndexOutOfRangeException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v16+20]");
						dataManager = (DataManager)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v16+20]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rcx_v23 (VampireSurvivors.Data.DataManager)+101]");
							VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
							if ((nint)0 == 0)
							{
								if (SignalBus != null)
								{
									List<WeaponData> list = ((Dictionary<WeaponType, List<WeaponData>>)(object)SignalBus).get_Item((WeaponType)(int)(&characterController));
									goto IL_01d4;
								}
							}
							else if (SignalBus != null)
							{
								List<WeaponData> list2 = ((Dictionary<WeaponType, List<WeaponData>>)(object)SignalBus).get_Item((WeaponType)(int)(&characterController));
								goto IL_01d4;
							}
						}
					}
				}
			}
		}
		goto IL_0246;
		IL_0246:
		throw new NullReferenceException();
		IL_01d4:
		if (_spawned != null)
		{
			List<WeaponSelectionItemUI>.Enumerator enumerator = default(List<WeaponSelectionItemUI>.Enumerator);
			if (enumerator.MoveNext())
			{
				Component component = null;
				throw new NullReferenceException();
			}
			ExitMultiplayerControl();
			return;
		}
		goto IL_0246;
	}

	private unsafe void GetBaseWeapons(List<WeaponType> weaponList = null)
	{
		//IL_0051: Expected O, but got I4
		//IL_0059: Expected O, but got Ref
		List<WeaponType> list = new List<WeaponType>();
		List<WeaponType> list2 = new List<WeaponType>();
		List<WeaponType> list3 = new List<WeaponType>();
		List<WeaponType> list4 = new List<WeaponType>();
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
		Dictionary<WeaponType, List<WeaponData>> dictionary = convertedWeapons;
		Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator3 = default(Dictionary<WeaponType, List<WeaponData>>.Enumerator);
		object obj2 = default(object);
		while (enumerator3.MoveNext())
		{
			if (weaponList != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
				if (obj2 == null)
				{
					continue;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)weaponList;
			throw new NullReferenceException();
		}
	}

	private unsafe void GetPassiveWeapons()
	{
		//IL_0033: Expected O, but got I4
		//IL_003b: Expected O, but got Ref
		//IL_01d0: Expected O, but got Ref
		List<WeaponType> list = new List<WeaponType>();
		List<WeaponType> list2 = new List<WeaponType>();
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
		Dictionary<WeaponType, List<WeaponData>> dictionary = convertedWeapons;
		Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator3 = default(Dictionary<WeaponType, List<WeaponData>>.Enumerator);
		if (enumerator3.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			WeaponType weaponType = WeaponType.VOID;
			Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator4 = (Dictionary<WeaponType, List<WeaponData>>.Enumerator)(&enumerator3);
			throw new NullReferenceException();
		}
	}

	private void AddXifYisUnlocked(WeaponType x, WeaponType y, ref List<WeaponType> list)
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
		}
	}

	private unsafe void GetEvolvedWeapons()
	{
		//IL_004b: Expected O, but got I
		//IL_00a5: Expected O, but got I
		//IL_2455: Expected O, but got I
		//IL_010f: Expected O, but got I
		//IL_2489: Expected O, but got I
		//IL_0179: Expected O, but got I
		//IL_24b1: Expected O, but got I
		//IL_01e3: Expected O, but got I
		//IL_24d9: Expected O, but got I
		//IL_024d: Expected O, but got I
		//IL_2501: Expected O, but got I
		//IL_02b7: Expected O, but got I
		//IL_2529: Expected O, but got I
		//IL_0321: Expected O, but got I
		//IL_2551: Expected O, but got I
		//IL_038b: Expected O, but got I
		//IL_2579: Expected O, but got I
		//IL_03f5: Expected O, but got I
		//IL_25a1: Expected O, but got I
		//IL_045f: Expected O, but got I
		//IL_25c9: Expected O, but got I
		//IL_04c9: Expected O, but got I
		//IL_25f1: Expected O, but got I
		//IL_0533: Expected O, but got I
		//IL_2619: Expected O, but got I
		//IL_059d: Expected O, but got I
		//IL_2641: Expected O, but got I
		//IL_0607: Expected O, but got I
		//IL_2669: Expected O, but got I
		//IL_0671: Expected O, but got I
		//IL_2691: Expected O, but got I
		//IL_06db: Expected O, but got I
		//IL_26b9: Expected O, but got I
		//IL_0745: Expected O, but got I
		//IL_26e1: Expected O, but got I
		//IL_07af: Expected O, but got I
		//IL_2709: Expected O, but got I
		//IL_0819: Expected O, but got I
		//IL_2804: Expected O, but got I
		//IL_21c7: Expected O, but got I
		//IL_21d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_21da: Expected O, but got Unknown
		//IL_234f: Expected O, but got I4
		//IL_215f: Expected O, but got Ref
		//IL_2003: Expected O, but got Ref
		//IL_2019: Expected O, but got Ref
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
		List<WeaponType> list = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ rcx_v6+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)4);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rcx_v9+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)2);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v627 @ rcx_v11+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)8);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 8;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v628 @ rcx_v13+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)6);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 6;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rcx_v15+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)17);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 17;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ rcx_v17+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)15);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 15;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v631 @ rcx_v19+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)13);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 13;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ rcx_v21+18]");
		if (num8 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)19);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 19;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v633 @ rcx_v23+18]");
		if (num9 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)10);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 10;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v634 @ rcx_v25+18]");
		if (num10 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)69);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 69;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ rcx_v27+18]");
		if (num11 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)23);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 23;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ rcx_v29+18]");
		if (num12 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)26);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 26;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ rcx_v31+18]");
		if (num13 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)44);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 44;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v638 @ rcx_v33+18]");
		if (num14 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)38);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 38;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v639 @ rcx_v35+18]");
		if (num15 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)33);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 33;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rcx_v37+18]");
		if (num16 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)46);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj32 = (nint)0 + (nint)1;
			_ = 46;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v641 @ rcx_v39+18]");
		if (num17 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)29);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj34 = (nint)0 + (nint)1;
			_ = 29;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rcx_v41+18]");
		if (num18 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)79);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj36 = (nint)0 + (nint)1;
			_ = 79;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v643 @ rcx_v43+18]");
		if (num19 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)98);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj38 = (nint)0 + (nint)1;
			_ = 98;
		}
		List<WeaponType> list2 = default(List<WeaponType>);
		AddXifYisUnlocked(WeaponType.BATTILIA2, WeaponType.BATTILIA, ref list2);
		AddXifYisUnlocked(WeaponType.ICELANCE2, WeaponType.ICELANCE, ref list2);
		AddXifYisUnlocked(WeaponType.PHASER2, WeaponType.PHASER, ref list2);
		AddXifYisUnlocked(WeaponType.SANTAJAVELIN2, WeaponType.SANTAJAVELIN, ref list2);
		AddXifYisUnlocked(WeaponType.EX_GAEA2, WeaponType.EX_GAEA1, ref list2);
		AddXifYisUnlocked(WeaponType.EX_MAGISTONE2, WeaponType.EX_MAGISTONE1, ref list2);
		AddXifYisUnlocked(WeaponType.EX_AMMO2, WeaponType.EX_AMMO1, ref list2);
		Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
		bool flag = loadedDlc == null;
		int num20 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc).FindEntry((System.Int32Enum)0);
		List<WeaponType> list3;
		if (!flag)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config._003CAchievements_003Ek__BackingField).FindEntry((DlcType)145) != 0)
			{
				int num21 = ((Dictionary<DlcType, BundleManifestData>)(object)list2).FindEntry((DlcType)112);
			}
			PlayerOptionsData config2 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config2._003CAchievements_003Ek__BackingField).FindEntry((DlcType)147) != 0)
			{
				int num22 = ((Dictionary<DlcType, BundleManifestData>)(object)list2).FindEntry((DlcType)114);
			}
			PlayerOptionsData config3 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config3._003CAchievements_003Ek__BackingField).FindEntry((DlcType)149) != 0)
			{
				int num23 = ((Dictionary<DlcType, BundleManifestData>)(object)list2).FindEntry((DlcType)116);
			}
			PlayerOptionsData config4 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config4._003CAchievements_003Ek__BackingField).FindEntry((DlcType)151) != 0)
			{
				int num24 = ((Dictionary<DlcType, BundleManifestData>)(object)list2).FindEntry((DlcType)118);
			}
			PlayerOptionsData config5 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config5._003CAchievements_003Ek__BackingField).FindEntry((DlcType)157) != 0)
			{
				int num25 = ((Dictionary<DlcType, BundleManifestData>)(object)list2).FindEntry((DlcType)121);
			}
			PlayerOptionsData config6 = _playerOptions.Config;
			int num26 = ((Dictionary<DlcType, BundleManifestData>)(object)config6._003CAchievements_003Ek__BackingField).FindEntry((DlcType)159);
			bool flag2 = num26 == 0;
			list3 = list2;
			if (!flag2)
			{
				int num27 = ((Dictionary<DlcType, BundleManifestData>)(object)list2).FindEntry((DlcType)119);
				list3 = list2;
			}
		}
		else
		{
			list3 = list2;
		}
		Dictionary<DlcType, BundleManifestData> loadedDlc2 = DlcSystem.LoadedDlc;
		bool flag3 = loadedDlc2 == null;
		int num28 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc2).FindEntry((System.Int32Enum)1);
		if (!flag3)
		{
			PlayerOptionsData config7 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config7._003CAchievements_003Ek__BackingField).FindEntry((DlcType)168) != 0)
			{
				int num29 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)127);
			}
			PlayerOptionsData config8 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config8._003CAchievements_003Ek__BackingField).FindEntry((DlcType)170) != 0)
			{
				int num30 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)139);
			}
			PlayerOptionsData config9 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config9._003CAchievements_003Ek__BackingField).FindEntry((DlcType)172) != 0)
			{
				int num31 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)136);
			}
			PlayerOptionsData config10 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config10._003CAchievements_003Ek__BackingField).FindEntry((DlcType)177) != 0)
			{
				int num32 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)134);
			}
			PlayerOptionsData config11 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config11._003CAchievements_003Ek__BackingField).FindEntry((DlcType)179) != 0)
			{
				int num33 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)132);
			}
		}
		Dictionary<DlcType, BundleManifestData> loadedDlc3 = DlcSystem.LoadedDlc;
		bool flag4 = loadedDlc3 == null;
		int num34 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc3).FindEntry((System.Int32Enum)2);
		if (!flag4)
		{
			PlayerOptionsData config12 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config12._003CAchievements_003Ek__BackingField).FindEntry((DlcType)208) != 0)
			{
				int num35 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)173);
			}
			PlayerOptionsData config13 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config13._003CAchievements_003Ek__BackingField).FindEntry((DlcType)213) != 0)
			{
				int num36 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)175);
			}
			PlayerOptionsData config14 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config14._003CAchievements_003Ek__BackingField).FindEntry((DlcType)200) != 0)
			{
				int num37 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)167);
			}
			PlayerOptionsData config15 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config15._003CAchievements_003Ek__BackingField).FindEntry((DlcType)202) != 0)
			{
				int num38 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)177);
			}
			PlayerOptionsData config16 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config16._003CAchievements_003Ek__BackingField).FindEntry((DlcType)210) != 0)
			{
				int num39 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)171);
			}
			PlayerOptionsData config17 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config17._003CAchievements_003Ek__BackingField).FindEntry((DlcType)206) != 0)
			{
				int num40 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)179);
			}
			PlayerOptionsData config18 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config18._003CAchievements_003Ek__BackingField).FindEntry((DlcType)204) != 0)
			{
				int num41 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)169);
			}
		}
		Dictionary<DlcType, BundleManifestData> loadedDlc4 = DlcSystem.LoadedDlc;
		bool flag5 = loadedDlc4 == null;
		int num42 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc4).FindEntry((System.Int32Enum)3);
		if (!flag5)
		{
			PlayerOptionsData config19 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config19._003CAchievements_003Ek__BackingField).FindEntry((DlcType)240) != 0)
			{
				int num43 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)334);
			}
			PlayerOptionsData config20 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config20._003CAchievements_003Ek__BackingField).FindEntry((DlcType)242) != 0)
			{
				int num44 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)322);
			}
			PlayerOptionsData config21 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config21._003CAchievements_003Ek__BackingField).FindEntry((DlcType)244) != 0)
			{
				int num45 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)335);
			}
			PlayerOptionsData config22 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config22._003CAchievements_003Ek__BackingField).FindEntry((DlcType)246) != 0)
			{
				int num46 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)313);
			}
			PlayerOptionsData config23 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config23._003CAchievements_003Ek__BackingField).FindEntry((DlcType)249) != 0)
			{
				int num47 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)314);
			}
			PlayerOptionsData config24 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config24._003CAchievements_003Ek__BackingField).FindEntry((DlcType)251) != 0)
			{
				int num48 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)305);
			}
			PlayerOptionsData config25 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config25._003CAchievements_003Ek__BackingField).FindEntry((DlcType)253) != 0)
			{
				int num49 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)337);
			}
			PlayerOptionsData config26 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config26._003CAchievements_003Ek__BackingField).FindEntry((DlcType)256) != 0)
			{
				int num50 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)317);
			}
			PlayerOptionsData config27 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config27._003CAchievements_003Ek__BackingField).FindEntry((DlcType)259) != 0)
			{
				int num51 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)316);
			}
			PlayerOptionsData config28 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config28._003CAchievements_003Ek__BackingField).FindEntry((DlcType)262) != 0)
			{
				int num52 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)309);
			}
			PlayerOptionsData config29 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config29._003CAchievements_003Ek__BackingField).FindEntry((DlcType)265) != 0)
			{
				int num53 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)315);
			}
		}
		Dictionary<DlcType, BundleManifestData> loadedDlc5 = DlcSystem.LoadedDlc;
		bool flag6 = loadedDlc5 == null;
		int num54 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc5).FindEntry((System.Int32Enum)4);
		if (!flag6)
		{
			PlayerOptionsData config30 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config30._003CAchievements_003Ek__BackingField).FindEntry((DlcType)409) != 0)
			{
				int num55 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)363);
			}
			PlayerOptionsData config31 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config31._003CAchievements_003Ek__BackingField).FindEntry((DlcType)411) != 0)
			{
				int num56 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)365);
			}
			PlayerOptionsData config32 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config32._003CAchievements_003Ek__BackingField).FindEntry((DlcType)413) != 0)
			{
				int num57 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)368);
			}
			PlayerOptionsData config33 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config33._003CAchievements_003Ek__BackingField).FindEntry((DlcType)415) != 0)
			{
				int num58 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)370);
			}
			PlayerOptionsData config34 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config34._003CAchievements_003Ek__BackingField).FindEntry((DlcType)417) != 0)
			{
				int num59 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)373);
			}
			PlayerOptionsData config35 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config35._003CAchievements_003Ek__BackingField).FindEntry((DlcType)419) != 0)
			{
				int num60 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)375);
			}
			PlayerOptionsData config36 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config36._003CAchievements_003Ek__BackingField).FindEntry((DlcType)421) != 0)
			{
				int num61 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)384);
			}
			PlayerOptionsData config37 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config37._003CAchievements_003Ek__BackingField).FindEntry((DlcType)423) != 0)
			{
				int num62 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)386);
			}
			PlayerOptionsData config38 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config38._003CAchievements_003Ek__BackingField).FindEntry((DlcType)425) != 0)
			{
				int num63 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)377);
			}
			PlayerOptionsData config39 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config39._003CAchievements_003Ek__BackingField).FindEntry((DlcType)428) != 0)
			{
				int num64 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)389);
			}
			PlayerOptionsData config40 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config40._003CAchievements_003Ek__BackingField).FindEntry((DlcType)430) != 0)
			{
				int num65 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)391);
			}
			PlayerOptionsData config41 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config41._003CAchievements_003Ek__BackingField).FindEntry((DlcType)434) != 0)
			{
				int num66 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)393);
			}
			PlayerOptionsData config42 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config42._003CAchievements_003Ek__BackingField).FindEntry((DlcType)433) != 0)
			{
				int num67 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)396);
			}
			PlayerOptionsData config43 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config43._003CAchievements_003Ek__BackingField).FindEntry((DlcType)431) != 0)
			{
				int num68 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)400);
			}
			PlayerOptionsData config44 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config44._003CAchievements_003Ek__BackingField).FindEntry((DlcType)432) != 0)
			{
				int num69 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)403);
			}
			PlayerOptionsData config45 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config45._003CAchievements_003Ek__BackingField).FindEntry((DlcType)446) != 0)
			{
				int num70 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)406);
			}
		}
		Dictionary<DlcType, BundleManifestData> loadedDlc6 = DlcSystem.LoadedDlc;
		bool flag7 = loadedDlc6 == null;
		int num71 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc6).FindEntry((System.Int32Enum)6);
		if (!flag7)
		{
			PlayerOptionsData config46 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config46._003CAchievements_003Ek__BackingField).FindEntry((DlcType)466) != 0)
			{
				int num72 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)1702);
			}
			PlayerOptionsData config47 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config47._003CAchievements_003Ek__BackingField).FindEntry((DlcType)468) != 0)
			{
				int num73 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)1706);
			}
			PlayerOptionsData config48 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config48._003CAchievements_003Ek__BackingField).FindEntry((DlcType)470) != 0)
			{
				int num74 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)1704);
			}
			PlayerOptionsData config49 = _playerOptions.Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config49._003CAchievements_003Ek__BackingField).FindEntry((DlcType)472) != 0)
			{
				int num75 = ((Dictionary<DlcType, BundleManifestData>)(object)list3).FindEntry((DlcType)1708);
			}
		}
		Dictionary<DlcType, BundleManifestData> loadedDlc7 = DlcSystem.LoadedDlc;
		bool flag8 = loadedDlc7 == null;
		int num76 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc7).FindEntry((System.Int32Enum)5);
		List<WeaponType>.Enumerator enumerator = default(List<WeaponType>.Enumerator);
		Dictionary<System.Int32Enum, object> dictionary;
		if (!flag8)
		{
			List<WeaponType> list4 = new List<WeaponType>();
			int num77 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1456);
			int num78 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1458);
			int num79 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1460);
			int num80 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1462);
			int num81 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1464);
			int num82 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1466);
			int num83 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1468);
			int num84 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1470);
			int num85 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1412);
			int num86 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1495);
			int num87 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1420);
			int num88 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1416);
			int num89 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1502);
			int num90 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1509);
			int num91 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1418);
			int num92 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1504);
			int num93 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1422);
			int num94 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1414);
			int num95 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1424);
			int num96 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1426);
			int num97 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1493);
			int num98 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1432);
			int num99 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1450);
			int num100 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1434);
			int num101 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1406);
			int num102 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1489);
			int num103 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1446);
			int num104 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1506);
			int num105 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1442);
			int num106 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1491);
			int num107 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1444);
			int num108 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1436);
			int num109 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1428);
			int num110 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1430);
			int num111 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1472);
			int num112 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1474);
			int num113 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1453);
			int num114 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1440);
			int num115 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1500);
			int num116 = ((Dictionary<DlcType, BundleManifestData>)(object)list4).FindEntry((DlcType)1404);
			object obj39 = default(object);
			while (enumerator.MoveNext())
			{
				PlayerOptions playerOptions = _playerOptions;
				bool flag9 = _playerOptions == null;
				List<WeaponType>.Enumerator enumerator2 = (List<WeaponType>.Enumerator)(&enumerator);
				PlayerOptionsData playerOptionsData;
				if (!flag9)
				{
					enumerator2 = (List<WeaponType>.Enumerator)(&enumerator);
					if (playerOptions._onlineClientWithRunDataConfig == null)
					{
						if (playerOptions._hostGameConfig == null)
						{
							if (playerOptions._currentAdventureSaveData != null)
							{
								playerOptionsData = playerOptions._currentAdventureSaveData;
								if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
								{
									goto IL_2779;
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
					goto IL_2779;
				}
				throw new NullReferenceException();
				IL_2779:
				if (playerOptionsData != null)
				{
					enumerator2 = (List<WeaponType>.Enumerator)playerOptionsData._003CCollectedWeapons_003Ek__BackingField;
					if (playerOptionsData._003CCollectedWeapons_003Ek__BackingField != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5220 @ rcx_v167 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>+Enumerator<VampireSurvivors.Data.WeaponType>)+18]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
							if ((nint)obj39 != -1)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
							}
						}
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			dictionary = (Dictionary<System.Int32Enum, object>)(&enumerator);
		}
		object obj40 = default(object);
		object obj42 = default(object);
		while (true)
		{
			if ((object)enumerator != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4611 @ stack_-40_v18 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>+Enumerator<VampireSurvivors.Data.WeaponType>)+1C]");
				if (obj40 != null)
				{
					break;
				}
				object obj41 = obj42;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4611 @ stack_-40_v18 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>+Enumerator<VampireSurvivors.Data.WeaponType>)+18]");
				if ((nint)obj41 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4611 @ stack_-40_v18 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>+Enumerator<VampireSurvivors.Data.WeaponType>)+10]");
				object obj43 = 0;
				object obj44 = obj42 + 1;
				_003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass27_0();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5003 @ rax_v93+20+v4799 @ stack_-38_v4*4]");
				CS_0024_003C_003E8__locals5.v = WeaponType.VOID;
				VampireSurvivors.Objects.Characters.CharacterController targetCharacter = _targetCharacter;
				CharacterWeaponsManager weaponsManager = targetCharacter._weaponsManager;
				Func<Equipment, bool> predicate = delegate(Equipment x)
				{
					//IL_0053: Expected I4, but got O
					//IL_0031: Expected O, but got I4
					if ((object)x == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					object obj45 = x._equipmentType - CS_0024_003C_003E8__locals5.v;
					return obj45 == null;
				};
				int num117 = Enumerable.Count(((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField, (Func<object, bool>)predicate);
				bool flag10 = num117 > 0;
				obj42 = obj44;
				if (flag10)
				{
					continue;
				}
				VampireSurvivors.Objects.Characters.CharacterController targetCharacter2 = _targetCharacter;
				CharacterWeaponsManager weaponsManager2 = targetCharacter2._weaponsManager;
				Func<Equipment, bool> predicate2 = delegate(Equipment x)
				{
					//IL_0053: Expected I4, but got O
					//IL_0031: Expected O, but got I4
					if ((object)x == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					object obj45 = x._equipmentType - CS_0024_003C_003E8__locals5.v;
					return obj45 == null;
				};
				int num118 = Enumerable.Count(((EquipmentManager)weaponsManager2)._003CRemovedEquipment_003Ek__BackingField, (Func<object, bool>)predicate2);
				bool flag11 = num118 > 0;
				obj42 = obj44;
				if (!flag11)
				{
					bool flag12 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).TryGetValue((System.Int32Enum)CS_0024_003C_003E8__locals5.v, out object value);
					bool flag13 = value == null;
					obj42 = obj44;
					if (!flag13)
					{
						bool flag14 = ((Dictionary<WeaponType, List<WeaponData>>)value).TryGetValue(WeaponType.VOID, out *(List<WeaponData>*)(&value));
						AddWeapon(CS_0024_003C_003E8__locals5.v, (WeaponData)flag14);
						obj42 = obj44;
					}
				}
				continue;
			}
			throw new NullReferenceException();
		}
		bool flag15 = (object)enumerator == null;
		dictionary = (Dictionary<System.Int32Enum, object>)0;
		if (!flag15)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4611 @ stack_-40_v18 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>+Enumerator<VampireSurvivors.Data.WeaponType>)+1C]");
			if (obj40 == null)
			{
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			dictionary = null;
		}
		throw new NullReferenceException();
	}

	private void SelectFirst()
	{
		//IL_008c: Expected O, but got I4
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		List<WeaponSelectionItemUI> spawned = _spawned;
		int num = spawned._size ^ spawned._size;
		int num2 = spawned._size & num;
		bool flag = num2 < 0;
		bool flag2 = spawned._size < 0;
		bool flag3 = spawned._size == 0;
		Component component;
		if (!flag3)
		{
			bool flag4 = flag2 == flag;
			object obj = !flag4;
			object obj2 = obj | flag3;
			if (obj2 != null)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			WeaponSelectionItemUI[] items = spawned._items;
			component = items[0];
		}
		else
		{
			component = _SkipButton;
		}
		Selectable component2 = component.GetComponent<Selectable>();
		component2.Select();
	}

	private void AddWeapon(WeaponType t, WeaponData d)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(_WeaponPrefab, _Container);
		WeaponSelectionItemUI component = gameObject.GetComponent<WeaponSelectionItemUI>();
		component.SetData(this, t, d);
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

	private void Clear()
	{
		//IL_0039->IL0125: Incompatible stack heights: 1 vs 0
		if (_spawned != null)
		{
			List<WeaponSelectionItemUI>.Enumerator enumerator = default(List<WeaponSelectionItemUI>.Enumerator);
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
			List<WeaponSelectionItemUI> spawned = _spawned;
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

	private void RemoveCandyBox()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE9C0");
	}

	private void OnDestroy()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		Action<OnlineSignals.SelectCandyBoxWeapon> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE8E0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		Action token2 = OnWeaponSkippedRemotely;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		_signalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
	}

	public WeaponSelectionPage()
	{
		List<WeaponSelectionItemUI> spawned = new List<WeaponSelectionItemUI>();
		_spawned = spawned;
		((BaseUIPage)this)._002Ector();
	}
}
