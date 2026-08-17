using System;
using System.Collections.Generic;
using Assets.Scripts.Audio.Music;
using Assets.Scripts.Game.Other;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class MusicSelectionUi : MonoBehaviour
{
	private static int index;

	public TextMeshProUGUI t_trackName;

	private List<MusicTrack> tracks;

	public MapSelectionUi mapSelection;

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<SelectionGroupToggleSingleButton, MapData> b = OnMapSelected;
		Delegate obj = Delegate.Combine(MapSelectionUi.A_MapSelected, b);
		if ((object)obj == null)
		{
			MapSelectionUi.A_MapSelected = (Action<SelectionGroupToggleSingleButton, MapData>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<SelectionGroupToggleSingleButton, MapData> action = default(Action<SelectionGroupToggleSingleButton, MapData>);
		if (action != null)
		{
			MapSelectionUi.A_MapSelected = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<SelectionGroupToggleSingleButton, MapData>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<SelectionGroupToggleSingleButton, MapData>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<SelectionGroupToggleSingleButton, MapData> value = OnMapSelected;
		Delegate obj = Delegate.Remove(MapSelectionUi.A_MapSelected, value);
		if ((object)obj == null)
		{
			MapSelectionUi.A_MapSelected = (Action<SelectionGroupToggleSingleButton, MapData>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<SelectionGroupToggleSingleButton, MapData> action = default(Action<SelectionGroupToggleSingleButton, MapData>);
		if (action != null)
		{
			MapSelectionUi.A_MapSelected = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<SelectionGroupToggleSingleButton, MapData>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<SelectionGroupToggleSingleButton, MapData>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void Start()
	{
		UpdateTrack(playTrack: false);
	}

	public void Flip(int dir)
	{
		//IL_008f: Expected O, but got I4
		//IL_0026: Expected O, but got I4
		object obj = index + dir;
		if ((nint)obj >= -1)
		{
			List<MusicTrack> list = MusicUtility.GetTracks();
			object obj2 = index + dir;
			if ((nint)obj2 < list._size)
			{
				int num = index + dir;
				index = num;
				UpdateTrack(playTrack: true);
			}
		}
	}

	private void UpdateTrack(bool playTrack)
	{
		string text;
		if (index < 0)
		{
			text = "Random";
		}
		else
		{
			List<MusicTrack> list = MusicUtility.GetTracks();
			MusicTrack musicTrack = list.get_Item(index);
			bool flag = musicTrack.trackName == null;
			text = "";
			if (!flag)
			{
				text = musicTrack.trackName;
			}
		}
		t_trackName.text = text;
		if (playTrack && index >= 0)
		{
			List<MusicTrack> list2 = MusicUtility.GetTracks();
			MusicTrack musicTrack2 = list2.get_Item(index);
			MusicController.Instance.PlayMusicTrack(musicTrack2);
		}
		else
		{
			MusicController.Instance.PlayMenuTrack();
		}
		MapSelectionUi mapSelectionUi = mapSelection;
		RunConfig runConfig = mapSelectionUi.runConfig;
		runConfig.musicTrackIndex = index;
	}

	private void OnMapSelected(SelectionGroupToggleSingleButton btn, MapData mapData)
	{
		UpdateTrack(playTrack: false);
	}

	private int NumSongs()
	{
		//IL_0043: Expected I4, but got O
		List<MusicTrack> list = MusicUtility.GetTracks();
		if (list != null)
		{
			return list._size;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	static MusicSelectionUi()
	{
		//IL_0013: Expected I4, but got I8
		index = -1;
	}
}
