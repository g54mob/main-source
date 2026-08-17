using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Cpp2ILInjected;
using UnityEngine;

public class ServerFeed : MonoBehaviour
{
	public GameObject serverFeedPrefab;

	public Transform content;

	private int numMaxPrefabs = 13;

	private readonly List<ServerFeedPrefab> activePrefabs;

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<EItem> b = OnItemAdded;
		Delegate obj = Delegate.Combine(ItemInventory.A_ItemAdded, b);
		if ((object)obj == null)
		{
			ItemInventory.A_ItemAdded = (Action<EItem>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EItem> action = default(Action<EItem>);
		if (action != null)
		{
			ItemInventory.A_ItemAdded = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<EItem>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<EItem>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<EItem> value = OnItemAdded;
		Delegate obj = Delegate.Remove(ItemInventory.A_ItemAdded, value);
		if ((object)obj == null)
		{
			ItemInventory.A_ItemAdded = (Action<EItem>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EItem> action = default(Action<EItem>);
		if (action != null)
		{
			ItemInventory.A_ItemAdded = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<EItem>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<EItem>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public void SetFeed(string text, float duration, Texture icon = null)
	{
		List<ServerFeedPrefab> list = activePrefabs;
		Action<ServerFeedPrefab> timeoutAction;
		ServerFeedPrefab serverFeedPrefab2;
		if (list._size >= numMaxPrefabs)
		{
			ServerFeedPrefab serverFeedPrefab = list.get_Item(0);
			((List<object>)(object)activePrefabs).RemoveAt(0);
			activePrefabs.Add(serverFeedPrefab);
			Transform transform = serverFeedPrefab.transform;
			transform.SetAsLastSibling();
			serverFeedPrefab.StopAllCoroutines();
			Action<ServerFeedPrefab> action = TimeoutPrefab;
			timeoutAction = action;
			serverFeedPrefab2 = serverFeedPrefab;
		}
		else
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(this.serverFeedPrefab, content);
			ServerFeedPrefab component = gameObject.GetComponent<ServerFeedPrefab>();
			activePrefabs.Add(component);
			Action<ServerFeedPrefab> action2 = TimeoutPrefab;
			timeoutAction = action2;
			serverFeedPrefab2 = component;
		}
		serverFeedPrefab2.timeoutAction = timeoutAction;
		GameObject gameObject2 = serverFeedPrefab2.t_info.gameObject;
		gameObject2.SetActive(value: true);
		serverFeedPrefab2.t_info.text = text;
		if (icon != null)
		{
			serverFeedPrefab2.i_icon.enabled = true;
			serverFeedPrefab2.i_icon.texture = icon;
		}
		else
		{
			serverFeedPrefab2.i_icon.enabled = false;
		}
		serverFeedPrefab2.startFadeTime = duration;
		serverFeedPrefab2.currentTime = 0f;
		ServerFeedPrefab._003CShow_003Ed__9 obj = new ServerFeedPrefab._003CShow_003Ed__9(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = serverFeedPrefab2;
		Coroutine coroutine = serverFeedPrefab2.StartCoroutine(obj);
	}

	private void TimeoutPrefab(ServerFeedPrefab prefab)
	{
	}

	private void OnItemAdded(EItem eItem)
	{
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFGameSettings cfGameSettings = config.cfGameSettings;
		if (cfGameSettings.show_item_feed != 0)
		{
			ItemData item = DataManager.Instance.GetItem(eItem);
			string text = item.GetName();
			string text2 = "+1 " + text;
			Texture icon = item.GetIcon();
			SetFeed(text2, 5f, icon);
		}
	}

	public ServerFeed()
	{
		List<ServerFeedPrefab> list = new List<ServerFeedPrefab>();
		activePrefabs = list;
		base._002Ector();
	}
}
