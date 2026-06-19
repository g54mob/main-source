using System;
using System.Collections.Generic;
using UnityEngine;

public class WorldContentMenu : WorldSettingsSubMenu, IScrollable
{
	private const string I2_PREFIX = "ContentBundles/";

	private const string TITLE_POSTFIX = "";

	private const string DESCRIPTION_POSTFIX = "Desc";

	public WorldSettingsTab tab;

	public UIScrollWindow scrollWindow;

	public UIComponentMonoBehaviour scrollingContent;

	public RadicalMenuOption_Apply addAllOption;

	public WorldContentBundleOption optionPrefab;

	public GameObject noAvailableBundlesText;

	public LinearLayoutUIComponent optionLayout;

	private WorldInfo _worldInfo;

	private HashSet<DataBlockAddress> _viewedBundles = new HashSet<DataBlockAddress>();

	private List<WorldContentBundleOption> _worldContentBundleOptions = new List<WorldContentBundleOption>();

	private int _availableOptionsCount;

	private bool _resetSelectionOnNextUpdate;

	public List<RadicalMenuOption> InitializeOptions()
	{
		int count = ScriptableData.GetDataBlocks<ContentBundleDataBlock>().Count;
		AsyncInstantiateOperation<WorldContentBundleOption> asyncInstantiateOperation = UnityEngine.Object.InstantiateAsync(optionPrefab, count, optionLayout.transform);
		asyncInstantiateOperation.WaitForCompletion();
		WorldContentBundleOption[] result = asyncInstantiateOperation.Result;
		foreach (WorldContentBundleOption worldContentBundleOption in result)
		{
			worldContentBundleOption.worldContentMenu = this;
			_worldContentBundleOptions.Add(worldContentBundleOption);
		}
		List<RadicalMenuOption> list = new List<RadicalMenuOption>(_worldContentBundleOptions.Count);
		foreach (WorldContentBundleOption worldContentBundleOption2 in _worldContentBundleOptions)
		{
			list.Add(worldContentBundleOption2.addButton);
		}
		return list;
	}

	public override void Activate(WorldInfo worldInfo)
	{
		_worldInfo = worldInfo;
		_viewedBundles = new HashSet<DataBlockAddress>(_worldInfo.viewedContentBundles);
		_worldInfo.MarkAllContentBundlesAsViewed();
		Reset();
		_resetSelectionOnNextUpdate = false;
		Manager.menu.SelectOption(tab);
		scrollWindow.MoveScrollToIncludePosition(0f, 0f);
	}

	public override void Reset()
	{
		List<ContentBundleDataBlock> missingBundles = GetMissingBundles();
		SetBundleOptions(missingBundles);
		bool flag = _availableOptionsCount > 0;
		noAvailableBundlesText.SetActive(!flag);
		scrollWindow.gameObject.SetActive(flag);
		addAllOption.gameObject.SetActive(flag);
		_resetSelectionOnNextUpdate = true;
		optionLayout.MarkUIComponentAsDirty(render: true);
	}

	public void Update()
	{
		if (_resetSelectionOnNextUpdate)
		{
			ResetSelection();
			_resetSelectionOnNextUpdate = false;
		}
		if (_availableOptionsCount != 0)
		{
			UpdateDependencies();
		}
	}

	private void ResetSelection()
	{
		if (_availableOptionsCount > 0)
		{
			Manager.menu.SelectOption(_worldContentBundleOptions[0].addButton);
		}
		else
		{
			Manager.menu.SelectOption(tab);
		}
	}

	private void UpdateDependencies()
	{
		HashSet<DataBlockAddress> hashSet = new HashSet<DataBlockAddress>();
		foreach (DataBlockAddress activatedContentBundle in _worldInfo.ActivatedContentBundles)
		{
			hashSet.Add(activatedContentBundle);
		}
		for (int i = 0; i < _availableOptionsCount; i++)
		{
			WorldContentBundleOption worldContentBundleOption = _worldContentBundleOptions[i];
			ContentBundleDataBlock currentContentBundle = worldContentBundleOption.CurrentContentBundle;
			worldContentBundleOption.SetAvailable(currentContentBundle != null && !HasMissingDependencies(currentContentBundle, hashSet));
		}
	}

