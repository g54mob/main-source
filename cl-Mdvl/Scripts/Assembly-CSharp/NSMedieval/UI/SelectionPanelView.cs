using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Tutorial;
using NSMedieval.Village;
using UnityEngine;
using UnityEngine.Serialization;

namespace NSMedieval.UI
{
	public class SelectionPanelView : UIView
	{
		[SerializeField]
		private SelectionHeaderView header;

		[SerializeField]
		private SelectionMiddleGenericView body;

		[SerializeField]
		private SelectionMiddleCharacterView bodyCharacter;

		[SerializeField]
		private SelectionMiddleEnemyView bodyEnemy;

		[SerializeField]
		private SelectionMiddleAnimalView bodyAnimal;

		[SerializeField]
		private SelectionFooterView footer;

		[SerializeField]
		private SelectionExtraWorker workerExtraPanel;

		[SerializeField]
		private SelectionExtraEnemy enemyExtraPanel;

		[SerializeField]
		private SelectionExtraStockpile stockpileExtraWindow;

		[SerializeField]
		private SelectionExtraCropfield cropfieldExtraWindow;

		[SerializeField]
		private SelectionExtraProduction productionExtraWindow;

		[SerializeField]
		private SelectionExtraGrave gravesExtraWindow;

		[SerializeField]
		private SelectionExtraMeshVariation meshVariationsExtraWindow;

		[SerializeField]
		private FuelConsumerSelectionExtraPanel fuelConsumerSelectionExtraPanel;

		[FormerlySerializedAs("selectionExtraSiegeWeapon")]
		[SerializeField]
		private SiegeWeaponExtraPanel siegeWeaponExtraPanel;

		[SerializeField]
		private AnimalPenExtraPanel animalPenExtraPanel;

		[SerializeField]
		private RallyPointExtraPanel rallyPointExtraPanel;

		[SerializeField]
		private BellExtraPanel bellExtraPanel;

		[SerializeField]
		private SelectionExtraAnimal animalExtraPanel;

		[SerializeField]
		private SelectionExtraBuildingOwnership buildingOwnershipExtraPanel;

		[SerializeField]
		private SelectionExtraPlayerTriggeredEvent playerTriggeredEventExtraPanel;

		[SerializeField]
		private SignExtraPanel signExtraPanel;

		[NonSerialized]
		private readonly List<SelectionExtraWindowView> extraPanels = new List<SelectionExtraWindowView>();

		public SelectionExtraProduction ProductionExtraWindow => productionExtraWindow;

		private void OnEnable()
		{
			MonoSingleton<UIController>.Instance.ShowWorkerExtraSelectionTab += OnShowWorkerExtraPanelTab;
		}

		private void OnDisable()
		{
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.ShowWorkerExtraSelectionTab -= OnShowWorkerExtraPanelTab;
			}
		}

		public RectTransform GetDraftButtonRectTransform()
		{
			return footer.ActionButtons.FirstOrDefault()?.transform as RectTransform;
		}

		public RectTransform GetHoldGroundButtonRectTransform()
		{
			return footer.WorkerDraftedStancesGroup.GetComponentsInChildren<CustomGrouppedToggle>().FirstOrDefault()?.GetComponent<RectTransform>();
		}

		public void ResetTabIndex()
		{
			if ((bool)body)
			{
				body.ResetTabIndex();
			}
		}

		public override void Hide()
		{
			base.Hide();
			ResetTabIndex();
			HideAllPanels();
		}

