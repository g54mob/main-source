using System;
using System.Collections.Generic;
using System.Linq;
using SINetworking;
using UnityEngine;
using UnityEngine.UI;

public class ServerWindow : MonoBehaviour
{
	public GUIWindow Window;

	public GUIListView ServerList;

	public GUIListView ItemList;

	public Image UnsupportButton;

	public Text UnsupportText;

	public Text ProcessLabel;

	public InputField InputName;

	public GameObject MultiplayerPanel;

	public GUICombobox CloudCombo;

	public Slider MarkupSlider;

	public Text MarkupText;

	public float CloudFactor = 10f;

	[NonSerialized]
	public bool ShouldUpdateServerList;

	[NonSerialized]
	public bool ShowUnsupported;

	[NonSerialized]
	public bool ShowAll;

	public void UpdateMarkupText()
	{
		MarkupText.text = (MarkupSlider.value / CloudFactor).ToPercent(false);
	}

	public void ApplyCloudChanges()
	{
		if (CloudCombo.Selected > 0)
		{
			ServerGroup cloud = GameSettings.Instance.GetCloud();
			ServerGroup selected = CloudCombo.GetSelected<ServerGroup>();
			if (cloud != null)
			{
				foreach (NetworkServerItem item in cloud.Items.OfType<NetworkServerItem>().ToList())
				{
					GameSettings.Instance.RegisterWithServer(selected.Name, item);
				}
				cloud.IsCloud = false;
			}
			selected.IsCloud = true;
			NetworkMessaging.SendUpdateCloudService(NetworkManager.LocalPlayerID, MarkupSlider.value / CloudFactor, selected.PowerSum * selected.Available, NetworkMessaging.MessageTarget.Everyone, 0);
		}
		else
		{
			if (GameSettings.Instance.MyCompany.CloudService == null)
			{
				return;
			}
			ServerGroup cloud2 = GameSettings.Instance.GetCloud();
			if (cloud2 != null)
			{
				foreach (NetworkServerItem item2 in cloud2.Items.OfType<NetworkServerItem>().ToList())
				{
					GameSettings.Instance.RegisterWithServer(null, item2);
				}
				cloud2.IsCloud = false;
			}
			NetworkMessaging.SendUpdateCloudService(NetworkManager.LocalPlayerID, -1f, -1f, NetworkMessaging.MessageTarget.Everyone, 0);
		}
	}

	public void SetName()
	{
		if (ServerList.Selected.Count > 0 && InputName.text.Length > 0 && !GameSettings.Instance.HasServerName(InputName.text) && !InputName.text.StartsWith("NETWORKPLAYERCLOUD"))
		{
			ServerGroup serverGroup = ServerList.GetSelected<ServerGroup>()[0];
			if (serverGroup.CloudProvider == 0)
			{
				GameSettings.Instance.ChangeServerName(serverGroup.Name, InputName.text);
				DoUpdateServerList();
			}
		}
	}

	public void ShowAllProcs()
	{
		if (ServerList.Selected.Count > 0)
		{
			ServerList.Selected.Clear();
		}
		ProcessLabel.text = "AllProcs".Loc() + ":";
		ShowAll = true;
		ShowUnsupported = false;
		ItemList.Items.Clear();
		HashSet<IServerItem> hashSet = GameSettings.Instance.UnsupportedServerItems.ToHashSet();
		hashSet.AddRange(GameSettings.Instance.GetAllServerGroups().SelectMany((ServerGroup x) => x.Items));
		ItemList.Items.AddRange(hashSet.Cast<object>());
		ItemList["SrvItemServer"].ToggleActive(false, true);
	}

	public void Unsupported()
	{
		if (ServerList.Selected.Count > 0)
		{
			ServerList.Selected.Clear();
		}
		ProcessLabel.text = "UnsupportedProcess".Loc() + ":";
		ShowAll = false;
		ShowUnsupported = true;
		ItemList.Items.Clear();
		ItemList.Items.AddRange(GameSettings.Instance.UnsupportedServerItems.Cast<object>());
	}

	public void CancelItems(params IServerItem[] items)
	{
		foreach (IServerItem item in items)
		{
			GameSettings.Instance.RegisterWithServer(null, item, false);
		}
		UpdateItems();
	}

