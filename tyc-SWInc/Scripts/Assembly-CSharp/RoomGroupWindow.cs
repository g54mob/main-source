using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomGroupWindow : MonoBehaviour
{
	public GUIWindow Window;

	public GUIListView GroupList;

	public void Toggle()
	{
		Window.Toggle();
	}

	public void Show(List<Room> rooms)
	{
		WindowManager.SpawnInputDialog("NewRoomGroupPrompt".Loc(), "", "Newroomgroup".Loc(), delegate(string s)
		{
			if (GameSettings.Instance.GetRoomGroups(true).Any((string x) => x.Equals(s)))
			{
				WindowManager.Instance.ShowMessageBox("RoomGroupNameError".Loc(), true, DialogWindow.DialogType.Error);
			}
			else
			{
				RoomGroup roomGroup = GameSettings.Instance.AddRoomGroup(s);
				foreach (Room room in rooms)
				{
					GameSettings.Instance.RemoveRoomFromGroups(room);
					roomGroup.AddRoom(room);
				}
				Window.Show();
			}
		});
	}

	public void UpdateList()
	{
		GroupList.Items = GameSettings.Instance.GetUnderlyingRoomGroups(false).Cast<object>().ToList();
	}

	public void ToggleRoomGroupOverlay()
	{
		DataOverlay.Instance.ActivateFunc(DataOverlay.HasActive ? null : "Room grouping");
	}

	public void AssignSelectedRooms()
	{
		RoomGroup[] selected = GroupList.GetSelected<RoomGroup>();
		List<Room> list = SelectorController.Instance.Selected.OfType<Room>().ToList();
		if (selected.Length == 0 || list.Count <= 0)
		{
			return;
		}
		foreach (Room item in list)
		{
			GameSettings.Instance.RemoveRoomFromGroups(item);
			selected[0].AddRoom(item);
		}
	}

	public void AddNewRoom()
	{
		WindowManager.SpawnInputDialog("NewRoomGroupPrompt".Loc(), "", "Newroomgroup".Loc(), delegate(string s)
		{
			if (GameSettings.Instance.GetRoomGroups(true).Any((string x) => x.Equals(s)))
			{
				WindowManager.Instance.ShowMessageBox("RoomGroupNameError".Loc(), true, DialogWindow.DialogType.Error);
			}
			else
			{
				GameSettings.Instance.AddRoomGroup(s);
			}
		});
	}

	public void SelectRooms()
	{
		RoomGroup[] selected = GroupList.GetSelected<RoomGroup>();
		if (selected.Length != 0)
		{
			SelectorController.Instance.SetSelection(selected.SelectMany((RoomGroup x) => x.GetRooms()));
		}
	}

	public void RoomGroupStyling(bool outdoor)
	{
		RoomGroup[] sel = GroupList.GetSelected<RoomGroup>();
		if (sel.Length == 0)
		{
			return;
		}
		List<RoomStyle> styles = GameSettings.Instance.RoomStyles.Where((RoomStyle x) => !x.RoofStyle && !x.PathStyle && x.OutdoorStyle == outdoor).ToList();
		WindowManager.Instance.MultiWindow.Show("Room style", styles.Select((RoomStyle x) => x.StyleName), delegate(int x)
		{
			RoomStyle style = ((x < 0) ? null : styles[x]);
			if (outdoor)
			{
				sel.ForEachEnum(delegate(RoomGroup z)
				{
					z.Outdoor = style;
				});
			}
			else
			{
				sel.ForEachEnum(delegate(RoomGroup z)
				{
					z.Indoor = style;
				});
			}
			if (style != null)
			{
				foreach (Room item in sel.SelectMany((RoomGroup z) => z.GetRooms()))
				{
					style.Apply(item, null);
				}
			}
		}, true);
	}

	public void MergeGroups()
	{
		RoomGroup[] selected = GroupList.GetSelected<RoomGroup>();
		if (selected.Length <= 1)
		{
			return;
		}
		for (int i = 1; i < selected.Length; i++)
		{
			List<Room> list = selected[i].GetRooms().ToList();
			for (int j = 0; j < list.Count; j++)
			{
				Room room = list[j];
				selected[i].RemoveRoom(room);
				selected[0].AddRoom(room);
			}
			foreach (Actor item in GameSettings.Instance.sActorManager.Staff)
			{
				if (item.AssignedRoomGroups.Remove(selected[i].Name))
				{
					item.AssignedRoomGroups.Add(selected[0].Name);
				}
			}
			GameSettings.Instance.RemoveRoomGroup(selected[i].Name);
		}
	}
}
