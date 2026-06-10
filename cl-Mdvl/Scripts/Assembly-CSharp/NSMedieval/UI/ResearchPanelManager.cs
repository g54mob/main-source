using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Research;
using NSMedieval.Resources;
using NSMedieval.Sound;
using NSMedieval.Tutorial;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class ResearchPanelManager : PanelBase
	{
		[SerializeField]
		private TMP_Text[] avaliableValues;

		[SerializeField]
		private TMP_Text[] allocatedValues;

		[SerializeField]
		private SoundButton closeButton;

		[SerializeField]
		private SoundButton helpButton;

		[SerializeField]
		private GameObject infoPanel;

		[SerializeField]
		private TextMeshProUGUI researchName;

		[SerializeField]
		private TMP_Text researchInfoLabel;

		[SerializeField]
		private List<FillBarLayoutItemView> resourcesNeeded;

		[SerializeField]
		private TextMeshProUGUI researchRequirements;

		[SerializeField]
		private Image researchRequirementsImage;

		[SerializeField]
		private TMP_Text unlocksTitleLabel;

		[SerializeField]
		private LayoutGroupView imageGrid;

		[SerializeField]
		private SoundButton unlockButton;

		[SerializeField]
		private SoundButton resetButton;

		[SerializeField]
		private ScrollRect scrollRect;

		private ResearchNodeInstance currentNode;

		private bool firstTime;

		private readonly List<IconWithBackgroundButton> imageViews = new List<IconWithBackgroundButton>();

		private bool secondTime;

		public void EnableScrolling(bool enable)
		{
			ScrollRect[] componentsInChildren = base.transform.GetComponentsInChildren<ScrollRect>();
			foreach (ScrollRect obj in componentsInChildren)
			{
				obj.horizontal = enable;
				obj.vertical = enable;
			}
		}

		public RectTransform GetUnlockRect()
		{
			return unlockButton.transform as RectTransform;
		}

		protected override IEnumerator InitializeContent()
		{
			yield return InitializeNodes();
			if (!GlobalSaveController.CurrentVillageData.FirstEnter)
			{
				yield return DelayLoadSavedResearch();
			}
			Hide();
		}

		protected override void Start()
		{
			base.Start();
			closeButton.onClick.AddListener(Hide);
			unlockButton.onClick.AddListener(Unlock);
			resetButton.gameObject.SetActive(value: false);
			helpButton.onClick.AddListener(OnHelpClick);
			helpButton.gameObject.SetActive(!TutorialManager.IsTutorialActive);
			ResetInfoPanel();
			UpdateResources();
			MonoSingleton<ResearchUIController>.Instance.ResearchNodeSelectedEvent += OnResearchNodeSelected;
			MonoSingleton<ResearchUIController>.Instance.ResearchNodeSelectedExternallyEvent += OnResearchNodeExternallySelected;
			MonoSingleton<ResearchUIController>.Instance.UpdateResourcesEvent += OnUpdateResources;
			MonoSingleton<UIController>.Instance.DevToolsActive += OnDevToolsActive;
			MonoSingleton<ResourcePileController>.Instance.ResourceCountChangeEvent += OnAvaliableResourcesChanged;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<ResearchUIController>.IsInstantiated())
			{
				MonoSingleton<ResearchUIController>.Instance.ResearchNodeSelectedEvent -= OnResearchNodeSelected;
				MonoSingleton<ResearchUIController>.Instance.ResearchNodeSelectedExternallyEvent -= OnResearchNodeExternallySelected;
				MonoSingleton<ResearchUIController>.Instance.UpdateResourcesEvent -= OnUpdateResources;
			}
			if (MonoSingleton<ResourcePileController>.IsInstantiated())
			{
				MonoSingleton<ResourcePileController>.Instance.ResourceCountChangeEvent -= OnAvaliableResourcesChanged;
			}
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.DevToolsActive -= OnDevToolsActive;
			}
		}

		protected override PanelGroupType GetGroupType()
		{
			return PanelGroupType.UpperLeft;
		}

		public override void Show()
		{
			base.Show();
			scrollRect.horizontalScrollbar.value = 0f;
			scrollRect.verticalScrollbar.value = 1f;
		}

		public override void Hide()
		{
			currentNode = null;
			ResetInfoPanel();
			DisposeImageGrid();
			base.Hide();
		}

		protected override void UpdatePanel()
		{
			if (!secondTime)
			{
				secondTime = true;
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					MonoSingleton<ResearchManager>.Instance.SetupScenarioUnlocked();
				});
			}
			StartCoroutine(RedrawLinesDelay());
		}

		private IEnumerator RedrawLinesDelay()
		{
			yield return new WaitForEndOfFrame();
			MonoSingleton<ResearchManager>.Instance.RedrawLines();
		}

		private IEnumerator DelayLoadSavedResearch()
		{
			yield return new WaitForEndOfFrame();
			MonoSingleton<ResearchManager>.Instance.LoadSavedResearch();
		}

		private void OnDevToolsActive(bool active)
		{
			resetButton.gameObject.SetActive(active);
		}

		private IEnumerator InitializeNodes()
		{
			yield return new WaitForEndOfFrame();
			MonoSingleton<ResearchManager>.Instance.InitializeNodes();
		}

		private void UpdateResources()
		{
			OnUpdateResources(MonoSingleton<ResearchManager>.Instance.ResearchAllocatedResources);
		}

		private void OnUpdateResources(Dictionary<Resource, int> allocatedResources)
		{
			int num = 0;
			foreach (KeyValuePair<Resource, int> allocatedResource in allocatedResources)
			{
				int value = allocatedResource.Value;
				ResourcePileCount count = MonoSingleton<ResourcePileTracker>.Instance.GetCount(allocatedResource.Key);
				int totalCount = count.TotalCount;
				int unreachableCount = count.UnreachableCount;
				int resourceCountFromWorkerStorage = MonoSingleton<WorkerManager>.Instance.GetResourceCountFromWorkerStorage(allocatedResource.Key);
				int num2 = totalCount + unreachableCount + resourceCountFromWorkerStorage;
				avaliableValues[num].SetText($"{Mathf.Clamp(num2 - value, 0, int.MaxValue)}");
				if (num2 >= value)
				{
					allocatedValues[num].SetText($"<style=DefaultGrey>{value}</style>");
				}
				else
				{
					allocatedValues[num].SetText($"<style=DefaultRed>{num2}/{value}</style>");
				}
				num++;
			}
		}

		private void Unlock()
		{
			if (currentNode != null)
			{
				MonoSingleton<AudioManager>.Instance.PlaySound("UI_ResearchUnlock");
				MonoSingleton<ResearchController>.Instance.Activate(currentNode);
				unlockButton.gameObject.SetActive(value: false);
			}
		}

		private void ResetAllResearch()
		{
			MonoSingleton<ResearchController>.Instance.ResetAllResearch();
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(UpdateResources);
		}

		private void OnResearchNodeExternallySelected(string nodeId)
		{
			ResearchNodeInstance instanceById = MonoSingleton<ResearchManager>.Instance.GetInstanceById(nodeId);
			bool isEnabled;
			if (instanceById == null)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(47, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ResearchPanelManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("There is no instance of Research node with id: ");
					messageBuilder.AppendFormatted(nodeId);
				}
				Log.Error(messageBuilder);
				return;
			}
			if (!GlobalSaveController.CurrentVillageData.ResearchTableBuilt)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("error_build_research_bench"));
				return;
			}
			Show();
			ResearchNodeView view = MonoSingleton<ResearchManager>.Instance.GetView(instanceById);
			if (view == null)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(47, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ResearchPanelManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Couldn't find ResearchNodeView for instance of ");
					messageBuilder.AppendFormatted(instanceById.Blueprint.GetID());
				}
				Log.Error(messageBuilder);
			}
			else
			{
				Vector2 sizeDelta = scrollRect.GetComponent<RectTransform>().sizeDelta;
				float value = view.GetPositionAndSelect().x * 0.5f / sizeDelta.x;
				float value2 = view.GetPositionAndSelect().y / sizeDelta.y;
				scrollRect.horizontalScrollbar.value = GetXScrollValue(value);
				scrollRect.verticalScrollbar.value = GetYScrollValue(value2);
				OnResearchNodeSelected(instanceById);
			}
			static float GetXScrollValue(float num)
			{
				if (num <= 0.6f)
				{
					return 0f;
				}
				if (num <= 0.7f)
				{
					return 0.25f;
				}
				if (num <= 0.8f)
				{
					return 0.65f;
				}
				return 1f;
			}
			static float GetYScrollValue(float num)
			{
				if (num <= 0.5f)
				{
					return 0f;
				}
				return 1f;
			}
		}

		private void OnResearchNodeSelected(ResearchNodeInstance node)
		{
			ResetInfoPanel();
			currentNode = node;
			CreateImages();
			unlockButton.interactable = false;
			unlockButton.gameObject.SetActive(value: false);
			researchName.text = MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(node.Blueprint.LocKeys));
			string text = MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetInfo(currentNode.Blueprint.LocKeys));
			researchInfoLabel.SetText(text);
			SetRequiredResearchTextAndIcon(node);
			SetRequiredResources(node);
			if (currentNode.ResearchState.Equals(ResearchState.Unlocked) && MonoSingleton<ResearchManager>.Instance.HasEnoughResources(node))
			{
				unlockButton.interactable = true;
			}
			if (!currentNode.ResearchState.Equals(ResearchState.Activated))
			{
				unlockButton.gameObject.SetActive(value: true);
			}
			infoPanel.SetActive(value: true);
		}

		private void SetRequiredResources(ResearchNodeInstance node)
		{
			foreach (FillBarLayoutItemView item in resourcesNeeded)
			{
				item.gameObject.SetActive(value: false);
			}
			int num = 0;
			foreach (KeyValuePair<string, int> item2 in node.Blueprint.RequiredResources.Dictionary)
			{
				resourcesNeeded[num].TooltipNew.SetLines(ResourceUtils.GetTooltipData(item2.Key));
				if (MonoSingleton<ResearchManager>.Instance.HasEnough(item2))
				{
					resourcesNeeded[num].SetText($"<style=AltColor>{item2.Value}</style>");
				}
				else
				{
					resourcesNeeded[num].SetText($"<style=DefaultRed>{item2.Value}</style>");
					resourcesNeeded[num].TooltipNew.AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("research_available_error"), TooltipStyles.DefaultRed);
				}
				resourcesNeeded[num].gameObject.SetActive(value: true);
				num++;
			}
		}

		private string GetRequiredResearch(ResearchNodeInstance node)
		{
			ResearchModel researchModel = node.Parents.FirstOrDefault()?.Blueprint;
			if (researchModel == null)
			{
				return MonoSingleton<LocalizationController>.Instance.GetText("keycode_None");
			}
			return MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(researchModel.LocKeys));
		}

		private void SetRequiredResearchTextAndIcon(ResearchNodeInstance node)
		{
			ResearchModel researchModel = node.Parents.FirstOrDefault()?.Blueprint;
			if (researchModel == null)
			{
				researchRequirements.text = MonoSingleton<LocalizationController>.Instance.GetText("keycode_None");
				researchRequirementsImage.enabled = false;
			}
			else
			{
				researchRequirementsImage.enabled = true;
				researchRequirements.text = MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(researchModel.LocKeys));
				researchRequirementsImage.sprite = MonoRepository<SpriteRepository, KeySpritePair>.Instance.GetByAddress(researchModel.IconActive);
			}
		}

		private string GetUnlockedItems(ResearchNodeInstance node)
		{
			string text = string.Empty;
			foreach (ResearchUnlock unlock in node.Blueprint.Unlocks)
			{
				string iconPath = Repository<ResourceRepository, Resource>.Instance.GetByID(unlock.UnlockId).IconPath;
				text = text + AssetUtils.GetSpriteAsset(iconPath) + " " + unlock.UnlockId + " \n\n";
			}
			return text;
		}

		private void ResetInfoPanel()
		{
			infoPanel.SetActive(currentNode != null);
			DisposeImageGrid();
			researchName.text = string.Empty;
			researchRequirements.text = string.Empty;
			foreach (FillBarLayoutItemView item in resourcesNeeded)
			{
				item.gameObject.SetActive(value: false);
			}
			if (currentNode != null && currentNode.ResearchState.Equals(ResearchState.Unlocked) && MonoSingleton<ResearchManager>.Instance.HasEnoughResources(currentNode))
			{
				unlockButton.interactable = true;
			}
		}

		private void CreateImages()
		{
			imageViews.SetAllActive(active: false);
			int num = 0;
			foreach (ResearchUnlock unlock in currentNode.Blueprint.Unlocks)
			{
				if (!unlock.HideInUi && GetUnlockedInfos(unlock.UnlockId, out var locKeys, out var iconPath, out var iconBackgroundPath, out var iconColor))
				{
					IconWithBackgroundButton next = imageViews.GetNext(imageGrid);
					next.SetData(iconPath, iconBackgroundPath, iconColor);
					next.AddButtonListener(delegate
					{
						MonoSingleton<UIController>.Instance.ShowAlmanacEntry(UiUtils.GetRepositoryLink(LocKeyUtils.GetName(locKeys)));
					});
					ItemToUnlockTooltip itemToUnlockTooltip = next.TooltipNew as ItemToUnlockTooltip;
					if (itemToUnlockTooltip != null)
					{
						itemToUnlockTooltip.SetId(unlock.UnlockId);
					}
					num++;
				}
			}
			unlocksTitleLabel.gameObject.SetActive(num > 0);
		}

		private void OnHelpClick()
		{
			MonoSingleton<UIController>.Instance.ShowAlmanacEntry("Gameplaytipsresearch");
		}

		private bool GetUnlockedInfos(string researchUnlockUnlockId, out LocKeys[] locKeys, out string iconPath, out string iconBackgroundPath, out string iconColor)
		{
			locKeys = null;
			iconPath = null;
			iconBackgroundPath = null;
			iconColor = null;
			NSMedieval.Model.Production byID = Repository<ProductionRepository, NSMedieval.Model.Production>.Instance.GetByID(researchUnlockUnlockId);
			if (byID != null)
			{
				locKeys = byID.LocKeys;
				iconPath = byID.IconPath;
				iconBackgroundPath = byID.IconBackgroundPath;
				iconColor = byID.IconColorValue;
				return true;
			}
			BaseBuildingBlueprint byID2 = Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetByID(researchUnlockUnlockId);
			if (byID2 != null)
			{
				locKeys = byID2.LocKeys;
				iconPath = byID2.IconPath;
				return true;
			}
			return false;
		}

		private void DisposeImageGrid()
		{
			foreach (IconWithBackgroundButton item in imageViews.IterateInReverseDynamic())
			{
				Object.Destroy(item.gameObject);
				imageViews.Remove(item);
			}
		}

		private void OnAvaliableResourcesChanged(Resource resource, ResourcePileCount pileCount)
		{
			if (currentNode != null && currentNode.ResearchState.Equals(ResearchState.Unlocked) && MonoSingleton<ResearchManager>.Instance.HasEnoughResources(currentNode))
			{
				unlockButton.interactable = true;
			}
		}
	}
}
