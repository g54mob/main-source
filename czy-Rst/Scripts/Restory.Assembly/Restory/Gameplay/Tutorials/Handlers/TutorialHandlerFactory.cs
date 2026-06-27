using System;
using Restory.Data.Tutorials;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Tutorials.Handlers
{
	public class TutorialHandlerFactory : IFactory<TutorialBase, TutorialHandlerBase>, IFactory
	{
		private const string RecommendedHandlerSuffix = "Handler";

		private readonly DiContainer diContainer;

		[Inject]
		public TutorialHandlerFactory(DiContainer diContainer)
		{
			this.diContainer = diContainer;
		}

		public TutorialHandlerBase Create(TutorialBase tutorial)
		{
			TutorialHandlerBase tutorialHandlerBase;
			if (!(tutorial is FirstRegularPaymentTutorial))
			{
				if (!(tutorial is FirstDeviceInteractionTutorial))
				{
					if (!(tutorial is FirstCashTutorial))
					{
						if (!(tutorial is ExitDisassembleTutorial))
						{
							if (!(tutorial is RadioMusicTutorial))
							{
								if (!(tutorial is WorkOrderShipmentTutorial))
								{
									if (!(tutorial is FirstElementDeviceTutorial))
									{
										if (!(tutorial is FirstEmailClientOpeningTutorial))
										{
											if (!(tutorial is NotebookOpenTutorial))
											{
												if (!(tutorial is InventoryOpenTutorial))
												{
													if (!(tutorial is CameraRotationTutorial))
													{
														if (!(tutorial is BillOpenTutorial))
														{
															if (!(tutorial is ReplaceDeviceTutorial))
															{
																if (!(tutorial is FirstDragElementToCleaningTutorial))
																{
																	if (!(tutorial is DeviceDisassembleModeRotationTutorial))
																	{
																		if (!(tutorial is DeviceDisassembleModeZoomTutorial))
																		{
																			if (!(tutorial is PaintingToolTutorial))
																			{
																				throw new ArgumentException($"Unknown Tutorial type: {tutorial.GetType()}");
																			}
																			tutorialHandlerBase = InstantiateHandler<PaintingToolTutorialHandler>(tutorial);
																		}
																		else
																		{
																			tutorialHandlerBase = InstantiateHandler<DeviceDisassembleModeZoomTutorialHandler>(tutorial);
																		}
																	}
																	else
																	{
																		tutorialHandlerBase = InstantiateHandler<DeviceDisassembleModeRotationTutorialHandler>(tutorial);
																	}
																}
																else
																{
																	tutorialHandlerBase = InstantiateHandler<FirstDragElementToCleaningTutorialHandler>(tutorial);
																}
															}
															else
															{
																tutorialHandlerBase = InstantiateHandler<ReplaceDeviceTutorialHandler>(tutorial);
															}
														}
														else
														{
															tutorialHandlerBase = InstantiateHandler<BillOpenTutorialHandler>(tutorial);
														}
													}
													else
													{
														tutorialHandlerBase = InstantiateHandler<CameraRotationTutorialHandler>(tutorial);
													}
												}
												else
												{
													tutorialHandlerBase = InstantiateHandler<InventoryOpenTutorialHandler>(tutorial);
												}
											}
											else
											{
												tutorialHandlerBase = InstantiateHandler<NotebookOpenTutorialHandler>(tutorial);
											}
										}
										else
										{
											tutorialHandlerBase = InstantiateHandler<FirstEmailClientOpeningTutorialHandler>(tutorial);
										}
									}
									else
									{
										tutorialHandlerBase = InstantiateHandler<FirstElementDeviceTutorialHandler>(tutorial);
									}
								}
								else
								{
									tutorialHandlerBase = InstantiateHandler<WorkOrderShipmentTutorialHandler>(tutorial);
								}
							}
							else
							{
								tutorialHandlerBase = InstantiateHandler<RadioMusicTutorialHandler>(tutorial);
							}
						}
						else
						{
							tutorialHandlerBase = InstantiateHandler<ExitDisassembleTutorialHandler>(tutorial);
						}
					}
					else
					{
						tutorialHandlerBase = InstantiateHandler<FirstCashTutorialHandler>(tutorial);
					}
				}
				else
				{
					tutorialHandlerBase = InstantiateHandler<FirstDeviceInteractionTutorialHandler>(tutorial);
				}
			}
			else
			{
				tutorialHandlerBase = InstantiateHandler<FirstRegularPaymentTutorialHandler>(tutorial);
			}
			TutorialHandlerBase tutorialHandlerBase2 = tutorialHandlerBase;
			string text = tutorial.GetType().Name + "Handler";
			string name = tutorialHandlerBase2.GetType().Name;
			if (!string.Equals(name, text, StringComparison.Ordinal))
			{
				Debug.LogError("Handler type name '" + name + "' does not match expected '" + text + "'. Recommended class name: '" + text + "'.");
			}
			return tutorialHandlerBase2;
		}

		private T InstantiateHandler<T>(TutorialBase tutorial) where T : TutorialHandlerBase
		{
			return diContainer.Instantiate<T>(new object[1] { tutorial });
		}
	}
}
