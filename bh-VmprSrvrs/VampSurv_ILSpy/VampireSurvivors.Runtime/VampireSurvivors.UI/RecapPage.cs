using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Data.Adventures;
using VampireSurvivors.App.Framework.System;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Scripts.Data;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Platforms.Standalone;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Spells;
using Zenject;

namespace VampireSurvivors.UI;

public class RecapPage : BaseUIPage
{
	public struct StatsDisplay
	{
		public string Name;

		public int Level;

		public string WeaponFrameName;

		public string WeaponTextureName;

		public float InflictedDamage;

		public float Lifetime;

		public float Dps;

		public bool IsBestDps;

		public bool IsBestRaw;

		public CharacterType Owner;

		public Color NameColor;
	}

	private class CustomPickupData
	{
		public ItemType? ItemType;

		public int Amount;

		public string FrameName;

		public string TextureName;
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Equipment, bool> _003C_003E9__72_0;

		public static Func<CustomPickupData, int> _003C_003E9__76_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CAddWeapons_003Eb__72_0(Equipment x)
		{
			//IL_0061: Expected I4, but got O
			if ((object)x != null)
			{
				if (x.IsPowerup())
				{
					return false;
				}
				return x._003CShowInRecap_003Ek__BackingField;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal int _003CAddCollectedItems_003Eb__76_0(CustomPickupData o)
		{
			//IL_0035: Expected I4, but got O
			if (o != null)
			{
				return o.Amount;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	private sealed class _003C_003Ec__DisplayClass63_0
	{
		public RecapPage _003C_003E4__this;

		public bool doReturnToLanding;

		internal void _003CCheckCompleteAdventure_003Eb__0()
		{
			if (doReturnToLanding)
			{
				_003C_003E4__this.ReturnToLanding();
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass76_0
	{
		public ItemType itemType;

		internal bool _003CAddCollectedItems_003Eb__1(CustomPickupData data)
		{
			//IL_005b: Expected I4, but got O
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected I4, but got Unknown
			if (data != null)
			{
				object obj = (object?)data.ItemType >> 32;
				object obj2 = obj - itemType;
				bool flag = obj2 == null;
				return (byte)((flag & (_003F?)data.ItemType) ? 1 : 0) != 0;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass82_0
	{
		public float start;

		public RecapPage _003C_003E4__this;

		internal float _003CRewardExtraGoldFromAd_003Eb__0()
		{
			return start;
		}

		internal void _003CRewardExtraGoldFromAd_003Eb__1(float x)
		{
			start = x;
		}

		internal void _003CRewardExtraGoldFromAd_003Eb__2()
		{
			RecapPage recapPage = _003C_003E4__this;
			PropertyUI gold = recapPage._Gold;
			double value = Math.Ceiling(start);
			NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
			string text = System.Number.FormatDouble(value, "F0", currentInfo);
			gold.Value.text = text;
		}
	}

	private sealed class _003CSelectDoneDelayed_003Ed__64(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public RecapPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0096: Expected I4, but got I8
			//IL_0102: Expected O, but got I4
			RecapPage recapPage = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				Debug.Log("[RecapPage] SelectDoneDelayed before yield WaitForEndOfFrame");
				object obj = Application.isBatchMode;
				WaitForEndOfFrame waitForEndOfFrame = ((obj == null) ? new WaitForEndOfFrame() : null);
				_003C_003E2__current = waitForEndOfFrame;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				Debug.Log("[RecapPage] SelectDoneDelayed before _DoneButton.Select()");
				recapPage._DoneButton.Select();
				Debug.Log("[RecapPage] SelectDoneDelayed after _DoneButton.Select()");
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

	private TextMeshProUGUI _MapTitle;

	private TextMeshProUGUI _CharacterName;

	private TextMeshProUGUI _EggCount;

	private PropertyUI _Survived;

	private PropertyUI _Gold;

	private PropertyUI _Levels;

	private PropertyUI _Enemies;

	private RectTransform _WeaponRecapContainer;

	private RectTransform _WeaponIcons;

	private RectTransform _StatIcons;

	private RectTransform _LootIcons;

	private GameObject _WeaponRecapPrefab;

	private GameObject _AchievementsPanel;

	private IconQuantityUI _QuantityIconPrefab;

	private Image _CharacterIcon;

	private AchievementPopup _AchievementPopup;

	private Selectable _DoneButton;

	private GameObject _HideAchievementsButton;

	private GameObject _AcceptAchievementsButton;

	private TickBoxUI _AcceptAchievementsTickBoxUI;

	private GameObject _DestructablePrefab;

	private GameObject _ArcanaPrefab;

	private RectTransform _ArcanaContainer;

	private RectTransform _TweenOrigin;

	private GameObject _UnlockBadge;

	private TextMeshProUGUI _UnlockCountText;

	private Button _WatchAdForExtraGoldButton;

	private ParticleEmitterManager _CoinEmitter;

	private GameObject _PreviousCharacterButton;

	private GameObject _NextCharacterButton;

	private Button _openLogsButton;

	private FakeSliderHandleController _sliderHandle;

	private SignalBus _signalBus;

	private PlayerOptions _playerOptions;

	private AchievementManager _achievements;

	private DataManager _dataManager;

	private PlayerStats _playerStats;

	private ArcanaManager _arcanaManager;

	private UnityServicesManager _unityServicesManager;

	private AdventureManager _adventureManager;

	private SpellsManager _spellsManager;

	private AchievementManager _achievementManager;

	private ParticleSystem _particles;

	private StringBuilder _timeFormatStringBuilder;

	private RectTransform _rectTransform;

	private List<Tween> _activeTweens;

	private VampireSurvivors.Objects.Characters.CharacterController _currentCharacter;

	private int _currentCharacterIndex;

	private List<GameObject> _spawned;

	private Dictionary<CharacterType, GameObject> _characterWeapons;

	private bool _isFirstShow;

	private int _selectedCharacterIndex;

	private Color hiddenWeaponNameColor;

	private void Construct(SignalBus signal, AchievementManager achievement, PlayerOptions playerOptions, DataManager dataManager, PlayerStats playerStats, ArcanaManager arcanaManager, UnityServicesManager unityServicesManager, AdventureManager adventureManager, SpellsManager spellsManager, AchievementManager achievementManager)
	{
		//IL_0038: Expected O, but got I
		_signalBus = signal;
		_achievements = achievement;
		_playerOptions = playerOptions;
		_dataManager = (DataManager)(object)spellsManager;
		_playerStats = (PlayerStats)(object)achievementManager;
		IntPtr intPtr = default(IntPtr);
		_arcanaManager = (ArcanaManager)(nint)intPtr;
		UnityServicesManager unityServicesManager2 = default(UnityServicesManager);
		_unityServicesManager = unityServicesManager2;
		AdventureManager adventureManager2 = default(AdventureManager);
		_adventureManager = adventureManager2;
		SpellsManager spellsManager2 = default(SpellsManager);
		_spellsManager = spellsManager2;
		AchievementManager achievementManager2 = default(AchievementManager);
		_achievementManager = achievementManager2;
	}

	public void HideAchievements()
	{
		//IL_024b: Expected O, but got I4
		//IL_01e6: Expected F4, but got I4
		//IL_00fb->IL01eb: Incompatible stack heights: 1 vs 0
		//IL_005b->IL01eb: Incompatible stack heights: 1 vs 0
		//IL_0134->IL01eb: Incompatible stack heights: 1 vs 0
		//IL_0094->IL01eb: Incompatible stack heights: 1 vs 0
		//IL_0290->IL01eb: Incompatible stack heights: 1 vs 0
		//IL_0180->IL01eb: Incompatible stack heights: 1 vs 0
		//IL_01b6->IL01eb: Incompatible stack heights: 1 vs 0
		GameObject achievementsPanel = _AchievementsPanel;
		bool flag2 = default(bool);
		GameObject unlockBadge;
		string text;
		bool active;
		if ((object)_AchievementsPanel != null)
		{
			bool flag = ((UnityEngine.Object)achievementsPanel).m_CachedPtr == (IntPtr)0;
			object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)achievementsPanel).m_CachedPtr);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			if (obj == null)
			{
				string translation = LocalizationManager.GetTranslation("lang/postGame_hideAchievements", FixForRTL: true, 0, ignoreRTLnumbers: true, flag2, localParametersRoot, overrideLanguage, allowLocalizedParameters);
				if ((object)_AchievementsPanel != null)
				{
					_AchievementsPanel.SetActive(value: true);
					unlockBadge = _UnlockBadge;
					if ((object)_UnlockBadge != null)
					{
						text = translation;
						active = true;
						goto IL_026b;
					}
				}
			}
			else
			{
				string translation2 = LocalizationManager.GetTranslation("lang/postGame_showAchievements", FixForRTL: true, 0, ignoreRTLnumbers: true, flag2, localParametersRoot, overrideLanguage, allowLocalizedParameters);
				if ((object)_AchievementsPanel != null)
				{
					_AchievementsPanel.SetActive(value: false);
					unlockBadge = _UnlockBadge;
					if ((object)_UnlockBadge != null)
					{
						text = translation2;
						active = false;
						goto IL_026b;
					}
				}
			}
		}
		goto IL_01eb;
		IL_026b:
		unlockBadge.SetActive(active);
		if (text != null)
		{
			string text2 = text.Replace("\\n", "<br>");
			if ((object)_HideAchievementsButton != null)
			{
				TextMeshProUGUI componentInChildren = _HideAchievementsButton.GetComponentInChildren<TextMeshProUGUI>(includeInactive: false);
				if ((object)componentInChildren != null)
				{
					componentInChildren.text = text2;
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, flag2 ? 1 : 0);
					return;
				}
			}
		}
		goto IL_01eb;
		IL_01eb:
		throw new NullReferenceException();
	}

	public void AcceptAchievementsToggle(bool _ = true)
	{
		AchievementManager achievements = _achievements;
		if (!achievements.allowUnlocking)
		{
			achievements.allowUnlocking = true;
			_AcceptAchievementsTickBoxUI.SetOn();
		}
		else
		{
			achievements.allowUnlocking = false;
			_AcceptAchievementsTickBoxUI.SetOff();
		}
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
	}

	public void DoneClicked()
	{
		Debug.Log("[RecapPage] ReturnToLanding start");
		AchievementManager achievementManager = _achievementManager;
		if (!achievementManager.allowUnlocking)
		{
			Debug.Log("[RecapPage] ReturnToLanding allowUnlocking = false");
		}
		else
		{
			Debug.Log("[RecapPage] ReturnToLanding allowUnlocking = true");
			GameManager core = GM.Core;
			if (core._003CStartedAsOnlineMultiplayerRun_003Ek__BackingField)
			{
				_playerOptions.ApplyClientConfigWithRunProgress();
			}
			_achievementManager.UnlockAchievementsAndGiveRewards();
			AchievementData achievementData = CheckCompleteAdventure(out var _);
		}
		ReturnToLanding();
	}

	public void ReturnToLanding()
	{
		_achievementManager.UnlockAchievementsAndGiveRewards();
		List<AchievementData> list = _achievementManager.CheckAllAchievements();
		_achievementManager.UnlockAchievementsAndGiveRewards();
		Debug.Log("[RecapPage] ReturnToLanding before DestroyOnlineConfigs");
		_playerOptions.DestroyOnlineConfigs();
		Debug.Log("[RecapPage] after DestroyOnlineConfigs");
		AchievementManager achievementManager = _achievementManager;
		if (achievementManager.allowUnlocking)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config._003CNextAutoSelectStage_003Ek__BackingField != StageType.FOREST)
			{
				PlayerOptionsData config2 = _playerOptions.Config;
				PlayerOptionsData config3 = _playerOptions.Config;
				config2._003CSelectedStage_003Ek__BackingField = config3._003CNextAutoSelectStage_003Ek__BackingField;
				PlayerOptionsData config4 = _playerOptions.Config;
				config4._003CNextAutoSelectStage_003Ek__BackingField = StageType.FOREST;
			}
			_playerOptions.Save(commitImmediately: true, createBackup: true);
		}
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, time);
		Debug.Log("[RecapPage] ReturnToLanding before delayed SnapshotRecap");
		Action onComplete = delegate
		{
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Expected O, but got Unknown
			Debug.Log("[RecapPage] ReturnToLanding before RecapPageCompletedSignal fire");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj3 = default(object);
			object obj2 = obj3 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		};
		GameManager._003CSnapshotRecap_003Ed__449 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = GM.Core;
		obj.onComplete = onComplete;
		Coroutine coroutine = StartCoroutine(obj);
	}

	public void WatchAdForExtraGold()
	{
		_playerOptions.Save();
	}

	public void NextCharacter()
	{
		//IL_0027: Expected O, but got I4
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected I4, but got Unknown
		GameManager core = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = core._characters;
		object obj = _selectedCharacterIndex + 1;
		int num = (_selectedCharacterIndex = obj % characters._size);
		GameManager core2 = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = core2._characters;
		if (num < characters2._size)
		{
			VampireSurvivors.Objects.Characters.CharacterController[] items = characters2._items;
			_currentCharacter = items[num];
			RefreshCharacterSpecificStats();
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void PreviousCharacter()
	{
		//IL_0027: Expected O, but got I4
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected I4, but got Unknown
		GameManager core = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = core._characters;
		object obj = _selectedCharacterIndex - 1;
		object obj2 = characters._size + obj;
		int num = (_selectedCharacterIndex = obj2 % characters._size);
		GameManager core2 = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = core2._characters;
		if (num < characters2._size)
		{
			VampireSurvivors.Objects.Characters.CharacterController[] items = characters2._items;
			_currentCharacter = items[num];
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 178 Invalid \"Jump target not found in method: 0x186D65F00\"");
			throw new NullReferenceException();
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void RefreshCharacterSpecificStats()
	{
		//IL_0627: Expected I, but got O
		//IL_066a: Expected I, but got O
		//IL_00b1: Expected I, but got O
		//IL_0093: Expected O, but got I
		//IL_014e: Expected O, but got I4
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected I4, but got Unknown
		//IL_01d3: Expected O, but got I4
		//IL_06c5: Expected I4, but got O
		//IL_06dd: Expected I, but got O
		//IL_024e: Expected O, but got I4
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected I4, but got Unknown
		//IL_02d3: Expected O, but got I4
		//IL_0752: Expected I4, but got O
		//IL_07c1: Expected O, but got I4
		//IL_0805: Expected I, but got O
		//IL_02fd: Expected I, but got O
		//IL_0368: Expected I, but got O
		//IL_0427: Expected I, but got O
		//IL_03c0: Expected I, but got O
		//IL_04a6: Expected I, but got O
		//IL_04ff: Expected O, but got I
		//IL_0717->IL0604: Incompatible stack heights: 1 vs 0
		//IL_020a->IL0604: Incompatible stack heights: 1 vs 0
		//IL_0231->IL0604: Incompatible stack heights: 1 vs 0
		//IL_0786->IL0604: Incompatible stack heights: 2 vs 0
		//IL_080e->IL0604: Incompatible stack heights: 3 vs 0
		//IL_0306->IL0604: Incompatible stack heights: 3 vs 0
		//IL_0371->IL0604: Incompatible stack heights: 3 vs 0
		//IL_0430->IL0604: Incompatible stack heights: 3 vs 0
		//IL_03c9->IL0604: Incompatible stack heights: 3 vs 0
		//IL_04c3->IL0604: Incompatible stack heights: 4 vs 0
		//IL_053a->IL0604: Incompatible stack heights: 5 vs 0
		//IL_0604->IL0813: Incompatible stack heights: 5 vs 3
		//IL_0566->IL0604: Incompatible stack heights: 5 vs 0
		//IL_0590->IL0604: Incompatible stack heights: 5 vs 0
		//IL_05ba->IL0604: Incompatible stack heights: 5 vs 0
		bool flag = _spawned == null;
		nint num = (nint)this;
		if (!flag)
		{
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			while (enumerator.MoveNext())
			{
				UnityEngine.Object.Destroy(null, 0f);
			}
			num = (nint)_spawned;
			if (_spawned != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v20 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+1C]");
				_ = (nint)0 + (nint)1;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v20 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v20 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+10]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v20 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+18]");
					Array.Clear((Array)num2, 0, 0);
				}
				object nextCharacterButton = _NextCharacterButton;
				nint num3 = (nint)typeof(GM);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ rax_v31 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
				num = 0;
				GameManager core = GM.Core;
				if ((object)GM.Core != null)
				{
					List<VampireSurvivors.Objects.Characters.CharacterController> characters = core._characters;
					if (core._characters != null && (object)_NextCharacterButton != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rsi_v11 (System.Object)+10]");
						bool flag2 = (nint)0 == 0;
						object obj = characters._size - 1;
						int num4 = characters._size ^ 1;
						int num5 = characters._size ^ obj;
						int num6 = num4 & num5;
						bool flag3 = num6 < 0;
						bool flag4 = (nint)obj < 0;
						bool flag5 = obj == null;
						bool flag6 = flag4 == flag3;
						bool flag7 = !flag5;
						object obj2 = flag7 & flag6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rsi_v11 (System.Object)+10]");
						GameObject.SetActive_Injected((IntPtr)0, (byte)(int)obj2 != 0);
						object previousCharacterButton = _PreviousCharacterButton;
						nint num7 = (nint)typeof(GM);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v804 @ rax_v38 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
						nint num8 = 0;
						GameManager core2 = GM.Core;
						bool flag8 = (object)GM.Core == null;
						num = num8;
						if (!flag8)
						{
							List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = core2._characters;
							bool flag9 = core2._characters == null;
							num = num8;
							if (!flag9)
							{
								bool flag10 = (object)_PreviousCharacterButton == null;
								num = num8;
								if (!flag10)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rsi_v14 (System.Object)+10]");
									bool flag11 = (nint)0 == 0;
									object obj3 = characters2._size - 1;
									int num9 = characters2._size ^ 1;
									int num10 = characters2._size ^ obj3;
									int num11 = num9 & num10;
									bool flag12 = num11 < 0;
									bool flag13 = (nint)obj3 < 0;
									bool flag14 = obj3 == null;
									bool flag15 = flag13 == flag12;
									bool flag16 = !flag14;
									object obj4 = flag16 & flag15;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rsi_v14 (System.Object)+10]");
									GameObject.SetActive_Injected((IntPtr)0, (byte)(int)obj4 != 0);
									object previousCharacterButton2 = _PreviousCharacterButton;
									bool flag17 = (object)_PreviousCharacterButton == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rsi_v14 (System.Object)+10]");
									num = 0;
									if (!flag17)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rsi_v17 (System.Object)+10]");
										bool flag18 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rsi_v17 (System.Object)+10]");
										object obj5 = GameObject.get_activeInHierarchy_Injected((IntPtr)0);
										if (obj5 != null)
										{
											bool flag19 = (object)_PreviousCharacterButton == null;
											num = (nint)_PreviousCharacterButton;
											if (flag19)
											{
												goto IL_0604;
											}
											VampireSurvivors.App.Tools.Extensions.SetNavigationRight(target: _PreviousCharacterButton.GetComponent<Selectable>(), origin: _sliderHandle);
										}
										if (_isFirstShow)
										{
											bool flag20 = Multiplayer == null;
											num = (nint)Multiplayer;
											if (flag20)
											{
												goto IL_0604;
											}
											int localPlayerCount = Multiplayer.GetLocalPlayerCount();
											if (localPlayerCount > 1)
											{
												bool flag21 = Multiplayer == null;
												num = (nint)Multiplayer;
												if (flag21)
												{
													goto IL_0604;
												}
												Multiplayer.SelectPlayerOneToControlUI(exclusiveUIControl: true);
											}
											_selectedCharacterIndex = 0;
										}
										GameManager core3 = GM.Core;
										bool flag22 = (object)GM.Core == null;
										num = (nint)typeof(GM);
										if (!flag22)
										{
											List<VampireSurvivors.Objects.Characters.CharacterController> characters3 = core3._characters;
											bool flag23 = core3._characters == null;
											num = (nint)typeof(GM);
											if (!flag23)
											{
												if (characters3._size == 0)
												{
													return;
												}
												GameManager core4 = GM.Core;
												List<VampireSurvivors.Objects.Characters.CharacterController> characters4 = core4._characters;
												int selectedCharacterIndex = _selectedCharacterIndex;
												bool flag24 = _selectedCharacterIndex >= characters4._size;
												num = (nint)characters4._items;
												if (characters4._items != null)
												{
													int selectedCharacterIndex2 = _selectedCharacterIndex;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v20 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+18]");
													bool flag25 = (nint)selectedCharacterIndex2 >= (nint)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v20 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+20+v141 @ rax_v56 (System.Int32)*8]");
													_currentCharacter = (VampireSurvivors.Objects.Characters.CharacterController)0;
													SetHeader();
													SetCharacter();
													SetRunStats();
													if (_isFirstShow)
													{
														AddCollectedItems();
														AddArcanas();
														AddPowerUps();
														goto IL_05ee;
													}
													if ((object)_WeaponIcons != null)
													{
														Transform transform = _WeaponIcons.transform;
														if ((object)transform != null)
														{
															Transform parent = transform.parent;
															if ((object)parent != null)
															{
																VerticalLayoutGroup component = parent.GetComponent<VerticalLayoutGroup>();
																if ((object)component != null)
																{
																	component.enabled = false;
																	goto IL_05ee;
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
		goto IL_0604;
		IL_0604:
		throw new NullReferenceException();
		IL_05ee:
		AddWeapons();
		_isFirstShow = false;
	}

	protected unsafe override void OnShowStart(GameObject g)
	{
		//IL_0039: Expected I, but got O
		//IL_0063: Expected I, but got O
		//IL_011b: Expected I, but got O
		//IL_00c9: Expected I, but got O
		//IL_013e: Expected I, but got O
		//IL_128b: Expected I, but got O
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected I, but got Unknown
		//IL_12d2: Expected I, but got O
		//IL_0347: Expected I, but got O
		//IL_023a: Expected I, but got O
		//IL_04a0: Expected I, but got O
		//IL_0269: Expected I, but got O
		//IL_03a0: Expected I, but got O
		//IL_04d6: Expected I, but got O
		//IL_03bb: Expected I, but got O
		//IL_04f2: Expected I, but got O
		//IL_050b: Expected I, but got O
		//IL_02c5: Expected I, but got O
		//IL_02f4: Expected I, but got O
		//IL_042b: Expected I, but got O
		//IL_0749: Expected I, but got O
		//IL_045a: Expected I, but got O
		//IL_0786: Expected I, but got O
		//IL_05c1: Expected I, but got O
		//IL_05f7: Expected I, but got O
		//IL_07a1: Expected O, but got Ref
		//IL_060e: Expected I, but got O
		//IL_087d: Expected I, but got O
		//IL_0670: Expected I, but got O
		//IL_06a6: Expected I, but got O
		//IL_0899: Expected I, but got O
		//IL_06bd: Expected I, but got O
		//IL_0944: Expected I, but got O
		//IL_0978: Expected I, but got O
		//IL_1377: Expected I, but got O
		//IL_09c2: Expected I, but got O
		//IL_0c22: Expected I, but got O
		//IL_0d0f: Expected I, but got O
		//IL_0a2d: Expected I, but got O
		//IL_0c70: Expected I, but got O
		//IL_0d3a: Expected I, but got O
		//IL_0a6e: Expected I, but got O
		//IL_0aa6: Expected I, but got O
		//IL_0dba: Expected I, but got O
		//IL_0ccd: Expected I, but got O
		//IL_0b39: Expected O, but got I
		//IL_0acb: Expected I, but got O
		//IL_0b93: Expected I, but got O
		//IL_0bcb: Expected I, but got O
		//IL_0f1a: Expected O, but got I4
		//IL_0f3d: Expected O, but got I4
		//IL_16c8: Expected O, but got I4
		//IL_16ec: Expected O, but got I4
		//IL_0f7c: Expected O, but got I4
		//IL_1519: Expected O, but got I
		//IL_0ff0: Expected O, but got I
		//IL_1556: Expected O, but got I
		//IL_1056: Expected O, but got I
		//IL_1593: Expected O, but got I
		//IL_10bc: Expected O, but got I
		//IL_15d0: Expected O, but got I
		//IL_1122: Expected O, but got I
		//IL_160d: Expected O, but got I
		//IL_1188: Expected O, but got I
		//IL_17b3: Expected O, but got I
		//IL_1684: Expected I, but got O
		//IL_102c->IL16fd: Incompatible stack heights: 4 vs 3
		//IL_1092->IL1724: Incompatible stack heights: 4 vs 3
		//IL_10f8->IL174b: Incompatible stack heights: 4 vs 3
		//IL_115e->IL1772: Incompatible stack heights: 4 vs 3
		//IL_11c4->IL1799: Incompatible stack heights: 4 vs 3
		//IL_11f1->IL1635: Incompatible stack heights: 4 vs 3
		base.OnShowStart(g);
		Debug.Log("[RecapPage] OnShowStart");
		OnlineErrorManager.CloseErrorPopupIfExists();
		AchievementManager achievementManager = _achievementManager;
		bool flag = _achievementManager == null;
		nint num = unchecked((nint)null);
		bool active;
		GameObject acceptAchievementsButton;
		if (!flag)
		{
			achievementManager.allowUnlocking = true;
			nint num2 = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rax_v62 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
			num = 0;
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				if (!core._003CStartedAsOnlineMultiplayerRun_003Ek__BackingField)
				{
					num = (nint)_AcceptAchievementsButton;
					if ((object)_AcceptAchievementsButton != null)
					{
						active = false;
						acceptAchievementsButton = _AcceptAchievementsButton;
						goto IL_1274;
					}
				}
				else
				{
					bool flag2 = (object)_AcceptAchievementsTickBoxUI == null;
					num = (nint)_AcceptAchievementsTickBoxUI;
					if (!flag2)
					{
						_AcceptAchievementsTickBoxUI.SetOn();
						num = (nint)_AcceptAchievementsButton;
						if ((object)_AcceptAchievementsButton != null)
						{
							active = true;
							acceptAchievementsButton = _AcceptAchievementsButton;
							goto IL_1274;
						}
					}
				}
			}
		}
		goto IL_1239;
		IL_1274:
		acceptAchievementsButton.SetActive(active);
		num = (nint)_signalBus;
		if (_signalBus != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA09F0");
			RectTransform component = GetComponent<RectTransform>();
			_rectTransform = component;
			StringBuilder timeFormatStringBuilder = new StringBuilder(10, 2147483647);
			_timeFormatStringBuilder = timeFormatStringBuilder;
			num = (nint)(this + 568);
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				bool flag3 = config == null;
				num = (nint)_playerOptions;
				if (!flag3)
				{
					if (config._003CCharacterEggInfo_003Ek__BackingField == null)
					{
						goto IL_031f;
					}
					PlayerOptionsData config2 = _playerOptions.Config;
					bool flag4 = config2 == null;
					num = (nint)_playerOptions;
					if (!flag4)
					{
						bool flag5 = config2._003CCharacterEggInfo_003Ek__BackingField == null;
						num = (nint)config2._003CCharacterEggInfo_003Ek__BackingField;
						if (!flag5)
						{
							int num3 = ((Dictionary<System.Int32Enum, object>)(object)config2._003CCharacterEggInfo_003Ek__BackingField).FindEntry((System.Int32Enum)48);
							if (flag5)
							{
								goto IL_031f;
							}
							PlayerOptionsData config3 = _playerOptions.Config;
							bool flag6 = config3 == null;
							num = (nint)_playerOptions;
							if (!flag6)
							{
								bool flag7 = config3._003CCharacterEggInfo_003Ek__BackingField == null;
								num = (nint)config3._003CCharacterEggInfo_003Ek__BackingField;
								if (!flag7)
								{
									bool flag8 = ((Dictionary<System.Int32Enum, object>)(object)config3._003CCharacterEggInfo_003Ek__BackingField).Remove((System.Int32Enum)48);
									goto IL_031f;
								}
							}
						}
					}
				}
			}
		}
		goto IL_1239;
		IL_0485:
		bool flag9 = _playerOptions == null;
		num = (nint)_playerOptions;
		if (!flag9)
		{
			PlayerOptionsData config4 = _playerOptions.Config;
			bool flag10 = config4 == null;
			num = (nint)_playerOptions;
			if (!flag10)
			{
				nint num4 = (nint)typeof(GM);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1689 @ rcx_v66 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
				nint num5 = 0;
				num = (nint)GM.Core;
				if ((object)GM.Core != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rcx_v51 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+3E0]");
					float num6 = 0f + config4._003CLifetimeSurvived_003Ek__BackingField;
					config4._003CLifetimeSurvived_003Ek__BackingField = num6;
					if (_adventureManager == null || !((Dictionary<CharacterType, float>)(object)typeof(AdventureManager)).Remove((CharacterType)num5))
					{
						goto IL_0709;
					}
					bool flag11 = _playerOptions == null;
					num = (nint)_playerOptions;
					if (!flag11)
					{
						PlayerOptionsData config5 = _playerOptions.Config;
						bool flag12 = config5 == null;
						num = (nint)_playerOptions;
						if (!flag12)
						{
							num = (nint)GM.Core;
							if ((object)GM.Core != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rcx_v51 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+3E0]");
								float num7 = 0f + config5._003CTotalAdventurePlaytime_003Ek__BackingField;
								config5._003CTotalAdventurePlaytime_003Ek__BackingField = num7;
								bool flag13 = _playerOptions == null;
								num = (nint)_playerOptions;
								if (!flag13)
								{
									PlayerOptionsData config6 = _playerOptions.Config;
									bool flag14 = config6 == null;
									num = (nint)_playerOptions;
									if (!flag14)
									{
										num = (nint)GM.Core;
										if ((object)GM.Core != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rcx_v51 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+3E0]");
											float num8 = 0f + config6._003CAllTimeAdventurePlaytime_003Ek__BackingField;
											config6._003CAllTimeAdventurePlaytime_003Ek__BackingField = num8;
											goto IL_0709;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_1239;
		IL_1239:
		throw new NullReferenceException();
		IL_1385:
		PlayerOptions playerOptions = _playerOptions;
		if (_playerOptions != null)
		{
			GameObject mainGameConfig = (GameObject)(object)playerOptions._mainGameConfig;
			if (playerOptions._mainGameConfig != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v759 @ rbx_v33 (UnityEngine.GameObject)+188]");
				num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v759 @ rbx_v33 (UnityEngine.GameObject)+188]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rcx_v51 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+18]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rcx_v51 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+18]");
						List<VampireSurvivors.Objects.Characters.CharacterController> list = (List<VampireSurvivors.Objects.Characters.CharacterController>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						object obj = default(object);
						if ((nint)obj != -1)
						{
							Debug.Log("Unlocking Adventures: Player has collected RELIC_ATLAS");
							PlayerOptions playerOptions2 = _playerOptions;
							bool flag15 = _playerOptions == null;
							num = unchecked((nint)"Unlocking Adventures: Player has collected RELIC_ATLAS");
							if (!flag15)
							{
								PlayerOptionsData mainGameConfig2 = playerOptions2._mainGameConfig;
								bool flag16 = playerOptions2._mainGameConfig == null;
								num = unchecked((nint)"Unlocking Adventures: Player has collected RELIC_ATLAS");
								if (!flag16)
								{
									mainGameConfig2._003CShouldPlayAdventureReveal_003Ek__BackingField = true;
									goto IL_135c;
								}
							}
							goto IL_1239;
						}
					}
					goto IL_135c;
				}
			}
		}
		goto IL_1239;
		IL_0709:
		Debug.Log("[RecapPage] OnShowStart pre foreach on all players");
		List<VampireSurvivors.Objects.Characters.CharacterController> list2 = new List<VampireSurvivors.Objects.Characters.CharacterController>();
		GameManager core2 = GM.Core;
		bool flag17 = (object)GM.Core == null;
		num = (nint)typeof(GM);
		if (!flag17)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> list = core2._characters;
			bool flag18 = core2._characters == null;
			num = (nint)typeof(GM);
			if (!flag18)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
				if (enumerator.MoveNext())
				{
					GameObject gameObject = null;
					object obj2 = (object)(&enumerator);
					throw new NullReferenceException();
				}
				Debug.Log("[RecapPage] OnShowStart after foreach on all players");
				bool flag19 = list2 == null;
				num = unchecked((nint)"[RecapPage] OnShowStart after foreach on all players");
				if (!flag19)
				{
					List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
					while (enumerator2.MoveNext())
					{
						nint num9 = (nint)typeof(GM);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2602 @ rax_v358 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
						nint num10 = 0;
						GameManager core3 = GM.Core;
						if ((object)GM.Core != null)
						{
							if (core3._characters != null)
							{
								bool flag20 = ((List<object>)(object)core3._characters).Remove((object)null);
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					Debug.Log("[RecapPage] OnShowStart after foreach to remove characters");
					RefreshCharacterSpecificStats();
					PlayerOptions playerOptions3 = _playerOptions;
					bool flag21 = _playerOptions == null;
					num = (nint)this;
					if (!flag21)
					{
						PlayerOptionsData mainGameConfig3 = playerOptions3._mainGameConfig;
						bool flag22 = playerOptions3._mainGameConfig == null;
						num = (nint)this;
						if (!flag22)
						{
							if (mainGameConfig3._003CHasSeenAdventureReveal_003Ek__BackingField)
							{
								goto IL_135c;
							}
							PlayerOptions playerOptions4 = _playerOptions;
							num = (nint)playerOptions4._mainGameConfig;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rcx_v51 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+48]");
							if ((nint)0 == 8 && _adventureManager != null)
							{
								bool flag23 = _adventureManager.HasLoadedAtLeastOneDlcWithAdventures();
								bool flag24 = !flag23;
								num = (nint)_adventureManager;
								if (!flag24)
								{
									Debug.Log("Unlocking Adventures: Player has a DLC and has unlocked Stage 3");
									PlayerOptions playerOptions5 = _playerOptions;
									bool flag25 = _playerOptions == null;
									num = unchecked((nint)"Unlocking Adventures: Player has a DLC and has unlocked Stage 3");
									if (!flag25)
									{
										PlayerOptionsData mainGameConfig4 = playerOptions5._mainGameConfig;
										bool flag26 = playerOptions5._mainGameConfig == null;
										num = unchecked((nint)"Unlocking Adventures: Player has a DLC and has unlocked Stage 3");
										if (!flag26)
										{
											mainGameConfig4._003CShouldPlayAdventureReveal_003Ek__BackingField = true;
											num = unchecked((nint)"Unlocking Adventures: Player has a DLC and has unlocked Stage 3");
											goto IL_1385;
										}
									}
									goto IL_1239;
								}
							}
							goto IL_1385;
						}
					}
				}
			}
		}
		goto IL_1239;
		IL_135c:
		bool flag27 = _achievements == null;
		num = (nint)_achievements;
		if (!flag27)
		{
			List<AchievementData> list3 = _achievements.CheckAllAchievements();
			GameManager core4 = GM.Core;
			bool flag28 = (object)GM.Core == null;
			num = (nint)typeof(GM);
			if (!flag28)
			{
				if (!core4._003CStartedAsOnlineMultiplayerRun_003Ek__BackingField)
				{
					bool flag29 = _achievementManager == null;
					num = (nint)_achievementManager;
					if (flag29)
					{
						goto IL_1239;
					}
					_achievementManager.UnlockAchievementsAndGiveRewards();
					AchievementData achievementData = CheckCompleteAdventure(out var _);
					if (achievementData != null)
					{
						bool flag30 = list3 == null;
						num = (nint)this;
						if (flag30)
						{
							goto IL_1239;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B120");
					}
				}
				QueueAchievements(list3);
				bool flag31 = _achievements == null;
				num = (nint)_achievements;
				if (!flag31)
				{
					List<SecretType> list4 = _achievements.CheckAllSecrets();
					nint num11 = (nint)typeof(GM);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3315 @ rax_v108 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
					nint num12 = 0;
					GameManager core5 = GM.Core;
					bool flag32 = (object)GM.Core == null;
					num = num12;
					if (!flag32)
					{
						if (!core5._003CStartedAsOnlineMultiplayerRun_003Ek__BackingField)
						{
							bool flag33 = _playerOptions == null;
							num = (nint)_playerOptions;
							if (flag33)
							{
								goto IL_1239;
							}
							_playerOptions.Save(commitImmediately: true, createBackup: true);
							List<VampireSurvivors.Objects.Characters.CharacterController> list = null;
						}
						Debug.Log("[RecapPage] OnShowStart after save");
						GameObject watchAdForExtraGoldButton = (GameObject)(object)_WatchAdForExtraGoldButton;
						bool flag34 = ((UnityEngine.Object)watchAdForExtraGoldButton).m_CachedPtr == (IntPtr)0;
						IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)watchAdForExtraGoldButton).m_CachedPtr);
						GameObject gameObject2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
						bool flag35 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
						GameObject.SetActive_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr, false);
						Debug.Log("[RecapPage] OnShowStart before creating particles");
						ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("items");
						List<string> list5 = new List<string>();
						int version = list5._version + 1;
						list5._version = version;
						string[] items = list5._items;
						if (list5._size >= items.Length)
						{
							((List<object>)(object)list5).AddWithResize((object)"coin-spin-gold_01");
						}
						else
						{
							int size = list5._size + 1;
							list5._size = size;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						particleSystemConfig._frame = list5;
						ParticleSystem.MinMaxCurve y = new ParticleSystem.MinMaxCurve(0f);
						particleSystemConfig._y = y;
						_ = 0;
						particleSystemConfig._x = (ParticleSystem.MinMaxCurve)3;
						_ = 0;
						particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)3;
						_ = 0;
						y = new ParticleSystem.MinMaxCurve(2500f);
						particleSystemConfig._lifespan = y;
						_ = 0;
						particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)1;
						_ = 0;
						_ = 100f;
						particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
						_ = 0;
						_ = 1.25f;
						particleSystemConfig._quantity = (int?)(object)1;
						ParticleEmitterManager coinEmitter = _CoinEmitter;
						bool flag36 = ((UnityEngine.Object)coinEmitter).m_CachedPtr == (IntPtr)0;
						IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)coinEmitter).m_CachedPtr);
						Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
						Transform parent = default(Transform);
						string psName = default(string);
						bool isAdditive = default(bool);
						bool requiresMasking = default(bool);
						ParticleSystem particles = coinEmitter.CreateUIEmitter(particleSystemConfig, "UI", 10, parent, psName, isAdditive, requiresMasking);
						_particles = particles;
						Debug.Log("[RecapPage] OnShowStart before setting up texture sheet animation");
						Sprite sprite = SpriteManager.GetSprite("coin-spin-gold_01", "items");
						if ((object)sprite != null)
						{
							List<VampireSurvivors.Objects.Characters.CharacterController> list6 = (List<VampireSurvivors.Objects.Characters.CharacterController>)(nint)((UnityEngine.Object)sprite).m_CachedPtr;
						}
						else
						{
							List<VampireSurvivors.Objects.Characters.CharacterController> list6 = null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBD0]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBD0]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							bool flag37 = obj3 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v4929 @ rax_v174 (should have been resolved before IL gen)");
						Sprite sprite2 = SpriteManager.GetSprite("coin-spin-gold_02", "items");
						if ((object)sprite2 != null)
						{
							List<VampireSurvivors.Objects.Characters.CharacterController> list7 = (List<VampireSurvivors.Objects.Characters.CharacterController>)(nint)((UnityEngine.Object)sprite2).m_CachedPtr;
						}
						else
						{
							List<VampireSurvivors.Objects.Characters.CharacterController> list7 = null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBD0]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBD0]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							bool flag38 = obj4 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v5000 @ rax_v180 (should have been resolved before IL gen)");
						Sprite sprite3 = SpriteManager.GetSprite("coin-spin-gold_03", "items");
						if ((object)sprite3 != null)
						{
							List<VampireSurvivors.Objects.Characters.CharacterController> list8 = (List<VampireSurvivors.Objects.Characters.CharacterController>)(nint)((UnityEngine.Object)sprite3).m_CachedPtr;
						}
						else
						{
							List<VampireSurvivors.Objects.Characters.CharacterController> list8 = null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBD0]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBD0]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							bool flag39 = obj5 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v5071 @ rax_v186 (should have been resolved before IL gen)");
						Sprite sprite4 = SpriteManager.GetSprite("coin-spin-gold_04", "items");
						if ((object)sprite4 != null)
						{
							List<VampireSurvivors.Objects.Characters.CharacterController> list9 = (List<VampireSurvivors.Objects.Characters.CharacterController>)(nint)((UnityEngine.Object)sprite4).m_CachedPtr;
						}
						else
						{
							List<VampireSurvivors.Objects.Characters.CharacterController> list9 = null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBD0]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBD0]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							bool flag40 = obj6 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v5142 @ rax_v192 (should have been resolved before IL gen)");
						Sprite sprite5 = SpriteManager.GetSprite("coin-spin-gold_05", "items");
						if ((object)sprite5 != null)
						{
							List<VampireSurvivors.Objects.Characters.CharacterController> list10 = (List<VampireSurvivors.Objects.Characters.CharacterController>)(nint)((UnityEngine.Object)sprite5).m_CachedPtr;
						}
						else
						{
							List<VampireSurvivors.Objects.Characters.CharacterController> list10 = null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBD0]");
						object obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBD0]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							bool flag41 = obj7 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v5213 @ rax_v198 (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB68]");
						object obj8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB68]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							bool flag42 = obj8 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v5238 @ rax_v201 (should have been resolved before IL gen)");
						List<VampireSurvivors.Objects.Characters.CharacterController> particles2 = (List<VampireSurvivors.Objects.Characters.CharacterController>)(object)_particles;
						bool flag43 = particles2._items == null;
						ParticleSystem.Stop_Injected((IntPtr)particles2._items, true, ParticleSystemStopBehavior.StopEmitting);
						Debug.Log("[RecapPage] OnShowStart before starting SelectDoneDelayed");
						_003CSelectDoneDelayed_003Ed__64 obj9 = null;
						obj9._003C_003E1__state = 0;
						obj9._003C_003E4__this = this;
						Coroutine coroutine = StartCoroutine(obj9);
						if (_spellsManager != null)
						{
							_spellsManager.RestoreCachedPlayerSettings();
						}
						return;
					}
				}
			}
		}
		goto IL_1239;
		IL_031f:
		PlayerOptionsData config7 = _playerOptions.Config;
		bool flag44 = config7 == null;
		num = (nint)_playerOptions;
		if (!flag44)
		{
			if (config7._003CCharacterEggCount_003Ek__BackingField == null)
			{
				goto IL_0485;
			}
			PlayerOptionsData config8 = _playerOptions.Config;
			bool flag45 = config8 == null;
			num = (nint)_playerOptions;
			if (!flag45)
			{
				num = (nint)config8._003CCharacterEggCount_003Ek__BackingField;
				bool flag46 = config8._003CCharacterEggCount_003Ek__BackingField == null;
				if (!flag46)
				{
					int num13 = config8._003CCharacterEggCount_003Ek__BackingField.FindEntry(CharacterType.SIGMA);
					if (flag46)
					{
						goto IL_0485;
					}
					PlayerOptionsData config9 = _playerOptions.Config;
					bool flag47 = config9 == null;
					num = (nint)_playerOptions;
					if (!flag47)
					{
						bool flag48 = config9._003CCharacterEggCount_003Ek__BackingField == null;
						num = (nint)config9._003CCharacterEggCount_003Ek__BackingField;
						if (!flag48)
						{
							bool flag49 = config9._003CCharacterEggCount_003Ek__BackingField.Remove(CharacterType.SIGMA);
							goto IL_0485;
						}
					}
				}
			}
		}
		goto IL_1239;
	}

	private unsafe AchievementData CheckCompleteAdventure(out bool willReturnToLandingFromPopup)
	{
		//IL_0a99: Expected I, but got O
		//IL_00ba: Expected I, but got O
		//IL_00f0: Expected I, but got O
		//IL_010b: Expected I, but got O
		//IL_0197: Expected I, but got O
		//IL_0ad7: Expected I, but got O
		//IL_021a: Expected I, but got O
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Expected O, but got Unknown
		//IL_0b24: Expected I, but got O
		//IL_030d: Expected I, but got O
		//IL_0328: Expected I, but got O
		//IL_0365: Expected I, but got O
		//IL_039b: Expected I, but got O
		//IL_03ca: Expected I, but got O
		//IL_03f3: Expected I, but got O
		//IL_04ab: Expected F4, but got I
		//IL_04d4: Expected I, but got O
		//IL_0429: Expected I, but got O
		//IL_0511: Expected I, but got O
		//IL_0487: Expected I, but got O
		//IL_054e: Expected I, but got O
		//IL_058d: Expected F4, but got I
		//IL_0b76: Expected I, but got O
		//IL_05cb: Expected F4, but got I
		//IL_071a: Expected I, but got O
		//IL_0735: Expected I, but got O
		//IL_06e4: Expected F4, but got O
		//IL_06ed: Expected F4, but got I4
		//IL_05f9: Expected F4, but got I4
		//IL_0601: Expected O, but got Ref
		//IL_085a: Expected I, but got O
		//IL_0889: Expected I, but got O
		//IL_08f2: Expected I, but got O
		//IL_090d: Expected I, but got O
		//IL_097b: Expected O, but got I
		//IL_09a8: Expected I, but got O
		//IL_09cf: Expected I, but got O
		//IL_0a28: Expected O, but got I
		_003C_003Ec__DisplayClass63_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass63_0();
		bool flag = CS_0024_003C_003E8__locals5 == null;
		nint num = (nint)typeof(_003C_003Ec__DisplayClass63_0);
		if (!flag)
		{
			CS_0024_003C_003E8__locals5._003C_003E4__this = this;
			ref bool reference = ref *(bool*)null;
			if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField && _adventureManager != null)
			{
				AdventureManager adventureManager = _adventureManager;
				if (_adventureManager.IsAdventureCompleted(adventureManager.CurrentAdventure))
				{
					bool flag2 = _playerOptions == null;
					num = (nint)_playerOptions;
					if (!flag2)
					{
						PlayerOptionsData config = _playerOptions.Config;
						bool flag3 = config == null;
						num = (nint)_playerOptions;
						if (!flag3)
						{
							num = (nint)config._003CCompletedAdventures_003Ek__BackingField;
							AdventureManager adventureManager2 = _adventureManager;
							if (_adventureManager != null && config._003CCompletedAdventures_003Ek__BackingField != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9D240");
								object obj = default(object);
								if (obj != null)
								{
									goto IL_0a3e;
								}
								AdventureCompletedPopup adventureCompletedPopup = PopupManager.CreateAdventureCompletedPopup("Adventure-Completed-Popup");
								num = (nint)GM.Core;
								if ((object)GM.Core != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v7 (Il2CppClass<VampireSurvivors.UI.RecapPage+<>c__DisplayClass63_0>)+349]");
									CS_0024_003C_003E8__locals5.doReturnToLanding = false;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v7 (Il2CppClass<VampireSurvivors.UI.RecapPage+<>c__DisplayClass63_0>)+349]");
									if ((int)(~(nint)0) == 0)
									{
										reference = ref *(bool*)1;
									}
									Action action = delegate
									{
										if (CS_0024_003C_003E8__locals5.doReturnToLanding)
										{
											CS_0024_003C_003E8__locals5._003C_003E4__this.ReturnToLanding();
										}
									};
									bool flag4 = (object)adventureCompletedPopup == null;
									num = (nint)action;
									if (!flag4)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829B4260");
										bool flag5 = _signalBus == null;
										num = (nint)adventureCompletedPopup;
										if (!flag5)
										{
											nint num2 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1118 @ rbx_v10 (Il2CppMethodInfo)+38]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
											}
											nint num3 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1135 @ rbx_v11 (Il2CppMethodInfo)+38]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
											object obj3 = default(object);
											object obj2 = obj3 + 32;
											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
											Type signalType = default(Type);
											bool requireDeclaration = default(bool);
											_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
											AdventureManager adventureManager3 = _adventureManager;
											bool flag6 = _adventureManager == null;
											num = (nint)_signalBus;
											if (!flag6)
											{
												AdventureData adventureData = adventureManager3._003CAdventureData_003Ek__BackingField;
												bool flag7 = adventureManager3._003CAdventureData_003Ek__BackingField == null;
												num = (nint)_signalBus;
												if (!flag7)
												{
													num = (nint)adventureData._003CCoreAdventureData_003Ek__BackingField;
													if (adventureData._003CCoreAdventureData_003Ek__BackingField != null)
													{
														bool flag8 = _playerOptions == null;
														num = (nint)_playerOptions;
														if (!flag8)
														{
															PlayerOptionsData config2 = _playerOptions.Config;
															bool flag9 = config2 == null;
															num = (nint)_playerOptions;
															if (!flag9)
															{
																bool flag10 = config2._003CAdventureCompletionCount_003Ek__BackingField <= 0;
																num = (nint)_playerOptions;
																if (flag10)
																{
																	goto IL_0b32;
																}
																bool flag11 = _playerOptions == null;
																num = (nint)_playerOptions;
																if (!flag11)
																{
																	PlayerOptionsData config3 = _playerOptions.Config;
																	bool flag12 = config3 == null;
																	num = (nint)_playerOptions;
																	if (!flag12)
																	{
																		float num4 = (float)config3._003CAdventureCompletionCount_003Ek__BackingField * 0.1f;
																		float num5 = num4 + 1f;
																		float num6 = num5;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v7 (Il2CppClass<VampireSurvivors.UI.RecapPage+<>c__DisplayClass63_0>)+48]");
																		float num7 = num6 * 0f;
																		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ebx,xmm1\"");
																		num = (nint)_playerOptions;
																		goto IL_0b32;
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
					goto IL_0a48;
				}
			}
			goto IL_0a3e;
		}
		goto IL_0a48;
		IL_0a48:
		throw new NullReferenceException();
		IL_0a3e:
		return null;
		IL_0b32:
		PlayerOptions playerOptions = _playerOptions;
		if (_playerOptions != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v7 (Il2CppClass<VampireSurvivors.UI.RecapPage+<>c__DisplayClass63_0>)+48]");
			PlayerOptions.AddCoinsFlat(0f, playerOptions._mainGameConfig);
			AdventureManager adventureManager4 = _adventureManager;
			bool flag13 = _adventureManager == null;
			num = (nint)typeof(PlayerOptions);
			if (!flag13)
			{
				AdventureData adventureData2 = adventureManager4._003CAdventureData_003Ek__BackingField;
				bool flag14 = adventureManager4._003CAdventureData_003Ek__BackingField == null;
				num = (nint)typeof(PlayerOptions);
				if (!flag14)
				{
					CoreAdventureData coreAdventureData = adventureData2._003CCoreAdventureData_003Ek__BackingField;
					bool flag15 = adventureData2._003CCoreAdventureData_003Ek__BackingField == null;
					num = (nint)typeof(PlayerOptions);
					if (!flag15)
					{
						PlayerOptionsData playerOptionsData = (PlayerOptionsData)(object)coreAdventureData._003CCompletionSkinsReward_003Ek__BackingField;
						bool flag16 = coreAdventureData._003CCompletionSkinsReward_003Ek__BackingField == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v7 (Il2CppClass<VampireSurvivors.UI.RecapPage+<>c__DisplayClass63_0>)+48]");
						float num8 = 0f;
						SkinType skinType = SkinType.DEFAULT;
						if (!flag16)
						{
							bool flag17 = (nint)playerOptionsData._003CPlatform_003Ek__BackingField <= 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v7 (Il2CppClass<VampireSurvivors.UI.RecapPage+<>c__DisplayClass63_0>)+48]");
							num8 = 0f;
							skinType = SkinType.DEFAULT;
							if (!flag17)
							{
								skinType = SkinType.DEFAULT;
								List<SkinToUnlock>.Enumerator enumerator = default(List<SkinToUnlock>.Enumerator);
								if (enumerator.MoveNext())
								{
									float num9 = 0f;
									PlayerOptions playerOptions2 = (PlayerOptions)(&enumerator);
									throw new NullReferenceException();
								}
								num8 = (float)playerOptionsData;
								float num7 = 0f;
							}
						}
						bool flag18 = _playerOptions == null;
						num = (nint)_playerOptions;
						if (!flag18)
						{
							PlayerOptionsData config4 = _playerOptions.Config;
							bool flag19 = config4 == null;
							num = (nint)_playerOptions;
							if (!flag19)
							{
								num = (nint)config4._003CCompletedAdventures_003Ek__BackingField;
								AdventureManager adventureManager5 = _adventureManager;
								if (_adventureManager != null && config4._003CCompletedAdventures_003Ek__BackingField != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9D2B0");
									AdventureManager adventureManager6 = _adventureManager;
									if (_adventureManager != null)
									{
										AdventureData adventureData3 = adventureManager6._003CAdventureData_003Ek__BackingField;
										if (adventureManager6._003CAdventureData_003Ek__BackingField != null)
										{
											string text = "CompleteAdv_" + adventureData3._003CProgressKey_003Ek__BackingField;
											if (!Enum.TryParse<AchievementType>(text, ignoreCase: false, out var result))
											{
												goto IL_0a3e;
											}
											DataManager dataManager = _dataManager;
											bool flag20 = _dataManager == null;
											num = (nint)text;
											if (!flag20)
											{
												bool flag21 = dataManager._003CAllAchievements_003Ek__BackingField == null;
												num = (nint)dataManager._003CAllAchievements_003Ek__BackingField;
												if (!flag21)
												{
													int num10 = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllAchievements_003Ek__BackingField).FindEntry((System.Int32Enum)result);
													if (num10 < 0)
													{
														goto IL_0a3e;
													}
													PlayerOptions playerOptions3 = _playerOptions;
													bool flag22 = _playerOptions == null;
													num = (nint)dataManager._003CAllAchievements_003Ek__BackingField;
													if (!flag22)
													{
														num = (nint)playerOptions3._mainGameConfig;
														if (playerOptions3._mainGameConfig != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v7 (Il2CppClass<VampireSurvivors.UI.RecapPage+<>c__DisplayClass63_0>)+190]");
															num = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v7 (Il2CppClass<VampireSurvivors.UI.RecapPage+<>c__DisplayClass63_0>)+190]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v7 (Il2CppClass<VampireSurvivors.UI.RecapPage+<>c__DisplayClass63_0>)+190]");
																if (Enum.TryParse<AchievementType>((string)0, (byte)result != 0, out *(AchievementType*)null))
																{
																	goto IL_0a3e;
																}
																bool flag23 = _achievementManager == null;
																num = (nint)_achievementManager;
																if (!flag23)
																{
																	_achievementManager.UnlockAchievement(result);
																	num = (nint)_dataManager;
																	if (_dataManager != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v7 (Il2CppClass<VampireSurvivors.UI.RecapPage+<>c__DisplayClass63_0>)+1A8]");
																		if ((nint)0 != 0)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v7 (Il2CppClass<VampireSurvivors.UI.RecapPage+<>c__DisplayClass63_0>)+1A8]");
																			return (AchievementData)((Dictionary<System.Int32Enum, object>)0).get_Item((System.Int32Enum)result);
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
		goto IL_0a48;
	}

	private IEnumerator SelectDoneDelayed()
	{
		_003CSelectDoneDelayed_003Ed__64 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void EditorShowCompletionPopup()
	{
		Debug.Break();
		AdventureCompletedPopup adventureCompletedPopup = PopupManager.CreateAdventureCompletedPopup("Adventure-Completed-Popup");
	}

	private void OnDestroy()
	{
		_AchievementPopup.CancelLoop();
		List<Tween>.Enumerator enumerator = default(List<Tween>.Enumerator);
		while (enumerator.MoveNext())
		{
		}
	}

	private void SetInfo()
	{
		SetHeader();
		SetCharacter();
		SetRunStats();
		if (!_isFirstShow)
		{
			Transform transform = _WeaponIcons.transform;
			Transform parent = transform.parent;
			VerticalLayoutGroup component = parent.GetComponent<VerticalLayoutGroup>();
			component.enabled = false;
		}
		else
		{
			AddCollectedItems();
			AddArcanas();
			AddPowerUps();
		}
		AddWeapons();
		_isFirstShow = false;
	}

	private void DoAnimations()
	{
		if (!_isFirstShow)
		{
			Transform transform = _WeaponIcons.transform;
			Transform parent = transform.parent;
			VerticalLayoutGroup component = parent.GetComponent<VerticalLayoutGroup>();
			component.enabled = false;
		}
		else
		{
			AddCollectedItems();
			AddArcanas();
			AddPowerUps();
		}
		AddWeapons();
		_isFirstShow = false;
	}

	private unsafe void SetHeader()
	{
		//IL_00c7: Expected O, but got I
		//IL_0201: Expected O, but got I
		//IL_0256: Expected I, but got O
		//IL_027c: Expected Ref, but got F4
		PlayerOptionsData config = _playerOptions.Config;
		Dictionary<StageType, List<StageData>> convertedStages = _dataManager.GetConvertedStages();
		int num = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).FindEntry((System.Int32Enum)config._003CSelectedStage_003Ek__BackingField);
		if (num >= 0)
		{
			Dictionary<StageType, List<StageData>> convertedStages2 = _dataManager.GetConvertedStages();
			object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedStages2).get_Item((System.Int32Enum)config._003CSelectedStage_003Ek__BackingField);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v16 (System.Object)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v16 (System.Object)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C74]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v17+20]");
				string prefix = ((StageData)0).GetPrefix(config._003CSelectedStage_003Ek__BackingField);
				string term = prefix + "stageName";
				bool applyParameters = default(bool);
				GameObject localParametersRoot = default(GameObject);
				string overrideLanguage = default(string);
				bool allowLocalizedParameters = default(bool);
				string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
				PlayerOptionsData config2 = _playerOptions.Config;
				string term2 = ((!config2._003CSelectedHyper_003Ek__BackingField) ? "lang/postGame_normal" : "lang/postGame_hyper");
				string translation2 = LocalizationManager.GetTranslation(term2, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
				nint num2 = (nint)typeof(GameManager);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v556 @ rcx_v25 (Il2CppClass<VampireSurvivors.Framework.GameManager>)+B8]");
				float num3 = 0f + 12f;
				string newValue = ((float*)num3)->ToString();
				string text = translation2.Replace("%0", newValue);
				string text2 = translation + " " + text;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
		else
		{
			Debug.LogError("Trying to show recap data for a non-existent stage...");
		}
	}

	private void SetCharacter()
	{
		//IL_00d5: Expected O, but got I
		//IL_00ea: Expected O, but got I
		//IL_0113: Expected O, but got I
		//IL_0181: Expected O, but got I4
		//IL_01da: Expected O, but got I4
		VampireSurvivors.Objects.Characters.CharacterController currentCharacter = _currentCharacter;
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
		int num = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).FindEntry((System.Int32Enum)currentCharacter._characterType);
		object message;
		if (num >= 0)
		{
			if (currentCharacter._characterType != CharacterType.FOLLOWER_ENEMY)
			{
				Dictionary<CharacterType, List<CharacterData>> convertedCharacterData2 = _dataManager.GetConvertedCharacterData();
				object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData2).get_Item((System.Int32Enum)currentCharacter._characterType);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v18 (System.Object)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v18 (System.Object)+10]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v19+20]");
					CharacterData characterData = (CharacterData)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v19+20]");
					string fullName = ((CharacterData)0).GetFullName(currentCharacter._characterType);
					SkinType skinTypeForCharacter = _playerOptions.GetSkinTypeForCharacter(currentCharacter._characterType);
					Skin skinForCharacter = _playerOptions.GetSkinForCharacter(currentCharacter._characterType, skinTypeForCharacter);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
					bool flag = skinForCharacter._003CspriteName_003Ek__BackingField == null;
					object obj3 = 0;
					if (!flag)
					{
						bool flag2 = (nint)skinForCharacter._003CtextureName_003Ek__BackingField < 0;
						bool flag3 = skinForCharacter._003CtextureName_003Ek__BackingField == null;
						bool flag4 = !flag2;
						bool flag5 = !flag3;
						obj3 = flag5 & flag4;
					}
					string spriteName;
					string textureName;
					if (obj3 != null)
					{
						spriteName = skinForCharacter._003CspriteName_003Ek__BackingField;
						textureName = skinForCharacter._003CtextureName_003Ek__BackingField;
					}
					else
					{
						spriteName = characterData._003CspriteName_003Ek__BackingField;
						textureName = characterData._003CtextureName_003Ek__BackingField;
					}
					Sprite sprite = SpriteManager.GetSprite(spriteName, textureName);
					_CharacterIcon.sprite = sprite;
					_CharacterIcon.preserveAspect = true;
					PlayerOptionsData config = _playerOptions.Config;
					if (config._003CSelectedGoldenEggs_003Ek__BackingField)
					{
						PlayerOptionsData config2 = _playerOptions.Config;
						int num2 = ((Dictionary<System.Int32Enum, object>)(object)config2._003CCharacterEggInfo_003Ek__BackingField).FindEntry((System.Int32Enum)currentCharacter._characterType);
						if (num2 >= 0)
						{
							Transform transform = _EggCount.transform;
							Transform parent = transform.parent;
							GameObject gameObject = parent.gameObject;
							gameObject.SetActive(value: true);
							PlayerOptionsData config3 = _playerOptions.Config;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96AE0");
							float eggCount = default(float);
							string formattedEggCount = EggManager.GetFormattedEggCount(eggCount);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
							return;
						}
					}
					Transform transform2 = _EggCount.transform;
					Transform parent2 = transform2.parent;
					GameObject gameObject2 = parent2.gameObject;
					gameObject2.SetActive(value: false);
				}
				else
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				}
				return;
			}
			message = "Do not show recap data for FOLLOWER_ENEMY characters...";
		}
		else
		{
			message = "Trying to show recap data for a non-existent character...";
		}
		Debug.LogError(message);
	}

	private unsafe void SetRunStats()
	{
		//IL_11e1: Expected I, but got O
		//IL_008d: Expected O, but got Ref
		//IL_00db: Expected O, but got Ref
		//IL_01cc: Expected O, but got Ref
		//IL_0233: Expected O, but got Ref
		//IL_02f2: Expected O, but got I4
		//IL_0300: Expected I, but got O
		//IL_0421: Expected I, but got O
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		GameManager core = GM.Core;
		float num3 = core._003CSurvivedSeconds_003Ek__BackingField / 60f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		_timeFormatStringBuilder.Length = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		System.ParamsArray paramsArray2 = default(System.ParamsArray);
		StringBuilder stringBuilder = _timeFormatStringBuilder.AppendFormatHelper((IFormatProvider)null, "{0:00}", (System.ParamsArray)(&paramsArray2));
		StringBuilder stringBuilder2 = _timeFormatStringBuilder.Append(":");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg2 = default(object);
		paramsArray = new System.ParamsArray(arg2);
		StringBuilder stringBuilder3 = _timeFormatStringBuilder.AppendFormatHelper((IFormatProvider)null, "{0:00}", (System.ParamsArray)(&paramsArray2));
		PropertyUI survived = _Survived;
		string text = _timeFormatStringBuilder.ToString();
		survived.Value.text = text;
		PropertyUI gold = _Gold;
		PlayerOptionsData config = _playerOptions.Config;
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		string text2 = System.Number.FormatSingle(config._003CRunCoins_003Ek__BackingField, "F0", currentInfo);
		gold.Value.text = text2;
		PropertyUI levels = _Levels;
		GameManager core2 = GM.Core;
		GameSessionData gameSessionData = core2._gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
		string text3 = System.Number.FormatInt32(activeCharacter._level, (ReadOnlySpan<char>)(&paramsArray), null);
		levels.Value.text = text3;
		PropertyUI enemies = _Enemies;
		GameManager core3 = GM.Core;
		PlayerOptionsData config2 = core3._playerOptions.Config;
		string text4 = System.Number.FormatInt32(config2._003CRunEnemies_003Ek__BackingField, (ReadOnlySpan<char>)(&paramsArray), null);
		enemies.Value.text = text4;
		GameManager core4 = GM.Core;
		Stage stage = core4._stage;
		StageModifiers stageModifiers = stage._003CStageMods_003Ek__BackingField;
		bool flag = stage._003CStageMods_003Ek__BackingField == null;
		float num4 = 1800f;
		if (!flag)
		{
			bool flag2 = (object)stageModifiers._003CTimeLimit_003Ek__BackingField == null;
			num4 = 1800f;
			if (!flag2)
			{
				float num5 = default(float);
				num4 = num5;
			}
		}
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (!enumerator.MoveNext())
		{
			return;
		}
		object obj = 0;
		nint num6 = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v950 @ rax_v55 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num7 = 0;
		GameManager core5 = GM.Core;
		PlayerOptionsData playerOptionsData;
		if ((object)GM.Core != null)
		{
			PlayerOptions playerOptions = _playerOptions;
			if (_playerOptions == null)
			{
				throw new NullReferenceException();
			}
			if (playerOptions._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions._hostGameConfig == null)
				{
					if (playerOptions._currentAdventureSaveData != null)
					{
						playerOptionsData = playerOptions._currentAdventureSaveData;
						if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_1249;
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
			goto IL_1249;
		}
		throw new NullReferenceException();
		IL_1249:
		if (playerOptionsData != null)
		{
			num7 = (nint)playerOptionsData._003CCharacterEnemiesKilled_003Ek__BackingField;
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	private unsafe void AddWeapons()
	{
		//IL_17d3: Expected I, but got O
		//IL_17e9: Expected O, but got I
		//IL_0147: Expected O, but got Ref
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00dd: Expected O, but got I8
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_1f22: Expected O, but got I4
		//IL_1f32: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f37: Expected O, but got Unknown
		//IL_1919: Expected O, but got Ref
		//IL_1922: Expected O, but got I4
		//IL_01a2: Expected I, but got O
		//IL_0229: Expected O, but got I4
		//IL_03a6: Expected I, but got O
		//IL_01da: Expected O, but got I
		//IL_042d: Expected O, but got I4
		//IL_03de: Expected O, but got I
		//IL_02e9: Expected O, but got I
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected O, but got Unknown
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Expected O, but got Unknown
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Expected O, but got Unknown
		//IL_0639: Expected O, but got I
		//IL_0642: Unknown result type (might be due to invalid IL or missing references)
		//IL_0647: Expected O, but got Unknown
		//IL_064f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0654: Expected O, but got Unknown
		//IL_027f: Expected O, but got I4
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f6: Expected O, but got Unknown
		//IL_0467: Expected I, but got O
		//IL_04ee: Expected O, but got I4
		//IL_0720: Expected F4, but got I4
		//IL_049f: Expected O, but got I
		//IL_067c: Expected O, but got I
		//IL_0685: Unknown result type (might be due to invalid IL or missing references)
		//IL_068a: Expected O, but got Unknown
		//IL_0692: Unknown result type (might be due to invalid IL or missing references)
		//IL_0697: Expected O, but got Unknown
		//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b7: Expected O, but got Unknown
		//IL_0783: Expected O, but got I
		//IL_0581: Expected I, but got O
		//IL_058f: Expected I, but got O
		//IL_059f: Expected O, but got I
		//IL_06a5: Expected O, but got I4
		//IL_05db: Expected O, but got I
		//IL_07d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07dd: Expected O, but got Unknown
		//IL_07fa: Expected F4, but got I
		//IL_080a: Expected F4, but got I
		//IL_081a: Expected F4, but got I
		//IL_1f8b: Expected O, but got Ref
		//IL_0860: Expected O, but got I
		//IL_1a7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a81: Expected O, but got Unknown
		//IL_1a8e: Expected O, but got Ref
		//IL_0611: Expected O, but got I4
		//IL_06c7: Expected O, but got I
		//IL_06d4: Expected O, but got Ref
		//IL_0895: Expected O, but got I
		//IL_1b39: Expected O, but got I4
		//IL_1b42: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b47: Expected O, but got Unknown
		//IL_09d3: Expected O, but got Ref
		//IL_0a02: Expected I, but got O
		//IL_1b9c: Expected I4, but got O
		//IL_0a8b: Expected O, but got I4
		//IL_0a39: Expected O, but got I
		//IL_0c0f: Expected O, but got I
		//IL_0c18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1d: Expected O, but got Unknown
		//IL_0c25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2a: Expected O, but got Unknown
		//IL_1e11: Expected O, but got I
		//IL_0ab9: Expected I, but got O
		//IL_0a4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a54: Expected O, but got Unknown
		//IL_0b42: Expected O, but got I4
		//IL_11ea: Expected O, but got I
		//IL_0af0: Expected O, but got I
		//IL_1c1a: Expected I, but got O
		//IL_093a: Unknown result type (might be due to invalid IL or missing references)
		//IL_093f: Expected O, but got Unknown
		//IL_0962: Expected F4, but got I4
		//IL_0b57: Expected I, but got O
		//IL_0b65: Expected I, but got O
		//IL_0b75: Expected O, but got I
		//IL_0c52: Expected O, but got I
		//IL_0c5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c60: Expected O, but got Unknown
		//IL_0c68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6d: Expected O, but got Unknown
		//IL_0c7b: Expected O, but got I4
		//IL_0b06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0b: Expected O, but got Unknown
		//IL_0bb1: Expected O, but got I
		//IL_0be7: Expected O, but got I4
		//IL_1242: Expected F4, but got I4
		//IL_16a3: Expected O, but got I
		//IL_0df3: Expected O, but got I
		//IL_0e78: Expected O, but got I
		//IL_0e78: Expected O, but got I
		//IL_0f17: Expected I, but got O
		//IL_0f27: Expected O, but got I
		//IL_0ffa: Expected I, but got O
		//IL_0fa5: Expected I, but got O
		//IL_0fb5: Expected O, but got I
		//IL_1065: Expected F4, but got I4
		//IL_10bb: Expected O, but got I
		//IL_1102: Expected O, but got Ref
		//IL_1141: Unknown result type (might be due to invalid IL or missing references)
		//IL_1146: Expected O, but got Unknown
		//IL_1187: Expected F4, but got I4
		//IL_0997->IL16c0: Incompatible stack heights: 1 vs 0
		//IL_1c49->IL16c0: Incompatible stack heights: 1 vs 0
		//IL_1bc5->IL16c0: Incompatible stack heights: 2 vs 0
		//IL_1e31->IL16c0: Incompatible stack heights: 2 vs 0
		//IL_120a->IL16c0: Incompatible stack heights: 2 vs 0
		//IL_1d43->IL1c4e: Incompatible stack heights: 3 vs 1
		//IL_0975->IL1c1f: Incompatible stack heights: 3 vs 1
		//IL_122f->IL16c0: Incompatible stack heights: 2 vs 0
		//IL_097a->IL097a: Incompatible stack heights: 3 vs 1
		//IL_1fb1->IL1c4e: Incompatible stack heights: 3 vs 1
		//IL_1d52->IL1c4e: Incompatible stack heights: 4 vs 1
		//IL_0fc4->IL1d84: Incompatible stack heights: 14 vs 13
		//IL_11a4->IL1c4e: Incompatible stack heights: 19 vs 1
		List<StatsDisplay> list = new List<StatsDisplay>();
		VampireSurvivors.Objects.Characters.CharacterController currentCharacter = _currentCharacter;
		bool flag = (object)_currentCharacter == null;
		List<StatsDisplay> list2 = list;
		Dictionary<WeaponType, int> dictionary;
		RecapPage recapPage = default(RecapPage);
		float num17;
		float num19 = default(float);
		if (!flag)
		{
			VampireSurvivors.Objects.Characters.CharacterController weaponsManager = (VampireSurvivors.Objects.Characters.CharacterController)(object)currentCharacter._weaponsManager;
			bool flag2 = (object)currentCharacter._weaponsManager == null;
			list2 = list;
			if (!flag2)
			{
				IEnumerable<Equipment> first = Enumerable.Concat((IEnumerable<Equipment>)weaponsManager._parentContainer, (IEnumerable<Equipment>)weaponsManager.body);
				IEnumerable<Equipment> source = Enumerable.Concat(first, (IEnumerable<Equipment>)((PhaserGameObject)weaponsManager)._scene);
				Func<Equipment, bool> predicate = _003C_003Ec._003C_003E9__72_0;
				if (_003C_003Ec._003C_003E9__72_0 == null)
				{
					Func<Equipment, bool> func = (_003C_003Ec._003C_003E9__72_0 = delegate(Equipment x)
					{
						//IL_0061: Expected I4, but got O
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						return !x.IsPowerup() && x._003CShowInRecap_003Ek__BackingField;
					});
					nint num = (nint)typeof(_003C_003Ec);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ rax_v364 (Il2CppClass<VampireSurvivors.UI.RecapPage+<>c>)+B8]");
					object obj = (nint)0 + (nint)8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
					bool flag3 = (nint)0 == 0;
					System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
					predicate = func;
					if (!flag3)
					{
						object obj2 = obj >> 12;
						object obj3 = obj2 & 0x1FFFFF;
						object obj4 = obj3 >> 6;
						object obj5 = 6603577472L;
						object obj6 = obj3 & 0x3F;
						nint num3;
						do
						{
							object obj7 = 1 << (int)obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1044 @ rdi_v63+462E0+v1049 @ rdx_v214*8]");
							object obj8 = 0 | obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1044 @ rdi_v63+462E0+v1049 @ rdx_v214*8]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1044 @ rdi_v63+462E0+v1049 @ rdx_v214*8]");
							if (num2 == 0)
							{
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1044 @ rdi_v63+462E0+v1049 @ rdx_v214*8]");
							num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1044 @ rdi_v63+462E0+v1049 @ rdx_v214*8]");
						}
						while (num3 != 0);
						insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
						predicate = func;
					}
				}
				IEnumerable<Equipment> enumerable = Enumerable.Where(source, predicate);
				dictionary = new Dictionary<WeaponType, int>();
				bool flag4 = enumerable == null;
				list2 = (List<StatsDisplay>)(object)dictionary;
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					List<StatsDisplay> list3 = default(List<StatsDisplay>);
					VampireSurvivors.Objects.Characters.CharacterController characterController = (VampireSurvivors.Objects.Characters.CharacterController)(&list3);
					list2 = null;
					object obj9 = default(object);
					object obj16 = default(object);
					object obj18 = default(object);
					while (true)
					{
						object obj10;
						object obj15;
						if (list3 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							if (obj9 == null)
							{
								break;
							}
							bool flag5 = list3 == null;
							list2 = null;
							if (!flag5)
							{
								nint num4 = (nint)list3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v578 @ r10_v62 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>>)+12E]");
								if ((nint)0 >= (nint)0)
								{
									goto IL_0216;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v578 @ r10_v62 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>>)+B0]");
								obj10 = 0;
								Weapon weapon = null;
								while (true)
								{
									object obj11 = (object)weapon + (object)weapon;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v595 @ r8_v150+v2176 @ rax_v357*8]");
									if (0 == (nint)typeof(IEnumerator<Equipment>))
									{
										break;
									}
									weapon = (Weapon)(weapon + 1);
									Weapon weapon2 = weapon;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v578 @ r10_v62 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>>)+12E]");
									if ((nint)weapon2 < 0)
									{
										continue;
									}
									goto IL_0216;
								}
								object obj12 = (object)weapon + (object)weapon;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v595 @ r8_v150+8+v2324 @ rcx_v267*8]");
								object obj13 = (nint)0 << 4;
								object obj14 = obj13 + 312;
								obj15 = obj14 + num4;
								goto IL_18d8;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
						IL_18d8:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2329 @ rdx_v200] (should have been resolved before IL gen)");
						bool flag6 = obj16 == null;
						list2 = list3;
						if (!flag6)
						{
							bool flag7 = dictionary == null;
							list2 = list3;
							if (!flag7)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v342+48]");
								int num5 = dictionary.FindEntry(WeaponType.VOID);
								object obj17 = !flag7;
								if (obj17 == null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v342+48]");
									bool flag8 = ((Dictionary<System.Int32Enum, int>)(object)dictionary).TryInsert((System.Int32Enum)0, 1, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
									System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
									list2 = (List<StatsDisplay>)(object)dictionary;
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v342+48]");
									int num6 = dictionary.get_Item(WeaponType.VOID);
									int value = num6 + 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v342+48]");
									bool flag9 = ((Dictionary<System.Int32Enum, int>)(object)dictionary).TryInsert((System.Int32Enum)0, value, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
									System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
									list2 = (List<StatsDisplay>)(object)dictionary;
								}
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
						IL_0216:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
						obj10 = 0;
						obj15 = obj18;
						goto IL_18d8;
					}
					if ((object)characterController != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					VampireSurvivors.Objects.Characters.CharacterController characterController2 = (VampireSurvivors.Objects.Characters.CharacterController)(&list3);
					object obj19 = 0;
					list2 = null;
					object obj26 = default(object);
					object obj33 = default(object);
					Weapon weapon8 = default(Weapon);
					object obj35 = default(object);
					string text = default(string);
					object obj38 = default(object);
					while (true)
					{
						object obj20;
						object obj25;
						if (list3 != null)
						{
							nint num7 = (nint)list3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ r10_v57 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>>)+12E]");
							if ((nint)0 >= (nint)0)
							{
								goto IL_041a;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ r10_v57 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>>)+B0]");
							obj20 = 0;
							Weapon weapon3 = null;
							while (true)
							{
								object obj21 = (object)weapon3 + (object)weapon3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1371 @ r8_v65+v2451 @ rax_v338*8]");
								if (0 == (nint)typeof(IEnumerator))
								{
									break;
								}
								weapon3 = (Weapon)(weapon3 + 1);
								Weapon weapon4 = weapon3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ r10_v57 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>>)+12E]");
								if ((nint)weapon4 < 0)
								{
									continue;
								}
								goto IL_041a;
							}
							object obj22 = (object)weapon3 + (object)weapon3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1371 @ r8_v65+8+v2603 @ rcx_v248*8]");
							object obj23 = (nint)0 << 4;
							object obj24 = obj23 + 312;
							obj25 = obj24 + num7;
							goto IL_19d9;
						}
						throw new NullReferenceException();
						IL_19d9:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2608 @ rdx_v74] (should have been resolved before IL gen)");
						if (obj26 == null)
						{
							break;
						}
						bool flag10 = list3 == null;
						list2 = list3;
						object obj27;
						object obj32;
						if (!flag10)
						{
							nint num8 = (nint)list3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1136 @ r10_v61 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>>)+12E]");
							if ((nint)0 >= (nint)0)
							{
								goto IL_04db;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1136 @ r10_v61 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>>)+B0]");
							obj27 = 0;
							Weapon weapon5 = null;
							while (true)
							{
								object obj28 = (object)weapon5 + (object)weapon5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1262 @ r8_v137+v2810 @ rax_v333*8]");
								if (0 == (nint)typeof(IEnumerator<Equipment>))
								{
									break;
								}
								weapon5 = (Weapon)(weapon5 + 1);
								Weapon weapon6 = weapon5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1136 @ r10_v61 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>>)+12E]");
								if ((nint)weapon6 < 0)
								{
									continue;
								}
								goto IL_04db;
							}
							object obj29 = (object)weapon5 + (object)weapon5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1262 @ r8_v137+8+v2951 @ rcx_v242*8]");
							object obj30 = (nint)0 << 4;
							object obj31 = obj30 + 312;
							obj32 = obj31 + num8;
							goto IL_1a00;
						}
						throw new NullReferenceException();
						IL_04db:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
						obj27 = 0;
						obj32 = obj33;
						goto IL_1a00;
						IL_19b7:
						object obj34;
						bool flag11 = obj34 == null;
						Weapon weapon7 = null;
						if (!flag11)
						{
							weapon7 = weapon8;
						}
						StatsDisplay statsDisplay = GenerateStatsDisplay(weapon7);
						bool flag12 = list == null;
						list2 = (List<StatsDisplay>)(&obj35);
						if (!flag12)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1183 @ rax_v323 (VampireSurvivors.UI.RecapPage+StatsDisplay)+40]");
							obj19 = 0;
							list.Add((StatsDisplay)(&text));
							list2 = list;
							continue;
						}
						throw new NullReferenceException();
						IL_1a00:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2956 @ rdx_v181] (should have been resolved before IL gen)");
						bool flag13 = (object)weapon8 == null;
						list2 = list3;
						if (!flag13)
						{
							bool flag14 = ((Equipment)weapon8)._equipmentType == WeaponType.LANCET;
							list2 = list3;
							if (flag14)
							{
								continue;
							}
							bool flag15 = ((Equipment)weapon8)._equipmentType == WeaponType.LAUREL;
							list2 = list3;
							if (flag15)
							{
								continue;
							}
							bool flag16 = ((Equipment)weapon8)._equipmentType == WeaponType.WINDOW;
							list2 = list3;
							if (flag16)
							{
								continue;
							}
							nint num9 = (nint)weapon8;
							nint num10 = (nint)typeof(Weapon);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3471 @ r8_v138 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
							object obj36 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3470 @ r9_v72 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
							nint num11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3471 @ r8_v138 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
							if (num11 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3470 @ r9_v72 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
								object obj37 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3625 @ rax_v327+FFFFFFF8+v3472 @ rax_v321*8]");
								if (0 == (nint)typeof(Weapon))
								{
									obj34 = 1;
									goto IL_19b7;
								}
							}
							obj34 = 0;
							goto IL_19b7;
						}
						throw new NullReferenceException();
						IL_041a:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
						obj20 = 0;
						obj25 = obj38;
						goto IL_19d9;
					}
					if ((object)characterController2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					}
					CalculateBestStats(list);
					bool flag17 = list == null;
					list2 = list;
					if (!flag17)
					{
						float num12 = 0f;
						object obj39 = default(object);
						List<StatsDisplay> list4 = default(List<StatsDisplay>);
						object obj41 = default(object);
						object obj46 = default(object);
						while (true)
						{
							if (obj39 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ stack_-228_v57+1C]");
								if (list4 == null)
								{
									object obj40 = obj41;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ stack_-228_v57+18]");
									if ((nint)obj40 < 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ stack_-228_v57+10]");
										object obj42 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ stack_-228_v57+10]");
										if ((nint)0 != 0)
										{
											object obj43 = obj41;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1632 @ rcx_v220+18]");
											if ((nint)obj43 < 0)
											{
												object obj44 = obj41 * 8;
												object obj45 = obj41 + obj44;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1632 @ rcx_v220+30+v3891 @ rax_v306*8]");
												num12 = 0f;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1632 @ rcx_v220+40+v3891 @ rax_v306*8]");
												float num13 = 0f;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1632 @ rcx_v220+50+v3891 @ rax_v306*8]");
												float num14 = 0f;
												obj41 = obj46 + 1;
												recapPage.GenerateWeaponRecap((StatsDisplay)(&text));
												continue;
											}
											throw new IndexOutOfRangeException();
										}
										throw new NullReferenceException();
									}
									break;
								}
								break;
							}
							throw new NullReferenceException();
						}
						if (obj39 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ stack_-228_v57+1C]");
							if (list4 == null)
							{
								int num15 = Enumerable.Count(dictionary);
								list2 = (List<StatsDisplay>)(object)recapPage._currentCharacter;
								if ((object)recapPage._currentCharacter != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1489 @ rcx_v62 (System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>)+C8]");
									list2 = (List<StatsDisplay>)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1489 @ rcx_v62 (System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>)+C8]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1489 @ rcx_v62 (System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>)+28]");
										list2 = (List<StatsDisplay>)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1489 @ rcx_v62 (System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>)+28]");
										if ((nint)0 != 0)
										{
											float num16 = num15;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1489 @ rcx_v62 (System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>)+18]");
											num17 = num16 + 0f;
											VampireSurvivors.Objects.Characters.CharacterController weaponIcons = (VampireSurvivors.Objects.Characters.CharacterController)(object)recapPage._WeaponIcons;
											if ((object)recapPage._WeaponIcons != null)
											{
												bool flag18 = ((UnityEngine.Object)weaponIcons).m_CachedPtr == (IntPtr)0;
												object obj47 = Transform.get_childCount_Injected(((UnityEngine.Object)weaponIcons).m_CachedPtr);
												object obj48 = obj47 - 1;
												if ((nint)obj48 < 0)
												{
													goto IL_097a;
												}
												while (true)
												{
													object weaponIcons2 = recapPage._WeaponIcons;
													if ((object)recapPage._WeaponIcons == null)
													{
														break;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rbx_v63 (System.Object)+10]");
													bool flag19 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rbx_v63 (System.Object)+10]");
													IntPtr child_Injected = Transform.GetChild_Injected((IntPtr)0, (int)obj48);
													Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(child_Injected);
													if ((object)transform == null)
													{
														break;
													}
													bool flag20 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
													IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)transform).m_CachedPtr);
													GameObject obj49 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
													nint num18 = (nint)typeof(UnityEngine.Object);
													UnityEngine.Object.Destroy(obj49, 0f);
													obj48--;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6990 @ rcx_v109 (Il2CppClass<UnityEngine.Object>)+E4]");
													bool flag21 = (nint)0 >= (nint)0;
													num12 = 0f;
													num19 = num19;
													if (flag21)
													{
														continue;
													}
													goto IL_097a;
												}
											}
										}
									}
								}
								goto IL_16c0;
							}
							System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
							List<StatsDisplay> list5 = null;
						}
						throw new NullReferenceException();
					}
				}
			}
		}
		goto IL_16c0;
		IL_097a:
		if (recapPage._dataManager != null)
		{
			Dictionary<WeaponType, List<WeaponData>> convertedWeapons = recapPage._dataManager.GetConvertedWeapons();
			Sequence sequence = DOTween.Sequence();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj51 = default(object);
			object obj50 = (object)(&obj51);
			object obj52 = null;
			float num20 = num17;
			object obj53 = null;
			Dictionary<WeaponType, int> dictionary2 = dictionary;
			Component component = recapPage;
			object obj65 = default(object);
			int num28 = default(int);
			float num35 = default(float);
			bool isWorldPos = default(bool);
			object obj72 = default(object);
			object obj75 = default(object);
			object obj76 = default(object);
			while (true)
			{
				bool flag22 = obj51 == null;
				nint num21 = (nint)obj51;
				object obj54 = obj52;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ r10_v59 (Il2CppClass<System.Object>)+12E]");
				if ((nint)obj54 >= 0)
				{
					goto IL_0a78;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ r10_v59 (Il2CppClass<System.Object>)+B0]");
				object obj55 = 0;
				object obj56 = obj52;
				while (true)
				{
					object obj57 = obj56 + obj56;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5779 @ r8_v75+v6402 @ rax_v300*8]");
					if (0 == (nint)typeof(IEnumerator))
					{
						break;
					}
					obj56++;
					object obj58 = obj56;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ r10_v59 (Il2CppClass<System.Object>)+12E]");
					if ((nint)obj58 < 0)
					{
						continue;
					}
					goto IL_0a78;
				}
				object obj59 = obj56 + obj56;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5779 @ r8_v75+8+v6682 @ rcx_v214*8]");
				object obj60 = (nint)0 << 4;
				object obj61 = obj60 + 312;
				object obj62 = obj61 + num21;
				goto IL_1cfa;
				IL_1cd5:
				object obj63;
				bool flag23 = obj63 == null;
				object obj64 = obj52;
				if (!flag23)
				{
					obj64 = obj65;
				}
				if (obj64 == null)
				{
					continue;
				}
				bool flag24 = dictionary2 == null;
				Dictionary<WeaponType, int> dictionary3 = dictionary2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6129 @ rax_v243 (System.Object)+48]");
				int num22 = dictionary3.FindEntry(WeaponType.VOID);
				if (!flag24)
				{
					Dictionary<WeaponType, int> dictionary4 = dictionary2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6129 @ rax_v243 (System.Object)+48]");
					int num23 = dictionary4.get_Item(WeaponType.VOID);
					bool flag25 = num23 <= 1;
					int num24 = 1;
					int num25 = 1;
					if (!flag25)
					{
						Dictionary<WeaponType, int> dictionary5 = dictionary2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6129 @ rax_v243 (System.Object)+48]");
						int num26 = dictionary5.get_Item(WeaponType.VOID);
						num24 = num26;
						num25 = num26;
					}
					Dictionary<WeaponType, int> dictionary6 = dictionary2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6129 @ rax_v243 (System.Object)+48]");
					bool flag26 = dictionary6.Remove(WeaponType.VOID);
					bool flag27 = convertedWeapons == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3316 @ r14_v66 (System.Object)+48]");
					object obj66 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
					bool flag28 = obj66 == null;
					List<WeaponData> list6 = ((Dictionary<WeaponType, List<WeaponData>>)obj66).get_Item(WeaponType.VOID);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3316 @ r14_v66 (System.Object)+48]");
					object obj67 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
					bool flag29 = obj67 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ r13_v57 (UnityEngine.Component)+148]");
					bool flag30 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ r13_v57 (UnityEngine.Component)+148]");
					GameObject original = ((Component)0).gameObject;
					GameObject gameObject = UnityEngine.Object.Instantiate(original, recapPage._WeaponIcons);
					bool flag31 = (object)gameObject == null;
					IconQuantityUI component2 = gameObject.GetComponent<IconQuantityUI>();
					bool flag32 = list6 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8153 @ rax_v254 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+40]");
					nint num27 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8153 @ rax_v254 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+38]");
					Sprite sprite = SpriteManager.GetSprite((string)num27, (string)0);
					bool flag33 = (object)component2 == null;
					bool flag34 = (object)component2._Icon == null;
					component2._Icon.sprite = sprite;
					CanvasGroup component3 = component2.GetComponent<CanvasGroup>();
					string text2 = num28.ToString();
					object quantityText = component2._QuantityText;
					bool flag35 = (object)component2._QuantityText == null;
					nint num29 = (nint)quantityText;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8238 @ r8_v108 (Il2CppClass<System.Object>)+558]");
					object obj68 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v8238 @ r8_v108 (Il2CppClass<System.Object>)+558] (should have been resolved before IL gen)");
					if (num25 != 1)
					{
						string text3 = num24.ToString();
						string text4 = "x" + text3;
						object quantityText2 = component2._QuantityText;
						bool flag36 = (object)component2._QuantityText == null;
						nint num30 = (nint)quantityText2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8324 @ r8_v117 (Il2CppClass<System.Object>)+558]");
						obj68 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v8324 @ r8_v117 (Il2CppClass<System.Object>)+558] (should have been resolved before IL gen)");
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3316 @ r14_v66 (System.Object)+4C]");
					nint num31 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5144 @ rax_v256 (System.Object)+18]");
					if (num31 >= 0)
					{
						float num13 = 0.015686275f;
						float num32 = 47f / 51f;
					}
					else
					{
						float num13 = 1f;
						float num32 = 1f;
					}
					object quantityText3 = component2._QuantityText;
					bool flag37 = (object)component2._QuantityText == null;
					nint num33 = (nint)quantityText3;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v8326 @ r8_v111 (Il2CppClass<System.Object>)+2A8] (should have been resolved before IL gen)");
					bool flag38 = (object)component3 == null;
					component3.alpha = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3034 @ stack_8 (VampireSurvivors.UI.RecapPage)+270]");
					bool flag39 = (nint)0 != 0;
					float num34 = 0.25f;
					if (!flag39)
					{
						num34 = 0f;
					}
					GameObject gameObject2 = component2.gameObject;
					bool flag40 = (object)gameObject2 == null;
					TweenToLayoutGroup tweenToLayoutGroup = gameObject2.AddComponent<TweenToLayoutGroup>();
					Transform sender = recapPage.transform;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3034 @ stack_8 (VampireSurvivors.UI.RecapPage)+198]");
					bool flag41 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3034 @ stack_8 (VampireSurvivors.UI.RecapPage)+198]");
					Vector3 position = ((Transform)0).position;
					bool flag42 = (object)tweenToLayoutGroup == null;
					num20 = position.x;
					tweenToLayoutGroup.TweenFromLocationToLayoutSpot(sender, (Vector3)(&num35), num34, num19, isWorldPos);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3034 @ stack_8 (VampireSurvivors.UI.RecapPage)+270]");
					if ((nint)0 == 0)
					{
						tweenToLayoutGroup.Complete();
					}
					object obj69 = obj53 + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3034 @ stack_8 (VampireSurvivors.UI.RecapPage)+260]");
					bool flag43 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
					obj52 = null;
					float num14 = num34;
					float num12 = 0f;
					obj53 = obj69;
					dictionary2 = dictionary;
					component = recapPage;
				}
				else
				{
					obj52 = null;
				}
				continue;
				IL_0b2f:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				object obj70 = 0;
				object obj71 = obj72;
				goto IL_1d21;
				IL_1d21:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v7385 @ rdx_v124] (should have been resolved before IL gen)");
				if (obj65 == null)
				{
					continue;
				}
				nint num36 = (nint)obj65;
				nint num37 = (nint)typeof(Weapon);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7505 @ rax_v244 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				object obj73 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5657 @ r8_v97 (Il2CppClass<System.Object>)+130]");
				nint num38 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7505 @ rax_v244 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				if (num38 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5657 @ r8_v97 (Il2CppClass<System.Object>)+C8]");
					object obj74 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7642 @ rcx_v203 (System.Object)+FFFFFFF8+v7506 @ rcx_v167 (System.Object)*8]");
					if (0 == (nint)typeof(Weapon))
					{
						obj63 = 1;
						goto IL_1cd5;
					}
				}
				obj63 = 0;
				goto IL_1cd5;
				IL_0a78:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				obj55 = 0;
				obj62 = obj75;
				goto IL_1cfa;
				IL_1cfa:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v6687 @ rdx_v92] (should have been resolved before IL gen)");
				if (obj76 == null)
				{
					break;
				}
				bool flag44 = obj51 == null;
				nint num39 = (nint)obj51;
				object obj77 = obj52;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3266 @ r10_v60 (Il2CppClass<System.Object>)+12E]");
				if ((nint)obj77 >= 0)
				{
					goto IL_0b2f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3266 @ r10_v60 (Il2CppClass<System.Object>)+B0]");
				obj70 = 0;
				object obj78 = obj52;
				while (true)
				{
					object obj79 = obj78 + obj78;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6091 @ r8_v96+v7127 @ rax_v295*8]");
					if (0 == (nint)typeof(IEnumerator<Equipment>))
					{
						break;
					}
					obj78++;
					object obj80 = obj78;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3266 @ r10_v60 (Il2CppClass<System.Object>)+12E]");
					if ((nint)obj80 < 0)
					{
						continue;
					}
					goto IL_0b2f;
				}
				object obj81 = obj78 + obj78;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6091 @ r8_v96+8+v7380 @ rcx_v208*8]");
				object obj82 = (nint)0 << 4;
				object obj83 = obj82 + 312;
				obj71 = obj83 + num39;
				goto IL_1d21;
			}
			if (obj50 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				list2 = null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ r13_v57 (UnityEngine.Component)+250]");
			object obj84 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ r13_v57 (UnityEngine.Component)+250]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v511 @ rax_v191+C8]");
				object obj85 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v511 @ rax_v191+C8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ r9_v61+28]");
					if ((nint)0 != 0)
					{
						List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
						while (enumerator.MoveNext())
						{
							float num40 = 0f;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ r13_v57 (UnityEngine.Component)+120]");
						bool flag45 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ r13_v57 (UnityEngine.Component)+120]");
						RectTransform component4 = ((Component)0).GetComponent<RectTransform>();
						LayoutRebuilder.ForceRebuildLayoutImmediate(component4);
						Canvas.ForceUpdateCanvases();
						return;
					}
				}
			}
		}
		goto IL_16c0;
		IL_16c0:
		throw new NullReferenceException();
	}

	private unsafe static void CalculateBestStats(List<StatsDisplay> allStats)
	{
		//IL_0008: Expected O, but got Ref
		//IL_003e: Expected O, but got I4
		//IL_004b: Expected O, but got I8
		//IL_005d: Expected O, but got I4
		//IL_0194: Expected O, but got I
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		//IL_0099: Expected O, but got I
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00fd: Invalid comparison between I and F4
		//IL_01fc: Expected O, but got Ref
		//IL_0267: Expected O, but got I8
		//IL_0270: Expected O, but got I4
		//IL_04ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b0: Expected O, but got Unknown
		//IL_03b8: Expected O, but got I
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Expected O, but got Unknown
		//IL_02b5: Expected O, but got I
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Expected O, but got Unknown
		//IL_0319: Invalid comparison between I and F4
		//IL_0420: Expected O, but got Ref
		//IL_04c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cb: Expected O, but got Unknown
		//IL_037c: Expected F4, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [allStats @ rcx (System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>)+18]");
		if ((nint)0 <= (nint)1)
		{
			return;
		}
		object obj3 = 0;
		object obj4 = 4294967295L;
		float num = -3.4028235E+38f;
		object obj5 = 0;
		float num2 = default(float);
		while (true)
		{
			object obj6 = obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [allStats @ rcx (System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>)+18]");
			if ((nint)obj6 < 0)
			{
				object obj7 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [allStats @ rcx (System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>)+18]");
				if ((nint)obj7 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [allStats @ rcx (System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>)+10]");
				object obj8 = 0;
				object obj9 = obj3 * 8;
				object obj10 = obj3 + obj9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v14+20+v288 @ r8_v9*8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v14+30+v288 @ r8_v9*8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v14+50+v288 @ r8_v9*8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v14+60+v288 @ r8_v9*8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v14+48+v288 @ r8_v9*8]");
				if (0f > num)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v14+20+v288 @ r8_v9*8]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v14+30+v288 @ r8_v9*8]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v14+50+v288 @ r8_v9*8]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v14+60+v288 @ r8_v9*8]");
					_ = 0;
					obj4 = obj3;
					num = num2;
				}
				obj3++;
				obj5 = obj3;
				continue;
			}
			object obj11 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [allStats @ rcx (System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>)+18]");
			if ((nint)obj11 >= 0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [allStats @ rcx (System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>)+10]");
			object obj12 = 0;
			object obj13 = obj4 * 8;
			object obj14 = obj4 + obj13;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rdx_v7+40+v453 @ rcx_v8*8]");
			_ = 0;
			_ = 1;
			object obj15 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [allStats @ rcx (System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>)+18]");
			if ((nint)obj15 >= 0)
			{
				break;
			}
			object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+17]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rdx_v7+20+v453 @ rcx_v8*8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rdx_v7+30+v453 @ rcx_v8*8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rdx_v7+50+v453 @ rcx_v8*8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rdx_v7+60+v453 @ rcx_v8*8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805FAB00");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [allStats @ rcx (System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>)+1C]");
			_ = (nint)0 + (nint)1;
			object obj17 = 4294967295L;
			object obj18 = 0;
			float num3 = -3.4028235E+38f;
			while (true)
			{
				object obj19 = obj18;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [allStats @ rcx (System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>)+18]");
				if ((nint)obj19 < 0)
				{
					object obj20 = obj18;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [allStats @ rcx (System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>)+18]");
					if ((nint)obj20 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [allStats @ rcx (System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>)+10]");
					object obj21 = 0;
					object obj22 = obj18 * 8;
					object obj23 = obj18 + obj22;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v13+20+v524 @ rdx_v12*8]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v13+30+v524 @ rdx_v12*8]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v13+50+v524 @ rdx_v12*8]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v13+60+v524 @ rdx_v12*8]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v13+40+v524 @ rdx_v12*8]");
					if (0f > num3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v13+20+v524 @ rdx_v12*8]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v13+30+v524 @ rdx_v12*8]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v13+50+v524 @ rdx_v12*8]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v13+60+v524 @ rdx_v12*8]");
						_ = 0;
						obj17 = obj18;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v13+40+v524 @ rdx_v12*8]");
						num3 = 0f;
					}
					obj18++;
					continue;
				}
				object obj24 = obj17;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [allStats @ rcx (System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>)+18]");
				if ((nint)obj24 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [allStats @ rcx (System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>)+10]");
				object obj25 = 0;
				object obj26 = obj17 * 8;
				object obj27 = obj17 + obj26;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rdx_v10+40+v454 @ rcx_v11*8]");
				_ = 0;
				_ = 1;
				object obj28 = obj17;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [allStats @ rcx (System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>)+18]");
				if ((nint)obj28 >= 0)
				{
					break;
				}
				object obj29 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+17]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rdx_v10+20+v454 @ rcx_v11*8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rdx_v10+30+v454 @ rcx_v11*8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rdx_v10+50+v454 @ rcx_v11*8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rdx_v10+60+v454 @ rcx_v11*8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805FAB00");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [allStats @ rcx (System.Collections.Generic.List`1<VampireSurvivors.UI.RecapPage+StatsDisplay>)+1C]");
				_ = (nint)0 + (nint)1;
				return;
			}
			break;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	private unsafe StatsDisplay GenerateStatsDisplay(Weapon weapon)
	{
		//IL_02ce: Expected native int or pointer, but got O
		//IL_02d8: Expected native int or pointer, but got O
		//IL_02e6: Expected native int or pointer, but got O
		//IL_02f4: Expected native int or pointer, but got O
		//IL_007e: Expected O, but got I
		//IL_0093: Expected O, but got I
		//IL_0328: Expected O, but got I
		//IL_015e: Expected O, but got I
		//IL_0348: Expected native int or pointer, but got O
		//IL_0352: Expected native int or pointer, but got O
		//IL_0360: Expected native int or pointer, but got O
		//IL_036e: Expected native int or pointer, but got O
		//IL_03a7: Expected native int or pointer, but got O
		//IL_03d5: Expected native int or pointer, but got O
		//IL_03be: Expected native int or pointer, but got O
		//IL_0273: Expected native int or pointer, but got O
		//IL_0285: Expected native int or pointer, but got O
		//IL_0297: Expected native int or pointer, but got O
		//IL_02b1: Expected native int or pointer, but got O
		//IL_02bf: Expected native int or pointer, but got O
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Expected Ref, but got Unknown
		//IL_0207: Expected I8, but got I4
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected Ref, but got Unknown
		StatsDisplay statsDisplay = default(StatsDisplay);
		System.Runtime.CompilerServices.Unsafe.Write(&((StatsDisplay*)(nint)statsDisplay)->Name, null);
		System.Runtime.CompilerServices.Unsafe.Write(&((StatsDisplay*)(nint)statsDisplay)->WeaponFrameName, null);
		((StatsDisplay*)(nint)statsDisplay)->InflictedDamage = 0f;
		((StatsDisplay*)(nint)statsDisplay)->Owner = CharacterType.VOID;
		_ = 0;
		float num = weapon.CalculateTotalDamage();
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)((Equipment)weapon)._equipmentType);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v12 (System.Object)+18]");
		WeaponData weaponData;
		Color nameColor;
		string text;
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v12 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rax_v13+20]");
			weaponData = (WeaponData)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C61]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rax_v13+20]");
			string prefix = ((WeaponData)0).GetPrefix(((Equipment)weapon)._equipmentType);
			string term = prefix + "name";
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			VampireSurvivors.Objects.Characters.CharacterController currentCharacter = _currentCharacter;
			CharacterWeaponsManager weaponsManager = currentCharacter._weaponsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0AA0");
			object obj3 = default(object);
			if (obj3 != null)
			{
				nameColor = hiddenWeaponNameColor;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
				nameColor = (Color)0;
			}
			System.Runtime.CompilerServices.Unsafe.Write(&((StatsDisplay*)(nint)statsDisplay)->Name, null);
			System.Runtime.CompilerServices.Unsafe.Write(&((StatsDisplay*)(nint)statsDisplay)->WeaponFrameName, null);
			((StatsDisplay*)(nint)statsDisplay)->InflictedDamage = 0f;
			((StatsDisplay*)(nint)statsDisplay)->Owner = CharacterType.VOID;
			_ = 0;
			object obj4 = "";
			if ((object)translation == "")
			{
				goto IL_024c;
			}
			bool flag = translation == null;
			text = translation;
			if (!flag)
			{
				bool flag2 = "" == null;
				text = translation;
				if (!flag2)
				{
					int stringLength = translation._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rdx_v11+10]");
					bool flag3 = (nint)stringLength != 0;
					text = translation;
					if (!flag3)
					{
						ref byte first = ref *(byte*)(translation + 20);
						ulong length = (ulong)(translation._stringLength + translation._stringLength);
						bool flag4 = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("" + 20), length);
						bool flag5 = !flag4;
						text = translation;
						if (!flag5)
						{
							goto IL_024c;
						}
					}
				}
			}
			goto IL_039f;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		StatsDisplay result = default(StatsDisplay);
		return result;
		IL_039f:
		System.Runtime.CompilerServices.Unsafe.Write(&((StatsDisplay*)(nint)statsDisplay)->Name, text);
		System.Runtime.CompilerServices.Unsafe.Write(&((StatsDisplay*)(nint)statsDisplay)->WeaponFrameName, weaponData._003CframeName_003Ek__BackingField);
		System.Runtime.CompilerServices.Unsafe.Write(&((StatsDisplay*)(nint)statsDisplay)->WeaponTextureName, weaponData._003Ctexture_003Ek__BackingField);
		((StatsDisplay*)(nint)statsDisplay)->Level = ((Equipment)weapon)._003CLevel_003Ek__BackingField;
		((StatsDisplay*)(nint)statsDisplay)->InflictedDamage = weapon._003CStatsInflictedDamage_003Ek__BackingField;
		((StatsDisplay*)(nint)statsDisplay)->Lifetime = weapon._003CStatsLifetime_003Ek__BackingField;
		float num2 = weapon.StatsGetDps();
		((StatsDisplay*)(nint)statsDisplay)->NameColor = nameColor;
		((StatsDisplay*)(nint)statsDisplay)->Dps = 0f;
		return statsDisplay;
		IL_024c:
		string text2 = ((UnityEngine.Object)weapon).GetName();
		text = text2;
		goto IL_039f;
	}

	public unsafe void AddPowerUps()
	{
		//IL_0079: Expected O, but got I
		//IL_0106: Expected F4, but got I4
		//IL_010f: Expected F4, but got I4
		//IL_024e: Expected O, but got I
		//IL_02a3: Expected O, but got I
		//IL_0323: Expected O, but got I
		//IL_0378: Expected O, but got I
		//IL_03c0: Expected O, but got I
		//IL_03c0: Expected O, but got I
		//IL_0452: Expected I, but got O
		//IL_04c8: Expected O, but got Ref
		//IL_05a3: Expected O, but got Ref
		//IL_05b9->IL061f: Incompatible stack heights: 22 vs 0
		Dictionary<PowerUpType, List<PowerUpData>> convertedPowerUpData = _dataManager.GetConvertedPowerUpData();
		Dictionary<PowerUpType, PlayerStat> ownedPowerUps = _playerStats.GetOwnedPowerUps();
		GameObject gameObject = _StatIcons.gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rax_v6 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.PowerUpType, VampireSurvivors.PlayerStat>)+20]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rax_v6 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.PowerUpType, VampireSurvivors.PlayerStat>)+28]");
		object obj = num - 0;
		object obj2 = obj ^ obj;
		object obj3 = obj & obj2;
		bool flag = (nint)obj3 < 0;
		bool flag2 = (nint)obj < 0;
		bool flag3 = obj == null;
		bool flag4 = flag2 == flag;
		bool flag5 = !flag3;
		bool active = flag5 & flag4;
		gameObject.SetActive(active);
		float num2 = 0f;
		float num3 = 2f;
		Dictionary<PowerUpType, List<PowerUpData>> dictionary = convertedPowerUpData;
		RecapPage recapPage = this;
		Dictionary<PowerUpType, PlayerStat>.Enumerator enumerator = default(Dictionary<PowerUpType, PlayerStat>.Enumerator);
		int num5 = default(int);
		object obj11 = default(object);
		RecapPage recapPage2 = default(RecapPage);
		float num9 = default(float);
		float delay = default(float);
		bool isWorldPos = default(bool);
		while (enumerator.MoveNext())
		{
			bool flag6 = dictionary == null;
			object obj4 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)0);
			bool flag7 = obj4 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
			System.Int32Enum int32Enum = (System.Int32Enum)0;
			IconQuantityUI quantityIconPrefab = recapPage._QuantityIconPrefab;
			bool flag8 = (object)recapPage._QuantityIconPrefab == null;
			bool flag9 = ((UnityEngine.Object)quantityIconPrefab).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)quantityIconPrefab).m_CachedPtr);
			GameObject original = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
			GameObject gameObject2 = UnityEngine.Object.Instantiate(original, recapPage._StatIcons);
			bool flag10 = (object)gameObject2 == null;
			IconQuantityUI component = gameObject2.GetComponent<IconQuantityUI>();
			object obj5 = ((Dictionary<System.Int32Enum, object>)(object)convertedPowerUpData).get_Item((System.Int32Enum)0);
			bool flag11 = obj5 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1013 @ rax_v34 (System.Object)+18]");
			bool flag12 = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1013 @ rax_v34 (System.Object)+10]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1013 @ rax_v34 (System.Object)+10]");
			bool flag13 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v940 @ rax_v35+18]");
			bool flag14 = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v940 @ rax_v35+20]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v940 @ rax_v35+20]");
			bool flag15 = (nint)0 == 0;
			object obj8 = ((Dictionary<System.Int32Enum, object>)(object)convertedPowerUpData).get_Item((System.Int32Enum)0);
			bool flag16 = obj8 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1439 @ rax_v36 (System.Object)+18]");
			bool flag17 = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1439 @ rax_v36 (System.Object)+10]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1439 @ rax_v36 (System.Object)+10]");
			bool flag18 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v37+18]");
			bool flag19 = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v37+20]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v37+20]");
			bool flag20 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1380 @ rcx_v29+38]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1545 @ rdx_v22+30]");
			Sprite sprite = SpriteManager.GetSprite((string)num4, (string)0);
			bool flag21 = (object)component == null;
			bool flag22 = (object)component._Icon == null;
			component._Icon.sprite = sprite;
			Dictionary<PowerUpType, List<PowerUpData>> quantityText = (Dictionary<PowerUpType, List<PowerUpData>>)(object)component._QuantityText;
			string text = num5.ToString();
			bool flag23 = (object)component._QuantityText == null;
			nint num6 = (nint)quantityText;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1679 @ r8_v16 (Il2CppClass<System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.PowerUpType, System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUp.PowerUpData>>>)+558] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ r15_v6 (System.Int32Enum)+14]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rax_v17 (System.Object)+18]");
			if (num7 >= 0)
			{
				float num8 = 0.015686275f;
				num2 = 47f / 51f;
			}
			else
			{
				float num8 = 1f;
				num2 = 1f;
			}
			bool flag24 = (object)component._QuantityText == null;
			component._QuantityText.color = (Color)(&obj11);
			Sprite sprite2 = SpriteManager.GetSprite("FrameD", "UI");
			component.SetFrame(sprite2);
			GameObject gameObject3 = component.gameObject;
			bool flag25 = (object)gameObject3 == null;
			TweenToLayoutGroup tweenToLayoutGroup = gameObject3.AddComponent<TweenToLayoutGroup>();
			bool flag26 = (object)recapPage2._TweenOrigin == null;
			Vector3 position = recapPage2._TweenOrigin.position;
			bool flag27 = (object)tweenToLayoutGroup == null;
			num3 = position.x;
			tweenToLayoutGroup.TweenFromLocationToLayoutSpot(recapPage2._rectTransform, (Vector3)(&num9), 0.25f, delay, isWorldPos);
			dictionary = convertedPowerUpData;
			recapPage = recapPage2;
		}
	}

	public unsafe void AddCollectedItems()
	{
		//IL_1192: Expected O, but got I
		//IL_00c3: Expected O, but got I
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_04b6: Expected O, but got I
		//IL_04a1: Expected O, but got I
		//IL_048c: Expected O, but got I
		//IL_0454: Expected O, but got I
		//IL_0517: Expected O, but got I4
		//IL_024f: Expected O, but got I4
		//IL_0604: Expected O, but got I
		//IL_05ef: Expected O, but got I
		//IL_02f5: Expected O, but got I
		//IL_05da: Expected O, but got I
		//IL_05a2: Expected O, but got I
		//IL_035d: Expected O, but got I
		//IL_06b2: Expected O, but got I
		//IL_116c: Expected I4, but got O
		//IL_03bc: Expected O, but got I
		//IL_0976: Expected O, but got I
		//IL_0961: Expected O, but got I
		//IL_094c: Expected O, but got I
		//IL_0774: Expected O, but got I
		//IL_0914: Expected O, but got I
		//IL_0a30: Expected O, but got I
		//IL_0a89: Expected O, but got I
		//IL_0abe: Expected O, but got I
		//IL_0b1b: Expected O, but got I
		//IL_0b4f: Expected O, but got I
		//IL_0c4a: Expected O, but got I
		//IL_0b8a: Expected O, but got I
		//IL_0ce2: Expected O, but got I
		//IL_0d56: Expected F4, but got I4
		//IL_0da4: Expected O, but got I
		//IL_0dad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db2: Expected O, but got Unknown
		//IL_0dd3: Expected O, but got I
		//IL_136b: Expected I, but got O
		//IL_0ec4: Expected O, but got I
		//IL_0f3f: Expected I4, but got O
		//IL_0fc2: Expected F4, but got O
		//IL_0fc2: Expected O, but got Ref
		//IL_08ad->IL105d: Incompatible stack heights: 2 vs 0
		//IL_1307->IL105d: Incompatible stack heights: 2 vs 0
		//IL_0995->IL105d: Incompatible stack heights: 2 vs 0
		//IL_09c1->IL105d: Incompatible stack heights: 2 vs 0
		//IL_09f7->IL105d: Incompatible stack heights: 2 vs 0
		//IL_0a50->IL105d: Incompatible stack heights: 3 vs 0
		//IL_132d->IL105d: Incompatible stack heights: 4 vs 0
		//IL_0bdb->IL105d: Incompatible stack heights: 4 vs 0
		//IL_0bfd->IL105d: Incompatible stack heights: 4 vs 0
		//IL_0b6f->IL105d: Incompatible stack heights: 5 vs 0
		//IL_0c30->IL105d: Incompatible stack heights: 4 vs 0
		//IL_0b9b->IL130c: Incompatible stack heights: 5 vs 4
		//IL_0c73->IL105d: Incompatible stack heights: 4 vs 0
		//IL_0c95->IL105d: Incompatible stack heights: 4 vs 0
		//IL_0cc8->IL105d: Incompatible stack heights: 4 vs 0
		//IL_0cff->IL105d: Incompatible stack heights: 4 vs 0
		//IL_1008->IL138a: Incompatible stack heights: 4 vs 1
		//IL_0fd5->IL1337: Incompatible stack heights: 10 vs 4
		List<CustomPickupData> list = new List<CustomPickupData>();
		object obj10;
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				List<ItemType> list2 = config._003CRunPickups_003Ek__BackingField;
				if (config._003CRunPickups_003Ek__BackingField != null)
				{
					object obj = default(object);
					object obj2 = default(object);
					object obj4 = default(object);
					while (true)
					{
						if (obj != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ stack_-B0_v32+1C]");
							if (obj2 != null)
							{
								break;
							}
							object obj3 = obj4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ stack_-B0_v32+18]");
							if ((nint)obj3 >= 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ stack_-B0_v32+10]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ stack_-B0_v32+10]");
							if ((nint)0 != 0)
							{
								object obj6 = obj4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ rax_v222+18]");
								if ((nint)obj6 < 0)
								{
									object obj7 = obj4 + 1;
									_003C_003Ec__DisplayClass76_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass76_0();
									if (CS_0024_003C_003E8__locals5 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ rax_v222+20+v614 @ stack_-A8_v31*4]");
										CS_0024_003C_003E8__locals5.itemType = ItemType.VOID;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ rax_v222+20+v614 @ stack_-A8_v31*4]");
										bool flag = (nint)0 == 8;
										obj4 = obj7;
										if (flag)
										{
											continue;
										}
										Predicate<CustomPickupData> match = delegate(CustomPickupData data)
										{
											//IL_005b: Expected I4, but got O
											//IL_0022: Unknown result type (might be due to invalid IL or missing references)
											//IL_0027: Expected O, but got Unknown
											//IL_0043: Unknown result type (might be due to invalid IL or missing references)
											//IL_0048: Expected I4, but got Unknown
											if (data == null)
											{
												NullReferenceException ex = new NullReferenceException();
												return (byte)(int)ex != 0;
											}
											object obj26 = (object?)data.ItemType >> 32;
											object obj27 = obj26 - CS_0024_003C_003E8__locals5.itemType;
											bool flag20 = obj27 == null;
											return (byte)((flag20 & (_003F?)data.ItemType) ? 1 : 0) != 0;
										};
										if (list != null)
										{
											CustomPickupData customPickupData = list.Find(match);
											if (customPickupData != null)
											{
												int amount = customPickupData.Amount + 1;
												customPickupData.Amount = amount;
												obj4 = obj7;
												list2 = null;
												continue;
											}
											CustomPickupData customPickupData2 = new CustomPickupData();
											if (customPickupData2 != null)
											{
												customPickupData2.ItemType = (ItemType?)(object)1;
												customPickupData2.Amount = 1;
												DataManager dataManager = _dataManager;
												if (_dataManager != null)
												{
													if (dataManager._003CAllItems_003Ek__BackingField != null)
													{
														object obj8 = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllItems_003Ek__BackingField).get_Item((System.Int32Enum)CS_0024_003C_003E8__locals5.itemType);
														if (obj8 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1000 @ rax_v232 (System.Object)+38]");
															customPickupData2.FrameName = (string)0;
															list2 = (List<ItemType>)(object)_dataManager;
															if (_dataManager != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ r9_v32 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+168]");
																if ((nint)0 != 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ r9_v32 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+168]");
																	object obj9 = ((Dictionary<System.Int32Enum, object>)0).get_Item((System.Int32Enum)CS_0024_003C_003E8__locals5.itemType);
																	if (obj9 != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v699 @ rax_v235 (System.Object)+30]");
																		bool flag2 = (nint)0 == 0;
																		string textureName = "items";
																		if (!flag2)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v699 @ rax_v235 (System.Object)+30]");
																			textureName = (string)0;
																		}
																		customPickupData2.TextureName = textureName;
																		ItemData itemData = ((Dictionary<ItemType, ItemData>)(object)list).get_Item((ItemType)customPickupData2);
																		obj4 = obj7;
																		continue;
																	}
																	throw new NullReferenceException();
																}
																throw new NullReferenceException();
															}
															throw new NullReferenceException();
														}
														throw new NullReferenceException();
													}
													throw new NullReferenceException();
												}
												throw new NullReferenceException();
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								throw new IndexOutOfRangeException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					bool flag3 = obj == null;
					PlayerOptions playerOptions = (PlayerOptions)0;
					if (!flag3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ stack_-B0_v32+1C]");
						if (obj2 == null)
						{
							GameObject playerOptions2 = (GameObject)(object)_playerOptions;
							if (_playerOptions == null)
							{
								goto IL_105d;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rbx_v32 (UnityEngine.GameObject)+68]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rbx_v32 (UnityEngine.GameObject)+58]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rbx_v32 (UnityEngine.GameObject)+78]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rbx_v32 (UnityEngine.GameObject)+78]");
										obj10 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rax_v83+2CC]");
										if ((nint)0 != 0)
										{
											goto IL_11f1;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rbx_v32 (UnityEngine.GameObject)+50]");
									obj10 = 0;
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rbx_v32 (UnityEngine.GameObject)+58]");
									obj10 = 0;
								}
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rbx_v32 (UnityEngine.GameObject)+68]");
								obj10 = 0;
							}
							goto IL_11f1;
						}
						System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
						playerOptions = null;
					}
					throw new NullReferenceException();
				}
			}
		}
		goto IL_105d;
		IL_1236:
		object obj11;
		CustomPickupData customPickupData3;
		if (obj11 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v189+C8]");
			customPickupData3.Amount = 0;
			DataManager dataManager2 = _dataManager;
			if (_dataManager != null && dataManager2._003CAllItems_003Ek__BackingField != null)
			{
				object obj12 = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllItems_003Ek__BackingField).get_Item((System.Int32Enum)2);
				if (obj12 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rax_v192 (System.Object)+38]");
					customPickupData3.FrameName = (string)0;
					DataManager dataManager3 = _dataManager;
					if (_dataManager != null && dataManager3._003CAllItems_003Ek__BackingField != null)
					{
						object obj13 = ((Dictionary<System.Int32Enum, object>)(object)dataManager3._003CAllItems_003Ek__BackingField).get_Item((System.Int32Enum)2);
						if (obj13 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rax_v196 (System.Object)+30]");
							bool flag4 = (nint)0 == 0;
							string textureName2 = "items";
							if (!flag4)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rax_v196 (System.Object)+30]");
								textureName2 = (string)0;
							}
							customPickupData3.TextureName = textureName2;
							if (list != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0B10");
								goto IL_07c3;
							}
						}
					}
				}
			}
		}
		goto IL_105d;
		IL_11f1:
		if (obj10 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rax_v83+C8]");
			if ((nint)0 > (nint)0)
			{
				customPickupData3 = new CustomPickupData();
				if (customPickupData3 != null)
				{
					customPickupData3.ItemType = (ItemType?)(object)1;
					GameObject playerOptions3 = (GameObject)(object)_playerOptions;
					if (_playerOptions != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbx_v49 (UnityEngine.GameObject)+68]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbx_v49 (UnityEngine.GameObject)+58]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbx_v49 (UnityEngine.GameObject)+78]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbx_v49 (UnityEngine.GameObject)+78]");
									obj11 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v189+2CC]");
									if ((nint)0 != 0)
									{
										goto IL_1236;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbx_v49 (UnityEngine.GameObject)+50]");
								obj11 = 0;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbx_v49 (UnityEngine.GameObject)+58]");
								obj11 = 0;
							}
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbx_v49 (UnityEngine.GameObject)+68]");
							obj11 = 0;
						}
						goto IL_1236;
					}
				}
			}
			else if (list != null)
			{
				goto IL_07c3;
			}
		}
		goto IL_105d;
		IL_07c3:
		List<object> list3;
		object obj14;
		if (list._size > 0)
		{
			if ((object)_LootIcons != null)
			{
				GameObject gameObject = _LootIcons.gameObject;
				if ((object)gameObject != null)
				{
					bool flag5 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					GameObject.SetActive_Injected(((UnityEngine.Object)gameObject).m_CachedPtr, true);
					Func<CustomPickupData, int> keySelector = _003C_003Ec._003C_003E9__76_0;
					if (_003C_003Ec._003C_003E9__76_0 == null)
					{
						keySelector = (_003C_003Ec._003C_003E9__76_0 = delegate(CustomPickupData o)
						{
							//IL_0035: Expected I4, but got O
							if (o == null)
							{
								NullReferenceException ex = new NullReferenceException();
								return (int)ex;
							}
							return o.Amount;
						});
					}
					IOrderedEnumerable<CustomPickupData> orderedEnumerable = Enumerable.OrderBy(list, keySelector);
					bool flag6 = orderedEnumerable == null;
					list3 = new List<object>(orderedEnumerable);
					GameObject playerOptions4 = (GameObject)(object)_playerOptions;
					if (_playerOptions != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v40 (UnityEngine.GameObject)+68]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v40 (UnityEngine.GameObject)+58]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v40 (UnityEngine.GameObject)+78]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v40 (UnityEngine.GameObject)+78]");
									obj14 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rax_v108+2CC]");
									if ((nint)0 != 0)
									{
										goto IL_12ef;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v40 (UnityEngine.GameObject)+50]");
								obj14 = 0;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v40 (UnityEngine.GameObject)+58]");
								obj14 = 0;
							}
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v40 (UnityEngine.GameObject)+68]");
							obj14 = 0;
						}
						goto IL_12ef;
					}
				}
			}
		}
		else if ((object)_LootIcons != null)
		{
			GameObject gameObject2 = _LootIcons.gameObject;
			if ((object)gameObject2 != null)
			{
				bool flag7 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
				GameObject.SetActive_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr, false);
				return;
			}
		}
		goto IL_105d;
		IL_105d:
		throw new NullReferenceException();
		IL_12ef:
		System.Int32Enum key;
		if (obj14 != null && _dataManager != null)
		{
			Dictionary<StageType, List<StageData>> convertedStages = _dataManager.GetConvertedStages();
			if (convertedStages != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rax_v108+48]");
				object obj15 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item((System.Int32Enum)0);
				if (obj15 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v110 (System.Object)+18]");
					bool flag8 = (nint)0 <= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v110 (System.Object)+10]");
					object obj16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v110 (System.Object)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rcx_v75+18]");
						bool flag9 = (nint)0 <= (nint)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rcx_v75+20]");
						object obj17 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rcx_v75+20]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdx_v54+E0]");
							object obj18 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdx_v54+E0]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rcx_v111+10]");
								if ((nint)0 > (nint)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v110 (System.Object)+10]");
									object obj19 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2353 @ rax_v160+18]");
									bool flag10 = (nint)0 <= (nint)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2353 @ rax_v160+20]");
									object obj20 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2353 @ rax_v160+20]");
									if ((nint)0 == 0)
									{
										goto IL_105d;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rax_v161+E0]");
									PropType propType = Enum.Parse<PropType>((string)0);
									key = (System.Int32Enum)propType;
									goto IL_130c;
								}
							}
						}
						key = (System.Int32Enum)2;
						goto IL_130c;
					}
				}
			}
		}
		goto IL_105d;
		IL_130c:
		CustomPickupData customPickupData4 = new CustomPickupData();
		if (customPickupData4 != null)
		{
			customPickupData4.Amount = 0;
			DataManager dataManager4 = _dataManager;
			if (_dataManager != null && dataManager4._003CAllProps_003Ek__BackingField != null)
			{
				object obj21 = ((Dictionary<System.Int32Enum, object>)(object)dataManager4._003CAllProps_003Ek__BackingField).get_Item(key);
				if (obj21 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rax_v114 (System.Object)+18]");
					customPickupData4.FrameName = (string)0;
					DataManager dataManager5 = _dataManager;
					if (_dataManager != null && dataManager5._003CAllProps_003Ek__BackingField != null)
					{
						object obj22 = ((Dictionary<System.Int32Enum, object>)(object)dataManager5._003CAllProps_003Ek__BackingField).get_Item(key);
						if (obj22 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rax_v118 (System.Object)+10]");
							customPickupData4.TextureName = (string)0;
							if (list3 != null)
							{
								list3.Insert(0, customPickupData4);
								float num = 1f / (float)list3._size;
								if (!_isFirstShow)
								{
									num = 0f;
								}
								int num2 = 0;
								List<CustomPickupData>.Enumerator enumerator = default(List<CustomPickupData>.Enumerator);
								float num4 = default(float);
								string text = default(string);
								bool isWorldPos = default(bool);
								while (enumerator.MoveNext())
								{
									TweenToLayoutGroup tweenToLayoutGroup = null;
									if (((UnityEngine.Object)tweenToLayoutGroup).m_CachedPtr != (IntPtr)0)
									{
										object obj23 = (nint)((UnityEngine.Object)tweenToLayoutGroup).m_CachedPtr >> 32;
										object obj24 = obj23 - 6;
										bool flag11 = obj24 == null;
										object obj25 = (nint)((UnityEngine.Object)tweenToLayoutGroup).m_CachedPtr & (flag11 ? 1 : 0);
										if (obj25 != null)
										{
											continue;
										}
										if (((UnityEngine.Object)tweenToLayoutGroup).m_CachedPtr != (IntPtr)0)
										{
											bool flag12 = (object)_QuantityIconPrefab == null;
											GameObject original = _QuantityIconPrefab.gameObject;
											GameObject gameObject3 = UnityEngine.Object.Instantiate(original, _LootIcons);
											bool flag13 = (object)gameObject3 == null;
											IconQuantityUI component = gameObject3.GetComponent<IconQuantityUI>();
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1796 @ rbx_v45 (VampireSurvivors.UI.TweenToLayoutGroup)+28]");
											bool flag14 = (nint)0 == 0;
											string textureName3 = "items";
											if (!flag14)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1796 @ rbx_v45 (VampireSurvivors.UI.TweenToLayoutGroup)+28]");
												textureName3 = (string)0;
											}
											nint num3 = (nint)typeof(SpriteManager);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3796 @ rcx_v94 (Il2CppClass<VampireSurvivors.Graphics.SpriteManager>)+E4]");
											bool flag15 = (nint)0 != 0;
											Sprite sprite = SpriteManager.GetSprite((string)tweenToLayoutGroup.originalPos, textureName3);
											bool flag16 = (object)component == null;
											bool flag17 = (object)component._Icon == null;
											component._Icon.sprite = sprite;
											component.SetQuantity((int)((MonoBehaviour)tweenToLayoutGroup).m_CancellationTokenSource);
											TweenToLayoutGroup tweenToLayoutGroup2 = gameObject3.AddComponent<TweenToLayoutGroup>();
											bool flag18 = (object)_TweenOrigin == null;
											Vector3 position = _TweenOrigin.position;
											bool flag19 = (object)tweenToLayoutGroup2 == null;
											float duration = (float)num2 * num;
											tweenToLayoutGroup2.TweenFromLocationToLayoutSpot(_rectTransform, (Vector3)(&num4), duration, (float)text, isWorldPos);
											num2++;
											continue;
										}
									}
									SpawnDestructible(num2, num, (string)tweenToLayoutGroup.originalPos, text);
									num2++;
								}
								return;
							}
						}
					}
				}
			}
		}
		goto IL_105d;
	}

	private unsafe void SpawnDestructible(int index, float duration, string frameName, string textureName)
	{
		//IL_0113: Expected O, but got Ref
		//IL_0168->IL0114: Incompatible stack heights: 1 vs 0
		GameObject gameObject = UnityEngine.Object.Instantiate(_DestructablePrefab, _LootIcons);
		if ((object)gameObject != null)
		{
			Image component = gameObject.GetComponent<Image>();
			string spriteName = frameName + "1";
			string textureName2 = default(string);
			Sprite sprite = SpriteManager.GetSprite(spriteName, textureName2);
			if ((object)component != null)
			{
				component.sprite = sprite;
				TweenToLayoutGroup tweenToLayoutGroup = gameObject.AddComponent<TweenToLayoutGroup>();
				RecapPage tweenOrigin = (RecapPage)(object)_TweenOrigin;
				if ((object)_TweenOrigin != null)
				{
					bool flag = ((UnityEngine.Object)tweenOrigin).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)tweenOrigin).m_CachedPtr, out Vector3 _);
					if ((object)tweenToLayoutGroup != null)
					{
						float duration2 = (float)index * duration;
						object obj = default(object);
						float delay = default(float);
						bool isWorldPos = default(bool);
						tweenToLayoutGroup.TweenFromLocationToLayoutSpot(_rectTransform, (Vector3)(&obj), duration2, delay, isWorldPos);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void AddArcanas()
	{
		//IL_035b: Expected O, but got I
		//IL_00de: Expected O, but got I
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_022e: Expected O, but got I
		//IL_028b: Expected O, but got Ref
		ArcanaManager arcanaManager = _arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rbx_v18 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 > (nint)0)
		{
			GameObject gameObject = _ArcanaContainer.gameObject;
			gameObject.SetActive(value: true);
			object obj = default(object);
			object obj2 = default(object);
			object obj4 = default(object);
			float num = default(float);
			float delay = default(float);
			bool isWorldPos = default(bool);
			while (true)
			{
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ stack_-60_v18+1C]");
					if (obj2 == null)
					{
						object obj3 = obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ stack_-60_v18+18]");
						if ((nint)obj3 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ stack_-60_v18+10]");
							object obj5 = 0;
							obj4++;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rdx_v27+20+v1290 @ rcx_v28*4]");
							Sprite sprite2;
							if ((nint)0 > (nint)21)
							{
								Sprite sprite = SpriteManager.GetSprite("frameH", "UI");
								sprite2 = sprite;
							}
							else
							{
								Sprite sprite3 = SpriteManager.GetSprite("frameG", "UI");
								sprite2 = sprite3;
							}
							GameObject gameObject2 = UnityEngine.Object.Instantiate(_ArcanaPrefab, _ArcanaContainer);
							DataManager dataManager = _dataManager;
							Dictionary<ArcanaType, ArcanaData> dictionary = dataManager._003CAllArcanas_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rdx_v27+20+v1290 @ rcx_v28*4]");
							object obj6 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)0);
							Image component = gameObject2.GetComponent<Image>();
							component.sprite = sprite2;
							Transform transform = gameObject2.transform;
							Transform child = transform.GetChild(0);
							Image component2 = child.GetComponent<Image>();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1035 @ rax_v57 (System.Object)+40]");
							Sprite sprite4 = SpriteManager.GetSprite((string)0, "items");
							component2.sprite = sprite4;
							TweenToLayoutGroup tweenToLayoutGroup = gameObject2.AddComponent<TweenToLayoutGroup>();
							Vector3 position = _TweenOrigin.position;
							tweenToLayoutGroup.TweenFromLocationToLayoutSpot(_rectTransform, (Vector3)(&num), 0.25f, delay, isWorldPos);
							continue;
						}
						break;
					}
					break;
				}
				throw new NullReferenceException();
			}
			bool flag = obj == null;
			GameObject gameObject3 = (GameObject)0;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ stack_-60_v18+1C]");
				if (obj2 == null)
				{
					return;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				gameObject3 = null;
			}
			throw new NullReferenceException();
		}
		GameObject gameObject4 = _ArcanaContainer.gameObject;
		gameObject4.SetActive(value: false);
	}

	private unsafe void GenerateWeaponRecap(StatsDisplay statsDisplay)
	{
		//IL_0048: Expected O, but got Ref
		GameObject gameObject = UnityEngine.Object.Instantiate(_WeaponRecapPrefab, _WeaponRecapContainer);
		Transform transform = gameObject.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		WeaponRecapUI component = gameObject.GetComponent<WeaponRecapUI>();
		object obj = default(object);
		component.SetData((StatsDisplay)(&obj));
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
	}

	private void QueueAchievements(List<AchievementData> achievementsUnlocked)
	{
		_HideAchievementsButton.SetActive(value: false);
		if (achievementsUnlocked != null)
		{
			int num = achievementsUnlocked._size ^ achievementsUnlocked._size;
			int num2 = achievementsUnlocked._size & num;
			bool flag = num2 < 0;
			bool flag2 = achievementsUnlocked._size < 0;
			bool flag3 = achievementsUnlocked._size == 0;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			bool active = flag5 & flag4;
			if (achievementsUnlocked._size <= 0)
			{
				GameObject gameObject = _AchievementPopup.gameObject;
				gameObject.SetActive(value: false);
			}
			else
			{
				bool applyParameters = default(bool);
				GameObject localParametersRoot = default(GameObject);
				string overrideLanguage = default(string);
				bool allowLocalizedParameters = default(bool);
				string translation = LocalizationManager.GetTranslation("lang/postGame_hideAchievements", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
				string text = translation.Replace("\\n", "<br>");
				TextMeshProUGUI componentInChildren = _HideAchievementsButton.GetComponentInChildren<TextMeshProUGUI>(includeInactive: false);
				componentInChildren.text = text;
				_HideAchievementsButton.SetActive(value: true);
				GameObject gameObject2 = _AchievementPopup.gameObject;
				gameObject2.SetActive(value: true);
				_AchievementPopup.SetAchievements(achievementsUnlocked);
				int num3 = default(int);
				string text2 = num3.ToString();
				_UnlockCountText.text = text2;
			}
			_UnlockBadge.SetActive(active);
		}
	}

	private bool CanShowPostRunGoldAdRewardButton()
	{
		//IL_001e: Expected I4, but got O
		if ((object)GM.Core != null)
		{
			return false;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe void RewardExtraGoldFromAd()
	{
		//IL_0129: Invalid comparison between I4 and F4
		//IL_01dc: Expected F4, but got I4
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected O, but got Unknown
		//IL_02dc: Expected O, but got Ref
		_003C_003Ec__DisplayClass82_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass82_0();
		CS_0024_003C_003E8__locals4._003C_003E4__this = this;
		PlayerOptionsData config = _playerOptions.Config;
		PlayerOptionsData config2 = _playerOptions.Config;
		float num = config._003CRunCoins_003Ek__BackingField * 0.5f;
		CS_0024_003C_003E8__locals4.start = config2._003CRunCoins_003Ek__BackingField;
		bool flag = 500f > num;
		float num2 = 500f;
		float num3;
		if (!flag)
		{
			bool flag2 = !(num > 5000f);
			num2 = 5000f;
			num3 = 5000f;
			if (flag2)
			{
				goto IL_00d0;
			}
		}
		num3 = num2;
		num = num2;
		goto IL_00d0;
		IL_01e1:
		PlayerOptionsData config3;
		float num4;
		config3._003CRunCoins_003Ek__BackingField = num4;
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((_003C_003Ec__DisplayClass82_0)(object)dOSetter)._003CRewardExtraGoldFromAd_003Eb__1(num);
		PlayerOptionsData config4 = _playerOptions.Config;
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, config4._003CRunCoins_003Ek__BackingField, 2f);
		TweenCallback tweenCallback = delegate
		{
			RecapPage recapPage = CS_0024_003C_003E8__locals4._003C_003E4__this;
			PropertyUI gold2 = recapPage._Gold;
			double value = Math.Ceiling(CS_0024_003C_003E8__locals4.start);
			NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
			string text = System.Number.FormatDouble(value, "F0", currentInfo);
			gold2.Value.text = text;
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ rax_v19 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		PropertyUI gold = _Gold;
		object obj = default(object);
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOColor(gold.Value, (Color)(&obj), 2f);
		RenderingExtensions.Start(_particles);
		TweenCallback onComplete = delegate
		{
			_particles.Stop();
		};
		Tween tween = UITimerHelper.RegisterMillis(1000f, onComplete);
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LevelUp, null, 0f, 10, time);
		return;
		IL_00d0:
		_playerOptions.AddCoinsFlat(num);
		config3 = _playerOptions.Config;
		PlayerOptionsData config5 = _playerOptions.Config;
		num4 = num + config5._003CRunCoins_003Ek__BackingField;
		if (!(0f > num4))
		{
			object obj2 = num4 & -2147483649L;
			if ((nint)obj2 != 2139095040)
			{
				object obj3 = num4 & -2147483649L;
				if ((nint)obj3 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186D6F54Ch\"");
					if (num4 != -1f / 0f)
					{
						goto IL_01e1;
					}
				}
			}
			num4 = 3.4028235E+38f;
		}
		else
		{
			num4 = 0f;
		}
		goto IL_01e1;
	}

	private void PlayParticles()
	{
		RenderingExtensions.Start(_particles);
		TweenCallback onComplete = delegate
		{
			_particles.Stop();
		};
		Tween tween = UITimerHelper.RegisterMillis(1000f, onComplete);
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LevelUp, null, 0f, 10, time);
	}

	public void OpenLogs()
	{
		string[] paths = new string[5];
		string text = Environment.internalGetEnvironmentVariable("AppData");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string companyName = Application.companyName;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string productName = Application.productName;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string text2 = Path.Combine(paths);
		string url = "file:///" + text2;
		Application.OpenURL(url);
		string targetPath = StandaloneStorage.GetTargetPath("Vampire_Survivors_Standalone");
		string url2 = "file:///" + targetPath;
		Application.OpenURL(url2);
	}

	public RecapPage()
	{
		//IL_0053: Expected O, but got I
		List<Tween> activeTweens = new List<Tween>();
		_activeTweens = activeTweens;
		_spawned = new List<GameObject>();
		_characterWeapons = new Dictionary<CharacterType, GameObject>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A122B0]");
		hiddenWeaponNameColor = (Color)0;
		_isFirstShow = true;
		base._002Ector();
	}

	private void _003CReturnToLanding_003Eb__57_0()
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		Debug.Log("[RecapPage] ReturnToLanding before RecapPageCompletedSignal fire");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	private void _003CPlayParticles_003Eb__83_0()
	{
		_particles.Stop();
	}
}
