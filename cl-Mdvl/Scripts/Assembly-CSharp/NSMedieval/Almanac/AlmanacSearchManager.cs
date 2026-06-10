using System;
using System.Collections;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.Almanac
{
	public class AlmanacSearchManager : MonoBehaviour
	{
		[SerializeField]
		private TMP_InputField searchInput;

		[SerializeField]
		private SoundButton clearButton;

		[SerializeField]
		private LayoutGroupView groupsParent;

		private int defaultMinimumDepth = 1;

		[NonSerialized]
		private Coroutine searchCoroutine;

		[NonSerialized]
		private Dictionary<string, AlmanacGroup> almanacGroups;

		[NonSerialized]
		private Dictionary<string, AlmanacEntry> almanacEntries;

		[NonSerialized]
		private Dictionary<AlmanacSearchSubgroupItemView, List<string>> entryTags = new Dictionary<AlmanacSearchSubgroupItemView, List<string>>();

		[NonSerialized]
		private Dictionary<string, List<AlmanacSearchSubgroupItemView>> entryButtons = new Dictionary<string, List<AlmanacSearchSubgroupItemView>>();

		[NonSerialized]
		private Dictionary<string, AlmanacSearchGroupItemView> groupButtons = new Dictionary<string, AlmanacSearchGroupItemView>();

		public bool InitComplete { get; private set; }

		public void Initialize(Dictionary<string, AlmanacGroup> almanacGroups, Dictionary<string, AlmanacEntry> almanacEntries)
		{
			InitComplete = false;
			this.almanacGroups = almanacGroups;
			this.almanacEntries = almanacEntries;
			clearButton.onClick.AddListener(ClearInput);
			searchInput.onDeselect.AddListener(delegate
			{
				OnSearchInput(inputLocked: false);
			});
			searchInput.onEndEdit.AddListener(delegate
			{
				OnSearchInput(inputLocked: false);
			});
			searchInput.onValueChanged.AddListener(delegate(string value)
			{
				OnSearchValueChange(value);
			});
			foreach (string key in this.almanacGroups.Keys)
			{
				AlmanacSearchGroupItemView almanacSearchGroupItemView = GetGroup();
				groupButtons.Add(key, almanacSearchGroupItemView);
				almanacSearchGroupItemView.SetupGroup(MonoSingleton<LocalizationController>.Instance.GetText("almanac_group_name_" + key), key);
				almanacSearchGroupItemView.name = key;
				bool flag = false;
				List<string> list;
				if (this.almanacGroups[key].SubGroupIDs != null)
				{
					list = this.almanacGroups[key].SubGroupIDs;
				}
				else
				{
					flag = true;
					list = this.almanacGroups[key].EntryIDs;
				}
				entryButtons.Add(key, new List<AlmanacSearchSubgroupItemView>());
				foreach (string item in list)
				{
					AlmanacSearchSubgroupItemView subgroup = GetSubgroup(almanacSearchGroupItemView.SubgroupParent);
					string id = item;
					string text;
					if (flag)
					{
						text = MonoSingleton<LocalizationController>.Instance.GetText(this.almanacEntries[id].Entries.Dictionary["title"]);
						entryTags.Add(subgroup, this.almanacEntries[id].Tags);
					}
					else
					{
						text = MonoSingleton<LocalizationController>.Instance.GetText("almanac_group_name_" + id);
					}
					subgroup.SetData(id, text, GlobalSaveController.CurrentVillageData.IsAlmanacEntryShown(item), delegate
					{
						ShowEntry(id);
					});
					subgroup.name = text;
					almanacSearchGroupItemView.AddChild(subgroup);
					entryButtons[key].Add(subgroup);
				}
			}
			ClearInput();
		}

		public void SetEntryShown(string entryId)
		{
			foreach (KeyValuePair<string, List<AlmanacSearchSubgroupItemView>> entryButton in entryButtons)
			{
				foreach (AlmanacSearchSubgroupItemView item in entryButton.Value)
				{
					if (item.EntryId == entryId)
					{
						item.SetShown(GlobalSaveController.CurrentVillageData.IsAlmanacEntryShown(entryId));
					}
				}
			}
		}

		private void ShowEntry(string entryId)
		{
			MonoSingleton<UIController>.Instance.ShowAlmanacEntry(entryId);
		}

		private void ClearInput()
		{
			searchInput.Select();
			searchInput.text = string.Empty;
			OnSearchValueChange(string.Empty);
		}

		private void OnSearchValueChange(string value)
		{
			if (base.gameObject.activeInHierarchy)
			{
				if (searchCoroutine != null)
				{
					StopCoroutine(searchCoroutine);
				}
				searchCoroutine = StartCoroutine(SearchCoroutine(value));
			}
		}

		private IEnumerator SearchCoroutine(string value)
		{
			int counter = 0;
			if (value == string.Empty)
			{
				OnSearchInput(inputLocked: false);
				foreach (KeyValuePair<string, AlmanacSearchGroupItemView> pair in groupButtons)
				{
					counter++;
					if (counter % 5 == 0)
					{
						yield return new WaitForEndOfFrame();
					}
					pair.Value.Hide(almanacGroups[pair.Key].Depth <= defaultMinimumDepth);
				}
			}
			else
			{
				OnSearchInput(inputLocked: true);
				foreach (string key in groupButtons.Keys)
				{
					foreach (AlmanacSearchSubgroupItemView item in entryButtons[key])
					{
						if (MonoSingleton<UIController>.Instance.IsAlmanacEntryLocked(item.EntryId))
						{
							continue;
						}
						int num = (item.TextObject.text.ToLower().Contains(value.ToLower()) ? 1 : 0);
						foreach (AlmanacSearchSubgroupItemView key2 in entryTags.Keys)
						{
							if (!(key2 == item))
							{
								continue;
							}
							foreach (string item2 in entryTags[key2])
							{
								if (!(item2 == "null") && MonoSingleton<LocalizationController>.Instance.GetText(item2).ToLower().Contains(value.ToLower()))
								{
									num++;
								}
							}
						}
						item.gameObject.SetActive(num > 0);
					}
					groupButtons[key].Refresh();
				}
			}
			InitComplete = true;
			yield return new WaitForEndOfFrame();
			Refresh();
		}

		private AlmanacSearchSubgroupItemView GetSubgroup(LayoutGroupView parentGroup)
		{
			AlmanacSearchSubgroupItemView component = UnityEngine.Object.Instantiate(parentGroup.Prefab, parentGroup.transform).GetComponent<AlmanacSearchSubgroupItemView>();
			component.gameObject.SetActive(value: false);
			return component;
		}

		private AlmanacSearchGroupItemView GetGroup()
		{
			AlmanacSearchGroupItemView component = UnityEngine.Object.Instantiate(groupsParent.Prefab, groupsParent.transform).GetComponent<AlmanacSearchGroupItemView>();
			component.gameObject.SetActive(value: false);
			return component;
		}

		private void Refresh()
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(groupsParent.GetComponent<RectTransform>());
		}

		private void OnSearchInput(bool inputLocked)
		{
			if (!(!searchInput.isFocused && inputLocked) && MonoSingleton<InputManager>.IsInstantiated())
			{
				MonoSingleton<InputManager>.Instance.SetInputEnabled(!inputLocked);
			}
		}

		private void OnEnable()
		{
			MonoSingleton<AlmanacController>.Instance.OnSearchGroupExpansionEvent += Refresh;
		}

		private void OnDisable()
		{
			if (MonoSingleton<AlmanacController>.IsInstantiated())
			{
				MonoSingleton<AlmanacController>.Instance.OnSearchGroupExpansionEvent -= Refresh;
			}
		}
	}
}
