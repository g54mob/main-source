using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Cpp2ILInjected;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Data.Adventures;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class AchievementsPage : BaseUIPage
{
	private sealed class _003CWaitAndReformat_003Ed__32(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public AchievementsPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_013f: Expected O, but got I4
			//IL_0014: Expected I4, but got I8
			//IL_00fb: Expected O, but got I4
			AchievementsPage achievementsPage = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 46 Invalid \"Jump target not found in method: 0x18775C2F7\"");
			object obj = _003C_003E1__state - 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 49 Invalid \"Jump target not found in method: 0x18775C25F\"");
			if ((nint)obj == 1)
			{
				_003C_003E1__state = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 73 Invalid \"Jump target not found in method: 0x18775C3A2\"");
				List<GameObject> spawned = achievementsPage._spawned;
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 85 Invalid \"Jump target not found in method: 0x18775C3A2\"");
				if (spawned._size <= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 111 Invalid \"Jump target not found in method: 0x18775C3A2\"");
					Selectable component = achievementsPage._HideCompleted.GetComponent<Selectable>();
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 124 Invalid \"Jump target not found in method: 0x18775C3A2\"");
					component.Select();
				}
				else
				{
					List<GameObject> spawned2 = achievementsPage._spawned;
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 152 Invalid \"Jump target not found in method: 0x18775C3A2\"");
					if (0 < spawned2._size)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 176 Invalid \"Jump target not found in method: 0x18775C39A\"");
						GameObject[] items = spawned2._items;
						Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 188 Invalid \"Jump target not found in method: 0x18775C3A2\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 200 Invalid \"Jump target not found in method: 0x18775C394\"");
						object obj2 = 0;
						GameObject gameObject = items[obj2];
						Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 213 Invalid \"Jump target not found in method: 0x18775C3A2\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 241 Invalid \"Jump target not found in method: 0x18775C389\"");
						return GameObject.get_activeInHierarchy_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					}
				}
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

	private GameObject _AchievementPrefab;

	private TextMeshProUGUI _Description;

	private TextMeshProUGUI _UnlockDescription;

	private TextMeshProUGUI _Title;

	private TextMeshProUGUI _ObtainedText;

	private Image _InfoBackground;

	private Localize _DescriptionText;

	private Image _Icon;

	private Image _IconBg;

	private Image _MoneyIcon;

	private TickBoxUI _HideCompleted;

	private GameObject _InfoPanel;

	private PlayerOptions _playerOptions;

	private DataManager _dataManager;

	private AchievementManager _achievementManager;

	private AdventureManager _adventureManager;

	private List<GameObject> _spawned;

	private List<AchievementType> _baseGameUnlocked;

	private void Construct(AchievementManager achievements, PlayerOptions playerOptions, DataManager dataManager, AdventureManager adventureManager)
	{
		_playerOptions = playerOptions;
		_dataManager = dataManager;
		_achievementManager = achievements;
		AdventureManager adventureManager2 = default(AdventureManager);
		_adventureManager = adventureManager2;
	}

	protected override void Awake()
	{
		base.Awake();
		base._maxInputActionsPerSecond = 100f;
		base._scrollAccelerationSpeed = 5f;
	}

	public void SelectAdventureProgress(AdventureAchievementType type, AchievementData achievementData)
	{
		string localizedDescription = achievementData.GetLocalizedDescription(type);
		_DescriptionText.Term = localizedDescription;
		UpdateInfoDisplay(achievementData);
	}

	public void SelectAchievement(AchievementType type, AchievementData bad)
	{
		string localizedDescription = bad.GetLocalizedDescription(type);
		_DescriptionText.Term = localizedDescription;
		UpdateInfoDisplay(bad);
	}

	public unsafe void Reset()
	{
		//IL_0012: Expected O, but got Ref
		//IL_0094: Expected I4, but got O
		//IL_0094: Expected O, but got I
		bool flag = _spawned == null;
		AchievementsPage achievementsPage = this;
		if (!flag)
		{
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			if (enumerator.MoveNext())
			{
				List<GameObject>.Enumerator enumerator2 = (List<GameObject>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			achievementsPage = (AchievementsPage)(object)_spawned;
			if (_spawned != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v3 (VampireSurvivors.UI.AchievementsPage)+1C]");
				_ = (nint)0 + (nint)1;
				((MonoBehaviour)achievementsPage).m_CancellationTokenSource = null;
				if ((nint)((MonoBehaviour)achievementsPage).m_CancellationTokenSource > 0)
				{
					Array.Clear((Array)(nint)((UnityEngine.Object)achievementsPage).m_CachedPtr, 0, (int)((MonoBehaviour)achievementsPage).m_CancellationTokenSource);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void ToggleCompleted()
	{
		PlayerOptionsData config = _playerOptions.Config;
		PlayerOptionsData config2 = _playerOptions.Config;
		bool flag = !config2._003CHideCompletedAchievements_003Ek__BackingField;
		config._003CHideCompletedAchievements_003Ek__BackingField = flag;
		Reset();
		Populate();
	}

	protected override void OnShowStart(GameObject g)
	{
		base.OnShowStart(g);
		PlayerOptionsData config = _playerOptions.Config;
		_baseGameUnlocked = config._003CAchievements_003Ek__BackingField;
		Populate();
		PlayerOptionsData config2 = _playerOptions.Config;
		_HideCompleted.InitialSet(config2._003CHideCompletedAchievements_003Ek__BackingField);
	}

	protected override void OnHideStart(GameObject g)
	{
		ResetBackButtonNavigation();
	}

	private unsafe void Populate()
	{
		//IL_00b5: Expected O, but got I4
		//IL_00fe: Expected O, but got I4
		//IL_01c7: Expected O, but got I4
		//IL_0210: Expected O, but got I4
		//IL_023d: Expected O, but got Ref
		//IL_025f: Expected O, but got I4
		//IL_034e: Expected O, but got I4
		//IL_02ca: Expected O, but got I4
		//IL_038b: Expected O, but got I4
		//IL_03d4: Expected O, but got I4
		//IL_042c: Expected O, but got I4
		//IL_0475: Expected O, but got I4
		//IL_04d8: Expected O, but got I4
		//IL_0521: Expected O, but got I4
		Reset();
		if (!AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			PopulateBaseGameAchievements();
		}
		else
		{
			PopulateAdventureProgress();
		}
		_003CWaitAndReformat_003Ed__32 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
		Selectable component6;
		Selectable origin;
		if (_spawned != null)
		{
			List<GameObject> spawned = _spawned;
			if (spawned._size > 0)
			{
				object obj2 = spawned._size - 1;
				if ((nint)obj2 < spawned._size)
				{
					GameObject[] items = spawned._items;
					object obj3 = spawned._size - 1;
					Selectable component = items[obj3].GetComponent<Selectable>();
					List<GameObject> spawned2 = _spawned;
					if (spawned2._size > 0)
					{
						GameObject[] items2 = spawned2._items;
						Selectable component2 = items2[0].GetComponent<Selectable>();
						Selectable component3 = _HideCompleted.GetComponent<Selectable>();
						Selectable right = default(Selectable);
						ForceBackButtonNavigation(component, component2, component3, right);
						List<GameObject> spawned3 = _spawned;
						object obj4 = spawned3._size - 1;
						if ((nint)obj4 < spawned3._size)
						{
							GameObject[] items3 = spawned3._items;
							object obj5 = spawned3._size - 1;
							Selectable component4 = items3[obj5].GetComponent<Selectable>();
							object obj6 = default(object);
							component4.navigation = (Navigation)(&obj6);
							List<GameObject> spawned4 = _spawned;
							object obj7 = spawned4._size - 1;
							if (spawned4._size <= 1)
							{
								if ((nint)obj7 < spawned4._size)
								{
									GameObject[] items4 = spawned4._items;
									object obj8 = spawned4._size - 1;
									Selectable component5 = items4[obj8].GetComponent<Selectable>();
									component6 = BackButtonController.Instance.GetComponent<Selectable>();
									origin = component5;
									goto IL_03fc;
								}
							}
							else if ((nint)obj7 < spawned4._size)
							{
								GameObject[] items5 = spawned4._items;
								object obj9 = spawned4._size - 1;
								Selectable component7 = items5[obj9].GetComponent<Selectable>();
								List<GameObject> spawned5 = _spawned;
								object obj10 = spawned5._size - 2;
								if ((nint)obj10 < spawned5._size)
								{
									GameObject[] items6 = spawned5._items;
									object obj11 = spawned5._size - 2;
									component6 = items6[obj11].GetComponent<Selectable>();
									origin = component7;
									goto IL_03fc;
								}
							}
						}
					}
				}
				goto IL_0662;
			}
		}
		goto IL_0563;
		IL_03fc:
		SetNavigationUp(origin, component6);
		List<GameObject> spawned6 = _spawned;
		object obj12 = spawned6._size - 1;
		if ((nint)obj12 < spawned6._size)
		{
			GameObject[] items7 = spawned6._items;
			object obj13 = spawned6._size - 1;
			Selectable component8 = items7[obj13].GetComponent<Selectable>();
			Selectable component9 = BackButtonController.Instance.GetComponent<Selectable>();
			SetNavigationDown(component8, component9);
			List<GameObject> spawned7 = _spawned;
			object obj14 = spawned7._size - 1;
			if ((nint)obj14 < spawned7._size)
			{
				GameObject[] items8 = spawned7._items;
				object obj15 = spawned7._size - 1;
				Selectable component10 = items8[obj15].GetComponent<Selectable>();
				Selectable component11 = _HideCompleted.GetComponent<Selectable>();
				SetNavigationLeft(component10, component11);
				goto IL_0563;
			}
		}
		goto IL_0662;
		IL_0662:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_0563:
		List<GameObject> spawned8 = _spawned;
		bool flag = _spawned == null;
		int active = 0;
		if (!flag)
		{
			int num = spawned8._size ^ spawned8._size;
			int num2 = spawned8._size & num;
			bool flag2 = num2 < 0;
			bool flag3 = spawned8._size < 0;
			bool flag4 = spawned8._size == 0;
			bool flag5 = flag3 == flag2;
			bool flag6 = !flag4;
			active = ((flag6 & flag5) ? 1 : 0);
		}
		_InfoPanel.SetActive((byte)active != 0);
	}

	private unsafe void UpdateInfoDisplay(AchievementData bad)
	{
		//IL_0147: Expected O, but got I
		//IL_02ea: Expected O, but got I
		//IL_048d: Expected O, but got I
		//IL_0630: Expected O, but got I
		//IL_07d3: Expected O, but got I
		//IL_01a1: Expected O, but got I4
		//IL_0976: Expected O, but got I
		//IL_0344: Expected O, but got I4
		//IL_0e31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e36: Expected I4, but got Unknown
		//IL_0b19: Expected O, but got I
		//IL_04e7: Expected O, but got I4
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected I4, but got Unknown
		//IL_0f08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f0d: Expected I4, but got Unknown
		//IL_0cbc: Expected O, but got I
		//IL_068a: Expected O, but got I4
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Expected I4, but got Unknown
		//IL_0fdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe4: Expected I4, but got Unknown
		//IL_082d: Expected O, but got I4
		//IL_052b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0530: Expected I4, but got Unknown
		//IL_09d0: Expected O, but got I4
		//IL_06ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d3: Expected I4, but got Unknown
		//IL_0b73: Expected O, but got I4
		//IL_0871: Unknown result type (might be due to invalid IL or missing references)
		//IL_0876: Expected I4, but got Unknown
		//IL_1bd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bd7: Expected O, but got Unknown
		//IL_19e1: Expected O, but got I4
		//IL_19e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ee: Expected O, but got Unknown
		//IL_1a03: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a08: Expected O, but got Unknown
		//IL_1910: Unknown result type (might be due to invalid IL or missing references)
		//IL_1915: Expected I4, but got Unknown
		//IL_0d16: Expected O, but got I4
		//IL_0a14: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a19: Expected I4, but got Unknown
		//IL_0bb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bbc: Expected I4, but got Unknown
		//IL_0d5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d5f: Expected I4, but got Unknown
		//IL_1a65: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a6a: Expected I4, but got Unknown
		//IL_1163: Expected O, but got I4
		//IL_1670: Expected O, but got I4
		//IL_17d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_17dc: Expected O, but got Unknown
		//IL_1276: Unknown result type (might be due to invalid IL or missing references)
		//IL_127b: Expected O, but got Unknown
		//IL_1784: Unknown result type (might be due to invalid IL or missing references)
		//IL_1789: Expected O, but got Unknown
		//IL_1839: Unknown result type (might be due to invalid IL or missing references)
		//IL_183e: Expected I4, but got Unknown
		//IL_1393: Unknown result type (might be due to invalid IL or missing references)
		//IL_1398: Expected O, but got Unknown
		//IL_14f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_14fc: Expected I4, but got Unknown
		//IL_14b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_14b5: Expected O, but got Unknown
		//IL_2483: Unknown result type (might be due to invalid IL or missing references)
		//IL_2488: Expected O, but got Unknown
		//IL_24f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_24f8: Expected O, but got Unknown
		//IL_24c1->IL206f: Incompatible stack heights: 1 vs 0
		//IL_2052->IL206f: Incompatible stack heights: 1 vs 0
		//IL_2522->IL206f: Incompatible stack heights: 2 vs 0
		object obj3 = default(object);
		if (_achievementManager != null)
		{
			string unlockText = _achievementManager.GetUnlockText(bad);
			if ((object)_UnlockDescription != null)
			{
				_UnlockDescription.text = unlockText;
				if (bad != null)
				{
					if (bad._003CType_003Ek__BackingField != AchievementType.FB_17_Find__Barrier)
					{
						goto IL_209b;
					}
					if (_playerOptions != null)
					{
						PlayerOptionsData config = _playerOptions.Config;
						if (config != null)
						{
							Dictionary<ItemType, int> dictionary = config._003CPickupCount_003Ek__BackingField;
							if (config._003CPickupCount_003Ek__BackingField != null)
							{
								int num = config._003CPickupCount_003Ek__BackingField.FindEntry(ItemType.FB_BARRIER);
								if (num < 0)
								{
									goto IL_209b;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rbx_v75 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.ItemType, System.Int32>)+18]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rbx_v75 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.ItemType, System.Int32>)+18]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v479 @ rcx_v216+18]");
									if ((nint)num >= (nint)0)
									{
										goto IL_20c0;
									}
									object obj2 = num + num;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v479 @ rcx_v216+2C+v2457 @ rax_v271*8]");
									_ = 0;
									if ((object)_Description != null)
									{
										string text = _Description.text;
										int num2 = obj3 + 40;
										string text2 = ((int*)num2)->ToString();
										string text3 = text + " (" + text2 + "/14)";
										_Description.text = text3;
										goto IL_209b;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_206f;
		IL_2239:
		TextMeshProUGUI textMeshProUGUI;
		if (_playerOptions != null)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			if (config2 != null && config2._003CKillCount_003Ek__BackingField != null)
			{
				int num3 = config2._003CKillCount_003Ek__BackingField.FindEntry(EnemyType.XLDRAGON2);
				if (num3 < 0)
				{
					goto IL_2258;
				}
				if (_playerOptions != null)
				{
					PlayerOptionsData config3 = _playerOptions.Config;
					if (config3 != null && config3._003CKillCount_003Ek__BackingField != null)
					{
						int num4 = config3._003CKillCount_003Ek__BackingField.get_Item(EnemyType.XLDRAGON2);
						textMeshProUGUI = (TextMeshProUGUI)(textMeshProUGUI + num4);
						goto IL_2258;
					}
				}
			}
		}
		goto IL_206f;
		IL_2527:
		TextMeshProUGUI textMeshProUGUI2;
		if (bad._003CType_003Ek__BackingField == AchievementType.Defeat6000StageKillers)
		{
			if (_playerOptions != null)
			{
				PlayerOptionsData config4 = _playerOptions.Config;
				if (config4 != null && config4._003CKillCount_003Ek__BackingField != null)
				{
					int num5 = config4._003CKillCount_003Ek__BackingField.FindEntry(EnemyType.STAGEKILLER);
					bool flag = num5 < 0;
					textMeshProUGUI2 = null;
					if (flag)
					{
						goto IL_22db;
					}
					if (_playerOptions != null)
					{
						PlayerOptionsData config5 = _playerOptions.Config;
						if (config5 != null && config5._003CKillCount_003Ek__BackingField != null)
						{
							int num6 = config5._003CKillCount_003Ek__BackingField.get_Item(EnemyType.STAGEKILLER);
							textMeshProUGUI2 = (TextMeshProUGUI)num6;
							goto IL_22db;
						}
					}
				}
			}
			goto IL_206f;
		}
		goto IL_22b6;
		IL_22db:
		if (_playerOptions != null)
		{
			PlayerOptionsData config6 = _playerOptions.Config;
			if (config6 != null && config6._003CKillCount_003Ek__BackingField != null)
			{
				int num7 = config6._003CKillCount_003Ek__BackingField.FindEntry(EnemyType.STAGEKILLER2);
				if (num7 < 0)
				{
					goto IL_22fa;
				}
				if (_playerOptions != null)
				{
					PlayerOptionsData config7 = _playerOptions.Config;
					if (config7 != null && config7._003CKillCount_003Ek__BackingField != null)
					{
						int num8 = config7._003CKillCount_003Ek__BackingField.get_Item(EnemyType.STAGEKILLER2);
						textMeshProUGUI2 = (TextMeshProUGUI)(textMeshProUGUI2 + num8);
						goto IL_22fa;
					}
				}
			}
		}
		goto IL_206f;
		IL_22fa:
		if (_playerOptions != null)
		{
			PlayerOptionsData config8 = _playerOptions.Config;
			if (config8 != null)
			{
				int num9 = ((Dictionary<ItemType, int>)(object)_playerOptions).FindEntry(ItemType.VOID);
				TextMeshProUGUI textMeshProUGUI3 = (TextMeshProUGUI)(textMeshProUGUI2 + num9);
				if ((nint)textMeshProUGUI3 > 0)
				{
					if ((object)_Description == null)
					{
						goto IL_206f;
					}
					string text4 = _Description.text;
					int num10 = obj3 + 40;
					string text5 = ((int*)num10)->ToString();
					string text6 = text4 + " (" + text5 + "/6000)";
					_Description.text = text6;
				}
				goto IL_22b6;
			}
		}
		goto IL_206f;
		IL_2277:
		if (_playerOptions != null)
		{
			PlayerOptionsData config9 = _playerOptions.Config;
			if (config9 != null && config9._003CKillCount_003Ek__BackingField != null)
			{
				int num11 = config9._003CKillCount_003Ek__BackingField.FindEntry(EnemyType.XLDRAGON2_FLAG);
				if (num11 < 0)
				{
					goto IL_2296;
				}
				if (_playerOptions != null)
				{
					PlayerOptionsData config10 = _playerOptions.Config;
					if (config10 != null && config10._003CKillCount_003Ek__BackingField != null)
					{
						int num12 = config10._003CKillCount_003Ek__BackingField.get_Item(EnemyType.XLDRAGON2_FLAG);
						textMeshProUGUI = (TextMeshProUGUI)(textMeshProUGUI + num12);
						goto IL_2296;
					}
				}
			}
		}
		goto IL_206f;
		IL_2136:
		if (bad._003CType_003Ek__BackingField == AchievementType.FindManyChickens)
		{
			if (_playerOptions != null)
			{
				PlayerOptionsData config11 = _playerOptions.Config;
				if (config11 != null)
				{
					Dictionary<ItemType, int> dictionary2 = config11._003CPickupCount_003Ek__BackingField;
					if (config11._003CPickupCount_003Ek__BackingField != null)
					{
						int num13 = config11._003CPickupCount_003Ek__BackingField.FindEntry(ItemType.ROAST);
						if (num13 < 0)
						{
							goto IL_215b;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rbx_v65 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.ItemType, System.Int32>)+18]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rbx_v65 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.ItemType, System.Int32>)+18]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ rcx_v176+18]");
							if ((nint)num13 >= (nint)0)
							{
								goto IL_20c0;
							}
							object obj5 = num13 + num13;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ rcx_v176+2C+v2872 @ rax_v216*8]");
							_ = 0;
							if ((object)_Description != null)
							{
								string text7 = _Description.text;
								int num14 = obj3 + 40;
								string text8 = ((int*)num14)->ToString();
								string text9 = text7 + " (" + text8 + "/500)";
								_Description.text = text9;
								goto IL_215b;
							}
						}
					}
				}
			}
			goto IL_206f;
		}
		goto IL_215b;
		IL_2180:
		if (bad._003CType_003Ek__BackingField == AchievementType.FindManyRosaries)
		{
			if (_playerOptions != null)
			{
				PlayerOptionsData config12 = _playerOptions.Config;
				if (config12 != null)
				{
					Dictionary<ItemType, int> dictionary3 = config12._003CPickupCount_003Ek__BackingField;
					if (config12._003CPickupCount_003Ek__BackingField != null)
					{
						int num15 = config12._003CPickupCount_003Ek__BackingField.FindEntry(ItemType.ROSARY);
						if (num15 < 0)
						{
							goto IL_21a5;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rbx_v61 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.ItemType, System.Int32>)+18]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rbx_v61 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.ItemType, System.Int32>)+18]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ rcx_v160+18]");
							if ((nint)num15 >= (nint)0)
							{
								goto IL_20c0;
							}
							object obj7 = num15 + num15;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ rcx_v160+2C+v3010 @ rax_v194*8]");
							_ = 0;
							if ((object)_Description != null)
							{
								string text10 = _Description.text;
								int num16 = obj3 + 40;
								string text11 = ((int*)num16)->ToString();
								string text12 = text10 + " (" + text11 + "/33)";
								_Description.text = text12;
								goto IL_21a5;
							}
						}
					}
				}
			}
			goto IL_206f;
		}
		goto IL_21a5;
		IL_20ec:
		if (bad._003CType_003Ek__BackingField == AchievementType.FindManyOrologions)
		{
			if (_playerOptions != null)
			{
				PlayerOptionsData config13 = _playerOptions.Config;
				if (config13 != null)
				{
					Dictionary<ItemType, int> dictionary4 = config13._003CPickupCount_003Ek__BackingField;
					if (config13._003CPickupCount_003Ek__BackingField != null)
					{
						int num17 = config13._003CPickupCount_003Ek__BackingField.FindEntry(ItemType.OROLOGION);
						if (num17 < 0)
						{
							goto IL_2111;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rbx_v69 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.ItemType, System.Int32>)+18]");
						object obj8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rbx_v69 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.ItemType, System.Int32>)+18]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ rcx_v192+18]");
							if ((nint)num17 >= (nint)0)
							{
								goto IL_20c0;
							}
							object obj9 = num17 + num17;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ rcx_v192+2C+v2742 @ rax_v238*8]");
							_ = 0;
							if ((object)_Description != null)
							{
								string text13 = _Description.text;
								int num18 = obj3 + 40;
								string text14 = ((int*)num18)->ToString();
								string text15 = text13 + " (" + text14 + "/20)";
								_Description.text = text15;
								goto IL_2111;
							}
						}
					}
				}
			}
			goto IL_206f;
		}
		goto IL_2111;
		IL_23d4:
		Behaviour iconBg;
		bool flag2;
		iconBg.enabled = flag2;
		Vector2 sizeDelta = default(Vector2);
		if ((object)_MoneyIcon != null)
		{
			GameObject gameObject = _MoneyIcon.gameObject;
			if ((object)gameObject != null)
			{
				int num19 = bad._003CgoldPrize_003Ek__BackingField ^ bad._003CgoldPrize_003Ek__BackingField;
				int num20 = bad._003CgoldPrize_003Ek__BackingField & num19;
				bool flag3 = num20 < 0;
				bool flag4 = bad._003CgoldPrize_003Ek__BackingField < 0;
				bool flag5 = bad._003CgoldPrize_003Ek__BackingField == 0;
				bool flag6 = flag4 == flag3;
				bool flag7 = !flag5;
				bool active = flag7 & flag6;
				gameObject.SetActive(active);
				TextMeshProUGUI iconBg2 = (TextMeshProUGUI)(object)_IconBg;
				if ((object)_IconBg != null)
				{
					TextMeshProUGUI text16 = (TextMeshProUGUI)(object)((TMP_Text)iconBg2).m_text;
					if (((TMP_Text)iconBg2).m_text == null || ((UnityEngine.Object)text16).m_CachedPtr == (IntPtr)0)
					{
						goto IL_1f98;
					}
					if ((object)_IconBg != null)
					{
						RectTransform rectTransform = _IconBg.rectTransform;
						Image iconBg3 = _IconBg;
						if ((object)_IconBg != null && (object)iconBg3.m_Sprite != null)
						{
							Rect rect = iconBg3.m_Sprite.rect;
							Image iconBg4 = _IconBg;
							if ((object)_IconBg != null && (object)iconBg4.m_Sprite != null)
							{
								Rect rect2 = iconBg4.m_Sprite.rect;
								if ((object)rectTransform != null)
								{
									rectTransform.sizeDelta = sizeDelta;
									goto IL_1f98;
								}
							}
						}
					}
				}
			}
		}
		goto IL_206f;
		IL_1f98:
		if ((object)_Icon != null)
		{
			RectTransform rectTransform2 = _Icon.rectTransform;
			TextMeshProUGUI icon = (TextMeshProUGUI)(object)_Icon;
			if ((object)_Icon != null)
			{
				object text17 = ((TMP_Text)icon).m_text;
				if (((TMP_Text)icon).m_text != null)
				{
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rbx_v32 (System.Object)+10]");
					bool flag8 = (nint)0 == 0;
					object obj10 = obj3 - 72;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rbx_v32 (System.Object)+10]");
					Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)obj10);
					TextMeshProUGUI icon2 = (TextMeshProUGUI)(object)_Icon;
					if ((object)_Icon != null)
					{
						TextMeshProUGUI text18 = (TextMeshProUGUI)(object)((TMP_Text)icon2).m_text;
						if (((TMP_Text)icon2).m_text != null)
						{
							_ = 0;
							bool flag9 = ((UnityEngine.Object)text18).m_CachedPtr == (IntPtr)0;
							object obj11 = obj3 - 56;
							Sprite.get_rect_Injected(((UnityEngine.Object)text18).m_CachedPtr, out *(Rect*)obj11);
							if ((object)rectTransform2 != null)
							{
								rectTransform2.sizeDelta = sizeDelta;
								return;
							}
						}
					}
				}
			}
		}
		goto IL_206f;
		IL_206f:
		throw new NullReferenceException();
		IL_209b:
		if (bad._003CType_003Ek__BackingField == AchievementType.FB_20_Find__Rapid)
		{
			if (_playerOptions != null)
			{
				PlayerOptionsData config14 = _playerOptions.Config;
				if (config14 != null)
				{
					Dictionary<ItemType, int> dictionary5 = config14._003CPickupCount_003Ek__BackingField;
					if (config14._003CPickupCount_003Ek__BackingField != null)
					{
						int num21 = config14._003CPickupCount_003Ek__BackingField.FindEntry(ItemType.FB_RAPIDFIRE);
						if (num21 < 0)
						{
							goto IL_20c7;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rbx_v73 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.ItemType, System.Int32>)+18]");
						object obj12 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rbx_v73 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.ItemType, System.Int32>)+18]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ rcx_v208+18]");
							if ((nint)num21 >= (nint)0)
							{
								goto IL_20c0;
							}
							object obj13 = num21 + num21;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ rcx_v208+2C+v2564 @ rax_v260*8]");
							_ = 0;
							if ((object)_Description != null)
							{
								string text19 = _Description.text;
								int num22 = obj3 + 40;
								string text20 = ((int*)num22)->ToString();
								string text21 = text19 + " (" + text20 + "/21)";
								_Description.text = text21;
								goto IL_20c7;
							}
						}
					}
				}
			}
			goto IL_206f;
		}
		goto IL_20c7;
		IL_233e:
		if (bad._003CType_003Ek__BackingField == AchievementType.HitManyEnemiesWithTrain)
		{
			if (_playerOptions != null)
			{
				PlayerOptionsData config15 = _playerOptions.Config;
				if (config15 != null)
				{
					double value = Math.Floor(config15._003CTrainHazardEnemiesHit_003Ek__BackingField);
					if ((object)_Description != null)
					{
						string text22 = _Description.text;
						NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
						string text23 = System.Number.FormatDouble(value, null, currentInfo);
						string text24 = text22 + " (" + text23 + "/25120)";
						_Description.text = text24;
						goto IL_254c;
					}
				}
			}
			goto IL_206f;
		}
		goto IL_254c;
		IL_2258:
		if (_playerOptions != null)
		{
			PlayerOptionsData config16 = _playerOptions.Config;
			if (config16 != null && config16._003CKillCount_003Ek__BackingField != null)
			{
				int num23 = config16._003CKillCount_003Ek__BackingField.FindEntry(EnemyType.XLDRAGON1_FLAG);
				if (num23 < 0)
				{
					goto IL_2277;
				}
				if (_playerOptions != null)
				{
					PlayerOptionsData config17 = _playerOptions.Config;
					if (config17 != null && config17._003CKillCount_003Ek__BackingField != null)
					{
						int num24 = config17._003CKillCount_003Ek__BackingField.get_Item(EnemyType.XLDRAGON1_FLAG);
						textMeshProUGUI = (TextMeshProUGUI)(textMeshProUGUI + num24);
						goto IL_2277;
					}
				}
			}
		}
		goto IL_206f;
		IL_2296:
		if ((nint)textMeshProUGUI > 0)
		{
			if ((object)_Description == null)
			{
				goto IL_206f;
			}
			string text25 = _Description.text;
			int num25 = obj3 + 40;
			string text26 = ((int*)num25)->ToString();
			string text27 = text25 + " (" + text26 + "/3000)";
			_Description.text = text27;
		}
		goto IL_2527;
		IL_20c0:
		throw new IndexOutOfRangeException();
		IL_215b:
		if (bad._003CType_003Ek__BackingField == AchievementType.FindManyGoldenFinger)
		{
			if (_playerOptions != null)
			{
				PlayerOptionsData config18 = _playerOptions.Config;
				if (config18 != null)
				{
					Dictionary<ItemType, int> dictionary6 = config18._003CPickupCount_003Ek__BackingField;
					if (config18._003CPickupCount_003Ek__BackingField != null)
					{
						int num26 = config18._003CPickupCount_003Ek__BackingField.FindEntry(ItemType.GOLDFINGER);
						if (num26 < 0)
						{
							goto IL_2180;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rbx_v63 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.ItemType, System.Int32>)+18]");
						object obj14 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rbx_v63 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.ItemType, System.Int32>)+18]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rcx_v168+18]");
							if ((nint)num26 >= (nint)0)
							{
								goto IL_20c0;
							}
							object obj15 = num26 + num26;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rcx_v168+2C+v2942 @ rax_v205*8]");
							_ = 0;
							if ((object)_Description != null)
							{
								string text28 = _Description.text;
								int num27 = obj3 + 40;
								string text29 = ((int*)num27)->ToString();
								string text30 = text28 + " (" + text29 + "/5)";
								_Description.text = text30;
								goto IL_2180;
							}
						}
					}
				}
			}
			goto IL_206f;
		}
		goto IL_2180;
		IL_2111:
		if (bad._003CType_003Ek__BackingField == AchievementType.FindManyClovers)
		{
			if (_playerOptions != null)
			{
				PlayerOptionsData config19 = _playerOptions.Config;
				if (config19 != null)
				{
					Dictionary<ItemType, int> dictionary7 = config19._003CPickupCount_003Ek__BackingField;
					if (config19._003CPickupCount_003Ek__BackingField != null)
					{
						int num28 = config19._003CPickupCount_003Ek__BackingField.FindEntry(ItemType.CLOVER);
						if (num28 < 0)
						{
							goto IL_2136;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rbx_v67 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.ItemType, System.Int32>)+18]");
						object obj16 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rbx_v67 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.ItemType, System.Int32>)+18]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v487 @ rcx_v184+18]");
							if ((nint)num28 >= (nint)0)
							{
								goto IL_20c0;
							}
							object obj17 = num28 + num28;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v487 @ rcx_v184+2C+v2805 @ rax_v227*8]");
							_ = 0;
							if ((object)_Description != null)
							{
								string text31 = _Description.text;
								int num29 = obj3 + 40;
								string text32 = ((int*)num29)->ToString();
								string text33 = text31 + " (" + text32 + "/23)";
								_Description.text = text33;
								goto IL_2136;
							}
						}
					}
				}
			}
			goto IL_206f;
		}
		goto IL_2136;
		IL_22b6:
		if (bad._003CType_003Ek__BackingField == AchievementType.DefeatManyBats)
		{
			if (_achievementManager == null)
			{
				goto IL_206f;
			}
			int num30 = _achievementManager.CountKilledEnemiesAndVariants(EnemyType.EX_BATS_COUNTER);
			if (num30 > 0)
			{
				if ((object)_Description == null)
				{
					goto IL_206f;
				}
				string text34 = _Description.text;
				int num31 = obj3 + 40;
				string text35 = ((int*)num31)->ToString();
				string text36 = text34 + " (" + text35 + "/161616)";
				_Description.text = text36;
			}
		}
		if (bad._003CType_003Ek__BackingField == AchievementType.DefeatShootingEnemies)
		{
			if (_achievementManager != null)
			{
				int num32 = _achievementManager.CountKilledEnemiesAndVariants(EnemyType.EX_SHOOTING_ENEMIES_COUNTER);
				System.Random random = new System.Random(num32);
				if (random != null)
				{
					int num33 = random.Next(1, 10);
					object obj18 = num32 * 4;
					object obj19 = num32 + obj18;
					object obj20 = obj19 + obj19;
					object obj21 = obj20 - num33;
					if ((nint)obj21 > 0)
					{
						if ((object)_Description == null)
						{
							goto IL_206f;
						}
						string text37 = _Description.text;
						int num34 = obj3 + 40;
						string text38 = ((int*)num34)->ToString();
						string text39 = text37 + " (" + text38 + "/251096)";
						_Description.text = text39;
					}
					goto IL_233e;
				}
			}
			goto IL_206f;
		}
		goto IL_233e;
		IL_254c:
		if ((object)_ObtainedText != null)
		{
			_ObtainedText.enabled = bad._003Cachieved_003Ek__BackingField;
			if (!bad._003Cachieved_003Ek__BackingField)
			{
			}
			if ((object)_InfoBackground != null)
			{
				Color color = (Color)(obj3 - 56);
				_ = 1065353216;
				_InfoBackground.color = color;
				if (_achievementManager != null)
				{
					Sprite spriteForAchievement = _achievementManager.GetSpriteForAchievement(bad);
					if ((object)_Icon != null)
					{
						_Icon.sprite = spriteForAchievement;
						if (_achievementManager != null)
						{
							Sprite frameForSprite = _achievementManager.GetFrameForSprite(bad);
							if ((object)_IconBg != null)
							{
								_IconBg.sprite = frameForSprite;
								TextMeshProUGUI iconBg5 = (TextMeshProUGUI)(object)_IconBg;
								if ((object)_IconBg != null)
								{
									TextMeshProUGUI text40 = (TextMeshProUGUI)(object)((TMP_Text)iconBg5).m_text;
									if (((TMP_Text)iconBg5).m_text != null)
									{
										iconBg = _IconBg;
										if (((UnityEngine.Object)text40).m_CachedPtr != (IntPtr)0)
										{
											if ((object)_IconBg == null)
											{
												goto IL_206f;
											}
											flag2 = true;
											goto IL_23d4;
										}
									}
									else
									{
										iconBg = _IconBg;
									}
									if ((object)iconBg != null)
									{
										flag2 = false;
										goto IL_23d4;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_206f;
		IL_20c7:
		if (bad._003CType_003Ek__BackingField == AchievementType.FB_23_Find__Grenade)
		{
			if (_playerOptions != null)
			{
				PlayerOptionsData config20 = _playerOptions.Config;
				if (config20 != null)
				{
					Dictionary<ItemType, int> dictionary8 = config20._003CPickupCount_003Ek__BackingField;
					if (config20._003CPickupCount_003Ek__BackingField != null)
					{
						int num35 = config20._003CPickupCount_003Ek__BackingField.FindEntry(ItemType.FB_GRENADE);
						if (num35 < 0)
						{
							goto IL_20ec;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rbx_v71 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.ItemType, System.Int32>)+18]");
						object obj22 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rbx_v71 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.ItemType, System.Int32>)+18]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ rcx_v200+18]");
							if ((nint)num35 >= (nint)0)
							{
								goto IL_20c0;
							}
							object obj23 = num35 + num35;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ rcx_v200+2C+v2624 @ rax_v249*8]");
							_ = 0;
							if ((object)_Description != null)
							{
								string text41 = _Description.text;
								int num36 = obj3 + 40;
								string text42 = ((int*)num36)->ToString();
								string text43 = text41 + " (" + text42 + "/28)";
								_Description.text = text43;
								goto IL_20ec;
							}
						}
					}
				}
			}
			goto IL_206f;
		}
		goto IL_20ec;
		IL_21a5:
		if (bad._003CType_003Ek__BackingField == AchievementType.Defeat3000Skeletons)
		{
			if (_achievementManager == null)
			{
				goto IL_206f;
			}
			int num37 = _achievementManager.CountKilledEnemiesAndVariants(EnemyType.SKELETON);
			if (num37 > 0)
			{
				if ((object)_Description == null)
				{
					goto IL_206f;
				}
				string text44 = _Description.text;
				int num38 = obj3 + 40;
				string text45 = ((int*)num38)->ToString();
				string text46 = text44 + " (" + text45 + "/3000)";
				_Description.text = text46;
			}
		}
		if (bad._003CType_003Ek__BackingField == AchievementType.Defeat3000Buers)
		{
			if (_achievementManager == null)
			{
				goto IL_206f;
			}
			int num39 = _achievementManager.CountKilledEnemiesAndVariants(EnemyType.BUER);
			if (num39 > 0)
			{
				if ((object)_Description == null)
				{
					goto IL_206f;
				}
				string text47 = _Description.text;
				int num40 = obj3 + 40;
				string text48 = ((int*)num40)->ToString();
				string text49 = text47 + " (" + text48 + "/3000)";
				_Description.text = text49;
			}
		}
		if (bad._003CType_003Ek__BackingField == AchievementType.Defeat3000Milk)
		{
			if (_achievementManager == null)
			{
				goto IL_206f;
			}
			int num41 = _achievementManager.CountKilledEnemiesAndVariants(EnemyType.MILK);
			if (num41 > 0)
			{
				if ((object)_Description == null)
				{
					goto IL_206f;
				}
				string text50 = _Description.text;
				int num42 = obj3 + 40;
				string text51 = ((int*)num42)->ToString();
				string text52 = text50 + " (" + text51 + "/3000)";
				_Description.text = text52;
			}
		}
		if (bad._003CType_003Ek__BackingField == AchievementType.Defeat3000Hydra)
		{
			_ = 0;
			if (_playerOptions != null)
			{
				PlayerOptionsData config21 = _playerOptions.Config;
				if (config21 != null && config21._003CKillCount_003Ek__BackingField != null)
				{
					int num43 = config21._003CKillCount_003Ek__BackingField.FindEntry(EnemyType.XLDRAGON1);
					bool flag10 = num43 < 0;
					textMeshProUGUI = null;
					if (flag10)
					{
						goto IL_2239;
					}
					if (_playerOptions != null)
					{
						PlayerOptionsData config22 = _playerOptions.Config;
						if (config22 != null && config22._003CKillCount_003Ek__BackingField != null)
						{
							int num44 = config22._003CKillCount_003Ek__BackingField.get_Item(EnemyType.XLDRAGON1);
							textMeshProUGUI = (TextMeshProUGUI)num44;
							goto IL_2239;
						}
					}
				}
			}
			goto IL_206f;
		}
		goto IL_2527;
	}

	private unsafe void PopulateAdventureProgress()
	{
		//IL_007f: Expected O, but got Ref
		//IL_0168: Expected I, but got O
		//IL_01b2: Expected I, but got O
		//IL_01f2: Expected O, but got I
		//IL_024d: Expected O, but got I
		//IL_0292: Expected O, but got Ref
		//IL_02d1: Expected I, but got O
		//IL_030c: Expected I, but got O
		//IL_03ba: Expected O, but got Ref
		//IL_03f9: Expected I, but got O
		AdventureManager adventureManager = _adventureManager;
		bool flag = _adventureManager == null;
		AchievementsPage achievementsPage = this;
		List<AchievementData>.Enumerator enumerator;
		TextMeshProUGUI title;
		string text;
		if (!flag)
		{
			AdventureData adventureData = adventureManager._003CAdventureData_003Ek__BackingField;
			bool flag2 = adventureManager._003CAdventureData_003Ek__BackingField == null;
			achievementsPage = this;
			if (!flag2)
			{
				bool flag3 = adventureData._003CProgressData_003Ek__BackingField == null;
				achievementsPage = this;
				if (!flag3)
				{
					enumerator = (List<AchievementData>.Enumerator)adventureData._003CProgressData_003Ek__BackingField;
					List<AchievementData>.Enumerator enumerator2 = default(List<AchievementData>.Enumerator);
					if (enumerator2.MoveNext())
					{
						AchievementData achievementData = null;
						List<AchievementData>.Enumerator enumerator3 = (List<AchievementData>.Enumerator)(&enumerator2);
						throw new NullReferenceException();
					}
					title = _Title;
					bool ignoreRTLnumbers = default(bool);
					bool applyParameters = default(bool);
					GameObject localParametersRoot = default(GameObject);
					string overrideLanguage = default(string);
					bool flag4 = LocalizationManager.TryGetTranslation("lang/achievements_header", out var Translation, FixForRTL: true, 0, ignoreRTLnumbers, applyParameters, localParametersRoot, overrideLanguage);
					if (Translation != null)
					{
						bool flag5 = Translation._stringLength > 0;
						text = Translation;
						if (flag5)
						{
							goto IL_0493;
						}
					}
					text = "lang/achievements_header";
					goto IL_0493;
				}
			}
		}
		goto IL_0404;
		IL_0404:
		throw new NullReferenceException();
		IL_0493:
		bool flag6 = (object)_Title == null;
		achievementsPage = (AchievementsPage)(object)"lang/achievements_header";
		if (!flag6)
		{
			nint num = (nint)title;
			_Title.text = text;
			AchievementsPage title2 = (AchievementsPage)(object)_Title;
			bool flag7 = (object)_Title == null;
			achievementsPage = (AchievementsPage)(object)_Title;
			if (!flag7)
			{
				nint num2 = (nint)title2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v688 @ rdx_v10 (Il2CppClass<VampireSurvivors.UI.AchievementsPage>)+548] (should have been resolved before IL gen)");
				achievementsPage = (AchievementsPage)(object)_adventureManager;
				if (_adventureManager != null)
				{
					achievementsPage = (AchievementsPage)(nint)((UnityEngine.Object)achievementsPage).m_CachedPtr;
					if (((UnityEngine.Object)achievementsPage).m_CachedPtr != (IntPtr)0)
					{
						bool shouldLog = ((BaseUIPage)achievementsPage).ShouldLog;
						if (~(((BaseUIPage)achievementsPage).ShouldLog ? 1u : 0u) == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v24 (System.Boolean)+2D8]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v24 (System.Boolean)+2D8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v25+18]");
								string newValue = System.Number.FormatInt32(0, (ReadOnlySpan<char>)(&enumerator), null);
								string text2 = default(string);
								if (text2 != null)
								{
									string text3 = text2.Replace("%0", newValue);
									nint num3 = (nint)title2;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v140 @ r9_v10 (Il2CppClass<VampireSurvivors.UI.AchievementsPage>)+558] (should have been resolved before IL gen)");
									AchievementsPage title3 = (AchievementsPage)(object)_Title;
									if ((object)_Title != null)
									{
										nint num4 = (nint)title3;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v741 @ rdx_v15 (Il2CppClass<VampireSurvivors.UI.AchievementsPage>)+548] (should have been resolved before IL gen)");
										AdventureManager adventureManager2 = _adventureManager;
										if (_adventureManager != null)
										{
											AdventureData adventureData2 = adventureManager2._003CAdventureData_003Ek__BackingField;
											if (adventureManager2._003CAdventureData_003Ek__BackingField != null)
											{
												List<AchievementData> list = adventureData2._003CProgressData_003Ek__BackingField;
												if (adventureData2._003CProgressData_003Ek__BackingField != null)
												{
													string newValue2 = System.Number.FormatInt32(list._size, (ReadOnlySpan<char>)(&enumerator), null);
													string text4 = default(string);
													if (text4 != null)
													{
														string text5 = text4.Replace("%1", newValue2);
														nint num5 = (nint)title3;
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v562 @ r9_v13 (Il2CppClass<VampireSurvivors.UI.AchievementsPage>)+558] (should have been resolved before IL gen)");
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
		goto IL_0404;
	}

	private void SpawnAdventureProgressUnlock(AdventureAchievementType type, AchievementData data)
	{
		AdventureManager adventureManager = _adventureManager;
		PlayerOptions playerOptions = adventureManager._playerOptions;
		PlayerOptionsData currentAdventureSaveData = playerOptions._currentAdventureSaveData;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9D310");
		object obj = default(object);
		if (obj != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config._003CHideCompletedAchievements_003Ek__BackingField)
			{
				return;
			}
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(_AchievementPrefab, _content);
		AchievementDataUI component = gameObject.GetComponent<AchievementDataUI>();
		component._isAdventureAchievement = true;
		component._adventureType = type;
		bool hasCompleted = default(bool);
		component.Init(data, this, _dataManager, hasCompleted);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
	}

	private unsafe void PopulateBaseGameAchievements()
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_00b0: Expected O, but got I4
		//IL_00d0: Expected O, but got Ref
		//IL_053d: Expected O, but got Ref
		//IL_05bd: Expected O, but got I
		//IL_05ca: Expected I4, but got O
		//IL_05e2: Expected O, but got Ref
		PlayerOptionsData config = _playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rcx_v23 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 == 0)
		{
			bool flag = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			object obj = obj2 - -1;
			bool flag2 = obj == null;
			bool flag = !flag2;
			AchievementData achievementData = null;
		}
		DataManager dataManager = _dataManager;
		Dictionary<AchievementType, AchievementData> dictionary = dataManager._003CAllAchievements_003Ek__BackingField;
		object obj3 = 0;
		Dictionary<AchievementType, AchievementData>.Enumerator enumerator = default(Dictionary<AchievementType, AchievementData>.Enumerator);
		if (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			AchievementType achievementType = AchievementType.ReachLV5;
			Dictionary<AchievementType, AchievementData>.Enumerator enumerator2 = (Dictionary<AchievementType, AchievementData>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		bool ignoreRTLnumbers = default(bool);
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool flag3 = LocalizationManager.TryGetTranslation("lang/achievements_header", out var Translation, FixForRTL: true, 0, ignoreRTLnumbers, applyParameters, localParametersRoot, overrideLanguage);
		string text;
		if (Translation != null)
		{
			bool flag4 = Translation._stringLength > 0;
			text = Translation;
			if (flag4)
			{
				goto IL_04f8;
			}
		}
		text = "lang/achievements_header";
		goto IL_04f8;
		IL_04f8:
		_Title.text = text;
		string text2 = _Title.text;
		int validUnlockedAchievementCount = GetValidUnlockedAchievementCount();
		object obj4 = default(object);
		string newValue = System.Number.FormatInt32(validUnlockedAchievementCount, (ReadOnlySpan<char>)(&obj4), null);
		string text3 = text2.Replace("%0", newValue);
		_Title.text = text3;
		string text4 = _Title.text;
		DataManager dataManager2 = _dataManager;
		Dictionary<AchievementType, AchievementData> dictionary2 = dataManager2._003CAllAchievements_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v35 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.AchievementType, VampireSurvivors.Achievements.AchievementData>)+20]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v35 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.AchievementType, VampireSurvivors.Achievements.AchievementData>)+28]");
		object obj5 = num - 0;
		int value = obj5 - obj3;
		string newValue2 = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&obj4), null);
		string text5 = text4.Replace("%1", newValue2);
		_Title.text = text5;
	}

	private int GetValidUnlockedAchievementCount()
	{
		//IL_0198: Expected O, but got I
		//IL_008a: Expected O, but got I
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		PlayerOptionsData config = _playerOptions.Config;
		int num = 0;
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ stack_-28_v9+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ stack_-28_v9+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ stack_-28_v9+10]");
						object obj5 = 0;
						object obj6 = obj4 + 1;
						DataManager dataManager = _dataManager;
						HashSet<AchievementType> hashSet = dataManager._003CAllLoadedAchievements_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v15+20+v95 @ stack_-20_v8*4]");
						bool flag = hashSet.Contains(AchievementType.ReachLV5);
						bool flag2 = !flag;
						obj4 = obj6;
						if (!flag2)
						{
							num++;
							obj4 = obj6;
						}
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag3 = obj == null;
		PlayerOptions playerOptions = (PlayerOptions)0;
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ stack_-28_v9+1C]");
			if (obj2 == null)
			{
				return num;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			playerOptions = null;
		}
		throw new NullReferenceException();
	}

	private IEnumerator WaitAndReformat()
	{
		_003CWaitAndReformat_003Ed__32 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void SpawnAchievement(AchievementType type, AchievementData data)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B0B0");
		object obj = default(object);
		if (obj != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config._003CHideCompletedAchievements_003Ek__BackingField)
			{
				return;
			}
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(_AchievementPrefab, _content);
		AchievementDataUI component = gameObject.GetComponent<AchievementDataUI>();
		component._isAdventureAchievement = false;
		component._type = type;
		bool hasCompleted = default(bool);
		component.Init(data, this, _dataManager, hasCompleted);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
	}

	public AchievementsPage()
	{
		List<GameObject> spawned = new List<GameObject>();
		_spawned = spawned;
		_baseGameUnlocked = new List<AchievementType>();
		base._002Ector();
	}
}
