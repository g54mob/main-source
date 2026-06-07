using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TwitchIntegration : MonoBehaviour
{
	[Serializable]
	public struct Chatter
	{
		public string chatterName;

		public bool isChatterSubbed;

		public ChatterAI chatterBot;

		public Chatter(string n, bool sub, ChatterAI bot)
		{
			chatterName = n;
			isChatterSubbed = sub;
			chatterBot = bot;
		}
	}

	public List<Chatter> chatters;

	public bool transferredStreamerBonusMoney;

	[Space]
	[Header("Settings")]
	[SerializeField]
	private TMP_InputField bootTimeInputField;

	private int minimumBootTimer = 5;

	[SerializeField]
	private TMP_InputField maximumChattersInputField;

	private int internalMinimum = 20;

	private int internalMaximum = 300;

	[SerializeField]
	private Toggle subOnlyToggle;

	[SerializeField]
	private Toggle showAvailableSlotsToggle;

	[SerializeField]
	private GameObject availableSlots;

	[SerializeField]
	private TMP_Text availableSlotsText;

	[SerializeField]
	private Toggle showCommandsToggle;

	[SerializeField]
	private GameObject onscreenCommands;

	[Space]
	[Header("References")]
	public Texture2D chatterTexture;

	public Texture2D subbedChatterTexture;

	[Space]
	public ChatterAI chatterBotPrefab;

	public ChatterAI subbedChatterBotPrefab;

	private void Start()
	{
		byte[] data = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, "chatterSheet.png"));
		chatterTexture.LoadImage(data);
		byte[] data2 = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, "subbedChatterSheet.png"));
		subbedChatterTexture.LoadImage(data2);
	}

	public void AddStreamerBonusMoney()
	{
		if (!transferredStreamerBonusMoney)
		{
			transferredStreamerBonusMoney = true;
			Inventory.ins.AddSpareParts(1000);
		}
	}

	public void SetBootTimerTo(string input)
	{
		if (int.TryParse(input, out var result))
		{
			if (result < minimumBootTimer)
			{
				result = minimumBootTimer;
			}
			if (result > 999)
			{
				result = 999;
			}
			SaveData.ins.inactivityTimer = result;
			SetBootTimerInputTextTo(result);
		}
	}

	private void SetBootTimerInputTextTo(int value)
	{
		bootTimeInputField.SetTextWithoutNotify(value.ToString());
	}

	public void SetChatterLimitTo(string input)
	{
		if (int.TryParse(input, out var result))
		{
			if (result < internalMinimum)
			{
				result = internalMinimum;
			}
			if (result > internalMaximum)
			{
				result = internalMaximum;
			}
			SaveData.ins.availableSlots = result;
			UpdateAvailableSlotsText();
			SetChatterLimitInputTextTo(result);
		}
	}

	private void SetChatterLimitInputTextTo(int value)
	{
		maximumChattersInputField.SetTextWithoutNotify(value.ToString());
	}

	public void ToggleSubsOnly(bool value)
	{
		SaveData.ins.subsOnly = value;
	}

	private void SetSubsOnlyToggleTo(bool value)
	{
		subOnlyToggle.SetIsOnWithoutNotify(value);
	}

	public void ToggleSlots(bool value)
	{
		availableSlots.SetActive(value);
	}

	public void ToggleCommands(bool value)
	{
		onscreenCommands.SetActive(value);
	}

	public void LoadSettings()
	{
		SetBootTimerInputTextTo(SaveData.ins.inactivityTimer);
		SetChatterLimitInputTextTo(SaveData.ins.availableSlots);
		SetSubsOnlyToggleTo(SaveData.ins.subsOnly);
		UpdateAvailableSlotsText();
	}

	public void Command(string chatterName, string message, bool chatterSub)
	{
		KeepChatterConnected(chatterName);
		if (message.Contains("!"))
		{
			if (message.Contains("!join"))
			{
				SpawnChatterBot(chatterName, chatterSub);
				return;
			}
			if (message.Contains("!leave"))
			{
				DespawnChatterBot(chatterName);
				return;
			}
			ChangeChatterBotAction(chatterName, message);
			ChangeBotColor(chatterName, message, chatterSub);
		}
	}

	public void Emote(string cName, Texture2D img)
	{
		if (isChatterAlreadyInList(cName, out var index))
		{
			chatters[index].chatterBot.PlayEmoteParticles(img);
		}
	}

	private void KeepChatterConnected(string cName)
	{
		if (isChatterAlreadyInList(cName, out var index))
		{
			chatters[index].chatterBot.ResetTimer();
		}
	}

	private void SpawnChatterBot(string chatterName, bool chatterSub)
	{
		if ((!SaveData.ins.subsOnly || chatterSub) && chatters.Count < SaveData.ins.availableSlots && !isChatterAlreadyInList(chatterName))
		{
			ChatterAI chatterAI = UnityEngine.Object.Instantiate(chatterBotPrefab);
			chatterAI.LinkTo(this);
			chatterAI.UpdateNameTagTo(chatterName, chatterSub);
			Chatter item = new Chatter(chatterName, chatterSub, chatterAI);
			chatters.Add(item);
			UpdateAvailableSlotsText();
		}
	}

	public void DespawnChatterBot(string chatterName)
	{
		for (int i = 0; i < chatters.Count; i++)
		{
			if (chatters[i].chatterName == chatterName)
			{
				UnityEngine.Object.Destroy(chatters[i].chatterBot.gameObject);
				chatters.RemoveAt(i);
				UpdateAvailableSlotsText();
				break;
			}
		}
	}

	public void DespawnAllChatters()
	{
		for (int i = 0; i < chatters.Count; i++)
		{
			UnityEngine.Object.Destroy(chatters[i].chatterBot.gameObject);
		}
		chatters.Clear();
		UpdateAvailableSlotsText();
	}

	private void UpdateAvailableSlotsText()
	{
		availableSlotsText.text = chatters.Count + "/" + SaveData.ins.availableSlots;
	}

	private bool isChatterAlreadyInList(string cName)
	{
		for (int i = 0; i < chatters.Count; i++)
		{
			if (chatters[i].chatterName == cName)
			{
				return true;
			}
		}
		return false;
	}

	private bool isChatterAlreadyInList(string cName, out int index)
	{
		for (int i = 0; i < chatters.Count; i++)
		{
			if (chatters[i].chatterName == cName)
			{
				index = i;
				return true;
			}
		}
		index = -1;
		return false;
	}

	private void ChangeChatterBotAction(string cName, string cmd)
	{
		if (isChatterAlreadyInList(cName, out var index))
		{
			bool flag = false;
			ChatterAI.ChatterAction currentAction = ChatterAI.ChatterAction.Water;
			if (cmd.Contains("!water"))
			{
				currentAction = ChatterAI.ChatterAction.Water;
				flag = true;
			}
			if (cmd.Contains("!harvest"))
			{
				currentAction = ChatterAI.ChatterAction.Harvest;
				flag = true;
			}
			if (cmd.Contains("!biofuel"))
			{
				currentAction = ChatterAI.ChatterAction.Stock;
				flag = true;
			}
			if (cmd.Contains("!build"))
			{
				currentAction = ChatterAI.ChatterAction.Build;
				flag = true;
			}
			if (cmd.Contains("!feed"))
			{
				currentAction = ChatterAI.ChatterAction.Feed;
				flag = true;
			}
			if (cmd.Contains("!collect") || cmd.Contains("!poop"))
			{
				currentAction = ChatterAI.ChatterAction.Collect;
				flag = true;
			}
			if (cmd.Contains("!fertilize"))
			{
				currentAction = ChatterAI.ChatterAction.Fertilize;
				flag = true;
			}
			if (cmd.Contains("!pick"))
			{
				currentAction = ChatterAI.ChatterAction.PickBerries;
				flag = true;
			}
			if (cmd.Contains("!plant"))
			{
				currentAction = ChatterAI.ChatterAction.Plant;
				flag = true;
			}
			if (flag)
			{
				chatters[index].chatterBot.currentAction = currentAction;
			}
			if (cmd.Contains("!bench") || cmd.Contains("!sit"))
			{
				chatters[index].chatterBot.NeedsRest();
			}
		}
	}

	private void ChangeBotColor(string cName, string cmd, bool subStatus)
	{
		if (isChatterAlreadyInList(cName, out var index))
		{
			if (cmd.Contains("!purple"))
			{
				chatters[index].chatterBot.ChangeColorToPurple();
			}
			if (cmd.Contains("!pink"))
			{
				chatters[index].chatterBot.ChangeColorToPink();
			}
			if (cmd.Contains("!blue"))
			{
				chatters[index].chatterBot.ChangeColorToBlue();
			}
			if (cmd.Contains("!green"))
			{
				chatters[index].chatterBot.ChangeColorToGreen();
			}
			if (cmd.Contains("!orange"))
			{
				chatters[index].chatterBot.ChangeColorToOrange();
			}
			if (cmd.Contains("!red"))
			{
				chatters[index].chatterBot.ChangeColorToRed();
			}
			if (cmd.Contains("!gray"))
			{
				chatters[index].chatterBot.ChangeColorToGray();
			}
			if (subStatus && cmd.Contains("!gold"))
			{
				chatters[index].chatterBot.ChangeColorToGold();
			}
		}
	}
}
