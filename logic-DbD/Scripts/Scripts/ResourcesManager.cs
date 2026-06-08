using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourcesManager
{
	public const string TEXT_FILE_PATH = "Text/";

	public const string TRANSCRIPT_FILE_PATH = "Text/Transcripts/";

	public const string IMAGES_FILE_PATH = "Images/";

	public const string AUDIO_FILE_PATH = "Audio/";

	public const string MUSIC_FILE_PATH = "Music/";

	public const string WEBSITES_FILE_PATH = "Websites/";

	public static string[] ParseTextFile(string filepath)
	{
		return (from line in Resources.Load<TextAsset>("Text/" + filepath).text.Split('\n')
			select line.Trim()).ToArray();
	}

	public static string GetTranscript(string filepath)
	{
		TextAsset textAsset = Resources.Load<TextAsset>("Text/Transcripts/" + filepath);
		if (textAsset != null)
		{
			return textAsset.text;
		}
		return null;
	}

	public static List<string[]> GetCSV(string filepath)
	{
		return (from line in Resources.Load<TextAsset>("Text/" + filepath).text.Split('\n')
			select line.Split(';')).ToList();
	}

	public static Dictionary<string, Clue> GetAllClues(string folderPath, int level)
	{
		Dictionary<string, Clue> dictionary = new Dictionary<string, Clue>();
		Debug.Log($"Loading clues from {folderPath}/{level}");
		string[] array = ParseTextFile($"Clues/{level}");
		foreach (string text in array)
		{
			string text2 = "Images/" + folderPath + text;
			Debug.Log(text2);
			Clue clue = new Clue();
			Sprite sprite = Resources.Load<Sprite>(text2);
			if (sprite != null)
			{
				Debug.Log("Setting photo clue for " + text);
				clue.photoClue = sprite;
			}
			else
			{
				clue.audioClue = Resources.Load<AudioClip>("Audio/" + folderPath + text);
			}
			dictionary.Add(text, clue);
		}
		return dictionary;
	}

	public static Sprite GetImage(string filePath)
	{
		return Resources.Load<Sprite>("Images/" + filePath);
	}

	public static Texture2D GetTexture(string filePath)
	{
		return Resources.Load<Texture2D>("Images/" + filePath);
	}

	public static Dictionary<AudioClip, string> GetSongNames()
	{
		Dictionary<AudioClip, string> dictionary = new Dictionary<AudioClip, string>();
		string[] array = ParseTextFile("Music/songs");
		foreach (string text in array)
		{
			Debug.Log("song: " + text);
			dictionary.Add(Resources.Load<AudioClip>("Music/" + text), text);
		}
		return dictionary;
	}

	public static AudioClip GetSoundEffect(string clipName)
	{
		return Resources.Load<AudioClip>("Audio//Sound Effects/" + clipName);
	}

	public static (List<AudioClip>, Dictionary<AudioClip, string>) GetSongs()
	{
		List<AudioClip> list = new List<AudioClip>();
		Dictionary<AudioClip, string> dictionary = new Dictionary<AudioClip, string>();
		string[] array = ParseTextFile("Music/songs");
		foreach (string text in array)
		{
			Debug.Log("song: " + text);
			AudioClip song = GetSong(text);
			list.Add(song);
			dictionary.Add(song, text);
		}
		return (list, dictionary);
	}

	public static AudioClip GetSong(string songName)
	{
		return Resources.Load<AudioClip>("Music/" + songName);
	}

	public static GameObject GetWebsite(string url)
	{
		return Resources.Load<GameObject>("Websites/" + url);
	}

	public static Message GetAudioMessage(string folderPath, string filename)
	{
		Debug.Log("Loading audio messages from " + folderPath + filename);
		return new Message
		{
			transcriptText = Resources.Load<TextAsset>("Text/" + folderPath + filename).text,
			message = Resources.Load<AudioClip>("Audio/" + folderPath + filename),
			title = filename
		};
	}
}
