using System;
using System.Collections.Generic;
using Stonescript;
using Stonescript.Runtime;
using UnityEngine;

public class CustomQuestsUi : AsciiObject, IAsciiObject
{
	[Serializable]
	public class NpcDialog
	{
		public NPCDialogBubble dialogBubble;

		public SSScriptableObject ssDialog;

		public Character npc;

		public List<string> dialogQueue = new List<string>();

		public Action onComplete;

		public Action onUpdate;

		public Action onTextDisplayed;

		public bool showing;

		public int offsetX;

		public int offsetY;

		public string align = "";

		public IFunction callbackFunc;

		public List<object> callbackParameters = new List<object>();

		public IFunction updateCallbackFunc;

		public object GetAlign()
		{
			return align;
		}

		public void SetAlign(object value)
		{
			align = value as string;
		}

		public void Reset()
		{
			dialogBubble.ClearDone();
			dialogBubble.autoHideTime = -1;
			dialogBubble.playerCanClose = true;
			dialogBubble.playerCanSkip = true;
			dialogBubble.preferredWidth = 24;
			npc = null;
			onComplete = null;
			onUpdate = null;
			onTextDisplayed = null;
			showing = false;
			offsetX = 0;
			offsetY = 0;
			align = "";
			dialogQueue.Clear();
			callbackFunc = null;
			callbackParameters.Clear();
			updateCallbackFunc = null;
		}

		public void OnDialogDone()
		{
			if (dialogQueue.Count > 0)
			{
				string text = dialogQueue[0];
				dialogQueue.RemoveAt(0);
				if (text.StartsWith("tid_"))
				{
					text = Te.xt(text);
				}
				dialogBubble.SetMessage(text);
				dialogBubble.SetNPCMouthPosition(npc.mouthOffsetX, npc.mouthOffsetY);
				dialogBubble.Show();
				if (npc != null && !string.IsNullOrEmpty(npc.dialogTalkSfx))
				{
					MindStoneGameModel.PlaySoundParseOptions(npc.dialogTalkSfx);
				}
				showing = true;
				onUpdate?.Invoke();
			}
			else
			{
				showing = false;
				onComplete?.Invoke();
			}
		}

		public void TryCompleteCallback()
		{
			if (callbackFunc != null)
			{
				callbackFunc.Invoke(callbackParameters);
			}
		}

		public void TryUpdateCallback()
		{
			if (updateCallbackFunc != null)
			{
				updateCallbackFunc.Invoke();
			}
		}

		public void TryTextDisplayedCallback()
		{
			onTextDisplayed?.Invoke();
		}

		public object OnUpdate(List<object> parameters, InvocationContext ctx)
		{
			if (parameters.Count == 0 || !(parameters[0] is IFunction))
			{
				throw new StonescriptRuntimeException("OnUpdate requires a callback function.");
			}
			updateCallbackFunc = parameters[0] as IFunction;
			onUpdate = delegate
			{
				TryUpdateCallback();
			};
			return ssDialog.Target;
		}

		public object OnComplete(List<object> parameters, InvocationContext ctx)
		{
			int num = 0;
			if (parameters.Count <= num || !(parameters[num] is IFunction))
			{
				throw new StonescriptRuntimeException("OnComplete requires a callback function.");
			}
			callbackFunc = parameters[num++] as IFunction;
			callbackParameters.Clear();
			if (parameters.Count > num)
			{
				if (!(parameters[num] is StonescriptArray))
				{
					throw new StonescriptRuntimeException("");
				}
				StonescriptArray collection = parameters[num++] as StonescriptArray;
				callbackParameters.AddRange(collection);
			}
			return ssDialog.Target;
		}

		public object OnTextDisplayed(List<object> parameters, InvocationContext ctx)
		{
			int num = 0;
			if (parameters.Count <= num || !(parameters[num] is IFunction))
			{
				throw new StonescriptRuntimeException("OnComplete requires a callback function.");
			}
			IFunction callback = parameters[num++] as IFunction;
			onTextDisplayed = (Action)Delegate.Combine(onTextDisplayed, (Action)delegate
			{
				callback.Invoke();
			});
			return ssDialog.Target;
		}

