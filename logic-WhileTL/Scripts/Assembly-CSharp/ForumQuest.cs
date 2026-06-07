using System;
using App.Data;
using Aux;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class ForumQuest : BaseQuest, ICloneable
{
	public string QuestKeyName;

	public string searchQueryKey;

	public string messagesKeyNames;

	public string buttonTextKey;

	public int scrollToMsg;

	public string headerKey;

	public bool exitActive;

	public bool autoTyping;

	private string[] messages;

	public string[] Messages
	{
		get
		{
			return messages ?? (messages = messagesKeyNames.Split(';'));
		}
		set
		{
			messages = value;
		}
	}

	public string SearchQuery => TextResources.GetString(searchQueryKey);

	public string ButtonText => TextResources.GetString(buttonTextKey);

	public string GetThemeName()
	{
		return TextResources.GetString(headerKey);
	}

	public ForumQuest()
	{
	}

	public ForumQuest(string questKeyName, string searchQuery, string messagesKeyNames, bool exitActive, string headerKey, bool autoTyping)
	{
		QuestKeyName = questKeyName;
		searchQueryKey = searchQuery;
		this.messagesKeyNames = messagesKeyNames;
		this.exitActive = exitActive;
		this.headerKey = headerKey;
		this.autoTyping = autoTyping;
	}

	public object Clone()
	{
		return new ForumQuest((QuestKeyName == null) ? null : ((string)QuestKeyName.Clone()), (searchQueryKey == null) ? null : ((string)searchQueryKey.Clone()), (messagesKeyNames == null) ? null : ((string)messagesKeyNames.Clone()), exitActive, (string)headerKey.Clone(), autoTyping)
		{
			KeyName = (string)KeyName.Clone()
		};
	}

	public override void ReInitConstructionArea(bool resetInOut = true)
	{
		QuestLine.GetQuest(QuestKeyName).GetTableQuest().ReInitConstructionArea(resetInOut);
	}

	private void RunConstructionTask()
	{
		Logic.Controller.Tree.OpenConstruction(KeyName);
	}

	public override void Start()
	{
		QuestLine.UpdateOrAddQuest(this);
		if (QuestKeyName != "-")
		{
			QuestLine.SetCurrentQuest(this);
		}
		Logic.GoogleController.Init(this, delegate
		{
			if (QuestKeyName == "-")
			{
				End();
			}
			else
			{
				RunConstructionTask();
			}
		});
		Logic.GoogleController.gameObject.SetActive(value: true);
	}

	public override void End()
	{
		base.End();
		Logic.TreeController.gameObject.SetActive(value: true);
		if (QuestKeyName == "-")
		{
			Logic.GetModel().RunTaskWhenTreeOpens = string.Empty;
		}
		Logic.GetController().OpenTree(QuestLine.GetQuest(KeyName));
		if (!(QuestKeyName == "-"))
		{
			return;
		}
		TreeController tree = Logic.TreeController;
		ScrollRect scrollRect = tree.ScrollRect;
		RectTransform component = tree.GetTaskGo("G/B DIVIDE").transform.parent.GetComponent<RectTransform>();
		if (!Logic.GetModel().globalSaves.IsSet(SaveFlags.DisabledTutorial) && !Logic.GetModel().P.firstTreeTutorialCompleted)
		{
			tree.firstTreeTutorial.gameObject.SetActive(value: true);
			Logic.GetSound().Play("Monokanal/WhileTrueLearn_TutorialPopup");
			tree.firstTreeTutorial.GetComponentInChildren<Button>().onClick.AddListener(delegate
			{
				Logic.GetModel().P.firstTreeTutorialCompleted = true;
				tree.firstTreeTutorial.gameObject.SetActive(value: false);
				tree.StartTask("G/B DIVIDE");
			});
		}
		scrollRect.content.localPosition = Helper.GetSnapToPositionToBringChildIntoView(scrollRect, component);
	}
}
