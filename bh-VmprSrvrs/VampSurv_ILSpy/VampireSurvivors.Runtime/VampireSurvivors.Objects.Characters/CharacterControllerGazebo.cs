using System;
using System.Collections.Generic;
using System.Globalization;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerGazebo : CharacterController
{
	private float OverhealTriggerValue = 30f;

	private Timer _overHealTimer;

	private List<WeaponBonusPair> _earlyBonusList;

	private List<WeaponBonusPair> _crapBonusList;

	private List<WeaponBonusPair> _obtainedBonusList;

	private int maxBonusTimes;

	private float cachedSize;

	private Timer _food_sequentialTimer;

	private float _food_BonusTimer;

	private float _food_BonusDelay;

	public unsafe override void AfterFullInitialization()
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Expected O, but got Unknown
		//IL_0390: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Expected O, but got Unknown
		//IL_047f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0484: Expected O, but got Unknown
		//IL_056e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0573: Expected O, but got Unknown
		//IL_065d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0662: Expected O, but got Unknown
		//IL_074c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0751: Expected O, but got Unknown
		//IL_083b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0840: Expected O, but got Unknown
		//IL_092a: Unknown result type (might be due to invalid IL or missing references)
		//IL_092f: Expected O, but got Unknown
		//IL_0a19: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1e: Expected O, but got Unknown
		//IL_0b08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0d: Expected O, but got Unknown
		//IL_0bf7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bfc: Expected O, but got Unknown
		//IL_0ce6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ceb: Expected O, but got Unknown
		//IL_0dd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dda: Expected O, but got Unknown
		//IL_0ec4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec9: Expected O, but got Unknown
		//IL_0fb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb8: Expected O, but got Unknown
		//IL_10a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a7: Expected O, but got Unknown
		//IL_1191: Unknown result type (might be due to invalid IL or missing references)
		//IL_1196: Expected O, but got Unknown
		//IL_1280: Unknown result type (might be due to invalid IL or missing references)
		//IL_1285: Expected O, but got Unknown
		//IL_136f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1374: Expected O, but got Unknown
		//IL_145e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1463: Expected O, but got Unknown
		//IL_149d: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a2: Expected O, but got Unknown
		//IL_14dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_14e1: Expected O, but got Unknown
		//IL_1d8d: Expected I, but got O
		//IL_160f->IL160f: Incompatible stack heights: 1 vs 0
		base.AfterFullInitialization();
		List<object> earlyBonusList = (List<object>)(object)_earlyBonusList;
		List<object> list = null;
		Action<float, float> action = default(Action<float, float>);
		while (true)
		{
			WeaponBonusPair weaponBonusPair = null;
			weaponBonusPair.weaponType = WeaponType.REGEN;
			weaponBonusPair.bonusValue = 0.5f;
			if (_earlyBonusList == null)
			{
				break;
			}
			int version = earlyBonusList._version + 1;
			earlyBonusList._version = version;
			object[] items = earlyBonusList._items;
			if (earlyBonusList._items == null)
			{
				break;
			}
			if (earlyBonusList._size >= items.Length)
			{
				((List<object>)(object)_earlyBonusList).AddWithResize((object)weaponBonusPair);
			}
			else
			{
				int num = earlyBonusList._size + 1;
				earlyBonusList._size = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			list = (List<object>)(list + 1);
			if ((nint)list < 1)
			{
				continue;
			}
			List<object> earlyBonusList2 = (List<object>)(object)_earlyBonusList;
			List<object> list2 = null;
			while (true)
			{
				WeaponBonusPair weaponBonusPair2 = null;
				weaponBonusPair2.weaponType = WeaponType.ARMOR;
				weaponBonusPair2.bonusValue = 1f;
				if (_earlyBonusList == null)
				{
					break;
				}
				int version2 = earlyBonusList2._version + 1;
				earlyBonusList2._version = version2;
				object[] items2 = earlyBonusList2._items;
				if (earlyBonusList2._items == null)
				{
					break;
				}
				if (earlyBonusList2._size >= items2.Length)
				{
					((List<object>)(object)_earlyBonusList).AddWithResize((object)weaponBonusPair2);
				}
				else
				{
					int num2 = earlyBonusList2._size + 1;
					earlyBonusList2._size = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				list2 = (List<object>)(list2 + 1);
				if ((nint)list2 < 1)
				{
					continue;
				}
				List<object> earlyBonusList3 = (List<object>)(object)_earlyBonusList;
				List<object> list3 = null;
				while (true)
				{
					WeaponBonusPair weaponBonusPair3 = null;
					weaponBonusPair3.weaponType = WeaponType.MAXHEALTH;
					weaponBonusPair3.bonusValue = 40f;
					if (_earlyBonusList == null)
					{
						break;
					}
					int version3 = earlyBonusList3._version + 1;
					earlyBonusList3._version = version3;
					object[] items3 = earlyBonusList3._items;
					if (earlyBonusList3._items == null)
					{
						break;
					}
					if (earlyBonusList3._size >= items3.Length)
					{
						((List<object>)(object)_earlyBonusList).AddWithResize((object)weaponBonusPair3);
					}
					else
					{
						int num3 = earlyBonusList3._size + 1;
						earlyBonusList3._size = num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					list3 = (List<object>)(list3 + 1);
					if ((nint)list3 < 1)
					{
						continue;
					}
					List<object> earlyBonusList4 = (List<object>)(object)_earlyBonusList;
					List<object> list4 = null;
					while (true)
					{
						WeaponBonusPair weaponBonusPair4 = null;
						weaponBonusPair4.weaponType = WeaponType.REVIVAL;
						weaponBonusPair4.bonusValue = 1f;
						if (_earlyBonusList == null)
						{
							break;
						}
						int version4 = earlyBonusList4._version + 1;
						earlyBonusList4._version = version4;
						object[] items4 = earlyBonusList4._items;
						if (earlyBonusList4._items == null)
						{
							break;
						}
						if (earlyBonusList4._size >= items4.Length)
						{
							((List<object>)(object)_earlyBonusList).AddWithResize((object)weaponBonusPair4);
						}
						else
						{
							int num4 = earlyBonusList4._size + 1;
							earlyBonusList4._size = num4;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						list4 = (List<object>)(list4 + 1);
						if ((nint)list4 < 1)
						{
							continue;
						}
						List<object> earlyBonusList5 = (List<object>)(object)_earlyBonusList;
						List<object> list5 = null;
						while (true)
						{
							WeaponBonusPair weaponBonusPair5 = null;
							weaponBonusPair5.weaponType = WeaponType.MOVESPEED;
							weaponBonusPair5.bonusValue = 0.2f;
							if (_earlyBonusList == null)
							{
								break;
							}
							int version5 = earlyBonusList5._version + 1;
							earlyBonusList5._version = version5;
							object[] items5 = earlyBonusList5._items;
							if (earlyBonusList5._items == null)
							{
								break;
							}
							if (earlyBonusList5._size >= items5.Length)
							{
								((List<object>)(object)_earlyBonusList).AddWithResize((object)weaponBonusPair5);
							}
							else
							{
								int num5 = earlyBonusList5._size + 1;
								earlyBonusList5._size = num5;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							list5 = (List<object>)(list5 + 1);
							if ((nint)list5 < 1)
							{
								continue;
							}
							List<object> earlyBonusList6 = (List<object>)(object)_earlyBonusList;
							List<object> list6 = null;
							while (true)
							{
								WeaponBonusPair weaponBonusPair6 = null;
								weaponBonusPair6.weaponType = WeaponType.COOLDOWN;
								weaponBonusPair6.bonusValue = -0.1f;
								if (_earlyBonusList == null)
								{
									break;
								}
								int version6 = earlyBonusList6._version + 1;
								earlyBonusList6._version = version6;
								object[] items6 = earlyBonusList6._items;
								if (earlyBonusList6._items == null)
								{
									break;
								}
								if (earlyBonusList6._size >= items6.Length)
								{
									((List<object>)(object)_earlyBonusList).AddWithResize((object)weaponBonusPair6);
								}
								else
								{
									int num6 = earlyBonusList6._size + 1;
									earlyBonusList6._size = num6;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								list6 = (List<object>)(list6 + 1);
								if ((nint)list6 < 1)
								{
									continue;
								}
								List<object> earlyBonusList7 = (List<object>)(object)_earlyBonusList;
								List<object> list7 = null;
								while (true)
								{
									WeaponBonusPair weaponBonusPair7 = null;
									weaponBonusPair7.weaponType = WeaponType.AMOUNT;
									weaponBonusPair7.bonusValue = 1f;
									if (_earlyBonusList == null)
									{
										break;
									}
									int version7 = earlyBonusList7._version + 1;
									earlyBonusList7._version = version7;
									object[] items7 = earlyBonusList7._items;
									if (earlyBonusList7._items == null)
									{
										break;
									}
									if (earlyBonusList7._size >= items7.Length)
									{
										((List<object>)(object)_earlyBonusList).AddWithResize((object)weaponBonusPair7);
									}
									else
									{
										int num7 = earlyBonusList7._size + 1;
										earlyBonusList7._size = num7;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									}
									list7 = (List<object>)(list7 + 1);
									if ((nint)list7 < 1)
									{
										continue;
									}
									List<object> earlyBonusList8 = (List<object>)(object)_earlyBonusList;
									List<object> list8 = null;
									while (true)
									{
										WeaponBonusPair weaponBonusPair8 = null;
										weaponBonusPair8.weaponType = WeaponType.MAGNET;
										weaponBonusPair8.bonusValue = 1f;
										if (_earlyBonusList == null)
										{
											break;
										}
										int version8 = earlyBonusList8._version + 1;
										earlyBonusList8._version = version8;
										object[] items8 = earlyBonusList8._items;
										if (earlyBonusList8._items == null)
										{
											break;
										}
										if (earlyBonusList8._size >= items8.Length)
										{
											((List<object>)(object)_earlyBonusList).AddWithResize((object)weaponBonusPair8);
										}
										else
										{
											int num8 = earlyBonusList8._size + 1;
											earlyBonusList8._size = num8;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										list8 = (List<object>)(list8 + 1);
										if ((nint)list8 < 1)
										{
											continue;
										}
										List<object> earlyBonusList9 = (List<object>)(object)_earlyBonusList;
										List<object> list9 = null;
										while (true)
										{
											WeaponBonusPair weaponBonusPair9 = null;
											weaponBonusPair9.weaponType = WeaponType.POWER;
											weaponBonusPair9.bonusValue = 0.2f;
											if (_earlyBonusList == null)
											{
												break;
											}
											int version9 = earlyBonusList9._version + 1;
											earlyBonusList9._version = version9;
											object[] items9 = earlyBonusList9._items;
											if (earlyBonusList9._items == null)
											{
												break;
											}
											if (earlyBonusList9._size >= items9.Length)
											{
												((List<object>)(object)_earlyBonusList).AddWithResize((object)weaponBonusPair9);
											}
											else
											{
												int num9 = earlyBonusList9._size + 1;
												earlyBonusList9._size = num9;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											}
											list9 = (List<object>)(list9 + 1);
											if ((nint)list9 < 1)
											{
												continue;
											}
											List<object> earlyBonusList10 = (List<object>)(object)_earlyBonusList;
											List<object> list10 = null;
											while (true)
											{
												WeaponBonusPair weaponBonusPair10 = null;
												weaponBonusPair10.weaponType = WeaponType.SPEED;
												weaponBonusPair10.bonusValue = 0.2f;
												if (_earlyBonusList == null)
												{
													break;
												}
												int version10 = earlyBonusList10._version + 1;
												earlyBonusList10._version = version10;
												object[] items10 = earlyBonusList10._items;
												if (earlyBonusList10._items == null)
												{
													break;
												}
												if (earlyBonusList10._size >= items10.Length)
												{
													((List<object>)(object)_earlyBonusList).AddWithResize((object)weaponBonusPair10);
												}
												else
												{
													int num10 = earlyBonusList10._size + 1;
													earlyBonusList10._size = num10;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												}
												list10 = (List<object>)(list10 + 1);
												if ((nint)list10 < 1)
												{
													continue;
												}
												List<object> earlyBonusList11 = (List<object>)(object)_earlyBonusList;
												List<object> list11 = null;
												while (true)
												{
													WeaponBonusPair weaponBonusPair11 = null;
													weaponBonusPair11.weaponType = WeaponType.DURATION;
													weaponBonusPair11.bonusValue = 0.2f;
													if (_earlyBonusList == null)
													{
														break;
													}
													int version11 = earlyBonusList11._version + 1;
													earlyBonusList11._version = version11;
													object[] items11 = earlyBonusList11._items;
													if (earlyBonusList11._items == null)
													{
														break;
													}
													if (earlyBonusList11._size >= items11.Length)
													{
														((List<object>)(object)_earlyBonusList).AddWithResize((object)weaponBonusPair11);
													}
													else
													{
														int num11 = earlyBonusList11._size + 1;
														earlyBonusList11._size = num11;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													}
													list11 = (List<object>)(list11 + 1);
													if ((nint)list11 < 1)
													{
														continue;
													}
													List<object> earlyBonusList12 = (List<object>)(object)_earlyBonusList;
													List<object> list12 = null;
													while (true)
													{
														WeaponBonusPair weaponBonusPair12 = null;
														weaponBonusPair12.weaponType = WeaponType.AREA;
														weaponBonusPair12.bonusValue = 0.2f;
														if (_earlyBonusList == null)
														{
															break;
														}
														int version12 = earlyBonusList12._version + 1;
														earlyBonusList12._version = version12;
														object[] items12 = earlyBonusList12._items;
														if (earlyBonusList12._items == null)
														{
															break;
														}
														if (earlyBonusList12._size >= items12.Length)
														{
															((List<object>)(object)_earlyBonusList).AddWithResize((object)weaponBonusPair12);
														}
														else
														{
															int num12 = earlyBonusList12._size + 1;
															earlyBonusList12._size = num12;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														}
														list12 = (List<object>)(list12 + 1);
														if ((nint)list12 < 1)
														{
															continue;
														}
														List<object> crapBonusList = (List<object>)(object)_crapBonusList;
														List<object> list13 = null;
														while (true)
														{
															WeaponBonusPair weaponBonusPair13 = null;
															weaponBonusPair13.weaponType = WeaponType.REGEN;
															weaponBonusPair13.bonusValue = 0.05f;
															if (_crapBonusList == null)
															{
																break;
															}
															int version13 = crapBonusList._version + 1;
															crapBonusList._version = version13;
															object[] items13 = crapBonusList._items;
															if (crapBonusList._items == null)
															{
																break;
															}
															if (crapBonusList._size >= items13.Length)
															{
																((List<object>)(object)_crapBonusList).AddWithResize((object)weaponBonusPair13);
															}
															else
															{
																int num13 = crapBonusList._size + 1;
																crapBonusList._size = num13;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															}
															list13 = (List<object>)(list13 + 1);
															if ((nint)list13 < 30)
															{
																continue;
															}
															List<object> crapBonusList2 = (List<object>)(object)_crapBonusList;
															List<object> list14 = null;
															while (true)
															{
																WeaponBonusPair weaponBonusPair14 = null;
																weaponBonusPair14.weaponType = WeaponType.ARMOR;
																weaponBonusPair14.bonusValue = 0.04f;
																if (_crapBonusList == null)
																{
																	break;
																}
																int version14 = crapBonusList2._version + 1;
																crapBonusList2._version = version14;
																object[] items14 = crapBonusList2._items;
																if (crapBonusList2._items == null)
																{
																	break;
																}
																if (crapBonusList2._size >= items14.Length)
																{
																	((List<object>)(object)_crapBonusList).AddWithResize((object)weaponBonusPair14);
																}
																else
																{
																	int num14 = crapBonusList2._size + 1;
																	crapBonusList2._size = num14;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																}
																list14 = (List<object>)(list14 + 1);
																if ((nint)list14 < 30)
																{
																	continue;
																}
																List<object> crapBonusList3 = (List<object>)(object)_crapBonusList;
																List<object> list15 = null;
																while (true)
																{
																	WeaponBonusPair weaponBonusPair15 = null;
																	weaponBonusPair15.weaponType = WeaponType.MAXHEALTH;
																	weaponBonusPair15.bonusValue = 6f;
																	if (_crapBonusList == null)
																	{
																		break;
																	}
																	int version15 = crapBonusList3._version + 1;
																	crapBonusList3._version = version15;
																	object[] items15 = crapBonusList3._items;
																	if (crapBonusList3._items == null)
																	{
																		break;
																	}
																	if (crapBonusList3._size >= items15.Length)
																	{
																		((List<object>)(object)_crapBonusList).AddWithResize((object)weaponBonusPair15);
																	}
																	else
																	{
																		int num15 = crapBonusList3._size + 1;
																		crapBonusList3._size = num15;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																	}
																	list15 = (List<object>)(list15 + 1);
																	if ((nint)list15 < 30)
																	{
																		continue;
																	}
																	List<object> crapBonusList4 = (List<object>)(object)_crapBonusList;
																	List<object> list16 = null;
																	while (true)
																	{
																		WeaponBonusPair weaponBonusPair16 = null;
																		weaponBonusPair16.weaponType = WeaponType.MOVESPEED;
																		weaponBonusPair16.bonusValue = 0.01f;
																		if (_crapBonusList == null)
																		{
																			break;
																		}
																		int version16 = crapBonusList4._version + 1;
																		crapBonusList4._version = version16;
																		object[] items16 = crapBonusList4._items;
																		if (crapBonusList4._items == null)
																		{
																			break;
																		}
																		if (crapBonusList4._size >= items16.Length)
																		{
																			((List<object>)(object)_crapBonusList).AddWithResize((object)weaponBonusPair16);
																		}
																		else
																		{
																			int num16 = crapBonusList4._size + 1;
																			crapBonusList4._size = num16;
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																		}
																		list16 = (List<object>)(list16 + 1);
																		if ((nint)list16 < 30)
																		{
																			continue;
																		}
																		List<object> crapBonusList5 = (List<object>)(object)_crapBonusList;
																		List<object> list17 = null;
																		while (true)
																		{
																			WeaponBonusPair weaponBonusPair17 = null;
																			weaponBonusPair17.weaponType = WeaponType.COOLDOWN;
																			weaponBonusPair17.bonusValue = -0.005f;
																			if (_crapBonusList == null)
																			{
																				break;
																			}
																			int version17 = crapBonusList5._version + 1;
																			crapBonusList5._version = version17;
																			object[] items17 = crapBonusList5._items;
																			if (crapBonusList5._items == null)
																			{
																				break;
																			}
																			if (crapBonusList5._size >= items17.Length)
																			{
																				((List<object>)(object)_crapBonusList).AddWithResize((object)weaponBonusPair17);
																			}
																			else
																			{
																				int num17 = crapBonusList5._size + 1;
																				crapBonusList5._size = num17;
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																			}
																			list17 = (List<object>)(list17 + 1);
																			if ((nint)list17 < 30)
																			{
																				continue;
																			}
																			List<object> crapBonusList6 = (List<object>)(object)_crapBonusList;
																			List<object> list18 = null;
																			while (true)
																			{
																				WeaponBonusPair weaponBonusPair18 = null;
																				weaponBonusPair18.weaponType = WeaponType.AMOUNT;
																				weaponBonusPair18.bonusValue = 0.04f;
																				if (_crapBonusList == null)
																				{
																					break;
																				}
																				int version18 = crapBonusList6._version + 1;
																				crapBonusList6._version = version18;
																				object[] items18 = crapBonusList6._items;
																				if (crapBonusList6._items == null)
																				{
																					break;
																				}
																				if (crapBonusList6._size >= items18.Length)
																				{
																					((List<object>)(object)_crapBonusList).AddWithResize((object)weaponBonusPair18);
																				}
																				else
																				{
																					int num18 = crapBonusList6._size + 1;
																					crapBonusList6._size = num18;
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																				}
																				list18 = (List<object>)(list18 + 1);
																				if ((nint)list18 < 30)
																				{
																					continue;
																				}
																				List<object> crapBonusList7 = (List<object>)(object)_crapBonusList;
																				List<object> list19 = null;
																				while (true)
																				{
																					WeaponBonusPair weaponBonusPair19 = null;
																					weaponBonusPair19.weaponType = WeaponType.REVIVAL;
																					weaponBonusPair19.bonusValue = 0.08f;
																					if (_crapBonusList == null)
																					{
																						break;
																					}
																					int version19 = crapBonusList7._version + 1;
																					crapBonusList7._version = version19;
																					object[] items19 = crapBonusList7._items;
																					if (crapBonusList7._items == null)
																					{
																						break;
																					}
																					if (crapBonusList7._size >= items19.Length)
																					{
																						((List<object>)(object)_crapBonusList).AddWithResize((object)weaponBonusPair19);
																					}
																					else
																					{
																						int num19 = crapBonusList7._size + 1;
																						crapBonusList7._size = num19;
																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																					}
																					list19 = (List<object>)(list19 + 1);
																					if ((nint)list19 < 30)
																					{
																						continue;
																					}
																					List<object> crapBonusList8 = (List<object>)(object)_crapBonusList;
																					List<object> list20 = null;
																					while (true)
																					{
																						WeaponBonusPair weaponBonusPair20 = null;
																						weaponBonusPair20.weaponType = WeaponType.MAGNET;
																						weaponBonusPair20.bonusValue = 0.5f;
																						if (_crapBonusList == null)
																						{
																							break;
																						}
																						int version20 = crapBonusList8._version + 1;
																						crapBonusList8._version = version20;
																						object[] items20 = crapBonusList8._items;
																						if (crapBonusList8._items == null)
																						{
																							break;
																						}
																						if (crapBonusList8._size >= items20.Length)
																						{
																							((List<object>)(object)_crapBonusList).AddWithResize((object)weaponBonusPair20);
																						}
																						else
																						{
																							int num20 = crapBonusList8._size + 1;
																							crapBonusList8._size = num20;
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																						}
																						list20 = (List<object>)(list20 + 1);
																						if ((nint)list20 < 30)
																						{
																							continue;
																						}
																						List<object> crapBonusList9 = (List<object>)(object)_crapBonusList;
																						List<object> list21 = null;
																						while (true)
																						{
																							WeaponBonusPair weaponBonusPair21 = null;
																							weaponBonusPair21.weaponType = WeaponType.POWER;
																							weaponBonusPair21.bonusValue = 0.01f;
																							if (_crapBonusList == null)
																							{
																								break;
																							}
																							int version21 = crapBonusList9._version + 1;
																							crapBonusList9._version = version21;
																							object[] items21 = crapBonusList9._items;
																							if (crapBonusList9._items == null)
																							{
																								break;
																							}
																							if (crapBonusList9._size >= items21.Length)
																							{
																								((List<object>)(object)_crapBonusList).AddWithResize((object)weaponBonusPair21);
																							}
																							else
																							{
																								int num21 = crapBonusList9._size + 1;
																								crapBonusList9._size = num21;
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																							}
																							list21 = (List<object>)(list21 + 1);
																							if ((nint)list21 < 30)
																							{
																								continue;
																							}
																							List<object> crapBonusList10 = (List<object>)(object)_crapBonusList;
																							List<object> list22 = null;
																							while (true)
																							{
																								WeaponBonusPair weaponBonusPair22 = null;
																								weaponBonusPair22.weaponType = WeaponType.SPEED;
																								weaponBonusPair22.bonusValue = 0.01f;
																								if (_crapBonusList == null)
																								{
																									break;
																								}
																								int version22 = crapBonusList10._version + 1;
																								crapBonusList10._version = version22;
																								object[] items22 = crapBonusList10._items;
																								if (crapBonusList10._items == null)
																								{
																									break;
																								}
																								if (crapBonusList10._size >= items22.Length)
																								{
																									((List<object>)(object)_crapBonusList).AddWithResize((object)weaponBonusPair22);
																								}
																								else
																								{
																									int num22 = crapBonusList10._size + 1;
																									crapBonusList10._size = num22;
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																								}
																								list22 = (List<object>)(list22 + 1);
																								if ((nint)list22 < 30)
																								{
																									continue;
																								}
																								List<object> list23 = null;
																								while (true)
																								{
																									WeaponBonusPair weaponBonusPair23 = null;
																									weaponBonusPair23.weaponType = WeaponType.DURATION;
																									weaponBonusPair23.bonusValue = 0.01f;
																									if (_crapBonusList == null)
																									{
																										break;
																									}
																									((List<object>)(object)_crapBonusList).Add((object)weaponBonusPair23);
																									list23 = (List<object>)(list23 + 1);
																									if ((nint)list23 < 30)
																									{
																										continue;
																									}
																									List<object> list24 = null;
																									while (true)
																									{
																										WeaponBonusPair weaponBonusPair24 = null;
																										weaponBonusPair24.weaponType = WeaponType.AREA;
																										weaponBonusPair24.bonusValue = 0.01f;
																										if (_crapBonusList == null)
																										{
																											break;
																										}
																										((List<object>)(object)_crapBonusList).Add((object)weaponBonusPair24);
																										list24 = (List<object>)(list24 + 1);
																										if ((nint)list24 >= 30)
																										{
																											Extensions.Shuffle((IList<object>)_crapBonusList);
																											Extensions.Shuffle((IList<object>)_earlyBonusList);
																											List<WeaponBonusPair> earlyBonusList13 = _earlyBonusList;
																											if (_earlyBonusList == null)
																											{
																												break;
																											}
																											List<WeaponBonusPair> crapBonusList11 = _crapBonusList;
																											maxBonusTimes = earlyBonusList13._size;
																											if (_crapBonusList == null)
																											{
																												break;
																											}
																											int num23 = earlyBonusList13._size + crapBonusList11._size;
																											maxBonusTimes = num23;
																											Action<float, float> b = null;
																											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE6B0");
																											Delegate obj = Delegate.Combine(base._onHpRecoveryCallback, b);
																											bool flag = (object)obj == null;
																											Action<float, float> onHpRecoveryCallback = null;
																											if (!flag)
																											{
																												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																												bool flag2 = action == null;
																												onHpRecoveryCallback = action;
																											}
																											base._onHpRecoveryCallback = onHpRecoveryCallback;
																											List<object> cachedTransform = (List<object>)(object)base._cachedTransform;
																											if ((object)base._cachedTransform == null)
																											{
																												break;
																											}
																											bool flag3 = cachedTransform._items == null;
																											float ret;
																											Transform.get_localScale_Injected((IntPtr)cachedTransform._items, out *(Vector3*)(&ret));
																											cachedSize = ret;
																											return;
																										}
																									}
																									break;
																								}
																								break;
																							}
																							break;
																						}
																						break;
																					}
																					break;
																				}
																				break;
																			}
																			break;
																		}
																		break;
																	}
																	break;
																}
																break;
															}
															break;
														}
														break;
													}
													break;
												}
												break;
											}
											break;
										}
										break;
									}
									break;
								}
								break;
							}
							break;
						}
						break;
					}
					break;
				}
				break;
			}
			break;
		}
		throw new NullReferenceException();
	}

	protected override void OnUpdate()
	{
		//IL_0117: Expected O, but got I4
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected I4, but got Unknown
		//IL_01c8: Expected O, but got I
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected O, but got Unknown
		//IL_0186: Expected F4, but got I
		//IL_023d: Expected O, but got I
		//IL_0311: Expected O, but got I4
		//IL_0228: Expected O, but got I8
		base.OnUpdate();
		if (PauseSystem._paused)
		{
			return;
		}
		List<WeaponBonusPair> obtainedBonusList = _obtainedBonusList;
		float num = 200f - (float)obtainedBonusList._size;
		bool flag = 8f > num;
		float food_BonusDelay = 8f;
		if (!flag)
		{
			food_BonusDelay = num;
		}
		_food_BonusDelay = food_BonusDelay;
		float deltaTime = PauseSystem.DeltaTime;
		float num2 = deltaTime * 1000f;
		if ((_food_BonusTimer = num2 + _food_BonusTimer) < _food_BonusDelay || !_coherenceSync.HasStateAuthority)
		{
			return;
		}
		List<WeaponBonusPair> obtainedBonusList2 = _obtainedBonusList;
		_food_BonusTimer = 0f;
		if (obtainedBonusList2._size <= 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96630");
		_obtainedBonusList.RemoveAt(0);
		List<WeaponBonusPair> crapBonusList = _crapBonusList;
		List<WeaponBonusPair> earlyBonusList = _earlyBonusList;
		object obj = earlyBonusList._size + crapBonusList._size;
		int num3 = obj / maxBonusTimes;
		GameManager core = GM.Core;
		float bonusSize = 1f - (float)num3;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rax_v13+10]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rax_v13+14]");
			ApplyBonus((WeaponType)num4, 0f, bonusSize);
			return;
		}
		Action<int, float, float> action = null;
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ r10_v4 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ r10_v4 (Il2CppMethodInfo)+4C]");
		object obj2 = (nint)0 >> 4;
		object obj3 = obj2 & 1;
		object obj4;
		if (obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ r10_v4 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 3)
			{
				obj4 = 6447778080L;
				goto IL_0308;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v449 @ rax_v20 (System.Action`3<System.Int32, System.Single, System.Single>)+10]");
		obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v449 @ rax_v20 (System.Action`3<System.Int32, System.Single, System.Single>)+20]");
		_ = 0;
		goto IL_0308;
		IL_0308:
		object obj5 = 24;
		_ = 6447777936L;
		CoherenceSync coherenceSync = _coherenceSync;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rax_v13+10]");
		float param = default(float);
		float param2 = default(float);
		bool flag2 = coherenceSync.SendCommand(action, MessageTarget.All, 0, param, param2);
	}

	private unsafe void ApplyBonus(WeaponType weapon, float value, float bonusSize)
	{
		//IL_0102: Expected O, but got I4
		//IL_00a2: Expected O, but got F4
		//IL_00a2: Expected O, but got Ref
		//IL_00d2: Expected O, but got I4
		AddAttribute(this, weapon, value);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 2f;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Roast, soundConfig, 500f, 5, num);
		GameManager core = GM.Core;
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		string value2 = System.Number.FormatSingle(value, null, currentInfo);
		Color coopColour = GetCoopColour();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
		object obj = default(object);
		float displayTimeMultiplier = default(float);
		Vector2 vOffset = default(Vector2);
		core._gizmoManager.DisplayWeaponIconOverhead(weapon, value2, (Color?)(object)(&obj), (CharacterController)num, displayTimeMultiplier, vOffset);
		float num2 = bonusSize + 1f;
		float xScale = num2 * cachedSize;
		ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
	}

	public void AddAttributeOnline(int weaponType, float value, float bonusSize)
	{
		ApplyBonus((WeaponType)weaponType, value, bonusSize);
	}

	private void InitBonuses(WeaponType weaponType, float bonusValue, int times, List<WeaponBonusPair> _list)
	{
		//IL_000e: Expected O, but got I4
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		if (times <= 0)
		{
			return;
		}
		object obj = 0;
		List<object> list = default(List<object>);
		do
		{
			WeaponBonusPair weaponBonusPair = null;
			weaponBonusPair.bonusValue = bonusValue;
			weaponBonusPair.weaponType = weaponType;
			int version = list._version + 1;
			list._version = version;
			object[] items = list._items;
			if (list._size >= items.Length)
			{
				list.AddWithResize((object)weaponBonusPair);
			}
			else
			{
				int num = list._size + 1;
				list._size = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			obj++;
		}
		while ((nint)obj < times);
	}

	private void CharacterHealed(float value, float rawValue)
	{
		float num = rawValue - value;
		if (num < OverhealTriggerValue)
		{
			return;
		}
		List<WeaponBonusPair> earlyBonusList = _earlyBonusList;
		List<WeaponBonusPair> list;
		if (earlyBonusList._size <= 0)
		{
			List<WeaponBonusPair> crapBonusList = _crapBonusList;
			if (crapBonusList._size <= 0)
			{
				return;
			}
			if (crapBonusList._size > 0)
			{
				WeaponBonusPair[] items = crapBonusList._items;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1C90");
				list = _crapBonusList;
				goto IL_0128;
			}
		}
		else if (earlyBonusList._size > 0)
		{
			WeaponBonusPair[] items2 = earlyBonusList._items;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1C90");
			list = _earlyBonusList;
			goto IL_0128;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_0128:
		list.RemoveAt(0);
	}

	public bool CheckAchievementStats()
	{
		//IL_0037: Expected I4, but got O
		if (_earlyBonusList != null)
		{
			bool flag = _crapBonusList == null;
			if (!flag)
			{
				return flag;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void AddBonusToQueue()
	{
		List<WeaponBonusPair> earlyBonusList = _earlyBonusList;
		List<WeaponBonusPair> list;
		if (earlyBonusList._size <= 0)
		{
			List<WeaponBonusPair> crapBonusList = _crapBonusList;
			if (crapBonusList._size <= 0)
			{
				return;
			}
			if (crapBonusList._size > 0)
			{
				WeaponBonusPair[] items = crapBonusList._items;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1C90");
				list = _crapBonusList;
				goto IL_00ab;
			}
		}
		else if (earlyBonusList._size > 0)
		{
			WeaponBonusPair[] items2 = earlyBonusList._items;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1C90");
			list = _earlyBonusList;
			goto IL_00ab;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_00ab:
		list.RemoveAt(0);
	}

	private void AddAttribute(CharacterController character, WeaponType weaponType, float value)
	{
		//IL_000e: Expected O, but got I4
		//IL_0038: Expected O, but got I8
		//IL_0052: Expected O, but got I8
		object obj = weaponType + -50;
		if ((nint)obj <= 16)
		{
			object obj2 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rdx_v1+734EC0C+v2 @ r8_v1*4]");
			object obj3 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v24 @ rcx_v2 (should have been resolved before IL gen)");
		}
	}

	public CharacterControllerGazebo()
	{
		List<WeaponBonusPair> earlyBonusList = new List<WeaponBonusPair>();
		_earlyBonusList = earlyBonusList;
		_crapBonusList = new List<WeaponBonusPair>();
		_obtainedBonusList = new List<WeaponBonusPair>();
		_food_BonusDelay = 200f;
		base._002Ector();
	}
}
