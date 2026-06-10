using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.TaskManager;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Extensions;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.Production;
using NSMedieval.Repository;
using NSMedieval.Roles;
using NSMedieval.RoomDetection;
using NSMedieval.Tools;
using NSMedieval.Tutorial;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.Almanac
{
	public class AlmanacPanelManager : PanelBase
	{
		private static bool initDone;

		[SerializeField]
		private AlmanacSearchManager searchManager;

		[SerializeField]
		private LayoutGroupView groupView;

		[SerializeField]
		private AlmanacEntryLayoutItemView entryView;

		[SerializeField]
		private ScrollRect contentScrollRect;

		[SerializeField]
		private SoundButton closeButton;

		[SerializeField]
		private SoundButton navigationPreviousButton;

		[SerializeField]
		private SoundButton navigationNextButton;

		[SerializeField]
		private TMP_Text breadcrumbsText;

		private readonly UndoRedoStack<Action> actionStack = new UndoRedoStack<Action>();

		private readonly Dictionary<string, AlmanacEntry> almanacEntries = new Dictionary<string, AlmanacEntry>();

		private readonly Dictionary<string, AlmanacGroup> almanacGroups = new Dictionary<string, AlmanacGroup>();

		private readonly List<AlmanacGroupLayoutItemView> groupButtons = new List<AlmanacGroupLayoutItemView>();

		private string currentSelection = string.Empty;

		private bool needEntriesRefresh;

		public static bool InitDone => initDone;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			initDone = false;
		}

		public bool IsEntryLocked(string entryID)
		{
			if (!almanacEntries.TryGetValue(entryID, out var value))
			{
				return false;
			}
			return MonoSingleton<GlobalSaveController>.Instance.IsBuildingLocked(value.GetID());
		}

		protected override void Start()
		{
			base.Start();
			closeButton.onClick.AddListener(Hide);
			navigationPreviousButton.onClick.AddListener(ShowPrevious);
			navigationNextButton.onClick.AddListener(ShowNext);
			MonoSingleton<UIController>.Instance.AlmanacEntrySelected += OnTextLinkClick;
			MonoSingleton<UIController>.Instance.SelectMaterialEvent += OnMaterialChange;
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.AlmanacEntrySelected -= OnTextLinkClick;
				MonoSingleton<UIController>.Instance.SelectMaterialEvent -= OnMaterialChange;
			}
		}

		protected override PanelGroupType GetGroupType()
		{
			return PanelGroupType.UpperRight;
		}

		public override void Show()
		{
			Log.Info(GetType().Name + " Show", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Almanac\\AlmanacPanelManager.cs");
			base.Show();
		}

		public void SetupAlmanac()
		{
			initDone = false;
			Task task = new Task();
			task.ThenWaitUntil((float t) => Repository<AlmanacEntriesRepository, AlmanacEntry>.IsInstantiated() && Repository<AlmanacEntriesRepository, AlmanacEntry>.Instance.InitFinished).Then(Show).Then(Initialize)
				.Then(delegate
				{
					searchManager.Initialize(almanacGroups, almanacEntries);
				})
				.ThenWaitUntil((float time) => searchManager.InitComplete)
				.Then(Hide)
				.Then(delegate
				{
					initDone = true;
				});
			MonoSingleton<TaskController>.Instance.EnqueueCustomTask(task);
		}

		public void RefreshAlmanac()
		{
			currentSelection = string.Empty;
			needEntriesRefresh = true;
		}

		private IEnumerator RefreshAlmanacAfterThreadFinished()
		{
			while (!Repository<AlmanacEntriesRepository, AlmanacEntry>.IsInstantiated() || !Repository<AlmanacEntriesRepository, AlmanacEntry>.Instance.InitFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			Initialize();
		}

		protected override void UpdatePanel()
		{
		}

		private void Initialize()
		{
			almanacEntries.Clear();
			almanacGroups.Clear();
			foreach (AlmanacEntry value in Repository<AlmanacEntriesRepository, AlmanacEntry>.Instance.AllEntries.Values)
			{
				almanacEntries.Add(value.Name, new AlmanacEntry(value.GetID(), value.Name, value.GroupId, value.Path, value.IconId, value.Entries, value.MaterialQualityEntries, value.Tags));
			}
			foreach (Almanac allItem in Repository<AlmanacRepository, Almanac>.Instance.GetAllItems())
			{
				if (allItem.SubGroupIDs.Count == 0)
				{
					List<string> list = new List<string>();
					foreach (AlmanacEntry value2 in almanacEntries.Values)
					{
						if (value2.GroupId == allItem.GetID())
						{
							list.Add(value2.Name);
						}
					}
					almanacGroups.Add(allItem.GetID(), new AlmanacGroup(allItem.GetID(), allItem.Path, allItem.Depth, null, list));
				}
				else
				{
					almanacGroups.Add(allItem.GetID(), new AlmanacGroup(allItem.GetID(), allItem.Path, allItem.Depth, allItem.SubGroupIDs, null));
				}
			}
			if (currentSelection == string.Empty)
			{
				actionStack.Do(delegate
				{
					ShowEntry("Index", visible: false);
				})?.Invoke();
			}
		}

		private void OnMaterialChange(string materialId)
		{
			if (almanacEntries.TryGetValue(currentSelection, out var value))
			{
				value.SelectMaterial(materialId);
				actionStack.Do(delegate
				{
					ShowEntry(currentSelection);
				})?.Invoke();
			}
		}

		private void OnTextLinkClick(string entryId)
		{
			if (!TutorialManager.IsTutorialActive)
			{
				if (needEntriesRefresh)
				{
					Initialize();
					needEntriesRefresh = false;
				}
				actionStack.Do(delegate
				{
					ShowEntry(entryId);
				})?.Invoke();
			}
		}

		private void ShowEntry(string entryId, bool visible = true)
		{
			if (almanacGroups.TryGetValue(entryId, out var value))
			{
				if (!groupView.gameObject.activeSelf)
				{
					SwitchView();
				}
				groupButtons.SetAllActive(active: false);
				if (value.SubGroupIDs != null)
				{
					foreach (string item in value.SubGroupIDs)
					{
						AlmanacGroupLayoutItemView next = groupButtons.GetNext(groupView);
						next.SetData("almanac_group_name_" + item, isShown: false, delegate
						{
							actionStack.Do(delegate
							{
								ShowEntry(item);
							})?.Invoke();
							OnNavigation();
						});
						next.SetImageData(item);
						next.gameObject.SetActive(value: true);
					}
				}
				if (value.EntryIDs != null)
				{
					foreach (string item2 in value.EntryIDs)
					{
						AlmanacGroupLayoutItemView next2 = groupButtons.GetNext(groupView);
						next2.SetData(almanacEntries[item2].Entries.Dictionary["title"], GlobalSaveController.CurrentVillageData.IsAlmanacEntryShown(item2), delegate
						{
							actionStack.Do(delegate
							{
								ShowEntry(item2);
							})?.Invoke();
							OnNavigation();
						});
						next2.SetImageData(almanacEntries[item2].IconId, almanacEntries[item2].IconColorOverlay);
						if (!MonoSingleton<GlobalSaveController>.Instance.IsBuildingLocked(almanacEntries[item2].GetID()))
						{
							next2.gameObject.SetActive(value: true);
						}
						else
						{
							next2.gameObject.SetActive(value: false);
						}
					}
				}
				LayoutRebuilder.ForceRebuildLayoutImmediate(groupView.GetComponent<RectTransform>());
			}
			if (almanacEntries.TryGetValue(entryId, out var entry))
			{
				GlobalSaveController.CurrentVillageData.SetAlmanacEntryShown(entryId);
				searchManager.SetEntryShown(entryId);
				if (!entryView.gameObject.activeSelf)
				{
					SwitchView();
				}
				string text = MonoSingleton<LocalizationController>.Instance.GetText(entry.Entries.Dictionary["info"]) ?? "";
				if (entry.GroupId == "Gameplaytips")
				{
					text = TextFormatting.FormatKeyInputEvent(text);
				}
				if (text.Contains("<room_type_list>"))
				{
					List<string> list = new List<string>();
					foreach (RoomType allItem in Repository<RoomTypeRepository, RoomType>.Instance.GetAllItems())
					{
						list.Add(LocKeyUtils.GetName(allItem.LocKeys));
					}
					text = text.Replace("<room_type_list>", UiUtils.GetLocalizedAlmanacLinks(list, ", "));
				}
				if (text.Contains("<event_list>"))
				{
					List<string> list2 = new List<string>();
					foreach (PlayerTriggeredEvent allItem2 in Repository<PlayerTriggeredEventRepository, PlayerTriggeredEvent>.Instance.GetAllItems())
					{
						list2.Add(LocKeyUtils.GetName(allItem2.LocKeys));
					}
					text = text.Replace("<event_list>", UiUtils.GetLocalizedAlmanacLinks(list2, ", "));
				}
				if (text.Contains("<role_list>"))
				{
					List<string> list3 = new List<string>();
					foreach (Role allItem3 in Repository<RoleRepository, Role>.Instance.GetAllItems())
					{
						list3.Add(LocKeyUtils.GetName(allItem3.LocKeys));
					}
					text = text.Replace("<role_list>", UiUtils.GetLocalizedAlmanacLinks(list3, ", "));
				}
				if (entry.TryGetMaterialQualityEntry(out var entry2))
				{
					text = text + "\n" + entry2;
				}
				string spriteName = ((entry.IconId == "almanac_default") ? "null" : entry.IconId);
				entryView.SetData(MonoSingleton<LocalizationController>.Instance.GetText(entry.Entries.Dictionary["title"]), text, spriteName, entry.Entries.Dictionary["video"]);
				bool flag = true;
				bool flag2 = true;
				almanacGroups.TryGetValue(entry.GroupId, out var almanacGroup);
				if (almanacGroup != null && almanacGroup.EntryIDs != null && almanacGroup.EntryIDs.Count > 0)
				{
					flag = entry.Name == almanacGroup.EntryIDs.First();
					flag2 = entry.Name == almanacGroup.EntryIDs.Last();
				}
				entryView.PreviousButton.interactable = !flag;
				entryView.NextButton.interactable = !flag2;
				entryView.PreviousButton.onClick.RemoveAllListeners();
				if (almanacGroup != null)
				{
					entryView.PreviousButton.onClick.AddListener(delegate
					{
						ShowPreviousEntryInGroup(entry.Name, almanacGroup.EntryIDs);
					});
				}
				entryView.NextButton.onClick.RemoveAllListeners();
				if (almanacGroup != null)
				{
					entryView.NextButton.onClick.AddListener(delegate
					{
						ShowNextEntryInGroup(entry.Name, almanacGroup.EntryIDs);
					});
				}
				LayoutRebuilder.ForceRebuildLayoutImmediate(entryView.GetComponent<RectTransform>());
			}
			currentSelection = entryId;
			if (!base.gameObject.activeInHierarchy && visible)
			{
				Show();
			}
			OnNavigation();
		}

		private void ShowPreviousEntryInGroup(string entryName, List<string> entryIDs)
		{
			if (!entryIDs.Contains(entryName))
			{
				return;
			}
			int num = entryIDs.IndexOf(entryName);
			if (num == 0)
			{
				return;
			}
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				if (!IsEntryLocked(entryIDs[num2]))
				{
					ShowEntry(entryIDs[num2]);
					break;
				}
			}
		}

		private void ShowNextEntryInGroup(string entryName, List<string> entryIDs)
		{
			if (!entryIDs.Contains(entryName))
			{
				return;
			}
			int num = entryIDs.IndexOf(entryName);
			if (num == entryIDs.Count - 1)
			{
				return;
			}
			for (int i = num + 1; i < entryIDs.Count; i++)
			{
				if (!IsEntryLocked(entryIDs[i]))
				{
					ShowEntry(entryIDs[i]);
					break;
				}
			}
		}

		private void ShowNext()
		{
			actionStack.Redo()?.Invoke();
			OnNavigation();
		}

		private void ShowPrevious()
		{
			actionStack.Undo()?.Invoke();
			OnNavigation();
		}

		private void OnNavigation()
		{
			breadcrumbsText.SetText(FormatBreadcrumbsText());
			navigationPreviousButton.interactable = actionStack.UndoCount > 1;
			navigationNextButton.interactable = actionStack.RedoCount > 0;
		}

		private string FormatBreadcrumbsText()
		{
			string empty = string.Empty;
			if (almanacGroups.ContainsKey(currentSelection))
			{
				empty = almanacGroups[currentSelection].Path;
			}
			else
			{
				if (!almanacEntries.ContainsKey(currentSelection))
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(39, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Almanac\\AlmanacPanelManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Missing Almanac key: ");
						messageBuilder.AppendFormatted(currentSelection);
						messageBuilder.AppendLiteral(", Entries count: ");
						messageBuilder.AppendFormatted(almanacEntries.Count);
						messageBuilder.AppendLiteral(" ");
						messageBuilder.AppendFormatted(almanacEntries.Keys.ToPrettyString());
					}
					Log.Error(messageBuilder);
					return empty;
				}
				empty = almanacEntries[currentSelection].Path;
			}
			string text = string.Empty;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string text2 = empty;
			for (int i = 0; i < text2.Length; i++)
			{
				char c = text2[i];
				if (char.IsUpper(c))
				{
					if (text != string.Empty)
					{
						dictionary.Add(text, GetLocalizedEntryName(text));
					}
					text = c.ToString();
				}
				else
				{
					text += c;
				}
			}
			dictionary.Add(text, GetLocalizedEntryName(text));
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Clear();
			bool flag = true;
			foreach (KeyValuePair<string, string> item in dictionary)
			{
				if (flag)
				{
					stringBuilder.Append(item.Value);
					flag = false;
				}
				else
				{
					stringBuilder.AppendFormat(" <sprite=\"crumb_arrow\" index=crumb_arrow> {0}", item.Value);
				}
			}
			return stringBuilder.ToString();
		}

		private void SwitchView()
		{
			groupView.gameObject.SetActive(!groupView.gameObject.activeSelf);
			entryView.SetActive(!entryView.gameObject.activeSelf);
			contentScrollRect.content = (groupView.gameObject.activeSelf ? groupView.GetComponent<RectTransform>() : entryView.GetComponent<RectTransform>());
		}

		private string GetLocalizedEntryName(string key)
		{
			if (almanacEntries.ContainsKey(key))
			{
				return UiUtils.GetLocalizedAlmanacLink(almanacEntries[key].Entries.Dictionary["title"]);
			}
			if (!almanacGroups.ContainsKey(key))
			{
				return "NULL";
			}
			return UiUtils.GetLocalizedAlmanacLink("almanac_group_name_" + key);
		}
	}
}
