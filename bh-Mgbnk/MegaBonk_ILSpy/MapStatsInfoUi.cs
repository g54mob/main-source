using System;
using System.Collections.Generic;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts.Game.Other;
using Assets.Scripts.Saves___Serialization.Progression;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapStatsInfoUi : MonoBehaviour
{
	public TextMeshProUGUI t_mapName;

	public TextMeshProUGUI t_mapRuns;

	public TextMeshProUGUI t_tier;

	public TextMeshProUGUI t_highscore;

	public TextMeshProUGUI t_fastestTime;

	public RawImage characterIconPrefab;

	public RawImage mapIcon;

	private List<RawImage> characterIcons;

	private EMap currentMap;

	private int currentTier;

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<RunConfig> b = OnRunConfigChanged;
		Delegate obj = Delegate.Combine(MapSelectionUi.A_RunConfigChanged, b);
		if ((object)obj == null)
		{
			MapSelectionUi.A_RunConfigChanged = (Action<RunConfig>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<RunConfig> action = default(Action<RunConfig>);
		if (action != null)
		{
			MapSelectionUi.A_RunConfigChanged = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<RunConfig>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<RunConfig>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<RunConfig> value = OnRunConfigChanged;
		Delegate obj = Delegate.Remove(MapSelectionUi.A_RunConfigChanged, value);
		if ((object)obj == null)
		{
			MapSelectionUi.A_RunConfigChanged = (Action<RunConfig>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<RunConfig> action = default(Action<RunConfig>);
		if (action != null)
		{
			MapSelectionUi.A_RunConfigChanged = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<RunConfig>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<RunConfig>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnRunConfigChanged(RunConfig runConfig)
	{
		SetConfig(runConfig);
	}

	public unsafe void SetConfig(RunConfig runConfig)
	{
		//IL_01eb: Expected O, but got Ref
		//IL_0499: Expected I, but got O
		//IL_076f: Expected I4, but got O
		//IL_07f6: Expected I4, but got O
		//IL_0807: Expected I4, but got O
		//IL_089d: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a2: Expected O, but got Unknown
		if (runConfig != null && (object)runConfig.mapData != null)
		{
			((List<T>)(object)runConfig.mapData).RemoveAt(0);
			if ((object)mapIcon != null)
			{
				Texture texture = default(Texture);
				mapIcon.texture = texture;
				if ((object)runConfig.mapData != null)
				{
					((List<T>)(object)runConfig.mapData).set_Item(0, (T)null);
					string text = default(string);
					bool flag = text == null;
					string text2 = "";
					if (!flag)
					{
						text2 = text;
					}
					t_mapName.text = text2;
					TextMeshProUGUI textMeshProUGUI = t_tier;
					string localizedString = LocalizationUtility.GetLocalizedString("Other", "TIER", "Tier", useEnglishDefaultIfAvailable: false);
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
					object arg = default(object);
					string text3 = $"{localizedString} {arg}";
					t_tier.text = text3;
					Color tierColor = MyColorUtility.GetTierColor(runConfig.mapTierIndex);
					float num = 1f - tierColor.b;
					float num2 = num * 0.25f;
					float num3 = num2 + tierColor.b;
					float num4 = 1f - tierColor.g;
					float num5 = num4 * 0.25f;
					float num6 = num5 + tierColor.g;
					List<object>.Enumerator enumerator = default(List<object>.Enumerator);
					t_tier.color = (Color)(&enumerator);
					SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
					ProgressionSaveFile progression = saveManager.progression;
					MapData mapData = runConfig.mapData;
					MapProgress mapProgress = progression.menuMeta.GetMapProgress(mapData.eMap);
					int numTierRuns = mapProgress.GetNumTierRuns(runConfig.mapTierIndex);
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
					string localizedString2 = LocalizationUtility.GetLocalizedString("Other", "RUNS", "Runs", useEnglishDefaultIfAvailable: false);
					object arg2 = default(object);
					string text4 = $"{arg2} {localizedString2}";
					t_mapRuns.text = text4;
					if (characterIcons == null)
					{
						List<RawImage> list = new List<RawImage>();
						characterIcons = list;
						if (characterIcons == null)
						{
							goto IL_08fd;
						}
						characterIcons.Add(characterIconPrefab);
					}
					SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
					if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
					{
						ProgressionSaveFile progression2 = saveManager2.progression;
						if (saveManager2.progression != null)
						{
							MapData mapData2 = runConfig.mapData;
							if ((object)runConfig.mapData != null && progression2.menuMeta != null)
							{
								MapProgress mapProgress2 = progression2.menuMeta.GetMapProgress(mapData2.eMap);
								if (mapProgress2 != null)
								{
									string tierHighscoreString = mapProgress2.GetTierHighscoreString(runConfig.mapTierIndex);
									if ((object)t_highscore != null)
									{
										t_highscore.text = tierHighscoreString;
										List<RawImage> list2 = (List<RawImage>)(object)t_fastestTime;
										string tierFastestTimeString = mapProgress2.GetTierFastestTimeString(runConfig.mapTierIndex);
										if ((object)t_fastestTime != null)
										{
											nint num7 = (nint)list2;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v108 @ r9_v12 (Il2CppClass<System.Collections.Generic.List`1<UnityEngine.UI.RawImage>>)+558] (should have been resolved before IL gen)");
											if (characterIcons != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
												List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
												Component component = default(Component);
												while (enumerator2.MoveNext())
												{
													if ((object)component != null)
													{
														GameObject gameObject = component.gameObject;
														if ((object)gameObject != null)
														{
															gameObject.SetActive(value: false);
															continue;
														}
														throw new NullReferenceException();
													}
													throw new NullReferenceException();
												}
												((List<RawImage>.Enumerator*)(&enumerator2))->Dispose();
												SaveManager saveManager3 = SaveManager._003CInstance_003Ek__BackingField;
												if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
												{
													ProgressionSaveFile progression3 = saveManager3.progression;
													if (saveManager3.progression != null && progression3.menuMeta != null)
													{
														MapProgress mapProgress3 = progression3.menuMeta.GetMapProgress(currentMap);
														if (mapProgress3 != null)
														{
															List<ECharacter> tierCompletionCharacters = mapProgress3.GetTierCompletionCharacters(runConfig.mapTierIndex);
															bool flag2 = tierCompletionCharacters == null;
															List<RawImage> list3 = null;
															List<RawImage> list4 = null;
															if (!flag2)
															{
																while (true)
																{
																	List<RawImage> list5 = list4;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ rax_v62 (System.Collections.Generic.List`1<ECharacter>)+18]");
																	if ((nint)list5 < 0)
																	{
																		List<RawImage> list6 = characterIcons;
																		if (characterIcons == null)
																		{
																			break;
																		}
																		if ((nint)list3 >= list6._size)
																		{
																			if ((object)characterIconPrefab == null)
																			{
																				break;
																			}
																			Transform transform = characterIconPrefab.transform;
																			if ((object)transform == null)
																			{
																				break;
																			}
																			Transform parent = transform.parent;
																			RawImage item = UnityEngine.Object.Instantiate(characterIconPrefab, parent);
																			if (characterIcons == null)
																			{
																				break;
																			}
																			characterIcons.Add(item);
																		}
																		if (characterIcons == null)
																		{
																			break;
																		}
																		RawImage rawImage = characterIcons.get_Item((int)list3);
																		if ((object)rawImage == null)
																		{
																			break;
																		}
																		GameObject gameObject2 = rawImage.gameObject;
																		if ((object)gameObject2 == null)
																		{
																			break;
																		}
																		gameObject2.SetActive(value: true);
																		if (characterIcons == null)
																		{
																			break;
																		}
																		RawImage rawImage2 = characterIcons.get_Item((int)list3);
																		ECharacter character = tierCompletionCharacters.get_Item((int)list3);
																		if ((object)DataManager.Instance == null)
																		{
																			break;
																		}
																		CharacterData characterData = DataManager.Instance.GetCharacterData(character);
																		if ((object)characterData == null)
																		{
																			break;
																		}
																		Texture icon = characterData.GetIcon();
																		if ((object)rawImage2 == null)
																		{
																			break;
																		}
																		rawImage2.texture = icon;
																		list3 = (List<RawImage>)(list3 + 1);
																		list4 = list3;
																		continue;
																	}
																	MapData mapData3 = runConfig.mapData;
																	if ((object)runConfig.mapData == null)
																	{
																		break;
																	}
																	currentMap = mapData3.eMap;
																	currentTier = runConfig.mapTierIndex;
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
		goto IL_08fd;
		IL_08fd:
		throw new NullReferenceException();
	}
}
