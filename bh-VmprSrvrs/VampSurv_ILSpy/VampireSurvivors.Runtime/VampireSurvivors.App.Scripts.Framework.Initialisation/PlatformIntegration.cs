using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using I2.Loc;
using UnityEngine;
using UnityEngine.SceneManagement;
using VampireSurvivors.Achievements;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Platforms;
using VampireSurvivors.Framework.Platforms.Saves;
using VampireSurvivors.Framework.Saves;
using VampireSurvivors.Objects;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.Scripts.Framework.Initialisation;

public static class PlatformIntegration
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__0_9;

		public static Action _003C_003E9__0_7;

		public static Action _003C_003E9__0_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CInit_003Eb__0_9()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3054]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			PopupManager.CreateErrorPopup("Failed-Load-Save-Data", "lang/failed_load_save_data", textIsLocalizationTerm: true);
		}

		internal void _003CInit_003Eb__0_7()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3055]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			PopupManager.CreateErrorPopup("Failed-Init-Storage", "lang/failed_init_storage", textIsLocalizationTerm: true);
		}

		internal void _003CInit_003Eb__0_1()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3056]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			PopupManager.CreateErrorPopup("Failed-Login", "lang/failed_login", textIsLocalizationTerm: true);
		}
	}

	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public PlayerOptions playerOptions;

		public AchievementManager achievementManager;

		public Action onComplete;

		public Action _003C_003E9__8;

		public Action _003C_003E9__6;

		public Action _003C_003E9__5;

		public Action _003C_003E9__4;

		public Action _003C_003E9__3;

		public Action _003C_003E9__2;

		internal unsafe void _003CInit_003Eb__0()
		{
			SetCurrentLanguageCode();
			FireProgressUpdate("lang/checking_dlc");
			Action callback = _003C_003E9__2;
			if (_003C_003E9__2 == null)
			{
				callback = (_003C_003E9__2 = delegate
				{
					FireProgressUpdate("lang/updating_dlc");
					Action action = _003C_003E9__3;
					if (_003C_003E9__3 == null)
					{
						action = (_003C_003E9__3 = delegate
						{
							//IL_00a9: Expected I, but got O
							//IL_002e: Expected O, but got I4
							while (true)
							{
								FireProgressUpdate("lang/loading_dlc");
								Action action2 = _003C_003E9__4;
								bool flag = _003C_003E9__4 != null;
								nint num = unchecked((nint)null);
								if (!flag)
								{
									Action action3 = (_003C_003E9__4 = delegate
									{
										FireProgressUpdate("lang/loading_dlc");
										Action callback2 = _003C_003E9__5;
										if (_003C_003E9__5 == null)
										{
											callback2 = (_003C_003E9__5 = delegate
											{
												if (PreloaderEvents.UpdateExtraText != null)
												{
													Action<string> updateExtraText = PreloaderEvents.UpdateExtraText;
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v74 @ r9_v8 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
												}
												FireProgressUpdate("lang/fetching_save_data");
												Action action4 = _003C_003E9__6;
												if (_003C_003E9__6 == null)
												{
													action4 = (_003C_003E9__6 = delegate
													{
														FireProgressUpdate("lang/loading_save_data");
														Action action5 = _003C_003E9__8;
														if (_003C_003E9__8 == null)
														{
															action5 = (_003C_003E9__8 = delegate
															{
																//IL_0017: Expected I4, but got O
																//IL_0041: Expected I8, but got I4
																//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
																//IL_00c4: Expected Ref, but got Unknown
																//IL_00db: Expected I8, but got I4
																//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
																//IL_00ea: Expected Ref, but got Unknown
																FireProgressUpdate("lang/loading");
																SyncAchievements(playerOptions, achievementManager);
																Scene activeScene = SceneManager.GetActiveScene();
																string nameInternal = Scene.GetNameInternal((int)activeScene);
																object obj2 = "Gameplay";
																bool flag2 = (object)nameInternal == "Gameplay";
																ulong num2 = 0uL;
																if (!flag2)
																{
																	if (nameInternal != null && "Gameplay" != null)
																	{
																		int stringLength = nameInternal._stringLength;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v4+10]");
																		if ((nint)stringLength == 0)
																		{
																			ref byte first = ref *(byte*)(nameInternal + 20);
																			num2 = (ulong)(nameInternal._stringLength + nameInternal._stringLength);
																			if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("Gameplay" + 20), num2))
																			{
																				goto IL_0119;
																			}
																		}
																	}
																	MainMenuLoader.Load(onComplete);
																	return;
																}
																goto IL_0119;
																IL_0119:
																Action action6 = onComplete;
																Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v115.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
															});
														}
														Action onError2 = _003C_003Ec._003C_003E9__0_9;
														if (_003C_003Ec._003C_003E9__0_9 == null)
														{
															onError2 = (_003C_003Ec._003C_003E9__0_9 = delegate
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3054]");
																if ((nint)0 == 0)
																{
																	_ = 1;
																}
																PopupManager.CreateErrorPopup("Failed-Load-Save-Data", "lang/failed_load_save_data", textIsLocalizationTerm: true);
															});
														}
														Load(playerOptions, action5, onError2);
													});
												}
												Action onError = _003C_003Ec._003C_003E9__0_7;
												if (_003C_003Ec._003C_003E9__0_7 == null)
												{
													onError = (_003C_003Ec._003C_003E9__0_7 = delegate
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3055]");
														if ((nint)0 == 0)
														{
															_ = 1;
														}
														PopupManager.CreateErrorPopup("Failed-Init-Storage", "lang/failed_init_storage", textIsLocalizationTerm: true);
													});
												}
												InitStorage(action4, onError);
											});
										}
										DlcSystem._003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals2 = new DlcSystem._003C_003Ec__DisplayClass33_0();
										CS_0024_003C_003E8__locals2.callback = callback2;
										DlcSystem.Log("Mounting and loading DLCs");
										DlcSystem._licenseManager.SortDlcLists();
										Action callback3 = delegate
										{
											//IL_0018: Expected I, but got O
											//IL_0035: Unknown result type (might be due to invalid IL or missing references)
											//IL_003a: Expected O, but got Unknown
											//IL_0080: Expected O, but got I
											nint num2 = (nint)typeof(DlcType);
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
											object obj3 = default(object);
											object obj2 = obj3 + 32;
											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
											IntPtr intPtr = default(IntPtr);
											num2 = intPtr;
											if (num2 != 0)
											{
												object obj4 = num2;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v243 @ rdx_v7+8F8] (should have been resolved before IL gen)");
												DlcType[] array = default(DlcType[]);
												if (array != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
													if (array == null)
													{
														throw new InvalidCastException();
													}
												}
												DlcSystem._loadingManager.ValidateVersion(0, array, CS_0024_003C_003E8__locals2.callback);
												return;
											}
											ArgumentNullException ex = new ArgumentNullException("enumType");
											ex._002Ector("enumType");
											throw ex;
										};
										DlcSystem._loadingManager.LoadDlcs(callback3);
									});
									object obj = 0;
									num = 0;
									action2 = action3;
								}
								IntPtr method = ((Delegate)action2).method;
								IntPtr method_code = ((Delegate)action2).method_code;
								IntPtr invoke_impl = ((Delegate)action2).invoke_impl;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v138 @ rax_v6 (System.IntPtr) (should have been resolved before IL gen)");
							}
						});
					}
					DlcSystem.Log("Checking for DLC updates");
					SystemPlatform sInstance = SystemPlatform.sInstance;
					sInstance.m_CurrentSystem.UpdateInstalledDlc(action);
				});
			}
			DlcSystem.LicenseCheckDlc(callback);
		}

		internal unsafe void _003CInit_003Eb__2()
		{
			FireProgressUpdate("lang/updating_dlc");
			Action action = _003C_003E9__3;
			if (_003C_003E9__3 == null)
			{
				action = (_003C_003E9__3 = delegate
				{
					//IL_00a9: Expected I, but got O
					//IL_002e: Expected O, but got I4
					while (true)
					{
						FireProgressUpdate("lang/loading_dlc");
						Action action2 = _003C_003E9__4;
						bool flag = _003C_003E9__4 != null;
						nint num = unchecked((nint)null);
						if (!flag)
						{
							Action action3 = (_003C_003E9__4 = delegate
							{
								FireProgressUpdate("lang/loading_dlc");
								Action callback = _003C_003E9__5;
								if (_003C_003E9__5 == null)
								{
									callback = (_003C_003E9__5 = delegate
									{
										if (PreloaderEvents.UpdateExtraText != null)
										{
											Action<string> updateExtraText = PreloaderEvents.UpdateExtraText;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v74 @ r9_v8 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
										}
										FireProgressUpdate("lang/fetching_save_data");
										Action action4 = _003C_003E9__6;
										if (_003C_003E9__6 == null)
										{
											action4 = (_003C_003E9__6 = delegate
											{
												FireProgressUpdate("lang/loading_save_data");
												Action action5 = _003C_003E9__8;
												if (_003C_003E9__8 == null)
												{
													action5 = (_003C_003E9__8 = delegate
													{
														//IL_0017: Expected I4, but got O
														//IL_0041: Expected I8, but got I4
														//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
														//IL_00c4: Expected Ref, but got Unknown
														//IL_00db: Expected I8, but got I4
														//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
														//IL_00ea: Expected Ref, but got Unknown
														FireProgressUpdate("lang/loading");
														SyncAchievements(playerOptions, achievementManager);
														Scene activeScene = SceneManager.GetActiveScene();
														string nameInternal = Scene.GetNameInternal((int)activeScene);
														object obj2 = "Gameplay";
														bool flag2 = (object)nameInternal == "Gameplay";
														ulong num2 = 0uL;
														if (!flag2)
														{
															if (nameInternal != null && "Gameplay" != null)
															{
																int stringLength = nameInternal._stringLength;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v4+10]");
																if ((nint)stringLength == 0)
																{
																	ref byte first = ref *(byte*)(nameInternal + 20);
																	num2 = (ulong)(nameInternal._stringLength + nameInternal._stringLength);
																	if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("Gameplay" + 20), num2))
																	{
																		goto IL_0119;
																	}
																}
															}
															MainMenuLoader.Load(onComplete);
															return;
														}
														goto IL_0119;
														IL_0119:
														Action action6 = onComplete;
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v115.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
													});
												}
												Action onError2 = _003C_003Ec._003C_003E9__0_9;
												if (_003C_003Ec._003C_003E9__0_9 == null)
												{
													onError2 = (_003C_003Ec._003C_003E9__0_9 = delegate
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3054]");
														if ((nint)0 == 0)
														{
															_ = 1;
														}
														PopupManager.CreateErrorPopup("Failed-Load-Save-Data", "lang/failed_load_save_data", textIsLocalizationTerm: true);
													});
												}
												Load(playerOptions, action5, onError2);
											});
										}
										Action onError = _003C_003Ec._003C_003E9__0_7;
										if (_003C_003Ec._003C_003E9__0_7 == null)
										{
											onError = (_003C_003Ec._003C_003E9__0_7 = delegate
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3055]");
												if ((nint)0 == 0)
												{
													_ = 1;
												}
												PopupManager.CreateErrorPopup("Failed-Init-Storage", "lang/failed_init_storage", textIsLocalizationTerm: true);
											});
										}
										InitStorage(action4, onError);
									});
								}
								DlcSystem._003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals2 = new DlcSystem._003C_003Ec__DisplayClass33_0();
								CS_0024_003C_003E8__locals2.callback = callback;
								DlcSystem.Log("Mounting and loading DLCs");
								DlcSystem._licenseManager.SortDlcLists();
								Action callback2 = delegate
								{
									//IL_0018: Expected I, but got O
									//IL_0035: Unknown result type (might be due to invalid IL or missing references)
									//IL_003a: Expected O, but got Unknown
									//IL_0080: Expected O, but got I
									nint num2 = (nint)typeof(DlcType);
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
									object obj3 = default(object);
									object obj2 = obj3 + 32;
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
									IntPtr intPtr = default(IntPtr);
									num2 = intPtr;
									if (num2 != 0)
									{
										object obj4 = num2;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v243 @ rdx_v7+8F8] (should have been resolved before IL gen)");
										DlcType[] array = default(DlcType[]);
										if (array != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											if (array == null)
											{
												throw new InvalidCastException();
											}
										}
										DlcSystem._loadingManager.ValidateVersion(0, array, CS_0024_003C_003E8__locals2.callback);
										return;
									}
									ArgumentNullException ex = new ArgumentNullException("enumType");
									ex._002Ector("enumType");
									throw ex;
								};
								DlcSystem._loadingManager.LoadDlcs(callback2);
							});
							object obj = 0;
							num = 0;
							action2 = action3;
						}
						IntPtr method = ((Delegate)action2).method;
						IntPtr method_code = ((Delegate)action2).method_code;
						IntPtr invoke_impl = ((Delegate)action2).invoke_impl;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v138 @ rax_v6 (System.IntPtr) (should have been resolved before IL gen)");
					}
				});
			}
			DlcSystem.Log("Checking for DLC updates");
			SystemPlatform sInstance = SystemPlatform.sInstance;
			sInstance.m_CurrentSystem.UpdateInstalledDlc(action);
		}

		internal unsafe void _003CInit_003Eb__3()
		{
			//IL_00a9: Expected I, but got O
			//IL_002e: Expected O, but got I4
			while (true)
			{
				FireProgressUpdate("lang/loading_dlc");
				Action action = _003C_003E9__4;
				bool flag = _003C_003E9__4 != null;
				nint num = unchecked((nint)null);
				if (!flag)
				{
					Action action2 = (_003C_003E9__4 = delegate
					{
						FireProgressUpdate("lang/loading_dlc");
						Action callback = _003C_003E9__5;
						if (_003C_003E9__5 == null)
						{
							callback = (_003C_003E9__5 = delegate
							{
								if (PreloaderEvents.UpdateExtraText != null)
								{
									Action<string> updateExtraText = PreloaderEvents.UpdateExtraText;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v74 @ r9_v8 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
								}
								FireProgressUpdate("lang/fetching_save_data");
								Action action3 = _003C_003E9__6;
								if (_003C_003E9__6 == null)
								{
									action3 = (_003C_003E9__6 = delegate
									{
										FireProgressUpdate("lang/loading_save_data");
										Action action4 = _003C_003E9__8;
										if (_003C_003E9__8 == null)
										{
											action4 = (_003C_003E9__8 = delegate
											{
												//IL_0017: Expected I4, but got O
												//IL_0041: Expected I8, but got I4
												//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
												//IL_00c4: Expected Ref, but got Unknown
												//IL_00db: Expected I8, but got I4
												//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
												//IL_00ea: Expected Ref, but got Unknown
												FireProgressUpdate("lang/loading");
												SyncAchievements(playerOptions, achievementManager);
												Scene activeScene = SceneManager.GetActiveScene();
												string nameInternal = Scene.GetNameInternal((int)activeScene);
												object obj2 = "Gameplay";
												bool flag2 = (object)nameInternal == "Gameplay";
												ulong num2 = 0uL;
												if (!flag2)
												{
													if (nameInternal != null && "Gameplay" != null)
													{
														int stringLength = nameInternal._stringLength;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v4+10]");
														if ((nint)stringLength == 0)
														{
															ref byte first = ref *(byte*)(nameInternal + 20);
															num2 = (ulong)(nameInternal._stringLength + nameInternal._stringLength);
															if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("Gameplay" + 20), num2))
															{
																goto IL_0119;
															}
														}
													}
													MainMenuLoader.Load(onComplete);
													return;
												}
												goto IL_0119;
												IL_0119:
												Action action5 = onComplete;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v115.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
											});
										}
										Action onError2 = _003C_003Ec._003C_003E9__0_9;
										if (_003C_003Ec._003C_003E9__0_9 == null)
										{
											onError2 = (_003C_003Ec._003C_003E9__0_9 = delegate
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3054]");
												if ((nint)0 == 0)
												{
													_ = 1;
												}
												PopupManager.CreateErrorPopup("Failed-Load-Save-Data", "lang/failed_load_save_data", textIsLocalizationTerm: true);
											});
										}
										Load(playerOptions, action4, onError2);
									});
								}
								Action onError = _003C_003Ec._003C_003E9__0_7;
								if (_003C_003Ec._003C_003E9__0_7 == null)
								{
									onError = (_003C_003Ec._003C_003E9__0_7 = delegate
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3055]");
										if ((nint)0 == 0)
										{
											_ = 1;
										}
										PopupManager.CreateErrorPopup("Failed-Init-Storage", "lang/failed_init_storage", textIsLocalizationTerm: true);
									});
								}
								InitStorage(action3, onError);
							});
						}
						DlcSystem._003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals2 = new DlcSystem._003C_003Ec__DisplayClass33_0();
						CS_0024_003C_003E8__locals2.callback = callback;
						DlcSystem.Log("Mounting and loading DLCs");
						DlcSystem._licenseManager.SortDlcLists();
						Action callback2 = delegate
						{
							//IL_0018: Expected I, but got O
							//IL_0035: Unknown result type (might be due to invalid IL or missing references)
							//IL_003a: Expected O, but got Unknown
							//IL_0080: Expected O, but got I
							nint num2 = (nint)typeof(DlcType);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
							object obj3 = default(object);
							object obj2 = obj3 + 32;
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
							IntPtr intPtr = default(IntPtr);
							num2 = intPtr;
							if (num2 != 0)
							{
								object obj4 = num2;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v243 @ rdx_v7+8F8] (should have been resolved before IL gen)");
								DlcType[] array = default(DlcType[]);
								if (array != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									if (array == null)
									{
										throw new InvalidCastException();
									}
								}
								DlcSystem._loadingManager.ValidateVersion(0, array, CS_0024_003C_003E8__locals2.callback);
								return;
							}
							ArgumentNullException ex = new ArgumentNullException("enumType");
							ex._002Ector("enumType");
							throw ex;
						};
						DlcSystem._loadingManager.LoadDlcs(callback2);
					});
					object obj = 0;
					num = 0;
					action = action2;
				}
				IntPtr method = ((Delegate)action).method;
				IntPtr method_code = ((Delegate)action).method_code;
				IntPtr invoke_impl = ((Delegate)action).invoke_impl;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v138 @ rax_v6 (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal unsafe void _003CInit_003Eb__4()
		{
			FireProgressUpdate("lang/loading_dlc");
			Action callback = _003C_003E9__5;
			if (_003C_003E9__5 == null)
			{
				callback = (_003C_003E9__5 = delegate
				{
					if (PreloaderEvents.UpdateExtraText != null)
					{
						Action<string> updateExtraText = PreloaderEvents.UpdateExtraText;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v74 @ r9_v8 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
					}
					FireProgressUpdate("lang/fetching_save_data");
					Action action = _003C_003E9__6;
					if (_003C_003E9__6 == null)
					{
						action = (_003C_003E9__6 = delegate
						{
							FireProgressUpdate("lang/loading_save_data");
							Action action2 = _003C_003E9__8;
							if (_003C_003E9__8 == null)
							{
								action2 = (_003C_003E9__8 = delegate
								{
									//IL_0017: Expected I4, but got O
									//IL_0041: Expected I8, but got I4
									//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
									//IL_00c4: Expected Ref, but got Unknown
									//IL_00db: Expected I8, but got I4
									//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
									//IL_00ea: Expected Ref, but got Unknown
									FireProgressUpdate("lang/loading");
									SyncAchievements(playerOptions, achievementManager);
									Scene activeScene = SceneManager.GetActiveScene();
									string nameInternal = Scene.GetNameInternal((int)activeScene);
									object obj = "Gameplay";
									bool flag = (object)nameInternal == "Gameplay";
									ulong num = 0uL;
									if (!flag)
									{
										if (nameInternal != null && "Gameplay" != null)
										{
											int stringLength = nameInternal._stringLength;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v4+10]");
											if ((nint)stringLength == 0)
											{
												ref byte first = ref *(byte*)(nameInternal + 20);
												num = (ulong)(nameInternal._stringLength + nameInternal._stringLength);
												if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("Gameplay" + 20), num))
												{
													goto IL_0119;
												}
											}
										}
										MainMenuLoader.Load(onComplete);
										return;
									}
									goto IL_0119;
									IL_0119:
									Action action3 = onComplete;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v115.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
								});
							}
							Action onError2 = _003C_003Ec._003C_003E9__0_9;
							if (_003C_003Ec._003C_003E9__0_9 == null)
							{
								onError2 = (_003C_003Ec._003C_003E9__0_9 = delegate
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3054]");
									if ((nint)0 == 0)
									{
										_ = 1;
									}
									PopupManager.CreateErrorPopup("Failed-Load-Save-Data", "lang/failed_load_save_data", textIsLocalizationTerm: true);
								});
							}
							Load(playerOptions, action2, onError2);
						});
					}
					Action onError = _003C_003Ec._003C_003E9__0_7;
					if (_003C_003Ec._003C_003E9__0_7 == null)
					{
						onError = (_003C_003Ec._003C_003E9__0_7 = delegate
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3055]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							PopupManager.CreateErrorPopup("Failed-Init-Storage", "lang/failed_init_storage", textIsLocalizationTerm: true);
						});
					}
					InitStorage(action, onError);
				});
			}
			DlcSystem._003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals2 = new DlcSystem._003C_003Ec__DisplayClass33_0();
			CS_0024_003C_003E8__locals2.callback = callback;
			DlcSystem.Log("Mounting and loading DLCs");
			DlcSystem._licenseManager.SortDlcLists();
			Action callback2 = delegate
			{
				//IL_0018: Expected I, but got O
				//IL_0035: Unknown result type (might be due to invalid IL or missing references)
				//IL_003a: Expected O, but got Unknown
				//IL_0080: Expected O, but got I
				nint num = (nint)typeof(DlcType);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
				object obj2 = default(object);
				object obj = obj2 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				IntPtr intPtr = default(IntPtr);
				num = intPtr;
				if (num != 0)
				{
					object obj3 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v243 @ rdx_v7+8F8] (should have been resolved before IL gen)");
					DlcType[] array = default(DlcType[]);
					if (array != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						if (array == null)
						{
							throw new InvalidCastException();
						}
					}
					DlcSystem._loadingManager.ValidateVersion(0, array, CS_0024_003C_003E8__locals2.callback);
					return;
				}
				ArgumentNullException ex = new ArgumentNullException("enumType");
				ex._002Ector("enumType");
				throw ex;
			};
			DlcSystem._loadingManager.LoadDlcs(callback2);
		}

		internal unsafe void _003CInit_003Eb__5()
		{
			if (PreloaderEvents.UpdateExtraText != null)
			{
				Action<string> updateExtraText = PreloaderEvents.UpdateExtraText;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v74 @ r9_v8 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
			}
			FireProgressUpdate("lang/fetching_save_data");
			Action action = _003C_003E9__6;
			if (_003C_003E9__6 == null)
			{
				action = (_003C_003E9__6 = delegate
				{
					FireProgressUpdate("lang/loading_save_data");
					Action action2 = _003C_003E9__8;
					if (_003C_003E9__8 == null)
					{
						action2 = (_003C_003E9__8 = delegate
						{
							//IL_0017: Expected I4, but got O
							//IL_0041: Expected I8, but got I4
							//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
							//IL_00c4: Expected Ref, but got Unknown
							//IL_00db: Expected I8, but got I4
							//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
							//IL_00ea: Expected Ref, but got Unknown
							FireProgressUpdate("lang/loading");
							SyncAchievements(playerOptions, achievementManager);
							Scene activeScene = SceneManager.GetActiveScene();
							string nameInternal = Scene.GetNameInternal((int)activeScene);
							object obj = "Gameplay";
							bool flag = (object)nameInternal == "Gameplay";
							ulong num = 0uL;
							if (!flag)
							{
								if (nameInternal != null && "Gameplay" != null)
								{
									int stringLength = nameInternal._stringLength;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v4+10]");
									if ((nint)stringLength == 0)
									{
										ref byte first = ref *(byte*)(nameInternal + 20);
										num = (ulong)(nameInternal._stringLength + nameInternal._stringLength);
										if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("Gameplay" + 20), num))
										{
											goto IL_0119;
										}
									}
								}
								MainMenuLoader.Load(onComplete);
								return;
							}
							goto IL_0119;
							IL_0119:
							Action action3 = onComplete;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v115.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
						});
					}
					Action onError2 = _003C_003Ec._003C_003E9__0_9;
					if (_003C_003Ec._003C_003E9__0_9 == null)
					{
						onError2 = (_003C_003Ec._003C_003E9__0_9 = delegate
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3054]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							PopupManager.CreateErrorPopup("Failed-Load-Save-Data", "lang/failed_load_save_data", textIsLocalizationTerm: true);
						});
					}
					Load(playerOptions, action2, onError2);
				});
			}
			Action onError = _003C_003Ec._003C_003E9__0_7;
			if (_003C_003Ec._003C_003E9__0_7 == null)
			{
				onError = (_003C_003Ec._003C_003E9__0_7 = delegate
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3055]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					PopupManager.CreateErrorPopup("Failed-Init-Storage", "lang/failed_init_storage", textIsLocalizationTerm: true);
				});
			}
			InitStorage(action, onError);
		}

		internal unsafe void _003CInit_003Eb__6()
		{
			FireProgressUpdate("lang/loading_save_data");
			Action action = _003C_003E9__8;
			if (_003C_003E9__8 == null)
			{
				action = (_003C_003E9__8 = delegate
				{
					//IL_0017: Expected I4, but got O
					//IL_0041: Expected I8, but got I4
					//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
					//IL_00c4: Expected Ref, but got Unknown
					//IL_00db: Expected I8, but got I4
					//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
					//IL_00ea: Expected Ref, but got Unknown
					FireProgressUpdate("lang/loading");
					SyncAchievements(playerOptions, achievementManager);
					Scene activeScene = SceneManager.GetActiveScene();
					string nameInternal = Scene.GetNameInternal((int)activeScene);
					object obj = "Gameplay";
					bool flag = (object)nameInternal == "Gameplay";
					ulong num = 0uL;
					if (!flag)
					{
						if (nameInternal != null && "Gameplay" != null)
						{
							int stringLength = nameInternal._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v4+10]");
							if ((nint)stringLength == 0)
							{
								ref byte first = ref *(byte*)(nameInternal + 20);
								num = (ulong)(nameInternal._stringLength + nameInternal._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("Gameplay" + 20), num))
								{
									goto IL_0119;
								}
							}
						}
						MainMenuLoader.Load(onComplete);
						return;
					}
					goto IL_0119;
					IL_0119:
					Action action2 = onComplete;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v115.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				});
			}
			Action onError = _003C_003Ec._003C_003E9__0_9;
			if (_003C_003Ec._003C_003E9__0_9 == null)
			{
				onError = (_003C_003Ec._003C_003E9__0_9 = delegate
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3054]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					PopupManager.CreateErrorPopup("Failed-Load-Save-Data", "lang/failed_load_save_data", textIsLocalizationTerm: true);
				});
			}
			Load(playerOptions, action, onError);
		}

		internal unsafe void _003CInit_003Eb__8()
		{
			//IL_0017: Expected I4, but got O
			//IL_0041: Expected I8, but got I4
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Expected Ref, but got Unknown
			//IL_00db: Expected I8, but got I4
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Expected Ref, but got Unknown
			FireProgressUpdate("lang/loading");
			SyncAchievements(playerOptions, achievementManager);
			Scene activeScene = SceneManager.GetActiveScene();
			string nameInternal = Scene.GetNameInternal((int)activeScene);
			object obj = "Gameplay";
			bool flag = (object)nameInternal == "Gameplay";
			ulong num = 0uL;
			if (!flag)
			{
				if (nameInternal != null && "Gameplay" != null)
				{
					int stringLength = nameInternal._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v4+10]");
					if ((nint)stringLength == 0)
					{
						ref byte first = ref *(byte*)(nameInternal + 20);
						num = (ulong)(nameInternal._stringLength + nameInternal._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("Gameplay" + 20), num))
						{
							goto IL_0119;
						}
					}
				}
				MainMenuLoader.Load(onComplete);
				return;
			}
			goto IL_0119;
			IL_0119:
			Action action = onComplete;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v115.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public PlayerOptions playerOptions;

		public Action onComplete;

		public Action onError;

		public Action _003C_003E9__1;

		public Action _003C_003E9__2;

		internal void _003CHandleNoFreeSpaceWhenLoading_003Eb__0()
		{
			//IL_0120: Expected I4, but got O
			//IL_0120: Expected I4, but got O
			//IL_0120: Expected I4, but got O
			Action action = _003C_003E9__1;
			if (_003C_003E9__1 == null)
			{
				action = (_003C_003E9__1 = delegate
				{
					Debug.Log("Attempting to allow users to try save again");
					Load(playerOptions, onComplete, onError);
				});
			}
			Action action2 = _003C_003E9__2;
			if (_003C_003E9__2 == null)
			{
				action2 = (_003C_003E9__2 = delegate
				{
					Debug.Log("User has requested to continue without allowing a save");
					SystemPlatform sInstance = SystemPlatform.sInstance;
					IPlatformSaveUtils storage = sInstance.m_CurrentSystem.Storage;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003900");
					Action action3 = onComplete;
					if (onComplete != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v133.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				});
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3050]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			string button2Text = default(string);
			Action button1Callback = default(Action);
			Action button2Callback = default(Action);
			bool titleIsLocalizationTerm = default(bool);
			PopupManager.CreateTwoButtonPopup("SaveData-NoFreeSpace", "lang/playStationNoFreeSpaceDialogTitle", "lang/playStationNoFreeSpaceDialogDescription", "lang/playStationNoFreeSpaceDialogButton1", button2Text, button1Callback, button2Callback, titleIsLocalizationTerm, (byte)(int)"lang/playStationNoFreeSpaceDialogButton2" != 0, (byte)(int)action != 0, (byte)(int)action2 != 0);
		}

		internal void _003CHandleNoFreeSpaceWhenLoading_003Eb__1()
		{
			Debug.Log("Attempting to allow users to try save again");
			Load(playerOptions, onComplete, onError);
		}

		internal void _003CHandleNoFreeSpaceWhenLoading_003Eb__2()
		{
			Debug.Log("User has requested to continue without allowing a save");
			SystemPlatform sInstance = SystemPlatform.sInstance;
			IPlatformSaveUtils storage = sInstance.m_CurrentSystem.Storage;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003900");
			Action action = onComplete;
			if (onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v133.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public AchievementManager achievementManager;

		public int locallyUnlocked;

		internal void _003CSyncAchievements_003Eb__0(bool r, List<AchievementType> unlocked)
		{
			//IL_002a: Expected I, but got O
			//IL_0090: Expected I, but got O
			//IL_00f5: Expected I, but got O
			object[] array = new object[3];
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj = default(object);
			if (obj != null)
			{
				nint num = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj3 = default(object);
			if (obj3 != null)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj5 = default(object);
			if (obj5 != null)
			{
				nint num3 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj6 = default(object);
				if (obj6 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Debug.LogFormat("System achievements manager initialization result: {0}, unlocked achievements count (locally/online): {1}/{2}", array);
			AchievementManager achievementManager = this.achievementManager;
			achievementManager.AchievementsUnlockedOnPlatform = unlocked;
			this.achievementManager.Setup();
			this.achievementManager.ApplyPlatformAchievementsRetroactively();
			this.achievementManager.CheckForStartupAchievements();
		}
	}

	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public Action onComplete;

		public Action onError;

		internal void _003CSignIn_003Eb__0(LoginResult r)
		{
			//IL_001c: Expected I4, but got O
			//IL_004a: Expected I, but got O
			//IL_01d1: Expected O, but got I4
			//IL_017a: Expected I, but got O
			//IL_011b: Expected O, but got I4
			//IL_00c4: Expected I, but got O
			if (r != LoginResult.Successful)
			{
				object[] array = new object[2];
				object obj2 = default(object);
				object obj = (LoginResult)obj2;
				if (obj != null)
				{
					nint num = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj3 = default(object);
					if (obj3 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				SystemPlatform sInstance = SystemPlatform.sInstance;
				IBaseAccount currentSystem = sInstance.m_CurrentSystem;
				object obj5 = default(object);
				object obj4 = (ErroInfo)obj5;
				if (obj4 != null)
				{
					nint num2 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj6 = default(object);
					if (obj6 == null)
					{
						ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
						throw ex2;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Debug.LogErrorFormat("Could not log in user: {0}, errorInfo: {1}!", array);
				Action action = onError;
				object obj7 = 0;
			}
			else
			{
				object[] array2 = new object[1];
				SystemPlatform sInstance2 = SystemPlatform.sInstance;
				IBaseAccount currentSystem2 = sInstance2.m_CurrentSystem;
				if (currentSystem2.m_Name != null)
				{
					nint num3 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj8 = default(object);
					if (obj8 == null)
					{
						ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
						throw ex3;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Debug.LogFormat("Player: '{0}' log in.", array2);
				Action action = onComplete;
				object obj7 = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v147.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public Action onComplete;

		public Action onError;

		internal void _003CInitStorage_003Eb__0(StorageResult sr)
		{
			//IL_01a8: Expected I4, but got O
			//IL_0056: Expected I4, but got O
			//IL_01d6: Expected I, but got O
			//IL_0084: Expected I, but got O
			//IL_0226: Expected I, but got O
			//IL_025a: Expected O, but got I
			//IL_00d4: Expected I, but got O
			//IL_0108: Expected O, but got I
			//IL_02ec: Expected I, but got O
			//IL_0291: Expected I, but got O
			//IL_019a: Expected I, but got O
			//IL_013f: Expected I, but got O
			if (sr == StorageResult.Successful)
			{
				Action action = onComplete;
			}
			else
			{
				object[] array = new object[2];
				object obj2 = default(object);
				object obj8 = default(object);
				if (sr == StorageResult.NoFreeSpace)
				{
					object obj = (StorageResult)obj2;
					if (obj != null)
					{
						nint num = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj3 = default(object);
						if (obj3 == null)
						{
							ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
							throw ex;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					SystemPlatform sInstance = SystemPlatform.sInstance;
					IBaseAccount currentSystem = sInstance.m_CurrentSystem;
					nint num2 = (nint)currentSystem;
					IPlatformSaveUtils storage = currentSystem.Storage;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9DA40");
					object obj5 = default(object);
					object obj4 = obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rax_v44+10]");
					object obj6 = 0;
					object obj7 = (ErroInfo)obj8;
					if (obj7 != null)
					{
						nint num3 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj9 = default(object);
						if (obj9 == null)
						{
							ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
							throw ex2;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					Debug.LogWarningFormat("There is no space left on the storage: {0}, errorInfo: {1}!", array);
					Action action = onError;
					IPlatformSaveUtils platformSaveUtils = storage;
					nint num4 = unchecked((nint)null);
				}
				else
				{
					object obj10 = (StorageResult)obj2;
					if (obj10 != null)
					{
						nint num5 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj11 = default(object);
						if (obj11 == null)
						{
							ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
							throw ex3;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					SystemPlatform sInstance2 = SystemPlatform.sInstance;
					IBaseAccount currentSystem2 = sInstance2.m_CurrentSystem;
					nint num6 = (nint)currentSystem2;
					IPlatformSaveUtils storage2 = currentSystem2.Storage;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9DA40");
					object obj12 = default(object);
					object obj4 = obj12;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ rax_v26+10]");
					object obj6 = 0;
					object obj13 = (ErroInfo)obj8;
					if (obj13 != null)
					{
						nint num7 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj14 = default(object);
						if (obj14 == null)
						{
							ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
							throw ex4;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					Debug.LogErrorFormat("Could not initialize storage: {0}, errorInfo: {1}!", array);
					Action action = onError;
					IPlatformSaveUtils platformSaveUtils = storage2;
					nint num4 = unchecked((nint)null);
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v90.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public Action onComplete;

		public Action onError;

		public PlayerOptions playerOptions;

		internal void _003CLoad_003Eb__0(StorageResult lr)
		{
			//IL_0031: Expected O, but got I4
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Expected O, but got Unknown
			//IL_0205: Expected I4, but got O
			//IL_027a: Expected I, but got O
			//IL_0233: Expected I, but got O
			//IL_009e: Expected I4, but got O
			//IL_02ae: Expected O, but got I
			//IL_0113: Expected I, but got O
			//IL_00cc: Expected I, but got O
			//IL_02e5: Expected I, but got O
			//IL_0147: Expected O, but got I
			//IL_017e: Expected I, but got O
			if (lr == StorageResult.Successful)
			{
				Action action = onComplete;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v51.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				return;
			}
			object obj = lr - 9;
			bool flag = lr == StorageResult.DataCorrupted;
			if (!flag)
			{
				object obj2 = obj - 1;
				object obj4 = default(object);
				object obj10 = default(object);
				object[] args;
				string format;
				if (!flag)
				{
					if ((nint)obj2 == 1)
					{
						HandleNoFreeSpaceWhenLoading(playerOptions, onComplete, onError);
						return;
					}
					object[] array = new object[2];
					object obj3 = (StorageResult)obj4;
					if (obj3 != null)
					{
						nint num = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj5 = default(object);
						if (obj5 == null)
						{
							ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
							throw ex;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					IBaseAccount account = SystemPlatform.Account;
					nint num2 = (nint)account;
					IPlatformSaveUtils storage = account.Storage;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9DA40");
					object obj7 = default(object);
					object obj6 = obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ rax_v44+10]");
					object obj8 = 0;
					object obj9 = (ErroInfo)obj10;
					if (obj9 != null)
					{
						nint num3 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj11 = default(object);
						if (obj11 == null)
						{
							ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
							throw ex2;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					IPlatformSaveUtils platformSaveUtils = storage;
					args = array;
					format = "Could not load save data: {0}, errorInfo: {1}!";
				}
				else
				{
					object[] array2 = new object[2];
					object obj12 = (StorageResult)obj4;
					if (obj12 != null)
					{
						nint num4 = (nint)array2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj13 = default(object);
						if (obj13 == null)
						{
							ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
							throw ex3;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					IBaseAccount account2 = SystemPlatform.Account;
					nint num5 = (nint)account2;
					IPlatformSaveUtils storage2 = account2.Storage;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9DA40");
					object obj14 = default(object);
					object obj6 = obj14;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rax_v26+10]");
					object obj8 = 0;
					object obj15 = (ErroInfo)obj10;
					if (obj15 != null)
					{
						nint num6 = (nint)array2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj16 = default(object);
						if (obj16 == null)
						{
							ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
							throw ex4;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					IPlatformSaveUtils platformSaveUtils = storage2;
					args = array2;
					format = "Could not access save data: {0}, errorInfo: {1}!";
				}
				Debug.LogErrorFormat(format, args);
				Action action2 = onError;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v131.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A304D]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				bool titleIsLocalizationTerm = default(bool);
				bool descriptionIsLocalizationTerm = default(bool);
				PopupManager.CreateWarningPopup("Options-Error", "lang/options_error", "lang/save_data_corrupted", onComplete, titleIsLocalizationTerm, descriptionIsLocalizationTerm);
			}
		}
	}

	public unsafe static void Init(PlayerOptions playerOptions, AchievementManager achievementManager, Action onComplete)
	{
		_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals29 = new _003C_003Ec__DisplayClass0_0();
		CS_0024_003C_003E8__locals29.playerOptions = playerOptions;
		CS_0024_003C_003E8__locals29.achievementManager = achievementManager;
		CS_0024_003C_003E8__locals29.onComplete = onComplete;
		FireProgressUpdate("lang/loading");
		Action onComplete2 = delegate
		{
			SetCurrentLanguageCode();
			FireProgressUpdate("lang/checking_dlc");
			Action callback = CS_0024_003C_003E8__locals29._003C_003E9__2;
			if (CS_0024_003C_003E8__locals29._003C_003E9__2 == null)
			{
				callback = (CS_0024_003C_003E8__locals29._003C_003E9__2 = delegate
				{
					FireProgressUpdate("lang/updating_dlc");
					Action onComplete3 = CS_0024_003C_003E8__locals29._003C_003E9__3;
					if (CS_0024_003C_003E8__locals29._003C_003E9__3 == null)
					{
						onComplete3 = (CS_0024_003C_003E8__locals29._003C_003E9__3 = delegate
						{
							//IL_00a9: Expected I, but got O
							//IL_002e: Expected O, but got I4
							while (true)
							{
								FireProgressUpdate("lang/loading_dlc");
								Action action = CS_0024_003C_003E8__locals29._003C_003E9__4;
								bool flag = CS_0024_003C_003E8__locals29._003C_003E9__4 != null;
								nint num = unchecked((nint)null);
								if (!flag)
								{
									Action action2 = (CS_0024_003C_003E8__locals29._003C_003E9__4 = delegate
									{
										FireProgressUpdate("lang/loading_dlc");
										Action callback2 = CS_0024_003C_003E8__locals29._003C_003E9__5;
										if (CS_0024_003C_003E8__locals29._003C_003E9__5 == null)
										{
											callback2 = (CS_0024_003C_003E8__locals29._003C_003E9__5 = delegate
											{
												if (PreloaderEvents.UpdateExtraText != null)
												{
													Action<string> updateExtraText = PreloaderEvents.UpdateExtraText;
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v74 @ r9_v8 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
												}
												FireProgressUpdate("lang/fetching_save_data");
												Action onComplete4 = CS_0024_003C_003E8__locals29._003C_003E9__6;
												if (CS_0024_003C_003E8__locals29._003C_003E9__6 == null)
												{
													onComplete4 = (CS_0024_003C_003E8__locals29._003C_003E9__6 = delegate
													{
														FireProgressUpdate("lang/loading_save_data");
														Action onComplete5 = CS_0024_003C_003E8__locals29._003C_003E9__8;
														if (CS_0024_003C_003E8__locals29._003C_003E9__8 == null)
														{
															onComplete5 = (CS_0024_003C_003E8__locals29._003C_003E9__8 = delegate
															{
																//IL_0017: Expected I4, but got O
																//IL_0041: Expected I8, but got I4
																//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
																//IL_00c4: Expected Ref, but got Unknown
																//IL_00db: Expected I8, but got I4
																//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
																//IL_00ea: Expected Ref, but got Unknown
																FireProgressUpdate("lang/loading");
																SyncAchievements(CS_0024_003C_003E8__locals29.playerOptions, CS_0024_003C_003E8__locals29.achievementManager);
																Scene activeScene = SceneManager.GetActiveScene();
																string nameInternal = Scene.GetNameInternal((int)activeScene);
																object obj2 = "Gameplay";
																bool flag2 = (object)nameInternal == "Gameplay";
																ulong num2 = 0uL;
																if (!flag2)
																{
																	if (nameInternal != null && "Gameplay" != null)
																	{
																		int stringLength = nameInternal._stringLength;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v4+10]");
																		if ((nint)stringLength == 0)
																		{
																			ref byte first = ref *(byte*)(nameInternal + 20);
																			num2 = (ulong)(nameInternal._stringLength + nameInternal._stringLength);
																			if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("Gameplay" + 20), num2))
																			{
																				goto IL_0119;
																			}
																		}
																	}
																	MainMenuLoader.Load(CS_0024_003C_003E8__locals29.onComplete);
																	return;
																}
																goto IL_0119;
																IL_0119:
																Action onComplete6 = CS_0024_003C_003E8__locals29.onComplete;
																Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v115.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
															});
														}
														Action onError3 = _003C_003Ec._003C_003E9__0_9;
														if (_003C_003Ec._003C_003E9__0_9 == null)
														{
															onError3 = (_003C_003Ec._003C_003E9__0_9 = delegate
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3054]");
																if ((nint)0 == 0)
																{
																	_ = 1;
																}
																PopupManager.CreateErrorPopup("Failed-Load-Save-Data", "lang/failed_load_save_data", textIsLocalizationTerm: true);
															});
														}
														Load(CS_0024_003C_003E8__locals29.playerOptions, onComplete5, onError3);
													});
												}
												Action onError2 = _003C_003Ec._003C_003E9__0_7;
												if (_003C_003Ec._003C_003E9__0_7 == null)
												{
													onError2 = (_003C_003Ec._003C_003E9__0_7 = delegate
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3055]");
														if ((nint)0 == 0)
														{
															_ = 1;
														}
														PopupManager.CreateErrorPopup("Failed-Init-Storage", "lang/failed_init_storage", textIsLocalizationTerm: true);
													});
												}
												InitStorage(onComplete4, onError2);
											});
										}
										DlcSystem._003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals21 = new DlcSystem._003C_003Ec__DisplayClass33_0();
										CS_0024_003C_003E8__locals21.callback = callback2;
										DlcSystem.Log("Mounting and loading DLCs");
										DlcSystem._licenseManager.SortDlcLists();
										Action callback3 = delegate
										{
											//IL_0018: Expected I, but got O
											//IL_0035: Unknown result type (might be due to invalid IL or missing references)
											//IL_003a: Expected O, but got Unknown
											//IL_0080: Expected O, but got I
											nint num2 = (nint)typeof(DlcType);
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
											object obj3 = default(object);
											object obj2 = obj3 + 32;
											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
											IntPtr intPtr = default(IntPtr);
											num2 = intPtr;
											if (num2 != 0)
											{
												object obj4 = num2;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v243 @ rdx_v7+8F8] (should have been resolved before IL gen)");
												DlcType[] array = default(DlcType[]);
												if (array != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
													if (array == null)
													{
														throw new InvalidCastException();
													}
												}
												DlcSystem._loadingManager.ValidateVersion(0, array, CS_0024_003C_003E8__locals21.callback);
												return;
											}
											ArgumentNullException ex = new ArgumentNullException("enumType");
											ex._002Ector("enumType");
											throw ex;
										};
										DlcSystem._loadingManager.LoadDlcs(callback3);
									});
									object obj = 0;
									num = 0;
									action = action2;
								}
								IntPtr method = ((Delegate)action).method;
								IntPtr method_code = ((Delegate)action).method_code;
								IntPtr invoke_impl = ((Delegate)action).invoke_impl;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v138 @ rax_v6 (System.IntPtr) (should have been resolved before IL gen)");
							}
						});
					}
					DlcSystem.Log("Checking for DLC updates");
					SystemPlatform sInstance = SystemPlatform.sInstance;
					sInstance.m_CurrentSystem.UpdateInstalledDlc(onComplete3);
				});
			}
			DlcSystem.LicenseCheckDlc(callback);
		};
		Action onError = _003C_003Ec._003C_003E9__0_1;
		if (_003C_003Ec._003C_003E9__0_1 == null)
		{
			onError = (_003C_003Ec._003C_003E9__0_1 = delegate
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3056]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				PopupManager.CreateErrorPopup("Failed-Login", "lang/failed_login", textIsLocalizationTerm: true);
			});
		}
		SignIn(onComplete2, onError);
	}

	private static void LicenseCheckDlc(Action onComplete)
	{
		DlcSystem.LicenseCheckDlc(onComplete);
	}

	private static void UpdateDlc(Action onComplete)
	{
		DlcSystem.Log("Checking for DLC updates");
		SystemPlatform sInstance = SystemPlatform.sInstance;
		sInstance.m_CurrentSystem.UpdateInstalledDlc(onComplete);
	}

	private static void CheckSelectedDLCs(Action onComplete)
	{
		IntPtr method = ((Delegate)onComplete).method;
		IntPtr method_code = ((Delegate)onComplete).method_code;
		IntPtr invoke_impl = ((Delegate)onComplete).invoke_impl;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v47 @ rax_v3 (System.IntPtr) (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}

	private static void LoadDlc(Action onComplete)
	{
		DlcSystem._003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals2 = new DlcSystem._003C_003Ec__DisplayClass33_0();
		CS_0024_003C_003E8__locals2.callback = onComplete;
		DlcSystem.Log("Mounting and loading DLCs");
		DlcSystem._licenseManager.SortDlcLists();
		Action callback = delegate
		{
			//IL_0018: Expected I, but got O
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Expected O, but got Unknown
			//IL_0080: Expected O, but got I
			nint num = (nint)typeof(DlcType);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			if (num != 0)
			{
				object obj3 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v243 @ rdx_v7+8F8] (should have been resolved before IL gen)");
				DlcType[] array = default(DlcType[]);
				if (array != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					if (array == null)
					{
						throw new InvalidCastException();
					}
				}
				DlcSystem._loadingManager.ValidateVersion(0, array, CS_0024_003C_003E8__locals2.callback);
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("enumType");
			ex._002Ector("enumType");
			throw ex;
		};
		DlcSystem._loadingManager.LoadDlcs(callback);
	}

	private static void SignIn(Action onComplete, Action onError)
	{
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals5.onComplete = onComplete;
		CS_0024_003C_003E8__locals5.onError = onError;
		SystemPlatform sInstance = SystemPlatform.sInstance;
		IBaseAccount currentSystem = sInstance.m_CurrentSystem;
		if (currentSystem.m_LoginState <= LoginState.LoggingIn)
		{
			SystemPlatform sInstance2 = SystemPlatform.sInstance;
			Action<LoginResult> onComplete2 = delegate(LoginResult r)
			{
				//IL_001c: Expected I4, but got O
				//IL_004a: Expected I, but got O
				//IL_01d1: Expected O, but got I4
				//IL_017a: Expected I, but got O
				//IL_011b: Expected O, but got I4
				//IL_00c4: Expected I, but got O
				if (r != LoginResult.Successful)
				{
					object[] array = new object[2];
					object obj2 = default(object);
					object obj = (LoginResult)obj2;
					if (obj != null)
					{
						nint num = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj3 = default(object);
						if (obj3 == null)
						{
							ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
							throw ex;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					SystemPlatform sInstance3 = SystemPlatform.sInstance;
					IBaseAccount currentSystem2 = sInstance3.m_CurrentSystem;
					object obj5 = default(object);
					object obj4 = (ErroInfo)obj5;
					if (obj4 != null)
					{
						nint num2 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj6 = default(object);
						if (obj6 == null)
						{
							ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
							throw ex2;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					Debug.LogErrorFormat("Could not log in user: {0}, errorInfo: {1}!", array);
					Action onError2 = CS_0024_003C_003E8__locals5.onError;
					object obj7 = 0;
				}
				else
				{
					object[] array2 = new object[1];
					SystemPlatform sInstance4 = SystemPlatform.sInstance;
					IBaseAccount currentSystem3 = sInstance4.m_CurrentSystem;
					if (currentSystem3.m_Name != null)
					{
						nint num3 = (nint)array2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj8 = default(object);
						if (obj8 == null)
						{
							ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
							throw ex3;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					Debug.LogFormat("Player: '{0}' log in.", array2);
					Action onError2 = CS_0024_003C_003E8__locals5.onComplete;
					object obj7 = 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v147.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			};
			sInstance2.m_CurrentSystem.LoginAsync(LoginOptions.RequireOnlineAccount, onComplete2);
		}
		else
		{
			Action onComplete3 = CS_0024_003C_003E8__locals5.onComplete;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v81.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private static void InitStorage(Action onComplete, Action onError)
	{
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals6.onComplete = onComplete;
		CS_0024_003C_003E8__locals6.onError = onError;
		SystemPlatform sInstance = SystemPlatform.sInstance;
		IPlatformSaveUtils storage = sInstance.m_CurrentSystem.Storage;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			SystemPlatform sInstance2 = SystemPlatform.sInstance;
			IPlatformSaveUtils storage2 = sInstance2.m_CurrentSystem.Storage;
			StorageOperationComplete onComplete2 = delegate(StorageResult sr)
			{
				//IL_01a8: Expected I4, but got O
				//IL_0056: Expected I4, but got O
				//IL_01d6: Expected I, but got O
				//IL_0084: Expected I, but got O
				//IL_0226: Expected I, but got O
				//IL_025a: Expected O, but got I
				//IL_00d4: Expected I, but got O
				//IL_0108: Expected O, but got I
				//IL_02ec: Expected I, but got O
				//IL_0291: Expected I, but got O
				//IL_019a: Expected I, but got O
				//IL_013f: Expected I, but got O
				if (sr == StorageResult.Successful)
				{
					Action onComplete4 = CS_0024_003C_003E8__locals6.onComplete;
				}
				else
				{
					object[] array = new object[2];
					object obj3 = default(object);
					object obj9 = default(object);
					if (sr == StorageResult.NoFreeSpace)
					{
						object obj2 = (StorageResult)obj3;
						if (obj2 != null)
						{
							nint num = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj4 = default(object);
							if (obj4 == null)
							{
								ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
								throw ex;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						SystemPlatform sInstance3 = SystemPlatform.sInstance;
						IBaseAccount currentSystem = sInstance3.m_CurrentSystem;
						nint num2 = (nint)currentSystem;
						IPlatformSaveUtils storage3 = currentSystem.Storage;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9DA40");
						object obj6 = default(object);
						object obj5 = obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rax_v44+10]");
						object obj7 = 0;
						object obj8 = (ErroInfo)obj9;
						if (obj8 != null)
						{
							nint num3 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj10 = default(object);
							if (obj10 == null)
							{
								ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
								throw ex2;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						Debug.LogWarningFormat("There is no space left on the storage: {0}, errorInfo: {1}!", array);
						Action onComplete4 = CS_0024_003C_003E8__locals6.onError;
						IPlatformSaveUtils platformSaveUtils = storage3;
						nint num4 = unchecked((nint)null);
					}
					else
					{
						object obj11 = (StorageResult)obj3;
						if (obj11 != null)
						{
							nint num5 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj12 = default(object);
							if (obj12 == null)
							{
								ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
								throw ex3;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						SystemPlatform sInstance4 = SystemPlatform.sInstance;
						IBaseAccount currentSystem2 = sInstance4.m_CurrentSystem;
						nint num6 = (nint)currentSystem2;
						IPlatformSaveUtils storage4 = currentSystem2.Storage;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9DA40");
						object obj13 = default(object);
						object obj5 = obj13;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ rax_v26+10]");
						object obj7 = 0;
						object obj14 = (ErroInfo)obj9;
						if (obj14 != null)
						{
							nint num7 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj15 = default(object);
							if (obj15 == null)
							{
								ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
								throw ex4;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						Debug.LogErrorFormat("Could not initialize storage: {0}, errorInfo: {1}!", array);
						Action onComplete4 = CS_0024_003C_003E8__locals6.onError;
						IPlatformSaveUtils platformSaveUtils = storage4;
						nint num4 = unchecked((nint)null);
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v90.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			};
			storage2.InitAsync("Vampire_Survivors_Standalone", "Vampire Survivors Data", onComplete2);
		}
		else
		{
			Action onComplete3 = CS_0024_003C_003E8__locals6.onComplete;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v91.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private static void Load(PlayerOptions playerOptions, Action onComplete, Action onError)
	{
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals10.onComplete = onComplete;
		CS_0024_003C_003E8__locals10.onError = onError;
		CS_0024_003C_003E8__locals10.playerOptions = playerOptions;
		SetCurrentLanguageCode();
		Action<StorageResult> onComplete2 = delegate(StorageResult lr)
		{
			//IL_0031: Expected O, but got I4
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Expected O, but got Unknown
			//IL_0205: Expected I4, but got O
			//IL_027a: Expected I, but got O
			//IL_0233: Expected I, but got O
			//IL_009e: Expected I4, but got O
			//IL_02ae: Expected O, but got I
			//IL_0113: Expected I, but got O
			//IL_00cc: Expected I, but got O
			//IL_02e5: Expected I, but got O
			//IL_0147: Expected O, but got I
			//IL_017e: Expected I, but got O
			if (lr == StorageResult.Successful)
			{
				Action onComplete3 = CS_0024_003C_003E8__locals10.onComplete;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v51.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			else
			{
				object obj = lr - 9;
				bool flag = lr == StorageResult.DataCorrupted;
				if (!flag)
				{
					object obj2 = obj - 1;
					object obj4 = default(object);
					object obj10 = default(object);
					object[] args;
					string format;
					if (!flag)
					{
						if ((nint)obj2 == 1)
						{
							HandleNoFreeSpaceWhenLoading(CS_0024_003C_003E8__locals10.playerOptions, CS_0024_003C_003E8__locals10.onComplete, CS_0024_003C_003E8__locals10.onError);
							return;
						}
						object[] array = new object[2];
						object obj3 = (StorageResult)obj4;
						if (obj3 != null)
						{
							nint num = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj5 = default(object);
							if (obj5 == null)
							{
								ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
								throw ex;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						IBaseAccount account = SystemPlatform.Account;
						nint num2 = (nint)account;
						IPlatformSaveUtils storage = account.Storage;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9DA40");
						object obj7 = default(object);
						object obj6 = obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ rax_v44+10]");
						object obj8 = 0;
						object obj9 = (ErroInfo)obj10;
						if (obj9 != null)
						{
							nint num3 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj11 = default(object);
							if (obj11 == null)
							{
								ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
								throw ex2;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						IPlatformSaveUtils platformSaveUtils = storage;
						args = array;
						format = "Could not load save data: {0}, errorInfo: {1}!";
					}
					else
					{
						object[] array2 = new object[2];
						object obj12 = (StorageResult)obj4;
						if (obj12 != null)
						{
							nint num4 = (nint)array2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj13 = default(object);
							if (obj13 == null)
							{
								ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
								throw ex3;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						IBaseAccount account2 = SystemPlatform.Account;
						nint num5 = (nint)account2;
						IPlatformSaveUtils storage2 = account2.Storage;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9DA40");
						object obj14 = default(object);
						object obj6 = obj14;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rax_v26+10]");
						object obj8 = 0;
						object obj15 = (ErroInfo)obj10;
						if (obj15 != null)
						{
							nint num6 = (nint)array2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj16 = default(object);
							if (obj16 == null)
							{
								ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
								throw ex4;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						IPlatformSaveUtils platformSaveUtils = storage2;
						args = array2;
						format = "Could not access save data: {0}, errorInfo: {1}!";
					}
					Debug.LogErrorFormat(format, args);
					Action onError2 = CS_0024_003C_003E8__locals10.onError;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v131.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A304D]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					bool titleIsLocalizationTerm = default(bool);
					bool descriptionIsLocalizationTerm = default(bool);
					PopupManager.CreateWarningPopup("Options-Error", "lang/options_error", "lang/save_data_corrupted", CS_0024_003C_003E8__locals10.onComplete, titleIsLocalizationTerm, descriptionIsLocalizationTerm);
				}
			}
		};
		SaveSystem.LoadAsync(CS_0024_003C_003E8__locals10.playerOptions, onComplete2);
	}

	private static void HandleSaveDataCorruptedDialog(Action onComplete)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A304D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool titleIsLocalizationTerm = default(bool);
		bool descriptionIsLocalizationTerm = default(bool);
		PopupManager.CreateWarningPopup("Options-Error", "lang/options_error", "lang/save_data_corrupted", onComplete, titleIsLocalizationTerm, descriptionIsLocalizationTerm);
	}

	private static void SetCurrentLanguageCode()
	{
		SystemPlatform sInstance = SystemPlatform.sInstance;
		string defaultLanguage = sInstance.m_CurrentSystem.GetDefaultLanguage();
		string message = "Default Language: " + defaultLanguage;
		Debug.Log(message);
		LocalizationManager.CurrentLanguageCode = defaultLanguage;
	}

	private static void HandleNoFreeSpaceWhenLoading(PlayerOptions playerOptions, Action onComplete, Action onError)
	{
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals14 = new _003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals14.playerOptions = playerOptions;
		CS_0024_003C_003E8__locals14.onComplete = onComplete;
		CS_0024_003C_003E8__locals14.onError = onError;
		SystemPlatform sInstance = SystemPlatform.sInstance;
		IPlatformSaveUtils storage = sInstance.m_CurrentSystem.Storage;
		Action onComplete2 = delegate
		{
			//IL_0120: Expected I4, but got O
			//IL_0120: Expected I4, but got O
			//IL_0120: Expected I4, but got O
			Action action = CS_0024_003C_003E8__locals14._003C_003E9__1;
			if (CS_0024_003C_003E8__locals14._003C_003E9__1 == null)
			{
				action = (CS_0024_003C_003E8__locals14._003C_003E9__1 = delegate
				{
					Debug.Log("Attempting to allow users to try save again");
					Load(CS_0024_003C_003E8__locals14.playerOptions, CS_0024_003C_003E8__locals14.onComplete, CS_0024_003C_003E8__locals14.onError);
				});
			}
			Action action2 = CS_0024_003C_003E8__locals14._003C_003E9__2;
			if (CS_0024_003C_003E8__locals14._003C_003E9__2 == null)
			{
				action2 = (CS_0024_003C_003E8__locals14._003C_003E9__2 = delegate
				{
					Debug.Log("User has requested to continue without allowing a save");
					SystemPlatform sInstance2 = SystemPlatform.sInstance;
					IPlatformSaveUtils storage2 = sInstance2.m_CurrentSystem.Storage;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003900");
					Action onComplete3 = CS_0024_003C_003E8__locals14.onComplete;
					if (CS_0024_003C_003E8__locals14.onComplete != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v133.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				});
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3050]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			string button2Text = default(string);
			Action button1Callback = default(Action);
			Action button2Callback = default(Action);
			bool titleIsLocalizationTerm = default(bool);
			PopupManager.CreateTwoButtonPopup("SaveData-NoFreeSpace", "lang/playStationNoFreeSpaceDialogTitle", "lang/playStationNoFreeSpaceDialogDescription", "lang/playStationNoFreeSpaceDialogButton1", button2Text, button1Callback, button2Callback, titleIsLocalizationTerm, (byte)(int)"lang/playStationNoFreeSpaceDialogButton2" != 0, (byte)(int)action != 0, (byte)(int)action2 != 0);
		};
		storage.RequestNoFreeSpaceToSaveSystemDialog(onComplete2);
	}

	private static void ShowInternalNoFreeSpaceDialog(PlayerOptions playerOptions, Action button1Callback, Action button2Callback)
	{
		//IL_0069: Expected I4, but got O
		//IL_0069: Expected I4, but got O
		//IL_0069: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3050]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string button2Text = default(string);
		Action button1Callback2 = default(Action);
		Action button2Callback2 = default(Action);
		bool titleIsLocalizationTerm = default(bool);
		PopupManager.CreateTwoButtonPopup("SaveData-NoFreeSpace", "lang/playStationNoFreeSpaceDialogTitle", "lang/playStationNoFreeSpaceDialogDescription", "lang/playStationNoFreeSpaceDialogButton1", button2Text, button1Callback2, button2Callback2, titleIsLocalizationTerm, (byte)(int)"lang/playStationNoFreeSpaceDialogButton2" != 0, (byte)(int)button1Callback != 0, (byte)(int)button2Callback != 0);
	}

	private static void SyncAchievements(PlayerOptions playerOptions, AchievementManager achievementManager)
	{
		//IL_010e: Expected O, but got I
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected O, but got Unknown
		//IL_0183: Expected O, but got I
		//IL_01ed: Expected O, but got I4
		//IL_016e: Expected O, but got I8
		_003C_003Ec__DisplayClass12_0 obj = new _003C_003Ec__DisplayClass12_0();
		obj.achievementManager = achievementManager;
		SystemPlatform sInstance = SystemPlatform.sInstance;
		IPlatformAchievementsManager achievementsManager = sInstance.m_CurrentSystem.AchievementsManager;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		if (obj2 != null)
		{
			return;
		}
		PlayerOptionsData config = playerOptions.Config;
		List<AchievementType> list = config._003CAchievements_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
		obj.locallyUnlocked = 0;
		List<AchievementType> inout_Completed = new List<AchievementType>();
		SystemPlatform sInstance2 = SystemPlatform.sInstance;
		IPlatformAchievementsManager achievementsManager2 = sInstance2.m_CurrentSystem.AchievementsManager;
		DataManager dataManager = playerOptions._dataManager;
		Action<bool, List<AchievementType>> onComplete = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r9_v3 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r9_v3 (Il2CppMethodInfo)+4C]");
		object obj3 = (nint)0 >> 4;
		object obj4 = obj3 & 1;
		object obj5;
		if (obj4 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r9_v3 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 2)
			{
				obj5 = 6447762992L;
				goto IL_01e4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v21 (System.Action`2<System.Boolean, System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>>)+10]");
		obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v21 (System.Action`2<System.Boolean, System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>>)+20]");
		_ = 0;
		goto IL_01e4;
		IL_01e4:
		object obj6 = 24;
		_ = 6447762864L;
		achievementsManager2.InitAsync(dataManager._003CAllAchievements_003Ek__BackingField, inout_Completed, onComplete);
	}

	private static void FireProgressUpdate(string term, bool isTerm = true)
	{
		bool flag = !isTerm;
		string text = term;
		if (!flag)
		{
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			text = translation;
		}
		if (PreloaderEvents.UpdateText != null)
		{
			Action<string> updateText = PreloaderEvents.UpdateText;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v128 @ r9_v3 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
		}
	}
}