	private bool HasMissingDependencies(ContentBundleDataBlock bundle, HashSet<DataBlockAddress> activeBundles)
	{
		foreach (DataBlockRef<ContentBundleDataBlock> dependency in bundle.dependencies)
		{
			if (!activeBundles.Contains(dependency.address))
			{
				return true;
			}
		}
		return false;
	}

	public void UpdateContainingElements(float scroll)
	{
	}

	public bool IsBottomElementSelected()
	{
		for (int num = _availableOptionsCount - 1; num >= 0; num--)
		{
			if (_worldContentBundleOptions[num].gameObject.activeInHierarchy)
			{
				return _worldContentBundleOptions[num].addButton == Manager.ui.currentSelectedUIElement;
			}
		}
		return false;
	}

	public bool IsTopElementSelected()
	{
		for (int num = 0; num < _availableOptionsCount; num--)
		{
			if (_worldContentBundleOptions[num].gameObject.activeInHierarchy)
			{
				return _worldContentBundleOptions[num].addButton == Manager.ui.currentSelectedUIElement;
			}
		}
		return false;
	}

	public float GetCurrentWindowHeight()
	{
		if (_availableOptionsCount == 0)
		{
			return 0f;
		}
		return scrollingContent.GetUIComponentRenderHeight();
	}

	public void OnAdd(ContentBundleDataBlock bundle)
	{
		OnAdd(new List<ContentBundleDataBlock> { bundle });
	}

	public void OnAdd(List<ContentBundleDataBlock> bundles)
	{
		int count = bundles.Count;
		string text;
		switch (count)
		{
		case 0:
			return;
		case 1:
			text = "Menu/ApplyContentBundlesOne";
			break;
		case 2:
			text = "Menu/ApplyContentBundlesTwo";
			break;
		default:
			text = "Menu/ApplyContentBundlesMultiple";
			break;
		}
		string text2 = text;
		string[] formatFields = count switch
		{
			1 => new string[1] { LocalizedBundleTitle(bundles[0]) }, 
			2 => new string[2]
			{
				LocalizedBundleTitle(bundles[0]),
				LocalizedBundleTitle(bundles[1])
			}, 
			_ => new string[2]
			{
				LocalizedBundleTitle(bundles[0]),
				(count - 1).ToString()
			}, 
		};
		Manager.menu.centerPopUpText.StartNewDisplaySequence(text2, options: new List<string> { "cancelDialogue", "confirm" }, formatFields: formatFields, menuInputCooldown: true, fadeTime: 0f, staticTime: 1.5f, useUnscaledTime: true, yPosition: 0f, textBackgroundAlpha: 1f, localize: true, fontFace: TextManager.FontFace.boldMedium, optionsCallback: delegate(PopupResponse response)
		{
			OnAddConfirmed(bundles, response.IsConfirm);
		}, minWidth: 10f, backgroundAlpha: 0.8f, priority: 0, textMaxWidth: 16f, secondOptionPopsAllMenus: false, pauseGame: true, holdToConfirm: false, localizePlaceholders: false, accidentalInputBlockDuration: 0f);
		static string LocalizedBundleTitle(ContentBundleDataBlock bundle)
		{
			return PugText.ProcessText(GetContentBundleTitle(bundle), null, shouldLocalize: true, shouldLocalizeFormatFields: false);
		}
	}

	public void OnAddAll()
	{
		List<ContentBundleDataBlock> list = new List<ContentBundleDataBlock>(_availableOptionsCount);
		for (int i = 0; i < _availableOptionsCount; i++)
		{
			list.Add(_worldContentBundleOptions[i].CurrentContentBundle);
		}
		OnAdd(list);
	}