		public void SetupPanel(InfoPanelData infoPanelData)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(15, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Selection\\SelectionPanelView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(infoPanelData.Type);
				messageBuilder.AppendLiteral(" Extra panels: ");
				messageBuilder.AppendFormatted(infoPanelData.ExtraPanelViews.Count);
			}
			Log.Debug(messageBuilder);
			Show();
			HideAllPanels();
			footer.Show();
			switch (infoPanelData.Type)
			{
			case InfoPanelDataType.Worker:
				bodyCharacter.gameObject.SetActive(value: true);
				bodyCharacter.InitializeBody(infoPanelData.WorkerBody);
				workerExtraPanel.ShowPanel(infoPanelData.WorkerBody.Humanoid);
				break;
			case InfoPanelDataType.Enemy:
				bodyEnemy.gameObject.SetActive(value: true);
				bodyEnemy.InitializeBody(infoPanelData.EnemyBody);
				enemyExtraPanel.ShowPanel(infoPanelData.EnemyBody.Humanoid);
				break;
			case InfoPanelDataType.Animal:
				bodyAnimal.gameObject.SetActive(value: true);
				bodyAnimal.InitializeBody(infoPanelData.AnimalBody);
				animalExtraPanel.ShowPanel(infoPanelData.AnimalBody.Animal);
				break;
			case InfoPanelDataType.None:
			case InfoPanelDataType.General:
				body.gameObject.SetActive(value: true);
				body.InitializeBody(infoPanelData.Body);
				if (infoPanelData.ExtraPanelViews.FirstOrDefault((SelectionExtraView sew) => sew is InfoPanelProduction) is InfoPanelProduction productionPanel)
				{
					productionExtraWindow.ShowPanel(productionPanel);
				}
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		public void UpdatePanelTick(InfoPanelData infoPanelData)
		{
			if (!MonoSingleton<SelectableObjectManager>.IsInstantiated() || MonoSingleton<SelectableObjectManager>.IsApplicationIsQuitting())
			{
				return;
			}
			if (infoPanelData.Header != null)
			{
				header.InitializeHeader(infoPanelData.Header);
			}
			if (infoPanelData.Footer != null)
			{
				footer.InitializeFooter(infoPanelData.Footer);
			}
			if (infoPanelData.WorkerBody != null)
			{
				bodyCharacter.UpdateData(infoPanelData.WorkerBody);
				workerExtraPanel.UpdateData();
				return;
			}
			if (infoPanelData.EnemyBody != null)
			{
				bodyEnemy.UpdateData(infoPanelData.EnemyBody);
				enemyExtraPanel.UpdateData();
				return;
			}
			if (infoPanelData.AnimalBody != null)
			{
				bodyAnimal.UpdateData(infoPanelData.AnimalBody);
				animalExtraPanel.UpdateData();
				return;
			}
			if (infoPanelData.Body != null)
			{
				body.UpdateBody(infoPanelData.Body);
			}
			if (infoPanelData.ExtraPanelViews.Count == 0)
			{
				foreach (SelectionExtraWindowView extraPanel in extraPanels)
				{
					extraPanel.Hide();
				}
				return;
			}
			UpdateExtraPanel(infoPanelData);
		}

		private void UpdateExtraPanel(InfoPanelData infoPanelData)
		{
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(15, 2, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Selection\\SelectionPanelView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(infoPanelData.Header.ObjectName);
				messageBuilder.AppendLiteral(" Extra panels: ");
				messageBuilder.AppendFormatted(infoPanelData.ExtraPanelViews.Count);
			}
			Log.Trace(messageBuilder);
			foreach (SelectionExtraView extraPanelView in infoPanelData.ExtraPanelViews)
			{
				if (extraPanelView == null)
				{
					continue;
				}
				messageBuilder = new FVLogTraceInterpolationHandler(12, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Selection\\SelectionPanelView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(extraPanelView.GetType().FullName);
					messageBuilder.AppendLiteral(" extra panel");
				}
				Log.Trace(messageBuilder);
				SelectionExtraView selectionExtraView = extraPanelView;
				if (selectionExtraView is InfoPanelProduction { PossibleProductions: var possibleProductions } infoPanelProduction)
				{
					if (possibleProductions != null && possibleProductions.Count > 0)
					{
						if (!productionExtraWindow.IsVisible)
						{
							productionExtraWindow.ShowPanel(infoPanelProduction);
							break;
						}
						productionExtraWindow.UpdateProduction(infoPanelProduction);
					}
				}
				else if (!(selectionExtraView is InfoPanelGraves infoPanelGraves))
				{
					if (!(selectionExtraView is InfoPanelRallyPoint infoPanel))
					{
						if (!(selectionExtraView is InfoPanelBell infoPanel2))
						{
							if (!(selectionExtraView is InfoPanelMeshVariations infoPanelMeshVariations))
							{
								if (!(selectionExtraView is InfoPanelSign infoPanelSign))
								{
									if (!(selectionExtraView is InfoPanelBuildingOwnership infoPanelBuildingOwnership))
									{
										if (!(selectionExtraView is InfoPanelPlayerTriggeredEvent playerTriggeredEventInfo))
										{
											if (!(selectionExtraView is InfoPanelCropfield infoPanelCropfield))
											{
												if (!(selectionExtraView is InfoPanelStockpile infoPanelStockpile))
												{
													if (selectionExtraView is InfoPanelFuelConsumer infoPanelFuelConsumer)
													{
														if (!infoPanelFuelConsumer.AnyHasDisposed)
														{
															fuelConsumerSelectionExtraPanel.UpdatePanel(infoPanelFuelConsumer);
														}
													}
													else if (selectionExtraView is InfoPanelSiegeWeapon infoPanelStockpile2)
													{
														siegeWeaponExtraPanel.UpdatePanel(infoPanelStockpile2);
													}
												}
												else
												{
													if (TutorialManager.IsTutorialActive)
													{
														break;
													}
													stockpileExtraWindow.UpdatePanel(infoPanelStockpile);
												}
											}
											else
											{
												cropfieldExtraWindow.UpdatePanel(infoPanelCropfield);
											}
											continue;
										}
										BaseBuildingBlueprint byID = Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetByID(infoPanelData.Body.ObjectId);
										if ((object)byID != null)
										{
											List<string> playerTriggeredEvents = byID.PlayerTriggeredEvents;
											if (playerTriggeredEvents != null && playerTriggeredEvents.Count > 0)
											{
												playerTriggeredEventExtraPanel.UpdatePanel(playerTriggeredEventInfo);
											}
										}
									}
									else
									{
										buildingOwnershipExtraPanel.UpdatePanel(infoPanelBuildingOwnership.BaseBuildingInstance);
									}
								}
								else
								{
									signExtraPanel.UpdatePanel(infoPanelSign);
								}
							}
							else if (infoPanelMeshVariations.Selection.All((BaseBuildingInstance buildingInstance) => buildingInstance.FactionOwnership == FactionOwnership.Player))
							{
								if (infoPanelMeshVariations is InfoPanelPenMarker infoPanelMeshVariations2)
								{
									animalPenExtraPanel.UpdatePanel(infoPanelMeshVariations2);
									break;
								}
								meshVariationsExtraWindow.UpdatePanel(infoPanelMeshVariations);
							}
						}
						else
						{
							bellExtraPanel.UpdatePanel(infoPanel2);
						}
					}
					else
					{
						rallyPointExtraPanel.UpdatePanel(infoPanel);
					}
				}
				else
				{
					gravesExtraWindow.UpdatePanel(infoPanelGraves);
				}
			}
		}

		internal void Initialize()
		{
			extraPanels.Add(workerExtraPanel);
			extraPanels.Add(stockpileExtraWindow);
			extraPanels.Add(cropfieldExtraWindow);
			extraPanels.Add(productionExtraWindow);
			extraPanels.Add(gravesExtraWindow);
			extraPanels.Add(meshVariationsExtraWindow);
			extraPanels.Add(fuelConsumerSelectionExtraPanel);
			extraPanels.Add(animalPenExtraPanel);
			extraPanels.Add(rallyPointExtraPanel);
			extraPanels.Add(bellExtraPanel);
			extraPanels.Add(enemyExtraPanel);
			extraPanels.Add(animalExtraPanel);
			extraPanels.Add(buildingOwnershipExtraPanel);
			extraPanels.Add(playerTriggeredEventExtraPanel);
			extraPanels.Add(siegeWeaponExtraPanel);
			extraPanels.Add(signExtraPanel);
			foreach (SelectionExtraWindowView extraPanel in extraPanels)
			{
				extraPanel.Initialize();
			}
			HideAllPanels();
		}

		private void HideAllPanels()
		{
			foreach (SelectionExtraWindowView extraPanel in extraPanels)
			{
				extraPanel.Hide();
			}
			footer.Hide();
			body.gameObject.SetActive(value: false);
			bodyCharacter.gameObject.SetActive(value: false);
			bodyEnemy.gameObject.SetActive(value: false);
			bodyAnimal.gameObject.SetActive(value: false);
		}

		private void OnShowWorkerExtraPanelTab(int tabIndex)
		{
			workerExtraPanel.SelectedPanel = tabIndex;
		}
	}
}