		public object SetText(List<object> parameters, InvocationContext ctx)
		{
			if (parameters.Count == 0)
			{
				throw new StonescriptRuntimeException("You must pass a string or an array of strings for dialog.SetText.");
			}
			if (parameters[0] is StonescriptArray)
			{
				dialogQueue.Clear();
				StonescriptArray stonescriptArray = parameters[0] as StonescriptArray;
				dialogQueue.AddRange(stonescriptArray.ToList<string>());
			}
			else
			{
				if (!(parameters[0] is string))
				{
					throw new StonescriptRuntimeException("You must pass a string or an array of strings for dialog.SetText.");
				}
				dialogQueue.Clear();
				string item = parameters[0] as string;
				dialogQueue.Add(item);
			}
			return ssDialog.Target;
		}

		public object Show(List<object> parameters, InvocationContext ctx)
		{
			OnDialogDone();
			return ssDialog.Target;
		}
	}

	protected class SSTreasureDialog : StonescriptObject
	{
		public OpenTreasureDialog openTreasureDialog;

		public List<Item> rewardsOpened = new List<Item>();

		public List<int> rewardAmounts = new List<int>();

		public StonescriptArray ssRewards = new StonescriptArray();

		public StonescriptArray ssRewardAmounts = new StonescriptArray();

		public IFunction onCompleteCallback;

		public List<object> callbackParameters = new List<object>();

		public bool showing;

		public SSTreasureDialog(OpenTreasureDialog openTreasureDialog)
		{
			this.openTreasureDialog = openTreasureDialog;
			TreasureItem.OnTreasureOpened += OnRewardOpened;
			openTreasureDialog.OnComplete += OnDialogComplete;
			SSScriptableObject.Bind(this, this);
		}

		public void Clear()
		{
			onCompleteCallback = null;
			rewardsOpened.Clear();
			rewardAmounts.Clear();
			ssRewards.Clear();
			ssRewardAmounts.Clear();
			callbackParameters.Clear();
			showing = false;
		}

		public void Setup(TreasureItem treasure)
		{
			Clear();
			openTreasureDialog.Setup(treasure);
		}

		protected void OnRewardOpened(string itemId, string groupId, List<Item> items, List<int> amounts)
		{
			rewardsOpened.AddRange(items);
			rewardAmounts.AddRange(amounts);
		}

		protected void OnDialogComplete()
		{
			showing = false;
			if (onCompleteCallback != null)
			{
				rewardsOpened.ForEach(delegate(Item item)
				{
					ssRewards.Add(item.ssObject);
				});
				rewardAmounts.ForEach(delegate(int amount)
				{
					ssRewardAmounts.Add(amount);
				});
				callbackParameters.Add(ssRewards);
				callbackParameters.Add(ssRewardAmounts);
				onCompleteCallback?.Invoke(callbackParameters);
			}
		}

		[StonescriptNativeMethod]
		public object OnComplete(List<object> parameters, InvocationContext ctx)
		{
			onCompleteCallback = parameters[0] as IFunction;
			return this;
		}

		[StonescriptNativeMethod]
		public object Show(List<object> parameters, InvocationContext ctx)
		{
			showing = true;
			openTreasureDialog.Show();
			return this;
		}
	}

	public float displayDuration = 1f;

	public int maxRows = 3;

	public RewardProgressCard customQuestProgressCardPrefab;

	public CustomQuestsStoryDialog storyDialogPrefab;

	public CustomQuestsStoryDialog storyDialog;

	private bool storyShowing;

	private Action storyEndedCallback;

	private Action storyIndexChangedCallback;

	public OpenTreasureDialog openTreasureDialogPrefab;

	protected SSTreasureDialog treasureDialog;

	private List<string> storyQueue = new List<string>();

	private int storyIndex;

	[SerializeField]
	private List<NpcDialog> npcDialogPool = new List<NpcDialog>();

	[SerializeField]
	private List<NpcDialog> npcDialogsInUse = new List<NpcDialog>();

	public NPCDialogBubble dialogBubblePrefab;

