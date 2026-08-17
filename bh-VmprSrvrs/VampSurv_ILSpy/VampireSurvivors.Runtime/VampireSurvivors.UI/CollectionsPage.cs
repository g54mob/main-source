using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using VampireSurvivors.App.Data.Adventures;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class CollectionsPage : BaseUIPage
{
	public enum FilterType
	{
		DEFAULT,
		BY_TYPE,
		BY_VERSION,
		ADVENTURE
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<CollectionItemUI, bool> _003C_003E9__44_0;

		public static Func<CollectionItemUI, bool> _003C_003E9__44_1;

		public static Func<CollectionItemUI, bool> _003C_003E9__44_2;

		public static Func<CollectionItemUI, bool> _003C_003E9__44_3;

		public static Func<CollectionItemUI, string> _003C_003E9__44_4;

		public static Func<CollectionItemUI, bool> _003C_003E9__44_5;

		public static Func<CollectionItemUI, bool> _003C_003E9__44_6;

		public static Func<CollectionItemUI, bool> _003C_003E9__44_7;

		public static Func<CollectionItemUI, bool> _003C_003E9__45_0;

		public static Func<CollectionItemUI, bool> _003C_003E9__45_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CSortByType_003Eb__44_0(CollectionItemUI x)
		{
			//IL_00ad: Expected I4, but got O
			if ((object)x != null)
			{
				if (x._weaponType != WeaponType.VOID)
				{
					WeaponData weaponData = x._weaponData;
					if (x._weaponData == null)
					{
						goto IL_009f;
					}
					if (!weaponData._003CisPowerUp_003Ek__BackingField)
					{
						return true;
					}
				}
				return false;
			}
			goto IL_009f;
			IL_009f:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CSortByType_003Eb__44_1(CollectionItemUI x)
		{
			//IL_00aa: Expected I4, but got O
			if ((object)x != null)
			{
				if (x._weaponType != WeaponType.VOID)
				{
					WeaponData weaponData = x._weaponData;
					if (x._weaponData == null)
					{
						goto IL_009c;
					}
					if (weaponData._003CisPowerUp_003Ek__BackingField)
					{
						return true;
					}
				}
				return false;
			}
			goto IL_009c;
			IL_009c:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CSortByType_003Eb__44_2(CollectionItemUI x)
		{
			//IL_0074: Expected I4, but got O
			if ((object)x != null)
			{
				if (x._itemType != ItemType.VOID && !x.IsRelic())
				{
					return true;
				}
				return false;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CSortByType_003Eb__44_3(CollectionItemUI x)
		{
			//IL_003d: Expected I4, but got O
			if ((object)x != null)
			{
				return x.IsRelic();
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal string _003CSortByType_003Eb__44_4(CollectionItemUI x)
		{
			if ((object)x != null)
			{
				ItemData itemData = x._itemData;
				if (x._itemData != null)
				{
					return itemData._003CcollectionFrame_003Ek__BackingField;
				}
			}
			return (string)(object)new NullReferenceException();
		}

		internal bool _003CSortByType_003Eb__44_5(CollectionItemUI x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._itemType - 24;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CSortByType_003Eb__44_6(CollectionItemUI x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._itemType - 75;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CSortByType_003Eb__44_7(CollectionItemUI x)
		{
			//IL_005d: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._arcanaType - -1;
				bool flag = obj == null;
				return !flag;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CSortByVersion_003Eb__45_0(CollectionItemUI x)
		{
			//IL_00c7: Expected I4, but got O
			if ((object)x != null)
			{
				if (x._weaponData == null)
				{
					if (x._itemData == null)
					{
						return true;
					}
					ItemData itemData = x._itemData;
					return itemData._003CcontentGroup_003Ek__BackingField == ContentGroupType.BASE;
				}
				WeaponData weaponData = x._weaponData;
				return weaponData._003CcontentGroup_003Ek__BackingField == ContentGroupType.BASE;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CSortByVersion_003Eb__45_1(CollectionItemUI x)
		{
			//IL_013c: Expected I4, but got O
			//IL_011a: Expected O, but got I4
			//IL_00e6: Expected O, but got I4
			//IL_00b2: Expected O, but got I4
			if ((object)x != null)
			{
				if (x._weaponData == null)
				{
					if (x._itemData == null)
					{
						if (x._arcanaData == null)
						{
							return false;
						}
						ArcanaData arcanaData = x._arcanaData;
						object obj = arcanaData._003CcontentGroup_003Ek__BackingField - 1;
						return obj == null;
					}
					ItemData itemData = x._itemData;
					object obj2 = itemData._003CcontentGroup_003Ek__BackingField - 1;
					return obj2 == null;
				}
				WeaponData weaponData = x._weaponData;
				object obj3 = weaponData._003CcontentGroup_003Ek__BackingField - 1;
				return obj3 == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public static bool IsMagician;

	private bool _DEBUG;

	private Localize Name;

	private Localize Description;

	private Localize AdditionalInfo;

	private Image Icon;

	private Image Background;

	private Localize Title;

	private GameObject CollectionPrefab;

	private RectTransform _MagicianPanel;

	private SealPanel _SealPanel;

	private GameObject _GridPrefab;

	private GameObject _HeaderPrefab;

	private TextMeshProUGUI _FilterModeText;

	private MobileConfig _PanelPanelConfig;

	private MegaSealPanel _MegaSealPanel;

	private DataManager _data;

	private PlayerOptions _playerOptions;

	private AdventureManager _adventures;

	private List<CollectionItemUI> _spawned;

	private List<GameObject> _structuralSpawned;

	private int _totalUnlocked;

	private int _totalAvailable;

	private RectTransform _scrollRect;

	private int _yellowSignClickCount;

	private RectTransform _activeContentGrid;

	private bool shouldForceLayoutUpdate;

	private bool shouldRegenerateNav;

	private bool _hasDarkasso;

	private List<CollectionItemUI> _defaultSortOrder;

	public FilterType _currentFilter;

	private void Construct(DataManager data, PlayerOptions player, AdventureManager adventure)
	{
		_data = data;
		_playerOptions = player;
		_adventures = adventure;
	}

	protected override void OnShowStart(GameObject g)
	{
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		base.OnShowStart(g);
		int maxSeals = _playerOptions.GetMaxSeals();
		FilterType currentFilter;
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			currentFilter = FilterType.ADVENTURE;
		}
		else
		{
			PlayerOptionsData config = _playerOptions.Config;
			currentFilter = config.CollectionFilterMode;
		}
		_currentFilter = currentFilter;
		PlayerOptionsData config2 = _playerOptions.Config;
		List<ItemType> list = config2._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rcx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		bool hasDarkasso;
		if ((nint)0 == 0)
		{
			hasDarkasso = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			object obj = obj2 - -1;
			bool flag = obj == null;
			hasDarkasso = !flag;
		}
		MegaSealPanel megaSealPanel = _MegaSealPanel;
		_hasDarkasso = hasDarkasso;
		megaSealPanel._page = this;
		_MegaSealPanel.TryShow();
		Populate();
		SealPanel sealPanel = _SealPanel;
		sealPanel._playerOptions = _playerOptions;
		_SealPanel.UpdateValues();
		if (!_MegaSealPanel.IsAvailable)
		{
			_MegaSealPanel.UnsealAll(playSound: false);
		}
		shouldForceLayoutUpdate = true;
	}

	private void LateUpdate()
	{
		if (shouldRegenerateNav)
		{
			shouldRegenerateNav = false;
			GenerateNavigation();
		}
		if (shouldForceLayoutUpdate)
		{
			shouldForceLayoutUpdate = false;
			RectTransform component = GetComponent<RectTransform>();
			VampireSurvivors.App.Tools.Extensions.RefreshLayoutGroupsImmediateAndRecursive(component);
			Canvas.ForceUpdateCanvases();
			shouldRegenerateNav = true;
		}
	}

	private void Populate()
	{
		//IL_088c: Expected O, but got I
		//IL_00cb: Expected O, but got I
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		//IL_02c5: Expected O, but got I
		//IL_07dd: Expected I, but got O
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Expected O, but got Unknown
		//IL_04d1: Expected O, but got I
		//IL_0828: Expected I, but got O
		//IL_04df: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e4: Expected O, but got Unknown
		//IL_0689: Expected O, but got I4
		//IL_06d2: Expected O, but got I4
		Reset();
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _data.GetConvertedWeapons();
		DataManager data = _data;
		WeaponType[] yellowWeapons = new WeaponType[0];
		ItemType[] array = new ItemType[0];
		_totalAvailable = 0;
		PlayerOptionsData config = _playerOptions.Config;
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ stack_-80_v31+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ stack_-80_v31+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ stack_-80_v31+10]");
						object obj5 = 0;
						object obj6 = obj4 + 1;
						bool flag = convertedWeapons == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v495 @ rdx_v77+20+v470 @ stack_-78_v30*4]");
						int num = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).FindEntry((System.Int32Enum)0);
						obj4 = obj6;
						if (!flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v495 @ rdx_v77+20+v823 @ rcx_v103*4]");
							object obj7 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
							List<WeaponData> list = ((Dictionary<WeaponType, List<WeaponData>>)obj7).get_Item(WeaponType.VOID);
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v495 @ rdx_v77+20+v823 @ rcx_v103*4]");
							object obj8 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
							List<WeaponData> list2 = ((Dictionary<WeaponType, List<WeaponData>>)obj8).get_Item(WeaponType.VOID);
							list2._items = null;
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
		bool flag2 = obj == null;
		PlayerOptions playerOptions = (PlayerOptions)0;
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ stack_-80_v31+1C]");
			if (obj2 == null)
			{
				PlayerOptions playerOptions2 = _playerOptions;
				if (playerOptions2._onlineClientWithRunDataConfig == null && playerOptions2._hostGameConfig == null && playerOptions2._currentAdventureSaveData != null)
				{
					PlayerOptionsData currentAdventureSaveData = playerOptions2._currentAdventureSaveData;
					if ((object)currentAdventureSaveData._003CSelectedAdventureType_003Ek__BackingField != null)
					{
					}
				}
				object obj9 = default(object);
				object obj10 = default(object);
				object obj12 = default(object);
				while (true)
				{
					if (obj9 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ stack_-C0_v32+1C]");
						if (obj10 != null)
						{
							break;
						}
						object obj11 = obj12;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ stack_-C0_v32+18]");
						if ((nint)obj11 >= 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ stack_-C0_v32+10]");
						object obj13 = 0;
						object obj14 = obj12 + 1;
						bool flag3 = data._003CAllItems_003Ek__BackingField == null;
						Dictionary<ItemType, ItemData> dictionary = data._003CAllItems_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1249 @ rbx_v40+20+v1243 @ stack_-B8_v30*4]");
						int num2 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).FindEntry((System.Int32Enum)0);
						obj12 = obj14;
						if (!flag3)
						{
							Dictionary<ItemType, ItemData> dictionary2 = data._003CAllItems_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1249 @ rbx_v40+20+v1475 @ rcx_v93*4]");
							object obj15 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).get_Item((System.Int32Enum)0);
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1249 @ rbx_v40+20+v1475 @ rcx_v93*4]");
							bool flag4 = (nint)0 != 75;
							obj12 = obj14;
							if (!flag4)
							{
								Dictionary<ItemType, ItemData> dictionary3 = data._003CAllItems_003Ek__BackingField;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1249 @ rbx_v40+20+v1475 @ rcx_v93*4]");
								object obj16 = ((Dictionary<System.Int32Enum, object>)(object)dictionary3).get_Item((System.Int32Enum)0);
								_ = 0;
								obj12 = obj14;
							}
						}
						continue;
					}
					throw new NullReferenceException();
				}
				bool flag5 = obj9 == null;
				nint num3 = 0;
				if (!flag5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ stack_-C0_v32+1C]");
					if (obj10 == null)
					{
						PlayerOptions playerOptions3 = _playerOptions;
						if (playerOptions3._onlineClientWithRunDataConfig == null && playerOptions3._hostGameConfig == null && playerOptions3._currentAdventureSaveData != null)
						{
							PlayerOptionsData currentAdventureSaveData2 = playerOptions3._currentAdventureSaveData;
							if ((object)currentAdventureSaveData2._003CSelectedAdventureType_003Ek__BackingField != null)
							{
							}
						}
						object obj17 = default(object);
						object obj18 = default(object);
						object obj20 = default(object);
						while (true)
						{
							if (obj17 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ stack_-A8_v32+1C]");
								if (obj18 == null)
								{
									object obj19 = obj20;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ stack_-A8_v32+18]");
									if ((nint)obj19 < 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ stack_-A8_v32+10]");
										object obj21 = 0;
										object obj22 = obj20 + 1;
										bool flag6 = data._003CAllArcanas_003Ek__BackingField == null;
										Dictionary<ArcanaType, ArcanaData> dictionary4 = data._003CAllArcanas_003Ek__BackingField;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1877 @ rdx_v65+20+v1846 @ stack_-A0_v30*4]");
										int num4 = ((Dictionary<System.Int32Enum, object>)(object)dictionary4).FindEntry((System.Int32Enum)0);
										obj20 = obj22;
										if (!flag6)
										{
											Dictionary<ArcanaType, ArcanaData> dictionary5 = data._003CAllArcanas_003Ek__BackingField;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1877 @ rdx_v65+20+v2068 @ rcx_v84*4]");
											object obj23 = ((Dictionary<System.Int32Enum, object>)(object)dictionary5).get_Item((System.Int32Enum)0);
											_ = 1;
											obj20 = obj22;
										}
										continue;
									}
									break;
								}
								break;
							}
							throw new NullReferenceException();
						}
						bool flag7 = obj17 == null;
						nint num5 = 0;
						if (!flag7)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ stack_-A8_v32+1C]");
							if (obj18 == null)
							{
								ItemType[] array2 = default(ItemType[]);
								Dictionary<ArcanaType, ArcanaData> arcanas = default(Dictionary<ArcanaType, ArcanaData>);
								SpawnElements(convertedWeapons, yellowWeapons, data._003CAllItems_003Ek__BackingField, array2, arcanas);
								CollectionItemUI[] componentsInChildren = _content.GetComponentsInChildren<CollectionItemUI>();
								if (componentsInChildren != null)
								{
									List<object> defaultSortOrder = new List<object>(componentsInChildren);
									_defaultSortOrder = (List<CollectionItemUI>)(object)defaultSortOrder;
									SetFilter();
									List<CollectionItemUI> spawned = _spawned;
									if (spawned._size > 0)
									{
										CollectionItemUI[] items = spawned._items;
										Selectable component = items[0].GetComponent<Selectable>();
										component.Select();
										SetTitle();
										List<CollectionItemUI> spawned2 = _spawned;
										object obj24 = spawned2._size - 1;
										if ((nint)obj24 < spawned2._size)
										{
											CollectionItemUI[] items2 = spawned2._items;
											object obj25 = spawned2._size - 1;
											Selectable component2 = items2[obj25].GetComponent<Selectable>();
											List<CollectionItemUI> spawned3 = _spawned;
											if (spawned3._size > 0)
											{
												CollectionItemUI[] items3 = spawned3._items;
												Selectable component3 = items3[0].GetComponent<Selectable>();
												ForceBackButtonNavigation(component2, component3, null, (Selectable)(object)array2);
												LayoutRebuilder.ForceRebuildLayoutImmediate(_content);
												Canvas.ForceUpdateCanvases();
												return;
											}
										}
									}
									System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
								}
								Exception ex = System.Linq.Error.ArgumentNull("source");
								throw ex;
							}
							System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
							num5 = unchecked((nint)null);
						}
						throw new NullReferenceException();
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
					num3 = unchecked((nint)null);
				}
				throw new NullReferenceException();
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			playerOptions = null;
		}
		throw new NullReferenceException();
	}

	private unsafe void GenerateNavigation()
	{
		//IL_004d: Expected O, but got I4
		//IL_0056: Expected O, but got I4
		//IL_09fc: Expected O, but got I4
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected I4, but got Unknown
		//IL_07d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d8: Expected O, but got Unknown
		//IL_0361: Expected O, but got Ref
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_041b: Expected O, but got Unknown
		//IL_0424: Invalid comparison between F4 and O
		//IL_0470: Unknown result type (might be due to invalid IL or missing references)
		//IL_0475: Expected O, but got Unknown
		//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c4: Expected O, but got Unknown
		//IL_063f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0644: Expected O, but got Unknown
		//IL_064d: Invalid comparison between F4 and O
		//IL_067b: Expected O, but got I4
		//IL_0a55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5a: Expected O, but got Unknown
		//IL_0a63: Expected O, but got I4
		//IL_06a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a5: Expected O, but got Unknown
		//IL_0719: Unknown result type (might be due to invalid IL or missing references)
		//IL_071e: Expected O, but got Unknown
		//IL_0a14->IL0988: Incompatible stack heights: 1 vs 0
		//IL_0136->IL0988: Incompatible stack heights: 1 vs 0
		//IL_0160->IL0988: Incompatible stack heights: 1 vs 0
		//IL_0198->IL0988: Incompatible stack heights: 1 vs 0
		//IL_01cb->IL0988: Incompatible stack heights: 1 vs 0
		//IL_01fa->IL0988: Incompatible stack heights: 1 vs 0
		//IL_0224->IL0988: Incompatible stack heights: 1 vs 0
		//IL_025c->IL0988: Incompatible stack heights: 1 vs 0
		//IL_02a3->IL0988: Incompatible stack heights: 1 vs 0
		//IL_02d6->IL0988: Incompatible stack heights: 1 vs 0
		//IL_07e5->IL0a6a: Incompatible stack heights: 1 vs 0
		//IL_031f->IL0988: Incompatible stack heights: 1 vs 0
		//IL_0346->IL0988: Incompatible stack heights: 1 vs 0
		//IL_03b4->IL0988: Incompatible stack heights: 1 vs 0
		//IL_03e7->IL0988: Incompatible stack heights: 1 vs 0
		//IL_05d8->IL0988: Incompatible stack heights: 1 vs 0
		//IL_049b->IL0988: Incompatible stack heights: 1 vs 0
		//IL_060b->IL0988: Incompatible stack heights: 1 vs 0
		//IL_04ea->IL0988: Incompatible stack heights: 1 vs 0
		//IL_051d->IL0988: Incompatible stack heights: 1 vs 0
		//IL_0547->IL0988: Incompatible stack heights: 1 vs 0
		//IL_06cb->IL0988: Incompatible stack heights: 1 vs 0
		//IL_0583->IL0988: Incompatible stack heights: 1 vs 0
		//IL_06fe->IL0988: Incompatible stack heights: 1 vs 0
		//IL_0744->IL0988: Incompatible stack heights: 1 vs 0
		//IL_0777->IL0988: Incompatible stack heights: 1 vs 0
		//IL_07a6->IL0988: Incompatible stack heights: 1 vs 0
		if ((object)_content != null)
		{
			GridLayoutGroup[] componentsInChildren = _content.GetComponentsInChildren<GridLayoutGroup>();
			if ((object)BackButtonController.Instance != null)
			{
				Selectable component = BackButtonController.Instance.GetComponent<Selectable>();
				if (componentsInChildren != null)
				{
					object obj = 0;
					object obj2 = 0;
					object obj4 = default(object);
					object obj6 = default(object);
					object obj7 = default(object);
					Selectable right = default(Selectable);
					while (true)
					{
						if ((nint)obj2 < componentsInChildren.Length)
						{
							if ((object)componentsInChildren[obj] == null)
							{
								break;
							}
							Transform transform = componentsInChildren[obj].transform;
							if ((object)componentsInChildren[obj] == null)
							{
								break;
							}
							Transform transform2 = componentsInChildren[obj].transform;
							if ((object)transform2 == null)
							{
								break;
							}
							bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							object obj3 = Transform.get_childCount_Injected(((UnityEngine.Object)transform2).m_CachedPtr);
							if ((object)transform == null)
							{
								break;
							}
							int index = obj3 - 1;
							Transform child = transform.GetChild(index);
							if ((object)child == null)
							{
								break;
							}
							RectTransform component2 = child.GetComponent<RectTransform>();
							if ((object)component2 == null)
							{
								break;
							}
							Vector2 anchoredPosition = component2.anchoredPosition;
							if ((object)componentsInChildren[obj] == null)
							{
								break;
							}
							Transform transform3 = componentsInChildren[obj].transform;
							if ((object)transform3 == null)
							{
								break;
							}
							Transform child2 = transform3.GetChild(0);
							if ((object)child2 == null)
							{
								break;
							}
							RectTransform component3 = child2.GetComponent<RectTransform>();
							if ((object)component3 == null)
							{
								break;
							}
							Vector2 anchoredPosition2 = component3.anchoredPosition;
							if ((object)componentsInChildren[obj] == null)
							{
								break;
							}
							Selectable[] componentsInChildren2 = componentsInChildren[obj].GetComponentsInChildren<Selectable>();
							Transform transform4 = null;
							while ((object)componentsInChildren[obj] != null)
							{
								Transform transform5 = componentsInChildren[obj].transform;
								if ((object)transform5 == null)
								{
									break;
								}
								int childCount = transform5.childCount;
								if ((nint)transform4 < childCount)
								{
									if (componentsInChildren2 == null || (object)componentsInChildren2[(object)transform4] == null)
									{
										break;
									}
									componentsInChildren2[(object)transform4].navigation = (Navigation)(&obj4);
									SetNavigationRight(componentsInChildren2[(object)transform4]);
									SetNavigationLeft(componentsInChildren2[(object)transform4]);
									if ((object)componentsInChildren2[(object)transform4] == null)
									{
										break;
									}
									RectTransform component4 = componentsInChildren2[(object)transform4].GetComponent<RectTransform>();
									if ((object)component4 == null)
									{
										break;
									}
									Vector2 anchoredPosition3 = component4.anchoredPosition;
									object obj5 = obj6 - obj7;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
									object obj8 = obj5 & 0;
									Selectable selectable;
									Selectable target;
									if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
									{
										selectable = component;
										target = null;
									}
									else if (obj != null)
									{
										object obj9 = obj - 1;
										if ((object)componentsInChildren[obj9] == null)
										{
											break;
										}
										Transform transform6 = componentsInChildren[obj9].transform;
										object obj10 = obj - 1;
										if ((object)componentsInChildren[obj10] == null)
										{
											break;
										}
										Transform transform7 = componentsInChildren[obj10].transform;
										if ((object)transform7 == null)
										{
											break;
										}
										int childCount2 = transform7.childCount;
										if ((object)transform6 == null)
										{
											break;
										}
										int index2 = childCount2 - 1;
										Transform child3 = transform6.GetChild(index2);
										if ((object)child3 == null)
										{
											break;
										}
										target = child3.GetComponent<Selectable>();
										selectable = component;
									}
									else
									{
										selectable = component;
										target = component;
									}
									SetNavigationUp(componentsInChildren2[(object)transform4], target);
									if ((object)componentsInChildren2[(object)transform4] == null)
									{
										break;
									}
									RectTransform component5 = componentsInChildren2[(object)transform4].GetComponent<RectTransform>();
									if ((object)component5 == null)
									{
										break;
									}
									Vector2 anchoredPosition4 = component5.anchoredPosition;
									object obj11 = obj6 - obj6;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
									object obj12 = obj11 & 0;
									Selectable target2;
									if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12))
									{
										target2 = null;
									}
									else
									{
										object obj13 = componentsInChildren.Length - 1;
										if (obj != obj13)
										{
											object obj14 = obj + 1;
											if ((object)componentsInChildren[obj14] == null)
											{
												break;
											}
											Transform transform8 = componentsInChildren[obj14].transform;
											if ((object)transform8 == null)
											{
												break;
											}
											int childCount3 = transform8.childCount;
											object obj15 = obj + 1;
											if ((object)componentsInChildren[obj15] == null)
											{
												break;
											}
											Transform transform9 = componentsInChildren[obj15].transform;
											if ((object)transform9 == null)
											{
												break;
											}
											Transform child4 = transform9.GetChild(0);
											if ((object)child4 == null)
											{
												break;
											}
											target2 = child4.GetComponent<Selectable>();
										}
										else
										{
											target2 = selectable;
										}
									}
									SetNavigationDown(componentsInChildren2[(object)transform4], target2);
									transform4 = (Transform)(transform4 + 1);
									obj4 = 4;
									continue;
								}
								goto IL_07ca;
							}
							break;
						}
						if ((object)_activeContentGrid == null)
						{
							break;
						}
						Transform transform10 = _activeContentGrid.transform;
						if ((object)transform10 == null)
						{
							break;
						}
						int childCount4 = transform10.childCount;
						int index3 = childCount4 - 1;
						Transform child5 = _activeContentGrid.GetChild(index3);
						if ((object)child5 == null)
						{
							break;
						}
						Selectable component6 = child5.GetComponent<Selectable>();
						if ((object)_content == null)
						{
							break;
						}
						GridLayoutGroup[] componentsInChildren3 = _content.GetComponentsInChildren<GridLayoutGroup>();
						if (componentsInChildren3 == null || (object)componentsInChildren3[0] == null)
						{
							break;
						}
						Transform transform11 = componentsInChildren3[0].transform;
						if ((object)transform11 == null)
						{
							break;
						}
						Transform child6 = transform11.GetChild(0);
						if ((object)child6 == null)
						{
							break;
						}
						Selectable component7 = child6.GetComponent<Selectable>();
						ForceBackButtonNavigation(component6, component7, null, right);
						return;
						IL_07ca:
						obj++;
						obj2 = obj;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void SpawnElements(Dictionary<WeaponType, List<WeaponData>> weapons, WeaponType[] yellowWeapons, Dictionary<ItemType, ItemData> items, ItemType[] yellowItems, Dictionary<ArcanaType, ArcanaData> arcanas)
	{
		//IL_06e4->IL04f9: Incompatible stack heights: 1 vs 0
		AddGrid();
		WeaponType[] array2 = default(WeaponType[]);
		WeaponType[] array = array2;
		Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator = default(Dictionary<WeaponType, List<WeaponData>>.Enumerator);
		while (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
		}
		WeaponType[] array3 = null;
		Dictionary<ItemType, ItemData>.Enumerator enumerator2 = default(Dictionary<ItemType, ItemData>.Enumerator);
		while (enumerator2.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			ItemData itemData = null;
		}
		GameObject gameObject = ((Component)(object)array3).gameObject;
		if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ r14_v14 (VampireSurvivors.Data.WeaponType[])+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ r14_v14 (VampireSurvivors.Data.WeaponType[])+10]");
			Transform.SetAsLastSibling_Injected((IntPtr)0);
		}
		Dictionary<ArcanaType, ArcanaData>.Enumerator enumerator3 = default(Dictionary<ArcanaType, ArcanaData>.Enumerator);
		ArcanaData arcanaData = default(ArcanaData);
		while (enumerator3.MoveNext())
		{
			if (arcanaData != null && !arcanaData._003Chidden_003Ek__BackingField && arcanaData._003Cmajor_003Ek__BackingField && arcanaData._003Cunlocked_003Ek__BackingField)
			{
				AddArcana(arcanaData, ArcanaType.T00_KILLER);
				int totalAvailable = _totalAvailable + 1;
				_totalAvailable = totalAvailable;
			}
		}
	}

	protected override void OnHideStart(GameObject g)
	{
		base.OnHideStart(g);
		ResetBackButtonNavigation();
		if (!AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			PlayerOptionsData config = _playerOptions.Config;
			config.CollectionFilterMode = _currentFilter;
		}
		ClearStructures();
		Reset();
		_playerOptions.Save();
	}

	private void AddWeapon(WeaponData dat, WeaponType type)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(CollectionPrefab, _activeContentGrid);
		CollectionItemUI component = gameObject.GetComponent<CollectionItemUI>();
		PlayerOptionsData config = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
		object obj = default(object);
		if (obj == null)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
		}
		bool isSealed = default(bool);
		component.SetData(dat, this, type, isSealed);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E0C0");
		if (dat._003Cseen_003Ek__BackingField)
		{
			int totalUnlocked = _totalUnlocked + 1;
			_totalUnlocked = totalUnlocked;
		}
	}

	private GameObject AddItem(ItemData dat, ItemType type)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(CollectionPrefab, _activeContentGrid);
		CollectionItemUI component;
		if ((object)gameObject != null)
		{
			component = gameObject.GetComponent<CollectionItemUI>();
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null && config._003CSealedItems_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
					object obj = default(object);
					if (obj != null)
					{
						goto IL_0159;
					}
					if (_playerOptions != null)
					{
						PlayerOptionsData config2 = _playerOptions.Config;
						if (config2 != null && config2._003CContentGroupSealedItems_003Ek__BackingField != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
							goto IL_0159;
						}
					}
				}
			}
		}
		goto IL_01f9;
		IL_0159:
		if ((object)component != null)
		{
			bool isSealed = default(bool);
			component.SetItem(dat, this, type, isSealed);
			if (dat != null)
			{
				if (dat._003Cseen_003Ek__BackingField)
				{
					int totalUnlocked = _totalUnlocked + 1;
					_totalUnlocked = totalUnlocked;
				}
				if (_spawned != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E0C0");
					return gameObject;
				}
			}
		}
		goto IL_01f9;
		IL_01f9:
		return (GameObject)(object)new NullReferenceException();
	}

	private void AddArcana(ArcanaData dat, ArcanaType type)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(CollectionPrefab, _activeContentGrid);
		CollectionItemUI component = gameObject.GetComponent<CollectionItemUI>();
		component.SetArcana(dat, this, type);
		if (dat._003Cunlocked_003Ek__BackingField)
		{
			int totalUnlocked = _totalUnlocked + 1;
			_totalUnlocked = totalUnlocked;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E0C0");
	}

	private unsafe void SetTitle()
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected I4, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected I4, but got Unknown
		//IL_019a: Expected O, but got I
		//IL_03e5: Expected O, but got I4
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_035e: Expected O, but got Ref
		//IL_039d: Expected O, but got Ref
		TextMeshProUGUI component = Title.GetComponent<TextMeshProUGUI>();
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation("lang/weapon_header", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		string newValue2;
		string text2;
		if (!AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			int num = this + 384;
			string newValue = ((int*)num)->ToString();
			string text = translation.Replace("%0", newValue);
			int num2 = this + 388;
			newValue2 = ((int*)num2)->ToString();
			text2 = text;
			goto IL_03ae;
		}
		string translation2 = LocalizationManager.GetTranslation("adventureLang/adv_adventureCollection_collected", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		AdventureManager adventures = _adventures;
		AdventureData adventureData = adventures._003CAdventureData_003Ek__BackingField;
		int num3 = 0;
		object obj2 = default(object);
		object obj = obj2;
		object obj3 = default(object);
		object obj5 = default(object);
		object obj7 = default(object);
		while (true)
		{
			PlayerOptionsData playerOptionsData;
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v45+1C]");
				if (obj3 != null)
				{
					break;
				}
				object obj4 = obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v45+18]");
				if ((nint)obj4 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v45+10]");
				object obj6 = 0;
				obj5++;
				PlayerOptions playerOptions = _playerOptions;
				if (playerOptions._onlineClientWithRunDataConfig == null)
				{
					if (playerOptions._hostGameConfig == null)
					{
						if (playerOptions._currentAdventureSaveData != null)
						{
							playerOptionsData = playerOptions._currentAdventureSaveData;
							if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
							{
								goto IL_0270;
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
				goto IL_0270;
			}
			throw new NullReferenceException();
			IL_0270:
			List<WeaponType> list = playerOptionsData._003CCollectedWeapons_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ r10_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				bool flag = (nint)obj7 == -1;
				obj = obj2;
				if (!flag)
				{
					num3++;
					obj = obj2;
				}
			}
		}
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v45+1C]");
			if (obj3 == null)
			{
				AdventureManager adventures2 = _adventures;
				AdventureData adventureData2 = adventures2._003CAdventureData_003Ek__BackingField;
				List<WeaponType> list2 = adventureData2._003CWeaponTypes_003Ek__BackingField;
				object obj8 = default(object);
				string newValue3 = System.Number.FormatInt32(num3, (ReadOnlySpan<char>)(&obj8), null);
				string text3 = translation2.Replace("%0", newValue3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				newValue2 = System.Number.FormatInt32(0, (ReadOnlySpan<char>)(&obj8), null);
				text2 = text3;
				goto IL_03ae;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			obj = 0;
		}
		throw new NullReferenceException();
		IL_03ae:
		string text4 = text2.Replace("%1", newValue2);
		component.text = text4;
	}

	private void SortByDefault()
	{
		//IL_00b8: Expected O, but got I
		//IL_03c8: Expected O, but got I
		//IL_0115: Expected O, but got I
		//IL_01df: Expected O, but got I
		//IL_018b: Expected O, but got I
		//IL_0533: Expected O, but got I4
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Expected O, but got Unknown
		//IL_0580: Expected I4, but got O
		//IL_04fe->IL0358: Incompatible stack heights: 1 vs 0
		//IL_054b->IL0358: Incompatible stack heights: 2 vs 0
		//IL_0585->IL042f: Incompatible stack heights: 3 vs 0
		ClearStructures();
		AddGrid();
		List<CollectionItemUI> defaultSortOrder = _defaultSortOrder;
		bool flag = _defaultSortOrder == null;
		int num = 0;
		Component component = null;
		object obj = null;
		int num2 = 0;
		if (!flag)
		{
			while (true)
			{
				if (num2 < defaultSortOrder._size)
				{
					List<CollectionItemUI> defaultSortOrder2 = _defaultSortOrder;
					if (_defaultSortOrder == null)
					{
						break;
					}
					if (num < defaultSortOrder2._size)
					{
						Component items = (Component)(object)defaultSortOrder2._items;
						if (defaultSortOrder2._items == null)
						{
							break;
						}
						int num3 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rbx_v15 (UnityEngine.Component)+18]");
						if ((nint)num3 < (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rbx_v15 (UnityEngine.Component)+20+v77 @ rsi_v9 (System.Int32)*8]");
							Component component2 = (Component)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rbx_v15 (UnityEngine.Component)+20+v77 @ rsi_v9 (System.Int32)*8]");
							if ((nint)0 == 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbx_v16 (UnityEngine.Component)+E0]");
							if ((nint)0 == 75)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rbx_v15 (UnityEngine.Component)+20+v77 @ rsi_v9 (System.Int32)*8]");
								obj = 0;
							}
							if (_hasDarkasso && ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbx_v16 (UnityEngine.Component)+F0]");
								if ((nint)0 > (nint)22)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rbx_v15 (UnityEngine.Component)+20+v77 @ rsi_v9 (System.Int32)*8]");
									component = (Component)0;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rbx_v15 (UnityEngine.Component)+20+v77 @ rsi_v9 (System.Int32)*8]");
							Transform transform = ((Component)0).transform;
							if ((object)transform == null)
							{
								break;
							}
							Transform transform2 = transform.transform;
							if ((object)transform2 == null)
							{
								break;
							}
							transform2.SetParent(_activeContentGrid, worldPositionStays: true);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rbx_v15 (UnityEngine.Component)+20+v77 @ rsi_v9 (System.Int32)*8]");
							Transform transform3 = ((Component)0).transform;
							if ((object)transform3 == null)
							{
								break;
							}
							transform3.SetSiblingIndex(num);
							defaultSortOrder = _defaultSortOrder;
							num++;
							if (_defaultSortOrder == null)
							{
								break;
							}
							num2 = num;
							continue;
						}
					}
					else
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					}
					throw new IndexOutOfRangeException();
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rbp_v11 (System.Object)+10]");
					if ((nint)0 != 0 && (object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rbp_v11 (System.Object)+10]");
						if ((nint)0 == 0)
						{
							UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(obj);
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rbp_v11 (System.Object)+10]");
						IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
						Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
						bool flag2 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
						IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)component).m_CachedPtr);
						Transform transform5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
						if ((object)transform5 == null)
						{
							break;
						}
						bool flag3 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
						object obj2 = Transform.GetSiblingIndex_Injected(((UnityEngine.Object)transform5).m_CachedPtr);
						if ((object)transform4 == null)
						{
							break;
						}
						Component component3 = (Component)(obj2 - 1);
						bool flag4 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
						Transform.SetSiblingIndex_Injected(((UnityEngine.Object)transform4).m_CachedPtr, (int)component3);
					}
				}
				shouldForceLayoutUpdate = true;
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void SortByType()
	{
		//IL_09e8: Expected O, but got I4
		//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d8: Expected O, but got Unknown
		//IL_0a3b: Expected I4, but got O
		//IL_08c5: Expected O, but got I4
		//IL_03cd: Expected O, but got I4
		//IL_0462: Expected O, but got I4
		//IL_008c->IL04e2: Incompatible stack heights: 1 vs 0
		//IL_04a7->IL04e2: Incompatible stack heights: 1 vs 0
		//IL_028d->IL04e2: Incompatible stack heights: 2 vs 0
		//IL_02e1->IL04e2: Incompatible stack heights: 3 vs 0
		//IL_0953->IL04e2: Incompatible stack heights: 2 vs 0
		//IL_07f2->IL04e2: Incompatible stack heights: 4 vs 0
		//IL_09b3->IL04e2: Incompatible stack heights: 3 vs 0
		//IL_034e->IL04e2: Incompatible stack heights: 5 vs 0
		//IL_03a2->IL04e2: Incompatible stack heights: 6 vs 0
		//IL_0a00->IL04e2: Incompatible stack heights: 4 vs 0
		//IL_0852->IL04e2: Incompatible stack heights: 7 vs 0
		//IL_0a40->IL08ec: Incompatible stack heights: 5 vs 1
		//IL_08ca->IL0a6a: Incompatible stack heights: 8 vs 1
		//IL_03e5->IL04e2: Incompatible stack heights: 8 vs 0
		ClearStructures();
		AddGrid();
		if ((object)_content != null)
		{
			CollectionItemUI[] componentsInChildren = _content.GetComponentsInChildren<CollectionItemUI>();
			bool flag = componentsInChildren == null;
			List<object> source = new List<object>(componentsInChildren);
			List<CollectionItemUI> list = new List<CollectionItemUI>();
			Func<CollectionItemUI, bool> predicate = _003C_003Ec._003C_003E9__44_0;
			if (_003C_003Ec._003C_003E9__44_0 == null)
			{
				predicate = (_003C_003Ec._003C_003E9__44_0 = delegate(CollectionItemUI x)
				{
					//IL_00ad: Expected I4, but got O
					if ((object)x != null)
					{
						if (x._weaponType != WeaponType.VOID)
						{
							WeaponData weaponData = x._weaponData;
							if (x._weaponData == null)
							{
								goto IL_009f;
							}
							if (!weaponData._003CisPowerUp_003Ek__BackingField)
							{
								return true;
							}
						}
						return false;
					}
					goto IL_009f;
					IL_009f:
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				});
			}
			IEnumerable<CollectionItemUI> collection = Enumerable.Where((IEnumerable<CollectionItemUI>)source, predicate);
			if (list != null)
			{
				((List<object>)(object)list).InsertRange(list._size, (IEnumerable<object>)collection);
				Func<CollectionItemUI, bool> predicate2 = _003C_003Ec._003C_003E9__44_1;
				if (_003C_003Ec._003C_003E9__44_1 == null)
				{
					predicate2 = (_003C_003Ec._003C_003E9__44_1 = delegate(CollectionItemUI x)
					{
						//IL_00aa: Expected I4, but got O
						if ((object)x != null)
						{
							if (x._weaponType != WeaponType.VOID)
							{
								WeaponData weaponData = x._weaponData;
								if (x._weaponData == null)
								{
									goto IL_009c;
								}
								if (weaponData._003CisPowerUp_003Ek__BackingField)
								{
									return true;
								}
							}
							return false;
						}
						goto IL_009c;
						IL_009c:
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					});
				}
				((List<object>)(object)list).InsertRange(collection: (IEnumerable<object>)Enumerable.Where((IEnumerable<CollectionItemUI>)source, predicate2), index: list._size);
				Func<CollectionItemUI, bool> predicate3 = _003C_003Ec._003C_003E9__44_2;
				if (_003C_003Ec._003C_003E9__44_2 == null)
				{
					predicate3 = (_003C_003Ec._003C_003E9__44_2 = delegate(CollectionItemUI x)
					{
						//IL_0074: Expected I4, but got O
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						return (x._itemType != ItemType.VOID && !x.IsRelic()) ? true : false;
					});
				}
				((List<object>)(object)list).InsertRange(collection: (IEnumerable<object>)Enumerable.Where((IEnumerable<CollectionItemUI>)source, predicate3), index: list._size);
				Func<CollectionItemUI, bool> predicate4 = _003C_003Ec._003C_003E9__44_3;
				if (_003C_003Ec._003C_003E9__44_3 == null)
				{
					predicate4 = (_003C_003Ec._003C_003E9__44_3 = delegate(CollectionItemUI x)
					{
						//IL_003d: Expected I4, but got O
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						return x.IsRelic();
					});
				}
				IEnumerable<CollectionItemUI> source2 = Enumerable.Where((IEnumerable<CollectionItemUI>)source, predicate4);
				Func<CollectionItemUI, string> keySelector = _003C_003Ec._003C_003E9__44_4;
				if (_003C_003Ec._003C_003E9__44_4 == null)
				{
					keySelector = (_003C_003Ec._003C_003E9__44_4 = delegate(CollectionItemUI x)
					{
						if ((object)x != null)
						{
							ItemData itemData = x._itemData;
							if (x._itemData != null)
							{
								return itemData._003CcollectionFrame_003Ek__BackingField;
							}
						}
						return (string)(object)new NullReferenceException();
					});
				}
				IOrderedEnumerable<CollectionItemUI> orderedEnumerable = Enumerable.OrderBy(source2, keySelector);
				((List<object>)(object)list).InsertRange(list._size, (IEnumerable<object>)orderedEnumerable);
				Func<CollectionItemUI, bool> predicate5 = _003C_003Ec._003C_003E9__44_5;
				if (_003C_003Ec._003C_003E9__44_5 == null)
				{
					predicate5 = (_003C_003Ec._003C_003E9__44_5 = delegate(CollectionItemUI x)
					{
						//IL_0052: Expected I4, but got O
						//IL_0030: Expected O, but got I4
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						object obj9 = x._itemType - 24;
						return obj9 == null;
					});
				}
				CollectionItemUI item = Enumerable.First(orderedEnumerable, predicate5);
				bool flag2 = ((List<object>)(object)list).Remove((object)item);
				bool flag3 = list.Remove(item);
				object obj;
				if (!_hasDarkasso)
				{
					obj = null;
				}
				else
				{
					Func<CollectionItemUI, bool> predicate6 = _003C_003Ec._003C_003E9__44_6;
					if (_003C_003Ec._003C_003E9__44_6 == null)
					{
						predicate6 = (_003C_003Ec._003C_003E9__44_6 = delegate(CollectionItemUI x)
						{
							//IL_0052: Expected I4, but got O
							//IL_0030: Expected O, but got I4
							if ((object)x == null)
							{
								NullReferenceException ex = new NullReferenceException();
								return (byte)(int)ex != 0;
							}
							object obj9 = x._itemType - 75;
							return obj9 == null;
						});
					}
					CollectionItemUI collectionItemUI = Enumerable.First(orderedEnumerable, predicate6);
					obj = collectionItemUI;
				}
				Func<CollectionItemUI, bool> predicate7 = _003C_003Ec._003C_003E9__44_7;
				if (_003C_003Ec._003C_003E9__44_7 == null)
				{
					predicate7 = (_003C_003Ec._003C_003E9__44_7 = delegate(CollectionItemUI x)
					{
						//IL_005d: Expected I4, but got O
						//IL_0030: Expected O, but got I4
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						object obj9 = x._arcanaType - -1;
						bool flag15 = obj9 == null;
						return !flag15;
					});
				}
				((List<object>)(object)list).InsertRange(collection: (IEnumerable<object>)Enumerable.Where((IEnumerable<CollectionItemUI>)source, predicate7), index: list._size);
				object obj2 = null;
				int num = 0;
				object obj3 = null;
				object obj5 = default(object);
				object obj6 = default(object);
				while (true)
				{
					if ((nint)obj3 < list._size)
					{
						bool flag4 = num >= list._size;
						CollectionItemUI[] items = list._items;
						if (list._items == null)
						{
							break;
						}
						bool flag5 = num >= items.Length;
						object obj4 = items[num];
						if ((object)items[num] == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdi_v39 (System.Object)+10]");
						bool flag6 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdi_v39 (System.Object)+10]");
						IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
						Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
						if ((object)transform == null)
						{
							break;
						}
						transform.SetParent(_activeContentGrid, worldPositionStays: true);
						bool flag7 = num >= list._size;
						CollectionItemUI[] items2 = list._items;
						if (list._items == null)
						{
							break;
						}
						bool flag8 = num >= items2.Length;
						Func<CollectionItemUI, bool> func = (Func<CollectionItemUI, bool>)(object)items2[num];
						if ((object)items2[num] == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rdi_v40 (System.Func`2<VampireSurvivors.UI.CollectionItemUI, System.Boolean>)+10]");
						bool flag9 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rdi_v40 (System.Func`2<VampireSurvivors.UI.CollectionItemUI, System.Boolean>)+10]");
						IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
						Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
						if ((object)transform2 == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v136 (UnityEngine.Transform)+10]");
						bool flag10 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v136 (UnityEngine.Transform)+10]");
						Transform.SetSiblingIndex_Injected((IntPtr)0, num);
						if (_hasDarkasso)
						{
							list.InsertRange(num, (IEnumerable<CollectionItemUI>)1);
							if (obj5 == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rax_v143+F0]");
							if ((nint)0 > (nint)22)
							{
								if (obj2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2213 @ r14_v22 (System.Object)+10]");
									if ((nint)0 != 0)
									{
										goto IL_08ad;
									}
								}
								list.InsertRange(num, (IEnumerable<CollectionItemUI>)1);
								obj2 = obj6;
							}
						}
						goto IL_08ad;
					}
					if (_hasDarkasso)
					{
						if (obj == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r12_v20 (System.Object)+10]");
						bool flag11 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r12_v20 (System.Object)+10]");
						IntPtr gcHandlePtr3 = Component.get_transform_Injected((IntPtr)0);
						Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
						if (obj2 == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2213 @ r14_v22 (System.Object)+10]");
						bool flag12 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2213 @ r14_v22 (System.Object)+10]");
						IntPtr gcHandlePtr4 = Component.get_transform_Injected((IntPtr)0);
						Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr4);
						if ((object)transform4 == null)
						{
							break;
						}
						bool flag13 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
						object obj7 = Transform.GetSiblingIndex_Injected(((UnityEngine.Object)transform4).m_CachedPtr);
						if ((object)transform3 == null)
						{
							break;
						}
						object obj8 = obj7 - 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v100 (UnityEngine.Transform)+10]");
						bool flag14 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v100 (UnityEngine.Transform)+10]");
						Transform.SetSiblingIndex_Injected((IntPtr)0, (int)obj8);
					}
					shouldForceLayoutUpdate = true;
					return;
					IL_08ad:
					num++;
					obj3 = num;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void SortByVersion()
	{
		//IL_00ea: Expected O, but got Ref
		//IL_0137: Expected I, but got O
		//IL_01be: Expected O, but got I4
		//IL_016f: Expected O, but got I
		//IL_01f8: Expected O, but got I
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Expected O, but got Unknown
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Expected O, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected O, but got Unknown
		//IL_032a: Expected O, but got Ref
		//IL_0337: Expected I, but got O
		//IL_03be: Expected O, but got I4
		//IL_036f: Expected O, but got I
		//IL_04ad: Expected O, but got I
		//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bb: Expected O, but got Unknown
		//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c8: Expected O, but got Unknown
		//IL_03ec: Expected I, but got O
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Expected O, but got Unknown
		//IL_0473: Expected O, but got I4
		//IL_0424: Expected O, but got I
		//IL_06ad: Expected O, but got I
		//IL_06bd: Expected O, but got I
		//IL_04f0: Expected O, but got I
		//IL_04f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Expected O, but got Unknown
		//IL_0506: Unknown result type (might be due to invalid IL or missing references)
		//IL_050b: Expected O, but got Unknown
		//IL_06cf: Expected I4, but got O
		//IL_0688: Expected O, but got I
		//IL_0698: Expected O, but got I
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Expected O, but got Unknown
		//IL_06ee: Expected I4, but got O
		//IL_0727: Expected O, but got I4
		//IL_0864: Expected O, but got I
		//IL_00d3->IL08fd: Incompatible stack heights: 1 vs 0
		//IL_0582->IL08fd: Incompatible stack heights: 2 vs 0
		//IL_023a->IL0a4a: Incompatible stack heights: 6 vs 1
		//IL_0313->IL08fd: Incompatible stack heights: 2 vs 0
		//IL_05a4->IL08fd: Incompatible stack heights: 2 vs 0
		//IL_0c21->IL08fd: Incompatible stack heights: 2 vs 0
		//IL_060a->IL0bd9: Incompatible stack heights: 4 vs 2
		//IL_055b->IL0a93: Incompatible stack heights: 3 vs 2
		//IL_0c7d->IL08fd: Incompatible stack heights: 2 vs 0
		//IL_06dc->IL0c3f: Incompatible stack heights: 3 vs 2
		//IL_0529->IL0bbb: Incompatible stack heights: 7 vs 2
		//IL_07f2->IL0c82: Incompatible stack heights: 3 vs 2
		//IL_07a6->IL0c3f: Incompatible stack heights: 5 vs 2
		//IL_08f8->IL0c82: Incompatible stack heights: 7 vs 2
		//IL_0cce->IL08b6: Incompatible stack heights: 7 vs 6
		ClearStructures();
		if ((object)_content != null)
		{
			CollectionItemUI[] componentsInChildren = _content.GetComponentsInChildren<CollectionItemUI>();
			bool flag = componentsInChildren == null;
			List<object> list = new List<object>(componentsInChildren);
			List<CollectionItemUI> list2 = new List<CollectionItemUI>();
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation("lang/menu_CollectionVersion", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			AddHeader(translation);
			AddGrid();
			Func<CollectionItemUI, bool> predicate = _003C_003Ec._003C_003E9__45_0;
			bool flag2 = _003C_003Ec._003C_003E9__45_0 != null;
			bool flag3 = true;
			if (!flag2)
			{
				predicate = (_003C_003Ec._003C_003E9__45_0 = delegate(CollectionItemUI x)
				{
					//IL_00c7: Expected I4, but got O
					if ((object)x == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					if (x._weaponData == null)
					{
						if (x._itemData == null)
						{
							return true;
						}
						ItemData itemData = x._itemData;
						return itemData._003CcontentGroup_003Ek__BackingField == ContentGroupType.BASE;
					}
					WeaponData weaponData = x._weaponData;
					return weaponData._003CcontentGroup_003Ek__BackingField == ContentGroupType.BASE;
				});
				flag3 = false;
			}
			IEnumerable<CollectionItemUI> enumerable = Enumerable.Where((IEnumerable<CollectionItemUI>)list, predicate);
			if (enumerable != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj2 = default(object);
				object obj = (object)(&obj2);
				object obj3 = default(object);
				object obj10 = default(object);
				object obj11 = default(object);
				while (true)
				{
					bool flag4 = obj2 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					if (obj3 == null)
					{
						break;
					}
					bool flag5 = obj2 == null;
					nint num = (nint)obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ r10_v33 (Il2CppClass<System.Object>)+12E]");
					object obj4;
					object obj9;
					if ((nint)0 < (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ r10_v33 (Il2CppClass<System.Object>)+B0]");
						obj4 = 0;
						Func<CollectionItemUI, bool> func = null;
						while (true)
						{
							object obj5 = func + func;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ r8_v93+v2076 @ rax_v255*8]");
							if (0 == (nint)typeof(IEnumerator<CollectionItemUI>))
							{
								break;
							}
							func = (Func<CollectionItemUI, bool>)(func + 1);
							Func<CollectionItemUI, bool> func2 = func;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ r10_v33 (Il2CppClass<System.Object>)+12E]");
							if ((nint)func2 < 0)
							{
								continue;
							}
							goto IL_01ab;
						}
						object obj6 = func + func;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ r8_v93+8+v2250 @ rcx_v186*8]");
						object obj7 = (nint)0 << 4;
						object obj8 = obj7 + 312;
						obj9 = obj8 + num;
						goto IL_0a27;
					}
					goto IL_01ab;
					IL_01ab:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
					obj4 = 0;
					obj9 = obj10;
					goto IL_0a27;
					IL_0a27:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2255 @ rdx_v115] (should have been resolved before IL gen)");
					bool flag6 = obj11 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v731 @ rax_v241 (System.Object)+10]");
					bool flag7 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v731 @ rax_v241 (System.Object)+10]");
					IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
					Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					bool flag8 = (object)transform == null;
					transform.SetParent(_activeContentGrid, worldPositionStays: true);
					flag3 = false;
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				Func<CollectionItemUI, bool> predicate2 = _003C_003Ec._003C_003E9__45_1;
				if (_003C_003Ec._003C_003E9__45_1 == null)
				{
					predicate2 = (_003C_003Ec._003C_003E9__45_1 = delegate(CollectionItemUI x)
					{
						//IL_013c: Expected I4, but got O
						//IL_011a: Expected O, but got I4
						//IL_00e6: Expected O, but got I4
						//IL_00b2: Expected O, but got I4
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						if (x._weaponData == null)
						{
							if (x._itemData == null)
							{
								if (x._arcanaData == null)
								{
									return false;
								}
								ArcanaData arcanaData = x._arcanaData;
								object obj35 = arcanaData._003CcontentGroup_003Ek__BackingField - 1;
								return obj35 == null;
							}
							ItemData itemData = x._itemData;
							object obj36 = itemData._003CcontentGroup_003Ek__BackingField - 1;
							return obj36 == null;
						}
						WeaponData weaponData = x._weaponData;
						object obj37 = weaponData._003CcontentGroup_003Ek__BackingField - 1;
						return obj37 == null;
					});
				}
				IEnumerable<CollectionItemUI> enumerable2 = Enumerable.Where((IEnumerable<CollectionItemUI>)list, predicate2);
				int num2 = Enumerable.Count(enumerable2);
				if (num2 > 0)
				{
					string translation2 = LocalizationManager.GetTranslation("lang/menu_CollectionExtra", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
					AddHeader(translation2);
					AddGrid();
					if (enumerable2 == null)
					{
						goto IL_08fd;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					Func<CollectionItemUI, bool> func3 = default(Func<CollectionItemUI, bool>);
					object obj12 = (object)(&func3);
					object obj19 = default(object);
					object obj26 = default(object);
					object obj27 = default(object);
					object obj28 = default(object);
					while (true)
					{
						bool flag9 = func3 == null;
						nint num3 = (nint)func3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1385 @ r10_v31 (Il2CppClass<System.Func`2<VampireSurvivors.UI.CollectionItemUI, System.Boolean>>)+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_03ab;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1385 @ r10_v31 (Il2CppClass<System.Func`2<VampireSurvivors.UI.CollectionItemUI, System.Boolean>>)+B0]");
						object obj13 = 0;
						Func<CollectionItemUI, bool> func4 = null;
						while (true)
						{
							object obj14 = func4 + func4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1401 @ r8_v78+v3069 @ rax_v219*8]");
							if (0 == (nint)typeof(IEnumerator))
							{
								break;
							}
							func4 = (Func<CollectionItemUI, bool>)(func4 + 1);
							Func<CollectionItemUI, bool> func5 = func4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1385 @ r10_v31 (Il2CppClass<System.Func`2<VampireSurvivors.UI.CollectionItemUI, System.Boolean>>)+12E]");
							if ((nint)func5 < 0)
							{
								continue;
							}
							goto IL_03ab;
						}
						object obj15 = func4 + func4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1401 @ r8_v78+8+v3141 @ rcx_v156*8]");
						object obj16 = (nint)0 << 4;
						object obj17 = obj16 + 312;
						object obj18 = obj17 + num3;
						goto IL_0b71;
						IL_0b71:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3146 @ rdx_v91] (should have been resolved before IL gen)");
						if (obj19 == null)
						{
							break;
						}
						bool flag10 = func3 == null;
						nint num4 = (nint)func3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1051 @ r10_v32 (Il2CppClass<System.Func`2<VampireSurvivors.UI.CollectionItemUI, System.Boolean>>)+12E]");
						object obj20;
						object obj25;
						if ((nint)0 < (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1051 @ r10_v32 (Il2CppClass<System.Func`2<VampireSurvivors.UI.CollectionItemUI, System.Boolean>>)+B0]");
							obj20 = 0;
							Func<CollectionItemUI, bool> func6 = null;
							while (true)
							{
								object obj21 = func6 + func6;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1070 @ r8_v81+v3196 @ rax_v214*8]");
								if (0 == (nint)typeof(IEnumerator<CollectionItemUI>))
								{
									break;
								}
								func6 = (Func<CollectionItemUI, bool>)(func6 + 1);
								Func<CollectionItemUI, bool> func7 = func6;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1051 @ r10_v32 (Il2CppClass<System.Func`2<VampireSurvivors.UI.CollectionItemUI, System.Boolean>>)+12E]");
								if ((nint)func7 < 0)
								{
									continue;
								}
								goto IL_0460;
							}
							object obj22 = func6 + func6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1070 @ r8_v81+8+v3307 @ rcx_v150*8]");
							object obj23 = (nint)0 << 4;
							object obj24 = obj23 + 312;
							obj25 = obj24 + num4;
							goto IL_0b98;
						}
						goto IL_0460;
						IL_0460:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
						obj20 = 0;
						obj25 = obj26;
						goto IL_0b98;
						IL_0b98:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3312 @ rdx_v96] (should have been resolved before IL gen)");
						bool flag11 = obj27 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1320 @ rax_v200 (System.Object)+10]");
						bool flag12 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1320 @ rax_v200 (System.Object)+10]");
						IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
						Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
						bool flag13 = (object)transform2 == null;
						transform2.SetParent(_activeContentGrid, worldPositionStays: true);
						continue;
						IL_03ab:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
						obj13 = 0;
						obj18 = obj28;
						goto IL_0b71;
					}
					if (obj12 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					}
				}
				Dictionary<ContentGroupType, DlcType> dictionary = new Dictionary<ContentGroupType, DlcType>();
				DlcCatalog dlcCatalog = DlcSystem._dlcCatalog;
				if ((object)DlcSystem._dlcCatalog != null && dlcCatalog._DlcData != null)
				{
					Dictionary<DlcType, DlcData>.Enumerator enumerator = default(Dictionary<DlcType, DlcData>.Enumerator);
					object obj29 = default(object);
					while (enumerator.MoveNext())
					{
						bool flag14 = obj29 == null;
						bool flag15 = dictionary == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3137 @ stack_-B8+38]");
						bool flag16 = ((Dictionary<System.Int32Enum, System.Int32Enum>)(object)dictionary).TryInsert((System.Int32Enum)0, (System.Int32Enum)0, System.Collections.Generic.InsertionBehavior.None);
					}
					Dictionary<DlcType, List<CollectionItemUI>> dictionary2 = new Dictionary<DlcType, List<CollectionItemUI>>();
					if (list != null)
					{
						List<CollectionItemUI>.Enumerator enumerator2 = default(List<CollectionItemUI>.Enumerator);
						while (enumerator2.MoveNext())
						{
							DlcType dlcType = DlcType.Moonspell;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1799 @ rbx_v37 (VampireSurvivors.Data.DlcType)+C0]");
							Func<CollectionItemUI, bool> func8;
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1799 @ rbx_v37 (VampireSurvivors.Data.DlcType)+D8]");
								if ((nint)0 == 0)
								{
									func8 = null;
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1799 @ rbx_v37 (VampireSurvivors.Data.DlcType)+D8]");
									object obj30 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3456 @ rax_v166+84]");
									func8 = (Func<CollectionItemUI, bool>)0;
								}
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1799 @ rbx_v37 (VampireSurvivors.Data.DlcType)+C0]");
								object obj31 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3439 @ rax_v165+1A0]");
								func8 = (Func<CollectionItemUI, bool>)0;
							}
							bool flag17 = dictionary == null;
							int num5 = dictionary.FindEntry((ContentGroupType)func8);
							if (!flag17)
							{
								DlcType key = dictionary.get_Item((ContentGroupType)func8);
								bool flag18 = dictionary2 == null;
								int num6 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).FindEntry((System.Int32Enum)key);
								object obj32 = !flag18;
								if (obj32 == null)
								{
									List<CollectionItemUI> value = new List<CollectionItemUI>();
									bool flag19 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)key, (object)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
								}
								object obj33 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).get_Item((System.Int32Enum)key);
								bool flag20 = obj33 == null;
								List<CollectionItemUI> list3 = ((Dictionary<DlcType, List<CollectionItemUI>>)obj33).get_Item(DlcType.Moonspell);
							}
						}
						if (dictionary2 != null)
						{
							Dictionary<DlcType, List<CollectionItemUI>>.Enumerator enumerator3 = default(Dictionary<DlcType, List<CollectionItemUI>>.Enumerator);
							List<CollectionItemUI>.Enumerator enumerator4 = default(List<CollectionItemUI>.Enumerator);
							while (enumerator3.MoveNext())
							{
								Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
								bool flag21 = loadedDlc == null;
								int num7 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc).FindEntry((System.Int32Enum)0);
								if (!flag21)
								{
									int num8 = ((Dictionary<DlcType, BundleManifestData>)(object)typeof(DlcSystem)).FindEntry(DlcType.Moonspell);
									bool flag22 = num8 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2733 @ rax_v126 (System.Int32)+18]");
									bool flag23 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2733 @ rax_v126 (System.Int32)+18]");
									object obj34 = ((Dictionary<System.Int32Enum, object>)0).get_Item((System.Int32Enum)0);
									bool flag24 = obj34 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2623 @ rax_v127 (System.Object)+38]");
									string localizedName = ContentGroupMethods.GetLocalizedName(ContentGroupType.BASE);
									AddHeader(localizedName);
									AddGrid();
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
									do
									{
										Transform transform3 = ((Component)null).transform;
										bool flag25 = (object)transform3 == null;
										transform3.SetParent(_activeContentGrid, worldPositionStays: true);
									}
									while (enumerator4.MoveNext());
								}
							}
							shouldForceLayoutUpdate = true;
							return;
						}
					}
				}
			}
		}
		goto IL_08fd;
		IL_08fd:
		throw new NullReferenceException();
	}

	private ContentGroupType GetContentGroup(CollectionItemUI item)
	{
		//IL_00a9: Expected I4, but got O
		if ((object)item != null)
		{
			if (item._weaponData == null)
			{
				if (item._itemData == null)
				{
					return ContentGroupType.BASE;
				}
				ItemData itemData = item._itemData;
				return itemData._003CcontentGroup_003Ek__BackingField;
			}
			WeaponData weaponData = item._weaponData;
			return weaponData._003CcontentGroup_003Ek__BackingField;
		}
		NullReferenceException ex = new NullReferenceException();
		return (ContentGroupType)ex;
	}

	private void ClearStructures()
	{
		//IL_002c: Expected O, but got I4
		//IL_0036: Expected O, but got I4
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_0093->IL018a: Incompatible stack heights: 1 vs 0
		//IL_0205->IL018a: Incompatible stack heights: 2 vs 0
		//IL_00d2->IL020a: Incompatible stack heights: 2 vs 0
		if ((object)_content != null)
		{
			CollectionItemUI[] componentsInChildren = _content.GetComponentsInChildren<CollectionItemUI>();
			bool flag = componentsInChildren == null;
			object obj = 0;
			object obj2 = 0;
			if (!flag)
			{
				List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
				while (true)
				{
					if ((nint)obj2 < componentsInChildren.Length)
					{
						bool flag2 = (nint)obj >= componentsInChildren.Length;
						CollectionItemUI collectionItemUI = componentsInChildren[obj];
						if ((object)componentsInChildren[obj] == null)
						{
							break;
						}
						bool flag3 = ((UnityEngine.Object)collectionItemUI).m_CachedPtr == (IntPtr)0;
						IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)collectionItemUI).m_CachedPtr);
						Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
						if ((object)transform == null)
						{
							break;
						}
						transform.SetParent(_content, worldPositionStays: true);
						obj++;
						obj2 = obj;
						continue;
					}
					if (_structuralSpawned == null)
					{
						break;
					}
					while (enumerator.MoveNext())
					{
						UnityEngine.Object.Destroy(null, 0f);
					}
					List<GameObject> structuralSpawned = _structuralSpawned;
					if (_structuralSpawned == null)
					{
						break;
					}
					int version = structuralSpawned._version + 1;
					structuralSpawned._version = version;
					structuralSpawned._size = 0;
					if (structuralSpawned._size > 0)
					{
						Array.Clear(structuralSpawned._items, 0, structuralSpawned._size);
					}
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void SortByAdventure()
	{
		//IL_017c: Expected O, but got I4
		//IL_09d9: Expected O, but got Ref
		//IL_0199: Expected O, but got Ref
		//IL_0897: Expected O, but got I4
		//IL_01df: Expected O, but got I
		//IL_0a2f: Expected O, but got Ref
		//IL_0380: Expected O, but got Ref
		//IL_023c: Expected O, but got I
		//IL_0a7a: Expected O, but got Ref
		//IL_0271: Expected O, but got I
		//IL_02a4: Expected O, but got I4
		//IL_02ac: Expected O, but got Ref
		//IL_07b3: Expected O, but got I4
		//IL_07b3: Expected I4, but got O
		//IL_06e5: Expected O, but got I4
		//IL_06e5: Expected I4, but got O
		//IL_0128->IL0842: Incompatible stack heights: 1 vs 0
		//IL_015f->IL0842: Incompatible stack heights: 1 vs 0
		//IL_09e2->IL0842: Incompatible stack heights: 1 vs 0
		//IL_0a38->IL0842: Incompatible stack heights: 1 vs 0
		//IL_0a83->IL0842: Incompatible stack heights: 1 vs 0
		//IL_083d->IL0ba5: Incompatible stack heights: 3 vs 1
		//IL_077c->IL0b08: Incompatible stack heights: 3 vs 1
		Debug.Log("Sorting by adventure");
		ClearStructures();
		Component content = _content;
		List<object> list;
		bool flag2 = default(bool);
		GameObject gameObject = default(GameObject);
		string text = default(string);
		bool flag3 = default(bool);
		string text2;
		if ((object)_content != null)
		{
			CollectionItemUI[] componentsInChildren = _content.GetComponentsInChildren<CollectionItemUI>();
			bool flag = componentsInChildren == null;
			list = new List<object>(componentsInChildren);
			string translation = LocalizationManager.GetTranslation("adventureLang/adv_adventureCollection_available", FixForRTL: true, 0, ignoreRTLnumbers: true, flag2, gameObject, text, flag3);
			AddHeader(translation);
			AddGrid();
			List<CollectionItemUI> list2 = new List<CollectionItemUI>();
			List<CollectionItemUI> list3 = new List<CollectionItemUI>();
			List<WeaponType> list4 = new List<WeaponType>();
			DataManager data = _data;
			bool flag4 = _data == null;
			content = (Component)(object)list4;
			if (!flag4)
			{
				Dictionary<StageType, List<StageData>> adventureStageData = data._adventureStageData;
				bool flag5 = data._adventureStageData == null;
				content = (Component)(object)list4;
				if (!flag5)
				{
					bool flag6 = false;
					List<WeaponType>.Enumerator enumerator = (List<WeaponType>.Enumerator)0;
					Dictionary<StageType, List<StageData>>.Enumerator enumerator2 = default(Dictionary<StageType, List<StageData>>.Enumerator);
					object obj = default(object);
					List<VampireSurvivors.App.Data.CustomMerchantData>.Enumerator enumerator4 = default(List<VampireSurvivors.App.Data.CustomMerchantData>.Enumerator);
					while (enumerator2.MoveNext())
					{
						bool flag7 = obj == null;
						Dictionary<StageType, List<StageData>>.Enumerator enumerator3 = (Dictionary<StageType, List<StageData>>.Enumerator)(&enumerator2);
						if (!flag7)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1982 @ stack_-70+18]");
							if ((nint)0 > (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1982 @ stack_-70+10]");
								content = (Component)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1982 @ stack_-70+10]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rcx_v14 (UnityEngine.Component)+18]");
									if ((nint)0 > (nint)0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rcx_v14 (UnityEngine.Component)+20]");
										object obj2 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rcx_v14 (UnityEngine.Component)+20]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v996 @ r9_v46+1B8]");
											adventureStageData = (Dictionary<StageType, List<StageData>>)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v996 @ r9_v46+1B8]");
											if ((nint)0 == 0)
											{
												throw new NullReferenceException();
											}
											if (enumerator4.MoveNext())
											{
												object obj3 = 0;
												List<WeaponType>.Enumerator enumerator5 = (List<WeaponType>.Enumerator)(&enumerator4);
												throw new NullReferenceException();
											}
											continue;
										}
										throw new NullReferenceException();
									}
									throw new IndexOutOfRangeException();
								}
								throw new NullReferenceException();
							}
							System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
							enumerator3 = (Dictionary<StageType, List<StageData>>.Enumerator)0;
						}
						throw new NullReferenceException();
					}
					bool flag8 = list == null;
					content = (Component)(&enumerator2);
					if (!flag8)
					{
						List<CollectionItemUI>.Enumerator enumerator6 = default(List<CollectionItemUI>.Enumerator);
						if (enumerator6.MoveNext())
						{
							Component component = null;
							List<CollectionItemUI>.Enumerator enumerator7 = (List<CollectionItemUI>.Enumerator)(&enumerator6);
							throw new NullReferenceException();
						}
						bool flag9 = list2 == null;
						content = (Component)(&enumerator6);
						if (!flag9)
						{
							List<CollectionItemUI>.Enumerator enumerator8 = default(List<CollectionItemUI>.Enumerator);
							while (enumerator8.MoveNext())
							{
								bool flag10 = list.Remove(null);
							}
							bool flag11 = list3 == null;
							content = (Component)(&enumerator8);
							if (!flag11)
							{
								if (list3._size > 0)
								{
									bool flag12 = LocalizationManager.TryGetTranslation("adventureLang/adv_adventureCollection_merchantpurchase", out var Translation, FixForRTL: true, 0, flag2, (byte)(int)gameObject != 0, (GameObject)(object)text, (string)flag3);
									if (Translation != null)
									{
										bool flag13 = Translation._stringLength > 0;
										text2 = Translation;
										if (flag13)
										{
											goto IL_0a97;
										}
									}
									text2 = "adventureLang/adv_adventureCollection_merchantpurchase";
									goto IL_0a97;
								}
								goto IL_0786;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0786:
		bool flag14 = LocalizationManager.TryGetTranslation("adventureLang/adv_adventureCollection_baseGame", out var Translation2, FixForRTL: true, 0, flag2, (byte)(int)gameObject != 0, (GameObject)(object)text, (string)flag3);
		string text3;
		if (Translation2 != null)
		{
			bool flag15 = Translation2._stringLength > 0;
			text3 = Translation2;
			if (flag15)
			{
				goto IL_0b33;
			}
		}
		text3 = "adventureLang/adv_adventureCollection_baseGame";
		goto IL_0b33;
		IL_0a97:
		AddHeader(text2);
		AddGrid();
		List<CollectionItemUI>.Enumerator enumerator9 = default(List<CollectionItemUI>.Enumerator);
		while (enumerator9.MoveNext())
		{
			List<WeaponType> list5 = null;
			bool flag16 = list.Remove(null);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2388 @ rbx_v41 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			bool flag17 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2388 @ rbx_v41 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag18 = (object)transform == null;
			transform.SetParent(_activeContentGrid, worldPositionStays: true);
		}
		goto IL_0786;
		IL_0b33:
		AddHeader(text3);
		AddGrid();
		List<CollectionItemUI>.Enumerator enumerator10 = default(List<CollectionItemUI>.Enumerator);
		while (enumerator10.MoveNext())
		{
			List<WeaponType> list6 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2900 @ rbx_v38 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			bool flag19 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2900 @ rbx_v38 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
			Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
			bool flag20 = (object)transform2 == null;
			transform2.SetParent(_activeContentGrid, worldPositionStays: true);
		}
		shouldForceLayoutUpdate = true;
	}

	private void AddHeader(string text)
	{
		//IL_0039: Expected I, but got O
		GameObject gameObject = UnityEngine.Object.Instantiate(_HeaderPrefab, _content);
		TextMeshProUGUI component = gameObject.GetComponent<TextMeshProUGUI>();
		nint num = (nint)component;
		component.text = text;
		shouldForceLayoutUpdate = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
	}

	private void AddGrid()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(_GridPrefab, _content);
		RectTransform component = gameObject.GetComponent<RectTransform>();
		_activeContentGrid = component;
		shouldForceLayoutUpdate = true;
		GameObject gameObject2 = UnityEngine.Object.Instantiate((GameObject)(object)_structuralSpawned, (Transform)(object)gameObject);
	}

	private void AddFakeContent()
	{
		//IL_0054: Expected O, but got I4
		//IL_016a: Expected O, but got I4
		//IL_008d: Expected O, but got I
		//IL_00a2: Expected O, but got I
		//IL_00db: Expected O, but got I
		//IL_0114: Expected O, but got I
		//IL_0137: Expected O, but got I
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		//IL_014b->IL0189: Incompatible stack heights: 4 vs 1
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _data.GetConvertedWeapons();
		bool flag = convertedWeapons == null;
		List<KeyValuePair<System.Int32Enum, object>> list = new List<KeyValuePair<System.Int32Enum, object>>((IEnumerable<KeyValuePair<System.Int32Enum, object>>)convertedWeapons);
		object obj = 0;
		while (true)
		{
			object obj2 = UnityEngine.Random.RandomRangeInt(7, 23);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v19 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<System.Int32Enum, System.Object>>)+18]");
			bool flag2 = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v19 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<System.Int32Enum, System.Object>>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v25+28]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rax_v26+18]");
			bool flag3 = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rax_v26+10]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v19 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<System.Int32Enum, System.Object>>)+18]");
			bool flag4 = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v19 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<System.Int32Enum, System.Object>>)+10]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v13+20]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v27+20]");
			AddWeapon((WeaponData)num, WeaponType.VOID);
			obj++;
		}
		shouldForceLayoutUpdate = true;
	}

	public unsafe void SetInfoPanel(WeaponData d, WeaponType type)
	{
		//IL_0453: Expected O, but got Ref
		Icon.enabled = true;
		TextMeshProUGUI component = Name.GetComponent<TextMeshProUGUI>();
		component.enabled = true;
		TextMeshProUGUI component2 = Description.GetComponent<TextMeshProUGUI>();
		component2.enabled = true;
		TextMeshProUGUI component3 = AdditionalInfo.GetComponent<TextMeshProUGUI>();
		component3.enabled = true;
		Image background;
		if (!d._003Cseen_003Ek__BackingField)
		{
			TextMeshProUGUI component4 = Name.GetComponent<TextMeshProUGUI>();
			component4.text = "???";
			Description.Term = "lang/weaponCollectionPanel_notFound";
			TextMeshProUGUI component5 = AdditionalInfo.GetComponent<TextMeshProUGUI>();
			component5.text = "";
			Sprite sprite = SpriteManager.GetSprite("QuestionMark", "UI");
			Icon.sprite = sprite;
			background = Background;
		}
		else
		{
			Sprite sprite2 = SpriteManager.GetSprite(d._003CframeName_003Ek__BackingField, d._003Ctexture_003Ek__BackingField);
			Icon.sprite = sprite2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C61]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			string prefix = d.GetPrefix(type);
			string term = prefix + "name";
			Name.Term = term;
			TextMeshProUGUI component6 = Name.GetComponent<TextMeshProUGUI>();
			string text = component6.text;
			if (text == null || text._stringLength <= 0)
			{
				component6.text = d._003Cname_003Ek__BackingField;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C62]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			string prefix2 = d.GetPrefix(type);
			string term2 = prefix2 + "description";
			Description.Term = term2;
			TextMeshProUGUI component7 = Description.GetComponent<TextMeshProUGUI>();
			if (!((TMP_Text)component7).m_enableAutoSizing)
			{
				((TMP_Text)component7).m_enableAutoSizing = true;
				component7.SetVerticesDirty();
				component7.SetLayoutDirty();
			}
			string text2 = component7.text;
			if (text2 == null || text2._stringLength <= 0)
			{
				component7.text = d._003Cdescription_003Ek__BackingField;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C63]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			string prefix3 = d.GetPrefix(type);
			string term3 = prefix3 + "tips";
			bool ignoreRTLnumbers = default(bool);
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool flag = LocalizationManager.TryGetTranslation(term3, out var Translation, FixForRTL: true, 0, ignoreRTLnumbers, applyParameters, localParametersRoot, overrideLanguage);
			if (Translation != null && Translation._stringLength > 0)
			{
				string localizedTipsTerm = d.GetLocalizedTipsTerm(type);
				AdditionalInfo.Term = localizedTipsTerm;
				TextMeshProUGUI component8 = AdditionalInfo.GetComponent<TextMeshProUGUI>();
				string text3 = component8.text;
				if (text3 == null || text3._stringLength <= 0)
				{
					component8.text = d._003Ctips_003Ek__BackingField;
				}
			}
			else
			{
				TextMeshProUGUI component9 = AdditionalInfo.GetComponent<TextMeshProUGUI>();
				component9.text = "";
			}
			background = Background;
		}
		object obj = default(object);
		background.color = (Color)(&obj);
		SetIconSize();
	}

	public void RegisterItemClick(bool isYellowSign)
	{
		//IL_01a5: Expected I, but got O
		//IL_01c3: Expected O, but got I4
		//IL_01dd: Expected O, but got I4
		nint num = (nint)typeof(CollectionsPage);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v2 (Il2CppClass<VampireSurvivors.UI.CollectionsPage>)+B8]");
		nint num2 = 0;
		object obj = IsMagician & isYellowSign;
		bool flag = obj == null;
		object obj2 = !flag;
		if (obj2 != null)
		{
			return;
		}
		if (isYellowSign)
		{
			int yellowSignClickCount = _yellowSignClickCount + 1;
			_yellowSignClickCount = yellowSignClickCount;
		}
		if (_yellowSignClickCount < 7 || IsMagician)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
		object obj3 = default(object);
		if (obj3 == null)
		{
			IsMagician = true;
			Sequence sequence = DOTween.Sequence();
			Transform target = _MagicianPanel.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScaleY(target, 1f, 0.5f);
			if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
			{
				Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)t, ((Tween)sequence).duration);
			}
			Sequence sequence3 = TweenSettingsExtensions.AppendInterval(sequence, 3f);
			Transform target2 = _MagicianPanel.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOScaleY(target2, 0f, 0.5f);
			if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t2, false))
			{
				Sequence sequence4 = Sequence.DoInsert(sequence, (Tween)t2, ((Tween)sequence).duration);
			}
		}
	}

	public void WeaponClicked(CollectionItemUI item, WeaponType t)
	{
		//IL_00e2: Expected O, but got I
		PlayerOptionsData config = _playerOptions.Config;
		List<ItemType> list = config._003CSealedItems_003Ek__BackingField;
		PlayerOptionsData config2 = _playerOptions.Config;
		List<WeaponType> list2 = config2._003CSealedWeapons_003Ek__BackingField;
		PlayerOptionsData config3 = _playerOptions.Config;
		if (config3._003CSeals_003Ek__BackingField == 0)
		{
			return;
		}
		PlayerOptionsData config4 = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
		object obj = default(object);
		float time = default(float);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj2 = num + 0;
			if ((nint)obj2 >= config3._003CSeals_003Ek__BackingField)
			{
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, time);
				return;
			}
			PlayerOptionsData config5 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
			object obj3 = default(object);
			if (obj3 == null)
			{
				PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Banish, null, 0f, 10, time);
				WeaponData weaponData = item._weaponData;
				if (weaponData._003Cseen_003Ek__BackingField)
				{
					PlayerOptionsData config6 = _playerOptions.Config;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
					object obj4 = default(object);
					if (obj4 == null)
					{
						WeaponData weaponData2 = item._weaponData;
						if (weaponData2._003Csealable_003Ek__BackingField)
						{
							PlayerOptionsData config7 = _playerOptions.Config;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
							item.Seal();
						}
					}
				}
			}
		}
		else
		{
			PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
			PlayerOptionsData config8 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
			object obj5 = default(object);
			if (obj5 != null)
			{
				PlayerOptionsData config9 = _playerOptions.Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
				object obj6 = default(object);
				if (obj6 == null)
				{
					PlayerOptionsData config10 = _playerOptions.Config;
					bool flag = ((List<System.Int32Enum>)(object)config10._003CSealedWeapons_003Ek__BackingField).Remove((System.Int32Enum)item._weaponType);
					item.UnSeal();
				}
			}
		}
		_SealPanel.UpdateValues();
	}

	private void BanishWeapon(CollectionItemUI item)
	{
		WeaponData weaponData = item._weaponData;
		if (!weaponData._003Cseen_003Ek__BackingField)
		{
			return;
		}
		PlayerOptionsData config = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
		object obj = default(object);
		if (obj == null)
		{
			WeaponData weaponData2 = item._weaponData;
			if (weaponData2._003Csealable_003Ek__BackingField)
			{
				PlayerOptionsData config2 = _playerOptions.Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
				item.Seal();
			}
		}
	}

	private void UnBanishWeapon(CollectionItemUI item)
	{
		PlayerOptionsData config = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
		object obj = default(object);
		if (obj != null)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
			object obj2 = default(object);
			if (obj2 == null)
			{
				PlayerOptionsData config3 = _playerOptions.Config;
				bool flag = ((List<System.Int32Enum>)(object)config3._003CSealedWeapons_003Ek__BackingField).Remove((System.Int32Enum)item._weaponType);
				item.UnSeal();
			}
		}
	}

	private void ContentGroupBanishWeapon(CollectionItemUI item)
	{
		WeaponData weaponData = item._weaponData;
		if (weaponData._003CisPowerUp_003Ek__BackingField)
		{
			return;
		}
		PlayerOptionsData config = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
		object obj = default(object);
		if (obj == null)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
			object obj2 = default(object);
			if (obj2 != null)
			{
				PlayerOptionsData config3 = _playerOptions.Config;
				bool flag = ((List<System.Int32Enum>)(object)config3._003CSealedWeapons_003Ek__BackingField).Remove((System.Int32Enum)item._weaponType);
			}
			PlayerOptionsData config4 = _playerOptions.Config;
			bool flag2 = config4._003CContentGroupSealedWeapons_003Ek__BackingField.Remove(item._weaponType);
			item.Seal();
		}
	}

	private void ContentGroupUnBanishWeapon(CollectionItemUI item)
	{
		PlayerOptionsData config = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
		object obj = default(object);
		if (obj != null)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			bool flag = ((List<System.Int32Enum>)(object)config2._003CContentGroupSealedWeapons_003Ek__BackingField).Remove((System.Int32Enum)item._weaponType);
			item.UnSeal();
		}
	}

	private void ContentGroupBanishItem(CollectionItemUI item)
	{
	}

	private void ContentGroupUnBanishItem(CollectionItemUI item)
	{
		PlayerOptionsData config = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
		object obj = default(object);
		if (obj != null)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			bool flag = ((List<System.Int32Enum>)(object)config2._003CContentGroupSealedItems_003Ek__BackingField).Remove((System.Int32Enum)item._itemType);
			item.UnSeal();
		}
	}

	public void UnsealAll()
	{
		List<CollectionItemUI>.Enumerator enumerator = default(List<CollectionItemUI>.Enumerator);
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
						goto IL_0298;
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
		goto IL_0298;
		IL_0298:
		List<ItemType> list = playerOptionsData._003CSealedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		PlayerOptions playerOptions2 = _playerOptions;
		PlayerOptionsData playerOptionsData2;
		if (playerOptions2._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions2._hostGameConfig == null)
			{
				if (playerOptions2._currentAdventureSaveData != null)
				{
					playerOptionsData2 = playerOptions2._currentAdventureSaveData;
					if ((object)playerOptionsData2._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_02d6;
					}
				}
				playerOptionsData2 = playerOptions2._mainGameConfig;
			}
			else
			{
				playerOptionsData2 = playerOptions2._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData2 = playerOptions2._onlineClientWithRunDataConfig;
		}
		goto IL_02d6;
		IL_02d6:
		List<WeaponType> list2 = playerOptionsData2._003CSealedWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		_SealPanel.UpdateValues();
		if (_MegaSealPanel.IsAvailable)
		{
			_MegaSealPanel.UnsealAll();
		}
	}

	private void BanishItem(CollectionItemUI item)
	{
		ItemData itemData = item._itemData;
		if (!itemData._003Cseen_003Ek__BackingField)
		{
			return;
		}
		PlayerOptionsData config = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
		object obj = default(object);
		if (obj == null)
		{
			ItemData itemData2 = item._itemData;
			if (itemData2._003Csealable_003Ek__BackingField)
			{
				PlayerOptionsData config2 = _playerOptions.Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
				item.Seal();
			}
		}
	}

	private void UnBanishItem(CollectionItemUI item)
	{
		PlayerOptionsData config = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
		object obj = default(object);
		if (obj != null)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
			object obj2 = default(object);
			if (obj2 == null)
			{
				PlayerOptionsData config3 = _playerOptions.Config;
				bool flag = ((List<System.Int32Enum>)(object)config3._003CSealedItems_003Ek__BackingField).Remove((System.Int32Enum)item._itemType);
				item.UnSeal();
			}
		}
	}

	public unsafe void BanishGroup(ContentGroupType contentGroup)
	{
		//IL_0017: Expected O, but got Ref
		if (_spawned != null)
		{
			List<CollectionItemUI>.Enumerator enumerator = default(List<CollectionItemUI>.Enumerator);
			if (enumerator.MoveNext())
			{
				CollectionItemUI collectionItemUI = null;
				List<CollectionItemUI>.Enumerator enumerator2 = (List<CollectionItemUI>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			if ((object)_SealPanel != null)
			{
				_SealPanel.UpdateValues();
				return;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void UnBanishGroup(ContentGroupType contentGroup)
	{
		//IL_0017: Expected O, but got Ref
		if (_spawned != null)
		{
			List<CollectionItemUI>.Enumerator enumerator = default(List<CollectionItemUI>.Enumerator);
			if (enumerator.MoveNext())
			{
				CollectionItemUI collectionItemUI = null;
				List<CollectionItemUI>.Enumerator enumerator2 = (List<CollectionItemUI>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			if ((object)_SealPanel != null)
			{
				_SealPanel.UpdateValues();
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void ItemClicked(CollectionItemUI item, ItemType t)
	{
		//IL_00e2: Expected O, but got I
		PlayerOptionsData config = _playerOptions.Config;
		List<ItemType> list = config._003CSealedItems_003Ek__BackingField;
		PlayerOptionsData config2 = _playerOptions.Config;
		List<WeaponType> list2 = config2._003CSealedWeapons_003Ek__BackingField;
		PlayerOptionsData config3 = _playerOptions.Config;
		if (config3._003CSeals_003Ek__BackingField == 0)
		{
			return;
		}
		PlayerOptionsData config4 = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
		object obj = default(object);
		float time = default(float);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj2 = num + 0;
			if ((nint)obj2 >= config3._003CSeals_003Ek__BackingField)
			{
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, time);
				return;
			}
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Banish, null, 0f, 10, time);
			ItemData itemData = item._itemData;
			if (itemData._003Cseen_003Ek__BackingField)
			{
				PlayerOptionsData config5 = _playerOptions.Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ItemData itemData2 = item._itemData;
					if (itemData2._003Csealable_003Ek__BackingField)
					{
						PlayerOptionsData config6 = _playerOptions.Config;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
						item.Seal();
					}
				}
			}
		}
		else
		{
			PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
			PlayerOptionsData config7 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
			object obj4 = default(object);
			if (obj4 != null)
			{
				PlayerOptionsData config8 = _playerOptions.Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
				object obj5 = default(object);
				if (obj5 == null)
				{
					PlayerOptionsData config9 = _playerOptions.Config;
					bool flag = ((List<System.Int32Enum>)(object)config9._003CSealedItems_003Ek__BackingField).Remove((System.Int32Enum)item._itemType);
					item.UnSeal();
				}
			}
		}
		_SealPanel.UpdateValues();
	}

	public void OnUnsealableClicked()
	{
		PlayerOptionsData config = _playerOptions.Config;
		if (config._003CSeals_003Ek__BackingField != 0)
		{
			_SealPanel.ShowWarning();
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, time);
		}
	}

	public unsafe void SetInfoPanel(ItemData d, ItemType type)
	{
		//IL_038b: Expected O, but got Ref
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Expected Ref, but got Unknown
		//IL_02ee: Expected I8, but got I4
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Expected Ref, but got Unknown
		Image background;
		if (!d._003Cseen_003Ek__BackingField)
		{
			TextMeshProUGUI component = Name.GetComponent<TextMeshProUGUI>();
			component.text = "???";
			Description.Term = "lang/weaponCollectionPanel_notFound";
			TextMeshProUGUI component2 = AdditionalInfo.GetComponent<TextMeshProUGUI>();
			component2.text = "";
			Sprite sprite = SpriteManager.GetSprite("QuestionMark", "UI");
			Icon.sprite = sprite;
			background = Background;
			goto IL_037e;
		}
		Sprite sprite2 = SpriteManager.GetSprite(d._003CframeName_003Ek__BackingField, d._003Ctexture_003Ek__BackingField);
		Icon.sprite = sprite2;
		TextMeshProUGUI component3 = Name.GetComponent<TextMeshProUGUI>();
		string localizedName = d.GetLocalizedName(type);
		component3.text = localizedName;
		TextMeshProUGUI component4 = Description.GetComponent<TextMeshProUGUI>();
		string localizedDescription = d.GetLocalizedDescription(type);
		component4.text = localizedDescription;
		string text = d._003Ctips_003Ek__BackingField;
		TextMeshProUGUI component5;
		string text3;
		if (d._003Ctips_003Ek__BackingField != null && text._stringLength > 0)
		{
			component5 = AdditionalInfo.GetComponent<TextMeshProUGUI>();
			string localPrefix = d.GetLocalPrefix(type);
			string term = localPrefix + "tips";
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			string text2 = translation.Replace("\\n", "<br>");
			object obj = "";
			if ((object)text2 == "")
			{
				goto IL_0333;
			}
			bool flag = text2 == null;
			text3 = text2;
			if (!flag)
			{
				bool flag2 = "" == null;
				text3 = text2;
				if (!flag2)
				{
					int stringLength = text2._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v620 @ rdx_v21+10]");
					bool flag3 = (nint)stringLength != 0;
					text3 = text2;
					if (!flag3)
					{
						ref byte first = ref *(byte*)(text2 + 20);
						ulong length = (ulong)(text2._stringLength + text2._stringLength);
						bool flag4 = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("" + 20), length);
						bool flag5 = !flag4;
						text3 = text2;
						if (!flag5)
						{
							goto IL_0333;
						}
					}
				}
			}
			goto IL_0345;
		}
		TextMeshProUGUI component6 = AdditionalInfo.GetComponent<TextMeshProUGUI>();
		component6.text = "";
		goto IL_03ba;
		IL_03ba:
		background = Background;
		goto IL_037e;
		IL_037e:
		object obj2 = default(object);
		background.color = (Color)(&obj2);
		SetIconSize();
		return;
		IL_0345:
		component5.text = text3;
		goto IL_03ba;
		IL_0333:
		text3 = d._003Ctips_003Ek__BackingField;
		goto IL_0345;
	}

	public void CycleFiltering()
	{
		//IL_0049: Expected I, but got O
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_00b1: Expected O, but got I
		object obj2 = default(object);
		IntPtr intPtr = default(IntPtr);
		Array array = default(Array);
		object obj4 = default(object);
		float time = default(float);
		while (true)
		{
			if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
			{
				return;
			}
			FilterType filterType = _currentFilter + 1;
			nint num = (nint)typeof(FilterType);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			num = intPtr;
			if (num == 0)
			{
				break;
			}
			object obj3 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v320 @ rdx_v7+8F8] (should have been resolved before IL gen)");
			int length = array.Length;
			bool flag = (int)filterType >= length;
			FilterType filterType2 = FilterType.DEFAULT;
			if (!flag)
			{
				filterType2 = filterType;
			}
			_currentFilter = filterType2;
			if (filterType2 == FilterType.ADVENTURE)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
				if (obj4 == null)
				{
					continue;
				}
			}
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
			SetFilter();
			return;
		}
		ArgumentNullException ex = new ArgumentNullException("enumType");
		throw ex;
	}

	private void SetFilter()
	{
		//IL_002f: Expected O, but got I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_00ba: Expected O, but got I4
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		bool flag = _currentFilter == FilterType.DEFAULT;
		if (!flag)
		{
			object obj = _currentFilter - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 == 1)
					{
						SortByAdventure();
					}
				}
				else
				{
					SortByVersion();
				}
			}
			else
			{
				SortByType();
			}
		}
		else
		{
			SortByDefault();
		}
		bool flag2 = _currentFilter == FilterType.DEFAULT;
		if (flag2)
		{
			goto IL_012e;
		}
		object obj3 = _currentFilter - 1;
		string term;
		if (!flag2)
		{
			object obj4 = obj3 - 1;
			if (!flag2)
			{
				if ((nint)obj4 != 1)
				{
					goto IL_012e;
				}
				term = "lang/menu_CollectionByAdventure";
			}
			else
			{
				term = "lang/menu_CollectionByVersion";
			}
		}
		else
		{
			term = "lang/menu_CollectionByType";
		}
		goto IL_013c;
		IL_013c:
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		_FilterModeText.text = translation;
		return;
		IL_012e:
		term = "lang/menu_CollectionDefault";
		goto IL_013c;
	}

	private void UpdateFilterTextDisplay()
	{
		//IL_0015: Expected O, but got I4
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		bool flag = _currentFilter == FilterType.DEFAULT;
		if (flag)
		{
			goto IL_0089;
		}
		object obj = _currentFilter - 1;
		string term;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (!flag)
			{
				if ((nint)obj2 != 1)
				{
					goto IL_0089;
				}
				term = "lang/menu_CollectionByAdventure";
			}
			else
			{
				term = "lang/menu_CollectionByVersion";
			}
		}
		else
		{
			term = "lang/menu_CollectionByType";
		}
		goto IL_0097;
		IL_0097:
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		_FilterModeText.text = translation;
		return;
		IL_0089:
		term = "lang/menu_CollectionDefault";
		goto IL_0097;
	}

	public unsafe void SetInfoPanel(ArcanaData d, ArcanaType type)
	{
		//IL_01d4: Expected O, but got Ref
		Image background;
		if (!d._003Cunlocked_003Ek__BackingField)
		{
			TextMeshProUGUI component = Name.GetComponent<TextMeshProUGUI>();
			component.text = "???";
			Description.Term = "lang/weaponCollectionPanel_notFound";
			TextMeshProUGUI component2 = AdditionalInfo.GetComponent<TextMeshProUGUI>();
			component2.text = "";
			Sprite sprite = SpriteManager.GetSprite("QuestionMark", "UI");
			Icon.sprite = sprite;
			background = Background;
		}
		else
		{
			Sprite sprite2 = SpriteManager.GetSprite(d._003CframeName_003Ek__BackingField, d._003Ctexture_003Ek__BackingField);
			Icon.sprite = sprite2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C17]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			string localPrefix = d.GetLocalPrefix(type);
			string term = localPrefix + "name";
			Name.Term = term;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C18]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			string localPrefix2 = d.GetLocalPrefix(type);
			string term2 = localPrefix2 + "description";
			Description.Term = term2;
			TextMeshProUGUI component3 = AdditionalInfo.GetComponent<TextMeshProUGUI>();
			component3.text = "";
			background = Background;
		}
		object obj = default(object);
		background.color = (Color)(&obj);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 371 Invalid \"Jump target not found in method: 0x186CAB980\"");
		throw new NullReferenceException();
	}

	private void SetIconSize()
	{
		//IL_0178: Expected O, but got I
		//IL_02b9: Expected O, but got I
		//IL_021f->IL01bf: Incompatible stack heights: 1 vs 0
		//IL_00a0->IL01bf: Incompatible stack heights: 1 vs 0
		//IL_0274->IL01bf: Incompatible stack heights: 2 vs 0
		//IL_00d6->IL01bf: Incompatible stack heights: 2 vs 0
		//IL_0102->IL01bf: Incompatible stack heights: 2 vs 0
		//IL_012c->IL01bf: Incompatible stack heights: 2 vs 0
		//IL_0156->IL01bf: Incompatible stack heights: 2 vs 0
		//IL_0198->IL01bf: Incompatible stack heights: 2 vs 0
		//IL_02d9->IL01bf: Incompatible stack heights: 3 vs 0
		//IL_0326->IL01bf: Incompatible stack heights: 4 vs 0
		if ((object)Icon != null)
		{
			RectTransform rectTransform = Icon.rectTransform;
			Image icon = Icon;
			if ((object)Icon != null)
			{
				Image sprite = (Image)(object)icon.m_Sprite;
				if ((object)icon.m_Sprite != null)
				{
					bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
					Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect ret);
					Image icon2 = Icon;
					if ((object)Icon != null)
					{
						object sprite2 = icon2.m_Sprite;
						if ((object)icon2.m_Sprite != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v13 (System.Object)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v13 (System.Object)+10]");
							Sprite.get_rect_Injected((IntPtr)0, out Rect ret2);
							if ((object)rectTransform != null)
							{
								Vector2 sizeDelta = default(Vector2);
								rectTransform.sizeDelta = sizeDelta;
								if ((object)Icon != null)
								{
									Transform transform = Icon.transform;
									if ((object)transform != null)
									{
										Transform parent = transform.parent;
										if ((object)parent != null)
										{
											Image component = parent.GetComponent<Image>();
											if ((object)component != null)
											{
												RectTransform rectTransform2 = component.rectTransform;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v39 (UnityEngine.UI.Image)+E0]");
												CollectionsPage collectionsPage = (CollectionsPage)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v39 (UnityEngine.UI.Image)+E0]");
												if ((nint)0 != 0)
												{
													bool flag3 = ((UnityEngine.Object)collectionsPage).m_CachedPtr == (IntPtr)0;
													Sprite.get_rect_Injected(((UnityEngine.Object)collectionsPage).m_CachedPtr, out ret2);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v39 (UnityEngine.UI.Image)+E0]");
													Image image = (Image)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v39 (UnityEngine.UI.Image)+E0]");
													if ((nint)0 != 0)
													{
														bool flag4 = ((UnityEngine.Object)image).m_CachedPtr == (IntPtr)0;
														Sprite.get_rect_Injected(((UnityEngine.Object)image).m_CachedPtr, out ret);
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
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void Reset()
	{
		//IL_0039->IL01d3: Incompatible stack heights: 1 vs 0
		if (_spawned != null)
		{
			List<CollectionItemUI>.Enumerator enumerator = default(List<CollectionItemUI>.Enumerator);
			while (enumerator.MoveNext())
			{
				object obj = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rbx_v7 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rbx_v7 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
				GameObject obj2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				UnityEngine.Object.Destroy(obj2, 0f);
			}
			List<CollectionItemUI> spawned = _spawned;
			if (_spawned != null)
			{
				int version = spawned._version + 1;
				spawned._version = version;
				spawned._size = 0;
				if (spawned._size > 0)
				{
					Array.Clear(spawned._items, 0, spawned._size);
				}
				List<CollectionItemUI> defaultSortOrder = _defaultSortOrder;
				if (_defaultSortOrder != null)
				{
					int version2 = defaultSortOrder._version + 1;
					defaultSortOrder._version = version2;
					defaultSortOrder._size = 0;
					if (defaultSortOrder._size > 0)
					{
						Array.Clear(defaultSortOrder._items, 0, defaultSortOrder._size);
					}
				}
				ClearStructures();
				_totalUnlocked = 0;
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void MakeMagician()
	{
		if (IsMagician)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
		object obj = default(object);
		if (obj == null)
		{
			IsMagician = true;
			Sequence sequence = DOTween.Sequence();
			Transform target = _MagicianPanel.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScaleY(target, 1f, 0.5f);
			if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
			{
				Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)t, ((Tween)sequence).duration);
			}
			Sequence sequence3 = TweenSettingsExtensions.AppendInterval(sequence, 3f);
			Transform target2 = _MagicianPanel.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOScaleY(target2, 0f, 0.5f);
			if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t2, false))
			{
				Sequence sequence4 = Sequence.DoInsert(sequence, (Tween)t2, ((Tween)sequence).duration);
			}
		}
	}

	public CollectionsPage()
	{
		List<CollectionItemUI> spawned = new List<CollectionItemUI>();
		_spawned = spawned;
		_structuralSpawned = new List<GameObject>();
		base._002Ector();
	}
}
