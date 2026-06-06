using System.Collections.Generic;
using R3;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using ZLinq;
using ZLinq.Linq;

public class ResearchView : MonoBehaviour, IMainView
{
	public struct ResearchNodeDataWrapper
	{
		public ResearchNode Research;

		public ResearchNodeDirectory Directory;

		public LocalizedString Title;

		public LocalizedString Description;

		public Sprite Sprite;

		public double Cost;

		public bool IsDummy;

		public ResearchNodeDataWrapper(ResearchNodeData research)
		{
			Research = research.ID;
			Directory = research.directory;
			Title = research.TitleLocalized;
			Description = research.DescriptionLocalized;
			Sprite = research.sprite;
			Cost = research.cost;
			IsDummy = false;
		}

		public ResearchNodeDataWrapper(ResearchNode research, LocalizedString description, Sprite sprite, double cost)
		{
			Research = research;
			Directory = FindDirectory(research);
			Title = FindTitle(research);
			Description = description;
			Sprite = sprite;
			Cost = cost;
			IsDummy = true;
		}

		private static LocalizedString FindTitle(ResearchNode node)
		{
			string text = "research_" + node.ToString().ToLower();
			LocalizedDatabase<UnityEngine.Localization.Tables.StringTable, UnityEngine.Localization.Tables.StringTableEntry>.TableEntryResult tableEntry = LocalizationSettings.StringDatabase.GetTableEntry(LocTable.Research.Value(), text, LocalizationSettings.SelectedLocale ?? LocalizationSettings.ProjectLocale);
			if (tableEntry.Entry != null)
			{
				return new LocalizedString(tableEntry.Table.SharedData.TableCollectionNameGuid, tableEntry.Entry.KeyId);
			}
			return new LocalizedString();
		}

		private static ResearchNodeDirectory FindDirectory(ResearchNode node)
		{
			switch (node)
			{
			case ResearchNode.BitArchitecture:
			case ResearchNode.VCSSystem:
			case ResearchNode.DeploymentScript:
			case ResearchNode.KernelDebugger:
			case ResearchNode.AnonymousAnalytics:
				return ResearchNodeDirectory.Development;
			case ResearchNode.BigBox:
			case ResearchNode.LegacySupport:
			case ResearchNode.Day1DLC:
			case ResearchNode.Big4Consultant:
			case ResearchNode.LiveServices:
				return ResearchNodeDirectory.Monetization;
			case ResearchNode.ClusterOverdrive:
			case ResearchNode.T3Backbone:
			case ResearchNode.RemoteSupport:
			case ResearchNode.BackwardsCompatibility:
			case ResearchNode.Hyperscaler:
				return ResearchNodeDirectory.Performance;
			case ResearchNode.TokyoOffice:
			case ResearchNode.LondonOffice:
			case ResearchNode.CrunchCulture:
			case ResearchNode.AuctionHouse:
			case ResearchNode.ParallelDevteams:
				return ResearchNodeDirectory.Branding;
			case ResearchNode.VCFunding:
			case ResearchNode.PublishingDeal:
			case ResearchNode.LineOfCredit:
			case ResearchNode.VolumeLicensing:
			case ResearchNode.GovernmentGrant:
				return ResearchNodeDirectory.Finances;
			default:
				return ResearchNodeDirectory.Development;
			}
		}
	}

	[SerializeField]
	private List<ResearchDirectory> directories;

	[SerializeField]
	private Transform directoryParent;

	[SerializeField]
	private Vector2 gridCellSize = new Vector2(130f, 180f);

	[SerializeField]
	private Vector2 gridSpacing = new Vector2(2f, 20f);

	[SerializeField]
	private ResearchVisualizer entryPrefab;

	[SerializeField]
	private LocalizedString notInDemoLocalized;

	[SerializeField]
	private Sprite notInDemoSprite;

	[SerializeField]
	private LocalizeStringHandler titleHandler;

	[SerializeField]
	private LocalizeStringHandler descriptionHandler;

	[SerializeField]
	private LocalizeStringHandler modifiersHandler;

	[SerializeField]
	private LocalizeStringHandler costHandler;

	[SerializeField]
	private Image image;

	[SerializeField]
	private Button researchButton;

	[SerializeField]
	private Button increaseStorageButton;

	[SerializeField]
	private List<ResearchStorageBlade> storageBlades;

	private ResearchNodeDirectory _directory;

	private ResearchNode _research;

	private readonly Dictionary<ResearchNodeDirectory, GameObject> _researchNodeParents = new Dictionary<ResearchNodeDirectory, GameObject>();

	private readonly Dictionary<ResearchNodeDirectory, ResearchNode> _selectedResearchPerDirectory = new Dictionary<ResearchNodeDirectory, ResearchNode>();

	public void Initialize()
	{
		Initializer.Each(directories, delegate(ResearchDirectory dir)
		{
			dir.Selected += DirectorySelected;
		}).Context(researchButton).AddListener(HandleResearch)
			.Context(increaseStorageButton)
			.AddListener(Database.Commands.Research.IncreaseStorage)
			.Invoke(InitializeResearchParents)
			.Invoke(InitializeResearch)
			.Invoke(delegate
			{
				DirectorySelected(ResearchNodeDirectory.Monetization);
			})
			.Invoke(Hide);
		Database.State.Research.DataNodes.Subscribe(RefreshStorageBlades).AddTo(this);
		Database.State.Research.DataNodes.Select((int x) => x < 6).DistinctUntilChanged().SubscribeToSetActive(increaseStorageButton.gameObject)
			.AddTo(this);
	}

