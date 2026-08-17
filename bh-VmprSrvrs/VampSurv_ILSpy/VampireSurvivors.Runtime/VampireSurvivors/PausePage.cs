using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VampireSurvivors.App.Tools;
using VampireSurvivors.App.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors;

public class PausePage : BaseUIPage
{
	private enum PausePageState
	{
		NONE,
		MAP,
		GRIMOIRE,
		OPTIONS
	}

	private sealed class _003CForceLeftLayoutDelayed_003Ed__42(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public PausePage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			//IL_00e1: Expected I4, but got O
			PausePage pausePage = _003C_003E4__this;
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
				if ((object)_003C_003E4__this == null || (object)pausePage._LeftStatsLayoutGroup == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				RectTransform component = pausePage._LeftStatsLayoutGroup.GetComponent<RectTransform>();
				LayoutRebuilder.ForceRebuildLayoutImmediate(component);
				Canvas.ForceUpdateCanvases();
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

	private GameObject _Equipment;

	private GameObject _MobileEquipment;

	private GameObject _CharacterStatsPanel;

	private GameObject _Options;

	private List<PauseEquipmentPanel> _EquipmentPanels;

	private GrimoireManager _Grimoire;

	private GameObject _QuitDescriptionText;

	private GameObject _Fader;

	private VerticalLayoutGroup _LeftStatsLayoutGroup;

	private ArcanaDisplayContainer _arcanasDisplayContainer;

	private SurvarotsDisplayContainer _survarotsDisplayContainer;

	private GameObject _Arcanas;

	private RectTransform _ResumeButton;

	private RectTransform _OptionsButton;

	private RectTransform _QuitButton;

	private RectTransform _GuidesButton;

	private RectTransform _PickupsButton;

	private RectTransform _OpenMapButton;

	private RectTransform _OpenGrimoireButton;

	private RectTransform _ZoomInMapButton;

	private RectTransform _ZoomOutMapButton;

	private GameObject _Map;

	private MapManager _MapManager;

	private SignalBus _signalBus;

	private PlayerOptions _playerOptions;

	private GameManager _gameManager;

	private DataManager _dataManager;

	private LobbiesManager _lobbiesManager;

	private bool _hasGrimoire;

	private bool _hasMap;

	private bool _hasInitializedOptions;

	private bool _arcanasActive;

	private bool hadToDelayInitialization;

	private PausePageState _State;

	protected override bool IsOnlineUi => false;

	private void Construct(SignalBus signalBus, PlayerOptions playerOptions, GameManager gameManager, DataManager dataManager, LobbiesManager lobbiesManager)
	{
		_signalBus = signalBus;
		_playerOptions = playerOptions;
		_gameManager = gameManager;
		DataManager dataManager2 = default(DataManager);
		_dataManager = dataManager2;
		LobbiesManager lobbiesManager2 = default(LobbiesManager);
		_lobbiesManager = lobbiesManager2;
	}

	protected override void Awake()
	{
		//IL_0261->IL01c5: Incompatible stack heights: 1 vs 0
		base.Awake();
		if ((object)_Grimoire != null)
		{
			GameObject gameObject = _Grimoire.gameObject;
			if ((object)gameObject != null)
			{
				gameObject.SetActive(value: false);
				if ((object)_Map != null)
				{
					_Map.SetActive(value: false);
					PlayerOptions playerOptions = _playerOptions;
					if (_playerOptions != null)
					{
						if (!playerOptions._003CIsInitialized_003Ek__BackingField)
						{
							PlayerOptions.OnInitialized value = InitializePage;
							_playerOptions.PlayerOptionsInitialized += value;
							hadToDelayInitialization = true;
							return;
						}
						GameManager gameManager = _gameManager;
						if ((object)_gameManager != null && gameManager._arcanaManager != null)
						{
							if (!(_arcanasActive = gameManager._arcanaManager.HasRandomazzoEnabled()))
							{
								return;
							}
							Canvas.ForceUpdateCanvases();
							if ((object)_Arcanas != null)
							{
								RectTransform component = _Arcanas.GetComponent<RectTransform>();
								if ((object)component != null)
								{
									bool flag = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
									RectTransform.ForceUpdateRectTransforms_Injected(((UnityEngine.Object)component).m_CachedPtr);
									if ((object)_Arcanas != null)
									{
										RectTransform component2 = _Arcanas.GetComponent<RectTransform>();
										VampireSurvivors.App.Tools.Extensions.RefreshLayoutGroupsImmediateAndRecursive(component2);
										return;
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

	private void OnDestroy()
	{
		if (hadToDelayInitialization)
		{
			PlayerOptions.OnInitialized value = InitializePage;
			_playerOptions.PlayerOptionsInitialized -= value;
		}
	}

	private void InitializePage()
	{
		//IL_014a->IL00d4: Incompatible stack heights: 1 vs 0
		//IL_00d3->IL00d3: Incompatible stack heights: 1 vs 0
		GameManager gameManager = _gameManager;
		if ((object)_gameManager != null && gameManager._arcanaManager != null)
		{
			if (!(_arcanasActive = gameManager._arcanaManager.HasRandomazzoEnabled()))
			{
				return;
			}
			Canvas.ForceUpdateCanvases();
			if ((object)_Arcanas != null)
			{
				RectTransform component = _Arcanas.GetComponent<RectTransform>();
				if ((object)component != null)
				{
					bool flag = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
					RectTransform.ForceUpdateRectTransforms_Injected(((UnityEngine.Object)component).m_CachedPtr);
					if ((object)_Arcanas != null)
					{
						RectTransform component2 = _Arcanas.GetComponent<RectTransform>();
						VampireSurvivors.App.Tools.Extensions.RefreshLayoutGroupsImmediateAndRecursive(component2);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnShowStart(GameObject g)
	{
		//IL_117d: Expected O, but got I4
		//IL_035f: Expected I4, but got I8
		//IL_035f: Expected O, but got I
		//IL_0857: Expected O, but got I
		//IL_06c5: Expected O, but got I
		//IL_1902: Expected O, but got I
		//IL_0842: Expected O, but got I
		//IL_18d1: Expected O, but got I
		//IL_06b0: Expected O, but got I
		//IL_047f: Expected O, but got I
		//IL_080c: Expected O, but got I
		//IL_07ca: Expected O, but got I
		//IL_071f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0724: Expected O, but got Unknown
		//IL_067a: Expected O, but got I
		//IL_0638: Expected O, but got I
		//IL_09db: Expected O, but got I
		//IL_0529: Expected O, but got I
		//IL_1933: Expected O, but got I
		//IL_09c6: Expected O, but got I
		//IL_0a2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2f: Expected O, but got Unknown
		//IL_0990: Expected O, but got I
		//IL_094e: Expected O, but got I
		//IL_0afa: Expected O, but got I
		//IL_0c00: Expected O, but got I
		//IL_0beb: Expected O, but got I
		//IL_0bb5: Expected O, but got I
		//IL_0b7d: Expected O, but got I
		//IL_0cfe: Expected O, but got I
		//IL_1964: Expected O, but got I
		//IL_0ce9: Expected O, but got I
		//IL_0d4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d53: Expected O, but got Unknown
		//IL_0cb3: Expected O, but got I
		//IL_0c71: Expected O, but got I
		//IL_10ac->IL10ac: Incompatible stack heights: 11 vs 0
		//IL_121b->IL189b: Incompatible stack heights: 12 vs 10
		//IL_1195->IL119a: Incompatible stack heights: 13 vs 10
		//IL_0268->IL119a: Incompatible stack heights: 14 vs 10
		//IL_0832->IL1311: Incompatible stack heights: 15 vs 14
		//IL_06a0->IL12b2: Incompatible stack heights: 15 vs 14
		//IL_052e->IL052e: Incompatible stack heights: 24 vs 11
		//IL_0a53->IL1316: Incompatible stack heights: 17 vs 15
		//IL_0a16->IL1316: Incompatible stack heights: 17 vs 15
		//IL_09b6->IL1348: Incompatible stack heights: 17 vs 16
		//IL_0a89->IL0a89: Incompatible stack heights: 18 vs 17
		//IL_0bdb->IL15d5: Incompatible stack heights: 32 vs 31
		//IL_0cd9->IL1675: Incompatible stack heights: 35 vs 34
		//IL_0eb7->IL0eb7: Incompatible stack heights: 47 vs 43
		//IL_0ff0->IL0ffb: Incompatible stack heights: 48 vs 44
		bool flag6;
		bool flag7 = default(bool);
		List<PauseEquipmentPanel>.Enumerator enumerator = default(List<PauseEquipmentPanel>.Enumerator);
		GameObject gameObject3 = default(GameObject);
		List<PauseEquipmentPanel>.Enumerator enumerator3 = default(List<PauseEquipmentPanel>.Enumerator);
		GameObject characterStatsPanel;
		while (true)
		{
			base.OnShowStart(g);
			GameManager gameManager = _gameManager;
			bool flag = (object)_gameManager == null;
			EnterMultiplayerControl(gameManager._003CPausingPlayer_003Ek__BackingField, 0f);
			bool flag2 = (object)_Fader == null;
			_Fader.SetActive(value: true);
			bool flag3 = _playerOptions == null;
			PlayerOptionsData config = _playerOptions.Config;
			bool flag4 = config == null;
			List<WeaponType> list = config._003CUnlockedWeapons_003Ek__BackingField;
			bool flag5 = config._003CUnlockedWeapons_003Ek__BackingField == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rax_v79 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			if ((nint)0 > (nint)21)
			{
				flag6 = true;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
				flag6 = flag7;
			}
			bool flag8 = (object)_Grimoire == null;
			GameObject gameObject = _Grimoire.gameObject;
			bool flag9 = (object)gameObject == null;
			gameObject.SetActive(value: false);
			bool flag10 = (object)_Map == null;
			_Map.SetActive(value: false);
			bool flag11 = (object)_Equipment == null;
			_Equipment.SetActive(flag6);
			bool num;
			if (flag6)
			{
				List<PauseEquipmentPanel> equipmentPanels = _EquipmentPanels;
				bool flag12 = _EquipmentPanels == null;
				num = flag12;
				while (enumerator.MoveNext())
				{
					GameObject gameObject2 = ((Component)null).gameObject;
					bool flag13 = (object)gameObject2 == null;
					bool flag14 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
					GameObject.SetActive_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr, true);
					bool flag15 = ((UnityEngine.Object)gameObject3).m_CachedPtr == (IntPtr)0;
					object obj = GameObject.get_activeInHierarchy_Injected(((UnityEngine.Object)gameObject3).m_CachedPtr);
					if (obj != null)
					{
						GameManager gameManager2 = _gameManager;
						bool flag16 = (object)_gameManager == null;
						((PauseEquipmentPanel)null).Populate(gameManager2._003CPausingPlayer_003Ek__BackingField);
					}
				}
				Component component = null;
				List<PauseEquipmentPanel>.Enumerator enumerator2 = (List<PauseEquipmentPanel>.Enumerator)equipmentPanels;
			}
			else
			{
				List<PauseEquipmentPanel> equipmentPanels = _EquipmentPanels;
				bool flag17 = _EquipmentPanels == null;
				num = flag17;
				while (enumerator3.MoveNext())
				{
					GameObject gameObject4 = ((Component)null).gameObject;
					bool flag18 = (object)gameObject4 == null;
					bool flag19 = ((UnityEngine.Object)gameObject4).m_CachedPtr == (IntPtr)0;
					GameObject.SetActive_Injected(((UnityEngine.Object)gameObject4).m_CachedPtr, false);
				}
				Component component = null;
				List<PauseEquipmentPanel>.Enumerator enumerator2 = (List<PauseEquipmentPanel>.Enumerator)equipmentPanels;
			}
			characterStatsPanel = _CharacterStatsPanel;
			bool flag20 = (object)_CharacterStatsPanel == null;
			if (((UnityEngine.Object)characterStatsPanel).m_CachedPtr != (IntPtr)0)
			{
				break;
			}
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_CharacterStatsPanel);
		}
		GameObject.SetActive_Injected(((UnityEngine.Object)characterStatsPanel).m_CachedPtr, flag6);
		if (flag6)
		{
			bool flag21 = (object)_CharacterStatsPanel == null;
			StatsPanelUI component2 = _CharacterStatsPanel.GetComponent<StatsPanelUI>();
			bool flag22 = (object)component2 == null;
			if (!component2._hasLoaded)
			{
				component2.Populate();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rax_v303 (VampireSurvivors.UI.StatsPanelUI)+98]");
			TextAutoSizeHelper.UpdateTextSizes((List<TextMeshProUGUI>)0, -1);
			GameManager gameManager3 = _gameManager;
			bool flag23 = (object)_gameManager == null;
			VampireSurvivors.Objects.Characters.CharacterController characterController = gameManager3._003CPausingPlayer_003Ek__BackingField;
			bool flag24 = (object)gameManager3._003CPausingPlayer_003Ek__BackingField == null;
			bool flag25 = (object)_CharacterStatsPanel == null;
			StatsPanelUI component3 = _CharacterStatsPanel.GetComponent<StatsPanelUI>();
			bool flag26 = _dataManager == null;
			Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
			bool flag27 = convertedCharacterData == null;
			object obj2 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterController._characterType);
			bool flag28 = obj2 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ rax_v310 (System.Object)+18]");
			bool flag29 = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ rax_v310 (System.Object)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ rax_v310 (System.Object)+10]");
			bool flag30 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rdx_v146+18]");
			bool flag31 = (nint)0 <= (nint)0;
			GameManager gameManager4 = _gameManager;
			bool flag32 = (object)_gameManager == null;
			bool flag33 = (object)component3 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rdx_v146+20]");
			component3.SetCharacter((CharacterData)0, characterController._characterType, gameManager4._003CPausingPlayer_003Ek__BackingField);
		}
		_003CForceLeftLayoutDelayed_003Ed__42 obj4 = null;
		obj4._003C_003E1__state = 0;
		obj4._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj4);
		GameManager core = GM.Core;
		bool flag34 = (object)GM.Core == null;
		Stage stage = core._stage;
		bool flag35 = (object)core._stage == null;
		GameObject playerOptions = (GameObject)(object)_playerOptions;
		bool num2;
		if (stage._stageType != StageType.TP_CASTLE)
		{
			bool flag36 = _playerOptions == null;
			num2 = flag36;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1118 @ rdi_v38 (UnityEngine.GameObject)+68]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1118 @ rdi_v38 (UnityEngine.GameObject)+58]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1118 @ rdi_v38 (UnityEngine.GameObject)+78]");
					GameObject gameObject6;
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1118 @ rdi_v38 (UnityEngine.GameObject)+78]");
						GameObject gameObject5 = (GameObject)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3265 @ rax_v296 (UnityEngine.GameObject)+2CC]");
						if ((nint)0 != 0)
						{
							gameObject6 = gameObject5;
							goto IL_18c1;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1118 @ rdi_v38 (UnityEngine.GameObject)+50]");
					gameObject6 = (GameObject)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1118 @ rdi_v38 (UnityEngine.GameObject)+50]");
					bool flag37 = (nint)0 == 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1118 @ rdi_v38 (UnityEngine.GameObject)+58]");
					GameObject gameObject6 = (GameObject)0;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1118 @ rdi_v38 (UnityEngine.GameObject)+68]");
				GameObject gameObject6 = (GameObject)0;
			}
			goto IL_18c1;
		}
		bool flag38 = _playerOptions == null;
		num2 = flag38;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1118 @ rdi_v38 (UnityEngine.GameObject)+68]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1118 @ rdi_v38 (UnityEngine.GameObject)+58]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1118 @ rdi_v38 (UnityEngine.GameObject)+78]");
				GameObject gameObject8;
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1118 @ rdi_v38 (UnityEngine.GameObject)+78]");
					GameObject gameObject7 = (GameObject)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3310 @ rax_v284 (UnityEngine.GameObject)+2CC]");
					if ((nint)0 != 0)
					{
						gameObject8 = gameObject7;
						goto IL_18f2;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1118 @ rdi_v38 (UnityEngine.GameObject)+50]");
				gameObject8 = (GameObject)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1118 @ rdi_v38 (UnityEngine.GameObject)+50]");
				bool flag39 = (nint)0 == 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1118 @ rdi_v38 (UnityEngine.GameObject)+58]");
				GameObject gameObject8 = (GameObject)0;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1118 @ rdi_v38 (UnityEngine.GameObject)+68]");
			GameObject gameObject8 = (GameObject)0;
		}
		goto IL_18f2;
		IL_18f2:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1122 @ rdi_v63 (UnityEngine.GameObject)+188]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1122 @ rdi_v63 (UnityEngine.GameObject)+188]");
		bool flag40 = (nint)0 == 0;
		bool num3 = flag40;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rcx_v225+18]");
		bool flag41 = (nint)0 == 0;
		ArcanaInfoPanel arcanaInfoPanel = null;
		bool hasMap;
		if (!flag41)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj6 = default(object);
			bool flag42 = (nint)obj6 == -1;
			arcanaInfoPanel = null;
			if (!flag42)
			{
				arcanaInfoPanel = null;
				hasMap = true;
				goto IL_1316;
			}
		}
		GameObject playerOptions2 = (GameObject)(object)_playerOptions;
		bool flag43 = _playerOptions == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1123 @ rdi_v65 (UnityEngine.GameObject)+68]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1123 @ rdi_v65 (UnityEngine.GameObject)+58]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1123 @ rdi_v65 (UnityEngine.GameObject)+78]");
				GameObject gameObject10;
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1123 @ rdi_v65 (UnityEngine.GameObject)+78]");
					GameObject gameObject9 = (GameObject)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3830 @ rax_v275 (UnityEngine.GameObject)+2CC]");
					if ((nint)0 != 0)
					{
						gameObject10 = gameObject9;
						goto IL_1923;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1123 @ rdi_v65 (UnityEngine.GameObject)+50]");
				gameObject10 = (GameObject)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1123 @ rdi_v65 (UnityEngine.GameObject)+50]");
				bool flag44 = (nint)0 == 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1123 @ rdi_v65 (UnityEngine.GameObject)+58]");
				GameObject gameObject10 = (GameObject)0;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1123 @ rdi_v65 (UnityEngine.GameObject)+68]");
			GameObject gameObject10 = (GameObject)0;
		}
		goto IL_1923;
		IL_1954:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1134 @ rdi_v51 (UnityEngine.GameObject)+188]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1134 @ rdi_v51 (UnityEngine.GameObject)+188]");
		bool flag45 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rcx_v136+18]");
		bool hasGrimoire;
		if ((nint)0 == 0)
		{
			hasGrimoire = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj9 = default(object);
			object obj8 = obj9 - -1;
			bool flag46 = obj8 == null;
			hasGrimoire = !flag46;
			arcanaInfoPanel = null;
		}
		_hasGrimoire = hasGrimoire;
		GameObject openGrimoireButton = (GameObject)(object)_OpenGrimoireButton;
		bool flag47 = (object)_OpenGrimoireButton == null;
		bool flag48 = ((UnityEngine.Object)openGrimoireButton).m_CachedPtr == (IntPtr)0;
		IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)openGrimoireButton).m_CachedPtr);
		GameObject gameObject11 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
		bool flag49 = (object)gameObject11 == null;
		bool flag50 = ((UnityEngine.Object)gameObject11).m_CachedPtr == (IntPtr)0;
		GameObject.SetActive_Injected(((UnityEngine.Object)gameObject11).m_CachedPtr, _hasGrimoire);
		bool flag51 = (object)_Grimoire == null;
		_Grimoire.Init();
		UpdatePickupsToggleText();
		bool flag52 = (object)_MapManager == null;
		_MapManager.SetPickups();
		UpdateGuidesToggleText();
		GameObject arcanas = _Arcanas;
		bool flag53 = (object)_Arcanas == null;
		bool flag54 = ((UnityEngine.Object)arcanas).m_CachedPtr == (IntPtr)0;
		GameObject.SetActive_Injected(((UnityEngine.Object)arcanas).m_CachedPtr, _arcanasActive);
		if (_arcanasActive)
		{
			ArcanaDisplayContainer arcanasDisplayContainer = _arcanasDisplayContainer;
			GameManager core2 = GM.Core;
			bool flag55 = (object)GM.Core == null;
			bool flag56 = (object)_arcanasDisplayContainer == null;
			arcanaInfoPanel = arcanasDisplayContainer._ArcanaInfoPanel;
			bool flag57 = (object)arcanasDisplayContainer._ArcanaInfoPanel == null;
			arcanaInfoPanel._controllingCharacter = core2._003CPausingPlayer_003Ek__BackingField;
			bool flag58 = (object)_arcanasDisplayContainer == null;
			_arcanasDisplayContainer.SetArcanaDetails();
		}
		bool flag59 = (object)_survarotsDisplayContainer == null;
		_survarotsDisplayContainer.SetCardDetails();
		if (!_hasMap)
		{
			if (_hasGrimoire)
			{
				OpenGrimoire();
			}
			else
			{
				_State = PausePageState.NONE;
				bool flag60 = (object)_Map == null;
				_Map.SetActive(value: false);
				bool flag61 = (object)_Grimoire == null;
				GameObject gameObject12 = _Grimoire.gameObject;
				bool flag62 = (object)gameObject12 == null;
				gameObject12.SetActive(value: false);
				bool flag63 = (object)_Options == null;
				_Options.SetActive(value: false);
				FormatButtons();
				arcanaInfoPanel = null;
			}
		}
		else
		{
			OpenMap();
		}
		GameObject options = _Options;
		bool flag64 = (object)_Options == null;
		bool flag65 = ((UnityEngine.Object)options).m_CachedPtr == (IntPtr)0;
		GameObject.SetActive_Injected(((UnityEngine.Object)options).m_CachedPtr, false);
		GameObject optionsButton = (GameObject)(object)_OptionsButton;
		bool flag66 = (object)_OptionsButton == null;
		bool flag67 = ((UnityEngine.Object)optionsButton).m_CachedPtr == (IntPtr)0;
		IntPtr gcHandlePtr2 = Component.get_gameObject_Injected(((UnityEngine.Object)optionsButton).m_CachedPtr);
		GameObject gameObject13 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
		bool flag68 = (object)gameObject13 == null;
		bool flag69 = ((UnityEngine.Object)gameObject13).m_CachedPtr == (IntPtr)0;
		GameObject.SetActive_Injected(((UnityEngine.Object)gameObject13).m_CachedPtr, true);
		UpdatePickupsToggleText();
		bool flag70 = (object)_MapManager == null;
		_MapManager.SetPickups();
		UpdateGuidesToggleText();
		bool flag71 = (object)_ResumeButton == null;
		Selectable component4 = _ResumeButton.GetComponent<Selectable>();
		bool flag72 = (object)component4 == null;
		component4.Select();
		return;
		IL_15d5:
		bool flag73 = (object)_QuitDescriptionText == null;
		GameObject quitDescriptionText;
		bool flag74 = ((UnityEngine.Object)quitDescriptionText).m_CachedPtr == (IntPtr)0;
		IntPtr cachedPtr = ((UnityEngine.Object)quitDescriptionText).m_CachedPtr;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rax_v145+130]");
		GameObject.SetActive_Injected(cachedPtr, false);
		GameObject playerOptions3 = (GameObject)(object)_playerOptions;
		bool flag75 = _playerOptions == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1141 @ rdi_v50 (UnityEngine.GameObject)+68]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1141 @ rdi_v50 (UnityEngine.GameObject)+58]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1141 @ rdi_v50 (UnityEngine.GameObject)+78]");
				GameObject gameObject15;
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1141 @ rdi_v50 (UnityEngine.GameObject)+78]");
					GameObject gameObject14 = (GameObject)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4911 @ rax_v231 (UnityEngine.GameObject)+2CC]");
					if ((nint)0 != 0)
					{
						gameObject15 = gameObject14;
						goto IL_1954;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1141 @ rdi_v50 (UnityEngine.GameObject)+50]");
				gameObject15 = (GameObject)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1141 @ rdi_v50 (UnityEngine.GameObject)+50]");
				bool flag76 = (nint)0 == 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1141 @ rdi_v50 (UnityEngine.GameObject)+58]");
				GameObject gameObject15 = (GameObject)0;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1141 @ rdi_v50 (UnityEngine.GameObject)+68]");
			GameObject gameObject15 = (GameObject)0;
		}
		goto IL_1954;
		IL_1923:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1125 @ rdi_v66 (UnityEngine.GameObject)+188]");
		object obj10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1125 @ rdi_v66 (UnityEngine.GameObject)+188]");
		bool flag77 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rcx_v230+18]");
		if ((nint)0 == 0)
		{
			hasMap = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj12 = default(object);
			object obj11 = obj12 - -1;
			bool flag78 = obj11 == null;
			hasMap = !flag78;
			arcanaInfoPanel = null;
		}
		goto IL_1316;
		IL_12b7:
		PausePage pausePage;
		pausePage._hasMap = hasMap;
		GameObject map = _Map;
		bool flag79 = (object)_Map == null;
		bool flag80 = ((UnityEngine.Object)map).m_CachedPtr == (IntPtr)0;
		GameObject.SetActive_Injected(((UnityEngine.Object)map).m_CachedPtr, _hasMap);
		if (_hasMap)
		{
			bool flag81 = (object)_MapManager == null;
			_MapManager.Populate();
		}
		GameObject guidesButton = (GameObject)(object)_GuidesButton;
		bool flag82 = (object)_GuidesButton == null;
		bool flag83 = ((UnityEngine.Object)guidesButton).m_CachedPtr == (IntPtr)0;
		IntPtr gcHandlePtr3 = Component.get_transform_Injected(((UnityEngine.Object)guidesButton).m_CachedPtr);
		Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
		bool flag84 = (object)transform == null;
		bool flag85 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		IntPtr gcHandlePtr4 = Component.get_gameObject_Injected(((UnityEngine.Object)transform).m_CachedPtr);
		GameObject gameObject16 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr4);
		bool flag86 = (object)gameObject16 == null;
		bool flag87 = ((UnityEngine.Object)gameObject16).m_CachedPtr == (IntPtr)0;
		GameObject.SetActive_Injected(((UnityEngine.Object)gameObject16).m_CachedPtr, _hasMap);
		GameObject pickupsButton = (GameObject)(object)_PickupsButton;
		bool flag88 = (object)_PickupsButton == null;
		bool flag89 = ((UnityEngine.Object)pickupsButton).m_CachedPtr == (IntPtr)0;
		IntPtr gcHandlePtr5 = Component.get_transform_Injected(((UnityEngine.Object)pickupsButton).m_CachedPtr);
		Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr5);
		bool flag90 = (object)transform2 == null;
		bool flag91 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		IntPtr gcHandlePtr6 = Component.get_gameObject_Injected(((UnityEngine.Object)transform2).m_CachedPtr);
		GameObject gameObject17 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr6);
		bool flag92 = (object)gameObject17 == null;
		bool flag93 = ((UnityEngine.Object)gameObject17).m_CachedPtr == (IntPtr)0;
		GameObject.SetActive_Injected(((UnityEngine.Object)gameObject17).m_CachedPtr, _hasMap);
		quitDescriptionText = _QuitDescriptionText;
		GameObject core3 = (GameObject)(object)GM.Core;
		bool flag94 = (object)GM.Core == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1140 @ rdi_v47 (UnityEngine.GameObject)+90]");
		GameObject gameObject18 = (GameObject)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1140 @ rdi_v47 (UnityEngine.GameObject)+90]");
		bool flag95 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1132 @ rdi_v48 (UnityEngine.GameObject)+68]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1132 @ rdi_v48 (UnityEngine.GameObject)+58]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1132 @ rdi_v48 (UnityEngine.GameObject)+78]");
				object obj13;
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1132 @ rdi_v48 (UnityEngine.GameObject)+78]");
					obj13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rax_v145+2CC]");
					if ((nint)0 != 0)
					{
						goto IL_15d5;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1132 @ rdi_v48 (UnityEngine.GameObject)+50]");
				obj13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1132 @ rdi_v48 (UnityEngine.GameObject)+50]");
				bool flag96 = (nint)0 == 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1132 @ rdi_v48 (UnityEngine.GameObject)+58]");
				object obj13 = 0;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1132 @ rdi_v48 (UnityEngine.GameObject)+68]");
			object obj13 = 0;
		}
		goto IL_15d5;
		IL_1316:
		pausePage = this;
		goto IL_12b7;
		IL_18c1:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1120 @ rdi_v75 (UnityEngine.GameObject)+188]");
		object obj14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1120 @ rdi_v75 (UnityEngine.GameObject)+188]");
		bool flag97 = (nint)0 == 0;
		num3 = flag97;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rcx_v242+18]");
		if ((nint)0 == 0)
		{
			arcanaInfoPanel = null;
			hasMap = false;
			pausePage = this;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj16 = default(object);
			object obj15 = obj16 - -1;
			bool flag98 = obj15 == null;
			hasMap = !flag98;
			arcanaInfoPanel = null;
			pausePage = this;
		}
		goto IL_12b7;
	}

	private IEnumerator ForceLeftLayoutDelayed()
	{
		_003CForceLeftLayoutDelayed_003Ed__42 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	protected override void OnHideStart(GameObject g)
	{
		base.OnHideStart(g);
		GameManager core = GM.Core;
		core._003CMainUI_003Ek__BackingField.ForceEquipmentLayoutRebuild();
		_survarotsDisplayContainer.HideArcanaInfoPanel();
	}

	protected override void OnHideFinish(GameObject g)
	{
		base.OnHideFinish(g);
		ExitMultiplayerControl();
		_Fader.SetActive(value: false);
		OptionsState.LastSelectedTabIndex = 0;
		OptionsController component = _Options.GetComponent<OptionsController>();
		component.ClearAll();
	}

	public void ReturnToGame()
	{
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			GameManager core2 = GM.Core;
			VampireSurvivors.Objects.Characters.CharacterController characterController = core2._003CPausingPlayer_003Ek__BackingField;
			if (characterController._player == null)
			{
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAC9A0");
	}

	public void Quit()
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		config._003CShowQuitDescription_003Ek__BackingField = false;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, time);
		TweenCallback onComplete = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AACA80");
		};
		Tween tween = UITimerHelper.RegisterMillis(420f, onComplete);
	}

	public void OpenOptions()
	{
		_State = PausePageState.OPTIONS;
		_Map.SetActive(value: false);
		_Options.SetActive(value: true);
		GameObject gameObject = _Grimoire.gameObject;
		gameObject.SetActive(value: false);
		OptionsState.LastSelectedTabIndex = 0;
		OptionsController component = _Options.GetComponent<OptionsController>();
		Selectable component2 = _ResumeButton.GetComponent<Selectable>();
		component.OnDown = component2;
		Selectable component3 = _ResumeButton.GetComponent<Selectable>();
		component.OnUp = component3;
		Selectable component4 = _QuitButton.GetComponent<Selectable>();
		component.Quit = component4;
		component.Initialize();
		FormatButtons();
	}

	public void OpenEmpty()
	{
		_State = PausePageState.NONE;
		_Map.SetActive(value: false);
		GameObject gameObject = _Grimoire.gameObject;
		gameObject.SetActive(value: false);
		_Options.SetActive(value: false);
		FormatButtons();
	}

	public void OpenMap()
	{
		_State = PausePageState.MAP;
		_Map.SetActive(value: true);
		_MapManager.Populate();
		_Options.SetActive(value: false);
		GameObject gameObject = _Grimoire.gameObject;
		gameObject.SetActive(value: false);
		FormatButtons();
		Sequence sequence = DOTween.Sequence();
		Sequence sequence2 = TweenSettingsExtensions.AppendInterval(sequence, 0f);
		TweenCallback tweenCallback = delegate
		{
			if (_hasGrimoire)
			{
				GameObject gameObject2 = _OpenGrimoireButton.gameObject;
				gameObject2.SetActive(value: true);
			}
			Transform transform = _PickupsButton.transform;
			GameObject gameObject3 = transform.gameObject;
			gameObject3.SetActive(value: true);
			Transform transform2 = _GuidesButton.transform;
			GameObject gameObject4 = transform2.gameObject;
			gameObject4.SetActive(value: true);
		};
		Tween t;
		object message;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback != null)
					{
						Sequence sequence3 = Sequence.DoInsertCallback(sequence, tweenCallback, ((Tween)sequence).duration);
					}
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				t = null;
				message = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				t = null;
				message = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			t = null;
			message = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message, t);
	}

	public void ToggleGuides()
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_016d: Expected I, but got O
		//IL_018c: Expected O, but got I
		PlayerOptions playerOptions = _playerOptions;
		PlayerOptionsData config = _playerOptions.Config;
		bool flag = !config._003CShowPickups_003Ek__BackingField;
		PlayerOptionsData config2 = _playerOptions.Config;
		config2._003CShowPickups_003Ek__BackingField = flag;
		PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
		mainGameConfig._003CShowPickups_003Ek__BackingField = flag;
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
		playerOptions._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		UpdateGuidesToggleText();
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			GameManager core2 = GM.Core;
			VampireSurvivors.Objects.Characters.CharacterController characterController = core2._003CPausingPlayer_003Ek__BackingField;
			if (characterController._player == null)
			{
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAC9A0");
	}

	public void TogglePickups()
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_00ca: Expected I, but got O
		//IL_00e9: Expected O, but got I
		PlayerOptions playerOptions = _playerOptions;
		PlayerOptionsData config = _playerOptions.Config;
		bool flag = !config._003CShowSmallMapIcons_003Ek__BackingField;
		PlayerOptionsData config2 = _playerOptions.Config;
		config2._003CShowSmallMapIcons_003Ek__BackingField = flag;
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
		playerOptions._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		UpdatePickupsToggleText();
		_MapManager.SetPickups();
	}

	public void OpenGrimoire()
	{
		_State = PausePageState.GRIMOIRE;
		_Map.SetActive(value: false);
		_Options.SetActive(value: false);
		GameObject gameObject = _Grimoire.gameObject;
		gameObject.SetActive(value: true);
		FormatButtons();
		if (!_hasMap)
		{
			return;
		}
		Sequence sequence = DOTween.Sequence();
		Sequence sequence2 = TweenSettingsExtensions.AppendInterval(sequence, 0.1f);
		TweenCallback tweenCallback = delegate
		{
			GameObject gameObject2 = _OpenMapButton.gameObject;
			gameObject2.SetActive(value: true);
		};
		Tween t;
		object message;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback != null)
					{
						Sequence sequence3 = Sequence.DoInsertCallback(sequence, tweenCallback, ((Tween)sequence).duration);
					}
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				t = null;
				message = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				t = null;
				message = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			t = null;
			message = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message, t);
	}

	public unsafe void FormatButtons()
	{
		//IL_0008: Expected O, but got Ref
		//IL_020a: Expected O, but got I
		//IL_0232: Expected O, but got I
		//IL_025f: Expected O, but got I
		//IL_027b: Expected O, but got Ref
		//IL_02cf: Expected O, but got I
		//IL_02e2: Expected O, but got Ref
		//IL_0339: Expected O, but got Ref
		//IL_0390: Expected O, but got Ref
		//IL_03e4: Expected O, but got I
		//IL_03f7: Expected O, but got Ref
		//IL_044e: Expected O, but got Ref
		//IL_04a5: Expected O, but got Ref
		//IL_04f9: Expected O, but got I
		//IL_050c: Expected O, but got Ref
		//IL_0563: Expected O, but got Ref
		//IL_05ef: Expected O, but got I4
		//IL_0d71: Expected O, but got I
		//IL_0606: Unknown result type (might be due to invalid IL or missing references)
		//IL_060b: Expected O, but got Unknown
		//IL_0e6a: Expected O, but got I
		//IL_0e6a: Expected O, but got I
		//IL_0e84: Expected O, but got I
		//IL_0eab: Expected O, but got I
		//IL_0ec0: Expected O, but got I
		//IL_0ee2: Expected O, but got I
		//IL_0ee2: Expected O, but got I
		//IL_06fd: Expected O, but got Ref
		//IL_0756: Expected O, but got I
		//IL_0764: Expected O, but got Ref
		//IL_0800: Expected O, but got I
		//IL_0828: Expected O, but got I
		//IL_0850: Expected O, but got I
		//IL_0878: Expected O, but got I
		//IL_08a4: Expected O, but got I
		//IL_08b9: Expected O, but got I
		//IL_14ec: Expected O, but got I
		//IL_15ab: Expected O, but got I
		//IL_15c0: Expected O, but got I
		//IL_10fd: Expected O, but got I
		//IL_145d: Expected O, but got I4
		//IL_1477: Expected O, but got I4
		//IL_1548: Expected O, but got I4
		//IL_1562: Expected O, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = _OpenMapButton.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = _OpenGrimoireButton.gameObject;
		gameObject2.SetActive(value: false);
		GameObject gameObject3 = _QuitButton.gameObject;
		gameObject3.SetActive(value: false);
		Debug.Log("Setting Quit To False");
		GameObject gameObject4 = _ResumeButton.gameObject;
		gameObject4.SetActive(value: false);
		GameObject gameObject5 = _GuidesButton.gameObject;
		gameObject5.SetActive(value: false);
		GameObject gameObject6 = _PickupsButton.gameObject;
		gameObject6.SetActive(value: false);
		GameObject gameObject7 = _OptionsButton.gameObject;
		gameObject7.SetActive(value: false);
		Selectable component = _ResumeButton.GetComponent<Selectable>();
		Selectable component2 = _QuitButton.GetComponent<Selectable>();
		Selectable component3 = _OptionsButton.GetComponent<Selectable>();
		Selectable component4 = _GuidesButton.GetComponent<Selectable>();
		Selectable component5 = _PickupsButton.GetComponent<Selectable>();
		Selectable component6 = _OpenMapButton.GetComponent<Selectable>();
		Selectable component7 = _OpenGrimoireButton.GetComponent<Selectable>();
		Selectable component8 = _ZoomInMapButton.GetComponent<Selectable>();
		Selectable component9 = _ZoomOutMapButton.GetComponent<Selectable>();
		VampireSurvivors.App.Tools.Extensions.ClearNavigation(component);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7F]");
		VampireSurvivors.App.Tools.Extensions.ClearNavigation((Selectable)0);
		VampireSurvivors.App.Tools.Extensions.ClearNavigation(component3);
		VampireSurvivors.App.Tools.Extensions.ClearNavigation(component4);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
		VampireSurvivors.App.Tools.Extensions.ClearNavigation((Selectable)0);
		VampireSurvivors.App.Tools.Extensions.ClearNavigation(component6);
		VampireSurvivors.App.Tools.Extensions.ClearNavigation(component7);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
		VampireSurvivors.App.Tools.Extensions.ClearNavigation((Selectable)0);
		VampireSurvivors.App.Tools.Extensions.ClearNavigation(component9);
		Navigation navigation = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = component.m_Navigation;
		_ = 4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rax_v24 (UnityEngine.UI.Selectable)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rax_v24 (UnityEngine.UI.Selectable)+48]");
		_ = 0;
		component.navigation = navigation;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7F]");
		Selectable selectable = (Selectable)0;
		Navigation navigation2 = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = selectable.m_Navigation;
		_ = 4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ rax_v43 (UnityEngine.UI.Selectable)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ rax_v43 (UnityEngine.UI.Selectable)+48]");
		_ = 0;
		selectable.navigation = navigation2;
		Navigation navigation3 = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = component3.m_Navigation;
		_ = 4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ rax_v26 (UnityEngine.UI.Selectable)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ rax_v26 (UnityEngine.UI.Selectable)+48]");
		_ = 0;
		component3.navigation = navigation3;
		Navigation navigation4 = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = component4.m_Navigation;
		_ = 4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v27 (UnityEngine.UI.Selectable)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v27 (UnityEngine.UI.Selectable)+48]");
		_ = 0;
		component4.navigation = navigation4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
		Selectable selectable2 = (Selectable)0;
		Navigation navigation5 = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = selectable2.m_Navigation;
		_ = 4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v47 (UnityEngine.UI.Selectable)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v47 (UnityEngine.UI.Selectable)+48]");
		_ = 0;
		selectable2.navigation = navigation5;
		Navigation navigation6 = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = component6.m_Navigation;
		_ = 4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rax_v29 (UnityEngine.UI.Selectable)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rax_v29 (UnityEngine.UI.Selectable)+48]");
		_ = 0;
		component6.navigation = navigation6;
		Navigation navigation7 = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = component7.m_Navigation;
		_ = 4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ rax_v30 (UnityEngine.UI.Selectable)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ rax_v30 (UnityEngine.UI.Selectable)+48]");
		_ = 0;
		component7.navigation = navigation7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
		Selectable selectable3 = (Selectable)0;
		Navigation navigation8 = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = selectable3.m_Navigation;
		_ = 4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ rax_v51 (UnityEngine.UI.Selectable)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ rax_v51 (UnityEngine.UI.Selectable)+48]");
		_ = 0;
		selectable3.navigation = navigation8;
		Navigation navigation9 = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = component9.m_Navigation;
		_ = 4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1907 @ rax_v32 (UnityEngine.UI.Selectable)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1907 @ rax_v32 (UnityEngine.UI.Selectable)+48]");
		_ = 0;
		component9.navigation = navigation9;
		OptionsController component10 = _Options.GetComponent<OptionsController>();
		bool flag = _State == PausePageState.NONE;
		Vector2 vector = default(Vector2);
		if (!flag)
		{
			object obj3 = _State - 1;
			if (flag)
			{
				GameObject gameObject8 = _ResumeButton.gameObject;
				bool active = IsLocalPlayerControllingUi();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7F]");
				((GameObject)0).SetActive(active);
				GameObject gameObject9 = _OptionsButton.gameObject;
				gameObject9.SetActive(value: true);
				GameObject gameObject10 = _PickupsButton.gameObject;
				gameObject10.SetActive(value: true);
				GameObject gameObject11 = _GuidesButton.gameObject;
				gameObject11.SetActive(value: true);
				if (_hasGrimoire)
				{
					GameObject gameObject12 = _OpenGrimoireButton.gameObject;
					gameObject12.SetActive(value: true);
				}
				_Arcanas.SetActive(_arcanasActive);
				_survarotsDisplayContainer.ShowSelf();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
				VampireSurvivors.App.Tools.Extensions.SetNavigationDown((Selectable)num, (Selectable)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
				VampireSurvivors.App.Tools.Extensions.SetNavigationRight((Selectable)0, component9);
				VampireSurvivors.App.Tools.Extensions.SetNavigationDown(component9, component4);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
				VampireSurvivors.App.Tools.Extensions.SetNavigationLeft(component9, (Selectable)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
				VampireSurvivors.App.Tools.Extensions.SetNavigationUp(component3, (Selectable)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
				VampireSurvivors.App.Tools.Extensions.SetNavigationUp((Selectable)num2, (Selectable)0);
				VampireSurvivors.App.Tools.Extensions.SetNavigationUp(component4, component9);
				if (_hasGrimoire)
				{
					VampireSurvivors.App.Tools.Extensions.SetNavigationUp(component7, component9);
				}
				_ResumeButton.anchoredPosition = vector;
				_OpenGrimoireButton.anchoredPosition = vector;
				_GuidesButton.anchoredPosition = vector;
				_PickupsButton.anchoredPosition = vector;
				_OptionsButton.sizeDelta = vector;
				_OptionsButton.anchoredPosition = vector;
				bool flag2 = !_hasGrimoire;
				Selectable target = component4;
				if (!flag2)
				{
					target = component7;
				}
				VampireSurvivors.App.Tools.Extensions.SetNavigationLeft(component, target);
				VampireSurvivors.App.Tools.Extensions.SetNavigationRight(component, component3);
				if (_hasGrimoire)
				{
					VampireSurvivors.App.Tools.Extensions.SetNavigationLeft(component7, component4);
					VampireSurvivors.App.Tools.Extensions.SetNavigationRight(component7, component);
					EventSystem current = EventSystem.current;
					GameObject currentSelected = current.m_CurrentSelected;
					GameObject gameObject13 = component6.gameObject;
					bool flag3 = (object)gameObject13 == null;
					bool flag4 = (object)current.m_CurrentSelected == null;
					object obj4 = flag4 & flag3;
					bool flag5 = obj4 == null;
					object obj5 = !flag5;
					if (obj5 == null)
					{
						bool flag6;
						if ((object)gameObject13 != null)
						{
							if ((object)current.m_CurrentSelected != null)
							{
								object obj6 = (object)current.m_CurrentSelected - (object)gameObject13;
								flag6 = obj6 == null;
							}
							else
							{
								flag6 = ((UnityEngine.Object)gameObject13).m_CachedPtr == (IntPtr)0;
							}
						}
						else
						{
							flag6 = ((UnityEngine.Object)currentSelected).m_CachedPtr == (IntPtr)0;
						}
						if (!flag6)
						{
							goto IL_14d7;
						}
					}
					component7.Select();
				}
				goto IL_14d7;
			}
			object obj7 = obj3 - 1;
			if (!flag)
			{
				if ((nint)obj7 == 1)
				{
					GameObject gameObject14 = _ResumeButton.gameObject;
					bool active2 = IsLocalPlayerControllingUi();
					gameObject14.SetActive(active2);
					GameObject gameObject15 = _QuitButton.gameObject;
					gameObject15.SetActive(value: true);
					_Arcanas.SetActive(value: false);
					GameObject gameObject16 = _survarotsDisplayContainer.gameObject;
					gameObject16.SetActive(value: false);
					_ResumeButton.anchoredPosition = vector;
					_QuitButton.anchoredPosition = vector;
					Navigation navigation10 = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
					_ = component.m_Navigation;
					_ = 4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rax_v24 (UnityEngine.UI.Selectable)+38]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rax_v24 (UnityEngine.UI.Selectable)+48]");
					_ = 0;
					component.navigation = navigation10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7F]");
					Selectable selectable4 = (Selectable)0;
					Navigation navigation11 = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
					_ = selectable4.m_Navigation;
					_ = 4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rsi_v16 (UnityEngine.UI.Selectable)+38]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rsi_v16 (UnityEngine.UI.Selectable)+48]");
					_ = 0;
					selectable4.navigation = navigation11;
					SetNavigationLeft(component, selectable4);
					SetNavigationRight(component, selectable4);
					SetNavigationLeft(selectable4, component);
					SetNavigationRight(selectable4, component);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
					Selectable lastSelectable = ((OptionsController)0).GetLastSelectable();
					SetNavigationUp(component, lastSelectable);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
					Selectable lastSelectable2 = ((OptionsController)0).GetLastSelectable();
					SetNavigationUp(selectable4, lastSelectable2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
					Selectable firstSelectable = ((OptionsController)0).GetFirstSelectable();
					SetNavigationDown(component, firstSelectable);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
					Selectable firstSelectable2 = ((OptionsController)0).GetFirstSelectable();
					SetNavigationDown(selectable4, firstSelectable2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
					((OptionsController)0).SetDownNavigation(component);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
					((OptionsController)0).SetUpNavigation(component);
					component.Select();
				}
			}
			else
			{
				GameObject gameObject17 = _ResumeButton.gameObject;
				bool active3 = IsLocalPlayerControllingUi();
				gameObject17.SetActive(active3);
				GameObject gameObject18 = _OptionsButton.gameObject;
				gameObject18.SetActive(value: true);
				if (_hasMap)
				{
					GameObject gameObject19 = _OpenMapButton.gameObject;
					gameObject19.SetActive(value: true);
				}
				_Arcanas.SetActive(_arcanasActive);
				GameObject gameObject20 = _survarotsDisplayContainer.gameObject;
				gameObject20.SetActive(value: false);
				_ResumeButton.anchoredPosition = vector;
				_OpenMapButton.anchoredPosition = vector;
				_OptionsButton.sizeDelta = vector;
				_OptionsButton.anchoredPosition = vector;
				bool flag7 = !_hasMap;
				Selectable target2 = component3;
				if (!flag7)
				{
					target2 = component6;
				}
				VampireSurvivors.App.Tools.Extensions.SetNavigationLeft(component, target2);
				VampireSurvivors.App.Tools.Extensions.SetNavigationRight(component, component3);
				GrimoireManager grimoire = _Grimoire;
				PageManager pageManager = grimoire._PageManager;
				List<GameObject> pages = pageManager._Pages;
				if (pages._size > 1)
				{
					GrimoireManager grimoire2 = _Grimoire;
					PageManager pageManager2 = grimoire2._PageManager;
					VampireSurvivors.App.Tools.Extensions.SetNavigationUp(component, pageManager2._RightArrow);
					VampireSurvivors.App.Tools.Extensions.SetNavigationUp(component3, pageManager2._RightArrow);
					PageManager pageManager4;
					Selectable target3;
					if (!_hasMap)
					{
						GrimoireManager grimoire3 = _Grimoire;
						PageManager pageManager3 = grimoire3._PageManager;
						VampireSurvivors.App.Tools.Extensions.SetNavigationDown(pageManager3._LeftArrow, component);
						VampireSurvivors.App.Tools.Extensions.SetNavigationDown(pageManager3._RightArrow, component);
						GrimoireManager grimoire4 = _Grimoire;
						pageManager4 = grimoire4._PageManager;
						VampireSurvivors.App.Tools.Extensions.SetNavigationUp(pageManager4._LeftArrow, component);
						target3 = component;
					}
					else
					{
						VampireSurvivors.App.Tools.Extensions.SetNavigationUp(component6, pageManager2._RightArrow);
						GrimoireManager grimoire5 = _Grimoire;
						PageManager pageManager5 = grimoire5._PageManager;
						VampireSurvivors.App.Tools.Extensions.SetNavigationDown(pageManager5._LeftArrow, component6);
						VampireSurvivors.App.Tools.Extensions.SetNavigationDown(pageManager5._RightArrow, component6);
						GrimoireManager grimoire6 = _Grimoire;
						pageManager4 = grimoire6._PageManager;
						VampireSurvivors.App.Tools.Extensions.SetNavigationUp(pageManager4._LeftArrow, component6);
						target3 = component6;
					}
					VampireSurvivors.App.Tools.Extensions.SetNavigationUp(pageManager4._RightArrow, target3);
				}
				VampireSurvivors.App.Tools.Extensions.SetNavigationLeft(component3, component);
				bool flag8 = !_hasMap;
				Selectable target4 = component;
				if (!flag8)
				{
					target4 = component6;
				}
				VampireSurvivors.App.Tools.Extensions.SetNavigationRight(component3, target4);
				if (_hasMap)
				{
					VampireSurvivors.App.Tools.Extensions.SetNavigationLeft(component6, component3);
					VampireSurvivors.App.Tools.Extensions.SetNavigationRight(component6, component);
					EventSystem current2 = EventSystem.current;
					GameObject currentSelected2 = current2.m_CurrentSelected;
					GameObject gameObject21 = component7.gameObject;
					bool flag9 = (object)gameObject21 == null;
					bool flag10 = (object)current2.m_CurrentSelected == null;
					object obj8 = flag10 & flag9;
					bool flag11 = obj8 == null;
					object obj9 = !flag11;
					if (obj9 == null)
					{
						bool flag12;
						if ((object)gameObject21 != null)
						{
							if ((object)current2.m_CurrentSelected != null)
							{
								object obj10 = (object)current2.m_CurrentSelected - (object)gameObject21;
								flag12 = obj10 == null;
							}
							else
							{
								flag12 = ((UnityEngine.Object)gameObject21).m_CachedPtr == (IntPtr)0;
							}
						}
						else
						{
							flag12 = ((UnityEngine.Object)currentSelected2).m_CachedPtr == (IntPtr)0;
						}
						if (!flag12)
						{
							goto IL_120f;
						}
					}
					component6.Select();
				}
			}
		}
		else
		{
			GameObject gameObject22 = _ResumeButton.gameObject;
			bool active4 = IsLocalPlayerControllingUi();
			gameObject22.SetActive(active4);
			GameObject gameObject23 = _OptionsButton.gameObject;
			gameObject23.SetActive(value: true);
			_Arcanas.SetActive(_arcanasActive);
			_survarotsDisplayContainer.ShowSelf();
			_OptionsButton.sizeDelta = vector;
			_OptionsButton.anchoredPosition = vector;
			_ResumeButton.anchoredPosition = vector;
			SetNavigationLeft(component, component3);
			SetNavigationRight(component, component3);
			SetNavigationLeft(component3, component);
			SetNavigationRight(component3, component);
		}
		goto IL_120f;
		IL_15d7:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_120f:
		Selectable up = default(Selectable);
		Selectable right;
		if (_arcanasActive)
		{
			SurvarotsDisplayContainer survarotsDisplayContainer = _survarotsDisplayContainer;
			List<ArcanaCardUI> spawnedCards = survarotsDisplayContainer._spawnedCards;
			Selectable left;
			if (spawnedCards._size > 0)
			{
				if (spawnedCards._size <= 0)
				{
					goto IL_15d7;
				}
				ArcanaCardUI[] items = spawnedCards._items;
				left = items[0].GetComponent<Selectable>();
			}
			else
			{
				left = null;
			}
			_arcanasDisplayContainer.ConfigureNavigationForArcanaCards(component, left, null, up);
			if (_arcanasActive)
			{
				ArcanaDisplayContainer arcanasDisplayContainer = _arcanasDisplayContainer;
				List<ArcanaCardUI> spawnedCards2 = arcanasDisplayContainer._spawnedCards;
				if (spawnedCards2._size > 0)
				{
					if (spawnedCards2._size > 0)
					{
						ArcanaCardUI[] items2 = spawnedCards2._items;
						right = items2[0].GetComponent<Selectable>();
						goto IL_1391;
					}
					goto IL_15d7;
				}
			}
		}
		right = null;
		goto IL_1391;
		IL_1391:
		_survarotsDisplayContainer.ConfigureNavigationForCharacterCards(component, null, right, up);
		return;
		IL_14d7:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
		VampireSurvivors.App.Tools.Extensions.SetNavigationLeft(component4, (Selectable)0);
		bool flag13 = !_hasGrimoire;
		Selectable target5 = component;
		if (!flag13)
		{
			target5 = component7;
		}
		VampireSurvivors.App.Tools.Extensions.SetNavigationRight(component4, target5);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
		VampireSurvivors.App.Tools.Extensions.SetNavigationLeft((Selectable)0, component3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
		VampireSurvivors.App.Tools.Extensions.SetNavigationRight((Selectable)0, component4);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
		VampireSurvivors.App.Tools.Extensions.SetNavigationRight(component3, (Selectable)0);
		VampireSurvivors.App.Tools.Extensions.SetNavigationLeft(component3, component);
		goto IL_120f;
	}

	protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
	{
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			return core._003CPausingPlayer_003Ek__BackingField;
		}
		return (VampireSurvivors.Objects.Characters.CharacterController)(object)new NullReferenceException();
	}

	private void InitToggles()
	{
		UpdatePickupsToggleText();
		_MapManager.SetPickups();
		UpdateGuidesToggleText();
	}

	private void UpdatePickupsToggleText()
	{
		Localize componentInChildren = _PickupsButton.GetComponentInChildren<Localize>();
		PlayerOptionsData config = _playerOptions.Config;
		bool flag = !config._003CShowSmallMapIcons_003Ek__BackingField;
		string term = "lang/pause_showPickups";
		if (!flag)
		{
			term = "lang/pause_hidePickups";
		}
		componentInChildren.Term = term;
	}

	private void UpdateGuidesToggleText()
	{
		Localize componentInChildren = _GuidesButton.GetComponentInChildren<Localize>();
		PlayerOptionsData config = _playerOptions.Config;
		bool flag = !config._003CShowPickups_003Ek__BackingField;
		string term = "lang/pause_showGuides";
		if (!flag)
		{
			term = "lang/pause_hideGuides";
		}
		componentInChildren.Term = term;
	}

	private void HideAllPanels()
	{
		GameObject gameObject = _Grimoire.gameObject;
		gameObject.SetActive(value: false);
		_Map.SetActive(value: false);
	}

	public PausePage()
	{
		List<PauseEquipmentPanel> equipmentPanels = new List<PauseEquipmentPanel>();
		_EquipmentPanels = equipmentPanels;
		base._002Ector();
	}

	private void _003CQuit_003Eb__46_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AACA80");
	}

	private void _003COpenMap_003Eb__49_0()
	{
		if (_hasGrimoire)
		{
			GameObject gameObject = _OpenGrimoireButton.gameObject;
			gameObject.SetActive(value: true);
		}
		Transform transform = _PickupsButton.transform;
		GameObject gameObject2 = transform.gameObject;
		gameObject2.SetActive(value: true);
		Transform transform2 = _GuidesButton.transform;
		GameObject gameObject3 = transform2.gameObject;
		gameObject3.SetActive(value: true);
	}

	private void _003COpenGrimoire_003Eb__52_0()
	{
		GameObject gameObject = _OpenMapButton.gameObject;
		gameObject.SetActive(value: true);
	}
}
