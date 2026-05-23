using System;
using System.Collections.Generic;
using UnityEngine;

public class ProfilesMenu : MonoBehaviour, PageTemplateHost
{
	private enum State
	{
		Normal = 0,
		InList = 1
	}

	private class SaveInfo
	{
		public int index;

		public string id;

		public string pageItemIdPrefix;

		public string profileDescription;

		public string confirmDescription;

		public SaveData data;

		public bool exists
		{
			get
			{
				return data != null;
			}
		}
	}

	private enum OpKind
	{
		Copy = 0,
		Delete = 1
	}

	private class Op
	{
		public OpKind kind;

		public int a = -1;

		public int b = -1;

		public ListPanel.Item GetListItem(List<SaveInfo> saveInfos)
		{
			string[] array = new string[0];
			string text = ((!Lang.loadedLanguage.isRTL) ? " >> " : " << ");
			array = ((kind != OpKind.Delete) ? new string[4]
			{
				Lang.Get("profile_option_copy"),
				saveInfos[a].confirmDescription,
				text,
				saveInfos[b].confirmDescription
			} : new string[2]
			{
				Lang.Get("profile_option_delete"),
				saveInfos[a].confirmDescription
			});
			if (Lang.loadedLanguage.isRTL)
			{
				Array.Reverse(array);
			}
			return new ListPanel.Item(array, this);
		}

		public static TextAnchor[] GetListAlignments(OpKind kind)
		{
			if (kind != OpKind.Delete)
			{
				return new TextAnchor[4]
				{
					TextAnchor.MiddleLeft,
					TextAnchor.MiddleLeft,
					TextAnchor.MiddleCenter,
					TextAnchor.MiddleLeft
				};
			}
			return new TextAnchor[2]
			{
				TextAnchor.MiddleLeft,
				TextAnchor.MiddleRight
			};
		}
	}

	private delegate void OnListItemSelected(ListPanel.Item selectedItem);

	public AudioClip beginAudioClip;

	private PageTemplate pageTemplate;

	private TitleRoot titleRoot;

	private ListPanel listPanel;

	private List<SaveInfo> saveInfos;

	private SaveInfo selectOnFirstFrameSaveInfo;

	private State state
	{
		get
		{
			return listPanel.isOpen ? State.InList : State.Normal;
		}
		set
		{
			listPanel.gameObject.SetActive(value == State.InList);
			pageTemplate.interactable = value == State.Normal;
		}
	}

	private void OnEnable()
	{
		if (listPanel == null)
		{
			listPanel = GetComponentInChildren<ListPanel>(true);
			if (listPanel == null)
			{
				return;
			}
			titleRoot = GetComponentInParent<TitleRoot>();
			pageTemplate = GetComponent<PageTemplate>();
			listPanel.audioKit = titleRoot.audioKit;
			listPanel.gameObject.SetActive(false);
		}
		if (listPanel != null)
		{
			Refresh();
		}
		if (saveInfos == null)
		{
			return;
		}
		selectOnFirstFrameSaveInfo = null;
		foreach (SaveInfo saveInfo in saveInfos)
		{
			if (saveInfo.exists && (selectOnFirstFrameSaveInfo == null || saveInfo.data.diskDate.systemDateTime > selectOnFirstFrameSaveInfo.data.diskDate.systemDateTime))
			{
				selectOnFirstFrameSaveInfo = saveInfo;
			}
		}
		if (selectOnFirstFrameSaveInfo != null)
		{
			pageTemplate.SetInitialFocus(PageItem.ButtonSide.Right, pageTemplate.pageItemDict[selectOnFirstFrameSaveInfo.pageItemIdPrefix + "continue"].selectable);
		}
	}

	private void Update()
	{
		if (RInput.GetButtonDown(10))
		{
			if (listPanel.isOpen)
			{
				listPanel.gameObject.SetActive(false);
			}
			else
			{
				titleRoot.OnProfilesDone();
			}
		}
		if (!pageTemplate.interactable && !listPanel.isOpen)
		{
			pageTemplate.interactable = true;
		}
	}

	private static string MakeDurationString(string idPrefix, float s, bool hasJustNow)
	{
		int num = Mathf.FloorToInt(s / 60f / 60f);
		int num2 = Mathf.FloorToInt(s / 60f) % 60;
		string empty = string.Empty;
		if (num > 1)
		{
			num2 = Mathf.Max(2, num2);
			empty = ((num2 <= 0) ? "_h2" : "_h2m2");
		}
		else if (num == 1)
		{
			num2 = Mathf.Max(2, num2);
			empty = ((num2 <= 0) ? "_h1" : "_h1m2");
		}
		else if (hasJustNow && num2 < 2)
		{
			empty = "_justnow";
		}
		else
		{
			num2 = Mathf.Max(2, num2);
			empty = "_m2";
		}
		string id = idPrefix + empty;
		return Lang.Get(id, "$h", num, "$m", num2);
	}

