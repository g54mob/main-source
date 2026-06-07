using System.IO;
using DV.Radio;
using PlaylistsNET.Content;
using PlaylistsNET.Models;
using UnityEngine;

public class BoomboxRadioPlaylistAutogenerate : MonoBehaviour
{
	private const string CONTENTS = "[playlist]\r\n\r\nFile1=https://simulatorradio.stream/320\r\nTitle1=Simulator Radio\r\n\r\nFile2=http://radio.truckers.fm\r\nTitle2=TruckersFM\r\n\r\nNumberOfEntries=2\r\nVersion=2\r\n";

	private const string KEY = "RadioPlaylistPatch";

	private const int CURRENT_VERSION = 3;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void GeneratePlaylistFile()
	{
		string playlistPath = RadioPlayerController.GetPlaylistPath();
		if (File.Exists(playlistPath))
		{
			Patch(playlistPath);
		}
		else
		{
			Debug.Log("Auto-generating radio playlist file '" + playlistPath + "'");
			File.WriteAllText(playlistPath, "[playlist]\r\n\r\nFile1=https://simulatorradio.stream/320\r\nTitle1=Simulator Radio\r\n\r\nFile2=http://radio.truckers.fm\r\nTitle2=TruckersFM\r\n\r\nNumberOfEntries=2\r\nVersion=2\r\n");
			PlayerPrefs.SetInt("RadioPlaylistPatch", 3);
		}
		PlayerPrefs.GetInt("RadioPlaylistPatch");
	}

	private static void Patch(string path)
	{
		int num;
		if (!PlayerPrefs.HasKey("RadioPlaylistPatch"))
		{
			num = 1;
		}
		else
		{
			num = PlayerPrefs.GetInt("RadioPlaylistPatch");
			if (num < 1)
			{
				Debug.LogWarning(string.Format("Unexpected '{0}' low value '{1}' from PlayerPrefs, overriding to 1", "RadioPlaylistPatch", num));
				num = 1;
			}
			else if (num > 3)
			{
				Debug.LogWarning(string.Format("Unexpected '{0}' high value '{1}' from PlayerPrefs, overriding to {2}", "RadioPlaylistPatch", num, 3));
				num = 3;
			}
		}
		if (num == 1)
		{
			string text = File.ReadAllText(path);
			string text2 = text.Replace("simulatorradio.stream/stream", "simulatorradio.stream/320");
			if (text2 != text)
			{
				Debug.Log("Patching radio playlist file for Simulator Radio URL change");
				File.WriteAllText(path, text2);
			}
			num = 2;
			PlayerPrefs.SetInt("RadioPlaylistPatch", num);
		}
		if (num == 2)
		{
			if (TryGetPlaylist(path, out var playlist))
			{
				if (playlist.PlaylistEntries.Exists((PlsPlaylistEntry entry) => !string.IsNullOrWhiteSpace(entry.Path) && entry.Path.Contains("radio.truckers.fm")))
				{
					Debug.Log("Radio playlist file already contains TruckersFM entry, doing nothing");
				}
				else
				{
					playlist.PlaylistEntries.Add(new PlsPlaylistEntry
					{
						Title = "TruckersFM",
						Path = "http://radio.truckers.fm"
					});
					string contents = new PlsContent().ToText(playlist);
					Debug.Log("Patching radio playlist file for TruckersFM addition");
					File.WriteAllText(path, contents);
				}
			}
			else
			{
				Debug.LogError("Couldn't read playlist file '" + path + "' when attempting upgrade to version 3");
			}
			num = 3;
			PlayerPrefs.SetInt("RadioPlaylistPatch", num);
		}
		PlayerPrefs.GetInt("RadioPlaylistPatch");
	}

	private static bool TryGetPlaylist(string path, out PlsPlaylist playlist)
	{
		if (!PlaylistPlayer.TryGetPlaylist(path, out var playlist2))
		{
			Debug.LogError("Couldn't read playlist file");
			playlist = null;
			return false;
		}
		if (!(playlist2 is PlsPlaylist plsPlaylist))
		{
			Debug.LogError("Couldn't cast non-null IBasePlaylist to PlsPlaylist");
			playlist = null;
			return false;
		}
		playlist = plsPlaylist;
		return true;
	}
}