	public void DelegateItems(params IServerItem[] items)
	{
		List<ServerGroup> servers = GameSettings.Instance.GetAllServerGroups().ToList();
		SDateTime time = SDateTime.Now();
		float needed = items.SumSafe((IServerItem x) => x.GetLoadRequirement()).BandwidthFactor(time);
		WindowManager.Instance.MultiWindow.Show("Server", servers.Select((ServerGroup x) => x.GetDisplayName() + " ( " + "NewServerLoad".Loc() + ": " + x.GetLoadAfter(needed, items) + " )"), delegate(int i)
		{
			if (i == -1)
			{
				CancelItems(items);
			}
			else
			{
				string value = servers[i].Name;
				if (!string.IsNullOrEmpty(value))
				{
					bool flag = false;
					bool flag2 = false;
					ServerGroup serverGroup = GameSettings.Instance.GetServerGroup(value);
					foreach (IServerItem item in items)
					{
						if (serverGroup.Items.Contains(item))
						{
							flag = true;
						}
						else
						{
							flag2 = true;
							GameSettings.Instance.RegisterWithServer(value, item, false);
						}
					}
					UpdateItems();
					if (flag && !flag2)
					{
						WindowManager.Instance.ShowMessageBox("ServerDelegateError".Loc(), true, DialogWindow.DialogType.Error);
					}
				}
			}
		}, true);
	}

	public void DelegateSelected()
	{
		if (ItemList.Selected.Count != 0)
		{
			DelegateItems(ItemList.GetSelected<IServerItem>());
		}
	}

	private void Start()
	{
		ServerList.OnSelectChange = delegate
		{
			ItemList["SrvItemServer"].ToggleActive(false, false);
			if (ServerList.Selected.Count > 0)
			{
				ShowUnsupported = false;
				ShowAll = false;
				ServerGroup serverGroup = ServerList.GetSelected<ServerGroup>()[0];
				ProcessLabel.text = "ProcessOnServer".Loc(serverGroup.Name) + ":";
				ItemList.Items.Clear();
				ItemList.Items.AddRange(serverGroup.Items.Cast<object>());
				InputName.text = serverGroup.GetDisplayName();
			}
			else if (ShowUnsupported)
			{
				Unsupported();
			}
			else if (ShowAll)
			{
				ShowAllProcs();
			}
			else
			{
				ProcessLabel.text = "Processes".Loc() + ":";
				InputName.text = "";
			}
		};
		DoUpdateServerList();
		UpdateServerWarning();
		MultiplayerPanel.SetActive(GameSettings.Instance.IsNetworkMode);
		ServerList["SrvCost"].ToggleActive(false, false);
		if (GameSettings.Instance.MyCompany.CloudService != null)
		{
			CloudCombo.SelectedItem = GameSettings.Instance.GetCloud();
			MarkupSlider.value = GameSettings.Instance.MyCompany.CloudService.Markup * CloudFactor;
		}
		UpdateMarkupText();
		ItemList["SrvItemServer"].ToggleActive(false, false);
		ProcessLabel.text = "Processes".Loc() + ":";
	}

	public void UpdateServerList()
	{
		ShouldUpdateServerList = true;
	}

	public void DoUpdateServerList()
	{
		ShouldUpdateServerList = false;
		ServerList.Items.Clear();
		ServerList.Items.AddRange(GameSettings.Instance.GetAllServerGroups().Cast<object>());
		ServerList.Selected.Clear();
		CloudCombo.UpdateContent(GameSettings.Instance.GetAllServerGroups(true, false));
		UpdateItems();
	}

	public void UpdateServerWarning()
	{
		UnsupportButton.color = ((GameSettings.Instance.UnsupportedServerItems.Count > 0) ? Color.red : Color.white);
		UnsupportText.text = "UnsupportedProc".Loc() + " (" + GameSettings.Instance.UnsupportedServerItems.Count + ")";
		if (HUD.Instance != null)
		{
			HUD.Instance.UpdateServerWarning();
		}
	}

	public void UpdateItems()
	{
		ItemList["SrvItemServer"].ToggleActive(false, false);
		if (ShowUnsupported)
		{
			Unsupported();
		}
		else if (ShowAll)
		{
			ShowAllProcs();
		}
		else if (ServerList.Selected.Count > 0)
		{
			ItemList.Items.Clear();
			ServerGroup serverGroup = ServerList.GetSelected<ServerGroup>()[0];
			ItemList.Items.AddRange(serverGroup.Items.Cast<object>());
			ProcessLabel.text = "ProcessOnServer".Loc(serverGroup.Name) + ":";
		}
		else
		{
			ProcessLabel.text = "Processes".Loc() + ":";
			ItemList.Selected.Clear();
			ItemList.Items.Clear();
		}
	}
}
