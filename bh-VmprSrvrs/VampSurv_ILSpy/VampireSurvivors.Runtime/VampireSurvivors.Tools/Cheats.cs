using System;
using System.Collections.Generic;
using System.Threading;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using Zenject;

namespace VampireSurvivors.Tools;

public class Cheats : GameMonoBehaviour
{
	private SignalBus _signalBus;

	private GameSessionData _gameSessionData;

	private LevelUpFactory _levelUpFactory;

	private GameManager _gameManager;

	private GameObject _automationCancel;

	private TextMeshProUGUI _spawnedEnemyCount;

	private TextMeshProUGUI _temporaryEnemyCount;

	private TextMeshProUGUI _permanentEnemyCount;

	private TextMeshProUGUI _currentTimeText;

	private void Construct(SignalBus signalBus, GameSessionData gameSessionData, LevelUpFactory levelUpFactory, GameManager gameManager)
	{
		_signalBus = signalBus;
		_gameSessionData = gameSessionData;
		_levelUpFactory = levelUpFactory;
		GameManager gameManager2 = default(GameManager);
		_gameManager = gameManager2;
	}

	protected unsafe override void OnUpdate()
	{
		//IL_008a: Expected O, but got Ref
		//IL_0103: Expected O, but got Ref
		//IL_0165: Expected O, but got Ref
		GameManager core = GM.Core;
		Stage stage = core._stage;
		if ((object)core._stage != null && ((UnityEngine.Object)stage).m_CachedPtr != (IntPtr)0)
		{
			GameManager core2 = GM.Core;
			Stage stage2 = core2._stage;
			List<EnemyController> spawnedEnemies = stage2._spawnedEnemies;
			object obj = default(object);
			string text = System.Number.FormatInt32(spawnedEnemies._size, (ReadOnlySpan<char>)(&obj), null);
			string text2 = "Enemies: " + text;
			_spawnedEnemyCount.text = text2;
			GameManager core3 = GM.Core;
			Stage stage3 = core3._stage;
			StageEventManager stageEventManager = stage3._stageEventManager;
			string text3 = System.Number.FormatInt32(stageEventManager._003CSpawned_003Ek__BackingField, (ReadOnlySpan<char>)(&obj), null);
			string text4 = "Temporary: " + text3;
			_temporaryEnemyCount.text = text4;
			GameManager core4 = GM.Core;
			int permanentEnemiesNumber = core4._stage.PermanentEnemiesNumber;
			string text5 = System.Number.FormatInt32(permanentEnemiesNumber, (ReadOnlySpan<char>)(&obj), null);
			string text6 = "Permanent: " + text5;
			_permanentEnemyCount.text = text6;
		}
		DateTime now = DateTime.Now;
		string text7 = System.DateTimeFormat.Format(now, "HH:mm:ss", (IFormatProvider)null);
		string text8 = "Time: " + text7;
		_currentTimeText.text = text8;
	}

