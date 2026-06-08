using System.Collections.Generic;
using Stonescript;
using Stonescript.Runtime;
using UnityEngine;

public class SSCustomQuest : Scope
{
	private class WaitCallback
	{
		public int id;

		public string callback;

		public float timer;

		public List<object> parameters = new List<object>();

		private static int counter;

		public WaitCallback(string callback, float timer)
		{
			id = counter++;
			this.callback = callback;
			this.timer = timer;
		}
	}

	private Data.CustomQuestInstance quest;

	private CustomQuestsController controller;

	public Executable executable;

	private StonescriptObject hero;

	private SSLevel level;

	private IFunction rewardDialogCallback;

	private List<WaitCallback> waitCallbacks = new List<WaitCallback>();

	public SSLevel Level
	{
		get
		{
			return level;
		}
		set
		{
			level = value;
			SetVariable("level", level);
		}
	}

	public SSCustomQuest(Data.CustomQuestInstance quest, CustomQuestsController controller)
		: base(quest.def.scriptName)
	{
		this.quest = quest;
		this.controller = controller;
		hero = GameStates.Singleton.hero.SSObject;
		DeclareVariable("hero", hero);
		DeclareVariable("level", level);
		SSScriptableObject.Bind(this, this);
	}

	[StonescriptNativeMethod]
	public object Complete(List<object> parameters, InvocationContext ctx)
	{
		return controller.Complete(quest);
	}

	[StonescriptNativeMethod]
	public object Abandon(List<object> parameters, InvocationContext ctx)
	{
		controller.AbandonQuest(quest);
		controller.customQuestsScreen.MarkDirty();
		return null;
	}

	[StonescriptNativeMethod]
	public object GetStatus(List<object> parameters, InvocationContext ctx)
	{
		return quest.status;
	}

	private string SanitizeUGCString(string value)
	{
		return value.Replace('"', '＂');
	}

	[StonescriptNativeMethod]
	public object SetStatus(List<object> parameters, InvocationContext ctx)
	{
		string status = SanitizeUGCString(parameters[0] as string);
		controller.SetStatus(quest, status);
		return null;
	}

	[StonescriptNativeMethod]
	public object SetProgressTitle(List<object> parameters, InvocationContext ctx)
	{
		string title = SanitizeUGCString(parameters[0] as string);
		controller.SetProgressTitle(quest, title);
		return null;
	}

