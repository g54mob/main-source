using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Research;
using NSMedieval.State;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class SelectionExtraProduction : SelectionExtraWindowView
	{
		public static ProductionInstance ExtraShownForProduction;

		[SerializeField]
		private LayoutGroupView productionsGroup;

		[SerializeField]
		private LayoutGroupView productionQueueGroup;

		[SerializeField]
		private Button copyQueueButton;

		[SerializeField]
		private Button pasteQueueButton;

		private InfoPanelProduction productionPanel;

		private List<IconWithBackgroundButton> productions = new List<IconWithBackgroundButton>();

		private List<ProductionLayoutItemView> productionQueue = new List<ProductionLayoutItemView>();

		public ProductionComponentInstance SelectedComponentInstance => productionPanel.SelectedProductionComponentInstance;

		public List<IconWithBackgroundButton> ProductionButtons => productions;

		public List<ProductionLayoutItemView> ProductionQueue => productionQueue;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			ExtraShownForProduction = null;
		}

		public void ShowPanel(InfoPanelProduction productionPanel)
		{
			Show();
			base.SceneUIManager.OnProductionPanelOpen();
			this.productionPanel = productionPanel;
			foreach (IconWithBackgroundButton production in productions)
			{
				production.gameObject.SetActive(value: false);
			}
			foreach (ProductionLayoutItemView item in ProductionQueue)
			{
				Object.Destroy(item.gameObject);
			}
			productionQueue.Clear();
			foreach (string productionID in this.productionPanel.PossibleProductions)
			{
				if (!MonoSingleton<ResearchManager>.Instance.Researched(productionID) && !MonoSingleton<ResearchManager>.Instance.UnlockedByDefault(productionID))
				{
					continue;
				}
				NSMedieval.Model.Production blueprint = Repository<ProductionRepository, NSMedieval.Model.Production>.Instance.GetByID(productionID);
				IconWithBackgroundButton button = CreateProductionButton();
				button.gameObject.SetActive(value: true);
				button.SetData(blueprint.IconPath, blueprint.IconBackgroundPath, blueprint.IconColorValue);
				if (button.TooltipNew != null)
				{
					button.TooltipNew.ExecuteOnShow = delegate
					{
						button.TooltipNew.SetLines(blueprint.GenerateTooltipData());
					};
				}
				button.AddButtonListener(delegate
				{
					AddNewProduction(productionID);
				});
			}
			SetupProductionQueue();
		}

		public void UpdateProduction(InfoPanelProduction infoPanelProduction)
		{
			if (infoPanelProduction.CurrentProductions == null)
			{
				Log.Warning("Info extra panel current production is NONE", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Selection\\SelectionExtraProduction.cs");
				foreach (ProductionLayoutItemView item in productionQueue)
				{
					Object.Destroy(item.gameObject);
				}
				productionQueue.Clear();
				return;
			}
			for (int i = 0; i < infoPanelProduction.CurrentProductions.Count; i++)
			{
				CreateProductionQueued(i).SetProductionData(infoPanelProduction.SelectedProductionComponentInstance, infoPanelProduction.CurrentProductions[i]);
			}
			for (int j = infoPanelProduction.CurrentProductions.Count; j < productionQueue.Count; j++)
			{
				productionQueue[j].gameObject.SetActive(value: false);
			}
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.ToggleEditProductionUIEvent -= OnToggleEditProductionUI;
				MonoSingleton<UIController>.Instance.QueuedProductionSelectedEvent -= OnQueuedProductionSelectedEvent;
				MonoSingleton<UIController>.Instance.ForceUpdateProductionLayoutItemViewsEvent -= OnForceUpdateProductionLayoutItemViews;
				MonoSingleton<UIController>.Instance.ProductionCanceledUIEvent -= OnProductionUICanceled;
				copyQueueButton.onClick.RemoveAllListeners();
				pasteQueueButton.onClick.RemoveAllListeners();
			}
			ExtraShownForProduction = null;
			base.OnDestroy();
		}

		private void OnDisable()
		{
			ExtraShownForProduction = null;
		}

		private void OnProductionUICanceled(ProductionLayoutItemView productionLayoutItemView)
		{
			if (!(productionLayoutItemView == null))
			{
				if (productionQueue.Remove(productionLayoutItemView))
				{
					Object.Destroy(productionLayoutItemView.gameObject);
				}
				ExtraShownForProduction = null;
			}
		}

		private void OnForceUpdateProductionLayoutItemViews()
		{
			if (productionPanel != null)
			{
				UpdateProduction(productionPanel);
			}
		}

		private void SetupProductionQueue()
		{
			if (productionPanel == null || productionPanel.CurrentProductions == null)
			{
				foreach (ProductionLayoutItemView item in productionQueue)
				{
					if (item != null)
					{
						Object.Destroy(item.gameObject);
					}
				}
				productionQueue.Clear();
			}
			else
			{
				int count = productionPanel.CurrentProductions.Count;
				for (int i = 0; i < count; i++)
				{
					CreateProductionQueued(i).gameObject.SetActive(value: true);
				}
			}
		}

		private IconWithBackgroundButton CreateProductionButton()
		{
			IconWithBackgroundButton iconWithBackgroundButton = productions.FirstOrDefault((IconWithBackgroundButton productionObject) => !productionObject.gameObject.activeSelf);
			if (iconWithBackgroundButton == null)
			{
				iconWithBackgroundButton = Object.Instantiate(productionsGroup.Prefab, Vector3.zero, Quaternion.identity, productionsGroup.gameObject.transform) as IconWithBackgroundButton;
				productions.Add(iconWithBackgroundButton);
			}
			return iconWithBackgroundButton;
		}

		private ProductionLayoutItemView CreateProductionQueued(int index)
		{
			ProductionLayoutItemView productionLayoutItemView = ((productionQueue != null && productionQueue.Count > index) ? productionQueue[index] : null);
			if (productionQueue == null)
			{
				productionQueue = new List<ProductionLayoutItemView>();
			}
			if (productionLayoutItemView == null)
			{
				productionLayoutItemView = Object.Instantiate(productionQueueGroup.Prefab, Vector3.zero, Quaternion.identity, productionQueueGroup.gameObject.transform) as ProductionLayoutItemView;
				productionQueue.Add(productionLayoutItemView);
			}
			productionLayoutItemView.gameObject.SetActive(value: true);
			return productionLayoutItemView;
		}

		private void AddNewProduction(string productionId)
		{
			if (SelectedComponentInstance != null && !SelectedComponentInstance.HasDisposed)
			{
				if (productionQueue == null)
				{
					productionQueue = new List<ProductionLayoutItemView>();
				}
				int count = productionQueue.Count;
				ProductionLayoutItemView productionLayoutItemView = CreateProductionQueued(count);
				productionLayoutItemView.SetProductionData(productionInstance: SelectedComponentInstance.ProductionSystemInstance.AddNewProduction(Repository<ProductionRepository, NSMedieval.Model.Production>.Instance.GetByID(productionId)), productionComponentInstance: SelectedComponentInstance);
				productionLayoutItemView.gameObject.SetActive(value: true);
			}
		}

		private void CopyQueue()
		{
			SelectedComponentInstance.ProductionSystemInstance.CopyProductionQueue();
		}

		private void PasteQueue()
		{
			SelectedComponentInstance.ProductionSystemInstance.PasteProductionQueue();
		}

		private void Start()
		{
			ExtraShownForProduction = null;
			MonoSingleton<UIController>.Instance.ToggleEditProductionUIEvent += OnToggleEditProductionUI;
			MonoSingleton<UIController>.Instance.QueuedProductionSelectedEvent += OnQueuedProductionSelectedEvent;
			MonoSingleton<UIController>.Instance.ForceUpdateProductionLayoutItemViewsEvent += OnForceUpdateProductionLayoutItemViews;
			MonoSingleton<UIController>.Instance.ProductionCanceledUIEvent += OnProductionUICanceled;
			copyQueueButton.onClick.AddListener(CopyQueue);
			pasteQueueButton.onClick.AddListener(PasteQueue);
		}

		private void OnToggleEditProductionUI(ProductionInstance productionInstance)
		{
			if (productionInstance == null)
			{
				Log.Warning("OnToggleEditProductionUI - production instance is null", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Selection\\SelectionExtraProduction.cs");
			}
			else
			{
				MonoSingleton<UIController>.Instance.ProductionSettingsPanel.SetUpAndShow(productionInstance);
			}
		}

		private void OnQueuedProductionSelectedEvent(ProductionInstance productionInstance)
		{
			if (productionInstance == null || productionInstance.Blueprint == null || productionInstance.OwnerSystem.HasDisposed)
			{
				ExtraShownForProduction = null;
			}
			else
			{
				OnToggleEditProductionUI(productionInstance);
			}
		}
	}
}