	private void Refresh()
	{
		saveInfos = new List<SaveInfo>();
		for (int i = 0; i < 3; i++)
		{
			SaveInfo saveInfo = new SaveInfo();
			saveInfo.index = i;
			saveInfo.id = string.Format("P{0}", i + 1);
			saveInfo.pageItemIdPrefix = string.Format("p{0}-", i);
			if (SaveData.CanLoad(saveInfo.id))
			{
				saveInfo.data = new SaveData();
				saveInfo.data.Load(saveInfo.id);
				SaveData.Date diskDate = saveInfo.data.diskDate;
				saveInfo.confirmDescription = Lang.Get("profile_description_full", "$num", i + 1, "$year", diskDate.year, "$month", diskDate.month, "$day", diskDate.day, "$day", diskDate.day, "$time", diskDate.timeStr, "$fates", saveInfo.data.GetNumFatesCorrect());
				string text = MakeDurationString("profile_playtime", saveInfo.data.generalRo.playTime, false);
				TimeSpan timeSpan = DateTime.Now - diskDate.systemDateTime;
				string empty = string.Empty;
				empty = ((!(timeSpan.TotalHours < 49.0)) ? Lang.Get("profile_lastplayed_date", "$month", diskDate.systemDateTime.Month, "$day", diskDate.systemDateTime.Day, "$year", diskDate.systemDateTime.Year) : MakeDurationString("profile_lastplayed", (float)(DateTime.Now - diskDate.systemDateTime).TotalSeconds, true));
				string counted = Lang.GetCounted(saveInfo.data.GetNumFatesCorrect(), "profile_fates_zero", "profile_fates_zero", "profile_fates_morethanone");
				saveInfo.profileDescription = text + "\n" + empty + "\n" + counted;
			}
			else
			{
				saveInfo.data = null;
				saveInfo.confirmDescription = Lang.Get("profile_description_empty", "$num", i + 1);
				saveInfo.profileDescription = Lang.Get("profile_fates_zero");
			}
			saveInfos.Add(saveInfo);
		}
		pageTemplate.BeginRefresh();
		Dictionary<string, PageItem> pageItemDict = pageTemplate.pageItemDict;
		int num = 0;
		foreach (SaveInfo saveInfo2 in saveInfos)
		{
			if (saveInfo2.exists)
			{
				SaveData.Date diskDate2 = saveInfo2.data.diskDate;
				pageItemDict[saveInfo2.pageItemIdPrefix + "description"].text = saveInfo2.profileDescription;
				pageItemDict[saveInfo2.pageItemIdPrefix + "continue"].text = Lang.Get("profile_continue");
				pageItemDict[saveInfo2.pageItemIdPrefix + "rewind"].touched = saveInfo2.data.CanRewind();
				num++;
			}
			else
			{
				pageItemDict[saveInfo2.pageItemIdPrefix + "description"].text = saveInfo2.profileDescription;
				pageItemDict[saveInfo2.pageItemIdPrefix + "continue"].text = Lang.Get("profile_begin");
				pageItemDict[saveInfo2.pageItemIdPrefix + "rewind"].touched = false;
			}
		}
		pageItemDict["copydelete"].touched = num > 0;
		pageItemDict["lowerdivider"].touched = num > 0;
		pageTemplate.EndRefresh();
	}

	public void MoveOffPage(int dir, PageItem sourcePageItem)
	{
	}

	private void ExecuteContinue(SaveInfo saveInfo)
	{
		AudioOneShot.Play(beginAudioClip);
		titleRoot.OnProfilesDone(saveInfo.id);
	}

	private void ConfirmRewind(SaveInfo saveInfo)
	{
		bool zoneIsSolved = saveInfo.data.GetZoneIsSolved(Story.Zone.Ship);
		ListPanel.Spec spec = new ListPanel.Spec(null, string.Empty);
		spec.title = Lang.Get((!zoneIsSolved) ? "profile_rewind_warning_a" : "profile_rewind_warning_b");
		spec.items.Add(new ListPanel.Item(Lang.Get("profile_option_cancel")));
		spec.items.Add(new ListPanel.Item(Lang.Get("profile_option_rewind"), "REWIND"));
		OpenList(spec, delegate(ListPanel.Item selectedItem)
		{
			if (selectedItem != null && selectedItem.data as string == "REWIND")
			{
				saveInfo.data.Rewind();
				saveInfo.data.Save(saveInfo.id);
				ExecuteContinue(saveInfo);
			}
		});
	}