	[StonescriptNativeMethod]
	public object SetActions(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 2)
		{
			throw new StonescriptRuntimeException("SetActions requires at least 2 parameters.");
		}
		quest.actions.Clear();
		if (!(parameters[0] is string) && !(parameters[0] is IFunction))
		{
			throw new StonescriptRuntimeException("SetActions parameter 0 must be a callback.");
		}
		string item = SanitizeUGCString(parameters[0].ToString());
		quest.actions.Add(item);
		for (int i = 1; i < parameters.Count; i++)
		{
			object obj = parameters[i];
			if (!(obj is string))
			{
				throw new StonescriptRuntimeException("SetActions only accepts strings");
			}
			string item2 = SanitizeUGCString(obj as string);
			quest.actions.Add(item2);
		}
		CustomQuestsRowAdvanced rowForQuest = GameStates.Singleton.customQuestsScreen.GetRowForQuest(quest);
		if (rowForQuest != null)
		{
			rowForQuest.BindActionButtons();
		}
		return null;
	}

	[StonescriptNativeMethod]
	public object ClearActions(List<object> parameters, InvocationContext ctx)
	{
		quest.actions.Clear();
		CustomQuestsRowAdvanced rowForQuest = GameStates.Singleton.customQuestsScreen.GetRowForQuest(quest);
		if (rowForQuest != null)
		{
			rowForQuest.BindActionButtons();
		}
		return null;
	}

	[StonescriptNativeMethod]
	public object UpdateProgress(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 2)
		{
			controller.UpdateProgress(quest, (int)parameters[0], (int)parameters[1]);
		}
		else if (parameters.Count == 3)
		{
			controller.UpdateProgress(quest, (int)parameters[1], (int)parameters[2], (int)parameters[0]);
		}
		return null;
	}

	[StonescriptNativeMethod]
	public object SetCooldown(List<object> parameters, InvocationContext ctx)
	{
		int cooldown = -1;
		if (parameters.Count >= 1 && parameters[0] is int)
		{
			cooldown = (int)parameters[0];
		}
		CustomQuestsController.Singleton.SetCooldown(quest, cooldown);
		return null;
	}

	[StonescriptNativeMethod]
	public object ClearCooldown(List<object> parameters, InvocationContext ctx)
	{
		CustomQuestsController.Singleton.SetCooldown(quest, 0);
		return null;
	}

	[StonescriptNativeMethod]
	public object MarkSeen(List<object> parameters, InvocationContext ctx)
	{
		bool seen = parameters.Count != 1 || (bool)parameters[0];
		CustomQuestsController.Singleton.SetSeen(quest, seen);
		return null;
	}

	[StonescriptNativeMethod]
	public object CollectItem(List<object> parameters, InvocationContext ctx)
	{
		Item item = null;
		int count = 1;
		int num = 0;
		if (parameters.Count == 0)
		{
			throw new StonescriptRuntimeException("CollectItem must receive an Item parameter.");
		}
		if (parameters[num] is StonescriptObject)
		{
			SSScriptableObject scriptable = (parameters[num++] as StonescriptObject).Scriptable;
			if (scriptable != null)
			{
				item = scriptable.GetComponent<Item>();
			}
			count = ((parameters.Count <= num || !(parameters[num] is int)) ? item.count : ((int)parameters[num++]));
		}
		else if (parameters[num] is string)
		{
			item = (SSItemStatic.New(new List<object> { parameters[num++] }, ctx) as StonescriptObject)?.Scriptable.GetComponent<Item>();
			count = ((parameters.Count <= num || !(parameters[num] is int)) ? item.count : ((int)parameters[num++]));
		}
		if (item == null)
		{
			throw new StonescriptRuntimeException("CollectItem did not receive a valid item.");
		}
		if (parameters.Count > num)
		{
			if (!(parameters[num] is IFunction))
			{
				throw new RuntimeException(ctx, $"CollectItem argument {num} expected a function but received something else.");
			}
			rewardDialogCallback = ((parameters.Count > num) ? (parameters[num++] as IFunction) : null);
		}
		SequentialPopupManager.singleton.itemFoundDialog.OnDone += OnRewardDialogDone;
		SequentialPopupManager.singleton.itemFoundDialog.mode = ItemFoundDialog.DialogMode.CustomQuest;
		SfxController.singleton.Play("pickup_success");
		GameStates.Singleton.AddItemFromPickup(item, count);
		return item.ssObject;
	}

	private void OnRewardDialogDone()
	{
		SequentialPopupManager.singleton.itemFoundDialog.mode = ItemFoundDialog.DialogMode.Normal;
		SequentialPopupManager.singleton.itemFoundDialog.OnDone -= OnRewardDialogDone;
		IFunction function = rewardDialogCallback;
		rewardDialogCallback = null;
		function?.Invoke();
	}

	[StonescriptNativeMethod]
	public object Wait(List<object> parameters, InvocationContext ctx)
	{
		string callback = parameters[0].ToString();
		float timer = (float)(int)parameters[1] / 1000f;
		WaitCallback waitCallback = new WaitCallback(callback, timer);
		if (parameters.Count >= 3)
		{
			if (!(parameters[2] is StonescriptArray))
			{
				throw new StonescriptRuntimeException("Invalid callback parameters: array expected");
			}
			waitCallback.parameters.AddRange(parameters[2] as StonescriptArray);
		}
		waitCallbacks.Add(waitCallback);
		return waitCallback.id;
	}

	public void Update()
	{
		ProcessWaitCallbacks();
	}

	private void ProcessWaitCallbacks()
	{
		if (waitCallbacks.Count == 0)
		{
			return;
		}
		float deltaTime = Utils.deltaTime;
		for (int num = waitCallbacks.Count - 1; num >= 0; num--)
		{
			WaitCallback waitCallback = waitCallbacks[num];
			waitCallback.timer -= deltaTime;
			if (waitCallback.timer <= 0f)
			{
				executable.Execute(waitCallback.callback, waitCallback.parameters);
				if (num < waitCallbacks.Count)
				{
					waitCallbacks.RemoveAt(num);
				}
			}
		}
	}

	[StonescriptNativeMethod]
	public object ClearWaits(List<object> parameters, InvocationContext ctx)
	{
		waitCallbacks.Clear();
		return this;
	}

	[StonescriptNativeMethod]
	public object IsAvailable(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0)
		{
			throw new StonescriptRuntimeException("IsAvailable requires a quest id or object");
		}
		Data.Quest quest = null;
		if (parameters[0] is string)
		{
			string questId = parameters[0] as string;
			return QuestController.singleton.IsAvailable(questId);
		}
		if (parameters[0] is SSNativeObject<Data.Quest>)
		{
			quest = (parameters[0] as SSNativeObject<Data.Quest>).Source;
		}
		if (quest == null)
		{
			return false;
		}
		return QuestController.singleton.IsAvailable(quest);
	}

	[StonescriptNativeMethod]
	public object MakeAvailable(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0)
		{
			throw new StonescriptRuntimeException("MakeAvailable requires a quest id or object");
		}
		Data.Quest quest = null;
		if (parameters[0] is string)
		{
			quest = Data.Quest.FromString((parameters[0] as string).Replace("\\n", "\n"));
		}
		else if (parameters[0] is SSNativeObject<Data.Quest>)
		{
			quest = (parameters[0] as SSNativeObject<Data.Quest>).Source;
		}
		if (quest == null)
		{
			throw new StonescriptRuntimeException("Invalid quest");
		}
		QuestController.singleton.MakeAvailable(quest);
		GameStates.Singleton.workstationScreen.UpdateContents();
		return quest.ssObject;
	}

	[StonescriptNativeMethod]
	public object RemoveQuest(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0)
		{
			throw new StonescriptRuntimeException("RemoveQuest requires a quest id or object");
		}
		if (parameters[0] is string)
		{
			string questId = parameters[0] as string;
			QuestController.singleton.MakeUnavailable(questId);
			GameStates.Singleton.workstationScreen.UpdateContents();
		}
		else
		{
			if (!(parameters[0] is SSNativeObject<Data.Quest>))
			{
				throw new StonescriptRuntimeException("Invalid quest");
			}
			Data.Quest source = (parameters[0] as SSNativeObject<Data.Quest>).Source;
			QuestController.singleton.MakeUnavailable(source);
			GameStates.Singleton.workstationScreen.UpdateContents();
		}
		return null;
	}

	[StonescriptNativeMethod]
	public object CreateLocation(List<object> parameters, InvocationContext ctx)
	{
		return CreateQuest(parameters, ctx);
	}

	[StonescriptNativeMethod]
	public object CreateQuest(List<object> parameters, InvocationContext ctx)
	{
		Data.Quest quest = Data.Quest.FromString((parameters[0] as string).Replace("\\n", "\n"));
		if (quest.sequel != null)
		{
			quest.sequelRoot = QuestController.singleton.GetQuestById(quest.sequel);
			if (quest.sequelRoot == null)
			{
				Utils.LogError("Quest is a sequel with id " + quest.sequel + ", but the root quest was not found.");
			}
			else
			{
				Data.Trigger[] triggers = quest.triggers;
				quest.CopyUnsetValuesFrom(quest.sequelRoot);
				quest.triggers = triggers;
			}
		}
		quest.isCustomQuest = true;
		return quest.ssObject;
	}

	[StonescriptNativeMethod]
	public object GoToLocation(List<object> parameters, InvocationContext ctx)
	{
		Data.Quest quest = null;
		if (parameters != null && parameters.Count > 0 && parameters[0] is SSNativeObject<Data.Quest>)
		{
			quest = (parameters[0] as SSNativeObject<Data.Quest>).Source;
		}
		else
		{
			if (parameters == null || parameters.Count <= 0 || !(parameters[0] is string))
			{
				throw new StonescriptRuntimeException("Invalid location passed to GoToLocation.");
			}
			QuestController singleton = QuestController.singleton;
			string text = parameters[0] as string;
			if (!singleton.QuestExists(text))
			{
				throw new StonescriptRuntimeException("Quest \"" + text + "\" does not exist.");
			}
			int difficulty = 0;
			if (parameters.Count >= 2 && parameters[1] is int)
			{
				difficulty = (int)parameters[1];
			}
			else
			{
				for (int num = QuestController.singleton.GetStarDifficultyForQuest(text); num >= 3; num--)
				{
					Data.QuestStats statsForQuest = OfflineFarmController.singleton.GetStatsForQuest(text, num);
					if (statsForQuest != null && Mathf.RoundToInt(statsForQuest.averageTime.GetValue()) > 0)
					{
						difficulty = num;
						break;
					}
				}
			}
			quest = singleton.GetQuestByIdAndDifficulty(text, difficulty);
		}
		if (parameters != null && ((parameters.Count > 1 && parameters[1] is string && (string)parameters[1] == "ouroboros") || (parameters.Count > 2 && parameters[2] is string && (string)parameters[2] == "ouroboros")))
		{
			OuroborosWeapon.questToReplay = quest;
			GameStates.Singleton.ShowSoulstoneScreen(SoulstoneScreen.Type.OuroborosStone, GameStates.State.OuroborosPlayTransition);
			SoulstoneScreen.hideStopButton = true;
		}
		else
		{
			GameStates.Singleton.StartQuest(quest, playTransition: true, hardReset: true);
		}
		return null;
	}

	[StonescriptNativeMethod]
	public object SetFlag(List<object> parameters, InvocationContext ctx)
	{
		string flag = parameters[0] as string;
		bool value = true;
		if (parameters.Count >= 2 && parameters[1] is bool)
		{
			value = (bool)parameters[1];
		}
		ProgressFlags.SetFlag(flag, value);
		return null;
	}

	[StonescriptNativeMethod]
	public object GetFlag(List<object> parameters, InvocationContext ctx)
	{
		return ProgressFlags.GetFlag(parameters[0] as string);
	}
}