	public void Show()
	{
		base.gameObject.SetActive(value: true);
		UI.Registry.taskbar.research.ForcePressed();
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
		UI.Registry.taskbar.research.Clear();
	}

	private void InitializeResearchParents()
	{
		foreach (ResearchNodeDirectory value in EnumUtility.GetValues<ResearchNodeDirectory>())
		{
			GameObject gameObject = new GameObject(value.ToString());
			gameObject.transform.SetParent(directoryParent);
			_researchNodeParents.Add(value, gameObject);
			RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
			rectTransform.anchorMin = Vector2.zero;
			rectTransform.anchorMax = Vector2.one;
			rectTransform.localScale = Vector3.one;
			rectTransform.sizeDelta = Vector2.zero;
			rectTransform.anchoredPosition3D = Vector3.zero;
			GridLayoutGroup gridLayoutGroup = gameObject.AddComponent<GridLayoutGroup>();
			gridLayoutGroup.cellSize = gridCellSize;
			gridLayoutGroup.spacing = gridSpacing;
		}
	}

	private void InitializeResearch()
	{
		using ValueEnumerator<OrderBy<Select<FromEnumerable<ResearchNode>, ResearchNode, ResearchNodeDataWrapper>, ResearchNodeDataWrapper, double>, ResearchNodeDataWrapper> valueEnumerator = (from x in EnumUtility.GetValuesSkipNone<ResearchNode>().AsValueEnumerable().Select(WrapData)
			orderby x.Cost
			select x).GetEnumerator<OrderBy<Select<FromEnumerable<ResearchNode>, ResearchNode, ResearchNodeDataWrapper>, ResearchNodeDataWrapper, double>, ResearchNodeDataWrapper>();
		while (valueEnumerator.MoveNext())
		{
			ResearchNodeDataWrapper current = valueEnumerator.Current;
			Transform parent = _researchNodeParents[current.Directory].transform;
			ResearchVisualizer researchVisualizer = Object.Instantiate(entryPrefab, parent);
			researchVisualizer.Setup(current);
			researchVisualizer.Selected += ResearchSelected;
			_selectedResearchPerDirectory.TryAdd(current.Directory, current.Research);
		}
	}

	private void DirectorySelected(ResearchNodeDirectory directory)
	{
		_directory = directory;
		foreach (KeyValuePair<ResearchNodeDirectory, GameObject> researchNodeParent in _researchNodeParents)
		{
			researchNodeParent.Value.SetActive(researchNodeParent.Key == _directory);
		}
		foreach (ResearchDirectory directory2 in directories)
		{
			directory2.SetActiveTab(directory2.Directory == _directory);
		}
		LayoutRebuilder.ForceRebuildLayoutImmediate(_researchNodeParents[_directory].GetComponent<RectTransform>());
		ResearchSelected(_selectedResearchPerDirectory[_directory]);
	}

	private void ResearchSelected(ResearchNode research)
	{
		_research = research;
		_selectedResearchPerDirectory[_directory] = _research;
		ResearchNodeDataWrapper researchNodeDataWrapper = WrapData(_research);
		bool flag = Database.State.Research.IsUnlocked(_research);
		titleHandler.SetLocalizedString(researchNodeDataWrapper.Title);
		descriptionHandler.SetLocalizedString(researchNodeDataWrapper.Description);
		modifiersHandler.SetVariable("research_modifiers", researchNodeDataWrapper.IsDummy ? new LocalizedModifierList() : new LocalizedModifierList(researchNodeDataWrapper.Research, !flag));
		modifiersHandler.SetLocalizedString(modifiersHandler.AssetReference);
		costHandler.SetValue(researchNodeDataWrapper.Cost);
		image.overrideSprite = researchNodeDataWrapper.Sprite;
		costHandler.gameObject.SetActive(!flag);
		researchButton.gameObject.SetActive(!flag && !researchNodeDataWrapper.IsDummy);
		LayoutRebuilder.ForceRebuildLayoutImmediate(descriptionHandler.GetComponent<RectTransform>());
		LayoutRebuilder.ForceRebuildLayoutImmediate(modifiersHandler.GetComponent<RectTransform>());
	}

	private void HandleResearch()
	{
		if (_research.TryGetData(out var data))
		{
			Database.Commands.Research.Unlock(data);
			ResearchSelected(_research);
		}
	}

	private void RefreshStorageBlades(int blades)
	{
		for (int i = 0; i < storageBlades.Count; i++)
		{
			storageBlades[i].SetState(i < blades);
		}
	}

	private ResearchNodeDataWrapper WrapData(ResearchNode node)
	{
		if (!node.TryGetData(out var data))
		{
			return new ResearchNodeDataWrapper(node, notInDemoLocalized, notInDemoSprite, 99.9);
		}
		return new ResearchNodeDataWrapper(data);
	}
}
