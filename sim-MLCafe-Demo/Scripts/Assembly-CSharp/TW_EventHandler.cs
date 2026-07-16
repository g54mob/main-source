using System.Collections.Generic;
using Lexone.UnityTwitchChat;
using UnityEngine;

public class TW_EventHandler : MonoBehaviour
{
	private List<TwitchCustomer> customerList = new List<TwitchCustomer>();

	private void Start()
	{
		TW_GlobalCommands.OnCommandTrigger.AddListener(CheckTriggeredCommand);
		CustomerManager.OnCustomerSpawned.AddListener(SpawnTwitchCustomer);
		CustomerManager.OnCustomerDestroyed.AddListener(DestroyTwitchCustomer);
	}

	private bool IsAlreadySpawned(Chatter chatter)
	{
		return customerList.Exists((TwitchCustomer twCustomer) => twCustomer.chatter.login == chatter.login);
	}

	private void SpawnTwitchCustomer(CustomerCore customer)
	{
		Chatter randomJoinedChatter = TW_GlobalCommands.GetRandomJoinedChatter();
		if (randomJoinedChatter != null && !(customer == null) && !IsAlreadySpawned(randomJoinedChatter))
		{
			TwitchCustomer twitchCustomer = new TwitchCustomer();
			twitchCustomer.customer = customer;
			twitchCustomer.chatter = randomJoinedChatter;
			twitchCustomer.customer.SetNameTag(new EntityNameTag("", randomJoinedChatter.GetNameColor(), usePreLocalization: true, randomJoinedChatter.login));
			customerList.Add(twitchCustomer);
		}
	}

	private void DestroyTwitchCustomer(CustomerCore customer)
	{
		TwitchCustomer twitchCustomer = customerList.Find((TwitchCustomer x) => x.customer == customer);
		if (twitchCustomer != null)
		{
			customerList.Remove(twitchCustomer);
		}
	}

	private void CheckTriggeredCommand(TwitchCommand command, Chatter chatter)
	{
		if (IsAlreadySpawned(chatter))
		{
			TwitchCustomer item = customerList.Find((TwitchCustomer twCustomer) => twCustomer.chatter.login == chatter.login);
			base.gameObject.SendMessage(command.command, (item, command), SendMessageOptions.RequireReceiver);
		}
	}

	public void Speak((TwitchCustomer, TwitchCommand) data)
	{
		int count = data.Item2.command.Length + 1;
		string msg = data.Item1.chatter.message.Remove(0, count);
		data.Item1.customer.Speak(msg);
	}

	public void Upsi((TwitchCustomer, TwitchCommand) data)
	{
		data.Item1.customer.SpawnDirt();
	}
}
