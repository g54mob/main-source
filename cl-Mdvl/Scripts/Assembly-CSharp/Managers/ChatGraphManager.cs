using System;
using System.Collections.Generic;
using System.IO;
using ChatGraphSystem;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Dialogs;
using NSMedieval.Dialogs.Data;
using NSMedieval.GameEventSystem;
using NSMedieval.State;
using NSMedieval.Tools;
using UnityEngine;

namespace Managers
{
	public class ChatGraphManager : MonoSingleton<ChatGraphManager>
	{
		public delegate void DialogContentFormattingHandler(string chatGraphId, string dialogName, DialogContent dialogContent, CreatureBase chatInitiator, CreatureBase chatTarget);

		public delegate void ChatOptionChosenHandler(string chatGraphId, string dialogName, int optionIndex, CreatureBase chatInitiator, CreatureBase chatTarget);

		private ChatGraphInstance currentChatGraphInstance;

		private CreatureBase chatInitiator;

		private CreatureBase chatTarget;

		public event DialogContentFormattingHandler BeforeShowDialogEvent;

		public event ChatOptionChosenHandler ChatOptionChosenEvent;

		public void StartNew(string chatGraphId, CreatureBase chatInitiator, CreatureBase chatTarget)
		{
			if (currentChatGraphInstance != null)
			{
				throw new Exception("Can't start chat graph '" + chatGraphId + "' because another one is still in progress (id='" + currentChatGraphInstance.Id + "')");
			}
			string text = Path.Combine(Application.dataPath, "StreamingAssets", "ChatGraphs", chatGraphId + ".json");
			if (!File.Exists(text))
			{
				throw new Exception("Can't start chat graph '" + chatGraphId + "' because it does not exist (tried looking at path '" + FilePathUtils.RemoveUserFromPath(text) + "')");
			}
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(43, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\ChatGraphManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Starting chat graph ");
				messageBuilder.AppendFormatted(chatGraphId);
				messageBuilder.AppendLiteral(", initiator: ");
				messageBuilder.AppendFormatted(chatInitiator);
				messageBuilder.AppendLiteral(", target: ");
				messageBuilder.AppendFormatted(chatTarget);
			}
			Log.Info(messageBuilder);
			currentChatGraphInstance = ChatGraphLoader.Load(text, chatGraphId);
			this.chatInitiator = chatInitiator;
			this.chatTarget = chatTarget;
			UpdateView();
		}

		private void UpdateView()
		{
			if (currentChatGraphInstance.HasEnded)
			{
				Log.Info("Current chat graph already ended, closing silently", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\ChatGraphManager.cs");
				MonoSingleton<DialogViewManager>.Instance.CloseSilent();
				currentChatGraphInstance = null;
				chatInitiator = null;
				chatTarget = null;
				return;
			}
			DialogNode currentNode = currentChatGraphInstance.CurrentNode;
			DialogContent dialogContent = new DialogContent();
			dialogContent.WindowTitle = currentNode.WindowTitle;
			dialogContent.ContentTitle = currentNode.ContentTitle;
			dialogContent.ContentBodyText = currentNode.ContentText;
			dialogContent.ContentBodyImagePath = currentNode.ContentImageName;
			dialogContent.Options = new List<DialogOption>();
			for (int i = 0; i < currentChatGraphInstance.Choices.Count; i++)
			{
				ChoiceNode choiceNode = currentChatGraphInstance.Choices[i];
				DialogOption dialogOption = new DialogOption();
				dialogOption.Tooltips = BuildTooltips(choiceNode);
				dialogOption.Text = choiceNode.Text;
				int indexClosureCopy = i;
				dialogOption.OnSelected = delegate
				{
					if (currentChatGraphInstance != null && !currentChatGraphInstance.HasEnded)
					{
						currentChatGraphInstance.MakeChoice(choiceNode);
						string text = currentNode.Name;
						string id = currentChatGraphInstance.Id;
						CreatureBase creatureBase = chatInitiator;
						CreatureBase creatureBase2 = chatTarget;
						bool isEnabled;
						FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(26, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\ChatGraphManager.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Dialog '");
							messageBuilder.AppendFormatted(text);
							messageBuilder.AppendLiteral("', option chosen: ");
							messageBuilder.AppendFormatted(indexClosureCopy);
						}
						Log.Info(messageBuilder);
						this.ChatOptionChosenEvent?.Invoke(id, text, indexClosureCopy, creatureBase, creatureBase2);
						UpdateView();
					}
				};
				dialogContent.Options.Add(dialogOption);
			}
			this.BeforeShowDialogEvent?.Invoke(currentChatGraphInstance.Id, currentNode.Name, dialogContent, chatInitiator, chatTarget);
			dialogContent.Options.Reverse();
			MonoSingleton<DialogViewManager>.Instance.OpenDialog(dialogContent, appendCloseToButtons: false);
		}

		private static List<TooltipData> BuildTooltips(ChoiceNode choiceNode)
		{
			List<TooltipData> list = new List<TooltipData>();
			choiceNode.TryParseOptionEffects(out var result);
			foreach (GameEventOptionEffect item in result)
			{
				if (item != GameEventOptionEffect.None)
				{
					TooltipData tooltipData = new TooltipData();
					tooltipData.Key = item.ToString();
					tooltipData.Args = new List<string>();
					list.Add(tooltipData);
				}
			}
			return list;
		}
	}
}