	public void OnPageButtonClick(PageItem pageItem)
	{
		switch (pageItem.buttonSettings.actionId)
		{
		case "p0-button-continue":
			ExecuteContinue(saveInfos[0]);
			break;
		case "p1-button-continue":
			ExecuteContinue(saveInfos[1]);
			break;
		case "p2-button-continue":
			ExecuteContinue(saveInfos[2]);
			break;
		case "p0-button-rewind":
			ConfirmRewind(saveInfos[0]);
			break;
		case "p1-button-rewind":
			ConfirmRewind(saveInfos[1]);
			break;
		case "p2-button-rewind":
			ConfirmRewind(saveInfos[2]);
			break;
		case "button-delete":
		{
			List<Op> list2 = new List<Op>();
			foreach (SaveInfo saveInfo3 in saveInfos)
			{
				if (saveInfo3.exists)
				{
					list2.Add(new Op
					{
						kind = OpKind.Delete,
						a = saveInfo3.index
					});
				}
			}
			ListOps(OpKind.Delete, list2);
			break;
		}
		case "button-copy":
		{
			List<Op> list = new List<Op>();
			for (int i = 0; i < saveInfos.Count; i++)
			{
				SaveInfo saveInfo = saveInfos[i];
				if (!saveInfo.exists)
				{
					continue;
				}
				for (int j = 0; j < saveInfos.Count; j++)
				{
					if (i != j)
					{
						SaveInfo saveInfo2 = saveInfos[j];
						list.Add(new Op
						{
							kind = OpKind.Copy,
							a = saveInfo.index,
							b = saveInfo2.index
						});
					}
				}
			}
			ListOps(OpKind.Copy, list);
			break;
		}
		}
	}

	private void ListOps(OpKind kind, List<Op> ops)
	{
		ListPanel.Spec spec = new ListPanel.Spec(null, string.Empty);
		if (kind == OpKind.Delete)
		{
			spec.title = Lang.Get("profile_delete");
		}
		else
		{
			spec.title = Lang.Get("profile_copy");
		}
		foreach (Op op in ops)
		{
			spec.items.Add(op.GetListItem(saveInfos));
		}
		spec.items.Add(new ListPanel.Item(Lang.Get("profile_option_cancel")));
		spec.alignments = Op.GetListAlignments(kind);
		spec.selectedIndex = spec.items.Count - 1;
		OpenList(spec, delegate(ListPanel.Item selectedItem)
		{
			ConfirmOp(selectedItem.data as Op);
		});
	}

	private void ConfirmOp(Op op)
	{
		if (op == null)
		{
			return;
		}
		ListPanel.Spec spec = new ListPanel.Spec(null, string.Empty);
		if (op.kind == OpKind.Delete)
		{
			spec.title = Lang.Get("profile_confirm", "$num", saveInfos[op.a].index + 1);
			spec.items.Add(op.GetListItem(saveInfos));
		}
		else
		{
			if (saveInfos[op.b].data == null)
			{
				ExecuteOp(op);
				return;
			}
			spec.title = Lang.Get("profile_confirm", "$num", saveInfos[op.b].index + 1);
			spec.items.Add(op.GetListItem(saveInfos));
		}
		spec.items.Add(new ListPanel.Item(Lang.Get("profile_option_cancel")));
		spec.alignments = Op.GetListAlignments(op.kind);
		spec.selectedIndex = spec.items.Count - 1;
		OpenList(spec, delegate(ListPanel.Item selectedItem)
		{
			ExecuteOp(selectedItem.data as Op);
		});
	}

	private void ExecuteOp(Op op)
	{
		if (op != null)
		{
			if (op.kind == OpKind.Copy)
			{
				SaveData.MakeBackup(saveInfos[op.b].id, "CopiedOver", true);
				SaveData.Copy(saveInfos[op.a].id, saveInfos[op.b].id);
			}
			else
			{
				SaveData.MakeBackup(saveInfos[op.a].id, "Deleted", true);
				SaveData.Delete(saveInfos[op.a].id);
			}
			Refresh();
		}
	}

	private void OpenList(ListPanel.Spec spec, OnListItemSelected onListItemSelected)
	{
		spec.onItemSelected = delegate(ListPanel.Spec s, ListPanel.Item selectedItem)
		{
			if (selectedItem != null)
			{
				titleRoot.audioKit.Play("tap");
				onListItemSelected(selectedItem);
			}
			else
			{
				titleRoot.audioKit.Play("popup-close");
			}
		};
		titleRoot.audioKit.Play("popup-open");
		state = State.InList;
		spec.outsideAlpha = 0.75f;
		pageTemplate.interactable = false;
		listPanel.Open(spec);
	}
}