	private void OnAddConfirmed(List<ContentBundleDataBlock> bundles, bool confirmed)
	{
		if (!confirmed)
		{
			return;
		}
		foreach (ContentBundleDataBlock bundle in bundles)
		{
			_worldInfo.ActivatedContentBundles.Add(bundle.address);
		}
		Reset();
	}

	private List<ContentBundleDataBlock> GetMissingBundles()
	{
		List<ContentBundleDataBlock> list = new List<ContentBundleDataBlock>();
		foreach (ContentBundleDataBlock dataBlock in ScriptableData.GetDataBlocks<ContentBundleDataBlock>())
		{
			if (dataBlock.canBeActivatedByPlayer && !_worldInfo.ActivatedContentBundles.Contains(dataBlock.address))
			{
				list.Add(dataBlock);
			}
		}
		list.Sort(delegate(ContentBundleDataBlock a, ContentBundleDataBlock b)
		{
			if (a.createdForVersion != b.createdForVersion)
			{
				return a.createdForVersion.CompareTo(b.createdForVersion);
			}
			return (a.displayOrder != b.displayOrder) ? a.displayOrder.CompareTo(b.displayOrder) : string.Compare(a.name, b.name, StringComparison.InvariantCultureIgnoreCase);
		});
		return list;
	}

	private void SetBundleOptions(List<ContentBundleDataBlock> availableBundles)
	{
		for (int i = 0; i < availableBundles.Count; i++)
		{
			ActivateOption(_worldContentBundleOptions[i], availableBundles[i]);
		}
		for (int j = availableBundles.Count; j < _worldContentBundleOptions.Count; j++)
		{
			DeactivateOption(_worldContentBundleOptions[j]);
		}
		_availableOptionsCount = availableBundles.Count;
		ClearVerticalNavigationOptions(tab);
		if (_availableOptionsCount > 0)
		{
			SetVerticalNavigationPair(tab, _worldContentBundleOptions[0].addButton);
		}
		for (int k = 0; k < _availableOptionsCount - 1; k++)
		{
			SetVerticalNavigationPair(_worldContentBundleOptions[k].addButton, _worldContentBundleOptions[k + 1].addButton);
		}
		bool flag = _availableOptionsCount > 0;
		addAllOption.SetInteractable(flag);
		if (flag)
		{
			ClearVerticalNavigationOptions(addAllOption);
			SetVerticalNavigationPair(_worldContentBundleOptions[_availableOptionsCount - 1].addButton, addAllOption);
			SetVerticalNavigationPair(addAllOption, tab);
		}
	}

	private void ActivateOption(WorldContentBundleOption option, ContentBundleDataBlock bundle)
	{
		option.CurrentContentBundle = bundle;
		option.gameObject.SetActive(value: true);
		option.SetNotificationStatus(!_viewedBundles.Contains(bundle.address));
		List<ContentBundleDataBlock> list = new List<ContentBundleDataBlock>();
		foreach (DataBlockRef<ContentBundleDataBlock> dependency in bundle.dependencies)
		{
			if (!_worldInfo.ActivatedContentBundles.Contains(dependency.address))
			{
				list.Add(dependency.Get());
			}
		}
		option.SetDependencies(list);
	}

	private void DeactivateOption(WorldContentBundleOption option)
	{
		option.CurrentContentBundle = null;
		option.gameObject.SetActive(value: false);
	}

	private static void ClearVerticalNavigationOptions(UIelement element)
	{
		element.topUIElements.Clear();
		element.bottomUIElements.Clear();
	}

	private static void SetVerticalNavigationPair(UIelement top, UIelement bottom)
	{
		top.bottomUIElements.Add(bottom);
		bottom.topUIElements.Add(top);
	}

	public static string GetContentBundleTitle(ContentBundleDataBlock bundle)
	{
		if (!(bundle != null))
		{
			return null;
		}
		return "ContentBundles/" + bundle.name;
	}

	public static string GetContentBundleDescription(ContentBundleDataBlock bundle)
	{
		if (!(bundle != null))
		{
			return null;
		}
		return "ContentBundles/" + bundle.name + "Desc";
	}
}