	private PlayChoiceDialog optionDialog;

	private IFunction optionCallbackMethod;

	private GameStates.State optionPrevState;

	private bool sightStoneDialogShowing;

	public IFunction sightStoneCallbackMethod;

	public RewardProgressCard customQuestProgressCard { get; private set; }

	public static CustomQuestsUi Singleton { get; private set; }

	private void Awake()
	{
		Singleton = this;
	}

	private void Start()
	{
		customQuestProgressCard = UnityEngine.Object.Instantiate(customQuestProgressCardPrefab);
		CustomQuestsController.Singleton.OnQuestProgress += OnQuestProgress;
		storyDialog = UnityEngine.Object.Instantiate(storyDialogPrefab);
		storyDialog.OnDone += HandleStoryDone;
		CustomQuestsStoryDialog customQuestsStoryDialog = storyDialog;
		customQuestsStoryDialog.OnOut = (Action<CustomQuestsStoryDialog>)Delegate.Combine(customQuestsStoryDialog.OnOut, new Action<CustomQuestsStoryDialog>(HandleStoryOut));
		treasureDialog = new SSTreasureDialog(UnityEngine.Object.Instantiate(openTreasureDialogPrefab));
	}

	public void OnQuestProgress(Data.CustomQuestInstance quest, int initialProgress)
	{
		string desc = quest.status;
		if (quest.progressTitle != null)
		{
			desc = quest.progressTitle;
		}
		customQuestProgressCard.Setup(null, initialProgress, Mathf.Min(quest.progress, quest.target), quest.target, desc);
	}

	public void ClearAll()
	{
		if (storyShowing)
		{
			storyShowing = false;
		}
		storyQueue.Clear();
		foreach (NpcDialog item in npcDialogsInUse)
		{
			item.Reset();
			npcDialogPool.Add(item);
		}
		npcDialogsInUse.Clear();
	}

	public void ClearNPCDialogs()
	{
		foreach (NpcDialog item in npcDialogsInUse)
		{
			item.Reset();
			npcDialogPool.Add(item);
		}
		npcDialogsInUse.Clear();
	}

	[StonescriptNativeMethod]
	public object ClearAll(List<object> parameters, InvocationContext ctx)
	{
		ClearAll();
		return this;
	}

	private void AddStoryPage(string story)
	{
		storyQueue.Add(story);
	}

	private void StartStory()
	{
		storyIndex = -1;
		ProcessNextStory();
	}

	private void ProcessNextStory()
	{
		storyIndex++;
		storyIndexChangedCallback?.Invoke();
		if (storyQueue.Count > 0)
		{
			string text = storyQueue[0];
			storyQueue.RemoveAt(0);
			if (text.StartsWith("tid_"))
			{
				text = Te.xt(text);
			}
			storyDialog.SetMessage(text);
			storyShowing = true;
		}
		else
		{
			storyShowing = false;
			storyEndedCallback?.Invoke();
		}
	}

	private void HandleStoryDone(CustomQuestsStoryDialog dialog)
	{
		if (storyQueue.Count > 0)
		{
			ProcessNextStory();
		}
		else
		{
			storyDialog.FadeOut();
		}
	}

	private void HandleStoryOut(CustomQuestsStoryDialog dialog)
	{
		ProcessNextStory();
	}

	[StonescriptNativeGetter("isItemFoundDialogShowing")]
	public object Property_Get_IsItemFoundDialogShowing()
	{
		return SequentialPopupManager.singleton.itemFoundDialog.CurrentState == DialogNineSlice.State.In || SequentialPopupManager.singleton.itemFoundDialog.CurrentState == DialogNineSlice.State.Idle;
	}