	public void ForceTreasure(int level)
	{
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Expected O, but got Unknown
		//IL_033a: Expected O, but got I4
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e1: Expected O, but got Unknown
		//IL_03c9: Expected O, but got I4
		//IL_046b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0470: Expected O, but got Unknown
		//IL_0458: Expected O, but got I4
		//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ff: Expected O, but got Unknown
		//IL_04e7: Expected O, but got I4
		//IL_0589: Unknown result type (might be due to invalid IL or missing references)
		//IL_058e: Expected O, but got Unknown
		//IL_0576: Expected O, but got I4
		//IL_0686: Unknown result type (might be due to invalid IL or missing references)
		//IL_068b: Expected O, but got Unknown
		//IL_0715: Unknown result type (might be due to invalid IL or missing references)
		//IL_071a: Expected O, but got Unknown
		//IL_07a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a9: Expected O, but got Unknown
		//IL_0833: Unknown result type (might be due to invalid IL or missing references)
		//IL_0838: Expected O, but got Unknown
		//IL_08c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c7: Expected O, but got Unknown
		//IL_0082->IL0943: Incompatible stack heights: 1 vs 0
		//IL_00c4->IL0943: Incompatible stack heights: 1 vs 0
		//IL_0105->IL09b7: Incompatible stack heights: 1 vs 2
		//IL_09f4->IL0943: Incompatible stack heights: 2 vs 0
		//IL_0194->IL09f9: Incompatible stack heights: 2 vs 3
		//IL_0a36->IL0943: Incompatible stack heights: 3 vs 0
		//IL_0223->IL0a3b: Incompatible stack heights: 3 vs 4
		//IL_0a53->IL0943: Incompatible stack heights: 4 vs 0
		//IL_02bc->IL0943: Incompatible stack heights: 4 vs 0
		//IL_02fe->IL0943: Incompatible stack heights: 4 vs 0
		//IL_033f->IL0a58: Incompatible stack heights: 4 vs 5
		//IL_0a95->IL0943: Incompatible stack heights: 5 vs 0
		//IL_03ce->IL0a9a: Incompatible stack heights: 5 vs 6
		//IL_0ad7->IL0943: Incompatible stack heights: 6 vs 0
		//IL_045d->IL0adc: Incompatible stack heights: 6 vs 7
		//IL_0b19->IL0943: Incompatible stack heights: 7 vs 0
		//IL_04ec->IL0b1e: Incompatible stack heights: 7 vs 8
		//IL_0b5b->IL0943: Incompatible stack heights: 8 vs 0
		//IL_057b->IL0b60: Incompatible stack heights: 8 vs 9
		//IL_05f5->IL0943: Incompatible stack heights: 9 vs 0
		//IL_0637->IL0943: Incompatible stack heights: 9 vs 0
		//IL_0678->IL0b72: Incompatible stack heights: 9 vs 10
		//IL_0baf->IL0943: Incompatible stack heights: 10 vs 0
		//IL_0707->IL0bb4: Incompatible stack heights: 10 vs 11
		//IL_0bf1->IL0943: Incompatible stack heights: 11 vs 0
		//IL_0796->IL0bf6: Incompatible stack heights: 11 vs 12
		//IL_0c33->IL0943: Incompatible stack heights: 12 vs 0
		//IL_0825->IL0c38: Incompatible stack heights: 12 vs 13
		//IL_0c75->IL0943: Incompatible stack heights: 13 vs 0
		//IL_08b4->IL0c7a: Incompatible stack heights: 13 vs 14
		//IL_0921->IL0943: Incompatible stack heights: 14 vs 0
		GameSessionData gameSessionData = _gameSessionData;
		if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
		{
			Transform transform = gameSessionData._activeCharacter.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				Treasure treasure = new Treasure();
				List<float> list = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
				if (list != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v809 @ rax_v20 (System.Collections.Generic.List`1<System.Single>)+1C]");
					_ = (nint)0 + (nint)1;
					IntPtr cachedPtr = ((UnityEngine.Object)(object)list).m_CachedPtr;
					if (((UnityEngine.Object)(object)list).m_CachedPtr != (IntPtr)0)
					{
						CancellationTokenSource cancellationTokenSource = ((MonoBehaviour)(object)list).m_CancellationTokenSource;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rcx_v17 (System.IntPtr)+18]");
						if ((nint)cancellationTokenSource >= 0)
						{
							list.AddWithResize(0f);
						}
						else
						{
							CancellationTokenSource cancellationTokenSource2 = (CancellationTokenSource)(((MonoBehaviour)(object)list).m_CancellationTokenSource + 1);
							((MonoBehaviour)(object)list).m_CancellationTokenSource = cancellationTokenSource2;
							CancellationTokenSource cancellationTokenSource3 = ((MonoBehaviour)(object)list).m_CancellationTokenSource;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rcx_v17 (System.IntPtr)+18]");
							bool flag2 = (nint)cancellationTokenSource3 >= 0;
							_ = 0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v809 @ rax_v20 (System.Collections.Generic.List`1<System.Single>)+1C]");
						_ = (nint)0 + (nint)1;
						IntPtr cachedPtr2 = ((UnityEngine.Object)(object)list).m_CachedPtr;
						if (((UnityEngine.Object)(object)list).m_CachedPtr != (IntPtr)0)
						{
							CancellationTokenSource cancellationTokenSource4 = ((MonoBehaviour)(object)list).m_CancellationTokenSource;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rdx_v12 (System.IntPtr)+18]");
							if ((nint)cancellationTokenSource4 >= 0)
							{
								list.AddWithResize(0f);
							}
							else
							{
								CancellationTokenSource cancellationTokenSource5 = (CancellationTokenSource)(((MonoBehaviour)(object)list).m_CancellationTokenSource + 1);
								((MonoBehaviour)(object)list).m_CancellationTokenSource = cancellationTokenSource5;
								CancellationTokenSource cancellationTokenSource6 = ((MonoBehaviour)(object)list).m_CancellationTokenSource;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rdx_v12 (System.IntPtr)+18]");
								bool flag3 = (nint)cancellationTokenSource6 >= 0;
								_ = 0;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v809 @ rax_v20 (System.Collections.Generic.List`1<System.Single>)+1C]");
							_ = (nint)0 + (nint)1;
							IntPtr cachedPtr3 = ((UnityEngine.Object)(object)list).m_CachedPtr;
							if (((UnityEngine.Object)(object)list).m_CachedPtr != (IntPtr)0)
							{
								CancellationTokenSource cancellationTokenSource7 = ((MonoBehaviour)(object)list).m_CancellationTokenSource;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rdx_v13 (System.IntPtr)+18]");
								if ((nint)cancellationTokenSource7 >= 0)
								{
									list.AddWithResize(30f);
								}
								else
								{
									CancellationTokenSource cancellationTokenSource8 = (CancellationTokenSource)(((MonoBehaviour)(object)list).m_CancellationTokenSource + 1);
									((MonoBehaviour)(object)list).m_CancellationTokenSource = cancellationTokenSource8;
									CancellationTokenSource cancellationTokenSource9 = ((MonoBehaviour)(object)list).m_CancellationTokenSource;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rdx_v13 (System.IntPtr)+18]");
									bool flag4 = (nint)cancellationTokenSource9 >= 0;
									_ = 1106247680;
								}
								if (treasure != null)
								{
									treasure._003Cchances_003Ek__BackingField = list;
									treasure._003Clevel_003Ek__BackingField = level;
									List<PrizeType?> list2 = new List<PrizeType?>();
									if (list2 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v942 @ rax_v27 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
										_ = (nint)0 + (nint)1;
										IntPtr cachedPtr4 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
										if (((UnityEngine.Object)(object)list2).m_CachedPtr != (IntPtr)0)
										{
											CancellationTokenSource cancellationTokenSource10 = ((MonoBehaviour)(object)list2).m_CancellationTokenSource;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdx_v16 (System.IntPtr)+18]");
											if ((nint)cancellationTokenSource10 >= 0)
											{
												list2.AddWithResize((PrizeType?)(object)1);
											}
											else
											{
												CancellationTokenSource cancellationTokenSource11 = (CancellationTokenSource)(((MonoBehaviour)(object)list2).m_CancellationTokenSource + 1);
												((MonoBehaviour)(object)list2).m_CancellationTokenSource = cancellationTokenSource11;
												CancellationTokenSource cancellationTokenSource12 = ((MonoBehaviour)(object)list2).m_CancellationTokenSource;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdx_v16 (System.IntPtr)+18]");
												bool flag5 = (nint)cancellationTokenSource12 >= 0;
												_ = 1;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v942 @ rax_v27 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
											_ = (nint)0 + (nint)1;
											IntPtr cachedPtr5 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
											if (((UnityEngine.Object)(object)list2).m_CachedPtr != (IntPtr)0)
											{
												CancellationTokenSource cancellationTokenSource13 = ((MonoBehaviour)(object)list2).m_CancellationTokenSource;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdx_v18 (System.IntPtr)+18]");
												if ((nint)cancellationTokenSource13 >= 0)
												{
													list2.AddWithResize((PrizeType?)(object)1);
												}
												else
												{
													CancellationTokenSource cancellationTokenSource14 = (CancellationTokenSource)(((MonoBehaviour)(object)list2).m_CancellationTokenSource + 1);
													((MonoBehaviour)(object)list2).m_CancellationTokenSource = cancellationTokenSource14;
													CancellationTokenSource cancellationTokenSource15 = ((MonoBehaviour)(object)list2).m_CancellationTokenSource;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdx_v18 (System.IntPtr)+18]");
													bool flag6 = (nint)cancellationTokenSource15 >= 0;
													_ = 1;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v942 @ rax_v27 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
												_ = (nint)0 + (nint)1;
												IntPtr cachedPtr6 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
												if (((UnityEngine.Object)(object)list2).m_CachedPtr != (IntPtr)0)
												{
													CancellationTokenSource cancellationTokenSource16 = ((MonoBehaviour)(object)list2).m_CancellationTokenSource;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdx_v20 (System.IntPtr)+18]");
													if ((nint)cancellationTokenSource16 >= 0)
													{
														list2.AddWithResize((PrizeType?)(object)1);
													}
													else
													{
														CancellationTokenSource cancellationTokenSource17 = (CancellationTokenSource)(((MonoBehaviour)(object)list2).m_CancellationTokenSource + 1);
														((MonoBehaviour)(object)list2).m_CancellationTokenSource = cancellationTokenSource17;
														CancellationTokenSource cancellationTokenSource18 = ((MonoBehaviour)(object)list2).m_CancellationTokenSource;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdx_v20 (System.IntPtr)+18]");
														bool flag7 = (nint)cancellationTokenSource18 >= 0;
														_ = 1;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v942 @ rax_v27 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
													_ = (nint)0 + (nint)1;
													IntPtr cachedPtr7 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
													if (((UnityEngine.Object)(object)list2).m_CachedPtr != (IntPtr)0)
													{
														CancellationTokenSource cancellationTokenSource19 = ((MonoBehaviour)(object)list2).m_CancellationTokenSource;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rdx_v22 (System.IntPtr)+18]");
														if ((nint)cancellationTokenSource19 >= 0)
														{
															list2.AddWithResize((PrizeType?)(object)1);
														}
														else
														{
															CancellationTokenSource cancellationTokenSource20 = (CancellationTokenSource)(((MonoBehaviour)(object)list2).m_CancellationTokenSource + 1);
															((MonoBehaviour)(object)list2).m_CancellationTokenSource = cancellationTokenSource20;
															CancellationTokenSource cancellationTokenSource21 = ((MonoBehaviour)(object)list2).m_CancellationTokenSource;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rdx_v22 (System.IntPtr)+18]");
															bool flag8 = (nint)cancellationTokenSource21 >= 0;
															_ = 1;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v942 @ rax_v27 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
														_ = (nint)0 + (nint)1;
														IntPtr cachedPtr8 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
														if (((UnityEngine.Object)(object)list2).m_CachedPtr != (IntPtr)0)
														{
															CancellationTokenSource cancellationTokenSource22 = ((MonoBehaviour)(object)list2).m_CancellationTokenSource;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rdx_v24 (System.IntPtr)+18]");
															if ((nint)cancellationTokenSource22 >= 0)
															{
																list2.AddWithResize((PrizeType?)(object)1);
															}
															else
															{
																CancellationTokenSource cancellationTokenSource23 = (CancellationTokenSource)(((MonoBehaviour)(object)list2).m_CancellationTokenSource + 1);
																((MonoBehaviour)(object)list2).m_CancellationTokenSource = cancellationTokenSource23;
																CancellationTokenSource cancellationTokenSource24 = ((MonoBehaviour)(object)list2).m_CancellationTokenSource;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rdx_v24 (System.IntPtr)+18]");
																bool flag9 = (nint)cancellationTokenSource24 >= 0;
																_ = 1;
															}
															treasure._003CprizeTypes_003Ek__BackingField = list2;
															List<WeaponType> list3 = new List<WeaponType>();
															if (list3 != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1173 @ rax_v36 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
																_ = (nint)0 + (nint)1;
																IntPtr cachedPtr9 = ((UnityEngine.Object)(object)list3).m_CachedPtr;
																if (((UnityEngine.Object)(object)list3).m_CachedPtr != (IntPtr)0)
																{
																	CancellationTokenSource cancellationTokenSource25 = ((MonoBehaviour)(object)list3).m_CancellationTokenSource;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rdx_v28 (System.IntPtr)+18]");
																	if ((nint)cancellationTokenSource25 >= 0)
																	{
																		((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)55);
																	}
																	else
																	{
																		CancellationTokenSource cancellationTokenSource26 = (CancellationTokenSource)(((MonoBehaviour)(object)list3).m_CancellationTokenSource + 1);
																		((MonoBehaviour)(object)list3).m_CancellationTokenSource = cancellationTokenSource26;
																		CancellationTokenSource cancellationTokenSource27 = ((MonoBehaviour)(object)list3).m_CancellationTokenSource;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rdx_v28 (System.IntPtr)+18]");
																		bool flag10 = (nint)cancellationTokenSource27 >= 0;
																		_ = 55;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1173 @ rax_v36 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
																	_ = (nint)0 + (nint)1;
																	IntPtr cachedPtr10 = ((UnityEngine.Object)(object)list3).m_CachedPtr;
																	if (((UnityEngine.Object)(object)list3).m_CachedPtr != (IntPtr)0)
																	{
																		CancellationTokenSource cancellationTokenSource28 = ((MonoBehaviour)(object)list3).m_CancellationTokenSource;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rdx_v30 (System.IntPtr)+18]");
																		if ((nint)cancellationTokenSource28 >= 0)
																		{
																			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)55);
																		}
																		else
																		{
																			CancellationTokenSource cancellationTokenSource29 = (CancellationTokenSource)(((MonoBehaviour)(object)list3).m_CancellationTokenSource + 1);
																			((MonoBehaviour)(object)list3).m_CancellationTokenSource = cancellationTokenSource29;
																			CancellationTokenSource cancellationTokenSource30 = ((MonoBehaviour)(object)list3).m_CancellationTokenSource;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rdx_v30 (System.IntPtr)+18]");
																			bool flag11 = (nint)cancellationTokenSource30 >= 0;
																			_ = 55;
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1173 @ rax_v36 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
																		_ = (nint)0 + (nint)1;
																		IntPtr cachedPtr11 = ((UnityEngine.Object)(object)list3).m_CachedPtr;
																		if (((UnityEngine.Object)(object)list3).m_CachedPtr != (IntPtr)0)
																		{
																			CancellationTokenSource cancellationTokenSource31 = ((MonoBehaviour)(object)list3).m_CancellationTokenSource;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rdx_v32 (System.IntPtr)+18]");
																			if ((nint)cancellationTokenSource31 >= 0)
																			{
																				((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)55);
																			}
																			else
																			{
																				CancellationTokenSource cancellationTokenSource32 = (CancellationTokenSource)(((MonoBehaviour)(object)list3).m_CancellationTokenSource + 1);
																				((MonoBehaviour)(object)list3).m_CancellationTokenSource = cancellationTokenSource32;
																				CancellationTokenSource cancellationTokenSource33 = ((MonoBehaviour)(object)list3).m_CancellationTokenSource;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rdx_v32 (System.IntPtr)+18]");
																				bool flag12 = (nint)cancellationTokenSource33 >= 0;
																				_ = 55;
																			}
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1173 @ rax_v36 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
																			_ = (nint)0 + (nint)1;
																			IntPtr cachedPtr12 = ((UnityEngine.Object)(object)list3).m_CachedPtr;
																			if (((UnityEngine.Object)(object)list3).m_CachedPtr != (IntPtr)0)
																			{
																				CancellationTokenSource cancellationTokenSource34 = ((MonoBehaviour)(object)list3).m_CancellationTokenSource;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rdx_v34 (System.IntPtr)+18]");
																				if ((nint)cancellationTokenSource34 >= 0)
																				{
																					((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)55);
																				}
																				else
																				{
																					CancellationTokenSource cancellationTokenSource35 = (CancellationTokenSource)(((MonoBehaviour)(object)list3).m_CancellationTokenSource + 1);
																					((MonoBehaviour)(object)list3).m_CancellationTokenSource = cancellationTokenSource35;
																					CancellationTokenSource cancellationTokenSource36 = ((MonoBehaviour)(object)list3).m_CancellationTokenSource;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rdx_v34 (System.IntPtr)+18]");
																					bool flag13 = (nint)cancellationTokenSource36 >= 0;
																					_ = 55;
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1173 @ rax_v36 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
																				_ = (nint)0 + (nint)1;
																				IntPtr cachedPtr13 = ((UnityEngine.Object)(object)list3).m_CachedPtr;
																				if (((UnityEngine.Object)(object)list3).m_CachedPtr != (IntPtr)0)
																				{
																					CancellationTokenSource cancellationTokenSource37 = ((MonoBehaviour)(object)list3).m_CancellationTokenSource;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rdx_v36 (System.IntPtr)+18]");
																					if ((nint)cancellationTokenSource37 >= 0)
																					{
																						((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)55);
																					}
																					else
																					{
																						CancellationTokenSource cancellationTokenSource38 = (CancellationTokenSource)(((MonoBehaviour)(object)list3).m_CancellationTokenSource + 1);
																						((MonoBehaviour)(object)list3).m_CancellationTokenSource = cancellationTokenSource38;
																						CancellationTokenSource cancellationTokenSource39 = ((MonoBehaviour)(object)list3).m_CancellationTokenSource;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rdx_v36 (System.IntPtr)+18]");
																						bool flag14 = (nint)cancellationTokenSource39 >= 0;
																						_ = 55;
																					}
																					treasure._003CfixedPrizes_003Ek__BackingField = list3;
																					if ((object)_gameManager != null)
																					{
																						Vector2 pos = default(Vector2);
																						TreasureChest treasureChest = _gameManager.MakeTreasure(pos, treasure);
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
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void FindRelic()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E180");
	}

	public void FindItem()
	{
	}

	public void ForceLevelUp()
	{
		GameManager core = GM.Core;
		float xp;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			GameSessionData gameSessionData = _gameSessionData;
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
			xp = activeCharacter._xp;
		}
		else
		{
			OnlineStageManager instance = OnlineStageManager._instance;
			PlayerInfo playerInfo = OnlineStageManager._instance.ReturnPlayerInfoForSeat(instance._firstSeat);
			VampireSurvivors.Objects.Characters.CharacterController characterController = playerInfo.CharacterController;
			xp = characterController._xp;
		}
		LevelUpFactory levelUpFactory = _levelUpFactory;
		float xp2 = levelUpFactory._currentXpFactor - xp;
		_gameManager.AddPlayerXp(xp2, XPMultiplierMode.IgnoreAll);
	}

	public void Pause()
	{
		VampireSurvivors.Objects.Characters.CharacterController playerOne = GM.Core.PlayerOne;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B4A0");
	}

	public void KillPlayer()
	{
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			GameSessionData gameSessionData = _gameSessionData;
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
			gameSessionData._activeCharacter.TakeDamage(activeCharacter._currentHp);
		}
		else
		{
			PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
			VampireSurvivors.Objects.Characters.CharacterController characterController = myPlayerInfo.CharacterController;
			characterController.TakeDamage(characterController._currentHp);
		}
	}

	public void AddRandomExperience()
	{
		//IL_0028: Expected O, but got I4
		object obj = UnityEngine.Random.RandomRangeInt(0, 99);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAEAB0");
	}

	public void PickupCoinBag()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E180");
	}

	public void CancelAutomation()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0072: Expected I, but got O
		//IL_008e: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		_automationCancel.SetActive(value: false);
	}

	public Cheats()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
