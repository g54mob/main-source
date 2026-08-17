using System;
using System.Collections.Generic;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts.Game.Other;
using Assets.Scripts.Managers;
using Assets.Scripts.Saves___Serialization.Progression;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Audio.Music;

public class MusicUtility
{
	private static List<MusicTrack> tracks;

	private static List<MusicTrack> tracksOther;

	private static Dictionary<EMap, int> mapTrackRotation;

	private static MusicTrack themeTrackPlayedLastRound;

	public static MusicTrack GetMusicTrackToPlay(RunConfig runConfig)
	{
		//IL_030e: Expected O, but got I4
		//IL_038d: Expected O, but got I4
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Expected O, but got Unknown
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Expected I4, but got Unknown
		//IL_03ff: Expected O, but got I4
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_040e: Expected I4, but got Unknown
		if (MapController.isFinalBossStage)
		{
			MapData mapData = runConfig.mapData;
			if (mapData.bossTrack != null)
			{
				MapData mapData2 = runConfig.mapData;
				return mapData2.bossTrack;
			}
		}
		int index;
		List<MusicTrack> list2;
		if (runConfig.musicTrackIndex != -1)
		{
			List<MusicTrack> list = GetTracks();
			index = runConfig.musicTrackIndex;
			list2 = list;
			goto IL_04e9;
		}
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		CharacterProgression characterProgression = saveManager.progression.GetCharacterProgression(CharacterMenu.selectedCharacter);
		CharacterData characterData = DataManager.Instance.GetCharacterData(CharacterMenu.selectedCharacter);
		if (characterData.themeSong != null)
		{
			float num = UnityEngine.Random.Range(0f, 1f);
			if (0.15f > num || characterProgression.numRuns <= 0)
			{
				CharacterData characterData2 = DataManager.Instance.GetCharacterData(CharacterMenu.selectedCharacter);
				themeTrackPlayedLastRound = characterData2.themeSong;
				return themeTrackPlayedLastRound;
			}
		}
		themeTrackPlayedLastRound = null;
		float num2 = UnityEngine.Random.Range(0f, 1f);
		if (0.15f > num2)
		{
			List<MusicTrack> list3 = GetTracksOther();
			if (list3 != null && list3._size > 0)
			{
				int num3 = UnityEngine.Random.Range(0, list3._size);
				index = num3;
				list2 = list3;
				goto IL_04e9;
			}
		}
		MapData mapData3 = runConfig.mapData;
		if (!mapTrackRotation.ContainsKey(mapData3.eMap))
		{
			MapData mapData4 = runConfig.mapData;
			MusicTrack[] musicTracks = mapData4.musicTracks;
			int value = UnityEngine.Random.Range(0, musicTracks.Length);
			((Dictionary<System.Int32Enum, int>)(object)mapTrackRotation).Add((System.Int32Enum)mapData4.eMap, value);
		}
		MapData mapData5 = runConfig.mapData;
		int num4 = mapTrackRotation.get_Item(mapData5.eMap);
		MapData mapData6 = runConfig.mapData;
		object obj = 0;
		int num5 = num4;
		while (true)
		{
			MusicTrack[] musicTracks2 = mapData6.musicTracks;
			if (num5 >= musicTracks2.Length)
			{
				break;
			}
			MusicTrack musicTrack = musicTracks2[num5];
			bool flag = MapController.index <= musicTrack.maxStageCompatibility;
			int num6 = num5;
			if (!flag)
			{
				object obj2 = num5 + 1;
				obj++;
				int num7 = obj2 % musicTracks2.Length;
				bool flag2 = (nint)obj <= 100;
				num6 = num7;
				num5 = num7;
				if (flag2)
				{
					continue;
				}
			}
			MapData mapData7 = runConfig.mapData;
			MusicTrack[] musicTracks3 = mapData7.musicTracks;
			object obj3 = num6 + 1;
			int value2 = obj3 % musicTracks3.Length;
			((Dictionary<System.Int32Enum, int>)(object)mapTrackRotation).set_Item((System.Int32Enum)mapData7.eMap, value2);
			MapData mapData8 = runConfig.mapData;
			MusicTrack[] musicTracks4 = mapData8.musicTracks;
			if (num6 >= musicTracks4.Length)
			{
				break;
			}
			return musicTracks4[num6];
		}
		return (MusicTrack)(object)new IndexOutOfRangeException();
		IL_04e9:
		return list2.get_Item(index);
	}

	public unsafe static List<MusicTrack> GetTracks()
	{
		//IL_0062: Expected O, but got Ref
		if (tracks == null)
		{
			List<MusicTrack> list = new List<MusicTrack>();
			tracks = list;
			DataManager instance = DataManager.Instance;
			if ((object)DataManager.Instance != null && instance.unsortedMusic != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
				List<object>.Enumerator enumerator = default(List<object>.Enumerator);
				MusicTrack musicTrack = default(MusicTrack);
				while (enumerator.MoveNext())
				{
					bool flag = (object)musicTrack == null;
					List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(&enumerator);
					if (!flag)
					{
						if (musicTrack.isEnabled && musicTrack.isInJukebox)
						{
							tracks.Add(musicTrack);
						}
						continue;
					}
					throw new NullReferenceException();
				}
				((List<MusicTrack>.Enumerator*)(&enumerator))->Dispose();
				if (tracks != null)
				{
					((List<object>)(object)tracks).Sort();
					return tracks;
				}
			}
			return (List<MusicTrack>)(object)new NullReferenceException();
		}
		return tracks;
	}

	public unsafe static List<MusicTrack> GetTracksOther()
	{
		//IL_0062: Expected O, but got Ref
		if (tracksOther == null)
		{
			List<MusicTrack> list = new List<MusicTrack>();
			tracksOther = list;
			DataManager instance = DataManager.Instance;
			if ((object)DataManager.Instance != null && instance.unsortedMusic != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
				List<object>.Enumerator enumerator = default(List<object>.Enumerator);
				MusicTrack musicTrack = default(MusicTrack);
				while (enumerator.MoveNext())
				{
					bool flag = (object)musicTrack == null;
					List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(&enumerator);
					if (!flag)
					{
						if (musicTrack.isEnabled && musicTrack.isInJukebox && musicTrack.isInRandomPool && musicTrack.category == MusicCategory.Other)
						{
							tracksOther.Add(musicTrack);
						}
						continue;
					}
					throw new NullReferenceException();
				}
				((List<MusicTrack>.Enumerator*)(&enumerator))->Dispose();
				if (tracksOther != null)
				{
					((List<object>)(object)tracksOther).Sort();
					return tracksOther;
				}
			}
			return (List<MusicTrack>)(object)new NullReferenceException();
		}
		return tracksOther;
	}

	static MusicUtility()
	{
		Dictionary<EMap, int> dictionary = new Dictionary<EMap, int>();
		mapTrackRotation = dictionary;
		themeTrackPlayedLastRound = null;
	}
}