	public override void UpdateTic()
	{
		customQuestProgressCard.UpdateTic();
		if (storyShowing)
		{
			storyDialog.UpdateTic();
		}
		if (GameStates.Singleton.CurrentState == GameStates.State.PlayItemScreen || GameStates.Singleton.CurrentState == GameStates.State.PlayMindStoneEdit)
		{
			return;
		}
		if (GameStates.Singleton.CurrentState != GameStates.State.SightstoneCharacterDialog)
		{
			for (int num = npcDialogsInUse.Count - 1; num >= 0; num--)
			{
				if (num < npcDialogsInUse.Count)
				{
					npcDialogsInUse[num].dialogBubble.UpdateTic();
				}
			}
		}
		if (sightStoneDialogShowing && GameStates.Singleton.CurrentState != GameStates.State.SightstoneCharacterDialog)
		{
			OnSightStoneDialogComplete();
		}
		if (treasureDialog.showing)
		{
			treasureDialog.openTreasureDialog.UpdateTic();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetX += r.width - PositionX;
		offsetY += PositionY;
		customQuestProgressCard.Draw(r, offsetX, offsetY);
		if (GameStates.Singleton.CurrentState == GameStates.State.PlayItemScreen || GameStates.Singleton.CurrentState == GameStates.State.PlayMindStoneEdit)
		{
			return;
		}
		foreach (NpcDialog item in npcDialogsInUse)
		{
			NPCDialogBubble dialogBubble = item.dialogBubble;
			Character npc = item.npc;
			int screenX = npc.lastDrawX + npc.mouthOffsetX;
			int screenY = npc.lastDrawY + npc.mouthOffsetY;
			dialogBubble.SetNPCMouthPosition(screenX, screenY);
			screenX = npc.lastDrawX + item.offsetX;
			screenY = npc.lastDrawY + item.offsetY;
			if (item.align == "bottom")
			{
				screenY -= dialogBubble.lineCount + 1;
			}
			else if (item.align == "center")
			{
				screenY -= dialogBubble.lineCount / 2;
			}
			else if (item.align != "top" && dialogBubble.lineCount > 7)
			{
				screenY -= dialogBubble.lineCount - 7;
			}
			dialogBubble.Draw(r, screenX, screenY);
		}
		if (treasureDialog.showing)
		{
			treasureDialog.openTreasureDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
	}

	public void LateDraw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetX += r.width - PositionX;
		offsetY += PositionY;
		if (storyShowing)
		{
			storyDialog.Draw(r, r.width / 2, r.height / 2);
		}
	}

	[StonescriptNativeMethod]
	public object ShowNPCDialog(List<object> parameters, InvocationContext ctx)
	{
		NpcDialog npcDialog = CreateNPCDialog_Internal(parameters, ctx);
		npcDialog.SetText(parameters.GetRange(1, 1), ctx);
		if (parameters.Count > 2)
		{
			npcDialog.OnComplete(parameters.GetRange(2, parameters.Count - 2), ctx);
		}
		npcDialog.Show(null, ctx);
		return npcDialog.ssDialog.Target;
	}

	private NpcDialog CreateNPCDialog_Internal(List<object> parameters, InvocationContext ctx)
	{
		StonescriptObject obj = (parameters[0] as StonescriptObject) ?? throw new StonescriptRuntimeException("Null target for ShowNPCDialog.");
		if (obj.Scriptable == null)
		{
			throw new StonescriptRuntimeException("Target for ShowNPCDialog must be a scriptable object.");
		}
		Character component = obj.Scriptable.GetComponent<Character>();
		if (component == null)
		{
			throw new StonescriptRuntimeException("Target for ShowNPCDialog must be a character.");
		}
		NpcDialog dialogInfo;
		if (npcDialogPool.Count > 0)
		{
			dialogInfo = npcDialogPool[0];
			npcDialogPool.RemoveAt(0);
		}
		else
		{
			dialogInfo = new NpcDialog();
			dialogInfo.dialogBubble = UnityEngine.Object.Instantiate(dialogBubblePrefab);
			dialogInfo.ssDialog = dialogInfo.dialogBubble.GetComponent<SSScriptableObject>();
			dialogInfo.ssDialog.Target.DeclareFunction(dialogInfo.OnComplete);
			dialogInfo.ssDialog.Target.DeclareFunction(dialogInfo.OnTextDisplayed);
			dialogInfo.ssDialog.Target.DeclareFunction(dialogInfo.OnUpdate);
			dialogInfo.ssDialog.Target.DeclareFunction(dialogInfo.SetText);
			dialogInfo.ssDialog.Target.DeclareFunction(dialogInfo.Show);
			dialogInfo.ssDialog.Target.DeclareGetter("align", dialogInfo.GetAlign);
			dialogInfo.ssDialog.Target.DeclareSetter("align", dialogInfo.SetAlign);
			dialogInfo.dialogBubble.OnTextDisplayed += dialogInfo.TryTextDisplayedCallback;
		}
		dialogInfo.dialogBubble.OnDone += dialogInfo.OnDialogDone;
		dialogInfo.npc = component;
		dialogInfo.offsetX = dialogInfo.npc.dialogOffsetX;
		dialogInfo.offsetY = dialogInfo.npc.dialogOffsetY;
		if (dialogInfo.npc.dialogPreferredWidth > 0)
		{
			dialogInfo.dialogBubble.preferredWidth = dialogInfo.npc.dialogPreferredWidth;
		}
		dialogInfo.onComplete = delegate
		{
			npcDialogsInUse.Remove(dialogInfo);
			dialogInfo.TryCompleteCallback();
			dialogInfo.Reset();
			npcDialogPool.Add(dialogInfo);
		};
		npcDialogsInUse.Add(dialogInfo);
		return dialogInfo;
	}

	[StonescriptNativeMethod]
	public object CreateNPCDialog(List<object> parameters, InvocationContext ctx)
	{
		return CreateNPCDialog_Internal(parameters, ctx).ssDialog.Target;
	}

	[StonescriptNativeMethod]
	public object ShowOptionDialog(List<object> parameters, InvocationContext ctx)
	{
		int num = 0;
		string text = parameters[num++] as string;
		string option = parameters[num++] as string;
		string option2 = ((parameters.Count > num && parameters[num] is string) ? (parameters[num++] as string) : null);
		if (parameters.Count > num)
		{
			if (!(parameters[num] is IFunction))
			{
				throw new ArgumentException($"Argument {num} expected a function but was something else.");
			}
			optionCallbackMethod = parameters[num++] as IFunction;
		}
		ShowOptionDialog(text, option, option2);
		return null;
	}

	public void ShowOptionDialog(string text, string option1, string option2)
	{
		if (optionDialog == null)
		{
			optionDialog = GameStates.Singleton.playChoiceDialog;
		}
		if (option2 != null)
		{
			optionDialog.SetupText(text, option1, option2, KeyCode.A, KeyCode.B);
			optionDialog.button1.OnPressed += HandleOption1Picked;
			optionDialog.button2.OnPressed += HandleOption2Picked;
		}
		else
		{
			optionDialog.SetupText(text, option1, KeyCode.A);
			optionDialog.buttonSingle.OnPressed += HandleOption1Picked;
		}
		optionPrevState = GameStates.Singleton.CurrentState;
		if (optionPrevState == GameStates.State.PlayPaused)
		{
			optionPrevState = GameStates.Singleton.previousState;
		}
		GameStates.Singleton.ShowPlayChoiceDialog();
	}

	[StonescriptNativeMethod]
	public object CloseOptionDialog(List<object> parameters, InvocationContext ctx)
	{
		if (optionPrevState != GameStates.State.None)
		{
			GameStates.Singleton.SetState(optionPrevState);
			optionPrevState = GameStates.State.None;
		}
		return null;
	}

	private void HandleOption1Picked(DialogButton btn)
	{
		optionDialog.button1.OnPressed -= HandleOption1Picked;
		optionDialog.button2.OnPressed -= HandleOption2Picked;
		optionDialog.buttonSingle.OnPressed -= HandleOption1Picked;
		GameStates.Singleton.SetState(optionPrevState);
		if (optionCallbackMethod != null)
		{
			IFunction function = optionCallbackMethod;
			optionCallbackMethod = null;
			List<object> list = new List<object>();
			if (function.ParameterNames.Count == 1)
			{
				list.Add(0);
			}
			function.Invoke(list);
		}
	}

	private void HandleOption2Picked(DialogButton btn)
	{
		optionDialog.button1.OnPressed -= HandleOption1Picked;
		optionDialog.button2.OnPressed -= HandleOption2Picked;
		optionDialog.buttonSingle.OnPressed -= HandleOption1Picked;
		GameStates.Singleton.SetState(optionPrevState);
		if (optionCallbackMethod != null)
		{
			IFunction function = optionCallbackMethod;
			optionCallbackMethod = null;
			List<object> list = new List<object>();
			if (function.ParameterNames.Count == 1)
			{
				list.Add(1);
			}
			function.Invoke(list);
		}
	}

	[StonescriptNativeMethod]
	public object ShowSightStoneDialog(List<object> parameters, InvocationContext ctx)
	{
		Character component = (parameters[0] as StonescriptObject).Scriptable.GetComponent<Character>();
		int num = 1;
		if (parameters.Count > num)
		{
			if (!(parameters[num] is IFunction))
			{
				throw new ArgumentException($"Argument {num} expected a function but received something else.");
			}
			sightStoneCallbackMethod = parameters[num++] as IFunction;
		}
		sightStoneDialogShowing = true;
		GameStates.Singleton.ShowSightstoneCharacter(component);
		return null;
	}

	private void OnSightStoneDialogComplete()
	{
		sightStoneDialogShowing = false;
		if (sightStoneCallbackMethod != null)
		{
			IFunction function = sightStoneCallbackMethod;
			sightStoneCallbackMethod = null;
			function?.Invoke();
		}
	}

	[StonescriptNativeMethod]
	public object ShowInventory(List<object> parameters, InvocationContext ctx)
	{
		GameStates.Singleton.SetState(GameStates.State.PlayItemScreen);
		return null;
	}

	[StonescriptNativeMethod]
	public object IsInventoryOpen(List<object> parameters, InvocationContext ctx)
	{
		return GameStates.Singleton.CurrentState == GameStates.State.ItemScreen || GameStates.Singleton.CurrentState == GameStates.State.PlayItemScreen;
	}

	[StonescriptNativeMethod]
	public object ShowStoryDialog(List<object> parameters, InvocationContext ctx)
	{
		IFunction endedCallback = ((parameters.Count > 1) ? (parameters[1] as IFunction) : null);
		if (parameters.Count > 1 && endedCallback == null)
		{
			throw new RuntimeException(ctx, "Invalid callback for ShowStoryDialog.");
		}
		IFunction indexChangedCallback = ((parameters.Count > 2) ? (parameters[2] as IFunction) : null);
		storyEndedCallback = delegate
		{
			if (endedCallback != null)
			{
				endedCallback.Invoke();
			}
		};
		storyIndexChangedCallback = delegate
		{
			if (indexChangedCallback != null)
			{
				indexChangedCallback.Invoke(new List<object> { storyIndex });
			}
		};
		if (parameters[0] is StonescriptArray)
		{
			foreach (string item in (parameters[0] as StonescriptArray).ToList<string>())
			{
				AddStoryPage(item);
			}
		}
		else
		{
			string story = parameters[0] as string;
			AddStoryPage(story);
		}
		StartStory();
		return null;
	}

	[StonescriptNativeMethod]
	public object ShowWorkshop(List<object> parameters, InvocationContext ctx)
	{
		GameStates.Singleton.SetState(GameStates.State.WorkstationScreen);
		return null;
	}

	[StonescriptNativeMethod]
	public object ShowQuestScreen(List<object> parameters, InvocationContext ctx)
	{
		GameStates.Singleton.SetState(GameStates.State.CustomQuests);
		return null;
	}

	[StonescriptNativeMethod]
	public object ShowFissureStone(List<object> parameters, InvocationContext ctx)
	{
		GameStates.Singleton.SetState(GameStates.State.WorkstationScreen);
		GameStates.Singleton.workstationScreen.ShowFissureScreen();
		return null;
	}

	[StonescriptNativeMethod]
	public object OpenTreasure(List<object> parameters, InvocationContext ctx)
	{
		TreasureItem component = (parameters[0] as StonescriptObject).Scriptable.GetComponent<TreasureItem>();
		treasureDialog.Setup(component);
		return treasureDialog;
	}
}
