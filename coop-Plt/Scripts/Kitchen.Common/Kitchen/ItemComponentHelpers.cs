using Platforms;
using Unity.Entities;

namespace Kitchen
{
	public static class ItemComponentHelpers
	{
		public static void SetDynamic<T>(EntityContext ctx, Entity e, T component) where T : IComponentData
		{
			if (component == null)
			{
				return;
			}
			if (PlatformSettings.AllowsDynamicVariables)
			{
				ctx.Set(e, (dynamic)component);
			}
			else if (!(component is CPreventToolStorageAccess data))
			{
				if (!(component is CPreservedOvernight data2))
				{
					if (!(component is CEffectCreator data3))
					{
						if (!(component is CTriggerOrderReset data4))
						{
							if (!(component is CTriggerPatienceReset data5))
							{
								if (!(component is CTriggerLeaveHappy data6))
								{
									if (!(component is CTriggerLeftoverCurrentMeal data7))
									{
										if (!(component is CRefreshesFlowerProviders data8))
										{
											if (!(component is CRefreshesProviderQuantity data9))
											{
												if (!(component is CRefreshesSpecificProvider data10))
												{
													if (!(component is CApplyDecor data11))
													{
														if (!(component is CEquippableTool data12))
														{
															if (!(component is CToolClean data13))
															{
																if (!(component is CToolStorage data14))
																{
																	if (!(component is CToolStorageOnlySameItem data15))
																	{
																		if (!(component is CToolStorageNoTools data16))
																		{
																			if (!(component is CToolInteractionMemory data17))
																			{
																				if (!(component is CDurationTool data18))
																				{
																					if (!(component is CProcessTool data19))
																					{
																						if (!(component is CInstantProcessTool data20))
																						{
																							if (!(component is CSatisfyAnyOrder data21))
																							{
																								if (!(component is CReturnItem data22))
																								{
																									if (!(component is CPreventItemTransfer data23))
																									{
																										if (component is CPreventItemMerge data24)
																										{
																											ctx.Set(e, data24);
																										}
																									}
																									else
																									{
																										ctx.Set(e, data23);
																									}
																								}
																								else
																								{
																									ctx.Set(e, data22);
																								}
																							}
																							else
																							{
																								ctx.Set(e, data21);
																							}
																						}
																						else
																						{
																							ctx.Set(e, data20);
																						}
																					}
																					else
																					{
																						ctx.Set(e, data19);
																					}
																				}
																				else
																				{
																					ctx.Set(e, data18);
																				}
																			}
																			else
																			{
																				ctx.Set(e, data17);
																			}
																		}
																		else
																		{
																			ctx.Set(e, data16);
																		}
																	}
																	else
																	{
																		ctx.Set(e, data15);
																	}
																}
																else
																{
																	ctx.Set(e, data14);
																}
															}
															else
															{
																ctx.Set(e, data13);
															}
														}
														else
														{
															ctx.Set(e, data12);
														}
													}
													else
													{
														ctx.Set(e, data11);
													}
												}
												else
												{
													ctx.Set(e, data10);
												}
											}
											else
											{
												ctx.Set(e, data9);
											}
										}
										else
										{
											ctx.Set(e, data8);
										}
									}
									else
									{
										ctx.Set(e, data7);
									}
								}
								else
								{
									ctx.Set(e, data6);
								}
							}
							else
							{
								ctx.Set(e, data5);
							}
						}
						else
						{
							ctx.Set(e, data4);
						}
					}
					else
					{
						ctx.Set(e, data3);
					}
				}
				else
				{
					ctx.Set(e, data2);
				}
			}
			else
			{
				ctx.Set(e, data);
			}
		}
	}
}
